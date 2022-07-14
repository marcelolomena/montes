Imports AjaxControlToolkit
Partial Class FichaProvincias
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 29-08-2011 8:41:55
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
    Dim txtProvinciasCodigo As TextBox ' Etiqueta : Código Provincia - Control : txtProvinciasCodigo - Variable : ProvinciasCodigo
    Dim txtProvinciasName As TextBox ' Etiqueta : Provincia - Control : txtProvinciasName - Variable : ProvinciasName
    Dim txtProvinciasDescription As TextBox ' Etiqueta : Descripción - Control : txtProvinciasDescription - Variable : ProvinciasDescription
    Dim txtProvinciasGobernador As TextBox ' Etiqueta : Nombre Gobernador - Control : txtProvinciasGobernador - Variable : ProvinciasGobernador
    Dim txtRegionesCodigo As TextBox ' Etiqueta : Código Región - Control : txtRegionesCodigo - Variable : RegionesCodigo
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim ProvinciasCodigo As String ' Etiqueta : Código Provincia - Control : txtProvinciasCodigo - Variable : ProvinciasCodigo
    Dim ProvinciasName As String ' Etiqueta : Provincia - Control : txtProvinciasName - Variable : ProvinciasName
    Dim ProvinciasDescription As String ' Etiqueta : Descripción - Control : txtProvinciasDescription - Variable : ProvinciasDescription
    Dim ProvinciasGobernador As String ' Etiqueta : Nombre Gobernador - Control : txtProvinciasGobernador - Variable : ProvinciasGobernador
    Dim RegionesCodigo As String ' Etiqueta : Código Región - Control : txtRegionesCodigo - Variable : RegionesCodigo
    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim Provincias As New Provincias
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim Mensaje As String = ""
        Try
            t = Provincias.ProvinciasDelete(Request.QueryString("Id"), CStr(txtProvinciasCodigo.Text), CLng(Session("PersonaId")), Mensaje)
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
        Dim Provincias As New Provincias
        Try
            t = Provincias.ProvinciasUpdate(Request.QueryString("Id"), CStr(txtProvinciasCodigo.Text), CStr(txtProvinciasName.Text), CStr(txtProvinciasDescription.Text), CStr(txtProvinciasGobernador.Text), CStr(txtRegionesCodigo.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Provincias As New Provincias
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
                If t = Provincias.LeerProvincias(Request.QueryString("Id"), ProvinciasCodigo, ProvinciasName, ProvinciasDescription, ProvinciasGobernador, RegionesCodigo) Then
                    txtProvinciasCodigo = FindControl("txtProvinciasCodigo")
                    txtProvinciasCodigo.Text = ProvinciasCodigo
                    txtProvinciasName = FindControl("txtProvinciasName")
                    txtProvinciasName.Text = ProvinciasName
                    txtProvinciasDescription = FindControl("txtProvinciasDescription")
                    txtProvinciasDescription.Text = ProvinciasDescription
                    txtProvinciasGobernador = FindControl("txtProvinciasGobernador")
                    txtProvinciasGobernador.Text = ProvinciasGobernador
                    txtRegionesCodigo = FindControl("txtRegionesCodigo")
                    txtRegionesCodigo.Text = RegionesCodigo
                    ' Aquí colocare código para invocar uso de las tabs
                    sSQLWhere = ""
                    sSQLOrder = ""

                Else
                    txtProvinciasCodigo = FindControl("txtProvinciasCodigo")
                    txtProvinciasCodigo.Text = Session("ProvinciasCodigo")
                End If
            End If
        Else
            txtProvinciasCodigo = FindControl("txtProvinciasCodigo")
            txtProvinciasName = FindControl("txtProvinciasName")
            txtProvinciasDescription = FindControl("txtProvinciasDescription")
            txtProvinciasGobernador = FindControl("txtProvinciasGobernador")
            txtRegionesCodigo = FindControl("txtRegionesCodigo")
        End If
    End Sub
End Class
