'------------------------------------------------------------
' Código generado por ZRISMART SF el 22-08-2011 12:24:19
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Programas
    Public Function LeerProgramas(ByVal ProgramasId As Long, ByRef ProgramasCodigo As String, ByRef ProgramasName As String, ByRef ProgramasAno As String, ByRef GerenciasCodigo As String, ByRef ProgramasDescription As String, ByRef ProgramasAreaResponsableName As String, ByRef ProgramasAreaEjecutoraName As String, ByRef ZonaGeograficaName As String, ByRef ProgramasPeriodoInicio As String, ByRef ProgramasPeriodoTermino As String, ByRef ProgramasElaboradoPor As String, ByRef ProgramasRevisadoPor As String, ByRef ProgramasAprobadoPor As String, ByRef ProgramasCoordinadoPor As String, ByRef ProgramasPresupuestoTotal As Double, ByRef ProgramasPresupuestoAnual As Double, ByRef ProgramasIndicadorLogro As String, ByRef ProgramasRespaldoCumplimiento As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasCodigo, ProgramasName, ProgramasAno, GerenciasCodigo, ProgramasDescription, ProgramasAreaResponsableName, ProgramasAreaEjecutoraName, ZonaGeograficaName, ProgramasPeriodoInicio, ProgramasPeriodoTermino, ProgramasElaboradoPor, ProgramasRevisadoPor, ProgramasAprobadoPor, ProgramasCoordinadoPor, ProgramasPresupuestoTotal, ProgramasPresupuestoAnual, ProgramasIndicadorLogro, ProgramasRespaldoCumplimiento "
        sSQL = sSQL & "FROM (Programas) "
        sSQL = sSQL & "WHERE (Programas.ProgramasId = " & ProgramasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProgramasCodigo = CStr(dtr("ProgramasCodigo").ToString)
                ProgramasName = CStr(dtr("ProgramasName").ToString)
                ProgramasAno = CStr(dtr("ProgramasAno").ToString)
                GerenciasCodigo = CStr(dtr("GerenciasCodigo").ToString)
                ProgramasDescription = CStr(dtr("ProgramasDescription").ToString)
                ProgramasAreaResponsableName = CStr(dtr("ProgramasAreaResponsableName").ToString)
                ProgramasAreaEjecutoraName = CStr(dtr("ProgramasAreaEjecutoraName").ToString)
                ZonaGeograficaName = CStr(dtr("ZonaGeograficaName").ToString)
                ProgramasPeriodoInicio = CStr(dtr("ProgramasPeriodoInicio").ToString)
                ProgramasPeriodoTermino = CStr(dtr("ProgramasPeriodoTermino").ToString)
                ProgramasElaboradoPor = CStr(dtr("ProgramasElaboradoPor").ToString)
                ProgramasRevisadoPor = CStr(dtr("ProgramasRevisadoPor").ToString)
                ProgramasAprobadoPor = CStr(dtr("ProgramasAprobadoPor").ToString)
                ProgramasCoordinadoPor = CStr(dtr("ProgramasCoordinadoPor").ToString)
                If Len(dtr("ProgramasPresupuestoTotal").ToString) = 0 Then
                    ProgramasPresupuestoTotal = 0
                Else
                    ProgramasPresupuestoTotal = CDbl(dtr("ProgramasPresupuestoTotal").ToString)
                End If
                If Len(dtr("ProgramasPresupuestoAnual").ToString) = 0 Then
                    ProgramasPresupuestoAnual = 0
                Else
                    ProgramasPresupuestoAnual = CDbl(dtr("ProgramasPresupuestoAnual").ToString)
                End If
                ProgramasIndicadorLogro = CStr(dtr("ProgramasIndicadorLogro").ToString)
                ProgramasRespaldoCumplimiento = CStr(dtr("ProgramasRespaldoCumplimiento").ToString)
            End While
            LeerProgramas = True
            dtr.Close()
        Catch
            LeerProgramas = False
        End Try
    End Function
    Public Function LeerProgramasByName(ByRef ProgramasId As Long, ByVal ProgramasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasId "
        sSQL = sSQL & "FROM (Programas) "
        sSQL = sSQL & "WHERE (Programas.ProgramasCodigo = '" & ProgramasCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProgramasId = CLng(dtr("ProgramasId").ToString)
            End While
            LeerProgramasByName = True
            dtr.Close()
        Catch
            LeerProgramasByName = False
        End Try
    End Function
    Public Function LeerProgramasCodigoById(ByVal ProgramasId As Long, ByRef ProgramasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasCodigo "
        sSQL = sSQL & "FROM (Programas) "
        sSQL = sSQL & "WHERE (Programas.ProgramasId = " & ProgramasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProgramasCodigo = CStr(dtr("ProgramasCodigo").ToString)
            End While
            LeerProgramasCodigoById = True
            dtr.Close()
        Catch
            LeerProgramasCodigoById = False
        End Try
    End Function
    Public Function LeerProgramasDescriptionByName(ByVal ProgramasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasName "
        sSQL = sSQL & "FROM (Programas) "
        sSQL = sSQL & "WHERE (Programas.ProgramasCodigo = '" & ProgramasCodigo & "') "
        LeerProgramasDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerProgramasDescriptionByName = CStr(dtr("ProgramasName").ToString)
            End While
            dtr.Close()
        Catch
            LeerProgramasDescriptionByName = ""
        End Try
    End Function
    Public Function ProgramasUpdate(ByVal ProgramasId As Long, ByRef ProgramasCodigo As String, ByRef ProgramasName As String, ByRef ProgramasAno As String, ByRef GerenciasCodigo As String, ByRef ProgramasDescription As String, ByRef ProgramasAreaResponsableName As String, ByRef ProgramasAreaEjecutoraName As String, ByRef ZonaGeograficaName As String, ByRef ProgramasPeriodoInicio As String, ByRef ProgramasPeriodoTermino As String, ByRef ProgramasElaboradoPor As String, ByRef ProgramasRevisadoPor As String, ByRef ProgramasAprobadoPor As String, ByRef ProgramasCoordinadoPor As String, ByRef ProgramasPresupuestoTotal As Double, ByRef ProgramasPresupuestoAnual As Double, ByRef ProgramasIndicadorLogro As String, ByRef ProgramasRespaldoCumplimiento As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Programas SET "
        strUpdate = strUpdate & "Programas.ProgramasCodigo = '" & ProgramasCodigo & "', "
        strUpdate = strUpdate & "Programas.ProgramasName = '" & ProgramasName & "', "
        strUpdate = strUpdate & "Programas.ProgramasAno = '" & ProgramasAno & "', "
        strUpdate = strUpdate & "Programas.GerenciasCodigo = '" & GerenciasCodigo & "', "
        strUpdate = strUpdate & "Programas.ProgramasDescription = '" & ProgramasDescription & "', "
        strUpdate = strUpdate & "Programas.ProgramasAreaResponsableName = '" & ProgramasAreaResponsableName & "', "
        strUpdate = strUpdate & "Programas.ProgramasAreaEjecutoraName = '" & ProgramasAreaEjecutoraName & "', "
        strUpdate = strUpdate & "Programas.ZonaGeograficaName = '" & ZonaGeograficaName & "', "
        strUpdate = strUpdate & "Programas.ProgramasPeriodoInicio = '" & ProgramasPeriodoInicio & "', "
        strUpdate = strUpdate & "Programas.ProgramasPeriodoTermino = '" & ProgramasPeriodoTermino & "', "
        strUpdate = strUpdate & "Programas.ProgramasElaboradoPor = '" & ProgramasElaboradoPor & "', "
        strUpdate = strUpdate & "Programas.ProgramasRevisadoPor = '" & ProgramasRevisadoPor & "', "
        strUpdate = strUpdate & "Programas.ProgramasAprobadoPor = '" & ProgramasAprobadoPor & "', "
        strUpdate = strUpdate & "Programas.ProgramasCoordinadoPor = '" & ProgramasCoordinadoPor & "', "
        strUpdate = strUpdate & "Programas.ProgramasPresupuestoTotal = " & ProgramasPresupuestoTotal & ", "
        strUpdate = strUpdate & "Programas.ProgramasPresupuestoAnual = " & ProgramasPresupuestoAnual & ", "
        strUpdate = strUpdate & "Programas.ProgramasIndicadorLogro = '" & ProgramasIndicadorLogro & "', "
        strUpdate = strUpdate & "Programas.ProgramasRespaldoCumplimiento = '" & ProgramasRespaldoCumplimiento & "', "
        strUpdate = strUpdate & "Programas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Programas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Programas.ProgramasId = " & ProgramasId
        Try
            ProgramasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ProgramasCodigo, ProgramasId, "Programas", "")
        Catch
            ProgramasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ProgramasCodigo, ProgramasId, "Programas", "")
        End Try
    End Function
    Public Function ProgramasInsert(ByRef ProgramasId As Long, ByRef ProgramasCodigo As String, ByRef ProgramasName As String, ByRef ProgramasAno As String, ByRef GerenciasCodigo As String, ByRef ProgramasDescription As String, ByRef ProgramasAreaResponsableName As String, ByRef ProgramasAreaEjecutoraName As String, ByRef ZonaGeograficaName As String, ByRef ProgramasPeriodoInicio As String, ByRef ProgramasPeriodoTermino As String, ByRef ProgramasElaboradoPor As String, ByRef ProgramasRevisadoPor As String, ByRef ProgramasAprobadoPor As String, ByRef ProgramasCoordinadoPor As String, ByRef ProgramasPresupuestoTotal As Double, ByRef ProgramasPresupuestoAnual As Double, ByRef ProgramasIndicadorLogro As String, ByRef ProgramasRespaldoCumplimiento As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Programas As New Programas
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = ProgramasCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("ProgramasId", "ProgramasCodigo", "Programas", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("ProgramasId", "ProgramasCodigo", "Programas", MasterName, CLng(UserId), MasterId)
            End If
            ProgramasInsert = Programas.ProgramasUpdate(MasterId, CStr(ProgramasCodigo), CStr(ProgramasName), CStr(ProgramasAno), CStr(GerenciasCodigo), CStr(ProgramasDescription), CStr(ProgramasAreaResponsableName), CStr(ProgramasAreaEjecutoraName), CStr(ZonaGeograficaName), CStr(ProgramasPeriodoInicio), CStr(ProgramasPeriodoTermino), CStr(ProgramasElaboradoPor), CStr(ProgramasRevisadoPor), CStr(ProgramasAprobadoPor), CStr(ProgramasCoordinadoPor), CDbl(ProgramasPresupuestoTotal), CDbl(ProgramasPresupuestoAnual), CStr(ProgramasIndicadorLogro), CStr(ProgramasRespaldoCumplimiento), UserId)
        Catch
            ProgramasInsert = 0
        End Try
    End Function
    Public Function LeerTotalProgramasPorTablasRelacionadas(ByVal ProgramasCodigo As String, ByVal ProgramasId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en un Programa Global de Gestión
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Programas INNER JOIN ProgramasObjEspecifico ON Programas.ProgramasCodigo = ProgramasObjEspecifico.ProgramasCodigo "
        sSQL = sSQL & "WHERE (((Programas.ProgramasCodigo)= '" & ProgramasCodigo & "'))"
        LeerTotalProgramasPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalProgramasPorTablasRelacionadas = LeerTotalProgramasPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalProgramasPorTablasRelacionadas = 0
        End Try
        'Verifica si esta referenciada en una Actividad
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Programas INNER JOIN ProgramasCompTrimestral ON Programas.ProgramasCodigo = ProgramasCompTrimestral.ProgramasCodigo "
        sSQL = sSQL & "WHERE (((Programas.ProgramasCodigo)='" & ProgramasCodigo & "'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalProgramasPorTablasRelacionadas = LeerTotalProgramasPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalProgramasPorTablasRelacionadas = LeerTotalProgramasPorTablasRelacionadas + 0
        End Try
    End Function
    Public Function ProgramasDelete(ByVal ProgramasId As Long, ByVal ProgramasCodigo As String, ByVal UserId As Long, ByRef Mensaje As String, ByVal MenuOptionsId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Programas As New Programas
        Dim Rol As New Rol

        ' Verificar si la tarea posee evidencias o KPI registrados
        '---------------------------------------------------------
        Total = Programas.LeerTotalProgramasPorTablasRelacionadas(ProgramasCodigo, ProgramasId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados al Programa " & ProgramasCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie el Programa, antes de eliminarlo de la lista"
            ProgramasDelete = False
        Else
            Try
                ' Borra registro de la tabla de Programas
                '-------------------------------------
                strUpdate = "DELETE FROM Programas WHERE ProgramasId = " & ProgramasId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), MenuOptionsId, "Elimina el Programa: " & ProgramasCodigo, ProgramasId, "Programas", "")
                ProgramasDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), MenuOptionsId, "Intento fallido de eliminar el Programa: " & ProgramasCodigo, ProgramasId, "Programas", "")
                ProgramasDelete = False
            End Try
        End If
    End Function
    Public Function LeerCoordinadorByProgramasCodigo(ByVal ProgramasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasCoordinadoPor "
        sSQL = sSQL & "FROM (Programas) "
        sSQL = sSQL & "WHERE (Programas.ProgramasCodigo = '" & ProgramasCodigo & "') "
        LeerCoordinadorByProgramasCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerCoordinadorByProgramasCodigo = CStr(dtr("ProgramasCoordinadoPor").ToString)
            End While
            dtr.Close()
        Catch
            LeerCoordinadorByProgramasCodigo = ""
        End Try
    End Function
    Public Function LeerProgramasPeriodoInicio(ByVal ProgramasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasPeriodoInicio "
        sSQL = sSQL & "FROM (Programas) "
        sSQL = sSQL & "WHERE (Programas.ProgramasId = " & ProgramasId & ") "
        LeerProgramasPeriodoInicio = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerProgramasPeriodoInicio = CStr(dtr("ProgramasPeriodoInicio").ToString)
            End While
            dtr.Close()
        Catch
            LeerProgramasPeriodoInicio = ""
        End Try
    End Function
    Public Function LeerCabeceraPrograma(ByVal ProgramasCodigo As String, ByRef Objetivo As String, ByRef Coordinador As String, ByRef Iniciativa As String, ByRef Dimension As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Programas.ProgramasCodigo, Programas.ProgramasDescription as Objetivo, Programas.ProgramasCoordinadoPor as Coordinador, IniciativasEstrategicas.IniciativasEstrategicasName as Iniciativa, DimensionesEstrategicas.DimensionesEstrategicasName as Dimension "
        sSQL = sSQL & "FROM ((Programas INNER JOIN ProgramasIniciativas ON Programas.ProgramasId = ProgramasIniciativas.ProgramasId) INNER JOIN IniciativasEstrategicas ON ProgramasIniciativas.IniciativasEstrategicasId = IniciativasEstrategicas.IniciativasEstrategicasId) INNER JOIN DimensionesEstrategicas ON IniciativasEstrategicas.DimensionesEstrategicasCodigo = DimensionesEstrategicas.DimensionesEstrategicasCodigo "
        sSQL = sSQL & "WHERE (((Programas.ProgramasCodigo)='" & ProgramasCodigo & "'))"

        LeerCabeceraPrograma = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Objetivo = CStr(dtr("Objetivo").ToString)
                Coordinador = CStr(dtr("Coordinador").ToString)
                Iniciativa = CStr(dtr("Iniciativa").ToString)
                Dimension = CStr(dtr("Dimension").ToString)
                LeerCabeceraPrograma = True
            End While
            dtr.Close()
        Catch
            LeerCabeceraPrograma = False
        End Try
    End Function
    Public Function LoadProgramasPorStakeholders(ByRef rptProgramas As Repeater, ByVal StakeholdersId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT StakeholdersPorProgramas.StakeholdersId AS Id, Programas.ProgramasCodigo AS Codigo, Programas.ProgramasName AS Nombre, Programas.ProgramasAno AS Ano, Usuarios.UsuariosName As Responsable, ProgramasMapa.ProgramasMapaTipoGestion AS TipoGestion, ProgramasMapa.ProgramasMapaImportancia AS Puntaje "
        sSQL = sSQL & "FROM (((StakeholdersPorProgramas INNER JOIN Programas ON StakeholdersPorProgramas.ProgramasId = Programas.ProgramasId) INNER JOIN ProgramasMapa ON Programas.ProgramasCodigo = ProgramasMapa.ProgramasCodigo) INNER JOIN Stakeholders ON (StakeholdersPorProgramas.StakeholdersId = Stakeholders.StakeholdersId) AND (ProgramasMapa.StakeholdersCodigo = Stakeholders.StakeholdersCodigo)) INNER JOIN Usuarios ON Programas.ProgramasCoordinadoPor = Usuarios.UsuariosCodigo "
        sSQL = sSQL & "WHERE (((Stakeholders.StakeholdersId)=" & StakeholdersId & "))"

        Try
            dtrRutasPorViajes = AccesoEA.ListarRegistros(sSQL)

            rptProgramas.DataSource = dtrRutasPorViajes
            rptProgramas.DataBind()
            LoadProgramasPorStakeholders = True
            dtrRutasPorViajes.Close()
        Catch
            LoadProgramasPorStakeholders = False
        End Try
    End Function
    Public Function LoadRolEnProgramaPorStakeholders(ByRef rptProgramas As Repeater, ByVal StakeholdersId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Programas.ProgramasName As Programa, ProgramasMapa.ProgramasMapaRol As Rol, ProgramasMapa.ProgramasMapaFuncion As Funcion, ProgramasMapa.ProgramasMapaRelacion As Relacion "
        sSQL = sSQL & "FROM (Stakeholders INNER JOIN ProgramasMapa ON Stakeholders.StakeholdersCodigo = ProgramasMapa.StakeholdersCodigo) INNER JOIN Programas ON ProgramasMapa.ProgramasCodigo = Programas.ProgramasCodigo "
        sSQL = sSQL & "WHERE (((Stakeholders.StakeholdersId)=" & StakeholdersId & "))"

        Try
            dtrRutasPorViajes = AccesoEA.ListarRegistros(sSQL)

            rptProgramas.DataSource = dtrRutasPorViajes
            rptProgramas.DataBind()
            LoadRolEnProgramaPorStakeholders = True
            dtrRutasPorViajes.Close()
        Catch
            LoadRolEnProgramaPorStakeholders = False
        End Try
    End Function
    Public Function MostrarProgramasPorPalabraClave(ByVal PalabraClave As String, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim CodigoHTML As String = ""
        Dim dtr As IDataReader
        Dim strUpdate As String
        Dim NotasTransversales As New NotasTransversales


        strUpdate = "SELECT distinct Programas.[ProgramasCodigo] AS PGGCodigo "
        strUpdate = strUpdate & "FROM (Programas) "
        strUpdate = strUpdate & "WHERE (((Programas.ProgramasName) LIKE ('%" & PalabraClave & "%')) OR ((Programas.ProgramasDescription) LIKE ('%" & PalabraClave & "%')))"
        MostrarProgramasPorPalabraClave = ""
        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""alertas"">"
        CodigoHTML = CodigoHTML & "<tr><th scope=""col"">Programas con ['" & PalabraClave & "']</th></tr>"
        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                strUpdate = "<a href=""ReportesPGG.aspx?PaginaWebName=" & "Ver Mapa" & "&PGGCodigo=" & dtr("PGGCodigo").ToString & """ target=""_blank"">" & dtr("PGGCodigo").ToString & "</a>"
                MostrarProgramasPorPalabraClave = MostrarProgramasPorPalabraClave & "<tr><td>" & strUpdate & "</td></tr>"
            End While
            dtr.Close()
        Catch
            MostrarProgramasPorPalabraClave = ""
        End Try
        If Len(MostrarProgramasPorPalabraClave) = 0 Then
            MostrarProgramasPorPalabraClave = MostrarProgramasPorPalabraClave & "<tr><td>No se encontraron programas con '" & PalabraClave & "'</td></tr>"
        End If
        CodigoHTML = CodigoHTML & MostrarProgramasPorPalabraClave & "</table>"
        MostrarProgramasPorPalabraClave = CodigoHTML
    End Function




    Public Function ListarProgramasPorDimension(ByRef DimensionesEstrategicasCodigo As String, ByVal IsAuthorizedUser As Boolean) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim l As String
        Dim Prioridad As String = "Priorización"

        strUpdate = "SELECT Programas.ProgramasId AS Id, Programas.ProgramasCodigo AS Codigo, Programas.ProgramasName AS Name, Programas.GerenciasCodigo AS Gerencia, Usuarios.UsuariosName AS Responsable "
        strUpdate = strUpdate & "FROM ((IniciativasEstrategicas INNER JOIN (Programas INNER JOIN ProgramasIniciativas ON Programas.ProgramasId = ProgramasIniciativas.ProgramasId) ON IniciativasEstrategicas.IniciativasEstrategicasId = ProgramasIniciativas.IniciativasEstrategicasId) INNER JOIN DimensionesEstrategicas ON IniciativasEstrategicas.DimensionesEstrategicasCodigo = DimensionesEstrategicas.DimensionesEstrategicasCodigo) INNER JOIN Usuarios ON Programas.ProgramasCoordinadoPor = Usuarios.UsuariosCodigo "
        strUpdate = strUpdate & "WHERE (((DimensionesEstrategicas.DimensionesEstrategicasCodigo)='" & DimensionesEstrategicasCodigo & "'))"

        ListarProgramasPorDimension = ""

        CodigoHTML = "<table class=""popup_tabla_de_datos"">"
        CodigoHTML = CodigoHTML & "<tr>"
        CodigoHTML = CodigoHTML & "<th width=""400"">Nombre</th>"
        CodigoHTML = CodigoHTML & "<th width=""50"">Gerencia</th>"
        CodigoHTML = CodigoHTML & "<th width=""150"">Responsable</th>"
        If IsAuthorizedUser = True Then
            CodigoHTML = CodigoHTML & "<th width=""50"" align=""center"">Editar</th>"
        End If
        CodigoHTML = CodigoHTML & "</tr>"

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read

                l = dtr("Name").ToString
                l = l & "<br />"
                l = l & "&nbsp;&nbsp;&nbsp;<a href=""ReportesPGG.aspx?PaginaWebName=" & "Ver Mapa" & "&PGGCodigo=" & dtr("Codigo").ToString & """ target=""_blank"">" & "Mapa" & "</a>"
                l = l & "<br />"
                l = l & "&nbsp;&nbsp;&nbsp;<a href=""ReportesPGG.aspx?PaginaWebName=" & "Reporte SE1" & "&PGGCodigo=" & dtr("Codigo").ToString & """ target=""_blank"">" & "Lista de Stakeholders" & "</a>"
                l = l & "<br />"
                l = l & "&nbsp;&nbsp;&nbsp;<a href=""ReportesPGG.aspx?PaginaWebName=" & "Reporte SE2" & "&PGGCodigo=" & dtr("Codigo").ToString & """ target=""_blank"">" & Prioridad & "</a>"
                'l = l & "<br />"
                'l = l & "&nbsp;&nbsp;&nbsp;<a href=""ReportesPGG.aspx?PaginaWebName=" & "Reporte SE3" & "&PGGCodigo=" & dtr("Codigo").ToString & """ target=""_blank"">" & "Acciones por Stakeholders" & "</a>"
                l = l & "<br />"
                l = l & "&nbsp;&nbsp;&nbsp;<a href=""ReportesPGG.aspx?PaginaWebName=" & "Reporte SE4" & "&PGGCodigo=" & dtr("Codigo").ToString & """ target=""_blank"">" & "Plan de Actividades" & "</a>"
                l = l & "<br />"
                l = l & "&nbsp;&nbsp;&nbsp;<a href=""IndexSGI.aspx?PaginaWebName=DocumentosPorPrograma&MenuOptionsId=431&PGGCodigo=" & dtr("Codigo").ToString & """ >" & "Documentos" & "</a>"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td>" & l & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Gerencia").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Responsable").ToString & "</td>"
                If IsAuthorizedUser = True Then
                    l = "<a href=""IndexSGI.aspx?PaginaWebName=Ficha de Programas&MenuOptionsId=431&Id=" & dtr("Id").ToString & """><img src=""imgs/editar.png"" alt=""Editar"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" width=""20"" height=""20"" /></a>"
                    CodigoHTML = CodigoHTML & "<td>" & l & "</td>"
                End If
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch

        End Try
        CodigoHTML = CodigoHTML & "</table>"
        ListarProgramasPorDimension = CodigoHTML
    End Function
End Class
