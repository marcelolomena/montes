<%@ Control Language="VB" AutoEventWireup="false" CodeFile="BuscaDocumentosSGI.ascx.vb" Inherits="BuscaDocumentosSGI" %>
<! -- Código generado por ZRISMART SF el 01-12-2010 19:29:04 -->
<asp:table id="MyTable" runat="server" width="100%" cellspacing="2" cellpadding="2" />
<asp:Label ID="lblMensaje" CssClass="tab_contenido" Visible="false" runat="server" Text="Label"></asp:Label>
<hr />
<table width="100%" cellspacing="2" cellpadding="2"><tr><td  Width="20%" 
        align="right" class="textocontgris10bold"><asp:Label ID="Label1" runat="server" Text="Busqueda avanzada"></asp:Label></td><td  Width="80%">    
        <asp:TextBox ID="txtDescription" runat="server" ClientIDMode="Static" 
            autoComplete="off" Width="440px" CssClass="textoboxgris" Height="18px" 
            style="margin-right: 0px; margin-top: 0px"  ></asp:TextBox>
    <ajaxToolkit:AutoCompleteExtender
                runat="server" 
                ID="autoComplete1" 
                TargetControlID="txtDescription"
                ServicePath="~/SimpleService.asmx" 
                ServiceMethod="GetCompletionList"
                MinimumPrefixLength="2" 
                CompletionInterval="1000"
                EnableCaching="true"
                CompletionSetCount="12" />
    <asp:Button ID="Button2" runat="server" Text="Buscar" CssClass="boxceleste" 
            Width="80px" /></td></tr></table>

