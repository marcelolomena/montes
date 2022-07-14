Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class TareasProgramadas
    Public Function LeerTareasProgramadas(ByVal TareasProgramadasId As Long, ByRef TareasProgramadasFecha As Date, ByRef TareasProgramadasDescription As String, ByRef UsuariosCodigo As String, ByRef AccionesPorStakeholdersPorProgramaId As Long, ByRef TareasId As Long, ByRef ProgramasCodigo As String, ByRef AccionesCodigo As String, ByRef StakeholdersCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasProgramadasFecha, TareasProgramadasDescription, UsuariosCodigo, AccionesPorStakeholdersPorProgramaId, TareasId, ProgramasCodigo, AccionesCodigo, StakeholdersCodigo "
        sSQL = sSQL & "FROM (TareasProgramadas) "
        sSQL = sSQL & "WHERE (TareasProgramadas.TareasProgramadasId = " & TareasProgramadasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If Len(dtr("TareasProgramadasFecha").ToString) = 0 Then
                    TareasProgramadasFecha = "01/01/01"
                Else
                    TareasProgramadasFecha = CDate(dtr("TareasProgramadasFecha").ToString)
                End If
                TareasProgramadasDescription = CStr(dtr("TareasProgramadasDescription").ToString)
                UsuariosCodigo = CStr(dtr("UsuariosCodigo").ToString)
                If Len(dtr("AccionesPorStakeholdersPorProgramaId").ToString) = 0 Then
                    AccionesPorStakeholdersPorProgramaId = 0
                Else
                    AccionesPorStakeholdersPorProgramaId = CLng(dtr("AccionesPorStakeholdersPorProgramaId").ToString)
                End If
                If Len(dtr("TareasId").ToString) = 0 Then
                    TareasId = 0
                Else
                    TareasId = CLng(dtr("TareasId").ToString)
                End If
                ProgramasCodigo = CStr(dtr("ProgramasCodigo").ToString)
                AccionesCodigo = CStr(dtr("AccionesCodigo").ToString)
                StakeholdersCodigo = CStr(dtr("StakeholdersCodigo").ToString)
            End While
            LeerTareasProgramadas = True
            dtr.Close()
        Catch
            LeerTareasProgramadas = False
        End Try
    End Function
    Public Function LeerTareasIdAsociada(ByVal TareasProgramadasId As Long, ByRef TareasId As Long, ByRef TareasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Tareas As New Tareas
        sSQL = "Select TareasId "
        sSQL = sSQL & "FROM (TareasProgramadas) "
        sSQL = sSQL & "WHERE (TareasProgramadas.TareasProgramadasId = " & TareasProgramadasId & ") "
        LeerTareasIdAsociada = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If Len(dtr("TareasId").ToString) = 0 Then
                    TareasId = 0
                Else
                    TareasId = CLng(dtr("TareasId").ToString)
                End If
                TareasCodigo = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)
                LeerTareasIdAsociada = True
            End While
            dtr.Close()
        Catch
            LeerTareasIdAsociada = False
        End Try
    End Function
    Public Function LeerStakeholderByTareasId(ByVal TareasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Tareas As New Tareas
        sSQL = "Select StakeholdersCodigo "
        sSQL = sSQL & "FROM (TareasProgramadas) "
        sSQL = sSQL & "WHERE (TareasProgramadas.TareasId = " & TareasId & ") "
        LeerStakeholderByTareasId = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerStakeholderByTareasId = CStr(dtr("StakeholdersCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerStakeholderByTareasId = ""
        End Try
    End Function
    Public Function TareasProgramadasUpdate(ByVal TareasProgramadasId As Long, ByVal TareasProgramadasFecha As Date, ByVal TareasProgramadasDescription As String, ByVal UsuariosCodigo As String, ByVal AccionesPorStakeholdersPorProgramaId As Long, ByRef TareasId As Long, ByRef ProgramasCodigo As String, ByRef AccionesCodigo As String, ByRef StakeholdersCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim EstadoTareas As New EstadoTareas
        Dim Usuarios As New Usuarios
        Dim t As Integer = 0

        'El update sólo contempla el cambio de fecha y eventualmente el cambio de instrucciones, el cambio de ejecutor forma parte de las actualizaciones que puede hacer
        'el que este como responsable de la tarea.

        'El resto de los campos quedaron grabados en el origen y no son susceptibles de cambio

        strUpdate = "UPDATE TareasProgramadas SET "
        strUpdate = strUpdate & "TareasProgramadas.TareasProgramadasFecha = '" & AccionesABM.DateTransform(TareasProgramadasFecha) & "', "
        strUpdate = strUpdate & "TareasProgramadas.TareasProgramadasDescription = '" & TareasProgramadasDescription & "', "
        strUpdate = strUpdate & "TareasProgramadas.UsuariosCodigo = '" & UsuariosCodigo & "', "
        strUpdate = strUpdate & "TareasProgramadas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "TareasProgramadas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE TareasProgramadas.TareasProgramadasId = " & TareasProgramadasId

        Try
            TareasProgramadasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza la fecha o instrucciones de una tarea de " & ProgramasCodigo, TareasProgramadasId, "TareasProgramadas", "")
            't = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasProgramadasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar la fecha o instrucciones de una tarea de " & ProgramasCodigo, TareasProgramadasId, "TareasProgramadas", "")
        End Try
    End Function
    Public Function TareasProgramadasTareasIdUpdate(ByVal TareasProgramadasId As Long, ByVal TareasId As Long, ByVal ProgramasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim EstadoTareas As New EstadoTareas
        Dim Usuarios As New Usuarios
        Dim t As Integer = 0

        'Este update sólo contempla el cambio del valor del campo Identity asociado en la tabla Tareas.

        'El resto de los campos quedaron grabados en el origen y no son susceptibles de cambio

        strUpdate = "UPDATE TareasProgramadas SET "
        strUpdate = strUpdate & "TareasProgramadas.TareasId = " & TareasId & ", "
        strUpdate = strUpdate & "TareasProgramadas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "TareasProgramadas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE TareasProgramadas.TareasProgramadasId = " & TareasProgramadasId

        Try
            TareasProgramadasTareasIdUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza el Id de una tarea de " & ProgramasCodigo, TareasProgramadasId, "TareasProgramadas", "")
            't = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasProgramadasTareasIdUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el Id de una tarea de " & ProgramasCodigo, TareasProgramadasId, "TareasProgramadas", "")
        End Try
    End Function
    Public Function TareasProgramadasInsert(ByVal TareasProgramadasFecha As Date, ByVal TareasProgramadasDescription As String, ByVal UsuariosCodigo As String, ByVal AccionesPorStakeholdersPorProgramaId As Long, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim AccesoEA As New AccesoEA
        Dim ProgramasMapa As New ProgramasMapa
        Dim TareasProgramadas As New TareasProgramadas
        Dim AccionesPorStakeholdersPorPrograma As New AccionesPorStakeholdersPorPrograma
        Dim Acciones As New Acciones
        Dim s As Integer = 0
        Dim t As Boolean
        Dim Tareas As New Tareas
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        'Necesito definir otros campos del registro que no vienen desde el usuario y son internos
        Dim TareasId As Long = 0
        Dim TareasProgramadasId As Long = 0
        Dim ProgramasCodigo As String = ""
        Dim AccionesCodigo As String = ""
        Dim StakeholdersCodigo As String = ""
        Dim ProgramasId As Long = 0
        Dim AccionesId As Long = 0
        Dim ProgramasMapaId As Long = 0
        Dim strUpdate As String = ""
        Dim AccionesHH As Double = 0
        Dim AccionesUSD As Double = 0

        TareasProgramadasInsert = 0

        t = AccionesPorStakeholdersPorPrograma.LeerProgramaMapaIdYAccionesId(AccionesPorStakeholdersPorProgramaId, ProgramasMapaId, AccionesId)
        AccionesCodigo = Acciones.LeerAccionesCodigoById(AccionesId)
        t = ProgramasMapa.LeerProgramasMapaProgramaYStakeholder(ProgramasMapaId, ProgramasCodigo, StakeholdersCodigo)
        t = AccionesPorStakeholdersPorPrograma.LeerHHyUSDPorAccion(AccionesPorStakeholdersPorProgramaId, AccionesHH, AccionesUSD)

        'Asumo que conozco el Id del registro de la tabla AccionesPorStakeholdersPorPrograma.
        'Desde dicho registro colgarán una o más tareas que permitiran dar cumplimiento con la acción
        'Estos registros quedan en la tabla TAREASPROGRAMADAS y tanbién se crea un registro en la tabla de Tareas

        strUpdate = "INSERT INTO TAREASPROGRAMADAS (TareasProgramadasFecha, TareasProgramadasDescription, UsuariosCodigo, AccionesPorStakeholdersPorProgramaId, TareasId, ProgramasCodigo, AccionesCodigo, StakeholdersCodigo, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES ('" & AccionesABM.DateTransform(TareasProgramadasFecha) & "', '" & TareasProgramadasDescription & "', '" & UsuariosCodigo & "', " & AccionesPorStakeholdersPorProgramaId & ", " & TareasId & ", '" & ProgramasCodigo & "', '" & AccionesCodigo & "', '" & StakeholdersCodigo & "', '" & AccionesABM.DateTransform(Now()) & "', " & UserId & ")"

        Try
            TareasProgramadasInsert = AccesoEA.ABMRegistros(strUpdate)
            TareasProgramadasId = Lecturas.LeerMaximoId("Select Max(TareasProgramadasID) as MaximoId FROM (TareasProgramadas)")
            TareasProgramadasInsert = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta una nueva tarea programada para " & StakeholdersCodigo & " el día " & Mid(TareasProgramadasFecha, 1, 10), TareasProgramadasId, "TareasProgramadas", "")
            ' Como todo salio bien ahora creo la tarea en la tabla de Tareas
            TareasProgramadasInsert = TareasProgramadas.CrearTarea(ProgramasMapaId, AccionesId, ProgramasCodigo, StakeholdersCodigo, AccionesCodigo, TareasProgramadasFecha, TareasProgramadasDescription, UsuariosCodigo, AccionesHH, AccionesUSD, TareasId, UserId)
            If TareasProgramadasInsert = 1 Then
                s = TareasProgramadas.TareasProgramadasTareasIdUpdate(TareasProgramadasId, TareasId, ProgramasCodigo, UserId)
            End If
        Catch
            TareasProgramadasInsert = 0
            TareasProgramadasId = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar una nueva tarea programada para " & StakeholdersCodigo & " el día " & Mid(TareasProgramadasFecha, 1, 10), TareasProgramadasId, "TareasProgramadas", "")
        End Try

    End Function
    Public Function TareasProgramadasDelete(ByVal TareasProgramadasId As Long, ByRef Mensaje As String, ByVal UserId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Rol As New Rol
        Dim Tareas As New Tareas
        Dim TareasProgramadas As New TareasProgramadas
        Dim Total As Long = 0
        Dim TareasId As Long = 0
        Dim TareasCodigo As String = ""

        ' Verificar si la tarea posee evidencias o KPI registrados

        '---------------------------------------------------------
        t = TareasProgramadas.LeerTareasIdAsociada(TareasProgramadasId, TareasId, TareasCodigo)
        Total = Tareas.LeerTotalTareasPorTablasRelacionadas(TareasCodigo, TareasId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados a la Tarea " & TareasCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie la Tarea en las Evidencias y KPI, antes de eliminarla de la lista"
            TareasProgramadasDelete = False
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
                TareasProgramadasDelete = True
                ' Borra registro de la tabla de TareasProgramadas
                '-------------------------------------
                strUpdate = "DELETE FROM TareasProgramadas WHERE TareasProgramadasId = " & TareasProgramadasId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), 0, "Elimina la Tarea Programada: " & TareasProgramadasId, TareasProgramadasId, "TareasProgramadas", "")
                TareasProgramadasDelete = True

            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), 0, "Intento fallido de eliminar la Tarea: " & TareasCodigo, TareasId, "Tareas", "")
                TareasProgramadasDelete = False
            End Try
        End If
    End Function
    Public Function CrearTarea(ByVal PivotId As Long, _
                                ByVal ChildId As Long, _
                                ByVal PGGCodigo As String, _
                                ByVal StakeholdersCodigo As String, _
                                ByVal AccionesCodigo As String, _
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

        Dim TareasProgramadas As New TareasProgramadas
        CrearTarea = TareasProgramadas.CrearTareasPorAcción(PGGCodigo, AccionesCodigo, ChildId, PivotId, StakeholdersCodigo, TareasProgramadasFecha, TareasProgramadasDescription, UsuariosCodigo, AccionesHH, AccionesUSD, TareasId, UserId)

    End Function
    Public Function CrearTareasPorAcción(ByVal PGGCodigo As String, _
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

        CrearTareasPorAcción = 0

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
            TareasCodigo = PGGCodigo & "-" & AccionesCodigo & "-" & StakeholdersCodigo & "-" & TareasAno & "-" & TareasMes
            t = AccionesABM.MasterPartialInsert("TareasId", "TareasCodigo", "Tareas", TareasCodigo, UserId, TareasId)
            TareasCodigo = TareasCodigo & "-" & TareasId 'SE agrega el Id de la Tarea para asegurar que el código sea único
            t = Tareas.TareasUpdate(TareasId, TareasCodigo, TareasName, TareasDescription, PGGCodigo, AccionesCodigo, CLng(ActividadesSecuencia), CLng(TareasMes), TareasAno, CLng(TareasSecuencia), UsuariosCodigo, CDbl(TareasHH * 100), CDbl(TareasUSD * 100), CLng(DiaMinimoInicio), CLng(DiaMaximoTermino), CLng(TareasDiaProgramado), TareasTipo, CLng(TareasDiaRealTermino), CDbl(TareasHHConsumidas * 100), CDbl(TareasUSDConsumidos * 100), EstadoTareasCodigo, UserId)
            t = Tareas.TareasEjecutorUpdate(TareasId, TareasCodigo, UsuariosCodigo, AccionesCodigo, UserId)
            CrearTareasPorAcción = 1
        Catch ex As Exception
            CrearTareasPorAcción = 0
        End Try

    End Function
    Public Function LeerTotalTareasProgramadas(ByVal ProgramasId As Long, ByVal StakeholdersId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim ProgramasCodigo As String = ""
        Dim StakeholdersCodigo As String = ""
        Dim Programas As New Programas
        Dim Stakeholders As New Stakeholders
        Dim t As Boolean = False

        t = Programas.LeerProgramasCodigoById(ProgramasId, ProgramasCodigo)
        StakeholdersCodigo = Stakeholders.LeerStakeholdersCodigoById(StakeholdersId)

        'Verifica si el stakeholders tiene ya asignada tareas programadas.

        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM TareasProgramadas "
        sSQL = sSQL & "WHERE (((TareasProgramadas.ProgramasCodigo)= '" & ProgramasCodigo & "') AND ((TareasProgramadas.StakeholdersCodigo)= '" & StakeholdersCodigo & "'))"
        LeerTotalTareasProgramadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalTareasProgramadas = LeerTotalTareasProgramadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalTareasProgramadas = 0
        End Try
    End Function
End Class
