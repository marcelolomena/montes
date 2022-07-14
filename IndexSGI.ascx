<%@ Control Language="VB" AutoEventWireup="false" CodeFile="IndexSGI.ascx.vb" Inherits="IndexSGI" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:table id="MyTable" runat="server" width="100%" cellspacing="2" cellpadding="2" />
<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>  
        
<asp:TabContainer ID="TabContainer1"  runat="server" ActiveTabIndex="0" Visible="false">
    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
        <ContentTemplate>

        </ContentTemplate>
    </asp:TabPanel>
</asp:TabContainer>
