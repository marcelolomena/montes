<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FichaAcciones.aspx.vb" Inherits="FichaAcciones" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Definición de Acciones dentro de una Etapa de un Proceso Judicial</title>
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
                $get("txtAccionesId").value = arg[0];
                $get("txtAccionesCodigo").value = arg[1];
                $get("txtAccionesName").value = arg[2];
                $(document).ready(function () {
                    if (arg[2] != "") {
                        $("#txtAccionesName").attr("disabled", true);
                    }
                    else {
                        $("#txtAccionesName").removeAttr("disabled");
                    }
                });
                $get("txtAccionesDescription").value = arg[3];
                $get("txtAccionesSecuencia").value = arg[4];
                $get("txtTipoProcesoSecuencia").value = arg[5];
                $get("txtEtapasSecuencia").value = arg[6];
                $get("txtEtapasName").value = arg[7];
                $get("txtEtapasId").value = arg[8];
                $get("txtRolName").value = arg[9];
                $get("txtRolNameDescription").value = "";
                $get("txtPaginaWebName").value = arg[10];
                $get("txtPaginaWebNameDescription").value = arg[10];
                $get("txtAccionesDuration").value = arg[11];
                $get("chkAccionesEnviaCorreo").checked = false;
                $get("chkAccionesAdvertirFechaFatal").checked = false;
                $get("chkAccionesIsFlujoAlternativo").checked = false;
                if (arg[12] == "true") {
                    $get("chkAccionesEnviaCorreo").checked = true;
                }
                if (arg[13] == "true") {
                    $get("chkAccionesAdvertirFechaFatal").checked = true;
                }
                if (arg[14] == "true") {
                    $get("chkAccionesIsFlujoAlternativo").checked = true;
                }
            }
        }
        function OnTimeOuteditbutton(arg) {
            alert("TimeOut al invocar el servicio de lectura de una acci&oacute;n");
        }
        function OnErroreditbutton(arg) {
            alert("Error encontrado al invocar el servicio de lectura de una acci&oacute;n");
        }
        function editbutton(AccionesId) {
            ret = SimpleService.LeerAcciones(AccionesId, OnCompleteeditbutton, OnTimeOuteditbutton, OnErroreditbutton);
            return (true);
        }
        function OnCompleteNewButton(arg) {
            if (arg != null) {
                $get("txtAccionesId").value = arg[0];
                $get("txtAccionesCodigo").value = arg[1];
                $get("txtAccionesName").value = arg[2];
                $(document).ready(function () {
                    $("#txtAccionesName").removeAttr("disabled");
                });
                $get("txtAccionesDescription").value = arg[3];
                $get("txtAccionesSecuencia").value = arg[4];
                $get("txtTipoProcesoSecuencia").value = arg[5];
                $get("txtEtapasSecuencia").value = arg[6];
                $get("txtEtapasName").value = arg[7];
                $get("txtEtapasId").value = arg[8];
                $get("txtRolName").value = arg[9];
                $get("txtRolNameDescription").value = "";
                $get("txtPaginaWebName").value = arg[10];
                $get("txtPaginaWebNameDescription").value = "";
                $get("txtAccionesDuration").value = arg[11];
                $get("chkAccionesEnviaCorreo").checked = false;
                $get("chkAccionesAdvertirFechaFatal").checked = false;
                $get("chkAccionesIsFlujoAlternativo").checked = false;
                // var cajadiv = "div#ListaCarpetas";
                document.getElementById("ListaCarpetas").innerHTML = arg[15];
            }
        }
        function OnTimeOutNewButton(arg) {
            alert("TimeOut al invocar el servicio de inserción de una acción");
        }
        function OnErrorNewButton(arg) {
            alert("Error encontrado al invocar el servicio de inserción de una acción");
        }
        function NewButton(UsuariosId) {
            ret = SimpleService.AccionesInsert(UsuariosId, $get("txtTipoProcesoSecuencia").value, $get("txtEtapasId").value, OnCompleteNewButton, OnTimeOutNewButton, OnErrorNewButton);
            return (true);
        }
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
        <!-- <center><asp:PlaceHolder ID="MyDeudor" runat="server"></asp:PlaceHolder></center> -->
        <div id="ListaCarpetas"><asp:PlaceHolder ID="MyResponsable" runat="server"></asp:PlaceHolder></div> 
        <asp:PlaceHolder ID="MyTask" runat="server"></asp:PlaceHolder>        
        <asp:Label ID="MyMessage1" runat="server" CssClass="subtit"></asp:Label>
    </form>
</body>
</html>
