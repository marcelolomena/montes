
Partial Class SelectFromModalList
    Inherits System.Web.UI.Page
    Dim ObjectId As Long
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim DocumentosSGI As New DocumentosSGI
        Dim t As Boolean = True
        lblTitulo.Text = "Ventana de ayuda para la selección de " & Request.QueryString("Accion")
    End Sub
    Sub GetRaiz(ByVal node As TreeNode)
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        t = Lecturas.LoadModalList(node, Request.QueryString("Accion"))
    End Sub
    Sub GetHoja(ByVal node As TreeNode)
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        t = Lecturas.LoadHojaPorAmbitos(node)
    End Sub
    Sub GetDocumento(ByVal node As TreeNode)
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        't = Lecturas.LoadGruposPorHoja(node)
        t = Lecturas.LoadDocumentosPorHoja(node)
    End Sub
    Sub PopulateNode(ByVal source As Object, ByVal e As TreeNodeEventArgs)
        Select Case e.Node.Depth
            Case 0
                GetRaiz(e.Node)
                'Case 1
                'GetHoja(e.Node)
                'Case 2
                '    GetDocumento(e.Node)
        End Select
    End Sub

End Class
