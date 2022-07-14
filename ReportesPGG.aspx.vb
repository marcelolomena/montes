
Partial Class ReportesPGG
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ctlControl As Control
        Dim Lecturas As New Lecturas
        Dim PaginaWebUserControl As String = ""

        Try
            If Lecturas.PageUserControl(Request.QueryString("PaginaWebName"), PaginaWebUserControl) Then
                ctlControl = LoadControl(PaginaWebUserControl)
                PlaceHolder1.Controls.Add(ctlControl)
            Else
                ctlControl = LoadControl("PorDefinir.ascx")
                PlaceHolder1.Controls.Add(ctlControl)
                'PlaceHolder1.Controls.Add(New LiteralControl("<h1>Página en Construcción</h1>"))
            End If
        Catch ex As Exception
            PlaceHolder1.Controls.Add(New LiteralControl("<h1>Página en Construcción</h1>"))
        End Try
    End Sub


End Class
