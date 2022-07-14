Imports AjaxControlToolkit
Partial Class FichaMoneda
Inherits System.Web.UI.UserControl
'------------------------------------------------------------
' Código generado por ZRISMART SF el 01-02-2011 11:22:22
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
Dim txtMonedaName As Textbox ' Etiqueta : Moneda - Control : txtMonedaName - Variable : MonedaName
Dim txtMonedaDescription As Textbox ' Etiqueta : Descripción - Control : txtMonedaDescription - Variable : MonedaDescription
Dim txtMonedaSecuencia As TextBox ' Etiqueta : Secuencia - Control : txtMonedaSecuencia - Variable : MonedaSecuencia
'----------------------------------------
' Declaración de Campos de la Aplicación
'----------------------------------------
Dim MonedaName As String ' Etiqueta : Moneda - Control : txtMonedaName - Variable : MonedaName
Dim MonedaDescription As String ' Etiqueta : Descripción - Control : txtMonedaDescription - Variable : MonedaDescription
Dim MonedaSecuencia As Long ' Etiqueta : Secuencia - Control : txtMonedaSecuencia - Variable : MonedaSecuencia
'----------------------------------------
Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
'Se pone solo por completitud
End Sub
Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
'Se pone solo por completitud
End Sub
Protected Sub RFC_Search(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchButton.Click
Dim Lecturas As New Lecturas
Dim t As Boolean = False
Dim Pagina As String = ""
Dim NombrePagina As String = ""
t = Lecturas.LeerURLStatementFormularioWeb("URLSearch", Pagina, NombrePagina, Session("NumeroPagina"))
Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
Response.Redirect(Url)
End Sub
Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
Dim Lecturas As New Lecturas
Dim t As Boolean
Dim Pagina As String = ""
Dim NombrePagina As String = ""
t = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))
Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
Response.Redirect(Url)
End Sub
Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
'Se pone solo por completitud
End Sub
Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
Dim Lecturas As New Lecturas
Dim t As Boolean
Dim Pagina As String = ""
Dim NombrePagina As String = ""
t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Request.QueryString("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
Dim AccionesABM As New AccionesABM
Dim Moneda As New Moneda
Try
t = Moneda.MonedaUpdate(Request.QueryString("Id"), CStr(txtMonedaName.Text), CStr(txtMonedaDescription.Text), CLng(txtMonedaSecuencia.Text), Session("PersonaId"))
Catch
t = 0
End Try
Response.Redirect(Url)
End Sub
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
Dim Lecturas As New Lecturas
Dim Moneda As New Moneda
Dim t As Boolean
Dim TituloPagina As String = ""
Dim DescripcionPagina As String = ""
Dim NumeroPagina As Integer = 0
Dim GroupValidation As String = ""
Dim PaginaWebName As String = ""
Dim sSQLWhere As String = ""
Dim sSQLOrder As String = ""
t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
Session("NumeroPagina") = NumeroPagina
Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
AddHandler UpdateButton.Click, AddressOf RFC_Update
AddHandler NewButton.Click, AddressOf RFC_New
AddHandler SearchButton.Click, AddressOf RFC_Search
If Not IsPostBack Then
If Request.QueryString("Id") <> 0 Then
If t = Moneda.LeerMoneda(Request.QueryString("Id"), MonedaName, MonedaDescription, MonedaSecuencia) Then
txtMonedaName = FindControl("txtMonedaName")
txtMonedaName.Text = MonedaName
txtMonedaDescription = FindControl("txtMonedaDescription")
txtMonedaDescription.Text = MonedaDescription
txtMonedaSecuencia = FindControl("txtMonedaSecuencia")
txtMonedaSecuencia.Text = MonedaSecuencia
Else
txtMonedaName = FindControl("txtMonedaName")
txtMonedaName.Text = Session("MonedaName")
End If
End If
Else
txtMonedaName = FindControl("txtMonedaName")
txtMonedaDescription = FindControl("txtMonedaDescription")
txtMonedaSecuencia = FindControl("txtMonedaSecuencia")
End If
End Sub
End Class
