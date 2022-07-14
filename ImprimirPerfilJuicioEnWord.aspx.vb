Imports System.Data
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Data.OleDb
Partial Class ImprimirPerfilJuicioEnWord
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim qk = HttpContext.Current.Server.MapPath(".")
        Dim rutaOrigen As String = qk & "\" & "FileExcel\Plantilla1.xls"
        Dim rutaDestino As String = qk & "\" & "DownLoadExcel\"
        Dim archivoDestino As String = "FileExcel" & Session.SessionID & ".doc"
        rutaDestino &= archivoDestino

        Dim TipoProcesoSecuencia As Long = Request.QueryString("Id")
        Dim TipoProceso As New TipoProceso
        Dim Acciones As New Acciones
        Dim TipoProcesoName As String = TipoProceso.LeerTipoProcesoNameBySecuencia(TipoProcesoSecuencia)

        Dim CodigoHTML As String = ""

        CodigoHTML = "<h1>" & UCase(TipoProcesoName) & "</h1>"
        CodigoHTML = CodigoHTML & Acciones.ListarAccionesPorProceso(TipoProcesoSecuencia, "Word")

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
        Response.Write("@page Section1 {size:595.45pt 841.7pt;mso-page-orientation:landscape;margin:1.00in 0.5in 1.00in 0.5in;mso-header-margin:.5in;mso-footer-margin:.5in;mso-paper-source:0;font-family:Verdana;font-size:8pt;}")
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
