<%@ Control Language="VB" AutoEventWireup="false" CodeFile="EstadoDiario.ascx.vb" Inherits="EstadoDiario" %>
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
         // var cajadiv = "div#ListaTareasPendientes";
         document.getElementById("ListaTareasPendientes").innerHTML = arg;
     }
     function OnTimeOutrefrescar(arg) {
         alert("TimeOut al invocar el servicio");
     }
     function OnErrorrefrescar(arg) {
         alert("Error encontrado al invocar el servicio");
     }
     function refrescar() {
         ret = SimpleService.ListarInformeEstadoDiarioPorTiposDeProcesos(OnCompleterefrescar, OnTimeOutrefrescar, OnErrorrefrescar);
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
                    <td width="84%"><h2>Informe de Estado Diario de los Procesos Judiciales Vigentes</h2></td>
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