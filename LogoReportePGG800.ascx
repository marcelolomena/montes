<%@ Control Language="VB" AutoEventWireup="false" CodeFile="LogoReportePGG800.ascx.vb" Inherits="LogoReportePGG800" %>
<style type="text/css">
    .style1
    {
        height: 131px;
    }
</style>
<table border="0" cellspacing="0" cellpadding="0" width="100%" align="center">
    <tbody>
        <tr>
            <td width="20%" class="style1">
                <img hspace="6" vspace="2" src="img/logo_corporativo.gif" 
                    width="177" alt="Logo principal" style="height: 118px" /></td>
            <td width="60%" class="style1">
                <asp:Panel ID="Panel1" runat="server" ForeColor="#B26C4A" BackColor="White" 
                    HorizontalAlign="Center" style="text-align: center" Width="425px">
    <div class="style1" align="center" 
                        style="font-family: 'Palatino Linotype'; font-size: 18px; font-weight: bold; font-style: normal; color: #B26C4A">
        <br />
        GERENCIA NUEVO NIVEL MINA<br /> SISTEMA DE GESTIÓN INTEGRADO<br /> 
        SUSTENTABILIDAD Y CALIDAD<br /> PROGRAMA : <%= Request.QueryString("PGGCodigo") %><br /></div>
</asp:Panel>
            <td width="20%" class="style1">
                <img hspace="6" vspace="2" src="img/logoNNM.png" 
                    width="148" style="height: 118px" alt="Logo del Proyecto" /></td>
        </tr>    
    </tbody>
</table>