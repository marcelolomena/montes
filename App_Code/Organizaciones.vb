'------------------------------------------------------------
' Código generado por ZRISMART SF el 24-07-2011 9:00:28
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Organizaciones
    Public Function LeerOrganizaciones(ByVal OrganizacionesId As Long, ByRef OrganizacionesCodigo As String, ByRef OrganizacionesName As String, ByRef OrganizacionesDescription As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select OrganizacionesCodigo, OrganizacionesName, OrganizacionesDescription "
        sSQL = sSQL & "FROM (Organizaciones) "
        sSQL = sSQL & "WHERE (Organizaciones.OrganizacionesId = " & OrganizacionesId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                OrganizacionesCodigo = CStr(dtr("OrganizacionesCodigo").ToString)
                OrganizacionesName = CStr(dtr("OrganizacionesName").ToString)
                OrganizacionesDescription = CStr(dtr("OrganizacionesDescription").ToString)
            End While
            LeerOrganizaciones = True
            dtr.Close()
        Catch
            LeerOrganizaciones = False
        End Try
    End Function
    Public Function LeerOrganizacionesByName(ByRef OrganizacionesId As Long, ByVal OrganizacionesCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select OrganizacionesId "
        sSQL = sSQL & "FROM (Organizaciones) "
        sSQL = sSQL & "WHERE (Organizaciones.OrganizacionesCodigo = '" & OrganizacionesCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                OrganizacionesId = CLng(dtr("OrganizacionesId").ToString)
            End While
            LeerOrganizacionesByName = True
            dtr.Close()
        Catch
            LeerOrganizacionesByName = False
        End Try
    End Function
    Public Function OrganizacionesUpdate(ByVal OrganizacionesId As Long, ByRef OrganizacionesCodigo As String, ByRef OrganizacionesName As String, ByRef OrganizacionesDescription As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Organizaciones SET "
        strUpdate = strUpdate & "Organizaciones.OrganizacionesCodigo = '" & OrganizacionesCodigo & "', "
        strUpdate = strUpdate & "Organizaciones.OrganizacionesName = '" & OrganizacionesName & "', "
        strUpdate = strUpdate & "Organizaciones.OrganizacionesDescription = '" & OrganizacionesDescription & "', "
        strUpdate = strUpdate & "Organizaciones.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Organizaciones.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Organizaciones.OrganizacionesId = " & OrganizacionesId
        Try
            OrganizacionesUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & OrganizacionesCodigo, OrganizacionesId, "Organizaciones", "")
        Catch
            OrganizacionesUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & OrganizacionesCodigo, OrganizacionesId, "Organizaciones", "")
        End Try
    End Function
    Public Function OrganizacionesInsert(ByRef OrganizacionesId As Long, ByRef OrganizacionesCodigo As String, ByRef OrganizacionesName As String, ByRef OrganizacionesDescription As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Organizaciones As New Organizaciones
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = OrganizacionesCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("OrganizacionesId", "OrganizacionesCodigo", "Organizaciones", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("OrganizacionesId", "OrganizacionesCodigo", "Organizaciones", MasterName, CLng(UserId), MasterId)
            End If
            OrganizacionesInsert = Organizaciones.OrganizacionesUpdate(MasterId, CStr(OrganizacionesCodigo), CStr(OrganizacionesName), CStr(OrganizacionesDescription), UserId)
        Catch
            OrganizacionesInsert = 0
        End Try
    End Function
    Public Function LeerOrganizacionesDescriptionByName(ByVal OrganizacionesCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select OrganizacionesName "
        sSQL = sSQL & "FROM (Organizaciones) "
        sSQL = sSQL & "WHERE (Organizaciones.OrganizacionesCodigo = '" & OrganizacionesCodigo & "') "
        LeerOrganizacionesDescriptionByName = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerOrganizacionesDescriptionByName = CStr(dtr("OrganizacionesName").ToString)
            End While
            dtr.Close()
        Catch
            LeerOrganizacionesDescriptionByName = ""
        End Try
    End Function
    Public Function LeerTotalOrganizacionesPorTablasRelacionadas(ByVal OrganizacionesCodigo As String, ByVal OrganizacionesId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en una Gerencia
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Organizaciones INNER JOIN Gerencias ON Organizaciones.OrganizacionesCodigo = Gerencias.OrganizacionesCodigo "
        sSQL = sSQL & "WHERE (((Organizaciones.OrganizacionesCodigo)='" & OrganizacionesCodigo & "'))"
        LeerTotalOrganizacionesPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalOrganizacionesPorTablasRelacionadas = LeerTotalOrganizacionesPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalOrganizacionesPorTablasRelacionadas = 0
        End Try
    End Function
    Public Function OrganizacionesDelete(ByVal OrganizacionesId As Long, ByVal OrganizacionesCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Organizaciones As New Organizaciones

        ' Lee la cantidad de veces que la organización es usada en la tabla de Gerencias
        '------------------------------------------
        Total = Organizaciones.LeerTotalOrganizacionesPorTablasRelacionadas(OrganizacionesCodigo, OrganizacionesId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados a la Organización " & OrganizacionesCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie el Indicador en las Acciones y KPI levantados en las tareas, antes de eliminarlo de la lista"
            OrganizacionesDelete = False
        Else
            Try
                ' Borra registro de la tabla de Organizaciones
                '-------------------------------------
                strUpdate = "DELETE FROM Organizaciones WHERE OrganizacionesId = " & OrganizacionesId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina la organización: " & OrganizacionesCodigo, OrganizacionesId, "Organizaciones", "")
                OrganizacionesDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la Organización: " & OrganizacionesCodigo, OrganizacionesId, "Organizaciones", "")
                OrganizacionesDelete = False
            End Try
        End If
    End Function
End Class
