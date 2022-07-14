<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FichaMoneda.ascx.vb" Inherits="FichaMoneda" %>
<script type="text/javascript">
<! -- Código generado por ZRISMART SF el 01-02-2011 11:22:10 -->
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
