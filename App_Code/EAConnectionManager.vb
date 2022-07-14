Imports Microsoft.VisualBasic
Namespace ZRISMART.NET
    Public Class EAConnectionManager
        Private Sub New()

        End Sub

        Public Shared ReadOnly Property ConnectionString() As String
            Get
                Return ConfigurationManager.ConnectionStrings("CintacConnectionString").ConnectionString
                'Return "Server=localhost;UID=eauser;PWD=Ea196908;Database=ea"
            End Get
        End Property
    End Class
End Namespace

