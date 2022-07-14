'------------------------------------------------------------
' Código generado por ZRISMART SF el 29-08-2011 14:32:12
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class StakeholdersContactos
    Public Function LeerStakeholdersContactos(ByVal StakeholdersContactosId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersContactosSecuencia As Long, ByRef StakeholdersContactosNombres As String, ByRef StakeholdersContactosApellidos As String, ByRef StakeholdersCargosContactosName As String, ByRef StakeholdersNivelContactosName As String, ByRef StakeholdersContactosTelefono As String, ByRef StakeholdersContactosCorreo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersCodigo, StakeholdersContactosSecuencia, StakeholdersContactosNombres, StakeholdersContactosApellidos, StakeholdersCargosContactosName, StakeholdersNivelContactosName, StakeholdersContactosTelefono, StakeholdersContactosCorreo "
        sSQL = sSQL & "FROM (StakeholdersContactos) "
        sSQL = sSQL & "WHERE (StakeholdersContactos.StakeholdersContactosId = " & StakeholdersContactosId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                StakeholdersCodigo = CStr(dtr("StakeholdersCodigo").ToString)
                If Len(dtr("StakeholdersContactosSecuencia").ToString) = 0 Then
                    StakeholdersContactosSecuencia = 0
                Else
                    StakeholdersContactosSecuencia = CLng(dtr("StakeholdersContactosSecuencia").ToString)
                End If
                StakeholdersContactosNombres = CStr(dtr("StakeholdersContactosNombres").ToString)
                StakeholdersContactosApellidos = CStr(dtr("StakeholdersContactosApellidos").ToString)
                StakeholdersCargosContactosName = CStr(dtr("StakeholdersCargosContactosName").ToString)
                StakeholdersNivelContactosName = CStr(dtr("StakeholdersNivelContactosName").ToString)
                StakeholdersContactosTelefono = CStr(dtr("StakeholdersContactosTelefono").ToString)
                StakeholdersContactosCorreo = CStr(dtr("StakeholdersContactosCorreo").ToString)
            End While
            LeerStakeholdersContactos = True
            dtr.Close()
        Catch
            LeerStakeholdersContactos = False
        End Try
    End Function
    Public Function StakeholdersContactosUpdate(ByVal StakeholdersContactosId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersContactosSecuencia As Long, ByRef StakeholdersContactosNombres As String, ByRef StakeholdersContactosApellidos As String, ByRef StakeholdersCargosContactosName As String, ByRef StakeholdersNivelContactosName As String, ByRef StakeholdersContactosTelefono As String, ByRef StakeholdersContactosCorreo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE StakeholdersContactos SET "
        strUpdate = strUpdate & "StakeholdersContactos.StakeholdersCodigo = '" & StakeholdersCodigo & "', "
        strUpdate = strUpdate & "StakeholdersContactos.StakeholdersContactosSecuencia = " & StakeholdersContactosSecuencia & ", "
        strUpdate = strUpdate & "StakeholdersContactos.StakeholdersContactosNombres = '" & StakeholdersContactosNombres & "', "
        strUpdate = strUpdate & "StakeholdersContactos.StakeholdersContactosApellidos = '" & StakeholdersContactosApellidos & "', "
        strUpdate = strUpdate & "StakeholdersContactos.StakeholdersCargosContactosName = '" & StakeholdersCargosContactosName & "', "
        strUpdate = strUpdate & "StakeholdersContactos.StakeholdersNivelContactosName = '" & StakeholdersNivelContactosName & "', "
        strUpdate = strUpdate & "StakeholdersContactos.StakeholdersContactosTelefono = '" & StakeholdersContactosTelefono & "', "
        strUpdate = strUpdate & "StakeholdersContactos.StakeholdersContactosCorreo = '" & StakeholdersContactosCorreo & "', "
        strUpdate = strUpdate & "StakeholdersContactos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "StakeholdersContactos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE StakeholdersContactos.StakeholdersContactosId = " & StakeholdersContactosId
        Try
            StakeholdersContactosUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & StakeholdersCodigo, StakeholdersContactosId, "StakeholdersContactos", "")
        Catch
            StakeholdersContactosUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & StakeholdersCodigo, StakeholdersContactosId, "StakeholdersContactos", "")
        End Try
    End Function
    Public Function StakeholdersContactosInsert(ByRef StakeholdersContactosId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersContactosSecuencia As Long, ByRef StakeholdersContactosNombres As String, ByRef StakeholdersContactosApellidos As String, ByRef StakeholdersCargosContactosName As String, ByRef StakeholdersNivelContactosName As String, ByRef StakeholdersContactosTelefono As String, ByRef StakeholdersContactosCorreo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim StakeholdersContactos As New StakeholdersContactos
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = StakeholdersCodigo
            DetailSecuencia = StakeholdersContactosSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("StakeholdersContactosId", "StakeholdersCodigo", "StakeholdersContactosSecuencia", "StakeholdersContactos", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("StakeholdersContactosId", "StakeholdersCodigo", "StakeholdersContactosSecuencia", "StakeholdersContactos", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            StakeholdersContactosInsert = StakeholdersContactos.StakeholdersContactosUpdate(DetailId, CStr(StakeholdersCodigo), CLng(StakeholdersContactosSecuencia), CStr(StakeholdersContactosNombres), CStr(StakeholdersContactosApellidos), CStr(StakeholdersCargosContactosName), CStr(StakeholdersNivelContactosName), CStr(StakeholdersContactosTelefono), CStr(StakeholdersContactosCorreo), UserId)
        Catch
            StakeholdersContactosInsert = 0
        End Try
    End Function
    Public Function StakeholdersContactosDelete(ByVal StakeholdersContactosId As Long, ByVal StakeholdersCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (StakeholdersContactos) "
        strUpdate = strUpdate & "WHERE (StakeholdersContactos.StakeholdersContactosId = " & StakeholdersContactosId & ") "
        Try
            StakeholdersContactosDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & StakeholdersCodigo, StakeholdersContactosId, "StakeholdersContactos", "")
        Catch
            StakeholdersContactosDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & StakeholdersCodigo, StakeholdersContactosId, "StakeholdersContactos", "")
        End Try
    End Function
    Public Function LoadContactosPorStakeholders(ByRef rptContactos As Repeater, ByVal StakeholdersId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT StakeholdersContactos.StakeholdersContactosNombres As Nombres, StakeholdersContactos.StakeholdersContactosApellidos As Apellidos, StakeholdersContactos.StakeholdersCargosContactosName As Cargo, StakeholdersContactos.StakeholdersContactosTelefono As Telefonos, StakeholdersContactos.StakeholdersContactosCorreo As Correo "
        sSQL = sSQL & "FROM Stakeholders INNER JOIN StakeholdersContactos ON Stakeholders.StakeholdersCodigo = StakeholdersContactos.StakeholdersCodigo "
        sSQL = sSQL & "WHERE (((Stakeholders.StakeholdersId)=" & StakeholdersId & "))"

        Try
            dtrRutasPorViajes = AccesoEA.ListarRegistros(sSQL)

            rptContactos.DataSource = dtrRutasPorViajes
            rptContactos.DataBind()
            LoadContactosPorStakeholders = True
            dtrRutasPorViajes.Close()
        Catch
            LoadContactosPorStakeholders = False
        End Try
    End Function
End Class
