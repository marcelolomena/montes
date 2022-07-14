<%@ Page Title="" Language="VB" MasterPageFile="~/MasterSGI.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<%@ Register src="Login.ascx" tagname="Login" tagprefix="uc1" %>
<%@ Register src="BarraSuperior.ascx" tagname="BarraSuperior" tagprefix="uc6" %>

<asp:Content ID="Content4" ContentPlaceHolderID="MainContent" Runat="Server">
    <uc1:Login ID="Login1" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="BarraSuperior" runat="server">
    <uc6:BarraSuperior ID="BarraSuperior1" runat="server" />
</asp:Content>
