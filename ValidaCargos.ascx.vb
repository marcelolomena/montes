Imports AjaxControlToolkit
Partial Class ValidaCargos
Inherits System.Web.UI.UserControl
'------------------------------------------------------------
' Código generado por ZRISMART SF el 18-04-2011 18:56:06
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
Dim txtMasterName As Textbox ' Etiqueta : Código - Control : txtMasterName - Variable : CargosCodigo
'----------------------------------------
' Declaración de Campos de la Aplicación
'----------------------------------------
Dim CargosCodigo As String ' Etiqueta : Código - Control : txtMasterName - Variable : CargosCodigo
'----------------------------------------
Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
Dim Lecturas As New Lecturas
Dim AccionesABM As New AccionesABM
Dim t As Boolean
Dim Pagina As String = ""
Dim NombrePagina As String = ""
t = Lecturas.LeerURLStatementFormularioWeb("URLLogin", Pagina, NombrePagina, Session("NumeroPagina"))
Dim MasterId As Long = 0
Dim MasterName As String = ""
Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina
Try
MasterName = txtMasterName.Text
MasterId = 0
t = Lecturas.LeerMasterIdByMasterName("CargosId", "CargosCodigo", "Cargos", MasterName, MasterId)
If MasterId > 0 Then
Url = Url & "&Id=" & MasterId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
Response.Redirect(Url)
Else
t = AccionesABM.MasterPartialInsert("CargosId", "CargosCodigo", "Cargos", MasterName, CLng(Session("PersonaId")), MasterId)
Url = Url & "&Id=" & MasterId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
Response.Redirect(Url)
End If
Catch
t = 0
End Try
End Sub
Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
Dim Lecturas As New Lecturas
Dim t As Boolean
Dim Pagina As String = ""
Dim NombrePagina As String = ""
t = Lecturas.LeerURLStatementFormularioWeb("URLLogout", Pagina, NombrePagina, Session("NumeroPagina"))
Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
Response.Redirect(Url)
End Sub
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
Dim Lecturas As New Lecturas
Dim t As Boolean
Dim TituloPagina As String = ""
Dim DescripcionPagina As String = ""
Dim NumeroPagina As Integer = 0
Dim GroupValidation As String = ""
t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
Session("NumeroPagina") = NumeroPagina
Call Lecturas.CrearFormularioLogin(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyTable, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
AddHandler LoginButton.Click, AddressOf RFC_Login
AddHandler CancelButton.Click, AddressOf RFC_Logout
If IsPostBack Then
txtMasterName = FindControl("txtMasterName")
End If
End Sub
End Class
