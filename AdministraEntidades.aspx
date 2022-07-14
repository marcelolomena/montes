<%@ Page Title="" Language="VB" MasterPageFile="~/PaginaContenidos.master" AutoEventWireup="false" CodeFile="AdministraEntidades.aspx.vb" Inherits="AdministraEntidades" %>

<%@ Register src="LogoTrabajo.ascx" tagname="LogoTrabajo" tagprefix="uc1" %>
<%@ Register src="BarMenuTrabajo.ascx" tagname="BarMenuTrabajo" tagprefix="uc3" %>
<%@ Register src="PiePaginaControl.ascx" tagname="PiePaginaControl" tagprefix="uc5" %>
<%@ Register src="AdministraEntidades.ascx" tagname="AdministraEntidades" tagprefix="uc6" %>
<%@ Register src="SideBarAccordion.ascx" tagname="SideBarAccordion" tagprefix="uc7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Logo" Runat="Server">
    <uc1:LogoTrabajo ID="LogoTrabajo1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Banner" Runat="Server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="BarMenu" Runat="Server">
    <uc3:BarMenuTrabajo ID="BarMenuTrabajo1" runat="server" />  
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="SideBarMenu" Runat="Server">
    <uc7:SideBarAccordion ID="SideBarAccordion1" runat="server" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentArea" Runat="Server">
    <uc6:AdministraEntidades ID="AdministraEntidades1" runat="server" />
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="PiePagina" Runat="Server">
    <uc5:PiePaginaControl ID="PiePaginaControl1" runat="server" />
</asp:Content>

