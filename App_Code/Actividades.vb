'------------------------------------------------------------
' Código generado por ZRISMART SF el 18-04-2011 17:55:24
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Actividades
    Public Function LeerActividades(ByVal ActividadesId As Long, ByRef AccionesCodigo As String, ByRef ActividadesSecuencia As Long, ByRef ActividadObjetivo As String, ByRef ActividadEspecifica As String, ByRef ActividadPublicoObjetivo As String, ByRef ActividadOtrasObservaciones As String, ByRef CargosCodigo As String, ByRef ActividadesHH As Double, ByRef ActividadesUSD As Double, ByRef ActividadesEnEnero As Long, ByRef ActividadesEnFebrero As Long, ByRef ActividadesEnMarzo As Long, ByRef ActividadesEnAbril As Long, ByRef ActividadesEnMayo As Long, ByRef ActividadesEnJunio As Long, ByRef ActividadesEnJulio As Long, ByRef ActividadesEnAgosto As Long, ByRef ActividadesEnSeptiembre As Long, ByRef ActividadesEnOctubre As Long, ByRef ActividadesEnNoviembre As Long, ByRef ActividadesEnDiciembre As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AccionesCodigo, ActividadesSecuencia, ActividadObjetivo, ActividadEspecifica, ActividadPublicoObjetivo, ActividadOtrasObservaciones, CargosCodigo, ActividadesHH, ActividadesUSD, ActividadesEnEnero, ActividadesEnFebrero, ActividadesEnMarzo, ActividadesEnAbril, ActividadesEnMayo, ActividadesEnJunio, ActividadesEnJulio, ActividadesEnAgosto, ActividadesEnSeptiembre, ActividadesEnOctubre, ActividadesEnNoviembre, ActividadesEnDiciembre "
        sSQL = sSQL & "FROM (Actividades) "
        sSQL = sSQL & "WHERE (Actividades.ActividadesId = " & ActividadesId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                AccionesCodigo = CStr(dtr("AccionesCodigo").ToString)
                If Len(dtr("ActividadesSecuencia").ToString) = 0 Then
                    ActividadesSecuencia = 0
                Else
                    ActividadesSecuencia = CLng(dtr("ActividadesSecuencia").ToString)
                End If
                ActividadObjetivo = CStr(dtr("ActividadObjetivo").ToString)
                ActividadEspecifica = CStr(dtr("ActividadEspecifica").ToString)
                ActividadPublicoObjetivo = CStr(dtr("ActividadPublicoObjetivo").ToString)
                ActividadOtrasObservaciones = CStr(dtr("ActividadOtrasObservaciones").ToString)
                CargosCodigo = CStr(dtr("CargosCodigo").ToString)
                If Len(dtr("ActividadesHH").ToString) = 0 Then
                    ActividadesHH = 0
                Else
                    ActividadesHH = CDbl(dtr("ActividadesHH").ToString)
                End If
                If Len(dtr("ActividadesUSD").ToString) = 0 Then
                    ActividadesUSD = 0
                Else
                    ActividadesUSD = CDbl(dtr("ActividadesUSD").ToString)
                End If
                If Len(dtr("ActividadesEnEnero").ToString) = 0 Then
                    ActividadesEnEnero = 0
                Else
                    ActividadesEnEnero = CLng(dtr("ActividadesEnEnero").ToString)
                End If
                If Len(dtr("ActividadesEnFebrero").ToString) = 0 Then
                    ActividadesEnFebrero = 0
                Else
                    ActividadesEnFebrero = CLng(dtr("ActividadesEnFebrero").ToString)
                End If
                If Len(dtr("ActividadesEnMarzo").ToString) = 0 Then
                    ActividadesEnMarzo = 0
                Else
                    ActividadesEnMarzo = CLng(dtr("ActividadesEnMarzo").ToString)
                End If
                If Len(dtr("ActividadesEnAbril").ToString) = 0 Then
                    ActividadesEnAbril = 0
                Else
                    ActividadesEnAbril = CLng(dtr("ActividadesEnAbril").ToString)
                End If
                If Len(dtr("ActividadesEnMayo").ToString) = 0 Then
                    ActividadesEnMayo = 0
                Else
                    ActividadesEnMayo = CLng(dtr("ActividadesEnMayo").ToString)
                End If
                If Len(dtr("ActividadesEnJunio").ToString) = 0 Then
                    ActividadesEnJunio = 0
                Else
                    ActividadesEnJunio = CLng(dtr("ActividadesEnJunio").ToString)
                End If
                If Len(dtr("ActividadesEnJulio").ToString) = 0 Then
                    ActividadesEnJulio = 0
                Else
                    ActividadesEnJulio = CLng(dtr("ActividadesEnJulio").ToString)
                End If
                If Len(dtr("ActividadesEnAgosto").ToString) = 0 Then
                    ActividadesEnAgosto = 0
                Else
                    ActividadesEnAgosto = CLng(dtr("ActividadesEnAgosto").ToString)
                End If
                If Len(dtr("ActividadesEnSeptiembre").ToString) = 0 Then
                    ActividadesEnSeptiembre = 0
                Else
                    ActividadesEnSeptiembre = CLng(dtr("ActividadesEnSeptiembre").ToString)
                End If
                If Len(dtr("ActividadesEnOctubre").ToString) = 0 Then
                    ActividadesEnOctubre = 0
                Else
                    ActividadesEnOctubre = CLng(dtr("ActividadesEnOctubre").ToString)
                End If
                If Len(dtr("ActividadesEnNoviembre").ToString) = 0 Then
                    ActividadesEnNoviembre = 0
                Else
                    ActividadesEnNoviembre = CLng(dtr("ActividadesEnNoviembre").ToString)
                End If
                If Len(dtr("ActividadesEnDiciembre").ToString) = 0 Then
                    ActividadesEnDiciembre = 0
                Else
                    ActividadesEnDiciembre = CLng(dtr("ActividadesEnDiciembre").ToString)
                End If
            End While
            LeerActividades = True
            dtr.Close()
        Catch
            LeerActividades = False
        End Try
    End Function
    Public Function ActividadesUpdate(ByVal ActividadesId As Long, ByRef AccionesCodigo As String, ByRef ActividadesSecuencia As Long, ByRef ActividadObjetivo As String, ByRef ActividadEspecifica As String, ByRef ActividadPublicoObjetivo As String, ByRef ActividadOtrasObservaciones As String, ByRef CargosCodigo As String, ByRef ActividadesHH As Double, ByRef ActividadesUSD As Double, ByRef ActividadesEnEnero As Long, ByRef ActividadesEnFebrero As Long, ByRef ActividadesEnMarzo As Long, ByRef ActividadesEnAbril As Long, ByRef ActividadesEnMayo As Long, ByRef ActividadesEnJunio As Long, ByRef ActividadesEnJulio As Long, ByRef ActividadesEnAgosto As Long, ByRef ActividadesEnSeptiembre As Long, ByRef ActividadesEnOctubre As Long, ByRef ActividadesEnNoviembre As Long, ByRef ActividadesEnDiciembre As Long, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Actividades SET "
        strUpdate = strUpdate & "Actividades.AccionesCodigo = '" & AccionesCodigo & "', "
        strUpdate = strUpdate & "Actividades.ActividadesSecuencia = " & ActividadesSecuencia & ", "
        strUpdate = strUpdate & "Actividades.ActividadObjetivo = '" & ActividadObjetivo & "', "
        strUpdate = strUpdate & "Actividades.ActividadEspecifica = '" & ActividadEspecifica & "', "
        strUpdate = strUpdate & "Actividades.ActividadPublicoObjetivo = '" & ActividadPublicoObjetivo & "', "
        strUpdate = strUpdate & "Actividades.ActividadOtrasObservaciones = '" & ActividadOtrasObservaciones & "', "
        strUpdate = strUpdate & "Actividades.CargosCodigo = '" & CargosCodigo & "', "
        strUpdate = strUpdate & "Actividades.ActividadesHH = " & ActividadesHH & ", "
        strUpdate = strUpdate & "Actividades.ActividadesUSD = " & ActividadesUSD & ", "
        strUpdate = strUpdate & "Actividades.ActividadesEnEnero = " & ActividadesEnEnero & ", "
        strUpdate = strUpdate & "Actividades.ActividadesEnFebrero = " & ActividadesEnFebrero & ", "
        strUpdate = strUpdate & "Actividades.ActividadesEnMarzo = " & ActividadesEnMarzo & ", "
        strUpdate = strUpdate & "Actividades.ActividadesEnAbril = " & ActividadesEnAbril & ", "
        strUpdate = strUpdate & "Actividades.ActividadesEnMayo = " & ActividadesEnMayo & ", "
        strUpdate = strUpdate & "Actividades.ActividadesEnJunio = " & ActividadesEnJunio & ", "
        strUpdate = strUpdate & "Actividades.ActividadesEnJulio = " & ActividadesEnJulio & ", "
        strUpdate = strUpdate & "Actividades.ActividadesEnAgosto = " & ActividadesEnAgosto & ", "
        strUpdate = strUpdate & "Actividades.ActividadesEnSeptiembre = " & ActividadesEnSeptiembre & ", "
        strUpdate = strUpdate & "Actividades.ActividadesEnOctubre = " & ActividadesEnOctubre & ", "
        strUpdate = strUpdate & "Actividades.ActividadesEnNoviembre = " & ActividadesEnNoviembre & ", "
        strUpdate = strUpdate & "Actividades.ActividadesEnDiciembre = " & ActividadesEnDiciembre & ", "
        strUpdate = strUpdate & "Actividades.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Actividades.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Actividades.ActividadesId = " & ActividadesId
        Try
            ActividadesUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & AccionesCodigo, ActividadesId, "Actividades", "")
        Catch
            ActividadesUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & AccionesCodigo, ActividadesId, "Actividades", "")
        End Try
    End Function
    Public Function ActividadesInsert(ByRef ActividadesId As Long, ByRef AccionesCodigo As String, ByRef ActividadesSecuencia As Long, ByRef ActividadObjetivo As String, ByRef ActividadEspecifica As String, ByRef ActividadPublicoObjetivo As String, ByRef ActividadOtrasObservaciones As String, ByRef CargosCodigo As String, ByRef ActividadesHH As Double, ByRef ActividadesUSD As Double, ByRef ActividadesEnEnero As Long, ByRef ActividadesEnFebrero As Long, ByRef ActividadesEnMarzo As Long, ByRef ActividadesEnAbril As Long, ByRef ActividadesEnMayo As Long, ByRef ActividadesEnJunio As Long, ByRef ActividadesEnJulio As Long, ByRef ActividadesEnAgosto As Long, ByRef ActividadesEnSeptiembre As Long, ByRef ActividadesEnOctubre As Long, ByRef ActividadesEnNoviembre As Long, ByRef ActividadesEnDiciembre As Long, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Actividades As New Actividades
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = AccionesCodigo
            DetailSecuencia = ActividadesSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("ActividadesId", "AccionesCodigo", "ActividadesSecuencia", "Actividades", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("ActividadesId", "AccionesCodigo", "ActividadesSecuencia", "Actividades", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            ActividadesInsert = Actividades.ActividadesUpdate(DetailId, CStr(AccionesCodigo), CLng(ActividadesSecuencia), CStr(ActividadObjetivo), CStr(ActividadEspecifica), CStr(ActividadPublicoObjetivo), CStr(ActividadOtrasObservaciones), CStr(CargosCodigo), CDbl(ActividadesHH), CDbl(ActividadesUSD), CLng(ActividadesEnEnero), CLng(ActividadesEnFebrero), CLng(ActividadesEnMarzo), CLng(ActividadesEnAbril), CLng(ActividadesEnMayo), CLng(ActividadesEnJunio), CLng(ActividadesEnJulio), CLng(ActividadesEnAgosto), CLng(ActividadesEnSeptiembre), CLng(ActividadesEnOctubre), CLng(ActividadesEnNoviembre), CLng(ActividadesEnDiciembre), UserId)
        Catch
            ActividadesInsert = 0
        End Try
    End Function
    Public Function ActividadesDelete(ByVal ActividadesId As Long, ByVal AccionesCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (Actividades) "
        strUpdate = strUpdate & "WHERE (Actividades.ActividadesId = " & ActividadesId & ") "
        Try
            ActividadesDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & AccionesCodigo, ActividadesId, "Actividades", "")
        Catch
            ActividadesDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & AccionesCodigo, ActividadesId, "Actividades", "")
        End Try
    End Function
    Public Function ActividadesPorAccion(ByVal AccionesCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "SELECT Count(*) as Total "
        sSQL = sSQL & "FROM Actividades Where AccionesCodigo = '" & AccionesCodigo & "'"
        ActividadesPorAccion = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ActividadesPorAccion = CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            ActividadesPorAccion = 0
        End Try
    End Function
    Public Function LeerUsuariosCodigoPorActividad(ByVal ActividadesId As String, ByRef TablaUsuariosCodigo() As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Usuarios.UsuariosCodigo "
        sSQL = sSQL & "FROM Usuarios INNER JOIN UsuariosPorActividad ON Usuarios.UsuariosId = UsuariosPorActividad.UsuariosId "
        sSQL = sSQL & "WHERE (((UsuariosPorActividad.ActividadesId)=" & ActividadesId & "))"

        LeerUsuariosCodigoPorActividad = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TablaUsuariosCodigo(LeerUsuariosCodigoPorActividad) = CStr(dtr("UsuariosCodigo").ToString)
                LeerUsuariosCodigoPorActividad = LeerUsuariosCodigoPorActividad + 1
            End While
            dtr.Close()
        Catch
            LeerUsuariosCodigoPorActividad = 0
        End Try
    End Function


End Class
