Imports AjaxControlToolkit
Partial Class FichaTareasKPI
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 25-04-2011 9:55:16
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
    Dim txtTareasCodigo As TextBox ' Etiqueta : Tarea # - Control : txtTareasCodigo - Variable : TareasCodigo
    Dim txtTareasKPISecuencia As TextBox ' Etiqueta : Secuencia - Control : txtTareasKPISecuencia - Variable : TareasKPISecuencia
    Dim txtIndicadoresCodigo As TextBox ' Etiqueta : Indicador (KPI) - Control : txtIndicadoresCodigo - Variable : IndicadoresCodigo
    Dim txtIndicadoresCodigoDescription As TextBox ' Etiqueta : Indicador (KPI) - Control : txtIndicadoresCodigo - Variable : IndicadoresCodigo
    Dim txtAreasName As TextBox ' Etiqueta : Área - Control : txtAreasName - Variable : AreasName
    Dim txtAreasNameDescription As TextBox ' Etiqueta : Área - Control : txtAreasName - Variable : AreasName
    Dim txtEmpresasCodigo As TextBox ' Etiqueta : Empresa - Control : txtEmpresasCodigo - Variable : EmpresasCodigo
    Dim txtEmpresasCodigoDescription As TextBox ' Etiqueta : Empresa - Control : txtEmpresasCodigo - Variable : EmpresasCodigo
    Dim txtContratoCodigo As TextBox ' Etiqueta : Contrato - Control : txtContratoCodigo - Variable : ContratoCodigo
    Dim txtContratoCodigoDescription As TextBox ' Etiqueta : Contrato - Control : txtContratoCodigo - Variable : ContratoCodigo
    Dim txtTareasKPIAno As TextBox ' Etiqueta : Año - Control : txtTareasKPIAno - Variable : TareasKPIAno
    Dim txtTareasKPIMes As TextBox ' Etiqueta : Mes - Control : txtTareasKPIMes - Variable : TareasKPIMes
    Dim txtTareasKPIValor1 As TextBox ' Etiqueta : Valor 1 - Control : txtTareasKPIValor1 - Variable : TareasKPIValor1
    Dim txtTareasKPIValor2 As TextBox ' Etiqueta : Valor 2 - Control : txtTareasKPIValor2 - Variable : TareasKPIValor2
    Dim txtTareasKPIValor3 As TextBox ' Etiqueta : Valor 3 - Control : txtTareasKPIValor3 - Variable : TareasKPIValor3
    Dim txtTareasKPIObservacion As TextBox ' Etiqueta : Observaciones - Control : txtTareasKPIObservacion - Variable : TareasKPIObservacion
    Dim txtTareasKPIFechaRegistro As TextBox ' Etiqueta : Fecha del Dato - Control : txtTareasKPIFechaRegistro - Variable : TareasKPIFechaRegistro
    Dim txtUsuariosCodigo As TextBox ' Etiqueta : Responsable Actividad - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim txtUsuariosCodigoDescription As TextBox ' Etiqueta : Responsable Actividad - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim txtTareasKPIResponsable As TextBox ' Etiqueta : Nombre Funcionario - Control : txtTareasKPIResponsable - Variable : TareasKPIResponsable
    Dim txtTareasKPICargo As TextBox ' Etiqueta : Cargo Funcionario - Control : txtTareasKPICargo - Variable : TareasKPICargo
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim TareasCodigo As String ' Etiqueta : Tarea # - Control : txtTareasCodigo - Variable : TareasCodigo
    Dim TareasKPISecuencia As Long ' Etiqueta : Secuencia - Control : txtTareasKPISecuencia - Variable : TareasKPISecuencia
    Dim IndicadoresCodigo As String ' Etiqueta : Indicador (KPI) - Control : txtIndicadoresCodigo - Variable : IndicadoresCodigo
    Dim AreasName As String ' Etiqueta : Área - Control : txtAreasName - Variable : AreasName
    Dim EmpresasCodigo As String ' Etiqueta : Empresa - Control : txtEmpresasCodigo - Variable : EmpresasCodigo
    Dim ContratoCodigo As String ' Etiqueta : Contrato - Control : txtContratoCodigo - Variable : ContratoCodigo
    Dim TareasKPIAno As String ' Etiqueta : Año - Control : txtTareasKPIAno - Variable : TareasKPIAno
    Dim TareasKPIMes As Long ' Etiqueta : Mes - Control : txtTareasKPIMes - Variable : TareasKPIMes
    Dim TareasKPIValor1 As Double ' Etiqueta : Valor 1 - Control : txtTareasKPIValor1 - Variable : TareasKPIValor1
    Dim TareasKPIValor2 As Double ' Etiqueta : Valor 2 - Control : txtTareasKPIValor2 - Variable : TareasKPIValor2
    Dim TareasKPIValor3 As Long ' Etiqueta : Valor 3 - Control : txtTareasKPIValor3 - Variable : TareasKPIValor3
    Dim TareasKPIObservacion As String ' Etiqueta : Observaciones - Control : txtTareasKPIObservacion - Variable : TareasKPIObservacion
    Dim TareasKPIFechaRegistro As Date ' Etiqueta : Fecha del Dato - Control : txtTareasKPIFechaRegistro - Variable : TareasKPIFechaRegistro
    Dim UsuariosCodigo As String ' Etiqueta : Responsable Actividad - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim TareasKPIResponsable As String ' Etiqueta : Nombre Funcionario - Control : txtTareasKPIResponsable - Variable : TareasKPIResponsable
    Dim TareasKPICargo As String ' Etiqueta : Cargo Funcionario - Control : txtTareasKPICargo - Variable : TareasKPICargo
    '----------------------------------------
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Dim AccionesABM As New AccionesABM
        Dim TareasKPI As New TareasKPI
        Try
            t = TareasKPI.TareasKPIDelete(Session("Id"), Request.QueryString("MasterName"), CLng(Session("PersonaId")))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Return(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReturnButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLReturn", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & Request.QueryString("MasterName") & "&MasterId=" & Request.QueryString("MasterId")
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Session("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & Request.QueryString("MasterName") & "&MasterId=" & Request.QueryString("MasterId")
        Dim AccionesABM As New AccionesABM
        Dim TareasKPI As New TareasKPI
        Dim Contrato As New Contrato
        Dim Acciones As New Acciones

        Try
            txtEmpresasCodigo.Text = Contrato.LeerContratoEmpresasCodigoByName(txtContratoCodigo.Text)
            txtIndicadoresCodigo.Text = Acciones.LeerIndicadoresCodigoByTareasCodigo(txtTareasCodigo.Text)
            't = TareasKPI.TareasKPIUpdate(Session("Id"), CStr(txtTareasCodigo.Text), CLng(txtTareasKPISecuencia.Text), CStr(txtIndicadoresCodigo.Text), CStr(txtAreasName.Text), CStr(txtEmpresasCodigo.Text), CStr(txtContratoCodigo.Text), CStr(txtTareasKPIAno.Text), CLng(txtTareasKPIMes.Text), CDbl(txtTareasKPIValor1.Text * 100), CDbl(txtTareasKPIValor2.Text * 100), CLng(txtTareasKPIValor3.Text), CStr(txtTareasKPIObservacion.Text), CDate(txtTareasKPIFechaRegistro.Text), CStr(txtUsuariosCodigo.Text), CStr(txtTareasKPIResponsable.Text), CStr(txtTareasKPICargo.Text), Session("PersonaId"))
            t = TareasKPI.TareasKPIUpdate(Session("Id"), CStr(txtTareasCodigo.Text), CLng(txtTareasKPISecuencia.Text), CStr(txtIndicadoresCodigo.Text), CStr(txtAreasName.Text), CStr(txtEmpresasCodigo.Text), CStr(txtContratoCodigo.Text), CStr(txtTareasKPIAno.Text), CLng(txtTareasKPIMes.Text), CDbl(txtTareasKPIValor1.Text * 100), 0, 0, CStr(txtTareasKPIObservacion.Text), CDate(txtTareasKPIFechaRegistro.Text), CStr(txtUsuariosCodigo.Text), CStr(txtTareasKPIResponsable.Text), CStr(txtTareasKPICargo.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim TareasKPI As New TareasKPI
        Dim Indicadores As New Indicadores
        Dim Areas As New Areas
        Dim Empresas As New Empresas
        Dim Contrato As New Contrato
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
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
        Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler DeleteButton.Click, AddressOf RFC_Delete
        AddHandler ReturnButton.Click, AddressOf RFC_Return
        Try
            If Not IsPostBack Then
                MasterName = Request.QueryString("MasterName")
                Session("MasterId") = Request.QueryString("MasterId")
                DetailId = Request.QueryString("Id")
                If DetailId = 0 Then
                    DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("TareasCodigo", "TareasKPISecuencia", "TareasKPI", MasterName)
                    t = AccionesABM.ObjectPartialInsert("TareasKPIId", "TareasCodigo", "TareasKPISecuencia", "TareasKPI", MasterName, DetailSecuencia, CLng(Session("PersonaId")), DetailId)
                End If
                Session("Id") = DetailId
                If t = TareasKPI.LeerTareasKPI(Session("Id"), TareasCodigo, TareasKPISecuencia, IndicadoresCodigo, AreasName, EmpresasCodigo, ContratoCodigo, TareasKPIAno, TareasKPIMes, TareasKPIValor1, TareasKPIValor2, TareasKPIValor3, TareasKPIObservacion, TareasKPIFechaRegistro, UsuariosCodigo, TareasKPIResponsable, TareasKPICargo) Then
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = TareasCodigo
                    txtTareasCodigo.ToolTip = Tareas.LeerTareasDescriptionByName(TareasCodigo)
                    txtTareasKPISecuencia = FindControl("txtTareasKPISecuencia")
                    txtTareasKPISecuencia.Text = TareasKPISecuencia
                    txtIndicadoresCodigo = FindControl("txtIndicadoresCodigo")
                    txtIndicadoresCodigo.Text = IndicadoresCodigo
                    'txtIndicadoresCodigoDescription = FindControl("txtIndicadoresCodigoDescription")
                    'txtIndicadoresCodigoDescription.Text = Indicadores.LeerIndicadoresDescriptionByName(IndicadoresCodigo)
                    txtAreasName = FindControl("txtAreasName")
                    txtAreasName.Text = AreasName
                    txtAreasNameDescription = FindControl("txtAreasNameDescription")
                    txtAreasNameDescription.Text = Areas.LeerAreasDescriptionByName(AreasName)
                    txtEmpresasCodigo = FindControl("txtEmpresasCodigo")
                    txtEmpresasCodigo.Text = EmpresasCodigo
                    'txtEmpresasCodigoDescription = FindControl("txtEmpresasCodigoDescription")
                    'txtEmpresasCodigoDescription.Text = Empresas.LeerEmpresasDescriptionByName(EmpresasCodigo)
                    txtContratoCodigo = FindControl("txtContratoCodigo")
                    txtContratoCodigo.Text = ContratoCodigo
                    txtContratoCodigoDescription = FindControl("txtContratoCodigoDescription")
                    txtContratoCodigoDescription.Text = Contrato.LeerContratoDescriptionByName(ContratoCodigo)
                    txtTareasKPIAno = FindControl("txtTareasKPIAno")
                    txtTareasKPIAno.Text = TareasKPIAno
                    txtTareasKPIMes = FindControl("txtTareasKPIMes")
                    txtTareasKPIMes.Text = TareasKPIMes
                    txtTareasKPIValor1 = FindControl("txtTareasKPIValor1")
                    txtTareasKPIValor1.Text = FormatNumber(TareasKPIValor1 / 100, 2)
                    txtTareasKPIValor2 = FindControl("txtTareasKPIValor2")
                    txtTareasKPIValor2.Text = FormatNumber(TareasKPIValor2 / 100, 2)
                    txtTareasKPIValor3 = FindControl("txtTareasKPIValor3")
                    txtTareasKPIValor3.Text = FormatNumber(TareasKPIValor3 / 100, 2)
                    txtTareasKPIObservacion = FindControl("txtTareasKPIObservacion")
                    txtTareasKPIObservacion.Text = TareasKPIObservacion
                    txtTareasKPIFechaRegistro = FindControl("txtTareasKPIFechaRegistro")
                    txtTareasKPIFechaRegistro.Text = TareasKPIFechaRegistro
                    txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
                    If Len(UsuariosCodigo) = 0 Then UsuariosCodigo = Tareas.LeerTareasUsuariosCodigoByName(TareasCodigo)
                    txtUsuariosCodigo.Text = UsuariosCodigo
                    txtUsuariosCodigoDescription = FindControl("txtUsuariosCodigoDescription")
                    txtUsuariosCodigoDescription.Text = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)
                    txtTareasKPIResponsable = FindControl("txtTareasKPIResponsable")
                    txtTareasKPIResponsable.Text = TareasKPIResponsable
                    txtTareasKPICargo = FindControl("txtTareasKPICargo")
                    txtTareasKPICargo.Text = TareasKPICargo
                Else
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = Session("TareasCodigo")
                    txtTareasKPISecuencia = FindControl("txtTareasKPISecuencia")
                    txtTareasKPISecuencia.Text = Session("TareasKPISecuencia")
                End If
            Else
                txtTareasCodigo = FindControl("txtTareasCodigo")
                txtTareasKPISecuencia = FindControl("txtTareasKPISecuencia")
                txtIndicadoresCodigo = FindControl("txtIndicadoresCodigo")
                txtAreasName = FindControl("txtAreasName")
                txtEmpresasCodigo = FindControl("txtEmpresasCodigo")
                txtContratoCodigo = FindControl("txtContratoCodigo")
                txtTareasKPIAno = FindControl("txtTareasKPIAno")
                txtTareasKPIMes = FindControl("txtTareasKPIMes")
                txtTareasKPIValor1 = FindControl("txtTareasKPIValor1")
                txtTareasKPIValor2 = FindControl("txtTareasKPIValor2")
                txtTareasKPIValor3 = FindControl("txtTareasKPIValor3")
                txtTareasKPIObservacion = FindControl("txtTareasKPIObservacion")
                txtTareasKPIFechaRegistro = FindControl("txtTareasKPIFechaRegistro")
                txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
                txtTareasKPIResponsable = FindControl("txtTareasKPIResponsable")
                txtTareasKPICargo = FindControl("txtTareasKPICargo")
            End If
        Catch
            t = False
        End Try
    End Sub
End Class
