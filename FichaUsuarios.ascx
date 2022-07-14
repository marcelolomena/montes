<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FichaUsuarios.ascx.vb" Inherits="FichaUsuarios" %>
<script type="text/javascript">
<! -- Código generado por ZRISMART SF el 15-03-2011 8:31:37 -->
function PanelClick(sender, e) {
}
function ActiveTabChanged(sender, e) {
}
</script>
<script type="text/vbscript" language="vbscript">
Sub RutValidator_ClientValidate(s, e)
e.IsValid = True
</script>
<asp:PlaceHolder ID="MyView" runat="server"></asp:PlaceHolder>
<asp:table id="MyTabs" runat="server" width="100%" cellspacing="2" cellpadding="2" />
<asp:PlaceHolder ID="MyFormulario" runat="server"></asp:PlaceHolder>
