'------------------------------------------------------------
' Código generado por ZRISMART SF el 30-03-2011 10:16:31
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class API
    Public Function LeerAPI(ByVal APIId As Long, ByRef APICodigo As String, ByRef APIName As String, ByRef APIOrganizacion As String, ByRef APIRol1 As String, ByRef APINombre1 As String, ByRef APICargo1 As String, ByRef APIOrganizacion1 As String, ByRef APIRol2 As String, ByRef APINombre2 As String, ByRef APICargo2 As String, ByRef APIOrganizacion2 As String, ByRef APIRol3 As String, ByRef APINombre3 As String, ByRef APICargo3 As String, ByRef APIOrganizacion3 As String, ByRef APIRol4 As String, ByRef APINombre4 As String, ByRef APICargo4 As String, ByRef APIOrganizacion4 As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select APICodigo, APIName, APIOrganizacion, APIRol1, APINombre1, APICargo1, APIOrganizacion1, APIRol2, APINombre2, APICargo2, APIOrganizacion2, APIRol3, APINombre3, APICargo3, APIOrganizacion3, APIRol4, APINombre4, APICargo4, APIOrganizacion4 "
        sSQL = sSQL & "FROM API "
        sSQL = sSQL & "WHERE (API.APIId = " & APIId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                APICodigo = CStr(dtr("APICodigo").ToString)
                APIName = CStr(dtr("APIName").ToString)
                APIOrganizacion = CStr(dtr("APIOrganizacion").ToString)
                APIRol1 = CStr(dtr("APIRol1").ToString)
                APINombre1 = CStr(dtr("APINombre1").ToString)
                APICargo1 = CStr(dtr("APICargo1").ToString)
                APIOrganizacion1 = CStr(dtr("APIOrganizacion1").ToString)
                APIRol2 = CStr(dtr("APIRol2").ToString)
                APINombre2 = CStr(dtr("APINombre2").ToString)
                APICargo2 = CStr(dtr("APICargo2").ToString)
                APIOrganizacion2 = CStr(dtr("APIOrganizacion2").ToString)
                APIRol3 = CStr(dtr("APIRol3").ToString)
                APINombre3 = CStr(dtr("APINombre3").ToString)
                APICargo3 = CStr(dtr("APICargo3").ToString)
                APIOrganizacion3 = CStr(dtr("APIOrganizacion3").ToString)
                APIRol4 = CStr(dtr("APIRol4").ToString)
                APINombre4 = CStr(dtr("APINombre4").ToString)
                APICargo4 = CStr(dtr("APICargo4").ToString)
                APIOrganizacion4 = CStr(dtr("APIOrganizacion4").ToString)
            End While
            LeerAPI = True
            dtr.Close()
        Catch
            LeerAPI = False
        End Try
    End Function
    Public Function LeerAPIByName(ByRef APIId As Long, ByVal APICodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select APIId "
        sSQL = sSQL & "FROM API "
        sSQL = sSQL & "WHERE (API.APICodigo = '" & APICodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                APIId = CLng(dtr("APIId").ToString)
            End While
            LeerAPIByName = True
            dtr.Close()
        Catch
            LeerAPIByName = False
        End Try
    End Function
    Public Function APIUpdate(ByVal APIId As Long, ByRef APICodigo As String, ByRef APIName As String, ByRef APIOrganizacion As String, ByRef APIRol1 As String, ByRef APINombre1 As String, ByRef APICargo1 As String, ByRef APIOrganizacion1 As String, ByRef APIRol2 As String, ByRef APINombre2 As String, ByRef APICargo2 As String, ByRef APIOrganizacion2 As String, ByRef APIRol3 As String, ByRef APINombre3 As String, ByRef APICargo3 As String, ByRef APIOrganizacion3 As String, ByRef APIRol4 As String, ByRef APINombre4 As String, ByRef APICargo4 As String, ByRef APIOrganizacion4 As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE API SET "
        strUpdate = strUpdate & "API.APICodigo = '" & APICodigo & "', "
        strUpdate = strUpdate & "API.APIName = '" & APIName & "', "
        strUpdate = strUpdate & "API.APIOrganizacion = '" & APIOrganizacion & "', "
        strUpdate = strUpdate & "API.APIRol1 = '" & APIRol1 & "', "
        strUpdate = strUpdate & "API.APINombre1 = '" & APINombre1 & "', "
        strUpdate = strUpdate & "API.APICargo1 = '" & APICargo1 & "', "
        strUpdate = strUpdate & "API.APIOrganizacion1 = '" & APIOrganizacion1 & "', "
        strUpdate = strUpdate & "API.APIRol2 = '" & APIRol2 & "', "
        strUpdate = strUpdate & "API.APINombre2 = '" & APINombre2 & "', "
        strUpdate = strUpdate & "API.APICargo2 = '" & APICargo2 & "', "
        strUpdate = strUpdate & "API.APIOrganizacion2 = '" & APIOrganizacion2 & "', "
        strUpdate = strUpdate & "API.APIRol3 = '" & APIRol3 & "', "
        strUpdate = strUpdate & "API.APINombre3 = '" & APINombre3 & "', "
        strUpdate = strUpdate & "API.APICargo3 = '" & APICargo3 & "', "
        strUpdate = strUpdate & "API.APIOrganizacion3 = '" & APIOrganizacion3 & "', "
        strUpdate = strUpdate & "API.APIRol4 = '" & APIRol4 & "', "
        strUpdate = strUpdate & "API.APINombre4 = '" & APINombre4 & "', "
        strUpdate = strUpdate & "API.APICargo4 = '" & APICargo4 & "', "
        strUpdate = strUpdate & "API.APIOrganizacion4 = '" & APIOrganizacion4 & "', "
        strUpdate = strUpdate & "API.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "API.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE API.APIId = " & APIId
        Try
            APIUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & APICodigo, APIId, "API", "")
        Catch
            APIUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & APICodigo, APIId, "API", "")
        End Try
    End Function
    Public Function APIInsert(ByRef APIId As Long, ByRef APICodigo As String, ByRef APIName As String, ByRef APIOrganizacion As String, ByRef APIRol1 As String, ByRef APINombre1 As String, ByRef APICargo1 As String, ByRef APIOrganizacion1 As String, ByRef APIRol2 As String, ByRef APINombre2 As String, ByRef APICargo2 As String, ByRef APIOrganizacion2 As String, ByRef APIRol3 As String, ByRef APINombre3 As String, ByRef APICargo3 As String, ByRef APIOrganizacion3 As String, ByRef APIRol4 As String, ByRef APINombre4 As String, ByRef APICargo4 As String, ByRef APIOrganizacion4 As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim API As New API
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = APICodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("APIId", "APICodigo", "API", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("APIId", "APICodigo", "API", MasterName, CLng(UserId), MasterId)
            End If
            APIInsert = API.APIUpdate(MasterId, CStr(APICodigo), CStr(APIName), CStr(APIOrganizacion), CStr(APIRol1), CStr(APINombre1), CStr(APICargo1), CStr(APIOrganizacion1), CStr(APIRol2), CStr(APINombre2), CStr(APICargo2), CStr(APIOrganizacion2), CStr(APIRol3), CStr(APINombre3), CStr(APICargo3), CStr(APIOrganizacion3), CStr(APIRol4), CStr(APINombre4), CStr(APICargo4), CStr(APIOrganizacion4), UserId)
        Catch
            APIInsert = 0
        End Try
    End Function
    Public Function LeerAPIDescriptionByName(ByVal APICodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select APIName "
        sSQL = sSQL & "FROM API "
        sSQL = sSQL & "WHERE (API.APICodigo = '" & APICodigo & "') "
        LeerAPIDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerAPIDescriptionByName = CStr(dtr("APIName").ToString)
            End While
            dtr.Close()
        Catch
            LeerAPIDescriptionByName = ""
        End Try
    End Function
    Public Function LeerTotalAPIPorTablasRelacionadas(ByVal APICodigo As String, ByVal APIId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim API As New API

        'Verifica si esta referenciada en un contrato
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM API INNER JOIN Contrato ON API.APICodigo = Contrato.APIName "
        sSQL = sSQL & "WHERE (((API.APICodigo)='" & APICodigo & "'))"
        LeerTotalAPIPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalAPIPorTablasRelacionadas = LeerTotalAPIPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalAPIPorTablasRelacionadas = 0
        End Try
        'Verifica si esta referenciada en algun proyecto
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM API INNER JOIN APIPorProyecto ON API.APIId = APIPorProyecto.APIId "
        sSQL = sSQL & "WHERE (((API.APIId)=" & APIId & "))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalAPIPorTablasRelacionadas = LeerTotalAPIPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalAPIPorTablasRelacionadas = LeerTotalAPIPorTablasRelacionadas + 0
        End Try

    End Function
    Public Function APIDelete(ByVal APIId As Long, ByVal APICodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim API As New API

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = API.LeerTotalAPIPorTablasRelacionadas(APICodigo, APIId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " Contratos y/o Proyectos asociados al API " & APICodigo & vbCrLf
            Mensaje = Mensaje & ", cambie el API a los Contratos y/o Proyectos, antes de eliminarla de la lista"
            APIDelete = False
        Else
            Try
                ' Borra registro de la tabla de APIPorProyecto
                '-------------------------------------
                strUpdate = "DELETE FROM APIPorProyecto WHERE APIId = " & APIId
                t = AccesoEA.ABMRegistros(strUpdate)
                ' Borra registro de la tabla de API
                '-------------------------------------
                strUpdate = "DELETE FROM API WHERE APIId = " & APIId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el API: " & APICodigo, APIId, "API", "")
                APIDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el API: " & APICodigo, APIId, "API", "")
                APIDelete = False
            End Try
        End If
    End Function
End Class
