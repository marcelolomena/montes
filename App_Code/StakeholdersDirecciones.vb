'------------------------------------------------------------
' Código generado por ZRISMART SF el 29-08-2011 14:30:53
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class StakeholdersDirecciones
    Public Function LeerStakeholdersDirecciones(ByVal StakeholdersDireccionesId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersDireccionesSecuencia As Long, ByRef StakeholdersTipoDireccionesName As String, ByRef StakeholdersDireccionesDireccion As String, ByRef StakeholdersDireccionesLocalidad As String, ByRef ComunasCodigo As String, ByRef StakeholdersDireccionesTelefono As String, ByRef StakeholdersDireccionesCorreo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersCodigo, StakeholdersDireccionesSecuencia, StakeholdersTipoDireccionesName, StakeholdersDireccionesDireccion, StakeholdersDireccionesLocalidad, ComunasCodigo, StakeholdersDireccionesTelefono, StakeholdersDireccionesCorreo "
        sSQL = sSQL & "FROM StakeholdersDirecciones "
        sSQL = sSQL & "WHERE StakeholdersDirecciones.StakeholdersDireccionesId = " & StakeholdersDireccionesId & " "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                StakeholdersCodigo = CStr(dtr("StakeholdersCodigo").ToString)
                If Len(dtr("StakeholdersDireccionesSecuencia").ToString) = 0 Then
                    StakeholdersDireccionesSecuencia = 0
                Else
                    StakeholdersDireccionesSecuencia = CLng(dtr("StakeholdersDireccionesSecuencia").ToString)
                End If
                StakeholdersTipoDireccionesName = CStr(dtr("StakeholdersTipoDireccionesName").ToString)
                StakeholdersDireccionesDireccion = CStr(dtr("StakeholdersDireccionesDireccion").ToString)
                StakeholdersDireccionesLocalidad = CStr(dtr("StakeholdersDireccionesLocalidad").ToString)
                ComunasCodigo = CStr(dtr("ComunasCodigo").ToString)
                StakeholdersDireccionesTelefono = CStr(dtr("StakeholdersDireccionesTelefono").ToString)
                StakeholdersDireccionesCorreo = CStr(dtr("StakeholdersDireccionesCorreo").ToString)
            End While
            LeerStakeholdersDirecciones = True
            dtr.Close()
        Catch
            LeerStakeholdersDirecciones = False
        End Try
    End Function
    Public Function StakeholdersDireccionesUpdate(ByVal StakeholdersDireccionesId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersDireccionesSecuencia As Long, ByRef StakeholdersTipoDireccionesName As String, ByRef StakeholdersDireccionesDireccion As String, ByRef StakeholdersDireccionesLocalidad As String, ByRef ComunasCodigo As String, ByRef StakeholdersDireccionesTelefono As String, ByRef StakeholdersDireccionesCorreo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE StakeholdersDirecciones SET "
        strUpdate = strUpdate & "StakeholdersDirecciones.StakeholdersCodigo = '" & StakeholdersCodigo & "', "
        strUpdate = strUpdate & "StakeholdersDirecciones.StakeholdersDireccionesSecuencia = " & StakeholdersDireccionesSecuencia & ", "
        strUpdate = strUpdate & "StakeholdersDirecciones.StakeholdersTipoDireccionesName = '" & StakeholdersTipoDireccionesName & "', "
        strUpdate = strUpdate & "StakeholdersDirecciones.StakeholdersDireccionesDireccion = '" & StakeholdersDireccionesDireccion & "', "
        strUpdate = strUpdate & "StakeholdersDirecciones.StakeholdersDireccionesLocalidad = '" & StakeholdersDireccionesLocalidad & "', "
        strUpdate = strUpdate & "StakeholdersDirecciones.ComunasCodigo = '" & ComunasCodigo & "', "
        strUpdate = strUpdate & "StakeholdersDirecciones.StakeholdersDireccionesTelefono = '" & StakeholdersDireccionesTelefono & "', "
        strUpdate = strUpdate & "StakeholdersDirecciones.StakeholdersDireccionesCorreo = '" & StakeholdersDireccionesCorreo & "', "
        strUpdate = strUpdate & "StakeholdersDirecciones.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "StakeholdersDirecciones.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE StakeholdersDirecciones.StakeholdersDireccionesId = " & StakeholdersDireccionesId
        Try
            StakeholdersDireccionesUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & StakeholdersCodigo, StakeholdersDireccionesId, "StakeholdersDirecciones", "")
        Catch
            StakeholdersDireccionesUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & StakeholdersCodigo, StakeholdersDireccionesId, "StakeholdersDirecciones", "")
        End Try
    End Function
    Public Function StakeholdersDireccionesInsert(ByRef StakeholdersDireccionesId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersDireccionesSecuencia As Long, ByRef StakeholdersTipoDireccionesName As String, ByRef StakeholdersDireccionesDireccion As String, ByRef StakeholdersDireccionesLocalidad As String, ByRef ComunasCodigo As String, ByRef StakeholdersDireccionesTelefono As String, ByRef StakeholdersDireccionesCorreo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim StakeholdersDirecciones As New StakeholdersDirecciones
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = StakeholdersCodigo
            DetailSecuencia = StakeholdersDireccionesSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("StakeholdersDireccionesId", "StakeholdersCodigo", "StakeholdersDireccionesSecuencia", "StakeholdersDirecciones", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("StakeholdersDireccionesId", "StakeholdersCodigo", "StakeholdersDireccionesSecuencia", "StakeholdersDirecciones", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            StakeholdersDireccionesInsert = StakeholdersDirecciones.StakeholdersDireccionesUpdate(DetailId, CStr(StakeholdersCodigo), CLng(StakeholdersDireccionesSecuencia), CStr(StakeholdersTipoDireccionesName), CStr(StakeholdersDireccionesDireccion), CStr(StakeholdersDireccionesLocalidad), CStr(ComunasCodigo), CStr(StakeholdersDireccionesTelefono), CStr(StakeholdersDireccionesCorreo), UserId)
        Catch
            StakeholdersDireccionesInsert = 0
        End Try
    End Function
    Public Function StakeholdersDireccionesDelete(ByVal StakeholdersDireccionesId As Long, ByVal StakeholdersCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM StakeholdersDirecciones "
        strUpdate = strUpdate & "WHERE StakeholdersDirecciones.StakeholdersDireccionesId = " & StakeholdersDireccionesId & " "
        Try
            StakeholdersDireccionesDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Dirección asociada al Stakeholder: " & StakeholdersCodigo, StakeholdersDireccionesId, "StakeholdersDirecciones", "")
        Catch
            StakeholdersDireccionesDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar Dirección asociada al Stakeholder: " & StakeholdersCodigo, StakeholdersDireccionesId, "StakeholdersDirecciones", "")
        End Try
    End Function
    Public Function LoadDireccionesPorStakeholders(ByRef rptDirecciones As Repeater, ByVal StakeholdersId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT StakeholdersDirecciones.StakeholdersDireccionesDireccion AS Direccion, Comunas.ComunasName AS Comuna, StakeholdersDirecciones.StakeholdersDireccionesTelefono AS Telefonos, StakeholdersDirecciones.StakeholdersDireccionesCorreo AS Correo "
        sSQL = sSQL & "FROM (((Stakeholders INNER JOIN StakeholdersDirecciones ON Stakeholders.StakeholdersCodigo = StakeholdersDirecciones.StakeholdersCodigo) INNER JOIN Comunas ON StakeholdersDirecciones.ComunasCodigo = Comunas.ComunasCodigo) INNER JOIN Provincias ON Comunas.ProvinciasCodigo = Provincias.ProvinciasCodigo) INNER JOIN Regiones ON Provincias.RegionesCodigo = Regiones.RegionesCodigo "
        sSQL = sSQL & "WHERE Stakeholders.StakeholdersId=" & StakeholdersId & " "

        Try
            dtrRutasPorViajes = AccesoEA.ListarRegistros(sSQL)

            rptDirecciones.DataSource = dtrRutasPorViajes
            rptDirecciones.DataBind()
            LoadDireccionesPorStakeholders = True
            dtrRutasPorViajes.Close()
        Catch
            LoadDireccionesPorStakeholders = False
        End Try
    End Function
    Public Function LoadPrimeraDireccionPorStakeholder(ByRef lblDireccion As Label, ByRef lblComuna As Label, ByRef lblTelefono As Label, ByRef lblCorreo As Label, ByVal StakeholdersId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT StakeholdersDirecciones.StakeholdersDireccionesDireccion AS Direccion, Comunas.ComunasName AS Comuna, StakeholdersDirecciones.StakeholdersDireccionesTelefono AS Telefonos, StakeholdersDirecciones.StakeholdersDireccionesCorreo AS Correo "
        sSQL = sSQL & "FROM (((Stakeholders INNER JOIN StakeholdersDirecciones ON Stakeholders.StakeholdersCodigo = StakeholdersDirecciones.StakeholdersCodigo) INNER JOIN Comunas ON StakeholdersDirecciones.ComunasCodigo = Comunas.ComunasCodigo) INNER JOIN Provincias ON Comunas.ProvinciasCodigo = Provincias.ProvinciasCodigo) INNER JOIN Regiones ON Provincias.RegionesCodigo = Regiones.RegionesCodigo "
        sSQL = sSQL & "WHERE Stakeholders.StakeholdersId=" & StakeholdersId & " "
        lblComuna.Text = ""
        lblCorreo.Text = ""
        lblDireccion.Text = ""
        lblTelefono.Text = ""

        Try
            dtrRutasPorViajes = AccesoEA.ListarRegistros(sSQL)

            While dtrRutasPorViajes.Read
                lblDireccion.Text = CStr(dtrRutasPorViajes("Direccion").ToString)
                lblComuna.Text = CStr(dtrRutasPorViajes("Comuna").ToString)
                lblTelefono.Text = CStr(dtrRutasPorViajes("Telefonos").ToString)
                lblCorreo.Text = CStr(dtrRutasPorViajes("Correo").ToString)
            End While
            LoadPrimeraDireccionPorStakeholder = True
            dtrRutasPorViajes.Close()
        Catch
            LoadPrimeraDireccionPorStakeholder = False
        End Try
    End Function
    Public Function LeerPrimeraDireccionPorStakeholder(ByRef Direccion As String, ByRef Comuna As String, ByRef Telefono As String, ByRef Correo As String, ByVal StakeholdersId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT TOP 1 StakeholdersDirecciones.StakeholdersDireccionesDireccion AS Direccion, Comunas.ComunasName AS Comuna, StakeholdersDirecciones.StakeholdersDireccionesTelefono AS Telefonos, StakeholdersDirecciones.StakeholdersDireccionesCorreo AS Correo "
        sSQL = sSQL & "FROM (((Stakeholders INNER JOIN StakeholdersDirecciones ON Stakeholders.StakeholdersCodigo = StakeholdersDirecciones.StakeholdersCodigo) INNER JOIN Comunas ON StakeholdersDirecciones.ComunasCodigo = Comunas.ComunasCodigo) INNER JOIN Provincias ON Comunas.ProvinciasCodigo = Provincias.ProvinciasCodigo) INNER JOIN Regiones ON Provincias.RegionesCodigo = Regiones.RegionesCodigo "
        sSQL = sSQL & "WHERE Stakeholders.StakeholdersId=" & StakeholdersId & " "
        Comuna = ""
        Correo = ""
        Direccion = ""
        Telefono = ""

        Try
            dtrRutasPorViajes = AccesoEA.ListarRegistros(sSQL)

            While dtrRutasPorViajes.Read
                Direccion = CStr(dtrRutasPorViajes("Direccion").ToString)
                Comuna = CStr(dtrRutasPorViajes("Comuna").ToString)
                Telefono = CStr(dtrRutasPorViajes("Telefonos").ToString)
                Correo = CStr(dtrRutasPorViajes("Correo").ToString)
            End While
            LeerPrimeraDireccionPorStakeholder = True
            dtrRutasPorViajes.Close()
        Catch
            LeerPrimeraDireccionPorStakeholder = False
        End Try
    End Function
End Class
