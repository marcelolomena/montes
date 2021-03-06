Imports System.Data
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Data.OleDb
Partial Class ImprimirPlanEnWord
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim qk = HttpContext.Current.Server.MapPath(".")
        Dim rutaOrigen As String = qk & "\" & "FileExcel\Plantilla1.xls"
        Dim rutaDestino As String = qk & "\" & "DownLoadExcel\"
        Dim archivoDestino As String = "FileExcel" & Session.SessionID & ".doc"
        rutaDestino &= archivoDestino

        Dim CarpetaJudicialId As String = Request.QueryString("Id")
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim CarpetaJudicialCodigo As String = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
        Dim TipoProcesoName As String = CarpetaJudicial.LeerTipoProcesoNameByCodigo(CarpetaJudicialCodigo)
        Dim TipoProceso As New TipoProceso
        Dim Acciones As New Acciones
        Dim TipoProcesoSecuencia As Long = TipoProceso.LeerTipoProcesoSecuenciaByName(TipoProcesoName)
        Dim TareasId As Long = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
        Dim Tareas As New Tareas

        Dim CodigoHTML As String = ""

        CodigoHTML = "<b>" & UCase(CarpetaJudicialCodigo) & ": " & UCase(CarpetaJudicial.LeerApellidosDeudorByTareasId(TareasId)) & " CON SCOTIABANK </b><br /><br />"
        CodigoHTML = CodigoHTML & "<u><b>" & UCase("Antecedentes del deudor y del proceso judicial") & "</b></u><br />"
        CodigoHTML = CodigoHTML & Tareas.ListarDatosDelDeudorPorTareasId(TareasId, CarpetaJudicialCodigo, "visible", "Word")

        CodigoHTML = CodigoHTML & Acciones.ListarPlanPorProceso(TipoProcesoSecuencia, CarpetaJudicialCodigo)

        HttpContext.Current.Response.ContentType = "application/msword"
        HttpContext.Current.Response.ContentEncoding = System.Text.UnicodeEncoding.UTF8
        HttpContext.Current.Response.Charset = "UTF-8"
        Response.AddHeader("Content-Disposition", "attachment; filename=" & rutaDestino)
        Response.Write("<html>")
        Response.Write("<head>")
        Response.Write("<META HTTP-EQUIV=""Content-Type"" CONTENT=""text/html; charset=UTF-8"">")
        Response.Write("<meta name=ProgId content=Word.Document>")
        Response.Write("<meta name=Generator content=""Microsoft Word 9"">")
        Response.Write("<meta name=Originator content=""Microsoft Word 9"">")
        Response.Write("<style>")
        Response.Write("@page Section1 {size:595.45pt 841.7pt; margin:1.00in 0.5in 1.00in 0.5in;mso-header-margin:.5in;mso-footer-margin:.5in;mso-paper-source:0;font-family:Verdana;font-size:8pt;}")
        Response.Write("div.Section1 {page:Section1;}")
        Response.Write("</style>")
        Response.Write("</head>")
        Response.Write("<body>")
        Response.Write("<div class=""Section1"">")
        Response.Write(CodigoHTML)
        Response.Write("</div>")
        Response.Write("</body>")
        Response.Write("</html>")
        HttpContext.Current.Response.Flush()


    End Sub
End Class
