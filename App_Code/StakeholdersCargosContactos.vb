'------------------------------------------------------------
' Código generado por ZRISMART SF el 24-08-2011 19:03:21
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class StakeholdersCargosContactos
    Public Function LeerStakeholdersCargosContactos(ByVal StakeholdersCargosContactosId As Long, ByRef StakeholdersCargosContactosName As String, ByRef StakeholdersCargosContactosDescription As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersCargosContactosName, StakeholdersCargosContactosDescription "
        sSQL = sSQL & "FROM (StakeholdersCargosContactos) "
        sSQL = sSQL & "WHERE (StakeholdersCargosContactos.StakeholdersCargosContactosId = " & StakeholdersCargosContactosId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                StakeholdersCargosContactosName = CStr(dtr("StakeholdersCargosContactosName").ToString)
                StakeholdersCargosContactosDescription = CStr(dtr("StakeholdersCargosContactosDescription").ToString)
            End While
            LeerStakeholdersCargosContactos = True
            dtr.Close()
        Catch
            LeerStakeholdersCargosContactos = False
        End Try
    End Function
    Public Function LeerStakeholdersCargosContactosByName(ByRef StakeholdersCargosContactosId As Long, ByVal StakeholdersCargosContactosName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersCargosContactosId "
        sSQL = sSQL & "FROM (StakeholdersCargosContactos) "
        sSQL = sSQL & "WHERE (StakeholdersCargosContactos.StakeholdersCargosContactosName = '" & StakeholdersCargosContactosName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                StakeholdersCargosContactosId = CLng(dtr("StakeholdersCargosContactosId").ToString)
            End While
            LeerStakeholdersCargosContactosByName = True
            dtr.Close()
        Catch
            LeerStakeholdersCargosContactosByName = False
        End Try
    End Function
    Public Function LeerStakeholdersCargosContactosDescriptionByName(ByVal StakeholdersCargosContactosName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        LeerStakeholdersCargosContactosDescriptionByName = " "
        sSQL = "Select StakeholdersCargosContactosDescription "
        sSQL = sSQL & "FROM (StakeholdersCargosContactos) "
        sSQL = sSQL & "WHERE (StakeholdersCargosContactos.StakeholdersCargosContactosName = '" & StakeholdersCargosContactosName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerStakeholdersCargosContactosDescriptionByName = CStr(dtr("StakeholdersCargosContactosDescription").ToString)
            End While
            dtr.Close()
        Catch
            LeerStakeholdersCargosContactosDescriptionByName = " "
        End Try
    End Function
    Public Function StakeholdersCargosContactosUpdate(ByVal StakeholdersCargosContactosId As Long, ByRef StakeholdersCargosContactosName As String, ByRef StakeholdersCargosContactosDescription As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE StakeholdersCargosContactos SET "
        strUpdate = strUpdate & "StakeholdersCargosContactos.StakeholdersCargosContactosName = '" & StakeholdersCargosContactosName & "', "
        strUpdate = strUpdate & "StakeholdersCargosContactos.StakeholdersCargosContactosDescription = '" & StakeholdersCargosContactosDescription & "', "
        strUpdate = strUpdate & "StakeholdersCargosContactos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "StakeholdersCargosContactos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE StakeholdersCargosContactos.StakeholdersCargosContactosId = " & StakeholdersCargosContactosId
        Try
            StakeholdersCargosContactosUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & StakeholdersCargosContactosName, StakeholdersCargosContactosId, "StakeholdersCargosContactos", "")
        Catch
            StakeholdersCargosContactosUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & StakeholdersCargosContactosName, StakeholdersCargosContactosId, "StakeholdersCargosContactos", "")
        End Try
    End Function
    Public Function StakeholdersCargosContactosInsert(ByRef StakeholdersCargosContactosId As Long, ByRef StakeholdersCargosContactosName As String, ByRef StakeholdersCargosContactosDescription As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim StakeholdersCargosContactos As New StakeholdersCargosContactos
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = StakeholdersCargosContactosName
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("StakeholdersCargosContactosId", "StakeholdersCargosContactosName", "StakeholdersCargosContactos", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("StakeholdersCargosContactosId", "StakeholdersCargosContactosName", "StakeholdersCargosContactos", MasterName, CLng(UserId), MasterId)
            End If
            StakeholdersCargosContactosInsert = StakeholdersCargosContactos.StakeholdersCargosContactosUpdate(MasterId, CStr(StakeholdersCargosContactosName), CStr(StakeholdersCargosContactosDescription), UserId)
        Catch
            StakeholdersCargosContactosInsert = 0
        End Try
    End Function
    Public Function LeerTotalStakeholdersCargosContactosPorDocumentos(ByVal StakeholdersCargosContactosName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        ' Verificamos si el área esta referenciada en algún documento
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM StakeholdersCargosContactos INNER JOIN StakeholdersContactos ON StakeholdersCargosContactos.StakeholdersCargosContactosName = StakeholdersContactos.StakeholdersCargosContactosName "
        sSQL = sSQL & "WHERE (((StakeholdersCargosContactos.StakeholdersCargosContactosName)='" & StakeholdersCargosContactosName & "'))"
        LeerTotalStakeholdersCargosContactosPorDocumentos = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalStakeholdersCargosContactosPorDocumentos = LeerTotalStakeholdersCargosContactosPorDocumentos + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalStakeholdersCargosContactosPorDocumentos = 0
        End Try
    End Function
    Public Function StakeholdersCargosContactosDelete(ByVal StakeholdersCargosContactosId As Long, ByVal StakeholdersCargosContactosName As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim StakeholdersCargosContactos As New StakeholdersCargosContactos

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = StakeholdersCargosContactos.LeerTotalStakeholdersCargosContactosPorDocumentos(StakeholdersCargosContactosName)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " contactos asociados al cargo " & StakeholdersCargosContactosName & vbCrLf
            Mensaje = Mensaje & "Cambia el cargo a los contactos, antes de eliminarlo de la lista"
            StakeholdersCargosContactosDelete = False
        Else
            Try
                ' Borra registro de la tabla de Roles
                '-------------------------------------
                strUpdate = "DELETE FROM StakeholdersCargosContactos WHERE StakeholdersCargosContactosId = " & StakeholdersCargosContactosId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el cargo de Contacto: " & StakeholdersCargosContactosName, StakeholdersCargosContactosId, "StakeholdersCargosContactos", "")
                StakeholdersCargosContactosDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el cargo de Contacto: " & StakeholdersCargosContactosName, StakeholdersCargosContactosId, "StakeholdersCargosContactos", "")
                StakeholdersCargosContactosDelete = False
            End Try
        End If
    End Function
End Class
