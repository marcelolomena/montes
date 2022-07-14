
Partial Class BarraSuperior
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '-------------
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim Botonera As String = ""
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim Portales As New Portales
        Dim t As Boolean = False
        Dim Rol As New Rol
        Dim RolName As String = Rol.LeerRolNameByRolId(Session("RolId"))
        Dim PortalesUrlIndex As String = ""
        Dim PortalesMasterPage As String = ""

        'If RolName = "Site Administrator" Or RolName = "Site Developer" Then
        '<a href='IndexSGI.aspx?PaginaWebName=Lista de Usuarios&MenuOptionsId=381'><img src='imgs/admin2.png' alt='Administración' width='20' height='20' hspace='2' border='0' align='top' /></a></td>"
        'End If

        t = Portales.LeerURLIndexMasterPage(Session("PortalesName"), PortalesUrlIndex, PortalesMasterPage)
        '<img src="imgs/tareas_rojo.gif" alt="Home" width="20" height="20" hspace="2" border="0" align="top" /><img src="imgs/admin2.png" alt="Perfil" width="20" height="20" hspace="2" border="0" align="top" />

        Botonera = "<a href='LoginPampaNorte.aspx'><img src='IMG/cerrar-sesion.png' alt='Volver al Login' title='Cerrar la Sesión' style='cursor:hand; vertical-align:bottom;' hspace='5' border='0' ></a>"

        'If RolName = "Site Administrator" Or RolName = "Site Developer" Then
        '    Botonera = "<a href='" & PortalesUrlIndex & "'><img src='IMG/home.png' alt='Volver a la home page' title='Volver a la página principal' style='cursor:hand; vertical-align:bottom;' hspace='5' border='0' ></a><a href='" & PortalesMasterPage & "?PaginaWebName=Busca Mis Tareas&Id=" & Session("PersonaId") & "&MenuOptionsId=422&UsuariosCodigo=" & Session("EMail") & "'><img src='imgs/tareas_rojo.gif' alt='Mis Tareas' title='Visualizar su lista de tareas por ejecutar' style='cursor:hand; vertical-align:bottom;' hspace='5' border='0' ></a><a href='IndexSGI.aspx?PaginaWebName=Lista de Usuarios&MenuOptionsId=381'><img src='imgs/admin2.png' alt='Administración' title='Administración' width='20' height='20' hspace='2' border='0' align='top' /></a><a href='LoginPampaNorte.aspx'><img src='IMG/cerrar-sesion.png' alt='Volver al Login' title='Cerrar la Sesión' style='cursor:hand; vertical-align:bottom;' hspace='5' border='0' ></a>"
        'End If

        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "barra_superior"
        Cell.Style(HtmlTextWriterStyle.Height) = "30"
        Cell.VerticalAlign = VerticalAlign.Middle
        If Len(Session("PerNombre")) > 0 Then
            Cell.Controls.Add(New LiteralControl("Bienvenido Sr(a): " & Session("PerNombre") & " - [" & Session("RolName") & "] " & " en [" & Session("PortalesName") & "] " & Botonera))
        Else
            Cell.Controls.Add(New LiteralControl(" "))
        End If
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.Height) = "130"
        Cell.CssClass = "caja_titulo_principal"
        Cell.Controls.Add(New LiteralControl("<img src=""img/titulo_plan_de_relaciones.png"" width=""668"" height=""66"" alt=""Sistema de cobranza judicial a deudores hipotecarios"" />"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)


    End Sub
End Class
