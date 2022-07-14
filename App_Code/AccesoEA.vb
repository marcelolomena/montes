Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Public Class AccesoEA
    Dim cn As SqlConnection
    Dim cmd As SqlCommand
    'Dim cn As OleDbConnection
    'Dim cmd As OleDbCommand
    Public Function ListarRegistros(ByVal sSQL As String) As SqlDataReader
    'Public Function ListarRegistros(ByVal sSQL As String) As IDataReader
        'Dim objDataDir As Object = AppDomain.CurrentDomain.GetData("DataDirectory")
        'Dim dataDirectory As String = TryCast(objDataDir, String)
        Console.WriteLine(sSQL)
        'cn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\BDCAS.mdb")
        cn = New SqlConnection("Server=localhost;UID=sa;PWD=Password_01;Database=montes")
        Try
        cn.Open()
        cmd = New SqlCommand(sSQL, cn)
        'cmd = New OleDbCommand(sSQL, cn)
        'Try
            ListarRegistros = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection)
            Return ListarRegistros
        Catch ex As Exception
            'Return Nothing
            Console.WriteLine(ex.ToString)
            Console.WriteLine()
            Return Nothing
        End Try
    End Function
    Public Function ABMRegistros(ByVal sSQL As String) As Integer

        'cn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\BDCAS.mdb")
        cn = New SqlConnection("Server=localhost;UID=sa;PWD=Password_01;Database=montes")
        'Console.WriteLine("picochico!!!!!!!!")
        cn.Open()

        cmd = New SqlCommand(sSQL, cn)
        'cmd = New OleDbCommand(sSQL, cn)

        Try
            ABMRegistros = cmd.ExecuteNonQuery
        Catch ex As Exception
            MsgBox("Could not connect")
            ABMRegistros = 0
        End Try

        cn.Close()
    End Function

    Public Function ObtenerSchema(ByVal sSQL As String) As IDataReader

        'cn = New OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\BDCAS.mdb")
        cn = New SqlConnection("Server=localhost;UID=sa;PWD=Password_01;Database=montes")
        cn.Open()
        cmd = New SqlCommand(sSQL, cn)
        'cmd = New OleDbCommand(sSQL, cn)
        Try
            ObtenerSchema = cmd.ExecuteReader(System.Data.CommandBehavior.KeyInfo Or CommandBehavior.SchemaOnly)
            Return ObtenerSchema
        Catch
            Return Nothing
        End Try
    End Function

End Class
