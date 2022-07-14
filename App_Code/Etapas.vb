'------------------------------------------------------------
' Código generado por ZRISMART SF el 21-03-2012 21:37:20
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class Etapas
    Public Function LeerEtapas(ByVal EtapasId As Long, ByRef EtapasName As String, ByRef EtapasDescription As String, ByRef EtapasSecuencia As Long, ByRef EtapasPreCondiciones As String, ByRef EtapasPostCondiciones As String, ByRef TipoProcesoId As Long, ByRef TipoProcesoName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EtapasName, EtapasDescription, EtapasSecuencia, EtapasPreCondiciones, EtapasPostCondiciones, TipoProcesoId, TipoProcesoName "
        sSQL = sSQL & "FROM Etapas "
        sSQL = sSQL & "WHERE Etapas.EtapasId = " & EtapasId & " "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                EtapasName = CStr(dtr("EtapasName").ToString)
                EtapasDescription = CStr(dtr("EtapasDescription").ToString)
                If Len(dtr("EtapasSecuencia").ToString) = 0 Then
                    EtapasSecuencia = 0
                Else
                    EtapasSecuencia = CLng(dtr("EtapasSecuencia").ToString)
                End If
                EtapasPreCondiciones = CStr(dtr("EtapasPreCondiciones").ToString)
                EtapasPostCondiciones = CStr(dtr("EtapasPostCondiciones").ToString)
                If Len(dtr("TipoProcesoId").ToString) = 0 Then
                    TipoProcesoId = 0
                Else
                    TipoProcesoId = CLng(dtr("TipoProcesoId").ToString)
                End If
                TipoProcesoName = CStr(dtr("TipoProcesoName").ToString)
            End While
            LeerEtapas = True
            dtr.Close()
        Catch
            LeerEtapas = False
        End Try
    End Function
    Public Function LeerEtapasIdByName(ByVal EtapasName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EtapasId "
        sSQL = sSQL & "FROM Etapas "
        sSQL = sSQL & "WHERE Etapas.EtapasName = '" & EtapasName & "' "
        LeerEtapasIdByName = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerEtapasIdByName = CLng(dtr("EtapasId").ToString)
            End While
            dtr.Close()
        Catch
            LeerEtapasIdByName = 0
        End Try
    End Function
    Public Function LeerEtapasSecuenciaByName(ByVal EtapasName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EtapasSecuencia "
        sSQL = sSQL & "FROM Etapas "
        sSQL = sSQL & "WHERE Etapas.EtapasName = '" & EtapasName & "' "
        LeerEtapasSecuenciaByName = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerEtapasSecuenciaByName = CLng(dtr("EtapasSecuencia").ToString)
            End While
            dtr.Close()
        Catch
            LeerEtapasSecuenciaByName = 0
        End Try
    End Function
    Public Function LeerEtapasNameBySecuencia(ByVal EtapasSecuencia As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EtapasName "
        sSQL = sSQL & "FROM Etapas "
        sSQL = sSQL & "WHERE Etapas.EtapasSecuencia = " & EtapasSecuencia
        LeerEtapasNameBySecuencia = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerEtapasNameBySecuencia = CStr(dtr("EtapasName").ToString)
            End While
            dtr.Close()
        Catch
            LeerEtapasNameBySecuencia = ""
        End Try
    End Function
    Public Function LeerEtapasNameById(ByVal EtapasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EtapasName "
        sSQL = sSQL & "FROM Etapas "
        sSQL = sSQL & "WHERE Etapas.EtapasId = " & EtapasId
        LeerEtapasNameById = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerEtapasNameById = CStr(dtr("EtapasName").ToString)
            End While
            dtr.Close()
        Catch
            LeerEtapasNameById = ""
        End Try
    End Function
    Public Function LeerTipoProcesoIdByEtapasId(ByVal EtapasId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Acciones As New Acciones

        sSQL = "Select TipoProcesoId "
        sSQL = sSQL & "FROM Etapas "
        sSQL = sSQL & "WHERE Etapas.EtapasId = " & EtapasId & " "
        LeerTipoProcesoIdByEtapasId = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTipoProcesoIdByEtapasId = CLng(dtr("TipoProcesoId").ToString)
            End While
            dtr.Close()
        Catch
            LeerTipoProcesoIdByEtapasId = 0
        End Try
    End Function
    Public Function EtapasUpdate(ByVal EtapasId As Long, ByVal EtapasName As String, ByVal EtapasDescription As String, ByVal EtapasSecuencia As Long, ByVal EtapasPreCondiciones As String, ByVal EtapasPostCondiciones As String, ByVal TipoProcesoId As Long, ByVal TipoProcesoName As String, ByVal UserId As Long) As Integer 'ByVal TipoProcesoId As Long, ByVal TipoProcesoName As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Etapas SET "
        strUpdate = strUpdate & "Etapas.EtapasName = '" & EtapasName & "', "
        strUpdate = strUpdate & "Etapas.EtapasDescription = '" & EtapasDescription & "', "
        strUpdate = strUpdate & "Etapas.EtapasSecuencia = " & EtapasSecuencia & ", "
        strUpdate = strUpdate & "Etapas.EtapasPreCondiciones = '" & EtapasPreCondiciones & "', "
        strUpdate = strUpdate & "Etapas.EtapasPostCondiciones = '" & EtapasPostCondiciones & "', "
        strUpdate = strUpdate & "Etapas.TipoProcesoId = " & TipoProcesoId & ", "
        strUpdate = strUpdate & "Etapas.TipoProcesoName = '" & TipoProcesoName & "', "
        strUpdate = strUpdate & "Etapas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Etapas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Etapas.EtapasId = " & EtapasId
        Try
            EtapasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & EtapasName, EtapasId, "Etapas", "")
        Catch
            EtapasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & EtapasName, EtapasId, "Etapas", "")
        End Try
    End Function
    Public Function EtapasInsert(ByRef EtapasId As Long, ByVal EtapasName As String, ByVal EtapasDescription As String, ByVal EtapasSecuencia As Long, ByVal EtapasPreCondiciones As String, ByVal EtapasPostCondiciones As String, ByVal TipoProcesoId As Long, ByVal TipoProcesoName As String, ByVal UserId As Long) As Integer 'ByVal TipoProcesoId As Long, ByVal TipoProcesoName As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Etapas As New Etapas
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = EtapasName
            MasterId = 0
            't = Lecturas.LeerMasterIdByMasterName("EtapasId", "EtapasName", "Etapas", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("EtapasId", "EtapasName", "Etapas", MasterName, CLng(UserId), MasterId)
                EtapasId = MasterId
            End If
            EtapasInsert = Etapas.EtapasUpdate(MasterId, CStr(EtapasName), CStr(EtapasDescription), CLng(EtapasSecuencia), EtapasPreCondiciones, EtapasPostCondiciones, TipoProcesoId, TipoProcesoName, UserId) ',
            EtapasInsert = MasterId
        Catch
            EtapasInsert = 0
        End Try
    End Function
    Public Function LeerTotalEtapasPorAccion(ByVal EtapasName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Acciones "
        sSQL = sSQL & "WHERE Acciones.EtapasName='" & EtapasName & "'"
        LeerTotalEtapasPorAccion = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalEtapasPorAccion = LeerTotalEtapasPorAccion + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalEtapasPorAccion = 0
        End Try

    End Function
    Public Function EtapasDelete(ByVal EtapasId As Long, ByVal EtapasName As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Etapas As New Etapas


        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Mensaje = ""
        Total = Etapas.LeerTotalEtapasPorAccion(EtapasName)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " acciones asociadas a la etapa " & EtapasName & vbCrLf
            Mensaje = Mensaje & ". Esta etapa no puede ser eliminada."
            EtapasDelete = False
        Else
            Try
                ' Borra registro de la tabla de Etapas
                '-------------------------------------
                strUpdate = "DELETE FROM Etapas WHERE EtapasId = " & EtapasId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina la etapa: " & EtapasName, EtapasId, "Etapas", "")
                EtapasDelete = True
                Mensaje = ""
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la etapa: " & EtapasName, EtapasId, "Etapas", "")
                EtapasDelete = False
            End Try
        End If
    End Function

    Public Function ListarEtapasVigentes(Optional ByVal TipoProcesoId As Long = 2) As String

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
        Dim TipoProceso As New TipoProceso
        Dim TipoProcesoName As String = TipoProceso.LeerTipoProcesoNameById(TipoProcesoId)

        strUpdate = "SELECT Etapas.EtapasId As Id, Etapas.EtapasName As Name, Etapas.EtapasDescription As Description, Etapas.EtapasSecuencia As Secuencia "
        strUpdate = strUpdate & "FROM Etapas "
        strUpdate = strUpdate & "WHERE TipoProcesoId = " & TipoProcesoId & " "
        strUpdate = strUpdate & "ORDER BY Etapas.EtapasSecuencia"

        ListarEtapasVigentes = ""

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<th width=""200"" align=""left"">Tipo</th>"
                    CodigoHTML = CodigoHTML & "<th width=""400"">Descripci&oacute;n</th>"
                    CodigoHTML = CodigoHTML & "<th width=""25"">Editar</th>"
                    CodigoHTML = CodigoHTML & "</tr>"
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td width=""200"" align=""left"">" & dtr("Name").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "<td width=""400"">" & dtr("Description").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "<td width=""25"">" & "<img src=""img/editar.png"" alt=""Editar una etapa del proceso judicial"" hspace=""5"" border=""0"" align=""left"" title=""Editar una etapa del proceso judicial"" onclick=""editbutton(" & dtr("Id").ToString & ");"" />"
                    CodigoHTML = CodigoHTML & "</tr>"
                Else
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td width=""200"" align=""left"">" & dtr("Name").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "<td width=""400"">" & dtr("Description").ToString & "</td>"
                    CodigoHTML = CodigoHTML & "<td width=""25"">" & "<img src=""img/editar.png"" alt=""Editar una etapa del proceso judicial"" hspace=""5"" border=""0"" align=""left"" title=""Editar una etapa del proceso judicial"" onclick=""editbutton(" & dtr("Id").ToString & ");"" />"
                    CodigoHTML = CodigoHTML & "</tr>"
                End If
            End While
            dtr.Close()
        Catch

        End Try
        If CodigoHTML <> "" Then
            CodigoHTML = CodigoHTML & "</table>"
        End If
        ListarEtapasVigentes = CodigoHTML
    End Function
    Public Function CalcularNextEtapasSecuencia(Optional ByVal TipoProcesoId As Long = 2) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Max(Etapas.EtapasSecuencia) as Maximo "
        sSQL = sSQL & "FROM Etapas "
        sSQL = sSQL & "WHERE TipoProcesoId = " & TipoProcesoId

        CalcularNextEtapasSecuencia = 1

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                CalcularNextEtapasSecuencia = CLng(dtr("Maximo").ToString) + 1
            End While
            dtr.Close()
        Catch
            CalcularNextEtapasSecuencia = 1
        End Try
    End Function
    Public Function ListarAccionesPorEtapas(ByVal EtapasId As Long, Optional ByVal UsuariosId As Long = 2, Optional ByVal TipoProcesoId As Long = 2) As String

        Dim AccesoEA As New AccesoEA
        Dim Etapas As New Etapas
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim LinkPerfilUsuario As String = ""
        Dim NombreEtapa As String = ""
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Dim i As Integer = 0
        Dim Acciones As New Acciones
        Dim TituloMisAcciones As String = Etapas.TituloAccionesPorEtapas(EtapasId)
        'Dim TipoProcesoId As Long = Etapas.LeerTipoProcesoIdByEtapasId(EtapasId)

        'TipoProcesoId = 2
        strUpdate = "SELECT Acciones.AccionesId As Id, Acciones.AccionesCodigo as Codigo, Acciones.AccionesName As Name, Acciones.AccionesDescription As Description, Acciones.RolName As Rol, Acciones.TipoProcesoSecuencia As TipoProcesoId "
        strUpdate = strUpdate & "FROM Acciones "
        strUpdate = strUpdate & "WHERE Acciones.EtapasId = " & EtapasId & " "
        strUpdate = strUpdate & "ORDER BY Acciones.AccionesSecuencia"

        ListarAccionesPorEtapas = ""

        CodigoHTML = ""
        Dim linkAgregar As String = "<input id=""AgregarUnaAccion"" type=""button"" value=""Agregar una acci&oacute;n"" class=""boxceleste"" title=""De un click para agregar una nueva acci&oacute;n a la etapa"" onclick=""verModalAccionEtapas('FichaAcciones.aspx?AccionesId=0&EtapasId=" & EtapasId & "&TipoProcesoId=" & TipoProcesoId & "&PaginaWebName=Ficha de Acciones', " & UsuariosId & ", " & TipoProcesoId & ")"" />"
        CodigoHTML = CodigoHTML & "<p>" & linkAgregar & "</p>"
        CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
        CodigoHTML = CodigoHTML & "<caption>" & TituloMisAcciones & "</caption>"
        CodigoHTML = CodigoHTML & "<tr>"
        CodigoHTML = CodigoHTML & "<th width=""200"" align=""left"">Acci&oacute;n</th>"
        CodigoHTML = CodigoHTML & "<th width=""50"" align=""left"">Rol</th>"
        CodigoHTML = CodigoHTML & "<th width=""350"">Descripci&oacute;n</th>"
        CodigoHTML = CodigoHTML & "<th width=""25"">Editar</th>"
        CodigoHTML = CodigoHTML & "</tr>"

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td width=""200"" align=""left"">" & dtr("Name").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td width=""50"">" & dtr("Rol").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td width=""350"">" & dtr("Description").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td width=""25""><img src=""img/editar.png"" alt=""Editar una acci&oacute;n de la etapa"" hspace=""5"" border=""0"" align=""left"" title=""Editar una acción de la etapa"" onclick=""verModalAccionEtapas('FichaAcciones.aspx?AccionesId=" & dtr("Id").ToString & "&EtapasId=" & EtapasId & "&TipoProcesoId=" & TipoProcesoId & "&PaginaWebName=Ficha de Acciones', " & UsuariosId & ", " & TipoProcesoId & ")"" /></td>"
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtr.Close()
        Catch

        End Try
        CodigoHTML = CodigoHTML & "</table>"
        ListarAccionesPorEtapas = CodigoHTML
    End Function
    Public Function TituloAccionesPorEtapas(ByVal EtapasId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select Etapas.EtapasName, TipoProcesoName "
        sSQL = sSQL & "FROM Etapas "
        sSQL = sSQL & "WHERE Etapas.EtapasId = " & EtapasId
        TituloAccionesPorEtapas = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TituloAccionesPorEtapas = "<h2>Acciones de la Etapa " & dtr("EtapasName").ToString & "</h2>"  '" del " & dtr("TipoProcesoName").ToString & 
            End While
            dtr.Close()
        Catch
            TituloAccionesPorEtapas = ""
        End Try
    End Function
    Public Function ListarEtapasPorTipoProceso(ByVal TipoProcesoId As Long, ByVal UserId As Long) As String
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim t As Boolean
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;"
        Dim Etapas As New Etapas
        Dim TipoProceso As New TipoProceso
        Dim l As String = ""
        Dim Pagina As String = ""
        Dim EtapasPorTipoProcesoId As Long = 0
        Dim Valor As Long = 0
        Dim Secuencia As Long = 0
        Dim TipoProcesoName As String = TipoProceso.LeerTipoProcesoNameById(TipoProcesoId)
        Dim CodigoHTML As String = ""
        Dim UrlEditarCarpeta As String = "*"
        Dim UrlCrearSubCarpeta As String = "*"

        sSQL = "SELECT Etapas.EtapasId As PId, Etapas.EtapasName As Carpeta, Etapas.EtapasDescription As Descripcion, Etapas.EtapasPostCondiciones As PostCondicion "
        sSQL = sSQL & "FROM Etapas "
        ' Esta condición deberá ser eliminada posteriormente
        sSQL = sSQL & "WHERE TipoProcesoId = 2 "
        sSQL = sSQL & "ORDER BY Etapas.EtapasSecuencia"
        CodigoHTML = ""
        Dim linkAgregar As String = "<input id=""AgregarUnaEtapa"" type=""button"" value=""Agregar una etapa"" class=""boxceleste"" title=""De un click para agregar una nueva etapa al proceso"" onclick=""verModalEtapasTipoProceso('FichaEtapas.aspx?EtapasId=0&TipoProcesoId=" & TipoProcesoId & "&PaginaWebName=Ficha de Etapas', " & UserId & ")"" />"
        CodigoHTML = CodigoHTML & linkAgregar
        CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""2"" cellspacing=""2"" class=""popup_tabla_de_datos_tareas"">"
        CodigoHTML = CodigoHTML & "<caption><h2>Lista de Etapas del " & TipoProcesoName & "</h2></caption>"
        CodigoHTML = CodigoHTML & "<tr><th width=""100"" align=""left"">Etapa</th><th width=""320"" align=""left"">Descripción</th><th width=""80"" align=""center"">Editar/Numerar/Asociar</th></tr>"
        ListarEtapasPorTipoProceso = ""
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read
                Valor = CLng(dtrFunciones("PId"))
                If Etapas.LeerEtapaPorTipoProceso(TipoProcesoId, Valor, EtapasPorTipoProcesoId, Secuencia) Then
                    l = "<div id=""divContent" & Valor & """ ><input id=""txtInputbox" & Valor & """ type=""text"" style=""text-align:right;width: 25px"" class=""textoboxgris""  value=""" & FormatNumber(Secuencia, 0) & """ onblur=""EtapasPorTipoProcesoUpdateSecuencia(" & TipoProcesoId & ", " & Valor & ", " & UserId & ")""  />&nbsp;&nbsp;<input id=""Checkbox" & Valor & """ type=""checkbox"" checked=""checked"" onclick=""EtapasPorTipoProcesoUpdate(" & TipoProcesoId & ", " & Valor & ", " & UserId & ")"" />&nbsp;&nbsp;<img src=""img/editar.png"" alt=""Editar una etapa del proceso judicial"" hspace=""5"" border=""0"" align=""left"" title=""Editar una etapa del proceso judicial"" onclick=""verModalEtapasTipoProceso('FichaEtapas.aspx?EtapasId=" & Valor & "&TipoProcesoId=" & TipoProcesoId & "&PaginaWebName=Ficha de Etapas', " & UserId & ")"" /></div>"
                Else
                    'l = "<input id=""txtInputbox" & Valor & """ type=""text"" style=""text-align:right;width: 25px"" class=""textoboxgris"" value=""0"" />&nbsp;&nbsp;<input id=""Checkbox" & Valor & """ type=""checkbox"" onclick=""FuncionesPorPortalUpdate(" & PortalesId & ", " & Valor & ", " & UserId & ")"" />"
                    l = "<div id=""divContent" & Valor & """ ><input id=""Checkbox" & Valor & """ type=""checkbox"" onclick=""EtapasPorTipoProcesoUpdate(" & TipoProcesoId & ", " & Valor & ", " & UserId & ")"" />&nbsp;&nbsp;<img src=""img/editar.png"" alt=""Editar una etapa del proceso judicial"" hspace=""5"" border=""0"" align=""left"" title=""Editar una etapa del proceso judicial"" onclick=""verModalEtapasTipoProceso('FichaEtapas.aspx?EtapasId=" & Valor & "&TipoProcesoId=" & TipoProcesoId & "&PaginaWebName=Ficha de Etapas', " & UserId & ")"" /></div>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td width=""100"" align=""left"">" & dtrFunciones("Carpeta").ToString & "</td><td width=""320"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""80"" align=""center"">" & l & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtrFunciones.Close()
        Catch
            ListarEtapasPorTipoProceso = ""
        End Try
        ListarEtapasPorTipoProceso = CodigoHTML & "</table>"
    End Function
    Public Function LeerEtapaPorTipoProceso(ByVal TipoProcesoId As Long, ByVal EtapasId As String, ByRef EtapasPorTipoProcesoId As Long, ByRef Secuencia As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EtapasPorTipoProcesoId, Secuencia "
        sSQL = sSQL & "FROM EtapasPorTipoProceso "
        sSQL = sSQL & "WHERE TipoProcesoId = " & TipoProcesoId & " AND EtapasId = " & EtapasId & " "

        LeerEtapaPorTipoProceso = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                EtapasPorTipoProcesoId = CLng(dtr("EtapasPorTipoProcesoId").ToString)
                Secuencia = CLng(dtr("Secuencia").ToString)
                LeerEtapaPorTipoProceso = True
            End While
            dtr.Close()
        Catch
            LeerEtapaPorTipoProceso = False
        End Try
    End Function
    Public Function LeerEtapasPorTipoProcesoId(ByVal TipoProcesoId As Long, ByVal EtapasId As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select EtapasPorTipoProcesoId "
        sSQL = sSQL & "FROM EtapasPorTipoProceso "
        sSQL = sSQL & "WHERE TipoProcesoId = " & TipoProcesoId & " AND EtapasId = " & EtapasId & " "

        LeerEtapasPorTipoProcesoId = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerEtapasPorTipoProcesoId = CLng(dtr("EtapasPorTipoProcesoId").ToString)
            End While
            dtr.Close()
        Catch
            LeerEtapasPorTipoProcesoId = 0
        End Try
    End Function
    Public Function EtapasPorTipoProcesoUpdate(ByVal TipoProcesoId As Long, ByVal EtapasId As String, ByVal Secuencia As Long, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim EtapasPorTipoProcesoId As Long = 0
        Dim SecuenciaGrabada As Long = 0
        Dim Lecturas As New Lecturas
        Dim Etapas As New Etapas
        Dim CodigoHTMLCarpetas As String = ""

        If LeerEtapaPorTipoProceso(TipoProcesoId, EtapasId, EtapasPorTipoProcesoId, SecuenciaGrabada) = True Then
            'Se elimina si la secuencia es la 
            strUpdate = "DELETE FROM EtapasPorTipoProceso WHERE TipoProcesoId = " & TipoProcesoId & " AND EtapasId = " & EtapasId

            Try
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Etapa " & EtapasId & " para el Proceso " & TipoProcesoId, TipoProcesoId, "TipoProceso", "")
                EtapasPorTipoProcesoUpdate = Etapas.ListarEtapasPorTipoProceso(TipoProcesoId, UserId)
            Catch
                EtapasPorTipoProcesoUpdate = 0
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar Etapa " & EtapasId & " para el Proceso " & TipoProcesoId, TipoProcesoId, "TipoProceso", "")
            End Try
        Else
            'Se Crea
            'Primero se busca la secuencia disponible y se le suma 1, se crean las posiciones segun el orden que se escoje.
            Secuencia = Lecturas.LeerMaximoId("Select Max(Secuencia) as MaximoId FROM EtapasPorTipoProceso WHERE TipoProcesoID = " & TipoProcesoId) + 1
            strUpdate = "INSERT INTO EtapasPorTipoProceso ( TipoProcesoId, EtapasId, Secuencia, DateLastUpdate, UserLastUpdate "
            strUpdate = strUpdate & ") VALUES (" & TipoProcesoId & ", " & EtapasId & ", " & Secuencia & ", '" & AccionesABM.DateTransform(Now()) & "', " & UserId & ")"

            Try
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Etapa " & EtapasId & " para el Proceso " & TipoProcesoId, TipoProcesoId, "TipoProceso", "")
                EtapasPorTipoProcesoUpdate = Etapas.ListarEtapasPorTipoProceso(TipoProcesoId, UserId)

            Catch
                EtapasPorTipoProcesoUpdate = "0"
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de Insertar Etapa " & EtapasId & " para el Proceso " & TipoProcesoId, TipoProcesoId, "TipoProceso", "")
            End Try

        End If
    End Function
    Public Function EtapasPorTipoProcesoUpdateSecuencia(ByVal TipoProcesoId As Long, ByVal EtapasId As String, ByVal Secuencia As Long, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim EtapasPorTipoProcesoId As Long = 0
        Dim SecuenciaGrabada As Long = 0
        Dim Etapas As New Etapas
        Dim CodigoHTMLCarpetas = ""

        EtapasPorTipoProcesoUpdateSecuencia = 0

        If LeerEtapaPorTipoProceso(TipoProcesoId, EtapasId, EtapasPorTipoProcesoId, SecuenciaGrabada) = True Then
            'Se encontro el registro y por ello se actualiza 
            strUpdate = "UPDATE EtapasPorTipoProceso SET "
            strUpdate = strUpdate & "EtapasPorTipoProceso.Secuencia = " & Secuencia & ", "
            strUpdate = strUpdate & "EtapasPorTipoProceso.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
            strUpdate = strUpdate & "EtapasPorTipoProceso.UserLastUpdate = " & UserId & " "
            strUpdate = strUpdate & "WHERE EtapasPorTipoProceso.EtapasPorTipoProcesoId = " & EtapasPorTipoProcesoId
            Try
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Secuencia de la Etapa " & EtapasId & " para el Proceso " & TipoProcesoId, TipoProcesoId, "TipoProceso", "")
                EtapasPorTipoProcesoUpdateSecuencia = Etapas.ListarEtapasPorTipoProceso(TipoProcesoId, UserId)
            Catch
                t = 0
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar la secuencia de la Etapa " & EtapasId & " para el Proceso " & TipoProcesoId, TipoProcesoId, "TipoProceso", "")
            End Try
        Else
            'No vamos a crear un registro
            'strUpdate = "INSERT INTO FuncionesPorPortal ( PortalesId, MenuOptionsId, Secuencia, DateLastUpdate, UserLastUpdate "
            'strUpdate = strUpdate & ") VALUES (" & PortalesId & ", " & MenuOptionsId & ", " & Secuencia & ", '" & AccionesABM.DateTransform(Now()) & "', " & UserId & ")"

            'Try
            '    FuncionesPorPortalUpdateSecuencia = AccesoEA.ABMRegistros(strUpdate)
            '    t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Función " & MenuOptionsId & " para el Portal " & PortalesId, PortalesId, "Portales", "")
            'Catch
            '    FuncionesPorPortalUpdateSecuencia = 0
            '    t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de Insertar Función " & MenuOptionsId & " para el Portal " & PortalesId, PortalesId, "Portales", "")
            'End Try

        End If
    End Function
    Public Function LeerIdEtapaAnterior(ByVal EtapasId As Long, ByVal EtapasSecuencia As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim Id As Long = 0

        sSQL = "Select EtapasId as Id "
        sSQL = sSQL & "FROM Etapas "
        sSQL = sSQL & "WHERE Etapas.EtapasSecuencia < " & EtapasSecuencia & " AND Etapas.TipoProcesoId = 2 "
        sSQL = sSQL & "ORDER BY EtapasSecuencia Desc"
        LeerIdEtapaAnterior = 0
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
            LeerIdEtapaAnterior = EtapasId
        Else
            LeerIdEtapaAnterior = Id
        End If


    End Function
    Public Function LeerIdEtapaSiguiente(ByVal EtapasId As String, ByVal EtapasSecuencia As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim Id As Long = 0

        sSQL = "Select EtapasId as Id "
        sSQL = sSQL & "FROM Etapas "
        sSQL = sSQL & "WHERE Etapas.EtapasSecuencia > " & EtapasSecuencia & " AND Etapas.TipoProcesoId = 2 "  'La última condición deberá ser eliminada más adelante
        sSQL = sSQL & "ORDER BY EtapasSecuencia Asc"

        LeerIdEtapaSiguiente = 0

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
            LeerIdEtapaSiguiente = EtapasId
        Else
            LeerIdEtapaSiguiente = Id
        End If
    End Function
    Public Function ListarAccionesPorEtapasPorTipoProceso(ByVal EtapasId As Long, ByVal TipoProcesoId As Long, ByVal UserId As Long) As String
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim t As Boolean
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;"
        Dim Etapas As New Etapas
        Dim TipoProceso As New TipoProceso
        Dim l As String = ""
        Dim Pagina As String = ""
        Dim AccionesPorEtapasPorTipoProcesoId As Long = 0
        Dim Valor As Long = 0
        Dim Secuencia As Long = 0
        Dim EtapasName As String = Etapas.LeerEtapasNameById(EtapasId)
        Dim ProcesosName As String = TipoProceso.LeerTipoProcesoNameById(TipoProcesoId)
        Dim CodigoHTML As String = ""
        Dim UrlEditarCarpeta As String = "*"
        Dim UrlCrearSubCarpeta As String = "*"

        Dim EtapasPorTipoProcesoId As Long = Etapas.LeerEtapasPorTipoProcesoId(TipoProcesoId, EtapasId)

        sSQL = "SELECT Acciones.AccionesId As PId, Acciones.AccionesCodigo as Codigo, Acciones.AccionesName As Carpeta, Acciones.AccionesDescription As Descripcion, Acciones.RolName As Rol, Acciones.TipoProcesoSecuencia As TipoProcesoId "
        sSQL = sSQL & "FROM Acciones "
        sSQL = sSQL & "WHERE Acciones.EtapasId = " & EtapasId & " "
        sSQL = sSQL & "ORDER BY Acciones.AccionesSecuencia"


        CodigoHTML = ""
        Dim linkAgregar As String = "<input id=""AgregarUnaAccion"" type=""button"" value=""Agregar una acci&oacute;n"" class=""boxceleste"" title=""De un click para agregar una nueva acci&oacute;n a la etapa"" onclick=""verModalAccionEtapas('FichaAcciones.aspx?AccionesId=0&EtapasId=" & EtapasId & "&TipoProcesoId=" & TipoProcesoId & "&PaginaWebName=Ficha de Acciones', " & UserId & ", " & TipoProcesoId & ")"" />"
        'Dim linkAgregar As String = "<input id=""AgregarUnaAccion"" type=""button"" value=""Agregar una acción"" class=""boxceleste"" title=""De un click para agregar una nueva acción a la etapa"" onclick=""verModalEtapasTipoProceso('FichaEtapas.aspx?EtapasId=0&TipoProcesoId=" & TipoProcesoId & "&PaginaWebName=Ficha de Etapas', " & UserId & ")"" />"
        CodigoHTML = CodigoHTML & linkAgregar
        CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""2"" cellspacing=""2"" class=""popup_tabla_de_datos_tareas"">"
        CodigoHTML = CodigoHTML & "<caption><h2>Lista de Acciones de la Etapa " & EtapasName & " del " & ProcesosName & "</h2></caption>"
        CodigoHTML = CodigoHTML & "<tr>"
        CodigoHTML = CodigoHTML & "<th width=""200"" align=""left"">Acci&oacute;n</th>"
        CodigoHTML = CodigoHTML & "<th width=""50"" align=""left"">Rol</th>"
        'CodigoHTML = CodigoHTML & "<th width=""295"">Descripci&oacute;n</th>"
        CodigoHTML = CodigoHTML & "<th width=""80"">Editar/Numerar/Asociar</th>"
        CodigoHTML = CodigoHTML & "</tr>"
        'CodigoHTML = CodigoHTML & "<tr><th width=""100"" align=""left"">Etapa</th><th width=""320"" align=""left"">Descripción</th><th width=""80"" align=""center"">Editar/Numerar/Asociar</th></tr>"
        ListarAccionesPorEtapasPorTipoProceso = ""
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read
                Valor = CLng(dtrFunciones("PId"))
                If Etapas.LeerAccionPorEtapaPorTipoProceso(EtapasPorTipoProcesoId, Valor, AccionesPorEtapasPorTipoProcesoId, Secuencia) Then
                    l = "<div id=""divContent" & Valor & """ ><input id=""txtInputbox" & Valor & """ type=""text"" style=""text-align:right;width: 25px"" class=""textoboxgris""  value=""" & FormatNumber(Secuencia, 0) & """ onblur=""AccionesPorEtapasPorTipoProcesoUpdateSecuencia(" & EtapasPorTipoProcesoId & ", " & Valor & ", " & UserId & ")""  />&nbsp;&nbsp;<input id=""Checkbox" & Valor & """ type=""checkbox"" checked=""checked"" onclick=""AccionesPorEtapasPorTipoProcesoUpdate(" & EtapasPorTipoProcesoId & ", " & Valor & ", " & UserId & ")"" />&nbsp;&nbsp;<img src=""img/editar.png"" alt=""Editar una acci&oacute;n de la etapas del proceso judicial"" hspace=""5"" border=""0"" align=""left"" title=""Editar una acci&0acute;n de la etapa del proceso judicial"" onclick=""verModalAccionEtapas('FichaAcciones.aspx?AccionesId=" & Valor & "&EtapasId=" & EtapasId & "&TipoProcesoId=" & TipoProcesoId & "&PaginaWebName=Ficha de Acciones', " & UserId & ", " & TipoProcesoId & ")"" /></div>"
                Else
                    'l = "<input id=""txtInputbox" & Valor & """ type=""text"" style=""text-align:right;width: 25px"" class=""textoboxgris"" value=""0"" />&nbsp;&nbsp;<input id=""Checkbox" & Valor & """ type=""checkbox"" onclick=""FuncionesPorPortalUpdate(" & PortalesId & ", " & Valor & ", " & UserId & ")"" />"
                    l = "<div id=""divContent" & Valor & """ ><input id=""Checkbox" & Valor & """ type=""checkbox"" onclick=""AccionesPorEtapasPorTipoProcesoUpdate(" & EtapasPorTipoProcesoId & ", " & Valor & ", " & UserId & ")"" />&nbsp;&nbsp;<img src=""img/editar.png"" alt=""Editar una acci&oacute;n de una etapa del proceso judicial"" hspace=""5"" border=""0"" align=""left"" title=""Editar una Acci&oacute;n de una etapa del proceso judicial"" onclick=""verModalAccionEtapas('FichaAcciones.aspx?AccionesId=" & Valor & "&EtapasId=" & EtapasId & "&TipoProcesoId=" & TipoProcesoId & "&PaginaWebName=Ficha de Acciones', " & UserId & ", " & TipoProcesoId & ")"" /></div>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td width=""200"" align=""left"">" & dtrFunciones("Carpeta").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td width=""50"">" & dtrFunciones("Rol").ToString & "</td>"
                'CodigoHTML = CodigoHTML & "<td width=""295"">" & dtrFunciones("Descripcion").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td width=""80"" align=""center"">" & l & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtrFunciones.Close()
        Catch
            ListarAccionesPorEtapasPorTipoProceso = ""
        End Try
        ListarAccionesPorEtapasPorTipoProceso = CodigoHTML & "</table>"
    End Function
    Public Function LeerAccionPorEtapaPorTipoProceso(ByVal EtapasPorTipoProcesoId As Long, ByVal AccionesId As String, ByRef AccionesPorEtapasPorTipoProcesoId As Long, ByRef Secuencia As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select AccionesPorEtapasPorTipoProcesoId, Secuencia "
        sSQL = sSQL & "FROM AccionesPorEtapasPorTipoProceso "
        sSQL = sSQL & "WHERE EtapasPorTipoProcesoId = " & EtapasPorTipoProcesoId & " AND AccionesId = " & AccionesId & " "

        LeerAccionPorEtapaPorTipoProceso = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                AccionesPorEtapasPorTipoProcesoId = CLng(dtr("AccionesPorEtapasPorTipoProcesoId").ToString)
                Secuencia = CLng(dtr("Secuencia").ToString)
                LeerAccionPorEtapaPorTipoProceso = True
            End While
            dtr.Close()
        Catch
            LeerAccionPorEtapaPorTipoProceso = False
        End Try
    End Function
    Public Function AccionesPorEtapasPorTipoProcesoUpdate(ByVal EtapasPorTipoProcesoId As Long, ByVal AccionesId As String, ByVal Secuencia As Long, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Acciones As New Acciones
        Dim t As Integer = 0
        Dim AccionesPorEtapasPorTipoProcesoId As Long = 0
        Dim SecuenciaGrabada As Long = 0
        Dim Lecturas As New Lecturas
        Dim Etapas As New Etapas
        Dim CodigoHTMLCarpetas As String = ""
        Dim EtapasId As Long = 0
        Dim TipoProcesoId As Long = 0
        Dim TipoProcesoName As String = ""
        Dim EtapasName As String = ""
        Dim AccionesName As String = Acciones.LeerAccionesNameByAccionesId(AccionesId)

        t = Etapas.LeerEtapasNameProcesosNameByEtapasPorTipoProcesoId(EtapasPorTipoProcesoId, TipoProcesoName, EtapasName, TipoProcesoId, EtapasId)

        If LeerAccionPorEtapaPorTipoProceso(EtapasPorTipoProcesoId, AccionesId, AccionesPorEtapasPorTipoProcesoId, SecuenciaGrabada) = True Then
            'Se elimina si la secuencia es la 
            strUpdate = "DELETE FROM AccionesPorEtapasPorTipoProceso WHERE EtapasPorTipoProcesoId = " & EtapasPorTipoProcesoId & " AND AccionesId = " & AccionesId

            Try
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Acción " & AccionesName & " para la Etapa " & EtapasName & " del " & TipoProcesoName, AccionesId, "Acciones", "")
                AccionesPorEtapasPorTipoProcesoUpdate = Etapas.ListarAccionesPorEtapasPorTipoProceso(EtapasId, TipoProcesoId, UserId)
            Catch
                AccionesPorEtapasPorTipoProcesoUpdate = 0
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar acción " & AccionesName & " para la etapa " & EtapasName & "del " & TipoProcesoName, AccionesId, "Acciones", "")
            End Try
        Else
            'Se Crea
            'Primero se busca la secuencia disponible y se le suma 1, se crean las posiciones segun el orden que se escoje.
            Secuencia = Lecturas.LeerMaximoId("Select Max(Secuencia) as MaximoId FROM AccionesPorEtapasPorTipoProceso WHERE EtapasPorTipoProcesoId = " & EtapasPorTipoProcesoId) + 1
            strUpdate = "INSERT INTO AccionesPorEtapasPorTipoProceso ( EtapasPorTipoProcesoId, AccionesId, Secuencia, DateLastUpdate, UserLastUpdate "
            strUpdate = strUpdate & ") VALUES (" & EtapasPorTipoProcesoId & ", " & AccionesId & ", " & Secuencia & ", '" & AccionesABM.DateTransform(Now()) & "', " & UserId & ")"

            Try
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Acción " & AccionesName & " para la etapa " & EtapasName & " del " & TipoProcesoName, AccionesId, "Acciones", "")
                AccionesPorEtapasPorTipoProcesoUpdate = Etapas.ListarAccionesPorEtapasPorTipoProceso(EtapasId, TipoProcesoId, UserId)

            Catch
                AccionesPorEtapasPorTipoProcesoUpdate = "0"
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de Insertar Acción " & AccionesName & " para la Etapa " & EtapasName & " del " & TipoProcesoName, AccionesId, "Acciones", "")
            End Try

        End If
    End Function
    Public Function LeerEtapasNameProcesosNameByEtapasPorTipoProcesoId(ByVal EtapasPorTipoProcesoId As Long, ByRef TipoProcesoName As String, ByRef EtapasName As String, ByRef TipoProcesoId As Long, ByRef EtapasId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TipoProceso.TipoProcesoName, Etapas.EtapasName, TipoProceso.TipoProcesoId, Etapas.EtapasId "
        sSQL = sSQL & "FROM EtapasPorTipoProceso, TipoProceso, Etapas "
        sSQL = sSQL & "WHERE EtapasPorTipoProcesoId = " & EtapasPorTipoProcesoId & " AND TipoProceso.TipoProcesoId = EtapasPorTipoProceso.TipoProcesoId AND Etapas.EtapasId = EtapasPorTipoProceso.EtapasId "

        LeerEtapasNameProcesosNameByEtapasPorTipoProcesoId = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TipoProcesoName = CStr(dtr("TipoProcesoName").ToString)
                EtapasName = CStr(dtr("EtapasName").ToString)
                TipoProcesoId = CLng(dtr("TipoProcesoId").ToString)
                EtapasId = CLng(dtr("EtapasId").ToString)
                LeerEtapasNameProcesosNameByEtapasPorTipoProcesoId = True
            End While
            dtr.Close()
        Catch
            LeerEtapasNameProcesosNameByEtapasPorTipoProcesoId = False
        End Try
    End Function
    Public Function AccionesPorEtapasPorTipoProcesoUpdateSecuencia(ByVal EtapasPorTipoProcesoId As Long, ByVal AccionesId As String, ByVal Secuencia As Long, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Acciones As New Acciones
        Dim t As Integer = 0
        Dim AccionesPorEtapasPorTipoProcesoId As Long = 0
        Dim SecuenciaGrabada As Long = 0
        Dim Etapas As New Etapas
        Dim CodigoHTMLCarpetas = ""
        Dim EtapasId As Long = 0
        Dim TipoProcesoId As Long = 0
        Dim TipoProcesoName As String = ""
        Dim EtapasName As String = ""
        Dim AccionesName As String = Acciones.LeerAccionesNameByAccionesId(AccionesId)

        t = Etapas.LeerEtapasNameProcesosNameByEtapasPorTipoProcesoId(EtapasPorTipoProcesoId, TipoProcesoName, EtapasName, TipoProcesoId, EtapasId)

        AccionesPorEtapasPorTipoProcesoUpdateSecuencia = 0

        If LeerAccionPorEtapaPorTipoProceso(EtapasPorTipoProcesoId, AccionesId, AccionesPorEtapasPorTipoProcesoId, SecuenciaGrabada) = True Then
            'Se encontro el registro y por ello se actualiza 
            strUpdate = "UPDATE AccionesPorEtapasPorTipoProceso SET "
            strUpdate = strUpdate & "AccionesPorEtapasPorTipoProceso.Secuencia = " & Secuencia & ", "
            strUpdate = strUpdate & "AccionesPorEtapasPorTipoProceso.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
            strUpdate = strUpdate & "AccionesPorEtapasPorTipoProceso.UserLastUpdate = " & UserId & " "
            strUpdate = strUpdate & "WHERE AccionesPorEtapasPorTipoProceso.AccionesPorEtapasPorTipoProcesoId = " & AccionesPorEtapasPorTipoProcesoId
            Try
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Secuencia de la Acción " & AccionesName & " de la Etapa " & EtapasName & " del " & TipoProcesoName, AccionesId, "Acciones", "")
                AccionesPorEtapasPorTipoProcesoUpdateSecuencia = Etapas.ListarAccionesPorEtapasPorTipoProceso(EtapasId, TipoProcesoId, UserId)
            Catch
                t = 0
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar la secuencia de la Acción " & AccionesName & " de la etapa " & EtapasName & " del " & TipoProcesoName, AccionesId, "Acciones", "")
            End Try
        Else
            'No vamos a crear un registro
            'strUpdate = "INSERT INTO FuncionesPorPortal ( PortalesId, MenuOptionsId, Secuencia, DateLastUpdate, UserLastUpdate "
            'strUpdate = strUpdate & ") VALUES (" & PortalesId & ", " & MenuOptionsId & ", " & Secuencia & ", '" & AccionesABM.DateTransform(Now()) & "', " & UserId & ")"

            'Try
            '    FuncionesPorPortalUpdateSecuencia = AccesoEA.ABMRegistros(strUpdate)
            '    t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Función " & MenuOptionsId & " para el Portal " & PortalesId, PortalesId, "Portales", "")
            'Catch
            '    FuncionesPorPortalUpdateSecuencia = 0
            '    t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de Insertar Función " & MenuOptionsId & " para el Portal " & PortalesId, PortalesId, "Portales", "")
            'End Try

        End If
    End Function

End Class
