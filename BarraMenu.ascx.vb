
Partial Class BarraMenu
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CodigoHTML As String = ""
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim Rol As New Rol
        Dim RolName As String = Rol.LeerRolNameByRolId(Session("RolId"))
        Dim MenuOptions As New MenuOptions

        CodigoHTML = MenuOptions.LoadRaicesDeBarraMenu(Session("RolId"), Session("PortalesId"))
        MyTable.Controls.Add(New LiteralControl(CodigoHTML))

    End Sub
End Class
