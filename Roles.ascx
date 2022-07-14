<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Roles.ascx.vb" Inherits="Roles" %>
<! -- Código generado por ZRISMART SF el 23-08-2010 11:52:17 -->
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
<asp:Label ID="lblMensaje" runat="server" Text="Label"></asp:Label>