<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MantencionProcesos.ascx.vb" Inherits="MantencionProcesos" %>
    <script type="text/javascript" language="javascript">

        function verModalAccion(urlName) {
            var vals;
            vals = window.showModalDialog(urlName);
        }

        function verModalTipoProceso(urlName) {
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
            ret = SimpleService.ListarTiposDeProcesos(OnCompleterefrescar, OnTimeOutrefrescar, OnErrorrefrescar);
            return (true);
        }


    </script>
    <table width="660" border="0" cellpadding="0" cellspacing="0" class="popups_titulo_con_enlaces">
        <tr>
            <td width="100%"><h1>Etapas y Actividades de los procesos judiciales</h1></td>
        </tr>
    </table>
<div id="ListaTareasPendientes"><asp:PlaceHolder ID="MyAccordion" runat="server"></asp:PlaceHolder></div>