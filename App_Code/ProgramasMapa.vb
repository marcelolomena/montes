'------------------------------------------------------------
' Código generado por ZRISMART SF el 03-09-2011 8:42:33
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class ProgramasMapa
    Public Function LeerProgramasMapa(ByVal ProgramasMapaId As Long, ByRef ProgramasCodigo As String, ByRef ProgramasMapaSecuencia As Long, ByRef StakeholdersCodigo As String, ByRef ProgramasMapaMesEvaluacion As String, ByRef ProgramasMapaImportancia As Long, ByRef ProgramasMapaTipoGestion As String, ByRef ProgramasMapaPuntajePoder As Long, ByRef ProgramasMapaPuntajeRelevancia As Long, ByRef ProgramasMapaRol As String, ByRef ProgramasMapaFuncion As String, ByRef ProgramasMapaRelacion As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasCodigo, ProgramasMapaSecuencia, StakeholdersCodigo, ProgramasMapaMesEvaluacion, ProgramasMapaImportancia, ProgramasMapaTipoGestion, ProgramasMapaPuntajePoder, ProgramasMapaPuntajeRelevancia, ProgramasMapaRol, ProgramasMapaFuncion, ProgramasMapaRelacion "
        sSQL = sSQL & "FROM (ProgramasMapa) "
        sSQL = sSQL & "WHERE (ProgramasMapa.ProgramasMapaId = " & ProgramasMapaId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProgramasCodigo = CStr(dtr("ProgramasCodigo").ToString)
                If Len(dtr("ProgramasMapaSecuencia").ToString) = 0 Then
                    ProgramasMapaSecuencia = 0
                Else
                    ProgramasMapaSecuencia = CLng(dtr("ProgramasMapaSecuencia").ToString)
                End If
                StakeholdersCodigo = CStr(dtr("StakeholdersCodigo").ToString)
                ProgramasMapaMesEvaluacion = CStr(dtr("ProgramasMapaMesEvaluacion").ToString)
                If Len(dtr("ProgramasMapaImportancia").ToString) = 0 Then
                    ProgramasMapaImportancia = 0
                Else
                    ProgramasMapaImportancia = CLng(dtr("ProgramasMapaImportancia").ToString)
                End If
                ProgramasMapaTipoGestion = CStr(dtr("ProgramasMapaTipoGestion").ToString)
                If Len(dtr("ProgramasMapaPuntajePoder").ToString) = 0 Then
                    ProgramasMapaPuntajePoder = 0
                Else
                    ProgramasMapaPuntajePoder = CLng(dtr("ProgramasMapaPuntajePoder").ToString)
                End If
                If Len(dtr("ProgramasMapaPuntajeRelevancia").ToString) = 0 Then
                    ProgramasMapaPuntajeRelevancia = 0
                Else
                    ProgramasMapaPuntajeRelevancia = CLng(dtr("ProgramasMapaPuntajeRelevancia").ToString)
                End If
                ProgramasMapaRol = CStr(dtr("ProgramasMapaRol").ToString)
                ProgramasMapaFuncion = CStr(dtr("ProgramasMapaFuncion").ToString)
                ProgramasMapaRelacion = CStr(dtr("ProgramasMapaRelacion").ToString)
            End While
            LeerProgramasMapa = True
            dtr.Close()
        Catch
            LeerProgramasMapa = False
        End Try
    End Function
    Public Function ProgramasMapaUpdate(ByVal ProgramasMapaId As Long, ByRef ProgramasCodigo As String, ByRef ProgramasMapaSecuencia As Long, ByRef StakeholdersCodigo As String, ByRef ProgramasMapaMesEvaluacion As String, ByRef ProgramasMapaImportancia As Long, ByRef ProgramasMapaTipoGestion As String, ByRef ProgramasMapaPuntajePoder As Long, ByRef ProgramasMapaPuntajeRelevancia As Long, ByRef ProgramasMapaRol As String, ByRef ProgramasMapaFuncion As String, ByRef ProgramasMapaRelacion As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim ProgramasMapa As New ProgramasMapa

        ' Calcula Puntaje de Poder
        ProgramasMapaPuntajePoder = ProgramasMapa.Puntaje(ProgramasMapaId, 1)
        ' Calcula Puntaje de Relevancia
        ProgramasMapaPuntajeRelevancia = ProgramasMapa.Puntaje(ProgramasMapaId, 2)
        ' Calcula Importancia
        'ProgramasMapaImportancia = (ProgramasMapaPuntajePoder / 5) * (ProgramasMapaPuntajeRelevancia / 3)
        ProgramasMapaImportancia = (ProgramasMapaPuntajePoder / 5) * (ProgramasMapaPuntajeRelevancia)
        If ProgramasMapaImportancia >= 18 Then
            ProgramasMapaTipoGestion = "Gestión Especial"
        Else
            ProgramasMapaTipoGestion = "Gestión General"
        End If
        strUpdate = "UPDATE ProgramasMapa SET "
        strUpdate = strUpdate & "ProgramasMapa.ProgramasCodigo = '" & ProgramasCodigo & "', "
        strUpdate = strUpdate & "ProgramasMapa.ProgramasMapaSecuencia = " & ProgramasMapaSecuencia & ", "
        strUpdate = strUpdate & "ProgramasMapa.StakeholdersCodigo = '" & StakeholdersCodigo & "', "
        strUpdate = strUpdate & "ProgramasMapa.ProgramasMapaMesEvaluacion = '" & ProgramasMapaMesEvaluacion & "', "
        strUpdate = strUpdate & "ProgramasMapa.ProgramasMapaImportancia = " & ProgramasMapaImportancia & ", "
        strUpdate = strUpdate & "ProgramasMapa.ProgramasMapaTipoGestion = '" & ProgramasMapaTipoGestion & "', "
        strUpdate = strUpdate & "ProgramasMapa.ProgramasMapaPuntajePoder = " & ProgramasMapaPuntajePoder & ", "
        strUpdate = strUpdate & "ProgramasMapa.ProgramasMapaPuntajeRelevancia = " & ProgramasMapaPuntajeRelevancia & ", "
        strUpdate = strUpdate & "ProgramasMapa.ProgramasMapaRol = '" & ProgramasMapaRol & "', "
        strUpdate = strUpdate & "ProgramasMapa.ProgramasMapaFuncion = '" & ProgramasMapaFuncion & "', "
        strUpdate = strUpdate & "ProgramasMapa.ProgramasMapaRelacion = '" & ProgramasMapaRelacion & "', "
        strUpdate = strUpdate & "ProgramasMapa.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "ProgramasMapa.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE ProgramasMapa.ProgramasMapaId = " & ProgramasMapaId
        Try
            ProgramasMapaUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ProgramasCodigo, ProgramasMapaId, "ProgramasMapa", "")
        Catch
            ProgramasMapaUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ProgramasCodigo, ProgramasMapaId, "ProgramasMapa", "")
        End Try
    End Function
    Public Function ProgramasMapaUpdateImportancia(ByVal ProgramasMapaId As Long, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim ProgramasMapa As New ProgramasMapa
        Dim ProgramasMapaPuntajePoder As Long = 0
        Dim ProgramasMapaPuntajeRelevancia As Long = 0
        Dim ProgramasMapaImportancia As Long = 0
        Dim ProgramasMapaTipoGestion As String = ""
        Dim ProgramasCodigo As String

        ProgramasCodigo = ProgramasMapa.LeerProgramasCodigo(ProgramasMapaId)
        ' Calcula Puntaje de Poder
        ProgramasMapaPuntajePoder = ProgramasMapa.Puntaje(ProgramasMapaId, 1)
        ' Calcula Puntaje de Relevancia
        ProgramasMapaPuntajeRelevancia = ProgramasMapa.Puntaje(ProgramasMapaId, 2)
        ' Calcula Importancia
        'ProgramasMapaImportancia = (ProgramasMapaPuntajePoder / 5) * (ProgramasMapaPuntajeRelevancia / 3)
        ProgramasMapaImportancia = (ProgramasMapaPuntajePoder / 5) * (ProgramasMapaPuntajeRelevancia)
        If ProgramasMapaImportancia >= 18 Then
            ProgramasMapaTipoGestion = "Gestión Especial"
        Else
            ProgramasMapaTipoGestion = "Gestión General"
        End If
        strUpdate = "UPDATE ProgramasMapa SET "
        strUpdate = strUpdate & "ProgramasMapa.ProgramasMapaImportancia = " & ProgramasMapaImportancia & ", "
        strUpdate = strUpdate & "ProgramasMapa.ProgramasMapaTipoGestion = '" & ProgramasMapaTipoGestion & "', "
        strUpdate = strUpdate & "ProgramasMapa.ProgramasMapaPuntajePoder = " & ProgramasMapaPuntajePoder & ", "
        strUpdate = strUpdate & "ProgramasMapa.ProgramasMapaPuntajeRelevancia = " & ProgramasMapaPuntajeRelevancia & ", "
        strUpdate = strUpdate & "ProgramasMapa.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "ProgramasMapa.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE ProgramasMapa.ProgramasMapaId = " & ProgramasMapaId
        Try
            ProgramasMapaUpdateImportancia = AccesoEA.ABMRegistros(strUpdate)
            ProgramasMapaUpdateImportancia = ProgramasMapaImportancia
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & ProgramasCodigo, ProgramasMapaId, "ProgramasMapa", "")
        Catch
            ProgramasMapaUpdateImportancia = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & ProgramasCodigo, ProgramasMapaId, "ProgramasMapa", "")
        End Try
    End Function
    Public Function ProgramasMapaInsert(ByRef ProgramasMapaId As Long, ByRef ProgramasCodigo As String, ByRef ProgramasMapaSecuencia As Long, ByRef StakeholdersCodigo As String, ByRef ProgramasMapaMesEvaluacion As String, ByRef ProgramasMapaImportancia As Long, ByRef ProgramasMapaTipoGestion As String, ByRef ProgramasMapaPuntajePoder As Long, ByRef ProgramasMapaPuntajeRelevancia As Long, ByRef ProgramasMapaRol As String, ByRef ProgramasMapaFuncion As String, ByRef ProgramasMapaRelacion As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim ProgramasMapa As New ProgramasMapa
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = ProgramasCodigo
            DetailSecuencia = ProgramasMapaSecuencia
            DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("ProgramasCodigo", "ProgramasMapaSecuencia", "ProgramasMapa", MasterName)
            ProgramasMapaSecuencia = DetailSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("ProgramasMapaId", "ProgramasCodigo", "ProgramasMapaSecuencia", "ProgramasMapa", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("ProgramasMapaId", "ProgramasCodigo", "ProgramasMapaSecuencia", "ProgramasMapa", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            ProgramasMapaId = DetailId
            ProgramasMapaInsert = ProgramasMapa.ProgramasMapaUpdate(DetailId, CStr(ProgramasCodigo), CLng(ProgramasMapaSecuencia), CStr(StakeholdersCodigo), CStr(ProgramasMapaMesEvaluacion), CLng(ProgramasMapaImportancia), CStr(ProgramasMapaTipoGestion), CLng(ProgramasMapaPuntajePoder), CLng(ProgramasMapaPuntajeRelevancia), CStr(ProgramasMapaRol), CStr(ProgramasMapaFuncion), CStr(ProgramasMapaRelacion), UserId)
        Catch
            ProgramasMapaInsert = 0
        End Try
    End Function
    Public Function ProgramasMapaDelete(ByVal ProgramasMapaId As Long, ByVal ProgramasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (ProgramasMapa) "
        strUpdate = strUpdate & "WHERE (ProgramasMapa.ProgramasMapaId = " & ProgramasMapaId & ") "
        Try
            ProgramasMapaDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & ProgramasCodigo, ProgramasMapaId, "ProgramasMapa", "")
        Catch
            ProgramasMapaDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & ProgramasCodigo, ProgramasMapaId, "ProgramasMapa", "")
        End Try
    End Function
    Public Function PriorizacionPorStakeholdersInsert(ByVal ProgramasMapaId As Long, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim AccionesABM As New AccionesABM
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Id As Long = 0

        sSQL = "Select SubGruposPriorizacionId "
        sSQL = sSQL & "FROM SubGruposPriorizacion "
        sSQL = sSQL & "ORDER BY SubGruposPriorizacionId"
        PriorizacionPorStakeholdersInsert = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Id = CLng(dtr("SubGruposPriorizacionId").ToString)
                PriorizacionPorStakeholdersInsert = AccionesABM.PriorizacionPorStakeholdersInsert("PriorizacionPorStakeholders", "ProgramasMapa", "SubGruposPriorizacion", ProgramasMapaId, Id, UserId)
            End While
            dtr.Close()
        Catch
            PriorizacionPorStakeholdersInsert = 0
        End Try
    End Function
    Public Function PriorizacionPorStakeholdersDelete(ByVal ProgramasMapaId As Long, ByVal ProgramasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (PriorizacionPorStakeholders) "
        strUpdate = strUpdate & "WHERE (PriorizacionPorStakeholders.ProgramasMapaId = " & ProgramasMapaId & ") "
        Try
            PriorizacionPorStakeholdersDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Priorizacion por Stakeholders de : " & ProgramasCodigo, ProgramasMapaId, "PriorizacionPorStakeholders", "")
        Catch
            PriorizacionPorStakeholdersDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar Priorizacion por Stakeholders de : " & ProgramasCodigo, ProgramasMapaId, "PriorizacionPorStakeholders", "")
        End Try
    End Function
    Public Function LeerProgramasMapaIdByPriorizacionPorStakeholdersId(ByVal PriorizacionPorStakeholdersId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasMapaId "
        sSQL = sSQL & "FROM (PriorizacionPorStakeholders) "
        sSQL = sSQL & "WHERE (PriorizacionPorStakeholders.PriorizacionPorStakeholdersId = " & PriorizacionPorStakeholdersId & ") "
        LeerProgramasMapaIdByPriorizacionPorStakeholdersId = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerProgramasMapaIdByPriorizacionPorStakeholdersId = CLng(dtr("ProgramasMapaId").ToString)
            End While
            dtr.Close()
        Catch
            LeerProgramasMapaIdByPriorizacionPorStakeholdersId = 0
        End Try
    End Function
    Public Function Puntaje(ByVal ProgramasMapaId As Long, ByVal GruposPriorizacionId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'sSQL = "SELECT Sum(PriorizacionPorStakeholders.PriorizacionPorStakeholdersValor) AS Puntaje "
        'sSQL = sSQL & "FROM ((GruposPriorizacion INNER JOIN SubGruposPriorizacion ON GruposPriorizacion.GruposPriorizacionCodigo = SubGruposPriorizacion.GruposPriorizacionCodigo) INNER JOIN PriorizacionPorStakeholders ON SubGruposPriorizacion.SubGruposPriorizacionId = PriorizacionPorStakeholders.SubGruposPriorizacionId) INNER JOIN ProgramasMapa ON PriorizacionPorStakeholders.ProgramasMapaId = ProgramasMapa.ProgramasMapaId "
        'sSQL = sSQL & "GROUP BY GruposPriorizacion.GruposPriorizacionCodigo, PriorizacionPorStakeholders.ProgramasMapaId "
        'sSQL = sSQL & "HAVING (((GruposPriorizacion.GruposPriorizacionCodigo)='" & GruposPriorizacionCodigo & "') AND ((PriorizacionPorStakeholders.ProgramasMapaId)=" & ProgramasMapaId & "))"

        sSQL = "SELECT Sum(PriorizacionPorStakeholders.PriorizacionPorStakeholdersValor) AS Puntaje "
        sSQL = sSQL & "FROM ((GruposPriorizacion INNER JOIN SubGruposPriorizacion ON GruposPriorizacion.GruposPriorizacionCodigo = SubGruposPriorizacion.GruposPriorizacionCodigo) INNER JOIN PriorizacionPorStakeholders ON SubGruposPriorizacion.SubGruposPriorizacionId = PriorizacionPorStakeholders.SubGruposPriorizacionId) INNER JOIN ProgramasMapa ON PriorizacionPorStakeholders.ProgramasMapaId = ProgramasMapa.ProgramasMapaId "
        sSQL = sSQL & "GROUP BY GruposPriorizacion.GruposPriorizacionId, PriorizacionPorStakeholders.ProgramasMapaId "
        sSQL = sSQL & "HAVING (((GruposPriorizacion.GruposPriorizacionId)=" & GruposPriorizacionId & ") AND ((PriorizacionPorStakeholders.ProgramasMapaId)=" & ProgramasMapaId & "));"

        Puntaje = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Puntaje = CLng(dtr("Puntaje").ToString)
            End While
            dtr.Close()
        Catch
            Puntaje = 0
        End Try
    End Function
    Public Function LeerProgramasCodigo(ByVal ProgramasMapaId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasCodigo "
        sSQL = sSQL & "FROM (ProgramasMapa) "
        sSQL = sSQL & "WHERE (ProgramasMapa.ProgramasMapaId = " & ProgramasMapaId & ") "
        LeerProgramasCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerProgramasCodigo = CStr(dtr("ProgramasCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerProgramasCodigo = ""
        End Try
    End Function
    Public Function LeerStakeholdersCodigo(ByVal ProgramasMapaId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select StakeholdersCodigo "
        sSQL = sSQL & "FROM (ProgramasMapa) "
        sSQL = sSQL & "WHERE (ProgramasMapa.ProgramasMapaId = " & ProgramasMapaId & ") "
        LeerStakeholdersCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerStakeholdersCodigo = CStr(dtr("StakeholdersCodigo").ToString)
            End While
            dtr.Close()
        Catch
            LeerStakeholdersCodigo = ""
        End Try
    End Function
    Public Function CantidadStakeholdersPorTipoGestion(ByVal ProgramasCodigo As String, ByVal ProgramasMapaTipoGestion As String) As Integer
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Count(ProgramasMapa.ProgramasMapaTipoGestion) AS Total "
        sSQL = sSQL & "FROM(ProgramasMapa) "
        sSQL = sSQL & "WHERE (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "') AND ((ProgramasMapa.ProgramasMapaTipoGestion)='" & ProgramasMapaTipoGestion & "'))"

        CantidadStakeholdersPorTipoGestion = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CantidadStakeholdersPorTipoGestion = CInt(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            CantidadStakeholdersPorTipoGestion = 0
        End Try
    End Function
    Public Function CantidadStakeholdersPorPrograma(ByVal ProgramasCodigo As String) As Integer
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM(ProgramasMapa) "
        sSQL = sSQL & "WHERE (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "'))"

        CantidadStakeholdersPorPrograma = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CantidadStakeholdersPorPrograma = CInt(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            CantidadStakeholdersPorPrograma = 0
        End Try
    End Function
    Public Function GetdstPuntajes(ByRef rptPuntajes As Repeater, ByVal ProgramasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim PuntajePoder As Integer = 0
        Dim PuntajeRelevancia As Integer = 0
        Dim Valor As Integer = 0

        Dim dtblPuntajes As DataTable
        Dim dcolColumn As DataColumn
        Dim drowItem As DataRow
        Dim dvwPuntajes As DataView

        'Crear el DataTable
        dtblPuntajes = New DataTable("Puntajes")

        'Crea Columnas
        dcolColumn = New DataColumn("StakeholderName", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Comunicacional", GetType(Integer))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Movilizacion", GetType(Integer))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Conflictividad", GetType(Integer))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Posicion", GetType(Integer))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("PoderLegal", GetType(Integer))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Interes", GetType(Integer))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Apoyo", GetType(Integer))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Participacion", GetType(Integer))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Puntaje", GetType(Integer))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Gestion", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)



        sSQL = "SELECT ProgramasMapa.StakeholdersCodigo As Stakeholder, SubGruposPriorizacion.SubGruposPriorizacionName as SubGrupo, PriorizacionPorStakeholders.PriorizacionPorStakeholdersValor as Valor "
        sSQL = sSQL & "FROM (((PriorizacionPorStakeholders INNER JOIN ProgramasMapa ON PriorizacionPorStakeholders.ProgramasMapaId = ProgramasMapa.ProgramasMapaId) INNER JOIN Programas ON ProgramasMapa.ProgramasCodigo = Programas.ProgramasCodigo) INNER JOIN SubGruposPriorizacion ON PriorizacionPorStakeholders.SubGruposPriorizacionId = SubGruposPriorizacion.SubGruposPriorizacionId) INNER JOIN GruposPriorizacion ON SubGruposPriorizacion.GruposPriorizacionCodigo = GruposPriorizacion.GruposPriorizacionCodigo "
        sSQL = sSQL & "WHERE (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "')) "
        sSQL = sSQL & "ORDER BY ProgramasMapa.ProgramasMapaSecuencia, GruposPriorizacion.GruposPriorizacionSecuencia, SubGruposPriorizacion.SubGruposPriorizacionSecuencia"
        i = 1
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If i = 9 Then
                    i = 1
                End If
                If i = 1 Then 'Nuevo Stakeholder
                    drowItem = dtblPuntajes.NewRow()
                    PuntajePoder = 0
                    PuntajeRelevancia = 0
                    drowItem("StakeholderName") = dtr("Stakeholder").ToString
                    drowItem("Comunicacional") = CInt(dtr("Valor").ToString)
                    PuntajePoder = PuntajePoder + CInt(dtr("Valor").ToString)
                Else
                    If i = 2 Then
                        drowItem("Movilizacion") = CInt(dtr("Valor").ToString)
                        PuntajePoder = PuntajePoder + CInt(dtr("Valor").ToString)
                    Else
                        If i = 3 Then
                            drowItem("Conflictividad") = CInt(dtr("Valor").ToString)
                            PuntajePoder = PuntajePoder + CInt(dtr("Valor").ToString)
                        Else
                            If i = 4 Then
                                drowItem("Posicion") = CInt(dtr("Valor").ToString)
                                PuntajePoder = PuntajePoder + CInt(dtr("Valor").ToString)
                            Else
                                If i = 5 Then
                                    drowItem("PoderLegal") = CInt(dtr("Valor").ToString)
                                    PuntajePoder = PuntajePoder + CInt(dtr("Valor").ToString)
                                Else
                                    If i = 6 Then
                                        drowItem("Interes") = CInt(dtr("Valor").ToString)
                                        PuntajeRelevancia = PuntajeRelevancia + CInt(dtr("Valor").ToString)
                                    Else
                                        If i = 7 Then
                                            drowItem("Apoyo") = CInt(dtr("Valor").ToString)
                                            PuntajeRelevancia = PuntajeRelevancia + CInt(dtr("Valor").ToString)
                                        Else
                                            drowItem("Participacion") = CInt(dtr("Valor").ToString)
                                            PuntajeRelevancia = PuntajeRelevancia + CInt(dtr("Valor").ToString)
                                            Valor = CInt((PuntajePoder / 5) * (PuntajeRelevancia))
                                            If Valor >= 18 Then
                                                drowItem("Puntaje") = Valor
                                                drowItem("Gestion") = "<td style=""width:100; text-align:center; background-color: #FF0000; color: #FFFFFF; height: 25px; width: 75px"">Especial</td>"
                                            End If
                                            If Valor >= 7 And Valor < 18 Then
                                                drowItem("Puntaje") = Valor
                                                drowItem("Gestion") = "<td style=""width:100; text-align:center; background-color: #FFCC00; color: #FFFFFF; height: 25px; width: 75px"">General</td>"
                                            End If
                                            If Valor >= 1 And Valor < 7 Then
                                                drowItem("Puntaje") = Valor
                                                drowItem("Gestion") = "<td style=""width:100; text-align:center; background-color: #FFFF00; height: 25px; width: 75px"">General</td>"
                                            End If
                                            dtblPuntajes.Rows.Add(drowItem)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
                i = i + 1
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
    Public Function GetMatriz(ByRef rptMatriz As GridView, ByVal ProgramasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim ProgramasMapa As New ProgramasMapa
        Dim dtr As IDataReader
        Dim dtrStakeholders As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim TipoAccion As String = ""
        Dim TotalStakeholders As Integer = ProgramasMapa.CantidadStakeholdersPorTipoGestion(ProgramasCodigo, "Gestión General") + ProgramasMapa.CantidadStakeholdersPorTipoGestion(ProgramasCodigo, "Gestión Especial")
        Dim dtblMatriz As DataTable
        Dim dcolColumn As DataColumn
        Dim drowItem As DataRow
        Dim dvwMatriz As DataView

        'Doy formato a la GridView
        'No lo necesita basta con el nombre ya que hay un conjunto de estilos asociados
        'al nombre de la clase
        'rptMatriz.HeaderStyle.CssClass = "grilla_top"
        'rptMatriz.RowStyle.CssClass = "grilla_Fila1"
        rptMatriz.AlternatingRowStyle.CssClass = "alt"

        'Crear el DataTable
        dtblMatriz = New DataTable("Matriz")

        'Crea Columnas
        'La primera corresponde a la variable
        dcolColumn = New DataColumn("Variable", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        'Las segundas columnas corresponden a los valores de la variable de la primera columna, pero por cada actor
        'Para ello debo dar al campo un valor relacionado con la secuencia del actor dentro de programa

        sSQL = "Select ProgramasMapa.ProgramasMapaSecuencia as Sec "
        sSQL = sSQL & "From ProgramasMapa "
        sSQL = sSQL & "Where (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "')) "
        sSQL = sSQL & "Order by ProgramasMapa.ProgramasMapaSecuencia"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                dcolColumn = New DataColumn("Actor" & dtr("Sec").ToString, GetType(String))
                dcolColumn.DefaultValue = " "
                dtblMatriz.Columns.Add(dcolColumn)
            End While
            dtr.Close()
        Catch ex As Exception

        End Try
        'Con esto tengo creada la Tabla en memoria en la que guardare temporalmente los datos del informe

        'Primero poblare los primeros 4 registros de la tabla con los datos de cada stakeholder
        'Variables: Nombre, Grupo, SubGrupo y TipoGestion
        'Este es un metodo carretero pero que da el resultado esperado.
        'Por cada variable haremos una lectura que involucre a todos los stakeholders de un mismo programa
        'Luego recorreremos el resultado, actualizando los campos que correspondan según el número de secuencia del stakeholder
        'Partamos con el nombre de los stakeholders.

        drowItem = dtblMatriz.NewRow()
        drowItem("Variable") = "Stakeholder"

        sSQL = "Select ProgramasMapa.ProgramasMapaSecuencia as Sec, ProgramasMapa.StakeholdersCodigo As Stakeholder "
        sSQL = sSQL & "From ProgramasMapa "
        sSQL = sSQL & "Where (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "')) "
        sSQL = sSQL & "Order by ProgramasMapa.ProgramasMapaSecuencia"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                drowItem("Actor" & dtr("Sec").ToString) = dtr("Stakeholder").ToString
            End While
            dtblMatriz.Rows.Add(drowItem)
            dtr.Close()
        Catch ex As Exception

        End Try

        drowItem = dtblMatriz.NewRow()
        drowItem("Variable") = "Grupo"

        sSQL = "SELECT ProgramasMapa.ProgramasMapaSecuencia as Sec, Grupos.GruposName as Grupo "
        sSQL = sSQL & "FROM (((ProgramasMapa INNER JOIN Stakeholders ON ProgramasMapa.StakeholdersCodigo = Stakeholders.StakeholdersCodigo) INNER JOIN StakeholdersPorSubGrupos ON Stakeholders.StakeholdersId = StakeholdersPorSubGrupos.StakeholdersId) INNER JOIN SubGrupos ON StakeholdersPorSubGrupos.SubGruposId = SubGrupos.SubGruposId) INNER JOIN Grupos ON SubGrupos.GruposCodigo = Grupos.GruposCodigo "
        sSQL = sSQL & "WHERE (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "')) "
        sSQL = sSQL & "ORDER BY ProgramasMapa.ProgramasMapaSecuencia"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                drowItem("Actor" & dtr("Sec").ToString) = dtr("Grupo").ToString
            End While
            dtblMatriz.Rows.Add(drowItem)
            dtr.Close()
        Catch ex As Exception

        End Try

        drowItem = dtblMatriz.NewRow()
        drowItem("Variable") = "SubGrupo"

        sSQL = "SELECT ProgramasMapa.ProgramasMapaSecuencia as Sec, SubGrupos.SubGruposName as SubGrupo "
        sSQL = sSQL & "FROM (((ProgramasMapa INNER JOIN Stakeholders ON ProgramasMapa.StakeholdersCodigo = Stakeholders.StakeholdersCodigo) INNER JOIN StakeholdersPorSubGrupos ON Stakeholders.StakeholdersId = StakeholdersPorSubGrupos.StakeholdersId) INNER JOIN SubGrupos ON StakeholdersPorSubGrupos.SubGruposId = SubGrupos.SubGruposId) INNER JOIN Grupos ON SubGrupos.GruposCodigo = Grupos.GruposCodigo "
        sSQL = sSQL & "WHERE (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "')) "
        sSQL = sSQL & "ORDER BY ProgramasMapa.ProgramasMapaSecuencia"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                drowItem("Actor" & dtr("Sec").ToString) = dtr("SubGrupo").ToString
            End While
            dtblMatriz.Rows.Add(drowItem)
            dtr.Close()
        Catch ex As Exception

        End Try

        drowItem = dtblMatriz.NewRow()
        drowItem("Variable") = "TipoGestion"

        sSQL = "SELECT ProgramasMapa.ProgramasMapaSecuencia as Sec, ProgramasMapa.ProgramasMapaTipoGestion As TipoGestion, ProgramasMapa.ProgramasMapaImportancia "
        sSQL = sSQL & "FROM (((ProgramasMapa INNER JOIN Stakeholders ON ProgramasMapa.StakeholdersCodigo = Stakeholders.StakeholdersCodigo) INNER JOIN StakeholdersPorSubGrupos ON Stakeholders.StakeholdersId = StakeholdersPorSubGrupos.StakeholdersId) INNER JOIN SubGrupos ON StakeholdersPorSubGrupos.SubGruposId = SubGrupos.SubGruposId) INNER JOIN Grupos ON SubGrupos.GruposCodigo = Grupos.GruposCodigo "
        sSQL = sSQL & "WHERE (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "')) "
        sSQL = sSQL & "ORDER BY ProgramasMapa.ProgramasMapaSecuencia"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If CInt(dtr("ProgramasMapaImportancia").ToString) > 17 Then
                    drowItem("Actor" & dtr("Sec").ToString) = "Gestión Especial"
                Else
                    drowItem("Actor" & dtr("Sec").ToString) = "Gestión General"
                End If
                'drowItem("Actor" & dtr("Sec").ToString) = dtr("TipoGestion").ToString
            End While
            dtblMatriz.Rows.Add(drowItem)
            dtr.Close()
            dvwMatriz = dtblMatriz.DefaultView
            rptMatriz.DataSource = dvwMatriz
            rptMatriz.DataBind()
            GetMatriz = True
        Catch ex As Exception
            GetMatriz = False
        End Try

    End Function
    Public Function GetActividades(ByRef rptMatriz As GridView, ByVal ProgramasCodigo As String, ByVal ObjetivosCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim ProgramasMapa As New ProgramasMapa
        Dim dtr As IDataReader
        Dim dtrStakeholders As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim TipoAccion As String = ""
        Dim TotalStakeholders As Integer = ProgramasMapa.CantidadStakeholdersPorTipoGestion(ProgramasCodigo, "Gestión General") + ProgramasMapa.CantidadStakeholdersPorTipoGestion(ProgramasCodigo, "Gestión Especial")
        Dim dtblMatriz As DataTable
        Dim dcolColumn As DataColumn
        Dim drowItem As DataRow
        Dim dvwMatriz As DataView

        'Doy formato a la GridView
        'rptMatriz.HeaderStyle.CssClass = "grilla_top"
        'rptMatriz.RowStyle.CssClass = "grilla_Fila1"
        rptMatriz.AlternatingRowStyle.CssClass = "alt"

        'Crear el DataTable
        dtblMatriz = New DataTable("Matriz")

        'Crea Columnas
        'La primera corresponde a la variable
        dcolColumn = New DataColumn("Actividad", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        'Las segundas columnas corresponden a los valores de la variable de la primera columna, pero por cada actor
        'Para ello debo dar al campo un valor relacionado con la secuencia del actor dentro de programa

        sSQL = "Select ProgramasMapa.ProgramasMapaSecuencia as Sec "
        sSQL = sSQL & "From ProgramasMapa "
        sSQL = sSQL & "Where (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "')) "
        sSQL = sSQL & "Order by ProgramasMapa.ProgramasMapaSecuencia"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                dcolColumn = New DataColumn("Actor" & dtr("Sec").ToString, GetType(String))
                dcolColumn.DefaultValue = " "
                dtblMatriz.Columns.Add(dcolColumn)
            End While
            dtr.Close()
        Catch ex As Exception

        End Try
        'Con esto tengo creada la Tabla en memoria en la que guardare temporalmente los datos del informe

        'Primero poblare los primeros 4 registros de la tabla con los datos de cada stakeholder
        'Variables: Nombre, Grupo, SubGrupo y TipoGestion
        'Este es un metodo carretero pero que da el resultado esperado.
        'Por cada variable haremos una lectura que involucre a todos los stakeholders de un mismo programa
        'Luego recorreremos el resultado, actualizando los campos que correspondan según el número de secuencia del stakeholder
        'Partamos con el nombre de los stakeholders.

        drowItem = dtblMatriz.NewRow()
        drowItem("Actividad") = "Stakeholder"

        sSQL = "Select ProgramasMapa.ProgramasMapaSecuencia as Sec, ProgramasMapa.StakeholdersCodigo As Stakeholder "
        sSQL = sSQL & "From ProgramasMapa "
        sSQL = sSQL & "Where (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "')) "
        sSQL = sSQL & "Order by ProgramasMapa.ProgramasMapaSecuencia"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                drowItem("Actor" & dtr("Sec").ToString) = dtr("Stakeholder").ToString
            End While
            dtblMatriz.Rows.Add(drowItem)
            dtr.Close()
        Catch ex As Exception

        End Try

        'Ahora me toca partir con las acciones y hacer lo mismo pero con el otro query.
        'Igual tengo que hacer algo anidado, primero me leo todas las acciones y luego a partir de cada
        'una hago el segundo query.
        'Me falta poco pero aqui voy.


        sSQL = "SELECT Acciones.AccionesId As Id, Acciones.AccionesCodigo, Objetivos.ObjetivosName As TipoAccion, Acciones.AccionesName As NombreAccion "
        sSQL = sSQL & "FROM ((Acciones INNER JOIN Metas ON Acciones.MetasCodigo = Metas.MetasCodigo) INNER JOIN Objetivos ON Metas.ObjetivosCodigo = Objetivos.ObjetivosCodigo) INNER JOIN Compromisos ON Objetivos.CompromisosCodigo = Compromisos.CompromisosCodigo "
        sSQL = sSQL & "WHERE(((Compromisos.CompromisosCodigo) = '1') AND ((Objetivos.ObjetivosCodigo) = '" & ObjetivosCodigo & "')) "  'Solo un tipo de acción a la vez
        sSQL = sSQL & "ORDER BY Objetivos.ObjetivosCodigo, Acciones.AccionesCodigo"
        i = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                'Primero creo una nueva fila en el DataTable con el nombre de la Acción
                drowItem = dtblMatriz.NewRow()
                drowItem("Actividad") = dtr("NombreAccion").ToString
                ' Continuación se leen todos los Stakeholders asociados a la misma AccionId y desde luego al mismo programa
                ' Para ello se hace una nueva lectura, en base al siguiente query

                sSQL = "SELECT Programas.ProgramasCodigo, ProgramasMapa.ProgramasMapaSecuencia As Sec, ProgramasMapa.StakeholdersCodigo, Objetivos.ObjetivosCodigo, Objetivos.ObjetivosName, Acciones.AccionesName "
                sSQL = sSQL & "FROM ((((Acciones INNER JOIN (Metas INNER JOIN Objetivos ON Metas.ObjetivosCodigo = Objetivos.ObjetivosCodigo) ON Acciones.MetasCodigo = Metas.MetasCodigo) INNER JOIN AccionesPorStakeholdersPorPrograma ON Acciones.AccionesId = AccionesPorStakeholdersPorPrograma.AccionesId) INNER JOIN ProgramasMapa ON AccionesPorStakeholdersPorPrograma.ProgramasMapaId = ProgramasMapa.ProgramasMapaId) INNER JOIN Programas ON ProgramasMapa.ProgramasCodigo = Programas.ProgramasCodigo) INNER JOIN Stakeholders ON ProgramasMapa.StakeholdersCodigo = Stakeholders.StakeholdersCodigo "
                sSQL = sSQL & "WHERE(((Programas.ProgramasCodigo) = '" & ProgramasCodigo & "') And ((Acciones.AccionesId) = " & dtr("Id").ToString & ")) "
                sSQL = sSQL & "ORDER BY ProgramasMapa.ProgramasMapaSecuencia, Objetivos.ObjetivosCodigo"

                Try
                    dtrStakeholders = AccesoEA.ListarRegistros(sSQL)
                    While dtrStakeholders.Read
                        drowItem("Actor" & dtrStakeholders("Sec").ToString) = "SI"
                    End While
                    dtrStakeholders.Close()
                Catch ex As Exception

                End Try
                dtblMatriz.Rows.Add(drowItem)
            End While
            dtr.Close()
            dvwMatriz = dtblMatriz.DefaultView
            rptMatriz.DataSource = dvwMatriz
            rptMatriz.DataBind()
            GetActividades = True
        Catch ex As Exception
            GetActividades = False
        End Try
    End Function
    Public Function LeerSecuenciaSiguiente(ByVal ProgramasCodigo As String, ByVal ProgramasMapaSecuencia As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        Dim NextSecuencia As Long = ProgramasMapaSecuencia + 1

        sSQL = "Select ProgramasMapa.ProgramasMapaId As Id "
        sSQL = sSQL & "FROM(ProgramasMapa) "
        sSQL = sSQL & "WHERE (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "') AND ((ProgramasMapa.ProgramasMapaSecuencia)=" & NextSecuencia & "))"

        LeerSecuenciaSiguiente = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerSecuenciaSiguiente = CLng(dtr("Id").ToString)
            End While
            dtr.Close()
        Catch
            LeerSecuenciaSiguiente = 0
        End Try
    End Function
    Public Function LeerSecuenciaAnterior(ByVal ProgramasCodigo As String, ByVal ProgramasMapaSecuencia As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        Dim NextSecuencia As Long

        If ProgramasMapaSecuencia > 1 Then
            NextSecuencia = ProgramasMapaSecuencia - 1
        Else
            NextSecuencia = ProgramasMapaSecuencia
        End If

        sSQL = "Select ProgramasMapa.ProgramasMapaId As Id "
        sSQL = sSQL & "FROM(ProgramasMapa) "
        sSQL = sSQL & "WHERE (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "') AND ((ProgramasMapa.ProgramasMapaSecuencia)=" & NextSecuencia & "))"

        LeerSecuenciaAnterior = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerSecuenciaAnterior = CLng(dtr("Id").ToString)
            End While
            dtr.Close()
        Catch
            LeerSecuenciaAnterior = 0
        End Try
    End Function
    Public Function LeerProgramasMapaId(ByVal ProgramasCodigo As String, ByVal StakeholdersCodigo As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select ProgramasMapa.ProgramasMapaId As Id "
        sSQL = sSQL & "FROM(ProgramasMapa) "
        sSQL = sSQL & "WHERE (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "') AND ((ProgramasMapa.StakeholdersCodigo)='" & StakeholdersCodigo & "'))"

        LeerProgramasMapaId = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerProgramasMapaId = CLng(dtr("Id").ToString)
            End While
            dtr.Close()
        Catch
            LeerProgramasMapaId = 0
        End Try
    End Function
    Public Function AccionesPorStakeholdersPorProgramaDelete(ByVal ProgramasMapaId As Long, ByVal ProgramasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (AccionesPorStakeholdersPorPrograma) "
        strUpdate = strUpdate & "WHERE (AccionesPorStakeholdersPorPrograma.ProgramasMapaId = " & ProgramasMapaId & ") "
        Try
            AccionesPorStakeholdersPorProgramaDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Priorizacion por Stakeholders de : " & ProgramasCodigo, ProgramasMapaId, "AccionesPorStakeholdersPorPrograma", "")
        Catch
            AccionesPorStakeholdersPorProgramaDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar Priorizacion por Stakeholders de : " & ProgramasCodigo, ProgramasMapaId, "AccionesPorStakeholdersPorPrograma", "")
        End Try
    End Function
    Public Function LeerProgramasMapaProgramaYStakeholder(ByVal ProgramasMapaId As Long, ByRef ProgramasCodigo As String, ByRef StakeholdersCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select ProgramasMapa.ProgramasCodigo As Programa, ProgramasMapa.StakeholdersCodigo As Stakeholder "
        sSQL = sSQL & "FROM ProgramasMapa "
        sSQL = sSQL & "WHERE ProgramasMapa.ProgramasMapaId=" & ProgramasMapaId

        LeerProgramasMapaProgramaYStakeholder = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProgramasCodigo = CStr(dtr("Programa"))
                StakeholdersCodigo = CStr(dtr("Stakeholder"))
                LeerProgramasMapaProgramaYStakeholder = True
            End While
            dtr.Close()
        Catch
            LeerProgramasMapaProgramaYStakeholder = False
        End Try
    End Function
    Public Function GetPlanActividades(ByRef rptFunciones As Repeater, ByVal ProgramasCodigo As String, ByVal ObjetivosCodigo As String) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Acciones.AccionesName As Actividad, Count(ProgramasMapa.StakeholdersCodigo) AS Stakeholders, Count(AccionesPorStakeholdersPorPrograma.UsuariosCodigo) AS Responsables, Count(AccionesPorStakeholdersPorPrograma.EmpresasCodigo) AS Asesores, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsEnero) AS Enero, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsFebrero) AS Febrero, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsMarzo) AS Marzo, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsAbril) AS Abril, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsMayo) AS Mayo, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsJunio) AS Junio, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsJulio) AS Julio, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsAgosto) AS Agosto, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsSeptiembre) AS Septiembre, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsOctubre) AS Octubre, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsNoviembre) AS Noviembre, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsDiciembre) AS Diciembre "
        sSQL = sSQL & "FROM (((ProgramasMapa INNER JOIN AccionesPorStakeholdersPorPrograma ON ProgramasMapa.ProgramasMapaId = AccionesPorStakeholdersPorPrograma.ProgramasMapaId) INNER JOIN Acciones ON AccionesPorStakeholdersPorPrograma.AccionesId = Acciones.AccionesId) INNER JOIN Metas ON Acciones.MetasCodigo = Metas.MetasCodigo) INNER JOIN Objetivos ON Metas.ObjetivosCodigo = Objetivos.ObjetivosCodigo "
        sSQL = sSQL & "GROUP BY ProgramasMapa.ProgramasCodigo, Objetivos.ObjetivosCodigo, Acciones.AccionesName "
        sSQL = sSQL & "HAVING (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "') AND ((Objetivos.ObjetivosCodigo)='" & ObjetivosCodigo & "'))"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptFunciones.DataSource = dtrFunciones
            rptFunciones.DataBind()
            GetPlanActividades = True
            dtrFunciones.Close()
        Catch
            GetPlanActividades = False
        End Try
    End Function
    Public Function GetPlanActividadesFollowUp(ByRef rptFunciones As Repeater, ByVal ProgramasCodigo As String, ByVal ObjetivosCodigo As String) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Acciones.AccionesName As Actividad, Count(ProgramasMapa.StakeholdersCodigo) AS Stakeholders, Count(AccionesPorStakeholdersPorPrograma.UsuariosCodigo) AS Responsables, Count(AccionesPorStakeholdersPorPrograma.EmpresasCodigo) AS Asesores, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsEnero) AS Enero, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsFebrero) AS Febrero, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsMarzo) AS Marzo, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsAbril) AS Abril, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsMayo) AS Mayo, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsJunio) AS Junio, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsJulio) AS Julio, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsAgosto) AS Agosto, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsSeptiembre) AS Septiembre, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsOctubre) AS Octubre, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsNoviembre) AS Noviembre, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsDiciembre) AS Diciembre "
        sSQL = sSQL & "FROM (((ProgramasMapa INNER JOIN AccionesPorStakeholdersPorPrograma ON ProgramasMapa.ProgramasMapaId = AccionesPorStakeholdersPorPrograma.ProgramasMapaId) INNER JOIN Acciones ON AccionesPorStakeholdersPorPrograma.AccionesId = Acciones.AccionesId) INNER JOIN Metas ON Acciones.MetasCodigo = Metas.MetasCodigo) INNER JOIN Objetivos ON Metas.ObjetivosCodigo = Objetivos.ObjetivosCodigo "
        sSQL = sSQL & "GROUP BY ProgramasMapa.ProgramasCodigo, Objetivos.ObjetivosCodigo, Acciones.AccionesName "
        sSQL = sSQL & "HAVING (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "') AND ((Objetivos.ObjetivosCodigo)='" & ObjetivosCodigo & "'))"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            rptFunciones.DataSource = dtrFunciones
            rptFunciones.DataBind()
            GetPlanActividadesFollowUp = True
            dtrFunciones.Close()
        Catch
            GetPlanActividadesFollowUp = False
        End Try
    End Function
    Public Function GetActividadesFollowUp(ByRef rptMatriz As GridView, ByVal ProgramasCodigo As String, ByVal ObjetivosCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim ProgramasMapa As New ProgramasMapa
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim TipoAccion As String = ""
        Dim TotalStakeholders As Integer = ProgramasMapa.CantidadStakeholdersPorTipoGestion(ProgramasCodigo, "Gestión General") + ProgramasMapa.CantidadStakeholdersPorTipoGestion(ProgramasCodigo, "Gestión Especial")
        Dim dtblMatriz As DataTable
        Dim dcolColumn As DataColumn
        Dim drowItem As DataRow
        Dim dvwMatriz As DataView

        'Doy formato a la GridView
        'rptMatriz.HeaderStyle.CssClass = "grilla_top"
        'rptMatriz.RowStyle.CssClass = "grilla_Fila1"
        rptMatriz.AlternatingRowStyle.CssClass = "alt"

        'Crear el DataTable
        dtblMatriz = New DataTable("Matriz")

        'Crea Columnas
        'La primera corresponde a la variable
        dcolColumn = New DataColumn("Actividad", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Stakeholders", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Responsables", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Asesores", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Enero", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Febrero", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Marzo", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Abril", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Mayo", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Junio", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Julio", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Agosto", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Septiembre", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Octubre", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Noviembre", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Diciembre", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)


        sSQL = "SELECT Acciones.AccionesName As Actividad, Count(ProgramasMapa.StakeholdersCodigo) AS Stakeholders, Count(AccionesPorStakeholdersPorPrograma.UsuariosCodigo) AS Responsables, Count(AccionesPorStakeholdersPorPrograma.EmpresasCodigo) AS Asesores, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsEnero) AS Enero, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsFebrero) AS Febrero, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsMarzo) AS Marzo, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsAbril) AS Abril, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsMayo) AS Mayo, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsJunio) AS Junio, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsJulio) AS Julio, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsAgosto) AS Agosto, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsSeptiembre) AS Septiembre, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsOctubre) AS Octubre, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsNoviembre) AS Noviembre, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsDiciembre) AS Diciembre "
        sSQL = sSQL & "FROM (((ProgramasMapa INNER JOIN AccionesPorStakeholdersPorPrograma ON ProgramasMapa.ProgramasMapaId = AccionesPorStakeholdersPorPrograma.ProgramasMapaId) INNER JOIN Acciones ON AccionesPorStakeholdersPorPrograma.AccionesId = Acciones.AccionesId) INNER JOIN Metas ON Acciones.MetasCodigo = Metas.MetasCodigo) INNER JOIN Objetivos ON Metas.ObjetivosCodigo = Objetivos.ObjetivosCodigo "
        sSQL = sSQL & "GROUP BY ProgramasMapa.ProgramasCodigo, Objetivos.ObjetivosCodigo, Acciones.AccionesName "
        sSQL = sSQL & "HAVING (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "') AND ((Objetivos.ObjetivosCodigo)='" & ObjetivosCodigo & "'))"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                drowItem = dtblMatriz.NewRow()
                drowItem("Actividad") = dtr("Actividad").ToString
                drowItem("Stakeholders") = dtr("Stakeholders").ToString
                drowItem("Responsables") = dtr("Responsables").ToString
                drowItem("Asesores") = dtr("Asesores").ToString
                drowItem("Enero") = dtr("Enero").ToString
                drowItem("Febrero") = dtr("Febrero").ToString
                drowItem("Marzo") = dtr("Marzo").ToString
                drowItem("Abril") = dtr("Abril").ToString
                drowItem("Mayo") = dtr("Mayo").ToString
                drowItem("Junio") = dtr("Junio").ToString
                drowItem("Julio") = dtr("Julio").ToString
                drowItem("Agosto") = dtr("Agosto").ToString
                drowItem("Septiembre") = dtr("Septiembre").ToString
                drowItem("Octubre") = dtr("Octubre").ToString
                drowItem("Noviembre") = dtr("Noviembre").ToString
                drowItem("Diciembre") = dtr("Diciembre").ToString
                dtblMatriz.Rows.Add(drowItem)
            End While

            dtr.Close()
            dvwMatriz = dtblMatriz.DefaultView
            rptMatriz.DataSource = dvwMatriz
            rptMatriz.DataBind()
            GetActividadesFollowUp = True
        Catch ex As Exception
            GetActividadesFollowUp = False
        End Try
    End Function
    Public Function GetActividadesFollowUpConRepeater(ByRef rptMatriz As Repeater, ByVal ProgramasCodigo As String, ByVal ObjetivosCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim ProgramasMapa As New ProgramasMapa
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim TipoAccion As String = ""
        Dim TotalStakeholders As Integer = ProgramasMapa.CantidadStakeholdersPorTipoGestion(ProgramasCodigo, "Gestión General") + ProgramasMapa.CantidadStakeholdersPorTipoGestion(ProgramasCodigo, "Gestión Especial")
        Dim dtblMatriz As DataTable
        Dim dcolColumn As DataColumn
        Dim drowItem As DataRow
        Dim dvwMatriz As DataView

        'Doy formato a la GridView
        'rptMatriz.HeaderStyle.CssClass = "grilla_top"
        'rptMatriz.RowStyle.CssClass = "grilla_Fila1"
        'rptMatriz.AlternatingRowStyle.CssClass = "alt"

        'Crear el DataTable
        dtblMatriz = New DataTable("Matriz")

        'Crea Columnas
        'La primera corresponde a la variable
        dcolColumn = New DataColumn("Actividad", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Stakeholders", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Responsables", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Asesores", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Enero", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Febrero", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Marzo", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Abril", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Mayo", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Junio", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Julio", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Agosto", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Septiembre", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Octubre", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Noviembre", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Diciembre", GetType(String))
        dtblMatriz.Columns.Add(dcolColumn)


        sSQL = "SELECT Acciones.AccionesName As Actividad, Count(ProgramasMapa.StakeholdersCodigo) AS Stakeholders, Count(AccionesPorStakeholdersPorPrograma.UsuariosCodigo) AS Responsables, Count(AccionesPorStakeholdersPorPrograma.EmpresasCodigo) AS Asesores, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsEnero) AS Enero, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsFebrero) AS Febrero, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsMarzo) AS Marzo, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsAbril) AS Abril, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsMayo) AS Mayo, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsJunio) AS Junio, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsJulio) AS Julio, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsAgosto) AS Agosto, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsSeptiembre) AS Septiembre, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsOctubre) AS Octubre, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsNoviembre) AS Noviembre, Sum(AccionesPorStakeholdersPorPrograma.AccionesIsDiciembre) AS Diciembre "
        sSQL = sSQL & "FROM (((ProgramasMapa INNER JOIN AccionesPorStakeholdersPorPrograma ON ProgramasMapa.ProgramasMapaId = AccionesPorStakeholdersPorPrograma.ProgramasMapaId) INNER JOIN Acciones ON AccionesPorStakeholdersPorPrograma.AccionesId = Acciones.AccionesId) INNER JOIN Metas ON Acciones.MetasCodigo = Metas.MetasCodigo) INNER JOIN Objetivos ON Metas.ObjetivosCodigo = Objetivos.ObjetivosCodigo "
        sSQL = sSQL & "GROUP BY ProgramasMapa.ProgramasCodigo, Objetivos.ObjetivosCodigo, Acciones.AccionesName "
        sSQL = sSQL & "HAVING (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "') AND ((Objetivos.ObjetivosCodigo)='" & ObjetivosCodigo & "'))"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                drowItem = dtblMatriz.NewRow()
                drowItem("Actividad") = dtr("Actividad").ToString
                drowItem("Stakeholders") = dtr("Stakeholders").ToString
                drowItem("Responsables") = dtr("Responsables").ToString
                drowItem("Asesores") = dtr("Asesores").ToString
                drowItem("Enero") = dtr("Enero").ToString & "</br>2</br>1"
                drowItem("Febrero") = dtr("Febrero").ToString & "</br>2</br>1"
                drowItem("Marzo") = dtr("Marzo").ToString & "</br>2</br>1"
                drowItem("Abril") = dtr("Abril").ToString & "</br>2</br>1"
                drowItem("Mayo") = dtr("Mayo").ToString
                drowItem("Junio") = dtr("Junio").ToString
                drowItem("Julio") = dtr("Julio").ToString
                drowItem("Agosto") = dtr("Agosto").ToString
                drowItem("Septiembre") = dtr("Septiembre").ToString
                drowItem("Octubre") = dtr("Octubre").ToString
                drowItem("Noviembre") = dtr("Noviembre").ToString
                drowItem("Diciembre") = dtr("Diciembre").ToString & "</br>2</br>1"
                dtblMatriz.Rows.Add(drowItem)
            End While

            dtr.Close()
            dvwMatriz = dtblMatriz.DefaultView
            rptMatriz.DataSource = dvwMatriz
            rptMatriz.DataBind()
            GetActividadesFollowUpConRepeater = True
        Catch ex As Exception
            GetActividadesFollowUpConRepeater = False
        End Try
    End Function
    Public Function GetReporteSE1(ByRef rptPuntajes As Repeater, ByVal ProgramasCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim PuntajePoder As Integer = 0
        Dim PuntajeRelevancia As Integer = 0
        Dim Valor As Integer = 0

        Dim dtblPuntajes As DataTable
        Dim dcolColumn As DataColumn
        Dim drowItem As DataRow
        Dim dvwPuntajes As DataView

        Dim SubGrupos As New SubGrupos
        Dim GruposName As String = ""
        Dim SubgruposName As String = ""
        Dim t As Boolean


        'Crear el DataTable
        dtblPuntajes = New DataTable("Puntajes")

        'Crea Columnas
        dcolColumn = New DataColumn("Stakeholders", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Grupos", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Subgrupos", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)

        sSQL = "SELECT ProgramasMapa.StakeholdersCodigo AS Stakeholders  "
        sSQL = sSQL & "FROM ProgramasMapa "
        sSQL = sSQL & "WHERE (((ProgramasMapa.ProgramasCodigo)='" & ProgramasCodigo & "'));"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                drowItem = dtblPuntajes.NewRow()
                PuntajePoder = 0
                PuntajeRelevancia = 0
                drowItem("Stakeholders") = dtr("Stakeholders").ToString
                t = SubGrupos.LeerPrimerGrupoSubGrupoPorStakeholders(GruposName, SubgruposName, dtr("Stakeholders").ToString)
                drowItem("Grupos") = GruposName
                drowItem("Subgrupos") = SubgruposName
                dtblPuntajes.Rows.Add(drowItem)
            End While
            dvwPuntajes = dtblPuntajes.DefaultView
            rptPuntajes.DataSource = dvwPuntajes
            rptPuntajes.DataBind()
            dtr.Close()
            GetReporteSE1 = True
        Catch
            GetReporteSE1 = False
        End Try
    End Function

End Class
