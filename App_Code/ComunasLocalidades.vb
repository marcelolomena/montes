'------------------------------------------------------------
' Código generado por ZRISMART SF el 19-10-2011 8:37:36
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class ComunasLocalidades
Public Function LeerComunasLocalidades(ByVal ComunasLocalidadesId As Long, ByRef ComunasCodigo As String, ByRef ComunasLocalidadesSecuencia As Long, ByRef ComunasLocalidadesNombre As String) As Boolean
Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
Dim sSQL As String
sSQL = "Select ComunasCodigo, ComunasLocalidadesSecuencia, ComunasLocalidadesNombre "
sSQL = sSQL & "FROM (ComunasLocalidades) "
sSQL = sSQL & "WHERE (ComunasLocalidades.ComunasLocalidadesId = " & ComunasLocalidadesId & ") "
Try
dtr = AccesoEA.ListarRegistros(sSQL)
While dtr.Read
ComunasCodigo = CStr(dtr("ComunasCodigo").ToString)
If Len(dtr("ComunasLocalidadesSecuencia").ToString) = 0 Then
ComunasLocalidadesSecuencia = 0
Else
ComunasLocalidadesSecuencia = CLng(dtr("ComunasLocalidadesSecuencia").ToString)
End If
ComunasLocalidadesNombre = CStr(dtr("ComunasLocalidadesNombre").ToString)
End While
LeerComunasLocalidades = True
dtr.Close()
Catch
LeerComunasLocalidades = False
End Try
End Function
Public Function ComunasLocalidadesUpdate(ByVal ComunasLocalidadesId As Long, ByRef ComunasCodigo As String, ByRef ComunasLocalidadesSecuencia As Long, ByRef ComunasLocalidadesNombre As String, ByVal UserId As Long) As Integer
Dim AccesoEA As New AccesoEA
Dim strUpdate As String
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
strUpdate = "UPDATE ComunasLocalidades SET "
strUpdate = strUpdate & "ComunasLocalidades.ComunasCodigo = '" & ComunasCodigo & "', "
strUpdate = strUpdate & "ComunasLocalidades.ComunasLocalidadesSecuencia = " & ComunasLocalidadesSecuencia & ", "
strUpdate = strUpdate & "ComunasLocalidades.ComunasLocalidadesNombre = '" & ComunasLocalidadesNombre & "', "
strUpdate = strUpdate & "ComunasLocalidades.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
strUpdate = strUpdate & "ComunasLocalidades.UserLastUpdate = " & UserId & " "
strUpdate = strUpdate & "WHERE ComunasLocalidades.ComunasLocalidadesId = " & ComunasLocalidadesId
Try
ComunasLocalidadesUpdate = AccesoEA.ABMRegistros(strUpdate)
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ComunasCodigo, ComunasLocalidadesId, "ComunasLocalidades", "")
Catch
ComunasLocalidadesUpdate = 0
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ComunasCodigo, ComunasLocalidadesId, "ComunasLocalidades", "")
End Try
End Function
Public Function ComunasLocalidadesInsert(ByRef ComunasLocalidadesId As Long, ByRef ComunasCodigo As String, ByRef ComunasLocalidadesSecuencia As Long, ByRef ComunasLocalidadesNombre As String, ByVal UserId As Long) As Integer
Dim Lecturas As New Lecturas
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
Dim ComunasLocalidades As New ComunasLocalidades
Dim MasterId As Long = 0
Dim MasterName As String = ""
Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
Try
MasterName = ComunasCodigo
DetailSecuencia = ComunasLocalidadesSecuencia
DetailId = 0
t = Lecturas.LeerObjectByNameAndSecuencia("ComunasLocalidadesId", "ComunasCodigo", "ComunasLocalidadesSecuencia", "ComunasLocalidades", MasterName, DetailSecuencia, DetailId)
If DetailId = 0 Then
t = AccionesABM.ObjectPartialInsert("ComunasLocalidadesId", "ComunasCodigo", "ComunasLocalidadesSecuencia", "ComunasLocalidades", MasterName, DetailSecuencia, UserId, DetailId)
End If
ComunasLocalidadesInsert = ComunasLocalidades.ComunasLocalidadesUpdate(DetailId, CStr(ComunasCodigo), CLng(ComunasLocalidadesSecuencia), CStr(ComunasLocalidadesNombre), UserId)
Catch
ComunasLocalidadesInsert = 0
End Try
End Function
Public Function ComunasLocalidadesDelete(ByVal ComunasLocalidadesId As Long, ByVal ComunasCodigo As String, ByVal UserId As Long) As Integer
Dim AccesoEA As New AccesoEA
Dim strUpdate As String
Dim AccionesABM As New AccionesABM
Dim t As Integer
strUpdate = "Delete "
strUpdate = strUpdate & "FROM (ComunasLocalidades) "
strUpdate = strUpdate & "WHERE (ComunasLocalidades.ComunasLocalidadesId = " & ComunasLocalidadesId & ") "
Try
ComunasLocalidadesDelete = AccesoEA.ABMRegistros(strUpdate)
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & ComunasCodigo, ComunasLocalidadesId, "ComunasLocalidades", "")
Catch
ComunasLocalidadesDelete = 0
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & ComunasCodigo, ComunasLocalidadesId, "ComunasLocalidades", "")
End Try
End Function
End Class
