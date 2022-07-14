'------------------------------------------------------------
' Código generado por ZRISMART SF el 06-04-2011 9:18:28
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Objetivos
    Public Function LeerObjetivos(ByVal ObjetivosId As Long, ByRef ObjetivosCodigo As String, ByRef ObjetivosName As String, ByRef ObjetivosDescription As String, ByRef CompromisosCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ObjetivosCodigo, ObjetivosName, ObjetivosDescription, CompromisosCodigo "
        sSQL = sSQL & "FROM (Objetivos) "
        sSQL = sSQL & "WHERE (Objetivos.ObjetivosId = " & ObjetivosId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ObjetivosCodigo = CStr(dtr("ObjetivosCodigo").ToString)
                ObjetivosName = CStr(dtr("ObjetivosName").ToString)
                ObjetivosDescription = CStr(dtr("ObjetivosDescription").ToString)
                CompromisosCodigo = CStr(dtr("CompromisosCodigo").ToString)
            End While
            LeerObjetivos = True
            dtr.Close()
        Catch
            LeerObjetivos = False
        End Try
    End Function
    Public Function LeerObjetivosByName(ByRef ObjetivosId As Long, ByVal ObjetivosCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ObjetivosId "
        sSQL = sSQL & "FROM (Objetivos) "
        sSQL = sSQL & "WHERE (Objetivos.ObjetivosCodigo = '" & ObjetivosCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ObjetivosId = CLng(dtr("ObjetivosId").ToString)
            End While
            LeerObjetivosByName = True
            dtr.Close()
        Catch
            LeerObjetivosByName = False
        End Try
    End Function
    Public Function ObjetivosUpdate(ByVal ObjetivosId As Long, ByRef ObjetivosCodigo As String, ByRef ObjetivosName As String, ByRef ObjetivosDescription As String, ByRef CompromisosCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Objetivos SET "
        strUpdate = strUpdate & "Objetivos.ObjetivosCodigo = '" & ObjetivosCodigo & "', "
        strUpdate = strUpdate & "Objetivos.ObjetivosName = '" & ObjetivosName & "', "
        strUpdate = strUpdate & "Objetivos.ObjetivosDescription = '" & ObjetivosDescription & "', "
        strUpdate = strUpdate & "Objetivos.CompromisosCodigo = '" & CompromisosCodigo & "', "
        strUpdate = strUpdate & "Objetivos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Objetivos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Objetivos.ObjetivosId = " & ObjetivosId
        Try
            ObjetivosUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ObjetivosCodigo, ObjetivosId, "Objetivos", "")
        Catch
            ObjetivosUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ObjetivosCodigo, ObjetivosId, "Objetivos", "")
        End Try
    End Function
    Public Function ObjetivosInsert(ByRef ObjetivosId As Long, ByRef ObjetivosCodigo As String, ByRef ObjetivosName As String, ByRef ObjetivosDescription As String, ByRef CompromisosCodigo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Objetivos As New Objetivos
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = ObjetivosCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("ObjetivosId", "ObjetivosCodigo", "Objetivos", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("ObjetivosId", "ObjetivosCodigo", "Objetivos", MasterName, CLng(UserId), MasterId)
            End If
            ObjetivosInsert = Objetivos.ObjetivosUpdate(MasterId, CStr(ObjetivosCodigo), CStr(ObjetivosName), CStr(ObjetivosDescription), CStr(CompromisosCodigo), UserId)
        Catch
            ObjetivosInsert = 0
        End Try
    End Function
    Public Function LeerObjetivosDescriptionByName(ByVal ObjetivosCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ObjetivosName "
        sSQL = sSQL & "FROM (Objetivos) "
        sSQL = sSQL & "WHERE (Objetivos.ObjetivosCodigo = '" & ObjetivosCodigo & "') "
        LeerObjetivosDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerObjetivosDescriptionByName = CStr(dtr("ObjetivosName").ToString)
            End While
            dtr.Close()
        Catch
            LeerObjetivosDescriptionByName = "Código de objetivo es incorrecto"
        End Try
    End Function
    Public Function LeerTotalObjetivosPorTablasRelacionadas(ByVal ObjetivosCodigo As String, ByVal ObjetivosId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en una Meta
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Objetivos INNER JOIN Metas ON Objetivos.ObjetivosCodigo = Metas.ObjetivosCodigo "
        sSQL = sSQL & "WHERE (((Objetivos.ObjetivosCodigo)='" & ObjetivosCodigo & "'))"
        LeerTotalObjetivosPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalObjetivosPorTablasRelacionadas = LeerTotalObjetivosPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalObjetivosPorTablasRelacionadas = 0
        End Try

    End Function
    Public Function ObjetivosDelete(ByVal ObjetivosId As Long, ByVal ObjetivosCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Objetivos As New Objetivos

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Objetivos.LeerTotalObjetivosPorTablasRelacionadas(ObjetivosCodigo, ObjetivosId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados al Objetivo " & ObjetivosCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie o elimine el Objetivos de sus metas asociados, antes de eliminarlo de la lista"
            ObjetivosDelete = False
        Else
            Try
                ' Borra registro de la tabla de Gerencias
                '-------------------------------------
                strUpdate = "DELETE FROM Objetivos WHERE ObjetivosId = " & ObjetivosId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Objetivo: " & ObjetivosCodigo, ObjetivosId, "Objetivos", "")
                ObjetivosDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Objetivo: " & ObjetivosCodigo, ObjetivosId, "Objetivos", "")
                ObjetivosDelete = False
            End Try
        End If
    End Function
End Class
