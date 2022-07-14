Partial Class ValidaEntidades
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
    Dim txtComunaName As TextBox
    Dim txtEstCargoName As TextBox
    Dim txtCargosName As TextBox
    Dim txtEMail As TextBox
    Dim txtRut As TextBox
    Dim txtPortalesName As TextBox
    Dim txtPaginaWebName As TextBox
    Dim txtPaginaWebGroupValidation As TextBox
    Dim txtPaginaWebStereotype As TextBox
    Dim txtPaginaWebUserControl As TextBox
    Dim valTextBox As RequiredFieldValidator
    Dim sumValidacion As ValidationSummary
    Dim REValidacion As RegularExpressionValidator
    Dim CuValidacion As CustomValidator
    Dim CoValidacion As CompareValidator

    ' Declaración de Campos de la Aplicación
    ' Campos de la entidad Comunas
    Dim ComunaId As Long
    Dim ComunaName As String
    ' Campos de la entidad Familia de Cargos - EstereotiposCargos
    Dim EstCargoId As Long
    Dim EstCargoName As String
    ' Campos de la entidad Cargos - Cargos
    Dim CargosId As Long
    Dim CargosName As String
    ' Campos de la Entidad Cliente - Cliente
    Dim ClienteId As Long
    Dim ClienteEMail As String
    Dim ClienteRut As String
    Dim ClienteName As String
    Dim ClienteApPaterno As String
    Dim ClienteApMaterno As String
    ' Campos de la entidad Portales - Portales
    Dim PortalesId As Long
    Dim PortalesName As String
    ' Campos de la entidad Paginas Web - PaginaWeb
    Dim PaginaWebId As Long
    Dim PaginaWebGroupValidation As String
    Dim PaginaWebStereotype As String
    Dim PaginaWebUserControl As String
    'Dim PaginaWebName As String
    ' Declaración de Variables de la Aplicación
    Dim t As Boolean
    Dim Logo As String = ""
    Dim BarMenu As String = ""
    Dim SideBarMenu As String = ""
    Dim PaginaWebName As String = ""
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogin", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim MasterId As Long = 0
        Dim MasterName As String = ""



        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina

        Try
            Select Case Request.QueryString("PaginaWebName")
                Case "Valida Comuna"
                    MasterName = txtComunaName.Text
                    MasterId = 0
                    t = Lecturas.LeerMasterIdByMasterName("ComunaId", "ComunaName", "Comuna", MasterName, MasterId)
                    If MasterId > 0 Then

                        Url = Url & "&Id=" & MasterId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                        Response.Redirect(Url)
                    Else
                        t = AccionesABM.MasterPartialInsert("ComunaId", "ComunaName", "Comuna", MasterName, CLng(Session("PersonaId")), MasterId)
                        Url = Url & "&Id=" & MasterId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                        Response.Redirect(Url)
                    End If
                Case "Valida EstCargo"
                    EstCargoName = txtEstCargoName.Text
                    Session("EstCargoName") = EstCargoName
                    EstCargoId = 0
                    t = Lecturas.LeerEstCargoByName(EstCargoName, EstCargoId)
                    If EstCargoId > 0 Then
                        Session("EstCargoId") = EstCargoId
                        Session("EstCargoName") = EstCargoName
                        Url = Url & "&Id=" & ComunaId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                        Response.Redirect(Url)
                    Else
                        t = AccionesABM.EstCargoPartialInsert(EstCargoName, CLng(Session("PersonaId")), EstCargoId)
                        Session("EstCargoId") = EstCargoId
                        Url = Url & "&Id=" & EstCargoId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                        Response.Redirect(Url)
                    End If
                Case "Valida Cargos"
                    CargosName = txtCargosName.Text
                    Session("CargosName") = CargosName
                    CargosId = 0
                    t = Lecturas.LeerCargoByName(CargosName, CargosId)
                    If CargosId > 0 Then
                        Session("CargosId") = CargosId
                        Session("CargosName") = CargosName
                        Url = Url & "&Id=" & ComunaId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                        Response.Redirect(Url)
                    Else
                        t = AccionesABM.CargosPartialInsert(CargosName, CLng(Session("PersonaId")), CargosId)
                        Session("CargosId") = CargosId
                        Url = Url & "&Id=" & CargosId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                        Response.Redirect(Url)
                    End If
                Case "Valida Cliente"
                    ClienteEMail = txtEMail.Text
                    ClienteRut = txtRut.Text
                    Session("EMail") = ClienteEMail
                    Session("Rut") = ClienteRut
                    ClienteId = 0
                    t = Lecturas.LeerRutYCorreoCliente(ClienteEMail, ClienteRut, ClienteId, ClienteName, ClienteApPaterno, ClienteApMaterno)
                    If ClienteId > 0 Then
                        Url = Url & "&Id=" & ClienteId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                        Response.Redirect(Url)
                    Else
                        t = AccionesABM.ClientePartialInsert(ClienteEMail, ClienteRut, ClienteId, ClienteName, ClienteApPaterno, ClienteApMaterno, Session("PersonaId"))
                        Url = Url & "&Id=" & ClienteId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                        Response.Redirect(Url)
                    End If
                Case "Valida Portales"
                    PortalesName = txtPortalesName.Text
                    Session("PortalesName") = PortalesName
                    PortalesId = 0
                    t = Lecturas.LeerPortalByName(PortalesName, PortalesId)
                    If PortalesId > 0 Then
                        Session("PortalesId") = PortalesId
                        Session("PortalesName") = PortalesName
                        Url = Url & "&Id=" & PortalesId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                        Response.Redirect(Url)
                    Else
                        t = AccionesABM.PortalesPartialInsert(PortalesName, CLng(Session("PersonaId")), PortalesId)
                        Session("PortalesId") = PortalesId
                        Url = Url & "&Id=" & PortalesId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                        Response.Redirect(Url)
                    End If
                Case "Valida Páginas"
                    PaginaWebName = txtPaginaWebName.Text
                    Session("PaginaWebName") = PaginaWebName
                    PaginaWebGroupValidation = txtPaginaWebGroupValidation.Text
                    Session("PaginaWebGroupValidation") = PaginaWebGroupValidation
                    PaginaWebStereotype = txtPaginaWebStereotype.Text
                    Session("PaginaWebStereotype") = PaginaWebStereotype
                    PaginaWebUserControl = txtPaginaWebUserControl.Text
                    Session("PaginaWEbUserControl") = PaginaWebUserControl
                    PaginaWebId = 0
                    t = Lecturas.LeerPaginaWebByName(PaginaWebName, PaginaWebId)
                    If PaginaWebId > 0 Then
                        Session("PaginaWebId") = PaginaWebId
                        Session("PaginaWebName") = PaginaWebName
                        Url = Url & "&Id=" & PaginaWebId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                        Response.Redirect(Url)
                    Else
                        t = AccionesABM.PaginaWebPartialInsert(PaginaWebName, PaginaWebGroupValidation, PaginaWebStereotype, PaginaWebUserControl, CLng(Session("PersonaId")), PaginaWebId)
                        Session("PaginaWebId") = PaginaWebId
                        Url = Url & "&Id=" & PaginaWebId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                        Response.Redirect(Url)
                    End If

            End Select
        Catch
            t = 0
        End Try
    End Sub
    Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogout", Pagina, NombrePagina, Session("NumeroPagina"))

        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
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

        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        Call Lecturas.CrearFormularioLogin(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyTable, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler LoginButton.Click, AddressOf RFC_Login
        AddHandler CancelButton.Click, AddressOf RFC_Logout

        If IsPostBack Then
            Select Case Request.QueryString("PaginaWebName")
                Case "Valida Comuna"
                    txtComunaName = FindControl("txtComunaName")
                Case "Valida EstCargo"
                    txtEstCargoName = FindControl("txtEstCargoName")
                Case "Valida Cargos"
                    txtCargosName = FindControl("txtCargosName")
                Case "Valida Cliente"
                    txtEMail = FindControl("txtEMail")
                    txtRut = FindControl("txtRut")
                Case "Valida Portales"
                    txtPortalesName = FindControl("txtPortalesName")
                Case "Valida Páginas"
                    txtPaginaWebName = FindControl("txtPaginaWebName")
                    txtPaginaWebGroupValidation = FindControl("txtPaginaWebGroupValidation")
                    txtPaginaWebStereotype = FindControl("txtPaginaWebStereotype")
                    txtPaginaWebUserControl = FindControl("txtPaginaWebUserControl")
            End Select
        End If

    End Sub
End Class
