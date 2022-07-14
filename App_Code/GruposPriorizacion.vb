'------------------------------------------------------------
' Código generado por ZRISMART SF el 01-09-2011 23:14:08
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class GruposPriorizacion
    Public Function LeerGruposPriorizacion(ByVal GruposPriorizacionId As Long, ByRef GruposPriorizacionCodigo As String, ByRef GruposPriorizacionDescription As String, ByRef GruposPriorizacionSecuencia As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select GruposPriorizacionCodigo, GruposPriorizacionDescription, GruposPriorizacionSecuencia "
        sSQL = sSQL & "FROM (GruposPriorizacion) "
        sSQL = sSQL & "WHERE (GruposPriorizacion.GruposPriorizacionId = " & GruposPriorizacionId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                GruposPriorizacionCodigo = CStr(dtr("GruposPriorizacionCodigo").ToString)
                GruposPriorizacionDescription = CStr(dtr("GruposPriorizacionDescription").ToString)
                If Len(dtr("GruposPriorizacionSecuencia").ToString) = 0 Then
                    GruposPriorizacionSecuencia = 0
                Else
                    GruposPriorizacionSecuencia = CLng(dtr("GruposPriorizacionSecuencia").ToString)
                End If
            End While
            LeerGruposPriorizacion = True
            dtr.Close()
        Catch
            LeerGruposPriorizacion = False
        End Try
    End Function
    Public Function LeerGruposPriorizacionByName(ByRef GruposPriorizacionId As Long, ByVal GruposPriorizacionCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select GruposPriorizacionId "
        sSQL = sSQL & "FROM (GruposPriorizacion) "
        sSQL = sSQL & "WHERE (GruposPriorizacion.GruposPriorizacionCodigo = '" & GruposPriorizacionCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                GruposPriorizacionId = CLng(dtr("GruposPriorizacionId").ToString)
            End While
            LeerGruposPriorizacionByName = True
            dtr.Close()
        Catch
            LeerGruposPriorizacionByName = False
        End Try
    End Function
    Public Function LeerGruposPriorizacionDescriptionByName(ByVal GruposPriorizacionCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select GruposPriorizacionName "
        sSQL = sSQL & "FROM (GruposPriorizacion) "
        sSQL = sSQL & "WHERE (GruposPriorizacion.GruposPriorizacionCodigo = '" & GruposPriorizacionCodigo & "') "
        LeerGruposPriorizacionDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerGruposPriorizacionDescriptionByName = CStr(dtr("GruposPriorizacionName").ToString)
            End While
            dtr.Close()
        Catch
            LeerGruposPriorizacionDescriptionByName = ""
        End Try
    End Function
    Public Function GruposPriorizacionUpdate(ByVal GruposPriorizacionId As Long, ByRef GruposPriorizacionCodigo As String, ByRef GruposPriorizacionDescription As String, ByRef GruposPriorizacionSecuencia As Long, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE GruposPriorizacion SET "
        strUpdate = strUpdate & "GruposPriorizacion.GruposPriorizacionCodigo = '" & GruposPriorizacionCodigo & "', "
        strUpdate = strUpdate & "GruposPriorizacion.GruposPriorizacionDescription = '" & GruposPriorizacionDescription & "', "
        strUpdate = strUpdate & "GruposPriorizacion.GruposPriorizacionSecuencia = " & GruposPriorizacionSecuencia & ", "
        strUpdate = strUpdate & "GruposPriorizacion.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "GruposPriorizacion.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE GruposPriorizacion.GruposPriorizacionId = " & GruposPriorizacionId
        Try
            GruposPriorizacionUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & GruposPriorizacionCodigo, GruposPriorizacionId, "GruposPriorizacion", "")
        Catch
            GruposPriorizacionUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & GruposPriorizacionCodigo, GruposPriorizacionId, "GruposPriorizacion", "")
        End Try
    End Function
    Public Function GruposPriorizacionInsert(ByRef GruposPriorizacionId As Long, ByRef GruposPriorizacionCodigo As String, ByRef GruposPriorizacionDescription As String, ByRef GruposPriorizacionSecuencia As Long, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim GruposPriorizacion As New GruposPriorizacion
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = GruposPriorizacionCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("GruposPriorizacionId", "GruposPriorizacionCodigo", "GruposPriorizacion", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("GruposPriorizacionId", "GruposPriorizacionCodigo", "GruposPriorizacion", MasterName, CLng(UserId), MasterId)
            End If
            GruposPriorizacionInsert = GruposPriorizacion.GruposPriorizacionUpdate(MasterId, CStr(GruposPriorizacionCodigo), CStr(GruposPriorizacionDescription), CLng(GruposPriorizacionSecuencia), UserId)
        Catch
            GruposPriorizacionInsert = 0
        End Try
    End Function
    Public Function LeerTotalGruposPriorizacionPorTablasRelacionadas(ByVal GruposPriorizacionCodigo As String, ByVal GruposPriorizacionId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en una Iniciativa
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM GruposPriorizacion INNER JOIN SubGruposPriorizacion ON GruposPriorizacion.GruposPriorizacionCodigo = SubGruposPriorizacion.GruposPriorizacionCodigo "
        sSQL = sSQL & "WHERE (((GruposPriorizacion.GruposPriorizacionCodigo)='" & GruposPriorizacionCodigo & "'))"
        LeerTotalGruposPriorizacionPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalGruposPriorizacionPorTablasRelacionadas = LeerTotalGruposPriorizacionPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalGruposPriorizacionPorTablasRelacionadas = 0
        End Try
    End Function
    Public Function GruposPriorizacionDelete(ByVal GruposPriorizacionId As Long, ByVal GruposPriorizacionCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim GruposPriorizacion As New GruposPriorizacion

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = GruposPriorizacion.LeerTotalGruposPriorizacionPorTablasRelacionadas(GruposPriorizacionCodigo, GruposPriorizacionId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados al Grupo " & GruposPriorizacionCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie el Grupos en los Sub Grupos, antes de eliminarla de la lista"
            GruposPriorizacionDelete = False
        Else
            Try
                ' Borra registro de la tabla de Grupos
                '-------------------------------------
                strUpdate = "DELETE FROM GruposPriorizacion WHERE GruposPriorizacionId = " & GruposPriorizacionId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Grupo: " & GruposPriorizacionCodigo, GruposPriorizacionId, "GruposPriorizacion", "")
                GruposPriorizacionDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Grupo: " & GruposPriorizacionCodigo, GruposPriorizacionId, "GruposPriorizacion", "")
                GruposPriorizacionDelete = False
            End Try
        End If
    End Function
End Class
