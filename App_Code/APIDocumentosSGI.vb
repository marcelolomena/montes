'------------------------------------------------------------
' Código generado por ZRISMART SF el 02-12-2010 6:03:40
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class APIDocumentosSGI
    Public Function LeerAPIDocumentosSGI(ByVal APIDocumentosSGIId As Long, ByRef DocumentosSGICodigo As String, ByRef APIDocumentosSGISecuencia As Long, ByRef MenuOptionsId As Long, ByRef APIDocumentosSGICodigo As String, ByRef APIDocumentosSGIAmbito As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select DocumentosSGICodigo, APIDocumentosSGISecuencia, MenuOptionsId, APIDocumentosSGICodigo, APIDocumentosSGIAmbito "
        sSQL = sSQL & "FROM (APIDocumentosSGI) "
        sSQL = sSQL & "WHERE (APIDocumentosSGI.APIDocumentosSGIId = " & APIDocumentosSGIId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                DocumentosSGICodigo = CStr(dtr("DocumentosSGICodigo").ToString)
                If Len(dtr("APIDocumentosSGISecuencia").ToString) = 0 Then
                    APIDocumentosSGISecuencia = 0
                Else
                    APIDocumentosSGISecuencia = CLng(dtr("APIDocumentosSGISecuencia").ToString)
                End If
                If Len(dtr("MenuOptionsId").ToString) = 0 Then
                    MenuOptionsId = 0
                Else
                    MenuOptionsId = CLng(dtr("MenuOptionsId").ToString)
                End If
                APIDocumentosSGICodigo = CStr(dtr("APIDocumentosSGICodigo").ToString)
                APIDocumentosSGIAmbito = CStr(dtr("APIDocumentosSGIAmbito").ToString)
            End While
            LeerAPIDocumentosSGI = True
            dtr.Close()
        Catch
            LeerAPIDocumentosSGI = False
        End Try
    End Function
    Public Function APIDocumentosSGIUpdate(ByVal APIDocumentosSGIId As Long, ByRef DocumentosSGICodigo As String, ByRef APIDocumentosSGISecuencia As Long, ByRef MenuOptionsId As Long, ByRef APIDocumentosSGICodigo As String, ByRef APIDocumentosSGIAmbito As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Lecturas As New Lecturas
        Dim t As Integer = 0
        Dim GruposName As String = ""
        Dim GruposSecuencia As Long = 0

        t = Lecturas.LeerTipoDocYSecuencia(DocumentosSGICodigo, GruposName, GruposSecuencia)

        strUpdate = "UPDATE APIDocumentosSGI SET "
        strUpdate = strUpdate & "APIDocumentosSGI.DocumentosSGICodigo = '" & DocumentosSGICodigo & "', "
        strUpdate = strUpdate & "APIDocumentosSGI.MenuOptionsId = " & MenuOptionsId & ", "
        strUpdate = strUpdate & "APIDocumentosSGI.APIDocumentosSGICodigo = '" & APIDocumentosSGICodigo & "', "
        strUpdate = strUpdate & "APIDocumentosSGI.APIDocumentosSGIAmbito = '" & APIDocumentosSGIAmbito & "', "
        strUpdate = strUpdate & "APIDocumentosSGI.GruposName = '" & GruposName & "', "
        strUpdate = strUpdate & "APIDocumentosSGI.GruposSecuencia = " & GruposSecuencia & ", "
        strUpdate = strUpdate & "APIDocumentosSGI.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "APIDocumentosSGI.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE APIDocumentosSGI.APIDocumentosSGIId = " & APIDocumentosSGIId
        Try
            APIDocumentosSGIUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & DocumentosSGICodigo, APIDocumentosSGIId, "APIDocumentosSGI", "")
        Catch
            APIDocumentosSGIUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & DocumentosSGICodigo, APIDocumentosSGIId, "APIDocumentosSGI", "")
        End Try
    End Function
    Public Function APIDocumentosSGIInsert(ByRef APIDocumentosSGIId As Long, ByRef DocumentosSGICodigo As String, ByRef APIDocumentosSGISecuencia As Long, ByRef MenuOptionsId As Long, ByRef APIDocumentosSGICodigo As String, ByRef APIDocumentosSGIAmbito As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim APIDocumentosSGI As New APIDocumentosSGI
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = DocumentosSGICodigo
            DetailSecuencia = APIDocumentosSGISecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("APIDocumentosSGIId", "DocumentosSGICodigo", "APIDocumentosSGISecuencia", "APIDocumentosSGI", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("APIDocumentosSGIId", "DocumentosSGICodigo", "APIDocumentosSGISecuencia", "APIDocumentosSGI", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            APIDocumentosSGIInsert = APIDocumentosSGI.APIDocumentosSGIUpdate(DetailId, CStr(DocumentosSGICodigo), CLng(APIDocumentosSGISecuencia), CLng(MenuOptionsId), CStr(APIDocumentosSGICodigo), CStr(APIDocumentosSGIAmbito), UserId)
        Catch
            APIDocumentosSGIInsert = 0
        End Try
    End Function
    Public Function APIDocumentosSGIDelete(ByVal APIDocumentosSGIId As Long, ByVal DocumentosSGICodigo As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "DELETE FROM APIDocumentosSGI WHERE APIDocumentosSGIId = " & APIDocumentosSGIId

        Try
            APIDocumentosSGIDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina un código API del documento: " & DocumentosSGICodigo, APIDocumentosSGIId, "APIDocumentosSGI", "")
        Catch
            APIDocumentosSGIDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar un código API del documento: " & DocumentosSGICodigo, APIDocumentosSGIId, "APIDocumentosSGI", "")
        End Try
    End Function
End Class
