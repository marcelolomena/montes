'------------------------------------------------------------
' Código generado por ZRISMART SF el 01-02-2011 12:44:15
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class ContratoDocs
    Public Function LeerContratoDocs(ByVal ContratoDocsId As Long, ByRef ContratoCodigo As String, ByRef ContratoDocsSecuencia As Long, ByRef ContratoDocsNombre As String, ByRef ContratoDocsDescription As String, ByRef ContratoDocsPath As String, ByRef ContratoDocsFEmision As Date, ByRef ContratoDocsResponsable As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ContratoCodigo, ContratoDocsSecuencia, ContratoDocsNombre, ContratoDocsDescription, ContratoDocsPath, ContratoDocsFEmision, ContratoDocsResponsable "
        sSQL = sSQL & "FROM (ContratoDocs) "
        sSQL = sSQL & "WHERE (ContratoDocs.ContratoDocsId = " & ContratoDocsId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ContratoCodigo = CStr(dtr("ContratoCodigo").ToString)
                If Len(dtr("ContratoDocsSecuencia").ToString) = 0 Then
                    ContratoDocsSecuencia = 0
                Else
                    ContratoDocsSecuencia = CLng(dtr("ContratoDocsSecuencia").ToString)
                End If
                ContratoDocsNombre = CStr(dtr("ContratoDocsNombre").ToString)
                ContratoDocsDescription = CStr(dtr("ContratoDocsDescription").ToString)
                ContratoDocsPath = CStr(dtr("ContratoDocsPath").ToString)
                If Len(dtr("ContratoDocsFEmision").ToString) = 0 Then
                    ContratoDocsFEmision = "01/01/01"
                Else
                    ContratoDocsFEmision = CDate(dtr("ContratoDocsFEmision").ToString)
                End If
                ContratoDocsResponsable = CStr(dtr("ContratoDocsResponsable").ToString)
            End While
            LeerContratoDocs = True
            dtr.Close()
        Catch
            LeerContratoDocs = False
        End Try
    End Function
    Public Function ContratoDocsUpdate(ByVal ContratoDocsId As Long, ByRef ContratoCodigo As String, ByRef ContratoDocsSecuencia As Long, ByRef ContratoDocsNombre As String, ByRef ContratoDocsDescription As String, ByRef ContratoDocsPath As String, ByRef ContratoDocsFEmision As Date, ByRef ContratoDocsResponsable As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE ContratoDocs SET "
        strUpdate = strUpdate & "ContratoDocs.ContratoCodigo = '" & ContratoCodigo & "', "
        strUpdate = strUpdate & "ContratoDocs.ContratoDocsSecuencia = " & ContratoDocsSecuencia & ", "
        strUpdate = strUpdate & "ContratoDocs.ContratoDocsNombre = '" & ContratoDocsNombre & "', "
        strUpdate = strUpdate & "ContratoDocs.ContratoDocsDescription = '" & ContratoDocsDescription & "', "
        strUpdate = strUpdate & "ContratoDocs.ContratoDocsPath = '" & ContratoDocsPath & "', "
        strUpdate = strUpdate & "ContratoDocs.ContratoDocsFEmision = '" & AccionesABM.DateTransform(ContratoDocsFEmision) & "', "
        strUpdate = strUpdate & "ContratoDocs.ContratoDocsResponsable = '" & ContratoDocsResponsable & "', "
        strUpdate = strUpdate & "ContratoDocs.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "ContratoDocs.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE ContratoDocs.ContratoDocsId = " & ContratoDocsId
        Try
            ContratoDocsUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ContratoCodigo, ContratoDocsId, "ContratoDocs", "")
        Catch
            ContratoDocsUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ContratoCodigo, ContratoDocsId, "ContratoDocs", "")
        End Try
    End Function
    Public Function ContratoDocsInsert(ByRef ContratoDocsId As Long, ByRef ContratoCodigo As String, ByRef ContratoDocsSecuencia As Long, ByRef ContratoDocsNombre As String, ByRef ContratoDocsDescription As String, ByRef ContratoDocsPath As String, ByRef ContratoDocsFEmision As Date, ByRef ContratoDocsResponsable As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim ContratoDocs As New ContratoDocs
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = ContratoCodigo
            DetailSecuencia = ContratoDocsSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("ContratoDocsId", "ContratoCodigo", "ContratoDocsSecuencia", "ContratoDocs", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("ContratoDocsId", "ContratoCodigo", "ContratoDocsSecuencia", "ContratoDocs", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            ContratoDocsInsert = ContratoDocs.ContratoDocsUpdate(DetailId, CStr(ContratoCodigo), CLng(ContratoDocsSecuencia), CStr(ContratoDocsNombre), CStr(ContratoDocsDescription), CStr(ContratoDocsPath), CDate(ContratoDocsFEmision), CStr(ContratoDocsResponsable), UserId)
        Catch
            ContratoDocsInsert = 0
        End Try
    End Function
    Public Function ContratoDocsDelete(ByVal ContratoDocsId As Long, ByVal ContratoCodigo As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "DELETE FROM ContratoDocs WHERE ContratoDocsId = " & ContratoDocsId

        Try
            ContratoDocsDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina un documento del contrato: " & ContratoCodigo, ContratoDocsId, "ContratoDocs", "")
        Catch
            ContratoDocsDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar un documento del contrato: " & ContratoCodigo, ContratoDocsId, "ContratoDocs", "")
        End Try
    End Function
End Class
