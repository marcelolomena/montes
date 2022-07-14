<%@ Control Language="VB" AutoEventWireup="false" CodeFile="noticias.ascx.vb" Inherits="noticias"  %>
<script language="JavaScript" type="text/JavaScript">
<!--
    function UpdateNota(UserId) {
        var CajaTexto = "txtNota";
        ret = SimpleService.UpdateNota($get(CajaTexto).value, UserId, OnCompleteNota, OnTimeOutNota, OnErrorNota);
        return (true);
    }
    function OnCompleteNota(arg) {
        $get("txtNota").value = "Ingrese una nueva nota";
        // $("div#ListaNotas").html(arg);
        document.getElementById("ListaNotas").innerHTML = arg;
    }
    function OnTimeOutNota(arg) {
        alert("TimeOut al invocar el servicio");
    }
    function OnErrorNota(arg) {
        alert("Error encontrado al invocar el servicio");
    }
    function DeleteNota(Id, UserId) {
        ret = SimpleService.DeleteNota(Id, UserId, OnCompleteNota, OnTimeOutNota, OnErrorNota);
        return (true);
    }
    function ListarTodas(UserId) {
        ret = SimpleService.ListarTodas(UserId, OnCompleteNota, OnTimeOutNota, OnErrorNota);
        return (true);
    }

// -->
</script>
<br />
<asp:PlaceHolder ID="MyTable" runat="server"></asp:PlaceHolder>