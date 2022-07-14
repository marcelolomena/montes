'------------------------------------------------------------
' Código generado por ZRISMART SF el 23-02-2012 12:51:44
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class CarpetaJudicialLog
    Public Function LeerCarpetaJudicialLog(ByVal CarpetaJudicialLogId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialLogSecuencia As Long, ByRef CarpetaJudicialLogFecha As Date, ByRef UsuariosCodigo As String, ByRef AccionesCodigo As String, ByRef CarpetaJudicialDocsId As Long, ByRef CarpetaJudicialLogDescription As String, ByRef CurrentStateId As Long, ByRef NextStatedId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialCodigo, CarpetaJudicialLogSecuencia, CarpetaJudicialLogFecha, UsuariosCodigo, AccionesCodigo, CarpetaJudicialDocsId, CarpetaJudicialLogDescription, CurrentStateId, NextStatedId "
        sSQL = sSQL & "FROM (CarpetaJudicialLog) "
        sSQL = sSQL & "WHERE (CarpetaJudicialLog.CarpetaJudicialLogId = " & CarpetaJudicialLogId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CarpetaJudicialCodigo = CStr(dtr("CarpetaJudicialCodigo").ToString)
                If Len(dtr("CarpetaJudicialLogSecuencia").ToString) = 0 Then
                    CarpetaJudicialLogSecuencia = 0
                Else
                    CarpetaJudicialLogSecuencia = CLng(dtr("CarpetaJudicialLogSecuencia").ToString)
                End If
                If Len(dtr("CarpetaJudicialLogFecha").ToString) = 0 Then
                    CarpetaJudicialLogFecha = "01/01/01"
                Else
                    CarpetaJudicialLogFecha = CDate(dtr("CarpetaJudicialLogFecha").ToString)
                End If
                UsuariosCodigo = CStr(dtr("UsuariosCodigo").ToString)
                AccionesCodigo = CStr(dtr("AccionesCodigo").ToString)
                If Len(dtr("CarpetaJudicialDocsId").ToString) = 0 Then
                    CarpetaJudicialDocsId = 0
                Else
                    CarpetaJudicialDocsId = CLng(dtr("CarpetaJudicialDocsId").ToString)
                End If
                CarpetaJudicialLogDescription = CStr(dtr("CarpetaJudicialLogDescription").ToString)
                If Len(dtr("CurrentStateId").ToString) = 0 Then
                    CurrentStateId = 0
                Else
                    CurrentStateId = CLng(dtr("CurrentStateId").ToString)
                End If
                If Len(dtr("NextStatedId").ToString) = 0 Then
                    NextStatedId = 0
                Else
                    NextStatedId = CLng(dtr("NextStatedId").ToString)
                End If
            End While
            LeerCarpetaJudicialLog = True
            dtr.Close()
        Catch
            LeerCarpetaJudicialLog = False
        End Try
    End Function
    Public Function CarpetaJudicialLogUpdate(ByVal CarpetaJudicialLogId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialLogSecuencia As Long, ByRef CarpetaJudicialLogFecha As Date, ByRef UsuariosCodigo As String, ByRef AccionesCodigo As String, ByRef CarpetaJudicialDocsId As Long, ByRef CarpetaJudicialLogDescription As String, ByRef CurrentStateId As Long, ByRef NextStatedId As Long, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE CarpetaJudicialLog SET "
        strUpdate = strUpdate & "CarpetaJudicialLog.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialLog.CarpetaJudicialLogSecuencia = " & CarpetaJudicialLogSecuencia & ", "
        strUpdate = strUpdate & "CarpetaJudicialLog.CarpetaJudicialLogFecha = '" & AccionesABM.DateTransform(CarpetaJudicialLogFecha) & "', "
        strUpdate = strUpdate & "CarpetaJudicialLog.UsuariosCodigo = '" & UsuariosCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialLog.AccionesCodigo = '" & AccionesCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialLog.CarpetaJudicialDocsId = " & CarpetaJudicialDocsId & ", "
        strUpdate = strUpdate & "CarpetaJudicialLog.CarpetaJudicialLogDescription = '" & CarpetaJudicialLogDescription & "', "
        strUpdate = strUpdate & "CarpetaJudicialLog.CurrentStateId = " & CurrentStateId & ", "
        strUpdate = strUpdate & "CarpetaJudicialLog.NextStatedId = " & NextStatedId & ", "
        strUpdate = strUpdate & "CarpetaJudicialLog.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicialLog.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicialLog.CarpetaJudicialLogId = " & CarpetaJudicialLogId
        Try
            CarpetaJudicialLogUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & CarpetaJudicialCodigo, CarpetaJudicialLogId, "CarpetaJudicialLog", "")
        Catch
            CarpetaJudicialLogUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & CarpetaJudicialCodigo, CarpetaJudicialLogId, "CarpetaJudicialLog", "")
        End Try
    End Function
    Public Function CarpetaJudicialLogInsert(ByRef CarpetaJudicialLogId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialLogSecuencia As Long, ByRef CarpetaJudicialLogFecha As Date, ByRef UsuariosCodigo As String, ByRef AccionesCodigo As String, ByRef CarpetaJudicialDocsId As Long, ByRef CarpetaJudicialLogDescription As String, ByRef CurrentStateId As Long, ByRef NextStatedId As Long, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim CarpetaJudicialLog As New CarpetaJudicialLog
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = CarpetaJudicialCodigo
            DetailSecuencia = CarpetaJudicialLogSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("CarpetaJudicialLogId", "CarpetaJudicialCodigo", "CarpetaJudicialLogSecuencia", "CarpetaJudicialLog", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("CarpetaJudicialLogId", "CarpetaJudicialCodigo", "CarpetaJudicialLogSecuencia", "CarpetaJudicialLog", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            CarpetaJudicialLogInsert = CarpetaJudicialLog.CarpetaJudicialLogUpdate(DetailId, CStr(CarpetaJudicialCodigo), CLng(CarpetaJudicialLogSecuencia), CDate(CarpetaJudicialLogFecha), CStr(UsuariosCodigo), CStr(AccionesCodigo), CLng(CarpetaJudicialDocsId), CStr(CarpetaJudicialLogDescription), CLng(CurrentStateId), CLng(NextStatedId), UserId)
        Catch
            CarpetaJudicialLogInsert = 0
        End Try
    End Function
    Public Function CarpetaJudicialLogDelete(ByVal CarpetaJudicialLogId As Long, ByVal CarpetaJudicialCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (CarpetaJudicialLog) "
        strUpdate = strUpdate & "WHERE (CarpetaJudicialLog.CarpetaJudicialLogId = " & CarpetaJudicialLogId & ") "
        Try
            CarpetaJudicialLogDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & CarpetaJudicialCodigo, CarpetaJudicialLogId, "CarpetaJudicialLog", "")
        Catch
            CarpetaJudicialLogDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & CarpetaJudicialCodigo, CarpetaJudicialLogId, "CarpetaJudicialLog", "")
        End Try
    End Function
    Public Function ListarLog(ByVal CarpetaJudicialCodigo As String, Optional ByVal Clase As String = "invisible", Optional ByVal Formato As String = "CodigoHTML") As String
        Dim CodigoHTML As String = ""
        Dim CarpetaJudicialLog As New CarpetaJudicialLog
        Dim Direcciones(100) As String
        Dim NumeroDirecciones As Integer = CarpetaJudicialLog.LeerDatosLog(CarpetaJudicialCodigo, Direcciones, "invisible", Formato)
        Dim i As Integer
        ListarLog = ""

        If NumeroDirecciones > 0 Then
            If Formato = "CodigoHTML" Then
                CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td><h1>" & "Bit&aacute;cora completa del proceso judicial" & "</h1></td>"
                CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & "Tareas" & "')"" /></td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "</table>"
                CodigoHTML = CodigoHTML & "<div id=""subgrilla" & "Tareas" & """ class=""" & Clase & """>"
                CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
            Else
                CodigoHTML = CodigoHTML & "<table width=""660"" border=""1"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Verdana;font-size:8pt;border:1px solid #FFFFFF;"">"
            End If
            For i = 0 To NumeroDirecciones
                CodigoHTML = CodigoHTML & Direcciones(i)
            Next
            CodigoHTML = CodigoHTML & "</table>"
            If Formato = "CodigoHTML" Then
                CodigoHTML = CodigoHTML & "</div>"
            End If
        End If

        ListarLog = CodigoHTML
    End Function
    Public Function LeerDatosLog(ByVal CarpetaJudicialCodigo As String, ByRef Direcciones() As String, Optional ByVal Clase As String = "invisible", Optional ByVal Formato As String = "CodigoHTML") As Integer
        Dim CarpetaJudicialLog As New CarpetaJudicialLog
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim Actividades(100) As String
        Dim NumeroActividades As Integer = 0
        Dim Encabezado As String = ""

        sSQL = "SELECT Tareas.TareasId As Id, Tareas.TareasCodigo As Codigo, Tareas.TareasName As Accion, Usuarios.UsuariosName As Responsable, Tareas.EstadoTareasCodigo As Estado, Tareas.DateLastUpdate As FechaUlt, Tareas.TareasFechaTermino As FechaTer "
        sSQL = sSQL & "FROM Tareas, Usuarios "
        sSQL = sSQL & "WHERE Tareas.PGGCodigo = '" & CarpetaJudicialCodigo & "' AND Usuarios.UsuariosCodigo = Tareas.UsuariosCodigo "
        sSQL = sSQL & "ORDER BY Tareas.TareasId Desc"

        Dim CodigoHTML As String = ""

        LeerDatosLog = 0

        If Formato = "CodigoHTML" Then
            Direcciones(0) = "<tr><th width=""175"" align=""left"">Acci&oacute;n</th><th width=""175"" align=""left"">Responsable</th><th width=""150"" align=""left"">Estado</th><th width=""75"" align=""left"">Plazo</th><th width=""75"" align=""left"">T&eacute;rmino</th><th align=""left"">M&aacute;s</th></tr>"
        Else
            Encabezado = "<tr><th width=""175"" align=""left"">Acci&oacute;n</th><th width=""175"" align=""left"">Responsable</th><th width=""150"" align=""left"">Estado</th><th width=""75"" align=""left"">Plazo</th><th width=""75"" align=""left"">T&eacute;rmino</th></tr>"
        End If

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If Formato = "CodigoHTML" Then
                    Direcciones(i) = "<tr><td>" & dtr("Accion").ToString & "</td><td>" & dtr("Responsable").ToString & "</td><td>" & dtr("Estado").ToString & "</td><td>" & FormatDateTime(dtr("FechaTer").ToString, DateFormat.ShortDate) & "</td><td>" & FormatDateTime(dtr("FechaUlt").ToString, DateFormat.ShortDate) & "</td>"
                    Direcciones(i) = Direcciones(i) & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & "Tareas" & dtr("Id").ToString & "')"" /></td></tr>"
                    Direcciones(i) = Direcciones(i) & "<tr><td colspan=""6"">"
                    Direcciones(i) = Direcciones(i) & "<div id=""subgrilla" & "Tareas" & dtr("Id").ToString & """ class=""" & Clase & """>"
                    Direcciones(i) = Direcciones(i) & "<table class=""popup_tabla_de_datos_tareas"">"
                Else
                    Direcciones(i) = Encabezado & "<tr><td>" & dtr("Accion").ToString & "</td><td>" & dtr("Responsable").ToString & "</td><td>" & dtr("Estado").ToString & "</td><td>" & FormatDateTime(dtr("FechaTer").ToString, DateFormat.ShortDate) & "</td><td>" & FormatDateTime(dtr("FechaUlt").ToString, DateFormat.ShortDate) & "</td>"
                    Direcciones(i) = Direcciones(i) & "<tr><td colspan=""5"">"
                    Direcciones(i) = Direcciones(i) & "<table width=""660"" border=""1"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Verdana;font-size:8pt;border:1px solid #FFFFFF;"">"
                End If

                NumeroActividades = CarpetaJudicialLog.LeerDatosActividades(dtr("Codigo").ToString, Actividades)

                For j = 0 To NumeroActividades
                    Direcciones(i) = Direcciones(i) & Actividades(j)
                Next
                Direcciones(i) = Direcciones(i) & "</table>"
                If Formato = "CodigoHTML" Then
                    Direcciones(i) = Direcciones(i) & "</div></td></tr>"
                Else
                    Direcciones(i) = Direcciones(i) & "</td></tr>"
                End If
            End While
            dtr.Close()
        Catch
            LeerDatosLog = 0
        End Try


        LeerDatosLog = i

    End Function
    Public Function LeerDatosActividades(ByVal TareasCodigo As String, ByRef Direcciones() As String) As Integer

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0

        sSQL = "Select TareasLog.TareasLogId as Id, TareasLog.TareasLogTime As Fecha, Usuarios.UsuariosName As Responsable, TareasLog.TareasLogRol As Rol, TareasLog.TareasLogActividad As Actividad "
        sSQL = sSQL & "FROM TareasLog, Usuarios "
        sSQL = sSQL & "WHERE TareasLog.TareasCodigo = '" & TareasCodigo & "' AND Usuarios.UsuariosCodigo = TareasLog.UsuariosCodigo "
        sSQL = sSQL & "ORDER BY TareasLog.TareasLogId Desc"

        Dim CodigoHTML As String = ""

        LeerDatosActividades = 0

        Direcciones(0) = "<tr><th width=""100"" align=""left"">Fecha</th><th width=""200"" align=""left"">Responsable</th><th width=""150"" align=""left"">Rol</th><th width=""200"" align=""left"">Actividad</th></tr>"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                Direcciones(i) = "<tr><td>" & FormatDateTime(dtr("Fecha").ToString, DateFormat.GeneralDate) & "</td><td>" & dtr("Responsable").ToString & "</td><td>" & dtr("Rol").ToString & "</td><td>" & dtr("Actividad").ToString & "</td>"
            End While
            dtr.Close()
        Catch
            LeerDatosActividades = 0
        End Try


        LeerDatosActividades = i

    End Function


End Class
