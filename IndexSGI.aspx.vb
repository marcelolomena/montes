
Partial Class IndexSGI
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim ctlControl As Control
        'Dim PaginaWeb As New PaginaWeb
        'Dim ProgramasId As Long = 0
        'Dim t As Boolean = False
        'Dim Programas As New Programas
        'ctlControl = LoadControl("BusquedaPorPalabraClave.ascx")
        'PlaceHolder1.Controls.Add(ctlControl)
        'If PaginaWeb.MostrarListaNovedades(Request.QueryString("PaginaWebName")) Then 'Se adiciona la lista de novedades por Programa
        '    If Request.QueryString("PaginaWebName") = "Ficha de Programas" Then
        '        ProgramasId = Request.QueryString("Id")
        '    Else
        '        t = Programas.LeerProgramasByName(ProgramasId, Request.QueryString("MasterName"))
        '    End If
        '    Session("ProgramasId") = ProgramasId
        '    ctlControl = LoadControl("Novedades.ascx")
        '    PlaceHolder1.Controls.Add(ctlControl)
        'End If
    End Sub
End Class
