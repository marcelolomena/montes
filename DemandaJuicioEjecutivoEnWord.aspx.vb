Imports System.Data
Imports System.IO
Imports Microsoft.VisualBasic
Imports System.Data.OleDb
Partial Class DemandaJuicioEjecutivoEnWord
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim qk = HttpContext.Current.Server.MapPath(".")
        Dim rutaOrigen As String = qk & "\" & "FileExcel\Plantilla1.xls"
        Dim rutaDestino As String = qk & "\" & "DownLoadExcel\"
        Dim archivoDestino As String = "FileExcel" & Session.SessionID & ".doc"
        rutaDestino &= archivoDestino

        Dim TareasId As Long = CLng(Request.QueryString("Id"))

        Dim CarpetaJudicial As New CarpetaJudicial
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Dim CarpetaJudicialHipotecas As New CarpetaJudicialHipotecas
        Dim CarpetaJudicialAvales As New CarpetaJudicialAvales
        Dim t As Boolean = False
        Dim Tareas As New Tareas
        Dim CarpetaJudicialId As Long = Tareas.LeerCarpetaJudicialIdbyTareasId(TareasId)
        Dim CarpetaJudicialCodigo As String = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
        Dim BancosDemandantes As String = CarpetaJudicialCreditos.BancoDemandante(CarpetaJudicialCodigo)
        Dim RepresentanteBanco As String = CarpetaJudicial.LeerRepresentanteBanco(CarpetaJudicialCodigo)
        Dim CiudadDemanda As String = ""
        Dim EsConExhorto As Boolean = CarpetaJudicial.EsConExhorto(CarpetaJudicialCodigo, CiudadDemanda)
        Dim NumeroCreditos As Integer = 0
        Dim NumeroMutuos As Integer = 0
        Dim CreditosId(10) As Long

        Dim Rut As String = ""
        Dim Nombres As String = ""

        Dim CodigoHTML As String = ""
        Dim TareasCodigo As String = ""
        Dim i As Integer = 0
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
        Dim TotalMutos As Integer = 0
        Dim TotalPagares As Integer = 0
        Dim TotalHipotecas As Integer = CarpetaJudicialHipotecas.TotalHipotecas(CarpetaJudicialCodigo)
        Dim TotalAvales As Integer = CarpetaJudicialAvales.TotalAvales(CarpetaJudicialCodigo)
        Dim ParrafoExhorto As String = ""

        Dim Vaelquintootrosi As Boolean = CarpetaJudicial.Vaelquintotrosi(CarpetaJudicialCodigo)

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
        Response.Write("@page Section1 {size:595.45pt 1007.7pt; margin:1.50in 1,25in 2.00in 1.00in;mso-header-margin:.5in;mso-footer-margin:.5in;mso-paper-source:0;font-family:Verdana;font-size:11pt;}")
        Response.Write("div.Section1 {page:Section1;}")
        Response.Write("</style>")
        Response.Write("</head>")
        Response.Write("<body>")
        'Response.Write("<table width=""600"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""contenidosword"" >")
        'border=""1"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Verdana;font-size:8pt;border:1px solid #FFFFFF;""
        Response.Write("<div class=""Section1"">")
        Response.Write("<table width=""600"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Verdana;font-size:11pt;"" >")
        Response.Write("<tr><td width=""50"">PROCEDIMIENTO:</td><td colspan=""2"" width=""550""><b>EJECUTIVO</b></td></tr>")
        Response.Write("<tr><td width=""50"" valign=""top"">MATERIA:</td><td colspan=""2"" width=""550""><b>" & CarpetaJudicialCreditos.MateriaJuicio(CarpetaJudicialCodigo) & "</b></td></tr>")
        Response.Write("<tr><td width=""50"">DEMANDANTE:</td><td width=""400""><b>BANCO SCOTIABANK CHILE</b></td><td width=""150""><b>RUT 97.018.000-1</b></td></tr>")
        Response.Write("<tr><td width=""50"">PATROCINANTE:</td><td width=""400""><b>JORGE MONTES BEZANILLA</b></td><td width=""150""><b>RUT 5.892.163-7</b></td></tr>")
        Response.Write("<tr><td width=""50"">APODERADO:</td><td width=""400""><b>MARÍA PAZ MONTES BEZANILLA</b></td><td width=""150""><b>RUT 6.971.644-K</b></td></tr>")
        Response.Write("<tr><td width=""50"" valign=""top"">DEMANDADO:</td><td colspan=""2"" width=""550"">" & CarpetaJudicial.LeerIdentificacionBasicaDemandados(CarpetaJudicialCodigo) & "</td></tr>")
        Response.Write("<tr><td colspan=""3""><hr /></td><tr>")
        Response.Write("<tr><td colspan=""3"">")
        Response.Write("<p>En lo principal, demanda ejecutiva y mandamiento de ejecución y embargo; en el primer otrosí, señala bienes para la traba de embargo y depositarios provisionales; en el segundo, acompaña documentos, con citación; en el tercero, patrocinio y poder")
        If BancosDemandantes <> "" Then
            Response.Write("en el cuarto, antecedentes de la fusión del " & BancosDemandantes & " y el Banco Scotiabank Chile")
            If EsConExhorto = True Then
                Response.Write("; en el quinto, exhorto.</p>")
            Else
                Response.Write(".</p>")
            End If
        Else
            If EsConExhorto = True Then
                Response.Write("; en el cuarto, exhorto.</p>")
            Else
                Response.Write(".</p>")
            End If
        End If
        Response.Write(Espacios & Espacios & "<b>S.J.L</b>")
        Response.Write("<p>" & Espacios & Espacios & RepresentanteBanco & " en representación según se acredita con el que se acompaña en el segundo otrosí,  del Banco Scotiabank Chile, institución financiera, ambos domiciliados en calle Morandé Nº 226, Santiago, a V.S. respetuosamente digo:</p>")
        ' Vamos a hacer el circuito de los Mutuos
        NumeroCreditos = CarpetaJudicialCreditos.LeerCreditosIdPorTipo(CarpetaJudicialCodigo, "Mutuo", CreditosId)
        NumeroMutuos = NumeroCreditos
        i = 0
        If NumeroCreditos > 0 Then  'Tenemos mutuos a describir, uno o más.
            For i = 1 To NumeroCreditos
                Response.Write(CarpetaJudicialCreditos.ParrafoMutuoEndosable(CreditosId(i), i))
            Next
        End If
        ' Vamos a hacer el circuito de los Mutuos Complementarios
        NumeroCreditos = CarpetaJudicialCreditos.LeerCreditosIdPorTipo(CarpetaJudicialCodigo, "Mutuo Complementario", CreditosId)
        i = 0
        If NumeroCreditos > 0 Then  'Tenemos mutuos a describir, uno o más.
            For i = 1 To NumeroCreditos
                Response.Write(CarpetaJudicialCreditos.ParrafoMutuoEndosable(CreditosId(i), NumeroMutuos + i))
            Next
        End If
        If CarpetaJudicialCreditos.LeerCantidadEscriturasPublicas(CarpetaJudicialCodigo) > 1 Then 'Mas de una escritura
            If NumeroMutuos + i > 1 Then 'Más de 1 Mutuo
                If TotalHipotecas > 1 Then 'Más de una Hipoteca
                    If (TotalAvales - 1) > 0 Then 'Hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En las escrituras públicas en que constan los referidos mutuos se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "Los mutuos, las hipotecas y la fianza solidaria constan de " & CarpetaJudicialCreditos.LeerCantidadEscriturasPublicas(CarpetaJudicialCodigo) & " escrituras públicas cuyas copias autorizadas se acompañan por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    Else ' No hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En las escrituras públicas en que constan los referidos mutuos se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "Los mutuos y las hipotecas constan de " & CarpetaJudicialCreditos.LeerCantidadEscriturasPublicas(CarpetaJudicialCodigo) & " escrituras públicas cuyas copias autorizadas se acompañan por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    End If
                Else ' Sólo una hipoteca
                    If (TotalAvales - 1) > 0 Then 'Hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En las escrituras públicas en que constan los referidos mutuos se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "Los mutuos, la hipoteca y la fianza solidaria constan de " & CarpetaJudicialCreditos.LeerCantidadEscriturasPublicas(CarpetaJudicialCodigo) & " escrituras públicas cuyas copias autorizadas se acompañan por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    Else ' No hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En las escrituras públicas en que constan los referidos mutuos se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "Los mutuos y la hipoteca constan de " & CarpetaJudicialCreditos.LeerCantidadEscriturasPublicas(CarpetaJudicialCodigo) & " escrituras públicas cuyas copias autorizadas se acompañan por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    End If
                End If
            Else ' Un sólo mutuo
                If TotalHipotecas > 1 Then 'Más de una Hipoteca
                    If (TotalAvales - 1) > 0 Then 'Hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En las escrituras públicas en que consta el referido mutuo se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "El mutuo, las hipotecas y la fianza solidaria constan de " & CarpetaJudicialCreditos.LeerCantidadEscriturasPublicas(CarpetaJudicialCodigo) & " escrituras públicas cuyas copias autorizadas se acompañan por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    Else ' No hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En las escrituras públicas en que consta el referido mutuo se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "El mutuo y las hipotecas constan de " & CarpetaJudicialCreditos.LeerCantidadEscriturasPublicas(CarpetaJudicialCodigo) & " escrituras públicas cuyas copias autorizadas se acompañan por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    End If
                Else ' Sólo una hipoteca
                    If (TotalAvales - 1) > 0 Then 'Hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En las escrituras públicas en que consta el referido mutuo se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "El mutuo, la hipoteca y la fianza solidaria constan de " & CarpetaJudicialCreditos.LeerCantidadEscriturasPublicas(CarpetaJudicialCodigo) & " escrituras públicas cuyas copias autorizadas se acompañan por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    Else ' No hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En las escrituras públicas en que consta el referido mutuo se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "El mutuo y la hipoteca constan de " & CarpetaJudicialCreditos.LeerCantidadEscriturasPublicas(CarpetaJudicialCodigo) & " escrituras públicas cuyas copias autorizadas se acompañan por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    End If
                End If
            End If
        Else ' Una sola escritura
            If NumeroMutuos + i > 1 Then 'Más de 1 Mutuo
                If TotalHipotecas > 1 Then 'Más de una Hipoteca
                    If (TotalAvales - 1) > 0 Then 'Hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En la escritura pública en que constan los referidos mutuos se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "Los mutuos, las hipotecas y la fianza solidaria constan de " & "una" & " escritura pública cuya copia autorizada se acompaña por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    Else ' No hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En la escritura pública en que constan los referidos mutuos se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "Los mutuos y las hipotecas constan de " & "una" & " escritura pública cuya copia autorizada se acompaña por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    End If
                Else ' Sólo una hipoteca
                    If (TotalAvales - 1) > 0 Then 'Hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En la escritura pública en que constan los referidos mutuos se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "Los mutuos, la hipoteca y la fianza solidaria constan de " & "una" & " escritura pública cuya copia autorizada se acompaña por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    Else ' No hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En las escrituras públicas en que constan los referidos mutuos se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "Los mutuos y la hipoteca constan de " & "una" & " escritura pública cuya copia autorizada se acompaña por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    End If
                End If
            Else ' Un sólo mutuo
                If TotalHipotecas > 1 Then 'Más de una Hipoteca
                    If (TotalAvales - 1) > 0 Then 'Hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En la escritura pública en que consta el referido mutuo se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "El mutuo, las hipotecas y la fianza solidaria constan de " & "una" & " escritura pública cuya copia autorizada se acompaña por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    Else ' No hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En la escritura pública en que consta el referido mutuo se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "El mutuo y las hipotecas constan de " & "una" & " escritura pública cuya copia autorizada se acompaña por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    End If
                Else ' Sólo una hipoteca
                    If (TotalAvales - 1) > 0 Then 'Hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En la escritura pública en que consta el referido mutuo se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "El mutuo, la hipoteca y la fianza solidaria constan de " & "una" & " escritura pública cuya copia autorizada se acompaña por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    Else ' No hay Avales
                        Response.Write("<p>" & Espacios & Espacios & "En la escritura pública en que consta el referido mutuo se estipuló que el no pago oportuno de cualquier dividendo daría derecho al Banco para exigir el pago de toda la obligación, como si fuere de plazo vencido. </p>")
                        Response.Write("<p>" & Espacios & Espacios & "El mutuo y la hipoteca constan de " & "una" & " escritura pública cuya copia autorizada se acompaña por lo que tienen mérito ejecutivo en conformidad con la Ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
                    End If
                End If
            End If
        End If
        Response.Write("<p>" & Espacios & Espacios & CarpetaJudicial.LeerNombreCompletoDemandados(CarpetaJudicialCodigo) & CarpetaJudicialCreditos.LeerTotalDeuda(CarpetaJudicialCodigo) & " incluidos los intereses pactados y los intereres moratorios indicados. </p>")
        ' Vamos a hacer el circuito de los Pagare
        NumeroCreditos = CarpetaJudicialCreditos.LeerCreditosIdPorTipo(CarpetaJudicialCodigo, "Pagare", CreditosId)
        i = 0
        If NumeroCreditos > 0 Then  'Tenemos mutuos a describir, uno o más.
            For i = 1 To NumeroCreditos
                Response.Write(CarpetaJudicialCreditos.ParrafoMutuoPagare(CreditosId(i), i))
            Next
            Response.Write("<p>" & Espacios & Espacios & "En caso de mora en el pago de cualquier cuota se devengan intereses penales o moratorios equivalentes al máximo que la ley permite estipular para operaciones de crédito de dinero en moneda nacional que se aplican desde la fecha de la mora hasta el pago efectivo de toda la deuda.</p>")
            Response.Write("<p>" & Espacios & Espacios & "La firma del suscriptor del pagaré está autorizada  por Notario Público, por lo que tiene mérito ejecutivo en conformidad a la ley. La deuda es líquida, actualmente exigible y su acción no ha prescrito.</p>")
            Response.Write("<p>" & Espacios & Espacios & "Conforme a lo anterior, vengo en demandar ejecutivamente a " & CarpetaJudicial.LeerNombreCompletoDeudor(CreditosId(1)) & " por " & CarpetaJudicialCreditos.LeerTotalDeudaPagares(CarpetaJudicialCodigo) & " más los  intereses pactados y los intereses penales o moratorios que se han indicado.</p>")
        End If
        Response.Write(Espacios & Espacios & "<b>POR TANTO</b>")

        Response.Write("<p>en mérito de lo expuesto, de los documentos que se acompañan y  conforme lo establecen los artículos 434 y siguientes del Código de Procedimiento Civil, a V.S. ruego se sirva tener por presentada demanda ejecutiva en contra de " & CarpetaJudicial.LeerNombreCompletoDemandadosPORTANTO(CarpetaJudicialCodigo) & CarpetaJudicialCreditos.LeerTotalDeuda(CarpetaJudicialCodigo) & " incluidos los intereses pactados y los intereses moratorios indicados")
        NumeroCreditos = CarpetaJudicialCreditos.LeerCreditosIdPorTipo(CarpetaJudicialCodigo, "Pagare", CreditosId)
        If NumeroCreditos > 0 Then  'Tenemos pagarés a describir, uno o más.
            Response.Write(", y a " & CarpetaJudicial.LeerNombreCompletoDeudor(CreditosId(1)) & " por " & CarpetaJudicialCreditos.LeerTotalDeudaPagares(CarpetaJudicialCodigo) & " más los  intereses pactados y los intereses penales o moratorios ya citados")
        End If
        Response.Write(", y disponer se siga adelante con la ejecución hasta hacerse íntegro pago de toda la deuda, con costas.</p>")
        Response.Write("<p><b>PRIMER OTROSÍ:</b> ruego a V.S. tener presente que señalo para la traba de embargo todos los bienes que aparezcan a nombre o en posesión ")
        If TotalAvales > 1 Then
            Response.Write("de los demandados, en especial, ")
        Else
            Response.Write("del demandado, en especial, ")
        End If
        Response.Write(CarpetaJudicial.ParrafoHipotecaPRIMEROTROSI(CarpetaJudicialCodigo))
        If TotalHipotecas > 1 Then
            Response.Write(", bienes que quedarán en  poder de ")
            If TotalAvales > 1 Then
                Response.Write("los deudores, como depositarios provisionales bajo su responsabilidad legal, sin perjuicio de la designación de un depositario definitivo que solicitará esta parte.</p>")
            Else
                Response.Write("el deudor, como depositario provisional bajo su responsabilidad legal, sin perjuicio de la designación de un depositario definitivo que solicitará esta parte.</p>")
            End If
        Else
            Response.Write(", bien que quedará en  poder de ")
            If TotalAvales > 1 Then
                Response.Write("los deudores, como depositarios provisionales bajo su responsabilidad legal, sin perjuicio de la designación de un depositario definitivo que solicitará esta parte.</p>")
            Else
                Response.Write("el deudor, como depositario provisional bajo su responsabilidad legal, sin perjuicio de la designación de un depositario definitivo que solicitará esta parte.</p>")
            End If
        End If
        Response.Write("<p><b>SEGUNDO OTROSÍ:</b> sírvase V.S. tener por acompañados los siguientes documentos con citación:</p>")
        Response.Write("<p>1.- Copia autorizada de " & CarpetaJudicial.ParrafoEscriturasPublicas(CarpetaJudicialCodigo) & "</p>")
        TotalMutos = CarpetaJudicialCreditos.LeerCreditosIdPorTipo(CarpetaJudicialCodigo, "Mutuo", CreditosId) + CarpetaJudicialCreditos.LeerCreditosIdPorTipo(CarpetaJudicialCodigo, "Mutuo Complementario", CreditosId)
        TotalPagares = CarpetaJudicialCreditos.LeerCreditosIdPorTipo(CarpetaJudicialCodigo, "Pagare", CreditosId)
        Select Case TotalMutos
            Case 0
                Select Case TotalPagares
                    Case 0
                        Response.Write("<p>2. Copia autorizada de la escritura pública de fecha 1 de Marzo de 2012, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, en la cual consta mi personería por el banco Scotiabank Chile.</p>")
                        If Vaelquintootrosi = True Then
                            Response.Write("<p>3.- Copia autorizada de la escritura pública de fecha 2 de Noviembre de 2009, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, citada en el cuarto otrosí.</p>")
                        End If
                    Case 1
                        Response.Write("<p>2.- Original del pagaré y copia del  Cronograma de plan de pagos del mismo.</p>")
                        Response.Write("<p>3. Copia autorizada de la escritura pública de fecha 1 de Marzo de 2012, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, en la cual consta mi personería por el banco Scotiabank Chile.</p>")
                        If Vaelquintootrosi = True Then
                            Response.Write("<p>4.- Copia autorizada de la escritura pública de fecha 2 de Noviembre de 2009, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, citada en el cuarto otrosí.</p>")
                        End If
                    Case Is > 1
                        Response.Write("<p>2.- Originales de los pagaré y copia del  Cronograma de plan de pagos de los mismos.</p>")
                        Response.Write("<p>3. Copia autorizada de la escritura pública de fecha 1 de Marzo de 2012, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, en la cual consta mi personería por el banco Scotiabank Chile.</p>")
                        If Vaelquintootrosi = True Then
                            Response.Write("<p>4.- Copia autorizada de la escritura pública de fecha 2 de Noviembre de 2009, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, citada en el cuarto otrosí.</p>")
                        End If
                End Select
            Case 1
                Response.Write("<p>2.- Liquidación de las deudas por el mutuo citada.</p>")
                Select Case TotalPagares
                    Case 0
                        Response.Write("<p>3. Copia autorizada de la escritura pública de fecha 1 de Marzo de 2012, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, en la cual consta mi personería por el banco Scotiabank Chile.</p>")
                        If Vaelquintootrosi = True Then
                            Response.Write("<p>4.- Copia autorizada de la escritura pública de fecha 2 de Noviembre de 2009, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, citada en el cuarto otrosí.</p>")
                        End If
                    Case 1
                        Response.Write("<p>3.- Original del pagaré y copia del  Cronograma de plan de pagos del mismo.</p>")
                        Response.Write("<p>4. Copia autorizada de la escritura pública de fecha 1 de Marzo de 2012, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, en la cual consta mi personería por el banco Scotiabank Chile.</p>")
                        If Vaelquintootrosi = True Then
                            Response.Write("<p>5.- Copia autorizada de la escritura pública de fecha 2 de Noviembre de 2009, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, citada en el cuarto otrosí.</p>")
                        End If
                    Case Is > 1
                        Response.Write("<p>3.- Originales de los pagaré y copia del  Cronograma de plan de pagos de los mismos.</p>")
                        Response.Write("<p>4. Copia autorizada de la escritura pública de fecha 1 de Marzo de 2012, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, en la cual consta mi personería por el banco Scotiabank Chile.</p>")
                        If Vaelquintootrosi = True Then
                            Response.Write("<p>5.- Copia autorizada de la escritura pública de fecha 2 de Noviembre de 2009, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, citada en el cuarto otrosí.</p>")
                        End If
                End Select

            Case Is > 1
                Response.Write("<p>2.- Liquidación de las deudas por los mutuos citada.</p>")
                Select Case TotalPagares
                    Case 0
                        Response.Write("<p>3. Copia autorizada de la escritura pública de fecha 1 de Marzo de 2012, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, en la cual consta mi personería por el banco Scotiabank Chile.</p>")
                        If Vaelquintootrosi = True Then
                            Response.Write("<p>4.- Copia autorizada de la escritura pública de fecha 2 de Noviembre de 2009, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, citada en el cuarto otrosí.</p>")
                        End If
                    Case 1
                        Response.Write("<p>3.- Original del pagaré y copia del  Cronograma de plan de pagos del mismo.</p>")
                        Response.Write("<p>4. Copia autorizada de la escritura pública de fecha 1 de Marzo de 2012, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, en la cual consta mi personería por el banco Scotiabank Chile.</p>")
                        If Vaelquintootrosi = True Then
                            Response.Write("<p>5.- Copia autorizada de la escritura pública de fecha 2 de Noviembre de 2009, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, citada en el cuarto otrosí.</p>")
                        End If
                    Case Is > 1
                        Response.Write("<p>3.- Originales de los pagaré y copia del  Cronograma de plan de pagos de los mismos.</p>")
                        Response.Write("<p>4. Copia autorizada de la escritura pública de fecha 1 de Marzo de 2012, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, en la cual consta mi personería por el banco Scotiabank Chile.</p>")
                        If Vaelquintootrosi = True Then
                            Response.Write("<p>5.- Copia autorizada de la escritura pública de fecha 2 de Noviembre de 2009, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, citada en el cuarto otrosí.</p>")
                        End If
                End Select
        End Select
        Response.Write("<p><b>TERCER OTROSÍ:</b> ruego a V.S. tener presente que designo abogado patrocinante y otorgo poder a don Jorge Montes Bezanilla, patente de la Municipalidad de Santiago Nº 410.610-5 y que confiero poder a doña María Paz Montes Bezanilla, abogado, patente al día Nº 420.642-8 de la citada Municipalidad, ambos domiciliados en calle San Pío X, Oficina 1304, Providencia, quienes podrán actuar en forma separada e indistinta.</p>")

        If EsConExhorto = True Then
            ParrafoExhorto = "ruego a V.S. se sirva disponer se despache exhorto al Juzgado de Turno de " & CiudadDemanda & ", con el objeto que ese Tribunal ordene la notificación y requerimiento de la demanda como, asimismo, notificar al respectivo Conservador del embargo del inmueble inscrito en su Registro, a saber, la notificación en el domicilio de " & CarpetaJudicial.LeerIdentificacionProfesionDireccion(CarpetaJudicialCodigo)
            ParrafoExhorto = ParrafoExhorto & " y el embargo de todos los bienes que aparezcan a nombre o en posesión "
            If TotalAvales > 1 Then
                ParrafoExhorto = ParrafoExhorto & "de los demandados, en especial, "
            Else
                ParrafoExhorto = ParrafoExhorto & "del demandado, en especial, "
            End If
            ParrafoExhorto = ParrafoExhorto & CarpetaJudicial.ParrafoHipotecaPRIMEROTROSI(CarpetaJudicialCodigo)
        End If


        If Vaelquintootrosi = True Then
            Response.Write("<p><b>CUARTO OTROSÍ:</b> los antecedentes de la fusión del Banco del Desarrollo y el Scotiabank Chile, son los siguientes: por escritura pública de fecha 2 de Noviembre de 2009, otorgada en la Notaría de Santiago de don Eduardo Diez Morello, se hizo constar que en Juntas Extraordinarias de Accionistas de Scotiabank Sud Americano y de Banco del  Desarrollo, celebradas con fecha 31 de Marzo de 2008 y cuyas actas fueron reducidas a escritura pública en la Notaría de Santiago de don Eduardo Diez Morello, con fechas 15 y 17 de Abril de 2008, se aprobaron, entre otras materias, 1) la fusión de ambos bancos mediante la incorporación de Banco del Desarrollo en Scotiabank Sud Americano; 2) los estatutos por los que pasará a regirse la entidad fusionada una vez que se materialice la fusión, bajo la denominación SCOTIABANK CHILE y 3) la delegación en el Directorio de ambos bancos, en los términos indicados en el acta, la facultad para fijar la fecha en se materializaría la fusión. Con fecha 27 de Abril de 2008 se solicitó a la Superintendencia de Bancos e Instituciones Financieras la aprobación de la fusión de ambos bancos en los términos acordados por las respectivas Juntas Extraordinarias de Accionistas, de la correspondiente reforma de estatutos de Scotiabank Sud Americano, de los estatutos que pasarán a regir a la entidad fusionada con el nombre de SCOTIABANK CHILE y la disolución anticipada de Banco del Desarrollo, al momento que se materialice la fusión. Dicha aprobación fue otorgada por la mencionada Superintendencia mediante Resolución N° 97 de fecha 7 de Mayo de 2008. Con fecha 19 de Agosto de 2009 se solicitó a la Superintendencia de Bancos e Instituciones Financieras la aprobación de la modificación relativa al nombre, en los términos acordados por las respectivas Juntas Extraordinarias de Accionista y de los estatutos que pasará a regir a la entidad fusionada. La aprobación fue otorgada por la referida Superintendencia mediante Resolución N° 96 de fecha 2 de Septiembre de 2009.</p>")
            Response.Write("<p>" & Espacios & Espacios & "Como consecuencia, de la materialización de la fusión, SCOTIABANK CHILE, como entidad fusionada, ha pasado a ser la continuadora legal de Banco del Desarrollo para todos los efectos legales.</p>")
            If EsConExhorto = True Then
                Response.Write("<p><b>QUINTO OTROSÍ:</b>" & ParrafoExhorto & "</p>")
                Response.Write("<p>El exhorto podrá ser conducido y tramitado por un apoderado de esta parte y deberá contener copia íntegra de esta demanda, sus resoluciones, y del mandamiento de ejecución y embargo.</p>")
            End If
        Else
            If EsConExhorto = True Then
                Response.Write("<p><b>CUARTO OTROSÍ:</b>" & ParrafoExhorto & "</p>")
                Response.Write("<p>El exhorto podrá ser conducido y tramitado por un apoderado de esta parte y deberá contener copia íntegra de esta demanda, sus resoluciones, y del mandamiento de ejecución y embargo.</p>")
            End If
        End If

        Response.Write("<p>Sírvase V.S. tenerlo presente.</p>")
        Response.Write("</td></tr></table>")
        Response.Write("</div>")
        Response.Write("</font>")
        Response.Write("</body>")
        Response.Write("</html>")
        HttpContext.Current.Response.Flush()


    End Sub
End Class
