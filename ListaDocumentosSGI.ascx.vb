Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Partial Class ListaDocumentosSGI
    Inherits System.Web.UI.UserControl

    ' Declaración de botones del formulario
    Dim WithEvents NewButton As Button

    Dim Logo As String = ""
    Dim BarMenu As String = ""
    Dim SideBarMenu As String = ""
    Dim PaginaWebName As String = ""
    Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
        'Dim Lecturas As New Lecturas
        'Dim t As Boolean
        'Dim Pagina As String = ""
        'Dim NombrePagina As String = ""
        't = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))

        'Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        'Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Areas As New Areas
        Dim MenuOptions As New MenuOptions
        Dim TipoDoc As New TipoDoc
        Dim t As Boolean = True
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Row As TableRow
        Dim Cell As TableCell

        Dim OpcionMenu As String = Request.QueryString("GrupoDocs")
        Dim MenuOptionsId As Long = CLng(Request.QueryString("MenuOptionsId"))
        Dim MenuOptionsPId As Long = MenuOptions.LeerMenuOptionsPId(MenuOptionsId)

        Dim TituloPagina As String = Request.QueryString("Titulo")
        Dim DescripcionPagina As String = ""
        Dim DescripcionArea As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim sSQLWHERE As String = ""
        Dim sSQLOrderBy As String = ""
        Dim PanelScroll As Panel
        Dim txtTextBox As TextBox

        'Vamos a ver si resulta esta lesera
        Dim csName1 As String = "PopupScript"
        Dim cstype As Type = Me.GetType()
        Dim cs As ClientScriptManager = Page.ClientScript


        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(PaginaWebName, TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina

        TituloPagina = Request.QueryString("GrupoDocs")

        If TituloPagina = "Política" Or TituloPagina = "Formulario" Or TituloPagina = "API" Then
            TituloPagina = TipoDoc.LeerTipoDocDescriptionByName(TituloPagina)
        End If

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

        'Considero que aquí es donde deberiamos poner la descripción del requisito de la norma

        Select Case OpcionMenu
            Case "Política", "Formulario", "API"

            Case "Normativa Interna"

            Case "Procedimientos e Instructivos VP"

            Case "Procedimientos e Instructivos DET"

            Case "Marco Regulatorio Legislación Externa"

            Case "Lista de Documentos"

                Row = New TableRow
                Cell = New TableCell
                Cell.CssClass = "subtit"
                Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
                Cell.ColumnSpan = "2"
                Cell.Controls.Add(New LiteralControl("<br /><img src='img/flecha_naranja.gif' width='10' height='10'/><a class='linkmenu' onclick='aparecer(""subgrilla" & MenuOptionsId & """)' ><span class='subtit'>" & "Condición de búsqueda" & "</span></a>"))
                Cell.Controls.Add(New LiteralControl("<br /><div id=""subgrilla" & MenuOptionsId & """ class='invisible'>"))
                PanelScroll = New Panel
                PanelScroll.ID = "panel" & MenuOptionsId
                PanelScroll.ClientIDMode = UI.ClientIDMode.Static
                PanelScroll.ScrollBars = ScrollBars.Auto
                PanelScroll.Height = "50"
                txtTextBox = New TextBox
                txtTextBox.ID = "txtRequisito" & MenuOptionsId
                txtTextBox.ClientIDMode = ClientIDMode.Static
                txtTextBox.CssClass = "tab_contenido"
                txtTextBox.Style(HtmlTextWriterStyle.Width) = "695"
                txtTextBox.TextMode = 1
                txtTextBox.Height = "40"
                txtTextBox.Width = "695"
                txtTextBox.ToolTip = "Condición de búsqueda en formato SQL"
                txtTextBox.Enabled = True
                txtTextBox.Text = Request.QueryString("sSQLWhere")
                PanelScroll.Controls.Add(txtTextBox)
                Cell.Controls.Add(PanelScroll)
                Cell.Controls.Add(New LiteralControl("</div>"))
                Row.Cells.Add(Cell)
                MyTable.Rows.Add(Row)

            Case Else

                Row = New TableRow
                Cell = New TableCell
                Cell.CssClass = "subtit"
                Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
                Cell.ColumnSpan = "2"
                Cell.Controls.Add(New LiteralControl("<br /><img src='img/flecha_naranja.gif' width='10' height='10'/><a class='linkmenu' onclick='aparecer(""subgrilla" & MenuOptionsId & """)' ><span class='subtit'>" & "Requisitos" & "</span></a>"))
                Cell.Controls.Add(New LiteralControl("<br /><div id=""subgrilla" & MenuOptionsId & """ class='invisible'>"))
                If Session("RolName") <> "Lector" Then
                    Cell.Controls.Add(New LiteralControl("<input id=""btnInputbox" & MenuOptionsId & """ type=""button"" value=""Actualizar Descripción del Requisito"" class=""boxceleste"" onclick=""UpdateDescripcionRequisito(" & MenuOptionsId & ")"" />"))
                End If
                PanelScroll = New Panel
                PanelScroll.ID = "panel" & MenuOptionsId
                PanelScroll.ClientIDMode = UI.ClientIDMode.Static
                PanelScroll.ScrollBars = ScrollBars.Auto
                PanelScroll.Height = "100"
                txtTextBox = New TextBox
                txtTextBox.ID = "txtRequisito" & MenuOptionsId
                txtTextBox.ClientIDMode = ClientIDMode.Static
                txtTextBox.CssClass = "tab_contenido"
                txtTextBox.Style(HtmlTextWriterStyle.Width) = "695"
                txtTextBox.TextMode = 1
                txtTextBox.Height = "90"
                txtTextBox.Width = "695"
                txtTextBox.ToolTip = "Descripción del requisito " & TituloPagina
                txtTextBox.Enabled = True
                txtTextBox.Text = MenuOptions.DescripcionDelRequisito(MenuOptionsId)
                PanelScroll.Controls.Add(txtTextBox)
                Cell.Controls.Add(PanelScroll)
                Cell.Controls.Add(New LiteralControl("</div>"))
                Row.Cells.Add(Cell)
                MyTable.Rows.Add(Row)


        End Select


        'Botones de busqueda y para agregar un nuevo registro de comunas

        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "tab_contenido"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        NewButton = New Button
        NewButton.ID = "newButton"
        NewButton.CssClass = "boxceleste"
        NewButton.Style(HtmlTextWriterStyle.Width) = "80px"
        NewButton.Text = "Nuevo"
        NewButton.ToolTip = "Presione para crear un nuevo registro"
        NewButton.Visible = False
        AddHandler NewButton.Click, AddressOf RFC_New
        Cell.Controls.Add(NewButton)
        Cell.Controls.Add(New LiteralControl(" "))

        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        Select Case OpcionMenu
            Case "Política", "Formulario", "API"
                sSQL = "SELECT DISTINCT DocumentosSGI.DocumentosSGIArea As NombreGrupo, Areas.AreasSecuencia As Grupo "
                sSQL = sSQL & "FROM DocumentosSGI INNER JOIN Areas ON DocumentosSGI.DocumentosSGIArea = Areas.AreasName "
                sSQL = sSQL & "GROUP BY DocumentosSGI.DocumentosSGIArea, Areas.AreasSecuencia, DocumentosSGI.DocumentosSGITipo "
                sSQL = sSQL & "HAVING (((DocumentosSGI.DocumentosSGITipo)='" & OpcionMenu & "')) "
                sSQL = sSQL & "ORDER BY Areas.AreasSecuencia"
            Case "Normativa Interna"
                sSQL = "SELECT DISTINCT DocumentosSGI.DocumentosSGITipo AS NombreGrupo, TipoDoc.TipoDocSecuencia AS Grupo "
                sSQL = sSQL & "FROM (DocumentosSGI INNER JOIN TipoDoc ON DocumentosSGI.DocumentosSGITipo = TipoDoc.TipoDocName) INNER JOIN Areas ON DocumentosSGI.DocumentosSGIArea = Areas.AreasName "
                sSQL = sSQL & "GROUP BY DocumentosSGI.DocumentosSGITipo, TipoDoc.TipoDocSecuencia, DocumentosSGI.DocumentosSGIArea, Areas.AreasGrupo "
                sSQL = sSQL & "HAVING (((DocumentosSGI.DocumentosSGITipo)='Norma Corporativa' Or (DocumentosSGI.DocumentosSGITipo)='Directriz Corporativa' Or (DocumentosSGI.DocumentosSGITipo)='Estándar Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Manual' Or (DocumentosSGI.DocumentosSGITipo)='Guía de Buenas Prácticas' Or (DocumentosSGI.DocumentosSGITipo)='Plan' Or (DocumentosSGI.DocumentosSGITipo)='Reglamento' Or (DocumentosSGI.DocumentosSGITipo)='Manual Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Reglamento Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Procedimiento Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Instructivo') AND ((Areas.AreasGrupo)='Corporativo')) "
                sSQL = sSQL & "ORDER BY TipoDoc.TipoDocSecuencia"
            Case "Procedimientos e Instructivos VP"
                sSQL = "SELECT DISTINCT DocumentosSGI.DocumentosSGIArea AS NombreGrupo, Areas.AreasDescription AS Grupo "
                sSQL = sSQL & "FROM DocumentosSGI INNER JOIN Areas ON DocumentosSGI.DocumentosSGIArea = Areas.AreasName Where Areas.AreasGrupo = 'VP' "
                sSQL = sSQL & "GROUP BY DocumentosSGI.DocumentosSGIArea, Areas.AreasDescription, DocumentosSGI.DocumentosSGITipo, Areas.AreasGrupo  "
                sSQL = sSQL & "HAVING (DocumentosSGI.DocumentosSGITipo)='Norma Corporativa' Or (DocumentosSGI.DocumentosSGITipo)='Directriz Corporativa' Or (DocumentosSGI.DocumentosSGITipo)='Estándar Corporativo' Or "
                sSQL = sSQL & "(DocumentosSGI.DocumentosSGITipo)='Manual' Or (DocumentosSGI.DocumentosSGITipo)='Guía de Buenas Prácticas' Or (DocumentosSGI.DocumentosSGITipo)='Plan' Or (DocumentosSGI.DocumentosSGITipo)='Reglamento' Or (DocumentosSGI.DocumentosSGITipo)='Manual Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Reglamento Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Procedimiento Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Instructivo' Or "
                sSQL = sSQL & "(DocumentosSGI.DocumentosSGITipo)='Bases para Aseguramiento de la Calidad' Or (DocumentosSGI.DocumentosSGITipo)='Bases para la Gestión Documental' Or (DocumentosSGI.DocumentosSGITipo)='Criterio de Diseño' Or (DocumentosSGI.DocumentosSGITipo)='Criterio de Diseño Civil' Or (DocumentosSGI.DocumentosSGITipo)='Criterio de Diseño Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Criterio de Diseño de Ergonomía' Or (DocumentosSGI.DocumentosSGITipo)='Criterio de Diseño Hidráulico Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Data Sheet' Or "
                sSQL = sSQL & "(DocumentosSGI.DocumentosSGITipo)='Especificación Técnica' Or (DocumentosSGI.DocumentosSGITipo)='Especificación Técnica Civil' Or (DocumentosSGI.DocumentosSGITipo)='Especificación Técnica Corporativa' Or (DocumentosSGI.DocumentosSGITipo)='Estándar Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Estándar de Ingenieria' Or (DocumentosSGI.DocumentosSGITipo)='Estándares Eléctricos' Or (DocumentosSGI.DocumentosSGITipo)='Hoja de Datos' Or (DocumentosSGI.DocumentosSGITipo)='Hoja de Datos Corporativa' Or "
                sSQL = sSQL & "(DocumentosSGI.DocumentosSGITipo)='Hoja de Datos Corporativa' Or (DocumentosSGI.DocumentosSGITipo)='Informe' Or (DocumentosSGI.DocumentosSGITipo)='Manual de Usuario' Or (DocumentosSGI.DocumentosSGITipo)='Mínimo Estándar' Or (DocumentosSGI.DocumentosSGITipo)='Criterio de Diseño Corporativo Civil' Or (DocumentosSGI.DocumentosSGITipo)='Procedimiento' Or (DocumentosSGI.DocumentosSGITipo)='Procedimiento Eléctrico Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Protocolo Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Technical Specification' AND "
                sSQL = sSQL & "(Areas.AreasGrupo)='VP' "
                sSQL = sSQL & "ORDER BY Areas.AreasDescription"
            Case "Procedimientos e Instructivos DET"
                sSQL = "SELECT DISTINCT DocumentosSGI.DocumentosSGIArea AS NombreGrupo, Areas.AreasDescription AS Grupo "
                sSQL = sSQL & "FROM DocumentosSGI INNER JOIN Areas ON DocumentosSGI.DocumentosSGIArea = Areas.AreasName Where Areas.AreasGrupo = 'DET' "
                sSQL = sSQL & "GROUP BY DocumentosSGI.DocumentosSGIArea, Areas.AreasDescription, DocumentosSGI.DocumentosSGITipo, Areas.AreasGrupo  "
                sSQL = sSQL & "HAVING (((DocumentosSGI.DocumentosSGITipo)='Norma Corporativa' Or (DocumentosSGI.DocumentosSGITipo)='Directriz Corporativa' Or (DocumentosSGI.DocumentosSGITipo)='Estándar Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Manual' Or (DocumentosSGI.DocumentosSGITipo)='Guía de Buenas Prácticas' Or (DocumentosSGI.DocumentosSGITipo)='Plan' Or (DocumentosSGI.DocumentosSGITipo)='Reglamento' Or (DocumentosSGI.DocumentosSGITipo)='Manual Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Reglamento Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Procedimiento Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Instructivo') AND ((Areas.AreasGrupo)='DET')) "
                sSQL = sSQL & "ORDER BY Areas.AreasDescription"
            Case "Marco Regulatorio Legislación Externa"
                sSQL = "SELECT DISTINCT DocumentosSGI.DocumentosSGIArea AS NombreGrupo, Areas.AreasDescription AS Grupo "
                sSQL = sSQL & "FROM DocumentosSGI INNER JOIN Areas ON DocumentosSGI.DocumentosSGIArea = Areas.AreasName "
                sSQL = sSQL & "GROUP BY DocumentosSGI.DocumentosSGIArea, Areas.AreasDescription, DocumentosSGI.DocumentosSGITipo "
                sSQL = sSQL & "HAVING ((DocumentosSGI.DocumentosSGITipo)='Decreto' OR (DocumentosSGI.DocumentosSGITipo)='DFL' Or (DocumentosSGI.DocumentosSGITipo)='Decreto de Ley' Or (DocumentosSGI.DocumentosSGITipo)='Decreto Supremo' Or (DocumentosSGI.DocumentosSGITipo)='Ley' Or (DocumentosSGI.DocumentosSGITipo)='Resolución') "
                sSQL = sSQL & "ORDER BY Areas.AreasDescription"
            Case "Lista de Documentos"
                sSQL = "SELECT DISTINCT DocumentosSGI.DocumentosSGITipo AS NombreGrupo, TipoDoc.TipoDocSecuencia AS Grupo "
                sSQL = sSQL & "FROM DocumentosSGI INNER JOIN TipoDoc ON DocumentosSGI.DocumentosSGITipo = TipoDoc.TipoDocName "
                sSQL = sSQL & Request.QueryString("sSQLWhere") & " "
                sSQL = sSQL & "GROUP BY DocumentosSGI.DocumentosSGITipo, TipoDoc.TipoDocSecuencia, DocumentosSGI.DocumentosSGIArea "
                sSQL = sSQL & "ORDER BY TipoDoc.TipoDocSecuencia"
            Case Else
                sSQL = "SELECT DISTINCT APIDocumentosSGI.GruposName AS NombreGrupo, APIDocumentosSGI.GruposSecuencia AS Grupo "
                sSQL = sSQL & "FROM (APIDocumentosSGI) "
                'sSQL = sSQL & "WHERE(((APIDocumentosSGI.APIDocumentosSGICodigo) = '" & OpcionMenu & "')) "
                sSQL = sSQL & "WHERE(((APIDocumentosSGI.MenuOptionsId) = " & MenuOptionsId & ")) "
                sSQL = sSQL & "GROUP BY APIDocumentosSGI.GruposName, APIDocumentosSGI.GruposSecuencia, APIDocumentosSGI.GruposSecuencia "
                sSQL = sSQL & "ORDER BY APIDocumentosSGI.GruposSecuencia"
        End Select

        Dim NGrillas As Integer = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                NGrillas = NGrillas + 1

                Select Case OpcionMenu
                    Case "Política", "Formulario", "API"
                        CreateTable(NumeroPagina, TituloPagina, OpcionMenu, dtr("Grupo"), NGrillas, dtr("NombreGrupo"), Areas.LeerAreasDescriptionByName(dtr("NombreGrupo")))
                    Case "Marco Regulatorio Legislación Externa"
                        CreateTable(NumeroPagina, TituloPagina, OpcionMenu, NGrillas, NGrillas, dtr("NombreGrupo"), Areas.LeerAreasDescriptionByName(dtr("NombreGrupo")))
                    Case "Procedimientos e Instructivos VP", "Procedimientos e Instructivos DET"
                        CreateTable(NumeroPagina, TituloPagina, OpcionMenu, NGrillas, NGrillas, dtr("NombreGrupo"), Areas.LeerAreasDescriptionByName(dtr("NombreGrupo")))
                    Case Else
                        CreateTable(NumeroPagina, TituloPagina, OpcionMenu, dtr("Grupo"), NGrillas, dtr("NombreGrupo"), TipoDoc.LeerTipoDocDescriptionByName(dtr("NombreGrupo")))
                End Select

            End While
        Catch

        End Try


        Select Case OpcionMenu
            Case "Política", "Formulario", "API"

            Case "Normativa Interna"

            Case "Procedimientos e Instructivos VP", "Procedimientos e Instructivos DET"

            Case "Marco Regulatorio Legislación Externa"

            Case "Lista de Documentos"

            Case Else
                If MenuOptionsPId <> 0 Then
                    If (Not cs.IsStartupScriptRegistered(cstype, csName1)) Then

                        Dim cstext1 As String = "aparecer('sub" & MenuOptionsPId & "');"
                        cs.RegisterStartupScript(cstype, csName1, cstext1, True)
                    End If
                End If
        End Select





    End Sub
    Sub CreateTable(ByVal NumeroPagina As Long, ByVal TituloPagina As String, ByVal OpcionMenu As String, ByVal Grupo As Long, ByVal NGrillas As Integer, ByVal NombreGrupo As String, ByVal DescripcionGrupo As String)
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Boolean = False
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim arrLabel(21) As String
        Dim arrControl(21) As String
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


        Dim sqlSource As AccessDataSource
        Dim Grilla As GridView
        Dim sSQL As String = ""
        Dim HTMLCode As String = ""
        Dim HyperColumnGrid As HyperLinkField
        Dim ItemTempColumnGrid As TemplateField
        Dim PanelScroll As Panel


        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQLCount As String = ""
        Dim TotalRegistros As Integer = 0


        Select Case OpcionMenu
            Case "Normativa Interna"
                sSQL = "SELECT Count(*) as Total "
                sSQL = sSQL & "FROM DocumentosSGI INNER JOIN Areas ON DocumentosSGI.DocumentosSGIArea = Areas.AreasName "
                sSQL = sSQL & "WHERE (((DocumentosSGI.DocumentosSGITipo)='" & NombreGrupo & "') AND ((Areas.AreasGrupo)='Corporativo'))"
            Case "Procedimientos e Instructivos VP"
                sSQL = "SELECT Count(*) as Total "
                sSQL = sSQL & "FROM DocumentosSGI INNER JOIN Areas ON DocumentosSGI.DocumentosSGIArea = Areas.AreasName "
                sSQL = sSQL & "WHERE (((DocumentosSGI.DocumentosSGIArea)='" & NombreGrupo & "') AND ((Areas.AreasGrupo)='VP'))"
            Case "Procedimientos e Instructivos DET"
                sSQL = "SELECT Count(*) as Total "
                sSQL = sSQL & "FROM DocumentosSGI INNER JOIN Areas ON DocumentosSGI.DocumentosSGIArea = Areas.AreasName "
                sSQL = sSQL & "WHERE (((DocumentosSGI.DocumentosSGIArea)='" & NombreGrupo & "') AND ((Areas.AreasGrupo)='DET'))"
            Case "Lista de Documentos"
                sSQL = "SELECT Count(*) as Total "
                sSQL = sSQL & "FROM DocumentosSGI "
                sSQL = sSQL & Request.QueryString("sSQLWhere") & " AND " & "(((DocumentosSGI.DocumentosSGITipo) = '" & NombreGrupo & "')) "
            Case "Marco Regulatorio Legislación Externa"
                sSQL = "SELECT Count(*) as Total "
                sSQL = sSQL & "FROM DocumentosSGI "
                sSQL = sSQL & "WHERE(((DocumentosSGI.DocumentosSGIArea) = '" & NombreGrupo & "')) "
            Case "Política", "Formulario", "API"
                sSQL = "SELECT Count(*) as Total "
                sSQL = sSQL & "FROM DocumentosSGI "
                sSQL = sSQL & "WHERE(((DocumentosSGI.DocumentosSGITipo) = '" & OpcionMenu & "') And ((DocumentosSGI.DocumentosSGIArea) = '" & NombreGrupo & "')) "
            Case Else
                sSQL = "SELECT Count(*) as Total "
                sSQL = sSQL & "FROM APIDocumentosSGI LEFT JOIN DocumentosSGI ON APIDocumentosSGI.DocumentosSGICodigo = DocumentosSGI.DocumentosSGICodigo "
                'sSQL = sSQL & "WHERE(((APIDocumentosSGI.APIDocumentosSGICodigo) = '" & OpcionMenu & "') And ((APIDocumentosSGI.GruposName) = '" & NombreGrupo & "')) "
                sSQL = sSQL & "WHERE(((APIDocumentosSGI.MenuOptionsId) = " & Request.QueryString("MenuOptionsId") & ") And ((APIDocumentosSGI.GruposName) = '" & NombreGrupo & "')) "
        End Select

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TotalRegistros = CInt(dtr("Total").ToString)
            End While
            dtr.Close()
            sSQL = ""
        Catch

        End Try

        TotalRegistros = (TotalRegistros + 1) * 35 + 15
        If TotalRegistros > 250 Then TotalRegistros = 250

        Row = New TableRow
        Cell = New TableCell

        Cell.Controls.Add(New LiteralControl("<br /><img src='img/flecha_naranja.gif' width='10' height='10'/><a class='linkmenu' onclick='aparecer(""subgrilla" & NGrillas & """)' ><span class='subtit'>" & DescripcionGrupo & "</span></a>"))
        If NGrillas = 1 Then
            Cell.Controls.Add(New LiteralControl("<div id=""subgrilla" & NGrillas & """ class='invisible'>"))
        Else
            Cell.Controls.Add(New LiteralControl("<div id=""subgrilla" & NGrillas & """ class='invisible'>"))
        End If

        'Columnas del Formulario
        i = 0
        t = Lecturas.LeerColumnasFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        PanelScroll = New Panel
        PanelScroll.ID = "panel" & NGrillas
        PanelScroll.ClientIDMode = UI.ClientIDMode.Static
        PanelScroll.ScrollBars = ScrollBars.Auto
        PanelScroll.Height = TotalRegistros

        Grilla = New GridView
        Grilla.ID = "grid1" & NGrillas
        Grilla.DataSourceID = "ds1" & NGrillas
        Grilla.DataKeyNames = New String(0) {"Id"}
        Grilla.HeaderStyle.CssClass = "grilla_top"
        Grilla.RowStyle.CssClass = "grilla_Fila1"
        Grilla.AlternatingRowStyle.CssClass = "grilla_Fila2"
        Grilla.FooterStyle.CssClass = "grilla_top"
        Grilla.PagerStyle.CssClass = "grilla_top"
        Grilla.CssClass = "tabla_grilla"

        Grilla.Width = "700"
        Grilla.AllowPaging = False
        Grilla.AllowSorting = True
        'Grilla.PageSize = 30
        Grilla.AutoGenerateColumns = False
        'Grilla.Caption = DescripcionGrupo
        'Grilla.CaptionAlign = TableCaptionAlign.Top


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
                    HyperColumnGrid.HeaderImageUrl = "img/botones/i_solicitar.gif"
                    HyperColumnGrid.Visible = False
                    Grilla.Columns.Add(HyperColumnGrid)
                    ItemTempColumnGrid = New TemplateField
                    ItemTempColumnGrid.ShowHeader = True
                    'ItemTempColumnGrid.HeaderText = arrLabel(k)
                    ItemTempColumnGrid.HeaderImageUrl = "img/botones/i_solicitar.gif"
                    ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                    ItemTempColumnGrid.ItemTemplate = New PlantillaImageGrilla(DataControlRowType.DataRow, New String(0) {arrControl(k)}, SelectCommand, "img/botones/i_solicitar.gif")
                    ItemTempColumnGrid.Visible = True
                    If Session("RolName") = "Lector" Then ItemTempColumnGrid.Visible = False
                    Grilla.Columns.Add(ItemTempColumnGrid)
                Case "DeleteField"
                    HyperColumnGrid = New HyperLinkField
                    HyperColumnGrid.DataTextField = arrControl(k)
                    HyperColumnGrid.ShowHeader = True
                    HyperColumnGrid.HeaderText = arrLabel(k)
                    HyperColumnGrid.DataNavigateUrlFields = New String(0) {arrControl(k)}
                    HyperColumnGrid.DataNavigateUrlFormatString = SelectCommand
                    HyperColumnGrid.ItemStyle.Width = ControlWidth
                    HyperColumnGrid.HeaderImageUrl = "img/botones/b_eliminar.png"
                    HyperColumnGrid.Visible = False
                    Grilla.Columns.Add(HyperColumnGrid)
                    ItemTempColumnGrid = New TemplateField
                    ItemTempColumnGrid.ShowHeader = True
                    'ItemTempColumnGrid.HeaderText = arrLabel(k)
                    ItemTempColumnGrid.HeaderImageUrl = "img/botones/b_eliminar.png"
                    ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                    ItemTempColumnGrid.ItemTemplate = New PlantillaImageGrilla(DataControlRowType.DataRow, New String(0) {arrControl(k)}, SelectCommand, "img/botones/b_eliminar.png")
                    ItemTempColumnGrid.Visible = True
                    If Session("RolName") = "Lector" Then ItemTempColumnGrid.Visible = False
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
                Case "TemplateField"
                    ItemTempColumnGrid = New TemplateField
                    ItemTempColumnGrid.ShowHeader = True
                    If (OpcionMenu = "Procedimientos e Instructivos VP" Or OpcionMenu = "Procedimientos e Instructivos DET" Or OpcionMenu = "Marco Regulatorio Legislación Externa") And arrLabel(k) = "Emisor" Then
                        ItemTempColumnGrid.HeaderText = "Tipo_Doc"
                    Else
                        ItemTempColumnGrid.HeaderText = arrLabel(k)
                    End If

                    ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                    ItemTempColumnGrid.ItemTemplate = New PlantillaGrilla(DataControlRowType.DataRow, New String(0) {arrControl(k)})
                    Grilla.Columns.Add(ItemTempColumnGrid)
            End Select
        Next

        PanelScroll.Controls.Add(Grilla)
        Cell.Controls.Add(PanelScroll)
        'Cell.Controls.Add(Grilla)
        Cell.Controls.Add(New LiteralControl("</div>"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "txt_label"
        Cell.ColumnSpan = "2"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "right"
        sqlSource = New AccessDataSource
        sqlSource.ID = "ds1" & NGrillas
        Select Case OpcionMenu
            Case "Normativa Interna"
                sSQL = "SELECT DocumentosSGI.DocumentosSGIId AS Id, DocumentosSGI.DocumentosSGICodigo AS Código, Mid(DocumentosSGI.DocumentosSGIFEmision,1.1) AS Emisión, DocumentosSGI.DocumentosSGIFRevision AS Rev, DocumentosSGI.DocumentosSGINombre AS Título, DocumentosSGI.DocumentosSGIArea AS Emisor, DocumentosSGI.DocumentosSGIOrigen AS C_Externo, 'SGI\'+DocumentosSGI.DocumentosSGIPath AS Url, Areas.AreasGrupo "
                sSQL = sSQL & "FROM DocumentosSGI INNER JOIN Areas ON DocumentosSGI.DocumentosSGIArea = Areas.AreasName "
                sSQL = sSQL & "WHERE (((DocumentosSGI.DocumentosSGITipo)='" & NombreGrupo & "') AND ((Areas.AreasGrupo)='Corporativo')) "
                sSQL = sSQL & "ORDER BY DocumentosSGI.DocumentosSGIArea, DocumentosSGI.DocumentosSGICodigo"
            Case "Procedimientos e Instructivos VP"
                sSQL = "SELECT DocumentosSGI.DocumentosSGIId AS Id, DocumentosSGI.DocumentosSGICodigo AS Código, Mid(DocumentosSGI.DocumentosSGIFEmision,1.1) AS Emisión, DocumentosSGI.DocumentosSGIFRevision AS Rev, DocumentosSGI.DocumentosSGINombre AS Título, DocumentosSGI.DocumentosSGITipo AS Emisor, DocumentosSGI.DocumentosSGIOrigen AS C_Externo, 'SGI\'+DocumentosSGI.DocumentosSGIPath AS Url, Areas.AreasGrupo "
                sSQL = sSQL & "FROM DocumentosSGI INNER JOIN Areas ON DocumentosSGI.DocumentosSGIArea = Areas.AreasName "
                sSQL = sSQL & "WHERE (DocumentosSGI.DocumentosSGIArea)='" & NombreGrupo & "' AND (Areas.AreasGrupo)='VP' AND (DocumentosSGI.DocumentosSGITipo)='Norma Corporativa' Or (DocumentosSGI.DocumentosSGITipo)='Manual Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Reglamento Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Directriz Corporativa' Or (DocumentosSGI.DocumentosSGITipo)='Estándar Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Manual' Or (DocumentosSGI.DocumentosSGITipo)='Guía de Buenas Prácticas' Or (DocumentosSGI.DocumentosSGITipo)='Plan' Or (DocumentosSGI.DocumentosSGITipo)='Reglamento' Or (DocumentosSGI.DocumentosSGITipo)='Procedimiento Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Instructivo' "
                sSQL = sSQL & "Or (DocumentosSGI.DocumentosSGITipo)='Bases para Aseguramiento de la Calidad' Or (DocumentosSGI.DocumentosSGITipo)='Bases para la Gestión Documental' Or (DocumentosSGI.DocumentosSGITipo)='Criterio de Diseño' Or (DocumentosSGI.DocumentosSGITipo)='Criterio de Diseño Civil' Or (DocumentosSGI.DocumentosSGITipo)='Criterio de Diseño Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Criterio de Diseño de Ergonomía' Or (DocumentosSGI.DocumentosSGITipo)='Criterio de Diseño Hidráulico Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Data Sheet' "
                sSQL = sSQL & "Or (DocumentosSGI.DocumentosSGITipo)='Especificación Técnica' Or (DocumentosSGI.DocumentosSGITipo)='Especificación Técnica Civil' Or (DocumentosSGI.DocumentosSGITipo)='Especificación Técnica Corporativa' Or (DocumentosSGI.DocumentosSGITipo)='Estándar Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Estándar de Ingenieria' Or (DocumentosSGI.DocumentosSGITipo)='Estándares Eléctricos' Or (DocumentosSGI.DocumentosSGITipo)='Hoja de Datos' Or (DocumentosSGI.DocumentosSGITipo)='Hoja de Datos Corporativa' "
                sSQL = sSQL & "Or (DocumentosSGI.DocumentosSGITipo)='Hoja de Datos Corporativa' Or (DocumentosSGI.DocumentosSGITipo)='Informe' Or (DocumentosSGI.DocumentosSGITipo)='Manual de Usuario' Or (DocumentosSGI.DocumentosSGITipo)='Mínimo Estándar' Or (DocumentosSGI.DocumentosSGITipo)='Criterio de Diseño Corporativo Civil' Or (DocumentosSGI.DocumentosSGITipo)='Procedimiento' Or (DocumentosSGI.DocumentosSGITipo)='Procedimiento Eléctrico Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Protocolo Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Technical Specification' "
                sSQL = sSQL & "ORDER BY DocumentosSGI.DocumentosSGITipo, DocumentosSGI.DocumentosSGICodigo"
            Case "Procedimientos e Instructivos DET"
                sSQL = "SELECT DocumentosSGI.DocumentosSGIId AS Id, DocumentosSGI.DocumentosSGICodigo AS Código, Mid(DocumentosSGI.DocumentosSGIFEmision,1.1) AS Emisión, DocumentosSGI.DocumentosSGIFRevision AS Rev, DocumentosSGI.DocumentosSGINombre AS Título, DocumentosSGI.DocumentosSGITipo AS Emisor, DocumentosSGI.DocumentosSGIOrigen AS C_Externo, 'SGI\'+DocumentosSGI.DocumentosSGIPath AS Url, Areas.AreasGrupo "
                sSQL = sSQL & "FROM DocumentosSGI INNER JOIN Areas ON DocumentosSGI.DocumentosSGIArea = Areas.AreasName "
                sSQL = sSQL & "WHERE ((DocumentosSGI.DocumentosSGIArea)='" & NombreGrupo & "') AND (((DocumentosSGI.DocumentosSGITipo)='Norma Corporativa' Or (DocumentosSGI.DocumentosSGITipo)='Manual Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Reglamento Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Directriz Corporativa' Or (DocumentosSGI.DocumentosSGITipo)='Estándar Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Manual' Or (DocumentosSGI.DocumentosSGITipo)='Guía de Buenas Prácticas' Or (DocumentosSGI.DocumentosSGITipo)='Plan' Or (DocumentosSGI.DocumentosSGITipo)='Reglamento' Or (DocumentosSGI.DocumentosSGITipo)='Procedimiento Corporativo' Or (DocumentosSGI.DocumentosSGITipo)='Instructivo') AND ((Areas.AreasGrupo)='DET')) "
                sSQL = sSQL & "ORDER BY DocumentosSGI.DocumentosSGITipo, DocumentosSGI.DocumentosSGICodigo"
            Case "Lista de Documentos"
                sSQL = "SELECT DocumentosSGI.DocumentosSGIId as Id, DocumentosSGI.DocumentosSGICodigo as Código, Mid(DocumentosSGI.DocumentosSGIFEmision,1,10) as Emisión, DocumentosSGI.DocumentosSGIFRevision As Rev, DocumentosSGI.DocumentosSGINombre As Título, DocumentosSGI.DocumentosSGIArea As Emisor, DocumentosSGI.DocumentosSGIOrigen As C_Externo, 'SGI\' + DocumentosSGI.DocumentosSGIPath as Url  "
                sSQL = sSQL & "FROM DocumentosSGI "
                sSQL = sSQL & Request.QueryString("sSQLWhere") & " AND " & "(((DocumentosSGI.DocumentosSGITipo) = '" & NombreGrupo & "')) "
                sSQL = sSQL & "ORDER BY DocumentosSGI.DocumentosSGICodigo"
            Case "Marco Regulatorio Legislación Externa"
                sSQL = "SELECT DocumentosSGI.DocumentosSGIId as Id, DocumentosSGI.DocumentosSGICodigo as Código, Mid(DocumentosSGI.DocumentosSGIFEmision,1,10) as Emisión, DocumentosSGI.DocumentosSGIFRevision As Rev, DocumentosSGI.DocumentosSGINombre As Título, DocumentosSGI.DocumentosSGITipo As Emisor, DocumentosSGI.DocumentosSGIOrigen As C_Externo, 'SGI\' + DocumentosSGI.DocumentosSGIPath as Url  "
                sSQL = sSQL & "FROM DocumentosSGI "
                sSQL = sSQL & "WHERE(((DocumentosSGI.DocumentosSGIArea) = '" & NombreGrupo & "')) "
                sSQL = sSQL & "ORDER BY DocumentosSGI.DocumentosSGITipo, DocumentosSGI.DocumentosSGICodigo"
            Case "Política", "Formulario", "API"
                sSQL = "SELECT DocumentosSGI.DocumentosSGIId as Id, DocumentosSGI.DocumentosSGICodigo as Código, Mid(DocumentosSGI.DocumentosSGIFEmision,1,10) as Emisión, DocumentosSGI.DocumentosSGIFRevision As Rev, DocumentosSGI.DocumentosSGINombre As Título, DocumentosSGI.DocumentosSGIArea As Emisor, DocumentosSGI.DocumentosSGIOrigen As C_Externo, 'SGI\' + DocumentosSGI.DocumentosSGIPath as Url  "
                sSQL = sSQL & "FROM DocumentosSGI "
                sSQL = sSQL & "WHERE(((DocumentosSGI.DocumentosSGITipo) = '" & OpcionMenu & "') And ((DocumentosSGI.DocumentosSGIArea) = '" & NombreGrupo & "')) "
                sSQL = sSQL & "ORDER BY DocumentosSGI.DocumentosSGICodigo"
            Case Else
                sSQL = "SELECT DocumentosSGI.DocumentosSGIId as Id, APIDocumentosSGI.DocumentosSGICodigo as Código, Mid(DocumentosSGI.DocumentosSGIFEmision,1,10) as Emisión, DocumentosSGI.DocumentosSGIFRevision As Rev, DocumentosSGI.DocumentosSGINombre As Título, DocumentosSGI.DocumentosSGIArea As Emisor, DocumentosSGI.DocumentosSGIOrigen As C_Externo, 'SGI\' + DocumentosSGI.DocumentosSGIPath as Url  "
                sSQL = sSQL & "FROM APIDocumentosSGI LEFT JOIN DocumentosSGI ON APIDocumentosSGI.DocumentosSGICodigo = DocumentosSGI.DocumentosSGICodigo "
                'sSQL = sSQL & "WHERE(((APIDocumentosSGI.APIDocumentosSGICodigo) = '" & OpcionMenu & "') And ((APIDocumentosSGI.GruposName) = '" & NombreGrupo & "')) "
                sSQL = sSQL & "WHERE(((APIDocumentosSGI.MenuOptionsId) = " & Request.QueryString("MenuOptionsId") & ") And ((APIDocumentosSGI.GruposName) = '" & NombreGrupo & "')) "
                sSQL = sSQL & "ORDER BY APIDocumentosSGI.DocumentosSGICodigo"
        End Select
        t = Lecturas.LeerSQLStatementFormularioWeb("SQLSelect", DataFile, SelectCommand, NumeroPagina)
        sqlSource.DataFile = DataFile
        sqlSource.SelectCommand = sSQL
        Cell.Controls.Add(sqlSource)
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

    End Sub

End Class
