<%@ Control Language="VB" AutoEventWireup="false" CodeFile="MostrarCarpetas.ascx.vb" Inherits="MostrarCarpetas" %>
    <table width="700" border="0" cellspacing="0" cellpadding="0">
          <tr><td><h1>Consulta Carpeta de Documentos</h1></td></tr>
    </table>
    <div align="left">
        <asp:TreeView ID="Carpeta" OnTreeNodePopulate="PopulateNode" Width="660px" 
            ExpandDepth="1" runat="server" 
            ImageSet="XPFileExplorer" LineImagesFolder="~/TreeLineImages" 
            NodeIndent="15" >
            <ParentNodeStyle Font-Bold="False" />
            <HoverNodeStyle Font-Underline="True" ForeColor="#56829B" />
            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" 
                HorizontalPadding="0px" VerticalPadding="0px"/>
            <NodeStyle Font-Names="Verdana" Font-Size="8pt" ForeColor="#56829B" HorizontalPadding="2px"
                NodeSpacing="0px" VerticalPadding="2px" />      
            <Nodes>
                <asp:TreeNode Text="CARPETA DE DOCUMENTOS" SelectAction= "Expand" PopulateOnDemand="True" ShowCheckBox="False" Value="Escoja un elemento de la lista"/>
            </Nodes>
        </asp:TreeView>
    </div>