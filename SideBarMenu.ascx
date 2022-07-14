<%@ Control Language="VB" AutoEventWireup="false" CodeFile="SideBarMenu.ascx.vb" Inherits="SideBarMenu" %>
                <asp:Repeater ID="rptMenu" EnableViewState="False" runat="server">
                    <HeaderTemplate>
                        <table border="0" cellSpacing="2" cellPadding="2" width="255">
                            <tbody>
                                <tr>
                                    <td width="247"><img src="img/tit_agent.gif" width="247" height="33"></td>
                                </tr>
                                <tr>
                                    <td scope="row" align="left">&nbsp;</td>
                                </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                                <tr><td scope="row" align="left"><img src="img/flecha_naranja.gif" width="9" height="14"><a class="txt_negro_link" href="<%#Container.DataItem("href")%>"><%#Container.DataItem("texto")%></a></td></tr>
                                <tr><td align="left"><img src="img/puntos_hor.png" width="173" height="3"></td></tr>
                    </ItemTemplate>
                    <FooterTemplate>
                                <tr><td align="right">&nbsp;</td></tr>
                            </tbody>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>