<%@ Control Language="VB" AutoEventWireup="false" CodeFile="PerfilUsuarios.ascx.vb" Inherits="PerfilUsuarios" %>
    <script type="text/javascript" language="javascript">

        function verModalTarea(urlName) {
            var vals;
            // vals = window.showModalDialog(urlName);
            vals = window.showModalDialog(urlName);
            refrescarnotas(vals);
            refrescar(vals);
        }

        function OnCompleterefrescar(arg) {
            var cajadiv = "div#subgrillaTareas";
            // $(cajadiv).html(arg);
            document.getElementById("subgrillaTareas").innerHTML = arg;
        }
        function OnTimeOutrefrescar(arg) {
            alert("TimeOut al invocar el servicio");
        }
        function OnErrorrefrescar(arg) {
            alert("Error encontrado al invocar el servicio");
        }
        function refrescar(UsuariosCodigo) {
            ret = SimpleService.MostrarTareasPendientesPorUsuario(UsuariosCodigo, OnCompleterefrescar, OnTimeOutrefrescar, OnErrorrefrescar);
            return (true);
        }

        function verModalMensaje(urlName) {
            var vals;
            // vals = window.showModalDialog(urlName);
            vals = window.showModalDialog(urlName);            
            refrescarnotas(vals);
        }
        function OnCompleteRefrescarnotas(arg) {
            // var cajadiv = "div#ListaNotas";
            document.getElementById("ListaNotas").innerHTML = arg;
        }
        function OnTimeOutRefrescarnotas(arg) {
            alert("TimeOut al invocar el servicio de refrescar notas");
        }
        function OnErrorRefrescarnotas(arg) {
            alert("Error encontrado al invocar el servicio de refrescar notas");
        }
        function refrescarnotas(UsuariosCodigo) {
            ret = SimpleService.MostrarNotasTransversales( UsuariosCodigo, OnCompleteRefrescarnotas, OnTimeOutRefrescarnotas, OnErrorRefrescarnotas);
            return (true);
        }

        function verModalAccion(urlName) {
            var vals;
            // vals = window.showModalDialog(urlName);
            vals = window.showModalDialog(urlName);
        }


    </script>          
          
          
          <table width="650" border="0" cellpadding="0" cellspacing="0" class="titulo_con_enlaces">
            <tr>
              <td width="404"><h1>Perfil de Usuarios</h1></td>
              <td width="246" align="right">&nbsp;</td>
              </tr>
            </table>
          <p><br />
            </p>
          <table width="650" border="0" cellpadding="0" cellspacing="0" class="tabla_de_stakeholders">
            <tr>
              <th width="111" rowspan="10"><img src="img/foto_perfil.jpg" width="111" height="96" alt="Foto Perfil" /></th>
              <th width="115">Nombre: </th>
              <th width="382"><asp:Label ID="lblUsuariosName" runat="server" Text="Label"></asp:Label></th>
              </tr>
            <tr>
              <td width="115">Rol: </td>
              <td width="382"><asp:Label ID="lblRolName" runat="server" Text="Label"></asp:Label><br /><asp:Label ID="lblRolDescription" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
              <td width="115">&nbsp;</td>
              <td width="382">&nbsp;</td>
            </tr>
            <tr>
              <td width="115"><h1>Correo: </h1></td>
              <td width="382"><asp:Label ID="lblUsuariosCodigo" runat="server" Text="Label"></asp:Label><br /><asp:Label ID="lblUsuariosCorreo2" runat="server" Text="Label"></asp:Label></td>
              </tr>
            <tr>
              <td width="115"><h1>Profesión: </h1></td>
              <td width="382"><asp:Label ID="lblUsuariosProfesion" runat="server" Text="Label"></asp:Label></td>
              </tr>
            <tr>
              <td width="115"><h1>Universidad: </h1></td>
              <td width="382"><asp:Label ID="lblUsuariosUniversidad" runat="server" Text="Label"></asp:Label></td>
              </tr>
            <tr>
              <td width="115"><h1>Celular: </h1></td>
              <td width="382"><asp:Label ID="lblUsuariosCelular" runat="server" Text="Label"></asp:Label></td>
              </tr>
            <tr>
              <td width="115"><h1>Teléfono Fijo: </h1></td>
              <td width="382"><asp:Label ID="lblUsuariosTelefonoFijo" runat="server" Text="Label"></asp:Label></td>
              </tr>
            <tr>
              <td width="115"><h1>Dirección 1: </h1></td>
              <td width="382"><asp:Label ID="lblUsuariosDireccion1" runat="server" Text="Label"></asp:Label></td>
              </tr>
            <tr>
              <td width="115"><h1>Dirección 2: </h1></td>
              <td width="382"><asp:Label ID="lblUsuariosDireccion2" runat="server" Text="Label"></asp:Label></td>
              </tr>
            </table>
          <p>&nbsp;</p>
<asp:PlaceHolder ID="MyAccordion" runat="server"></asp:PlaceHolder>