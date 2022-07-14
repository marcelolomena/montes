
Partial Class MostrarCarpetas
    Inherits System.Web.UI.UserControl

    Sub GetRaiz(ByVal node As TreeNode, ByVal Carpeta As String)
        Dim Carpetas As New Carpetas
        Dim t As Boolean
        t = Carpetas.LoadNivel1(node, Carpeta)
    End Sub
    Sub GetHoja(ByVal node As TreeNode)
        Dim Carpetas As New Carpetas
        Dim t As Boolean
        t = Carpetas.LoadNivel2(node)
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
                GetRaiz(e.Node, Request.QueryString("Carpeta"))
            Case 1
                GetHoja(e.Node)
            Case 2
                GetHoja(e.Node)
            Case 3
                GetHoja(e.Node)
            Case 4
                GetHoja(e.Node)
        End Select
    End Sub
End Class
