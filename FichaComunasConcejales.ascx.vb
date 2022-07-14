Imports AjaxControlToolkit
Partial Class FichaComunasConcejales
Inherits System.Web.UI.UserControl
'------------------------------------------------------------
' Código generado por ZRISMART SF el 18-10-2011 19:40:37
'------------------------------------------------------------
' Declaración de botones del formulario
'----------------------------------------
Dim WithEvents LoginButton As Button
Dim WithEvents UpdateButton As Button
Dim WithEvents CancelButton As Button
Dim WithEvents NewButton As Button
Dim WithEvents SearchButton As Button
Dim WithEvents DeleteButton As Button
Dim WithEvents ReturnButton As Button
'----------------------------------------
' Declaración de controles de validación
'----------------------------------------
Dim valTextBox As RequiredFieldValidator
Dim sumValidacion As ValidationSummary
Dim REValidacion As RegularExpressionValidator
Dim CuValidacion As CustomValidator
Dim CoValidacion As CompareValidator
'------------------------------------------
' Declaración de Variables de la Aplicación
'------------------------------------------
Dim t As Boolean = False
Dim Logo As String = ""
Dim BarMenu As String = ""
Dim SideBarMenu As String = ""
Dim PaginaWebName As String = ""
'----------------------------------------
' Declaración de Controles del Formulario
'----------------------------------------
Dim txtComunasCodigo As Textbox ' Etiqueta : Comuna - Control : txtComunasCodigo - Variable : ComunasCodigo
Dim txtComunasConcejalesSecuencia As TextBox ' Etiqueta : Secuencia - Control : txtComunasConcejalesSecuencia - Variable : ComunasConcejalesSecuencia
Dim txtComunasConcejalesNombre As Textbox ' Etiqueta : Nombre - Control : txtComunasConcejalesNombre - Variable : ComunasConcejalesNombre
'----------------------------------------
' Declaración de Campos de la Aplicación
'----------------------------------------
Dim ComunasCodigo As String ' Etiqueta : Comuna - Control : txtComunasCodigo - Variable : ComunasCodigo
Dim ComunasConcejalesSecuencia As Long ' Etiqueta : Secuencia - Control : txtComunasConcejalesSecuencia - Variable : ComunasConcejalesSecuencia
Dim ComunasConcejalesNombre As String ' Etiqueta : Nombre - Control : txtComunasConcejalesNombre - Variable : ComunasConcejalesNombre
'----------------------------------------
Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
Dim Lecturas As New Lecturas
Dim t As Boolean
Dim Pagina As String = ""
Dim NombrePagina As String = ""
t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
Dim AccionesABM As New AccionesABM
Dim ComunasConcejales As New ComunasConcejales
Try
t = ComunasConcejales.ComunasConcejalesDelete(Session("Id"), Request.QueryString("MasterName"), CLng(Session("PersonaId")))
Catch
t = 0
End Try
Response.Redirect(Url)
End Sub
Protected Sub RFC_Return(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReturnButton.Click
Dim Lecturas As New Lecturas
Dim t As Boolean
Dim Pagina As String = ""
Dim NombrePagina As String = ""
t = Lecturas.LeerURLStatementFormularioWeb("URLReturn", Pagina, NombrePagina, Session("NumeroPagina"))
Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
Response.Redirect(Url)
End Sub
Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
Dim Lecturas As New Lecturas
Dim t As Boolean
Dim Pagina As String = ""
Dim NombrePagina As String = ""
t = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))
Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & Request.QueryString("MasterName") & "&MasterId=" & Request.QueryString("MasterId")
Response.Redirect(Url)
End Sub
Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
Dim Lecturas As New Lecturas
Dim t As Boolean
Dim Pagina As String = ""
Dim NombrePagina As String = ""
t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Session("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & Request.QueryString("MasterName") & "&MasterId=" & Request.QueryString("MasterId")
Dim AccionesABM As New AccionesABM
Dim ComunasConcejales As New ComunasConcejales
Try
t = ComunasConcejales.ComunasConcejalesUpdate(Session("Id"), CStr(txtComunasCodigo.Text), CLng(txtComunasConcejalesSecuencia.Text), CStr(txtComunasConcejalesNombre.Text), Session("PersonaId"))
Catch
t = 0
End Try
Response.Redirect(Url)
End Sub
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
Dim Lecturas As New Lecturas
Dim AccionesABM As New AccionesABM
Dim ComunasConcejales As New ComunasConcejales
Dim t As Boolean
Dim TituloPagina As String = ""
Dim DescripcionPagina As String = ""
Dim NumeroPagina As Integer = 0
Dim GroupValidation As String = ""
Dim PaginaWebName As String = ""
Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
Dim MasterName As String = "" ' Guarda el nombre del Maestro al que pertenece el detalle
Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
Session("NumeroPagina") = NumeroPagina
Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
AddHandler UpdateButton.Click, AddressOf RFC_Update
AddHandler NewButton.Click, AddressOf RFC_New
AddHandler DeleteButton.Click, AddressOf RFC_Delete
AddHandler ReturnButton.Click, AddressOf RFC_Return
Try
If Not IsPostBack Then
MasterName = Request.QueryString("MasterName")
Session("MasterId") = Request.QueryString("MasterId")
DetailId = Request.QueryString("Id")
If DetailId = 0 Then
DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("ComunasCodigo", "ComunasConcejalesSecuencia", "ComunasConcejales", MasterName)
t = AccionesABM.ObjectPartialInsert("ComunasConcejalesId", "ComunasCodigo", "ComunasConcejalesSecuencia", "ComunasConcejales", MasterName, DetailSecuencia, CLng(Session("PersonaId")), DetailId)
End If
Session("Id") = DetailId
If t = ComunasConcejales.LeerComunasConcejales(Session("Id"), ComunasCodigo, ComunasConcejalesSecuencia, ComunasConcejalesNombre) Then
txtComunasCodigo = FindControl("txtComunasCodigo")
txtComunasCodigo.Text = ComunasCodigo
txtComunasConcejalesSecuencia = FindControl("txtComunasConcejalesSecuencia")
txtComunasConcejalesSecuencia.Text = ComunasConcejalesSecuencia
txtComunasConcejalesNombre = FindControl("txtComunasConcejalesNombre")
txtComunasConcejalesNombre.Text = ComunasConcejalesNombre
Else
txtComunasCodigo = FindControl("txtComunasCodigo")
txtComunasCodigo.Text = Session("ComunasCodigo")
txtComunasConcejalesSecuencia = FindControl("txtComunasConcejalesSecuencia")
txtComunasConcejalesSecuencia.Text = Session("ComunasConcejalesSecuencia")
End If
Else
txtComunasCodigo = FindControl("txtComunasCodigo")
txtComunasConcejalesSecuencia = FindControl("txtComunasConcejalesSecuencia")
txtComunasConcejalesNombre = FindControl("txtComunasConcejalesNombre")
End If
Catch
t = False
End Try
End Sub
End Class
