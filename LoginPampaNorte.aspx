<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LoginPampaNorte.aspx.vb" Inherits="LoginPampaNorte" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Sistema de Cobranza Judicial</title>
<style type="text/css">
</style>
<link href="Styles/stylesheet.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function MM_preloadImages() { //v3.0
        var d = document; if (d.images) {
            if (!d.MM_p) d.MM_p = new Array();
            var i, j = d.MM_p.length, a = MM_preloadImages.arguments; for (i = 0; i < a.length; i++)
                if (a[i].indexOf("#") != 0) { d.MM_p[j] = new Image; d.MM_p[j++].src = a[i]; } 
        }
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
<table width="960" border="0" cellpadding="0" cellspacing="0" class="caja_principal">
    <tr>
        <td height="90" colspan="2" class="caja_titulo_principal"><img src="img/titulo_plan_de_relaciones.png" width="668" height="66" alt="Plan de Relacionamiento y Diálogos con Stakeholders" /></td>
    </tr>
    <tr>
        <td colspan="2">&nbsp;</td>
    </tr>
    <tr>
        <td colspan="2">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%"></td>
                    <td width="70%">
                        <h1>Bienvenido</h1>
                        <p>&nbsp;</p>
                        <h2>Propósito</h2>
                        <p>El Proceso Integrado de Cobranza Judicial, es un modelo que existe por la necesidad de Montes y Cia. de crear y mantener una estructura organizacional que sea ágil, eficaz y eficiente</p>
                        <h2>Sistema</h2>
                        <p>El sistema contiene dentro de él una descripción del proceso judicial y un conjunto de plantillas que facilitarán la tarea de preparación de los escritos y harán más uniforme el proceso en general.</p>
                        <p>El sistema, permite a un encargado de un proceso judicial, controlar, organizar y gestionar las acciones asociadas a las etapas del proceso. Esto mediante el cruce de información que generará un sistema de avisos predefinidos de cada una de las acciones a desarrollar, enfocado a facilitar el relacionamiento de un encargado de un juicio con el tribunal específico o con el resto de los involucrados en un proceso de demanda judicial</p>
                        <hr color="#FFFFFF" style="width:660;" />            
                    </td>
                    <td width="15%"></td>                    
                </tr>
            </table>
        </td>
    </tr>
  <tr>
    <td colspan="2"><table width="100%" border="0" cellpadding="0" cellspacing="0">
      <tr>
        <td align="center" class="contenidos"><br />
          <table border="0" cellpadding="0" cellspacing="0" class="login" id="login">
          <tr>
              <th scope="col">Acceso a Usuarios</th>
              </tr>
            <tr>
              <td>
<table width="100%" border="0" cellpadding="0" cellspacing="0" id="loguin">
  <tr>
    <td width="34%">Usuario:</td>
    <td width="66%"><asp:TextBox ID="txtEMail" runat="server" 
            ToolTip="Ingrese el código de usuario"></asp:TextBox></td>
  </tr>
  <tr>
    <td>Clave:</td>
    <td><asp:TextBox ID="txtRut" runat="server" TextMode="Password" ToolTip="Ingrese su password"></asp:TextBox></td>
  </tr>
  <tr>
    <td>Portal:</td>
    <td>
        <asp:DropDownList ID="txtPortalesName" runat="server" height="30px" 
            width="260px">
        </asp:DropDownList>
      </td>
  </tr>
  <tr>
    <td colspan="2"><asp:Label ID="MyMessage1" runat="server" CssClass="subtit"></asp:Label></td>
  </tr>
  <tr>
    <td>&nbsp;</td>
    <td align="right"><asp:Button ID="LoginButton" runat="server" class="submit" 
            Text="Enviar" BackColor="#56829B" Font-Names="Verdana" ForeColor="White" 
            Height="30px" Width="80px" /></td>
  </tr>
</table>
              </td>
            </tr>
    </table>
          <table width="370" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td>&nbsp;</td>
              <td align="right"></td>
            </tr>
            <tr>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
          </table></td>
        </tr>
  </table></td>
  </tr>
  <tr>
    <td colspan="2" class="contenidos">&nbsp;</td>
  </tr>
  <tr>
    <td class="pie_de_pagina"></td>
    <td align="right" class="pie_de_pagina">©2013</td>
  </tr>
</table>

</form>
</body>
</html>
