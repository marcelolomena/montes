
Partial Class ListaTareas
    Inherits System.Web.UI.UserControl
    ' Declaración de botones del formulario
    Dim WithEvents NewButton As Button
    Dim WithEvents SearchButton As Button
    Dim Logo As String = ""
    Dim BarMenu As String = ""
    Dim SideBarMenu As String = ""
    Dim PaginaWebName As String = ""
    Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))

        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Search(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLSearch", Pagina, NombrePagina, Session("NumeroPagina"))

        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url)
    End Sub
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
        Dim t As Boolean = False
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim Row As TableRow
        Dim Cell As TableCell
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


        Dim sqlSource As SqlDataSource
        'Dim txtTextoLibre As LiteralControl
        Dim Grilla As GridView
        Dim sSQL As String = ""
        Dim HTMLCode As String = ""
        Dim HyperColumnGrid As HyperLinkField
        Dim ItemTempColumnGrid As TemplateField



        'Titulo
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "subtit"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl(TituloPagina))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        'Linea de División
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.Height = "4"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("<hr />"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        'Descripción
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "tab_contenido"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl(DescripcionPagina))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        'Linea de División
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.Height = "4"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("<hr />"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        'Botones de busqueda y para agregar un nuevo registro 
        i = 0
        t = Lecturas.LeerButtonFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "tab_contenido"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        For k = 0 To i - 1
            t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Button", GroupValidation, NumeroPagina, k + 1)
            Select Case arrControl(k)
                Case "NewButton"
                    NewButton = New Button
                    NewButton.ID = arrControl(k)
                    NewButton.CssClass = CssClassControl
                    NewButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    NewButton.Text = arrLabel(k)
                    NewButton.ToolTip = ToolTip
                    AddHandler NewButton.Click, AddressOf RFC_New
                    If IsAuthorizedUser = True Then
                        NewButton.Visible = True
                    Else
                        NewButton.Visible = False
                    End If
                    If IsNotEnabledField = True Then NewButton.Visible = False
                    Cell.Controls.Add(NewButton)
                    Cell.Controls.Add(New LiteralControl(" "))
                Case "SearchButton"
                    SearchButton = New Button
                    SearchButton.ID = arrControl(k)
                    SearchButton.CssClass = CssClassControl
                    SearchButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    SearchButton.Text = arrLabel(k)
                    SearchButton.ToolTip = ToolTip
                    AddHandler SearchButton.Click, AddressOf RFC_Search
                    If IsNotEnabledField = True Then SearchButton.Visible = False
                    Cell.Controls.Add(SearchButton)
                    Cell.Controls.Add(New LiteralControl(" "))
            End Select
        Next
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)


        'Linea de División, solo si los botones anteriores estan habilitados
        'Se toma sólo el último como referencia

        If IsNotEnabledField = False Then 'Significa que los botones estan visible y es necesaria la línea
            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Height = "4"
            Cell.ColumnSpan = "2"
            Cell.Controls.Add(New LiteralControl("<hr />"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
        End If

        Row = New TableRow
        Cell = New TableCell

        'Columnas del Formulario
        i = 0
        t = Lecturas.LeerColumnasFormularioWeb(arrLabel, arrControl, NumeroPagina, i)


        Grilla = New GridView
        Grilla.ID = "grid1"
        Grilla.DataSourceID = "ds1"
        Grilla.DataKeyNames = New String(0) {"Id"}
        Grilla.HeaderStyle.CssClass = "grilla_top"
        Grilla.RowStyle.CssClass = "grilla_Fila1"
        Grilla.AlternatingRowStyle.CssClass = "grilla_Fila2"

        Grilla.Width = "700"
        Grilla.AllowPaging = True
        Grilla.AllowSorting = False
        Grilla.PageSize = 10
        Grilla.AutoGenerateColumns = False

        For k = 0 To i - 1
            t = Lecturas.LeerColumnaFormularioWeb(TipoControl, EtiquetaAlign, ControlWidth, ToolTip, SelectCommand, "Grilla", NumeroPagina, k + 1)
            Select Case TipoControl
                Case "HyperLinkField"
                    HyperColumnGrid = New HyperLinkField
                    HyperColumnGrid.DataTextField = arrControl(k)
                    HyperColumnGrid.ShowHeader = True
                    HyperColumnGrid.HeaderText = arrLabel(k)
                    HyperColumnGrid.DataNavigateUrlFields = New String(0) {arrControl(k)}
                    HyperColumnGrid.DataNavigateUrlFormatString = SelectCommand
                    HyperColumnGrid.ItemStyle.Width = ControlWidth
                    HyperColumnGrid.Visible = False  '***
                    Grilla.Columns.Add(HyperColumnGrid)
                    ItemTempColumnGrid = New TemplateField
                    ItemTempColumnGrid.ShowHeader = True
                    'ItemTempColumnGrid.HeaderText = arrLabel(k)
                    ItemTempColumnGrid.HeaderImageUrl = "img/botones/i_solicitar.gif"
                    ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                    ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                    ItemTempColumnGrid.ItemTemplate = New PlantillaImageGrilla(DataControlRowType.DataRow, New String(0) {arrControl(k)}, SelectCommand, "img/botones/i_solicitar.gif")
                    If IsAuthorizedUser = True Then
                        ItemTempColumnGrid.Visible = True
                    Else
                        ItemTempColumnGrid.Visible = False
                    End If
                    Grilla.Columns.Add(ItemTempColumnGrid)
                Case "DeleteField"
                    HyperColumnGrid = New HyperLinkField
                    HyperColumnGrid.DataTextField = arrControl(k)
                    HyperColumnGrid.ShowHeader = True
                    HyperColumnGrid.HeaderText = arrLabel(k)
                    HyperColumnGrid.DataNavigateUrlFields = New String(0) {arrControl(k)}
                    HyperColumnGrid.DataNavigateUrlFormatString = SelectCommand
                    HyperColumnGrid.ItemStyle.Width = ControlWidth
                    HyperColumnGrid.Visible = False  '***
                    Grilla.Columns.Add(HyperColumnGrid)
                    ItemTempColumnGrid = New TemplateField
                    ItemTempColumnGrid.ShowHeader = True
                    'ItemTempColumnGrid.HeaderText = arrLabel(k)
                    ItemTempColumnGrid.HeaderImageUrl = "img/botones/b_eliminar.png"
                    ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                    ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                    ItemTempColumnGrid.ItemTemplate = New PlantillaImageGrilla(DataControlRowType.DataRow, New String(0) {arrControl(k)}, SelectCommand, "img/botones/b_eliminar.png")
                    If IsAuthorizedUser = True Then
                        ItemTempColumnGrid.Visible = True
                    Else
                        ItemTempColumnGrid.Visible = False
                    End If
                    Grilla.Columns.Add(ItemTempColumnGrid)
                Case "DownLoadField"
                    HyperColumnGrid = New HyperLinkField
                    HyperColumnGrid.DataTextField = "Título"
                    HyperColumnGrid.ShowHeader = True
                    HyperColumnGrid.HeaderText = arrLabel(k)
                    HyperColumnGrid.DataNavigateUrlFields = New String(0) {"Url"}
                    HyperColumnGrid.Target = "_blank"
                    HyperColumnGrid.ItemStyle.Width = ControlWidth
                    HyperColumnGrid.ItemStyle.HorizontalAlign = 1
                    'HyperColumnGrid.DataNavigateUrlFormatString = {0}
                    Grilla.Columns.Add(HyperColumnGrid)
                Case "ReportePGGField"
                    ItemTempColumnGrid = New TemplateField
                    ItemTempColumnGrid.ShowHeader = True
                    ItemTempColumnGrid.HeaderText = arrLabel(k)
                    ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                    ItemTempColumnGrid.ItemTemplate = New PlantillaReportePGG(DataControlRowType.DataRow, New String(0) {arrControl(k)}, arrLabel(k))
                    ItemTempColumnGrid.Visible = True
                    ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                    Grilla.Columns.Add(ItemTempColumnGrid)
                Case "TemplateField"
                    ItemTempColumnGrid = New TemplateField
                    ItemTempColumnGrid.ShowHeader = True
                    ItemTempColumnGrid.HeaderText = arrLabel(k)
                    ItemTempColumnGrid.ItemTemplate = New PlantillaGrilla(DataControlRowType.DataRow, New String(0) {arrControl(k)})
                    ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                    Select Case EtiquetaAlign
                        Case "Center"
                            ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                        Case "Left"
                            ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                        Case "Right"
                            ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                        Case "Justify"
                            ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Justify
                        Case Else
                            ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                    End Select
                    Grilla.Columns.Add(ItemTempColumnGrid)
            End Select
        Next

        Cell.Controls.Add(Grilla)
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "txt_label"
        Cell.ColumnSpan = "2"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "right"

        sqlSource As New SqlDataSource()                    
        sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
        sqlSource.SelectCommand = SelectCommand

        sqlSource.ID = "ds1"

        t = Lecturas.LeerSQLStatementFormularioWeb("SQLSelect", DataFile, SelectCommand, NumeroPagina)

        'sqlSource.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\BDCAS.mdb"
        sqlSource.DataFile = DataFile
        sSQL = SelectCommand & " "

        'sSQLWhere = " Where EstadoTareasCodigo <> 'Terminada' "
        sSQL = sSQL & sSQLWhere

        ' Si el rol es Lector, sólo filtrara las tareas que le corresponden al usuario


        ' El orden es por la tareas más antigua en fecha a la más nueva

        'sSQL = sSQL & " Order by TareasAno, TareasMes, TareasSecuencia "
        If Len(Request.QueryString("sSQLOrderBy")) > 0 Then
            sSQL = sSQL & " " & Request.QueryString("sSQLOrderBy")
        End If

        sqlSource.SelectCommand = sSQL

        ' El 22-03-2011 se agrega el caso especial del HAVING para el manejo de selección de datos 
        ' agrupados por alguna condición, como por ejemplo el caso de las Guias no facturadas o facturadas en 
        ' un determinado mes.

        ' Para lo cual primero se desplegará una ventana de parámetros y luego se invocará el reporte.

        If Len(Request.QueryString("sSQLHaving")) > 0 Then
            sSQL = sSQL & " " & Request.QueryString("sSQLHaving")
        End If
        sqlSource.SelectCommand = sSQL

        Cell.Controls.Add(sqlSource)
        Row.Cells.Add(Cell)

        MyTable.Rows.Add(Row)

    End Sub

End Class
