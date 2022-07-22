'------------------------------------------------------------
' Código generado por ZRISMART SF el 23-04-2011 13:17:56
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Tareas
    Public Function LeerTareas(ByVal TareasId As Long, ByRef TareasCodigo As String, ByRef TareasName As String, ByRef TareasDescription As String, ByRef PGGCodigo As String, ByRef AccionesCodigo As String, ByRef ActividadesSecuencia As Long, ByRef TareasMes As Long, ByRef TareasAno As String, ByRef TareasSecuencia As Long, ByRef UsuariosCodigo As String, ByRef TareasHH As Double, ByRef TareasUSD As Double, ByRef DiaMinimoInicio As Long, ByRef DiaMaximoTermino As Long, ByRef TareasDiaProgramado As Long, ByRef TareasTipo As String, ByRef TareasDiaRealTermino As Long, ByRef TareasHHConsumidas As Double, ByRef TareasUSDConsumidos As Double, ByRef EstadoTareasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasCodigo, TareasName, TareasDescription, PGGCodigo, AccionesCodigo, ActividadesSecuencia, TareasMes, TareasAno, TareasSecuencia, UsuariosCodigo, TareasHH, TareasUSD, DiaMinimoInicio, DiaMaximoTermino, TareasDiaProgramado, TareasTipo, TareasDiaRealTermino, TareasHHConsumidas, TareasUSDConsumidos, EstadoTareasCodigo "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasId = " & TareasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TareasCodigo = CStr(dtr("TareasCodigo").ToString)
                TareasName = CStr(dtr("TareasName").ToString)
                TareasDescription = CStr(dtr("TareasDescription").ToString)
                PGGCodigo = CStr(dtr("PGGCodigo").ToString)
                AccionesCodigo = CStr(dtr("AccionesCodigo").ToString)
                If Len(dtr("ActividadesSecuencia").ToString) = 0 Then
                    ActividadesSecuencia = 0
                Else
                    ActividadesSecuencia = CLng(dtr("ActividadesSecuencia").ToString)
                End If
                If Len(dtr("TareasMes").ToString) = 0 Then
                    TareasMes = 0
                Else
                    TareasMes = CLng(dtr("TareasMes").ToString)
                End If
                TareasAno = CStr(dtr("TareasAno").ToString)
                If Len(dtr("TareasSecuencia").ToString) = 0 Then
                    TareasSecuencia = 0
                Else
                    TareasSecuencia = CLng(dtr("TareasSecuencia").ToString)
                End If
                UsuariosCodigo = CStr(dtr("UsuariosCodigo").ToString)
                If Len(dtr("TareasHH").ToString) = 0 Then
                    TareasHH = 0
                Else
                    TareasHH = CDbl(dtr("TareasHH").ToString)
                End If
                If Len(dtr("TareasUSD").ToString) = 0 Then
                    TareasUSD = 0
                Else
                    TareasUSD = CDbl(dtr("TareasUSD").ToString)
                End If
                If Len(dtr("DiaMinimoInicio").ToString) = 0 Then
                    DiaMinimoInicio = 0
                Else
                    DiaMinimoInicio = CLng(dtr("DiaMinimoInicio").ToString)
                End If
                If Len(dtr("DiaMaximoTermino").ToString) = 0 Then
                    DiaMaximoTermino = 0
                Else
                    DiaMaximoTermino = CLng(dtr("DiaMaximoTermino").ToString)
                End If
                If Len(dtr("TareasDiaProgramado").ToString) = 0 Then
                    TareasDiaProgramado = 0
                Else
                    TareasDiaProgramado = CLng(dtr("TareasDiaProgramado").ToString)
                End If
                TareasTipo = CStr(dtr("TareasTipo").ToString)
                If Len(dtr("TareasDiaRealTermino").ToString) = 0 Then
                    TareasDiaRealTermino = 0
                Else
                    TareasDiaRealTermino = CLng(dtr("TareasDiaRealTermino").ToString)
                End If
                If Len(dtr("TareasHHConsumidas").ToString) = 0 Then
                    TareasHHConsumidas = 0
                Else
                    TareasHHConsumidas = CDbl(dtr("TareasHHConsumidas").ToString)
                End If
                If Len(dtr("TareasUSDConsumidos").ToString) = 0 Then
                    TareasUSDConsumidos = 0
                Else
                    TareasUSDConsumidos = CDbl(dtr("TareasUSDConsumidos").ToString)
                End If
                EstadoTareasCodigo = CStr(dtr("EstadoTareasCodigo").ToString)
            End While
            LeerTareas = True
            dtr.Close()
        Catch
            LeerTareas = False
        End Try
    End Function
    Public Function LeerTareasByName(ByRef TareasId As Long, ByVal TareasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasId "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasCodigo = '" & TareasCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TareasId = CLng(dtr("TareasId").ToString)
            End While
            LeerTareasByName = True
            dtr.Close()
        Catch
            LeerTareasByName = False
        End Try
    End Function
    Public Function IndicadorIsManual(ByVal TareasId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Indicadores.IndicadoresIsManual "
        sSQL = sSQL & "FROM (Tareas INNER JOIN Acciones ON Tareas.AccionesCodigo = Acciones.AccionesCodigo) INNER JOIN Indicadores ON Acciones.IndicadoresCodigo = Indicadores.IndicadoresCodigo "
        sSQL = sSQL & "WHERE(((Tareas.TareasId) = " & TareasId & "))"
        IndicadorIsManual = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                IndicadorIsManual = CBool(dtr("IndicadoresIsManual").ToString)
            End While
            dtr.Close()
        Catch
            IndicadorIsManual = False
        End Try
    End Function
    Public Function LeerTareasDescriptionByName(ByVal TareasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasName "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasCodigo = '" & TareasCodigo & "') "
        LeerTareasDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasDescriptionByName = CStr(dtr("TareasName").ToString)
            End While
            dtr.Close()
        Catch
            LeerTareasDescriptionByName = ""
        End Try
    End Function
    Public Function LeerTareasUsuariosCodigoByName(ByVal TareasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select UsuariosCodigo "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasCodigo = '" & TareasCodigo & "') "
        LeerTareasUsuariosCodigoByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasUsuariosCodigoByName = CStr(dtr("UsuariosCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerTareasUsuariosCodigoByName = ""
        End Try
    End Function
    Public Function LeerTareasUsuariosCodigoByTareasId(ByVal TareasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select UsuariosCodigo "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasId = " & TareasId & ") "
        LeerTareasUsuariosCodigoByTareasId = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasUsuariosCodigoByTareasId = CStr(dtr("UsuariosCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerTareasUsuariosCodigoByTareasId = ""
        End Try
    End Function

    Public Function LeerTareasMesAnoUsuarioByName(ByVal TareasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios

        sSQL = "Select UsuariosCodigo, TareasMes, TareasAno "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasCodigo = '" & TareasCodigo & "') "
        LeerTareasMesAnoUsuarioByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasMesAnoUsuarioByName = Lecturas.NombreMes(CLng(dtr("TareasMes").ToString)) & " de " & CLng(dtr("TareasAno").ToString) & ", " & Usuarios.LeerUsuariosDescriptionByName(CStr(dtr("UsuariosCodigo").ToString))
            End While
            dtr.Close()
        Catch
            LeerTareasMesAnoUsuarioByName = ""
        End Try
    End Function
    Public Function LeerTareasMesAnoByName(ByVal TareasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios

        sSQL = "Select TareasMes, TareasAno "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasCodigo = '" & TareasCodigo & "') "
        LeerTareasMesAnoByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasMesAnoByName = Lecturas.NombreMes(CLng(dtr("TareasMes").ToString)) & " de " & CLng(dtr("TareasAno").ToString)
            End While
            dtr.Close()
        Catch
            LeerTareasMesAnoByName = ""
        End Try
    End Function
    Public Function LeerEjecutorDeTareas(ByVal TareasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios

        sSQL = "Select TareasEjecutor "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasCodigo = '" & TareasCodigo & "') "
        LeerEjecutorDeTareas = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerEjecutorDeTareas = dtr("TareasEjecutor").ToString
            End While
            dtr.Close()
        Catch
            LeerEjecutorDeTareas = ""
        End Try
    End Function
    Public Function LeerCoordinadorDeTareas(ByVal TareasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios

        sSQL = "Select Programas.ProgramasCoordinadoPor As Coordinador "
        sSQL = sSQL & "FROM Tareas INNER JOIN Programas ON Tareas.PGGCodigo = Programas.ProgramasCodigo "
        sSQL = sSQL & "WHERE (((Tareas.TareasCodigo)='" & TareasCodigo & "'))"

        LeerCoordinadorDeTareas = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerCoordinadorDeTareas = dtr("Coordinador").ToString
            End While
            dtr.Close()
        Catch
            LeerCoordinadorDeTareas = ""
        End Try
    End Function
    Public Function LeerAccionesNameByTareasCodigo(ByVal TareasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios

        sSQL = "Select Acciones.AccionesCodigo+': '+Acciones.AccionesName As AccionesName "
        sSQL = sSQL & "FROM Tareas INNER JOIN Acciones ON Tareas.AccionesCodigo = Acciones.AccionesCodigo "
        sSQL = sSQL & "WHERE (((Tareas.TareasCodigo)='" & TareasCodigo & "'))"

        LeerAccionesNameByTareasCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerAccionesNameByTareasCodigo = dtr("AccionesName").ToString
            End While
            dtr.Close()
        Catch
            LeerAccionesNameByTareasCodigo = ""
        End Try
    End Function
    Public Function LeerAccionesNameByTareasId(ByVal TareasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios

        sSQL = "Select Acciones.AccionesCodigo+': '+Acciones.AccionesName As AccionesName "
        sSQL = sSQL & "FROM Tareas INNER JOIN Acciones ON Tareas.AccionesCodigo = Acciones.AccionesCodigo "
        sSQL = sSQL & "WHERE (((Tareas.TareasId)=" & TareasId & "))"

        LeerAccionesNameByTareasId = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerAccionesNameByTareasId = dtr("AccionesName").ToString
            End While
            dtr.Close()
        Catch
            LeerAccionesNameByTareasId = ""
        End Try
    End Function

    Public Function LeerResponsableSegunEstadoDeTareas(ByVal TareasCodigo As String, ByVal EstadoTareasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim Rol As String = ""
        Dim Tareas As New Tareas

        'sSQL = "Select EstadoTareas.EstadoTareasRolResponsable As Rol "
        'sSQL = sSQL & "FROM(EstadoTareas) "
        'sSQL = sSQL & "WHERE (((EstadoTareas.EstadoTareasName)= '" & EstadoTareasCodigo & "'))"

        sSQL = "SELECT Tareas.[TareasCodigo], Acciones.RolName As Rol, CarpetaJudicial.CarpetaJudicialProcurador As Procurador, CarpetaJudicial.CarpetaJudicialSecretaria As Secretaria, CarpetaJudicial.CarpetaJudicialSupervisor As Supervisor "
        sSQL = sSQL & "FROM (Tareas INNER JOIN Acciones ON Tareas.AccionesCodigo = Acciones.AccionesCodigo) INNER JOIN CarpetaJudicial ON Tareas.TareasId = CarpetaJudicial.TareasId "
        sSQL = sSQL & "WHERE (((Tareas.[TareasCodigo])='" & TareasCodigo & "'))"

        LeerResponsableSegunEstadoDeTareas = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Rol = dtr("Rol").ToString
                If Rol = "Supervisor" Then LeerResponsableSegunEstadoDeTareas = dtr("Supervisor").ToString
                If Rol = "Secretaria" Then LeerResponsableSegunEstadoDeTareas = dtr("Secretaria").ToString
                If Rol = "Procurador" Then LeerResponsableSegunEstadoDeTareas = dtr("Procurador").ToString
            End While
            dtr.Close()
        Catch
            LeerResponsableSegunEstadoDeTareas = ""
        End Try
    End Function
    Public Function LeerAPIsPorTarea(ByVal TareasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim i As Integer = 0

        sSQL = "Select API.APICodigo "
        sSQL = sSQL & "FROM (((Tareas INNER JOIN PGG ON Tareas.PGGCodigo = PGG.PGGCodigo) INNER JOIN Proyectos ON PGG.ProyectosCodigo = Proyectos.ProyectosCodigo) INNER JOIN APIPorProyecto ON Proyectos.ProyectosId = APIPorProyecto.ProyectosId) INNER JOIN API ON APIPorProyecto.APIId = API.APIId "
        sSQL = sSQL & "WHERE (((Tareas.TareasCodigo)='" & TareasCodigo & "'))"

        LeerAPIsPorTarea = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If i > 0 Then
                    LeerAPIsPorTarea = LeerAPIsPorTarea & " - " & CStr(dtr("APICodigo").ToString)
                Else
                    LeerAPIsPorTarea = LeerAPIsPorTarea & CStr(dtr("APICodigo").ToString)
                End If
                i = i + 1
            End While
            dtr.Close()
        Catch
            LeerAPIsPorTarea = ""
        End Try
    End Function
    Public Function LeerTareasProgramadas(ByVal Accion As String, ByVal Mes As Integer, ByVal PGGCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim i As Integer = 0

        If Accion <> "Todas" Then
            sSQL = "SELECT Count(Tareas.UsuariosCodigo) AS TareasProgramadas "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.AccionesCodigo, Tareas.TareasMes, Tareas.PGGCodigo "
            sSQL = sSQL & "HAVING (((Tareas.AccionesCodigo)='" & Accion & "') AND ((Tareas.TareasMes)=" & Mes & ") AND ((Tareas.PGGCodigo)='" & PGGCodigo & "'))"
        Else
            sSQL = "SELECT Count(Tareas.UsuariosCodigo) AS TareasProgramadas "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.TareasMes, Tareas.PGGCodigo "
            sSQL = sSQL & "HAVING (((Tareas.TareasMes)=" & Mes & ") AND ((Tareas.PGGCodigo)='" & PGGCodigo & "'))"
        End If

        LeerTareasProgramadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasProgramadas = CLng(dtr("TareasProgramadas").ToString)
            End While
            dtr.Close()
        Catch
            LeerTareasProgramadas = 0
        End Try
    End Function
    Public Function LeerTareasProgramadasAlMes(ByVal Accion As String, ByVal Mes As Integer, ByVal PGGCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim i As Integer = 0

        If Accion <> "Todas" Then
            sSQL = "SELECT Count(Tareas.UsuariosCodigo) AS TareasProgramadas "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.AccionesCodigo, Tareas.TareasMes, Tareas.PGGCodigo "
            sSQL = sSQL & "HAVING (((Tareas.AccionesCodigo)='" & Accion & "') AND ((Tareas.TareasMes) <= " & Mes & " ) AND ((Tareas.PGGCodigo)='" & PGGCodigo & "'))"
        Else
            sSQL = "SELECT Count(Tareas.UsuariosCodigo) AS TareasProgramadas "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.TareasMes, Tareas.PGGCodigo "
            sSQL = sSQL & "HAVING (((Tareas.TareasMes) <= " & Mes & " ) AND ((Tareas.PGGCodigo)='" & PGGCodigo & "'))"
        End If

        LeerTareasProgramadasAlMes = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasProgramadasAlMes = LeerTareasProgramadasAlMes + CLng(dtr("TareasProgramadas").ToString)
            End While
            dtr.Close()
        Catch
            LeerTareasProgramadasAlMes = 0
        End Try
    End Function
    Public Function LeerTotalTareasProgramadas(ByVal Accion As String, ByVal PGGCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim i As Integer = 0

        If Accion <> "Todas" Then
            sSQL = "SELECT Count(Tareas.UsuariosCodigo) AS TareasProgramadas "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.AccionesCodigo, Tareas.PGGCodigo "
            sSQL = sSQL & "HAVING (((Tareas.AccionesCodigo)='" & Accion & "') AND ((Tareas.PGGCodigo)='" & PGGCodigo & "'))"
        Else
            sSQL = "SELECT Count(Tareas.UsuariosCodigo) AS TareasProgramadas "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.PGGCodigo "
            sSQL = sSQL & "HAVING (((Tareas.PGGCodigo)='" & PGGCodigo & "'))"
        End If



        LeerTotalTareasProgramadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalTareasProgramadas = CLng(dtr("TareasProgramadas").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalTareasProgramadas = 0
        End Try
    End Function
    Public Function LeerTareasRealizadas(ByVal Accion As String, ByVal Mes As Integer, ByVal PGGCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim i As Integer = 0

        If Accion <> "Todas" Then
            sSQL = "SELECT Count(Tareas.UsuariosCodigo) AS TareasRealizadas "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.AccionesCodigo, Tareas.TareasMes, Tareas.PGGCodigo, Tareas.EstadoTareasCodigo "
            sSQL = sSQL & "HAVING (((Tareas.AccionesCodigo)='" & Accion & "') AND ((Tareas.TareasMes)=" & Mes & ") AND ((Tareas.PGGCodigo)='" & PGGCodigo & "') AND ((Tareas.EstadoTareasCodigo)='Cerrada'))"
        Else
            sSQL = "SELECT Count(Tareas.UsuariosCodigo) AS TareasRealizadas "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.TareasMes, Tareas.PGGCodigo, Tareas.EstadoTareasCodigo "
            sSQL = sSQL & "HAVING (((Tareas.TareasMes)=" & Mes & ") AND ((Tareas.PGGCodigo)='" & PGGCodigo & "') AND ((Tareas.EstadoTareasCodigo)='Cerrada'))"
        End If

        LeerTareasRealizadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasRealizadas = CLng(dtr("TareasRealizadas").ToString)
            End While
            dtr.Close()
        Catch
            LeerTareasRealizadas = 0
        End Try
    End Function
    Public Function LeerTareasRealizadasAlMes(ByVal Accion As String, ByVal Mes As Integer, ByVal PGGCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim i As Integer = 0

        If Accion <> "Todas" Then
            sSQL = "SELECT Count(Tareas.UsuariosCodigo) AS TareasRealizadas "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.AccionesCodigo, Tareas.TareasMes, Tareas.PGGCodigo, Tareas.EstadoTareasCodigo "
            sSQL = sSQL & "HAVING (((Tareas.AccionesCodigo)='" & Accion & "') AND ((Tareas.TareasMes) <= " & Mes & " ) AND ((Tareas.PGGCodigo)='" & PGGCodigo & "') AND ((Tareas.EstadoTareasCodigo)='Cerrada'))"
        Else
            sSQL = "SELECT Count(Tareas.UsuariosCodigo) AS TareasRealizadas "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.TareasMes, Tareas.PGGCodigo, Tareas.EstadoTareasCodigo "
            sSQL = sSQL & "HAVING (((Tareas.TareasMes) <= " & Mes & " ) AND ((Tareas.PGGCodigo)='" & PGGCodigo & "') AND ((Tareas.EstadoTareasCodigo)='Cerrada'))"
        End If

        LeerTareasRealizadasAlMes = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasRealizadasAlMes = LeerTareasRealizadasAlMes + CLng(dtr("TareasRealizadas").ToString)
            End While
            dtr.Close()
        Catch
            LeerTareasRealizadasAlMes = 0
        End Try
    End Function
    Public Function LeerTotalTareasRealizadas(ByVal Accion As String, ByVal PGGCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim i As Integer = 0

        If Accion <> "Todas" Then
            sSQL = "SELECT Count(Tareas.UsuariosCodigo) AS TareasRealizadas "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.AccionesCodigo, Tareas.PGGCodigo, Tareas.EstadoTareasCodigo "
            sSQL = sSQL & "HAVING (((Tareas.AccionesCodigo)='" & Accion & "') AND ((Tareas.PGGCodigo)='" & PGGCodigo & "') AND ((Tareas.EstadoTareasCodigo)='Cerrada'))"
        Else
            sSQL = "SELECT Count(Tareas.UsuariosCodigo) AS TareasRealizadas "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.PGGCodigo, Tareas.EstadoTareasCodigo "
            sSQL = sSQL & "HAVING (((Tareas.PGGCodigo)='" & PGGCodigo & "') AND ((Tareas.EstadoTareasCodigo)='Cerrada'))"
        End If



        LeerTotalTareasRealizadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalTareasRealizadas = CLng(dtr("TareasRealizadas").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalTareasRealizadas = 0
        End Try
    End Function
    Public Function LeerHHProgramadas(ByVal Accion As String, ByVal PGGCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim i As Integer = 0

        If Accion <> "Todas" Then
            sSQL = "SELECT Sum(Tareas.TareasHH) AS HHProgramadas "
            sSQL = sSQL & "FROM Tareas "
            sSQL = sSQL & "GROUP BY Tareas.AccionesCodigo, Tareas.PGGCodigo "
            sSQL = sSQL & "HAVING (((Tareas.AccionesCodigo)='" & Accion & "') AND ((Tareas.PGGCodigo)='" & PGGCodigo & "'))"
        Else
            sSQL = "SELECT Sum(Tareas.TareasHH) AS HHProgramadas "
            sSQL = sSQL & "FROM Tareas "
            sSQL = sSQL & "GROUP BY Tareas.PGGCodigo "
            sSQL = sSQL & "HAVING (((Tareas.PGGCodigo)='" & PGGCodigo & "'))"
        End If


        LeerHHProgramadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerHHProgramadas = CLng(dtr("HHProgramadas").ToString)
            End While
            dtr.Close()
        Catch
            LeerHHProgramadas = 0
        End Try
    End Function
    Public Function LeerHHConsumidas(ByVal Accion As String, ByVal PGGCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim i As Integer = 0

        If Accion <> "Todas" Then
            sSQL = "SELECT Sum(Tareas.TareasHHConsumidas) AS HHConsumidas "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.AccionesCodigo, Tareas.PGGCodigo "
            sSQL = sSQL & "HAVING (((Tareas.AccionesCodigo)='" & Accion & "') AND  ((Tareas.PGGCodigo)='" & PGGCodigo & "'))"
        Else
            sSQL = "SELECT Sum(Tareas.TareasHHConsumidas) AS HHConsumidas "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.PGGCodigo "
            sSQL = sSQL & "HAVING (((Tareas.PGGCodigo)='" & PGGCodigo & "'))"
        End If


        LeerHHConsumidas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerHHConsumidas = CLng(dtr("HHConsumidas").ToString)
            End While
            dtr.Close()
        Catch
            LeerHHConsumidas = 0
        End Try
    End Function
    Public Function LeerUSDProgramados(ByVal Accion As String, ByVal PGGCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim i As Integer = 0

        If Accion <> "Todas" Then
            sSQL = "SELECT Sum(Tareas.TareasUSD) AS USDProgramados "
            sSQL = sSQL & "FROM Tareas "
            sSQL = sSQL & "GROUP BY Tareas.AccionesCodigo, Tareas.PGGCodigo "
            sSQL = sSQL & "HAVING (((Tareas.AccionesCodigo)='" & Accion & "') AND ((Tareas.PGGCodigo)='" & PGGCodigo & "'))"
        Else
            sSQL = "SELECT Sum(Tareas.TareasUSD) AS USDProgramados "
            sSQL = sSQL & "FROM Tareas "
            sSQL = sSQL & "GROUP BY Tareas.PGGCodigo "
            sSQL = sSQL & "HAVING (((Tareas.PGGCodigo)='" & PGGCodigo & "'))"
        End If



        LeerUSDProgramados = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerUSDProgramados = CLng(dtr("USDProgramados").ToString)
            End While
            dtr.Close()
        Catch
            LeerUSDProgramados = 0
        End Try
    End Function
    Public Function LeerUSDConsumidos(ByVal Accion As String, ByVal PGGCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim i As Integer = 0

        If Accion <> "Todas" Then
            sSQL = "SELECT Sum(Tareas.TareasUSDConsumidos) AS USDConsumidos "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.AccionesCodigo, Tareas.PGGCodigo "
            sSQL = sSQL & "HAVING (((Tareas.AccionesCodigo)='" & Accion & "') AND  ((Tareas.PGGCodigo)='" & PGGCodigo & "'))"
        Else
            sSQL = "SELECT Sum(Tareas.TareasUSDConsumidos) AS USDConsumidos "
            sSQL = sSQL & "FROM(Tareas) "
            sSQL = sSQL & "GROUP BY Tareas.PGGCodigo "
            sSQL = sSQL & "HAVING (((Tareas.PGGCodigo)='" & PGGCodigo & "'))"
        End If


        LeerUSDConsumidos = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerUSDConsumidos = CLng(dtr("USDConsumidos").ToString)
            End While
            dtr.Close()
        Catch
            LeerUSDConsumidos = 0
        End Try
    End Function
    Public Function LeerMenuOptionsIdPorTarea(ByVal TareasCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios

        sSQL = "Select RequisitosPorAccion.MenuOptionsId "
        sSQL = sSQL & "FROM Tareas INNER JOIN (Acciones INNER JOIN RequisitosPorAccion ON Acciones.AccionesId = RequisitosPorAccion.AccionesId) ON Tareas.AccionesCodigo = Acciones.AccionesCodigo "
        sSQL = sSQL & "WHERE (((Tareas.TareasCodigo)='" & TareasCodigo & "'))"

        LeerMenuOptionsIdPorTarea = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerMenuOptionsIdPorTarea = CLng(dtr("MenuOptionsId").ToString)
            End While
            dtr.Close()
        Catch
            LeerMenuOptionsIdPorTarea = ""
        End Try
    End Function
    Public Function LeerDatosVinculo(ByVal MenuOptionsId As Long, ByVal DocumentosSGICodigo As String, ByRef Requisito As String, ByRef Ambito As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT APIDocumentosSGI.APIDocumentosSGICodigo As Requisito, APIDocumentosSGI.APIDocumentosSGIAmbito as Ambito "
        sSQL = sSQL & "FROM(APIDocumentosSGI) "
        sSQL = sSQL & "WHERE (((APIDocumentosSGI.DocumentosSGICodigo)='" & DocumentosSGICodigo & "') AND ((APIDocumentosSGI.MenuOptionsID)=" & MenuOptionsId & "))"

        Requisito = " - "
        Ambito = " - "
        LeerDatosVinculo = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Requisito = CStr(dtr("Requisito").ToString)
                Ambito = CStr(dtr("Ambito").ToString)
                LeerDatosVinculo = True
            End While
            dtr.Close()
        Catch
            LeerDatosVinculo = False
        End Try
    End Function
    Public Function LeerIndicadorIsManual(ByVal AccionesCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Indicadores.IndicadoresIsManual As IsManual "
        sSQL = sSQL & "FROM Acciones INNER JOIN Indicadores ON Acciones.IndicadoresCodigo = Indicadores.IndicadoresCodigo "
        sSQL = sSQL & "WHERE (((Acciones.AccionesCodigo)='" & AccionesCodigo & "'))"

        LeerIndicadorIsManual = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerIndicadorIsManual = CBool(dtr("IsManual").ToString)
            End While
            dtr.Close()
        Catch
            LeerIndicadorIsManual = False
        End Try
    End Function
    Public Function LeerMetaByAccion(ByVal AccionesCodigo As String, ByRef IsManual As Boolean, ByRef ValorMeta As Double, ByRef TextoIndicador As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Tareas As New Tareas

        IsManual = Tareas.LeerIndicadorIsManual(AccionesCodigo)

        sSQL = "Select Acciones.AccionesMetaIndicador As ValorMeta, AccionesObjetivoIndicador as TextoIndicador "
        sSQL = sSQL & "FROM Acciones "
        sSQL = sSQL & "WHERE (((Acciones.AccionesCodigo)='" & AccionesCodigo & "'))"

        LeerMetaByAccion = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ValorMeta = CDbl(dtr("ValorMeta").ToString)
                TextoIndicador = CStr(dtr("TextoIndicador").ToString)
            End While
            dtr.Close()
        Catch
            LeerMetaByAccion = False
        End Try
    End Function
    Public Function TareasUpdate(ByVal TareasId As Long, ByRef TareasCodigo As String, ByRef TareasName As String, ByRef TareasDescription As String, ByRef PGGCodigo As String, ByRef AccionesCodigo As String, ByRef ActividadesSecuencia As Long, ByRef TareasMes As Long, ByRef TareasAno As String, ByRef TareasSecuencia As Long, ByRef UsuariosCodigo As String, ByRef TareasHH As Double, ByRef TareasUSD As Double, ByRef DiaMinimoInicio As Long, ByRef DiaMaximoTermino As Long, ByRef TareasDiaProgramado As Long, ByRef TareasTipo As String, ByRef TareasDiaRealTermino As Long, ByRef TareasHHConsumidas As Double, ByRef TareasUSDConsumidos As Double, ByRef EstadoTareasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim EstadoTareas As New EstadoTareas
        Dim Usuarios As New Usuarios
        Dim t As Integer = 0

        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoActualDelaTarea(TareasId)
        Dim TareasLogActividad As String = EstadoTareasCodigo

        strUpdate = "UPDATE Tareas SET "
        strUpdate = strUpdate & "Tareas.TareasCodigo = '" & TareasCodigo & "', "
        strUpdate = strUpdate & "Tareas.TareasName = '" & TareasName & "', "
        strUpdate = strUpdate & "Tareas.TareasDescription = '" & TareasDescription & "', "
        strUpdate = strUpdate & "Tareas.PGGCodigo = '" & PGGCodigo & "', "
        strUpdate = strUpdate & "Tareas.AccionesCodigo = '" & AccionesCodigo & "', "
        strUpdate = strUpdate & "Tareas.ActividadesSecuencia = " & ActividadesSecuencia & ", "
        strUpdate = strUpdate & "Tareas.TareasMes = " & TareasMes & ", "
        strUpdate = strUpdate & "Tareas.TareasAno = '" & TareasAno & "', "
        strUpdate = strUpdate & "Tareas.TareasSecuencia = " & TareasSecuencia & ", "
        strUpdate = strUpdate & "Tareas.UsuariosCodigo = '" & UsuariosCodigo & "', "
        strUpdate = strUpdate & "Tareas.TareasHH = " & Replace(TareasHH, ",", ".") & ", "
        strUpdate = strUpdate & "Tareas.TareasUSD = " & Replace(TareasUSD, ",", ".") & ", "
        strUpdate = strUpdate & "Tareas.DiaMinimoInicio = " & DiaMinimoInicio & ", "
        strUpdate = strUpdate & "Tareas.DiaMaximoTermino = " & DiaMaximoTermino & ", "
        strUpdate = strUpdate & "Tareas.TareasDiaProgramado = " & TareasDiaProgramado & ", "
        strUpdate = strUpdate & "Tareas.TareasTipo = '" & TareasTipo & "', "
        strUpdate = strUpdate & "Tareas.TareasDiaRealTermino = " & TareasDiaRealTermino & ", "
        strUpdate = strUpdate & "Tareas.TareasHHConsumidas = " & Replace(TareasHHConsumidas, ",", ".") & ", "
        strUpdate = strUpdate & "Tareas.TareasUSDConsumidos = " & Replace(TareasUSDConsumidos, ",", ".") & ", "
        strUpdate = strUpdate & "Tareas.EstadoTareasCodigo = '" & EstadoTareasCodigo & "', "
        strUpdate = strUpdate & "Tareas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Tareas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Tareas.TareasId = " & TareasId
        Try
            TareasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & TareasCodigo, TareasId, "Tareas", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TareasCodigo, TareasId, "Tareas", "")
        End Try
    End Function
    Public Function TareasEjecutorUpdate(ByVal TareasId As Long, ByVal TareasCodigo As String, ByRef TareasEjecutor As String, ByVal AccionesCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim Tareas As New Tareas
        Dim Acciones As New Acciones
        Dim t As Integer = 0
        Dim b As Boolean
        Dim UserIdCodigo As String = ""
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim Dias As Double = Acciones.LeerDurationPorAccion(AccionesCodigo)
        Dim TareasLogRol As String = Acciones.LeerRolPorAccion(AccionesCodigo)
        Dim TareasLogActividad As String = TareasLogRol & ": " & TareasEjecutor & "; Usuario que Asigna: " & UserIdCodigo & "; Fecha Inicio: " & FormatDateTime(Now(), DateFormat.ShortDate) & "; Fecha Termino: " & FormatDateTime(DateAdd(DateInterval.Day, Dias, Now()))
        Dim FechaAsignacion As Date = Tareas.LeerFechaAsignacion(TareasId)



        strUpdate = "UPDATE Tareas SET "
        strUpdate = strUpdate & "Tareas.TareasEjecutor = '" & TareasEjecutor & "', "
        If AccionesCodigo = "01.02" Then  'Es la primera acción y la fecha de término se calcula a partir de la fecha de asignación
            strUpdate = strUpdate & "Tareas.TareasFechaInicio = '" & AccionesABM.DateTransform(FechaAsignacion) & "', "
            strUpdate = strUpdate & "Tareas.TareasFechaTermino = '" & AccionesABM.DateTransform(DateAdd(DateInterval.Day, Dias, FechaAsignacion)) & "', "
            TareasLogActividad = TareasLogRol & ": " & TareasEjecutor & "; Usuario que Asigna: " & UserIdCodigo & "; Fecha Inicio: " & FormatDateTime(FechaAsignacion, DateFormat.ShortDate) & "; Fecha Termino: " & FormatDateTime(DateAdd(DateInterval.Day, Dias, FechaAsignacion))
        Else
            strUpdate = strUpdate & "Tareas.TareasFechaInicio = '" & AccionesABM.DateTransform(Now()) & "', "
            strUpdate = strUpdate & "Tareas.TareasFechaTermino = '" & AccionesABM.DateTransform(DateAdd(DateInterval.Day, Dias, Now())) & "', "
            TareasLogActividad = TareasLogRol & ": " & TareasEjecutor & "; Usuario que Asigna: " & UserIdCodigo & "; Fecha Inicio: " & FormatDateTime(Now(), DateFormat.ShortDate) & "; Fecha Termino: " & FormatDateTime(DateAdd(DateInterval.Day, Dias, Now()))
        End If
        strUpdate = strUpdate & "Tareas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Tareas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Tareas.TareasCodigo = '" & TareasCodigo & "'"
        Try
            TareasEjecutorUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & TareasCodigo, TareasId, "Tareas", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, TareasEjecutor, TareasLogRol, TareasLogActividad)
        Catch
            TareasEjecutorUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TareasCodigo, TareasId, "Tareas", "")
        End Try
    End Function

    Public Function LeerFechaAsignacion(ByVal TareasId As Long) As Date
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Tareas As New Tareas

        sSQL = "Select CarpetaJudicial.CarpetaJudicialFechaAsignacion As Fecha "
        sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.TareasId = CarpetaJudicial.TareasId "
        sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"

        LeerFechaAsignacion = "01/01/01"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If Len(dtr("Fecha").ToString) = 0 Then
                    LeerFechaAsignacion = "01/01/01"
                Else
                    LeerFechaAsignacion = CDate(dtr("Fecha").ToString)
                End If
            End While
            dtr.Close()
        Catch
            LeerFechaAsignacion = "01/01/01"
        End Try
    End Function
    Public Function LeerFechaEntroEnMora(ByVal TareasId As Long) As Date
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Tareas As New Tareas

        sSQL = "Select CarpetaJudicial.CarpetaJudicialFechaEntroEnMora As Fecha "
        sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.TareasId = CarpetaJudicial.TareasId "
        sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"

        LeerFechaEntroEnMora = "01/01/01"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If Len(dtr("Fecha").ToString) = 0 Then
                    LeerFechaEntroEnMora = "01/01/01"
                Else
                    LeerFechaEntroEnMora = CDate(dtr("Fecha").ToString)
                End If
            End While
            dtr.Close()
        Catch
            LeerFechaEntroEnMora = "01/01/01"
        End Try
    End Function

    Public Function TareasResponsableUpdate(ByVal TareasId As Long, ByVal TareasCodigo As String, ByRef UsuariosCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Usuarios As New Usuarios
        Dim Acciones As New Acciones
        Dim EstadoTareas As New EstadoTareas
        Dim Tareas As New Tareas
        Dim t As Integer = 0
        Dim b As Boolean
        Dim UserIdCodigo As String = ""
        Dim CarpetaJudicialCodigo As String = ""
        Dim AccionesCodigo As String = ""

        b = Tareas.LeerTareasPGGAccion(TareasId, CarpetaJudicialCodigo, AccionesCodigo)
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = Acciones.LeerRolPorAccion(AccionesCodigo)
        Dim TareasLogActividad As String = "La Tarea queda en estado: " & EstadoTareasCodigo & ", quedando como responsable: " & Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)

        strUpdate = "UPDATE Tareas SET "
        strUpdate = strUpdate & "Tareas.UsuariosCodigo = '" & UsuariosCodigo & "', "
        strUpdate = strUpdate & "Tareas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Tareas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Tareas.TareasCodigo = '" & TareasCodigo & "'"

        Try
            TareasResponsableUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & TareasCodigo, TareasId, "Tareas", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasResponsableUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TareasCodigo, TareasId, "Tareas", "")
        End Try

    End Function
    Public Function EstadoTareasCodigoUpdate(ByVal TareasId As Long, ByVal TareasCodigo As String, ByVal EstadoTareasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim Tareas As New Tareas
        Dim t As Integer = 0
        Dim UsuariosCodigo As String = ""

        strUpdate = "UPDATE Tareas SET "
        strUpdate = strUpdate & "Tareas.EstadoTareasCodigo = '" & EstadoTareasCodigo & "', "
        strUpdate = strUpdate & "Tareas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Tareas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Tareas.TareasId = " & TareasId

        Try
            EstadoTareasCodigoUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & TareasCodigo, TareasId, "Tareas", "")
        Catch
            EstadoTareasCodigoUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TareasCodigo, TareasId, "Tareas", "")
        End Try
        UsuariosCodigo = Tareas.LeerResponsableSegunEstadoDeTareas(TareasCodigo, EstadoTareasCodigo)
        t = Tareas.TareasResponsableUpdate(TareasId, TareasCodigo, UsuariosCodigo, UserId)
    End Function
    Public Function TareasInsert(ByRef TareasId As Long, ByRef TareasCodigo As String, ByRef TareasName As String, ByRef TareasDescription As String, ByRef PGGCodigo As String, ByRef AccionesCodigo As String, ByRef ActividadesSecuencia As Long, ByRef TareasMes As Long, ByRef TareasAno As String, ByRef TareasSecuencia As Long, ByRef UsuariosCodigo As String, ByRef TareasHH As Double, ByRef TareasUSD As Double, ByRef DiaMinimoInicio As Long, ByRef DiaMaximoTermino As Long, ByRef TareasDiaProgramado As Long, ByRef TareasTipo As String, ByRef TareasDiaRealTermino As Long, ByRef TareasHHConsumidas As Double, ByRef TareasUSDConsumidos As Double, ByRef EstadoTareasCodigo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Tareas As New Tareas
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = TareasCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("TareasId", "TareasCodigo", "Tareas", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("TareasId", "TareasCodigo", "Tareas", MasterName, CLng(UserId), MasterId)
            End If
            TareasInsert = Tareas.TareasUpdate(MasterId, CStr(TareasCodigo), CStr(TareasName), CStr(TareasDescription), CStr(PGGCodigo), CStr(AccionesCodigo), CLng(ActividadesSecuencia), CLng(TareasMes), CStr(TareasAno), CLng(TareasSecuencia), CStr(UsuariosCodigo), CDbl(TareasHH), CDbl(TareasUSD), CLng(DiaMinimoInicio), CLng(DiaMaximoTermino), CLng(TareasDiaProgramado), CStr(TareasTipo), CLng(TareasDiaRealTermino), CDbl(TareasHHConsumidas), CDbl(TareasUSDConsumidos), CStr(EstadoTareasCodigo), UserId)
            TareasId = MasterId
        Catch
            TareasInsert = 0
        End Try
    End Function
    Public Function LeerTareasPGGAccion(ByVal TareasId As Long, ByRef PGGCodigo As String, ByRef AccionesCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PGGCodigo, AccionesCodigo "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasId = " & TareasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                PGGCodigo = CStr(dtr("PGGCodigo").ToString)
                AccionesCodigo = CStr(dtr("AccionesCodigo").ToString)
            End While
            LeerTareasPGGAccion = True
            dtr.Close()
        Catch
            LeerTareasPGGAccion = False
        End Try
    End Function
    Public Function LeerTareasPGGCodigo(ByVal TareasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PGGCodigo "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasCodigo = '" & TareasCodigo & "') "
        LeerTareasPGGCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasPGGCodigo = CStr(dtr("PGGCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerTareasPGGCodigo = ""
        End Try
    End Function



    Public Function LeerEjecutorRolByTareasId(ByVal TareasId As Long, ByRef Ejecutor As String, ByRef Rol As String, ByRef TareasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "SELECT Tareas.TareasCodigo as Codigo, Tareas.UsuariosCodigo As Ejecutor, Acciones.RolName as Rol "
        sSQL = sSQL & "FROM Tareas INNER JOIN Acciones ON Tareas.AccionesCodigo = Acciones.AccionesCodigo "
        sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Ejecutor = CStr(dtr("Ejecutor").ToString)
                Rol = CStr(dtr("Rol").ToString)
                TareasCodigo = CStr(dtr("Codigo").ToString)
            End While
            LeerEjecutorRolByTareasId = True
            dtr.Close()
        Catch
            LeerEjecutorRolByTareasId = False
        End Try
    End Function


    Public Function LeerEstadoTareasCodigo(ByVal TareasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EstadoTareasCodigo "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasId = " & TareasId & ") "
        LeerEstadoTareasCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerEstadoTareasCodigo = CStr(dtr("EstadoTareasCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerEstadoTareasCodigo = ""
        End Try
    End Function
    Public Function LeerFechaTarea(ByVal TareasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select Tareas.TareasAno AS Ano, Tareas.TareasMes AS Mes, Tareas.TareasDiaProgramado AS Dia "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasId = " & TareasId & ") "
        LeerFechaTarea = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerFechaTarea = CStr(dtr("Dia").ToString) & "-" & CStr(dtr("Mes").ToString) & "-" & CStr(dtr("Ano").ToString)
            End While
            dtr.Close()
        Catch
            LeerFechaTarea = ""
        End Try
    End Function
    Public Function LeerFechaEstadoTarea(ByVal TareasId As Long, ByRef Fecha As String, ByRef Estado As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select Tareas.TareasAno AS Ano, Tareas.TareasMes AS Mes, Tareas.TareasDiaProgramado AS Dia, Tareas.EstadoTareasCodigo as Estado "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasId = " & TareasId & ") "
        LeerFechaEstadoTarea = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Fecha = CStr(dtr("Dia").ToString) & "-" & CStr(dtr("Mes").ToString) & "-" & CStr(dtr("Ano").ToString)
                Estado = CStr(dtr("Estado").ToString)
                LeerFechaEstadoTarea = True
            End While
            dtr.Close()
        Catch
            LeerFechaEstadoTarea = False
        End Try
    End Function

    Public Function LeerTotalTareasPorTablasRelacionadas(ByVal TareasCodigo As String, ByVal TareasId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en un Programa Global de Gestión
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Tareas INNER JOIN TareasDocs ON Tareas.TareasCodigo = TareasDocs.TareasCodigo "
        sSQL = sSQL & "WHERE (((Tareas.TareasCodigo)= '" & TareasCodigo & "'))"
        LeerTotalTareasPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalTareasPorTablasRelacionadas = LeerTotalTareasPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalTareasPorTablasRelacionadas = 0
        End Try
        'Verifica si esta referenciada en una Actividad
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Tareas INNER JOIN TareasKPI ON Tareas.TareasCodigo = TareasKPI.TareasCodigo "
        sSQL = sSQL & "WHERE (((Tareas.TareasCodigo)='" & TareasCodigo & "'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalTareasPorTablasRelacionadas = LeerTotalTareasPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalTareasPorTablasRelacionadas = LeerTotalTareasPorTablasRelacionadas + 0
        End Try
    End Function
    Public Function TareasDelete(ByVal TareasId As Long, ByVal TareasCodigo As String, ByVal UserId As Long, ByRef Mensaje As String, ByVal MenuOptionsId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Tareas As New Tareas
        Dim Rol As New Rol

        ' Verificar si la tarea posee evidencias o KPI registrados
        '---------------------------------------------------------
        Total = Tareas.LeerTotalTareasPorTablasRelacionadas(TareasCodigo, TareasId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados a la Tarea " & TareasCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie la Tarea en las Evidencias y KPI, antes de eliminarla de la lista"
            TareasDelete = False
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
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), MenuOptionsId, "Elimina la Tarea: " & TareasCodigo, TareasId, "Tareas", "")
                TareasDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), Rol.LeerRolByUserId(UserId), MenuOptionsId, "Intento fallido de eliminar la Tarea: " & TareasCodigo, TareasId, "Tareas", "")
                TareasDelete = False
            End Try
        End If
    End Function
    Public Function LeerTareasCodigoById(ByVal TareasId As Long, ByRef TareasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasCodigo "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasId = " & TareasId & ") "
        LeerTareasCodigoById = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TareasCodigo = CStr(dtr("TareasCodigo").ToString)
                LeerTareasCodigoById = True
            End While
            dtr.Close()
        Catch
            LeerTareasCodigoById = False
        End Try
    End Function
    Public Function MostrarTareasPorMes(ByRef CodigoHTML As String, ByVal IsAuthorizedUser As Boolean, ByVal Codigo As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim strUpdate As String
        Dim Tareas As New Tareas
        Dim MesYAno As String = ""


        strUpdate = "SELECT Tareas.TareasAno, Tareas.TareasMes "
        strUpdate = strUpdate & "FROM Tareas "
        strUpdate = strUpdate & "WHERE(((Tareas.EstadoTareasCodigo) <> 'Cerrada')) "
        strUpdate = strUpdate & "GROUP BY Tareas.TareasAno, Tareas.TareasMes, Tareas.UsuariosCodigo "
        strUpdate = strUpdate & "HAVING (((Tareas.UsuariosCodigo)='" & Codigo & "'))"

        MostrarTareasPorMes = False

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                Select Case dtr("TareasMes").ToString
                    Case "1"
                        MesYAno = "Enero " & dtr("TareasAno").ToString
                    Case "2"
                        MesYAno = "Febrero " & dtr("TareasAno").ToString
                    Case "3"
                        MesYAno = "Marzo " & dtr("TareasAno").ToString
                    Case "4"
                        MesYAno = "Abril " & dtr("TareasAno").ToString
                    Case "5"
                        MesYAno = "Mayo " & dtr("TareasAno").ToString
                    Case "6"
                        MesYAno = "Junio " & dtr("TareasAno").ToString
                    Case "7"
                        MesYAno = "Julio " & dtr("TareasAno").ToString
                    Case "8"
                        MesYAno = "Agosto " & dtr("TareasAno").ToString
                    Case "9"
                        MesYAno = "Septiembre " & dtr("TareasAno").ToString
                    Case "10"
                        MesYAno = "Octubre " & dtr("TareasAno").ToString
                    Case "11"
                        MesYAno = "Noviembre " & dtr("TareasAno").ToString
                    Case "12"
                        MesYAno = "Diciembre " & dtr("TareasAno").ToString
                End Select
                CodigoHTML = CodigoHTML & "<div class=""AccordionPanel"">"
                CodigoHTML = CodigoHTML & "<div class=""AccordionPanelTab"">"
                CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td><h2>" & MesYAno & "</h2></td>"
                CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & dtr("TareasMes").ToString & dtr("TareasAno").ToString & "')"" /></td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "</table>"
                CodigoHTML = CodigoHTML & "</div>"
                CodigoHTML = CodigoHTML & "<a id=""" & "Dimension" & dtr("TareasMes").ToString & dtr("TareasAno").ToString & """ name=""" & "Dimension" & dtr("TareasMes").ToString & dtr("TareasAno").ToString & """></a><div id=""subgrilla" & dtr("TareasMes").ToString & dtr("TareasAno").ToString & """ class=""visible"">"
                CodigoHTML = CodigoHTML & Tareas.MostrarTareasPorPrograma(CLng(dtr("TareasMes").ToString), dtr("TareasAno").ToString, IsAuthorizedUser, Codigo)
                CodigoHTML = CodigoHTML & "</div>"
                CodigoHTML = CodigoHTML & "</div>"
                MostrarTareasPorMes = True
            End While
            dtr.Close()
        Catch
            MostrarTareasPorMes = False
        End Try

    End Function
    Public Function MostrarTareasPorPrograma(ByVal Mes As Long, ByVal Ano As String, ByVal IsAuthorizedUser As Boolean, ByVal Codigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim l As String = ""
        Dim Gerencias As New Gerencias
        Dim Programa As String = ""
        Dim Tareas As New Tareas
        Dim CarpetaJudicial As New CarpetaJudicial

        Dim FechaDeTarea As String = ""
        Dim EstadoTarea As String = ""
        Dim t As Boolean = False


        strUpdate = "SELECT Tareas.PGGCodigo As Programa, Tareas.TareasId As Id, Tareas.TareasName As Name, Tareas.TareasDiaProgramado As Vencimiento, CarpetaJudicial.CarpetaJudicialId "
        strUpdate = strUpdate & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.PGGCodigo = CarpetaJudicial.CarpetaJudicialCodigo "
        strUpdate = strUpdate & "WHERE (((Tareas.TareasAno)='" & Ano & "') AND ((Tareas.TareasMes)=" & Mes & ") AND ((Tareas.UsuariosCodigo)='" & Codigo & "') AND ((Tareas.EstadoTareasCodigo)<>'Cerrada')) "
        strUpdate = strUpdate & "ORDER BY Tareas.PGGCodigo"

        MostrarTareasPorPrograma = ""

        CodigoHTML = ""

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                If Programa = "" Then 'Primera pasada
                    Programa = dtr("Programa").ToString
                    'strboton = "<a href=""IndexSGI.aspx?PaginaWebName=Ficha de CarpetaJudicial&MenuOptionsId=425&Id=" & dtr("Id").ToString & """><img src=""img/editar.png"" alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" width=""12"" height=""12"" border=""0"" title=""Editar la Carpeta Judicial"" /></a>"


                    CodigoHTML = CodigoHTML & "<h3><a href=""IndexSGI.aspx?PaginaWebName=Ficha de CarpetaJudicial&MenuOptionsId=425&Id=" & dtr("CarpetaJudicialId").ToString & """><img src=""img/editar.png"" alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" width=""12"" height=""12"" border=""0"" title=""Editar la Carpeta Judicial"" /></a>" & CarpetaJudicial.LeerDeudorByCarpetaJudicialCodigo(dtr("Programa").ToString) & "</h3>"
                    CodigoHTML = CodigoHTML & "<table class=""tareas"">"
                Else  'Segundas pasadas
                    If Programa <> dtr("Programa").ToString Then
                        Programa = dtr("Programa").ToString
                        CodigoHTML = CodigoHTML & "</table>"
                        CodigoHTML = CodigoHTML & "<h3><a href=""IndexSGI.aspx?PaginaWebName=Ficha de CarpetaJudicial&MenuOptionsId=425&Id=" & dtr("CarpetaJudicialId").ToString & """><img src=""img/editar.png"" alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" width=""12"" height=""12"" border=""0"" title=""Editar la Carpeta Judicial"" /></a>" & CarpetaJudicial.LeerDeudorByCarpetaJudicialCodigo(dtr("Programa").ToString) & "</h3>"
                        CodigoHTML = CodigoHTML & "<table class=""tareas"">"
                    End If
                End If

                Dim FechaTareas As Date = CDate(Tareas.LeerFechaTarea(CLng(dtr("Id"))))
                t = Tareas.LeerFechaEstadoTarea(CLng(dtr("Id")), FechaDeTarea, EstadoTarea)
                FechaTareas = CDate(FechaDeTarea)

                Dim MesTarea As String = Month(FechaTareas)
                Dim DeltaFecha As Integer = DateDiff(DateInterval.Day, Now, FechaTareas)
                Dim NumeroMesEnCurso As Integer = System.DateTime.Today.Month
                ' No solo debemos comparar el mes sino también el año
                Dim AnoEnCurso As Integer = System.DateTime.Today.Year

                'l = "<img src=""img/editar.png"" alt=""?"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Agregar un Comentario"" onclick=""verModalMensaje('GestionCarpetaJudicial.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "')"" />"
                'l = l & "<img src=""img/editar.png"" alt=""?"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Editar una Tarea"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" />"

                CodigoHTML = CodigoHTML & "<tr class=""alt""  >"
                If DeltaFecha <= 5 Then 'La Tarea se encuentra o próxima a su fecha o esta vencida
                    ' Fondo Rojo
                    'l = l & " <a href=""IndexSGI.aspx?PaginaWebName=Ficha de Tareas&MenuOptionsId=422&Id=" & dtr("Id").ToString & """><img src=""img/tareas_circ_rojo.png"" alt=""Tarea Atrasada"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" /></a>" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                    l = "<img src=""img/tareas_circ_rojo.png"" alt=""Tarea Atrasada"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" />" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                End If
                If DeltaFecha > 6 And DeltaFecha <= 15 Then 'La Tarea se encuentra en fecha de ejecución, ya que estamos filtrando las tareas terminadas
                    ' Fondo Amarillo: Warning
                    'l = l & " <a href=""IndexSGI.aspx?PaginaWebName=Ficha de Tareas&MenuOptionsId=422&Id=" & dtr("Id").ToString & """><img src=""img/tareas_circ_amarillo.png"" alt=""Tarea Próxima a vencer"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" /></a>" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                    l = "<img src=""img/tareas_circ_amarillo.png"" alt=""Tarea Próxima a vencer"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" />" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                End If
                If DeltaFecha > 16 And DeltaFecha <= 30 Then 'La Tarea es para un mes subsiguiente al actual
                    ' Fondo de color verde
                    'l = l & " <a href=""IndexSGI.aspx?PaginaWebName=Ficha de Tareas&MenuOptionsId=422&Id=" & dtr("Id").ToString & """><img src=""img/tareas_circ_verde.png"" alt=""Tarea a tiempo"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" /></a>" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                    l = "<img src=""img/tareas_circ_verde.png"" alt=""Tarea a tiempo"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" />" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                End If
                If DeltaFecha > 30 Then
                    ' Fondo del color verde
                    'l = l & " <a href=""IndexSGI.aspx?PaginaWebName=Ficha de Tareas&MenuOptionsId=422&Id=" & dtr("Id").ToString & """><img src=""img/tareas_circ_verde.png"" alt=""Tarea a tiempo"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" /></a>" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                    l = "<img src=""img/tareas_circ_verde.png"" alt=""Tarea a tiempo"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" />" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                End If
                CodigoHTML = CodigoHTML & "<td>" & l & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
            End While

            dtr.Close()
        Catch

        End Try
        If CodigoHTML <> "" Then
            CodigoHTML = CodigoHTML & "</table>"
        Else
            CodigoHTML = "<h3>No presenta tareas pendientes en este mes</h3>"
        End If

        MostrarTareasPorPrograma = CodigoHTML
    End Function

    Public Function MostrarTareasPendientesPorUsuario(ByVal Codigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim l As String = ""
        Dim Gerencias As New Gerencias
        Dim Programa As String = ""
        Dim Tareas As New Tareas
        Dim CarpetaJudicial As New CarpetaJudicial

        Dim FechaDeTarea As String = ""
        Dim EstadoTarea As String = ""
        Dim t As Boolean = False

        'strUpdate = "SELECT Tareas.PGGCodigo As Programa, Tareas.TareasId As Id, Tareas.TareasName As Name, Tareas.TareasDiaProgramado As Vencimiento "
        'strUpdate = strUpdate & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.PGGCodigo = CarpetaJudicial.CarpetaJudicialCodigo "
        'strUpdate = strUpdate & "WHERE (((Tareas.TareasAno)='" & Ano & "') AND ((Tareas.TareasMes)=" & Mes & ") AND ((Tareas.UsuariosCodigo)='" & Codigo & "') AND ((Tareas.EstadoTareasCodigo)<>'Cerrada')) "
        'strUpdate = strUpdate & "ORDER BY Tareas.PGGCodigo"

        strUpdate = "SELECT Tareas.PGGCodigo As Programa, Tareas.TareasId As Id, Tareas.TareasName As Name, Tareas.TareasDiaProgramado As Vencimiento, CarpetaJudicial.CarpetaJudicialId "
        strUpdate = strUpdate & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.PGGCodigo = CarpetaJudicial.CarpetaJudicialCodigo "
        strUpdate = strUpdate & "WHERE (((Tareas.UsuariosCodigo)='" & Codigo & "') AND ((Tareas.EstadoTareasCodigo)<>'Cerrada')) "
        strUpdate = strUpdate & "ORDER BY Tareas.PGGCodigo"

        MostrarTareasPendientesPorUsuario = ""

        CodigoHTML = "<h3>No tiene tareas pendientes</h3><table class=""tareas"">"

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                If Programa = "" Then 'Primera pasada
                    Programa = dtr("Programa").ToString
                    CodigoHTML = "<h3>" & CarpetaJudicial.LeerDeudorByCarpetaJudicialCodigo(dtr("Programa").ToString) & "</h3>"
                    CodigoHTML = CodigoHTML & "<table class=""tareas"">"
                Else  'Segundas pasadas
                    If Programa <> dtr("Programa").ToString Then
                        Programa = dtr("Programa").ToString
                        CodigoHTML = CodigoHTML & "</table>"
                        CodigoHTML = CodigoHTML & "<h3>" & CarpetaJudicial.LeerDeudorByCarpetaJudicialCodigo(dtr("Programa").ToString) & "</h3>"
                        CodigoHTML = CodigoHTML & "<table class=""tareas"">"
                    End If
                End If

                Dim FechaTareas As Date = CDate(Tareas.LeerFechaTarea(CLng(dtr("Id"))))
                t = Tareas.LeerFechaEstadoTarea(CLng(dtr("Id")), FechaDeTarea, EstadoTarea)
                FechaTareas = CDate(FechaDeTarea)

                Dim MesTarea As String = Month(FechaTareas)
                Dim DeltaFecha As Integer = DateDiff(DateInterval.Day, Now, FechaTareas)
                Dim NumeroMesEnCurso As Integer = System.DateTime.Today.Month
                ' No solo debemos comparar el mes sino también el año
                Dim AnoEnCurso As Integer = System.DateTime.Today.Year


                CodigoHTML = CodigoHTML & "<tr class=""alt""  >"

                If DeltaFecha <= 5 Then 'La Tarea se encuentra o próxima a su fecha o esta vencida
                    ' Fondo Rojo
                    'l = l & " <a href=""IndexSGI.aspx?PaginaWebName=Ficha de Tareas&MenuOptionsId=422&Id=" & dtr("Id").ToString & """><img src=""img/tareas_circ_rojo.png"" alt=""Tarea Atrasada"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" /></a>" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                    l = "<img src=""img/tareas_circ_rojo.png"" alt=""Tarea Atrasada"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" />" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                End If
                If DeltaFecha > 6 And DeltaFecha <= 15 Then 'La Tarea se encuentra en fecha de ejecución, ya que estamos filtrando las tareas terminadas
                    ' Fondo Amarillo: Warning
                    'l = l & " <a href=""IndexSGI.aspx?PaginaWebName=Ficha de Tareas&MenuOptionsId=422&Id=" & dtr("Id").ToString & """><img src=""img/tareas_circ_amarillo.png"" alt=""Tarea Próxima a vencer"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" /></a>" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                    l = "<img src=""img/tareas_circ_amarillo.png"" alt=""Tarea Próxima a vencer"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" />" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                End If
                If DeltaFecha > 16 And DeltaFecha <= 30 Then 'La Tarea es para un mes subsiguiente al actual
                    ' Fondo de color verde
                    'l = l & " <a href=""IndexSGI.aspx?PaginaWebName=Ficha de Tareas&MenuOptionsId=422&Id=" & dtr("Id").ToString & """><img src=""img/tareas_circ_verde.png"" alt=""Tarea a tiempo"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" /></a>" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                    l = "<img src=""img/tareas_circ_verde.png"" alt=""Tarea a tiempo"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" />" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                End If
                If DeltaFecha > 30 Then
                    ' Fondo del color verde
                    'l = l & " <a href=""IndexSGI.aspx?PaginaWebName=Ficha de Tareas&MenuOptionsId=422&Id=" & dtr("Id").ToString & """><img src=""img/tareas_circ_verde.png"" alt=""Tarea a tiempo"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" /></a>" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                    l = "<img src=""img/tareas_circ_verde.png"" alt=""Tarea a tiempo"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" title=""Editar el registro de la tarea"" onclick=""verModalTarea('GestionTareas.aspx?Id=" & dtr("CarpetaJudicialId").ToString & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=422')"" />" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                End If


                'If DeltaFecha <= 5 Then 'La Tarea se encuentra o próxima a su fecha o esta vencida
                '    ' Fondo Rojo
                '    l = "<a href=""IndexSGI.aspx?PaginaWebName=Ficha de Tareas&MenuOptionsId=422&Id=" & dtr("Id").ToString & """><img src=""img/tareas_circ_rojo.png"" alt=""Tarea Atrasada"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" /></a>" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                'End If
                'If DeltaFecha > 6 And DeltaFecha <= 15 Then 'La Tarea se encuentra en fecha de ejecución, ya que estamos filtrando las tareas terminadas
                '    ' Fondo Amarillo: Warning
                '    l = "<a href=""IndexSGI.aspx?PaginaWebName=Ficha de Tareas&MenuOptionsId=422&Id=" & dtr("Id").ToString & """><img src=""img/tareas_circ_amarillo.png"" alt=""Tarea Próxima a vencer"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" /></a>" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                'End If
                'If DeltaFecha > 16 And DeltaFecha <= 30 Then 'La Tarea es para un mes subsiguiente al actual
                '    ' Fondo de color verde
                '    l = "<a href=""IndexSGI.aspx?PaginaWebName=Ficha de Tareas&MenuOptionsId=422&Id=" & dtr("Id").ToString & """><img src=""img/tareas_circ_verde.png"" alt=""Tarea a tiempo"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" /></a>" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                'End If
                'If DeltaFecha > 30 Then
                '    ' Fondo del color verde
                '    l = "<a href=""IndexSGI.aspx?PaginaWebName=Ficha de Tareas&MenuOptionsId=422&Id=" & dtr("Id").ToString & """><img src=""img/tareas_circ_verde.png"" alt=""Tarea a tiempo"" width=""12"" height=""12"" hspace=""5"" border=""0"" align=""left"" /></a>" & Mid(FechaDeTarea, 1, 10) & " " & dtr("Name")
                'End If
                CodigoHTML = CodigoHTML & "<td>" & l & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
            End While

            dtr.Close()
        Catch

        End Try
        CodigoHTML = CodigoHTML & "</table>"
        MostrarTareasPendientesPorUsuario = CodigoHTML
    End Function
    Public Function LeerProcuradorbyTareasId(ByVal TareasId As Long, ByRef Procurador As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'sSQL = "SELECT CarpetaJudicial.CarpetaJudicialProcurador As Procurador "
        'sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.TareasId = CarpetaJudicial.TareasId "
        'sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"


        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialProcurador As Procurador "
        sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.PGGCodigo = CarpetaJudicial.CarpetaJudicialCodigo "
        sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"


        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Procurador = CStr(dtr("Procurador").ToString)
            End While
            LeerProcuradorbyTareasId = True
            dtr.Close()
        Catch
            LeerProcuradorbyTareasId = False
        End Try
    End Function
    Public Function LeerMasAntecedentesbyTareasId(ByVal TareasId As Long, ByRef Profesion As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'sSQL = "SELECT CarpetaJudicial.CarpetaJudicialProfesion AS Profesion "
        'sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.TareasId = CarpetaJudicial.TareasId "
        'sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"

        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialProfesion AS Profesion "
        sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.PGGCodigo = CarpetaJudicial.CarpetaJudicialCodigo "
        sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Profesion = CStr(dtr("Profesion").ToString)
            End While
            LeerMasAntecedentesbyTareasId = True
            dtr.Close()
        Catch
            LeerMasAntecedentesbyTareasId = False
        End Try
    End Function

    Public Function LeerIdentificacionDeudorbyTareasId(ByVal TareasId As Long, ByRef Rut As String, ByRef Nombres As String, ByRef Apellidos As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'sSQL = "SELECT CarpetaJudicial.CarpetaJudicialRut As Rut, CarpetaJudicial.CarpetaJudicialNombres As Nombres, CarpetaJudicial.CarpetaJudicialApellidos As Apellidos "
        'sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.TareasId = CarpetaJudicial.TareasId "
        'sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"

        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialRut As Rut, CarpetaJudicial.CarpetaJudicialNombres As Nombres, CarpetaJudicial.CarpetaJudicialApellidos As Apellidos "
        sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.PGGCodigo = CarpetaJudicial.CarpetaJudicialCodigo "
        sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Rut = CStr(dtr("Rut").ToString)
                Nombres = CStr(dtr("Nombres").ToString)
                Apellidos = CStr(dtr("Apellidos").ToString)
            End While
            LeerIdentificacionDeudorbyTareasId = True
            dtr.Close()
        Catch
            LeerIdentificacionDeudorbyTareasId = False
        End Try
    End Function
    Public Function LeerJuzgadoRolbyTareasId(ByVal TareasId As Long, ByRef Rol As String, ByRef Fecha As Date, ByRef Juzgado As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'sSQL = "SELECT CarpetaJudicial.CarpetaJudicialRolJuicio As Rol, CarpetaJudicial.CarpetaJudicialFechaDistribucion As Fecha, CarpetaJudicial.CarpetaJudicialJuzgado As Juzgado "
        'sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.TareasId = CarpetaJudicial.TareasId "
        'sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"

        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialRolJuicio As Rol, CarpetaJudicial.CarpetaJudicialFechaDistribucion As Fecha, CarpetaJudicial.CarpetaJudicialJuzgado As Juzgado "
        sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.PGGCodigo = CarpetaJudicial.CarpetaJudicialCodigo "
        sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"

        Rol = ""
        Fecha = "01/01/01"
        Juzgado = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Rol = CStr(dtr("Rol").ToString)
                Juzgado = CStr(dtr("Juzgado").ToString)
                If Len(dtr("Fecha").ToString) = 0 Then
                    Fecha = "01/01/01"
                Else
                    Fecha = CDate(dtr("Fecha").ToString)
                End If

            End While
            LeerJuzgadoRolbyTareasId = True
            dtr.Close()
        Catch
            LeerJuzgadoRolbyTareasId = False
        End Try
    End Function
    Public Function LeerFechaNotificacionbyTareasId(ByVal TareasId As Long, ByRef Fecha As Date, ByRef Comuna As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'sSQL = "SELECT CarpetaJudicial.CarpetaJudicialFechaNotificacion As Fecha, CarpetaJudicial.CarpetaJudicialComunaNotificacion As Comuna "
        'sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.TareasId = CarpetaJudicial.TareasId "
        'sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"

        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialFechaNotificacion As Fecha, CarpetaJudicial.CarpetaJudicialComunaNotificacion As Comuna "
        sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.PGGCodigo = CarpetaJudicial.CarpetaJudicialCodigo "
        sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"

        Fecha = "01/01/01"
        Comuna = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Comuna = CStr(dtr("Comuna").ToString)
                If Len(dtr("Fecha").ToString) = 0 Then
                    Fecha = "01/01/01"
                Else
                    Fecha = CDate(dtr("Fecha").ToString)
                End If

            End While
            LeerFechaNotificacionbyTareasId = True
            dtr.Close()
        Catch
            LeerFechaNotificacionbyTareasId = False
        End Try
    End Function
    Public Function LeerFechaPresentacionbyTareasId(ByVal TareasId As Long, ByRef Fecha As Date) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'sSQL = "SELECT CarpetaJudicial.CarpetaJudicialFechaPresentacion As Fecha "
        'sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.TareasId = CarpetaJudicial.TareasId "
        'sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"

        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialFechaPresentacion As Fecha "
        sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.PGGCodigo = CarpetaJudicial.CarpetaJudicialCodigo "
        sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"


        Fecha = "01/01/01"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If Len(dtr("Fecha").ToString) = 0 Then
                    Fecha = "01/01/01"
                Else
                    Fecha = CDate(dtr("Fecha").ToString)
                End If

            End While
            LeerFechaPresentacionbyTareasId = True
            dtr.Close()
        Catch
            LeerFechaPresentacionbyTareasId = False
        End Try
    End Function


    Public Function LeerCarpetaJudicialIdbyTareasId(ByVal TareasId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'sSQL = "SELECT CarpetaJudicial.CarpetaJudicialId As Id "
        'sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.TareasId = CarpetaJudicial.TareasId "
        'sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"

        sSQL = "SELECT CarpetaJudicial.CarpetaJudicialId As Id "
        sSQL = sSQL & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.PGGCodigo = CarpetaJudicial.CarpetaJudicialCodigo "
        sSQL = sSQL & "WHERE (((Tareas.[TareasId])=" & TareasId & "))"

        LeerCarpetaJudicialIdbyTareasId = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerCarpetaJudicialIdbyTareasId = CLng(dtr("Id").ToString)
            End While
            dtr.Close()
        Catch
            LeerCarpetaJudicialIdbyTareasId = 0
        End Try
    End Function

    Public Function ListarDatosDelDeudorPorTareasId(ByVal TareasId As Long, ByVal CarpetaJudicialCodigo As String, Optional ByVal Clase As String = "invisible", Optional ByVal Formato As String = "CodigoHTML") As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Dim Totales As Double = 0

        strUpdate = "SELECT CarpetaJudicial.TipoProcesoName As Tipo, CarpetaJudicial.CarpetaJudicialRut As Rut, CarpetaJudicial.CarpetaJudicialNombres As Nombres, CarpetaJudicial.CarpetaJudicialApellidos As Apellidos, CarpetaJudicial.CarpetaJudicialRolJuicio As Rol, CarpetaJudicial.CarpetaJudicialJuzgado As Juzgado, CarpetaJudicial.CarpetaJudicialNroOperacion As Operacion, CarpetaJudicial.CarpetaJudicialCapInicial As Prestamo, CarpetaJudicial.CarpetaJudicialMoneda As Moneda, CarpetaJudicial.CarpetaJudicialFechaSuscripcion As FechaSuscripcion, CarpetaJudicial.CarpetaJudicialSaldoDeuda As Deuda, CarpetaJudicial.CarpetaJudicialFechaEntroEnMora As FechaMora, CarpetaJudicial.EstadoProcesoCodigo As EstadoProceso, CarpetaJudicial.CarpetaJudicialDireccion As Direccion, CarpetaJudicial.CarpetaJudicialComuna As Comuna, CarpetaJudicial.CarpetaJudicialCiudad As Ciudad, CarpetaJudicial.CarpetaJudicialCodigo As CodigoCarpeta "
        strUpdate = strUpdate & "FROM Tareas INNER JOIN CarpetaJudicial ON Tareas.PGGCodigo = CarpetaJudicial.CarpetaJudicialCodigo "
        strUpdate = strUpdate & "WHERE Tareas.TareasId=" & TareasId

        ListarDatosDelDeudorPorTareasId = ""


        If Formato = "CodigoHTML" Then
            CodigoHTML = "<p><h1>" & CarpetaJudicialCodigo & ": " & UCase(CarpetaJudicial.LeerApellidosDeudorByTareasId(TareasId)) & " CON SCOTIABANK </h1></p>"
            CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
            CodigoHTML = CodigoHTML & "<tr>"
            CodigoHTML = CodigoHTML & "<td><h1>" & "Antecedentes del deudor y del proceso judicial" & "</h1></td>"
            CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & "DatosDeudor" & "')"" /></td>"
            CodigoHTML = CodigoHTML & "</tr>"
            CodigoHTML = CodigoHTML & "</table>"
            CodigoHTML = CodigoHTML & "<div id=""subgrilla" & "DatosDeudor" & """ class=""" & Clase & """>"
        End If

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                If Formato = "CodigoHTML" Then
                    CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
                Else
                    CodigoHTML = CodigoHTML & "<table width=""660"" border=""1"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Verdana;font-size:8pt;border:1px solid #FFFFFF;"">"
                End If
                CodigoHTML = CodigoHTML & "<tr align=""left"">"
                CodigoHTML = CodigoHTML & "<th width=""75"" align=""left"">Tipo</th>"
                CodigoHTML = CodigoHTML & "<td width=""250"" colspan=""3"">" & dtr("Tipo").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<th width=""75"" align=""left"">Rut</th>"
                CodigoHTML = CodigoHTML & "<td width=""250"">" & dtr("Rut").ToString & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "<tr align=""left"">"
                CodigoHTML = CodigoHTML & "<th align=""left"">Nombres</th>"
                CodigoHTML = CodigoHTML & "<td width=""250"" colspan=""3"">" & dtr("Nombres").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<th align=""left"">Apellidos</th>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Apellidos").ToString & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "<tr align=""left"">"
                CodigoHTML = CodigoHTML & "<th align=""left"">Rol</th>"
                CodigoHTML = CodigoHTML & "<td width=""250"" colspan=""3"">" & dtr("Rol").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<th align=""left"">Juzgado</th>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("Juzgado").ToString & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "</table>"
                If Formato = "CodigoHTML" Then
                    CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
                Else
                    CodigoHTML = CodigoHTML & "<table width=""660"" border=""1"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Verdana;font-size:8pt;border:1px solid #FFFFFF;"">"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<th width=""150"" align=""left"" >Tipo Cr&eacute;dito</th>"
                CodigoHTML = CodigoHTML & "<th width=""50"" align=""left""># de Operaci&oacute;n</th>"
                CodigoHTML = CodigoHTML & "<th width=""150"" align=""right"" >Capital Inicial</th>"
                CodigoHTML = CodigoHTML & "<th width=""75"" align=""left"">Fecha Suscripci&oacute;n</th>"
                CodigoHTML = CodigoHTML & "<th width=""75"" align=""left"">Fecha Entro en Mora</th>"
                CodigoHTML = CodigoHTML & "<th width=""150"" align=""right"">Saldo Deuda</th>"
                CodigoHTML = CodigoHTML & CarpetaJudicialCreditos.ListarCreditos(dtr("CodigoCarpeta").ToString)
                CodigoHTML = CodigoHTML & "</tr></table>"
            End While
            dtr.Close()
        Catch

        End Try
        If Formato = "CodigoHTML" Then
            CodigoHTML = CodigoHTML & "</div>"
        End If
        ListarDatosDelDeudorPorTareasId = CodigoHTML
    End Function

    Public Function ListarDatosDelResponsablePorTareasId(ByVal TareasId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Dim i As Integer = 0

        strUpdate = "SELECT Tareas.[TareasId], Usuarios.UsuariosName As Responsable, Tareas.EstadoTareasCodigo As Estado, TareasLog.TareasLogTime As Fecha, Usuarios_1.UsuariosName As Mensajero, TareasLog.TareasLogActividad As Actividad "
        strUpdate = strUpdate & "FROM ((Tareas INNER JOIN Usuarios ON Tareas.UsuariosCodigo = Usuarios.UsuariosCodigo) INNER JOIN TareasLog ON Tareas.TareasCodigo = TareasLog.TareasCodigo) INNER JOIN Usuarios AS Usuarios_1 ON TareasLog.UsuariosCodigo = Usuarios_1.UsuariosCodigo "
        strUpdate = strUpdate & "WHERE(((Tareas.[TareasId]) = " & TareasId & ")) "
        strUpdate = strUpdate & "ORDER BY TareasLog.TareasLogTime DESC"

        ListarDatosDelResponsablePorTareasId = ""




        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    CodigoHTML = "<table class=""popup_tabla_de_datos_tareas"">"
                    CodigoHTML = CodigoHTML & "<tr align=""left"">"
                    CodigoHTML = CodigoHTML & "<th width=""75"" align=""left"">Responsable</th>"
                    CodigoHTML = CodigoHTML & "<td width=""250"">" & dtr("Responsable").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "<th width=""75"" align=""left"">Actividad</th>"
                    CodigoHTML = CodigoHTML & "<td width=""250"">" & dtr("Estado").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                    CodigoHTML = CodigoHTML & "</table>"
                    CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<th width=""125"" align=""right"">Fecha</th>"
                    CodigoHTML = CodigoHTML & "<th width=""150"">Responsable</th>"
                    CodigoHTML = CodigoHTML & "<th width=""375"">Actividad</th>"
                    CodigoHTML = CodigoHTML & "</tr>"
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td width=""125"" align=""right"">" & dtr("Fecha").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "<td width=""150"">" & dtr("Mensajero").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "<td width=""375"">" & dtr("Actividad").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                Else
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td width=""125"" align=""right"">" & dtr("Fecha").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "<td width=""150"">" & dtr("Mensajero").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "<td width=""375"">" & dtr("Actividad").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                End If



            End While
            dtr.Close()
        Catch

        End Try
        If CodigoHTML <> "" Then
            CodigoHTML = CodigoHTML & "</table>"
        End If
        ListarDatosDelResponsablePorTareasId = CodigoHTML
    End Function
    Public Function MostrarUltimasActividades(ByVal TareasId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim CodigoHTML As String = ""
        Dim dtr As IDataReader
        Dim strUpdate As String

        strUpdate = "SELECT Tareas.[TareasId], Usuarios.UsuariosName As Responsable, Tareas.EstadoTareasCodigo As Estado, TareasLog.TareasLogTime As Fecha, Usuarios_1.UsuariosName As Mensajero, TareasLog.TareasLogActividad As Actividad "
        strUpdate = strUpdate & "FROM ((Tareas INNER JOIN Usuarios ON Tareas.UsuariosCodigo = Usuarios.UsuariosCodigo) INNER JOIN TareasLog ON Tareas.TareasCodigo = TareasLog.TareasCodigo) INNER JOIN Usuarios AS Usuarios_1 ON TareasLog.UsuariosCodigo = Usuarios_1.UsuariosCodigo "
        strUpdate = strUpdate & "WHERE(((Tareas.[TareasId]) = " & TareasId & ")) "
        strUpdate = strUpdate & "ORDER BY TareasLog.TareasLogTime DESC"


        MostrarUltimasActividades = ""

        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""alertas"">"

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                MostrarUltimasActividades = MostrarUltimasActividades & "<tr><td width=""240"">" & dtr("Actividad").ToString & "<br /> (" & dtr("Mensajero").ToString & ")</td></tr>"
            End While
            dtr.Close()
        Catch
            MostrarUltimasActividades = ""
        End Try
        CodigoHTML = CodigoHTML & MostrarUltimasActividades & "</table>"
        MostrarUltimasActividades = CodigoHTML

    End Function




    Public Function LoadCondicionesTermino(ByRef rptFunciones As DropDownList, ByVal AccionesCodigo As String) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT PortalesName, PortalesId "
        sSQL = sSQL & "FROM Portales "
        sSQL = sSQL & "ORDER by PortalesSecuencia"

        sSQL = "Select TransicionAcciones.EstadoProcesoCodigo "
        sSQL = sSQL & "FROM TransicionAcciones INNER JOIN Acciones ON TransicionAcciones.CurrentStateId = Acciones.AccionesId "
        sSQL = sSQL & "WHERE Acciones.AccionesCodigo = '" & AccionesCodigo & "'"


        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptFunciones.DataSource = dtrFunciones
            rptFunciones.DataTextField = "EstadoProcesoCodigo"
            rptFunciones.DataValueField = "EstadoProcesoCodigo"
            rptFunciones.DataBind()
            rptFunciones.SelectedIndex = 0
            LoadCondicionesTermino = True
            dtrFunciones.Close()
        Catch
            LoadCondicionesTermino = False
        End Try
    End Function
    Public Function TareasCerrar(ByVal TareasId As Long, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Usuarios As New Usuarios
        Dim t As Boolean
        Dim Tareas As New Tareas
        Dim TareasCodigo As String = ""
        Dim UsuariosCodigo As String = ""
        Dim s As Boolean

        t = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UsuariosCodigo)
        Dim TareasLogRol As String = Usuarios.LeerRolNameByName(UsuariosCodigo)
        Dim TareasLogActividad As String = "Da por concluida la Tarea: " & TareasCodigo & " - " & Tareas.LeerEstadoTareasCodigo(TareasId)
        s = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)

        strUpdate = "UPDATE Tareas SET "
        strUpdate = strUpdate & "Tareas.EstadoTareasCodigo = 'Cerrada', "
        strUpdate = strUpdate & "Tareas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Tareas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Tareas.TareasId = " & TareasId
        Try
            TareasCerrar = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Da por concluida la Tarea: " & TareasCodigo, TareasId, "Tareas", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasCerrar = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de dar por concluida la tarea: " & TareasCodigo, TareasId, "Tareas", "")
        End Try
    End Function
    Public Function ListarTareasPendientes(ByVal Codigo As String) As String
        Dim CodigoHTML As String = ""
        Dim Tareas As New Tareas
        Dim t As Boolean

        CodigoHTML = CodigoHTML & "<div id=""Accordion1"" class=""Accordion"" tabindex=""0"" >"
        t = Tareas.MostrarTareasPorMes(CodigoHTML, True, Codigo)
        CodigoHTML = CodigoHTML & "</div>"
        ListarTareasPendientes = CodigoHTML
    End Function
    Public Function ColorDeLaTarea(ByVal CarpetaJudicialCodigo As String, Optional ByRef AccionesCodigo As String = "02.01.01", Optional ByRef ToolTipAtraso As String = "", Optional ByRef SemaforoImg As String = "", Optional ByRef SemaforoAlt As String = "") As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim strUpdate As String
        Dim l As String = ""
        Dim Tareas As New Tareas
        Dim FechaDeTarea As String = ""
        Dim EstadoTarea As String = ""
        Dim t As Boolean = False

        strUpdate = "SELECT Tareas.TareasId As Id, Tareas.AccionesCodigo As Codigo "
        strUpdate = strUpdate & "FROM Tareas "
        strUpdate = strUpdate & "WHERE (((Tareas.PGGCodigo)='" & CarpetaJudicialCodigo & "') AND ((Tareas.EstadoTareasCodigo)<>'Cerrada')) "

        ColorDeLaTarea = ""

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                AccionesCodigo = dtr("Codigo").ToString
                Dim FechaTareas As Date = CDate(Tareas.LeerFechaTarea(CLng(dtr("Id"))))
                t = Tareas.LeerFechaEstadoTarea(CLng(dtr("Id")), FechaDeTarea, EstadoTarea)
                FechaTareas = CDate(FechaDeTarea)

                Dim MesTarea As String = Month(FechaTareas)
                Dim DeltaFecha As Integer = DateDiff(DateInterval.Day, Now, FechaTareas)
                Dim NumeroMesEnCurso As Integer = System.DateTime.Today.Month
                ' No solo debemos comparar el mes sino también el año
                Dim AnoEnCurso As Integer = System.DateTime.Today.Year

                If DeltaFecha <= 5 Then 'La Tarea se encuentra o próxima a su fecha o esta vencida
                    l = "img/tareas_circ_rojo.png"
                End If
                If DeltaFecha > 6 And DeltaFecha <= 15 Then 'La Tarea se encuentra en fecha de ejecución, ya que estamos filtrando las tareas terminadas
                    l = "img/tareas_circ_amarillo.png"
                End If
                If DeltaFecha > 16 And DeltaFecha <= 30 Then 'La Tarea es para un mes subsiguiente al actual
                    l = "img/tareas_circ_verde.png"
                End If
                If DeltaFecha > 30 Then
                    l = "img/tareas_circ_verde.png"
                End If

                'If DeltaFecha < 0 Then 'Atraso
                '    If DeltaFecha < -1 Then
                '        ToolTipAtraso = CStr(DeltaFecha * (-1)) & " d&iacute;as de atraso"
                '    Else
                '        ToolTipAtraso = CStr(DeltaFecha * (-1)) & " d&iacute;a de atraso"
                '    End If
                'Else
                '    If DeltaFecha < -1 Then
                '        ToolTipAtraso = CStr(DeltaFecha * (1)) & " d&iacute;as de adelanto"
                '    Else
                '        ToolTipAtraso = CStr(DeltaFecha * (1)) & " d&iacute;a de adelanto"
                '    End If
                'End If

                If DeltaFecha <= 5 Then 'La Tarea se encuentra o próxima a su fecha o esta vencida
                    ' Fondo Rojo                          
                    SemaforoImg = "imgs/semaforo_rojo2.png"
                    SemaforoAlt = "rojo"
                End If
                If DeltaFecha > 6 And DeltaFecha <= 15 Then 'La Tarea se encuentra en fecha de ejecución, ya que estamos filtrando las tareas terminadas
                    ' Fondo Amarillo: Warning
                    SemaforoImg = "imgs/semaforo_amarillo2.png"
                    SemaforoAlt = "amarillo"
                End If
                If DeltaFecha > 16 And DeltaFecha <= 30 Then 'La Tarea es para un mes subsiguiente al actual
                    ' Fondo de color verde
                    SemaforoImg = "imgs/semaforo_verde2.png"
                    SemaforoAlt = "verde"
                End If
                If DeltaFecha > 30 Then
                    ' Fondo de color verde
                    SemaforoImg = "imgs/semaforo_verde2.png"
                    SemaforoAlt = "verde"
                End If

            End While

            dtr.Close()
        Catch

        End Try
        ColorDeLaTarea = l
    End Function
    Public Function LeerTareasPGGCodigoById(ByVal TareasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PGGCodigo "
        sSQL = sSQL & "FROM Tareas "
        sSQL = sSQL & "WHERE (Tareas.TareasId = " & TareasId & ") "
        LeerTareasPGGCodigoById = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasPGGCodigoById = CStr(dtr("PGGCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerTareasPGGCodigoById = ""
        End Try
    End Function
    Public Function CerrarTareasDeUnProcesoJudicial(ByVal CarpetaJudicialCodigo As String, ByVal TareasId As Long, ByVal TareasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Usuarios As New Usuarios
        Dim t As Boolean
        Dim Tareas As New Tareas
        Dim UsuariosCodigo As String = ""
        Dim s As Boolean

        t = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UsuariosCodigo)
        Dim TareasLogRol As String = Usuarios.LeerRolNameByName(UsuariosCodigo)
        Dim TareasLogActividad As String = "Dar por concluidas las Tareas del Proceso Judicial: " & CarpetaJudicialCodigo

        strUpdate = "UPDATE Tareas SET "
        strUpdate = strUpdate & "Tareas.EstadoTareasCodigo = 'Cerrada', "
        strUpdate = strUpdate & "Tareas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Tareas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Tareas.TareasId = " & TareasId
        Try
            CerrarTareasDeUnProcesoJudicial = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Da por concluida las Tareas del Proceso Judical: " & CarpetaJudicialCodigo, TareasId, "Tareas", "Cierra Proceso Judicial")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CerrarTareasDeUnProcesoJudicial = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de dar por concluidas las tareas  del proceso judicial: " & CarpetaJudicialCodigo, TareasId, "Tareas", "")
        End Try
    End Function
End Class
