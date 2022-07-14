<%@ Control Language="VB" AutoEventWireup="false" CodeFile="ListaTareasPendientes.ascx.vb" Inherits="ListaTareasPendientes" %>
<h1>Tareas Pendientes</h1>
<p>&nbsp;</p>
    <script type="text/javascript" language="javascript">

        function verModalTarea(urlName) {
            var vals;
            vals = window.showModalDialog(urlName);
            refrescarnotas(vals);            
            refrescar(vals);
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
        function refrescar(UsuariosCodigo) {
            ret = SimpleService.ListarTareasPendientes(UsuariosCodigo, OnCompleterefrescar, OnTimeOutrefrescar, OnErrorrefrescar);
            return (true);
        }

        function verModalMensaje(urlName) {
            var vals;
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
            ret = SimpleService.MostrarNotasTransversales(UsuariosCodigo, OnCompleteRefrescarnotas, OnTimeOutRefrescarnotas, OnErrorRefrescarnotas);
            return (true);
        }


    </script>
<asp:Label ID="lblMensaje" CssClass="tab_contenido" Visible="false" runat="server" Text="Label"></asp:Label>
<div id="ListaTareasPendientes"><asp:PlaceHolder ID="MyAccordion" runat="server"></asp:PlaceHolder></div>
