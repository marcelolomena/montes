Imports Microsoft.VisualBasic

Public Class Body
    ' Fields
    Public borderColor As String
    Public borderThickness As Integer
    Public fillColor As String
    Public height As Integer
    Public id As Integer
    Public label As String
    Public link As String
    Public textColor As String
    Public width As Integer
End Class

Public Class Foot
    ' Fields
    Public barColor As String
    Public barWidth As Integer
    Public borderColor As String
    Public borderThickness As Integer
    Public fillColor As String
    Public height As Integer
    Public id As Integer
    Public label As String
    Public link As String
    Public value As Integer
    Public width As Integer
End Class

Public Class Meta
    ' Fields
    Public deltay As Integer
    Public maxChars As Integer
End Class

Public Class StakeholderMap
    ' Fields
    Public body As Body
    Public feet As List(Of Foot) = New List(Of Foot)
    Public meta As Meta
End Class
