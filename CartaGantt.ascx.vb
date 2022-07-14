Imports System.Web.UI.DataVisualization.Charting
Partial Class CartaGantt
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim TipoProceso As New TipoProceso
        Dim CodigoHTML As String = ""
        Dim CarpetaJudicialId As String = Request.QueryString("Id")
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim CarpetaJudicialCodigo As String = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
        Dim TipoProcesoName As String = CarpetaJudicial.LeerTipoProcesoNameByCodigo(CarpetaJudicialCodigo)
        Dim Acciones As New Acciones
        Dim TipoProcesoSecuencia As Long = TipoProceso.LeerTipoProcesoSecuenciaByName(TipoProcesoName)
        Dim TareasId As Long = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
        Dim Tareas As New Tareas

        CodigoHTML = "<div style=""position:relative"" class=""gantt"" id=""GanttChartDIV""></div>"
        CodigoHTML = CodigoHTML & "<script type=""text/javascript"" language=""javascript"">"
        CodigoHTML = CodigoHTML & "var g = new JSGantt.GanttChart('g', document.getElementById('GanttChartDIV'), 'day');"
        CodigoHTML = CodigoHTML & "g.setShowRes(0);"
        CodigoHTML = CodigoHTML & "g.setShowDur(1);"
        CodigoHTML = CodigoHTML & "g.setShowComp(1);"
        CodigoHTML = CodigoHTML & "g.setCaptionType('Resource');"
        CodigoHTML = CodigoHTML & "if (g) {"
        CodigoHTML = CodigoHTML & Acciones.ListarItemsGanttPorProceso(TipoProcesoSecuencia, CarpetaJudicialCodigo, Chart1)
        CodigoHTML = CodigoHTML & "g.Draw();"
        CodigoHTML = CodigoHTML & "g.DrawDependencies();"
        CodigoHTML = CodigoHTML & "}"
        CodigoHTML = CodigoHTML & "else {"
        CodigoHTML = CodigoHTML & "alert(""not defined"");"
        CodigoHTML = CodigoHTML & "}"
        CodigoHTML = CodigoHTML & "</script>"

        MyAccordion.Controls.Add(New LiteralControl(CodigoHTML))

    End Sub
End Class
