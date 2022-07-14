Imports Microsoft.VisualBasic

Public Class PlantillaEstadoTareas
    Implements ITemplate

    Private templateType As DataControlRowType
    Private columnName() As String
    Private TipoValor As String
    Private Correo As String
    Sub New(ByVal type As DataControlRowType, ByVal colname() As String, ByVal ValorTipo As String)

        templateType = type
        columnName = colname
        TipoValor = ValorTipo

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
        Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
        Valor = DataBinder.Eval(row.DataItem, Variable).ToString()
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
        Dim FechaDeTarea As String = ""
        Dim EstadoTarea As String = ""
        Dim t As Boolean = False

        Dim FechaTareas As Date = CDate(Tareas.LeerFechaTarea(CLng(Valor)))
        t = Tareas.LeerFechaEstadoTarea(CLng(Valor), FechaDeTarea, EstadoTarea)
        FechaTareas = CDate(FechaDeTarea)

        Dim MesTarea As String = Month(FechaTareas)
        Dim DeltaFecha As Integer = DateDiff(DateInterval.Day, Now, FechaTareas)




        Dim NumeroMesEnCurso As Integer = System.DateTime.Today.Month
        ' No solo debemos comparar el mes sino también el año
        Dim AnoEnCurso As Integer = System.DateTime.Today.Year



        Select Case TipoValor
            Case "ColorCeldaDelMesDeLaTarea"
                l.Text = "<table>"
                If DeltaFecha <= 5 Then 'La Tarea se encuentra o próxima a su fecha o esta vencida
                    ' Fondo Rojo
                    l.Text = l.Text & "<tr style=""height: 30px;""><td style=""background-color: #FF0000; color: #FFFFFF; width: 25px"">" & MesTarea & "</td></tr>"
                End If
                If DeltaFecha > 6 And DeltaFecha <= 15 Then 'La Tarea se encuentra en fecha de ejecución, ya que estamos filtrando las tareas terminadas
                    ' Fondo Amarillo: Warning
                    l.Text = l.Text & "<tr style=""height: 30px;""><td style=""background-color: #FFFF00; width: 25px"">" & MesTarea & "</td></tr>"
                End If
                If DeltaFecha > 16 And DeltaFecha <= 30 Then 'La Tarea es para un mes subsiguiente al actual
                    ' Fondo de color verde
                    l.Text = l.Text & "<tr style=""height: 30px;""><td style=""background-color: #00FF00; width: 25px"">" & MesTarea & "</td></tr>"
                End If
                If DeltaFecha > 30 Then
                    ' Fondo del color que corresponda
                    l.Text = l.Text & "<tr style=""height: 30px;""><td>" & MesTarea & "</td></tr>"
                End If
                l.Text = l.Text & "</table>"
            Case "ColorCeldaDelEstadoDeLaTarea"
                l.Text = "<table>"
                If EstadoTarea <> "Cerrada" Then
                    If DeltaFecha <= 5 Then 'La Tarea se encuentra o próxima a su fecha o esta vencida
                        ' Fondo Rojo
                        l.Text = l.Text & "<tr style=""height: 30px;""><td style=""background-color: #FF0000; color: #FFFFFF; width: 70px"">" & EstadoTarea & "</td></tr>"
                    End If
                    If DeltaFecha > 6 And DeltaFecha <= 15 Then 'La Tarea se encuentra en fecha de ejecución, ya que estamos filtrando las tareas terminadas
                        ' Fondo Amarillo: Warning
                        l.Text = l.Text & "<tr style=""height: 30px;""><td style=""background-color: #FFFF00; width: 70px"">" & EstadoTarea & "</td></tr>"
                    End If
                    If DeltaFecha > 16 And DeltaFecha <= 30 Then 'La Tarea es para un mes subsiguiente al actual
                        ' Fondo de color verde
                        l.Text = l.Text & "<tr style=""height: 30px;""><td style=""background-color: #00FF00; width: 70px"">" & EstadoTarea & "</td></tr>"
                    End If
                    If DeltaFecha > 30 Then
                        ' Fondo del color que corresponda
                        l.Text = l.Text & "<tr style=""height: 30px;""><td>" & EstadoTarea & "</td></tr>"
                    End If
                Else
                    ' Fondo del color que corresponda
                    l.Text = l.Text & "<tr style=""height: 30px;""><td>" & EstadoTarea & "</td></tr>"
                End If
                l.Text = l.Text & "</table>"
            Case "MailButton"    ' Genera un correo al usuario en relación a la tarea y de acuerdo a su estado
                If Variable = "Responsable" Then
                    l.Text = Usuarios.LeerUsuariosDescriptionByName(Valor)
                    Correo = Valor
                End If
                If Variable = "Id" Then
                    l.Text = "  <img src=""img/botones/b_contacto.gif"" alt=""Enviar correo"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" onclick=""EnviarCorreo('" & Correo & "', " & Valor & ")""  />"
                End If
        End Select

    End Sub
End Class
