
Partial Class PerfilUsuarios
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim UsuariosId As Long = CStr(Request.QueryString("Id"))
        Dim Usuarios As New Usuarios
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim Rol As New Rol
        Dim PaginaWeb As New PaginaWeb
        Dim Programas As New Programas
        Dim Acciones As New Acciones
        Dim Tareas As New Tareas
        Dim t As Boolean = False
        Dim PaginaWebName As String = Request.QueryString("PaginaWebName")
        Dim CodigoHTML As String = ""
        Dim FuncionesPorRolId As Long = 0
        Dim IsAuthorizedUser As Boolean = FuncionesPorRol.LeerFuncionesPorRol(Session("RolId"), CLng(Request.QueryString("MenuOptionsId")), "MenuOptions", FuncionesPorRolId)

        Dim UsuariosCodigo As String = ""
        Dim UsuariosClave As String = "" ' Etiqueta : Clave de acceso - Control : txtUsuariosClave - Variable : UsuariosClave
        Dim UsuariosName As String = "" ' Etiqueta : Nombre Completo - Control : txtUsuariosName - Variable : UsuariosName
        Dim RolName As String = Rol.LeerRolNameByRolId(Session("RolId")) ' Etiqueta : Rol - Control : txtRolName - Variable : RolName
        Dim UsuariosProfesion As String = ""
        Dim UsuariosUniversidad As String = ""
        Dim UsuariosCelular As String = ""
        Dim UsuariosTelefonoFijo As String = ""
        Dim UsuariosDireccion1 As String = ""
        Dim UsuariosDireccion2 As String = ""
        Dim UsuariosCorreo2 As String = ""

        If Session("PersonaId") = 0 Then Response.Redirect("LoginPampaNorte.aspx", True)
        If UsuariosId = 0 Then UsuariosId = CLng(Session("PersonaId"))
        t = Usuarios.LeerUsuarios(UsuariosId, UsuariosCodigo, UsuariosClave, UsuariosName, RolName, UsuariosProfesion, UsuariosUniversidad, UsuariosCelular, UsuariosTelefonoFijo, UsuariosDireccion1, UsuariosDireccion2, UsuariosCorreo2)


        'lblTitulo.Text = PaginaWeb.LeerPaginaWebTitle(PaginaWebName)
        lblUsuariosCodigo.Text = UsuariosCodigo
        lblUsuariosName.Text = UsuariosName
        lblRolName.Text = RolName
        lblRolDescription.Text = Rol.LeerRolDescriptionByName(RolName)
        lblUsuariosProfesion.Text = UsuariosProfesion
        lblUsuariosUniversidad.Text = UsuariosUniversidad
        lblUsuariosCelular.Text = UsuariosCelular
        lblUsuariosTelefonoFijo.Text = UsuariosTelefonoFijo
        lblUsuariosDireccion1.Text = UsuariosDireccion1
        lblUsuariosDireccion2.Text = UsuariosDireccion2
        lblUsuariosCorreo2.Text = UsuariosCorreo2

        CodigoHTML = CodigoHTML & "<div id=""Accordion1"" class=""Accordion"" tabindex=""0"" >"
        CodigoHTML = CodigoHTML & "<div class=""AccordionPanel"">"
        CodigoHTML = CodigoHTML & "<div class=""AccordionPanelTab"">"
        CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
        CodigoHTML = CodigoHTML & "<tr>"
        CodigoHTML = CodigoHTML & "<td><h2>" & "Funciones" & "</h2></td>"
        CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & "Funciones" & "')"" /></td>"
        CodigoHTML = CodigoHTML & "</tr>"
        CodigoHTML = CodigoHTML & "</table>"
        CodigoHTML = CodigoHTML & "</div>"
        CodigoHTML = CodigoHTML & "<div id=""subgrilla" & "Funciones" & """ class=""invisible"">"
        CodigoHTML = CodigoHTML & "<p>&nbsp;</p>"
        CodigoHTML = CodigoHTML & Acciones.ListarAccionesPorRol(RolName)
        CodigoHTML = CodigoHTML & "<p>&nbsp;</p>"
        CodigoHTML = CodigoHTML & "</div>"
        CodigoHTML = CodigoHTML & "</div>"
        CodigoHTML = CodigoHTML & "<div class=""AccordionPanel"">"
        CodigoHTML = CodigoHTML & "<div class=""AccordionPanelTab"">"
        CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
        CodigoHTML = CodigoHTML & "<tr>"
        CodigoHTML = CodigoHTML & "<td><h2>" & "Tareas en Ejecución" & "</h2></td>"
        CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & "Tareas" & "')"" /></td>"
        CodigoHTML = CodigoHTML & "</tr>"
        CodigoHTML = CodigoHTML & "</table>"
        CodigoHTML = CodigoHTML & "</div>"
        CodigoHTML = CodigoHTML & "<div id=""subgrilla" & "Tareas" & """ class=""invisible"">"
        'CodigoHTML = CodigoHTML & "<p>&nbsp;</p>"
        'CodigoHTML = CodigoHTML & Tareas.MostrarTareasPendientesPorUsuario(UsuariosCodigo)
        'CodigoHTML = CodigoHTML & "<p>&nbsp;</p>"

        CodigoHTML = CodigoHTML & "<div id=""Accordion1"" class=""Accordion"" tabindex=""0"" >"
        t = Tareas.MostrarTareasPorMes(CodigoHTML, IsAuthorizedUser, UsuariosCodigo)
        CodigoHTML = CodigoHTML & "</div>"


        CodigoHTML = CodigoHTML & "</div>"
        CodigoHTML = CodigoHTML & "</div>"
        CodigoHTML = CodigoHTML & "</div>"
        MyAccordion.Controls.Add(New LiteralControl(CodigoHTML))


    End Sub
End Class
