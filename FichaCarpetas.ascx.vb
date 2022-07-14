Imports AjaxControlToolkit
Partial Class FichaCarpetas
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 23-08-2011 23:42:51
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
    Dim txtCarpetasPId As TextBox ' Etiqueta : Código - Control : txtGruposCodigo - Variable : GruposCodigo
    Dim txtCarpetasSecuencia As TextBox
    Dim txtCarpetasName As TextBox ' Etiqueta : Nombre - Control : txtGruposName - Variable : GruposName
    Dim txtCarpetasDescription As TextBox ' Etiqueta : Descripción - Control : txtGruposDescription - Variable : GruposDescription
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim CarpetasPId As Long ' Etiqueta : Código - Control : txtGruposCodigo - Variable : GruposCodigo
    Dim CarpetasSecuencia As Long
    Dim CarpetasName As String ' Etiqueta : Nombre - Control : txtGruposName - Variable : GruposName
    Dim CarpetasDescription As String ' Etiqueta : Descripción - Control : txtGruposDescription - Variable : GruposDescription
    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim Carpetas As New Carpetas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        If Request.QueryString("MenuOptionsId") = 509 Then
            Url = Url & "&Carpeta=Carpeta Compliance"
        Else
            Url = Url & "&Carpeta=Carpeta General"
        End If
        Dim Mensaje As String = ""
        Try
            t = Carpetas.CarpetasDelete(Request.QueryString("Id"), CStr(txtCarpetasName.Text), CLng(Session("PersonaId")), Mensaje)
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
        If Request.QueryString("MenuOptionsId") = 509 Then
            Url = Url & "&Carpeta=Carpeta Compliance"
        Else
            Url = Url & "&Carpeta=Carpeta General"
        End If

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
        Dim Carpetas As New Carpetas
        Try
            t = Carpetas.CarpetasUpdate(Request.QueryString("Id"), CLng(txtCarpetasPId.Text), CLng(txtCarpetasSecuencia.Text), CStr(txtCarpetasName.Text), CStr(txtCarpetasDescription.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Carpetas As New Carpetas
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
        NewButton.Visible = False
        SearchButton.Visible = False
        If Not IsPostBack Then
            If Request.QueryString("Id") <> 0 Then
                If t = Carpetas.LeerCarpetas(Request.QueryString("Id"), CarpetasPId, CarpetasSecuencia, CarpetasName, CarpetasDescription) Then
                    txtCarpetasPId = FindControl("txtCarpetasPId")
                    txtCarpetasPId.Text = CarpetasPId
                    txtCarpetasSecuencia = FindControl("txtCarpetasSecuencia")
                    txtCarpetasSecuencia.Text = CarpetasSecuencia
                    txtCarpetasName = FindControl("txtCarpetasName")
                    txtCarpetasName.Text = CarpetasName
                    If CarpetasName = "Carpeta General" Or CarpetasName = "Carpeta Compliance" Then
                        DeleteButton.Visible = False
                    End If
                    txtCarpetasDescription = FindControl("txtCarpetasDescription")
                    txtCarpetasDescription.Text = CarpetasDescription
                    ' Aquí colocare código para invocar uso de las tabs
                    sSQLWhere = ""
                    sSQLOrder = ""
                    Call Lecturas.CreateTabs(NumeroPagina, CarpetasName, Request.QueryString("Id"), MyTabs, "CarpetasPId", sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"), Request.QueryString("Id"), "Carpetas", Session("PersonaId"))
                Else
                    txtCarpetasName = FindControl("txtCarpetasName")
                    txtCarpetasName.Text = Session("CarpetasName")
                End If
            End If
        Else
            txtCarpetasPId = FindControl("TxtCarpetasPId")
            txtCarpetasSecuencia = FindControl("txtCarpetasSecuencia")
            txtCarpetasName = FindControl("txtCarpetasName")
            txtCarpetasDescription = FindControl("txtCarpetasDescription")
        End If
    End Sub
End Class
