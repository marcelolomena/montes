
Partial Class LoginPampaNorte
    Inherits System.Web.UI.Page
    ' Declaración de Campos de la Aplicación
    Dim ClienteId As Long
    Dim ClienteEMail As String
    Dim ClienteRut As String
    Dim ClienteName As String
    Dim ClienteApPaterno As String
    Dim ClienteApMaterno As String
    ' Declaración de Campos de la Tabla Portales
    Dim PortalesId As Long = 0
    Dim PortalesName As String
    Dim PortalesURLIndex As String = ""
    Dim PortalesLogo1 As String = ""
    Dim PortalesBanner As String = ""
    Dim PortalesLogo2 As String = ""
    ' Declaración de Variables de la Aplicación
    Dim UsuariosCodigo As String ' Etiqueta : Nombre de Usuario - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim UsuariosClave As String ' Etiqueta : Clave de acceso - Control : txtUsuariosClave - Variable : UsuariosClave
    Dim UsuariosName As String ' Etiqueta : Nombre Completo - Control : txtUsuariosName - Variable : UsuariosName
    Dim RolName As String ' Etiqueta : Rol - Control : txtRolName - Variable : RolName
    Dim RolId As Long
    Dim t As Boolean
    Protected Sub LoginButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        Dim Lecturas As New Lecturas
        Dim Portales As New Portales
        Dim AccionesABM As New AccionesABM
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim Usuarios As New Usuarios
        Dim t As Integer
        Dim Url As String = ""
        Dim FuncionesPorRolId As Long = 0


        Try
            ClienteEMail = txtEMail.Text
            ClienteRut = txtRut.Text
            PortalesName = txtPortalesName.SelectedItem.Text
            PortalesId = txtPortalesName.SelectedItem.Value
            Session("EMail") = ClienteEMail
            Session("Rut") = ClienteRut
            Session("PortalesName") = PortalesName
            Session("PortalesId") = PortalesId
            ClienteId = 0

            If Usuarios.ValidarUsuario(ClienteEMail, ClienteRut, ClienteId, ClienteName, RolName, RolId) = True Then
                'El usuario esta registrado como tal
                Session("PersonaId") = ClienteId
                Session("PerNombre") = ClienteName
                Session("RolId") = RolId
                Session("RolName") = RolName
                Session("EMail") = ClienteEMail
                Session("Rut") = ClienteRut

                If FuncionesPorRol.LeerFuncionesPorRol(RolId, PortalesId, "Portales", FuncionesPorRolId) Then
                    'Puede acceder al portal seleccionado.
                    t = Portales.LeerURLPortal(PortalesId, PortalesURLIndex, PortalesLogo1, PortalesBanner, PortalesLogo2)

                    Url = PortalesURLIndex & "&Logo1=" & PortalesLogo1 & "&Banner=" & PortalesBanner & "&Logo2=" & PortalesLogo2
                    Session("Logo1") = PortalesLogo1
                    Session("Banner") = PortalesBanner
                    Session("Logo2") = PortalesLogo2
                    'Se envia a la página indicada en la URL contenida en la tabla Portales
                    Response.Redirect(Url)
                Else
                    MyMessage1.Text = "Usted no posee autorización de acceso al portal de " & PortalesName & ".<br /> Consulte con el administrador del sistema"
                End If

            Else
                MyMessage1.Text = "Usted no esta registrado o se encuentra inactivado. <br />Consulte con el administrador del sistema"
            End If
        Catch
            t = 0
            MyMessage1.Text = "Algo paso con la Url" & Url
        End Try
    End Sub

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim Portales As New Portales
        Dim t As Integer

        If Not IsPostBack Then
            t = Portales.LoadPortalesName(txtPortalesName)
        End If
    End Sub
End Class
