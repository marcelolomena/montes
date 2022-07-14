
Partial Class BarMenu
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim t As Boolean = True
        Dim Lecturas As New Lecturas

        t = Lecturas.LoadOpcionesDelMenu(rptMenu, "Inicio")
    End Sub
End Class
