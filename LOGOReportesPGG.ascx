<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LOGOReportesPGG.ascx.vb" Inherits="LOGOReportesPGG" %>
<table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
        <tr>
            <td valign="middle">
                <img hspace="6" vspace="2" src="img/LogoHorizontalBHPBilliton.bmp" 
                    width="483px" alt="Logo principal" style="height: 112px" />
            </td>
            <td valign="middle">
                <div align="center" style="font-family: 'Trebuchet'; font-size: 18px; font-weight: bold; font-style: normal; color: #006699">
                    <h1>PLAN DE RELACIONES Y DIÁLOGO CON STAKEHOLDERS<br /><asp:Label ID="lblTitulo" runat="server" Text="Label"></asp:Label></h1>
                </div>
            </td>
        </tr>    
</table>
<table border="0" cellpadding="0" cellspacing="0" width="100%">
    <tr>
        <td width="25%">
            <div align="left" style="font-family: 'Verdana'; font-size: 14px; font-weight: normal; font-style: normal; color: #006699">
                <h2>LÍNEA ESTRATÉGICA</h2>
            </div>
        </td>
        <td width="25%">
            <div align="left" style="font-family: 'Verdana'; font-size: 14px; font-weight: normal; font-style: normal; color: #006699">
                <h3><asp:Label ID="lblLineaEstrategica" runat="server" Text="Label"></asp:Label></h3>
            </div>        
        </td>
        <td width="25%">
            <div align="left" style="font-family: 'Verdana'; font-size: 14px; font-weight: normal; font-style: normal; color: #006699">
                <h2>SUB LÍNEA ESTRATÉGICA</h2>
            </div>
        </td>
        <td width="25%">
            <div align="left" style="font-family: 'Verdana'; font-size: 14px; font-weight: normal; font-style: normal; color: #006699">
                <h3><asp:Label ID="lblSubLineaEstrategica" runat="server" Text="Label"></asp:Label></h3>
            </div>        
        </td>
    </tr>
    <tr>
        <td width="25%">
            <div align="left" style="font-family: 'Trebuchet'; font-size: 14px; font-weight: normal; font-style: normal; color: #006699">
                <h2>OBJETIVO</h2>
            </div>        
        </td>
        <td width="75%" colspan="3">
            <div align="left" style="font-family: 'Verdana'; font-size: 14px; font-weight: normal; font-style: normal; color: #006699">
                <h3><asp:Label ID="lblObjetivo" runat="server" Text="Label"></asp:Label></h3>
            </div>          
        </td>
    </tr>
    <tr>
        <td width="25%">
            <div align="left" style="font-family: 'Verdana'; font-size: 14px; font-weight: normal; font-style: normal; color: #006699">
                <h2>PROGRAMA</h2>
            </div>
        </td>
        <td width="25%">
            <div align="left" style="font-family: 'Verdana'; font-size: 14px; font-weight: normal; font-style: normal; color: #006699">
                <h3><%= Request.QueryString("PGGCodigo") %></h3>
            </div>        
        </td>
        <td width="25%">
            <div align="left" style="font-family: 'Verdana'; font-size: 14px; font-weight: normal; font-style: normal; color: #006699">
                <h2>ENCARGADO</h2>
            </div>
        </td>
        <td width="25%">
            <div align="left" style="font-family: 'Verdana'; font-size: 14px; font-weight: normal; font-style: normal; color: #006699">
                <h3><asp:Label ID="lblEncargado" runat="server" Text="Label"></asp:Label></h3>
            </div>        
        </td>
    </tr>
</table>