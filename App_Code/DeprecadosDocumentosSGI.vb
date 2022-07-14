'------------------------------------------------------------
' Código generado por ZRISMART SF el 02-12-2010 6:07:22
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class DeprecadosDocumentosSGI
    Public Function LeerDeprecadosDocumentosSGI(ByVal DeprecadosDocumentosSGIId As Long, ByRef DocumentosSGICodigo As String, ByRef DeprecadosDocumentosSGISecuencia As Long, ByRef DeprecadosDocumentosSGICodigo As String, ByRef DeprecadosDocumentosSGINombre As String, ByRef DeprecadosDocumentosSGIDescription As String, ByRef DeprecadosDocumentosSGIPath As String, ByRef DeprecadosDocumentosSGIOrigen As String, ByRef DeprecadosDocumentosSGITipo As String, ByRef DeprecadosDocumentosSGIFEmision As Date, ByRef DeprecadosDocumentosSGIFRevision As String, ByRef DeprecadosDocumentosSGIArea As String, ByRef DeprecadosDocumentosSGIResponsable As String, ByRef DeprecadosDocumentosSGIEmpresa As String, ByRef DeprecadosDocumentosSGIContrato As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select DocumentosSGICodigo, DeprecadosDocumentosSGISecuencia, DeprecadosDocumentosSGICodigo, DeprecadosDocumentosSGINombre, DeprecadosDocumentosSGIDescription, DeprecadosDocumentosSGIPath, DeprecadosDocumentosSGIOrigen, DeprecadosDocumentosSGITipo, DeprecadosDocumentosSGIFEmision, DeprecadosDocumentosSGIFRevision, DeprecadosDocumentosSGIArea, DeprecadosDocumentosSGIResponsable, DeprecadosDocumentosSGIEmpresa, DeprecadosDocumentosSGIContrato "
        sSQL = sSQL & "FROM (DeprecadosDocumentosSGI) "
        sSQL = sSQL & "WHERE (DeprecadosDocumentosSGI.DeprecadosDocumentosSGIId = " & DeprecadosDocumentosSGIId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                DocumentosSGICodigo = CStr(dtr("DocumentosSGICodigo").ToString)
                If Len(dtr("DeprecadosDocumentosSGISecuencia").ToString) = 0 Then
                    DeprecadosDocumentosSGISecuencia = 0
                Else
                    DeprecadosDocumentosSGISecuencia = CLng(dtr("DeprecadosDocumentosSGISecuencia").ToString)
                End If
                DeprecadosDocumentosSGICodigo = CStr(dtr("DeprecadosDocumentosSGICodigo").ToString)
                DeprecadosDocumentosSGINombre = CStr(dtr("DeprecadosDocumentosSGINombre").ToString)
                DeprecadosDocumentosSGIDescription = CStr(dtr("DeprecadosDocumentosSGIDescription").ToString)
                DeprecadosDocumentosSGIPath = CStr(dtr("DeprecadosDocumentosSGIPath").ToString)
                DeprecadosDocumentosSGIOrigen = CStr(dtr("DeprecadosDocumentosSGIOrigen").ToString)
                DeprecadosDocumentosSGITipo = CStr(dtr("DeprecadosDocumentosSGITipo").ToString)
                If Len(dtr("DeprecadosDocumentosSGIFEmision").ToString) = 0 Then
                    DeprecadosDocumentosSGIFEmision = "01/01/01"
                Else
                    DeprecadosDocumentosSGIFEmision = CDate(dtr("DeprecadosDocumentosSGIFEmision").ToString)
                End If
                DeprecadosDocumentosSGIFRevision = dtr("DeprecadosDocumentosSGIFRevision").ToString
                DeprecadosDocumentosSGIArea = CStr(dtr("DeprecadosDocumentosSGIArea").ToString)
                DeprecadosDocumentosSGIResponsable = CStr(dtr("DeprecadosDocumentosSGIResponsable").ToString)
                DeprecadosDocumentosSGIEmpresa = CStr(dtr("DeprecadosDocumentosSGIEmpresa").ToString)
                DeprecadosDocumentosSGIContrato = CStr(dtr("DeprecadosDocumentosSGIContrato").ToString)
            End While
            LeerDeprecadosDocumentosSGI = True
            dtr.Close()
        Catch
            LeerDeprecadosDocumentosSGI = False
        End Try
    End Function
    Public Function DeprecadosDocumentosSGIUpdate(ByVal DeprecadosDocumentosSGIId As Long, ByRef DocumentosSGICodigo As String, ByRef DeprecadosDocumentosSGISecuencia As Long, ByRef DeprecadosDocumentosSGICodigo As String, ByRef DeprecadosDocumentosSGINombre As String, ByRef DeprecadosDocumentosSGIDescription As String, ByRef DeprecadosDocumentosSGIPath As String, ByRef DeprecadosDocumentosSGIOrigen As String, ByRef DeprecadosDocumentosSGITipo As String, ByRef DeprecadosDocumentosSGIFEmision As Date, ByRef DeprecadosDocumentosSGIFRevision As String, ByRef DeprecadosDocumentosSGIArea As String, ByRef DeprecadosDocumentosSGIResponsable As String, ByRef DeprecadosDocumentosSGIEmpresa As String, ByRef DeprecadosDocumentosSGIContrato As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE DeprecadosDocumentosSGI SET "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DocumentosSGICodigo = '" & DocumentosSGICodigo & "', "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DeprecadosDocumentosSGISecuencia = " & DeprecadosDocumentosSGISecuencia & ", "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DeprecadosDocumentosSGICodigo = '" & DeprecadosDocumentosSGICodigo & "', "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DeprecadosDocumentosSGINombre = '" & DeprecadosDocumentosSGINombre & "', "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DeprecadosDocumentosSGIDescription = '" & DeprecadosDocumentosSGIDescription & "', "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DeprecadosDocumentosSGIPath = '" & DeprecadosDocumentosSGIPath & "', "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DeprecadosDocumentosSGIOrigen = '" & DeprecadosDocumentosSGIOrigen & "', "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DeprecadosDocumentosSGITipo = '" & DeprecadosDocumentosSGITipo & "', "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DeprecadosDocumentosSGIFEmision = '" & AccionesABM.DateTransform(DeprecadosDocumentosSGIFEmision) & "', "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DeprecadosDocumentosSGIFRevision = '" & DeprecadosDocumentosSGIFRevision & "', "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DeprecadosDocumentosSGIArea = '" & DeprecadosDocumentosSGIArea & "', "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DeprecadosDocumentosSGIResponsable = '" & DeprecadosDocumentosSGIResponsable & "', "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DeprecadosDocumentosSGIEmpresa = '" & DeprecadosDocumentosSGIEmpresa & "', "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DeprecadosDocumentosSGIContrato = '" & DeprecadosDocumentosSGIContrato & "', "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "DeprecadosDocumentosSGI.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE DeprecadosDocumentosSGI.DeprecadosDocumentosSGIId = " & DeprecadosDocumentosSGIId
        Try
            DeprecadosDocumentosSGIUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & DocumentosSGICodigo, DeprecadosDocumentosSGIId, "DeprecadosDocumentosSGI", "")
        Catch
            DeprecadosDocumentosSGIUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & DocumentosSGICodigo, DeprecadosDocumentosSGIId, "DeprecadosDocumentosSGI", "")
        End Try
    End Function
    Public Function DeprecadosDocumentosSGIInsert(ByRef DeprecadosDocumentosSGIId As Long, ByRef DocumentosSGICodigo As String, ByRef DeprecadosDocumentosSGISecuencia As Long, ByRef DeprecadosDocumentosSGICodigo As String, ByRef DeprecadosDocumentosSGINombre As String, ByRef DeprecadosDocumentosSGIDescription As String, ByRef DeprecadosDocumentosSGIPath As String, ByRef DeprecadosDocumentosSGIOrigen As String, ByRef DeprecadosDocumentosSGITipo As String, ByRef DeprecadosDocumentosSGIFEmision As Date, ByRef DeprecadosDocumentosSGIFRevision As String, ByRef DeprecadosDocumentosSGIArea As String, ByRef DeprecadosDocumentosSGIResponsable As String, ByRef DeprecadosDocumentosSGIEmpresa As String, ByRef DeprecadosDocumentosSGIContrato As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim DeprecadosDocumentosSGI As New DeprecadosDocumentosSGI
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = DocumentosSGICodigo
            DetailSecuencia = DeprecadosDocumentosSGISecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("DeprecadosDocumentosSGIId", "DocumentosSGICodigo", "DeprecadosDocumentosSGISecuencia", "DeprecadosDocumentosSGI", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("DeprecadosDocumentosSGIId", "DocumentosSGICodigo", "DeprecadosDocumentosSGISecuencia", "DeprecadosDocumentosSGI", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            DeprecadosDocumentosSGIInsert = DeprecadosDocumentosSGI.DeprecadosDocumentosSGIUpdate(DetailId, CStr(DocumentosSGICodigo), CLng(DeprecadosDocumentosSGISecuencia), CStr(DeprecadosDocumentosSGICodigo), CStr(DeprecadosDocumentosSGINombre), CStr(DeprecadosDocumentosSGIDescription), CStr(DeprecadosDocumentosSGIPath), CStr(DeprecadosDocumentosSGIOrigen), CStr(DeprecadosDocumentosSGITipo), CDate(DeprecadosDocumentosSGIFEmision), CStr(DeprecadosDocumentosSGIFRevision), CStr(DeprecadosDocumentosSGIArea), CStr(DeprecadosDocumentosSGIResponsable), CStr(DeprecadosDocumentosSGIEmpresa), CStr(DeprecadosDocumentosSGIContrato), UserId)
        Catch
            DeprecadosDocumentosSGIInsert = 0
        End Try
    End Function
    Public Function DeprecadosDocumentosSGIDelete(ByVal DeprecadosDocumentosSGIId As Long, ByVal DocumentosSGICodigo As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "DELETE FROM DeprecadosDocumentosSGI WHERE DeprecadosDocumentosSGIId = " & DeprecadosDocumentosSGIId

        Try
            DeprecadosDocumentosSGIDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina un documento obsoleto del documento: " & DocumentosSGICodigo, DeprecadosDocumentosSGIId, "DeprecadosDocumentosSGI", "")
        Catch
            DeprecadosDocumentosSGIDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar un documento obsoleto del documento: " & DocumentosSGICodigo, DeprecadosDocumentosSGIId, "DeprecadosDocumentosSGI", "")
        End Try
    End Function
End Class
