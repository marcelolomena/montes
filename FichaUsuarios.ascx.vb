Imports AjaxControlToolkit
Partial Class FichaUsuarios
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 15-03-2011 8:31:51
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
    Dim txtUsuariosCodigo As TextBox ' Etiqueta : Nombre de Usuario - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim txtUsuariosClave As TextBox ' Etiqueta : Clave de acceso - Control : txtUsuariosClave - Variable : UsuariosClave
    Dim txtUsuariosName As TextBox ' Etiqueta : Nombre Completo - Control : txtUsuariosName - Variable : UsuariosName
    Dim txtRolName As TextBox ' Etiqueta : Rol - Control : txtRolName - Variable : RolName
    Dim txtRolNameDescription As TextBox
    Dim txtUsuariosProfesion As TextBox
    Dim txtUsuariosUniversidad As TextBox
    Dim txtUsuariosCelular As TextBox
    Dim txtUsuariosTelefonoFijo As TextBox
    Dim txtUsuariosDireccion1 As TextBox
    Dim txtUsuariosDireccion2 As TextBox
    Dim txtUsuariosCorreo2 As TextBox
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim UsuariosCodigo As String ' Etiqueta : Nombre de Usuario - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim UsuariosClave As String ' Etiqueta : Clave de acceso - Control : txtUsuariosClave - Variable : UsuariosClave
    Dim UsuariosName As String ' Etiqueta : Nombre Completo - Control : txtUsuariosName - Variable : UsuariosName
    Dim RolName As String ' Etiqueta : Rol - Control : txtRolName - Variable : RolName
    Dim UsuariosProfesion As String
    Dim UsuariosUniversidad As String
    Dim UsuariosCelular As String
    Dim UsuariosTelefonoFijo As String
    Dim UsuariosDireccion1 As String
    Dim UsuariosDireccion2 As String
    Dim UsuariosCorreo2 As String
    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim Usuarios As New Usuarios
        Try
            t = Usuarios.UsuariosDelete(Request.QueryString("Id"), CStr(txtUsuariosCodigo.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
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
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogout", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Request.QueryString("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim AccionesABM As New AccionesABM
        Dim Usuarios As New Usuarios


        Try
            t = Usuarios.UsuariosUpdate(Request.QueryString("Id"), CStr(txtUsuariosCodigo.Text), CStr(txtUsuariosClave.Text), CStr(txtUsuariosName.Text), CStr(txtRolName.Text), CStr(txtUsuariosProfesion.Text), CStr(txtUsuariosUniversidad.Text), CStr(txtUsuariosCelular.Text), CStr(txtUsuariosTelefonoFijo.Text), CStr(txtUsuariosDireccion1.Text), CStr(txtUsuariosDireccion2.Text), CStr(txtUsuariosCorreo2.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Usuarios As New Usuarios
        Dim Rol As New Rol
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
                If t = Usuarios.LeerUsuarios(Request.QueryString("Id"), UsuariosCodigo, UsuariosClave, UsuariosName, RolName, UsuariosProfesion, UsuariosUniversidad, UsuariosCelular, UsuariosTelefonoFijo, UsuariosDireccion1, UsuariosDireccion2, UsuariosCorreo2) Then
                    txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
                    txtUsuariosCodigo.Text = UsuariosCodigo
                    txtUsuariosClave = FindControl("txtUsuariosClave")
                    txtUsuariosClave.Text = UsuariosClave
                    txtUsuariosName = FindControl("txtUsuariosName")
                    txtUsuariosName.Text = UsuariosName
                    txtRolName = FindControl("txtRolName")
                    txtRolName.Text = RolName
                    txtRolNameDescription = FindControl("txtRolNameDescription")
                    txtRolNameDescription.Text = Rol.LeerRolDescriptionByName(RolName)
                    txtUsuariosProfesion = FindControl("txtUsuariosProfesion")
                    txtUsuariosProfesion.Text = UsuariosProfesion
                    txtUsuariosUniversidad = FindControl("txtUsuariosUniversidad")
                    txtUsuariosUniversidad.Text = UsuariosUniversidad
                    txtUsuariosCelular = FindControl("txtUsuariosCelular")
                    txtUsuariosCelular.Text = UsuariosCelular
                    txtUsuariosTelefonoFijo = FindControl("txtUsuariosTelefonoFijo")
                    txtUsuariosTelefonoFijo.Text = UsuariosTelefonoFijo
                    txtUsuariosDireccion1 = FindControl("txtUsuariosDireccion1")
                    txtUsuariosDireccion1.Text = UsuariosDireccion1
                    txtUsuariosDireccion2 = FindControl("txtUsuariosDireccion2")
                    txtUsuariosDireccion2.Text = UsuariosDireccion2
                    txtUsuariosCorreo2 = FindControl("txtUsuariosCorreo2")
                    txtUsuariosCorreo2.Text = UsuariosCorreo2
                Else
                    txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
                    txtUsuariosCodigo.Text = Session("UsuariosCodigo")
                End If
            End If
        Else
            txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
            txtUsuariosClave = FindControl("txtUsuariosClave")
            txtUsuariosName = FindControl("txtUsuariosName")
            txtRolName = FindControl("txtRolName")
            txtUsuariosProfesion = FindControl("txtUsuariosProfesion")
            txtUsuariosUniversidad = FindControl("txtUsuariosUniversidad")
            txtUsuariosCelular = FindControl("txtUsuariosCelular")
            txtUsuariosTelefonoFijo = FindControl("txtUsuariosTelefonoFijo")
            txtUsuariosDireccion1 = FindControl("txtUsuariosDireccion1")
            txtUsuariosDireccion2 = FindControl("txtUsuariosDireccion2")
            txtUsuariosCorreo2 = FindControl("txtUsuariosCorreo2")
        End If
    End Sub
End Class
