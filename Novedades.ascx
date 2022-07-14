<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Novedades.ascx.vb" Inherits="Novedades" %>
<script language="JavaScript" type="text/JavaScript">
<!--
    function UpdateNovedades(ProgramasId, UserId) {
        var CajaTexto = "txtNovedades";
        ret = SimpleService.UpdateNovedades($get(CajaTexto).value, ProgramasId, UserId,  OnCompleteNovedades, OnTimeOutNovedades, OnErrorNovedades);
        return (true);
    }
    function OnCompleteNovedades(arg) {
        $get("txtNovedades").value = "Ingrese una nueva novedad para el programa";
        $("div#ListaNovedades").html(arg);
    }
    function OnTimeOutNovedades(arg) {
        alert("TimeOut al invocar el servicio");
    }
    function OnErrorNovedades(arg) {
        alert("Error encontrado al invocar el servicio");
    }
    function DeleteNovedades(Id, ProgramasId, UserId) {
        ret = SimpleService.DeleteNovedades(Id, ProgramasId, UserId, OnCompleteNovedades, OnTimeOutNovedades, OnErrorNovedades);
        return (true);
    }
    function ListarNovedadesTodas(ProgramasId, UserId) {
        ret = SimpleService.ListarNovedadesTodas(ProgramasId, UserId, OnCompleteNovedades, OnTimeOutNovedades, OnErrorNovedades);
        return (true);
    }


// -->
</script>
<br />
<asp:PlaceHolder ID="MyTable" runat="server"></asp:PlaceHolder>