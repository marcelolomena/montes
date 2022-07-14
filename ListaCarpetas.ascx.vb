Partial Class ListaCarpetas
    Inherits System.Web.UI.UserControl
    ' Declaración de botones del formulario
    ' No lleva botones
    Dim Logo As String = ""
    Dim BarMenu As String = ""
    Dim SideBarMenu As String = ""
    Dim PaginaWebName As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim sSQLWHERE As String = ""
        Dim sSQLOrderBy As String = ""


        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(PaginaWebName, TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        If Len(Request.QueryString("sSQLWhere")) > 0 Then
            CreateTable(NumeroPagina, TituloPagina, DescripcionPagina, Request.QueryString("sSQLWhere"))
        Else
            CreateTable(NumeroPagina, TituloPagina, DescripcionPagina, "")
        End If
    End Sub
    Sub CreateTable(ByVal NumeroPagina As Integer, ByVal TituloPagina As String, ByVal DescripcionPagina As String, ByVal sSQLWhere As String)
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim Rol As New Rol
        Dim t As Boolean = False
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim FuncionesPorRolId As Long = 0
        Dim IsAuthorizedUser As Boolean = FuncionesPorRol.LeerFuncionesPorRol(Session("RolId"), CLng(Request.QueryString("MenuOptionsId")), "MenuOptions", FuncionesPorRolId)
        Dim RolName As String = Rol.LeerRolNameByRolId(Session("RolId"))
        Dim Carpetas As New Carpetas
        Dim CodigoHTML As String = ""
        Dim CodigoHTMLCarpetas As String = ""
        Dim CarpetaRaiz As String = ""

        Session("CarpetaRaiz") = Request.QueryString("Carpeta")
        CodigoHTML = "<h1>" & TituloPagina & "</h1>"
        CodigoHTML = CodigoHTML & "<br /><div id=""ListaCarpetas"">" & Carpetas.LoadEditarRaicesCarpeta(CodigoHTMLCarpetas, Session("DocumentosSGIId"), Session("PersonaId"), Session("CarpetaRaiz"), IsAuthorizedUser) & "</div>"
        MyTable.Controls.Add(New LiteralControl(CodigoHTML))



    End Sub


End Class
