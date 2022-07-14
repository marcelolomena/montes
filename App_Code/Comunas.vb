'------------------------------------------------------------
' Código generado por ZRISMART SF el 24-08-2011 19:08:58
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Comunas
    Public Function LeerComunas(ByVal ComunasId As Long, ByRef ComunasCodigo As String, ByRef ComunasName As String, ByRef ComunasDescription As String, ByRef ComunasAlcalde As String, ByRef ProvinciasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ComunasCodigo, ComunasName, ComunasDescription, ComunasAlcalde, ProvinciasCodigo "
        sSQL = sSQL & "FROM (Comunas) "
        sSQL = sSQL & "WHERE (Comunas.ComunasId = " & ComunasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ComunasCodigo = CStr(dtr("ComunasCodigo").ToString)
                ComunasName = CStr(dtr("ComunasName").ToString)
                ComunasDescription = CStr(dtr("ComunasDescription").ToString)
                ComunasAlcalde = CStr(dtr("ComunasAlcalde").ToString)
                ProvinciasCodigo = CStr(dtr("ProvinciasCodigo").ToString)
            End While
            LeerComunas = True
            dtr.Close()
        Catch
            LeerComunas = False
        End Try
    End Function
    Public Function LeerComunasByName(ByRef ComunasId As Long, ByVal ComunasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ComunasId "
        sSQL = sSQL & "FROM (Comunas) "
        sSQL = sSQL & "WHERE (Comunas.ComunasCodigo = '" & ComunasCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ComunasId = CLng(dtr("ComunasId").ToString)
            End While
            LeerComunasByName = True
            dtr.Close()
        Catch
            LeerComunasByName = False
        End Try
    End Function
    Public Function LeerComunasDescriptionByName(ByVal ComunasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        LeerComunasDescriptionByName = " "
        sSQL = "Select ComunasName "
        sSQL = sSQL & "FROM (Comunas) "
        sSQL = sSQL & "WHERE (Comunas.ComunasCodigo = '" & ComunasCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerComunasDescriptionByName = CStr(dtr("ComunasName").ToString)
            End While
            dtr.Close()
        Catch
            LeerComunasDescriptionByName = " "
        End Try
    End Function
    Public Function ComunasUpdate(ByVal ComunasId As Long, ByRef ComunasCodigo As String, ByRef ComunasName As String, ByRef ComunasDescription As String, ByRef ComunasAlcalde As String, ByRef ProvinciasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Comunas SET "
        strUpdate = strUpdate & "Comunas.ComunasCodigo = '" & ComunasCodigo & "', "
        strUpdate = strUpdate & "Comunas.ComunasName = '" & ComunasName & "', "
        strUpdate = strUpdate & "Comunas.ComunasDescription = '" & ComunasDescription & "', "
        strUpdate = strUpdate & "Comunas.ComunasAlcalde = '" & ComunasAlcalde & "', "
        strUpdate = strUpdate & "Comunas.ProvinciasCodigo = '" & ProvinciasCodigo & "', "
        strUpdate = strUpdate & "Comunas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Comunas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Comunas.ComunasId = " & ComunasId
        Try
            ComunasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ComunasCodigo, ComunasId, "Comunas", "")
        Catch
            ComunasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ComunasCodigo, ComunasId, "Comunas", "")
        End Try
    End Function
    Public Function ComunasInsert(ByRef ComunasId As Long, ByRef ComunasCodigo As String, ByRef ComunasName As String, ByRef ComunasDescription As String, ByRef ComunasAlcalde As String, ByRef ProvinciasCodigo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Comunas As New Comunas
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = ComunasCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("ComunasId", "ComunasCodigo", "Comunas", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("ComunasId", "ComunasCodigo", "Comunas", MasterName, CLng(UserId), MasterId)
            End If
            ComunasInsert = Comunas.ComunasUpdate(MasterId, CStr(ComunasCodigo), CStr(ComunasName), CStr(ComunasDescription), CStr(ComunasAlcalde), CStr(ProvinciasCodigo), UserId)
        Catch
            ComunasInsert = 0
        End Try
    End Function
    Public Function LeerTotalComunasPorDocumentos(ByVal ComunasCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        ' Verificamos si el área esta referenciada en algún documento
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Comunas INNER JOIN StakeholdersDirecciones ON Comunas.ComunasCodigo = StakeholdersDirecciones.ComunasCodigo "
        sSQL = sSQL & "WHERE (((Comunas.ComunasCodigo)='" & ComunasCodigo & "'))"
        LeerTotalComunasPorDocumentos = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalComunasPorDocumentos = LeerTotalComunasPorDocumentos + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalComunasPorDocumentos = 0
        End Try
    End Function
    Public Function ComunasDelete(ByVal ComunasId As Long, ByVal ComunasCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Comunas As New Comunas

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Comunas.LeerTotalComunasPorDocumentos(ComunasCodigo)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " Contactos de Stakeholders asociados a la Comuna " & ComunasCodigo & vbCrLf
            Mensaje = Mensaje & "Cambie la comuna a los contactos, antes de eliminarla de la lista"
            ComunasDelete = False
        Else
            Try
                ' Borra registro de la tabla de Comunas
                '-------------------------------------
                strUpdate = "DELETE FROM Comunas WHERE ComunasId = " & ComunasId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina la Comuna: " & ComunasCodigo, ComunasId, "Comunas", "")
                ComunasDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la Comuna: " & ComunasCodigo, ComunasId, "Comunas", "")
                ComunasDelete = False
            End Try
        End If
    End Function
    Public Function ZonaGeograficaName(ByVal ProgramasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Comunas.ComunasName As Nombre "
        sSQL = sSQL & "FROM ProgramasComunas INNER JOIN Comunas ON ProgramasComunas.ComunasId = Comunas.ComunasId "
        sSQL = sSQL & "WHERE (((ProgramasComunas.ProgramasId)=" & ProgramasId & "))"

        ZonaGeograficaName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ZonaGeograficaName = ZonaGeograficaName & " " & CStr(dtr("Nombre").ToString) & ";"
            End While
            If Len(ZonaGeograficaName) > 2 Then
                ZonaGeograficaName = Mid(ZonaGeograficaName, 1, Len(ZonaGeograficaName) - 1)
            End If
            dtr.Close()
        Catch
            ZonaGeograficaName = 0
        End Try
    End Function
End Class
