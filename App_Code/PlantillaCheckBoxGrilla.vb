Imports Microsoft.VisualBasic

Public Class PlantillaCheckBoxGrilla
    Implements ITemplate

    Private templateType As DataControlRowType
    Private columnName() As String
    Private Rol As Long
    Private Tabla As String
    Private Url As String
    Private UserId As Long
    Sub New(ByVal type As DataControlRowType, ByVal colname() As String, ByVal RolId As Long, ByVal TablaName As String, ByVal UrlName As String, ByVal UserIdCodigo As Long)

        templateType = type
        columnName = colname
        Rol = RolId
        Tabla = TablaName
        Url = UrlName
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
        Dim Valor As String
        Dim l As Label = CType(sender, Label)
        Variable = l.Text
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim FuncionesPorRolId As Long

        Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
        Valor = DataBinder.Eval(row.DataItem, Variable).ToString()

        'l.Text = "<a href=""" & Url & "&Id=" & Valor & """><img src=""img/botones/i_solicitar.gif"" alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" /></a>"
        If FuncionesPorRol.LeerFuncionesPorRol(Rol, CLng(Valor), Tabla, FuncionesPorRolId) Then
            l.Text = "<input id=""Checkbox" & Valor & """ type=""checkbox"" checked=""checked"" onclick=""FuncionesPorRolDelete(" & Rol & ", " & Valor & ", '" & Tabla & "', " & UserId & ")"" />"
        Else
            l.Text = "<input id=""Checkbox" & Valor & """ type=""checkbox"" onclick=""FuncionesPorRolInsert(" & Rol & ", " & Valor & ", '" & Tabla & "', " & UserId & ")"" />"
        End If
        If Len(Url) > 0 Then
            l.Text = l.Text & "<img src=""img/botones/i_solicitar.gif"" alt=""Asignar/Desasignar funciones de la aplicación"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" />"
        End If


    End Sub

End Class
