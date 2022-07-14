<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FichaEtapas.aspx.vb" Inherits="FichaEtapas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Definición de Etapas de un Proceso Judicial</title>
    <style type="text/css">HTML {width:47em; height:45em;}</style>
    <link rel="stylesheet" type="text/css" href="Styles/stylesheet.css" />
    <link href="SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css" />
    <script src="SpryAssets/SpryAccordion.js" type="text/javascript"></script>
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="Scripts/AC_RunActiveContent.js"></script>
    <script type="text/javascript" language="javascript">
        function aparecer(submenus) {

            if (document.getElementById(submenus).className == "visible") {
                document.getElementById(submenus).className = "invisible";
            } else {
                document.getElementById(submenus).className = "visible";
            }
        }

        function desaparecer(submenus) {

            if (document.getElementById(submenus).className == "visible") {
                document.getElementById(submenus).className = "invisible";
            } else {
                document.getElementById(submenus).className = "invisible";
            }
        }

        function todosvisibles(submenus) {

            if (document.getElementById(submenus).className == "visible") {
                document.getElementById(submenus).className = "visible";
            } else {
                document.getElementById(submenus).className = "visible";
            }
        }
        function MM_preloadImages() { //v3.0
            var d = document; if (d.images) {
                if (!d.MM_p) d.MM_p = new Array();
                var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                    if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; }
            }
        }

        function OnCompleteeditbutton(arg) {
            if (arg != null) {
                $get("txtEtapasId").value = arg[0];
                $get("txtEtapasName").value = arg[1];
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
                // $get("txtTipoProcesoId").value = arg[6];
                // $get("txtTipoProcesoName").value = arg[7];
               //  var cajadiv = "div#ListaAcciones";
                document.getElementById("ListaAcciones").innerHTML = arg[6];
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
            ret = SimpleService.LeerEtapaAnterior(UsuariosId, $get("txtEtapasId").value, $get("txtEtapasSecuencia").value, <%= Request.QueryString("TipoProcesoId") %>, "aspx", OnCompleteeditbutton, OnTimeOuteditbutton, OnErroreditbutton);
            return (true);
        }
        function LeerSiguiente(UsuariosId) {
            ret = SimpleService.LeerEtapaSiguiente(UsuariosId, $get("txtEtapasId").value, $get("txtEtapasSecuencia").value, <%= Request.QueryString("TipoProcesoId") %>, "aspx", OnCompleteeditbutton, OnTimeOuteditbutton, OnErroreditbutton);
            return (true);
        }
        function OnCompleteNewButton(arg) {
            if (arg != null) {
                $get("txtEtapasId").value = arg[0];
                $get("txtEtapasName").value = arg[1];
                $(document).ready(function () {
                    $("#txtEtapasName").removeAttr("disabled");
                });
                $get("txtEtapasDescription").value = arg[2];
                $get("txtEtapasSecuencia").value = arg[3];
                $get("txtEtapasPreCondiciones").value = arg[4];
                $get("txtEtapasPostCondiciones").value = arg[5];
                // $get("txtTipoProcesoId").value = arg[6];
                // $get("txtTipoProcesoName").value = arg[7];
                // var cajadiv = "div#ListaCarpetas";
                document.getElementById("ListaCarpetas").innerHTML = arg[6];
                // var cajadiv = "div#ListaAcciones";
                document.getElementById("ListaAcciones").innerHTML = arg[7];
            }
        }
        function OnTimeOutNewButton(arg) {
            alert("TimeOut al invocar el servicio de lectura de una etapa");
        }
        function OnErrorNewButton(arg) {
            alert("Error encontrado al invocar el servicio de lectura de una etapa");
        }
        function NewButton(UsuariosId) {
            ret = SimpleService.EtapasInsert(UsuariosId, <%= Request.QueryString("TipoProcesoId") %>, OnCompleteNewButton, OnTimeOutNewButton, OnErrorNewButton);
            return (true);
        }
        function verModalAccionEtapas(urlName, UsuariosId, TipoProcesoId) {
            var vals;
            vals = window.showModalDialog(urlName);
            refrescarAcciones(UsuariosId, TipoProcesoId);
        }
        function OnCompleterefrescarAcciones(arg) {
            // var cajadiv = "div#ListaAcciones";
            document.getElementById("ListaAcciones").innerHTML = arg;
        }
        function OnTimeOutrefrescarAcciones(arg) {
            alert("TimeOut al invocar el servicio");
        }
        function OnErrorrefrescarAcciones(arg) {
            alert("Error encontrado al invocar el servicio");
        }
        function refrescarAcciones(UsuariosId, TipoProcesoId) {
            ret = SimpleService.ListarAccionesPorEtapas($get("txtEtapasId").value, TipoProcesoId, UsuariosId, "aspx", OnCompleterefrescarAcciones, OnTimeOutrefrescarAcciones, OnErrorrefrescarAcciones);
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

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
           <Services>
                <asp:ServiceReference Path="~/Services/CintacDataBroker.asmx" />
                <asp:ServiceReference Path="AutoCompleteTitulo.asmx" /> 
                <asp:ServiceReference Path="SimpleService.asmx" />   
            </Services>            
            <Scripts>
                <asp:ScriptReference Path="FuncionesJScript.js" />
            </Scripts>
        </asp:ScriptManager>    
        <asp:PlaceHolder ID="MyScript" runat="server"></asp:PlaceHolder>
        <!-- <center><asp:PlaceHolder ID="MyDeudor" runat="server"></asp:PlaceHolder></center>
         <div id="ListaCarpetas"><asp:PlaceHolder ID="MyResponsable" runat="server"></asp:PlaceHolder></div> -->
        <asp:PlaceHolder ID="MyTask" runat="server"></asp:PlaceHolder>        
        <asp:Label ID="MyMessage1" runat="server" CssClass="subtit"></asp:Label>
        <div id="ListaAcciones"><asp:PlaceHolder ID="MyEtapas" runat="server"></asp:PlaceHolder></div>
    </form>
</body>
</html>
