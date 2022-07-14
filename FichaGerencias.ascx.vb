Imports AjaxControlToolkit
Partial Class FichaGerencias
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 13-04-2011 17:59:19
    '------------------------------------------------------------
    ' Declaración de botones del formulario
    '----------------------------------------
    Dim WithEvents LoginButton As Button
    Dim WithEvents UpdateButton As Button
    Dim WithEvents CancelButton As Button
    Dim WithEvents NewButton As Button
    Dim WithEvents SearchButton As Button
    Dim WithEvents DeleteButton As Button
    Dim WithEvents ReturnButton As Button
    '----------------------------------------
    ' Declaración de controles de validación
    '----------------------------------------
    Dim valTextBox As RequiredFieldValidator
    Dim sumValidacion As ValidationSummary
    Dim REValidacion As RegularExpressionValidator
    Dim CuValidacion As CustomValidator
    Dim CoValidacion As CompareValidator
    '------------------------------------------
    ' Declaración de Variables de la Aplicación
    '------------------------------------------
    Dim t As Boolean = False
    Dim Logo As String = ""
    Dim BarMenu As String = ""
    Dim SideBarMenu As String = ""
    Dim PaginaWebName As String = ""
    '----------------------------------------
    ' Declaración de Controles del Formulario
    '----------------------------------------
    Dim txtGerenciasCodigo As TextBox ' Etiqueta : Código - Control : txtGerenciasCodigo - Variable : GerenciasCodigo
    Dim txtGerenciasName As TextBox ' Etiqueta : Nombre - Control : txtGerenciasName - Variable : GerenciasName
    Dim txtGerenciasDescription As TextBox ' Etiqueta : Objetivos - Control : txtGerenciasDescription - Variable : GerenciasDescription
    Dim txtUsuariosCodigo As TextBox ' Etiqueta : Usuario Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim txtUsuariosCodigoDescription As TextBox
    Dim txtGerenciasCargo As TextBox ' Etiqueta : Cargo - Control : txtGerenciasCargo - Variable : GerenciasCargo
    Dim txtOrganizacionesCodigo As TextBox ' Etiqueta : Organización - Control : txtGerenciasOrganizacion - Variable : GerenciasOrganizacion
    Dim txtOrganizacionesCodigoDescription As TextBox
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim GerenciasCodigo As String ' Etiqueta : Código - Control : txtGerenciasCodigo - Variable : GerenciasCodigo
    Dim GerenciasName As String ' Etiqueta : Nombre - Control : txtGerenciasName - Variable : GerenciasName
    Dim GerenciasDescription As String ' Etiqueta : Objetivos - Control : txtGerenciasDescription - Variable : GerenciasDescription
    Dim UsuariosCodigo As String ' Etiqueta : Usuario Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim GerenciasCargo As String ' Etiqueta : Cargo - Control : txtGerenciasCargo - Variable : GerenciasCargo
    Dim OrganizacionesCodigo As String ' Etiqueta : Organización - Control : txtGerenciasOrganizacion - Variable : GerenciasOrganizacion
    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim Gerencias As New Gerencias
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim Mensaje As String = ""
        Try
            t = Gerencias.GerenciasDelete(Request.QueryString("Id"), CStr(txtGerenciasCodigo.Text), CLng(Session("PersonaId")), Mensaje)
            If t = False Then
                MyMessage1.Text = Mensaje
            Else
                Response.Redirect(Url)
            End If
        Catch
            t = 0
        End Try
    End Sub
    Protected Sub RFC_Search(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLSearch", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogout", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Request.QueryString("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim AccionesABM As New AccionesABM
        Dim Gerencias As New Gerencias
        Try
            t = Gerencias.GerenciasUpdate(Request.QueryString("Id"), CStr(txtGerenciasCodigo.Text), CStr(txtGerenciasName.Text), CStr(txtGerenciasDescription.Text), CStr(txtUsuariosCodigo.Text), CStr(txtGerenciasCargo.Text), CStr(txtOrganizacionesCodigo.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Gerencias As New Gerencias
        Dim Usuarios As New Usuarios
        Dim Organizaciones As New Organizaciones
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim PaginaWebName As String = ""
        Dim sSQLWhere As String = ""
        Dim sSQLOrder As String = ""
        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler SearchButton.Click, AddressOf RFC_Search
        AddHandler DeleteButton.Click, AddressOf RFC_Delete
        AddHandler CancelButton.Click, AddressOf RFC_Logout
        If Not IsPostBack Then
            If Request.QueryString("Id") <> 0 Then
                If t = Gerencias.LeerGerencias(Request.QueryString("Id"), GerenciasCodigo, GerenciasName, GerenciasDescription, UsuariosCodigo, GerenciasCargo, OrganizacionesCodigo) Then
                    txtGerenciasCodigo = FindControl("txtGerenciasCodigo")
                    txtGerenciasCodigo.Text = GerenciasCodigo
                    txtGerenciasName = FindControl("txtGerenciasName")
                    txtGerenciasName.Text = GerenciasName
                    txtGerenciasDescription = FindControl("txtGerenciasDescription")
                    txtGerenciasDescription.Text = GerenciasDescription
                    txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
                    txtUsuariosCodigo.Text = UsuariosCodigo
                    txtUsuariosCodigoDescription = FindControl("txtUsuariosCodigoDescription")
                    txtUsuariosCodigoDescription.Text = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)
                    txtGerenciasCargo = FindControl("txtGerenciasCargo")
                    txtGerenciasCargo.Text = GerenciasCargo
                    txtOrganizacionesCodigo = FindControl("txtOrganizacionesCodigo")
                    txtOrganizacionesCodigo.Text = OrganizacionesCodigo
                    txtOrganizacionesCodigoDescription = FindControl("txtOrganizacionesCodigoDescription")
                    txtOrganizacionesCodigoDescription.Text = Organizaciones.LeerOrganizacionesDescriptionByName(OrganizacionesCodigo)
                    ' Aquí colocare código para invocar uso de las tabs
                    sSQLWhere = ""
                    sSQLOrder = ""
                    Call Lecturas.CreateTabs(NumeroPagina, GerenciasCodigo, Request.QueryString("Id"), MyTabs, "GerenciasCodigo", sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"), Request.QueryString("Id"), "Gerencias", Session("PersonaId"))
                Else
                    txtGerenciasCodigo = FindControl("txtGerenciasCodigo")
                    txtGerenciasCodigo.Text = Session("GerenciasCodigo")
                End If
            End If
        Else
            txtGerenciasCodigo = FindControl("txtGerenciasCodigo")
            txtGerenciasName = FindControl("txtGerenciasName")
            txtGerenciasDescription = FindControl("txtGerenciasDescription")
            txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
            txtGerenciasCargo = FindControl("txtGerenciasCargo")
            txtOrganizacionesCodigo = FindControl("txtOrganizacionesCodigo")
        End If
    End Sub
End Class
