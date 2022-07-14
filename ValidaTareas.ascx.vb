Imports AjaxControlToolkit
Partial Class ValidaTareas
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 24-04-2011 8:54:32
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
    Dim txtMasterName As TextBox ' Etiqueta : Código Tarea - Control : txtMasterName - Variable : TareasCodigo
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim TareasCodigo As String ' Etiqueta : Código Tarea - Control : txtMasterName - Variable : TareasCodigo
    '----------------------------------------
    '----------------------------------------
    ' Declaración de Campos de la Tabla Tareas
    '----------------------------------------
    Dim TareasId As Long
    'Dim TareasCodigo As String = "" ' Etiqueta : Código Tarea - Control : txtTareasCodigo - Variable : TareasCodigo
    Dim TareasName As String = "" ' Etiqueta : Objetivo - Control : txtTareasName - Variable : TareasName
    Dim TareasDescription As String = "" ' Etiqueta : Descripción - Control : txtTareasDescription - Variable : TareasDescription
    'Dim PGGCodigo As String ' Etiqueta : Código del PGG - Control : txtPGGCodigo - Variable : PGGCodigo
    'Dim AccionesCodigo As String ' Etiqueta : Acción del PGG - Control : txtAccionesCodigo - Variable : AccionesCodigo
    Dim ActividadesSecuencia As Long = 0 ' Etiqueta : Secuencia de Actividad - Control : txtActividadesSecuencia - Variable : ActividadesSecuencia
    Dim TareasMes As Long = 0 ' Etiqueta : Mes - Control : txtTareasMes - Variable : TareasMes
    Dim TareasAno As String = "" ' Etiqueta : Año - Control : txtTareasAno - Variable : TareasAno
    Dim TareasSecuencia As Long = 0 ' Etiqueta : # de actividad - Control : txtTareasSecuencia - Variable : TareasSecuencia
    Dim UsuariosCodigo As String = "" ' Etiqueta : Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim TareasHH As Double = 0 ' Etiqueta : HH Estimadas - Control : txtTareasHH - Variable : TareasHH
    Dim TareasUSD As Double = 0 ' Etiqueta : Costo Estimado (USD) - Control : txtTareasUSD - Variable : TareasUSD
    Dim DiaMinimoInicio As Long = 0 ' Etiqueta : Mínimo día de inicio - Control : txtDiaMinimoInicio - Variable : DiaMinimoInicio
    Dim DiaMaximoTermino As Long = 0 ' Etiqueta : Max. Día de Término - Control : txtDiaMaximoTermino - Variable : DiaMaximoTermino
    Dim TareasDiaProgramado As Long = 0 ' Etiqueta : Día sugerido - Control : txtTareasDiaProgramado - Variable : TareasDiaProgramado
    Dim TareasTipo As String = "Tarea No Programada" ' Etiqueta : Tipo de Tarea - Control : txtTareasTipo - Variable : TareasTipo
    Dim TareasDiaRealTermino As Long = 0 ' Etiqueta : Día Real de Término - Control : txtTareasDiaRealTermino - Variable : TareasDiaRealTermino
    Dim TareasHHConsumidas As Double = 0 ' Etiqueta : HH Consumidas - Control : txtTareasHHConsumidas - Variable : TareasHHConsumidas
    Dim TareasUSDConsumidos As Double = 0 ' Etiqueta : Costo Real (USD) - Control : txtTareasUSDConsumidos - Variable : TareasUSDConsumidos
    Dim EstadoTareasCodigo As String = "Asignada" ' Etiqueta : Estado de Tarea - Control : txtEstadoTareasCodigo - Variable : EstadoTareasCodigo
    Dim TareasEjecutor As String = ""
    '----------------------------------------

    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogin", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina
        Try
            MasterName = txtMasterName.Text
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("TareasId", "TareasCodigo", "Tareas", MasterName, MasterId)
            If MasterId > 0 Then
                Url = Url & "&Id=" & MasterId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                Response.Redirect(Url)
            Else
                t = AccionesABM.MasterPartialInsert("TareasId", "TareasCodigo", "Tareas", MasterName, CLng(Session("PersonaId")), MasterId)
                Url = Url & "&Id=" & MasterId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                Response.Redirect(Url)
            End If
        Catch
            t = 0
        End Try
    End Sub
    Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogout", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        'Call Lecturas.CrearFormularioLogin(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyTable, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        'AddHandler LoginButton.Click, AddressOf RFC_Login
        'AddHandler CancelButton.Click, AddressOf RFC_Logout
        'If IsPostBack Then
        'txtMasterName = FindControl("txtMasterName")
        'End If

        Dim AccionesABM As New AccionesABM
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogin", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina

        t = AccionesABM.MasterPartialInsert("TareasId", "TareasCodigo", "Tareas", MasterName, CLng(Session("PersonaId")), MasterId)

        'Inicializo variable para crear una tarea
        TareasId = MasterId
        TareasCodigo = "Tarea Extraprogramada " & MasterId
        TareasName = ""
        TareasDescription = ""
        ActividadesSecuencia = 0  'Para indicar que proviene de una acción y no de una actividad
        TareasMes = 0 ' Se reasigna más adelante
        TareasAno = 0
        TareasSecuencia = 0 ' Se reasigna más adelante
        t = Usuarios.LeerUsuariosCodigoByUsuariosId(CLng(Session("PersonaId")), UsuariosCodigo)
        TareasHH = 0 ' Se asume una distribución uniforme de las HH por cada tarea
        TareasUSD = 0 ' idem anterior
        DiaMinimoInicio = 1 ' Se reasigna más adelante
        DiaMaximoTermino = 28 ' Se reasigna más adelante
        TareasDiaProgramado = 14 ' Se reasigna más adelante
        TareasTipo = "Tarea No Programada"
        TareasDiaRealTermino = 0
        TareasHHConsumidas = 0
        TareasUSDConsumidos = 0
        EstadoTareasCodigo = "Creada"
        t = Tareas.TareasUpdate(TareasId, TareasCodigo, TareasName, TareasDescription, "", "", CLng(ActividadesSecuencia), CLng(TareasMes), TareasAno, CLng(TareasSecuencia), UsuariosCodigo, CDbl(TareasHH * 100), CDbl(TareasUSD * 100), CLng(DiaMinimoInicio), CLng(DiaMaximoTermino), CLng(TareasDiaProgramado), TareasTipo, CLng(TareasDiaRealTermino), CDbl(TareasHHConsumidas * 100), CDbl(TareasUSDConsumidos * 100), EstadoTareasCodigo, CLng(Session("PersonaId")))
        't = Tareas.TareasEjecutorUpdate(TareasId, TareasCodigo, UsuariosCodigo, CLng(Session("PersonaId")))
        Url = Url & "&Id=" & MasterId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url)
    End Sub
End Class
