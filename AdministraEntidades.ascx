<%@ Control Language="VB" AutoEventWireup="false" CodeFile="AdministraEntidades.ascx.vb" Inherits="AdministraEntidades" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:table id="MyTable" runat="server" width="100%" cellspacing="2" cellpadding="2" />
<asp:TabContainer ID="TabContainer1"  runat="server" ActiveTabIndex="0">
    <asp:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
        <ContentTemplate>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>  
        </ContentTemplate>
    </asp:TabPanel>
</asp:TabContainer>





