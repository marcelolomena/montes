'------------------------------------------------------------
' Código generado por ZRISMART SF el 24-08-2011 12:42:40
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class StakeholdersTipo
    Public Function LeerStakeholdersTipo(ByVal StakeholdersTipoId As Long, ByRef StakeholdersTipoName As String, ByRef StakeholdersTipoDescription As String, ByRef StakeholdersIsIndividuo As Boolean) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersTipoName, StakeholdersTipoDescription, StakeholdersIsIndividuo "
        sSQL = sSQL & "FROM (StakeholdersTipo) "
        sSQL = sSQL & "WHERE (StakeholdersTipo.StakeholdersTipoId = " & StakeholdersTipoId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                StakeholdersTipoName = CStr(dtr("StakeholdersTipoName").ToString)
                StakeholdersTipoDescription = CStr(dtr("StakeholdersTipoDescription").ToString)
                StakeholdersIsIndividuo = CBool(dtr("StakeholdersIsIndividuo").ToString)
            End While
            LeerStakeholdersTipo = True
            dtr.Close()
        Catch
            LeerStakeholdersTipo = False
        End Try
    End Function
    Public Function LeerStakeholdersTipoByName(ByRef StakeholdersTipoId As Long, ByVal StakeholdersTipoName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersTipoId "
        sSQL = sSQL & "FROM (StakeholdersTipo) "
        sSQL = sSQL & "WHERE (StakeholdersTipo.StakeholdersTipoName = '" & StakeholdersTipoName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                StakeholdersTipoId = CLng(dtr("StakeholdersTipoId").ToString)
            End While
            LeerStakeholdersTipoByName = True
            dtr.Close()
        Catch
            LeerStakeholdersTipoByName = False
        End Try
    End Function
    Public Function LeerStakeholdersTipoDescriptionByName(ByVal StakeholdersTipoName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        LeerStakeholdersTipoDescriptionByName = " "
        sSQL = "Select StakeholdersTipoDescription "
        sSQL = sSQL & "FROM (StakeholdersTipo) "
        sSQL = sSQL & "WHERE (StakeholdersTipo.StakeholdersTipoName = '" & StakeholdersTipoName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerStakeholdersTipoDescriptionByName = CStr(dtr("StakeholdersTipoDescription").ToString)
            End While
            dtr.Close()
        Catch
            LeerStakeholdersTipoDescriptionByName = " "
        End Try
    End Function
    Public Function StakeholdersTipoUpdate(ByVal StakeholdersTipoId As Long, ByRef StakeholdersTipoName As String, ByRef StakeholdersTipoDescription As String, ByRef StakeholdersIsIndividuo As Boolean, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE StakeholdersTipo SET "
        strUpdate = strUpdate & "StakeholdersTipo.StakeholdersTipoName = '" & StakeholdersTipoName & "', "
        strUpdate = strUpdate & "StakeholdersTipo.StakeholdersTipoDescription = '" & StakeholdersTipoDescription & "', "
        strUpdate = strUpdate & "StakeholdersTipo.StakeholdersIsIndividuo = " & StakeholdersIsIndividuo & ", "
        strUpdate = strUpdate & "StakeholdersTipo.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "StakeholdersTipo.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE StakeholdersTipo.StakeholdersTipoId = " & StakeholdersTipoId
        Try
            StakeholdersTipoUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & StakeholdersTipoName, StakeholdersTipoId, "StakeholdersTipo", "")
        Catch
            StakeholdersTipoUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & StakeholdersTipoName, StakeholdersTipoId, "StakeholdersTipo", "")
        End Try
    End Function
    Public Function StakeholdersTipoInsert(ByRef StakeholdersTipoId As Long, ByRef StakeholdersTipoName As String, ByRef StakeholdersTipoDescription As String, ByRef StakeholdersIsIndividuo As Boolean, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim StakeholdersTipo As New StakeholdersTipo
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = StakeholdersTipoName
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("StakeholdersTipoId", "StakeholdersTipoName", "StakeholdersTipo", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("StakeholdersTipoId", "StakeholdersTipoName", "StakeholdersTipo", MasterName, CLng(UserId), MasterId)
            End If
            StakeholdersTipoInsert = StakeholdersTipo.StakeholdersTipoUpdate(MasterId, CStr(StakeholdersTipoName), CStr(StakeholdersTipoDescription), CBool(StakeholdersIsIndividuo), UserId)
        Catch
            StakeholdersTipoInsert = 0
        End Try
    End Function
    Public Function LeerTotalStakeholdersTipoPorDocumentos(ByVal StakeholdersTipoName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        ' Verificamos si el área esta referenciada en algún documento
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM StakeholdersTipo INNER JOIN Stakeholders ON StakeholdersTipo.StakeholdersTipoName = Stakeholders.StakeholdersTipoName "
        sSQL = sSQL & "WHERE (((StakeholdersTipo.StakeholdersTipoName)='" & StakeholdersTipoName & "'))"
        LeerTotalStakeholdersTipoPorDocumentos = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalStakeholdersTipoPorDocumentos = LeerTotalStakeholdersTipoPorDocumentos + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalStakeholdersTipoPorDocumentos = 0
        End Try
    End Function
    Public Function StakeholdersTipoDelete(ByVal StakeholdersTipoId As Long, ByVal StakeholdersTipoName As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim StakeholdersTipo As New StakeholdersTipo

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = StakeholdersTipo.LeerTotalStakeholdersTipoPorDocumentos(StakeholdersTipoName)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " stakeholders asociados al tipo " & StakeholdersTipoName & vbCrLf
            Mensaje = Mensaje & "Cambia el tipo a los stakeholders, antes de eliminarlo de la lista"
            StakeholdersTipoDelete = False
        Else
            Try
                ' Borra registro de la tabla de Roles
                '-------------------------------------
                strUpdate = "DELETE FROM StakeholdersTipo WHERE StakeholdersTipoId = " & StakeholdersTipoId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Tipo de Stakeholder: " & StakeholdersTipoName, StakeholdersTipoId, "StakeholdersTipo", "")
                StakeholdersTipoDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Tipo de Stakeholder: " & StakeholdersTipoName, StakeholdersTipoId, "StakeholdersTipo", "")
                StakeholdersTipoDelete = False
            End Try
        End If
    End Function
End Class
