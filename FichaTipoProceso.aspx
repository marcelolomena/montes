<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FichaTipoProceso.aspx.vb" Inherits="FichaTipoProceso" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Definición de Tipos de Procesos</title>
    <style type="text/css">HTML {width:47em; height:45em;}</style>
    <link rel="stylesheet" type="text/css" href="Styles/stylesheet.css" />
    <link href="SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css" />
    <script src="SpryAssets/SpryAccordion.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/jquery-1.9.1.js" type="text/javascript"></script>
    <script src="http://code.jquery.com/ui/1.10.3/jquery-ui.js" type="text/javascript"></script>

      <script type="text/javascript">
          $(function () {
              var icons = {
                  header: "ui-icon-circle-arrow-e",
                  activeHeader: "ui-icon-circle-arrow-s"
              };
              $("#accordion").accordion({
                  heightStyle: "content",
                  icons: icons
              });
          });
      </script>


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
                $get("txtTipoProcesoId").value = arg[0];
                $get("txtTipoProcesoName").value = arg[1];
                $(document).ready(function () {
                    if (arg[1] != "") {
                        $("#txtTipoProcesoName").attr("disabled", true);
                    }
                    else {
                        $("#txtTipoProcesoName").removeAttr("disabled");
                    }
                });
                $get("txtTipoProcesoDescription").value = arg[2];
                $get("txtTipoProcesoSecuencia").value = arg[3];
                $get("txtClaseProcesoName").value = arg[4];
                $get("txtClaseProcesoNameDescription").value = "";
                $get("txtAccionesCodigo").value = arg[5];
                $get("txtAccionesCodigoDescription").value = "";
                var cajadiv = "div#ListaEtapas";
                // $(cajadiv).html(arg[6]);
                document.getElementById("ListaEtapas").innerHTML = arg[6];
                
            }
        }
        function OnTimeOuteditbutton(arg) {
            alert("TimeOut al invocar el servicio de lectura de un tipo de proceso");
        }
        function OnErroreditbutton(arg) {
            alert("Error encontrado al invocar el servicio de lectura de un tipo de proceso");
        }
        function editbutton(TipoProcesoId) {
            ret = SimpleService.LeerTipoProceso(TipoProcesoId, OnCompleteeditbutton, OnTimeOuteditbutton, OnErroreditbutton);
            return (true);
        }
        function LeerAnterior(UsuariosId) {
            ret = SimpleService.LeerTipoProcesoAnterior(UsuariosId, $get("txtTipoProcesoId").value, $get("txtTipoProcesoSecuencia").value, OnCompleteeditbutton, OnTimeOuteditbutton, OnErroreditbutton);
            return (true);
        }
        function LeerSiguiente(UsuariosId) {
            ret = SimpleService.LeerTipoProcesoSiguiente(UsuariosId, $get("txtTipoProcesoId").value, $get("txtTipoProcesoSecuencia").value, OnCompleteeditbutton, OnTimeOuteditbutton, OnErroreditbutton);
            return (true);
        }


        function OnCompleteNewButton(arg) {
            if (arg != null) {
                $get("txtTipoProcesoId").value = arg[0];
                $get("txtTipoProcesoName").value = arg[1];
                $(document).ready(function () {
                    $("#txtTipoProcesoName").removeAttr("disabled");
                });
                $get("txtTipoProcesoDescription").value = arg[2];
                $get("txtTipoProcesoSecuencia").value = arg[3];
                $get("txtClaseProcesoName").value = arg[4];
                $get("txtClaseProcesoNameDescription").value = "";
                $get("txtAccionesCodigo").value = arg[5];
                $get("txtAccionesCodigoDescription").value = "";
                var cajadiv = "div#ListaCarpetas";
                // $(cajadiv).html(arg[6]);
                document.getElementById("ListaCarpetas").innerHTML = arg[6];
                var cajadiv = "div#ListaEtapas";
                // $(cajadiv).html(arg[7]);
                document.getElementById("ListaEtapas").innerHTML = arg[7];
            }
        }
        function OnTimeOutNewButton(arg) {
            alert("TimeOut al invocar el servicio de lectura de un tipo de proceso");
        }
        function OnErrorNewButton(arg) {
            alert("Error encontrado al invocar el servicio de lectura de un tipo de proceso");
        }
        function NewButton(UsuariosId) {
            ret = SimpleService.TipoProcesoInsert(UsuariosId, OnCompleteNewButton, OnTimeOutNewButton, OnErrorNewButton);
            return (true);
        }
        function verModalEtapasTipoProceso(urlName, UsuariosId) {
            var vals;
            vals = window.showModalDialog(urlName,'','location:no');
            refrescarEtapas(UsuariosId);
        }
        function OnCompleterefrescarEtapas(arg) {
            var cajadiv = "div#ListaEtapas";
            // $(cajadiv).html(arg);
            document.getElementById("ListaEtapas").innerHTML = arg;
        }
        function OnTimeOutrefrescarEtapas(arg) {
            alert("TimeOut al invocar el servicio");
        }
        function OnErrorrefrescarEtapas(arg) {
            alert("Error encontrado al invocar el servicio");
        }
        function refrescarEtapas(UsuariosId) {
            ret = SimpleService.ListarEtapasPorTipoProceso($get("txtTipoProcesoId").value, UsuariosId,  OnCompleterefrescarEtapas, OnTimeOutrefrescarEtapas, OnErrorrefrescarEtapas);
            return (true);
        }



    </script>  
<script language="JavaScript" type="text/JavaScript">
<!--
    function EtapasPorTipoProcesoUpdate(TipoProcesoId, EtapasId, UserId) {
        ret = SimpleService.EtapasPorTipoProcesoUpdate(TipoProcesoId, EtapasId,  0, UserId, OnCompleteImportanciaUpdate, OnTimeOutImportanciaUpdate, OnErrorImportanciaUpdate);
        return (true);
    }
    function OnCompleteImportanciaUpdate(arg) {
        var cajadiv = "div#ListaEtapas";
        // $(cajadiv).html(arg);
        document.getElementById("ListaEtapas").innerHTML = arg;
    }
    function OnTimeOutImportanciaUpdate(arg) {
        alert("TimeOut al invocar el servicio");
    }
    function OnErrorImportanciaUpdate(arg) {
        alert("Error encontrado al invocar el servicio");
    }
    function EtapasPorTipoProcesoUpdateSecuencia(TipoProcesoId, EtapasId, UserId) {
        var CajaTexto = "txtInputbox" + MenuOptionsId;
        if ($get(CajaTexto).value < 1) {
            alert("Valor debe ser mayor a 0");
            $get(CajaTexto).focus();
            return (false);
        }
        else {
            ret = SimpleService.EtapasPorTipoProcesoUpdateSecuencia(TipoProcesoId, EtapasId, $get(CajaTexto).value, UserId, OnCompleteImportanciaUpdate, OnTimeOutImportanciaUpdate, OnErrorImportanciaUpdate);
            return (true);
        }

    }
// -->
</script>   

</head>
<body style="border-left:5px">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <Services>
                <asp:ServiceReference Path="SimpleService.asmx" />   
            </Services>            
            <Scripts>
                <asp:ScriptReference Path="FuncionesJScript.js" />
            </Scripts>
        </asp:ScriptManager>    
        <asp:PlaceHolder ID="MyScript" runat="server"></asp:PlaceHolder>
        <asp:PlaceHolder ID="MyTask" runat="server"></asp:PlaceHolder>        
        <div id="ListaEtapas"><asp:PlaceHolder ID="MyEtapas" runat="server"></asp:PlaceHolder></div>                
        <asp:Label ID="MyMessage1" runat="server" CssClass="subtit"></asp:Label>

    </form>
</body>
</html>
