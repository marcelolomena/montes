'------------------------------------------------------------
' Código generado por ZRISMART SF el 18-10-2011 19:32:23
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class ComunasConcejales
Public Function LeerComunasConcejales(ByVal ComunasConcejalesId As Long, ByRef ComunasCodigo As String, ByRef ComunasConcejalesSecuencia As Long, ByRef ComunasConcejalesNombre As String) As Boolean
Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
Dim sSQL As String
sSQL = "Select ComunasCodigo, ComunasConcejalesSecuencia, ComunasConcejalesNombre "
sSQL = sSQL & "FROM (ComunasConcejales) "
sSQL = sSQL & "WHERE (ComunasConcejales.ComunasConcejalesId = " & ComunasConcejalesId & ") "
Try
dtr = AccesoEA.ListarRegistros(sSQL)
While dtr.Read
ComunasCodigo = CStr(dtr("ComunasCodigo").ToString)
If Len(dtr("ComunasConcejalesSecuencia").ToString) = 0 Then
ComunasConcejalesSecuencia = 0
Else
ComunasConcejalesSecuencia = CLng(dtr("ComunasConcejalesSecuencia").ToString)
End If
ComunasConcejalesNombre = CStr(dtr("ComunasConcejalesNombre").ToString)
End While
LeerComunasConcejales = True
dtr.Close()
Catch
LeerComunasConcejales = False
End Try
End Function
Public Function ComunasConcejalesUpdate(ByVal ComunasConcejalesId As Long, ByRef ComunasCodigo As String, ByRef ComunasConcejalesSecuencia As Long, ByRef ComunasConcejalesNombre As String, ByVal UserId As Long) As Integer
Dim AccesoEA As New AccesoEA
Dim strUpdate As String
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
strUpdate = "UPDATE ComunasConcejales SET "
strUpdate = strUpdate & "ComunasConcejales.ComunasCodigo = '" & ComunasCodigo & "', "
strUpdate = strUpdate & "ComunasConcejales.ComunasConcejalesSecuencia = " & ComunasConcejalesSecuencia & ", "
strUpdate = strUpdate & "ComunasConcejales.ComunasConcejalesNombre = '" & ComunasConcejalesNombre & "', "
strUpdate = strUpdate & "ComunasConcejales.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
strUpdate = strUpdate & "ComunasConcejales.UserLastUpdate = " & UserId & " "
strUpdate = strUpdate & "WHERE ComunasConcejales.ComunasConcejalesId = " & ComunasConcejalesId
Try
ComunasConcejalesUpdate = AccesoEA.ABMRegistros(strUpdate)
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ComunasCodigo, ComunasConcejalesId, "ComunasConcejales", "")
Catch
ComunasConcejalesUpdate = 0
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ComunasCodigo, ComunasConcejalesId, "ComunasConcejales", "")
End Try
End Function
Public Function ComunasConcejalesInsert(ByRef ComunasConcejalesId As Long, ByRef ComunasCodigo As String, ByRef ComunasConcejalesSecuencia As Long, ByRef ComunasConcejalesNombre As String, ByVal UserId As Long) As Integer
Dim Lecturas As New Lecturas
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
Dim ComunasConcejales As New ComunasConcejales
Dim MasterId As Long = 0
Dim MasterName As String = ""
Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
Try
MasterName = ComunasCodigo
DetailSecuencia = ComunasConcejalesSecuencia
DetailId = 0
t = Lecturas.LeerObjectByNameAndSecuencia("ComunasConcejalesId", "ComunasCodigo", "ComunasConcejalesSecuencia", "ComunasConcejales", MasterName, DetailSecuencia, DetailId)
If DetailId = 0 Then
t = AccionesABM.ObjectPartialInsert("ComunasConcejalesId", "ComunasCodigo", "ComunasConcejalesSecuencia", "ComunasConcejales", MasterName, DetailSecuencia, UserId, DetailId)
End If
ComunasConcejalesInsert = ComunasConcejales.ComunasConcejalesUpdate(DetailId, CStr(ComunasCodigo), CLng(ComunasConcejalesSecuencia), CStr(ComunasConcejalesNombre), UserId)
Catch
ComunasConcejalesInsert = 0
End Try
End Function
Public Function ComunasConcejalesDelete(ByVal ComunasConcejalesId As Long, ByVal ComunasCodigo As String, ByVal UserId As Long) As Integer
Dim AccesoEA As New AccesoEA
Dim strUpdate As String
Dim AccionesABM As New AccionesABM
Dim t As Integer
strUpdate = "Delete "
strUpdate = strUpdate & "FROM (ComunasConcejales) "
strUpdate = strUpdate & "WHERE (ComunasConcejales.ComunasConcejalesId = " & ComunasConcejalesId & ") "
Try
ComunasConcejalesDelete = AccesoEA.ABMRegistros(strUpdate)
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & ComunasCodigo, ComunasConcejalesId, "ComunasConcejales", "")
Catch
ComunasConcejalesDelete = 0
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & ComunasCodigo, ComunasConcejalesId, "ComunasConcejales", "")
End Try
End Function
End Class
