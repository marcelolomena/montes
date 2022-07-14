'------------------------------------------------------------
' Código generado por ZRISMART SF el 01-02-2011 9:27:44
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class TipoContrato
    Public Function LeerTipoContrato(ByVal TipoContratoId As Long, ByRef TipoContratoName As String, ByRef TipoContratoDescription As String, ByRef TipoContratoSecuencia As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TipoContratoName, TipoContratoDescription, TipoContratoSecuencia "
        sSQL = sSQL & "FROM (TipoContrato) "
        sSQL = sSQL & "WHERE (TipoContrato.TipoContratoId = " & TipoContratoId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TipoContratoName = CStr(dtr("TipoContratoName").ToString)
                TipoContratoDescription = CStr(dtr("TipoContratoDescription").ToString)
                If Len(dtr("TipoContratoSecuencia").ToString) = 0 Then
                    TipoContratoSecuencia = 0
                Else
                    TipoContratoSecuencia = CLng(dtr("TipoContratoSecuencia").ToString)
                End If
            End While
            LeerTipoContrato = True
            dtr.Close()
        Catch
            LeerTipoContrato = False
        End Try
    End Function
    Public Function LeerTipoContratoByName(ByRef TipoContratoId As Long, ByVal TipoContratoName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TipoContratoId "
        sSQL = sSQL & "FROM (TipoContrato) "
        sSQL = sSQL & "WHERE (TipoContrato.TipoContratoName = '" & TipoContratoName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TipoContratoId = CLng(dtr("TipoContratoId").ToString)
            End While
            LeerTipoContratoByName = True
            dtr.Close()
        Catch
            LeerTipoContratoByName = False
        End Try
    End Function
    Public Function TipoContratoUpdate(ByVal TipoContratoId As Long, ByRef TipoContratoName As String, ByRef TipoContratoDescription As String, ByRef TipoContratoSecuencia As Long, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE TipoContrato SET "
        strUpdate = strUpdate & "TipoContrato.TipoContratoName = '" & TipoContratoName & "', "
        strUpdate = strUpdate & "TipoContrato.TipoContratoDescription = '" & TipoContratoDescription & "', "
        strUpdate = strUpdate & "TipoContrato.TipoContratoSecuencia = " & TipoContratoSecuencia & ", "
        strUpdate = strUpdate & "TipoContrato.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "TipoContrato.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE TipoContrato.TipoContratoId = " & TipoContratoId
        Try
            TipoContratoUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & TipoContratoName, TipoContratoId, "TipoContrato", "")
        Catch
            TipoContratoUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TipoContratoName, TipoContratoId, "TipoContrato", "")
        End Try
    End Function
    Public Function TipoContratoInsert(ByRef TipoContratoId As Long, ByRef TipoContratoName As String, ByRef TipoContratoDescription As String, ByRef TipoContratoSecuencia As Long, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim TipoContrato As New TipoContrato
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = TipoContratoName
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("TipoContratoId", "TipoContratoName", "TipoContrato", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("TipoContratoId", "TipoContratoName", "TipoContrato", MasterName, CLng(UserId), MasterId)
            End If
            TipoContratoInsert = TipoContrato.TipoContratoUpdate(MasterId, CStr(TipoContratoName), CStr(TipoContratoDescription), CLng(TipoContratoSecuencia), UserId)
        Catch
            TipoContratoInsert = 0
        End Try
    End Function
End Class
