Imports AjaxControlToolkit
Partial Class BuscaGerencias
Inherits System.Web.UI.UserControl
'------------------------------------------------------------
' Código generado por ZRISMART SF el 13-04-2011 18:00:05
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
Dim txtUsuariosCodigo As DropDownList ' Etiqueta : Usuario Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim txtOrganizacionesCodigo As DropDownList ' Etiqueta : Área - Control : txtAreasName - Variable : AreasName
'----------------------------------------
' Declaración de Campos de la Aplicación
'----------------------------------------
Dim UsuariosCodigo As String ' Etiqueta : Usuario Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim OrganizacionesCodigo As String ' Etiqueta : Área - Control : txtAreasName - Variable : AreasName
'----------------------------------------------------------------------------------------
' Declaración de controles de indicador de búsqueda por la variable asociado al checkbox
'----------------------------------------------------------------------------------------
Dim chktxtUsuariosCodigo As CheckBox ' Etiqueta : Usuario Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim chktxtOrganizacionesCodigo As CheckBox ' Etiqueta : Área - Control : txtAreasName - Variable : AreasName
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
If chktxtUsuariosCodigo.Checked = True Then
If Len(sSQLWhere) = 0 Then
sSQLWhere = " Where UsuariosCodigo = '" & txtUsuariosCodigo.Text & "' "
Else
sSQLWhere = sSQLWhere & " AND UsuariosCodigo = '" & txtUsuariosCodigo.Text & "' "
End If
End If
        If chktxtOrganizacionesCodigo.Checked = True Then
            If Len(sSQLWhere) = 0 Then
                sSQLWhere = " Where OrganizacionesCodigo = '" & txtOrganizacionesCodigo.Text & "' "
            Else
                sSQLWhere = sSQLWhere & " AND OrganizacionesCodigo = '" & txtOrganizacionesCodigo.Text & "' "
            End If
        End If
If Len(sSQLWhere) > 0 Then
Url = Url & "&sSqlWhere=" & sSQLWhere
End If
lblMensaje.Visible = "False"
sSQL = "SELECT Count(*) AS Cantidad, Max(GerenciasId) AS Codigo FROM Gerencias" & sSQLWhere
t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)
If Cantidad > 1 Then
Response.Redirect(Url)  'Se pasa a la página que muestra la lista de comunas
Else
If Cantidad = 1 Then    'Se pasa a la página que muestra la ficha de la única comuna seleccionada
Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=Ficha de Gerencias&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Codigo
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
txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
chktxtUsuariosCodigo = FindControl("chktxtUsuariosCodigo")
        txtOrganizacionesCodigo = FindControl("txtOrganizacionesCodigo")
        chktxtOrganizacionesCodigo = FindControl("chktxtOrganizacionesCodigo")
End Sub
End Class
