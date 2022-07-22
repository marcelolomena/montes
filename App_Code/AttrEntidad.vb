'------------------------------------------------------------
' Código generado por ZRISMART SF el 25-08-2010 11:21:58
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class AttrEntidad
    Public Function LeerAttrEntidad(ByVal AttrEntidadId As Long, ByRef EntidadNombreTabla As String, ByRef AttrEntidadSecuencia As Long, ByRef AttrEntidadColumnName As String, ByRef AttrEntidadColumnDescription As String, ByRef AttrEntidadColumnOrdinal As Long, ByRef AttrEntidadColumnDataType As String, ByRef AttrEntidadColumnSize As Long, ByRef AttrEntidadIsRequerido As Boolean, ByRef AttrEntidadDomainField As String, ByRef AttrEntidadIsForeignKey As Boolean, ByRef AttrEntidadForeignTable As String, ByRef AttrEntidadForeignSQL As String, ByRef AttrEntidadColumnLabel As String, ByRef AttrEntidadColumnControlName As String, ByRef AttrEntidadColumnControlBase As String, ByRef AttrEntidadColumnTextMode As Long, ByRef AttrEntidadColumnToolTip As String, ByRef AttrEntidadIsFilterField As Boolean, ByRef AttrEntidadIsColumnField As Boolean, ByRef AttrEntidadColumnNumber As Long, ByRef AttrEntidadColumnHeader As String, ByRef AttrEntidadIsInVistaValidar As Boolean, ByRef AttrEntidadIsEnabledInVistaMantener As Boolean, ByRef AttrEntidadIsAutocomplete As Boolean, ByRef AttrEntidadAutocompleteMethod As String, ByRef AttrEntidadColumnGroupNumber As Long, ByRef AttrEntidadColumnGroupOrdinal As Long, ByRef AttrEntidadColumnGroupName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EntidadNombreTabla, AttrEntidadSecuencia, AttrEntidadColumnName, AttrEntidadColumnDescription, AttrEntidadColumnOrdinal, AttrEntidadColumnDataType, AttrEntidadColumnSize, AttrEntidadIsRequerido, AttrEntidadDomainField, AttrEntidadIsForeignKey, AttrEntidadForeignTable, AttrEntidadForeignSQL, AttrEntidadColumnLabel, AttrEntidadColumnControlName, AttrEntidadColumnControlBase, AttrEntidadColumnTextMode, AttrEntidadColumnToolTip, AttrEntidadIsFilterField, AttrEntidadIsColumnField, AttrEntidadColumnNumber, AttrEntidadColumnHeader, AttrEntidadIsInVistaValidar, AttrEntidadIsEnabledInVistaMantener, AttrEntidadIsAutocomplete, AttrEntidadAutocompleteMethod, AttrEntidadColumnGroupNumber, AttrEntidadColumnGroupOrdinal, AttrEntidadColumnGroupName "
        sSQL = sSQL & "FROM AttrEntidad "
        sSQL = sSQL & "WHERE (AttrEntidad.AttrEntidadId = " & AttrEntidadId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                EntidadNombreTabla = CStr(dtr("EntidadNombreTabla").ToString)
                AttrEntidadSecuencia = CLng(dtr("AttrEntidadSecuencia").ToString)
                AttrEntidadColumnName = CStr(dtr("AttrEntidadColumnName").ToString)
                AttrEntidadColumnDescription = CStr(dtr("AttrEntidadColumnDescription").ToString)
                AttrEntidadColumnOrdinal = CLng(dtr("AttrEntidadColumnOrdinal").ToString)
                AttrEntidadColumnDataType = CStr(dtr("AttrEntidadColumnDataType").ToString)
                AttrEntidadColumnSize = CLng(dtr("AttrEntidadColumnSize").ToString)
                AttrEntidadIsRequerido = CBool(dtr("AttrEntidadIsRequerido").ToString)
                AttrEntidadDomainField = CStr(dtr("AttrEntidadDomainField").ToString)
                AttrEntidadIsForeignKey = CBool(dtr("AttrEntidadIsForeignKey").ToString)
                AttrEntidadForeignTable = CStr(dtr("AttrEntidadForeignTable").ToString)
                AttrEntidadForeignSQL = CStr(dtr("AttrEntidadForeignSQL").ToString)
                AttrEntidadColumnLabel = CStr(dtr("AttrEntidadColumnLabel").ToString)
                AttrEntidadColumnControlName = CStr(dtr("AttrEntidadColumnControlName").ToString)
                AttrEntidadColumnControlBase = CStr(dtr("AttrEntidadColumnControlBase").ToString)
                AttrEntidadColumnTextMode = CLng(dtr("AttrEntidadColumnTextMode").ToString)
                AttrEntidadColumnToolTip = CStr(dtr("AttrEntidadColumnToolTip").ToString)
                AttrEntidadIsFilterField = CBool(dtr("AttrEntidadIsFilterField").ToString)
                AttrEntidadIsColumnField = CBool(dtr("AttrEntidadIsColumnField").ToString)
                AttrEntidadColumnNumber = CLng(dtr("AttrEntidadColumnNumber").ToString)
                AttrEntidadColumnHeader = CStr(dtr("AttrEntidadColumnHeader").ToString)
                AttrEntidadIsInVistaValidar = CBool(dtr("AttrEntidadIsInVistaValidar").ToString)
                AttrEntidadIsEnabledInVistaMantener = CBool(dtr("AttrEntidadIsEnabledInVistaMantener").ToString)
                AttrEntidadIsAutocomplete = CBool(dtr("AttrEntidadIsAutocomplete").ToString)
                AttrEntidadAutocompleteMethod = CStr(dtr("AttrEntidadAutocompleteMethod").ToString)
                AttrEntidadColumnGroupNumber = CLng(dtr("AttrEntidadColumnGroupNumber").ToString)
                AttrEntidadColumnGroupOrdinal = CLng(dtr("AttrEntidadColumnGroupOrdinal").ToString)
                AttrEntidadColumnGroupName = CStr(dtr("AttrEntidadColumnGroupName").ToString)
            End While
            LeerAttrEntidad = True
            dtr.Close()
        Catch
            LeerAttrEntidad = False
        End Try
    End Function
    Public Function AttrEntidadUpdate(ByVal AttrEntidadId As Long, ByRef EntidadNombreTabla As String, _
                                      ByRef AttrEntidadSecuencia As Long, ByRef AttrEntidadColumnName As String, _
                                      ByRef AttrEntidadColumnDescription As String, ByRef AttrEntidadColumnOrdinal As Long, _
                                      ByRef AttrEntidadColumnDataType As String, ByRef AttrEntidadColumnSize As Long, _
                                      ByRef AttrEntidadIsRequerido As Boolean, ByRef AttrEntidadDomainField As String, _
                                      ByRef AttrEntidadIsForeignKey As Boolean, ByRef AttrEntidadForeignTable As String, _
                                      ByRef AttrEntidadForeignSQL As String, ByRef AttrEntidadColumnLabel As String, _
                                      ByRef AttrEntidadColumnControlName As String, ByRef AttrEntidadColumnControlBase As String, _
                                      ByRef AttrEntidadColumnTipoControl As String, ByRef AttrEntidadColumnControlWidth As String, _
                                      ByRef AttrEntidadColumnTextMode As Long, ByRef AttrEntidadColumnToolTip As String, _
                                      ByRef AttrEntidadIsFilterField As Boolean, ByRef AttrEntidadIsColumnField As Boolean, _
                                      ByRef AttrEntidadColumnNumber As Long, ByRef AttrEntidadColumnHeader As String, _
                                      ByRef AttrEntidadIsInVistaValidar As Boolean, ByRef AttrEntidadIsEnabledInVistaMantener As Boolean, _
                                      ByRef AttrEntidadIsFormKeys As Boolean, ByRef AttrEntidadIsAutocomplete As Boolean, _
                                      ByRef AttrEntidadAutocompleteMethod As String, ByRef AttrEntidadColumnGroupNumber As Long, _
                                      ByRef AttrEntidadColumnGroupOrdinal As Long, ByRef AttrEntidadColumnGroupName As String, _
                                      ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE AttrEntidad SET "
        strUpdate = strUpdate & "AttrEntidad.EntidadNombreTabla = '" & EntidadNombreTabla & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadSecuencia = " & AttrEntidadSecuencia & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnName = '" & AttrEntidadColumnName & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnDescription = '" & AttrEntidadColumnDescription & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnOrdinal = " & AttrEntidadColumnOrdinal & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnDataType = '" & AttrEntidadColumnDataType & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnSize = " & AttrEntidadColumnSize & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadIsRequerido = " & AttrEntidadIsRequerido & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadDomainField = '" & AttrEntidadDomainField & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadIsForeignKey = " & AttrEntidadIsForeignKey & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadForeignTable = '" & AttrEntidadForeignTable & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadForeignSQL = '" & AttrEntidadForeignSQL & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnLabel = '" & AttrEntidadColumnLabel & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnControlName = '" & AttrEntidadColumnControlName & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnControlBase = '" & AttrEntidadColumnControlBase & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnTipoControl = '" & AttrEntidadColumnTipoControl & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnControlWidth = '" & AttrEntidadColumnControlWidth & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnTextMode = " & AttrEntidadColumnTextMode & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnToolTip = '" & AttrEntidadColumnToolTip & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadIsFilterField = " & AttrEntidadIsFilterField & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadIsColumnField = " & AttrEntidadIsColumnField & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnNumber = " & AttrEntidadColumnNumber & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnHeader = '" & AttrEntidadColumnHeader & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadIsInVistaValidar = " & AttrEntidadIsInVistaValidar & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadIsEnabledInVistaMantener = " & AttrEntidadIsEnabledInVistaMantener & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadIsFormKeys = " & AttrEntidadIsFormKeys & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadIsAutocomplete = " & AttrEntidadIsAutocomplete & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadAutocompleteMethod = '" & AttrEntidadAutocompleteMethod & "', "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnGroupNumber = " & AttrEntidadColumnGroupNumber & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnGroupOrdinal = " & AttrEntidadColumnGroupOrdinal & ", "
        strUpdate = strUpdate & "AttrEntidad.AttrEntidadColumnGroupName = '" & AttrEntidadColumnGroupName & "', "
        strUpdate = strUpdate & "AttrEntidad.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "AttrEntidad.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE AttrEntidad.AttrEntidadId = " & AttrEntidadId
        Try
            AttrEntidadUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & EntidadNombreTabla, AttrEntidadId, "AttrEntidad", "")
        Catch
            AttrEntidadUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & EntidadNombreTabla, AttrEntidadId, "AttrEntidad", "")
        End Try
    End Function
    Public Function AttrEntidadInsert(ByRef AttrEntidadId As Long, ByRef EntidadNombreTabla As String, _
                                      ByRef AttrEntidadSecuencia As Long, ByRef AttrEntidadColumnName As String, _
                                      ByRef AttrEntidadColumnDescription As String, ByRef AttrEntidadColumnOrdinal As Long, _
                                      ByRef AttrEntidadColumnDataType As String, ByRef AttrEntidadColumnSize As Long, _
                                      ByRef AttrEntidadIsRequerido As Boolean, ByRef AttrEntidadDomainField As String, _
                                      ByRef AttrEntidadIsForeignKey As Boolean, ByRef AttrEntidadForeignTable As String, _
                                      ByRef AttrEntidadForeignSQL As String, ByRef AttrEntidadColumnLabel As String, _
                                      ByRef AttrEntidadColumnControlName As String, ByRef AttrEntidadColumnControlBase As String, _
                                      ByRef AttrEntidadColumnTipoControl As String, ByRef AttrEntidadColumnControlWidth As String, _
                                      ByRef AttrEntidadColumnTextMode As Long, ByRef AttrEntidadColumnToolTip As String, _
                                      ByRef AttrEntidadIsFilterField As Boolean, ByRef AttrEntidadIsColumnField As Boolean, _
                                      ByRef AttrEntidadColumnNumber As Long, ByRef AttrEntidadColumnHeader As String, _
                                      ByRef AttrEntidadIsInVistaValidar As Boolean, ByRef AttrEntidadIsEnabledInVistaMantener As Boolean, _
                                      ByRef AttrEntidadIsFormKeys As Boolean, ByRef AttrEntidadIsAutocomplete As Boolean, _
                                      ByRef AttrEntidadAutocompleteMethod As String, ByRef AttrEntidadColumnGroupNumber As Long, _
                                      ByRef AttrEntidadColumnGroupOrdinal As Long, ByRef AttrEntidadColumnGroupName As String, _
                                      ByVal UserId As Long) As Integer

        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim AttrEntidad As New AttrEntidad
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle

        Try
            MasterName = EntidadNombreTabla
            DetailSecuencia = AttrEntidadSecuencia
            DetailId = 0

            t = Lecturas.LeerObjectByNameAndSecuencia("AttrEntidadId", "EntidadNombreTabla", "AttrEntidadSecuencia", "AttrEntidad", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("AttrEntidadId", "EntidadNombreTabla", "AttrEntidadSecuencia", "AttrEntidad", MasterName, DetailSecuencia, UserId, DetailId)
            End If

            AttrEntidadInsert = AttrEntidad.AttrEntidadUpdate(DetailId, CStr(EntidadNombreTabla), CLng(AttrEntidadSecuencia), CStr(AttrEntidadColumnName), CStr(AttrEntidadColumnDescription), CLng(AttrEntidadColumnOrdinal), CStr(AttrEntidadColumnDataType), CLng(AttrEntidadColumnSize), CBool(AttrEntidadIsRequerido), CStr(AttrEntidadDomainField), CBool(AttrEntidadIsForeignKey), CStr(AttrEntidadForeignTable), CStr(AttrEntidadForeignSQL), CStr(AttrEntidadColumnLabel), CStr(AttrEntidadColumnControlName), CStr(AttrEntidadColumnControlBase), CStr(AttrEntidadColumnTipoControl), CStr(AttrEntidadColumnControlWidth), CLng(AttrEntidadColumnTextMode), CStr(AttrEntidadColumnToolTip), CBool(AttrEntidadIsFilterField), CBool(AttrEntidadIsColumnField), CLng(AttrEntidadColumnNumber), CStr(AttrEntidadColumnHeader), CBool(AttrEntidadIsInVistaValidar), CBool(AttrEntidadIsEnabledInVistaMantener), CBool(AttrEntidadIsFormKeys), CBool(AttrEntidadIsAutocomplete), CStr(AttrEntidadAutocompleteMethod), CLng(AttrEntidadColumnGroupNumber), CLng(AttrEntidadColumnGroupOrdinal), CStr(AttrEntidadColumnGroupName), UserId)
        Catch
            AttrEntidadInsert = 0
        End Try
    End Function
End Class
