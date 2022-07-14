'------------------------------------------------------------
' Código generado por ZRISMART SF el 06-04-2011 11:17:51
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Metas
    Public Function LeerMetas(ByVal MetasId As Long, ByRef MetasCodigo As String, ByRef MetasName As String, ByRef MetasDescription As String, ByRef ObjetivosCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select MetasCodigo, MetasName, MetasDescription, ObjetivosCodigo "
        sSQL = sSQL & "FROM (Metas) "
        sSQL = sSQL & "WHERE (Metas.MetasId = " & MetasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                MetasCodigo = CStr(dtr("MetasCodigo").ToString)
                MetasName = CStr(dtr("MetasName").ToString)
                MetasDescription = CStr(dtr("MetasDescription").ToString)
                ObjetivosCodigo = CStr(dtr("ObjetivosCodigo").ToString)
            End While
            LeerMetas = True
            dtr.Close()
        Catch
            LeerMetas = False
        End Try
    End Function
    Public Function LeerMetasByName(ByRef MetasId As Long, ByVal MetasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select MetasId "
        sSQL = sSQL & "FROM (Metas) "
        sSQL = sSQL & "WHERE (Metas.MetasCodigo = '" & MetasCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                MetasId = CLng(dtr("MetasId").ToString)
            End While
            LeerMetasByName = True
            dtr.Close()
        Catch
            LeerMetasByName = False
        End Try
    End Function
    Public Function MetasUpdate(ByVal MetasId As Long, ByRef MetasCodigo As String, ByRef MetasName As String, ByRef MetasDescription As String, ByRef ObjetivosCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Metas SET "
        strUpdate = strUpdate & "Metas.MetasCodigo = '" & MetasCodigo & "', "
        strUpdate = strUpdate & "Metas.MetasName = '" & MetasName & "', "
        strUpdate = strUpdate & "Metas.MetasDescription = '" & MetasDescription & "', "
        strUpdate = strUpdate & "Metas.ObjetivosCodigo = '" & ObjetivosCodigo & "', "
        strUpdate = strUpdate & "Metas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Metas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Metas.MetasId = " & MetasId
        Try
            MetasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & MetasCodigo, MetasId, "Metas", "")
        Catch
            MetasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & MetasCodigo, MetasId, "Metas", "")
        End Try
    End Function
    Public Function MetasInsert(ByRef MetasId As Long, ByRef MetasCodigo As String, ByRef MetasName As String, ByRef MetasDescription As String, ByRef ObjetivosCodigo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Metas As New Metas
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = MetasCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("MetasId", "MetasCodigo", "Metas", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("MetasId", "MetasCodigo", "Metas", MasterName, CLng(UserId), MasterId)
            End If
            MetasInsert = Metas.MetasUpdate(MasterId, CStr(MetasCodigo), CStr(MetasName), CStr(MetasDescription), CStr(ObjetivosCodigo), UserId)
        Catch
            MetasInsert = 0
        End Try
    End Function
    Public Function LeerMetasDescriptionByName(ByVal MetasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select MetasName "
        sSQL = sSQL & "FROM (Metas) "
        sSQL = sSQL & "WHERE (Metas.MetasCodigo = '" & MetasCodigo & "') "
        LeerMetasDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerMetasDescriptionByName = CStr(dtr("MetasName").ToString)
            End While
            dtr.Close()
        Catch
            LeerMetasDescriptionByName = ""
        End Try
    End Function
    Public Function LeerTotalMetasTablasRelacionadas(ByVal MetasCodigo As String, ByVal MetasId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en una Meta
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Metas INNER JOIN Acciones ON Metas.MetasCodigo = Acciones.MetasCodigo "
        sSQL = sSQL & "WHERE (((Metas.MetasCodigo)='" & MetasCodigo & "'))"
        LeerTotalMetasTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalMetasTablasRelacionadas = LeerTotalMetasTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalMetasTablasRelacionadas = 0
        End Try

    End Function
    Public Function MetasDelete(ByVal MetasId As Long, ByVal MetasCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Metas As New Metas

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Metas.LeerTotalMetasTablasRelacionadas(MetasCodigo, MetasId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados a la Meta " & MetasCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie o elimine la Meta de sus acciones asociados, antes de eliminarlo de la lista"
            MetasDelete = False
        Else
            Try
                ' Borra registro de la tabla de Metas
                '-------------------------------------
                strUpdate = "DELETE FROM Metas WHERE MetasId = " & MetasId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina la Meta: " & MetasCodigo, MetasId, "Metas", "")
                MetasDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la Meta: " & MetasCodigo, MetasId, "Metas", "")
                MetasDelete = False
            End Try
        End If
    End Function
End Class
