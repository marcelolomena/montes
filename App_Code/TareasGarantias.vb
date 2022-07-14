'------------------------------------------------------------
' Código generado por ZRISMART SF el 20-04-2011 16:43:05
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class TareasGarantias
    Public Function LeerTareasGarantias(ByVal TareasGarantiasId As Long, ByRef TareasCodigo As String, _
                                        ByRef TareasGarantiasSecuencia As Long, _
                                        ByRef TareasGarantiasDescription As String, _
                                        ByRef TareasGarantiasFechaEscritura As Date, _
                                        ByRef TareasGarantiasCiudadEscritura As String, _
                                        ByRef TareasGarantiasNotarioEscritura As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasCodigo, TareasGarantiasSecuencia, TareasGarantiasDescription, TareasGarantiasFechaEscritura, TareasGarantiasCiudadEscritura, TareasGarantiasNotarioEscritura "
        sSQL = sSQL & "FROM TareasGarantias "
        sSQL = sSQL & "WHERE TareasGarantias.TareasGarantiasId = " & TareasGarantiasId
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TareasCodigo = CStr(dtr("TareasCodigo").ToString)
                If Len(dtr("TareasGarantiasSecuencia").ToString) = 0 Then
                    TareasGarantiasSecuencia = 0
                Else
                    TareasGarantiasSecuencia = CLng(dtr("TareasGarantiasSecuencia").ToString)
                End If
                TareasGarantiasDescription = CStr(dtr("TareasGarantiasDescription").ToString)
                If Len(dtr("TareasGarantiasFechaEscritura").ToString) = 0 Then
                    TareasGarantiasFechaEscritura = "01/01/01"
                Else
                    TareasGarantiasFechaEscritura = CDate(dtr("TareasGarantiasFechaEscritura").ToString)
                End If
                TareasGarantiasCiudadEscritura = CStr(dtr("TareasGarantiasCiudadEscritura").ToString)
                TareasGarantiasNotarioEscritura = CStr(dtr("TareasGarantiasNotarioEscritura").ToString)
            End While
            LeerTareasGarantias = True
            dtr.Close()
        Catch
            LeerTareasGarantias = False
        End Try
    End Function
    Public Function TareasGarantiasUpdate(ByVal TareasGarantiasId As Long, ByRef TareasCodigo As String, _
                                          ByVal TareasGarantiasSecuencia As Long, _
                                          ByVal TareasGarantiasDescription As String, _
                                          ByVal TareasGarantiasFechaEscritura As Date, _
                                          ByVal TareasGarantiasCiudadEscritura As String, _
                                          ByVal TareasGarantiasNotarioEscritura As String, _
                                          ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim Tareas As New Tareas
        Dim t As Integer = 0
        Dim TareasId As Long = 0
        Dim b As Boolean
        b = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        Dim UserIdCodigo As String = ""
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(TareasId)
        Dim TareasLogActividad As String = ""

        TareasLogActividad = "Registra Garant&iacute;a: " & TareasGarantiasDescription

        strUpdate = "UPDATE TareasGarantias SET "
        strUpdate = strUpdate & "TareasGarantias.TareasCodigo = '" & TareasCodigo & "', "
        strUpdate = strUpdate & "TareasGarantias.TareasGarantiasSecuencia = " & TareasGarantiasSecuencia & ", "
        strUpdate = strUpdate & "TareasGarantias.TareasGarantiasDescription = '" & TareasGarantiasDescription & "', "
        strUpdate = strUpdate & "TareasGarantias.TareasGarantiasFechaEscritura = '" & AccionesABM.DateTransform(TareasGarantiasFechaEscritura) & "', "
        strUpdate = strUpdate & "TareasGarantias.TareasGarantiasCiudadEscritura = '" & TareasGarantiasCiudadEscritura & "', "
        strUpdate = strUpdate & "TareasGarantias.TareasGarantiasNotarioEscritura = '" & TareasGarantiasNotarioEscritura & "', "
        strUpdate = strUpdate & "TareasGarantias.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "TareasGarantias.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE TareasGarantias.TareasGarantiasId = " & TareasGarantiasId
        Try
            TareasGarantiasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & TareasCodigo, TareasGarantiasId, "TareasGarantias", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasGarantiasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TareasCodigo, TareasGarantiasId, "TareasGarantias", "")
        End Try
    End Function
    Public Function TareasGarantiasInsert(ByRef TareasGarantiasId As Long, ByVal TareasCodigo As String, _
                                          ByVal TareasGarantiasSecuencia As Long, _
                                          ByVal TareasGarantiasDescription As String, _
                                          ByVal TareasGarantiasFechaEscritura As Date, _
                                          ByVal TareasGarantiasCiudadEscritura As String, _
                                          ByVal TareasGarantiasNotarioEscritura As String, _
                                          ByVal UserId As Long) As Integer

        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim TareasGarantias As New TareasGarantias
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = TareasCodigo
            DetailSecuencia = TareasGarantiasSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("TareasGarantiasId", "TareasCodigo", "TareasGarantiasSecuencia", "TareasGarantias", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("TareasGarantiasId", "TareasCodigo", "TareasGarantiasSecuencia", "TareasGarantias", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            TareasGarantiasInsert = TareasGarantias.TareasGarantiasUpdate(DetailId, CStr(TareasCodigo), CLng(TareasGarantiasSecuencia), CStr(TareasGarantiasDescription), CDate(TareasGarantiasFechaEscritura), CStr(TareasGarantiasCiudadEscritura), CStr(TareasGarantiasNotarioEscritura), UserId)
        Catch
            TareasGarantiasInsert = 0
        End Try
    End Function
    Public Function TareasGarantiasDelete(ByVal TareasGarantiasId As Long, ByVal TareasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim TareasGarantias As New TareasGarantias
        Dim t As Integer
        Dim TareasId As Long = 0
        Dim b As Boolean
        b = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        Dim UserIdCodigo As String = ""
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(TareasId)
        Dim TareasLogActividad As String = ""

        TareasLogActividad = "Elimina Garant&iacute;a: " & TareasGarantias.LeerTareasGarantiasNombre(TareasGarantiasId)

        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (TareasGarantias) "
        strUpdate = strUpdate & "WHERE (TareasGarantias.TareasGarantiasId = " & TareasGarantiasId & ") "

        Try
            TareasGarantiasDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Garantia asociada a la Tarea: " & TareasCodigo, TareasGarantiasId, "TareasGarantias", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasGarantiasDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar garantia asociada a la tarea: " & TareasCodigo, TareasGarantiasId, "TareasGarantias", "")
        End Try
    End Function
    Public Function LeerTareasGarantiasNombre(ByVal TareasGarantiasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasGarantiasDescription "
        sSQL = sSQL & "FROM TareasGarantias "
        sSQL = sSQL & "WHERE (TareasGarantias.TareasGarantiasId = " & TareasGarantiasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasGarantiasNombre = CStr(dtr("TareasGarantiasDescription").ToString)
            End While
            LeerTareasGarantiasNombre = True
            dtr.Close()
        Catch
            LeerTareasGarantiasNombre = False
        End Try
    End Function
    Public Function LeerLasGarantias(ByVal TareasCodigo As String, ByVal Accion As Integer, ByVal Deudor As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String = ""
        Dim Tareas As New Tareas
        Dim TareasGarantiasDescription As String = ""
        Dim TareasGarantiasFechaEscritura As Date = "01/01/01"
        Dim TareasGarantiasCiudadEscritura As String = ""
        Dim TareasGarantiasNotarioEscritura As String = ""

        LeerLasGarantias = ""

        Select Case Accion
            Case 1

                strUpdate = "SELECT TareasGarantias.TareasGarantiasId As Id, TareasGarantias.TareasGarantiasDescription As Description, TareasGarantias.TareasGarantiasFechaEscritura As Fecha, TareasGarantias.TareasGarantiasCiudadEscritura As Ciudad, TareasGarantias.TareasGarantiasNotarioEscritura As Notario "
                strUpdate = strUpdate & "FROM CarpetaJudicial INNER JOIN (TareasGarantias INNER JOIN Tareas ON TareasGarantias.TareasCodigo = Tareas.TareasCodigo) ON CarpetaJudicial.CarpetaJudicialCodigo = Tareas.PGGCodigo "
                strUpdate = strUpdate & "WHERE (((Tareas.PGGCodigo)='" & Tareas.LeerTareasPGGCodigo(TareasCodigo) & "'))"

                Try
                    dtr = AccesoEA.ListarRegistros(strUpdate)
                    While dtr.Read
                        TareasGarantiasDescription = CStr(dtr("Description").ToString)
                        If Len(dtr("Fecha").ToString) = 0 Then
                            TareasGarantiasFechaEscritura = "01/01/01"
                        Else
                            TareasGarantiasFechaEscritura = CDate(dtr("Fecha").ToString)
                        End If
                        TareasGarantiasCiudadEscritura = CStr(dtr("Ciudad").ToString)
                        TareasGarantiasNotarioEscritura = CStr(dtr("Notario").ToString)
                        CodigoHTML = CodigoHTML & "<p>Por escritura de " & FormatDateTime(TareasGarantiasFechaEscritura, DateFormat.ShortDate) & ", en la notaria de don " & TareasGarantiasNotarioEscritura & ", de " & TareasGarantiasCiudadEscritura & ", " & Deudor & " constituyo prenda sobre el siguiente bien " & TareasGarantiasDescription & "</p>"
                    End While
                    dtr.Close()
                Catch
                    CodigoHTML = ""
                End Try

        End Select

        LeerLasGarantias = CodigoHTML

    End Function


End Class
