Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Net.Mail
Imports System.IO
Imports AccesoEA
Public Class AccionesABM
    Public Function CargosUpdate(ByVal ObjectId As Long, _
                                    ByVal Cargo As String, _
                                    ByVal Familia As String, _
                                    ByVal Objetivos As String) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String

        strUpdate = "UPDATE t_object "
        strUpdate = strUpdate & "SET t_object.Name = '" & Cargo & "', "
        strUpdate = strUpdate & "t_object.Stereotype = '" & Familia & "', "
        strUpdate = strUpdate & "t_object.Note = '" & Objetivos & "' "
        strUpdate = strUpdate & "WHERE t_object.Object_ID = " & ObjectId
        Try
            CargosUpdate = AccesoEA.ABMRegistros(strUpdate)
        Catch
            CargosUpdate = 0
        End Try
    End Function
    Public Function FuncionesUpdate(ByVal ReqId As Long, _
                                    ByVal Funcion As String, _
                                    ByVal Descripcion As String) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String

        strUpdate = "UPDATE t_objectrequires "
        strUpdate = strUpdate & "SET t_objectrequires.Requirement = '" & Funcion & "', "
        strUpdate = strUpdate & "t_objectrequires.Notes = '" & Descripcion & "' "
        strUpdate = strUpdate & "WHERE t_objectrequires.ReqID = " & ReqId

        Try
            FuncionesUpdate = AccesoEA.ABMRegistros(strUpdate)
        Catch
            FuncionesUpdate = 0
        End Try
    End Function
    Public Function FuncionesInsert(ByVal ObjectId As Long, _
                                ByVal Funcion As String, _
                                ByVal Descripcion As String) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String

        strUpdate = "INSERT INTO t_objectrequires (Object_ID, Requirement, ReqType, Status, Notes, Difficulty, Priority, LastUpdate) "
        strUpdate = strUpdate & "VALUES (" & ObjectId & ", '" & Funcion & "', 'Functional', 'Approved', '" & Descripcion & "', 'Medium', 'Medium', '" & DateTime.Now() & "')"

        Try
            FuncionesInsert = AccesoEA.ABMRegistros(strUpdate)
        Catch
            FuncionesInsert = 0
        End Try
    End Function
    Public Function FuncionesDelete(ByVal ReqId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String

        strUpdate = "DELETE FROM t_objectrequires WHERE ReqId = " & ReqId

        Try
            FuncionesDelete = AccesoEA.ABMRegistros(strUpdate)
        Catch
            FuncionesDelete = 0
        End Try
    End Function
    Public Function ClienteUpdate(ByVal ClienteId As Long, ByRef ClienteEMail As String, ByRef ClienteRut As String, ByRef ClienteName As String, ByRef ClienteApPaterno As String, ByRef ClienteApMaterno As String, _
                                ByRef ClienteCalle As String, ByRef ClienteNumero As String, ByRef ClienteDepartamento As String, ByRef ClienteComuna As String, _
                                ByRef ClienteCiudad As String, ByRef ClienteTelefonoParticular As String, ByRef ClienteCelular As String, _
                                ByRef ClienteTelefonoComercial1 As String, ByRef ClienteTelefonoComercial2 As String, ByRef ClienteFNacimiento As Date, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "UPDATE Cliente "
        strUpdate = strUpdate & "SET Cliente.ClienteEMail = '" & ClienteEMail & "', "
        strUpdate = strUpdate & "Cliente.ClienteRut = '" & ClienteRut & "', "
        strUpdate = strUpdate & "Cliente.ClienteName = '" & ClienteName & "', "
        strUpdate = strUpdate & "Cliente.ClienteApPaterno = '" & ClienteApPaterno & "', "
        strUpdate = strUpdate & "Cliente.ClienteApMaterno = '" & ClienteApMaterno & "', "
        strUpdate = strUpdate & "Cliente.ClienteCalle = '" & ClienteCalle & "', "
        strUpdate = strUpdate & "Cliente.ClienteNumero = '" & ClienteNumero & "', "
        strUpdate = strUpdate & "Cliente.ClienteDepartamento = '" & ClienteDepartamento & "', "
        strUpdate = strUpdate & "Cliente.ClienteComuna = '" & ClienteComuna & "', "
        strUpdate = strUpdate & "Cliente.ClienteCiudad = '" & ClienteCiudad & "', "
        strUpdate = strUpdate & "Cliente.ClienteTelefonoParticular = '" & ClienteTelefonoParticular & "', "
        strUpdate = strUpdate & "Cliente.ClienteCelular = '" & ClienteCelular & "', "
        strUpdate = strUpdate & "Cliente.ClienteTelefonoComercial1 = '" & ClienteTelefonoComercial1 & "', "
        strUpdate = strUpdate & "Cliente.ClienteTelefonoComercial2 = '" & ClienteTelefonoComercial2 & "', "
        strUpdate = strUpdate & "Cliente.ClienteFNacimiento = '" & ClienteFNacimiento & "' "
        strUpdate = strUpdate & "WHERE Cliente.ClienteId = " & ClienteId
        Try
            ClienteUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Cliente " & ClienteEMail, ClienteId, "Cliente", "Sin Observaciones")
        Catch
            ClienteUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro del Cliente " & ClienteEMail, ClienteId, "Cliente", "Sin Observaciones")
        End Try
    End Function
    Public Function ClientePartialInsert(ByVal ClienteEMail As String, ByVal ClienteRut As String, _
                                        ByRef ClienteId As Long, ByRef ClienteName As String, _
                                        ByRef ClienteApPaterno As String, ByRef ClienteApMaterno As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim t As Boolean
        Dim s As Integer

        strUpdate = "INSERT INTO Cliente (ClienteEMail, ClienteRut) "
        strUpdate = strUpdate & "VALUES ('" & ClienteEMail & "', '" & ClienteRut & "')"

        Try
            ClientePartialInsert = AccesoEA.ABMRegistros(strUpdate)
            t = Lecturas.LeerRutYCorreoCliente(ClienteEMail, ClienteRut, ClienteId, ClienteName, ClienteApPaterno, ClienteApMaterno)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Cliente " & ClienteEMail, ClienteId, "Cliente", "Sin Observaciones")
        Catch
            ClientePartialInsert = 0
            ClienteId = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar el registro del Cliente " & ClienteEMail, ClienteId, "Cliente", "Sin Observaciones")
        End Try
    End Function
    Public Function ClienteInsert(ByVal ClienteEMail As String, ByVal ClienteRut As String, ByVal ClienteName As String, ByVal ClienteApPaterno As String, ByVal ClienteApMaterno As String, _
                                ByVal ClienteCalle As String, ByVal ClienteNumero As String, ByVal ClienteDepartamento As String, ByVal ClienteComuna As String, _
                                ByVal ClienteCiudad As String, ByVal ClienteTelefonoParticular As String, ByVal ClienteCelular As String, _
                                ByVal ClienteTelefonoComercial1 As String, ByVal ClienteTelefonoComercial2 As String, ByVal ClienteFNacimiento As Date) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String

        strUpdate = "INSERT INTO Cliente (ClienteEMail, ClienteRut, ClienteName, ClienteApPaterno, ClienteApMaterno, ClienteCalle, ClienteNumero, ClienteDepartamento, ClienteComuna, ClienteCiudad, ClienteTelefonoParticular, ClienteCelular, ClienteTelefonoComercial1, ClienteTelefonoComercial2, ClienteFNacimiento ) "
        strUpdate = strUpdate & " VALUES ('" & ClienteEMail & "', '" & ClienteRut & "', '" & ClienteName & "', '" & ClienteApPaterno & "', '" & ClienteApMaterno & "', '" & ClienteCalle & "', '" & ClienteNumero & "', '" & ClienteDepartamento & "', '" & ClienteComuna & "', '" & ClienteCiudad & "', '" & ClienteTelefonoParticular & "', '" & ClienteCelular & "', '" & ClienteTelefonoComercial1 & "', '" & ClienteTelefonoComercial2 & "', '#" & ClienteFNacimiento & "#')"

        Try
            ClienteInsert = AccesoEA.ABMRegistros(strUpdate)
        Catch
            ClienteInsert = 0
        End Try
    End Function
    Public Function ComunaPartialInsert(ByVal ComunaName As String, ByVal UserId As Long, ByRef ComunaId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim t As Boolean
        Dim s As Integer

        strUpdate = "INSERT INTO Comuna (ComunaName, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES ('" & ComunaName & "', '" & DateTransform(Now()) & "', " & UserId & ")"

        Try
            ComunaPartialInsert = AccesoEA.ABMRegistros(strUpdate)
            t = Lecturas.LeerComunaByName(ComunaName, ComunaId)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Comuna " & ComunaName, ComunaId, "Comuna", "")
        Catch
            ComunaPartialInsert = 0
            ComunaId = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar el registro de la Comuna " & ComunaName, ComunaId, "Comuna", "")
        End Try
    End Function
    Public Function ComunaUpdate(ByVal ComunaId As Long, ByRef ComunaName As String, ByRef ComunaDescription As String, ByRef ComunaCodigoCorreos As String, ByRef ComunaProvincia As String, ByRef ComunaRegion As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "UPDATE Comuna "
        strUpdate = strUpdate & "SET Comuna.ComunaName = '" & ComunaName & "', "
        strUpdate = strUpdate & "Comuna.ComunaDescription = '" & ComunaDescription & "', "
        strUpdate = strUpdate & "Comuna.ComunaCodigoCorreos = '" & ComunaCodigoCorreos & "', "
        strUpdate = strUpdate & "Comuna.ComunaProvincia = '" & ComunaProvincia & "', "
        strUpdate = strUpdate & "Comuna.ComunaRegion = '" & ComunaRegion & "', "
        strUpdate = strUpdate & "Comuna.DateLastUpdate = '" & DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Comuna.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Comuna.ComunaId = " & ComunaId
        Try
            ComunaUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Comuna " & ComunaName, ComunaId, "Comuna", "")
        Catch
            ComunaUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de la Comuna " & ComunaName, ComunaId, "Comuna", "")
        End Try
    End Function
    Public Function ComunaInsert(ByVal ComunaName As String, ByVal ComunaDescription As String, ByVal ComunaCodigoCorreos As String, ByVal ComunaProvincia As String, ByVal ComunaRegion As String) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String

        strUpdate = "INSERT INTO Comuna (ComunaName, ComunaDescription, ComunaCodigoCorreos, ComunaProvincia, ComunaRegion) "
        strUpdate = strUpdate & " VALUES ('" & ComunaName & "', '" & ComunaDescription & "', '" & ComunaCodigoCorreos & "', '" & ComunaProvincia & "', '" & ComunaRegion & "')"

        Try
            ComunaInsert = AccesoEA.ABMRegistros(strUpdate)
        Catch
            ComunaInsert = 0
        End Try
    End Function
    Public Function DateTransform(ByVal FechaControl As Date) As String
        '    DateTransform = Mid(FechaControl, 7, 4) & "-" & Mid(FechaControl, 4, 2) & "-" & Mid(FechaControl, 1, 2) & " " & Mid(FechaControl, 12, 8)
        DateTransform = DatePart("yyyy", FechaControl) & "-" & DatePart("m", FechaControl) & "-" & DatePart("d", FechaControl) & " " & DatePart("h", FechaControl) & ":" & DatePart("n", FechaControl) & ":" & DatePart("s", FechaControl)
    End Function
    Public Function BitacoraInsert(ByVal UserId As Long, ByVal sSQL As String, ByVal RolId As Long, ByVal FuncionId As Long, ByVal Mensaje As String, ByVal RegId As Long, ByVal TableName As String, ByVal Observacion As String) As Integer

        Dim AccesoEA As New AccesoEA 
        Dim strUpdate As String

        strUpdate = "INSERT INTO Bitacora ( LogTime, PersonaId, sSQL, RolId, Id, Mensaje, RegId, TableName, Observacion ) "
        strUpdate = strUpdate & " VALUES ('" & DateTransform(Now()) & "', " & UserId & ", '" & sSQL & "', " & RolId & ", " & FuncionId & ", '" & Mensaje & "', " & RegId & ", '" & TableName & "', '" & Observacion & "')"

        Try
            BitacoraInsert = AccesoEA.ABMRegistros(strUpdate)
        Catch
            BitacoraInsert = 0
        End Try
    End Function
    Public Function TareasLogInsert(ByVal TareasCodigo As String, ByVal UsuariosCodigo As String, ByVal TareasLogRol As String, ByVal TareasLogActividad As String) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String

        strUpdate = "INSERT INTO TareasLog ( TareasLogTime, TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad ) "
        strUpdate = strUpdate & " VALUES ('" & DateTransform(Now()) & "', '" & TareasCodigo & "', '" & UsuariosCodigo & "', '" & TareasLogRol & "', '" & TareasLogActividad & "')"

        Try
            TareasLogInsert = AccesoEA.ABMRegistros(strUpdate)
        Catch
            TareasLogInsert = 0
        End Try
    End Function


    Public Function EstCargoPartialInsert(ByVal EstCargoName As String, ByVal UserId As Long, ByRef EstCargoId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim t As Boolean
        Dim s As Integer

        strUpdate = "INSERT INTO EstereotiposCargos (EstCargoName, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES ('" & EstCargoName & "', '" & DateTransform(Now()) & "', " & UserId & ")"

        Try
            EstCargoPartialInsert = AccesoEA.ABMRegistros(strUpdate)
            t = Lecturas.LeerEstCargoByName(EstCargoName, EstCargoId)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Familia de Cargo: " & EstCargoName, EstCargoId, "EstereotiposCargos", "")
        Catch
            EstCargoPartialInsert = 0
            EstCargoId = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar la familia de cargo: " & EstCargoName, EstCargoId, "EstereotiposCargos", "")
        End Try
    End Function
    Public Function EstCargoUpdate(ByVal EstCargoId As Long, ByRef EstCargoName As String, ByRef EstCargoDescription As String, ByRef EstCargoSecuencia As Long, ByRef EstCargoPlanta As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "UPDATE EstereotiposCargos "
        strUpdate = strUpdate & "SET EstereotiposCargos.EstCargoName = '" & EstCargoName & "', "
        strUpdate = strUpdate & "EstereotiposCargos.EstCargoDescription = '" & EstCargoDescription & "', "
        strUpdate = strUpdate & "EstereotiposCargos.EstCargoSecuencia = " & EstCargoSecuencia & ", "
        strUpdate = strUpdate & "EstereotiposCargos.EstCargoPlanta = '" & EstCargoPlanta & "', "
        strUpdate = strUpdate & "EstereotiposCargos.DateLastUpdate = '" & DateTransform(Now()) & "', "
        strUpdate = strUpdate & "EstereotiposCargos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE EstereotiposCargos.EstCargoId = " & EstCargoId
        Try
            EstCargoUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza familia de cargo: " & EstCargoName, EstCargoId, "EstereotiposCargos", "")
        Catch
            EstCargoUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar la familia de cargo: " & EstCargoName, EstCargoId, "EstereotiposCargos", "")
        End Try
    End Function
    Public Function CargosPartialInsert(ByVal CargosName As String, ByVal UserId As Long, ByRef CargosId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim t As Boolean
        Dim s As Integer

        strUpdate = "INSERT INTO Cargos (CargosName, EstCargoName, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES ('" & CargosName & "','" & "Por definir" & "', '" & DateTransform(Now()) & "', " & UserId & ")"

        Try
            CargosPartialInsert = AccesoEA.ABMRegistros(strUpdate)
            t = Lecturas.LeerCargoByName(CargosName, CargosId)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Cargo: " & CargosName, CargosId, "Cargos", "")
        Catch
            CargosPartialInsert = 0
            CargosId = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar cargo: " & CargosName, CargosId, "Cargos", "")
        End Try
    End Function
    Public Function CargosUpdate(ByVal CargosId As Long, ByRef CargosName As String, ByRef CargosDescription As String, ByRef EstCargoName As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "UPDATE Cargos "
        strUpdate = strUpdate & "SET CargosName = '" & CargosName & "', "
        strUpdate = strUpdate & "Cargos.CargosDescription = '" & CargosDescription & "', "
        strUpdate = strUpdate & "Cargos.EstCargoName = '" & EstCargoName & "', "
        strUpdate = strUpdate & "Cargos.DateLastUpdate = '" & DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Cargos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Cargos.CargosId = " & CargosId

        Try
            CargosUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza cargo: " & CargosName, CargosId, "Cargos", "")
        Catch
            CargosUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar cargo: " & CargosName, CargosId, "Cargos", "")
        End Try
    End Function
    Public Function ReqCargoPartialInsert(ByVal CargosName As String, ByVal ReqCargoSecuencia As Long, ByVal UserId As Long, ByRef ReqCargoId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim t As Boolean
        Dim s As Integer

        strUpdate = "INSERT INTO RequisitosCargos (CargosName, ReqCargoSecuencia, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES ('" & CargosName & "'," & ReqCargoSecuencia & ", '" & DateTransform(Now()) & "', " & UserId & ")"

        Try
            ReqCargoPartialInsert = AccesoEA.ABMRegistros(strUpdate)
            t = Lecturas.LeerRequisitoCargoByNameAndSecuencia(CargosName, ReqCargoSecuencia, ReqCargoId)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Requisito del Cargo: " & CargosName, ReqCargoId, "RequisitosCargos", "")
        Catch
            ReqCargoPartialInsert = 0
            ReqCargoId = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar Requisito del cargo: " & CargosName, ReqCargoId, "RequisitosCargos", "")
        End Try
    End Function
    Public Function ObjectPartialInsert(ByVal CampoId As String, _
                                        ByVal CampoMaestro As String, _
                                        ByVal CampoSecuencia As String, _
                                        ByVal NombreTabla As String, _
                                        ByVal MasterName As String, _
                                        ByVal DetailSecuencia As Long, _
                                        ByVal UserId As Long, _
                                        ByRef DetailId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim t As Boolean
        Dim s As Integer

        strUpdate = "INSERT INTO " & NombreTabla & " (" & CampoMaestro & ", " & CampoSecuencia & ", DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES ('" & MasterName & "'," & DetailSecuencia & ", '" & DateTransform(Now()) & "', " & UserId & ")"

        Try
            Console.WriteLine("** SQL--------------------- **")
            Console.WriteLine(strUpdate)
            Console.WriteLine("** SQL--------------------- **")
            ObjectPartialInsert = AccesoEA.ABMRegistros(strUpdate)
            t = Lecturas.LeerObjectByNameAndSecuencia(CampoId, CampoMaestro, CampoSecuencia, NombreTabla, MasterName, DetailSecuencia, DetailId)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Detalle de : " & MasterName, DetailId, NombreTabla, "")
        Catch ex As Exception
            ObjectPartialInsert = 0
            DetailId = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar detalle de : " & MasterName, DetailId, NombreTabla, "")
            Console.WriteLine("** Exception in ObjectPartialInsert **")
            Console.WriteLine(ex.ToString)
            Console.WriteLine("Tabla = " & NombreTabla)
            Console.WriteLine("** Exception in ObjectPartialInsert **")               
        End Try
    End Function



    Public Function ReqCargoUpdate(ByVal ReqCargoId As Long, ByRef CargosName As String, ByRef ReqCargoSecuencia As Long, ByRef ReqCargoNombre As String, ByRef ReqCargoDescription As String, ByRef ReqCargoNivelExigencia As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "UPDATE RequisitosCargos "
        strUpdate = strUpdate & "SET RequisitosCargos.CargosName = '" & CargosName & "', "
        strUpdate = strUpdate & "RequisitosCargos.ReqCargoSecuencia = " & ReqCargoSecuencia & ", "
        strUpdate = strUpdate & "RequisitosCargos.ReqCargoNombre = '" & ReqCargoNombre & "', "
        strUpdate = strUpdate & "RequisitosCargos.ReqCargoDescription = '" & ReqCargoDescription & "', "
        strUpdate = strUpdate & "RequisitosCargos.ReqCargoNivelExigencia = '" & ReqCargoNivelExigencia & "', "
        strUpdate = strUpdate & "RequisitosCargos.DateLastUpdate = '" & DateTransform(Now()) & "', "
        strUpdate = strUpdate & "RequisitosCargos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE RequisitosCargos.ReqCargoId = " & ReqCargoId
        Try
            ReqCargoUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza requisito del cargo: " & CargosName, ReqCargoId, "RequisitosCargos", "")
        Catch
            ReqCargoUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el cargo: " & CargosName, ReqCargoId, "RequisitosCargos", "")
        End Try
    End Function
    Public Function ReqCargoDelete(ByVal ReqCargoId As Long, ByVal CargosName As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "DELETE FROM RequisitosCargos WHERE ReqCargoId = " & ReqCargoId

        Try
            ReqCargoDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina un requisito del cargo: " & CargosName, ReqCargoId, "RequisitosCargos", "")
        Catch
            ReqCargoDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar un requisito del cargo: " & CargosName, ReqCargoId, "RequisitosCargos", "")
        End Try
    End Function
    Public Function FunCargoPartialInsert(ByVal CargosName As String, ByVal FunCargoSecuencia As Long, ByVal UserId As Long, ByRef FunCargoId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim t As Boolean
        Dim s As Integer

        strUpdate = "INSERT INTO FuncionesCargos (CargosName, FunCargoSecuencia, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES ('" & CargosName & "'," & FunCargoSecuencia & ", '" & DateTransform(Now()) & "', " & UserId & ")"

        Try
            FunCargoPartialInsert = AccesoEA.ABMRegistros(strUpdate)
            t = Lecturas.LeerFuncionCargoByNameAndSecuencia(CargosName, FunCargoSecuencia, FunCargoId)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Funci�n del Cargo: " & CargosName, FunCargoId, "FuncionesCargos", "")
        Catch
            FunCargoPartialInsert = 0
            FunCargoId = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar Funci�n del cargo: " & CargosName, FunCargoId, "FuncionesCargos", "")
        End Try
    End Function
    Public Function FunCargoUpdate(ByVal FunCargoId As Long, ByRef CargosName As String, ByRef FunCargoSecuencia As Long, ByRef FunCargoCodigo As String, ByRef FunCargoNombre As String, ByRef FunCargoDescription As String, ByRef FunCargoGrupo As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "UPDATE FuncionesCargos "
        strUpdate = strUpdate & "SET FuncionesCargos.CargosName = '" & CargosName & "', "
        strUpdate = strUpdate & "FuncionesCargos.FunCargoSecuencia = " & FunCargoSecuencia & ", "
        strUpdate = strUpdate & "FuncionesCargos.FunCargoCodigo = '" & FunCargoCodigo & "', "
        strUpdate = strUpdate & "FuncionesCargos.FunCargoNombre = '" & FunCargoNombre & "', "
        strUpdate = strUpdate & "FuncionesCargos.FunCargoDescription = '" & FunCargoDescription & "', "
        strUpdate = strUpdate & "FuncionesCargos.FunCargoGrupo = '" & FunCargoGrupo & "', "
        strUpdate = strUpdate & "FuncionesCargos.DateLastUpdate = '" & DateTransform(Now()) & "', "
        strUpdate = strUpdate & "FuncionesCargos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE FuncionesCargos.FunCargoId = " & FunCargoId
        Try
            FunCargoUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Funci�n del cargo: " & CargosName, FunCargoId, "FuncionesCargos", "")
        Catch
            FunCargoUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el cargo: " & CargosName, FunCargoId, "FuncionesCargos", "")
        End Try
    End Function
    Public Function FunCargoDelete(ByVal FunCargoId As Long, ByVal CargosName As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "DELETE FROM FuncionesCargos WHERE FunCargoId = " & FunCargoId

        Try
            FunCargoDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina una funci�n del cargo: " & CargosName, FunCargoId, "FuncionesCargos", "")
        Catch
            FunCargoDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar una funci�n del cargo: " & CargosName, FunCargoId, "FuncionesCargos", "")
        End Try
    End Function
    Public Function PortalesPartialInsert(ByVal PortalesName As String, ByVal UserId As Long, ByRef PortalesId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim t As Boolean
        Dim s As Integer

        strUpdate = "INSERT INTO Portales (PortalesName, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES ('" & PortalesName & "', '" & DateTransform(Now()) & "', " & UserId & ")"

        Try
            PortalesPartialInsert = AccesoEA.ABMRegistros(strUpdate)
            t = Lecturas.LeerPortalByName(PortalesName, PortalesId)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Portal: " & PortalesName, PortalesId, "Portales", "")
        Catch
            PortalesPartialInsert = 0
            PortalesId = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar Portal: " & PortalesName, PortalesId, "Portales", "")
        End Try
    End Function
    Public Function PortalesUpdate(ByVal PortalesId As Long, ByVal PortalesName As String, ByVal PortalesDescription As String, ByVal PortalesSecuencia As Long, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "UPDATE Portales "
        strUpdate = strUpdate & "SET Portales.PortalesName = '" & PortalesName & "', "
        strUpdate = strUpdate & "Portales.PortalesDescription = '" & PortalesDescription & "', "
        strUpdate = strUpdate & "Portales.PortalesSecuencia = " & PortalesSecuencia & ", "
        strUpdate = strUpdate & "Portales.DateLastUpdate = '" & DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Portales.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Portales.PortalesId = " & PortalesId
        Try
            PortalesUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Portal: " & PortalesName, PortalesId, "Portales", "")
        Catch
            PortalesUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el portal: " & PortalesName, PortalesId, "Portales", "")
        End Try
    End Function
    Public Function PaginaWebPartialInsert(ByVal PaginaWebName As String, ByVal PaginaWebGroupValidation As String, _
                                           ByVal PaginaWebStereotype As String, ByVal PaginaWebUserControl As String, _
                                           ByVal UserId As Long, ByRef PaginaWebId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim t As Boolean
        Dim s As Integer

        strUpdate = "INSERT INTO PaginaWeb (PaginaWebName, PaginaWebGroupValidation, PaginaWebStereotype, PaginaWebUserControl, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES ('" & PaginaWebName & "', '" & PaginaWebGroupValidation & "', '" & PaginaWebStereotype & "', '" & PaginaWebUserControl & "', '" & DateTransform(Now()) & "', " & UserId & ")"

        Try
            PaginaWebPartialInsert = AccesoEA.ABMRegistros(strUpdate)
            t = Lecturas.LeerPaginaWebByName(PaginaWebName, PaginaWebId)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Pagina Web: " & PaginaWebName, PaginaWebId, "PaginaWeb", "")
        Catch
            PaginaWebPartialInsert = 0
            PaginaWebId = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar Pagina Web: " & PaginaWebName, PaginaWebId, "PaginaWeb", "")
        End Try
    End Function
    Public Function FormularioWebInsert(ByVal FormularioWebNumber As Long, _
            ByVal FormularioWebPId As Long, ByVal FormularioWebSecuencia As Long, ByVal FormularioWebLabel As String, _
            ByVal FormularioWebControl As String, ByVal FormularioWebTipoControl As String, ByVal FormularioWebCssClassLabel As String, _
            ByVal FormularioWebCssClassControl As String, ByVal FormularioWebLabelAlign As String, ByVal FormularioWebControlWidth As String, _
            ByVal FormularioWebControlTextMode As Long, ByVal FormularioWebToolTip As String, ByVal FormularioWebIsNotEnabled As Boolean, _
            ByVal FormularioWebSection As String, ByVal UserId As Long, ByRef FormularioWebId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim s As Integer

        'FormularioWebTipoControl, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsNotEnabled, 
        '& FormularioWebTipoControl "', '" & FormularioWebCssClassLabel & "', '" & FormularioWebCssClassControl & "', '" &  FormularioWebLabelAlign & "', '" & FormularioWebControlWidth & "', " & FormularioWebControlTextMode & ", '" & FormularioWebToolTip & "', '" & CBool(FormularioWebIsNotEnabled) & "', '" 

        strUpdate = "INSERT INTO FormularioWeb (FormularioWebNumber, FormularioWebPID, FormularioWebSecuencia, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsNotEnabled, FormularioWebSection, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES (" & FormularioWebNumber & ", " & FormularioWebPId & ", " & FormularioWebSecuencia & ", '" & FormularioWebLabel & "', '" & FormularioWebControl & "', '" & FormularioWebTipoControl & "', '" & FormularioWebCssClassLabel & "', '" & FormularioWebCssClassControl & "', '" & FormularioWebLabelAlign & "', '" & FormularioWebControlWidth & "', " & FormularioWebControlTextMode & ", '" & FormularioWebToolTip & "', " & CBool(FormularioWebIsNotEnabled) & ", '" & FormularioWebSection & "', '" & DateTransform(Now()) & "', " & UserId & ")"

        Try
            FormularioWebInsert = AccesoEA.ABMRegistros(strUpdate)
            FormularioWebId = Lecturas.LeerMaximoId("Select Max(FormularioWebID) as MaximoId FROM FormularioWeb")
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Formulario Web: " & FormularioWebLabel, FormularioWebId, "FormularioWeb", "")
        Catch
            FormularioWebInsert = 0
            FormularioWebId = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar Formulario Web: " & FormularioWebLabel, FormularioWebId, "FormularioWeb", "")
        End Try
    End Function


    Public Function PaginaWebUpdate(ByVal PaginaWebId As Long, ByVal PaginaWebName As String, ByVal PaginaWebTitle As String, ByVal PaginaWebDescription As String, ByVal FormularioWebNumber As Long, _
                                    ByVal PaginaWebGroupValidation As String, ByVal PaginaWebStereotype As String, ByVal PaginaWebUserControl As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "UPDATE PaginaWeb "
        strUpdate = strUpdate & "SET PaginaWeb.PaginaWebName = '" & PaginaWebName & "', "
        strUpdate = strUpdate & "PaginaWeb.PaginaWebTitle = '" & PaginaWebTitle & "', "
        strUpdate = strUpdate & "PaginaWeb.PaginaWebDescription = '" & PaginaWebDescription & "', "
        strUpdate = strUpdate & "PaginaWeb.FormularioWebNumber = " & FormularioWebNumber & ", "
        strUpdate = strUpdate & "PaginaWeb.PaginaWebGroupValidation = '" & PaginaWebGroupValidation & "', "
        strUpdate = strUpdate & "PaginaWeb.PaginaWebStereotype = '" & PaginaWebStereotype & "', "
        strUpdate = strUpdate & "PaginaWeb.PaginaWebUserControl = '" & PaginaWebUserControl & "', "
        strUpdate = strUpdate & "PaginaWeb.DateLastUpdate = '" & DateTransform(Now()) & "', "
        strUpdate = strUpdate & "PaginaWeb.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE PaginaWeb.PaginaWebId = " & PaginaWebId
        Try
            PaginaWebUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza P�gina: " & PaginaWebName, PaginaWebId, "PaginaWeb", "")
        Catch
            PaginaWebUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar la p�gina: " & PaginaWebName, PaginaWebId, "PaginaWeb", "")
        End Try
    End Function
    Public Function MenuOptionsDelete(ByVal MenuOptionsId As Long, ByVal Texto As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "DELETE FROM MenuOptions WHERE MenuOptionsId = " & MenuOptionsId

        Try
            MenuOptionsDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina la opci�n de men�: " & Texto, MenuOptionsId, "MenuOptions", "")
        Catch
            MenuOptionsDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la opci�n de men�: " & Texto, MenuOptionsId, "MenuOptions", "")
        End Try
    End Function
    Public Function MenuOptionsUpdate(ByVal MenuOptionsId As Long, ByVal Secuencia As Long, _
                                ByVal GrupoOpciones As String, ByVal href As String, ByVal title As String, ByVal Texto As String, _
                                ByVal Logo As String, ByVal BarMenu As String, ByVal SideBarMenu As String, _
                                ByVal PaginaWebName As String, ByVal Description As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "UPDATE MenuOptions "
        strUpdate = strUpdate & "SET "
        strUpdate = strUpdate & "MenuOptions.Secuencia = " & Secuencia & ", "
        strUpdate = strUpdate & "MenuOptions.Class = '" & GrupoOpciones & "', "
        strUpdate = strUpdate & "MenuOptions.href = '" & href & "', "
        strUpdate = strUpdate & "MenuOptions.title = '" & title & "', "
        strUpdate = strUpdate & "MenuOptions.Texto = '" & Texto & "', "
        strUpdate = strUpdate & "MenuOptions.Logo = '" & Logo & "', "
        strUpdate = strUpdate & "MenuOptions.BarMenu = '" & BarMenu & "', "
        strUpdate = strUpdate & "MenuOptions.SideBarMenu = '" & SideBarMenu & "', "
        strUpdate = strUpdate & "MenuOptions.PaginaWebName = '" & PaginaWebName & "', "
        strUpdate = strUpdate & "MenuOptions.Description = '" & Description & "', "
        strUpdate = strUpdate & "MenuOptions.DateLastUpdate = '" & DateTransform(Now()) & "', "
        strUpdate = strUpdate & "MenuOptions.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE MenuOptions.MenuOptionsId = " & MenuOptionsId
        Try
            MenuOptionsUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Opci�n de Men�: " & PaginaWebName, MenuOptionsId, "MenuOptions", "")
        Catch
            MenuOptionsUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar la opci�n de men�: " & PaginaWebName, MenuOptionsId, "MenuOptions", "")
        End Try
    End Function
    Public Function MenuOptionsPartialInsert(ByVal MenuOptionsPID As Long, ByVal Secuencia As Long, _
                                ByVal SystemId As Long, ByVal PortalesName As String, _
                                ByVal Zona As String, ByVal OptionsType As String, ByVal IsNodoHoja As String, _
                                ByVal UserId As Long, ByRef MenuOptionsId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim s As Integer

        strUpdate = "INSERT INTO MenuOptions (MenuOptionsPId, Secuencia, SystemId, PortalesName, Zona, OptionsType, IsNodoHoja, PaginaWebName, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES (" & MenuOptionsPID & ", " & Secuencia & ", " & SystemId & ", '" & PortalesName & "', '" & Zona & "', '" & OptionsType & "', '" & IsNodoHoja & "', '" & "Login" & "', '" & DateTransform(Now()) & "', " & UserId & ")"

        Try
            MenuOptionsPartialInsert = AccesoEA.ABMRegistros(strUpdate)
            MenuOptionsId = Lecturas.LeerMaximoId("Select Max(MenuOptionsID) as MaximoId FROM (MenuOptions)")
            't = Lecturas.LeerPaginaWebByName(PaginaWebName, PaginaWebId)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Opci�n de Menu en la Zona: " & Zona, MenuOptionsId, "MenuOptions", "")
        Catch
            MenuOptionsPartialInsert = 0
            MenuOptionsId = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar opci�n de men� en la zona: " & Zona, MenuOptionsId, "MenuOptions", "")
        End Try
    End Function
    Public Function MasterPartialInsert(ByVal ObjectId As String, _
                                        ByVal ObjectName As String, _
                                        ByVal ObjectTable As String, _
                                        ByVal MasterName As String, _
                                        ByVal UserId As Long, _
                                        ByRef MasterId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim t As Boolean
        Dim s As Integer

        strUpdate = "INSERT INTO " & ObjectTable & " (" & ObjectName & ", DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES ('" & MasterName & "', '" & DateTransform(Now()) & "', " & UserId & ")"

        Try
            MasterPartialInsert = AccesoEA.ABMRegistros(strUpdate)
            t = Lecturas.LeerMasterIdByMasterName(ObjectId, ObjectName, ObjectTable, MasterName, MasterId)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta " & MasterName, MasterId, ObjectTable, "")
        Catch
            MasterPartialInsert = 0
            MasterId = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar " & MasterName, MasterId, ObjectTable, "")
        End Try
    End Function
    Public Function MasterDelete(ByVal ObjectId As String, _
                                        ByVal ObjectTable As String, _
                                        ByVal MasterName As String, _
                                        ByVal UserId As Long, _
                                        ByRef MasterId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim s As Integer

        strUpdate = "DELETE FROM " & ObjectTable & " WHERE " & ObjectId & " = " & MasterId

        Try
            MasterDelete = AccesoEA.ABMRegistros(strUpdate)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Borra " & MasterName, MasterId, ObjectTable, "")
        Catch
            MasterDelete = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de borrar " & MasterName, MasterId, ObjectTable, "")
        End Try
    End Function
    Public Function RelationsBetweenTablesDelete(ByVal RelationTable As String, _
                                        ByVal RelationTableId As Long, _
                                        ByRef UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim s As Integer

        strUpdate = "DELETE FROM " & RelationTable & " WHERE " & RelationTable & "Id = " & RelationTableId

        Try
            RelationsBetweenTablesDelete = AccesoEA.ABMRegistros(strUpdate)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Borra " & RelationTable, RelationTableId, RelationTable, "")
        Catch
            RelationsBetweenTablesDelete = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de borrar " & RelationTable, RelationTableId, RelationTable, "")
        End Try
    End Function
    Public Function RelationsBetweenTablesInsert(ByVal RelationTable As String, _
                                        ByVal PivotTable As String, _
                                        ByVal ChildTable As String, _
                                        ByVal PivotId As Long, _
                                        ByVal ChildId As Long, _
                                        ByRef UserId As Long) As Long

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim s As Integer

        strUpdate = "INSERT INTO " & RelationTable & " (" & PivotTable & "Id, " & ChildTable & "Id, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES (" & PivotId & ", " & ChildId & ", '" & DateTransform(Now()) & "', " & UserId & ")"

        Try
            s = AccesoEA.ABMRegistros(strUpdate)
            RelationsBetweenTablesInsert = LeerRelationTableId(RelationTable, PivotTable, ChildTable, PivotId, ChildId)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta relacion entre " & PivotTable & " y " & ChildTable & "(" & ChildId & ")", PivotId, PivotTable, "")
        Catch
            RelationsBetweenTablesInsert = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de Insertar relacion entre " & PivotTable & " y " & ChildTable & "(" & ChildId & ")", PivotId, PivotTable, "")
        End Try
    End Function
    Public Function PriorizacionPorStakeholdersUpdate(ByVal RelationTable As String, _
                                        ByVal RelationTableId As Long, _
                                        ByVal Puntaje As Long, _
                                        ByRef UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim s As Integer
        Dim ProgramasMapa As New ProgramasMapa
        Dim ProgramasMapaId As Long = 0
        Dim ProgramasCodigo As String = "" ' Etiqueta : ProgramasCodigo - Control : txtProgramasCodigo - Variable : ProgramasCodigo
        Dim ProgramasMapaSecuencia As Long = 0 ' Etiqueta : ProgramasMapaSecuencia - Control : txtProgramasMapaSecuencia - Variable : ProgramasMapaSecuencia
        Dim StakeholdersCodigo As String = "" ' Etiqueta : StakeholdersCodigo - Control : txtStakeholdersCodigo - Variable : StakeholdersCodigo
        Dim ProgramasMapaMesEvaluacion As String = "" ' Etiqueta : ProgramasMapaMesEvaluacion - Control : txtProgramasMapaMesEvaluacion - Variable : ProgramasMapaMesEvaluacion
        Dim ProgramasMapaImportancia As Long ' Etiqueta : ProgramasMapaImportancia - Control : txtProgramasMapaImportancia - Variable : ProgramasMapaImportancia
        Dim ProgramasMapaTipoGestion As String = "" ' Etiqueta : ProgramasMapaTipoGestion - Control : txtProgramasMapaTipoGestion - Variable : ProgramasMapaTipoGestion
        Dim ProgramasMapaPuntajePoder As Long ' Etiqueta : ProgramasMapaPuntajePoder - Control : txtProgramasMapaPuntajePoder - Variable : ProgramasMapaPuntajePoder
        Dim ProgramasMapaPuntajeRelevancia As Long ' Etiqueta : ProgramasMapaPuntajeRelevancia - Control : txtProgramasMapaPuntajeRelevancia - Variable : ProgramasMapaPuntajeRelevancia
        Dim ProgramasMapaRol As String
        Dim ProgramasMapaFuncion As String
        Dim ProgramasMapaRelacion As String
        Dim t As Boolean

        PriorizacionPorStakeholdersUpdate = 0

        strUpdate = "UPDATE PriorizacionPorStakeholders SET "
        strUpdate = strUpdate & "PriorizacionPorStakeholders.PriorizacionPorStakeholdersValor = " & Puntaje & ", "
        strUpdate = strUpdate & "PriorizacionPorStakeholders.DateLastUpdate = '" & DateTransform(Now()) & "', "
        strUpdate = strUpdate & "PriorizacionPorStakeholders.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE PriorizacionPorStakeholders.PriorizacionPorStakeholdersId = " & RelationTableId

        Try
            s = AccesoEA.ABMRegistros(strUpdate)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Priorizaci�n de Stakeholders ", RelationTableId, RelationTable, "")
            ' Se Obtiene el valor del Campo ProgramasId a partir de RelationTableId
            ProgramasMapaId = ProgramasMapa.LeerProgramasMapaIdByPriorizacionPorStakeholdersId(RelationTableId)
            ' Se lee el registro de la Tabla ProgramasMapa
            t = ProgramasMapa.LeerProgramasMapa(ProgramasMapaId, ProgramasCodigo, ProgramasMapaSecuencia, StakeholdersCodigo, ProgramasMapaMesEvaluacion, ProgramasMapaImportancia, ProgramasMapaTipoGestion, ProgramasMapaPuntajePoder, ProgramasMapaPuntajeRelevancia, ProgramasMapaRol, ProgramasMapaFuncion, ProgramasMapaRelacion)
            ' Calcula Puntaje de Poder
            ProgramasMapaPuntajePoder = ProgramasMapa.Puntaje(ProgramasMapaId, "Caracterizaci�n")
            ' Calcula Puntaje de Relevancia
            ProgramasMapaPuntajeRelevancia = ProgramasMapa.Puntaje(ProgramasMapaId, "Relevancia")
            ' Calcula Importancia
            'ProgramasMapaImportancia = (ProgramasMapaPuntajePoder / 5) * (ProgramasMapaPuntajeRelevancia / 3)
            ProgramasMapaImportancia = (ProgramasMapaPuntajePoder / 5) * (ProgramasMapaPuntajeRelevancia)
            ' Actualiza el registro de la Tabla ProgramasMapa
            If ProgramasMapaImportancia >= 18 Then
                ProgramasMapaTipoGestion = "Gesti�n Especial"
            Else
                ProgramasMapaTipoGestion = "Gesti�n General"
            End If
            t = ProgramasMapa.ProgramasMapaUpdate(ProgramasMapaId, ProgramasCodigo, ProgramasMapaSecuencia, StakeholdersCodigo, ProgramasMapaMesEvaluacion, ProgramasMapaImportancia, ProgramasMapaTipoGestion, ProgramasMapaPuntajePoder, ProgramasMapaPuntajeRelevancia, ProgramasMapaRol, ProgramasMapaFuncion, ProgramasMapaRelacion, UserId)
            PriorizacionPorStakeholdersUpdate = CStr(ProgramasMapaImportancia)
        Catch
            PriorizacionPorStakeholdersUpdate = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento Fallido de Actualizar Priorizaci�n de Stakeholders ", RelationTableId, RelationTable, "")
        End Try
    End Function
    Public Function PriorizacionPorStakeholdersInsert(ByVal RelationTable As String, _
                                        ByVal PivotTable As String, _
                                        ByVal ChildTable As String, _
                                        ByVal PivotId As Long, _
                                        ByVal ChildId As Long, _
                                        ByRef UserId As Long) As Long

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim s As Integer

        strUpdate = "INSERT INTO " & RelationTable & " (" & PivotTable & "Id, " & ChildTable & "Id, PriorizacionPorStakeholdersValor, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES (" & PivotId & ", " & ChildId & ", 0, '" & DateTransform(Now()) & "', " & UserId & ")"

        Try
            s = AccesoEA.ABMRegistros(strUpdate)
            PriorizacionPorStakeholdersInsert = LeerRelationTableId(RelationTable, PivotTable, ChildTable, PivotId, ChildId)
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta relacion entre " & PivotTable & " y " & ChildTable & "(" & ChildId & ")", PivotId, PivotTable, "")
        Catch
            PriorizacionPorStakeholdersInsert = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de Insertar relacion entre " & PivotTable & " y " & ChildTable & "(" & ChildId & ")", PivotId, PivotTable, "")
        End Try
    End Function
    Public Function LeerRelationTableId(ByVal RelationTable As String, ByVal PivotTable As String, ByVal ChildTable As String, ByVal PivotId As Long, ByVal ChildId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select " & RelationTable & "Id As Id "
        sSQL = sSQL & "FROM (" & RelationTable & ") "
        sSQL = sSQL & "WHERE (" & PivotTable & "Id = " & PivotId & " AND " & ChildTable & "Id = " & ChildId & ")"
        LeerRelationTableId = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerRelationTableId = CLng(dtr("Id").ToString)
            End While
            dtr.Close()
        Catch
            LeerRelationTableId = 0
        End Try
    End Function
    Public Function LeerRelationTableIdMasValor(ByVal RelationTable As String, ByVal PivotTable As String, ByVal ChildTable As String, ByVal PivotId As Long, ByVal ChildId As Long, ByRef Valor As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select " & RelationTable & "Id As Id, " & RelationTable & "Valor As Valor "
        sSQL = sSQL & "FROM (" & RelationTable & ") "
        sSQL = sSQL & "WHERE (" & PivotTable & "Id = " & PivotId & " AND " & ChildTable & "Id = " & ChildId & ")"
        LeerRelationTableIdMasValor = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerRelationTableIdMasValor = CLng(dtr("Id").ToString)
                If Len(dtr("Valor").ToString) = 0 Then
                    Valor = 0
                Else
                    Valor = CLng(dtr("Valor").ToString)
                End If
            End While
            dtr.Close()
        Catch
            LeerRelationTableIdMasValor = 0
        End Try
    End Function

    Public Function RelationsBetweenTablesUpdate(ByVal RelationTable As String, _
                                        ByVal PivotTable As String, _
                                        ByVal ChildTable As String, _
                                        ByVal PivotId As Long, _
                                        ByVal ChildId As Long, _
                                        ByRef UserId As Long) As Long

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim PGG As New PGG
        Dim Mensaje As String = ""
        Dim t As Boolean = False
        Dim RelationTableId As Long
        Dim Programas As New Programas
        Dim ProgramasMapa As New ProgramasMapa
        Dim Stakeholders As New Stakeholders
        Dim ProgramasMapaId As Long = 0
        Dim ProgramasCodigo As String = "" ' Etiqueta : ProgramasCodigo - Control : txtProgramasCodigo - Variable : ProgramasCodigo
        Dim ProgramasMapaSecuencia As Long = 0 ' Etiqueta : ProgramasMapaSecuencia - Control : txtProgramasMapaSecuencia - Variable : ProgramasMapaSecuencia
        Dim StakeholdersCodigo As String = "" ' Etiqueta : StakeholdersCodigo - Control : txtStakeholdersCodigo - Variable : StakeholdersCodigo
        Dim ProgramasMapaMesEvaluacion As String = Programas.LeerProgramasPeriodoInicio(PivotId) ' Etiqueta : ProgramasMapaMesEvaluacion - Control : txtProgramasMapaMesEvaluacion - Variable : ProgramasMapaMesEvaluacion
        Dim ProgramasMapaImportancia As Long = 0 ' Etiqueta : ProgramasMapaImportancia - Control : txtProgramasMapaImportancia - Variable : ProgramasMapaImportancia
        Dim ProgramasMapaTipoGestion As String = "" ' Etiqueta : ProgramasMapaTipoGestion - Control : txtProgramasMapaTipoGestion - Variable : ProgramasMapaTipoGestion
        Dim ProgramasMapaPuntajePoder As Long = 0 ' Etiqueta : ProgramasMapaPuntajePoder - Control : txtProgramasMapaPuntajePoder - Variable : ProgramasMapaPuntajePoder
        Dim ProgramasMapaPuntajeRelevancia As Long = 0 ' Etiqueta : ProgramasMapaPuntajeRelevancia - Control : txtProgramasMapaPuntajeRelevancia - Variable : ProgramasMapaPuntajeRelevancia
        Dim ProgramasMapaRol As String = ""
        Dim ProgramasMapaFuncion As String = ""
        Dim ProgramasMapaRelacion As String = ""
        Dim s As Integer = 0

        RelationTableId = AccionesABM.LeerRelationTableId(RelationTable, PivotTable, ChildTable, PivotId, ChildId)


        'If RelationTable = "AccionesPorStakeholdersPorPrograma" Then
        'Aqui voy
        'En este caso estamos frente a una tabla Pivot que es a la vez una relaci�n entre el programa y
        'el stakeholder involucrado en la acci�n, a su vez la tabla child trae el id de la acci�n a realizar

        If PivotTable = "PGG" Then
            ' Aqu� voy a poner el c�digo necesario para crear las tareas asociadas a las actividades de la acci�n
            ' La acci�n en cuesti�n es identificada por si identity que es el campo ChildId
            If RelationTableId = 0 Then  ' La relaci�n no existe y por ello se crea
                RelationsBetweenTablesUpdate = AccionesABM.RelationsBetweenTablesInsert(RelationTable, PivotTable, ChildTable, PivotId, ChildId, UserId)
                ' A continuaci�n se crean las tareas, asociadas al PGG
                ' PivotTable debe ser ProgramasMapa, ChildTable debe ser Acciones
                ' PivotId es el Identity de ProgramasMapa y ChildId es el Identity de Acciones
                ' Con estos valores voy a leer las actividades asociadas a la acci�n y voy a crear 
                ' todas las tareas que correspondan a cada actividad segun los meses en que se deben 
                ' ejecutar y el n�mero de veces que debe ejecutarse dentro del mismo mes, 
                ' asignandoselas a la o las personas que poseen el cargo indicado.
                RelationsBetweenTablesUpdate = AccionesABM.CrearTareas(PivotId, ChildId, UserId)
            Else                        ' La realaci�n existe y por ello se elimina
                'RelationsBetweenTablesUpdate = AccionesABM.RelationsBetweenTablesDelete(RelationTable, RelationTableId, UserId)
                'Por ahora no eliminaremos la relaci�n
                t = PGG.AccionesPorPGGDelete(PivotId, ChildId, UserId, Mensaje, 0)
                If t = False Then
                    RelationsBetweenTablesUpdate = 0
                Else
                    RelationsBetweenTablesUpdate = 1
                End If
            End If
        Else
            If RelationTableId = 0 Then  ' La relaci�n no existe y por ello se crea
                RelationsBetweenTablesUpdate = AccionesABM.RelationsBetweenTablesInsert(RelationTable, PivotTable, ChildTable, PivotId, ChildId, UserId)
                If RelationTable = "StakeholdersPorProgramas" Then
                    'Dado que se asocio un nuevo stakeholder al programa, se debe crear un registro en la tabla ProgramasMapa
                    'Luego se deben crear tantos registros como se requiera en la tabla PriorizacionPorStakeholders.
                    '----------------------
                    'Crear registro en la tabla ProgramasMapa
                    t = Programas.LeerProgramasCodigoById(PivotId, ProgramasCodigo)
                    StakeholdersCodigo = Stakeholders.LeerStakeholdersCodigoById(ChildId)
                    s = ProgramasMapa.ProgramasMapaInsert(ProgramasMapaId, ProgramasCodigo, ProgramasMapaSecuencia, StakeholdersCodigo, ProgramasMapaMesEvaluacion, ProgramasMapaImportancia, ProgramasMapaTipoGestion, ProgramasMapaPuntajePoder, ProgramasMapaPuntajeRelevancia, ProgramasMapaRol, ProgramasMapaFuncion, ProgramasMapaRelacion, UserId)
                    'Ahora me falta crear los registros de los atributos de evaluaci�n de Poder y Relevancia 
                    s = ProgramasMapa.PriorizacionPorStakeholdersInsert(ProgramasMapaId, UserId)
                End If
            Else                        ' La relaci�n existe y por ello se elimina
                RelationsBetweenTablesUpdate = AccionesABM.RelationsBetweenTablesDelete(RelationTable, RelationTableId, UserId)
                If RelationTable = "StakeholdersPorProgramas" Then
                    'Dado que se elimina un stakeholder del programa, se debe eliminar el registro correspondiente desde la tabla ProgramasMapa
                    'Luego se deben eliminar tantos registros como se requiera desde la tabla PriorizacionPorStakeholders.
                    'Luego se deben eliminar tantos registros como se requiera desde la tabla AccionesPorStakeholdersPorPrograma.
                    '------------------------
                    'Se debe obtener el valor del ProgramasMapaId a partir del c�digo del programa y del codigo del stakeholder
                    t = Programas.LeerProgramasCodigoById(PivotId, ProgramasCodigo)
                    StakeholdersCodigo = Stakeholders.LeerStakeholdersCodigoById(ChildId)
                    ProgramasMapaId = ProgramasMapa.LeerProgramasMapaId(ProgramasCodigo, StakeholdersCodigo)
                    '----------------------
                    'Eliminar registro de la tabla ProgramasMapa, PriorizacionPorStakeholders y AccionesPorStakeholdersPorPrograma
                    s = ProgramasMapa.ProgramasMapaDelete(ProgramasMapaId, ProgramasCodigo, UserId)
                    s = ProgramasMapa.PriorizacionPorStakeholdersDelete(ProgramasMapaId, ProgramasCodigo, UserId)
                    s = ProgramasMapa.AccionesPorStakeholdersPorProgramaDelete(ProgramasMapaId, ProgramasCodigo, UserId)
                    'Pero hay que examinar si el stakeholder ya tiene definidas ciertas tareas
                    'Por ahora lo que haremos es tambi�n eliminarlas y as� cumplir con eliminar el stakeholder
                    'y no dejar rastro de �l en el programa.

                End If

            End If
        End If
    End Function
    Public Function UpdateRelationsBetweenTablesUpdate(ByVal RelationTable As String, _
                                        ByVal RelationTableId As Long, _
                                        ByVal Puntaje As Long, _
                                        ByVal ProgramasMapaId As Long, _
                                        ByRef UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim PGG As New PGG
        Dim Mensaje As String = ""
        Dim t As Boolean = False
        Dim PriorizacionPorStakeholders As New PriorizacionPorStakeholders

        UpdateRelationsBetweenTablesUpdate = PriorizacionPorStakeholders.PriorizacionPorStakeholdersUpdate(RelationTable, RelationTableId, Puntaje, ProgramasMapaId, UserId)



    End Function


    Public Function CrearTareas(ByVal PivotId As Long, _
                                ByVal ChildId As Long, _
                                ByRef UserId As Long) As Long

        Dim dtr As IDataReader
        Dim sSQL As String
        Dim AccesoEA As New AccesoEA
        Dim PGG As New PGG
        Dim ProgramasMapa As New ProgramasMapa
        Dim Acciones As New Acciones
        Dim Actividades As New Actividades
        Dim Tareas As New Tareas
        Dim AccionesABM As New AccionesABM

        'PivotId es ProgramasMapaId, de la tabla ProgramasMapa debo obtener ProgramasCodigo y StakeholdersCodigo
        'ChilId es AccionesId

        Dim ProgramasCodigo As String = ""
        Dim StakeholdersCodigo As String = ""
        Dim PGGCodigo As String ' Etiqueta : C�digo del PGG - Control : txtPGGCodigo - Variable : PGGCodigo
        Dim AccionesCodigo As String ' Etiqueta : C�digo - Control : txtAccionesCodigo - Variable : AccionesCodigo

        CrearTareas = 0


        ProgramasCodigo = ProgramasMapa.LeerProgramasCodigo(PivotId)
        PGGCodigo = ProgramasCodigo
        StakeholdersCodigo = ProgramasMapa.LeerStakeholdersCodigo(PivotId)
        AccionesCodigo = Acciones.LeerAccionesCodigoById(ChildId)
        Dim ActividadesPorAccion As Long = 0

        If ActividadesPorAccion = 0 Then    'Solo se crean tareas asociadas a lo que indica la Accion
            CrearTareas = AccionesABM.CrearTareasPorAccion(PGGCodigo, AccionesCodigo, ChildId, PivotId, UserId)
        Else                                'Se crean tareas asociadas a las actividades detalladas de una macro acci�n
            sSQL = "SELECT ActividadesId "
            sSQL = sSQL & "FROM Actividades Where AccionesCodigo = '" & AccionesCodigo & "'"
            CrearTareas = 0
            Try
                dtr = AccesoEA.ListarRegistros(sSQL)
                While dtr.Read
                    CrearTareas = CrearTareas + AccionesABM.CrearTareasPorActividad(PGGCodigo, CLng(dtr("ActividadesId").ToString), ChildId, PivotId, UserId)
                End While
                dtr.Close()
            Catch
                CrearTareas = 0
            End Try
        End If

    End Function
    Public Function CrearTareasPorAccion(ByVal PGGCodigo As String, ByVal AccionesCodigo As String, ByVal AccionesId As Long, ByVal PGGId As Long, ByVal UserId As Long) As Long
        Dim t As Boolean
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim DistanciaEntreDias As Double = 0
        Dim DistanciaMediaEntreDias As Double = 0
        Dim ActividadesPorMes(11) As Long
        Dim TotalTareas As Long = 0
        Dim Acciones As New Acciones
        Dim PGG As New PGG
        Dim Programas As New Programas
        Dim Gerencias As New Gerencias
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim ProgramasMapa As New ProgramasMapa
        Dim StakeholdersCodigo As String = ProgramasMapa.LeerStakeholdersCodigo(PGGId)
        Dim ProgramasId As Long = 0


        '-------------------------------------------------------------------------------------------
        ' Declaraci�n de Campos de la Tabla Programas: Programas de Relacionamiento con Stakeholders
        '-------------------------------------------------------------------------------------------
        Dim ProgramasCodigo As String = "" ' Etiqueta : C�digo - Control : txtProgramasCodigo - Variable : ProgramasCodigo
        Dim ProgramasName As String = "" ' Etiqueta : Nombre - Control : txtProgramasName - Variable : ProgramasName
        Dim ProgramasAno As String = "" ' Etiqueta : A�o - Control : txtProgramasAno - Variable : ProgramasAno
        Dim GerenciasCodigo As String = "" ' Etiqueta : Gerencia - Control : txtGerenciasCodigo - Variable : GerenciasCodigo
        Dim ProgramasDescription As String = "" ' Etiqueta : Descripci�n - Control : txtProgramasDescription - Variable : ProgramasDescription
        Dim ProgramasAreaResponsableName As String = "" ' Etiqueta : �rea Responsable - Control : txtProgramasAreaResponsableName - Variable : ProgramasAreaResponsableName
        Dim ProgramasAreaEjecutoraName As String = "" ' Etiqueta : �rea Ejecutora - Control : txtProgramasAreaEjecutoraName - Variable : ProgramasAreaEjecutoraName
        Dim ZonaGeograficaName As String = "" ' Etiqueta : Zona Geogr�fica - Control : txtZonaGeograficaName - Variable : ZonaGeograficaName
        Dim ProgramasPeriodoInicio As String = "" ' Etiqueta : Mes y A�o de Inicio - Control : txtProgramasPeriodoInicio - Variable : ProgramasPeriodoInicio
        Dim ProgramasPeriodoTermino As String = "" ' Etiqueta : Mes y A�o de T�rmino - Control : txtProgramasPeriodoTermino - Variable : ProgramasPeriodoTermino
        Dim ProgramasElaboradoPor As String = "" ' Etiqueta : Elaborado Por - Control : txtProgramasElaboradoPor - Variable : ProgramasElaboradoPor
        Dim ProgramasRevisadoPor As String = "" ' Etiqueta : Revisado Por - Control : txtProgramasRevisadoPor - Variable : ProgramasRevisadoPor
        Dim ProgramasAprobadoPor As String = "" ' Etiqueta : Aprobado Por - Control : txtProgramasAprobadoPor - Variable : ProgramasAprobadoPor
        Dim ProgramasCoordinadoPor As String = "" ' Etiqueta : Coordinado Por - Control : txtProgramasCoordinadoPor - Variable : ProgramasCoordinadoPor
        Dim ProgramasPresupuestoTotal As Double = 0 ' Etiqueta : Presupuesto Total - Control : txtProgramasPresupuestoTotal - Variable : ProgramasPresupuestoTotal
        Dim ProgramasPresupuestoAnual As Double = 0 ' Etiqueta : Presupuesto Anual - Control : txtProgramasPresupuestoAnual - Variable : ProgramasPresupuestoAnual
        Dim ProgramasIndicadorLogro As String = "" ' Etiqueta : Indicador de Logro - Control : txtProgramasIndicadorLogro - Variable : ProgramasIndicadorLogro
        Dim ProgramasRespaldoCumplimiento As String = "" ' Etiqueta : Respaldo - Control : txtProgramasRespaldoCumplimiento - Variable : ProgramasRespaldoCumplimiento
        '----------------------------------------



        '----------------------------------------
        ' Declaraci�n de Campos de la Tabla PGG: Programa Global de Gesti�n
        '----------------------------------------
        'Dim PGGCodigo As String ' Etiqueta : C�digo del PGG - Control : txtPGGCodigo - Variable : PGGCodigo
        Dim PGGName As String = "" ' Etiqueta : Nombre - Control : txtPGGName - Variable : PGGName
        Dim PGGAno As String = "" ' Etiqueta : A�o - Control : txtPGGAno - Variable : PGGAno
        Dim ProyectosCodigo As String = "" ' Etiqueta : Proyecto - Control : txtProyectosCodigo - Variable : ProyectosCodigo
        Dim GerenciasCodigoPGG As String = "" ' Etiqueta : Gerencia del Proyecto - Control : txtGerenciasCodigo - Variable : GerenciasCodigo
        Dim PGGElaboradoPor As String = "" ' Etiqueta : Elaborado por - Control : txtPGGElaboradoPor - Variable : PGGElaboradoPor
        Dim PGGRevisadoPor As String = "" ' Etiqueta : Revisado por - Control : txtPGGRevisadoPor - Variable : PGGRevisadoPor
        Dim PGGAprobadoPor As String = "" ' Etiqueta : Aprobado po - Control : txtPGGAprobadoPor - Variable : PGGAprobadoPor
        Dim PGGCoordinadoPor As String = "" '
        Dim PGGResponsableSSO As String = "" '
        Dim PGGResponsableC As String = "" '
        Dim PGGResponsableMA As String = "" '
        Dim PGGResponsableQ As String = "" '
        '-------------------------------------------
        ' Declaraci�n de Campos de la Tabla Acciones
        '-------------------------------------------
        'Dim AccionesCodigo As String ' Etiqueta : C�digo - Control : txtAccionesCodigo - Variable : AccionesCodigo
        Dim AccionesName As String = "" ' Etiqueta : Acci�n - Control : txtAccionesName - Variable : AccionesName
        Dim AccionesDescription As String = "" ' Etiqueta : Descripci�n - Control : txtAccionesDescription - Variable : AccionesDescription
        Dim MetasCodigo As String = "" ' Etiqueta : Meta - Control : txtMetasCodigo - Variable : MetasCodigo
        Dim IndicadoresCodigo As String = "" ' Etiqueta : Indicador (KPI) - Control : txtIndicadoresCodigo - Variable : IndicadoresCodigo
        Dim AccionesMetaIndicador As Double ' Etiqueta : Valor esperado para el indicador - Control : txtAccionesMetaIndicador - Variable : AccionesMetaIndicador
        Dim AccionesObjetivoIndicador As String = "" ' Etiqueta : Objetivo del Indicador - Control : txtAccionesObjetivoIndicador - Variable : AccionesObjetivoIndicador
        Dim AmbitosCodigo As String = "" ' Etiqueta : �mbito al que aplica la acci�n - Control : txtAmbitosCodigo - Variable : AmbitosCodigo
        'Dim GerenciasCodigo As String = "" ' Etiqueta : Gerencia Responsable - Control : txtGerenciasCodigo - Variable : GerenciasCodigo
        Dim AccionesHH As Double ' Etiqueta : Esfuerzo Estimado (HH) - Control : txtAccionesHH - Variable : AccionesHH
        Dim AccionesUSD As Double ' Etiqueta : Presupuesto Estimado (USD) - Control : txtAccionesUSD - Variable : AccionesUSD
        Dim AccionesIsEnero As Long ' Etiqueta : Acciones en Enero - Control : txtAccionesIsEnero - Variable : AccionesIsEnero
        Dim AccionesIsFebrero As Long ' Etiqueta : Acciones en Febrero - Control : txtAccionesIsFebrero - Variable : AccionesIsFebrero
        Dim AccionesIsMarzo As Long ' Etiqueta : Acciones en Marzo - Control : txtAccionesIsMarzo - Variable : AccionesIsMarzo
        Dim AccionesIsAbril As Long ' Etiqueta : Acciones en Abril - Control : txtAccionesIsAbril - Variable : AccionesIsAbril
        Dim AccionesIsMayo As Long ' Etiqueta : Acciones en Mayo - Control : txtAccionesIsMayo - Variable : AccionesIsMayo
        Dim AccionesIsJunio As Long ' Etiqueta : Acciones en Junio - Control : txtAccionesIsJunio - Variable : AccionesIsJunio
        Dim AccionesIsJulio As Long ' Etiqueta : Acciones en Julio - Control : txtAccionesIsJulio - Variable : AccionesIsJulio
        Dim AccionesIsAgosto As Long ' Etiqueta : Acciones en Agosto - Control : txtAccionesIsAgosto - Variable : AccionesIsAgosto
        Dim AccionesIsSeptiembre As Long ' Etiqueta : Acciones en Septiembre - Control : txtAccionesIsSeptiembre - Variable : AccionesIsSeptiembre
        Dim AccionesIsOctubre As Long ' Etiqueta : Acciones en Octubre - Control : txtAccionesIsOctubre - Variable : AccionesIsOctubre
        Dim AccionesIsNoviembre As Long ' Etiqueta : Acciones en Noviembre - Control : txtAccionesIsNoviembre - Variable : AccionesIsNoviembre
        Dim AccionesIsDiciembre As Long ' Etiqueta : Acciones en Diciembre - Control : txtAccionesIsDiciembre - Variable : AccionesIsDiciembre
        '----------------------------------------
        ' Declaraci�n de Campos de la Tabla Tareas
        '----------------------------------------
        Dim TareasId As Long
        Dim TareasCodigo As String = "" ' Etiqueta : C�digo Tarea - Control : txtTareasCodigo - Variable : TareasCodigo
        Dim TareasName As String = "" ' Etiqueta : Objetivo - Control : txtTareasName - Variable : TareasName
        Dim TareasDescription As String = "" ' Etiqueta : Descripci�n - Control : txtTareasDescription - Variable : TareasDescription
        'Dim PGGCodigo As String ' Etiqueta : C�digo del PGG - Control : txtPGGCodigo - Variable : PGGCodigo
        'Dim AccionesCodigo As String ' Etiqueta : Acci�n del PGG - Control : txtAccionesCodigo - Variable : AccionesCodigo
        Dim ActividadesSecuencia As Long = 0 ' Etiqueta : Secuencia de Actividad - Control : txtActividadesSecuencia - Variable : ActividadesSecuencia
        Dim TareasMes As Long = 0 ' Etiqueta : Mes - Control : txtTareasMes - Variable : TareasMes
        Dim TareasAno As String = "" ' Etiqueta : A�o - Control : txtTareasAno - Variable : TareasAno
        Dim TareasSecuencia As Long = 0 ' Etiqueta : # de actividad - Control : txtTareasSecuencia - Variable : TareasSecuencia
        Dim UsuariosCodigo As String = "" ' Etiqueta : Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
        Dim TareasHH As Double = 0 ' Etiqueta : HH Estimadas - Control : txtTareasHH - Variable : TareasHH
        Dim TareasUSD As Double = 0 ' Etiqueta : Costo Estimado (USD) - Control : txtTareasUSD - Variable : TareasUSD
        Dim DiaMinimoInicio As Long = 0 ' Etiqueta : M�nimo d�a de inicio - Control : txtDiaMinimoInicio - Variable : DiaMinimoInicio
        Dim DiaMaximoTermino As Long = 0 ' Etiqueta : Max. D�a de T�rmino - Control : txtDiaMaximoTermino - Variable : DiaMaximoTermino
        Dim TareasDiaProgramado As Long = 0 ' Etiqueta : D�a sugerido - Control : txtTareasDiaProgramado - Variable : TareasDiaProgramado
        Dim TareasTipo As String = "Tarea Programada" ' Etiqueta : Tipo de Tarea - Control : txtTareasTipo - Variable : TareasTipo
        Dim TareasDiaRealTermino As Long = 0 ' Etiqueta : D�a Real de T�rmino - Control : txtTareasDiaRealTermino - Variable : TareasDiaRealTermino
        Dim TareasHHConsumidas As Double = 0 ' Etiqueta : HH Consumidas - Control : txtTareasHHConsumidas - Variable : TareasHHConsumidas
        Dim TareasUSDConsumidos As Double = 0 ' Etiqueta : Costo Real (USD) - Control : txtTareasUSDConsumidos - Variable : TareasUSDConsumidos
        Dim EstadoTareasCodigo As String = "Asignada" ' Etiqueta : Estado de Tarea - Control : txtEstadoTareasCodigo - Variable : EstadoTareasCodigo
        Dim TareasEjecutor As String = ""
        '----------------------------------------

        CrearTareasPorAccion = 0

        ' Leer PGG y la Acci�n asociada
        t = Programas.LeerProgramasByName(ProgramasId, ProgramasCodigo)
        t = Programas.LeerProgramas(ProgramasId, ProgramasCodigo, ProgramasName, ProgramasAno, GerenciasCodigo, ProgramasDescription, ProgramasAreaResponsableName, ProgramasAreaEjecutoraName, ZonaGeograficaName, ProgramasPeriodoInicio, ProgramasPeriodoTermino, ProgramasElaboradoPor, ProgramasRevisadoPor, ProgramasAprobadoPor, ProgramasCoordinadoPor, ProgramasPresupuestoTotal, ProgramasPresupuestoAnual, ProgramasIndicadorLogro, ProgramasRespaldoCumplimiento)
        't = PGG.LeerPGG(PGGId, PGGCodigo, PGGName, PGGAno, ProyectosCodigo, GerenciasCodigoPGG, PGGElaboradoPor, PGGRevisadoPor, PGGAprobadoPor, PGGCoordinadoPor, PGGResponsableSSO, PGGResponsableC, PGGResponsableMA, PGGResponsableQ)
        ' 14-07-2013
        't = Acciones.LeerAcciones(AccionesId, AccionesCodigo, AccionesName, AccionesDescription, MetasCodigo, IndicadoresCodigo, AccionesMetaIndicador, AccionesObjetivoIndicador, AmbitosCodigo, GerenciasCodigo, AccionesHH, AccionesUSD, AccionesIsEnero, AccionesIsFebrero, AccionesIsMarzo, AccionesIsAbril, AccionesIsMayo, AccionesIsJunio, AccionesIsJulio, AccionesIsAgosto, AccionesIsSeptiembre, AccionesIsOctubre, AccionesIsNoviembre, AccionesIsDiciembre)

        'Determinar el Total de Tareas a Crear
        TotalTareas = 0
        ActividadesPorMes(0) = AccionesIsEnero
        ActividadesPorMes(1) = AccionesIsFebrero
        ActividadesPorMes(2) = AccionesIsMarzo
        ActividadesPorMes(3) = AccionesIsAbril
        ActividadesPorMes(4) = AccionesIsMayo
        ActividadesPorMes(5) = AccionesIsJunio
        ActividadesPorMes(6) = AccionesIsJulio
        ActividadesPorMes(7) = AccionesIsAgosto
        ActividadesPorMes(8) = AccionesIsSeptiembre
        ActividadesPorMes(9) = AccionesIsOctubre
        ActividadesPorMes(10) = AccionesIsNoviembre
        ActividadesPorMes(11) = AccionesIsDiciembre
        For k = 0 To 11
            TotalTareas = TotalTareas + ActividadesPorMes(k)
        Next
        'Inicializo variable para crear una tarea
        TareasCodigo = "" ' Se reasigna m�s adelante
        TareasName = AccionesName
        TareasDescription = AccionesDescription
        ActividadesSecuencia = 0  'Para indicar que proviene de una acci�n y no de una actividad
        TareasMes = 0 ' Se reasigna m�s adelante
        TareasAno = PGGAno
        TareasSecuencia = 1 ' Se reasigna m�s adelante
        UsuariosCodigo = Gerencias.LeerUsuarioResponsable(GerenciasCodigo)
        TareasHH = (AccionesHH / 100) / TotalTareas ' Se asume una distribuci�n uniforme de las HH por cada tarea
        TareasUSD = (AccionesUSD / 100) / TotalTareas ' idem anterior
        DiaMinimoInicio = 1 ' Se reasigna m�s adelante
        DiaMaximoTermino = 28 ' Se reasigna m�s adelante
        TareasDiaProgramado = 14 ' Se reasigna m�s adelante
        TareasTipo = "Tarea Programada"
        TareasDiaRealTermino = 0
        TareasHHConsumidas = 0
        TareasUSDConsumidos = 0
        EstadoTareasCodigo = "Asignada"
        'Se recorre la tabla de actividades para ir creando las tareas por mes.
        For k = 0 To 11
            If ActividadesPorMes(k) > 0 Then 'se crean tareas, de lo contrario ese mes no tiene actividades
                DistanciaEntreDias = 28 / ActividadesPorMes(k)
                DistanciaMediaEntreDias = DistanciaEntreDias / 2 ' 
                TareasMes = k + 1
                For i = 1 To ActividadesPorMes(k)
                    TareasSecuencia = i
                    DiaMinimoInicio = 1 + DistanciaEntreDias * (i - 1)
                    TareasDiaProgramado = DistanciaMediaEntreDias + DistanciaEntreDias * (i - 1)
                    DiaMaximoTermino = DistanciaEntreDias * i
                    TareasCodigo = PGGCodigo & "-" & AccionesCodigo & "-" & ActividadesSecuencia & "-" & UsuariosCodigo & "-" & TareasAno & "-" & TareasMes & "-" & TareasSecuencia
                    t = AccionesABM.MasterPartialInsert("TareasId", "TareasCodigo", "Tareas", TareasCodigo, UserId, TareasId)
                    TareasCodigo = TareasCodigo & "-" & TareasId 'SE agrega el Id de la Tarea para asegurar que el c�digo sea �nico
                    t = Tareas.TareasUpdate(TareasId, TareasCodigo, TareasName, TareasDescription, PGGCodigo, AccionesCodigo, CLng(ActividadesSecuencia), CLng(TareasMes), TareasAno, CLng(TareasSecuencia), UsuariosCodigo, CDbl(TareasHH * 100), CDbl(TareasUSD * 100), CLng(DiaMinimoInicio), CLng(DiaMaximoTermino), CLng(TareasDiaProgramado), TareasTipo, CLng(TareasDiaRealTermino), CDbl(TareasHHConsumidas * 100), CDbl(TareasUSDConsumidos * 100), EstadoTareasCodigo, UserId)
                    t = Tareas.TareasEjecutorUpdate(TareasId, TareasCodigo, UsuariosCodigo, AccionesCodigo, UserId)
                    CrearTareasPorAccion = CrearTareasPorAccion + 1
                Next
            End If
        Next
    End Function
    Public Function CrearTareasPorActividad(ByVal PGGCodigo As String, ByVal ActividadesId As Long, ByVal AccionesId As Long, ByVal PGGId As Long, ByVal UserId As Long) As Long
        Dim t As Boolean
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim DistanciaEntreDias As Double = 0
        Dim DistanciaMediaEntreDias As Double = 0
        Dim ActividadesPorMes(11) As Long
        Dim TotalTareas As Long = 0
        Dim Acciones As New Acciones
        Dim PGG As New PGG
        Dim Gerencias As New Gerencias
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim Tareas As New Tareas
        Dim Actividades As New Actividades
        Dim Cargos As New Cargos
        Dim UsuariosPorCargo As Long = 0
        Dim TablaUsuariosPorCargo(99) As String

        '----------------------------------------
        ' Declaraci�n de Campos de la Tabla PGG: Programa Global de Gesti�n
        '----------------------------------------
        'Dim PGGCodigo As String ' Etiqueta : C�digo del PGG - Control : txtPGGCodigo - Variable : PGGCodigo
        Dim PGGName As String = "" ' Etiqueta : Nombre - Control : txtPGGName - Variable : PGGName
        Dim PGGAno As String = "" ' Etiqueta : A�o - Control : txtPGGAno - Variable : PGGAno
        Dim ProyectosCodigo As String = "" ' Etiqueta : Proyecto - Control : txtProyectosCodigo - Variable : ProyectosCodigo
        Dim GerenciasCodigoPGG As String = "" ' Etiqueta : Gerencia del Proyecto - Control : txtGerenciasCodigo - Variable : GerenciasCodigo
        Dim PGGElaboradoPor As String = "" ' Etiqueta : Elaborado por - Control : txtPGGElaboradoPor - Variable : PGGElaboradoPor
        Dim PGGRevisadoPor As String = "" ' Etiqueta : Revisado por - Control : txtPGGRevisadoPor - Variable : PGGRevisadoPor
        Dim PGGAprobadoPor As String = "" ' Etiqueta : Aprobado po - Control : txtPGGAprobadoPor - Variable : PGGAprobadoPor
        Dim PGGCoordinadoPor As String = "" '
        Dim PGGResponsableSSO As String = "" '
        Dim PGGResponsableC As String = "" '
        Dim PGGResponsableMA As String = "" '
        Dim PGGResponsableQ As String = "" '
        '----------------------------------------
        ' Declaraci�n de Campos de la Tabla Actividades
        '----------------------------------------
        Dim AccionesCodigo As String = "" ' Etiqueta : C�digo Acci�n - Control : txtAccionesCodigo - Variable : AccionesCodigo
        Dim ActividadesSecuenciaACT As Long ' Etiqueta : Secuencia - Control : txtActividadesSecuencia - Variable : ActividadesSecuencia
        Dim ActividadObjetivo As String = "" ' Etiqueta : Objetivo - Control : txtActividadObjetivo - Variable : ActividadObjetivo
        Dim ActividadEspecifica As String = "" ' Etiqueta : Actividad Espec�fica - Control : txtActividadEspecifica - Variable : ActividadEspecifica
        Dim ActividadPublicoObjetivo As String = "" ' Etiqueta : P�blico Objetivo - Control : txtActividadPublicoObjetivo - Variable : ActividadPublicoObjetivo
        Dim ActividadOtrasObservaciones As String = "" ' Etiqueta : Otras Observaciones - Control : txtActividadOtrasObservaciones - Variable : ActividadOtrasObservaciones
        Dim CargosCodigo As String = "" ' Etiqueta : Cargo Responsable - Control : txtCargosCodigo - Variable : CargosCodigo
        Dim ActividadesHH As Double ' Etiqueta : HH Estimadas - Control : txtActividadesHH - Variable : ActividadesHH
        Dim ActividadesUSD As Double ' Etiqueta : USD Estimados - Control : txtActividadesUSD - Variable : ActividadesUSD
        Dim ActividadesEnEnero As Long ' Etiqueta : # Actividades En Enero - Control : txtActividadesEnEnero - Variable : ActividadesEnEnero
        Dim ActividadesEnFebrero As Long ' Etiqueta : # Actividades En Febrero - Control : txtActividadesEnFebrero - Variable : ActividadesEnFebrero
        Dim ActividadesEnMarzo As Long ' Etiqueta : # Actividades En Marzo - Control : txtActividadesEnMarzo - Variable : ActividadesEnMarzo
        Dim ActividadesEnAbril As Long ' Etiqueta : # Actividades En Abril - Control : txtActividadesEnAbril - Variable : ActividadesEnAbril
        Dim ActividadesEnMayo As Long ' Etiqueta : # Actividades En Mayo - Control : txtActividadesEnMayo - Variable : ActividadesEnMayo
        Dim ActividadesEnJunio As Long ' Etiqueta : # Actividades En Junio - Control : txtActividadesEnJunio - Variable : ActividadesEnJunio
        Dim ActividadesEnJulio As Long ' Etiqueta : # Actividades En Julio - Control : txtActividadesEnJulio - Variable : ActividadesEnJulio
        Dim ActividadesEnAgosto As Long ' Etiqueta : # Actividades En Agosto - Control : txtActividadesEnAgosto - Variable : ActividadesEnAgosto
        Dim ActividadesEnSeptiembre As Long ' Etiqueta : # Actividades En Septiembre - Control : txtActividadesEnSeptiembre - Variable : ActividadesEnSeptiembre
        Dim ActividadesEnOctubre As Long ' Etiqueta : # Actividades En Octubre - Control : txtActividadesEnOctubre - Variable : ActividadesEnOctubre
        Dim ActividadesEnNoviembre As Long ' Etiqueta : # Actividades En Noviembre - Control : txtActividadesEnNoviembre - Variable : ActividadesEnNoviembre
        Dim ActividadesEnDiciembre As Long ' Etiqueta : # Actividades En Diciembre - Control : txtActividadesEnDiciembre - Variable : ActividadesEnDiciembre
        '----------------------------------------
        ' Declaraci�n de Campos de la Tabla Tareas
        '----------------------------------------
        Dim TareasId As Long
        Dim TareasCodigo As String = "" ' Etiqueta : C�digo Tarea - Control : txtTareasCodigo - Variable : TareasCodigo
        Dim TareasName As String = "" ' Etiqueta : Objetivo - Control : txtTareasName - Variable : TareasName
        Dim TareasDescription As String = "" ' Etiqueta : Descripci�n - Control : txtTareasDescription - Variable : TareasDescription
        'Dim PGGCodigo As String ' Etiqueta : C�digo del PGG - Control : txtPGGCodigo - Variable : PGGCodigo
        'Dim AccionesCodigo As String ' Etiqueta : Acci�n del PGG - Control : txtAccionesCodigo - Variable : AccionesCodigo
        Dim ActividadesSecuencia As Long = 0 ' Etiqueta : Secuencia de Actividad - Control : txtActividadesSecuencia - Variable : ActividadesSecuencia
        Dim TareasMes As Long = 0 ' Etiqueta : Mes - Control : txtTareasMes - Variable : TareasMes
        Dim TareasAno As String = "" ' Etiqueta : A�o - Control : txtTareasAno - Variable : TareasAno
        Dim TareasSecuencia As Long = 0 ' Etiqueta : # de actividad - Control : txtTareasSecuencia - Variable : TareasSecuencia
        Dim UsuariosCodigo As String = "" ' Etiqueta : Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
        Dim TareasHH As Double = 0 ' Etiqueta : HH Estimadas - Control : txtTareasHH - Variable : TareasHH
        Dim TareasUSD As Double = 0 ' Etiqueta : Costo Estimado (USD) - Control : txtTareasUSD - Variable : TareasUSD
        Dim DiaMinimoInicio As Long = 0 ' Etiqueta : M�nimo d�a de inicio - Control : txtDiaMinimoInicio - Variable : DiaMinimoInicio
        Dim DiaMaximoTermino As Long = 0 ' Etiqueta : Max. D�a de T�rmino - Control : txtDiaMaximoTermino - Variable : DiaMaximoTermino
        Dim TareasDiaProgramado As Long = 0 ' Etiqueta : D�a sugerido - Control : txtTareasDiaProgramado - Variable : TareasDiaProgramado
        Dim TareasTipo As String = "Tarea Programada" ' Etiqueta : Tipo de Tarea - Control : txtTareasTipo - Variable : TareasTipo
        Dim TareasDiaRealTermino As Long = 0 ' Etiqueta : D�a Real de T�rmino - Control : txtTareasDiaRealTermino - Variable : TareasDiaRealTermino
        Dim TareasHHConsumidas As Double = 0 ' Etiqueta : HH Consumidas - Control : txtTareasHHConsumidas - Variable : TareasHHConsumidas
        Dim TareasUSDConsumidos As Double = 0 ' Etiqueta : Costo Real (USD) - Control : txtTareasUSDConsumidos - Variable : TareasUSDConsumidos
        Dim EstadoTareasCodigo As String = "Asignada" ' Etiqueta : Estado de Tarea - Control : txtEstadoTareasCodigo - Variable : EstadoTareasCodigo
        Dim TareasEjecutor As String = ""
        '----------------------------------------

        CrearTareasPorActividad = 0

        ' Leer PGG y la Acci�n asociada

        t = PGG.LeerPGG(PGGId, PGGCodigo, PGGName, PGGAno, ProyectosCodigo, GerenciasCodigoPGG, PGGElaboradoPor, PGGRevisadoPor, PGGAprobadoPor, PGGCoordinadoPor, PGGResponsableSSO, PGGResponsableC, PGGResponsableMA, PGGResponsableQ)
        t = Actividades.LeerActividades(ActividadesId, AccionesCodigo, ActividadesSecuenciaACT, ActividadObjetivo, ActividadEspecifica, ActividadPublicoObjetivo, ActividadOtrasObservaciones, CargosCodigo, ActividadesHH, ActividadesUSD, ActividadesEnEnero, ActividadesEnFebrero, ActividadesEnMarzo, ActividadesEnAbril, ActividadesEnMayo, ActividadesEnJunio, ActividadesEnJulio, ActividadesEnAgosto, ActividadesEnSeptiembre, ActividadesEnOctubre, ActividadesEnNoviembre, ActividadesEnDiciembre)

        'Determinar el Total de Tareas a Crear
        TotalTareas = 0
        ActividadesPorMes(0) = ActividadesEnEnero
        ActividadesPorMes(1) = ActividadesEnFebrero
        ActividadesPorMes(2) = ActividadesEnMarzo
        ActividadesPorMes(3) = ActividadesEnAbril
        ActividadesPorMes(4) = ActividadesEnMayo
        ActividadesPorMes(5) = ActividadesEnJunio
        ActividadesPorMes(6) = ActividadesEnJulio
        ActividadesPorMes(7) = ActividadesEnAgosto
        ActividadesPorMes(8) = ActividadesEnSeptiembre
        ActividadesPorMes(9) = ActividadesEnOctubre
        ActividadesPorMes(10) = ActividadesEnNoviembre
        ActividadesPorMes(11) = ActividadesEnDiciembre
        For k = 0 To 11
            TotalTareas = TotalTareas + ActividadesPorMes(k)
        Next
        ' Vemos si hay m�s de un usuario para el cargo asignado a la tarea
        ' Si es as� este es un factor multiplicador para el n�mero de tareas a generar
        ' Aqui se incorporo un cambio y se ve que usuarios hay por actividad ya que al crear la
        ' actividad ahora se puede seleccionar que usuarios que ocupan el cargo la ejecutan ya que
        ' en algunos casos no son todos.  Para efectos pr�cticos se creara otro metodo dependiendo de
        ' la tabla de actividades y de la tabla de usuarios por actividad
        UsuariosPorCargo = Actividades.LeerUsuariosCodigoPorActividad(ActividadesId, TablaUsuariosPorCargo)
        TotalTareas = TotalTareas * UsuariosPorCargo
        ' Se verifica que el n�mero de tareas sea mayor a 0, para crear tareas
        If (TotalTareas > 0 And UsuariosPorCargo > 0) Then
            'Inicializo variable para crear una tarea
            TareasCodigo = "" ' Se reasigna m�s adelante
            TareasName = ActividadObjetivo
            TareasDescription = "Actividad Especifica: " & ActividadEspecifica & " P�blico Objetivo: " & ActividadPublicoObjetivo & " Otras Observaciones: " & ActividadOtrasObservaciones
            ActividadesSecuencia = ActividadesSecuenciaACT
            TareasMes = 0 ' Se reasigna m�s adelante
            TareasAno = PGGAno
            TareasSecuencia = 1 ' Se reasigna m�s adelante
            UsuariosCodigo = "" ' Se reasigna porque es un factor multiplicador de tareas en caso de que para un cargo exista m�s de un usuario
            TareasHH = (ActividadesHH / 100) / TotalTareas ' Se asume una distribuci�n uniforme de las HH por cada tarea
            TareasUSD = (ActividadesUSD / 100) / TotalTareas ' idem anterior
            DiaMinimoInicio = 1 ' Se reasigna m�s adelante
            DiaMaximoTermino = 28 ' Se reasigna m�s adelante
            TareasDiaProgramado = 14 ' Se reasigna m�s adelante
            TareasTipo = "Tarea Programada"
            TareasDiaRealTermino = 0
            TareasHHConsumidas = 0
            TareasUSDConsumidos = 0
            EstadoTareasCodigo = "Asignada"
            'Se recorre la tabla de actividades para ir creando las tareas por mes y por usuario del cargo.
            For k = 0 To 11
                If ActividadesPorMes(k) > 0 Then 'se crean tareas, de lo contrario ese mes no tiene actividades
                    DistanciaEntreDias = 28 / ActividadesPorMes(k)
                    DistanciaMediaEntreDias = DistanciaEntreDias / 2 ' 
                    TareasMes = k + 1
                    For i = 1 To ActividadesPorMes(k)
                        TareasSecuencia = i
                        DiaMinimoInicio = 1 + DistanciaEntreDias * (i - 1)
                        TareasDiaProgramado = DistanciaMediaEntreDias + DistanciaEntreDias * (i - 1)
                        DiaMaximoTermino = DistanciaEntreDias * i
                        For j = 0 To UsuariosPorCargo - 1
                            TareasCodigo = PGGCodigo & "-" & AccionesCodigo & "-" & ActividadesSecuencia & "-" & TablaUsuariosPorCargo(j) & "-" & TareasAno & "-" & TareasMes & "-" & TareasSecuencia
                            t = AccionesABM.MasterPartialInsert("TareasId", "TareasCodigo", "Tareas", TareasCodigo, UserId, TareasId)
                            TareasCodigo = TareasCodigo & "-" & TareasId 'SE agrega el Id de la Tarea para asegurar que el c�digo sea �nico
                            t = Tareas.TareasUpdate(TareasId, TareasCodigo, TareasName, TareasDescription, PGGCodigo, AccionesCodigo, CLng(ActividadesSecuencia), CLng(TareasMes), TareasAno, CLng(TareasSecuencia), TablaUsuariosPorCargo(j), CDbl(TareasHH * 100), CDbl(TareasUSD * 100), CLng(DiaMinimoInicio), CLng(DiaMaximoTermino), CLng(TareasDiaProgramado), TareasTipo, CLng(TareasDiaRealTermino), CDbl(TareasHHConsumidas * 100), CDbl(TareasUSDConsumidos * 100), EstadoTareasCodigo, UserId)
                            t = Tareas.TareasEjecutorUpdate(TareasId, TareasCodigo, TablaUsuariosPorCargo(j), AccionesCodigo, UserId)
                            CrearTareasPorActividad = CrearTareasPorActividad + 1
                        Next
                    Next
                End If
            Next
        End If
    End Function
    Public Function EnviarCorreo(ByVal Correo As String, ByVal Id As Long) As Integer
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
        Dim Lecturas As New Lecturas
        Dim PGG As New PGG
        Dim Acciones As New Acciones
        Dim Metas As New Metas
        Dim Indicadores As New Indicadores
        Dim Objetivos As New Objetivos
        Dim Compromisos As New Compromisos
        Dim Proyectos As New Proyectos
        Dim EstadoTareas As New EstadoTareas
        Dim t As Boolean = True
        Dim NumeroMesEnCurso As Integer = System.DateTime.Today.Month
        Dim AccionesABM As New AccionesABM
        Dim Coordinador As String = ""
        Dim Ejecutor As String = ""
        Dim Desde As String = ""
        Dim Hasta As String = ""
        Dim Cuerpo As String = ""

        '----------------------------------------
        ' Declaraci�n de Campos de la Tabla Tareas
        '----------------------------------------
        Dim TareasCodigo As String = "" ' Etiqueta : C�digo Tarea - Control : txtTareasCodigo - Variable : TareasCodigo
        Dim TareasName As String = "" ' Etiqueta : Objetivo - Control : txtTareasName - Variable : TareasName
        Dim TareasDescription As String = "" ' Etiqueta : Descripci�n - Control : txtTareasDescription - Variable : TareasDescription
        Dim PGGCodigo As String = "" ' Etiqueta : C�digo del PGG - Control : txtPGGCodigo - Variable : PGGCodigo
        Dim AccionesCodigo As String = "" ' Etiqueta : Acci�n del PGG - Control : txtAccionesCodigo - Variable : AccionesCodigo
        Dim ActividadesSecuencia As Long = 0 ' Etiqueta : Secuencia de Actividad - Control : txtActividadesSecuencia - Variable : ActividadesSecuencia
        Dim TareasMes As Long = 0 ' Etiqueta : Mes - Control : txtTareasMes - Variable : TareasMes
        Dim TareasAno As String = "" ' Etiqueta : A�o - Control : txtTareasAno - Variable : TareasAno
        Dim TareasSecuencia As Long = 0 ' Etiqueta : # de actividad - Control : txtTareasSecuencia - Variable : TareasSecuencia
        Dim UsuariosCodigo As String = "" ' Etiqueta : Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
        Dim TareasHH As Double = 0 ' Etiqueta : HH Estimadas - Control : txtTareasHH - Variable : TareasHH
        Dim TareasUSD As Double = 0 ' Etiqueta : Costo Estimado (USD) - Control : txtTareasUSD - Variable : TareasUSD
        Dim DiaMinimoInicio As Long = 0 ' Etiqueta : M�nimo d�a de inicio - Control : txtDiaMinimoInicio - Variable : DiaMinimoInicio
        Dim DiaMaximoTermino As Long = 0 ' Etiqueta : Max. D�a de T�rmino - Control : txtDiaMaximoTermino - Variable : DiaMaximoTermino
        Dim TareasDiaProgramado As Long = 0 ' Etiqueta : D�a sugerido - Control : txtTareasDiaProgramado - Variable : TareasDiaProgramado
        Dim TareasTipo As String = "Tarea Programada" ' Etiqueta : Tipo de Tarea - Control : txtTareasTipo - Variable : TareasTipo
        Dim TareasDiaRealTermino As Long = 0 ' Etiqueta : D�a Real de T�rmino - Control : txtTareasDiaRealTermino - Variable : TareasDiaRealTermino
        Dim TareasHHConsumidas As Double = 0 ' Etiqueta : HH Consumidas - Control : txtTareasHHConsumidas - Variable : TareasHHConsumidas
        Dim TareasUSDConsumidos As Double = 0 ' Etiqueta : Costo Real (USD) - Control : txtTareasUSDConsumidos - Variable : TareasUSDConsumidos
        Dim EstadoTareasCodigo As String = "Asignada" ' Etiqueta : Estado de Tarea - Control : txtEstadoTareasCodigo - Variable : EstadoTareasCodigo

        t = Tareas.LeerTareas(Id, TareasCodigo, TareasName, TareasDescription, PGGCodigo, AccionesCodigo, ActividadesSecuencia, TareasMes, TareasAno, TareasSecuencia, UsuariosCodigo, TareasHH, TareasUSD, DiaMinimoInicio, DiaMaximoTermino, TareasDiaProgramado, TareasTipo, TareasDiaRealTermino, TareasHHConsumidas, TareasUSDConsumidos, EstadoTareasCodigo)

        Coordinador = Tareas.LeerCoordinadorDeTareas(TareasCodigo)
        Ejecutor = UsuariosCodigo
        Correo = UsuariosCodigo
        Desde = Usuarios.LeerUsuariosDescriptionByName(Coordinador)
        Hasta = Usuarios.LeerUsuariosDescriptionByName(Ejecutor)

        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(EstadoTareasCodigo)

        Dim definition As New MailDefinition
        Dim smtpcliente As New SmtpClient("mail.zrismart.cl")
        definition.BodyFileName = HttpContext.Current.Server.MapPath("~/PlantillaTareas.htm")
        'definition.BodyFileName = HttpContext.Current.Server.MapPath("~/App_Data/HolaMundo.txt")
        definition.IsBodyHtml = True
        'definition.CC = "flepori@codelco.cl, dandrade@gs3.cl, javen004@codelco.cl"
        If TareasMes < NumeroMesEnCurso Then
            definition.Subject = "Aviso de Tarea Atrasada" ' Tarea atrasada
            Cuerpo = "Solicitamos a usted ejecutar la tarea solicitada"
        End If

        If TareasMes = NumeroMesEnCurso Then
            definition.Subject = "Aviso de Tarea Pr�xima a su Vencimiento dentro del mes en curso" ' Tarea Pr�xima a vencer
            Cuerpo = "Recordamos a usted ejecutar la tarea solicitada"
        End If
        If TareasMes > NumeroMesEnCurso Then
            definition.Subject = "Aviso de Asignaci�n de Tarea" ' Aviso de Asignaci�n de Tarea
            Cuerpo = "Solicitamos nos confirme su aceptaci�n a la tarea solicitada"
        End If

        definition.From = "sgi@zrismart.cl"
        Dim now As DateTime = DateTime.Now
        Dim replacements As IDictionary = New ListDictionary
        replacements.Add("<%Nombre%>", Usuarios.LeerUsuariosDescriptionByName(Correo))
        replacements.Add("<%Aviso%>", definition.Subject)
        replacements.Add("<%Desde%>", Desde)
        replacements.Add("<%Cuerpo%>", Cuerpo)
        replacements.Add("<%TareasCodigo%>", TareasCodigo)
        replacements.Add("<%TareasAno%>", Lecturas.NombreMes(TareasMes) & " de " & TareasAno)
        replacements.Add("<%TareasName%>", TareasName)
        'replacements.Add("<%DiaMinimoInicio%>", CStr(DiaMinimoInicio))
        'replacements.Add("<%DiaMaximoTermino%>", CStr(DiaMaximoTermino))
        replacements.Add("<%TareasDiaProgramado%>", CStr(TareasDiaProgramado))
        'replacements.Add("<%PGGCodigo%>", PGGCodigo)
        'replacements.Add("<%PGGName%>", PGG.LeerPGGDescriptionByName(PGGCodigo))
        'replacements.Add("<%ProyectosCodigo%>", PGG.LeerProyectosCodigoByPGGCodigo(PGGCodigo))
        'replacements.Add("<%ProyectosName%>", Proyectos.LeerProyectosDescriptionByName(PGG.LeerProyectosCodigoByPGGCodigo(PGGCodigo)))
        'replacements.Add("<%AccionesName%>", Acciones.LeerAccionesDescriptionByName(AccionesCodigo))
        replacements.Add("<%Fecha%>", now.ToShortDateString)
        replacements.Add("<%Hora%>", now.ToShortTimeString)
        Using message As MailMessage = definition.CreateMailMessage("dandrade56@gmail.com", replacements, New Control)
            smtpcliente.Send(message)
        End Using
        EnviarCorreo = 1

        t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, definition.Subject)

    End Function

    Public Function EnviarMensaje(ByVal TareasId As Long, ByVal TareasNotasId As Long, ByVal UserId As Long) As Boolean
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Lecturas As New Lecturas
        Dim PGG As New PGG
        Dim Acciones As New Acciones
        Dim Metas As New Metas
        Dim Indicadores As New Indicadores
        Dim Objetivos As New Objetivos
        Dim Compromisos As New Compromisos
        Dim Proyectos As New Proyectos
        Dim EstadoTareas As New EstadoTareas
        Dim t As Boolean = True
        Dim NumeroMesEnCurso As Integer = System.DateTime.Today.Month
        Dim AccionesABM As New AccionesABM
        Dim TareasNotas As New TareasNotas
        Dim Coordinador As String = ""
        Dim Ejecutor As String = ""
        Dim Correo As String = ""
        Dim Desde As String = ""
        Dim Hasta As String = ""

        '----------------------------------------
        ' Declaraci�n de Campos de la Tabla Tareas
        '----------------------------------------
        Dim TareasCodigo As String = "" ' Etiqueta : C�digo Tarea - Control : txtTareasCodigo - Variable : TareasCodigo
        Dim TareasName As String = "" ' Etiqueta : Objetivo - Control : txtTareasName - Variable : TareasName
        Dim TareasDescription As String = "" ' Etiqueta : Descripci�n - Control : txtTareasDescription - Variable : TareasDescription
        Dim PGGCodigo As String = "" ' Etiqueta : C�digo del PGG - Control : txtPGGCodigo - Variable : PGGCodigo
        Dim AccionesCodigo As String = "" ' Etiqueta : Acci�n del PGG - Control : txtAccionesCodigo - Variable : AccionesCodigo
        Dim ActividadesSecuencia As Long = 0 ' Etiqueta : Secuencia de Actividad - Control : txtActividadesSecuencia - Variable : ActividadesSecuencia
        Dim TareasMes As Long = 0 ' Etiqueta : Mes - Control : txtTareasMes - Variable : TareasMes
        Dim TareasAno As String = "" ' Etiqueta : A�o - Control : txtTareasAno - Variable : TareasAno
        Dim TareasSecuencia As Long = 0 ' Etiqueta : # de actividad - Control : txtTareasSecuencia - Variable : TareasSecuencia
        Dim UsuariosCodigo As String = "" ' Etiqueta : Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
        Dim TareasHH As Double = 0 ' Etiqueta : HH Estimadas - Control : txtTareasHH - Variable : TareasHH
        Dim TareasUSD As Double = 0 ' Etiqueta : Costo Estimado (USD) - Control : txtTareasUSD - Variable : TareasUSD
        Dim DiaMinimoInicio As Long = 0 ' Etiqueta : M�nimo d�a de inicio - Control : txtDiaMinimoInicio - Variable : DiaMinimoInicio
        Dim DiaMaximoTermino As Long = 0 ' Etiqueta : Max. D�a de T�rmino - Control : txtDiaMaximoTermino - Variable : DiaMaximoTermino
        Dim TareasDiaProgramado As Long = 0 ' Etiqueta : D�a sugerido - Control : txtTareasDiaProgramado - Variable : TareasDiaProgramado
        Dim TareasTipo As String = "Tarea Programada" ' Etiqueta : Tipo de Tarea - Control : txtTareasTipo - Variable : TareasTipo
        Dim TareasDiaRealTermino As Long = 0 ' Etiqueta : D�a Real de T�rmino - Control : txtTareasDiaRealTermino - Variable : TareasDiaRealTermino
        Dim TareasHHConsumidas As Double = 0 ' Etiqueta : HH Consumidas - Control : txtTareasHHConsumidas - Variable : TareasHHConsumidas
        Dim TareasUSDConsumidos As Double = 0 ' Etiqueta : Costo Real (USD) - Control : txtTareasUSDConsumidos - Variable : TareasUSDConsumidos
        Dim EstadoTareasCodigo As String = "Asignada" ' Etiqueta : Estado de Tarea - Control : txtEstadoTareasCodigo - Variable : EstadoTareasCodigo
        '----------------------------------------
        ' Declaraci�n de Campos de la Aplicaci�n
        '----------------------------------------
        'Dim TareasCodigo As String ' Etiqueta : Tarea # - Control : txtTareasCodigo - Variable : TareasCodigo
        Dim TareasNotasSecuencia As Long ' Etiqueta : Secuencia - Control : txtTareasNotasSecuencia - Variable : TareasNotasSecuencia
        Dim TareasNotasTime As Date ' Etiqueta : Fecha y Hora - Control : txtTareasNotasTime - Variable : TareasNotasTime
        Dim TareasNotasFrom As String ' Etiqueta : De - Control : txtTareasNotasFrom - Variable : TareasNotasFrom
        Dim TareasNotasTo As String ' Etiqueta : A - Control : txtTareasNotasTo - Variable : TareasNotasTo
        Dim TareasNotasSubject As String ' Etiqueta : Materia - Control : txtTareasNotasSubject - Variable : TareasNotasSubject
        Dim TareasNotasBody As String ' Etiqueta : Texto del Mensaje - Control : txtTareasNotasBody - Variable : TareasNotasBody
        '----------------------------------------

        t = Tareas.LeerTareas(TareasId, TareasCodigo, TareasName, TareasDescription, PGGCodigo, AccionesCodigo, ActividadesSecuencia, TareasMes, TareasAno, TareasSecuencia, UsuariosCodigo, TareasHH, TareasUSD, DiaMinimoInicio, DiaMaximoTermino, TareasDiaProgramado, TareasTipo, TareasDiaRealTermino, TareasHHConsumidas, TareasUSDConsumidos, EstadoTareasCodigo)
        t = TareasNotas.LeerTareasNotas(TareasNotasId, TareasCodigo, TareasNotasSecuencia, TareasNotasTime, TareasNotasFrom, TareasNotasTo, TareasNotasSubject, TareasNotasBody)

        Coordinador = Tareas.LeerCoordinadorDeTareas(TareasCodigo)
        Ejecutor = Tareas.LeerEjecutorDeTareas(TareasCodigo)
        If UsuariosCodigo = Coordinador Then    'Mensaje del coordinador al ejecutor
            TareasNotasFrom = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)
            TareasNotasTo = Usuarios.LeerUsuariosDescriptionByName(Ejecutor)
            Correo = Ejecutor
        Else                                    'Mensaje del ejecutor al coordinador
            TareasNotasFrom = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)
            TareasNotasTo = Usuarios.LeerUsuariosDescriptionByName(Coordinador)
            Correo = Coordinador
        End If

        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(EstadoTareasCodigo)

        Dim definition As New MailDefinition
        Dim smtpcliente As New SmtpClient("mail.zrismart.cl")
        definition.BodyFileName = HttpContext.Current.Server.MapPath("~/PlantillaMensajes.htm")
        'definition.BodyFileName = HttpContext.Current.Server.MapPath("~/App_Data/HolaMundo.txt")
        definition.IsBodyHtml = True
        definition.Subject = TareasNotasSubject
        definition.From = "sgi@zrismart.cl"
        'definition.CC = "flepori@codelco.cl, dandrade@gs3.cl, javen004@codelco.cl"
        Dim now As DateTime = DateTime.Now
        TareasNotasTime = now
        Dim replacements As IDictionary = New ListDictionary
        replacements.Add("<%Nombre%>", Usuarios.LeerUsuariosDescriptionByName(Correo))
        replacements.Add("<%Aviso%>", definition.Subject)
        replacements.Add("<%Desde%>", TareasNotasFrom)
        replacements.Add("<%Cuerpo%>", Tareas.ListarDatosDelDeudorPorTareasId(TareasId, CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(TareasId))))
        'replacements.Add("<%TareasCodigo%>", TareasCodigo)
        'replacements.Add("<%TareasAno%>", Lecturas.NombreMes(TareasMes) & " de " & TareasAno)
        'replacements.Add("<%TareasName%>", TareasName)
        'replacements.Add("<%DiaMinimoInicio%>", CStr(DiaMinimoInicio))
        'replacements.Add("<%DiaMaximoTermino%>", CStr(DiaMaximoTermino))
        'replacements.Add("<%TareasDiaProgramado%>", CStr(TareasDiaProgramado))
        'replacements.Add("<%PGGCodigo%>", PGGCodigo)
        'replacements.Add("<%PGGName%>", PGG.LeerPGGDescriptionByName(PGGCodigo))
        'replacements.Add("<%ProyectosCodigo%>", PGG.LeerProyectosCodigoByPGGCodigo(PGGCodigo))
        'replacements.Add("<%ProyectosName%>", Proyectos.LeerProyectosDescriptionByName(PGG.LeerProyectosCodigoByPGGCodigo(PGGCodigo)))
        'replacements.Add("<%AccionesName%>", Acciones.LeerAccionesDescriptionByName(AccionesCodigo))
        replacements.Add("<%Fecha%>", now.ToShortDateString)
        replacements.Add("<%Hora%>", now.ToShortTimeString)
        Using message As MailMessage = definition.CreateMailMessage("dandrade56@gmail.com", replacements, New Control)
            smtpcliente.Send(message)
        End Using
        EnviarMensaje = True
        't = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, definition.Subject)
        't = TareasNotas.TareasNotasUpdate(TareasNotasId, TareasCodigo, TareasNotasSecuencia, TareasNotasTime, TareasNotasFrom, TareasNotasTo, TareasNotasSubject, TareasNotasBody, UserId)
    End Function
    Public Function EnviarMensajeDemanda(ByVal TareasId As Long, _
                                                ByVal CarpetaJudicialId As Long, _
                                                ByVal Comentarios As String, _
                                                ByVal Secretaria As String, _
                                                ByVal Procurador As String, _
                                                ByVal Supervisor As String, _
                                                ByVal Receptor As String, _
                                                ByVal CarpetaJudicialCodigo As String, _
                                                ByVal TareasNotasFrom As String, _
                                                ByVal TareasNotasTo As String, _
                                                ByVal Correo As String, _
                                                ByVal TareasNotasSubject As String, _
                                                ByVal ConCopia As String, _
                                                ByVal UserId As Long) As Boolean
        Dim Usuarios As New Usuarios
        Dim Tareas As New Tareas

        Dim TareasNotasTime As Date ' Etiqueta : Fecha y Hora - Control : txtTareasNotasTime - Variable : TareasNotasTime

        Dim definition As New MailDefinition
        Dim smtpcliente As New SmtpClient("mail.zrismart.cl")
        definition.BodyFileName = HttpContext.Current.Server.MapPath("~/PlantillaMensajes.htm")
        definition.IsBodyHtml = True
        definition.Subject = TareasNotasSubject
        definition.From = "sgi@zrismart.cl"
        definition.CC = Secretaria & ", " & Supervisor & ", " & Procurador
        Dim now As DateTime = DateTime.Now
        TareasNotasTime = now
        Dim replacements As IDictionary = New ListDictionary
        replacements.Add("<%Nombre%>", Usuarios.LeerUsuariosDescriptionByName(Correo))
        replacements.Add("<%Aviso%>", definition.Subject)
        replacements.Add("<%Desde%>", TareasNotasFrom)
        replacements.Add("<%Cuerpo%>", Tareas.ListarDatosDelDeudorPorTareasId(TareasId, CarpetaJudicialCodigo) & "<br /><p>" & Comentarios & "</p>")
        replacements.Add("<%Fecha%>", now.ToShortDateString)
        replacements.Add("<%Hora%>", now.ToShortTimeString)
        'Using message As MailMessage = definition.CreateMailMessage(Correo, replacements, New Control)
        'smtpcliente.Send(message)
        'End Using
        EnviarMensajeDemanda = True
    End Function

End Class
