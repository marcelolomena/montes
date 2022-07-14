<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MovimientoDiario.ascx.vb" Inherits="MovimientoDiario" %>
<%@ Register src="BarraMenu.ascx" tagname="BarraMenu" tagprefix="uc1" %>
<%@ Register src="BarraSuperior.ascx" tagname="BarraSuperior" tagprefix="uc2" %>
<%@ Register src="BarraSubMenu.ascx" tagname="BarraSubMenu" tagprefix="uc9" %>

 <script type="text/javascript" language="javascript">

     function verModalTarea(urlName) {
         var vals;
         vals = window.showModalDialog(urlName);
         refrescar();
     }

     function OnCompleterefrescar(arg) {
         var cajadiv = "div#ListaTareasPendientes";
         // $(cajadiv).html(arg);
         document.getElementById("ListaTareasPendientes").innerHTML = arg;
     }
     function OnTimeOutrefrescar(arg) {
         alert("TimeOut al invocar el servicio");
     }
     function OnErrorrefrescar(arg) {
         alert("Error encontrado al invocar el servicio");
     }
     function refrescar() {
         ret = SimpleService.ListarInformeMovimientoDiarioPorTiposDeProcesos($get("txtFecha").value, OnCompleterefrescar, OnTimeOutrefrescar, OnErrorrefrescar);
         return (true);
     }

</script>

 <table width="960" border="0" cellpadding="0" cellspacing="0" class="caja_principal">
    <tr>
        <td class="caja_titulo_principal">

            

            <uc2:BarraSuperior ID="BarraSuperior1" runat="server" />

            
                    </td>
    </tr>
    <tr>
        <td class="caja_titulo_principal">

            <uc1:BarraMenu ID="BarraMenu1" runat="server" />

        </td>
    </tr>
    <tr>
        <td class="caja_titulo_principal">

            <uc9:BarraSubMenu ID="BarraMenu3" runat="server" />

        </td>
    </tr>
    <tr>
        <td>
            <table width="960" border="0" cellpadding="0" cellspacing="0" class="popups_titulo_con_enlaces">
                <tr>
                    <td>
                            <asp:table id="MyTable" runat="server" width="100%" cellspacing="2" cellpadding="2" />   
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <div id="ListaTareasPendientes"><asp:PlaceHolder ID="MyAccordion" runat="server"></asp:PlaceHolder></div>
        </td>
    </tr>
    <tr>
        <td class="caja_titulo_principal">

            <uc1:BarraMenu ID="BarraMenu2" runat="server" />

        </td>
    </tr>
</table>