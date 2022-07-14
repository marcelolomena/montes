Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class SimpleService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function DescriptorCodigo(ByVal Codigo As String, ByVal Tabla As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        Select Case Tabla
            Case "Roles"
                sSQL = "Select " & Tabla & ".RolDescription As Nombre From " & Tabla & " Where " & Tabla & ".RolName = '" & Codigo & "'"
            Case "DocumentosSGI"
                sSQL = "Select " & Tabla & "." & Tabla & "Nombre As Nombre From " & Tabla & " Where " & Tabla & "." & Tabla & "Codigo = '" & Codigo & "'"
            Case "TipoDoc", "Areas", "Roles", "EstadoTareas", "ZonaGeografica", "ClaseProceso"
                sSQL = "Select " & Tabla & "." & Tabla & "Description As Nombre From " & Tabla & " Where " & Tabla & "." & Tabla & "Name = '" & Codigo & "'"
            Case "PaginaWeb"
                sSQL = "Select " & Tabla & "." & Tabla & "Title As Nombre From " & Tabla & " Where " & Tabla & "." & Tabla & "Name = '" & Codigo & "'"
            Case Else
                sSQL = "Select " & Tabla & "." & Tabla & "Name As Nombre From " & Tabla & " Where " & Tabla & "." & Tabla & "Codigo = '" & Codigo & "'"
        End Select
        DescriptorCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                DescriptorCodigo = CStr(dtr("Nombre").ToString)
            End While
            dtr.Close()
        Catch
            DescriptorCodigo = ""
        End Try

    End Function
    <WebMethod()> _
    Public Function DescriptorNombre(ByVal Name As String, ByVal Tabla As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select " & Tabla & "." & Tabla & "Codigo As Codigo From " & Tabla & " Where " & Tabla & "." & Tabla & "Name = '" & Name & "'"
        DescriptorNombre = ""
        'Return "Código no existe en la lista de " & Tabla
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                DescriptorNombre = CStr(dtr("Codigo").ToString)
            End While
            dtr.Close()
        Catch
            DescriptorNombre = "No existe"
        End Try

    End Function

    <WebMethod()> _
    Public Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim DocumentosSGI As New DocumentosSGI
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim arrLabel(100) As String

        If DocumentosSGI.LeerTituloParaAutocomplete(arrLabel, prefixText, i) Then

            'If DocumentosSGI.LeerPalabrasClavesParaBusqueda(arrLabel, prefixText, i) Then
            Dim items As New List(Of String)
            If i <> 0 Then
                For j = 0 To i - 1
                    items.Add(arrLabel(j))
                Next j

                Return items.ToArray()
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

    End Function
    <WebMethod()> _
    Public Function UpdateRequisito(ByVal MenuOptionsId As Long, ByVal Descripcion As String, ByVal UserId As Long) As Integer
        Dim MenuOptions As New MenuOptions

        UpdateRequisito = MenuOptions.UpdateDescripcionRequisito(MenuOptionsId, Descripcion, UserId)
    End Function
    <WebMethod()> _
    Public Function UpdateNota(ByVal Descripcion As String, ByVal UserId As Long) As String
        Dim NotasTransversales As New NotasTransversales
        Dim AccionesABM As New AccionesABM

        UpdateNota = NotasTransversales.InsertarNotaTransversal(Descripcion, UserId)

    End Function
    <WebMethod()> _
    Public Function DeleteNota(ByVal Id As Long, ByVal UserId As Long) As String
        Dim NotasTransversales As New NotasTransversales
        Dim AccionesABM As New AccionesABM

        DeleteNota = NotasTransversales.BorrarNotaTransversal(Id, UserId)

    End Function
    <WebMethod()> _
    Public Function ListarTodas(ByVal UserId As Long) As String
        Dim NotasTransversales As New NotasTransversales
        Dim AccionesABM As New AccionesABM

        ListarTodas = NotasTransversales.NotaTransversalTodas(UserId)

    End Function
    <WebMethod()> _
    Public Function UpdateNovedades(ByVal Descripcion As String, ByVal ProgramasId As Long, ByVal UserId As Long) As String
        Dim NovedadesPorPrograma As New NovedadesPorPrograma
        Dim AccionesABM As New AccionesABM

        UpdateNovedades = NovedadesPorPrograma.InsertarNovedadesPorPrograma(Descripcion, ProgramasId, UserId)

    End Function
    <WebMethod()> _
    Public Function DeleteNovedades(ByVal Id As Long, ByVal ProgramasId As Long, ByVal UserId As Long) As String
        Dim NovedadesPorPrograma As New NovedadesPorPrograma
        Dim AccionesABM As New AccionesABM

        DeleteNovedades = NovedadesPorPrograma.BorrarNovedadesPorPrograma(Id, ProgramasId, UserId)

    End Function
    <WebMethod()> _
    Public Function ListarNovedadesTodas(ByVal ProgramasId As Long, ByVal UserId As Long) As String
        Dim NovedadesPorPrograma As New NovedadesPorPrograma
        Dim AccionesABM As New AccionesABM

        ListarNovedadesTodas = NovedadesPorPrograma.NovedadesTodas(ProgramasId, UserId)

    End Function
    <WebMethod()> _
    Public Function BuscarDocumentos(ByVal Descripcion As String, ByVal UserId As Long) As String
        Dim DocumentosSGI As New DocumentosSGI
        Dim Stakeholders As New Stakeholders
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim AccionesABM As New AccionesABM
        Dim BuscarStakeholders As String = ""
        Dim BuscarJuicios As String = ""
        Dim CodigoHTML As String = ""
        Dim Usuarios As New Usuarios
        Dim s As Integer = 0

        If Len(Descripcion) >= 3 Then
            'Session("StringBusqueda") = Descripcion
            s = Usuarios.StringBusquedaUpdate(UserId, Descripcion)
            BuscarDocumentos = DocumentosSGI.MostrarDocumentosPorPalabraClave(Descripcion, UserId)
            'BuscarStakeholders = Stakeholders.MostrarStakeholdersPorPalabraClave(Descripcion, UserId)
            'BuscarProgramas = Programas.MostrarProgramasPorPalabraClave(Descripcion, UserId)
            BuscarJuicios = CarpetaJudicial.MostrarCarpetaJudicialPorPalabraClave(Descripcion, UserId)
            BuscarDocumentos = BuscarDocumentos & BuscarJuicios
        Else
            CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""alertas"">"
            CodigoHTML = CodigoHTML & "<tr><th scope=""col"">Búsquedas con ['" & Descripcion & "']</th></tr>"
            CodigoHTML = CodigoHTML & "<tr><td>La palabra clave para la búsqueda debe tener al menos 3 dígitos</td></tr></table>"
            BuscarDocumentos = CodigoHTML
        End If

    End Function
    <WebMethod()> _
    Public Function FuncionesPorRolInsert(ByVal RolId As Long, ByVal FuncionId As String, ByVal EntidadNombreTabla As String, ByVal UserId As Long) As Integer
        Dim FuncionesPorRol As New FuncionesPorRol

        FuncionesPorRolInsert = FuncionesPorRol.FuncionesPorRolInsert(RolId, FuncionId, EntidadNombreTabla, UserId)
    End Function
    <WebMethod()> _
    Public Function FuncionesPorRolDelete(ByVal RolId As Long, ByVal FuncionId As String, ByVal EntidadNombreTabla As String, ByVal UserId As Long) As Integer
        Dim FuncionesPorRol As New FuncionesPorRol

        FuncionesPorRolDelete = FuncionesPorRol.FuncionesPorRolDelete(RolId, FuncionId, EntidadNombreTabla, UserId)
    End Function
    <WebMethod()> _
    Public Function FuncionesPorRolUpdate(ByVal RolId As Long, ByVal FuncionId As String, ByVal EntidadNombreTabla As String, ByVal UserId As Long) As Integer
        Dim FuncionesPorRol As New FuncionesPorRol

        FuncionesPorRolUpdate = FuncionesPorRol.FuncionesPorRolUpdate(RolId, FuncionId, EntidadNombreTabla, UserId)
    End Function
    <WebMethod()> _
    Public Function FuncionesPorPortalUpdate(ByVal PortalesId As Long, ByVal MenuOptionsId As String, ByVal Secuencia As Long, ByVal UserId As Long) As String
        Dim FuncionesPorPortal As New FuncionesPorPortal

        FuncionesPorPortalUpdate = FuncionesPorPortal.FuncionesPorPortalUpdate(PortalesId, MenuOptionsId, Secuencia, UserId)
    End Function
    <WebMethod()> _
    Public Function FuncionesPorPortalUpdateSecuencia(ByVal PortalesId As Long, ByVal MenuOptionsId As String, ByVal Secuencia As Long, ByVal UserId As Long) As String
        Dim FuncionesPorPortal As New FuncionesPorPortal

        FuncionesPorPortalUpdateSecuencia = FuncionesPorPortal.FuncionesPorPortalUpdateSecuencia(PortalesId, MenuOptionsId, Secuencia, UserId)
    End Function
    <WebMethod()> _
    Public Function MenuOptionsUpdateSecuencia(ByVal MenuOptionsId As Long, ByVal Id As Long, ByVal Secuencia As Long, ByVal UserId As Long) As String
        Dim MenuOptions As New MenuOptions

        MenuOptionsUpdateSecuencia = MenuOptions.MenuOptionsUpdateSecuencia(MenuOptionsId, Id, Secuencia, UserId)
    End Function
    <WebMethod()> _
    Public Function RelationTableUpdate(ByVal RelationTable As String, ByVal PivotTable As String, ByVal ChildTable As String, ByVal PivotId As Long, ByVal ChildId As Long, ByVal UserId As Long) As Integer
        Dim AccionesABM As New AccionesABM

        RelationTableUpdate = AccionesABM.RelationsBetweenTablesUpdate(RelationTable, PivotTable, ChildTable, PivotId, ChildId, UserId)

    End Function
    <WebMethod()> _
    Public Function UpdateRelationTableUpdate(ByVal RelationTable As String, ByVal RelationTableId As Long, ByVal Puntaje As Long, ByVal ProgramasMapaId As Long, ByVal UserId As Long) As String
        'Dim PriorizacionPorStakeholders As New PriorizacionPorStakeholders

        'UpdateRelationTableUpdate = PriorizacionPorStakeholders.PriorizacionPorStakeholdersUpdate(RelationTable, RelationTableId, Puntaje, ProgramasMapaId, UserId)

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim s As Integer
        Dim ProgramasMapa As New ProgramasMapa

        UpdateRelationTableUpdate = ""

        strUpdate = "UPDATE PriorizacionPorStakeholders SET "
        strUpdate = strUpdate & "PriorizacionPorStakeholders.PriorizacionPorStakeholdersValor = " & Puntaje & ", "
        strUpdate = strUpdate & "PriorizacionPorStakeholders.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "PriorizacionPorStakeholders.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE PriorizacionPorStakeholders.PriorizacionPorStakeholdersId = " & RelationTableId

        Try
            s = AccesoEA.ABMRegistros(strUpdate)
            UpdateRelationTableUpdate = CStr(ProgramasMapa.ProgramasMapaUpdateImportancia(ProgramasMapaId, UserId))
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Priorización de Stakeholders ", RelationTableId, RelationTable, "")
        Catch
            UpdateRelationTableUpdate = ""
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento Fallido de Actualizar Priorización de Stakeholders ", RelationTableId, RelationTable, "")
        End Try

    End Function
    <WebMethod()> _
    Public Function EnviarCorreo(ByVal DireccionCorreo As String, ByVal TareasId As Long) As Integer
        Dim AccionesABM As New AccionesABM

        EnviarCorreo = AccionesABM.EnviarCorreo(DireccionCorreo, TareasId)
    End Function
    <WebMethod()> _
    Public Function UpdateTareasLog(ByVal TareasCodigo As String, ByVal UsuariosCodigo As String, ByVal RolName As String, ByVal Comentarios As String, ByVal chkCorreo As Boolean, ByVal chkMuro As Boolean, ByVal chkCritica As Boolean, ByVal FechaCritica As String) As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim NotasTransversales As New NotasTransversales
        Dim Usuarios As New Usuarios
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim TareasId As Long = 0
        Dim t As Boolean
        t = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        Dim CarpetaJudicialId As Long = Tareas.LeerCarpetaJudicialIdbyTareasId(TareasId)
        Dim CarpetaJudicialCodigo As String = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
        Dim UsuariosId As Long = 0
        t = Usuarios.LeerUsuariosByName(UsuariosId, UsuariosCodigo)
        Dim TareasNotasFrom As String = ""
        Dim TareasNotasTo As String = ""
        Dim TareasNotasSubject As String = ""
        Dim Correo As String = ""
        Dim ConCopia As String = ""


        Dim ResponsableTarea As String = Tareas.LeerEjecutorDeTareas(TareasCodigo)
        Dim Causa As String = CarpetaJudicialCodigo & ": Scotiabank y " & CarpetaJudicial.LeerApellidosDeudorByTareasId(TareasId)

        If Len(Comentarios) > 0 Then  'El comentario no puede venir vacio

            'Primero inserta el comentario en el log de la tareas, esto se hace siempre.
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, RolName, FormatDateTime(Now(), DateFormat.ShortDate) & ": " & Comentarios)

            'A continuación se examina si el check de fecha critica es verdadero
            'De ser así se publica en el muro y se manda correo.

            Dim Secretaria As String = CarpetaJudicial.DevolverUsuarioPorRol("Secretaria", CarpetaJudicialCodigo)
            Dim Supervisor As String = CarpetaJudicial.DevolverUsuarioPorRol("Supervisor", CarpetaJudicialCodigo)
            Dim Procurador As String = CarpetaJudicial.DevolverUsuarioPorRol("Procurador", CarpetaJudicialCodigo)
            Dim Receptor As String = CarpetaJudicial.DevolverUsuarioPorRol("Receptor", CarpetaJudicialCodigo)
            TareasNotasFrom = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)
            TareasNotasTo = Usuarios.LeerUsuariosDescriptionByName(ResponsableTarea)
            Correo = ResponsableTarea

            ConCopia = ""
            TareasNotasSubject = CarpetaJudicialCodigo & ": Scotiabank  y " & CarpetaJudicial.LeerApellidosDeudorByTareasId(TareasId)
            If chkCritica = True Then
                t = NotasTransversales.NotasTransversalesInsertAlerta("De: " & Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo) & " A: " & Usuarios.LeerUsuariosDescriptionByName(ResponsableTarea) & " por la causa " & Causa & ": Alerta de Fecha Cr&iacute;tica el d&iacute;a " & FormatDateTime(CDate(FechaCritica), DateFormat.ShortDate) & " " & Comentarios, True, CDate(FechaCritica), False, CDate(Now()), UsuariosId)
                t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, RolName, "Se publica aviso de fecha crítica en el muro: " & FormatDateTime(CDate(FechaCritica), DateFormat.ShortDate) & " " & Comentarios)
                t = AccionesABM.EnviarMensajeDemanda(TareasId, CarpetaJudicialId, Comentarios, Secretaria, Procurador, Supervisor, Receptor, CarpetaJudicialCodigo, TareasNotasFrom, TareasNotasTo, Correo, TareasNotasSubject, ConCopia, UsuariosId)
                t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, RolName, "Se envia correo de alerta de fecha critica para el " & FormatDateTime(CDate(FechaCritica), DateFormat.ShortDate) & " a " & Correo & ": " & Comentarios)
            Else
                If chkCorreo Then
                    t = AccionesABM.EnviarMensajeDemanda(TareasId, CarpetaJudicialId, Comentarios, Secretaria, Procurador, Supervisor, Receptor, CarpetaJudicialCodigo, TareasNotasFrom, TareasNotasTo, Correo, TareasNotasSubject, ConCopia, UsuariosId)
                    t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, RolName, "Se envia correo a " & Correo & ": " & Comentarios)
                End If
                If chkMuro Then
                    t = NotasTransversales.NotasTransversalesInsert("De: " & Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo) & ", A: " & Usuarios.LeerUsuariosDescriptionByName(ResponsableTarea) & ", por la causa " & Causa & ": " & Comentarios, UsuariosId)
                    t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, RolName, "Se publica comentario en el muro")
                End If
            End If
        End If
        UpdateTareasLog = Tareas.ListarDatosDelResponsablePorTareasId(TareasId)
    End Function
    <WebMethod()> _
    Public Function TerminarTarea(ByVal TareasCodigo As String, ByVal UsuariosCodigo As String, ByVal EstadoTareasCodigo As String, ByVal AccionesCodigo As String) As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim NotasTransversales As New NotasTransversales
        Dim Usuarios As New Usuarios
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim TareasId As Long = 0
        Dim t As Boolean
        Dim UsuariosCodigoActual As String = UsuariosCodigo
        t = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        Dim CarpetaJudicialId As Long = Tareas.LeerCarpetaJudicialIdbyTareasId(TareasId)
        Dim CarpetaJudicialCodigo As String = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
        Dim UsuariosId As Long = 0
        t = Usuarios.LeerUsuariosByName(UsuariosId, UsuariosCodigo)
        Dim TareasNotasFrom As String = ""
        Dim TareasNotasTo As String = ""
        Dim TareasNotasSubject As String = ""
        Dim Correo As String = ""
        Dim ConCopia As String = ""

        Dim Lecturas As New Lecturas

        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim Acciones As New Acciones
        Dim AccionesId As Long = 0

        Dim AccionesName As String = ""
        Dim AccionesDescription As String = ""
        Dim RolName As String = ""
        Dim s As Integer = 0
        Dim CarpetaJudicialRut As String = ""


        Dim FechaProximaTarea As Date
        Dim Dias As Double = 0
        Dim SeDebeEnviarCorreo As Boolean = False

        Dim TareasEjecutor As String = ""
        Dim TareasLogRol As String = ""

        Dim Secretaria As String = CarpetaJudicial.DevolverUsuarioPorRol("Secretaria", CarpetaJudicialCodigo)
        Dim Supervisor As String = CarpetaJudicial.DevolverUsuarioPorRol("Supervisor", CarpetaJudicialCodigo)
        Dim Procurador As String = CarpetaJudicial.DevolverUsuarioPorRol("Procurador", CarpetaJudicialCodigo)
        Dim Receptor As String = CarpetaJudicial.DevolverUsuarioPorRol("Receptor", CarpetaJudicialCodigo)


        t = Tareas.LeerEjecutorRolByTareasId(TareasId, TareasEjecutor, TareasLogRol, TareasCodigo)

        'Aquí se llega cuando el usuario ha decidido dar por terminada la tarea y requiere generar 
        'la siguiente tarea de acuerdo a la post condicion resultante al finalizar la tarea actualmente 
        'en ejecución.

        'Lo primero es marcar la tarea como cerrada.
        'A continuación se crea la siguiente tarea de acuerdo con la post condición indicada por el usuario
        'Se actualiza la carpeta judicial con el nuevo estado

        'Marcar la tarea como cerrada

        t = Tareas.TareasCerrar(TareasId, UsuariosId)
        SeDebeEnviarCorreo = Acciones.SeDebeEnviarCorreo(AccionesCodigo)
        TareasNotasSubject = CarpetaJudicialCodigo & ": Scotiabank  y " & CarpetaJudicial.LeerApellidosDeudorByTareasId(TareasId)

        'Ubicar la siguiente acción dada la post condición indicada en txtEstadoTareasCodigo en combinación con el código de la acción actual

        t = Acciones.LeerAccionSiguiente(AccionesCodigo, EstadoTareasCodigo, AccionesId, AccionesCodigo, AccionesName, AccionesDescription, RolName)
        ' Aquí voy a preguntar chanchamente si la siguiente acción es 02.06.16 y de ser así voy a poner el código
        ' para abrir el flujo en dos tareas paralelas.
        If SeDebeEnviarCorreo = True Then
            t = Usuarios.LeerUsuariosCodigoByUsuariosId(UsuariosId, UsuariosCodigo)
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
            t = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, "Se envia correo a " & Correo & ": " & EstadoTareasCodigo)
            TareasNotasSubject = TareasNotasSubject & " - " & EstadoTareasCodigo
            t = AccionesABM.EnviarMensajeDemanda(TareasId, CarpetaJudicialId, EstadoTareasCodigo, Secretaria, Procurador, Supervisor, Receptor, CarpetaJudicialCodigo, TareasNotasFrom, TareasNotasTo, Correo, TareasNotasSubject, ConCopia, UsuariosId)
        End If
        'CarpetaJudicialCodigo = CStr(txtPGGCodigo.Text)
        'CarpetaJudicialId = CarpetaJudicial.LeerCarpetaJudicialIdByCodigo(CarpetaJudicialCodigo)
        CarpetaJudicialRut = CarpetaJudicial.LeerRutDeudorByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
        '--------------------------------------------------------------------------------------------------------------------------------
        'IMPORTANTE: Este es un tema pendiente, manejar flujos alternativos, creando las tareas que correspondan pero sin código quemado.
        '--------------------------------------------------------------------------------------------------------------------------------
        If AccionesCodigo = "02.06.16" Then  'Se abre el flujo
            'Crear Tarea para el flujo de apremios, que corresponde a la acción 02.06.12
            t = Acciones.LeerAccionesByName(AccionesId, "02.06.12")
            t = Acciones.LeerAccionesNameAndDescription(AccionesId, AccionesCodigo, AccionesName, AccionesDescription)
            RolName = Acciones.LeerRolPorAccion(AccionesCodigo)
            UsuariosCodigo = CarpetaJudicial.DevolverUsuarioPorRol(RolName, CarpetaJudicialCodigo)
            Dias = Acciones.LeerDurationPorAccion(AccionesCodigo)
            FechaProximaTarea = DateAdd(DateInterval.Day, Dias, Now())
            s = CarpetaJudicial.CrearTareas(CarpetaJudicialCodigo, AccionesCodigo, AccionesId, CarpetaJudicialId, CarpetaJudicialRut, FechaProximaTarea, AccionesName, UsuariosCodigo, 0, 0, TareasId, UsuariosId)
            If s = 1 Then
                t = CarpetaJudicial.CarpetaJudicialTareasIdUpdate(CarpetaJudicialId, TareasId, CarpetaJudicialCodigo, AccionesName, UsuariosId)
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
            s = CarpetaJudicial.CrearTareas(CarpetaJudicialCodigo, AccionesCodigo, AccionesId, CarpetaJudicialId, CarpetaJudicialRut, FechaProximaTarea, AccionesName, UsuariosCodigo, 0, 0, TareasId, UsuariosId)
            If s = 1 Then
                t = CarpetaJudicial.CarpetaJudicialTareasIdUpdate(CarpetaJudicialId, TareasId, CarpetaJudicialCodigo, AccionesName, UsuariosId)
            End If

        Else

            UsuariosCodigo = CarpetaJudicial.DevolverUsuarioPorRol(RolName, CarpetaJudicialCodigo)
            Dias = Acciones.LeerDurationPorAccion(AccionesCodigo)
            FechaProximaTarea = DateAdd(DateInterval.Day, Dias, Now())

            s = CarpetaJudicial.CrearTareas(CarpetaJudicialCodigo, AccionesCodigo, AccionesId, CarpetaJudicialId, CarpetaJudicialRut, FechaProximaTarea, AccionesName, UsuariosCodigo, 0, 0, TareasId, UsuariosId)
            If s = 1 Then
                t = CarpetaJudicial.CarpetaJudicialTareasIdUpdate(CarpetaJudicialId, TareasId, CarpetaJudicialCodigo, AccionesName, UsuariosId)
            End If

        End If


        TerminarTarea = Tareas.ListarDatosDelResponsablePorTareasId(TareasId)
    End Function
    <WebMethod()> _
    Public Function CerrarTarea(ByVal TareasId As Long, ByVal UserId As Long, ByVal arrControl As String, _
                                ByVal arrLabel As String, ByVal k As Integer, _
                                ByVal IsNotEnabledField As Boolean, ByVal Pagina As String, _
                                ByVal NombrePagina As String, ByVal MenuOptionsId As Long, _
                                ByVal MasterName As String, ByVal MasterId As Long, ByVal DomainField As String, _
                                ByVal FormularioWebPId As Long, ByVal FilterField As String, _
                                ByVal sSQLWhere As String, ByVal sSQLOrder As String, ByVal PaginaWebName As String) As String

        Dim Tareas As New Tareas
        Dim Lecturas As New Lecturas
        Dim t As Boolean


        t = Tareas.TareasCerrar(TareasId, UserId)

        'CerrarTarea = Tareas.ListarDatosDelResponsablePorTareasId(TareasId)
        CerrarTarea = Lecturas.LoadTabla(arrControl, arrLabel, k, IsNotEnabledField, Pagina, NombrePagina, MenuOptionsId, MasterName, MasterId, DomainField, FormularioWebPId, FilterField, sSQLWhere, sSQLOrder, PaginaWebName, UserId)

    End Function
    <WebMethod()> _
    Public Function LoadTabla(ByVal arrControl As String, _
                                ByVal arrLabel As String, ByVal k As Integer, _
                                ByVal IsNotEnabledField As Boolean, ByVal Pagina As String, _
                                ByVal NombrePagina As String, ByVal MenuOptionsId As Long, _
                                ByVal MasterName As String, ByVal MasterId As Long, ByVal DomainField As String, _
                                ByVal FormularioWebPId As Long, ByVal FilterField As String, _
                                ByVal sSQLWhere As String, ByVal sSQLOrder As String, ByVal PaginaWebName As String, ByVal UserId As Long) As String

        Dim Lecturas As New Lecturas
        LoadTabla = Lecturas.LoadTabla(arrControl, arrLabel, k, IsNotEnabledField, Pagina, NombrePagina, MenuOptionsId, MasterName, MasterId, DomainField, FormularioWebPId, FilterField, sSQLWhere, sSQLOrder, PaginaWebName, UserId)

    End Function
    <WebMethod()> _
    Public Function ListarTareasPendientes(ByVal UsuariosCodigo As String) As String
        Dim Tareas As New Tareas

        ListarTareasPendientes = Tareas.ListarTareasPendientes(UsuariosCodigo)
    End Function
    <WebMethod()> _
    Public Function CarpetaJudicialJuzgadoRol(ByVal TareasCodigo As String, ByVal UsuariosCodigo As String, ByVal Fecha As String, ByVal Rol As String, ByVal Juzgado As String) As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim TareasId As Long = 0
        Dim UsuariosId As Long = 0
        Dim t As Boolean

        t = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        Dim CarpetaJudicialId As Long = Tareas.LeerCarpetaJudicialIdbyTareasId(TareasId)
        Dim CarpetaJudicialCodigo As String = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
        t = Usuarios.LeerUsuariosByName(UsuariosId, UsuariosCodigo)
        t = CarpetaJudicial.CarpetaJudicialJuzgadoRolUpdate(CarpetaJudicialId, TareasId, Rol, Juzgado, CDate(Fecha), UsuariosId)

        CarpetaJudicialJuzgadoRol = Tareas.ListarDatosDelResponsablePorTareasId(TareasId)
    End Function
    <WebMethod()> _
    Public Function MostrarNotasTransversales(ByVal UsuariosCodigo As String) As String
        Dim NotasTransversales As New NotasTransversales
        Dim Usuarios As New Usuarios
        Dim UsuariosId As Long
        Dim t As Boolean

        t = Usuarios.LeerUsuariosByName(UsuariosId, UsuariosCodigo)
        MostrarNotasTransversales = NotasTransversales.MostrarNotasTransversales(10, UsuariosId)
    End Function
    <WebMethod()> _
    Public Function CarpetaJudicialIdentificacionDeudorUpdate(ByVal TareasCodigo As String, ByVal UsuariosCodigo As String, ByVal Rut As String, ByVal Nombres As String, ByVal Apellidos As String) As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim TareasId As Long = 0
        Dim UsuariosId As Long = 0
        Dim t As Boolean

        t = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        Dim CarpetaJudicialId As Long = Tareas.LeerCarpetaJudicialIdbyTareasId(TareasId)
        Dim CarpetaJudicialCodigo As String = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
        t = Usuarios.LeerUsuariosByName(UsuariosId, UsuariosCodigo)
        t = CarpetaJudicial.CarpetaJudicialIdentificacionDeudorUpdate(CarpetaJudicialId, TareasId, Rut, Nombres, Apellidos, UsuariosId)

        CarpetaJudicialIdentificacionDeudorUpdate = Tareas.ListarDatosDelResponsablePorTareasId(TareasId)
    End Function
    <WebMethod()> _
    Public Function CarpetaJudicialMasAntecedentesUpdate(ByVal TareasCodigo As String, ByVal UsuariosCodigo As String, ByVal Profesion As String) As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim TareasId As Long = 0
        Dim UsuariosId As Long = 0
        Dim t As Boolean

        t = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        Dim CarpetaJudicialId As Long = Tareas.LeerCarpetaJudicialIdbyTareasId(TareasId)
        Dim CarpetaJudicialCodigo As String = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
        t = Usuarios.LeerUsuariosByName(UsuariosId, UsuariosCodigo)
        t = CarpetaJudicial.CarpetaJudicialMasAntecedentesUpdate(CarpetaJudicialId, TareasId, Profesion, UsuariosId)

        CarpetaJudicialMasAntecedentesUpdate = Tareas.ListarDatosDelResponsablePorTareasId(TareasId)
    End Function
    <WebMethod()> _
    Public Function CarpetaJudicialFechaPresentacionUpdate(ByVal TareasCodigo As String, ByVal UsuariosCodigo As String, ByVal Fecha As String) As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim TareasId As Long = 0
        Dim UsuariosId As Long = 0
        Dim t As Boolean

        t = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        Dim CarpetaJudicialId As Long = Tareas.LeerCarpetaJudicialIdbyTareasId(TareasId)
        Dim CarpetaJudicialCodigo As String = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
        t = Usuarios.LeerUsuariosByName(UsuariosId, UsuariosCodigo)
        t = CarpetaJudicial.CarpetaJudicialFechaPresentacionUpdate(CarpetaJudicialId, TareasId, CDate(Fecha), UsuariosId)

        CarpetaJudicialFechaPresentacionUpdate = Tareas.ListarDatosDelResponsablePorTareasId(TareasId)
    End Function
    <WebMethod()> _
    Public Function CarpetaJudicialFechaNotificacionUpdate(ByVal TareasCodigo As String, ByVal UsuariosCodigo As String, ByVal Fecha As String, ByVal Comuna As String) As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim TareasId As Long = 0
        Dim UsuariosId As Long = 0
        Dim t As Boolean

        t = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        Dim CarpetaJudicialId As Long = Tareas.LeerCarpetaJudicialIdbyTareasId(TareasId)
        Dim CarpetaJudicialCodigo As String = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
        t = Usuarios.LeerUsuariosByName(UsuariosId, UsuariosCodigo)
        t = CarpetaJudicial.CarpetaJudicialFechaNotificacionUpdate(CarpetaJudicialId, TareasId, CDate(Fecha), Comuna, UsuariosId)

        CarpetaJudicialFechaNotificacionUpdate = Tareas.ListarDatosDelResponsablePorTareasId(TareasId)
    End Function
    <WebMethod()> _
    Public Function ListarDatosDelResponsablePorTareasId(ByVal TareasCodigo As String) As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim TareasId As Long = 0
        Dim t As Boolean

        t = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        ListarDatosDelResponsablePorTareasId = Tareas.ListarDatosDelResponsablePorTareasId(TareasId)
    End Function
    <WebMethod()> _
    Public Function MostrarTareasPendientesPorUsuario(ByVal UsuariosCodigo As String) As String
        Dim Tareas As New Tareas
        Dim CodigoHTML As String = ""
        Dim t As Boolean

        CodigoHTML = CodigoHTML & "<div id=""Accordion1"" class=""Accordion"" tabindex=""0"" >"
        t = Tareas.MostrarTareasPorMes(CodigoHTML, True, UsuariosCodigo)
        CodigoHTML = CodigoHTML & "</div>"

        MostrarTareasPendientesPorUsuario = CodigoHTML

        'MostrarTareasPendientesPorUsuario = Tareas.MostrarTareasPendientesPorUsuario(UsuariosCodigo)
    End Function
    <WebMethod()> _
    Public Function ListarPanelControlPorTiposDeProcesos() As String
        Dim TipoProceso As New TipoProceso

        ListarPanelControlPorTiposDeProcesos = TipoProceso.ListarPanelControlPorTiposDeProcesos()
    End Function
    <WebMethod()> _
    Public Function ListarInformeMovimientoDiarioPorTiposDeProcesos(ByVal Fecha As String) As String
        Dim TipoProceso As New TipoProceso

        ListarInformeMovimientoDiarioPorTiposDeProcesos = TipoProceso.ListarInformeMovimientoDiarioPorTiposDeProcesos(CDate(Fecha))
    End Function
    <WebMethod()> _
    Public Function ListarInformeEstadoDiarioPorTiposDeProcesos() As String
        Dim TipoProceso As New TipoProceso

        ListarInformeEstadoDiarioPorTiposDeProcesos = TipoProceso.ListarInformeEstadoDiarioPorTiposDeProcesos()
    End Function
    <WebMethod()> _
    Public Function TipoProcesoUpdate(ByVal UsuariosId As Long, ByVal TipoProcesoId As Long, ByVal TipoProcesoName As String, ByVal TipoProcesoDescription As String, ByVal TipoProcesoSecuencia As Long, ByVal ClaseProcesoName As String, ByVal AccionesCodigo As String) As String
        Dim AccionesABM As New AccionesABM
        Dim TipoProceso As New TipoProceso
        Dim s As Integer

        s = TipoProceso.TipoProcesoUpdate(TipoProcesoId, TipoProcesoName, TipoProcesoDescription, TipoProcesoSecuencia, ClaseProcesoName, AccionesCodigo, UsuariosId)

        TipoProcesoUpdate = TipoProceso.ListarTipoProcesosVigentes()
    End Function
    <WebMethod()> _
    Public Function ListarTiposDeProcesos() As String
        Dim TipoProceso As New TipoProceso

        ListarTiposDeProcesos = TipoProceso.ListarTiposDeProcesos("invisible", True)
    End Function
    <WebMethod()> _
    Public Function TipoProcesoDelete(ByVal UsuariosId As Long, ByVal TipoProcesoId As Long, ByVal TipoProcesoName As String) As String
        Dim TipoProceso As New TipoProceso
        Dim s As Integer
        Dim Mensaje As String = ""

        s = TipoProceso.TipoProcesoDelete(TipoProcesoId, TipoProcesoName, UsuariosId, Mensaje)

        If Mensaje = "" Then
            TipoProcesoDelete = TipoProceso.ListarTipoProcesosVigentes()
        Else
            TipoProcesoDelete = "NO"
        End If
    End Function
    <WebMethod()> _
    Public Function LeerTipoProceso(ByVal TipoProcesoId As Long) As String()
        Dim TipoProceso As New TipoProceso
        Dim TipoProcesoName As String = ""
        Dim TipoProcesoDescription As String = ""
        Dim TipoProcesoSecuencia As Long = 0
        Dim ClaseProcesoName As String = ""
        Dim AccionesCodigo As String = ""

        If TipoProceso.LeerTipoProceso(TipoProcesoId, TipoProcesoName, TipoProcesoDescription, TipoProcesoSecuencia, ClaseProcesoName, AccionesCodigo) Then
            Dim items As New List(Of String)
            items.Add(TipoProcesoId)
            items.Add(TipoProcesoName)
            items.Add(TipoProcesoDescription)
            items.Add(TipoProcesoSecuencia)
            items.Add(ClaseProcesoName)
            items.Add(AccionesCodigo)
            items.Add(TipoProceso.ListarEtapasPorTipoProceso(TipoProcesoId))
            Return items.ToArray
        Else
            Return Nothing
        End If
    End Function
    <WebMethod()> _
    Public Function LeerTipoProcesoAnterior(ByVal UserId As Long, ByVal TipoProcesoId As Long, ByVal TipoProcesoSecuencia As Long) As String()
        Dim TipoProceso As New TipoProceso
        Dim TipoProcesoName As String = ""
        Dim TipoProcesoDescription As String = ""
        Dim ClaseProcesoName As String = ""
        Dim AccionesCodigo As String = ""
        Dim Etapas As New Etapas

        Dim Id As Long = TipoProceso.LeerIdProcesoAnterior(TipoProcesoId, TipoProcesoSecuencia)
        If TipoProceso.LeerTipoProceso(Id, TipoProcesoName, TipoProcesoDescription, TipoProcesoSecuencia, ClaseProcesoName, AccionesCodigo) Then
            Dim items As New List(Of String)
            items.Add(Id)
            items.Add(TipoProcesoName)
            items.Add(TipoProcesoDescription)
            items.Add(TipoProcesoSecuencia)
            items.Add(ClaseProcesoName)
            items.Add(AccionesCodigo)
            items.Add(Etapas.ListarEtapasPorTipoProceso(Id, UserId))
            'items.Add(TipoProceso.ListarEtapasPorTipoProceso(Id))
            Return items.ToArray
        Else
            Return Nothing
        End If
    End Function
    <WebMethod()> _
    Public Function LeerTipoProcesoSiguiente(ByVal UserId As Long, ByVal TipoProcesoId As Long, ByVal TipoProcesoSecuencia As Long) As String()
        Dim TipoProceso As New TipoProceso
        Dim TipoProcesoName As String = ""
        Dim TipoProcesoDescription As String = ""
        Dim ClaseProcesoName As String = ""
        Dim AccionesCodigo As String = ""
        Dim Id As Long = TipoProceso.LeerIdProcesoSiguiente(TipoProcesoId, TipoProcesoSecuencia)
        Dim Etapas As New Etapas

        If TipoProceso.LeerTipoProceso(Id, TipoProcesoName, TipoProcesoDescription, TipoProcesoSecuencia, ClaseProcesoName, AccionesCodigo) Then
            Dim items As New List(Of String)
            items.Add(Id)
            items.Add(TipoProcesoName)
            items.Add(TipoProcesoDescription)
            items.Add(TipoProcesoSecuencia)
            items.Add(ClaseProcesoName)
            items.Add(AccionesCodigo)
            items.Add(Etapas.ListarEtapasPorTipoProceso(Id, UserId))
            'items.Add(TipoProceso.ListarEtapasPorTipoProceso(Id))
            Return items.ToArray
        Else
            Return Nothing
        End If
    End Function

    <WebMethod()> _
    Public Function TipoProcesoInsert(ByVal UsuariosId As Long) As String()
        Dim TipoProceso As New TipoProceso
        Dim TipoProcesoId As Long = 0
        Dim TipoProcesoName As String = ""
        Dim TipoProcesoDescription As String = ""
        Dim TipoProcesoSecuencia As Long = 0
        Dim ClaseProcesoName As String = ""
        Dim AccionesCodigo As String = ""
        Dim s As Integer
        Dim Etapas As New Etapas

        s = TipoProceso.TipoProcesoInsert(TipoProcesoId, TipoProcesoName, TipoProcesoDescription, TipoProceso.CalcularNextTipoProcesoSecuencia, ClaseProcesoName, AccionesCodigo, UsuariosId)
        If TipoProceso.LeerTipoProceso(s, TipoProcesoName, TipoProcesoDescription, TipoProcesoSecuencia, ClaseProcesoName, AccionesCodigo) Then
            Dim items As New List(Of String)
            items.Add(TipoProcesoId)
            items.Add(TipoProcesoName)
            items.Add(TipoProcesoDescription)
            items.Add(TipoProcesoSecuencia)
            items.Add(ClaseProcesoName)
            items.Add(AccionesCodigo)
            items.Add(TipoProceso.ListarTipoProcesosVigentes())
            items.Add(Etapas.ListarEtapasPorTipoProceso(s, UsuariosId))
            'items.Add(TipoProceso.ListarEtapasPorTipoProceso(Id))
            Return items.ToArray
        Else
            Return Nothing
        End If
    End Function
    <WebMethod()> _
    Public Function ListarEtapasPorTipoProceso(ByVal TipoProcesoId As Long, ByVal UserId As Long) As String
        Dim TipoProceso As New TipoProceso
        Dim Etapas As New Etapas

        'ListarEtapasPorTipoProceso = TipoProceso.ListarEtapasPorTipoProceso(TipoProcesoId)
        ListarEtapasPorTipoProceso = Etapas.ListarEtapasPorTipoProceso(TipoProcesoId, UserId)



    End Function
    <WebMethod()> _
    Public Function EtapasUpdate(ByVal UsuariosId As Long, ByVal EtapasId As Long, ByVal EtapasName As String, ByVal EtapasDescription As String, ByVal EtapasSecuencia As Long, ByVal EtapasPreCondiciones As String, ByVal EtapasPostCondiciones As String, ByVal TipoProcesoId As Long, ByVal TipoProcesoName As String) As String ', ByVal TipoProcesoId As Long, ByVal TipoProcesoName As String) As String
        Dim AccionesABM As New AccionesABM
        Dim Etapas As New Etapas
        Dim s As Integer

        s = Etapas.EtapasUpdate(EtapasId, EtapasName, EtapasDescription, EtapasSecuencia, EtapasPreCondiciones, EtapasPostCondiciones, TipoProcesoId, TipoProcesoName, UsuariosId)  '

        EtapasUpdate = Etapas.ListarEtapasVigentes()
    End Function
    <WebMethod()> _
    Public Function ListarEtapas(ByVal TipoProcesoId As Long) As String
        Dim Etapas As New Etapas

        ListarEtapas = Etapas.ListarEtapasVigentes(TipoProcesoId)
    End Function
    <WebMethod()> _
    Public Function EtapasDelete(ByVal UsuariosId As Long, ByVal EtapasId As Long, ByVal EtapasName As String) As String
        Dim Etapas As New Etapas
        Dim s As Integer
        Dim Mensaje As String = ""

        s = Etapas.EtapasDelete(EtapasId, EtapasName, UsuariosId, Mensaje)

        If Mensaje = "" Then
            EtapasDelete = Etapas.ListarEtapasVigentes()
        Else
            EtapasDelete = "NO"
        End If
    End Function
    <WebMethod()> _
    Public Function LeerEtapas(ByVal EtapasId As Long) As String()
        Dim Etapas As New Etapas
        Dim EtapasName As String = ""
        Dim EtapasDescription As String = ""
        Dim EtapasSecuencia As Long = 0
        Dim EtapasPreCondiciones As String = ""
        Dim EtapasPostCondiciones As String = ""
        Dim TipoProcesoId As Long = 0
        Dim TipoProcesoName As String = ""

        If Etapas.LeerEtapas(EtapasId, EtapasName, EtapasDescription, EtapasSecuencia, EtapasPreCondiciones, EtapasPostCondiciones, TipoProcesoId, TipoProcesoName) Then
            Dim items As New List(Of String)
            items.Add(EtapasId)
            items.Add(EtapasName)
            items.Add(EtapasDescription)
            items.Add(EtapasSecuencia)
            items.Add(EtapasPreCondiciones)
            items.Add(EtapasPostCondiciones)
            items.Add(TipoProcesoId)
            items.Add(TipoProcesoName)
            items.Add(Etapas.ListarAccionesPorEtapas(EtapasId))

            Return items.ToArray
        Else
            Return Nothing
        End If
    End Function
    <WebMethod()> _
    Public Function LeerEtapaAnterior(ByVal UserId As Long, ByVal EtapasId As Long, ByVal EtapasSecuencia As Long, ByVal ProcesoId As Long, ByVal Formato As String) As String()
        Dim Etapas As New Etapas
        Dim EtapasName As String = ""
        Dim EtapasDescription As String = ""
        Dim EtapasPreCondiciones As String = ""
        Dim EtapasPostCondiciones As String = ""
        Dim TipoProcesoId As Long = 0
        Dim TipoProcesoName As String = ""

        Dim Id As Long = Etapas.LeerIdEtapaAnterior(EtapasId, EtapasSecuencia)
        If Etapas.LeerEtapas(Id, EtapasName, EtapasDescription, EtapasSecuencia, EtapasPreCondiciones, EtapasPostCondiciones, TipoProcesoId, TipoProcesoName) Then
            Dim items As New List(Of String)
            items.Add(Id)
            items.Add(EtapasName)
            items.Add(EtapasDescription)
            items.Add(EtapasSecuencia)
            items.Add(EtapasPreCondiciones)
            items.Add(EtapasPostCondiciones)
            items.Add(TipoProcesoId)
            items.Add(TipoProcesoName)
            If Formato = "ascx" Then
                items.Add(Etapas.ListarAccionesPorEtapas(Id))
            Else
                items.Add(Etapas.ListarAccionesPorEtapasPorTipoProceso(Id, ProcesoId, UserId))
            End If

            Return items.ToArray
        Else
            Return Nothing
        End If
    End Function
    <WebMethod()> _
    Public Function LeerEtapaSiguiente(ByVal UserId As Long, ByVal EtapasId As Long, ByVal EtapasSecuencia As Long, ByVal ProcesoId As Long, ByVal Formato As String) As String()
        Dim Etapas As New Etapas
        Dim EtapasName As String = ""
        Dim EtapasDescription As String = ""
        Dim EtapasPreCondiciones As String = ""
        Dim EtapasPostCondiciones As String = ""
        Dim TipoProcesoId As Long = 0
        Dim TipoProcesoName As String = ""

        Dim Id As Long = Etapas.LeerIdEtapaSiguiente(EtapasId, EtapasSecuencia)
        If Etapas.LeerEtapas(Id, EtapasName, EtapasDescription, EtapasSecuencia, EtapasPreCondiciones, EtapasPostCondiciones, TipoProcesoId, TipoProcesoName) Then
            Dim items As New List(Of String)
            items.Add(Id)
            items.Add(EtapasName)
            items.Add(EtapasDescription)
            items.Add(EtapasSecuencia)
            items.Add(EtapasPreCondiciones)
            items.Add(EtapasPostCondiciones)
            items.Add(TipoProcesoId)
            items.Add(TipoProcesoName)
            If Formato = "ascx" Then
                items.Add(Etapas.ListarAccionesPorEtapas(Id))
            Else
                items.Add(Etapas.ListarAccionesPorEtapasPorTipoProceso(Id, ProcesoId, UserId))
            End If
            Return items.ToArray
        Else
            Return Nothing
        End If
    End Function
    <WebMethod()> _
    Public Function EtapasInsert(ByVal UsuariosId As Long, ByVal ProcesoId As Long, ByVal Formato As String) As String()
        Dim TipoProceso As New TipoProceso
        Dim Etapas As New Etapas
        Dim EtapasId As Long = 0
        Dim EtapasName As String = ""
        Dim EtapasDescription As String = ""
        Dim EtapasSecuencia As Long = 0
        Dim EtapasPreCondiciones As String = ""
        Dim EtapasPostCondiciones As String = ""
        Dim TipoProcesoId As Long = ProcesoId
        Dim TipoProcesoName As String = TipoProceso.LeerTipoProcesoNameById(TipoProcesoId)
        Dim s As Integer

        s = Etapas.EtapasInsert(EtapasId, EtapasName, EtapasDescription, Etapas.CalcularNextEtapasSecuencia(), EtapasPreCondiciones, EtapasPostCondiciones, TipoProcesoId, TipoProcesoName, UsuariosId) ' 
        If Etapas.LeerEtapas(s, EtapasName, EtapasDescription, EtapasSecuencia, EtapasPreCondiciones, EtapasPostCondiciones, TipoProcesoId, TipoProcesoName) Then
            Dim items As New List(Of String)
            items.Add(s)
            items.Add(EtapasName)
            items.Add(EtapasDescription)
            items.Add(EtapasSecuencia)
            items.Add(EtapasPreCondiciones)
            items.Add(EtapasPostCondiciones)
            items.Add(TipoProcesoId)
            items.Add(TipoProcesoName)
            items.Add(Etapas.ListarEtapasVigentes(ProcesoId))
            If Formato = "ascx" Then
                items.Add(Etapas.ListarAccionesPorEtapas(s))
            Else
                items.Add(Etapas.ListarAccionesPorEtapasPorTipoProceso(s, ProcesoId, UsuariosId))
            End If
            Return items.ToArray
        Else
            Return Nothing
        End If
    End Function
    <WebMethod()> _
    Public Function ListarAccionesPorEtapas(ByVal EtapasId As Long, ByVal TipoProcesoId As Long, ByVal UserId As Long, ByVal Formato As String) As String
        Dim Etapas As New Etapas

        If Formato = "ascx" Then
            ListarAccionesPorEtapas = Etapas.ListarAccionesPorEtapas(EtapasId, UserId, TipoProcesoId)
        Else
            ListarAccionesPorEtapas = Etapas.ListarAccionesPorEtapasPorTipoProceso(EtapasId, TipoProcesoId, UserId)
        End If

    End Function
    <WebMethod()> _
    Public Function AccionesInsert(ByVal UsuariosId As Long, ByVal TipoProcesoSecuencia As Long, ByVal EtapasId As Long) As String()

        Dim Acciones As New Acciones
        Dim Etapas As New Etapas
        Dim s As Integer

        Dim AccionesId As Long = 0
        Dim AccionesCodigo As String = ""
        Dim AccionesName As String = ""
        Dim AccionesDescription As String = ""
        Dim AccionesSecuencia As Long = Acciones.CalcularNextAccionesSecuencia(EtapasId)
        Dim EtapasName As String = Etapas.LeerEtapasNameById(EtapasId)
        Dim EtapasSecuencia As Long = Etapas.LeerEtapasSecuenciaByName(EtapasName)
        Dim RolName As String = ""
        Dim PaginaWebName As String = "Sin Ficha"
        Dim AccionesDuration As Long = 1
        Dim AccionesEnviaCorreo As Boolean = False
        Dim AccionesAdvertirFechaFatal As Boolean = False
        Dim AccionesIsFlujoAlternativo As Boolean = False

        If TipoProcesoSecuencia < 10 Then
            AccionesCodigo = AccionesCodigo & "0" & TipoProcesoSecuencia & "."
        Else
            AccionesCodigo = AccionesCodigo & TipoProcesoSecuencia & "."
        End If
        If EtapasSecuencia < 10 Then
            AccionesCodigo = AccionesCodigo & "0" & EtapasSecuencia & "."
        Else
            AccionesCodigo = AccionesCodigo & EtapasSecuencia & "."
        End If
        If AccionesSecuencia < 10 Then
            AccionesCodigo = AccionesCodigo & "0" & AccionesSecuencia
        Else
            AccionesCodigo = AccionesCodigo & AccionesSecuencia
        End If

        s = Acciones.AccionesInsert(AccionesId, AccionesCodigo, AccionesName, AccionesDescription, AccionesSecuencia, TipoProcesoSecuencia, EtapasSecuencia, EtapasName, EtapasId, RolName, PaginaWebName, AccionesDuration, AccionesEnviaCorreo, AccionesAdvertirFechaFatal, AccionesIsFlujoAlternativo, UsuariosId)
        If Acciones.LeerAcciones(s, AccionesCodigo, AccionesName, AccionesDescription, AccionesSecuencia, TipoProcesoSecuencia, EtapasSecuencia, EtapasName, EtapasId, RolName, PaginaWebName, AccionesDuration, AccionesEnviaCorreo, AccionesAdvertirFechaFatal, AccionesIsFlujoAlternativo) Then
            Dim items As New List(Of String)
            items.Add(s)
            items.Add(AccionesCodigo)
            items.Add(AccionesName)
            items.Add(AccionesDescription)
            items.Add(AccionesSecuencia)
            items.Add(TipoProcesoSecuencia)
            items.Add(EtapasSecuencia)
            items.Add(EtapasName)
            items.Add(EtapasId)
            items.Add(RolName)
            items.Add(PaginaWebName)
            items.Add(AccionesDuration)
            items.Add(LCase(AccionesEnviaCorreo))
            items.Add(LCase(AccionesAdvertirFechaFatal))
            items.Add(LCase(AccionesIsFlujoAlternativo))
            items.Add(Acciones.ListarAccionesPorEtapas(EtapasId))
            Return items.ToArray
        Else
            Return Nothing
        End If
    End Function
    <WebMethod()> _
    Public Function LeerAcciones(ByVal AccionesId As Long) As String()
        Dim Acciones As New Acciones
        Dim AccionesCodigo As String = ""
        Dim AccionesName As String = ""
        Dim AccionesDescription As String = ""
        Dim AccionesSecuencia As Long = 0
        Dim TipoProcesoSecuencia As Long = 0
        Dim EtapasSecuencia As Long = 0
        Dim EtapasName As String = ""
        Dim EtapasId As Long = 0
        Dim RolName As String = ""
        Dim PaginaWebName As String = ""
        Dim AccionesDuration As Long = 1
        Dim AccionesEnviaCorreo As Boolean = False
        Dim AccionesAdvertirFechaFatal As Boolean = False
        Dim AccionesIsFlujoAlternativo As Boolean = False

        If Acciones.LeerAcciones(AccionesId, AccionesCodigo, AccionesName, AccionesDescription, AccionesSecuencia, TipoProcesoSecuencia, EtapasSecuencia, EtapasName, EtapasId, RolName, PaginaWebName, AccionesDuration, AccionesEnviaCorreo, AccionesAdvertirFechaFatal, AccionesIsFlujoAlternativo) Then
            Dim items As New List(Of String)
            items.Add(AccionesId)
            items.Add(AccionesCodigo)
            items.Add(AccionesName)
            items.Add(AccionesDescription)
            items.Add(AccionesSecuencia)
            items.Add(TipoProcesoSecuencia)
            items.Add(EtapasSecuencia)
            items.Add(EtapasName)
            items.Add(EtapasId)
            items.Add(RolName)
            items.Add(PaginaWebName)
            items.Add(AccionesDuration)
            items.Add(LCase(AccionesEnviaCorreo))
            items.Add(LCase(AccionesAdvertirFechaFatal))
            items.Add(LCase(AccionesIsFlujoAlternativo))
            Return items.ToArray
        Else
            Return Nothing
        End If
    End Function
    <WebMethod()> _
    Public Function AccionesDelete(ByVal UsuariosId As Long, ByVal EtapasId As Long, ByVal AccionesId As Long, ByVal AccionesCodigo As String) As String
        Dim Acciones As New Acciones
        Dim Etapas As New Etapas
        Dim s As Integer
        Dim Mensaje As String = ""

        s = Acciones.AccionesDelete(AccionesId, AccionesCodigo, UsuariosId, Mensaje)

        If Mensaje = "" Then
            AccionesDelete = Etapas.ListarAccionesPorEtapas(EtapasId)
        Else
            AccionesDelete = "NO"
        End If
    End Function
    <WebMethod()> _
    Public Function AccionesUpdate(ByVal UsuariosId As Long, ByVal AccionesId As Long, ByVal AccionesCodigo As String, ByVal AccionesName As String, ByVal AccionesDescription As String, ByVal AccionesSecuencia As Long, ByVal TipoProcesoSecuencia As Long, ByVal EtapasSecuencia As Long, ByVal EtapasName As String, ByVal EtapasId As Long, ByVal RolName As String, ByVal PaginaWebName As String, ByVal AccionesDuration As Long, ByVal AccionesEnviaCorreo As Boolean, ByVal AccionesAdvertirFechaFatal As Boolean, ByVal AccionesIsFlujoAlternativo As Boolean) As String
        Dim Acciones As New Acciones
        Dim s As Integer

        s = Acciones.AccionesUpdate(AccionesId, AccionesCodigo, AccionesName, AccionesDescription, AccionesSecuencia, TipoProcesoSecuencia, EtapasSecuencia, EtapasName, EtapasId, RolName, PaginaWebName, AccionesDuration, AccionesEnviaCorreo, AccionesAdvertirFechaFatal, AccionesIsFlujoAlternativo, UsuariosId)

        AccionesUpdate = Acciones.ListarAccionesPorEtapas(EtapasId)
    End Function
    <WebMethod()> _
    Public Function EtapasPorTipoProcesoUpdate(ByVal TipoProcesoId As Long, ByVal EtapasId As String, ByVal Secuencia As Long, ByVal UserId As Long) As String
        Dim Etapas As New Etapas

        EtapasPorTipoProcesoUpdate = Etapas.EtapasPorTipoProcesoUpdate(TipoProcesoId, EtapasId, Secuencia, UserId)
    End Function
    <WebMethod()> _
    Public Function EtapasPorTipoProcesoUpdateSecuencia(ByVal TipoProcesoId As Long, ByVal EtapasId As String, ByVal Secuencia As Long, ByVal UserId As Long) As String
        Dim Etapas As New Etapas

        EtapasPorTipoProcesoUpdateSecuencia = Etapas.EtapasPorTipoProcesoUpdateSecuencia(TipoProcesoId, EtapasId, Secuencia, UserId)
    End Function
    <WebMethod()> _
    Public Function AccionesPorEtapasPorTipoProcesoUpdate(ByVal EtapasPorTipoProcesoId As Long, ByVal AccionesId As String, ByVal Secuencia As Long, ByVal UserId As Long) As String
        Dim Etapas As New Etapas

        AccionesPorEtapasPorTipoProcesoUpdate = Etapas.AccionesPorEtapasPorTipoProcesoUpdate(EtapasPorTipoProcesoId, AccionesId, Secuencia, UserId)
    End Function
    <WebMethod()> _
    Public Function AccionesPorEtapasPorTipoProcesoUpdateSecuencia(ByVal EtapasPorTipoProcesoId As Long, ByVal AccionesId As String, ByVal Secuencia As Long, ByVal UserId As Long) As String
        Dim Etapas As New Etapas

        AccionesPorEtapasPorTipoProcesoUpdateSecuencia = Etapas.AccionesPorEtapasPorTipoProcesoUpdateSecuencia(EtapasPorTipoProcesoId, AccionesId, Secuencia, UserId)
    End Function

End Class
