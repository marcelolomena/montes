'------------------------------------------------------------
' Código generado por ZRISMART SF el 18-04-2011 18:21:05
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Cargos
    Public Function LeerCargos(ByVal CargosId As Long, ByRef CargosCodigo As String, ByRef CargosName As String, ByRef CargosDescription As String, ByRef AreasName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CargosCodigo, CargosName, CargosDescription, AreasName "
        sSQL = sSQL & "FROM (Cargos) "
        sSQL = sSQL & "WHERE (Cargos.CargosId = " & CargosId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CargosCodigo = CStr(dtr("CargosCodigo").ToString)
                CargosName = CStr(dtr("CargosName").ToString)
                CargosDescription = CStr(dtr("CargosDescription").ToString)
                AreasName = CStr(dtr("AreasName").ToString)
            End While
            LeerCargos = True
            dtr.Close()
        Catch
            LeerCargos = False
        End Try
    End Function
    Public Function LeerCargosByName(ByRef CargosId As Long, ByVal CargosCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CargosId "
        sSQL = sSQL & "FROM (Cargos) "
        sSQL = sSQL & "WHERE (Cargos.CargosCodigo = '" & CargosCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CargosId = CLng(dtr("CargosId").ToString)
            End While
            LeerCargosByName = True
            dtr.Close()
        Catch
            LeerCargosByName = False
        End Try
    End Function
    Public Function CargosUpdate(ByVal CargosId As Long, ByRef CargosCodigo As String, ByRef CargosName As String, ByRef CargosDescription As String, ByRef AreasName As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Cargos SET "
        strUpdate = strUpdate & "Cargos.CargosCodigo = '" & CargosCodigo & "', "
        strUpdate = strUpdate & "Cargos.CargosName = '" & CargosName & "', "
        strUpdate = strUpdate & "Cargos.CargosDescription = '" & CargosDescription & "', "
        strUpdate = strUpdate & "Cargos.AreasName = '" & AreasName & "', "
        strUpdate = strUpdate & "Cargos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Cargos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Cargos.CargosId = " & CargosId
        Try
            CargosUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & CargosCodigo, CargosId, "Cargos", "")
        Catch
            CargosUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & CargosCodigo, CargosId, "Cargos", "")
        End Try
    End Function
    Public Function CargosInsert(ByRef CargosId As Long, ByRef CargosCodigo As String, ByRef CargosName As String, ByRef CargosDescription As String, ByRef AreasName As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Cargos As New Cargos
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = CargosCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("CargosId", "CargosCodigo", "Cargos", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("CargosId", "CargosCodigo", "Cargos", MasterName, CLng(UserId), MasterId)
            End If
            CargosInsert = Cargos.CargosUpdate(MasterId, CStr(CargosCodigo), CStr(CargosName), CStr(CargosDescription), CStr(AreasName), UserId)
        Catch
            CargosInsert = 0
        End Try
    End Function
    Public Function LeerCargosDescriptionByName(ByVal CargosCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CargosName "
        sSQL = sSQL & "FROM (Cargos) "
        sSQL = sSQL & "WHERE (Cargos.CargosCodigo = '" & CargosCodigo & "') "
        LeerCargosDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerCargosDescriptionByName = CStr(dtr("CargosName").ToString)
            End While
            dtr.Close()
        Catch
            LeerCargosDescriptionByName = ""
        End Try
    End Function
    Public Function UsuariosPorCargo(ByVal CargosCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "SELECT Count(*) as Total "
        sSQL = sSQL & "FROM (Cargos INNER JOIN UsuariosPorCargo ON Cargos.CargosId = UsuariosPorCargo.CargosId) INNER JOIN Usuarios ON UsuariosPorCargo.UsuariosId = Usuarios.UsuariosId "
        sSQL = sSQL & "GROUP BY Cargos.CargosCodigo "
        sSQL = sSQL & "HAVING (((Cargos.CargosCodigo)='" & CargosCodigo & "'))"
        UsuariosPorCargo = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                UsuariosPorCargo = CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            UsuariosPorCargo = 0
        End Try
    End Function
    Public Function LeerUsuariosCodigoPorCargo(ByVal CargosCodigo As String, ByRef TablaUsuariosCodigo() As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Usuarios.UsuariosCodigo "
        sSQL = sSQL & "FROM (Cargos INNER JOIN UsuariosPorCargo ON Cargos.CargosId = UsuariosPorCargo.CargosId) INNER JOIN Usuarios ON UsuariosPorCargo.UsuariosId = Usuarios.UsuariosId "
        sSQL = sSQL & "WHERE (((Cargos.CargosCodigo)='" & CargosCodigo & "'))"

        LeerUsuariosCodigoPorCargo = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TablaUsuariosCodigo(LeerUsuariosCodigoPorCargo) = CStr(dtr("UsuariosCodigo").ToString)
                LeerUsuariosCodigoPorCargo = LeerUsuariosCodigoPorCargo + 1
            End While
            dtr.Close()
        Catch
            LeerUsuariosCodigoPorCargo = 0
        End Try
    End Function
    Public Function LeerTotalCargosPorTablasRelacionadas(ByVal CargosCodigo As String, ByVal CargosId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en actividades
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Cargos INNER JOIN Actividades ON Cargos.CargosCodigo = Actividades.CargosCodigo "
        sSQL = sSQL & "WHERE (((Cargos.CargosCodigo)='" & CargosCodigo & "'))"
        LeerTotalCargosPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalCargosPorTablasRelacionadas = LeerTotalCargosPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalCargosPorTablasRelacionadas = 0
        End Try
        'Verifica si tiene usuarios en el cargo
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Cargos INNER JOIN UsuariosPorCargo ON Cargos.CargosId = UsuariosPorCargo.CargosId "
        sSQL = sSQL & "WHERE (((Cargos.CargosId)=" & CargosId & "))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalCargosPorTablasRelacionadas = LeerTotalCargosPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalCargosPorTablasRelacionadas = LeerTotalCargosPorTablasRelacionadas + 0
        End Try
    End Function
    Public Function CargosDelete(ByVal CargosId As Long, ByVal CargosCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Cargos As New Cargos

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Cargos.LeerTotalCargosPorTablasRelacionadas(CargosCodigo, CargosId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados al Cargo " & CargosCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie el cargo en las actividades y elimine los usuarios del cargo, antes de eliminarlo de la lista"
            CargosDelete = False
        Else
            Try
                ' Borra registro de la tabla de Cargos
                '-------------------------------------
                strUpdate = "DELETE FROM Cargos WHERE CargosId = " & CargosId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Cargo: " & CargosCodigo, CargosId, "Cargos", "")
                CargosDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Cargo: " & CargosCodigo, CargosId, "Cargos", "")
                CargosDelete = False
            End Try
        End If
    End Function
End Class
