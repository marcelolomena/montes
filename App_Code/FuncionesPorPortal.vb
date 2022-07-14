Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class FuncionesPorPortal
    Public Function FuncionesPorPortalUpdate(ByVal PortalesId As Long, ByVal MenuOptionsId As String, ByVal Secuencia As Long, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim FuncionesPorPortalId As Long = 0
        Dim SecuenciaGrabada As Long = 0
        Dim Lecturas As New Lecturas
        Dim FuncionesPorPortal As New FuncionesPorPortal
        Dim CodigoHTMLCarpetas As String = ""

        If LeerFuncionesPorPortal(PortalesId, MenuOptionsId, FuncionesPorPortalId, SecuenciaGrabada) = True Then
            'Se elimina si la secuencia es la 
            strUpdate = "DELETE FROM FuncionesPorPortal WHERE PortalesId = " & PortalesId & " AND MenuOptionsId = " & MenuOptionsId

            Try
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Función " & MenuOptionsId & " para el Portal " & PortalesId, PortalesId, "Portales", "")
                FuncionesPorPortalUpdate = FuncionesPorPortal.ListarFuncionesPorPortal(CodigoHTMLCarpetas, UserId, True, PortalesId)
            Catch
                FuncionesPorPortalUpdate = 0
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar Función " & MenuOptionsId & " para el Portal " & PortalesId, PortalesId, "Portales", "")
            End Try
        Else
            'Se Crea
            'Primero se busca la secuencia disponible y se le suma 1, se crean las posiciones segun el orden que se escoje.
            Secuencia = Lecturas.LeerMaximoId("Select Max(Secuencia) as MaximoId FROM FuncionesPorPortal WHERE PortalesID = " & PortalesId) + 1
            strUpdate = "INSERT INTO FuncionesPorPortal ( PortalesId, MenuOptionsId, Secuencia, DateLastUpdate, UserLastUpdate "
            strUpdate = strUpdate & ") VALUES (" & PortalesId & ", " & MenuOptionsId & ", " & Secuencia & ", '" & AccionesABM.DateTransform(Now()) & "', " & UserId & ")"

            Try
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Función " & MenuOptionsId & " para el Portal " & PortalesId, PortalesId, "Portales", "")
                'FuncionesPorPortalUpdate = "<input id=""txtInputbox" & MenuOptionsId & """ type=""text"" style=""text-align:right;width: 25px"" class=""textoboxgris""  value=""" & FormatNumber(Secuencia, 0) & """ onblur=""FuncionesPorPortalUpdateSecuencia(" & PortalesId & ", " & MenuOptionsId & ", " & UserId & ")""  />&nbsp;&nbsp;<input id=""Checkbox" & MenuOptionsId & """ type=""checkbox"" checked=""checked"" onclick=""FuncionesPorPortalUpdate(" & PortalesId & ", " & MenuOptionsId & ", " & UserId & ")"" />"
                FuncionesPorPortalUpdate = FuncionesPorPortal.ListarFuncionesPorPortal(CodigoHTMLCarpetas, UserId, True, PortalesId)

            Catch
                FuncionesPorPortalUpdate = "0"
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de Insertar Función " & MenuOptionsId & " para el Portal " & PortalesId, PortalesId, "Portales", "")
            End Try

        End If
    End Function
    Public Function FuncionesPorPortalUpdateSecuencia(ByVal PortalesId As Long, ByVal MenuOptionsId As String, ByVal Secuencia As Long, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim FuncionesPorPortalId As Long = 0
        Dim SecuenciaGrabada As Long = 0
        Dim FuncionesPorPortal As New FuncionesPorPortal
        Dim CodigoHTMLCarpetas = ""

        FuncionesPorPortalUpdateSecuencia = 0

        If LeerFuncionesPorPortal(PortalesId, MenuOptionsId, FuncionesPorPortalId, SecuenciaGrabada) = True Then
            'Se encontro el registro y por ello se actualiza 
            strUpdate = "UPDATE FuncionesPorPortal SET "
            strUpdate = strUpdate & "FuncionesPorPortal.Secuencia = " & Secuencia & ", "
            strUpdate = strUpdate & "FuncionesPorPortal.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
            strUpdate = strUpdate & "FuncionesPorPortal.UserLastUpdate = " & UserId & " "
            strUpdate = strUpdate & "WHERE FuncionesPorPortal.FuncionesPorPortalId = " & FuncionesPorPortalId
            Try
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Secuencia de la Función " & MenuOptionsId & " para el Portal " & PortalesId, PortalesId, "Portales", "")
                FuncionesPorPortalUpdateSecuencia = FuncionesPorPortal.ListarFuncionesPorPortal(CodigoHTMLCarpetas, UserId, True, PortalesId)
            Catch
                t = 0
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar la secuencia de la Función " & MenuOptionsId & " para el Portal " & PortalesId, PortalesId, "Portales", "")
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
    Public Function LeerFuncionesPorPortal(ByVal PortalesId As Long, ByVal MenuOptionsId As String, ByRef FuncionesPorPortalId As Long, ByRef Secuencia As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select FuncionesPorPortalId, Secuencia "
        sSQL = sSQL & "FROM FuncionesPorPortal "
        sSQL = sSQL & "WHERE PortalesId = " & PortalesId & " AND MenuOptionsId = " & MenuOptionsId & " "

        LeerFuncionesPorPortal = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                FuncionesPorPortalId = CLng(dtr("FuncionesPorPortalId").ToString)
                Secuencia = CLng(dtr("Secuencia").ToString)
                LeerFuncionesPorPortal = True
            End While
            dtr.Close()
        Catch
            LeerFuncionesPorPortal = False
        End Try
    End Function
    Public Function ListarFuncionesPorPortal(ByRef CodigoHTML As String, ByVal UserId As Long, ByVal IsAuthorizedUser As Boolean, ByVal PortalesId As Long) As String
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim t As Boolean
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;"
        Dim FuncionesPorPortal As New FuncionesPorPortal
        Dim l As String = ""
        Dim Pagina As String = ""
        Dim FuncionesPorPortalId As Long = 0
        Dim Valor As Long = 0
        Dim Secuencia As Long = 0

        Dim UrlEditarCarpeta As String = "*"
        Dim UrlCrearSubCarpeta As String = "*"

        sSQL = "SELECT MenuOptionsId As PId, Texto As Carpeta, Description As Descripcion, PaginaWebName as Pagina "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = 0 And Zona = 'BarMenu' "
        sSQL = sSQL & "ORDER by Secuencia"

        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""vinculo_carpeta"">"
        CodigoHTML = CodigoHTML & "<tr><th width=""200"" align=""left"">Opción de Menú</th><th width=""250"" align=""left"">Descripción</th><th width=""150"" align=""left"">Página</th><th width=""68"" align=""center"">Editar</th></tr>"
        ListarFuncionesPorPortal = ""
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read
                Valor = CLng(dtrFunciones("PId"))
                If FuncionesPorPortal.LeerFuncionesPorPortal(PortalesId, Valor, FuncionesPorPortalId, Secuencia) Then
                    l = "<div id=""divContent" & Valor & """ ><input id=""txtInputbox" & Valor & """ type=""text"" style=""text-align:right;width: 25px"" class=""textoboxgris""  value=""" & FormatNumber(Secuencia, 0) & """ onblur=""FuncionesPorPortalUpdateSecuencia(" & PortalesId & ", " & Valor & ", " & UserId & ")""  />&nbsp;&nbsp;<input id=""Checkbox" & Valor & """ type=""checkbox"" checked=""checked"" onclick=""FuncionesPorPortalUpdate(" & PortalesId & ", " & Valor & ", " & UserId & ")"" /></div>"
                Else
                    'l = "<input id=""txtInputbox" & Valor & """ type=""text"" style=""text-align:right;width: 25px"" class=""textoboxgris"" value=""0"" />&nbsp;&nbsp;<input id=""Checkbox" & Valor & """ type=""checkbox"" onclick=""FuncionesPorPortalUpdate(" & PortalesId & ", " & Valor & ", " & UserId & ")"" />"
                    l = "<div id=""divContent" & Valor & """ ><input id=""Checkbox" & Valor & """ type=""checkbox"" onclick=""FuncionesPorPortalUpdate(" & PortalesId & ", " & Valor & ", " & UserId & ")"" /></div>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                If IsAuthorizedUser = True Then
                    CodigoHTML = CodigoHTML & "<td width=""250"" align=""left"">" & dtrFunciones("Carpeta").ToString & "</td><td width=""250"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""100"" align=""left"">" & Pagina & "</td><td width=""68"" align=""center"">" & l & "</td>"
                Else
                    CodigoHTML = CodigoHTML & "<td width=""250"" align=""left"">" & dtrFunciones("Carpeta").ToString & "</td><td width=""250"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""100"" align=""left"">" & Pagina & "</td><td width=""68"" align=""center""></td>"
                End If
                CodigoHTML = CodigoHTML & "</tr>"
            End While
            dtrFunciones.Close()
        Catch
            ListarFuncionesPorPortal = ""
        End Try
        ListarFuncionesPorPortal = CodigoHTML & "</table>"
    End Function

End Class
