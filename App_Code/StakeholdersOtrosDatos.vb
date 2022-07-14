'------------------------------------------------------------
' Código generado por ZRISMART SF el 29-08-2011 14:33:30
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class StakeholdersOtrosDatos
Public Function LeerStakeholdersOtrosDatos(ByVal StakeholdersOtrosDatosId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersOtrosDatosSecuencia As Long, ByRef StakeholdersOtrosDatosNombreDato As String, ByRef StakeholdersOtrosDatosDescription As String, ByRef StakeholdersOtrosDatosValor As Double, ByRef StakeholdersOtrosDatosFecha As Date) As Boolean
Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
Dim sSQL As String
sSQL = "Select StakeholdersCodigo, StakeholdersOtrosDatosSecuencia, StakeholdersOtrosDatosNombreDato, StakeholdersOtrosDatosDescription, StakeholdersOtrosDatosValor, StakeholdersOtrosDatosFecha "
sSQL = sSQL & "FROM (StakeholdersOtrosDatos) "
sSQL = sSQL & "WHERE (StakeholdersOtrosDatos.StakeholdersOtrosDatosId = " & StakeholdersOtrosDatosId & ") "
Try
dtr = AccesoEA.ListarRegistros(sSQL)
While dtr.Read
StakeholdersCodigo = CStr(dtr("StakeholdersCodigo").ToString)
If Len(dtr("StakeholdersOtrosDatosSecuencia").ToString) = 0 Then
StakeholdersOtrosDatosSecuencia = 0
Else
StakeholdersOtrosDatosSecuencia = CLng(dtr("StakeholdersOtrosDatosSecuencia").ToString)
End If
StakeholdersOtrosDatosNombreDato = CStr(dtr("StakeholdersOtrosDatosNombreDato").ToString)
StakeholdersOtrosDatosDescription = CStr(dtr("StakeholdersOtrosDatosDescription").ToString)
If Len(dtr("StakeholdersOtrosDatosValor").ToString) = 0 Then
StakeholdersOtrosDatosValor = 0
Else
StakeholdersOtrosDatosValor = CDbl(dtr("StakeholdersOtrosDatosValor").ToString)
End If
If Len(dtr("StakeholdersOtrosDatosFecha").ToString) = 0 Then
StakeholdersOtrosDatosFecha = "01/01/01"
Else
StakeholdersOtrosDatosFecha = CDate(dtr("StakeholdersOtrosDatosFecha").ToString)
End If
End While
LeerStakeholdersOtrosDatos = True
dtr.Close()
Catch
LeerStakeholdersOtrosDatos = False
End Try
End Function
Public Function StakeholdersOtrosDatosUpdate(ByVal StakeholdersOtrosDatosId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersOtrosDatosSecuencia As Long, ByRef StakeholdersOtrosDatosNombreDato As String, ByRef StakeholdersOtrosDatosDescription As String, ByRef StakeholdersOtrosDatosValor As Double, ByRef StakeholdersOtrosDatosFecha As Date, ByVal UserId As Long) As Integer
Dim AccesoEA As New AccesoEA
Dim strUpdate As String
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
strUpdate = "UPDATE StakeholdersOtrosDatos SET "
strUpdate = strUpdate & "StakeholdersOtrosDatos.StakeholdersCodigo = '" & StakeholdersCodigo & "', "
strUpdate = strUpdate & "StakeholdersOtrosDatos.StakeholdersOtrosDatosSecuencia = " & StakeholdersOtrosDatosSecuencia & ", "
strUpdate = strUpdate & "StakeholdersOtrosDatos.StakeholdersOtrosDatosNombreDato = '" & StakeholdersOtrosDatosNombreDato & "', "
strUpdate = strUpdate & "StakeholdersOtrosDatos.StakeholdersOtrosDatosDescription = '" & StakeholdersOtrosDatosDescription & "', "
strUpdate = strUpdate & "StakeholdersOtrosDatos.StakeholdersOtrosDatosValor = " & StakeholdersOtrosDatosValor & ", "
strUpdate = strUpdate & "StakeholdersOtrosDatos.StakeholdersOtrosDatosFecha = '" & AccionesABM.DateTransform(StakeholdersOtrosDatosFecha) & "', "
strUpdate = strUpdate & "StakeholdersOtrosDatos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
strUpdate = strUpdate & "StakeholdersOtrosDatos.UserLastUpdate = " & UserId & " "
strUpdate = strUpdate & "WHERE StakeholdersOtrosDatos.StakeholdersOtrosDatosId = " & StakeholdersOtrosDatosId
Try
StakeholdersOtrosDatosUpdate = AccesoEA.ABMRegistros(strUpdate)
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & StakeholdersCodigo, StakeholdersOtrosDatosId, "StakeholdersOtrosDatos", "")
Catch
StakeholdersOtrosDatosUpdate = 0
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & StakeholdersCodigo, StakeholdersOtrosDatosId, "StakeholdersOtrosDatos", "")
End Try
End Function
Public Function StakeholdersOtrosDatosInsert(ByRef StakeholdersOtrosDatosId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersOtrosDatosSecuencia As Long, ByRef StakeholdersOtrosDatosNombreDato As String, ByRef StakeholdersOtrosDatosDescription As String, ByRef StakeholdersOtrosDatosValor As Double, ByRef StakeholdersOtrosDatosFecha As Date, ByVal UserId As Long) As Integer
Dim Lecturas As New Lecturas
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
Dim StakeholdersOtrosDatos As New StakeholdersOtrosDatos
Dim MasterId As Long = 0
Dim MasterName As String = ""
Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
Try
MasterName = StakeholdersCodigo
DetailSecuencia = StakeholdersOtrosDatosSecuencia
DetailId = 0
t = Lecturas.LeerObjectByNameAndSecuencia("StakeholdersOtrosDatosId", "StakeholdersCodigo", "StakeholdersOtrosDatosSecuencia", "StakeholdersOtrosDatos", MasterName, DetailSecuencia, DetailId)
If DetailId = 0 Then
t = AccionesABM.ObjectPartialInsert("StakeholdersOtrosDatosId", "StakeholdersCodigo", "StakeholdersOtrosDatosSecuencia", "StakeholdersOtrosDatos", MasterName, DetailSecuencia, UserId, DetailId)
End If
StakeholdersOtrosDatosInsert = StakeholdersOtrosDatos.StakeholdersOtrosDatosUpdate(DetailId, CStr(StakeholdersCodigo), CLng(StakeholdersOtrosDatosSecuencia), CStr(StakeholdersOtrosDatosNombreDato), CStr(StakeholdersOtrosDatosDescription), CDbl(StakeholdersOtrosDatosValor), CDate(StakeholdersOtrosDatosFecha), UserId)
Catch
StakeholdersOtrosDatosInsert = 0
End Try
End Function
Public Function StakeholdersOtrosDatosDelete(ByVal StakeholdersOtrosDatosId As Long, ByVal StakeholdersCodigo As String, ByVal UserId As Long) As Integer
Dim AccesoEA As New AccesoEA
Dim strUpdate As String
Dim AccionesABM As New AccionesABM
Dim t As Integer
strUpdate = "Delete "
strUpdate = strUpdate & "FROM (StakeholdersOtrosDatos) "
strUpdate = strUpdate & "WHERE (StakeholdersOtrosDatos.StakeholdersOtrosDatosId = " & StakeholdersOtrosDatosId & ") "
Try
StakeholdersOtrosDatosDelete = AccesoEA.ABMRegistros(strUpdate)
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & StakeholdersCodigo, StakeholdersOtrosDatosId, "StakeholdersOtrosDatos", "")
Catch
StakeholdersOtrosDatosDelete = 0
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & StakeholdersCodigo, StakeholdersOtrosDatosId, "StakeholdersOtrosDatos", "")
End Try
End Function
End Class
