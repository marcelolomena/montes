Imports AjaxControlToolkit
Partial Class FichaCarpetaJudicialCreditos
    Inherits System.Web.UI.UserControl

    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 25-02-2012 6:49:09
    '------------------------------------------------------------
    ' Declaración de botones del formulario
    '----------------------------------------
    Dim WithEvents LoginButton As Button
    Dim WithEvents UpdateButton As Button
    Dim WithEvents CancelButton As Button
    Dim WithEvents NewButton As Button
    Dim WithEvents SearchButton As Button
    Dim WithEvents DeleteButton As Button
    Dim WithEvents ReturnButton As Button
    '----------------------------------------
    ' Declaración de controles de validación
    '----------------------------------------
    Dim valTextBox As RequiredFieldValidator
    Dim sumValidacion As ValidationSummary
    Dim REValidacion As RegularExpressionValidator
    Dim CuValidacion As CustomValidator
    Dim CoValidacion As CompareValidator
    '------------------------------------------
    ' Declaración de Variables de la Aplicación
    '------------------------------------------
    Dim t As Boolean = False
    Dim Logo As String = ""
    Dim BarMenu As String = ""
    Dim SideBarMenu As String = ""
    Dim PaginaWebName As String = ""
    '----------------------------------------
    ' Declaración de Controles del Formulario
    '----------------------------------------
    Dim txtCarpetaJudicialCodigo As TextBox ' Etiqueta : # Interno - Control : txtCarpetaJudicialCodigo - Variable : CarpetaJudicialCodigo
    Dim txtCarpetaJudicialCreditosSecuencia As TextBox ' Etiqueta : # Secuencia - Control : txtCarpetaJudicialGastosSecuencia - Variable : CarpetaJudicialGastosSecuencia
    Dim txtTipoCreditoName As TextBox ' Etiqueta : # Secuencia - Control : txtCarpetaJudicialGastosSecuencia - Variable : CarpetaJudicialGastosSecuencia
    Dim txtCarpetaJudicialCreditosNroOperacion As TextBox ' Etiqueta : # Operación - Control : txtCarpetaJudicialNroOperacion - Variable : CarpetaJudicialNroOperacion
    Dim txtCarpetaJudicialCreditosCapInicial As TextBox ' Etiqueta : Capital Inicial - Control : txtCarpetaJudicialCapInicial - Variable : CarpetaJudicialCapInicial
    Dim txtCarpetaJudicialCreditosMoneda As TextBox ' Etiqueta : Moneda - Control : txtCarpetaJudicialMoneda - Variable : CarpetaJudicialMoneda
    Dim txtCarpetaJudicialCreditosFechaSuscripcion As TextBox ' Etiqueta : Fecha Suscripción - Control : txtCarpetaJudicialFechaSuscripcion - Variable : CarpetaJudicialFechaSuscripcion
    Dim txtCarpetaJudicialCreditosFechaEntroEnMora As TextBox ' Etiqueta : Fecha entro en mora - Control : txtCarpetaJudicialFechaEntroEnMora - Variable : CarpetaJudicialFechaEntroEnMora
    Dim txtBancoPrestamistaName As TextBox
    Dim txtCarpetaJudicialCreditosMesesPlazo As TextBox
    Dim txtCarpetaJudicialCreditosTasaInteresAnual As TextBox
    Dim txtCarpetaJudicialCreditosFechaPrimerVencimiento As TextBox
    Dim txtCarpetaJudicialCreditosValorCuota As TextBox
    Dim txtCarpetaJudicialCreditosUltimaCuota As TextBox
    Dim txtCarpetaJudicialCreditosFechaEscritura As TextBox
    Dim txtCarpetaJudicialCreditosNotarioEscritura As TextBox
    Dim txtCarpetaJudicialCreditosCiudadEscritura As TextBox
    Dim txtCarpetaJudicialCreditosDeudaCapitalPesos As TextBox
    Dim txtCarpetaJudicialCreditosDeudaCapitalUF As TextBox
    Dim txtCarpetaJudicialCreditosDeudaDividendosPesos As TextBox
    Dim txtCarpetaJudicialCreditosDeudaDividendosUF As TextBox
    Dim txtCarpetaJudicialCreditosInteresesPenalesPesos As TextBox
    Dim txtCarpetaJudicialCreditosInteresesPenalesUF As TextBox
    Dim txtCarpetaJudicialCreditosDeudaTotalPesos As TextBox
    Dim txtCarpetaJudicialCreditosDeudaTotalUF As TextBox

    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim CarpetaJudicialCodigo As String ' Etiqueta : # Interno - Control : txtCarpetaJudicialCodigo - Variable : CarpetaJudicialCodigo
    Dim CarpetaJudicialCreditosSecuencia As Long ' Etiqueta : # Secuencia - Control : txtCarpetaJudicialGastosSecuencia - Variable : CarpetaJudicialGastosSecuencia
    Dim TipoCreditoName As String
    Dim CarpetaJudicialCreditosNroOperacion As String ' Etiqueta : # Operación - Control : txtCarpetaJudicialNroOperacion - Variable : CarpetaJudicialNroOperacion
    Dim CarpetaJudicialCreditosCapInicial As Double ' Etiqueta : Capital Inicial - Control : txtCarpetaJudicialCapInicial - Variable : CarpetaJudicialCapInicial
    Dim CarpetaJudicialCreditosMoneda As String ' Etiqueta : Moneda - Control : txtCarpetaJudicialMoneda - Variable : CarpetaJudicialMoneda
    Dim CarpetaJudicialCreditosFechaSuscripcion As Date ' Etiqueta : Fecha Suscripción - Control : txtCarpetaJudicialFechaSuscripcion - Variable : CarpetaJudicialFechaSuscripcion
    Dim CarpetaJudicialCreditosFechaEntroEnMora As Date ' Etiqueta : Fecha entro en mora - Control : txtCarpetaJudicialFechaEntroEnMora - Variable : CarpetaJudicialFechaEntroEnMora
    Dim BancoPrestamistaName As String
    Dim CarpetaJudicialCreditosMesesPlazo As Long
    Dim CarpetaJudicialCreditosTasaInteresAnual As Double
    Dim CarpetaJudicialCreditosFechaPrimerVencimiento As Date
    Dim CarpetaJudicialCreditosValorCuota As Double
    Dim CarpetaJudicialCreditosUltimaCuota As Double
    Dim CarpetaJudicialCreditosFechaEscritura As Date
    Dim CarpetaJudicialCreditosNotarioEscritura As String
    Dim CarpetaJudicialCreditosCiudadEscritura As String
    Dim CarpetaJudicialCreditosDeudaCapitalPesos As Double
    Dim CarpetaJudicialCreditosDeudaCapitalUF As Double
    Dim CarpetaJudicialCreditosDeudaDividendosPesos As Double
    Dim CarpetaJudicialCreditosDeudaDividendosUF As Double
    Dim CarpetaJudicialCreditosInteresesPenalesPesos As Double
    Dim CarpetaJudicialCreditosInteresesPenalesUF As Double
    Dim CarpetaJudicialCreditosDeudaTotalPesos As Double
    Dim CarpetaJudicialCreditosDeudaTotalUF As Double

    '----------------------------------------
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Try
            t = CarpetaJudicialCreditos.CarpetaJudicialCreditosDelete(Session("Id"), Request.QueryString("MasterName"), CLng(Session("PersonaId")))
        Catch
            t = 0
        End Try
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_Return(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReturnButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLReturn", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim Url As String = ""
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas
        Dim CarpetaJudicialCodigo As String = ""

        t = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))
        Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & Request.QueryString("MasterName") & "&MasterId=" & Request.QueryString("MasterId")

        If NombrePagina = "Ficha de TareasCreditos" Then
            'MasterName cambia al código de la caprpeta judicial
            'MasterId se mantiene en el Id de la Tarea.
            CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
            Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & CarpetaJudicialCodigo & "&MasterId=" & Request.QueryString("MasterId")
        End If


        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim Url As String = ""
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas
        Dim CarpetaJudicialCodigo As String = ""
        Dim Monto As Double = 0

        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Session("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & Request.QueryString("MasterName") & "&MasterId=" & Request.QueryString("MasterId")
        If NombrePagina = "Ficha de TareasCreditos" Then
            'MasterName cambia al código de la caprpeta judicial
            'MasterId se mantiene en el Id de la Tarea.
            CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
            Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Session("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & CarpetaJudicialCodigo & "&MasterId=" & Request.QueryString("MasterId")
        End If

        Monto = CDbl(txtCarpetaJudicialCreditosCapInicial.Text)
        If Monto < 100000 Then
            txtCarpetaJudicialCreditosMoneda.Text = "UF"
        Else
            txtCarpetaJudicialCreditosMoneda.Text = "Pesos"
        End If


        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Try
            t = CarpetaJudicialCreditos.CarpetaJudicialCreditosUpdate(Session("Id"), CStr(txtCarpetaJudicialCodigo.Text), CLng(txtCarpetaJudicialCreditosSecuencia.Text), CStr(txtTipoCreditoName.Text), CStr(txtCarpetaJudicialCreditosNroOperacion.Text), CDbl(txtCarpetaJudicialCreditosCapInicial.Text * 10000), CStr(txtCarpetaJudicialCreditosMoneda.Text), CDate(txtCarpetaJudicialCreditosFechaSuscripcion.Text), CDate(txtCarpetaJudicialCreditosFechaEntroEnMora.Text), CStr(txtBancoPrestamistaName.Text), CLng(txtCarpetaJudicialCreditosMesesPlazo.Text), CDbl(txtCarpetaJudicialCreditosTasaInteresAnual.Text * 10000), CDate(txtCarpetaJudicialCreditosFechaPrimerVencimiento.Text), CDbl(txtCarpetaJudicialCreditosValorCuota.Text * 10000), CDbl(txtCarpetaJudicialCreditosUltimaCuota.Text * 10000), CDate(txtCarpetaJudicialCreditosFechaEscritura.Text), CStr(txtCarpetaJudicialCreditosNotarioEscritura.Text), CStr(txtCarpetaJudicialCreditosCiudadEscritura.Text), CDbl(txtCarpetaJudicialCreditosDeudaCapitalPesos.Text * 10000), CDbl(txtCarpetaJudicialCreditosDeudaCapitalUF.Text * 10000), CDbl(txtCarpetaJudicialCreditosDeudaDividendosPesos.Text * 10000), CDbl(txtCarpetaJudicialCreditosDeudaDividendosUF.Text * 10000), CDbl(txtCarpetaJudicialCreditosInteresesPenalesPesos.Text * 10000), CDbl(txtCarpetaJudicialCreditosInteresesPenalesUF.Text * 10000), CDbl(txtCarpetaJudicialCreditosDeudaTotalPesos.Text * 10000), CDbl(txtCarpetaJudicialCreditosDeudaTotalUF.Text * 10000), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url, True)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas
        Dim sSQLWhere As String = ""
        Dim sSQLOrder As String = ""

        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim PaginaWebName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim MasterName As String = "" ' Guarda el nombre del Maestro al que pertenece el detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina

        If Request.QueryString("PaginaWebName") = "Ficha de TareasCreditos" Then
            CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
            MyDeudor.Controls.Add(New LiteralControl(Tareas.ListarDatosDelDeudorPorTareasId(CLng(Request.QueryString("MasterId")), CarpetaJudicialCodigo)))
        End If

        Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler DeleteButton.Click, AddressOf RFC_Delete
        AddHandler ReturnButton.Click, AddressOf RFC_Return
        Try
            If Not IsPostBack Then
                MasterName = Request.QueryString("MasterName")
                If Request.QueryString("PaginaWebName") = "Ficha de TareasCreditos" Then
                    MasterName = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
                End If
                Session("MasterId") = Request.QueryString("MasterId")
                DetailId = Request.QueryString("Id")
                If DetailId = 0 Then
                    DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("CarpetaJudicialCodigo", "CarpetaJudicialCreditosSecuencia", "CarpetaJudicialCreditos", MasterName)
                    t = AccionesABM.ObjectPartialInsert("CarpetaJudicialCreditosId", "CarpetaJudicialCodigo", "CarpetaJudicialCreditosSecuencia", "CarpetaJudicialCreditos", MasterName, DetailSecuencia, CLng(Session("PersonaId")), DetailId)
                End If
                Session("Id") = DetailId

                If t = CarpetaJudicialCreditos.LeerCarpetaJudicialCreditos(Session("Id"), CarpetaJudicialCodigo, CarpetaJudicialCreditosSecuencia, TipoCreditoName, CarpetaJudicialCreditosNroOperacion, CarpetaJudicialCreditosCapInicial, CarpetaJudicialCreditosMoneda, CarpetaJudicialCreditosFechaSuscripcion, CarpetaJudicialCreditosFechaEntroEnMora, BancoPrestamistaName, CarpetaJudicialCreditosMesesPlazo, CarpetaJudicialCreditosTasaInteresAnual, CarpetaJudicialCreditosFechaPrimerVencimiento, CarpetaJudicialCreditosValorCuota, CarpetaJudicialCreditosUltimaCuota, CarpetaJudicialCreditosFechaEscritura, CarpetaJudicialCreditosNotarioEscritura, CarpetaJudicialCreditosCiudadEscritura, CarpetaJudicialCreditosDeudaCapitalPesos, CarpetaJudicialCreditosDeudaCapitalUF, CarpetaJudicialCreditosDeudaDividendosPesos, CarpetaJudicialCreditosDeudaDividendosUF, CarpetaJudicialCreditosInteresesPenalesPesos, CarpetaJudicialCreditosInteresesPenalesUF, CarpetaJudicialCreditosDeudaTotalPesos, CarpetaJudicialCreditosDeudaTotalUF) Then
                    txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                    txtCarpetaJudicialCodigo.Text = CarpetaJudicialCodigo
                    txtCarpetaJudicialCreditosSecuencia = FindControl("txtCarpetaJudicialCreditosSecuencia")
                    txtCarpetaJudicialCreditosSecuencia.Text = CarpetaJudicialCreditosSecuencia
                    txtTipoCreditoName = FindControl("txtTipoCreditoName")
                    txtTipoCreditoName.Text = TipoCreditoName
                    txtCarpetaJudicialCreditosNroOperacion = FindControl("txtCarpetaJudicialCreditosNroOperacion")
                    txtCarpetaJudicialCreditosNroOperacion.Text = CarpetaJudicialCreditosNroOperacion
                    txtCarpetaJudicialCreditosCapInicial = FindControl("txtCarpetaJudicialCreditosCapInicial")
                    txtCarpetaJudicialCreditosCapInicial.Text = FormatNumber(CarpetaJudicialCreditosCapInicial / 10000, 4)
                    txtCarpetaJudicialCreditosMoneda = FindControl("txtCarpetaJudicialCreditosMoneda")
                    txtCarpetaJudicialCreditosMoneda.Text = CarpetaJudicialCreditosMoneda
                    txtCarpetaJudicialCreditosFechaSuscripcion = FindControl("txtCarpetaJudicialCreditosFechaSuscripcion")
                    txtCarpetaJudicialCreditosFechaSuscripcion.Text = CarpetaJudicialCreditosFechaSuscripcion
                    txtCarpetaJudicialCreditosFechaEntroEnMora = FindControl("txtCarpetaJudicialCreditosFechaEntroEnMora")
                    txtCarpetaJudicialCreditosFechaEntroEnMora.Text = CarpetaJudicialCreditosFechaEntroEnMora
                    txtBancoPrestamistaName = FindControl("txtBancoPrestamistaName")
                    txtBancoPrestamistaName.Text = BancoPrestamistaName

                    txtCarpetaJudicialCreditosMesesPlazo = FindControl("txtCarpetaJudicialCreditosMesesPlazo")
                    txtCarpetaJudicialCreditosMesesPlazo.Text = CarpetaJudicialCreditosMesesPlazo

                    txtCarpetaJudicialCreditosTasaInteresAnual = FindControl("txtCarpetaJudicialCreditosTasaInteresAnual")
                    txtCarpetaJudicialCreditosTasaInteresAnual.Text = FormatNumber(CarpetaJudicialCreditosTasaInteresAnual / 10000, 4)

                    txtCarpetaJudicialCreditosFechaPrimerVencimiento = FindControl("txtCarpetaJudicialCreditosFechaPrimerVencimiento")
                    txtCarpetaJudicialCreditosFechaPrimerVencimiento.Text = CarpetaJudicialCreditosFechaPrimerVencimiento

                    txtCarpetaJudicialCreditosValorCuota = FindControl("txtCarpetaJudicialCreditosValorCuota")
                    txtCarpetaJudicialCreditosValorCuota.Text = FormatNumber(CarpetaJudicialCreditosValorCuota / 10000, 4)

                    txtCarpetaJudicialCreditosUltimaCuota = FindControl("txtCarpetaJudicialCreditosUltimaCuota")
                    txtCarpetaJudicialCreditosUltimaCuota.Text = FormatNumber(CarpetaJudicialCreditosUltimaCuota / 10000, 4)

                    txtCarpetaJudicialCreditosFechaEscritura = FindControl("txtCarpetaJudicialCreditosFechaEscritura")
                    txtCarpetaJudicialCreditosFechaEscritura.Text = CarpetaJudicialCreditosFechaEscritura

                    txtCarpetaJudicialCreditosNotarioEscritura = FindControl("txtCarpetaJudicialCreditosNotarioEscritura")
                    txtCarpetaJudicialCreditosNotarioEscritura.Text = CarpetaJudicialCreditosNotarioEscritura

                    txtCarpetaJudicialCreditosCiudadEscritura = FindControl("txtCarpetaJudicialCreditosCiudadEscritura")
                    txtCarpetaJudicialCreditosCiudadEscritura.Text = CarpetaJudicialCreditosCiudadEscritura

                    txtCarpetaJudicialCreditosDeudaCapitalPesos = FindControl("txtCarpetaJudicialCreditosDeudaCapitalPesos")
                    txtCarpetaJudicialCreditosDeudaCapitalPesos.Text = FormatNumber(CarpetaJudicialCreditosDeudaCapitalPesos / 10000, 4)

                    txtCarpetaJudicialCreditosDeudaCapitalUF = FindControl("txtCarpetaJudicialCreditosDeudaCapitalUF")
                    txtCarpetaJudicialCreditosDeudaCapitalUF.Text = FormatNumber(CarpetaJudicialCreditosDeudaCapitalUF / 10000, 4)

                    txtCarpetaJudicialCreditosDeudaDividendosPesos = FindControl("txtCarpetaJudicialCreditosDeudaDividendosPesos")
                    txtCarpetaJudicialCreditosDeudaDividendosPesos.Text = FormatNumber(CarpetaJudicialCreditosDeudaDividendosPesos / 10000, 4)

                    txtCarpetaJudicialCreditosDeudaDividendosUF = FindControl("txtCarpetaJudicialCreditosDeudaDividendosUF")
                    txtCarpetaJudicialCreditosDeudaDividendosUF.Text = FormatNumber(CarpetaJudicialCreditosDeudaDividendosUF / 10000, 4)

                    txtCarpetaJudicialCreditosInteresesPenalesPesos = FindControl("txtCarpetaJudicialCreditosInteresesPenalesPesos")
                    txtCarpetaJudicialCreditosInteresesPenalesPesos.Text = FormatNumber(CarpetaJudicialCreditosInteresesPenalesPesos / 10000, 4)

                    txtCarpetaJudicialCreditosInteresesPenalesUF = FindControl("txtCarpetaJudicialCreditosInteresesPenalesUF")
                    txtCarpetaJudicialCreditosInteresesPenalesUF.Text = FormatNumber(CarpetaJudicialCreditosInteresesPenalesUF / 10000, 4)

                    txtCarpetaJudicialCreditosDeudaTotalPesos = FindControl("txtCarpetaJudicialCreditosDeudaTotalPesos")
                    txtCarpetaJudicialCreditosDeudaTotalPesos.Text = FormatNumber(CarpetaJudicialCreditosDeudaTotalPesos / 10000, 4)

                    txtCarpetaJudicialCreditosDeudaTotalUF = FindControl("txtCarpetaJudicialCreditosDeudaTotalUF")
                    txtCarpetaJudicialCreditosDeudaTotalUF.Text = FormatNumber(CarpetaJudicialCreditosDeudaTotalUF / 10000, 4)

                    sSQLWhere = ""
                    sSQLOrder = ""
                    Call Lecturas.CreateTabs(NumeroPagina, CarpetaJudicialCodigo, Request.QueryString("Id"), MyTabs, "CarpetaJudicialCreditosId", sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"), Request.QueryString("Id"), "CarpetaJudicialAvalesPorCarpetaJudicialCreditos", Session("PersonaId"))


                Else
                    txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                    txtCarpetaJudicialCodigo.Text = Session("CarpetaJudicialCodigo")
                    txtCarpetaJudicialCreditosSecuencia = FindControl("txtCarpetaJudicialCreditosSecuencia")
                    txtCarpetaJudicialCreditosSecuencia.Text = Session("CarpetaJudicialCreditosSecuencia")
                End If
            Else
                txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                txtCarpetaJudicialCreditosSecuencia = FindControl("txtCarpetaJudicialCreditosSecuencia")
                txtTipoCreditoName = FindControl("txtTipoCreditoName")
                txtCarpetaJudicialCreditosNroOperacion = FindControl("txtCarpetaJudicialCreditosNroOperacion")
                txtCarpetaJudicialCreditosCapInicial = FindControl("txtCarpetaJudicialCreditosCapInicial")
                txtCarpetaJudicialCreditosMoneda = FindControl("txtCarpetaJudicialCreditosMoneda")
                txtCarpetaJudicialCreditosFechaSuscripcion = FindControl("txtCarpetaJudicialCreditosFechaSuscripcion")
                txtCarpetaJudicialCreditosFechaEntroEnMora = FindControl("txtCarpetaJudicialCreditosFechaEntroEnMora")
                txtBancoPrestamistaName = FindControl("txtBancoPrestamistaName")
                txtCarpetaJudicialCreditosMesesPlazo = FindControl("txtCarpetaJudicialCreditosMesesPlazo")
                txtCarpetaJudicialCreditosTasaInteresAnual = FindControl("txtCarpetaJudicialCreditosTasaInteresAnual")
                txtCarpetaJudicialCreditosFechaPrimerVencimiento = FindControl("txtCarpetaJudicialCreditosFechaPrimerVencimiento")
                txtCarpetaJudicialCreditosValorCuota = FindControl("txtCarpetaJudicialCreditosValorCuota")
                txtCarpetaJudicialCreditosUltimaCuota = FindControl("txtCarpetaJudicialCreditosUltimaCuota")
                txtCarpetaJudicialCreditosFechaEscritura = FindControl("txtCarpetaJudicialCreditosFechaEscritura")
                txtCarpetaJudicialCreditosNotarioEscritura = FindControl("txtCarpetaJudicialCreditosNotarioEscritura")
                txtCarpetaJudicialCreditosCiudadEscritura = FindControl("txtCarpetaJudicialCreditosCiudadEscritura")
                txtCarpetaJudicialCreditosDeudaCapitalPesos = FindControl("txtCarpetaJudicialCreditosDeudaCapitalPesos")
                txtCarpetaJudicialCreditosDeudaCapitalUF = FindControl("txtCarpetaJudicialCreditosDeudaCapitalUF")
                txtCarpetaJudicialCreditosDeudaDividendosPesos = FindControl("txtCarpetaJudicialCreditosDeudaDividendosPesos")
                txtCarpetaJudicialCreditosDeudaDividendosUF = FindControl("txtCarpetaJudicialCreditosDeudaDividendosUF")
                txtCarpetaJudicialCreditosInteresesPenalesPesos = FindControl("txtCarpetaJudicialCreditosInteresesPenalesPesos")
                txtCarpetaJudicialCreditosInteresesPenalesUF = FindControl("txtCarpetaJudicialCreditosInteresesPenalesUF")
                txtCarpetaJudicialCreditosDeudaTotalPesos = FindControl("txtCarpetaJudicialCreditosDeudaTotalPesos")
                txtCarpetaJudicialCreditosDeudaTotalUF = FindControl("txtCarpetaJudicialCreditosDeudaTotalUF")
            End If
        Catch
            t = False
        End Try
    End Sub
End Class
