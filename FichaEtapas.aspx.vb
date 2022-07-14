Imports AjaxControlToolkit
Partial Class FichaEtapas
    Inherits System.Web.UI.Page
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 24-04-2011 8:52:50
    '------------------------------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim EtapasId As Long
    Dim EtapasName As String
    Dim EtapasDescription As String
    Dim EtapasSecuencia As Long
    Dim EtapasPreCondiciones As String
    Dim EtapasPostCondiciones As String
    Dim TipoProcesoId As Long
    Dim TipoProcesoName As String
    '----------------------------------------
    ' Declaración de Controles del Formulario 2
    '----------------------------------------
    Dim txtEtapasId As TextBox
    Dim txtEtapasName As TextBox
    Dim txtEtapasDescription As TextBox
    Dim txtEtapasSecuencia As TextBox
    Dim txtEtapasPreCondiciones As TextBox
    Dim txtEtapasPostCondiciones As TextBox
    Dim txtTipoProcesoId As TextBox
    Dim txtTipoProcesoName As TextBox

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim PaginaWeb As New PaginaWeb
        Dim TipoProceso As New TipoProceso
        Dim t As Boolean = True
        Dim s As Integer = 0

        Dim VistaWeb As String = Request.QueryString("PaginaWebName")
        EtapasId = CLng(Request.QueryString("EtapasId"))
        TipoProcesoId = CLng(Request.QueryString("TipoProcesoId"))
        Dim TipoProcesoName As String = TipoProceso.LeerTipoProcesoNameById(TipoProcesoId)
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim PaginaWebName As String = ""
        Dim PaginaWebTitle As String = PaginaWeb.LeerPaginaWebTitle(VistaWeb)

        Dim Etapas As New Etapas
        Dim PaginaWebUserControl As String = ""
        Dim MisEtapas As String = ""


        If EtapasId = 0 Then 'Crearemos un nuevo registro
            t = Etapas.EtapasInsert(EtapasId, EtapasName, EtapasDescription, Etapas.CalcularNextEtapasSecuencia(TipoProcesoId), EtapasPreCondiciones, EtapasPostCondiciones, TipoProcesoId, TipoProcesoName, Session("PersonaId"))  ' 
        End If

        'MyDeudor.Controls.Add(New LiteralControl("<p><h1>" & PaginaWebTitle & " " & TipoProcesoName & "</h1></p>"))
        'MyResponsable.Controls.Add(New LiteralControl(Etapas.ListarEtapasVigentes(TipoProcesoId)))

        'Aquí se pinta el formulario variable dependiendo de la acción a ejecutar dentro de la tarea.
        'A partir del Id de la tarea, se obtiene la acción y de allí la página web a leer

        t = Lecturas.LeerPaginaWeb(VistaWeb, TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        TituloPagina = TituloPagina & " " & TipoProcesoName
        If NumeroPagina <> 0 Then
            Call Lecturas.CrearNewVista(NumeroPagina, TituloPagina, MyTask, Session("PersonaId"), True, 680, True, 19)
        End If

        Session("NumeroPagina") = NumeroPagina

        If Not IsPostBack Then
            t = Etapas.LeerEtapas(EtapasId, EtapasName, EtapasDescription, EtapasSecuencia, EtapasPreCondiciones, EtapasPostCondiciones, TipoProcesoId, TipoProcesoName)
            txtEtapasId = FindControl("txtEtapasId")
            txtEtapasId.Text = EtapasId
            txtEtapasName = FindControl("txtEtapasName")
            txtEtapasName.Text = EtapasName
            txtEtapasDescription = FindControl("txtEtapasDescription")
            txtEtapasDescription.Text = EtapasDescription
            txtEtapasSecuencia = FindControl("txtEtapasSecuencia")
            txtEtapasSecuencia.Text = EtapasSecuencia
            txtEtapasPreCondiciones = FindControl("txtEtapasPrecondiciones")
            txtEtapasPreCondiciones.Text = EtapasPreCondiciones
            txtEtapasPostCondiciones = FindControl("txtEtapasPostcondiciones")
            txtEtapasPostCondiciones.Text = EtapasPostCondiciones
            txtTipoProcesoId = FindControl("txtTipoProcesoId")
            txtTipoProcesoId.Text = TipoProcesoId
            txtTipoProcesoName = FindControl("txtTipoProcesoName")
            txtTipoProcesoName.Text = TipoProcesoName
            'MisEtapas = MisEtapas & Etapas.ListarAccionesPorEtapas(EtapasId)
            'MyEtapas.Controls.Add(New LiteralControl(MisEtapas))
            CreatePerfil()
        Else
            txtEtapasId = FindControl("txtEtapasId")
            txtEtapasName = FindControl("txtEtapasName")
            txtEtapasDescription = FindControl("txtEtapasDescription")
            txtEtapasSecuencia = FindControl("txtEtapasSecuencia")
            txtEtapasPreCondiciones = FindControl("txtEtapasPrecondiciones")
            txtEtapasPostCondiciones = FindControl("txtEtapasPostcondiciones")
            txtTipoProcesoId = FindControl("txtTipoProcesoId")
            txtTipoProcesoName = FindControl("txtTipoProcesoName")
        End If

    End Sub
    Sub CreatePerfil()
        Dim Etapas As New Etapas

        MyEtapas.Controls.Add(New LiteralControl(Etapas.ListarAccionesPorEtapasPorTipoProceso(Request.QueryString("EtapasId"), CLng(Request.QueryString("TipoProcesoId")), Session("PersonaId"))))
        'MyEtapas.Controls.Add(New LiteralControl(Etapas.ListarAccionesPorEtapas(Request.QueryString("EtapasId"))))

    End Sub

End Class
