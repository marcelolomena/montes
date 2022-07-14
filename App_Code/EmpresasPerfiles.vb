'------------------------------------------------------------
' Código generado por ZRISMART SF el 24-07-2011 15:20:29
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class EmpresasPerfiles
Public Function LeerEmpresasPerfiles(ByVal EmpresasPerfilesId As Long, ByRef EmpresasCodigo As String, ByRef EmpresasPerfilesSecuencia As Long, ByRef EmpresasPerfilesName As String, ByRef EmpresasPerfilesDescription As String, ByRef UsuariosCodigo As String, ByRef EmpresasPerfilesCargo As String) As Boolean
Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
Dim sSQL As String
sSQL = "Select EmpresasCodigo, EmpresasPerfilesSecuencia, EmpresasPerfilesName, EmpresasPerfilesDescription, UsuariosCodigo, EmpresasPerfilesCargo "
sSQL = sSQL & "FROM (EmpresasPerfiles) "
sSQL = sSQL & "WHERE (EmpresasPerfiles.EmpresasPerfilesId = " & EmpresasPerfilesId & ") "
Try
dtr = AccesoEA.ListarRegistros(sSQL)
While dtr.Read
EmpresasCodigo = CStr(dtr("EmpresasCodigo").ToString)
If Len(dtr("EmpresasPerfilesSecuencia").ToString) = 0 Then
EmpresasPerfilesSecuencia = 0
Else
EmpresasPerfilesSecuencia = CLng(dtr("EmpresasPerfilesSecuencia").ToString)
End If
EmpresasPerfilesName = CStr(dtr("EmpresasPerfilesName").ToString)
EmpresasPerfilesDescription = CStr(dtr("EmpresasPerfilesDescription").ToString)
UsuariosCodigo = CStr(dtr("UsuariosCodigo").ToString)
EmpresasPerfilesCargo = CStr(dtr("EmpresasPerfilesCargo").ToString)
End While
LeerEmpresasPerfiles = True
dtr.Close()
Catch
LeerEmpresasPerfiles = False
End Try
End Function
Public Function EmpresasPerfilesUpdate(ByVal EmpresasPerfilesId As Long, ByRef EmpresasCodigo As String, ByRef EmpresasPerfilesSecuencia As Long, ByRef EmpresasPerfilesName As String, ByRef EmpresasPerfilesDescription As String, ByRef UsuariosCodigo As String, ByRef EmpresasPerfilesCargo As String, ByVal UserId As Long) As Integer
Dim AccesoEA As New AccesoEA
Dim strUpdate As String
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
strUpdate = "UPDATE EmpresasPerfiles SET "
strUpdate = strUpdate & "EmpresasPerfiles.EmpresasCodigo = '" & EmpresasCodigo & "', "
strUpdate = strUpdate & "EmpresasPerfiles.EmpresasPerfilesSecuencia = " & EmpresasPerfilesSecuencia & ", "
strUpdate = strUpdate & "EmpresasPerfiles.EmpresasPerfilesName = '" & EmpresasPerfilesName & "', "
strUpdate = strUpdate & "EmpresasPerfiles.EmpresasPerfilesDescription = '" & EmpresasPerfilesDescription & "', "
strUpdate = strUpdate & "EmpresasPerfiles.UsuariosCodigo = '" & UsuariosCodigo & "', "
strUpdate = strUpdate & "EmpresasPerfiles.EmpresasPerfilesCargo = '" & EmpresasPerfilesCargo & "', "
strUpdate = strUpdate & "EmpresasPerfiles.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
strUpdate = strUpdate & "EmpresasPerfiles.UserLastUpdate = " & UserId & " "
strUpdate = strUpdate & "WHERE EmpresasPerfiles.EmpresasPerfilesId = " & EmpresasPerfilesId
Try
EmpresasPerfilesUpdate = AccesoEA.ABMRegistros(strUpdate)
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & EmpresasCodigo, EmpresasPerfilesId, "EmpresasPerfiles", "")
Catch
EmpresasPerfilesUpdate = 0
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & EmpresasCodigo, EmpresasPerfilesId, "EmpresasPerfiles", "")
End Try
End Function
Public Function EmpresasPerfilesInsert(ByRef EmpresasPerfilesId As Long, ByRef EmpresasCodigo As String, ByRef EmpresasPerfilesSecuencia As Long, ByRef EmpresasPerfilesName As String, ByRef EmpresasPerfilesDescription As String, ByRef UsuariosCodigo As String, ByRef EmpresasPerfilesCargo As String, ByVal UserId As Long) As Integer
Dim Lecturas As New Lecturas
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
Dim EmpresasPerfiles As New EmpresasPerfiles
Dim MasterId As Long = 0
Dim MasterName As String = ""
Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
Try
MasterName = EmpresasCodigo
DetailSecuencia = EmpresasPerfilesSecuencia
DetailId = 0
t = Lecturas.LeerObjectByNameAndSecuencia("EmpresasPerfilesId", "EmpresasCodigo", "EmpresasPerfilesSecuencia", "EmpresasPerfiles", MasterName, DetailSecuencia, DetailId)
If DetailId = 0 Then
t = AccionesABM.ObjectPartialInsert("EmpresasPerfilesId", "EmpresasCodigo", "EmpresasPerfilesSecuencia", "EmpresasPerfiles", MasterName, DetailSecuencia, UserId, DetailId)
End If
EmpresasPerfilesInsert = EmpresasPerfiles.EmpresasPerfilesUpdate(DetailId, CStr(EmpresasCodigo), CLng(EmpresasPerfilesSecuencia), CStr(EmpresasPerfilesName), CStr(EmpresasPerfilesDescription), CStr(UsuariosCodigo), CStr(EmpresasPerfilesCargo), UserId)
Catch
EmpresasPerfilesInsert = 0
End Try
End Function
Public Function EmpresasPerfilesDelete(ByVal EmpresasPerfilesId As Long, ByVal EmpresasCodigo As String, ByVal UserId As Long) As Integer
Dim AccesoEA As New AccesoEA
Dim strUpdate As String
Dim AccionesABM As New AccionesABM
Dim t As Integer
strUpdate = "Delete "
strUpdate = strUpdate & "FROM (EmpresasPerfiles) "
strUpdate = strUpdate & "WHERE (EmpresasPerfiles.EmpresasPerfilesId = " & EmpresasPerfilesId & ") "
Try
EmpresasPerfilesDelete = AccesoEA.ABMRegistros(strUpdate)
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & EmpresasCodigo, EmpresasPerfilesId, "EmpresasPerfiles", "")
Catch
EmpresasPerfilesDelete = 0
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & EmpresasCodigo, EmpresasPerfilesId, "EmpresasPerfiles", "")
End Try
End Function
End Class
