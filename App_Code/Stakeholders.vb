'------------------------------------------------------------
' Código generado por ZRISMART SF el 29-08-2011 9:51:21
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Stakeholders
    Public Function LeerStakeholders(ByVal StakeholdersId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersName As String, ByRef StakeholdersSigla As String, ByRef StakeholdersTipoName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersCodigo, StakeholdersName, StakeholdersSigla, StakeholdersTipoName "
        sSQL = sSQL & "FROM (Stakeholders) "
        sSQL = sSQL & "WHERE (Stakeholders.StakeholdersId = " & StakeholdersId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                StakeholdersCodigo = CStr(dtr("StakeholdersCodigo").ToString)
                StakeholdersName = CStr(dtr("StakeholdersName").ToString)
                StakeholdersSigla = CStr(dtr("StakeholdersSigla").ToString)
                StakeholdersTipoName = CStr(dtr("StakeholdersTipoName").ToString)
            End While
            LeerStakeholders = True
            dtr.Close()
        Catch
            LeerStakeholders = False
        End Try
    End Function
    Public Function LeerStakeholdersByName(ByRef StakeholdersId As Long, ByVal StakeholdersCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersId "
        sSQL = sSQL & "FROM (Stakeholders) "
        sSQL = sSQL & "WHERE (Stakeholders.StakeholdersCodigo = '" & StakeholdersCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                StakeholdersId = CLng(dtr("StakeholdersId").ToString)
            End While
            LeerStakeholdersByName = True
            dtr.Close()
        Catch
            LeerStakeholdersByName = False
        End Try
    End Function
    Public Function StakeholdersUpdate(ByVal StakeholdersId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersName As String, ByRef StakeholdersSigla As String, ByRef StakeholdersTipoName As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Stakeholders SET "
        strUpdate = strUpdate & "Stakeholders.StakeholdersCodigo = '" & StakeholdersCodigo & "', "
        strUpdate = strUpdate & "Stakeholders.StakeholdersName = '" & StakeholdersName & "', "
        strUpdate = strUpdate & "Stakeholders.StakeholdersSigla = '" & StakeholdersSigla & "', "
        strUpdate = strUpdate & "Stakeholders.StakeholdersTipoName = '" & StakeholdersTipoName & "', "
        strUpdate = strUpdate & "Stakeholders.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Stakeholders.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Stakeholders.StakeholdersId = " & StakeholdersId
        Try
            StakeholdersUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & StakeholdersCodigo, StakeholdersId, "Stakeholders", "")
        Catch
            StakeholdersUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & StakeholdersCodigo, StakeholdersId, "Stakeholders", "")
        End Try
    End Function
    Public Function StakeholdersInsert(ByRef StakeholdersId As Long, ByRef StakeholdersCodigo As String, ByRef StakeholdersName As String, ByRef StakeholdersSigla As String, ByRef StakeholdersTipoName As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Stakeholders As New Stakeholders
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = StakeholdersCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("StakeholdersId", "StakeholdersCodigo", "Stakeholders", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("StakeholdersId", "StakeholdersCodigo", "Stakeholders", MasterName, CLng(UserId), MasterId)
            End If
            StakeholdersInsert = Stakeholders.StakeholdersUpdate(MasterId, CStr(StakeholdersCodigo), CStr(StakeholdersName), CStr(StakeholdersSigla), CStr(StakeholdersTipoName), UserId)
        Catch
            StakeholdersInsert = 0
        End Try
    End Function
    Public Function LeerStakeholdersDescriptionByName(ByVal StakeholdersCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersName "
        sSQL = sSQL & "FROM (Stakeholders) "
        sSQL = sSQL & "WHERE (Stakeholders.StakeholdersCodigo = '" & StakeholdersCodigo & "') "
        LeerStakeholdersDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerStakeholdersDescriptionByName = CStr(dtr("StakeholdersName").ToString)
            End While
            dtr.Close()
        Catch
            LeerStakeholdersDescriptionByName = ""
        End Try
    End Function
    Public Function LeerStakeholdersCodigoById(ByVal StakeholdersId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersCodigo "
        sSQL = sSQL & "FROM (Stakeholders) "
        sSQL = sSQL & "WHERE (Stakeholders.StakeholdersId = " & StakeholdersId & ") "
        LeerStakeholdersCodigoById = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerStakeholdersCodigoById = CStr(dtr("StakeholdersCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerStakeholdersCodigoById = ""
        End Try
    End Function
    Public Function LeerStakeholdersSiglaById(ByVal StakeholdersId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersSigla "
        sSQL = sSQL & "FROM (Stakeholders) "
        sSQL = sSQL & "WHERE (Stakeholders.StakeholdersId = " & StakeholdersId & ") "
        LeerStakeholdersSiglaById = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerStakeholdersSiglaById = CStr(dtr("StakeholdersSigla").ToString)
            End While
            dtr.Close()
        Catch
            LeerStakeholdersSiglaById = ""
        End Try
    End Function
    Public Function LeerTotalStakeholdersPorTablasRelacionadas(ByVal StakeholdersCodigo As String, ByVal StakeholdersId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si esta referenciada en un Contrato
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Stakeholders INNER JOIN StakeholdersPorSubGrupos ON Stakeholders.StakeholdersId = StakeholdersPorSubGrupos.StakeholdersId "
        sSQL = sSQL & "WHERE (((Stakeholders.StakeholdersId)=" & StakeholdersId & "))"
        LeerTotalStakeholdersPorTablasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalStakeholdersPorTablasRelacionadas = LeerTotalStakeholdersPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalStakeholdersPorTablasRelacionadas = 0
        End Try
        'Verifica si esta referenciada en una evidencia
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Stakeholders INNER JOIN StakeholdersDocs ON Stakeholders.StakeholdersCodigo = StakeholdersDocs.StakeholdersCodigo "
        sSQL = sSQL & "WHERE (((Stakeholders.StakeholdersCodigo)='" & StakeholdersCodigo & "'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalStakeholdersPorTablasRelacionadas = LeerTotalStakeholdersPorTablasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalStakeholdersPorTablasRelacionadas = LeerTotalStakeholdersPorTablasRelacionadas + 0
        End Try
        'Verifica si esta referenciada en un programa, queda pendiente
    End Function
    Public Function StakeholdersDelete(ByVal StakeholdersId As Long, ByVal StakeholdersCodigo As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Stakeholders As New Stakeholders

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Stakeholders.LeerTotalStakeholdersPorTablasRelacionadas(StakeholdersCodigo, StakeholdersId)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros asociados al mStakeholder " & StakeholdersCodigo & vbCrLf
            Mensaje = Mensaje & ", cambie el Stakeholder en las tablas asociadas, antes de eliminarla de la lista"
            StakeholdersDelete = False
        Else
            Try
                ' Borra registro de la tabla de Gerencias
                '-------------------------------------
                strUpdate = "DELETE FROM Stakeholders WHERE StakeholdersId = " & StakeholdersId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Stakeholder: " & StakeholdersCodigo, StakeholdersId, "Stakeholders", "")
                StakeholdersDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la Empresa: " & StakeholdersCodigo, StakeholdersId, "Stakeholders", "")
                StakeholdersDelete = False
            End Try
        End If
    End Function
    Public Function LeerStakeholdersNombreYTipo(ByVal StakeholdersId As Long, ByRef lblStakeholdersName As Label, ByRef lblStakeholdersTipoName As Label) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersName, StakeholdersTipoName "
        sSQL = sSQL & "FROM (Stakeholders) "
        sSQL = sSQL & "WHERE (Stakeholders.StakeholdersId = " & StakeholdersId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                lblStakeholdersName.Text = CStr(dtr("StakeholdersName").ToString)
                lblStakeholdersTipoName.Text = CStr(dtr("StakeholdersTipoName").ToString)
            End While
            LeerStakeholdersNombreYTipo = True
            dtr.Close()
        Catch
            LeerStakeholdersNombreYTipo = False
        End Try
    End Function
    Public Function LeerStakeholdersIdByCodigo(ByVal StakeholdersCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersId "
        sSQL = sSQL & "FROM (Stakeholders) "
        sSQL = sSQL & "WHERE (Stakeholders.StakeholdersCodigo = '" & StakeholdersCodigo & "') "
        LeerStakeholdersIdByCodigo = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerStakeholdersIdByCodigo = CLng(dtr("StakeholdersId").ToString)
            End While
            dtr.Close()
        Catch
            LeerStakeholdersIdByCodigo = 0
        End Try
    End Function
    Public Function GetdstPuntajes(ByRef rptPuntajes As Repeater, ByVal IsAuthorizedUser As Boolean) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim Stakeholders As New Stakeholders
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim Valor As Integer = 0

        Dim dtblPuntajes As DataTable
        Dim dcolColumn As DataColumn
        Dim drowItem As DataRow
        Dim dvwPuntajes As DataView

        'Crear el DataTable
        dtblPuntajes = New DataTable("Puntajes")

        'Crea Columnas
        dcolColumn = New DataColumn("Id", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Stakeholder", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Tipo", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Programas", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("SubGrupos", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)

        sSQL = "Select Stakeholders.StakeholdersId As Id, Stakeholders.StakeholdersCodigo As Codigo, Stakeholders.StakeholdersName As Stakeholder, Stakeholders.StakeholdersSigla As Sigla, Stakeholders.StakeholdersTipoName As Tipo FROM Stakeholders Order By Stakeholders.StakeholdersName"

        i = 1
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                drowItem = dtblPuntajes.NewRow
                If IsAuthorizedUser Then
                    drowItem("Id") = "<a href=""" & "IndexSGI.aspx?PaginaWebName=Ficha de Stakeholders&MenuOptionsId=439" & "&Id=" & dtr("Id").ToString & """><img src=""" & "img/editar.png" & """ alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Actualizar datos del Stakeholder"" /></a>"
                Else
                    drowItem("Id") = "<img src=""" & "img/editar.png" & """ alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Rol no autorizado a Editar datos del stakeholder""  />"
                End If
                'drowItem("Stakeholder") = "<a href=""ReportesPGG.aspx?PaginaWebName=" & "Reporte Stakeholders" & "&StakeholdersId=" & dtr("Id").ToString & """ target=""_blank"">" & Stakeholders.LeerStakeholdersCodigoById(dtr("Id").ToString) & "</a>"
                drowItem("Stakeholder") = "<a href=""IndexSGI.aspx?PaginaWebName=Perfil Stakeholders&MenuOptionsId=439" & "&StakeholdersId=" & dtr("Id").ToString & """ >" & Stakeholders.LeerStakeholdersCodigoById(dtr("Id").ToString) & "</a>"
                drowItem("Tipo") = dtr("Tipo").ToString
                drowItem("Programas") = Stakeholders.LeerProgramasPorStakeholders(dtr("Codigo").ToString)
                drowItem("SubGrupos") = Stakeholders.LeerSubGruposPorStakeholders(dtr("Codigo").ToString)
                dtblPuntajes.Rows.Add(drowItem)
            End While
            dvwPuntajes = dtblPuntajes.DefaultView
            rptPuntajes.DataSource = dvwPuntajes
            rptPuntajes.DataBind()
            dtr.Close()
            GetdstPuntajes = True
        Catch
            GetdstPuntajes = False
        End Try
    End Function
    Public Function GetGridWiewPaginada(ByRef rptPuntajes As GridView, ByVal IsAuthorizedUser As Boolean) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim Stakeholders As New Stakeholders
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim Valor As Integer = 0

        Dim dtblPuntajes As DataTable
        Dim dcolColumn As DataColumn
        Dim drowItem As DataRow
        Dim dvwPuntajes As DataView

        'Doy formato a la GridView
        'rptMatriz.HeaderStyle.CssClass = "grilla_top"
        'rptMatriz.RowStyle.CssClass = "grilla_Fila1"
        rptPuntajes.AlternatingRowStyle.CssClass = "alt"
        rptPuntajes.AllowPaging = True
        rptPuntajes.PageSize = 20

        'Crear el DataTable
        dtblPuntajes = New DataTable("Puntajes")

        'Crea Columnas
        dcolColumn = New DataColumn("Id", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Stakeholder", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Tipo", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Programas", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("SubGrupos", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)

        sSQL = "Select Stakeholders.StakeholdersId As Id, Stakeholders.StakeholdersCodigo As Codigo, Stakeholders.StakeholdersName As Stakeholder, Stakeholders.StakeholdersSigla As Sigla, Stakeholders.StakeholdersTipoName As Tipo FROM Stakeholders Order By Stakeholders.StakeholdersName"

        i = 1
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                drowItem = dtblPuntajes.NewRow
                If IsAuthorizedUser Then
                    drowItem("Id") = "<a href=""" & "IndexSGI.aspx?PaginaWebName=Ficha de Stakeholders&MenuOptionsId=439" & "&Id=" & dtr("Id").ToString & """><img src=""" & "img/editar.png" & """ alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Actualizar datos del Stakeholder"" /></a>"
                Else
                    drowItem("Id") = "<img src=""" & "img/editar.png" & """ alt=""Ver la ficha del documento"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Rol no autorizado a Editar datos del stakeholder""  />"
                End If
                'drowItem("Stakeholder") = "<a href=""ReportesPGG.aspx?PaginaWebName=" & "Reporte Stakeholders" & "&StakeholdersId=" & dtr("Id").ToString & """ target=""_blank"">" & Stakeholders.LeerStakeholdersCodigoById(dtr("Id").ToString) & "</a>"
                drowItem("Stakeholder") = "<a href=""IndexSGI.aspx?PaginaWebName=Perfil Stakeholders&MenuOptionsId=439" & "&StakeholdersId=" & dtr("Id").ToString & """ >" & Stakeholders.LeerStakeholdersCodigoById(dtr("Id").ToString) & "</a>"
                drowItem("Tipo") = dtr("Tipo").ToString
                drowItem("Programas") = Stakeholders.LeerProgramasPorStakeholders(dtr("Codigo").ToString)
                drowItem("SubGrupos") = Stakeholders.LeerSubGruposPorStakeholders(dtr("Codigo").ToString)
                dtblPuntajes.Rows.Add(drowItem)
            End While
            dvwPuntajes = dtblPuntajes.DefaultView
            rptPuntajes.DataSource = dvwPuntajes
            rptPuntajes.DataBind()
            dtr.Close()
            GetGridWiewPaginada = True
        Catch
            GetGridWiewPaginada = False
        End Try
    End Function
    Public Function LeerProgramasPorStakeholders(ByVal StakeholdersCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0

        sSQL = "SELECT Programas.ProgramasName + ' (' + ProgramasMapa.ProgramasMapaTipoGestion + ')' as ProgramasPorStake "
        sSQL = sSQL & "FROM (Stakeholders INNER JOIN ProgramasMapa ON Stakeholders.StakeholdersCodigo = ProgramasMapa.StakeholdersCodigo) INNER JOIN Programas ON ProgramasMapa.ProgramasCodigo = Programas.ProgramasCodigo "
        sSQL = sSQL & "WHERE (((Stakeholders.StakeholdersCodigo)='" & StakeholdersCodigo & "'))"

        LeerProgramasPorStakeholders = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    LeerProgramasPorStakeholders = LeerProgramasPorStakeholders & CStr(dtr("ProgramasPorStake").ToString)
                Else
                    LeerProgramasPorStakeholders = LeerProgramasPorStakeholders & "<br />" & CStr(dtr("ProgramasPorStake").ToString)
                End If
            End While
            dtr.Close()
        Catch
            LeerProgramasPorStakeholders = ""
        End Try


    End Function
    Public Function LeerSubGruposPorStakeholders(ByVal StakeholdersCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0

        sSQL = "SELECT SubGrupos.GruposCodigo+' - '+SubGrupos.SubGruposName AS Grupo "
        sSQL = sSQL & "FROM (Stakeholders INNER JOIN StakeholdersPorSubGrupos ON Stakeholders.StakeholdersId = StakeholdersPorSubGrupos.StakeholdersId) INNER JOIN SubGrupos ON StakeholdersPorSubGrupos.SubGruposId = SubGrupos.SubGruposId "
        sSQL = sSQL & "WHERE (((Stakeholders.StakeholdersCodigo)='" & StakeholdersCodigo & "'))"


        LeerSubGruposPorStakeholders = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    LeerSubGruposPorStakeholders = LeerSubGruposPorStakeholders & CStr(dtr("Grupo").ToString)
                Else
                    LeerSubGruposPorStakeholders = LeerSubGruposPorStakeholders & "<br />" & CStr(dtr("Grupo").ToString)
                End If
            End While
            dtr.Close()
        Catch
            LeerSubGruposPorStakeholders = ""
        End Try

    End Function
    Public Function LoadDescriptionPorStakeholders(ByRef rptDescription As Repeater, ByVal StakeholdersId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrRutasPorViajes As IDataReader
        'Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Stakeholders.StakeholdersSigla AS Descripcion "
        sSQL = sSQL & "FROM Stakeholders "
        sSQL = sSQL & "WHERE Stakeholders.StakeholdersId=" & StakeholdersId

        Try
            dtrRutasPorViajes = AccesoEA.ListarRegistros(sSQL)

            rptDescription.DataSource = dtrRutasPorViajes
            rptDescription.DataBind()
            LoadDescriptionPorStakeholders = True
            dtrRutasPorViajes.Close()
        Catch
            LoadDescriptionPorStakeholders = False
        End Try
    End Function
    Public Function MostrarStakeholdersPorPalabraClaveOld(ByVal PalabraClave As String, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim CodigoHTML As String = ""
        Dim dtr As IDataReader
        Dim strUpdate As String
        Dim NotasTransversales As New NotasTransversales

        strUpdate = "SELECT DISTINCT Stakeholders.StakeholdersCodigo AS Stakeholder, Stakeholders.StakeholdersId AS Id "
        strUpdate = strUpdate & "FROM ((SubGrupos INNER JOIN StakeholdersPorSubGrupos ON SubGrupos.SubGruposId = StakeholdersPorSubGrupos.SubGruposId) INNER JOIN Grupos ON SubGrupos.GruposCodigo = Grupos.GruposCodigo) INNER JOIN Stakeholders ON StakeholdersPorSubGrupos.StakeholdersId = Stakeholders.StakeholdersId "
        strUpdate = strUpdate & "WHERE (((Stakeholders.StakeholdersName) Like ('%" & PalabraClave & "%'))) OR (((Stakeholders.StakeholdersSigla) Like ('%" & PalabraClave & "%'))) OR (((Grupos.GruposName) Like ('%" & PalabraClave & "%'))) OR (((Grupos.GruposDescription) Like ('%" & PalabraClave & "%'))) OR (((SubGrupos.SubGruposName) Like ('%" & PalabraClave & "%'))) OR (((SubGrupos.SubGruposDescription) Like ('%" & PalabraClave & "%')))"
        MostrarStakeholdersPorPalabraClaveOld = ""
        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""alertas"">"
        CodigoHTML = CodigoHTML & "<tr><th scope=""col"">Stakeholders con ['" & PalabraClave & "']</th></tr>"
        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                strUpdate = "<a href=""ReportesPGG.aspx?PaginaWebName=" & "Reporte Stakeholders" & "&StakeholdersId=" & dtr("Id").ToString & """ target=""_blank"">" & dtr("Stakeholder").ToString & "</a>"
                MostrarStakeholdersPorPalabraClaveOld = MostrarStakeholdersPorPalabraClaveOld & "<tr><td>" & strUpdate & "</td></tr>"
            End While
            dtr.Close()
        Catch
            MostrarStakeholdersPorPalabraClaveOld = ""
        End Try
        If Len(MostrarStakeholdersPorPalabraClaveOld) = 0 Then
            MostrarStakeholdersPorPalabraClaveOld = MostrarStakeholdersPorPalabraClaveOld & "<tr><td>No se encontraron stakeholders con '" & PalabraClave & "'</td></tr>"
        End If
        CodigoHTML = CodigoHTML & MostrarStakeholdersPorPalabraClaveOld & "</table>"
        MostrarStakeholdersPorPalabraClaveOld = CodigoHTML
    End Function
    Public Function MostrarStakeholdersPorPalabraClave(ByVal PalabraClave As String, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim CodigoHTML As String = ""
        Dim dtr As IDataReader
        Dim strUpdate As String
        Dim NotasTransversales As New NotasTransversales
        Dim Stakeholders As New Stakeholders

        strUpdate = "SELECT DISTINCT Stakeholders.StakeholdersCodigo AS Stakeholder, Stakeholders.StakeholdersId AS Id "
        strUpdate = strUpdate & "FROM ((SubGrupos INNER JOIN StakeholdersPorSubGrupos ON SubGrupos.SubGruposId = StakeholdersPorSubGrupos.SubGruposId) INNER JOIN Grupos ON SubGrupos.GruposCodigo = Grupos.GruposCodigo) INNER JOIN Stakeholders ON StakeholdersPorSubGrupos.StakeholdersId = Stakeholders.StakeholdersId "
        strUpdate = strUpdate & "WHERE (((Stakeholders.StakeholdersName) Like ('%" & PalabraClave & "%'))) OR (((Stakeholders.StakeholdersSigla) Like ('%" & PalabraClave & "%'))) OR (((Grupos.GruposName) Like ('%" & PalabraClave & "%'))) OR (((Grupos.GruposDescription) Like ('%" & PalabraClave & "%'))) OR (((SubGrupos.SubGruposName) Like ('%" & PalabraClave & "%'))) OR (((SubGrupos.SubGruposDescription) Like ('%" & PalabraClave & "%')))"
        MostrarStakeholdersPorPalabraClave = ""
        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""alertas"">"
        CodigoHTML = CodigoHTML & "<tr><th scope=""col"">Stakeholders con ['" & PalabraClave & "']</th></tr>"
        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                strUpdate = "<a href=""ReportesPGG.aspx?PaginaWebName=" & "Reporte Stakeholders" & "&StakeholdersId=" & dtr("Id").ToString & """ target=""_blank"">" & dtr("Stakeholder").ToString & "</a>"
                MostrarStakeholdersPorPalabraClave = MostrarStakeholdersPorPalabraClave & "<tr><td>" & strUpdate & "</td></tr>"
            End While
            dtr.Close()
        Catch
            MostrarStakeholdersPorPalabraClave = ""
        End Try
        If Len(MostrarStakeholdersPorPalabraClave) = 0 Then
            MostrarStakeholdersPorPalabraClave = MostrarStakeholdersPorPalabraClave & Stakeholders.MostrarStakeholdersPorPalabraClaveSoloEnStakeholders(PalabraClave, UserId)
        End If
        CodigoHTML = CodigoHTML & MostrarStakeholdersPorPalabraClave & "</table>"
        MostrarStakeholdersPorPalabraClave = CodigoHTML
    End Function
    Public Function MostrarStakeholdersPorPalabraClaveSoloEnStakeholders(ByVal PalabraClave As String, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim CodigoHTML As String = ""
        Dim dtr As IDataReader
        Dim strUpdate As String
        Dim NotasTransversales As New NotasTransversales

        'strUpdate = "SELECT DISTINCT Stakeholders.StakeholdersCodigo AS Stakeholder, Stakeholders.StakeholdersId AS Id "
        'strUpdate = strUpdate & "FROM ((SubGrupos INNER JOIN StakeholdersPorSubGrupos ON SubGrupos.SubGruposId = StakeholdersPorSubGrupos.SubGruposId) INNER JOIN Grupos ON SubGrupos.GruposCodigo = Grupos.GruposCodigo) INNER JOIN Stakeholders ON StakeholdersPorSubGrupos.StakeholdersId = Stakeholders.StakeholdersId "
        'strUpdate = strUpdate & "WHERE (((Stakeholders.StakeholdersName) Like ('%" & PalabraClave & "%'))) OR (((Stakeholders.StakeholdersSigla) Like ('%" & PalabraClave & "%'))) OR (((Grupos.GruposName) Like ('%" & PalabraClave & "%'))) OR (((Grupos.GruposDescription) Like ('%" & PalabraClave & "%'))) OR (((SubGrupos.SubGruposName) Like ('%" & PalabraClave & "%'))) OR (((SubGrupos.SubGruposDescription) Like ('%" & PalabraClave & "%')))"

        strUpdate = "SELECT DISTINCT Stakeholders.StakeholdersCodigo AS Stakeholder, Stakeholders.StakeholdersId AS Id "
        strUpdate = strUpdate & "FROM(Stakeholders) "
        strUpdate = strUpdate & "WHERE (((Stakeholders.StakeholdersName) Like ('%" & PalabraClave & "%'))) OR (((Stakeholders.StakeholdersSigla) Like ('%" & PalabraClave & "%')))"

        MostrarStakeholdersPorPalabraClaveSoloEnStakeholders = ""
        'CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""alertas"">"
        'CodigoHTML = CodigoHTML & "<tr><th scope=""col"">Stakeholders con ['" & PalabraClave & "']</th></tr>"
        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                strUpdate = "<a href=""ReportesPGG.aspx?PaginaWebName=" & "Reporte Stakeholders" & "&StakeholdersId=" & dtr("Id").ToString & """ target=""_blank"">" & dtr("Stakeholder").ToString & "</a>"
                MostrarStakeholdersPorPalabraClaveSoloEnStakeholders = MostrarStakeholdersPorPalabraClaveSoloEnStakeholders & "<tr><td>" & strUpdate & "</td></tr>"
            End While
            dtr.Close()
        Catch
            MostrarStakeholdersPorPalabraClaveSoloEnStakeholders = ""
        End Try
        If Len(MostrarStakeholdersPorPalabraClaveSoloEnStakeholders) = 0 Then
            MostrarStakeholdersPorPalabraClaveSoloEnStakeholders = MostrarStakeholdersPorPalabraClaveSoloEnStakeholders & "<tr><td>No se encontraron stakeholders con '" & PalabraClave & "'</td></tr>"
        End If
        'CodigoHTML = CodigoHTML & MostrarStakeholdersPorPalabraClaveSoloEnStakeholders & "</table>"
        'MostrarStakeholdersPorPalabraClaveSoloEnStakeholders = CodigoHTML
    End Function

    Public Function GetStakeholdersPorPrograma(ByVal Value As String) As String

        Dim Stakeholders As New Stakeholders
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim ProgramasCodigo As String = Value
        Dim ListaXML As String = ""

        sSQL = "SELECT ProgramasMapa.StakeholdersCodigo as Codigo, ProgramasMapa.ProgramasMapaImportancia as Puntos "
        sSQL = sSQL & "FROM(ProgramasMapa) "
        sSQL = sSQL & "WHERE (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "')) "
        sSQL = sSQL & "ORDER BY ProgramasMapa.ProgramasMapaImportancia"


        '<feet><Foot><label>1Coditfam</label><barColor>0xfeea00</barColor><link>http://www.google.com</link><value>3</value></Foot><Foot><label>2Coditfam</label><barColor>0xfeea00</barColor><link>http://www.google.com</link><value>3</value></Foot><Foot><label>3Coditfam</label><barColor>0xfeea00</barColor><link>http://www.google.com</link><value>3</value></Foot><Foot><label>4Coditfam</label><barColor>0xfeea00</barColor><link>http://www.google.com</link><value>3</value></Foot><Foot><label>5Coditfam</label><barColor>0xfeea00</barColor><link>http://www.google.com</link><value>3</value></Foot><Foot><label>6Coditfam</label><barColor>0xfeea00</barColor><link>http://www.google.com</link><value>3</value></Foot><Foot><label>7Coditfam</label><barColor>0xfeea00</barColor><link>http://www.google.com</link><value>3</value></Foot><Foot><label>8Coditfam</label><barColor>0xfeea00</barColor><link>http://www.google.com</link><value>3</value></Foot><Foot><label>9Coditfam</label><barColor>0xff0000</barColor><link>http://www.google.com</link><value>3</value></Foot></feet></StakeholderMap>
        ListaXML = "<feet>"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read

                ListaXML = ListaXML & "<Foot>"
                ListaXML = ListaXML & "<label>" & dtrFunciones("Codigo") & "</label>"
                If CInt(dtrFunciones("Puntos")) >= 18 Then 'Rojo
                    ListaXML = ListaXML & "<barColor>0xe30003</barColor>"
                End If
                If CInt(dtrFunciones("Puntos")) >= 7 And CInt(dtrFunciones("Puntos")) < 18 Then 'Rosado
                    ListaXML = ListaXML & "<barColor>0xffa52b</barColor>"
                End If
                If CInt(dtrFunciones("Puntos")) >= 1 And CInt(dtrFunciones("Puntos")) < 7 Then 'Amarillo
                    ListaXML = ListaXML & "<barColor>0xfeea00</barColor>"
                End If
                ListaXML = ListaXML & "<link>ReportesPGG.aspx?PaginaWebName=Reporte Stakeholders%26StakeholdersId=" & CStr(Stakeholders.LeerStakeholdersIdByCodigo(dtrFunciones("Codigo"))) & "</link>"
                ListaXML = ListaXML & "<value>" & dtrFunciones("Puntos") & "</value>"

                ListaXML = ListaXML & "</Foot>"

            End While
            dtrFunciones.Close()
        Catch

        End Try

        ListaXML = ListaXML & "</feet></StakeholderMap>"

        Return ListaXML

    End Function

End Class
