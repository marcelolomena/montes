<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SideBarRight.ascx.vb" Inherits="SideBarRight" %>
<table border="0" cellspacing="0" cellpadding="0" width="150" align="center">
    <tbody>
        <tr style="font-weight: 700; font-family: 'Verdana'">
            <asp:Repeater ID="rptMenu" EnableViewState="False" runat="server">
                <HeaderTemplate>
                    <table border="0" cellspacing="0" cellpadding="0" width="250" align="right">
                </HeaderTemplate>
                <ItemTemplate>
                        <tr>
                            <td align="center" class="menupn" style="font-family: Verdana; font-size: 11px; color: #FFFFFF; height: 35px;"><a href='<%#Container.DataItem("href")%>' style="font-family: Verdana; font-size: 11px; color: #FFFFFF"><%#Container.DataItem("texto")%></a></td>
                        </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
           
         </tr>    
     </tbody>
</table>