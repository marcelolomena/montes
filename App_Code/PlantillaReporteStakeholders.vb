Imports Microsoft.VisualBasic

Public Class PlantillaReporteStakeholders
    Implements ITemplate

    Private templateType As DataControlRowType
    Private columnName() As String
    Private reporte As String

    Sub New(ByVal type As DataControlRowType, ByVal colname() As String, ByVal NombreReporte As String)

        templateType = type
        columnName = colname
        reporte = NombreReporte

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
        Dim Valor As String
        Dim l As Label = CType(sender, Label)
        Variable = l.Text
        Dim Stakeholders As New Stakeholders

        Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
        Valor = DataBinder.Eval(row.DataItem, Variable).ToString()
        l.Text = "<a href=""IndexSGI.aspx?PaginaWebName=Perfil Stakeholders&MenuOptionsId=439&StakeholdersId=" & Valor & """ >" & Stakeholders.LeerStakeholdersCodigoById(Valor) & "</a>"
    End Sub
End Class
