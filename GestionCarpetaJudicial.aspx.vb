
Partial Class GestionCarpetaJudicial
    Inherits System.Web.UI.Page
    ' Declaración de Controles del Formulario
    Dim txtFecha As TextBox
    Dim chkCorreo As CheckBox
    Dim chkMuro As CheckBox
    Dim chkCritica As CheckBox

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim TareasCodigo As String = ""
        Dim UsuariosCodigo As String = ""
        Dim t As Boolean = True
        Dim CarpetaJudicialId As Long = CLng(Request.QueryString("Id"))
        Dim CarpetaJudicialCodigo As String = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
        Dim TareasId As Long = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)

        Dim CodigoHTML As String = "<p><h1>" & CarpetaJudicialCodigo & ": " & UCase(CarpetaJudicial.LeerApellidosDeudorByTareasId(TareasId)) & " CON SCOTIABANK </h1></p>"

        MyDeudor.Controls.Add(New LiteralControl(CodigoHTML))
        MyResponsable.Controls.Add(New LiteralControl(Tareas.ListarDatosDelResponsablePorTareasId(TareasId)))

        t = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)
        txtTareasCodigo.Text = TareasCodigo
        t = Usuarios.LeerUsuariosCodigoByUsuariosId(Session("PersonaId"), UsuariosCodigo)
        txtUsuariosCodigo.Text = UsuariosCodigo
        txtRol.Text = Usuarios.LeerRolNameByName(UsuariosCodigo)

        Call Lecturas.CrearCheckComentarios(MyTable)

        If IsPostBack Then
            txtFecha = FindControl("txtFecha")
            chkCorreo = FindControl("chkCorreo")
            chkMuro = FindControl("chkMuro")
            chkCritica = FindControl("chkCritica")
        End If

    End Sub
End Class
