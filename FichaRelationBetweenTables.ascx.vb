Imports AjaxControlToolkit
Partial Class FichaRelationBetweenTables
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 22-08-2011 13:25:34
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
    Dim txtProgramasCodigo As TextBox ' Etiqueta : Código - Control : txtProgramasCodigo - Variable : ProgramasCodigo
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim ProgramasCodigo As String ' Etiqueta : Código - Control : txtProgramasCodigo - Variable : ProgramasCodigo
    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Search(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim Url As String = ""

        t = Lecturas.LeerURLStatementFormularioWeb("URLLogout", Pagina, NombrePagina, Session("NumeroPagina"))
        Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Request.QueryString("MasterId")
        If NombrePagina = "Ficha de TareasCreditos" Then
            t = CarpetaJudicialCreditos.LeerMasterNameMasterId(Request.QueryString("MasterId"), MasterId, MasterName)
            Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Request.QueryString("MasterId") & "&MasterId=" & MasterId & "&MasterName=" & MasterName
        End If
        If NombrePagina = "Ficha de CarpetaJudicialCreditos" Then
            t = CarpetaJudicial.LeerMasterNameMasterId(Request.QueryString("MasterId"), MasterId, MasterName)
            Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Request.QueryString("MasterId") & "&MasterId=" & MasterId & "&MasterName=" & MasterName
        End If
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Programas As New Programas
        Dim ProgramasMapa As New ProgramasMapa
        Dim PaginaWeb As New PaginaWeb
        Dim Entidad As New Entidad
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim PaginaWebName As String = ""
        Dim sSQLWhere As String = ""
        Dim sSQLOrder As String = ""
        Dim PivotTable As String = ""
        Dim CampoCodigo As String = ""
        Dim ProgramasCodigo As String = ""
        Dim StakeholdersCodigo As String = ""

        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        PivotTable = PaginaWeb.LeerPivotTable(Request.QueryString("PaginaWebName"))
        CampoCodigo = Entidad.LeerCampoCodigo(PivotTable)
        Session("NumeroPagina") = NumeroPagina
        Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler SearchButton.Click, AddressOf RFC_Search
        AddHandler DeleteButton.Click, AddressOf RFC_Delete
        AddHandler CancelButton.Click, AddressOf RFC_Logout
        UpdateButton.Visible = False
        NewButton.Visible = False
        SearchButton.Visible = False
        DeleteButton.Visible = False
        txtProgramasCodigo = FindControl("txtProgramasCodigo")
        txtProgramasCodigo.Text = Request.QueryString("MasterName")
        If Request.QueryString("PaginaWebName") = "Ficha de AccionesPorStakeholder" Then
            t = ProgramasMapa.LeerProgramasMapaProgramaYStakeholder(Request.QueryString("MasterId"), ProgramasCodigo, StakeholdersCodigo)
            txtProgramasCodigo.Text = ProgramasCodigo & " para " & StakeholdersCodigo
        End If
        If Request.QueryString("PaginaWebName") = "Ficha de DocumentosSGIPorCarpeta" Then
            If Request.QueryString("MenuOptionsId") = 509 Then
                Session("CarpetaRaiz") = "Carpeta Compliance"
            Else
                Session("CarpetaRaiz") = "Carpeta General"
            End If
        End If
        Call Lecturas.CreateTabs(NumeroPagina, ProgramasCodigo, Request.QueryString("MasterId"), MyTabs, CampoCodigo, sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"), Request.QueryString("MasterId"), PivotTable, Session("PersonaId"))

    End Sub
End Class
