<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FichaAreas.ascx.vb" Inherits="FichaAreas" %>
<script type="text/javascript">
<! -- Código generado por ZRISMART SF el 25-01-2011 9:45:32 -->
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