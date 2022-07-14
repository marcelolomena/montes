'------------------------------------------------------------
' Código generado por ZRISMART SF el 22-03-2012 7:33:21
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Procesos
    Public Function LeerProcesos(ByVal ProcesosId As Long, ByRef ProcesosName As String, ByRef ProcesosDescription As String, ByRef ProcesosSecuencia As Long, ByRef AccionesCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProcesosName, ProcesosDescription, ProcesosSecuencia, AccionesCodigo "
        sSQL = sSQL & "FROM Procesos "
        sSQL = sSQL & "WHERE Procesos.ProcesosId = " & ProcesosId & " "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProcesosName = CStr(dtr("ProcesosName").ToString)
                ProcesosDescription = CStr(dtr("ProcesosDescription").ToString)
                If Len(dtr("ProcesosSecuencia").ToString) = 0 Then
                    ProcesosSecuencia = 0
                Else
                    ProcesosSecuencia = CLng(dtr("ProcesosSecuencia").ToString)
                End If
                AccionesCodigo = CStr(dtr("AccionesCodigo").ToString)
            End While
            LeerProcesos = True
            dtr.Close()
        Catch
            LeerProcesos = False
        End Try
    End Function
    Public Function LeerProcesosByName(ByRef ProcesosId As Long, ByVal ProcesosName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProcesosId "
        sSQL = sSQL & "FROM (Procesos) "
        sSQL = sSQL & "WHERE (Procesos.ProcesosName = '" & ProcesosName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProcesosId = CLng(dtr("ProcesosId").ToString)
            End While
            LeerProcesosByName = True
            dtr.Close()
        Catch
            LeerProcesosByName = False
        End Try
    End Function
    Public Function ProcesosUpdate(ByVal ProcesosId As Long, ByRef ProcesosName As String, ByRef ProcesosDescription As String, ByRef ProcesosSecuencia As Long, ByRef AccionesCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Procesos SET "
        strUpdate = strUpdate & "Procesos.ProcesosName = '" & ProcesosName & "', "
        strUpdate = strUpdate & "Procesos.ProcesosDescription = '" & ProcesosDescription & "', "
        strUpdate = strUpdate & "Procesos.ProcesosSecuencia = " & ProcesosSecuencia & ", "
        strUpdate = strUpdate & "Procesos.AccionesCodigo = '" & AccionesCodigo & "', "
        strUpdate = strUpdate & "Procesos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Procesos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Procesos.ProcesosId = " & ProcesosId
        Try
            ProcesosUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ProcesosName, ProcesosId, "Procesos", "")
        Catch
            ProcesosUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ProcesosName, ProcesosId, "Procesos", "")
        End Try
    End Function
    Public Function ProcesosInsert(ByRef ProcesosId As Long, ByRef ProcesosName As String, ByRef ProcesosDescription As String, ByRef ProcesosSecuencia As Long, ByRef AccionesCodigo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Procesos As New Procesos
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = ProcesosName
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("ProcesosId", "ProcesosName", "Procesos", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("ProcesosId", "ProcesosName", "Procesos", MasterName, CLng(UserId), MasterId)
            End If
            ProcesosInsert = Procesos.ProcesosUpdate(MasterId, CStr(ProcesosName), CStr(ProcesosDescription), CLng(ProcesosSecuencia), CStr(AccionesCodigo), UserId)
        Catch
            ProcesosInsert = 0
        End Try
    End Function
    Public Function LeerTotalProcesosEnTablasRelacionadas(ByVal ProcesosName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        ' Esta instrucción debe ser completada por el desarrollador, reemplazando XXXXXX por el nombre de la tabla relacionada
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Procesos INNER JOIN XXXXXXXXXXX ON Procesos.ProcesosName = XXXXXXXXXXXX.ProcesosName "
        sSQL = sSQL & "WHERE Procesos.ProcesosName = '" & ProcesosName & "' "
        LeerTotalProcesosEnTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalProcesosEnTablasRelacionadas = LeerTotalProcesosEnTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalProcesosEnTablasRelacionadas = 0
        End Try
    End Function
    Public Function ProcesosDelete(ByVal ProcesosId As Long, ByVal ProcesosName As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = " "
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        Dim Total As Long
        Dim Mensaje As String
        Dim Procesos As New Procesos
        ' Lee la cantidad de veces que el registro es usado en tablas relacionadas
        Total = Procesos.LeerTotalProcesosEnTablasRelacionadas(ProcesosName)
        If Total > 0 Then
            Mensaje = "Existen " & Total & " de registros en tablas relacionadas con la tabla Procesos " & vbCrLf
            Mensaje = Mensaje & "El registro no puede ser eliminado"
            ProcesosDelete = False
        Else
            Try
                strUpdate = "DELETE "
                strUpdate = strUpdate & "FROM Procesos "
                strUpdate = strUpdate & "WHERE Procesos.ProcesosId = " & ProcesosId
                ProcesosDelete = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Registro: " & ProcesosName, ProcesosId, "Procesos", "")
            Catch
                ProcesosDelete = 0
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar Registro: " & ProcesosName, ProcesosId, "Procesos", "")
            End Try
        End If
    End Function
End Class
