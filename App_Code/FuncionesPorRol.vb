Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class FuncionesPorRol
    Public Function FuncionesPorRolInsert(ByVal RolId As Long, ByVal FuncionId As String, ByVal EntidadNombreTabla As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim AccesoEA As New AccesoEA
        Dim sSQL As String

        sSQL = "INSERT INTO FuncionesPorRol ( RolId, FuncionId, EntidadNombreTabla, DateLastUpdate, UserLastUpdate "
        sSQL = sSQL & ") VALUES (" & RolId & ", " & FuncionId & ", '" & EntidadNombreTabla & "', '" & AccionesABM.DateTransform(Now()) & "', " & UserId & ")"

        Try
            FuncionesPorRolInsert = AccesoEA.ABMRegistros(sSQL)
            t = AccionesABM.BitacoraInsert(UserId, Replace(sSQL, "'", " "), 0, 0, "Inserta Función " & FuncionId & " de la tabla " & EntidadNombreTabla & " para el Rol " & RolId, RolId, "Roles", "")
        Catch
            FuncionesPorRolInsert = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(sSQL, "'", " "), 0, 0, "Intento fallido de Insertar Función " & FuncionId & " de la tabla " & EntidadNombreTabla & " para el Rol " & RolId, RolId, "Roles", "")
        End Try
    End Function
    Public Function FuncionesPorRolDelete(ByVal RolId As Long, ByVal FuncionId As String, ByVal EntidadNombreTabla As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "DELETE FROM FuncionesPorRol WHERE RolId = " & RolId & " AND FuncionId = " & FuncionId & " AND EntidadNombreTabla = '" & EntidadNombreTabla & "'"

        Try
            FuncionesPorRolDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Función " & FuncionId & " de la tabla " & EntidadNombreTabla & " para el Rol " & RolId, RolId, "Roles", "")
        Catch
            FuncionesPorRolDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar Función " & FuncionId & " de la tabla " & EntidadNombreTabla & " para el Rol " & RolId, RolId, "Roles", "")
        End Try
    End Function
    Public Function FuncionesPorRolUpdate(ByVal RolId As Long, ByVal FuncionId As String, ByVal EntidadNombreTabla As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim FuncionesPorRolId As Long = 0

        If LeerFuncionesPorRol(RolId, FuncionId, EntidadNombreTabla, FuncionesPorRolId) = True Then
            'Se elimina
            strUpdate = "DELETE FROM FuncionesPorRol WHERE RolId = " & RolId & " AND FuncionId = " & FuncionId & " AND EntidadNombreTabla = '" & EntidadNombreTabla & "'"

            Try
                FuncionesPorRolUpdate = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Función " & FuncionId & " de la tabla " & EntidadNombreTabla & " para el Rol " & RolId, RolId, "Roles", "")
            Catch
                FuncionesPorRolUpdate = 0
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar Función " & FuncionId & " de la tabla " & EntidadNombreTabla & " para el Rol " & RolId, RolId, "Roles", "")
            End Try
        Else
            'Se Crea
            strUpdate = "INSERT INTO FuncionesPorRol ( RolId, FuncionId, EntidadNombreTabla, DateLastUpdate, UserLastUpdate "
            strUpdate = strUpdate & ") VALUES (" & RolId & ", " & FuncionId & ", '" & EntidadNombreTabla & "', '" & AccionesABM.DateTransform(Now()) & "', " & UserId & ")"

            Try
                FuncionesPorRolUpdate = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta Función " & FuncionId & " de la tabla " & EntidadNombreTabla & " para el Rol " & RolId, RolId, "Roles", "")
            Catch
                FuncionesPorRolUpdate = 0
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de Insertar Función " & FuncionId & " de la tabla " & EntidadNombreTabla & " para el Rol " & RolId, RolId, "Roles", "")
            End Try

        End If
    End Function

    Public Function LeerFuncionesPorRol(ByVal RolId As Long, ByVal FuncionId As String, ByVal EntidadNombreTabla As String, ByRef FuncionesPorRolId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select FuncionesPorRolId "
        sSQL = sSQL & "FROM FuncionesPorRol "
        sSQL = sSQL & "WHERE (RolId = " & RolId & " AND FuncionId = " & FuncionId & " AND EntidadNombreTabla = '" & EntidadNombreTabla & "')"
        LeerFuncionesPorRol = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                FuncionesPorRolId = CLng(dtr("FuncionesPorRolId").ToString)
                LeerFuncionesPorRol = True
            End While
            dtr.Close()
        Catch
            LeerFuncionesPorRol = False
        End Try
    End Function
    Public Function ListarPortales(ByRef CodigoHTML As String, ByVal UserId As Long, ByVal IsAuthorizedUser As Boolean, ByVal MenuOptionsId As Long, ByVal RolId As Long) As String
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim t As Boolean
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;"
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim l As String = ""
        Dim Pagina As String = ""
        Dim FuncionesPorRolId As Long = 0
        Dim Tabla As String = "Portales"
        Dim Valor As Long = 0

        Dim UrlEditarCarpeta As String = "*"
        Dim UrlCrearSubCarpeta As String = "*"

        sSQL = "SELECT PortalesId As PId, PortalesName As Carpeta, PortalesDescription As Descripcion, PortalesMasterPage as Pagina "
        sSQL = sSQL & "FROM Portales "
        sSQL = sSQL & "ORDER by Portales.PortalesSecuencia"

        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""vinculo_carpeta"">"
        CodigoHTML = CodigoHTML & "<tr><th width=""200"" align=""left"">Portal</th><th width=""250"" align=""left"">Descripción</th><th width=""150"" align=""left"">Página Maestra</th><th width=""68"" align=""center"">Editar</th></tr>"
        ListarPortales = ""
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read
                Pagina = ""
                If dtrFunciones("Pagina").ToString <> "Por definir" Then
                    Pagina = dtrFunciones("Pagina").ToString
                End If
                Valor = CLng(dtrFunciones("PId"))
                If FuncionesPorRol.LeerFuncionesPorRol(RolId, Valor, Tabla, FuncionesPorRolId) Then
                    l = "<input id=""Checkbox" & Valor & """ type=""checkbox"" checked=""checked"" onclick=""FuncionesPorRolUpdate(" & RolId & ", " & Valor & ", '" & Tabla & "', " & UserId & ")"" />"
                Else
                    l = "<input id=""Checkbox" & Valor & """ type=""checkbox"" onclick=""FuncionesPorRolUpdate(" & RolId & ", " & Valor & ", '" & Tabla & "', " & UserId & ")"" />"
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
            ListarPortales = ""
        End Try
        ListarPortales = CodigoHTML & "</table><br />"

        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""vinculo_carpeta"">"
        CodigoHTML = CodigoHTML & "<tr><th width=""200"" align=""left"">Opción de Menú</th><th width=""250"" align=""left"">Descripción</th><th width=""150"" align=""left"">Página</th><th width=""68"" align=""center"">Editar</th></tr>"
        t = FuncionesPorRol.LoadEditarRaicesCarpeta(CodigoHTML, UserId, IsAuthorizedUser, MenuOptionsId, RolId)
        ListarPortales = ListarPortales & CodigoHTML & "</table>"
    End Function

    Public Function LoadEditarRaicesCarpeta(ByRef CodigoHTML As String, ByVal UserId As Long, ByVal IsAuthorizedUser As Boolean, ByVal MenuOptionsId As Long, ByVal Rol As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim t As Boolean
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;"
        Dim EspacioMasAbajo As String = Espacios & "&nbsp;&nbsp;&nbsp;"
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim l As String = ""
        Dim Pagina As String = ""
        Dim FuncionesPorRolId As Long = 0
        Dim Tabla As String = "MenuOptions"
        Dim Valor As Long = 0

        Dim UrlEditarCarpeta As String = "*"
        Dim UrlCrearSubCarpeta As String = "*"

        sSQL = "SELECT MenuOptionsId As PId, Texto As Carpeta, Description As Descripcion, PaginaWebName as Pagina "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = 0 AND Zona = 'BarMenu' "
        sSQL = sSQL & "ORDER by MenuOptions.Secuencia"

        'CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""vinculo_carpeta"">"
        'CodigoHTML = CodigoHTML & "<tr><th width=""200"" align=""left"">Opción de Menú</th><th width=""250"" align=""left"">Descripción</th><th width=""150"" align=""left"">Página</th><th width=""68"" align=""center"">Editar</th></tr>"
        LoadEditarRaicesCarpeta = False
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read
                Pagina = ""
                If dtrFunciones("Pagina").ToString <> "Por definir" Then
                    Pagina = dtrFunciones("Pagina").ToString
                End If
                Valor = CLng(dtrFunciones("PId"))
                If FuncionesPorRol.LeerFuncionesPorRol(Rol, Valor, Tabla, FuncionesPorRolId) Then
                    l = "<input id=""Checkbox" & Valor & """ type=""checkbox"" checked=""checked"" onclick=""FuncionesPorRolUpdate(" & Rol & ", " & Valor & ", '" & Tabla & "', " & UserId & ")"" />"
                Else
                    l = "<input id=""Checkbox" & Valor & """ type=""checkbox"" onclick=""FuncionesPorRolUpdate(" & Rol & ", " & Valor & ", '" & Tabla & "', " & UserId & ")"" />"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                If IsAuthorizedUser = True Then
                    CodigoHTML = CodigoHTML & "<td width=""250"" align=""left"">" & Espacios & dtrFunciones("Carpeta").ToString & "</td><td width=""250"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""100"" align=""left"">" & Pagina & "</td><td width=""68"" align=""center"">" & l & "</td>"
                Else
                    CodigoHTML = CodigoHTML & "<td width=""250"" align=""left"">" & Espacios & dtrFunciones("Carpeta").ToString & "</td><td width=""250"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""100"" align=""left"">" & Pagina & "</td><td width=""68"" align=""center""></td>"
                End If
                CodigoHTML = CodigoHTML & "</tr>"
                t = FuncionesPorRol.LoadEditarNodosCarpetas(CLng(dtrFunciones("PId").ToString), CodigoHTML, UserId, EspacioMasAbajo, IsAuthorizedUser, MenuOptionsId, Rol)
                LoadEditarRaicesCarpeta = True
            End While
            dtrFunciones.Close()
        Catch
            LoadEditarRaicesCarpeta = False
        End Try
    End Function
    Public Function LoadEditarNodosCarpetas(ByVal CarpetasPId As Long, ByRef CodigoHTML As String, ByVal UserId As Long, ByVal Espacios As String, ByVal IsAuthorizedUser As Boolean, ByVal MenuOptionsId As Long, ByVal Rol As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim t As Boolean
        Dim EspacioMasAbajo As String = Espacios & "&nbsp;&nbsp;&nbsp;"
        Dim l As String = ""
        Dim m As String = ""
        Dim UrlEditarCarpeta As String = "*"
        Dim UrlCrearSubCarpeta As String = "*"
        Dim Pagina As String = ""
        Dim FuncionesPorRolId As Long = 0
        Dim Tabla As String = "MenuOptions"
        Dim Valor As Long = 0


        sSQL = "SELECT MenuOptionsId As PId, Texto As Carpeta, Description As Descripcion, PaginaWebName as Pagina, IsNodoHoja as Hoja "
        sSQL = sSQL & "FROM MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = " & CarpetasPId
        sSQL = sSQL & " ORDER by MenuOptions.Secuencia"
        LoadEditarNodosCarpetas = False
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)
            While dtrFunciones.Read
                Pagina = ""
                If dtrFunciones("Pagina").ToString <> "Por definir" Then
                    Pagina = dtrFunciones("Pagina").ToString
                End If
                If dtrFunciones("Hoja").ToString = "Hoja" Then
                    Valor = CLng(dtrFunciones("PId"))
                    If FuncionesPorRol.LeerFuncionesPorRol(Rol, Valor, Tabla, FuncionesPorRolId) Then
                        l = "<input id=""Checkbox" & Valor & """ type=""checkbox"" checked=""checked"" onclick=""FuncionesPorRolUpdate(" & Rol & ", " & Valor & ", '" & Tabla & "', " & UserId & ")"" />"
                    Else
                        l = "<input id=""Checkbox" & Valor & """ type=""checkbox"" onclick=""FuncionesPorRolUpdate(" & Rol & ", " & Valor & ", '" & Tabla & "', " & UserId & ")"" />"
                    End If
                Else
                    l = ""
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                If IsAuthorizedUser Then
                    CodigoHTML = CodigoHTML & "<td width=""250"" align=""left"">" & Espacios & dtrFunciones("Carpeta").ToString & "</td><td width=""250"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""100"" align=""left"">" & Pagina & "</td><td width=""68"" align=""center"">" & l & "</td>"
                Else
                    CodigoHTML = CodigoHTML & "<td width=""250"" align=""left"">" & Espacios & dtrFunciones("Carpeta").ToString & "</td><td width=""250"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""100"" align=""left"">" & Pagina & "</td><td width=""68"" align=""center""></td>"
                End If
                CodigoHTML = CodigoHTML & "</tr>"
                t = FuncionesPorRol.LoadEditarNodosCarpetas(CLng(dtrFunciones("PId").ToString), CodigoHTML, UserId, EspacioMasAbajo, IsAuthorizedUser, MenuOptionsId, Rol)
                LoadEditarNodosCarpetas = True
            End While
            dtrFunciones.Close()
        Catch
            LoadEditarNodosCarpetas = False
        End Try
    End Function


End Class
