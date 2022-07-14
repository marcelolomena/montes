Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class CarpetaJudicialDocs
    Public Function LeerCarpetaJudicialDocs(ByVal CarpetaJudicialDocsId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialDocsSecuencia As Long, ByRef CarpetaJudicialDocsCodigo As String, ByRef CarpetaJudicialDocsNombre As String, ByRef CarpetaJudicialDocsDescription As String, ByRef CarpetaJudicialDocsPath As String, ByRef CarpetaJudicialPlantillaCodigo As String, ByRef AreasName As String, ByRef EmpresasCodigo As String, ByRef ContratoCodigo As String, ByRef CarpetaJudicialDocsFEmision As Date, ByRef UsuariosCodigo As String, ByRef CarpetaJudicialDocsObservaciones As String, ByRef CarpetaJudicialDocsResponsableArea As String, ByRef CarpetaJudicialDocsCargoResponsable As String, ByRef TipoDocName As String, ByRef CarpetaJudicialDocsIsAdjunto As Boolean, ByRef CarpetaJudicialDocsIsAvailable As Boolean, ByRef CarpetaJudicialDocsCorreoResponsable As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialCodigo, CarpetaJudicialDocsSecuencia, CarpetaJudicialDocsCodigo, CarpetaJudicialDocsNombre, CarpetaJudicialDocsDescription, CarpetaJudicialDocsPath, CarpetaJudicialPlantillaCodigo, AreasName, EmpresasCodigo, ContratoCodigo, CarpetaJudicialDocsFEmision, UsuariosCodigo, CarpetaJudicialDocsObservaciones, CarpetaJudicialDocsResponsableArea, CarpetaJudicialDocsCargoResponsable, TipoDocName, CarpetaJudicialDocsIsAdjunto, CarpetaJudicialDocsIsAvailable, CarpetaJudicialDocsCorreoResponsable "
        sSQL = sSQL & "FROM CarpetaJudicialDocs "
        sSQL = sSQL & "WHERE CarpetaJudicialDocs.CarpetaJudicialDocsId = " & CarpetaJudicialDocsId
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CarpetaJudicialCodigo = CStr(dtr("CarpetaJudicialCodigo").ToString)
                If Len(dtr("CarpetaJudicialDocsSecuencia").ToString) = 0 Then
                    CarpetaJudicialDocsSecuencia = 0
                Else
                    CarpetaJudicialDocsSecuencia = CLng(dtr("CarpetaJudicialDocsSecuencia").ToString)
                End If
                CarpetaJudicialDocsCodigo = CStr(dtr("CarpetaJudicialDocsCodigo").ToString)
                CarpetaJudicialDocsNombre = CStr(dtr("CarpetaJudicialDocsNombre").ToString)
                CarpetaJudicialDocsDescription = CStr(dtr("CarpetaJudicialDocsDescription").ToString)
                CarpetaJudicialDocsPath = CStr(dtr("CarpetaJudicialDocsPath").ToString)
                CarpetaJudicialPlantillaCodigo = CStr(dtr("CarpetaJudicialPlantillaCodigo").ToString)
                AreasName = CStr(dtr("AreasName").ToString)
                EmpresasCodigo = CStr(dtr("EmpresasCodigo").ToString)
                ContratoCodigo = CStr(dtr("ContratoCodigo").ToString)
                If Len(dtr("CarpetaJudicialDocsFEmision").ToString) = 0 Then
                    CarpetaJudicialDocsFEmision = "01/01/01"
                Else
                    CarpetaJudicialDocsFEmision = CDate(dtr("CarpetaJudicialDocsFEmision").ToString)
                End If
                UsuariosCodigo = CStr(dtr("UsuariosCodigo").ToString)
                CarpetaJudicialDocsObservaciones = CStr(dtr("CarpetaJudicialDocsObservaciones").ToString)
                CarpetaJudicialDocsResponsableArea = CStr(dtr("CarpetaJudicialDocsResponsableArea").ToString)
                CarpetaJudicialDocsCargoResponsable = CStr(dtr("CarpetaJudicialDocsCargoResponsable").ToString)
                TipoDocName = CStr(dtr("TipoDocName").ToString)
                CarpetaJudicialDocsCorreoResponsable = CStr(dtr("CarpetaJudicialDocsCorreoResponsable").ToString)
                CarpetaJudicialDocsIsAdjunto = CBool(dtr("CarpetaJudicialDocsIsAdjunto").ToString)
                CarpetaJudicialDocsIsAvailable = CBool(dtr("CarpetaJudicialDocsIsAvailable").ToString)
            End While
            LeerCarpetaJudicialDocs = True
            dtr.Close()
        Catch
            LeerCarpetaJudicialDocs = False
        End Try
    End Function
    Public Function CarpetaJudicialDocsUpdate(ByVal CarpetaJudicialDocsId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialDocsSecuencia As Long, ByRef CarpetaJudicialDocsCodigo As String, ByRef CarpetaJudicialDocsNombre As String, ByRef CarpetaJudicialDocsDescription As String, ByRef CarpetaJudicialDocsPath As String, ByRef CarpetaJudicialPlantillaCodigo As String, ByRef AreasName As String, ByRef EmpresasCodigo As String, ByRef ContratoCodigo As String, ByRef CarpetaJudicialDocsFEmision As Date, ByRef UsuariosCodigo As String, ByRef CarpetaJudicialDocsObservaciones As String, ByRef CarpetaJudicialDocsResponsableArea As String, ByRef CarpetaJudicialDocsCargoResponsable As String, ByRef TipoDocName As String, ByRef CarpetaJudicialDocsIsAdjunto As Boolean, ByRef CarpetaJudicialDocsIsAvailable As Boolean, ByRef CarpetaJudicialDocsCorreoResponsable As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim Tareas As New Tareas
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim t As Integer = 0
        Dim TareasId As Long = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
        Dim TareasCodigo As String = ""
        Dim b As Boolean

        b = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)
        Dim UserIdCodigo As String = ""
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(TareasId)
        Dim TareasLogActividad As String = ""

        TareasLogActividad = "Upload de Archivo: " & CarpetaJudicialDocsPath
        TareasLogActividad = TareasLogActividad & "; T&iacute;tulo: " & CarpetaJudicialDocsNombre & "; Stakeholder: " & EmpresasCodigo

        strUpdate = "UPDATE CarpetaJudicialDocs SET "
        strUpdate = strUpdate & "CarpetaJudicialDocs.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.CarpetaJudicialDocsSecuencia = " & CarpetaJudicialDocsSecuencia & ", "
        strUpdate = strUpdate & "CarpetaJudicialDocs.CarpetaJudicialDocsCodigo = '" & CarpetaJudicialDocsCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.CarpetaJudicialDocsNombre = '" & CarpetaJudicialDocsNombre & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.CarpetaJudicialDocsDescription = '" & CarpetaJudicialDocsDescription & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.CarpetaJudicialDocsPath = '" & CarpetaJudicialDocsPath & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.CarpetaJudicialPlantillaCodigo = '" & CarpetaJudicialPlantillaCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.AreasName = '" & AreasName & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.EmpresasCodigo = '" & EmpresasCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.ContratoCodigo = '" & ContratoCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.CarpetaJudicialDocsFEmision = '" & AccionesABM.DateTransform(CarpetaJudicialDocsFEmision) & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.UsuariosCodigo = '" & UsuariosCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.CarpetaJudicialDocsObservaciones = '" & CarpetaJudicialDocsObservaciones & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.CarpetaJudicialDocsResponsableArea = '" & CarpetaJudicialDocsResponsableArea & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.CarpetaJudicialDocsCargoResponsable = '" & CarpetaJudicialDocsCargoResponsable & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.TipoDocName = '" & TipoDocName & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.CarpetaJudicialDocsIsAdjunto = " & CBool(CarpetaJudicialDocsIsAdjunto) & ", "
        strUpdate = strUpdate & "CarpetaJudicialDocs.CarpetaJudicialDocsIsAvailable = " & CBool(CarpetaJudicialDocsIsAvailable) & ", "
        strUpdate = strUpdate & "CarpetaJudicialDocs.CarpetaJudicialDocsCorreoResponsable = '" & CarpetaJudicialDocsCorreoResponsable & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicialDocs.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicialDocs.CarpetaJudicialDocsId = " & CarpetaJudicialDocsId
        Try
            CarpetaJudicialDocsUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & CarpetaJudicialCodigo, CarpetaJudicialDocsId, "CarpetaJudicialDocs", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CarpetaJudicialDocsUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & CarpetaJudicialCodigo, CarpetaJudicialDocsId, "CarpetaJudicialDocs", "")
        End Try
    End Function
    Public Function CarpetaJudicialDocsInsert(ByRef CarpetaJudicialDocsId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialDocsSecuencia As Long, ByRef CarpetaJudicialDocsCodigo As String, ByRef CarpetaJudicialDocsNombre As String, ByRef CarpetaJudicialDocsDescription As String, ByRef CarpetaJudicialDocsPath As String, ByRef CarpetaJudicialPlantillaCodigo As String, ByRef AreasName As String, ByRef EmpresasCodigo As String, ByRef ContratoCodigo As String, ByRef CarpetaJudicialDocsFEmision As Date, ByRef UsuariosCodigo As String, ByRef CarpetaJudicialDocsObservaciones As String, ByRef CarpetaJudicialDocsResponsableArea As String, ByRef CarpetaJudicialDocsCargoResponsable As String, ByRef TipoDocName As String, ByRef CarpetaJudicialDocsIsAdjunto As Boolean, ByRef CarpetaJudicialDocsIsAvailable As Boolean, ByRef CarpetaJudicialDocsCorreoResponsable As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim CarpetaJudicialDocs As New CarpetaJudicialDocs
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = CarpetaJudicialCodigo
            DetailSecuencia = CarpetaJudicialDocsSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("CarpetaJudicialDocsId", "CarpetaJudicialCodigo", "CarpetaJudicialDocsSecuencia", "CarpetaJudicialDocs", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("CarpetaJudicialDocsId", "CarpetaJudicialCodigo", "CarpetaJudicialDocsSecuencia", "CarpetaJudicialDocs", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            CarpetaJudicialDocsInsert = CarpetaJudicialDocs.CarpetaJudicialDocsUpdate(DetailId, CStr(CarpetaJudicialCodigo), CLng(CarpetaJudicialDocsSecuencia), CStr(CarpetaJudicialDocsCodigo), CStr(CarpetaJudicialDocsNombre), CStr(CarpetaJudicialDocsDescription), CStr(CarpetaJudicialDocsPath), CStr(CarpetaJudicialPlantillaCodigo), CStr(AreasName), CStr(EmpresasCodigo), CStr(ContratoCodigo), CDate(CarpetaJudicialDocsFEmision), CStr(UsuariosCodigo), CStr(CarpetaJudicialDocsObservaciones), CStr(CarpetaJudicialDocsResponsableArea), CStr(CarpetaJudicialDocsCargoResponsable), CStr(TipoDocName), CBool(CarpetaJudicialDocsIsAdjunto), CBool(CarpetaJudicialDocsIsAvailable), CStr(CarpetaJudicialDocsCorreoResponsable), UserId)
        Catch
            CarpetaJudicialDocsInsert = 0
        End Try
    End Function
    Public Function LeerCarpetaJudicialDocsPaths(ByVal CarpetaJudicialDocsId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim CarpetaJudicialDocsPath As String = ""

        sSQL = "Select CarpetaJudicialDocsPath "
        sSQL = sSQL & "FROM CarpetaJudicialDocs "
        sSQL = sSQL & "WHERE CarpetaJudicialDocs.CarpetaJudicialDocsId = " & CarpetaJudicialDocsId
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CarpetaJudicialDocsPath = CStr(dtr("CarpetaJudicialDocsPath").ToString)
            End While
            LeerCarpetaJudicialDocsPaths = CarpetaJudicialDocsPath
            dtr.Close()
        Catch
            LeerCarpetaJudicialDocsPaths = CarpetaJudicialDocsPath
        End Try
    End Function
    Public Function LeerCarpetaJudicialDocsNombre(ByVal CarpetaJudicialDocsId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim CarpetaJudicialDocsNombre As String = ""

        sSQL = "Select CarpetaJudicialDocsNombre "
        sSQL = sSQL & "FROM CarpetaJudicialDocs "
        sSQL = sSQL & "WHERE CarpetaJudicialDocs.CarpetaJudicialDocsId = " & CarpetaJudicialDocsId
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CarpetaJudicialDocsNombre = CStr(dtr("CarpetaJudicialDocsNombre").ToString)
            End While
            LeerCarpetaJudicialDocsNombre = CarpetaJudicialDocsNombre
            dtr.Close()
        Catch
            LeerCarpetaJudicialDocsNombre = CarpetaJudicialDocsNombre
        End Try
    End Function

    Public Function CarpetaJudicialDocsDelete(ByVal CarpetaJudicialDocsId As Long, ByVal CarpetaJudicialCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer

        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim Tareas As New Tareas
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim CarpetaJudicialDocs As New CarpetaJudicialDocs
        Dim CarpetaJudicialDocsPath As String = CarpetaJudicialDocs.LeerCarpetaJudicialDocsPaths(CarpetaJudicialDocsId)
        Dim CarpetaJudicialDocsNombre As String = CarpetaJudicialDocs.LeerCarpetaJudicialDocsNombre(CarpetaJudicialDocsId)
        Dim TareasId As Long = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
        Dim TareasCodigo As String = ""
        Dim b As Boolean

        b = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)
        Dim UserIdCodigo As String = ""
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(TareasId)
        Dim TareasLogActividad As String = ""

        TareasLogActividad = "Elimina Archivo: " & CarpetaJudicialDocsPath
        TareasLogActividad = TareasLogActividad & "; T&iacute;tulo: " & CarpetaJudicialDocsNombre

        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (CarpetaJudicialDocs) "
        strUpdate = strUpdate & "WHERE (CarpetaJudicialDocs.CarpetaJudicialDocsId = " & CarpetaJudicialDocsId & ") "
        Try
            CarpetaJudicialDocsDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Documento asociada a la Carpeta: " & CarpetaJudicialCodigo, CarpetaJudicialDocsId, "CarpetaJudicialDocs", "")
            t = AccionesABM.TareasLogInsert(CarpetaJudicialCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)

        Catch
            CarpetaJudicialDocsDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar Documento asociada a la Carpeta: " & CarpetaJudicialCodigo, CarpetaJudicialDocsId, "CarpetaJudicialDocs", "")
        End Try
    End Function
    Public Function LeerLosDocumentos(ByVal CarpetaJudicialCodigo As String, ByVal Accion As Integer) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String = ""
        Dim CarpetaJudicial As New CarpetaJudicial

        LeerLosDocumentos = ""
        Select Case Accion
            Case 1

                strUpdate = "SELECT CarpetaJudicialDocs.CarpetaJudicialDocsNombre as Titulo "
                strUpdate = strUpdate & "FROM CarpetaJudicialDocs "
                strUpdate = strUpdate & "WHERE (((CarpetaJudicialDocs.CarpetaJudicialCodigo)='" & CarpetaJudicialCodigo & "'))"

                Try
                    dtr = AccesoEA.ListarRegistros(strUpdate)
                    While dtr.Read
                        CodigoHTML = CodigoHTML & "<p>" & dtr("Titulo").ToString & "</p>"
                    End While
                    dtr.Close()
                Catch
                    CodigoHTML = ""
                End Try
        End Select
        LeerLosDocumentos = CodigoHTML
    End Function
    Public Function ListarDocs(ByVal CarpetaJudicialCodigo As String, Optional ByVal Clase As String = "invisible", Optional ByVal Formato As String = "CodigoHTML") As String
        Dim CodigoHTML As String = ""
        Dim CarpetaJudicialDocs As New CarpetaJudicialDocs
        Dim Direcciones(15) As String
        Dim NumeroDirecciones As Integer = CarpetaJudicialDocs.LeerDatosDocs(CarpetaJudicialCodigo, Direcciones, Formato)
        Dim i As Integer
        ListarDocs = ""

        If NumeroDirecciones > 0 Then

            If Formato = "CodigoHTML" Then
                CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td><h1>" & "Documentos adjuntos a la carpeta del deudor" & "</h1></td>"
                CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & "Docs" & "')"" /></td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "</table>"
                CodigoHTML = CodigoHTML & "<div id=""subgrilla" & "Docs" & """ class=""" & Clase & """>"
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

        ListarDocs = CodigoHTML
    End Function
    Public Function LeerDatosDocs(ByVal CarpetaJudicialCodigo As String, ByRef Direcciones() As String, Optional ByVal Formato As String = "CodigoHTML") As Integer

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim CarpetaJudicialDocs As New CarpetaJudicialDocs

        sSQL = "Select CarpetaJudicialDocsId as Id, CarpetaJudicialDocsNombre As Nombre, CarpetaJudicialDocsDescription As Descripcion, 'SGI\' + CarpetaJudicialDocsPath as Path, CarpetaJudicialDocsFEmision As Fecha, TipoDocName As Tipo "
        sSQL = sSQL & "FROM CarpetaJudicialDocs "
        sSQL = sSQL & "WHERE CarpetaJudicialDocs.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' "
        sSQL = sSQL & "ORDER BY CarpetaJudicialDocs.CarpetaJudicialDocsSecuencia"

        Dim CodigoHTML As String = ""

        LeerDatosDocs = 0

        Direcciones(0) = "<tr><th align=""left"">Nombre</th><th align=""left"">Descripción</th><th align=""left"">Fecha</th><th align=""left"">Tipo</th><th align=""left"">Operaciones</th></tr>"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If Formato = "CodigoHTML" Then
                    Direcciones(i) = "<tr><td>" & "<a href=""" & dtr("Path").ToString & """ target=""_blank"">" & dtr("Nombre").ToString & "</a></td><td>" & dtr("Descripcion").ToString & "</td><td>" & FormatDateTime(dtr("Fecha").ToString, DateFormat.ShortDate) & "</td><td>" & dtr("Tipo").ToString & "</td>"
                Else
                    Direcciones(i) = "<tr><td>" & dtr("Nombre").ToString & "</td><td>" & dtr("Descripcion").ToString & "</td><td>" & FormatDateTime(dtr("Fecha").ToString, DateFormat.ShortDate) & "</td><td>" & dtr("Tipo").ToString & "</td>"
                End If
                Direcciones(i) = Direcciones(i) & "<td>" & CarpetaJudicialDocs.LeerOperacionesPorDocs(CLng(dtr("Id").ToString)) & "</td></tr>"
            End While
            dtr.Close()
        Catch
            LeerDatosDocs = 0
        End Try


        LeerDatosDocs = i

    End Function

    Public Function LeerOperacionesPorDocs(ByVal CarpetaJudicialDocsId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0

        sSQL = "Select CarpetaJudicialCreditos.CarpetaJudicialCreditosNroOperacion As Operacion "
        sSQL = sSQL & "FROM CarpetaJudicialDocsPorCarpetaJudicialCreditos INNER JOIN CarpetaJudicialCreditos ON CarpetaJudicialDocsPorCarpetaJudicialCreditos.CarpetaJudicialCreditosId = CarpetaJudicialCreditos.CarpetaJudicialCreditosId "
        sSQL = sSQL & "WHERE (((CarpetaJudicialDocsPorCarpetaJudicialCreditos.CarpetaJudicialDocsId)=" & CarpetaJudicialDocsId & "))"

        Dim CodigoHTML As String = ""

        LeerOperacionesPorDocs = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CodigoHTML = CodigoHTML & dtr("Operacion").ToString & "</br>"
            End While
            dtr.Close()
        Catch
            LeerOperacionesPorDocs = ""
        End Try

        LeerOperacionesPorDocs = CodigoHTML

    End Function


End Class
