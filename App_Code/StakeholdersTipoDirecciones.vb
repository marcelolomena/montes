'------------------------------------------------------------
' Código generado por ZRISMART SF el 24-08-2011 19:01:38
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class StakeholdersTipoDirecciones
    Public Function LeerStakeholdersTipoDirecciones(ByVal StakeholdersTipoDireccionesId As Long, ByRef StakeholdersTipoDireccionesName As String, ByRef StakeholdersTipoDireccionesDescription As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersTipoDireccionesName, StakeholdersTipoDireccionesDescription "
        sSQL = sSQL & "FROM (StakeholdersTipoDirecciones) "
        sSQL = sSQL & "WHERE (StakeholdersTipoDirecciones.StakeholdersTipoDireccionesId = " & StakeholdersTipoDireccionesId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                StakeholdersTipoDireccionesName = CStr(dtr("StakeholdersTipoDireccionesName").ToString)
                StakeholdersTipoDireccionesDescription = CStr(dtr("StakeholdersTipoDireccionesDescription").ToString)
            End While
            LeerStakeholdersTipoDirecciones = True
            dtr.Close()
        Catch
            LeerStakeholdersTipoDirecciones = False
        End Try
    End Function
    Public Function LeerStakeholdersTipoDireccionesByName(ByRef StakeholdersTipoDireccionesId As Long, ByVal StakeholdersTipoDireccionesName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersTipoDireccionesId "
        sSQL = sSQL & "FROM (StakeholdersTipoDirecciones) "
        sSQL = sSQL & "WHERE (StakeholdersTipoDirecciones.StakeholdersTipoDireccionesName = '" & StakeholdersTipoDireccionesName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                StakeholdersTipoDireccionesId = CLng(dtr("StakeholdersTipoDireccionesId").ToString)
            End While
            LeerStakeholdersTipoDireccionesByName = True
            dtr.Close()
        Catch
            LeerStakeholdersTipoDireccionesByName = False
        End Try
    End Function
    Public Function LeerStakeholdersTipoDireccionesDescriptionByName(ByVal StakeholdersTipoDireccionesName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        LeerStakeholdersTipoDireccionesDescriptionByName = " "
        sSQL = "Select StakeholdersTipoDireccionesDescription "
        sSQL = sSQL & "FROM (StakeholdersTipoDirecciones) "
        sSQL = sSQL & "WHERE (StakeholdersTipoDirecciones.StakeholdersTipoDireccionesName = '" & StakeholdersTipoDireccionesName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerStakeholdersTipoDireccionesDescriptionByName = CStr(dtr("StakeholdersTipoDireccionesDescription").ToString)
            End While
            dtr.Close()
        Catch
            LeerStakeholdersTipoDireccionesDescriptionByName = " "
        End Try
    End Function
    Public Function StakeholdersTipoDireccionesUpdate(ByVal StakeholdersTipoDireccionesId As Long, ByRef StakeholdersTipoDireccionesName As String, ByRef StakeholdersTipoDireccionesDescription As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE StakeholdersTipoDirecciones SET "
        strUpdate = strUpdate & "StakeholdersTipoDirecciones.StakeholdersTipoDireccionesName = '" & StakeholdersTipoDireccionesName & "', "
        strUpdate = strUpdate & "StakeholdersTipoDirecciones.StakeholdersTipoDireccionesDescription = '" & StakeholdersTipoDireccionesDescription & "', "
        strUpdate = strUpdate & "StakeholdersTipoDirecciones.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "StakeholdersTipoDirecciones.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE StakeholdersTipoDirecciones.StakeholdersTipoDireccionesId = " & StakeholdersTipoDireccionesId
        Try
            StakeholdersTipoDireccionesUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & StakeholdersTipoDireccionesName, StakeholdersTipoDireccionesId, "StakeholdersTipoDirecciones", "")
        Catch
            StakeholdersTipoDireccionesUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & StakeholdersTipoDireccionesName, StakeholdersTipoDireccionesId, "StakeholdersTipoDirecciones", "")
        End Try
    End Function
    Public Function StakeholdersTipoDireccionesInsert(ByRef StakeholdersTipoDireccionesId As Long, ByRef StakeholdersTipoDireccionesName As String, ByRef StakeholdersTipoDireccionesDescription As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim StakeholdersTipoDirecciones As New StakeholdersTipoDirecciones
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = StakeholdersTipoDireccionesName
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("StakeholdersTipoDireccionesId", "StakeholdersTipoDireccionesName", "StakeholdersTipoDirecciones", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("StakeholdersTipoDireccionesId", "StakeholdersTipoDireccionesName", "StakeholdersTipoDirecciones", MasterName, CLng(UserId), MasterId)
            End If
            StakeholdersTipoDireccionesInsert = StakeholdersTipoDirecciones.StakeholdersTipoDireccionesUpdate(MasterId, CStr(StakeholdersTipoDireccionesName), CStr(StakeholdersTipoDireccionesDescription), UserId)
        Catch
            StakeholdersTipoDireccionesInsert = 0
        End Try
    End Function
    Public Function LeerTotalStakeholdersTipoDireccionesPorDocumentos(ByVal StakeholdersTipoDireccionesName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        ' Verificamos si el área esta referenciada en algún documento
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM StakeholdersTipoDirecciones INNER JOIN StakeholdersDirecciones ON StakeholdersTipoDirecciones.StakeholdersTipoDireccionesName = StakeholdersDirecciones.StakeholdersTipoDireccionesName "
        sSQL = sSQL & "WHERE (((StakeholdersTipoDirecciones.StakeholdersTipoDireccionesName)='" & StakeholdersTipoDireccionesName & "'))"
        LeerTotalStakeholdersTipoDireccionesPorDocumentos = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalStakeholdersTipoDireccionesPorDocumentos = LeerTotalStakeholdersTipoDireccionesPorDocumentos + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalStakeholdersTipoDireccionesPorDocumentos = 0
        End Try
    End Function
    Public Function StakeholdersTipoDireccionesDelete(ByVal StakeholdersTipoDireccionesId As Long, ByVal StakeholdersTipoDireccionesName As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim StakeholdersTipoDirecciones As New StakeholdersTipoDirecciones

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = StakeholdersTipoDirecciones.LeerTotalStakeholdersTipoDireccionesPorDocumentos(StakeholdersTipoDireccionesName)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " direcciones de contactos asociados al tipo de dirección " & StakeholdersTipoDireccionesName & vbCrLf
            Mensaje = Mensaje & "Cambia el tipo a las direcciones de los contactos, antes de eliminarlo de la lista"
            StakeholdersTipoDireccionesDelete = False
        Else
            Try
                ' Borra registro de la tabla de Roles
                '-------------------------------------
                strUpdate = "DELETE FROM StakeholdersTipoDirecciones WHERE StakeholdersTipoDireccionesId = " & StakeholdersTipoDireccionesId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Tipo de Dirección: " & StakeholdersTipoDireccionesName, StakeholdersTipoDireccionesId, "StakeholdersTipoDirecciones", "")
                StakeholdersTipoDireccionesDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Tipo de Dirección: " & StakeholdersTipoDireccionesName, StakeholdersTipoDireccionesId, "StakeholdersTipoDirecciones", "")
                StakeholdersTipoDireccionesDelete = False
            End Try
        End If
    End Function
End Class
