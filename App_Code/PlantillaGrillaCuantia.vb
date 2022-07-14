Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class PlantillaGrillaCuantia
    Implements ITemplate

    Private templateType As DataControlRowType
    Private columnName() As String
    Sub New(ByVal type As DataControlRowType, ByVal colname() As String)

        templateType = type
        columnName = colname

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
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Valor As String
        Dim Variable As String
        Dim l As Label = CType(sender, Label)
        Dim i As Integer = 0
        Variable = l.Text

        Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
        Valor = DataBinder.Eval(row.DataItem, Variable).ToString()

        sSQL = "SELECT Sum (CarpetaJudicialCreditos.CarpetaJudicialCreditosDeudaTotalPesos) AS Suma "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos "
        sSQL = sSQL & "GROUP BY CarpetaJudicialCreditos.CarpetaJudicialCodigo, CarpetaJudicialCreditos.CarpetaJudicialCreditosMoneda "
        sSQL = sSQL & "HAVING (((CarpetaJudicialCreditos.CarpetaJudicialCodigo)='" & Valor & "'))"

        l.Text = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If Len(dtr("Suma").ToString) = 0 Then
                    l.Text = ""
                Else
                    l.Text = "$ " & FormatNumber(dtr("Suma").ToString / 10000, 0) & vbLf
                End If
            End While
            dtr.Close()
        Catch

        End Try

    End Sub
End Class
