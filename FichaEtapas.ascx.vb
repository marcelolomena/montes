Imports AjaxControlToolkit
Partial Class FichaEtapas
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 24-04-2011 8:52:50
    '------------------------------------------------------------
    Dim WithEvents CancelButton As Button
    Dim WithEvents DeleteButton As Button
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
    Dim txtTipoProcesoId As HiddenField
    Dim txtTipoProcesoName As HiddenField
    Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogout", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim Etapas As New Etapas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim Mensaje As String = ""
        Try
            't = Etapas.EtapasDelete(CLng(txtEtapasId.Text), CStr(txtEtapasName.Text), CLng(Session("PersonaId")), Mensaje)
            t = Etapas.EtapasDelete(CLng(HidEtapasId.Value), CStr(HidEtapasName.Value), CLng(Session("PersonaId")), Mensaje)
            If t = False Then
                MyMessage1.Controls.Clear()
                MyMessage1.Controls.Add(New LiteralControl("<h3>" & Mensaje & "</h3>"))
                MyEtapas.Controls.Clear()
                MyEtapas.Controls.Add(New LiteralControl(Etapas.ListarAccionesPorEtapas(CLng(txtEtapasId.Text))))
            Else
                Response.Redirect(Url, True)
            End If
        Catch
            t = 0
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim PaginaWeb As New PaginaWeb
        Dim TipoProceso As New TipoProceso
        Dim t As Boolean = True
        Dim s As Integer = 0

        Dim VistaWeb As String = Request.QueryString("PaginaWebName")
        EtapasId = CLng(Request.QueryString("Id"))
        'TipoProcesoId = CLng(Request.QueryString("TipoProcesoId"))
        TipoProcesoId = 2
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

        t = Lecturas.LeerPaginaWeb(VistaWeb, TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        TituloPagina = TituloPagina ' & " " & TipoProcesoName
        If NumeroPagina <> 0 Then
            Call Lecturas.CrearNewVista(NumeroPagina, TituloPagina, MyTask, Session("PersonaId"), True, 680, True, 19, "ascx", CancelButton, DeleteButton)
            AddHandler CancelButton.Click, AddressOf RFC_Logout
            AddHandler DeleteButton.Click, AddressOf RFC_Delete
        End If
        Session("NumeroPagina") = NumeroPagina

        If Not IsPostBack Then

            If EtapasId = 0 Then 'Crearemos un nuevo registro
                t = Etapas.EtapasInsert(EtapasId, EtapasName, EtapasDescription, Etapas.CalcularNextEtapasSecuencia(TipoProcesoId), EtapasPreCondiciones, EtapasPostCondiciones, TipoProcesoId, TipoProcesoName, Session("PersonaId"))  ' 
            End If

            t = Etapas.LeerEtapas(EtapasId, EtapasName, EtapasDescription, EtapasSecuencia, EtapasPreCondiciones, EtapasPostCondiciones, TipoProcesoId, TipoProcesoName)
            txtEtapasId = FindControl("txtEtapasId")
            txtEtapasId.Text = EtapasId
            txtEtapasName = FindControl("txtEtapasName")
            txtEtapasName.Text = EtapasName
            HidEtapasId.Value = EtapasId
            HidEtapasName.Value = EtapasName
            If Len(EtapasName) = 0 Then
                txtEtapasName.Enabled = True
            Else
                txtEtapasName.Enabled = False
            End If
            txtEtapasDescription = FindControl("txtEtapasDescription")
            txtEtapasDescription.Text = EtapasDescription
            txtEtapasSecuencia = FindControl("txtEtapasSecuencia")
            txtEtapasSecuencia.Text = EtapasSecuencia
            txtEtapasPreCondiciones = FindControl("txtEtapasPrecondiciones")
            txtEtapasPreCondiciones.Text = EtapasPreCondiciones
            txtEtapasPostCondiciones = FindControl("txtEtapasPostcondiciones")
            txtEtapasPostCondiciones.Text = EtapasPostCondiciones
            txtTipoProcesoId = FindControl("txtTipoProcesoId")
            'txtTipoProcesoId.Text = TipoProcesoId
            txtTipoProcesoId.Value = TipoProcesoId
            txtTipoProcesoName = FindControl("txtTipoProcesoName")
            'txtTipoProcesoName.Text = TipoProcesoName
            txtTipoProcesoName.Value = TipoProcesoName
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

        'MyEtapas.Controls.Add(New LiteralControl(Etapas.ListarAccionesPorEtapasPorTipoProceso(Request.QueryString("EtapasId"), CLng(Request.QueryString("TipoProcesoId")), Session("PersonaId"))))
        MyEtapas.Controls.Add(New LiteralControl(Etapas.ListarAccionesPorEtapas(CLng(txtEtapasId.Text))))

    End Sub
End Class
