'------------------------------------------------------------
' Código generado por ZRISMART SF el 01-02-2011 11:11:54
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Moneda
Public Function LeerMoneda(ByVal MonedaId As Long, ByRef MonedaName As String, ByRef MonedaDescription As String, ByRef MonedaSecuencia As Long) As Boolean
Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select MonedaName, MonedaDescription, MonedaSecuencia "
        sSQL = sSQL & "FROM (Moneda) "
        sSQL = sSQL & "WHERE (Moneda.MonedaId = " & MonedaId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                MonedaName = CStr(dtr("MonedaName").ToString)
                MonedaDescription = CStr(dtr("MonedaDescription").ToString)
                If Len(dtr("MonedaSecuencia").ToString) = 0 Then
                    MonedaSecuencia = 0
                Else
                    MonedaSecuencia = CLng(dtr("MonedaSecuencia").ToString)
                End If
            End While
            LeerMoneda = True
            dtr.Close()
        Catch
            LeerMoneda = False
        End Try
    End Function
    Public Function LeerMonedaByName(ByRef MonedaId As Long, ByVal MonedaName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select MonedaId "
        sSQL = sSQL & "FROM (Moneda) "
        sSQL = sSQL & "WHERE (Moneda.MonedaName = '" & MonedaName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                MonedaId = CLng(dtr("MonedaId").ToString)
            End While
            LeerMonedaByName = True
            dtr.Close()
        Catch
            LeerMonedaByName = False
        End Try
    End Function
Public Function MonedaUpdate(ByVal MonedaId As Long, ByRef MonedaName As String, ByRef MonedaDescription As String, ByRef MonedaSecuencia As Long, ByVal UserId As Long) As Integer
Dim AccesoEA As New AccesoEA
Dim strUpdate As String
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
strUpdate = "UPDATE Moneda SET "
strUpdate = strUpdate & "Moneda.MonedaName = '" & MonedaName & "', "
strUpdate = strUpdate & "Moneda.MonedaDescription = '" & MonedaDescription & "', "
strUpdate = strUpdate & "Moneda.MonedaSecuencia = " & MonedaSecuencia & ", "
strUpdate = strUpdate & "Moneda.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
strUpdate = strUpdate & "Moneda.UserLastUpdate = " & UserId & " "
strUpdate = strUpdate & "WHERE Moneda.MonedaId = " & MonedaId
Try
MonedaUpdate = AccesoEA.ABMRegistros(strUpdate)
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & MonedaName, MonedaId, "Moneda", "")
Catch
MonedaUpdate = 0
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & MonedaName, MonedaId, "Moneda", "")
End Try
End Function
Public Function MonedaInsert(ByRef MonedaId As Long, ByRef MonedaName As String, ByRef MonedaDescription As String, ByRef MonedaSecuencia As Long, ByVal UserId As Long) As Integer
Dim Lecturas As New Lecturas
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
Dim Moneda As New Moneda
Dim MasterId As Long = 0
Dim MasterName As String = ""
Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
Try
MasterName = MonedaName
MasterId = 0
t = Lecturas.LeerMasterIdByMasterName("MonedaId", "MonedaName", "Moneda", MasterName, MasterId)
If MasterId = 0 Then
t = AccionesABM.MasterPartialInsert("MonedaId", "MonedaName", "Moneda", MasterName, CLng(UserId), MasterId)
End If
MonedaInsert = Moneda.MonedaUpdate(MasterId, CStr(MonedaName), CStr(MonedaDescription), CLng(MonedaSecuencia), UserId)
Catch
MonedaInsert = 0
End Try
End Function
End Class
