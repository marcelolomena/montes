'------------------------------------------------------------
' Código generado por ZRISMART SF el 07-11-2010 10:44:08
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Rol
    Public Function LeerRol(ByVal RolId As Long, ByRef RolName As String, ByRef RolDescription As String, ByRef RolNivel As Long) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select RolName, RolDescription, RolNivel "
        sSQL = sSQL & "FROM Roles "
        sSQL = sSQL & "WHERE (Roles.RolId = " & RolId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                RolName = CStr(dtr("RolName").ToString)
                RolDescription = CStr(dtr("RolDescription").ToString)
                If Len(dtr("RolNivel").ToString) = 0 Then
                    RolNivel = 0
                Else
                    RolNivel = CLng(dtr("RolNivel").ToString)
                End If
            End While
            LeerRol = True
            dtr.Close()
        Catch
            LeerRol = False
        End Try
    End Function
    Public Function LeerRolByName(ByRef RolId As Long, ByVal RolName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select RolId "
        sSQL = sSQL & "FROM Roles "
        sSQL = sSQL & "WHERE (Roles.RolName = '" & RolName & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                RolId = CLng(dtr("RolId").ToString)
            End While
            LeerRolByName = True
            dtr.Close()
        Catch
            LeerRolByName = False
        End Try
    End Function
    Public Function LeerRolNameByRolId(ByVal RolId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select RolName "
        sSQL = sSQL & "FROM Roles "
        sSQL = sSQL & "WHERE (Roles.RolId = " & RolId & ") "
        LeerRolNameByRolId = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerRolNameByRolId = CStr(dtr("RolName").ToString)
            End While
            dtr.Close()
        Catch
            LeerRolNameByRolId = ""
        End Try
    End Function
    Public Function RolUpdate(ByVal RolId As Long, ByVal RolName As String, ByVal RolDescription As String, ByVal RolNivel As Long, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE Roles SET "
        strUpdate = strUpdate & "Roles.RolName = '" & RolName & "', "
        strUpdate = strUpdate & "Roles.RolDescription = '" & RolDescription & "', "
        strUpdate = strUpdate & "Roles.RolNivel = " & RolNivel & ", "
        strUpdate = strUpdate & "Roles.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "Roles.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE Roles.RolId = " & RolId
        Try
            RolUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & RolName, RolId, "Roles", "")
        Catch
            RolUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & RolName, RolId, "Roles", "")
        End Try
    End Function
    Public Function RolInsert(ByRef RolId As Long, ByVal RolName As String, ByVal RolDescription As String, ByVal RolNivel As Long, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Rol As New Rol
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = RolName
            MasterId = 0
            t = Lecturas.LeerMasterIdByMasterName("RolId", "RolName", "Roles", MasterName, MasterId)
            If MasterId = 0 Then
                t = AccionesABM.MasterPartialInsert("RolId", "RolName", "Roles", MasterName, CLng(UserId), MasterId)
            End If
            RolInsert = Rol.RolUpdate(MasterId, CStr(RolName), CStr(RolDescription), CStr(RolNivel), UserId)
        Catch
            RolInsert = 0
        End Try
    End Function
    Public Function LeerRolDescriptionByName(ByVal RolName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select RolDescription "
        sSQL = sSQL & "FROM Roles "
        sSQL = sSQL & "WHERE (Roles.RolName = '" & RolName & "') "
        LeerRolDescriptionByName = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerRolDescriptionByName = CStr(dtr("RolDescription").ToString)
            End While
            dtr.Close()
        Catch
            LeerRolDescriptionByName = ""
        End Try
    End Function
    Public Function LeerTotalUsuariosPorRol(ByVal RolName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM Roles INNER JOIN Usuarios ON Roles.RolName = Usuarios.RolName "
        sSQL = sSQL & "WHERE (((Roles.RolName)='" & RolName & "'))"
        LeerTotalUsuariosPorRol = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalUsuariosPorRol = LeerTotalUsuariosPorRol + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalUsuariosPorRol = 0
        End Try
    End Function
    Public Function RolDelete(ByVal RolId As Long, ByVal RolName As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim Roles As New Rol

        ' Lee la cantidad de veces que el rol es usado en la tabla de usuarios
        '------------------------------------------
        Total = Roles.LeerTotalUsuariosPorRol(RolName)

        If Total > 0 Then
            Mensaje = "Existen " & Total & " usuarios con el Rol " & RolName & vbCrLf
            Mensaje = Mensaje & "Cambia el rol a los usuarios, antes de eliminar el Rol"
            RolDelete = False
        Else
            Try
                ' Borra registro de la tabla de Roles
                '-------------------------------------
                strUpdate = "DELETE FROM Roles WHERE RolId = " & RolId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el Rol: " & RolName, RolId, "Roles", "")
                ' Borra registro de la tabla de FuncionesPorRol
                '-----------------------------------------------------------------------------------------------------------
                strUpdate = "DELETE FROM FuncionesPorRol WHERE RolId = " & RolId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina funciones del rol: " & RolName, RolId, "FuncionesPorRol", "")
                RolDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar el Rol: " & RolName, RolId, "Roles", "")
                RolDelete = False
            End Try
        End If
    End Function
    Public Function LeerRolByUserId(ByVal UserId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT Roles.RolId "
        sSQL = sSQL & "FROM Usuarios INNER JOIN Roles ON Usuarios.RolName = Roles.RolName "
        sSQL = sSQL & "WHERE (((Usuarios.[UsuariosId])=" & UserId & "))"

        LeerRolByUserId = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerRolByUserId = CLng(dtr("RolId").ToString)
            End While
            dtr.Close()
        Catch
            LeerRolByUserId = 0
        End Try
    End Function
    Public Function MostrarRol(ByRef CodigoHTML As String, ByVal IsAuthorizedUser As Boolean) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim strUpdate As String
        Dim Usuarios As New Usuarios

        strUpdate = "SELECT Roles.RolName As Name "
        strUpdate = strUpdate & "FROM Roles "
        strUpdate = strUpdate & "WHERE Roles.RolNivel < 6 "
        strUpdate = strUpdate & "ORDER BY Roles.RolNivel Asc"

        MostrarRol = False

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read

                CodigoHTML = CodigoHTML & "<div class=""AccordionPanel"">"
                CodigoHTML = CodigoHTML & "<div class=""AccordionPanelTab"">"
                CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td><h2>" & dtr("Name").ToString & "</h2></td>"
                CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & dtr("Name").ToString & "')"" /></td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "</table>"
                CodigoHTML = CodigoHTML & "</div>"
                CodigoHTML = CodigoHTML & "<div id=""subgrilla" & dtr("Name").ToString & """ class=""invisible"">"
                CodigoHTML = CodigoHTML & Usuarios.ListarUsuariosPorRol(dtr("Name").ToString, IsAuthorizedUser)
                CodigoHTML = CodigoHTML & "</div>"
                CodigoHTML = CodigoHTML & "</div>"
                MostrarRol = True
            End While
            dtr.Close()
        Catch
            MostrarRol = False
        End Try

    End Function
End Class
