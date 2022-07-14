Imports AjaxControlToolkit
Partial Class BuscaTareas
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 24-04-2011 8:53:39
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
    Dim txtPGGCodigo As DropDownList ' Etiqueta : Código del PGG - Control : txtPGGCodigo - Variable : PGGCodigo
    Dim txtAccionesCodigo As DropDownList ' Etiqueta : Acción del PGG - Control : txtAccionesCodigo - Variable : AccionesCodigo
    Dim txtTareasMes As DropDownList ' Etiqueta : Mes - Control : txtTareasMes - Variable : TareasMes
    Dim txtTareasAno As DropDownList ' Etiqueta : Año - Control : txtTareasAno - Variable : TareasAno
    Dim txtUsuariosCodigo As DropDownList ' Etiqueta : Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim txtTareasTipo As DropDownList ' Etiqueta : Tipo de Tarea - Control : txtTareasTipo - Variable : TareasTipo
    Dim txtEstadoTareasCodigo As DropDownList ' Etiqueta : Estado de Tarea - Control : txtEstadoTareasCodigo - Variable : EstadoTareasCodigo
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim PGGCodigo As String ' Etiqueta : Código del PGG - Control : txtPGGCodigo - Variable : PGGCodigo
    Dim AccionesCodigo As String ' Etiqueta : Acción del PGG - Control : txtAccionesCodigo - Variable : AccionesCodigo
    Dim TareasMes As Long ' Etiqueta : Mes - Control : txtTareasMes - Variable : TareasMes
    Dim TareasAno As String ' Etiqueta : Año - Control : txtTareasAno - Variable : TareasAno
    Dim UsuariosCodigo As String ' Etiqueta : Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim TareasTipo As String ' Etiqueta : Tipo de Tarea - Control : txtTareasTipo - Variable : TareasTipo
    Dim EstadoTareasCodigo As String ' Etiqueta : Estado de Tarea - Control : txtEstadoTareasCodigo - Variable : EstadoTareasCodigo
    '----------------------------------------------------------------------------------------
    ' Declaración de controles de indicador de búsqueda por la variable asociado al checkbox
    '----------------------------------------------------------------------------------------
    Dim chktxtPGGCodigo As CheckBox ' Etiqueta : Código del PGG - Control : txtPGGCodigo - Variable : PGGCodigo
    Dim chktxtAccionesCodigo As CheckBox ' Etiqueta : Acción del PGG - Control : txtAccionesCodigo - Variable : AccionesCodigo
    Dim chktxtTareasMes As CheckBox ' Etiqueta : Mes - Control : txtTareasMes - Variable : TareasMes
    Dim chktxtTareasAno As CheckBox ' Etiqueta : Año - Control : txtTareasAno - Variable : TareasAno
    Dim chktxtUsuariosCodigo As CheckBox ' Etiqueta : Responsable - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim chktxtTareasTipo As CheckBox ' Etiqueta : Tipo de Tarea - Control : txtTareasTipo - Variable : TareasTipo
    Dim chktxtEstadoTareasCodigo As CheckBox ' Etiqueta : Estado de Tarea - Control : txtEstadoTareasCodigo - Variable : EstadoTareasCodigo
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
        Dim sSQLOrder As String = " &sSQLOrderBy=Order by TareasAno, TareasMes, TareasSecuencia, TareasCodigo"
        Dim sSQL As String = ""
        If chktxtPGGCodigo.Checked = True Then
            If Len(sSQLWhere) = 0 Then
                sSQLWhere = " AND PGGCodigo = '" & txtPGGCodigo.Text & "' "
            Else
                sSQLWhere = sSQLWhere & " AND PGGCodigo = '" & txtPGGCodigo.Text & "' "
            End If
        End If
        If chktxtAccionesCodigo.Checked = True Then
            If Len(sSQLWhere) = 0 Then
                sSQLWhere = " AND AccionesCodigo = '" & txtAccionesCodigo.Text & "' "
            Else
                sSQLWhere = sSQLWhere & " AND AccionesCodigo = '" & txtAccionesCodigo.Text & "' "
            End If
        End If
        If chktxtTareasMes.Checked = True Then
            If Len(sSQLWhere) = 0 Then
                sSQLWhere = " AND TareasMes = " & txtTareasMes.Text & " "
            Else
                sSQLWhere = sSQLWhere & " AND TareasMes = " & txtTareasMes.Text & " "
            End If
        End If
        If chktxtTareasAno.Checked = True Then
            If Len(sSQLWhere) = 0 Then
                sSQLWhere = " AND TareasAno = '" & txtTareasAno.Text & "' "
            Else
                sSQLWhere = sSQLWhere & " AND TareasAno = '" & txtTareasAno.Text & "' "
            End If
        End If
        If chktxtUsuariosCodigo.Checked = True Then
            If Len(sSQLWhere) = 0 Then
                sSQLWhere = " AND UsuariosCodigo = '" & txtUsuariosCodigo.Text & "' "
            Else
                sSQLWhere = sSQLWhere & " AND UsuariosCodigo = '" & txtUsuariosCodigo.Text & "' "
            End If
        End If
        If chktxtTareasTipo.Checked = True Then
            If Len(sSQLWhere) = 0 Then
                sSQLWhere = " AND TareasTipo = '" & txtTareasTipo.Text & "' "
            Else
                sSQLWhere = sSQLWhere & " AND TareasTipo = '" & txtTareasTipo.Text & "' "
            End If
        End If
        If chktxtEstadoTareasCodigo.Checked = True Then
            If Len(sSQLWhere) = 0 Then
                sSQLWhere = " AND EstadoTareasCodigo = '" & txtEstadoTareasCodigo.Text & "' "
            Else
                sSQLWhere = sSQLWhere & " AND EstadoTareasCodigo = '" & txtEstadoTareasCodigo.Text & "' "
            End If
        End If
        If Len(sSQLWhere) > 0 Then
            Url = Url & "&sSqlWhere=" & sSQLWhere
        End If
        Url = Url & sSQLOrder
        lblMensaje.Visible = "False"
        sSQL = "SELECT Count(*) AS Cantidad, Max(TareasId) AS Codigo FROM Tareas Where (Tareas.EstadoTareasCodigo = 'Asignada' OR Tareas.EstadoTareasCodigo = 'Rechazada' OR Tareas.EstadoTareasCodigo = 'Aceptada' OR Tareas.EstadoTareasCodigo = 'Reasignada') " & sSQLWhere
        t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)
        If Cantidad > 1 Then
            Response.Redirect(Url)  'Se pasa a la página que muestra la lista de comunas
        Else
            If Cantidad = 1 Then    'Se pasa a la página que muestra la ficha de la única comuna seleccionada
                Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=Ficha de Tareas&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Codigo
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
        txtPGGCodigo = FindControl("txtPGGCodigo")
        chktxtPGGCodigo = FindControl("chktxtPGGCodigo")
        txtAccionesCodigo = FindControl("txtAccionesCodigo")
        chktxtAccionesCodigo = FindControl("chktxtAccionesCodigo")
        txtTareasMes = FindControl("txtTareasMes")
        chktxtTareasMes = FindControl("chktxtTareasMes")
        txtTareasAno = FindControl("txtTareasAno")
        chktxtTareasAno = FindControl("chktxtTareasAno")
        txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
        chktxtUsuariosCodigo = FindControl("chktxtUsuariosCodigo")
        txtTareasTipo = FindControl("txtTareasTipo")
        chktxtTareasTipo = FindControl("chktxtTareasTipo")
        txtEstadoTareasCodigo = FindControl("txtEstadoTareasCodigo")
        chktxtEstadoTareasCodigo = FindControl("chktxtEstadoTareasCodigo")
    End Sub
End Class
