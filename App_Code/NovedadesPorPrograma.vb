Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit

Public Class NovedadesPorPrograma
    Public Function NovedadesPorProgramaInsert(ByVal Descripcion As String, _
                                                ByVal ProgramasId As Long, _
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

        strUpdate = "INSERT INTO NovedadesPorPrograma (NovedadesPorProgramaTime, NovedadesPorProgramaFrom, NovedadesPorProgramaBody, ProgramasId, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES ('" & AccionesABM.DateTransform(Now()) & "', '" & UsuariosNombre & "', '" & Descripcion & "', " & ProgramasId & ", '" & AccionesABM.DateTransform(Now()) & "', " & UserId & ")"
        Try
            NovedadesPorProgramaInsert = AccesoEA.ABMRegistros(strUpdate)
        Catch
            NovedadesPorProgramaInsert = 0
        End Try
    End Function

    Public Function InsertarNovedadesPorPrograma(ByVal Descripcion As String, _
                                                 ByVal ProgramasId As Long, _
                                ByVal UserId As Long) As String

        Dim s As Integer
        Dim NovedadesPorPrograma As New NovedadesPorPrograma

        s = NovedadesPorPrograma.NovedadesPorProgramaInsert(Descripcion, ProgramasId, UserId)
        InsertarNovedadesPorPrograma = NovedadesPorPrograma.MostrarNovedadesPorPrograma(10, ProgramasId, UserId)
    End Function
    Public Function MostrarNovedadesPorPrograma(ByVal Cantidad As Integer, ByVal ProgramasId As Long, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim CodigoHTML As String = ""
        Dim dtr As IDataReader
        Dim strUpdate As String
        Dim NotasTransversales As New NotasTransversales

        If Cantidad = 10 Then
            strUpdate = "SELECT Top " & Cantidad & " NovedadesPorPrograma.NovedadesPorProgramaTime, NovedadesPorPrograma.NovedadesPorProgramaFrom, NovedadesPorPrograma.NovedadesPorProgramaBody, NovedadesPorPrograma.UserLastUpdate, NovedadesPorPrograma.NovedadesPorProgramaId as Id "
            strUpdate = strUpdate & "FROM(NovedadesPorPrograma) WHERE NovedadesPorPrograma.ProgramasId = " & ProgramasId
            strUpdate = strUpdate & " ORDER BY NovedadesPorPrograma.NovedadesPorProgramaTime DESC"
        Else
            strUpdate = "SELECT NovedadesPorPrograma.NovedadesPorProgramaTime, NovedadesPorPrograma.NovedadesPorProgramaFrom, NovedadesPorPrograma.NovedadesPorProgramaBody, NovedadesPorPrograma.UserLastUpdate, NovedadesPorPrograma.NovedadesPorProgramaId as Id "
            strUpdate = strUpdate & "FROM(NovedadesPorPrograma) WHERE NovedadesPorPrograma.ProgramasId = " & ProgramasId
            strUpdate = strUpdate & " ORDER BY NovedadesPorPrograma.NovedadesPorProgramaTime DESC"
        End If

        MostrarNovedadesPorPrograma = ""
        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" id=""noticias"">"
        'CodigoHTML = CodigoHTML & "<tr><th scope=""col"">Novedades</th></tr>"
        Try
            dtr = AccesoEA.ListarRegistros(strUpdate)
            While dtr.Read
                If UserId = CLng(dtr("UserLastUpdate").ToString) Then 'Se permite eliminar la nota
                    'strUpdate = "<img src=""img/botones/b_eliminar.png"" alt=""Eliminar la Novedad"" onclick=""DeleteNovedades(" & dtr("Id").ToString & ", " & ProgramasId & ", " & UserId & ");"" title=""Eliminar la Novedad"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0""  />"
                    'MostrarNovedadesPorPrograma = MostrarNovedadesPorPrograma & "<tr><td>" & dtr("NovedadesPorProgramaTime").ToString & " " & dtr("NovedadesPorProgramaBody").ToString & " [" & dtr("NovedadesPorProgramaFrom").ToString & "] " & strUpdate & "</td></tr>"
                    MostrarNovedadesPorPrograma = MostrarNovedadesPorPrograma & "<tr><td>" & dtr("NovedadesPorProgramaTime").ToString & " " & dtr("NovedadesPorProgramaBody").ToString & "</td></tr>"
                Else
                    MostrarNovedadesPorPrograma = MostrarNovedadesPorPrograma & "<tr><td>" & dtr("NovedadesPorProgramaTime").ToString & " " & dtr("NovedadesPorProgramaBody").ToString & "</td></tr>"
                End If

            End While
            dtr.Close()
        Catch
            MostrarNovedadesPorPrograma = ""
        End Try
        CodigoHTML = CodigoHTML & MostrarNovedadesPorPrograma & "</table>"
        CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""alertas"">"
        CodigoHTML = CodigoHTML & "<tfoot><tr><td align=""right"" ><img src=""img/ver_todos.png"" alt=""Ver todas las novedades"" title=""Ver todas las novedades"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" onclick=""ListarNovedadesTodas(" & ProgramasId & ", " & UserId & ");"" /></td></tr></tfoot></table>"
        MostrarNovedadesPorPrograma = CodigoHTML
    End Function
    Public Function NovedadesPorProgramaDelete(ByVal Id As Long, _
                                                ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String

        strUpdate = "Delete From NovedadesPorPrograma Where NovedadesPorProgramaId = " & Id
        Try
            NovedadesPorProgramaDelete = AccesoEA.ABMRegistros(strUpdate)
        Catch
            NovedadesPorProgramaDelete = 0
        End Try
    End Function
    Public Function BorrarNovedadesPorPrograma(ByVal Id As Long, _
                                               ByVal ProgramasId As Long, _
                                ByVal UserId As Long) As String

        Dim s As Integer
        Dim NovedadesPorPrograma As New NovedadesPorPrograma

        s = NovedadesPorPrograma.NovedadesPorProgramaDelete(Id, UserId)
        BorrarNovedadesPorPrograma = NovedadesPorPrograma.MostrarNovedadesPorPrograma(10, ProgramasId, UserId)
    End Function
    Public Function NovedadesTodas(ByVal ProgramasId As Long, _
                                ByVal UserId As Long) As String

        Dim s As Integer
        Dim NovedadesPorPrograma As New NovedadesPorPrograma

        NovedadesTodas = NovedadesPorPrograma.MostrarNovedadesPorPrograma(100, ProgramasId, UserId)
    End Function
End Class
