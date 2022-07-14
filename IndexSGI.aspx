<%@ Page Title="" Language="VB" MasterPageFile="~/MasterSGI.master" AutoEventWireup="false" CodeFile="IndexSGI.aspx.vb" Inherits="IndexSGI" %>

<%@ Register src="IndexSGI.ascx" tagname="IndexSGI" tagprefix="uc3" %>
<%@ Register src="BarraSuperior.ascx" tagname="BarraSuperior" tagprefix="uc6" %>
<%@ Register src="BarraMenu.ascx" tagname="BarraMenu" tagprefix="uc7" %>
<%@ Register src="noticias.ascx" tagname="Noticias" tagprefix="uc8" %>
<%@ Register src="BusquedaPorPalabraClave.ascx" tagname="Busqueda" tagprefix="uc10" %>
<%@ Register src="BarraSubMenu.ascx" tagname="BarraSubMenu" tagprefix="uc9" %>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <uc3:IndexSGI ID="IndexSGI1" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="BarraSuperior" runat="server">
    <uc6:BarraSuperior ID="BarraSuperior1" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="BarraMenu" runat="server">
    <uc7:BarraMenu ID="BarraMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="Noticias" runat="server">
    <uc10:Busqueda ID="Busqueda1" runat="server" />
    <uc8:Noticias ID="Noticias1" runat="server" />    
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>    

</asp:Content>
<asp:Content ID="Content9" ContentPlaceHolderID="BarraSubMenu" runat="server">
    <uc9:BarraSubMenu ID="BarraSubMenu1" runat="server" />
</asp:Content>
<asp:Content ID="Content10" ContentPlaceHolderID="MenuPie" runat="server">
    <uc7:BarraMenu ID="BarraMenu2" runat="server" />
</asp:Content>