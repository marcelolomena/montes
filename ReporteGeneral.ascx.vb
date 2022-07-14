
Partial Class ReporteGeneral
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim TipoProceso As New TipoProceso

        MyAccordion.Controls.Add(New LiteralControl(TipoProceso.ListarPanelControlPorTiposDeProcesos()))

    End Sub
End Class
