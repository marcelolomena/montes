Partial Class CambiarCargoSuperior
    Inherits System.Web.UI.Page
    Dim ObjectId As Long
    Dim Empresa As String
    Dim SystemId As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim MenuOptions As New MenuOptions
        Dim Portales As New Portales
        Dim t As Boolean = True
        ObjectId = Request.QueryString("ObjectId")
        txtDependenciaActual.Text = Request.QueryString("Superior")
        SystemId = Request.QueryString("ObjectId")
        txtCargo.Text = Portales.LeerPortalesName(SystemId)
        txtObjectId.Text = Request.QueryString("ObjectId")
        Empresa = Request.QueryString("Empresa")

        Select Case Request.QueryString("Accion")
            Case "Cargo"
                lblTitulo.Text = "Cambio de la dependencia jerárquica de la opción de menú"
                lblCargo.Text = "Nombre de la Opción:"
                lblCargoSuperiorActual.Text = "Opción Superior Actual:"
                lblCargoSuperiorPropuesto.Text = "Opción Superior Propuesta:"
            Case "Empleado"
                lblTitulo.Text = "Cambio de Cargo de un Empleado"
                lblCargo.Text = "Nombre del Empleado:"
                lblCargoSuperiorActual.Text = "Cargo Actual:"
                lblCargoSuperiorPropuesto.Text = "Nuevo Cargo:"
        End Select
    End Sub
    Sub GetRaiz(ByVal node As TreeNode)
        Dim MenuOptions As New MenuOptions
        Dim t As Boolean
        t = MenuOptions.LoadRaizPorMenu(node, SystemId)
    End Sub
    Sub GetHoja(ByVal node As TreeNode)
        Dim MenuOptions As New MenuOptions
        Dim t As Boolean
        t = MenuOptions.LoadHojaPorMenu(node)
    End Sub
    Sub PopulateNode(ByVal source As Object, ByVal e As TreeNodeEventArgs)
        Select Case e.Node.Depth
            Case 0
                GetRaiz(e.Node)
            Case Is > 0
                GetHoja(e.Node)
        End Select
    End Sub
End Class
