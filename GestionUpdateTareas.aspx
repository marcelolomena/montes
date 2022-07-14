<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GestionUpdateTareas.aspx.vb" Inherits="GestionUpdateTareas" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Gestión de Tareas</title>
    <style type="text/css">HTML {width:47em; height:45em;}</style>
    <link rel="stylesheet" type="text/css" href="Styles/stylesheet.css" />
    <link href="SpryAssets/SpryAccordion.css" rel="stylesheet" type="text/css" />
    <script src="SpryAssets/SpryAccordion.js" type="text/javascript"></script>
    <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="Scripts/AC_RunActiveContent.js"></script>
    <script type="text/javascript" language="javascript">
        function validaMail(email, n) {
            if (email != "") {
                if (!isMail(email)) {
                    alert('¡debe ingresar un Email válido!');
                    if (n == 1) {
                        form2.royMail.focus();
                    } else {
                        form3.royMail.focus();
                    }
                    return false;
                }
            }
        }
        function validaRut(rut, campo) {
            if (rut != "") {
                checkRutPersona(rut, campo);

            }

        }
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

        function verModalMensaje(urlName) {
            var vals;
            vals = window.showModalDialog(urlName);
            refrescarnotas();
        }
        function OnCompleteRefrescarnotas(arg) {
            //var cajadiv = "div#ListaCarpetas";
            document.getElementById("ListaCarpetas").innerHTML = arg;
        }
        function OnTimeOutRefrescarnotas(arg) {
            alert("TimeOut al invocar el servicio de refrescar la lista de actividades");
        }
        function OnErrorRefrescarnotas(arg) {
            alert("Error encontrado al invocar el servicio de refrescar la lista de actividades");
        }
        function refrescarnotas() {
            ret = SimpleService.ListarDatosDelResponsablePorTareasId($get("txtTareasCodigo").value, OnCompleteRefrescarnotas, OnTimeOutRefrescarnotas, OnErrorRefrescarnotas);
            return (true);
        }
        function verModalAccion(urlName) {
            var vals;
            vals = window.showModalDialog(urlName);
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
        
        <center><asp:PlaceHolder ID="MyDeudor" runat="server"></asp:PlaceHolder></center>
        <div id="ListaCarpetas"><asp:PlaceHolder ID="MyResponsable" runat="server"></asp:PlaceHolder></div>
        <table width="98%" class="visible" cellspacing="2" cellpadding="2" border="0" style="background-color:WhiteSmoke;border-color:WhiteSmoke;border-width:1px;border-style:Solid;">
            <tr valign="middle">
                <td class="textocontgris10bold"   style="text-align:right;">Tarea en curso</td>
                <td width="71%" valign="middle" style="height:20px;">
                    <asp:TextBox ID="txtTareasCodigo" ClientIDMode="Static" Width="500" Enabled="false" runat="server"></asp:TextBox>                
                </td>
            </tr>
            <tr valign="middle">
                <td class="textocontgris10bold" style="text-align:right;">
                    <input id="Button4" type="button" value="Consultar Procedimiento" class="boxceleste" onclick="verModalAccion('ConsultaAccion.aspx?Accion=<%= txtAccionesCodigo.text %>')" />                    
                </td>
                <td width="71%" valign="middle" style="height:20px;">
                    <asp:TextBox ID="txtAccionesCodigo" ClientIDMode="Static" Width="500" Enabled="false" runat="server"></asp:TextBox>                
                </td>
            </tr>                            
            <tr valign="middle">
                <td class="textocontgris10bold" style="text-align:right;">Usuario responsable</td>
                <td width="71%" valign="middle" style="height:20px;">
                    <asp:TextBox ID="txtUsuariosCodigo" ClientIDMode="Static" Width="500" Enabled="false" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr valign="middle">
                <td class="textocontgris10bold" style="text-align:right;">Estado Actual de la Tarea</td>
                <td width="71%" valign="middle" style="height:20px;">
                    <asp:TextBox ID="txtEstadoTareasCodigo" ClientIDMode="Static" Width="500" Enabled="false" runat="server"></asp:TextBox>  
                </td>
            </tr>                         
            <tr valign="middle">
                <td class="style1" style="text-align:left;"></td>
                <td width="71%" valign="middle" class="style2">
                        <input id="Button2" type="button" value="Agregar un Comentario" class="boxceleste" onclick="verModalMensaje('GestionCarpetaJudicial.aspx?Id=<%= Request.QueryString("Id") %>')" />
                        <input id="Button3" type="button" value="Salir" class="boxceleste" onclick="javascript:handleUpdateTareas($get('txtUsuariosCodigo').value);" /> 
                </td>
            </tr>
        </table>
        <asp:Label ID="MyMessage1" runat="server" CssClass="subtit"></asp:Label>
        <asp:PlaceHolder ID="MyTask" runat="server"></asp:PlaceHolder>
    </form>
</body>
</html>
