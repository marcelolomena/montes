Imports System.Data
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Data.OleDb
Partial Class ImprimirPerfilCarpetaEnWord
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim qk = HttpContext.Current.Server.MapPath(".")
        Dim rutaOrigen As String = qk & "\" & "FileExcel\Plantilla1.xls"
        Dim rutaDestino As String = qk & "\" & "DownLoadExcel\"
        Dim archivoDestino As String = "FileExcel" & Session.SessionID & ".doc"
        rutaDestino &= archivoDestino

        Dim CarpetaJudicialId As String = Request.QueryString("Id")
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Dim CarpetaJudicialDirecciones As New CarpetaJudicialDirecciones
        Dim CarpetaJudicialAvales As New CarpetaJudicialAvales
        Dim CarpetaJudicialHipotecas As New CarpetaJudicialHipotecas
        Dim CarpetaJudicialDocs As New CarpetaJudicialDocs
        Dim CarpetaJudicialGastos As New CarpetaJudicialGastos
        Dim CarpetaJudicialLog As New CarpetaJudicialLog
        Dim CarpetaJudicialCodigo As String = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
        Dim TareasId As Long = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
        Dim Tareas As New Tareas

        Dim CodigoHTML As String = ""

        CodigoHTML = "<b>" & UCase(CarpetaJudicialCodigo) & ": " & UCase(CarpetaJudicial.LeerApellidosDeudorByTareasId(TareasId)) & " CON SCOTIABANK </b><br /><br />"
        CodigoHTML = CodigoHTML & "<u><b>" & UCase("Antecedentes del deudor y del proceso judicial") & "</b></u><br />"
        CodigoHTML = CodigoHTML & Tareas.ListarDatosDelDeudorPorTareasId(TareasId, CarpetaJudicialCodigo, "visible", "Word")
        CodigoHTML = CodigoHTML & "<br /><u><b>1.- RESPONSABLES DEL PROCESO JUDICIAL</b></u>" & CarpetaJudicial.ListarDatosDelProcesoJudicial(CarpetaJudicialId, "visible", "Word")
        CodigoHTML = CodigoHTML & "<br /><u><b>2.- CRÉDITOS: Mutuos y Mutuos Complementarios</b></u>" & CarpetaJudicialCreditos.ListarDatosDelCredito(CarpetaJudicialCodigo, False, "visible", "Word")
        CodigoHTML = CodigoHTML & "<br /><u><b>2.- CRÉDITOS: Pagarés</b></u>" & CarpetaJudicialCreditos.ListarDatosDelCredito(CarpetaJudicialCodigo, True, "visible", "Word")
        CodigoHTML = CodigoHTML & "<br /><u><b>3.- DIRECCIONES ALTERNATIVAS DEL DEUDOR</b></u>" & CarpetaJudicialDirecciones.ListarDirecciones(CarpetaJudicialCodigo, "visible", "Word")
        CodigoHTML = CodigoHTML & "<br /><u><b>4.- AVALES DEL DEUDOR</b></u>" & CarpetaJudicialAvales.ListarAvales(CarpetaJudicialCodigo, "visible", "Word")
        CodigoHTML = CodigoHTML & "<br /><u><b>5.- HIPOTECAS DEL DEUDOR</b></u>" & CarpetaJudicialHipotecas.ListarHipotecas(CarpetaJudicialCodigo, "visible", "Word")
        CodigoHTML = CodigoHTML & "<br /><u><b>6.- DOCUMENTOS ADJUNTOS A LA CARPETA DEL DEUDOR</b></u>" & CarpetaJudicialDocs.ListarDocs(CarpetaJudicialCodigo, "visible", "Word")
        CodigoHTML = CodigoHTML & "<br /><u><b>7.- GASTOS DEL PROCESO JUDICIAL</b></u>" & CarpetaJudicialGastos.ListarGastos(CarpetaJudicialCodigo, "visible", "Word")
        CodigoHTML = CodigoHTML & "<br /><u><b>8.- " & UCase("Bitácora completa del proceso judicial") & "</b></u>" & CarpetaJudicialLog.ListarLog(CarpetaJudicialCodigo, "visible", "Word")

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
