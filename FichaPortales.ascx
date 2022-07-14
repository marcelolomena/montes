<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FichaPortales.ascx.vb" Inherits="FichaPortales" %>
<! -- Código generado por ZRISMART SF el 29-08-2011 8:50:43 -->
<script type="text/javascript">
    function PanelClick(sender, e) {
    }
    function ActiveTabChanged(sender, e) {
    }
</script>
<script language="JavaScript" type="text/JavaScript">
<!--
    function FuncionesPorPortalUpdate(PortalesId, MenuOptionsId, UserId) {
            ret = SimpleService.FuncionesPorPortalUpdate(PortalesId, MenuOptionsId, 0, UserId,  OnCompleteImportanciaUpdate, OnTimeOutImportanciaUpdate, OnErrorImportanciaUpdate);
            return (true);
        }
    function OnCompleteImportanciaUpdate(arg) {
        // var cajadiv = "div#ListaCarpetas";
        document.getElementById("ListaCarpetas").innerHTML(arg);
    }
    function OnTimeOutImportanciaUpdate(arg) {
        alert("TimeOut al invocar el servicio");
    }
    function OnErrorImportanciaUpdate(arg) {
        alert("Error encontrado al invocar el servicio");
    }
    function FuncionesPorPortalUpdateSecuencia(PortalesId, MenuOptionsId, UserId) {
        var CajaTexto = "txtInputbox" + MenuOptionsId;
        if ($get(CajaTexto).value < 1) {
            alert("Valor debe ser mayor a 0");
            $get(CajaTexto).focus();
            return (false);
        }
        else {
            ret = SimpleService.FuncionesPorPortalUpdateSecuencia(PortalesId, MenuOptionsId, $get(CajaTexto).value, UserId, OnCompleteImportanciaUpdate, OnTimeOutImportanciaUpdate, OnErrorImportanciaUpdate);
            return (true);
        }

    }
// -->
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