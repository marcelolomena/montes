<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Entidades.ascx.vb" Inherits="Entidades" %>
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
<!-- <asp:table id="MyTable" runat="server" width="100%" cellspacing="2" cellpadding="2" /> -->
<asp:PlaceHolder ID="MyView" runat="server"></asp:PlaceHolder>
<asp:table id="MyTabs" runat="server" width="100%" cellspacing="2" cellpadding="2" />
<!-- Se usa sólo para mostrar el formulario de una página web -->
<asp:PlaceHolder ID="MyFormulario" runat="server"></asp:PlaceHolder>
