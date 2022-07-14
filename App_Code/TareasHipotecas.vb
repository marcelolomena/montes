'------------------------------------------------------------
' Código generado por ZRISMART SF el 20-04-2011 16:43:05
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class TareasHipotecas
    Public Function LeerTareasHipotecas(ByVal TareasHipotecasId As Long, ByRef TareasCodigo As String, _
                                          ByRef TareasHipotecasSecuencia As Long, _
                                          ByRef TareasHipotecasDescription As String, _
                                          ByRef TareasHipotecasInscripcionFojas As String, _
                                          ByRef TareasHipotecasInscripcionNumero As String, _
                                          ByRef TareasHipotecasInscripcionAno As Integer, _
                                          ByRef TareasHipotecasInscripcionCiudad As String, _
                                          ByRef TareasHipotecasFojas As String, _
                                          ByRef TareasHipotecasNumero As String, _
                                          ByRef TareasHipotecasAno As Integer, _
                                          ByRef TareasHipotecasCiudad As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasCodigo, TareasHipotecasSecuencia, TareasHipotecasDescription, TareasHipotecasInscripcionFojas, TareasHipotecasInscripcionNumero, TareasHipotecasInscripcionAno, TareasHipotecasInscripcionCiudad, TareasHipotecasFojas, TareasHipotecasNumero, TareasHipotecasAno, TareasHipotecasCiudad "
        sSQL = sSQL & "FROM TareasHipotecas "
        sSQL = sSQL & "WHERE TareasHipotecas.TareasHipotecasId = " & TareasHipotecasId
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TareasCodigo = CStr(dtr("TareasCodigo").ToString)
                If Len(dtr("TareasHipotecasSecuencia").ToString) = 0 Then
                    TareasHipotecasSecuencia = 0
                Else
                    TareasHipotecasSecuencia = CLng(dtr("TareasHipotecasSecuencia").ToString)
                End If
                TareasHipotecasDescription = CStr(dtr("TareasHipotecasDescription").ToString)
                TareasHipotecasInscripcionFojas = CStr(dtr("TareasHipotecasInscripcionFojas").ToString)
                TareasHipotecasInscripcionNumero = CStr(dtr("TareasHipotecasInscripcionNumero").ToString)
                TareasHipotecasInscripcionCiudad = CStr(dtr("TareasHipotecasInscripcionCiudad").ToString)
                If Len(dtr("TareasHipotecasInscripcionAno").ToString) = 0 Then
                    TareasHipotecasInscripcionAno = 0
                Else
                    TareasHipotecasInscripcionAno = CLng(dtr("TareasHipotecasInscripcionAno").ToString)
                End If
                TareasHipotecasFojas = CStr(dtr("TareasHipotecasFojas").ToString)
                TareasHipotecasNumero = CStr(dtr("TareasHipotecasNumero").ToString)
                TareasHipotecasCiudad = CStr(dtr("TareasHipotecasCiudad").ToString)
                If Len(dtr("TareasHipotecasAno").ToString) = 0 Then
                    TareasHipotecasAno = 0
                Else
                    TareasHipotecasAno = CLng(dtr("TareasHipotecasAno").ToString)
                End If
            End While
            LeerTareasHipotecas = True
            dtr.Close()
        Catch
            LeerTareasHipotecas = False
        End Try
    End Function
    Public Function TareasHipotecasUpdate(ByVal TareasHipotecasId As Long, ByVal TareasCodigo As String, _
                                            ByVal TareasHipotecasSecuencia As Long, _
                                            ByVal TareasHipotecasDescription As String, _
                                            ByVal TareasHipotecasInscripcionFojas As String, _
                                            ByVal TareasHipotecasInscripcionNumero As String, _
                                            ByVal TareasHipotecasInscripcionAno As Integer, _
                                            ByVal TareasHipotecasInscripcionCiudad As String, _
                                            ByVal TareasHipotecasFojas As String, _
                                            ByVal TareasHipotecasNumero As String, _
                                            ByVal TareasHipotecasAno As Integer, _
                                            ByVal TareasHipotecasCiudad As String, _
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

        TareasLogActividad = "Registra Otros Bienes: " & TareasHipotecasDescription

        strUpdate = "UPDATE TareasHipotecas SET "
        strUpdate = strUpdate & "TareasHipotecas.TareasCodigo = '" & TareasCodigo & "', "
        strUpdate = strUpdate & "TareasHipotecas.TareasHipotecasSecuencia = " & TareasHipotecasSecuencia & ", "
        strUpdate = strUpdate & "TareasHipotecas.TareasHipotecasDescription = '" & TareasHipotecasDescription & "', "
        strUpdate = strUpdate & "TareasHipotecas.TareasHipotecasInscripcionFojas = '" & TareasHipotecasInscripcionFojas & "', "
        strUpdate = strUpdate & "TareasHipotecas.TareasHipotecasInscripcionNumero = '" & TareasHipotecasInscripcionNumero & "', "
        strUpdate = strUpdate & "TareasHipotecas.TareasHipotecasInscripcionAno = " & TareasHipotecasInscripcionAno & ", "
        strUpdate = strUpdate & "TareasHipotecas.TareasHipotecasInscripcionCiudad = '" & TareasHipotecasInscripcionCiudad & "', "
        strUpdate = strUpdate & "TareasHipotecas.TareasHipotecasFojas = '" & TareasHipotecasFojas & "', "
        strUpdate = strUpdate & "TareasHipotecas.TareasHipotecasNumero = '" & TareasHipotecasNumero & "', "
        strUpdate = strUpdate & "TareasHipotecas.TareasHipotecasAno = " & TareasHipotecasAno & ", "
        strUpdate = strUpdate & "TareasHipotecas.TareasHipotecasCiudad = '" & TareasHipotecasCiudad & "', "
        strUpdate = strUpdate & "TareasHipotecas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "TareasHipotecas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE TareasHipotecas.TareasHipotecasId = " & TareasHipotecasId
        Try
            TareasHipotecasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & TareasCodigo, TareasHipotecasId, "TareasHipotecas", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasHipotecasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TareasCodigo, TareasHipotecasId, "TareasHipotecas", "")
        End Try
    End Function
    Public Function TareasHipotecasInsert(ByRef TareasHipotecasId As Long, ByVal TareasCodigo As String, _
                                            ByVal TareasHipotecasSecuencia As Long, _
                                            ByVal TareasHipotecasDescription As String, _
                                            ByVal TareasHipotecasInscripcionFojas As String, _
                                            ByVal TareasHipotecasInscripcionNumero As String, _
                                            ByVal TareasHipotecasInscripcionAno As Integer, _
                                            ByVal TareasHipotecasInscripcionCiudad As String, _
                                            ByVal TareasHipotecasFojas As String, _
                                            ByVal TareasHipotecasNumero As String, _
                                            ByVal TareasHipotecasAno As Integer, _
                                            ByVal TareasHipotecasCiudad As String, _
                                            ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim TareasHipotecas As New TareasHipotecas
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = TareasCodigo
            DetailSecuencia = TareasHipotecasSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("TareasHipotecasId", "TareasCodigo", "TareasHipotecasSecuencia", "TareasHipotecas", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("TareasHipotecasId", "TareasCodigo", "TareasHipotecasSecuencia", "TareasHipotecas", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            TareasHipotecasInsert = TareasHipotecas.TareasHipotecasUpdate(DetailId, CStr(TareasCodigo), CLng(TareasHipotecasSecuencia), CStr(TareasHipotecasDescription), TareasHipotecasInscripcionFojas, TareasHipotecasInscripcionNumero, TareasHipotecasInscripcionAno, TareasHipotecasInscripcionCiudad, TareasHipotecasFojas, TareasHipotecasNumero, TareasHipotecasAno, TareasHipotecasCiudad, UserId)
        Catch
            TareasHipotecasInsert = 0
        End Try
    End Function
    Public Function TareasHipotecasDelete(ByVal TareasHipotecasId As Long, ByVal TareasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim TareasHipotecas As New TareasHipotecas
        Dim t As Integer
        Dim TareasId As Long = 0
        Dim b As Boolean
        b = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        Dim UserIdCodigo As String = ""
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(TareasId)
        Dim TareasLogActividad As String = ""

        TareasLogActividad = "Elimina Aval: " & TareasHipotecas.LeerTareasHipotecasNombre(TareasHipotecasId)

        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (TareasHipotecas) "
        strUpdate = strUpdate & "WHERE (TareasHipotecas.TareasHipotecasId = " & TareasHipotecasId & ") "

        Try
            TareasHipotecasDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina un bien asociada a la Tarea: " & TareasCodigo, TareasHipotecasId, "TareasHipotecas", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasHipotecasDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar un bien asociada a la tarea: " & TareasCodigo, TareasHipotecasId, "TareasHipotecas", "")
        End Try
    End Function
    Public Function LeerTareasHipotecasNombre(ByVal TareasHipotecasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasHipotecasDescription "
        sSQL = sSQL & "FROM TareasHipotecas "
        sSQL = sSQL & "WHERE (TareasHipotecas.TareasHipotecasId = " & TareasHipotecasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasHipotecasNombre = CStr(dtr("TareasHipotecasDescription").ToString)
            End While
            LeerTareasHipotecasNombre = True
            dtr.Close()
        Catch
            LeerTareasHipotecasNombre = False
        End Try
    End Function
    Public Function LeerLasHipotecas(ByVal TareasCodigo As String, ByVal Accion As Integer) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String = ""
        Dim Tareas As New Tareas

        LeerLasHipotecas = ""

        Select Case Accion
            Case 1

                strUpdate = "SELECT TareasHipotecas.TareasHipotecasId As Id, TareasHipotecas.TareasHipotecasDescription As Description, TareasHipotecas.TareasHipotecasInscripcionFojas AS InmuebleFojas, TareasHipotecas.TareasHipotecasInscripcionNumero AS InmuebleNumero, TareasHipotecas.TareasHipotecasInscripcionAno AS InmuebleAno, TareasHipotecas.TareasHipotecasInscripcionCiudad AS InmuebleCiudad, TareasHipotecas.TareasHipotecasFojas AS HipotecaFojas, TareasHipotecas.TareasHipotecasNumero AS HipotecaNumero, TareasHipotecas.TareasHipotecasAno AS HipotecaAno, TareasHipotecas.TareasHipotecasCiudad AS HipotecaCiudad "
                strUpdate = strUpdate & "FROM CarpetaJudicial INNER JOIN (TareasHipotecas INNER JOIN Tareas ON TareasHipotecas.TareasCodigo = Tareas.TareasCodigo) ON CarpetaJudicial.CarpetaJudicialCodigo = Tareas.PGGCodigo "
                strUpdate = strUpdate & "WHERE (((Tareas.PGGCodigo)='" & Tareas.LeerTareasPGGCodigo(TareasCodigo) & "'))"

                Try
                    dtr = AccesoEA.ListarRegistros(strUpdate)
                    While dtr.Read
                        CodigoHTML = CodigoHTML & "<p>" & dtr("Description").ToString & "</p>"
                        CodigoHTML = CodigoHTML & "<p>El inmueble está inscrito a fojas " & dtr("InmuebleFojas").ToString & " Nº " & dtr("InmuebleNumero").ToString & " del Registro de propiedad del año " & dtr("InmuebleAno").ToString & " en el Conservador de Bienes Raíces  de " & dtr("InmuebleCiudad").ToString & ". La hipoteca constituida a favor del banco Scotiabank está inscrita a fojas " & dtr("HipotecaFojas").ToString & " Nº " & dtr("HipotecaNumero").ToString & " del Registro de Hipotecas y Gravámenes del año " & dtr("HipotecaAno").ToString & " en el citado Conservador de Bienes Raíces como se acredita con la copia autorizada que se acompaña en el primer otrosí.</p>"
                    End While
                    dtr.Close()
                Catch
                    CodigoHTML = ""
                End Try

        End Select

        LeerLasHipotecas = CodigoHTML

    End Function
End Class
