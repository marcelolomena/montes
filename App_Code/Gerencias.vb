'------------------------------------------------------------
' Código generado por ZRISMART SF el 13-04-2011 17:47:04
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Gerencias
    Public Function LeerGerencias(ByVal GerenciasId As Long, ByRef GerenciasCodigo As String, ByRef GerenciasName As String, ByRef GerenciasDescription As String, ByRef UsuariosCodigo As String, ByRef GerenciasCargo As String, ByRef OrganizacionesCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select GerenciasCodigo, GerenciasName, GerenciasDescription, UsuariosCodigo, GerenciasCargo, OrganizacionesCodigo "
        sSQL = sSQL & "FROM (Gerencias) "
        sSQL = sSQL & "WHERE (Gerencias.GerenciasId = " & GerenciasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                GerenciasCodigo = CStr(dtr("GerenciasCodigo").ToString)
                GerenciasName = CStr(dtr("GerenciasName").ToString)
                GerenciasDescription = CStr(dtr("GerenciasDescription").ToString)
                UsuariosCodigo = CStr(dtr("UsuariosCodigo").ToString)
                GerenciasCargo = CStr(dtr("GerenciasCargo").ToString)
                OrganizacionesCodigo = CStr(dtr("OrganizacionesCodigo").ToString)
            End While
            LeerGerencias = True
            dtr.Close()
        Catch
            LeerGerencias = False
        End Try
    End Function
    Public Function LeerGerenciasByName(ByRef GerenciasId As Long, ByVal GerenciasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select GerenciasId "
        sSQL = sSQL & "FROM (Gerencias) "
        sSQL = sSQL & "WHERE (Gerencias.GerenciasCodigo = '" & GerenciasCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                GerenciasId = CLng(dtr("GerenciasId").ToString)
            End While
            LeerGerenciasByName = True
            dtr.Close()
        Catch
            LeerGerenciasByName = False
        End Try
    End Function
    Public Function GerenciasUpdate(ByVal GerenciasId As Long, ByRef GerenciasCodigo As String, ByRef GerenciasName As String, ByRef GerenciasDescription As String, ByRef UsuariosCodigo As String, ByRef GerenciasCargo As String, ByRef OrganizacionesCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Gerencias SET "
        strUpdate = strUpdate & "Gerencias.GerenciasCodigo = '" & GerenciasCodigo & "', "
        strUpdate = strUpdate & "Gerencias.GerenciasName = '" & GerenciasName & "', "
        strUpdate = strUpdate & "Gerencias.GerenciasDescription = '" & GerenciasDescription & "', "
        strUpdate = strUpdate & "Gerencias.UsuariosCodigo = '" & UsuariosCodigo & "', "
        strUpdate = strUpdate & "Gerencias.GerenciasCargo = '" & GerenciasCargo & "', "
        strUpdate = strUpdate & "Gerencias.OrganizacionesCodigo = '" & OrganizacionesCodigo & "', "
        strUpdate = strUpdate & "Gerencias.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Gerencias.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Gerencias.GerenciasId = " & GerenciasId
        Try
            GerenciasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & GerenciasCodigo, GerenciasId, "Gerencias", "")
        Catch
            GerenciasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & GerenciasCodigo, GerenciasId, "Gerencias", "")
        End Try
    End Function
    Public Function GerenciasInsert(ByRef GerenciasId As Long, ByRef GerenciasCodigo As String, ByRef GerenciasName As String, ByRef GerenciasDescription As String, ByRef UsuariosCodigo As String, ByRef GerenciasCargo As String, ByRef OrganizacionesCodigo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Gerencias As New Gerencias
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = GerenciasCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("GerenciasId", "GerenciasCodigo", "Gerencias", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("GerenciasId", "GerenciasCodigo", "Gerencias", MasterName, CLng(UserId), MasterId)
            End If
            GerenciasInsert = Gerencias.GerenciasUpdate(MasterId, CStr(GerenciasCodigo), CStr(GerenciasName), CStr(GerenciasDescription), CStr(UsuariosCodigo), CStr(GerenciasCargo), CStr(OrganizacionesCodigo), UserId)
        Catch
            GerenciasInsert = 0
        End Try
    End Function
    Public Function LeerGerenciasDescriptionByName(ByVal GerenciasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select GerenciasName "
        sSQL = sSQL & "FROM (Gerencias) "
        sSQL = sSQL & "WHERE (Gerencias.GerenciasCodigo = '" & GerenciasCodigo & "') "
        LeerGerenciasDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerGerenciasDescriptionByName = CStr(dtr("GerenciasName").ToString)
            End While
            dtr.Close()
        Catch
            LeerGerenciasDescriptionByName = ""
        End Try
    End Function
    Public Function LeerUsuarioResponsable(ByVal GerenciasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select UsuariosCodigo "
        sSQL = sSQL & "FROM (Gerencias) "
        sSQL = sSQL & "WHERE (Gerencias.GerenciasCodigo = '" & GerenciasCodigo & "') "
        LeerUsuarioResponsable = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerUsuarioResponsable = CStr(dtr("UsuariosCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerUsuarioResponsable = ""
        End Try
    End Function
    Public Function LeerTotalGerenciasPorTablasRelacionadas(ByVal GerenciasCodigo As String, ByVal GerenciasId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en un Area
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Gerencias INNER JOIN Areas ON Gerencias.GerenciasCodigo = Areas.GerenciasCodigo "
        sSQL = sSQL & "WHERE (((Gerencias.GerenciasCodigo)='" & GerenciasCodigo & "'))"
        LeerTotalGerenciasPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalGerenciasPorTablasRelacionadas = LeerTotalGerenciasPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalGerenciasPorTablasRelacionadas = 0
        End Try
    End Function
    Public Function GerenciasDelete(ByVal GerenciasId As Long, ByVal GerenciasCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Gerencias As New Gerencias

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Gerencias.LeerTotalGerenciasPorTablasRelacionadas(GerenciasCodigo, GerenciasId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados a la Gerencia " & GerenciasCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie la Gerencia en los Programas, Acciones, Cargos o Proyectos, antes de eliminarla de la lista"
            GerenciasDelete = False
        Else
            Try
                ' Borra registro de la tabla de Gerencias
                '-------------------------------------
                strUpdate = "DELETE FROM Gerencias WHERE GerenciasId = " & GerenciasId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina la Gerencia: " & GerenciasCodigo, GerenciasId, "Gerencias", "")
                GerenciasDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la Gerencia: " & GerenciasCodigo, GerenciasId, "Gerencias", "")
                GerenciasDelete = False
            End Try
        End If
    End Function
End Class
