Imports Microsoft.VisualBasic

Public Class PlantillaGrilla1Fila1Columna
    Implements ITemplate

    Private templateType As DataControlRowType
    Private columnName() As String
    Private codigoPGG As String
    Private TipoValor As String
    Private numeroMes As Integer
    Sub New(ByVal type As DataControlRowType, ByVal colname() As String, ByVal PGGCodigo As String, _
            ByVal ValorTipo As String, ByVal Mes As Integer)

        templateType = type
        columnName = colname
        codigoPGG = PGGCodigo
        TipoValor = ValorTipo
        numeroMes = Mes

    End Sub
    Sub InstantiateIn(ByVal container As System.Web.UI.Control) _
      Implements ITemplate.InstantiateIn

        Dim i As Integer = 0


        For i = 0 To columnName.Length - 1
            Dim firstName As New Label

            firstName.Text = columnName(i)
            AddHandler firstName.DataBinding, AddressOf FirstName_DataBinding

            container.Controls.Add(firstName)

        Next i

    End Sub
    Private Sub FirstName_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        Dim Valor As String
        Dim Variable As String
        Dim l As Label = CType(sender, Label)
        Variable = l.Text
        Dim TareasProgramadas As Long = 0
        Dim TareasRealizadas As Long = 0
        Dim PorcentajeCumplimiento As Double = 0
        Dim TareasProgramadasAlMesAnteriorAlMesEnCurso As Long = 0
        Dim TareasRealizadasAlMesAnteriorAlMesEnCurso As Long = 0
        Dim PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso As Double = 0
        Dim HHProgramadas As Double = 0
        Dim HHConsumidas As Double = 0
        Dim USDProgramados As Double = 0
        Dim USDConsumidos As Double = 0
        Dim Meta As Double = 0
        Dim TextoIndicador As String = ""
        Dim Tareas As New Tareas
        Dim t As Boolean
        Dim IsManual As Boolean
        Dim ValorMeta As Double
        Dim NumeroMesEnCurso As Integer = System.DateTime.Today.Month
        Dim YearEnCurso As Integer = System.DateTime.Today.Year

        Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
        Valor = DataBinder.Eval(row.DataItem, Variable).ToString()

        Select Case TipoValor
            Case "Meta"
                t = Tareas.LeerMetaByAccion(Valor, IsManual, ValorMeta, TextoIndicador)
                If IsManual = True Then
                    l.Text = FormatNumber(ValorMeta / 100, 2)
                Else
                    If ValorMeta = 0 Then
                        l.Text = ""
                    Else
                        l.Text = FormatNumber(ValorMeta / 100, 2)
                    End If
                End If
            Case "Indicador"    ' calcula el valor del indicador indicado por la acción
                t = Tareas.LeerMetaByAccion(Valor, IsManual, ValorMeta, TextoIndicador)
                If ValorMeta = 0 Then
                    l.Text = ""
                Else
                    l.Text = TextoIndicador
                End If
            Case "PR"
                l.Text = "<table>"
                l.Text = l.Text & "<tr><td>P</td></tr>"
                l.Text = l.Text & "<tr><td>R</td></tr>"
                l.Text = l.Text & "</table>"
            Case "Nomenclatura"
                l.Text = " "
            Case "PRMA"
                l.Text = "<table>"
                l.Text = l.Text & "<tr><td>Programado</td></tr>"
                l.Text = l.Text & "<tr><td>Realizado</td></tr>"
                l.Text = l.Text & "<tr><td>Mensual</td></tr>"
                l.Text = l.Text & "<tr><td>Acumulado</td></tr>"
                l.Text = l.Text & "</table>"
            Case "HH"           ' calcula el valor de las HH presupuestas y las reales
                HHProgramadas = Tareas.LeerHHProgramadas(Valor, codigoPGG)
                l.Text = "<table>"
                l.Text = l.Text & "<tr><td>" & FormatNumber(HHProgramadas / 100, 0) & "</td></tr>"
                l.Text = l.Text & "</table>"
            Case "USD"          ' calcula el valor de los USD presupuestados vs los reales
                USDProgramados = Tareas.LeerUSDProgramados(Valor, codigoPGG)
                l.Text = "<table>"
                l.Text = l.Text & "<tr><td>" & FormatCurrency(USDProgramados / 100, 0) & "</td></tr>"
                l.Text = l.Text & "</table>"
            Case "HHFooter"           ' calcula el valor de las HH presupuestas y las reales
                HHProgramadas = Tareas.LeerHHProgramadas("Todas", codigoPGG)
                l.Text = "<table>"
                l.Text = l.Text & "<tr><td>" & FormatNumber(HHProgramadas / 100, 0) & "</td></tr>"
                l.Text = l.Text & "</table>"
            Case "USDFooter"          ' calcula el valor de los USD presupuestados vs los reales
                USDProgramados = Tareas.LeerUSDProgramados("Todas", codigoPGG)
                l.Text = "<table>"
                l.Text = l.Text & "<tr><td>" & FormatCurrency(USDProgramados / 100, 0) & "</td></tr>"
                l.Text = l.Text & "</table>"
            Case "Mes"          ' calcula el número de tareas asignadas vs las realizadas
                TareasProgramadas = Tareas.LeerTareasProgramadas(Valor, numeroMes, codigoPGG)
                l.Text = "<table>"
                If TareasProgramadas > 0 Then
                    l.Text = l.Text & "<tr><td>" & TareasProgramadas & "</td></tr>"
                Else
                    l.Text = l.Text & "<tr><td></td></tr>"
                End If
                l.Text = l.Text & "</table>"
            Case "MesFooter"          ' calcula el número de tareas asignadas vs las realizadas
                TareasProgramadas = Tareas.LeerTareasProgramadas("Todas", numeroMes, codigoPGG)
                l.Text = "<table>"
                If TareasProgramadas > 0 Then
                    l.Text = l.Text & "<tr><td>" & TareasProgramadas & "</td></tr>"
                Else
                    l.Text = l.Text & "<tr><td></td></tr>"
                End If
                l.Text = l.Text & "</table>"
            Case "Prc"          ' calcula la última columna con el porcentaje total de cumplimiento
                TareasProgramadas = Tareas.LeerTotalTareasProgramadas(Valor, codigoPGG)
                l.Text = "<table>"
                l.Text = l.Text & "<tr><td>" & FormatNumber(TareasProgramadas, 0) & "</td></tr>"
                l.Text = l.Text & "</table>"
            Case "PrcFooter"          ' calcula la última columna con el porcentaje total de cumplimiento
                TareasProgramadas = Tareas.LeerTotalTareasProgramadas("Todas", codigoPGG)
                l.Text = "<table>"
                l.Text = l.Text & "<tr><td>" & FormatNumber(TareasProgramadas, 0) & "</td></tr>"
                l.Text = l.Text & "</table>"
        End Select

    End Sub
End Class
