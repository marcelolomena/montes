
Partial Class BuscaMisTareas
    Inherits System.Web.UI.UserControl
    '------------------------------------------
    ' Declaración de Variables de la Aplicación
    '------------------------------------------
    Dim t As Boolean = False
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
        Dim sSQLWhere As String = ""
        Dim sSQLOrder As String = " &sSQLOrderBy=Order by TareasAno, TareasMes, TareasDiaProgramado, TareasId "
        Dim UsuariosCodigo As String = ""
        Dim Usuarios As New Usuarios

        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim Cantidad As Integer = 0
        Dim Codigo As Long = 0
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        'Aquí vamos a intervenir para usar la variable de sesión del usuario conectado.
        'Se le envia a conectarse si ha perdido la variable de sesión
        If Session("PersonaId") = 0 Then Response.Redirect("LoginPampaNorte.aspx", True)
        t = Usuarios.LeerUsuariosCodigoByUsuariosId(CLng(Session("PersonaId")), UsuariosCodigo)
        ' Ahora donde se usaba el requestquerystring de usuarioscodigo, se usuara estrictamente la variable de sesión.


        Dim sSQL As String = ""
        sSQLWhere = " AND Tareas.UsuariosCodigo = '" & UsuariosCodigo & "' "
        Url = Url & "&sSqlWhere=" & sSQLWhere
        Url = Url & sSQLOrder
        Url = Url & "&UsuariosCodigo=" & UsuariosCodigo
        lblMensaje.Visible = "False"
        sSQL = "SELECT Count(*) AS Cantidad, Max(TareasId) AS Codigo FROM Tareas Where Tareas.EstadoTareasCodigo <> 'Cerrada' " & sSQLWhere
        t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)
        If Cantidad > 1 Then
            Response.Redirect(Url)  'Se pasa a la página que muestra la lista de tareas
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
End Class
