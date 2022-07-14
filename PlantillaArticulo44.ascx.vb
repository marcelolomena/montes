
Partial Class PlantillaArticulo44
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
        Dim RolJuicio As String
        Dim FechaPresentacion As Date
        Dim Tribunal As String
        Dim TasaInteresAnual As Double

        t = Tareas.LeerIdentificacionDeudorbyTareasId(Request.QueryString("Id"), Rut, Nombres, Apellidos)
        t = Tareas.LeerMasAntecedentesbyTareasId(Request.QueryString("Id"), Profesion)
        t = Tareas.LeerJuzgadoRolbyTareasId(Request.QueryString("Id"), RolJuicio, FechaPresentacion, Tribunal)

        lblNombreDeudor.Text = Nombres & " " & Apellidos
        lblRol.Text = RolJuicio

    End Sub
End Class
