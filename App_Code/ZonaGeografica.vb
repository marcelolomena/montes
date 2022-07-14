'------------------------------------------------------------
' Código generado por ZRISMART SF el 10-08-2011 11:08:55
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class ZonaGeografica
    Public Function LeerZonaGeografica(ByVal ZonaGeograficaId As Long, ByRef ZonaGeograficaName As String, ByRef ZonaGeograficaDescription As String, ByRef ZonaGeograficaSecuencia As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ZonaGeograficaName, ZonaGeograficaDescription, ZonaGeograficaSecuencia "
        sSQL = sSQL & "FROM (ZonaGeografica) "
        sSQL = sSQL & "WHERE (ZonaGeografica.ZonaGeograficaId = " & ZonaGeograficaId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ZonaGeograficaName = CStr(dtr("ZonaGeograficaName").ToString)
                ZonaGeograficaDescription = CStr(dtr("ZonaGeograficaDescription").ToString)
                If Len(dtr("ZonaGeograficaSecuencia").ToString) = 0 Then
                    ZonaGeograficaSecuencia = 0
                Else
                    ZonaGeograficaSecuencia = CLng(dtr("ZonaGeograficaSecuencia").ToString)
                End If
            End While
            LeerZonaGeografica = True
            dtr.Close()
        Catch
            LeerZonaGeografica = False
        End Try
    End Function
    Public Function LeerZonaGeograficaByName(ByRef ZonaGeograficaId As Long, ByVal ZonaGeograficaName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ZonaGeograficaId "
        sSQL = sSQL & "FROM (ZonaGeografica) "
        sSQL = sSQL & "WHERE (ZonaGeografica.ZonaGeograficaName = '" & ZonaGeograficaName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ZonaGeograficaId = CLng(dtr("ZonaGeograficaId").ToString)
            End While
            LeerZonaGeograficaByName = True
            dtr.Close()
        Catch
            LeerZonaGeograficaByName = False
        End Try
    End Function
    Public Function LeerZonaGeograficaDescriptionByName(ByRef ZonaGeograficaName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        LeerZonaGeograficaDescriptionByName = ""
        sSQL = "Select ZonaGeograficaDescription "
        sSQL = sSQL & "FROM (ZonaGeografica) "
        sSQL = sSQL & "WHERE (ZonaGeografica.ZonaGeograficaName = '" & ZonaGeograficaName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerZonaGeograficaDescriptionByName = CStr(dtr("ZonaGeograficaDescription").ToString)
            End While
            dtr.Close()
        Catch
            LeerZonaGeograficaDescriptionByName = " "
        End Try
    End Function
    Public Function ZonaGeograficaUpdate(ByVal ZonaGeograficaId As Long, ByRef ZonaGeograficaName As String, ByRef ZonaGeograficaDescription As String, ByRef ZonaGeograficaSecuencia As Long, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE ZonaGeografica SET "
        strUpdate = strUpdate & "ZonaGeografica.ZonaGeograficaName = '" & ZonaGeograficaName & "', "
        strUpdate = strUpdate & "ZonaGeografica.ZonaGeograficaDescription = '" & ZonaGeograficaDescription & "', "
        strUpdate = strUpdate & "ZonaGeografica.ZonaGeograficaSecuencia = " & ZonaGeograficaSecuencia & ", "
        strUpdate = strUpdate & "ZonaGeografica.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "ZonaGeografica.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE ZonaGeografica.ZonaGeograficaId = " & ZonaGeograficaId
        Try
            ZonaGeograficaUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ZonaGeograficaName, ZonaGeograficaId, "ZonaGeografica", "")
        Catch
            ZonaGeograficaUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ZonaGeograficaName, ZonaGeograficaId, "ZonaGeografica", "")
        End Try
    End Function
    Public Function ZonaGeograficaInsert(ByRef ZonaGeograficaId As Long, ByRef ZonaGeograficaName As String, ByRef ZonaGeograficaDescription As String, ByRef ZonaGeograficaSecuencia As Long, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim ZonaGeografica As New ZonaGeografica
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = ZonaGeograficaName
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("ZonaGeograficaId", "ZonaGeograficaName", "ZonaGeografica", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("ZonaGeograficaId", "ZonaGeograficaName", "ZonaGeografica", MasterName, CLng(UserId), MasterId)
            End If
            ZonaGeograficaInsert = ZonaGeografica.ZonaGeograficaUpdate(MasterId, CStr(ZonaGeograficaName), CStr(ZonaGeograficaDescription), CLng(ZonaGeograficaSecuencia), UserId)
        Catch
            ZonaGeograficaInsert = 0
        End Try
    End Function
    Public Function LeerTotalZonaGeograficaPorDocumentos(ByVal ZonaGeograficaName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM ZonaGeografica INNER JOIN GerenciasPrograma ON ZonaGeografica.ZonaGeograficaName = GerenciasPrograma.ZonaGeograficaName "
        sSQL = sSQL & "WHERE (((ZonaGeografica.ZonaGeograficaName)='" & ZonaGeograficaName & "'))"
        LeerTotalZonaGeograficaPorDocumentos = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalZonaGeograficaPorDocumentos = LeerTotalZonaGeograficaPorDocumentos + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalZonaGeograficaPorDocumentos = 0
        End Try
    End Function
    Public Function ZonaGeograficaDelete(ByVal ZonaGeograficaId As Long, ByVal ZonaGeograficaName As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim ZonaGeografica As New ZonaGeografica

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = ZonaGeografica.LeerTotalZonaGeograficaPorDocumentos(ZonaGeograficaName)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " Programas asociados a la Zona " & ZonaGeograficaName & vbCrLf
            Mensaje = Mensaje & "Cambie la Zona a los Programas, antes de eliminarlo de la lista"
            ZonaGeograficaDelete = False
        Else
            Try
                ' Borra registro de la tabla de Roles
                '-------------------------------------
                strUpdate = "DELETE FROM ZonaGeografica WHERE ZonaGeograficaId = " & ZonaGeograficaId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina la Zona: " & ZonaGeograficaName, ZonaGeograficaId, "ZonaGeografica", "")
                ZonaGeograficaDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la Zona: " & ZonaGeograficaName, ZonaGeograficaId, "ZonaGeografica", "")
                ZonaGeograficaDelete = False
            End Try
        End If
    End Function
End Class
