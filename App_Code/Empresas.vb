'------------------------------------------------------------
' Código generado por ZRISMART SF el 13-04-2011 10:07:31
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Empresas
    Public Function LeerEmpresas(ByVal EmpresasId As Long, ByRef EmpresasCodigo As String, ByRef EmpresasName As String, ByRef EmpresasEMail As String, ByRef EmpresasContacto As String, ByRef EmpresasTelefono As String, ByRef EmpresasSigla As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EmpresasCodigo, EmpresasName, EmpresasEMail, EmpresasContacto, EmpresasTelefono, EmpresasSigla "
        sSQL = sSQL & "FROM Empresas "
        sSQL = sSQL & "WHERE (Empresas.EmpresasId = " & EmpresasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                EmpresasCodigo = CStr(dtr("EmpresasCodigo").ToString)
                EmpresasName = CStr(dtr("EmpresasName").ToString)
                EmpresasEMail = CStr(dtr("EmpresasEMail").ToString)
                EmpresasContacto = CStr(dtr("EmpresasContacto").ToString)
                EmpresasTelefono = CStr(dtr("EmpresasTelefono").ToString)
                EmpresasSigla = CStr(dtr("EmpresasSigla").ToString)
            End While
            LeerEmpresas = True
            dtr.Close()
        Catch
            LeerEmpresas = False
        End Try
    End Function
    Public Function LeerEmpresasByName(ByRef EmpresasId As Long, ByVal EmpresasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EmpresasId "
        sSQL = sSQL & "FROM Empresas "
        sSQL = sSQL & "WHERE (Empresas.EmpresasCodigo = '" & EmpresasCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                EmpresasId = CLng(dtr("EmpresasId").ToString)
            End While
            LeerEmpresasByName = True
            dtr.Close()
        Catch
            LeerEmpresasByName = False
        End Try
    End Function
    Public Function EmpresasUpdate(ByVal EmpresasId As Long, ByRef EmpresasCodigo As String, ByRef EmpresasName As String, ByRef EmpresasEMail As String, ByRef EmpresasContacto As String, ByRef EmpresasTelefono As String, ByRef EmpresasSigla As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Empresas SET "
        strUpdate = strUpdate & "Empresas.EmpresasCodigo = '" & EmpresasCodigo & "', "
        strUpdate = strUpdate & "Empresas.EmpresasName = '" & EmpresasName & "', "
        strUpdate = strUpdate & "Empresas.EmpresasEMail = '" & EmpresasEMail & "', "
        strUpdate = strUpdate & "Empresas.EmpresasContacto = '" & EmpresasContacto & "', "
        strUpdate = strUpdate & "Empresas.EmpresasTelefono = '" & EmpresasTelefono & "', "
        strUpdate = strUpdate & "Empresas.EmpresasSigla = '" & EmpresasSigla & "', "
        strUpdate = strUpdate & "Empresas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Empresas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Empresas.EmpresasId = " & EmpresasId
        Try
            EmpresasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & EmpresasCodigo, EmpresasId, "Empresas", "")
        Catch
            EmpresasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & EmpresasCodigo, EmpresasId, "Empresas", "")
        End Try
    End Function
    Public Function EmpresasInsert(ByRef EmpresasId As Long, ByRef EmpresasCodigo As String, ByRef EmpresasName As String, ByRef EmpresasEMail As String, ByRef EmpresasContacto As String, ByRef EmpresasTelefono As String, ByRef EmpresasSigla As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Empresas As New Empresas
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = EmpresasCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("EmpresasId", "EmpresasCodigo", "Empresas", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("EmpresasId", "EmpresasCodigo", "Empresas", MasterName, CLng(UserId), MasterId)
            End If
            EmpresasInsert = Empresas.EmpresasUpdate(MasterId, CStr(EmpresasCodigo), CStr(EmpresasName), CStr(EmpresasEMail), CStr(EmpresasContacto), CStr(EmpresasTelefono), CStr(EmpresasSigla), UserId)
        Catch
            EmpresasInsert = 0
        End Try
    End Function
    Public Function LeerEmpresasDescriptionByName(ByVal EmpresasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EmpresasName "
        sSQL = sSQL & "FROM Empresas "
        sSQL = sSQL & "WHERE (Empresas.EmpresasCodigo = '" & EmpresasCodigo & "') "
        LeerEmpresasDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerEmpresasDescriptionByName = CStr(dtr("EmpresasName").ToString)
            End While
            dtr.Close()
        Catch
            LeerEmpresasDescriptionByName = ""
        End Try
    End Function
    Public Function LeerEmpresasSiglaByName(ByVal EmpresasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EmpresasSigla "
        sSQL = sSQL & "FROM Empresas "
        sSQL = sSQL & "WHERE (Empresas.EmpresasCodigo = '" & EmpresasCodigo & "') "
        LeerEmpresasSiglaByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerEmpresasSiglaByName = CStr(dtr("EmpresasSigla").ToString)
            End While
            dtr.Close()
        Catch
            LeerEmpresasSiglaByName = ""
        End Try
    End Function
    Public Function LeerTotalEmpresasPorTablasRelacionadas(ByVal EmpresasCodigo As String, ByVal EmpresasId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en un Contrato
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Empresas INNER JOIN Contrato ON Empresas.EmpresasCodigo = Contrato.EmpresasCodigo "
        sSQL = sSQL & "WHERE (((Empresas.EmpresasCodigo)='" & EmpresasCodigo & "'))"
        LeerTotalEmpresasPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalEmpresasPorTablasRelacionadas = LeerTotalEmpresasPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalEmpresasPorTablasRelacionadas = 0
        End Try
        'Verifica si esta referenciada en una evidencia
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Empresas INNER JOIN TareasDocs ON Empresas.EmpresasCodigo = TareasDocs.EmpresasCodigo "
        sSQL = sSQL & "WHERE (((Empresas.EmpresasCodigo)='" & EmpresasCodigo & "'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalEmpresasPorTablasRelacionadas = LeerTotalEmpresasPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalEmpresasPorTablasRelacionadas = LeerTotalEmpresasPorTablasRelacionadas + 0
        End Try
        'Verifica si esta referenciada en un KPI
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Empresas INNER JOIN TareasKPI ON Empresas.EmpresasCodigo = TareasKPI.EmpresasCodigo "
        sSQL = sSQL & "WHERE (((Empresas.EmpresasCodigo)='" & EmpresasCodigo & "'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalEmpresasPorTablasRelacionadas = LeerTotalEmpresasPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalEmpresasPorTablasRelacionadas = LeerTotalEmpresasPorTablasRelacionadas + 0
        End Try
    End Function
    Public Function EmpresasDelete(ByVal EmpresasId As Long, ByVal EmpresasCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Empresas As New Empresas

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Empresas.LeerTotalEmpresasPorTablasRelacionadas(EmpresasCodigo, EmpresasId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados a la Empresa " & EmpresasCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie la Empresa en los Contratos, Evidencias y KPI, antes de eliminarla de la lista"
            EmpresasDelete = False
        Else
            Try
                ' Borra registro de la tabla de Gerencias
                '-------------------------------------
                strUpdate = "DELETE FROM Empresas WHERE EmpresasId = " & EmpresasId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina la Empresa: " & EmpresasCodigo, EmpresasId, "Empresas", "")
                EmpresasDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la Empresa: " & EmpresasCodigo, EmpresasId, "Empresas", "")
                EmpresasDelete = False
            End Try
        End If
    End Function
End Class
