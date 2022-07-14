Imports AjaxControlToolkit
Partial Class FichaTipoProceso
    Inherits System.Web.UI.Page
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 24-04-2011 8:52:50
    '------------------------------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim TipoProcesoId As Long
    Dim TipoProcesoName As String
    Dim TipoProcesoDescription As String
    Dim TipoProcesoSecuencia As Long
    Dim ClaseProcesoName As String
    Dim ClaseProcesoNameDescription As String
    Dim AccionesCodigo As String
    Dim AccionesCodigoDescription As String
    '----------------------------------------
    ' Declaración de Controles del Formulario 2
    '----------------------------------------
    Dim txtTipoProcesoId As TextBox
    Dim txtTipoProcesoName As TextBox
    Dim txtTipoProcesoDescription As TextBox
    Dim txtTipoProcesoSecuencia As TextBox
    Dim txtClaseProcesoName As TextBox
    Dim txtClaseProcesoNameDescription As TextBox
    Dim txtAccionesCodigo As TextBox
    Dim txtAccionesCodigoDescription As TextBox
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim PaginaWeb As New PaginaWeb
        Dim t As Boolean = True
        Dim s As Integer = 0

        Dim VistaWeb As String = Request.QueryString("PaginaWebName")
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim PaginaWebName As String = ""
        Dim PaginaWebTitle As String = PaginaWeb.LeerPaginaWebTitle(VistaWeb)

        Dim TipoProceso As New TipoProceso
        Dim PaginaWebUserControl As String = ""
        Dim MisEtapas As String = ""

        TipoProcesoId = CLng(Request.QueryString("Id"))
        If TipoProcesoId = 0 Then 'Crearemos un nuevo registro
            TipoProcesoId = TipoProceso.TipoProcesoInsert(TipoProcesoId, TipoProcesoName, TipoProcesoDescription, TipoProceso.CalcularNextTipoProcesoSecuencia, ClaseProcesoName, AccionesCodigo, Session("PersonaId"))
            TipoProcesoName = ""
        Else
            TipoProcesoName = TipoProceso.LeerTipoProcesoNameById(TipoProcesoId)
        End If

        'Aquí se pinta el formulario variable dependiendo de la acción a ejecutar dentro de la tarea.
        'A partir del Id de la tarea, se obtiene la acción y de allí la página web a leer

        t = Lecturas.LeerPaginaWeb(VistaWeb, TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        If NumeroPagina <> 0 Then
            Call Lecturas.CrearNewVista(NumeroPagina, TituloPagina, MyTask, Session("PersonaId"), True, 735, True, 29)
        End If

        Session("NumeroPagina") = NumeroPagina

        If Not IsPostBack Then
            t = TipoProceso.LeerTipoProceso(TipoProcesoId, TipoProcesoName, TipoProcesoDescription, TipoProcesoSecuencia, ClaseProcesoName, AccionesCodigo)
            txtTipoProcesoId = FindControl("txtTipoProcesoId")
            txtTipoProcesoId.Text = TipoProcesoId
            txtTipoProcesoName = FindControl("txtTipoProcesoName")
            txtTipoProcesoName.Text = TipoProcesoName
            If Len(TipoProcesoName) > 0 Then
                txtTipoProcesoName.Enabled = False
            Else
                txtTipoProcesoName.Enabled = True
            End If
            txtTipoProcesoDescription = FindControl("txtTipoProcesoDescription")
            txtTipoProcesoDescription.Text = TipoProcesoDescription
            txtTipoProcesoSecuencia = FindControl("txtTipoProcesoSecuencia")
            txtTipoProcesoSecuencia.Text = TipoProcesoSecuencia
            txtClaseProcesoName = FindControl("txtClaseProcesoName")
            txtClaseProcesoName.Text = ClaseProcesoName
            txtAccionesCodigo = FindControl("txtAccionesCodigo")
            txtAccionesCodigo.Text = AccionesCodigo
            CreatePerfil()
        Else
            txtTipoProcesoId = FindControl("txtTipoProcesoId")
            txtTipoProcesoName = FindControl("txtTipoProcesoName")
            txtTipoProcesoDescription = FindControl("txtTipoProcesoDescription")
            txtTipoProcesoSecuencia = FindControl("txtTipoProcesoSecuencia")
            txtClaseProcesoName = FindControl("txtClaseProcesoName")
            txtAccionesCodigo = FindControl("txtAccionesCodigo")
        End If

    End Sub
    Sub CreatePerfil()
        Dim Etapas As New Etapas

        MyEtapas.Controls.Add(New LiteralControl(Etapas.ListarEtapasPorTipoProceso(Request.QueryString("Id"), Session("PersonaId"))))

    End Sub

End Class
