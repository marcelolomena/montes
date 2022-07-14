'------------------------------------------------------------
' Código generado por ZRISMART SF el 09-08-2011 20:47:41
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class IniciativasEstrategicas
    Public Function LeerIniciativasEstrategicas(ByVal IniciativasEstrategicasId As Long, ByRef DimensionesEstrategicasCodigo As String, ByRef IniciativasEstrategicasSecuencia As Long, ByRef IniciativasEstrategicasName As String, ByRef IniciativasEstrategicasDescription As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select DimensionesEstrategicasCodigo, IniciativasEstrategicasSecuencia, IniciativasEstrategicasName, IniciativasEstrategicasDescription "
        sSQL = sSQL & "FROM (IniciativasEstrategicas) "
        sSQL = sSQL & "WHERE (IniciativasEstrategicas.IniciativasEstrategicasId = " & IniciativasEstrategicasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                DimensionesEstrategicasCodigo = CStr(dtr("DimensionesEstrategicasCodigo").ToString)
                If Len(dtr("IniciativasEstrategicasSecuencia").ToString) = 0 Then
                    IniciativasEstrategicasSecuencia = 0
                Else
                    IniciativasEstrategicasSecuencia = CLng(dtr("IniciativasEstrategicasSecuencia").ToString)
                End If
                IniciativasEstrategicasName = CStr(dtr("IniciativasEstrategicasName").ToString)
                IniciativasEstrategicasDescription = CStr(dtr("IniciativasEstrategicasDescription").ToString)
            End While
            LeerIniciativasEstrategicas = True
            dtr.Close()
        Catch
            LeerIniciativasEstrategicas = False
        End Try
    End Function
    Public Function IniciativasEstrategicasUpdate(ByVal IniciativasEstrategicasId As Long, ByRef DimensionesEstrategicasCodigo As String, ByRef IniciativasEstrategicasSecuencia As Long, ByRef IniciativasEstrategicasName As String, ByRef IniciativasEstrategicasDescription As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE IniciativasEstrategicas SET "
        strUpdate = strUpdate & "IniciativasEstrategicas.DimensionesEstrategicasCodigo = '" & DimensionesEstrategicasCodigo & "', "
        strUpdate = strUpdate & "IniciativasEstrategicas.IniciativasEstrategicasSecuencia = " & IniciativasEstrategicasSecuencia & ", "
        strUpdate = strUpdate & "IniciativasEstrategicas.IniciativasEstrategicasName = '" & IniciativasEstrategicasName & "', "
        strUpdate = strUpdate & "IniciativasEstrategicas.IniciativasEstrategicasDescription = '" & IniciativasEstrategicasDescription & "', "
        strUpdate = strUpdate & "IniciativasEstrategicas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "IniciativasEstrategicas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE IniciativasEstrategicas.IniciativasEstrategicasId = " & IniciativasEstrategicasId
        Try
            IniciativasEstrategicasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & DimensionesEstrategicasCodigo, IniciativasEstrategicasId, "IniciativasEstrategicas", "")
        Catch
            IniciativasEstrategicasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & DimensionesEstrategicasCodigo, IniciativasEstrategicasId, "IniciativasEstrategicas", "")
        End Try
    End Function
    Public Function IniciativasEstrategicasInsert(ByRef IniciativasEstrategicasId As Long, ByRef DimensionesEstrategicasCodigo As String, ByRef IniciativasEstrategicasSecuencia As Long, ByRef IniciativasEstrategicasName As String, ByRef IniciativasEstrategicasDescription As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim IniciativasEstrategicas As New IniciativasEstrategicas
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = DimensionesEstrategicasCodigo
            DetailSecuencia = IniciativasEstrategicasSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("IniciativasEstrategicasId", "DimensionesEstrategicasCodigo", "IniciativasEstrategicasSecuencia", "IniciativasEstrategicas", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("IniciativasEstrategicasId", "DimensionesEstrategicasCodigo", "IniciativasEstrategicasSecuencia", "IniciativasEstrategicas", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            IniciativasEstrategicasInsert = IniciativasEstrategicas.IniciativasEstrategicasUpdate(DetailId, CStr(DimensionesEstrategicasCodigo), CLng(IniciativasEstrategicasSecuencia), CStr(IniciativasEstrategicasName), CStr(IniciativasEstrategicasDescription), UserId)
        Catch
            IniciativasEstrategicasInsert = 0
        End Try
    End Function
    Public Function IniciativasEstrategicasDelete(ByVal IniciativasEstrategicasId As Long, ByVal DimensionesEstrategicasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (IniciativasEstrategicas) "
        strUpdate = strUpdate & "WHERE (IniciativasEstrategicas.IniciativasEstrategicasId = " & IniciativasEstrategicasId & ") "
        Try
            IniciativasEstrategicasDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & DimensionesEstrategicasCodigo, IniciativasEstrategicasId, "IniciativasEstrategicas", "")
        Catch
            IniciativasEstrategicasDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & DimensionesEstrategicasCodigo, IniciativasEstrategicasId, "IniciativasEstrategicas", "")
        End Try
    End Function
End Class
