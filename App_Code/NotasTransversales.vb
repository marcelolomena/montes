Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.Xml
Imports AjaxControlToolkit

Public Class NotasTransversales
    Public Function NotasTransversalesInsert(ByVal Descripcion As String, _
                                ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim AccionesABM As New AccionesABM
        Dim Usuarios As New Usuarios
        Dim UsuariosCodigo As String = ""
        Dim UsuariosNombre As String = ""
        Dim t As Boolean
        Dim strUpdate As String

        t = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UsuariosCodigo)
        UsuariosNombre = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)

        strUpdate = "INSERT INTO NotasTransversales (NotasTransversalesTime, NotasTransversalesFrom, NotasTransversalesBody, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES ('" & AccionesABM.DateTransform(Now()) & "', '" & UsuariosNombre & "', '" & Descripcion & "', '" & AccionesABM.DateTransform(Now()) & "', " & UserId & ")"
        Try
            NotasTransversalesInsert = AccesoEA.ABMRegistros(strUpdate)
        Catch
            NotasTransversalesInsert = 0
        End Try
    End Function

    Public Function NotasTransversalesInsertAlerta(ByVal Descripcion As String, _
                                                   ByVal NotasTransversalesIsAlerta As Boolean, _
                                                   ByVal NotasTransversalesFechaCritica As Date, _
                                                   ByVal NotasTransversalesFueLeida As Boolean, _
                                                   ByVal NotasTransversalesFechaLectura As Date, _
                                                   ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim AccionesABM As New AccionesABM
        Dim Usuarios As New Usuarios
        Dim UsuariosCodigo As String = ""
        Dim UsuariosNombre As String = ""
        Dim t As Boolean
        Dim strUpdate As String

        t = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UsuariosCodigo)
        UsuariosNombre = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)

        strUpdate = "INSERT INTO NotasTransversales (NotasTransversalesTime, NotasTransversalesFrom, NotasTransversalesBody, NotasTransversalesIsAlerta, NotasTransversalesFechaCritica, NotasTransversalesFueLeida, NotasTransversalesFechaLectura, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES ('" & AccionesABM.DateTransform(Now()) & "', '" & UsuariosNombre & "', '" & Descripcion & "', " & NotasTransversalesIsAlerta & ", '" & AccionesABM.DateTransform(NotasTransversalesFechaCritica) & "', " & NotasTransversalesFueLeida & ", '" & AccionesABM.DateTransform(NotasTransversalesFechaLectura) & "', '" & AccionesABM.DateTransform(Now()) & "', " & UserId & ")"
        Try
            NotasTransversalesInsertAlerta = AccesoEA.ABMRegistros(strUpdate)
        Catch
            NotasTransversalesInsertAlerta = 0
        End Try
    End Function


    Public Function InsertarNotaTransversal(ByVal Descripcion As String, _
                                ByVal UserId As Long) As String

        Dim s As Integer
        Dim NotasTransversales As New NotasTransversales

        s = NotasTransversales.NotasTransversalesInsert(Descripcion, UserId)
        InsertarNotaTransversal = NotasTransversales.MostrarNotasTransversales(10, UserId)
    End Function
    Public Function NotaTransversalTodas(ByVal UserId As Long) As String

        Dim s As Integer
        Dim NotasTransversales As New NotasTransversales

        NotaTransversalTodas = NotasTransversales.MostrarNotasTransversales(100, UserId)
    End Function
    Public Function MostrarNotasTransversales(ByVal Cantidad As Integer, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim CodigoHTML As String = ""
        Dim dtr As IDataReader
        Dim strUpdate As String
        Dim NotasTransversales As New NotasTransversales
        Dim GetStakeholders As New GetStakeholders

        If Cantidad = 10 Then
            strUpdate = "SELECT Top " & Cantidad & " NotasTransversales.NotasTransversalesTime, NotasTransversales.NotasTransversalesFrom, NotasTransversales.NotasTransversalesBody, NotasTransversales.UserLastUpdate, NotasTransversales.NotasTransversalesId as Id, NotasTransversales.NotasTransversalesIsAlerta as IsAlerta, NotasTransversales.NotasTransversalesFechaCritica as FechaCritica, NotasTransversales.NotasTransversalesFueLeida as IsFueLeida, NotasTransversales.NotasTransversalesFechaLectura as FechaLectura "
            strUpdate = strUpdate & "FROM NotasTransversales "
            strUpdate = strUpdate & "WHERE NotasTransversales.NotasTransversalesFueLeida IS NULL "
            strUpdate = strUpdate & "ORDER BY NotasTransversales.NotasTransversalesTime DESC"
        Else
            strUpdate = "SELECT NotasTransversales.NotasTransversalesTime, NotasTransversales.NotasTransversalesFrom, NotasTransversales.NotasTransversalesBody, NotasTransversales.UserLastUpdate, NotasTransversales.NotasTransversalesId as Id, NotasTransversales.NotasTransversalesIsAlerta as IsAlerta, NotasTransversales.NotasTransversalesFechaCritica as FechaCritica, NotasTransversales.NotasTransversalesFueLeida as IsFueLeida, NotasTransversales.NotasTransversalesFechaLectura as FechaLectura "
            strUpdate = strUpdate & "FROM NotasTransversales "
            strUpdate = strUpdate & "WHERE NotasTransversales.NotasTransversalesFueLeida IS NULL "
            strUpdate = strUpdate & "ORDER BY NotasTransversales.NotasTransversalesTime DESC"
        End If

        MostrarNotasTransversales = ""

        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""alertas"">"

        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                Console.WriteLine("--------------------------------")
                Console.WriteLine(dtr("IsAlerta"))
                Console.WriteLine("--------------------------------")
                If Not String.IsNullOrEmpty(dtr("IsAlerta").ToString)  Then
                    MostrarNotasTransversales = MostrarNotasTransversales & "<tr><td width=""223"" style=""color:Red;"">" & dtr("NotasTransversalesTime").ToString & " " & dtr("NotasTransversalesBody").ToString & "<br />Quedan sólo " & DateDiff(DateInterval.Day, CDate(Now()), CDate(dtr("FechaCritica").ToString)) & " d&iacute;as<br /> (" & dtr("NotasTransversalesFrom").ToString & ")</td>"
                Else
                    MostrarNotasTransversales = MostrarNotasTransversales & "<tr><td width=""223"">" & dtr("NotasTransversalesTime").ToString & " " & dtr("NotasTransversalesBody").ToString & "<br /> (" & dtr("NotasTransversalesFrom").ToString & ")</td>"

                End If

                If UserId = CLng(dtr("UserLastUpdate").ToString) Then 'Se permite eliminar la nota
                    MostrarNotasTransversales = MostrarNotasTransversales & "<td width=""17"" align=""right""><img src=""img/eliminar.png"" alt=""Eliminar la Nota"" width=""8"" height=""8"" vspace=""2"" border=""0"" onclick=""DeleteNota(" & dtr("Id").ToString & ", " & UserId & ");"" title=""Marcar la Nota como leida"" style=""cursor:hand; vertical-align:bottom;"" /></td></tr>"
                Else
                    MostrarNotasTransversales = MostrarNotasTransversales & "<td width=""17"" align=""right""></td></tr>"
                End If

            End While
            Console.WriteLine("--------------------------------")
            Console.WriteLine(MostrarNotasTransversales)
            dtr.Close()
        Catch

            MostrarNotasTransversales = ""
        End Try
        CodigoHTML = CodigoHTML & MostrarNotasTransversales & "</table>"
        CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""alertas"">"
        CodigoHTML = CodigoHTML & "<tfoot><tr><td align=""right"" ><img src=""img/ver_todos.png"" alt=""Ver todas las notas"" title=""Ver todas las notas"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" onclick=""ListarTodas(" & UserId & ");"" /></td></tr></tfoot></table>"

        MostrarNotasTransversales = CodigoHTML

    End Function
    Public Function NotasTransversalesDelete(ByVal Id As Long, _
                                ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String

        'Las notas del muro no se borran, se marcan como leídas

        strUpdate = "UPDATE NotasTransversales SET "
        strUpdate = strUpdate & "NotasTransversales.NotasTransversalesFueLeida = True, "
        strUpdate = strUpdate & "NotasTransversales.NotasTransversalesFechaLectura = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "NotasTransversales.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "NotasTransversales.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE NotasTransversales.NotasTransversalesId = " & Id

        Try
            NotasTransversalesDelete = AccesoEA.ABMRegistros(strUpdate)
        Catch
            NotasTransversalesDelete = 0
        End Try
    End Function
    Public Function BorrarNotaTransversal(ByVal Id As Long, _
                                ByVal UserId As Long) As String

        Dim s As Integer
        Dim NotasTransversales As New NotasTransversales

        s = NotasTransversales.NotasTransversalesDelete(Id, UserId)
        BorrarNotaTransversal = NotasTransversales.MostrarNotasTransversales(10, UserId)
    End Function
End Class
