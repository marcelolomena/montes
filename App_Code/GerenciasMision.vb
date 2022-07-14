'------------------------------------------------------------
' Código generado por ZRISMART SF el 09-08-2011 17:20:22
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class GerenciasMision
Public Function LeerGerenciasMision(ByVal GerenciasMisionId As Long, ByRef GerenciasCodigo As String, ByRef GerenciasMisionSecuencia As String, ByRef GerenciasMisionDescription As String, ByRef GerenciasMisionYear As String) As Boolean
Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
Dim sSQL As String
sSQL = "Select GerenciasCodigo, GerenciasMisionSecuencia, GerenciasMisionDescription, GerenciasMisionYear "
sSQL = sSQL & "FROM (GerenciasMision) "
sSQL = sSQL & "WHERE (GerenciasMision.GerenciasMisionId = " & GerenciasMisionId & ") "
Try
dtr = AccesoEA.ListarRegistros(sSQL)
While dtr.Read
GerenciasCodigo = CStr(dtr("GerenciasCodigo").ToString)
GerenciasMisionSecuencia = CStr(dtr("GerenciasMisionSecuencia").ToString)
GerenciasMisionDescription = CStr(dtr("GerenciasMisionDescription").ToString)
GerenciasMisionYear = CStr(dtr("GerenciasMisionYear").ToString)
End While
LeerGerenciasMision = True
dtr.Close()
Catch
LeerGerenciasMision = False
End Try
End Function
Public Function GerenciasMisionUpdate(ByVal GerenciasMisionId As Long, ByRef GerenciasCodigo As String, ByRef GerenciasMisionSecuencia As String, ByRef GerenciasMisionDescription As String, ByRef GerenciasMisionYear As String, ByVal UserId As Long) As Integer
Dim AccesoEA As New AccesoEA
Dim strUpdate As String
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
strUpdate = "UPDATE GerenciasMision SET "
strUpdate = strUpdate & "GerenciasMision.GerenciasCodigo = '" & GerenciasCodigo & "', "
strUpdate = strUpdate & "GerenciasMision.GerenciasMisionSecuencia = '" & GerenciasMisionSecuencia & "', "
strUpdate = strUpdate & "GerenciasMision.GerenciasMisionDescription = '" & GerenciasMisionDescription & "', "
strUpdate = strUpdate & "GerenciasMision.GerenciasMisionYear = '" & GerenciasMisionYear & "', "
strUpdate = strUpdate & "GerenciasMision.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
strUpdate = strUpdate & "GerenciasMision.UserLastUpdate = " & UserId & " "
strUpdate = strUpdate & "WHERE GerenciasMision.GerenciasMisionId = " & GerenciasMisionId
Try
GerenciasMisionUpdate = AccesoEA.ABMRegistros(strUpdate)
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & GerenciasCodigo, GerenciasMisionId, "GerenciasMision", "")
Catch
GerenciasMisionUpdate = 0
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & GerenciasCodigo, GerenciasMisionId, "GerenciasMision", "")
End Try
End Function
Public Function GerenciasMisionInsert(ByRef GerenciasMisionId As Long, ByRef GerenciasCodigo As String, ByRef GerenciasMisionSecuencia As String, ByRef GerenciasMisionDescription As String, ByRef GerenciasMisionYear As String, ByVal UserId As Long) As Integer
Dim Lecturas As New Lecturas
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
Dim GerenciasMision As New GerenciasMision
Dim MasterId As Long = 0
Dim MasterName As String = ""
Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
Try
MasterName = GerenciasCodigo
DetailSecuencia = GerenciasMisionSecuencia
DetailId = 0
t = Lecturas.LeerObjectByNameAndSecuencia("GerenciasMisionId", "GerenciasCodigo", "GerenciasMisionSecuencia", "GerenciasMision", MasterName, DetailSecuencia, DetailId)
If DetailId = 0 Then
t = AccionesABM.ObjectPartialInsert("GerenciasMisionId", "GerenciasCodigo", "GerenciasMisionSecuencia", "GerenciasMision", MasterName, DetailSecuencia, UserId, DetailId)
End If
GerenciasMisionInsert = GerenciasMision.GerenciasMisionUpdate(DetailId, CStr(GerenciasCodigo), CStr(GerenciasMisionSecuencia), CStr(GerenciasMisionDescription), CStr(GerenciasMisionYear), UserId)
Catch
GerenciasMisionInsert = 0
End Try
End Function
Public Function GerenciasMisionDelete(ByVal GerenciasMisionId As Long, ByVal GerenciasCodigo As String, ByVal UserId As Long) As Integer
Dim AccesoEA As New AccesoEA
Dim strUpdate As String
Dim AccionesABM As New AccionesABM
Dim t As Integer
strUpdate = "Delete "
strUpdate = strUpdate & "FROM (GerenciasMision) "
strUpdate = strUpdate & "WHERE (GerenciasMision.GerenciasMisionId = " & GerenciasMisionId & ") "
Try
GerenciasMisionDelete = AccesoEA.ABMRegistros(strUpdate)
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & GerenciasCodigo, GerenciasMisionId, "GerenciasMision", "")
Catch
GerenciasMisionDelete = 0
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & GerenciasCodigo, GerenciasMisionId, "GerenciasMision", "")
End Try
End Function
End Class
