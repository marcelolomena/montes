'------------------------------------------------------------
' Código generado por ZRISMART SF el 01-04-2011 21:09:19
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class ProyectosDocs
    Public Function LeerProyectosDocs(ByVal ProyectosDocsId As Long, ByRef ProyectosCodigo As String, ByRef ProyectosSecuencia As Long, ByRef ProyectosNombre As String, ByRef ProyectosDescription As String, ByRef ProyectosPath As String, ByRef ProyectosFEmision As Date, ByRef ProyectosResponsable As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProyectosCodigo, ProyectosSecuencia, ProyectosNombre, ProyectosDescription, ProyectosPath, ProyectosFEmision, ProyectosResponsable "
        sSQL = sSQL & "FROM (ProyectosDocs) "
        sSQL = sSQL & "WHERE (ProyectosDocs.ProyectosDocsId = " & ProyectosDocsId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProyectosCodigo = CStr(dtr("ProyectosCodigo").ToString)
                If Len(dtr("ProyectosSecuencia").ToString) = 0 Then
                    ProyectosSecuencia = 0
                Else
                    ProyectosSecuencia = CLng(dtr("ProyectosSecuencia").ToString)
                End If
                ProyectosNombre = CStr(dtr("ProyectosNombre").ToString)
                ProyectosDescription = CStr(dtr("ProyectosDescription").ToString)
                ProyectosPath = CStr(dtr("ProyectosPath").ToString)
                If Len(dtr("ProyectosFEmision").ToString) = 0 Then
                    ProyectosFEmision = "01/01/01"
                Else
                    ProyectosFEmision = CDate(dtr("ProyectosFEmision").ToString)
                End If
                ProyectosResponsable = CStr(dtr("ProyectosResponsable").ToString)
            End While
            LeerProyectosDocs = True
            dtr.Close()
        Catch
            LeerProyectosDocs = False
        End Try
    End Function
    Public Function ProyectosDocsUpdate(ByVal ProyectosDocsId As Long, ByRef ProyectosCodigo As String, ByRef ProyectosSecuencia As Long, ByRef ProyectosNombre As String, ByRef ProyectosDescription As String, ByRef ProyectosPath As String, ByRef ProyectosFEmision As Date, ByRef ProyectosResponsable As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE ProyectosDocs SET "
        strUpdate = strUpdate & "ProyectosDocs.ProyectosCodigo = '" & ProyectosCodigo & "', "
        strUpdate = strUpdate & "ProyectosDocs.ProyectosSecuencia = " & ProyectosSecuencia & ", "
        strUpdate = strUpdate & "ProyectosDocs.ProyectosNombre = '" & ProyectosNombre & "', "
        strUpdate = strUpdate & "ProyectosDocs.ProyectosDescription = '" & ProyectosDescription & "', "
        strUpdate = strUpdate & "ProyectosDocs.ProyectosPath = '" & ProyectosPath & "', "
        strUpdate = strUpdate & "ProyectosDocs.ProyectosFEmision = '" & AccionesABM.DateTransform(ProyectosFEmision) & "', "
        strUpdate = strUpdate & "ProyectosDocs.ProyectosResponsable = '" & ProyectosResponsable & "', "
        strUpdate = strUpdate & "ProyectosDocs.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "ProyectosDocs.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE ProyectosDocs.ProyectosDocsId = " & ProyectosDocsId
        Try
            ProyectosDocsUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ProyectosCodigo, ProyectosDocsId, "ProyectosDocs", "")
        Catch
            ProyectosDocsUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ProyectosCodigo, ProyectosDocsId, "ProyectosDocs", "")
        End Try
    End Function
    Public Function ProyectosDocsInsert(ByRef ProyectosDocsId As Long, ByRef ProyectosCodigo As String, ByRef ProyectosSecuencia As Long, ByRef ProyectosNombre As String, ByRef ProyectosDescription As String, ByRef ProyectosPath As String, ByRef ProyectosFEmision As Date, ByRef ProyectosResponsable As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim ProyectosDocs As New ProyectosDocs
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = ProyectosCodigo
            DetailSecuencia = ProyectosSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("ProyectosDocsId", "ProyectosCodigo", "ProyectosSecuencia", "ProyectosDocs", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("ProyectosDocsId", "ProyectosCodigo", "ProyectosSecuencia", "ProyectosDocs", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            ProyectosDocsInsert = ProyectosDocs.ProyectosDocsUpdate(DetailId, CStr(ProyectosCodigo), CLng(ProyectosSecuencia), CStr(ProyectosNombre), CStr(ProyectosDescription), CStr(ProyectosPath), CDate(ProyectosFEmision), CStr(ProyectosResponsable), UserId)
        Catch
            ProyectosDocsInsert = 0
        End Try
    End Function
    Public Function ProyectosDocsDelete(ByVal ProyectosDocsId As Long, ByVal ProyectosCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (ProyectosDocs) "
        strUpdate = strUpdate & "WHERE (ProyectosDocs.ProyectosDocsId = " & ProyectosDocsId & ") "
        Try
            ProyectosDocsDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & ProyectosCodigo, ProyectosDocsId, "ProyectosDocs", "")
        Catch
            ProyectosDocsDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & ProyectosCodigo, ProyectosDocsId, "ProyectosDocs", "")
        End Try
    End Function
End Class
