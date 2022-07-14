
Partial Class LOGOReportesPGG
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Programas As New Programas
        Dim PaginaWeb As New PaginaWeb
        Dim t As Boolean = False
        Dim ProgramasCodigo As String = Request.QueryString("PGGCodigo")
        Dim PaginaWebName As String = Request.QueryString("PaginaWebName")
        Dim Objetivo As String = ""
        Dim Coordinador As String = ""
        Dim Iniciativa As String = ""
        Dim Dimension As String = ""

        t = Programas.LeerCabeceraPrograma(ProgramasCodigo, Objetivo, Coordinador, Iniciativa, Dimension)
        lblTitulo.Text = PaginaWeb.LeerPaginaWebTitle(PaginaWebName)
        lblObjetivo.Text = Objetivo
        lblEncargado.Text = Coordinador
        lblLineaEstrategica.Text = Dimension
        lblSubLineaEstrategica.Text = Iniciativa

    End Sub
End Class
