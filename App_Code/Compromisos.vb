'------------------------------------------------------------
' Código generado por ZRISMART SF el 06-04-2011 6:04:20
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Compromisos
    Public Function LeerCompromisos(ByVal CompromisosId As Long, ByRef CompromisosCodigo As String, ByRef CompromisosName As String, ByRef CompromisosDescription As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CompromisosCodigo, CompromisosName, CompromisosDescription "
        sSQL = sSQL & "FROM (Compromisos) "
        sSQL = sSQL & "WHERE (Compromisos.CompromisosId = " & CompromisosId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CompromisosCodigo = CStr(dtr("CompromisosCodigo").ToString)
                CompromisosName = CStr(dtr("CompromisosName").ToString)
                CompromisosDescription = CStr(dtr("CompromisosDescription").ToString)
            End While
            LeerCompromisos = True
            dtr.Close()
        Catch
            LeerCompromisos = False
        End Try
    End Function
    Public Function LeerCompromisosByName(ByRef CompromisosId As Long, ByVal CompromisosCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CompromisosId "
        sSQL = sSQL & "FROM (Compromisos) "
        sSQL = sSQL & "WHERE (Compromisos.CompromisosCodigo = '" & CompromisosCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CompromisosId = CLng(dtr("CompromisosId").ToString)
            End While
            LeerCompromisosByName = True
            dtr.Close()
        Catch
            LeerCompromisosByName = False
        End Try
    End Function
    Public Function CompromisosUpdate(ByVal CompromisosId As Long, ByRef CompromisosCodigo As String, ByRef CompromisosName As String, ByRef CompromisosDescription As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Compromisos SET "
        strUpdate = strUpdate & "Compromisos.CompromisosCodigo = '" & CompromisosCodigo & "', "
        strUpdate = strUpdate & "Compromisos.CompromisosName = '" & CompromisosName & "', "
        strUpdate = strUpdate & "Compromisos.CompromisosDescription = '" & CompromisosDescription & "', "
        strUpdate = strUpdate & "Compromisos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Compromisos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Compromisos.CompromisosId = " & CompromisosId
        Try
            CompromisosUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & CompromisosCodigo, CompromisosId, "Compromisos", "")
        Catch
            CompromisosUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & CompromisosCodigo, CompromisosId, "Compromisos", "")
        End Try
    End Function
    Public Function CompromisosInsert(ByRef CompromisosId As Long, ByRef CompromisosCodigo As String, ByRef CompromisosName As String, ByRef CompromisosDescription As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Compromisos As New Compromisos
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = CompromisosCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("CompromisosId", "CompromisosCodigo", "Compromisos", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("CompromisosId", "CompromisosCodigo", "Compromisos", MasterName, CLng(UserId), MasterId)
            End If
            CompromisosInsert = Compromisos.CompromisosUpdate(MasterId, CStr(CompromisosCodigo), CStr(CompromisosName), CStr(CompromisosDescription), UserId)
        Catch
            CompromisosInsert = 0
        End Try
    End Function
    Public Function LeerCompromisosDescriptionByName(ByVal CompromisosCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CompromisosName "
        sSQL = sSQL & "FROM (Compromisos) "
        sSQL = sSQL & "WHERE (Compromisos.CompromisosCodigo = '" & CompromisosCodigo & "') "
        LeerCompromisosDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerCompromisosDescriptionByName = CStr(dtr("CompromisosName").ToString)
            End While
            dtr.Close()
        Catch
            LeerCompromisosDescriptionByName = "Código de compromiso es incorrecto"
        End Try
    End Function
    Public Function LeerTotalCompromisosPorTablasRelacionadas(ByVal CompromisosCodigo As String, ByVal CompromisosId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en un Objetivo
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Compromisos INNER JOIN Objetivos ON Compromisos.CompromisosCodigo = Objetivos.CompromisosCodigo "
        sSQL = sSQL & "WHERE (((Compromisos.CompromisosCodigo)='" & CompromisosCodigo & "'))"
        LeerTotalCompromisosPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalCompromisosPorTablasRelacionadas = LeerTotalCompromisosPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalCompromisosPorTablasRelacionadas = 0
        End Try

    End Function
    Public Function CompromisosDelete(ByVal CompromisosId As Long, ByVal CompromisosCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Compromisos As New Compromisos

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Compromisos.LeerTotalCompromisosPorTablasRelacionadas(CompromisosCodigo, CompromisosId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados al Compromiso " & CompromisosCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie o elimine el Compromiso de sus objetivos asociados, antes de eliminarlo de la lista"
            CompromisosDelete = False
        Else
            Try
                ' Borra registro de la tabla de Gerencias
                '-------------------------------------
                strUpdate = "DELETE FROM Compromisos WHERE CompromisosId = " & CompromisosId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Compromiso: " & CompromisosCodigo, CompromisosId, "Compromisos", "")
                CompromisosDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Compromiso: " & CompromisosCodigo, CompromisosId, "Compromisos", "")
                CompromisosDelete = False
            End Try
        End If
    End Function
End Class
