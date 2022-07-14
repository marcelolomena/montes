Imports AjaxControlToolkit
Partial Class BuscaCarpetaJudicial
Inherits System.Web.UI.UserControl
'------------------------------------------------------------
' Código generado por ZRISMART SF el 24-02-2012 11:01:45
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
Dim txtCarpetaJudicialRut As DropDownList ' Etiqueta : Rut del deudor - Control : txtCarpetaJudicialRut - Variable : CarpetaJudicialRut
Dim txtCarpetaJudicialApellidos As DropDownList ' Etiqueta : Apellidos - Control : txtCarpetaJudicialApellidos - Variable : CarpetaJudicialApellidos
Dim txtCarpetaJudicialSaldoDeuda As DropDownList ' Etiqueta : Saldo deuda - Control : txtCarpetaJudicialSaldoDeuda - Variable : CarpetaJudicialSaldoDeuda
Dim txtCarpetaJudicialProcurador As DropDownList ' Etiqueta : Procurador - Control : txtCarpetaJudicialProcurador - Variable : CarpetaJudicialProcurador
Dim txtEstadoProcesoCodigo As DropDownList ' Etiqueta : Estado de la Demanda - Control : txtEstadoProcesoCodigo - Variable : EstadoProcesoCodigo
'----------------------------------------
' Declaración de Campos de la Aplicación
'----------------------------------------
Dim CarpetaJudicialRut As String ' Etiqueta : Rut del deudor - Control : txtCarpetaJudicialRut - Variable : CarpetaJudicialRut
Dim CarpetaJudicialApellidos As String ' Etiqueta : Apellidos - Control : txtCarpetaJudicialApellidos - Variable : CarpetaJudicialApellidos
Dim CarpetaJudicialSaldoDeuda As Double ' Etiqueta : Saldo deuda - Control : txtCarpetaJudicialSaldoDeuda - Variable : CarpetaJudicialSaldoDeuda
Dim CarpetaJudicialProcurador As String ' Etiqueta : Procurador - Control : txtCarpetaJudicialProcurador - Variable : CarpetaJudicialProcurador
Dim EstadoProcesoCodigo As String ' Etiqueta : Estado de la Demanda - Control : txtEstadoProcesoCodigo - Variable : EstadoProcesoCodigo
'----------------------------------------------------------------------------------------
' Declaración de controles de indicador de búsqueda por la variable asociado al checkbox
'----------------------------------------------------------------------------------------
Dim chktxtCarpetaJudicialRut As CheckBox ' Etiqueta : Rut del deudor - Control : txtCarpetaJudicialRut - Variable : CarpetaJudicialRut
Dim chktxtCarpetaJudicialApellidos As CheckBox ' Etiqueta : Apellidos - Control : txtCarpetaJudicialApellidos - Variable : CarpetaJudicialApellidos
Dim chktxtCarpetaJudicialSaldoDeuda As CheckBox ' Etiqueta : Saldo deuda - Control : txtCarpetaJudicialSaldoDeuda - Variable : CarpetaJudicialSaldoDeuda
Dim chktxtCarpetaJudicialProcurador As CheckBox ' Etiqueta : Procurador - Control : txtCarpetaJudicialProcurador - Variable : CarpetaJudicialProcurador
Dim chktxtEstadoProcesoCodigo As CheckBox ' Etiqueta : Estado de la Demanda - Control : txtEstadoProcesoCodigo - Variable : EstadoProcesoCodigo
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
If chktxtCarpetaJudicialRut.Checked = True Then
If Len(sSQLWhere) = 0 Then
sSQLWhere = " Where CarpetaJudicialRut = '" & txtCarpetaJudicialRut.Text & "' "
Else
sSQLWhere = sSQLWhere & " AND CarpetaJudicialRut = '" & txtCarpetaJudicialRut.Text & "' "
End If
End If
If chktxtCarpetaJudicialApellidos.Checked = True Then
If Len(sSQLWhere) = 0 Then
sSQLWhere = " Where CarpetaJudicialApellidos = '" & txtCarpetaJudicialApellidos.Text & "' "
Else
sSQLWhere = sSQLWhere & " AND CarpetaJudicialApellidos = '" & txtCarpetaJudicialApellidos.Text & "' "
End If
End If
If chktxtCarpetaJudicialSaldoDeuda.Checked = True Then
If Len(sSQLWhere) = 0 Then
sSQLWhere = " Where CarpetaJudicialSaldoDeuda = " & txtCarpetaJudicialSaldoDeuda.Text & " "
Else
sSQLWhere = sSQLWhere & " AND CarpetaJudicialSaldoDeuda = " & txtCarpetaJudicialSaldoDeuda.Text & " "
End If
End If
If chktxtCarpetaJudicialProcurador.Checked = True Then
If Len(sSQLWhere) = 0 Then
sSQLWhere = " Where CarpetaJudicialProcurador = '" & txtCarpetaJudicialProcurador.Text & "' "
Else
sSQLWhere = sSQLWhere & " AND CarpetaJudicialProcurador = '" & txtCarpetaJudicialProcurador.Text & "' "
End If
End If
If chktxtEstadoProcesoCodigo.Checked = True Then
If Len(sSQLWhere) = 0 Then
sSQLWhere = " Where EstadoProcesoCodigo = '" & txtEstadoProcesoCodigo.Text & "' "
Else
sSQLWhere = sSQLWhere & " AND EstadoProcesoCodigo = '" & txtEstadoProcesoCodigo.Text & "' "
End If
End If
If Len(sSQLWhere) > 0 Then
Url = Url & "&sSqlWhere=" & sSQLWhere
End If
lblMensaje.Visible = "False"
sSQL = "SELECT Count(*) AS Cantidad, Max(CarpetaJudicialId) AS Codigo FROM CarpetaJudicial" & sSQLWhere
t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)
If Cantidad > 1 Then
Response.Redirect(Url)  'Se pasa a la página que muestra la lista de comunas
Else
If Cantidad = 1 Then    'Se pasa a la página que muestra la ficha de la única comuna seleccionada
Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=Ficha de CarpetaJudicial&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Codigo
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
txtCarpetaJudicialRut = FindControl("txtCarpetaJudicialRut")
chktxtCarpetaJudicialRut = FindControl("chktxtCarpetaJudicialRut")
txtCarpetaJudicialApellidos = FindControl("txtCarpetaJudicialApellidos")
chktxtCarpetaJudicialApellidos = FindControl("chktxtCarpetaJudicialApellidos")
txtCarpetaJudicialSaldoDeuda = FindControl("txtCarpetaJudicialSaldoDeuda")
chktxtCarpetaJudicialSaldoDeuda = FindControl("chktxtCarpetaJudicialSaldoDeuda")
txtCarpetaJudicialProcurador = FindControl("txtCarpetaJudicialProcurador")
chktxtCarpetaJudicialProcurador = FindControl("chktxtCarpetaJudicialProcurador")
txtEstadoProcesoCodigo = FindControl("txtEstadoProcesoCodigo")
chktxtEstadoProcesoCodigo = FindControl("chktxtEstadoProcesoCodigo")
End Sub
End Class
