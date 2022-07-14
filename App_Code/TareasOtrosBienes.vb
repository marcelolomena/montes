'------------------------------------------------------------
' Código generado por ZRISMART SF el 20-04-2011 16:43:05
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class TareasOtrosBienes
    Public Function LeerTareasOtrosBienes(ByVal TareasOtrosBienesId As Long, ByRef TareasCodigo As String, _
                                          ByRef TareasOtrosBienesSecuencia As Long, _
                                          ByRef TareasOtrosBienesDescription As String, _
                                          ByRef TareasOtrosBienesInscripcionFojas As String, _
                                          ByRef TareasOtrosBienesInscripcionNumero As String, _
                                          ByRef TareasOtrosBienesInscripcionAno As Integer, _
                                          ByRef TareasOtrosBienesInscripcionCiudad As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasCodigo, TareasOtrosBienesSecuencia, TareasOtrosBienesDescription, TareasOtrosBienesInscripcionFojas, TareasOtrosBienesInscripcionNumero, TareasOtrosBienesInscripcionAno, TareasOtrosBienesInscripcionCiudad "
        sSQL = sSQL & "FROM (TareasOtrosBienes) "
        sSQL = sSQL & "WHERE (TareasOtrosBienes.TareasOtrosBienesId = " & TareasOtrosBienesId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TareasCodigo = CStr(dtr("TareasCodigo").ToString)
                If Len(dtr("TareasOtrosBienesSecuencia").ToString) = 0 Then
                    TareasOtrosBienesSecuencia = 0
                Else
                    TareasOtrosBienesSecuencia = CLng(dtr("TareasOtrosBienesSecuencia").ToString)
                End If
                TareasOtrosBienesDescription = CStr(dtr("TareasOtrosBienesDescription").ToString)
                TareasOtrosBienesInscripcionFojas = CStr(dtr("TareasOtrosBienesInscripcionFojas").ToString)
                TareasOtrosBienesInscripcionNumero = CStr(dtr("TareasOtrosBienesInscripcionNumero").ToString)
                TareasOtrosBienesInscripcionCiudad = CStr(dtr("TareasOtrosBienesInscripcionCiudad").ToString)
                If Len(dtr("TareasOtrosBienesInscripcionAno").ToString) = 0 Then
                    TareasOtrosBienesInscripcionAno = 0
                Else
                    TareasOtrosBienesInscripcionAno = CLng(dtr("TareasOtrosBienesInscripcionAno").ToString)
                End If
            End While
            LeerTareasOtrosBienes = True
            dtr.Close()
        Catch
            LeerTareasOtrosBienes = False
        End Try
    End Function
    Public Function TareasOtrosBienesUpdate(ByVal TareasOtrosBienesId As Long, ByVal TareasCodigo As String, _
                                            ByVal TareasOtrosBienesSecuencia As Long, _
                                            ByVal TareasOtrosBienesDescription As String, _
                                            ByVal TareasOtrosBienesInscripcionFojas As String, _
                                            ByVal TareasOtrosBienesInscripcionNumero As String, _
                                            ByVal TareasOtrosBienesInscripcionAno As Integer, _
                                            ByVal TareasOtrosBienesInscripcionCiudad As String, _
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

        TareasLogActividad = "Registra Otros Bienes: " & TareasOtrosBienesDescription

        strUpdate = "UPDATE TareasOtrosBienes SET "
        strUpdate = strUpdate & "TareasOtrosBienes.TareasCodigo = '" & TareasCodigo & "', "
        strUpdate = strUpdate & "TareasOtrosBienes.TareasOtrosBienesSecuencia = " & TareasOtrosBienesSecuencia & ", "
        strUpdate = strUpdate & "TareasOtrosBienes.TareasOtrosBienesDescription = '" & TareasOtrosBienesDescription & "', "
        strUpdate = strUpdate & "TareasOtrosBienes.TareasOtrosBienesInscripcionFojas = '" & TareasOtrosBienesInscripcionFojas & "', "
        strUpdate = strUpdate & "TareasOtrosBienes.TareasOtrosBienesInscripcionNumero = '" & TareasOtrosBienesInscripcionNumero & "', "
        strUpdate = strUpdate & "TareasOtrosBienes.TareasOtrosBienesInscripcionAno = " & TareasOtrosBienesInscripcionAno & ", "
        strUpdate = strUpdate & "TareasOtrosBienes.TareasOtrosBienesInscripcionCiudad = '" & TareasOtrosBienesInscripcionCiudad & "', "
        strUpdate = strUpdate & "TareasOtrosBienes.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "TareasOtrosBienes.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE TareasOtrosBienes.TareasOtrosBienesId = " & TareasOtrosBienesId
        Try
            TareasOtrosBienesUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & TareasCodigo, TareasOtrosBienesId, "TareasOtrosBienes", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasOtrosBienesUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TareasCodigo, TareasOtrosBienesId, "TareasOtrosBienes", "")
        End Try
    End Function
    Public Function TareasOtrosBienesInsert(ByRef TareasOtrosBienesId As Long, ByVal TareasCodigo As String, _
                                            ByVal TareasOtrosBienesSecuencia As Long, _
                                            ByVal TareasOtrosBienesDescription As String, _
                                            ByVal TareasOtrosBienesInscripcionFojas As String, _
                                            ByVal TareasOtrosBienesInscripcionNumero As String, _
                                            ByVal TareasOtrosBienesInscripcionAno As Integer, _
                                            ByVal TareasOtrosBienesInscripcionCiudad As String, _
                                            ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim TareasOtrosBienes As New TareasOtrosBienes
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = TareasCodigo
            DetailSecuencia = TareasOtrosBienesSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("TareasOtrosBienesId", "TareasCodigo", "TareasOtrosBienesSecuencia", "TareasOtrosBienes", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("TareasOtrosBienesId", "TareasCodigo", "TareasOtrosBienesSecuencia", "TareasOtrosBienes", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            TareasOtrosBienesInsert = TareasOtrosBienes.TareasOtrosBienesUpdate(DetailId, CStr(TareasCodigo), CLng(TareasOtrosBienesSecuencia), CStr(TareasOtrosBienesDescription), TareasOtrosBienesInscripcionFojas, TareasOtrosBienesInscripcionNumero, TareasOtrosBienesInscripcionAno, TareasOtrosBienesInscripcionCiudad, UserId)
        Catch
            TareasOtrosBienesInsert = 0
        End Try
    End Function
    Public Function TareasOtrosBienesDelete(ByVal TareasOtrosBienesId As Long, ByVal TareasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim TareasOtrosBienes As New TareasOtrosBienes
        Dim t As Integer
        Dim TareasId As Long = 0
        Dim b As Boolean
        b = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        Dim UserIdCodigo As String = ""
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(TareasId)
        Dim TareasLogActividad As String = ""

        TareasLogActividad = "Elimina Aval: " & TareasOtrosBienes.LeerTareasOtrosBienesNombre(TareasOtrosBienesId)

        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (TareasOtrosBienes) "
        strUpdate = strUpdate & "WHERE (TareasOtrosBienes.TareasOtrosBienesId = " & TareasOtrosBienesId & ") "

        Try
            TareasOtrosBienesDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina un bien asociada a la Tarea: " & TareasCodigo, TareasOtrosBienesId, "TareasOtrosBienes", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasOtrosBienesDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar un bien asociada a la tarea: " & TareasCodigo, TareasOtrosBienesId, "TareasOtrosBienes", "")
        End Try
    End Function
    Public Function LeerTareasOtrosBienesNombre(ByVal TareasOtrosBienesId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasOtrosBienesDescription "
        sSQL = sSQL & "FROM TareasOtrosBienes "
        sSQL = sSQL & "WHERE (TareasOtrosBienes.TareasOtrosBienesId = " & TareasOtrosBienesId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasOtrosBienesNombre = CStr(dtr("TareasOtrosBienesDescription").ToString)
            End While
            LeerTareasOtrosBienesNombre = True
            dtr.Close()
        Catch
            LeerTareasOtrosBienesNombre = False
        End Try
    End Function
    Public Function LeerLosOtrosBienes(ByVal TareasCodigo As String, ByVal Accion As Integer) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String = ""
        Dim Tareas As New Tareas
        Dim TareasOtrosBienesDescription As String
        Dim TareasOtrosBienesInscripcionFojas As String
        Dim TareasOtrosBienesInscripcionNumero As String
        Dim TareasOtrosBienesInscripcionAno As Integer
        Dim TareasOtrosBienesInscripcionCiudad As String

        LeerLosOtrosBienes = ""

        Select Case Accion
            Case 1

                strUpdate = "SELECT TareasOtrosBienes.TareasOtrosBienesId As Id, TareasOtrosBienes.TareasOtrosBienesDescription As Description, TareasOtrosBienes.TareasOtrosBienesInscripcionFojas As Fojas, TareasOtrosBienes.TareasOtrosBienesInscripcionNumero As Numero, TareasOtrosBienes.TareasOtrosBienesInscripcionAno As Ano, TareasOtrosBienes.TareasOtrosBienesInscripcionCiudad As Ciudad "
                strUpdate = strUpdate & "FROM CarpetaJudicial INNER JOIN (TareasOtrosBienes INNER JOIN Tareas ON TareasOtrosBienes.TareasCodigo = Tareas.TareasCodigo) ON CarpetaJudicial.CarpetaJudicialCodigo = Tareas.PGGCodigo "
                strUpdate = strUpdate & "WHERE (((Tareas.PGGCodigo)='" & Tareas.LeerTareasPGGCodigo(TareasCodigo) & "'))"

                Try
                    dtr = AccesoEA.ListarRegistros(strUpdate)
                    While dtr.Read
                        TareasOtrosBienesDescription = CStr(dtr("Description").ToString)
                        TareasOtrosBienesInscripcionFojas = CStr(dtr("Fojas").ToString)
                        TareasOtrosBienesInscripcionNumero = CStr(dtr("Numero").ToString)
                        TareasOtrosBienesInscripcionCiudad = CStr(dtr("Ciudad").ToString)
                        If Len(dtr("Ano").ToString) = 0 Then
                            TareasOtrosBienesInscripcionAno = 0
                        Else
                            TareasOtrosBienesInscripcionAno = CLng(dtr("Ano").ToString)
                        End If
                        CodigoHTML = CodigoHTML & "<p>El deudor es dueño de " & TareasOtrosBienesDescription & ".</p>"
                        If Len(TareasOtrosBienesInscripcionFojas) > 0 Then
                            CodigoHTML = CodigoHTML & "<p>El inmueble está inscrito a fojas " & TareasOtrosBienesInscripcionFojas & " Nº " & TareasOtrosBienesInscripcionNumero & " del Registro de Propiedad del año " & TareasOtrosBienesInscripcionAno & " en el Conservador de Bienes Raíces  de " & TareasOtrosBienesInscripcionCiudad & ".</p>"
                        End If
                    End While
                    dtr.Close()
                Catch
                    CodigoHTML = ""
                End Try

        End Select

        LeerLosOtrosBienes = CodigoHTML

    End Function


End Class
