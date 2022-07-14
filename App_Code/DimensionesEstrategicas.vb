'------------------------------------------------------------
' Código generado por ZRISMART SF el 09-08-2011 20:45:40
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class DimensionesEstrategicas
    Public Function LeerDimensionesEstrategicas(ByVal DimensionesEstrategicasId As Long, ByRef DimensionesEstrategicasCodigo As String, ByRef DimensionesEstrategicasName As String, ByRef DimensionesEstrategicasDescription As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select DimensionesEstrategicasCodigo, DimensionesEstrategicasName, DimensionesEstrategicasDescription "
        sSQL = sSQL & "FROM (DimensionesEstrategicas) "
        sSQL = sSQL & "WHERE (DimensionesEstrategicas.DimensionesEstrategicasId = " & DimensionesEstrategicasId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                DimensionesEstrategicasCodigo = CStr(dtr("DimensionesEstrategicasCodigo").ToString)
                DimensionesEstrategicasName = CStr(dtr("DimensionesEstrategicasName").ToString)
                DimensionesEstrategicasDescription = CStr(dtr("DimensionesEstrategicasDescription").ToString)
            End While
            LeerDimensionesEstrategicas = True
            dtr.Close()
        Catch
            LeerDimensionesEstrategicas = False
        End Try
    End Function
    Public Function LeerDimensionesEstrategicasByName(ByRef DimensionesEstrategicasId As Long, ByVal DimensionesEstrategicasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select DimensionesEstrategicasId "
        sSQL = sSQL & "FROM (DimensionesEstrategicas) "
        sSQL = sSQL & "WHERE (DimensionesEstrategicas.DimensionesEstrategicasCodigo = '" & DimensionesEstrategicasCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                DimensionesEstrategicasId = CLng(dtr("DimensionesEstrategicasId").ToString)
            End While
            LeerDimensionesEstrategicasByName = True
            dtr.Close()
        Catch
            LeerDimensionesEstrategicasByName = False
        End Try
    End Function
    Public Function LeerDimensionesEstrategicasDescriptionByName(ByVal DimensionesEstrategicasCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select DimensionesEstrategicasName "
        sSQL = sSQL & "FROM (DimensionesEstrategicas) "
        sSQL = sSQL & "WHERE (DimensionesEstrategicas.DimensionesEstrategicasCodigo = '" & DimensionesEstrategicasCodigo & "') "
        LeerDimensionesEstrategicasDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerDimensionesEstrategicasDescriptionByName = CStr(dtr("DimensionesEstrategicasName").ToString)
            End While
            dtr.Close()
        Catch
            LeerDimensionesEstrategicasDescriptionByName = ""
        End Try
    End Function
    Public Function DimensionesEstrategicasUpdate(ByVal DimensionesEstrategicasId As Long, ByRef DimensionesEstrategicasCodigo As String, ByRef DimensionesEstrategicasName As String, ByRef DimensionesEstrategicasDescription As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE DimensionesEstrategicas SET "
        strUpdate = strUpdate & "DimensionesEstrategicas.DimensionesEstrategicasCodigo = '" & DimensionesEstrategicasCodigo & "', "
        strUpdate = strUpdate & "DimensionesEstrategicas.DimensionesEstrategicasName = '" & DimensionesEstrategicasName & "', "
        strUpdate = strUpdate & "DimensionesEstrategicas.DimensionesEstrategicasDescription = '" & DimensionesEstrategicasDescription & "', "
        strUpdate = strUpdate & "DimensionesEstrategicas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "DimensionesEstrategicas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE DimensionesEstrategicas.DimensionesEstrategicasId = " & DimensionesEstrategicasId
        Try
            DimensionesEstrategicasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & DimensionesEstrategicasCodigo, DimensionesEstrategicasId, "DimensionesEstrategicas", "")
        Catch
            DimensionesEstrategicasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & DimensionesEstrategicasCodigo, DimensionesEstrategicasId, "DimensionesEstrategicas", "")
        End Try
    End Function
    Public Function DimensionesEstrategicasInsert(ByRef DimensionesEstrategicasId As Long, ByRef DimensionesEstrategicasCodigo As String, ByRef DimensionesEstrategicasName As String, ByRef DimensionesEstrategicasDescription As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim DimensionesEstrategicas As New DimensionesEstrategicas
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = DimensionesEstrategicasCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("DimensionesEstrategicasId", "DimensionesEstrategicasCodigo", "DimensionesEstrategicas", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("DimensionesEstrategicasId", "DimensionesEstrategicasCodigo", "DimensionesEstrategicas", MasterName, CLng(UserId), MasterId)
            End If
            DimensionesEstrategicasInsert = DimensionesEstrategicas.DimensionesEstrategicasUpdate(MasterId, CStr(DimensionesEstrategicasCodigo), CStr(DimensionesEstrategicasName), CStr(DimensionesEstrategicasDescription), UserId)
        Catch
            DimensionesEstrategicasInsert = 0
        End Try
    End Function
    Public Function LeerTotalDimensionesEstrategicasPorTablasRelacionadas(ByVal DimensionesEstrategicasCodigo As String, ByVal DimensionesEstrategicasId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en una Iniciativa
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM DimensionesEstrategicas INNER JOIN IniciativasEstrategicas ON DimensionesEstrategicas.DimensionesEstrategicasCodigo = IniciativasEstrategicas.DimensionesEstrategicasCodigo "
        sSQL = sSQL & "WHERE (((DimensionesEstrategicas.DimensionesEstrategicasCodigo)='" & DimensionesEstrategicasCodigo & "'))"
        LeerTotalDimensionesEstrategicasPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalDimensionesEstrategicasPorTablasRelacionadas = LeerTotalDimensionesEstrategicasPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalDimensionesEstrategicasPorTablasRelacionadas = 0
        End Try
        'Verifica si esta referenciada en una Mision
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM DimensionesEstrategicas INNER JOIN DimensionesPorMision ON DimensionesEstrategicas.DimensionesEstrategicasId = DimensionesPorMision.DimensionesEstrategicasId "
        sSQL = sSQL & "WHERE (((DimensionesEstrategicas.DimensionesEstrategicasId)='" & DimensionesEstrategicasId & "'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalDimensionesEstrategicasPorTablasRelacionadas = LeerTotalDimensionesEstrategicasPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalDimensionesEstrategicasPorTablasRelacionadas = LeerTotalDimensionesEstrategicasPorTablasRelacionadas + 0
        End Try
    End Function
    Public Function DimensionesEstrategicasDelete(ByVal DimensionesEstrategicasId As Long, ByVal DimensionesEstrategicasCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim DimensionesEstrategicas As New DimensionesEstrategicas

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = DimensionesEstrategicas.LeerTotalDimensionesEstrategicasPorTablasRelacionadas(DimensionesEstrategicasCodigo, DimensionesEstrategicasId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados a la Dimensiones Estrategica " & DimensionesEstrategicasCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie la Dimensión Estrategica en las Misiones e Iniciativas, antes de eliminarla de la lista"
            DimensionesEstrategicasDelete = False
        Else
            Try
                ' Borra registro de la tabla de Gerencias
                '-------------------------------------
                strUpdate = "DELETE FROM DimensionesEstrategicas WHERE DimensionesEstrategicasId = " & DimensionesEstrategicasId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina la Dimensión Estrategica: " & DimensionesEstrategicasCodigo, DimensionesEstrategicasId, "DimensionesEstrategicas", "")
                DimensionesEstrategicasDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la Dimensión Estrategica: " & DimensionesEstrategicasCodigo, DimensionesEstrategicasId, "DimensionesEstrategicas", "")
                DimensionesEstrategicasDelete = False
            End Try
        End If
    End Function
    Public Function MostrarProgramasPorDimensiones(ByRef CodigoHTML As String, ByVal IsAuthorizedUser As Boolean) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim strUpdate As String
        Dim Programas As New Programas

        strUpdate = "SELECT DimensionesEstrategicas.DimensionesEstrategicasCodigo As Codigo, DimensionesEstrategicas.DimensionesEstrategicasName As Name "
        strUpdate = strUpdate & "FROM(DimensionesEstrategicas) "
        strUpdate = strUpdate & "ORDER BY DimensionesEstrategicas.DimensionesEstrategicasId"

        MostrarProgramasPorDimensiones = False

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read

                CodigoHTML = CodigoHTML & "<div class=""AccordionPanel"">"
                CodigoHTML = CodigoHTML & "<div class=""AccordionPanelTab"">"
                CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td><h2>" & dtr("Name").ToString & "</h2></td>"
                CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & dtr("Codigo").ToString & "')"" /></td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "</table>"
                CodigoHTML = CodigoHTML & "</div>"
                CodigoHTML = CodigoHTML & "<div class=""AccordionPanelContent"" id=""subgrilla" & dtr("Codigo").ToString & """ class=""visible"">"
                CodigoHTML = CodigoHTML & Programas.ListarProgramasPorDimension(dtr("Codigo").ToString, IsAuthorizedUser)
                CodigoHTML = CodigoHTML & "</div>"
                CodigoHTML = CodigoHTML & "</div>"
                MostrarProgramasPorDimensiones = True
            End While
            dtr.Close()
        Catch
            MostrarProgramasPorDimensiones = False
        End Try

    End Function
End Class
