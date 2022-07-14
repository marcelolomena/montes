
Partial Class AdministraEntidades
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ctlControl As Control
        Dim Lecturas As New Lecturas
        Dim PaginaWebUserControl As String = ""
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim Botonera As String = ""
        Dim Logo As String = ""
        Dim BarMenu As String = ""
        Dim SideBarMenu As String = ""
        Dim PaginaWebName As String = ""
        Dim PagePath As String = ""
        Dim t As Boolean

        Botonera = "<img src='IMG/botones/b_ayuda.gif' style='cursor:hand; vertical-align:bottom;' hspace='3'> | <img src='IMG/botones/b_contacto.gif' style='cursor:hand; vertical-align:bottom;' hspace='3'>| <img src='IMG/inicio.gif' style='cursor:hand; vertical-align:bottom;' hspace='5' border='0' > | <img src='IMG/cerrarsesion.gif' border='0' style='cursor:hand; vertical-align:bottom;'>"
        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        PagePath = "Usted se encuentra en: " & SideBarMenu & " > " & PaginaWebName

        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "textocontgris10bold"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.Style(HtmlTextWriterStyle.Width) = "75%"
        Cell.Style(HtmlTextWriterStyle.Height) = "6"
        If Len(Session("PerNombre")) > 0 Then
            Cell.Controls.Add(New LiteralControl("Bienvenido Sr: " & Session("PerNombre")))
        Else
            Cell.Controls.Add(New LiteralControl(" "))
        End If
        Row.Cells.Add(Cell)
        Cell = New TableCell
        Cell.CssClass = "txt_azul10Right"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "right"
        Cell.Style(HtmlTextWriterStyle.Width) = "25%"
        Cell.Style(HtmlTextWriterStyle.Height) = "6"
        Cell.Controls.Add(New LiteralControl(Botonera))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "textocontgris10bold"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.Style(HtmlTextWriterStyle.Width) = "75%"
        Cell.Style(HtmlTextWriterStyle.Height) = "6"
        Cell.Height = "4"
        'Cell.Controls.Add(New LiteralControl("Usted se encuentra en: " & Request.QueryString("SideBar") & " > " & Request.QueryString("PaginaWebName")))
        Cell.Controls.Add(New LiteralControl(PagePath))
        Row.Cells.Add(Cell)
        Cell = New TableCell
        Cell.CssClass = "txt_azul10Right"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "right"
        Cell.Style(HtmlTextWriterStyle.Width) = "25%"
        'Cell.Style(HtmlTextWriterStyle.Height) = "6"
        Cell.Height = "4"
        Cell.Controls.Add(New LiteralControl(FormatDateTime(Now(), DateFormat.ShortDate)))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        TabPanel1.HeaderText = Request.QueryString("PaginaWebName")
        'TabPanel1.HeaderText = PaginaWebName
        Try
            If Lecturas.PageUserControl(Request.QueryString("PaginaWebName"), PaginaWebUserControl) Then
                'If Lecturas.PageUserControl(PaginaWebName, PaginaWebUserControl) Then
                ctlControl = LoadControl(PaginaWebUserControl)
                PlaceHolder1.Controls.Add(ctlControl)
            Else
                PlaceHolder1.Controls.Add(New LiteralControl("<h1>Página en Construcción</h1>"))
            End If
        Catch ex As Exception
            PlaceHolder1.Controls.Add(New LiteralControl("<h1>Página en Construcción</h1>"))
        End Try

    End Sub
End Class
