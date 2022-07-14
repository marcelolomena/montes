Imports AjaxControlToolkit
Partial Class FichaComunasLocalidades
Inherits System.Web.UI.UserControl
'------------------------------------------------------------
' Código generado por ZRISMART SF el 19-10-2011 8:45:01
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
Dim txtComunasCodigo As Textbox ' Etiqueta : Código de Comuna - Control : txtComunasCodigo - Variable : ComunasCodigo
Dim txtComunasLocalidadesSecuencia As TextBox ' Etiqueta : Secuencia - Control : txtComunasLocalidadesSecuencia - Variable : ComunasLocalidadesSecuencia
Dim txtComunasLocalidadesNombre As Textbox ' Etiqueta : Localidad - Control : txtComunasLocalidadesNombre - Variable : ComunasLocalidadesNombre
'----------------------------------------
' Declaración de Campos de la Aplicación
'----------------------------------------
Dim ComunasCodigo As String ' Etiqueta : Código de Comuna - Control : txtComunasCodigo - Variable : ComunasCodigo
Dim ComunasLocalidadesSecuencia As Long ' Etiqueta : Secuencia - Control : txtComunasLocalidadesSecuencia - Variable : ComunasLocalidadesSecuencia
Dim ComunasLocalidadesNombre As String ' Etiqueta : Localidad - Control : txtComunasLocalidadesNombre - Variable : ComunasLocalidadesNombre
'----------------------------------------
Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
Dim Lecturas As New Lecturas
Dim t As Boolean
Dim Pagina As String = ""
Dim NombrePagina As String = ""
t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
Dim AccionesABM As New AccionesABM
Dim ComunasLocalidades As New ComunasLocalidades
Try
t = ComunasLocalidades.ComunasLocalidadesDelete(Session("Id"), Request.QueryString("MasterName"), CLng(Session("PersonaId")))
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
Dim ComunasLocalidades As New ComunasLocalidades
Try
t = ComunasLocalidades.ComunasLocalidadesUpdate(Session("Id"), CStr(txtComunasCodigo.Text), CLng(txtComunasLocalidadesSecuencia.Text), CStr(txtComunasLocalidadesNombre.Text), Session("PersonaId"))
Catch
t = 0
End Try
Response.Redirect(Url)
End Sub
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
Dim Lecturas As New Lecturas
Dim AccionesABM As New AccionesABM
Dim ComunasLocalidades As New ComunasLocalidades
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
DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("ComunasCodigo", "ComunasLocalidadesSecuencia", "ComunasLocalidades", MasterName)
t = AccionesABM.ObjectPartialInsert("ComunasLocalidadesId", "ComunasCodigo", "ComunasLocalidadesSecuencia", "ComunasLocalidades", MasterName, DetailSecuencia, CLng(Session("PersonaId")), DetailId)
End If
Session("Id") = DetailId
If t = ComunasLocalidades.LeerComunasLocalidades(Session("Id"), ComunasCodigo, ComunasLocalidadesSecuencia, ComunasLocalidadesNombre) Then
txtComunasCodigo = FindControl("txtComunasCodigo")
txtComunasCodigo.Text = ComunasCodigo
txtComunasLocalidadesSecuencia = FindControl("txtComunasLocalidadesSecuencia")
txtComunasLocalidadesSecuencia.Text = ComunasLocalidadesSecuencia
txtComunasLocalidadesNombre = FindControl("txtComunasLocalidadesNombre")
txtComunasLocalidadesNombre.Text = ComunasLocalidadesNombre
Else
txtComunasCodigo = FindControl("txtComunasCodigo")
txtComunasCodigo.Text = Session("ComunasCodigo")
txtComunasLocalidadesSecuencia = FindControl("txtComunasLocalidadesSecuencia")
txtComunasLocalidadesSecuencia.Text = Session("ComunasLocalidadesSecuencia")
End If
Else
txtComunasCodigo = FindControl("txtComunasCodigo")
txtComunasLocalidadesSecuencia = FindControl("txtComunasLocalidadesSecuencia")
txtComunasLocalidadesNombre = FindControl("txtComunasLocalidadesNombre")
End If
Catch
t = False
End Try
End Sub
End Class
