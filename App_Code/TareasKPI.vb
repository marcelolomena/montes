'------------------------------------------------------------
' Código generado por ZRISMART SF el 20-04-2011 18:26:32
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class TareasKPI
    Public Function LeerTareasKPI(ByVal TareasKPIId As Long, ByRef TareasCodigo As String, ByRef TareasKPISecuencia As Long, ByRef IndicadoresCodigo As String, ByRef AreasName As String, ByRef EmpresasCodigo As String, ByRef ContratoCodigo As String, ByRef TareasKPIAno As String, ByRef TareasKPIMes As Long, ByRef TareasKPIValor1 As Double, ByRef TareasKPIValor2 As Double, ByRef TareasKPIValor3 As Long, ByRef TareasKPIObservacion As String, ByRef TareasKPIFechaRegistro As Date, ByRef UsuariosCodigo As String, ByRef TareasKPIResponsable As String, ByRef TareasKPICargo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasCodigo, TareasKPISecuencia, IndicadoresCodigo, AreasName, EmpresasCodigo, ContratoCodigo, TareasKPIAno, TareasKPIMes, TareasKPIValor1, TareasKPIValor2, TareasKPIValor3, TareasKPIObservacion, TareasKPIFechaRegistro, UsuariosCodigo, TareasKPIResponsable, TareasKPICargo "
        sSQL = sSQL & "FROM (TareasKPI) "
        sSQL = sSQL & "WHERE (TareasKPI.TareasKPIId = " & TareasKPIId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TareasCodigo = CStr(dtr("TareasCodigo").ToString)
                If Len(dtr("TareasKPISecuencia").ToString) = 0 Then
                    TareasKPISecuencia = 0
                Else
                    TareasKPISecuencia = CLng(dtr("TareasKPISecuencia").ToString)
                End If
                IndicadoresCodigo = CStr(dtr("IndicadoresCodigo").ToString)
                AreasName = CStr(dtr("AreasName").ToString)
                EmpresasCodigo = CStr(dtr("EmpresasCodigo").ToString)
                ContratoCodigo = CStr(dtr("ContratoCodigo").ToString)
                TareasKPIAno = CStr(dtr("TareasKPIAno").ToString)
                If Len(dtr("TareasKPIMes").ToString) = 0 Then
                    TareasKPIMes = 0
                Else
                    TareasKPIMes = CLng(dtr("TareasKPIMes").ToString)
                End If
                If Len(dtr("TareasKPIValor1").ToString) = 0 Then
                    TareasKPIValor1 = 0
                Else
                    TareasKPIValor1 = CDbl(dtr("TareasKPIValor1").ToString)
                End If
                If Len(dtr("TareasKPIValor2").ToString) = 0 Then
                    TareasKPIValor2 = 0
                Else
                    TareasKPIValor2 = CDbl(dtr("TareasKPIValor2").ToString)
                End If
                If Len(dtr("TareasKPIValor3").ToString) = 0 Then
                    TareasKPIValor3 = 0
                Else
                    TareasKPIValor3 = CLng(dtr("TareasKPIValor3").ToString)
                End If
                TareasKPIObservacion = CStr(dtr("TareasKPIObservacion").ToString)
                If Len(dtr("TareasKPIFechaRegistro").ToString) = 0 Then
                    TareasKPIFechaRegistro = "01/01/01"
                Else
                    TareasKPIFechaRegistro = CDate(dtr("TareasKPIFechaRegistro").ToString)
                End If
                UsuariosCodigo = CStr(dtr("UsuariosCodigo").ToString)
                TareasKPIResponsable = CStr(dtr("TareasKPIResponsable").ToString)
                TareasKPICargo = CStr(dtr("TareasKPICargo").ToString)
            End While
            LeerTareasKPI = True
            dtr.Close()
        Catch
            LeerTareasKPI = False
        End Try
    End Function
    Public Function TareasKPIUpdate(ByVal TareasKPIId As Long, ByRef TareasCodigo As String, ByRef TareasKPISecuencia As Long, ByRef IndicadoresCodigo As String, ByRef AreasName As String, ByRef EmpresasCodigo As String, ByRef ContratoCodigo As String, ByRef TareasKPIAno As String, ByRef TareasKPIMes As Long, ByRef TareasKPIValor1 As Double, ByRef TareasKPIValor2 As Double, ByRef TareasKPIValor3 As Long, ByRef TareasKPIObservacion As String, ByRef TareasKPIFechaRegistro As Date, ByRef UsuariosCodigo As String, ByRef TareasKPIResponsable As String, ByRef TareasKPICargo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim t As Integer = 0
        Dim TareasId As Long = 0
        Dim b As Boolean
        b = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        Dim UserIdCodigo As String = ""
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(EstadoTareasCodigo)
        Dim TareasLogActividad As String = ""

        TareasLogActividad = "Responsable: " & UsuariosCodigo & "; Usuario que opera el sistema: " & UserIdCodigo & "; Indicador: " & IndicadoresCodigo
        TareasLogActividad = TareasLogActividad & "; Valor: " & TareasKPIValor1 / 100 & "; Area: " & AreasName & "; Empresa: " & EmpresasCodigo & "; Contrato: " & ContratoCodigo

        strUpdate = "UPDATE TareasKPI SET "
        strUpdate = strUpdate & "TareasKPI.TareasCodigo = '" & TareasCodigo & "', "
        strUpdate = strUpdate & "TareasKPI.TareasKPISecuencia = " & TareasKPISecuencia & ", "
        strUpdate = strUpdate & "TareasKPI.IndicadoresCodigo = '" & IndicadoresCodigo & "', "
        strUpdate = strUpdate & "TareasKPI.AreasName = '" & AreasName & "', "
        strUpdate = strUpdate & "TareasKPI.EmpresasCodigo = '" & EmpresasCodigo & "', "
        strUpdate = strUpdate & "TareasKPI.ContratoCodigo = '" & ContratoCodigo & "', "
        strUpdate = strUpdate & "TareasKPI.TareasKPIAno = '" & TareasKPIAno & "', "
        strUpdate = strUpdate & "TareasKPI.TareasKPIMes = " & TareasKPIMes & ", "
        strUpdate = strUpdate & "TareasKPI.TareasKPIValor1 = " & TareasKPIValor1 & ", "
        strUpdate = strUpdate & "TareasKPI.TareasKPIValor2 = " & TareasKPIValor2 & ", "
        strUpdate = strUpdate & "TareasKPI.TareasKPIValor3 = " & TareasKPIValor3 & ", "
        strUpdate = strUpdate & "TareasKPI.TareasKPIObservacion = '" & TareasKPIObservacion & "', "
        strUpdate = strUpdate & "TareasKPI.TareasKPIFechaRegistro = '" & AccionesABM.DateTransform(TareasKPIFechaRegistro) & "', "
        strUpdate = strUpdate & "TareasKPI.UsuariosCodigo = '" & UsuariosCodigo & "', "
        strUpdate = strUpdate & "TareasKPI.TareasKPIResponsable = '" & TareasKPIResponsable & "', "
        strUpdate = strUpdate & "TareasKPI.TareasKPICargo = '" & TareasKPICargo & "', "
        strUpdate = strUpdate & "TareasKPI.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "TareasKPI.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE TareasKPI.TareasKPIId = " & TareasKPIId
        Try
            TareasKPIUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & TareasCodigo, TareasKPIId, "TareasKPI", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasKPIUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TareasCodigo, TareasKPIId, "TareasKPI", "")
        End Try
    End Function
    Public Function TareasKPIInsert(ByRef TareasKPIId As Long, ByRef TareasCodigo As String, ByRef TareasKPISecuencia As Long, ByRef IndicadoresCodigo As String, ByRef AreasName As String, ByRef EmpresasCodigo As String, ByRef ContratoCodigo As String, ByRef TareasKPIAno As String, ByRef TareasKPIMes As Long, ByRef TareasKPIValor1 As Double, ByRef TareasKPIValor2 As Double, ByRef TareasKPIValor3 As Long, ByRef TareasKPIObservacion As String, ByRef TareasKPIFechaRegistro As Date, ByRef UsuariosCodigo As String, ByRef TareasKPIResponsable As String, ByRef TareasKPICargo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim TareasKPI As New TareasKPI
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = TareasCodigo
            DetailSecuencia = TareasKPISecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("TareasKPIId", "TareasCodigo", "TareasKPISecuencia", "TareasKPI", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("TareasKPIId", "TareasCodigo", "TareasKPISecuencia", "TareasKPI", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            TareasKPIInsert = TareasKPI.TareasKPIUpdate(DetailId, CStr(TareasCodigo), CLng(TareasKPISecuencia), CStr(IndicadoresCodigo), CStr(AreasName), CStr(EmpresasCodigo), CStr(ContratoCodigo), CStr(TareasKPIAno), CLng(TareasKPIMes), CDbl(TareasKPIValor1), CDbl(TareasKPIValor2), CLng(TareasKPIValor3), CStr(TareasKPIObservacion), CDate(TareasKPIFechaRegistro), CStr(UsuariosCodigo), CStr(TareasKPIResponsable), CStr(TareasKPICargo), UserId)
        Catch
            TareasKPIInsert = 0
        End Try
    End Function
    Public Function TareasKPIDelete(ByVal TareasKPIId As Long, ByVal TareasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (TareasKPI) "
        strUpdate = strUpdate & "WHERE (TareasKPI.TareasKPIId = " & TareasKPIId & ") "
        Try
            TareasKPIDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & TareasCodigo, TareasKPIId, "TareasKPI", "")
        Catch
            TareasKPIDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & TareasCodigo, TareasKPIId, "TareasKPI", "")
        End Try
    End Function
End Class
