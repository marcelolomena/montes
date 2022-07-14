
Partial Class ListaMenuOptions
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Portales As New Portales
        Dim t As Boolean
        If Not IsPostBack Then

            lblLinkNuevo.Text = "<a href=""IndexSGI.aspx?PaginaWebName=Ficha de MenuOptions&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=0&Carpeta=Indicar Nombre&PortalesId=" & Request.QueryString("Id") & "&PId=0"" >Agregar opción de Menú Principal</a>"
            ' Variante para administrar el mapa del sitio del portal
            CreateTable(CLng(Request.QueryString("MenuOptionsId")))
        End If
    End Sub
    Sub CreateTable(ByVal MenuOptionsId As Long)
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
        Dim MenuOptions As New MenuOptions
        Dim CodigoHTML As String = ""
        Dim CodigoHTMLCarpetas As String = ""
        Dim CarpetaRaiz As String = ""

        'Session("CarpetaRaiz") = PortalesName
        'CodigoHTML = "<h1>" & TituloPagina & "</h1>"
        CodigoHTML = ""
        CodigoHTML = CodigoHTML & "<br /><div id=""ListaCarpetas"">" & MenuOptions.LoadEditarRaicesCarpeta(CodigoHTMLCarpetas, Session("PersonaId"), IsAuthorizedUser, MenuOptionsId) & "</div>"
        MyTable.Controls.Add(New LiteralControl(CodigoHTML))
    End Sub
End Class
