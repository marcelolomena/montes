Partial Class Login
    Inherits System.Web.UI.UserControl
    ' Declaración de Botones del Formulario
    Dim WithEvents LoginButton As Button
    Dim WithEvents CancelButton As Button
    Dim WithEvents UpdateButton As Button
    Dim WithEvents NewButton As Button
    Dim WithEvents SearchButton As Button
    Dim WithEvents DeleteButton As Button
    Dim WithEvents ReturnButton As Button
    ' Declaración de Controles del Formulario
    Dim txtEMail As TextBox
    Dim txtRut As TextBox
    Dim txtPortalesName As DropDownList
    Dim valTextBox As RequiredFieldValidator
    Dim sumValidacion As ValidationSummary
    Dim REValidacion As RegularExpressionValidator
    Dim CuValidacion As CustomValidator
    Dim CoValidacion As CompareValidator
    ' Declaración de Campos de la Aplicación
    Dim ClienteId As Long
    Dim ClienteEMail As String
    Dim ClienteRut As String
    Dim ClienteName As String
    Dim ClienteApPaterno As String
    Dim ClienteApMaterno As String
    ' Declaración de Campos de la Tabla Portales
    Dim PortalesName As String
    ' Declaración de Variables de la Aplicación
    Dim UsuariosCodigo As String ' Etiqueta : Nombre de Usuario - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim UsuariosClave As String ' Etiqueta : Clave de acceso - Control : txtUsuariosClave - Variable : UsuariosClave
    Dim UsuariosName As String ' Etiqueta : Nombre Completo - Control : txtUsuariosName - Variable : UsuariosName
    Dim RolName As String ' Etiqueta : Rol - Control : txtRolName - Variable : RolName
    Dim RolId As Long
    Dim t As Boolean
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim Usuarios As New Usuarios
        Dim t As Integer
        Dim Url As String = "AdministraEntidades.aspx?Pagina=Bienvenida&SideBar=Control de Acceso&PaginaWebName=PrimerRegistro"
        Dim PortalesURLIndex As String = ""
        Dim PortalesLogo1 As String = ""
        Dim PortalesBanner As String = ""
        Dim PortalesLogo2 As String = ""

        Try
            ClienteEMail = txtEMail.Text
            ClienteRut = txtRut.Text
            PortalesName = txtPortalesName.Text
            Session("EMail") = ClienteEMail
            Session("Rut") = ClienteRut
            ClienteId = 0
            't = Lecturas.LeerRutYCorreoCliente(ClienteEMail, ClienteRut, ClienteId, ClienteName, ClienteApPaterno, ClienteApMaterno)

            If Usuarios.ValidarUsuario(ClienteEMail, ClienteRut, ClienteId, ClienteName, RolName, RolId) = True Then
                Session("PersonaId") = ClienteId
                Session("PerNombre") = ClienteName
                Session("RolId") = RolId
                Session("RolName") = RolName
                Session("EMail") = ClienteEMail
                Session("Rut") = ClienteRut
                t = Lecturas.LeerURLPortal(PortalesName, PortalesURLIndex, PortalesLogo1, PortalesBanner, PortalesLogo2)
                Url = PortalesURLIndex & "&Logo1=" & PortalesLogo1 & "&Banner=" & PortalesBanner & "&Logo2=" & PortalesLogo2
                Session("Logo1") = PortalesLogo1
                Session("Banner") = PortalesBanner
                Session("Logo2") = PortalesLogo2
                'Url = "AdministraEntidades.aspx?Pagina=Cotizacion&SideBar=Módulo de Cotización&MenuOptionsId=86"
                'Url = "IndexSGI.aspx?Pagina=MenuSGI&SideBar=PrincipalSGI&PaginaWebName=Por definir&MenuOptionsId=174"

                Response.Redirect(Url)
            Else
                MyMessage1.Text = "El usuario no esta registrado o se encuentra inactivado, consulte con el administrador del sistema"
                'Url = "Login.aspx"
                'Response.Redirect(Url)
            End If
        Catch
            t = 0
        End Try
    End Sub
    Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Dim Url As String = "Login.aspx"

        Session("PersonaId") = 0
        Session("PerNombre") = ""
        Session("EMail") = ""
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""

        t = Lecturas.LeerPaginaWeb("Login", TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)

        Call Lecturas.CrearFormularioLogin(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyTable, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler LoginButton.Click, AddressOf RFC_Login
        AddHandler CancelButton.Click, AddressOf RFC_Logout
        CancelButton.Visible = False
        If IsPostBack Then
            txtEMail = FindControl("txtEMail")
            txtRut = FindControl("txtRut")
            txtPortalesName = FindControl("txtPortalesName")
        End If
    End Sub
End Class
