
Partial Class FichaFuncionesPorRol
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 23-08-2010 12:01:05
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
    Dim txtMasterName As TextBox ' Etiqueta : Rol - Control : txtMasterName - Variable : RolName
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim RolName As String ' Etiqueta : Rol - Control : txtMasterName - Variable : RolName
    Dim RolDescription As String ' Etiqueta : Descripción - Control : txtRolDescription - Variable : RolDescription
    Dim RolNivel As Long
    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogin", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina
        Try
            MasterName = txtMasterName.Text
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("RolId", "RolName", "Roles", MasterName, MasterId)
            If MasterId > 0 Then
                Url = Url & "&Id=" & MasterId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                Response.Redirect(Url)
            Else
                t = AccionesABM.MasterPartialInsert("RolId", "RolName", "Roles", MasterName, CLng(Session("PersonaId")), MasterId)
                Url = Url & "&Id=" & MasterId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                Response.Redirect(Url)
            End If
        Catch
            t = 0
        End Try
    End Sub
    Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogout", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Rol As New Rol
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim sSQLWhere As String = ""
        Dim sSQLOrder As String = " Order by Class, Secuencia"
        Dim PortalesName As String = ""

        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        Call Lecturas.CrearFormularioLogin(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyTable, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler LoginButton.Click, AddressOf RFC_Login
        LoginButton.Visible = False
        AddHandler CancelButton.Click, AddressOf RFC_Logout
        If Not IsPostBack Then
            If Request.QueryString("Id") <> 0 Then
                If t = Rol.LeerRol(Request.QueryString("Id"), RolName, RolDescription, RolNivel) Then
                    txtMasterName = FindControl("txtMasterName")
                    txtMasterName.Text = RolName
                    'Call Lecturas.CreatePerfil(NumeroPagina, "SGI", 6, MyTabs, "PortalesName", sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"), Request.QueryString("Id"), "MenuOptions", CLng(Session("PersonaId")))

                    ' Variante para administrar los perfiles por rol y portal
                    CreatePerfil()
                Else
                    txtMasterName = FindControl("txtMasterName")
                End If
            End If
        Else
            txtMasterName = FindControl("txtMasterName")
        End If

    End Sub
    Sub CreatePerfil()
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim Rol As New Rol
        Dim t As Boolean = False
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim FuncionesPorRolId As Long = 0
        Dim IsAuthorizedUser As Boolean = FuncionesPorRol.LeerFuncionesPorRol(Session("RolId"), CLng(Request.QueryString("MenuOptionsId")), "MenuOptions", FuncionesPorRolId)
        Dim RolName As String = Rol.LeerRolNameByRolId(Session("RolId"))
        Dim CodigoHTML As String = ""
        Dim CodigoHTMLCarpetas As String = ""
        Dim CarpetaRaiz As String = ""

        CodigoHTML = ""
        CodigoHTML = CodigoHTML & "<br /><div id=""ListaCarpetas"">" & FuncionesPorRol.ListarPortales(CodigoHTMLCarpetas, Session("PersonaId"), IsAuthorizedUser, CLng(Request.QueryString("MenuOptionsId")), Request.QueryString("Id")) & "</div>"
        MyPerfil.Controls.Add(New LiteralControl(CodigoHTML))
    End Sub

End Class
