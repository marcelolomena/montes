'------------------------------------------------------------
' Código generado por ZRISMART SF el 01-12-2010 19:20:59
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class DocumentosSGI
    Public Function LeerDocumentosSGI(ByVal DocumentosSGIId As Long, ByRef DocumentosSGICodigo As String, ByRef DocumentosSGINombre As String, ByRef DocumentosSGIDescription As String, ByRef DocumentosSGIPath As String, ByRef DocumentosSGIOrigen As String, ByRef DocumentosSGITipo As String, ByRef DocumentosSGIFEmision As Date, ByRef DocumentosSGIFRevision As String, ByRef DocumentosSGIArea As String, ByRef DocumentosSGIResponsable As String, ByRef DocumentosSGIEmpresa As String, ByRef DocumentosSGIContrato As String, ByRef DocumentosSGIPalabrasClaves As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select DocumentosSGICodigo, DocumentosSGINombre, DocumentosSGIDescription, DocumentosSGIPath, DocumentosSGIOrigen, DocumentosSGITipo, DocumentosSGIFEmision, DocumentosSGIFRevision, DocumentosSGIArea, DocumentosSGIResponsable, DocumentosSGIEmpresa, DocumentosSGIContrato, DocumentosSGIPalabrasClaves "
        sSQL = sSQL & "FROM (DocumentosSGI) "
        sSQL = sSQL & "WHERE (DocumentosSGI.DocumentosSGIId = " & DocumentosSGIId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                DocumentosSGICodigo = CStr(dtr("DocumentosSGICodigo").ToString)
                DocumentosSGINombre = CStr(dtr("DocumentosSGINombre").ToString)
                DocumentosSGIDescription = CStr(dtr("DocumentosSGIDescription").ToString)
                DocumentosSGIPath = CStr(dtr("DocumentosSGIPath").ToString)
                DocumentosSGIOrigen = CStr(dtr("DocumentosSGIOrigen").ToString)
                DocumentosSGITipo = CStr(dtr("DocumentosSGITipo").ToString)
                If Len(dtr("DocumentosSGIFEmision").ToString) = 0 Then
                    DocumentosSGIFEmision = "01/01/01"
                Else
                    DocumentosSGIFEmision = CDate(dtr("DocumentosSGIFEmision").ToString)
                End If
                DocumentosSGIFRevision = CStr(dtr("DocumentosSGIFRevision").ToString)
                DocumentosSGIArea = CStr(dtr("DocumentosSGIArea").ToString)
                DocumentosSGIResponsable = CStr(dtr("DocumentosSGIResponsable").ToString)
                DocumentosSGIEmpresa = CStr(dtr("DocumentosSGIEmpresa").ToString)
                DocumentosSGIContrato = CStr(dtr("DocumentosSGIContrato").ToString)
                DocumentosSGIPalabrasClaves = CStr(dtr("DocumentosSGIPalabrasClaves").ToString)
            End While
            LeerDocumentosSGI = True
            dtr.Close()
        Catch
            LeerDocumentosSGI = False
        End Try
    End Function
    Public Function LeerDocumentosSGIByName(ByRef DocumentosSGIId As Long, ByVal DocumentosSGICodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select DocumentosSGIId "
        sSQL = sSQL & "FROM (DocumentosSGI) "
        sSQL = sSQL & "WHERE (DocumentosSGI.DocumentosSGICodigo = '" & DocumentosSGICodigo & "') "
        DocumentosSGIId = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                DocumentosSGIId = CLng(dtr("DocumentosSGIId").ToString)
                LeerDocumentosSGIByName = True
            End While
            dtr.Close()
        Catch
            LeerDocumentosSGIByName = False
        End Try
    End Function
    Public Function DocumentosSGIUpdate(ByVal DocumentosSGIId As Long, ByRef DocumentosSGICodigo As String, ByRef DocumentosSGINombre As String, ByRef DocumentosSGIDescription As String, ByRef DocumentosSGIPath As String, ByRef DocumentosSGIOrigen As String, ByRef DocumentosSGITipo As String, ByRef DocumentosSGIFEmision As Date, ByRef DocumentosSGIFRevision As String, ByRef DocumentosSGIArea As String, ByRef DocumentosSGIResponsable As String, ByRef DocumentosSGIEmpresa As String, ByRef DocumentosSGIContrato As String, ByRef DocumentosSGIPalabrasClaves As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE DocumentosSGI SET "
        strUpdate = strUpdate & "DocumentosSGI.DocumentosSGICodigo = '" & DocumentosSGICodigo & "', "
        strUpdate = strUpdate & "DocumentosSGI.DocumentosSGINombre = '" & DocumentosSGINombre & "', "
        strUpdate = strUpdate & "DocumentosSGI.DocumentosSGIDescription = '" & DocumentosSGIDescription & "', "
        strUpdate = strUpdate & "DocumentosSGI.DocumentosSGIPath = '" & DocumentosSGIPath & "', "
        strUpdate = strUpdate & "DocumentosSGI.DocumentosSGIOrigen = '" & DocumentosSGIOrigen & "', "
        strUpdate = strUpdate & "DocumentosSGI.DocumentosSGITipo = '" & DocumentosSGITipo & "', "
        strUpdate = strUpdate & "DocumentosSGI.DocumentosSGIFEmision = '" & AccionesABM.DateTransform(DocumentosSGIFEmision) & "', "
        strUpdate = strUpdate & "DocumentosSGI.DocumentosSGIFRevision = '" & DocumentosSGIFRevision & "', "
        strUpdate = strUpdate & "DocumentosSGI.DocumentosSGIArea = '" & DocumentosSGIArea & "', "
        strUpdate = strUpdate & "DocumentosSGI.DocumentosSGIResponsable = '" & DocumentosSGIResponsable & "', "
        strUpdate = strUpdate & "DocumentosSGI.DocumentosSGIEmpresa = '" & DocumentosSGIEmpresa & "', "
        strUpdate = strUpdate & "DocumentosSGI.DocumentosSGIContrato = '" & DocumentosSGIContrato & "', "
        strUpdate = strUpdate & "DocumentosSGI.DocumentosSGIPalabrasClaves = '" & DocumentosSGIPalabrasClaves & "', "
        strUpdate = strUpdate & "DocumentosSGI.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "DocumentosSGI.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE DocumentosSGI.DocumentosSGIId = " & DocumentosSGIId
        Try
            DocumentosSGIUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & DocumentosSGICodigo, DocumentosSGIId, "DocumentosSGI", "")
        Catch
            DocumentosSGIUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & DocumentosSGICodigo, DocumentosSGIId, "DocumentosSGI", "")
        End Try
    End Function
    Public Function DocumentosSGIInsert(ByRef DocumentosSGIId As Long, ByRef DocumentosSGICodigo As String, ByRef DocumentosSGINombre As String, ByRef DocumentosSGIDescription As String, ByRef DocumentosSGIPath As String, ByRef DocumentosSGIOrigen As String, ByRef DocumentosSGITipo As String, ByRef DocumentosSGIFEmision As Date, ByRef DocumentosSGIFRevision As String, ByRef DocumentosSGIArea As String, ByRef DocumentosSGIResponsable As String, ByRef DocumentosSGIEmpresa As String, ByRef DocumentosSGIContrato As String, ByRef DocumentosSGIPalabrasClaves As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim DocumentosSGI As New DocumentosSGI
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = DocumentosSGICodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("DocumentosSGIId", "DocumentosSGICodigo", "DocumentosSGI", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("DocumentosSGIId", "DocumentosSGICodigo", "DocumentosSGI", MasterName, CLng(UserId), MasterId)
            End If
            DocumentosSGIInsert = DocumentosSGI.DocumentosSGIUpdate(MasterId, CStr(DocumentosSGICodigo), CStr(DocumentosSGINombre), CStr(DocumentosSGIDescription), CStr(DocumentosSGIPath), CStr(DocumentosSGIOrigen), CStr(DocumentosSGITipo), CDate(DocumentosSGIFEmision), CStr(DocumentosSGIFRevision), CStr(DocumentosSGIArea), CStr(DocumentosSGIResponsable), CStr(DocumentosSGIEmpresa), CStr(DocumentosSGIContrato), CStr(DocumentosSGIPalabrasClaves), UserId)
        Catch
            DocumentosSGIInsert = 0
        End Try
    End Function
    Public Function TituloDocumentosSGIByCodigo(ByVal DocumentosSGICodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select DocumentosSGINombre "
        sSQL = sSQL & "FROM (DocumentosSGI) "
        sSQL = sSQL & "WHERE (DocumentosSGI.DocumentosSGICodigo = '" & DocumentosSGICodigo & "') "
        TituloDocumentosSGIByCodigo = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TituloDocumentosSGIByCodigo = dtr("DocumentosSGINombre").ToString
            End While
            dtr.Close()
        Catch
            TituloDocumentosSGIByCodigo = ""
        End Try
    End Function
    Public Function LeerTituloParaAutocomplete(ByRef ArrChartData() As String, ByVal Filtro As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT distinct DocumentosSGI.[DocumentosSGINombre] AS Titulo "
        sSQL = sSQL & "FROM (DocumentosSGI) "
        sSQL = sSQL & "WHERE (((DocumentosSGI.DocumentosSGINombre) LIKE ('%" & Filtro & "%')))"

        i = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("Titulo").ToString
                i = i + 1
            End While
            LeerTituloParaAutocomplete = True
            dtr.Close()
        Catch
            LeerTituloParaAutocomplete = False
        End Try
    End Function
    Public Function LeerPalabrasClavesParaBusqueda(ByRef ArrChartData() As String, ByVal Filtro As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT distinct DocumentosSGI.[DocumentosSGINombre] AS Titulo "
        sSQL = sSQL & "FROM (DocumentosSGI) "
        sSQL = sSQL & "WHERE (((DocumentosSGI.DocumentosSGIPalabrasClaves) LIKE ('%" & Filtro & "%')))"
        i = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrChartData(i) = dtr("Titulo").ToString
                i = i + 1
            End While
            LeerPalabrasClavesParaBusqueda = True
            dtr.Close()
        Catch
            LeerPalabrasClavesParaBusqueda = False
        End Try
    End Function
    Public Function LeerDocumentosSGIDescriptionByName(ByVal DocumentosSGICodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select DocumentosSGINombre "
        sSQL = sSQL & "FROM (DocumentosSGI) "
        sSQL = sSQL & "WHERE (DocumentosSGI.DocumentosSGICodigo = '" & DocumentosSGICodigo & "') "
        LeerDocumentosSGIDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerDocumentosSGIDescriptionByName = CStr(dtr("DocumentosSGINombre").ToString)
            End While
            dtr.Close()
        Catch
            LeerDocumentosSGIDescriptionByName = ""
        End Try
    End Function
    Public Function DocumentosSGIDelete(ByVal DocumentosSGIId As Long, ByVal DocumentosSGICodigo As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        ' Borra registro de la tabla de documentos
        '------------------------------------------
        strUpdate = "DELETE FROM DocumentosSGI WHERE DocumentosSGIId = " & DocumentosSGIId
        Try
            DocumentosSGIDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina un documento del SGI: " & DocumentosSGICodigo, DocumentosSGIId, "DocumentosSGI", "")
        Catch
            DocumentosSGIDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar un documento del SGI: " & DocumentosSGICodigo, DocumentosSGIId, "DocumentosSGI", "")
        End Try

        ' Borra registro de la tabla de vinculos del documento con los requisitos de la norma
        '-------------------------------------------------------------------------------------
        strUpdate = "DELETE FROM APIDocumentosSGI WHERE DocumentosSGICodigo = '" & DocumentosSGICodigo & "'"

        Try
            DocumentosSGIDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina vínculos del documento: " & DocumentosSGICodigo, DocumentosSGIId, "APIDocumentosSGI", "")
        Catch
            DocumentosSGIDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar vínculos del documento: " & DocumentosSGICodigo, DocumentosSGIId, "APIDocumentosSGI", "")
        End Try

        ' Borra registro de la tabla de documentos deprecados
        '-----------------------------------------------------
        strUpdate = "DELETE FROM DeprecadosDocumentosSGI WHERE DocumentosSGICodigo = '" & DocumentosSGICodigo & "'"

        Try
            DocumentosSGIDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina todos los documentos obsoletos del documento: " & DocumentosSGICodigo, DocumentosSGIId, "DeprecadosDocumentosSGI", "")
        Catch
            DocumentosSGIDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar los documentos obsoletos del documento: " & DocumentosSGICodigo, DocumentosSGIId, "DeprecadosDocumentosSGI", "")
        End Try

        ' Borra registro de la tabla de documentos deprecados
        '-----------------------------------------------------
        strUpdate = "DELETE FROM NotasDocumentosSGI WHERE DocumentosSGICodigo = '" & DocumentosSGICodigo & "'"

        Try
            DocumentosSGIDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina las Notas del documento: " & DocumentosSGICodigo, DocumentosSGIId, "NotasDocumentosSGI", "")
        Catch
            DocumentosSGIDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar las notas del documento: " & DocumentosSGICodigo, DocumentosSGIId, "NotasDocumentosSGI", "")
        End Try

        ' Borra registro de la tabla de formularios asociados a acciones de cumplimientos de requisitos de la norma
        '-----------------------------------------------------------------------------------------------------------
        strUpdate = "DELETE FROM FormulariosPorAccion WHERE DocumentosSGIId = " & DocumentosSGIId

        Try
            DocumentosSGIDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina vínculos del documento: " & DocumentosSGICodigo & " a acciones de cumplimiento de requisitos", DocumentosSGIId, "FormulariosPorAccion", "")
        Catch
            DocumentosSGIDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar vínculos del documento: " & DocumentosSGICodigo & " a acciones de cumplimiento de requisitos", DocumentosSGIId, "FormulariosPorAccion", "")
        End Try

    End Function
    Public Function MostrarDocumentosPorPalabraClave(ByVal PalabraClave As String, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim CodigoHTML As String = ""
        Dim dtr As IDataReader
        Dim strUpdate As String
        Dim NotasTransversales As New NotasTransversales


        strUpdate = "SELECT distinct DocumentosSGI.[DocumentosSGINombre] AS Titulo, 'SGI\' + DocumentosSGI.DocumentosSGIPath As Url, Mid(DocumentosSGIFEmision,1,10) as Fecha "
        strUpdate = strUpdate & "FROM (DocumentosSGI) "
        strUpdate = strUpdate & "WHERE (((DocumentosSGI.DocumentosSGIPalabrasClaves) LIKE ('%" & PalabraClave & "%')) OR ((DocumentosSGI.DocumentosSGINombre) LIKE ('%" & PalabraClave & "%')) OR ((DocumentosSGI.DocumentosSGIEmpresa) LIKE ('%" & PalabraClave & "%')))"
        MostrarDocumentosPorPalabraClave = ""
        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""alertas"">"
        CodigoHTML = CodigoHTML & "<tr><th scope=""col"">Documentos con ['" & PalabraClave & "']</th></tr>"
        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                strUpdate = "[" & dtr("Fecha").ToString & "] <a href=""" & dtr("Url").ToString & """ target=""_blank"">" & dtr("Titulo").ToString & "</a>"
                MostrarDocumentosPorPalabraClave = MostrarDocumentosPorPalabraClave & "<tr><td>" & strUpdate & "</td></tr>"
            End While
            dtr.Close()
        Catch
            MostrarDocumentosPorPalabraClave = ""
        End Try
        If Len(MostrarDocumentosPorPalabraClave) = 0 Then
            MostrarDocumentosPorPalabraClave = MostrarDocumentosPorPalabraClave & "<tr><td>No se encontraron documentos con '" & PalabraClave & "'</td></tr>"
        End If
        CodigoHTML = CodigoHTML & MostrarDocumentosPorPalabraClave & "</table>"
        MostrarDocumentosPorPalabraClave = CodigoHTML
    End Function


End Class
