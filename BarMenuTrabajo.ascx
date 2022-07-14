<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BarMenuTrabajo.ascx.vb" Inherits="BarMenuTrabajo" %>
<table border="0" cellspacing="0" cellpadding="0" width="100%">
    <tr>
        <td>
            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td class="menu" width="100%" align="center">
                        <asp:Repeater ID="rptMenu" EnableViewState="False" runat="server">
                            <HeaderTemplate>
                                <table border="0" cellspacing="0" cellpadding="0" width="100%" >
                                    <tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                        <td class="menu" width="20%" align="center" height="35px" bgcolor="#EE5500"><a class="mn_mid_link" href="<%#Container.DataItem("href")%>"><%#Container.DataItem("texto")%></a></td>           
                            </ItemTemplate>
                            <FooterTemplate>
                                    </tr>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>