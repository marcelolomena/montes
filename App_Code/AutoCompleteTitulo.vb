Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class AutoCompleteTitulo
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim DocumentosSGI As New DocumentosSGI
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim arrLabel(21) As String

        If DocumentosSGI.LeerTituloParaAutocomplete(arrLabel, prefixText, i) Then

            Dim items As New List(Of String)
            If i <> 0 Then
                For j = 0 To i - 1
                    items.Add(arrLabel(j))
                Next j

                Return items.ToArray()
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If

    End Function

End Class