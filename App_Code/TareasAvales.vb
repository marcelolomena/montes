'------------------------------------------------------------
' Código generado por ZRISMART SF el 20-04-2011 16:43:05
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class TareasAvales
    Public Function LeerTareasAvales(ByVal TareasAvalesId As Long, ByRef TareasCodigo As String, ByRef TareasAvalesSecuencia As Long, ByRef TareasAvalesRUT As String, ByRef TareasAvalesNombres As String, ByRef TareasAvalesApellidos As String, ByRef TareasAvalesDireccion As String, ByRef TareasAvalesComuna As String, ByRef TareasAvalesProfesion As String, ByRef TareasAvalesFechaEscritura As Date, ByRef TareasAvalesCiudadEscritura As String, ByRef TareasAvalesNotarioEscritura As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasCodigo, TareasAvalesSecuencia, TareasAvalesRUT, TareasAvalesNombres, TareasAvalesApellidos, TareasAvalesDireccion, TareasAvalesComuna, TareasAvalesProfesion, TareasAvalesFechaEscritura, TareasAvalesCiudadEscritura, TareasAvalesNotarioEscritura "
        sSQL = sSQL & "FROM (TareasAvales) "
        sSQL = sSQL & "WHERE (TareasAvales.TareasAvalesId = " & TareasAvalesId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TareasCodigo = CStr(dtr("TareasCodigo").ToString)
                If Len(dtr("TareasAvalesSecuencia").ToString) = 0 Then
                    TareasAvalesSecuencia = 0
                Else
                    TareasAvalesSecuencia = CLng(dtr("TareasAvalesSecuencia").ToString)
                End If
                TareasAvalesRUT = CStr(dtr("TareasAvalesRUT").ToString)
                TareasAvalesNombres = CStr(dtr("TareasAvalesNombres").ToString)
                TareasAvalesApellidos = CStr(dtr("TareasAvalesApellidos").ToString)
                TareasAvalesDireccion = CStr(dtr("TareasAvalesDireccion").ToString)
                TareasAvalesComuna = CStr(dtr("TareasAvalesComuna").ToString)
                TareasAvalesProfesion = CStr(dtr("TareasAvalesProfesion").ToString)
                If Len(dtr("TareasAvalesFechaEscritura").ToString) = 0 Then
                    TareasAvalesFechaEscritura = "01/01/01"
                Else
                    TareasAvalesFechaEscritura = CDate(dtr("TareasAvalesFechaEscritura").ToString)
                End If
                TareasAvalesCiudadEscritura = CStr(dtr("TareasAvalesCiudadEscritura").ToString)
                TareasAvalesNotarioEscritura = CStr(dtr("TareasAvalesNotarioEscritura").ToString)
            End While
            LeerTareasAvales = True
            dtr.Close()
        Catch
            LeerTareasAvales = False
        End Try
    End Function
    Public Function TareasAvalesUpdate(ByVal TareasAvalesId As Long, ByVal TareasCodigo As String, ByVal TareasAvalesSecuencia As Long, ByVal TareasAvalesRUT As String, ByVal TareasAvalesNombres As String, ByVal TareasAvalesApellidos As String, ByVal TareasAvalesDireccion As String, ByVal TareasAvalesComuna As String, ByVal TareasAvalesProfesion As String, ByVal TareasAvalesFechaEscritura As Date, ByVal TareasAvalesCiudadEscritura As String, ByVal TareasAvalesNotarioEscritura As String, ByVal UserId As Long) As Integer
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

        TareasLogActividad = "Registra Avales: " & TareasAvalesNombres & " " & TareasAvalesApellidos

        strUpdate = "UPDATE TareasAvales SET "
        strUpdate = strUpdate & "TareasAvales.TareasCodigo = '" & TareasCodigo & "', "
        strUpdate = strUpdate & "TareasAvales.TareasAvalesSecuencia = " & TareasAvalesSecuencia & ", "
        strUpdate = strUpdate & "TareasAvales.TareasAvalesRUT = '" & TareasAvalesRUT & "', "
        strUpdate = strUpdate & "TareasAvales.TareasAvalesNombres = '" & TareasAvalesNombres & "', "
        strUpdate = strUpdate & "TareasAvales.TareasAvalesApellidos = '" & TareasAvalesApellidos & "', "
        strUpdate = strUpdate & "TareasAvales.TareasAvalesDireccion = '" & TareasAvalesDireccion & "', "
        strUpdate = strUpdate & "TareasAvales.TareasAvalesComuna = '" & TareasAvalesComuna & "', "
        strUpdate = strUpdate & "TareasAvales.TareasAvalesProfesion = '" & TareasAvalesProfesion & "', "
        strUpdate = strUpdate & "TareasAvales.TareasAvalesFechaEscritura = '" & AccionesABM.DateTransform(TareasAvalesFechaEscritura) & "', "
        strUpdate = strUpdate & "TareasAvales.TareasAvalesCiudadEscritura = '" & TareasAvalesCiudadEscritura & "', "
        strUpdate = strUpdate & "TareasAvales.TareasAvalesNotarioEscritura = '" & TareasAvalesNotarioEscritura & "', "
        strUpdate = strUpdate & "TareasAvales.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "TareasAvales.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE TareasAvales.TareasAvalesId = " & TareasAvalesId
        Try
            TareasAvalesUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & TareasCodigo, TareasAvalesId, "TareasAvales", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasAvalesUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TareasCodigo, TareasAvalesId, "TareasAvales", "")
        End Try
    End Function
    Public Function TareasAvalesInsert(ByRef TareasAvalesId As Long, ByVal TareasCodigo As String, ByVal TareasAvalesSecuencia As Long, ByVal TareasAvalesRUT As String, ByVal TareasAvalesNombres As String, ByVal TareasAvalesApellidos As String, ByVal TareasAvalesDireccion As String, ByVal TareasAvalesComuna As String, ByVal TareasAvalesProfesion As String, ByVal TareasAvalesFechaEscritura As Date, ByVal TareasAvalesCiudadEscritura As String, ByVal TareasAvalesNotarioEscritura As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim TareasAvales As New TareasAvales
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = TareasCodigo
            DetailSecuencia = TareasAvalesSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("TareasAvalesId", "TareasCodigo", "TareasAvalesSecuencia", "TareasAvales", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("TareasAvalesId", "TareasCodigo", "TareasAvalesSecuencia", "TareasAvales", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            TareasAvalesInsert = TareasAvales.TareasAvalesUpdate(DetailId, CStr(TareasCodigo), CLng(TareasAvalesSecuencia), TareasAvalesRUT, CStr(TareasAvalesNombres), CStr(TareasAvalesApellidos), TareasAvalesDireccion, TareasAvalesComuna, TareasAvalesProfesion, CDate(TareasAvalesFechaEscritura), TareasAvalesCiudadEscritura, TareasAvalesNotarioEscritura, UserId)
        Catch
            TareasAvalesInsert = 0
        End Try
    End Function
    Public Function TareasAvalesDelete(ByVal TareasAvalesId As Long, ByVal TareasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim TareasAvales As New TareasAvales
        Dim t As Integer
        Dim TareasId As Long = 0
        Dim b As Boolean
        b = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        Dim UserIdCodigo As String = ""
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(TareasId)
        Dim TareasLogActividad As String = ""

        TareasLogActividad = "Elimina Aval: " & TareasAvales.LeerTareasAvalesNombre(TareasAvalesId)

        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (TareasAvales) "
        strUpdate = strUpdate & "WHERE (TareasAvales.TareasAvalesId = " & TareasAvalesId & ") "

        Try
            TareasAvalesDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Aval asociada a la Tarea: " & TareasCodigo, TareasAvalesId, "TareasAvales", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasAvalesDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar Aval asociada a la tarea: " & TareasCodigo, TareasAvalesId, "TareasAvales", "")
        End Try
    End Function
    Public Function LeerTareasAvalesNombre(ByVal TareasAvalesId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasAvalesNombres, TareasAvalesApellidos "
        sSQL = sSQL & "FROM TareasAvales "
        sSQL = sSQL & "WHERE (TareasAvales.TareasAvalesId = " & TareasAvalesId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTareasAvalesNombre = CStr(dtr("TareasAvalesNombres").ToString) & " " & CStr(dtr("TareasAvalesApellidos").ToString)
            End While
            LeerTareasAvalesNombre = True
            dtr.Close()
        Catch
            LeerTareasAvalesNombre = False
        End Try
    End Function
    Public Function LeerAvalesDemandados(ByVal TareasCodigo As String, ByVal Accion As Integer, Optional DeudaCapitalUF As Double = 0, Optional DeudaCapitalPesos As Double = 0, Optional DeudaDividendosUF As Double = 0, Optional DeudaDividendosPesos As Double = 0) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String = ""
        Dim Tareas As New Tareas
        Dim TareasAvalesFechaEscritura As Date = "01/01/01"

        LeerAvalesDemandados = ""

        Select Case Accion
            Case 1
                strUpdate = "SELECT TareasAvales.TareasAvalesId As Id, TareasAvales.TareasAvalesRUT as RUT, TareasAvales.TareasAvalesNombres As Nombres, TareasAvales.TareasAvalesApellidos as Apellidos "
                strUpdate = strUpdate & "FROM CarpetaJudicial INNER JOIN (TareasAvales INNER JOIN Tareas ON TareasAvales.TareasCodigo = Tareas.TareasCodigo) ON CarpetaJudicial.CarpetaJudicialCodigo = Tareas.PGGCodigo "
                strUpdate = strUpdate & "WHERE (((Tareas.PGGCodigo)='" & Tareas.LeerTareasPGGCodigo(TareasCodigo) & "'))"

                Try
                    dtr = AccesoEA.ListarRegistros(strUpdate)
                    While dtr.Read
                        CodigoHTML = CodigoHTML & "<tr><td><h1>DEMANDADO:</h1></td>"
                        CodigoHTML = CodigoHTML & "<td><h1><b>" & dtr("Nombres").ToString & " " & dtr("Apellidos").ToString & "</b></h1></td>"
                        CodigoHTML = CodigoHTML & "<td><h1><b>RUT " & dtr("RUT").ToString & "</b></h1></td>"
                        CodigoHTML = CodigoHTML & "</tr>"
                    End While
                    dtr.Close()
                Catch
                    CodigoHTML = ""
                End Try


                'Aqui tengo un problema que tengo que resolver, copie la acción 2 a la 3 y elimina una, por los tanto tengo que crear las acciones 2 y 3.
            Case 2
                strUpdate = "SELECT TareasAvales.TareasAvalesNombres As Nombres, TareasAvales.TareasAvalesApellidos as Apellidos, TareasAvales.TareasAvalesDireccion As Direccion, TareasAvales.TareasAvalesComuna As Comuna, TareasAvales.TareasAvalesProfesion As Profesion, TareasAvales.TareasAvalesFechaEscritura As Fecha, TareasAvales.TareasAvalesCiudadEscritura As Ciudad, TareasAvales.TareasAvalesNotarioEscritura As Notario "
                strUpdate = strUpdate & "FROM CarpetaJudicial INNER JOIN (TareasAvales INNER JOIN Tareas ON TareasAvales.TareasCodigo = Tareas.TareasCodigo) ON CarpetaJudicial.CarpetaJudicialCodigo = Tareas.PGGCodigo "
                strUpdate = strUpdate & "WHERE (((Tareas.PGGCodigo)='" & Tareas.LeerTareasPGGCodigo(TareasCodigo) & "'))"

                Try
                    dtr = AccesoEA.ListarRegistros(strUpdate)
                    While dtr.Read
                        CodigoHTML = CodigoHTML & "<p>En garantía de las obligaciones del deudor, don(ña) " & dtr("Nombres").ToString & " " & dtr("Apellidos").ToString & ", " & dtr("Profesion").ToString & ", domiciliado en " & dtr("Direccion").ToString & ", " & dtr("Comuna").ToString & " , se constituyo como codeudor solidario por escritura de " & FormatDateTime(CDate(dtr("Fecha").ToString), DateFormat.ShortDate) & ", en la notaria de don " & dtr("Notario").ToString & ", de " & dtr("Ciudad").ToString & "</p>"
                    End While
                    dtr.Close()
                Catch
                    CodigoHTML = ""
                End Try

            Case 3
                strUpdate = "SELECT TareasAvales.TareasAvalesNombres As Nombres, TareasAvales.TareasAvalesApellidos as Apellidos, TareasAvales.TareasAvalesDireccion As Direccion, TareasAvales.TareasAvalesComuna As Comuna, TareasAvales.TareasAvalesProfesion As Profesion "
                strUpdate = strUpdate & "FROM CarpetaJudicial INNER JOIN (TareasAvales INNER JOIN Tareas ON TareasAvales.TareasCodigo = Tareas.TareasCodigo) ON CarpetaJudicial.CarpetaJudicialCodigo = Tareas.PGGCodigo "
                strUpdate = strUpdate & "WHERE (((Tareas.PGGCodigo)='" & Tareas.LeerTareasPGGCodigo(TareasCodigo) & "'))"

                Try
                    dtr = AccesoEA.ListarRegistros(strUpdate)
                    While dtr.Read
                        CodigoHTML = CodigoHTML & "<p>Igualmente demando a don(ña) " & dtr("Nombres").ToString & " " & dtr("Apellidos").ToString & ", " & dtr("Profesion").ToString & ", domiciliado en " & dtr("Direccion").ToString & ", " & dtr("Comuna").ToString & ", por " & FormatNumber(DeudaCapitalUF / 100, 2) & " UF equivalente a " & FormatNumber(DeudaCapitalPesos / 100, 2) & " PESOS por concepto de capital y de " & FormatNumber(DeudaDividendosUF / 100, 2) & " UF equivalente a " & FormatNumber(DeudaDividendosPesos / 100, 2) & " PESOS por concepto de dividendos impagos, más los  interses pactados y los intereses penales o moratorios que se han indicado.</p>"
                    End While
                    dtr.Close()
                Catch
                    CodigoHTML = ""
                End Try

            Case 4
                strUpdate = "SELECT TareasAvales.TareasAvalesNombres As Nombres, TareasAvales.TareasAvalesApellidos as Apellidos "
                strUpdate = strUpdate & "FROM CarpetaJudicial INNER JOIN (TareasAvales INNER JOIN Tareas ON TareasAvales.TareasCodigo = Tareas.TareasCodigo) ON CarpetaJudicial.CarpetaJudicialCodigo = Tareas.PGGCodigo "
                strUpdate = strUpdate & "WHERE (((Tareas.PGGCodigo)='" & Tareas.LeerTareasPGGCodigo(TareasCodigo) & "'))"

                Try
                    dtr = AccesoEA.ListarRegistros(strUpdate)
                    While dtr.Read
                        CodigoHTML = CodigoHTML & " y de don(ña) " & dtr("Nombres").ToString & " " & dtr("Apellidos").ToString
                    End While
                    dtr.Close()
                Catch
                    CodigoHTML = ""
                End Try

                If Len(CodigoHTML) > 0 Then
                    CodigoHTML = CodigoHTML & ", ya individualizados, "
                Else
                    CodigoHTML = CodigoHTML & ", ya individualizado, "
                End If

        End Select

        LeerAvalesDemandados = CodigoHTML

    End Function

End Class
