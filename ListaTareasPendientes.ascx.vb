
Partial Class ListaTareasPendientes
    Inherits System.Web.UI.UserControl

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
        'Cambio del 26-02-2012
        Dim sSQLWhere As String = Request.QueryString("sSQLWhere")
        Dim sSQLOrder As String = " &sSQLOrderBy=Order by TareasAno, TareasMes, TareasDiaProgramado, TareasId "



        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim Cantidad As Integer = 0
        Dim Codigo As Long = 0
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim sSQL As String = ""
        'sSQLWhere = " AND Tareas.UsuariosCodigo = '" & Request.QueryString("UsuariosCodigo") & "' "
        Url = Url & "&sSqlWhere=" & sSQLWhere
        Url = Url & sSQLOrder
        lblMensaje.Visible = "False"
        sSQL = "SELECT Count(*) AS Cantidad, Max(TareasId) AS Codigo FROM Tareas Where Tareas.EstadoTareasCodigo <> 'Cerrada' " & sSQLWhere
        t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)
        If Cantidad > 0 Then
            'Response.Redirect(Url)  'Se pasa a la página que muestra la lista de tareas
            Session("NumeroPagina") = NumeroPagina
            CreateAccordion(NumeroPagina, TituloPagina, DescripcionPagina, "")
        Else
            If Cantidad = 1 Then    'Se pasa a la página que muestra la ficha de la única tarea encontrada
                Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Codigo
                Response.Redirect(Url)
            Else
                lblMensaje.Text = "<h2>No existen tareas pendientes por ejecutar</h2>"
                lblMensaje.Visible = "True"
            End If
        End If
    End Sub
    Sub CreateAccordion(ByVal NumeroPagina As Integer, ByVal TituloPagina As String, ByVal DescripcionPagina As String, ByVal sSQLWhere As String)
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim Rol As New Rol
        Dim t As Boolean = False
        Dim k As Integer = 0
        Dim i As Integer = 0

        Dim arrLabel(21) As String
        Dim arrControl(21) As String
        Dim arrDomain(21) As String
        Dim TipoControl As String = ""
        Dim CssClassLabel As String = ""
        Dim CssClassControl As String = ""
        Dim ControlWidth As String = ""
        Dim ControlTextMode As String = "0"
        Dim EtiquetaAlign As String = ""
        Dim ToolTip As String = ""
        Dim IsRequiredField As Boolean = True
        Dim IsNotEnabledField As Boolean = False
        Dim DomainField As String = ""
        Dim DataTextField As String = ""
        Dim DataFile As String = ""
        Dim SelectCommand As String = ""
        Dim Section As String = ""
        Dim GroupValidation As String = ""
        Dim FuncionesPorRolId As Long = 0
        Dim IsAuthorizedUser As Boolean = FuncionesPorRol.LeerFuncionesPorRol(Session("RolId"), CLng(Request.QueryString("MenuOptionsId")), "MenuOptions", FuncionesPorRolId)
        Dim RolName As String = Rol.LeerRolNameByRolId(Session("RolId"))
        Dim CodigoHTML As String = ""
        Dim Tareas As New Tareas

        'Dim txtTextoLibre As LiteralControl

        Dim sSQL As String = ""
        Dim HTMLCode As String = ""

        CodigoHTML = CodigoHTML & "<div id=""Accordion1"" class=""Accordion"" tabindex=""0"" >"
        t = Tareas.MostrarTareasPorMes(CodigoHTML, IsAuthorizedUser, Request.QueryString("UsuariosCodigo"))
        CodigoHTML = CodigoHTML & "</div>"
        MyAccordion.Controls.Add(New LiteralControl(CodigoHTML))

    End Sub


End Class
