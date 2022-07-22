'------------------------------------------------------------
' Código generado por ZRISMART SF el 26-01-2011 9:12:00
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class TipoDoc
    Public Function LeerTipoDoc(ByVal TipoDocId As Long, ByRef TipoDocName As String, ByRef TipoDocDescription As String, ByRef TipoDocSecuencia As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TipoDocName, TipoDocDescription, TipoDocSecuencia "
        sSQL = sSQL & "FROM TipoDoc "
        sSQL = sSQL & "WHERE (TipoDoc.TipoDocId = " & TipoDocId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TipoDocName = CStr(dtr("TipoDocName").ToString)
                TipoDocDescription = CStr(dtr("TipoDocDescription").ToString)
                If Len(dtr("TipoDocSecuencia").ToString) = 0 Then
                    TipoDocSecuencia = 0
                Else
                    TipoDocSecuencia = CLng(dtr("TipoDocSecuencia").ToString)
                End If
            End While
            LeerTipoDoc = True
            dtr.Close()
        Catch
            LeerTipoDoc = False
        End Try
    End Function
    Public Function LeerTipoDocByName(ByRef TipoDocId As Long, ByVal TipoDocName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TipoDocId "
        sSQL = sSQL & "FROM TipoDoc "
        sSQL = sSQL & "WHERE (TipoDoc.TipoDocName = '" & TipoDocName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TipoDocId = CLng(dtr("TipoDocId").ToString)
            End While
            LeerTipoDocByName = True
            dtr.Close()
        Catch
            LeerTipoDocByName = False
        End Try
    End Function
    Public Function LeerTipoDocDescriptionByName(ByRef TipoDocName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        LeerTipoDocDescriptionByName = ""
        sSQL = "Select TipoDocDescription "
        sSQL = sSQL & "FROM TipoDoc "
        sSQL = sSQL & "WHERE (TipoDoc.TipoDocName = '" & TipoDocName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTipoDocDescriptionByName = CStr(dtr("TipoDocDescription").ToString)
            End While
            dtr.Close()
        Catch
            LeerTipoDocDescriptionByName = " "
        End Try
    End Function
    Public Function LeerTipoDocNameById(ByRef TipoDocId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        LeerTipoDocNameById = ""
        sSQL = "Select TipoDocName "
        sSQL = sSQL & "FROM TipoDoc "
        sSQL = sSQL & "WHERE (TipoDoc.TipoDocId = " & TipoDocId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTipoDocNameById = CStr(dtr("TipoDocName").ToString)
            End While
            dtr.Close()
        Catch
            LeerTipoDocNameById = " "
        End Try
    End Function
    Public Function TipoDocUpdate(ByVal TipoDocId As Long, ByRef TipoDocName As String, ByRef TipoDocDescription As String, ByRef TipoDocSecuencia As Long, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE TipoDoc SET "
        strUpdate = strUpdate & "TipoDoc.TipoDocName = '" & TipoDocName & "', "
        strUpdate = strUpdate & "TipoDoc.TipoDocDescription = '" & TipoDocDescription & "', "
        strUpdate = strUpdate & "TipoDoc.TipoDocSecuencia = " & TipoDocSecuencia & ", "
        strUpdate = strUpdate & "TipoDoc.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "TipoDoc.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE TipoDoc.TipoDocId = " & TipoDocId
        Try
            TipoDocUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & TipoDocName, TipoDocId, "TipoDoc", "")
        Catch
            TipoDocUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TipoDocName, TipoDocId, "TipoDoc", "")
        End Try
    End Function
    Public Function TipoDocInsert(ByRef TipoDocId As Long, ByRef TipoDocName As String, ByRef TipoDocDescription As String, ByRef TipoDocSecuencia As Long, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim TipoDoc As New TipoDoc
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = TipoDocName
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("TipoDocId", "TipoDocName", "TipoDoc", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("TipoDocId", "TipoDocName", "TipoDoc", MasterName, CLng(UserId), MasterId)
            End If
            TipoDocInsert = TipoDoc.TipoDocUpdate(MasterId, CStr(TipoDocName), CStr(TipoDocDescription), CLng(TipoDocSecuencia), UserId)
        Catch
            TipoDocInsert = 0
        End Try
    End Function
    Public Function LeerTotalTipoDocPorDocumentos(ByVal TipoDocName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM TipoDoc INNER JOIN DocumentosSGI ON TipoDoc.TipoDocName = DocumentosSGI.DocumentosSGITipo "
        sSQL = sSQL & "WHERE (((TipoDoc.TipoDocName)='" & TipoDocName & "'))"
        LeerTotalTipoDocPorDocumentos = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalTipoDocPorDocumentos = LeerTotalTipoDocPorDocumentos + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalTipoDocPorDocumentos = 0
        End Try
    End Function
    Public Function TipoDocDelete(ByVal TipoDocId As Long, ByVal TipoDocName As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim TipoDoc As New TipoDoc

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = TipoDoc.LeerTotalTipoDocPorDocumentos(TipoDocName)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " documentos asociados al Tipo " & TipoDocName & vbCrLf
            Mensaje = Mensaje & "Cambia el Tipo a los documentos, antes de eliminarlo de la lista"
            TipoDocDelete = False
        Else
            Try
                ' Borra registro de la tabla de Roles
                '-------------------------------------
                strUpdate = "DELETE FROM TipoDoc WHERE TipoDocId = " & TipoDocId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Tipo: " & TipoDocName, TipoDocId, "TipoDoc", "")
                TipoDocDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Tipo: " & TipoDocName, TipoDocId, "TipoDoc", "")
                TipoDocDelete = False
            End Try
        End If
    End Function

End Class
