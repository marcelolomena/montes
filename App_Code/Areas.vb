'------------------------------------------------------------
' Código generado por ZRISMART SF el 25-01-2011 9:00:05
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Areas
    Public Function LeerAreas(ByVal AreasId As Long, ByRef AreasName As String, ByRef AreasDescription As String, ByRef UsuariosCodigo As String, ByRef AreasCargo As String, ByRef GerenciasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AreasName, AreasDescription, UsuariosCodigo, AreasCargo, GerenciasCodigo "
        sSQL = sSQL & "FROM Areas "
        sSQL = sSQL & "WHERE (Areas.AreasId = " & AreasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                AreasName = CStr(dtr("AreasName").ToString)
                AreasDescription = CStr(dtr("AreasDescription").ToString)
                UsuariosCodigo = CStr(dtr("UsuariosCodigo").ToString)
                AreasCargo = CStr(dtr("AreasCargo").ToString)
                GerenciasCodigo = CStr(dtr("GerenciasCodigo").ToString)
            End While
            LeerAreas = True
            dtr.Close()
        Catch
            LeerAreas = False
        End Try
    End Function
    Public Function LeerAreasByName(ByRef AreasId As Long, ByVal AreasName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AreasId "
        sSQL = sSQL & "FROM Areas "
        sSQL = sSQL & "WHERE (Areas.AreasName = '" & AreasName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                AreasId = CLng(dtr("AreasId").ToString)
            End While
            LeerAreasByName = True
            dtr.Close()
        Catch
            LeerAreasByName = False
        End Try
    End Function
    Public Function LeerAreasDescriptionByName(ByVal AreasName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        LeerAreasDescriptionByName = " "
        sSQL = "Select AreasDescription "
        sSQL = sSQL & "FROM Areas "
        sSQL = sSQL & "WHERE (Areas.AreasName = '" & AreasName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerAreasDescriptionByName = CStr(dtr("AreasDescription").ToString)
            End While
            dtr.Close()
        Catch
            LeerAreasDescriptionByName = " "
        End Try
    End Function
    Public Function AreasUpdate(ByVal AreasId As Long, ByRef AreasName As String, ByRef AreasDescription As String, ByRef UsuariosCodigo As String, ByRef AreasCargo As String, ByRef GerenciasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Areas SET "
        strUpdate = strUpdate & "Areas.AreasName = '" & AreasName & "', "
        strUpdate = strUpdate & "Areas.AreasDescription = '" & AreasDescription & "', "
        strUpdate = strUpdate & "Areas.UsuariosCodigo = '" & UsuariosCodigo & "', "
        strUpdate = strUpdate & "Areas.AreasCargo = '" & AreasCargo & "', "
        strUpdate = strUpdate & "Areas.GerenciasCodigo = '" & GerenciasCodigo & "', "
        strUpdate = strUpdate & "Areas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Areas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Areas.AreasId = " & AreasId
        Try
            AreasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & AreasName, AreasId, "Areas", "")
        Catch
            AreasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & AreasName, AreasId, "Areas", "")
        End Try
    End Function
    Public Function AreasInsert(ByRef AreasId As Long, ByRef AreasName As String, ByRef AreasDescription As String, ByRef UsuariosCodigo As String, ByRef AreasCargo As String, ByRef GerenciasCodigo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Areas As New Areas
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = AreasName
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("AreasId", "AreasName", "Areas", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("AreasId", "AreasName", "Areas", MasterName, CLng(UserId), MasterId)
            End If
            AreasInsert = Areas.AreasUpdate(MasterId, CStr(AreasName), CStr(AreasDescription), CStr(UsuariosCodigo), CStr(AreasCargo), CStr(GerenciasCodigo), UserId)
        Catch
            AreasInsert = 0
        End Try
    End Function
    Public Function LeerTotalAreasPorDocumentos(ByVal AreasName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        ' Verificamos si el área esta referenciada en algún documento
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Areas INNER JOIN DocumentosSGI ON Areas.AreasName = DocumentosSGI.DocumentosSGIArea "
        sSQL = sSQL & "WHERE (((Areas.AreasName)='" & AreasName & "'))"
        LeerTotalAreasPorDocumentos = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalAreasPorDocumentos = LeerTotalAreasPorDocumentos + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalAreasPorDocumentos = 0
        End Try
        ' Verificamos si el área esta referenciada en algún cargo
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Areas INNER JOIN Cargos ON Areas.AreasName = Cargos.AreasName "
        sSQL = sSQL & "WHERE (((Areas.AreasName)='" & AreasName & "'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalAreasPorDocumentos = LeerTotalAreasPorDocumentos + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalAreasPorDocumentos = LeerTotalAreasPorDocumentos + 0
        End Try
    End Function
    Public Function AreasDelete(ByVal AreasId As Long, ByVal AreasName As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Areas As New Areas

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Areas.LeerTotalAreasPorDocumentos(AreasName)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " documentos asociados al Area " & AreasName & vbCrLf
            Mensaje = Mensaje & "Cambia el Area a los documentos, antes de eliminarla de la lista"
            AreasDelete = False
        Else
            Try
                ' Borra registro de la tabla de Roles
                '-------------------------------------
                strUpdate = "DELETE FROM Areas WHERE AreasId = " & AreasId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Area: " & AreasName, AreasId, "Areas", "")
                AreasDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Area: " & AreasName, AreasId, "Areas", "")
                AreasDelete = False
            End Try
        End If
    End Function
End Class
