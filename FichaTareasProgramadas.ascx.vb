Imports AjaxControlToolkit
Partial Class FichaTareasProgramadas
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 12-04-2011 13:31:55
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
    Dim ProgramasMapaId As Long = 0
    Dim AccionesId As Long = 0
    Dim AccionesName As String = ""
    Dim AccionesDescription As String = ""
    '----------------------------------------
    ' Declaración de Controles del Formulario
    '----------------------------------------

    Dim txtTareasProgramadasFecha As TextBox
    Dim txtTareasProgramadasDescription As TextBox ' Etiqueta : Descripción - Control : txtAccionesDescription - Variable : AccionesDescription
    Dim txtUsuariosCodigo As TextBox ' Etiqueta : Indicador (KPI) - Control : txtIndicadoresCodigo - Variable : IndicadoresCodigo
    Dim txtUsuariosCodigoDescription As TextBox ' Etiqueta : Meta - Control : txtMetasCodigo - Variable : MetasCodigo
    Dim txtStakeholdersCodigo As TextBox ' Etiqueta : Meta - Control : txtMetasCodigo - Variable : MetasCodigo
    Dim txtProgramasCodigo As TextBox ' Etiqueta : Código - Control : txtAccionesCodigo - Variable : AccionesCodigo
    Dim txtAccionesCodigo As TextBox
    Dim txtAccionesName As TextBox
    Dim txtAccionesDescription As TextBox

    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim TareasProgramadasFecha As Date
    Dim TareasProgramadasDescription As String
    Dim UsuariosCodigo As String ' Etiqueta : Indicador (KPI) - Control : txtIndicadoresCodigo - Variable : IndicadoresCodigo
    Dim AccionesPorStakeholdersPorProgramaId As Long
    Dim TareasId As Long
    Dim ProgramasCodigo As String ' Etiqueta : Código - Control : txtAccionesCodigo - Variable : AccionesCodigo
    Dim AccionesCodigo As String ' Etiqueta : Acción - Control : txtAccionesName - Variable : AccionesName
    Dim StakeholdersCodigo As String ' Etiqueta : Meta - Control : txtMetasCodigo - Variable : MetasCodigo
    '-----------------------------------------
    ' Otras variables
    '-----------------------------------------



    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim AccionesPorStakeholdersPorPrograma As New AccionesPorStakeholdersPorPrograma
        Dim TareasProgramadas As New TareasProgramadas
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        t = AccionesPorStakeholdersPorPrograma.LeerProgramaMapaIdYAccionesId(AccionesPorStakeholdersPorProgramaId, ProgramasMapaId, AccionesId)
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & AccionesPorStakeholdersPorProgramaId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterId=" & ProgramasMapaId
        Dim AccionesABM As New AccionesABM
        Dim Mensaje As String = ""

        Try
            t = TareasProgramadas.TareasProgramadasDelete(Request.QueryString("Id"), Mensaje, CLng(Session("PersonaId")))
            If t = False Then
                MyMessage1.Text = Mensaje
            End If
        Catch ex As Exception
            t = False
        End Try

        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Search(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim AccionesPorStakeholdersPorPrograma As New AccionesPorStakeholdersPorPrograma
        Dim TareasProgramadas As New TareasProgramadas
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        t = AccionesPorStakeholdersPorPrograma.LeerProgramaMapaIdYAccionesId(AccionesPorStakeholdersPorProgramaId, ProgramasMapaId, AccionesId)
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & AccionesPorStakeholdersPorProgramaId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterId=" & ProgramasMapaId
        Dim AccionesABM As New AccionesABM

        Try
            t = TareasProgramadas.TareasProgramadasInsert(CDate(txtTareasProgramadasFecha.Text), txtTareasProgramadasDescription.Text, txtUsuariosCodigo.Text, AccionesPorStakeholdersPorProgramaId, CLng(Session("PersonaId")))
        Catch ex As Exception
            t = False
        End Try

        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim AccionesPorStakeholdersPorPrograma As New AccionesPorStakeholdersPorPrograma
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogout", Pagina, NombrePagina, Session("NumeroPagina"))
        t = AccionesPorStakeholdersPorPrograma.LeerProgramaMapaIdYAccionesId(AccionesPorStakeholdersPorProgramaId, ProgramasMapaId, AccionesId)
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & AccionesPorStakeholdersPorProgramaId & "&MasterId=" & ProgramasMapaId

        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim AccionesPorStakeholdersPorPrograma As New AccionesPorStakeholdersPorPrograma
        Dim TareasProgramadas As New TareasProgramadas
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        t = AccionesPorStakeholdersPorPrograma.LeerProgramaMapaIdYAccionesId(AccionesPorStakeholdersPorProgramaId, ProgramasMapaId, AccionesId)
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & AccionesPorStakeholdersPorProgramaId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterId=" & ProgramasMapaId
        Dim AccionesABM As New AccionesABM

        Try
            t = TareasProgramadas.TareasProgramadasUpdate(Request.QueryString("Id"), CDate(txtTareasProgramadasFecha.Text), CStr(txtTareasProgramadasDescription.Text), CStr(txtUsuariosCodigo.Text), AccionesPorStakeholdersPorProgramaId, TareasId, CStr(txtProgramasCodigo.Text), AccionesCodigo, CStr(txtStakeholdersCodigo.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim AccionesPorStakeholdersPorPrograma As New AccionesPorStakeholdersPorPrograma
        Dim TareasProgramadas As New TareasProgramadas
        Dim Empresas As New Empresas
        Dim Usuarios As New Usuarios
        Dim Stakeholders As New Stakeholders
        Dim Acciones As New Acciones
        Dim Tareas As New Tareas
        Dim ProgramasMapa As New ProgramasMapa
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim PaginaWebName As String = ""
        Dim TareasCodigo As String = ""
        Dim sSQLWhere As String = ""
        Dim sSQLOrder As String = ""
        AccionesPorStakeholdersPorProgramaId = Request.QueryString("MasterId")

        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler SearchButton.Click, AddressOf RFC_Search
        AddHandler DeleteButton.Click, AddressOf RFC_Delete
        AddHandler CancelButton.Click, AddressOf RFC_Logout
        t = AccionesPorStakeholdersPorPrograma.LeerProgramaMapaIdYAccionesId(AccionesPorStakeholdersPorProgramaId, ProgramasMapaId, AccionesId)
        t = ProgramasMapa.LeerProgramasMapaProgramaYStakeholder(ProgramasMapaId, ProgramasCodigo, StakeholdersCodigo)
        t = Acciones.LeerAccionesNameAndDescription(AccionesId, AccionesCodigo, AccionesName, AccionesDescription)
        If Not IsPostBack Then
            If Request.QueryString("Id") <> 0 Then
                'Si existe se puede solo eliminar
                UpdateButton.Visible = False
                NewButton.Visible = False
                SearchButton.Visible = False
                DeleteButton.Visible = True
                If t = TareasProgramadas.LeerTareasProgramadas(Request.QueryString("Id"), TareasProgramadasFecha, TareasProgramadasDescription, UsuariosCodigo, AccionesPorStakeholdersPorProgramaId, TareasId, ProgramasCodigo, AccionesCodigo, StakeholdersCodigo) Then
                    txtProgramasCodigo = FindControl("txtProgramasCodigo")
                    txtProgramasCodigo.Text = ProgramasCodigo
                    txtTareasProgramadasFecha = FindControl("txtTareasProgramadasFecha")
                    txtTareasProgramadasFecha.Text = TareasProgramadasFecha
                    txtTareasProgramadasFecha.Enabled = False
                    txtTareasProgramadasDescription = FindControl("txtTareasProgramadasDescription")
                    txtTareasProgramadasDescription.Text = TareasProgramadasDescription
                    txtTareasProgramadasDescription.Enabled = False
                    txtStakeholdersCodigo = FindControl("txtStakeholdersCodigo")
                    txtStakeholdersCodigo.Text = StakeholdersCodigo
                    txtUsuariosCodigo = FindControl("txtusuariosCodigo")
                    txtUsuariosCodigo.Text = UsuariosCodigo
                    txtUsuariosCodigo.Enabled = False
                    txtUsuariosCodigoDescription = FindControl("txtUsuariosCodigoDescription")
                    txtUsuariosCodigoDescription.Text = UsuariosCodigo
                    txtAccionesCodigo = FindControl("txtAccionesCodigo")
                    txtAccionesCodigo.Text = AccionesCodigo
                    txtAccionesName = FindControl("txtAccionesName")
                    txtAccionesName.Text = AccionesName
                    txtAccionesDescription = FindControl("txtAccionesDescription")
                    txtAccionesDescription.Text = AccionesDescription
                    t = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)
                    ' Se agregar para mostrar las listas de registros asociados en las tablas hijas
                    sSQLWhere = ""
                    sSQLOrder = ""
                    Call Lecturas.CreateTabs(NumeroPagina, TareasCodigo, TareasId, MyTabs, "TareasCodigo", sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"), TareasId, "Tareas", Session("PersonaId"))


                Else
                    'Este camino es un error no es muy factible que pueda ocurrir.
                    txtProgramasCodigo = FindControl("txtProgramasCodigo")
                    txtProgramasCodigo.Text = ProgramasCodigo
                    txtTareasProgramadasFecha = FindControl("txtTareasProgramadasFecha")
                    txtTareasProgramadasFecha.Text = ""
                    txtTareasProgramadasDescription = FindControl("txtTareasProgramadasDescription")
                    txtTareasProgramadasDescription.Text = ""
                    txtStakeholdersCodigo = FindControl("txtStakeholdersCodigo")
                    txtStakeholdersCodigo.Text = StakeholdersCodigo
                    txtUsuariosCodigo = FindControl("txtusuariosCodigo")
                    txtUsuariosCodigo.Text = ""
                    txtAccionesCodigo = FindControl("txtAccionesCodigo")
                    txtAccionesCodigo.Text = AccionesCodigo
                    txtAccionesName = FindControl("txtAccionesName")
                    txtAccionesName.Text = AccionesName
                    txtAccionesDescription = FindControl("txtAccionesDescription")
                    txtAccionesDescription.Text = AccionesDescription
                End If
            Else
                'Significa que la Tarea no existe y por ello solo la podemos crear.
                UpdateButton.Visible = False
                NewButton.Visible = True
                SearchButton.Visible = False
                DeleteButton.Visible = False
                txtProgramasCodigo = FindControl("txtProgramasCodigo")
                txtProgramasCodigo.Text = ProgramasCodigo
                txtTareasProgramadasFecha = FindControl("txtTareasProgramadasFecha")
                txtTareasProgramadasFecha.Text = ""
                txtTareasProgramadasDescription = FindControl("txtTareasProgramadasDescription")
                txtTareasProgramadasDescription.Text = ""
                txtStakeholdersCodigo = FindControl("txtStakeholdersCodigo")
                txtStakeholdersCodigo.Text = StakeholdersCodigo
                txtUsuariosCodigo = FindControl("txtusuariosCodigo")
                txtUsuariosCodigo.Text = ""
                txtAccionesCodigo = FindControl("txtAccionesCodigo")
                txtAccionesCodigo.Text = AccionesCodigo
                txtAccionesName = FindControl("txtAccionesName")
                txtAccionesName.Text = AccionesName
                txtAccionesDescription = FindControl("txtAccionesDescription")
                txtAccionesDescription.Text = AccionesDescription
            End If
        Else
            txtProgramasCodigo = FindControl("txtProgramasCodigo")
            txtTareasProgramadasFecha = FindControl("txtTareasProgramadasFecha")
            txtTareasProgramadasDescription = FindControl("txtTareasProgramadasDescription")
            txtStakeholdersCodigo = FindControl("txtStakeholdersCodigo")
            txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
            txtAccionesCodigo = FindControl("txtAccionesCodigo")
            txtAccionesName = FindControl("txtAccionesName")
            txtAccionesDescription = FindControl("txtAccionesDescription")
        End If
    End Sub
End Class
