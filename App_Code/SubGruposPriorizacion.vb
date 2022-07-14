'------------------------------------------------------------
' Código generado por ZRISMART SF el 01-09-2011 23:16:37
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class SubGruposPriorizacion
    Public Function LeerSubGruposPriorizacion(ByVal SubGruposPriorizacionId As Long, ByRef GruposPriorizacionCodigo As String, ByRef SubGruposPriorizacionSecuencia As Long, ByRef SubGruposPriorizacionName As String, ByRef SubGruposPriorizacionDescription As String, _
                                              ByRef SubGruposPriorizacionNivel1 As String, ByRef SubGruposPriorizacionNivel2 As String, ByRef SubGruposPriorizacionNivel3 As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select GruposPriorizacionCodigo, SubGruposPriorizacionSecuencia, SubGruposPriorizacionName, SubGruposPriorizacionDescription, SubGruposPriorizacionNivel1, SubGruposPriorizacionNivel2, SubGruposPriorizacionNivel3  "
        sSQL = sSQL & "FROM (SubGruposPriorizacion) "
        sSQL = sSQL & "WHERE (SubGruposPriorizacion.SubGruposPriorizacionId = " & SubGruposPriorizacionId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                GruposPriorizacionCodigo = CStr(dtr("GruposPriorizacionCodigo").ToString)
                If Len(dtr("SubGruposPriorizacionSecuencia").ToString) = 0 Then
                    SubGruposPriorizacionSecuencia = 0
                Else
                    SubGruposPriorizacionSecuencia = CLng(dtr("SubGruposPriorizacionSecuencia").ToString)
                End If
                SubGruposPriorizacionName = CStr(dtr("SubGruposPriorizacionName").ToString)
                SubGruposPriorizacionDescription = CStr(dtr("SubGruposPriorizacionDescription").ToString)
                SubGruposPriorizacionNivel1 = CStr(dtr("SubGruposPriorizacionNivel1").ToString)
                SubGruposPriorizacionNivel2 = CStr(dtr("SubGruposPriorizacionNivel2").ToString)
                SubGruposPriorizacionNivel3 = CStr(dtr("SubGruposPriorizacionNivel3").ToString)
            End While
            LeerSubGruposPriorizacion = True
            dtr.Close()
        Catch
            LeerSubGruposPriorizacion = False
        End Try
    End Function
    Public Function SubGruposPriorizacionUpdate(ByVal SubGruposPriorizacionId As Long, ByRef GruposPriorizacionCodigo As String, ByRef SubGruposPriorizacionSecuencia As Long, ByRef SubGruposPriorizacionName As String, ByRef SubGruposPriorizacionDescription As String, ByRef SubGruposPriorizacionNivel1 As String, ByRef SubGruposPriorizacionNivel2 As String, ByRef SubGruposPriorizacionNivel3 As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE SubGruposPriorizacion SET "
        strUpdate = strUpdate & "SubGruposPriorizacion.GruposPriorizacionCodigo = '" & GruposPriorizacionCodigo & "', "
        strUpdate = strUpdate & "SubGruposPriorizacion.SubGruposPriorizacionSecuencia = " & SubGruposPriorizacionSecuencia & ", "
        strUpdate = strUpdate & "SubGruposPriorizacion.SubGruposPriorizacionName = '" & SubGruposPriorizacionName & "', "
        strUpdate = strUpdate & "SubGruposPriorizacion.SubGruposPriorizacionDescription = '" & SubGruposPriorizacionDescription & "', "
        strUpdate = strUpdate & "SubGruposPriorizacion.SubGruposPriorizacionNivel1 = '" & SubGruposPriorizacionNivel1 & "', "
        strUpdate = strUpdate & "SubGruposPriorizacion.SubGruposPriorizacionNivel2 = '" & SubGruposPriorizacionNivel2 & "', "
        strUpdate = strUpdate & "SubGruposPriorizacion.SubGruposPriorizacionNivel3 = '" & SubGruposPriorizacionNivel3 & "', "
        strUpdate = strUpdate & "SubGruposPriorizacion.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "SubGruposPriorizacion.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE SubGruposPriorizacion.SubGruposPriorizacionId = " & SubGruposPriorizacionId
        Try
            SubGruposPriorizacionUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & GruposPriorizacionCodigo, SubGruposPriorizacionId, "SubGruposPriorizacion", "")
        Catch
            SubGruposPriorizacionUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & GruposPriorizacionCodigo, SubGruposPriorizacionId, "SubGruposPriorizacion", "")
        End Try
    End Function
    Public Function SubGruposPriorizacionInsert(ByRef SubGruposPriorizacionId As Long, ByRef GruposPriorizacionCodigo As String, ByRef SubGruposPriorizacionSecuencia As Long, ByRef SubGruposPriorizacionName As String, ByRef SubGruposPriorizacionDescription As String, ByRef SubGruposPriorizacionNivel1 As String, ByRef SubGruposPriorizacionNivel2 As String, ByRef SubGruposPriorizacionNivel3 As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim SubGruposPriorizacion As New SubGruposPriorizacion
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = GruposPriorizacionCodigo
            DetailSecuencia = SubGruposPriorizacionSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("SubGruposPriorizacionId", "GruposPriorizacionCodigo", "SubGruposPriorizacionSecuencia", "SubGruposPriorizacion", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("SubGruposPriorizacionId", "GruposPriorizacionCodigo", "SubGruposPriorizacionSecuencia", "SubGruposPriorizacion", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            SubGruposPriorizacionInsert = SubGruposPriorizacion.SubGruposPriorizacionUpdate(DetailId, CStr(GruposPriorizacionCodigo), CLng(SubGruposPriorizacionSecuencia), CStr(SubGruposPriorizacionName), CStr(SubGruposPriorizacionDescription), CStr(SubGruposPriorizacionNivel1), CStr(SubGruposPriorizacionNivel2), CStr(SubGruposPriorizacionNivel3), UserId)
        Catch
            SubGruposPriorizacionInsert = 0
        End Try
    End Function
    Public Function SubGruposPriorizacionDelete(ByVal SubGruposPriorizacionId As Long, ByVal GruposPriorizacionCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (SubGruposPriorizacion) "
        strUpdate = strUpdate & "WHERE (SubGruposPriorizacion.SubGruposPriorizacionId = " & SubGruposPriorizacionId & ") "
        Try
            SubGruposPriorizacionDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & GruposPriorizacionCodigo, SubGruposPriorizacionId, "SubGruposPriorizacion", "")
        Catch
            SubGruposPriorizacionDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & GruposPriorizacionCodigo, SubGruposPriorizacionId, "SubGruposPriorizacion", "")
        End Try
    End Function
End Class
