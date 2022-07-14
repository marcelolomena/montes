<%@ Control Language="VB" AutoEventWireup="false" CodeFile="CartaGantt.ascx.vb" Inherits="CartaGantt" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<%@ Register src="BarraMenu.ascx" tagname="BarraMenu" tagprefix="uc1" %>

 <%@ Register src="BarraSuperior.ascx" tagname="BarraSuperior" tagprefix="uc2" %>

 <table width="960" border="0" cellpadding="0" cellspacing="0" class="caja_principal">
    <tr>
        <td class="caja_titulo_principal">

            

            <uc2:BarraSuperior ID="BarraSuperior1" runat="server" />

            

        </td>
    </tr>
    <tr>
        <td class="caja_titulo_principal">

            <uc1:BarraMenu ID="BarraMenu1" runat="server" />

        </td>
    </tr>
    <tr>
        <td>
            <table width="960" border="0" cellpadding="0" cellspacing="0" class="popups_titulo_con_enlaces">
                <tr>
                    <td width="84%"><h2>Carta Gantt del Proceso Judicial</h2></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:PlaceHolder ID="MyAccordion" runat="server"></asp:PlaceHolder>

        </td>
    </tr>
    <tr>
        <td>
                        <center>
						<asp:chart id="Chart1" runat="server" Height="436px" Width="808px"  Visible=false
                            ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)" BorderDashStyle="Solid" 
                            BackGradientStyle="TopBottom" BorderWidth="2px" backcolor="243, 223, 193" 
                            BorderColor="#B54001" enableviewstate="True" viewstatecontent="All">
							<legends>
								<asp:legend Enabled="True" IsTextAutoFit="False" Name="Default" 
                                    BackColor="Transparent" Font="Trebuchet MS, 8.25pt, style=Bold" 
                                    Title="Gráfico de Valor Ganado"></asp:legend>
							</legends>
							<borderskin skinstyle="Emboss"></borderskin>
							<series>
								<asp:series ChartArea="ChartArea1" XValueType="DateTime" Name="Series1" 
                                    CustomProperties="LabelsRadialLineSize=1, LabelStyle=outside" 
                                    BorderColor="180, 26, 59, 105" Color="194, 65, 140, 240" ChartType="Line" LegendText="Esfuerzo Planeado"></asp:series>
								<asp:series ChartArea="ChartArea1" XValueType="DateTime" Name="Series2" 
                                    CustomProperties="LabelsRadialLineSize=1, LabelStyle=outside" 
                                    BorderColor="180, 26, 59, 105" Color="194, 65, 140, 140" ChartType="Line" LegendText="Avance Real"></asp:series>
								<asp:series ChartArea="ChartArea1" XValueType="DateTime" Name="Series3" 
                                    CustomProperties="LabelsRadialLineSize=1, LabelStyle=outside" 
                                    BorderColor="180, 26, 59, 105" Color="154, 65, 140, 140" ChartType="Line" LegendText="Esfuerzo Real"></asp:series>
							</series>
							<chartareas>
								<asp:chartarea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid" BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
									<axisy2 enabled="False"></axisy2>
									<axisx2 enabled="False"></axisx2>
									<area3dstyle Rotation="10" perspective="10" Inclination="15" IsRightAngleAxes="False" wallwidth="0" IsClustered="False"></area3dstyle>
									<axisy linecolor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisy>
									<axisx linecolor="64, 64, 64, 64" IsLabelAutoFit="False" ArrowStyle="Triangle">
										<labelstyle font="Trebuchet MS, 8.25pt, style=Bold" IsStaggered="True" />
										<majorgrid linecolor="64, 64, 64, 64" />
									</axisx>
								</asp:chartarea>
							</chartareas>
						</asp:chart>
                        </center>



        </td>
    </tr>
    <tr>
        <td class="caja_titulo_principal">

            <uc1:BarraMenu ID="BarraMenu2" runat="server" />

        </td>
    </tr>
</table>
