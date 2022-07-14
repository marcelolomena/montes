Imports Microsoft.VisualBasic

Public Class PlantillaTextBoxButton
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
        Dim Puntaje As Long = 0
        Dim Importancia As Long = 1
        Dim RelationTableId As Long = 0
        Dim l As Label = CType(sender, Label)
        Variable = l.Text
        Dim AccionesABM As New AccionesABM
        Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
        Valor = CLng(DataBinder.Eval(row.DataItem, Variable).ToString())

        RelationTableId = AccionesABM.LeerRelationTableIdMasValor(nRelationTable, nPivotTable, nChildTable, nPivotId, CLng(Valor), Puntaje)
        l.Text = "<input id=""txtInputbox" & RelationTableId & """ type=""text"" style=""text-align:right;width: 65px"" class=""textoboxgris""  value=""" & FormatNumber(Puntaje, 0) & """ onblur=""RelationTableUpdate('" & nRelationTable & "', " & RelationTableId & ", " & nPivotId & ", " & UserId & ")"" />" '&nbsp;&nbsp;&nbsp;&nbsp;<input id=""btnInputbox" & RelationTableId & """ type=""button"" value=""Actualizar"" class=""boxceleste"" onblur=""RelationTableUpdate('" & nRelationTable & "', " & RelationTableId & ", " & UserId & ")"" />"
    End Sub
End Class
