Imports AjaxControlToolkit
Partial Class ConsultaAccion
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Acciones As New Acciones
        Dim AccionesCodigo As String = CStr(Request.QueryString("Accion"))

        MyDeudor.Controls.Add(New LiteralControl("<center><h1>DESCRIPCIÓN DE LA ACCIÓN</h1></center>"))
        MyResponsable.Controls.Add(New LiteralControl(Acciones.DescribirUnaAccion(AccionesCodigo)))
    End Sub
End Class
