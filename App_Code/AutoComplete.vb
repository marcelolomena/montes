Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Collections.Generic

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<System.Web.Script.Services.ScriptService()> _
Public Class AutoComplete
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim Lecturas As New Lecturas
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim arrLabel(21) As String

        If Lecturas.LeerClienteParaAutocomplete(arrLabel, prefixText, i) Then

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
    <WebMethod()> _
    Public Function GetReqCargoNombreList(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim Lecturas As New Lecturas
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim arrLabel(21) As String

        If Lecturas.LeerReqCargoNombreParaAutocomplete(arrLabel, prefixText, i) Then

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
    <WebMethod()> _
    Public Function GetReqCargoNivelExigenciaList(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim Lecturas As New Lecturas
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim arrLabel(21) As String

        If Lecturas.LeerReqCargoNivelExigenciaParaAutocomplete(arrLabel, prefixText, i) Then

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
    <WebMethod()> _
    Public Function GetFunCargoGrupoList(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim Lecturas As New Lecturas
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim arrLabel(21) As String

        If Lecturas.LeerFunCargoGrupoParaAutocomplete(arrLabel, prefixText, i) Then

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
    <WebMethod()> _
    Public Function GetPaginaWebGroupValidationList(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim Lecturas As New Lecturas
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim arrLabel(21) As String

        If Lecturas.LeerPaginaWebGroupValidationParaAutocomplete(arrLabel, prefixText, i) Then

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
    <WebMethod()> _
    Public Function GetPaginaWebStereotypeList(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim Lecturas As New Lecturas
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim arrLabel(21) As String

        If Lecturas.LeerPaginaWebStereotypeParaAutocomplete(arrLabel, prefixText, i) Then

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
    <WebMethod()> _
    Public Function GetPaginaWebUserControlList(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim Lecturas As New Lecturas
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim arrLabel(21) As String

        If Lecturas.LeerPaginaWebUserControlParaAutocomplete(arrLabel, prefixText, i) Then

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
    <WebMethod()> _
    Public Function GetMenuOptionsClassList(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim Lecturas As New Lecturas
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim arrLabel(21) As String

        If Lecturas.LeerMenuOptionsClassParaAutocomplete(arrLabel, prefixText, i) Then

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
    <WebMethod()> _
    Public Function GetMenuOptionsTextoList(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim Lecturas As New Lecturas
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim arrLabel(21) As String

        If Lecturas.LeerMenuOptionsTextoParaAutocomplete(arrLabel, prefixText, i) Then

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
    <WebMethod()> _
    Public Function GetMenuOptionsLogoList(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim Lecturas As New Lecturas
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim arrLabel(21) As String

        If Lecturas.LeerMenuOptionsLogoParaAutocomplete(arrLabel, prefixText, i) Then

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
    <WebMethod()> _
    Public Function GetMenuOptionsBarMenuList(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim Lecturas As New Lecturas
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim arrLabel(21) As String

        If Lecturas.LeerMenuOptionsBarMenuParaAutocomplete(arrLabel, prefixText, i) Then

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
    <WebMethod()> _
    Public Function GetMenuOptionsSideBarMenuList(ByVal prefixText As String, ByVal count As Integer) As String()
        Dim Lecturas As New Lecturas
        Dim i As Integer = 0
        Dim j As Integer = 0
        Dim arrLabel(21) As String

        If Lecturas.LeerMenuOptionsSideBarMenuParaAutocomplete(arrLabel, prefixText, i) Then

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
