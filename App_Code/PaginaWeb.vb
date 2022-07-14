'------------------------------------------------------------
' Código generado por ZRISMART SF el 25-08-2010 17:45:08
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class PaginaWeb
    Public Function LeerPaginaWeb(ByVal PaginaWebId As Long, ByRef PaginaWebName As String, ByRef PaginaWebTitle As String, ByRef PaginaWebDescription As String, ByRef PaginaWebDescription2 As String, ByRef FormularioWebNumber As Long, ByRef PaginaWebGroupValidation As String, ByRef PaginaWebStereotype As String, ByRef PaginaWebUserControl As String, ByRef EntidadNombreTabla As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PaginaWebName, PaginaWebTitle, PaginaWebDescription, PaginaWebDescription2, FormularioWebNumber, PaginaWebGroupValidation, PaginaWebStereotype, PaginaWebUserControl, EntidadNombreTabla "
        sSQL = sSQL & "FROM (PaginaWeb) "
        sSQL = sSQL & "WHERE (PaginaWeb.PaginaWebId = " & PaginaWebId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                PaginaWebName = CStr(dtr("PaginaWebName").ToString)
                PaginaWebTitle = CStr(dtr("PaginaWebTitle").ToString)
                PaginaWebDescription = CStr(dtr("PaginaWebDescription").ToString)
                PaginaWebDescription2 = CStr(dtr("PaginaWebDescription2").ToString)
                FormularioWebNumber = CLng(dtr("FormularioWebNumber").ToString)
                PaginaWebGroupValidation = CStr(dtr("PaginaWebGroupValidation").ToString)
                PaginaWebStereotype = CStr(dtr("PaginaWebStereotype").ToString)
                PaginaWebUserControl = CStr(dtr("PaginaWebUserControl").ToString)
                EntidadNombreTabla = CStr(dtr("EntidadNombreTabla").ToString)
            End While
            LeerPaginaWeb = True
            dtr.Close()
        Catch
            LeerPaginaWeb = False
        End Try
    End Function
    Public Function PaginaWebUpdate(ByVal PaginaWebId As Long, ByRef PaginaWebName As String, ByRef PaginaWebTitle As String, ByRef PaginaWebDescription As String, ByRef PaginaWebDescription2 As String, ByRef FormularioWebNumber As Long, ByRef PaginaWebGroupValidation As String, ByRef PaginaWebStereotype As String, ByRef PaginaWebUserControl As String, ByRef EntidadNombreTabla As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE PaginaWeb SET "
        strUpdate = strUpdate & "PaginaWeb.PaginaWebName = '" & PaginaWebName & "', "
        strUpdate = strUpdate & "PaginaWeb.PaginaWebTitle = '" & PaginaWebTitle & "', "
        strUpdate = strUpdate & "PaginaWeb.PaginaWebDescription = '" & PaginaWebDescription & "', "
        strUpdate = strUpdate & "PaginaWeb.PaginaWebDescription2 = '" & PaginaWebDescription2 & "', "
        strUpdate = strUpdate & "PaginaWeb.FormularioWebNumber = " & FormularioWebNumber & ", "
        strUpdate = strUpdate & "PaginaWeb.PaginaWebGroupValidation = '" & PaginaWebGroupValidation & "', "
        strUpdate = strUpdate & "PaginaWeb.PaginaWebStereotype = '" & PaginaWebStereotype & "', "
        strUpdate = strUpdate & "PaginaWeb.PaginaWebUserControl = '" & PaginaWebUserControl & "', "
        strUpdate = strUpdate & "PaginaWeb.EntidadNombreTabla = '" & EntidadNombreTabla & "', "
        strUpdate = strUpdate & "PaginaWeb.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "PaginaWeb.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE PaginaWeb.PaginaWebId = " & PaginaWebId
        Try
            PaginaWebUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & PaginaWebName, PaginaWebId, "PaginaWeb", "")
        Catch
            PaginaWebUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & PaginaWebName, PaginaWebId, "PaginaWeb", "")
        End Try
    End Function
    Public Function PaginaWebInsert(ByRef PaginaWebId As Long, ByRef PaginaWebName As String, ByRef PaginaWebTitle As String, ByRef PaginaWebDescription As String, ByRef PaginaWebDescription2 As String, ByRef FormularioWebNumber As Long, ByRef PaginaWebGroupValidation As String, ByRef PaginaWebStereotype As String, ByRef PaginaWebUserControl As String, ByRef EntidadNombreTabla As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim PaginaWeb As New PaginaWeb
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Try
            MasterName = PaginaWebName
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("PaginaWebId", "PaginaWebName", "PaginaWeb", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("PaginaWebId", "PaginaWebName", "PaginaWeb", MasterName, CLng(UserId), MasterId)
            End If
            PaginaWebInsert = PaginaWeb.PaginaWebUpdate(MasterId, CStr(PaginaWebName), CStr(PaginaWebTitle), CStr(PaginaWebDescription), CStr(PaginaWebDescription2), CLng(FormularioWebNumber), CStr(PaginaWebGroupValidation), CStr(PaginaWebStereotype), CStr(PaginaWebUserControl), CStr(EntidadNombreTabla), UserId)
        Catch
            PaginaWebInsert = 0
        End Try
    End Function
    Public Function LeerPaginaWebTitle(ByVal PaginaWebName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PaginaWebTitle "
        sSQL = sSQL & "FROM (PaginaWeb) "
        sSQL = sSQL & "WHERE (PaginaWeb.PaginaWebName = '" & PaginaWebName & "') "
        LeerPaginaWebTitle = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerPaginaWebTitle = CStr(dtr("PaginaWebTitle").ToString)
            End While
            dtr.Close()
        Catch
            LeerPaginaWebTitle = ""
        End Try
    End Function
    Public Function LeerPivotTable(ByVal PaginaWebName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EntidadNombreTabla "
        sSQL = sSQL & "FROM (PaginaWeb) "
        sSQL = sSQL & "WHERE (PaginaWeb.PaginaWebName = '" & PaginaWebName & "') "
        LeerPivotTable = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerPivotTable = CStr(dtr("EntidadNombreTabla").ToString)
            End While
            dtr.Close()
        Catch
            LeerPivotTable = ""
        End Try
    End Function
    Public Function MostrarListaNovedades(ByVal PaginaWebName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PaginaWebNovedades "
        sSQL = sSQL & "FROM (PaginaWeb) "
        sSQL = sSQL & "WHERE (PaginaWeb.PaginaWebName = '" & PaginaWebName & "') "
        MostrarListaNovedades = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                MostrarListaNovedades = CBool(dtr("PaginaWebNovedades").ToString)
            End While
            dtr.Close()
        Catch
            MostrarListaNovedades = False
        End Try
    End Function
    Public Function PaginaWebTitle(ByVal PaginaWebName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PaginaWebTitle "
        sSQL = sSQL & "FROM PaginaWeb "
        sSQL = sSQL & "WHERE PaginaWeb.PaginaWebName = '" & PaginaWebName & "' "
        PaginaWebTitle = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                PaginaWebTitle = CStr(dtr("PaginaWebTitle").ToString)
            End While
            dtr.Close()
        Catch
            PaginaWebTitle = ""
        End Try
    End Function
    Public Function EntidadNombreTabla(ByVal PaginaWebName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EntidadNombreTabla "
        sSQL = sSQL & "FROM PaginaWeb "
        sSQL = sSQL & "WHERE PaginaWeb.PaginaWebName = '" & PaginaWebName & "' "
        EntidadNombreTabla = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                EntidadNombreTabla = CStr(dtr("EntidadNombreTabla").ToString)
            End While
            dtr.Close()
        Catch
            EntidadNombreTabla = ""
        End Try
    End Function
End Class
