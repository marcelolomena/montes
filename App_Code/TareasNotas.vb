'------------------------------------------------------------
' Código generado por ZRISMART SF el 14-06-2011 20:51:15
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class TareasNotas
    Public Function LeerTareasNotas(ByVal TareasNotasId As Long, ByRef TareasCodigo As String, ByRef TareasNotasSecuencia As Long, ByRef TareasNotasTime As Date, ByRef TareasNotasFrom As String, ByRef TareasNotasTo As String, ByRef TareasNotasSubject As String, ByRef TareasNotasBody As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasCodigo, TareasNotasSecuencia, TareasNotasTime, TareasNotasFrom, TareasNotasTo, TareasNotasSubject, TareasNotasBody "
        sSQL = sSQL & "FROM (TareasNotas) "
        sSQL = sSQL & "WHERE (TareasNotas.TareasNotasId = " & TareasNotasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TareasCodigo = CStr(dtr("TareasCodigo").ToString)
                If Len(dtr("TareasNotasSecuencia").ToString) = 0 Then
                    TareasNotasSecuencia = 0
                Else
                    TareasNotasSecuencia = CLng(dtr("TareasNotasSecuencia").ToString)
                End If
                If Len(dtr("TareasNotasTime").ToString) = 0 Then
                    TareasNotasTime = "01/01/01"
                Else
                    TareasNotasTime = CDate(dtr("TareasNotasTime").ToString)
                End If
                TareasNotasFrom = CStr(dtr("TareasNotasFrom").ToString)
                TareasNotasTo = CStr(dtr("TareasNotasTo").ToString)
                TareasNotasSubject = CStr(dtr("TareasNotasSubject").ToString)
                TareasNotasBody = CStr(dtr("TareasNotasBody").ToString)
            End While
            LeerTareasNotas = True
            dtr.Close()
        Catch
            LeerTareasNotas = False
        End Try
    End Function
    Public Function TareasNotasUpdate(ByVal TareasNotasId As Long, ByRef TareasCodigo As String, ByRef TareasNotasSecuencia As Long, ByRef TareasNotasTime As Date, ByRef TareasNotasFrom As String, ByRef TareasNotasTo As String, ByRef TareasNotasSubject As String, ByRef TareasNotasBody As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE TareasNotas SET "
        strUpdate = strUpdate & "TareasNotas.TareasCodigo = '" & TareasCodigo & "', "
        strUpdate = strUpdate & "TareasNotas.TareasNotasSecuencia = " & TareasNotasSecuencia & ", "
        strUpdate = strUpdate & "TareasNotas.TareasNotasTime = '" & AccionesABM.DateTransform(TareasNotasTime) & "', "
        strUpdate = strUpdate & "TareasNotas.TareasNotasFrom = '" & TareasNotasFrom & "', "
        strUpdate = strUpdate & "TareasNotas.TareasNotasTo = '" & TareasNotasTo & "', "
        strUpdate = strUpdate & "TareasNotas.TareasNotasSubject = '" & TareasNotasSubject & "', "
        strUpdate = strUpdate & "TareasNotas.TareasNotasBody = '" & TareasNotasBody & "', "
        strUpdate = strUpdate & "TareasNotas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "TareasNotas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE TareasNotas.TareasNotasId = " & TareasNotasId
        Try
            TareasNotasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & TareasCodigo, TareasNotasId, "TareasNotas", "")
        Catch
            TareasNotasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TareasCodigo, TareasNotasId, "TareasNotas", "")
        End Try
    End Function
    Public Function TareasNotasInsert(ByRef TareasNotasId As Long, ByRef TareasCodigo As String, ByRef TareasNotasSecuencia As Long, ByRef TareasNotasTime As Date, ByRef TareasNotasFrom As String, ByRef TareasNotasTo As String, ByRef TareasNotasSubject As String, ByRef TareasNotasBody As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim TareasNotas As New TareasNotas
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = TareasCodigo
            DetailSecuencia = TareasNotasSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("TareasNotasId", "TareasCodigo", "TareasNotasSecuencia", "TareasNotas", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("TareasNotasId", "TareasCodigo", "TareasNotasSecuencia", "TareasNotas", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            TareasNotasInsert = TareasNotas.TareasNotasUpdate(DetailId, CStr(TareasCodigo), CLng(TareasNotasSecuencia), CDate(TareasNotasTime), CStr(TareasNotasFrom), CStr(TareasNotasTo), CStr(TareasNotasSubject), CStr(TareasNotasBody), UserId)
        Catch
            TareasNotasInsert = 0
        End Try
    End Function
    Public Function TareasNotasDelete(ByVal TareasNotasId As Long, ByVal TareasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (TareasNotas) "
        strUpdate = strUpdate & "WHERE (TareasNotas.TareasNotasId = " & TareasNotasId & ") "
        Try
            TareasNotasDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & TareasCodigo, TareasNotasId, "TareasNotas", "")
        Catch
            TareasNotasDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & TareasCodigo, TareasNotasId, "TareasNotas", "")
        End Try
    End Function
End Class
