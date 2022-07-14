'------------------------------------------------------------
' Código generado por ZRISMART SF el 23-08-2011 23:11:56
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class SubGrupos
    Public Function LeerSubGrupos(ByVal SubGruposId As Long, ByRef GruposCodigo As String, ByRef SubGruposSecuencia As Long, ByRef SubGruposName As String, ByRef SubGruposDescription As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select GruposCodigo, SubGruposSecuencia, SubGruposName, SubGruposDescription "
        sSQL = sSQL & "FROM (SubGrupos) "
        sSQL = sSQL & "WHERE (SubGrupos.SubGruposId = " & SubGruposId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                GruposCodigo = CStr(dtr("GruposCodigo").ToString)
                If Len(dtr("SubGruposSecuencia").ToString) = 0 Then
                    SubGruposSecuencia = 0
                Else
                    SubGruposSecuencia = CLng(dtr("SubGruposSecuencia").ToString)
                End If
                SubGruposName = CStr(dtr("SubGruposName").ToString)
                SubGruposDescription = CStr(dtr("SubGruposDescription").ToString)
            End While
            LeerSubGrupos = True
            dtr.Close()
        Catch
            LeerSubGrupos = False
        End Try
    End Function
    Public Function SubGruposUpdate(ByVal SubGruposId As Long, ByRef GruposCodigo As String, ByRef SubGruposSecuencia As Long, ByRef SubGruposName As String, ByRef SubGruposDescription As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE SubGrupos SET "
        strUpdate = strUpdate & "SubGrupos.GruposCodigo = '" & GruposCodigo & "', "
        strUpdate = strUpdate & "SubGrupos.SubGruposSecuencia = " & SubGruposSecuencia & ", "
        strUpdate = strUpdate & "SubGrupos.SubGruposName = '" & SubGruposName & "', "
        strUpdate = strUpdate & "SubGrupos.SubGruposDescription = '" & SubGruposDescription & "', "
        strUpdate = strUpdate & "SubGrupos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "SubGrupos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE SubGrupos.SubGruposId = " & SubGruposId
        Try
            SubGruposUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & GruposCodigo, SubGruposId, "SubGrupos", "")
        Catch
            SubGruposUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & GruposCodigo, SubGruposId, "SubGrupos", "")
        End Try
    End Function
    Public Function SubGruposInsert(ByRef SubGruposId As Long, ByRef GruposCodigo As String, ByRef SubGruposSecuencia As Long, ByRef SubGruposName As String, ByRef SubGruposDescription As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim SubGrupos As New SubGrupos
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = GruposCodigo
            DetailSecuencia = SubGruposSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("SubGruposId", "GruposCodigo", "SubGruposSecuencia", "SubGrupos", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("SubGruposId", "GruposCodigo", "SubGruposSecuencia", "SubGrupos", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            SubGruposInsert = SubGrupos.SubGruposUpdate(DetailId, CStr(GruposCodigo), CLng(SubGruposSecuencia), CStr(SubGruposName), CStr(SubGruposDescription), UserId)
        Catch
            SubGruposInsert = 0
        End Try
    End Function
    Public Function SubGruposDelete(ByVal SubGruposId As Long, ByVal GruposCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (SubGrupos) "
        strUpdate = strUpdate & "WHERE (SubGrupos.SubGruposId = " & SubGruposId & ") "
        Try
            SubGruposDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & GruposCodigo, SubGruposId, "SubGrupos", "")
        Catch
            SubGruposDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & GruposCodigo, SubGruposId, "SubGrupos", "")
        End Try
    End Function
    Public Function LoadSubGruposPorStakeholders(ByRef rptGruposSubGrupos As Repeater, ByVal StakeholdersId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Stakeholders.StakeholdersName as Stakeholder, Grupos.GruposName as Grupo, SubGrupos.SubGruposName as SubGrupo "
        sSQL = sSQL & "FROM ((StakeholdersPorSubGrupos INNER JOIN SubGrupos ON StakeholdersPorSubGrupos.SubGruposId = SubGrupos.SubGruposId) INNER JOIN Grupos ON SubGrupos.GruposCodigo = Grupos.GruposCodigo) INNER JOIN Stakeholders ON StakeholdersPorSubGrupos.StakeholdersId = Stakeholders.StakeholdersId "
        sSQL = sSQL & "WHERE (((Stakeholders.StakeholdersId)=" & StakeholdersId & "))"

        Try
            dtrRutasPorViajes = AccesoEA.ListarRegistros(sSQL)

            rptGruposSubGrupos.DataSource = dtrRutasPorViajes
            rptGruposSubGrupos.DataBind()
            LoadSubGruposPorStakeholders = True
            dtrRutasPorViajes.Close()
        Catch
            LoadSubGruposPorStakeholders = False
        End Try
    End Function

    Public Function LoadPrimerGrupoSubGrupoPorStakeholders(ByRef lblGruposName As Label, ByRef lblSubGruposName As Label, ByVal StakeholdersId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Stakeholders.StakeholdersName as Stakeholder, Grupos.GruposName as Grupo, SubGrupos.SubGruposName as SubGrupo "
        sSQL = sSQL & "FROM ((StakeholdersPorSubGrupos INNER JOIN SubGrupos ON StakeholdersPorSubGrupos.SubGruposId = SubGrupos.SubGruposId) INNER JOIN Grupos ON SubGrupos.GruposCodigo = Grupos.GruposCodigo) INNER JOIN Stakeholders ON StakeholdersPorSubGrupos.StakeholdersId = Stakeholders.StakeholdersId "
        sSQL = sSQL & "WHERE (((Stakeholders.StakeholdersId)=" & StakeholdersId & "))"
        lblGruposName.Text = ""
        lblSubGruposName.Text = ""
        Try
            dtrRutasPorViajes = AccesoEA.ListarRegistros(sSQL)

            While dtrRutasPorViajes.Read
                lblGruposName.Text = CStr(dtrRutasPorViajes("Grupo").ToString)
                lblSubGruposName.Text = CStr(dtrRutasPorViajes("SubGrupo").ToString)

            End While
            dtrRutasPorViajes.Close()
            LoadPrimerGrupoSubGrupoPorStakeholders = True
        Catch
            LoadPrimerGrupoSubGrupoPorStakeholders = False
        End Try
    End Function
    Public Function LeerPrimerGrupoSubGrupoPorStakeholders(ByRef GruposName As String, ByRef SubGruposName As String, ByVal StakeholdersCodigo As String) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        'sSQL = "SELECT Stakeholders.StakeholdersName as Stakeholder, Grupos.GruposName as Grupo, SubGrupos.SubGruposName as SubGrupo "
        'sSQL = sSQL & "FROM ((StakeholdersPorSubGrupos INNER JOIN SubGrupos ON StakeholdersPorSubGrupos.SubGruposId = SubGrupos.SubGruposId) INNER JOIN Grupos ON SubGrupos.GruposCodigo = Grupos.GruposCodigo) INNER JOIN Stakeholders ON StakeholdersPorSubGrupos.StakeholdersId = Stakeholders.StakeholdersId "
        'sSQL = sSQL & "WHERE (((Stakeholders.StakeholdersId)=" & StakeholdersId & "))"

        sSQL = "SELECT Stakeholders.[StakeholdersCodigo], SubGrupos.SubGruposName As SubGrupo, Grupos.GruposName As Grupo "
        sSQL = sSQL & "FROM ((Stakeholders INNER JOIN StakeholdersPorSubGrupos ON Stakeholders.StakeholdersId = StakeholdersPorSubGrupos.StakeholdersId) INNER JOIN SubGrupos ON StakeholdersPorSubGrupos.SubGruposId = SubGrupos.SubGruposId) INNER JOIN Grupos ON SubGrupos.GruposCodigo = Grupos.GruposCodigo "
        sSQL = sSQL & "WHERE (((Stakeholders.[StakeholdersCodigo])='" & StakeholdersCodigo & "'))"

        GruposName = ""
        SubGruposName = ""
        Try
            dtrRutasPorViajes = AccesoEA.ListarRegistros(sSQL)

            While dtrRutasPorViajes.Read
                GruposName = CStr(dtrRutasPorViajes("Grupo").ToString)
                SubGruposName = CStr(dtrRutasPorViajes("SubGrupo").ToString)

            End While
            dtrRutasPorViajes.Close()
            LeerPrimerGrupoSubGrupoPorStakeholders = True
        Catch
            LeerPrimerGrupoSubGrupoPorStakeholders = False
        End Try
    End Function

End Class
