'------------------------------------------------------------
' Código generado por ZRISMART SF el 24-08-2011 19:07:13
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Provincias
    Public Function LeerProvincias(ByVal ProvinciasId As Long, ByRef ProvinciasCodigo As String, ByRef ProvinciasName As String, ByRef ProvinciasDescription As String, ByRef ProvinciasGobernador As String, ByRef RegionesCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProvinciasCodigo, ProvinciasName, ProvinciasDescription, ProvinciasGobernador, RegionesCodigo "
        sSQL = sSQL & "FROM Provincias "
        sSQL = sSQL & "WHERE (Provincias.ProvinciasId = " & ProvinciasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProvinciasCodigo = CStr(dtr("ProvinciasCodigo").ToString)
                ProvinciasName = CStr(dtr("ProvinciasName").ToString)
                ProvinciasDescription = CStr(dtr("ProvinciasDescription").ToString)
                ProvinciasGobernador = CStr(dtr("ProvinciasGobernador").ToString)
                RegionesCodigo = CStr(dtr("RegionesCodigo").ToString)
            End While
            LeerProvincias = True
            dtr.Close()
        Catch
            LeerProvincias = False
        End Try
    End Function
    Public Function LeerProvinciasByName(ByRef ProvinciasId As Long, ByVal ProvinciasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProvinciasId "
        sSQL = sSQL & "FROM Provincias "
        sSQL = sSQL & "WHERE (Provincias.ProvinciasCodigo = '" & ProvinciasCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProvinciasId = CLng(dtr("ProvinciasId").ToString)
            End While
            LeerProvinciasByName = True
            dtr.Close()
        Catch
            LeerProvinciasByName = False
        End Try
    End Function
    Public Function LeerProvinciasDescriptionByName(ByVal ProvinciasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        LeerProvinciasDescriptionByName = " "
        sSQL = "Select ProvinciasName "
        sSQL = sSQL & "FROM Provincias "
        sSQL = sSQL & "WHERE (Provincias.ProvinciasCodigo = '" & ProvinciasCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerProvinciasDescriptionByName = CStr(dtr("ProvinciasName").ToString)
            End While
            dtr.Close()
        Catch
            LeerProvinciasDescriptionByName = " "
        End Try
    End Function
    Public Function ProvinciasUpdate(ByVal ProvinciasId As Long, ByRef ProvinciasCodigo As String, ByRef ProvinciasName As String, ByRef ProvinciasDescription As String, ByRef ProvinciasGobernador As String, ByRef RegionesCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Provincias SET "
        strUpdate = strUpdate & "Provincias.ProvinciasCodigo = '" & ProvinciasCodigo & "', "
        strUpdate = strUpdate & "Provincias.ProvinciasName = '" & ProvinciasName & "', "
        strUpdate = strUpdate & "Provincias.ProvinciasDescription = '" & ProvinciasDescription & "', "
        strUpdate = strUpdate & "Provincias.ProvinciasGobernador = '" & ProvinciasGobernador & "', "
        strUpdate = strUpdate & "Provincias.RegionesCodigo = '" & RegionesCodigo & "', "
        strUpdate = strUpdate & "Provincias.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Provincias.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Provincias.ProvinciasId = " & ProvinciasId
        Try
            ProvinciasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ProvinciasCodigo, ProvinciasId, "Provincias", "")
        Catch
            ProvinciasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ProvinciasCodigo, ProvinciasId, "Provincias", "")
        End Try
    End Function
    Public Function ProvinciasInsert(ByRef ProvinciasId As Long, ByRef ProvinciasCodigo As String, ByRef ProvinciasName As String, ByRef ProvinciasDescription As String, ByRef ProvinciasGobernador As String, ByRef RegionesCodigo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Provincias As New Provincias
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = ProvinciasCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("ProvinciasId", "ProvinciasCodigo", "Provincias", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("ProvinciasId", "ProvinciasCodigo", "Provincias", MasterName, CLng(UserId), MasterId)
            End If
            ProvinciasInsert = Provincias.ProvinciasUpdate(MasterId, CStr(ProvinciasCodigo), CStr(ProvinciasName), CStr(ProvinciasDescription), CStr(ProvinciasGobernador), CStr(RegionesCodigo), UserId)
        Catch
            ProvinciasInsert = 0
        End Try
    End Function
    Public Function LeerTotalProvinciasPorDocumentos(ByVal ProvinciasCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        ' Verificamos si el área esta referenciada en algún documento
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Provincias INNER JOIN Comunas ON Provincias.ProvinciasCodigo = Comunas.ProvinciasCodigo "
        sSQL = sSQL & "WHERE (((Provincias.ProvinciasCodigo)='" & ProvinciasCodigo & "'))"
        LeerTotalProvinciasPorDocumentos = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalProvinciasPorDocumentos = LeerTotalProvinciasPorDocumentos + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalProvinciasPorDocumentos = 0
        End Try
    End Function
    Public Function ProvinciasDelete(ByVal ProvinciasId As Long, ByVal ProvinciasCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Provincias As New Provincias

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Provincias.LeerTotalProvinciasPorDocumentos(ProvinciasCodigo)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " Comunas asociados a la Provincia " & ProvinciasCodigo & vbCrLf
            Mensaje = Mensaje & "Cambie la provincia a las comunas, antes de eliminarla de la lista"
            ProvinciasDelete = False
        Else
            Try
                ' Borra registro de la tabla de Comunas
                '-------------------------------------
                strUpdate = "DELETE FROM Provincias WHERE ProvinciasId = " & ProvinciasId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina la Provincia: " & ProvinciasCodigo, ProvinciasId, "Provincias", "")
                ProvinciasDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la Provincia: " & ProvinciasCodigo, ProvinciasId, "Provincias", "")
                ProvinciasDelete = False
            End Try
        End If
    End Function
End Class
