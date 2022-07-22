Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class Carpetas
    Public Function LoadTiposDocumentos(ByVal node As TreeNode) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrPackages As IDataReader
        'Dim dtrPackages As SqlDataReader
        Dim sSQL As String = ""
        Dim Codigo As String = ""
        Dim Nombre As String = ""
        Dim Carpetas As New Carpetas

        sSQL = "SELECT TipoDoc.[TipoDocId] As Id, TipoDoc.[TipoDocName] As Nombre "
        sSQL = sSQL & "FROM TipoDoc "
        sSQL = sSQL & "ORDER BY TipoDoc.[TipoDocName]"

        LoadTiposDocumentos = False

        Try
            dtrPackages = AccesoEA.ListarRegistros(sSQL)
            While dtrPackages.Read
                If (Not IsDBNull(dtrPackages("Nombre")) And Not IsDBNull(dtrPackages("Id"))) Then
                    'Dim urlPaginaCargos As String = "AdministradorDeCargos.aspx?id=" & dtrPackages("AmbitosId")
                    Dim urlPaginaCargos As String = dtrPackages("Nombre")
                    Dim newNode As TreeNode = New TreeNode(dtrPackages("Nombre"), dtrPackages("Id"), "img/WebResource2.gif", "", "")
                    newNode.SelectAction = TreeNodeSelectAction.Expand
                    newNode.PopulateOnDemand = True
                    node.ChildNodes.Add(newNode)
                    LoadTiposDocumentos = True
                End If
            End While
            dtrPackages.Close()
        Catch
            LoadTiposDocumentos = False
        End Try

    End Function
    Public Function LoadDocumentosPorTipo(ByVal node As TreeNode) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrPackages As IDataReader
        Dim sSQL As String
        Dim TipoDocId As String = node.Value
        Dim Lecturas As New Lecturas
        Dim TipoDoc As New TipoDoc
        Dim t As Boolean
        Dim TipoDocName As String = TipoDoc.LeerTipoDocNameById(TipoDocId)

        LoadDocumentosPorTipo = False

        sSQL = "SELECT DocumentosSGI.[DocumentosSGIId] As Id, DocumentosSGI.DocumentosSGICodigo As Codigo, DocumentosSGI.DocumentosSGINombre as Nombre, 'SGI\' + DocumentosSGI.DocumentosSGIPath As Url, convert(varchar, DocumentosSGI.DocumentosSGIFEmision, 23) As Fecha "
        sSQL = sSQL & "FROM DocumentosSGI "
        sSQL = sSQL & "WHERE (((DocumentosSGI.DocumentosSGITipo)= '" & TipoDocName & "' ))"

        Try
            dtrPackages = AccesoEA.ListarRegistros(sSQL)
            While dtrPackages.Read
                'Dim urlPaginaCargos As String = "CambiarCargoSuperior.aspx?Nuevoid=" & dtrPackages("Numero") & "&NuevoCargo=" & dtrPackages("Cargo")
                Dim TituloDocumento As String = "[" & dtrPackages("Fecha") & "] " & dtrPackages("Nombre").ToString
                If Len(TituloDocumento) > 100 Then
                    TituloDocumento = Mid(TituloDocumento, 1, 100) & " ..."
                End If
                Dim newNode As TreeNode = New TreeNode(TituloDocumento, dtrPackages("Codigo"), "img/WebResource.gif", dtrPackages("Url"), "_blank")
                newNode.SelectAction = TreeNodeSelectAction.Expand
                newNode.PopulateOnDemand = True
                node.ChildNodes.Add(newNode)
                LoadDocumentosPorTipo = True
            End While
            dtrPackages.Close()
        Catch
            LoadDocumentosPorTipo = False
        End Try



    End Function
    Public Function LoadYears(ByVal node As TreeNode) As Boolean
        Dim newNode As TreeNode

        LoadYears = False

        newNode = New TreeNode("2009", "2009", "img/WebResource2.gif", "", "")
        newNode.SelectAction = TreeNodeSelectAction.Expand
        newNode.PopulateOnDemand = True
        node.ChildNodes.Add(newNode)

        newNode = New TreeNode("2010", "2010", "img/WebResource2.gif", "", "")
        newNode.SelectAction = TreeNodeSelectAction.Expand
        newNode.PopulateOnDemand = True
        node.ChildNodes.Add(newNode)

        newNode = New TreeNode("2011", "2011", "img/WebResource2.gif", "", "")
        newNode.SelectAction = TreeNodeSelectAction.Expand
        newNode.PopulateOnDemand = True
        node.ChildNodes.Add(newNode)

        newNode = New TreeNode("2012", "2012", "img/WebResource2.gif", "", "")
        newNode.SelectAction = TreeNodeSelectAction.Expand
        newNode.PopulateOnDemand = True
        node.ChildNodes.Add(newNode)

        LoadYears = True


    End Function

    Public Function LoadNivel1(ByVal node As TreeNode, ByVal Carpeta As String) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrPackages As IDataReader
        'Dim dtrPackages As SqlDataReader
        Dim sSQL As String = ""
        Dim Codigo As String = ""
        Dim Nombre As String = ""
        Dim Carpetas As New Carpetas

        sSQL = "SELECT Carpetas.[CarpetasId] As Id, Carpetas.[CarpetasPId] As PId, Carpetas.[CarpetasSecuencia] As Sec, Carpetas.[CarpetasName] As Nombre "
        sSQL = sSQL & "FROM(Carpetas) "
        sSQL = sSQL & "WHERE(((Carpetas.[CarpetasPId]) = " & Carpetas.LeerCarpetaIdByName(Carpeta) & ")) "
        sSQL = sSQL & "ORDER BY Carpetas.[CarpetasSecuencia]"

        LoadNivel1 = False

        Try
            dtrPackages = AccesoEA.ListarRegistros(sSQL)
            While dtrPackages.Read
                If (Not IsDBNull(dtrPackages("Nombre")) And Not IsDBNull(dtrPackages("Id"))) Then
                    'Dim urlPaginaCargos As String = "AdministradorDeCargos.aspx?id=" & dtrPackages("AmbitosId")
                    Dim urlPaginaCargos As String = dtrPackages("Nombre")
                    Dim newNode As TreeNode = New TreeNode(dtrPackages("Nombre"), dtrPackages("Id"), "img/WebResource2.gif", "", "")
                    newNode.SelectAction = TreeNodeSelectAction.Expand
                    newNode.PopulateOnDemand = True
                    node.ChildNodes.Add(newNode)
                    LoadNivel1 = True
                End If
            End While
            dtrPackages.Close()
        Catch
            LoadNivel1 = False
        End Try

    End Function
    Public Function LoadNivel2(ByVal node As TreeNode) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrPackages As IDataReader
        Dim sSQL As String
        Dim CarpetasPId As String = node.Value
        Dim Lecturas As New Lecturas

        sSQL = "SELECT Carpetas.[CarpetasId] As Id, Carpetas.[CarpetasPId] As PId, Carpetas.[CarpetasSecuencia] As Sec, Carpetas.[CarpetasName] As Nombre "
        sSQL = sSQL & "FROM(Carpetas) "
        sSQL = sSQL & "WHERE(((Carpetas.[CarpetasPId]) = " & CarpetasPId & ")) "
        sSQL = sSQL & "ORDER BY Carpetas.[CarpetasSecuencia]"

        LoadNivel2 = False

        Try
            dtrPackages = AccesoEA.ListarRegistros(sSQL)
            While dtrPackages.Read
                'Dim urlPaginaCargos As String = "CambiarCargoSuperior.aspx?Nuevoid=" & dtrPackages("Numero") & "&NuevoCargo=" & dtrPackages("Cargo")
                Dim urlPaginaCargos As String = dtrPackages("Nombre")
                Dim newNode As TreeNode = New TreeNode(dtrPackages("Nombre"), dtrPackages("Id"), "img/WebResource2.gif", "", "")
                newNode.SelectAction = TreeNodeSelectAction.Expand
                newNode.PopulateOnDemand = True
                node.ChildNodes.Add(newNode)
                LoadNivel2 = True
            End While
            dtrPackages.Close()
        Catch
            LoadNivel2 = False
        End Try

        sSQL = "SELECT DocumentosSGIPorCarpeta.[DocumentosSGIPorCarpetaId] As Id, DocumentosSGIPorCarpeta.CarpetasId As PId, DocumentosSGI.DocumentosSGICodigo As Codigo, DocumentosSGI.DocumentosSGINombre as Nombre, 'SGI\' + DocumentosSGI.DocumentosSGIPath As Url, Mid(DocumentosSGI.DocumentosSGIFEmision,1,10) As Fecha "
        sSQL = sSQL & "FROM DocumentosSGIPorCarpeta INNER JOIN DocumentosSGI ON DocumentosSGIPorCarpeta.DocumentosSGIId = DocumentosSGI.DocumentosSGIId "
        sSQL = sSQL & "WHERE (((DocumentosSGIPorCarpeta.CarpetasId)=" & CarpetasPId & "))"

        Try
            dtrPackages = AccesoEA.ListarRegistros(sSQL)
            While dtrPackages.Read
                'Dim urlPaginaCargos As String = "CambiarCargoSuperior.aspx?Nuevoid=" & dtrPackages("Numero") & "&NuevoCargo=" & dtrPackages("Cargo")
                Dim TituloDocumento As String = "[" & dtrPackages("Fecha") & "] " & dtrPackages("Nombre").ToString
                If Len(TituloDocumento) > 100 Then
                    TituloDocumento = Mid(TituloDocumento, 1, 100) & " ..."
                End If
                Dim newNode As TreeNode = New TreeNode(TituloDocumento, dtrPackages("Codigo"), "img/WebResource.gif", dtrPackages("Url"), "_blank")
                newNode.SelectAction = TreeNodeSelectAction.Expand
                newNode.PopulateOnDemand = True
                node.ChildNodes.Add(newNode)
                LoadNivel2 = True
            End While
            dtrPackages.Close()
        Catch
            LoadNivel2 = False
        End Try



    End Function
    Public Function LeerCarpetas(ByVal CarpetasId As Long, ByRef CarpetasPId As Long, ByRef CarpetasSecuencia As Long, ByRef CarpetasName As String, ByRef CarpetasDescription As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Carpetas.[CarpetasId] As Id, Carpetas.[CarpetasPId] As PId, Carpetas.[CarpetasSecuencia] As Sec, Carpetas.[CarpetasName] As Nombre, Carpetas.[CarpetasDescription] As Description "
        sSQL = sSQL & "FROM(Carpetas) "
        sSQL = sSQL & "WHERE(((Carpetas.[CarpetasId]) = " & CarpetasId & ")) "
        sSQL = sSQL & "ORDER BY Carpetas.[CarpetasSecuencia]"

        LeerCarpetas = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CarpetasPId = CLng(dtr("PId").ToString)
                CarpetasSecuencia = CLng(dtr("Sec").ToString)
                CarpetasName = CStr(dtr("Nombre").ToString)
                CarpetasDescription = CStr(dtr("Description").ToString)
                LeerCarpetas = True
            End While
            dtr.Close()
        Catch
            LeerCarpetas = False
        End Try
    End Function
    Public Function CarpetasUpdate(ByVal CarpetasId As Long, ByVal CarpetasPId As Long, ByVal CarpetasSecuencia As Long, ByVal CarpetasName As String, ByVal CarpetasDescription As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "UPDATE Carpetas SET "
        strUpdate = strUpdate & "Carpetas.CarpetasPId = " & CarpetasPId & ", "
        strUpdate = strUpdate & "Carpetas.CarpetasSecuencia = " & CarpetasSecuencia & ", "
        strUpdate = strUpdate & "Carpetas.CarpetasName = '" & CarpetasName & "', "
        strUpdate = strUpdate & "Carpetas.CarpetasDescription = '" & CarpetasDescription & "', "
        strUpdate = strUpdate & "Carpetas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Carpetas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Carpetas.CarpetasId = " & CarpetasId
        Try
            CarpetasUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & CarpetasName, CarpetasId, "Carpetas", "")
        Catch
            CarpetasUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & CarpetasName, CarpetasId, "Carpetas", "")
        End Try
    End Function
    Public Function CarpetasUpdatePId(ByVal CarpetasId As Long, ByVal CarpetasPId As Long, ByVal CarpetasName As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "UPDATE Carpetas SET "
        strUpdate = strUpdate & "Carpetas.CarpetasPId = " & CarpetasPId & ", "
        strUpdate = strUpdate & "Carpetas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Carpetas.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Carpetas.CarpetasId = " & CarpetasId
        Try
            CarpetasUpdatePId = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza PId de " & CarpetasName, CarpetasId, "Carpetas", "")
        Catch
            CarpetasUpdatePId = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el PId  del registro de " & CarpetasName, CarpetasId, "Carpetas", "")
        End Try
    End Function
    Public Function CarpetasInsert(ByRef CarpetasId As Long, ByVal CarpetasPId As Long, ByVal CarpetasSecuencia As Long, ByVal CarpetasName As String, ByVal CarpetasDescription As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim AccesoEA As New AccesoEA
        Dim t As Integer = 0
        Dim strUpdate As String = ""

        strUpdate = "INSERT INTO CARPETAS (CarpetasPId, CarpetasSecuencia, CarpetasName, CarpetasDescription, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES (" & CarpetasPId & ", " & CarpetasSecuencia & ", '" & CarpetasName & "', '" & CarpetasDescription & "', '" & AccionesABM.DateTransform(Now()) & "', " & UserId & ")"

        Try

            CarpetasInsert = AccesoEA.ABMRegistros(strUpdate)
            CarpetasId = Lecturas.LeerMaximoId("Select Max(CarpetasId) as MaximoId FROM (Carpetas)")
            CarpetasInsert = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta una nueva Carpeta de Agrupación de Documentos: " & CarpetasName, CarpetasId, "Carpetas", "")
        Catch
            CarpetasInsert = 0
            CarpetasId = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar una nueva Carpeta de Agrupación de Documentos: " & CarpetasName, CarpetasId, "Carpetas", "")
        End Try
    End Function
    Public Function LeerTotalSubCarpetasRelacionadas(ByVal CarpetasId As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si tiene subcarpetas
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Carpetas "
        sSQL = sSQL & "WHERE (((Carpetas.CarpetasPId)=" & CarpetasId & "))"
        LeerTotalSubCarpetasRelacionadas = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalSubCarpetasRelacionadas = LeerTotalSubCarpetasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalSubCarpetasRelacionadas = 0
        End Try

        'Verifica si tiene documentos asociados
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM DocumentosSGIPorCarpeta "
        sSQL = sSQL & "WHERE (((DocumentosSGIPorCarpeta.CarpetasId)=" & CarpetasId & "))"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalSubCarpetasRelacionadas = LeerTotalSubCarpetasRelacionadas + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalSubCarpetasRelacionadas = 0
        End Try
    End Function
    Public Function CarpetasDelete(ByVal CarpetasId As Long, ByVal CarpetasName As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Carpetas As New Carpetas

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = Carpetas.LeerTotalSubCarpetasRelacionadas(CarpetasId)
        CarpetasDelete = False
        If Total > 0 Then
            Mensaje = "Existen " & Total & " registros subordinados a la carpeta " & CarpetasName & vbCrLf
            Mensaje = Mensaje & ", elimine las subcarpetas y desvincule los documentos antes de eliminarla de la lista"
            CarpetasDelete = False
        Else
            Try
                ' Borra registro de la tabla de Carpetas
                '-------------------------------------
                strUpdate = "DELETE FROM Carpetas WHERE CarpetasId = " & CarpetasId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina la Carpeta: " & CarpetasName, CarpetasId, "Carpetas", "")
                CarpetasDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la Carpeta: " & CarpetasName, CarpetasId, "Carpetas", "")
                CarpetasDelete = False
            End Try
        End If
    End Function
    Public Function LoadRaicesCarpeta(ByRef CodigoHTML As String, ByVal DocumentosSGIId As Long, ByVal UserId As Long, ByVal CarpetaRaiz As String) As String
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim t As Boolean
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;"
        Dim Carpetas As New Carpetas

        sSQL = "SELECT CarpetasId As PId, CarpetasName As Carpeta, CarpetasDescription As Descripcion "
        sSQL = sSQL & "FROM Carpetas "
        sSQL = sSQL & "WHERE CarpetasPId = " & Carpetas.LeerCarpetaIdByName(CarpetaRaiz) & " "
        sSQL = sSQL & "ORDER by Carpetas.CarpetasSecuencia"

        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""vinculo_carpeta"">"
        CodigoHTML = CodigoHTML & "<tr><th width=""60"" align=""center"">Asociar</th><th width=""400"" align=""left"">Carpetas y Sub Carpetas</th><th width=""338"" align=""left"">Descripción</th></tr>"
        LoadRaicesCarpeta = ""
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td width=""60"" align=""center""></td><td width=""400"" align=""left"">" & dtrFunciones("Carpeta").ToString & "</td><td width=""338"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<tr>"
                t = LoadNodosCarpetas(CLng(dtrFunciones("PId").ToString), CodigoHTML, DocumentosSGIId, UserId, Espacios)
            End While
            dtrFunciones.Close()
        Catch
            LoadRaicesCarpeta = ""
        End Try
        LoadRaicesCarpeta = CodigoHTML & "</table>"
    End Function
    Public Function LeerCarpetaIdByName(ByVal CarpetasName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Carpetas.CarpetasId As Id "
        sSQL = sSQL & "FROM(Carpetas) "
        sSQL = sSQL & "WHERE(((Carpetas.CarpetasName) = '" & CarpetasName & "'))"

        LeerCarpetaIdByName = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerCarpetaIdByName = CLng(dtr("Id").ToString)
            End While
            dtr.Close()
        Catch
            LeerCarpetaIdByName = 0
        End Try
    End Function
    Public Function LoadNodosCarpetas(ByVal CarpetasPId As Long, ByRef CodigoHTML As String, ByVal DocumentosSGIId As Long, ByVal UserId As Long, ByVal Espacios As String) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim Carpetas As New Carpetas
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim t As Boolean
        Dim EspacioMasAbajo As String = Espacios & "&nbsp;&nbsp;&nbsp;"
        Dim l As String = ""

        sSQL = "SELECT CarpetasId As PId, CarpetasName As Carpeta, CarpetasDescription As Descripcion "
        sSQL = sSQL & "FROM Carpetas "
        sSQL = sSQL & "WHERE CarpetasPId = " & CarpetasPId
        sSQL = sSQL & " ORDER by Carpetas.CarpetasSecuencia"
        LoadNodosCarpetas = False
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)
            While dtrFunciones.Read

                If Carpetas.LeerDocumentosSGIPorCarpetaId(CLng(dtrFunciones("PId").ToString), DocumentosSGIId) > 0 Then
                    l = "<input id=""Checkbox" & CLng(dtrFunciones("PId").ToString) & """ type=""checkbox"" checked=""checked"" onclick=""RelationTableUpdate('" & "DocumentosSGIPorCarpeta" & "', '" & "DocumentosSGI" & "', '" & "Carpetas" & "', " & DocumentosSGIId & ", " & CLng(dtrFunciones("PId").ToString) & ", " & UserId & ")"" />"
                Else
                    l = "<input id=""Checkbox" & CLng(dtrFunciones("PId").ToString) & """ type=""checkbox"" onclick=""RelationTableUpdate('" & "DocumentosSGIPorCarpeta" & "', '" & "DocumentosSGI" & "', '" & "Carpetas" & "', " & DocumentosSGIId & ", " & CLng(dtrFunciones("PId").ToString) & ", " & UserId & ")"" />"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td width=""60"" align=""center"">" & l & "</td><td width=""400"" align=""left"">" & Espacios & dtrFunciones("Carpeta").ToString & "</td><td width=""338"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<tr>"
                t = LoadNodosCarpetas(CLng(dtrFunciones("PId").ToString), CodigoHTML, DocumentosSGIId, UserId, EspacioMasAbajo)
                LoadNodosCarpetas = True
            End While
            dtrFunciones.Close()
        Catch
            LoadNodosCarpetas = False
        End Try
    End Function
    Public Function LeerDocumentosSGIPorCarpetaId(ByVal CarpetasId As Long, ByVal DocumentosSGIId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT DocumentosSGIPorCarpeta.DocumentosSGIPorCarpetaId As Id "
        sSQL = sSQL & "FROM DocumentosSGIPorCarpeta "
        sSQL = sSQL & "WHERE (((DocumentosSGIPorCarpeta.[CarpetasId]) = " & CarpetasId & ") AND ((DocumentosSGIPorCarpeta.[DocumentosSGIId]) = " & DocumentosSGIId & "))"

        LeerDocumentosSGIPorCarpetaId = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerDocumentosSGIPorCarpetaId = CLng(dtr("Id").ToString)
            End While
            dtr.Close()
        Catch
            LeerDocumentosSGIPorCarpetaId = 0
        End Try
    End Function
    Public Function DocumentosSGIPorCarpetaDelete(ByVal DocumentosSGIId As Long, ByVal DocumentosSGICodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long = 0
        Dim Carpetas As New Carpetas

        DocumentosSGIPorCarpetaDelete = False
        strUpdate = "DELETE FROM DocumentosSGIPorCarpeta WHERE DocumentosSGIId = " & DocumentosSGIId

        Try
            DocumentosSGIPorCarpetaDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina vinculos del documento: " & DocumentosSGICodigo, DocumentosSGIId, "DocumentosSGIPorCarpeta", "")
        Catch
            DocumentosSGIPorCarpetaDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar vínculos del documento: " & DocumentosSGICodigo, DocumentosSGIId, "DocumentosSGIPorCarpeta", "")
        End Try

    End Function
    Public Function LoadEditarRaicesCarpeta(ByRef CodigoHTML As String, ByVal DocumentosSGIId As Long, ByVal UserId As Long, ByVal CarpetaRaiz As String, ByVal IsAuthorizedUser As Boolean) As String
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim t As Boolean
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;"
        Dim Carpetas As New Carpetas
        Dim l As String = ""

        Dim UrlEditarCarpeta As String = "*"
        Dim UrlCrearSubCarpeta As String = "*"

        'sSQL = "SELECT CarpetasId As PId, CarpetasName As Carpeta, CarpetasDescription As Descripcion "
        'sSQL = sSQL & "FROM Carpetas "
        'sSQL = sSQL & "WHERE CarpetasPId = " & Carpetas.LeerCarpetaIdByName(CarpetaRaiz) & " "
        'sSQL = sSQL & "ORDER by Carpetas.CarpetasSecuencia"

        sSQL = "SELECT CarpetasId As PId, CarpetasName As Carpeta, CarpetasDescription As Descripcion "
        sSQL = sSQL & "FROM Carpetas "
        sSQL = sSQL & "WHERE CarpetasName = '" & CarpetaRaiz & "' "
        sSQL = sSQL & "ORDER by Carpetas.CarpetasSecuencia"

        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""vinculo_carpeta"">"
        CodigoHTML = CodigoHTML & "<tr><th width=""300"" align=""left"">Carpetas</th><th width=""300"" align=""left"">Descripción</th><th width=""68"" align=""center"">Editar</th></tr>"
        LoadEditarRaicesCarpeta = ""
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read
                If CarpetaRaiz = "Carpeta General" Then
                    UrlEditarCarpeta = "IndexSGI.aspx?PaginaWebName=Ficha de Carpetas&MenuOptionsId=503&Carpeta=" & CarpetaRaiz & "&Id=" & dtrFunciones("Pid").ToString
                Else
                    UrlEditarCarpeta = "IndexSGI.aspx?PaginaWebName=Ficha de Carpetas&MenuOptionsId=509&Carpeta=" & CarpetaRaiz & "&Id=" & dtrFunciones("Pid").ToString
                End If
                l = "<a href=""" & UrlEditarCarpeta & """><img src=""img/editar.png"" alt=""Editar Carpeta"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Editar Descripción y Posición y Asociar Archivos"" /></a>"
                CodigoHTML = CodigoHTML & "<tr>"
                If IsAuthorizedUser = True Then
                    CodigoHTML = CodigoHTML & "<td width=""240"" align=""left"">" & dtrFunciones("Carpeta").ToString & "</td><td width=""240"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""68"" align=""center"">" & l & "</td>"
                Else
                    CodigoHTML = CodigoHTML & "<td width=""240"" align=""left"">" & dtrFunciones("Carpeta").ToString & "</td><td width=""240"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""68"" align=""center""></td>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                t = Carpetas.LoadEditarNodosCarpetas(CLng(dtrFunciones("PId").ToString), CodigoHTML, DocumentosSGIId, UserId, Espacios, IsAuthorizedUser, CarpetaRaiz)
            End While
            dtrFunciones.Close()
        Catch
            LoadEditarRaicesCarpeta = ""
        End Try
        LoadEditarRaicesCarpeta = CodigoHTML & "</table>"
    End Function
    Public Function LoadEditarNodosCarpetas(ByVal CarpetasPId As Long, ByRef CodigoHTML As String, ByVal DocumentosSGIId As Long, ByVal UserId As Long, ByVal Espacios As String, ByVal IsAuthorizedUser As Boolean, ByVal CarpetaRaiz As String) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim Carpetas As New Carpetas
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim t As Boolean
        Dim EspacioMasAbajo As String = Espacios & "&nbsp;&nbsp;&nbsp;"
        Dim l As String = ""
        Dim m As String = ""
        Dim UrlEditarCarpeta As String = "*"
        Dim UrlCrearSubCarpeta As String = "*"


        sSQL = "SELECT CarpetasId As PId, CarpetasName As Carpeta, CarpetasDescription As Descripcion "
        sSQL = sSQL & "FROM Carpetas "
        sSQL = sSQL & "WHERE CarpetasPId = " & CarpetasPId
        sSQL = sSQL & " ORDER by Carpetas.CarpetasSecuencia"
        LoadEditarNodosCarpetas = False
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)
            While dtrFunciones.Read
                If CarpetaRaiz = "Carpeta General" Then
                    UrlEditarCarpeta = "IndexSGI.aspx?PaginaWebName=Ficha de Carpetas&MenuOptionsId=503&Carpeta=" & CarpetaRaiz & "&Id=" & dtrFunciones("Pid").ToString
                Else
                    UrlEditarCarpeta = "IndexSGI.aspx?PaginaWebName=Ficha de Carpetas&MenuOptionsId=509&Carpeta=" & CarpetaRaiz & "&Id=" & dtrFunciones("Pid").ToString
                End If
                l = "<a href=""" & UrlCrearSubCarpeta & """><img src=""img/WebResource2.gif"" alt=""Crear Subcarpeta"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Crear Subcarpeta"" /></a>"
                m = "<a href=""" & UrlEditarCarpeta & """><img src=""img/editar.png"" alt=""Editar Carpeta"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Editar Descripción y Posición y Asociar Archivos"" /></a>"
                CodigoHTML = CodigoHTML & "<tr>"
                If IsAuthorizedUser Then
                    CodigoHTML = CodigoHTML & "<td width=""300"" align=""left"">" & Espacios & dtrFunciones("Carpeta").ToString & "</td><td width=""300"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""68"" align=""center"">" & m & "</td>"
                Else
                    CodigoHTML = CodigoHTML & "<td width=""300"" align=""left"">" & Espacios & dtrFunciones("Carpeta").ToString & "</td><td width=""300"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""68"" align=""center""></td>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                t = Carpetas.LoadEditarNodosCarpetas(CLng(dtrFunciones("PId").ToString), CodigoHTML, DocumentosSGIId, UserId, EspacioMasAbajo, IsAuthorizedUser, CarpetaRaiz)
                LoadEditarNodosCarpetas = True
            End While
            dtrFunciones.Close()
        Catch
            LoadEditarNodosCarpetas = False
        End Try
    End Function
End Class
