'------------------------------------------------------------
' Código generado por ZRISMART SF el 23-08-2011 23:10:48
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Grupos
    Public Function LeerGrupos(ByVal GruposId As Long, ByRef GruposCodigo As String, ByRef GruposName As String, ByRef GruposDescription As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select GruposCodigo, GruposName, GruposDescription "
        sSQL = sSQL & "FROM (Grupos) "
        sSQL = sSQL & "WHERE (Grupos.GruposId = " & GruposId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                GruposCodigo = CStr(dtr("GruposCodigo").ToString)
                GruposName = CStr(dtr("GruposName").ToString)
                GruposDescription = CStr(dtr("GruposDescription").ToString)
            End While
            LeerGrupos = True
            dtr.Close()
        Catch
            LeerGrupos = False
        End Try
    End Function
    Public Function LeerGruposByName(ByRef GruposId As Long, ByVal GruposCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select GruposId "
        sSQL = sSQL & "FROM (Grupos) "
        sSQL = sSQL & "WHERE (Grupos.GruposCodigo = '" & GruposCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                GruposId = CLng(dtr("GruposId").ToString)
            End While
            LeerGruposByName = True
            dtr.Close()
        Catch
            LeerGruposByName = False
        End Try
    End Function
    Public Function LeerGruposDescriptionByName(ByVal GruposCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select GruposName "
        sSQL = sSQL & "FROM (Grupos) "
        sSQL = sSQL & "WHERE (Grupos.GruposCodigo = '" & GruposCodigo & "') "
        LeerGruposDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerGruposDescriptionByName = CStr(dtr("GruposName").ToString)
            End While
            dtr.Close()
        Catch
            LeerGruposDescriptionByName = ""
        End Try
    End Function
    Public Function GruposUpdate(ByVal GruposId As Long, ByRef GruposCodigo As String, ByRef GruposName As String, ByRef GruposDescription As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Grupos SET "
        strUpdate = strUpdate & "Grupos.GruposCodigo = '" & GruposCodigo & "', "
        strUpdate = strUpdate & "Grupos.GruposName = '" & GruposName & "', "
        strUpdate = strUpdate & "Grupos.GruposDescription = '" & GruposDescription & "', "
        strUpdate = strUpdate & "Grupos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Grupos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Grupos.GruposId = " & GruposId
        Try
            GruposUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & GruposCodigo, GruposId, "Grupos", "")
        Catch
            GruposUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & GruposCodigo, GruposId, "Grupos", "")
        End Try
    End Function
    Public Function GruposInsert(ByRef GruposId As Long, ByRef GruposCodigo As String, ByRef GruposName As String, ByRef GruposDescription As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Grupos As New Grupos
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = GruposCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("GruposId", "GruposCodigo", "Grupos", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("GruposId", "GruposCodigo", "Grupos", MasterName, CLng(UserId), MasterId)
            End If
            GruposInsert = Grupos.GruposUpdate(MasterId, CStr(GruposCodigo), CStr(GruposName), CStr(GruposDescription), UserId)
        Catch
            GruposInsert = 0
        End Try
    End Function
    Public Function LeerTotalGruposPorTablasRelacionadas(ByVal GruposCodigo As String, ByVal GruposId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en una Iniciativa
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Grupos INNER JOIN SubGrupos ON Grupos.GruposCodigo = SubGrupos.GruposCodigo "
        sSQL = sSQL & "WHERE (((Grupos.GruposCodigo)='" & GruposCodigo & "'))"
        LeerTotalGruposPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalGruposPorTablasRelacionadas = LeerTotalGruposPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalGruposPorTablasRelacionadas = 0
        End Try
    End Function
    Public Function GruposDelete(ByVal GruposId As Long, ByVal GruposCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Grupos As New Grupos

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Grupos.LeerTotalGruposPorTablasRelacionadas(GruposCodigo, GruposId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados al Grupo " & GruposCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie el Grupos en los Sub Grupos, antes de eliminarla de la lista"
            GruposDelete = False
        Else
            Try
                ' Borra registro de la tabla de Grupos
                '-------------------------------------
                strUpdate = "DELETE FROM Grupos WHERE GruposId = " & GruposId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Grupo: " & GruposCodigo, GruposId, "Grupos", "")
                GruposDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Grupo: " & GruposCodigo, GruposId, "Grupos", "")
                GruposDelete = False
            End Try
        End If
    End Function
End Class
