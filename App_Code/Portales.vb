Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class Portales
    Public Function LeerURLPortal(ByVal PortalesId As Long, ByRef UrlIndex As String, ByRef Logo1 As String, ByRef Banner As String, ByRef Logo2 As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim MenuOptions As New MenuOptions

        sSQL = "Select PortalesURLIndex as URLIndex, PortalesLogo1 As Logo1, PortalesBanner As Banner, PortalesLogo2 As Logo2 "
        sSQL = sSQL & "FROM Portales "
        sSQL = sSQL & "WHERE PortalesId = " & PortalesId

        'Este metodo por ahora lee y devuelve el último registro leido, asumiendo que hay un solo registro en la tabla de portales
        'Esto debe cambiar.

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                'UrlIndex = dtr("UrlIndex").ToString
                UrlIndex = MenuOptions.ObtenerURLInicioPortal(PortalesId)
                Logo1 = dtr("Logo1").ToString
                Banner = dtr("Banner").ToString
                Logo2 = dtr("Logo2").ToString
            End While
            LeerURLPortal = True
            dtr.Close()
        Catch
            LeerURLPortal = False
        End Try
    End Function
    Public Function PortalesDelete(ByVal PortalesId As Long, ByVal PortalesName As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Portales As New Portales

        Total = Portales.LeerTotalPortalesPorMenuOptions(PortalesName)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " opciones de menu asociados al portal " & PortalesName & vbCrLf
            Mensaje = Mensaje & "Cambie las opciones de menu, antes de eliminar el portal"
            PortalesDelete = False
        Else
            Try
                strUpdate = "DELETE FROM Portales WHERE PortalesId = " & PortalesId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el portal: " & PortalesName, PortalesId, "Portales", "")
                PortalesDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el portal: " & PortalesName, PortalesId, "Portales", "")
                PortalesDelete = False
            End Try
        End If
    End Function
    Public Function LeerTotalPortalesPorMenuOptions(ByVal PortalesName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        ' Verificamos si el área esta referenciada en algún documento
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.PortalesName)='" & PortalesName & "'))"
        LeerTotalPortalesPorMenuOptions = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalPortalesPorMenuOptions = CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalPortalesPorMenuOptions = 0
        End Try
    End Function
    Public Function PortalesUpdate(ByVal PortalesId As Long, ByVal PortalesName As String, ByVal PortalesSecuencia As Long, ByVal PortalesDescription As String, ByVal PortalesURLIndex As String, ByVal PortalesLogo1 As String, ByVal PortalesBanner As String, ByVal PortalesLogo2 As String, ByVal PortalesMasterPage As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Portales SET "
        strUpdate = strUpdate & "Portales.PortalesName = '" & PortalesName & "', "
        strUpdate = strUpdate & "Portales.PortalesSecuencia = " & PortalesSecuencia & ", "
        strUpdate = strUpdate & "Portales.PortalesDescription = '" & PortalesDescription & "', "
        strUpdate = strUpdate & "Portales.PortalesURLIndex = '" & PortalesURLIndex & "', "
        strUpdate = strUpdate & "Portales.PortalesLogo1 = '" & PortalesLogo1 & "', "
        strUpdate = strUpdate & "Portales.PortalesBanner = '" & PortalesBanner & "', "
        strUpdate = strUpdate & "Portales.PortalesLogo2 = '" & PortalesLogo2 & "', "
        strUpdate = strUpdate & "Portales.PortalesMasterPage = '" & PortalesMasterPage & "', "
        strUpdate = strUpdate & "Portales.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Portales.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Portales.PortalesId = " & PortalesId
        Try
            PortalesUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & PortalesName, PortalesId, "Portales", "")
        Catch
            PortalesUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & PortalesName, PortalesId, "Portales", "")
        End Try
    End Function
    Public Function PortalesInsert(ByVal PortalesId As Long, ByVal PortalesName As String, ByVal PortalesSecuencia As Long, ByVal PortalesDescription As String, ByVal PortalesURLIndex As String, ByVal PortalesLogo1 As String, ByVal PortalesBanner As String, ByVal PortalesLogo2 As String, ByVal PortalesMasterPage As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Portales As New Portales
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = PortalesName
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("PortalesId", "PortalesName", "Portales", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("PortalesId", "PortalesName", "Portales", MasterName, CLng(UserId), MasterId)
            End If
            PortalesInsert = Portales.PortalesUpdate(MasterId, CStr(PortalesName), CLng(PortalesSecuencia), CStr(PortalesDescription), CStr(PortalesURLIndex), CStr(PortalesLogo1), CStr(PortalesBanner), CStr(PortalesLogo2), CStr(PortalesMasterPage), UserId)
        Catch
            PortalesInsert = 0
        End Try
    End Function
    Public Function LeerPortalesId(ByVal PortalesName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PortalesId as Id "
        sSQL = sSQL & "FROM Portales "
        sSQL = sSQL & "WHERE Portales.PortalesName = '" & PortalesName & "' "
        LeerPortalesId = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerPortalesId = CLng(dtr("Id").ToString)
            End While
            dtr.Close()
        Catch
            LeerPortalesId = 0
        End Try
    End Function
    Public Function LeerPortalesName(ByVal PortalesId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PortalesName as Name "
        sSQL = sSQL & "FROM Portales "
        sSQL = sSQL & "WHERE Portales.PortalesId = " & PortalesId
        LeerPortalesName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerPortalesName = CStr(dtr("Name").ToString)
            End While
            dtr.Close()
        Catch
            LeerPortalesName = ""
        End Try
    End Function
    Public Function LeerPortales(ByVal PortalesId As Long, ByRef PortalesName As String, ByRef PortalesSecuencia As Long, ByRef PortalesDescription As String, ByRef PortalesURLIndex As String, ByRef PortalesLogo1 As String, ByRef PortalesBanner As String, ByRef PortalesLogo2 As String, ByRef PortalesMasterPage As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PortalesName, PortalesSecuencia, PortalesDescription, PortalesURLIndex, PortalesLogo1, PortalesBanner, PortalesLogo2, PortalesMasterPage "
        sSQL = sSQL & "FROM Portales "
        sSQL = sSQL & "WHERE Portales.PortalesId = " & PortalesId
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                PortalesName = CStr(dtr("PortalesName").ToString)
                If Len(dtr("PortalesSecuencia").ToString) = 0 Then
                    PortalesSecuencia = 0
                Else
                    PortalesSecuencia = CLng(dtr("PortalesSecuencia").ToString)
                End If
                PortalesDescription = CStr(dtr("PortalesDescription").ToString)
                PortalesURLIndex = CStr(dtr("PortalesURLIndex").ToString)
                PortalesLogo1 = CStr(dtr("PortalesLogo1").ToString)
                PortalesBanner = CStr(dtr("PortalesBanner").ToString)
                PortalesLogo2 = CStr(dtr("PortalesLogo2").ToString)
                PortalesMasterPage = CStr(dtr("PortalesMasterPage").ToString)
            End While
            LeerPortales = True
            dtr.Close()
        Catch
            LeerPortales = False
        End Try
    End Function
    Public Function LeerURLIndexMasterPage(ByVal PortalesName As String, ByRef PortalesUrlIndex As String, ByRef PortalesMasterPage As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select PortalesURLIndex as URLIndex, PortalesMasterPage as MasterPage "
        sSQL = sSQL & "FROM Portales "
        sSQL = sSQL & "WHERE PortalesName = '" & PortalesName & "'"

        LeerURLIndexMasterPage = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                PortalesUrlIndex = dtr("URLIndex").ToString
                PortalesMasterPage = dtr("MasterPage").ToString
            End While
            LeerURLIndexMasterPage = True
            dtr.Close()
        Catch
            LeerURLIndexMasterPage = False
        End Try
    End Function
    Public Function LoadPortalesName(ByRef rptFunciones As DropDownList) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT PortalesName, PortalesId "
        sSQL = sSQL & "FROM Portales "
        sSQL = sSQL & "ORDER by PortalesSecuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptFunciones.DataSource = dtrFunciones
            rptFunciones.DataTextField = "PortalesName"
            rptFunciones.DataValueField = "PortalesId"
            rptFunciones.DataBind()
            rptFunciones.SelectedIndex = 0
            LoadPortalesName = True
            dtrFunciones.Close()
        Catch
            LoadPortalesName = False
        End Try
    End Function
End Class
