Imports Microsoft.VisualBasic

Public Class PlantillaGrilla
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
        Dim Valor As String
        Dim Variable As String
        Dim l As Label = CType(sender, Label)
        Variable = l.Text
        Dim Usuarios As New Usuarios

        Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
        Valor = DataBinder.Eval(row.DataItem, Variable).ToString()

        Select Case Mid(Variable, 1, 3)
            Case "Usr"
                l.Text = Usuarios.LeerUsuariosDescriptionByName(Valor)
            Case "Str"
                l.Text = DataBinder.Eval(row.DataItem, Variable).ToString()
            Case "Int"
                If Len(DataBinder.Eval(row.DataItem, Variable).ToString()) = 0 Then
                    l.Text = 0
                Else
                    l.Text = FormatNumber(DataBinder.Eval(row.DataItem, Variable).ToString(), 0)
                End If
            Case "Dec"
                If Len(DataBinder.Eval(row.DataItem, Variable).ToString()) = 0 Then
                    l.Text = 0
                Else
                    l.Text = FormatNumber(DataBinder.Eval(row.DataItem, Variable).ToString() / 100, 2)
                End If
            Case "Cur"
                If Variable = "CurCuantia" Then
                    If Len(DataBinder.Eval(row.DataItem, Variable).ToString()) = 0 Then
                        l.Text = 0
                    Else
                        l.Text = FormatCurrency(DataBinder.Eval(row.DataItem, Variable).ToString() / 100, 0)
                    End If
                Else
                    If Len(DataBinder.Eval(row.DataItem, Variable).ToString()) = 0 Then
                        l.Text = 0
                    Else
                        l.Text = FormatCurrency(DataBinder.Eval(row.DataItem, Variable).ToString() / 100, 4)
                    End If
                End If

            Case "Prc"
                If Len(DataBinder.Eval(row.DataItem, Variable).ToString()) = 0 Then
                    l.Text = 0
                Else
                    l.Text = FormatPercent(DataBinder.Eval(row.DataItem, Variable).ToString() / 100, 2)
                End If
            Case "Boo"
                If DataBinder.Eval(row.DataItem, Variable).ToString() = "True" Then
                    l.Text = "SI"
                Else
                    l.Text = "NO"
                End If
            Case "Url"
                l.Text = "<a href=""" & Valor & """><img src=""img/editar.png"" alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" /></a>"
            Case "HRT"
                l.Text = "<a href=""ReporteHojaDeRuta.aspx?PaginaWebName=Rendicion Hoja de Ruta&MenuOptionsId=260&Viaje=" & Valor & """ target=""_blank"">" & Valor & "</a>"
            Case "Map"
                l.Text = "<table>"
                If Valor >= 18 Then 'Rojo
                    l.Text = l.Text & "<tr><td style=""background-color: #FF0000; color: #FFFFFF; height: 30px; width: 75px"">" & Valor & "</td></tr>"
                End If
                If Valor >= 9 And Valor < 18 Then 'Rosado
                    l.Text = l.Text & "<tr><td style=""background-color: #FFCC00; color: #FFFFFF; height: 30px; width: 75px"">" & Valor & "</td></tr>"
                End If
                If Valor >= 1 And Valor < 9 Then 'Amarillo
                    l.Text = l.Text & "<tr><td style=""background-color: #FFFF00; height: 30px; width: 75px"">" & Valor & "</td></tr>"
                End If
                l.Text = l.Text & "</table>"
            Case Else
                l.Text = DataBinder.Eval(row.DataItem, Variable).ToString()
        End Select

    End Sub
End Class
