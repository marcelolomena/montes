Imports Microsoft.VisualBasic

Public Class PlantillaFooter
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
        Dim HHProgramadas As Double = 0
        Dim HHConsumidas As Double = 0
        Dim USDProgramados As Double = 0
        Dim USDConsumidos As Double = 0
        Dim Tareas As New Tareas

        Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
        'Valor = DataBinder.Eval(row.DataItem, Variable).ToString()
        Valor = ""

        Select Case TipoValor
            Case "Indicador"    ' calcula el valor del indicador indicado por la acción
                l.Text = DataBinder.Eval(row.DataItem, Variable).ToString()
            Case "PR"
                l.Text = "<table>"
                l.Text = l.Text & "<tr><td>P</td></tr>"
                l.Text = l.Text & "<tr><td>R</td></tr>"
                l.Text = l.Text & "</table>"
            Case "HH"           ' calcula el valor de las HH presupuestas y las reales
                HHProgramadas = Tareas.LeerHHProgramadas(Valor, codigoPGG)
                HHConsumidas = Tareas.LeerHHConsumidas(Valor, codigoPGG)
                l.Text = "<table>"
                l.Text = l.Text & "<tr><td>" & FormatNumber(HHProgramadas / 100, 2) & "</td></tr>"
                l.Text = l.Text & "<tr><td>" & FormatNumber(HHConsumidas / 100, 2) & "</td></tr>"
                l.Text = l.Text & "</table>"
            Case "USD"          ' calcula el valor de los USD presupuestados vs los reales
                USDProgramados = Tareas.LeerUSDProgramados(Valor, codigoPGG)
                USDConsumidos = Tareas.LeerUSDConsumidos(Valor, codigoPGG)
                l.Text = "<table>"
                l.Text = l.Text & "<tr><td>" & FormatCurrency(USDProgramados / 100, 2) & "</td></tr>"
                l.Text = l.Text & "<tr><td>" & FormatCurrency(USDConsumidos / 100, 2) & "</td></tr>"
                l.Text = l.Text & "</table>"
            Case "Mes"          ' calcula el número de tareas asignadas vs las realizadas
                TareasProgramadas = Tareas.LeerTareasProgramadas(Valor, numeroMes, codigoPGG)
                TareasRealizadas = Tareas.LeerTareasRealizadas(Valor, numeroMes, codigoPGG)
                l.Text = "<table>"
                l.Text = l.Text & "<tr><td>" & TareasProgramadas & "</td></tr>"
                l.Text = l.Text & "<tr><td>" & TareasRealizadas & "</td></tr>"
                l.Text = l.Text & "</table>"
            Case "Prc"          ' calcula la última columna con el porcentaje total de cumplimiento
                TareasProgramadas = Tareas.LeerTotalTareasProgramadas(Valor, codigoPGG)
                TareasRealizadas = Tareas.LeerTotalTareasRealizadas(Valor, codigoPGG)
                PorcentajeCumplimiento = TareasRealizadas / TareasProgramadas
                l.Text = "<table>"
                l.Text = l.Text & "<tr><td>" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                l.Text = l.Text & "</table>"
        End Select

    End Sub
End Class
