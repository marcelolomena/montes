Imports AjaxControlToolkit
Partial Class FichaCargos
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 18-04-2011 18:54:40
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
    Dim txtCargosCodigo As TextBox ' Etiqueta : Código - Control : txtCargosCodigo - Variable : CargosCodigo
    Dim txtCargosName As TextBox ' Etiqueta : Nombre - Control : txtCargosName - Variable : CargosName
    Dim txtCargosDescription As TextBox ' Etiqueta : Descripción - Control : txtCargosDescription - Variable : CargosDescription
    Dim txtAreasName As TextBox ' Etiqueta : Gerencia - Control : txtGerenciasCodigo - Variable : GerenciasCodigo
    Dim txtAreasNameDescription As TextBox
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim CargosCodigo As String ' Etiqueta : Código - Control : txtCargosCodigo - Variable : CargosCodigo
    Dim CargosName As String ' Etiqueta : Nombre - Control : txtCargosName - Variable : CargosName
    Dim CargosDescription As String ' Etiqueta : Descripción - Control : txtCargosDescription - Variable : CargosDescription
    Dim AreasName As String ' Etiqueta : Gerencia - Control : txtGerenciasCodigo - Variable : GerenciasCodigo
    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim Cargos As New Cargos
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim Mensaje As String = ""
        Try
            t = Cargos.CargosDelete(Request.QueryString("Id"), CStr(txtCargosCodigo.Text), CLng(Session("PersonaId")), Mensaje)
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
        Dim Cargos As New Cargos
        Try
            t = Cargos.CargosUpdate(Request.QueryString("Id"), CStr(txtCargosCodigo.Text), CStr(txtCargosName.Text), CStr(txtCargosDescription.Text), CStr(txtAreasName.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Cargos As New Cargos
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
                If t = Cargos.LeerCargos(Request.QueryString("Id"), CargosCodigo, CargosName, CargosDescription, AreasName) Then
                    txtCargosCodigo = FindControl("txtCargosCodigo")
                    txtCargosCodigo.Text = CargosCodigo
                    txtCargosName = FindControl("txtCargosName")
                    txtCargosName.Text = CargosName
                    txtCargosDescription = FindControl("txtCargosDescription")
                    txtCargosDescription.Text = CargosDescription
                    txtAreasName = FindControl("txtAreasName")
                    txtAreasName.Text = AreasName
                    txtAreasNameDescription = FindControl("txtAreasNameDescription")
                    txtAreasNameDescription.Text = Gerencias.LeerGerenciasDescriptionByName(AreasName)
                    ' Aquí colocare código para invocar uso de las tabs
                    sSQLWhere = ""
                    sSQLOrder = ""
                    Call Lecturas.CreateTabs(NumeroPagina, CargosCodigo, Request.QueryString("Id"), MyTabs, "CargosCodigo", sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"), Request.QueryString("Id"), "Cargos", Session("PersonaId"))

                Else
                    txtCargosCodigo = FindControl("txtCargosCodigo")
                    txtCargosCodigo.Text = Session("CargosCodigo")
                End If
            End If
        Else
            txtCargosCodigo = FindControl("txtCargosCodigo")
            txtCargosName = FindControl("txtCargosName")
            txtCargosDescription = FindControl("txtCargosDescription")
            txtAreasName = FindControl("txtAreasName")
        End If
    End Sub
End Class
