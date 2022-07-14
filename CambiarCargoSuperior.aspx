<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CambiarCargoSuperior.aspx.vb" Inherits="CambiarCargoSuperior" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Mantención de Dependencias de las Opciones del Menú del Portal</title>
    <style type="text/css">HTML {width:47em; height:48em}</style>
    <link href="CSS/StyleConsalud.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="Styles/stylesheet.css" />        
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
           <Services>
                <asp:ServiceReference Path="~/Services/CintacDataBroker.asmx" />
            </Services>            
            <Scripts>
                <asp:ScriptReference Path="FuncionesJScript.js" />
            </Scripts>
        </asp:ScriptManager>    
    <div>
<table width="100%" border="0" cellpadding="0" cellspacing="0">
    <tr>
        <td align="left" bgcolor="#FFFFFF">
              <br /><img alt="LogoCintac" src="img/titulo_plan_de_relaciones.png" /><br />
              <br /></td>
        
    </tr>  
</table>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
        <td class="txt_general"><div class="TituloPrincipal"><h1><asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label></h1></div></td>
    </tr>
</table>
<table width="100%" class="visible" cellspacing="2" cellpadding="2" border="0" style="background-color:WhiteSmoke;border-color:WhiteSmoke;border-width:1px;border-style:Solid;">
<tr valign="middle">
   <td class="textocontgris10bold" style="text-align:left;"><asp:Label ID="lblCargo" runat="server" Text="Label"></asp:Label></td>
   <td width="71%" valign="middle" style="height:20px;"><asp:TextBox ID="txtObjectId" runat="server"  
           Width="38px" class="textoboxgris" Enabled="false" /><asp:TextBox ID="txtCargo" runat="server" Width="458px" class="textoboxgris" Enabled="false" />
   </td>
</tr>
<tr valign="middle">
   <td class="textocontgris10bold" style="text-align:left;"><asp:Label ID="lblCargoSuperiorActual" runat="server" Text="Label"></asp:Label></td>
   <td width="71%" valign="middle" style="height:20px;"><asp:TextBox ID="txtDependenciaActual" runat="server" Width="500px" Enabled="false" class="textoboxgris" />
   </td> 
</tr>
<tr valign="middle">
   <td class="textocontgris10bold" style="text-align:left;"><asp:Label ID="lblCargoSuperiorPropuesto" runat="server" Text="Label"></asp:Label></td>
   <td width="71%" valign="middle" style="height:20px;"><input id="txtDependenciaPropuesta" name="txtDependenciaPropuesta" disabled="disabled" type="text" class="textoboxgris" style="width: 500px; "  />
   </td>
</tr>
<tr valign="middle">
   <td class="textocontgris10bold" style="text-align:left;"></td>
   <td width="71%" valign="middle" style="height:20px;">
            <input id="Button1" type="button" value="Aceptar" class="boxceleste" onclick="javascript:handleUpdateFuncion($get('txtObjectId').value);" />
            <input id="Button2" type="button" value="Cancelar" class="boxceleste" onclick="window.close();" /> 
   </td>
</tr>
</table>

    <input id="txtNuevoCargoSuperiorId" name="txtNuevoCargoSuperiorId" type="hidden" />    
    
    <div align="left">
    <asp:TreeView ID="TreeView1" OnTreeNodePopulate="PopulateNode" Width="660px" ExpandDepth="3" runat="server" ShowCheckBoxes="None" ToolTip="Escoja nuevo cargo superior" ImageSet="XPFileExplorer" LineImagesFolder="~/TreeLineImages" NodeIndent="15" ShowLines="True" >
        <ParentNodeStyle Font-Bold="False" />
        <HoverNodeStyle Font-Underline="True" ForeColor="#56829B" />
        <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" 
                HorizontalPadding="0px" VerticalPadding="0px"/>
        <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="#56829B" HorizontalPadding="2px"
                NodeSpacing="0px" VerticalPadding="2px" />      
      <Nodes>
        <asp:TreeNode Text="Lista Jer&aacute;rquica de Opciones de Men&uacute;" SelectAction="Expand" PopulateOnDemand="True" ShowCheckBox="False" Value="Lista Jer&aacute;rquica de opciones de Men&uacute;"/>
      </Nodes>

    </asp:TreeView></div>          
    
  
    </div>
    </form>
</body>
</html>
