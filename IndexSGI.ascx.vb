
Partial Class IndexSGI
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ctlControl As Control
        Dim Lecturas As New Lecturas
        Dim PaginaWeb As New PaginaWeb
        Dim MenuOptions As New MenuOptions
        Dim PaginaWebUserControl As String = ""

        '-------------
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim Botonera As String = ""
        Dim Logo As String = ""
        Dim BarMenu As String = ""
        Dim SideBarMenu As String = ""
        Dim PaginaWebName As String = ""
        Dim PagePath As String = ""
        Dim t As Boolean

        'Botonera = "<img src='IMG/botones/b_ayuda.gif' style='cursor:hand; vertical-align:bottom;' hspace='3'> | <img src='IMG/botones/b_contacto.gif' style='cursor:hand; vertical-align:bottom;' hspace='3'>| <a href='IndexSGI.aspx?PaginaWebName=Por definir&MenuOptionsId=174'><img src='IMG/inicio.gif' style='cursor:hand; vertical-align:bottom;' hspace='5' border='0' ></a> | <img src='IMG/cerrarsesion.gif' border='0' style='cursor:hand; vertical-align:bottom;'>"

        'Botonera = "<a href=""javascript:window.print();""><img src='IMG/botones/i_imprimir.gif' alt='Imprimir la página' title='Imprimir la página' style='cursor:hand; vertical-align:bottom;' hspace='5' border='0' ></a> |<a href='IndexSGI.aspx?PaginaWebName=Por definir&MenuOptionsId=174'><img src='IMG/inicio.gif' alt='Volver a la home page' title='Volver a la página principal' style='cursor:hand; vertical-align:bottom;' hspace='5' border='0' ></a> |<a href='Login.aspx'><img src='IMG/botones/i_SolEjecutivo.gif' alt='Volver al Login' title='Volver a la página Login' style='cursor:hand; vertical-align:bottom;' hspace='5' border='0' ></a> | <img src='IMG/cerrarsesion.gif' title='Cerrar la sesión' border='0' style='cursor:hand; vertical-align:bottom;' alt='Salir de la Aplicación' onclick='window.close();'>"
        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        PagePath = MenuOptions.LeerTexto(Request.QueryString("MenuOptionsId")) & " > " & PaginaWeb.LeerPaginaWebTitle(Request.QueryString("PaginaWebName"))

        'Row = New TableRow
        'Cell = New TableCell
        'Cell.CssClass = "textocontgris10bold"
        'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        'Cell.Style(HtmlTextWriterStyle.Width) = "60%"
        'Cell.Style(HtmlTextWriterStyle.Height) = "6"
        'If Len(Session("PerNombre")) > 0 Then
        'Cell.Controls.Add(New LiteralControl("Bienvenido Sr(a): <a href='IndexSGI.aspx?PaginaWebName=Busca Mis Tareas&Id=" & Session("PersonaId") & "&MenuOptionsId=422&UsuariosCodigo=" & Session("EMail") & "'>" & Session("PerNombre") & "</a>" & " - " & Session("RolName")))
        'Else
        'Cell.Controls.Add(New LiteralControl(" "))
        'End If

        'If Len(Session("PerNombre")) > 0 Then
        'Cell.Controls.Add(New LiteralControl("Bienvenido Sr(a): " & Session("PerNombre") & " - " & Session("RolName")))
        'Else
        'Cell.Controls.Add(New LiteralControl(" "))
        'End If
        'Row.Cells.Add(Cell)
        'Cell = New TableCell
        'Cell.CssClass = "txt_azul10Right"
        'Cell.Style(HtmlTextWriterStyle.TextAlign) = "right"
        'Cell.Style(HtmlTextWriterStyle.Width) = "40%"
        'Cell.Height = "4"
        'Cell.Controls.Add(New LiteralControl(FormatDateTime(Now(), DateFormat.ShortDate)))
        'Cell.Controls.Add(New LiteralControl(" "))
        'Cell.Controls.Add(New LiteralControl(Botonera))
        'Row.Cells.Add(Cell)
        'MyTable.Rows.Add(Row)
        'Agrego el path de donde estoy.
        Row = New TableRow
        Cell = New TableCell
        'Cell.CssClass = "textocontgris10bold"
        Cell.ColumnSpan = "2"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        'Cell.Style(HtmlTextWriterStyle.Height) = "6"
        Cell.Controls.Add(New LiteralControl("<h4>" & PagePath & "</h4>"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        '----------------
        If Session("PersonaId") = 0 Then
            TabPanel1.HeaderText = "Control de Acceso"

            Try
                If Lecturas.PageUserControl("LoginPampaNorte", PaginaWebUserControl) Then
                    'ctlControl = LoadControl(PaginaWebUserControl)
                    'PlaceHolder1.Controls.Add(ctlControl)
                    Response.Redirect("LoginPampaNorte.aspx", True)
                Else
                    'TabPanel1.HeaderText = "Home"
                    'ctlControl = LoadControl("PorDefinir.ascx")
                    'PlaceHolder1.Controls.Add(ctlControl)
                    ''PlaceHolder1.Controls.Add(New LiteralControl("<h1>Página en Construcción</h1>"))
                    Response.Redirect("LoginPampaNorte.aspx", True)
                End If
            Catch ex As Exception
                'PlaceHolder1.Controls.Add(New LiteralControl("<h1>Página en Construcción</h1>"))
                Response.Redirect("LoginPampaNorte.aspx", True)
            End Try


        Else
            If Request.QueryString("PaginaWebName") = "Por definir" Then
                TabPanel1.HeaderText = "Home"
            Else
                TabPanel1.HeaderText = Request.QueryString("PaginaWebName")
            End If

            Try
                If Lecturas.PageUserControl(Request.QueryString("PaginaWebName"), PaginaWebUserControl) Then
                    ctlControl = LoadControl(PaginaWebUserControl)
                    PlaceHolder1.Controls.Add(ctlControl)
                Else
                    TabPanel1.HeaderText = "Home"
                    ctlControl = LoadControl("PorDefinir.ascx")
                    PlaceHolder1.Controls.Add(ctlControl)
                    'PlaceHolder1.Controls.Add(New LiteralControl("<h1>Página en Construcción</h1>"))
                End If
            Catch ex As Exception
                Console.WriteLine(ex.ToString)
                PlaceHolder1.Controls.Add(New LiteralControl("<h1>Página en Construcción</h1>"))
            End Try
        End If
    End Sub
End Class
