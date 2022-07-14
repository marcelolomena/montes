<%@ Page Language="VB" AutoEventWireup="false" CodeFile="SelectFromModalList.aspx.vb" Inherits="SelectFromModalList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Selección de un elemento de la lista</title>
    <style type="text/css">HTML {width:55em; height:48em}</style>
    <link rel="stylesheet" type="text/css" href="Styles/royal_estilo.css" />
    <link rel="stylesheet" href="../CSS/theme.css" type="text/css" />    
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

        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td class="txt_general"><div class="subtit"><asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label></div></td>
            </tr>
        </table>
        <p><img src="img/botones/b_Volver.gif" alt="Volver a la página que invoco la selección modal de un elemento de la lista" onclick="var j = new Array(1); j[0] = 'No selecciono un elemento'; window.returnValue = j; window.close();"  /></p>
        <div align="left">
            <asp:TreeView ID="TreeView1" OnTreeNodePopulate="PopulateNode" Width="500px" ExpandDepth="2" runat="server" ShowCheckBoxes= "None" ToolTip="Escoja un elemento de la lista" ImageSet="Contacts" LineImagesFolder="~/TreeLineImages" NodeIndent="10" ShowLines="True" >
                <ParentNodeStyle Font-Bold="True" ForeColor="#5555DD" />
                <HoverNodeStyle Font-Underline="False" />
                <SelectedNodeStyle BackColor="White" BorderWidth="1"/>
                <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                    NodeSpacing="0px" VerticalPadding="0px" />      
              <Nodes>
                <asp:TreeNode Text="De un click de mousse sobre el elemento a seleccionar" SelectAction="Expand" PopulateOnDemand="True" ShowCheckBox="False" Value="Escoja un elemento de la lista"/>
              </Nodes>
            </asp:TreeView>
        </div>
        <p><img src="img/botones/b_Volver.gif" alt="Volver a la página que invoco la selección modal de un elemento de la lista" onclick="var j = new Array(1); j[0] = 'No selecciono un elemento'; window.returnValue = j; window.close();"  /></p>                  
    </form>
</body>
</html>
