Partial Class MovimientoDiario
    Inherits System.Web.UI.UserControl
    ' Declaración de Botones del Formulario
    Dim WithEvents LoginButton As Button
    Dim WithEvents CancelButton As Button
    ' Declaración de Controles del Formulario
    Dim txtFecha As TextBox

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim TituloPagina As String = "Informe de Movimiento Diario de los Procesos Judiciales Vigentes"

        Call Lecturas.CrearFormularioFecha(TituloPagina, MyTable, LoginButton)
        AddHandler LoginButton.Click, AddressOf RFC_Login

        If IsPostBack Then
            txtFecha = FindControl("txtFecha")
        End If
    End Sub
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        Dim TipoProceso As New TipoProceso

        MyAccordion.Controls.Clear()
        MyAccordion.Controls.Add(New LiteralControl(TipoProceso.ListarInformeMovimientoDiarioPorTiposDeProcesos(CDate(txtFecha.Text))))
    End Sub
End Class
