<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ListaMenuOptions.ascx.vb" Inherits="ListaMenuOptions" %>
<script type="text/javascript">
    function PanelClick(sender, e) {
    }
    function ActiveTabChanged(sender, e) {
    }
    function OnCompleteImportanciaUpdate(arg) {
        var cajadiv = "div#ListaCarpetas";
        // $(cajadiv).html(arg);
        document.getElementById("ListaCarpetas").innerHTML = arg;
    }
    function OnTimeOutImportanciaUpdate(arg) {
        alert("TimeOut al invocar el servicio");
    }
    function OnErrorImportanciaUpdate(arg) {
        alert("Error encontrado al invocar el servicio");
    }
    function MenuOptionsUpdateSecuencia(MenuOptionsId, Id, UserId) {
        var CajaTexto = "txtInputbox" + MenuOptionsId;
        if ($get(CajaTexto).value < 1) {
            alert("Valor debe ser mayor a 0");
            $get(CajaTexto).focus();
            return (false);
        }
        else {
            ret = SimpleService.MenuOptionsUpdateSecuencia(MenuOptionsId, Id, $get(CajaTexto).value, UserId, OnCompleteImportanciaUpdate, OnTimeOutImportanciaUpdate, OnErrorImportanciaUpdate);
            return (true);
        }

    }
</script>
<h1>Lista de Opciones de Menú</h1>
<br />
<asp:Label ID="lblLinkNuevo" runat="server" CssClass="contenidos"></asp:Label>
<br />
<asp:PlaceHolder ID="MyTable" runat="server"></asp:PlaceHolder>