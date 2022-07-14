
Partial Class Equipo
    Inherits System.Web.UI.UserControl
    ' Declaración de botones del formulario
    Dim WithEvents NewButton As Button
    Dim WithEvents SearchButton As Button
    Dim Logo As String = ""
    Dim BarMenu As String = ""
    Dim SideBarMenu As String = ""
    Dim PaginaWebName As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim sSQLWHERE As String = ""
        Dim sSQLOrderBy As String = ""


        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(PaginaWebName, TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        CreateAccordion(NumeroPagina, TituloPagina, DescripcionPagina, "")

    End Sub
    Sub CreateAccordion(ByVal NumeroPagina As Integer, ByVal TituloPagina As String, ByVal DescripcionPagina As String, ByVal sSQLWhere As String)
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim Rol As New Rol

        Dim FuncionesPorRolId As Long = 0
        Dim IsAuthorizedUser As Boolean = FuncionesPorRol.LeerFuncionesPorRol(Session("RolId"), CLng(Request.QueryString("MenuOptionsId")), "MenuOptions", FuncionesPorRolId)
        Dim RolName As String = Rol.LeerRolNameByRolId(Session("RolId"))
        Dim CodigoHTML As String = ""
        Dim DimensionesEstrategicas As New DimensionesEstrategicas
        Dim t As Boolean

        CodigoHTML = CodigoHTML & "<div id=""Accordion1"" class=""Accordion"" tabindex=""0"" >"
        t = Rol.MostrarRol(CodigoHTML, IsAuthorizedUser)
        CodigoHTML = CodigoHTML & "</div>"
        MyAccordion.Controls.Add(New LiteralControl(CodigoHTML))

    End Sub
End Class
