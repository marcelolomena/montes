Imports AjaxControlToolkit
Partial Class FichaAreas
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 25-01-2011 9:45:58
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
    Dim txtAreasName As TextBox ' Etiqueta : Área - Control : txtAreasName - Variable : AreasName
    Dim txtAreasDescription As TextBox ' Etiqueta : Descripción del área - Control : txtAreasDescription - Variable : AreasDescription
    Dim txtUsuariosCodigo As TextBox ' Etiqueta : Usuario Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim txtUsuariosCodigoDescription As TextBox
    Dim txtAreasCargo As TextBox ' Etiqueta : Cargo - Control : txtGerenciasCargo - Variable : GerenciasCargo
    Dim txtGerenciasCodigo As TextBox ' Etiqueta : Organización - Control : txtGerenciasOrganizacion - Variable : GerenciasOrganizacion
    Dim txtGerenciasCodigoDescription As TextBox
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim AreasName As String ' Etiqueta : Área - Control : txtAreasName - Variable : AreasName
    Dim AreasDescription As String ' Etiqueta : Descripción del área - Control : txtAreasDescription - Variable : AreasDescription
    Dim UsuariosCodigo As String ' Etiqueta : Usuario Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim AreasCargo As String ' Etiqueta : Cargo - Control : txtGerenciasCargo - Variable : GerenciasCargo
    Dim GerenciasCodigo As String ' Etiqueta : Organización - Control : txtGerenciasOrganizacion - Variable : GerenciasOrganizacion
    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim Areas As New Areas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim Mensaje As String = ""
        Try
            t = Areas.AreasDelete(Request.QueryString("Id"), CStr(txtAreasName.Text), CLng(Session("PersonaId")), Mensaje)
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
        Dim Areas As New Areas
        Try
            t = Areas.AreasUpdate(Request.QueryString("Id"), CStr(txtAreasName.Text), CStr(txtAreasDescription.Text), CStr(txtUsuariosCodigo.Text), CStr(txtAreasCargo.Text), CStr(txtGerenciasCodigo.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Areas As New Areas
        Dim Usuarios As New Usuarios
        Dim Gerencias As New Gerencias
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
                If t = Areas.LeerAreas(Request.QueryString("Id"), AreasName, AreasDescription, UsuariosCodigo, AreasCargo, GerenciasCodigo) Then
                    txtAreasName = FindControl("txtAreasName")
                    txtAreasName.Text = AreasName
                    txtAreasDescription = FindControl("txtAreasDescription")
                    txtAreasDescription.Text = AreasDescription
                    txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
                    txtUsuariosCodigo.Text = UsuariosCodigo
                    txtUsuariosCodigoDescription = FindControl("txtUsuariosCodigoDescription")
                    txtUsuariosCodigoDescription.Text = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)
                    txtAreasCargo = FindControl("txtAreasCargo")
                    txtAreasCargo.Text = AreasCargo
                    txtGerenciasCodigo = FindControl("txtGerenciasCodigo")
                    txtGerenciasCodigo.Text = GerenciasCodigo
                    txtGerenciasCodigoDescription = FindControl("txtGerenciasCodigoDescription")
                    txtGerenciasCodigoDescription.Text = Gerencias.LeerGerenciasDescriptionByName(GerenciasCodigo)
                Else
                    txtAreasName = FindControl("txtAreasName")
                    txtAreasName.Text = Session("AreasName")
                End If
            End If
        Else
            txtAreasName = FindControl("txtAreasName")
            txtAreasDescription = FindControl("txtAreasDescription")
            txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
            txtAreasCargo = FindControl("txtAreasCargo")
            txtGerenciasCodigo = FindControl("txtGerenciasCodigo")
        End If
    End Sub
End Class
