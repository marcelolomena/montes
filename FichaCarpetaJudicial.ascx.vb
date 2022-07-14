Imports AjaxControlToolkit
Partial Class FichaCarpetaJudicial
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 24-02-2012 11:01:03
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
    Dim txtCarpetaJudicialFechaAsignacion As TextBox ' Etiqueta : Fecha Asignación - Control : txtCarpetaJudicialFechaAsignacion - Variable : CarpetaJudicialFechaAsignacion
    Dim txtCarpetaJudicialRut As TextBox ' Etiqueta : Rut del deudor - Control : txtCarpetaJudicialRut - Variable : CarpetaJudicialRut
    Dim txtCarpetaJudicialNombres As TextBox ' Etiqueta : Nombres - Control : txtCarpetaJudicialNombres - Variable : CarpetaJudicialNombres
    Dim txtCarpetaJudicialApellidos As TextBox ' Etiqueta : Apellidos - Control : txtCarpetaJudicialApellidos - Variable : CarpetaJudicialApellidos
    Dim txtCarpetaJudicialCiudad As TextBox ' Etiqueta : Ciudad - Control : txtCarpetaJudicialCiudad - Variable : CarpetaJudicialCiudad
    Dim txtCarpetaJudicialNroOperacion As TextBox ' Etiqueta : # Operación - Control : txtCarpetaJudicialNroOperacion - Variable : CarpetaJudicialNroOperacion
    Dim txtCarpetaJudicialCapInicial As TextBox ' Etiqueta : Capital Inicial - Control : txtCarpetaJudicialCapInicial - Variable : CarpetaJudicialCapInicial
    Dim txtCarpetaJudicialMoneda As TextBox ' Etiqueta : Moneda - Control : txtCarpetaJudicialMoneda - Variable : CarpetaJudicialMoneda
    Dim txtCarpetaJudicialFechaSuscripcion As TextBox ' Etiqueta : Fecha Suscripción - Control : txtCarpetaJudicialFechaSuscripcion - Variable : CarpetaJudicialFechaSuscripcion
    Dim txtCarpetaJudicialSaldoDeuda As TextBox ' Etiqueta : Saldo deuda - Control : txtCarpetaJudicialSaldoDeuda - Variable : CarpetaJudicialSaldoDeuda
    Dim txtCarpetaJudicialDivImpago As TextBox ' Etiqueta : # Div Impagos - Control : txtCarpetaJudicialDivImpago - Variable : CarpetaJudicialDivImpago
    Dim txtCarpetaJudicialFechaEntroEnMora As TextBox ' Etiqueta : Fecha entro en mora - Control : txtCarpetaJudicialFechaEntroEnMora - Variable : CarpetaJudicialFechaEntroEnMora
    Dim txtCarpetaJudicialProcurador As TextBox ' Etiqueta : Procurador - Control : txtCarpetaJudicialProcurador - Variable : CarpetaJudicialProcurador
    Dim txtCarpetaJudicialSecretaria As TextBox ' Etiqueta : Secretaria - Control : txtCarpetaJudicialSecretaria - Variable : CarpetaJudicialSecretaria
    Dim txtCarpetaJudicialSupervisor As TextBox ' Etiqueta : Supervisor - Control : txtCarpetaJudicialSupervisor - Variable : CarpetaJudicialSupervisor
    Dim txtCarpetaJudicialReceptor As TextBox ' Etiqueta : Supervisor - Control : txtCarpetaJudicialSupervisor - Variable : CarpetaJudicialSupervisor
    Dim txtEstadoProcesoCodigo As TextBox ' Etiqueta : Estado de la Demanda - Control : txtEstadoProcesoCodigo - Variable : EstadoProcesoCodigo
    Dim txtTipoProcesoName As TextBox
    Dim txtCarpetaJudicialRepresentanteBanco As TextBox
    Dim txtCarpetaJudicialProfesionRepresentante As TextBox
    Dim txtBancoPrestamistaName As TextBox
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim CarpetaJudicialCodigo As String ' Etiqueta : # Interno - Control : txtCarpetaJudicialCodigo - Variable : CarpetaJudicialCodigo
    Dim CarpetaJudicialFechaAsignacion As Date ' Etiqueta : Fecha Asignación - Control : txtCarpetaJudicialFechaAsignacion - Variable : CarpetaJudicialFechaAsignacion
    Dim CarpetaJudicialRut As String ' Etiqueta : Rut del deudor - Control : txtCarpetaJudicialRut - Variable : CarpetaJudicialRut
    Dim CarpetaJudicialNombres As String ' Etiqueta : Nombres - Control : txtCarpetaJudicialNombres - Variable : CarpetaJudicialNombres
    Dim CarpetaJudicialApellidos As String ' Etiqueta : Apellidos - Control : txtCarpetaJudicialApellidos - Variable : CarpetaJudicialApellidos
    Dim CarpetaJudicialCiudad As String ' Etiqueta : Ciudad - Control : txtCarpetaJudicialCiudad - Variable : CarpetaJudicialCiudad
    Dim CarpetaJudicialNroOperacion As String ' Etiqueta : # Operación - Control : txtCarpetaJudicialNroOperacion - Variable : CarpetaJudicialNroOperacion
    Dim CarpetaJudicialCapInicial As Double ' Etiqueta : Capital Inicial - Control : txtCarpetaJudicialCapInicial - Variable : CarpetaJudicialCapInicial
    Dim CarpetaJudicialMoneda As String ' Etiqueta : Moneda - Control : txtCarpetaJudicialMoneda - Variable : CarpetaJudicialMoneda
    Dim CarpetaJudicialFechaSuscripcion As Date ' Etiqueta : Fecha Suscripción - Control : txtCarpetaJudicialFechaSuscripcion - Variable : CarpetaJudicialFechaSuscripcion
    Dim CarpetaJudicialSaldoDeuda As Double ' Etiqueta : Saldo deuda - Control : txtCarpetaJudicialSaldoDeuda - Variable : CarpetaJudicialSaldoDeuda
    Dim CarpetaJudicialDivImpago As String ' Etiqueta : # Div Impagos - Control : txtCarpetaJudicialDivImpago - Variable : CarpetaJudicialDivImpago
    Dim CarpetaJudicialFechaEntroEnMora As Date ' Etiqueta : Fecha entro en mora - Control : txtCarpetaJudicialFechaEntroEnMora - Variable : CarpetaJudicialFechaEntroEnMora
    Dim CarpetaJudicialProcurador As String ' Etiqueta : Procurador - Control : txtCarpetaJudicialProcurador - Variable : CarpetaJudicialProcurador
    Dim CarpetaJudicialSecretaria As String ' Etiqueta : Secretaria - Control : txtCarpetaJudicialSecretaria - Variable : CarpetaJudicialSecretaria
    Dim CarpetaJudicialSupervisor As String ' Etiqueta : Supervisor - Control : txtCarpetaJudicialSupervisor - Variable : CarpetaJudicialSupervisor
    Dim CarpetaJudicialReceptor As String ' Etiqueta : Supervisor - Control : txtCarpetaJudicialSupervisor - Variable : CarpetaJudicialSupervisor
    Dim EstadoProcesoCodigo As String ' Etiqueta : Estado de la Demanda - Control : txtEstadoProcesoCodigo - Variable : EstadoProcesoCodigo
    Dim TipoProcesoName As String
    Dim CarpetaJudicialRepresentanteBanco As String
    Dim CarpetaJudicialProfesionRepresentante As String
    Dim BancoPrestamistaName As String
    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Usuarios As New Usuarios
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim Mensaje As String = ""
        Dim Supervisor As String = ""
        Dim Secretaria As String = ""
        Dim UsuarioConectado As String = ""

        'La Tarea solo puede ser eliminada por el coordinador del programa de gestión o por la secretaria
        Supervisor = CarpetaJudicial.LeerSupervisorByCarpetaJudicialCodigo(txtCarpetaJudicialCodigo.Text)
        Secretaria = CarpetaJudicial.LeerSecretariaByCarpetaJudicialCodigo(txtCarpetaJudicialCodigo.Text)
        t = Usuarios.LeerUsuariosCodigoByUsuariosId(Session("PersonaId"), UsuarioConectado)
        ' Si el UsuarioConectado es igual al Coordinador o a la secretaria se puede eliminar o cerrar la carpeta judicial    
        If (UsuarioConectado = Supervisor Or UsuarioConectado = Secretaria) Then
            Try
                t = CarpetaJudicial.CarpetaJudicialDelete(Request.QueryString("Id"), CStr(txtCarpetaJudicialCodigo.Text), CLng(Session("PersonaId")), Mensaje, CLng(Request.QueryString("MenuOptionsId")))
                If t = True Then
                    '    MyMessage1.Text = Mensaje
                    'Else
                    Response.Redirect(Url, True)
                End If
                'Response.Redirect(Url, True)
            Catch
                t = 0
            End Try
        Else
            MyMessage1.Text = "La carpeta del deudor s&oacutelo puede ser eliminada por el supervisor de la demanda"
        End If
    End Sub
    Protected Sub RFC_Search(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLSearch", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogout", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Request.QueryString("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Monto As Double = 0

        Monto = CDbl(txtCarpetaJudicialCapInicial.Text)
        If Monto < 100000 Then
            txtCarpetaJudicialMoneda.Text = "UF"
        Else
            txtCarpetaJudicialMoneda.Text = "Pesos"
        End If
        Try
            t = CarpetaJudicial.CarpetaJudicialUpdate(Request.QueryString("Id"), CStr(txtCarpetaJudicialCodigo.Text), CDate(txtCarpetaJudicialFechaAsignacion.Text), CStr(txtCarpetaJudicialRut.Text), CStr(txtCarpetaJudicialNombres.Text), CStr(txtCarpetaJudicialApellidos.Text), CStr(txtCarpetaJudicialCiudad.Text), CStr(txtCarpetaJudicialNroOperacion.Text), CDbl(txtCarpetaJudicialCapInicial.Text * 100), CStr(txtCarpetaJudicialMoneda.Text), CDate(txtCarpetaJudicialFechaSuscripcion.Text), CDbl(txtCarpetaJudicialSaldoDeuda.Text * 100), CStr(txtCarpetaJudicialDivImpago.Text), CDate(txtCarpetaJudicialFechaEntroEnMora.Text), CStr(txtCarpetaJudicialProcurador.Text), CStr(txtCarpetaJudicialSecretaria.Text), CStr(txtCarpetaJudicialSupervisor.Text), CStr(txtTipoProcesoName.Text), CStr(txtEstadoProcesoCodigo.Text), CStr(txtCarpetaJudicialReceptor.Text), CStr(txtCarpetaJudicialRepresentanteBanco.Text), CStr(txtCarpetaJudicialProfesionRepresentante.Text), CStr(txtBancoPrestamistaName.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url, True)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim PaginaWebName As String = ""
        Dim sSQLWhere As String = ""
        Dim sSQLOrder As String = ""
        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler SearchButton.Click, AddressOf RFC_Search
        If Not IsPostBack Then
            If Request.QueryString("Id") <> 0 Then
                If t = CarpetaJudicial.LeerCarpetaJudicial(Request.QueryString("Id"), CarpetaJudicialCodigo, CarpetaJudicialFechaAsignacion, CarpetaJudicialRut, CarpetaJudicialNombres, CarpetaJudicialApellidos, CarpetaJudicialCiudad, CarpetaJudicialNroOperacion, CarpetaJudicialCapInicial, CarpetaJudicialMoneda, CarpetaJudicialFechaSuscripcion, CarpetaJudicialSaldoDeuda, CarpetaJudicialDivImpago, CarpetaJudicialFechaEntroEnMora, CarpetaJudicialProcurador, CarpetaJudicialSecretaria, CarpetaJudicialSupervisor, TipoProcesoName, EstadoProcesoCodigo, CarpetaJudicialReceptor, CarpetaJudicialRepresentanteBanco, CarpetaJudicialProfesionRepresentante, BancoPrestamistaName) Then
                    'lblLinkGantt.Text = "<a href=""ReportesPGG.aspx?PaginaWebName=Carta Gantt&Id=" & Request.QueryString("Id") & "&MenuOptionsId=515"" >Carta Gantt</a>"
                    'Se agrego como reporte en el sidebar de noticias
                    txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                    txtCarpetaJudicialCodigo.Text = CarpetaJudicialCodigo
                    txtCarpetaJudicialFechaAsignacion = FindControl("txtCarpetaJudicialFechaAsignacion")
                    txtCarpetaJudicialFechaAsignacion.Text = CarpetaJudicialFechaAsignacion
                    txtCarpetaJudicialRut = FindControl("txtCarpetaJudicialRut")
                    txtCarpetaJudicialRut.Text = CarpetaJudicialRut
                    txtCarpetaJudicialNombres = FindControl("txtCarpetaJudicialNombres")
                    txtCarpetaJudicialNombres.Text = CarpetaJudicialNombres
                    txtCarpetaJudicialApellidos = FindControl("txtCarpetaJudicialApellidos")
                    txtCarpetaJudicialApellidos.Text = CarpetaJudicialApellidos
                    txtCarpetaJudicialCiudad = FindControl("txtCarpetaJudicialCiudad")
                    txtCarpetaJudicialCiudad.Text = CarpetaJudicialCiudad
                    txtCarpetaJudicialNroOperacion = FindControl("txtCarpetaJudicialNroOperacion")
                    txtCarpetaJudicialNroOperacion.Text = CarpetaJudicialNroOperacion
                    txtCarpetaJudicialCapInicial = FindControl("txtCarpetaJudicialCapInicial")
                    txtCarpetaJudicialCapInicial.Text = FormatNumber(CarpetaJudicialCapInicial / 100, 0)
                    txtCarpetaJudicialMoneda = FindControl("txtCarpetaJudicialMoneda")
                    txtCarpetaJudicialMoneda.Text = CarpetaJudicialMoneda
                    txtCarpetaJudicialFechaSuscripcion = FindControl("txtCarpetaJudicialFechaSuscripcion")
                    txtCarpetaJudicialFechaSuscripcion.Text = CarpetaJudicialFechaSuscripcion
                    txtCarpetaJudicialSaldoDeuda = FindControl("txtCarpetaJudicialSaldoDeuda")
                    txtCarpetaJudicialSaldoDeuda.Text = FormatNumber(CarpetaJudicialSaldoDeuda / 100, 0)
                    txtCarpetaJudicialDivImpago = FindControl("txtCarpetaJudicialDivImpago")
                    txtCarpetaJudicialDivImpago.Text = CarpetaJudicialDivImpago
                    txtCarpetaJudicialFechaEntroEnMora = FindControl("txtCarpetaJudicialFechaEntroEnMora")
                    txtCarpetaJudicialFechaEntroEnMora.Text = CarpetaJudicialFechaEntroEnMora
                    txtCarpetaJudicialProcurador = FindControl("txtCarpetaJudicialProcurador")
                    txtCarpetaJudicialProcurador.Text = CarpetaJudicialProcurador
                    txtCarpetaJudicialSecretaria = FindControl("txtCarpetaJudicialSecretaria")
                    txtCarpetaJudicialSecretaria.Text = CarpetaJudicialSecretaria
                    txtCarpetaJudicialSupervisor = FindControl("txtCarpetaJudicialSupervisor")
                    txtCarpetaJudicialSupervisor.Text = CarpetaJudicialSupervisor
                    txtCarpetaJudicialReceptor = FindControl("txtCarpetaJudicialReceptor")
                    txtCarpetaJudicialReceptor.Text = CarpetaJudicialReceptor
                    txtTipoProcesoName = FindControl("txtTipoProcesoName")
                    txtTipoProcesoName.Text = TipoProcesoName
                    txtEstadoProcesoCodigo = FindControl("txtEstadoProcesoCodigo")
                    txtEstadoProcesoCodigo.Text = EstadoProcesoCodigo
                    txtCarpetaJudicialRepresentanteBanco = FindControl("txtCarpetaJudicialRepresentanteBanco")
                    txtCarpetaJudicialRepresentanteBanco.Text = CarpetaJudicialRepresentanteBanco
                    txtCarpetaJudicialProfesionRepresentante = FindControl("txtCarpetaJudicialProfesionRepresentante")
                    txtCarpetaJudicialProfesionRepresentante.Text = CarpetaJudicialProfesionRepresentante
                    txtBancoPrestamistaName = FindControl("txtBancoPrestamistaName")
                    txtBancoPrestamistaName.Text = BancoPrestamistaName
                    ' Aquí colocare código para invocar uso de las tabs
                    sSQLWhere = ""
                    sSQLOrder = ""
                    'Call Lecturas.CreateTabs(NumeroPagina, CarpetaJudicialCodigo, Request.QueryString("Id"), MyTabs, "CarpetaJudicialCodigo", sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"), Request.QueryString("Id"), "CarpetaJudicial", Session("PersonaId"))

                    Call CreateNewTabs(NumeroPagina, CarpetaJudicialCodigo, Request.QueryString("Id"), MyTabs, "CarpetaJudicialCodigo", sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"), Request.QueryString("Id"), "CarpetaJudicial", Session("PersonaId"))

                Else
                    txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                    txtCarpetaJudicialCodigo.Text = Session("CarpetaJudicialCodigo")
                End If
            End If
        Else
            txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
            txtCarpetaJudicialFechaAsignacion = FindControl("txtCarpetaJudicialFechaAsignacion")
            txtCarpetaJudicialFechaAsignacion.Text = FormatDateTime(Now(), DateFormat.ShortDate)
            txtCarpetaJudicialRut = FindControl("txtCarpetaJudicialRut")
            txtCarpetaJudicialNombres = FindControl("txtCarpetaJudicialNombres")
            txtCarpetaJudicialApellidos = FindControl("txtCarpetaJudicialApellidos")
            txtCarpetaJudicialCiudad = FindControl("txtCarpetaJudicialCiudad")
            txtCarpetaJudicialNroOperacion = FindControl("txtCarpetaJudicialNroOperacion")
            txtCarpetaJudicialCapInicial = FindControl("txtCarpetaJudicialCapInicial")
            txtCarpetaJudicialMoneda = FindControl("txtCarpetaJudicialMoneda")
            txtCarpetaJudicialFechaSuscripcion = FindControl("txtCarpetaJudicialFechaSuscripcion")
            txtCarpetaJudicialSaldoDeuda = FindControl("txtCarpetaJudicialSaldoDeuda")
            txtCarpetaJudicialDivImpago = FindControl("txtCarpetaJudicialDivImpago")
            txtCarpetaJudicialFechaEntroEnMora = FindControl("txtCarpetaJudicialFechaEntroEnMora")
            txtCarpetaJudicialProcurador = FindControl("txtCarpetaJudicialProcurador")
            txtCarpetaJudicialSecretaria = FindControl("txtCarpetaJudicialSecretaria")
            txtCarpetaJudicialSupervisor = FindControl("txtCarpetaJudicialSupervisor")
            txtCarpetaJudicialReceptor = FindControl("txtCarpetaJudicialReceptor")
            txtTipoProcesoName = FindControl("txtTipoProcesoName")
            txtEstadoProcesoCodigo = FindControl("txtEstadoProcesoCodigo")
            txtCarpetaJudicialRepresentanteBanco = FindControl("txtCarpetaJudicialRepresentanteBanco")
            txtCarpetaJudicialProfesionRepresentante = FindControl("txtCarpetaJudicialProfesionRepresentante")
            txtBancoPrestamistaName = FindControl("txtBancoPrestamistaName")
        End If
    End Sub
    Public Sub CreateTabs(ByVal NumeroPagina As Long, ByVal MasterName As String, ByVal MasterId As Long, ByRef MyTable As Table, ByVal FilterField As String, ByVal sSQLWhere As String, ByVal sSQLOrder As String, ByVal PaginaWebName As String, ByVal MenuOptionsId As Long, Optional ByVal PivotId As Long = 0, Optional ByVal PivotTable As String = "", Optional ByVal UserId As Long = 0, Optional ByVal Agno As String = "", Optional ByVal Gerencia As String = "", Optional ByVal StakeholderCode As String = "")
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim m As Integer = 0
        Dim n As Integer = 0
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim arrLabel(21) As String
        Dim arrControl(21) As String
        Dim arrGrillaLabel(21) As String
        Dim arrGrillaControl(21) As String
        Dim TipoControl As String = ""
        Dim CssClassLabel As String = ""
        Dim CssClassControl As String = ""
        Dim ControlWidth As String = ""
        Dim ControlTextMode As String = "0"
        Dim EtiquetaAlign As String = ""
        Dim ToolTip As String = ""
        Dim IsRequiredField As Boolean = True
        Dim IsNotEnabledField As Boolean = False
        Dim DomainField As String = ""
        Dim DataTextField As String = ""
        Dim DataFile As String = ""
        Dim SelectCommand As String = ""
        Dim Section As String = ""
        Dim Url As String = ""
        Dim FormularioWebPId As Long = 0
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim sqlSource As AccessDataSource
        Dim Tareas As New Tareas
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim IndicadorEsManual As Boolean = False

        Dim TC As TabContainer
        Dim TP As TabPanel
        Dim Tabla As Table
        Dim Fila As TableRow
        Dim Celda As TableCell
        Dim PanelScroll As Panel

        Dim Grilla As GridView
        Dim sSQL As String = ""
        Dim HTMLCode As String = ""
        Dim HyperColumnGrid As HyperLinkField
        Dim ItemTempColumnGrid As TemplateField

        'Se agregan para hacer el cambio en el despliegue de las relaciones de asociacion
        Dim RelationTable As String = ""
        Dim sSQLRelationSelect As String = ""


        Dim GroupValidation As String = ""

        i = 0
        t = Lecturas.LeerTabsFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        If i > 0 Then  'Página posee tabs

            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Height = "4"
            Cell.ColumnSpan = "2"
            Cell.Controls.Add(New LiteralControl("<hr />"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)

            'Row = New TableRow
            'Cell = New TableCell
            'Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            'Cell.Height = "4"
            'Cell.ColumnSpan = "2"
            'Cell.Controls.Add(New LiteralControl(GenerarJScriptPorTabContainer("DynamicTab")))
            'Row.Cells.Add(Cell)
            'MyTable.Rows.Add(Row)


            Row = New TableRow
            Cell = New TableCell
            Cell.ColumnSpan = "2"

            'Crea el Tab Container
            TC = New TabContainer
            TC.ID = "DynamicTab" ' & NumeroPagina & i
            TC.ClientIDMode = UI.ClientIDMode.Static
            'TC.Height = "400"
            TC.OnClientActiveTabChanged = "ActiveTabChanged"
            ' Primer Tab Panel: Con k corren los paneles                                  

            'Aquí comienza el If si me quiero saltar un tab.

            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Tabs", GroupValidation, NumeroPagina, k + 1)
                t = Lecturas.LeerIdFormularioWeb(FormularioWebPId, "Tabs", NumeroPagina, k + 1, Pagina, NombrePagina)

                TP = New TabPanel
                TP.ID = "TabPanel" & arrControl(k)
                TP.ClientIDMode = UI.ClientIDMode.Static
                TP.HeaderText = arrLabel(k)
                TP.CssClass = "tab_contenido"
                'Agrega el contenedor
                TP.Controls.Add(New LiteralControl("<contenttemplate>"))
                TP.Controls.Add(New LiteralControl("<div id=""" & arrLabel(k) & """>"))

                Tabla = New Table
                Tabla.ID = "Tabla" & arrControl(k)
                Tabla.ClientIDMode = UI.ClientIDMode.Static
                Tabla.CellSpacing = "2"
                Tabla.CellPadding = "2"

                'Titulo
                Fila = New TableRow
                Celda = New TableCell
                'Celda.CssClass = "subtit"
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "left"
                Celda.ColumnSpan = "2"
                Celda.Controls.Add(New LiteralControl("<h1>Lista de " & arrLabel(k) & "</h1>"))
                Fila.Cells.Add(Celda)
                Tabla.Rows.Add(Fila)

                'Linea para incorporar el link para agregar un elemento a la lista.
                'Dim linkAgregar As String = Pagina & "?PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & MasterName & "&MasterId=" & MasterId

                'Cambio del 08 de Abril de 2011
                'Se comienza a usar el campo IsNotEnabledField, para determinar si se pone o no este link
                'El valor Yes implica que no se pone.
                'Este campo esta en el registro que corresponder a los tabs de la clase.

                If IsNotEnabledField = False Then
                    IndicadorEsManual = True

                    Dim linkAgregar As String = Pagina & "?PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & MenuOptionsId & "&MasterName=" & MasterName & "&MasterId=" & MasterId

                    If IndicadorEsManual = True Then
                        Url = "<a href='" & linkAgregar & "'>Agregar " & arrLabel(k) & "</a>"
                        If DomainField = "RelationBetweenTables" Then
                            Url = "<a href='" & linkAgregar & "'>Editar " & arrLabel(k) & "</a>"
                        End If
                    Else
                        Url = "<span class=""subtit"">Esta tarea no requiere ingresar un indicador de gestión</span>"
                    End If

                    Fila = New TableRow
                    Celda = New TableCell
                    Celda.Style(HtmlTextWriterStyle.TextAlign) = "left"
                    Celda.Height = "4"
                    Celda.ColumnSpan = "2"
                    Celda.Controls.Add(New LiteralControl(Url))
                    Fila.Cells.Add(Celda)
                    Tabla.Rows.Add(Fila)
                End If

                Fila = New TableRow
                Celda = New TableCell
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "left"
                Celda.Height = "4"
                Celda.ColumnSpan = "2"

                'Aquí vamos a poner la grilla de datos asociada a cada tabs

                'Columnas del Formulario
                n = 0
                t = Lecturas.LeerTabsColumnsFormularioWeb(arrGrillaLabel, arrGrillaControl, FormularioWebPId, n)

                PanelScroll = New Panel
                PanelScroll.ID = "panel" & arrLabel(k)
                PanelScroll.ClientIDMode = UI.ClientIDMode.Static
                PanelScroll.ScrollBars = ScrollBars.Auto
                PanelScroll.Height = "300"


                Grilla = New GridView
                'Grilla.ID = "grid" & arrLabel(k)
                Grilla.ID = "tabla_de_datos"
                Grilla.ClientIDMode = ClientIDMode.Static
                Grilla.DataSourceID = "ds" & arrLabel(k)
                Grilla.DataKeyNames = New String(0) {"Id"}
                'Grilla.HeaderStyle.CssClass = "grilla_top"
                'Grilla.RowStyle.CssClass = "grilla_Fila1"
                Grilla.AlternatingRowStyle.CssClass = "alt"

                Grilla.Width = "660"
                Grilla.AllowPaging = False
                Grilla.AllowSorting = False
                'Grilla.PageSize = 100
                Grilla.AutoGenerateColumns = False

                For m = 0 To n - 1
                    t = Lecturas.LeerTabColumnFormularioWeb(TipoControl, EtiquetaAlign, ControlWidth, ToolTip, SelectCommand, "Grilla", FormularioWebPId, m + 1)
                    Select Case TipoControl
                        Case "HyperLinkField"
                            HyperColumnGrid = New HyperLinkField
                            HyperColumnGrid.DataTextField = arrGrillaControl(m)
                            HyperColumnGrid.ShowHeader = True
                            HyperColumnGrid.HeaderText = arrGrillaLabel(m)
                            HyperColumnGrid.DataNavigateUrlFields = New String(0) {arrGrillaControl(m)}
                            HyperColumnGrid.DataNavigateUrlFormatString = SelectCommand & "&MasterName=" & MasterName & "&MasterId=" & MasterId
                            HyperColumnGrid.Visible = False
                            Grilla.Columns.Add(HyperColumnGrid)
                            ItemTempColumnGrid = New TemplateField
                            ItemTempColumnGrid.ShowHeader = True
                            ItemTempColumnGrid.HeaderText = "Editar"
                            'ItemTempColumnGrid.HeaderImageUrl = "img/botones/i_solicitar.gif"
                            ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                            ' Cambio Introducido el 11 de Abril de 2011
                            ' En caso de que el campo DomainField contenga la glosa RelationBetweenTables, se invocara una plantilla distinta a la habitual
                            If DomainField = "RelationBetweenTables" Then
                                ItemTempColumnGrid.ItemTemplate = New PlantillaRelationsBetweenTables(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)}, DataTextField, PivotTable, DataFile, PivotId, UserId)
                            Else
                                ItemTempColumnGrid.ItemTemplate = New PlantillaImageGrilla(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)}, SelectCommand & "&MasterName=" & MasterName & "&MasterId=" & MasterId, "img/editar.png")
                            End If
                            ItemTempColumnGrid.Visible = True
                            Grilla.Columns.Add(ItemTempColumnGrid)
                        Case "HyperLinkPlanField"
                            HyperColumnGrid = New HyperLinkField
                            HyperColumnGrid.DataTextField = arrGrillaControl(m)
                            HyperColumnGrid.ShowHeader = True
                            HyperColumnGrid.HeaderText = arrGrillaLabel(m)
                            HyperColumnGrid.DataNavigateUrlFields = New String(0) {arrGrillaControl(m)}
                            HyperColumnGrid.DataNavigateUrlFormatString = SelectCommand & "&MasterName=" & MasterName & "&MasterId=" & MasterId
                            HyperColumnGrid.Visible = False
                            Grilla.Columns.Add(HyperColumnGrid)
                            ItemTempColumnGrid = New TemplateField
                            ItemTempColumnGrid.ShowHeader = True
                            ItemTempColumnGrid.HeaderText = "Editar"
                            'ItemTempColumnGrid.HeaderImageUrl = "img/editar.png"
                            ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                            ' Cambio Introducido el 11 de Abril de 2011
                            ' En caso de que el campo DomainField contenga la glosa RelationBetweenTables, se invocara una plantilla distinta a la habitual
                            ItemTempColumnGrid.ItemTemplate = New PlantillaImageGrilla(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)}, SelectCommand & "&MasterName=" & MasterName & "&MasterId=" & MasterId, "img/editar.png")
                            ItemTempColumnGrid.Visible = True
                            Grilla.Columns.Add(ItemTempColumnGrid)
                        Case "TextBoxField"
                            HyperColumnGrid = New HyperLinkField
                            HyperColumnGrid.DataTextField = arrGrillaControl(m)
                            HyperColumnGrid.ShowHeader = True
                            HyperColumnGrid.HeaderText = arrGrillaLabel(m)
                            HyperColumnGrid.DataNavigateUrlFields = New String(0) {arrGrillaControl(m)}
                            HyperColumnGrid.DataNavigateUrlFormatString = SelectCommand & "&MasterName=" & MasterName & "&MasterId=" & MasterId
                            HyperColumnGrid.Visible = False
                            Grilla.Columns.Add(HyperColumnGrid)
                            ItemTempColumnGrid = New TemplateField
                            ItemTempColumnGrid.ShowHeader = True
                            ItemTempColumnGrid.HeaderText = "Editar"
                            'ItemTempColumnGrid.HeaderImageUrl = "img/editar.png"
                            ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                            ' Cambio Introducido el 11 de Abril de 2011
                            ' En caso de que el campo DomainField contenga la glosa RelationBetweenTables, se invocara una plantilla distinta a la habitual
                            If DomainField = "RelationBetweenTables" Then
                                ItemTempColumnGrid.ItemTemplate = New PlantillaTextBoxButton(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)}, DataTextField, PivotTable, DataFile, PivotId, UserId)
                            Else
                                ItemTempColumnGrid.ItemTemplate = New PlantillaImageGrilla(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)}, SelectCommand & "&MasterName=" & MasterName & "&MasterId=" & MasterId, "img/editar.png")
                            End If
                            ItemTempColumnGrid.Visible = True
                            Grilla.Columns.Add(ItemTempColumnGrid)
                        Case "EstadoFieldEstado"  ' Esta columna debe tomar un color de fondo, que puede ser rojo o amarillo o blanco segun si la tarea es de un mes anterior (rojo), si es del mismo mes (amarillo) o si es de un mes posterior al actual (blanco)
                            ItemTempColumnGrid = New TemplateField
                            ItemTempColumnGrid.ShowHeader = True
                            ItemTempColumnGrid.HeaderText = arrGrillaLabel(m)
                            ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                            ItemTempColumnGrid.ItemTemplate = New PlantillaEstadoTareas(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)}, "ColorCeldaDelEstadoDeLaTarea")
                            ItemTempColumnGrid.Visible = True
                            ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                            Grilla.Columns.Add(ItemTempColumnGrid)
                        Case "DownLoadField"
                            HyperColumnGrid = New HyperLinkField
                            HyperColumnGrid.DataTextField = "Título"
                            HyperColumnGrid.ShowHeader = True
                            HyperColumnGrid.HeaderText = arrGrillaLabel(m)
                            HyperColumnGrid.DataNavigateUrlFields = New String(0) {"Url"}
                            HyperColumnGrid.Target = "_blank"
                            'HyperColumnGrid.ItemStyle.Width = ControlWidth
                            HyperColumnGrid.ItemStyle.HorizontalAlign = 1
                            'HyperColumnGrid.DataNavigateUrlFormatString = {0}
                            Grilla.Columns.Add(HyperColumnGrid)

                        Case "TemplateField"
                            ItemTempColumnGrid = New TemplateField
                            ItemTempColumnGrid.ShowHeader = True
                            ItemTempColumnGrid.HeaderText = arrGrillaLabel(m)
                            ItemTempColumnGrid.ItemStyle.Width = ControlWidth
                            ItemTempColumnGrid.ItemTemplate = New PlantillaGrilla(DataControlRowType.DataRow, New String(0) {arrGrillaControl(m)})
                            Select Case EtiquetaAlign
                                Case "Center"
                                    ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                                Case "Left"
                                    ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Left
                                Case "Right"
                                    ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Right
                                Case "Justify"
                                    ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Justify
                                Case Else
                                    ItemTempColumnGrid.ItemStyle.HorizontalAlign = HorizontalAlign.Center
                            End Select
                            Grilla.Columns.Add(ItemTempColumnGrid)
                    End Select
                Next

                PanelScroll.Controls.Add(Grilla)
                Celda.Controls.Add(PanelScroll)
                Fila.Cells.Add(Celda)
                Tabla.Rows.Add(Fila)

                Fila = New TableRow
                Celda = New TableCell
                Celda.CssClass = "txt_label"
                Celda.ColumnSpan = "2"
                Celda.Style(HtmlTextWriterStyle.TextAlign) = "right"

                sqlSource = New AccessDataSource
                sqlSource.ID = "ds" & arrLabel(k)

                t = Lecturas.LeerTabSQLStatementFormularioWeb("SQLSelect", DataFile, SelectCommand, FormularioWebPId)

                'sqlSource.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\BDCAS.mdb"
                sqlSource.DataFile = DataFile
                ' Cambio introducido el 08 de abril de 2011
                ' Se verifica que el el campo DomainField no contiene la glosa RelationBetweenTables
                If DomainField = "RelationBetweenTables" Then
                    'Vamos a introducir un cambio para mejorar el desempeño del despliegue de 
                    'las listas de asociaciones entre la tabla maestra y sus tablas asociados.
                    'Para ello al momento de desplegar sólo vamos a mostrar los registros asociados
                    'Luego vamos a examinar el mecanismo para hacer nuevas asociaciones.
                    Select Case PaginaWebName
                        Case "Ficha de DocumentosSGIPorCarpeta"
                            If MenuOptionsId = 503 Then
                                sSQL = "SELECT DocumentosSGI.DocumentosSGIId as Id, Mid(DocumentosSGI.DocumentosSGIFEmision,1,10)  As Fecha, DocumentosSGI.DocumentosSGICodigo as Codigo, DocumentosSGI.DocumentosSGINombre As Nombre FROM DocumentosSGI Where DocumentosSGI.DocumentosSGITipo <> 'Compliance' Order By DocumentosSGINombre"
                            Else
                                sSQL = "SELECT DocumentosSGI.DocumentosSGIId as Id, Mid(DocumentosSGI.DocumentosSGIFEmision,1,10)  As Fecha, DocumentosSGI.DocumentosSGICodigo as Codigo, DocumentosSGI.DocumentosSGINombre As Nombre FROM DocumentosSGI Where DocumentosSGI.DocumentosSGITipo = 'Compliance' Order By DocumentosSGINombre"
                            End If
                        Case Else
                            sSQL = SelectCommand
                    End Select
                Else
                    If k = 0 Then
                        sSQL = SelectCommand & " WHERE (((Tareas.PGGCodigo)='" & MasterName & "')) ORDER BY Tareas.DateLastUpdate DESC"
                    Else
                        sSQL = SelectCommand & " where " & FilterField & " = '" & MasterName & "'"
                    End If
                End If


                If Len(sSQLWhere) > 0 Then
                    sSQL = sSQL & sSQLWhere
                End If
                sqlSource.SelectCommand = sSQL
                If Len(sSQLOrder) > 0 Then
                    sSQL = sSQL & sSQLOrder
                End If
                sqlSource.SelectCommand = sSQL

                Celda.Controls.Add(sqlSource)
                Fila.Cells.Add(Celda)

                Tabla.Rows.Add(Fila)



                TP.Controls.Add(Tabla)
                TP.Controls.Add(New LiteralControl("</div>"))
                TP.Controls.Add(New LiteralControl("</contenttemplate>"))
                TC.Controls.Add(TP)
            Next

            'Aquí termina el End If si me quiero saltar un tab


            Cell.Controls.Add(TC)
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)
        End If



    End Sub

    Public Function GenerarJScriptPorTabContainer(ByVal jsCode As String, ByVal jsCode2 As String) As String
        Dim js As String
        GenerarJScriptPorTabContainer = ""


        js = "<script type=""text/javascript"">" & vbCrLf
        js = js & "function PanelClick(sender, e) {" & vbCrLf
        js = js & "}" & vbCrLf
        js = js & "function ActiveTabChanged(sender, e) {" & vbCrLf
        js = js & "var indice = sender.get_activeTabIndex();" & vbCrLf
        js = js & jsCode & vbCrLf
        js = js & "}" & vbCrLf
        js = js & jsCode2 & vbCrLf
        js = js & "</script>"

        GenerarJScriptPorTabContainer = js

    End Function

    Public Sub CreateNewTabs(ByVal NumeroPagina As Long, ByVal MasterName As String, ByVal MasterId As Long, ByRef MyTable As Table, ByVal FilterField As String, ByVal sSQLWhere As String, ByVal sSQLOrder As String, ByVal PaginaWebName As String, ByVal MenuOptionsId As Long, Optional ByVal PivotId As Long = 0, Optional ByVal PivotTable As String = "", Optional ByVal UserId As Long = 0, Optional ByVal Agno As String = "", Optional ByVal Gerencia As String = "", Optional ByVal StakeholderCode As String = "")
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim m As Integer = 0
        Dim n As Integer = 0
        Dim Row As TableRow
        Dim Cell As TableCell
        Dim arrLabel(21) As String
        Dim arrControl(21) As String
        Dim arrGrillaLabel(21) As String
        Dim arrGrillaControl(21) As String
        Dim TipoControl As String = ""
        Dim CssClassLabel As String = ""
        Dim CssClassControl As String = ""
        Dim ControlWidth As String = ""
        Dim ControlTextMode As String = "0"
        Dim EtiquetaAlign As String = ""
        Dim ToolTip As String = ""
        Dim IsRequiredField As Boolean = True
        Dim IsNotEnabledField As Boolean = False
        Dim DomainField As String = ""
        Dim DataTextField As String = ""
        Dim DataFile As String = ""
        Dim SelectCommand As String = ""
        Dim Section As String = ""
        Dim Url As String = ""
        Dim FormularioWebPId As Long = 0
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""

        Dim Tareas As New Tareas
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim IndicadorEsManual As Boolean = False

        Dim TC As TabContainer
        Dim TP As TabPanel

        Dim sSQL As String = ""
        Dim HTMLCode As String = ""
        Dim jsCode As String = ""
        Dim jsCode2 As String = ""

        'Se agregan para hacer el cambio en el despliegue de las relaciones de asociacion
        Dim RelationTable As String = ""
        Dim sSQLRelationSelect As String = ""


        Dim GroupValidation As String = ""

        i = 0
        t = Lecturas.LeerTabsFormularioWeb(arrLabel, arrControl, NumeroPagina, i)

        If i > 0 Then  'Página posee tabs

            Row = New TableRow
            Cell = New TableCell
            Cell.Style(HtmlTextWriterStyle.TextAlign) = "left"
            Cell.Height = "4"
            Cell.ColumnSpan = "2"
            Cell.Controls.Add(New LiteralControl("<hr />"))
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)

            Row = New TableRow
            Cell = New TableCell
            Cell.ColumnSpan = "2"

            'Crea el Tab Container
            TC = New TabContainer
            TC.ID = "DynamicTab" ' & NumeroPagina & i
            TC.ClientIDMode = UI.ClientIDMode.Static
            'TC.Height = "400"
            TC.OnClientActiveTabChanged = "ActiveTabChanged"
            ' Primer Tab Panel: Con k corren los paneles                                  

            'Aquí comienza el If si me quiero saltar un tab.

            For k = 0 To i - 1
                t = Lecturas.LeerControlFormularioWeb(TipoControl, CssClassLabel, CssClassControl, EtiquetaAlign, ControlWidth, ControlTextMode, ToolTip, IsRequiredField, IsNotEnabledField, DomainField, DataTextField, DataFile, SelectCommand, "Tabs", GroupValidation, NumeroPagina, k + 1)
                t = Lecturas.LeerIdFormularioWeb(FormularioWebPId, "Tabs", NumeroPagina, k + 1, Pagina, NombrePagina)

                TP = New TabPanel
                TP.ID = "TabPanel" & arrControl(k)
                TP.ClientIDMode = UI.ClientIDMode.Static
                TP.HeaderText = arrLabel(k)
                TP.CssClass = "tab_contenido"
                'Agrega el contenedor
                TP.Controls.Add(New LiteralControl("<contenttemplate>"))
                TP.Controls.Add(New LiteralControl("<div id=""" & arrLabel(k) & """>"))
                'Aqui debo ir completando el script para llenar las tablas al hacer click en las viñetas.
                'El script es del tipo LoadTabla e invoca la web services que corresponda.
                'El script lo ponemos al final

                jsCode = jsCode & "if (indice==" & k & ") {" & vbCrLf
                jsCode = jsCode & "           // corresponde a las " & arrLabel(k) & vbCrLf
                jsCode = jsCode & "   LoadTabla" & arrLabel(k) & "('" & arrControl(k) & "','" & arrLabel(k) & "'," & k & ",'" & IsNotEnabledField & "','" & Pagina & "','" & NombrePagina & "'," & MenuOptionsId & ", '" & MasterName & "'," & MasterId & ",'" & DomainField & "', " & FormularioWebPId & ",'" & FilterField & "', '" & sSQLWhere & "','" & sSQLOrder & "', '" & PaginaWebName & "'," & UserId & ");"
                jsCode = jsCode & "}" & vbCrLf
                jsCode2 = jsCode2 & "function OnCompleteLoadTabla" & arrLabel(k) & "(arg) {" & vbCrLf
                jsCode2 = jsCode2 & "   var cajadiv = ""div#" & arrLabel(k) & """;" & vbCrLf
                jsCode2 = jsCode2 & "   document.getElementById(""" & arrLabel(k) & """).innerHTML = arg;" & vbCrLf
                jsCode2 = jsCode2 & "}" & vbCrLf
                jsCode2 = jsCode2 & "function OnTimeOutLoadTabla" & arrLabel(k) & "(arg) {" & vbCrLf
                jsCode2 = jsCode2 & "   alert(""TimeOut al invocar el servicio"");" & vbCrLf
                jsCode2 = jsCode2 & "}" & vbCrLf
                jsCode2 = jsCode2 & "function OnErrorLoadTabla" & arrLabel(k) & "(arg) {" & vbCrLf
                jsCode2 = jsCode2 & "   alert(""Error encontrado al invocar el servicio"");" & vbCrLf
                jsCode2 = jsCode2 & "}" & vbCrLf
                jsCode2 = jsCode2 & "function LoadTabla" & arrLabel(k) & "(arrControl, arrLabel, k, IsNotEnabledField, Pagina, NombrePagina, MenuOptionsId, MasterName, MasterId, DomainField, FormularioWebPId, FilterField, sSQLWhere, sSQLOrder, PaginaWebName, UserId) {" & vbCrLf
                jsCode2 = jsCode2 & "   ret = SimpleService.LoadTabla(arrControl, arrLabel, k, IsNotEnabledField, Pagina, NombrePagina, MenuOptionsId, MasterName, MasterId, DomainField, FormularioWebPId, FilterField, sSQLWhere, sSQLOrder, PaginaWebName, UserId, OnCompleteLoadTabla" & arrLabel(k) & ", OnTimeOutLoadTabla" & arrLabel(k) & ", OnErrorLoadTabla" & arrLabel(k) & ");" & vbCrLf
                jsCode2 = jsCode2 & "   return (true);" & vbCrLf
                jsCode2 = jsCode2 & "}" & vbCrLf

                'Aqui hay que invocar una llamada para traer la tabla en html, sólo para la primera viñeta
                If k = 0 Then
                    HTMLCode = Lecturas.LoadTabla(arrControl(k), arrLabel(k), k, IsNotEnabledField, Pagina, NombrePagina, MenuOptionsId, MasterName, MasterId, DomainField, FormularioWebPId, FilterField, sSQLWhere, sSQLOrder, PaginaWebName, Session("PersonaId"))
                    TP.Controls.Add(New LiteralControl(HTMLCode))
                End If

                TP.Controls.Add(New LiteralControl("</div>"))
                TP.Controls.Add(New LiteralControl("</contenttemplate>"))
                TC.Controls.Add(TP)
            Next

            'Aquí termina el End If si me quiero saltar un tab


            Cell.Controls.Add(TC)
            Row.Cells.Add(Cell)
            MyTable.Rows.Add(Row)

            MyJavaScript.Controls.Add(New LiteralControl(GenerarJScriptPorTabContainer(jsCode, jsCode2)))

        End If



    End Sub







End Class
