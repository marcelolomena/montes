'------------------------------------------------------------
' Código generado por ZRISMART SF el 20-04-2011 16:43:05
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class CarpetaJudicialHipotecas
    Public Function LeerCarpetaJudicialHipotecas(ByVal CarpetaJudicialHipotecasId As Long, ByRef CarpetaJudicialCodigo As String, _
                                          ByRef CarpetaJudicialHipotecasSecuencia As Long, _
                                          ByRef CarpetaJudicialHipotecasDescription As String, _
                                          ByRef CarpetaJudicialHipotecasInscripcionFojas As String, _
                                          ByRef CarpetaJudicialHipotecasInscripcionNumero As String, _
                                          ByRef CarpetaJudicialHipotecasInscripcionAno As Integer, _
                                          ByRef CarpetaJudicialHipotecasInscripcionCiudad As String, _
                                          ByRef CarpetaJudicialHipotecasFojas As String, _
                                          ByRef CarpetaJudicialHipotecasNumero As String, _
                                          ByRef CarpetaJudicialHipotecasAno As Integer, _
                                          ByRef CarpetaJudicialHipotecasCiudad As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialCodigo, CarpetaJudicialHipotecasSecuencia, CarpetaJudicialHipotecasDescription, CarpetaJudicialHipotecasInscripcionFojas, CarpetaJudicialHipotecasInscripcionNumero, CarpetaJudicialHipotecasInscripcionAno, CarpetaJudicialHipotecasInscripcionCiudad, CarpetaJudicialHipotecasFojas, CarpetaJudicialHipotecasNumero, CarpetaJudicialHipotecasAno, CarpetaJudicialHipotecasCiudad "
        sSQL = sSQL & "FROM CarpetaJudicialHipotecas "
        sSQL = sSQL & "WHERE CarpetaJudicialHipotecas.CarpetaJudicialHipotecasId = " & CarpetaJudicialHipotecasId
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CarpetaJudicialCodigo = CStr(dtr("CarpetaJudicialCodigo").ToString)
                If Len(dtr("CarpetaJudicialHipotecasSecuencia").ToString) = 0 Then
                    CarpetaJudicialHipotecasSecuencia = 0
                Else
                    CarpetaJudicialHipotecasSecuencia = CLng(dtr("CarpetaJudicialHipotecasSecuencia").ToString)
                End If
                CarpetaJudicialHipotecasDescription = CStr(dtr("CarpetaJudicialHipotecasDescription").ToString)
                CarpetaJudicialHipotecasInscripcionFojas = CStr(dtr("CarpetaJudicialHipotecasInscripcionFojas").ToString)
                CarpetaJudicialHipotecasInscripcionNumero = CStr(dtr("CarpetaJudicialHipotecasInscripcionNumero").ToString)
                CarpetaJudicialHipotecasInscripcionCiudad = CStr(dtr("CarpetaJudicialHipotecasInscripcionCiudad").ToString)
                If Len(dtr("CarpetaJudicialHipotecasInscripcionAno").ToString) = 0 Then
                    CarpetaJudicialHipotecasInscripcionAno = 0
                Else
                    CarpetaJudicialHipotecasInscripcionAno = CLng(dtr("CarpetaJudicialHipotecasInscripcionAno").ToString)
                End If
                CarpetaJudicialHipotecasFojas = CStr(dtr("CarpetaJudicialHipotecasFojas").ToString)
                CarpetaJudicialHipotecasNumero = CStr(dtr("CarpetaJudicialHipotecasNumero").ToString)
                CarpetaJudicialHipotecasCiudad = CStr(dtr("CarpetaJudicialHipotecasCiudad").ToString)
                If Len(dtr("CarpetaJudicialHipotecasAno").ToString) = 0 Then
                    CarpetaJudicialHipotecasAno = 0
                Else
                    CarpetaJudicialHipotecasAno = CLng(dtr("CarpetaJudicialHipotecasAno").ToString)
                End If
            End While
            LeerCarpetaJudicialHipotecas = True
            dtr.Close()
        Catch
            LeerCarpetaJudicialHipotecas = False
        End Try
    End Function
    Public Function CarpetaJudicialHipotecasUpdate(ByVal CarpetaJudicialHipotecasId As Long, ByVal CarpetaJudicialCodigo As String, _
                                            ByVal CarpetaJudicialHipotecasSecuencia As Long, _
                                            ByVal CarpetaJudicialHipotecasDescription As String, _
                                            ByVal CarpetaJudicialHipotecasInscripcionFojas As String, _
                                            ByVal CarpetaJudicialHipotecasInscripcionNumero As String, _
                                            ByVal CarpetaJudicialHipotecasInscripcionAno As Integer, _
                                            ByVal CarpetaJudicialHipotecasInscripcionCiudad As String, _
                                            ByVal CarpetaJudicialHipotecasFojas As String, _
                                            ByVal CarpetaJudicialHipotecasNumero As String, _
                                            ByVal CarpetaJudicialHipotecasAno As Integer, _
                                            ByVal CarpetaJudicialHipotecasCiudad As String, _
                                            ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas
        Dim t As Integer = 0
        Dim TareasId As Long = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
        Dim TareasCodigo As String = ""
        Dim b As Boolean
        b = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)
        Dim UserIdCodigo As String = ""
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(TareasId)
        Dim TareasLogActividad As String = ""

        TareasLogActividad = "Registra Hipoteca: " & CarpetaJudicialHipotecasDescription

        strUpdate = "UPDATE CarpetaJudicialHipotecas SET "
        strUpdate = strUpdate & "CarpetaJudicialHipotecas.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialHipotecas.CarpetaJudicialHipotecasSecuencia = " & CarpetaJudicialHipotecasSecuencia & ", "
        strUpdate = strUpdate & "CarpetaJudicialHipotecas.CarpetaJudicialHipotecasDescription = '" & CarpetaJudicialHipotecasDescription & "', "
        strUpdate = strUpdate & "CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionFojas = '" & CarpetaJudicialHipotecasInscripcionFojas & "', "
        strUpdate = strUpdate & "CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionNumero = '" & CarpetaJudicialHipotecasInscripcionNumero & "', "
        strUpdate = strUpdate & "CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionAno = " & CarpetaJudicialHipotecasInscripcionAno & ", "
        strUpdate = strUpdate & "CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionCiudad = '" & CarpetaJudicialHipotecasInscripcionCiudad & "', "
        strUpdate = strUpdate & "CarpetaJudicialHipotecas.CarpetaJudicialHipotecasFojas = '" & CarpetaJudicialHipotecasFojas & "', "
        strUpdate = strUpdate & "CarpetaJudicialHipotecas.CarpetaJudicialHipotecasNumero = '" & CarpetaJudicialHipotecasNumero & "', "
        strUpdate = strUpdate & "CarpetaJudicialHipotecas.CarpetaJudicialHipotecasAno = " & CarpetaJudicialHipotecasAno & ", "
        strUpdate = strUpdate & "CarpetaJudicialHipotecas.CarpetaJudicialHipotecasCiudad = '" & CarpetaJudicialHipotecasCiudad & "', "
        strUpdate = strUpdate & "CarpetaJudicialHipotecas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicialHipotecas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicialHipotecas.CarpetaJudicialHipotecasId = " & CarpetaJudicialHipotecasId
        Try
            CarpetaJudicialHipotecasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & CarpetaJudicialCodigo, CarpetaJudicialHipotecasId, "CarpetaJudicialHipotecas", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CarpetaJudicialHipotecasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TareasCodigo, CarpetaJudicialHipotecasId, "CarpetaJudicialHipotecas", "")
        End Try
    End Function
    Public Function CarpetaJudicialHipotecasInsert(ByRef CarpetaJudicialHipotecasId As Long, ByVal CarpetaJudicialCodigo As String, _
                                            ByVal CarpetaJudicialHipotecasSecuencia As Long, _
                                            ByVal CarpetaJudicialHipotecasDescription As String, _
                                            ByVal CarpetaJudicialHipotecasInscripcionFojas As String, _
                                            ByVal CarpetaJudicialHipotecasInscripcionNumero As String, _
                                            ByVal CarpetaJudicialHipotecasInscripcionAno As Integer, _
                                            ByVal CarpetaJudicialHipotecasInscripcionCiudad As String, _
                                            ByVal CarpetaJudicialHipotecasFojas As String, _
                                            ByVal CarpetaJudicialHipotecasNumero As String, _
                                            ByVal CarpetaJudicialHipotecasAno As Integer, _
                                            ByVal CarpetaJudicialHipotecasCiudad As String, _
                                            ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim CarpetaJudicialHipotecas As New CarpetaJudicialHipotecas
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = CarpetaJudicialCodigo
            DetailSecuencia = CarpetaJudicialHipotecasSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("CarpetaJudicialHipotecasId", "CarpetaJudicialCodigo", "CarpetaJudicialHipotecasSecuencia", "CarpetaJudicialHipotecas", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("CarpetaJudicialHipotecasId", "CarpetaJudicialCodigo", "CarpetaJudicialHipotecasSecuencia", "CarpetaJudicialHipotecas", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            CarpetaJudicialHipotecasInsert = CarpetaJudicialHipotecas.CarpetaJudicialHipotecasUpdate(DetailId, CStr(CarpetaJudicialCodigo), CLng(CarpetaJudicialHipotecasSecuencia), CStr(CarpetaJudicialHipotecasDescription), CarpetaJudicialHipotecasInscripcionFojas, CarpetaJudicialHipotecasInscripcionNumero, CarpetaJudicialHipotecasInscripcionAno, CarpetaJudicialHipotecasInscripcionCiudad, CarpetaJudicialHipotecasFojas, CarpetaJudicialHipotecasNumero, CarpetaJudicialHipotecasAno, CarpetaJudicialHipotecasCiudad, UserId)
        Catch
            CarpetaJudicialHipotecasInsert = 0
        End Try
    End Function
    Public Function CarpetaJudicialHipotecasDelete(ByVal CarpetaJudicialHipotecasId As Long, ByVal CarpetaJudicialCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim CarpetaJudicialHipotecas As New CarpetaJudicialHipotecas
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim t As Integer
        Dim TareasId As Long = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
        Dim TareasCodigo As String = ""
        Dim b As Boolean
        b = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)
        Dim UserIdCodigo As String = ""
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(TareasId)
        Dim TareasLogActividad As String = ""

        TareasLogActividad = "Elimina Hipoteca: " & CarpetaJudicialHipotecas.LeerCarpetaJudicialHipotecasNombre(CarpetaJudicialHipotecasId)

        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM CarpetaJudicialHipotecas "
        strUpdate = strUpdate & "WHERE CarpetaJudicialHipotecas.CarpetaJudicialHipotecasId = " & CarpetaJudicialHipotecasId & ") "

        Try
            CarpetaJudicialHipotecasDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina una hipoteca asociada a la Carpeta: " & CarpetaJudicialCodigo, CarpetaJudicialHipotecasId, "CarpetaJudicialHipotecas", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CarpetaJudicialHipotecasDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar un bien asociada a la Carpeta: " & CarpetaJudicialCodigo, CarpetaJudicialHipotecasId, "CarpetaJudicialHipotecas", "")
        End Try
    End Function
    Public Function LeerCarpetaJudicialHipotecasNombre(ByVal CarpetaJudicialHipotecasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialHipotecasDescription "
        sSQL = sSQL & "FROM CarpetaJudicialHipotecas "
        sSQL = sSQL & "WHERE (CarpetaJudicialHipotecas.CarpetaJudicialHipotecasId = " & CarpetaJudicialHipotecasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerCarpetaJudicialHipotecasNombre = CStr(dtr("CarpetaJudicialHipotecasDescription").ToString)
            End While
            LeerCarpetaJudicialHipotecasNombre = True
            dtr.Close()
        Catch
            LeerCarpetaJudicialHipotecasNombre = False
        End Try
    End Function
    Public Function LeerLasHipotecas(ByVal CarpetaJudicialCodigo As String, ByVal Accion As Integer) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String = ""
        Dim CarpetaJudicial As New CarpetaJudicial

        LeerLasHipotecas = ""

        Select Case Accion
            Case 1

                strUpdate = "SELECT CarpetaJudicialHipotecas.CarpetaJudicialHipotecasId As Id, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasDescription As Description, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionFojas AS InmuebleFojas, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionNumero AS InmuebleNumero, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionAno AS InmuebleAno, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionCiudad AS InmuebleCiudad, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasFojas AS HipotecaFojas, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasNumero AS HipotecaNumero, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasAno AS HipotecaAno, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasCiudad AS HipotecaCiudad "
                strUpdate = strUpdate & "FROM CarpetaJudicialHipotecas  "
                strUpdate = strUpdate & "WHERE CarpetaJudicialHipotecas.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' "

                Try
                    dtr = AccesoEA.ListarRegistros(strUpdate)
                    While dtr.Read
                        CodigoHTML = CodigoHTML & "<p>" & dtr("Description").ToString & "</p>"
                        CodigoHTML = CodigoHTML & "<p>El inmueble est&aacute; inscrito a fojas " & dtr("InmuebleFojas").ToString & " N&uacute;mero " & dtr("InmuebleNumero").ToString & " del Registro de propiedad del a&ntilde;o " & dtr("InmuebleAno").ToString & " en el Conservador de Bienes Ra&iacute;ces  de " & dtr("InmuebleCiudad").ToString & ". La hipoteca constituida a favor del banco Scotiabank está inscrita a fojas " & dtr("HipotecaFojas").ToString & " N&uacute;mero " & dtr("HipotecaNumero").ToString & " del Registro de Hipotecas y Grav&aacute;menes del a&ntilde;o " & dtr("HipotecaAno").ToString & " en el citado Conservador de Bienes Ra&iacute;ces como se acredita con la copia autorizada que se acompa&ntilde;a en el primer otros&iacute;.</p>"
                    End While
                    dtr.Close()
                Catch
                    CodigoHTML = ""
                End Try

        End Select

        LeerLasHipotecas = CodigoHTML

    End Function
    Public Function TotalHipotecas(ByVal CarpetaJudicialCodigo As String) As Integer
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim strUpdate As String = ""

        TotalHipotecas = 0

        strUpdate = "SELECT Count(*) As Total "
        strUpdate = strUpdate & "FROM CarpetaJudicialHipotecas  "
        strUpdate = strUpdate & "WHERE CarpetaJudicialHipotecas.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' "
        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                TotalHipotecas = CInt(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            TotalHipotecas = 0
        End Try
    End Function
    Public Function ListarHipotecas(ByVal CarpetaJudicialCodigo As String, Optional ByVal Clase As String = "invisible", Optional ByVal Formato As String = "CodigoHTML") As String
        Dim CodigoHTML As String = ""
        Dim CarpetaJudicialHipotecas As New CarpetaJudicialHipotecas
        Dim Direcciones(15) As String
        Dim NumeroDirecciones As Integer = CarpetaJudicialHipotecas.LeerDatosHipotecas(CarpetaJudicialCodigo, Direcciones)
        Dim i As Integer
        ListarHipotecas = ""

        If NumeroDirecciones > 0 Then
            If Formato = "CodigoHTML" Then
                CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td><h1>" & "Hipotecas del deudor" & "</h1></td>"
                CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & "Hipotecas" & "')"" /></td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "</table>"
                CodigoHTML = CodigoHTML & "<div id=""subgrilla" & "Hipotecas" & """ class=""" & Clase & """>"
                CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
            Else
                CodigoHTML = CodigoHTML & "<table width=""660"" border=""1"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Verdana;font-size:8pt;border:1px solid #FFFFFF;"">"
            End If
            For i = 0 To NumeroDirecciones
                CodigoHTML = CodigoHTML & Direcciones(i)
            Next
            CodigoHTML = CodigoHTML & "</table>"
            If Formato = "CodigoHTML" Then
                CodigoHTML = CodigoHTML & "</div>"
            End If
        End If

        ListarHipotecas = CodigoHTML
    End Function
    Public Function LeerDatosHipotecas(ByVal CarpetaJudicialCodigo As String, ByRef Direcciones() As String) As Integer

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim CarpetaJudicialHipotecas As New CarpetaJudicialHipotecas

        sSQL = "Select CarpetaJudicialHipotecasId as Id, CarpetaJudicialHipotecasDescription As Descripcion, CarpetaJudicialHipotecasInscripcionFojas As Fojas, CarpetaJudicialHipotecasInscripcionNumero As Numero, CarpetaJudicialHipotecasInscripcionAno As Ano, CarpetaJudicialHipotecasInscripcionCiudad As Ciudad "
        sSQL = sSQL & "FROM CarpetaJudicialHipotecas "
        sSQL = sSQL & "WHERE CarpetaJudicialHipotecas.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' "
        sSQL = sSQL & "ORDER BY CarpetaJudicialHipotecas.CarpetaJudicialHipotecasSecuencia"

        Dim CodigoHTML As String = ""

        LeerDatosHipotecas = 0

        Direcciones(0) = "<tr><th align=""left"">Descripción</th><th align=""left"">Fojas</th><th align=""left"">Número</th><th align=""left"">Año</th><th align=""left"">Ciudad</th><th align=""left"">Operaciones</th></tr>"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                Direcciones(i) = "<tr><td>" & dtr("Descripcion").ToString & "</td><td>" & dtr("Fojas").ToString & "</td><td>" & dtr("Numero").ToString & "</td><td>" & dtr("Ano").ToString & "</td><td>" & dtr("Ciudad").ToString & "</td>"
                Direcciones(i) = Direcciones(i) & "<td>" & CarpetaJudicialHipotecas.LeerOperacionesPorHipotecas(CLng(dtr("Id").ToString)) & "</td></tr>"
            End While
            dtr.Close()
        Catch
            LeerDatosHipotecas = 0
        End Try


        LeerDatosHipotecas = i

    End Function

    Public Function LeerOperacionesPorHipotecas(ByVal CarpetaJudicialHipotecasId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0

        sSQL = "Select CarpetaJudicialCreditos.CarpetaJudicialCreditosNroOperacion As Operacion "
        sSQL = sSQL & "FROM CarpetaJudicialHipotecasPorCarpetaJudicialCreditos INNER JOIN CarpetaJudicialCreditos ON CarpetaJudicialHipotecasPorCarpetaJudicialCreditos.CarpetaJudicialCreditosId = CarpetaJudicialCreditos.CarpetaJudicialCreditosId "
        sSQL = sSQL & "WHERE (((CarpetaJudicialHipotecasPorCarpetaJudicialCreditos.CarpetaJudicialHipotecasId)=" & CarpetaJudicialHipotecasId & "))"

        Dim CodigoHTML As String = ""

        LeerOperacionesPorHipotecas = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & dtr("Operacion").ToString & "</br>"
            End While
            dtr.Close()
        Catch
            LeerOperacionesPorHipotecas = ""
        End Try

        LeerOperacionesPorHipotecas = CodigoHTML

    End Function


End Class
