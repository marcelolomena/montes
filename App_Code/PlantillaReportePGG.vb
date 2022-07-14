Imports Microsoft.VisualBasic

Public Class PlantillaReportePGG
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
        Dim Programas As New Programas

        Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
        Valor = DataBinder.Eval(row.DataItem, Variable).ToString()
        'l.Text = "<a href=""ReportesPGG.aspx?PaginaWebName=" & reporte & "&PGGCodigo=" & Valor & """ target=""_blank"">" & Valor & "</a>"
        l.Text = Programas.LeerProgramasDescriptionByName(Valor)
        l.Text = l.Text & "<br />"
        l.Text = l.Text & "&nbsp;&nbsp;&nbsp;<a href=""ReportesPGG.aspx?PaginaWebName=" & "Ver Mapa" & "&PGGCodigo=" & Valor & """ target=""_blank"">" & "Mapa" & "</a>"
        l.Text = l.Text & "<br />"
        l.Text = l.Text & "&nbsp;&nbsp;&nbsp;<a href=""ReportesPGG.aspx?PaginaWebName=" & "Reporte SE1" & "&PGGCodigo=" & Valor & """ target=""_blank"">" & "Lista de Stakeholders" & "</a>"
        l.Text = l.Text & "<br />"
        l.Text = l.Text & "&nbsp;&nbsp;&nbsp;<a href=""ReportesPGG.aspx?PaginaWebName=" & "Reporte SE2" & "&PGGCodigo=" & Valor & """ target=""_blank"">" & "Priorización" & "</a>"
        l.Text = l.Text & "<br />"
        l.Text = l.Text & "&nbsp;&nbsp;&nbsp;<a href=""ReportesPGG.aspx?PaginaWebName=" & "Reporte SE3" & "&PGGCodigo=" & Valor & """ target=""_blank"">" & "Acciones por Stakeholders" & "</a>"
        l.Text = l.Text & "<br />"
        l.Text = l.Text & "&nbsp;&nbsp;&nbsp;<a href=""ReportesPGG.aspx?PaginaWebName=" & "Reporte SE4" & "&PGGCodigo=" & Valor & """ target=""_blank"">" & "Plan de Actividades" & "</a>"
        'l.Text = l.Text & "<br />"
        'l.Text = l.Text & "&nbsp;&nbsp;&nbsp;<a href=""ReportesPGG.aspx?PaginaWebName=" & "Reporte SE4 Avance" & "&PGGCodigo=" & Valor & """ target=""_blank"">" & "Reporte de Seguimiento" & "</a>"
        l.Text = l.Text & "<br />"
        l.Text = l.Text & "&nbsp;&nbsp;&nbsp;<a href=""IndexSGI.aspx?PaginaWebName=DocumentosPorPrograma&MenuOptionsId=431&PGGCodigo=" & Valor & """ >" & "Documentos" & "</a>"
        'l.Text = l.Text & "<br />"
        'l.Text = l.Text & "&nbsp;&nbsp;&nbsp;<a href=""*"" >" & "Lista de Tareas" & "</a>"
    End Sub
End Class
