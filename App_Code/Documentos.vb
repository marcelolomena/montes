'------------------------------------------------------------
' Código generado por ZRISMART SF el 16-11-2010 12:13:53
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Documentos
    Public Function LeerDocumentos(ByVal DocumentosId As Long, ByRef DocumentosCodigo As String, ByRef DocumentosNombre As String, ByRef DocumentosPath As String, ByRef DocumentosMenu As String, ByRef DocumentosOptionsMenuId As Long, ByRef DocumentosGroupName As String, ByRef DocumentosGroupSecuencia As Long, ByRef DocumentosGroupItemNumber As Long, ByRef DocumentosOrigen As String, ByRef DocumentosTipo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select DocumentosCodigo, DocumentosNombre, DocumentosPath, DocumentosMenu, DocumentosOptionsMenuId, DocumentosGroupName, DocumentosGroupSecuencia, DocumentosGroupItemNumber, DocumentosOrigen, DocumentosTipo "
        sSQL = sSQL & "FROM Documentos "
        sSQL = sSQL & "WHERE (Documentos.DocumentosId = " & DocumentosId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                DocumentosCodigo = CStr(dtr("DocumentosCodigo").ToString)
                DocumentosNombre = CStr(dtr("DocumentosNombre").ToString)
                DocumentosPath = CStr(dtr("DocumentosPath").ToString)
                DocumentosMenu = CStr(dtr("DocumentosMenu").ToString)
                If Len(dtr("DocumentosOptionsMenuId").ToString) = 0 Then
                    DocumentosOptionsMenuId = 0
                Else
                    DocumentosOptionsMenuId = CLng(dtr("DocumentosOptionsMenuId").ToString)
                End If
                DocumentosGroupName = CStr(dtr("DocumentosGroupName").ToString)
                If Len(dtr("DocumentosGroupSecuencia").ToString) = 0 Then
                    DocumentosGroupSecuencia = 0
                Else
                    DocumentosGroupSecuencia = CLng(dtr("DocumentosGroupSecuencia").ToString)
                End If
                If Len(dtr("DocumentosGroupItemNumber").ToString) = 0 Then
                    DocumentosGroupItemNumber = 0
                Else
                    DocumentosGroupItemNumber = CLng(dtr("DocumentosGroupItemNumber").ToString)
                End If
                DocumentosOrigen = CStr(dtr("DocumentosOrigen").ToString)
                DocumentosTipo = CStr(dtr("DocumentosTipo").ToString)
            End While
            LeerDocumentos = True
            dtr.Close()
        Catch
            LeerDocumentos = False
        End Try
    End Function
    Public Function LeerDocumentosByName(ByRef DocumentosId As Long, ByVal DocumentosCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select DocumentosId "
        sSQL = sSQL & "FROM Documentos "
        sSQL = sSQL & "WHERE (Documentos.DocumentosCodigo = '" & DocumentosCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                DocumentosId = CLng(dtr("DocumentosId").ToString)
            End While
            LeerDocumentosByName = True
            dtr.Close()
        Catch
            LeerDocumentosByName = False
        End Try
    End Function
    Public Function DocumentosUpdate(ByVal DocumentosId As Long, ByRef DocumentosCodigo As String, ByRef DocumentosNombre As String, ByRef DocumentosPath As String, ByRef DocumentosMenu As String, ByRef DocumentosOptionsMenuId As Long, ByRef DocumentosGroupName As String, ByRef DocumentosGroupSecuencia As Long, ByRef DocumentosGroupItemNumber As Long, ByRef DocumentosOrigen As String, ByRef DocumentosTipo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Documentos SET "
        strUpdate = strUpdate & "Documentos.DocumentosCodigo = '" & DocumentosCodigo & "', "
        strUpdate = strUpdate & "Documentos.DocumentosNombre = '" & DocumentosNombre & "', "
        strUpdate = strUpdate & "Documentos.DocumentosPath = '" & DocumentosPath & "', "
        strUpdate = strUpdate & "Documentos.DocumentosMenu = '" & DocumentosMenu & "', "
        strUpdate = strUpdate & "Documentos.DocumentosOptionsMenuId = " & DocumentosOptionsMenuId & ", "
        strUpdate = strUpdate & "Documentos.DocumentosGroupName = '" & DocumentosGroupName & "', "
        strUpdate = strUpdate & "Documentos.DocumentosGroupSecuencia = " & DocumentosGroupSecuencia & ", "
        strUpdate = strUpdate & "Documentos.DocumentosGroupItemNumber = " & DocumentosGroupItemNumber & ", "
        strUpdate = strUpdate & "Documentos.DocumentosOrigen = '" & DocumentosOrigen & "', "
        strUpdate = strUpdate & "Documentos.DocumentosTipo = '" & DocumentosTipo & "', "
        strUpdate = strUpdate & "Documentos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Documentos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Documentos.DocumentosId = " & DocumentosId
        Try
            DocumentosUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & DocumentosCodigo, DocumentosId, "Documentos", "")
        Catch
            DocumentosUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & DocumentosCodigo, DocumentosId, "Documentos", "")
        End Try
    End Function
    Public Function DocumentosInsert(ByRef DocumentosId As Long, ByRef DocumentosCodigo As String, ByRef DocumentosNombre As String, ByRef DocumentosPath As String, ByRef DocumentosMenu As String, ByRef DocumentosOptionsMenuId As Long, ByRef DocumentosGroupName As String, ByRef DocumentosGroupSecuencia As Long, ByRef DocumentosGroupItemNumber As Long, ByRef DocumentosOrigen As String, ByRef DocumentosTipo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Documentos As New Documentos
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = DocumentosCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("DocumentosId", "DocumentosCodigo", "Documentos", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("DocumentosId", "DocumentosCodigo", "Documentos", MasterName, CLng(UserId), MasterId)
            End If
            DocumentosInsert = Documentos.DocumentosUpdate(MasterId, CStr(DocumentosCodigo), CStr(DocumentosNombre), CStr(DocumentosPath), CStr(DocumentosMenu), CLng(DocumentosOptionsMenuId), CStr(DocumentosGroupName), CLng(DocumentosGroupSecuencia), CLng(DocumentosGroupItemNumber), CStr(DocumentosOrigen), CStr(DocumentosTipo), UserId)
        Catch
            DocumentosInsert = 0
        End Try
    End Function
End Class
