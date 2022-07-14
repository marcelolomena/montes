'------------------------------------------------------------
' Código generado por ZRISMART SF el 29-03-2011 23:35:51
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class Personas
Public Function LeerPersonas(ByVal PersonaId As Long, ByRef PerNombre As String, ByRef PerMail As String, ByRef UserPassword As String, ByRef PerEstado As Long, ByRef FecEstado As Date, ByRef PersonasCostoUFHora As Double) As Boolean
Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PerNombre, PerMail, UserPassword, PerEstado, FecEstado, PersonasCostoUFHora "
        sSQL = sSQL & "FROM (Personas) "
        sSQL = sSQL & "WHERE (Personas.PersonaId = " & PersonaId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                PerNombre = CStr(dtr("PerNombre").ToString)
                PerMail = CStr(dtr("PerMail").ToString)
                UserPassword = CStr(dtr("UserPassword").ToString)
                If Len(dtr("PerEstado").ToString) = 0 Then
                    PerEstado = 0
                Else
                    PerEstado = CLng(dtr("PerEstado").ToString)
                End If
                If Len(dtr("FecEstado").ToString) = 0 Then
                    FecEstado = "01/01/01"
                Else
                    FecEstado = CDate(dtr("FecEstado").ToString)
                End If
                If Len(dtr("PersonasCostoUFHora").ToString) = 0 Then
                    PersonasCostoUFHora = 0
                Else
                    PersonasCostoUFHora = CDbl(dtr("PersonasCostoUFHora").ToString)
                End If
            End While
            LeerPersonas = True
            dtr.Close()
        Catch
            LeerPersonas = False
        End Try
    End Function
    Public Function LeerPersonasByName(ByRef PersonaId As Long, ByVal PerNombre As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select PersonaId "
        sSQL = sSQL & "FROM (Personas) "
        sSQL = sSQL & "WHERE (Personas.PerNombre = '" & PerNombre & "') "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                PersonaId = CLng(dtr("PersonaId").ToString)
            End While
            LeerPersonasByName = True
            dtr.Close()
        Catch
            LeerPersonasByName = False
        End Try
    End Function
Public Function PersonasUpdate(ByVal PersonaId As Long, ByRef PerNombre As String, ByRef PerMail As String, ByRef UserPassword As String, ByRef PerEstado As Long, ByRef FecEstado As Date, ByRef PersonasCostoUFHora As Double, ByVal UserId As Long) As Integer
Dim AccesoEA As New AccesoEA
Dim strUpdate As String
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
strUpdate = "UPDATE Personas SET "
strUpdate = strUpdate & "Personas.PerNombre = '" & PerNombre & "', "
strUpdate = strUpdate & "Personas.PerMail = '" & PerMail & "', "
strUpdate = strUpdate & "Personas.UserPassword = '" & UserPassword & "', "
strUpdate = strUpdate & "Personas.PerEstado = " & PerEstado & ", "
strUpdate = strUpdate & "Personas.FecEstado = '" & AccionesABM.DateTransform(FecEstado) & "', "
strUpdate = strUpdate & "Personas.PersonasCostoUFHora = " & PersonasCostoUFHora & ", "
strUpdate = strUpdate & "Personas.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
strUpdate = strUpdate & "Personas.UserLastUpdate = " & UserId & " "
strUpdate = strUpdate & "WHERE Personas.PersonaId = " & PersonaId
Try
PersonasUpdate = AccesoEA.ABMRegistros(strUpdate)
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & PerNombre, PersonaId, "Personas", "")
Catch
PersonasUpdate = 0
t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & PerNombre, PersonaId, "Personas", "")
End Try
End Function
Public Function PersonasInsert(ByRef PersonaId As Long, ByRef PerNombre As String, ByRef PerMail As String, ByRef UserPassword As String, ByRef PerEstado As Long, ByRef FecEstado As Date, ByRef PersonasCostoUFHora As Double, ByVal UserId As Long) As Integer
Dim Lecturas As New Lecturas
Dim AccionesABM As New AccionesABM
Dim t As Integer = 0
Dim Personas As New Personas
Dim MasterId As Long = 0
Dim MasterName As String = ""
Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
Try
MasterName = PerNombre
MasterId = 0
t = Lecturas.LeerMasterIdByMasterName("PersonaId", "PerNombre", "Personas", MasterName, MasterId)
If MasterId = 0 Then
t = AccionesABM.MasterPartialInsert("PersonaId", "PerNombre", "Personas", MasterName, CLng(UserId), MasterId)
End If
PersonasInsert = Personas.PersonasUpdate(MasterId, CStr(PerNombre), CStr(PerMail), CStr(UserPassword), CLng(PerEstado), CDate(FecEstado), CDbl(PersonasCostoUFHora), UserId)
Catch
PersonasInsert = 0
End Try
End Function
End Class
