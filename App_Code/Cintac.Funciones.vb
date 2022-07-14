Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Namespace ZRISMART.NET
    Public Class Funcion
        Private m_ReqId As Long = -1
        Private m_ObjectId As Long = -1
        Private m_Funcion As String = String.Empty
        Private m_Descripcion As String = String.Empty
        Public Sub New()

        End Sub
        Public Property ReqId() As Integer
            Get
                Return Me.m_ReqId
            End Get
            Set(ByVal value As Integer)
                Me.m_ReqId = value
            End Set
        End Property
        Public Property ObjectId() As String
            Get
                Return Me.m_ObjectId
            End Get
            Set(ByVal value As String)
                Me.m_ObjectId = value
            End Set
        End Property
        Public Property Funcion() As String
            Get
                Return Me.m_Funcion
            End Get
            Set(ByVal value As String)
                Me.m_Funcion = value
            End Set
        End Property
        Public Property Descripcion() As String
            Get
                Return Me.m_Descripcion
            End Get
            Set(ByVal value As String)
                Me.m_Descripcion = value
            End Set
        End Property
        Private Sub HidrateObject(ByVal reader As SqlDataReader)
            Me.m_ReqId = reader("ReqId")
            Me.m_ObjectId = reader("ObjectId")
            Me.m_Funcion = " "
            Me.m_Descripcion = " "
            Try
                If Len(reader("Funcion")) > 0 Then Me.m_Funcion = reader("Funcion")
                If Len(reader("Descripcion")) > 0 Then Me.m_Descripcion = reader("Descripcion")
            Catch

            End Try
        End Sub
        Public Shared Function Save(ByVal currentFuncion As Funcion) As Boolean
            Dim _Funcion As New Funcion
            Using _conn As New SqlConnection(EAConnectionManager.ConnectionString)
                Using _comm As New SqlCommand("UPDATE t_objectrequires SET Requirement = @Funcion, Notes = @Descripcion WHERE ReqId=@ReqId", _conn)
                    _comm.Parameters.AddWithValue("@ReqId", currentFuncion.ReqId)
                    _comm.Parameters.AddWithValue("@Funcion", currentFuncion.Funcion)
                    _comm.Parameters.AddWithValue("@Descripcion", currentFuncion.Descripcion)
                    _conn.Open()
                    _comm.ExecuteNonQuery()
                End Using
            End Using
            Return True
        End Function
        Public Shared Function GetOneNew() As Funcion
            Return New Funcion
        End Function
        Public Shared Function GetOne(ByVal ReqId As Long) As Funcion
            Dim _Funcion As New Funcion
            Using _conn As New SqlConnection(EAConnectionManager.ConnectionString)
                Using _comm As New SqlCommand("SELECT ReqId As ReqId, Object_Id As ObjectId, Requirement as Funcion, Notes as Descripcion FROM t_objectrequires WHERE ReqId=@ReqId", _conn)
                    _comm.Parameters.AddWithValue("@ReqId", ReqId)
                    _conn.Open()
                    Using _dr As SqlDataReader = _comm.ExecuteReader(CommandBehavior.CloseConnection Or CommandBehavior.SingleResult Or CommandBehavior.SingleRow)
                        While _dr.Read
                            _Funcion.HidrateObject(_dr)
                        End While
                        Return _Funcion
                    End Using
                End Using
            End Using
        End Function
        Public Shared Function GetAll(ByVal ObjectId As Long) As List(Of Funcion)
            Dim _Funciones As New List(Of Funcion)
            Using _conn As New SqlConnection(EAConnectionManager.ConnectionString)
                Using _comm As New SqlCommand("SELECT ReqId As ReqId, Object_Id As ObjectId, Requirement as Funcion, Notes as Descripcion FROM t_objectrequires WHERE Object_Id=@ObjectId", _conn)
                    _comm.Parameters.AddWithValue("@ObjectId", ObjectId)
                    _conn.Open()
                    Using _dr As SqlDataReader = _comm.ExecuteReader(CommandBehavior.CloseConnection Or CommandBehavior.SingleResult)
                        While _dr.Read
                            Dim _Funcion As New Funcion
                            _Funcion.HidrateObject(_dr)
                            _Funciones.Add(_Funcion)
                        End While
                        Return _Funciones
                    End Using
                End Using
            End Using
        End Function
    End Class

    Public Class Cargo
        Private m_NewParentId As Long = -1
        Private m_ObjectId As Long = -1
        Private m_ParentId As Long = -1
        Public Sub New()

        End Sub
        Public Property NewParentId() As Integer
            Get
                Return Me.m_NewParentId
            End Get
            Set(ByVal value As Integer)
                Me.m_NewParentId = value
            End Set
        End Property
        Public Property ObjectId() As Integer
            Get
                Return Me.m_ObjectId
            End Get
            Set(ByVal value As Integer)
                Me.m_ObjectId = value
            End Set
        End Property
        Public Property ParentId() As Integer
            Get
                Return Me.m_ParentId
            End Get
            Set(ByVal value As Integer)
                Me.m_ParentId = value
            End Set
        End Property
        Public Shared Function SaveNuevaDependencia(ByVal ObjectId As Long, ByVal NewParentId As Long) As Boolean
            Dim _Cargo As New Cargo
            _Cargo.ObjectId = ObjectId
            _Cargo.NewParentId = NewParentId
            Using _conn As New SqlConnection(EAConnectionManager.ConnectionString)
                Using _comm As New SqlCommand("SELECT ParentId FROM t_object WHERE Object_Id=@ObjectId", _conn)
                    _comm.Parameters.AddWithValue("@ObjectId", _Cargo.ObjectId)
                    _conn.Open()
                    Using _dr As SqlDataReader = _comm.ExecuteReader(CommandBehavior.CloseConnection Or CommandBehavior.SingleResult)
                        While _dr.Read
                            _Cargo.ParentId = _dr("ParentId")
                        End While
                    End Using
                End Using
            End Using

            Using _conn As New SqlConnection(EAConnectionManager.ConnectionString)
                Using _comm As New SqlCommand("UPDATE t_connector SET End_Object_Id = @NewParentId WHERE Start_Object_Id=@ObjectId AND End_Object_Id = @ParentId", _conn)
                    _comm.Parameters.AddWithValue("@NewParentId", _Cargo.NewParentId)
                    _comm.Parameters.AddWithValue("@ObjectId", _Cargo.ObjectId)
                    _comm.Parameters.AddWithValue("@ParentId", _Cargo.ParentId)
                    _conn.Open()
                    _comm.ExecuteNonQuery()
                    _conn.Close()
                End Using

            End Using

            Using _conn As New SqlConnection(EAConnectionManager.ConnectionString)
                Using _comm As New SqlCommand("UPDATE t_object SET ParentId = @NewParentId WHERE Object_Id=@ObjectId", _conn)
                    _comm.Parameters.AddWithValue("@NewParentId", _Cargo.NewParentId)
                    _comm.Parameters.AddWithValue("@ObjectId", _Cargo.ObjectId)
                    _conn.Open()
                    _comm.ExecuteNonQuery()
                    _conn.Close()
                End Using

            End Using



            Return True
        End Function


    End Class
End Namespace

