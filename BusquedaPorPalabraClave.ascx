<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BusquedaPorPalabraClave.ascx.vb" Inherits="BusquedaPorPalabraClave" %>
<script language="JavaScript" type="text/JavaScript">
<!--
    function BuscarDocumentos(UserId) {
        var CajaTexto = "txtPalabrasClaves";
        ret = SimpleService.BuscarDocumentos($get(CajaTexto).value, UserId, OnCompleteBusqueda, OnTimeOutBusqueda, OnErrorBusqueda);
        return (true);
    }
    function OnCompleteBusqueda(arg) {
        $get("txtPalabrasClaves").value = "";
        document.getElementById("ListaDocumentos").innerHTML = arg;
    }
    function OnTimeOutBusqueda(arg) {
        alert("TimeOut al invocar el servicio de búsqueda");
    }
    function OnErrorBusqueda(arg) {
        alert("Error encontrado al invocar el servicio de búsqueda");
    }
    function verTareaModal(urlName) {
        var vals;
        vals = window.showModalDialog(urlName);
        refrescarnotasbuscar(vals);
    }
    function OnCompleteRefrescarnotasbuscar(arg) {
        //var cajadiv = "div#ListaNotas";
        document.getElementById("ListaNotas").innerHTML = arg;
    }
    function OnTimeOutRefrescarnotasbuscar(arg) {
        alert("TimeOut al invocar el servicio de refrescar notas");
    }
    function OnErrorRefrescarnotasbuscar(arg) {
        alert("Error encontrado al invocar el servicio de refrescar notas");
    }
    function refrescarnotasbuscar(UsuariosCodigo) {
        ret = SimpleService.MostrarNotasTransversales(UsuariosCodigo, OnCompleteRefrescarnotasbuscar, OnTimeOutRefrescarnotasbuscar, OnErrorRefrescarnotasbuscar);
        return (true);
    }


    // function doEnter(UserId, e) {
        //the purpose of this function is to allow the enter key to 
        //point to the correct button to click.
        //var key;

        //if (window.event)
            //key = window.event.keyCode;     //IE
        //else
            //key = e.which;     //firefox

        //if (key == 13) {
            //event.keyCode = 0;            
            //BuscarDocumentos(UserId);
            //}
        //}



// -->
</script>
<br />
<asp:PlaceHolder ID="MyTable" runat="server"></asp:PlaceHolder>