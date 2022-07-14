<%@ Control Language="VB" AutoEventWireup="false" CodeFile="FichaEtapas.ascx.vb" Inherits="FichaEtapas" %>
<script type="text/javascript" language="javascript">
        function OnCompleteeditbutton(arg) {
            if (arg != null) {
                // var cajadiv = "div#MiMensaje1";
                document.getElementById("MiMensaje1").innerHTML = " ";               
                $get("txtEtapasId").value = arg[0];
                $get("txtEtapasName").value = arg[1];
                $get("HidEtapasId").value = arg[0];
                $get("HidEtapasName").value = arg[1];
                $(document).ready(function () {
                    if (arg[1] != "") {
                        $("#txtEtapasName").attr("disabled", true);
                    }
                    else {
                        $("#txtEtapasName").removeAttr("disabled");
                    }
                });
                $get("txtEtapasDescription").value = arg[2];
                $get("txtEtapasSecuencia").value = arg[3];
                $get("txtEtapasPreCondiciones").value = arg[4];
                $get("txtEtapasPostCondiciones").value = arg[5];
                $get("txtTipoProcesoId").value = arg[6];
                $get("txtTipoProcesoName").value = arg[7];
                // var cajadiv = "div#ListaAcciones";
                document.getElementById("ListaAcciones").innerHTML = arg[8];
            }
        }
        function OnTimeOuteditbutton(arg) {
            alert("TimeOut al invocar el servicio de lectura de una etapa");
        }
        function OnErroreditbutton(arg) {
            alert("Error encontrado al invocar el servicio de lectura de una etapa");
        }
        function editbutton(EtapasId) {
            ret = SimpleService.LeerEtapas(EtapasId, OnCompleteeditbutton, OnTimeOuteditbutton, OnErroreditbutton);
            return (true);
        }
        function LeerAnterior(UsuariosId) {
            ret = SimpleService.LeerEtapaAnterior(UsuariosId, $get("txtEtapasId").value, $get("txtEtapasSecuencia").value, $get("txtTipoProcesoId").value, "ascx", OnCompleteeditbutton, OnTimeOuteditbutton, OnErroreditbutton);
            return (true);
        }
        function LeerSiguiente(UsuariosId) {
            ret = SimpleService.LeerEtapaSiguiente(UsuariosId, $get("txtEtapasId").value, $get("txtEtapasSecuencia").value, $get("txtTipoProcesoId").value, "ascx", OnCompleteeditbutton, OnTimeOuteditbutton, OnErroreditbutton);
            return (true);
        }
        function OnCompleteNewButton(arg) {
            if (arg != null) {
                // var cajadiv = "div#MiMensaje1";
                document.getElementById("MiMensaje1").innerHTML = " "; 
                $get("txtEtapasId").value = arg[0];
                $get("txtEtapasName").value = arg[1];
                $get("HidEtapasId").value = arg[0];
                $get("HidEtapasName").value = arg[1];
                $(document).ready(function () {
                    $("#txtEtapasName").removeAttr("disabled");
                });
                $get("txtEtapasDescription").value = arg[2];
                $get("txtEtapasSecuencia").value = arg[3];
                $get("txtEtapasPreCondiciones").value = arg[4];
                $get("txtEtapasPostCondiciones").value = arg[5];
                $get("txtTipoProcesoId").value = arg[6];
                $get("txtTipoProcesoName").value = arg[7];
                // var cajadiv = "div#ListaCarpetas";
                document.getElementById("ListaCarpetas").innerHTML = arg[8];
                // var cajadiv = "div#ListaAcciones";
                document.getElementById("ListaAcciones").innerHTML = arg[9];
            }
        }
        function OnTimeOutNewButton(arg) {
            alert("TimeOut al invocar el servicio de lectura de una etapa");
        }
        function OnErrorNewButton(arg) {
            alert("Error encontrado al invocar el servicio de lectura de una etapa");
        }
        function NewButton(UsuariosId) {
            ret = SimpleService.EtapasInsert(UsuariosId, $get("txtTipoProcesoId").value, "ascx", OnCompleteNewButton, OnTimeOutNewButton, OnErrorNewButton);
            return (true);
        }
        function verModalAccionEtapas(urlName, UsuariosId, TipoProcesoId) {
            var vals;
            vals = window.showModalDialog(urlName);
            refrescarAcciones(UsuariosId, TipoProcesoId);
        }
        function OnCompleterefrescarAcciones(arg) {
            var cajadiv = "div#ListaAcciones";
            document.getElementById("ListaAcciones").innerHTML = arg;
        }
        function OnTimeOutrefrescarAcciones(arg) {
            alert("TimeOut al invocar el servicio");
        }
        function OnErrorrefrescarAcciones(arg) {
            alert("Error encontrado al invocar el servicio");
        }
        function refrescarAcciones(UsuariosId, TipoProcesoId) {
            ret = SimpleService.ListarAccionesPorEtapas($get("txtEtapasId").value, TipoProcesoId, UsuariosId, "ascx",  OnCompleterefrescarAcciones, OnTimeOutrefrescarAcciones, OnErrorrefrescarAcciones);
            return (true);
        }
</script>  
<script language="JavaScript" type="text/JavaScript">
<!--
    function AccionesPorEtapasPorTipoProcesoUpdate(EtapasPorTipoProcesoId, AccionesId, UserId) {
        ret = SimpleService.AccionesPorEtapasPorTipoProcesoUpdate(EtapasPorTipoProcesoId, AccionesId, 0, UserId, OnCompleteImportanciaUpdate, OnTimeOutImportanciaUpdate, OnErrorImportanciaUpdate);
        return (true);
    }
    function OnCompleteImportanciaUpdate(arg) {
        // var cajadiv = "div#ListaAcciones";
        document.getElementById("ListaAcciones").innerHTML = arg;
    }
    function OnTimeOutImportanciaUpdate(arg) {
        alert("TimeOut al invocar el servicio");
    }
    function OnErrorImportanciaUpdate(arg) {
        alert("Error encontrado al invocar el servicio");
    }
    function AccionesPorEtapasPorTipoProcesoUpdateSecuencia(EtapasPorTipoProcesoId, AccionesId, UserId) {
        var CajaTexto = "txtInputbox" + AccionesId;
        if ($get(CajaTexto).value < 1) {
            alert("Valor debe ser mayor a 0");
            $get(CajaTexto).focus();
            return (false);
        }
        else {
            ret = SimpleService.AccionesPorEtapasPorTipoProcesoUpdateSecuencia(EtapasPorTipoProcesoId, AccionesId, $get(CajaTexto).value, UserId, OnCompleteImportanciaUpdate, OnTimeOutImportanciaUpdate, OnErrorImportanciaUpdate);
            return (true);
        }
    }
// -->
</script>  
<asp:PlaceHolder ID="MyScript" runat="server"></asp:PlaceHolder>
<!-- <center><asp:PlaceHolder ID="MyDeudor" runat="server"></asp:PlaceHolder></center> -->
<div id="ListaCarpetas"><asp:PlaceHolder ID="MyResponsable" runat="server"></asp:PlaceHolder></div> 
<asp:PlaceHolder ID="MyTask" runat="server"></asp:PlaceHolder>        
<div id="MiMensaje1"><asp:PlaceHolder ID="MyMessage1" runat="server"></asp:PlaceHolder></div> 
<div id="ListaAcciones"><asp:PlaceHolder ID="MyEtapas" runat="server"></asp:PlaceHolder></div> 
<asp:HiddenField ID="HidEtapasId"  ClientIDMode="Static" runat="server" />
<asp:HiddenField ID="HidEtapasName" ClientIDMode="Static" runat="server" />