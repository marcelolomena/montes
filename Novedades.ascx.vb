
Partial Class Novedades
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim NovedadesPorPrograma As New NovedadesPorPrograma
        Dim CodigoHTML As String = ""

        CodigoHTML = CodigoHTML & "<table width=""240"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""formulario_novedades"">"
        CodigoHTML = CodigoHTML & "<tr><th scope=""col"">Novedades</th></tr>"
        CodigoHTML = CodigoHTML & "<tr><td scope=""col"">&nbsp;</td></tr>"
        CodigoHTML = CodigoHTML & "<tr><td><textarea name=""txtNovedades"" id=""txtNovedades"" onfocus=""if(!this._haschanged){this.value=''};this._haschanged=true;"">Ingrese una nueva novedad para el programa</textarea></td></tr>"
        CodigoHTML = CodigoHTML & "<tr><td align=""right"">&nbsp;</td></tr>"
        CodigoHTML = CodigoHTML & "<tr><td align=""right""><span class=""submit""><input id=""SubmitNovedad"" type=""button"" value=""Agregar"" onclick=""UpdateNovedades(" & Session("ProgramasId") & ", " & Session("PersonaId") & ");"" /></span></td></tr>"
        CodigoHTML = CodigoHTML & "<tr><td align=""right"">&nbsp;</td></tr></table>"
        'CodigoHTML = CodigoHTML & "<table width=""240"" border=""0"" cellspacing=""0"" cellpadding=""0"">"
        'CodigoHTML = CodigoHTML & "<tr><td class=""rectangulo_titulos"">Nueva Novedad del Programa</td></tr></table>"
        'CodigoHTML = CodigoHTML & "<table width=""240"" border=""0"" cellpadding=""0"" cellspacing=""0"" id=""nueva_alerta"">"
        'CodigoHTML = CodigoHTML & "<tr><td><textarea name=""txtNovedades"" id=""txtNovedades"">Ingrese una nueva novedad para el programa</textarea></td></tr>"
        'CodigoHTML = CodigoHTML & "<tr><td align=""right""><span class=""submit""><input id=""SubmitNovedad"" type=""button"" value=""Agregar"" onclick=""UpdateNovedades(" & Session("ProgramasId") & ", " & Session("PersonaId") & ");"" /></span></td></tr></table>"
        CodigoHTML = CodigoHTML & "<div id=""ListaNovedades"">" & NovedadesPorPrograma.MostrarNovedadesPorPrograma(10, Session("ProgramasId"), Session("PersonaId")) & "</div>"
        MyTable.Controls.Add(New LiteralControl(CodigoHTML))
    End Sub
End Class
