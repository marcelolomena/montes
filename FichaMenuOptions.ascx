<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FichaMenuOptions.ascx.vb" Inherits="FichaMenuOptions" %>
<! -- Código generado por ZRISMART SF el 29-08-2011 8:50:43 -->
<! -- Código generado por ZRISMART SF el 23-08-2011 23:42:16 -->
<script type="text/javascript">
    function PanelClick(sender, e) {
    }
    function ActiveTabChanged(sender, e) {
    }
    function OnCompleteImportanciaUpdate(arg) {
        // var cajadiv = "div#ListaCarpetas";
        document.getElementById(ListaCarpetas).innerHTML = arg;
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
<table cellspacing="2" cellpadding="2" border="0" style="width:700px;">
	<tr>
		<td class="textocontgris10bold" style="text-align:right;width:10%;">Opción Superior</td>
        <td style="width:40%;"><asp:TextBox ID="txtOpcionSuperior" ClientIDMode="Static" 
                name="txtOpcionSuperior" runat="server" Enabled="false" Rows="3"  
                class="textoboxgris" style="width:500px;" TextMode="MultiLine" ></asp:TextBox></td>
	</tr>
    <asp:TextBox ID="txtOpcion" runat="server" Visible="false"></asp:TextBox>
    <asp:HiddenField ID="txtMenuOptionsPId" ClientIDMode="Static" runat="server" />
</table>
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