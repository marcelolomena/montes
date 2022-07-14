Imports Microsoft.Office.Interop.Word
Partial Class PlantillaDemandaJuicioEjecutivo
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim t As Boolean = False
        Dim Tareas As New Tareas

        Dim Rut As String = ""
        Dim Nombres As String = ""
        Dim Apellidos As String = ""
        Dim Ciudad As String = ""
        Dim Direccion As String = ""
        Dim Comuna As String = ""
        Dim Profesion As String = ""
        Dim EstadoCivil As String
        Dim FechaEscritura As Date
        Dim CiudadEscritura As String
        Dim NotarioEscritura As String
        Dim MontoUF As Double
        Dim MesesPlazo As Integer
        Dim FechaInicio As Date
        Dim DeudaCapitalUF As Double
        Dim DeudaCapitalPesos As Double
        Dim DeudaDividendosUF As Double
        Dim DeudaDividendosPesos As Double
        Dim InmuebleFojas As String
        Dim InmuebleNumero As String
        Dim InmuebleAno As Integer
        Dim InmuebleCiudad As String
        Dim HipotecaFojas As String
        Dim HipotecaNumero As String
        Dim HipotecaAno As Integer
        Dim HipotecaCiudad As String
        Dim DescripcionBien As String
        Dim TasaInteresAnual As Double
        Dim CodigoHTML As String = ""
        Dim TareasAvales As New TareasAvales
        Dim TareasHipotecas As New TareasHipotecas
        Dim TareasGarantias As New TareasGarantias
        Dim TareasOtrosBienes As New TareasOtrosBienes
        Dim TareasDocs As New TareasDocs
        Dim TareasCodigo As String = ""


        t = Tareas.LeerIdentificacionDeudorbyTareasId(Request.QueryString("Id"), Rut, Nombres, Apellidos)
        t = Tareas.LeerMasAntecedentesbyTareasId(Request.QueryString("Id"), Profesion)
        t = Tareas.LeerTareasCodigoById(Request.QueryString("Id"), TareasCodigo)
        CodigoHTML = TareasAvales.LeerAvalesDemandados(TareasCodigo, 1)
        MyAvales.Controls.Add(New LiteralControl(CodigoHTML))
        CodigoHTML = TareasHipotecas.LeerLasHipotecas(TareasCodigo, 1)
        LasHipotecas.Controls.Add(New LiteralControl(CodigoHTML))
        CodigoHTML = TareasGarantias.LeerLasGarantias(TareasCodigo, 1, Nombres & " " & Apellidos)
        LasGarantias.Controls.Add(New LiteralControl(CodigoHTML))
        CodigoHTML = TareasOtrosBienes.LeerLosOtrosBienes(TareasCodigo, 1)
        LasGarantias.Controls.Add(New LiteralControl(CodigoHTML))
        CodigoHTML = TareasAvales.LeerAvalesDemandados(TareasCodigo, 2)
        LosAvales.Controls.Add(New LiteralControl(CodigoHTML))
        CodigoHTML = TareasAvales.LeerAvalesDemandados(TareasCodigo, 3, DeudaCapitalUF, DeudaCapitalPesos, DeudaDividendosUF, DeudaDividendosPesos)
        LosAvalesDemandados.Controls.Add(New LiteralControl(CodigoHTML))
        CodigoHTML = TareasAvales.LeerAvalesDemandados(TareasCodigo, 4)
        LosDemandados.Controls.Add(New LiteralControl(CodigoHTML))
        CodigoHTML = TareasDocs.LeerLosDocumentos(TareasCodigo, 1)
        LosDocumentos.Controls.Add(New LiteralControl(CodigoHTML))


        lblDeudor.Text = UCase(Nombres) & " " & UCase(Apellidos)
        lblRutDeudor.Text = Rut

        lblFechaEscritura.Text = FechaEscritura
        lblCiudadEscritura.Text = CiudadEscritura
        lblNotarioEscritura.Text = NotarioEscritura

        lblNombreDeudor.Text = Nombres & " " & Apellidos
        lblNombreDeudor1.Text = Nombres & " " & Apellidos
        lblNombreDeudor2.Text = Nombres & " " & Apellidos
        lblNombreDeudor3.Text = Nombres & " " & Apellidos
        lblMontoUF.Text = FormatNumber(MontoUF / 100, 2)

        lblMesesPlazo.Text = MesesPlazo
        lblTasaInteresAnual.Text = FormatNumber(TasaInteresAnual / 100, 2)

        lblMesInicio.Text = Tareas.LeerFechaEntroEnMora(Request.QueryString("Id"))

        lblDeudaCapitalUF.Text = FormatNumber(DeudaCapitalUF / 100, 2)
        lblDeudaCapitalUF1.Text = FormatNumber(DeudaCapitalUF / 100, 2)
        lblDeudaCapitalUF2.Text = FormatNumber(DeudaCapitalUF / 100, 2)

        lblDeudaCapitalPesos.Text = FormatNumber(DeudaCapitalPesos / 100, 2)
        lblDeudaCapitalPesos1.Text = FormatNumber(DeudaCapitalPesos / 100, 2)
        lblDeudaCapitalPesos2.Text = FormatNumber(DeudaCapitalPesos / 100, 2)

        lblDeudaDividendosUF.Text = FormatNumber(DeudaDividendosUF / 100, 2)
        lblDeudaDividendosUF1.Text = FormatNumber(DeudaDividendosUF / 100, 2)
        lblDeudaDividendosUF2.Text = FormatNumber(DeudaDividendosUF / 100, 2)

        lblDeudaDividendosPesos.Text = FormatNumber(DeudaDividendosPesos / 100, 2)
        lblDeudaDividendosPesos1.Text = FormatNumber(DeudaDividendosPesos / 100, 2)
        lblDeudaDividendosPesos2.Text = FormatNumber(DeudaDividendosPesos / 100, 2)

        lblProfesion.Text = Profesion
        lblDomicilio.Text = Direccion
        lblComuna.Text = Comuna

        LblRepresentanteBanco.Text = CarpetaJudicial.LeerRepresentanteBancoByTareasId(Request.QueryString("Id"))

        Dim oWordApp As New Application

        Dim DocumentoWord As New Document
        Dim qk = HttpContext.Current.Server.MapPath(".")
        Dim rutaOrigen As String = qk & "\" & "FileExcel\DemandaEjecutiva.docx"
        Dim rutaDestino As String = qk & "\" & "DownLoadExcel\"
        Dim archivoDestino As String = "DemandaScotiabankCon" & Apellidos & ".docx"
        rutaDestino &= archivoDestino
        DocumentoWord = oWordApp.Documents.Add(rutaOrigen)

        DocumentoWord.Activate()

        oWordApp.Selection.GoTo(, , , "NombreDeudor")
        oWordApp.Selection.TypeText(lblNombreDeudor.Text)

        oWordApp.Selection.GoTo(, , , "CiudadEscritura")
        oWordApp.Selection.TypeText(lblCiudadEscritura.Text)

        oWordApp.Selection.GoTo(, , , "Deudor")
        oWordApp.Selection.TypeText(lblDeudor.Text)

        oWordApp.Selection.GoTo(, , , "FechaEscritura")
        oWordApp.Selection.TypeText(FormatDateTime(lblFechaEscritura.Text, DateFormat.ShortDate))

        oWordApp.Selection.GoTo(, , , "NotarioEscritura")
        oWordApp.Selection.TypeText(lblNotarioEscritura.Text)

        oWordApp.Selection.GoTo(, , , "RutDeudor")
        oWordApp.Selection.TypeText(lblRutDeudor.Text)

        DocumentoWord.SaveAs2(rutaDestino)

        oWordApp.Application.Quit()

        HyperLink1.NavigateUrl = "~/DownLoadExcel/" & archivoDestino
        HyperLink1.Target = "_blank"



    End Sub
End Class
