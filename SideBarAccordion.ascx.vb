
Partial Class SideBarAccordion
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim t As Boolean = True
        Dim Lecturas As New Lecturas
        Dim LogoTrabajo As String = ""
        Dim Logo As String = ""
        Dim BarMenu As String = ""
        Dim SideBarMenu As String = ""
        Dim PaginaWebName As String = ""

        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LoadRaicesDelMenuAccordion(MyTable, SideBarMenu, CLng(Request.QueryString("MenuOptionsId")))

    End Sub
End Class
