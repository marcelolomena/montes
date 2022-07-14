
Partial Class SideBarRight
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim t As Boolean = True
        Dim Lecturas As New Lecturas
        Dim LogoTrabajo As String = ""
        Dim Logo As String = ""
        Dim BarMenu As String = ""
        Dim SideBarMenu As String = ""
        Dim PaginaWebName As String = ""
        Dim URLAdicional As String = ""

        't = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        't = Lecturas.LoadOpcionesDelMenu(rptMenu, "SGI")
        URLAdicional = "&Logo1=" & Request.QueryString("Logo1") & "&Banner=" & Request.QueryString("Banner") & "&Logo2=" & Request.QueryString("Logo2")
        't = Lecturas.LoadOpcionesDelMenuSGI(rptMenu, "SGI", URLAdicional)
        t = Lecturas.LoadOpcionesDelMenuSGIV2(rptMenu, "SGI", URLAdicional, Session("RolId"))
    End Sub
End Class
