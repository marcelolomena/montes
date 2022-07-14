Imports AjaxControlToolkit
Partial Class GestionUpdateTareas
    Inherits System.Web.UI.Page
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 24-04-2011 8:52:50
    '------------------------------------------------------------
    ' Declaración de Variables de la Aplicación
    '------------------------------------------
    Dim Logo As String = ""
    Dim BarMenu As String = ""
    Dim SideBarMenu As String = ""
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
    ' Declaración de Controles del Formulario 2
    '----------------------------------------
    Dim txtComentarios As TextBox ' Etiqueta : Código Provincia - Control : txtProvinciasCodigo - Variable : ProvinciasCodigo
    Dim txtRut As TextBox
    Dim txtNombres As TextBox
    Dim txtApellidos As TextBox
    Dim txtProcurador As TextBox
    Dim txtProfesion As TextBox
    Dim txtRolJuicio As TextBox
    Dim txtFechaDistribucion As TextBox
    Dim txtJuzgado As TextBox
    Dim txtFechaPresentacion As TextBox
    Dim txtFechaNotificacion As TextBox
    Dim txtComunaNotificacion As TextBox
    '----------------------------------------
    ' Declaración de Campos de la Aplicación 2
    '----------------------------------------
    Dim Rut As String
    Dim Nombres As String
    Dim Apellidos As String
    Dim Procurador As String
    Dim Profesion As String
    Dim RolJuicio As String
    Dim FechaDistribucion As Date
    Dim Juzgado As String
    Dim FechaPresentacion As Date
    Dim FechaNotificacion As Date
    Dim ComunaNotificacion As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim TareasCodigo As String = ""
        Dim UsuariosCodigo As String = ""
        Dim t As Boolean = True
        Dim s As Integer = 0
        'Dim CarpetaJudicialId As Long = CLng(Request.QueryString("Id"))
        'Dim CarpetaJudicialCodigo As String = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
        'Dim TareasId As Long = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
        Dim TareasId As Long = CLng(Request.QueryString("TareasId"))
        Dim CarpetaJudicialCodigo As String = Tareas.LeerTareasPGGCodigoById(TareasId)
        Dim CarpetaJudicialId As Long = CarpetaJudicial.LeerCarpetaJudicialIdByCodigo(CarpetaJudicialCodigo)

        Dim Acciones As New Acciones
        Dim EstadoTareas As New EstadoTareas
        Dim Rol As New Rol
        Dim RolName As String = Rol.LeerRolNameByRolId(Session("RolId"))
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim PaginaWebName As String = ""

        Dim PaginaWeb As New PaginaWeb
        Dim MenuOptions As New MenuOptions
        Dim PaginaWebUserControl As String = ""

        Dim VistaWeb As String = ""


        Dim CodigoHTML As String = "<p><h1>" & CarpetaJudicialCodigo & ": " & UCase(CarpetaJudicial.LeerApellidosDeudorByTareasId(TareasId)) & " CON SCOTIABANK </h1></p>"

        MyDeudor.Controls.Add(New LiteralControl(CodigoHTML))

        MyResponsable.Controls.Add(New LiteralControl(Tareas.ListarDatosDelResponsablePorTareasId(TareasId)))


        'Aquí se pinta el formulario variable dependiendo de la acción a ejecutar dentro de la tarea.
        'A partir del Id de la tarea, se obtiene la acción y de allí la página web a leer

        t = Lecturas.LeerPaginaWeb(Acciones.LeerPaginaWebByTareaId(TareasId), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        If NumeroPagina <> 0 Then
            Call Lecturas.CrearNewVista(NumeroPagina, TituloPagina, MyTask)
        End If

        t = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)
        TareasName = Tareas.LeerTareasDescriptionByName(TareasCodigo)

        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina

        If Not IsPostBack Then
            If TareasId <> 0 Then
                If t = Tareas.LeerTareas(TareasId, TareasCodigo, TareasName, TareasDescription, PGGCodigo, AccionesCodigo, ActividadesSecuencia, TareasMes, TareasAno, TareasSecuencia, UsuariosCodigo, TareasHH, TareasUSD, DiaMinimoInicio, DiaMaximoTermino, TareasDiaProgramado, TareasTipo, TareasDiaRealTermino, TareasHHConsumidas, TareasUSDConsumidos, EstadoTareasCodigo) Then
                    txtTareasCodigo.Text = TareasCodigo
                    txtTareasCodigo.ToolTip = CarpetaJudicial.LeerToolTipTareaByCarpetaJudicialCodigo(PGGCodigo)

                    txtAccionesCodigo.Text = AccionesCodigo
                    txtUsuariosCodigo.Text = UsuariosCodigo
                    txtEstadoTareasCodigo.Text = EstadoTareasCodigo

                    VistaWeb = Acciones.LeerPaginaWeb(AccionesCodigo)
                    Select Case VistaWeb
                        Case "Ficha de Comentarios"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            txtComentarios = FindControl("txtComentarios")
                        Case "Ficha de DatosPersonales"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            t = Tareas.LeerIdentificacionDeudorbyTareasId(TareasId, Rut, Nombres, Apellidos)
                            txtRut = FindControl("txtRut")
                            txtRut.Text = Rut
                            txtNombres = FindControl("txtNombres")
                            txtNombres.Text = Nombres
                            txtApellidos = FindControl("txtApellidos")
                            txtApellidos.Text = Apellidos
                        Case "Ficha de AsignaProcurador"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            t = Tareas.LeerProcuradorbyTareasId(TareasId, Procurador)
                            txtComentarios = FindControl("txtComentarios")
                            txtComentarios.Text = ""
                            txtRut = FindControl("txtProcurador")
                            txtRut.Text = Procurador
                        Case "Ficha de MasAntecedentes"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            t = Tareas.LeerMasAntecedentesbyTareasId(TareasId, Profesion)
                            txtProfesion = FindControl("txtProfesion")
                            txtProfesion.Text = Profesion
                        Case "Ficha de JuzgadoRol"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            t = Tareas.LeerJuzgadoRolbyTareasId(TareasId, RolJuicio, FechaDistribucion, Juzgado)
                            txtRolJuicio = FindControl("txtRolJuicio")
                            txtRolJuicio.Text = RolJuicio
                            txtFechaDistribucion = FindControl("txtFechaDistribucion")
                            txtFechaDistribucion.Text = FechaDistribucion
                            txtJuzgado = FindControl("txtJuzgado")
                            txtJuzgado.Text = Juzgado
                        Case "Ficha de FechaPresentacion"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            t = Tareas.LeerFechaPresentacionbyTareasId(TareasId, FechaPresentacion)
                            txtFechaPresentacion = FindControl("txtFechaPresentacion")
                            txtFechaPresentacion.Text = FechaPresentacion
                        Case "Ficha de Notificacion"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            t = Tareas.LeerFechaNotificacionbyTareasId(TareasId, FechaNotificacion, ComunaNotificacion)
                            txtFechaNotificacion = FindControl("txtFechaNotificacion")
                            txtFechaNotificacion.Text = FechaNotificacion
                            txtComunaNotificacion = FindControl("txtComunaNotificacion")
                            txtComunaNotificacion.Text = ComunaNotificacion
                        Case "Ficha de Notificacion44"  ' Se instancian los controles dependiendo de la acción a ejecutar
                            t = Tareas.LeerFechaNotificacionbyTareasId(TareasId, FechaNotificacion, ComunaNotificacion)
                            txtFechaNotificacion = FindControl("txtFechaNotificacion")
                            txtFechaNotificacion.Text = FechaNotificacion
                            txtComunaNotificacion = FindControl("txtComunaNotificacion")
                            txtComunaNotificacion.Text = ComunaNotificacion
                    End Select
                Else
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = Session("TareasCodigo")
                End If
            End If
        Else
            VistaWeb = Acciones.LeerPaginaWeb(txtAccionesCodigo.Text)
            Select Case VistaWeb
                Case "Ficha de Comentarios"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtComentarios = FindControl("txtComentarios")
                Case "Ficha de DatosPersonales"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtRut = FindControl("txtRut")
                    txtNombres = FindControl("txtNombres")
                    txtApellidos = FindControl("txtApellidos")
                Case "Ficha de AsignaProcurador"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtComentarios = FindControl("txtComentarios")
                    txtProcurador = FindControl("txtProcurador")
                Case "Ficha de MasAntecedentes"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtProfesion = FindControl("txtProfesion")
                Case "Ficha de JuzgadoRol"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtRolJuicio = FindControl("txtRolJuicio")
                    txtFechaDistribucion = FindControl("txtFechaDistribucion")
                    txtJuzgado = FindControl("txtJuzgado")
                Case "Ficha de FechaPresentacion"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtFechaPresentacion = FindControl("txtFechaPresentacion")
                Case "Ficha de Notificacion"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtFechaNotificacion = FindControl("txtFechaNotificacion")
                    txtComunaNotificacion = FindControl("txtComunaNotificacion")
                Case "Ficha de Notificacion44"  ' Se instancian los controles dependiendo de la acción a ejecutar
                    txtFechaNotificacion = FindControl("txtFechaNotificacion")
                    txtComunaNotificacion = FindControl("txtComunaNotificacion")
            End Select
        End If

    End Sub
End Class
