<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FichaFuncionesPorRol.ascx.vb" Inherits="FichaFuncionesPorRol" %>
<script type="text/javascript">
    function PanelClick(sender, e) {
    }

    function ActiveTabChanged(sender, e) {
    }
</script>
<asp:table id="MyTable" runat="server" width="100%" cellspacing="2" cellpadding="2" />
<asp:PlaceHolder ID="MyPerfil" runat="server"></asp:PlaceHolder>
<asp:table id="MyTabs" runat="server" width="100%" cellspacing="0" cellpadding="0" />
<script language="JavaScript" type="text/JavaScript">
<!-- 
function FuncionesPorRolUpdate(Rol,Funcion,Tabla,UserId) {  
    ret = SimpleService.FuncionesPorRolUpdate(Rol,Funcion,Tabla,UserId);
}

// -->
</script>