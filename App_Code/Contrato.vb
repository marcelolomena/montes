'------------------------------------------------------------
' Código generado por ZRISMART SF el 01-02-2011 12:42:24
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Contrato
    Public Function LeerContrato(ByVal ContratoId As Long, ByRef ContratoCodigo As String, ByRef ContratoName As String, ByRef EmpresasCodigo As String, ByRef ContratoDescription As String, ByRef APIName As String, ByRef ContratoFechaInicio As Date, ByRef ContratoFechaTermino As Date) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ContratoCodigo, ContratoName, EmpresasCodigo, ContratoDescription, APIName, ContratoFechaInicio, ContratoFechaTermino "
        sSQL = sSQL & "FROM (Contrato) "
        sSQL = sSQL & "WHERE (Contrato.ContratoId = " & ContratoId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ContratoCodigo = CStr(dtr("ContratoCodigo").ToString)
                ContratoName = CStr(dtr("ContratoName").ToString)
                EmpresasCodigo = CStr(dtr("EmpresasCodigo").ToString)
                ContratoDescription = CStr(dtr("ContratoDescription").ToString)
                APIName = CStr(dtr("APIName").ToString)
                If Len(dtr("ContratoFechaInicio").ToString) = 0 Then
                    ContratoFechaInicio = "01/01/01"
                Else
                    ContratoFechaInicio = CDate(dtr("ContratoFechaInicio").ToString)
                End If
                If Len(dtr("ContratoFechaTermino").ToString) = 0 Then
                    ContratoFechaTermino = "01/01/01"
                Else
                    ContratoFechaTermino = CDate(dtr("ContratoFechaTermino").ToString)
                End If
            End While
            LeerContrato = True
            dtr.Close()
        Catch
            LeerContrato = False
        End Try
    End Function
    Public Function LeerContratoByName(ByRef ContratoId As Long, ByVal ContratoCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ContratoId "
        sSQL = sSQL & "FROM (Contrato) "
        sSQL = sSQL & "WHERE (Contrato.ContratoCodigo = '" & ContratoCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ContratoId = CLng(dtr("ContratoId").ToString)
            End While
            LeerContratoByName = True
            dtr.Close()
        Catch
            LeerContratoByName = False
        End Try
    End Function
    Public Function ContratoUpdate(ByVal ContratoId As Long, ByRef ContratoCodigo As String, ByRef ContratoName As String, ByRef EmpresasCodigo As String, ByRef ContratoDescription As String, ByRef APIName As String, ByRef ContratoFechaInicio As Date, ByRef ContratoFechaTermino As Date, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Contrato SET "
        strUpdate = strUpdate & "Contrato.ContratoCodigo = '" & ContratoCodigo & "', "
        strUpdate = strUpdate & "Contrato.ContratoName = '" & ContratoName & "', "
        strUpdate = strUpdate & "Contrato.EmpresasCodigo = '" & EmpresasCodigo & "', "
        strUpdate = strUpdate & "Contrato.ContratoDescription = '" & ContratoDescription & "', "
        strUpdate = strUpdate & "Contrato.APIName = '" & APIName & "', "
        strUpdate = strUpdate & "Contrato.ContratoFechaInicio = '" & AccionesABM.DateTransform(ContratoFechaInicio) & "', "
        strUpdate = strUpdate & "Contrato.ContratoFechaTermino = '" & AccionesABM.DateTransform(ContratoFechaTermino) & "', "
        strUpdate = strUpdate & "Contrato.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Contrato.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Contrato.ContratoId = " & ContratoId
        Try
            ContratoUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ContratoCodigo, ContratoId, "Contrato", "")
        Catch
            ContratoUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ContratoCodigo, ContratoId, "Contrato", "")
        End Try
    End Function
    Public Function ContratoInsert(ByRef ContratoId As Long, ByRef ContratoCodigo As String, ByRef ContratoName As String, ByRef EmpresasCodigo As String, ByRef ContratoDescription As String, ByRef APIName As String, ByRef ContratoFechaInicio As Date, ByRef ContratoFechaTermino As Date, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Contrato As New Contrato
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = ContratoCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("ContratoId", "ContratoCodigo", "Contrato", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("ContratoId", "ContratoCodigo", "Contrato", MasterName, CLng(UserId), MasterId)
            End If
            ContratoInsert = Contrato.ContratoUpdate(MasterId, CStr(ContratoCodigo), CStr(ContratoName), CStr(EmpresasCodigo), CStr(ContratoDescription), CStr(APIName), CDate(ContratoFechaInicio), CDate(ContratoFechaTermino), UserId)
        Catch
            ContratoInsert = 0
        End Try
    End Function
    Public Function LeerContratoDescriptionByName(ByVal ContratoCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ContratoName "
        sSQL = sSQL & "FROM (Contrato) "
        sSQL = sSQL & "WHERE (Contrato.ContratoCodigo = '" & ContratoCodigo & "') "
        LeerContratoDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerContratoDescriptionByName = CStr(dtr("ContratoName").ToString)
            End While
            dtr.Close()
        Catch
            LeerContratoDescriptionByName = ""
        End Try
    End Function
    Public Function LeerContratoEmpresasCodigoByName(ByVal ContratoCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EmpresasCodigo "
        sSQL = sSQL & "FROM (Contrato) "
        sSQL = sSQL & "WHERE (Contrato.ContratoCodigo = '" & ContratoCodigo & "') "
        LeerContratoEmpresasCodigoByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerContratoEmpresasCodigoByName = CStr(dtr("EmpresasCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerContratoEmpresasCodigoByName = ""
        End Try
    End Function
    Public Function LeerContratoEmpresaNameByName(ByVal ContratoCodigo As String, ByRef EmpresaName As String, ByRef ContratoName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Empresas.EmpresasName, Contrato.ContratoName "
        sSQL = sSQL & "FROM Contrato INNER JOIN Empresas ON Contrato.EmpresasCodigo = Empresas.EmpresasCodigo "
        sSQL = sSQL & "WHERE (((Contrato.ContratoCodigo)='" & ContratoCodigo & "'))"
        EmpresaName = " - "
        ContratoName = " - "
        LeerContratoEmpresaNameByName = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                EmpresaName = CStr(dtr("EmpresasName").ToString)
                ContratoName = CStr(dtr("ContratoName").ToString)
                LeerContratoEmpresaNameByName = True
            End While
            dtr.Close()
        Catch
            LeerContratoEmpresaNameByName = False
        End Try
    End Function
    Public Function LeerTotalContratoPorTablasRelacionadas(ByVal ContratoCodigo As String, ByVal ContratoId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en un Contrato
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Contrato INNER JOIN ContratoDocs ON Contrato.ContratoCodigo = ContratoDocs.ContratoCodigo "
        sSQL = sSQL & "WHERE (((Contrato.ContratoCodigo)='" & ContratoCodigo & "'))"
        LeerTotalContratoPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalContratoPorTablasRelacionadas = LeerTotalContratoPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalContratoPorTablasRelacionadas = 0
        End Try
        'Verifica si esta referenciado en una evidencia
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Contrato INNER JOIN TareasDocs ON Contrato.ContratoCodigo = TareasDocs.ContratoCodigo "
        sSQL = sSQL & "WHERE (((Contrato.ContratoCodigo)='" & ContratoCodigo & "'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalContratoPorTablasRelacionadas = LeerTotalContratoPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalContratoPorTablasRelacionadas = LeerTotalContratoPorTablasRelacionadas + 0
        End Try
        'Verifica si esta referenciada en un KPI
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Contrato INNER JOIN TareasKPI ON Contrato.ContratoCodigo = TareasKPI.ContratoCodigo "
        sSQL = sSQL & "WHERE (((Contrato.ContratoCodigo)='" & ContratoCodigo & "'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalContratoPorTablasRelacionadas = LeerTotalContratoPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalContratoPorTablasRelacionadas = LeerTotalContratoPorTablasRelacionadas + 0
        End Try
        'Verifica si esta referenciada en un Proyecto
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Contrato INNER JOIN ContratosPorProyecto ON Contrato.ContratoId = ContratosPorProyecto.ContratoId "
        sSQL = sSQL & "WHERE (((Contrato.ContratoId)=" & ContratoId & "))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalContratoPorTablasRelacionadas = LeerTotalContratoPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalContratoPorTablasRelacionadas = LeerTotalContratoPorTablasRelacionadas + 0
        End Try
    End Function
    Public Function ContratoDelete(ByVal ContratoId As Long, ByVal ContratoCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Contrato As New Contrato

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Contrato.LeerTotalContratoPorTablasRelacionadas(ContratoCodigo, ContratoId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados al Contrato " & ContratoCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie o elimine el Contrato de sus documentos asociados, Evidencias y KPI, antes de eliminarlo de la lista"
            ContratoDelete = False
        Else
            Try
                ' Borra registro de la tabla de Gerencias
                '-------------------------------------
                strUpdate = "DELETE FROM Contrato WHERE ContratoId = " & ContratoId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Contrato: " & ContratoCodigo, ContratoId, "Contrato", "")
                ContratoDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Contrato: " & ContratoCodigo, ContratoId, "Contrato", "")
                ContratoDelete = False
            End Try
        End If
    End Function

End Class
