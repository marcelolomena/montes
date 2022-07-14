Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services
Imports System.Math
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Xml

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class GetStakeholders
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    <ScriptMethod(UseHTTPGet:=False, ResponseFormat:=ResponseFormat.Xml)> _
    Public Function GetStakeholders(ByVal Value As String) As StakeholderMap

        Dim Stakeholders As New Stakeholders
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim ProgramasCodigo As String = Value
        Dim foot As Foot

        sSQL = "SELECT ProgramasMapa.StakeholdersCodigo as Codigo, ProgramasMapa.ProgramasMapaImportancia as Puntos "
        sSQL = sSQL & "FROM(ProgramasMapa) "
        sSQL = sSQL & "WHERE (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "')) "
        sSQL = sSQL & "ORDER BY ProgramasMapa.ProgramasMapaImportancia"

        Dim result As New StakeholderMap

        Dim meta As New Meta

        meta.maxChars = 100
        meta.deltay = 10

        result.meta = meta

        Dim Body As New Body

        Body.id = 5000
        Body.label = ProgramasCodigo
        Body.width = 160
        Body.height = 135
        Body.fillColor = "0xa5a397"
        Body.borderColor = "0xf6f6f6"
        Body.borderThickness = "6"
        Body.textColor = "0xffffff"
        Body.link = "ReportesPGG.aspx?PaginaWebName=Reporte SE2&PGGCodigo=" & ProgramasCodigo

        result.body = Body

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read

                foot = New Foot

                foot.id = 5000
                foot.label = dtrFunciones("Codigo")
                foot.width = "160"
                foot.height = "70"
                If CInt(dtrFunciones("Puntos")) >= 18 Then 'Rojo
                    foot.barColor = "0xe30003"
                End If
                If CInt(dtrFunciones("Puntos")) >= 9 And CInt(dtrFunciones("Puntos")) < 18 Then 'Rosado
                    foot.barColor = "0xffa52b"
                End If
                If CInt(dtrFunciones("Puntos")) >= 1 And CInt(dtrFunciones("Puntos")) < 9 Then 'Amarillo
                    foot.barColor = "0xfeea00"
                End If
                foot.fillColor = "0xe5e4e2"
                foot.barWidth = "10"
                foot.borderColor = "0xffffff"
                foot.borderThickness = "1"
                foot.link = "ReportesPGG.aspx?PaginaWebName=Reporte Stakeholders&StakeholdersId=" & CStr(Stakeholders.LeerStakeholdersIdByCodigo(dtrFunciones("Codigo")))
                foot.value = dtrFunciones("Puntos")

                result.feet.Add(foot)

            End While
            dtrFunciones.Close()
        Catch

        End Try

        Return result

    End Function

End Class