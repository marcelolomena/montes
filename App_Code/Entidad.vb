'------------------------------------------------------------
' Código generado por ZRISMART SF el 25-08-2010 9:56:21
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Entidad
    Public Function LeerEntidad(ByVal EntidadId As Long, ByRef EntidadNombreTabla As String, ByRef EntidadNombreEntidad As String, ByRef EntidadDescription As String, ByRef EntidadTipo As String, ByRef EntidadCampoId As String, ByRef EntidadCampoName As String, ByRef EntidadCampoSecuencia As String, ByRef EntidadNombreTablaPadre As String, ByRef EntidadMasterId As String, ByRef EntidadMasterName As String, ByRef EntidadNombreClase As String, ByRef EntidadServicioLectura As String, ByRef EntidadServicioUpdate As String, ByRef EntidadServicioInsert As String, ByRef EntidadVistaMantener As String, ByRef EntidadVistaBuscar As String, ByRef EntidadVistaValidar As String, ByRef EntidadVistaListar As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EntidadNombreTabla, EntidadNombreEntidad, EntidadDescription, EntidadTipo, EntidadCampoId, EntidadCampoName, EntidadCampoSecuencia, EntidadNombreTablaPadre, EntidadMasterId, EntidadMasterName, EntidadNombreClase, EntidadServicioLectura, EntidadServicioUpdate, EntidadServicioInsert, EntidadVistaMantener, EntidadVistaBuscar, EntidadVistaValidar, EntidadVistaListar "
        sSQL = sSQL & "FROM (Entidad) "
        sSQL = sSQL & "WHERE (Entidad.EntidadId = " & EntidadId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                EntidadNombreTabla = CStr(dtr("EntidadNombreTabla").ToString)
                EntidadNombreEntidad = CStr(dtr("EntidadNombreEntidad").ToString)
                EntidadDescription = CStr(dtr("EntidadDescription").ToString)
                EntidadTipo = CStr(dtr("EntidadTipo").ToString)
                EntidadCampoId = CStr(dtr("EntidadCampoId").ToString)
                EntidadCampoName = CStr(dtr("EntidadCampoName").ToString)
                EntidadCampoSecuencia = CStr(dtr("EntidadCampoSecuencia").ToString)
                EntidadNombreTablaPadre = CStr(dtr("EntidadNombreTablaPadre").ToString)
                EntidadMasterId = CStr(dtr("EntidadMasterId").ToString)
                EntidadMasterName = CStr(dtr("EntidadMasterName").ToString)
                EntidadNombreClase = CStr(dtr("EntidadNombreClase").ToString)
                EntidadServicioLectura = CStr(dtr("EntidadServicioLectura").ToString)
                EntidadServicioUpdate = CStr(dtr("EntidadServicioUpdate").ToString)
                EntidadServicioInsert = CStr(dtr("EntidadServicioInsert").ToString)
                EntidadVistaMantener = CStr(dtr("EntidadVistaMantener").ToString)
                EntidadVistaBuscar = CStr(dtr("EntidadVistaBuscar").ToString)
                EntidadVistaValidar = CStr(dtr("EntidadVistaValidar").ToString)
                EntidadVistaListar = CStr(dtr("EntidadVistaListar").ToString)
            End While
            LeerEntidad = True
            dtr.Close()
        Catch
            LeerEntidad = False
        End Try
    End Function
    Public Function LeerEntidadByName(ByRef EntidadId As Long, ByRef EntidadNombreTabla As String, ByRef EntidadNombreEntidad As String, ByRef EntidadDescription As String, ByRef EntidadTipo As String, ByRef EntidadCampoId As String, ByRef EntidadCampoName As String, ByRef EntidadCampoSecuencia As String, ByRef EntidadNombreTablaPadre As String, ByRef EntidadMasterId As String, ByRef EntidadMasterName As String, ByRef EntidadNombreClase As String, ByRef EntidadServicioLectura As String, ByRef EntidadServicioUpdate As String, ByRef EntidadServicioInsert As String, ByRef EntidadVistaMantener As String, ByRef EntidadVistaBuscar As String, ByRef EntidadVistaValidar As String, ByRef EntidadVistaListar As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EntidadId, EntidadNombreEntidad, EntidadDescription, EntidadTipo, EntidadCampoId, EntidadCampoName, EntidadCampoSecuencia, EntidadNombreTablaPadre, EntidadMasterId, EntidadMasterName, EntidadNombreClase, EntidadServicioLectura, EntidadServicioUpdate, EntidadServicioInsert, EntidadVistaMantener, EntidadVistaBuscar, EntidadVistaValidar, EntidadVistaListar "
        sSQL = sSQL & "FROM (Entidad) "
        sSQL = sSQL & "WHERE (Entidad.EntidadNombreTabla = '" & EntidadNombreTabla & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                EntidadId = CLng(dtr("EntidadId").ToString)
                EntidadNombreEntidad = CStr(dtr("EntidadNombreEntidad").ToString)
                EntidadDescription = CStr(dtr("EntidadDescription").ToString)
                EntidadTipo = CStr(dtr("EntidadTipo").ToString)
                EntidadCampoId = CStr(dtr("EntidadCampoId").ToString)
                EntidadCampoName = CStr(dtr("EntidadCampoName").ToString)
                EntidadCampoSecuencia = CStr(dtr("EntidadCampoSecuencia").ToString)
                EntidadNombreTablaPadre = CStr(dtr("EntidadNombreTablaPadre").ToString)
                EntidadMasterId = CStr(dtr("EntidadMasterId").ToString)
                EntidadMasterName = CStr(dtr("EntidadMasterName").ToString)
                EntidadNombreClase = CStr(dtr("EntidadNombreClase").ToString)
                EntidadServicioLectura = CStr(dtr("EntidadServicioLectura").ToString)
                EntidadServicioUpdate = CStr(dtr("EntidadServicioUpdate").ToString)
                EntidadServicioInsert = CStr(dtr("EntidadServicioInsert").ToString)
                EntidadVistaMantener = CStr(dtr("EntidadVistaMantener").ToString)
                EntidadVistaBuscar = CStr(dtr("EntidadVistaBuscar").ToString)
                EntidadVistaValidar = CStr(dtr("EntidadVistaValidar").ToString)
                EntidadVistaListar = CStr(dtr("EntidadVistaListar").ToString)
            End While
            LeerEntidadByName = True
            dtr.Close()
        Catch
            LeerEntidadByName = False
        End Try
    End Function
    Public Function EntidadUpdate(ByVal EntidadId As Long, ByRef EntidadNombreTabla As String, ByRef EntidadNombreEntidad As String, ByRef EntidadDescription As String, ByRef EntidadTipo As String, ByRef EntidadCampoId As String, ByRef EntidadCampoName As String, ByRef EntidadCampoSecuencia As String, ByRef EntidadNombreTablaPadre As String, ByRef EntidadMasterId As String, ByRef EntidadMasterName As String, ByRef EntidadNombreClase As String, ByRef EntidadServicioLectura As String, ByRef EntidadServicioUpdate As String, ByRef EntidadServicioInsert As String, ByRef EntidadVistaMantener As String, ByRef EntidadVistaBuscar As String, ByRef EntidadVistaValidar As String, ByRef EntidadVistaListar As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Entidad SET "
        strUpdate = strUpdate & "Entidad.EntidadNombreTabla = '" & EntidadNombreTabla & "', "
        strUpdate = strUpdate & "Entidad.EntidadNombreEntidad = '" & EntidadNombreEntidad & "', "
        strUpdate = strUpdate & "Entidad.EntidadDescription = '" & EntidadDescription & "', "
        strUpdate = strUpdate & "Entidad.EntidadTipo = '" & EntidadTipo & "', "
        strUpdate = strUpdate & "Entidad.EntidadCampoId = '" & EntidadCampoId & "', "
        strUpdate = strUpdate & "Entidad.EntidadCampoName = '" & EntidadCampoName & "', "
        strUpdate = strUpdate & "Entidad.EntidadCampoSecuencia = '" & EntidadCampoSecuencia & "', "
        strUpdate = strUpdate & "Entidad.EntidadNombreTablaPadre = '" & EntidadNombreTablaPadre & "', "
        strUpdate = strUpdate & "Entidad.EntidadMasterId = '" & EntidadMasterId & "', "
        strUpdate = strUpdate & "Entidad.EntidadMasterName = '" & EntidadMasterName & "', "
        strUpdate = strUpdate & "Entidad.EntidadNombreClase = '" & EntidadNombreClase & "', "
        strUpdate = strUpdate & "Entidad.EntidadServicioLectura = '" & EntidadServicioLectura & "', "
        strUpdate = strUpdate & "Entidad.EntidadServicioUpdate = '" & EntidadServicioUpdate & "', "
        strUpdate = strUpdate & "Entidad.EntidadServicioInsert = '" & EntidadServicioInsert & "', "
        strUpdate = strUpdate & "Entidad.EntidadVistaMantener = '" & EntidadVistaMantener & "', "
        strUpdate = strUpdate & "Entidad.EntidadVistaBuscar = '" & EntidadVistaBuscar & "', "
        strUpdate = strUpdate & "Entidad.EntidadVistaValidar = '" & EntidadVistaValidar & "', "
        strUpdate = strUpdate & "Entidad.EntidadVistaListar = '" & EntidadVistaListar & "', "
        strUpdate = strUpdate & "Entidad.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Entidad.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Entidad.EntidadId = " & EntidadId
        Try
            EntidadUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & EntidadNombreTabla, EntidadId, "Entidad", "")
        Catch
            EntidadUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & EntidadNombreTabla, EntidadId, "Entidad", "")
        End Try
    End Function
    Public Function EntidadInsert(ByRef EntidadId As Long, ByRef EntidadNombreTabla As String, ByRef EntidadNombreEntidad As String, ByRef EntidadDescription As String, ByRef EntidadTipo As String, ByRef EntidadCampoId As String, ByRef EntidadCampoName As String, ByRef EntidadCampoSecuencia As String, ByRef EntidadNombreTablaPadre As String, ByRef EntidadMasterId As String, ByRef EntidadMasterName As String, ByRef EntidadNombreClase As String, ByRef EntidadServicioLectura As String, ByRef EntidadServicioUpdate As String, ByRef EntidadServicioInsert As String, ByRef EntidadVistaMantener As String, ByRef EntidadVistaBuscar As String, ByRef EntidadVistaValidar As String, ByRef EntidadVistaListar As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Entidad As New Entidad
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Try
            MasterName = EntidadNombreTabla
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("EntidadId", "EntidadNombreTabla", "Entidad", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("EntidadId", "EntidadNombreTabla", "Entidad", MasterName, CLng(UserId), MasterId)
            End If
            EntidadInsert = Entidad.EntidadUpdate(MasterId, CStr(EntidadNombreTabla), CStr(EntidadNombreEntidad), CStr(EntidadDescription), CStr(EntidadTipo), CStr(EntidadCampoId), CStr(EntidadCampoName), CStr(EntidadCampoSecuencia), CStr(EntidadNombreTablaPadre), CStr(EntidadMasterId), CStr(EntidadMasterName), CStr(EntidadNombreClase), CStr(EntidadServicioLectura), CStr(EntidadServicioUpdate), CStr(EntidadServicioInsert), CStr(EntidadVistaMantener), CStr(EntidadVistaBuscar), CStr(EntidadVistaValidar), CStr(EntidadVistaListar), UserId)
        Catch
            EntidadInsert = 0
        End Try
    End Function
    Public Function LeerSchema(ByVal sSQL As String, _
                               ByRef arrLabel() As String, _
                               ByRef arrItem(,) As String, _
                               ByRef i As Integer, _
                               ByRef j As Integer) As Boolean

        Dim AccesoEA = New AccesoEA
        Dim dtr As IDataReader
        Dim dtrSchema As DataTable
        Dim dtrColumn As DataColumn
        Dim dtrItem As DataRow

        i = 0
        Try
            dtr = AccesoEA.ObtenerSchema(sSQL)
            dtrSchema = dtr.GetSchemaTable()

            'For i = 0 To dtrSchema.Columns.Count - 1
            'arrLabel(i) = dtrSchema.Columns(i).ColumnName.ToString() & " " & dtrSchema.Columns(i).DataType.ToString()
            'Next

            For Each dtrColumn In dtrSchema.Columns
                arrLabel(i) = dtrColumn.ColumnName

                j = 0
                For Each dtrItem In dtrSchema.Rows
                    arrItem(i, j) = dtrItem(dtrColumn).ToString
                    j = j + 1

                Next
                i = i + 1
            Next

            LeerSchema = True
            dtr.Close()
        Catch
            LeerSchema = False
        End Try

    End Function
    Public Function LeerEntidadTipo(ByVal EntidadNombreTabla As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EntidadTipo "
        sSQL = sSQL & "FROM (Entidad) "
        sSQL = sSQL & "WHERE (Entidad.EntidadNombreTabla = '" & EntidadNombreTabla & "') "
        LeerEntidadTipo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerEntidadTipo = CStr(dtr("EntidadTipo").ToString)
            End While
            dtr.Close()
        Catch
            LeerEntidadTipo = ""
        End Try
    End Function
    Public Function LeerEntidadVistaMantenerPadre(ByVal EntidadNombreTabla As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Entidad_1.EntidadVistaMantener As FichaPadre "
        sSQL = sSQL & "FROM Entidad INNER JOIN Entidad AS Entidad_1 ON Entidad.EntidadNombreTablaPadre = Entidad_1.EntidadNombreTabla "
        sSQL = sSQL & "WHERE (((Entidad.EntidadNombreTabla)='" & EntidadNombreTabla & "')) "

        LeerEntidadVistaMantenerPadre = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerEntidadVistaMantenerPadre = CStr(dtr("FichaPadre").ToString)
            End While
            dtr.Close()
        Catch
            LeerEntidadVistaMantenerPadre = ""
        End Try
    End Function
    Public Function LeerCampoCodigo(ByVal EntidadNombreTabla As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EntidadCampoName "
        sSQL = sSQL & "FROM (Entidad) "
        sSQL = sSQL & "WHERE (Entidad.EntidadNombreTabla = '" & EntidadNombreTabla & "') "
        LeerCampoCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerCampoCodigo = CStr(dtr("EntidadCampoName").ToString)
            End While
            dtr.Close()
        Catch
            LeerCampoCodigo = ""
        End Try
    End Function
End Class
