'------------------------------------------------------------
' Código generado por ZRISMART SF el 22-08-2011 12:26:01
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class ProgramasObjEspecifico
    Public Function LeerProgramasObjEspecifico(ByVal ProgramasObjEspecificoId As Long, ByRef ProgramasCodigo As String, ByRef ProgramasObjEspecificoSecuencia As Long, ByRef ProgramasObjEspecificoNombre As String, ByRef ProgramasObjEspecificoDescription As String, ByRef ProgramasObjEspecificoIndicadorLogro As String, ByRef ProgramasObjEspecificoResultado As String, ByRef ProgramasObjEspecificoRespaldo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasCodigo, ProgramasObjEspecificoSecuencia, ProgramasObjEspecificoNombre, ProgramasObjEspecificoDescription, ProgramasObjEspecificoIndicadorLogro, ProgramasObjEspecificoResultado, ProgramasObjEspecificoRespaldo "
        sSQL = sSQL & "FROM (ProgramasObjEspecifico) "
        sSQL = sSQL & "WHERE (ProgramasObjEspecifico.ProgramasObjEspecificoId = " & ProgramasObjEspecificoId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProgramasCodigo = CStr(dtr("ProgramasCodigo").ToString)
                If Len(dtr("ProgramasObjEspecificoSecuencia").ToString) = 0 Then
                    ProgramasObjEspecificoSecuencia = 0
                Else
                    ProgramasObjEspecificoSecuencia = CLng(dtr("ProgramasObjEspecificoSecuencia").ToString)
                End If
                ProgramasObjEspecificoNombre = CStr(dtr("ProgramasObjEspecificoNombre").ToString)
                ProgramasObjEspecificoDescription = CStr(dtr("ProgramasObjEspecificoDescription").ToString)
                ProgramasObjEspecificoIndicadorLogro = CStr(dtr("ProgramasObjEspecificoIndicadorLogro").ToString)
                ProgramasObjEspecificoResultado = CStr(dtr("ProgramasObjEspecificoResultado").ToString)
                ProgramasObjEspecificoRespaldo = CStr(dtr("ProgramasObjEspecificoRespaldo").ToString)
            End While
            LeerProgramasObjEspecifico = True
            dtr.Close()
        Catch
            LeerProgramasObjEspecifico = False
        End Try
    End Function
    Public Function ProgramasObjEspecificoUpdate(ByVal ProgramasObjEspecificoId As Long, ByRef ProgramasCodigo As String, ByRef ProgramasObjEspecificoSecuencia As Long, ByRef ProgramasObjEspecificoNombre As String, ByRef ProgramasObjEspecificoDescription As String, ByRef ProgramasObjEspecificoIndicadorLogro As String, ByRef ProgramasObjEspecificoResultado As String, ByRef ProgramasObjEspecificoRespaldo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE ProgramasObjEspecifico SET "
        strUpdate = strUpdate & "ProgramasObjEspecifico.ProgramasCodigo = '" & ProgramasCodigo & "', "
        strUpdate = strUpdate & "ProgramasObjEspecifico.ProgramasObjEspecificoSecuencia = " & ProgramasObjEspecificoSecuencia & ", "
        strUpdate = strUpdate & "ProgramasObjEspecifico.ProgramasObjEspecificoNombre = '" & ProgramasObjEspecificoNombre & "', "
        strUpdate = strUpdate & "ProgramasObjEspecifico.ProgramasObjEspecificoDescription = '" & ProgramasObjEspecificoDescription & "', "
        strUpdate = strUpdate & "ProgramasObjEspecifico.ProgramasObjEspecificoIndicadorLogro = '" & ProgramasObjEspecificoIndicadorLogro & "', "
        strUpdate = strUpdate & "ProgramasObjEspecifico.ProgramasObjEspecificoResultado = '" & ProgramasObjEspecificoResultado & "', "
        strUpdate = strUpdate & "ProgramasObjEspecifico.ProgramasObjEspecificoRespaldo = '" & ProgramasObjEspecificoRespaldo & "', "
        strUpdate = strUpdate & "ProgramasObjEspecifico.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "ProgramasObjEspecifico.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE ProgramasObjEspecifico.ProgramasObjEspecificoId = " & ProgramasObjEspecificoId
        Try
            ProgramasObjEspecificoUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ProgramasCodigo, ProgramasObjEspecificoId, "ProgramasObjEspecifico", "")
        Catch
            ProgramasObjEspecificoUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ProgramasCodigo, ProgramasObjEspecificoId, "ProgramasObjEspecifico", "")
        End Try
    End Function
    Public Function ProgramasObjEspecificoInsert(ByRef ProgramasObjEspecificoId As Long, ByRef ProgramasCodigo As String, ByRef ProgramasObjEspecificoSecuencia As Long, ByRef ProgramasObjEspecificoNombre As String, ByRef ProgramasObjEspecificoDescription As String, ByRef ProgramasObjEspecificoIndicadorLogro As String, ByRef ProgramasObjEspecificoResultado As String, ByRef ProgramasObjEspecificoRespaldo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim ProgramasObjEspecifico As New ProgramasObjEspecifico
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = ProgramasCodigo
            DetailSecuencia = ProgramasObjEspecificoSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("ProgramasObjEspecificoId", "ProgramasCodigo", "ProgramasObjEspecificoSecuencia", "ProgramasObjEspecifico", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("ProgramasObjEspecificoId", "ProgramasCodigo", "ProgramasObjEspecificoSecuencia", "ProgramasObjEspecifico", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            ProgramasObjEspecificoInsert = ProgramasObjEspecifico.ProgramasObjEspecificoUpdate(DetailId, CStr(ProgramasCodigo), CLng(ProgramasObjEspecificoSecuencia), CStr(ProgramasObjEspecificoNombre), CStr(ProgramasObjEspecificoDescription), CStr(ProgramasObjEspecificoIndicadorLogro), CStr(ProgramasObjEspecificoResultado), CStr(ProgramasObjEspecificoRespaldo), UserId)
        Catch
            ProgramasObjEspecificoInsert = 0
        End Try
    End Function
    Public Function ProgramasObjEspecificoDelete(ByVal ProgramasObjEspecificoId As Long, ByVal ProgramasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (ProgramasObjEspecifico) "
        strUpdate = strUpdate & "WHERE (ProgramasObjEspecifico.ProgramasObjEspecificoId = " & ProgramasObjEspecificoId & ") "
        Try
            ProgramasObjEspecificoDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & ProgramasCodigo, ProgramasObjEspecificoId, "ProgramasObjEspecifico", "")
        Catch
            ProgramasObjEspecificoDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & ProgramasCodigo, ProgramasObjEspecificoId, "ProgramasObjEspecifico", "")
        End Try
    End Function
    Public Function LoadObjetivosPorProgramas(ByRef rptFunciones As Repeater, ByVal ProgramasCodigo As String) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "Select ProgramasObjEspecificoSecuencia, ProgramasObjEspecificoNombre, ProgramasObjEspecificoDescription, ProgramasObjEspecificoIndicadorLogro, ProgramasObjEspecificoResultado, ProgramasObjEspecificoRespaldo "
        sSQL = sSQL & "FROM (ProgramasObjEspecifico) "
        sSQL = sSQL & "WHERE ProgramasObjEspecifico.ProgramasCodigo = '" & ProgramasCodigo & "' "


        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptFunciones.DataSource = dtrFunciones
            rptFunciones.DataBind()
            LoadObjetivosPorProgramas = True
            dtrFunciones.Close()
        Catch
            LoadObjetivosPorProgramas = False
        End Try
    End Function
End Class
