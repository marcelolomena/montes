'------------------------------------------------------------
' Código generado por ZRISMART SF el 15-03-2011 8:20:49
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Usuarios
    Public Function LeerUsuarios(ByVal UsuariosId As Long, ByRef UsuariosCodigo As String, ByRef UsuariosClave As String, ByRef UsuariosName As String, ByRef RolName As String, _
                                 ByRef UsuariosProfesion As String, ByRef UsuariosUniversidad As String, ByRef UsuariosCelular As String, ByRef UsuariosTelefonoFijo As String, ByRef UsuariosDireccion1 As String, _
                                 ByRef UsuariosDireccion2 As String, ByRef UsuariosCorreo2 As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select UsuariosCodigo, UsuariosClave, UsuariosName, RolName, UsuariosProfesion, UsuariosUniversidad, UsuariosCelular, UsuariosTelefonoFijo, UsuariosDireccion1, UsuariosDireccion2, UsuariosCorreo2 "
        sSQL = sSQL & "FROM [montes].[dbo].Usuarios "
        sSQL = sSQL & "WHERE (Usuarios.UsuariosId = " & UsuariosId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                UsuariosCodigo = CStr(dtr("UsuariosCodigo").ToString)
                UsuariosClave = CStr(dtr("UsuariosClave").ToString)
                UsuariosName = CStr(dtr("UsuariosName").ToString)
                RolName = CStr(dtr("RolName").ToString)
                UsuariosProfesion = CStr(dtr("UsuariosProfesion").ToString)
                UsuariosUniversidad = CStr(dtr("UsuariosUniversidad").ToString)
                UsuariosCelular = CStr(dtr("UsuariosCelular").ToString)
                UsuariosTelefonoFijo = CStr(dtr("UsuariosTelefonoFijo").ToString)
                UsuariosDireccion1 = CStr(dtr("UsuariosDireccion1").ToString)
                UsuariosDireccion2 = CStr(dtr("UsuariosDireccion2").ToString)
                UsuariosCorreo2 = CStr(dtr("UsuariosCorreo2").ToString)
            End While
            LeerUsuarios = True
            dtr.Close()
        Catch
            LeerUsuarios = False
        End Try
    End Function
    Public Function LeerUsuariosByName(ByRef UsuariosId As Long, ByVal UsuariosCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select UsuariosId "
        sSQL = sSQL & "FROM [montes].[dbo].Usuarios "
        sSQL = sSQL & "WHERE (Usuarios.UsuariosCodigo = '" & UsuariosCodigo & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                UsuariosId = CLng(dtr("UsuariosId").ToString)
            End While
            LeerUsuariosByName = True
            dtr.Close()
        Catch
            LeerUsuariosByName = False
        End Try
    End Function
    Public Function LeerUsuariosCodigoByUsuariosId(ByVal UsuariosId As Long, ByRef UsuariosCodigo As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select UsuariosCodigo "
        sSQL = sSQL & "FROM [montes].[dbo].Usuarios "
        sSQL = sSQL & "WHERE (Usuarios.Usuariosid = " & UsuariosId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                UsuariosCodigo = CStr(dtr("UsuariosCodigo").ToString)
            End While
            LeerUsuariosCodigoByUsuariosId = True
            dtr.Close()
        Catch
            LeerUsuariosCodigoByUsuariosId = False
        End Try
    End Function
    Public Function UsuariosUpdate(ByVal UsuariosId As Long, ByVal UsuariosCodigo As String, ByVal UsuariosClave As String, ByVal UsuariosName As String, ByVal RolName As String, _
                                 ByVal UsuariosProfesion As String, ByVal UsuariosUniversidad As String, ByVal UsuariosCelular As String, ByVal UsuariosTelefonoFijo As String, ByVal UsuariosDireccion1 As String, _
                                 ByVal UsuariosDireccion2 As String, ByVal UsuariosCorreo2 As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE [montes].[dbo].Usuarios SET "
        strUpdate = strUpdate & "Usuarios.UsuariosCodigo = '" & UsuariosCodigo & "', "
        strUpdate = strUpdate & "Usuarios.UsuariosClave = '" & UsuariosClave & "', "
        strUpdate = strUpdate & "Usuarios.UsuariosName = '" & UsuariosName & "', "
        strUpdate = strUpdate & "Usuarios.RolName = '" & RolName & "', "
        strUpdate = strUpdate & "Usuarios.UsuariosProfesion = '" & UsuariosProfesion & "', "
        strUpdate = strUpdate & "Usuarios.UsuariosUniversidad = '" & UsuariosUniversidad & "', "
        strUpdate = strUpdate & "Usuarios.UsuariosCelular = '" & UsuariosCelular & "', "
        strUpdate = strUpdate & "Usuarios.UsuariosTelefonoFijo = '" & UsuariosTelefonoFijo & "', "
        strUpdate = strUpdate & "Usuarios.UsuariosDireccion1 = '" & UsuariosDireccion1 & "', "
        strUpdate = strUpdate & "Usuarios.UsuariosDireccion2 = '" & UsuariosDireccion2 & "', "
        strUpdate = strUpdate & "Usuarios.UsuariosCorreo2 = '" & UsuariosCorreo2 & "', "
        strUpdate = strUpdate & "Usuarios.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Usuarios.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Usuarios.UsuariosId = " & UsuariosId
        Try
            UsuariosUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & UsuariosCodigo, UsuariosId, "Usuarios", "")
        Catch
            UsuariosUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & UsuariosCodigo, UsuariosId, "Usuarios", "")
        End Try
    End Function
    Public Function UsuariosInsert(ByRef UsuariosId As Long, ByVal UsuariosCodigo As String, ByVal UsuariosClave As String, ByVal UsuariosName As String, ByVal RolName As String, _
                                 ByVal UsuariosProfesion As String, ByVal UsuariosUniversidad As String, ByVal UsuariosCelular As String, ByVal UsuariosTelefonoFijo As String, ByVal UsuariosDireccion1 As String, _
                                 ByVal UsuariosDireccion2 As String, ByVal UsuariosCorreo2 As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Usuarios As New Usuarios
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = UsuariosCodigo
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("UsuariosId", "UsuariosCodigo", "Usuarios", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("UsuariosId", "UsuariosCodigo", "Usuarios", MasterName, CLng(UserId), MasterId)
            End If
            UsuariosInsert = Usuarios.UsuariosUpdate(MasterId, CStr(UsuariosCodigo), CStr(UsuariosClave), CStr(UsuariosName), CStr(RolName), UsuariosProfesion, UsuariosUniversidad, UsuariosCelular, UsuariosTelefonoFijo, UsuariosDireccion1, UsuariosDireccion2, UsuariosCorreo2, UserId)
        Catch
            UsuariosInsert = 0
        End Try
    End Function
    Public Function ValidarUsuario(ByVal UsuariosCodigo As String, ByVal UsuariosClave As String, _
                                        ByRef UsuariosId As Long, ByRef UsuariosName As String, _
                                        ByRef RolName As String, ByRef RolId As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Usuarios.UsuariosId, Usuarios.UsuariosName,  Usuarios.RolName, Roles.RolId "
        sSQL = sSQL & "FROM [montes].[dbo].Usuarios, [montes].[dbo].Roles "
        sSQL = sSQL & "WHERE Usuarios.UsuariosCodigo = '" & UsuariosCodigo & "' AND Usuarios.UsuariosClave = '" & UsuariosClave & "' AND Roles.RolName = Usuarios.RolName AND Usuarios.UsuariosEstado = 'Activo'"

        ValidarUsuario = False

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                UsuariosId = CLng(dtr("UsuariosId").ToString)
                UsuariosName = dtr("UsuariosName").ToString
                RolName = dtr("RolName").ToString
                RolId = CLng(dtr("RolId").ToString)
                ValidarUsuario = True
            End While

            dtr.Close()
        Catch
            ValidarUsuario = False
        End Try
    End Function
    Public Function LeerUsuariosDescriptionByName(ByVal UsuariosCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select UsuariosName "
        sSQL = sSQL & "FROM [montes].[dbo].Usuarios "
        sSQL = sSQL & "WHERE (Usuarios.UsuariosCodigo = '" & UsuariosCodigo & "') "
        LeerUsuariosDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerUsuariosDescriptionByName = CStr(dtr("UsuariosName").ToString)
            End While
            dtr.Close()
        Catch
            LeerUsuariosDescriptionByName = ""
        End Try
    End Function
    Public Function UsuariosDelete(ByVal UsuariosId As Long, ByVal UsuariosCodigo As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM

        Dim t As Integer = 0
        strUpdate = "UPDATE [montes].[dbo].Usuarios SET "
        strUpdate = strUpdate & "Usuarios.UsuariosEstado = 'Inactivo', "
        strUpdate = strUpdate & "Usuarios.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Usuarios.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Usuarios.UsuariosId = " & UsuariosId
        Try
            UsuariosDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Deja inactivo a " & UsuariosCodigo, UsuariosId, "Usuarios", "")
        Catch
            UsuariosDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de inactivar a " & UsuariosCodigo, UsuariosId, "Usuarios", "")
        End Try
    End Function
    Public Function LeerEstadoUsuarios(ByVal UsuariosId As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim Estado As String
        sSQL = "Select UsuariosEstado "
        sSQL = sSQL & "FROM [montes].[dbo].Usuarios "
        sSQL = sSQL & "WHERE (Usuarios.UsuariosId = " & UsuariosId & ") "
        LeerEstadoUsuarios = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Estado = CStr(dtr("UsuariosEstado").ToString)
                If Estado = "Activo" Then
                    LeerEstadoUsuarios = True
                Else
                    LeerEstadoUsuarios = False
                End If
            End While
            dtr.Close()
        Catch
            LeerEstadoUsuarios = False
        End Try
    End Function
    Public Function LeerRolNameByName(ByVal UsuariosCodigo As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select RolName "
        sSQL = sSQL & "FROM [montes].[dbo].Usuarios "
        sSQL = sSQL & "WHERE (Usuarios.UsuariosCodigo = '" & UsuariosCodigo & "') "
        LeerRolNameByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerRolNameByName = CStr(dtr("RolName").ToString)
            End While
            dtr.Close()
        Catch
            LeerRolNameByName = ""
        End Try
    End Function
    Public Function ListarUsuariosPorRol(ByRef RolName As String, ByVal IsAuthorizedUser As Boolean) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim CodigoHTML As String = ""
        Dim strUpdate As String
        Dim Programas As New Programas
        Dim LinkPerfilUsuario As String = ""

        strUpdate = "SELECT Roles.RolName, Usuarios.UsuariosId as Id, Usuarios.UsuariosName, Usuarios.UsuariosProfesion, Usuarios.UsuariosUniversidad, Usuarios.UsuariosCelular, Usuarios.UsuariosTelefonoFijo, Usuarios.UsuariosDireccion1, Usuarios.UsuariosDireccion2, Usuarios.UsuariosCodigo, Usuarios.UsuariosCorreo2 "
        strUpdate = strUpdate & "FROM [montes].[dbo].Usuarios INNER JOIN Roles ON Usuarios.RolName = Roles.RolName "
        strUpdate = strUpdate & "WHERE (((Roles.RolName)='" & RolName & "') AND ((Usuarios.UsuariosEstado)='Activo'))"

        ListarUsuariosPorRol = ""

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                CodigoHTML = CodigoHTML & "<table width=""650"" border=""0"" cellpadding=""0"" cellspacing=""0"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td width=""350"" class=""equipo_contenedor""><table width=""300"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""equipo"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td width=""111"" rowspan=""2""><img src=""imgs/foto_perfil.jpg"" width=""111"" height=""96"" alt=""Foto"" /></td>"
                LinkPerfilUsuario = "<a href=""IndexSGI.aspx?PaginaWebName=Perfil Usuarios&MenuOptionsId=486" & "&Id=" & dtr("Id").ToString & """ >" & dtr("UsuariosName").ToString & "</a>"
                CodigoHTML = CodigoHTML & "<th width=""189"" class=""equipo"">" & LinkPerfilUsuario & "</th>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td class=""equipo"">" & RolName & "<br />" & dtr("UsuariosProfesion").ToString & "<br />" & dtr("UsuariosUniversidad").ToString & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "</table></td>"
                CodigoHTML = CodigoHTML & "<td width=""300"" class=""equipo_contenedor""><table width=""300"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""equipo"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td class=""equipo""> Celular: " & dtr("UsuariosCelular").ToString & "<br /> Fijo: " & dtr("UsuariosTelefonoFijo").ToString & "<br /> Correo 1: " & dtr("UsuariosCodigo").ToString & "<br /> Correo 2: " & dtr("UsuariosCorreo2").ToString & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td class=""equipo""> Direcci&oacute;n 1: " & dtr("UsuariosDireccion1").ToString & "<br /> Direcci&oacute;n 2: " & dtr("UsuariosDireccion2").ToString & "</td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "</table></td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "</table>"
            End While
            dtr.Close()
        Catch

        End Try
        ListarUsuariosPorRol = CodigoHTML
    End Function
    Public Function LeerStringBusqueda(ByVal UsuariosId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select UsuariosStringBusqueda "
        sSQL = sSQL & "FROM [montes].[dbo].Usuarios "
        sSQL = sSQL & "WHERE Usuarios.UsuariosId = " & UsuariosId
        LeerStringBusqueda = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerStringBusqueda = CStr(dtr("UsuariosStringBusqueda").ToString)
            End While
            dtr.Close()
        Catch
            LeerStringBusqueda = ""
        End Try
    End Function
    Public Function StringBusquedaUpdate(ByVal UserId As Long, ByVal StringBusqueda As String) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM

        Dim t As Integer = 0
        strUpdate = "UPDATE [montes].[dbo].Usuarios SET "
        strUpdate = strUpdate & "Usuarios.UsuariosStringBusqueda = '" & StringBusqueda & "', "
        strUpdate = strUpdate & "Usuarios.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Usuarios.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Usuarios.UsuariosId = " & UserId
        Try
            StringBusquedaUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Ultimo String de Busqueda " & StringBusqueda, UserId, "Usuarios", "")
        Catch
            StringBusquedaUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "No se pudo actualizar string de buesqueda " & StringBusqueda, UserId, "Usuarios", "")
        End Try
    End Function
End Class
