Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class CarpetaJudicialDirecciones
    Public Function LeerCarpetaJudicialDirecciones(ByVal CarpetaJudicialDireccionesId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialDireccionesSecuencia As Long, ByRef CarpetaJudicialTipoDireccionesName As String, ByRef CarpetaJudicialDireccionesDireccion As String, ByRef CarpetaJudicialDireccionesLocalidad As String, ByRef ComunasCodigo As String, ByRef CarpetaJudicialDireccionesTelefono As String, ByRef CarpetaJudicialDireccionesCorreo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialCodigo, CarpetaJudicialDireccionesSecuencia, CarpetaJudicialTipoDireccionesName, CarpetaJudicialDireccionesDireccion, CarpetaJudicialDireccionesLocalidad, ComunasCodigo, CarpetaJudicialDireccionesTelefono, CarpetaJudicialDireccionesCorreo "
        sSQL = sSQL & "FROM CarpetaJudicialDirecciones "
        sSQL = sSQL & "WHERE CarpetaJudicialDirecciones.CarpetaJudicialDireccionesId = " & CarpetaJudicialDireccionesId & " "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CarpetaJudicialCodigo = CStr(dtr("CarpetaJudicialCodigo").ToString)
                If Len(dtr("CarpetaJudicialDireccionesSecuencia").ToString) = 0 Then
                    CarpetaJudicialDireccionesSecuencia = 0
                Else
                    CarpetaJudicialDireccionesSecuencia = CLng(dtr("CarpetaJudicialDireccionesSecuencia").ToString)
                End If
                CarpetaJudicialTipoDireccionesName = CStr(dtr("CarpetaJudicialTipoDireccionesName").ToString)
                CarpetaJudicialDireccionesDireccion = CStr(dtr("CarpetaJudicialDireccionesDireccion").ToString)
                CarpetaJudicialDireccionesLocalidad = CStr(dtr("CarpetaJudicialDireccionesLocalidad").ToString)
                ComunasCodigo = CStr(dtr("ComunasCodigo").ToString)
                CarpetaJudicialDireccionesTelefono = CStr(dtr("CarpetaJudicialDireccionesTelefono").ToString)
                CarpetaJudicialDireccionesCorreo = CStr(dtr("CarpetaJudicialDireccionesCorreo").ToString)
            End While
            LeerCarpetaJudicialDirecciones = True
            dtr.Close()
        Catch
            LeerCarpetaJudicialDirecciones = False
        End Try
    End Function
    Public Function CarpetaJudicialDireccionesUpdate(ByVal CarpetaJudicialDireccionesId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialDireccionesSecuencia As Long, ByRef CarpetaJudicialTipoDireccionesName As String, ByRef CarpetaJudicialDireccionesDireccion As String, ByRef CarpetaJudicialDireccionesLocalidad As String, ByRef ComunasCodigo As String, ByRef CarpetaJudicialDireccionesTelefono As String, ByRef CarpetaJudicialDireccionesCorreo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE CarpetaJudicialDirecciones SET "
        strUpdate = strUpdate & "CarpetaJudicialDirecciones.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialDirecciones.CarpetaJudicialDireccionesSecuencia = " & CarpetaJudicialDireccionesSecuencia & ", "
        strUpdate = strUpdate & "CarpetaJudicialDirecciones.CarpetaJudicialTipoDireccionesName = '" & CarpetaJudicialTipoDireccionesName & "', "
        strUpdate = strUpdate & "CarpetaJudicialDirecciones.CarpetaJudicialDireccionesDireccion = '" & CarpetaJudicialDireccionesDireccion & "', "
        strUpdate = strUpdate & "CarpetaJudicialDirecciones.CarpetaJudicialDireccionesLocalidad = '" & CarpetaJudicialDireccionesLocalidad & "', "
        strUpdate = strUpdate & "CarpetaJudicialDirecciones.ComunasCodigo = '" & ComunasCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialDirecciones.CarpetaJudicialDireccionesTelefono = '" & CarpetaJudicialDireccionesTelefono & "', "
        strUpdate = strUpdate & "CarpetaJudicialDirecciones.CarpetaJudicialDireccionesCorreo = '" & CarpetaJudicialDireccionesCorreo & "', "
        strUpdate = strUpdate & "CarpetaJudicialDirecciones.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicialDirecciones.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicialDirecciones.CarpetaJudicialDireccionesId = " & CarpetaJudicialDireccionesId
        Try
            CarpetaJudicialDireccionesUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & CarpetaJudicialCodigo, CarpetaJudicialDireccionesId, "CarpetaJudicialDirecciones", "")
        Catch
            CarpetaJudicialDireccionesUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & CarpetaJudicialCodigo, CarpetaJudicialDireccionesId, "CarpetaJudicialDirecciones", "")
        End Try
    End Function
    Public Function CarpetaJudicialDireccionesInsert(ByRef CarpetaJudicialDireccionesId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialDireccionesSecuencia As Long, ByRef CarpetaJudicialTipoDireccionesName As String, ByRef CarpetaJudicialDireccionesDireccion As String, ByRef CarpetaJudicialDireccionesLocalidad As String, ByRef ComunasCodigo As String, ByRef CarpetaJudicialDireccionesTelefono As String, ByRef CarpetaJudicialDireccionesCorreo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim CarpetaJudicialDirecciones As New CarpetaJudicialDirecciones
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = CarpetaJudicialCodigo
            DetailSecuencia = CarpetaJudicialDireccionesSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("CarpetaJudicialDireccionesId", "CarpetaJudicialCodigo", "CarpetaJudicialDireccionesSecuencia", "CarpetaJudicialDirecciones", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("CarpetaJudicialDireccionesId", "CarpetaJudicialCodigo", "CarpetaJudicialDireccionesSecuencia", "CarpetaJudicialDirecciones", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            CarpetaJudicialDireccionesInsert = CarpetaJudicialDirecciones.CarpetaJudicialDireccionesUpdate(DetailId, CStr(CarpetaJudicialCodigo), CLng(CarpetaJudicialDireccionesSecuencia), CStr(CarpetaJudicialTipoDireccionesName), CStr(CarpetaJudicialDireccionesDireccion), CStr(CarpetaJudicialDireccionesLocalidad), CStr(ComunasCodigo), CStr(CarpetaJudicialDireccionesTelefono), CStr(CarpetaJudicialDireccionesCorreo), UserId)
        Catch
            CarpetaJudicialDireccionesInsert = 0
        End Try
    End Function
    Public Function CarpetaJudicialDireccionesDelete(ByVal CarpetaJudicialDireccionesId As Long, ByVal CarpetaJudicialCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM CarpetaJudicialDirecciones "
        strUpdate = strUpdate & "WHERE CarpetaJudicialDirecciones.CarpetaJudicialDireccionesId = " & CarpetaJudicialDireccionesId & " "
        Try
            CarpetaJudicialDireccionesDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Dirección asociada al Stakeholder: " & CarpetaJudicialCodigo, CarpetaJudicialDireccionesId, "CarpetaJudicialDirecciones", "")
        Catch
            CarpetaJudicialDireccionesDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar Dirección asociada al Stakeholder: " & CarpetaJudicialCodigo, CarpetaJudicialDireccionesId, "CarpetaJudicialDirecciones", "")
        End Try
    End Function
    Public Function LoadDireccionesPorCarpetaJudicial(ByRef rptDirecciones As Repeater, ByVal CarpetaJudicialId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT CarpetaJudicialDirecciones.CarpetaJudicialDireccionesDireccion AS Direccion, Comunas.ComunasName AS Comuna, CarpetaJudicialDirecciones.CarpetaJudicialDireccionesTelefono AS Telefonos, CarpetaJudicialDirecciones.CarpetaJudicialDireccionesCorreo AS Correo "
        sSQL = sSQL & "FROM (((CarpetaJudicial INNER JOIN CarpetaJudicialDirecciones ON CarpetaJudicial.CarpetaJudicialCodigo = CarpetaJudicialDirecciones.CarpetaJudicialCodigo) INNER JOIN Comunas ON CarpetaJudicialDirecciones.ComunasCodigo = Comunas.ComunasCodigo) INNER JOIN Provincias ON Comunas.ProvinciasCodigo = Provincias.ProvinciasCodigo) INNER JOIN Regiones ON Provincias.RegionesCodigo = Regiones.RegionesCodigo "
        sSQL = sSQL & "WHERE CarpetaJudicial.CarpetaJudicialId=" & CarpetaJudicialId & " "

        Try
            dtrRutasPorViajes = AccesoEA.ListarRegistros(sSQL)

            rptDirecciones.DataSource = dtrRutasPorViajes
            rptDirecciones.DataBind()
            LoadDireccionesPorCarpetaJudicial = True
            dtrRutasPorViajes.Close()
        Catch
            LoadDireccionesPorCarpetaJudicial = False
        End Try
    End Function
    Public Function LoadPrimeraDireccionPorStakeholder(ByRef lblDireccion As Label, ByRef lblComuna As Label, ByRef lblTelefono As Label, ByRef lblCorreo As Label, ByVal CarpetaJudicialId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT CarpetaJudicialDirecciones.CarpetaJudicialDireccionesDireccion AS Direccion, Comunas.ComunasName AS Comuna, CarpetaJudicialDirecciones.CarpetaJudicialDireccionesTelefono AS Telefonos, CarpetaJudicialDirecciones.CarpetaJudicialDireccionesCorreo AS Correo "
        sSQL = sSQL & "FROM (((CarpetaJudicial INNER JOIN CarpetaJudicialDirecciones ON CarpetaJudicial.CarpetaJudicialCodigo = CarpetaJudicialDirecciones.CarpetaJudicialCodigo) INNER JOIN Comunas ON CarpetaJudicialDirecciones.ComunasCodigo = Comunas.ComunasCodigo) INNER JOIN Provincias ON Comunas.ProvinciasCodigo = Provincias.ProvinciasCodigo) INNER JOIN Regiones ON Provincias.RegionesCodigo = Regiones.RegionesCodigo "
        sSQL = sSQL & "WHERE CarpetaJudicial.CarpetaJudicialId=" & CarpetaJudicialId & " "
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
    Public Function LeerPrimeraDireccionPorStakeholder(ByRef Direccion As String, ByRef Comuna As String, ByRef Telefono As String, ByRef Correo As String, ByVal CarpetaJudicialId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT TOP 1 CarpetaJudicialDirecciones.CarpetaJudicialDireccionesDireccion AS Direccion, Comunas.ComunasName AS Comuna, CarpetaJudicialDirecciones.CarpetaJudicialDireccionesTelefono AS Telefonos, CarpetaJudicialDirecciones.CarpetaJudicialDireccionesCorreo AS Correo "
        sSQL = sSQL & "FROM (((CarpetaJudicial INNER JOIN CarpetaJudicialDirecciones ON CarpetaJudicial.CarpetaJudicialCodigo = CarpetaJudicialDirecciones.CarpetaJudicialCodigo) INNER JOIN Comunas ON CarpetaJudicialDirecciones.ComunasCodigo = Comunas.ComunasCodigo) INNER JOIN Provincias ON Comunas.ProvinciasCodigo = Provincias.ProvinciasCodigo) INNER JOIN Regiones ON Provincias.RegionesCodigo = Regiones.RegionesCodigo "
        sSQL = sSQL & "WHERE CarpetaJudicial.CarpetaJudicialId=" & CarpetaJudicialId & " "
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
    Public Function ListarDirecciones(ByVal CarpetaJudicialCodigo As String, Optional ByVal Clase As String = "invisible", Optional ByVal Formato As String = "CodigoHTML") As String
        Dim CodigoHTML As String = ""
        Dim CarpetaJudicialDirecciones As New CarpetaJudicialDirecciones
        Dim Direcciones(15) As String
        Dim NumeroDirecciones As Integer = CarpetaJudicialDirecciones.LeerDatosDirecciones(CarpetaJudicialCodigo, Direcciones)
        Dim i As Integer
        ListarDirecciones = ""

        If NumeroDirecciones > 0 Then

            If Formato = "CodigoHTML" Then
                CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td><h1>" & "Direcciones alternativas del deudor" & "</h1></td>"
                CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & "Direcciones" & "')"" /></td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "</table>"
                CodigoHTML = CodigoHTML & "<div id=""subgrilla" & "Direcciones" & """ class=""" & Clase & """>"
                CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
            Else
                CodigoHTML = CodigoHTML & "<table width=""660"" border=""1"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Verdana;font-size:8pt;border:1px solid #FFFFFF;"">"
            End If

            For i = 0 To NumeroDirecciones
                CodigoHTML = CodigoHTML & Direcciones(i)
            Next
            CodigoHTML = CodigoHTML & "</table>"
            If Formato = "CodigoHTML" Then
                CodigoHTML = CodigoHTML & "</div>"
            End If
        End If

        ListarDirecciones = CodigoHTML
    End Function
    Public Function LeerDatosDirecciones(ByVal CarpetaJudicialCodigo As String, ByRef Direcciones() As String) As Integer

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0

        sSQL = "Select CarpetaJudicialDireccionesSecuencia, CarpetaJudicialTipoDireccionesName As Tipo, CarpetaJudicialDireccionesDireccion As Direccion, CarpetaJudicialDireccionesLocalidad As Ciudad, ComunasName As Comuna, CarpetaJudicialDireccionesTelefono As Telefono, CarpetaJudicialDireccionesCorreo As Correo "
        sSQL = sSQL & "FROM CarpetaJudicialDirecciones, Comunas "
        sSQL = sSQL & "WHERE CarpetaJudicialDirecciones.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' AND Comunas.ComunasCodigo =  CarpetaJudicialDirecciones.ComunasCodigo "
        sSQL = sSQL & "ORDER BY CarpetaJudicialDirecciones.CarpetaJudicialDireccionesSecuencia"

        Dim CodigoHTML As String = ""

        LeerDatosDirecciones = 0

        Direcciones(0) = "<tr><th align=""left"">Tipo</th><th align=""left"">Dirección</th><th align=""left"">Ciudad</th><th align=""left"">Comuna</th><th align=""left"">Teléfono</th><th align=""left"">Correo</th></tr>"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                Direcciones(i) = "<tr><td>" & dtr("Tipo").ToString & "</td><td>" & dtr("Direccion").ToString & "</td><td>" & dtr("Ciudad").ToString & "</td><td>" & dtr("Comuna").ToString & "</td><td>" & dtr("Telefono").ToString & "</td><td>" & dtr("Correo").ToString & "</td></tr>"
            End While
            dtr.Close()
        Catch
            LeerDatosDirecciones = 0
        End Try

        LeerDatosDirecciones = i

    End Function
End Class
