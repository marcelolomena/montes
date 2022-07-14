Partial Class BusquedaPorPalabraClave
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim NovedadesPorPrograma As New NovedadesPorPrograma
        Dim CodigoHTML As String = ""
        Dim DocumentosSGI As New DocumentosSGI
        Dim Stakeholders As New Stakeholders
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim AccionesABM As New AccionesABM
        Dim BuscarStakeholders As String = ""
        Dim BuscarJuicios As String = ""
        Dim BuscarDocumentos As String = ""
        Dim Usuarios As New Usuarios
        Dim StringBusqueda As String = Usuarios.LeerStringBusqueda(Session("PersonaId"))

        'onKeyPress=""doEnter(" & Session("PersonaId") & ", event);""

        If Len(StringBusqueda) < 3 Then
            CodigoHTML = CodigoHTML & "<table width=""240"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""busquedas"">"
            CodigoHTML = CodigoHTML & "<tr><td><label for=""busqueda""></label><input name=""txtPalabrasClaves"" type=""text"" id=""txtPalabrasClaves"" value=""Buscar"" title=""Ingrese una palabra clave de búsqueda"" onfocus=""if(!this._haschanged){this.value=''};this._haschanged=true;"" onblur=""BuscarDocumentos(" & Session("PersonaId") & ");"" /></td>"
            CodigoHTML = CodigoHTML & "<td width=""18""><img src=""img/lupa20x20.png"" alt=""Buscar"" width=""20"" height=""20"" border=""0"" title=""De un click de mousse para activar la búsqueda"" onclick=""BuscarDocumentos(" & Session("PersonaId") & ");"" /></td></tr></table>"
            CodigoHTML = CodigoHTML & "<br /><div id=""ListaDocumentos""></div>"
            MyTable.Controls.Add(New LiteralControl(CodigoHTML))
        Else
            CodigoHTML = CodigoHTML & "<table width=""240"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""busquedas"">"
            CodigoHTML = CodigoHTML & "<tr><td><label for=""busqueda""></label><input name=""txtPalabrasClaves"" type=""text"" id=""txtPalabrasClaves"" value=""" & StringBusqueda & """ title=""Ingrese una palabra clave de búsqueda"" onfocus=""if(!this._haschanged){this.value=''};this._haschanged=true;"" onblur=""BuscarDocumentos(" & Session("PersonaId") & ");"" /></td>"
            CodigoHTML = CodigoHTML & "<td width=""18""><img src=""img/lupa20x20.png"" alt=""Buscar"" width=""20"" height=""20"" border=""0"" title=""De un click de mousse para activar la búsqueda"" onclick=""BuscarDocumentos(" & Session("PersonaId") & ");"" /></td></tr></table>"
            CodigoHTML = CodigoHTML & "<br /><div id=""ListaDocumentos"">"
            BuscarDocumentos = DocumentosSGI.MostrarDocumentosPorPalabraClave(StringBusqueda, Session("PersonaId"))
            BuscarJuicios = CarpetaJudicial.MostrarCarpetaJudicialPorPalabraClave(StringBusqueda, Session("PersonaId"))
            BuscarDocumentos = BuscarDocumentos & BuscarJuicios
            CodigoHTML = CodigoHTML & BuscarDocumentos
            CodigoHTML = CodigoHTML & "</div>"
            MyTable.Controls.Add(New LiteralControl(CodigoHTML))
        End If
    End Sub
End Class
