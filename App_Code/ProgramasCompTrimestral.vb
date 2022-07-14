'------------------------------------------------------------
' Código generado por ZRISMART SF el 22-08-2011 12:27:27
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class ProgramasCompTrimestral
    Public Function LeerProgramasCompTrimestral(ByVal ProgramasCompTrimestralId As Long, ByRef ProgramasCodigo As String, ByRef ProgramasCompTrimestralSecuencia As Long, ByRef ProgramasCompTrimestralNombre As String, ByRef ProgramasCompTrimestralDescription As String, ByRef ProgramasCompTrimestralPeriodo As String, ByRef ProgramasCompTrimestralFecha As Date, ByRef UsuariosCodigo As String, ByRef TareasId As Long, ByRef AccionesCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasCodigo, ProgramasCompTrimestralSecuencia, ProgramasCompTrimestralNombre, ProgramasCompTrimestralDescription, ProgramasCompTrimestralPeriodo, ProgramasCompTrimestralFecha, UsuariosCodigo, TareasId, AccionesCodigo "
        sSQL = sSQL & "FROM (ProgramasCompTrimestral) "
        sSQL = sSQL & "WHERE (ProgramasCompTrimestral.ProgramasCompTrimestralId = " & ProgramasCompTrimestralId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProgramasCodigo = CStr(dtr("ProgramasCodigo").ToString)
                If Len(dtr("ProgramasCompTrimestralSecuencia").ToString) = 0 Then
                    ProgramasCompTrimestralSecuencia = 0
                Else
                    ProgramasCompTrimestralSecuencia = CLng(dtr("ProgramasCompTrimestralSecuencia").ToString)
                End If
                ProgramasCompTrimestralNombre = CStr(dtr("ProgramasCompTrimestralNombre").ToString)
                ProgramasCompTrimestralDescription = CStr(dtr("ProgramasCompTrimestralDescription").ToString)
                ProgramasCompTrimestralPeriodo = CStr(dtr("ProgramasCompTrimestralPeriodo").ToString)
                If Len(dtr("ProgramasCompTrimestralFecha").ToString) = 0 Then
                    ProgramasCompTrimestralFecha = "01/01/01"
                Else
                    ProgramasCompTrimestralFecha = CDate(dtr("ProgramasCompTrimestralFecha").ToString)
                End If
                UsuariosCodigo = CStr(dtr("UsuariosCodigo").ToString)
                If Len(dtr("TareasId").ToString) = 0 Then
                    TareasId = 0
                Else
                    TareasId = CLng(dtr("TareasId").ToString)
                End If
                AccionesCodigo = CStr(dtr("AccionesCodigo").ToString)

            End While
            LeerProgramasCompTrimestral = True
            dtr.Close()
        Catch
            LeerProgramasCompTrimestral = False
        End Try
    End Function
    Public Function ProgramasCompTrimestralUpdate(ByVal ProgramasCompTrimestralId As Long, ByRef ProgramasCodigo As String, ByRef ProgramasCompTrimestralSecuencia As Long, ByRef ProgramasCompTrimestralNombre As String, ByRef ProgramasCompTrimestralDescription As String, ByRef ProgramasCompTrimestralPeriodo As String, ByRef ProgramasCompTrimestralFecha As Date, ByRef UsuariosCodigo As String, ByRef TareasId As Long, ByRef AccionesCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim ProgramasCompTrimestral As New ProgramasCompTrimestral
        Dim t As Integer = 0
        Dim s As Boolean
        Dim TareasCodigo As String = ""
        strUpdate = "UPDATE ProgramasCompTrimestral SET "
        strUpdate = strUpdate & "ProgramasCompTrimestral.ProgramasCodigo = '" & ProgramasCodigo & "', "
        strUpdate = strUpdate & "ProgramasCompTrimestral.ProgramasCompTrimestralSecuencia = " & ProgramasCompTrimestralSecuencia & ", "
        strUpdate = strUpdate & "ProgramasCompTrimestral.ProgramasCompTrimestralNombre = '" & ProgramasCompTrimestralNombre & "', "
        strUpdate = strUpdate & "ProgramasCompTrimestral.ProgramasCompTrimestralDescription = '" & ProgramasCompTrimestralDescription & "', "
        strUpdate = strUpdate & "ProgramasCompTrimestral.ProgramasCompTrimestralPeriodo = '" & ProgramasCompTrimestralPeriodo & "', "
        strUpdate = strUpdate & "ProgramasCompTrimestral.ProgramasCompTrimestralFecha = '" & AccionesABM.DateTransform(ProgramasCompTrimestralFecha) & "', "
        strUpdate = strUpdate & "ProgramasCompTrimestral.UsuariosCodigo = '" & UsuariosCodigo & "', "
        strUpdate = strUpdate & "ProgramasCompTrimestral.AccionesCodigo = '" & "3.1.1.01" & "', "
        strUpdate = strUpdate & "ProgramasCompTrimestral.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "ProgramasCompTrimestral.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE ProgramasCompTrimestral.ProgramasCompTrimestralId = " & ProgramasCompTrimestralId
        Try
            ProgramasCompTrimestralUpdate = AccesoEA.ABMRegistros(strUpdate)
            s = ProgramasCompTrimestral.LeerTareasIdAsociada(ProgramasCompTrimestralId, TareasId, TareasCodigo)
            t = ProgramasCompTrimestral.UpdateTarea(ProgramasCodigo, "3.1.1.01", ProgramasCompTrimestralFecha, ProgramasCompTrimestralDescription, UsuariosCodigo, TareasId, UserId)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ProgramasCodigo, ProgramasCompTrimestralId, "ProgramasCompTrimestral", "")
        Catch
            ProgramasCompTrimestralUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ProgramasCodigo, ProgramasCompTrimestralId, "ProgramasCompTrimestral", "")
        End Try
    End Function
    Public Function ProgramasCompTrimestralTareasIdUpdate(ByVal ProgramasCompTrimestralId As Long, ByVal TareasId As Long, ByVal ProgramasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim EstadoTareas As New EstadoTareas
        Dim Usuarios As New Usuarios
        Dim t As Integer = 0

        'Este update sólo contempla el cambio del valor del campo Identity asociado en la tabla Tareas.

        'El resto de los campos quedaron grabados en el origen y no son susceptibles de cambio

        strUpdate = "UPDATE ProgramasCompTrimestral SET "
        strUpdate = strUpdate & "ProgramasCompTrimestral.TareasId = " & TareasId & ", "
        strUpdate = strUpdate & "ProgramasCompTrimestral.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "ProgramasCompTrimestral.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE ProgramasCompTrimestral.ProgramasCompTrimestralId = " & ProgramasCompTrimestralId

        Try
            ProgramasCompTrimestralTareasIdUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza el Id de una tarea de " & ProgramasCodigo, ProgramasCompTrimestralId, "ProgramasCompTrimestral", "")
            't = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            ProgramasCompTrimestralTareasIdUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el Id de una tarea de " & ProgramasCodigo, ProgramasCompTrimestralId, "ProgramasCompTrimestral", "")
        End Try
    End Function
    Public Function ProgramasCompTrimestralInsert(ByRef ProgramasCompTrimestralId As Long, ByRef ProgramasCodigo As String, ByRef ProgramasCompTrimestralSecuencia As Long, ByRef ProgramasCompTrimestralNombre As String, ByRef ProgramasCompTrimestralDescription As String, ByRef ProgramasCompTrimestralPeriodo As String, ByRef ProgramasCompTrimestralFecha As Date, ByRef UsuariosCodigo As String, ByRef TareasId As Long, ByRef AccionesCodigo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim Acciones As New Acciones
        Dim Programas As New Programas
        Dim t As Integer = 0
        Dim ProgramasCompTrimestral As New ProgramasCompTrimestral
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Dim AccionesHH As Double = 0
        Dim AccionesUSD As Double = 0
        Dim AccionesId As Long = 0
        Dim ProgramasId As Long = 0
        Dim s As Boolean

        Try
            MasterName = ProgramasCodigo
            DetailSecuencia = ProgramasCompTrimestralSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("ProgramasCompTrimestralId", "ProgramasCodigo", "ProgramasCompTrimestralSecuencia", "ProgramasCompTrimestral", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("ProgramasCompTrimestralId", "ProgramasCodigo", "ProgramasCompTrimestralSecuencia", "ProgramasCompTrimestral", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            ProgramasCompTrimestralInsert = ProgramasCompTrimestral.ProgramasCompTrimestralUpdate(DetailId, CStr(ProgramasCodigo), CLng(ProgramasCompTrimestralSecuencia), CStr(ProgramasCompTrimestralNombre), CStr(ProgramasCompTrimestralDescription), CStr(ProgramasCompTrimestralPeriodo), ProgramasCompTrimestralFecha, UsuariosCodigo, TareasId, AccionesCodigo, UserId)
            AccionesCodigo = "3.1.1.01"
            s = Acciones.LeerAccionesByName(AccionesId, AccionesCodigo)
            s = Programas.LeerProgramasByName(ProgramasId, ProgramasCodigo)
            t = ProgramasCompTrimestral.CrearTarea(ProgramasId, ProgramasCodigo, AccionesCodigo, AccionesId, ProgramasCompTrimestralFecha, ProgramasCompTrimestralDescription, UsuariosCodigo, AccionesHH, AccionesUSD, TareasId, UserId)
            If t = 1 Then
                s = ProgramasCompTrimestral.ProgramasCompTrimestralTareasIdUpdate(ProgramasCompTrimestralId, TareasId, ProgramasCodigo, UserId)
            End If
        Catch
            ProgramasCompTrimestralInsert = 0
        End Try
    End Function
    Public Function ProgramasCompTrimestralDelete(ByVal TareasProgramadasId As Long, ByRef Mensaje As String, ByVal UserId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Rol As New Rol
        Dim Tareas As New Tareas
        Dim ProgramasCompTrimestral As New ProgramasCompTrimestral
        Dim Total As Long = 0
        Dim TareasId As Long = 0
        Dim TareasCodigo As String = ""

        ' Verificar si la tarea posee evidencias o KPI registrados

        '---------------------------------------------------------
        t = ProgramasCompTrimestral.LeerTareasIdAsociada(TareasProgramadasId, TareasId, TareasCodigo)
        Total = Tareas.LeerTotalTareasPorTablasRelacionadas(TareasCodigo, TareasId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados a la Tarea " & TareasCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie la Tarea en las Evidencias y KPI, antes de eliminarla de la lista"
            ProgramasCompTrimestralDelete = False
        Else
            Try
                ' Borra registro de la tabla de TareasLog
                '-------------------------------------
                strUpdate = "DELETE FROM TareasLog WHERE TareasCodigo = '" & TareasCodigo & "'"
                t = AccesoEA.ABMRegistros(strUpdate)
                ' Borra registro de la tabla de TareasNotas
                '-------------------------------------
                strUpdate = "DELETE FROM TareasNotas WHERE TareasCodigo = '" & TareasCodigo & "'"
                t = AccesoEA.ABMRegistros(strUpdate)
                ' Borra registro de la tabla de Tareas
                '-------------------------------------
                strUpdate = "DELETE FROM Tareas WHERE TareasId = " & TareasId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), 0, "Elimina la Tarea: " & TareasCodigo, TareasId, "Tareas", "")
                ProgramasCompTrimestralDelete = True
                ' Borra registro de la tabla de TareasProgramadas
                '-------------------------------------
                strUpdate = "DELETE FROM ProgramasCompTrimestral WHERE ProgramasCompTrimestralId = " & TareasProgramadasId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), 0, "Elimina el compromiso trimestral: " & TareasProgramadasId, TareasProgramadasId, "ProgramasCompTrimestral", "")
                ProgramasCompTrimestralDelete = True

            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), 0, "Intento fallido de eliminar el compromiso trimestral: " & TareasProgramadasId, TareasProgramadasId, "ProgramasCompTrimestral", "")
                ProgramasCompTrimestralDelete = False
            End Try
        End If
    End Function
    Public Function CrearTarea(ByVal ProgramasId As Long, _
                                ByVal PGGCodigo As String, _
                                ByVal AccionesCodigo As String, _
                                ByVal AccionesId As Long, _
                                ByVal TareasProgramadasFecha As Date, _
                                ByVal TareasProgramadasDescription As String, _
                                ByVal UsuariosCodigo As String, _
                                ByVal AccionesHH As Double, _
                                ByVal AccionesUSD As Double, _
                                ByRef TareasId As Long, _
                                ByVal UserId As Long) As Long

        'PGGCodigo = ProgramasCodigo
        'PivotId = ProgramasMapaId
        'ChilId = AccionesId

        Dim ProgramasCompTrimestral As New ProgramasCompTrimestral
        CrearTarea = ProgramasCompTrimestral.CrearTareasPorAccion(PGGCodigo, AccionesCodigo, AccionesId, ProgramasId, TareasProgramadasFecha, TareasProgramadasDescription, UsuariosCodigo, AccionesHH, AccionesUSD, TareasId, UserId)

    End Function
    Public Function CrearTareasPorAccion(ByVal PGGCodigo As String, _
                                         ByVal AccionesCodigo As String, _
                                         ByVal AccionesId As Long, _
                                         ByVal PGGId As Long, _
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

        CrearTareasPorAccion = 0

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
            EstadoTareasCodigo = "Asignada"
            TareasCodigo = PGGCodigo & "-" & AccionesCodigo & "-" & TareasAno & " - " & TareasMes
            t = AccionesABM.MasterPartialInsert("TareasId", "TareasCodigo", "Tareas", TareasCodigo, UserId, TareasId)
            TareasCodigo = TareasCodigo & "-" & TareasId 'SE agrega el Id de la Tarea para asegurar que el código sea único
            t = Tareas.TareasUpdate(TareasId, TareasCodigo, TareasName, TareasDescription, PGGCodigo, AccionesCodigo, CLng(ActividadesSecuencia), CLng(TareasMes), TareasAno, CLng(TareasSecuencia), UsuariosCodigo, CDbl(TareasHH * 100), CDbl(TareasUSD * 100), CLng(DiaMinimoInicio), CLng(DiaMaximoTermino), CLng(TareasDiaProgramado), TareasTipo, CLng(TareasDiaRealTermino), CDbl(TareasHHConsumidas * 100), CDbl(TareasUSDConsumidos * 100), EstadoTareasCodigo, UserId)
            t = Tareas.TareasEjecutorUpdate(TareasId, TareasCodigo, UsuariosCodigo, AccionesCodigo, UserId)
            CrearTareasPorAccion = 1
        Catch ex As Exception
            CrearTareasPorAccion = 0
        End Try

    End Function
    Public Function UpdateTarea(ByVal CodigoPrograma As String, _
                                         ByVal CodigoAcciones As String, _
                                         ByVal TareasProgramadasFecha As Date, _
                                         ByVal TareasProgramadasDescription As String, _
                                         ByVal UserCodigo As String, _
                                         ByVal TareasId As Long, _
                                         ByVal UserId As Long) As Long

        Dim t As Boolean
        Dim Acciones As New Acciones
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim AccionesHH As Double = 0
        Dim AccionesUSD As Double = 0
        Dim AccionesId As Long = 0

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
        Dim UsuariosCodigo As String = ""
        Dim PGGCodigo As String = ""
        Dim AccionesCodigo As String = ""
        '----------------------------------------

        t = Acciones.LeerAccionesByName(AccionesId, CodigoAcciones)
        t = Acciones.LeerHHyUSDPorAccion(AccionesId, AccionesHH, AccionesUSD)

        UpdateTarea = 0

        Try
            t = Tareas.LeerTareas(TareasId, TareasCodigo, TareasName, TareasDescription, PGGCodigo, AccionesCodigo, CLng(ActividadesSecuencia), CLng(TareasMes), TareasAno, CLng(TareasSecuencia), UsuariosCodigo, CDbl(TareasHH), CDbl(TareasUSD), CLng(DiaMinimoInicio), CLng(DiaMaximoTermino), CLng(TareasDiaProgramado), TareasTipo, CLng(TareasDiaRealTermino), CDbl(TareasHHConsumidas), CDbl(TareasUSDConsumidos), EstadoTareasCodigo)
            'Inicializo variable para crear una tarea
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
            EstadoTareasCodigo = "Asignada"
            TareasCodigo = TareasCodigo
            UsuariosCodigo = UserCodigo
            t = Tareas.TareasUpdate(TareasId, TareasCodigo, TareasName, TareasDescription, CodigoPrograma, CodigoAcciones, CLng(ActividadesSecuencia), CLng(TareasMes), TareasAno, CLng(TareasSecuencia), UsuariosCodigo, CDbl(TareasHH * 100), CDbl(TareasUSD * 100), CLng(DiaMinimoInicio), CLng(DiaMaximoTermino), CLng(TareasDiaProgramado), TareasTipo, CLng(TareasDiaRealTermino), CDbl(TareasHHConsumidas * 100), CDbl(TareasUSDConsumidos * 100), EstadoTareasCodigo, UserId)
            t = Tareas.TareasEjecutorUpdate(TareasId, TareasCodigo, UsuariosCodigo, CodigoAcciones, UserId)
            UpdateTarea = 1
        Catch ex As Exception
            UpdateTarea = 0
        End Try

    End Function
    Public Function LeerTareasIdAsociada(ByVal TareasProgramadasId As Long, ByRef TareasId As Long, ByRef TareasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Tareas As New Tareas
        Dim t As Boolean
        sSQL = "Select TareasId "
        sSQL = sSQL & "FROM (ProgramasCompTrimestral) "
        sSQL = sSQL & "WHERE (ProgramasCompTrimestral.ProgramasCompTrimestralId = " & TareasProgramadasId & ") "
        LeerTareasIdAsociada = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If Len(dtr("TareasId").ToString) = 0 Then
                    TareasId = 0
                Else
                    TareasId = CLng(dtr("TareasId").ToString)
                End If
                t = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)
                LeerTareasIdAsociada = True
            End While
            dtr.Close()
        Catch
            LeerTareasIdAsociada = False
        End Try
    End Function
End Class
