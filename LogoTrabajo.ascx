<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LogoTrabajo.ascx.vb" Inherits="LogoTrabajo" %>
<table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
    <tbody>
        <tr>
          <td width="20%">
              <!-- <img hspace="6" vspace="2" src="<%=Request.QueryString("Logo1")%>" width="148" 
                  style="height: 95px"></td> -->

              <img src="<%=Session("Logo1")%>" alt="logo" /></td>
          
          <td width="80%" align="right">
            <asp:Repeater ID="rptMenu" EnableViewState="False" runat="server">
                <HeaderTemplate>
                    <table border="0" cellspacing="0" cellpadding="0" align="right">
                        <tr>
                </HeaderTemplate>
                <ItemTemplate>
                            <td class="menusup" align="center"><a class="mn_sup_link" href='<%#Container.DataItem("href")%>'><%#Container.DataItem("texto")%></a>|</td>
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