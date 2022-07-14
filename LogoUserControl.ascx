<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LogoUserControl.ascx.vb" Inherits="LogoUserControl" %>
<table border="0" cellspacing="1" cellpadding="1" width="99%" align="center">
    <tbody>
        <tr>
          <td align="left" width="50%"><img hspace="6" vspace="2" src="img/logo_royal.gif" width="148" height="41"></td>
          <td align="right">
            <asp:Repeater ID="rptMenu" EnableViewState="False" runat="server">
                <HeaderTemplate>
                    <table border="0" cellspacing="2" cellpadding="2" width="67%" align="right">
                        <tr>
                </HeaderTemplate>
                <ItemTemplate>
                            <td class="menusup" width="20%" align="center"><a class="mn_sup_link" href='<%#Container.DataItem("href")%>'><%#Container.DataItem("texto")%></a></td>
                </ItemTemplate>
                <FooterTemplate>
                        </tr>
                    </table>
                </FooterTemplate>
            </asp:Repeater>                
           </td>
         </tr>    
     </tbody>
</table>