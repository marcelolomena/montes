'------------------------------------------------------------
' Código generado por ZRISMART SF el 14-04-2011 0:37:55
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class PGG
    Public Function LeerPGG(ByVal PGGId As Long, ByRef PGGCodigo As String, ByRef PGGName As String, _
                            ByRef PGGAno As String, ByRef ProyectosCodigo As String, _
                            ByRef GerenciasCodigo As String, ByRef PGGElaboradoPor As String, _
                            ByRef PGGRevisadoPor As String, ByRef PGGAprobadoPor As String, _
                            ByRef PGGCoordinadoPor As String, ByRef PGGResponsableSSO As String, _
                            ByRef PGGResponsableC As String, ByRef PGGResponsableMA As String, _
                            ByRef PGGResponsableQ As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PGGCodigo, PGGName, PGGAno, ProyectosCodigo, GerenciasCodigo, PGGElaboradoPor, PGGRevisadoPor, PGGAprobadoPor, PGGCoordinadoPor, PGGResponsableSSO, PGGResponsableC, PGGResponsableMA, PGGResponsableQ "
        sSQL = sSQL & "FROM (PGG) "
        sSQL = sSQL & "WHERE (PGG.PGGId = " & PGGId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                PGGCodigo = CStr(dtr("PGGCodigo").ToString)
                PGGName = CStr(dtr("PGGName").ToString)
                PGGAno = CStr(dtr("PGGAno").ToString)
                ProyectosCodigo = CStr(dtr("ProyectosCodigo").ToString)
                GerenciasCodigo = CStr(dtr("GerenciasCodigo").ToString)
                PGGElaboradoPor = CStr(dtr("PGGElaboradoPor").ToString)
                PGGRevisadoPor = CStr(dtr("PGGRevisadoPor").ToString)
                PGGAprobadoPor = CStr(dtr("PGGAprobadoPor").ToString)
                PGGCoordinadoPor = CStr(dtr("PGGCoordinadoPor").ToString)
                PGGResponsableSSO = CStr(dtr("PGGResponsableSSO").ToString)
                PGGResponsableC = CStr(dtr("PGGResponsableC").ToString)
                PGGResponsableMA = CStr(dtr("PGGResponsableMA").ToString)
                PGGResponsableQ = CStr(dtr("PGGResponsableQ").ToString)
            End While
            LeerPGG = True
            dtr.Close()
        Catch
            LeerPGG = False
        End Try
    End Function
    Public Function LeerPGGCodigoById(ByVal PGGId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PGGCodigo "
        sSQL = sSQL & "FROM (PGG) "
        sSQL = sSQL & "WHERE (PGG.PGGId = " & PGGId & ") "
        LeerPGGCodigoById = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerPGGCodigoById = CStr(dtr("PGGCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerPGGCodigoById = ""
        End Try
    End Function
    Public Function LeerPGGByName(ByRef PGGId As Long, ByVal PGGCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PGGId "
        sSQL = sSQL & "FROM (PGG) "
        sSQL = sSQL & "WHERE (PGG.PGGCodigo = '" & PGGCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                PGGId = CLng(dtr("PGGId").ToString)
            End While
            LeerPGGByName = True
            dtr.Close()
        Catch
            LeerPGGByName = False
        End Try
    End Function
    Public Function LeerProyectosCodigoByPGGCodigo(ByVal PGGCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProyectosCodigo "
        sSQL = sSQL & "FROM (PGG) "
        sSQL = sSQL & "WHERE (PGG.PGGCodigo = '" & PGGCodigo & "') "
        LeerProyectosCodigoByPGGCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerProyectosCodigoByPGGCodigo = CStr(dtr("ProyectosCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerProyectosCodigoByPGGCodigo = ""
        End Try
    End Function
    Public Function LeerCoordinadorByPGGCodigo(ByVal PGGCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasCoordinadoPor "
        sSQL = sSQL & "FROM (Programas) "
        sSQL = sSQL & "WHERE (Programas.ProgramasCodigo = '" & PGGCodigo & "') "
        LeerCoordinadorByPGGCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerCoordinadorByPGGCodigo = CStr(dtr("ProgramasCoordinadoPor").ToString)
            End While
            dtr.Close()
        Catch
            LeerCoordinadorByPGGCodigo = ""
        End Try
    End Function
    Public Function LeerAccionTOP1ByPGGCodigo(ByVal PGGCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT TOP 1 Acciones.AccionesCodigo "
        sSQL = sSQL & "FROM (AccionesPorPGG INNER JOIN Acciones ON AccionesPorPGG.AccionesId = Acciones.AccionesId) INNER JOIN PGG ON AccionesPorPGG.PGGId = PGG.PGGId "
        sSQL = sSQL & "WHERE (((PGG.PGGCodigo)= '" & PGGCodigo & "'))"

        LeerAccionTOP1ByPGGCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerAccionTOP1ByPGGCodigo = CStr(dtr("AccionesCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerAccionTOP1ByPGGCodigo = ""
        End Try
    End Function
    Public Function PGGUpdate(ByVal PGGId As Long, ByRef PGGCodigo As String, ByRef PGGName As String, _
                            ByRef PGGAno As String, ByRef ProyectosCodigo As String, _
                            ByRef GerenciasCodigo As String, ByRef PGGElaboradoPor As String, _
                            ByRef PGGRevisadoPor As String, ByRef PGGAprobadoPor As String, _
                            ByRef PGGCoordinadoPor As String, ByRef PGGResponsableSSO As String, _
                            ByRef PGGResponsableC As String, ByRef PGGResponsableMA As String, _
                            ByRef PGGResponsableQ As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE PGG SET "
        strUpdate = strUpdate & "PGG.PGGCodigo = '" & PGGCodigo & "', "
        strUpdate = strUpdate & "PGG.PGGName = '" & PGGName & "', "
        strUpdate = strUpdate & "PGG.PGGAno = '" & PGGAno & "', "
        strUpdate = strUpdate & "PGG.ProyectosCodigo = '" & ProyectosCodigo & "', "
        strUpdate = strUpdate & "PGG.GerenciasCodigo = '" & GerenciasCodigo & "', "
        strUpdate = strUpdate & "PGG.PGGElaboradoPor = '" & PGGElaboradoPor & "', "
        strUpdate = strUpdate & "PGG.PGGRevisadoPor = '" & PGGRevisadoPor & "', "
        strUpdate = strUpdate & "PGG.PGGAprobadoPor = '" & PGGAprobadoPor & "', "
        strUpdate = strUpdate & "PGG.PGGCoordinadoPor = '" & PGGCoordinadoPor & "', "
        strUpdate = strUpdate & "PGG.PGGResponsableSSO = '" & PGGResponsableSSO & "', "
        strUpdate = strUpdate & "PGG.PGGResponsableC = '" & PGGResponsableC & "', "
        strUpdate = strUpdate & "PGG.PGGResponsableMA = '" & PGGResponsableMA & "', "
        strUpdate = strUpdate & "PGG.PGGResponsableQ = '" & PGGResponsableQ & "', "
        strUpdate = strUpdate & "PGG.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "PGG.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE PGG.PGGId = " & PGGId
        Try
            PGGUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & PGGCodigo, PGGId, "PGG", "")
        Catch
            PGGUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & PGGCodigo, PGGId, "PGG", "")
        End Try
    End Function
    Public Function PGGInsert(ByRef PGGId As Long, ByRef PGGCodigo As String, ByRef PGGName As String, _
                              ByRef PGGAno As String, ByRef ProyectosCodigo As String, _
                              ByRef GerenciasCodigo As String, ByRef PGGElaboradoPor As String, _
                              ByRef PGGRevisadoPor As String, ByRef PGGAprobadoPor As String, _
                            ByRef PGGCoordinadoPor As String, ByRef PGGResponsableSSO As String, _
                            ByRef PGGResponsableC As String, ByRef PGGResponsableMA As String, _
                            ByRef PGGResponsableQ As String, ByVal UserId As Long) As Integer

        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim PGG As New PGG
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = PGGCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("PGGId", "PGGCodigo", "PGG", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("PGGId", "PGGCodigo", "PGG", MasterName, CLng(UserId), MasterId)
            End If
            PGGInsert = PGG.PGGUpdate(MasterId, CStr(PGGCodigo), CStr(PGGName), CStr(PGGAno), CStr(ProyectosCodigo), CStr(GerenciasCodigo), CStr(PGGElaboradoPor), CStr(PGGRevisadoPor), CStr(PGGAprobadoPor), CStr(PGGCoordinadoPor), CStr(PGGResponsableSSO), CStr(PGGResponsableC), CStr(PGGResponsableMA), CStr(PGGResponsableQ), UserId)
        Catch
            PGGInsert = 0
        End Try
    End Function
    Public Function LeerPGGDescriptionByName(ByVal PGGCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasName as PGGName "
        sSQL = sSQL & "FROM (Programas) "
        sSQL = sSQL & "WHERE (Programas.ProgramasCodigo = '" & PGGCodigo & "') "
        LeerPGGDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerPGGDescriptionByName = CStr(dtr("PGGName").ToString)
            End While
            dtr.Close()
        Catch
            LeerPGGDescriptionByName = ""
        End Try
    End Function
    Public Function LeerTotalPGGPorTablasRelacionadas(ByVal PGGCodigo As String, ByVal PGGId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si el PGG tiene tareas con evidencias registradas
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM (Tareas INNER JOIN PGG ON Tareas.PGGCodigo = PGG.PGGCodigo) INNER JOIN TareasDocs ON Tareas.TareasCodigo = TareasDocs.TareasCodigo "
        sSQL = sSQL & "WHERE(PGG.PGGId = " & PGGId & ")"
        ' Si tiene al menos una evidencia no podemos borrarlo hasta que se elimina la evidencia
        LeerTotalPGGPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalPGGPorTablasRelacionadas = LeerTotalPGGPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalPGGPorTablasRelacionadas = 0
        End Try
        'Verifica si el PGG tiene KPI registrados para alguna tarea
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM (Tareas INNER JOIN PGG ON Tareas.PGGCodigo = PGG.PGGCodigo) INNER JOIN TareasKPI ON Tareas.TareasCodigo = TareasKPI.TareasCodigo "
        sSQL = sSQL & "WHERE(PGG.PGGId = " & PGGId & ")"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalPGGPorTablasRelacionadas = LeerTotalPGGPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalPGGPorTablasRelacionadas = LeerTotalPGGPorTablasRelacionadas + 0
        End Try
    End Function
    Public Function PGGDelete(ByVal PGGId As Long, ByVal PGGCodigo As String, ByVal UserId As Long, ByRef Mensaje As String, ByVal MenuOptionsId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim PGG As New PGG
        Dim Rol As New Rol

        ' Verificar si el PGG posee evidencias o KPI registrados
        '---------------------------------------------------------
        Total = PGG.LeerTotalPGGPorTablasRelacionadas(PGGCodigo, PGGId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados al PGG " & PGGCodigo & vbCrLf
            Mensaje = Mensaje & ", elimine las Evidencias y KPI, antes de eliminarlo de la lista"
            PGGDelete = False
        Else
            Try
                ' Borra registros de la tabla de AccionesPorPGG
                '----------------------------------------------
                strUpdate = "DELETE FROM AccionesPorPGG WHERE PGGId = " & PGGId
                t = AccesoEA.ABMRegistros(strUpdate)
                ' Borra registros de la tabla de Tareas
                '-------------------------------------
                strUpdate = "DELETE FROM Tareas WHERE PGGCodigo = '" & PGGCodigo & "'"
                t = AccesoEA.ABMRegistros(strUpdate)
                ' Borra registro de la tabla de Tareas
                '--------------------------------------
                strUpdate = "DELETE FROM PGG WHERE PGGId = " & PGGId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), MenuOptionsId, "Elimina el PGG: " & PGGCodigo, PGGId, "PGG", "")
                PGGDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), MenuOptionsId, "Intento fallido de eliminar el PGG: " & PGGCodigo, PGGId, "PGG", "")
                PGGDelete = False
            End Try
        End If
    End Function
    Public Function LeerTotalAccionesPorPGGPorTablasRelacionadas(ByVal PGGId As Long, ByVal AccionesId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si la Acción del PGG tiene tareas con evidencias registradas
        sSQL = "SELECT Count(TareasDocs.TareasDocsId) AS Total "
        sSQL = sSQL & "FROM (((AccionesPorPGG INNER JOIN Acciones ON AccionesPorPGG.AccionesId = Acciones.AccionesId) INNER JOIN PGG ON AccionesPorPGG.PGGId = PGG.PGGId) INNER JOIN Tareas ON (Acciones.AccionesCodigo = Tareas.AccionesCodigo) AND (PGG.PGGCodigo = Tareas.PGGCodigo)) INNER JOIN TareasDocs ON Tareas.TareasCodigo = TareasDocs.TareasCodigo "
        sSQL = sSQL & "GROUP BY AccionesPorPGG.PGGId, AccionesPorPGG.AccionesId "
        sSQL = sSQL & "HAVING (((AccionesPorPGG.PGGId)=" & PGGId & ") AND ((AccionesPorPGG.AccionesId)=" & AccionesId & "))"
        ' Si tiene al menos una evidencia no podemos eliminar la acción hasta que se elimina la evidencia
        LeerTotalAccionesPorPGGPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalAccionesPorPGGPorTablasRelacionadas = LeerTotalAccionesPorPGGPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalAccionesPorPGGPorTablasRelacionadas = 0
        End Try
        'Verifica si la Acción del PGG tiene KPI registrados para alguna tarea
        sSQL = "SELECT Count(TareasKPI.TareasKPIId) AS Total "
        sSQL = sSQL & "FROM (((AccionesPorPGG INNER JOIN Acciones ON AccionesPorPGG.AccionesId = Acciones.AccionesId) INNER JOIN PGG ON AccionesPorPGG.PGGId = PGG.PGGId) INNER JOIN Tareas ON (Acciones.AccionesCodigo = Tareas.AccionesCodigo) AND (PGG.PGGCodigo = Tareas.PGGCodigo)) INNER JOIN TareasKPI ON Tareas.TareasCodigo = TareasKPI.TareasCodigo "
        sSQL = sSQL & "GROUP BY AccionesPorPGG.PGGId, AccionesPorPGG.AccionesId "
        sSQL = sSQL & "HAVING (((AccionesPorPGG.PGGId)=" & PGGId & ") AND ((AccionesPorPGG.AccionesId)=" & AccionesId & "))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalAccionesPorPGGPorTablasRelacionadas = LeerTotalAccionesPorPGGPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalAccionesPorPGGPorTablasRelacionadas = LeerTotalAccionesPorPGGPorTablasRelacionadas + 0
        End Try
    End Function
    ' Me falta borrar AccionesPorPGG que incluye borrar las tareas asociadas en caso de que no 
    ' tenga evidencias o KPI asociados.
    Public Function AccionesPorPGGDelete(ByVal PGGId As Long, ByVal AccionesId As Long, ByVal UserId As Long, ByRef Mensaje As String, ByVal MenuOptionsId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim PGG As New PGG
        Dim Acciones As New Acciones
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Rol As New Rol
        Dim AccionesCodigo As String = Acciones.LeerAccionesCodigoById(AccionesId)
        Dim PGGCodigo As String = PGG.LeerPGGCodigoById(PGGId)

        ' Verificar si el PGG posee evidencias o KPI registrados
        '---------------------------------------------------------
        Total = PGG.LeerTotalAccionesPorPGGPorTablasRelacionadas(PGGId, AccionesId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados al PGG " & PGGCodigo & vbCrLf
            Mensaje = Mensaje & ", elimine las Evidencias y KPI, antes de eliminarlo de la lista"
            AccionesPorPGGDelete = False
        Else
            Try
                ' Borra registros de la tabla de AccionesPorPGG
                '----------------------------------------------
                strUpdate = "DELETE FROM AccionesPorPGG WHERE PGGId = " & PGGId & " AND AccionesId = " & AccionesId
                t = AccesoEA.ABMRegistros(strUpdate)
                ' Borra registros de la tabla de Tareas
                '-------------------------------------
                strUpdate = "DELETE FROM Tareas WHERE PGGCodigo = '" & PGGCodigo & "' AND AccionesCodigo = '" & AccionesCodigo & "'"
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), MenuOptionsId, "Elimina Acción " & AccionesCodigo & " del PGG: " & PGGCodigo, AccionesId, "AccionesPorPGG", "")
                AccionesPorPGGDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), MenuOptionsId, "Intento fallido de eliminar Acción " & AccionesCodigo & " del PGG: " & PGGCodigo, AccionesId, "AccionesPorPGG", "")
                AccionesPorPGGDelete = False
            End Try
        End If
    End Function

End Class