'------------------------------------------------------------
' Código generado por ZRISMART SF el 02-12-2010 6:09:37
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class NotasDocumentosSGI
    Public Function LeerNotasDocumentosSGI(ByVal NotasDocumentosSGIId As Long, ByRef DocumentosSGICodigo As String, ByRef NotasDocumentosSGISecuencia As Long, ByRef NotasDocumentosSGINombre As String, ByRef NotasDocumentosSGIDescription As String, ByRef NotasDocumentosSGIPath As String, ByRef NotasDocumentosSGIFEmision As Date, ByRef NotasDocumentosSGIResponsable As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select DocumentosSGICodigo, NotasDocumentosSGISecuencia, NotasDocumentosSGINombre, NotasDocumentosSGIDescription, NotasDocumentosSGIPath, NotasDocumentosSGIFEmision, NotasDocumentosSGIResponsable "
        sSQL = sSQL & "FROM (NotasDocumentosSGI) "
        sSQL = sSQL & "WHERE (NotasDocumentosSGI.NotasDocumentosSGIId = " & NotasDocumentosSGIId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                DocumentosSGICodigo = CStr(dtr("DocumentosSGICodigo").ToString)
                If Len(dtr("NotasDocumentosSGISecuencia").ToString) = 0 Then
                    NotasDocumentosSGISecuencia = 0
                Else
                    NotasDocumentosSGISecuencia = CLng(dtr("NotasDocumentosSGISecuencia").ToString)
                End If
                NotasDocumentosSGINombre = CStr(dtr("NotasDocumentosSGINombre").ToString)
                NotasDocumentosSGIDescription = CStr(dtr("NotasDocumentosSGIDescription").ToString)
                NotasDocumentosSGIPath = CStr(dtr("NotasDocumentosSGIPath").ToString)
                If Len(dtr("NotasDocumentosSGIFEmision").ToString) = 0 Then
                    NotasDocumentosSGIFEmision = "01/01/01"
                Else
                    NotasDocumentosSGIFEmision = CDate(dtr("NotasDocumentosSGIFEmision").ToString)
                End If
                NotasDocumentosSGIResponsable = CStr(dtr("NotasDocumentosSGIResponsable").ToString)
            End While
            LeerNotasDocumentosSGI = True
            dtr.Close()
        Catch
            LeerNotasDocumentosSGI = False
        End Try
    End Function
    Public Function NotasDocumentosSGIUpdate(ByVal NotasDocumentosSGIId As Long, ByRef DocumentosSGICodigo As String, ByRef NotasDocumentosSGISecuencia As Long, ByRef NotasDocumentosSGINombre As String, ByRef NotasDocumentosSGIDescription As String, ByRef NotasDocumentosSGIPath As String, ByRef NotasDocumentosSGIFEmision As Date, ByRef NotasDocumentosSGIResponsable As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE NotasDocumentosSGI SET "
        strUpdate = strUpdate & "NotasDocumentosSGI.DocumentosSGICodigo = '" & DocumentosSGICodigo & "', "
        strUpdate = strUpdate & "NotasDocumentosSGI.NotasDocumentosSGISecuencia = " & NotasDocumentosSGISecuencia & ", "
        strUpdate = strUpdate & "NotasDocumentosSGI.NotasDocumentosSGINombre = '" & NotasDocumentosSGINombre & "', "
        strUpdate = strUpdate & "NotasDocumentosSGI.NotasDocumentosSGIDescription = '" & NotasDocumentosSGIDescription & "', "
        strUpdate = strUpdate & "NotasDocumentosSGI.NotasDocumentosSGIPath = '" & NotasDocumentosSGIPath & "', "
        strUpdate = strUpdate & "NotasDocumentosSGI.NotasDocumentosSGIFEmision = '" & AccionesABM.DateTransform(NotasDocumentosSGIFEmision) & "', "
        strUpdate = strUpdate & "NotasDocumentosSGI.NotasDocumentosSGIResponsable = '" & NotasDocumentosSGIResponsable & "', "
        strUpdate = strUpdate & "NotasDocumentosSGI.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "NotasDocumentosSGI.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE NotasDocumentosSGI.NotasDocumentosSGIId = " & NotasDocumentosSGIId
        Try
            NotasDocumentosSGIUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & DocumentosSGICodigo, NotasDocumentosSGIId, "NotasDocumentosSGI", "")
        Catch
            NotasDocumentosSGIUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & DocumentosSGICodigo, NotasDocumentosSGIId, "NotasDocumentosSGI", "")
        End Try
    End Function
    Public Function NotasDocumentosSGIInsert(ByRef NotasDocumentosSGIId As Long, ByRef DocumentosSGICodigo As String, ByRef NotasDocumentosSGISecuencia As Long, ByRef NotasDocumentosSGINombre As String, ByRef NotasDocumentosSGIDescription As String, ByRef NotasDocumentosSGIPath As String, ByRef NotasDocumentosSGIFEmision As Date, ByRef NotasDocumentosSGIResponsable As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim NotasDocumentosSGI As New NotasDocumentosSGI
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = DocumentosSGICodigo
            DetailSecuencia = NotasDocumentosSGISecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("NotasDocumentosSGIId", "DocumentosSGICodigo", "NotasDocumentosSGISecuencia", "NotasDocumentosSGI", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("NotasDocumentosSGIId", "DocumentosSGICodigo", "NotasDocumentosSGISecuencia", "NotasDocumentosSGI", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            NotasDocumentosSGIInsert = NotasDocumentosSGI.NotasDocumentosSGIUpdate(DetailId, CStr(DocumentosSGICodigo), CLng(NotasDocumentosSGISecuencia), CStr(NotasDocumentosSGINombre), CStr(NotasDocumentosSGIDescription), CStr(NotasDocumentosSGIPath), CDate(NotasDocumentosSGIFEmision), CStr(NotasDocumentosSGIResponsable), UserId)
        Catch
            NotasDocumentosSGIInsert = 0
        End Try
    End Function
    Public Function NotasDocumentosSGIDelete(ByVal NotasDocumentosSGIId As Long, ByVal DocumentosSGICodigo As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "DELETE FROM NotasDocumentosSGI WHERE NotasDocumentosSGIId = " & NotasDocumentosSGIId

        Try
            NotasDocumentosSGIDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina una Nota del documento: " & DocumentosSGICodigo, NotasDocumentosSGIId, "NotasDocumentosSGI", "")
        Catch
            NotasDocumentosSGIDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar un código API del documento: " & DocumentosSGICodigo, NotasDocumentosSGIId, "NotasDocumentosSGI", "")
        End Try
    End Function
End Class
