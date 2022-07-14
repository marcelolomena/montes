
Partial Class PlantillaDemanda
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim t As Boolean = False
        Dim Tareas As New Tareas

        Dim Rut As String = ""
        Dim Nombres As String = ""
        Dim Apellidos As String
        Dim Ciudad As String
        Dim Direccion As String
        Dim Comuna As String
        Dim Profesion As String
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

        t = Tareas.LeerIdentificacionDeudorbyTareasId(Request.QueryString("Id"), Rut, Nombres, Apellidos)
        t = Tareas.LeerMasAntecedentesbyTareasId(Request.QueryString("Id"), Profesion)

        lblDeudor.Text = UCase(Nombres) & " " & UCase(Apellidos)
        lblRutDeudor.Text = Rut

        lblFechaEscritura.Text = FechaEscritura
        lblCiudadEscritura.Text = CiudadEscritura
        lblNotarioEscritura.Text = NotarioEscritura

        lblNombreDeudor.Text = Nombres & " " & Apellidos
        lblMontoUF.Text = FormatNumber(MontoUF / 100, 2)

        lblMesesPlazo.Text = MesesPlazo
        lblFechaInicio.Text = FechaInicio

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

        lblInmuebleFojas.Text = InmuebleFojas
        lblInmuebleNumero.Text = InmuebleNumero
        lblInmuebleAno.Text = InmuebleAno
        lblInmuebleCiudad.Text = InmuebleCiudad

        lblHipotecaFojas.Text = HipotecaFojas
        lblHipotecaNumero.Text = HipotecaNumero
        lblHipotecaAno.Text = HipotecaAno
        lblHipotecaCiudad.Text = HipotecaCiudad

        lblDescripcionBien.Text = DescripcionBien

    End Sub
End Class
