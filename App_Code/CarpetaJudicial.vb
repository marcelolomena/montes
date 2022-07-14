'------------------------------------------------------------
' Código generado por ZRISMART SF el 23-02-2012 12:20:25
'------------------------------------------------------------

Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class CarpetaJudicial
    Public Function LeerCarpetaJudicial(ByVal CarpetaJudicialId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialFechaAsignacion As Date, ByRef CarpetaJudicialRut As String, ByRef CarpetaJudicialNombres As String, ByRef CarpetaJudicialApellidos As String, ByRef CarpetaJudicialCiudad As String, ByRef CarpetaJudicialNroOperacion As String, ByRef CarpetaJudicialCapInicial As Double, ByRef CarpetaJudicialMoneda As String, ByRef CarpetaJudicialFechaSuscripcion As Date, ByRef CarpetaJudicialSaldoDeuda As Double, ByRef CarpetaJudicialDivImpago As String, ByRef CarpetaJudicialFechaEntroEnMora As Date, ByRef CarpetaJudicialProcurador As String, ByRef CarpetaJudicialSecretaria As String, ByRef CarpetaJudicialSupervisor As String, ByRef TipoProcesoName As String, ByRef EstadoProcesoCodigo As String, ByRef CarpetaJudicialReceptor As String, ByRef CarpetaJudicialRepresentanteBanco As String, ByRef CarpetaJudicialProfesionRepresentante As String, ByRef BancoPrestamistaName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialCodigo, CarpetaJudicialFechaAsignacion, CarpetaJudicialRut, CarpetaJudicialNombres, CarpetaJudicialApellidos, CarpetaJudicialCiudad, CarpetaJudicialNroOperacion, CarpetaJudicialCapInicial, CarpetaJudicialMoneda, CarpetaJudicialFechaSuscripcion, CarpetaJudicialSaldoDeuda, CarpetaJudicialDivImpago, CarpetaJudicialFechaEntroEnMora, CarpetaJudicialProcurador, CarpetaJudicialSecretaria, CarpetaJudicialSupervisor, TipoProcesoName, EstadoProcesoCodigo, CarpetaJudicialReceptor, CarpetaJudicialRepresentanteBanco, CarpetaJudicialProfesionRepresentante, BancoPrestamistaName "
        sSQL = sSQL & "FROM CarpetaJudicial "
        sSQL = sSQL & "WHERE CarpetaJudicial.CarpetaJudicialId = " & CarpetaJudicialId & " "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CarpetaJudicialCodigo = CStr(dtr("CarpetaJudicialCodigo").ToString)
                If Len(dtr("CarpetaJudicialFechaAsignacion").ToString) = 0 Then
                    CarpetaJudicialFechaAsignacion = CDate(Now())
                Else
                    CarpetaJudicialFechaAsignacion = CDate(dtr("CarpetaJudicialFechaAsignacion").ToString)
                End If
                CarpetaJudicialRut = CStr(dtr("CarpetaJudicialRut").ToString)
                CarpetaJudicialNombres = CStr(dtr("CarpetaJudicialNombres").ToString)
                CarpetaJudicialApellidos = CStr(dtr("CarpetaJudicialApellidos").ToString)
                CarpetaJudicialCiudad = CStr(dtr("CarpetaJudicialCiudad").ToString)
                CarpetaJudicialNroOperacion = CStr(dtr("CarpetaJudicialNroOperacion").ToString)
                If Len(dtr("CarpetaJudicialCapInicial").ToString) = 0 Then
                    CarpetaJudicialCapInicial = 0
                Else
                    CarpetaJudicialCapInicial = CDbl(dtr("CarpetaJudicialCapInicial").ToString)
                End If
                CarpetaJudicialMoneda = CStr(dtr("CarpetaJudicialMoneda").ToString)
                If Len(dtr("CarpetaJudicialFechaSuscripcion").ToString) = 0 Then
                    CarpetaJudicialFechaSuscripcion = "01/01/01"
                Else
                    CarpetaJudicialFechaSuscripcion = CDate(dtr("CarpetaJudicialFechaSuscripcion").ToString)
                End If
                If Len(dtr("CarpetaJudicialSaldoDeuda").ToString) = 0 Then
                    CarpetaJudicialSaldoDeuda = 0
                Else
                    CarpetaJudicialSaldoDeuda = CDbl(dtr("CarpetaJudicialSaldoDeuda").ToString)
                End If
                CarpetaJudicialDivImpago = CStr(dtr("CarpetaJudicialDivImpago").ToString)
                If Len(dtr("CarpetaJudicialFechaEntroEnMora").ToString) = 0 Then
                    CarpetaJudicialFechaEntroEnMora = "01/01/01"
                Else
                    CarpetaJudicialFechaEntroEnMora = CDate(dtr("CarpetaJudicialFechaEntroEnMora").ToString)
                End If
                CarpetaJudicialProcurador = CStr(dtr("CarpetaJudicialProcurador").ToString)
                CarpetaJudicialSecretaria = CStr(dtr("CarpetaJudicialSecretaria").ToString)
                CarpetaJudicialSupervisor = CStr(dtr("CarpetaJudicialSupervisor").ToString)
                CarpetaJudicialReceptor = CStr(dtr("CarpetaJudicialReceptor").ToString)
                TipoProcesoName = CStr(dtr("TipoProcesoName").ToString)
                EstadoProcesoCodigo = CStr(dtr("EstadoProcesoCodigo").ToString)
                CarpetaJudicialRepresentanteBanco = CStr(dtr("CarpetaJudicialRepresentanteBanco").ToString)
                CarpetaJudicialProfesionRepresentante = CStr(dtr("CarpetaJudicialProfesionRepresentante").ToString)
                BancoPrestamistaName = CStr(dtr("BancoPrestamistaName").ToString)
            End While
            LeerCarpetaJudicial = True
            dtr.Close()
        Catch
            LeerCarpetaJudicial = False
        End Try
    End Function
    Public Function LeerCarpetaJudicialByName(ByRef CarpetaJudicialId As Long, ByVal CarpetaJudicialCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialId "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CarpetaJudicialId = CLng(dtr("CarpetaJudicialId").ToString)
            End While
            LeerCarpetaJudicialByName = True
            dtr.Close()
        Catch
            LeerCarpetaJudicialByName = False
        End Try
    End Function
    Public Function LeerCarpetaJudicialIdByCodigo(ByVal CarpetaJudicialCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialId "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "') "
        LeerCarpetaJudicialIdByCodigo = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerCarpetaJudicialIdByCodigo = CLng(dtr("CarpetaJudicialId").ToString)
            End While
            dtr.Close()
        Catch
            LeerCarpetaJudicialIdByCodigo = 0
        End Try
    End Function
    Public Function LeerTipoProcesoNameByCodigo(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TipoProcesoName "
        sSQL = sSQL & "FROM CarpetaJudicial "
        sSQL = sSQL & "WHERE CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' "
        LeerTipoProcesoNameByCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTipoProcesoNameByCodigo = CStr(dtr("TipoProcesoName").ToString)
            End While
            dtr.Close()
        Catch
            LeerTipoProcesoNameByCodigo = ""
        End Try
    End Function
    Public Function LeerCarpetaJudicialCodigoById(ByVal CarpetaJudicialId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialCodigo "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialId = " & CarpetaJudicialId & ") "
        LeerCarpetaJudicialCodigoById = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerCarpetaJudicialCodigoById = CStr(dtr("CarpetaJudicialCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerCarpetaJudicialCodigoById = ""
        End Try
    End Function
    Public Function LeerCarpetaJudicialCodigoByCarpetaJudicialCreditosId(ByVal CarpetaJudicialCreditosId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialCreditos.CarpetaJudicialCodigo "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos "
        sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCreditosId = " & CarpetaJudicialCreditosId
        LeerCarpetaJudicialCodigoByCarpetaJudicialCreditosId = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerCarpetaJudicialCodigoByCarpetaJudicialCreditosId = CStr(dtr("CarpetaJudicialCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerCarpetaJudicialCodigoByCarpetaJudicialCreditosId = ""
        End Try
    End Function


    Public Function CarpetaJudicialUpdate(ByVal CarpetaJudicialId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialFechaAsignacion As Date, ByRef CarpetaJudicialRut As String, ByRef CarpetaJudicialNombres As String, ByRef CarpetaJudicialApellidos As String, ByRef CarpetaJudicialCiudad As String, ByRef CarpetaJudicialNroOperacion As String, ByRef CarpetaJudicialCapInicial As Double, ByRef CarpetaJudicialMoneda As String, ByRef CarpetaJudicialFechaSuscripcion As Date, ByRef CarpetaJudicialSaldoDeuda As Double, ByRef CarpetaJudicialDivImpago As String, ByRef CarpetaJudicialFechaEntroEnMora As Date, ByRef CarpetaJudicialProcurador As String, ByRef CarpetaJudicialSecretaria As String, ByRef CarpetaJudicialSupervisor As String, ByRef TipoProcesoName As String, ByRef EstadoProcesoCodigo As String, ByRef CarpetaJudicialReceptor As String, ByRef CarpetaJudicialRepresentanteBanco As String, ByRef CarpetaJudicialProfesionRepresentante As String, ByVal BancoPrestamistaName As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Acciones As New Acciones
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim t As Integer = 0
        Dim UsuariosCodigo As String = ""
        Dim TipoProceso As New TipoProceso

        Dim AccionesCodigo As String = ""
        Dim AccionesId As Long = 0
        Dim AccionesName As String = ""

        Dim EstadoTareas As New EstadoTareas
        Dim TareasId As Long = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
        Dim TareasCodigo As String = ""
        Dim b As Boolean

        b = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)
        Dim UserIdCodigo As String = ""
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(TareasId)
        Dim TareasLogActividad As String = ""

        TareasLogActividad = "Actualiza Carpeta Judicial: " & CarpetaJudicialNombres & " " & CarpetaJudicialApellidos

        strUpdate = "UPDATE CarpetaJudicial SET "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialFechaAsignacion = '" & AccionesABM.DateTransform(CarpetaJudicialFechaAsignacion) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialRut = '" & CarpetaJudicialRut & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialNombres = '" & CarpetaJudicialNombres & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialApellidos = '" & CarpetaJudicialApellidos & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialCiudad = '" & CarpetaJudicialCiudad & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialNroOperacion = '" & CarpetaJudicialNroOperacion & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialCapInicial = " & CarpetaJudicialCapInicial & ", "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialMoneda = '" & CarpetaJudicialMoneda & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialFechaSuscripcion = '" & AccionesABM.DateTransform(CarpetaJudicialFechaSuscripcion) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialSaldoDeuda = " & CarpetaJudicialSaldoDeuda & ", "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialDivImpago = '" & CarpetaJudicialDivImpago & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialFechaEntroEnMora = '" & AccionesABM.DateTransform(CarpetaJudicialFechaEntroEnMora) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialProcurador = '" & CarpetaJudicialProcurador & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialSecretaria = '" & CarpetaJudicialSecretaria & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialSupervisor = '" & CarpetaJudicialSupervisor & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialReceptor = '" & CarpetaJudicialReceptor & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialRepresentanteBanco = '" & CarpetaJudicialRepresentanteBanco & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialProfesionRepresentante = '" & CarpetaJudicialProfesionRepresentante & "', "
        strUpdate = strUpdate & "CarpetaJudicial.TipoProcesoName = '" & TipoProcesoName & "', "
        strUpdate = strUpdate & "CarpetaJudicial.EstadoProcesoCodigo = '" & EstadoProcesoCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicial.BancoPrestamistaName = '" & BancoPrestamistaName & "', "
        strUpdate = strUpdate & "CarpetaJudicial.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicial.CarpetaJudicialId = " & CarpetaJudicialId
        Try
            CarpetaJudicialUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & CarpetaJudicialCodigo, CarpetaJudicialId, "CarpetaJudicial", "")
            ' Como todo salio bien ahora creo la tarea en la tabla de Tareas, en caso de que no haya sido creada aún
            ' Cada carpeta tiene una y sólo una tarea vigente, la que va pasando de un estado a otro según avance el proceso
            TareasId = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
            If TareasId = 0 Then  ' Crear la Tarea que da inicio al proceso judicial, por ello el uso de algunos valores en duro.
                t = TipoProceso.LeerAccionInicial(TipoProcesoName, AccionesCodigo, AccionesId, AccionesName)
                CarpetaJudicialUpdate = CarpetaJudicial.CrearTareas(CarpetaJudicialCodigo, AccionesCodigo, AccionesId, CarpetaJudicialId, CarpetaJudicialRut, DateAdd(DateInterval.Day, 3, CarpetaJudicialFechaAsignacion), AccionesName, CarpetaJudicialSecretaria, 0, 0, TareasId, UserId)
                If CarpetaJudicialUpdate = 1 Then
                    t = CarpetaJudicial.CarpetaJudicialTareasIdUpdate(CarpetaJudicialId, TareasId, CarpetaJudicialCodigo, AccionesName, UserId)
                    t = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)
                    t = Tareas.TareasEjecutorUpdate(TareasId, TareasCodigo, CarpetaJudicialSecretaria, AccionesCodigo, UserId)
                    b = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)
                    UserIdCodigo = ""
                    EstadoTareasCodigo = Tareas.LeerEstadoTareasCodigo(TareasId)
                    b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
                    TareasLogRol = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(TareasId)
                    TareasLogActividad = "Crea Carpeta Judicial: " & CarpetaJudicialCodigo & " - " & CarpetaJudicialNombres & " " & CarpetaJudicialApellidos
                    t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
                End If
            Else
                t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
            End If
        Catch
            CarpetaJudicialUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & CarpetaJudicialCodigo, CarpetaJudicialId, "CarpetaJudicial", "")
        End Try
    End Function
    Public Function CarpetaJudicialTareasIdUpdate(ByVal CarpetaJudicialId As Long, ByVal TareasId As Long, ByVal CarpetaJudicialCodigo As String, ByVal EstadoProcesosCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim EstadoTareas As New EstadoTareas
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
        Dim t As Integer = 0

        Dim UsuariosCodigo As String = ""
        Dim s As Boolean
        Dim TareasCodigo As String = ""

        s = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UsuariosCodigo)
        s = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)

        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoActualDelaTarea(TareasId)
        Dim TareasLogActividad As String = "Actualiza Carpeta con el Id de la Tarea Vigente: " & TareasId & ", quedando en el estado: " & EstadoProcesosCodigo
        'Este update sólo contempla el cambio del valor del campo Identity asociado en la tabla Tareas.

        'El resto de los campos quedaron grabados en el origen y no son susceptibles de cambio

        strUpdate = "UPDATE CarpetaJudicial SET "
        strUpdate = strUpdate & "CarpetaJudicial.TareasId = " & TareasId & ", "
        strUpdate = strUpdate & "CarpetaJudicial.EstadoProcesoCodigo = '" & EstadoProcesosCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicial.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicial.CarpetaJudicialId = " & CarpetaJudicialId

        Try
            CarpetaJudicialTareasIdUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza el Id de una tarea de " & CarpetaJudicialCodigo, CarpetaJudicialId, "CarpetaJudicial", "Da inicio al proceso")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CarpetaJudicialTareasIdUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el Id de una tarea de " & CarpetaJudicialCodigo, CarpetaJudicialId, "CarpetaJudicial", "No pudo dar inicio al proceso")
        End Try
    End Function
    Public Function CarpetaJudicialIdentificacionDeudorUpdate(ByVal CarpetaJudicialId As Long, ByVal TareasId As Long, ByVal Rut As String, ByVal Nombres As String, ByVal Apellidos As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim EstadoTareas As New EstadoTareas
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
        Dim t As Integer = 0

        Dim UsuariosCodigo As String = ""
        Dim s As Boolean
        Dim TareasCodigo As String = ""

        s = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UsuariosCodigo)
        s = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)

        'Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoActualDelaTarea(TareasId)
        Dim TareasLogRol As String = Usuarios.LeerRolNameByName(UsuariosCodigo)
        Dim TareasLogActividad As String = "Actualiza algunos datos de identificaci&oacute;n del deudor: " & Nombres & " " & Apellidos

        strUpdate = "UPDATE CarpetaJudicial SET "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialRut = '" & Rut & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialNombres = '" & Nombres & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialApellidos = '" & Apellidos & "', "
        strUpdate = strUpdate & "CarpetaJudicial.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicial.CarpetaJudicialId = " & CarpetaJudicialId

        Try
            CarpetaJudicialIdentificacionDeudorUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza algunos datos identificación del deudor " & Nombres & " " & Apellidos, CarpetaJudicialId, "CarpetaJudicial", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CarpetaJudicialIdentificacionDeudorUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar identificación del deudor " & Nombres & " " & Apellidos, CarpetaJudicialId, "CarpetaJudicial", "")
        End Try
    End Function
    Public Function CarpetaJudicialProcuradorUpdate(ByVal CarpetaJudicialId As Long, ByVal TareasId As Long, ByVal Procurador As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim EstadoTareas As New EstadoTareas
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
        Dim t As Integer = 0

        Dim UsuariosCodigo As String = ""
        Dim s As Boolean
        Dim TareasCodigo As String = ""

        s = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UsuariosCodigo)
        s = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)

        'Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoActualDelaTarea(TareasId)
        Dim TareasLogRol As String = Usuarios.LeerRolNameByName(UsuariosCodigo)
        Dim TareasLogActividad As String = "Actualiza procurador"
        'Este update sólo contempla el cambio del valor del campo Identity asociado en la tabla Tareas.

        'El resto de los campos quedaron grabados en el origen y no son susceptibles de cambio

        strUpdate = "UPDATE CarpetaJudicial SET "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialProcurador = '" & Procurador & "', "
        strUpdate = strUpdate & "CarpetaJudicial.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicial.CarpetaJudicialId = " & CarpetaJudicialId

        Try
            CarpetaJudicialProcuradorUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza asignación del procurador " & Procurador, CarpetaJudicialId, "CarpetaJudicial", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CarpetaJudicialProcuradorUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar procurador " & Procurador, CarpetaJudicialId, "CarpetaJudicial", "")
        End Try
    End Function
    Public Function CarpetaJudicialMasAntecedentesUpdate(ByVal CarpetaJudicialId As Long, ByVal TareasId As Long, _
                                                    ByVal Profesion As String, _
                                                     ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim EstadoTareas As New EstadoTareas
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
        Dim t As Integer = 0

        Dim UsuariosCodigo As String = ""
        Dim s As Boolean
        Dim TareasCodigo As String = ""

        s = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UsuariosCodigo)
        s = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)

        'Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoActualDelaTarea(TareasId)
        Dim TareasLogRol As String = Usuarios.LeerRolNameByName(UsuariosCodigo)
        Dim TareasLogActividad As String = "Actualiza Otros Antecedentes del Deudor para preparar el texto de la demanda, su profesi&oacute;n es " & Profesion

        strUpdate = "UPDATE CarpetaJudicial SET "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialProfesion = '" & Profesion & "', "
        strUpdate = strUpdate & "CarpetaJudicial.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicial.CarpetaJudicialId = " & CarpetaJudicialId

        Try
            CarpetaJudicialMasAntecedentesUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza más antecedentes del deudor para preparar la demanda", CarpetaJudicialId, "CarpetaJudicial", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CarpetaJudicialMasAntecedentesUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar más antecedentes del deudor", CarpetaJudicialId, "CarpetaJudicial", "")
        End Try
    End Function
    Public Function CarpetaJudicialJuzgadoRolUpdate(ByVal CarpetaJudicialId As Long, ByVal TareasId As Long, _
                                                    ByVal RolJuicio As String, _
                                                    ByVal Juzgado As String, _
                                                    ByVal FechaDistribucion As Date, _
                                                    ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim EstadoTareas As New EstadoTareas
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
        Dim t As Integer = 0

        Dim UsuariosCodigo As String = ""
        Dim s As Boolean
        Dim TareasCodigo As String = ""

        s = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UsuariosCodigo)
        s = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)

        'Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoActualDelaTarea(TareasId)
        Dim TareasLogRol As String = Usuarios.LeerRolNameByName(UsuariosCodigo)
        Dim TareasLogActividad As String = "Actualiza Rol del Juicio y Juzgado, Rol: " & RolJuicio & ", Juzgado: " & Juzgado & ", Fecha: " & FormatDateTime(FechaDistribucion, DateFormat.ShortDate)
        'Este update sólo contempla el cambio del valor del campo Identity asociado en la tabla Tareas.

        'El resto de los campos quedaron grabados en el origen y no son susceptibles de cambio

        strUpdate = "UPDATE CarpetaJudicial SET "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialRolJuicio = '" & RolJuicio & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialJuzgado = '" & Juzgado & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialFechaDistribucion = '" & AccionesABM.DateTransform(FechaDistribucion) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicial.CarpetaJudicialId = " & CarpetaJudicialId

        Try
            CarpetaJudicialJuzgadoRolUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Rol y Juzgado", CarpetaJudicialId, "CarpetaJudicial", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CarpetaJudicialJuzgadoRolUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar Rol y Juzgado", CarpetaJudicialId, "CarpetaJudicial", "")
        End Try
    End Function
    Public Function CarpetaJudicialFechaPresentacionUpdate(ByVal CarpetaJudicialId As Long, ByVal TareasId As Long, _
                                                    ByVal FechaPresentacion As Date, _
                                                    ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim EstadoTareas As New EstadoTareas
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
        Dim t As Integer = 0

        Dim UsuariosCodigo As String = ""
        Dim s As Boolean
        Dim TareasCodigo As String = ""

        s = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UsuariosCodigo)
        s = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)

        'Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoActualDelaTarea(TareasId)
        Dim TareasLogRol As String = Usuarios.LeerRolNameByName(UsuariosCodigo)
        Dim TareasLogActividad As String = "Actualiza Fecha de Presentaci&oacute;n de la Demanda en el Juzgado asignado, Fecha: " & FormatDateTime(FechaPresentacion, DateFormat.ShortDate)
        'Este update sólo contempla el cambio del valor del campo Identity asociado en la tabla Tareas.

        'El resto de los campos quedaron grabados en el origen y no son susceptibles de cambio

        strUpdate = "UPDATE CarpetaJudicial SET "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialFechaPresentacion = '" & AccionesABM.DateTransform(FechaPresentacion) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicial.CarpetaJudicialId = " & CarpetaJudicialId

        Try
            CarpetaJudicialFechaPresentacionUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Fecha de Presentación", CarpetaJudicialId, "CarpetaJudicial", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CarpetaJudicialFechaPresentacionUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar Fecha de Presentación", CarpetaJudicialId, "CarpetaJudicial", "")
        End Try
    End Function
    Public Function CarpetaJudicialFechaNotificacionUpdate(ByVal CarpetaJudicialId As Long, ByVal TareasId As Long, _
                                                    ByVal FechaNotificacion As Date, _
                                                    ByVal Comuna As String, _
                                                    ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim EstadoTareas As New EstadoTareas
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
        Dim t As Integer = 0

        Dim UsuariosCodigo As String = ""
        Dim s As Boolean
        Dim TareasCodigo As String = ""

        s = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UsuariosCodigo)
        s = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)

        'Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoActualDelaTarea(TareasId)
        Dim TareasLogRol As String = Usuarios.LeerRolNameByName(UsuariosCodigo)
        Dim TareasLogActividad As String = "Actualiza Fecha de Notificaci&oacute;n, Fecha: " & FormatDateTime(FechaNotificacion, DateFormat.ShortDate) & ", Comuna: " & Comuna

        strUpdate = "UPDATE CarpetaJudicial SET "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialComunaNotificacion = '" & Comuna & "', "
        strUpdate = strUpdate & "CarpetaJudicial.CarpetaJudicialFechaNotificacion = '" & AccionesABM.DateTransform(FechaNotificacion) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicial.CarpetaJudicialId = " & CarpetaJudicialId

        Try
            CarpetaJudicialFechaNotificacionUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Fecha y Comuna de Notificación", CarpetaJudicialId, "CarpetaJudicial", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CarpetaJudicialFechaNotificacionUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar Fecha y Comuna de Notificación", CarpetaJudicialId, "CarpetaJudicial", "")
        End Try
    End Function
    Public Function CarpetaJudicialInsert(ByRef CarpetaJudicialId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialFechaAsignacion As Date, ByRef CarpetaJudicialRut As String, ByRef CarpetaJudicialNombres As String, ByRef CarpetaJudicialApellidos As String, ByRef CarpetaJudicialCiudad As String, ByRef CarpetaJudicialNroOperacion As String, ByRef CarpetaJudicialCapInicial As Double, ByRef CarpetaJudicialMoneda As String, ByRef CarpetaJudicialFechaSuscripcion As Date, ByRef CarpetaJudicialSaldoDeuda As Double, ByRef CarpetaJudicialDivImpago As String, ByRef CarpetaJudicialFechaEntroEnMora As Date, ByRef CarpetaJudicialProcurador As String, ByRef CarpetaJudicialSecretaria As String, ByRef CarpetaJudicialSupervisor As String, ByRef TipoProcesoName As String, ByRef EstadoProcesoCodigo As String, ByRef CarpetaJudicialReceptor As String, ByRef CarpetaJudicialRepresentanteBanco As String, ByRef CarpetaJudicialProfesionRepresentante As String, ByRef BancoPrestamistaName As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = CarpetaJudicialCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("CarpetaJudicialId", "CarpetaJudicialCodigo", "CarpetaJudicial", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("CarpetaJudicialId", "CarpetaJudicialCodigo", "CarpetaJudicial", MasterName, CLng(UserId), MasterId)
                'Cuando se inserta un nueva carpeta se dispara la primera tarea del proceso judicial

            End If
            CarpetaJudicialInsert = CarpetaJudicial.CarpetaJudicialUpdate(MasterId, CStr(CarpetaJudicialCodigo), CDate(CarpetaJudicialFechaAsignacion), CStr(CarpetaJudicialRut), CStr(CarpetaJudicialNombres), CStr(CarpetaJudicialApellidos), CStr(CarpetaJudicialCiudad), CStr(CarpetaJudicialNroOperacion), CDbl(CarpetaJudicialCapInicial), CStr(CarpetaJudicialMoneda), CDate(CarpetaJudicialFechaSuscripcion), CDbl(CarpetaJudicialSaldoDeuda), CStr(CarpetaJudicialDivImpago), CDate(CarpetaJudicialFechaEntroEnMora), CStr(CarpetaJudicialProcurador), CStr(CarpetaJudicialSecretaria), CStr(CarpetaJudicialSupervisor), CStr(TipoProcesoName), CStr(EstadoProcesoCodigo), CStr(CarpetaJudicialReceptor), CStr(CarpetaJudicialRepresentanteBanco), CarpetaJudicialProfesionRepresentante, BancoPrestamistaName, UserId)
        Catch
            CarpetaJudicialInsert = 0
        End Try
    End Function
    Public Function LeerTotalCarpetasPorTablasRelacionadas(ByVal CarpetaJudicialCodigo As String, ByVal CarpetaJudicialId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en un Programa Global de Gestión
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM CarpetaJudicial INNER JOIN CarpetaJudicialLog ON CarpetaJudicial.CarpetaJudicialCodigo = CarpetaJudicialLog.CarpetaJudicialCodigo "
        sSQL = sSQL & "WHERE (((CarpetaJudicial.CarpetaJudicialCodigo)= '" & CarpetaJudicialCodigo & "'))"
        LeerTotalCarpetasPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalCarpetasPorTablasRelacionadas = LeerTotalCarpetasPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalCarpetasPorTablasRelacionadas = 0
        End Try
        'Verifica si esta referenciada en una Actividad
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM CarpetaJudicial INNER JOIN Tareas ON CarpetaJudicial.CarpetaJudicialCodigo = Tareas.PGGCodigo "
        sSQL = sSQL & "WHERE (((CarpetaJudicial.CarpetaJudicialCodigo)='" & CarpetaJudicialCodigo & "'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalCarpetasPorTablasRelacionadas = LeerTotalCarpetasPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalCarpetasPorTablasRelacionadas = LeerTotalCarpetasPorTablasRelacionadas + 0
        End Try
    End Function
    Public Function CarpetaJudicialDelete(ByVal CarpetaJudicialId As Long, ByVal CarpetaJudicialCodigo As String, ByVal UserId As Long, ByRef Mensaje As String, ByVal MenuOptionsId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Rol As New Rol

        ' Verificar si la tarea posee evidencias o KPI registrados
        '---------------------------------------------------------
        Total = CarpetaJudicial.LeerTotalCarpetasPorTablasRelacionadas(CarpetaJudicialCodigo, CarpetaJudicialId)

        If Total > 0 Then
            'Mensaje = "Existen " & Total & " registros asociados al Juicio " & CarpetaJudicialCodigo & vbCrLf
            'Mensaje = Mensaje & ", No puede ser eliminado por esta vía, pero cerraremos la carpeta"

            t = CarpetaJudicial.CarpetaJudicialCerrar(CarpetaJudicialId, CarpetaJudicialCodigo, UserId)
            CarpetaJudicialDelete = False
        Else
            Try
                ' Borra registro de la tabla de Programas
                '-------------------------------------
                strUpdate = "DELETE FROM CarpetaJudicial WHERE CarpetaJudicialId = " & CarpetaJudicialId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), MenuOptionsId, "Elimina el Juicio: " & CarpetaJudicialCodigo, CarpetaJudicialId, "CarpetaJudicial", "")
                CarpetaJudicialDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), MenuOptionsId, "Intento fallido de eliminar el Juicio: " & CarpetaJudicialCodigo, CarpetaJudicialId, "CarpetaJudicial", "")
                CarpetaJudicialDelete = False
            End Try
        End If
    End Function
    Public Function LeerReceptorByCarpetaJudicialCodigo(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialReceptor As Receptor "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "') "
        LeerReceptorByCarpetaJudicialCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerReceptorByCarpetaJudicialCodigo = CStr(dtr("Receptor").ToString)
            End While
            dtr.Close()
        Catch
            LeerReceptorByCarpetaJudicialCodigo = ""
        End Try
    End Function
    Public Function LeerProcuradorByCarpetaJudicialCodigo(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialProcurador As Procurador "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "') "
        LeerProcuradorByCarpetaJudicialCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerProcuradorByCarpetaJudicialCodigo = CStr(dtr("Procurador").ToString)
            End While
            dtr.Close()
        Catch
            LeerProcuradorByCarpetaJudicialCodigo = ""
        End Try
    End Function
    Public Function LeerSecretariaByCarpetaJudicialCodigo(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialSecretaria As Secretaria "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "') "
        LeerSecretariaByCarpetaJudicialCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerSecretariaByCarpetaJudicialCodigo = CStr(dtr("Secretaria").ToString)
            End While
            dtr.Close()
        Catch
            LeerSecretariaByCarpetaJudicialCodigo = ""
        End Try
    End Function
    Public Function LeerToolTipTareaByCarpetaJudicialCodigo(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialRut As Rut, CarpetaJudicialNombres As Nombres, CarpetaJudicialApellidos As Apellidos, CarpetaJudicialNroOperacion As Operacion, CarpetaJudicialProcurador As Procurador, CarpetaJudicialSecretaria As Secretaria, CarpetaJudicialSupervisor As Supervisor "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "') "
        LeerToolTipTareaByCarpetaJudicialCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerToolTipTareaByCarpetaJudicialCodigo = "Deudor: " & CStr(dtr("Rut").ToString) & ": " & CStr(dtr("Nombres").ToString) & " " & CStr(dtr("Apellidos").ToString) & "Equipo: " & CStr(dtr("Procurador").ToString) & ", " & CStr(dtr("Secretaria").ToString) & ", " & CStr(dtr("Supervisor").ToString)
            End While
            dtr.Close()
        Catch
            LeerToolTipTareaByCarpetaJudicialCodigo = ""
        End Try
    End Function


    Public Function LeerNroOperacionByCarpetaJudicialCodigo(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialNroOperacion As Operacion "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "') "
        LeerNroOperacionByCarpetaJudicialCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerNroOperacionByCarpetaJudicialCodigo = CStr(dtr("Operacion").ToString)
            End While
            dtr.Close()
        Catch
            LeerNroOperacionByCarpetaJudicialCodigo = ""
        End Try
    End Function
    Public Function LeerSupervisorByCarpetaJudicialCodigo(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialSupervisor As Supervisor "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "') "
        LeerSupervisorByCarpetaJudicialCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerSupervisorByCarpetaJudicialCodigo = CStr(dtr("Supervisor").ToString)
            End While
            dtr.Close()
        Catch
            LeerSupervisorByCarpetaJudicialCodigo = ""
        End Try
    End Function
    Public Function LeerDeudorByCarpetaJudicialCodigo(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialRut As Rut, CarpetaJudicialNombres As Nombres, CarpetaJudicialApellidos As Apellidos, TipoProcesoName As TipoProceso "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "') "
        LeerDeudorByCarpetaJudicialCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerDeudorByCarpetaJudicialCodigo = CStr(dtr("Rut").ToString) & ", " & UCase(CStr(dtr("Apellidos").ToString)) & ", " & UCase(CStr(dtr("Nombres").ToString))
            End While
            dtr.Close()
        Catch
            LeerDeudorByCarpetaJudicialCodigo = ""
        End Try
    End Function
    Public Function LeerDeudorParaGanttByCarpetaJudicialCodigo(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialRut As Rut, CarpetaJudicialNombres As Nombres, CarpetaJudicialApellidos As Apellidos, TipoProcesoName As TipoProceso "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "') "
        LeerDeudorParaGanttByCarpetaJudicialCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerDeudorParaGanttByCarpetaJudicialCodigo = CStr(dtr("Apellidos").ToString)
            End While
            dtr.Close()
        Catch
            LeerDeudorParaGanttByCarpetaJudicialCodigo = ""
        End Try
    End Function
    Public Function LeerDeudorByTareasId(ByVal TareasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialRut As Rut, CarpetaJudicialNombres As Nombres, CarpetaJudicialApellidos As Apellidos "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.TareasId = " & TareasId & ") "
        LeerDeudorByTareasId = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerDeudorByTareasId = CStr(dtr("Rut").ToString) & ", " & CStr(dtr("Nombres").ToString) & ", " & CStr(dtr("Apellidos").ToString)
            End While
            dtr.Close()
        Catch
            LeerDeudorByTareasId = ""
        End Try
    End Function
    Public Function LeerApellidosDeudorByTareasId(ByVal TareasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialApellidos As Apellidos "
        sSQL = sSQL & "FROM CarpetaJudicial, Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasId = " & TareasId & " AND CarpetaJudicial.CarpetaJudicialCodigo = Tareas.PGGCodigo) "
        LeerApellidosDeudorByTareasId = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerApellidosDeudorByTareasId = CStr(dtr("Apellidos").ToString)
            End While
            dtr.Close()
        Catch
            LeerApellidosDeudorByTareasId = ""
        End Try
    End Function
    Public Function LeerRepresentanteBancoByTareasId(ByVal TareasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialRepresentanteBanco As Representante, CarpetaJudicialProfesionRepresentante as Profesion "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.TareasId = " & TareasId & ") "
        LeerRepresentanteBancoByTareasId = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerRepresentanteBancoByTareasId = CStr(dtr("Representante").ToString) & ", " & CStr(dtr("Profesion").ToString) & ", "
            End While
            dtr.Close()
        Catch
            LeerRepresentanteBancoByTareasId = ""
        End Try
    End Function
    Public Function LeerRepresentanteBanco(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialRepresentanteBanco As Representante, CarpetaJudicialProfesionRepresentante as Profesion "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "') "
        LeerRepresentanteBanco = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerRepresentanteBanco = CStr(dtr("Representante").ToString) & ", " & CStr(dtr("Profesion").ToString) & ", "
            End While
            dtr.Close()
        Catch
            LeerRepresentanteBanco = ""
        End Try
    End Function
    Public Function EsConExhorto(ByVal CarpetaJudicialCodigo As String, ByRef Ciudad As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialCiudad As Ciudad "
        sSQL = sSQL & "FROM CarpetaJudicial "
        sSQL = sSQL & "WHERE CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "'"
        EsConExhorto = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If CStr(dtr("Ciudad").ToString) = "Santiago" Then
                    EsConExhorto = False
                Else
                    EsConExhorto = True
                End If
                Ciudad = CStr(dtr("Ciudad").ToString)
            End While
            dtr.Close()
        Catch
            EsConExhorto = False
        End Try
    End Function

    Public Function LeerRutDeudorByCarpetaJudicialCodigo(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialRut As Rut "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "') "
        LeerRutDeudorByCarpetaJudicialCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerRutDeudorByCarpetaJudicialCodigo = CStr(dtr("Rut").ToString)
            End While
            dtr.Close()
        Catch
            LeerRutDeudorByCarpetaJudicialCodigo = ""
        End Try
    End Function
    Public Function DevolverUsuarioPorRol(ByVal RolName As String, ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialProcurador As Procurador, CarpetaJudicialSecretaria As Secretaria, CarpetaJudicialSupervisor As Supervisor, CarpetaJudicialReceptor As Receptor "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "') "
        DevolverUsuarioPorRol = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If RolName = "Procurador" Then DevolverUsuarioPorRol = CStr(dtr("Procurador").ToString)
                If RolName = "Secretaria" Then DevolverUsuarioPorRol = CStr(dtr("Secretaria").ToString)
                If RolName = "Supervisor" Then DevolverUsuarioPorRol = CStr(dtr("Supervisor").ToString)
                If RolName = "Receptor" Then DevolverUsuarioPorRol = CStr(dtr("Receptor").ToString)
            End While
            dtr.Close()
        Catch
            DevolverUsuarioPorRol = ""
        End Try
    End Function
    Public Function LeerTareasIdByCarpetaJudicialCodigo(ByVal CarpetaJudicialCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasId As Id "
        sSQL = sSQL & "FROM (CarpetaJudicial) "
        sSQL = sSQL & "WHERE (CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "') "
        LeerTareasIdByCarpetaJudicialCodigo = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasIdByCarpetaJudicialCodigo = CLng(dtr("Id").ToString)
            End While
            dtr.Close()
        Catch
            LeerTareasIdByCarpetaJudicialCodigo = 0
        End Try
    End Function
    Public Function CrearTareas(ByVal PGGCodigo As String, _
                                         ByVal AccionesCodigo As String, _
                                         ByVal AccionesId As Long, _
                                         ByVal PGGId As Long, _
                                         ByVal StakeholdersCodigo As String, _
                                         ByVal TareasProgramadasFecha As Date, _
                                         ByVal TareasProgramadasDescription As String, _
                                         ByVal UsuariosCodigo As String, _
                                         ByVal AccionesHH As Double, _
                                         ByVal AccionesUSD As Double, _
                                         ByRef TareasId As Long, _
                                         ByVal UserId As Long) As Long

        Dim t As Boolean
        Dim Acciones As New Acciones
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas

        '----------------------------------------
        ' Declaración de Campos de la Tabla Tareas
        '----------------------------------------
        Dim TareasCodigo As String = "" ' Etiqueta : Código Tarea - Control : txtTareasCodigo - Variable : TareasCodigo
        Dim TareasName As String = "" ' Etiqueta : Objetivo - Control : txtTareasName - Variable : TareasName
        Dim TareasDescription As String = "" ' Etiqueta : Descripción - Control : txtTareasDescription - Variable : TareasDescription
        Dim ActividadesSecuencia As Long = 0 ' Etiqueta : Secuencia de Actividad - Control : txtActividadesSecuencia - Variable : ActividadesSecuencia
        Dim TareasMes As Long = 0 ' Etiqueta : Mes - Control : txtTareasMes - Variable : TareasMes
        Dim TareasAno As String = "" ' Etiqueta : Año - Control : txtTareasAno - Variable : TareasAno
        Dim TareasSecuencia As Long = 0 ' Etiqueta : # de actividad - Control : txtTareasSecuencia - Variable : TareasSecuencia
        Dim TareasHH As Double = 0 ' Etiqueta : HH Estimadas - Control : txtTareasHH - Variable : TareasHH
        Dim TareasUSD As Double = 0 ' Etiqueta : Costo Estimado (USD) - Control : txtTareasUSD - Variable : TareasUSD
        Dim DiaMinimoInicio As Long = 0 ' Etiqueta : Mínimo día de inicio - Control : txtDiaMinimoInicio - Variable : DiaMinimoInicio
        Dim DiaMaximoTermino As Long = 0 ' Etiqueta : Max. Día de Término - Control : txtDiaMaximoTermino - Variable : DiaMaximoTermino
        Dim TareasDiaProgramado As Long = 0 ' Etiqueta : Día sugerido - Control : txtTareasDiaProgramado - Variable : TareasDiaProgramado
        Dim TareasTipo As String = "Tarea Programada" ' Etiqueta : Tipo de Tarea - Control : txtTareasTipo - Variable : TareasTipo
        Dim TareasDiaRealTermino As Long = 0 ' Etiqueta : Día Real de Término - Control : txtTareasDiaRealTermino - Variable : TareasDiaRealTermino
        Dim TareasHHConsumidas As Double = 0 ' Etiqueta : HH Consumidas - Control : txtTareasHHConsumidas - Variable : TareasHHConsumidas
        Dim TareasUSDConsumidos As Double = 0 ' Etiqueta : Costo Real (USD) - Control : txtTareasUSDConsumidos - Variable : TareasUSDConsumidos
        Dim EstadoTareasCodigo As String = "Asignada" ' Etiqueta : Estado de Tarea - Control : txtEstadoTareasCodigo - Variable : EstadoTareasCodigo
        Dim TareasEjecutor As String = ""
        '----------------------------------------

        CrearTareas = 0

        Try
            'Inicializo variable para crear una tarea
            TareasCodigo = "" ' Se reasigna más adelante
            TareasName = TareasProgramadasDescription
            TareasDescription = TareasProgramadasDescription
            ActividadesSecuencia = 0  'Para indicar que proviene de una acción y no de una actividad
            TareasMes = Month(TareasProgramadasFecha)
            TareasAno = CStr(Year(TareasProgramadasFecha))
            TareasSecuencia = 1 ' Va a ser siempre 1
            'UsuariosCodigo = Gerencias.LeerUsuarioResponsable(GerenciasCodigo)
            TareasHH = AccionesHH / 100
            TareasUSD = AccionesUSD / 100
            DiaMinimoInicio = Day(TareasProgramadasFecha) ' Esta fecha es con la que se creo la tarea, la fecha puede cambiar, pero esta fecha no cambia
            DiaMaximoTermino = Day(TareasProgramadasFecha) ' idem anterior
            TareasDiaProgramado = Day(TareasProgramadasFecha) ' idem anterior
            TareasTipo = "Tarea Programada"
            TareasDiaRealTermino = 0
            TareasHHConsumidas = 0
            TareasUSDConsumidos = 0
            EstadoTareasCodigo = TareasProgramadasDescription
            TareasCodigo = PGGCodigo & "-" & AccionesCodigo & "-" & StakeholdersCodigo & "-" & TareasAno & "-" & TareasMes
            t = AccionesABM.MasterPartialInsert("TareasId", "TareasCodigo", "Tareas", TareasCodigo, UserId, TareasId)
            TareasCodigo = TareasCodigo & "-" & TareasId 'SE agrega el Id de la Tarea para asegurar que el código sea único
            t = Tareas.TareasUpdate(TareasId, TareasCodigo, TareasName, TareasDescription, PGGCodigo, AccionesCodigo, CLng(ActividadesSecuencia), CLng(TareasMes), TareasAno, CLng(TareasSecuencia), UsuariosCodigo, CDbl(TareasHH * 100), CDbl(TareasUSD * 100), CLng(DiaMinimoInicio), CLng(DiaMaximoTermino), CLng(TareasDiaProgramado), TareasTipo, CLng(TareasDiaRealTermino), CDbl(TareasHHConsumidas * 100), CDbl(TareasUSDConsumidos * 100), EstadoTareasCodigo, UserId)
            t = Tareas.TareasEjecutorUpdate(TareasId, TareasCodigo, UsuariosCodigo, AccionesCodigo, UserId)
            CrearTareas = 1
        Catch ex As Exception
            CrearTareas = 0
        End Try

    End Function

    Public Function LeerIdentificacionBasicaDemandados(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim CodigoHTML As String = ""

        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialRut As Rut, CarpetaJudicial.CarpetaJudicialNombres As Nombres, CarpetaJudicial.CarpetaJudicialApellidos As Apellidos "
        sSQL = sSQL & "FROM CarpetaJudicial "
        sSQL = sSQL & "WHERE CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "'"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<b>" & UCase(CStr(dtr("Nombres").ToString)) & " " & UCase(CStr(dtr("Apellidos").ToString) & "<br />RUT: " & CStr(dtr("Rut").ToString)) & "</b><br />"
            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try

        sSQL = "SELECT CarpetaJudicialAvales.CarpetaJudicialAvalesRut As Rut, CarpetaJudicialAvales.CarpetaJudicialAvalesNombres As Nombres, CarpetaJudicialAvales.CarpetaJudicialAvalesApellidos As Apellidos "
        sSQL = sSQL & "FROM CarpetaJudicialAvales "
        sSQL = sSQL & "WHERE CarpetaJudicialAvales.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "'"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<b>" & UCase(CStr(dtr("Nombres").ToString)) & " " & UCase(CStr(dtr("Apellidos").ToString) & "<br />RUT: " & CStr(dtr("Rut").ToString)) & "</b><br />"
            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try

        LeerIdentificacionBasicaDemandados = CodigoHTML
    End Function
    Public Function LeerNombreCompletoDemandados(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim CodigoHTML As String = ""
        Dim i As Integer = 0

        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialNombres As Nombres, CarpetaJudicial.CarpetaJudicialApellidos As Apellidos "
        sSQL = sSQL & "FROM CarpetaJudicial "
        sSQL = sSQL & "WHERE CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "'"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & "Conforme a lo anterior, vengo en demandar ejecutivamente a <b>" & UCase(CStr(dtr("Nombres").ToString)) & " " & UCase(CStr(dtr("Apellidos").ToString)) & "</b>"
            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try

        sSQL = "SELECT CarpetaJudicialAvales.CarpetaJudicialAvalesRut As Rut, CarpetaJudicialAvales.CarpetaJudicialAvalesNombres As Nombres, CarpetaJudicialAvales.CarpetaJudicialAvalesApellidos As Apellidos "
        sSQL = sSQL & "FROM CarpetaJudicialAvales "
        sSQL = sSQL & "WHERE CarpetaJudicialAvales.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "'"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    CodigoHTML = CodigoHTML & ", tambi&eacute;n representada por <b>" & UCase(CStr(dtr("Nombres").ToString)) & " " & UCase(CStr(dtr("Apellidos").ToString)) & "</b>"
                Else
                    CodigoHTML = CodigoHTML & ", <b>" & UCase(CStr(dtr("Nombres").ToString)) & " " & UCase(CStr(dtr("Apellidos").ToString)) & "</b>"
                End If
            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try

        Select Case i
            Case 0
                CodigoHTML = CodigoHTML & " por "
            Case 1
                CodigoHTML = CodigoHTML & " y a &eacute;ste &uacute;ltimo en  su calidad de fiador y codeudor solidario  por  "
            Case Else
                CodigoHTML = CodigoHTML & " y a &eacute;stos &uacute;ltimos en  su calidad de fiadores y codeudores solidarios por  "
        End Select


        LeerNombreCompletoDemandados = CodigoHTML
    End Function
    Public Function LeerNombreCompletoDemandadosPORTANTO(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim CodigoHTML As String = ""
        Dim i As Integer = 0

        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialNombres As Nombres, CarpetaJudicial.CarpetaJudicialApellidos As Apellidos "
        sSQL = sSQL & "FROM CarpetaJudicial "
        sSQL = sSQL & "WHERE CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "'"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<b>" & UCase(CStr(dtr("Nombres").ToString)) & " " & UCase(CStr(dtr("Apellidos").ToString)) & "</b>"
            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try

        sSQL = "SELECT CarpetaJudicialAvales.CarpetaJudicialAvalesRut As Rut, CarpetaJudicialAvales.CarpetaJudicialAvalesNombres As Nombres, CarpetaJudicialAvales.CarpetaJudicialAvalesApellidos As Apellidos "
        sSQL = sSQL & "FROM CarpetaJudicialAvales "
        sSQL = sSQL & "WHERE CarpetaJudicialAvales.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "'"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    CodigoHTML = CodigoHTML & " y a <b>" & UCase(CStr(dtr("Nombres").ToString)) & " " & UCase(CStr(dtr("Apellidos").ToString)) & "</b>"
                Else
                    CodigoHTML = CodigoHTML & " y a <b>" & UCase(CStr(dtr("Nombres").ToString)) & " " & UCase(CStr(dtr("Apellidos").ToString)) & "</b>"
                End If
            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try

        Select Case i
            Case 0
                CodigoHTML = CodigoHTML & ", ordenar que se despache mandamiento de ejecuci&oacute;n y embargo en su contra por "
            Case 1
                CodigoHTML = CodigoHTML & " en su car&aacute;cter de  aval  y  codeudor  solidario, ambos ya individualizados y mandatarios rec&iacute;procos entre s&iacute;, ordenar que se despache mandamiento de ejecuci&oacute;n y embargo en su contra por  "
            Case Else
                CodigoHTML = CodigoHTML & " y a &eacute;stos &uacute;ltimos en  su calidad de fiadores y codeudores solidarios por, todos ya individualizados y con mandatarios rec&iacute;procos entre s&iacute;, ordenar que se despache mandamiento de ejecuci&oacute;n y embargo en su contra por  "
        End Select


        LeerNombreCompletoDemandadosPORTANTO = CodigoHTML
    End Function

    Public Function LeerIdentificacionProfesionDireccion(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim CodigoHTML As String = ""

        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialRut As Rut, CarpetaJudicial.CarpetaJudicialNombres As Nombres, CarpetaJudicial.CarpetaJudicialApellidos As Apellidos, CarpetaJudicial.CarpetaJudicialProfesion As Profesion "
        sSQL = sSQL & "FROM CarpetaJudicial "
        sSQL = sSQL & "WHERE CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "'"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<b>" & UCase(CStr(dtr("Nombres").ToString)) & " " & UCase(CStr(dtr("Apellidos").ToString)) & "</b>, " & dtr("Profesion").ToString & ", con domicilio en "
            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try

        sSQL = "SELECT CarpetaJudicialDirecciones.CarpetaJudicialDireccionesDireccion As Direccion, CarpetaJudicialDirecciones.CarpetaJudicialDireccionesLocalidad As Localidad, Comunas.ComunasName As Comuna "
        sSQL = sSQL & "FROM CarpetaJudicialDirecciones, Comunas "
        sSQL = sSQL & "WHERE CarpetaJudicialDirecciones.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' AND Comunas.ComunasCodigo = CarpetaJudicialDirecciones.ComunasCodigo"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & CStr(dtr("Direccion").ToString) & ", Comuna de " & CStr(dtr("Comuna").ToString & ", " & CStr(dtr("Localidad").ToString)) & ", "
            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try

        LeerIdentificacionProfesionDireccion = CodigoHTML
    End Function
    Public Function LeerMasterNameMasterId(ByVal CarpetaJudicialCreditosId As Long, ByRef MasterId As Long, ByRef MasterName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialId As MasterId, CarpetaJudicial.CarpetaJudicialCodigo As MasterName "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos INNER JOIN CarpetaJudicial ON CarpetaJudicialCreditos.CarpetaJudicialCodigo = CarpetaJudicial.CarpetaJudicialCodigo "
        sSQL = sSQL & "WHERE (((CarpetaJudicialCreditos.CarpetaJudicialCreditosId)=" & CarpetaJudicialCreditosId & "))"

        LeerMasterNameMasterId = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                MasterId = CLng(dtr("MasterId").ToString)
                MasterName = CStr(dtr("MasterName").ToString)
                LeerMasterNameMasterId = True
            End While
            dtr.Close()
        Catch
            LeerMasterNameMasterId = False
        End Try
    End Function
    Public Function LeerNombreCompletoDeudor(ByVal CarpetaJudicialCreditosId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim CodigoHTML As String = ""

        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialNombres As Nombres, CarpetaJudicial.CarpetaJudicialApellidos As Apellidos "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos INNER JOIN CarpetaJudicial ON CarpetaJudicialCreditos.CarpetaJudicialCodigo = CarpetaJudicial.CarpetaJudicialCodigo "
        sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCreditosId=" & CarpetaJudicialCreditosId
        LeerNombreCompletoDeudor = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<b>" & UCase(CStr(dtr("Nombres").ToString)) & " " & UCase(CStr(dtr("Apellidos").ToString)) & "</b>"
            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try
        LeerNombreCompletoDeudor = CodigoHTML
    End Function
    Public Function ParrafoHipotecaPRIMEROTROSI(ByVal CarpetaJudicialCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"


        sSQL = "SELECT CarpetaJudicialHipotecas.CarpetaJudicialHipotecasDescription As Descripcion, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionFojas As Fojas, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionNumero As Numero, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionAno As Ano, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionCiudad As Ciudad "
        sSQL = sSQL & "FROM CarpetaJudicialHipotecas "
        sSQL = sSQL & "WHERE CarpetaJudicialHipotecas.CarpetaJudicialCodigo='" & CarpetaJudicialCodigo & "'"

        Dim CodigoHTML As String = ""

        ParrafoHipotecaPRIMEROTROSI = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    CodigoHTML = "el inmueble hipotecado en favor del banco Scotiabank consistente en " & dtr("Descripcion").ToString & " inscrita a su nombre fojas " & dtr("Fojas").ToString & " N&uacute;mero " & dtr("Numero").ToString & " del Registro de Propiedad del Conservador de Bienes Ra&iacute;ces de " & dtr("Ciudad").ToString & " del a&ntilde;o " & dtr("Ano").ToString
                Else
                    CodigoHTML = CodigoHTML & ", el inmueble hipotecado en favor del banco Scotiabank consistente en " & dtr("Descripcion").ToString & " inscrita a su nombre fojas " & dtr("Fojas").ToString & " N&uacute;mero " & dtr("Numero").ToString & " del Registro de Propiedad del Conservador de Bienes Ra&iacute;ces de " & dtr("Ciudad").ToString & " del a&ntilde;o " & dtr("Ano").ToString
                End If

            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try

        ParrafoHipotecaPRIMEROTROSI = CodigoHTML

    End Function
    Public Function ParrafoEscriturasPublicas(ByVal CarpetaJudicialCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim CarpetaJudicialHipotecas As New CarpetaJudicialHipotecas
        Dim CarpetaJudicialAvales As New CarpetaJudicialAvales
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim j As Integer = 0 'Cuenta los distintos

        Dim Fecha As Date
        Dim Ciudad As String = ""
        Dim Notario As String = ""
        Dim CodigoHTML As String = ""
        Dim TotalHipotecas As Integer = CarpetaJudicialHipotecas.TotalHipotecas(CarpetaJudicialCodigo)
        Dim TotalAvales As Integer = CarpetaJudicialAvales.TotalAvales(CarpetaJudicialCodigo) - 1

        sSQL = "Select CarpetaJudicialCreditosFechaEscritura As Fecha, CarpetaJudicialCreditosCiudadEscritura As Ciudad, CarpetaJudicialCreditosNotarioEscritura As Notario "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos "
        sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' AND CarpetaJudicialCreditos.TipoCreditoName <> 'Pagare' "
        sSQL = sSQL & "ORDER BY CarpetaJudicialCreditosFechaEscritura, CarpetaJudicialCreditosCiudadEscritura, CarpetaJudicialCreditosNotarioEscritura"

        'la escritura pública de fecha 24 de Julio de 2007, otorgada en la Notaría de Santiago de don Gonzalo de la Cuadra Fabres en la cual constan los mutuos otorgados por el banco Scotiabank Chile al deudor y la hipoteca constituida por ella referida en lo principal, como asimismo el mandato judicial recíproco


        ParrafoEscriturasPublicas = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    Fecha = CDate(dtr("Fecha").ToString)
                    Ciudad = CStr(dtr("Ciudad").ToString)
                    Notario = CStr(dtr("Notario").ToString)
                    CodigoHTML = "la escritura p&uacute;blica de fecha " & Lecturas.FechaEscrita(Fecha) & ", otorgada en la Notar&iacute;a de " & Ciudad & " de " & Notario
                    j = 1
                Else
                    If (Fecha = CDate(dtr("Fecha").ToString) And Ciudad = CStr(dtr("Ciudad").ToString) And Notario = CStr(dtr("Notario").ToString)) Then
                        j = j 'se mantiene el valo de j, hay igualdad
                    Else
                        Fecha = CDate(dtr("Fecha").ToString)
                        Ciudad = CStr(dtr("Ciudad").ToString)
                        Notario = CStr(dtr("Notario").ToString)
                        CodigoHTML = CodigoHTML & ", la escritura p&uacute;blica de fecha " & Lecturas.FechaEscrita(Fecha) & ", otorgada en la Notar&iacute;a de " & Ciudad & " de " & Notario
                        j = j + 1
                    End If
                End If
            End While
            dtr.Close()
        Catch
            ParrafoEscriturasPublicas = ""
        End Try

        If j > 1 Then
            CodigoHTML = CodigoHTML & " en las cuales  "
            If i > 1 Then
                CodigoHTML = CodigoHTML & " constan los mutuos otorgados por el banco Scotiabank Chile al deudor"
            Else
                CodigoHTML = CodigoHTML & " consta el mutuo otorgado por el banco Scotiabank Chile al deudor"
            End If

            If TotalHipotecas > 0 Then
                If TotalHipotecas = 1 Then
                    CodigoHTML = CodigoHTML & " y la hipoteca constituida por el referida en lo principal"
                Else
                    CodigoHTML = CodigoHTML & " y las hipotecas constituidas por el referidas en lo principal"
                End If
            End If
            If TotalAvales > 0 Then
                If TotalAvales = 1 Then
                    CodigoHTML = CodigoHTML & ", como asimismo el mandato judicial rec&iacute;proco"
                Else
                    CodigoHTML = CodigoHTML & ", como asimismo los mandatos judiciales rec&iacute;procos"
                End If
            End If

        Else
            CodigoHTML = CodigoHTML & " en la cual "
            If i > 1 Then
                CodigoHTML = CodigoHTML & " constan los mutuos otorgados por el banco Scotiabank Chile al deudor"
            Else
                CodigoHTML = CodigoHTML & " consta el mutuo otorgado por el banco Scotiabank Chile al deudor"
            End If

            If TotalHipotecas > 0 Then
                If TotalHipotecas = 1 Then
                    CodigoHTML = CodigoHTML & " y la hipoteca constituida por el referida en lo principal"
                Else
                    CodigoHTML = CodigoHTML & " y las hipotecas constituidas por el referidas en lo principal"
                End If
            End If
            If TotalAvales > 0 Then
                If TotalAvales = 1 Then
                    CodigoHTML = CodigoHTML & ", como asimismo el mandato judicial rec&iacute;proco"
                Else
                    CodigoHTML = CodigoHTML & ", como asimismo los mandatos judiciales rec&iacute;procos"
                End If
            End If
        End If

        ParrafoEscriturasPublicas = CodigoHTML

    End Function

    Public Function Vaelquintotrosi(ByVal CarpetaJudicialCodigo As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim j As Integer = 0 'Cuenta los distintos

        Dim Banco As String = ""
        Dim CodigoHTML As String = ""

        sSQL = "Select BancoPrestamistaName As Banco "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos "
        sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' "
        sSQL = sSQL & "ORDER BY BancoPrestamistaName"

        Vaelquintotrosi = False

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If dtr("Banco") = "Banco del Desarrollo" Then
                    Vaelquintotrosi = True
                End If
            End While
            dtr.Close()
        Catch
            Vaelquintotrosi = False
        End Try
    End Function
    Public Function ListarDatosDelProcesoJudicial(ByVal CarpetaJudicialId As Long, Optional ByVal Clase As String = "invisible", Optional ByVal Formato As String = "CodigoHTML") As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim sSQL As String
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Usuarios As New Usuarios

        ListarDatosDelProcesoJudicial = ""


        If Formato = "CodigoHTML" Then
            CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
            CodigoHTML = CodigoHTML & "<tr>"
            CodigoHTML = CodigoHTML & "<td><h1>" & "Responsables del proceso judicial" & "</h1></td>"
            CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & "DatosResponsables" & "')"" /></td>"
            CodigoHTML = CodigoHTML & "</tr>"
            CodigoHTML = CodigoHTML & "</table>"
            CodigoHTML = CodigoHTML & "<div id=""subgrilla" & "DatosResponsables" & """ class=""" & Clase & """>"
        End If

        sSQL = "Select CarpetaJudicialCodigo, CarpetaJudicialFechaAsignacion, CarpetaJudicialProcurador, CarpetaJudicialSecretaria, CarpetaJudicialSupervisor, EstadoProcesoCodigo, CarpetaJudicialReceptor, CarpetaJudicialRepresentanteBanco, CarpetaJudicialProfesionRepresentante "
        sSQL = sSQL & "FROM CarpetaJudicial "
        sSQL = sSQL & "WHERE CarpetaJudicial.CarpetaJudicialId = " & CarpetaJudicialId & " "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If Formato = "CodigoHTML" Then
                    CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
                Else
                    CodigoHTML = CodigoHTML & "<table width=""660"" border=""1"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Verdana;font-size:8pt;border:1px solid #FFFFFF;"">"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<th width=""150"" align=""left"">Fecha Asignaci&oacute;n</th>"
                If Len(dtr("CarpetaJudicialFechaAsignacion").ToString) = 0 Then
                    CodigoHTML = CodigoHTML & "<td width=""500"" colspan=""5"">" & CDate(Now()) & "</td>"
                Else
                    CodigoHTML = CodigoHTML & "<td width=""500"" colspan=""5"">" & FormatDateTime(CDate(dtr("CarpetaJudicialFechaAsignacion").ToString), DateFormat.ShortDate) & "</td>"
                End If
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<th width=""150"" align=""left"">Procurador</th>"
                CodigoHTML = CodigoHTML & "<td width=""500"" colspan=""5"">" & Usuarios.LeerUsuariosDescriptionByName(CStr(dtr("CarpetaJudicialProcurador").ToString)) & ", correo: " & CStr(dtr("CarpetaJudicialProcurador").ToString) & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<th width=""150"" align=""left"">Secretaria</th>"
                CodigoHTML = CodigoHTML & "<td width=""500"" colspan=""5"">" & Usuarios.LeerUsuariosDescriptionByName(CStr(dtr("CarpetaJudicialSecretaria").ToString)) & ", correo: " & CStr(dtr("CarpetaJudicialSecretaria").ToString) & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<th width=""150"" align=""left"">Supervisor</th>"
                CodigoHTML = CodigoHTML & "<td width=""500"" colspan=""5"">" & Usuarios.LeerUsuariosDescriptionByName(CStr(dtr("CarpetaJudicialSupervisor").ToString)) & ", correo: " & CStr(dtr("CarpetaJudicialSupervisor").ToString) & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<th width=""150"" align=""left"">Receptor</th>"
                CodigoHTML = CodigoHTML & "<td width=""500"" colspan=""5"">" & Usuarios.LeerUsuariosDescriptionByName(CStr(dtr("CarpetaJudicialReceptor").ToString)) & ", correo: " & CStr(dtr("CarpetaJudicialReceptor").ToString) & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<th width=""150"" align=""left"">Representante Banco</th>"
                CodigoHTML = CodigoHTML & "<td width=""500"" colspan=""5"">" & CStr(dtr("CarpetaJudicialRepresentanteBanco").ToString) & ", " & CStr(dtr("CarpetaJudicialProfesionRepresentante").ToString) & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<th width=""150"" align=""left"">Estado del Proceso</th>"
                CodigoHTML = CodigoHTML & "<td width=""500"" colspan=""5"">" & CStr(dtr("EstadoProcesoCodigo").ToString) & "</td>"
                CodigoHTML = CodigoHTML & "</tr></table>"
            End While
            dtr.Close()
        Catch

        End Try
        If Formato = "CodigoHTML" Then
            CodigoHTML = CodigoHTML & "</div>"
        End If
        ListarDatosDelProcesoJudicial = CodigoHTML
    End Function
    Public Function LeerFechaAdjudicacion(ByVal CarpetaJudicialCodigo As String) As Date
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialFechaAsignacion "
        sSQL = sSQL & "FROM CarpetaJudicial "
        sSQL = sSQL & "WHERE CarpetaJudicial.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' "
        LeerFechaAdjudicacion = CDate(Now())
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If Len(dtr("CarpetaJudicialFechaAsignacion").ToString) = 0 Then
                    LeerFechaAdjudicacion = CDate(Now())
                Else
                    LeerFechaAdjudicacion = CDate(dtr("CarpetaJudicialFechaAsignacion").ToString)
                End If

            End While
            dtr.Close()
        Catch
            LeerFechaAdjudicacion = CDate(Now())
        End Try
    End Function
    Public Function ProcesosVigentesPorTipo(ByVal TipoProcesoName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim CodigoHTML As String = ""
        Dim Acciones As New Acciones
        Dim DiasDeDesviacion As Integer = 0
        Dim SemaforoImg As String = ""
        Dim SemaforoAlt As String = ""
        Dim HTMLSemaforo As String = ""
        Dim ToolTipAtraso As String = ""
        Dim Tareas As New Tareas
        Dim AccionesCodigo As String = ""
        Dim ColorDeLaTarea As String = ""

        sSQL = "Select CarpetaJudicialCodigo, CarpetaJudicialId, CarpetaJudicialNombres, CarpetaJudicialApellidos, EstadoProcesoCodigo, CarpetaJudicial.CarpetaJudicialJuzgado As Juzgado, CarpetaJudicial.CarpetaJudicialRolJuicio As Rol "
        sSQL = sSQL & "FROM CarpetaJudicial LEFT JOIN Juzgados ON CarpetaJudicial.CarpetaJudicialJuzgado = Juzgados.JuzgadosName "
        'sSQL = sSQL & "WHERE (CarpetaJudicial.TipoProcesoName = '" & TipoProcesoName & "' AND CarpetaJudicial.EstadoProcesoCodigo <> 'Cerrado') "
        sSQL = sSQL & "WHERE (CarpetaJudicial.TipoProcesoName = '" & TipoProcesoName & "' AND (CarpetaJudicial.EstadoProcesoCodigo <> 'Cerrado' AND CarpetaJudicial.EstadoProcesoCodigo <> '')) "
        sSQL = sSQL & "ORDER BY Juzgados.JuzgadosSecuencia, CarpetaJudicial.CarpetaJudicialJuzgado, CarpetaJudicial.CarpetaJudicialRolJuicio, CarpetaJudicial.CarpetaJudicialApellidos"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ColorDeLaTarea = Tareas.ColorDeLaTarea(dtr("CarpetaJudicialCodigo").ToString, AccionesCodigo, ToolTipAtraso, SemaforoImg, SemaforoAlt)
                HTMLSemaforo = "<a href=""ImprimirPerfilCarpetaEnWord.aspx?Id=" & dtr("CarpetaJudicialId").ToString & """ target=""_blank"" ><img src=""" & SemaforoImg & """ alt=""" & SemaforoAlt & """ width=""16"" height=""16"" hspace=""1"" vspace=""0"" border=""0"" align=""absmiddle"" title=""" & ToolTipAtraso & "De un click de mouse para ver detalle del proceso"" /></a>"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td width=""180"">" & HTMLSemaforo & " <a href=""ImprimirPlanEnWord.aspx?Id=" & dtr("CarpetaJudicialId").ToString & """ target=""_blank"" title=""De un click de mouse para ver el plan de trabajo"" >" & UCase(CStr(dtr("CarpetaJudicialApellidos").ToString)) & "</a><br />" & CStr(dtr("Juzgado").ToString) & "<br />" & CStr(dtr("Rol").ToString) & "</td>"
                CodigoHTML = CodigoHTML & "<td width=""20""><img src=""" & ColorDeLaTarea & """ alt=""?"" style=""cursor:hand; vertical-align:bottom;"" width=""12"" height=""12"" hspace=""5"" border=""0"" title=""Editar el registro de la tarea"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" /><br />"
                CodigoHTML = CodigoHTML & "<br /><a href=""IndexSGI.aspx?PaginaWebName=Ficha de CarpetaJudicial&MenuOptionsId=425&Id=" & dtr("CarpetaJudicialId").ToString & """><img src=""img/editar.png"" alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" width=""12"" height=""12"" border=""0"" title=""Editar la Carpeta Judicial"" /></a></td>"
                CodigoHTML = CodigoHTML & Acciones.ListarSituacionPorEtapasDelProceso(dtr("EstadoProcesoCodigo").ToString, AccionesCodigo)
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try
        ProcesosVigentesPorTipo = CodigoHTML
    End Function
    Public Function InformeEstadoDiario(ByVal TipoProcesoName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim CodigoHTML As String = ""
        Dim Acciones As New Acciones
        Dim DiasDeDesviacion As Integer = 0
        Dim SemaforoImg As String = ""
        Dim SemaforoAlt As String = ""
        Dim HTMLSemaforo As String = ""
        Dim ToolTipAtraso As String = ""
        Dim Apellidos As String = ""
        Dim i As Integer = 0
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim AccionesCodigo As String = ""
        Dim Tareas As New Tareas

        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialJuzgado As Juzgado, CarpetaJudicial.CarpetaJudicialRolJuicio As Rol, CarpetaJudicial.CarpetaJudicialApellidos As Apellidos, CarpetaJudicial.CarpetaJudicialRut As Rut, CarpetaJudicial.EstadoProcesoCodigo As Estado, CarpetaJudicial.TareasId, CarpetaJudicial.CarpetaJudicialId, CarpetaJudicial.CarpetaJudicialCodigo "
        sSQL = sSQL & "FROM CarpetaJudicial LEFT JOIN Juzgados ON CarpetaJudicial.CarpetaJudicialJuzgado = Juzgados.JuzgadosName "
        'sSQL = sSQL & "WHERE (CarpetaJudicial.TipoProcesoName = '" & TipoProcesoName & "' AND CarpetaJudicial.EstadoProcesoCodigo <> 'Cerrado') "
        sSQL = sSQL & "WHERE (CarpetaJudicial.TipoProcesoName = '" & TipoProcesoName & "' AND (CarpetaJudicial.EstadoProcesoCodigo <> 'Cerrado' AND CarpetaJudicial.EstadoProcesoCodigo <> '')) "
        sSQL = sSQL & "ORDER BY Juzgados.JuzgadosSecuencia, CarpetaJudicial.CarpetaJudicialJuzgado, CarpetaJudicial.CarpetaJudicialRolJuicio, CarpetaJudicial.CarpetaJudicialApellidos"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Juzgado").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Rol").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & UCase(dtr("Apellidos").ToString) & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Rut").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Estado").ToString & "</td>"
                CodigoHTML = CodigoHTML & CarpetaJudicial.LeerUltimaActividad(CLng(dtr("TareasId").ToString))
                'CodigoHTML = CodigoHTML & "<td width=""20""><img src=""img/editar.png"" alt=""?"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Registrar Tareas, Consultar proceso y/o enviar mensaje al responsable"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" /></td>"

                CodigoHTML = CodigoHTML & "<td width=""20""><img src=""" & Tareas.ColorDeLaTarea(dtr("CarpetaJudicialCodigo").ToString, AccionesCodigo, ToolTipAtraso, SemaforoImg, SemaforoAlt) & """ alt=""?"" style=""cursor:hand; vertical-align:bottom;"" width=""12"" height=""12"" hspace=""5"" border=""0"" title=""Editar el registro de la tarea"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" /><br />"
                CodigoHTML = CodigoHTML & "<br /><a href=""IndexSGI.aspx?PaginaWebName=Ficha de CarpetaJudicial&MenuOptionsId=425&Id=" & dtr("CarpetaJudicialId").ToString & """><img src=""img/editar.png"" alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" width=""12"" height=""12"" border=""0"" title=""Editar la Carpeta Judicial"" /></a></td>"


                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try
        InformeEstadoDiario = CodigoHTML
    End Function
    Public Function LeerUltimaActividad(ByVal TareasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim CodigoHTML As String = ""
        Dim i = 0

        sSQL = "SELECT TareasLog.TareasLogTime As Fecha, TareasLog.TareasLogActividad As Actividad "
        sSQL = sSQL & "FROM Tareas INNER JOIN TareasLog ON Tareas.TareasCodigo = TareasLog.TareasCodigo "
        sSQL = sSQL & "WHERE(((Tareas.TareasId) = " & TareasId & ")) "
        sSQL = sSQL & "ORDER BY TareasLog.TareasLogTime DESC"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    CodigoHTML = CodigoHTML & "<td>" & FormatDateTime(dtr("Fecha").ToString, DateFormat.ShortDate) & "</td>"
                    CodigoHTML = CodigoHTML & "<td>" & dtr("Actividad").ToString & "</td>"
                End If
            End While
            dtr.Close()
        Catch
            CodigoHTML = CodigoHTML & "<td></td><td></td>"
        End Try
        LeerUltimaActividad = CodigoHTML
    End Function
    Public Function InformeMovimientoDiario(ByVal TipoProcesoName As String, ByVal Fecha As Date) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim CodigoHTML As String = ""
        Dim Acciones As New Acciones
        Dim DiasDeDesviacion As Integer = 0
        Dim SemaforoImg As String = ""
        Dim SemaforoAlt As String = ""
        Dim HTMLSemaforo As String = ""
        Dim ToolTipAtraso As String = ""
        Dim Apellidos As String = ""
        Dim i As Integer = 0
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim AccionesCodigo As String = ""
        Dim Tareas As New Tareas

        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialJuzgado As Juzgado, CarpetaJudicial.CarpetaJudicialRolJuicio As Rol, CarpetaJudicial.CarpetaJudicialApellidos As Apellidos, CarpetaJudicial.CarpetaJudicialRut As Rut, CarpetaJudicial.EstadoProcesoCodigo As Estado, CarpetaJudicial.TareasId, CarpetaJudicial.CarpetaJudicialId, CarpetaJudicial.CarpetaJudicialCodigo "
        sSQL = sSQL & "FROM CarpetaJudicial LEFT JOIN Juzgados ON CarpetaJudicial.CarpetaJudicialJuzgado = Juzgados.JuzgadosName "
        'sSQL = sSQL & "WHERE (CarpetaJudicial.TipoProcesoName = '" & TipoProcesoName & "' AND CarpetaJudicial.EstadoProcesoCodigo <> 'Cerrado')"
        sSQL = sSQL & "WHERE (CarpetaJudicial.TipoProcesoName = '" & TipoProcesoName & "' AND (CarpetaJudicial.EstadoProcesoCodigo <> 'Cerrado' AND CarpetaJudicial.EstadoProcesoCodigo <> '')) "
        sSQL = sSQL & "ORDER BY Juzgados.JuzgadosSecuencia, CarpetaJudicial.CarpetaJudicialJuzgado, CarpetaJudicial.CarpetaJudicialRolJuicio, CarpetaJudicial.CarpetaJudicialApellidos"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Juzgado").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Rol").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & UCase(dtr("Apellidos").ToString) & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Rut").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Estado").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & CarpetaJudicial.LeerActividadesDiarias(CLng(dtr("TareasId").ToString), Fecha) & "</td>"
                'CodigoHTML = CodigoHTML & "<td width=""20""><img src=""img/editar.png"" alt=""?"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Registrar Tareas, Consultar proceso y/o enviar mensaje al responsable"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" /></td>"

                CodigoHTML = CodigoHTML & "<td width=""20""><img src=""" & Tareas.ColorDeLaTarea(dtr("CarpetaJudicialCodigo").ToString, AccionesCodigo, ToolTipAtraso, SemaforoImg, SemaforoAlt) & """ alt=""?"" style=""cursor:hand; vertical-align:bottom;"" width=""12"" height=""12"" hspace=""5"" border=""0"" title=""Editar el registro de la tarea"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" /><br />"
                CodigoHTML = CodigoHTML & "<br /><a href=""IndexSGI.aspx?PaginaWebName=Ficha de CarpetaJudicial&MenuOptionsId=425&Id=" & dtr("CarpetaJudicialId").ToString & """><img src=""img/editar.png"" alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" width=""12"" height=""12"" border=""0"" title=""Editar la Carpeta Judicial"" /></a></td>"

                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try
        InformeMovimientoDiario = CodigoHTML
    End Function
    Public Function LeerActividadesDiarias(ByVal TareasId As Long, ByVal Fecha As Date) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim CodigoHTML As String = ""
        Dim i = 0
        Dim FechaFormatoCorrecto As String = Mid(Fecha, 4, 2) & "/" & Mid(Fecha, 1, 2) & "/" & Mid(Fecha, 7, 4)


        sSQL = "SELECT TareasLog.TareasLogTime As Fecha, TareasLog.TareasLogActividad As Actividad "
        sSQL = sSQL & "FROM Tareas INNER JOIN TareasLog ON Tareas.TareasCodigo = TareasLog.TareasCodigo "
        sSQL = sSQL & "WHERE(((Tareas.TareasId) = " & TareasId & " AND (TareasLog.TareasLogTime)>#" & FechaFormatoCorrecto & " 00:00:00# AND (TareasLog.TareasLogTime)<#" & FechaFormatoCorrecto & " 23:59:59#)) "
        sSQL = sSQL & "ORDER BY TareasLog.TareasLogTime DESC"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<tr><td>" & dtr("Actividad").ToString & "</td></tr>"
            End While
            dtr.Close()
        Catch
            CodigoHTML = CodigoHTML & "<tr></td>Sin Actividad en este d&iacute;a</td></tr>"
        End Try
        If CodigoHTML = "" Then
            CodigoHTML = CodigoHTML & "<tr></td>Sin Actividad en este d&iacute;a</td></tr>"
        End If
        LeerActividadesDiarias = "<table>" & CodigoHTML & "</table>"
    End Function
    Public Function MostrarCarpetaJudicialPorPalabraClave(ByVal PalabraClave As String, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim Tareas As New Tareas
        Dim CodigoHTML As String = ""
        Dim dtr As IDataReader
        Dim strUpdate As String
        Dim strboton As String
        Dim NotasTransversales As New NotasTransversales
        Dim NombreCompleto As String = ""


        strUpdate = "SELECT distinct CarpetaJudicial.CarpetaJudicialId AS Id, CarpetaJudicial.CarpetaJudicialApellidos as Apellidos, CarpetaJudicial.CarpetaJudicialNombres as Nombres, CarpetaJudicial.CarpetaJudicialCodigo AS PGGCodigo "
        strUpdate = strUpdate & "FROM CarpetaJudicial "
        strUpdate = strUpdate & "WHERE (((CarpetaJudicial.CarpetaJudicialApellidos) LIKE ('%" & PalabraClave & "%')) OR ((CarpetaJudicial.CarpetaJudicialNombres) LIKE ('%" & PalabraClave & "%')))"
        MostrarCarpetaJudicialPorPalabraClave = ""
        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""alertas"">"
        CodigoHTML = CodigoHTML & "<tr><th scope=""col"" colspan=""2"">Juicios con ['" & PalabraClave & "']</th></tr>"
        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                NombreCompleto = Mid(UCase(dtr("Apellidos").ToString) & ", " & UCase(dtr("Nombres").ToString), 1, 30)
                strUpdate = "<a href=""ImprimirPerfilCarpetaEnWord.aspx?Id=" & dtr("Id").ToString & """ target=""_blank"" title=""De un click para generar informe de estado del proceso judicial"" >" & NombreCompleto & "</a>"
                strUpdate = strUpdate & " <img src=""" & Tareas.ColorDeLaTarea(dtr("PGGCodigo").ToString) & """ width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" onclick=""verTareaModal('GestionTareas.aspx?Id=" & dtr("Id").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" />"
                strboton = "<a href=""IndexSGI.aspx?PaginaWebName=Ficha de CarpetaJudicial&MenuOptionsId=425&Id=" & dtr("Id").ToString & """><img src=""img/editar.png"" alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" width=""12"" height=""12"" border=""0"" title=""Editar la Carpeta Judicial"" /></a>"
                MostrarCarpetaJudicialPorPalabraClave = MostrarCarpetaJudicialPorPalabraClave & "<tr><td>" & strUpdate & "</td><td>" & strboton & "</td></tr>"
            End While
            dtr.Close()
        Catch
            MostrarCarpetaJudicialPorPalabraClave = ""
        End Try
        If Len(MostrarCarpetaJudicialPorPalabraClave) = 0 Then
            MostrarCarpetaJudicialPorPalabraClave = MostrarCarpetaJudicialPorPalabraClave & "<tr><td>No se encontraron programas con '" & PalabraClave & "'</td></tr>"
        End If
        CodigoHTML = CodigoHTML & MostrarCarpetaJudicialPorPalabraClave & "</table>"
        MostrarCarpetaJudicialPorPalabraClave = CodigoHTML
    End Function
    Public Function CarpetaJudicialCerrar(ByVal CarpetaJudicialId As Long, ByVal CarpetaJudicialCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim EstadoTareas As New EstadoTareas
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim t As Integer = 0

        Dim UsuariosCodigo As String = ""
        Dim s As Boolean
        Dim TareasCodigo As String = ""
        Dim TareasId As Long = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)

        s = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UsuariosCodigo)
        s = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)

        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoActualDelaTarea(TareasId)
        Dim TareasLogActividad As String = "Actualiza Carpeta con el Id de la Tarea Vigente: " & TareasId & ", quedando en el estado: " & "Cerrado"
        'Este update sólo contempla el cambio del valor del campo EstadoProcesosCodigo asociado en la tabla Carpeta Judicial y
        'también del campo EstadoTareasCodigo de la tabla Tareas para todas las tareas vigentes del proceso judicial que se cierra.

        strUpdate = "UPDATE CarpetaJudicial SET "
        strUpdate = strUpdate & "CarpetaJudicial.TareasId = " & TareasId & ", "
        strUpdate = strUpdate & "CarpetaJudicial.EstadoProcesoCodigo = '" & "Cerrado" & "', "
        strUpdate = strUpdate & "CarpetaJudicial.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicial.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicial.CarpetaJudicialId = " & CarpetaJudicialId

        Try
            CarpetaJudicialCerrar = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Cierra el proceso judicial " & CarpetaJudicialCodigo, CarpetaJudicialId, "CarpetaJudicial", "Cierra el proceso judicial")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
            t = Tareas.CerrarTareasDeUnProcesoJudicial(CarpetaJudicialCodigo, TareasId, TareasCodigo, UserId)
        Catch
            CarpetaJudicialCerrar = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de cerrar el proceso judicial " & CarpetaJudicialCodigo, CarpetaJudicialId, "CarpetaJudicial", "No pudo cerrar el proceso judicial")
        End Try
    End Function
End Class
