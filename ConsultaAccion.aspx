<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ConsultaAccion.aspx.vb" Inherits="ConsultaAccion" %>

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
        <br /><center><input id="Button3" type="button" value="Salir" class="boxceleste" onclick="window.close();" /></center>
                        
    </form>
</body>
</html>
