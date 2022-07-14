Imports AjaxControlToolkit
Partial Class BuscaMoneda
Inherits System.Web.UI.UserControl
'------------------------------------------------------------
' Código generado por ZRISMART SF el 01-02-2011 11:22:54
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
Dim txtMonedaName As DropDownList ' Etiqueta : Moneda - Control : txtMonedaName - Variable : MonedaName
'----------------------------------------
' Declaración de Campos de la Aplicación
'----------------------------------------
Dim MonedaName As String ' Etiqueta : Moneda - Control : txtMonedaName - Variable : MonedaName
'----------------------------------------------------------------------------------------
' Declaración de controles de indicador de búsqueda por la variable asociado al checkbox
'----------------------------------------------------------------------------------------
Dim chktxtMonedaName As CheckBox ' Etiqueta : Moneda - Control : txtMonedaName - Variable : MonedaName
'----------------------------------------
Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
Dim Lecturas As New Lecturas
Dim t As Boolean
Dim Pagina As String = ""
Dim NombrePagina As String = ""
Dim Cantidad As Integer = 0
Dim Codigo As Long = 0
t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
Dim sSQLWhere As String = ""
Dim sSQL As String = ""
If chktxtMonedaName.Checked = True Then
If Len(sSQLWhere) = 0 Then
sSQLWhere = " Where MonedaName = '" & txtMonedaName.Text & "' "
Else
sSQLWhere = sSQLWhere & " AND MonedaName = '" & txtMonedaName.Text & "' "
End If
End If
If Len(sSQLWhere) > 0 Then
Url = Url & "&sSqlWhere=" & sSQLWhere
End If
lblMensaje.Visible = "False"
sSQL = "SELECT Count(*) AS Cantidad, Max(MonedaId) AS Codigo FROM Moneda" & sSQLWhere
t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)
If Cantidad > 1 Then
Response.Redirect(Url)  'Se pasa a la página que muestra la lista de comunas
Else
If Cantidad = 1 Then    'Se pasa a la página que muestra la ficha de la única comuna seleccionada
Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=Ficha de Moneda&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Codigo
Response.Redirect(Url)
Else
lblMensaje.Text = "No existen registros que cumplan con el criterio de selección"
lblMensaje.Visible = "True"
End If
End If
End Sub
Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
Dim Lecturas As New Lecturas
Dim t As Boolean
Dim TituloPagina As String = ""
Dim DescripcionPagina As String = ""
Dim NumeroPagina As Integer = 0
Dim GroupValidation As String = ""
Dim sSQLWhere As String = ""
t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
Session("NumeroPagina") = NumeroPagina
Call Lecturas.CrearFormularioLogin(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyTable, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
AddHandler UpdateButton.Click, AddressOf RFC_Update
txtMonedaName = FindControl("txtMonedaName")
chktxtMonedaName = FindControl("chktxtMonedaName")
End Sub
End Class
