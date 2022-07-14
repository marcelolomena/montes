'------------------------------------------------------------
' Código generado por ZRISMART SF el 25-04-2011 17:08:39
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Indicadores
    Public Function LeerIndicadores(ByVal IndicadoresId As Long, ByRef IndicadoresCodigo As String, ByRef IndicadoresName As String, ByRef IndicadoresDescription As String, ByRef AmbitosCodigo As String, ByRef IndicadoresIsManual As Boolean, ByRef IndicadoresValores As Long, ByRef IndicadoresNombre1 As String, ByRef IndicadoresNombre2 As String, ByRef IndicadoresNombre3 As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select IndicadoresCodigo, IndicadoresName, IndicadoresDescription, AmbitosCodigo, IndicadoresIsManual, IndicadoresValores, IndicadoresNombre1, IndicadoresNombre2, IndicadoresNombre3 "
        sSQL = sSQL & "FROM (Indicadores) "
        sSQL = sSQL & "WHERE (Indicadores.IndicadoresId = " & IndicadoresId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                IndicadoresCodigo = CStr(dtr("IndicadoresCodigo").ToString)
                IndicadoresName = CStr(dtr("IndicadoresName").ToString)
                IndicadoresDescription = CStr(dtr("IndicadoresDescription").ToString)
                AmbitosCodigo = CStr(dtr("AmbitosCodigo").ToString)
                IndicadoresIsManual = CBool(dtr("IndicadoresIsManual").ToString)
                If Len(dtr("IndicadoresValores").ToString) = 0 Then
                    IndicadoresValores = 0
                Else
                    IndicadoresValores = CLng(dtr("IndicadoresValores").ToString)
                End If
                IndicadoresNombre1 = CStr(dtr("IndicadoresNombre1").ToString)
                IndicadoresNombre2 = CStr(dtr("IndicadoresNombre2").ToString)
                IndicadoresNombre3 = CStr(dtr("IndicadoresNombre3").ToString)
            End While
            LeerIndicadores = True
            dtr.Close()
        Catch
            LeerIndicadores = False
        End Try
    End Function
    Public Function LeerIndicadoresByName(ByRef IndicadoresId As Long, ByVal IndicadoresCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select IndicadoresId "
        sSQL = sSQL & "FROM (Indicadores) "
        sSQL = sSQL & "WHERE (Indicadores.IndicadoresCodigo = '" & IndicadoresCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                IndicadoresId = CLng(dtr("IndicadoresId").ToString)
            End While
            LeerIndicadoresByName = True
            dtr.Close()
        Catch
            LeerIndicadoresByName = False
        End Try
    End Function
    Public Function IndicadoresUpdate(ByVal IndicadoresId As Long, ByRef IndicadoresCodigo As String, ByRef IndicadoresName As String, ByRef IndicadoresDescription As String, ByRef AmbitosCodigo As String, ByRef IndicadoresIsManual As Boolean, ByRef IndicadoresValores As Long, ByRef IndicadoresNombre1 As String, ByRef IndicadoresNombre2 As String, ByRef IndicadoresNombre3 As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Indicadores SET "
        strUpdate = strUpdate & "Indicadores.IndicadoresCodigo = '" & IndicadoresCodigo & "', "
        strUpdate = strUpdate & "Indicadores.IndicadoresName = '" & IndicadoresName & "', "
        strUpdate = strUpdate & "Indicadores.IndicadoresDescription = '" & IndicadoresDescription & "', "
        strUpdate = strUpdate & "Indicadores.AmbitosCodigo = '" & AmbitosCodigo & "', "
        strUpdate = strUpdate & "Indicadores.IndicadoresIsManual = " & IndicadoresIsManual & ", "
        strUpdate = strUpdate & "Indicadores.IndicadoresValores = " & IndicadoresValores & ", "
        strUpdate = strUpdate & "Indicadores.IndicadoresNombre1 = '" & IndicadoresNombre1 & "', "
        strUpdate = strUpdate & "Indicadores.IndicadoresNombre2 = '" & IndicadoresNombre2 & "', "
        strUpdate = strUpdate & "Indicadores.IndicadoresNombre3 = '" & IndicadoresNombre3 & "', "
        strUpdate = strUpdate & "Indicadores.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Indicadores.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Indicadores.IndicadoresId = " & IndicadoresId
        Try
            IndicadoresUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & IndicadoresCodigo, IndicadoresId, "Indicadores", "")
        Catch
            IndicadoresUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & IndicadoresCodigo, IndicadoresId, "Indicadores", "")
        End Try
    End Function
    Public Function IndicadoresInsert(ByRef IndicadoresId As Long, ByRef IndicadoresCodigo As String, ByRef IndicadoresName As String, ByRef IndicadoresDescription As String, ByRef AmbitosCodigo As String, ByRef IndicadoresIsManual As Boolean, ByRef IndicadoresValores As Long, ByRef IndicadoresNombre1 As String, ByRef IndicadoresNombre2 As String, ByRef IndicadoresNombre3 As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Indicadores As New Indicadores
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = IndicadoresCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("IndicadoresId", "IndicadoresCodigo", "Indicadores", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("IndicadoresId", "IndicadoresCodigo", "Indicadores", MasterName, CLng(UserId), MasterId)
            End If
            IndicadoresInsert = Indicadores.IndicadoresUpdate(MasterId, CStr(IndicadoresCodigo), CStr(IndicadoresName), CStr(IndicadoresDescription), CStr(AmbitosCodigo), CBool(IndicadoresIsManual), CLng(IndicadoresValores), CStr(IndicadoresNombre1), CStr(IndicadoresNombre2), CStr(IndicadoresNombre3), UserId)
        Catch
            IndicadoresInsert = 0
        End Try
    End Function
    Public Function LeerIndicadoresDescriptionByName(ByVal IndicadoresCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select IndicadoresName "
        sSQL = sSQL & "FROM (Indicadores) "
        sSQL = sSQL & "WHERE (Indicadores.IndicadoresCodigo = '" & IndicadoresCodigo & "') "
        LeerIndicadoresDescriptionByName = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerIndicadoresDescriptionByName = CStr(dtr("IndicadoresName").ToString)
            End While
            dtr.Close()
        Catch
            LeerIndicadoresDescriptionByName = ""
        End Try
    End Function
    Public Function LeerTotalIndicadoresPorTablasRelacionadas(ByVal IndicadoresCodigo As String, ByVal IndicadoresId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en una Acción
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Indicadores INNER JOIN Acciones ON Indicadores.IndicadoresCodigo = Acciones.IndicadoresCodigo "
        sSQL = sSQL & "WHERE (((Indicadores.IndicadoresCodigo)='" & IndicadoresCodigo & "'))"
        LeerTotalIndicadoresPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalIndicadoresPorTablasRelacionadas = LeerTotalIndicadoresPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalIndicadoresPorTablasRelacionadas = 0
        End Try
        'Verifica si esta referenciada en una evidencia
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Indicadores INNER JOIN TareasKPI ON Indicadores.IndicadoresCodigo = TareasKPI.IndicadoresCodigo "
        sSQL = sSQL & "WHERE (((Indicadores.IndicadoresCodigo)='" & IndicadoresCodigo & "'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalIndicadoresPorTablasRelacionadas = LeerTotalIndicadoresPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalIndicadoresPorTablasRelacionadas = LeerTotalIndicadoresPorTablasRelacionadas + 0
        End Try
    End Function
    Public Function IndicadoresDelete(ByVal IndicadoresId As Long, ByVal IndicadoresCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Indicadores As New Indicadores

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Indicadores.LeerTotalIndicadoresPorTablasRelacionadas(IndicadoresCodigo, IndicadoresId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados al Indicador " & IndicadoresCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie el Indicador en las Acciones y KPI levantados en las tareas, antes de eliminarlo de la lista"
            IndicadoresDelete = False
        Else
            Try
                ' Borra registro de la tabla de Gerencias
                '-------------------------------------
                strUpdate = "DELETE FROM Indicadores WHERE IndicadoresId = " & IndicadoresId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el indicador: " & IndicadoresCodigo, IndicadoresId, "Indicadores", "")
                IndicadoresDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Indicador: " & IndicadoresCodigo, IndicadoresId, "Indicadores", "")
                IndicadoresDelete = False
            End Try
        End If
    End Function
End Class
