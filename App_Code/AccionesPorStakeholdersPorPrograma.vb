Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class AccionesPorStakeholdersPorPrograma
    Public Function LeerAccionesPorStakeholdersPorPrograma(ByVal AccionesPorStakeholdersPorProgramaId As Long, ByRef ProgramasMapaId As Long, ByRef AccionesId As Long, ByRef UsuariosCodigo As String, ByRef EmpresasCodigo As String, ByRef AccionesHH As Double, ByRef AccionesUSD As Double, ByRef AccionesIsEnero As Long, ByRef AccionesIsFebrero As Long, ByRef AccionesIsMarzo As Long, ByRef AccionesIsAbril As Long, ByRef AccionesIsMayo As Long, ByRef AccionesIsJunio As Long, ByRef AccionesIsJulio As Long, ByRef AccionesIsAgosto As Long, ByRef AccionesIsSeptiembre As Long, ByRef AccionesIsOctubre As Long, ByRef AccionesIsNoviembre As Long, ByRef AccionesIsDiciembre As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasMapaId, AccionesId, UsuariosCodigo, EmpresasCodigo, AccionesHH, AccionesUSD, AccionesIsEnero, AccionesIsFebrero, AccionesIsMarzo, AccionesIsAbril, AccionesIsMayo, AccionesIsJunio, AccionesIsJulio, AccionesIsAgosto, AccionesIsSeptiembre, AccionesIsOctubre, AccionesIsNoviembre, AccionesIsDiciembre "
        sSQL = sSQL & "FROM (AccionesPorStakeholdersPorPrograma) "
        sSQL = sSQL & "WHERE (AccionesPorStakeholdersPorPrograma.AccionesPorStakeholdersPorProgramaId = " & AccionesPorStakeholdersPorProgramaId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProgramasMapaId = CLng(dtr("ProgramasMapaId").ToString)
                AccionesId = CLng(dtr("AccionesId").ToString)
                UsuariosCodigo = CStr(dtr("UsuariosCodigo").ToString)
                EmpresasCodigo = CStr(dtr("EmpresasCodigo").ToString)
                If Len(dtr("AccionesHH").ToString) = 0 Then
                    AccionesHH = 0
                Else
                    AccionesHH = CDbl(dtr("AccionesHH").ToString)
                End If
                If Len(dtr("AccionesUSD").ToString) = 0 Then
                    AccionesUSD = 0
                Else
                    AccionesUSD = CDbl(dtr("AccionesUSD").ToString)
                End If
                If Len(dtr("AccionesIsEnero").ToString) = 0 Then
                    AccionesIsEnero = 0
                Else
                    AccionesIsEnero = CLng(dtr("AccionesIsEnero").ToString)
                End If
                If Len(dtr("AccionesIsFebrero").ToString) = 0 Then
                    AccionesIsFebrero = 0
                Else
                    AccionesIsFebrero = CLng(dtr("AccionesIsFebrero").ToString)
                End If
                If Len(dtr("AccionesIsMarzo").ToString) = 0 Then
                    AccionesIsMarzo = 0
                Else
                    AccionesIsMarzo = CLng(dtr("AccionesIsMarzo").ToString)
                End If
                If Len(dtr("AccionesIsAbril").ToString) = 0 Then
                    AccionesIsAbril = 0
                Else
                    AccionesIsAbril = CLng(dtr("AccionesIsAbril").ToString)
                End If
                If Len(dtr("AccionesIsMayo").ToString) = 0 Then
                    AccionesIsMayo = 0
                Else
                    AccionesIsMayo = CLng(dtr("AccionesIsMayo").ToString)
                End If
                If Len(dtr("AccionesIsJunio").ToString) = 0 Then
                    AccionesIsJunio = 0
                Else
                    AccionesIsJunio = CLng(dtr("AccionesIsJunio").ToString)
                End If
                If Len(dtr("AccionesIsJulio").ToString) = 0 Then
                    AccionesIsJulio = 0
                Else
                    AccionesIsJulio = CLng(dtr("AccionesIsJulio").ToString)
                End If
                If Len(dtr("AccionesIsAgosto").ToString) = 0 Then
                    AccionesIsAgosto = 0
                Else
                    AccionesIsAgosto = CLng(dtr("AccionesIsAgosto").ToString)
                End If
                If Len(dtr("AccionesIsSeptiembre").ToString) = 0 Then
                    AccionesIsSeptiembre = 0
                Else
                    AccionesIsSeptiembre = CLng(dtr("AccionesIsSeptiembre").ToString)
                End If
                If Len(dtr("AccionesIsOctubre").ToString) = 0 Then
                    AccionesIsOctubre = 0
                Else
                    AccionesIsOctubre = CLng(dtr("AccionesIsOctubre").ToString)
                End If
                If Len(dtr("AccionesIsNoviembre").ToString) = 0 Then
                    AccionesIsNoviembre = 0
                Else
                    AccionesIsNoviembre = CLng(dtr("AccionesIsNoviembre").ToString)
                End If
                If Len(dtr("AccionesIsDiciembre").ToString) = 0 Then
                    AccionesIsDiciembre = 0
                Else
                    AccionesIsDiciembre = CLng(dtr("AccionesIsDiciembre").ToString)
                End If
            End While
            LeerAccionesPorStakeholdersPorPrograma = True
            dtr.Close()
        Catch
            LeerAccionesPorStakeholdersPorPrograma = False
        End Try
    End Function
    Public Function AccionesPorStakeholdersPorProgramaUpdate(ByVal AccionesPorStakeholdersPorProgramaId As Long, ByRef UsuariosCodigo As String, ByRef EmpresasCodigo As String, ByRef AccionesHH As Double, ByRef AccionesUSD As Double, ByRef AccionesIsEnero As Long, ByRef AccionesIsFebrero As Long, ByRef AccionesIsMarzo As Long, ByRef AccionesIsAbril As Long, ByRef AccionesIsMayo As Long, ByRef AccionesIsJunio As Long, ByRef AccionesIsJulio As Long, ByRef AccionesIsAgosto As Long, ByRef AccionesIsSeptiembre As Long, ByRef AccionesIsOctubre As Long, ByRef AccionesIsNoviembre As Long, ByRef AccionesIsDiciembre As Long, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE AccionesPorStakeholdersPorPrograma SET "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.UsuariosCodigo = '" & UsuariosCodigo & "', "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.EmpresasCodigo = '" & EmpresasCodigo & "', "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.AccionesHH = " & AccionesHH & ", "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.AccionesUSD = " & AccionesUSD & ", "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.AccionesIsEnero = " & AccionesIsEnero & ", "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.AccionesIsFebrero = " & AccionesIsFebrero & ", "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.AccionesIsMarzo = " & AccionesIsMarzo & ", "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.AccionesIsAbril = " & AccionesIsAbril & ", "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.AccionesIsMayo = " & AccionesIsMayo & ", "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.AccionesIsJunio = " & AccionesIsJunio & ", "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.AccionesIsJulio = " & AccionesIsJulio & ", "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.AccionesIsAgosto = " & AccionesIsAgosto & ", "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.AccionesIsSeptiembre = " & AccionesIsSeptiembre & ", "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.AccionesIsOctubre = " & AccionesIsOctubre & ", "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.AccionesIsNoviembre = " & AccionesIsNoviembre & ", "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.AccionesIsDiciembre = " & AccionesIsDiciembre & ", "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "AccionesPorStakeholdersPorPrograma.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE AccionesPorStakeholdersPorPrograma.AccionesPorStakeholdersPorProgramaId = " & AccionesPorStakeholdersPorProgramaId
        Try
            AccionesPorStakeholdersPorProgramaUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Plan de Acciones", AccionesPorStakeholdersPorProgramaId, "AccionesPorStakeholdersPorPrograma", "")
        Catch
            AccionesPorStakeholdersPorProgramaUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el Plan de Acciones", AccionesPorStakeholdersPorProgramaId, "AccionesPorStakeholdersPorPrograma", "")
        End Try
    End Function
    Public Function LeerProgramaMapaIdYAccionesId(ByVal AccionesPorStakeholdersPorProgramaId As Long, ByRef ProgramasMapaId As Long, ByRef AccionesId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select ProgramasMapaId, AccionesId "
        sSQL = sSQL & "FROM (AccionesPorStakeholdersPorPrograma) "
        sSQL = sSQL & "WHERE (AccionesPorStakeholdersPorPrograma.AccionesPorStakeholdersPorProgramaId = " & AccionesPorStakeholdersPorProgramaId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                ProgramasMapaId = CLng(dtr("ProgramasMapaId").ToString)
                AccionesId = CLng(dtr("AccionesId").ToString)
            End While
            LeerProgramaMapaIdYAccionesId = True
            dtr.Close()
        Catch
            LeerProgramaMapaIdYAccionesId = False
        End Try
    End Function
    Public Function LeerHHyUSDPorAccion(ByVal AccionesPorStakeholdersPorProgramaId As Long, ByRef AccionesHH As Double, ByRef AccionesUSD As Double) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AccionesHH, AccionesUSD "
        sSQL = sSQL & "FROM (AccionesPorStakeholdersPorPrograma) "
        sSQL = sSQL & "WHERE (AccionesPorStakeholdersPorPrograma.AccionesPorStakeholdersPorProgramaId = " & AccionesPorStakeholdersPorProgramaId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If Len(dtr("AccionesHH").ToString) = 0 Then
                    AccionesHH = 0
                Else
                    AccionesHH = CDbl(dtr("AccionesHH").ToString)
                End If
                If Len(dtr("AccionesUSD").ToString) = 0 Then
                    AccionesUSD = 0
                Else
                    AccionesUSD = CDbl(dtr("AccionesUSD").ToString)
                End If
            End While
            LeerHHyUSDPorAccion = True
            dtr.Close()
        Catch
            LeerHHyUSDPorAccion = False
        End Try
    End Function
    Public Function LeerAccionesPorStakeholdersPorProgramaId(ByVal ProgramasMapaId As Long, ByVal AccionesId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        LeerAccionesPorStakeholdersPorProgramaId = 0
        sSQL = "Select AccionesPorStakeholdersPorProgramaId As Id "
        sSQL = sSQL & "FROM (AccionesPorStakeholdersPorPrograma) "
        sSQL = sSQL & "WHERE (AccionesPorStakeholdersPorPrograma.ProgramasMapaId = " & ProgramasMapaId & " AND AccionesPorStakeholdersPorPrograma.AccionesId = " & AccionesId & " )"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerAccionesPorStakeholdersPorProgramaId = CLng(dtr("Id").ToString)
            End While
            dtr.Close()
        Catch
            LeerAccionesPorStakeholdersPorProgramaId = 0
        End Try
    End Function
    Public Function GetdstPuntajes(ByRef rptPuntajes As Repeater, ByVal ProgramasMapaId As Long, ByVal UserId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim Stakeholders As New Stakeholders
        Dim AccionesPorStakeholdersPorPrograma As New AccionesPorStakeholdersPorPrograma
        Dim AccionesPorStakeholdersPorProgramaId As Long
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim Valor As Long = 0
        Dim l As String = ""

        Dim dtblPuntajes As DataTable
        Dim dcolColumn As DataColumn
        Dim drowItem As DataRow
        Dim dvwPuntajes As DataView

        Dim HayAsociacion As Boolean = False

        'Crear el DataTable
        dtblPuntajes = New DataTable("Puntajes")

        'Crea Columnas
        dcolColumn = New DataColumn("Id", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Accion", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)
        dcolColumn = New DataColumn("Tipo", GetType(String))
        dtblPuntajes.Columns.Add(dcolColumn)


        sSQL = "SELECT Acciones.AccionesId As Id, Acciones.AccionesName AS Accion, Objetivos.ObjetivosName AS Tipo "
        sSQL = sSQL & "FROM ((Acciones INNER JOIN Metas ON Acciones.MetasCodigo = Metas.MetasCodigo) INNER JOIN Objetivos ON Metas.ObjetivosCodigo = Objetivos.ObjetivosCodigo) INNER JOIN Compromisos ON Objetivos.CompromisosCodigo = Compromisos.CompromisosCodigo "
        sSQL = sSQL & "WHERE(((Compromisos.CompromisosCodigo) = '1'))"

        i = 1
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Valor = CLng(dtr("Id").ToString)  ' Valor es AccionesId
                AccionesPorStakeholdersPorProgramaId = AccionesPorStakeholdersPorPrograma.LeerAccionesPorStakeholdersPorProgramaId(ProgramasMapaId, Valor)

                If AccionesPorStakeholdersPorProgramaId = 0 Then  'La accion no esta relacionada con el stakeholder
                    l = "<input id=""Checkbox" & Valor & """ type=""checkbox"" onclick=""RelationTableUpdate('" & "AccionesPorStakeholdersPorPrograma" & "', '" & "ProgramasMapa" & "', '" & "Acciones" & "', " & ProgramasMapaId & ", " & Valor & ", " & UserId & ")"" />"
                Else
                    l = "<input id=""Checkbox" & Valor & """ type=""checkbox"" checked=""checked"" onclick=""RelationTableUpdate('" & "AccionesPorStakeholdersPorPrograma" & "', '" & "ProgramasMapa" & "', '" & "Acciones" & "', " & ProgramasMapaId & ", " & Valor & ", " & UserId & ")"" />"
                End If
                drowItem = dtblPuntajes.NewRow
                drowItem("Id") = l
                drowItem("Accion") = dtr("Accion").ToString
                drowItem("Tipo") = dtr("Tipo").ToString
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

End Class
