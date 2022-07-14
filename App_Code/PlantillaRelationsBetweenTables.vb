Imports Microsoft.VisualBasic

Public Class PlantillaRelationsBetweenTables
    Implements ITemplate

    Private templateType As DataControlRowType
    Private columnName() As String
    Private nRelationTable As String
    Private nPivotTable As String
    Private nChildTable As String
    Private nPivotId As Long
    Private UserId As Long
    Sub New(ByVal type As DataControlRowType, ByVal colname() As String, ByVal RelationTable As String, _
                                        ByVal PivotTable As String, _
                                        ByVal ChildTable As String, _
                                        ByVal PivotId As Long, _
                                        ByVal UserIdCodigo As Long)

        templateType = type
        columnName = colname
        nRelationTable = RelationTable
        nPivotTable = PivotTable
        nChildTable = ChildTable
        nPivotId = PivotId
        UserId = UserIdCodigo

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
        Dim Variable As String
        Dim Valor As Long
        Dim l As Label = CType(sender, Label)
        Variable = l.Text
        Dim AccionesABM As New AccionesABM
        Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
        Valor = CLng(DataBinder.Eval(row.DataItem, Variable).ToString())
        Dim TareasProgramadas As New TareasProgramadas
        Dim Total As Long = 0
        Dim StakeholdersCodigo As String = ""


        If AccionesABM.LeerRelationTableId(nRelationTable, nPivotTable, nChildTable, nPivotId, CLng(Valor)) Then
            If nRelationTable = "StakeholdersPorProgramas" Then
                'l.Text = "<input id=""Checkbox" & Valor & """ type=""checkbox"" disabled=""disabled"" checked=""checked"" onclick=""RelationTableUpdate('" & nRelationTable & "', '" & nPivotTable & "', '" & nChildTable & "', " & nPivotId & ", " & Valor & ", " & UserId & ")"" />"
                Total = TareasProgramadas.LeerTotalTareasProgramadas(nPivotId, Valor)
                If Total = 0 Then
                    l.Text = "<input id=""Checkbox" & Valor & """ type=""checkbox"" checked=""checked"" title=""Stakeholder puede ser eliminado del programa"" onclick=""RelationTableUpdate('" & nRelationTable & "', '" & nPivotTable & "', '" & nChildTable & "', " & nPivotId & ", " & Valor & ", " & UserId & ")"" />"
                Else    'Significa que el stakeholder tiene tareas programada y no puede ser eliminado del programa
                    l.Text = "<input id=""Checkbox" & Valor & """ type=""checkbox"" checked=""checked"" disabled=""disabled"" title=""Stakeholder tiene tareas asociadas""  />"
                End If
            Else
                l.Text = "<input id=""Checkbox" & Valor & """ type=""checkbox"" checked=""checked"" onclick=""RelationTableUpdate('" & nRelationTable & "', '" & nPivotTable & "', '" & nChildTable & "', " & nPivotId & ", " & Valor & ", " & UserId & ")"" />"
            End If
        Else
            If nRelationTable = "StakeholdersPorProgramas" And nPivotTable = "Stakeholders" Then
                l.Text = "<input id=""Checkbox" & Valor & """ type=""checkbox"" disabled=""disabled"" onclick=""RelationTableUpdate('" & nRelationTable & "', '" & nPivotTable & "', '" & nChildTable & "', " & nPivotId & ", " & Valor & ", " & UserId & ")"" />"
            Else
                l.Text = "<input id=""Checkbox" & Valor & """ type=""checkbox"" onclick=""RelationTableUpdate('" & nRelationTable & "', '" & nPivotTable & "', '" & nChildTable & "', " & nPivotId & ", " & Valor & ", " & UserId & ")"" />"
            End If
        End If
    End Sub
End Class
