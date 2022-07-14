<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FichaPaginaWeb.ascx.vb" Inherits="FichaPaginaWeb" %>
<! -- Código generado por ZRISMART SF el 29-08-2011 8:50:43 -->
<script type="text/javascript">
    function PanelClick(sender, e) {
    }
    function ActiveTabChanged(sender, e) {
    }
</script>
<asp:PlaceHolder ID="MyView" runat="server"></asp:PlaceHolder>
<br />
<asp:Label ID="lblLinkNuevo" runat="server" CssClass="contenidos"></asp:Label>
<br />
<asp:PlaceHolder ID="MyTable" runat="server"></asp:PlaceHolder>
<asp:table id="MyTabs" runat="server" width="100%" cellspacing="2" cellpadding="2" />
<asp:PlaceHolder ID="MyFormulario" runat="server"></asp:PlaceHolder>
<br />
<asp:Label ID="MyMessage1" runat="server" CssClass="subtit"></asp:Label>
<br />