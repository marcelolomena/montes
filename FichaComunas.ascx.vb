Imports AjaxControlToolkit
Partial Class FichaComunas
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 29-08-2011 8:50:58
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
    Dim txtComunasCodigo As TextBox ' Etiqueta : Código Comuna - Control : txtComunasCodigo - Variable : ComunasCodigo
    Dim txtComunasName As TextBox ' Etiqueta : Comuna - Control : txtComunasName - Variable : ComunasName
    Dim txtComunasDescription As TextBox ' Etiqueta : Descripción - Control : txtComunasDescription - Variable : ComunasDescription
    Dim txtComunasAlcalde As TextBox ' Etiqueta : Alcalde - Control : txtComunasAlcalde - Variable : ComunasAlcalde
    Dim txtProvinciasCodigo As TextBox ' Etiqueta : Código Provincia - Control : txtProvinciasCodigo - Variable : ProvinciasCodigo
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim ComunasCodigo As String ' Etiqueta : Código Comuna - Control : txtComunasCodigo - Variable : ComunasCodigo
    Dim ComunasName As String ' Etiqueta : Comuna - Control : txtComunasName - Variable : ComunasName
    Dim ComunasDescription As String ' Etiqueta : Descripción - Control : txtComunasDescription - Variable : ComunasDescription
    Dim ComunasAlcalde As String ' Etiqueta : Alcalde - Control : txtComunasAlcalde - Variable : ComunasAlcalde
    Dim ProvinciasCodigo As String ' Etiqueta : Código Provincia - Control : txtProvinciasCodigo - Variable : ProvinciasCodigo
    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim Comunas As New Comunas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim Mensaje As String = ""
        Try
            t = Comunas.ComunasDelete(Request.QueryString("Id"), CStr(txtComunasCodigo.Text), CLng(Session("PersonaId")), Mensaje)
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
        Dim Comunas As New Comunas
        Try
            t = Comunas.ComunasUpdate(Request.QueryString("Id"), CStr(txtComunasCodigo.Text), CStr(txtComunasName.Text), CStr(txtComunasDescription.Text), CStr(txtComunasAlcalde.Text), CStr(txtProvinciasCodigo.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Comunas As New Comunas
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
                If t = Comunas.LeerComunas(Request.QueryString("Id"), ComunasCodigo, ComunasName, ComunasDescription, ComunasAlcalde, ProvinciasCodigo) Then
                    txtComunasCodigo = FindControl("txtComunasCodigo")
                    txtComunasCodigo.Text = ComunasCodigo
                    txtComunasName = FindControl("txtComunasName")
                    txtComunasName.Text = ComunasName
                    txtComunasDescription = FindControl("txtComunasDescription")
                    txtComunasDescription.Text = ComunasDescription
                    txtComunasAlcalde = FindControl("txtComunasAlcalde")
                    txtComunasAlcalde.Text = ComunasAlcalde
                    txtProvinciasCodigo = FindControl("txtProvinciasCodigo")
                    txtProvinciasCodigo.Text = ProvinciasCodigo
                    ' Aquí colocare código para invocar uso de las tabs
                    sSQLWhere = ""
                    sSQLOrder = ""
                    Call Lecturas.CreateTabs(NumeroPagina, ComunasCodigo, Request.QueryString("Id"), MyTabs, "ComunasCodigo", sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"), Request.QueryString("Id"), "Comunas", Session("PersonaId"))
                Else
                    txtComunasCodigo = FindControl("txtComunasCodigo")
                    txtComunasCodigo.Text = Session("ComunasCodigo")
                End If
            End If
        Else
            txtComunasCodigo = FindControl("txtComunasCodigo")
            txtComunasName = FindControl("txtComunasName")
            txtComunasDescription = FindControl("txtComunasDescription")
            txtComunasAlcalde = FindControl("txtComunasAlcalde")
            txtProvinciasCodigo = FindControl("txtProvinciasCodigo")
        End If
    End Sub
End Class
