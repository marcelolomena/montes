<%@ Page Language="VB" AutoEventWireup="false" CodeFile="GestionCarpetaJudicial.aspx.vb" Inherits="GestionCarpetaJudicial" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Consulta Carpeta Judicial</title>
    <style type="text/css">HTML {width:47em; height:45em;}
        #txtComentarios
        {
            width: 519px;
            height: 117px;
        }
        .style1
        {
            font-family: Verdana, Arial, Geneva, sans-serif;
            font-size: 11px;
            color: #666666;
            background-color: #FFFFFF;
            font-weight: normal;
            height: 20px;
        }
        .style2
        {
            height: 20px;
        }
    </style>
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
        function OnCompleteImportanciaUpdate(arg) {
            var cajadiv = "div#ListaCarpetas";
            // $(cajadiv).html(arg);
            document.getElementById("ListaCarpetas").innerHTML = arg;
        }
        function OnTimeOutImportanciaUpdate(arg) {
            alert("TimeOut al invocar el servicio");
        }
        function OnErrorImportanciaUpdate(arg) {
            alert("Error encontrado al invocar el servicio");
        }
        function UpdateTareasLog() {
            ret = SimpleService.UpdateTareasLog($get("txtTareasCodigo").value, $get("txtUsuariosCodigo").value, $get("txtRol").value, $get("txtComentarios").value, $get("chkCorreo").checked, $get("chkMuro").checked, $get("chkCritica").checked, $get("txtFecha").value, OnCompleteImportanciaUpdate,  OnTimeOutImportanciaUpdate, OnErrorImportanciaUpdate);
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

        <center><asp:PlaceHolder ID="MyDeudor" runat="server"></asp:PlaceHolder></center>
        <div id="ListaCarpetas"><asp:PlaceHolder ID="MyResponsable" runat="server"></asp:PlaceHolder></div>
        <table width="98%" class="visible" cellspacing="2" cellpadding="2" border="0" style="background-color:WhiteSmoke;border-color:WhiteSmoke;border-width:1px;border-style:Solid;">
            <tr valign="middle">
                <td class="textocontgris10bold" style="text-align:right;">Tarea en curso</td>
                <td width="71%" valign="middle" style="height:20px;">
                    <asp:TextBox ID="txtTareasCodigo" ClientIDMode="Static" Width="500" Enabled="false" runat="server"></asp:TextBox>                
                </td>
            </tr>            
            <tr valign="middle">
                <td class="textocontgris10bold" style="text-align:right;">Usuario controlador</td>
                <td width="71%" valign="middle" style="height:20px;">
                    <asp:TextBox ID="txtUsuariosCodigo" ClientIDMode="Static" Width="500" Enabled="false" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr valign="middle">
                <td class="textocontgris10bold" style="text-align:right;">Rol</td>
                <td width="71%" valign="middle" style="height:20px;">
                    <asp:TextBox ID="txtRol" ClientIDMode="Static" Width="500" Enabled="false" runat="server"></asp:TextBox>  
                </td>
            </tr>                         
            <tr valign="middle">
                <td class="textocontgris10bold" style="text-align:right;">Comentarios e Instrucciones</td>
                <td width="71%" valign="middle" style="height:20px;">
                    <asp:TextBox ID="txtComentarios" ClientIDMode="Static" TextMode="MultiLine" Width="500" Rows="3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr valign="middle">
                <td class="textocontgris10bold" style="text-align:right;">Otras Acciones</td>
                <td width="71%" valign="middle" style="height:20px;">

                    <asp:table id="MyTable" runat="server" width="100%" cellspacing="0" cellpadding="0" />
                </td>
            </tr>
            <tr valign="middle">
                <td class="style1" style="text-align:left;"></td>
                <td width="71%" valign="middle" class="style2">
                        <input id="Button1" type="button" value="Guardar" class="boxceleste" onclick="UpdateTareasLog();" />
                        <input id="Button2" type="button" value="Salir" class="boxceleste" onclick="javascript:handleUpdateTareas($get('txtUsuariosCodigo').value);" /> 
                </td>
            </tr>
        </table>
  
    </form>
</body>
</html>
