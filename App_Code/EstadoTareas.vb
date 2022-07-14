'------------------------------------------------------------
' Código generado por ZRISMART SF el 19-04-2011 15:22:14
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class EstadoTareas
    Public Function LeerEstadoTareas(ByVal EstadoTareasId As Long, ByRef EstadoTareasName As String, ByRef EstadoTareasDescription As String, ByRef EstadoTareasSecuencia As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EstadoTareasName, EstadoTareasDescription, EstadoTareasSecuencia "
        sSQL = sSQL & "FROM (EstadoTareas) "
        sSQL = sSQL & "WHERE (EstadoTareas.EstadoTareasId = " & EstadoTareasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                EstadoTareasName = CStr(dtr("EstadoTareasName").ToString)
                EstadoTareasDescription = CStr(dtr("EstadoTareasDescription").ToString)
                If Len(dtr("EstadoTareasSecuencia").ToString) = 0 Then
                    EstadoTareasSecuencia = 0
                Else
                    EstadoTareasSecuencia = CLng(dtr("EstadoTareasSecuencia").ToString)
                End If
            End While
            LeerEstadoTareas = True
            dtr.Close()
        Catch
            LeerEstadoTareas = False
        End Try
    End Function
    Public Function LeerEstadoTareasByName(ByRef EstadoTareasId As Long, ByVal EstadoTareasName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EstadoTareasId "
        sSQL = sSQL & "FROM (EstadoTareas) "
        sSQL = sSQL & "WHERE (EstadoTareas.EstadoTareasName = '" & EstadoTareasName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                EstadoTareasId = CLng(dtr("EstadoTareasId").ToString)
            End While
            LeerEstadoTareasByName = True
            dtr.Close()
        Catch
            LeerEstadoTareasByName = False
        End Try
    End Function
    Public Function EstadoTareasUpdate(ByVal EstadoTareasId As Long, ByRef EstadoTareasName As String, ByRef EstadoTareasDescription As String, ByRef EstadoTareasSecuencia As Long, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE EstadoTareas SET "
        strUpdate = strUpdate & "EstadoTareas.EstadoTareasName = '" & EstadoTareasName & "', "
        strUpdate = strUpdate & "EstadoTareas.EstadoTareasDescription = '" & EstadoTareasDescription & "', "
        strUpdate = strUpdate & "EstadoTareas.EstadoTareasSecuencia = " & EstadoTareasSecuencia & ", "
        strUpdate = strUpdate & "EstadoTareas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "EstadoTareas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE EstadoTareas.EstadoTareasId = " & EstadoTareasId
        Try
            EstadoTareasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & EstadoTareasName, EstadoTareasId, "EstadoTareas", "")
        Catch
            EstadoTareasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & EstadoTareasName, EstadoTareasId, "EstadoTareas", "")
        End Try
    End Function
    Public Function EstadoTareasInsert(ByRef EstadoTareasId As Long, ByRef EstadoTareasName As String, ByRef EstadoTareasDescription As String, ByRef EstadoTareasSecuencia As Long, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim EstadoTareas As New EstadoTareas
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = EstadoTareasName
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("EstadoTareasId", "EstadoTareasName", "EstadoTareas", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("EstadoTareasId", "EstadoTareasName", "EstadoTareas", MasterName, CLng(UserId), MasterId)
            End If
            EstadoTareasInsert = EstadoTareas.EstadoTareasUpdate(MasterId, CStr(EstadoTareasName), CStr(EstadoTareasDescription), CLng(EstadoTareasSecuencia), UserId)
        Catch
            EstadoTareasInsert = 0
        End Try
    End Function
    Public Function LeerEstadoTareasDescriptionByName(ByVal EstadoTareasName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EstadoTareasDescription "
        sSQL = sSQL & "FROM (EstadoTareas) "
        sSQL = sSQL & "WHERE (EstadoTareas.EstadoTareasName = '" & EstadoTareasName & "') "
        LeerEstadoTareasDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerEstadoTareasDescriptionByName = CStr(dtr("EstadoTareasDescription").ToString)
            End While
            dtr.Close()
        Catch
            LeerEstadoTareasDescriptionByName = ""
        End Try
    End Function
    Public Function LeerRolResponsableSegunEstadoDeTareas(ByVal TareasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios

        sSQL = "SELECT Acciones.RolName As Rol "
        sSQL = sSQL & "FROM Tareas INNER JOIN Acciones ON Tareas.EstadoTareasCodigo = Acciones.AccionesName "
        sSQL = sSQL & "WHERE (((Tareas.TareasId)=" & TareasId & "))"

        LeerRolResponsableSegunEstadoDeTareas = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerRolResponsableSegunEstadoDeTareas = dtr("Rol").ToString
            End While
            dtr.Close()
        Catch
            LeerRolResponsableSegunEstadoDeTareas = ""
        End Try
    End Function

    Public Function LeerRolResponsableSegunEstadoActualDelaTarea(ByVal TareasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
        'Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)

        'sSQL = "Select EstadoTareas.EstadoTareasRolResponsable As Rol "
        'sSQL = sSQL & "FROM(EstadoTareas) "
        'sSQL = sSQL & "WHERE (((EstadoTareas.EstadoTareasName)= '" & EstadoTareasCodigo & "'))"

        sSQL = "SELECT Acciones.RolName As Rol "
        sSQL = sSQL & "FROM Tareas INNER JOIN Acciones ON Tareas.EstadoTareasCodigo = Acciones.AccionesName "
        sSQL = sSQL & "WHERE (((Tareas.TareasId)=" & TareasId & "))"

        LeerRolResponsableSegunEstadoActualDelaTarea = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerRolResponsableSegunEstadoActualDelaTarea = dtr("Rol").ToString
            End While
            dtr.Close()
        Catch
            LeerRolResponsableSegunEstadoActualDelaTarea = ""
        End Try
    End Function

End Class
