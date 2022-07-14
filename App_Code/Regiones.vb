'------------------------------------------------------------
' Código generado por ZRISMART SF el 24-08-2011 19:05:55
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Regiones
    Public Function LeerRegiones(ByVal RegionesId As Long, ByRef RegionesCodigo As String, ByRef RegionesName As String, ByRef RegionesDescription As String, ByRef RegionesIntendente As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select RegionesCodigo, RegionesName, RegionesDescription, RegionesIntendente "
        sSQL = sSQL & "FROM (Regiones) "
        sSQL = sSQL & "WHERE (Regiones.RegionesId = " & RegionesId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                RegionesCodigo = CStr(dtr("RegionesCodigo").ToString)
                RegionesName = CStr(dtr("RegionesName").ToString)
                RegionesDescription = CStr(dtr("RegionesDescription").ToString)
                RegionesIntendente = CStr(dtr("RegionesIntendente").ToString)
            End While
            LeerRegiones = True
            dtr.Close()
        Catch
            LeerRegiones = False
        End Try
    End Function
    Public Function LeerRegionesByName(ByRef RegionesId As Long, ByVal RegionesCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select RegionesId "
        sSQL = sSQL & "FROM (Regiones) "
        sSQL = sSQL & "WHERE (Regiones.RegionesCodigo = '" & RegionesCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                RegionesId = CLng(dtr("RegionesId").ToString)
            End While
            LeerRegionesByName = True
            dtr.Close()
        Catch
            LeerRegionesByName = False
        End Try
    End Function
    Public Function LeerRegionesDescriptionByName(ByVal RegionesCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        LeerRegionesDescriptionByName = " "
        sSQL = "Select RegionesName "
        sSQL = sSQL & "FROM (Regiones) "
        sSQL = sSQL & "WHERE (Regiones.RegionesCodigo = '" & RegionesCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerRegionesDescriptionByName = CStr(dtr("RegionesName").ToString)
            End While
            dtr.Close()
        Catch
            LeerRegionesDescriptionByName = " "
        End Try
    End Function
    Public Function RegionesUpdate(ByVal RegionesId As Long, ByRef RegionesCodigo As String, ByRef RegionesName As String, ByRef RegionesDescription As String, ByRef RegionesIntendente As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Regiones SET "
        strUpdate = strUpdate & "Regiones.RegionesCodigo = '" & RegionesCodigo & "', "
        strUpdate = strUpdate & "Regiones.RegionesName = '" & RegionesName & "', "
        strUpdate = strUpdate & "Regiones.RegionesDescription = '" & RegionesDescription & "', "
        strUpdate = strUpdate & "Regiones.RegionesIntendente = '" & RegionesIntendente & "', "
        strUpdate = strUpdate & "Regiones.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Regiones.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Regiones.RegionesId = " & RegionesId
        Try
            RegionesUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & RegionesCodigo, RegionesId, "Regiones", "")
        Catch
            RegionesUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & RegionesCodigo, RegionesId, "Regiones", "")
        End Try
    End Function
    Public Function RegionesInsert(ByRef RegionesId As Long, ByRef RegionesCodigo As String, ByRef RegionesName As String, ByRef RegionesDescription As String, ByRef RegionesIntendente As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Regiones As New Regiones
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = RegionesCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("RegionesId", "RegionesCodigo", "Regiones", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("RegionesId", "RegionesCodigo", "Regiones", MasterName, CLng(UserId), MasterId)
            End If
            RegionesInsert = Regiones.RegionesUpdate(MasterId, CStr(RegionesCodigo), CStr(RegionesName), CStr(RegionesDescription), CStr(RegionesIntendente), UserId)
        Catch
            RegionesInsert = 0
        End Try
    End Function
    Public Function LeerTotalRegionesPorDocumentos(ByVal RegionesCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        ' Verificamos si el área esta referenciada en algún documento
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Regiones INNER JOIN Provincias ON Regiones.RegionesCodigo = Provincias.RegionesCodigo "
        sSQL = sSQL & "WHERE (((Regiones.RegionesCodigo)='" & RegionesCodigo & "'))"
        LeerTotalRegionesPorDocumentos = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalRegionesPorDocumentos = LeerTotalRegionesPorDocumentos + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalRegionesPorDocumentos = 0
        End Try
    End Function
    Public Function RegionesDelete(ByVal RegionesId As Long, ByVal RegionesCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Regiones As New Regiones

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Regiones.LeerTotalRegionesPorDocumentos(RegionesCodigo)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " Provincias asociados a la Región " & RegionesCodigo & vbCrLf
            Mensaje = Mensaje & "Cambie la región a las provincias, antes de eliminarla de la lista"
            RegionesDelete = False
        Else
            Try
                ' Borra registro de la tabla de Comunas
                '-------------------------------------
                strUpdate = "DELETE FROM Regiones WHERE RegionesId = " & RegionesId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina la Región: " & RegionesCodigo, RegionesId, "Regiones", "")
                RegionesDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la Región: " & RegionesCodigo, RegionesId, "Regiones", "")
                RegionesDelete = False
            End Try
        End If
    End Function

End Class
