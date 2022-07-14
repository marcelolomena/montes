Imports Microsoft.VisualBasic

Public Class PlantillaImageGrilla
    Implements ITemplate

    Private templateType As DataControlRowType
    Private columnName() As String
    Private Url As String
    Private ImagenBoton As String
    Sub New(ByVal type As DataControlRowType, ByVal colname() As String, ByVal Urlname As String, ByVal BotonImagen As String)

        templateType = type
        columnName = colname
        Url = Urlname
        ImagenBoton = BotonImagen

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

        Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
        Valor = DataBinder.Eval(row.DataItem, Variable).ToString()

        l.Text = "<a href=""" & Url & "&Id=" & Valor & """><img src=""" & ImagenBoton & """ alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" /></a>"

    End Sub
End Class
