Imports AjaxControlToolkit
Partial Class FichaAcciones
    Inherits System.Web.UI.Page
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 24-04-2011 8:52:50
    '------------------------------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim AccionesId As Long = 0
    Dim AccionesCodigo As String = ""
    Dim AccionesName As String = ""
    Dim AccionesDescription As String = ""
    Dim AccionesSecuencia As Long = 0
    Dim TipoProcesoSecuencia As Long = 0
    Dim EtapasSecuencia As Long = 0
    Dim EtapasName As String = ""
    Dim EtapasId As Long = 0
    Dim RolName As String = ""
    Dim PaginaWebName As String = ""
    Dim AccionesDuration As Long = 1
    Dim AccionesEnviaCorreo As Boolean = False
    Dim AccionesAdvertirFechaFatal As Boolean = False
    Dim AccionesIsFlujoAlternativo As Boolean = False
    '----------------------------------------
    ' Declaración de Controles del Formulario 
    '----------------------------------------
    Dim txtAccionesId As HiddenField
    Dim txtAccionesCodigo As HiddenField
    Dim txtAccionesName As TextBox
    Dim txtAccionesDescription As TextBox
    Dim txtAccionesSecuencia As TextBox
    Dim txtTipoProcesoSecuencia As HiddenField
    Dim txtEtapasSecuencia As HiddenField
    Dim txtEtapasName As HiddenField
    Dim txtEtapasId As HiddenField
    Dim txtRolName As TextBox
    Dim txtPaginaWebName As TextBox
    Dim txtAccionesDuration As TextBox
    Dim chkAccionesEnviaCorreo As CheckBox
    Dim chkAccionesAdvertirFechaFatal As CheckBox
    Dim chkAccionesIsFlujoAlternativo As CheckBox

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim PaginaWeb As New PaginaWeb
        Dim TipoProceso As New TipoProceso
        Dim Etapas As New Etapas
        Dim Acciones As New Acciones
        Dim t As Boolean = True
        Dim s As Integer = 0

        Dim VistaWeb As String = Request.QueryString("PaginaWebName")
        EtapasId = CLng(Request.QueryString("EtapasId"))
        TipoProcesoSecuencia = CLng(Request.QueryString("TipoProcesoId"))
        Dim EtapasName As String = Etapas.LeerEtapasNameById(EtapasId)
        Dim EtapasSecuencia As String = Etapas.LeerEtapasSecuenciaByName(EtapasName)
        Dim AccionesId As Long = CLng(Request.QueryString("AccionesId"))
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim PaginaWebName As String = ""
        Dim PaginaWebTitle As String = PaginaWeb.LeerPaginaWebTitle(VistaWeb)

        Dim PaginaWebUserControl As String = ""
        Dim MisEtapas As String = ""


        If AccionesId = 0 Then 'Crearemos un nuevo registro
            Dim AccionesCodigo As String = ""
            Dim AccionesName As String = ""
            Dim AccionesDescription As String = ""
            Dim AccionesSecuencia As Long = Acciones.CalcularNextAccionesSecuencia(EtapasId)
            Dim RolName As String = ""
            Dim AccionesDuration As Long = 1
            Dim AccionesEnviaCorreo As Boolean = False
            Dim AccionesAdvertirFechaFatal As Boolean = False
            Dim AccionesIsFlujoAlternativo As Boolean = False

            If TipoProcesoSecuencia < 10 Then
                AccionesCodigo = AccionesCodigo & "0" & TipoProcesoSecuencia & "."
            Else
                AccionesCodigo = AccionesCodigo & TipoProcesoSecuencia & "."
            End If
            If EtapasSecuencia < 10 Then
                AccionesCodigo = AccionesCodigo & "0" & EtapasSecuencia & "."
            Else
                AccionesCodigo = AccionesCodigo & EtapasSecuencia & "."
            End If
            If AccionesSecuencia < 10 Then
                AccionesCodigo = AccionesCodigo & "0" & AccionesSecuencia
            Else
                AccionesCodigo = AccionesCodigo & AccionesSecuencia
            End If

            AccionesId = Acciones.AccionesInsert(AccionesId, AccionesCodigo, AccionesName, AccionesDescription, AccionesSecuencia, TipoProcesoSecuencia, EtapasSecuencia, EtapasName, EtapasId, RolName, "Sin Ficha", AccionesDuration, AccionesEnviaCorreo, AccionesAdvertirFechaFatal, AccionesIsFlujoAlternativo, Session("PersonaId"))
        End If

        'MyDeudor.Controls.Add(New LiteralControl("<p><h1>" & PaginaWebTitle & " " & EtapasName & "</h1></p>"))
        'MyResponsable.Controls.Add(New LiteralControl(Acciones.ListarAccionesPorEtapas(EtapasId)))

        'Aquí se pinta el formulario variable dependiendo de la acción a ejecutar dentro de la tarea.
        'A partir del Id de la tarea, se obtiene la acción y de allí la página web a leer

        t = Lecturas.LeerPaginaWeb(VistaWeb, TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        TituloPagina = TituloPagina & " " & EtapasName
        If NumeroPagina <> 0 Then
            Call Lecturas.CrearNewVista(NumeroPagina, TituloPagina, MyTask, Session("PersonaId"), True, 680, False, 19)
        End If

        Session("NumeroPagina") = NumeroPagina

        If Not IsPostBack Then
            t = Acciones.LeerAcciones(AccionesId, AccionesCodigo, AccionesName, AccionesDescription, AccionesSecuencia, TipoProcesoSecuencia, EtapasSecuencia, EtapasName, EtapasId, RolName, PaginaWebName, AccionesDuration, AccionesEnviaCorreo, AccionesAdvertirFechaFatal, AccionesIsFlujoAlternativo)
            txtAccionesId = FindControl("txtAccionesId")
            'txtAccionesId.Text = AccionesId
            txtAccionesId.Value = AccionesId
            txtAccionesCodigo = FindControl("txtAccionesCodigo")
            'txtAccionesCodigo.Text = AccionesCodigo
            txtAccionesCodigo.Value = AccionesCodigo
            txtAccionesName = FindControl("txtAccionesName")
            txtAccionesName.Text = AccionesName
            If Len(AccionesName) > 0 Then
                txtAccionesName.Enabled = False
            Else
                txtAccionesName.Enabled = True
            End If
            txtAccionesDescription = FindControl("txtAccionesDescription")
            txtAccionesDescription.Text = AccionesDescription
            txtAccionesSecuencia = FindControl("txtAccionesSecuencia")
            txtAccionesSecuencia.Text = AccionesSecuencia
            txtTipoProcesoSecuencia = FindControl("txtTipoProcesoSecuencia")
            'txtTipoProcesoSecuencia.Text = TipoProcesoSecuencia
            txtTipoProcesoSecuencia.Value = TipoProcesoSecuencia
            txtEtapasSecuencia = FindControl("txtEtapasSecuencia")
            'txtEtapasSecuencia.Text = EtapasSecuencia
            txtEtapasSecuencia.Value = EtapasSecuencia
            txtEtapasName = FindControl("txtEtapasName")
            'txtEtapasName.Text = EtapasName
            txtEtapasName.Value = EtapasName
            txtEtapasId = FindControl("txtEtapasId")
            'txtEtapasId.Text = EtapasId
            txtEtapasId.Value = EtapasId
            txtRolName = FindControl("txtRolName")
            txtRolName.Text = RolName
            txtPaginaWebName = FindControl("txtPaginaWebName")
            txtPaginaWebName.Text = PaginaWebName
            txtAccionesDuration = FindControl("txtAccionesDuration")
            txtAccionesDuration.Text = AccionesDuration
            chkAccionesEnviaCorreo = FindControl("chkAccionesEnviaCorreo")
            chkAccionesEnviaCorreo.Checked = CBool(AccionesEnviaCorreo)
            chkAccionesAdvertirFechaFatal = FindControl("chkAccionesAdvertirFechaFatal")
            chkAccionesAdvertirFechaFatal.Checked = CBool(AccionesAdvertirFechaFatal)
            chkAccionesIsFlujoAlternativo = FindControl("chkAccionesISFlujoAlternativo")
            chkAccionesIsFlujoAlternativo.Checked = CBool(AccionesIsFlujoAlternativo)
        Else
            txtAccionesId = FindControl("txtAccionesId")
            txtAccionesCodigo = FindControl("txtAccionesCodigo")
            txtAccionesName = FindControl("txtAccionesName")
            txtAccionesDescription = FindControl("txtAccionesDescription")
            txtAccionesSecuencia = FindControl("txtAccionesSecuencia")
            txtTipoProcesoSecuencia = FindControl("txtTipoProcesoSecuencia")
            txtEtapasSecuencia = FindControl("txtEtapasSecuencia")
            txtEtapasName = FindControl("txtEtapasName")
            txtEtapasId = FindControl("txtEtapasId")
            txtRolName = FindControl("txtRolName")
            txtPaginaWebName = FindControl("txtPaginaWebName")
            txtAccionesDuration = FindControl("txtAccionesDuration")
            chkAccionesEnviaCorreo = FindControl("chkAccionesEnviaCorreo")
            chkAccionesAdvertirFechaFatal = FindControl("AccionesAdvertirFechaFatal")
            chkAccionesIsFlujoAlternativo = FindControl("AccionesISFlujoAlternativo")
        End If

    End Sub

End Class
