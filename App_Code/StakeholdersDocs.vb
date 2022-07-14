'------------------------------------------------------------
' Código generado por ZRISMART SF el 29-08-2011 14:29:36
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class StakeholdersDocs
    Public Function LeerStakeholdersDocs(ByVal StakeholdersDocsId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersDocsSecuencia As Long, ByRef StakeholdersDocsNombre As String, ByRef StakeholdersDocsDescription As String, ByRef StakeholdersDocsPath As String, ByRef TipoDocName As String, ByRef AreasName As String, ByRef StakeholdersDocsFEmision As Date, ByRef UsuariosCodigo As String, ByRef StakeholdersDocsObservaciones As String, ByRef StakeholdersDocsResponsable As String, ByRef StakeholdersDocsCargoResponsable As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersCodigo, StakeholdersDocsSecuencia, StakeholdersDocsNombre, StakeholdersDocsDescription, StakeholdersDocsPath, TipoDocName, AreasName, StakeholdersDocsFEmision, UsuariosCodigo, StakeholdersDocsObservaciones, StakeholdersDocsResponsable, StakeholdersDocsCargoResponsable "
        sSQL = sSQL & "FROM (StakeholdersDocs) "
        sSQL = sSQL & "WHERE (StakeholdersDocs.StakeholdersDocsId = " & StakeholdersDocsId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                StakeholdersCodigo = CStr(dtr("StakeholdersCodigo").ToString)
                If Len(dtr("StakeholdersDocsSecuencia").ToString) = 0 Then
                    StakeholdersDocsSecuencia = 0
                Else
                    StakeholdersDocsSecuencia = CLng(dtr("StakeholdersDocsSecuencia").ToString)
                End If
                StakeholdersDocsNombre = CStr(dtr("StakeholdersDocsNombre").ToString)
                StakeholdersDocsDescription = CStr(dtr("StakeholdersDocsDescription").ToString)
                StakeholdersDocsPath = CStr(dtr("StakeholdersDocsPath").ToString)
                TipoDocName = CStr(dtr("TipoDocName").ToString)
                AreasName = CStr(dtr("AreasName").ToString)
                If Len(dtr("StakeholdersDocsFEmision").ToString) = 0 Then
                    StakeholdersDocsFEmision = "01/01/01"
                Else
                    StakeholdersDocsFEmision = CDate(dtr("StakeholdersDocsFEmision").ToString)
                End If
                UsuariosCodigo = CStr(dtr("UsuariosCodigo").ToString)
                StakeholdersDocsObservaciones = CStr(dtr("StakeholdersDocsObservaciones").ToString)
                StakeholdersDocsResponsable = CStr(dtr("StakeholdersDocsResponsable").ToString)
                StakeholdersDocsCargoResponsable = CStr(dtr("StakeholdersDocsCargoResponsable").ToString)
            End While
            LeerStakeholdersDocs = True
            dtr.Close()
        Catch
            LeerStakeholdersDocs = False
        End Try
    End Function
    Public Function StakeholdersDocsUpdate(ByVal StakeholdersDocsId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersDocsSecuencia As Long, ByRef StakeholdersDocsNombre As String, ByRef StakeholdersDocsDescription As String, ByRef StakeholdersDocsPath As String, ByRef TipoDocName As String, ByRef AreasName As String, ByRef StakeholdersDocsFEmision As Date, ByRef UsuariosCodigo As String, ByRef StakeholdersDocsObservaciones As String, ByRef StakeholdersDocsResponsable As String, ByRef StakeholdersDocsCargoResponsable As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE StakeholdersDocs SET "
        strUpdate = strUpdate & "StakeholdersDocs.StakeholdersCodigo = '" & StakeholdersCodigo & "', "
        strUpdate = strUpdate & "StakeholdersDocs.StakeholdersDocsSecuencia = " & StakeholdersDocsSecuencia & ", "
        strUpdate = strUpdate & "StakeholdersDocs.StakeholdersDocsNombre = '" & StakeholdersDocsNombre & "', "
        strUpdate = strUpdate & "StakeholdersDocs.StakeholdersDocsDescription = '" & StakeholdersDocsDescription & "', "
        strUpdate = strUpdate & "StakeholdersDocs.StakeholdersDocsPath = '" & StakeholdersDocsPath & "', "
        strUpdate = strUpdate & "StakeholdersDocs.TipoDocName = '" & TipoDocName & "', "
        strUpdate = strUpdate & "StakeholdersDocs.AreasName = '" & AreasName & "', "
        strUpdate = strUpdate & "StakeholdersDocs.StakeholdersDocsFEmision = '" & AccionesABM.DateTransform(StakeholdersDocsFEmision) & "', "
        strUpdate = strUpdate & "StakeholdersDocs.UsuariosCodigo = '" & UsuariosCodigo & "', "
        strUpdate = strUpdate & "StakeholdersDocs.StakeholdersDocsObservaciones = '" & StakeholdersDocsObservaciones & "', "
        strUpdate = strUpdate & "StakeholdersDocs.StakeholdersDocsResponsable = '" & StakeholdersDocsResponsable & "', "
        strUpdate = strUpdate & "StakeholdersDocs.StakeholdersDocsCargoResponsable = '" & StakeholdersDocsCargoResponsable & "', "
        strUpdate = strUpdate & "StakeholdersDocs.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "StakeholdersDocs.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE StakeholdersDocs.StakeholdersDocsId = " & StakeholdersDocsId
        Try
            StakeholdersDocsUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & StakeholdersCodigo, StakeholdersDocsId, "StakeholdersDocs", "")
        Catch
            StakeholdersDocsUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & StakeholdersCodigo, StakeholdersDocsId, "StakeholdersDocs", "")
        End Try
    End Function
    Public Function StakeholdersDocsInsert(ByRef StakeholdersDocsId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersDocsSecuencia As Long, ByRef StakeholdersDocsNombre As String, ByRef StakeholdersDocsDescription As String, ByRef StakeholdersDocsPath As String, ByRef TipoDocName As String, ByRef AreasName As String, ByRef StakeholdersDocsFEmision As Date, ByRef UsuariosCodigo As String, ByRef StakeholdersDocsObservaciones As String, ByRef StakeholdersDocsResponsable As String, ByRef StakeholdersDocsCargoResponsable As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim StakeholdersDocs As New StakeholdersDocs
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = StakeholdersCodigo
            DetailSecuencia = StakeholdersDocsSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("StakeholdersDocsId", "StakeholdersCodigo", "StakeholdersDocsSecuencia", "StakeholdersDocs", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("StakeholdersDocsId", "StakeholdersCodigo", "StakeholdersDocsSecuencia", "StakeholdersDocs", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            StakeholdersDocsInsert = StakeholdersDocs.StakeholdersDocsUpdate(DetailId, CStr(StakeholdersCodigo), CLng(StakeholdersDocsSecuencia), CStr(StakeholdersDocsNombre), CStr(StakeholdersDocsDescription), CStr(StakeholdersDocsPath), CStr(TipoDocName), CStr(AreasName), CDate(StakeholdersDocsFEmision), CStr(UsuariosCodigo), CStr(StakeholdersDocsObservaciones), CStr(StakeholdersDocsResponsable), CStr(StakeholdersDocsCargoResponsable), UserId)
        Catch
            StakeholdersDocsInsert = 0
        End Try
    End Function
    Public Function StakeholdersDocsDelete(ByVal StakeholdersDocsId As Long, ByVal StakeholdersCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (StakeholdersDocs) "
        strUpdate = strUpdate & "WHERE (StakeholdersDocs.StakeholdersDocsId = " & StakeholdersDocsId & ") "
        Try
            StakeholdersDocsDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & StakeholdersCodigo, StakeholdersDocsId, "StakeholdersDocs", "")
        Catch
            StakeholdersDocsDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & StakeholdersCodigo, StakeholdersDocsId, "StakeholdersDocs", "")
        End Try
    End Function
    Public Function LoadDocsPorStakeholders(ByRef rptDocumentos As Repeater, ByVal StakeholdersId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT StakeholdersDocs.StakeholdersDocsNombre as Nombre, Mid(StakeholdersDocs.StakeholdersDocsFEmision,1,10) as Fecha, 'SGI\' + StakeholdersDocs.StakeholdersDocsPath As URL, StakeholdersDocs.TipoDocName As Tipo "
        sSQL = sSQL & "FROM Stakeholders INNER JOIN StakeholdersDocs ON Stakeholders.StakeholdersCodigo = StakeholdersDocs.StakeholdersCodigo "
        sSQL = sSQL & "WHERE (((Stakeholders.StakeholdersId)=" & StakeholdersId & "))"

        Try
            dtrRutasPorViajes = AccesoEA.ListarRegistros(sSQL)

            rptDocumentos.DataSource = dtrRutasPorViajes
            rptDocumentos.DataBind()
            LoadDocsPorStakeholders = True
            dtrRutasPorViajes.Close()
        Catch
            LoadDocsPorStakeholders = False
        End Try
    End Function
End Class
