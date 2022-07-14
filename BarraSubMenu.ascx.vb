
Partial Class BarraSubMenu
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim t As Boolean = True
        Dim Lecturas As New Lecturas
        Dim LogoTrabajo As String = ""
        Dim Logo As String = ""
        Dim BarMenu As String = ""
        Dim SideBarMenu As String = ""
        Dim PaginaWebName As String = ""
        Dim MenuOptions As New MenuOptions
        Dim MenuOptionsId As Long = 0
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim FuncionesPorRolId As Long = 0

        MenuOptionsId = MenuOptions.LeerHastaBarMenu(CLng(Request.QueryString("MenuOptionsId")))

        'Se muestra el sub menu solo si se indico que tiene privilegios para el menú principal
        If FuncionesPorRol.LeerFuncionesPorRol(Session("RolId"), MenuOptionsId, "MenuOptions", FuncionesPorRolId) = True Then
            t = MenuOptions.LoadRaicesDeBarraSubMenu(MyTable, MenuOptionsId, Session("RolId"))
        End If
    End Sub
End Class
