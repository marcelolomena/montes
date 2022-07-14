'------------------------------------------------------------
' Código generado por ZRISMART SF el 20-04-2011 16:43:05
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class TareasDocs
    Public Function LeerTareasDocs(ByVal TareasDocsId As Long, ByRef TareasCodigo As String, ByRef TareasDocsSecuencia As Long, ByRef TareasDocsCodigo As String, ByRef TareasDocsNombre As String, ByRef TareasDocsDescription As String, ByRef TareasDocsPath As String, ByRef TareasPlantillaCodigo As String, ByRef AreasName As String, ByRef EmpresasCodigo As String, ByRef ContratoCodigo As String, ByRef TareasDocsFEmision As Date, ByRef UsuariosCodigo As String, ByRef TareasDocsObservaciones As String, ByRef TareasDocsResponsableArea As String, ByRef TareasDocsCargoResponsable As String, ByRef TipoDocName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TareasCodigo, TareasDocsSecuencia, TareasDocsCodigo, TareasDocsNombre, TareasDocsDescription, TareasDocsPath, TareasPlantillaCodigo, AreasName, EmpresasCodigo, ContratoCodigo, TareasDocsFEmision, UsuariosCodigo, TareasDocsObservaciones, TareasDocsResponsableArea, TareasDocsCargoResponsable, TipoDocName "
        sSQL = sSQL & "FROM (TareasDocs) "
        sSQL = sSQL & "WHERE (TareasDocs.TareasDocsId = " & TareasDocsId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TareasCodigo = CStr(dtr("TareasCodigo").ToString)
                If Len(dtr("TareasDocsSecuencia").ToString) = 0 Then
                    TareasDocsSecuencia = 0
                Else
                    TareasDocsSecuencia = CLng(dtr("TareasDocsSecuencia").ToString)
                End If
                TareasDocsCodigo = CStr(dtr("TareasDocsCodigo").ToString)
                TareasDocsNombre = CStr(dtr("TareasDocsNombre").ToString)
                TareasDocsDescription = CStr(dtr("TareasDocsDescription").ToString)
                TareasDocsPath = CStr(dtr("TareasDocsPath").ToString)
                TareasPlantillaCodigo = CStr(dtr("TareasPlantillaCodigo").ToString)
                AreasName = CStr(dtr("AreasName").ToString)
                EmpresasCodigo = CStr(dtr("EmpresasCodigo").ToString)
                ContratoCodigo = CStr(dtr("ContratoCodigo").ToString)
                If Len(dtr("TareasDocsFEmision").ToString) = 0 Then
                    TareasDocsFEmision = "01/01/01"
                Else
                    TareasDocsFEmision = CDate(dtr("TareasDocsFEmision").ToString)
                End If
                UsuariosCodigo = CStr(dtr("UsuariosCodigo").ToString)
                TareasDocsObservaciones = CStr(dtr("TareasDocsObservaciones").ToString)
                TareasDocsResponsableArea = CStr(dtr("TareasDocsResponsableArea").ToString)
                TareasDocsCargoResponsable = CStr(dtr("TareasDocsCargoResponsable").ToString)
                TipoDocName = CStr(dtr("TipoDocName").ToString)
            End While
            LeerTareasDocs = True
            dtr.Close()
        Catch
            LeerTareasDocs = False
        End Try
    End Function
    Public Function TareasDocsUpdate(ByVal TareasDocsId As Long, ByRef TareasCodigo As String, ByRef TareasDocsSecuencia As Long, ByRef TareasDocsCodigo As String, ByRef TareasDocsNombre As String, ByRef TareasDocsDescription As String, ByRef TareasDocsPath As String, ByRef TareasPlantillaCodigo As String, ByRef AreasName As String, ByRef EmpresasCodigo As String, ByRef ContratoCodigo As String, ByRef TareasDocsFEmision As Date, ByRef UsuariosCodigo As String, ByRef TareasDocsObservaciones As String, ByRef TareasDocsResponsableArea As String, ByRef TareasDocsCargoResponsable As String, ByRef TipoDocName As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim Tareas As New Tareas
        Dim t As Integer = 0
        Dim TareasId As Long = 0
        Dim b As Boolean
        b = Tareas.LeerTareasByName(TareasId, TareasCodigo)
        Dim UserIdCodigo As String = ""
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(TareasId)
        Dim TareasLogActividad As String = ""

        TareasLogActividad = "Upload de Archivo: " & TareasDocsPath
        TareasLogActividad = TareasLogActividad & "; T&iacute;tulo: " & TareasDocsNombre & "; Stakeholder: " & EmpresasCodigo

        strUpdate = "UPDATE TareasDocs SET "
        strUpdate = strUpdate & "TareasDocs.TareasCodigo = '" & TareasCodigo & "', "
        strUpdate = strUpdate & "TareasDocs.TareasDocsSecuencia = " & TareasDocsSecuencia & ", "
        strUpdate = strUpdate & "TareasDocs.TareasDocsCodigo = '" & TareasDocsCodigo & "', "
        strUpdate = strUpdate & "TareasDocs.TareasDocsNombre = '" & TareasDocsNombre & "', "
        strUpdate = strUpdate & "TareasDocs.TareasDocsDescription = '" & TareasDocsDescription & "', "
        strUpdate = strUpdate & "TareasDocs.TareasDocsPath = '" & TareasDocsPath & "', "
        strUpdate = strUpdate & "TareasDocs.TareasPlantillaCodigo = '" & TareasPlantillaCodigo & "', "
        strUpdate = strUpdate & "TareasDocs.AreasName = '" & AreasName & "', "
        strUpdate = strUpdate & "TareasDocs.EmpresasCodigo = '" & EmpresasCodigo & "', "
        strUpdate = strUpdate & "TareasDocs.ContratoCodigo = '" & ContratoCodigo & "', "
        strUpdate = strUpdate & "TareasDocs.TareasDocsFEmision = '" & AccionesABM.DateTransform(TareasDocsFEmision) & "', "
        strUpdate = strUpdate & "TareasDocs.UsuariosCodigo = '" & UsuariosCodigo & "', "
        strUpdate = strUpdate & "TareasDocs.TareasDocsObservaciones = '" & TareasDocsObservaciones & "', "
        strUpdate = strUpdate & "TareasDocs.TareasDocsResponsableArea = '" & TareasDocsResponsableArea & "', "
        strUpdate = strUpdate & "TareasDocs.TareasDocsCargoResponsable = '" & TareasDocsCargoResponsable & "', "
        strUpdate = strUpdate & "TareasDocs.TipoDocName = '" & TipoDocName & "', "
        strUpdate = strUpdate & "TareasDocs.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "TareasDocs.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE TareasDocs.TareasDocsId = " & TareasDocsId
        Try
            TareasDocsUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & TareasCodigo, TareasDocsId, "TareasDocs", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UsuariosCodigo, TareasLogRol, TareasLogActividad)
        Catch
            TareasDocsUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & TareasCodigo, TareasDocsId, "TareasDocs", "")
        End Try
    End Function
    Public Function TareasDocsInsert(ByRef TareasDocsId As Long, ByRef TareasCodigo As String, ByRef TareasDocsSecuencia As Long, ByRef TareasDocsCodigo As String, ByRef TareasDocsNombre As String, ByRef TareasDocsDescription As String, ByRef TareasDocsPath As String, ByRef TareasPlantillaCodigo As String, ByRef AreasName As String, ByRef EmpresasCodigo As String, ByRef ContratoCodigo As String, ByRef TareasDocsFEmision As Date, ByRef UsuariosCodigo As String, ByRef TareasDocsObservaciones As String, ByRef TareasDocsResponsableArea As String, ByRef TareasDocsCargoResponsable As String, ByRef TipoDocName As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim TareasDocs As New TareasDocs
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = TareasCodigo
            DetailSecuencia = TareasDocsSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("TareasDocsId", "TareasCodigo", "TareasDocsSecuencia", "TareasDocs", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("TareasDocsId", "TareasCodigo", "TareasDocsSecuencia", "TareasDocs", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            TareasDocsInsert = TareasDocs.TareasDocsUpdate(DetailId, CStr(TareasCodigo), CLng(TareasDocsSecuencia), CStr(TareasDocsCodigo), CStr(TareasDocsNombre), CStr(TareasDocsDescription), CStr(TareasDocsPath), CStr(TareasPlantillaCodigo), CStr(AreasName), CStr(EmpresasCodigo), CStr(ContratoCodigo), CDate(TareasDocsFEmision), CStr(UsuariosCodigo), CStr(TareasDocsObservaciones), CStr(TareasDocsResponsableArea), CStr(TareasDocsCargoResponsable), CStr(TipoDocName), UserId)
        Catch
            TareasDocsInsert = 0
        End Try
    End Function
    Public Function TareasDocsDelete(ByVal TareasDocsId As Long, ByVal TareasCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (TareasDocs) "
        strUpdate = strUpdate & "WHERE (TareasDocs.TareasDocsId = " & TareasDocsId & ") "
        Try
            TareasDocsDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina API asociada al Proyecto: " & TareasCodigo, TareasDocsId, "TareasDocs", "")
        Catch
            TareasDocsDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar API asociada al proyecto: " & TareasCodigo, TareasDocsId, "TareasDocs", "")
        End Try
    End Function
    Public Function LeerLosDocumentos(ByVal TareasCodigo As String, ByVal Accion As Integer) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String = ""
        Dim Tareas As New Tareas

        LeerLosDocumentos = ""
        Select Case Accion
            Case 1

                strUpdate = "SELECT TareasDocs.TareasDocsNombre as Titulo "
                strUpdate = strUpdate & "FROM CarpetaJudicial INNER JOIN (TareasDocs INNER JOIN Tareas ON TareasDocs.TareasCodigo = Tareas.TareasCodigo) ON CarpetaJudicial.CarpetaJudicialCodigo = Tareas.PGGCodigo "
                strUpdate = strUpdate & "WHERE (((Tareas.PGGCodigo)='" & Tareas.LeerTareasPGGCodigo(TareasCodigo) & "'))"

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
End Class
