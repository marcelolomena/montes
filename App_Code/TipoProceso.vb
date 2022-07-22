'------------------------------------------------------------
' Código generado por ZRISMART SF el 21-03-2012 21:37:20
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class TipoProceso
    Public Function LeerTipoProceso(ByVal TipoProcesoId As Long, ByRef TipoProcesoName As String, ByRef TipoProcesoDescription As String, ByRef TipoProcesoSecuencia As Long, ByRef ClaseProcesoName As String, ByRef AccionesCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TipoProcesoName, TipoProcesoDescription, TipoProcesoSecuencia, AccionesCodigo, ClaseProcesoName "
        sSQL = sSQL & "FROM TipoProceso "
        sSQL = sSQL & "WHERE TipoProceso.TipoProcesoId = " & TipoProcesoId & " "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TipoProcesoName = CStr(dtr("TipoProcesoName").ToString)
                TipoProcesoDescription = CStr(dtr("TipoProcesoDescription").ToString)
                If Len(dtr("TipoProcesoSecuencia").ToString) = 0 Then
                    TipoProcesoSecuencia = 0
                Else
                    TipoProcesoSecuencia = CLng(dtr("TipoProcesoSecuencia").ToString)
                End If
                ClaseProcesoName = CStr(dtr("ClaseProcesoName").ToString)
                AccionesCodigo = CStr(dtr("AccionesCodigo").ToString)
            End While
            LeerTipoProceso = True
            dtr.Close()
        Catch
            LeerTipoProceso = False
        End Try
    End Function
    Public Function LeerTipoProcesoByName(ByRef TipoProcesoId As Long, ByVal TipoProcesoName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TipoProcesoId "
        sSQL = sSQL & "FROM TipoProceso "
        sSQL = sSQL & "WHERE TipoProceso.TipoProcesoName = '" & TipoProcesoName & "' "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TipoProcesoId = CLng(dtr("TipoProcesoId").ToString)
            End While
            LeerTipoProcesoByName = True
            dtr.Close()
        Catch
            LeerTipoProcesoByName = False
        End Try
    End Function
    Public Function LeerTipoProcesoSecuenciaByName(ByVal TipoProcesoName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TipoProcesoSecuencia "
        sSQL = sSQL & "FROM TipoProceso "
        sSQL = sSQL & "WHERE TipoProceso.TipoProcesoName = '" & TipoProcesoName & "' "
        LeerTipoProcesoSecuenciaByName = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTipoProcesoSecuenciaByName = CLng(dtr("TipoProcesoSecuencia").ToString)
            End While
            dtr.Close()
        Catch
            LeerTipoProcesoSecuenciaByName = 0
        End Try
    End Function
    Public Function LeerTipoProcesoNameBySecuencia(ByVal TipoProcesoSecuencia As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TipoProcesoName "
        sSQL = sSQL & "FROM TipoProceso "
        sSQL = sSQL & "WHERE TipoProceso.TipoProcesoSecuencia = " & TipoProcesoSecuencia
        LeerTipoProcesoNameBySecuencia = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTipoProcesoNameBySecuencia = CStr(dtr("TipoProcesoName").ToString)
            End While
            dtr.Close()
        Catch
            LeerTipoProcesoNameBySecuencia = ""
        End Try
    End Function
    Public Function LeerTipoProcesoNameById(ByVal TipoProcesoId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TipoProcesoName "
        sSQL = sSQL & "FROM TipoProceso "
        sSQL = sSQL & "WHERE TipoProceso.TipoProcesoId = " & TipoProcesoId
        LeerTipoProcesoNameById = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTipoProcesoNameById = CStr(dtr("TipoProcesoName").ToString)
            End While
            dtr.Close()
        Catch
            LeerTipoProcesoNameById = ""
        End Try
    End Function

    Public Function LeerAccionInicial(ByVal TipoProcesoName As String, ByRef AccionesCodigo As String, ByRef AccionesId As Long, ByRef AccionesName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Acciones As New Acciones
        Dim t As Boolean

        sSQL = "Select AccionesCodigo "
        sSQL = sSQL & "FROM TipoProceso "
        sSQL = sSQL & "WHERE TipoProceso.TipoProcesoName = '" & TipoProcesoName & "' "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                AccionesCodigo = CStr(dtr("AccionesCodigo").ToString)
                t = Acciones.LeerAccionesIdAndName(AccionesCodigo, AccionesId, AccionesName)
            End While
            LeerAccionInicial = True
            dtr.Close()
        Catch
            LeerAccionInicial = False
        End Try
    End Function



    Public Function TipoProcesoUpdate(ByVal TipoProcesoId As Long, ByRef TipoProcesoName As String, ByRef TipoProcesoDescription As String, ByRef TipoProcesoSecuencia As Long, ByRef ClaseProcesoName As String, ByRef AccionesCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE TipoProceso SET "
        strUpdate = strUpdate & "TipoProceso.TipoProcesoName = '" & TipoProcesoName & "', "
        strUpdate = strUpdate & "TipoProceso.TipoProcesoDescription = '" & TipoProcesoDescription & "', "
        strUpdate = strUpdate & "TipoProceso.TipoProcesoSecuencia = " & TipoProcesoSecuencia & ", "
        strUpdate = strUpdate & "TipoProceso.ClaseProcesoName = '" & ClaseProcesoName & "', "
        strUpdate = strUpdate & "TipoProceso.AccionesCodigo = '" & AccionesCodigo & "', "
        strUpdate = strUpdate & "TipoProceso.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "TipoProceso.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE TipoProceso.TipoProcesoId = " & TipoProcesoId
        Try
            TipoProcesoUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & TipoProcesoName, TipoProcesoId, "TipoProceso", "")
        Catch
            TipoProcesoUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TipoProcesoName, TipoProcesoId, "TipoProceso", "")
        End Try
    End Function
    Public Function TipoProcesoInsert(ByRef TipoProcesoId As Long, ByRef TipoProcesoName As String, ByRef TipoProcesoDescription As String, ByRef TipoProcesoSecuencia As Long, ByRef ClaseProcesoName As String, ByRef AccionesCodigo As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim TipoProceso As New TipoProceso
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = TipoProcesoName
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("TipoProcesoId", "TipoProcesoName", "TipoProceso", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("TipoProcesoId", "TipoProcesoName", "TipoProceso", MasterName, CLng(UserId), MasterId)
                TipoProcesoId = MasterId
            End If
            TipoProcesoInsert = TipoProceso.TipoProcesoUpdate(MasterId, CStr(TipoProcesoName), CStr(TipoProcesoDescription), CLng(TipoProcesoSecuencia), CStr(ClaseProcesoName), CStr(AccionesCodigo), UserId)
            TipoProcesoInsert = MasterId
        Catch
            TipoProcesoInsert = 0
        End Try
    End Function
    Public Function LeerTotalTipoProcesoPorCarpeta(ByVal TipoProcesoName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM TipoProceso INNER JOIN CarpetaJudicial ON TipoProceso.TipoProcesoName = CarpetaJudicial.TipoProcesoName "
        sSQL = sSQL & "WHERE (((TipoProceso.TipoProcesoName)='" & TipoProcesoName & "'))"
        LeerTotalTipoProcesoPorCarpeta = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalTipoProcesoPorCarpeta = LeerTotalTipoProcesoPorCarpeta + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalTipoProcesoPorCarpeta = 0
        End Try

        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM TipoProceso INNER JOIN Acciones ON TipoProceso.TipoProcesoSecuencia = Acciones.TipoProcesoSecuencia "
        sSQL = sSQL & "WHERE (((TipoProceso.TipoProcesoName)='" & TipoProcesoName & "'))"
        'LeerTotalTipoProcesoPorCarpeta = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalTipoProcesoPorCarpeta = LeerTotalTipoProcesoPorCarpeta + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalTipoProcesoPorCarpeta = 0
        End Try



    End Function
    Public Function TipoProcesoDelete(ByVal TipoProcesoId As Long, ByVal TipoProcesoName As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim TipoProceso As New TipoProceso


        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Mensaje = ""
        Total = TipoProceso.LeerTotalTipoProcesoPorCarpeta(TipoProcesoName)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " carpetas judiciales asociados al Tipo " & TipoProcesoName & vbCrLf
            Mensaje = Mensaje & "Este proceso no puede ser eliminado."
            TipoProcesoDelete = False
        Else
            Try
                ' Borra registro de la tabla de Roles
                '-------------------------------------
                strUpdate = "DELETE FROM TipoProceso WHERE TipoProcesoId = " & TipoProcesoId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Tipo: " & TipoProcesoName, TipoProcesoId, "TipoProceso", "")
                TipoProcesoDelete = True
                Mensaje = ""
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Tipo: " & TipoProcesoName, TipoProcesoId, "TipoProceso", "")
                TipoProcesoDelete = False
            End Try
        End If
    End Function
    Public Function ListarTiposDeProcesos(Optional ByVal Clase As String = "invisible", Optional ByVal IsModoMantencion As Boolean = False) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim Acciones As New Acciones

        strUpdate = "Select TipoProcesoId, TipoProcesoName, TipoProcesoDescription, TipoProcesoSecuencia, AccionesCodigo "
        strUpdate = strUpdate & "FROM TipoProceso "
        strUpdate = strUpdate & "WHERE IsActivo = 'SI' ORDER BY TipoProcesoSecuencia "
        'strUpdate = strUpdate & "ORDER BY TipoProcesoSecuencia"

        ListarTiposDeProcesos = ""
        'l = "<img src=""img/editar.png"" alt=""Editar la identificación y numeración del proceso judicial"" hspace=""5"" border=""0"" align=""left"" title=""Editar la identificación y numeración del proceso judicial"" onclick=""verModalTipoProceso('FichaTipoProceso.aspx?Id=" & dtr("TipoProcesoId").ToString & "&PaginaWebName=Ficha de TipoProceso')"" />"


        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                CodigoHTML = CodigoHTML & "<tr>"
                If IsModoMantencion = True Then
                    CodigoHTML = CodigoHTML & "<td width=""30""><img src=""img/editar.png"" alt=""Editar un tipo de proceso judicial"" hspace=""5"" border=""0"" align=""left"" title=""Editar un tipo de proceso judicial"" onclick=""verModalTipoProceso('FichaTipoProceso.aspx?Id=" & dtr("TipoProcesoId").ToString & "&PaginaWebName=Ficha de TipoProceso')"" /></td><td align=""left"" width=""470""><h1>" & dtr("TipoProcesoName").ToString & "</h1></td>"
                Else
                    CodigoHTML = CodigoHTML & "<td width=""500""><h1>" & dtr("TipoProcesoName").ToString & "</h1></td>"
                End If
                CodigoHTML = CodigoHTML & "<td align=""right"" width=""160""><a href=""ImprimirPerfilJuicioEnWord.aspx?Id=" & dtr("TipoProcesoSecuencia").ToString & """ target=""_blank"" >[Ver en Word]  </a><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrillaProceso" & dtr("TipoProcesoSecuencia").ToString & "')"" /></td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "</table>"
                CodigoHTML = CodigoHTML & "<div id=""subgrillaProceso" & dtr("TipoProcesoSecuencia").ToString & """ class=""" & Clase & """>"
                CodigoHTML = CodigoHTML & Acciones.ListarAccionesPorProceso(CLng(dtr("TipoProcesoSecuencia").ToString))
                CodigoHTML = CodigoHTML & "</div>"
            End While
            dtr.Close()
        Catch

        End Try

        If IsModoMantencion = True Then
            CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
            CodigoHTML = CodigoHTML & "<tr>"
            CodigoHTML = CodigoHTML & "<td><td width=""26""><img src=""img/editar.png"" alt=""Crear un nuevo tipo de proceso judicial"" hspace=""5"" border=""0"" align=""left"" title=""Crear un nuevo tipo de proceso judicial"" onclick=""verModalTipoProceso('FichaTipoProceso.aspx?Id=0&PaginaWebName=Ficha de TipoProceso')"" /></td><td width=""634""><h1>" & "Describir un nuevo tipo de proceso judicial" & "</h1></td>"
            CodigoHTML = CodigoHTML & "</tr>"
            CodigoHTML = CodigoHTML & "</table>"
        End If

        ListarTiposDeProcesos = CodigoHTML
    End Function

    Public Function ListarPanelControlPorTiposDeProcesos() As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim Acciones As New Acciones
        Dim TipoProceso As New TipoProceso
        Dim CarpetaJudicial As New CarpetaJudicial

        strUpdate = "Select TipoProcesoName, TipoProcesoDescription, TipoProcesoSecuencia, AccionesCodigo "
        strUpdate = strUpdate & "FROM TipoProceso "
        'strUpdate = strUpdate & "WHERE TipoProcesoName = 'Juicio Ejecutivo' "
        strUpdate = strUpdate & "WHERE TipoProcesoName = 'Juicio Ejecutivo Hernan' "
        strUpdate = strUpdate & "ORDER BY TipoProcesoSecuencia"

        ListarPanelControlPorTiposDeProcesos = ""


        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<table width = ""1000"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                CodigoHTML = CodigoHTML & "<tr><td><h1>" & "Juicios Vigentes" & "</h1></td></tr>"
                CodigoHTML = CodigoHTML & "</table>"
                CodigoHTML = CodigoHTML & "<table width = ""1000"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""table_colors"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<th colspan=""2"" width=""200"">Deudor</th>"
                CodigoHTML = CodigoHTML & TipoProceso.EncabezadoEtapas(dtr("TipoProcesoName").ToString)
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & CarpetaJudicial.ProcesosVigentesPorTipo(dtr("TipoProcesoName").ToString)
                CodigoHTML = CodigoHTML & "</table>"
            End While
            dtr.Close()
        Catch

        End Try

        ListarPanelControlPorTiposDeProcesos = CodigoHTML
    End Function

    Public Function EncabezadoEtapas(ByVal TipoProcesoName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim CodigoHTML As String = ""

        sSQL = "SELECT EtapasName, EtapasDescription "
        sSQL = sSQL & "FROM Etapas "
        sSQL = sSQL & "WHERE Etapas.TipoProcesoName='" & TipoProcesoName & "'"
        EncabezadoEtapas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<th width=""100"">" & dtr("EtapasName").ToString & "</th>"
            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try
        EncabezadoEtapas = CodigoHTML
    End Function

    Public Function ListarInformeEstadoDiarioPorTiposDeProcesos(Optional ByVal Clase As String = "CodigoHTML") As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim Acciones As New Acciones
        Dim TipoProceso As New TipoProceso
        Dim CarpetaJudicial As New CarpetaJudicial

        strUpdate = "Select TipoProcesoName, TipoProcesoDescription, TipoProcesoSecuencia, AccionesCodigo "
        strUpdate = strUpdate & "FROM TipoProceso "
        strUpdate = strUpdate & "WHERE TipoProcesoName = 'Juicio Ejecutivo Hernan' "
        strUpdate = strUpdate & "ORDER BY TipoProcesoSecuencia"

        ListarInformeEstadoDiarioPorTiposDeProcesos = ""


        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<table width = ""1000"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                CodigoHTML = CodigoHTML & "<tr><td><h1>" & "Procesos vigentes al " & FormatDateTime(Now, DateFormat.ShortDate) & "</h1></td></tr>"
                CodigoHTML = CodigoHTML & "</table>"
                CodigoHTML = CodigoHTML & "<table width = ""1000"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""table_colors"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<th width=""150"">JUZGADO</th><th width=""100"">ROL</th><th width=""150"">DEMANDADO</th><th width=""100"">RUT</th><th width=""200"">ESTADO</th><th width=""100"">FECHA</th><th width=""180"">ULTIMO COMENTARIO</th><th width=""20""></th>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & CarpetaJudicial.InformeEstadoDiario(dtr("TipoProcesoName").ToString)
                CodigoHTML = CodigoHTML & "</table>"
            End While
            dtr.Close()
        Catch

        End Try

        ListarInformeEstadoDiarioPorTiposDeProcesos = CodigoHTML
    End Function

    Public Function ListarInformeMovimientoDiarioPorTiposDeProcesos(ByRef Fecha As Date) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim Acciones As New Acciones
        Dim TipoProceso As New TipoProceso
        Dim CarpetaJudicial As New CarpetaJudicial

        strUpdate = "Select TipoProcesoName, TipoProcesoDescription, TipoProcesoSecuencia, AccionesCodigo "
        strUpdate = strUpdate & "FROM TipoProceso "
        strUpdate = strUpdate & "WHERE TipoProcesoName = 'Juicio Ejecutivo Hernan' "
        strUpdate = strUpdate & "ORDER BY TipoProcesoSecuencia"

        ListarInformeMovimientoDiarioPorTiposDeProcesos = ""


        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<table width = ""1000"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                CodigoHTML = CodigoHTML & "<tr><td><h1>" & "Actividades del d&iacute;a " & FormatDateTime(Fecha, DateFormat.ShortDate) & "</h1></td></tr>"
                CodigoHTML = CodigoHTML & "</table>"
                CodigoHTML = CodigoHTML & "<table width = ""1000"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""table_colors"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<th width=""150"">JUZGADO</th><th width=""100"">ROL</th><th width=""150"">DEMANDADO</th><th width=""50"">RUT</th><th width=""200"">ESTADO</th><th width=""330"">ACTIVIDADES DIARIAS</th><th width=""20""></th>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & CarpetaJudicial.InformeMovimientoDiario(dtr("TipoProcesoName").ToString, Fecha)
                CodigoHTML = CodigoHTML & "</table>"
            End While
            dtr.Close()
        Catch

        End Try

        ListarInformeMovimientoDiarioPorTiposDeProcesos = CodigoHTML
    End Function

    Public Function ListarTipoProcesosVigentes() As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Dim i As Integer = 0
        Dim Acciones As New Acciones

        strUpdate = "SELECT TipoProceso.TipoProcesoId As Id, TipoProceso.TipoProcesoName As Name, TipoProceso.TipoProcesoDescription As Description, TipoProceso.TipoProcesoSecuencia As Secuencia, TipoProceso.AccionesCodigo As Codigo "
        strUpdate = strUpdate & "FROM TipoProceso "
        strUpdate = strUpdate & "ORDER BY TipoProceso.TipoProcesoSecuencia"

        ListarTipoProcesosVigentes = ""

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<th width=""100"" align=""left"">Tipo</th>"
                    CodigoHTML = CodigoHTML & "<th width=""250"">Descripci&oacute;n</th>"
                    CodigoHTML = CodigoHTML & "<th width=""250"">Acci&oacute;n Inicial</th>"
                    CodigoHTML = CodigoHTML & "<th width=""25"">Editar</th>"
                    CodigoHTML = CodigoHTML & "</tr>"
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td width=""100"" align=""left"">" & dtr("Name").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "<td width=""250"">" & dtr("Description").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "<td width=""250"">" & Acciones.LeerAccionesDescriptionByName(dtr("Codigo").ToString) & "</td>"
                    CodigoHTML = CodigoHTML & "<td width=""25"">" & "<img src=""img/editar.png"" alt=""Editar un tipo de proceso judicial"" hspace=""5"" border=""0"" align=""left"" title=""Editar un tipo de proceso judicial"" onclick=""editbutton(" & dtr("Id").ToString & ");"" />"
                    CodigoHTML = CodigoHTML & "</tr>"
                Else
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td width=""100"" align=""left"">" & dtr("Name").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "<td width=""250"">" & dtr("Description").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "<td width=""250"">" & Acciones.LeerAccionesDescriptionByName(dtr("Codigo").ToString) & "</td>"
                    CodigoHTML = CodigoHTML & "<td width=""25"">" & "<img src=""img/editar.png"" alt=""Editar un tipo de proceso judicial"" hspace=""5"" border=""0"" align=""left"" title=""Editar un tipo de proceso judicial"" onclick=""editbutton(" & dtr("Id").ToString & ");"" />"
                    CodigoHTML = CodigoHTML & "</tr>"
                End If
            End While
            dtr.Close()
        Catch

        End Try
        If CodigoHTML <> "" Then
            CodigoHTML = CodigoHTML & "</table>"
        End If
        ListarTipoProcesosVigentes = CodigoHTML
    End Function
    Public Function CalcularNextTipoProcesoSecuencia() As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Max(TipoProceso.TipoProcesoSecuencia) as Maximo "
        sSQL = sSQL & "FROM TipoProceso"

        CalcularNextTipoProcesoSecuencia = 1

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                CalcularNextTipoProcesoSecuencia = CLng(dtr("Maximo").ToString) + 1
            End While
            dtr.Close()
        Catch
            CalcularNextTipoProcesoSecuencia = 1
        End Try
    End Function
    Public Function ListarEtapasPorTipoProceso(ByVal TipoProcesoId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim TipoProceso As New TipoProceso
        Dim TipoProcesoName As String = TipoProceso.LeerTipoProcesoNameById(TipoProcesoId)
        Dim i As Integer = 0
        Dim Acciones As New Acciones

        strUpdate = "SELECT Etapas.EtapasId As Id, Etapas.EtapasName As Name, Etapas.EtapasDescription As Description, Etapas.EtapasPostCondiciones As PostCondicion "
        strUpdate = strUpdate & "FROM Etapas "
        strUpdate = strUpdate & "WHERE Etapas.TipoProcesoId = " & TipoProcesoId & " "
        strUpdate = strUpdate & "ORDER BY Etapas.EtapasSecuencia"

        ListarEtapasPorTipoProceso = ""

        CodigoHTML = "<h3>Lista de Etapas del " & TipoProcesoName & "</h3>"
        Dim linkAgregar As String = "<input id=""AgregarUnaEtapa"" type=""button"" value=""Agregar una etapa"" class=""boxceleste"" title=""De un click para agregar una nueva etapa al proceso"" onclick=""verModalEtapasTipoProceso('FichaEtapas.aspx?EtapasId=0&TipoProcesoId=" & TipoProcesoId & "&PaginaWebName=Ficha de Etapas')"" />"
        CodigoHTML = CodigoHTML & "<p>" & linkAgregar & "</p>"
        CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
        CodigoHTML = CodigoHTML & "<tr>"
        CodigoHTML = CodigoHTML & "<th width=""200"" align=""left"">Etapa</th>"
        CodigoHTML = CodigoHTML & "<th width=""425"">Descripci&oacute;n</th>"
        CodigoHTML = CodigoHTML & "<th width=""25"">Editar</th>"
        CodigoHTML = CodigoHTML & "</tr>"

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td width=""200"" align=""left"">" & dtr("Name").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td width=""425"">" & dtr("Description").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td width=""25""><img src=""img/editar.png"" alt=""Editar una etapa del proceso judicial"" hspace=""5"" border=""0"" align=""left"" title=""Editar una etapa del proceso judicial"" onclick=""verModalEtapasTipoProceso('FichaEtapas.aspx?EtapasId=" & dtr("Id").ToString & "&TipoProcesoId=" & TipoProcesoId & "&PaginaWebName=Ficha de Etapas')"" /></td>"
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch

        End Try
        CodigoHTML = CodigoHTML & "</table>"
        ListarEtapasPorTipoProceso = CodigoHTML
    End Function
    Public Function LeerIdProcesoAnterior(ByVal TipoProcesoId As String, ByVal TipoProcesoSecuencia As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim Id As Long = 0

        sSQL = "Select TipoProcesoId as Id "
        sSQL = sSQL & "FROM TipoProceso "
        sSQL = sSQL & "WHERE TipoProceso.TipoProcesoSecuencia < " & TipoProcesoSecuencia & " "
        sSQL = sSQL & "ORDER BY TipoProcesoSecuencia Desc"
        LeerIdProcesoAnterior = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    Id = CLng(dtr("Id").ToString)
                End If
            End While
            dtr.Close()
        Catch
            Id = 0
        End Try
        If Id = 0 Then
            LeerIdProcesoAnterior = TipoProcesoId
        Else
            LeerIdProcesoAnterior = Id
        End If


    End Function
    Public Function LeerIdProcesoSiguiente(ByVal TipoProcesoId As String, ByVal TipoProcesoSecuencia As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim Id As Long = 0

        sSQL = "Select TipoProcesoId as Id "
        sSQL = sSQL & "FROM TipoProceso "
        sSQL = sSQL & "WHERE TipoProceso.TipoProcesoSecuencia > " & TipoProcesoSecuencia & " "
        sSQL = sSQL & "ORDER BY TipoProcesoSecuencia Asc"
        LeerIdProcesoSiguiente = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    Id = CLng(dtr("Id").ToString)
                End If
            End While
            dtr.Close()
        Catch
            Id = 0
        End Try
        If Id = 0 Then
            LeerIdProcesoSiguiente = TipoProcesoId
        Else
            LeerIdProcesoSiguiente = Id
        End If
    End Function

End Class
