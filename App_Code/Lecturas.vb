Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Lecturas
    Public Function LoadOpcionesDelMenu(ByRef rptFunciones As Repeater, ByVal Clasificacion As String) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Class, href, title, texto "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE Class = '" & Clasificacion & "' "
        sSQL = sSQL & "ORDER by Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptFunciones.DataSource = dtrFunciones
            rptFunciones.DataBind()
            LoadOpcionesDelMenu = True
            dtrFunciones.Close()
        Catch
            LoadOpcionesDelMenu = False
        End Try
    End Function
    Public Function LoadOpcionesDelMenuSGI(ByRef rptFunciones As Repeater, ByVal Clasificacion As String, ByVal URLAdicional As String) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Class, href, title, texto "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE Class = '" & Clasificacion & "' "
        sSQL = sSQL & "ORDER by Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptFunciones.DataSource = dtrFunciones
            rptFunciones.DataBind()
            LoadOpcionesDelMenuSGI = True
            dtrFunciones.Close()
        Catch
            LoadOpcionesDelMenuSGI = False
        End Try
    End Function
    Public Function LoadOpcionesDelMenuSGIV2(ByRef rptFunciones As Repeater, ByVal Clasificacion As String, ByVal URLAdicional As String, ByVal RolId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT MenuOptions.[Class], MenuOptions.[href], MenuOptions.[title], MenuOptions.[Texto] "
        sSQL = sSQL & "FROM FuncionesPorRol INNER JOIN MenuOptions ON FuncionesPorRol.FuncionId = MenuOptions.MenuOptionsId "
        sSQL = sSQL & "WHERE(((FuncionesPorRol.RolId) = " & RolId & ") AND ((MenuOptions.Class) = '" & Clasificacion & "')) "
        sSQL = sSQL & "ORDER BY MenuOptions.Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptFunciones.DataSource = dtrFunciones
            rptFunciones.DataBind()
            LoadOpcionesDelMenuSGIV2 = True
            dtrFunciones.Close()
        Catch
            LoadOpcionesDelMenuSGIV2 = False
        End Try
    End Function


    Public Function LoadRaicesDelMenuAccordion(ByRef MyTable As PlaceHolder, ByVal Clasificacion As String, ByVal NodoId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim Tabla As Table
        Dim Fila As TableRow
        Dim Celda As TableCell
        Dim MenuOption As String = ""
        Dim t As Boolean
        Dim Espacios As String = ""


        sSQL = "SELECT MenuOptionsId, texto "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE Class = '" & Clasificacion & "' "
        sSQL = sSQL & "ORDER by Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read
                Tabla = New Table
                Tabla.ID = "TablaHeader" & dtrFunciones("MenuOptionsId")
                Tabla.ClientIDMode = UI.ClientIDMode.Static
                Tabla.CellSpacing = "0"
                Tabla.CellPadding = "0"
                Tabla.Width = "200"
                Fila = New TableRow
                Celda = New TableCell
                Celda.Style(HtmlTextWriterStyle.Height) = "29"
                Celda.Style(HtmlTextWriterStyle.Width) = "7px"
                Celda.Controls.Add(New LiteralControl("<img src='IMG/Menu_top_1.gif' width='7' height='29'/>"))
                Fila.Cells.Add(Celda)
                Celda = New TableCell
                Celda.CssClass = "c_menu_center"
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "center"
                Celda.Controls.Add(New LiteralControl(dtrFunciones("texto").ToString))
                Fila.Cells.Add(Celda)
                Celda = New TableCell
                Celda.Style(HtmlTextWriterStyle.Height) = "29"
                Celda.Style(HtmlTextWriterStyle.Width) = "6px"
                Celda.Controls.Add(New LiteralControl("<img src='IMG/Menu_r8_c10.gif' width='7' height='29'/>"))
                Fila.Cells.Add(Celda)
                Tabla.Rows.Add(Fila)
                MyTable.Controls.Add(Tabla)

                Tabla = New Table
                Tabla.ID = "TablaDetail" & dtrFunciones("MenuOptionsId")
                Tabla.ClientIDMode = UI.ClientIDMode.Static
                Tabla.CellSpacing = "0"
                Tabla.CellPadding = "0"
                Tabla.Width = "200"

                t = LoadOpcionesDelMenuAccordion(Tabla, CLng(dtrFunciones("MenuOptionsId").ToString), NodoId)

                MyTable.Controls.Add(Tabla)

            End While
            LoadRaicesDelMenuAccordion = True
            dtrFunciones.Close()
        Catch
            LoadRaicesDelMenuAccordion = False
        End Try

    End Function
    Public Function LoadOpcionesDelMenuAccordion(ByRef MyTable As Table, ByVal MenuOptionsPId As Long, ByVal NodoId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim MenuOption As String = ""
        Dim t As Boolean
        Dim Espacios As String = ""

        'Titulo
        Row = New TableRow
        Cell = New TableCell

        Cell.Controls.Add(New LiteralControl("<ul>"))

        sSQL = "SELECT MenuOptionsId, Class, href, title, texto, IsNodoHoja "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = " & MenuOptionsPId & " "
        sSQL = sSQL & "ORDER by Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)


            While dtrFunciones.Read
                If dtrFunciones("IsNodoHoja").ToString = "Hoja" Then
                    MenuOption = "<li class='celdaMenu'><a href='" & dtrFunciones("href").ToString & "' class='linkmenu'>" & dtrFunciones("texto").ToString & "</a></li>"
                    Cell.Controls.Add(New LiteralControl(MenuOption))
                Else
                    MenuOption = "<li class='celdaMenu'><img src='img/flecha_naranja.gif' width='10' height='10'/><a class='linkmenu' onclick='aparecer(""sub" & dtrFunciones("MenuOptionsId").ToString & """)'>" & dtrFunciones("texto").ToString & "</a>"
                    Cell.Controls.Add(New LiteralControl(MenuOption))
                    If CLng(dtrFunciones("MenuOptionsId").ToString) = NodoId Then
                        MenuOption = "<div id=""sub" & dtrFunciones("MenuOptionsId").ToString & """ class='visible'><ul>"
                    Else
                        MenuOption = "<div id=""sub" & dtrFunciones("MenuOptionsId").ToString & """ class='invisible'><ul>"
                    End If
                    Cell.Controls.Add(New LiteralControl(MenuOption))
                    Espacios = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                    t = LoadOpcionesDelSubMenuAccordion(Cell, CLng(dtrFunciones("MenuOptionsId").ToString), Espacios, NodoId)
                    MenuOption = "</ul></div></li>"
                    Cell.Controls.Add(New LiteralControl(MenuOption))
                End If
            End While
            LoadOpcionesDelMenuAccordion = True
            dtrFunciones.Close()
        Catch
            LoadOpcionesDelMenuAccordion = False
        End Try
        Cell.Controls.Add(New LiteralControl("</ul>"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)


    End Function
    Public Function LoadOpcionesDelSubMenuAccordion(ByRef MyCell As TableCell, ByVal MenuOptionsId As Long, ByRef Espacios As String, ByVal NodoId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim MenuOption As String = ""
        Dim t As Boolean

        sSQL = "SELECT MenuOptionsId, Class, href, title, texto, IsNodoHoja "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = " & MenuOptionsId
        sSQL = sSQL & " ORDER by Secuencia"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)


            While dtr.Read
                If dtr("IsNodoHoja").ToString = "Hoja" Then
                    MenuOption = "<li class='celdaMenuSGI'><a href='" & dtr("href").ToString & "' class='linksubmenu'>" & Espacios & dtr("texto").ToString & "</a></li>"
                    MyCell.Controls.Add(New LiteralControl(MenuOption))
                Else
                    MenuOption = "<li class='celdaMenu'><img src='img/flecha_naranja.gif' width='10' height='10'/><a class='linkmenu' onclick='aparecer(""sub" & dtr("MenuOptionsId").ToString & """)'>" & Espacios & dtr("texto").ToString & "</a>"
                    MyCell.Controls.Add(New LiteralControl(MenuOption))
                    If CLng(dtr("MenuOptionsId").ToString) = NodoId Then
                        MenuOption = "<div id=""sub" & dtr("MenuOptionsId").ToString & """ class='visible'><ul>"
                    Else
                        MenuOption = "<div id=""sub" & dtr("MenuOptionsId").ToString & """ class='invisible'><ul>"
                    End If
                    MyCell.Controls.Add(New LiteralControl(MenuOption))
                    t = LoadOpcionesDelSubMenuAccordion(MyCell, CLng(dtr("MenuOptionsId").ToString), Espacios & "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;", NodoId)
                    MenuOption = "</ul></div></li>"
                    MyCell.Controls.Add(New LiteralControl(MenuOption))
                End If
            End While
            LoadOpcionesDelSubMenuAccordion = True
            dtr.Close()
        Catch
            LoadOpcionesDelSubMenuAccordion = False
        End Try
    End Function
    Public Function IsNodoDelMenuAccordion(ByVal MenuOptionsId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT IsNodoHoja "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsId = " & MenuOptionsId & " AND IsNodoHoja = 'Nodo'"

        IsNodoDelMenuAccordion = False

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)
            While dtrFunciones.Read
                IsNodoDelMenuAccordion = True
                Return True
            End While
            dtrFunciones.Close()
        Catch
            IsNodoDelMenuAccordion = False
            Return False
        End Try

    End Function
    Public Function LoadOpcionesDelMenuPrivado(ByRef rptFunciones As Repeater, ByVal MenuOptionsPId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Class, href, title, texto "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = " & MenuOptionsPId & " "
        sSQL = sSQL & "ORDER by Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptFunciones.DataSource = dtrFunciones
            rptFunciones.DataBind()
            LoadOpcionesDelMenuPrivado = True
            dtrFunciones.Close()
        Catch
            LoadOpcionesDelMenuPrivado = False
        End Try
    End Function
    Public Function LoadOpcionesDelLeftBarMenu(ByRef rptFunciones As Repeater, ByVal MenuOptionPId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Class, href, title, texto "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = " & MenuOptionPId & " "
        sSQL = sSQL & "ORDER by Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptFunciones.DataSource = dtrFunciones
            rptFunciones.DataBind()
            LoadOpcionesDelLeftBarMenu = True
            dtrFunciones.Close()
        Catch
            LoadOpcionesDelLeftBarMenu = False
        End Try

    End Function
    Public Function LeerSchema(ByRef dgrdSchema As DataGrid, _
                               ByVal sSQL As String, _
                               ByRef arrLabel() As String, _
                               ByRef arrItem(,) As String, _
                               ByRef i As Integer, _
                               ByRef j As Integer) As Boolean

        Dim AccesoEA = New AccesoEA
        Dim dtr As IDataReader
        Dim dtrSchema As DataTable
        Dim dtrColumn As DataColumn
        Dim dtrItem As DataRow

        i = 0
        Try
            dtr = AccesoEA.ObtenerSchema(sSQL)
            dtrSchema = dtr.GetSchemaTable()

            'For i = 0 To dtrSchema.Columns.Count - 1
            'arrLabel(i) = dtrSchema.Columns(i).ColumnName.ToString() & " " & dtrSchema.Columns(i).DataType.ToString()
            'Next

            For Each dtrColumn In dtrSchema.Columns
                arrLabel(i) = dtrColumn.ColumnName

                j = 0
                For Each dtrItem In dtrSchema.Rows
                    arrItem(i, j) = dtrItem(dtrColumn).ToString
                    j = j + 1

                Next
                i = i + 1
            Next

            dgrdSchema.DataSource = dtrSchema
            dgrdSchema.DataBind()


            LeerSchema = True
            dtr.Close()
        Catch
            LeerSchema = False
        End Try

    End Function




    Public Function LoadEmpresasPorUsuario(ByRef rptFunciones As Repeater, ByVal PersonaId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "Select Empresa.EmpresaName As Empresa "
        sSQL = sSQL & "FROM Empresa INNER JOIN PersonasPorEmpresa ON Empresa.EmpresaId = PersonasPorEmpresa.EmpresaId "
        sSQL = sSQL & "WHERE(((PersonasPorEmpresa.PersonaId) = " & PersonaId & "))"


        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptFunciones.DataSource = dtrFunciones
            rptFunciones.DataBind()
            LoadEmpresasPorUsuario = True
            dtrFunciones.Close()
        Catch
            LoadEmpresasPorUsuario = False
        End Try
    End Function


    Public Function LoadMonedas(ByRef rptFunciones As Repeater) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT MonedaSimbolo as Moneda, MonedaValor as Valor "
        sSQL = sSQL & "FROM Monedas ORDER BY MonedaSecuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptFunciones.DataSource = dtrFunciones
            rptFunciones.DataBind()
            LoadMonedas = True
            dtrFunciones.Close()
        Catch
            LoadMonedas = False
        End Try
    End Function
    Public Function LoadEnlaces(ByRef rptFunciones As Repeater, ByVal PersonaId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "Select EnlacesURL, EnlacesNombre "
        sSQL = sSQL & "FROM Enlaces "
        sSQL = sSQL & "WHERE(((Enlaces.PersonaId) = " & PersonaId & ")) "
        sSQL = sSQL & "ORDER BY EnlacesSecuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptFunciones.DataSource = dtrFunciones
            rptFunciones.DataBind()
            LoadEnlaces = True
            dtrFunciones.Close()
        Catch
            LoadEnlaces = False
        End Try
    End Function
    Public Function CargarEnlaces(ByRef drpEnlaces As DropDownList) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "Select EnlacesNombre As Enlace "
        sSQL = sSQL & "FROM Enlaces "
        sSQL = sSQL & "WHERE(((Enlaces.PersonaId) = 1)) "
        sSQL = sSQL & "ORDER BY EnlacesSecuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            drpEnlaces.DataSource = dtrFunciones
            drpEnlaces.DataTextField = "Enlace"
            drpEnlaces.DataBind()
            CargarEnlaces = True
            dtrFunciones.Close()
        Catch
            CargarEnlaces = False
        End Try


    End Function


    Public Function LoadConsultas(ByRef rptFunciones As Repeater, ByVal Empresa As String) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Consulta.ConsultaId as Id, Consulta.ConsultaNombre As Nombre, Consulta.ConsultaObjetivo as Objetivo, Consulta.ConsultaClasificacion as Clasificacion "
        sSQL = sSQL & "FROM (Consulta INNER JOIN ConsultaPorEmpresa ON Consulta.ConsultaId = ConsultaPorEmpresa.ConsultaId) INNER JOIN Empresa ON ConsultaPorEmpresa.EmpresaId = Empresa.EmpresaId "
        sSQL = sSQL & "WHERE (((Empresa.EmpresaName)='" & Empresa & "')) "
        sSQL = sSQL & "ORDER BY Consulta.ConsultaClasificacion, Consulta.ConsultaSecuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptFunciones.DataSource = dtrFunciones
            rptFunciones.DataBind()
            LoadConsultas = True
            dtrFunciones.Close()
        Catch
            LoadConsultas = False
        End Try
    End Function
    Public Function LeerMaterialVuelo(ByRef ArrChartData() As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT MaterialVuelo.MaterialVueloCantidad as Cantidad, MaterialVuelo.MaterialVueloName as Material "
        sSQL = sSQL & "FROM MaterialVuelo "
        sSQL = sSQL & "ORDER BY MaterialVuelo.MaterialVueloArea, MaterialVuelo.MaterialVueloSecuencia"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("Material").ToString
                i = i + 1
            End While
            LeerMaterialVuelo = True
            dtr.Close()
        Catch
            LeerMaterialVuelo = False
        End Try
    End Function
    Public Function LeerMaterias(ByRef ArrChartData() As String, ByRef i As Integer, ByVal Grupo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Materias.MateriaName as Materia "
        sSQL = sSQL & "FROM Materias "
        sSQL = sSQL & "WHERE Materias.MateriaGrupo = '" & Grupo & "' ORDER BY MateriaSecuencia"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("Materia").ToString
                i = i + 1
            End While
            LeerMaterias = True
            dtr.Close()
        Catch
            LeerMaterias = False
        End Try
    End Function
    Public Function LeerMateriasTipo(ByVal Grupo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Materias.MateriaTipo as Tipo "
        sSQL = sSQL & "FROM Materias "
        sSQL = sSQL & "WHERE Materias.MateriaGrupo = '" & Grupo & "'"

        LeerMateriasTipo = "Porcentaje"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                LeerMateriasTipo = dtr("Tipo").ToString
            End While
            dtr.Close()
        Catch
            LeerMateriasTipo = "Porcentaje"
        End Try
    End Function
    Public Function MesActual(ByVal Materia As String) As Integer
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Materias.MateriaMesActual as MesActual "
        sSQL = sSQL & "FROM Materias "
        sSQL = sSQL & "WHERE Materias.MateriaName = '" & Materia & "'"

        MesActual = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                MesActual = CInt(dtr("MesActual").ToString)
            End While
            dtr.Close()
        Catch
            MesActual = 0
        End Try
    End Function
    Public Function MetaAnual(ByVal Materia As String) As Double
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Materias.MateriaMetaAnual as MetaAnual "
        sSQL = sSQL & "FROM Materias "
        sSQL = sSQL & "WHERE Materias.MateriaName = '" & Materia & "'"

        MetaAnual = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                MetaAnual = CDbl(dtr("MetaAnual").ToString)
            End While
            dtr.Close()
        Catch
            MetaAnual = 0
        End Try
    End Function
    Public Function LeerPorcentajesPorMaterias(ByRef ArrChartPorc() As Double, ByVal Materia As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Materias.MateriaPorc1 as Porc1, Materias.MateriaPorc2 as Porc2, Materias.MateriaPorc3 as Porc3, Materias.MateriaPorc4 as Porc4, Materias.MateriaPorc5 as Porc5, Materias.MateriaPorc6 as Porc6, Materias.MateriaPorc7 as Porc7, Materias.MateriaPorc8 as Porc8, Materias.MateriaPorc9 as Porc9, Materias.MateriaPorc10 as Porc10, Materias.MateriaPorc11 as Porc11, Materias.MateriaPorc12 as Porc12, Materias.MateriaPorcAnual as PorcAnual  "
        sSQL = sSQL & "FROM Materias "
        sSQL = sSQL & "WHERE Materias.MateriaName = '" & Materia & "'"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartPorc(0) = CDbl(dtr("Porc1").ToString)
                ArrChartPorc(1) = CDbl(dtr("Porc2").ToString)
                ArrChartPorc(2) = CDbl(dtr("Porc3").ToString)
                ArrChartPorc(3) = CDbl(dtr("Porc4").ToString)
                ArrChartPorc(4) = CDbl(dtr("Porc5").ToString)
                ArrChartPorc(5) = CDbl(dtr("Porc6").ToString)
                ArrChartPorc(6) = CDbl(dtr("Porc7").ToString)
                ArrChartPorc(7) = CDbl(dtr("Porc8").ToString)
                ArrChartPorc(8) = CDbl(dtr("Porc9").ToString)
                ArrChartPorc(9) = CDbl(dtr("Porc10").ToString)
                ArrChartPorc(10) = CDbl(dtr("Porc11").ToString)
                ArrChartPorc(11) = CDbl(dtr("Porc12").ToString)
                ArrChartPorc(12) = CDbl(dtr("PorcAnual").ToString)


            End While
            LeerPorcentajesPorMaterias = True
            dtr.Close()
        Catch
            LeerPorcentajesPorMaterias = False
        End Try
    End Function
    Public Function LeerValoresPorMaterias(ByRef ArrChartPorc() As Double, ByVal Materia As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Materias.MateriaValor1 as Valor1, Materias.MateriaValor2 as Valor2, Materias.MateriaValor3 as Valor3, Materias.MateriaValor4 as Valor4, Materias.MateriaValor5 as Valor5, Materias.MateriaValor6 as Valor6, Materias.MateriaValor7 as Valor7, Materias.MateriaValor8 as Valor8, Materias.MateriaValor9 as Valor9, Materias.MateriaValor10 as Valor10, Materias.MateriaValor11 as Valor11, Materias.MateriaValor12 as Valor12, Materias.MateriaValorAnual as ValorAnual  "
        sSQL = sSQL & "FROM Materias "
        sSQL = sSQL & "WHERE Materias.MateriaName = '" & Materia & "'"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartPorc(0) = CDbl(dtr("Valor1").ToString)
                ArrChartPorc(1) = CDbl(dtr("Valor2").ToString)
                ArrChartPorc(2) = CDbl(dtr("Valor3").ToString)
                ArrChartPorc(3) = CDbl(dtr("Valor4").ToString)
                ArrChartPorc(4) = CDbl(dtr("Valor5").ToString)
                ArrChartPorc(5) = CDbl(dtr("Valor6").ToString)
                ArrChartPorc(6) = CDbl(dtr("Valor7").ToString)
                ArrChartPorc(7) = CDbl(dtr("Valor8").ToString)
                ArrChartPorc(8) = CDbl(dtr("Valor9").ToString)
                ArrChartPorc(9) = CDbl(dtr("Valor10").ToString)
                ArrChartPorc(10) = CDbl(dtr("Valor11").ToString)
                ArrChartPorc(11) = CDbl(dtr("Valor12").ToString)
                ArrChartPorc(12) = CDbl(dtr("ValorAnual").ToString)


            End While
            LeerValoresPorMaterias = True
            dtr.Close()
        Catch
            LeerValoresPorMaterias = False
        End Try
    End Function
    Public Function LeerValoresAcumuladosPorMaterias(ByRef ArrChartPorc() As Double, ByVal Materia As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Materias.MateriaValorAcum1 as Acum1, Materias.MateriaValorAcum2 as Acum2, Materias.MateriaValorAcum3 as Acum3, Materias.MateriaValorAcum4 as Acum4, Materias.MateriaValorAcum5 as Acum5, Materias.MateriaValorAcum6 as Acum6, Materias.MateriaValorAcum7 as Acum7, Materias.MateriaValorAcum8 as Acum8, Materias.MateriaValorAcum9 as Acum9, Materias.MateriaValorAcum10 as Acum10, Materias.MateriaValorAcum11 as Acum11, Materias.MateriaValorAcum12 as Acum12, Materias.MateriaValorAcumAnual as ValorAcumAnual  "
        sSQL = sSQL & "FROM Materias "
        sSQL = sSQL & "WHERE Materias.MateriaName = '" & Materia & "'"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartPorc(0) = CDbl(dtr("Acum1").ToString)
                ArrChartPorc(1) = CDbl(dtr("Acum2").ToString)
                ArrChartPorc(2) = CDbl(dtr("Acum3").ToString)
                ArrChartPorc(3) = CDbl(dtr("Acum4").ToString)
                ArrChartPorc(4) = CDbl(dtr("Acum5").ToString)
                ArrChartPorc(5) = CDbl(dtr("Acum6").ToString)
                ArrChartPorc(6) = CDbl(dtr("Acum7").ToString)
                ArrChartPorc(7) = CDbl(dtr("Acum8").ToString)
                ArrChartPorc(8) = CDbl(dtr("Acum9").ToString)
                ArrChartPorc(9) = CDbl(dtr("Acum10").ToString)
                ArrChartPorc(10) = CDbl(dtr("Acum11").ToString)
                ArrChartPorc(11) = CDbl(dtr("Acum12").ToString)
                ArrChartPorc(12) = CDbl(dtr("ValorAcumAnual").ToString)


            End While
            LeerValoresAcumuladosPorMaterias = True
            dtr.Close()
        Catch
            LeerValoresAcumuladosPorMaterias = False
        End Try
    End Function
    Public Function LeerKPIPorMateria(ByRef ArrChartValor() As Double, _
                                      ByRef ArrChartValorAcum() As Double, _
                                      ByVal Materia As String, ByRef MetaAnual As Double, _
                                      ByRef DecMaxData As Decimal, _
                                      ByRef Tramos As Long, ByRef Pasos As Decimal) As Boolean

        Dim Lecturas As New Lecturas
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer
        Dim SumaValores As Decimal = 0
        Dim Ritmo As Decimal = 0
        Dim MesInicio As Integer = 0
        Dim Meses As Integer = 0
        Dim t As Boolean

        t = Lecturas.LeerValoresPorMaterias(ArrChartValor, Materia)
        t = Lecturas.LeerValoresAcumuladosPorMaterias(ArrChartValorAcum, Materia)

        sSQL = "SELECT Materias.Tramos As Tramos, Materias.Paso As Paso, Materias.MateriaMetaAnual as MetaAnual "
        sSQL = sSQL & "FROM Materias "
        sSQL = sSQL & "WHERE Materias.MateriaName = '" & Materia & "'"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Tramos = CLng(dtr("Tramos").ToString)
                Pasos = CDec(dtr("Paso").ToString)
                MetaAnual = CDbl(dtr("MetaAnual").ToString)
            End While
            'Determina el mayor valor entre los datos obtenidos
            DecMaxData = 0
            For i = 0 To 12
                If CDec(ArrChartValor(i)) > DecMaxData Then
                    DecMaxData = CDec(ArrChartValor(i))
                End If
            Next
            For i = 0 To 12
                If CDec(ArrChartValorAcum(i)) > DecMaxData Then
                    DecMaxData = CDec(ArrChartValorAcum(i))
                End If
            Next
            If CDec(MetaAnual) > DecMaxData Then
                DecMaxData = CDec(MetaAnual)
            End If
            dtr.Close()
            LeerKPIPorMateria = True
        Catch
            LeerKPIPorMateria = False
        End Try
    End Function


    Public Function LeerCodigosMaterialVuelo(ByRef ArrChartData() As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT MaterialVuelo.MaterialVueloId "
        sSQL = sSQL & "FROM MaterialVuelo "
        sSQL = sSQL & "ORDER BY MaterialVuelo.MaterialVueloArea, MaterialVuelo.MaterialVueloSecuencia"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("MaterialVueloId").ToString
                i = i + 1
            End While
            LeerCodigosMaterialVuelo = True
            dtr.Close()
        Catch
            LeerCodigosMaterialVuelo = False
        End Try
    End Function
    Public Function LeerNombreMaterialVuelo(ByRef MaterialVueloId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT MaterialVuelo.MaterialVueloName "
        sSQL = sSQL & "FROM MaterialVuelo "
        sSQL = sSQL & "WHERE MaterialVuelo.MaterialVueloId = " & MaterialVueloId

        LeerNombreMaterialVuelo = " "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                LeerNombreMaterialVuelo = dtr("MaterialVueloName").ToString
            End While
            dtr.Close()
        Catch

        End Try
    End Function
    Public Function LeerKeysFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                        ByRef FormularioWebId As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebLabel, FormularioWeb.FormularioWebControl "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE FormularioWeb.FormularioWebNumber = " & FormularioWebId & " AND FormularioWeb.FormularioWebSection = 'FormKeys' "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("FormularioWebLabel").ToString
                ArrControl(i) = dtr("FormularioWebControl").ToString
                i = i + 1
            End While
            LeerKeysFormularioWeb = True
            dtr.Close()
        Catch
            LeerKeysFormularioWeb = False
        End Try
    End Function
    Public Function LeerDeclaracionControlesFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                        ByRef FormularioWebNumber As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select 'Dim ' + FormularioWeb.FormularioWebControl + ' As ' + FormularioWeb.FormularioWebControlBase as Definicion, ' Etiqueta : ' + FormularioWebLabel + ' - Control : ' + FormularioWebControl + ' - Variable : ' + FormularioWebDataTextField as Glosa  "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' OR FormularioWeb.FormularioWebSection = 'Form' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("Glosa").ToString
                ArrControl(i) = dtr("Definicion").ToString
                i = i + 1
            End While
            LeerDeclaracionControlesFormularioWeb = True
            dtr.Close()
        Catch
            LeerDeclaracionControlesFormularioWeb = False
        End Try
    End Function
    Public Function LeerDeclaracionControlesCheckFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                        ByRef FormularioWebNumber As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select 'Dim chk' + FormularioWeb.FormularioWebControl + ' As CheckBox' as Definicion, ' Etiqueta : ' + FormularioWebLabel + ' - Control : ' + FormularioWebControl + ' - Variable : ' + FormularioWebDataTextField as Glosa  "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' OR FormularioWeb.FormularioWebSection = 'Form' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("Glosa").ToString
                ArrControl(i) = dtr("Definicion").ToString
                i = i + 1
            End While
            LeerDeclaracionControlesCheckFormularioWeb = True
            dtr.Close()
        Catch
            LeerDeclaracionControlesCheckFormularioWeb = False
        End Try
    End Function
    Public Function LeerCheckFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, ByVal ArrchkControl() As String, _
                                        ByRef FormularioWebNumber As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select 'chk' + FormularioWeb.FormularioWebControl + '.Checked' As CampoCheck, FormularioWeb.FormularioWebControl + '.Text' as CampoControl, FormularioWebDataTextField as Variable "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' OR FormularioWeb.FormularioWebSection = 'Form' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("Variable").ToString
                ArrControl(i) = dtr("CampoControl").ToString
                ArrchkControl(i) = dtr("CampoCheck").ToString
                i = i + 1
            End While
            LeerCheckFormularioWeb = True
            dtr.Close()
        Catch
            LeerCheckFormularioWeb = False
        End Try
    End Function
    Public Function LeerDeclaracionCamposFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                        ByRef FormularioWebNumber As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select 'Dim ' + FormularioWeb.FormularioWebDataTextField + ' As ' + FormularioWeb.FormularioWebTipoDatos as Definicion, ' Etiqueta : ' + FormularioWebLabel + ' - Control : ' + FormularioWebControl + ' - Variable : ' + FormularioWebDataTextField as Glosa "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' OR FormularioWeb.FormularioWebSection = 'Form' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("Glosa").ToString
                ArrControl(i) = dtr("Definicion").ToString
                i = i + 1
            End While
            LeerDeclaracionCamposFormularioWeb = True
            dtr.Close()
        Catch
            LeerDeclaracionCamposFormularioWeb = False
        End Try
    End Function
    Public Function DeclaracionAtributosPorEntidad(ByRef FormularioWebNumber As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select ', ByRef ' + FormularioWeb.FormularioWebDataTextField + ' As ' + FormularioWeb.FormularioWebTipoDatos as Definicion "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys'))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        DeclaracionAtributosPorEntidad = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                DeclaracionAtributosPorEntidad = DeclaracionAtributosPorEntidad & dtr("Definicion").ToString
            End While
            dtr.Close()
        Catch
            DeclaracionAtributosPorEntidad = ""
        End Try

        sSQL = "Select ', ByRef ' + FormularioWeb.FormularioWebDataTextField + ' As ' + FormularioWeb.FormularioWebTipoDatos as Definicion "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'Form' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                DeclaracionAtributosPorEntidad = DeclaracionAtributosPorEntidad & dtr("Definicion").ToString
            End While
            dtr.Close()
        Catch
            DeclaracionAtributosPorEntidad = ""
        End Try

    End Function
    Public Function ListaAtributosPorEntidad(ByRef FormularioWebNumber As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebDataTextField + ', ' as Definicion "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        ListaAtributosPorEntidad = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ListaAtributosPorEntidad = ListaAtributosPorEntidad & dtr("Definicion").ToString
            End While
            dtr.Close()
        Catch
            ListaAtributosPorEntidad = ""
        End Try

        sSQL = "Select FormularioWeb.FormularioWebDataTextField + ', ' as Definicion "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'Form' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ListaAtributosPorEntidad = ListaAtributosPorEntidad & dtr("Definicion").ToString
            End While
            ListaAtributosPorEntidad = Mid(ListaAtributosPorEntidad, 1, Len(ListaAtributosPorEntidad) - 2)
            dtr.Close()
        Catch
            ListaAtributosPorEntidad = ""
        End Try

    End Function
    Public Function UpdateAtributosPorEntidad(ByVal FormularioWebNumber As Long, _
                                              ByVal NombreTabla As String, _
                                              ByRef arrLabel() As String, _
                                              ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebDataTextField as Definicion, FormularioWebTipoDatos as TipoDatos  "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        i = 0
        arrLabel(i) = "strUpdate = ""UPDATE " & NombreTabla & " """
        i = i + 1
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Select Case dtr("TipoDatos")                                                                    '        strUpdate = strUpdate & "Comuna.ComunaDescription = '" & ComunaDescription & "', "
                    Case "String"
                        arrLabel(i) = "strUpdate = strUpdate & ""SET " & NombreTabla & "." & dtr("Definicion").ToString & " = '"" & " & dtr("Definicion") & " & ""', """
                    Case "Long"
                        arrLabel(i) = "strUpdate = strUpdate & ""SET " & NombreTabla & "." & dtr("Definicion").ToString & " = "" & " & dtr("Definicion") & " & "", """
                    Case "Date"
                        arrLabel(i) = "strUpdate = strUpdate & ""SET " & NombreTabla & "." & dtr("Definicion").ToString & " = '"" & AccionesABM.DateTransform(" & dtr("Definicion") & ") & ""', """
                    Case "Boolean"
                        arrLabel(i) = "strUpdate = strUpdate & ""SET " & NombreTabla & "." & dtr("Definicion").ToString & " = "" & " & dtr("Definicion") & " & "", """
                End Select
                i = i + 1
            End While
            dtr.Close()
            sSQL = "Select FormularioWeb.FormularioWebDataTextField as Definicion, FormularioWebTipoDatos as TipoDatos "
            sSQL = sSQL & "FROM FormularioWeb "
            sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'Form' ))) "
            sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
            Try
                dtr = AccesoEA.ListarRegistros(sSQL)
                While dtr.Read
                    Select Case dtr("TipoDatos")                                                                    '        strUpdate = strUpdate & "Comuna.ComunaDescription = '" & ComunaDescription & "', "
                        Case "String"
                            arrLabel(i) = "strUpdate = strUpdate & """ & NombreTabla & "." & dtr("Definicion").ToString & " = '"" & " & dtr("Definicion") & " & ""', """
                        Case "Long"
                            arrLabel(i) = "strUpdate = strUpdate & """ & NombreTabla & "." & dtr("Definicion").ToString & " = "" & " & dtr("Definicion") & " & "", """
                        Case "Date"
                            arrLabel(i) = "strUpdate = strUpdate & """ & NombreTabla & "." & dtr("Definicion").ToString & " = '"" & AccionesABM.DateTransform(" & dtr("Definicion") & ") & ""', """
                        Case "Boolean"
                            arrLabel(i) = "strUpdate = strUpdate & """ & NombreTabla & "." & dtr("Definicion").ToString & " = "" & " & dtr("Definicion") & " & "", """
                    End Select
                    i = i + 1
                End While
                UpdateAtributosPorEntidad = True
                dtr.Close()
            Catch
                UpdateAtributosPorEntidad = ""
            End Try
        Catch
            UpdateAtributosPorEntidad = False
        End Try
    End Function


    Public Function LeerControlesYCamposFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                        ByRef FormularioWebNumber As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebControl, FormularioWebDataTextField "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND FormularioWeb.FormularioWebSection = 'Form' )) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("FormularioWebDataTextField").ToString
                ArrControl(i) = dtr("FormularioWebControl").ToString
                i = i + 1
            End While
            LeerControlesYCamposFormularioWeb = True
            dtr.Close()
        Catch
            LeerControlesYCamposFormularioWeb = False
        End Try
    End Function
    Public Function LeerControlesYCamposFormularioWebKeys(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                        ByRef FormularioWebNumber As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebControl, FormularioWebDataTextField "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND FormularioWeb.FormularioWebSection = 'FormKeys' )) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("FormularioWebDataTextField").ToString
                ArrControl(i) = dtr("FormularioWebControl").ToString
                i = i + 1
            End While
            LeerControlesYCamposFormularioWebKeys = True
            dtr.Close()
        Catch
            LeerControlesYCamposFormularioWebKeys = False
        End Try
    End Function
    Public Function FormarStringUpdate(ByRef FormularioWebNumber As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim StringUpdate As String = ""

        sSQL = "Select FormularioWeb.FormularioWebControl + '.Text' as Definicion, FormularioWebTipoDatos as TipoDatos "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        FormarStringUpdate = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                Select Case dtr("TipoDatos")
                    Case "String"
                        StringUpdate = StringUpdate & "CStr(" & dtr("Definicion") & "), "
                    Case "Long"
                        StringUpdate = StringUpdate & "CLng(" & dtr("Definicion") & "), "
                    Case "Date"
                        StringUpdate = StringUpdate & "CDate(" & dtr("Definicion") & "), "
                    Case "Boolean"
                        StringUpdate = StringUpdate & "CBool(" & dtr("Definicion") & "), "
                    Case "Double"
                        StringUpdate = StringUpdate & "CDbl(" & dtr("Definicion") & "), "
                End Select
            End While
            dtr.Close()
        Catch
            StringUpdate = ""
        End Try

        sSQL = "Select FormularioWeb.FormularioWebControl + '.Text' as Definicion, FormularioWebTipoDatos as TipoDatos "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'Form' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                Select Case dtr("TipoDatos")
                    Case "String"
                        StringUpdate = StringUpdate & "CStr(" & dtr("Definicion") & "), "
                    Case "Long"
                        StringUpdate = StringUpdate & "CLng(" & dtr("Definicion") & "), "
                    Case "Date"
                        StringUpdate = StringUpdate & "CDate(" & dtr("Definicion") & "), "
                    Case "Boolean"
                        StringUpdate = StringUpdate & "CBool(" & dtr("Definicion") & "), "
                    Case "Double"
                        StringUpdate = StringUpdate & "CDbl(" & dtr("Definicion") & "), "
                End Select
            End While
            FormarStringUpdate = StringUpdate
            dtr.Close()
        Catch
            FormarStringUpdate = ""
        End Try

    End Function
    Public Function FormarStringBinding(ByVal FormularioWebNumber As Long, ByRef arrBinding() As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim StringUpdate As String = ""

        sSQL = "Select FormularioWeb.FormularioWebDataTextField as Definicion, FormularioWebTipoDatos as TipoDatos "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' OR FormularioWeb.FormularioWebSection = 'Form' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"

        i = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Select Case dtr("TipoDatos")
                    Case "String"
                        arrBinding(i) = dtr("Definicion").ToString & " = " & "CStr(dtr(""" & dtr("Definicion") & """).ToString)"
                    Case "Long"
                        arrBinding(i) = dtr("Definicion").ToString & " = " & "CLng(dtr(""" & dtr("Definicion") & """).ToString)"
                    Case "Date"
                        arrBinding(i) = dtr("Definicion").ToString & " = " & "CDate(dtr(""" & dtr("Definicion") & """).ToString)"
                    Case "Boolean"
                        arrBinding(i) = dtr("Definicion").ToString & " = " & "CBool(dtr(""" & dtr("Definicion") & """).ToString)"
                End Select
                i = i + 1
            End While
            dtr.Close()
            FormarStringBinding = True
        Catch
            FormarStringBinding = False
        End Try

    End Function
    Public Function FormarStringLeer(ByRef FormularioWebNumber As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim StringLeer As String = ""

        sSQL = "Select FormularioWeb.FormularioWebDataTextField as Definicion "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        FormarStringLeer = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                StringLeer = StringLeer & ", " & dtr("Definicion")
            End While
            dtr.Close()
        Catch
            StringLeer = ""
        End Try

        sSQL = "Select FormularioWeb.FormularioWebDataTextField as Definicion "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND (FormularioWeb.FormularioWebSection = 'Form'))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                StringLeer = StringLeer & ", " & dtr("Definicion")
            End While
            FormarStringLeer = StringLeer
            dtr.Close()
        Catch
            FormarStringLeer = ""
        End Try

    End Function




    Public Function LeerHeaderFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                    ByRef FormularioWebId As Long, ByRef i As Integer, ByRef FormularioWebPId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebId, FormularioWeb.FormularioWebLabel, FormularioWeb.FormularioWebControl "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE FormularioWeb.FormularioWebNumber = " & FormularioWebId & " AND FormularioWeb.FormularioWebSection = 'FormHeader' "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("FormularioWebLabel").ToString
                ArrControl(i) = dtr("FormularioWebControl").ToString
                FormularioWebPId = CLng(dtr("FormularioWebId").ToString)
                i = i + 1
            End While
            LeerHeaderFormularioWeb = True
            dtr.Close()
        Catch
            LeerHeaderFormularioWeb = False
        End Try
    End Function
    Public Function LeerNodesFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                    ByRef ArrNodesId() As Long, ByRef i As Integer, ByVal FormularioWebPId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebId, FormularioWeb.FormularioWebLabel, FormularioWeb.FormularioWebControl "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE FormularioWeb.FormularioWebPId = " & FormularioWebPId & " "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("FormularioWebLabel").ToString
                ArrControl(i) = dtr("FormularioWebControl").ToString
                ArrNodesId(i) = CLng(dtr("FormularioWebId").ToString)
                i = i + 1
            End While
            LeerNodesFormularioWeb = True
            dtr.Close()
        Catch
            LeerNodesFormularioWeb = False
        End Try
    End Function
    Public Function LeerLeafFormularioWeb(ByRef TipoControl As String, ByRef CssClassLabel As String, _
                                            ByRef CssClassControl As String, ByRef EtiquetaAlign As String, _
                                            ByRef ControlWidth As String, ByRef ControlTextMode As String, _
                                            ByRef ToolTip As String, ByRef IsRequiredField As Boolean, ByRef IsNotEnabledField As Boolean, ByRef DomainField As String, _
                                            ByRef DataTextField As String, ByRef DataFile As String, ByRef SelectCommand As String, _
                                            ByRef GroupValidation As String, ByRef FormularioWebServiceCall As String, _
                                            ByVal FormularioWebId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebTipoControl, "
        sSQL = sSQL & "FormularioWeb.FormularioWebCssClassLabel, FormularioWeb.FormularioWebCssClassControl, FormularioWeb.FormularioWebLabelAlign, "
        sSQL = sSQL & "FormularioWeb.FormularioWebControlWidth, FormularioWeb.FormularioWebControlTextMode, FormularioWeb.FormularioWebToolTip, FormularioWeb.FormularioWebIsRequiredField, FormularioWeb.FormularioWebIsNotEnabled, FormularioWeb.FormularioWebDomainField, "
        sSQL = sSQL & "FormularioWeb.FormularioWebDataTextField, FormularioWeb.FormularioWebDataFile, FormularioWeb.FormularioWebSelectCommand, FormularioWeb.FormularioWebSection, FormularioWeb.FormularioWebGroupValidation, FormularioWeb.FormularioWebServiceCall "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE FormularioWeb.FormularioWebId = " & FormularioWebId & " "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                TipoControl = dtr("FormularioWebTipoControl").ToString
                CssClassLabel = dtr("FormularioWebCssClassLabel").ToString
                CssClassControl = dtr("FormularioWebCssClassControl").ToString
                ControlWidth = dtr("FormularioWebControlWidth").ToString
                ControlTextMode = dtr("FormularioWebControlTextMode").ToString
                EtiquetaAlign = dtr("FormularioWebLabelAlign").ToString
                ToolTip = dtr("FormularioWebToolTip").ToString
                IsRequiredField = CBool(dtr("FormularioWebIsRequiredField").ToString)
                IsNotEnabledField = CBool(dtr("FormularioWebIsNotEnabled").ToString)
                DomainField = dtr("FormularioWebDomainField").ToString
                DataTextField = dtr("FormularioWebDataTextField").ToString
                DataFile = dtr("FormularioWebDataFile").ToString
                SelectCommand = dtr("FormularioWebSelectCommand").ToString
                GroupValidation = dtr("FormularioWebGroupValidation").ToString
                FormularioWebServiceCall = dtr("FormularioWebServiceCall").ToString
            End While
            LeerLeafFormularioWeb = True
            dtr.Close()
        Catch
            LeerLeafFormularioWeb = False
        End Try
    End Function
    Public Function LeerLabelFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                        ByRef FormularioWebId As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebLabel, FormularioWeb.FormularioWebControl "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebId & " AND FormularioWeb.FormularioWebSection = 'Form')) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("FormularioWebLabel").ToString
                ArrControl(i) = dtr("FormularioWebControl").ToString
                i = i + 1
            End While
            LeerLabelFormularioWeb = True
            dtr.Close()
        Catch
            LeerLabelFormularioWeb = False
        End Try
    End Function
    Public Function LeerControlFormularioWeb(ByRef TipoControl As String, ByRef CssClassLabel As String, _
                                            ByRef CssClassControl As String, ByRef EtiquetaAlign As String, _
                                            ByRef ControlWidth As String, ByRef ControlTextMode As String, _
                                            ByRef ToolTip As String, ByRef IsRequiredField As Boolean, ByRef IsNotEnabledField As Boolean, ByRef DomainField As String, _
                                            ByRef DataTextField As String, ByRef DataFile As String, ByRef SelectCommand As String, _
                                            ByVal Section As String, ByRef GroupValidation As String, _
                                            ByVal FormularioWebId As Long, ByVal i As Integer, _
                                                  Optional ByRef FormularioWebServiceCall As String = "") As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebTipoControl, "
        sSQL = sSQL & "FormularioWeb.FormularioWebCssClassLabel, FormularioWeb.FormularioWebCssClassControl, FormularioWeb.FormularioWebLabelAlign, "
        sSQL = sSQL & "FormularioWeb.FormularioWebControlWidth, FormularioWeb.FormularioWebControlTextMode, FormularioWeb.FormularioWebToolTip, FormularioWeb.FormularioWebIsRequiredField, FormularioWeb.FormularioWebIsNotEnabled, FormularioWeb.FormularioWebDomainField, "
        sSQL = sSQL & "FormularioWeb.FormularioWebDataTextField, FormularioWeb.FormularioWebDataFile, FormularioWeb.FormularioWebSelectCommand, FormularioWeb.FormularioWebSection, FormularioWeb.FormularioWebGroupValidation, FormularioWeb.FormularioWebServiceCall "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE FormularioWeb.FormularioWebNumber = " & FormularioWebId & " AND FormularioWeb.FormularioWebSecuencia = " & i & " AND FormularioWeb.FormularioWebSection = '" & Section & "' "
        LeerControlFormularioWeb = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                TipoControl = dtr("FormularioWebTipoControl").ToString
                CssClassLabel = dtr("FormularioWebCssClassLabel").ToString
                CssClassControl = dtr("FormularioWebCssClassControl").ToString
                ControlWidth = dtr("FormularioWebControlWidth").ToString
                ControlTextMode = dtr("FormularioWebControlTextMode").ToString
                EtiquetaAlign = dtr("FormularioWebLabelAlign").ToString
                ToolTip = dtr("FormularioWebToolTip").ToString
                IsRequiredField = CBool(dtr("FormularioWebIsRequiredField").ToString)
                IsNotEnabledField = CBool(dtr("FormularioWebIsNotEnabled").ToString)
                DomainField = dtr("FormularioWebDomainField").ToString
                DataTextField = dtr("FormularioWebDataTextField").ToString
                DataFile = dtr("FormularioWebDataFile").ToString
                SelectCommand = dtr("FormularioWebSelectCommand").ToString
                GroupValidation = dtr("FormularioWebGroupValidation").ToString
                FormularioWebServiceCall = dtr("FormularioWebServiceCall").ToString
                i = i + 1
                LeerControlFormularioWeb = True
            End While
            dtr.Close()
        Catch
            LeerControlFormularioWeb = False
        End Try
    End Function
    Public Function LeerControlFormularioWebConID(ByRef TipoControl As String, ByRef CssClassLabel As String, _
                                        ByRef CssClassControl As String, ByRef EtiquetaAlign As String, _
                                        ByRef ControlWidth As String, ByRef ControlTextMode As String, _
                                        ByRef ToolTip As String, ByRef IsRequiredField As Boolean, ByRef IsNotEnabledField As Boolean, ByRef DomainField As String, _
                                        ByRef DataTextField As String, ByRef DataFile As String, ByRef SelectCommand As String, _
                                        ByVal Section As String, ByRef GroupValidation As String, _
                                        ByVal FormularioWebId As Long, ByVal i As Integer, ByRef RegId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWebId as RegId, FormularioWeb.FormularioWebTipoControl, "
        sSQL = sSQL & "FormularioWeb.FormularioWebCssClassLabel, FormularioWeb.FormularioWebCssClassControl, FormularioWeb.FormularioWebLabelAlign, "
        sSQL = sSQL & "FormularioWeb.FormularioWebControlWidth, FormularioWeb.FormularioWebControlTextMode, FormularioWeb.FormularioWebToolTip, FormularioWeb.FormularioWebIsRequiredField, FormularioWeb.FormularioWebIsNotEnabled, FormularioWeb.FormularioWebDomainField, "
        sSQL = sSQL & "FormularioWeb.FormularioWebDataTextField, FormularioWeb.FormularioWebDataFile, FormularioWeb.FormularioWebSelectCommand, FormularioWeb.FormularioWebSection, FormularioWeb.FormularioWebGroupValidation "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE (((FormularioWeb.FormularioWebNumber) = " & FormularioWebId & " AND (FormularioWeb.FormularioWebSecuencia) = " & i & " AND (FormularioWeb.FormularioWebSection) = '" & Section & "')) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                TipoControl = dtr("FormularioWebTipoControl").ToString
                CssClassLabel = dtr("FormularioWebCssClassLabel").ToString
                CssClassControl = dtr("FormularioWebCssClassControl").ToString
                ControlWidth = dtr("FormularioWebControlWidth").ToString
                ControlTextMode = dtr("FormularioWebControlTextMode").ToString
                EtiquetaAlign = dtr("FormularioWebLabelAlign").ToString
                ToolTip = dtr("FormularioWebToolTip").ToString
                IsRequiredField = CBool(dtr("FormularioWebIsRequiredField").ToString)
                IsNotEnabledField = CBool(dtr("FormularioWebIsNotEnabled").ToString)
                DomainField = dtr("FormularioWebDomainField").ToString
                DataTextField = dtr("FormularioWebDataTextField").ToString
                DataFile = dtr("FormularioWebDataFile").ToString
                SelectCommand = dtr("FormularioWebSelectCommand").ToString
                GroupValidation = dtr("FormularioWebGroupValidation").ToString
                RegId = CLng(dtr("RegId").ToString)
                i = i + 1
            End While
            LeerControlFormularioWebConID = True
            dtr.Close()
        Catch
            LeerControlFormularioWebConID = False
        End Try
    End Function
    Public Function LeerControlButtonFormularioWeb(ByRef WebEvent As String, ByRef PageCall As String, _
                                            ByRef FormCall As String, ByRef ServiceCall As String, _
                                            ByVal Section As String, ByVal FormularioWebId As Long, ByVal i As Integer) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebEvent, "
        sSQL = sSQL & "FormularioWeb.FormularioWebPageCall, FormularioWeb.FormularioWebFormCall, FormularioWeb.FormularioWebServiceCall "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE (((FormularioWeb.FormularioWebNumber) = " & FormularioWebId & " AND (FormularioWeb.FormularioWebSecuencia) = " & i & " AND (FormularioWeb.FormularioWebSection) = '" & Section & "')) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                WebEvent = dtr("FormularioWebEvent").ToString
                PageCall = dtr("FormularioWebPageCall").ToString
                FormCall = dtr("FormularioWebFormCall").ToString
                ServiceCall = dtr("FormularioWebServiceCall").ToString
                i = i + 1
            End While
            LeerControlButtonFormularioWeb = True
            dtr.Close()
        Catch
            LeerControlButtonFormularioWeb = False
        End Try
    End Function
    Public Function LeerNombreMetodoAutocomplete(ByVal Section As String, _
                                            ByVal FormularioWebId As Long, ByVal i As Integer) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebServiceCall "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE (((FormularioWeb.FormularioWebNumber) = " & FormularioWebId & " AND (FormularioWeb.FormularioWebSecuencia) = " & i & " AND (FormularioWeb.FormularioWebSection) = '" & Section & "')) "

        LeerNombreMetodoAutocomplete = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                LeerNombreMetodoAutocomplete = dtr("FormularioWebServiceCall").ToString
                i = i + 1
            End While
            dtr.Close()
        Catch
            LeerNombreMetodoAutocomplete = ""
        End Try
    End Function

    Public Function LeerIdFormularioWeb(ByRef FormularioWebPId As Long, ByVal Section As String, _
                                        ByVal FormularioWebNumber As Long, ByVal i As Integer, _
                                        ByRef Pagina As String, _
                                        ByRef NombrePagina As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebId, FormularioWebPageCall, FormularioWebFormCall "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE (((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND (FormularioWeb.FormularioWebSecuencia) = " & i & " AND (FormularioWeb.FormularioWebSection) = '" & Section & "')) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                FormularioWebPId = dtr("FormularioWebId").ToString
                Pagina = dtr("FormularioWebPageCall").ToString
                NombrePagina = dtr("FormularioWebFormCall").ToString
                i = i + 1
            End While
            LeerIdFormularioWeb = True
            dtr.Close()
        Catch
            LeerIdFormularioWeb = False
        End Try
    End Function



    Public Function LeerColumnaFormularioWeb(ByRef TipoControl As String, ByRef EtiquetaAlign As String, _
                                            ByRef ControlWidth As String, _
                                            ByRef ToolTip As String, ByRef SelectCommand As String, _
                                            ByVal Section As String, _
                                            ByVal FormularioWebId As Long, ByVal i As Integer) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebTipoControl, "
        sSQL = sSQL & "FormularioWeb.FormularioWebLabelAlign, "
        sSQL = sSQL & "FormularioWeb.FormularioWebControlWidth, FormularioWebToolTip, FormularioWeb.FormularioWebURL "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE (((FormularioWeb.FormularioWebNumber) = " & FormularioWebId & " AND (FormularioWeb.FormularioWebSecuencia) = " & i & " AND (FormularioWeb.FormularioWebSection) = '" & Section & "')) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                TipoControl = dtr("FormularioWebTipoControl").ToString
                ControlWidth = dtr("FormularioWebControlWidth").ToString
                EtiquetaAlign = dtr("FormularioWebLabelAlign").ToString
                ToolTip = dtr("FormularioWebToolTip").ToString
                SelectCommand = dtr("FormularioWebURL").ToString  'Cambio del 09 de Julio de 2010
                i = i + 1
            End While
            LeerColumnaFormularioWeb = True
            dtr.Close()
        Catch
            LeerColumnaFormularioWeb = False
        End Try
    End Function
    Public Function LeerTabColumnFormularioWeb(ByRef TipoControl As String, ByRef EtiquetaAlign As String, _
                                            ByRef ControlWidth As String, _
                                            ByRef ToolTip As String, ByRef SelectCommand As String, _
                                            ByVal Section As String, _
                                            ByVal FormularioWebPId As Long, ByVal i As Integer) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebTipoControl, "
        sSQL = sSQL & "FormularioWeb.FormularioWebLabelAlign, "
        sSQL = sSQL & "FormularioWeb.FormularioWebControlWidth, FormularioWebToolTip, FormularioWeb.FormularioWebURL "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE (((FormularioWeb.FormularioWebPId) = " & FormularioWebPId & " AND (FormularioWeb.FormularioWebSecuencia) = " & i & " AND (FormularioWeb.FormularioWebSection) = '" & Section & "')) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                TipoControl = dtr("FormularioWebTipoControl").ToString
                ControlWidth = dtr("FormularioWebControlWidth").ToString
                EtiquetaAlign = dtr("FormularioWebLabelAlign").ToString
                ToolTip = dtr("FormularioWebToolTip").ToString
                SelectCommand = dtr("FormularioWebURL").ToString  'Cambio del 09 de Julio de 2010
                i = i + 1
            End While
            LeerTabColumnFormularioWeb = True
            dtr.Close()
        Catch
            LeerTabColumnFormularioWeb = False
        End Try
    End Function

    Public Function LeerSQLStatementFormularioWeb(ByVal TipoControl As String, ByRef DataFile As String, ByRef SelectCommand As String, _
                                            ByVal FormularioWebId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebDataFile, FormularioWeb.FormularioWebSelectCommand "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE FormularioWeb.FormularioWebNumber = " & FormularioWebId & " AND FormularioWeb.FormularioWebTipoControl = '" & TipoControl & "' "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                DataFile = dtr("FormularioWebDataFile").ToString
                SelectCommand = dtr("FormularioWebSelectCommand").ToString
            End While
            LeerSQLStatementFormularioWeb = True
            dtr.Close()
        Catch
            LeerSQLStatementFormularioWeb = False
        End Try
    End Function
    Public Function LeerTabSQLStatementFormularioWeb(ByVal TipoControl As String, ByRef DataFile As String, ByRef SelectCommand As String, _
                                            ByVal FormularioWebPId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebDataFile, FormularioWeb.FormularioWebSelectCommand "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE FormularioWeb.FormularioWebPId = " & FormularioWebPId & " AND FormularioWeb.FormularioWebTipoControl = '" & TipoControl & "' "
        LeerTabSQLStatementFormularioWeb = False

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                DataFile = dtr("FormularioWebDataFile").ToString
                SelectCommand = dtr("FormularioWebSelectCommand").ToString
                LeerTabSQLStatementFormularioWeb = True
            End While

            dtr.Close()
        Catch
            LeerTabSQLStatementFormularioWeb = False
        End Try
    End Function
    Public Function LeerChildTableFormularioWeb(ByVal FormularioWebId As Long, ByRef RelationTable As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebDataFile, FormularioWeb.FormularioWebDataTextField as RelationTable "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE FormularioWeb.FormularioWebId = " & FormularioWebId
        LeerChildTableFormularioWeb = False

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                LeerChildTableFormularioWeb = dtr("FormularioWebDataFile").ToString
                RelationTable = dtr("RelationTable").ToString
            End While

            dtr.Close()
        Catch
            LeerChildTableFormularioWeb = ""
        End Try
    End Function
    Public Function LeerURLStatementFormularioWeb(ByVal TipoControl As String, ByRef Pagina As String, ByRef NombrePagina As String, _
                                        ByVal FormularioWebId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Cambio introducido el 09 de Julio de 2010
        'TipoControl    ------->    Event
        'WebLabel       ------->    FormCall
        'WebControl     ------->    PageCall

        sSQL = "Select FormularioWeb.FormularioWebFormCall, FormularioWeb.FormularioWebPageCall "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE (((FormularioWeb.FormularioWebNumber) = " & FormularioWebId & " AND (FormularioWeb.FormularioWebEvent) = '" & TipoControl & "')) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                Pagina = dtr("FormularioWebPageCall").ToString
                NombrePagina = dtr("FormularioWebFormCall").ToString
            End While
            LeerURLStatementFormularioWeb = True
            dtr.Close()
        Catch
            LeerURLStatementFormularioWeb = False
        End Try
    End Function
    Public Function LeerPaginaWeb(ByVal PaginaWebName As String, ByRef PaginaWebTitle As String, _
                                        ByRef PaginaWebDescription As String, ByRef FormularioWebNumber As Integer, _
                                        ByRef PaginaWebGroupValidation As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select PaginaWeb.PaginaWebTitle, PaginaWeb.PaginaWebDescription, PaginaWeb.FormularioWebNumber, PaginaWeb.PaginaWebGroupValidation "
        sSQL = sSQL & "FROM PaginaWeb "
        sSQL = sSQL & "WHERE(((PaginaWeb.PaginaWebName) = '" & PaginaWebName & "')) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                PaginaWebTitle = dtr("PaginaWebTitle").ToString
                PaginaWebDescription = dtr("PaginaWebDescription").ToString
                FormularioWebNumber = CInt(dtr("FormularioWebNumber").ToString)
                PaginaWebGroupValidation = dtr("PaginaWebGroupValidation").ToString
            End While
            LeerPaginaWeb = True
            dtr.Close()
        Catch
            LeerPaginaWeb = False
        End Try
    End Function
    Public Function PageUserControl(ByVal PaginaWebName As String, ByRef PaginaWebUserControl As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select PaginaWeb.PaginaWebUserControl "
        sSQL = sSQL & "FROM PaginaWeb "
        sSQL = sSQL & "WHERE(((PaginaWeb.PaginaWebName) = '" & PaginaWebName & "')) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                PaginaWebUserControl = dtr("PaginaWebUserControl").ToString
            End While
            If Len(PaginaWebUserControl) > 0 Then
                PageUserControl = True
                Console.WriteLine("--------------- " & PaginaWebUserControl)
            Else
                PageUserControl = False
            End If
            dtr.Close()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            PageUserControl = False
        End Try
    End Function
    Public Function LeerCliente(ByVal ClienteId As Long, ByRef ClienteEMail As String, ByRef ClienteRut As String, ByRef ClienteName As String, ByRef ClienteApPaterno As String, ByRef ClienteApMaterno As String, _
                                ByRef ClienteCalle As String, ByRef ClienteNumero As String, ByRef ClienteDepartamento As String, ByRef ClienteComuna As String, _
                                ByRef ClienteCiudad As String, ByRef ClienteTelefonoParticular As String, ByRef ClienteCelular As String, _
                                ByRef ClienteTelefonoComercial1 As String, ByRef ClienteTelefonoComercial2 As String, ByRef ClienteFNacimiento As Date) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select ClienteEMail, ClienteRut, ClienteName, ClienteApPaterno, ClienteApMaterno, ClienteCalle, ClienteNumero, ClienteDepartamento, ClienteComuna, ClienteCiudad, "
        sSQL = sSQL & "ClienteTelefonoParticular, ClienteCelular, ClienteTelefonoComercial1, ClienteTelefonoComercial2, ClienteFNacimiento "
        sSQL = sSQL & "FROM Cliente "
        sSQL = sSQL & "WHERE (((Cliente.ClienteId) = " & ClienteId & ")) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ClienteEMail = dtr("ClienteEMail").ToString
                ClienteRut = dtr("ClienteRut").ToString
                ClienteName = dtr("ClienteName").ToString
                ClienteApPaterno = dtr("ClienteApPaterno").ToString
                ClienteApMaterno = dtr("ClienteApMaterno").ToString
                ClienteCalle = dtr("ClienteCalle").ToString
                ClienteNumero = dtr("ClienteNumero").ToString
                ClienteDepartamento = dtr("ClienteDepartamento").ToString
                ClienteComuna = dtr("ClienteComuna").ToString
                ClienteCiudad = dtr("ClienteCiudad").ToString
                ClienteTelefonoParticular = dtr("ClienteTelefonoParticular").ToString
                ClienteCelular = dtr("ClienteCelular").ToString
                ClienteTelefonoComercial1 = dtr("ClienteTelefonoComercial1").ToString
                ClienteTelefonoComercial2 = dtr("ClienteTelefonoComercial2").ToString
                ClienteFNacimiento = CDate(dtr("ClienteFNacimiento").ToString)
            End While
            LeerCliente = True
            dtr.Close()
        Catch
            LeerCliente = False
        End Try
    End Function
    Public Function LeerRutYCorreoCliente(ByVal ClienteEMail As String, ByVal ClienteRut As String, _
                                        ByRef ClienteId As Long, ByRef ClienteName As String, _
                                        ByRef ClienteApPaterno As String, ByRef ClienteApMaterno As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Cliente.ClienteId, Cliente.ClienteName,  Cliente.ClienteApPaterno, Cliente.ClienteApMaterno "
        sSQL = sSQL & "FROM Cliente "
        sSQL = sSQL & "WHERE (((Cliente.ClienteEMail) = '" & ClienteEMail & "' AND (Cliente.ClienteRut) = '" & ClienteRut & "')) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ClienteId = CLng(dtr("ClienteId").ToString)
                ClienteName = dtr("ClienteName").ToString
                ClienteApPaterno = dtr("ClienteApPaterno").ToString
                ClienteApMaterno = dtr("ClienteApMaterno").ToString
            End While
            LeerRutYCorreoCliente = True
            dtr.Close()
        Catch
            LeerRutYCorreoCliente = False
        End Try
    End Function
    Public Function LeerRolDelCliente(ByVal ClienteId As Long, ByRef RolName As String, _
                                        ByRef RolId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Cliente.RolName, Roles.RolId "
        sSQL = sSQL & "FROM Cliente, Roles "
        sSQL = sSQL & "WHERE Cliente.ClienteId = " & ClienteId & " AND Cliente.RolName = Roles.RolName"
        LeerRolDelCliente = False

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                RolId = CLng(dtr("RolId").ToString)
                RolName = dtr("RolName").ToString
                LeerRolDelCliente = True
            End While

            dtr.Close()
        Catch
            LeerRolDelCliente = False
        End Try
    End Function
    Public Function LeerComuna(ByVal ComunaId As Long, ByRef ComunaName As String, ByRef ComunaDescription As String, ByRef ComunaCodigoCorreos As String, ByRef ComunaProvincia As String, ByRef ComunaRegion As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select ComunaName, ComunaDescription, ComunaCodigoCorreos, ComunaProvincia, ComunaRegion "
        sSQL = sSQL & "FROM Comuna "
        sSQL = sSQL & "WHERE (((Comuna.ComunaId) = " & ComunaId & ")) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ComunaName = dtr("ComunaName").ToString
                ComunaDescription = dtr("ComunaDescription").ToString
                ComunaCodigoCorreos = dtr("ComunaCodigoCorreos").ToString
                ComunaProvincia = dtr("ComunaProvincia").ToString
                ComunaRegion = dtr("ComunaRegion").ToString
            End While
            LeerComuna = True
            dtr.Close()
        Catch
            LeerComuna = False
        End Try
    End Function
    Public Function LeerComunaByName(ByVal ComunaName As String, ByRef ComunaId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Comuna.ComunaId "
        sSQL = sSQL & "FROM (Comuna) "
        sSQL = sSQL & "WHERE ((Comuna.ComunaName) = '" & ComunaName & "')"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ComunaId = CLng(dtr("ComunaId").ToString)
            End While
            LeerComunaByName = True
            dtr.Close()
        Catch
            LeerComunaByName = False
            ComunaId = 0
        End Try
    End Function
    Public Function LeerMasterIdByMasterName(ByVal ObjectId As String, _
                                             ByVal ObjectName As String, _
                                             ByVal ObjectTable As String, _
                                             ByVal MasterName As String, _
                                             ByRef MasterId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select " & ObjectTable & "." & ObjectId & " As MasterId "
        sSQL = sSQL & "FROM " & ObjectTable & " "
        sSQL = sSQL & "WHERE ((" & ObjectTable & "." & ObjectName & ") = '" & MasterName & "')"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                MasterId = CLng(dtr("MasterId").ToString)
            End While
            LeerMasterIdByMasterName = True
            dtr.Close()
        Catch
            LeerMasterIdByMasterName = False
            MasterId = 0
        End Try
    End Function
    Public Function LeerCantidadComunaBysSQLWhere(ByVal sSQL As String, ByRef Cantidad As Integer, ByRef Codigo As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Cantidad = CInt(dtr("Cantidad").ToString)
                Codigo = CLng(dtr("Codigo").ToString)
            End While
            LeerCantidadComunaBysSQLWhere = True
            dtr.Close()
        Catch
            LeerCantidadComunaBysSQLWhere = False
            Cantidad = 0
            Codigo = 0
        End Try
    End Function
    Public Function LeerButtonFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                        ByRef FormularioWebId As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebLabel, FormularioWeb.FormularioWebControl "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE FormularioWeb.FormularioWebNumber = " & FormularioWebId & " AND FormularioWeb.FormularioWebTipoControl = 'Button' "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("FormularioWebLabel").ToString
                ArrControl(i) = dtr("FormularioWebControl").ToString
                i = i + 1
            End While

            LeerButtonFormularioWeb = True
            Console.WriteLine("------------------- LeerButtonFormularioWeb VERDADERO")
            dtr.Close()
        Catch
            LeerButtonFormularioWeb = False
            Console.WriteLine("------------------- LeerButtonFormularioWeb FALSO")
        End Try
    End Function
    Public Function LeerTabsFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                        ByRef FormularioWebId As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebLabel, FormularioWeb.FormularioWebControl "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE FormularioWeb.FormularioWebNumber = " & FormularioWebId & " AND FormularioWeb.FormularioWebTipoControl = 'Tabs' AND FormularioWeb.FormularioWebIsVisibleToInit = 1 "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("FormularioWebLabel").ToString
                ArrControl(i) = dtr("FormularioWebControl").ToString
                i = i + 1
            End While
            LeerTabsFormularioWeb = True
            dtr.Close()
        Catch
            LeerTabsFormularioWeb = False
        End Try
    End Function
    Public Function LeerColumnasFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                    ByRef FormularioWebId As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebLabel, FormularioWeb.FormularioWebControl "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE FormularioWeb.FormularioWebNumber = " & FormularioWebId & " AND FormularioWeb.FormularioWebSection = 'Grilla' "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("FormularioWebLabel").ToString
                ArrControl(i) = dtr("FormularioWebControl").ToString
                i = i + 1
            End While
            LeerColumnasFormularioWeb = True
            dtr.Close()
        Catch
            LeerColumnasFormularioWeb = False
        End Try
    End Function
    Public Function LeerTabsColumnsFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                ByVal FormularioWebPId As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebLabel, FormularioWeb.FormularioWebControl "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebPId) = " & FormularioWebPId & " AND FormularioWeb.FormularioWebSection = 'Grilla')) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("FormularioWebLabel").ToString
                ArrControl(i) = dtr("FormularioWebControl").ToString
                i = i + 1
            End While
            LeerTabsColumnsFormularioWeb = True
            dtr.Close()
        Catch
            LeerTabsColumnsFormularioWeb = False
        End Try
    End Function

    Public Sub CrearFormularioLogin(ByVal NumeroPagina As Integer, ByVal TituloPagina As String, _
                                    ByVal DescripcionPagina As String, ByVal GroupValidation As String, _
                                    ByRef MyTable As Table, ByRef sumValidacion As ValidationSummary, _
                                    ByRef valTextBox As RequiredFieldValidator, ByRef REValidacion As RegularExpressionValidator, _
                                    ByRef CuValidacion As CustomValidator, ByRef CoValidacion As CompareValidator, _
                                    ByRef LoginButton As Button, ByRef CancelButton As Button, ByRef UpdateButton As Button, _
                                    ByRef NewButton As Button, ByRef SearchButton As Button, ByRef DeleteButton As Button, ByRef ReturnButton As Button)
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim m As Integer = 0
        Dim n As Integer = 0
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim arrLabel(21) As String
        Dim arrControl(21) As String
        Dim arrGrillaLabel(21) As String
        Dim arrGrillaControl(21) As String
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
        Dim Url As String = ""
        Dim FormularioWebPId As Long = 0

        Dim txtTextBox As TextBox
        Dim txtDropDownList As DropDownList
        Dim txtCheckBox As CheckBox
        Dim sqlSource As SqlDataSource
        Dim txtCalendar As CalendarExtender
        Dim ImgImages As Image
        Dim AutoComp As AutoCompleteExtender

        Dim sSQL As String = ""
        Dim HTMLCode As String = ""




        t = Lecturas.LeerLabelFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        'Titulo
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("<h1>" & TituloPagina & "</h1>"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)


        'Linea de Divisi�n
        'Row = New TableRow
        'Cell = New TableCell
        'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        'Cell.Height = "4"
        'Cell.ColumnSpan = "2"
        'Cell.Controls.Add(New LiteralControl("<hr />"))
        'Row.Cells.Add(Cell)
        'MyTable.Rows.Add(Row)

        'Descripci�n
        'Row = New TableRow
        'Cell = New TableCell
        'Cell.CssClass = "tab_contenido"
        'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        'Cell.ColumnSpan = "2"
        'Cell.Controls.Add(New LiteralControl(DescripcionPagina))
        'Row.Cells.Add(Cell)
        'MyTable.Rows.Add(Row)

        'Summary de Validaciones
        Row = New TableRow
        Cell = New TableCell
        'Cell.CssClass = "contenidos"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        sumValidacion = New ValidationSummary
        sumValidacion.ID = "RegisterUserValidationSummary"
        sumValidacion.HeaderText = "Existen problemas con los siguientes campos del formulario"
        'sumValidacion.CssClass = "contenidos"
        sumValidacion.ValidationGroup = GroupValidation
        Cell.Controls.Add(sumValidacion)
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        'Linea de Divisi�n
        'Row = New TableRow
        'Cell = New TableCell
        'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        'Cell.Height = "4"
        'Cell.ColumnSpan = "2"
        'Cell.Controls.Add(New LiteralControl("<hr />"))
        'Row.Cells.Add(Cell)
        'MyTable.Rows.Add(Row)

        'Controles del Formulario Web
        For k = 0 To i - 1
            t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Form", GroupValidation, NumeroPagina, k + 1)
            Row = New TableRow
            Row.VerticalAlign = VerticalAlign.Middle
            Cell = New TableCell
            Cell.CssClass = CssClassLabel
            Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
            Cell.Style(HtmlTextWriterStyle.Width) = "20%"
            ' por si aca
            Cell.Style(HtmlTextWriterStyle.Height) = "50"
            Cell.Controls.Add(New LiteralControl(arrLabel(k) & " : "))
            Row.Cells.Add(Cell)
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.Width) = "80%"
            Cell.VerticalAlign = VerticalAlign.Middle
            Select Case TipoControl
                Case "TextBox"
                    txtTextBox = New TextBox
                    txtTextBox.ID = arrControl(k)
                    txtTextBox.ClientIDMode = ClientIDMode.Static
                    txtTextBox.CssClass = CssClassControl
                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    txtTextBox.TextMode = ControlTextMode
                    If ControlTextMode = 1 Then
                        txtTextBox.Height = "50"
                    End If
                    txtTextBox.ToolTip = ToolTip
                    If IsNotEnabledField Then
                        txtTextBox.Enabled = False
                    End If
                    Cell.Controls.Add(txtTextBox)
                Case "TextBoxAutoComplete"
                    txtTextBox = New TextBox
                    txtTextBox.ID = arrControl(k)
                    txtTextBox.ClientIDMode = ClientIDMode.Static
                    txtTextBox.CssClass = CssClassControl
                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    txtTextBox.TextMode = ControlTextMode
                    If ControlTextMode = 1 Then
                        txtTextBox.Height = "50"
                    End If
                    txtTextBox.ToolTip = ToolTip
                    If IsNotEnabledField Then
                        txtTextBox.Enabled = False
                    End If
                    Cell.Controls.Add(txtTextBox)
                    AutoComp = New AutoCompleteExtender
                    AutoComp.ID = "Autocomplete" & arrControl(k)
                    AutoComp.ClientIDMode = UI.ClientIDMode.Static
                    AutoComp.CompletionListItemCssClass = CssClassControl
                    AutoComp.TargetControlID = arrControl(k)
                    AutoComp.ServicePath = "AutoComplete.asmx"
                    AutoComp.ServiceMethod = Lecturas.LeerNombreMetodoAutocomplete("Form", NumeroPagina, k + 1)  ' Aqui hay que invocar un metodo para traer el nombre del m�todo
                    AutoComp.MinimumPrefixLength = "2"
                    AutoComp.CompletionInterval = "1000"
                    AutoComp.EnableCaching = "true"
                    AutoComp.CompletionSetCount = "12"
                    Cell.Controls.Add(AutoComp)
                Case "TextBoxCalendar"
                    txtTextBox = New TextBox
                    txtTextBox.ID = arrControl(k)
                    txtTextBox.ClientIDMode = ClientIDMode.Static
                    txtTextBox.CssClass = CssClassControl
                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    txtTextBox.TextMode = ControlTextMode
                    txtTextBox.ToolTip = ToolTip
                    If IsNotEnabledField Then
                        txtTextBox.Enabled = False
                    End If
                    Cell.Controls.Add(txtTextBox)
                    Cell.Controls.Add(New LiteralControl(" "))
                    ImgImages = New Image
                    ImgImages.ID = "Image" & arrControl(k)
                    ImgImages.ClientIDMode = UI.ClientIDMode.Static
                    ImgImages.ImageUrl = "img/Calendar_scheduleHS.png"
                    ImgImages.ImageAlign = ImageAlign.Middle
                    Cell.Controls.Add(ImgImages)
                    txtCalendar = New CalendarExtender
                    txtCalendar.ID = "Calendar" & arrControl(k)
                    txtCalendar.ClientIDMode = UI.ClientIDMode.Static
                    txtCalendar.TargetControlID = arrControl(k)
                    txtCalendar.PopupButtonID = "Image" & arrControl(k)
                    txtCalendar.Format = "dd/MM/yy"
                    Cell.Controls.Add(txtCalendar)
                Case "DropDownList"
                    txtDropDownList = New DropDownList
                    txtDropDownList.ID = arrControl(k)
                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                    txtDropDownList.CssClass = CssClassControl
                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    txtDropDownList.ToolTip = ToolTip
                    txtDropDownList.DataSourceID = "ds" & arrControl(k)
                    txtDropDownList.DataTextField = DataTextField
                    txtDropDownList.Height = "20"
                    Cell.Controls.Add(txtDropDownList)



                    
                    sqlSource  = New SqlDataSource()                    
                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                    sqlSource.SelectCommand = SelectCommand
                    Console.WriteLine(SelectCommand)
                    sqlSource.ID = "ds" & arrControl(k)
                    'sqlSource.DataFile = DataFile
                    Cell.Controls.Add(sqlSource)
                Case "DropDownSearch"
                    txtCheckBox = New CheckBox
                    txtCheckBox.ID = "chk" & arrControl(k)
                    txtCheckBox.ClientIDMode = ClientIDMode.Static
                    txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrLabel(k)
                    Cell.Controls.Add(txtCheckBox)
                    Cell.Controls.Add(New LiteralControl(" "))
                    txtDropDownList = New DropDownList
                    txtDropDownList.ID = arrControl(k)
                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                    txtDropDownList.CssClass = CssClassControl
                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    txtDropDownList.ToolTip = ToolTip
                    txtDropDownList.DataSourceID = "ds" & arrControl(k)
                    txtDropDownList.DataTextField = DataTextField
                    txtDropDownList.Height = "20"
                    Cell.Controls.Add(txtDropDownList)

                    
                    sqlSource  = New SqlDataSource()                    
                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                    sqlSource.SelectCommand = SelectCommand
                    
                    sqlSource.ID = "ds" & arrControl(k)
                    'sqlSource.DataFile = DataFile
                    'sqlSource.SelectCommand = SelectCommand
                    Cell.Controls.Add(sqlSource)
                Case "AutocompleteSearch"
                    txtCheckBox = New CheckBox
                    txtCheckBox.ID = "chk" & arrControl(k)
                    txtCheckBox.ClientIDMode = ClientIDMode.Static
                    txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrLabel(k)
                    Cell.Controls.Add(txtCheckBox)
                    Cell.Controls.Add(New LiteralControl(" "))
                    txtTextBox = New TextBox
                    txtTextBox.ID = arrControl(k)
                    txtTextBox.ClientIDMode = ClientIDMode.Static
                    txtTextBox.CssClass = CssClassControl
                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    txtTextBox.TextMode = ControlTextMode
                    If ControlTextMode = 1 Then
                        txtTextBox.Height = "50"
                    End If
                    txtTextBox.ToolTip = ToolTip
                    If IsNotEnabledField Then
                        txtTextBox.Enabled = False
                    End If
                    Cell.Controls.Add(txtTextBox)
                    AutoComp = New AutoCompleteExtender
                    AutoComp.ID = "Autocomplete" & arrControl(k)
                    AutoComp.ClientIDMode = UI.ClientIDMode.Static
                    AutoComp.CompletionListItemCssClass = CssClassControl
                    AutoComp.TargetControlID = arrControl(k)
                    AutoComp.ServicePath = "~/SimpleService.asmx"
                    AutoComp.ServiceMethod = "GetCompletionList"
                    AutoComp.MinimumPrefixLength = "2"
                    AutoComp.CompletionInterval = "1000"
                    AutoComp.EnableCaching = "true"
                    AutoComp.CompletionSetCount = "12"
                    Cell.Controls.Add(AutoComp)
            End Select

            Row.Cells.Add(Cell)

            If IsRequiredField Then
                valTextBox = New RequiredFieldValidator
                valTextBox.ID = "RequiredField" & arrControl(k)
                valTextBox.ControlToValidate = arrControl(k)
                valTextBox.Text = "*"
                valTextBox.ErrorMessage = arrLabel(k) & " es un campo obligatorio"
                valTextBox.CssClass = "tab_contenido"
                valTextBox.ValidationGroup = GroupValidation
                Cell.Controls.Add(valTextBox)
            End If
            Select Case DomainField
                Case "Correo"
                    REValidacion = New RegularExpressionValidator
                    REValidacion.ID = "RegularExpression" & arrControl(k)
                    REValidacion.ControlToValidate = arrControl(k)
                    REValidacion.Text = "*"
                    REValidacion.ErrorMessage = "La direcci�n de correo no tiene un formato valido"
                    REValidacion.CssClass = "tab_contenido"
                    REValidacion.ValidationGroup = GroupValidation
                    REValidacion.ValidationExpression = "\S+@\S+\.\S{2,3}"
                    Cell.Controls.Add(REValidacion)
                Case "RUT"
                    CuValidacion = New CustomValidator
                    CuValidacion.ID = "RutValidator" & arrControl(k)
                    CuValidacion.ControlToValidate = arrControl(k)
                    CuValidacion.Text = "*"
                    CuValidacion.ErrorMessage = "El RUT no es valido"
                    CuValidacion.CssClass = "tab_contenido"
                    CuValidacion.ValidationGroup = GroupValidation
                    CuValidacion.EnableClientScript = True
                    CuValidacion.ClientValidationFunction = "RutValidator_ClientValidate"
                    Cell.Controls.Add(CuValidacion)
                Case "Numeros"
                    CoValidacion = New CompareValidator
                    CoValidacion.ID = "CompareValidator" & arrControl(k)
                    CoValidacion.ControlToValidate = arrControl(k)
                    CoValidacion.Text = "*"
                    CoValidacion.ErrorMessage = arrLabel(k) & " debe ser un valor num�rico"
                    CoValidacion.CssClass = "tab_contenido"
                    CoValidacion.ValidationGroup = GroupValidation
                    CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                    CoValidacion.Type = ValidationDataType.Integer
                    Cell.Controls.Add(CoValidacion)
                Case "Letras"
                    CoValidacion = New CompareValidator
                    CoValidacion.ID = "CompareValidator" & arrControl(k)
                    CoValidacion.ControlToValidate = arrControl(k)
                    CoValidacion.Text = "*"
                    CoValidacion.ErrorMessage = arrLabel(k) & " debe ser un valor alfanum�rico"
                    CoValidacion.CssClass = "tab_contenido"
                    CoValidacion.ValidationGroup = GroupValidation
                    CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                    CoValidacion.Type = ValidationDataType.String
                    Cell.Controls.Add(CoValidacion)
                Case "Fecha"
                    CoValidacion = New CompareValidator
                    CoValidacion.ID = "CompareValidator" & arrControl(k)
                    CoValidacion.ControlToValidate = arrControl(k)
                    CoValidacion.Text = "*"
                    CoValidacion.ErrorMessage = arrLabel(k) & " debe ser una fecha valida"
                    CoValidacion.CssClass = "tab_contenido"
                    CoValidacion.ValidationGroup = GroupValidation
                    CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                    CoValidacion.Type = ValidationDataType.Date
                    Cell.Controls.Add(CoValidacion)

            End Select
            MyTable.Rows.Add(Row)
        Next

        'Linea de Divisi�n
        'Row = New TableRow
        'Cell = New TableCell
        'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        'Cell.Height = "4"
        'Cell.ColumnSpan = "2"
        'Cell.Controls.Add(New LiteralControl("<hr />"))
        'Row.Cells.Add(Cell)
        'MyTable.Rows.Add(Row)

        'Botones del Formulario
        i = 0
        t = Lecturas.LeerButtonFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = CssClassLabel
        Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
        Cell.Style(HtmlTextWriterStyle.Width) = "20%"
        Row.Cells.Add(Cell)
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.Width) = "80%"
        For k = 0 To i - 1
            t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Button", GroupValidation, NumeroPagina, k + 1)
            Select Case arrControl(k)
                Case "LoginButton"
                    LoginButton = New Button
                    LoginButton.ID = arrControl(k)
                    LoginButton.CssClass = CssClassControl
                    LoginButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    LoginButton.Text = arrLabel(k)
                    LoginButton.ToolTip = ToolTip
                    If IsRequiredField Then
                        LoginButton.ValidationGroup = GroupValidation
                    End If
                    'AddHandler LoginButton.Click, AddressOf RFC_Login
                    Cell.Controls.Add(LoginButton)
                    Cell.Controls.Add(New LiteralControl(" "))
                Case "CancelButton"
                    CancelButton = New Button
                    CancelButton.ID = arrControl(k)
                    CancelButton.CssClass = CssClassControl
                    CancelButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    CancelButton.Text = arrLabel(k)
                    CancelButton.ToolTip = ToolTip
                    'AddHandler CancelButton.Click, AddressOf RFC_Logout
                    Cell.Controls.Add(CancelButton)
                    Cell.Controls.Add(New LiteralControl(" "))
                Case "UpdateButton"
                    UpdateButton = New Button
                    UpdateButton.ID = arrControl(k)
                    UpdateButton.CssClass = CssClassControl
                    UpdateButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    UpdateButton.Text = arrLabel(k)
                    UpdateButton.ToolTip = ToolTip
                    If IsRequiredField Then
                        UpdateButton.ValidationGroup = GroupValidation
                    End If
                    'AddHandler UpdateButton.Click, AddressOf RFC_Update
                    Cell.Controls.Add(UpdateButton)
                    Cell.Controls.Add(New LiteralControl(" "))
                Case "NewButton"
                    NewButton = New Button
                    NewButton.ID = arrControl(k)
                    NewButton.CssClass = CssClassControl
                    NewButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    NewButton.Text = arrLabel(k)
                    NewButton.ToolTip = ToolTip
                    If IsRequiredField Then
                        NewButton.ValidationGroup = GroupValidation
                    End If
                    'AddHandler UpdateButton.Click, AddressOf RFC_Update
                    Cell.Controls.Add(NewButton)
                    Cell.Controls.Add(New LiteralControl(" "))
                Case "SearchButton"
                    SearchButton = New Button
                    SearchButton.ID = arrControl(k)
                    SearchButton.CssClass = CssClassControl
                    SearchButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    SearchButton.Text = arrLabel(k)
                    SearchButton.ToolTip = ToolTip
                    If IsRequiredField Then
                        SearchButton.ValidationGroup = GroupValidation
                    End If
                    'AddHandler UpdateButton.Click, AddressOf RFC_Update
                    Cell.Controls.Add(SearchButton)
                    Cell.Controls.Add(New LiteralControl(" "))
                Case "DeleteButton"
                    DeleteButton = New Button
                    DeleteButton.ID = arrControl(k)
                    DeleteButton.CssClass = CssClassControl
                    DeleteButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    DeleteButton.Text = arrLabel(k)
                    DeleteButton.ToolTip = ToolTip
                    If IsRequiredField Then
                        DeleteButton.ValidationGroup = GroupValidation
                    End If
                    'AddHandler DeleteButton.Click, AddressOf RFC_Delete
                    Cell.Controls.Add(DeleteButton)
                    Cell.Controls.Add(New LiteralControl(" "))
                Case "ReturnButton"
                    ReturnButton = New Button
                    ReturnButton.ID = arrControl(k)
                    ReturnButton.CssClass = CssClassControl
                    ReturnButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    ReturnButton.Text = arrLabel(k)
                    ReturnButton.ToolTip = ToolTip
                    If IsRequiredField Then
                        ReturnButton.ValidationGroup = GroupValidation
                    End If
                    'AddHandler ReturnButton.Click, AddressOf RFC_Return
                    Cell.Controls.Add(ReturnButton)
                    Cell.Controls.Add(New LiteralControl(" "))
            End Select
        Next

        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
    End Sub
    Public Function LeerMenuItemContext(ByVal MenuOptionsId As Long, ByRef Logo As String, ByRef BarMenu As String, ByRef SideBarMenu As String, ByRef PaginaWebName As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Logo, BarMenu, SideBarMenu, PaginaWebName "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.MenuOptionsId) = " & MenuOptionsId & ")) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                Logo = dtr("Logo").ToString
                BarMenu = dtr("BarMenu").ToString
                SideBarMenu = dtr("SideBarMenu").ToString
                PaginaWebName = dtr("PaginaWebName").ToString
            End While
            LeerMenuItemContext = True
            dtr.Close()
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
            LeerMenuItemContext = False
        End Try
    End Function
    Public Function IsSubMenuItem(ByVal MenuOptionsId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim t As Boolean

        sSQL = "Select IsSubMenu "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.MenuOptionsId) = " & MenuOptionsId & ")) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                t = CBool(dtr("IsSubMenu").ToString)
            End While
            If t = True Then
                IsSubMenuItem = True
            Else
                IsSubMenuItem = False
            End If

            dtr.Close()
        Catch
            IsSubMenuItem = False
        End Try
    End Function
    Public Function LeerEstCargo(ByVal EstCargoId As Long, ByRef EstCargoName As String, ByRef EstCargoDescription As String, ByRef EstCargoSecuencia As Long, ByRef EstCargoPlanta As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select EstCargoName, EstCargoDescription, EstCargoSecuencia, EstCargoPlanta "
        sSQL = sSQL & "FROM EstereotiposCargos "
        sSQL = sSQL & "WHERE (((EstereotiposCargos.EstCargoId) = " & EstCargoId & ")) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                EstCargoName = dtr("EstCargoName").ToString
                EstCargoDescription = dtr("EstCargoDescription").ToString
                EstCargoSecuencia = dtr("EstCargoSecuencia").ToString
                EstCargoPlanta = dtr("EstCargoPlanta").ToString
            End While
            LeerEstCargo = True
            dtr.Close()
        Catch
            LeerEstCargo = False
        End Try
    End Function
    Public Function LeerEstCargoByName(ByVal EstCargoName As String, ByRef EstCargoId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select EstereotiposCargos.EstCargoId "
        sSQL = sSQL & "FROM (EstereotiposCargos) "
        sSQL = sSQL & "WHERE ((EstereotiposCargos.EstCargoName) = '" & EstCargoName & "')"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                EstCargoId = CLng(dtr("EstCargoId").ToString)
            End While
            LeerEstCargoByName = True
            dtr.Close()
        Catch
            LeerEstCargoByName = False
            EstCargoId = 0
        End Try
    End Function
    Public Function LeerClienteParaAutocomplete(ByRef ArrChartData() As String, ByVal Filtro As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT distinct EstereotiposCargos.[EstCargoPlanta] AS Planta "
        sSQL = sSQL & "FROM EstereotiposCargos "
        sSQL = sSQL & "WHERE (((EstereotiposCargos.EstCargoPlanta) LIKE ('%" & Filtro & "%')))"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("Planta").ToString
                i = i + 1
            End While
            LeerClienteParaAutocomplete = True
            dtr.Close()
        Catch
            LeerClienteParaAutocomplete = False
        End Try
    End Function
    Public Function LeerCargo(ByVal CargosId As Long, ByRef CargosName As String, ByRef CargosDescription As String, ByRef EstCargoName As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select CargosName, CargosDescription, EstCargoName "
        sSQL = sSQL & "FROM Cargos "
        sSQL = sSQL & "WHERE (((Cargos.CargosId) = " & CargosId & ")) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                CargosName = dtr("CargosName").ToString
                CargosDescription = dtr("CargosDescription").ToString
                EstCargoName = dtr("EstCargoName").ToString
            End While
            LeerCargo = True
            dtr.Close()
        Catch
            LeerCargo = False
        End Try
    End Function
    Public Function LeerCargoByName(ByVal CargosName As String, ByRef CargosId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Cargos.CargosId "
        sSQL = sSQL & "FROM Cargos "
        sSQL = sSQL & "WHERE ((Cargos.CargosName) = '" & CargosName & "')"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                CargosId = CLng(dtr("CargosId").ToString)
            End While
            LeerCargoByName = True
            dtr.Close()
        Catch
            LeerCargoByName = False
            CargosId = 0
        End Try
    End Function
    Public Function LeerRequisitoCargoByNameAndSecuencia(ByVal CargosName As String, ByVal ReqCargoSecuencia As Long, ByRef ReqCargoId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select RequisitosCargos.ReqCargoId "
        sSQL = sSQL & "FROM RequisitosCargos "
        sSQL = sSQL & "WHERE ((RequisitosCargos.CargosName) = '" & CargosName & "' AND (RequisitosCargos.ReqCargoSecuencia)=" & ReqCargoSecuencia & ")"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ReqCargoId = CLng(dtr("ReqCargoId").ToString)
            End While
            LeerRequisitoCargoByNameAndSecuencia = True
            dtr.Close()
        Catch
            LeerRequisitoCargoByNameAndSecuencia = False
            ReqCargoId = 0
        End Try 
    End Function
    Public Function LeerObjectByNameAndSecuencia(ByVal CampoId As String, _
                                                ByVal CampoMaestro As String, _
                                                ByVal CampoSecuencia As String, _
                                                ByVal NombreTabla As String, _
                                                ByVal MasterName As String, _
                                                ByVal DetailSecuencia As Long, _
                                                ByRef DetailId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select " & NombreTabla & "." & CampoId & " As DetailId "
        sSQL = sSQL & "FROM " & NombreTabla & " "
        sSQL = sSQL & "WHERE ((" & NombreTabla & "." & CampoMaestro & ") = '" & MasterName & "' AND (" & NombreTabla & "." & CampoSecuencia & ")=" & DetailSecuencia & ")"
        LeerObjectByNameAndSecuencia = False
        DetailId = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                DetailId = CLng(dtr("DetailId").ToString)
                LeerObjectByNameAndSecuencia = True
            End While
            dtr.Close()
        Catch
            LeerObjectByNameAndSecuencia = False
            DetailId = 0
        End Try
    End Function


    Public Function CalcularNextSecuenciaReqCargo(ByVal CargosName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Max(RequisitosCargos.ReqCargoSecuencia) as Maximo "
        sSQL = sSQL & "FROM RequisitosCargos "
        sSQL = sSQL & "WHERE ((RequisitosCargos.CargosName) = '" & CargosName & "')"

        CalcularNextSecuenciaReqCargo = 1

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                CalcularNextSecuenciaReqCargo = CLng(dtr("Maximo").ToString) + 1
            End While
            dtr.Close()
        Catch
            CalcularNextSecuenciaReqCargo = 1
        End Try
    End Function
    Public Function CalcularNextSecuenciaObject(ByVal CampoMaestro As String, _
                                                ByVal CampoSecuencia As String, _
                                                ByVal NombreTabla As String, _
                                                ByVal MasterName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Max(" & NombreTabla & "." & CampoSecuencia & ") as Maximo "
        sSQL = sSQL & "FROM " & NombreTabla 
        sSQL = sSQL & " WHERE ((" & NombreTabla & "." & CampoMaestro & ") = '" & MasterName & "')"

        CalcularNextSecuenciaObject = 1

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                If Len(dtr("Maximo").ToString) > 0 Then
                    CalcularNextSecuenciaObject = CLng(dtr("Maximo").ToString) + 1
                Else
                    CalcularNextSecuenciaObject = 1
                End If
            End While
            dtr.Close()
Catch ex As Exception
            CalcularNextSecuenciaObject = 1
            Console.WriteLine("** Exception in CalcularNextSecuenciaObject **")
            Console.WriteLine(ex.ToString)
            Console.WriteLine("Tabla = " & NombreTabla)
            Console.WriteLine("** Exception in CalcularNextSecuenciaObject **")                         
        End Try
    End Function

    Public Function CalcularNextFormularioWebNumber() As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Max(FormularioWeb.FormularioWebNumber) as Maximo "
        sSQL = sSQL & "FROM FormularioWeb"

        CalcularNextFormularioWebNumber = 1

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                CalcularNextFormularioWebNumber = CLng(dtr("Maximo").ToString) + 1
            End While
            dtr.Close()
        Catch
            CalcularNextFormularioWebNumber = 1
        End Try
    End Function

    Public Function LeerReqCargo(ByVal ReqCargoId As Long, ByRef CargosName As String, ByRef ReqCargoSecuencia As Long, ByRef ReqCargoNombre As String, ByRef ReqCargoDescription As String, ByRef ReqCargoNivelExigencia As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select CargosName, ReqCargoDescription, ReqCargoSecuencia, ReqCargoNombre, ReqCargoNivelExigencia "
        sSQL = sSQL & "FROM RequisitosCargos "
        sSQL = sSQL & "WHERE (((RequisitosCargos.ReqCargoId) = " & ReqCargoId & ")) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                CargosName = dtr("CargosName").ToString
                ReqCargoSecuencia = CLng(dtr("ReqCargoSecuencia").ToString)
                ReqCargoNombre = dtr("ReqCargoNombre").ToString
                ReqCargoDescription = dtr("ReqCargoDescription").ToString
                ReqCargoNivelExigencia = dtr("ReqCargoNivelExigencia").ToString
            End While
            LeerReqCargo = True
            dtr.Close()
        Catch
            LeerReqCargo = False
        End Try
    End Function
    Public Function LeerReqCargoNombreParaAutocomplete(ByRef ArrChartData() As String, ByVal Filtro As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT distinct RequisitosCargos.[ReqCargoNombre] AS Requisito "
        sSQL = sSQL & "FROM RequisitosCargos "
        sSQL = sSQL & "WHERE (((RequisitosCargos.ReqCargoNombre) LIKE ('%" & Filtro & "%')))"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("Requisito").ToString
                i = i + 1
            End While
            LeerReqCargoNombreParaAutocomplete = True
            dtr.Close()
        Catch
            LeerReqCargoNombreParaAutocomplete = False
        End Try
    End Function
    Public Function LeerReqCargoNivelExigenciaParaAutocomplete(ByRef ArrChartData() As String, ByVal Filtro As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT distinct RequisitosCargos.[ReqCargoNivelExigencia] AS NivelExigencia "
        sSQL = sSQL & "FROM RequisitosCargos "
        sSQL = sSQL & "WHERE (((RequisitosCargos.ReqCargoNivelExigencia) LIKE ('%" & Filtro & "%')))"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("NivelExigencia").ToString
                i = i + 1
            End While
            LeerReqCargoNivelExigenciaParaAutocomplete = True
            dtr.Close()
        Catch
            LeerReqCargoNivelExigenciaParaAutocomplete = False
        End Try
    End Function
    Public Function LeerFunCargoGrupoParaAutocomplete(ByRef ArrChartData() As String, ByVal Filtro As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT distinct FuncionesCargos.[FunCargoGrupo] AS Grupo "
        sSQL = sSQL & "FROM FuncionesCargos "
        sSQL = sSQL & "WHERE (((FuncionesCargos.FunCargoGrupo) LIKE ('%" & Filtro & "%')))"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("Grupo").ToString
                i = i + 1
            End While
            LeerFunCargoGrupoParaAutocomplete = True
            dtr.Close()
        Catch
            LeerFunCargoGrupoParaAutocomplete = False
        End Try
    End Function
    Public Function LeerPaginaWebGroupValidationParaAutocomplete(ByRef ArrChartData() As String, ByVal Filtro As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT distinct PaginaWeb.[PaginaWebGroupValidation] AS Grupo "
        sSQL = sSQL & "FROM PaginaWeb "
        sSQL = sSQL & "WHERE (((PaginaWeb.PaginaWebGroupValidation) LIKE ('%" & Filtro & "%')))"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("Grupo").ToString
                i = i + 1
            End While
            LeerPaginaWebGroupValidationParaAutocomplete = True
            dtr.Close()
        Catch
            LeerPaginaWebGroupValidationParaAutocomplete = False
        End Try
    End Function
    Public Function LeerPaginaWebStereotypeParaAutocomplete(ByRef ArrChartData() As String, ByVal Filtro As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT distinct PaginaWeb.[PaginaWebStereotype] AS Grupo "
        sSQL = sSQL & "FROM PaginaWeb "
        sSQL = sSQL & "WHERE (((PaginaWeb.PaginaWebStereotype) LIKE ('%" & Filtro & "%')))"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("Grupo").ToString
                i = i + 1
            End While
            LeerPaginaWebStereotypeParaAutocomplete = True
            dtr.Close()
        Catch
            LeerPaginaWebStereotypeParaAutocomplete = False
        End Try
    End Function
    Public Function LeerPaginaWebUserControlParaAutocomplete(ByRef ArrChartData() As String, ByVal Filtro As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT distinct PaginaWeb.[PaginaWebUserControl] AS Grupo "
        sSQL = sSQL & "FROM PaginaWeb "
        sSQL = sSQL & "WHERE (((PaginaWeb.PaginaWebUserControl) LIKE ('%" & Filtro & "%')))"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("Grupo").ToString
                i = i + 1
            End While
            LeerPaginaWebUserControlParaAutocomplete = True
            dtr.Close()
        Catch
            LeerPaginaWebUserControlParaAutocomplete = False
        End Try
    End Function
    Public Function LeerFuncionCargoByNameAndSecuencia(ByVal CargosName As String, ByVal FunCargoSecuencia As Long, ByRef FunCargoId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FuncionesCargos.FunCargoId "
        sSQL = sSQL & "FROM FuncionesCargos "
        sSQL = sSQL & "WHERE ((FuncionesCargos.CargosName) = '" & CargosName & "' AND (FuncionesCargos.FunCargoSecuencia)=" & FunCargoSecuencia & ")"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                FunCargoId = CLng(dtr("FunCargoId").ToString)
            End While
            LeerFuncionCargoByNameAndSecuencia = True
            dtr.Close()
        Catch
            LeerFuncionCargoByNameAndSecuencia = False
            FunCargoId = 0
        End Try
    End Function
    Public Function CalcularNextSecuenciaFunCargo(ByVal CargosName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Max(FuncionesCargos.FunCargoSecuencia) as Maximo "
        sSQL = sSQL & "FROM (FuncionesCargos) "
        sSQL = sSQL & "WHERE ((FuncionesCargos.CargosName) = '" & CargosName & "')"

        CalcularNextSecuenciaFunCargo = 1

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                CalcularNextSecuenciaFunCargo = CLng(dtr("Maximo").ToString) + 1
            End While
            dtr.Close()
        Catch
            CalcularNextSecuenciaFunCargo = 1
        End Try
    End Function
    Public Function LeerFunCargo(ByVal FunCargoId As Long, ByRef CargosName As String, ByRef FunCargoSecuencia As Long, ByRef FunCargoCodigo As String, ByRef FunCargoNombre As String, ByRef FunCargoDescription As String, ByRef FunCargoGrupo As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select CargosName, FunCargoDescription, FunCargoSecuencia, FunCargoNombre, FunCargoGrupo, FunCargoCodigo "
        sSQL = sSQL & "FROM (FuncionesCargos) "
        sSQL = sSQL & "WHERE (((FuncionesCargos.FunCargoId) = " & FunCargoId & ")) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                CargosName = dtr("CargosName").ToString
                FunCargoSecuencia = CLng(dtr("FunCargoSecuencia").ToString)
                FunCargoCodigo = dtr("FunCargoCodigo").ToString
                FunCargoNombre = dtr("FunCargoNombre").ToString
                FunCargoDescription = dtr("FunCargoDescription").ToString
                FunCargoGrupo = dtr("FunCargoGrupo").ToString
            End While
            LeerFunCargo = True
            dtr.Close()
        Catch
            LeerFunCargo = False
        End Try
    End Function
    Public Sub CrearFormulario(ByVal NumeroPagina As Integer, ByVal TituloPagina As String, _
                                    ByVal DescripcionPagina As String, ByVal GroupValidation As String, _
                                    ByRef MyTable As Table, ByRef sumValidacion As ValidationSummary, _
                                    ByRef valTextBox As RequiredFieldValidator, ByRef REValidacion As RegularExpressionValidator, _
                                    ByRef CuValidacion As CustomValidator, ByRef CoValidacion As CompareValidator, _
                                    ByRef LoginButton As Button, ByRef CancelButton As Button, ByRef UpdateButton As Button, _
                                    ByRef NewButton As Button, ByRef SearchButton As Button, ByRef DeleteButton As Button, ByRef ReturnButton As Button)
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim m As Integer = 0
        Dim n As Integer = 0
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim MiTablaSubTab As Table
        Dim MiRowSubTab As TableRow
        Dim MiCellSubTab As TableCell

        Dim arrLabel(21) As String
        Dim arrControl(21) As String
        Dim arrGrillaLabel(21) As String
        Dim arrGrillaControl(21) As String
        Dim ArrNodesId(21) As Long
        Dim arrNodesLabel(21) As String
        Dim arrNodesControl(21) As String
        Dim arrSubNodesId(21) As Long
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
        Dim Url As String = ""
        Dim FormularioWebPId As Long = 0
        Dim FormularioWebServiceCall As String = ""

        Dim txtTextBox As TextBox
        Dim txtDropDownList As DropDownList
        Dim txtCheckBox As CheckBox
        Dim sqlSource As SqlDataSource
        Dim txtCalendar As CalendarExtender
        Dim ImgImages As Image
        Dim AutoComp As AutoCompleteExtender

        Dim sSQL As String = ""
        Dim HTMLCode As String = ""

        Dim TC As TabContainer
        Dim TP As TabPanel

        ' Primero pongo los textos de identificaci�n de la p�gina, que fueron pasados como
        ' par�metros de invocaci�n

        'Titulo
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "subtit"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl(TituloPagina))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        'Linea de Divisi�n
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.Height = "4"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("<hr />"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        'Descripci�n
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "tab_contenido"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl(DescripcionPagina))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        'Summary de Validaciones
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "tab_contenido"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        sumValidacion = New ValidationSummary
        sumValidacion.ID = "RegisterUserValidationSummary"
        sumValidacion.HeaderText = "Existen problemas con los siguientes campos del formulario"
        sumValidacion.CssClass = "tab_contenido"
        sumValidacion.ValidationGroup = GroupValidation
        Cell.Controls.Add(sumValidacion)
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        'Linea de Divisi�n
        'Row = New TableRow
        'Cell = New TableCell
        'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        'Cell.Height = "4"
        'Cell.ColumnSpan = "2"
        'Cell.Controls.Add(New LiteralControl("<hr />"))
        'Row.Cells.Add(Cell)
        'MyTable.Rows.Add(Row)

        ' A continuaci�n del t�tulo y de la descripci�n de objetivos de la p�gina se despliegan
        ' los campos que son de contexto y que no pueden ser alterados por ning�n motivo, como
        ' por ejemplo aquellos campos que son claves �nicas y que no pueden ser modificados
        ' o aquellos campos que corresponden a la foreing key hacia la tabla padre, en el
        ' caso de una aplicaci�n del tipo master-detail.

        ' Estos campos se encuentran en la section FormKeys y pueden no existir para determinados
        ' tipos de formularios y se leen mediante el metodo 
        ' LeerKeysFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        t = Lecturas.LeerKeysFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        If i > 0 Then

            'Linea de Divisi�n
            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Height = "4"
            Cell.ColumnSpan = "2"
            Cell.Controls.Add(New LiteralControl("<hr />"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)

            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "FormKeys", GroupValidation, NumeroPagina, k + 1)
                Row = New TableRow
                Cell = New TableCell
                Cell.CssClass = CssClassLabel
                Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
                Cell.Style(HtmlTextWriterStyle.Width) = "20%"
                Cell.Controls.Add(New LiteralControl(arrLabel(k) & " : "))
                Row.Cells.Add(Cell)
                Cell = New TableCell
                Cell.Style(HtmlTextWriterStyle.Width) = "80%"
                txtTextBox = New TextBox
                txtTextBox.ID = arrControl(k)
                txtTextBox.ClientIDMode = ClientIDMode.Static
                txtTextBox.CssClass = CssClassControl
                txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                txtTextBox.TextMode = ControlTextMode
                If ControlTextMode = 1 Then
                    txtTextBox.Height = "50"
                End If
                txtTextBox.ToolTip = ToolTip
                If IsNotEnabledField Then
                    txtTextBox.Enabled = False
                End If
                Cell.Controls.Add(txtTextBox)
                Row.Cells.Add(Cell)
                MyTable.Rows.Add(Row)
            Next


        End If

        i = 0

        ' A continuaci�n leo el registro de cabecera del formulario y desde el cual derivan el
        ' resto de los registros que indican sus atributos y sus acciones
        ' Este registro se identifica pues es el �nico del formulario que pertenece a la 
        ' section FormHeader y se lee con el metodo: LeerHeaderFormularioWeb, que devuelve
        ' una �nica variable cuyo valor gobierna las siguientes decisiones de despliegue de los 
        ' atributos del formulario web, para ello este metodo se implementa como una funci�n que 
        ' devuelve un �nico campo booleano que puede poseer los siguientes valores:

        '   False:  No se encontro registro de cabecera, en cuyo caso el formulario es plano y no
        '           requiere un recorrido recursivo para ir desplegando sus atributos.
        '   ------------------------------------------------------------------------------------
        '   True:  Se encontro registro de cabecera y ello indica que el formulario debe ser recorrido
        '           en forma recursiva a continuaci�n del despliegue de los campos clave, siempre y cuando
        '           estos existan como atributos del formulario.
        t = Lecturas.LeerHeaderFormularioWeb(arrLabel, arrControl, NumeroPagina, i, FormularioWebPId)

        If i = 1 Then ' Se encontro un registro de cabecera para el formulario web
            ' Aqui se implementa la lectura recursiva del formulario web
            ' La lectura del Header del Formulario nos trae el Id del registro de Header, cuyo valor
            ' actua como ParentId de los registros que deben ser leidos a continuaci�n de la lectura 
            ' del Header.

            ' Los registros que vienen a continuaci�n son de dos grandes tipos:
            ' Registros que identifican un control del tipo Contenedor y
            ' Registros que identifican un control que corresponde a un atributo de una tabla.


            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.ColumnSpan = "2"

            'La variable Cell actuara como contenedor de todo lo que resulte de recorrer recursivamente
            'los registros padre-hijo del formulario web.

            TC = New TabContainer
            'TC.ID = "DynamicTab" & FormularioWebPId
            TC.Height = "150"
            TC.OnClientActiveTabChanged = "ActiveTabChanged"
            ' Primer Tab Panel: Con k corren los paneles


            i = 0
            t = Lecturas.LeerNodesFormularioWeb(arrLabel, arrControl, ArrNodesId, i, FormularioWebPId)

            'Esta lectura me da los nodos de cabecera y que por ahora interpretaremos como los 
            'TabPanel del Tab Container.

            ' Luego ya leyendo los registros tendremos dos tipos de contenedores adicionales, que ser�n 
            ' los hijos de los TabPanel.

            ' Estos dos contenedores son del tipo Table y Panel.

            ' Siempre despues de un tipo Panel deber� venir un contenedor del tipo Table.

            ' Siempre despu�s de un tipo Table debera venir o un contenedor de tipo Panel o
            ' directamente un control del tipo Hoja y que corresponde a un control de texto de
            ' entrada o presentaci�n de datos o bien un contenedor de controles del tipo button.

            ' Un contenedor de controles del tipo button se implementara siempre como una tabla con 
            ' una sola fila y dos columnas, en donde la columna de la derecha es la contenedora de
            ' los botones.

            ' Bueno, ahora esto hay que hacerlo funcionar.

            ' He dicho, 24 de Julio de 2010 a las 12:14 horas.

            ' Vamos a copiar la misma logica del men� accordion

            If i > 0 Then


                For k = 0 To i - 1

                    TP = New TabPanel
                    'TP.ID = "TabPanel" & arrControl(k)
                    TP.HeaderText = arrLabel(k)
                    TP.CssClass = "tab_contenido"
                    'Agrega el contenedor
                    TP.Controls.Add(New LiteralControl("<contenttemplate>"))

                    'Aqui voy, por ahora supondremos que s�lo tenemos tabs que actuaran de contenedores
                    'de atributos y que por ahora no dejamos usar otros agrupadores, luego programaremos
                    'el resto del comportamiento esperado

                    'Call AgregarControlesPorTab(ArrNodesId(k), Celda, NumeroPagina, GroupValidation, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion)

                    'Aqui se agrego todo el c�digo necesario para dibujar la tabla de controles bajo cada Tab

                    n = 0
                    t = Lecturas.LeerNodesFormularioWeb(arrNodesLabel, arrNodesControl, arrSubNodesId, n, ArrNodesId(k))

                    MiTablaSubTab = New Table
                    MiTablaSubTab.ID = "SubTabla" & arrControl(k)
                    MiTablaSubTab.CellSpacing = "2"
                    MiTablaSubTab.CellPadding = "2"

                    'Controles del Formulario Web
                    For m = 0 To n - 1
                        t = Lecturas.LeerLeafFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, GroupValidation, FormularioWebServiceCall, arrSubNodesId(m))
                        MiRowSubTab = New TableRow
                        MiCellSubTab = New TableCell
                        MiCellSubTab.CssClass = CssClassLabel
                        MiCellSubTab.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
                        MiCellSubTab.Style(HtmlTextWriterStyle.Width) = "20%"
                        MiCellSubTab.Controls.Add(New LiteralControl(arrNodesLabel(m) & " : "))
                        MiRowSubTab.Cells.Add(MiCellSubTab)
                        MiCellSubTab = New TableCell
                        MiCellSubTab.Style(HtmlTextWriterStyle.Width) = "80%"
                        Select Case TipoControl
                            Case "TextBox"
                                txtTextBox = New TextBox
                                txtTextBox.ID = arrNodesControl(m)
                                txtTextBox.ClientIDMode = ClientIDMode.Static
                                txtTextBox.CssClass = CssClassControl
                                txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                txtTextBox.TextMode = ControlTextMode
                                If ControlTextMode = 1 Then
                                    txtTextBox.Height = "50"
                                End If
                                txtTextBox.ToolTip = ToolTip
                                If IsNotEnabledField Then
                                    txtTextBox.Enabled = False
                                End If
                                MiCellSubTab.Controls.Add(txtTextBox)
                            Case "TextBoxAutoComplete"
                                txtTextBox = New TextBox
                                txtTextBox.ID = arrNodesControl(m)
                                txtTextBox.ClientIDMode = ClientIDMode.Static
                                txtTextBox.CssClass = CssClassControl
                                txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                txtTextBox.TextMode = ControlTextMode
                                If ControlTextMode = 1 Then
                                    txtTextBox.Height = "50"
                                End If
                                txtTextBox.ToolTip = ToolTip
                                If IsNotEnabledField Then
                                    txtTextBox.Enabled = False
                                End If
                                MiCellSubTab.Controls.Add(txtTextBox)
                                AutoComp = New AutoCompleteExtender
                                AutoComp.ID = "Autocomplete" & arrNodesControl(m)
                                AutoComp.ClientIDMode = UI.ClientIDMode.Static
                                AutoComp.CompletionListItemCssClass = CssClassControl
                                AutoComp.TargetControlID = arrNodesControl(m)
                                AutoComp.ServicePath = "AutoComplete.asmx"
                                AutoComp.ServiceMethod = FormularioWebServiceCall
                                AutoComp.MinimumPrefixLength = "2"
                                AutoComp.CompletionInterval = "1000"
                                AutoComp.EnableCaching = "true"
                                AutoComp.CompletionSetCount = "12"
                                MiCellSubTab.Controls.Add(AutoComp)
                            Case "TextBoxCalendar"
                                txtTextBox = New TextBox
                                txtTextBox.ID = arrNodesControl(m)
                                txtTextBox.ClientIDMode = ClientIDMode.Static
                                txtTextBox.CssClass = CssClassControl
                                txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                txtTextBox.TextMode = ControlTextMode
                                txtTextBox.ToolTip = ToolTip
                                If IsNotEnabledField Then
                                    txtTextBox.Enabled = False
                                End If
                                MiCellSubTab.Controls.Add(txtTextBox)
                                MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                ImgImages = New Image
                                ImgImages.ID = "Image" & arrNodesControl(m)
                                ImgImages.ClientIDMode = UI.ClientIDMode.Static
                                ImgImages.ImageUrl = "img/Calendar_scheduleHS.png"
                                ImgImages.ImageAlign = ImageAlign.Middle
                                MiCellSubTab.Controls.Add(ImgImages)
                                txtCalendar = New CalendarExtender
                                txtCalendar.ID = "Calendar" & arrNodesControl(m)
                                txtCalendar.ClientIDMode = UI.ClientIDMode.Static
                                txtCalendar.TargetControlID = arrNodesControl(m)
                                txtCalendar.PopupButtonID = "Image" & arrNodesControl(m)
                                txtCalendar.Format = "dd/MMM/yy"
                                MiCellSubTab.Controls.Add(txtCalendar)
                            Case "DropDownList"
                                txtDropDownList = New DropDownList
                                txtDropDownList.ID = arrNodesControl(m)
                                txtDropDownList.ClientIDMode = ClientIDMode.Static
                                txtDropDownList.CssClass = CssClassControl
                                txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                txtDropDownList.ToolTip = ToolTip
                                txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                txtDropDownList.DataTextField = DataTextField
                                MiCellSubTab.Controls.Add(txtDropDownList)

                                sqlSource  = New SqlDataSource()                    
                                sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                sqlSource.SelectCommand = SelectCommand

                                sqlSource.ID = "ds" & arrNodesControl(m)
                                'sqlSource.DataFile = DataFile
                                'sqlSource.SelectCommand = SelectCommand
                                MiCellSubTab.Controls.Add(sqlSource)
                            Case "DropDownSearch"
                                txtCheckBox = New CheckBox
                                txtCheckBox.ID = "chk" & arrNodesControl(m)
                                txtCheckBox.ClientIDMode = ClientIDMode.Static
                                txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrNodesLabel(m)
                                MiCellSubTab.Controls.Add(txtCheckBox)
                                MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                txtDropDownList = New DropDownList
                                txtDropDownList.ID = arrNodesControl(m)
                                txtDropDownList.ClientIDMode = ClientIDMode.Static
                                txtDropDownList.CssClass = CssClassControl
                                txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                txtDropDownList.ToolTip = ToolTip
                                txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                txtDropDownList.DataTextField = DataTextField
                                MiCellSubTab.Controls.Add(txtDropDownList)


                                sqlSource  = New SqlDataSource()                    
                                sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                sqlSource.SelectCommand = SelectCommand

                                sqlSource.ID = "ds" & arrNodesControl(m)
                                'sqlSource.DataFile = DataFile
                                'sqlSource.SelectCommand = SelectCommand
                                MiCellSubTab.Controls.Add(sqlSource)

                        End Select

                        If IsRequiredField Then
                            valTextBox = New RequiredFieldValidator
                            valTextBox.ID = "RequiredField" & arrNodesControl(m)
                            valTextBox.ControlToValidate = arrNodesControl(m)
                            valTextBox.ClientIDMode = ClientIDMode.Static
                            valTextBox.Text = "*"
                            valTextBox.ErrorMessage = arrNodesLabel(m) & " es un campo obligatorio"
                            valTextBox.CssClass = "tab_contenido"
                            valTextBox.ValidationGroup = GroupValidation
                            MiCellSubTab.Controls.Add(valTextBox)
                        End If
                        Select Case DomainField
                            Case "Correo"
                                REValidacion = New RegularExpressionValidator
                                REValidacion.ID = "RegularExpression" & arrNodesControl(m)
                                REValidacion.ControlToValidate = arrNodesControl(m)
                                REValidacion.ClientIDMode = ClientIDMode.Static
                                REValidacion.Text = "*"
                                REValidacion.ErrorMessage = "La direcci�n de correo no tiene un formato valido"
                                REValidacion.CssClass = "tab_contenido"
                                REValidacion.ValidationGroup = GroupValidation
                                REValidacion.ValidationExpression = "\S+@\S+\.\S{2,3}"
                                MiCellSubTab.Controls.Add(REValidacion)
                            Case "RUT"
                                CuValidacion = New CustomValidator
                                CuValidacion.ID = "RutValidator" & arrNodesControl(m)
                                CuValidacion.ControlToValidate = arrNodesControl(m)
                                CuValidacion.ClientIDMode = ClientIDMode.Static
                                CuValidacion.Text = "*"
                                CuValidacion.ErrorMessage = "El RUT no es valido"
                                CuValidacion.CssClass = "tab_contenido"
                                CuValidacion.ValidationGroup = GroupValidation
                                CuValidacion.EnableClientScript = True
                                CuValidacion.ClientValidationFunction = "RutValidator_ClientValidate"
                                MiCellSubTab.Controls.Add(CuValidacion)
                            Case "Numeros"
                                CoValidacion = New CompareValidator
                                CoValidacion.ID = "CompareValidator" & arrNodesControl(m)
                                CoValidacion.ControlToValidate = arrNodesControl(m)
                                CoValidacion.ClientIDMode = ClientIDMode.Static
                                CoValidacion.Text = "*"
                                CoValidacion.ErrorMessage = arrNodesLabel(m) & " debe ser un valor num�rico"
                                CoValidacion.CssClass = "tab_contenido"
                                CoValidacion.ValidationGroup = GroupValidation
                                CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                                CoValidacion.Type = ValidationDataType.Integer
                                MiCellSubTab.Controls.Add(CoValidacion)
                            Case "Letras"
                                CoValidacion = New CompareValidator
                                CoValidacion.ID = "CompareValidator" & arrNodesControl(m)
                                CoValidacion.ControlToValidate = arrNodesControl(m)
                                CoValidacion.ClientIDMode = ClientIDMode.Static
                                CoValidacion.Text = "*"
                                CoValidacion.ErrorMessage = arrNodesLabel(m) & " debe ser un valor alfanum�rico"
                                CoValidacion.CssClass = "tab_contenido"
                                CoValidacion.ValidationGroup = GroupValidation
                                CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                                CoValidacion.Type = ValidationDataType.String
                                MiCellSubTab.Controls.Add(CoValidacion)
                            Case "Fecha"
                                CoValidacion = New CompareValidator
                                CoValidacion.ID = "CompareValidator" & arrNodesControl(m)
                                CoValidacion.ControlToValidate = arrNodesControl(m)
                                CoValidacion.ClientIDMode = ClientIDMode.Static
                                CoValidacion.Text = "*"
                                CoValidacion.ErrorMessage = arrNodesLabel(m) & " debe ser una fecha valida"
                                CoValidacion.CssClass = "tab_contenido"
                                CoValidacion.ValidationGroup = GroupValidation
                                CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                                CoValidacion.Type = ValidationDataType.Date
                                MiCellSubTab.Controls.Add(CoValidacion)

                        End Select
                        MiRowSubTab.Cells.Add(MiCellSubTab)
                        MiTablaSubTab.Rows.Add(MiRowSubTab)
                    Next

                    TP.Controls.Add(MiTablaSubTab)
                    TP.Controls.Add(New LiteralControl("</contenttemplate>"))
                    TC.Controls.Add(TP)
                Next
            End If
            Cell.Controls.Add(TC)
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)

            ' Hasta aqu� hemos agrupado los atributos en Tabs, pero nos faltan a�n los botones,
            ' por ahora simplemente copiaremos el c�digo que agrega los botones,luego haremos las
            ' optimizaciones

            'Botones del Formulario
            i = 0
            t = Lecturas.LeerButtonFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            Row = New TableRow
            Cell = New TableCell
            Cell.CssClass = CssClassLabel
            Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
            Cell.Style(HtmlTextWriterStyle.Width) = "20%"
            Row.Cells.Add(Cell)
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.Width) = "80%"
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Button", GroupValidation, NumeroPagina, k + 1)
                Select Case arrControl(k)
                    Case "LoginButton"
                        LoginButton = New Button
                        LoginButton.ID = arrControl(k)
                        LoginButton.CssClass = CssClassControl
                        LoginButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        LoginButton.Text = arrLabel(k)
                        LoginButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            LoginButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler LoginButton.Click, AddressOf RFC_Login
                        Cell.Controls.Add(LoginButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "CancelButton"
                        CancelButton = New Button
                        CancelButton.ID = arrControl(k)
                        CancelButton.CssClass = CssClassControl
                        CancelButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        CancelButton.Text = arrLabel(k)
                        CancelButton.ToolTip = ToolTip
                        'AddHandler CancelButton.Click, AddressOf RFC_Logout
                        Cell.Controls.Add(CancelButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "UpdateButton"
                        UpdateButton = New Button
                        UpdateButton.ID = arrControl(k)
                        UpdateButton.CssClass = CssClassControl
                        UpdateButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        UpdateButton.Text = arrLabel(k)
                        UpdateButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            UpdateButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(UpdateButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "NewButton"
                        NewButton = New Button
                        NewButton.ID = arrControl(k)
                        NewButton.CssClass = CssClassControl
                        NewButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        NewButton.Text = arrLabel(k)
                        NewButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            NewButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(NewButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "SearchButton"
                        SearchButton = New Button
                        SearchButton.ID = arrControl(k)
                        SearchButton.CssClass = CssClassControl
                        SearchButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        SearchButton.Text = arrLabel(k)
                        SearchButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            SearchButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(SearchButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "DeleteButton"
                        DeleteButton = New Button
                        DeleteButton.ID = arrControl(k)
                        DeleteButton.CssClass = CssClassControl
                        DeleteButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        DeleteButton.Text = arrLabel(k)
                        DeleteButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            DeleteButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler DeleteButton.Click, AddressOf RFC_Delete
                        Cell.Controls.Add(DeleteButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "ReturnButton"
                        ReturnButton = New Button
                        ReturnButton.ID = arrControl(k)
                        ReturnButton.CssClass = CssClassControl
                        ReturnButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        ReturnButton.Text = arrLabel(k)
                        ReturnButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            ReturnButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler ReturnButton.Click, AddressOf RFC_Return
                        Cell.Controls.Add(ReturnButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                End Select
            Next

            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)







        Else

            'Linea de Divisi�n
            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Height = "4"
            Cell.ColumnSpan = "2"
            Cell.Controls.Add(New LiteralControl("<hr />"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)

            i = 0
            t = Lecturas.LeerLabelFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

            'Controles del Formulario Web
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Form", GroupValidation, NumeroPagina, k + 1)
                Row = New TableRow
                Cell = New TableCell
                Cell.CssClass = CssClassLabel
                Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
                Cell.Style(HtmlTextWriterStyle.Width) = "20%"
                Cell.Controls.Add(New LiteralControl(arrLabel(k) & " : "))
                Row.Cells.Add(Cell)
                Cell = New TableCell
                Cell.Style(HtmlTextWriterStyle.Width) = "80%"
                Select Case TipoControl
                    Case "TextBox"
                        txtTextBox = New TextBox
                        txtTextBox.ID = arrControl(k)
                        txtTextBox.ClientIDMode = ClientIDMode.Static
                        txtTextBox.CssClass = CssClassControl
                        txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        txtTextBox.TextMode = ControlTextMode
                        If ControlTextMode = 1 Then
                            txtTextBox.Height = "50"
                        End If
                        txtTextBox.ToolTip = ToolTip
                        If IsNotEnabledField Then
                            txtTextBox.Enabled = False
                        End If
                        Cell.Controls.Add(txtTextBox)
                    Case "TextBoxAutoComplete"
                        txtTextBox = New TextBox
                        txtTextBox.ID = arrControl(k)
                        txtTextBox.ClientIDMode = ClientIDMode.Static
                        txtTextBox.CssClass = CssClassControl
                        txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        txtTextBox.TextMode = ControlTextMode
                        If ControlTextMode = 1 Then
                            txtTextBox.Height = "50"
                        End If
                        txtTextBox.ToolTip = ToolTip
                        If IsNotEnabledField Then
                            txtTextBox.Enabled = False
                        End If
                        Cell.Controls.Add(txtTextBox)
                        AutoComp = New AutoCompleteExtender
                        AutoComp.ID = "Autocomplete" & arrControl(k)
                        AutoComp.ClientIDMode = UI.ClientIDMode.Static
                        AutoComp.CompletionListItemCssClass = CssClassControl
                        AutoComp.TargetControlID = arrControl(k)
                        AutoComp.ServicePath = "AutoComplete.asmx"
                        AutoComp.ServiceMethod = Lecturas.LeerNombreMetodoAutocomplete("Form", NumeroPagina, k + 1)  ' Aqui hay que invocar un metodo para traer el nombre del m�todo
                        AutoComp.MinimumPrefixLength = "2"
                        AutoComp.CompletionInterval = "1000"
                        AutoComp.EnableCaching = "true"
                        AutoComp.CompletionSetCount = "12"
                        Cell.Controls.Add(AutoComp)
                    Case "TextBoxCalendar"
                        txtTextBox = New TextBox
                        txtTextBox.ID = arrControl(k)
                        txtTextBox.ClientIDMode = ClientIDMode.Static
                        txtTextBox.CssClass = CssClassControl
                        txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        txtTextBox.TextMode = ControlTextMode
                        txtTextBox.ToolTip = ToolTip
                        If IsNotEnabledField Then
                            txtTextBox.Enabled = False
                        End If
                        Cell.Controls.Add(txtTextBox)
                        Cell.Controls.Add(New LiteralControl(" "))
                        ImgImages = New Image
                        ImgImages.ID = "Image" & arrControl(k)
                        ImgImages.ClientIDMode = UI.ClientIDMode.Static
                        ImgImages.ImageUrl = "img/Calendar_scheduleHS.png"
                        ImgImages.ImageAlign = ImageAlign.Middle
                        Cell.Controls.Add(ImgImages)
                        txtCalendar = New CalendarExtender
                        txtCalendar.ID = "Calendar" & arrControl(k)
                        txtCalendar.ClientIDMode = UI.ClientIDMode.Static
                        txtCalendar.TargetControlID = arrControl(k)
                        txtCalendar.PopupButtonID = "Image" & arrControl(k)
                        txtCalendar.Format = "dd/MMM/yy"
                        Cell.Controls.Add(txtCalendar)
                    Case "DropDownList"
                        txtDropDownList = New DropDownList
                        txtDropDownList.ID = arrControl(k)
                        txtDropDownList.ClientIDMode = ClientIDMode.Static
                        txtDropDownList.CssClass = CssClassControl
                        txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        txtDropDownList.ToolTip = ToolTip
                        txtDropDownList.DataSourceID = "ds" & arrControl(k)
                        txtDropDownList.DataTextField = DataTextField
                        Cell.Controls.Add(txtDropDownList)

                        sqlSource  = New SqlDataSource()                    
                        sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                        sqlSource.SelectCommand = SelectCommand

                        sqlSource.ID = "ds" & arrControl(k)
                        'sqlSource.DataFile = DataFile
                        'sqlSource.SelectCommand = SelectCommand
                        Cell.Controls.Add(sqlSource)
                    Case "DropDownSearch"
                        txtCheckBox = New CheckBox
                        txtCheckBox.ID = "chk" & arrControl(k)
                        txtCheckBox.ClientIDMode = ClientIDMode.Static
                        txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrLabel(k)
                        Cell.Controls.Add(txtCheckBox)
                        Cell.Controls.Add(New LiteralControl(" "))
                        txtDropDownList = New DropDownList
                        txtDropDownList.ID = arrControl(k)
                        txtDropDownList.ClientIDMode = ClientIDMode.Static
                        txtDropDownList.CssClass = CssClassControl
                        txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        txtDropDownList.ToolTip = ToolTip
                        txtDropDownList.DataSourceID = "ds" & arrControl(k)
                        txtDropDownList.DataTextField = DataTextField
                        Cell.Controls.Add(txtDropDownList)


                        sqlSource  = New SqlDataSource()                   
                        sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                        sqlSource.SelectCommand = SelectCommand

                        sqlSource.ID = "ds" & arrControl(k)
                        'sqlSource.DataFile = DataFile
                        'sqlSource.SelectCommand = SelectCommand
                        Cell.Controls.Add(sqlSource)

                End Select

                Row.Cells.Add(Cell)

                If IsRequiredField Then
                    valTextBox = New RequiredFieldValidator
                    valTextBox.ID = "RequiredField" & arrControl(k)
                    valTextBox.ControlToValidate = arrControl(k)
                    valTextBox.Text = "*"
                    valTextBox.ErrorMessage = arrLabel(k) & " es un campo obligatorio"
                    valTextBox.CssClass = "tab_contenido"
                    valTextBox.ValidationGroup = GroupValidation
                    Cell.Controls.Add(valTextBox)
                End If
                Select Case DomainField
                    Case "Correo"
                        REValidacion = New RegularExpressionValidator
                        REValidacion.ID = "RegularExpression" & arrControl(k)
                        REValidacion.ControlToValidate = arrControl(k)
                        REValidacion.Text = "*"
                        REValidacion.ErrorMessage = "La direcci�n de correo no tiene un formato valido"
                        REValidacion.CssClass = "tab_contenido"
                        REValidacion.ValidationGroup = GroupValidation
                        REValidacion.ValidationExpression = "\S+@\S+\.\S{2,3}"
                        Cell.Controls.Add(REValidacion)
                    Case "RUT"
                        CuValidacion = New CustomValidator
                        CuValidacion.ID = "RutValidator" & arrControl(k)
                        CuValidacion.ControlToValidate = arrControl(k)
                        CuValidacion.Text = "*"
                        CuValidacion.ErrorMessage = "El RUT no es valido"
                        CuValidacion.CssClass = "tab_contenido"
                        CuValidacion.ValidationGroup = GroupValidation
                        CuValidacion.EnableClientScript = True
                        CuValidacion.ClientValidationFunction = "RutValidator_ClientValidate"
                        Cell.Controls.Add(CuValidacion)
                    Case "Numeros"
                        CoValidacion = New CompareValidator
                        CoValidacion.ID = "CompareValidator" & arrControl(k)
                        CoValidacion.ControlToValidate = arrControl(k)
                        CoValidacion.Text = "*"
                        CoValidacion.ErrorMessage = arrLabel(k) & " debe ser un valor num�rico"
                        CoValidacion.CssClass = "tab_contenido"
                        CoValidacion.ValidationGroup = GroupValidation
                        CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                        CoValidacion.Type = ValidationDataType.Integer
                        Cell.Controls.Add(CoValidacion)
                    Case "Letras"
                        CoValidacion = New CompareValidator
                        CoValidacion.ID = "CompareValidator" & arrControl(k)
                        CoValidacion.ControlToValidate = arrControl(k)
                        CoValidacion.Text = "*"
                        CoValidacion.ErrorMessage = arrLabel(k) & " debe ser un valor alfanum�rico"
                        CoValidacion.CssClass = "tab_contenido"
                        CoValidacion.ValidationGroup = GroupValidation
                        CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                        CoValidacion.Type = ValidationDataType.String
                        Cell.Controls.Add(CoValidacion)
                    Case "Fecha"
                        CoValidacion = New CompareValidator
                        CoValidacion.ID = "CompareValidator" & arrControl(k)
                        CoValidacion.ControlToValidate = arrControl(k)
                        CoValidacion.Text = "*"
                        CoValidacion.ErrorMessage = arrLabel(k) & " debe ser una fecha valida"
                        CoValidacion.CssClass = "tab_contenido"
                        CoValidacion.ValidationGroup = GroupValidation
                        CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                        CoValidacion.Type = ValidationDataType.Date
                        Cell.Controls.Add(CoValidacion)

                End Select
                MyTable.Rows.Add(Row)
            Next

            'Linea de Divisi�n
            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Height = "4"
            Cell.ColumnSpan = "2"
            Cell.Controls.Add(New LiteralControl("<hr />"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)

            'Botones del Formulario
            i = 0
            t = Lecturas.LeerButtonFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            Row = New TableRow
            Cell = New TableCell
            Cell.CssClass = CssClassLabel
            Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
            Cell.Style(HtmlTextWriterStyle.Width) = "20%"
            Row.Cells.Add(Cell)
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.Width) = "80%"
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Button", GroupValidation, NumeroPagina, k + 1)
                Select Case arrControl(k)
                    Case "LoginButton"
                        LoginButton = New Button
                        LoginButton.ID = arrControl(k)
                        LoginButton.CssClass = CssClassControl
                        LoginButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        LoginButton.Text = arrLabel(k)
                        LoginButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            LoginButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler LoginButton.Click, AddressOf RFC_Login
                        Cell.Controls.Add(LoginButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "CancelButton"
                        CancelButton = New Button
                        CancelButton.ID = arrControl(k)
                        CancelButton.CssClass = CssClassControl
                        CancelButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        CancelButton.Text = arrLabel(k)
                        CancelButton.ToolTip = ToolTip
                        'AddHandler CancelButton.Click, AddressOf RFC_Logout
                        Cell.Controls.Add(CancelButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "UpdateButton"
                        UpdateButton = New Button
                        UpdateButton.ID = arrControl(k)
                        UpdateButton.CssClass = CssClassControl
                        UpdateButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        UpdateButton.Text = arrLabel(k)
                        UpdateButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            UpdateButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(UpdateButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "NewButton"
                        NewButton = New Button
                        NewButton.ID = arrControl(k)
                        NewButton.CssClass = CssClassControl
                        NewButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        NewButton.Text = arrLabel(k)
                        NewButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            NewButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(NewButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "SearchButton"
                        SearchButton = New Button
                        SearchButton.ID = arrControl(k)
                        SearchButton.CssClass = CssClassControl
                        SearchButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        SearchButton.Text = arrLabel(k)
                        SearchButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            SearchButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(SearchButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "DeleteButton"
                        DeleteButton = New Button
                        DeleteButton.ID = arrControl(k)
                        DeleteButton.CssClass = CssClassControl
                        DeleteButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        DeleteButton.Text = arrLabel(k)
                        DeleteButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            DeleteButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler DeleteButton.Click, AddressOf RFC_Delete
                        Cell.Controls.Add(DeleteButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "ReturnButton"
                        ReturnButton = New Button
                        ReturnButton.ID = arrControl(k)
                        ReturnButton.CssClass = CssClassControl
                        ReturnButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        ReturnButton.Text = arrLabel(k)
                        ReturnButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            ReturnButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler ReturnButton.Click, AddressOf RFC_Return
                        Cell.Controls.Add(ReturnButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                End Select
            Next

            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
        End If
    End Sub
    Sub AgregarControlesPorTab(ByVal FormularioWebPID As Long, ByRef Celda As TableCell, ByVal NumeroPagina As Long, _
                                    ByVal GroupValidation As String, _
                                    ByRef sumValidacion As ValidationSummary, _
                                    ByRef valTextBox As RequiredFieldValidator, ByRef REValidacion As RegularExpressionValidator, _
                                    ByRef CuValidacion As CustomValidator, ByRef CoValidacion As CompareValidator)
        ' Al final este codigo fue incorporado directamente dentro de la rutina CrearFormulario


        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim m As Integer = 0
        Dim n As Integer = 0
        Dim MiTablaSubTab As Table
        Dim MiRowSubTab As TableRow
        Dim MiCellSubTab As TableCell
        Dim arrNodesLabel(21) As String
        Dim arrNodesControl(21) As String
        Dim arrGrillaLabel(21) As String
        Dim arrGrillaControl(21) As String
        Dim arrSubNodesId(21) As Long
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
        Dim Url As String = ""
        Dim FormularioWebServiceCall As String = ""


        Dim txtTextBox As TextBox
        Dim txtDropDownList As DropDownList
        Dim txtCheckBox As CheckBox
        Dim sqlSource As SqlDataSource
        Dim txtCalendar As CalendarExtender
        Dim ImgImages As Image
        Dim AutoComp As AutoCompleteExtender

        Dim sSQL As String = ""
        Dim HTMLCode As String = ""

        n = 0
        t = Lecturas.LeerNodesFormularioWeb(arrNodesLabel, arrNodesControl, arrSubNodesId, n, FormularioWebPID)

        MiTablaSubTab = New Table
        'Controles del Formulario Web
        For m = 0 To n - 1
            t = Lecturas.LeerLeafFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, GroupValidation, FormularioWebServiceCall, arrSubNodesId(m))
            MiRowSubTab = New TableRow
            MiCellSubTab = New TableCell
            MiCellSubTab.CssClass = CssClassLabel
            MiCellSubTab.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
            MiCellSubTab.Style(HtmlTextWriterStyle.Width) = "20%"
            MiCellSubTab.Controls.Add(New LiteralControl(arrNodesLabel(m) & " : "))
            MiRowSubTab.Cells.Add(MiCellSubTab)
            MiCellSubTab = New TableCell
            MiCellSubTab.Style(HtmlTextWriterStyle.Width) = "80%"
            Select Case TipoControl
                Case "TextBox"
                    txtTextBox = New TextBox
                    txtTextBox.ID = arrNodesControl(m)
                    txtTextBox.ClientIDMode = ClientIDMode.Static
                    txtTextBox.CssClass = CssClassControl
                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    txtTextBox.TextMode = ControlTextMode
                    If ControlTextMode = 1 Then
                        txtTextBox.Height = "50"
                    End If
                    txtTextBox.ToolTip = ToolTip
                    If IsNotEnabledField Then
                        txtTextBox.Enabled = False
                    End If
                    MiCellSubTab.Controls.Add(txtTextBox)
                Case "TextBoxAutoComplete"
                    txtTextBox = New TextBox
                    txtTextBox.ID = arrNodesControl(m)
                    txtTextBox.ClientIDMode = ClientIDMode.Static
                    txtTextBox.CssClass = CssClassControl
                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    txtTextBox.TextMode = ControlTextMode
                    If ControlTextMode = 1 Then
                        txtTextBox.Height = "50"
                    End If
                    txtTextBox.ToolTip = ToolTip
                    If IsNotEnabledField Then
                        txtTextBox.Enabled = False
                    End If
                    MiCellSubTab.Controls.Add(txtTextBox)
                    AutoComp = New AutoCompleteExtender
                    AutoComp.ID = "Autocomplete" & arrNodesControl(m)
                    AutoComp.ClientIDMode = UI.ClientIDMode.Static
                    AutoComp.CompletionListItemCssClass = CssClassControl
                    AutoComp.TargetControlID = arrNodesControl(m)
                    AutoComp.ServicePath = "AutoComplete.asmx"
                    AutoComp.ServiceMethod = FormularioWebServiceCall
                    AutoComp.MinimumPrefixLength = "2"
                    AutoComp.CompletionInterval = "1000"
                    AutoComp.EnableCaching = "true"
                    AutoComp.CompletionSetCount = "12"
                    MiCellSubTab.Controls.Add(AutoComp)
                Case "TextBoxCalendar"
                    txtTextBox = New TextBox
                    txtTextBox.ID = arrNodesControl(m)
                    txtTextBox.ClientIDMode = ClientIDMode.Static
                    txtTextBox.CssClass = CssClassControl
                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    txtTextBox.TextMode = ControlTextMode
                    txtTextBox.ToolTip = ToolTip
                    If IsNotEnabledField Then
                        txtTextBox.Enabled = False
                    End If
                    MiCellSubTab.Controls.Add(txtTextBox)
                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                    ImgImages = New Image
                    ImgImages.ID = "Image" & arrNodesControl(m)
                    ImgImages.ClientIDMode = UI.ClientIDMode.Static
                    ImgImages.ImageUrl = "img/Calendar_scheduleHS.png"
                    ImgImages.ImageAlign = ImageAlign.Middle
                    MiCellSubTab.Controls.Add(ImgImages)
                    txtCalendar = New CalendarExtender
                    txtCalendar.ID = "Calendar" & arrNodesControl(m)
                    txtCalendar.ClientIDMode = UI.ClientIDMode.Static
                    txtCalendar.TargetControlID = arrNodesControl(m)
                    txtCalendar.PopupButtonID = "Image" & arrNodesControl(m)
                    txtCalendar.Format = "dd/MMM/yy"
                    MiCellSubTab.Controls.Add(txtCalendar)
                Case "DropDownList"
                    txtDropDownList = New DropDownList
                    txtDropDownList.ID = arrNodesControl(m)
                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                    txtDropDownList.CssClass = CssClassControl
                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    txtDropDownList.ToolTip = ToolTip
                    txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                    txtDropDownList.DataTextField = DataTextField
                    MiCellSubTab.Controls.Add(txtDropDownList)


                    sqlSource  = New SqlDataSource()                    
                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                    sqlSource.SelectCommand = SelectCommand

                    sqlSource.ID = "ds" & arrNodesControl(m)
                    'sqlSource.DataFile = DataFile
                    'sqlSource.SelectCommand = SelectCommand
                    MiCellSubTab.Controls.Add(sqlSource)
                Case "DropDownSearch"
                    txtCheckBox = New CheckBox
                    txtCheckBox.ID = "chk" & arrNodesControl(m)
                    txtCheckBox.ClientIDMode = ClientIDMode.Static
                    txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrNodesLabel(m)
                    MiCellSubTab.Controls.Add(txtCheckBox)
                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                    txtDropDownList = New DropDownList
                    txtDropDownList.ID = arrNodesControl(m)
                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                    txtDropDownList.CssClass = CssClassControl
                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    txtDropDownList.ToolTip = ToolTip
                    txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                    txtDropDownList.DataTextField = DataTextField
                    MiCellSubTab.Controls.Add(txtDropDownList)

                    sqlSource  = New SqlDataSource()                   
                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                    sqlSource.SelectCommand = SelectCommand

                    sqlSource.ID = "ds" & arrNodesControl(m)
                    'sqlSource.DataFile = DataFile
                    'sqlSource.SelectCommand = SelectCommand
                    MiCellSubTab.Controls.Add(sqlSource)

            End Select

            If IsRequiredField Then
                valTextBox = New RequiredFieldValidator
                valTextBox.ID = "RequiredField" & arrNodesControl(m)
                valTextBox.ControlToValidate = arrNodesControl(m)
                valTextBox.ClientIDMode = ClientIDMode.Static
                valTextBox.Text = "*"
                valTextBox.ErrorMessage = arrNodesLabel(m) & " es un campo obligatorio"
                valTextBox.CssClass = "tab_contenido"
                valTextBox.ValidationGroup = GroupValidation
                MiCellSubTab.Controls.Add(valTextBox)
            End If
            Select Case DomainField
                Case "Correo"
                    REValidacion = New RegularExpressionValidator
                    REValidacion.ID = "RegularExpression" & arrNodesControl(m)
                    REValidacion.ControlToValidate = arrNodesControl(m)
                    REValidacion.ClientIDMode = ClientIDMode.Static
                    REValidacion.Text = "*"
                    REValidacion.ErrorMessage = "La direcci�n de correo no tiene un formato valido"
                    REValidacion.CssClass = "tab_contenido"
                    REValidacion.ValidationGroup = GroupValidation
                    REValidacion.ValidationExpression = "\S+@\S+\.\S{2,3}"
                    MiCellSubTab.Controls.Add(REValidacion)
                Case "RUT"
                    CuValidacion = New CustomValidator
                    CuValidacion.ID = "RutValidator" & arrNodesControl(m)
                    CuValidacion.ControlToValidate = arrNodesControl(m)
                    CuValidacion.ClientIDMode = ClientIDMode.Static
                    CuValidacion.Text = "*"
                    CuValidacion.ErrorMessage = "El RUT no es valido"
                    CuValidacion.CssClass = "tab_contenido"
                    CuValidacion.ValidationGroup = GroupValidation
                    CuValidacion.EnableClientScript = True
                    CuValidacion.ClientValidationFunction = "RutValidator_ClientValidate"
                    MiCellSubTab.Controls.Add(CuValidacion)
                Case "Numeros"
                    CoValidacion = New CompareValidator
                    CoValidacion.ID = "CompareValidator" & arrNodesControl(m)
                    CoValidacion.ControlToValidate = arrNodesControl(m)
                    CoValidacion.ClientIDMode = ClientIDMode.Static
                    CoValidacion.Text = "*"
                    CoValidacion.ErrorMessage = arrNodesLabel(m) & " debe ser un valor num�rico"
                    CoValidacion.CssClass = "tab_contenido"
                    CoValidacion.ValidationGroup = GroupValidation
                    CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                    CoValidacion.Type = ValidationDataType.Integer
                    MiCellSubTab.Controls.Add(CoValidacion)
                Case "Letras"
                    CoValidacion = New CompareValidator
                    CoValidacion.ID = "CompareValidator" & arrNodesControl(m)
                    CoValidacion.ControlToValidate = arrNodesControl(m)
                    CoValidacion.ClientIDMode = ClientIDMode.Static
                    CoValidacion.Text = "*"
                    CoValidacion.ErrorMessage = arrNodesLabel(m) & " debe ser un valor alfanum�rico"
                    CoValidacion.CssClass = "tab_contenido"
                    CoValidacion.ValidationGroup = GroupValidation
                    CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                    CoValidacion.Type = ValidationDataType.String
                    MiCellSubTab.Controls.Add(CoValidacion)
                Case "Fecha"
                    CoValidacion = New CompareValidator
                    CoValidacion.ID = "CompareValidator" & arrNodesControl(m)
                    CoValidacion.ControlToValidate = arrNodesControl(m)
                    CoValidacion.ClientIDMode = ClientIDMode.Static
                    CoValidacion.Text = "*"
                    CoValidacion.ErrorMessage = arrNodesLabel(m) & " debe ser una fecha valida"
                    CoValidacion.CssClass = "tab_contenido"
                    CoValidacion.ValidationGroup = GroupValidation
                    CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                    CoValidacion.Type = ValidationDataType.Date
                    MiCellSubTab.Controls.Add(CoValidacion)

            End Select
            MiRowSubTab.Cells.Add(MiCellSubTab)
            MiTablaSubTab.Rows.Add(MiRowSubTab)
        Next

        Celda.Controls.Add(MiTablaSubTab)

    End Sub

    Public Sub CrearVista(ByVal NumeroPagina As Integer, ByVal TituloPagina As String, ByRef MyView As PlaceHolder, ByRef UpdateButton As Button, ByRef MailButton As Button, ByRef CommentButton As Button, ByRef MuroButton As Button, ByRef AlertaButton As Button)


        '-------------------------- 26-Julio-2010 -----------------
        ' Esta nueva rutina supone trabajar con un contenedor del tipo PlaceHolder en vez del tipo
        ' table
        '----------------------------------------------------------

        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim m As Integer = 0
        Dim n As Integer = 0
        Dim kk As Integer = 0
        Dim ii As Integer = 0
        Dim mm As Integer = 0
        Dim nn As Integer = 0
        Dim MyTable As Table
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim MiTablaSubTab As Table
        Dim MiRowSubTab As TableRow
        Dim MiCellSubTab As TableCell
        Dim MiTabla12 As Table
        Dim MiRow12 As TableRow
        Dim MiCell12 As TableCell

        Dim arrLabel(24) As String
        Dim arrControl(24) As String
        Dim arrGrillaLabel(24) As String
        Dim arrGrillaControl(24) As String
        Dim ArrNodesId(24) As Long
        Dim arrNodesLabel(24) As String
        Dim arrNodesControl(24) As String
        Dim arrSubNodesId(24) As Long
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
        Dim Url As String = ""
        Dim FormularioWebPId As Long = 0
        Dim FormularioWebServiceCall As String = ""

        Dim txtTextBox As TextBox
        Dim txtDropDownList As DropDownList
        Dim txtCheckBox As CheckBox
        Dim sqlSource As SqlDataSource
        Dim txtCalendar As CalendarExtender
        Dim ImgImages As Image
        Dim AutoComp As AutoCompleteExtender
        Dim txtUploadFile As FileUpload
        Dim SaveButton As Button
        Dim UploadLink As HyperLink
        Dim txtCascadeDropDownList As CascadingDropDown


        Dim sSQL As String = ""
        Dim HTMLCode As String = ""

        Dim AnchoTablaTabs As Integer = 0
        Dim sJavaScript As String = ""

        Dim FormularioWeb As New FormularioWeb

        ' Primero se despliegan
        ' los campos que son de contexto y que no pueden ser alterados por ning�n motivo, como
        ' por ejemplo aquellos campos que son claves �nicas y que no pueden ser modificados
        ' o aquellos campos que corresponden a la foreing key hacia la tabla padre, en el
        ' caso de una aplicaci�n del tipo master-detail.

        ' Estos campos se encuentran en la section FormKeys y pueden no existir para determinados
        ' tipos de formularios y se leen mediante el metodo 
        ' LeerKeysFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        t = Lecturas.LeerKeysFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        ' A continuaci�n pongo los textos de identificaci�n de la p�gina, que fueron pasados como
        ' par�metros de invocaci�n

        If NumeroPagina <> 271 Then

            MyTable = New Table
            MyTable.ID = "ViewHeader2" & NumeroPagina
            MyTable.Width = "700"
            MyTable.CellSpacing = "2"
            MyTable.CellPadding = "2"
            MyTable.CssClass = "visible"
            'Titulo
            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.ColumnSpan = "2"
            Cell.Controls.Add(New LiteralControl("<h1>" & TituloPagina & "</h1>"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
            MyView.Controls.Add(MyTable)

        End If

        ' Bajo el nuevo esquema, creo otra tabla para los campos claves y la sumo al placeholder
        'Luego se agrega la tabla de control de validaci�n de los campos

        i = 0

        ' A continuaci�n leo el registro de cabecera del formulario y desde el cual derivan el
        ' resto de los registros que indican sus atributos y sus acciones
        ' Este registro se identifica pues es el �nico del formulario que pertenece a la 
        ' section FormHeader y se lee con el metodo: LeerHeaderFormularioWeb, que devuelve
        ' una �nica variable cuyo valor gobierna las siguientes decisiones de despliegue de los 
        ' atributos del formulario web, para ello este metodo se implementa como una funci�n que 
        ' devuelve un �nico campo booleano que puede poseer los siguientes valores:

        '   False:  No se encontro registro de cabecera, en cuyo caso el formulario es plano y no
        '           requiere un recorrido recursivo para ir desplegando sus atributos.
        '   ------------------------------------------------------------------------------------
        '   True:  Se encontro registro de cabecera y ello indica que el formulario debe ser recorrido
        '           en forma recursiva a continuaci�n del despliegue de los campos clave, siempre y cuando
        '           estos existan como atributos del formulario.
        t = Lecturas.LeerHeaderFormularioWeb(arrLabel, arrControl, NumeroPagina, i, FormularioWebPId)

        If i = 1 Then ' Se encontro un registro de cabecera para el formulario web

            ' Para emular tab container con tab panel se usaran solo tablas, con la capacidad de hacerse visibles o
            ' invisibles, dejando una sola visible a la vez.

            ' La primera tabla actuara como Tab Panel y es una tabla de una sola fila con tantas columnas como 
            ' grupos de campos tenga el formulario, para ello se hara un primer recorrido de las cabeceras encontradas

            ' Voy a usar una table en vez de un tab container

            i = 0
            t = Lecturas.LeerNodesFormularioWeb(arrLabel, arrControl, ArrNodesId, i, FormularioWebPId)
            If i > 1 Then 'Solo se despliegan tabs cuando hay m�s de 1, en el otro caso no lo amerita.
                'Creamos tabla y la �nica fila
                AnchoTablaTabs = 116 * (i + 1)
                MyTable = New Table
                MyTable.ID = "ViewBody2" & FormularioWebPId
                MyTable.Width = AnchoTablaTabs
                MyTable.CellSpacing = "2"
                MyTable.CellPadding = "2"
                Row = New TableRow
                For k = 0 To i - 1
                    sJavaScript = ""
                    For m = 0 To i - 1
                        If m = k Then
                            sJavaScript = sJavaScript & "aparecer(""sub" & arrControl(m) & "sub"");"
                        Else
                            sJavaScript = sJavaScript & "desaparecer(""sub" & arrControl(m) & "sub"");"
                        End If
                    Next
                    Cell = New TableCell
                    Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
                    Cell.Width = "120"
                    Cell.CssClass = "boxceleste"
                    Cell.Controls.Add(New LiteralControl("<a onclick='" & sJavaScript & "'>" & arrLabel(k) & "</a>"))
                    Row.Cells.Add(Cell)
                Next
                sJavaScript = ""
                For m = 0 To i - 1
                    sJavaScript = sJavaScript & "todosvisibles(""sub" & arrControl(m) & "sub"");"
                Next
                Cell = New TableCell
                Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
                Cell.Width = "120"
                Cell.CssClass = "boxceleste"
                Cell.Controls.Add(New LiteralControl("<a onclick='" & sJavaScript & "'>" & "Ver ficha completa" & "</a>"))
                Row.Cells.Add(Cell)
                MyTable.Rows.Add(Row)
                MyView.Controls.Add(MyTable)
            End If
            'Con el mismo arreglo de nodos, vuelvo a recorrerlos pero ahora por cada uno, leo sus nodos hijos
            'para asi cargos los controles del formulario web.

            If i > 0 Then
                For k = 0 To i - 1
                    n = 0
                    t = Lecturas.LeerNodesFormularioWeb(arrNodesLabel, arrNodesControl, arrSubNodesId, n, ArrNodesId(k))
                    'Aqui acabo de leer los nodos del primer tab, por ahora no hay m�s anidamiento, asi que cada nodo
                    'en arrNodesLabel es en realidad una hoja
                    MiTablaSubTab = New Table
                    MiTablaSubTab.ID = "sub" & arrControl(k) & "sub" & NumeroPagina
                    MiTablaSubTab.ClientIDMode = ClientIDMode.Static
                    MiTablaSubTab.Width = "700"
                    MiTablaSubTab.Caption = arrLabel(k)
                    MiTablaSubTab.CaptionAlign = TableCaptionAlign.Left
                    MiTablaSubTab.CellSpacing = "2"
                    MiTablaSubTab.CellPadding = "2"
                    If k = 0 Then
                        MiTablaSubTab.CssClass = "visible"
                    Else
                        MiTablaSubTab.CssClass = "invisible"
                    End If
                    MiTablaSubTab.BackColor = Drawing.Color.WhiteSmoke
                    MiTablaSubTab.BorderStyle = BorderStyle.Solid
                    MiTablaSubTab.BorderWidth = 1
                    MiTablaSubTab.BorderColor = Drawing.Color.WhiteSmoke

                    'Controles del Formulario Web
                    For m = 0 To n - 1
                        t = Lecturas.LeerLeafFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "InputValidation", FormularioWebServiceCall, arrSubNodesId(m))
                        ' Cambio introducido para dejar no visible ciertos campos
                        ' 27 de Abril de 2011
                        ' ------------------------------------------------------
                        If FormularioWeb.CampoIsVisible(arrSubNodesId(m)) = True Then
                            MiRowSubTab = New TableRow
                            MiRowSubTab.VerticalAlign = VerticalAlign.Middle
                            MiCellSubTab = New TableCell
                            MiCellSubTab.CssClass = CssClassLabel
                            MiCellSubTab.Style(HtmlTextWriterStyle.TextAlign) = "left"
                            MiCellSubTab.Style(HtmlTextWriterStyle.Width) = "20%"
                            If IsRequiredField Then
                                MiCellSubTab.Controls.Add(New LiteralControl(arrNodesLabel(m) & " (*) "))
                            Else
                                MiCellSubTab.Controls.Add(New LiteralControl(arrNodesLabel(m) & "  "))
                            End If
                            MiRowSubTab.Cells.Add(MiCellSubTab)
                            MiCellSubTab = New TableCell
                            MiCellSubTab.Style(HtmlTextWriterStyle.Width) = "80%"
                            MiCellSubTab.VerticalAlign = VerticalAlign.Middle
                            Select Case TipoControl
                                Case "TextBox"
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    If Mid(DomainField, 1, 2) = "Nb" Then
                                        txtTextBox.Style(HtmlTextWriterStyle.TextAlign) = "Right"
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                Case "TextBox12" 'Se crea para armar una fila con 12 columnas con header y campo
                                    ' Creamos una tabla que se va a subordinar a la tabla matriz

                                    MiTabla12 = New Table
                                    MiTabla12.ID = "sub" & arrNodesControl(m) & "sub"
                                    MiTabla12.ClientIDMode = ClientIDMode.Static
                                    MiTabla12.Width = "560"
                                    MiTabla12.CellSpacing = "1"
                                    MiTabla12.CellPadding = "1"
                                    MiTabla12.BackColor = Drawing.Color.WhiteSmoke
                                    MiTabla12.BorderStyle = BorderStyle.Solid
                                    MiTabla12.BorderWidth = 1
                                    MiTabla12.BorderColor = Drawing.Color.WhiteSmoke
                                    MiRow12 = New TableRow
                                    For ii = 1 To 12
                                        MiCell12 = New TableCell
                                        MiCell12.CssClass = CssClassLabel
                                        MiCell12.Style(HtmlTextWriterStyle.TextAlign) = "Center"
                                        MiCell12.Controls.Add(New LiteralControl(NombreMesCorto(ii)))
                                        MiRow12.Cells.Add(MiCell12)
                                    Next
                                    MiTabla12.Rows.Add(MiRow12)
                                    MiRow12 = New TableRow
                                    For ii = 1 To 12
                                        MiCell12 = New TableCell
                                        txtTextBox = New TextBox
                                        txtTextBox.ID = arrNodesControl(m)
                                        txtTextBox.ClientIDMode = ClientIDMode.Static
                                        txtTextBox.CssClass = CssClassControl
                                        txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                        txtTextBox.TextMode = ControlTextMode
                                        If ControlTextMode = 1 Then
                                            txtTextBox.Height = "50"
                                        End If
                                        txtTextBox.ToolTip = ToolTip
                                        If IsNotEnabledField Then
                                            txtTextBox.Enabled = False
                                        End If
                                        If Mid(DomainField, 1, 2) = "Nb" Then
                                            txtTextBox.Style(HtmlTextWriterStyle.TextAlign) = "Right"
                                        End If
                                        MiCell12.Controls.Add(txtTextBox)
                                        MiRow12.Cells.Add(MiCell12)
                                        m = m + 1
                                        If m <= n - 1 Then
                                            t = Lecturas.LeerLeafFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "InputValidation", FormularioWebServiceCall, arrSubNodesId(m))
                                        End If
                                    Next
                                    MiTabla12.Rows.Add(MiRow12)
                                    m = m - 1
                                    MiCellSubTab.Controls.Add(MiTabla12)
                                Case "CheckBox"
                                    txtCheckBox = New CheckBox
                                    txtCheckBox.ID = arrNodesControl(m)
                                    txtCheckBox.ClientIDMode = ClientIDMode.Static
                                    txtCheckBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtCheckBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtCheckBox)
                                Case "TextBoxAutoComplete"
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    AutoComp = New AutoCompleteExtender
                                    AutoComp.ID = "Autocomplete" & arrNodesControl(m)
                                    AutoComp.ClientIDMode = UI.ClientIDMode.Static
                                    AutoComp.CompletionListItemCssClass = CssClassControl
                                    AutoComp.TargetControlID = arrNodesControl(m)
                                    AutoComp.ServicePath = "AutoComplete.asmx"
                                    AutoComp.ServiceMethod = FormularioWebServiceCall
                                    AutoComp.MinimumPrefixLength = "2"
                                    AutoComp.CompletionInterval = "1000"
                                    AutoComp.EnableCaching = "true"
                                    AutoComp.CompletionSetCount = "12"
                                    MiCellSubTab.Controls.Add(AutoComp)
                                Case "TextBoxCalendar"
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ImgImages = New Image
                                    ImgImages.ID = "Image" & arrNodesControl(m)
                                    ImgImages.ClientIDMode = UI.ClientIDMode.Static
                                    ImgImages.ImageUrl = "img/Calendar_scheduleHS.png"
                                    ImgImages.ImageAlign = ImageAlign.Middle
                                    MiCellSubTab.Controls.Add(ImgImages)
                                    txtCalendar = New CalendarExtender
                                    txtCalendar.ID = "Calendar" & arrNodesControl(m)
                                    txtCalendar.ClientIDMode = UI.ClientIDMode.Static
                                    txtCalendar.TargetControlID = arrNodesControl(m)
                                    txtCalendar.PopupButtonID = "Image" & arrNodesControl(m)
                                    txtCalendar.Format = "dd/MM/yy"
                                    MiCellSubTab.Controls.Add(txtCalendar)
                                Case "DropDownList"
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = arrNodesControl(m)
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtDropDownList.ToolTip = ToolTip
                                    txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                    txtDropDownList.DataTextField = DataTextField
                                    txtDropDownList.Height = "20"
                                    MiCellSubTab.Controls.Add(txtDropDownList)

                                    sqlSource  = New SqlDataSource()                  
                                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                    sqlSource.SelectCommand = SelectCommand

                                    sqlSource.ID = "ds" & arrNodesControl(m)
                                    'sqlSource.DataFile = DataFile
                                    'sqlSource.SelectCommand = SelectCommand
                                    MiCellSubTab.Controls.Add(sqlSource)
                                Case "DropDownSearch"
                                    txtCheckBox = New CheckBox
                                    txtCheckBox.ID = "chk" & arrNodesControl(m)
                                    txtCheckBox.ClientIDMode = ClientIDMode.Static
                                    txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrNodesLabel(m)
                                    txtCheckBox.Height = "20"
                                    MiCellSubTab.Controls.Add(txtCheckBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = arrNodesControl(m)
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtDropDownList.ToolTip = ToolTip
                                    txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                    txtDropDownList.DataTextField = DataTextField
                                    txtDropDownList.Height = "20"
                                    MiCellSubTab.Controls.Add(txtDropDownList)

                                    sqlSource  = New SqlDataSource()                 
                                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                    sqlSource.SelectCommand = SelectCommand                                    
                                    sqlSource.ID = "ds" & arrNodesControl(m)

                                    'sqlSource.DataFile = DataFile
                                    'sqlSource.SelectCommand = SelectCommand
                                    MiCellSubTab.Controls.Add(sqlSource)
                                Case "AutocompleteSearch"
                                    txtCheckBox = New CheckBox
                                    txtCheckBox.ID = "chk" & arrNodesControl(m)
                                    txtCheckBox.ClientIDMode = ClientIDMode.Static
                                    txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrNodesLabel(m)
                                    MiCellSubTab.Controls.Add(txtCheckBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    AutoComp = New AutoCompleteExtender
                                    AutoComp.ID = "Autocomplete" & arrNodesControl(m)
                                    AutoComp.ClientIDMode = UI.ClientIDMode.Static
                                    AutoComp.CompletionListItemCssClass = CssClassControl
                                    AutoComp.TargetControlID = arrNodesControl(m)
                                    AutoComp.ServicePath = SelectCommand
                                    AutoComp.ServiceMethod = FormularioWebServiceCall
                                    AutoComp.MinimumPrefixLength = "2"
                                    AutoComp.CompletionInterval = "1000"
                                    AutoComp.EnableCaching = "true"
                                    AutoComp.CompletionSetCount = "12"
                                    MiCellSubTab.Controls.Add(AutoComp)

                                Case "UploadArchivo" 'S�lo 1 campo de este tipo por p�gina web
                                    txtUploadFile = New FileUpload
                                    txtUploadFile.ID = "txtUploadFile"
                                    txtUploadFile.ClientIDMode = ClientIDMode.Static
                                    txtUploadFile.ToolTip = "Busque el archivo a subir"
                                    txtUploadFile.CssClass = CssClassControl
                                    MiCellSubTab.Controls.Add(txtUploadFile)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ' Se agrega el bot�n Save
                                    SaveButton = New Button
                                    SaveButton.ID = "SaveButton"
                                    SaveButton.CssClass = "boxceleste"
                                    SaveButton.Style(HtmlTextWriterStyle.Width) = 70
                                    SaveButton.Text = "Guardar"
                                    SaveButton.ToolTip = "De un click para guardar el archivo"
                                    'AddHandler SaveButton.Click, AddressOf RFC_Save
                                    MiCellSubTab.Controls.Add(SaveButton)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ' Se agrega el campo de texto
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ' Se agrega el Hyperlink para ver el archivo
                                    UploadLink = New HyperLink
                                    UploadLink.ID = "lnkFile"
                                    UploadLink.ClientIDMode = ClientIDMode.Static
                                    UploadLink.ImageUrl = "~/img/lupa20x20.png"
                                    'UploadLink.BorderWidth = 0
                                    'UploadLink.Text = "Ver Archivo"
                                    UploadLink.ToolTip = "De un click para visualizar el archivo"
                                    UploadLink.Visible = True
                                    MiCellSubTab.Controls.Add(UploadLink)

                                Case "VerDemanda" 'S�lo 1 campo de este tipo por p�gina web
                                    ' Se agrega el Hyperlink para ver el archivo
                                    UploadLink = New HyperLink
                                    UploadLink.ID = "lnkFile"
                                    UploadLink.ClientIDMode = ClientIDMode.Static
                                    UploadLink.ImageUrl = "~/img/lupa20x20.png"
                                    UploadLink.BorderWidth = 0
                                    UploadLink.Text = "Ver Propuesta de Demanda"
                                    UploadLink.ToolTip = "De un click para visualizar la propuesta de Demanda"
                                    UploadLink.Visible = True
                                    MiCellSubTab.Controls.Add(UploadLink)

                                Case "VerPrecautoria" 'S�lo 1 campo de este tipo por p�gina web
                                    ' Se agrega el Hyperlink para ver el archivo
                                    UploadLink = New HyperLink
                                    UploadLink.ID = "lnkFile2"
                                    UploadLink.ClientIDMode = ClientIDMode.Static
                                    UploadLink.ImageUrl = "~/img/lupa20x20.png"
                                    UploadLink.BorderWidth = 0
                                    UploadLink.Text = "Ver Propuesta de Precautoria"
                                    UploadLink.ToolTip = "De un click para visualizar la propuesta de Precautoria"
                                    UploadLink.Visible = True
                                    MiCellSubTab.Controls.Add(UploadLink)

                                Case "VerEscritoMandamiento" 'S�lo 1 campo de este tipo por p�gina web
                                    ' Se agrega el Hyperlink para ver el archivo
                                    UploadLink = New HyperLink
                                    UploadLink.ID = "lnkFile"
                                    UploadLink.ClientIDMode = ClientIDMode.Static
                                    UploadLink.ImageUrl = "~/img/lupa20x20.png"
                                    UploadLink.BorderWidth = 0
                                    UploadLink.Text = "Ver propuesta de escrito para solicitar que el tribunal dicte el mandamiento"
                                    UploadLink.ToolTip = "De un click para visualizar la propuesta de Escrito"
                                    UploadLink.Visible = True
                                    MiCellSubTab.Controls.Add(UploadLink)

                                Case "VerCartaBanco" 'S�lo 1 campo de este tipo por p�gina web
                                    ' Se agrega el Hyperlink para ver el archivo
                                    UploadLink = New HyperLink
                                    UploadLink.ID = "lnkFile"
                                    UploadLink.ClientIDMode = ClientIDMode.Static
                                    UploadLink.ImageUrl = "~/img/lupa20x20.png"
                                    UploadLink.BorderWidth = 0
                                    UploadLink.Text = "Ver propuesta de carta para solicitar que el banco firme la demanda con dos copias"
                                    UploadLink.ToolTip = "De un click para visualizar la propuesta de Carta"
                                    UploadLink.Visible = True
                                    MiCellSubTab.Controls.Add(UploadLink)

                                Case "VerCedula" 'S�lo 1 campo de este tipo por p�gina web
                                    ' Se agrega el Hyperlink para ver el archivo
                                    UploadLink = New HyperLink
                                    UploadLink.ID = "lnkFile"
                                    UploadLink.ClientIDMode = ClientIDMode.Static
                                    UploadLink.ImageUrl = "~/img/lupa20x20.png"
                                    UploadLink.BorderWidth = 0
                                    UploadLink.Text = "Ver Propuesta de C�dula"
                                    UploadLink.ToolTip = ToolTip
                                    UploadLink.Visible = True
                                    MiCellSubTab.Controls.Add(UploadLink)

                                Case "VerEstampe" 'S�lo 1 campo de este tipo por p�gina web
                                    ' Se agrega el Hyperlink para ver el archivo
                                    UploadLink = New HyperLink
                                    UploadLink.ID = "lnkFile2"
                                    UploadLink.ClientIDMode = ClientIDMode.Static
                                    UploadLink.ImageUrl = "~/img/lupa20x20.png"
                                    UploadLink.BorderWidth = 0
                                    UploadLink.Text = "Ver Propuesta de Estampe"
                                    UploadLink.ToolTip = ToolTip
                                    UploadLink.Visible = True
                                    MiCellSubTab.Controls.Add(UploadLink)

                                Case "VerEscrito44" 'S�lo 1 campo de este tipo por p�gina web
                                    ' Se agrega el Hyperlink para ver el archivo
                                    UploadLink = New HyperLink
                                    UploadLink.ID = "lnkFile"
                                    UploadLink.ClientIDMode = ClientIDMode.Static
                                    UploadLink.ImageUrl = "~/img/lupa20x20.png"
                                    UploadLink.BorderWidth = 0
                                    UploadLink.Text = "Ver propuesta de escrito para solicitar que el tribunal dicte la resoluci�n para notificar por el art�culo 44"
                                    UploadLink.ToolTip = "De un click para visualizar la propuesta de Escrito"
                                    UploadLink.Visible = True
                                    MiCellSubTab.Controls.Add(UploadLink)

                                Case "CascadeDropDown" 'Se agrega solo para proyecto Codelco
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = "ddlAmbitos"
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                                    txtDropDownList.ToolTip = "Escoja el Ambito"
                                    MiCellSubTab.Controls.Add(txtDropDownList)
                                    MiCellSubTab.Controls.Add(New LiteralControl("<br /><br /> "))

                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = "ddlHojas"
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                                    txtDropDownList.ToolTip = "Escoja la opci�n de men�"
                                    MiCellSubTab.Controls.Add(txtDropDownList)
                                    MiCellSubTab.Controls.Add(New LiteralControl("<br /><br /> "))

                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = "ddlDocumentos"
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                                    txtDropDownList.ToolTip = "Documentos actualmente vinculados"
                                    MiCellSubTab.Controls.Add(txtDropDownList)
                                    MiCellSubTab.Controls.Add(New LiteralControl("<br /><br /> "))

                                    txtCascadeDropDownList = New CascadingDropDown
                                    txtCascadeDropDownList.ID = "cddAmbitos"
                                    txtCascadeDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtCascadeDropDownList.TargetControlID = "ddlAmbitos"
                                    txtCascadeDropDownList.Category = "Ambitos"
                                    txtCascadeDropDownList.PromptText = "Escoja un �mbito ...."
                                    txtCascadeDropDownList.LoadingText = "Por favor espere ..."
                                    txtCascadeDropDownList.ServicePath = "AmbitosService.asmx"
                                    txtCascadeDropDownList.ServiceMethod = "GetAmbitos"
                                    MiCellSubTab.Controls.Add(txtCascadeDropDownList)

                                    txtCascadeDropDownList = New CascadingDropDown
                                    txtCascadeDropDownList.ID = "cddHojas"
                                    txtCascadeDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtCascadeDropDownList.TargetControlID = "ddlHojas"
                                    txtCascadeDropDownList.ParentControlID = "ddlAmbitos"
                                    txtCascadeDropDownList.Category = "Hojas"
                                    txtCascadeDropDownList.PromptText = "Escoja una opci�n del men� ...."
                                    txtCascadeDropDownList.LoadingText = "Por favor espere ..."
                                    txtCascadeDropDownList.ServicePath = "AmbitosService.asmx"
                                    txtCascadeDropDownList.ServiceMethod = "GetHojas"
                                    MiCellSubTab.Controls.Add(txtCascadeDropDownList)

                                    txtCascadeDropDownList = New CascadingDropDown
                                    txtCascadeDropDownList.ID = "cddDocumentos"
                                    txtCascadeDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtCascadeDropDownList.TargetControlID = "ddlDocumentos"
                                    txtCascadeDropDownList.ParentControlID = "ddlHojas"
                                    txtCascadeDropDownList.Category = "Documentos"
                                    txtCascadeDropDownList.PromptText = "Documentos actualmente vinculados ...."
                                    txtCascadeDropDownList.LoadingText = "Por favor espere ..."
                                    txtCascadeDropDownList.ServicePath = "AmbitosService.asmx"
                                    txtCascadeDropDownList.ServiceMethod = "GetDocumentos"
                                    MiCellSubTab.Controls.Add(txtCascadeDropDownList)

                                Case "SelectFromModalList"   'Se agrega para proyecto con Importadora Vergara
                                    MiCellSubTab.Controls.Add(New LiteralControl("<input id=""btnModal""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""?"" onclick=""verModal" & arrNodesControl(m) & "('SelectFromModalList.aspx?Accion=" & SelectCommand & "')"" style=""width: 20px"" /> "))
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" <input id=""btnHelp" & arrNodesControl(m) & """ class=""boxceleste"" type=""button"" value=""..."" onclick=""return btnHelp" & arrNodesControl(m) & "_onclick()"" style=""width: 30px"" /> "))

                                    '<asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" autoComplete="off" Width="200px"  ></asp:TextBox>
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m) & "Description"
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = "350px"
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.Enabled = False
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    'MiCellSubTab.Controls.Add(New LiteralControl("<input id=""btnHelpCodigo""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""Leer por Nombre"" onclick=""return btnHelpNombre" & arrNodesControl(m) & "_onclick()"" style=""width: 100px"" />"))
                                    MiCellSubTab.Controls.Add(New LiteralControl(GenerarJScript(arrNodesControl(m), SelectCommand)))

                                Case "DropDownListPlusDescription"
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = arrNodesControl(m)
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtDropDownList.ToolTip = ToolTip
                                    txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                    txtDropDownList.DataTextField = DataTextField
                                    MiCellSubTab.Controls.Add(txtDropDownList)


                                    sqlSource  = New SqlDataSource()                 
                                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                    sqlSource.SelectCommand = SelectCommand

                                    sqlSource.ID = "ds" & arrNodesControl(m)
                                    'sqlSource.DataFile = DataFile
                                    'sqlSource.SelectCommand = SelectCommand
                                    MiCellSubTab.Controls.Add(sqlSource)

                                    MiCellSubTab.Controls.Add(New LiteralControl(" <input id=""btnHelp" & arrNodesControl(m) & """ class=""boxceleste"" type=""button"" value=""..."" onclick=""return btnHelp" & arrNodesControl(m) & "_onclick()"" style=""width: 30px"" /> "))

                                    '<asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" autoComplete="off" Width="200px"  ></asp:TextBox>
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m) & "Description"
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = "350px"
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.Enabled = False
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    'MiCellSubTab.Controls.Add(New LiteralControl("<input id=""btnHelpCodigo""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""Leer por Nombre"" onclick=""return btnHelpNombre" & arrNodesControl(m) & "_onclick()"" style=""width: 100px"" />"))
                                    MiCellSubTab.Controls.Add(New LiteralControl(GenerarJScriptOnlyDescription(arrNodesControl(m), SelectCommand)))

                                Case "UpdateButton"
                                    UpdateButton = New Button
                                    UpdateButton.ID = arrNodesControl(m) & "Vista"
                                    UpdateButton.CssClass = CssClassControl
                                    UpdateButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    UpdateButton.Text = arrNodesLabel(m)
                                    UpdateButton.ToolTip = ToolTip
                                    'AddHandler UpdateButton.Click, AddressOf RFC_Update
                                    MiCellSubTab.Controls.Add(UpdateButton)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))

                            End Select
                            MiRowSubTab.Cells.Add(MiCellSubTab)
                            MiTablaSubTab.Rows.Add(MiRowSubTab)
                        Else
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrNodesControl(m)
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtTextBox.TextMode = ControlTextMode
                            txtTextBox.ToolTip = ToolTip
                            txtTextBox.Enabled = False
                            txtTextBox.Visible = False
                            MyView.Controls.Add(txtTextBox)
                        End If
                    Next

                    MyView.Controls.Add(MiTablaSubTab)
                Next
            End If

            ' Creamos nuevamente la tabla
            MyTable = New Table
            MyTable.ID = "ViewButtons2" & NumeroPagina
            MyTable.Width = "700"
            MyTable.CellSpacing = "2"
            MyTable.CellPadding = "2"

            'Botones del Formulario
            i = 0
            t = Lecturas.LeerButtonFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            Row = New TableRow
            Cell = New TableCell
            Cell.CssClass = CssClassLabel
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Style(HtmlTextWriterStyle.Width) = "20%"
            'Se puso el 20 de Diciembre
            Cell.Controls.Add(New LiteralControl(" "))
            Row.Cells.Add(Cell)
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.Width) = "80%"
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Button", "InputValidation", NumeroPagina, k + 1)
                Select Case arrControl(k)

                    Case "UpdateButton"
                        UpdateButton = New Button
                        UpdateButton.ID = arrControl(k) & "Vista"
                        UpdateButton.CssClass = CssClassControl
                        UpdateButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        UpdateButton.Text = arrLabel(k)
                        UpdateButton.ToolTip = ToolTip
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(UpdateButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                        '<input id="Button1" type="button" value="Dar por terminada la tarea" class="boxceleste" onclick="TerminarTarea()" />
                        'Aqui agregar un boton cliente



                    Case "MailButton"
                        MailButton = New Button
                        MailButton.ID = arrControl(k) & "Mail"
                        MailButton.CssClass = CssClassControl
                        MailButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        MailButton.Text = arrLabel(k)
                        MailButton.ToolTip = ToolTip
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(MailButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "CommentButton"
                        CommentButton = New Button
                        CommentButton.ID = arrControl(k) & "Comment"
                        CommentButton.CssClass = CssClassControl
                        CommentButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        CommentButton.Text = arrLabel(k)
                        CommentButton.ToolTip = ToolTip
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(CommentButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "MuroButton"
                        MuroButton = New Button
                        MuroButton.ID = arrControl(k) & "Muro"
                        MuroButton.CssClass = CssClassControl
                        MuroButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        MuroButton.Text = arrLabel(k)
                        MuroButton.ToolTip = ToolTip
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(MuroButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "AlertaButton"
                        AlertaButton = New Button
                        AlertaButton.ID = arrControl(k) & "Alerta"
                        AlertaButton.CssClass = CssClassControl
                        AlertaButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        AlertaButton.Text = arrLabel(k)
                        AlertaButton.ToolTip = ToolTip
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(AlertaButton)
                        Cell.Controls.Add(New LiteralControl(" "))

                End Select
            Next

            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
            MyView.Controls.Add(MyTable)
        End If
    End Sub
    Public Sub NuevaCrearFormulario(ByVal NumeroPagina As Integer, ByVal TituloPagina As String, _
                                ByVal DescripcionPagina As String, ByVal GroupValidation As String, _
                                ByRef MyView As PlaceHolder, ByRef sumValidacion As ValidationSummary, _
                                ByRef valTextBox As RequiredFieldValidator, ByRef REValidacion As RegularExpressionValidator, _
                                ByRef CuValidacion As CustomValidator, ByRef CoValidacion As CompareValidator, _
                                ByRef LoginButton As Button, ByRef CancelButton As Button, ByRef UpdateButton As Button, _
                                ByRef NewButton As Button, ByRef SearchButton As Button, ByRef DeleteButton As Button, ByRef ReturnButton As Button, Optional ByRef NextButton As Button = Nothing, Optional ByRef PrevButton As Button = Nothing)


        '-------------------------- 26-Julio-2010 -----------------
        ' Esta nueva rutina supone trabajar con un contenedor del tipo PlaceHolder en vez del tipo
        ' table
        '----------------------------------------------------------

        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim m As Integer = 0
        Dim n As Integer = 0
        Dim kk As Integer = 0
        Dim ii As Integer = 0
        Dim mm As Integer = 0
        Dim nn As Integer = 0
        Dim MyTable As Table
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim MiTablaSubTab As Table
        Dim MiRowSubTab As TableRow
        Dim MiCellSubTab As TableCell
        Dim MiTabla12 As Table
        Dim MiRow12 As TableRow
        Dim MiCell12 As TableCell

        Dim arrLabel(25) As String
        Dim arrControl(25) As String
        Dim arrGrillaLabel(25) As String
        Dim arrGrillaControl(25) As String
        Dim ArrNodesId(25) As Long
        Dim arrNodesLabel(25) As String
        Dim arrNodesControl(25) As String
        Dim arrSubNodesId(25) As Long
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
        Dim Url As String = ""
        Dim FormularioWebPId As Long = 0
        Dim FormularioWebServiceCall As String = ""

        Dim txtTextBox As TextBox
        Dim txtDropDownList As DropDownList
        Dim txtCheckBox As CheckBox
        Dim sqlSource As SqlDataSource
        Dim txtCalendar As CalendarExtender
        Dim ImgImages As Image
        Dim AutoComp As AutoCompleteExtender
        Dim txtUploadFile As FileUpload
        Dim SaveButton As Button
        Dim UploadLink As HyperLink
        Dim txtCascadeDropDownList As CascadingDropDown

        Dim sSQL As String = ""
        Dim HTMLCode As String = ""

        Dim AnchoTablaTabs As Integer = 0
        Dim sJavaScript As String = ""

        Dim FormularioWeb As New FormularioWeb

        ' Primero se despliegan
        ' los campos que son de contexto y que no pueden ser alterados por ning�n motivo, como
        ' por ejemplo aquellos campos que son claves �nicas y que no pueden ser modificados
        ' o aquellos campos que corresponden a la foreing key hacia la tabla padre, en el
        ' caso de una aplicaci�n del tipo master-detail.

        ' Estos campos se encuentran en la section FormKeys y pueden no existir para determinados
        ' tipos de formularios y se leen mediante el metodo 
        ' LeerKeysFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        t = Lecturas.LeerKeysFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        ' A continuaci�n pongo los textos de identificaci�n de la p�gina, que fueron pasados como
        ' par�metros de invocaci�n

        MyTable = New Table
        MyTable.ID = "ViewHeader"
        MyTable.Width = "700"
        MyTable.CellSpacing = "2"
        MyTable.CellPadding = "2"
        MyTable.CssClass = "visible"
        'Titulo
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("<h1>" & TituloPagina & "</h1>"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        'Linea de Divisi�n
        'Row = New TableRow
        'Cell = New TableCell
        'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        'Cell.Height = "4"
        'Cell.ColumnSpan = "2"
        'Cell.Controls.Add(New LiteralControl("<hr />"))
        'Row.Cells.Add(Cell)
        'MyTable.Rows.Add(Row)
        'Descripci�n
        'Se esconde la descripci�n a solicitud de Priscilla
        'Row = New TableRow
        'Cell = New TableCell
        'Cell.CssClass = "tab_contenido"
        'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        'Cell.ColumnSpan = "2"
        'Cell.Controls.Add(New LiteralControl(DescripcionPagina))
        'Row.Cells.Add(Cell)
        'MyTable.Rows.Add(Row)
        MyView.Controls.Add(MyTable)



        ' Bajo el nuevo esquema, creo otra tabla para los campos claves y la sumo al placeholder


        MyTable = New Table
        MyTable.ID = "ViewKeys"
        MyTable.Width = "700"
        MyTable.CellSpacing = "2"
        MyTable.CellPadding = "2"
        If i > 0 Then
            Row = New TableRow
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "FormKeys", GroupValidation, NumeroPagina, k + 1)
                'aqui va la creaci�n de la fila
                Cell = New TableCell
                Cell.CssClass = CssClassLabel
                Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
                Cell.Style(HtmlTextWriterStyle.Width) = "10%"
                If k = 0 Then
                    Cell.Controls.Add(New LiteralControl(arrLabel(k) & " : "))
                End If
                Row.Cells.Add(Cell)
                Cell = New TableCell
                Cell.Style(HtmlTextWriterStyle.Width) = "40%"
                txtTextBox = New TextBox
                txtTextBox.ID = arrControl(k)
                txtTextBox.ClientIDMode = ClientIDMode.Static
                txtTextBox.CssClass = CssClassControl
                txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                txtTextBox.TextMode = ControlTextMode
                If ControlTextMode = 1 Then
                    txtTextBox.Height = "50"
                End If
                txtTextBox.ToolTip = ToolTip
                If IsNotEnabledField Then
                    txtTextBox.Enabled = False
                End If
                ' OJO esta instrucci�n no es generica y la coloque ha solicitud de Juan Manuel
                ' para esconder el campo Secuencia
                If k = 1 Then
                    txtTextBox.Visible = False  'Se esconde el n�mero de secuencia
                End If
                Cell.Controls.Add(txtTextBox)
                Row.Cells.Add(Cell)
                ' Aqu� se suma la fila
            Next
            MyTable.Rows.Add(Row)
            'Linea de Divisi�n
            'Se elimina la l�nea el 25-09-2011
            'Row = New TableRow
            'Cell = New TableCell
            'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            'Cell.Height = "4"
            'Cell.ColumnSpan = "4"  ' Se pone 4 esta vez para desplegar a 2 columnas
            'Cell.Controls.Add(New LiteralControl("<hr />"))
            'Row.Cells.Add(Cell)
            'MyTable.Rows.Add(Row)
        End If
        MyView.Controls.Add(MyTable)



        'Luego se agrega la tabla de control de validaci�n de los campos

        MyTable = New Table
        MyTable.ID = "ViewValidationSummary"
        MyTable.Width = "700"
        MyTable.CellSpacing = "2"
        MyTable.CellPadding = "2"
        'Summary de Validaciones
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "validador"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        sumValidacion = New ValidationSummary
        sumValidacion.ID = "RegisterUserValidationSummary"
        sumValidacion.HeaderText = "Existen problemas con los siguientes campos del formulario"
        sumValidacion.CssClass = "validador"
        sumValidacion.ValidationGroup = GroupValidation
        Cell.Controls.Add(sumValidacion)
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        MyView.Controls.Add(MyTable)

        i = 0

        ' A continuaci�n leo el registro de cabecera del formulario y desde el cual derivan el
        ' resto de los registros que indican sus atributos y sus acciones
        ' Este registro se identifica pues es el �nico del formulario que pertenece a la 
        ' section FormHeader y se lee con el metodo: LeerHeaderFormularioWeb, que devuelve
        ' una �nica variable cuyo valor gobierna las siguientes decisiones de despliegue de los 
        ' atributos del formulario web, para ello este metodo se implementa como una funci�n que 
        ' devuelve un �nico campo booleano que puede poseer los siguientes valores:

        '   False:  No se encontro registro de cabecera, en cuyo caso el formulario es plano y no
        '           requiere un recorrido recursivo para ir desplegando sus atributos.
        '   ------------------------------------------------------------------------------------
        '   True:  Se encontro registro de cabecera y ello indica que el formulario debe ser recorrido
        '           en forma recursiva a continuaci�n del despliegue de los campos clave, siempre y cuando
        '           estos existan como atributos del formulario.
        t = Lecturas.LeerHeaderFormularioWeb(arrLabel, arrControl, NumeroPagina, i, FormularioWebPId)

        If i = 1 Then ' Se encontro un registro de cabecera para el formulario web

            ' Para emular tab container con tab panel se usaran solo tablas, con la capacidad de hacerse visibles o
            ' invisibles, dejando una sola visible a la vez.

            ' La primera tabla actuara como Tab Panel y es una tabla de una sola fila con tantas columnas como 
            ' grupos de campos tenga el formulario, para ello se hara un primer recorrido de las cabeceras encontradas

            ' Voy a usar una table en vez de un tab container

            i = 0
            t = Lecturas.LeerNodesFormularioWeb(arrLabel, arrControl, ArrNodesId, i, FormularioWebPId)
            If i > 1 Then 'Solo se despliegan tabs cuando hay m�s de 1, en el otro caso no lo amerita.
                'Creamos tabla y la �nica fila
                AnchoTablaTabs = 116 * (i + 1)
                MyTable = New Table
                MyTable.ID = "ViewBody" & FormularioWebPId
                MyTable.Width = AnchoTablaTabs
                MyTable.CellSpacing = "2"
                MyTable.CellPadding = "2"
                Row = New TableRow
                For k = 0 To i - 1
                    sJavaScript = ""
                    For m = 0 To i - 1
                        If m = k Then
                            sJavaScript = sJavaScript & "aparecer(""sub" & arrControl(m) & "sub"");"
                        Else
                            sJavaScript = sJavaScript & "desaparecer(""sub" & arrControl(m) & "sub"");"
                        End If
                    Next
                    Cell = New TableCell
                    Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
                    Cell.Width = "120"
                    Cell.CssClass = "boxceleste"
                    Cell.Controls.Add(New LiteralControl("<a onclick='" & sJavaScript & "'>" & arrLabel(k) & "</a>"))
                    Row.Cells.Add(Cell)
                Next
                sJavaScript = ""
                For m = 0 To i - 1
                    sJavaScript = sJavaScript & "todosvisibles(""sub" & arrControl(m) & "sub"");"
                Next
                Cell = New TableCell
                Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
                Cell.Width = "120"
                Cell.CssClass = "boxceleste"
                Cell.Controls.Add(New LiteralControl("<a onclick='" & sJavaScript & "'>" & "Ver ficha completa" & "</a>"))
                Row.Cells.Add(Cell)
                MyTable.Rows.Add(Row)
                MyView.Controls.Add(MyTable)
            End If
            'Con el mismo arreglo de nodos, vuelvo a recorrerlos pero ahora por cada uno, leo sus nodos hijos
            'para asi cargos los controles del formulario web.

            If i > 0 Then
                For k = 0 To i - 1
                    n = 0
                    t = Lecturas.LeerNodesFormularioWeb(arrNodesLabel, arrNodesControl, arrSubNodesId, n, ArrNodesId(k))
                    'Aqui acabo de leer los nodos del primer tab, por ahora no hay m�s anidamiento, asi que cada nodo
                    'en arrNodesLabel es en realidad una hoja
                    MiTablaSubTab = New Table
                    MiTablaSubTab.ID = "sub" & arrControl(k) & "sub"
                    MiTablaSubTab.ClientIDMode = ClientIDMode.Static
                    MiTablaSubTab.Width = "700"
                    MiTablaSubTab.Caption = arrLabel(k)
                    MiTablaSubTab.CaptionAlign = TableCaptionAlign.Left
                    MiTablaSubTab.CellSpacing = "2"
                    MiTablaSubTab.CellPadding = "2"
                    If k = 0 Then
                        MiTablaSubTab.CssClass = "visible"
                    Else
                        MiTablaSubTab.CssClass = "invisible"
                    End If
                    MiTablaSubTab.BackColor = Drawing.Color.WhiteSmoke
                    MiTablaSubTab.BorderStyle = BorderStyle.Solid
                    MiTablaSubTab.BorderWidth = 1
                    MiTablaSubTab.BorderColor = Drawing.Color.WhiteSmoke

                    'Controles del Formulario Web
                    For m = 0 To n - 1
                        t = Lecturas.LeerLeafFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, GroupValidation, FormularioWebServiceCall, arrSubNodesId(m))
                        ' Cambio introducido para dejar no visible ciertos campos
                        ' 27 de Abril de 2011
                        ' ------------------------------------------------------
                        If FormularioWeb.CampoIsVisible(arrSubNodesId(m)) = True Then
                            MiRowSubTab = New TableRow
                            MiRowSubTab.VerticalAlign = VerticalAlign.Middle
                            MiCellSubTab = New TableCell
                            MiCellSubTab.CssClass = CssClassLabel
                            MiCellSubTab.Style(HtmlTextWriterStyle.TextAlign) = "left"
                            MiCellSubTab.Style(HtmlTextWriterStyle.Width) = "20%"
                            If IsRequiredField Then
                                MiCellSubTab.Controls.Add(New LiteralControl(arrNodesLabel(m) & " (*) "))
                            Else
                                MiCellSubTab.Controls.Add(New LiteralControl(arrNodesLabel(m) & "  "))
                            End If
                            MiRowSubTab.Cells.Add(MiCellSubTab)
                            MiCellSubTab = New TableCell
                            MiCellSubTab.Style(HtmlTextWriterStyle.Width) = "80%"
                            MiCellSubTab.VerticalAlign = VerticalAlign.Middle
                            Select Case TipoControl
                                Case "TextBox"
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    If Mid(DomainField, 1, 2) = "Nb" Then
                                        txtTextBox.Style(HtmlTextWriterStyle.TextAlign) = "Right"
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                Case "TextBox12" 'Se crea para armar una fila con 12 columnas con header y campo
                                    ' Creamos una tabla que se va a subordinar a la tabla matriz

                                    MiTabla12 = New Table
                                    MiTabla12.ID = "sub" & arrNodesControl(m) & "sub"
                                    MiTabla12.ClientIDMode = ClientIDMode.Static
                                    MiTabla12.Width = "560"
                                    MiTabla12.CellSpacing = "1"
                                    MiTabla12.CellPadding = "1"
                                    MiTabla12.BackColor = Drawing.Color.WhiteSmoke
                                    MiTabla12.BorderStyle = BorderStyle.Solid
                                    MiTabla12.BorderWidth = 1
                                    MiTabla12.BorderColor = Drawing.Color.WhiteSmoke
                                    MiRow12 = New TableRow
                                    For ii = 1 To 12
                                        MiCell12 = New TableCell
                                        MiCell12.CssClass = CssClassLabel
                                        MiCell12.Style(HtmlTextWriterStyle.TextAlign) = "Center"
                                        MiCell12.Controls.Add(New LiteralControl(NombreMesCorto(ii)))
                                        MiRow12.Cells.Add(MiCell12)
                                    Next
                                    MiTabla12.Rows.Add(MiRow12)
                                    MiRow12 = New TableRow
                                    For ii = 1 To 12
                                        MiCell12 = New TableCell
                                        txtTextBox = New TextBox
                                        txtTextBox.ID = arrNodesControl(m)
                                        txtTextBox.ClientIDMode = ClientIDMode.Static
                                        txtTextBox.CssClass = CssClassControl
                                        txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                        txtTextBox.TextMode = ControlTextMode
                                        If ControlTextMode = 1 Then
                                            txtTextBox.Height = "50"
                                        End If
                                        txtTextBox.ToolTip = ToolTip
                                        If IsNotEnabledField Then
                                            txtTextBox.Enabled = False
                                        End If
                                        If Mid(DomainField, 1, 2) = "Nb" Then
                                            txtTextBox.Style(HtmlTextWriterStyle.TextAlign) = "Right"
                                        End If
                                        MiCell12.Controls.Add(txtTextBox)
                                        MiRow12.Cells.Add(MiCell12)
                                        m = m + 1
                                        If m <= n - 1 Then
                                            t = Lecturas.LeerLeafFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, GroupValidation, FormularioWebServiceCall, arrSubNodesId(m))
                                        End If
                                    Next
                                    MiTabla12.Rows.Add(MiRow12)
                                    m = m - 1
                                    MiCellSubTab.Controls.Add(MiTabla12)
                                Case "CheckBox"
                                    txtCheckBox = New CheckBox
                                    txtCheckBox.ID = arrNodesControl(m)
                                    txtCheckBox.ClientIDMode = ClientIDMode.Static
                                    txtCheckBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtCheckBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtCheckBox)
                                Case "TextBoxAutoComplete"
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    AutoComp = New AutoCompleteExtender
                                    AutoComp.ID = "Autocomplete" & arrNodesControl(m)
                                    AutoComp.ClientIDMode = UI.ClientIDMode.Static
                                    AutoComp.CompletionListItemCssClass = CssClassControl
                                    AutoComp.TargetControlID = arrNodesControl(m)
                                    AutoComp.ServicePath = "AutoComplete.asmx"
                                    AutoComp.ServiceMethod = FormularioWebServiceCall
                                    AutoComp.MinimumPrefixLength = "2"
                                    AutoComp.CompletionInterval = "1000"
                                    AutoComp.EnableCaching = "true"
                                    AutoComp.CompletionSetCount = "12"
                                    MiCellSubTab.Controls.Add(AutoComp)
                                Case "TextBoxCalendar"
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ImgImages = New Image
                                    ImgImages.ID = "Image" & arrNodesControl(m)
                                    ImgImages.ClientIDMode = UI.ClientIDMode.Static
                                    ImgImages.ImageUrl = "img/Calendar_scheduleHS.png"
                                    ImgImages.ImageAlign = ImageAlign.Middle
                                    MiCellSubTab.Controls.Add(ImgImages)
                                    txtCalendar = New CalendarExtender
                                    txtCalendar.ID = "Calendar" & arrNodesControl(m)
                                    txtCalendar.ClientIDMode = UI.ClientIDMode.Static
                                    txtCalendar.TargetControlID = arrNodesControl(m)
                                    txtCalendar.PopupButtonID = "Image" & arrNodesControl(m)
                                    txtCalendar.Format = "dd/MM/yy"
                                    MiCellSubTab.Controls.Add(txtCalendar)
                                Case "DropDownList"
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = arrNodesControl(m)
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtDropDownList.ToolTip = ToolTip
                                    txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                    txtDropDownList.DataValueField = DataTextField
                                    txtDropDownList.DataTextField = DataTextField
                                    txtDropDownList.Height = "20"
                                    MiCellSubTab.Controls.Add(txtDropDownList)

                                    sqlSource  = New SqlDataSource()                   
                                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                    sqlSource.SelectCommand = SelectCommand

                                    sqlSource.ID = "ds" & arrNodesControl(m)
                                    'sqlSource.DataFile = DataFile
                                    'sqlSource.SelectCommand = SelectCommand
                                    MiCellSubTab.Controls.Add(sqlSource)
                                Case "DropDownSearch"
                                    txtCheckBox = New CheckBox
                                    txtCheckBox.ID = "chk" & arrNodesControl(m)
                                    txtCheckBox.ClientIDMode = ClientIDMode.Static
                                    txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrNodesLabel(m)
                                    txtCheckBox.Height = "20"
                                    MiCellSubTab.Controls.Add(txtCheckBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = arrNodesControl(m)
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtDropDownList.ToolTip = ToolTip
                                    txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                    txtDropDownList.DataTextField = DataTextField
                                    txtDropDownList.Height = "20"
                                    MiCellSubTab.Controls.Add(txtDropDownList)

                                    sqlSource  = New SqlDataSource()                    
                                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                    sqlSource.SelectCommand = SelectCommand

                                    sqlSource.ID = "ds" & arrNodesControl(m)
                                    'sqlSource.DataFile = DataFile
                                    'sqlSource.SelectCommand = SelectCommand
                                    MiCellSubTab.Controls.Add(sqlSource)
                                Case "AutocompleteSearch"
                                    txtCheckBox = New CheckBox
                                    txtCheckBox.ID = "chk" & arrNodesControl(m)
                                    txtCheckBox.ClientIDMode = ClientIDMode.Static
                                    txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrNodesLabel(m)
                                    MiCellSubTab.Controls.Add(txtCheckBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    AutoComp = New AutoCompleteExtender
                                    AutoComp.ID = "Autocomplete" & arrNodesControl(m)
                                    AutoComp.ClientIDMode = UI.ClientIDMode.Static
                                    AutoComp.CompletionListItemCssClass = CssClassControl
                                    AutoComp.TargetControlID = arrNodesControl(m)
                                    AutoComp.ServicePath = SelectCommand
                                    AutoComp.ServiceMethod = FormularioWebServiceCall
                                    AutoComp.MinimumPrefixLength = "2"
                                    AutoComp.CompletionInterval = "1000"
                                    AutoComp.EnableCaching = "true"
                                    AutoComp.CompletionSetCount = "12"
                                    MiCellSubTab.Controls.Add(AutoComp)

                                Case "UploadArchivo" 'S�lo 1 campo de este tipo por p�gina web
                                    txtUploadFile = New FileUpload
                                    txtUploadFile.ID = "txtUploadFile"
                                    txtUploadFile.ClientIDMode = ClientIDMode.Static
                                    txtUploadFile.ToolTip = "Busque el archivo a subir"
                                    txtUploadFile.CssClass = CssClassControl
                                    MiCellSubTab.Controls.Add(txtUploadFile)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ' Se agrega el bot�n Save
                                    SaveButton = New Button
                                    SaveButton.ID = "SaveButton"
                                    SaveButton.CssClass = "boxceleste"
                                    SaveButton.Style(HtmlTextWriterStyle.Width) = 70
                                    SaveButton.Text = "Guardar"
                                    SaveButton.ToolTip = "De un click para guardar el archivo"
                                    'AddHandler SaveButton.Click, AddressOf RFC_Save
                                    MiCellSubTab.Controls.Add(SaveButton)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ' Se agrega el campo de texto
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ' Se agrega el Hyperlink para ver el archivo
                                    UploadLink = New HyperLink
                                    UploadLink.ID = "lnkFile"
                                    UploadLink.ClientIDMode = ClientIDMode.Static
                                    UploadLink.ToolTip = "De un click para visualizar el archivo"
                                    MiCellSubTab.Controls.Add(UploadLink)
                                Case "CascadeDropDown" 'Se agrega solo para proyecto Codelco
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = "ddlAmbitos"
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                                    txtDropDownList.ToolTip = "Escoja el Ambito"
                                    MiCellSubTab.Controls.Add(txtDropDownList)
                                    MiCellSubTab.Controls.Add(New LiteralControl("<br /><br /> "))

                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = "ddlHojas"
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                                    txtDropDownList.ToolTip = "Escoja la opci�n de men�"
                                    MiCellSubTab.Controls.Add(txtDropDownList)
                                    MiCellSubTab.Controls.Add(New LiteralControl("<br /><br /> "))

                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = "ddlDocumentos"
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                                    txtDropDownList.ToolTip = "Documentos actualmente vinculados"
                                    MiCellSubTab.Controls.Add(txtDropDownList)
                                    MiCellSubTab.Controls.Add(New LiteralControl("<br /><br /> "))

                                    txtCascadeDropDownList = New CascadingDropDown
                                    txtCascadeDropDownList.ID = "cddAmbitos"
                                    txtCascadeDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtCascadeDropDownList.TargetControlID = "ddlAmbitos"
                                    txtCascadeDropDownList.Category = "Ambitos"
                                    txtCascadeDropDownList.PromptText = "Escoja un �mbito ...."
                                    txtCascadeDropDownList.LoadingText = "Por favor espere ..."
                                    txtCascadeDropDownList.ServicePath = "AmbitosService.asmx"
                                    txtCascadeDropDownList.ServiceMethod = "GetAmbitos"
                                    MiCellSubTab.Controls.Add(txtCascadeDropDownList)

                                    txtCascadeDropDownList = New CascadingDropDown
                                    txtCascadeDropDownList.ID = "cddHojas"
                                    txtCascadeDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtCascadeDropDownList.TargetControlID = "ddlHojas"
                                    txtCascadeDropDownList.ParentControlID = "ddlAmbitos"
                                    txtCascadeDropDownList.Category = "Hojas"
                                    txtCascadeDropDownList.PromptText = "Escoja una opci�n del men� ...."
                                    txtCascadeDropDownList.LoadingText = "Por favor espere ..."
                                    txtCascadeDropDownList.ServicePath = "AmbitosService.asmx"
                                    txtCascadeDropDownList.ServiceMethod = "GetHojas"
                                    Cell.Controls.Add(txtCascadeDropDownList)

                                    txtCascadeDropDownList = New CascadingDropDown
                                    txtCascadeDropDownList.ID = "cddDocumentos"
                                    txtCascadeDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtCascadeDropDownList.TargetControlID = "ddlDocumentos"
                                    txtCascadeDropDownList.ParentControlID = "ddlHojas"
                                    txtCascadeDropDownList.Category = "Documentos"
                                    txtCascadeDropDownList.PromptText = "Documentos actualmente vinculados ...."
                                    txtCascadeDropDownList.LoadingText = "Por favor espere ..."
                                    txtCascadeDropDownList.ServicePath = "AmbitosService.asmx"
                                    txtCascadeDropDownList.ServiceMethod = "GetDocumentos"
                                    Cell.Controls.Add(txtCascadeDropDownList)

                                Case "SelectFromModalList"   'Se agrega para proyecto con Importadora Vergara
                                    MiCellSubTab.Controls.Add(New LiteralControl("<input id=""btnModal""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""?"" onclick=""verModal" & arrNodesControl(m) & "('SelectFromModalList.aspx?Accion=" & SelectCommand & "')"" style=""width: 20px"" /> "))
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" <input id=""btnHelp" & arrNodesControl(m) & """ class=""boxceleste"" type=""button"" value=""..."" onclick=""return btnHelp" & arrNodesControl(m) & "_onclick()"" style=""width: 30px"" /> "))

                                    '<asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" autoComplete="off" Width="200px"  ></asp:TextBox>
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m) & "Description"
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = "350px"
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.Enabled = False
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    'MiCellSubTab.Controls.Add(New LiteralControl("<input id=""btnHelpCodigo""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""Leer por Nombre"" onclick=""return btnHelpNombre" & arrNodesControl(m) & "_onclick()"" style=""width: 100px"" />"))
                                    MiCellSubTab.Controls.Add(New LiteralControl(GenerarJScript(arrNodesControl(m), SelectCommand)))

                                Case "DropDownListPlusDescription"
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = arrNodesControl(m)
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtDropDownList.ToolTip = ToolTip
                                    txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                    txtDropDownList.DataTextField = DataTextField
                                    MiCellSubTab.Controls.Add(txtDropDownList)


                                    sqlSource  = New SqlDataSource()                   
                                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                    sqlSource.SelectCommand = SelectCommand                                    
                                    sqlSource.ID = "ds" & arrNodesControl(m)
                                    'sqlSource.DataFile = DataFile
                                    'sqlSource.SelectCommand = SelectCommand
                                    MiCellSubTab.Controls.Add(sqlSource)

                                    MiCellSubTab.Controls.Add(New LiteralControl(" <input id=""btnHelp" & arrNodesControl(m) & """ class=""boxceleste"" type=""button"" value=""..."" onclick=""return btnHelp" & arrNodesControl(m) & "_onclick()"" style=""width: 30px"" /> "))

                                    '<asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" autoComplete="off" Width="200px"  ></asp:TextBox>
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m) & "Description"
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = "350px"
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.Enabled = False
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    'MiCellSubTab.Controls.Add(New LiteralControl("<input id=""btnHelpCodigo""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""Leer por Nombre"" onclick=""return btnHelpNombre" & arrNodesControl(m) & "_onclick()"" style=""width: 100px"" />"))
                                    MiCellSubTab.Controls.Add(New LiteralControl(GenerarJScriptOnlyDescription(arrNodesControl(m), SelectCommand)))


                            End Select

                            If IsRequiredField Then
                                valTextBox = New RequiredFieldValidator
                                valTextBox.ID = "RequiredField" & arrNodesControl(m)
                                valTextBox.ControlToValidate = arrNodesControl(m)
                                valTextBox.ClientIDMode = ClientIDMode.Static
                                valTextBox.ForeColor = Drawing.Color.Red
                                valTextBox.Text = "*"
                                valTextBox.ErrorMessage = arrNodesLabel(m) & " es un campo obligatorio"
                                valTextBox.CssClass = "tab_contenido"
                                valTextBox.ValidationGroup = GroupValidation
                                MiCellSubTab.Controls.Add(valTextBox)
                            End If
                            Select Case DomainField
                                Case "Correo"
                                    REValidacion = New RegularExpressionValidator
                                    REValidacion.ID = "RegularExpression" & arrNodesControl(m)
                                    REValidacion.ControlToValidate = arrNodesControl(m)
                                    REValidacion.ClientIDMode = ClientIDMode.Static
                                    REValidacion.Text = "*"
                                    REValidacion.ErrorMessage = "La direcci�n de correo no tiene un formato valido"
                                    REValidacion.CssClass = "tab_contenido"
                                    REValidacion.ValidationGroup = GroupValidation
                                    REValidacion.ValidationExpression = "\S+@\S+\.\S{2,3}"
                                    MiCellSubTab.Controls.Add(REValidacion)
                                Case "RUT"
                                    CuValidacion = New CustomValidator
                                    CuValidacion.ID = "RutValidator" & arrNodesControl(m)
                                    CuValidacion.ControlToValidate = arrNodesControl(m)
                                    CuValidacion.ClientIDMode = ClientIDMode.Static
                                    CuValidacion.Text = "*"
                                    CuValidacion.ErrorMessage = "El RUT no es valido"
                                    CuValidacion.CssClass = "tab_contenido"
                                    CuValidacion.ValidationGroup = GroupValidation
                                    CuValidacion.EnableClientScript = True
                                    CuValidacion.ClientValidationFunction = "RutValidator_ClientValidate"
                                    MiCellSubTab.Controls.Add(CuValidacion)
                                Case "Numeros"
                                    CoValidacion = New CompareValidator
                                    CoValidacion.ID = "CompareValidator" & arrNodesControl(m)
                                    CoValidacion.ControlToValidate = arrNodesControl(m)
                                    CoValidacion.ClientIDMode = ClientIDMode.Static
                                    CoValidacion.Text = "*"
                                    CoValidacion.ErrorMessage = arrNodesLabel(m) & " debe ser un valor num�rico"
                                    CoValidacion.CssClass = "tab_contenido"
                                    CoValidacion.ValidationGroup = GroupValidation
                                    CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                                    CoValidacion.Type = ValidationDataType.Integer
                                    MiCellSubTab.Controls.Add(CoValidacion)
                                Case "Letras"
                                    CoValidacion = New CompareValidator
                                    CoValidacion.ID = "CompareValidator" & arrNodesControl(m)
                                    CoValidacion.ControlToValidate = arrNodesControl(m)
                                    CoValidacion.ClientIDMode = ClientIDMode.Static
                                    CoValidacion.Text = "*"
                                    CoValidacion.ErrorMessage = arrNodesLabel(m) & " debe ser un valor alfanum�rico"
                                    CoValidacion.CssClass = "tab_contenido"
                                    CoValidacion.ValidationGroup = GroupValidation
                                    CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                                    CoValidacion.Type = ValidationDataType.String
                                    MiCellSubTab.Controls.Add(CoValidacion)
                                Case "Fecha"
                                    CoValidacion = New CompareValidator
                                    CoValidacion.ID = "CompareValidator" & arrNodesControl(m)
                                    CoValidacion.ControlToValidate = arrNodesControl(m)
                                    CoValidacion.ClientIDMode = ClientIDMode.Static
                                    CoValidacion.Text = "*"
                                    CoValidacion.ErrorMessage = arrNodesLabel(m) & " debe ser una fecha valida"
                                    CoValidacion.CssClass = "tab_contenido"
                                    CoValidacion.ValidationGroup = GroupValidation
                                    CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                                    CoValidacion.Type = ValidationDataType.Date
                                    MiCellSubTab.Controls.Add(CoValidacion)

                            End Select
                            MiRowSubTab.Cells.Add(MiCellSubTab)
                            MiTablaSubTab.Rows.Add(MiRowSubTab)
                        Else
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrNodesControl(m)
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtTextBox.TextMode = ControlTextMode
                            txtTextBox.ToolTip = ToolTip
                            txtTextBox.Enabled = False
                            txtTextBox.Visible = False
                            MyView.Controls.Add(txtTextBox)
                        End If
                    Next

                    MyView.Controls.Add(MiTablaSubTab)
                Next
            End If

            ' Creamos nuevamente la tabla
            MyTable = New Table
            MyTable.ID = "ViewButtons"
            MyTable.Width = "700"
            MyTable.CellSpacing = "2"
            MyTable.CellPadding = "2"

            'Botones del Formulario
            i = 0
            t = Lecturas.LeerButtonFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            Row = New TableRow
            Cell = New TableCell
            Cell.CssClass = CssClassLabel
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Style(HtmlTextWriterStyle.Width) = "20%"
            'Se puso el 20 de Diciembre
            Cell.Controls.Add(New LiteralControl(" (*) Campo Obligatorio "))
            Row.Cells.Add(Cell)
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.Width) = "80%"
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Button", GroupValidation, NumeroPagina, k + 1)
                Select Case arrControl(k)
                    Case "LoginButton"
                        LoginButton = New Button
                        LoginButton.ID = arrControl(k)
                        LoginButton.CssClass = CssClassControl
                        LoginButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        LoginButton.Text = arrLabel(k)
                        LoginButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            LoginButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler LoginButton.Click, AddressOf RFC_Login
                        Cell.Controls.Add(LoginButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "CancelButton"
                        CancelButton = New Button
                        CancelButton.ID = arrControl(k)
                        CancelButton.CssClass = CssClassControl
                        CancelButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        CancelButton.Text = arrLabel(k)
                        CancelButton.ToolTip = ToolTip
                        'AddHandler CancelButton.Click, AddressOf RFC_Logout
                        Cell.Controls.Add(CancelButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "UpdateButton"
                        UpdateButton = New Button
                        UpdateButton.ID = arrControl(k)
                        UpdateButton.CssClass = CssClassControl
                        UpdateButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        UpdateButton.Text = arrLabel(k)
                        UpdateButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            UpdateButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(UpdateButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "NextButton"
                        NextButton = New Button
                        NextButton.ID = arrControl(k)
                        NextButton.CssClass = CssClassControl
                        NextButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        NextButton.Text = arrLabel(k)
                        NextButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            NextButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(NextButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "PrevButton"
                        PrevButton = New Button
                        PrevButton.ID = arrControl(k)
                        PrevButton.CssClass = CssClassControl
                        PrevButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        PrevButton.Text = arrLabel(k)
                        PrevButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            PrevButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(PrevButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "NewButton"
                        NewButton = New Button
                        NewButton.ID = arrControl(k)
                        NewButton.CssClass = CssClassControl
                        NewButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        NewButton.Text = arrLabel(k)
                        NewButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            NewButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(NewButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "SearchButton"
                        SearchButton = New Button
                        SearchButton.ID = arrControl(k)
                        SearchButton.CssClass = CssClassControl
                        SearchButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        SearchButton.Text = arrLabel(k)
                        SearchButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            SearchButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(SearchButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "DeleteButton"
                        DeleteButton = New Button
                        DeleteButton.ID = arrControl(k)
                        DeleteButton.CssClass = CssClassControl
                        DeleteButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        DeleteButton.Text = arrLabel(k)
                        DeleteButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            DeleteButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler DeleteButton.Click, AddressOf RFC_Delete
                        Cell.Controls.Add(DeleteButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "ReturnButton"
                        ReturnButton = New Button
                        ReturnButton.ID = arrControl(k)
                        ReturnButton.CssClass = CssClassControl
                        ReturnButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        ReturnButton.Text = arrLabel(k)
                        ReturnButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            ReturnButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler ReturnButton.Click, AddressOf RFC_Return
                        Cell.Controls.Add(ReturnButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                End Select
            Next

            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
            MyView.Controls.Add(MyTable)
        Else

            ' Significa que no hay tabs definidos para el formulario en cuesti�n y que 
            ' por tanto la l�gica de despliegue es la misma de siempre y podremos hacer todo
            ' en una �nica tabla y luego agregarla a la view.

            MyTable = New Table
            MyTable.ID = "ViewBody"
            MyTable.Width = "700"
            MyTable.CellSpacing = "2"
            MyTable.CellPadding = "2"


            'Linea de Divisi�n
            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Height = "4"
            Cell.ColumnSpan = "2"
            Cell.Controls.Add(New LiteralControl("<hr />"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)

            i = 0
            t = Lecturas.LeerLabelFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

            'Controles del Formulario Web
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Form", GroupValidation, NumeroPagina, k + 1)
                ' Cambio introducido para dejar no visible ciertos campos
                ' 27 de Abril de 2011
                ' ------------------------------------------------------
                Section = "Form"
                If FormularioWeb.CampoIsVisibleV2(Section, NumeroPagina, k + 1) = True Then
                    Row = New TableRow
                    Row.VerticalAlign = VerticalAlign.Middle
                    Cell = New TableCell
                    Cell.CssClass = CssClassLabel
                    Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
                    Cell.Style(HtmlTextWriterStyle.Width) = "20%"
                    Cell.Controls.Add(New LiteralControl(arrLabel(k) & " : "))
                    Row.Cells.Add(Cell)
                    Cell = New TableCell
                    Cell.Style(HtmlTextWriterStyle.Width) = "80%"
                    Cell.VerticalAlign = VerticalAlign.Middle
                    Select Case TipoControl
                        Case "TextBox"
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrControl(k)
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtTextBox.TextMode = ControlTextMode
                            If ControlTextMode = 1 Then
                                txtTextBox.Height = "50"
                            End If
                            txtTextBox.ToolTip = ToolTip
                            If IsNotEnabledField Then
                                txtTextBox.Enabled = False
                            End If
                            If Mid(DomainField, 1, 2) = "Nb" Then
                                txtTextBox.Style(HtmlTextWriterStyle.TextAlign) = "Right"
                            End If
                            Cell.Controls.Add(txtTextBox)
                        Case "CheckBox"
                            txtCheckBox = New CheckBox
                            txtCheckBox.ID = arrNodesControl(m)
                            txtCheckBox.ClientIDMode = ClientIDMode.Static
                            txtCheckBox.ToolTip = ToolTip
                            If IsNotEnabledField Then
                                txtCheckBox.Enabled = False
                            End If
                            Cell.Controls.Add(txtCheckBox)
                        Case "TextBoxAutoComplete"
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrControl(k)
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtTextBox.TextMode = ControlTextMode
                            If ControlTextMode = 1 Then
                                txtTextBox.Height = "50"
                            End If
                            txtTextBox.ToolTip = ToolTip
                            If IsNotEnabledField Then
                                txtTextBox.Enabled = False
                            End If
                            Cell.Controls.Add(txtTextBox)
                            AutoComp = New AutoCompleteExtender
                            AutoComp.ID = "Autocomplete" & arrControl(k)
                            AutoComp.ClientIDMode = UI.ClientIDMode.Static
                            AutoComp.CompletionListItemCssClass = CssClassControl
                            AutoComp.TargetControlID = arrControl(k)
                            AutoComp.ServicePath = "AutoComplete.asmx"
                            AutoComp.ServiceMethod = Lecturas.LeerNombreMetodoAutocomplete("Form", NumeroPagina, k + 1)  ' Aqui hay que invocar un metodo para traer el nombre del m�todo
                            AutoComp.MinimumPrefixLength = "2"
                            AutoComp.CompletionInterval = "1000"
                            AutoComp.EnableCaching = "true"
                            AutoComp.CompletionSetCount = "12"
                            Cell.Controls.Add(AutoComp)
                        Case "TextBoxCalendar"
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrControl(k)
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtTextBox.TextMode = ControlTextMode
                            txtTextBox.ToolTip = ToolTip
                            If IsNotEnabledField Then
                                txtTextBox.Enabled = False
                            End If
                            Cell.Controls.Add(txtTextBox)
                            Cell.Controls.Add(New LiteralControl(" "))
                            ImgImages = New Image
                            ImgImages.ID = "Image" & arrControl(k)
                            ImgImages.ClientIDMode = UI.ClientIDMode.Static
                            ImgImages.ImageUrl = "img/Calendar_scheduleHS.png"
                            ImgImages.ImageAlign = ImageAlign.Middle
                            Cell.Controls.Add(ImgImages)
                            txtCalendar = New CalendarExtender
                            txtCalendar.ID = "Calendar" & arrControl(k)
                            txtCalendar.ClientIDMode = UI.ClientIDMode.Static
                            txtCalendar.TargetControlID = arrControl(k)
                            txtCalendar.PopupButtonID = "Image" & arrControl(k)
                            txtCalendar.Format = "dd/MMM/yy"
                            Cell.Controls.Add(txtCalendar)
                        Case "DropDownList"
                            txtDropDownList = New DropDownList
                            txtDropDownList.ID = arrControl(k)
                            txtDropDownList.ClientIDMode = ClientIDMode.Static
                            txtDropDownList.CssClass = CssClassControl
                            txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtDropDownList.ToolTip = ToolTip
                            txtDropDownList.DataSourceID = "ds" & arrControl(k)
                            txtDropDownList.DataTextField = DataTextField
                            txtDropDownList.Height = "20"
                            Cell.Controls.Add(txtDropDownList)

                            sqlSource  = New SqlDataSource()                    
                            sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                            sqlSource.SelectCommand = SelectCommand

                            sqlSource.ID = "ds" & arrControl(k)
                            'sqlSource.DataFile = DataFile
                            'sqlSource.SelectCommand = SelectCommand
                            Cell.Controls.Add(sqlSource)
                        Case "DropDownSearch"
                            txtCheckBox = New CheckBox
                            txtCheckBox.ID = "chk" & arrControl(k)
                            txtCheckBox.ClientIDMode = ClientIDMode.Static
                            txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrLabel(k)
                            Cell.Controls.Add(txtCheckBox)
                            Cell.Controls.Add(New LiteralControl(" "))
                            txtDropDownList = New DropDownList
                            txtDropDownList.ID = arrControl(k)
                            txtDropDownList.ClientIDMode = ClientIDMode.Static
                            txtDropDownList.CssClass = CssClassControl
                            txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtDropDownList.ToolTip = ToolTip
                            txtDropDownList.DataSourceID = "ds" & arrControl(k)
                            txtDropDownList.DataTextField = DataTextField
                            txtDropDownList.Height = "20"
                            Cell.Controls.Add(txtDropDownList)

                            sqlSource  = New SqlDataSource()                   
                            sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                            sqlSource.SelectCommand = SelectCommand

                            sqlSource.ID = "ds" & arrControl(k)
                            'sqlSource.DataFile = DataFile
                            'sqlSource.SelectCommand = SelectCommand
                            Cell.Controls.Add(sqlSource)
                        Case "UploadArchivo" 'S�lo 1 campo de este tipo por p�gina web
                            txtUploadFile = New FileUpload
                            txtUploadFile.ID = "txtUploadFile"
                            txtUploadFile.ClientIDMode = ClientIDMode.Static
                            txtUploadFile.ToolTip = "Busque el archivo a subir"
                            txtUploadFile.CssClass = CssClassControl
                            Cell.Controls.Add(txtUploadFile)
                            Cell.Controls.Add(New LiteralControl(" "))
                            ' Se agrega el bot�n Save
                            SaveButton = New Button
                            SaveButton.ID = "SaveButton"
                            SaveButton.CssClass = "boxceleste"
                            SaveButton.Style(HtmlTextWriterStyle.Width) = 70
                            SaveButton.Text = "Guardar"
                            SaveButton.ToolTip = "De un click para guardar el archivo"
                            'AddHandler SaveButton.Click, AddressOf RFC_Save
                            Cell.Controls.Add(SaveButton)
                            Cell.Controls.Add(New LiteralControl(" "))
                            ' Se agrega el campo de texto
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrNodesControl(m)
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtTextBox.TextMode = ControlTextMode
                            If ControlTextMode = 1 Then
                                txtTextBox.Height = "50"
                            End If
                            txtTextBox.ToolTip = ToolTip
                            If IsNotEnabledField Then
                                txtTextBox.Enabled = False
                            End If
                            Cell.Controls.Add(txtTextBox)
                            Cell.Controls.Add(New LiteralControl(" "))
                            ' Se agrega el Hyperlink para ver el archivo
                            UploadLink = New HyperLink
                            UploadLink.ID = "lnkFile"
                            UploadLink.ClientIDMode = ClientIDMode.Static
                            UploadLink.ToolTip = "De un click para visualizar el archivo"
                            Cell.Controls.Add(UploadLink)
                        Case "CascadeDropDown" 'Se agrega solo para proyecto Codelco
                            txtDropDownList = New DropDownList
                            txtDropDownList.ID = "ddlAmbitos"
                            txtDropDownList.ClientIDMode = ClientIDMode.Static
                            txtDropDownList.CssClass = CssClassControl
                            txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                            txtDropDownList.ToolTip = "Escoja el Ambito"
                            Cell.Controls.Add(txtDropDownList)
                            Cell.Controls.Add(New LiteralControl("<br /> "))

                            txtDropDownList = New DropDownList
                            txtDropDownList.ID = "ddlHojas"
                            txtDropDownList.ClientIDMode = ClientIDMode.Static
                            txtDropDownList.CssClass = CssClassControl
                            txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                            txtDropDownList.ToolTip = "Escoja la opci�n de men�"
                            Cell.Controls.Add(txtDropDownList)
                            Cell.Controls.Add(New LiteralControl("<br /> "))

                            txtDropDownList = New DropDownList
                            txtDropDownList.ID = "ddlDocumentos"
                            txtDropDownList.ClientIDMode = ClientIDMode.Static
                            txtDropDownList.CssClass = CssClassControl
                            txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                            txtDropDownList.ToolTip = "Documentos actualmente vinculados"
                            Cell.Controls.Add(txtDropDownList)
                            Cell.Controls.Add(New LiteralControl("<br /> "))

                            txtCascadeDropDownList = New CascadingDropDown
                            txtCascadeDropDownList.ID = "cddAmbitos"
                            txtCascadeDropDownList.ClientIDMode = ClientIDMode.Static
                            txtCascadeDropDownList.TargetControlID = "ddlAmbitos"
                            txtCascadeDropDownList.Category = "Ambitos"
                            txtCascadeDropDownList.PromptText = "Escoja un �mbito ...."
                            txtCascadeDropDownList.LoadingText = "Por favor espere ..."
                            txtCascadeDropDownList.ServicePath = "AmbitosService.asmx"
                            txtCascadeDropDownList.ServiceMethod = "GetAmbitos"
                            Cell.Controls.Add(txtCascadeDropDownList)

                            txtCascadeDropDownList = New CascadingDropDown
                            txtCascadeDropDownList.ID = "cddHojas"
                            txtCascadeDropDownList.ClientIDMode = ClientIDMode.Static
                            txtCascadeDropDownList.TargetControlID = "ddlHojas"
                            txtCascadeDropDownList.ParentControlID = "ddlAmbitos"
                            txtCascadeDropDownList.Category = "Hojas"
                            txtCascadeDropDownList.PromptText = "Escoja una opci�n del men� ...."
                            txtCascadeDropDownList.LoadingText = "Por favor espere ..."
                            txtCascadeDropDownList.ServicePath = "AmbitosService.asmx"
                            txtCascadeDropDownList.ServiceMethod = "GetHojas"
                            Cell.Controls.Add(txtCascadeDropDownList)

                            txtCascadeDropDownList = New CascadingDropDown
                            txtCascadeDropDownList.ID = "cddDocumentos"
                            txtCascadeDropDownList.ClientIDMode = ClientIDMode.Static
                            txtCascadeDropDownList.TargetControlID = "ddlDocumentos"
                            txtCascadeDropDownList.ParentControlID = "ddlHojas"
                            txtCascadeDropDownList.Category = "Documentos"
                            txtCascadeDropDownList.PromptText = "Escoja una opci�n del men� ...."
                            txtCascadeDropDownList.LoadingText = "Por favor espere ..."
                            txtCascadeDropDownList.ServicePath = "AmbitosService.asmx"
                            txtCascadeDropDownList.ServiceMethod = "GetDocumentos"
                            Cell.Controls.Add(txtCascadeDropDownList)
                        Case "AutocompleteSearch"
                            txtCheckBox = New CheckBox
                            txtCheckBox.ID = "chk" & arrNodesControl(m)
                            txtCheckBox.ClientIDMode = ClientIDMode.Static
                            txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrNodesLabel(m)
                            Cell.Controls.Add(txtCheckBox)
                            Cell.Controls.Add(New LiteralControl(" "))
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrNodesControl(m)
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtTextBox.TextMode = ControlTextMode
                            If ControlTextMode = 1 Then
                                txtTextBox.Height = "50"
                            End If
                            txtTextBox.ToolTip = ToolTip
                            If IsNotEnabledField Then
                                txtTextBox.Enabled = False
                            End If
                            Cell.Controls.Add(txtTextBox)
                            AutoComp = New AutoCompleteExtender
                            AutoComp.ID = "Autocomplete" & arrNodesControl(m)
                            AutoComp.ClientIDMode = UI.ClientIDMode.Static
                            AutoComp.CompletionListItemCssClass = CssClassControl
                            AutoComp.TargetControlID = arrNodesControl(m)
                            AutoComp.ServicePath = SelectCommand
                            AutoComp.ServiceMethod = FormularioWebServiceCall
                            AutoComp.MinimumPrefixLength = "2"
                            AutoComp.CompletionInterval = "1000"
                            AutoComp.EnableCaching = "true"
                            AutoComp.CompletionSetCount = "12"
                            Cell.Controls.Add(AutoComp)
                        Case "SelectFromModalList"   'Se agrega para proyecto con Importadora Vergara
                            Cell.Controls.Add(New LiteralControl("<input id=""btnModal""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""?"" onclick=""verModal" & arrNodesControl(m) & "('SelectFromModalList.aspx?Accion=" & SelectCommand & "')"" style=""width: 20px"" /> "))
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrNodesControl(m)
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtTextBox.TextMode = ControlTextMode
                            txtTextBox.ToolTip = ToolTip
                            If IsNotEnabledField Then
                                txtTextBox.Enabled = False
                            End If
                            Cell.Controls.Add(txtTextBox)
                            Cell.Controls.Add(New LiteralControl(" <input id=""btnHelp" & arrNodesControl(m) & """ class=""boxceleste"" type=""button"" value=""..."" onclick=""return btnHelp" & arrNodesControl(m) & "_onclick()"" style=""width: 30px"" /> "))

                            '<asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" autoComplete="off" Width="200px"  ></asp:TextBox>
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrNodesControl(m) & "Description"
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = "350px"
                            txtTextBox.TextMode = ControlTextMode
                            txtTextBox.Enabled = False
                            Cell.Controls.Add(txtTextBox)
                            'Cell.Controls.Add(New LiteralControl("<input id=""btnHelpCodigo""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""Leer por Nombre"" onclick=""return btnHelpNombre" & arrNodesControl(m) & "_onclick()"" style=""width: 100px"" />"))
                            Cell.Controls.Add(New LiteralControl(GenerarJScript(arrNodesControl(m), SelectCommand)))
                        Case "DropDownListPlusDescription"
                            txtDropDownList = New DropDownList
                            txtDropDownList.ID = arrNodesControl(m)
                            txtDropDownList.ClientIDMode = ClientIDMode.Static
                            txtDropDownList.CssClass = CssClassControl
                            txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtDropDownList.ToolTip = ToolTip
                            txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                            txtDropDownList.DataTextField = DataTextField
                            Cell.Controls.Add(txtDropDownList)


                            sqlSource  = New SqlDataSource()                    
                            sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                            sqlSource.SelectCommand = SelectCommand

                            sqlSource.ID = "ds" & arrNodesControl(m)
                            'sqlSource.DataFile = DataFile
                            'sqlSource.SelectCommand = SelectCommand
                            Cell.Controls.Add(sqlSource)

                            Cell.Controls.Add(New LiteralControl(" <input id=""btnHelp" & arrNodesControl(m) & """ class=""boxceleste"" type=""button"" value=""..."" onclick=""return btnHelp" & arrNodesControl(m) & "_onclick()"" style=""width: 30px"" /> "))

                            '<asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" autoComplete="off" Width="200px"  ></asp:TextBox>
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrNodesControl(m) & "Description"
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = "350px"
                            txtTextBox.TextMode = ControlTextMode
                            txtTextBox.Enabled = False
                            Cell.Controls.Add(txtTextBox)
                            'MiCellSubTab.Controls.Add(New LiteralControl("<input id=""btnHelpCodigo""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""Leer por Nombre"" onclick=""return btnHelpNombre" & arrNodesControl(m) & "_onclick()"" style=""width: 100px"" />"))
                            Cell.Controls.Add(New LiteralControl(GenerarJScriptOnlyDescription(arrNodesControl(m), SelectCommand)))



                    End Select

                    Row.Cells.Add(Cell)

                    If IsRequiredField Then
                        valTextBox = New RequiredFieldValidator
                        valTextBox.ID = "RequiredField" & arrControl(k)
                        valTextBox.ControlToValidate = arrControl(k)
                        valTextBox.Text = "*"
                        valTextBox.ErrorMessage = arrLabel(k) & " es un campo obligatorio"
                        valTextBox.CssClass = "tab_contenido"
                        valTextBox.ValidationGroup = GroupValidation
                        Cell.Controls.Add(valTextBox)
                    End If
                    Select Case DomainField
                        Case "Correo"
                            REValidacion = New RegularExpressionValidator
                            REValidacion.ID = "RegularExpression" & arrControl(k)
                            REValidacion.ControlToValidate = arrControl(k)
                            REValidacion.Text = "*"
                            REValidacion.ErrorMessage = "La direcci�n de correo no tiene un formato valido"
                            REValidacion.CssClass = "tab_contenido"
                            REValidacion.ValidationGroup = GroupValidation
                            REValidacion.ValidationExpression = "\S+@\S+\.\S{2,3}"
                            Cell.Controls.Add(REValidacion)
                        Case "RUT"
                            CuValidacion = New CustomValidator
                            CuValidacion.ID = "RutValidator" & arrControl(k)
                            CuValidacion.ControlToValidate = arrControl(k)
                            CuValidacion.Text = "*"
                            CuValidacion.ErrorMessage = "El RUT no es valido"
                            CuValidacion.CssClass = "tab_contenido"
                            CuValidacion.ValidationGroup = GroupValidation
                            CuValidacion.EnableClientScript = True
                            CuValidacion.ClientValidationFunction = "RutValidator_ClientValidate"
                            Cell.Controls.Add(CuValidacion)
                        Case "Numeros"
                            CoValidacion = New CompareValidator
                            CoValidacion.ID = "CompareValidator" & arrControl(k)
                            CoValidacion.ControlToValidate = arrControl(k)
                            CoValidacion.Text = "*"
                            CoValidacion.ErrorMessage = arrLabel(k) & " debe ser un valor num�rico"
                            CoValidacion.CssClass = "tab_contenido"
                            CoValidacion.ValidationGroup = GroupValidation
                            CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                            CoValidacion.Type = ValidationDataType.Integer
                            Cell.Controls.Add(CoValidacion)
                        Case "Letras"
                            CoValidacion = New CompareValidator
                            CoValidacion.ID = "CompareValidator" & arrControl(k)
                            CoValidacion.ControlToValidate = arrControl(k)
                            CoValidacion.Text = "*"
                            CoValidacion.ErrorMessage = arrLabel(k) & " debe ser un valor alfanum�rico"
                            CoValidacion.CssClass = "tab_contenido"
                            CoValidacion.ValidationGroup = GroupValidation
                            CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                            CoValidacion.Type = ValidationDataType.String
                            Cell.Controls.Add(CoValidacion)
                        Case "Fecha"
                            CoValidacion = New CompareValidator
                            CoValidacion.ID = "CompareValidator" & arrControl(k)
                            CoValidacion.ControlToValidate = arrControl(k)
                            CoValidacion.Text = "*"
                            CoValidacion.ErrorMessage = arrLabel(k) & " debe ser una fecha valida"
                            CoValidacion.CssClass = "tab_contenido"
                            CoValidacion.ValidationGroup = GroupValidation
                            CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                            CoValidacion.Type = ValidationDataType.Date
                            Cell.Controls.Add(CoValidacion)

                    End Select
                    MyTable.Rows.Add(Row)
                Else
                    txtTextBox = New TextBox
                    txtTextBox.ID = arrNodesControl(m)
                    txtTextBox.ClientIDMode = ClientIDMode.Static
                    txtTextBox.CssClass = CssClassControl
                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    txtTextBox.TextMode = ControlTextMode
                    txtTextBox.ToolTip = ToolTip
                    txtTextBox.Enabled = False
                    txtTextBox.Visible = False
                    MyView.Controls.Add(txtTextBox)
                End If
            Next

            'Linea de Divisi�n
            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Height = "4"
            Cell.ColumnSpan = "2"
            Cell.Controls.Add(New LiteralControl("<hr />"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)

            'Botones del Formulario
            i = 0
            t = Lecturas.LeerButtonFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            Row = New TableRow
            Cell = New TableCell
            Cell.CssClass = CssClassLabel
            Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
            Cell.Style(HtmlTextWriterStyle.Width) = "20%"
            Row.Cells.Add(Cell)
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.Width) = "80%"
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Button", GroupValidation, NumeroPagina, k + 1)
                Select Case arrControl(k)
                    Case "LoginButton"
                        LoginButton = New Button
                        LoginButton.ID = arrControl(k)
                        LoginButton.CssClass = CssClassControl
                        LoginButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        LoginButton.Text = arrLabel(k)
                        LoginButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            LoginButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler LoginButton.Click, AddressOf RFC_Login
                        Cell.Controls.Add(LoginButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "CancelButton"
                        CancelButton = New Button
                        CancelButton.ID = arrControl(k)
                        CancelButton.CssClass = CssClassControl
                        CancelButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        CancelButton.Text = arrLabel(k)
                        CancelButton.ToolTip = ToolTip
                        'AddHandler CancelButton.Click, AddressOf RFC_Logout
                        Cell.Controls.Add(CancelButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "UpdateButton"
                        UpdateButton = New Button
                        UpdateButton.ID = arrControl(k)
                        UpdateButton.CssClass = CssClassControl
                        UpdateButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        UpdateButton.Text = arrLabel(k)
                        UpdateButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            UpdateButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(UpdateButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "NextButton"
                        NextButton = New Button
                        NextButton.ID = arrControl(k)
                        NextButton.CssClass = CssClassControl
                        NextButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        NextButton.Text = arrLabel(k)
                        NextButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            NextButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(NextButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "NewButton"
                        NewButton = New Button
                        NewButton.ID = arrControl(k)
                        NewButton.CssClass = CssClassControl
                        NewButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        NewButton.Text = arrLabel(k)
                        NewButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            NewButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(NewButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "PrevButton"
                        PrevButton = New Button
                        PrevButton.ID = arrControl(k)
                        PrevButton.CssClass = CssClassControl
                        PrevButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        PrevButton.Text = arrLabel(k)
                        PrevButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            PrevButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(PrevButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "SearchButton"
                        SearchButton = New Button
                        SearchButton.ID = arrControl(k)
                        SearchButton.CssClass = CssClassControl
                        SearchButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        SearchButton.Text = arrLabel(k)
                        SearchButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            SearchButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(SearchButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "DeleteButton"
                        DeleteButton = New Button
                        DeleteButton.ID = arrControl(k)
                        DeleteButton.CssClass = CssClassControl
                        DeleteButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        DeleteButton.Text = arrLabel(k)
                        DeleteButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            DeleteButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler DeleteButton.Click, AddressOf RFC_Delete
                        Cell.Controls.Add(DeleteButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "ReturnButton"
                        ReturnButton = New Button
                        ReturnButton.ID = arrControl(k)
                        ReturnButton.CssClass = CssClassControl
                        ReturnButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        ReturnButton.Text = arrLabel(k)
                        ReturnButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            ReturnButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler ReturnButton.Click, AddressOf RFC_Return
                        Cell.Controls.Add(ReturnButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                End Select
            Next

            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
            MyView.Controls.Add(MyTable)
        End If
    End Sub








    Public Function LeerPortalByName(ByVal PortalesName As String, ByRef PortalesId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Portales.PortalesId "
        sSQL = sSQL & "FROM (Portales) "
        sSQL = sSQL & "WHERE ((Portales.PortalesName) = '" & PortalesName & "')"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                PortalesId = CLng(dtr("PortalesId").ToString)
            End While
            LeerPortalByName = True
            dtr.Close()
        Catch
            LeerPortalByName = False
            PortalesId = 0
        End Try
    End Function
    Public Function LeerPortal(ByVal PortalesId As Long, ByRef PortalesName As String, ByRef PortalesDescription As String, ByRef PortalesSecuencia As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select PortalesName, PortalesDescription, PortalesSecuencia "
        sSQL = sSQL & "FROM (Portales) "
        sSQL = sSQL & "WHERE (((Portales.PortalesId) = " & PortalesId & ")) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                PortalesName = dtr("PortalesName").ToString
                PortalesDescription = dtr("PortalesDescription").ToString
                PortalesSecuencia = CLng(dtr("PortalesSecuencia").ToString)
            End While
            LeerPortal = True
            dtr.Close()
        Catch
            LeerPortal = False
        End Try
    End Function
    Public Function LeerPortalMasterPage(ByVal PortalesId As Long, ByRef PortalesMasterPage As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select PortalesMasterPage "
        sSQL = sSQL & "FROM (Portales) "
        sSQL = sSQL & "WHERE (((Portales.PortalesId) = " & PortalesId & ")) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                PortalesMasterPage = dtr("PortalesMasterPage").ToString
            End While
            LeerPortalMasterPage = True
            dtr.Close()
        Catch
            LeerPortalMasterPage = False
        End Try
    End Function
    Public Function LeerURLPortal(ByVal PortalesName As String, ByRef UrlIndex As String, ByRef Logo1 As String, ByRef Banner As String, ByRef Logo2 As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select PortalesURLIndex as URLIndex, PortalesLogo1 As Logo1, PortalesBanner As Banner, PortalesLogo2 As Logo2 "
        sSQL = sSQL & "FROM (Portales) "
        sSQL = sSQL & "WHERE (((Portales.PortalesName) = '" & PortalesName & "')) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                UrlIndex = dtr("UrlIndex").ToString
                Logo1 = dtr("Logo1").ToString
                Banner = dtr("Banner").ToString
                Logo2 = dtr("Logo2").ToString
            End While
            LeerURLPortal = True
            dtr.Close()
        Catch
            LeerURLPortal = False
        End Try
    End Function
    Public Function LeerPaginaWebByName(ByVal PaginaWebName As String, ByRef PaginaWebId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select PaginaWeb.PaginaWebId "
        sSQL = sSQL & "FROM PaginaWeb "
        sSQL = sSQL & "WHERE ((PaginaWeb.PaginaWebName) = '" & PaginaWebName & "')"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                PaginaWebId = CLng(dtr("PaginaWebId").ToString)
            End While
            LeerPaginaWebByName = True
            dtr.Close()
        Catch
            LeerPaginaWebByName = False
            PaginaWebId = 0
        End Try
    End Function
    Public Function LeerFormularioWebNumber(ByVal PaginaWebName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select PaginaWeb.FormularioWebNumber "
        sSQL = sSQL & "FROM PaginaWeb "
        sSQL = sSQL & "WHERE ((PaginaWeb.PaginaWebName) = '" & PaginaWebName & "')"

        LeerFormularioWebNumber = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                LeerFormularioWebNumber = CLng(dtr("FormularioWebNumber").ToString)
            End While
            dtr.Close()
        Catch
            LeerFormularioWebNumber = 0

        End Try
    End Function

    Public Function LeerPagina(ByVal PaginaWebId As Long, ByRef PaginaWebName As String, ByRef PaginaWebTitle As String, ByRef PaginaWebDescription As String, ByRef FormularioWebNumber As Long, _
                                  ByRef PaginaWebGroupValidation As String, ByRef PaginaWebStereotype As String, ByRef PaginaWebUserControl As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select PaginaWebName, PaginaWebTitle, PaginaWebDescription, FormularioWebNumber, PaginaWebGroupValidation, PaginaWebStereotype, PaginaWebUserControl "
        sSQL = sSQL & "FROM PaginaWeb "
        sSQL = sSQL & "WHERE (((PaginaWeb.PaginaWebId) = " & PaginaWebId & ")) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                PaginaWebName = dtr("PaginaWebName").ToString
                PaginaWebTitle = dtr("PaginaWebTitle").ToString
                PaginaWebDescription = dtr("PaginaWebDescription").ToString
                FormularioWebNumber = CLng(dtr("FormularioWebNumber").ToString)
                PaginaWebGroupValidation = dtr("PaginaWebGroupValidation").ToString
                PaginaWebStereotype = dtr("PaginaWebStereotype").ToString
                PaginaWebUserControl = dtr("PaginaWebUserControl").ToString
            End While
            LeerPagina = True
            dtr.Close()
        Catch
            LeerPagina = False
        End Try
    End Function
    Public Function LeerMaximoId(ByVal sSQL As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader

        LeerMaximoId = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                LeerMaximoId = CLng(dtr("MaximoId").ToString)
            End While
            dtr.Close()
        Catch
            LeerMaximoId = 0
        End Try
    End Function
    Public Function LeerMenuOptions(ByVal MenuOptionsId As Long, ByRef MenuOptionsPID As Long, ByRef Secuencia As Long, _
                                ByRef GrupoOpciones As String, ByRef href As String, ByRef title As String, ByRef Texto As String, _
                                ByRef Logo As String, ByRef BarMenu As String, ByRef SideBarMenu As String, _
                                ByRef PaginaWebName As String, ByRef SystemId As Long, ByRef PortalesName As String, _
                                ByRef Zona As String, ByRef OptionsType As String, ByRef IsNodoHoja As String, _
                                ByRef IsPerfilable As Boolean, ByRef IsSubMenu As Boolean, ByRef Description As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select MenuOptionsPID, Secuencia, Class, href, title, Texto, Logo, BarMenu, SideBarMenu, PaginaWebName, SystemId, PortalesName, Zona, OptionsType, IsNodoHoja, IsPerfilable, IsSubMenu, Description "
        sSQL = sSQL & "FROM (MenuOptions) "
        sSQL = sSQL & "WHERE (((MenuOptions.MenuOptionsId) = " & MenuOptionsId & ")) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                MenuOptionsPID = CLng(dtr("MenuOptionsPId").ToString)
                Secuencia = CLng(dtr("Secuencia").ToString)
                GrupoOpciones = dtr("Class").ToString
                href = dtr("href").ToString
                title = dtr("title").ToString
                Texto = dtr("Texto").ToString
                Logo = dtr("Logo").ToString
                BarMenu = dtr("BarMenu").ToString
                SideBarMenu = dtr("SideBarMenu").ToString
                PaginaWebName = dtr("PaginaWebName").ToString
                SystemId = CLng(dtr("SystemId").ToString)
                PortalesName = dtr("PortalesName").ToString
                Zona = dtr("Zona").ToString
                OptionsType = dtr("OptionsType").ToString
                IsNodoHoja = dtr("IsNodoHoja").ToString
                IsPerfilable = dtr("IsPerfilable").ToString
                IsSubMenu = dtr("IsSubMenu").ToString
                Description = dtr("Description").ToString
            End While
            LeerMenuOptions = True
            dtr.Close()
        Catch
            LeerMenuOptions = False
        End Try
    End Function
    Public Sub MostrarFormulario(ByVal NumeroPagina As Integer, ByVal TituloPagina As String, _
                                    ByVal DescripcionPagina As String, ByVal GroupValidation As String, _
                                    ByRef MyView As PlaceHolder, ByRef sumValidacion As ValidationSummary, _
                                    ByRef valTextBox As RequiredFieldValidator, ByRef REValidacion As RegularExpressionValidator, _
                                    ByRef CuValidacion As CustomValidator, ByRef CoValidacion As CompareValidator, _
                                    ByRef LoginButton As Button, ByRef CancelButton As Button, ByRef UpdateButton As Button, _
                                    ByRef NewButton As Button, ByRef SearchButton As Button, ByRef DeleteButton As Button, ByRef ReturnButton As Button, _
                                    ByVal MenuOptionsId As Long, ByVal MasterName As String, ByVal MasterId As Long)


        'Request.QueryString("MenuOptionsId") & "&MasterName=" & MasterName & "&MasterId=" & MasterId

        '-------------------------- 05-08-2010 -----------------
        ' Esta nueva rutina es solo para mostrar un formulario, sin dejarlo operativo, solo se muestra
        ' bajo los datos de la p�gina que representa.
        '----------------------------------------------------------

        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim m As Integer = 0
        Dim n As Integer = 0
        Dim MyTable As Table
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim MiTablaSubTab As Table
        Dim MiRowSubTab As TableRow
        Dim MiCellSubTab As TableCell

        Dim arrLabel(21) As String
        Dim arrControl(21) As String
        Dim arrGrillaLabel(21) As String
        Dim arrGrillaControl(21) As String
        Dim ArrNodesId(21) As Long
        Dim arrNodesLabel(21) As String
        Dim arrNodesControl(21) As String
        Dim arrSubNodesId(21) As Long
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
        Dim Url As String = ""
        Dim FormularioWebPId As Long = 0
        Dim FormularioWebServiceCall As String = ""
        Dim FormularioWebEvent As String = ""
        Dim FormularioWebPageCall As String = ""
        Dim FormularioWebFormCall As String = ""
        Dim RegID As Long = 0

        Dim txtTextBox As TextBox
        Dim txtDropDownList As DropDownList
        Dim txtCheckBox As CheckBox
        Dim sqlSource As SqlDataSource
        Dim txtCalendar As CalendarExtender
        Dim ImgImages As Image
        Dim AutoComp As AutoCompleteExtender

        Dim sSQL As String = ""
        Dim HTMLCode As String = ""

        Dim AnchoTablaTabs As Integer = 0
        Dim sJavaScript As String = ""
        Dim ControlAtributes As String = ""

        AnchoTablaTabs = 122 * 3
        MyTable = New Table
        MyTable.ID = "ViewVista" & FormularioWebPId & NumeroPagina
        MyTable.Width = "700"
        MyTable.CellSpacing = "2"
        MyTable.CellPadding = "2"

        'Linea de Divisi�n
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.Height = "4"
        Cell.ColumnSpan = "3"
        Cell.Controls.Add(New LiteralControl("<hr />"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        Row = New TableRow
        For k = 1 To 3
            sJavaScript = ""
            For m = 1 To 3
                If m = k Then
                    sJavaScript = sJavaScript & "aparecer(""sub" & m & "sub"");"
                Else
                    sJavaScript = sJavaScript & "desaparecer(""sub" & m & "sub"");"
                End If
            Next
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
            Cell.Width = "120"
            Cell.CssClass = "boxceleste"

            Select Case k
                Case 1
                    Cell.Controls.Add(New LiteralControl("<a onclick='" & sJavaScript & "'>" & "Vista" & "</a>"))
                Case 2
                    Cell.Controls.Add(New LiteralControl("<a onclick='" & sJavaScript & "'>" & "Controles" & "</a>"))
                Case 3
                    Cell.Controls.Add(New LiteralControl("<a onclick='" & sJavaScript & "'>" & "Requerimientos" & "</a>"))
            End Select
            Row.Cells.Add(Cell)
        Next
        MyTable.Rows.Add(Row)

        MyView.Controls.Add(MyTable)

        MyView.Controls.Add(New LiteralControl("<div id=""sub1sub"" class=""visible"">"))

        MyTable = New Table
        MyTable.ID = "Despliegue" & NumeroPagina
        MyTable.Width = "700"
        MyTable.CellSpacing = "2"
        MyTable.CellPadding = "2"
        MyTable.CssClass = "visible"
        'Linea de Divisi�n
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
        Cell.Height = "4"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("<hr />"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        'Titulo
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "subtit"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("Visualizaci�n del formato de la P�gina Web"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        'Linea de Divisi�n
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.Height = "4"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("<hr />"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        MyView.Controls.Add(MyTable)



        ' Primero se despliegan
        ' los campos que son de contexto y que no pueden ser alterados por ning�n motivo, como
        ' por ejemplo aquellos campos que son claves �nicas y que no pueden ser modificados
        ' o aquellos campos que corresponden a la foreing key hacia la tabla padre, en el
        ' caso de una aplicaci�n del tipo master-detail.

        ' Estos campos se encuentran en la section FormKeys y pueden no existir para determinados
        ' tipos de formularios y se leen mediante el metodo 
        ' LeerKeysFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        t = Lecturas.LeerKeysFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        ' Bajo el nuevo esquema, creo otra tabla para los campos claves y la sumo al placeholder




        MyTable = New Table
        MyTable.ID = "ViewKeys" & NumeroPagina
        MyTable.Width = "700"
        MyTable.CellSpacing = "2"
        MyTable.CellPadding = "2"
        If i > 0 Then
            Row = New TableRow
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWebConID(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "FormKeys", GroupValidation, NumeroPagina, k + 1, RegID)
                'aqui va la creaci�n de la fila
                Cell = New TableCell
                Cell.CssClass = CssClassLabel
                Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
                Cell.Style(HtmlTextWriterStyle.Width) = "10%"
                ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                ControlAtributes = ControlAtributes & "Obligatorio? : " & IsRequiredField.ToString & vbCrLf
                ControlAtributes = ControlAtributes & "Is Not Enabled? : " & IsNotEnabledField.ToString & vbCrLf
                ControlAtributes = ControlAtributes & "Dominio : " & DomainField & vbCrLf
                ControlAtributes = ControlAtributes & "Secci�n : " & "FormKeys" & vbCrLf
                ControlAtributes = ControlAtributes & "SQL : " & SelectCommand
                Cell.ToolTip = ControlAtributes

                'Linea para incorporar el link para Modificar un control de la P�gina.
                Dim linkFormKeys As String = "AdministraEntidades.aspx?PaginaWebName=Ficha de FormularioWeb&ID=" & RegID & "&MenuOptionsId=" & MenuOptionsId & "&MasterName=" & MasterName & "&MasterId=" & MasterId & "&Section=FormKeys&Number=" & NumeroPagina
                Url = "<a href='" & linkFormKeys & "'>" & arrLabel(k) & "</a>"
                Cell.Controls.Add(New LiteralControl(Url & " : "))
                '-----------
                Row.Cells.Add(Cell)
                Cell = New TableCell
                Cell.Style(HtmlTextWriterStyle.Width) = "40%"
                txtTextBox = New TextBox
                txtTextBox.ID = arrControl(k)
                txtTextBox.ClientIDMode = ClientIDMode.Static
                txtTextBox.CssClass = CssClassControl
                txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                txtTextBox.TextMode = ControlTextMode
                If ControlTextMode = 1 Then
                    txtTextBox.Height = "50"
                End If
                txtTextBox.ToolTip = ToolTip
                If IsNotEnabledField Then
                    txtTextBox.Enabled = False
                End If
                Cell.Controls.Add(txtTextBox)
                Row.Cells.Add(Cell)
                ' Aqu� se suma la fila
            Next
            MyTable.Rows.Add(Row)
            'Linea de Divisi�n
            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Height = "4"
            Cell.ColumnSpan = "4"  ' Se pone 4 esta vez para desplegar a 2 columnas
            Cell.Controls.Add(New LiteralControl("<hr />"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
        End If
        MyView.Controls.Add(MyTable)

        ' A continuaci�n pongo los textos de identificaci�n de la p�gina, que fueron pasados como
        ' par�metros de invocaci�n

        MyTable = New Table
        MyTable.ID = "ViewHeader" & NumeroPagina
        MyTable.Width = "700"
        MyTable.CellSpacing = "2"
        MyTable.CellPadding = "2"
        MyTable.CssClass = "visible"
        'Titulo
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "subtit"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl(TituloPagina))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        'Linea de Divisi�n
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.Height = "4"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("<hr />"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        'Descripci�n
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "tab_contenido"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl(DescripcionPagina))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        MyView.Controls.Add(MyTable)

        'Luego se agrega la tabla de control de validaci�n de los campos
        ' No tiene sentido para efectos de solo mostrar el formulario

        i = 0

        t = Lecturas.LeerHeaderFormularioWeb(arrLabel, arrControl, NumeroPagina, i, FormularioWebPId)

        If i = 1 Then

            i = 0
            t = Lecturas.LeerNodesFormularioWeb(arrLabel, arrControl, ArrNodesId, i, FormularioWebPId)

            'Creamos tabla y la �nica fila
            AnchoTablaTabs = 116 * (i + 1)
            MyTable = New Table
            MyTable.ID = "ViewBody" & FormularioWebPId & NumeroPagina
            MyTable.Width = AnchoTablaTabs
            MyTable.CellSpacing = "2"
            MyTable.CellPadding = "2"
            Row = New TableRow
            For k = 0 To i - 1
                sJavaScript = ""
                For m = 0 To i - 1
                    If m = k Then
                        sJavaScript = sJavaScript & "aparecer(""sub" & arrControl(m) & "sub"");"
                    Else
                        sJavaScript = sJavaScript & "desaparecer(""sub" & arrControl(m) & "sub"");"
                    End If
                Next
                Cell = New TableCell
                Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
                Cell.Width = "120"
                Cell.CssClass = "boxceleste"
                ControlAtributes = "Etiqueta Grupo: " & arrLabel(k) & vbCrLf
                ControlAtributes = ControlAtributes & "Field Group: " & arrControl(k) & vbCrLf
                ControlAtributes = ControlAtributes & "Width: " & "120" & vbCrLf
                ControlAtributes = ControlAtributes & "Secci�n : " & "FormGroup"
                Cell.ToolTip = ControlAtributes
                Cell.Controls.Add(New LiteralControl("<a onclick='" & sJavaScript & "'>" & arrLabel(k) & "</a>"))
                Row.Cells.Add(Cell)
            Next
            sJavaScript = ""
            For m = 0 To i - 1
                sJavaScript = sJavaScript & "todosvisibles(""sub" & arrControl(m) & "sub"");"
            Next
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
            Cell.Width = "120"
            Cell.CssClass = "boxceleste"
            Cell.Controls.Add(New LiteralControl("<a onclick='" & sJavaScript & "'>" & "Ver ficha completa" & "</a>"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
            MyView.Controls.Add(MyTable)
            'Con el mismo arreglo de nodos, vuelvo a recorrerlos pero ahora por cada uno, leo sus nodos hijos
            'para asi cargos los controles del formulario web.

            If i > 0 Then
                For k = 0 To i - 1
                    n = 0
                    t = Lecturas.LeerNodesFormularioWeb(arrNodesLabel, arrNodesControl, arrSubNodesId, n, ArrNodesId(k))
                    'Aqui acabo de leer los nodos del primer tab, por ahora no hay m�s anidamiento, asi que cada nodo
                    'en arrNodesLabel es en realidad una hoja
                    MiTablaSubTab = New Table
                    MiTablaSubTab.ID = "sub" & arrControl(k) & "sub"
                    MiTablaSubTab.ClientIDMode = ClientIDMode.Static
                    MiTablaSubTab.Width = "700"
                    MiTablaSubTab.Caption = arrLabel(k)
                    MiTablaSubTab.CaptionAlign = TableCaptionAlign.Left
                    MiTablaSubTab.CellSpacing = "2"
                    MiTablaSubTab.CellPadding = "2"
                    If k = 0 Then
                        MiTablaSubTab.CssClass = "visible"
                    Else
                        MiTablaSubTab.CssClass = "invisible"
                    End If
                    MiTablaSubTab.BackColor = Drawing.Color.WhiteSmoke
                    MiTablaSubTab.BorderStyle = BorderStyle.Solid
                    MiTablaSubTab.BorderWidth = 1
                    MiTablaSubTab.BorderColor = Drawing.Color.WhiteSmoke

                    'Controles del Formulario Web
                    For m = 0 To n - 1
                        t = Lecturas.LeerLeafFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, GroupValidation, FormularioWebServiceCall, arrSubNodesId(m))
                        MiRowSubTab = New TableRow
                        MiCellSubTab = New TableCell
                        MiCellSubTab.CssClass = CssClassLabel
                        MiCellSubTab.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
                        MiCellSubTab.Style(HtmlTextWriterStyle.Width) = "20%"
                        ControlAtributes = "Etiqueta Grupo: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field Group: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Etiqueta: " & arrNodesLabel(m) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrNodesControl(m) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Obligatorio? : " & IsRequiredField.ToString & vbCrLf
                        ControlAtributes = ControlAtributes & "Is Not Enabled? : " & IsNotEnabledField.ToString & vbCrLf
                        ControlAtributes = ControlAtributes & "Dominio : " & DomainField & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Form" & vbCrLf
                        ControlAtributes = ControlAtributes & "SQL : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "M�todo de la WS: " & FormularioWebServiceCall
                        MiCellSubTab.ToolTip = ControlAtributes
                        MiCellSubTab.Controls.Add(New LiteralControl(arrNodesLabel(m) & " : "))
                        MiRowSubTab.Cells.Add(MiCellSubTab)
                        MiCellSubTab = New TableCell
                        MiCellSubTab.Style(HtmlTextWriterStyle.Width) = "80%"
                        Select Case TipoControl
                            Case "TextBox"
                                txtTextBox = New TextBox
                                txtTextBox.ID = arrNodesControl(m)
                                'txtTextBox.ClientIDMode = ClientIDMode.Static
                                txtTextBox.CssClass = CssClassControl
                                txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                txtTextBox.TextMode = ControlTextMode
                                If ControlTextMode = 1 Then
                                    txtTextBox.Height = "50"
                                End If
                                txtTextBox.ToolTip = ToolTip
                                If IsNotEnabledField Then
                                    txtTextBox.Enabled = False
                                End If
                                MiCellSubTab.Controls.Add(txtTextBox)
                            Case "CheckBox"
                                txtCheckBox = New CheckBox
                                txtCheckBox.ID = arrNodesControl(m)
                                txtCheckBox.ToolTip = ToolTip
                                MiCellSubTab.Controls.Add(txtCheckBox)
                            Case "TextBoxAutoComplete"
                                txtTextBox = New TextBox
                                txtTextBox.ID = arrNodesControl(m)
                                'txtTextBox.ClientIDMode = ClientIDMode.Static
                                txtTextBox.CssClass = CssClassControl
                                txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                txtTextBox.TextMode = ControlTextMode
                                If ControlTextMode = 1 Then
                                    txtTextBox.Height = "50"
                                End If
                                txtTextBox.ToolTip = ToolTip
                                If IsNotEnabledField Then
                                    txtTextBox.Enabled = False
                                End If
                                MiCellSubTab.Controls.Add(txtTextBox)
                                AutoComp = New AutoCompleteExtender
                                AutoComp.ID = "Autocomplete" & arrNodesControl(m)
                                'AutoComp.ClientIDMode = UI.ClientIDMode.Static
                                AutoComp.CompletionListItemCssClass = CssClassControl
                                AutoComp.TargetControlID = arrNodesControl(m)
                                AutoComp.ServicePath = "AutoComplete.asmx"
                                AutoComp.ServiceMethod = FormularioWebServiceCall
                                AutoComp.MinimumPrefixLength = "2"
                                AutoComp.CompletionInterval = "1000"
                                AutoComp.EnableCaching = "true"
                                AutoComp.CompletionSetCount = "12"
                                MiCellSubTab.Controls.Add(AutoComp)
                            Case "TextBoxCalendar"
                                txtTextBox = New TextBox
                                txtTextBox.ID = arrNodesControl(m)
                                'txtTextBox.ClientIDMode = ClientIDMode.Static
                                txtTextBox.CssClass = CssClassControl
                                txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                txtTextBox.TextMode = ControlTextMode
                                txtTextBox.ToolTip = ToolTip
                                If IsNotEnabledField Then
                                    txtTextBox.Enabled = False
                                End If
                                MiCellSubTab.Controls.Add(txtTextBox)
                                MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                ImgImages = New Image
                                ImgImages.ID = "Image" & arrNodesControl(m)
                                'ImgImages.ClientIDMode = UI.ClientIDMode.Static
                                ImgImages.ImageUrl = "img/Calendar_scheduleHS.png"
                                ImgImages.ImageAlign = ImageAlign.Middle
                                MiCellSubTab.Controls.Add(ImgImages)
                                txtCalendar = New CalendarExtender
                                txtCalendar.ID = "Calendar" & arrNodesControl(m)
                                'txtCalendar.ClientIDMode = UI.ClientIDMode.Static
                                txtCalendar.TargetControlID = arrNodesControl(m)
                                txtCalendar.PopupButtonID = "Image" & arrNodesControl(m)
                                txtCalendar.Format = "dd/MMM/yy"
                                MiCellSubTab.Controls.Add(txtCalendar)
                            Case "DropDownList"
                                txtDropDownList = New DropDownList
                                txtDropDownList.ID = arrNodesControl(m)
                                'txtDropDownList.ClientIDMode = ClientIDMode.Static
                                txtDropDownList.CssClass = CssClassControl
                                txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                txtDropDownList.ToolTip = ToolTip
                                txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                txtDropDownList.DataTextField = DataTextField
                                MiCellSubTab.Controls.Add(txtDropDownList)

                                sqlSource  = New SqlDataSource()                    
                                sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                sqlSource.SelectCommand = SelectCommand

                                sqlSource.ID = "ds" & arrNodesControl(m)
                                'sqlSource.DataFile = DataFile
                                'sqlSource.SelectCommand = SelectCommand
                                MiCellSubTab.Controls.Add(sqlSource)
                            Case "DropDownSearch"
                                txtCheckBox = New CheckBox
                                txtCheckBox.ID = "chk" & arrNodesControl(m)
                                'txtCheckBox.ClientIDMode = ClientIDMode.Static
                                txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrNodesLabel(m)
                                MiCellSubTab.Controls.Add(txtCheckBox)
                                MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                txtDropDownList = New DropDownList
                                txtDropDownList.ID = arrNodesControl(m)
                                'txtDropDownList.ClientIDMode = ClientIDMode.Static
                                txtDropDownList.CssClass = CssClassControl
                                txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                txtDropDownList.ToolTip = ToolTip
                                txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                txtDropDownList.DataTextField = DataTextField
                                MiCellSubTab.Controls.Add(txtDropDownList)


                                sqlSource  = New SqlDataSource()                    
                                sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                sqlSource.SelectCommand = SelectCommand

                                sqlSource.ID = "ds" & arrNodesControl(m)
                                'sqlSource.DataFile = DataFile
                                'sqlSource.SelectCommand = SelectCommand
                                MiCellSubTab.Controls.Add(sqlSource)

                        End Select

                        MiRowSubTab.Cells.Add(MiCellSubTab)
                        MiTablaSubTab.Rows.Add(MiRowSubTab)
                    Next

                    MyView.Controls.Add(MiTablaSubTab)
                Next
            End If

            ' Creamos nuevamente la tabla
            MyTable = New Table
            MyTable.ID = "ViewButtons" & NumeroPagina
            MyTable.Width = "700"
            MyTable.CellSpacing = "2"
            MyTable.CellPadding = "2"

            'Botones del Formulario
            i = 0
            t = Lecturas.LeerButtonFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            Row = New TableRow
            Cell = New TableCell
            Cell.CssClass = CssClassLabel
            Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
            Cell.Style(HtmlTextWriterStyle.Width) = "20%"
            Row.Cells.Add(Cell)
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.Width) = "80%"
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Button", GroupValidation, NumeroPagina, k + 1)
                t = Lecturas.LeerControlButtonFormularioWeb(FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebServiceCall, "Button", NumeroPagina, k + 1)
                Select Case arrControl(k)
                    Case "LoginButton"
                        LoginButton = New Button
                        LoginButton.ID = arrControl(k) & NumeroPagina
                        LoginButton.CssClass = CssClassControl
                        LoginButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        LoginButton.Text = arrLabel(k)
                        ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Group Validations : " & GroupValidation & vbCrLf
                        ControlAtributes = ControlAtributes & "ToolTip : " & ToolTip & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Button" & vbCrLf
                        ControlAtributes = ControlAtributes & "Select : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "Evento : " & FormularioWebEvent & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Page : " & FormularioWebPageCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Form : " & FormularioWebFormCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Servicio : " & FormularioWebServiceCall
                        LoginButton.ToolTip = ControlAtributes
                        LoginButton.Enabled = False
                        'AddHandler LoginButton.Click, AddressOf RFC_Login
                        Cell.Controls.Add(LoginButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "CancelButton"
                        CancelButton = New Button
                        CancelButton.ID = arrControl(k) & NumeroPagina
                        CancelButton.CssClass = CssClassControl
                        CancelButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        CancelButton.Text = arrLabel(k)
                        ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Group Validations : " & GroupValidation & vbCrLf
                        ControlAtributes = ControlAtributes & "ToolTip : " & ToolTip & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Button" & vbCrLf
                        ControlAtributes = ControlAtributes & "Select : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "Evento : " & FormularioWebEvent & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Page : " & FormularioWebPageCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Form : " & FormularioWebFormCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Servicio : " & FormularioWebServiceCall
                        CancelButton.ToolTip = ControlAtributes
                        CancelButton.Enabled = False
                        'AddHandler CancelButton.Click, AddressOf RFC_Logout
                        Cell.Controls.Add(CancelButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "UpdateButton"
                        UpdateButton = New Button
                        UpdateButton.ID = arrControl(k) & NumeroPagina
                        UpdateButton.CssClass = CssClassControl
                        UpdateButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        UpdateButton.Text = arrLabel(k)
                        ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Group Validations : " & GroupValidation & vbCrLf
                        ControlAtributes = ControlAtributes & "ToolTip : " & ToolTip & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Button" & vbCrLf
                        ControlAtributes = ControlAtributes & "Select : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "Evento : " & FormularioWebEvent & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Page : " & FormularioWebPageCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Form : " & FormularioWebFormCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Servicio : " & FormularioWebServiceCall
                        UpdateButton.ToolTip = ControlAtributes
                        UpdateButton.Enabled = False
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(UpdateButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "NewButton"
                        NewButton = New Button
                        NewButton.ID = arrControl(k) & NumeroPagina
                        NewButton.CssClass = CssClassControl
                        NewButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        NewButton.Text = arrLabel(k)
                        ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Group Validations : " & GroupValidation & vbCrLf
                        ControlAtributes = ControlAtributes & "ToolTip : " & ToolTip & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Button" & vbCrLf
                        ControlAtributes = ControlAtributes & "Select : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "Evento : " & FormularioWebEvent & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Page : " & FormularioWebPageCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Form : " & FormularioWebFormCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Servicio : " & FormularioWebServiceCall
                        NewButton.ToolTip = ControlAtributes
                        NewButton.Enabled = False
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(NewButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "SearchButton"
                        SearchButton = New Button
                        SearchButton.ID = arrControl(k) & NumeroPagina
                        SearchButton.CssClass = CssClassControl
                        SearchButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        SearchButton.Text = arrLabel(k)
                        ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Group Validations : " & GroupValidation & vbCrLf
                        ControlAtributes = ControlAtributes & "ToolTip : " & ToolTip & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Button" & vbCrLf
                        ControlAtributes = ControlAtributes & "Select : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "Evento : " & FormularioWebEvent & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Page : " & FormularioWebPageCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Form : " & FormularioWebFormCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Servicio : " & FormularioWebServiceCall
                        SearchButton.ToolTip = ControlAtributes
                        SearchButton.Enabled = False
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(SearchButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "DeleteButton"
                        DeleteButton = New Button
                        DeleteButton.ID = arrControl(k) & NumeroPagina
                        DeleteButton.CssClass = CssClassControl
                        DeleteButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        DeleteButton.Text = arrLabel(k)
                        ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Group Validations : " & GroupValidation & vbCrLf
                        ControlAtributes = ControlAtributes & "ToolTip : " & ToolTip & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Button" & vbCrLf
                        ControlAtributes = ControlAtributes & "Select : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "Evento : " & FormularioWebEvent & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Page : " & FormularioWebPageCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Form : " & FormularioWebFormCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Servicio : " & FormularioWebServiceCall
                        DeleteButton.ToolTip = ControlAtributes
                        DeleteButton.Enabled = False
                        'AddHandler DeleteButton.Click, AddressOf RFC_Delete
                        Cell.Controls.Add(DeleteButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "ReturnButton"
                        ReturnButton = New Button
                        ReturnButton.ID = arrControl(k) & NumeroPagina
                        ReturnButton.CssClass = CssClassControl
                        ReturnButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        ReturnButton.Text = arrLabel(k)
                        ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Group Validations : " & GroupValidation & vbCrLf
                        ControlAtributes = ControlAtributes & "ToolTip : " & ToolTip & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Button" & vbCrLf
                        ControlAtributes = ControlAtributes & "Select : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "Evento : " & FormularioWebEvent & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Page : " & FormularioWebPageCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Form : " & FormularioWebFormCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Servicio : " & FormularioWebServiceCall
                        ReturnButton.ToolTip = ControlAtributes
                        'AddHandler ReturnButton.Click, AddressOf RFC_Return
                        ReturnButton.Enabled = False
                        Cell.Controls.Add(ReturnButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                End Select
            Next

            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
            MyView.Controls.Add(MyTable)
        Else

            ' Significa que no hay tabs definidos para el formulario en cuesti�n y que 
            ' por tanto la l�gica de despliegue es la misma de siempre y podremos hacer todo
            ' en una �nica tabla y luego agregarla a la view.

            MyTable = New Table
            MyTable.ID = "ViewBody" & NumeroPagina
            MyTable.Width = "700"
            MyTable.CellSpacing = "2"
            MyTable.CellPadding = "2"


            'Linea de Divisi�n
            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Height = "4"
            Cell.ColumnSpan = "2"
            Cell.Controls.Add(New LiteralControl("<hr />"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)

            i = 0
            t = Lecturas.LeerLabelFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

            'Controles del Formulario Web
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Form", GroupValidation, NumeroPagina, k + 1)
                Row = New TableRow
                Cell = New TableCell
                Cell.CssClass = CssClassLabel
                Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
                Cell.Style(HtmlTextWriterStyle.Width) = "20%"
                ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                ControlAtributes = ControlAtributes & "Obligatorio? : " & IsRequiredField.ToString & vbCrLf
                ControlAtributes = ControlAtributes & "Is Not Enabled? : " & IsNotEnabledField.ToString & vbCrLf
                ControlAtributes = ControlAtributes & "Dominio : " & DomainField & vbCrLf
                ControlAtributes = ControlAtributes & "Secci�n : " & "Form" & vbCrLf
                ControlAtributes = ControlAtributes & "SQL : " & SelectCommand & vbCrLf
                ControlAtributes = ControlAtributes & "M�todo de la WS: " & FormularioWebServiceCall
                Cell.ToolTip = ControlAtributes
                Cell.Controls.Add(New LiteralControl(arrLabel(k) & " : "))
                Row.Cells.Add(Cell)
                Cell = New TableCell
                Cell.Style(HtmlTextWriterStyle.Width) = "80%"
                Select Case TipoControl
                    Case "TextBox"
                        txtTextBox = New TextBox
                        txtTextBox.ID = arrControl(k)
                        'txtTextBox.ClientIDMode = ClientIDMode.Static
                        txtTextBox.CssClass = CssClassControl
                        txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        txtTextBox.TextMode = ControlTextMode
                        If ControlTextMode = 1 Then
                            txtTextBox.Height = "50"
                        End If
                        txtTextBox.ToolTip = ToolTip
                        If IsNotEnabledField Then
                            txtTextBox.Enabled = False
                        End If
                        Cell.Controls.Add(txtTextBox)
                    Case "CheckBox"
                        txtCheckBox = New CheckBox
                        txtCheckBox.ID = arrNodesControl(m)
                        txtCheckBox.ToolTip = ToolTip
                        Cell.Controls.Add(txtCheckBox)
                    Case "TextBoxAutoComplete"
                        txtTextBox = New TextBox
                        txtTextBox.ID = arrControl(k)
                        'txtTextBox.ClientIDMode = ClientIDMode.Static
                        txtTextBox.CssClass = CssClassControl
                        txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        txtTextBox.TextMode = ControlTextMode
                        If ControlTextMode = 1 Then
                            txtTextBox.Height = "50"
                        End If
                        txtTextBox.ToolTip = ToolTip
                        If IsNotEnabledField Then
                            txtTextBox.Enabled = False
                        End If
                        Cell.Controls.Add(txtTextBox)
                        AutoComp = New AutoCompleteExtender
                        AutoComp.ID = "Autocomplete" & arrControl(k)
                        'AutoComp.ClientIDMode = UI.ClientIDMode.Static
                        AutoComp.CompletionListItemCssClass = CssClassControl
                        AutoComp.TargetControlID = arrControl(k)
                        AutoComp.ServicePath = "AutoComplete.asmx"
                        AutoComp.ServiceMethod = Lecturas.LeerNombreMetodoAutocomplete("Form", NumeroPagina, k + 1)  ' Aqui hay que invocar un metodo para traer el nombre del m�todo
                        AutoComp.MinimumPrefixLength = "2"
                        AutoComp.CompletionInterval = "1000"
                        AutoComp.EnableCaching = "true"
                        AutoComp.CompletionSetCount = "12"
                        Cell.Controls.Add(AutoComp)
                    Case "TextBoxCalendar"
                        txtTextBox = New TextBox
                        txtTextBox.ID = arrControl(k)
                        'txtTextBox.ClientIDMode = ClientIDMode.Static
                        txtTextBox.CssClass = CssClassControl
                        txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        txtTextBox.TextMode = ControlTextMode
                        txtTextBox.ToolTip = ToolTip
                        If IsNotEnabledField Then
                            txtTextBox.Enabled = False
                        End If
                        Cell.Controls.Add(txtTextBox)
                        Cell.Controls.Add(New LiteralControl(" "))
                        ImgImages = New Image
                        ImgImages.ID = "Image" & arrControl(k)
                        'ImgImages.ClientIDMode = UI.ClientIDMode.Static
                        ImgImages.ImageUrl = "img/Calendar_scheduleHS.png"
                        ImgImages.ImageAlign = ImageAlign.Middle
                        Cell.Controls.Add(ImgImages)
                        txtCalendar = New CalendarExtender
                        txtCalendar.ID = "Calendar" & arrControl(k)
                        'txtCalendar.ClientIDMode = UI.ClientIDMode.Static
                        txtCalendar.TargetControlID = arrControl(k)
                        txtCalendar.PopupButtonID = "Image" & arrControl(k)
                        txtCalendar.Format = "dd/MMM/yy"
                        Cell.Controls.Add(txtCalendar)
                    Case "DropDownList"
                        txtDropDownList = New DropDownList
                        txtDropDownList.ID = arrControl(k)
                        'txtDropDownList.ClientIDMode = ClientIDMode.Static
                        txtDropDownList.CssClass = CssClassControl
                        txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        txtDropDownList.ToolTip = ToolTip
                        txtDropDownList.DataSourceID = "ds" & arrControl(k)
                        txtDropDownList.DataTextField = DataTextField
                        Cell.Controls.Add(txtDropDownList)


                        sqlSource  = New SqlDataSource()                   
                        sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                        sqlSource.SelectCommand = SelectCommand   

                        sqlSource.ID = "ds" & arrControl(k)
                        'sqlSource.DataFile = DataFile
                        'sqlSource.SelectCommand = SelectCommand
                        Cell.Controls.Add(sqlSource)
                    Case "DropDownSearch"
                        txtCheckBox = New CheckBox
                        txtCheckBox.ID = "chk" & arrControl(k)
                        'txtCheckBox.ClientIDMode = ClientIDMode.Static
                        txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrLabel(k)
                        Cell.Controls.Add(txtCheckBox)
                        Cell.Controls.Add(New LiteralControl(" "))
                        txtDropDownList = New DropDownList
                        txtDropDownList.ID = arrControl(k)
                        'txtDropDownList.ClientIDMode = ClientIDMode.Static
                        txtDropDownList.CssClass = CssClassControl
                        txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        txtDropDownList.ToolTip = ToolTip
                        txtDropDownList.DataSourceID = "ds" & arrControl(k)
                        txtDropDownList.DataTextField = DataTextField
                        Cell.Controls.Add(txtDropDownList)

                        sqlSource  = New SqlDataSource()                    
                        sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                        sqlSource.SelectCommand = SelectCommand

                        sqlSource.ID = "ds" & arrControl(k)
                        'sqlSource.DataFile = DataFile
                        'sqlSource.SelectCommand = SelectCommand
                        Cell.Controls.Add(sqlSource)

                End Select

                Row.Cells.Add(Cell)
                MyTable.Rows.Add(Row)
            Next

            'Linea de Divisi�n
            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Height = "4"
            Cell.ColumnSpan = "2"
            Cell.Controls.Add(New LiteralControl("<hr />"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)

            'Botones del Formulario
            i = 0
            t = Lecturas.LeerButtonFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            Row = New TableRow
            Cell = New TableCell
            Cell.CssClass = CssClassLabel
            Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
            Cell.Style(HtmlTextWriterStyle.Width) = "20%"
            Row.Cells.Add(Cell)
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.Width) = "80%"
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Button", GroupValidation, NumeroPagina, k + 1)
                t = Lecturas.LeerControlButtonFormularioWeb(FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebServiceCall, "Button", NumeroPagina, k + 1)
                Select Case arrControl(k)
                    Case "LoginButton"
                        LoginButton = New Button
                        LoginButton.ID = arrControl(k) & NumeroPagina
                        LoginButton.CssClass = CssClassControl
                        LoginButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        LoginButton.Text = arrLabel(k)
                        ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Group Validations : " & GroupValidation & vbCrLf
                        ControlAtributes = ControlAtributes & "ToolTip : " & ToolTip & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Button" & vbCrLf
                        ControlAtributes = ControlAtributes & "Select : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "Evento : " & FormularioWebEvent & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Page : " & FormularioWebPageCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Form : " & FormularioWebFormCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Servicio : " & FormularioWebServiceCall
                        LoginButton.ToolTip = ControlAtributes
                        LoginButton.Enabled = False
                        'AddHandler LoginButton.Click, AddressOf RFC_Login
                        Cell.Controls.Add(LoginButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "CancelButton"
                        CancelButton = New Button
                        CancelButton.ID = arrControl(k) & NumeroPagina
                        CancelButton.CssClass = CssClassControl
                        CancelButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        CancelButton.Text = arrLabel(k)
                        ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Group Validations : " & GroupValidation & vbCrLf
                        ControlAtributes = ControlAtributes & "ToolTip : " & ToolTip & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Button" & vbCrLf
                        ControlAtributes = ControlAtributes & "Select : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "Evento : " & FormularioWebEvent & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Page : " & FormularioWebPageCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Form : " & FormularioWebFormCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Servicio : " & FormularioWebServiceCall
                        CancelButton.ToolTip = ControlAtributes
                        CancelButton.Enabled = False
                        'AddHandler CancelButton.Click, AddressOf RFC_Logout
                        Cell.Controls.Add(CancelButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "UpdateButton"
                        UpdateButton = New Button
                        UpdateButton.ID = arrControl(k) & NumeroPagina
                        UpdateButton.CssClass = CssClassControl
                        UpdateButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        UpdateButton.Text = arrLabel(k)
                        ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Group Validations : " & GroupValidation & vbCrLf
                        ControlAtributes = ControlAtributes & "ToolTip : " & ToolTip & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Button" & vbCrLf
                        ControlAtributes = ControlAtributes & "Select : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "Evento : " & FormularioWebEvent & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Page : " & FormularioWebPageCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Form : " & FormularioWebFormCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Servicio : " & FormularioWebServiceCall
                        UpdateButton.ToolTip = ControlAtributes
                        UpdateButton.Enabled = False
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(UpdateButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "NewButton"
                        NewButton = New Button
                        NewButton.ID = arrControl(k) & NumeroPagina
                        NewButton.CssClass = CssClassControl
                        NewButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        NewButton.Text = arrLabel(k)
                        ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Group Validations : " & GroupValidation & vbCrLf
                        ControlAtributes = ControlAtributes & "ToolTip : " & ToolTip & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Button" & vbCrLf
                        ControlAtributes = ControlAtributes & "Select : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "Evento : " & FormularioWebEvent & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Page : " & FormularioWebPageCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Form : " & FormularioWebFormCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Servicio : " & FormularioWebServiceCall
                        NewButton.ToolTip = ControlAtributes
                        NewButton.Enabled = False
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(NewButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "SearchButton"
                        SearchButton = New Button
                        SearchButton.ID = arrControl(k) & NumeroPagina
                        SearchButton.CssClass = CssClassControl
                        SearchButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        SearchButton.Text = arrLabel(k)
                        ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Group Validations : " & GroupValidation & vbCrLf
                        ControlAtributes = ControlAtributes & "ToolTip : " & ToolTip & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Button" & vbCrLf
                        ControlAtributes = ControlAtributes & "Select : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "Evento : " & FormularioWebEvent & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Page : " & FormularioWebPageCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Form : " & FormularioWebFormCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Servicio : " & FormularioWebServiceCall
                        SearchButton.ToolTip = ControlAtributes
                        SearchButton.Enabled = False
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(SearchButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "DeleteButton"
                        DeleteButton = New Button
                        DeleteButton.ID = arrControl(k) & NumeroPagina
                        DeleteButton.CssClass = CssClassControl
                        DeleteButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        DeleteButton.Text = arrLabel(k)
                        ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Group Validations : " & GroupValidation & vbCrLf
                        ControlAtributes = ControlAtributes & "ToolTip : " & ToolTip & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Button" & vbCrLf
                        ControlAtributes = ControlAtributes & "Select : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "Evento : " & FormularioWebEvent & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Page : " & FormularioWebPageCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Form : " & FormularioWebFormCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Servicio : " & FormularioWebServiceCall
                        DeleteButton.ToolTip = ControlAtributes
                        DeleteButton.Enabled = False
                        'AddHandler DeleteButton.Click, AddressOf RFC_Delete
                        Cell.Controls.Add(DeleteButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "ReturnButton"
                        ReturnButton = New Button
                        ReturnButton.ID = arrControl(k) & NumeroPagina
                        ReturnButton.CssClass = CssClassControl
                        ReturnButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        ReturnButton.Text = arrLabel(k)
                        ControlAtributes = "Etiqueta: " & arrLabel(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Field: " & arrControl(k) & vbCrLf
                        ControlAtributes = ControlAtributes & "Width: " & ControlWidth & vbCrLf
                        ControlAtributes = ControlAtributes & "Type: " & TipoControl & vbCrLf
                        ControlAtributes = ControlAtributes & "Group Validations : " & GroupValidation & vbCrLf
                        ControlAtributes = ControlAtributes & "ToolTip : " & ToolTip & vbCrLf
                        ControlAtributes = ControlAtributes & "Secci�n : " & "Button" & vbCrLf
                        ControlAtributes = ControlAtributes & "Select : " & SelectCommand & vbCrLf
                        ControlAtributes = ControlAtributes & "Evento : " & FormularioWebEvent & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Page : " & FormularioWebPageCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Next Form : " & FormularioWebFormCall & vbCrLf
                        ControlAtributes = ControlAtributes & "Servicio : " & FormularioWebServiceCall
                        ReturnButton.ToolTip = ControlAtributes
                        ReturnButton.Enabled = False
                        'AddHandler ReturnButton.Click, AddressOf RFC_Return
                        Cell.Controls.Add(ReturnButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                End Select
            Next


            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
            MyView.Controls.Add(MyTable)


        End If

        MyView.Controls.Add(New LiteralControl("</div>"))

        MyView.Controls.Add(New LiteralControl("<div id=""sub2sub"" class=""invisible"">"))
        MyTable = New Table
        MyTable.ID = "Controles" & NumeroPagina
        MyTable.Width = "700"
        MyTable.CellSpacing = "2"
        MyTable.CellPadding = "2"
        MyTable.CssClass = "visible"
        'Linea de Divisi�n
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.Height = "4"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("<hr />"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        'Titulo
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "subtit"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("Lista de Controles de la P�gina"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        'Linea de Divisi�n
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.Height = "4"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("<hr />"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        MyView.Controls.Add(MyTable)
        MyView.Controls.Add(New LiteralControl("</div>"))

        MyView.Controls.Add(New LiteralControl("<div id=""sub3sub"" class=""invisible"">"))
        MyTable = New Table
        MyTable.ID = "Requerimientos" & NumeroPagina
        MyTable.Width = "700"
        MyTable.CellSpacing = "2"
        MyTable.CellPadding = "2"
        MyTable.CssClass = "visible"
        'Linea de Divisi�n
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.Height = "4"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("<hr />"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        'Titulo
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "subtit"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("Lista de Requerimientos de la P�gina"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        'Linea de Divisi�n
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.Height = "4"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("<hr />"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        MyView.Controls.Add(MyTable)
        MyView.Controls.Add(New LiteralControl("</div>"))

    End Sub
    Public Function LeerMenuOptionsClassParaAutocomplete(ByRef ArrChartData() As String, ByVal Filtro As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT distinct MenuOptions.[Class] AS GrupoOpciones "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.Class) LIKE ('%" & Filtro & "%')))"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("GrupoOpciones").ToString
                i = i + 1
            End While
            LeerMenuOptionsClassParaAutocomplete = True
            dtr.Close()
        Catch
            LeerMenuOptionsClassParaAutocomplete = False
        End Try
    End Function
    Public Function LeerMenuOptionsTextoParaAutocomplete(ByRef ArrChartData() As String, ByVal Filtro As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT distinct MenuOptions.[Texto] AS Texto "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.Texto) LIKE ('%" & Filtro & "%')))"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("Texto").ToString
                i = i + 1
            End While
            LeerMenuOptionsTextoParaAutocomplete = True
            dtr.Close()
        Catch
            LeerMenuOptionsTextoParaAutocomplete = False
        End Try
    End Function
    Public Function LeerMenuOptionsLogoParaAutocomplete(ByRef ArrChartData() As String, ByVal Filtro As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT distinct MenuOptions.[Logo] AS GrupoOpciones "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.Logo) LIKE ('%" & Filtro & "%')))"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("GrupoOpciones").ToString
                i = i + 1
            End While
            LeerMenuOptionsLogoParaAutocomplete = True
            dtr.Close()
        Catch
            LeerMenuOptionsLogoParaAutocomplete = False
        End Try
    End Function
    Public Function LeerMenuOptionsBarMenuParaAutocomplete(ByRef ArrChartData() As String, ByVal Filtro As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT distinct MenuOptions.[BarMenu] AS GrupoOpciones "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.BarMenu) LIKE ('%" & Filtro & "%')))"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("GrupoOpciones").ToString
                i = i + 1
            End While
            LeerMenuOptionsBarMenuParaAutocomplete = True
            dtr.Close()
        Catch
            LeerMenuOptionsBarMenuParaAutocomplete = False
        End Try
    End Function
    Public Function LeerMenuOptionsSideBarMenuParaAutocomplete(ByRef ArrChartData() As String, ByVal Filtro As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT distinct MenuOptions.[SideBarMenu] AS GrupoOpciones "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.SideBarMenu) LIKE ('%" & Filtro & "%')))"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("GrupoOpciones").ToString
                i = i + 1
            End While
            LeerMenuOptionsSideBarMenuParaAutocomplete = True
            dtr.Close()
        Catch
            LeerMenuOptionsSideBarMenuParaAutocomplete = False
        End Try
    End Function
    Public Sub CreateTabs(ByVal NumeroPagina As Long, ByVal MasterName As String, ByVal MasterId As Long, ByRef MyTable As Table, ByVal FilterField As String, ByVal sSQLWhere As String, ByVal sSQLOrder As String, ByVal PaginaWebName As String, ByVal MenuOptionsId As Long, Optional ByVal PivotId As Long = 0, Optional ByVal PivotTable As String = "", Optional ByVal UserId As Long = 0, Optional ByVal Agno As String = "", Optional ByVal Gerencia As String = "", Optional ByVal StakeholderCode As String = "")
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim m As Integer = 0
        Dim n As Integer = 0
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim arrLabel(21) As String
        Dim arrControl(21) As String
        Dim arrGrillaLabel(21) As String
        Dim arrGrillaControl(21) As String
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
        Dim Url As String = ""
        Dim FormularioWebPId As Long = 0
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim sqlSource As SqlDataSource
        Dim Tareas As New Tareas
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim IndicadorEsManual As Boolean = False

        Dim TC As TabContainer
        Dim TP As TabPanel
        Dim Tabla As Table
        Dim Fila As TableRow
        Dim Celda As TableCell
        Dim PanelScroll As Panel

        Dim Grilla As GridView
        Dim sSQL As String = ""
        Dim HTMLCode As String = ""
        Dim HyperColumnGrid As HyperLinkField
        Dim ItemTempColumnGrid As TemplateField

        'Se agregan para hacer el cambio en el despliegue de las relaciones de asociacion
        Dim RelationTable As String
        Dim sSQLRelationSelect As String = ""


        Dim GroupValidation As String = ""

        i = 0
        t = Lecturas.LeerTabsFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        If i > 0 Then  'P�gina posee tabs
            'Linea de Divisi�n
            ' Aqu� vamos a verificar si la evidencia de ejecuci�n de una tarea, requiere o no
            ' el ingreso de un indicador, de no ser as�, no se muestra el tab.

            'Se elimina esta l�nea el 25-09-2011
            'Row = New TableRow
            'Cell = New TableCell
            'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            'Cell.Height = "4"
            'Cell.ColumnSpan = "2"
            'Cell.Controls.Add(New LiteralControl("<hr />"))
            'Row.Cells.Add(Cell)
            'MyTable.Rows.Add(Row)

            Row = New TableRow
            Cell = New TableCell
            Cell.ColumnSpan = "2"

            'Crea el Tab Container
            TC = New TabContainer
            TC.ID = "DynamicTab" & NumeroPagina & i
            TC.ClientIDMode = UI.ClientIDMode.Static
            TC.Height = "400"
            TC.OnClientActiveTabChanged = "ActiveTabChanged"
            ' Primer Tab Panel: Con k corren los paneles                                  

            'Aqu� comienza el If si me quiero saltar un tab.

            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Tabs", GroupValidation, NumeroPagina, k + 1)
                t = Lecturas.LeerIdFormularioWeb(FormularioWebPId, "Tabs", NumeroPagina, k + 1, Pagina, NombrePagina)

                TP = New TabPanel
                TP.ID = "TabPanel" & arrControl(k)
                TP.ClientIDMode = UI.ClientIDMode.Static
                TP.HeaderText = arrLabel(k)
                TP.CssClass = "tab_contenido"
                'Agrega el contenedor
                TP.Controls.Add(New LiteralControl("<contenttemplate>"))

                Tabla = New Table
                Tabla.ID = "Tabla" & arrControl(k)
                Tabla.ClientIDMode = UI.ClientIDMode.Static
                Tabla.CellSpacing = "2"
                Tabla.CellPadding = "2"

                'Titulo
                Fila = New TableRow
                Celda = New TableCell
                'Celda.CssClass = "subtit"
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "left"
                Celda.ColumnSpan = "2"
                Celda.Controls.Add(New LiteralControl("<h1>Lista de " & arrLabel(k) & "</h1>"))
                Fila.Cells.Add(Celda)
                Tabla.Rows.Add(Fila)

                'Linea de Divisi�n
                'Fila = New TableRow
                'Celda = New TableCell
                'Celda.Style(HtmlTextWriterStyle.TextAlign) = "left"
                'Celda.Height = "4"
                'Celda.ColumnSpan = "2"
                'Celda.Controls.Add(New LiteralControl("<hr />"))
                'Fila.Cells.Add(Celda)
                'Tabla.Rows.Add(Fila)

                'Descripci�n
                'Fila = New TableRow
                'Celda = New TableCell
                'Celda.CssClass = "tab_contenido"
                'Celda.Style(HtmlTextWriterStyle.TextAlign) = "left"
                'Celda.ColumnSpan = "2"
                'Celda.Controls.Add(New LiteralControl(ToolTip))
                'Fila.Cells.Add(Celda)
                'Tabla.Rows.Add(Fila)

                'Linea de Divisi�n
                'Fila = New TableRow
                'Celda = New TableCell
                'Celda.Style(HtmlTextWriterStyle.TextAlign) = "left"
                'Celda.Height = "4"
                'Celda.ColumnSpan = "2"
                'Celda.Controls.Add(New LiteralControl("<hr />"))
                'Fila.Cells.Add(Celda)
                'Tabla.Rows.Add(Fila)

                'Linea para incorporar el link para agregar un elemento a la lista.
                'Dim linkAgregar As String = Pagina & "?PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & MasterName & "&MasterId=" & MasterId

                'Cambio del 08 de Abril de 2011
                'Se comienza a usar el campo IsNotEnabledField, para determinar si se pone o no este link
                'El valo Yes implica que no se pone.
                'Este campo esta en el registro que corresponder a los tabs de la clase.

                If IsNotEnabledField = False Then
                    IndicadorEsManual = True
                    If PaginaWebName = "Ficha de Tareas" Then
                        If NombrePagina = "Ficha de TareasKPI" Then
                            IndicadorEsManual = Tareas.IndicadorIsManual(MasterId)
                        End If
                    End If

                    Dim linkAgregar As String = Pagina & "?PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & MenuOptionsId & "&MasterName=" & MasterName & "&MasterId=" & MasterId

                    If PaginaWebName = "Ficha de Portales" Then
                        Select Case arrControl(k)
                            Case "tabLogo"
                                linkAgregar = linkAgregar & "&Zona=Logo&MenuOptionsPID=0&OptionsType=Sitio Privado&IsNodoHoja=MenuHoja&SystemId=" & MasterId
                            Case "tabBarMenu"
                                linkAgregar = linkAgregar & "&Zona=BarMenu&MenuOptionsPID=0&OptionsType=Sitio Privado&IsNodoHoja=MenuHoja&SystemId=" & MasterId
                            Case "tabSideBarMenu"

                        End Select
                    End If
                    If IndicadorEsManual = True Then
                        Url = "<a href='" & linkAgregar & "'>Agregar " & arrLabel(k) & "</a>"
                        If DomainField = "RelationBetweenTables" Then
                            Url = "<a href='" & linkAgregar & "'>Editar " & arrLabel(k) & "</a>"
                        End If
                    Else
                        Url = "<span class=""subtit"">Esta tarea no requiere ingresar un indicador de gesti�n</span>"
                    End If

                    Fila = New TableRow
                    Celda = New TableCell
                    Celda.Style(HtmlTextWriterStyle.TextAlign) = "left"
                    Celda.Height = "4"
                    Celda.ColumnSpan = "2"
                    Celda.Controls.Add(New LiteralControl(Url))
                    Fila.Cells.Add(Celda)
                    Tabla.Rows.Add(Fila)
                End If

                Fila = New TableRow
                Celda = New TableCell
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "left"
                Celda.Height = "4"
                Celda.ColumnSpan = "2"

                'Aqu� vamos a poner la grilla de datos asociada a cada tabs

                'Columnas del Formulario
                n = 0
                t = Lecturas.LeerTabsColumnsFormularioWeb(arrGrillaLabel, arrGrillaControl, FormularioWebPId, n)

                PanelScroll = New Panel
                PanelScroll.ID = "panel" & arrLabel(k)
                PanelScroll.ClientIDMode = UI.ClientIDMode.Static
                PanelScroll.ScrollBars = ScrollBars.Auto
                PanelScroll.Height = "300"


                Grilla = New GridView
                'Grilla.ID = "grid" & arrLabel(k)
                Grilla.ID = "tabla_de_datos"
                Grilla.ClientIDMode = ClientIDMode.Static
                Grilla.DataSourceID = "ds" & arrLabel(k)
                Grilla.DataKeyNames = New String(0) {"Id"}
                'Grilla.HeaderStyle.CssClass = "grilla_top"
                'Grilla.RowStyle.CssClass = "grilla_Fila1"
                Grilla.AlternatingRowStyle.CssClass = "alt"

                Grilla.Width = "660"
                Grilla.AllowPaging = False
                Grilla.AllowSorting = False
                'Grilla.PageSize = 100
                Grilla.AutoGenerateColumns = False

                For m = 0 To n - 1
                    t = Lecturas.LeerTabColumnFormularioWeb(TipoControl, EtiquetaAlign, ControlWidth, ToolTip, SelectCommand, "Grilla", FormularioWebPId, m + 1)
                    Select Case TipoControl
                        Case "HyperLinkField"
                            HyperColumnGrid = New HyperLinkField
                            HyperColumnGrid.DataTextField = arrGrillaControl(m)
                            HyperColumnGrid.ShowHeader = True
                            HyperColumnGrid.HeaderText = arrGrillaLabel(m)
                            HyperColumnGrid.DataNavigateUrlFields = New String(0) {arrGrillaControl(m)}
                            HyperColumnGrid.DataNavigateUrlFormatString = SelectCommand & "&MasterName=" & MasterName & "&MasterId=" & MasterId
                            HyperColumnGrid.Visible = False
                            Grilla.Columns.Add(HyperColumnGrid)
                            ItemTempColumnGrid = New TemplateField
                            ItemTempColumnGrid.ShowHeader = True
                            ItemTempColumnGrid.HeaderText = "Editar"
                            'ItemTempColumnGrid.HeaderImageUrl = "img/botones/i_solicitar.gif"
                            ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                            ' Cambio Introducido el 11 de Abril de 2011
                            ' En caso de que el campo DomainField contenga la glosa RelationBetweenTables, se invocara una plantilla distinta a la habitual
                            If DomainField = "RelationBetweenTables" Then
                                ItemTempColumnGrid.ItemTemplate = New PlantillaRelationsBetweenTables(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)}, DataTextField, PivotTable, DataFile, PivotId, UserId)
                            Else
                                ItemTempColumnGrid.ItemTemplate = New PlantillaImageGrilla(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)}, SelectCommand & "&MasterName=" & MasterName & "&MasterId=" & MasterId, "img/editar.png")
                            End If
                            ItemTempColumnGrid.Visible = True
                            Grilla.Columns.Add(ItemTempColumnGrid)
                        Case "HyperLinkPlanField"
                            HyperColumnGrid = New HyperLinkField
                            HyperColumnGrid.DataTextField = arrGrillaControl(m)
                            HyperColumnGrid.ShowHeader = True
                            HyperColumnGrid.HeaderText = arrGrillaLabel(m)
                            HyperColumnGrid.DataNavigateUrlFields = New String(0) {arrGrillaControl(m)}
                            HyperColumnGrid.DataNavigateUrlFormatString = SelectCommand & "&MasterName=" & MasterName & "&MasterId=" & MasterId
                            HyperColumnGrid.Visible = False
                            Grilla.Columns.Add(HyperColumnGrid)
                            ItemTempColumnGrid = New TemplateField
                            ItemTempColumnGrid.ShowHeader = True
                            ItemTempColumnGrid.HeaderText = "Editar"
                            'ItemTempColumnGrid.HeaderImageUrl = "img/editar.png"
                            ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                            ' Cambio Introducido el 11 de Abril de 2011
                            ' En caso de que el campo DomainField contenga la glosa RelationBetweenTables, se invocara una plantilla distinta a la habitual
                            ItemTempColumnGrid.ItemTemplate = New PlantillaImageGrilla(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)}, SelectCommand & "&MasterName=" & MasterName & "&MasterId=" & MasterId, "img/editar.png")
                            ItemTempColumnGrid.Visible = True
                            Grilla.Columns.Add(ItemTempColumnGrid)
                        Case "TextBoxField"
                            HyperColumnGrid = New HyperLinkField
                            HyperColumnGrid.DataTextField = arrGrillaControl(m)
                            HyperColumnGrid.ShowHeader = True
                            HyperColumnGrid.HeaderText = arrGrillaLabel(m)
                            HyperColumnGrid.DataNavigateUrlFields = New String(0) {arrGrillaControl(m)}
                            HyperColumnGrid.DataNavigateUrlFormatString = SelectCommand & "&MasterName=" & MasterName & "&MasterId=" & MasterId
                            HyperColumnGrid.Visible = False
                            Grilla.Columns.Add(HyperColumnGrid)
                            ItemTempColumnGrid = New TemplateField
                            ItemTempColumnGrid.ShowHeader = True
                            ItemTempColumnGrid.HeaderText = "Editar"
                            'ItemTempColumnGrid.HeaderImageUrl = "img/editar.png"
                            ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                            ' Cambio Introducido el 11 de Abril de 2011
                            ' En caso de que el campo DomainField contenga la glosa RelationBetweenTables, se invocara una plantilla distinta a la habitual
                            If DomainField = "RelationBetweenTables" Then
                                ItemTempColumnGrid.ItemTemplate = New PlantillaTextBoxButton(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)}, DataTextField, PivotTable, DataFile, PivotId, UserId)
                            Else
                                ItemTempColumnGrid.ItemTemplate = New PlantillaImageGrilla(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)}, SelectCommand & "&MasterName=" & MasterName & "&MasterId=" & MasterId, "img/editar.png")
                            End If
                            ItemTempColumnGrid.Visible = True
                            Grilla.Columns.Add(ItemTempColumnGrid)
                        Case "EstadoFieldEstado"  ' Esta columna debe tomar un color de fondo, que puede ser rojo o amarillo o blanco segun si la tarea es de un mes anterior (rojo), si es del mismo mes (amarillo) o si es de un mes posterior al actual (blanco)
                            ItemTempColumnGrid = New TemplateField
                            ItemTempColumnGrid.ShowHeader = True
                            ItemTempColumnGrid.HeaderText = arrGrillaLabel(m)
                            ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                            ItemTempColumnGrid.ItemTemplate = New PlantillaEstadoTareas(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)}, "ColorCeldaDelEstadoDeLaTarea")
                            ItemTempColumnGrid.Visible = True
                            ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                            Grilla.Columns.Add(ItemTempColumnGrid)
                        Case "DownLoadField"
                            HyperColumnGrid = New HyperLinkField
                            HyperColumnGrid.DataTextField = "T�tulo"
                            HyperColumnGrid.ShowHeader = True
                            HyperColumnGrid.HeaderText = arrGrillaLabel(m)
                            HyperColumnGrid.DataNavigateUrlFields = New String(0) {"Url"}
                            HyperColumnGrid.Target = "_blank"
                            'HyperColumnGrid.ItemStyle.Width = ControlWidth
                            HyperColumnGrid.ItemStyle.HorizontalAlign = 1
                            'HyperColumnGrid.DataNavigateUrlFormatString = {0}
                            Grilla.Columns.Add(HyperColumnGrid)

                        Case "TemplateField"
                            ItemTempColumnGrid = New TemplateField
                            ItemTempColumnGrid.ShowHeader = True
                            ItemTempColumnGrid.HeaderText = arrGrillaLabel(m)
                            ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                            ItemTempColumnGrid.ItemTemplate = New PlantillaGrilla(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)})
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

                PanelScroll.Controls.Add(Grilla)
                Celda.Controls.Add(PanelScroll)
                Fila.Cells.Add(Celda)
                Tabla.Rows.Add(Fila)

                Fila = New TableRow
                Celda = New TableCell
                Celda.CssClass = "txt_label"
                Celda.ColumnSpan = "2"
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "right"


                sqlSource  = New SqlDataSource()                   
                sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                sqlSource.SelectCommand = SelectCommand                
                sqlSource.ID = "ds" & arrLabel(k)

                t = Lecturas.LeerTabSQLStatementFormularioWeb("SQLSelect", DataFile, SelectCommand, FormularioWebPId)

                'sqlSource.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\BDCAS.mdb"
                'sqlSource.DataFile = DataFile
                ' Cambio introducido el 08 de abril de 2011
                ' Se verifica que el el campo DomainField no contiene la glosa RelationBetweenTables
                If DomainField = "RelationBetweenTables" Then
                    'Vamos a introducir un cambio para mejorar el desempe�o del despliegue de 
                    'las listas de asociaciones entre la tabla maestra y sus tablas asociados.
                    'Para ello al momento de desplegar s�lo vamos a mostrar los registros asociados
                    'Luego vamos a examinar el mecanismo para hacer nuevas asociaciones.


                    Select Case PaginaWebName
                        Case "Ficha de Acciones"
                            Select Case k
                                Case 1
                                    'sSQL = "SELECT MenuOptions.MenuOptionsId AS Id, Acciones.AmbitosCodigo AS Grupo, MenuOptions.Texto AS Nombre "
                                    'sSQL = sSQL & "FROM (Acciones INNER JOIN Ambitos ON Acciones.AmbitosCodigo = Ambitos.AmbitosCodigo) INNER JOIN MenuOptions ON Ambitos.AmbitosSideBarMenu = MenuOptions.SideBarMenu "
                                    'sSQL = sSQL & "WHERE (((MenuOptions.PaginaWebName)=""Lista Pol�ticas"") AND ((MenuOptions.IsNodoHoja)=""Hoja"") AND ((Acciones.AccionesId)=" & PivotId & ")) "
                                    'sSQL = sSQL & "ORDER BY MenuOptions.Texto"

                                    sSQL = "SELECT Usuarios.[UsuariosId] as Id, Usuarios.[UsuariosCodigo] As Codigo, Usuarios.[UsuariosName] As Nombre "
                                    sSQL = sSQL & "FROM Usuarios"
                                    'Case 1
                                    'sSQL = "SELECT DocumentosSGI.DocumentosSGIId As Id, MenuOptions.Texto as Requisito, DocumentosSGI.DocumentosSGITipo as Tipo, DocumentosSGI.DocumentosSGINombre As T�tulo, 'SGI\' + DocumentosSGI.DocumentosSGIPath as Url  "
                                    'sSQL = sSQL & "FROM ((((Acciones INNER JOIN RequisitosPorAccion ON Acciones.AccionesId = RequisitosPorAccion.AccionesId) INNER JOIN APIDocumentosSGI ON RequisitosPorAccion.MenuOptionsId = APIDocumentosSGI.MenuOptionsID) INNER JOIN DocumentosSGI ON APIDocumentosSGI.DocumentosSGICodigo = DocumentosSGI.DocumentosSGICodigo) INNER JOIN TipoDoc ON DocumentosSGI.DocumentosSGITipo = TipoDoc.TipoDocName) INNER JOIN MenuOptions ON RequisitosPorAccion.MenuOptionsId = MenuOptions.MenuOptionsId "
                                    'sSQL = sSQL & "WHERE(((Acciones.[AccionesId]) = " & PivotId & ")) "
                                    'sSQL = sSQL & "ORDER BY TipoDoc.TipoDocSecuencia, DocumentosSGI.DocumentosSGINombre"
                                Case 0
                                    sSQL = "SELECT DocumentosSGI.DocumentosSGIId AS Id, DocumentosSGI.DocumentosSGICodigo AS C�digo, DocumentosSGI.DocumentosSGINombre AS T�tulo, DocumentosSGI.DocumentosSGIArea AS Emisor, Mid(DocumentosSGI.DocumentosSGIFEmision,1.1) AS Emisi�n, DocumentosSGI.DocumentosSGIFRevision AS Rev, DocumentosSGI.DocumentosSGIOrigen AS C_Externo, 'SGI\'+DocumentosSGI.DocumentosSGIPath AS Url, DocumentosSGI.DocumentosSGITipo As Tipo "
                                    sSQL = sSQL & "FROM DocumentosSGI "
                                    sSQL = sSQL & "WHERE (((DocumentosSGI.DocumentosSGITipo)='Procedimiento')) OR (((DocumentosSGI.DocumentosSGITipo)='Formulario')) "
                                    sSQL = sSQL & "ORDER BY DocumentosSGI.DocumentosSGIId"
                            End Select
                        Case "Ficha de Actividades"
                            sSQL = "SELECT Usuarios.UsuariosId AS Id, Usuarios.UsuariosCodigo AS UserName, Usuarios.UsuariosName AS Nombre, Usuarios.RolName AS Rol "
                            sSQL = sSQL & "FROM ((Actividades INNER JOIN Cargos ON Actividades.CargosCodigo = Cargos.CargosCodigo) INNER JOIN UsuariosPorCargo ON Cargos.CargosId = UsuariosPorCargo.CargosId) INNER JOIN Usuarios ON UsuariosPorCargo.UsuariosId = Usuarios.UsuariosId "
                            sSQL = sSQL & "WHERE(((Actividades.ActividadesId) = " & PivotId & "))"
                        Case "Ficha de Programas"
                            RelationTable = ""
                            Select Case Lecturas.LeerChildTableFormularioWeb(FormularioWebPId, RelationTable)
                                Case "IniciativasEstrategicas"
                                    'Vamos a hacer pruebas con esto'
                                    'sSQL = SelectCommand & " WHERE GerenciasMision.GerenciasMisionYear='" & Agno & "' AND Gerencias.GerenciasCodigo='" & Gerencia & "'"
                                    sSQL = SelectCommand & " Where " & RelationTable & ".ProgramasId = " & PivotId

                                Case "Stakeholders"
                                    'sSQL = SelectCommand
                                    sSQL = SelectCommand & " Where " & RelationTable & ".ProgramasId = " & PivotId & " Order By Stakeholders.StakeholdersCodigo"
                                Case "Comunas"
                                    'sSQL = SelectCommand
                                    sSQL = SelectCommand & " Where " & RelationTable & ".ProgramasId = " & PivotId & " "
                            End Select
                        Case "Ficha de CarpetaJudicialCreditos"
                            RelationTable = ""
                            Select Case Lecturas.LeerChildTableFormularioWeb(FormularioWebPId, RelationTable)
                                Case "CarpetaJudicialAvales"
                                    sSQL = SelectCommand & " Where " & RelationTable & ".CarpetaJudicialCreditosId = " & PivotId
                                Case "CarpetaJudicialHipotecas"
                                    sSQL = SelectCommand & " Where " & RelationTable & ".CarpetaJudicialCreditosId = " & PivotId
                                Case "CarpetaJudicialDocs"
                                    sSQL = SelectCommand & " Where " & RelationTable & ".CarpetaJudicialCreditosId = " & PivotId
                            End Select
                        Case "Ficha de TareasCreditos"
                            RelationTable = ""
                            Select Case Lecturas.LeerChildTableFormularioWeb(FormularioWebPId, RelationTable)
                                Case "CarpetaJudicialAvales"
                                    sSQL = SelectCommand & " Where " & RelationTable & ".CarpetaJudicialCreditosId = " & PivotId
                                Case "CarpetaJudicialHipotecas"
                                    sSQL = SelectCommand & " Where " & RelationTable & ".CarpetaJudicialCreditosId = " & PivotId
                                Case "CarpetaJudicialDocs"
                                    sSQL = SelectCommand & " Where " & RelationTable & ".CarpetaJudicialCreditosId = " & PivotId
                            End Select
                        Case "Ficha de CarpetaJudicialHipotecasPorCarpetaJudicialCreditos", "Ficha de CarpetaJudicialHipotecasPorTareasCreditos", "Ficha de CarpetaJudicialAvalesPorCarpetaJudicialCreditos", "Ficha de CarpetaJudicialAvalesPorTareasCreditos", "Ficha de CarpetaJudicialDocsPorCarpetaJudicialCreditos", "Ficha de CarpetaJudicialDocsPorTareasCreditos"
                            RelationTable = ""
                            sSQL = SelectCommand & " Where " & Lecturas.LeerChildTableFormularioWeb(FormularioWebPId, RelationTable) & ".CarpetaJudicialCodigo = '" & CarpetaJudicial.LeerCarpetaJudicialCodigoByCarpetaJudicialCreditosId(PivotId) & "' "
                        Case "Ficha de Stakeholders"
                            RelationTable = ""
                            Select Case Lecturas.LeerChildTableFormularioWeb(FormularioWebPId, RelationTable)
                                Case "SubGrupos"
                                    'Vamos a hacer pruebas con esto'
                                    'sSQL = SelectCommand & " WHERE GerenciasMision.GerenciasMisionYear='" & Agno & "' AND Gerencias.GerenciasCodigo='" & Gerencia & "'"
                                    sSQL = SelectCommand & " Where " & RelationTable & ".StakeholdersId = " & PivotId & " Order By Grupos.GruposName, SubGrupos.SubGruposName"
                                Case "Programas"
                                    'sSQL = SelectCommand
                                    sSQL = SelectCommand & " Where " & RelationTable & ".StakeholdersId = " & PivotId
                            End Select
                        Case "Ficha de SubGrupos"
                            RelationTable = ""
                            Select Case Lecturas.LeerChildTableFormularioWeb(FormularioWebPId, RelationTable)
                                Case "Stakeholders"
                                    'Vamos a hacer pruebas con esto'
                                    'sSQL = SelectCommand & " WHERE GerenciasMision.GerenciasMisionYear='" & Agno & "' AND Gerencias.GerenciasCodigo='" & Gerencia & "'"
                                    sSQL = SelectCommand & " Where " & RelationTable & ".SubGruposId = " & PivotId & " Order By Stakeholders.StakeholdersName"
                            End Select
                        Case "Ficha de ProgramasAcciones"
                            RelationTable = ""
                            Select Case Lecturas.LeerChildTableFormularioWeb(FormularioWebPId, RelationTable)
                                Case "Acciones"
                                    'Vamos a hacer pruebas con esto'
                                    'sSQL = SelectCommand & " WHERE GerenciasMision.GerenciasMisionYear='" & Agno & "' AND Gerencias.GerenciasCodigo='" & Gerencia & "'"
                                    sSQL = SelectCommand & " Where ProgramasMapa.ProgramasCodigo = '" & MasterName & "' AND ProgramasMapa.StakeholdersCodigo = '" & StakeholderCode & "' "

                                    'WHERE (((ProgramasMapa.ProgramasCodigo)='Programa Voluntariado 2011') AND ((ProgramasMapa.StakeholdersCodigo)='Claudia Alarc�n'));

                            End Select
                        Case "Ficha de ProgramasMapa"
                            RelationTable = ""
                            Select Case Lecturas.LeerChildTableFormularioWeb(FormularioWebPId, RelationTable)
                                Case "Acciones"
                                    'Vamos a hacer pruebas con esto'
                                    'sSQL = SelectCommand & " WHERE GerenciasMision.GerenciasMisionYear='" & Agno & "' AND Gerencias.GerenciasCodigo='" & Gerencia & "'"
                                    sSQL = SelectCommand & " Where ProgramasMapa.ProgramasCodigo = '" & MasterName & "' AND ProgramasMapa.StakeholdersCodigo = '" & StakeholderCode & "' "

                                    'WHERE (((ProgramasMapa.ProgramasCodigo)='Programa Voluntariado 2011') AND ((ProgramasMapa.StakeholdersCodigo)='Claudia Alarc�n'));

                                Case "SubGruposPriorizacion"
                                    sSQL = SelectCommand
                            End Select
                        Case "Ficha de Carpetas"
                            RelationTable = ""
                            Select Case Lecturas.LeerChildTableFormularioWeb(FormularioWebPId, RelationTable)
                                Case "DocumentosSGI"
                                    'Vamos a hacer pruebas con esto'
                                    'sSQL = SelectCommand & " WHERE GerenciasMision.GerenciasMisionYear='" & Agno & "' AND Gerencias.GerenciasCodigo='" & Gerencia & "'"
                                    sSQL = SelectCommand & " Where DocumentosSGIPorCarpeta.CarpetasId = " & PivotId
                            End Select
                        Case "Ficha de DocumentosSGIPorCarpeta"
                            If MenuOptionsId = 503 Then
                                sSQL = "SELECT DocumentosSGI.DocumentosSGIId as Id, Mid(DocumentosSGI.DocumentosSGIFEmision,1,10)  As Fecha, DocumentosSGI.DocumentosSGICodigo as Codigo, DocumentosSGI.DocumentosSGINombre As Nombre FROM DocumentosSGI Where DocumentosSGI.DocumentosSGITipo <> 'Compliance' Order By DocumentosSGINombre"
                            Else
                                sSQL = "SELECT DocumentosSGI.DocumentosSGIId as Id, Mid(DocumentosSGI.DocumentosSGIFEmision,1,10)  As Fecha, DocumentosSGI.DocumentosSGICodigo as Codigo, DocumentosSGI.DocumentosSGINombre As Nombre FROM DocumentosSGI Where DocumentosSGI.DocumentosSGITipo = 'Compliance' Order By DocumentosSGINombre"
                            End If
                        Case Else
                            sSQL = SelectCommand
                    End Select

                Else
                    If PaginaWebName = "Ficha de DocumentosSGI" Or PaginaWebName = "Ficha de Contrato" Or PaginaWebName = "Ficha de Proyectos" Or PaginaWebName = "Ficha de Acciones" Or PaginaWebName = "Ficha de Tareas" Or PaginaWebName = "Ficha de Empresas" Or PaginaWebName = "Ficha de Gerencias" Or PaginaWebName = "Ficha de DimensionesEstrategicas" Or PaginaWebName = "Ficha de Programas" Or PaginaWebName = "Ficha de Grupos" Or PaginaWebName = "Ficha de Stakeholders" Or PaginaWebName = "Ficha de GruposPriorizacion" Or PaginaWebName = "Ficha de ProgramasMapa" Or PaginaWebName = "Ficha de Comunas" Or PaginaWebName = "Ficha de PlanPorAccion" Or PaginaWebName = "Ficha de Carpetas" Or PaginaWebName = "Ficha de TareasProgramadas" Or PaginaWebName = "Ficha de CarpetaJudicial" Then
                        If (arrLabel(k) = "Bitacora" Or arrLabel(k) = "Mensajes") Then
                            If arrLabel(k) = "Bitacora" Then sSQL = SelectCommand & " where " & FilterField & " = '" & MasterName & "' Order by TareasLog.TareasLogId DESC"
                            If arrLabel(k) = "Mensajes" Then sSQL = SelectCommand & " where " & FilterField & " = '" & MasterName & "' Order by TareasNotas.TareasNotasId"
                        Else
                            If PaginaWebName = "Ficha de PlanPorAccion" Or PaginaWebName = "Ficha de Carpetas" Then
                                sSQL = SelectCommand & " where " & FilterField & " = " & MasterId
                            Else
                                sSQL = SelectCommand & " where " & FilterField & " = '" & MasterName & "'"
                            End If

                            If PaginaWebName = "Ficha de CarpetaJudicial" And k = 0 Then

                                sSQL = SelectCommand & " WHERE (((Tareas.PGGCodigo)='" & MasterName & "')) ORDER BY Tareas.DateLastUpdate DESC"

                            End If

                            'Probando

                            If PaginaWebName = "Ficha de Tareas" And k = 0 Then

                                sSQL = SelectCommand & " WHERE (((CarpetaJudicialDocs.CarpetaJudicialCodigo)='" & CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(MasterId)) & "'))"

                            End If

                            If PaginaWebName = "Ficha de Tareas" And k = 1 Then

                                sSQL = SelectCommand & " WHERE (((TareasLog.TareasCodigo)='" & MasterName & "')) ORDER BY TareasLog.TareasLogTime DESC"

                            End If

                            If PaginaWebName = "Ficha de Tareas" And k = 6 Then

                                sSQL = SelectCommand & " WHERE (((Tareas.PGGCodigo)='" & Tareas.LeerTareasPGGCodigo(MasterName) & "')) ORDER BY Tareas.DateLastUpdate DESC"

                            End If

                            If PaginaWebName = "Ficha de Tareas" And k = 2 Then

                                sSQL = SelectCommand & " WHERE (((CarpetaJudicialHipotecas.CarpetaJudicialCodigo)='" & CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(MasterId)) & "'))"

                            End If

                            If PaginaWebName = "Ficha de Tareas" And k = 7 Then

                                sSQL = SelectCommand & " WHERE (((Tareas.PGGCodigo)='" & Tareas.LeerTareasPGGCodigo(MasterName) & "')) ORDER BY Tareas.DateLastUpdate DESC"

                            End If

                            If PaginaWebName = "Ficha de Tareas" And k = 8 Then

                                sSQL = SelectCommand & " WHERE (((Tareas.PGGCodigo)='" & Tareas.LeerTareasPGGCodigo(MasterName) & "')) ORDER BY Tareas.DateLastUpdate DESC"

                            End If

                            If PaginaWebName = "Ficha de Tareas" And k = 3 Then

                                sSQL = SelectCommand & " WHERE (((CarpetaJudicialAvales.CarpetaJudicialCodigo)='" & CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(MasterId)) & "'))"

                            End If

                            If PaginaWebName = "Ficha de Tareas" And k = 4 Then

                                sSQL = SelectCommand & " WHERE (((CarpetaJudicialDirecciones.CarpetaJudicialCodigo)='" & CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(MasterId)) & "'))"

                            End If

                            If PaginaWebName = "Ficha de Tareas" And k = 5 Then

                                sSQL = SelectCommand & " WHERE (((CarpetaJudicialCreditos.CarpetaJudicialCodigo)='" & CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(MasterId)) & "'))"

                            End If

                        End If
                    Else
                        If PaginaWebName = "Ficha de Portales" Then
                            sSQL = SelectCommand & " " & FilterField & " = " & MasterId
                        Else
                            sSQL = SelectCommand & " " & FilterField & " = '" & MasterName & "'"
                        End If

                    End If
                End If


                If Len(sSQLWhere) > 0 Then
                    sSQL = sSQL & sSQLWhere
                End If
                sqlSource.SelectCommand = sSQL
                If Len(sSQLOrder) > 0 Then
                    sSQL = sSQL & sSQLOrder
                End If
                sqlSource.SelectCommand = sSQL

                Celda.Controls.Add(sqlSource)
                Fila.Cells.Add(Celda)

                Tabla.Rows.Add(Fila)



                TP.Controls.Add(Tabla)
                TP.Controls.Add(New LiteralControl("</contenttemplate>"))
                TC.Controls.Add(TP)
            Next

            'Aqu� termina el End If si me quiero saltar un tab


            Cell.Controls.Add(TC)
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
        End If



    End Sub

    Public Function LoadDocumentos(ByRef rptDocumentos As Repeater, ByVal OpcionMenu As String) As Boolean
        Dim AccesoEA = New AccesoEA
        'Dim dtrFunciones As SqlDataReader
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT DocumentosCodigo As Codigo, DocumentosNombre As Nombre, DocumentosPath As URL "
        sSQL = sSQL & "FROM Documentos "
        sSQL = sSQL & "WHERE DocumentosMenu = '" & OpcionMenu & "'"
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptDocumentos.DataSource = dtrFunciones
            rptDocumentos.DataBind()
            LoadDocumentos = True
            dtrFunciones.Close()
        Catch
            LoadDocumentos = False
        End Try
    End Function
    Public Function LoadRaicesDelMenuAccordionSGI(ByRef MyTable As PlaceHolder, ByVal Clasificacion As String, ByVal NodoId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim Tabla As Table
        Dim Fila As TableRow
        Dim Celda As TableCell
        Dim MenuOption As String = ""
        Dim t As Boolean
        Dim Espacios As String = ""


        sSQL = "SELECT MenuOptionsId, texto "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE Class = '" & Clasificacion & "' "
        sSQL = sSQL & "ORDER by Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read
                Tabla = New Table
                Tabla.ID = "TablaHeader" & dtrFunciones("MenuOptionsId")
                Tabla.ClientIDMode = UI.ClientIDMode.Static
                Tabla.CellSpacing = "0"
                Tabla.CellPadding = "0"
                Tabla.Width = "250"
                Fila = New TableRow
                Celda = New TableCell
                Celda.Style(HtmlTextWriterStyle.Height) = "29"
                Celda.Style(HtmlTextWriterStyle.Width) = "8px"
                Celda.BackColor = Drawing.Color.SaddleBrown
                'Celda.BackColor = RGB(178, 108, 74)
                Celda.ForeColor = Drawing.Color.White
                'Celda.Controls.Add(New LiteralControl("<img src='IMG/Menu_top_1.gif' width='7' height='29'/>"))
                Fila.Cells.Add(Celda)
                Celda = New TableCell
                'Celda.CssClass = "c_menu_center"
                Celda.BackColor = Drawing.Color.SaddleBrown
                Celda.ForeColor = Drawing.Color.White
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "center"
                Celda.Controls.Add(New LiteralControl(dtrFunciones("texto").ToString))
                Fila.Cells.Add(Celda)
                Celda = New TableCell
                Celda.Style(HtmlTextWriterStyle.Height) = "29"
                Celda.Style(HtmlTextWriterStyle.Width) = "12px"
                Celda.BackColor = Drawing.Color.SaddleBrown
                Celda.ForeColor = Drawing.Color.White
                'Celda.Controls.Add(New LiteralControl("<img src='IMG/Menu_r8_c10.gif' width='7' height='29'/>"))
                Fila.Cells.Add(Celda)
                Tabla.Rows.Add(Fila)
                MyTable.Controls.Add(Tabla)

                Tabla = New Table
                Tabla.ID = "TablaDetail" & dtrFunciones("MenuOptionsId")
                Tabla.ClientIDMode = UI.ClientIDMode.Static
                Tabla.CellSpacing = "0"
                Tabla.CellPadding = "0"
                Tabla.Width = "250"
                Tabla.BorderColor = Drawing.Color.SaddleBrown
                Tabla.BorderWidth = "1"

                t = LoadOpcionesDelMenuAccordionSGI(Tabla, CLng(dtrFunciones("MenuOptionsId").ToString), NodoId)

                MyTable.Controls.Add(Tabla)

            End While
            LoadRaicesDelMenuAccordionSGI = True
            dtrFunciones.Close()
        Catch
            LoadRaicesDelMenuAccordionSGI = False
        End Try

    End Function
    Public Function LoadRaicesDelMenuAccordionSGIPN(ByRef MyTable As PlaceHolder, ByVal Clasificacion As String, ByVal NodoId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim Tabla As Table
        Dim Fila As TableRow
        Dim Celda As TableCell
        Dim MenuOption As String = ""
        Dim t As Boolean
        Dim Espacios As String = ""


        sSQL = "SELECT MenuOptionsId, texto "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE Class = '" & Clasificacion & "' "
        sSQL = sSQL & "ORDER by Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read
                Tabla = New Table
                Tabla.ID = "TablaHeader" & dtrFunciones("MenuOptionsId")
                Tabla.ClientIDMode = UI.ClientIDMode.Static
                Tabla.CellSpacing = "0"
                Tabla.CellPadding = "0"
                Tabla.Width = "250"
                Fila = New TableRow
                Celda = New TableCell
                Celda.Style(HtmlTextWriterStyle.Height) = "29"
                Celda.Style(HtmlTextWriterStyle.Width) = "8px"
                Celda.CssClass = "menupn"
                'Celda.BackColor = Drawing.Color.SaddleBrown
                'Celda.ForeColor = Drawing.Color.White
                'Celda.Controls.Add(New LiteralControl("<img src='IMG/Menu_top_1.gif' width='7' height='29'/>"))
                Fila.Cells.Add(Celda)
                Celda = New TableCell
                Celda.CssClass = "menupn"
                'Celda.BackColor = Drawing.Color.SaddleBrown
                'Celda.ForeColor = Drawing.Color.White
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "center"
                Celda.Controls.Add(New LiteralControl(dtrFunciones("texto").ToString))
                Fila.Cells.Add(Celda)
                Celda = New TableCell
                Celda.CssClass = "menupn"
                Celda.Style(HtmlTextWriterStyle.Height) = "29"
                Celda.Style(HtmlTextWriterStyle.Width) = "12px"
                'Celda.BackColor = Drawing.Color.SaddleBrown
                'Celda.ForeColor = Drawing.Color.White
                'Celda.Controls.Add(New LiteralControl("<img src='IMG/Menu_r8_c10.gif' width='7' height='29'/>"))
                Fila.Cells.Add(Celda)
                Tabla.Rows.Add(Fila)
                MyTable.Controls.Add(Tabla)

                Tabla = New Table
                Tabla.ID = "TablaDetail" & dtrFunciones("MenuOptionsId")
                Tabla.ClientIDMode = UI.ClientIDMode.Static
                Tabla.CellSpacing = "0"
                Tabla.CellPadding = "0"
                Tabla.Width = "250"
                Tabla.CssClass = "tablamenupn"
                'Tabla.BorderColor = Drawing.Color.SaddleBrown
                'Tabla.BorderWidth = "1"

                t = LoadOpcionesDelMenuAccordionSGI(Tabla, CLng(dtrFunciones("MenuOptionsId").ToString), NodoId)

                MyTable.Controls.Add(Tabla)

            End While
            LoadRaicesDelMenuAccordionSGIPN = True
            dtrFunciones.Close()
        Catch
            LoadRaicesDelMenuAccordionSGIPN = False
        End Try

    End Function
    Public Function LoadRaicesDeBarraSubMenu(ByRef MyTable As PlaceHolder, ByVal Clasificacion As String, ByVal NodoId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim MenuOption As String = ""
        Dim t As Boolean
        Dim Espacios As String = ""
        Dim BarraSubMenu As String = "<table width=""1000"" border=""0"" cellpadding=""0"" cellspacing=""0"" id=""submenu"">"

        'Aqu� s�lo creo la tabla y le traspaso el MenuOptionsId a la siguiente rutina.
        'La siguiente rutina lee las columnas de la barra de sub menu y por cada registro
        'crea una columna, pone el t�tulo y luego invoca la tercera rutina que agrega a dicha 
        'columna los link a las aplicaciones.


        'De esta instrucci�n nos interesa rescatar s�lo el MenuOptionsId que vamos a usar como 
        'ParentId para rescatar los nodos del sub menu.

        sSQL = "SELECT MenuOptionsId, texto "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE Class = '" & Clasificacion & "' "
        sSQL = sSQL & "ORDER by Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read

                t = LoadNodosBarraDeSubMenu(BarraSubMenu, CLng(dtrFunciones("MenuOptionsId").ToString), NodoId)
                BarraSubMenu = BarraSubMenu & "</table>"
                MyTable.Controls.Add(New LiteralControl(BarraSubMenu))

            End While
            LoadRaicesDeBarraSubMenu = True
            dtrFunciones.Close()
        Catch
            LoadRaicesDeBarraSubMenu = False
        End Try

    End Function
    Public Function LoadNodosBarraDeSubMenu(ByRef BarraSubMenu As String, ByVal MenuOptionsPId As Long, ByVal NodoId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim MenuOption As String = ""
        Dim t As Boolean
        Dim Espacios As String = ""
        Dim FilaEncabezado As String = "<tr>"
        Dim FilaOpciones As String = "<tr>"
        Dim i As Integer = 0

        'Se llena la primera fila, con sus respectivas columnas de t�tulo

        'Se leen los encabezados y por cada uno se va llenando la Fila de Encabezado y 
        'se invoca la siguiente rutina para llenar las opciones del meni.


        sSQL = "SELECT MenuOptionsId, Class, href, title, texto, IsNodoHoja "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = " & MenuOptionsPId & " "
        sSQL = sSQL & "ORDER by Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)


            While dtrFunciones.Read
                i = i + 1
                FilaEncabezado = FilaEncabezado & "<th scope=""col"">" & dtrFunciones("texto").ToString & "</th>"
                t = LoadOpcionesBarraSubMenu(FilaOpciones, CLng(dtrFunciones("MenuOptionsId").ToString), Espacios, NodoId)
            End While
            LoadNodosBarraDeSubMenu = True
            dtrFunciones.Close()
        Catch
            LoadNodosBarraDeSubMenu = False
        End Try
        FilaEncabezado = FilaEncabezado & "</tr>"
        FilaOpciones = FilaOpciones & "</tr>"
        BarraSubMenu = BarraSubMenu & FilaEncabezado & FilaOpciones


    End Function
    Public Function LoadOpcionesBarraSubMenu(ByRef FilaOpciones As String, ByVal MenuOptionsId As Long, ByRef Espacios As String, ByVal NodoId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim MenuOption As String = ""

        'Se leen las opciones del men� que estan asociados a v�nculos a las aplicaciones
        sSQL = "SELECT MenuOptionsId, Class, href, title, texto, IsNodoHoja "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = " & MenuOptionsId
        sSQL = sSQL & " ORDER by Secuencia"

        FilaOpciones = FilaOpciones & "<td>"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                'Se asume que todas son opciones 
                FilaOpciones = FilaOpciones & "<a href='" & dtr("href").ToString & "' class='linksubmenu'>" & Espacios & dtr("texto").ToString & "</a><br />"
            End While
            LoadOpcionesBarraSubMenu = True
            dtr.Close()
        Catch
            LoadOpcionesBarraSubMenu = False
        End Try
        FilaOpciones = FilaOpciones & "</td>"
    End Function

    Public Function LoadOpcionesDelMenuAccordionSGI(ByRef MyTable As Table, ByVal MenuOptionsPId As Long, ByVal NodoId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim MenuOption As String = ""
        Dim t As Boolean
        Dim Espacios As String = ""

        'Titulo
        Row = New TableRow
        Cell = New TableCell

        Cell.Controls.Add(New LiteralControl("<ul>"))

        sSQL = "SELECT MenuOptionsId, Class, href, title, texto, IsNodoHoja "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = " & MenuOptionsPId & " "
        sSQL = sSQL & "ORDER by Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)


            While dtrFunciones.Read
                If dtrFunciones("IsNodoHoja").ToString = "Hoja" Then
                    MenuOption = "<li class='celdaMenuSGI'><a href='" & dtrFunciones("href").ToString & "' class='linkmenu'>" & dtrFunciones("texto").ToString & "</a></li>"
                    Cell.Controls.Add(New LiteralControl(MenuOption))
                Else
                    MenuOption = "<li class='celdaMenuSGI'><a class='linkmenu' onclick='aparecer(""sub" & dtrFunciones("MenuOptionsId").ToString & """)'> " & " > " & dtrFunciones("texto").ToString & "</a>"
                    Cell.Controls.Add(New LiteralControl(MenuOption))
                    If CLng(dtrFunciones("MenuOptionsId").ToString) = NodoId Then
                        MenuOption = "<div id=""sub" & dtrFunciones("MenuOptionsId").ToString & """ class='visible'><ul>"
                    Else
                        MenuOption = "<div id=""sub" & dtrFunciones("MenuOptionsId").ToString & """ class='visible'><ul>"
                    End If
                    Cell.Controls.Add(New LiteralControl(MenuOption))
                    Espacios = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
                    t = LoadOpcionesDelSubMenuAccordion(Cell, CLng(dtrFunciones("MenuOptionsId").ToString), Espacios, NodoId)
                    MenuOption = "</ul></div></li>"
                    Cell.Controls.Add(New LiteralControl(MenuOption))
                End If
            End While
            LoadOpcionesDelMenuAccordionSGI = True
            dtrFunciones.Close()
        Catch
            LoadOpcionesDelMenuAccordionSGI = False
        End Try
        Cell.Controls.Add(New LiteralControl("</ul>"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)


    End Function

    Public Function LeerTipoDocumentoQA(ByVal OpcionMenu As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        LeerTipoDocumentoQA = "Documentos"
        sSQL = "SELECT Documentos.[DocumentosTipo] as Tipo "
        sSQL = sSQL & "FROM Documentos "
        sSQL = sSQL & "WHERE DocumentosMenu = '" & OpcionMenu & "' "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                LeerTipoDocumentoQA = dtr("Tipo").ToString
            End While
            dtr.Close()
        Catch
            LeerTipoDocumentoQA = "Documentos"
        End Try
    End Function

    Public Sub NuevaCrearFormularioV2(ByVal NumeroPagina As Integer, ByVal TituloPagina As String, _
                                    ByVal DescripcionPagina As String, ByVal GroupValidation As String, _
                                    ByRef MyView As PlaceHolder, ByRef sumValidacion As ValidationSummary, _
                                    ByRef valTextBox As RequiredFieldValidator, ByRef REValidacion As RegularExpressionValidator, _
                                    ByRef CuValidacion As CustomValidator, ByRef CoValidacion As CompareValidator, _
                                    ByRef LoginButton As Button, ByRef CancelButton As Button, ByRef UpdateButton As Button, _
                                    ByRef NewButton As Button, ByRef SearchButton As Button, ByRef DeleteButton As Button, ByRef ReturnButton As Button, ByRef SaveButton As Button)


        '-------------------------- 26-Julio-2010 -----------------
        ' Esta nueva rutina supone trabajar con un contenedor del tipo PlaceHolder en vez del tipo
        ' table
        ' 08-12-2010: Incluye el boton Save para el control Upload
        '----------------------------------------------------------

        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim m As Integer = 0
        Dim n As Integer = 0
        Dim MyTable As Table
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim MiTablaSubTab As Table
        Dim MiRowSubTab As TableRow
        Dim MiCellSubTab As TableCell

        Dim arrLabel(25) As String
        Dim arrControl(25) As String
        Dim arrGrillaLabel(25) As String
        Dim arrGrillaControl(25) As String
        Dim ArrNodesId(25) As Long
        Dim arrNodesLabel(25) As String
        Dim arrNodesControl(25) As String
        Dim arrSubNodesId(25) As Long
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
        Dim Url As String = ""
        Dim FormularioWebPId As Long = 0
        Dim FormularioWebServiceCall As String = ""
        Dim FormularioWeb As New FormularioWeb

        Dim txtTextBox As TextBox
        Dim txtDropDownList As DropDownList
        Dim txtCheckBox As CheckBox
        Dim sqlSource As SqlDataSource
        Dim txtCalendar As CalendarExtender
        Dim ImgImages As Image
        Dim AutoComp As AutoCompleteExtender
        Dim txtUploadFile As FileUpload
        Dim UploadLink As HyperLink


        Dim sSQL As String = ""
        Dim HTMLCode As String = ""

        Dim AnchoTablaTabs As Integer = 0
        Dim sJavaScript As String = ""

        ' Primero se despliegan
        ' los campos que son de contexto y que no pueden ser alterados por ning�n motivo, como
        ' por ejemplo aquellos campos que son claves �nicas y que no pueden ser modificados
        ' o aquellos campos que corresponden a la foreing key hacia la tabla padre, en el
        ' caso de una aplicaci�n del tipo master-detail.

        ' Estos campos se encuentran en la section FormKeys y pueden no existir para determinados
        ' tipos de formularios y se leen mediante el metodo 
        ' LeerKeysFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        t = Lecturas.LeerKeysFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        ' A continuaci�n pongo los textos de identificaci�n de la p�gina, que fueron pasados como
        ' par�metros de invocaci�n

        MyTable = New Table
        MyTable.ID = "ViewHeader"
        MyTable.Width = "700"
        MyTable.CellSpacing = "2"
        MyTable.CellPadding = "2"
        MyTable.CssClass = "visible"
        'Titulo
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("<h1>" & TituloPagina & "</h1>"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        'Linea de Divisi�n
        'Row = New TableRow
        'Cell = New TableCell
        'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        'Cell.Height = "4"
        'Cell.ColumnSpan = "2"
        'Cell.Controls.Add(New LiteralControl("<hr />"))
        'Row.Cells.Add(Cell)
        'MyTable.Rows.Add(Row)
        'Descripci�n
        'Se esconde la descripci�n a solicitud de Priscilla
        'Row = New TableRow
        'Cell = New TableCell
        'Cell.CssClass = "tab_contenido"
        'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        'Cell.ColumnSpan = "2"
        'Cell.Controls.Add(New LiteralControl(DescripcionPagina))
        'Row.Cells.Add(Cell)
        'MyTable.Rows.Add(Row)
        MyView.Controls.Add(MyTable)

        ' Bajo el nuevo esquema, creo otra tabla para los campos claves y la sumo al placeholder

        MyTable = New Table
        MyTable.ID = "ViewKeys"
        MyTable.Width = "700"
        MyTable.CellSpacing = "2"
        MyTable.CellPadding = "2"
        If i > 0 Then
            Row = New TableRow
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "FormKeys", GroupValidation, NumeroPagina, k + 1)
                'aqui va la creaci�n de la fila
                Cell = New TableCell
                Cell.CssClass = CssClassLabel
                Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
                Cell.Style(HtmlTextWriterStyle.Width) = "10%"
                If k = 0 Then
                    Cell.Controls.Add(New LiteralControl(arrLabel(k) & " : "))
                End If
                'Cell.Controls.Add(New LiteralControl(arrLabel(k) & " : "))
                Row.Cells.Add(Cell)
                Cell = New TableCell
                Cell.Style(HtmlTextWriterStyle.Width) = "40%"
                txtTextBox = New TextBox
                txtTextBox.ID = arrControl(k)
                txtTextBox.ClientIDMode = ClientIDMode.Static
                txtTextBox.CssClass = CssClassControl
                txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                txtTextBox.TextMode = ControlTextMode
                If ControlTextMode = 1 Then
                    txtTextBox.Height = "50"
                End If
                txtTextBox.ToolTip = ToolTip
                If IsNotEnabledField Then
                    txtTextBox.Enabled = False
                End If
                ' OJO esta instrucci�n no es generica y la coloque ha solicitud de Juan Manuel
                ' para esconder el campo Secuencia
                If k = 1 Then
                    txtTextBox.Visible = False  'Se esconde el n�mero de secuencia
                End If
                Cell.Controls.Add(txtTextBox)
                Row.Cells.Add(Cell)
                ' Aqu� se suma la fila
            Next
            MyTable.Rows.Add(Row)
            'Linea de Divisi�n
            'Se elimino el 25-09-2011
            'Row = New TableRow
            'Cell = New TableCell
            'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            'Cell.Height = "4"
            'Cell.ColumnSpan = "4"  ' Se pone 4 esta vez para desplegar a 2 columnas
            'Cell.Controls.Add(New LiteralControl("<hr />"))
            'Row.Cells.Add(Cell)
            'MyTable.Rows.Add(Row)
        End If
        MyView.Controls.Add(MyTable)



        'Luego se agrega la tabla de control de validaci�n de los campos

        MyTable = New Table
        MyTable.ID = "ViewValidationSummary"
        MyTable.Width = "700"
        MyTable.CellSpacing = "2"
        MyTable.CellPadding = "2"
        'Summary de Validaciones
        Row = New TableRow
        Cell = New TableCell
        Cell.CssClass = "validador"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        sumValidacion = New ValidationSummary
        sumValidacion.ID = "RegisterUserValidationSummary"
        sumValidacion.HeaderText = "Existen problemas con los siguientes campos del formulario"
        sumValidacion.CssClass = "validador"
        sumValidacion.ValidationGroup = GroupValidation
        Cell.Controls.Add(sumValidacion)
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)
        MyView.Controls.Add(MyTable)

        i = 0

        ' A continuaci�n leo el registro de cabecera del formulario y desde el cual derivan el
        ' resto de los registros que indican sus atributos y sus acciones
        ' Este registro se identifica pues es el �nico del formulario que pertenece a la 
        ' section FormHeader y se lee con el metodo: LeerHeaderFormularioWeb, que devuelve
        ' una �nica variable cuyo valor gobierna las siguientes decisiones de despliegue de los 
        ' atributos del formulario web, para ello este metodo se implementa como una funci�n que 
        ' devuelve un �nico campo booleano que puede poseer los siguientes valores:

        '   False:  No se encontro registro de cabecera, en cuyo caso el formulario es plano y no
        '           requiere un recorrido recursivo para ir desplegando sus atributos.
        '   ------------------------------------------------------------------------------------
        '   True:  Se encontro registro de cabecera y ello indica que el formulario debe ser recorrido
        '           en forma recursiva a continuaci�n del despliegue de los campos clave, siempre y cuando
        '           estos existan como atributos del formulario.
        t = Lecturas.LeerHeaderFormularioWeb(arrLabel, arrControl, NumeroPagina, i, FormularioWebPId)

        If i = 1 Then ' Se encontro un registro de cabecera para el formulario web

            ' Para emular tab container con tab panel se usaran solo tablas, con la capacidad de hacerse visibles o
            ' invisibles, dejando una sola visible a la vez.

            ' La primera tabla actuara como Tab Panel y es una tabla de una sola fila con tantas columnas como 
            ' grupos de campos tenga el formulario, para ello se hara un primer recorrido de las cabeceras encontradas

            ' Voy a usar una table en vez de un tab container

            i = 0
            t = Lecturas.LeerNodesFormularioWeb(arrLabel, arrControl, ArrNodesId, i, FormularioWebPId)
            If i > 1 Then 'Solo se despliegan tabs cuando hay m�s de 1, en el otro caso no lo amerita.
                'Creamos tabla y la �nica fila
                AnchoTablaTabs = 116 * (i + 1)
                MyTable = New Table
                MyTable.ID = "ViewBody" & FormularioWebPId
                MyTable.Width = AnchoTablaTabs
                MyTable.CellSpacing = "2"
                MyTable.CellPadding = "2"
                Row = New TableRow
                For k = 0 To i - 1
                    sJavaScript = ""
                    For m = 0 To i - 1
                        If m = k Then
                            sJavaScript = sJavaScript & "aparecer(""sub" & arrControl(m) & "sub"");"
                        Else
                            sJavaScript = sJavaScript & "desaparecer(""sub" & arrControl(m) & "sub"");"
                        End If
                    Next
                    Cell = New TableCell
                    Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
                    Cell.Width = "120"
                    Cell.CssClass = "boxceleste"
                    Cell.Controls.Add(New LiteralControl("<a onclick='" & sJavaScript & "'>" & arrLabel(k) & "</a>"))
                    Row.Cells.Add(Cell)
                Next
                sJavaScript = ""
                For m = 0 To i - 1
                    sJavaScript = sJavaScript & "todosvisibles(""sub" & arrControl(m) & "sub"");"
                Next
                Cell = New TableCell
                Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
                Cell.Width = "120"
                Cell.CssClass = "boxceleste"
                Cell.Controls.Add(New LiteralControl("<a onclick='" & sJavaScript & "'>" & "Ver ficha completa" & "</a>"))
                Row.Cells.Add(Cell)
                MyTable.Rows.Add(Row)
                MyView.Controls.Add(MyTable)
            End If
            'Con el mismo arreglo de nodos, vuelvo a recorrerlos pero ahora por cada uno, leo sus nodos hijos
            'para asi cargos los controles del formulario web.

            If i > 0 Then
                For k = 0 To i - 1
                    n = 0
                    t = Lecturas.LeerNodesFormularioWeb(arrNodesLabel, arrNodesControl, arrSubNodesId, n, ArrNodesId(k))
                    'Aqui acabo de leer los nodos del primer tab, por ahora no hay m�s anidamiento, asi que cada nodo
                    'en arrNodesLabel es en realidad una hoja
                    MiTablaSubTab = New Table
                    MiTablaSubTab.ID = "sub" & arrControl(k) & "sub"
                    MiTablaSubTab.ClientIDMode = ClientIDMode.Static
                    MiTablaSubTab.Width = "700"
                    MiTablaSubTab.Caption = arrLabel(k)
                    MiTablaSubTab.CaptionAlign = TableCaptionAlign.Left
                    MiTablaSubTab.CellSpacing = "2"
                    MiTablaSubTab.CellPadding = "2"
                    If k = 0 Then
                        MiTablaSubTab.CssClass = "visible"
                    Else
                        MiTablaSubTab.CssClass = "invisible"
                    End If
                    MiTablaSubTab.BackColor = Drawing.Color.WhiteSmoke
                    MiTablaSubTab.BorderStyle = BorderStyle.Solid
                    MiTablaSubTab.BorderWidth = 1
                    MiTablaSubTab.BorderColor = Drawing.Color.WhiteSmoke

                    'Controles del Formulario Web
                    For m = 0 To n - 1
                        t = Lecturas.LeerLeafFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, GroupValidation, FormularioWebServiceCall, arrSubNodesId(m))
                        ' Cambio introducido para dejar no visible ciertos campos
                        ' 27 de Abril de 2011
                        ' ------------------------------------------------------
                        If FormularioWeb.CampoIsVisible(arrSubNodesId(m)) = True Then

                            MiRowSubTab = New TableRow
                            MiRowSubTab.VerticalAlign = VerticalAlign.Top
                            MiCellSubTab = New TableCell
                            MiCellSubTab.CssClass = CssClassLabel
                            'MiCellSubTab.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
                            MiCellSubTab.Style(HtmlTextWriterStyle.TextAlign) = "left"
                            MiCellSubTab.Style(HtmlTextWriterStyle.Width) = "20%"
                            If IsRequiredField Then
                                MiCellSubTab.Controls.Add(New LiteralControl(arrNodesLabel(m) & " (*) "))
                            Else
                                MiCellSubTab.Controls.Add(New LiteralControl(arrNodesLabel(m) & "  "))
                            End If
                            MiRowSubTab.Cells.Add(MiCellSubTab)
                            MiCellSubTab = New TableCell
                            MiCellSubTab.Style(HtmlTextWriterStyle.Width) = "80%"
                            MiCellSubTab.VerticalAlign = VerticalAlign.Middle
                            Select Case TipoControl
                                Case "TextBox"
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    If Mid(DomainField, 1, 2) = "Nb" Then
                                        txtTextBox.Style(HtmlTextWriterStyle.TextAlign) = "Right"
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                Case "CheckBox"
                                    txtCheckBox = New CheckBox
                                    txtCheckBox.ID = arrNodesControl(m)
                                    txtCheckBox.ClientIDMode = ClientIDMode.Static
                                    txtCheckBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtCheckBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtCheckBox)
                                Case "TextBoxAutoComplete"
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    AutoComp = New AutoCompleteExtender
                                    AutoComp.ID = "Autocomplete" & arrNodesControl(m)
                                    AutoComp.ClientIDMode = UI.ClientIDMode.Static
                                    AutoComp.CompletionListItemCssClass = CssClassControl
                                    AutoComp.TargetControlID = arrNodesControl(m)
                                    AutoComp.ServicePath = "AutoComplete.asmx"
                                    AutoComp.ServiceMethod = FormularioWebServiceCall
                                    AutoComp.MinimumPrefixLength = "2"
                                    AutoComp.CompletionInterval = "1000"
                                    AutoComp.EnableCaching = "true"
                                    AutoComp.CompletionSetCount = "12"
                                    MiCellSubTab.Controls.Add(AutoComp)
                                Case "TextBoxCalendar"
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ImgImages = New Image
                                    ImgImages.ID = "Image" & arrNodesControl(m)
                                    ImgImages.ClientIDMode = UI.ClientIDMode.Static
                                    ImgImages.ImageUrl = "img/Calendar_scheduleHS.png"
                                    ImgImages.ImageAlign = ImageAlign.Middle
                                    MiCellSubTab.Controls.Add(ImgImages)
                                    txtCalendar = New CalendarExtender
                                    txtCalendar.ID = "Calendar" & arrNodesControl(m)
                                    txtCalendar.ClientIDMode = UI.ClientIDMode.Static
                                    txtCalendar.TargetControlID = arrNodesControl(m)
                                    txtCalendar.PopupButtonID = "Image" & arrNodesControl(m)
                                    txtCalendar.Format = "dd/MM/yy"
                                    MiCellSubTab.Controls.Add(txtCalendar)
                                Case "DropDownList"
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = arrNodesControl(m)
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtDropDownList.ToolTip = ToolTip
                                    txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                    txtDropDownList.DataTextField = DataTextField
                                    MiCellSubTab.Controls.Add(txtDropDownList)

                                    sqlSource  = New SqlDataSource()                    
                                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                    sqlSource.SelectCommand = SelectCommand

                                    sqlSource.ID = "ds" & arrNodesControl(m)
                                    'sqlSource.DataFile = DataFile
                                    'sqlSource.SelectCommand = SelectCommand
                                    MiCellSubTab.Controls.Add(sqlSource)
                                Case "DropDownSearch"
                                    txtCheckBox = New CheckBox
                                    txtCheckBox.ID = "chk" & arrNodesControl(m)
                                    txtCheckBox.ClientIDMode = ClientIDMode.Static
                                    txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrNodesLabel(m)
                                    MiCellSubTab.Controls.Add(txtCheckBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = arrNodesControl(m)
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtDropDownList.ToolTip = ToolTip
                                    txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                    txtDropDownList.DataTextField = DataTextField
                                    MiCellSubTab.Controls.Add(txtDropDownList)

                                    sqlSource  = New SqlDataSource()                    
                                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                    sqlSource.SelectCommand = SelectCommand 

                                    sqlSource.ID = "ds" & arrNodesControl(m)
                                    'sqlSource.DataFile = DataFile
                                    'sqlSource.SelectCommand = SelectCommand
                                    MiCellSubTab.Controls.Add(sqlSource)
                                Case "UploadArchivo" 'S�lo 1 campo de este tipo por p�gina web
                                    txtUploadFile = New FileUpload
                                    txtUploadFile.ID = "txtUploadFile"
                                    txtUploadFile.ClientIDMode = ClientIDMode.Static
                                    txtUploadFile.ToolTip = "Busque el archivo a subir"
                                    txtUploadFile.CssClass = CssClassControl
                                    txtUploadFile.Width = "200"
                                    txtUploadFile.Height = "20"
                                    MiCellSubTab.Controls.Add(txtUploadFile)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ' Se agrega el bot�n Save
                                    SaveButton = New Button
                                    SaveButton.ID = "SaveButton"
                                    SaveButton.CssClass = "boxceleste"
                                    SaveButton.Style(HtmlTextWriterStyle.Width) = 60
                                    SaveButton.Text = "Guardar"
                                    SaveButton.ToolTip = "De un click para guardar el archivo"
                                    'AddHandler SaveButton.Click, AddressOf RFC_Save
                                    MiCellSubTab.Controls.Add(SaveButton)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ' Se agrega el campo de texto
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    txtTextBox.Visible = True
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ' Se agrega el Hyperlink para ver el archivo
                                    UploadLink = New HyperLink
                                    UploadLink.ID = "lnkFile"
                                    UploadLink.ClientIDMode = ClientIDMode.Static
                                    UploadLink.ImageUrl = "~/img/lupa20x20.png"
                                    'UploadLink.BorderWidth = 0
                                    'UploadLink.Text = "Ver Archivo"
                                    UploadLink.ToolTip = "De un click para visualizar el archivo"
                                    UploadLink.Visible = True
                                    MiCellSubTab.Controls.Add(UploadLink)
                                Case "CascadeDropDown" 'Se agrega solo para proyecto Codelco
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = "ddlAmbitos"
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                                    txtDropDownList.ToolTip = "Escoja el Ambito"
                                    MiCellSubTab.Controls.Add(txtDropDownList)
                                    MiCellSubTab.Controls.Add(New LiteralControl("<br /> "))

                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = "ddlHojas"
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                                    txtDropDownList.ToolTip = "Escoja la opci�n de men�"
                                    MiCellSubTab.Controls.Add(txtDropDownList)
                                    MiCellSubTab.Controls.Add(New LiteralControl("<br /> "))

                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = "ddlDocumentos"
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                                    txtDropDownList.ToolTip = "Documentos actualmente vinculados"
                                    MiCellSubTab.Controls.Add(txtDropDownList)
                                    MiCellSubTab.Controls.Add(New LiteralControl("<br /> "))

                                Case "SelectFromModalList"   'Se agrega para proyecto con Importadora Vergara
                                    MiCellSubTab.Controls.Add(New LiteralControl("<input id=""btnModal""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""?"" onclick=""verModal" & arrNodesControl(m) & "('SelectFromModalList.aspx?Accion=" & SelectCommand & "')"" style=""width: 20px"" /> "))
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" <input id=""btnHelp" & arrNodesControl(m) & """ class=""boxceleste"" type=""button"" value=""..."" onclick=""return btnHelp" & arrNodesControl(m) & "_onclick()"" style=""width: 30px"" /> "))

                                    '<asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" autoComplete="off" Width="200px"  ></asp:TextBox>
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m) & "Description"
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = "350px"
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.Enabled = False
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    'MiCellSubTab.Controls.Add(New LiteralControl("<input id=""btnHelpCodigo""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""Leer por Nombre"" onclick=""return btnHelpNombre" & arrNodesControl(m) & "_onclick()"" style=""width: 100px"" />"))
                                    MiCellSubTab.Controls.Add(New LiteralControl(GenerarJScript(arrNodesControl(m), SelectCommand)))

                                Case "DropDownListPlusDescription"
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = arrNodesControl(m)
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtDropDownList.ToolTip = ToolTip
                                    txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                    txtDropDownList.DataTextField = DataTextField
                                    MiCellSubTab.Controls.Add(txtDropDownList)


                                    sqlSource  = New SqlDataSource()                    
                                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                    sqlSource.SelectCommand = SelectCommand

                                    sqlSource.ID = "ds" & arrNodesControl(m)
                                    'sqlSource.DataFile = DataFile
                                    'sqlSource.SelectCommand = SelectCommand
                                    MiCellSubTab.Controls.Add(sqlSource)

                                    MiCellSubTab.Controls.Add(New LiteralControl(" <input id=""btnHelp" & arrNodesControl(m) & """ class=""boxceleste"" type=""button"" value=""..."" onclick=""return btnHelp" & arrNodesControl(m) & "_onclick()"" style=""width: 30px"" /> "))

                                    '<asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" autoComplete="off" Width="200px"  ></asp:TextBox>
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m) & "Description"
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = "350px"
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.Enabled = False
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    'MiCellSubTab.Controls.Add(New LiteralControl("<input id=""btnHelpCodigo""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""Leer por Nombre"" onclick=""return btnHelpNombre" & arrNodesControl(m) & "_onclick()"" style=""width: 100px"" />"))
                                    MiCellSubTab.Controls.Add(New LiteralControl(GenerarJScriptOnlyDescription(arrNodesControl(m), SelectCommand)))


                            End Select

                            If IsRequiredField Then
                                valTextBox = New RequiredFieldValidator
                                valTextBox.ID = "RequiredField" & arrNodesControl(m)
                                valTextBox.ControlToValidate = arrNodesControl(m)
                                valTextBox.ClientIDMode = ClientIDMode.Static
                                valTextBox.ForeColor = Drawing.Color.Red
                                valTextBox.Text = "*"
                                valTextBox.ErrorMessage = arrNodesLabel(m) & " es un campo obligatorio"
                                valTextBox.CssClass = "tab_contenido"
                                valTextBox.ValidationGroup = GroupValidation
                                MiCellSubTab.Controls.Add(valTextBox)
                            End If
                            Select Case DomainField
                                Case "Correo"
                                    REValidacion = New RegularExpressionValidator
                                    REValidacion.ID = "RegularExpression" & arrNodesControl(m)
                                    REValidacion.ControlToValidate = arrNodesControl(m)
                                    REValidacion.ClientIDMode = ClientIDMode.Static
                                    REValidacion.Text = "*"
                                    REValidacion.ErrorMessage = "La direcci�n de correo no tiene un formato valido"
                                    REValidacion.CssClass = "tab_contenido"
                                    REValidacion.ValidationGroup = GroupValidation
                                    REValidacion.ValidationExpression = "\S+@\S+\.\S{2,3}"
                                    MiCellSubTab.Controls.Add(REValidacion)
                                Case "RUT"
                                    CuValidacion = New CustomValidator
                                    CuValidacion.ID = "RutValidator" & arrNodesControl(m)
                                    CuValidacion.ControlToValidate = arrNodesControl(m)
                                    CuValidacion.ClientIDMode = ClientIDMode.Static
                                    CuValidacion.Text = "*"
                                    CuValidacion.ErrorMessage = "El RUT no es valido"
                                    CuValidacion.CssClass = "tab_contenido"
                                    CuValidacion.ValidationGroup = GroupValidation
                                    CuValidacion.EnableClientScript = True
                                    CuValidacion.ClientValidationFunction = "RutValidator_ClientValidate"
                                    MiCellSubTab.Controls.Add(CuValidacion)
                                Case "Numeros"
                                    CoValidacion = New CompareValidator
                                    CoValidacion.ID = "CompareValidator" & arrNodesControl(m)
                                    CoValidacion.ControlToValidate = arrNodesControl(m)
                                    CoValidacion.ClientIDMode = ClientIDMode.Static
                                    CoValidacion.Text = "*"
                                    CoValidacion.ErrorMessage = arrNodesLabel(m) & " debe ser un valor num�rico"
                                    CoValidacion.CssClass = "tab_contenido"
                                    CoValidacion.ValidationGroup = GroupValidation
                                    CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                                    CoValidacion.Type = ValidationDataType.Integer
                                    MiCellSubTab.Controls.Add(CoValidacion)
                                Case "Letras"
                                    CoValidacion = New CompareValidator
                                    CoValidacion.ID = "CompareValidator" & arrNodesControl(m)
                                    CoValidacion.ControlToValidate = arrNodesControl(m)
                                    CoValidacion.ClientIDMode = ClientIDMode.Static
                                    CoValidacion.Text = "*"
                                    CoValidacion.ErrorMessage = arrNodesLabel(m) & " debe ser un valor alfanum�rico"
                                    CoValidacion.CssClass = "tab_contenido"
                                    CoValidacion.ValidationGroup = GroupValidation
                                    CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                                    CoValidacion.Type = ValidationDataType.String
                                    MiCellSubTab.Controls.Add(CoValidacion)
                                Case "Fecha"
                                    CoValidacion = New CompareValidator
                                    CoValidacion.ID = "CompareValidator" & arrNodesControl(m)
                                    CoValidacion.ControlToValidate = arrNodesControl(m)
                                    CoValidacion.ClientIDMode = ClientIDMode.Static
                                    CoValidacion.Text = "*"
                                    CoValidacion.ErrorMessage = arrNodesLabel(m) & " debe ser una fecha valida"
                                    CoValidacion.CssClass = "tab_contenido"
                                    CoValidacion.ValidationGroup = GroupValidation
                                    CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                                    CoValidacion.Type = ValidationDataType.Date
                                    MiCellSubTab.Controls.Add(CoValidacion)

                            End Select
                            MiRowSubTab.Cells.Add(MiCellSubTab)
                            MiTablaSubTab.Rows.Add(MiRowSubTab)
                        Else
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrNodesControl(m)
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtTextBox.TextMode = ControlTextMode
                            txtTextBox.ToolTip = ToolTip
                            txtTextBox.Enabled = False
                            txtTextBox.Visible = False
                            MyView.Controls.Add(txtTextBox)
                        End If
                    Next

                    MyView.Controls.Add(MiTablaSubTab)
                Next
            End If

            ' Creamos nuevamente la tabla
            MyTable = New Table
            MyTable.ID = "ViewButtons"
            MyTable.Width = "700"
            MyTable.CellSpacing = "2"
            MyTable.CellPadding = "2"

            'Botones del Formulario
            i = 0
            t = Lecturas.LeerButtonFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            Row = New TableRow
            Cell = New TableCell
            Cell.CssClass = CssClassLabel
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Style(HtmlTextWriterStyle.Width) = "20%"
            'Se puso el 20 de Diciembre
            Cell.Controls.Add(New LiteralControl(" (*) Campo Obligatorio "))
            Row.Cells.Add(Cell)
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.Width) = "80%"
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Button", GroupValidation, NumeroPagina, k + 1)
                Select Case arrControl(k)
                    Case "LoginButton"
                        LoginButton = New Button
                        LoginButton.ID = arrControl(k)
                        LoginButton.CssClass = CssClassControl
                        LoginButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        LoginButton.Text = arrLabel(k)
                        LoginButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            LoginButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler LoginButton.Click, AddressOf RFC_Login
                        Cell.Controls.Add(LoginButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "CancelButton"
                        CancelButton = New Button
                        CancelButton.ID = arrControl(k)
                        CancelButton.CssClass = CssClassControl
                        CancelButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        CancelButton.Text = arrLabel(k)
                        CancelButton.ToolTip = ToolTip
                        'AddHandler CancelButton.Click, AddressOf RFC_Logout
                        Cell.Controls.Add(CancelButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "UpdateButton"
                        UpdateButton = New Button
                        UpdateButton.ID = arrControl(k)
                        UpdateButton.CssClass = CssClassControl
                        UpdateButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        UpdateButton.Text = arrLabel(k)
                        UpdateButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            UpdateButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(UpdateButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "NewButton"
                        NewButton = New Button
                        NewButton.ID = arrControl(k)
                        NewButton.CssClass = CssClassControl
                        NewButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        NewButton.Text = arrLabel(k)
                        NewButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            NewButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(NewButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "SearchButton"
                        SearchButton = New Button
                        SearchButton.ID = arrControl(k)
                        SearchButton.CssClass = CssClassControl
                        SearchButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        SearchButton.Text = arrLabel(k)
                        SearchButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            SearchButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(SearchButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "DeleteButton"
                        DeleteButton = New Button
                        DeleteButton.ID = arrControl(k)
                        DeleteButton.CssClass = CssClassControl
                        DeleteButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        DeleteButton.Text = arrLabel(k)
                        DeleteButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            DeleteButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler DeleteButton.Click, AddressOf RFC_Delete
                        Cell.Controls.Add(DeleteButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "ReturnButton"
                        ReturnButton = New Button
                        ReturnButton.ID = arrControl(k)
                        ReturnButton.CssClass = CssClassControl
                        ReturnButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        ReturnButton.Text = arrLabel(k)
                        ReturnButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            ReturnButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler ReturnButton.Click, AddressOf RFC_Return
                        Cell.Controls.Add(ReturnButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                End Select
            Next

            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
            MyView.Controls.Add(MyTable)
        Else

            ' Significa que no hay tabs definidos para el formulario en cuesti�n y que 
            ' por tanto la l�gica de despliegue es la misma de siempre y podremos hacer todo
            ' en una �nica tabla y luego agregarla a la view.

            MyTable = New Table
            MyTable.ID = "ViewBody"
            MyTable.Width = "700"
            MyTable.CellSpacing = "2"
            MyTable.CellPadding = "2"


            'Linea de Divisi�n
            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Height = "4"
            Cell.ColumnSpan = "2"
            Cell.Controls.Add(New LiteralControl("<hr />"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)

            i = 0
            t = Lecturas.LeerLabelFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

            'Controles del Formulario Web
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Form", GroupValidation, NumeroPagina, k + 1)
                ' Cambio introducido para dejar no visible ciertos campos
                ' 27 de Abril de 2011
                ' ------------------------------------------------------
                If FormularioWeb.CampoIsVisibleV2(Section, NumeroPagina, k + 1) = True Then
                    Row = New TableRow
                    Cell = New TableCell
                    Cell.CssClass = CssClassLabel
                    Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
                    Cell.Style(HtmlTextWriterStyle.Width) = "20%"
                    Cell.Controls.Add(New LiteralControl(arrLabel(k) & " : "))
                    Row.Cells.Add(Cell)
                    Cell = New TableCell
                    Cell.Style(HtmlTextWriterStyle.Width) = "80%"
                    Cell.VerticalAlign = VerticalAlign.Middle
                    Select Case TipoControl
                        Case "TextBox"
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrControl(k)
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtTextBox.TextMode = ControlTextMode
                            If ControlTextMode = 1 Then
                                txtTextBox.Height = "50"
                            End If
                            txtTextBox.ToolTip = ToolTip
                            If IsNotEnabledField Then
                                txtTextBox.Enabled = False
                            End If
                            If Mid(DomainField, 1, 2) = "Nb" Then
                                txtTextBox.Style(HtmlTextWriterStyle.TextAlign) = "Right"
                            End If
                            Cell.Controls.Add(txtTextBox)
                        Case "CheckBox"
                            txtCheckBox = New CheckBox
                            txtCheckBox.ID = arrNodesControl(m)
                            txtCheckBox.ClientIDMode = ClientIDMode.Static
                            txtCheckBox.ToolTip = ToolTip
                            If IsNotEnabledField Then
                                txtCheckBox.Enabled = False
                            End If
                            Cell.Controls.Add(txtCheckBox)
                        Case "TextBoxAutoComplete"
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrControl(k)
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtTextBox.TextMode = ControlTextMode
                            If ControlTextMode = 1 Then
                                txtTextBox.Height = "50"
                            End If
                            txtTextBox.ToolTip = ToolTip
                            If IsNotEnabledField Then
                                txtTextBox.Enabled = False
                            End If
                            Cell.Controls.Add(txtTextBox)
                            AutoComp = New AutoCompleteExtender
                            AutoComp.ID = "Autocomplete" & arrControl(k)
                            AutoComp.ClientIDMode = UI.ClientIDMode.Static
                            AutoComp.CompletionListItemCssClass = CssClassControl
                            AutoComp.TargetControlID = arrControl(k)
                            AutoComp.ServicePath = "AutoComplete.asmx"
                            AutoComp.ServiceMethod = Lecturas.LeerNombreMetodoAutocomplete("Form", NumeroPagina, k + 1)  ' Aqui hay que invocar un metodo para traer el nombre del m�todo
                            AutoComp.MinimumPrefixLength = "2"
                            AutoComp.CompletionInterval = "1000"
                            AutoComp.EnableCaching = "true"
                            AutoComp.CompletionSetCount = "12"
                            Cell.Controls.Add(AutoComp)
                        Case "TextBoxCalendar"
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrControl(k)
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtTextBox.TextMode = ControlTextMode
                            txtTextBox.ToolTip = ToolTip
                            If IsNotEnabledField Then
                                txtTextBox.Enabled = False
                            End If
                            Cell.Controls.Add(txtTextBox)
                            Cell.Controls.Add(New LiteralControl(" "))
                            ImgImages = New Image
                            ImgImages.ID = "Image" & arrControl(k)
                            ImgImages.ClientIDMode = UI.ClientIDMode.Static
                            ImgImages.ImageUrl = "img/Calendar_scheduleHS.png"
                            ImgImages.ImageAlign = ImageAlign.Middle
                            Cell.Controls.Add(ImgImages)
                            txtCalendar = New CalendarExtender
                            txtCalendar.ID = "Calendar" & arrControl(k)
                            txtCalendar.ClientIDMode = UI.ClientIDMode.Static
                            txtCalendar.TargetControlID = arrControl(k)
                            txtCalendar.PopupButtonID = "Image" & arrControl(k)
                            txtCalendar.Format = "dd/MMM/yy"
                            Cell.Controls.Add(txtCalendar)
                        Case "DropDownList"
                            txtDropDownList = New DropDownList
                            txtDropDownList.ID = arrControl(k)
                            txtDropDownList.ClientIDMode = ClientIDMode.Static
                            txtDropDownList.CssClass = CssClassControl
                            txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtDropDownList.ToolTip = ToolTip
                            txtDropDownList.DataSourceID = "ds" & arrControl(k)
                            txtDropDownList.DataTextField = DataTextField
                            Cell.Controls.Add(txtDropDownList)

                            sqlSource  = New SqlDataSource()                    
                            sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                            sqlSource.SelectCommand = SelectCommand                            
                            sqlSource.ID = "ds" & arrControl(k)
                            'sqlSource.DataFile = DataFile
                            'sqlSource.SelectCommand = SelectCommand
                            Cell.Controls.Add(sqlSource)
                        Case "DropDownSearch"
                            txtCheckBox = New CheckBox
                            txtCheckBox.ID = "chk" & arrControl(k)
                            txtCheckBox.ClientIDMode = ClientIDMode.Static
                            txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrLabel(k)
                            Cell.Controls.Add(txtCheckBox)
                            Cell.Controls.Add(New LiteralControl(" "))
                            txtDropDownList = New DropDownList
                            txtDropDownList.ID = arrControl(k)
                            txtDropDownList.ClientIDMode = ClientIDMode.Static
                            txtDropDownList.CssClass = CssClassControl
                            txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtDropDownList.ToolTip = ToolTip
                            txtDropDownList.DataSourceID = "ds" & arrControl(k)
                            txtDropDownList.DataTextField = DataTextField
                            Cell.Controls.Add(txtDropDownList)

                            sqlSource  = New SqlDataSource()                    
                            sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                            sqlSource.SelectCommand = SelectCommand

                            sqlSource.ID = "ds" & arrControl(k)
                            'sqlSource.DataFile = DataFile
                            'sqlSource.SelectCommand = SelectCommand
                            Cell.Controls.Add(sqlSource)
                        Case "UploadArchivo" 'S�lo 1 campo de este tipo por p�gina web
                            txtUploadFile = New FileUpload
                            txtUploadFile.ID = "txtUploadFile"
                            txtUploadFile.ClientIDMode = ClientIDMode.Static
                            txtUploadFile.ToolTip = "Busque el archivo a subir"
                            txtUploadFile.CssClass = CssClassControl
                            txtUploadFile.Height = "20"
                            Cell.Controls.Add(txtUploadFile)
                            Cell.Controls.Add(New LiteralControl(" "))
                            ' Se agrega el bot�n Save
                            SaveButton = New Button
                            SaveButton.ID = "SaveButton"
                            SaveButton.CssClass = "boxceleste"
                            SaveButton.Style(HtmlTextWriterStyle.Width) = 70
                            SaveButton.Text = "Guardar"
                            SaveButton.ToolTip = "De un click para guardar el archivo"
                            'AddHandler SaveButton.Click, AddressOf RFC_Save
                            Cell.Controls.Add(SaveButton)
                            Cell.Controls.Add(New LiteralControl(" "))
                            ' Se agrega el campo de texto
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrNodesControl(m)
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtTextBox.TextMode = ControlTextMode
                            If ControlTextMode = 1 Then
                                txtTextBox.Height = "50"
                            End If
                            txtTextBox.ToolTip = ToolTip
                            If IsNotEnabledField Then
                                txtTextBox.Enabled = False
                            End If
                            Cell.Controls.Add(txtTextBox)
                            Cell.Controls.Add(New LiteralControl(" "))
                            ' Se agrega el Hyperlink para ver el archivo
                            UploadLink = New HyperLink
                            UploadLink.ID = "lnkFile"
                            'UploadLink.ImageUrl = "~/img/icono_pdf.gif"
                            'UploadLink.BorderWidth = 0
                            UploadLink.Text = "Ver Archivo"
                            UploadLink.ClientIDMode = ClientIDMode.Static
                            UploadLink.ToolTip = "De un click para visualizar el archivo"
                            Cell.Controls.Add(UploadLink)
                        Case "CascadeDropDown" 'Se agrega solo para proyecto Codelco
                            txtDropDownList = New DropDownList
                            txtDropDownList.ID = "ddlAmbitos"
                            txtDropDownList.ClientIDMode = ClientIDMode.Static
                            txtDropDownList.CssClass = CssClassControl
                            txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                            txtDropDownList.ToolTip = "Escoja el Ambito"
                            Cell.Controls.Add(txtDropDownList)
                            Cell.Controls.Add(New LiteralControl("<br /> "))

                            txtDropDownList = New DropDownList
                            txtDropDownList.ID = "ddlHojas"
                            txtDropDownList.ClientIDMode = ClientIDMode.Static
                            txtDropDownList.CssClass = CssClassControl
                            txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                            txtDropDownList.ToolTip = "Escoja la opci�n de men�"
                            Cell.Controls.Add(txtDropDownList)
                            Cell.Controls.Add(New LiteralControl("<br /> "))

                            txtDropDownList = New DropDownList
                            txtDropDownList.ID = "ddlDocumentos"
                            txtDropDownList.ClientIDMode = ClientIDMode.Static
                            txtDropDownList.CssClass = CssClassControl
                            txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                            txtDropDownList.ToolTip = "Documentos actualmente vinculados"
                            Cell.Controls.Add(txtDropDownList)
                            Cell.Controls.Add(New LiteralControl("<br /> "))

                        Case "SelectFromModalList"   'Se agrega para proyecto con Importadora Vergara
                            Cell.Controls.Add(New LiteralControl("<input id=""btnModal""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""?"" onclick=""verModal" & arrNodesControl(m) & "('SelectFromModalList.aspx?Accion=" & SelectCommand & "')"" style=""width: 20px"" /> "))
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrNodesControl(m)
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtTextBox.TextMode = ControlTextMode
                            txtTextBox.ToolTip = ToolTip
                            If IsNotEnabledField Then
                                txtTextBox.Enabled = False
                            End If
                            Cell.Controls.Add(txtTextBox)
                            Cell.Controls.Add(New LiteralControl(" <input id=""btnHelp" & arrNodesControl(m) & """ class=""boxceleste"" type=""button"" value=""..."" onclick=""return btnHelp" & arrNodesControl(m) & "_onclick()"" style=""width: 30px"" /> "))

                            '<asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" autoComplete="off" Width="200px"  ></asp:TextBox>
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrNodesControl(m) & "Description"
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = "350px"
                            txtTextBox.TextMode = ControlTextMode
                            txtTextBox.Enabled = False
                            Cell.Controls.Add(txtTextBox)
                            'Cell.Controls.Add(New LiteralControl("<input id=""btnHelpCodigo""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""Leer por Nombre"" onclick=""return btnHelpNombre" & arrNodesControl(m) & "_onclick()"" style=""width: 100px"" />"))
                            Cell.Controls.Add(New LiteralControl(GenerarJScript(arrNodesControl(m), SelectCommand)))
                        Case "DropDownListPlusDescription"
                            txtDropDownList = New DropDownList
                            txtDropDownList.ID = arrNodesControl(m)
                            txtDropDownList.ClientIDMode = ClientIDMode.Static
                            txtDropDownList.CssClass = CssClassControl
                            txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            txtDropDownList.ToolTip = ToolTip
                            txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                            txtDropDownList.DataTextField = DataTextField
                            Cell.Controls.Add(txtDropDownList)

                            sqlSource  = New SqlDataSource()                   
                            sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                            sqlSource.SelectCommand = SelectCommand                            
                            sqlSource.ID = "ds" & arrNodesControl(m)
                            'sqlSource.DataFile = DataFile
                            'sqlSource.SelectCommand = SelectCommand
                            Cell.Controls.Add(sqlSource)

                            Cell.Controls.Add(New LiteralControl(" <input id=""btnHelp" & arrNodesControl(m) & """ class=""boxceleste"" type=""button"" value=""..."" onclick=""return btnHelp" & arrNodesControl(m) & "_onclick()"" style=""width: 30px"" /> "))

                            '<asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" autoComplete="off" Width="200px"  ></asp:TextBox>
                            txtTextBox = New TextBox
                            txtTextBox.ID = arrNodesControl(m) & "Description"
                            txtTextBox.ClientIDMode = ClientIDMode.Static
                            txtTextBox.CssClass = CssClassControl
                            txtTextBox.Style(HtmlTextWriterStyle.Width) = "350px"
                            txtTextBox.TextMode = ControlTextMode
                            txtTextBox.Enabled = False
                            Cell.Controls.Add(txtTextBox)
                            'MiCellSubTab.Controls.Add(New LiteralControl("<input id=""btnHelpCodigo""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""Leer por Nombre"" onclick=""return btnHelpNombre" & arrNodesControl(m) & "_onclick()"" style=""width: 100px"" />"))
                            Cell.Controls.Add(New LiteralControl(GenerarJScriptOnlyDescription(arrNodesControl(m), SelectCommand)))

                    End Select

                    Row.Cells.Add(Cell)

                    If IsRequiredField Then
                        valTextBox = New RequiredFieldValidator
                        valTextBox.ID = "RequiredField" & arrControl(k)
                        valTextBox.ControlToValidate = arrControl(k)
                        valTextBox.Text = "*"
                        valTextBox.ErrorMessage = arrLabel(k) & " es un campo obligatorio"
                        valTextBox.CssClass = "tab_contenido"
                        valTextBox.ValidationGroup = GroupValidation
                        Cell.Controls.Add(valTextBox)
                    End If
                    Select Case DomainField
                        Case "Correo"
                            REValidacion = New RegularExpressionValidator
                            REValidacion.ID = "RegularExpression" & arrControl(k)
                            REValidacion.ControlToValidate = arrControl(k)
                            REValidacion.Text = "*"
                            REValidacion.ErrorMessage = "La direcci�n de correo no tiene un formato valido"
                            REValidacion.CssClass = "tab_contenido"
                            REValidacion.ValidationGroup = GroupValidation
                            REValidacion.ValidationExpression = "\S+@\S+\.\S{2,3}"
                            Cell.Controls.Add(REValidacion)
                        Case "RUT"
                            CuValidacion = New CustomValidator
                            CuValidacion.ID = "RutValidator" & arrControl(k)
                            CuValidacion.ControlToValidate = arrControl(k)
                            CuValidacion.Text = "*"
                            CuValidacion.ErrorMessage = "El RUT no es valido"
                            CuValidacion.CssClass = "tab_contenido"
                            CuValidacion.ValidationGroup = GroupValidation
                            CuValidacion.EnableClientScript = True
                            CuValidacion.ClientValidationFunction = "RutValidator_ClientValidate"
                            Cell.Controls.Add(CuValidacion)
                        Case "Numeros"
                            CoValidacion = New CompareValidator
                            CoValidacion.ID = "CompareValidator" & arrControl(k)
                            CoValidacion.ControlToValidate = arrControl(k)
                            CoValidacion.Text = "*"
                            CoValidacion.ErrorMessage = arrLabel(k) & " debe ser un valor num�rico"
                            CoValidacion.CssClass = "tab_contenido"
                            CoValidacion.ValidationGroup = GroupValidation
                            CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                            CoValidacion.Type = ValidationDataType.Integer
                            Cell.Controls.Add(CoValidacion)
                        Case "Letras"
                            CoValidacion = New CompareValidator
                            CoValidacion.ID = "CompareValidator" & arrControl(k)
                            CoValidacion.ControlToValidate = arrControl(k)
                            CoValidacion.Text = "*"
                            CoValidacion.ErrorMessage = arrLabel(k) & " debe ser un valor alfanum�rico"
                            CoValidacion.CssClass = "tab_contenido"
                            CoValidacion.ValidationGroup = GroupValidation
                            CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                            CoValidacion.Type = ValidationDataType.String
                            Cell.Controls.Add(CoValidacion)
                        Case "Fecha"
                            CoValidacion = New CompareValidator
                            CoValidacion.ID = "CompareValidator" & arrControl(k)
                            CoValidacion.ControlToValidate = arrControl(k)
                            CoValidacion.Text = "*"
                            CoValidacion.ErrorMessage = arrLabel(k) & " debe ser una fecha valida"
                            CoValidacion.CssClass = "tab_contenido"
                            CoValidacion.ValidationGroup = GroupValidation
                            CoValidacion.Operator = ValidationCompareOperator.DataTypeCheck
                            CoValidacion.Type = ValidationDataType.Date
                            Cell.Controls.Add(CoValidacion)

                    End Select
                    MyTable.Rows.Add(Row)
                Else
                    txtTextBox = New TextBox
                    txtTextBox.ID = arrNodesControl(m)
                    txtTextBox.ClientIDMode = ClientIDMode.Static
                    txtTextBox.CssClass = CssClassControl
                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                    txtTextBox.TextMode = ControlTextMode
                    txtTextBox.ToolTip = ToolTip
                    txtTextBox.Enabled = False
                    txtTextBox.Visible = False
                    MyView.Controls.Add(txtTextBox)
                End If
            Next

            'Linea de Divisi�n
            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Height = "4"
            Cell.ColumnSpan = "2"
            Cell.Controls.Add(New LiteralControl("<hr />"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)

            'Botones del Formulario
            i = 0
            t = Lecturas.LeerButtonFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            Row = New TableRow
            Cell = New TableCell
            Cell.CssClass = CssClassLabel
            Cell.Style(HtmlTextWriterStyle.TextAlign) = EtiquetaAlign
            Cell.Style(HtmlTextWriterStyle.Width) = "20%"
            Row.Cells.Add(Cell)
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.Width) = "80%"
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Button", GroupValidation, NumeroPagina, k + 1)
                Select Case arrControl(k)
                    Case "LoginButton"
                        LoginButton = New Button
                        LoginButton.ID = arrControl(k)
                        LoginButton.CssClass = CssClassControl
                        LoginButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        LoginButton.Text = arrLabel(k)
                        LoginButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            LoginButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler LoginButton.Click, AddressOf RFC_Login
                        Cell.Controls.Add(LoginButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "CancelButton"
                        CancelButton = New Button
                        CancelButton.ID = arrControl(k)
                        CancelButton.CssClass = CssClassControl
                        CancelButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        CancelButton.Text = arrLabel(k)
                        CancelButton.ToolTip = ToolTip
                        'AddHandler CancelButton.Click, AddressOf RFC_Logout
                        Cell.Controls.Add(CancelButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "UpdateButton"
                        UpdateButton = New Button
                        UpdateButton.ID = arrControl(k)
                        UpdateButton.CssClass = CssClassControl
                        UpdateButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        UpdateButton.Text = arrLabel(k)
                        UpdateButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            UpdateButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(UpdateButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "NewButton"
                        NewButton = New Button
                        NewButton.ID = arrControl(k)
                        NewButton.CssClass = CssClassControl
                        NewButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        NewButton.Text = arrLabel(k)
                        NewButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            NewButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(NewButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "SearchButton"
                        SearchButton = New Button
                        SearchButton.ID = arrControl(k)
                        SearchButton.CssClass = CssClassControl
                        SearchButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        SearchButton.Text = arrLabel(k)
                        SearchButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            SearchButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler UpdateButton.Click, AddressOf RFC_Update
                        Cell.Controls.Add(SearchButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "DeleteButton"
                        DeleteButton = New Button
                        DeleteButton.ID = arrControl(k)
                        DeleteButton.CssClass = CssClassControl
                        DeleteButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        DeleteButton.Text = arrLabel(k)
                        DeleteButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            DeleteButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler DeleteButton.Click, AddressOf RFC_Delete
                        Cell.Controls.Add(DeleteButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                    Case "ReturnButton"
                        ReturnButton = New Button
                        ReturnButton.ID = arrControl(k)
                        ReturnButton.CssClass = CssClassControl
                        ReturnButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                        ReturnButton.Text = arrLabel(k)
                        ReturnButton.ToolTip = ToolTip
                        If IsRequiredField Then
                            ReturnButton.ValidationGroup = GroupValidation
                        End If
                        'AddHandler ReturnButton.Click, AddressOf RFC_Return
                        Cell.Controls.Add(ReturnButton)
                        Cell.Controls.Add(New LiteralControl(" "))
                End Select
            Next

            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
            MyView.Controls.Add(MyTable)
        End If
    End Sub

    Public Function SideBarClassName(ByVal MenuOptionsId As Long) As String
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT MenuOptions.SideBarMenu As SideBarMenu "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE MenuOptions.MenuOptionsId = " & MenuOptionsId

        SideBarClassName = ""
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)
            While dtrFunciones.Read
                SideBarClassName = dtrFunciones("SideBarMenu").ToString
            End While
            dtrFunciones.Close()
        Catch
            SideBarClassName = ""
        End Try
    End Function

    Public Function HojaName(ByVal MenuOptionsId As Long) As String
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT MenuOptions.Texto As Texto "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE MenuOptions.MenuOptionsId = " & MenuOptionsId

        HojaName = ""
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)
            While dtrFunciones.Read
                HojaName = dtrFunciones("Texto").ToString
            End While
            dtrFunciones.Close()
        Catch
            HojaName = ""
        End Try
    End Function

    Public Function LoadRaizPorAmbitos(ByVal node As TreeNode) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrPackages As IDataReader
        'Dim dtrPackages As SqlDataReader
        Dim sSQL As String

        sSQL = "SELECT MenuOptions.Texto AS AmbitosName, MenuOptions.MenuOptionsId As AmbitosId FROM MenuOptions WHERE (((MenuOptions.PortalesName)='SGI') AND ((MenuOptions.Zona)='BarMenu')) ORDER BY MenuOptions.Secuencia"
        LoadRaizPorAmbitos = False

        Try
            dtrPackages = AccesoEA.ListarRegistros(sSQL)
            While dtrPackages.Read
                'Dim urlPaginaCargos As String = "AdministradorDeCargos.aspx?id=" & dtrPackages("AmbitosId")
                Dim urlPaginaCargos As String = "javascript:handleGetAmbito('" & dtrPackages("AmbitosName") & "','" & dtrPackages("AmbitosId") & "');"
                Dim newNode As TreeNode = New TreeNode(dtrPackages("AmbitosName"), dtrPackages("AmbitosId"), "", urlPaginaCargos, "")
                newNode.SelectAction = TreeNodeSelectAction.Expand
                newNode.PopulateOnDemand = True
                node.ChildNodes.Add(newNode)
                LoadRaizPorAmbitos = True
            End While
            dtrPackages.Close()
        Catch
            LoadRaizPorAmbitos = False
        End Try

    End Function

    Public Function LoadHojaPorAmbitos(ByVal node As TreeNode) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrPackages As IDataReader
        Dim sSQL As String
        Dim AmbitosId As String = node.Value
        Dim SideBarName As String = ""
        Dim Lecturas As New Lecturas


        'Dim AmbitosId As Integer
        'If ((Not kv.ContainsKey("Ambitos")) Or (Not Int32.TryParse(kv("Ambitos"), AmbitosId))) Then
        'Return Nothing
        'End If
        SideBarName = Lecturas.SideBarClassName(CLng(AmbitosId))
        'Dim carModelAdapter As New dsCarModelsTableAdapters.CarModelsTableAdapter()

        sSQL = "SELECT MenuOptions.Texto AS HojasName, MenuOptions.MenuOptionsId as HojasId FROM MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.SideBarmenu)='" & SideBarName & "') AND ((MenuOptions.IsNodoHoja)='HOJA') AND ((MenuOptions.PortalesName)='SGI') AND ((MenuOptions.Zona)='SideBarMenu')) "
        sSQL = sSQL & "ORDER BY MenuOptions.Texto"


        'sSQL = "SELECT t_object_1.Object_ID AS Numero, t_object_1.Name AS Cargo "
        'sSQL = sSQL & "FROM (t_object INNER JOIN t_connector ON t_object.Object_ID = t_connector.End_Object_ID) INNER JOIN t_object AS t_object_1 ON t_connector.Start_Object_ID = t_object_1.Object_ID "
        'sSQL = sSQL & "WHERE (((t_object_1.Stereotype)<>'Cargo') AND ((t_object.Object_ID)=" & ObjectId & ") AND ((t_connector.Connector_Type)='Dependency'))"
        'sSQL = sSQL & " ORDER BY t_object_1.TPos"

        LoadHojaPorAmbitos = False

        Try
            dtrPackages = AccesoEA.ListarRegistros(sSQL)
            While dtrPackages.Read
                'Dim urlPaginaCargos As String = "CambiarCargoSuperior.aspx?Nuevoid=" & dtrPackages("Numero") & "&NuevoCargo=" & dtrPackages("Cargo")
                Dim urlPaginaCargos As String = "javascript:handleGetHoja('" & dtrPackages("HojasName") & "','" & dtrPackages("HojasId") & "');"
                Dim newNode As TreeNode = New TreeNode(dtrPackages("HojasName"), dtrPackages("HojasId"), "", urlPaginaCargos, "")
                newNode.SelectAction = TreeNodeSelectAction.Expand
                newNode.PopulateOnDemand = True
                node.ChildNodes.Add(newNode)
                LoadHojaPorAmbitos = True
            End While
            dtrPackages.Close()
        Catch
            LoadHojaPorAmbitos = False
        End Try
    End Function
    Public Function LoadDocumentosPorHoja(ByVal node As TreeNode) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrPackages As IDataReader
        Dim sSQL As String
        Dim HojasId As String = node.Value
        Dim HojasName As String = node.Text

        Dim Lecturas As New Lecturas


        'Dim AmbitosId As Integer
        'If ((Not kv.ContainsKey("Ambitos")) Or (Not Int32.TryParse(kv("Ambitos"), AmbitosId))) Then
        'Return Nothing
        'End If
        'HojasName = Lecturas.SideBarClassName(CLng(HojasId))
        'Dim carModelAdapter As New dsCarModelsTableAdapters.CarModelsTableAdapter()

        sSQL = "SELECT APIDocumentosSGI.GruposName + ' - ' + Cstr(APIDocumentosSGI.APIDocumentosSGISecuencia) +  ' - ' + DocumentosSGI.DocumentosSGINombre as DocumentosName, APIDocumentosSGI.APIDocumentosSGIId as DocumentosId "
        sSQL = sSQL & "FROM (APIDocumentosSGI INNER JOIN Grupos ON APIDocumentosSGI.GruposName = Grupos.GruposName) INNER JOIN DocumentosSGI ON APIDocumentosSGI.DocumentosSGICodigo = DocumentosSGI.DocumentosSGICodigo "
        sSQL = sSQL & "WHERE (((APIDocumentosSGI.APIDocumentosSGICodigo)='" & HojasName & "')) "
        sSQL = sSQL & "ORDER BY Grupos.GruposSecuencia, APIDocumentosSGI.APIDocumentosSGISecuencia"

        'sSQL = "SELECT t_object_1.Object_ID AS Numero, t_object_1.Name AS Cargo "
        'sSQL = sSQL & "FROM (t_object INNER JOIN t_connector ON t_object.Object_ID = t_connector.End_Object_ID) INNER JOIN t_object AS t_object_1 ON t_connector.Start_Object_ID = t_object_1.Object_ID "
        'sSQL = sSQL & "WHERE (((t_object_1.Stereotype)<>'Cargo') AND ((t_object.Object_ID)=" & ObjectId & ") AND ((t_connector.Connector_Type)='Dependency'))"
        'sSQL = sSQL & " ORDER BY t_object_1.TPos"

        LoadDocumentosPorHoja = False

        Try
            dtrPackages = AccesoEA.ListarRegistros(sSQL)
            While dtrPackages.Read
                'Dim urlPaginaCargos As String = "CambiarCargoSuperior.aspx?Nuevoid=" & dtrPackages("Numero") & "&NuevoCargo=" & dtrPackages("Cargo")
                Dim urlPaginaCargos As String = "javascript:handleGetDocumento('" & dtrPackages("DocumentosName") & "','" & dtrPackages("DocumentosId") & "');"
                Dim newNode As TreeNode = New TreeNode(dtrPackages("DocumentosName"), dtrPackages("DocumentosId"), "", urlPaginaCargos, "")
                newNode.SelectAction = TreeNodeSelectAction.Expand
                newNode.PopulateOnDemand = True
                node.ChildNodes.Add(newNode)
                LoadDocumentosPorHoja = True
            End While
            dtrPackages.Close()
        Catch
            LoadDocumentosPorHoja = False
        End Try
    End Function
    Public Function LoadMinutasByYear(ByVal node As TreeNode) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrPackages As IDataReader
        Dim sSQL As String
        Dim HojasId As String = node.Value
        Dim HojasName As String = node.Text

        Dim Lecturas As New Lecturas


        'Dim AmbitosId As Integer
        'If ((Not kv.ContainsKey("Ambitos")) Or (Not Int32.TryParse(kv("Ambitos"), AmbitosId))) Then
        'Return Nothing
        'End If
        'HojasName = Lecturas.SideBarClassName(CLng(HojasId))
        'Dim carModelAdapter As New dsCarModelsTableAdapters.CarModelsTableAdapter()

        'sSQL = "SELECT APIDocumentosSGI.GruposName + ' - ' + Cstr(APIDocumentosSGI.APIDocumentosSGISecuencia) +  ' - ' + DocumentosSGI.DocumentosSGINombre as DocumentosName, APIDocumentosSGI.APIDocumentosSGIId as DocumentosId "
        'sSQL = sSQL & "FROM (APIDocumentosSGI INNER JOIN Grupos ON APIDocumentosSGI.GruposName = Grupos.GruposName) INNER JOIN DocumentosSGI ON APIDocumentosSGI.DocumentosSGICodigo = DocumentosSGI.DocumentosSGICodigo "
        'sSQL = sSQL & "WHERE (((APIDocumentosSGI.APIDocumentosSGICodigo)='" & HojasName & "')) "
        'sSQL = sSQL & "ORDER BY Grupos.GruposSecuencia, APIDocumentosSGI.APIDocumentosSGISecuencia"

        'sSQL = "SELECT t_object_1.Object_ID AS Numero, t_object_1.Name AS Cargo "
        'sSQL = sSQL & "FROM (t_object INNER JOIN t_connector ON t_object.Object_ID = t_connector.End_Object_ID) INNER JOIN t_object AS t_object_1 ON t_connector.Start_Object_ID = t_object_1.Object_ID "
        'sSQL = sSQL & "WHERE (((t_object_1.Stereotype)<>'Cargo') AND ((t_object.Object_ID)=" & ObjectId & ") AND ((t_connector.Connector_Type)='Dependency'))"
        'sSQL = sSQL & " ORDER BY t_object_1.TPos"

        LoadMinutasByYear = False

        sSQL = "SELECT DocumentosSGI.[DocumentosSGIId] As Id, DocumentosSGI.DocumentosSGICodigo As Codigo, DocumentosSGI.DocumentosSGINombre as Nombre, 'SGI\' + DocumentosSGI.DocumentosSGIPath As Url, convert(varchar, DocumentosSGI.DocumentosSGIFEmision, 23) As Fecha "
        sSQL = sSQL & "FROM DocumentosSGI "
        sSQL = sSQL & "WHERE (((Mid(DocumentosSGI.DocumentosSGIFEmision,7,4))='" & HojasId & "') AND ((DocumentosSGI.DocumentosSGITipo) = 'Minuta'))"

        Try
            dtrPackages = AccesoEA.ListarRegistros(sSQL)
            While dtrPackages.Read
                'Dim urlPaginaCargos As String = "CambiarCargoSuperior.aspx?Nuevoid=" & dtrPackages("Numero") & "&NuevoCargo=" & dtrPackages("Cargo")
                Dim TituloDocumento As String = "[" & dtrPackages("Fecha") & "] " & dtrPackages("Nombre").ToString
                If Len(TituloDocumento) > 100 Then
                    TituloDocumento = Mid(TituloDocumento, 1, 100) & " ..."
                End If
                Dim newNode As TreeNode = New TreeNode(TituloDocumento, dtrPackages("Codigo"), "img/WebResource.gif", dtrPackages("Url"), "_blank")
                newNode.SelectAction = TreeNodeSelectAction.Expand
                newNode.PopulateOnDemand = True
                node.ChildNodes.Add(newNode)
                LoadMinutasByYear = True
            End While
            dtrPackages.Close()
        Catch
            LoadMinutasByYear = False
        End Try



        Try
            dtrPackages = AccesoEA.ListarRegistros(sSQL)
            While dtrPackages.Read
                'Dim urlPaginaCargos As String = "CambiarCargoSuperior.aspx?Nuevoid=" & dtrPackages("Numero") & "&NuevoCargo=" & dtrPackages("Cargo")
                Dim urlPaginaCargos As String = "javascript:handleGetDocumento('" & dtrPackages("DocumentosName") & "','" & dtrPackages("DocumentosId") & "');"
                Dim newNode As TreeNode = New TreeNode(dtrPackages("DocumentosName"), dtrPackages("DocumentosId"), "", urlPaginaCargos, "")
                newNode.SelectAction = TreeNodeSelectAction.Expand
                newNode.PopulateOnDemand = True
                node.ChildNodes.Add(newNode)
                LoadMinutasByYear = True
            End While
            dtrPackages.Close()
        Catch
            LoadMinutasByYear = False
        End Try
    End Function
    Public Function LoadGruposPorHoja(ByVal node As TreeNode) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrPackages As IDataReader
        Dim sSQL As String
        Dim HojasId As String = node.Value
        Dim HojasName As String = node.Text

        Dim Lecturas As New Lecturas


        'Dim AmbitosId As Integer
        'If ((Not kv.ContainsKey("Ambitos")) Or (Not Int32.TryParse(kv("Ambitos"), AmbitosId))) Then
        'Return Nothing
        'End If
        'HojasName = Lecturas.SideBarClassName(CLng(HojasId))
        'Dim carModelAdapter As New dsCarModelsTableAdapters.CarModelsTableAdapter()

        sSQL = "SELECT DISTINCT APIDocumentosSGI.GruposName AS GruposName, APIDocumentosSGI.GruposSecuencia "
        sSQL = sSQL & "FROM APIDocumentosSGI "
        sSQL = sSQL & "WHERE(((APIDocumentosSGI.APIDocumentosSGICodigo) = '" & HojasName & "')) "
        sSQL = sSQL & "GROUP BY APIDocumentosSGI.GruposName, APIDocumentosSGI.GruposSecuencia, APIDocumentosSGI.GruposSecuencia "
        sSQL = sSQL & "ORDER BY APIDocumentosSGI.GruposSecuencia"

        'sSQL = "SELECT APIDocumentosSGI.GruposName + ' - ' + Cstr(APIDocumentosSGI.APIDocumentosSGISecuencia) +  ' - ' + DocumentosSGI.DocumentosSGINombre as DocumentosName, APIDocumentosSGI.APIDocumentosSGIId as DocumentosId "
        'sSQL = sSQL & "FROM (APIDocumentosSGI INNER JOIN Grupos ON APIDocumentosSGI.GruposName = Grupos.GruposName) INNER JOIN DocumentosSGI ON APIDocumentosSGI.DocumentosSGICodigo = DocumentosSGI.DocumentosSGICodigo "
        'sSQL = sSQL & "WHERE (((APIDocumentosSGI.APIDocumentosSGICodigo)='" & HojasName & "')) "
        'sSQL = sSQL & "ORDER BY Grupos.GruposSecuencia, APIDocumentosSGI.APIDocumentosSGISecuencia"

        'sSQL = "SELECT t_object_1.Object_ID AS Numero, t_object_1.Name AS Cargo "
        'sSQL = sSQL & "FROM (t_object INNER JOIN t_connector ON t_object.Object_ID = t_connector.End_Object_ID) INNER JOIN t_object AS t_object_1 ON t_connector.Start_Object_ID = t_object_1.Object_ID "
        'sSQL = sSQL & "WHERE (((t_object_1.Stereotype)<>'Cargo') AND ((t_object.Object_ID)=" & ObjectId & ") AND ((t_connector.Connector_Type)='Dependency'))"
        'sSQL = sSQL & " ORDER BY t_object_1.TPos"

        LoadGruposPorHoja = False

        Try
            dtrPackages = AccesoEA.ListarRegistros(sSQL)
            While dtrPackages.Read
                'Dim urlPaginaCargos As String = "CambiarCargoSuperior.aspx?Nuevoid=" & dtrPackages("Numero") & "&NuevoCargo=" & dtrPackages("Cargo")
                Dim urlPaginaCargos As String = "javascript:handleGetGrupos('" & dtrPackages("GruposName") & "','" & dtrPackages("GruposSecuencia") & "');"
                Dim newNode As TreeNode = New TreeNode(dtrPackages("GruposName"), dtrPackages("GruposSecuencia"), "", urlPaginaCargos, "")
                newNode.SelectAction = TreeNodeSelectAction.Expand
                newNode.PopulateOnDemand = True
                node.ChildNodes.Add(newNode)
                LoadGruposPorHoja = True
            End While
            dtrPackages.Close()
        Catch
            LoadGruposPorHoja = False
        End Try
    End Function
    Public Function LeerGruposSecuenciaByGroupName(ByVal GruposName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Grupos.GruposSecuencia "
        sSQL = sSQL & "FROM Grupos "
        sSQL = sSQL & "WHERE ((Grupos.GruposName) = '" & GruposName & "')"
        LeerGruposSecuenciaByGroupName = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                LeerGruposSecuenciaByGroupName = CLng(dtr("GruposSecuencia").ToString)
            End While
            dtr.Close()
        Catch
            LeerGruposSecuenciaByGroupName = 0
        End Try
    End Function
    Public Function LeerTipoDocYSecuencia(ByVal CodigoSGI As String, ByRef GruposName As String, ByRef GruposSecuencia As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        LeerTipoDocYSecuencia = False

        sSQL = "SELECT DocumentosSGI.DocumentosSGITipo as Grupo, TipoDoc.TipoDocSecuencia as Secuencia "
        sSQL = sSQL & "FROM DocumentosSGI INNER JOIN TipoDoc ON DocumentosSGI.DocumentosSGITipo = TipoDoc.TipoDocName "
        sSQL = sSQL & "WHERE (((DocumentosSGI.[DocumentosSGICodigo])='" & CodigoSGI & "'))"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                GruposName = dtr("Grupo").ToString
                GruposSecuencia = dtr("Secuencia").ToString
            End While
            LeerTipoDocYSecuencia = True
            dtr.Close()
        Catch
            LeerTipoDocYSecuencia = False
        End Try
    End Function

    Public Sub CreatePerfil(ByVal NumeroPagina As Long, ByVal MasterName As String, ByVal MasterId As Long, ByRef MyTable As Table, ByVal FilterField As String, ByVal sSQLWhere As String, ByVal sSQLOrder As String, ByVal PaginaWebName As String, ByVal MenuOptionsId As Long, ByVal RolId As Long, ByVal TablaName As String, ByVal UserId As Long)
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim m As Integer = 0
        Dim n As Integer = 0
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim arrLabel(100) As String
        Dim arrControl(100) As String
        Dim arrGrillaLabel(100) As String
        Dim arrGrillaControl(100) As String
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
        Dim Url As String = ""
        Dim FormularioWebPId As Long = 0
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim sqlSource As SqlDataSource


        Dim TC As TabContainer
        Dim TP As TabPanel
        Dim Tabla As Table
        Dim Fila As TableRow
        Dim Celda As TableCell
        Dim PanelScroll As Panel

        Dim Grilla As GridView
        Dim sSQL As String = ""
        Dim HTMLCode As String = ""
        Dim HyperColumnGrid As HyperLinkField
        Dim ItemTempColumnGrid As TemplateField


        Dim GroupValidation As String = ""

        i = 0
        t = Lecturas.LeerTabsFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        If i > 0 Then  'P�gina posee tabs
            'Linea de Divisi�n
            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Height = "4"
            Cell.ColumnSpan = "2"
            Cell.Controls.Add(New LiteralControl("<hr />"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)

            Row = New TableRow
            Cell = New TableCell
            Cell.ColumnSpan = "2"

            'Crea el Tab Container
            TC = New TabContainer
            TC.ID = "DynamicTab" & NumeroPagina & i
            TC.ClientIDMode = UI.ClientIDMode.Static
            'TC.Height = "250"
            TC.OnClientActiveTabChanged = "ActiveTabChanged"
            ' Primer Tab Panel: Con k corren los paneles                                  

            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Tabs", GroupValidation, NumeroPagina, k + 1)
                t = Lecturas.LeerIdFormularioWeb(FormularioWebPId, "Tabs", NumeroPagina, k + 1, Pagina, NombrePagina)

                TP = New TabPanel
                TP.ID = "TabPanel" & arrControl(k)
                TP.ClientIDMode = UI.ClientIDMode.Static
                TP.HeaderText = arrLabel(k)
                TP.CssClass = "tab_contenido"
                'Agrega el contenedor
                TP.Controls.Add(New LiteralControl("<contenttemplate>"))

                Tabla = New Table
                Tabla.ID = "Tabla" & arrControl(k)
                Tabla.ClientIDMode = UI.ClientIDMode.Static
                Tabla.CellSpacing = "2"
                Tabla.CellPadding = "2"

                'Titulo
                Fila = New TableRow
                Celda = New TableCell
                Celda.CssClass = "subtit"
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "left"
                Celda.ColumnSpan = "2"
                Celda.Controls.Add(New LiteralControl(" " & arrLabel(k)))
                Fila.Cells.Add(Celda)
                Tabla.Rows.Add(Fila)

                'Linea de Divisi�n
                Fila = New TableRow
                Celda = New TableCell
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "left"
                Celda.Height = "4"
                Celda.ColumnSpan = "2"
                Celda.Controls.Add(New LiteralControl("<hr />"))
                Fila.Cells.Add(Celda)
                Tabla.Rows.Add(Fila)

                'Descripci�n
                Fila = New TableRow
                Celda = New TableCell
                Celda.CssClass = "tab_contenido"
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "left"
                Celda.ColumnSpan = "2"
                Celda.Controls.Add(New LiteralControl(ToolTip))
                Fila.Cells.Add(Celda)
                Tabla.Rows.Add(Fila)

                'Linea de Divisi�n
                Fila = New TableRow
                Celda = New TableCell
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "left"
                Celda.Height = "4"
                Celda.ColumnSpan = "2"
                Celda.Controls.Add(New LiteralControl("<hr />"))
                Fila.Cells.Add(Celda)
                Tabla.Rows.Add(Fila)

                'Linea para incorporar el link para agregar un elemento a la lista.
                'Dim linkAgregar As String = Pagina & "?PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & MasterName & "&MasterId=" & MasterId

                Fila = New TableRow
                Celda = New TableCell
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "left"
                Celda.Height = "4"
                Celda.ColumnSpan = "2"

                'Aqu� vamos a poner la grilla de datos asociada a cada tabs

                'Columnas del Formulario
                n = 0
                t = Lecturas.LeerTabsColumnsFormularioWeb(arrGrillaLabel, arrGrillaControl, FormularioWebPId, n)

                PanelScroll = New Panel
                PanelScroll.ID = "panel" & arrLabel(k)
                PanelScroll.ClientIDMode = UI.ClientIDMode.Static
                PanelScroll.ScrollBars = ScrollBars.Auto
                'PanelScroll.Height = "150"


                Grilla = New GridView
                Grilla.ID = "grid" & arrLabel(k)
                Grilla.DataSourceID = "ds" & arrLabel(k)
                Grilla.DataKeyNames = New String(0) {"Id"}
                Grilla.HeaderStyle.CssClass = "grilla_top"
                Grilla.RowStyle.CssClass = "grilla_Fila1"
                Grilla.AlternatingRowStyle.CssClass = "grilla_Fila2"

                Grilla.Width = "660"
                Grilla.AllowPaging = False
                Grilla.AllowSorting = False
                'Grilla.PageSize = 8
                Grilla.AutoGenerateColumns = False

                For m = 0 To n - 1
                    t = Lecturas.LeerTabColumnFormularioWeb(TipoControl, EtiquetaAlign, ControlWidth, ToolTip, SelectCommand, "Grilla", FormularioWebPId, m + 1)
                    Select Case TipoControl
                        Case "HyperLinkField"
                            HyperColumnGrid = New HyperLinkField
                            HyperColumnGrid.DataTextField = arrGrillaControl(m)
                            HyperColumnGrid.ShowHeader = True
                            HyperColumnGrid.HeaderText = arrGrillaLabel(m)
                            HyperColumnGrid.DataNavigateUrlFields = New String(0) {arrGrillaControl(m)}
                            HyperColumnGrid.DataNavigateUrlFormatString = SelectCommand & "&MasterName=" & MasterName & "&MasterId=" & MasterId
                            HyperColumnGrid.Visible = False
                            Grilla.Columns.Add(HyperColumnGrid)
                            ItemTempColumnGrid = New TemplateField
                            ItemTempColumnGrid.ShowHeader = True
                            'ItemTempColumnGrid.HeaderText = arrLabel(k)
                            ItemTempColumnGrid.HeaderImageUrl = "img/botones/i_solicitar.gif"
                            ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                            ItemTempColumnGrid.ItemTemplate = New PlantillaCheckBoxGrilla(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)}, RolId, TablaName, "", UserId)
                            ItemTempColumnGrid.Visible = True
                            ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                            Grilla.Columns.Add(ItemTempColumnGrid)

                        Case "DownLoadField"
                            HyperColumnGrid = New HyperLinkField
                            HyperColumnGrid.DataTextField = "T�tulo"
                            HyperColumnGrid.ShowHeader = True
                            HyperColumnGrid.HeaderText = arrGrillaLabel(m)
                            HyperColumnGrid.DataNavigateUrlFields = New String(0) {"Url"}
                            HyperColumnGrid.Target = "_blank"
                            'HyperColumnGrid.ItemStyle.Width = ControlWidth
                            HyperColumnGrid.ItemStyle.HorizontalAlign = 1
                            'HyperColumnGrid.DataNavigateUrlFormatString = {0}
                            Grilla.Columns.Add(HyperColumnGrid)

                        Case "TemplateField"
                            ItemTempColumnGrid = New TemplateField
                            ItemTempColumnGrid.ShowHeader = True
                            ItemTempColumnGrid.HeaderText = arrGrillaLabel(m)
                            ItemTempColumnGrid.ItemTemplate = New PlantillaGrilla(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)})
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

                PanelScroll.Controls.Add(Grilla)
                Celda.Controls.Add(PanelScroll)
                Fila.Cells.Add(Celda)
                Tabla.Rows.Add(Fila)

                Fila = New TableRow
                Celda = New TableCell
                Celda.CssClass = "txt_label"
                Celda.ColumnSpan = "2"
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "right"


                sqlSource  = New SqlDataSource()                    
                sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                sqlSource.SelectCommand = SelectCommand

                sqlSource.ID = "ds" & arrLabel(k)

                t = Lecturas.LeerTabSQLStatementFormularioWeb("SQLSelect", DataFile, SelectCommand, FormularioWebPId)

                'sqlSource.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\BDCAS.mdb"
                'sqlSource.DataFile = DataFile
                sSQL = SelectCommand & " " & FilterField & " = '" & MasterName & "'"

                If Len(sSQLWhere) > 0 Then
                    sSQL = sSQL & sSQLWhere
                End If
                sqlSource.SelectCommand = sSQL
                If arrControl(k) = "tabSideBarMenu" Then
                    sSQL = sSQL & " Order by MenuOptions.SideBarMenu, MenuOptions.Texto"
                End If
                'If Len(sSQLOrder) > 0 Then
                'sSQL = sSQL & sSQLOrder
                'End If
                sqlSource.SelectCommand = sSQL

                Celda.Controls.Add(sqlSource)
                Fila.Cells.Add(Celda)

                Tabla.Rows.Add(Fila)



                TP.Controls.Add(Tabla)
                TP.Controls.Add(New LiteralControl("</contenttemplate>"))
                TC.Controls.Add(TP)
            Next
            Cell.Controls.Add(TC)
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
        End If



    End Sub
    Public Function GenerarJScriptBad(ByVal Control As String, ByVal Tabla As String) As String
        Dim js As String
        GenerarJScriptBad = ""
        'No usar

        Try

            'js = "<span id=""message" & Control & "" & "></span>" & vbCrLf
            js = "<script language=""JavaScript"" type=""text/JavaScript"">" & vbCrLf
            js = js & "<!-- " & vbCrLf
            js = js & "/* Function to detect pop up is closed and take actions */" & vbCrLf
            js = js & "function checkPopUpClosed" & Control & "(win) {" & vbCrLf
            js = js & "     var timer = setInterval(function() {" & vbCrLf
            'js = js & "         if(win.closed) {" & vbCrLf
            js = js & "         if(true) {" & vbCrLf
            js = js & "             clearInterval(timer);" & vbCrLf
            js = js & "             alert('�detecto cierre de la ventana modal!');" & vbCrLf
            js = js & "             window.addEventListener(""Unlistener"",receiveMessage" & Control & "(),false);" & vbCrLf
            '----------------------

            '-----------------------
            js = js & "         }" & vbCrLf
            js = js & "     }, 1000);" & vbCrLf
            js = js & " }" & vbCrLf
            js = js & "/* Function to receive the postmessage from modal window. */" & vbCrLf
            js = js & "function receiveMessage" & Control & "(win) { " & vbCrLf
            js = js & "     alert(""Estoy en el listener"");" & vbCrLf
            js = js & "     var vals = win.data;" & vbCrLf
            js = js & "     if (vals != null) {" & vbCrLf
            js = js & "         if (vals[0] == ""No selecciono un elemento"") {" & vbCrLf
            js = js & "             alert('�debe seleccionar un elemento v�lido!'); }" & vbCrLf
            js = js & "         else {" & vbCrLf
            js = js & "             $get(""" & Control & """).value = vals[1];" & vbCrLf
            js = js & "             $get(""" & Control & "Description"").value = vals[0];" & vbCrLf
            js = js & "         }" & vbCrLf
            js = js & "     }" & vbCrLf
            js = js & "     else {" & vbCrLf
            'js = js & "         alert('Llega sin un valor');" & vbCrLf
            js = js & "         win.focus();" & vbCrLf
            js = js & "     }" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "/* Instruction to declare the event listener. */" & vbCrLf
            'js = js & "window.addEventListener(""message" & Control & """,receiveMessage" & Control & ",false);" & vbCrLf
            'js = js & "window.addEventListener(""Unlistener"",receiveMessage" & Control & ",false);" & vbCrLf
            'js = js & "window.addEventListener(""Unlistener"",receiveMessage" & Control & "(),false);" & vbCrLf
            js = js & "<!-- " & vbCrLf
            js = js & "function verModal" & Control & "(urlName) { " & vbCrLf
            'js = js & "var vals;" & vbCrLf
            '----- 26-06-2022 -----
            js = js & "var mywindow = window.open(urlName,""mywindow"",""location=1, status=1, scrollbars=1,resizable=1,width=880,height=480"");" & vbCrLf
            js = js & "mywindow.focus();" & vbCrLf
            js = js & "window.addEventListener(""Unlistener"",receiveMessage" & Control & "(mywindow),false);" & vbCrLf

            'js = js & "checkPopUpClosed" & Control & "(mywindow);" & vbCrLf

            '-----------------
            js = js & "}" & vbCrLf
            js = js & "function OnTimeOut(arg) {" & vbCrLf
            js = js & "alert(""TimeOut al invocar el servicio"");" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "function OnError(arg) {" & vbCrLf
            js = js & "alert(""Error encontrado al invocar el servicio"");" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "function btnHelp" & Control & "_onclick() {" & vbCrLf
            js = js & "ret = SimpleService.DescriptorCodigo($get(""" & Control & """).value, """ & Tabla & """, OnCompletebtnHelp" & Control & ", OnTimeOut, OnError);" & vbCrLf
            js = js & "return (true);" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "function OnCompletebtnHelp" & Control & "(arg) {" & vbCrLf
            js = js & "$get(""" & Control & "Description"").value = arg" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "// -->" & vbCrLf
            js = js & "</script>"
            GenerarJScriptBad = js

        Catch ex As Exception
            GenerarJScriptBad = ""

        End Try


    End Function
    Public Function GenerarJScript(ByVal Control As String, ByVal Tabla As String) As String
        Dim js As String
        GenerarJScript = ""


        Try


            js = "<script language=""JavaScript"" type=""text/JavaScript"">" & vbCrLf
            js = js & "<!-- " & vbCrLf
            js = js & "function verModal" & Control & "(urlName) { " & vbCrLf
            js = js & "var vals;" & vbCrLf
            js = js & "vals = window.showModalDialog(urlName);" & vbCrLf
            js = js & "if (vals != null) {" & vbCrLf
            js = js & "if (vals[0] == ""No selecciono un elemento"") {" & vbCrLf
            js = js & "alert('�debe seleccionar un elemento v�lido!'); }" & vbCrLf
            js = js & "else {" & vbCrLf
            js = js & "$get(""" & Control & """).value = vals[1];" & vbCrLf
            js = js & "$get(""" & Control & "Description"").value = vals[0];" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "function OnTimeOut(arg) {" & vbCrLf
            js = js & "alert(""TimeOut al invocar el servicio"");" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "function OnError(arg) {" & vbCrLf
            js = js & "alert(""Error encontrado al invocar el servicio"");" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "function btnHelp" & Control & "_onclick() {" & vbCrLf
            js = js & "ret = SimpleService.DescriptorCodigo($get(""" & Control & """).value, """ & Tabla & """, OnCompletebtnHelp" & Control & ", OnTimeOut, OnError);" & vbCrLf
            js = js & "return (true);" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "function OnCompletebtnHelp" & Control & "(arg) {" & vbCrLf
            js = js & "$get(""" & Control & "Description"").value = arg" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "// -->" & vbCrLf
            js = js & "</script>"
            GenerarJScript = js

        Catch ex As Exception
            GenerarJScript = ""

        End Try


    End Function

    Public Function GenerarJScriptOnlyDescription(ByVal Control As String, ByVal Tabla As String) As String
        Dim js As String
        GenerarJScriptOnlyDescription = ""


        Try


            js = "<script language=""JavaScript"" type=""text/JavaScript"">" & vbCrLf
            js = js & "<!-- " & vbCrLf
            js = js & "function OnTimeOut(arg) {" & vbCrLf
            js = js & "alert(""TimeOut al invocar el servicio"");" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "function OnError(arg) {" & vbCrLf
            js = js & "alert(""Error encontrado al invocar el servicio"");" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "function btnHelp" & Control & "_onclick() {" & vbCrLf
            js = js & "ret = SimpleService.DescriptorCodigo($get(""" & Control & """).value, """ & Tabla & """, OnCompletebtnHelp" & Control & ", OnTimeOut, OnError);" & vbCrLf
            js = js & "return (true);" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "function OnCompletebtnHelp" & Control & "(arg) {" & vbCrLf
            js = js & "$get(""" & Control & "Description"").value = arg" & vbCrLf
            js = js & "}" & vbCrLf
            js = js & "// -->" & vbCrLf
            js = js & "</script>"
            GenerarJScriptOnlyDescription = js

        Catch ex As Exception
            GenerarJScriptOnlyDescription = ""

        End Try


    End Function
    Public Function LoadModalList(ByVal node As TreeNode, ByVal Tabla As String, Optional ByVal TareasCodigo As String = "") As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrPackages As IDataReader
        'Dim dtrPackages As SqlDataReader
        Dim sSQL As String = ""
        Dim Codigo As String = ""
        Dim Nombre As String = ""

        Select Case Tabla
            Case "Moneda", "TipoDoc", "Areas", "EstadoTareas", "Roles", "DocumentosSGI", "Usuarios", "TipoProceso", "Juzgados", "BancoPrestamista", "TipoCredito", "StakeholdersTipoDirecciones", "PaginaWeb", "ClaseProceso"
                Select Case Tabla
                    Case "Roles"
                        sSQL = "SELECT " & Tabla & ".RolName as Codigo, " & Tabla & ".RolDescription as Nombre FROM " & Tabla & " ORDER BY RolName"
                    Case "DocumentosSGI"
                        sSQL = "SELECT " & Tabla & "." & Tabla & "Codigo as Codigo, " & Tabla & "." & Tabla & "Nombre as Nombre FROM " & Tabla & " WHERE DocumentosSGITipo = ""Formulario"" ORDER BY " & Tabla & "Codigo"
                    Case "TipoProceso"
                        sSQL = "SELECT " & Tabla & "." & Tabla & "Name as Codigo, " & Tabla & "." & Tabla & "Description as Nombre FROM " & Tabla & " WHERE IsActivo = ""SI"" ORDER BY " & Tabla & "Name"
                    Case "Moneda", "TipoDoc", "Areas", "EstadoTareas", "Juzgados", "BancoPrestamista", "TipoCredito", "StakeholdersTipoDirecciones", "PaginaWeb", "ClaseProceso"
                        sSQL = "SELECT " & Tabla & "." & Tabla & "Name as Codigo, " & Tabla & "." & Tabla & "Description as Nombre FROM " & Tabla & " ORDER BY " & Tabla & "Name"
                    Case "Usuarios"
                        sSQL = "SELECT " & Tabla & "." & Tabla & "Codigo as Codigo, " & Tabla & "." & Tabla & "Name as Nombre FROM " & Tabla & " WHERE " & Tabla & ".UsuariosEstado = 'Activo' ORDER BY " & Tabla & "Codigo"
                End Select
            Case Else
                sSQL = "SELECT " & Tabla & "." & Tabla & "Codigo as Codigo, " & Tabla & "." & Tabla & "Name as Nombre FROM " & Tabla & " ORDER BY " & Tabla & "Codigo"
        End Select

        LoadModalList = False

        Try
            dtrPackages = AccesoEA.ListarRegistros(sSQL)
            While dtrPackages.Read
                If (Not IsDBNull(dtrPackages("Nombre")) And Not IsDBNull(dtrPackages("Codigo"))) Then
                    'Dim urlPaginaCargos As String = "AdministradorDeCargos.aspx?id=" & dtrPackages("AmbitosId")
                    Dim urlPaginaCargos As String = "javascript:handleGetDocumentoFromModalList('" & dtrPackages("Nombre") & "','" & dtrPackages("Codigo") & "');"
                    Dim newNode As TreeNode = New TreeNode(dtrPackages("Codigo") & " - " & dtrPackages("Nombre"), dtrPackages("Codigo"), "", urlPaginaCargos, "")
                    newNode.SelectAction = TreeNodeSelectAction.Expand
                    newNode.PopulateOnDemand = True
                    node.ChildNodes.Add(newNode)
                    LoadModalList = True
                End If
            End While
            dtrPackages.Close()
        Catch
            LoadModalList = False
        End Try

    End Function
    Function NombreMesCorto(ByVal Mes As Long) As String
        NombreMesCorto = ""
        Select Case Mes
            Case 1
                NombreMesCorto = "Ene"
            Case 2
                NombreMesCorto = "Feb"
            Case 3
                NombreMesCorto = "Mar"
            Case 4
                NombreMesCorto = "Abr"
            Case 5
                NombreMesCorto = "May"
            Case 6
                NombreMesCorto = "Jun"
            Case 7
                NombreMesCorto = "Jul"
            Case 8
                NombreMesCorto = "Ago"
            Case 9
                NombreMesCorto = "Sep"
            Case 10
                NombreMesCorto = "Oct"
            Case 11
                NombreMesCorto = "Nov"
            Case 12
                NombreMesCorto = "Dic"
        End Select
    End Function
    Function NumeroMesCorto(ByVal Mes As String) As Long
        NumeroMesCorto = ""
        Select Case Mes
            Case "Ene"
                NumeroMesCorto = 1
            Case "Feb"
                NumeroMesCorto = 2
            Case "Mar"
                NumeroMesCorto = 3
            Case "Abr"
                NumeroMesCorto = 4
            Case "May"
                NumeroMesCorto = 5
            Case "Jun"
                NumeroMesCorto = 6
            Case "Jul"
                NumeroMesCorto = 7
            Case "Ago"
                NumeroMesCorto = 8
            Case "Sep"
                NumeroMesCorto = 9
            Case "Oct"
                NumeroMesCorto = 10
            Case "Nov"
                NumeroMesCorto = 11
            Case "Dic"
                NumeroMesCorto = 12
        End Select
    End Function
    Function NombreMes(ByVal Mes As Long) As String
        NombreMes = ""
        Select Case Mes
            Case 1
                NombreMes = "enero"
            Case 2
                NombreMes = "febrero"
            Case 3
                NombreMes = "marzo"
            Case 4
                NombreMes = "abril"
            Case 5
                NombreMes = "mayo"
            Case 6
                NombreMes = "junio"
            Case 7
                NombreMes = "julio"
            Case 8
                NombreMes = "agosto"
            Case 9
                NombreMes = "septiembre"
            Case 10
                NombreMes = "octubre"
            Case 11
                NombreMes = "noviembre"
            Case 12
                NombreMes = "diciembre"
        End Select
    End Function
    Function NumeroMes(ByVal Mes As String) As Long
        NumeroMes = ""
        Select Case Mes
            Case "Enero"
                NumeroMes = 1
            Case "Febrero"
                NumeroMes = 2
            Case "Marzo"
                NumeroMes = 3
            Case "Abril"
                NumeroMes = 4
            Case "Mayo"
                NumeroMes = 5
            Case "Junio"
                NumeroMes = 6
            Case "Julio"
                NumeroMes = 7
            Case "Agosto"
                NumeroMes = 8
            Case "Septiembre"
                NumeroMes = 9
            Case "Octubre"
                NumeroMes = 10
            Case "Noviembre"
                NumeroMes = 11
            Case "Diciembre"
                NumeroMes = 12
        End Select
    End Function
    Function FechaEscrita(Fecha As Date) As String
        Dim Lecturas As New Lecturas

        Try
            FechaEscrita = CType(Fecha, Date).Day & " de " & Lecturas.NombreMes(CLng(CType(Fecha, Date).Month)) & " del a�o " & CType(Fecha, Date).Year
        Catch ex As Exception
            FechaEscrita = ""
        End Try
    End Function
    Public Sub CrearFormularioFecha(ByVal TituloPagina As String, ByRef MyTable As Table, ByRef LoginButton As Button)
        Dim Row As TableRow
        Dim Cell As TableCell

        Dim txtTextBox As TextBox
        Dim txtCalendar As CalendarExtender
        Dim ImgImages As Image

        'Titulo
        Row = New TableRow
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        Cell.ColumnSpan = "2"
        Cell.Controls.Add(New LiteralControl("<h1>" & TituloPagina & "</h1>"))
        Row.Cells.Add(Cell)
        MyTable.Rows.Add(Row)

        'Controles del Formulario Web, solo una textbox de fecha
        Row = New TableRow
        Row.VerticalAlign = VerticalAlign.Middle
        Cell = New TableCell
        Cell.CssClass = "textocontgris10bold"
        Cell.Style(HtmlTextWriterStyle.TextAlign) = "right"
        Cell.Style(HtmlTextWriterStyle.Width) = "20%"
        Cell.Style(HtmlTextWriterStyle.Height) = "50"
        Cell.Controls.Add(New LiteralControl("Fecha" & " : "))
        Row.Cells.Add(Cell)
        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.Width) = "80%"
        Cell.VerticalAlign = VerticalAlign.Middle
        txtTextBox = New TextBox
        txtTextBox.ID = "txtFecha"
        txtTextBox.ClientIDMode = ClientIDMode.Static
        txtTextBox.CssClass = "textoboxgris"
        txtTextBox.Style(HtmlTextWriterStyle.Width) = "70px"
        txtTextBox.TextMode = "0"
        txtTextBox.ToolTip = "Indique la fecha del informe"
        Cell.Controls.Add(txtTextBox)
        Cell.Controls.Add(New LiteralControl(" "))
        ImgImages = New Image
        ImgImages.ID = "Image" & "txtFecha"
        ImgImages.ClientIDMode = UI.ClientIDMode.Static
        ImgImages.ImageUrl = "img/Calendar_scheduleHS.png"
        ImgImages.ImageAlign = ImageAlign.Middle
        Cell.Controls.Add(ImgImages)
        txtCalendar = New CalendarExtender
        txtCalendar.ID = "Calendar" & "txtFecha"
        txtCalendar.ClientIDMode = UI.ClientIDMode.Static
        txtCalendar.TargetControlID = "txtFecha"
        txtCalendar.PopupButtonID = "Image" & "txtFecha"
        txtCalendar.Format = "dd/MM/yy"
        Cell.Controls.Add(txtCalendar)
        '
        Cell.Controls.Add(New LiteralControl(" "))
        LoginButton = New Button
        LoginButton.ID = "LoginButton"
        LoginButton.CssClass = "boxceleste"
        LoginButton.Style(HtmlTextWriterStyle.Width) = "70px"
        LoginButton.Text = "Aceptar"
        LoginButton.ToolTip = "De un click de mousse para emitir el informe"
        Cell.Controls.Add(LoginButton)



        Row.Cells.Add(Cell)


        MyTable.Rows.Add(Row)
        


        'Botones del Formulario. Solo bot�n Login
        'Row = New TableRow
        'Cell = New TableCell
        'Cell.CssClass = "textocontgris10bold"
        'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
        'Cell.Style(HtmlTextWriterStyle.Width) = "20%"
        'Row.Cells.Add(Cell)
        'Cell = New TableCell
        'Cell.Style(HtmlTextWriterStyle.Width) = "80%"
        'LoginButton = New Button
        'LoginButton.ID = "LoginButton"
        'LoginButton.CssClass = "boxceleste"
        'LoginButton.Style(HtmlTextWriterStyle.Width) = "70px"
        'LoginButton.Text = "Aceptar"
        'LoginButton.ToolTip = "De un click de mousse para emitir el informe"
        'Cell.Controls.Add(LoginButton)
        'Cell.Controls.Add(New LiteralControl(" "))

        'Row.Cells.Add(Cell)
        'MyTable.Rows.Add(Row)
    End Sub
    Public Sub CrearCheckComentarios(ByRef MyTable As Table)
        Dim Row As TableRow
        Dim Cell As TableCell

        Dim txtTextBox As TextBox
        Dim txtCalendar As CalendarExtender
        Dim ImgImages As Image
        Dim txtCheckBox As CheckBox

        'Controles del Formulario Web, solo una textbox de fecha
        Row = New TableRow
        Row.VerticalAlign = VerticalAlign.Middle

        Cell = New TableCell
        Cell.Style(HtmlTextWriterStyle.Width) = "100%"
        Cell.VerticalAlign = VerticalAlign.Middle
        txtCheckBox = New CheckBox
        txtCheckBox.ID = "chkCorreo"
        txtCheckBox.ClientIDMode = ClientIDMode.Static
        txtCheckBox.ToolTip = "De un click de mousse para solicitar el envio de correo al responsable de la tarea"
        txtCheckBox.Text = "Enviar Correo"
        Cell.Controls.Add(txtCheckBox)
        Cell.Controls.Add(New LiteralControl(" "))

        txtCheckBox = New CheckBox
        txtCheckBox.ID = "chkMuro"
        txtCheckBox.ClientIDMode = ClientIDMode.Static
        txtCheckBox.ToolTip = "De un click de mousse para solicitar el registro del mensaje en el muro"
        txtCheckBox.Text = "Publicar en Muro"
        Cell.Controls.Add(txtCheckBox)
        Cell.Controls.Add(New LiteralControl(" "))

        txtCheckBox = New CheckBox
        txtCheckBox.ID = "chkCritica"
        txtCheckBox.ClientIDMode = ClientIDMode.Static
        txtCheckBox.ToolTip = "De un click de mousse para solicitar el registro de un mensaje de fecha cr�tica en el muro"
        txtCheckBox.Text = "Alerta Fecha Cr�tica"
        Cell.Controls.Add(txtCheckBox)
        Cell.Controls.Add(New LiteralControl(" "))

        txtTextBox = New TextBox
        txtTextBox.ID = "txtFecha"
        txtTextBox.ClientIDMode = ClientIDMode.Static
        txtTextBox.CssClass = "textoboxgris"
        txtTextBox.Style(HtmlTextWriterStyle.Width) = "70px"
        txtTextBox.TextMode = "0"
        txtTextBox.ToolTip = "Indique la fecha del informe"
        Cell.Controls.Add(txtTextBox)
        Cell.Controls.Add(New LiteralControl(" "))

        ImgImages = New Image
        ImgImages.ID = "Image" & "txtFecha"
        ImgImages.ClientIDMode = UI.ClientIDMode.Static
        ImgImages.ImageUrl = "img/Calendar_scheduleHS.png"
        ImgImages.ImageAlign = ImageAlign.Middle
        Cell.Controls.Add(ImgImages)

        txtCalendar = New CalendarExtender
        txtCalendar.ID = "Calendar" & "txtFecha"
        txtCalendar.ClientIDMode = UI.ClientIDMode.Static
        txtCalendar.TargetControlID = "txtFecha"
        txtCalendar.PopupButtonID = "Image" & "txtFecha"
        txtCalendar.Format = "dd/MM/yy"
        Cell.Controls.Add(txtCalendar)
        '
        Row.Cells.Add(Cell)

        MyTable.Rows.Add(Row)

    End Sub

    Public Sub CrearNewVista(ByVal NumeroPagina As Integer, ByVal TituloPagina As String, ByRef MyView As PlaceHolder, Optional ByVal UsuariosId As Long = 0, Optional ByVal ConTitulo As Boolean = True, Optional ByVal AnchoVista As Integer = 735, Optional ByVal IsConRecorridoRegistros As Boolean = False, Optional ByVal LadoIzquierdo As Integer = 29, Optional Formato As String = "aspx", Optional ByRef CancelButton As Button = Nothing, Optional ByRef DeleteButton As Button = Nothing)


        '-------------------------- 26-Julio-2010 -----------------
        ' Esta nueva rutina supone trabajar con un contenedor del tipo PlaceHolder en vez del tipo
        ' table
        '----------------------------------------------------------

        '-------------------------- 07-Junio-2013 -----------------
        ' Esta nueva rutina supone trabajar con una vista con un �nico bot�n que responde del lado
        ' del cliente y para el cual tambi�n se autogenera el javascript que va de depender de la 
        ' vista escogida en t�rminos de la acci�n cuyo resultado va a ser informado por el usuario.
        '----------------------------------------------------------

        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim m As Integer = 0
        Dim n As Integer = 0
        Dim kk As Integer = 0
        Dim ii As Integer = 0
        Dim mm As Integer = 0
        Dim nn As Integer = 0
        Dim MyTable As Table
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim MiTablaSubTab As Table
        Dim MiRowSubTab As TableRow
        Dim MiCellSubTab As TableCell
        Dim MiTabla12 As Table
        Dim MiRow12 As TableRow
        Dim MiCell12 As TableCell

        Dim arrLabel(24) As String
        Dim arrControl(24) As String
        Dim arrGrillaLabel(24) As String
        Dim arrGrillaControl(24) As String
        Dim ArrNodesId(24) As Long
        Dim arrNodesLabel(24) As String
        Dim arrNodesControl(24) As String
        Dim arrSubNodesId(24) As Long
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
        Dim Url As String = ""
        Dim FormularioWebPId As Long = 0
        Dim FormularioWebServiceCall As String = ""

        Dim txtTextBox As TextBox
        Dim hidTextBox As HiddenField
        Dim txtDropDownList As DropDownList
        Dim txtCheckBox As CheckBox
        Dim sqlSource As SqlDataSource
        Dim txtCalendar As CalendarExtender
        Dim ImgImages As Image
        Dim AutoComp As AutoCompleteExtender
        Dim txtUploadFile As FileUpload
        Dim SaveButton As Button
        Dim UploadLink As HyperLink
        Dim txtCascadeDropDownList As CascadingDropDown

        Dim sSQL As String = ""
        Dim HTMLCode As String = ""

        Dim AnchoTablaTabs As Integer = 0
        Dim sJavaScript As String = ""

        Dim FormularioWeb As New FormularioWeb
        Dim MyScript As String = ""

        ' Primero se despliegan
        ' los campos que son de contexto y que no pueden ser alterados por ning�n motivo, como
        ' por ejemplo aquellos campos que son claves �nicas y que no pueden ser modificados
        ' o aquellos campos que corresponden a la foreing key hacia la tabla padre, en el
        ' caso de una aplicaci�n del tipo master-detail.

        ' Estos campos se encuentran en la section FormKeys y pueden no existir para determinados
        ' tipos de formularios y se leen mediante el metodo 
        ' LeerKeysFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        t = Lecturas.LeerKeysFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        ' A continuaci�n pongo los textos de identificaci�n de la p�gina, que fueron pasados como
        ' par�metros de invocaci�n

        If NumeroPagina <> 271 Then

            'MyTable = New Table
            'MyTable.ID = "ViewHeader2" & NumeroPagina
            'MyTable.Width = "700"
            'MyTable.CellSpacing = "2"
            'MyTable.CellPadding = "2"
            'MyTable.CssClass = "visible"
            ''Titulo
            'Row = New TableRow
            'Cell = New TableCell
            'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            'Cell.ColumnSpan = "2"
            'Cell.Controls.Add(New LiteralControl("<h1>" & TituloPagina & "</h1>"))
            'Row.Cells.Add(Cell)
            'MyTable.Rows.Add(Row)
            'MyView.Controls.Add(MyTable)
            ' Quitamos el t�tulo y lo asociamos al formulario de entrada de datos - 24 de Julio de 2013
            '-------------------------------------------------------------------------------------------
            'If ConTitulo Then
            '    Dim CodigoHTML As String = "<p><center><h1>" & TituloPagina & "</h1></center></p>"

            '    MyView.Controls.Add(New LiteralControl(CodigoHTML))
            'End If

        End If

        ' Bajo el nuevo esquema, creo otra tabla para los campos claves y la sumo al placeholder
        'Luego se agrega la tabla de control de validaci�n de los campos

        i = 0

        ' A continuaci�n leo el registro de cabecera del formulario y desde el cual derivan el
        ' resto de los registros que indican sus atributos y sus acciones
        ' Este registro se identifica pues es el �nico del formulario que pertenece a la 
        ' section FormHeader y se lee con el metodo: LeerHeaderFormularioWeb, que devuelve
        ' una �nica variable cuyo valor gobierna las siguientes decisiones de despliegue de los 
        ' atributos del formulario web, para ello este metodo se implementa como una funci�n que 
        ' devuelve un �nico campo booleano que puede poseer los siguientes valores:

        '   False:  No se encontro registro de cabecera, en cuyo caso el formulario es plano y no
        '           requiere un recorrido recursivo para ir desplegando sus atributos.
        '   ------------------------------------------------------------------------------------
        '   True:  Se encontro registro de cabecera y ello indica que el formulario debe ser recorrido
        '           en forma recursiva a continuaci�n del despliegue de los campos clave, siempre y cuando
        '           estos existan como atributos del formulario.
        t = Lecturas.LeerHeaderFormularioWeb(arrLabel, arrControl, NumeroPagina, i, FormularioWebPId)

        If i = 1 Then ' Se encontro un registro de cabecera para el formulario web

            ' Para emular tab container con tab panel se usaran solo tablas, con la capacidad de hacerse visibles o
            ' invisibles, dejando una sola visible a la vez.

            ' La primera tabla actuara como Tab Panel y es una tabla de una sola fila con tantas columnas como 
            ' grupos de campos tenga el formulario, para ello se hara un primer recorrido de las cabeceras encontradas

            ' Voy a usar una table en vez de un tab container

            i = 0
            t = Lecturas.LeerNodesFormularioWeb(arrLabel, arrControl, ArrNodesId, i, FormularioWebPId)
            If i > 1 Then 'Solo se despliegan tabs cuando hay m�s de 1, en el otro caso no lo amerita.
                'Creamos tabla y la �nica fila
                AnchoTablaTabs = 116 * (i + 1)
                MyTable = New Table
                MyTable.ID = "ViewBody2" & FormularioWebPId
                MyTable.Width = AnchoTablaTabs
                MyTable.CellSpacing = "2"
                MyTable.CellPadding = "2"
                Row = New TableRow
                For k = 0 To i - 1
                    sJavaScript = ""
                    For m = 0 To i - 1
                        If m = k Then
                            sJavaScript = sJavaScript & "aparecer(""sub" & arrControl(m) & "sub"");"
                        Else
                            sJavaScript = sJavaScript & "desaparecer(""sub" & arrControl(m) & "sub"");"
                        End If
                    Next
                    Cell = New TableCell
                    Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
                    Cell.Width = "120"
                    Cell.CssClass = "boxceleste"
                    Cell.Controls.Add(New LiteralControl("<a onclick='" & sJavaScript & "'>" & arrLabel(k) & "</a>"))
                    Row.Cells.Add(Cell)
                Next
                sJavaScript = ""
                For m = 0 To i - 1
                    sJavaScript = sJavaScript & "todosvisibles(""sub" & arrControl(m) & "sub"");"
                Next
                Cell = New TableCell
                Cell.Style(HtmlTextWriterStyle.TextAlign) = "center"
                Cell.Width = "120"
                Cell.CssClass = "boxceleste"
                Cell.Controls.Add(New LiteralControl("<a onclick='" & sJavaScript & "'>" & "Ver ficha completa" & "</a>"))
                Row.Cells.Add(Cell)
                MyTable.Rows.Add(Row)
                MyView.Controls.Add(MyTable)
            End If
            'Con el mismo arreglo de nodos, vuelvo a recorrerlos pero ahora por cada uno, leo sus nodos hijos
            'para asi cargos los controles del formulario web.

            If i > 0 Then
                For k = 0 To i - 1
                    n = 0
                    t = Lecturas.LeerNodesFormularioWeb(arrNodesLabel, arrNodesControl, arrSubNodesId, n, ArrNodesId(k))
                    'Aqui acabo de leer los nodos del primer tab, por ahora no hay m�s anidamiento, asi que cada nodo
                    'en arrNodesLabel es en realidad una hoja
                    MiTablaSubTab = New Table
                    MiTablaSubTab.ID = "sub" & arrControl(k) & "sub" & NumeroPagina
                    MiTablaSubTab.ClientIDMode = ClientIDMode.Static
                    MiTablaSubTab.Width = AnchoVista  '735  y 720
                    ' Asociamos el t�tulo al formulario de entrada de datos - 24 de Julio de 2013
                    '-------------------------------------------------------------------------------------------
                    If ConTitulo Then
                        MiTablaSubTab.Caption = "<h2>" & TituloPagina & "</h2>"
                    End If
                    MiTablaSubTab.CaptionAlign = TableCaptionAlign.Left
                    MiTablaSubTab.CellSpacing = "2"
                    MiTablaSubTab.CellPadding = "2"
                    If k = 0 Then
                        MiTablaSubTab.CssClass = "visible"
                    Else
                        MiTablaSubTab.CssClass = "invisible"
                    End If
                    MiTablaSubTab.BackColor = Drawing.Color.WhiteSmoke
                    MiTablaSubTab.BorderStyle = BorderStyle.Solid
                    MiTablaSubTab.BorderWidth = 1
                    MiTablaSubTab.BorderColor = Drawing.Color.WhiteSmoke

                    'Controles del Formulario Web
                    For m = 0 To n - 1
                        t = Lecturas.LeerLeafFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "InputValidation", FormularioWebServiceCall, arrSubNodesId(m))
                        ' Cambio introducido para dejar no visible ciertos campos
                        ' 27 de Abril de 2011
                        ' ------------------------------------------------------
                        If FormularioWeb.CampoIsVisible(arrSubNodesId(m)) = True Then
                            MiRowSubTab = New TableRow
                            MiRowSubTab.VerticalAlign = VerticalAlign.Middle
                            MiCellSubTab = New TableCell
                            MiCellSubTab.CssClass = CssClassLabel
                            MiCellSubTab.Style(HtmlTextWriterStyle.TextAlign) = "right"
                            'MiCellSubTab.Style(HtmlTextWriterStyle.Width) = "19%"  ' 29
                            MiCellSubTab.Style(HtmlTextWriterStyle.Width) = LadoIzquierdo & "%"
                            If IsRequiredField Then
                                MiCellSubTab.Controls.Add(New LiteralControl(arrNodesLabel(m) & " (*) "))
                            Else
                                MiCellSubTab.Controls.Add(New LiteralControl(arrNodesLabel(m) & "  "))
                            End If
                            MiRowSubTab.Cells.Add(MiCellSubTab)
                            MiCellSubTab = New TableCell
                            'MiCellSubTab.Style(HtmlTextWriterStyle.Width) = "81%"   ' 71
                            MiCellSubTab.Style(HtmlTextWriterStyle.Width) = (100 - LadoIzquierdo) & "%"
                            MiCellSubTab.VerticalAlign = VerticalAlign.Middle
                            Select Case TipoControl
                                Case "TextBox"
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    If Mid(DomainField, 1, 2) = "Nb" Then
                                        txtTextBox.Style(HtmlTextWriterStyle.TextAlign) = "Right"
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                Case "TextBox12" 'Se crea para armar una fila con 12 columnas con header y campo
                                    ' Creamos una tabla que se va a subordinar a la tabla matriz

                                    MiTabla12 = New Table
                                    MiTabla12.ID = "sub" & arrNodesControl(m) & "sub"
                                    MiTabla12.ClientIDMode = ClientIDMode.Static
                                    MiTabla12.Width = "560"
                                    MiTabla12.CellSpacing = "1"
                                    MiTabla12.CellPadding = "1"
                                    MiTabla12.BackColor = Drawing.Color.WhiteSmoke
                                    MiTabla12.BorderStyle = BorderStyle.Solid
                                    MiTabla12.BorderWidth = 1
                                    MiTabla12.BorderColor = Drawing.Color.WhiteSmoke
                                    MiRow12 = New TableRow
                                    For ii = 1 To 12
                                        MiCell12 = New TableCell
                                        MiCell12.CssClass = CssClassLabel
                                        MiCell12.Style(HtmlTextWriterStyle.TextAlign) = "Center"
                                        MiCell12.Controls.Add(New LiteralControl(NombreMesCorto(ii)))
                                        MiRow12.Cells.Add(MiCell12)
                                    Next
                                    MiTabla12.Rows.Add(MiRow12)
                                    MiRow12 = New TableRow
                                    For ii = 1 To 12
                                        MiCell12 = New TableCell
                                        txtTextBox = New TextBox
                                        txtTextBox.ID = arrNodesControl(m)
                                        txtTextBox.ClientIDMode = ClientIDMode.Static
                                        txtTextBox.CssClass = CssClassControl
                                        txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                        txtTextBox.TextMode = ControlTextMode
                                        If ControlTextMode = 1 Then
                                            txtTextBox.Height = "50"
                                        End If
                                        txtTextBox.ToolTip = ToolTip
                                        If IsNotEnabledField Then
                                            txtTextBox.Enabled = False
                                        End If
                                        If Mid(DomainField, 1, 2) = "Nb" Then
                                            txtTextBox.Style(HtmlTextWriterStyle.TextAlign) = "Right"
                                        End If
                                        MiCell12.Controls.Add(txtTextBox)
                                        MiRow12.Cells.Add(MiCell12)
                                        m = m + 1
                                        If m <= n - 1 Then
                                            t = Lecturas.LeerLeafFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "InputValidation", FormularioWebServiceCall, arrSubNodesId(m))
                                        End If
                                    Next
                                    MiTabla12.Rows.Add(MiRow12)
                                    m = m - 1
                                    MiCellSubTab.Controls.Add(MiTabla12)
                                Case "CheckBox"
                                    txtCheckBox = New CheckBox
                                    txtCheckBox.ID = arrNodesControl(m)
                                    txtCheckBox.ClientIDMode = ClientIDMode.Static
                                    txtCheckBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtCheckBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtCheckBox)
                                Case "TextBoxAutoComplete"
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    AutoComp = New AutoCompleteExtender
                                    AutoComp.ID = "Autocomplete" & arrNodesControl(m)
                                    AutoComp.ClientIDMode = UI.ClientIDMode.Static
                                    AutoComp.CompletionListItemCssClass = CssClassControl
                                    AutoComp.TargetControlID = arrNodesControl(m)
                                    AutoComp.ServicePath = "AutoComplete.asmx"
                                    AutoComp.ServiceMethod = FormularioWebServiceCall
                                    AutoComp.MinimumPrefixLength = "2"
                                    AutoComp.CompletionInterval = "1000"
                                    AutoComp.EnableCaching = "true"
                                    AutoComp.CompletionSetCount = "12"
                                    MiCellSubTab.Controls.Add(AutoComp)
                                Case "TextBoxCalendar"
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ImgImages = New Image
                                    ImgImages.ID = "Image" & arrNodesControl(m)
                                    ImgImages.ClientIDMode = UI.ClientIDMode.Static
                                    ImgImages.ImageUrl = "img/Calendar_scheduleHS.png"
                                    ImgImages.ImageAlign = ImageAlign.Middle
                                    MiCellSubTab.Controls.Add(ImgImages)
                                    txtCalendar = New CalendarExtender
                                    txtCalendar.ID = "Calendar" & arrNodesControl(m)
                                    txtCalendar.ClientIDMode = UI.ClientIDMode.Static
                                    txtCalendar.TargetControlID = arrNodesControl(m)
                                    txtCalendar.PopupButtonID = "Image" & arrNodesControl(m)
                                    txtCalendar.Format = "dd/MM/yy"
                                    MiCellSubTab.Controls.Add(txtCalendar)
                                Case "DropDownList"
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = arrNodesControl(m)
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtDropDownList.ToolTip = ToolTip
                                    txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                    txtDropDownList.DataTextField = DataTextField
                                    txtDropDownList.Height = "20"
                                    MiCellSubTab.Controls.Add(txtDropDownList)


                                    sqlSource  = New SqlDataSource()                    
                                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                    sqlSource.SelectCommand = SelectCommand

                                    sqlSource.ID = "ds" & arrNodesControl(m)
                                    'sqlSource.DataFile = DataFile
                                    'sqlSource.SelectCommand = SelectCommand
                                    MiCellSubTab.Controls.Add(sqlSource)
                                Case "DropDownSearch"
                                    txtCheckBox = New CheckBox
                                    txtCheckBox.ID = "chk" & arrNodesControl(m)
                                    txtCheckBox.ClientIDMode = ClientIDMode.Static
                                    txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrNodesLabel(m)
                                    txtCheckBox.Height = "20"
                                    MiCellSubTab.Controls.Add(txtCheckBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = arrNodesControl(m)
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtDropDownList.ToolTip = ToolTip
                                    txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                    txtDropDownList.DataTextField = DataTextField
                                    txtDropDownList.Height = "20"
                                    MiCellSubTab.Controls.Add(txtDropDownList)


                                    sqlSource  = New SqlDataSource()                    
                                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                    sqlSource.SelectCommand = SelectCommand                                    
                                    sqlSource.ID = "ds" & arrNodesControl(m)
                                    'sqlSource.DataFile = DataFile
                                    'sqlSource.SelectCommand = SelectCommand
                                    MiCellSubTab.Controls.Add(sqlSource)
                                Case "AutocompleteSearch"
                                    txtCheckBox = New CheckBox
                                    txtCheckBox.ID = "chk" & arrNodesControl(m)
                                    txtCheckBox.ClientIDMode = ClientIDMode.Static
                                    txtCheckBox.ToolTip = "Marque el check box para realizar la b�squeda usando el valor seleccionado para el campo " & arrNodesLabel(m)
                                    MiCellSubTab.Controls.Add(txtCheckBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    AutoComp = New AutoCompleteExtender
                                    AutoComp.ID = "Autocomplete" & arrNodesControl(m)
                                    AutoComp.ClientIDMode = UI.ClientIDMode.Static
                                    AutoComp.CompletionListItemCssClass = CssClassControl
                                    AutoComp.TargetControlID = arrNodesControl(m)
                                    AutoComp.ServicePath = SelectCommand
                                    AutoComp.ServiceMethod = FormularioWebServiceCall
                                    AutoComp.MinimumPrefixLength = "2"
                                    AutoComp.CompletionInterval = "1000"
                                    AutoComp.EnableCaching = "true"
                                    AutoComp.CompletionSetCount = "12"
                                    MiCellSubTab.Controls.Add(AutoComp)

                                Case "UploadArchivo" 'S�lo 1 campo de este tipo por p�gina web
                                    txtUploadFile = New FileUpload
                                    txtUploadFile.ID = "txtUploadFile"
                                    txtUploadFile.ClientIDMode = ClientIDMode.Static
                                    txtUploadFile.ToolTip = "Busque el archivo a subir"
                                    txtUploadFile.CssClass = CssClassControl
                                    MiCellSubTab.Controls.Add(txtUploadFile)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ' Se agrega el bot�n Save
                                    SaveButton = New Button
                                    SaveButton.ID = "SaveButton"
                                    SaveButton.CssClass = "boxceleste"
                                    SaveButton.Style(HtmlTextWriterStyle.Width) = 70
                                    SaveButton.Text = "Guardar"
                                    SaveButton.ToolTip = "De un click para guardar el archivo"
                                    'AddHandler SaveButton.Click, AddressOf RFC_Save
                                    MiCellSubTab.Controls.Add(SaveButton)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ' Se agrega el campo de texto
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    If ControlTextMode = 1 Then
                                        txtTextBox.Height = "50"
                                    End If
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" "))
                                    ' Se agrega el Hyperlink para ver el archivo
                                    UploadLink = New HyperLink
                                    UploadLink.ID = "lnkFile"
                                    UploadLink.ClientIDMode = ClientIDMode.Static
                                    UploadLink.ImageUrl = "~/img/lupa20x20.png"
                                    'UploadLink.BorderWidth = 0
                                    'UploadLink.Text = "Ver Archivo"
                                    UploadLink.ToolTip = "De un click para visualizar el archivo"
                                    UploadLink.Visible = True
                                    MiCellSubTab.Controls.Add(UploadLink)




                                Case "CascadeDropDown" 'Se agrega solo para proyecto Codelco
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = "ddlAmbitos"
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                                    txtDropDownList.ToolTip = "Escoja el Ambito"
                                    MiCellSubTab.Controls.Add(txtDropDownList)
                                    MiCellSubTab.Controls.Add(New LiteralControl("<br /><br /> "))

                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = "ddlHojas"
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                                    txtDropDownList.ToolTip = "Escoja la opci�n de men�"
                                    MiCellSubTab.Controls.Add(txtDropDownList)
                                    MiCellSubTab.Controls.Add(New LiteralControl("<br /><br /> "))

                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = "ddlDocumentos"
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = "500"
                                    txtDropDownList.ToolTip = "Documentos actualmente vinculados"
                                    MiCellSubTab.Controls.Add(txtDropDownList)
                                    MiCellSubTab.Controls.Add(New LiteralControl("<br /><br /> "))

                                    txtCascadeDropDownList = New CascadingDropDown
                                    txtCascadeDropDownList.ID = "cddAmbitos"
                                    txtCascadeDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtCascadeDropDownList.TargetControlID = "ddlAmbitos"
                                    txtCascadeDropDownList.Category = "Ambitos"
                                    txtCascadeDropDownList.PromptText = "Escoja un �mbito ...."
                                    txtCascadeDropDownList.LoadingText = "Por favor espere ..."
                                    txtCascadeDropDownList.ServicePath = "AmbitosService.asmx"
                                    txtCascadeDropDownList.ServiceMethod = "GetAmbitos"
                                    MiCellSubTab.Controls.Add(txtCascadeDropDownList)

                                    txtCascadeDropDownList = New CascadingDropDown
                                    txtCascadeDropDownList.ID = "cddHojas"
                                    txtCascadeDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtCascadeDropDownList.TargetControlID = "ddlHojas"
                                    txtCascadeDropDownList.ParentControlID = "ddlAmbitos"
                                    txtCascadeDropDownList.Category = "Hojas"
                                    txtCascadeDropDownList.PromptText = "Escoja una opci�n del men� ...."
                                    txtCascadeDropDownList.LoadingText = "Por favor espere ..."
                                    txtCascadeDropDownList.ServicePath = "AmbitosService.asmx"
                                    txtCascadeDropDownList.ServiceMethod = "GetHojas"
                                    MiCellSubTab.Controls.Add(txtCascadeDropDownList)

                                    txtCascadeDropDownList = New CascadingDropDown
                                    txtCascadeDropDownList.ID = "cddDocumentos"
                                    txtCascadeDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtCascadeDropDownList.TargetControlID = "ddlDocumentos"
                                    txtCascadeDropDownList.ParentControlID = "ddlHojas"
                                    txtCascadeDropDownList.Category = "Documentos"
                                    txtCascadeDropDownList.PromptText = "Documentos actualmente vinculados ...."
                                    txtCascadeDropDownList.LoadingText = "Por favor espere ..."
                                    txtCascadeDropDownList.ServicePath = "AmbitosService.asmx"
                                    txtCascadeDropDownList.ServiceMethod = "GetDocumentos"
                                    MiCellSubTab.Controls.Add(txtCascadeDropDownList)

                                Case "SelectFromModalList"   'Se agrega para proyecto con Importadora Vergara
                                    MiCellSubTab.Controls.Add(New LiteralControl("<input id=""btnModal""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""?"" onclick=""verModal" & arrNodesControl(m) & "('SelectFromModalList.aspx?Accion=" & SelectCommand & "')"" style=""width: 20px"" /> "))
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m)
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.ToolTip = ToolTip
                                    If IsNotEnabledField Then
                                        txtTextBox.Enabled = False
                                    End If
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    MiCellSubTab.Controls.Add(New LiteralControl(" <input id=""btnHelp" & arrNodesControl(m) & """ class=""boxceleste"" type=""button"" value=""..."" onclick=""return btnHelp" & arrNodesControl(m) & "_onclick()"" style=""width: 30px"" /> "))

                                    '<asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" autoComplete="off" Width="200px"  ></asp:TextBox>
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m) & "Description"
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = "350px"
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.Enabled = False
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    'MiCellSubTab.Controls.Add(New LiteralControl("<input id=""btnHelpCodigo""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""Leer por Nombre"" onclick=""return btnHelpNombre" & arrNodesControl(m) & "_onclick()"" style=""width: 100px"" />"))
                                    MiCellSubTab.Controls.Add(New LiteralControl(GenerarJScript(arrNodesControl(m), SelectCommand)))

                                Case "DropDownListPlusDescription"
                                    txtDropDownList = New DropDownList
                                    txtDropDownList.ID = arrNodesControl(m)
                                    txtDropDownList.ClientIDMode = ClientIDMode.Static
                                    txtDropDownList.CssClass = CssClassControl
                                    txtDropDownList.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                    txtDropDownList.ToolTip = ToolTip
                                    txtDropDownList.DataSourceID = "ds" & arrNodesControl(m)
                                    txtDropDownList.DataTextField = DataTextField
                                    MiCellSubTab.Controls.Add(txtDropDownList)


                                    sqlSource  = New SqlDataSource()                    
                                    sqlSource.ConnectionString = "Server=localhost;UID=sa;PWD=Password_01;Database=montes"
                                    sqlSource.SelectCommand = SelectCommand
                                    Console.WriteLine(SelectCommand)
                                    sqlSource.ID = "ds" & arrNodesControl(m)
                                    'sqlSource.DataFile = DataFile
                                    'sqlSource.SelectCommand = SelectCommand
                                    MiCellSubTab.Controls.Add(sqlSource)

                                    MiCellSubTab.Controls.Add(New LiteralControl(" <input id=""btnHelp" & arrNodesControl(m) & """ class=""boxceleste"" type=""button"" value=""..."" onclick=""return btnHelp" & arrNodesControl(m) & "_onclick()"" style=""width: 30px"" /> "))

                                    '<asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" autoComplete="off" Width="200px"  ></asp:TextBox>
                                    txtTextBox = New TextBox
                                    txtTextBox.ID = arrNodesControl(m) & "Description"
                                    txtTextBox.ClientIDMode = ClientIDMode.Static
                                    txtTextBox.CssClass = CssClassControl
                                    txtTextBox.Style(HtmlTextWriterStyle.Width) = "350px"
                                    txtTextBox.TextMode = ControlTextMode
                                    txtTextBox.Enabled = False
                                    MiCellSubTab.Controls.Add(txtTextBox)
                                    'MiCellSubTab.Controls.Add(New LiteralControl("<input id=""btnHelpCodigo""" & arrNodesControl(m) & " class=""boxceleste"" type=""button"" value=""Leer por Nombre"" onclick=""return btnHelpNombre" & arrNodesControl(m) & "_onclick()"" style=""width: 100px"" />"))
                                    MiCellSubTab.Controls.Add(New LiteralControl(GenerarJScriptOnlyDescription(arrNodesControl(m), SelectCommand)))


                            End Select
                            MiRowSubTab.Cells.Add(MiCellSubTab)
                            MiTablaSubTab.Rows.Add(MiRowSubTab)
                        Else
                            hidTextBox = New HiddenField
                            hidTextBox.ID = arrNodesControl(m)
                            hidTextBox.ClientIDMode = ClientIDMode.Static
                            'hidTextBox.CssClass = CssClassControl
                            'hidTextBox.Style(HtmlTextWriterStyle.Width) = ControlWidth
                            'hidtxtTextBox.TextMode = ControlTextMode
                            'hidtxtTextBox.ToolTip = ToolTip
                            'hidTextBox.Enabled = False
                            'hidTextBox.Visible = False
                            MyView.Controls.Add(hidTextBox)
                        End If
                    Next

                    MyView.Controls.Add(MiTablaSubTab)
                Next
            End If

            ' Creamos nuevamente la tabla
            MyTable = New Table
            MyTable.ID = "ViewButtons2" & NumeroPagina
            MyTable.Width = AnchoVista  '735  y 720
            MyTable.CellSpacing = "2"
            MyTable.CellPadding = "2"

            'Botones del Formulario
            i = 0
            t = Lecturas.LeerButtonFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            Row = New TableRow
            Cell = New TableCell
            'Cell.CssClass = CssClassLabel
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            'Cell.Style(HtmlTextWriterStyle.Width) = "29%"
            Cell.Style(HtmlTextWriterStyle.Width) = LadoIzquierdo & "%"
            'Se puso el 20 de Diciembre
            Cell.Controls.Add(New LiteralControl(" "))
            Row.Cells.Add(Cell)
            Cell = New TableCell
            'Cell.Style(HtmlTextWriterStyle.Width) = "71%"
            Cell.Style(HtmlTextWriterStyle.Width) = (100 - LadoIzquierdo) & "%"
            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Button", "InputValidation", NumeroPagina, k + 1, FormularioWebServiceCall)
                Select Case arrControl(k)

                    Case "UpdateButton"  'Este bot�n invoca un evento en el cliente que a su vez invoca un servicio web
                        If Len(FormularioWebServiceCall) > 0 Then  'Se muestra s�lo si existe un servicio web a invocar
                            'Aqui agregar un boton cliente
                            Cell.Controls.Add(New LiteralControl("<input id=""html" & arrControl(k) & """ type=""button"" value=""" & arrLabel(k) & """ class=""" & CssClassControl & """ title=""" & ToolTip & """ onclick=""" & arrControl(k) & "(" & UsuariosId & ");"" />"))
                            'Aqui genero el script que responde al evento click del boton cliente
                            Cell.Controls.Add(New LiteralControl(" "))
                            'Cell.Controls.Add(New LiteralControl(GenerarJScriptPorAccion(NumeroPagina, FormularioWebServiceCall, arrControl(k))))
                            'Lo comento en forma temporal - 14 de Julio de 2013
                            MyScript = MyScript & GenerarJScriptPorAccion(NumeroPagina, FormularioWebServiceCall, arrControl(k))
                        End If
                    Case "CancelButton"  'Este bot�n invoca un evento en el cliente que a su vez invoca un servicio web

                        If Len(FormularioWebServiceCall) > 0 Then  'Se muestra s�lo si existe un servicio web a invocar
                            'Aqui agregar un boton cliente
                            If IsConRecorridoRegistros = True Then  ' Se agregan dos botones para recorrer los registros
                                Cell.Controls.Add(New LiteralControl("<input id=""html" & arrControl(k) & "Anterior" & """ type=""button"" value=""" & "Anterior" & """ class=""" & CssClassControl & """ title=""" & "Leer registro anterior" & """ onclick=""" & "LeerAnterior" & "(" & UsuariosId & ");"" />"))
                                'Aqui genero el script que responde al evento click del boton cliente
                                Cell.Controls.Add(New LiteralControl(" "))
                                Cell.Controls.Add(New LiteralControl("<input id=""html" & arrControl(k) & "Siguiente" & """ type=""button"" value=""" & "Siguiente" & """ class=""" & CssClassControl & """ title=""" & "Leer registro siguiente" & """ onclick=""" & "LeerSiguiente" & "(" & UsuariosId & ");"" />"))
                                'Aqui genero el script que responde al evento click del boton cliente
                                Cell.Controls.Add(New LiteralControl(" "))
                            End If
                            If Formato = "aspx" Then
                                Cell.Controls.Add(New LiteralControl(" <input id=""html" & arrControl(k) & """ type=""button"" value=""" & arrLabel(k) & """ class=""" & CssClassControl & """ title=""" & ToolTip & """ onclick=""" & FormularioWebServiceCall & """ />"))
                            Else
                                CancelButton = New Button
                                CancelButton.ID = arrControl(k)
                                CancelButton.CssClass = CssClassControl
                                CancelButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                CancelButton.Text = arrLabel(k)
                                CancelButton.ToolTip = ToolTip
                                'AddHandler CancelButton.Click, AddressOf RFC_Logout
                                Cell.Controls.Add(CancelButton)
                                Cell.Controls.Add(New LiteralControl(" "))
                                'Cell.Controls.Add(New LiteralControl(" <a href='" & FormularioWebServiceCall & "'><span class=""" & CssClassControl & """ title=""" & ToolTip & """ style=""width:60px;height:20px"" >" & arrLabel(k) & "</span></a>"))
                            End If
                        End If
                    Case "DeleteButton"  'Este bot�n invoca un evento en el cliente que a su vez invoca un servicio web
                        If Len(FormularioWebServiceCall) > 0 Then  'Se muestra s�lo si existe un servicio web a invocar
                            If Formato = "aspx" Then
                                'Aqui agregar un boton cliente
                                Cell.Controls.Add(New LiteralControl("<input id=""html" & arrControl(k) & """ type=""button"" value=""" & arrLabel(k) & """ class=""" & CssClassControl & """ title=""" & ToolTip & """ onclick=""" & arrControl(k) & "(" & UsuariosId & ");"" />"))
                                'Aqui genero el script que responde al evento click del boton cliente
                                Cell.Controls.Add(New LiteralControl(" "))
                                'Cell.Controls.Add(New LiteralControl(GenerarJScriptPorAccion(NumeroPagina, FormularioWebServiceCall, arrControl(k))))
                                MyScript = MyScript & GenerarJScriptPorDelete(NumeroPagina, FormularioWebServiceCall, arrControl(k))

                            Else
                                DeleteButton = New Button
                                DeleteButton.ID = arrControl(k)
                                DeleteButton.CssClass = CssClassControl
                                DeleteButton.Style(HtmlTextWriterStyle.Width) = ControlWidth
                                DeleteButton.Text = arrLabel(k)
                                DeleteButton.ToolTip = ToolTip
                                'AddHandler DeleteButton.Click, AddressOf RFC_Delete
                                Cell.Controls.Add(DeleteButton)
                                Cell.Controls.Add(New LiteralControl(" "))
                            End If

                        End If

                    Case "NewButton"  'Este bot�n invoca un evento en el cliente que a su vez invoca un servicio web
                        If Len(FormularioWebServiceCall) > 0 Then  'Se muestra s�lo si existe un servicio web a invocar
                            'Aqui agregar un boton cliente
                            Cell.Controls.Add(New LiteralControl("<input id=""html" & arrControl(k) & """ type=""button"" value=""" & arrLabel(k) & """ class=""" & CssClassControl & """ title=""" & ToolTip & """ onclick=""" & arrControl(k) & "(" & UsuariosId & ");"" />"))
                            'Aqui genero el script que responde al evento click del boton cliente
                            Cell.Controls.Add(New LiteralControl(" "))
                            'Cell.Controls.Add(New LiteralControl(GenerarJScriptPorAccion(NumeroPagina, FormularioWebServiceCall, arrControl(k))))
                            'MyScript = MyScript & GenerarJScriptPorDelete(NumeroPagina, FormularioWebServiceCall, arrControl(k))
                        End If
                End Select
            Next
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
            MyView.Controls.Add(New LiteralControl(MyScript))
            MyView.Controls.Add(MyTable)
        End If
    End Sub

    Public Function GenerarJScriptPorAccion(ByVal NumeroPagina As Long, ByVal MetodoServicioWeb As String, ByVal EventoClick As String) As String
        Dim js As String
        GenerarJScriptPorAccion = ""
        Dim FormularioWeb As New FormularioWeb


        ' Aqui voy, debo pasar el n�mero de la p�gina y seleccionar los controles y armar la invocaci�n de la 
        ' web service para actualizar esos datos en la carpeta judicial.

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim StringUpdate As String = ""

        sSQL = "Select FormularioWeb.FormularioWebControl As Control, FormularioWeb.FormularioWebId as Id "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & NumeroPagina & ") And ((FormularioWeb.FormularioWebSection) = 'Form')) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebSecuencia"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                'Se elimina esta condici�n para permitir el manejo de campos ocultos como par�metros de invocaci�n del servicio de actualizaci�n
                'If FormularioWeb.CampoIsVisible(CLng(dtr("Id").ToString)) = True Then
                If Mid(dtr("control").ToString, 1, 3) = "chk" Then
                    StringUpdate = StringUpdate & " $get(""" & dtr("control").ToString & """).checked,"
                Else
                    StringUpdate = StringUpdate & " $get(""" & dtr("control").ToString & """).value,"
                End If
                'End If
            End While
            dtr.Close()
        Catch
            StringUpdate = ""
        End Try

        js = vbCrLf & "<script type=""text/JavaScript"">" & vbCrLf
        js = js & "     function OnTimeOut" & EventoClick & "(arg) {" & vbCrLf
        js = js & "         alert(""TimeOut al invocar el servicio web"");" & vbCrLf
        js = js & "     }" & vbCrLf
        js = js & "     function OnError" & EventoClick & "(arg) {" & vbCrLf
        js = js & "         alert(""Error encontrado al invocar el servicio"");" & vbCrLf
        js = js & "     }" & vbCrLf
        js = js & "     function OnComplete" & EventoClick & "(arg) {" & vbCrLf
        'js = js & "         var cajadiv = ""div#ListaCarpetas"";" & vbCrLf
        'js = js & "         $(cajadiv).html(arg);" & vbCrLf
        'js = js & "         var cajadiv = ""ListaCarpetas"";" & vbCrLf
        js = js & "         document.getElementById(""ListaCarpetas"").innerHTML = arg;" & vbCrLf
        js = js & "     }" & vbCrLf
        js = js & "     function " & EventoClick & "(UsuariosId) {" & vbCrLf
        js = js & "         ret = " & MetodoServicioWeb & StringUpdate & " OnComplete" & EventoClick & ", OnTimeOut" & EventoClick & ", OnError" & EventoClick & ");" & vbCrLf
        js = js & "         return (true); " & vbCrLf
        js = js & "     }" & vbCrLf
        js = js & "</script>" & vbCrLf
        GenerarJScriptPorAccion = js

    End Function
    Public Function GenerarJScriptPorDelete(ByVal NumeroPagina As Long, ByVal MetodoServicioWeb As String, ByVal EventoClick As String) As String
        Dim js As String
        GenerarJScriptPorDelete = ""

        js = vbCrLf & "<script type=""text/JavaScript"">" & vbCrLf
        js = js & "     function OnTimeOut" & EventoClick & "(arg) {" & vbCrLf
        js = js & "         alert(""TimeOut al invocar el servicio web"");" & vbCrLf
        js = js & "     }" & vbCrLf
        js = js & "     function OnError" & EventoClick & "(arg) {" & vbCrLf
        js = js & "         alert(""Error encontrado al invocar el servicio"");" & vbCrLf
        js = js & "     }" & vbCrLf
        js = js & "     function OnComplete" & EventoClick & "(arg) {" & vbCrLf
        js = js & "         if (arg != null) {" & vbCrLf
        js = js & "             if (arg == ""NO"") {" & vbCrLf
        js = js & "                 alert(""Registro no puede ser eliminado"");" & vbCrLf
        js = js & "                 }" & vbCrLf
        js = js & "             else {" & vbCrLf
        'js = js & "                 var cajadiv = ""div#ListaCarpetas"";" & vbCrLf
        'js = js & "                 $(cajadiv).html(arg);" & vbCrLf
        'js = js & "                 var cajadiv = ""ListaCarpetas"";" & vbCrLf
        js = js & "                 document.getElementById(""ListaCarpetas"").innerHTML = arg;" & vbCrLf
        js = js & "                 window.close();" & vbCrLf
        js = js & "                 }" & vbCrLf
        js = js & "             }" & vbCrLf
        js = js & "         }" & vbCrLf
        js = js & "     function " & EventoClick & "(UsuariosId) {" & vbCrLf
        js = js & "         ret = " & MetodoServicioWeb & " OnComplete" & EventoClick & ", OnTimeOut" & EventoClick & ", OnError" & EventoClick & ");" & vbCrLf
        js = js & "         return (true); " & vbCrLf
        js = js & "     }" & vbCrLf
        js = js & "</script>" & vbCrLf
        GenerarJScriptPorDelete = js

    End Function

    Public Function LoadTabla(ByVal arrControl As String, ByVal arrLabel As String, ByVal k As Integer, _
                              ByVal IsNotEnabledField As Boolean, ByVal Pagina As String, _
                              ByVal NombrePagina As String, ByVal MenuOptionsId As Long, _
                              ByVal MasterName As String, ByVal MasterId As Long, ByVal DomainField As String, _
                              ByVal FormularioWebPId As Long, ByVal FilterField As String, _
                              ByVal sSQLWhere As String, ByVal sSQLOrder As String, ByVal PaginaWebName As String, _
                              ByVal UserId As Long) As String


        Dim Lecturas As New Lecturas
        Dim CodigoHTML As String = ""
        Dim IndicadorEsManual As Boolean
        Dim Url As String
        Dim n As Integer = 0
        Dim m As Integer = 0
        Dim arrGrillaLabel(21) As String
        Dim arrGrillaControl(21) As String
        Dim arrTipoControl(21) As String
        Dim arrEtiquetaAlign(21) As String
        Dim TipoControl As String = ""
        Dim EtiquetaAlign As String = ""
        Dim ControlWidth As String = ""
        Dim ToolTip As String = ""
        Dim SelectCommand As String = ""
        Dim SelectCommandHyperLinkField As String = ""
        Dim DataFile As String = ""
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim t As Boolean
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim CarpetaJudicialId As Long = 0
        Dim TareasIdEnCarpeta As Long = 0


        'Crear la Tabla con su encabezado
        CodigoHTML = "<h1>Lista de " & arrLabel & "</h1>"
        If IsNotEnabledField = False Then
            IndicadorEsManual = True
            Dim linkAgregar As String = Pagina & "?PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & MenuOptionsId & "&MasterName=" & MasterName & "&MasterId=" & MasterId

            If IndicadorEsManual = True Then
                Url = "<a href='" & linkAgregar & "'>Agregar " & arrLabel & "</a>"
                If DomainField = "RelationBetweenTables" Then
                    Url = "<a href='" & linkAgregar & "'>Editar " & arrLabel & "</a>"
                End If
            Else
                Url = "<span class=""subtit"">Esta tarea no requiere ingresar un indicador de gesti�n</span>"
            End If
            CodigoHTML = CodigoHTML & "<p>" & Url & "</p>"
        End If

        n = 0
        t = Lecturas.LeerTabsColumnsFormularioWeb(arrGrillaLabel, arrGrillaControl, FormularioWebPId, n)
        CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""2"" cellspacing=""2"" class=""vinculo_carpeta"">"
        CodigoHTML = CodigoHTML & "<tr>"
        For m = 0 To n - 1
            t = Lecturas.LeerTabColumnFormularioWeb(TipoControl, EtiquetaAlign, ControlWidth, ToolTip, SelectCommand, "Grilla", FormularioWebPId, m + 1)
            arrTipoControl(m) = TipoControl
            arrEtiquetaAlign(m) = EtiquetaAlign
            Select Case TipoControl
                Case "HyperLinkField"
                    CodigoHTML = CodigoHTML & "<th>Editar</th>"
                    SelectCommandHyperLinkField = SelectCommand
                Case "HyperLinkTareaField"
                    CodigoHTML = CodigoHTML & "<th>Editar</th>"
                Case "DownLoadField"
                    CodigoHTML = CodigoHTML & "<th width =""" & ControlWidth & """ align=""" & EtiquetaAlign & """ >" & arrGrillaLabel(m) & "</th>"
                Case "TemplateField"
                    CodigoHTML = CodigoHTML & "<th width =""" & ControlWidth & """ align=""" & EtiquetaAlign & """ >" & arrGrillaLabel(m) & "</th>"
            End Select
        Next
        CodigoHTML = CodigoHTML & "</tr>"

        t = Lecturas.LeerTabSQLStatementFormularioWeb("SQLSelect", DataFile, SelectCommand, FormularioWebPId)

        'sqlSource.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\BDCAS.mdb"
        ' Cambio introducido el 08 de abril de 2011
        ' Se verifica que el el campo DomainField no contiene la glosa RelationBetweenTables
        If DomainField = "RelationBetweenTables" Then
            'Vamos a introducir un cambio para mejorar el desempe�o del despliegue de 
            'las listas de asociaciones entre la tabla maestra y sus tablas asociados.
            'Para ello al momento de desplegar s�lo vamos a mostrar los registros asociados
            'Luego vamos a examinar el mecanismo para hacer nuevas asociaciones.
            Select Case PaginaWebName
                Case "Ficha de DocumentosSGIPorCarpeta"
                    If MenuOptionsId = 503 Then
                        sSQL = "SELECT DocumentosSGI.DocumentosSGIId as Id, Mid(DocumentosSGI.DocumentosSGIFEmision,1,10)  As Fecha, DocumentosSGI.DocumentosSGICodigo as Codigo, DocumentosSGI.DocumentosSGINombre As Nombre FROM DocumentosSGI Where DocumentosSGI.DocumentosSGITipo <> 'Compliance' Order By DocumentosSGINombre"
                    Else
                        sSQL = "SELECT DocumentosSGI.DocumentosSGIId as Id, Mid(DocumentosSGI.DocumentosSGIFEmision,1,10)  As Fecha, DocumentosSGI.DocumentosSGICodigo as Codigo, DocumentosSGI.DocumentosSGINombre As Nombre FROM DocumentosSGI Where DocumentosSGI.DocumentosSGITipo = 'Compliance' Order By DocumentosSGINombre"
                    End If
                Case Else
                    sSQL = SelectCommand
            End Select
        Else
            If k = 0 Then
                sSQL = SelectCommand & " WHERE (((Tareas.PGGCodigo)='" & MasterName & "')) ORDER BY Tareas.DateLastUpdate DESC"
            Else
                sSQL = SelectCommand & " where " & FilterField & " = '" & MasterName & "'"
            End If
        End If


        If Len(sSQLWhere) > 0 Then
            sSQL = sSQL & sSQLWhere
        End If

        If Len(sSQLOrder) > 0 Then
            sSQL = sSQL & sSQLOrder
        End If

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<tr>"
                For m = 0 To n - 1
                    't = Lecturas.LeerTabColumnFormularioWeb(TipoControl, EtiquetaAlign, ControlWidth, ToolTip, SelectCommand, "Grilla", FormularioWebPId, m + 1)
                    TipoControl = arrTipoControl(m)
                    Select Case TipoControl
                        Case "HyperLinkField"
                            If DomainField = "RelationBetweenTables" Then
                                'Aqui debo poner la otra condici�n
                                'ItemTempColumnGrid.ItemTemplate = New PlantillaRelationsBetweenTables(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)}, DataTextField, PivotTable, DataFile, PivotId, UserId)
                            Else
                                CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """><a href=""" & SelectCommandHyperLinkField & "&MasterName=" & MasterName & "&MasterId=" & MasterId & "&Id=" & dtr(arrGrillaControl(m)).ToString & """><img src=""img/editar.png"" alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" /></a></td>"
                            End If
                        Case "HyperLinkTareaField"
                            If dtr("Estado").ToString <> "Cerrada" Then
                                CarpetaJudicialId = CarpetaJudicial.LeerCarpetaJudicialIdByCodigo(dtr("CarpetaJudicialCodigo").ToString)
                                TareasIdEnCarpeta = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(dtr("CarpetaJudicialCodigo").ToString)
                                If CLng(dtr("Id").ToString) = TareasIdEnCarpeta Then
                                    CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """><img src=""" & Tareas.ColorDeLaTarea(dtr("CarpetaJudicialCodigo").ToString) & """ width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & CarpetaJudicialId & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422'," & UserId & ",'" & arrControl & "','" & arrLabel & "'," & k & ",'" & IsNotEnabledField & "','" & Pagina & "','" & NombrePagina & "'," & MenuOptionsId & ", '" & MasterName & "'," & MasterId & ",'" & DomainField & "', " & FormularioWebPId & ",'" & FilterField & "', '" & sSQLWhere & "','" & sSQLOrder & "', '" & PaginaWebName & "')"" /></td>"
                                Else
                                    'Aqui tengo que invocar una web service para cerrar la tarea sin generar una nueva.

                                    CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """><img src=""img/tareas_circ_amarillo.png"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Click para cerrar la tarea"" onclick=""cerrarTarea(" & dtr("Id").ToString & "," & UserId & ",'" & arrControl & "','" & arrLabel & "'," & k & ",'" & IsNotEnabledField & "','" & Pagina & "','" & NombrePagina & "'," & MenuOptionsId & ", '" & MasterName & "'," & MasterId & ",'" & DomainField & "', " & FormularioWebPId & ",'" & FilterField & "', '" & sSQLWhere & "','" & sSQLOrder & "', '" & PaginaWebName & "')"" /></td>"
                                End If
                            Else
                                'Le voy a quitar la capacidad de abrir la ventana modal cuando la tarea esta cerrada. 28 de junio de 2022
                                'CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """><img src=""img/tareas_circ_verde.png"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" onclick=""verModalTarea('GestionUpdateTareas.aspx?TareasId=" & dtr("Id").ToString & "&Id=" & CarpetaJudicialId & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422'," & UserId & ",'" & arrControl & "','" & arrLabel & "'," & k & ",'" & IsNotEnabledField & "','" & Pagina & "','" & NombrePagina & "'," & MenuOptionsId & ", '" & MasterName & "'," & MasterId & ",'" & DomainField & "', " & FormularioWebPId & ",'" & FilterField & "', '" & sSQLWhere & "','" & sSQLOrder & "', '" & PaginaWebName & "')"" /></td>"
                                CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """><img src=""img/tareas_circ_verde.png"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Tarea no Editable""  /></td>"

                            End If
                        Case "DownLoadField"
                            CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """><a href=""" & dtr("URL").ToString & """ target=""_blank"" >" & dtr("T�tulo").ToString & "</a></td>"
                        Case "TemplateField"
                            Select Case Mid(arrGrillaControl(m), 1, 3)
                                Case "Usr"
                                    CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>" & Usuarios.LeerUsuariosDescriptionByName(dtr(arrGrillaControl(m)).ToString) & "</td>"
                                Case "Str"
                                    CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>" & dtr(arrGrillaControl(m)).ToString & "</td>"
                                Case "Int"
                                    If Len(dtr(arrGrillaControl(m)).ToString) = 0 Then
                                        CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>0</td>"
                                    Else
                                        CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>" & FormatNumber(dtr(arrGrillaControl(m)).ToString, 0) & "</td>"
                                    End If
                                Case "Dec"
                                    If Len(dtr(arrGrillaControl(m)).ToString) = 0 Then
                                        CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>0</td>"
                                    Else
                                        CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>" & FormatNumber(dtr(arrGrillaControl(m)).ToString / 100, 2) & "</td>"
                                    End If
                                Case "Cur"
                                    If arrGrillaControl(m) = "CurCuantia" Then
                                        If Len(dtr(arrGrillaControl(m)).ToString) = 0 Then
                                            CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>0</td>"
                                        Else
                                            CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>" & FormatCurrency(dtr(arrGrillaControl(m)).ToString / 100, 0) & "</td>"
                                        End If
                                    Else
                                        If Len(dtr(arrGrillaControl(m)).ToString) = 0 Then
                                            CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>0</td>"
                                        Else
                                            CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>" & FormatCurrency(dtr(arrGrillaControl(m)).ToString / 100, 4) & "</td>"
                                        End If
                                    End If

                                Case "Prc"
                                    If Len(dtr(arrGrillaControl(m)).ToString) = 0 Then
                                        CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>0</td>"
                                    Else
                                        CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>" & FormatPercent(dtr(arrGrillaControl(m)).ToString / 100, 2) & "</td>"
                                    End If
                                Case "Boo"
                                    If CBool(dtr(arrGrillaControl(m)).ToString) = "True" Then
                                        CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>SI</td>"
                                    Else
                                        CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>NO</td>"
                                    End If
                                Case "Url"
                                    CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """><a href=""" & dtr(arrGrillaControl(m)).ToString & """><img src=""img/editar.png"" alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" /></a></td>"
                                Case Else
                                    CodigoHTML = CodigoHTML & "<td align=""" & arrEtiquetaAlign(m) & """>" & dtr(arrGrillaControl(m)).ToString & "</td>"
                            End Select
                    End Select
                Next
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch
            CodigoHTML = CodigoHTML & "<tr><td></td></tr>"
        End Try
        CodigoHTML = CodigoHTML & "</table>"
        LoadTabla = CodigoHTML
    End Function

    Private Function Session() As Object
        Throw New NotImplementedException
    End Function

End Class
