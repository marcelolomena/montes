'------------------------------------------------------------
' Código generado por ZRISMART SF el 20-04-2011 16:43:05
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class CarpetaJudicialAvales
    Public Function LeerCarpetaJudicialAvales(ByVal CarpetaJudicialAvalesId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialAvalesSecuencia As Long, ByRef CarpetaJudicialAvalesRUT As String, ByRef CarpetaJudicialAvalesNombres As String, ByRef CarpetaJudicialAvalesApellidos As String, ByRef CarpetaJudicialAvalesDireccion As String, ByRef CarpetaJudicialAvalesComuna As String, ByRef CarpetaJudicialAvalesProfesion As String, ByRef CarpetaJudicialAvalesIsReciproco As Boolean) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialCodigo, CarpetaJudicialAvalesSecuencia, CarpetaJudicialAvalesRUT, CarpetaJudicialAvalesNombres, CarpetaJudicialAvalesApellidos, CarpetaJudicialAvalesDireccion, CarpetaJudicialAvalesComuna, CarpetaJudicialAvalesProfesion, CarpetaJudicialAvalesIsReciproco "
        sSQL = sSQL & "FROM CarpetaJudicialAvales "
        sSQL = sSQL & "WHERE (CarpetaJudicialAvales.CarpetaJudicialAvalesId = " & CarpetaJudicialAvalesId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CarpetaJudicialCodigo = CStr(dtr("CarpetaJudicialCodigo").ToString)
                If Len(dtr("CarpetaJudicialAvalesSecuencia").ToString) = 0 Then
                    CarpetaJudicialAvalesSecuencia = 0
                Else
                    CarpetaJudicialAvalesSecuencia = CLng(dtr("CarpetaJudicialAvalesSecuencia").ToString)
                End If
                CarpetaJudicialAvalesRUT = CStr(dtr("CarpetaJudicialAvalesRUT").ToString)
                CarpetaJudicialAvalesNombres = CStr(dtr("CarpetaJudicialAvalesNombres").ToString)
                CarpetaJudicialAvalesApellidos = CStr(dtr("CarpetaJudicialAvalesApellidos").ToString)
                CarpetaJudicialAvalesDireccion = CStr(dtr("CarpetaJudicialAvalesDireccion").ToString)
                CarpetaJudicialAvalesComuna = CStr(dtr("CarpetaJudicialAvalesComuna").ToString)
                CarpetaJudicialAvalesProfesion = CStr(dtr("CarpetaJudicialAvalesProfesion").ToString)
                CarpetaJudicialAvalesIsReciproco = CBool(dtr("CarpetaJudicialAvalesIsReciproco").ToString)
            End While
            LeerCarpetaJudicialAvales = True
            dtr.Close()
        Catch
            LeerCarpetaJudicialAvales = False
        End Try
    End Function
    Public Function CarpetaJudicialAvalesUpdate(ByVal CarpetaJudicialAvalesId As Long, ByVal CarpetaJudicialCodigo As String, ByVal CarpetaJudicialAvalesSecuencia As Long, ByVal CarpetaJudicialAvalesRUT As String, ByVal CarpetaJudicialAvalesNombres As String, ByVal CarpetaJudicialAvalesApellidos As String, ByVal CarpetaJudicialAvalesDireccion As String, ByVal CarpetaJudicialAvalesComuna As String, ByVal CarpetaJudicialAvalesProfesion As String, ByVal CarpetaJudicialAvalesIsREciproco As Boolean, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim Tareas As New Tareas
        Dim CarpetaJudicial As New CarpetaJudicial
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

        TareasLogActividad = "Registra Avales: " & CarpetaJudicialAvalesNombres & " " & CarpetaJudicialAvalesApellidos

        strUpdate = "UPDATE CarpetaJudicialAvales SET "
        strUpdate = strUpdate & "CarpetaJudicialAvales.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialAvales.CarpetaJudicialAvalesSecuencia = " & CarpetaJudicialAvalesSecuencia & ", "
        strUpdate = strUpdate & "CarpetaJudicialAvales.CarpetaJudicialAvalesRUT = '" & CarpetaJudicialAvalesRUT & "', "
        strUpdate = strUpdate & "CarpetaJudicialAvales.CarpetaJudicialAvalesNombres = '" & CarpetaJudicialAvalesNombres & "', "
        strUpdate = strUpdate & "CarpetaJudicialAvales.CarpetaJudicialAvalesApellidos = '" & CarpetaJudicialAvalesApellidos & "', "
        strUpdate = strUpdate & "CarpetaJudicialAvales.CarpetaJudicialAvalesDireccion = '" & CarpetaJudicialAvalesDireccion & "', "
        strUpdate = strUpdate & "CarpetaJudicialAvales.CarpetaJudicialAvalesComuna = '" & CarpetaJudicialAvalesComuna & "', "
        strUpdate = strUpdate & "CarpetaJudicialAvales.CarpetaJudicialAvalesProfesion = '" & CarpetaJudicialAvalesProfesion & "', "
        strUpdate = strUpdate & "CarpetaJudicialAvales.CarpetaJudicialAvalesIsReciproco = " & CBool(CarpetaJudicialAvalesIsREciproco) & ", "
        strUpdate = strUpdate & "CarpetaJudicialAvales.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicialAvales.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicialAvales.CarpetaJudicialAvalesId = " & CarpetaJudicialAvalesId
        Try
            CarpetaJudicialAvalesUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & CarpetaJudicialCodigo, CarpetaJudicialAvalesId, "CarpetaJudicialAvales", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CarpetaJudicialAvalesUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & CarpetaJudicialCodigo, CarpetaJudicialAvalesId, "CarpetaJudicialAvales", "")
        End Try
    End Function
    Public Function CarpetaJudicialAvalesInsert(ByRef CarpetaJudicialAvalesId As Long, ByVal CarpetaJudicialCodigo As String, ByVal CarpetaJudicialAvalesSecuencia As Long, ByVal CarpetaJudicialAvalesRUT As String, ByVal CarpetaJudicialAvalesNombres As String, ByVal CarpetaJudicialAvalesApellidos As String, ByVal CarpetaJudicialAvalesDireccion As String, ByVal CarpetaJudicialAvalesComuna As String, ByVal CarpetaJudicialAvalesProfesion As String, ByVal CarpetaJudicialAvalesFechaEscritura As Date, ByVal CarpetaJudicialAvalesIsReciproco As Boolean, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim CarpetaJudicialAvales As New CarpetaJudicialAvales
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = CarpetaJudicialCodigo
            DetailSecuencia = CarpetaJudicialAvalesSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("CarpetaJudicialAvalesId", "CarpetaJudicialCodigo", "CarpetaJudicialAvalesSecuencia", "CarpetaJudicialAvales", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("CarpetaJudicialAvalesId", "CarpetaJudicialCodigo", "CarpetaJudicialAvalesSecuencia", "CarpetaJudicialAvales", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            CarpetaJudicialAvalesInsert = CarpetaJudicialAvales.CarpetaJudicialAvalesUpdate(DetailId, CStr(CarpetaJudicialCodigo), CLng(CarpetaJudicialAvalesSecuencia), CarpetaJudicialAvalesRUT, CStr(CarpetaJudicialAvalesNombres), CStr(CarpetaJudicialAvalesApellidos), CarpetaJudicialAvalesDireccion, CarpetaJudicialAvalesComuna, CarpetaJudicialAvalesProfesion, CBool(CarpetaJudicialAvalesIsReciproco), UserId)
        Catch
            CarpetaJudicialAvalesInsert = 0
        End Try
    End Function
    Public Function CarpetaJudicialAvalesDelete(ByVal CarpetaJudicialAvalesId As Long, ByVal CarpetaJudicialCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim CarpetaJudicialAvales As New CarpetaJudicialAvales
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

        TareasLogActividad = "Elimina Aval: " & CarpetaJudicialAvales.LeerCarpetaJudicialAvalesNombre(CarpetaJudicialAvalesId)

        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (CarpetaJudicialAvales) "
        strUpdate = strUpdate & "WHERE (CarpetaJudicialAvales.CarpetaJudicialAvalesId = " & CarpetaJudicialAvalesId & ") "

        Try
            CarpetaJudicialAvalesDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Aval asociada a la Carpeta: " & CarpetaJudicialCodigo, CarpetaJudicialAvalesId, "CarpetaJudicialAvales", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CarpetaJudicialAvalesDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar Aval asociada a la tarea: " & CarpetaJudicialCodigo, CarpetaJudicialAvalesId, "CarpetaJudicialAvales", "")
        End Try
    End Function
    Public Function LeerCarpetaJudicialAvalesNombre(ByVal CarpetaJudicialAvalesId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialAvalesNombres, CarpetaJudicialAvalesApellidos "
        sSQL = sSQL & "FROM CarpetaJudicialAvales "
        sSQL = sSQL & "WHERE (CarpetaJudicialAvales.CarpetaJudicialAvalesId = " & CarpetaJudicialAvalesId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerCarpetaJudicialAvalesNombre = CStr(dtr("CarpetaJudicialAvalesNombres").ToString) & " " & CStr(dtr("CarpetaJudicialAvalesApellidos").ToString)
            End While
            LeerCarpetaJudicialAvalesNombre = True
            dtr.Close()
        Catch
            LeerCarpetaJudicialAvalesNombre = False
        End Try
    End Function
    Public Function LeerAvalesDemandados(ByVal CarpetaJudicialCodigo As String, ByVal Accion As Integer, Optional DeudaCapitalUF As Double = 0, Optional DeudaCapitalPesos As Double = 0, Optional DeudaDividendosUF As Double = 0, Optional DeudaDividendosPesos As Double = 0) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String = ""
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim CarpetaJudicialAvalesFechaEscritura As Date = "01/01/01"

        LeerAvalesDemandados = ""

        Select Case Accion
            Case 1
                strUpdate = "SELECT CarpetaJudicialAvales.CarpetaJudicialAvalesId As Id, CarpetaJudicialAvales.CarpetaJudicialAvalesRUT as RUT, CarpetaJudicialAvales.CarpetaJudicialAvalesNombres As Nombres, CarpetaJudicialAvales.CarpetaJudicialAvalesApellidos as Apellidos "
                strUpdate = strUpdate & "FROM CarpetaJudicialAvales "
                strUpdate = strUpdate & "WHERE CarpetaJudicialAvales.CarpetaJudicialCodigo)='" & CarpetaJudicialCodigo & "'))"

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
                strUpdate = "SELECT CarpetaJudicialAvales.CarpetaJudicialAvalesNombres As Nombres, CarpetaJudicialAvales.CarpetaJudicialAvalesApellidos as Apellidos, CarpetaJudicialAvales.CarpetaJudicialAvalesDireccion As Direccion, CarpetaJudicialAvales.CarpetaJudicialAvalesComuna As Comuna, CarpetaJudicialAvales.CarpetaJudicialAvalesProfesion As Profesion, CarpetaJudicialAvales.CarpetaJudicialAvalesIsReciproco As Reciproco "
                strUpdate = strUpdate & "FROM CarpetaJudicialAvales "
                strUpdate = strUpdate & "WHERE CarpetaJudicialAvales.CarpetaJudicialCodigo)='" & CarpetaJudicialCodigo & "'))"

                Try
                    dtr = AccesoEA.ListarRegistros(strUpdate)
                    While dtr.Read
                        CodigoHTML = CodigoHTML & "<p>En garantía de las obligaciones del deudor, don(ña) " & dtr("Nombres").ToString & " " & dtr("Apellidos").ToString & ", " & dtr("Profesion").ToString & ", domiciliado en " & dtr("Direccion").ToString & ", " & dtr("Comuna").ToString & " , se constituyo como codeudor solidario por escritura de </p>" ' & FormatDateTime(CDate(dtr("Fecha").ToString), DateFormat.ShortDate) & ", en la notaria de don " & dtr("Notario").ToString & ", de " & dtr("Ciudad").ToString & "</p>"
                    End While
                    dtr.Close()
                Catch
                    CodigoHTML = ""
                End Try

            Case 3
                strUpdate = "SELECT CarpetaJudicialAvales.CarpetaJudicialAvalesNombres As Nombres, CarpetaJudicialAvales.CarpetaJudicialAvalesApellidos as Apellidos, CarpetaJudicialAvales.CarpetaJudicialAvalesDireccion As Direccion, CarpetaJudicialAvales.CarpetaJudicialAvalesComuna As Comuna, CarpetaJudicialAvales.CarpetaJudicialAvalesProfesion As Profesion "
                strUpdate = strUpdate & "FROM CarpetaJudicialAvales "
                strUpdate = strUpdate & "WHERE CarpetaJudicialAvales.CarpetaJudicialCodigo)='" & CarpetaJudicialCodigo & "'))"

                Try
                    dtr = AccesoEA.ListarRegistros(strUpdate)
                    While dtr.Read
                        CodigoHTML = CodigoHTML & "<p>Igualmente demando a don(ña) " & dtr("Nombres").ToString & " " & dtr("Apellidos").ToString & ", " & dtr("Profesion").ToString & ", domiciliado en " & dtr("Direccion").ToString & ", " & dtr("Comuna").ToString & ", por " & FormatNumber(DeudaCapitalUF / 10000, 4) & " UF equivalente a " & FormatNumber(DeudaCapitalPesos / 10000, 4) & " PESOS por concepto de capital y de " & FormatNumber(DeudaDividendosUF / 10000, 4) & " UF equivalente a " & FormatNumber(DeudaDividendosPesos / 10000, 4) & " PESOS por concepto de dividendos impagos, más los  interses pactados y los intereses penales o moratorios que se han indicado.</p>"
                    End While
                    dtr.Close()
                Catch
                    CodigoHTML = ""
                End Try

            Case 4
                strUpdate = "SELECT CarpetaJudicialAvales.CarpetaJudicialAvalesNombres As Nombres, CarpetaJudicialAvales.CarpetaJudicialAvalesApellidos as Apellidos "
                strUpdate = strUpdate & "FROM CarpetaJudicialAvales "
                strUpdate = strUpdate & "WHERE (((CarpetaJudicialAvales.CarpetaJudicialCodigo)='" & CarpetaJudicialCodigo & "'))"

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
    Public Function TotalAvales(ByVal CarpetaJudicialCodigo As String) As Integer
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim strUpdate As String = ""

        TotalAvales = 0

        strUpdate = "SELECT Count(*) As Total "
        strUpdate = strUpdate & "FROM CarpetaJudicialAvales  "
        strUpdate = strUpdate & "WHERE CarpetaJudicialAvales.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' AND CarpetaJudicialAvales.CarpetaJudicialAvalesIsReciproco = True "
        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                TotalAvales = CInt(dtr("Total").ToString) + 1
            End While
            dtr.Close()
        Catch
            TotalAvales = 0
        End Try


    End Function
    Public Function ListarAvales(ByVal CarpetaJudicialCodigo As String, Optional ByVal Clase As String = "invisible", Optional ByVal Formato As String = "CodigoHTML") As String
        Dim CodigoHTML As String = ""
        Dim CarpetaJudicialAvales As New CarpetaJudicialAvales
        Dim Direcciones(15) As String
        Dim NumeroDirecciones As Integer = CarpetaJudicialAvales.LeerDatosAvales(CarpetaJudicialCodigo, Direcciones)
        Dim i As Integer
        ListarAvales = ""

        If NumeroDirecciones > 0 Then

            If Formato = "CodigoHTML" Then
                CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td><h1>" & "Avales del deudor" & "</h1></td>"
                CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & "Avales" & "')"" /></td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "</table>"
                CodigoHTML = CodigoHTML & "<div id=""subgrilla" & "Avales" & """ class=""" & Clase & """>"
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

        ListarAvales = CodigoHTML
    End Function
    Public Function LeerDatosAvales(ByVal CarpetaJudicialCodigo As String, ByRef Direcciones() As String) As Integer

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim CarpetaJudicialAvales As New CarpetaJudicialAvales

        sSQL = "Select CarpetaJudicialAvalesId as Id, CarpetaJudicialAvalesSecuencia, CarpetaJudicialAvalesRUT As RUT, CarpetaJudicialAvalesNombres As Nombres, CarpetaJudicialAvalesApellidos As Apellidos, CarpetaJudicialAvalesDireccion As Direccion, CarpetaJudicialAvalesComuna As Comuna, CarpetaJudicialAvalesProfesion As Profesion, CarpetaJudicialAvalesIsReciproco As Reciproco "
        sSQL = sSQL & "FROM CarpetaJudicialAvales "
        sSQL = sSQL & "WHERE CarpetaJudicialAvales.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' "
        sSQL = sSQL & "ORDER BY CarpetaJudicialAvales.CarpetaJudicialAvalesSecuencia"

        Dim CodigoHTML As String = ""

        LeerDatosAvales = 0

        Direcciones(0) = "<tr><th align=""left"" width=""100"">RUT</th><th align=""left"" width=""100"">Nombres</th><th align=""left"" width=""100"">Apellidos</th><th align=""left"" width=""100"">Dirección</th><th align=""left"" width=""100"">Profesión</th><th align=""left"">Es recíproco?</th><th align=""left"">Operaciones</th></tr>"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                Direcciones(i) = "<tr><td>" & dtr("RUT").ToString & "</td><td>" & dtr("Nombres").ToString & "</td><td>" & dtr("Apellidos").ToString & "</td><td>" & dtr("Direccion").ToString & "</td><td>" & dtr("Profesion").ToString & "</td>"
                If CBool(dtr("Reciproco").ToString) = False Then
                    Direcciones(i) = Direcciones(i) & "<td>NO</td>"
                Else
                    Direcciones(i) = Direcciones(i) & "<td>SI</td>"
                End If
                Direcciones(i) = Direcciones(i) & "<td>" & CarpetaJudicialAvales.LeerOperacionesPorAvales(CLng(dtr("Id").ToString)) & "</td></tr>"
            End While
            dtr.Close()
        Catch
            LeerDatosAvales = 0
        End Try


        LeerDatosAvales = i

    End Function

    Public Function LeerOperacionesPorAvales(ByVal CarpetaJudicialAvalesId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0

        sSQL = "Select CarpetaJudicialCreditos.CarpetaJudicialCreditosNroOperacion As Operacion "
        sSQL = sSQL & "FROM CarpetaJudicialAvalesPorCarpetaJudicialCreditos INNER JOIN CarpetaJudicialCreditos ON CarpetaJudicialAvalesPorCarpetaJudicialCreditos.CarpetaJudicialCreditosId = CarpetaJudicialCreditos.CarpetaJudicialCreditosId "
        sSQL = sSQL & "WHERE (((CarpetaJudicialAvalesPorCarpetaJudicialCreditos.CarpetaJudicialAvalesId)=" & CarpetaJudicialAvalesId & "))"

        Dim CodigoHTML As String = ""

        LeerOperacionesPorAvales = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & dtr("Operacion").ToString & "</br>"
            End While
            dtr.Close()
        Catch
            LeerOperacionesPorAvales = ""
        End Try

        LeerOperacionesPorAvales = CodigoHTML

    End Function

End Class
