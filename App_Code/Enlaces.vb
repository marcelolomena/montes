'------------------------------------------------------------
' Código generado por ZRISMART SF el 26-01-2011 16:19:24
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Enlaces
Public Function LeerEnlaces(ByVal EnlacesId As Long, ByRef EnlacesName As String, ByRef EnlacesSecuencia As Long, ByRef EnlacesURL As String) As Boolean
Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EnlacesName, EnlacesSecuencia, EnlacesURL "
        sSQL = sSQL & "FROM (Enlaces) "
        sSQL = sSQL & "WHERE (Enlaces.EnlacesId = " & EnlacesId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                EnlacesName = CStr(dtr("EnlacesName").ToString)
                If Len(dtr("EnlacesSecuencia").ToString) = 0 Then
                    EnlacesSecuencia = 0
                Else
                    EnlacesSecuencia = CLng(dtr("EnlacesSecuencia").ToString)
                End If
                EnlacesURL = CStr(dtr("EnlacesURL").ToString)
            End While
            LeerEnlaces = True
            dtr.Close()
        Catch
            LeerEnlaces = False
        End Try
    End Function
    Public Function LeerEnlacesByName(ByRef EnlacesId As Long, ByVal EnlacesName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EnlacesId "
        sSQL = sSQL & "FROM (Enlaces) "
        sSQL = sSQL & "WHERE (Enlaces.EnlacesName = '" & EnlacesName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                EnlacesId = CLng(dtr("EnlacesId").ToString)
            End While
            LeerEnlacesByName = True
            dtr.Close()
        Catch
            LeerEnlacesByName = False
        End Try
    End Function
Public Function EnlacesUpdate(ByVal EnlacesId As Long, ByRef EnlacesName As String, ByRef EnlacesSecuencia As Long, ByRef EnlacesURL As String, ByVal UserId As Long) As Integer
Dim AccesoEA As New AccesoEA
Dim strUpdate As String
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
strUpdate = "UPDATE Enlaces SET "
strUpdate = strUpdate & "Enlaces.EnlacesName = '" & EnlacesName & "', "
strUpdate = strUpdate & "Enlaces.EnlacesSecuencia = " & EnlacesSecuencia & ", "
strUpdate = strUpdate & "Enlaces.EnlacesURL = '" & EnlacesURL & "', "
strUpdate = strUpdate & "Enlaces.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
strUpdate = strUpdate & "Enlaces.UserLastUpdate = " & UserId & " "
strUpdate = strUpdate & "WHERE Enlaces.EnlacesId = " & EnlacesId
Try
EnlacesUpdate = AccesoEA.ABMRegistros(strUpdate)
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & EnlacesName, EnlacesId, "Enlaces", "")
Catch
EnlacesUpdate = 0
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & EnlacesName, EnlacesId, "Enlaces", "")
End Try
End Function
Public Function EnlacesInsert(ByRef EnlacesId As Long, ByRef EnlacesName As String, ByRef EnlacesSecuencia As Long, ByRef EnlacesURL As String, ByVal UserId As Long) As Integer
Dim Lecturas As New Lecturas
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
Dim Enlaces As New Enlaces
Dim MasterId As Long = 0
Dim MasterName As String = ""
Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
Try
MasterName = EnlacesName
MasterId = 0
t = Lecturas.LeerMasterIdByMasterName("EnlacesId", "EnlacesName", "Enlaces", MasterName, MasterId)
If MasterId = 0 Then
t = AccionesABM.MasterPartialInsert("EnlacesId", "EnlacesName", "Enlaces", MasterName, CLng(UserId), MasterId)
End If
EnlacesInsert = Enlaces.EnlacesUpdate(MasterId, CStr(EnlacesName), CLng(EnlacesSecuencia), CStr(EnlacesURL), UserId)
Catch
EnlacesInsert = 0
End Try
End Function
End Class
