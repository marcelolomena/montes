<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BarMenu.ascx.vb" Inherits="BarMenu" %>
<table border=0 cellSpacing=0 cellPadding=0 width="100%" align=center>
        <TBODY>
        <TR>
          <TD>
            <TABLE border=0 cellSpacing=0 cellPadding=0 width="100%" 
            align=center>
              <TBODY>
              <TR>
                <TD class=menu width=950 align=middle>
                <asp:Repeater ID="rptMenu" EnableViewState="False" runat="server">
                    <HeaderTemplate>
                         <table border="0" cellSpacing="0" cellPadding="0" width="100%" height="30">
                            <tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                                <td class="menu" width="21%" align="center"><a class="mn_mid_link" href="<%#Container.DataItem("href")%>"><%#Container.DataItem("texto")%></a></td>           
                    </ItemTemplate>
                    <FooterTemplate>
                            </tr>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>                       
            </TD></TR>
              <TR>
                <TD align=middle><IMG 
                  src="img/hoja_900.gif" 
                  width=951 
  height=26></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE>