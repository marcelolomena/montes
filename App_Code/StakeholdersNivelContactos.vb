'------------------------------------------------------------
' Código generado por ZRISMART SF el 24-08-2011 19:04:42
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class StakeholdersNivelContactos
    Public Function LeerStakeholdersNivelContactos(ByVal StakeholdersNivelContactosId As Long, ByRef StakeholdersNivelContactosName As String, ByRef StakeholdersNivelContactosDescription As String, ByRef StakeholdersNivelContactosSecuencia As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersNivelContactosName, StakeholdersNivelContactosDescription, StakeholdersNivelContactosSecuencia "
        sSQL = sSQL & "FROM (StakeholdersNivelContactos) "
        sSQL = sSQL & "WHERE (StakeholdersNivelContactos.StakeholdersNivelContactosId = " & StakeholdersNivelContactosId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                StakeholdersNivelContactosName = CStr(dtr("StakeholdersNivelContactosName").ToString)
                StakeholdersNivelContactosDescription = CStr(dtr("StakeholdersNivelContactosDescription").ToString)
                If Len(dtr("StakeholdersNivelContactosSecuencia").ToString) = 0 Then
                    StakeholdersNivelContactosSecuencia = 0
                Else
                    StakeholdersNivelContactosSecuencia = CLng(dtr("StakeholdersNivelContactosSecuencia").ToString)
                End If
            End While
            LeerStakeholdersNivelContactos = True
            dtr.Close()
        Catch
            LeerStakeholdersNivelContactos = False
        End Try
    End Function
    Public Function LeerStakeholdersNivelContactosByName(ByRef StakeholdersNivelContactosId As Long, ByVal StakeholdersNivelContactosName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersNivelContactosId "
        sSQL = sSQL & "FROM (StakeholdersNivelContactos) "
        sSQL = sSQL & "WHERE (StakeholdersNivelContactos.StakeholdersNivelContactosName = '" & StakeholdersNivelContactosName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                StakeholdersNivelContactosId = CLng(dtr("StakeholdersNivelContactosId").ToString)
            End While
            LeerStakeholdersNivelContactosByName = True
            dtr.Close()
        Catch
            LeerStakeholdersNivelContactosByName = False
        End Try
    End Function
    Public Function LeerStakeholdersNivelContactosDescriptionByName(ByVal StakeholdersNivelContactosName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        LeerStakeholdersNivelContactosDescriptionByName = " "
        sSQL = "Select StakeholdersNivelContactosDescription "
        sSQL = sSQL & "FROM (StakeholdersNivelContactos) "
        sSQL = sSQL & "WHERE (StakeholdersNivelContactos.StakeholdersNivelContactosName = '" & StakeholdersNivelContactosName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerStakeholdersNivelContactosDescriptionByName = CStr(dtr("StakeholdersNivelContactosDescription").ToString)
            End While
            dtr.Close()
        Catch
            LeerStakeholdersNivelContactosDescriptionByName = " "
        End Try
    End Function
    Public Function StakeholdersNivelContactosUpdate(ByVal StakeholdersNivelContactosId As Long, ByRef StakeholdersNivelContactosName As String, ByRef StakeholdersNivelContactosDescription As String, ByRef StakeholdersNivelContactosSecuencia As Long, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE StakeholdersNivelContactos SET "
        strUpdate = strUpdate & "StakeholdersNivelContactos.StakeholdersNivelContactosName = '" & StakeholdersNivelContactosName & "', "
        strUpdate = strUpdate & "StakeholdersNivelContactos.StakeholdersNivelContactosDescription = '" & StakeholdersNivelContactosDescription & "', "
        strUpdate = strUpdate & "StakeholdersNivelContactos.StakeholdersNivelContactosSecuencia = " & StakeholdersNivelContactosSecuencia & ", "
        strUpdate = strUpdate & "StakeholdersNivelContactos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "StakeholdersNivelContactos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE StakeholdersNivelContactos.StakeholdersNivelContactosId = " & StakeholdersNivelContactosId
        Try
            StakeholdersNivelContactosUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & StakeholdersNivelContactosName, StakeholdersNivelContactosId, "StakeholdersNivelContactos", "")
        Catch
            StakeholdersNivelContactosUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & StakeholdersNivelContactosName, StakeholdersNivelContactosId, "StakeholdersNivelContactos", "")
        End Try
    End Function
    Public Function StakeholdersNivelContactosInsert(ByRef StakeholdersNivelContactosId As Long, ByRef StakeholdersNivelContactosName As String, ByRef StakeholdersNivelContactosDescription As String, ByRef StakeholdersNivelContactosSecuencia As Long, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim StakeholdersNivelContactos As New StakeholdersNivelContactos
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = StakeholdersNivelContactosName
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("StakeholdersNivelContactosId", "StakeholdersNivelContactosName", "StakeholdersNivelContactos", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("StakeholdersNivelContactosId", "StakeholdersNivelContactosName", "StakeholdersNivelContactos", MasterName, CLng(UserId), MasterId)
            End If
            StakeholdersNivelContactosInsert = StakeholdersNivelContactos.StakeholdersNivelContactosUpdate(MasterId, CStr(StakeholdersNivelContactosName), CStr(StakeholdersNivelContactosDescription), CLng(StakeholdersNivelContactosSecuencia), UserId)
        Catch
            StakeholdersNivelContactosInsert = 0
        End Try
    End Function
    Public Function LeerTotalStakeholdersNivelContactosPorDocumentos(ByVal StakeholdersNivelContactosName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        ' Verificamos si el área esta referenciada en algún documento
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM StakeholdersNivelContactos INNER JOIN StakeholdersContactos ON StakeholdersNivelContactos.StakeholdersNivelContactosName = StakeholdersContactos.StakeholdersNivelContactosName "
        sSQL = sSQL & "WHERE (((StakeholdersNivelContactos.StakeholdersNivelContactosName)='" & StakeholdersNivelContactosName & "'))"
        LeerTotalStakeholdersNivelContactosPorDocumentos = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalStakeholdersNivelContactosPorDocumentos = LeerTotalStakeholdersNivelContactosPorDocumentos + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalStakeholdersNivelContactosPorDocumentos = 0
        End Try
    End Function
    Public Function StakeholdersNivelContactosDelete(ByVal StakeholdersNivelContactosId As Long, ByVal StakeholdersNivelContactosName As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim StakeholdersNivelContactos As New StakeholdersNivelContactos

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = StakeholdersNivelContactos.LeerTotalStakeholdersNivelContactosPorDocumentos(StakeholdersNivelContactosName)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " contactos asociados al nivel " & StakeholdersNivelContactosName & vbCrLf
            Mensaje = Mensaje & "Cambia el Nivel a los contactos, antes de eliminarlo de la lista"
            StakeholdersNivelContactosDelete = False
        Else
            Try
                ' Borra registro de la tabla de Roles
                '-------------------------------------
                strUpdate = "DELETE FROM StakeholdersNivelContactos WHERE StakeholdersNivelContactosId = " & StakeholdersNivelContactosId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Nivel de Contacto: " & StakeholdersNivelContactosName, StakeholdersNivelContactosId, "StakeholdersNivelContactos", "")
                StakeholdersNivelContactosDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Nivel de Contacto: " & StakeholdersNivelContactosName, StakeholdersNivelContactosId, "StakeholdersNivelContactos", "")
                StakeholdersNivelContactosDelete = False
            End Try
        End If
    End Function
End Class
