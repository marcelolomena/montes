'------------------------------------------------------------
' Código generado por ZRISMART SF el 01-04-2011 16:03:35
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Proyectos
    Public Function LeerProyectos(ByVal ProyectosId As Long, ByRef ProyectosCodigo As String, ByRef ProyectosName As String, ByRef ProyectosDescription As String, ByRef ProyectosResponsable As String, ByRef ProyectosCorreo As String, ByRef ProyectosCargo As String, ByRef GerenciasCodigo As String, ByRef ProyectosFechaInicio As Date, ByRef ProyectosFechaTermino As Date) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProyectosCodigo, ProyectosName, ProyectosDescription, ProyectosResponsable, ProyectosCorreo, ProyectosCargo, GerenciasCodigo, ProyectosFechaInicio, ProyectosFechaTermino "
        sSQL = sSQL & "FROM (Proyectos) "
        sSQL = sSQL & "WHERE (Proyectos.ProyectosId = " & ProyectosId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProyectosCodigo = CStr(dtr("ProyectosCodigo").ToString)
                ProyectosName = CStr(dtr("ProyectosName").ToString)
                ProyectosDescription = CStr(dtr("ProyectosDescription").ToString)
                ProyectosResponsable = CStr(dtr("ProyectosResponsable").ToString)
                ProyectosCorreo = CStr(dtr("ProyectosCorreo").ToString)
                ProyectosCargo = CStr(dtr("ProyectosCargo").ToString)
                GerenciasCodigo = CStr(dtr("GerenciasCodigo").ToString)
                If Len(dtr("ProyectosFechaInicio").ToString) = 0 Then
                    ProyectosFechaInicio = "01/01/01"
                Else
                    ProyectosFechaInicio = CDate(dtr("ProyectosFechaInicio").ToString)
                End If
                If Len(dtr("ProyectosFechaTermino").ToString) = 0 Then
                    ProyectosFechaTermino = "01/01/01"
                Else
                    ProyectosFechaTermino = CDate(dtr("ProyectosFechaTermino").ToString)
                End If
            End While
            LeerProyectos = True
            dtr.Close()
        Catch
            LeerProyectos = False
        End Try
    End Function
    Public Function LeerProyectosByName(ByRef ProyectosId As Long, ByVal ProyectosCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProyectosId "
        sSQL = sSQL & "FROM (Proyectos) "
        sSQL = sSQL & "WHERE (Proyectos.ProyectosCodigo = '" & ProyectosCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProyectosId = CLng(dtr("ProyectosId").ToString)
            End While
            LeerProyectosByName = True
            dtr.Close()
        Catch
            LeerProyectosByName = False
        End Try
    End Function
    Public Function ProyectosUpdate(ByVal ProyectosId As Long, ByRef ProyectosCodigo As String, ByRef ProyectosName As String, ByRef ProyectosDescription As String, ByRef ProyectosResponsable As String, ByRef ProyectosCorreo As String, ByRef ProyectosCargo As String, ByRef GerenciasCodigo As String, ByRef ProyectosFechaInicio As Date, ByRef ProyectosFechaTermino As Date, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Proyectos SET "
        strUpdate = strUpdate & "Proyectos.ProyectosCodigo = '" & ProyectosCodigo & "', "
        strUpdate = strUpdate & "Proyectos.ProyectosName = '" & ProyectosName & "', "
        strUpdate = strUpdate & "Proyectos.ProyectosDescription = '" & ProyectosDescription & "', "
        strUpdate = strUpdate & "Proyectos.ProyectosResponsable = '" & ProyectosResponsable & "', "
        strUpdate = strUpdate & "Proyectos.ProyectosCorreo = '" & ProyectosCorreo & "', "
        strUpdate = strUpdate & "Proyectos.ProyectosCargo = '" & ProyectosCargo & "', "
        strUpdate = strUpdate & "Proyectos.GerenciasCodigo = '" & GerenciasCodigo & "', "
        strUpdate = strUpdate & "Proyectos.ProyectosFechaInicio = '" & AccionesABM.DateTransform(ProyectosFechaInicio) & "', "
        strUpdate = strUpdate & "Proyectos.ProyectosFechaTermino = '" & AccionesABM.DateTransform(ProyectosFechaTermino) & "', "
        strUpdate = strUpdate & "Proyectos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Proyectos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Proyectos.ProyectosId = " & ProyectosId
        Try
            ProyectosUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ProyectosCodigo, ProyectosId, "Proyectos", "")
        Catch
            ProyectosUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ProyectosCodigo, ProyectosId, "Proyectos", "")
        End Try
    End Function
    Public Function ProyectosInsert(ByRef ProyectosId As Long, ByRef ProyectosCodigo As String, ByRef ProyectosName As String, ByRef ProyectosDescription As String, ByRef ProyectosResponsable As String, ByRef ProyectosCorreo As String, ByRef ProyectosCargo As String, ByRef GerenciasCodigo As String, ByRef ProyectosFechaInicio As Date, ByRef ProyectosFechaTermino As Date, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Proyectos As New Proyectos
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = ProyectosCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("ProyectosId", "ProyectosCodigo", "Proyectos", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("ProyectosId", "ProyectosCodigo", "Proyectos", MasterName, CLng(UserId), MasterId)
            End If
            ProyectosInsert = Proyectos.ProyectosUpdate(MasterId, CStr(ProyectosCodigo), CStr(ProyectosName), CStr(ProyectosDescription), CStr(ProyectosResponsable), CStr(ProyectosCorreo), CStr(ProyectosCargo), CStr(GerenciasCodigo), CDate(ProyectosFechaInicio), CDate(ProyectosFechaTermino), UserId)
        Catch
            ProyectosInsert = 0
        End Try
    End Function
    Public Function LeerProyectosDescriptionByName(ByVal ProyectosCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProyectosName "
        sSQL = sSQL & "FROM (Proyectos) "
        sSQL = sSQL & "WHERE (Proyectos.ProyectosCodigo = '" & ProyectosCodigo & "') "
        LeerProyectosDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerProyectosDescriptionByName = CStr(dtr("ProyectosName").ToString)
            End While

            dtr.Close()
        Catch
            LeerProyectosDescriptionByName = ""
        End Try
    End Function
    Public Function LeerAPIsPorProyecto(ByVal ProyectosCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim i As Integer = 0


        sSQL = "SELECT API.APICodigo "
        sSQL = sSQL & "FROM (Proyectos INNER JOIN APIPorProyecto ON Proyectos.ProyectosId = APIPorProyecto.ProyectosId) INNER JOIN API ON APIPorProyecto.APIId = API.APIId "
        sSQL = sSQL & "WHERE (((Proyectos.ProyectosCodigo)='" & ProyectosCodigo & "'))"

        LeerAPIsPorProyecto = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If i > 0 Then
                    LeerAPIsPorProyecto = LeerAPIsPorProyecto & " - " & CStr(dtr("APICodigo").ToString)
                Else
                    LeerAPIsPorProyecto = LeerAPIsPorProyecto & CStr(dtr("APICodigo").ToString)
                End If
                i = i + 1
            End While
            dtr.Close()
        Catch
            LeerAPIsPorProyecto = ""
        End Try
    End Function
    Public Function LeerTotalProyectosPorTablasRelacionadas(ByVal ProyectosCodigo As String, ByVal ProyectosId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en un PGG
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Proyectos INNER JOIN PGG ON Proyectos.ProyectosCodigo = PGG.ProyectosCodigo "
        sSQL = sSQL & "WHERE (((Proyectos.ProyectosCodigo)='" & ProyectosCodigo & "'))"
        LeerTotalProyectosPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalProyectosPorTablasRelacionadas = LeerTotalProyectosPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalProyectosPorTablasRelacionadas = 0
        End Try
        'Verifica si tiene documentos relacionados
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Proyectos INNER JOIN ProyectosDocs ON Proyectos.ProyectosCodigo = ProyectosDocs.ProyectosCodigo "
        sSQL = sSQL & "WHERE (((Proyectos.ProyectosCodigo)='" & ProyectosCodigo & "'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalProyectosPorTablasRelacionadas = LeerTotalProyectosPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalProyectosPorTablasRelacionadas = LeerTotalProyectosPorTablasRelacionadas + 0
        End Try
        'Verifica si posee contratos asociados
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Proyectos INNER JOIN ContratosPorProyecto ON Proyectos.ProyectosId = ContratosPorProyecto.ProyectosId "
        sSQL = sSQL & "WHERE (((Proyectos.ProyectosId)=" & ProyectosId & "))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalProyectosPorTablasRelacionadas = LeerTotalProyectosPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalProyectosPorTablasRelacionadas = LeerTotalProyectosPorTablasRelacionadas + 0
        End Try
        'Verifica si posee API's Relacionadas
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Proyectos INNER JOIN APIPorProyecto ON Proyectos.ProyectosId = APIPorProyecto.ProyectosId "
        sSQL = sSQL & "WHERE (((Proyectos.ProyectosId)=" & ProyectosId & "))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalProyectosPorTablasRelacionadas = LeerTotalProyectosPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalProyectosPorTablasRelacionadas = LeerTotalProyectosPorTablasRelacionadas + 0
        End Try
    End Function
    Public Function ProyectosDelete(ByVal ProyectosId As Long, ByVal ProyectosCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Proyectos As New Proyectos

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Proyectos.LeerTotalProyectosPorTablasRelacionadas(ProyectosCodigo, ProyectosId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados al Proyecto " & ProyectosCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie el Proyecto en los Programas y elimine los documentos del proyecto y sus relaciones con Contratos y API, antes de eliminarlo de la lista"
            ProyectosDelete = False
        Else
            Try
                ' Borra registro de la tabla de Proyectos
                '-------------------------------------
                strUpdate = "DELETE FROM Proyectos WHERE ProyectosId = " & ProyectosId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Proyecto: " & ProyectosCodigo, ProyectosId, "Proyectos", "")
                ProyectosDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Proyecto: " & ProyectosCodigo, ProyectosId, "Proyectos", "")
                ProyectosDelete = False
            End Try
        End If
    End Function
End Class
