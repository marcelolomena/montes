<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FichaOrganizaciones.ascx.vb" Inherits="FichaOrganizaciones" %>
<! -- Código generado por ZRISMART SF el 24-07-2011 9:24:09 -->
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
<asp:PlaceHolder ID="MyView" runat="server"></asp:PlaceHolder>
<asp:table id="MyTabs" runat="server" width="100%" cellspacing="2" cellpadding="2" />
<asp:PlaceHolder ID="MyFormulario" runat="server"></asp:PlaceHolder>
<br />
<asp:Label ID="MyMessage1" runat="server" CssClass="subtit"></asp:Label>
<br />