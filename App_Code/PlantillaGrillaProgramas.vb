Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class PlantillaGrillaProgramas
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
        Dim Programas As New Programas
        Dim l As Label = CType(sender, Label)
        Dim i As Integer = 0
        Variable = l.Text

        Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
        Valor = DataBinder.Eval(row.DataItem, Variable).ToString()

        sSQL = "SELECT Programas.ProgramasName + ' (' + ProgramasMapa.ProgramasMapaTipoGestion + ')' as ProgramasPorStake "
        sSQL = sSQL & "FROM (Stakeholders INNER JOIN ProgramasMapa ON Stakeholders.StakeholdersCodigo = ProgramasMapa.StakeholdersCodigo) INNER JOIN Programas ON ProgramasMapa.ProgramasCodigo = Programas.ProgramasCodigo "
        sSQL = sSQL & "WHERE (((Stakeholders.StakeholdersName)='" & Valor & "'))"

        l.Text = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    l.Text = l.Text & CStr(dtr("ProgramasPorStake").ToString)
                Else
                    l.Text = l.Text & "<br />" & CStr(dtr("ProgramasPorStake").ToString)
                End If
            End While
            dtr.Close()
        Catch

        End Try



    End Sub
End Class
