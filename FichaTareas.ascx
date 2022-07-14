<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FichaTareas.ascx.vb" Inherits="FichaTareas" %>
<! -- Código generado por ZRISMART SF el 24-04-2011 8:52:25 -->
<script type="text/javascript">
function PanelClick(sender, e) {
}
function ActiveTabChanged(sender, e) {
}
</script>
<script type="text/vbscript" language="vbscript">
Sub RutValidator_ClientValidate(s, e)
e.IsValid = True
End Sub
</script>
<asp:PlaceHolder ID="MyDeudor" runat="server"></asp:PlaceHolder>
<asp:PlaceHolder ID="MyActivities" runat="server"></asp:PlaceHolder>
<table border="0" cellpadding="0" cellspacing="0" class="popups_titulo_con_enlaces">
<tr>
<td><h1>Comentarios, correos, mensajes al muro y alertas de fechas cr&iacute;ticas</h1></td>
<td align= "right"><img src="imgs/expandir.png" width="25" height="25" alt="Expandir" onclick="aparecer('subgrillaMisComentarios')" /></td>
</tr>
</table>
<div id="subgrillaMisComentarios" class="invisible">
<asp:PlaceHolder ID="MisComentarios" runat="server"></asp:PlaceHolder>
</div>
<asp:PlaceHolder ID="MyView" runat="server"></asp:PlaceHolder>
<asp:Label ID="MyMessage1" runat="server" CssClass="subtit"></asp:Label>
<asp:PlaceHolder ID="MyTask" runat="server"></asp:PlaceHolder>
<asp:table id="MyTabs" runat="server" width="100%" cellspacing="2" cellpadding="2" />
<asp:PlaceHolder ID="MyFormulario" runat="server"></asp:PlaceHolder>
