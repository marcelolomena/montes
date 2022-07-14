Imports AjaxControlToolkit
Partial Class FichaTareas
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 24-04-2011 8:52:50
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
    Dim WithEvents NewUpdateButton As Button
    Dim WithEvents MailButton As Button
    Dim WithEvents CommentButton As Button
    Dim WithEvents MuroButton As Button
    Dim WithEvents AlertaButton As Button
    '----------------------------------------
    ' Declaración de controles de validación
    '----------------------------------------
    Dim valTextBox As RequiredFieldValidator
    Dim sumValidacion As ValidationSummary
    Dim REValidacion As RegularExpressionValidator
    Dim CuValidacion As CustomValidator
    Dim CoValidacion As CompareValidator
    '----------------------------------------
    ' Declaración de controles de para hacer upload de archivo
    '----------------------------------------
    Dim UploadLink As HyperLink
    Dim UploadLink2 As HyperLink
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
    Dim txtTareasCodigo As TextBox ' Etiqueta : Código Tarea - Control : txtTareasCodigo - Variable : TareasCodigo
    Dim txtTareasName As TextBox ' Etiqueta : Objetivo - Control : txtTareasName - Variable : TareasName
    Dim txtTareasDescription As TextBox ' Etiqueta : Descripción - Control : txtTareasDescription - Variable : TareasDescription
    Dim txtPGGCodigo As TextBox ' Etiqueta : Código del PGG - Control : txtPGGCodigo - Variable : PGGCodigo
    Dim txtPGGCodigoDescription As TextBox ' Etiqueta : Código del PGG - Control : txtPGGCodigo - Variable : PGGCodigo
    Dim txtAccionesCodigo As TextBox ' Etiqueta : Acción del PGG - Control : txtAccionesCodigo - Variable : AccionesCodigo
    Dim txtAccionesCodigoDescription As TextBox ' Etiqueta : Acción del PGG - Control : txtAccionesCodigo - Variable : AccionesCodigo
    Dim txtActividadesSecuencia As TextBox ' Etiqueta : Secuencia de Actividad - Control : txtActividadesSecuencia - Variable : ActividadesSecuencia
    Dim txtTareasMes As TextBox ' Etiqueta : Mes - Control : txtTareasMes - Variable : TareasMes
    Dim txtTareasAno As TextBox ' Etiqueta : Año - Control : txtTareasAno - Variable : TareasAno
    Dim txtTareasSecuencia As TextBox ' Etiqueta : # de actividad - Control : txtTareasSecuencia - Variable : TareasSecuencia
    Dim txtUsuariosCodigo As TextBox ' Etiqueta : Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim txtUsuariosCodigoDescription As TextBox ' Etiqueta : Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim txtTareasHH As TextBox ' Etiqueta : HH Estimadas - Control : txtTareasHH - Variable : TareasHH
    Dim txtTareasUSD As TextBox ' Etiqueta : Costo Estimado (USD) - Control : txtTareasUSD - Variable : TareasUSD
    Dim txtDiaMinimoInicio As TextBox ' Etiqueta : Mínimo día de inicio - Control : txtDiaMinimoInicio - Variable : DiaMinimoInicio
    Dim txtDiaMaximoTermino As TextBox ' Etiqueta : Max. Día de Término - Control : txtDiaMaximoTermino - Variable : DiaMaximoTermino
    Dim txtTareasDiaProgramado As TextBox ' Etiqueta : Día sugerido - Control : txtTareasDiaProgramado - Variable : TareasDiaProgramado
    Dim txtTareasTipo As TextBox ' Etiqueta : Tipo de Tarea - Control : txtTareasTipo - Variable : TareasTipo
    Dim txtTareasDiaRealTermino As TextBox ' Etiqueta : Día Real de Término - Control : txtTareasDiaRealTermino - Variable : TareasDiaRealTermino
    Dim txtTareasHHConsumidas As TextBox ' Etiqueta : HH Consumidas - Control : txtTareasHHConsumidas - Variable : TareasHHConsumidas
    Dim txtTareasUSDConsumidos As TextBox ' Etiqueta : Costo Real (USD) - Control : txtTareasUSDConsumidos - Variable : TareasUSDConsumidos
    Dim txtEstadoTareasCodigo As DropDownList ' Etiqueta : Estado de Tarea - Control : txtEstadoTareasCodigo - Variable : EstadoTareasCodigo
    Dim txtEstadoTareasCodigoDescription As TextBox ' Etiqueta : Estado de Tarea - Control : txtEstadoTareasCodigo - Variable : EstadoTareasCodigo
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim TareasCodigo As String ' Etiqueta : Código Tarea - Control : txtTareasCodigo - Variable : TareasCodigo
    Dim TareasName As String ' Etiqueta : Objetivo - Control : txtTareasName - Variable : TareasName
    Dim TareasDescription As String ' Etiqueta : Descripción - Control : txtTareasDescription - Variable : TareasDescription
    Dim PGGCodigo As String ' Etiqueta : Código del PGG - Control : txtPGGCodigo - Variable : PGGCodigo
    Dim AccionesCodigo As String ' Etiqueta : Acción del PGG - Control : txtAccionesCodigo - Variable : AccionesCodigo
    Dim ActividadesSecuencia As Long ' Etiqueta : Secuencia de Actividad - Control : txtActividadesSecuencia - Variable : ActividadesSecuencia
    Dim TareasMes As Long ' Etiqueta : Mes - Control : txtTareasMes - Variable : TareasMes
    Dim TareasAno As String ' Etiqueta : Año - Control : txtTareasAno - Variable : TareasAno
    Dim TareasSecuencia As Long ' Etiqueta : # de actividad - Control : txtTareasSecuencia - Variable : TareasSecuencia
    Dim UsuariosCodigo As String ' Etiqueta : Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim TareasHH As Double ' Etiqueta : HH Estimadas - Control : txtTareasHH - Variable : TareasHH
    Dim TareasUSD As Double ' Etiqueta : Costo Estimado (USD) - Control : txtTareasUSD - Variable : TareasUSD
    Dim DiaMinimoInicio As Long ' Etiqueta : Mínimo día de inicio - Control : txtDiaMinimoInicio - Variable : DiaMinimoInicio
    Dim DiaMaximoTermino As Long ' Etiqueta : Max. Día de Término - Control : txtDiaMaximoTermino - Variable : DiaMaximoTermino
    Dim TareasDiaProgramado As Long ' Etiqueta : Día sugerido - Control : txtTareasDiaProgramado - Variable : TareasDiaProgramado
    Dim TareasTipo As String ' Etiqueta : Tipo de Tarea - Control : txtTareasTipo - Variable : TareasTipo
    Dim TareasDiaRealTermino As Long ' Etiqueta : Día Real de Término - Control : txtTareasDiaRealTermino - Variable : TareasDiaRealTermino
    Dim TareasHHConsumidas As Double ' Etiqueta : HH Consumidas - Control : txtTareasHHConsumidas - Variable : TareasHHConsumidas
    Dim TareasUSDConsumidos As Double ' Etiqueta : Costo Real (USD) - Control : txtTareasUSDConsumidos - Variable : TareasUSDConsumidos
    Dim EstadoTareasCodigo As String ' Etiqueta : Estado de Tarea - Control : txtEstadoTareasCodigo - Variable : EstadoTareasCodigo
    '----------------------------------------
    ' Se agregar para filtrar la lista de rutas por empresa y cliente
    '------------------------------------------------------------------------------------
    ' Declaración de Controles del Formulario para comentarios, correos, avisos y alertas
    '------------------------------------------------------------------------------------
    Dim txtComentariosCriticos As TextBox ' Etiqueta : Código Provincia - Control : txtProvinciasCodigo - Variable : ProvinciasCodigo
    Dim txtFechaCritica As TextBox
    Dim chkProcurador As CheckBox
    Dim chkSupervisor As CheckBox
    Dim chkSecretaria As CheckBox
    Dim chkReceptor As CheckBox
    '---------------------------------------------------------------------------------
    ' Declaración de Campos del Formulario para comentarios, correos, avisos y alertas
    '---------------------------------------------------------------------------------
    Dim ComentariosCriticos As String
    Dim FechaCritica As Date
    '----------------------------------------
    ' Declaración de Controles del Formulario 2
    '----------------------------------------
    Dim txtComentarios As TextBox ' Etiqueta : Código Provincia - Control : txtProvinciasCodigo - Variable : ProvinciasCodigo
    Dim txtRut As TextBox
    Dim txtNombres As TextBox
    Dim txtApellidos As TextBox
    Dim txtProcurador As TextBox
    Dim txtProcuradorDescription As TextBox
    Dim txtProfesion As TextBox
    Dim txtEstadoCivil As TextBox
    Dim txtFechaEscritura As TextBox
    Dim txtCiudadEscritura As TextBox
    Dim txtNotarioEscritura As TextBox
    Dim txtMontoUF As TextBox
    Dim txtMesesPlazo As TextBox
    Dim txtFechaInicio As TextBox
    Dim txtDeudaCapitalUF As TextBox
    Dim txtDeudaCapitalPesos As TextBox
    Dim txtDeudaDividendosUF As TextBox
    Dim txtDeudaDividendosPesos As TextBox
    Dim txtInmuebleFojas As TextBox
    Dim txtInmuebleNumero As TextBox
    Dim txtInmuebleAno As TextBox
    Dim txtInmuebleCiudad As TextBox
    Dim txtHipotecaFojas As TextBox
    Dim txtHipotecaNumero As TextBox
    Dim txtHipotecaAno As TextBox
    Dim txtHipotecaCiudad As TextBox
    Dim txtRolJuicio As TextBox
    Dim txtFechaDistribucion As TextBox
    Dim txtJuzgado As TextBox
    Dim txtFechaPresentacion As TextBox
    Dim txtFechaNotificacion As TextBox
    Dim txtComunaNotificacion As TextBox
    Dim txtTasaInteresAnual As TextBox

    '----------------------------------------
    ' Declaración de Campos de la Aplicación 2
    '----------------------------------------
    Dim Comentarios As String ' Etiqueta : Código Provincia - Control : txtProvinciasCodigo - Variable : ProvinciasCodigo
    Dim Rut As String
    Dim Nombres As String
    Dim Apellidos As String
    Dim Procurador As String
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
    Dim RolJuicio As String
    Dim FechaDistribucion As Date
    Dim Juzgado As String
    Dim FechaPresentacion As Date
    Dim FechaNotificacion As Date
    Dim ComunaNotificacion As String
    Dim TasaInteresAnual As Double

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
    Dim EstadoProcesoCodigo As String ' Etiqueta : Estado de la Demanda - Control : txtEstadoProcesoCodigo - Variable : EstadoProcesoCodigo

    '----------------------------------------
    Dim sqlSource As AccessDataSource
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&sSQLOrderBy=Order by TareasAno, TareasMes, TareasSecuencia, TareasCodigo"
        Dim Mensaje As String = ""
        Dim Coordinador As String = ""
        Dim UsuarioConectado As String = ""

        'La Tarea solo puede ser eliminada por el coordinador del programa de gestión
        Coordinador = Tareas.LeerCoordinadorDeTareas(txtTareasCodigo.Text)
        t = Usuarios.LeerUsuariosCodigoByUsuariosId(Session("PersonaId"), UsuarioConectado)
        ' Si el UsuarioConectado es igual al Coordinador se puede eliminar la tarea    
        If UsuarioConectado = Coordinador Then
            Try
                t = Tareas.TareasDelete(Request.QueryString("Id"), CStr(txtTareasCodigo.Text), CLng(Session("PersonaId")), Mensaje, CLng(Request.QueryString("MenuOptionsId")))
                If t = False Then
                    MyMessage1.Text = Mensaje
                Else
                    Response.Redirect(Url)
                End If
            Catch
                t = 0
            End Try
        Else
            MyMessage1.Text = "La Tarea sólo puede ser eliminada por el coordinador del programa"
        End If



    End Sub
    Protected Sub RFC_Search(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLSearch", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogout", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&sSQLOrderBy=Order by TareasAno, TareasMes, TareasSecuencia, TareasCodigo"
        Url = "IndexSGI.aspx?PaginaWebName=Busca Mis Tareas&Id=" & Session("PersonaId") & "&MenuOptionsId=422&UsuariosCodigo=" & Session("EMail")

        Response.Redirect(Url)
    End Sub
    ' Aquí se agrega el segundo Update
    Protected Sub RFC_UpdateNew(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewUpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas
        Dim Url As String
        Dim Acciones As New Acciones

        Dim VistaWeb As String = ""

        Dim TareasId As Long = CLng(Request.QueryString("Id"))
        Dim TareasCodigo As String = ""
        Dim TareasEjecutor As String = ""
        Dim TareasLogRol As String = ""
        Dim CarpetaJudicialId As Long = Tareas.LeerCarpetaJudicialIdbyTareasId(TareasId)

        t = Tareas.LeerEjecutorRolByTareasId(TareasId, TareasEjecutor, TareasLogRol, TareasCodigo)

        VistaWeb = Acciones.LeerPaginaWeb(txtAccionesCodigo.Text)
        Select Case VistaWeb
            Case "Ficha de Comentarios"  ' Se instancian los controles dependiendo de la acción a ejecutar
                t = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, txtComentarios.Text)
            Case "Ficha de DatosPersonales"
                't = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, txtComentarios.Text & " " & txtRut.Text & " " & txtNombres.Text & " " & txtApellidos.Text & " " & txtCiudad.Text & " " & txtDireccion.Text & " " & txtComuna.Text)
                t = CarpetaJudicial.CarpetaJudicialIdentificacionDeudorUpdate(CarpetaJudicialId, TareasId, txtRut.Text, txtNombres.Text, txtApellidos.Text, Session("PersonaId"))
            Case "Ficha de AsignaProcurador"
                t = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, txtComentarios.Text & " " & txtProcurador.Text)
                t = CarpetaJudicial.CarpetaJudicialProcuradorUpdate(CarpetaJudicialId, TareasId, txtProcurador.Text, Session("PersonaId"))
            Case "Ficha de MasAntecedentes"
                't = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, txtComentarios.Text & " " & txtProfesion.Text)
                t = CarpetaJudicial.CarpetaJudicialMasAntecedentesUpdate(CarpetaJudicialId, TareasId, CStr(txtProfesion.Text), Session("PersonaId"))
            Case "Ficha de JuzgadoRol"
                t = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, "Rol: " & txtRolJuicio.Text & " - Tribunal: " & txtJuzgado.Text)
                t = CarpetaJudicial.CarpetaJudicialJuzgadoRolUpdate(CarpetaJudicialId, TareasId, CStr(txtRolJuicio.Text), CStr(txtJuzgado.Text), CDate(txtFechaDistribucion.Text), Session("PersonaId"))
            Case "Ficha de FechaPresentacion"
                t = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, txtFechaPresentacion.Text)
                t = CarpetaJudicial.CarpetaJudicialFechaPresentacionUpdate(CarpetaJudicialId, TareasId, CDate(txtFechaPresentacion.Text), Session("PersonaId"))
            Case "Ficha de Notificacion"
                t = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, "Fecha de Notificación: " & txtFechaNotificacion.Text & " Comuna: " & txtComunaNotificacion.Text)
                t = CarpetaJudicial.CarpetaJudicialFechaNotificacionUpdate(CarpetaJudicialId, TareasId, CDate(txtFechaNotificacion.Text), txtComunaNotificacion.Text, Session("PersonaId"))
            Case "Ficha de Notificacion44"
                t = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, "Fecha de Notificación por el Artículo 44: " & txtFechaNotificacion.Text & " Comuna: " & txtComunaNotificacion.Text)
                t = CarpetaJudicial.CarpetaJudicialFechaNotificacionUpdate(CarpetaJudicialId, TareasId, CDate(txtFechaNotificacion.Text), txtComunaNotificacion.Text, Session("PersonaId"))
        End Select


        Url = "IndexSGI.aspx?PaginaWebName=Ficha de Tareas&Id=" & TareasId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url, True)

    End Sub
    ' Aqui agrego el script para enviar correo
    Protected Sub RFC_Mail(ByVal sender As Object, ByVal e As System.EventArgs) Handles MailButton.Click

        Dim t As Boolean
        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim TareasId As Long = CLng(Request.QueryString("Id"))
        Dim CarpetaJudicialId As Long = Tareas.LeerCarpetaJudicialIdbyTareasId(TareasId)
        Dim UsuariosCodigo As String = ""
        Dim Url As String = ""

        t = Usuarios.LeerUsuariosCodigoByUsuariosId(Session("PersonaId"), UsuariosCodigo)

        CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)

        Dim Secretaria As String = CarpetaJudicial.DevolverUsuarioPorRol("Secretaria", CarpetaJudicialCodigo)
        Dim Supervisor As String = CarpetaJudicial.DevolverUsuarioPorRol("Supervisor", CarpetaJudicialCodigo)
        Dim Procurador As String = CarpetaJudicial.DevolverUsuarioPorRol("Procurador", CarpetaJudicialCodigo)
        Dim Receptor As String = CarpetaJudicial.DevolverUsuarioPorRol("Receptor", CarpetaJudicialCodigo)

        Dim TareasNotasFrom As String = ""
        Dim TareasNotasTo As String = ""
        Dim TareasNotasSubject As String = ""
        Dim Correo As String = ""
        Dim ConCopia As String = ""

        Dim TareasCodigo As String = ""
        Dim TareasEjecutor As String = ""
        Dim TareasLogRol As String = ""

        t = Tareas.LeerEjecutorRolByTareasId(TareasId, TareasEjecutor, TareasLogRol, TareasCodigo)

        TareasNotasFrom = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)
        If chkProcurador.Checked = True Then
            TareasNotasTo = Usuarios.LeerUsuariosDescriptionByName(Procurador)
            Correo = Procurador
        End If
        If chkSecretaria.Checked = True Then
            TareasNotasTo = TareasNotasTo & ", " & Usuarios.LeerUsuariosDescriptionByName(Secretaria)
            Correo = Correo & ", " & Secretaria
        End If
        If chkSupervisor.Checked = True Then
            TareasNotasTo = TareasNotasTo & ", " & Usuarios.LeerUsuariosDescriptionByName(Supervisor)
            Correo = Correo & ", " & Supervisor
        End If
        If chkReceptor.Checked = True Then
            TareasNotasTo = TareasNotasTo & ", " & Usuarios.LeerUsuariosDescriptionByName(Receptor)
            Correo = Correo & ", " & Receptor
        End If

        ConCopia = ""
        TareasNotasSubject = CarpetaJudicialCodigo & ": Scotiabank  y " & CarpetaJudicial.LeerApellidosDeudorByTareasId(TareasId)
        t = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, "Se envia correo a " & Correo & ": " & txtComentariosCriticos.Text)
        t = AccionesABM.EnviarMensajeDemanda(TareasId, CarpetaJudicialId, txtComentariosCriticos.Text, Secretaria, Procurador, Supervisor, Receptor, CarpetaJudicialCodigo, TareasNotasFrom, TareasNotasTo, Correo, TareasNotasSubject, ConCopia, Session("PersonaId"))

        Url = "IndexSGI.aspx?PaginaWebName=Ficha de Tareas&Id=" & TareasId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url, True)

    End Sub
    ' Script para grabar comentario
    Protected Sub RFC_Comment(ByVal sender As Object, ByVal e As System.EventArgs) Handles CommentButton.Click
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim TareasId As Long = CLng(Request.QueryString("Id"))
        Dim Url As String = ""

        Dim TareasCodigo As String = ""
        Dim TareasEjecutor As String = ""
        Dim TareasLogRol As String = ""

        t = Tareas.LeerEjecutorRolByTareasId(TareasId, TareasEjecutor, TareasLogRol, TareasCodigo)
        t = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, FormatDateTime(Now(), DateFormat.ShortDate) & ": " & txtComentariosCriticos.Text)

        Url = "IndexSGI.aspx?PaginaWebName=Ficha de Tareas&Id=" & TareasId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url, True)
    End Sub
    ' Script para publicar en el muro privado de alguien
    Protected Sub RFC_Muro(ByVal sender As Object, ByVal e As System.EventArgs) Handles MuroButton.Click
        Dim t As Boolean
        Dim AccionesABM As New AccionesABM
        Dim NotasTransversales As New NotasTransversales
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim TareasId As Long = CLng(Request.QueryString("Id"))
        Dim CarpetaJudicialId As Long = Tareas.LeerCarpetaJudicialIdbyTareasId(TareasId)
        Dim UsuariosCodigo As String = ""
        Dim Notas As String = ""
        Dim Url As String = ""
        Dim Causa As String = ""

        t = Usuarios.LeerUsuariosCodigoByUsuariosId(Session("PersonaId"), UsuariosCodigo)

        CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)

        Causa = CarpetaJudicialCodigo & ": Scotiabank y " & CarpetaJudicial.LeerApellidosDeudorByTareasId(TareasId)

        Dim Secretaria As String = CarpetaJudicial.DevolverUsuarioPorRol("Secretaria", CarpetaJudicialCodigo)
        Dim Supervisor As String = CarpetaJudicial.DevolverUsuarioPorRol("Supervisor", CarpetaJudicialCodigo)
        Dim Procurador As String = CarpetaJudicial.DevolverUsuarioPorRol("Procurador", CarpetaJudicialCodigo)
        Dim Receptor As String = CarpetaJudicial.DevolverUsuarioPorRol("Receptor", CarpetaJudicialCodigo)

        Dim SecretariaId As Long = 0
        Dim SupervisorId As Long = 0
        Dim ProcuradorId As Long = 0
        Dim ReceptorId As Long = 0

        t = Usuarios.LeerUsuariosByName(SecretariaId, Secretaria)
        t = Usuarios.LeerUsuariosByName(SupervisorId, Supervisor)
        t = Usuarios.LeerUsuariosByName(ProcuradorId, Procurador)
        t = Usuarios.LeerUsuariosByName(ReceptorId, Receptor)

        Dim TareasEjecutor As String = ""
        Dim TareasLogRol As String = ""

        t = Tareas.LeerEjecutorRolByTareasId(TareasId, TareasEjecutor, TareasLogRol, TareasCodigo)

        If chkProcurador.Checked = True Then
            t = NotasTransversales.NotasTransversalesInsert("De: " & Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo) & ", A: " & Usuarios.LeerUsuariosDescriptionByName(Procurador) & ", por la causa " & Causa & ": " & txtComentariosCriticos.Text, ProcuradorId)
            Notas = Usuarios.LeerUsuariosDescriptionByName(Procurador)
        End If
        If chkSecretaria.Checked = True Then
            t = NotasTransversales.NotasTransversalesInsert("De: " & Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo) & ", A: " & Usuarios.LeerUsuariosDescriptionByName(Secretaria) & ", por la causa " & Causa & ": " & txtComentariosCriticos.Text, SecretariaId)
            Notas = Notas & ", " & Usuarios.LeerUsuariosDescriptionByName(Secretaria)
        End If
        If chkSupervisor.Checked = True Then
            t = NotasTransversales.NotasTransversalesInsert("De: " & Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo) & ", A: " & Usuarios.LeerUsuariosDescriptionByName(Supervisor) & ", por la causa " & Causa & ": " & txtComentariosCriticos.Text, SupervisorId)
            Notas = Notas & ", " & Usuarios.LeerUsuariosDescriptionByName(Supervisor)
        End If
        If chkReceptor.Checked = True Then
            t = NotasTransversales.NotasTransversalesInsert("De: " & Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo) & ", A: " & Usuarios.LeerUsuariosDescriptionByName(Receptor) & ", por la causa " & Causa & ": " & txtComentariosCriticos.Text, ReceptorId)
            Notas = Notas & ", " & Usuarios.LeerUsuariosDescriptionByName(Receptor)
        End If
        t = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, "Se publica comentario en el muro de " & Notas & ": " & txtComentariosCriticos.Text)

        Url = "IndexSGI.aspx?PaginaWebName=Ficha de Tareas&Id=" & TareasId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url, True)

    End Sub
    ' Script para publicar alertas para todos los miembros del equipo
    Protected Sub RFC_Alerta(ByVal sender As Object, ByVal e As System.EventArgs) Handles AlertaButton.Click
        Dim t As Boolean
        Dim AccionesABM As New AccionesABM
        Dim NotasTransversales As New NotasTransversales
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim TareasId As Long = CLng(Request.QueryString("Id"))
        Dim CarpetaJudicialId As Long = Tareas.LeerCarpetaJudicialIdbyTareasId(TareasId)
        Dim UsuariosCodigo As String = ""
        Dim Notas As String = ""
        Dim Url As String = ""
        Dim Causa As String = ""

        t = Usuarios.LeerUsuariosCodigoByUsuariosId(Session("PersonaId"), UsuariosCodigo)

        CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)

        Causa = CarpetaJudicialCodigo & ": Scotiabank y " & CarpetaJudicial.LeerApellidosDeudorByTareasId(TareasId)

        Dim Supervisor As String = CarpetaJudicial.DevolverUsuarioPorRol("Supervisor", CarpetaJudicialCodigo)

        Dim SupervisorId As Long = 0

        t = Usuarios.LeerUsuariosByName(SupervisorId, Supervisor)

        Dim TareasEjecutor As String = ""
        Dim TareasLogRol As String = ""

        t = Tareas.LeerEjecutorRolByTareasId(TareasId, TareasEjecutor, TareasLogRol, TareasCodigo)

        t = NotasTransversales.NotasTransversalesInsertAlerta("De: " & Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo) & " A: " & Usuarios.LeerUsuariosDescriptionByName(Supervisor) & " por la causa " & Causa & ": Alerta de Fecha Cr&iacute;tica el d&iacute;a " & FormatDateTime(CDate(txtFechaCritica.Text), DateFormat.ShortDate) & " " & txtComentariosCriticos.Text, True, CDate(txtFechaCritica.Text), False, CDate(Now()), SupervisorId)
        Notas = Usuarios.LeerUsuariosDescriptionByName(Supervisor)

        t = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, "Se publica aviso de fecha crítica en el muro del Supervisor " & Notas & ": " & FormatDateTime(CDate(txtFechaCritica.Text), DateFormat.ShortDate) & " " & txtComentariosCriticos.Text)

        Url = "IndexSGI.aspx?PaginaWebName=Ficha de Tareas&Id=" & TareasId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url, True)
    End Sub

    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Request.QueryString("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim Acciones As New Acciones
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim AccionesId As Long = 0
        Dim AccionesCodigo As String = ""
        Dim AccionesName As String = ""
        Dim AccionesDescription As String = ""
        Dim RolName As String = ""
        Dim s As Integer = 0
        Dim CarpetaJudicialId As Long = 0
        Dim CarpetaJudicialCodigo As String = CStr(txtPGGCodigo.Text)
        Dim CarpetaJudicialRut As String = ""
        Dim UsuariosCodigo As String = ""
        Dim TareasId As Long = CLng(Request.QueryString("Id"))
        Dim FechaProximaTarea As Date
        Dim Dias As Double = 0
        Dim SeDebeEnviarCorreo As Boolean = False
        Dim TareasNotasFrom As String = ""
        Dim TareasNotasTo As String = ""
        Dim TareasNotasSubject As String = ""
        Dim Correo As String = ""
        Dim ConCopia As String = ""
        Dim Usuarios As New Usuarios

        Dim TareasCodigo As String = ""
        Dim TareasEjecutor As String = ""
        Dim TareasLogRol As String = ""

        Dim Secretaria As String = CarpetaJudicial.DevolverUsuarioPorRol("Secretaria", CarpetaJudicialCodigo)
        Dim Supervisor As String = CarpetaJudicial.DevolverUsuarioPorRol("Supervisor", CarpetaJudicialCodigo)
        Dim Procurador As String = CarpetaJudicial.DevolverUsuarioPorRol("Procurador", CarpetaJudicialCodigo)
        Dim Receptor As String = CarpetaJudicial.DevolverUsuarioPorRol("Receptor", CarpetaJudicialCodigo)

        Url = "IndexSGI.aspx?PaginaWebName=Busca Mis Tareas&Id=" & Session("PersonaId") & "&MenuOptionsId=422&UsuariosCodigo=" & Session("EMail")

        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas

        t = Tareas.LeerEjecutorRolByTareasId(TareasId, TareasEjecutor, TareasLogRol, TareasCodigo)

        'Aquí se llega cuando el usuario ha decidido dar por terminada la tarea y requiere generar 
        'la siguiente tarea de acuerdo a la post condicion resultante al finalizar la tarea actualmente 
        'en ejecución.

        'Lo primero es marcar la tarea como cerrada.
        'A continuación se crea la siguiente tarea de acuerdo con la post condición indicada por el usuario
        'Se actualiza la carpeta judicial con el nuevo estado

        'Marcar la tarea como cerrada

        t = Tareas.TareasUpdate(Request.QueryString("Id"), CStr(txtTareasCodigo.Text), CStr(txtTareasName.Text), CStr(txtTareasDescription.Text), CStr(txtPGGCodigo.Text), CStr(txtAccionesCodigo.Text), CLng(txtActividadesSecuencia.Text), CLng(txtTareasMes.Text), CStr(txtTareasAno.Text), CLng(txtTareasSecuencia.Text), CStr(txtUsuariosCodigo.Text), CDbl(txtTareasHH.Text * 100), CDbl(txtTareasUSD.Text * 100), CLng(txtDiaMinimoInicio.Text), CLng(txtDiaMaximoTermino.Text), CLng(txtTareasDiaProgramado.Text), CStr(txtTareasTipo.Text), CLng(txtTareasDiaRealTermino.Text), CDbl(txtTareasHHConsumidas.Text * 100), CDbl(txtTareasUSDConsumidos.Text * 100), "Cerrada", Session("PersonaId"))
        SeDebeEnviarCorreo = Acciones.SeDebeEnviarCorreo(CStr(txtAccionesCodigo.Text))
        TareasNotasSubject = CarpetaJudicialCodigo & ": Scotiabank  y " & CarpetaJudicial.LeerApellidosDeudorByTareasId(TareasId)

        'Ubicar la siguiente acción dada la post condición indicada en txtEstadoTareasCodigo en combinación con el código de la acción actual

        t = Acciones.LeerAccionSiguiente(CStr(txtAccionesCodigo.Text), CStr(txtEstadoTareasCodigo.Text), AccionesId, AccionesCodigo, AccionesName, AccionesDescription, RolName)
        ' Aquí voy a preguntar chanchamente si la siguiente acción es 02.06.16 y de ser así voy a poner el código
        ' para abrir el flujo en dos tareas paralelas.
        If SeDebeEnviarCorreo = True Then
            t = Usuarios.LeerUsuariosCodigoByUsuariosId(Session("PersonaId"), UsuariosCodigo)
            TareasNotasFrom = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)
            If RolName = "Procurador" Then
                TareasNotasTo = Usuarios.LeerUsuariosDescriptionByName(Procurador)
                Correo = Procurador
            End If
            If RolName = "Secretaria" Then
                TareasNotasTo = TareasNotasTo & ", " & Usuarios.LeerUsuariosDescriptionByName(Secretaria)
                Correo = Secretaria
            End If
            If RolName = "Supervisor" Then
                TareasNotasTo = TareasNotasTo & ", " & Usuarios.LeerUsuariosDescriptionByName(Supervisor)
                Correo = Supervisor
            End If
            If RolName = "Receptor" Then
                TareasNotasTo = TareasNotasTo & ", " & Usuarios.LeerUsuariosDescriptionByName(Receptor)
                Correo = Receptor
            End If

            ConCopia = ""
            t = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, "Se envia correo a " & Correo & ": " & CStr(txtEstadoTareasCodigo.Text))
            TareasNotasSubject = TareasNotasSubject & " - " & CStr(txtEstadoTareasCodigo.Text)
            t = AccionesABM.EnviarMensajeDemanda(TareasId, CarpetaJudicialId, CStr(txtEstadoTareasCodigo.Text), Secretaria, Procurador, Supervisor, Receptor, CarpetaJudicialCodigo, TareasNotasFrom, TareasNotasTo, Correo, TareasNotasSubject, ConCopia, Session("PersonaId"))
        End If
        CarpetaJudicialCodigo = CStr(txtPGGCodigo.Text)
        CarpetaJudicialId = CarpetaJudicial.LeerCarpetaJudicialIdByCodigo(CarpetaJudicialCodigo)
        CarpetaJudicialRut = CarpetaJudicial.LeerRutDeudorByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
        If AccionesCodigo = "02.06.16" Then  'Se abre el flujo
            'Crear Tarea para el flujo de apremios, que corresponde a la acción 02.06.12
            t = Acciones.LeerAccionesByName(AccionesId, "02.06.12")
            t = Acciones.LeerAccionesNameAndDescription(AccionesId, AccionesCodigo, AccionesName, AccionesDescription)
            RolName = Acciones.LeerRolPorAccion(AccionesCodigo)
            UsuariosCodigo = CarpetaJudicial.DevolverUsuarioPorRol(RolName, CarpetaJudicialCodigo)
            Dias = Acciones.LeerDurationPorAccion(AccionesCodigo)
            FechaProximaTarea = DateAdd(DateInterval.Day, Dias, Now())
            s = CarpetaJudicial.CrearTareas(CarpetaJudicialCodigo, AccionesCodigo, AccionesId, CarpetaJudicialId, CarpetaJudicialRut, FechaProximaTarea, AccionesName, UsuariosCodigo, 0, 0, TareasId, Session("PersonaId"))
            If s = 1 Then
                t = CarpetaJudicial.CarpetaJudicialTareasIdUpdate(CarpetaJudicialId, TareasId, CarpetaJudicialCodigo, AccionesName, Session("PersonaId"))
            End If
            'Crear Tarea para el flujo principal, que corresponde a la acción 02.06.17
            t = Acciones.LeerAccionesByName(AccionesId, "02.06.17")
            t = Acciones.LeerAccionesNameAndDescription(AccionesId, AccionesCodigo, AccionesName, AccionesDescription)
            RolName = Acciones.LeerRolPorAccion(AccionesCodigo)
            UsuariosCodigo = CarpetaJudicial.DevolverUsuarioPorRol(RolName, CarpetaJudicialCodigo)
            'Aquí debo incorporar cambios en el calculo de la fecha que dependen de la comuna en que fue notificado y la comuna en donde reside el tribunal en el que se
            'esta tramitando el juicio y también depende de la fecha de notificación.
            'El algoritmo indica que si el deudor fue requerido en la misma comuna de tribunal el deudor tiene 4 días para oponerse a la demanda y si el deudor es requerido
            'en una comuna distinta a la del tribunal el deudor tiene un plazo de 8 días para presentar oposición.  La fecha de vencimiento de la tarea es el plazo indicado
            'aplicando el algoritmo más 1 día.   
            'Este cambio lo implementare más adelante
            Dias = Acciones.LeerDurationPorAccion(AccionesCodigo)
            FechaProximaTarea = DateAdd(DateInterval.Day, Dias, Now())
            s = CarpetaJudicial.CrearTareas(CarpetaJudicialCodigo, AccionesCodigo, AccionesId, CarpetaJudicialId, CarpetaJudicialRut, FechaProximaTarea, AccionesName, UsuariosCodigo, 0, 0, TareasId, Session("PersonaId"))
            If s = 1 Then
                t = CarpetaJudicial.CarpetaJudicialTareasIdUpdate(CarpetaJudicialId, TareasId, CarpetaJudicialCodigo, AccionesName, Session("PersonaId"))
            End If

        Else

            UsuariosCodigo = CarpetaJudicial.DevolverUsuarioPorRol(RolName, CarpetaJudicialCodigo)
            Dias = Acciones.LeerDurationPorAccion(AccionesCodigo)
            FechaProximaTarea = DateAdd(DateInterval.Day, Dias, Now())

            s = CarpetaJudicial.CrearTareas(CarpetaJudicialCodigo, AccionesCodigo, AccionesId, CarpetaJudicialId, CarpetaJudicialRut, FechaProximaTarea, AccionesName, UsuariosCodigo, 0, 0, TareasId, Session("PersonaId"))
            If s = 1 Then
                t = CarpetaJudicial.CarpetaJudicialTareasIdUpdate(CarpetaJudicialId, TareasId, CarpetaJudicialCodigo, AccionesName, Session("PersonaId"))
            End If

        End If



        Response.Redirect(Url, True)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Tareas As New Tareas
        'Dim PGG As New PGG
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Acciones As New Acciones
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim Rol As New Rol
        Dim RolName As String = Rol.LeerRolNameByRolId(Session("RolId"))
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim PaginaWebName As String = ""
        Dim sSQLWhere As String = ""
        Dim sSQLOrder As String = ""
        Dim sSQL As String = ""
        Dim CarpetaJudicialCodigo As String

        Dim PaginaWeb As New PaginaWeb
        Dim MenuOptions As New MenuOptions
        Dim PaginaWebUserControl As String = ""

        Dim VistaWeb As String = ""

        'Ficha de ComentariosCorreosMuroAlerta

        'Aquí se pinta el formulario fijo que permite registrar comentarios de avance, enviar correos, 
        'publicar en el muro y por último publicar alertas de tipo general, estas últimas quedan asociadas al
        'supervisor quien es el único que las puede eliminar del muro.

        t = Lecturas.LeerPaginaWeb("Ficha de ComentariosCorreosMuroAlerta", TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Call Lecturas.CrearVista(NumeroPagina, TituloPagina, MisComentarios, NewUpdateButton, MailButton, CommentButton, MuroButton, AlertaButton)
        AddHandler CommentButton.Click, AddressOf RFC_Comment
        AddHandler MailButton.Click, AddressOf RFC_Mail
        AddHandler MuroButton.Click, AddressOf RFC_Muro
        AddHandler AlertaButton.Click, AddressOf RFC_Alerta

        'Aquí se pinta el formulario variable dependiendo de la acción a ejecutar dentro de la tarea.
        'A partir del Id de la tarea, se obtiene la acción y de allí la página web a leer

        t = Lecturas.LeerPaginaWeb(Acciones.LeerPaginaWebByTareaId(CLng(Request.QueryString("Id"))), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        If NumeroPagina <> 0 Then
            Call Lecturas.CrearVista(NumeroPagina, TituloPagina, MyTask, NewUpdateButton, MailButton, CommentButton, MuroButton, AlertaButton)
            AddHandler NewUpdateButton.Click, AddressOf RFC_UpdateNew
            Select Case Acciones.LeerPaginaWebByTareaId(CLng(Request.QueryString("Id")))
                Case "Ficha de DemandaFirmada"
                    NewUpdateButton.Visible = False
                Case "Ficha de Solicitar44"
                    NewUpdateButton.Visible = False
            End Select
        End If


        t = Tareas.LeerTareasCodigoById(CLng(Request.QueryString("Id")), TareasCodigo)
        TareasName = Tareas.LeerTareasDescriptionByName(TareasCodigo)
        CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("Id"))))
        MyActivities.Controls.Add(New LiteralControl(Acciones.ListarActividadesPorTareasId(CLng(Request.QueryString("Id")), TareasName)))
        MyDeudor.Controls.Add(New LiteralControl(Tareas.ListarDatosDelDeudorPorTareasId(CLng(Request.QueryString("Id")), CarpetaJudicialCodigo)))

        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler SearchButton.Click, AddressOf RFC_Search
        AddHandler DeleteButton.Click, AddressOf RFC_Delete
        AddHandler CancelButton.Click, AddressOf RFC_Logout
        NewButton.Visible = False
        SearchButton.Visible = False
        DeleteButton.Visible = False
        'CancelButton.Visible = False

        If Not IsPostBack Then
            If Request.QueryString("Id") <> 0 Then
                If t = Tareas.LeerTareas(Request.QueryString("Id"), TareasCodigo, TareasName, TareasDescription, PGGCodigo, AccionesCodigo, ActividadesSecuencia, TareasMes, TareasAno, TareasSecuencia, UsuariosCodigo, TareasHH, TareasUSD, DiaMinimoInicio, DiaMaximoTermino, TareasDiaProgramado, TareasTipo, TareasDiaRealTermino, TareasHHConsumidas, TareasUSDConsumidos, EstadoTareasCodigo) Then
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = TareasCodigo
                    txtTareasCodigo.ToolTip = CarpetaJudicial.LeerToolTipTareaByCarpetaJudicialCodigo(PGGCodigo)
                    txtTareasName = FindControl("txtTareasName")
                    txtTareasName.Text = TareasName
                    txtTareasDescription = FindControl("txtTareasDescription")
                    txtTareasDescription.Text = TareasDescription
                    txtPGGCodigo = FindControl("txtPGGCodigo")
                    txtPGGCodigo.Text = PGGCodigo
                    'txtPGGCodigoDescription = FindControl("txtPGGCodigoDescription")
                    'txtPGGCodigoDescription.Text = PGG.LeerPGGDescriptionByName(PGGCodigo) 'A este ya lo adapte para leer desde la tabla Programas
                    txtAccionesCodigo = FindControl("txtAccionesCodigo")
                    txtAccionesCodigo.Text = AccionesCodigo
                    txtTareasName.ToolTip = Acciones.LeerToolTipAccion(AccionesCodigo)
                    'txtAccionesCodigoDescription = FindControl("txtAccionesCodigoDescription")
                    'txtAccionesCodigoDescription.Text = Acciones.LeerAccionesDescriptionByName(AccionesCodigo)
                    txtActividadesSecuencia = FindControl("txtActividadesSecuencia")
                    txtActividadesSecuencia.Text = ActividadesSecuencia
                    txtTareasMes = FindControl("txtTareasMes")
                    txtTareasMes.Text = TareasMes
                    txtTareasAno = FindControl("txtTareasAno")
                    txtTareasAno.Text = TareasAno
                    txtTareasSecuencia = FindControl("txtTareasSecuencia")
                    txtTareasSecuencia.Text = TareasSecuencia
                    txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
                    txtUsuariosCodigo.Text = UsuariosCodigo
                    'txtUsuariosCodigoDescription = FindControl("txtUsuariosCodigoDescription")
                    'txtUsuariosCodigoDescription.Text = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)
                    txtTareasHH = FindControl("txtTareasHH")
                    txtTareasHH.Text = TareasHH
                    txtTareasHH.Text = FormatNumber(TareasHH / 100, 0)
                    txtTareasUSD = FindControl("txtTareasUSD")
                    txtTareasUSD.Text = TareasUSD
                    txtTareasUSD.Text = FormatCurrency(TareasUSD / 100, 0)
                    txtDiaMinimoInicio = FindControl("txtDiaMinimoInicio")
                    txtDiaMinimoInicio.Text = DiaMinimoInicio
                    txtDiaMaximoTermino = FindControl("txtDiaMaximoTermino")
                    txtDiaMaximoTermino.Text = DiaMaximoTermino
                    txtTareasDiaProgramado = FindControl("txtTareasDiaProgramado")
                    txtTareasDiaProgramado.Text = TareasDiaProgramado
                    txtTareasTipo = FindControl("txtTareasTipo")
                    txtTareasTipo.Text = TareasTipo
                    txtTareasDiaRealTermino = FindControl("txtTareasDiaRealTermino")
                    txtTareasDiaRealTermino.Text = TareasDiaRealTermino
                    txtTareasHHConsumidas = FindControl("txtTareasHHConsumidas")
                    txtTareasHHConsumidas.Text = TareasHHConsumidas
                    txtTareasHHConsumidas.Text = FormatNumber(TareasHHConsumidas / 100, 0)
                    txtTareasUSDConsumidos = FindControl("txtTareasUSDConsumidos")
                    txtTareasUSDConsumidos.Text = TareasUSDConsumidos
                    txtTareasUSDConsumidos.Text = FormatCurrency(TareasUSDConsumidos / 100, 0)
                    txtEstadoTareasCodigo = FindControl("txtEstadoTareasCodigo")
                    'txtEstadoTareasCodigo.Text = EstadoTareasCodigo

                    'sSQL = "Select EstadoTareas_1.EstadoTareasName As EstadoTareasCodigo "
                    'sSQL = sSQL & "FROM (EstadoTareas INNER JOIN TransicionEstadoTareas ON EstadoTareas.EstadoTareasId = TransicionEstadoTareas.CurrentStateId) INNER JOIN EstadoTareas AS EstadoTareas_1 ON TransicionEstadoTareas.NextStateId = EstadoTareas_1.EstadoTareasId "
                    'sSQL = sSQL & "WHERE (((EstadoTareas.EstadoTareasName)= '" & EstadoTareasCodigo & "'))"

                    sSQL = "Select TransicionAcciones.EstadoProcesoCodigo As EstadoTareasCodigo "
                    sSQL = sSQL & "FROM TransicionAcciones INNER JOIN Acciones ON TransicionAcciones.CurrentStateId = Acciones.AccionesId "
                    sSQL = sSQL & "WHERE Acciones.AccionesCodigo = '" & AccionesCodigo & "'"


                    sqlSource = FindControl("dstxtEstadoTareasCodigo")
                    sqlSource.SelectCommand = sSQL

                    txtEstadoTareasCodigoDescription = FindControl("txtEstadoTareasCodigoDescription")
                    'txtEstadoTareasCodigoDescription.Text = EstadoTareas.LeerEstadoTareasDescriptionByName(EstadoTareasCodigo)
                    ' Aquí colocare código para invocar uso de las tabs

                    'ctlControl = LoadControl("Vinculos.ascx")
                    'PlaceHolder1.Controls.Add(ctlControl)

                    'If Lecturas.PageUserControl(Acciones.LeerPaginaWeb(AccionesCodigo), PaginaWebUserControl) Then
                    'ctlControl = LoadControl(PaginaWebUserControl)
                    'MyTask.Controls.Add(ctlControl)
                    'End If

                    txtComentariosCriticos = FindControl("txtComentariosCriticos")
                    txtFechaCritica = FindControl("txtFechaCritica")
                    txtFechaCritica.text = FormatDateTime(Now(), DateFormat.ShortDate)
                    chkProcurador = FindControl("chkProcurador")
                    chkSupervisor = FindControl("chkSupervisor")
                    chkSecretaria = FindControl("chkSecretaria")
                    chkReceptor = FindControl("chkReceptor")

                    VistaWeb = Acciones.LeerPaginaWeb(AccionesCodigo)
                    Select Case VistaWeb
                        Case "Ficha de Comentarios"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            txtComentarios = FindControl("txtComentarios")
                        Case "Ficha de DatosPersonales"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            t = Tareas.LeerIdentificacionDeudorbyTareasId(Request.QueryString("Id"), Rut, Nombres, Apellidos)
                            'txtComentarios = FindControl("txtComentarios")
                            'txtComentarios.Text = ""
                            txtRut = FindControl("txtRut")
                            txtRut.Text = Rut
                            txtNombres = FindControl("txtNombres")
                            txtNombres.Text = Nombres
                            txtApellidos = FindControl("txtApellidos")
                            txtApellidos.Text = Apellidos
                        Case "Ficha de AsignaProcurador"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            t = Tareas.LeerProcuradorbyTareasId(Request.QueryString("Id"), Procurador)
                            txtComentarios = FindControl("txtComentarios")
                            txtComentarios.Text = ""
                            txtRut = FindControl("txtProcurador")
                            txtRut.Text = Procurador
                        Case "Ficha de MasAntecedentes"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            t = Tareas.LeerMasAntecedentesbyTareasId(Request.QueryString("Id"), Profesion)
                            txtComentarios = FindControl("txtComentarios")
                            txtComentarios.Text = Comentarios
                            txtProfesion = FindControl("txtProfesion")
                            txtEstadoCivil = FindControl("txtEstadoCivil")
                            txtFechaEscritura = FindControl("txtFechaEscritura")
                            txtCiudadEscritura = FindControl("txtCiudadEscritura")
                            txtNotarioEscritura = FindControl("txtNotarioEscritura")
                            txtMontoUF = FindControl("txtMontoUF")
                            txtMesesPlazo = FindControl("txtMesesPlazo")
                            txtFechaInicio = FindControl("txtFechaInicio")
                            txtDeudaCapitalUF = FindControl("txtDeudaCapitalUF")
                            txtDeudaCapitalPesos = FindControl("txtDeudaCapitalPesos")
                            txtDeudaDividendosUF = FindControl("txtDeudaDividendosUF")
                            txtDeudaDividendosPesos = FindControl("txtDeudaDividendosPesos")
                            txtInmuebleFojas = FindControl("txtInmuebleFojas")
                            txtInmuebleNumero = FindControl("txtInmuebleNumero")
                            txtInmuebleAno = FindControl("txtInmuebleAno")
                            txtInmuebleCiudad = FindControl("txtInmuebleCiudad")
                            txtHipotecaFojas = FindControl("txtHipotecaFojas")
                            txtHipotecaNumero = FindControl("txtHipotecaNumero")
                            txtHipotecaAno = FindControl("txtHipotecaAno")
                            txtHipotecaCiudad = FindControl("txtHipotecaCiudad")
                            txtTasaInteresAnual = FindControl("txtTasaInteresAnual")
                            txtProfesion.Text = Profesion
                            txtEstadoCivil.Text = EstadoCivil
                            txtFechaEscritura.Text = FechaEscritura
                            txtCiudadEscritura.Text = CiudadEscritura
                            txtNotarioEscritura.Text = NotarioEscritura
                            txtMontoUF.Text = FormatNumber(MontoUF / 100, 0)
                            txtMesesPlazo.Text = MesesPlazo
                            txtFechaInicio.Text = FechaInicio
                            txtDeudaCapitalUF.Text = FormatNumber(DeudaCapitalUF / 100, 0)
                            txtDeudaCapitalPesos.Text = FormatNumber(DeudaCapitalPesos / 100, 0)
                            txtDeudaDividendosUF.Text = FormatNumber(DeudaDividendosUF / 100, 0)
                            txtDeudaDividendosPesos.Text = FormatNumber(DeudaDividendosPesos / 100, 0)
                            txtTasaInteresAnual.Text = FormatNumber(TasaInteresAnual / 100, 2)
                            txtInmuebleFojas.Text = InmuebleFojas
                            txtInmuebleNumero.Text = InmuebleNumero
                            txtInmuebleAno.Text = InmuebleAno
                            txtInmuebleCiudad.Text = InmuebleCiudad
                            txtHipotecaFojas.Text = HipotecaFojas
                            txtHipotecaNumero.Text = HipotecaNumero
                            txtHipotecaAno.Text = HipotecaAno
                            txtHipotecaCiudad.Text = HipotecaCiudad
                            ' Se agregan manualmente para manejar el evento RFC_Save
                            UploadLink = FindControl("lnkFile")
                            'UploadLink.NavigateUrl = "ReportesPGG.aspx?PaginaWebName=Plantilla Demanda&Id=" & Request.QueryString("Id")
                            UploadLink.NavigateUrl = "DemandaJuicioEjecutivoEnWord.aspx?Id=" & Request.QueryString("Id")
                            UploadLink.Target = "_blank"
                            'UploadLink2 = FindControl("lnkFile2")
                            'UploadLink2.NavigateUrl = "ReportesPGG.aspx?PaginaWebName=Plantilla Precautoria&Id=" & Request.QueryString("Id")
                            'UploadLink2.Target = "_blank"
                        Case "Ficha de JuzgadoRol"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            t = Tareas.LeerJuzgadoRolbyTareasId(Request.QueryString("Id"), RolJuicio, FechaDistribucion, Juzgado)
                            txtRolJuicio = FindControl("txtRolJuicio")
                            txtRolJuicio.Text = RolJuicio
                            txtFechaDistribucion = FindControl("txtFechaDistribucion")
                            txtFechaDistribucion.Text = FechaDistribucion
                            txtJuzgado = FindControl("txtJuzgado")
                            txtJuzgado.Text = Juzgado
                        Case "Ficha de FechaPresentacion"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            t = Tareas.LeerFechaPresentacionbyTareasId(Request.QueryString("Id"), FechaPresentacion)
                            txtFechaPresentacion = FindControl("txtFechaPresentacion")
                            txtFechaPresentacion.Text = FechaPresentacion
                        Case "Ficha de DemandaFirmada"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            UploadLink = FindControl("lnkFile")
                            UploadLink.NavigateUrl = "ReportesPGG.aspx?PaginaWebName=Plantilla Demanda&Id=" & Request.QueryString("Id")
                            UploadLink.Target = "_blank"
                        Case "Ficha de Notificacion"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            t = Tareas.LeerFechaNotificacionbyTareasId(Request.QueryString("Id"), FechaNotificacion, ComunaNotificacion)
                            txtFechaNotificacion = FindControl("txtFechaNotificacion")
                            txtFechaNotificacion.Text = FechaNotificacion
                            txtComunaNotificacion = FindControl("txtComunaNotificacion")
                            txtComunaNotificacion.Text = ComunaNotificacion
                            ' Se agregan manualmente para manejar el evento RFC_Save
                            UploadLink = FindControl("lnkFile")
                            UploadLink.NavigateUrl = "ReportesPGG.aspx?PaginaWebName=Plantilla Demanda&Id=" & Request.QueryString("Id")
                            UploadLink.Target = "_blank"
                            UploadLink2 = FindControl("lnkFile2")
                            UploadLink2.NavigateUrl = "ReportesPGG.aspx?PaginaWebName=Plantilla Precautoria&Id=" & Request.QueryString("Id")
                            UploadLink2.Target = "_blank"
                        Case "Ficha de Solicitar44"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            UploadLink = FindControl("lnkFile")
                            UploadLink.NavigateUrl = "ReportesPGG.aspx?PaginaWebName=Plantilla Articulo44&Id=" & Request.QueryString("Id")
                            UploadLink.Target = "_blank"
                        Case "Ficha de Notificacion44"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            t = Tareas.LeerFechaNotificacionbyTareasId(Request.QueryString("Id"), FechaNotificacion, ComunaNotificacion)
                            txtFechaNotificacion = FindControl("txtFechaNotificacion")
                            txtFechaNotificacion.Text = FechaNotificacion
                            txtComunaNotificacion = FindControl("txtComunaNotificacion")
                            txtComunaNotificacion.Text = ComunaNotificacion
                            ' Se agregan manualmente para manejar el evento RFC_Save
                            UploadLink = FindControl("lnkFile")
                            UploadLink.NavigateUrl = "ReportesPGG.aspx?PaginaWebName=Plantilla Demanda&Id=" & Request.QueryString("Id")
                            UploadLink.Target = "_blank"
                            UploadLink2 = FindControl("lnkFile2")
                            UploadLink2.NavigateUrl = "ReportesPGG.aspx?PaginaWebName=Plantilla Precautoria&Id=" & Request.QueryString("Id")
                            UploadLink2.Target = "_blank"
                    End Select
                    sSQLWhere = ""
                    sSQLOrder = ""
                    Call Lecturas.CreateTabs(NumeroPagina, TareasCodigo, Request.QueryString("Id"), MyTabs, "TareasCodigo", sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"), Request.QueryString("Id"), "Tareas", Session("PersonaId"))

                Else
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = Session("TareasCodigo")
                End If
            End If
        Else
            txtTareasCodigo = FindControl("txtTareasCodigo")
            txtTareasName = FindControl("txtTareasName")
            txtTareasDescription = FindControl("txtTareasDescription")
            txtPGGCodigo = FindControl("txtPGGCodigo")
            txtAccionesCodigo = FindControl("txtAccionesCodigo")
            txtActividadesSecuencia = FindControl("txtActividadesSecuencia")
            txtTareasMes = FindControl("txtTareasMes")
            txtTareasAno = FindControl("txtTareasAno")
            txtTareasSecuencia = FindControl("txtTareasSecuencia")
            txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
            txtTareasHH = FindControl("txtTareasHH")
            txtTareasUSD = FindControl("txtTareasUSD")
            txtDiaMinimoInicio = FindControl("txtDiaMinimoInicio")
            txtDiaMaximoTermino = FindControl("txtDiaMaximoTermino")
            txtTareasDiaProgramado = FindControl("txtTareasDiaProgramado")
            txtTareasTipo = FindControl("txtTareasTipo")
            txtTareasDiaRealTermino = FindControl("txtTareasDiaRealTermino")
            txtTareasHHConsumidas = FindControl("txtTareasHHConsumidas")
            txtTareasUSDConsumidos = FindControl("txtTareasUSDConsumidos")
            txtEstadoTareasCodigo = FindControl("txtEstadoTareasCodigo")

            txtComentariosCriticos = FindControl("txtComentariosCriticos")
            txtFechaCritica = FindControl("txtFechaCritica")
            chkProcurador = FindControl("chkProcurador")
            chkSupervisor = FindControl("chkSupervisor")
            chkSecretaria = FindControl("chkSecretaria")
            chkReceptor = FindControl("chkReceptor")

            VistaWeb = Acciones.LeerPaginaWeb(txtAccionesCodigo.Text)
            Select Case VistaWeb
                Case "Ficha de Comentarios"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtComentarios = FindControl("txtComentarios")
                Case "Ficha de DatosPersonales"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    'txtComentarios = FindControl("txtComentarios")
                    txtRut = FindControl("txtRut")
                    txtNombres = FindControl("txtNombres")
                    txtApellidos = FindControl("txtApellidos")
                Case "Ficha de AsignaProcurador"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtComentarios = FindControl("txtComentarios")
                    txtProcurador = FindControl("txtProcurador")
                Case "Ficha de MasAntecedentes"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtComentarios = FindControl("txtComentarios")
                    txtProfesion = FindControl("txtProfesion")
                    txtEstadoCivil = FindControl("txtEstadoCivil")
                    txtFechaEscritura = FindControl("txtFechaEscritura")
                    txtCiudadEscritura = FindControl("txtCiudadEscritura")
                    txtNotarioEscritura = FindControl("txtNotarioEscritura")
                    txtMontoUF = FindControl("txtMontoUF")
                    txtMesesPlazo = FindControl("txtMesesPlazo")
                    txtFechaInicio = FindControl("txtFechaInicio")
                    txtDeudaCapitalUF = FindControl("txtDeudaCapitalUF")
                    txtDeudaCapitalPesos = FindControl("txtDeudaCapitalPesos")
                    txtDeudaDividendosUF = FindControl("txtDeudaDividendosUF")
                    txtDeudaDividendosPesos = FindControl("txtDeudaDividendosPesos")
                    txtInmuebleFojas = FindControl("txtInmuebleFojas")
                    txtInmuebleNumero = FindControl("txtInmuebleNumero")
                    txtInmuebleAno = FindControl("txtInmuebleAno")
                    txtInmuebleCiudad = FindControl("txtInmuebleCiudad")
                    txtHipotecaFojas = FindControl("txtHipotecaFojas")
                    txtHipotecaNumero = FindControl("txtHipotecaNumero")
                    txtHipotecaAno = FindControl("txtHipotecaAno")
                    txtHipotecaCiudad = FindControl("txtHipotecaCiudad")
                    txtTasaInteresAnual = FindControl("txtTasaInteresAnual")
                    ' Se agregan manualmente para manejar el evento RFC_Save
                    UploadLink = FindControl("lnkFile")
                    'UploadLink2 = FindControl("lnkFile2")
                Case "Ficha de JuzgadoRol"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtRolJuicio = FindControl("txtRolJuicio")
                    txtFechaDistribucion = FindControl("txtFechaDistribucion")
                    txtJuzgado = FindControl("txtJuzgado")
                Case "Ficha de FechaPresentacion"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtFechaPresentacion = FindControl("txtFechaPresentacion")
                Case "Ficha de DemandaFirmada"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    UploadLink = FindControl("lnkFile")
                Case "Ficha de Notificacion"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtFechaNotificacion = FindControl("txtFechaNotificacion")
                    txtComunaNotificacion = FindControl("txtComunaNotificacion")
                    ' Se agregan manualmente para manejar el evento RFC_Save
                    UploadLink = FindControl("lnkFile")
                    UploadLink2 = FindControl("lnkFile2")
                Case "Ficha de Solicitar44"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    UploadLink = FindControl("lnkFile")
                Case "Ficha de Notificacion44"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtFechaNotificacion = FindControl("txtFechaNotificacion")
                    txtComunaNotificacion = FindControl("txtComunaNotificacion")
                    ' Se agregan manualmente para manejar el evento RFC_Save
                    UploadLink = FindControl("lnkFile")
                    UploadLink2 = FindControl("lnkFile2")
            End Select


            sSQLWhere = ""
            sSQLOrder = ""
            Call Lecturas.CreateTabs(NumeroPagina, txtTareasCodigo.Text, Request.QueryString("Id"), MyTabs, "TareasCodigo", sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"), Request.QueryString("Id"), "Tareas", Session("PersonaId"))


        End If
    End Sub
End Class
