<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PerfilJuicio.ascx.vb" Inherits="PerfilJuicio" %>
    <script type="text/javascript" language="javascript">

        function verModalAccion(urlName) {
            var vals;
            vals = window.showModalDialog(urlName);
        }


    </script>
    <table width="660" border="0" cellpadding="0" cellspacing="0" class="popups_titulo_con_enlaces">
        <tr>
            <td width="100%"><h1>Etapas y Actividades de los procesos judiciales</h1></td>
        </tr>
    </table>
<asp:PlaceHolder ID="MyAccordion" runat="server"></asp:PlaceHolder>