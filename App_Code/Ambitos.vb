'------------------------------------------------------------
' Código generado por ZRISMART SF el 11-04-2011 22:40:05
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Ambitos
    Public Function LeerAmbitos(ByVal AmbitosId As Long, ByRef AmbitosCodigo As String, ByRef AmbitosName As String, ByRef AmbitosDescription As String, ByRef AmbitosSecuencia As Long, ByRef AmbitosSideBarMenu As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AmbitosCodigo, AmbitosName, AmbitosDescription, AmbitosSecuencia, AmbitosSideBarMenu "
        sSQL = sSQL & "FROM Ambitos "
        sSQL = sSQL & "WHERE (Ambitos.AmbitosId = " & AmbitosId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                AmbitosCodigo = CStr(dtr("AmbitosCodigo").ToString)
                AmbitosName = CStr(dtr("AmbitosName").ToString)
                AmbitosDescription = CStr(dtr("AmbitosDescription").ToString)
                If Len(dtr("AmbitosSecuencia").ToString) = 0 Then
                    AmbitosSecuencia = 0
                Else
                    AmbitosSecuencia = CLng(dtr("AmbitosSecuencia").ToString)
                End If
                AmbitosSideBarMenu = CStr(dtr("AmbitosSideBarMenu").ToString)
            End While
            LeerAmbitos = True
            dtr.Close()
        Catch
            LeerAmbitos = False
        End Try
    End Function
    Public Function LeerAmbitosByName(ByRef AmbitosId As Long, ByVal AmbitosCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AmbitosId "
        sSQL = sSQL & "FROM Ambitos "
        sSQL = sSQL & "WHERE (Ambitos.AmbitosCodigo = '" & AmbitosCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                AmbitosId = CLng(dtr("AmbitosId").ToString)
            End While
            LeerAmbitosByName = True
            dtr.Close()
        Catch
            LeerAmbitosByName = False
        End Try
    End Function
    Public Function AmbitosUpdate(ByVal AmbitosId As Long, ByRef AmbitosCodigo As String, ByRef AmbitosName As String, ByRef AmbitosDescription As String, ByRef AmbitosSecuencia As Long, ByRef AmbitosSideBarMenu As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Ambitos SET "
        strUpdate = strUpdate & "Ambitos.AmbitosCodigo = '" & AmbitosCodigo & "', "
        strUpdate = strUpdate & "Ambitos.AmbitosName = '" & AmbitosName & "', "
        strUpdate = strUpdate & "Ambitos.AmbitosDescription = '" & AmbitosDescription & "', "
        strUpdate = strUpdate & "Ambitos.AmbitosSecuencia = " & AmbitosSecuencia & ", "
        strUpdate = strUpdate & "Ambitos.AmbitosSideBarMenu = '" & AmbitosSideBarMenu & "', "
        strUpdate = strUpdate & "Ambitos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Ambitos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Ambitos.AmbitosId = " & AmbitosId
        Try
            AmbitosUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & AmbitosCodigo, AmbitosId, "Ambitos", "")
        Catch
            AmbitosUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & AmbitosCodigo, AmbitosId, "Ambitos", "")
        End Try
    End Function
    Public Function AmbitosInsert(ByRef AmbitosId As Long, ByRef AmbitosCodigo As String, ByRef AmbitosName As String, ByRef AmbitosDescription As String, ByRef AmbitosSecuencia As Long, ByRef AmbitosSideBarMenu As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Ambitos As New Ambitos
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = AmbitosCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("AmbitosId", "AmbitosCodigo", "Ambitos", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("AmbitosId", "AmbitosCodigo", "Ambitos", MasterName, CLng(UserId), MasterId)
            End If
            AmbitosInsert = Ambitos.AmbitosUpdate(MasterId, CStr(AmbitosCodigo), CStr(AmbitosName), CStr(AmbitosDescription), CLng(AmbitosSecuencia), CStr(AmbitosSideBarMenu), UserId)
        Catch
            AmbitosInsert = 0
        End Try
    End Function
    Public Function LeerAmbitosDescriptionByName(ByVal AmbitosCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AmbitosName "
        sSQL = sSQL & "FROM Ambitos "
        sSQL = sSQL & "WHERE (Ambitos.AmbitosCodigo = '" & AmbitosCodigo & "') "
        LeerAmbitosDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerAmbitosDescriptionByName = CStr(dtr("AmbitosName").ToString)
            End While
            dtr.Close()
        Catch
            LeerAmbitosDescriptionByName = ""
        End Try
    End Function
End Class
