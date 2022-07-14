'------------------------------------------------------------
' Código generado por ZRISMART SF el 12-04-2011 12:51:49
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Imports System.Web.UI.DataVisualization.Charting
Public Class Acciones
    Public Function LeerAcciones(ByVal AccionesId As Long, ByRef AccionesCodigo As String, ByRef AccionesName As String, ByRef AccionesDescription As String, ByRef AccionesSecuencia As Long, ByRef TipoProcesoSecuencia As Long, ByRef EtapasSecuencia As Long, ByRef EtapasName As String, ByRef EtapasId As Long, ByRef RolName As String, ByRef PaginaWebName As String, ByRef AccionesDuration As Long, ByRef AccionesEnviaCorreo As Boolean, ByRef AccionesAdvertirFechaFatal As Boolean, ByRef AccionesIsFlujoAlternativo As Boolean) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AccionesCodigo, AccionesName, AccionesDescription, AccionesSecuencia, TipoProcesoSecuencia, EtapasSecuencia, EtapasName, EtapasId, RolName, PaginaWebName, AccionesDuration, AccionesEnviaCorreo, AccionesAdvertirFechaFatal, AccionesIsFlujoAlternativo "
        sSQL = sSQL & "FROM (Acciones) "
        sSQL = sSQL & "WHERE (Acciones.AccionesId = " & AccionesId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                AccionesCodigo = CStr(dtr("AccionesCodigo").ToString)
                AccionesName = CStr(dtr("AccionesName").ToString)
                AccionesDescription = CStr(dtr("AccionesDescription").ToString)
                AccionesSecuencia = CStr(dtr("AccionesSecuencia").ToString)
                TipoProcesoSecuencia = CLng(dtr("TipoProcesoSecuencia").ToString)
                EtapasSecuencia = CLng(dtr("EtapasSecuencia").ToString)
                EtapasName = CStr(dtr("EtapasName").ToString)
                EtapasId = CLng(dtr("EtapasId").ToString)
                RolName = CStr(dtr("RolName").ToString)
                PaginaWebName = CStr(dtr("PaginaWebName").ToString)
                If Len(dtr("AccionesDuration").ToString) = 0 Then
                    AccionesDuration = 1
                Else
                    AccionesDuration = CInt(dtr("AccionesDuration").ToString)
                End If
                AccionesEnviaCorreo = CBool(dtr("AccionesEnviaCorreo").ToString)
                AccionesAdvertirFechaFatal = CBool(dtr("AccionesAdvertirFechaFatal").ToString)
                AccionesIsFlujoAlternativo = CBool(dtr("AccionesIsFlujoAlternativo").ToString)
            End While
            LeerAcciones = True
            dtr.Close()
        Catch
            LeerAcciones = False
        End Try
    End Function
    Public Function LeerAccionesNameAndDescription(ByVal AccionesId As Long, ByRef AccionesCodigo As String, ByRef AccionesName As String, ByRef AccionesDescription As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AccionesCodigo, AccionesName, AccionesDescription "
        sSQL = sSQL & "FROM (Acciones) "
        sSQL = sSQL & "WHERE (Acciones.AccionesId = " & AccionesId & ") "
        LeerAccionesNameAndDescription = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                AccionesCodigo = CStr(dtr("AccionesCodigo").ToString)
                AccionesName = CStr(dtr("AccionesName").ToString)
                AccionesDescription = CStr(dtr("AccionesDescription").ToString)
                LeerAccionesNameAndDescription = True
            End While
            dtr.Close()
        Catch
            LeerAccionesNameAndDescription = False
        End Try
    End Function
    Public Function LeerAccionesIdAndName(ByRef AccionesCodigo As String, ByVal AccionesId As Long, ByRef AccionesName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AccionesId, AccionesName "
        sSQL = sSQL & "FROM Acciones "
        sSQL = sSQL & "WHERE Acciones.AccionesCodigo = '" & AccionesCodigo & "' "
        LeerAccionesIdAndName = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                AccionesId = CStr(dtr("AccionesId").ToString)
                AccionesName = CStr(dtr("AccionesName").ToString)
                LeerAccionesIdAndName = True
            End While
            dtr.Close()
        Catch
            LeerAccionesIdAndName = False
        End Try
    End Function

    Public Function LeerAccionSiguiente(ByVal ActualAccionesCodigo As String, ByVal EstadoProcesosCodigo As String, ByRef AccionesId As Long, ByRef AccionesCodigo As String, ByRef AccionesName As String, ByRef AccionesDescription As String, ByRef RolName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Acciones_1.AccionesCodigo, Acciones_1.AccionesId, Acciones_1.AccionesDescription, Acciones_1.AccionesName, Acciones_1.RolName "
        sSQL = sSQL & "FROM (TransicionAcciones INNER JOIN Acciones ON TransicionAcciones.CurrentStateId = Acciones.AccionesId) INNER JOIN Acciones AS Acciones_1 ON TransicionAcciones.NextStateId = Acciones_1.AccionesId "
        sSQL = sSQL & "WHERE (((Acciones.AccionesCodigo)='" & ActualAccionesCodigo & "') AND ((TransicionAcciones.EstadoProcesoCodigo)='" & EstadoProcesosCodigo & "'))"

        LeerAccionSiguiente = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                AccionesId = CLng(dtr("AccionesId").ToString)
                AccionesCodigo = CStr(dtr("AccionesCodigo").ToString)
                AccionesName = CStr(dtr("AccionesName").ToString)
                AccionesDescription = CStr(dtr("AccionesDescription").ToString)
                RolName = CStr(dtr("RolName").ToString)
                LeerAccionSiguiente = True
            End While
            dtr.Close()
        Catch
            LeerAccionSiguiente = False
        End Try
    End Function



    Public Function LeerToolTipAccion(ByVal AccionesCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AccionesDescription "
        sSQL = sSQL & "FROM (Acciones) "
        sSQL = sSQL & "WHERE (Acciones.AccionesCodigo = '" & AccionesCodigo & "') "
        LeerToolTipAccion = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerToolTipAccion = CStr(dtr("AccionesDescription").ToString)
            End While
            dtr.Close()
        Catch
            LeerToolTipAccion = ""
        End Try
    End Function

    Public Function LeerPaginaWeb(ByVal AccionesCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PaginaWebName "
        sSQL = sSQL & "FROM (Acciones) "
        sSQL = sSQL & "WHERE (Acciones.AccionesCodigo = '" & AccionesCodigo & "') "
        LeerPaginaWeb = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerPaginaWeb = CStr(dtr("PaginaWebName").ToString)
            End While
            dtr.Close()
        Catch
            LeerPaginaWeb = ""
        End Try
    End Function
    Public Function LeerPaginaWebByTareaId(ByVal TareasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select Acciones.PaginaWebName "
        sSQL = sSQL & "FROM Tareas INNER JOIN Acciones ON Tareas.AccionesCodigo = Acciones.AccionesCodigo "
        sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"
        LeerPaginaWebByTareaId = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerPaginaWebByTareaId = CStr(dtr("PaginaWebName").ToString)
            End While
            dtr.Close()
        Catch
            LeerPaginaWebByTareaId = ""
        End Try
    End Function

    Public Function LeerAccionesByName(ByRef AccionesId As Long, ByVal AccionesCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AccionesId "
        sSQL = sSQL & "FROM (Acciones) "
        sSQL = sSQL & "WHERE (Acciones.AccionesCodigo = '" & AccionesCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                AccionesId = CLng(dtr("AccionesId").ToString)
            End While
            LeerAccionesByName = True
            dtr.Close()
        Catch
            LeerAccionesByName = False
        End Try
    End Function
    Public Function LeerAccionesNameByAccionesId(ByVal AccionesId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AccionesName "
        sSQL = sSQL & "FROM Acciones "
        sSQL = sSQL & "WHERE Acciones.AccionesId = " & AccionesId
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerAccionesNameByAccionesId = CStr(dtr("AccionesName").ToString)
            End While
            dtr.Close()
        Catch
            LeerAccionesNameByAccionesId = ""
        End Try
    End Function
    Public Function SeDebeEnviarCorreo(ByVal AccionesCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AccionesEnviaCorreo As Correo "
        sSQL = sSQL & "FROM Acciones "
        sSQL = sSQL & "WHERE Acciones.AccionesCodigo = '" & AccionesCodigo & "'"
        SeDebeEnviarCorreo = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                SeDebeEnviarCorreo = CBool(dtr("Correo").ToString)
            End While
            dtr.Close()
        Catch
            SeDebeEnviarCorreo = False
        End Try
    End Function


    Public Function LeerAccionesCodigoById(ByVal AccionesId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AccionesCodigo "
        sSQL = sSQL & "FROM (Acciones) "
        sSQL = sSQL & "WHERE (Acciones.AccionesId = " & AccionesId & ") "
        LeerAccionesCodigoById = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerAccionesCodigoById = CStr(dtr("AccionesCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerAccionesCodigoById = ""
        End Try
    End Function

    Public Function AccionesUpdate(ByVal AccionesId As Long, ByVal AccionesCodigo As String, ByVal AccionesName As String, ByVal AccionesDescription As String, ByVal AccionesSecuencia As Long, ByVal TipoProcesoSecuencia As Long, ByVal EtapasSecuencia As Long, ByVal EtapasName As String, ByVal EtapasId As Long, ByVal RolName As String, ByVal PaginaWebName As String, ByRef AccionesDuration As Long, ByVal AccionesEnviaCorreo As Boolean, ByVal AccionesAdvertirFechaFatal As Boolean, ByVal AccionesIsFlujoAlternativo As Boolean, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Acciones SET "
        strUpdate = strUpdate & "Acciones.AccionesCodigo = '" & AccionesCodigo & "', "
        strUpdate = strUpdate & "Acciones.AccionesName = '" & AccionesName & "', "
        strUpdate = strUpdate & "Acciones.AccionesDescription = '" & AccionesDescription & "', "
        strUpdate = strUpdate & "Acciones.AccionesSecuencia = " & AccionesSecuencia & ", "
        strUpdate = strUpdate & "Acciones.TipoProcesoSecuencia = " & TipoProcesoSecuencia & ", "
        strUpdate = strUpdate & "Acciones.EtapasSecuencia = " & EtapasSecuencia & ", "
        strUpdate = strUpdate & "Acciones.EtapasName = '" & EtapasName & "', "
        strUpdate = strUpdate & "Acciones.EtapasId = " & EtapasId & ", "
        strUpdate = strUpdate & "Acciones.RolName = '" & RolName & "', "
        strUpdate = strUpdate & "Acciones.PaginaWebName = '" & PaginaWebName & "', "
        strUpdate = strUpdate & "Acciones.AccionesDuration = " & AccionesDuration & ", "
        strUpdate = strUpdate & "Acciones.AccionesEnviaCorreo = " & CBool(AccionesEnviaCorreo) & ", "
        strUpdate = strUpdate & "Acciones.AccionesAdvertirFechaFatal = " & CBool(AccionesAdvertirFechaFatal) & ", "
        strUpdate = strUpdate & "Acciones.AccionesIsFlujoAlternativo = " & CBool(AccionesIsFlujoAlternativo) & ", "
        strUpdate = strUpdate & "Acciones.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Acciones.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Acciones.AccionesId = " & AccionesId
        Try
            AccionesUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & AccionesName, AccionesId, "Acciones", "")
        Catch
            AccionesUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & AccionesName, AccionesId, "Acciones", "")
        End Try
    End Function
    Public Function AccionesInsert(ByRef AccionesId As Long, ByVal AccionesCodigo As String, ByVal AccionesName As String, ByVal AccionesDescription As String, ByVal AccionesSecuencia As Long, ByVal TipoProcesoSecuencia As Long, ByVal EtapasSecuencia As Long, ByVal EtapasName As String, ByVal EtapasId As Long, ByVal RolName As String, ByVal PaginaWebName As String, ByRef AccionesDuration As Long, ByVal AccionesEnviaCorreo As Boolean, ByVal AccionesAdvertirFechaFatal As Boolean, ByVal AccionesIsFlujoAlternativo As Boolean, ByVal UserId As Long) As Long
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Acciones As New Acciones
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Try
            t = AccionesABM.MasterPartialInsert("AccionesId", "AccionesCodigo", "Acciones", MasterName, CLng(UserId), MasterId)
            AccionesCodigo = AccionesCodigo & "-" & MasterId
            AccionesInsert = Acciones.AccionesUpdate(MasterId, AccionesCodigo, AccionesName, AccionesDescription, AccionesSecuencia, TipoProcesoSecuencia, EtapasSecuencia, EtapasName, EtapasId, RolName, PaginaWebName, AccionesDuration, AccionesEnviaCorreo, AccionesAdvertirFechaFatal, AccionesIsFlujoAlternativo, UserId)
            AccionesInsert = MasterId
        Catch
            AccionesInsert = 0
        End Try
    End Function
    Public Function LeerAccionesDescriptionByName(ByVal AccionesCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AccionesName "
        sSQL = sSQL & "FROM (Acciones) "
        sSQL = sSQL & "WHERE (Acciones.AccionesCodigo = '" & AccionesCodigo & "') "
        LeerAccionesDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerAccionesDescriptionByName = CStr(dtr("AccionesName").ToString)
            End While
            dtr.Close()
        Catch
            LeerAccionesDescriptionByName = ""
        End Try
    End Function
    Public Function LeerIndicadoresCodigoByTareasCodigo(ByVal TareasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Acciones.IndicadoresCodigo "
        sSQL = sSQL & "FROM Tareas INNER JOIN Acciones ON Tareas.AccionesCodigo = Acciones.AccionesCodigo "
        sSQL = sSQL & "WHERE (((Tareas.TareasCodigo) = '" & TareasCodigo & "'))"

        LeerIndicadoresCodigoByTareasCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerIndicadoresCodigoByTareasCodigo = CStr(dtr("IndicadoresCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerIndicadoresCodigoByTareasCodigo = ""
        End Try
    End Function
    Public Function LeerTotalAccionesPorTablasRelacionadas(ByVal AccionesCodigo As String, ByVal AccionesId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en una descomposición de actividades por acción
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Acciones INNER JOIN AccionesActividades ON Acciones.AccionesCodigo = AccionesActividades.AccionesCodigo "
        sSQL = sSQL & "WHERE (((Acciones.AccionesId)= " & AccionesId & "))"
        LeerTotalAccionesPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalAccionesPorTablasRelacionadas = LeerTotalAccionesPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalAccionesPorTablasRelacionadas = 0
        End Try
        'Verifica si esta referenciada en una Tarea
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Acciones INNER JOIN Tareas ON Acciones.AccionesCodigo = Tareas.AccionesCodigo "
        sSQL = sSQL & "WHERE (((Acciones.AccionesCodigo)='" & AccionesCodigo & "'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalAccionesPorTablasRelacionadas = LeerTotalAccionesPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalAccionesPorTablasRelacionadas = LeerTotalAccionesPorTablasRelacionadas + 0
        End Try
        'Verifica si esta referenciada como acción inicial en un tipo de proceso.
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Acciones INNER JOIN TipoProceso ON Acciones.AccionesCodigo = TipoProceso.AccionesCodigo "
        sSQL = sSQL & "WHERE (((Acciones.AccionesCodigo)='" & AccionesCodigo & "'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalAccionesPorTablasRelacionadas = LeerTotalAccionesPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalAccionesPorTablasRelacionadas = LeerTotalAccionesPorTablasRelacionadas + 0
        End Try

    End Function
    Public Function AccionesDelete(ByVal AccionesId As Long, ByVal AccionesCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Acciones As New Acciones

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Acciones.LeerTotalAccionesPorTablasRelacionadas(AccionesCodigo, AccionesId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados a la Acci&oacuten " & AccionesCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie la Acci&oacuten en las Actividades, Acciones por Tareas o acci&oacute;n inicial en un tipo de proceso, antes de eliminarla de la lista"
            AccionesDelete = False
        Else
            Try
                ' Borra registro de la tabla de Gerencias
                '-------------------------------------
                strUpdate = "DELETE FROM Acciones WHERE AccionesId = " & AccionesId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina la Acción: " & AccionesCodigo, AccionesId, "Acciones", "")
                AccionesDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la Acción: " & AccionesCodigo, AccionesId, "Acciones", "")
                AccionesDelete = False
            End Try
        End If
    End Function
    Public Function LoadAccionesPorStakeholders(ByRef rptAcciones As Repeater, ByVal StakeholdersId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT StakeholdersPorProgramas.StakeholdersId AS Id, Programas.ProgramasCodigo AS Codigo, Programas.ProgramasName AS Nombre, Objetivos.ObjetivosName As Tipo, Acciones.AccionesName As Accion "
        sSQL = sSQL & "FROM ((((((StakeholdersPorProgramas INNER JOIN Programas ON StakeholdersPorProgramas.ProgramasId = Programas.ProgramasId) INNER JOIN ProgramasMapa ON Programas.ProgramasCodigo = ProgramasMapa.ProgramasCodigo) INNER JOIN Stakeholders ON (StakeholdersPorProgramas.StakeholdersId = Stakeholders.StakeholdersId) AND (ProgramasMapa.StakeholdersCodigo = Stakeholders.StakeholdersCodigo)) INNER JOIN AccionesPorStakeholdersPorPrograma ON ProgramasMapa.ProgramasMapaId = AccionesPorStakeholdersPorPrograma.ProgramasMapaId) INNER JOIN Acciones ON AccionesPorStakeholdersPorPrograma.AccionesId = Acciones.AccionesId) INNER JOIN Metas ON Acciones.MetasCodigo = Metas.MetasCodigo) INNER JOIN Objetivos ON Metas.ObjetivosCodigo = Objetivos.ObjetivosCodigo "
        sSQL = sSQL & "WHERE (((Stakeholders.StakeholdersId)=" & StakeholdersId & ")) "
        sSQL = sSQL & "ORDER BY Programas.ProgramasName, Objetivos.ObjetivosCodigo"
        Try
            dtrRutasPorViajes = AccesoEA.ListarRegistros(sSQL)

            rptAcciones.DataSource = dtrRutasPorViajes
            rptAcciones.DataBind()
            LoadAccionesPorStakeholders = True
            dtrRutasPorViajes.Close()
        Catch
            LoadAccionesPorStakeholders = False
        End Try
    End Function
    Public Function LeerHHyUSDPorAccion(ByVal AccionesId As Long, ByRef AccionesHH As Double, ByRef AccionesUSD As Double) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AccionesHH, AccionesUSD "
        sSQL = sSQL & "FROM (Acciones) "
        sSQL = sSQL & "WHERE (Acciones.Id = " & AccionesId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If Len(dtr("AccionesHH").ToString) = 0 Then
                    AccionesHH = 0
                Else
                    AccionesHH = CDbl(dtr("AccionesHH").ToString)
                End If
                If Len(dtr("AccionesUSD").ToString) = 0 Then
                    AccionesUSD = 0
                Else
                    AccionesUSD = CDbl(dtr("AccionesUSD").ToString)
                End If
            End While
            LeerHHyUSDPorAccion = True
            dtr.Close()
        Catch
            LeerHHyUSDPorAccion = False
        End Try
    End Function

    Public Function ListarAccionesPorRol(ByRef RolName As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim Acciones As New Acciones
        Dim TipoProceso As New TipoProceso

        strUpdate = "SELECT Acciones.AccionesId as Id, Acciones.AccionesCodigo as Codigo, Acciones.AccionesName As Name, Acciones.AccionesDescription As Descripcion, Acciones.EtapasName As Etapa "
        strUpdate = strUpdate & "FROM Acciones "
        'strUpdate = strUpdate & "WHERE (((Acciones.RolName)='" & RolName & "' AND TipoProcesoSecuencia = 2)) "
        strUpdate = strUpdate & "WHERE (((Acciones.RolName)='" & RolName & "' AND TipoProcesoSecuencia = 3)) "
        strUpdate = strUpdate & "ORDER BY Acciones.TipoProcesoSecuencia, Acciones.EtapasSecuencia, Acciones.AccionesSecuencia"
        ListarAccionesPorRol = ""

        CodigoHTML = "<table class=""popup_tabla_de_datos"">"
        'CodigoHTML = CodigoHTML & "<tr>"
        'CodigoHTML = CodigoHTML & "<th width=""200"">Acci&oacute;n</th>"
        'CodigoHTML = CodigoHTML & "<th width=""450"">Descripci&oacute;n</th>"
        'CodigoHTML = CodigoHTML & "</tr>"

        CodigoHTML = CodigoHTML & "<tr>"
        CodigoHTML = CodigoHTML & "<td colspan=""2""><h1>" & TipoProceso.LeerTipoProcesoNameBySecuencia(2) & "</h1></td>"
        CodigoHTML = CodigoHTML & "</tr>"


        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                If NombreEtapa <> dtr("Etapa").ToString Then
                    NombreEtapa = dtr("Etapa").ToString
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td colspan=""2""><h2>" & UCase(NombreEtapa) & "</h2></td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td width=""20"" valign=""middle"" align=""center""><br /><img src=""imgs/buscar.png"" alt=""?"" width=""16"" height=""16"" hspace=""5"" border=""0"" align=""left"" title=""Descripci&oacute;n de la actividad"" onclick=""verModalAccion('ConsultaAccion.aspx?Accion=" & dtr("Codigo").ToString & "')"" /></td>"
                CodigoHTML = CodigoHTML & "<td width=""630""><h3>" & dtr("Codigo").ToString & ": " & UCase(dtr("Name").ToString) & "</h3></td>"
                CodigoHTML = CodigoHTML & "</tr>"

                'CodigoHTML = CodigoHTML & "<tr>"
                'CodigoHTML = CodigoHTML & "<td><h3>Responsable</h3></td>"
                'CodigoHTML = CodigoHTML & "<td><h3>" & RolName & "</h3></td>"
                'CodigoHTML = CodigoHTML & "</tr>"
                'CodigoHTML = CodigoHTML & "<tr>"
                'CodigoHTML = CodigoHTML & "<td><h3>Objetivo</h3></td>"
                'CodigoHTML = CodigoHTML & "<td>" & dtr("Descripcion").ToString & "</td>"
                'CodigoHTML = CodigoHTML & "</tr>"
                'CodigoHTML = CodigoHTML & Acciones.ListarObservacionesPorAccion(dtr("Codigo").ToString)
                'CodigoHTML = CodigoHTML & Acciones.ListarPrecondicionesPorAccion(dtr("Codigo").ToString)
                'CodigoHTML = CodigoHTML & Acciones.ListarActividadesPorAccion(dtr("Codigo").ToString)
                'CodigoHTML = CodigoHTML & Acciones.ListarPostcondicionesPorAccion(dtr("Codigo").ToString)
                'CodigoHTML = CodigoHTML & Acciones.ListarDatosPorAccion(dtr("Codigo").ToString)
            End While
            dtr.Close()
        Catch

        End Try
        CodigoHTML = CodigoHTML & "</table>"
        ListarAccionesPorRol = CodigoHTML
    End Function
    Public Function ListarActividadesPorAccion(ByRef AccionesCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim i = 0

        strUpdate = "SELECT AccionesActividades.AccionesActividadesSecuencia As Secuencia, AccionesActividades.AccionesActividadesDescription As Descripcion "
        strUpdate = strUpdate & "FROM AccionesActividades "
        strUpdate = strUpdate & "WHERE (((AccionesActividades.AccionesCodigo)='" & AccionesCodigo & "')) "
        strUpdate = strUpdate & "ORDER BY AccionesActividades.AccionesActividadesSecuencia"

        ListarActividadesPorAccion = ""
        CodigoHTML = CodigoHTML & "<tr>"
        CodigoHTML = CodigoHTML & "<td><h3>Actividades</h3></td>"
        CodigoHTML = CodigoHTML & "<td><ol>"
        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<li>" & dtr("Descripcion").ToString & "</li>"
            End While
            dtr.Close()
        Catch

        End Try
        CodigoHTML = CodigoHTML & "</ol></td></tr>"
        ListarActividadesPorAccion = CodigoHTML
    End Function
    Public Function ListarPrecondicionesPorAccion(ByRef AccionesCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim i = 0

        strUpdate = "SELECT Acciones_1.AccionesCodigo as Codigo, Acciones_1.AccionesName as Accion, Acciones_1.RolName As Rol, TransicionAcciones.EstadoProcesoCodigo As Precondicion "
        strUpdate = strUpdate & "FROM (TransicionAcciones INNER JOIN Acciones ON TransicionAcciones.NextStateId = Acciones.AccionesId) INNER JOIN Acciones AS Acciones_1 ON TransicionAcciones.CurrentStateId = Acciones_1.AccionesId "
        strUpdate = strUpdate & "WHERE (((Acciones.AccionesCodigo)='" & AccionesCodigo & "'))"

        ListarPrecondicionesPorAccion = ""

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td><h3>Precondiciones</h3></td>"
                    CodigoHTML = CodigoHTML & "<td>Para la ejecuci&oacute;n de esta acci&oacute;n y sus actividades deben estar cumplidas las siguientes condiciones:</td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td align=""right""><i><b>" & dtr("Rol").ToString & "</b></i>: " & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & "Acci&oacute;n previa: " & dtr("Codigo").ToString & " - " & dtr("Accion").ToString & "<br />Estado del Proceso: " & dtr("Precondicion").ToString & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch

        End Try
        If Len(CodigoHTML) = 0 Then
            CodigoHTML = CodigoHTML & "<tr>"
            CodigoHTML = CodigoHTML & "<td><h3>Precondiciones</h3></td>"
            CodigoHTML = CodigoHTML & "<td>La acci&oacute;n no tiene precondiciones para su ejecuci&oacute;n</td>"
            CodigoHTML = CodigoHTML & "</tr>"
        End If
        ListarPrecondicionesPorAccion = CodigoHTML
    End Function
    Public Function ListarPredecesorasPorAccion(ByRef AccionesCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim i = 0
        Dim CodigoAccion As String = ""

        strUpdate = "SELECT Acciones_1.AccionesCodigo as Accion, Acciones_1.AccionesIsFlujoAlternativo As Alternativo "
        strUpdate = strUpdate & "FROM (TransicionAcciones INNER JOIN Acciones ON TransicionAcciones.NextStateId = Acciones.AccionesId) INNER JOIN Acciones AS Acciones_1 ON TransicionAcciones.CurrentStateId = Acciones_1.AccionesId "
        strUpdate = strUpdate & "WHERE (((Acciones.AccionesCodigo)='" & AccionesCodigo & "'))"

        ListarPredecesorasPorAccion = ""

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                i = i + 1
                If CBool(dtr("Alternativo").ToString) = True Then
                    CodigoAccion = "<i>" & dtr("Accion").ToString & "</i>"
                Else
                    CodigoAccion = dtr("Accion").ToString
                End If
                If i = 1 Then
                    CodigoHTML = CodigoHTML & CodigoAccion
                Else
                    CodigoHTML = CodigoHTML & ", <br />" & CodigoAccion
                End If
            End While
            dtr.Close()
        Catch

        End Try
        ListarPredecesorasPorAccion = CodigoHTML
    End Function
    Public Function FechaTerminoMasTardiaTareasPredecesoras(ByRef AccionesCodigo As String, ByVal AccionesProgramadas() As String, ByVal FechaProgramadas() As Date, ByVal j As Integer, ByVal FechaInicio As Date) As Date

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim i = 0
        Dim CodigoAccion As String = ""
        Dim Acciones As New Acciones

        strUpdate = "SELECT Acciones_1.AccionesCodigo as Accion, Acciones_1.AccionesIsFlujoAlternativo As Alternativo "
        strUpdate = strUpdate & "FROM (TransicionAcciones INNER JOIN Acciones ON TransicionAcciones.NextStateId = Acciones.AccionesId) INNER JOIN Acciones AS Acciones_1 ON TransicionAcciones.CurrentStateId = Acciones_1.AccionesId "
        strUpdate = strUpdate & "WHERE (((Acciones.AccionesCodigo)='" & AccionesCodigo & "'))"

        FechaTerminoMasTardiaTareasPredecesoras = FechaInicio

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                If CBool(dtr("Alternativo").ToString) = False Then
                    For i = 1 To j - 1
                        If AccionesProgramadas(i) = dtr("Accion").ToString Then
                            If FechaProgramadas(i) > FechaTerminoMasTardiaTareasPredecesoras Then
                                FechaTerminoMasTardiaTareasPredecesoras = FechaProgramadas(i)
                            End If
                        End If
                    Next
                Else
                    'FechaTerminoMasTardiaTareasPredecesoras = Acciones.FechaTerminoMasTardiaTareasPredecesoras(dtr("Accion").ToString, AccionesProgramadas, FechaProgramadas, j, FechaInicio)
                End If
            End While
            dtr.Close()
        Catch

        End Try

    End Function
    Public Function TareasPredecesorasParaGantt(ByRef AccionesCodigo As String, ByVal AccionesProgramadas() As String, ByVal CodigosGantt() As Long, ByVal j As Integer, ByVal FechaInicio As Date) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim i As Integer = 0
        Dim k As Integer = 0
        Dim CodigoAccion As String = ""
        Dim Acciones As New Acciones

        strUpdate = "SELECT Acciones_1.AccionesCodigo as Accion, Acciones_1.AccionesIsFlujoAlternativo As Alternativo "
        strUpdate = strUpdate & "FROM (TransicionAcciones INNER JOIN Acciones ON TransicionAcciones.NextStateId = Acciones.AccionesId) INNER JOIN Acciones AS Acciones_1 ON TransicionAcciones.CurrentStateId = Acciones_1.AccionesId "
        strUpdate = strUpdate & "WHERE (((Acciones.AccionesCodigo)='" & AccionesCodigo & "'))"

        TareasPredecesorasParaGantt = ""

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                If CBool(dtr("Alternativo").ToString) = False Then
                    k = k + 1
                    For i = 1 To j - 1
                        If AccionesProgramadas(i) = dtr("Accion").ToString Then
                            If k = 1 Then
                                TareasPredecesorasParaGantt = CodigosGantt(i)
                            Else
                                TareasPredecesorasParaGantt = TareasPredecesorasParaGantt & "," & CodigosGantt(i)
                            End If
                        End If
                    Next
                Else
                    'FechaTerminoMasTardiaTareasPredecesoras = Acciones.FechaTerminoMasTardiaTareasPredecesoras(dtr("Accion").ToString, AccionesProgramadas, FechaProgramadas, j, FechaInicio)
                End If
            End While
            dtr.Close()
        Catch

        End Try

    End Function
    Public Function FechaInicioTerminoReal(ByVal AccionesCodigo As String, ByVal CarpetaJudicialCodigo As String, ByRef FechaInicio As Date, ByRef FechaTermino As Date, ByRef Dias As Integer) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim i = 0
        Dim CodigoAccion As String = ""

        strUpdate = "SELECT Min(TareasLog.TareasLogTime) AS FechaInicio, Max(TareasLog.TareasLogTime) AS FechaTermino "
        strUpdate = strUpdate & "FROM Tareas INNER JOIN TareasLog ON Tareas.TareasCodigo = TareasLog.TareasCodigo "
        strUpdate = strUpdate & "GROUP BY Tareas.AccionesCodigo, Tareas.PGGCodigo "
        strUpdate = strUpdate & "HAVING (((Tareas.PGGCodigo)='" & CarpetaJudicialCodigo & "') AND ((Tareas.AccionesCodigo)='" & AccionesCodigo & "'))"

        FechaInicioTerminoReal = False

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                FechaInicio = CDate(dtr("FechaInicio").ToString)
                FechaTermino = CDate(dtr("FechaTermino").ToString)
                Dias = DateDiff(DateInterval.Day, FechaInicio, FechaTermino)
                FechaInicioTerminoReal = True
            End While
            dtr.Close()
        Catch

        End Try

    End Function

    Public Function ListarPostcondicionesPorAccion(ByRef AccionesCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim i = 0

        strUpdate = "SELECT Acciones_1.AccionesCodigo as Codigo, Acciones_1.AccionesName as Accion, Acciones_1.RolName As Rol, TransicionAcciones.EstadoProcesoCodigo As PostCondicion "
        strUpdate = strUpdate & "FROM (TransicionAcciones INNER JOIN Acciones ON TransicionAcciones.CurrentStateId = Acciones.AccionesId) INNER JOIN Acciones AS Acciones_1 ON TransicionAcciones.NextStateId = Acciones_1.AccionesId "
        strUpdate = strUpdate & "WHERE (((Acciones.AccionesCodigo)='" & AccionesCodigo & "'))"

        ListarPostcondicionesPorAccion = ""

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td><h3>Postcondiciones</h3></td>"
                    CodigoHTML = CodigoHTML & "<td>Luego de la ejecuci&oacute;n de esta acci&oacute;n y sus actividades, el proceso judicial deber&aacute; quedar en alguno de los siguientes estados o postcondiciones:</td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td align=""right""><i><b>" & dtr("Rol").ToString & "</b></i>: " & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & "Acci&oacute;n posterior: " & dtr("Codigo").ToString & " - " & dtr("Accion").ToString & "<br />Estado del Proceso: " & dtr("Postcondicion").ToString & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch

        End Try
        If Len(CodigoHTML) = 0 Then
            CodigoHTML = CodigoHTML & "<tr>"
            CodigoHTML = CodigoHTML & "<td><h3>Postcondiciones</h3></td>"
            CodigoHTML = CodigoHTML & "<td>La acci&oacute;n no tiene postcondiciones luego de su ejecuci&oacute;n</td>"
            CodigoHTML = CodigoHTML & "</tr>"
        End If
        ListarPostcondicionesPorAccion = CodigoHTML
    End Function
    Public Function ListarSucesorasPorAccion(ByRef AccionesCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim i = 0
        Dim CodigoAccion As String = ""

        strUpdate = "SELECT Acciones_1.AccionesCodigo as Accion, Acciones_1.AccionesIsFlujoAlternativo As Alternativo "
        strUpdate = strUpdate & "FROM (TransicionAcciones INNER JOIN Acciones ON TransicionAcciones.CurrentStateId = Acciones.AccionesId) INNER JOIN Acciones AS Acciones_1 ON TransicionAcciones.NextStateId = Acciones_1.AccionesId "
        strUpdate = strUpdate & "WHERE (((Acciones.AccionesCodigo)='" & AccionesCodigo & "'))"

        ListarSucesorasPorAccion = ""

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                i = i + 1
                If CBool(dtr("Alternativo").ToString) = True Then
                    CodigoAccion = "<i>" & dtr("Accion").ToString & "</i>"
                Else
                    CodigoAccion = dtr("Accion").ToString
                End If
                If i = 1 Then
                    CodigoHTML = CodigoHTML & CodigoAccion
                Else
                    CodigoHTML = CodigoHTML & ", <br />" & CodigoAccion
                End If
            End While
            dtr.Close()
        Catch

        End Try
        ListarSucesorasPorAccion = CodigoHTML
    End Function


    Public Function ListarObservacionesPorAccion(ByRef AccionesCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim GlosaDuracion As String = "Esta actividad tiene una duraci&oacute;n m&aacute;xima de "
        Dim GlosaCorreo As String = "Al dar por concluida la actividad se enviara un correo al resto de los miembros del equipo jur&iacute;dico"
        Dim GlosaFechaFatal As String = "Esta actividad tiene una fecha fatal, por tanto esa fecha debe ser cumplida"
        Dim GlosaCorreoNegativa As String = "Al dar por concluida la actividad no se enviara un correo al resto de los miembros del equipo jur&iacute;dico"
        Dim GlosaFechaFatalNegativa As String = "Esta actividad no tiene una fecha fatal, pero igualmente el responsable debe hacer todo el esfuerzo para cumplirla, a menos que la fecha de t&eacute;rmino depende de un tercero sobre el cual no tiene capacidad de presi&oacute;n"
        Dim GlosaFlujoPrincipal As String = "Esta actividad es parte del flujo principal del proceso"
        Dim GlosaFlujoAlternativo As String = "Esta actividad es parte de un flujo alternativo que deriva de una actividad del flujo principal"

        strUpdate = "SELECT Acciones.AccionesDuration, Acciones.AccionesEnviaCorreo, Acciones.AccionesAdvertirFechaFatal, Acciones.AccionesIsFlujoAlternativo "
        strUpdate = strUpdate & "FROM Acciones "
        strUpdate = strUpdate & "WHERE Acciones.AccionesCodigo = '" & AccionesCodigo & "'"

        ListarObservacionesPorAccion = ""

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read

                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td><h3>Observaciones</h3></td>"
                CodigoHTML = CodigoHTML & "<td><ol>"
                If CInt(dtr("AccionesDuration").ToString) > 1 Then
                    CodigoHTML = CodigoHTML & "<li>" & GlosaDuracion & CInt(dtr("AccionesDuration").ToString) & " d&iacute;as</li>"
                Else
                    CodigoHTML = CodigoHTML & "<li>" & GlosaDuracion & CInt(dtr("AccionesDuration").ToString) & " d&iacute;a</li>"
                End If
                If CBool(dtr("AccionesEnviaCorreo").ToString) = True Then
                    CodigoHTML = CodigoHTML & "<li>" & GlosaCorreo & "</li>"
                Else
                    CodigoHTML = CodigoHTML & "<li>" & GlosaCorreoNegativa & "</li>"
                End If
                If CBool(dtr("AccionesAdvertirFechaFatal").ToString) = True Then
                    CodigoHTML = CodigoHTML & "<li>" & GlosaFechaFatal & "</li>"
                Else
                    CodigoHTML = CodigoHTML & "<li>" & GlosaFechaFatalNegativa & "</li>"
                End If
                If CBool(dtr("AccionesIsFlujoAlternativo").ToString) = False Then
                    CodigoHTML = CodigoHTML & "<li>" & GlosaFlujoPrincipal & "</li>"
                Else
                    CodigoHTML = CodigoHTML & "<li>" & GlosaFlujoAlternativo & "</li>"
                End If
                CodigoHTML = CodigoHTML & "</ol></td>"
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch

        End Try
        ListarObservacionesPorAccion = CodigoHTML
    End Function


    Public Function ListarDatosPorAccion(ByRef AccionesCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim Accion As String = ""
        Dim i = 0

        strUpdate = "SELECT FormularioWeb_1.FormularioWebLabel As Nombre, FormularioWeb_1.FormularioWebToolTip As Descripcion "
        strUpdate = strUpdate & "FROM (Acciones INNER JOIN PaginaWeb ON Acciones.PaginaWebName = PaginaWeb.PaginaWebName) INNER JOIN (FormularioWeb INNER JOIN FormularioWeb AS FormularioWeb_1 ON FormularioWeb.FormularioWebId = FormularioWeb_1.FormularioWebPId) ON PaginaWeb.FormularioWebNumber = FormularioWeb.FormularioWebNumber "
        strUpdate = strUpdate & "WHERE(((Acciones.AccionesCodigo) = '" & AccionesCodigo & "') And ((FormularioWeb.FormularioWebSection) = 'FormGroup') And ((FormularioWeb_1.FormularioWebIsVisibleToInit) = True))"
        strUpdate = strUpdate & "ORDER BY FormularioWeb.FormularioWebSecuencia, FormularioWeb_1.FormularioWebSecuencia"

        ListarDatosPorAccion = ""

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td><h3>Datos</h3></td>"
                    CodigoHTML = CodigoHTML & "<td>La acci&oacute;n requiere que el usuario registre los siguientes datos, que quedaran registrados en la base de datos del sistema y asociados a la carpeta judicial.<br />Adicionalmente el usuario siempre deber&aacute; registrar el t&eacute;rmino de su tarea y deber&aacute; escoger la post condici&oacute;n en la que ha dejado el proceso y tambi&eacute;n podr&aacute; apoyarse con el resto de las funcionalidades del sistema que le permit&eacute;n enviar correos y dejar mensajes de advertencia al resto de los responsables del proceso judicial</td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td align=""right""><i><b>" & dtr("Nombre").ToString & "</b></i></td>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Descripcion").ToString & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch

        End Try

        If Len(CodigoHTML) = 0 Then
            CodigoHTML = CodigoHTML & "<tr>"
            CodigoHTML = CodigoHTML & "<td><h3>Datos</h3></td>"
            CodigoHTML = CodigoHTML & "<td>La acci&oacute;n  no requiere que el usuario registre datos espec&iacute;ficos, pero dependiendo de sus privilegios podr&aacute; modificar datos previamente registrados en la base de datos del sistema.<br />Adicionalmente el usuario siempre deber&aacute; registrar el t&eacute;rmino de su tarea y deber&aacute; escoger la post condici&oacute;n en la que ha dejado el proceso y tambi&eacute;n podr&aacute; apoyarse con el resto de las funcionalidades del sistema que le permit&eacute;n enviar correos y dejar mensajes de advertencia al resto de los responsables del proceso judicial</td>"
            CodigoHTML = CodigoHTML & "</tr>"
        End If

        ListarDatosPorAccion = CodigoHTML

        strUpdate = "SELECT FormularioWeb.FormularioWebLabel As Grupo, FormularioWeb.FormularioWebToolTip As DescripcionGrupo, FormularioWeb_2.FormularioWebLabel As Nombre, FormularioWeb_2.FormularioWebToolTip As Descripcion "
        strUpdate = strUpdate & "FROM ((((Acciones INNER JOIN PaginaWeb ON Acciones.PaginaWebName = PaginaWeb.PaginaWebName) INNER JOIN FormularioWeb ON PaginaWeb.FormularioWebNumber = FormularioWeb.FormularioWebNumber) INNER JOIN PaginaWeb AS PaginaWeb_1 ON FormularioWeb.FormularioWebFormCall = PaginaWeb_1.PaginaWebName) INNER JOIN FormularioWeb AS FormularioWeb_1 ON PaginaWeb_1.FormularioWebNumber = FormularioWeb_1.FormularioWebNumber) INNER JOIN FormularioWeb AS FormularioWeb_2 ON FormularioWeb_1.FormularioWebId = FormularioWeb_2.FormularioWebPId "
        strUpdate = strUpdate & "WHERE(((Acciones.AccionesCodigo) = '" & AccionesCodigo & "') And ((FormularioWeb.FormularioWebTipoControl) = 'Tabs') And ((FormularioWeb.FormularioWebIsVisibleToInit) = True) And ((FormularioWeb_1.FormularioWebSection) = 'FormGroup') And ((FormularioWeb_2.FormularioWebIsVisibleToInit) = True)) "
        strUpdate = strUpdate & "ORDER BY FormularioWeb.FormularioWebSecuencia, FormularioWeb_1.FormularioWebSecuencia, FormularioWeb_2.FormularioWebSecuencia"

        CodigoHTML = ""
        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td><h3>Otros Datos</h3></td>"
                    CodigoHTML = CodigoHTML & "<td></td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                    Accion = dtr("Grupo").ToString
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td align=""right""><h4>" & dtr("Grupo").ToString & "</h4></td>"
                    CodigoHTML = CodigoHTML & "<td><i>" & dtr("DescripcionGrupo").ToString & "</i></td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                End If
                If Accion <> dtr("Grupo").ToString Then
                    Accion = dtr("Grupo").ToString
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td align=""right""><h4>" & dtr("Grupo").ToString & "</h4></td>"
                    CodigoHTML = CodigoHTML & "<td><i>" & dtr("DescripcionGrupo").ToString & "</i></td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td align=""right""><i><b>" & dtr("Nombre").ToString & "</b></i></td>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Descripcion").ToString & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch

        End Try

        ListarDatosPorAccion = ListarDatosPorAccion & CodigoHTML

    End Function

    Public Function LeerDurationPorAccion(ByVal AccionesCodigo As String) As Double
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AccionesDuration As Dias "
        sSQL = sSQL & "FROM (Acciones) "
        sSQL = sSQL & "WHERE (Acciones.AccionesCodigo = '" & AccionesCodigo & "') "
        LeerDurationPorAccion = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If Len(dtr("Dias").ToString) = 0 Then
                    LeerDurationPorAccion = 0
                Else
                    LeerDurationPorAccion = CDbl(dtr("Dias").ToString)
                End If
            End While
            dtr.Close()
        Catch
            LeerDurationPorAccion = 0
        End Try
    End Function
    Public Function LeerRolPorAccion(ByVal AccionesCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select RolName As Rol "
        sSQL = sSQL & "FROM (Acciones) "
        sSQL = sSQL & "WHERE (Acciones.AccionesCodigo = '" & AccionesCodigo & "') "
        LeerRolPorAccion = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If Len(dtr("Rol").ToString) = 0 Then
                    LeerRolPorAccion = ""
                Else
                    LeerRolPorAccion = CStr(dtr("Rol").ToString)
                End If
            End While
            dtr.Close()
        Catch
            LeerRolPorAccion = ""
        End Try
    End Function
    Public Function ListarActividadesPorTareasId(ByVal TareasId As Long, ByVal TareasName As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""

        strUpdate = "SELECT AccionesActividades.AccionesActividadesSecuencia as Secuencia, AccionesActividades.AccionesActividadesDescription as Descripcion "
        strUpdate = strUpdate & "FROM Tareas INNER JOIN AccionesActividades ON Tareas.AccionesCodigo = AccionesActividades.AccionesCodigo "
        strUpdate = strUpdate & "WHERE Tareas.TareasId=" & TareasId


        ListarActividadesPorTareasId = ""

        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
        CodigoHTML = CodigoHTML & "<tr>"
        CodigoHTML = CodigoHTML & "<td><h1>" & "Lista de Actividades a Ejecutar" & "</h1></td>"
        CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & "Actividades" & "')"" title=""Expanda o contraiga para visualizar o esconder el detalle de las actividades a ejecutar para cumplir con el objetivo de la tarea asignada"" /></td>"
        CodigoHTML = CodigoHTML & "</tr>"
        CodigoHTML = CodigoHTML & "</table>"
        CodigoHTML = CodigoHTML & "<div id=""subgrilla" & "Actividades" & """ class=""invisible"">"
        CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
        CodigoHTML = CodigoHTML & "<caption>" & TareasName & "</caption>"
        CodigoHTML = CodigoHTML & "<tr>"
        CodigoHTML = CodigoHTML & "<th width=""50"">Secuencia</th>"
        CodigoHTML = CodigoHTML & "<th width=""600"">Descripci&oacute;n</th>"
        CodigoHTML = CodigoHTML & "</tr>"

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Secuencia").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Descripcion").ToString & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch

        End Try
        CodigoHTML = CodigoHTML & "</table></div>"
        ListarActividadesPorTareasId = CodigoHTML
    End Function
    Public Function ListarAccionesPorProceso(ByRef TipoProcesoSecuencia As Long, Optional ByVal Formato As String = "CodigoHTML") As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim Acciones As New Acciones

        strUpdate = "SELECT Acciones.AccionesId as Id, Acciones.AccionesCodigo as Codigo, Acciones.AccionesName As Name, Acciones.AccionesDescription As Descripcion, Acciones.EtapasName As Etapa, Acciones.RolName as RolName "
        strUpdate = strUpdate & "FROM Acciones "
        strUpdate = strUpdate & "WHERE TipoProcesoSecuencia = " & TipoProcesoSecuencia & " "
        strUpdate = strUpdate & "ORDER BY Acciones.TipoProcesoSecuencia, Acciones.EtapasSecuencia, Acciones.AccionesSecuencia"

        ListarAccionesPorProceso = ""

        If Formato = "CodigoHTML" Then
            CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
        Else
            CodigoHTML = CodigoHTML & "<table width=""660"" border=""1"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Verdana;font-size:8pt;border:1px solid #FFFFFF;"">"
        End If
        'CodigoHTML = CodigoHTML & "<tr>"
        'CodigoHTML = CodigoHTML & "<th width=""200"">Acci&oacute;n</th>"
        'CodigoHTML = CodigoHTML & "<th width=""450"">Descripci&oacute;n</th>"
        'CodigoHTML = CodigoHTML & "</tr>"

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                If NombreEtapa <> dtr("Etapa").ToString Then
                    NombreEtapa = dtr("Etapa").ToString
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td colspan=""2""><h2>" & UCase(NombreEtapa) & "</h2></td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td width=""20"" valign=""middle"" align=""center""><br /><img src=""imgs/buscar.png"" alt=""?"" width=""16"" height=""16"" hspace=""5"" border=""0"" align=""left"" title=""Descripci&oacute;n de la actividad"" onclick=""verModalAccion('ConsultaAccion.aspx?Accion=" & dtr("Codigo").ToString & "')"" /></td>"
                CodigoHTML = CodigoHTML & "<td width=""630""><h3>" & dtr("Codigo").ToString & ": " & UCase(dtr("Name").ToString) & "</h3></td>"
                CodigoHTML = CodigoHTML & "</tr>"


                'CodigoHTML = CodigoHTML & "<tr>"
                'CodigoHTML = CodigoHTML & "<td colspan=""2""><h3>" & dtr("Codigo").ToString & ": " & UCase(dtr("Name").ToString) & "</h3></td>"
                'CodigoHTML = CodigoHTML & "</tr>"
                'CodigoHTML = CodigoHTML & "<tr>"
                'CodigoHTML = CodigoHTML & "<td><h4>Responsable</h4></td>"
                'CodigoHTML = CodigoHTML & "<td><h4>" & dtr("RolName").ToString & "</h4></td>"
                'CodigoHTML = CodigoHTML & "</tr>"
                'CodigoHTML = CodigoHTML & "<tr>"
                'CodigoHTML = CodigoHTML & "<td><h4>Objetivo</h4></td>"
                'CodigoHTML = CodigoHTML & "<td>" & dtr("Descripcion").ToString & "</td>"
                'CodigoHTML = CodigoHTML & "</tr>"
                'CodigoHTML = CodigoHTML & Acciones.ListarObservacionesPorAccion(dtr("Codigo").ToString)
                'CodigoHTML = CodigoHTML & Acciones.ListarPrecondicionesPorAccion(dtr("Codigo").ToString)
                'CodigoHTML = CodigoHTML & Acciones.ListarActividadesPorAccion(dtr("Codigo").ToString)
                'CodigoHTML = CodigoHTML & Acciones.ListarPostcondicionesPorAccion(dtr("Codigo").ToString)
                'CodigoHTML = CodigoHTML & Acciones.ListarDatosPorAccion(dtr("Codigo").ToString)
            End While
            dtr.Close()
        Catch

        End Try
        CodigoHTML = CodigoHTML & "</table>"
        ListarAccionesPorProceso = CodigoHTML




    End Function
    Public Function ListarPlanPorProceso(ByVal TipoProcesoSecuencia As Long, ByVal CarpetaJudicialCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim Acciones As New Acciones
        Dim Usuarios As New Usuarios
        Dim Dias As Double
        Dim FechaAdjudicacion As Date = CDate(CarpetaJudicial.LeerFechaAdjudicacion(CarpetaJudicialCodigo))
        Dim FechaInicioTareas As Date
        Dim FechaTerminoTareas As Date
        Dim FechaInicioReal As Date
        Dim FechaTerminoReal As Date
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim t As Boolean
        Dim Codigos(299) As String
        Dim FechasTermino(299) As Date


        strUpdate = "SELECT Acciones.AccionesId as Id, Acciones.AccionesCodigo as Codigo, Acciones.AccionesName As Name, Acciones.AccionesDuration As Duration, Acciones.EtapasName As Etapa, Acciones.RolName as RolName, Acciones.AccionesIsFlujoAlternativo as IsAlternativo "
        strUpdate = strUpdate & "FROM Acciones "
        strUpdate = strUpdate & "WHERE TipoProcesoSecuencia = " & TipoProcesoSecuencia & " "
        strUpdate = strUpdate & "ORDER BY Acciones.TipoProcesoSecuencia, Acciones.EtapasSecuencia, Acciones.AccionesSecuencia"

        ListarPlanPorProceso = ""

        CodigoHTML = CodigoHTML & "<u><b>" & UCase("Plan de Trabajo") & "</b></u><br />"
        CodigoHTML = CodigoHTML & "<table width=""660"" border=""1"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Verdana;font-size:8pt;border:1px solid #FFFFFF;"">"
        CodigoHTML = CodigoHTML & "<tr>"
        CodigoHTML = CodigoHTML & "<td colspan=""10"">Solo se planifican las actividades principales. Las situaciones de excepci&oacute;n se mencionan pero no se hacen estimaciones de sus tiempos de proceso, pues estas estimaciones estan implicitas en los tiempos estimados para las actividades principales</td>"
        CodigoHTML = CodigoHTML & "</tr>"
        CodigoHTML = CodigoHTML & "<tr>"
        CodigoHTML = CodigoHTML & "<th>Etapa</th>"
        CodigoHTML = CodigoHTML & "<th colspan=""3"">Plan</th>"
        CodigoHTML = CodigoHTML & "<th colspan=""3"">Real</th>"
        CodigoHTML = CodigoHTML & "<th colspan=""3""></th>"
        CodigoHTML = CodigoHTML & "</tr>"
        CodigoHTML = CodigoHTML & "<tr>"
        CodigoHTML = CodigoHTML & "<th>Acci&oacute;n</th>"
        CodigoHTML = CodigoHTML & "<th>D&iacute;as</th>"
        CodigoHTML = CodigoHTML & "<th width=""66"">Comienzo</th>"
        CodigoHTML = CodigoHTML & "<th width=""66"">Fin</th>"
        CodigoHTML = CodigoHTML & "<th>D&iacute;as</th>"
        CodigoHTML = CodigoHTML & "<th width=""66"">Comienzo</th>"
        CodigoHTML = CodigoHTML & "<th width=""66"">Fin</th>"
        CodigoHTML = CodigoHTML & "<th>Pred.</th>"
        CodigoHTML = CodigoHTML & "<th>Sig.</th>"
        CodigoHTML = CodigoHTML & "<th>Resp.</th>"
        CodigoHTML = CodigoHTML & "</tr>"


        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                i = i + 1

                If i = 1 Then
                    Dias = CDbl(dtr("Duration").ToString)
                    FechaInicioTareas = FechaAdjudicacion
                    FechaTerminoTareas = DateAdd(DateInterval.Day, Dias, FechaInicioTareas)
                    Codigos(i) = dtr("Codigo").ToString
                    FechasTermino(i) = FechaTerminoTareas
                Else
                    Dias = CDbl(dtr("Duration").ToString)
                    If CBool(dtr("IsAlternativo").ToString) = False Then 'Solo se planifican las actividades del flujo principal
                        ' Aqui invocar una rutina que seleccione la mayor fecha de termino entre las tareas predecesoras y la coloque como fecha de inicio de la tarea
                        'FechaInicioTareas = FechaTerminoTareas
                        FechaInicioTareas = Acciones.FechaTerminoMasTardiaTareasPredecesoras(dtr("Codigo").ToString, Codigos, FechasTermino, i, FechaAdjudicacion)
                        FechaTerminoTareas = DateAdd(DateInterval.Day, Dias, FechaInicioTareas)
                        Codigos(i) = dtr("Codigo").ToString
                        FechasTermino(i) = FechaTerminoTareas
                    End If

                End If
                If NombreEtapa <> dtr("Etapa").ToString Then
                    NombreEtapa = dtr("Etapa").ToString
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td><b>" & UCase(NombreEtapa) & "</b></td>"
                    CodigoHTML = CodigoHTML & "<td></td>"
                    CodigoHTML = CodigoHTML & "<td></td>"
                    CodigoHTML = CodigoHTML & "<td></td>"
                    CodigoHTML = CodigoHTML & "<td></td>"
                    CodigoHTML = CodigoHTML & "<td></td>"
                    CodigoHTML = CodigoHTML & "<td></td>"
                    CodigoHTML = CodigoHTML & "<td></td>"
                    CodigoHTML = CodigoHTML & "<td></td>"
                    CodigoHTML = CodigoHTML & "<td></td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                If CBool(dtr("IsAlternativo").ToString) = False Then
                    CodigoHTML = CodigoHTML & "<td>" & dtr("Codigo").ToString & " (" & dtr("Id").ToString & "): " & dtr("Name").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "<td align=""center"">" & Dias & "</td>"
                    CodigoHTML = CodigoHTML & "<td align=""center"">" & FormatDateTime(FechaInicioTareas, DateFormat.ShortDate) & "</td>"
                    CodigoHTML = CodigoHTML & "<td align=""center"">" & FormatDateTime(FechaTerminoTareas, DateFormat.ShortDate) & "</td>"
                Else
                    CodigoHTML = CodigoHTML & "<td colspan=""4""><ul><li><i>" & dtr("Codigo").ToString & ": " & dtr("Name").ToString & "</i></li></ul></td>"
                End If
                If Acciones.FechaInicioTerminoReal(dtr("Codigo").ToString, CarpetaJudicialCodigo, FechaInicioReal, FechaTerminoReal, Dias) = True Then
                    CodigoHTML = CodigoHTML & "<td align=""center"">" & Dias & "</td>"
                    CodigoHTML = CodigoHTML & "<td align=""center"">" & FormatDateTime(FechaInicioReal, DateFormat.ShortDate) & "</td>"
                    CodigoHTML = CodigoHTML & "<td align=""center"">" & FormatDateTime(FechaTerminoReal, DateFormat.ShortDate) & "</td>"
                Else
                    CodigoHTML = CodigoHTML & "<td>" & "" & "</td>"
                    CodigoHTML = CodigoHTML & "<td>" & "" & "</td>"
                    CodigoHTML = CodigoHTML & "<td>" & "" & "</td>"
                End If

                CodigoHTML = CodigoHTML & "<td align=""center"">" & Acciones.ListarPredecesorasPorAccion(dtr("Codigo").ToString) & "</td>"
                CodigoHTML = CodigoHTML & "<td align=""center"">" & Acciones.ListarSucesorasPorAccion(dtr("Codigo").ToString) & "</td>"
                'CodigoHTML = CodigoHTML & "<td>" & Usuarios.LeerUsuariosDescriptionByName(CarpetaJudicial.DevolverUsuarioPorRol(dtr("RolName").ToString, CarpetaJudicialCodigo)) & "</td>"
                CodigoHTML = CodigoHTML & "<td align=""center"">" & dtr("RolName").ToString & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch

        End Try
        CodigoHTML = CodigoHTML & "</table>"
        ListarPlanPorProceso = CodigoHTML
    End Function
    Public Function ListarSituacionPorEtapasDelProceso(ByVal Estado As String, ByVal AccionesCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String

        strUpdate = "Select Acciones.EtapasSecuencia As Etapa "
        strUpdate = strUpdate & "FROM Acciones "
        strUpdate = strUpdate & "WHERE (((Acciones.AccionesCodigo)='" & AccionesCodigo & "'))"

        ListarSituacionPorEtapasDelProceso = ""

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                Select Case dtr("Etapa").ToString
                    Case 1 ' Encargo
                        CodigoHTML = CodigoHTML & "<td>" & Estado & "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td>"
                    Case 2 ' Presentación
                        CodigoHTML = CodigoHTML & "<td></td><td>" & Estado & "</td><td></td><td></td><td></td><td></td><td></td><td></td>"
                    Case 3 ' Resolución
                        CodigoHTML = CodigoHTML & "<td></td><td></td><td>" & Estado & "</td><td></td><td></td><td></td><td></td><td></td>"
                    Case 4 ' Notificación
                        CodigoHTML = CodigoHTML & "<td></td><td></td><td></td><td>" & Estado & "</td><td></td><td></td><td></td><td></td>"
                    Case 5 ' Oposición
                        CodigoHTML = CodigoHTML & "<td></td><td></td><td></td><td></td><td>" & Estado & "</td><td></td><td></td><td></td>"
                    Case 6 ' Tasación
                        CodigoHTML = CodigoHTML & "<td></td><td></td><td></td><td></td><td></td><td>" & Estado & "</td><td></td><td></td>"
                    Case 7 ' Bases
                        CodigoHTML = CodigoHTML & "<td></td><td></td><td></td><td></td><td></td><td></td><td>" & Estado & "</td><td></td>"
                    Case 8 ' Remate
                        CodigoHTML = CodigoHTML & "<td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" & Estado & "</td>"
                End Select
            End While
            dtr.Close()
        Catch

        End Try
        ListarSituacionPorEtapasDelProceso = CodigoHTML
    End Function

    Public Function ListarEstadoPorEtapasDelProceso(ByVal TipoProcesoName As String, ByVal EtapasName As String, ByVal CarpetaJudicialCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String = ""
        Dim EstadoCerrada As String = ""
        Dim EstadosEnCurso As String = ""
        Dim i As Integer = 0

        strUpdate = "Select Tareas.EstadoTareasCodigo As Estado "
        strUpdate = strUpdate & "FROM Etapas INNER JOIN (Acciones INNER JOIN Tareas ON Acciones.AccionesCodigo = Tareas.AccionesCodigo) ON Etapas.EtapasName = Acciones.EtapasName "
        strUpdate = strUpdate & "WHERE(((Etapas.TipoProcesoName) = '" & TipoProcesoName & "') And ((Acciones.EtapasName) = '" & EtapasName & "') And ((Tareas.PGGCodigo) = '" & CarpetaJudicialCodigo & "')) "
        strUpdate = strUpdate & "ORDER BY Acciones.EtapasSecuencia, Acciones.AccionesSecuencia;"


        ListarEstadoPorEtapasDelProceso = ""

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                If (CStr(dtr("Estado").ToString) <> "Cerrada") Then
                    i = i + 1
                    If i = 1 Then
                        EstadosEnCurso = dtr("Estado").ToString
                    Else
                        EstadosEnCurso = EstadosEnCurso & ", <br / >" & dtr("Estado").ToString
                    End If
                Else
                    EstadoCerrada = ""
                End If
            End While
            dtr.Close()
        Catch

        End Try

        If Len(EstadosEnCurso) > 0 Then
            ListarEstadoPorEtapasDelProceso = EstadosEnCurso
        Else
            If Len(EstadoCerrada) > 0 Then
                ListarEstadoPorEtapasDelProceso = EstadoCerrada
            Else
                ListarEstadoPorEtapasDelProceso = ""
            End If
        End If

    End Function
    Public Function DesviacionDelProceso(ByVal CarpetaJudicialCodigo As String, Optional ByRef AccionesCodigo As String = "02.01.01") As Integer

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim strUpdate As String
        Dim sSQL As String = ""
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Acciones As New Acciones
        Dim Usuarios As New Usuarios
        Dim Dias As Double
        Dim FechaAdjudicacion As Date = CDate(CarpetaJudicial.LeerFechaAdjudicacion(CarpetaJudicialCodigo))
        Dim FechaInicioTareas As Date
        Dim FechaTerminoTareas As Date

        Dim i As Integer = 0
        Dim j As Integer = 0

        Dim Codigos(299) As String
        Dim FechasTermino(299) As Date
        Dim Seguir As Boolean = True
        Dim TipoProcesoSecuencia As Long = 0
        Dim AccionesName As String = ""
        Dim EtapasSecuencia As Long = 0

        'Determinar la acción no concluida de la carpeta judicial


        sSQL = "SELECT TipoProceso.TipoProcesoSecuencia As Tipo, Tareas.AccionesCodigo As Codigo, Acciones.AccionesName As Name, Acciones.EtapasSecuencia As Etapa "
        sSQL = sSQL & "FROM ((CarpetaJudicial INNER JOIN Tareas ON CarpetaJudicial.CarpetaJudicialCodigo = Tareas.PGGCodigo) INNER JOIN TipoProceso ON CarpetaJudicial.TipoProcesoName = TipoProceso.TipoProcesoName) INNER JOIN Acciones ON Tareas.AccionesCodigo = Acciones.AccionesCodigo "
        sSQL = sSQL & "WHERE (((CarpetaJudicial.CarpetaJudicialCodigo)='" & CarpetaJudicialCodigo & "') AND ((Tareas.EstadoTareasCodigo)<> 'Cerrada'))"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TipoProcesoSecuencia = CLng(dtr("Tipo").ToString)
                AccionesCodigo = CStr(dtr("Codigo").ToString)
                AccionesName = CStr(dtr("Name").ToString)
                EtapasSecuencia = CLng(dtr("Etapa").ToString)
            End While
            dtr.Close()
        Catch

        End Try

        strUpdate = "SELECT Acciones.AccionesId as Id, Acciones.AccionesCodigo as Codigo, Acciones.AccionesName As Name, Acciones.AccionesDuration As Duration, Acciones.EtapasName As Etapa, Acciones.RolName as RolName, Acciones.AccionesIsFlujoAlternativo as IsAlternativo "
        strUpdate = strUpdate & "FROM Acciones "
        strUpdate = strUpdate & "WHERE TipoProcesoSecuencia = " & TipoProcesoSecuencia & " "
        strUpdate = strUpdate & "ORDER BY Acciones.TipoProcesoSecuencia, Acciones.EtapasSecuencia, Acciones.AccionesSecuencia"

        DesviacionDelProceso = 0


        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                If Seguir = True Then
                    i = i + 1

                    If i = 1 Then
                        Dias = CDbl(dtr("Duration").ToString)
                        FechaInicioTareas = FechaAdjudicacion
                        FechaTerminoTareas = DateAdd(DateInterval.Day, Dias, FechaInicioTareas)
                        Codigos(i) = dtr("Codigo").ToString
                        FechasTermino(i) = FechaTerminoTareas
                    Else
                        Dias = CDbl(dtr("Duration").ToString)

                        ' Aqui invocar una rutina que seleccione la mayor fecha de termino entre las tareas predecesoras y la coloque como fecha de inicio de la tarea
                        'FechaInicioTareas = FechaTerminoTareas
                        FechaInicioTareas = Acciones.FechaTerminoMasTardiaTareasPredecesoras(dtr("Codigo").ToString, Codigos, FechasTermino, i, FechaAdjudicacion)
                        FechaTerminoTareas = DateAdd(DateInterval.Day, Dias, FechaInicioTareas)
                        Codigos(i) = dtr("Codigo").ToString
                        FechasTermino(i) = FechaTerminoTareas
                    End If
                    If dtr("Codigo").ToString = AccionesCodigo Then 'Llegamos a la acción de la tarea actual, no debemos seguir
                        Seguir = False
                        DesviacionDelProceso = DateDiff(DateInterval.Day, Now, FechaTerminoTareas)
                    End If
                End If







            End While
            dtr.Close()
        Catch

        End Try

    End Function
    Public Function ListarItemsGanttPorProceso(ByVal TipoProcesoSecuencia As Long, ByVal CarpetaJudicialCodigo As String, ByRef Chart1 As Chart) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim Acciones As New Acciones
        Dim Usuarios As New Usuarios
        Dim Dias As Double
        Dim FechaAdjudicacion As Date = CDate(CarpetaJudicial.LeerFechaAdjudicacion(CarpetaJudicialCodigo))
        Dim FechaInicioTareas As Date = FechaAdjudicacion
        Dim FechaTerminoTareas As Date
        Dim sFechaInicio As String = ""
        Dim sFechaTermino As String = ""
        Dim FechaInicioReal As Date
        Dim FechaTerminoReal As Date
        Dim i As Integer = 0 'Cuenta todos los registros
        Dim j As Integer = 0 'Cuenta las distintas etapas.
        Dim k As Integer = 0 'Cuenta las actividades dentro de una misma etapa
        Dim l As Integer = 0 'l=1 son las fechas programadas y l=2 son las fechas reales

        Dim Codigos(299) As String
        Dim FechasTermino(299) As Date
        Dim CodigosGantt(299) As Long
        Dim GanttId As Long = 0  'Obtiene el número de la tarea en la gantt = j + 10*k
        Dim GanttPId As Long = 0 'Se asigna el GanttId de la etapa.
        Dim GanttPIdTarea As Long = 0
        Dim CodigosPredecesores As String = ""
        Dim PorcentajeAvance As String = ""

        strUpdate = "SELECT Acciones.AccionesId as Id, Acciones.AccionesCodigo as Codigo, Acciones.AccionesName As Name, Acciones.AccionesDuration As Duration, Acciones.EtapasName As Etapa, Acciones.RolName as RolName, Acciones.AccionesIsFlujoAlternativo as IsAlternativo "
        strUpdate = strUpdate & "FROM Acciones "
        strUpdate = strUpdate & "WHERE TipoProcesoSecuencia = " & TipoProcesoSecuencia & " "
        strUpdate = strUpdate & "ORDER BY Acciones.TipoProcesoSecuencia, Acciones.EtapasSecuencia, Acciones.AccionesSecuencia"

        ListarItemsGanttPorProceso = ""

        '
        ' Creates a task (one row) in gantt object
        ' @class TaskItem 
        ' @namespace JSGantt
        ' @constructor
        ' @for JSGantt

        ' @param pID {Number} Task unique numeric ID
        ' @param pName {String} Task Name
        ' @param pStart {Date} Task start date/time (not required for pGroup=1 )
        ' @param pEnd {Date} Task end date/time, you can set the end time to 12:00 to indicate half-day (not required for pGroup=1 )
        ' @param pColor {String} Task bar RGB value
        ' @param pLink {String} Task URL, clicking on the task will redirect to this url. Leave empty if you do not with the Task also serve as a link
        ' @param pMile {Boolean} Determines whether task is a milestone (1=Yes,0=No)
        ' @param pRes {String} Resource to perform the task
        '                                                                               @param pComp {Number} Percent complete (Number between 0 and 100)
        '                                                                               @param pGroup {Boolean}
        '                                                                               @param pParent {Number} ID of the parent task
        '                                                                               @param pOpen {Boolean}
        '                                                                               @param pDepend {String} Comma seperated list of IDs this task depends on
        '                                                                               @param pCaption {String} Caption to be used instead of default caption (Resource). 
        '                                                                               note : you should use setCaption("Caption") in order to display the caption
        '                                                                               @return void
        '/

        'Vamos a poner una tarea raíz con el nombre del deudor

        j = 0   'Número de la etapa
        k = 0   'Número de la tarea
        l = 0   '1:Fechas Planeadas y 2:Fechas Reales
        GanttId = 1 + j * 10 + 100 * k + l * 1000 'Id en la Gantt
        CodigoHTML = CodigoHTML & "g.AddTaskItem(new JSGantt.TaskItem(" & GanttId & ", '" & CarpetaJudicial.LeerDeudorParaGanttByCarpetaJudicialCodigo(CarpetaJudicialCodigo) & "', '', '', 'ff0000', 'http://help.com', 0, '', 0, 1, 0, 1));"  'Agregamos la tarea a la gantt
        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                i = i + 1  ' Cuenta todos los registros

                If NombreEtapa <> dtr("Etapa").ToString Then
                    'Cambio de Etapa, implica agregar un registro padre a la carta gantt del proceso judicial.
                    NombreEtapa = dtr("Etapa").ToString 'Primera Etapa
                    j = j + 1   'Número de la etapa
                    k = 0       'Número de la tarea
                    l = 0       '1:Fechas Planeadas y 2:Fechas Reales
                    GanttId = 1 + j * 10 + 100 * k + l * 1000 'Id en la Gantt
                    CodigosGantt(i) = GanttId  'Guardamos el Id en la tabla de tareas
                    GanttPId = GanttId 'Guardamos el GanttId como ParentId para las tareas de la etapa.
                    CodigoHTML = CodigoHTML & "g.AddTaskItem(new JSGantt.TaskItem(" & GanttId & ", '" & UCase(NombreEtapa) & "', '', '', 'ff0000', 'http://help.com', 0, '', 0, 1, 1, 1));"  'Agregamos la etapa a la gantt
                    Codigos(i) = ""
                    FechasTermino(i) = FechaAdjudicacion
                    i = i + 1
                End If
                If CBool(dtr("IsAlternativo").ToString) = False Then 'Solo se planifican las actividades del flujo principal
                    ' Aqui invocar una rutina que seleccione la mayor fecha de termino entre las tareas predecesoras y la coloque como fecha de inicio de la tarea
                    'FechaInicioTareas = FechaTerminoTareas
                    'Quiero que cada tarea quede como grupo y que se abra en dos items, uno para el rango de fechas planeado y el otro para el rango real.
                    'Tarea de Grupo con el nombre de la Tarea
                    k = k + 1
                    If i = 2 Then 'Es la primera tarea y que corresponde a un hito, no tiene predecesoras pero es la tarea inicial
                        l = 0
                        GanttId = 1 + j * 10 + 100 * k + l * 1000 'Id en la Gantt
                        Dias = CDbl(dtr("Duration").ToString)
                        FechaTerminoTareas = DateAdd(DateInterval.Day, Dias, FechaInicioTareas)
                        CodigosGantt(i) = GanttId  'Guardamos el Id en la tabla de tareas
                        sFechaInicio = CType(FechaInicioTareas, Date).Month & "/" & CType(FechaInicioTareas, Date).Day & "/" & CType(FechaInicioTareas, Date).Year
                        sFechaTermino = CType(FechaTerminoTareas, Date).Month & "/" & CType(FechaTerminoTareas, Date).Day & "/" & CType(FechaTerminoTareas, Date).Year
                        PorcentajeAvance = "100"
                        ' Tarea inicial, marcada como hito
                        CodigoHTML = CodigoHTML & "g.AddTaskItem(new JSGantt.TaskItem(" & GanttId & ", '" & Mid(dtr("Name").ToString, 1, 40) & "', '" & sFechaInicio & "', '" & sFechaTermino & "', '00ffff', 'http://help.com', 1, '" & dtr("RolName").ToString & "', " & PorcentajeAvance & ", 0, " & GanttPId & ", 0,""" & CodigosPredecesores & """));"  'Agregamos la tarea a la gantt
                        Codigos(i) = dtr("Codigo").ToString
                        FechasTermino(i) = FechaTerminoTareas
                    Else
                        Select Case Acciones.EstadoAccion(dtr("Codigo").ToString, CarpetaJudicialCodigo)
                            Case "Cerrada" 'Se agrega la tarea como grupo y se abre en dos, una para reflejar el plan y la otra para el real.
                                'Tarea
                                l = 0
                                PorcentajeAvance = "100"
                                GanttPIdTarea = 1 + j * 10 + 100 * k + l * 1000 'Id en la Gantt
                                CodigoHTML = CodigoHTML & "g.AddTaskItem(new JSGantt.TaskItem(" & GanttPIdTarea & ", '" & Mid(dtr("Name").ToString, 1, 40) & "', '', '', 'ff0000', 'http://help.com', 0, '', " & PorcentajeAvance & ", 1, " & GanttPId & ", 1));"  'Agregamos la tarea a la gantt
                                'Plan
                                l = 1
                                GanttId = 1 + j * 10 + 100 * k + l * 1000 'Id en la Gantt
                                If i > 2 Then
                                    FechaInicioTareas = Acciones.FechaTerminoMasTardiaTareasPredecesoras(dtr("Codigo").ToString, Codigos, FechasTermino, i, FechaAdjudicacion)
                                End If
                                Dias = CDbl(dtr("Duration").ToString)
                                FechaTerminoTareas = DateAdd(DateInterval.Day, Dias, FechaInicioTareas)

                                sFechaInicio = CType(FechaInicioTareas, Date).Month & "/" & CType(FechaInicioTareas, Date).Day & "/" & CType(FechaInicioTareas, Date).Year
                                sFechaTermino = CType(FechaTerminoTareas, Date).Month & "/" & CType(FechaTerminoTareas, Date).Day & "/" & CType(FechaTerminoTareas, Date).Year
                                'CodigosPredecesores = Acciones.TareasPredecesorasParaGantt(dtr("Codigo").ToString, Codigos, CodigosGantt, i, FechaAdjudicacion)
                                CodigoHTML = CodigoHTML & "g.AddTaskItem(new JSGantt.TaskItem(" & GanttId & ", '" & "Plan" & "', '" & sFechaInicio & "', '" & sFechaTermino & "', '00ffff', 'http://help.com', 0, '" & dtr("RolName").ToString & "', " & PorcentajeAvance & ", 0, " & GanttPIdTarea & ", 0));"  'Agregamos la tarea a la gantt
                                ' Ruta según línea base
                                'CodigosGantt(i) = GanttId  'Guardamos el Id en la tabla de tareas
                                'Codigos(i) = dtr("Codigo").ToString
                                'FechasTermino(i) = FechaTerminoTareas
                                'Ejecución
                                If Acciones.FechaInicioTerminoReal(dtr("Codigo").ToString, CarpetaJudicialCodigo, FechaInicioReal, FechaTerminoReal, Dias) = True Then
                                    l = 2
                                    GanttId = 1 + j * 10 + 100 * k + l * 1000 'Id en la Gantt
                                    sFechaInicio = CType(FechaInicioReal, Date).Month & "/" & CType(FechaInicioReal, Date).Day & "/" & CType(FechaInicioReal, Date).Year
                                    sFechaTermino = CType(FechaTerminoReal, Date).Month & "/" & CType(FechaTerminoReal, Date).Day & "/" & CType(FechaTerminoReal, Date).Year
                                    CodigosPredecesores = Acciones.TareasPredecesorasParaGantt(dtr("Codigo").ToString, Codigos, CodigosGantt, i, FechaAdjudicacion)
                                    CodigoHTML = CodigoHTML & "g.AddTaskItem(new JSGantt.TaskItem(" & GanttId & ", '" & "Real" & "', '" & sFechaInicio & "', '" & sFechaTermino & "', '0000ff', 'http://localhost:2097/SESite/GestionTareas.aspx?Id=167&PaginaWebName=Ficha de Tareas&MenuOptionsId=422', 0, '" & dtr("RolName").ToString & "', " & PorcentajeAvance & ", 0, " & GanttPIdTarea & ", 0,""" & CodigosPredecesores & """));"  'Agregamos la tarea a la gantt
                                    'Ruta en base al termino real de las tareas
                                    CodigosGantt(i) = GanttId  'Guardamos el Id en la tabla de tareas
                                    Codigos(i) = dtr("Codigo").ToString
                                    FechasTermino(i) = FechaTerminoReal
                                End If
                            Case "No Iniciada"  'Solo se agrega la tarea planeada 
                                l = 0
                                GanttId = 1 + j * 10 + 100 * k + l * 1000 'Id en la Gantt
                                If i > 2 Then
                                    FechaInicioTareas = Acciones.FechaTerminoMasTardiaTareasPredecesoras(dtr("Codigo").ToString, Codigos, FechasTermino, i, FechaAdjudicacion)
                                End If
                                Dias = CDbl(dtr("Duration").ToString)
                                FechaTerminoTareas = DateAdd(DateInterval.Day, Dias, FechaInicioTareas)
                                sFechaInicio = CType(FechaInicioTareas, Date).Month & "/" & CType(FechaInicioTareas, Date).Day & "/" & CType(FechaInicioTareas, Date).Year
                                sFechaTermino = CType(FechaTerminoTareas, Date).Month & "/" & CType(FechaTerminoTareas, Date).Day & "/" & CType(FechaTerminoTareas, Date).Year
                                CodigosPredecesores = Acciones.TareasPredecesorasParaGantt(dtr("Codigo").ToString, Codigos, CodigosGantt, i, FechaAdjudicacion)
                                PorcentajeAvance = "0"
                                ' Se pone como tarea planeada.
                                CodigoHTML = CodigoHTML & "g.AddTaskItem(new JSGantt.TaskItem(" & GanttId & ", '" & Mid(dtr("Name").ToString, 1, 40) & "', '" & sFechaInicio & "', '" & sFechaTermino & "', '00ffff', 'http://help.com', 0, '" & dtr("RolName").ToString & "', " & PorcentajeAvance & ", 0, " & GanttPId & ", 0,""" & CodigosPredecesores & """));"  'Agregamos la tarea a la gantt
                                CodigosGantt(i) = GanttId  'Guardamos el Id en la tabla de tareas
                                Codigos(i) = dtr("Codigo").ToString
                                FechasTermino(i) = FechaTerminoTareas
                            Case Else 'Se agrega la tarea como grupo y se abre en dos, una para reflejar el plan y la otra para el real y en este caso se pone como fecha de término, la del día de hoy.
                                'Tarea
                                l = 0
                                PorcentajeAvance = "0"
                                GanttPIdTarea = 1 + j * 10 + 100 * k + l * 1000 'Id en la Gantt
                                CodigoHTML = CodigoHTML & "g.AddTaskItem(new JSGantt.TaskItem(" & GanttPIdTarea & ", '" & Mid(dtr("Name").ToString, 1, 40) & "', '', '', 'ff0000', 'http://help.com', 0, '', " & PorcentajeAvance & ", 1, " & GanttPId & ", 1));"  'Agregamos la tarea a la gantt
                                'Plan
                                l = 1
                                GanttId = 1 + j * 10 + 100 * k + l * 1000 'Id en la Gantt
                                If i > 2 Then
                                    FechaInicioTareas = Acciones.FechaTerminoMasTardiaTareasPredecesoras(dtr("Codigo").ToString, Codigos, FechasTermino, i, FechaAdjudicacion)
                                End If
                                Dias = CDbl(dtr("Duration").ToString)
                                FechaTerminoTareas = DateAdd(DateInterval.Day, Dias, FechaInicioTareas)
                                sFechaInicio = CType(FechaInicioTareas, Date).Month & "/" & CType(FechaInicioTareas, Date).Day & "/" & CType(FechaInicioTareas, Date).Year
                                sFechaTermino = CType(FechaTerminoTareas, Date).Month & "/" & CType(FechaTerminoTareas, Date).Day & "/" & CType(FechaTerminoTareas, Date).Year
                                'CodigosPredecesores = Acciones.TareasPredecesorasParaGantt(dtr("Codigo").ToString, Codigos, CodigosGantt, i, FechaAdjudicacion)
                                CodigoHTML = CodigoHTML & "g.AddTaskItem(new JSGantt.TaskItem(" & GanttId & ", '" & "Plan" & "', '" & sFechaInicio & "', '" & sFechaTermino & "', '00ffff', 'http://help.com', 0, '" & dtr("RolName").ToString & "', " & PorcentajeAvance & ", 0, " & GanttPIdTarea & ", 0));"  'Agregamos la tarea a la gantt
                                ' Ruta según línea base
                                'CodigosGantt(i) = GanttId  'Guardamos el Id en la tabla de tareas
                                'Codigos(i) = dtr("Codigo").ToString
                                'FechasTermino(i) = FechaTerminoTareas
                                'Ejecución
                                If Acciones.FechaInicioTerminoReal(dtr("Codigo").ToString, CarpetaJudicialCodigo, FechaInicioReal, FechaTerminoReal, Dias) = True Then
                                    l = 2
                                    GanttId = 1 + j * 10 + 100 * k + l * 1000 'Id en la Gantt
                                    sFechaInicio = CType(FechaInicioReal, Date).Month & "/" & CType(FechaInicioReal, Date).Day & "/" & CType(FechaInicioReal, Date).Year
                                    sFechaTermino = CType(Now(), Date).Month & "/" & CType(Now(), Date).Day & "/" & CType(Now(), Date).Year
                                    CodigosPredecesores = Acciones.TareasPredecesorasParaGantt(dtr("Codigo").ToString, Codigos, CodigosGantt, i, FechaAdjudicacion)
                                    CodigoHTML = CodigoHTML & "g.AddTaskItem(new JSGantt.TaskItem(" & GanttId & ", '" & "Real" & "', '" & sFechaInicio & "', '" & sFechaTermino & "', '0000ff', 'http://help.com', 0, '" & dtr("RolName").ToString & "', " & PorcentajeAvance & ", 0, " & GanttPIdTarea & ", 0,""" & CodigosPredecesores & """));"  'Agregamos la tarea a la gantt
                                    'Ruta en base al termino real de las tareas
                                    CodigosGantt(i) = GanttId  'Guardamos el Id en la tabla de tareas
                                    Codigos(i) = dtr("Codigo").ToString
                                    FechasTermino(i) = CDate(Now())
                                End If
                        End Select


                    End If


                End If

            End While
            dtr.Close()
        Catch

        End Try
        ListarItemsGanttPorProceso = CodigoHTML
        ' Populate series data


        Array.Sort(FechasTermino)
        Dim Acum As Integer = 0
        Dim Fecha As DateTime = CDate(FechasTermino(299 - i))
        Dim pointIndex As Integer
        'For pointIndex = 0 To 20
        For pointIndex = 299 - i To 299
            If Fecha = CDate(FechasTermino(pointIndex)) Then
                Acum = Acum + 1
            Else
                Chart1.Series("Series1").Points.AddXY(Fecha, Acum)
                Acum = 1
                Fecha = CDate(FechasTermino(pointIndex))
            End If
        Next



        'Dim random As New Random()
        'Dim Acum As Integer = 0
        'Dim [date] As DateTime = DateTime.Now.Date
        'Dim pointIndex As Integer
        'For pointIndex = 0 To 20
        'Acum = Acum + Random.Next(5, 95)
        'Chart1.Series("Series1").Points.AddXY([Date], Acum)
        'Chart1.Series("Series2").Points.AddXY([Date], Acum - 100)
        'Chart1.Series("Series3").Points.AddXY([Date], Acum + 100)
        '[Date] = [Date].AddDays(Random.Next(1, 5))
        'Next

    End Function

    Public Function EstadoAccion(ByVal AccionesCodigo As String, ByVal CarpetaJudicialCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim i = 0
        Dim CodigoAccion As String = ""

        strUpdate = "SELECT Top 1 Tareas.EstadoTareasCodigo As Estado "
        strUpdate = strUpdate & "FROM Tareas "
        strUpdate = strUpdate & "WHERE (((Tareas.PGGCodigo)='" & CarpetaJudicialCodigo & "') AND ((Tareas.AccionesCodigo)='" & AccionesCodigo & "')) "
        strUpdate = strUpdate & "ORDER BY Tareas.TareasId Desc "

        EstadoAccion = "No Iniciada"

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                EstadoAccion = dtr("Estado").ToString()
            End While
            dtr.Close()
        Catch

        End Try

    End Function
    Public Function DescribirUnaAccion(ByRef AccionesCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim Acciones As New Acciones

        strUpdate = "SELECT Acciones.AccionesId as Id, Acciones.RolName as RolName, Acciones.AccionesName As Name, Acciones.AccionesDescription As Descripcion, Acciones.EtapasName As Etapa "
        strUpdate = strUpdate & "FROM Acciones "
        strUpdate = strUpdate & "WHERE Acciones.AccionesCodigo='" & AccionesCodigo & "'"

        DescribirUnaAccion = ""

        CodigoHTML = "<table class=""popup_tabla_de_datos"">"

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                If NombreEtapa <> dtr("Etapa").ToString Then
                    NombreEtapa = dtr("Etapa").ToString
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td colspan=""2""><h2>ETAPA: " & UCase(NombreEtapa) & "</h2></td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td colspan=""2""><h2>ACCION: " & AccionesCodigo & ": " & UCase(dtr("Name").ToString) & "</h2></td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td width=""100""><h2>Responsable</h2></td>"
                CodigoHTML = CodigoHTML & "<td width=""550""><h2>" & dtr("RolName").ToString & "</h2></td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td width=""100""><h3>Objetivo</h3></td>"
                CodigoHTML = CodigoHTML & "<td width=""550"">" & dtr("Descripcion").ToString & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & Acciones.ListarObservacionesPorAccion(AccionesCodigo)
                CodigoHTML = CodigoHTML & Acciones.ListarPrecondicionesPorAccion(AccionesCodigo)
                CodigoHTML = CodigoHTML & Acciones.ListarActividadesPorAccion(AccionesCodigo)
                CodigoHTML = CodigoHTML & Acciones.ListarPostcondicionesPorAccion(AccionesCodigo)
                CodigoHTML = CodigoHTML & Acciones.ListarDatosPorAccion(AccionesCodigo)
            End While
            dtr.Close()
        Catch

        End Try
        CodigoHTML = CodigoHTML & "</table>"
        DescribirUnaAccion = CodigoHTML
    End Function
    Public Function CalcularNextAccionesSecuencia(ByVal EtapasId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Max(Acciones.AccionesSecuencia) as Maximo "
        sSQL = sSQL & "FROM Acciones "
        sSQL = sSQL & "WHERE EtapasId = " & EtapasId

        CalcularNextAccionesSecuencia = 1

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                CalcularNextAccionesSecuencia = CLng(dtr("Maximo").ToString) + 1
            End While
            dtr.Close()
        Catch
            CalcularNextAccionesSecuencia = 1
        End Try
    End Function
    Public Function ListarAccionesPorEtapas(ByVal EtapasId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim Etapas As New Etapas
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Dim i As Integer = 0
        Dim Acciones As New Acciones
        'Dim TituloMisAcciones As String = Etapas.TituloAccionesPorEtapas(EtapasId)

        strUpdate = "SELECT Acciones.AccionesId As Id, Acciones.AccionesCodigo as Codigo, Acciones.AccionesName As Name, Acciones.AccionesDescription As Description, Acciones.RolName As Rol, Acciones.TipoProcesoSecuencia As TipoProcesoId "
        strUpdate = strUpdate & "FROM Acciones "
        strUpdate = strUpdate & "WHERE Acciones.EtapasId = " & EtapasId & " "
        strUpdate = strUpdate & "ORDER BY Acciones.AccionesSecuencia"

        ListarAccionesPorEtapas = ""

        'CodigoHTML = TituloMisAcciones
        'Dim linkAgregar As String = "<input id=""AgregarUnaAccion"" type=""button"" value=""Agregar una acci&oacute;n"" class=""boxceleste"" title=""De un click para agregar una nueva acci&oacute;n a la etapa"" onclick=""verModalAccionEtapas('FichaAcciones.aspx?AccionesId=0&EtapasId=" & EtapasId & "&PaginaWebName=Ficha de Acciones')"" />"
        'CodigoHTML = CodigoHTML & "<p>" & linkAgregar & "</p>"
        CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
        CodigoHTML = CodigoHTML & "<tr>"
        CodigoHTML = CodigoHTML & "<th width=""200"" align=""left"">Acci&oacute;n</th>"
        CodigoHTML = CodigoHTML & "<th width=""50"" align=""left"">Rol</th>"
        CodigoHTML = CodigoHTML & "<th width=""350"">Descripci&oacute;n</th>"
        CodigoHTML = CodigoHTML & "<th width=""25"">Editar</th>"
        CodigoHTML = CodigoHTML & "</tr>"

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td width=""200"" align=""left"">" & dtr("Name").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td width=""50"">" & dtr("Rol").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td width=""350"">" & dtr("Description").ToString & "</td>"
                'CodigoHTML = CodigoHTML & "<td width=""25""><img src=""img/editar.png"" alt=""Editar una acci&oacute;n de la etapa"" hspace=""5"" border=""0"" align=""left"" title=""Editar una acción de la etapa"" onclick=""verModalAccionEtapas('FichaAcciones.aspx?AccionesId=" & dtr("Id").ToString & "&EtapasId=" & EtapasId & "&TipoProcesoId=" & dtr("TipoProcesoId").ToString & "&PaginaWebName=Ficha de Acciones')"" /></td>"
                CodigoHTML = CodigoHTML & "<td width=""25"">" & "<img src=""img/editar.png"" alt=""Editar una acci&oacute;n de la etapa"" hspace=""5"" border=""0"" align=""left"" title=""una acci&oacute;n de la etapa"" onclick=""editbutton(" & dtr("Id").ToString & ");"" />"
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch

        End Try
        CodigoHTML = CodigoHTML & "</table>"
        ListarAccionesPorEtapas = CodigoHTML
    End Function
End Class
