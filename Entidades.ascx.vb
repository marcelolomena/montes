Imports AjaxControlToolkit
Partial Class Entidades
    Inherits System.Web.UI.UserControl
    ' Declaración de botones del formulario
    Dim WithEvents LoginButton As Button
    Dim WithEvents UpdateButton As Button
    Dim WithEvents CancelButton As Button
    Dim WithEvents NewButton As Button
    Dim WithEvents SearchButton As Button
    Dim WithEvents DeleteButton As Button
    Dim WithEvents ReturnButton As Button
    ' sqlSource para las aplicaciones MasterDetail
    Dim sqlSourceRequisitos As AccessDataSource
    Dim sqlSourceFunciones As AccessDataSource
    Dim sSQL As String
    ' Declaración de Controles del Formulario
    '----------------------------------------
    ' Comunas
    Dim txtComunaName As TextBox
    Dim txtComunaDescription As TextBox
    Dim txtComunaCodigoCorreos As TextBox
    Dim txtComunaProvincia As DropDownList
    Dim txtComunaRegion As DropDownList
    ' Familias de Cargos
    Dim txtEstCargoName As TextBox
    Dim txtEstCargoDescription As TextBox
    Dim txtEstCargoSecuencia As TextBox
    Dim txtEstCargoPlanta As TextBox
    ' Cargos
    Dim txtCargosName As TextBox
    Dim txtCargosDescription As TextBox
    Dim ddlEstCargoName As DropDownList
    ' Clientes
    Dim txtEMail As TextBox
    Dim txtRut As TextBox
    Dim txtName As TextBox
    Dim txtApPaterno As TextBox
    Dim txtApMaterno As TextBox
    Dim txtCalle As TextBox
    Dim txtNumero As TextBox
    Dim txtDepartamento As TextBox
    Dim txtComuna As DropDownList
    Dim txtCiudad As TextBox
    Dim txtTelefonoParticular As TextBox
    Dim txtCelular As TextBox
    Dim txtTelefonoComercial1 As TextBox
    Dim txtTelefonoComercial2 As TextBox
    Dim txtFNacimiento As TextBox
    ' Portales
    Dim txtPortalesName As TextBox
    Dim txtPortalesDescription As TextBox
    Dim txtPortalesSecuencia As TextBox
    ' PaginaWeb
    Dim txtPaginaWebName As TextBox
    Dim txtPaginaWebTitle As TextBox
    Dim txtPaginaWebDescription As TextBox
    Dim txtFormularioWebNumber As TextBox
    Dim txtPaginaWebGroupValidation As TextBox
    Dim txtPaginaWebStereotype As TextBox
    Dim txtPaginaWebUserControl As TextBox
    ' Declaración de controles de validación
    Dim valTextBox As RequiredFieldValidator
    Dim sumValidacion As ValidationSummary
    Dim REValidacion As RegularExpressionValidator
    Dim CuValidacion As CustomValidator
    Dim CoValidacion As CompareValidator
    ' Declaración de Campos de la Aplicación
    ' Comunas
    Dim ComunaId As Long
    Dim ComunaName As String
    Dim ComunaDescription As String
    Dim ComunaCodigoCorreos As String
    Dim ComunaProvincia As String
    Dim ComunaRegion As String
    ' Familias de Cargos
    Dim EstCargoId As Long
    Dim EstCargoName As String
    Dim EstCargoDescription As String
    Dim EstCargoSecuencia As Long
    Dim EstCargoPlanta As String
    'Cargos
    Dim CargosId As Long
    Dim CargosName As String
    Dim CargosDescription As String
    ' Clientes
    Dim ClienteId As Long
    Dim ClienteEMail As String
    Dim ClienteRut As String
    Dim ClienteName As String
    Dim ClienteApPaterno As String
    Dim ClienteApMaterno As String
    Dim ClienteCalle As String
    Dim ClienteNumero As String
    Dim ClienteDepartamento As String
    Dim ClienteComuna As String
    Dim ClienteCiudad As String
    Dim ClienteTelefonoParticular As String
    Dim ClienteCelular As String
    Dim ClienteTelefonoComercial1 As String
    Dim ClienteTelefonoComercial2 As String
    Dim ClienteFNacimiento As Date
    ' Portales
    Dim PortalesId As Long
    Dim PortalesName As String
    Dim PortalesDescription As String
    Dim PortalesSecuencia As Long
    'PaginaWeb
    Dim PaginaWebId As Long
    Dim PaginaWebName As String
    Dim PaginaWebTitle As String
    Dim PaginaWebDescription As String
    Dim FormularioWebNumber As Long
    Dim PaginaWebGroupValidation As String
    Dim PaginaWebStereotype As String
    Dim PaginaWebUserControl As String
    Dim FormularioWebId As Long
    Dim FormularioWebPId As Long

    ' Declaración de Variables de la Aplicación
    Dim t As Boolean
    Dim Logo As String = ""
    Dim BarMenu As String = ""
    Dim SideBarMenu As String = ""
    'Dim PaginaWebName As String = ""

    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Search(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
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
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))

        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Request.QueryString("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")

        Dim AccionesABM As New AccionesABM

        Select Case Request.QueryString("PaginaWebName")
            Case "Ficha de Comuna"
                Try
                    t = AccionesABM.ComunaUpdate(Request.QueryString("Id"), txtComunaName.Text, txtComunaDescription.Text, txtComunaCodigoCorreos.Text, txtComunaProvincia.Text, txtComunaRegion.Text, CLng(Session("PersonaId")))
                Catch
                    t = 0
                End Try
            Case "Ficha de EstCargo"
                Try
                    t = AccionesABM.EstCargoUpdate(Request.QueryString("Id"), txtEstCargoName.Text, txtEstCargoDescription.Text, CLng(txtEstCargoSecuencia.Text), txtEstCargoPlanta.Text, CLng(Session("PersonaId")))
                Catch
                    t = 0
                End Try
            Case "Ficha de Cargos"
                Try
                    t = AccionesABM.CargosUpdate(Request.QueryString("Id"), txtCargosName.Text, txtCargosDescription.Text, ddlEstCargoName.Text, CLng(Session("PersonaId")))
                Catch
                    t = 0
                End Try
            Case "Ficha de Cliente"
                Try
                    t = AccionesABM.ClienteUpdate(Request.QueryString("Id"), txtEMail.Text, txtRut.Text, txtName.Text, txtApPaterno.Text, txtApMaterno.Text, txtCalle.Text, txtNumero.Text, txtDepartamento.Text, txtComuna.Text, txtCiudad.Text, txtTelefonoParticular.Text, txtCelular.Text, txtTelefonoComercial1.Text, txtTelefonoComercial2.Text, CDate(txtFNacimiento.Text), Session("PersonaId"))
                Catch
                    t = 0
                End Try
            Case "Ficha de Portales"
                Try
                    t = AccionesABM.PortalesUpdate(Request.QueryString("Id"), txtPortalesName.Text, txtPortalesDescription.Text, CLng(txtPortalesSecuencia.Text), CLng(Session("PersonaId")))
                Catch
                    t = 0
                End Try
            Case "Ficha de Páginas"
                Try
                    If Len(txtFormularioWebNumber.Text) = 0 Then 'Significa que no tiene formulario asignado y por tanto se le crea uno.
                        txtFormularioWebNumber.Text = Lecturas.CalcularNextFormularioWebNumber
                        Select Case txtPaginaWebUserControl.Text
                            Case "Entidades.ascx" ' Se generan en forma automática algunos registros con el objetivo de presentar la página con algo ya avanzado y que el usuario pueda modificar
                                t = AccionesABM.FormularioWebInsert(CLng(txtFormularioWebNumber.Text), 0, 1, txtPaginaWebName.Text, "frmHeader", "Entidades", "", "", "", "", 0, "", "False", "FormHeader", CLng(Session("PersonaId")), FormularioWebId)
                                FormularioWebPId = FormularioWebId
                                'Insertar una Key como modelo
                                t = AccionesABM.FormularioWebInsert(CLng(txtFormularioWebNumber.Text), 0, 1, "Key1", "txtKey1", "TextBox", "textocontgris10bold", "textoboxgris", "right", "250px", 0, "Modifique o Elimine este registro", "True", "FormKeys", CLng(Session("PersonaId")), FormularioWebId)
                                'Insertar un grupo
                                t = AccionesABM.FormularioWebInsert(CLng(txtFormularioWebNumber.Text), FormularioWebPId, 1, "Grupo1", "frmGrupo1", "", "", "", "", "", 0, "", "False", "FormGroup", CLng(Session("PersonaId")), FormularioWebId)
                                'Insertar un control
                                t = AccionesABM.FormularioWebInsert(CLng(txtFormularioWebNumber.Text), FormularioWebId, 1, "Field1", "txtField1", "TextBox", "textocontgris10bold", "textoboxgris", "right", "250px", 0, "Modifique o Elimine este registro", "False", "Form", CLng(Session("PersonaId")), FormularioWebId)
                                'Insertar Botones, que en este caso son 3
                                t = AccionesABM.FormularioWebInsert(CLng(txtFormularioWebNumber.Text), 0, 1, "Guardar Datos", "UpdateButton", "Button", "textocontgris10bold", "boxceleste", "left", "80px", 0, "Presione para actualizar los datos", "False", "Button", CLng(Session("PersonaId")), FormularioWebId)
                                t = AccionesABM.FormularioWebInsert(CLng(txtFormularioWebNumber.Text), 0, 2, "Nuevo", "NewButton", "Button", "textocontgris10bold", "boxceleste", "left", "80px", 0, "Presione para crear un nuevo registro", "False", "Button", CLng(Session("PersonaId")), FormularioWebId)
                                t = AccionesABM.FormularioWebInsert(CLng(txtFormularioWebNumber.Text), 0, 3, "Buscar", "SearchButton", "Button", "textocontgris10bold", "boxceleste", "left", "80px", 0, "Presione para buscar un registro", "False", "Button", CLng(Session("PersonaId")), FormularioWebId)
                        End Select
                    End If
                    t = AccionesABM.PaginaWebUpdate(Request.QueryString("Id"), txtPaginaWebName.Text, txtPaginaWebTitle.Text, txtPaginaWebDescription.Text, CLng(txtFormularioWebNumber.Text), txtPaginaWebGroupValidation.Text, txtPaginaWebStereotype.Text, txtPaginaWebUserControl.Text, CLng(Session("PersonaId")))
                Catch
                    t = 0
                End Try
        End Select
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
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
        'Call Lecturas.CrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyTable, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler SearchButton.Click, AddressOf RFC_Search
        'AddHandler DeleteButton.Click, AddressOf RFC_Delete

        Select Case Request.QueryString("PaginaWebName")
            Case "Ficha de Comuna"
                If Not IsPostBack Then
                    If t = Lecturas.LeerComuna(Request.QueryString("Id"), ComunaName, ComunaDescription, ComunaCodigoCorreos, ComunaProvincia, ComunaRegion) Then
                        txtComunaName = FindControl("txtComunaName")
                        txtComunaName.Text = ComunaName
                        txtComunaDescription = FindControl("txtComunaDescription")
                        txtComunaDescription.Text = ComunaDescription
                        txtComunaCodigoCorreos = FindControl("txtComunaCodigoCorreos")
                        txtComunaCodigoCorreos.Text = ComunaCodigoCorreos
                        txtComunaProvincia = FindControl("txtComunaProvincia")
                        txtComunaProvincia.Text = ComunaProvincia
                        txtComunaRegion = FindControl("txtComunaRegion")
                        txtComunaRegion.Text = ComunaRegion
                    Else
                        txtComunaName = FindControl("txtComunaName")
                        txtComunaName.Text = Session("ComunaName")
                    End If
                Else
                    txtComunaName = FindControl("txtComunaName")
                    txtComunaDescription = FindControl("txtComunaDescription")
                    txtComunaCodigoCorreos = FindControl("txtComunaCodigoCorreos")
                    txtComunaProvincia = FindControl("txtComunaProvincia")
                    txtComunaRegion = FindControl("txtComunaRegion")
                End If
            Case "Ficha de EstCargo"
                If Not IsPostBack Then
                    If t = Lecturas.LeerEstCargo(Request.QueryString("Id"), EstCargoName, EstCargoDescription, EstCargoSecuencia, EstCargoPlanta) Then
                        txtEstCargoName = FindControl("txtEstCargoName")
                        txtEstCargoName.Text = EstCargoName
                        txtEstCargoDescription = FindControl("txtEstCargoDescription")
                        txtEstCargoDescription.Text = EstCargoDescription
                        txtEstCargoSecuencia = FindControl("txtEstCargoSecuencia")
                        txtEstCargoSecuencia.Text = EstCargoSecuencia
                        txtEstCargoPlanta = FindControl("txtEstCargoPlanta")
                        txtEstCargoPlanta.Text = EstCargoPlanta
                    Else
                        txtEstCargoName = FindControl("txtEstCargoName")
                        txtEstCargoName.Text = Session("EstCargoName")
                    End If
                Else
                    txtEstCargoName = FindControl("txtEstCargoName")
                    txtEstCargoDescription = FindControl("txtEstCargoDescription")
                    txtEstCargoSecuencia = FindControl("txtEstCargoSecuencia")
                    txtEstCargoPlanta = FindControl("txtEstCargoPlanta")
                End If

            Case "Ficha de Cargos"  'ES aplicación Maestro Detalle
                If Not IsPostBack Then
                    If t = Lecturas.LeerCargo(Request.QueryString("Id"), CargosName, CargosDescription, EstCargoName) Then
                        txtCargosName = FindControl("txtCargosName")
                        txtCargosName.Text = CargosName
                        txtCargosDescription = FindControl("txtCargosDescription")
                        txtCargosDescription.Text = CargosDescription
                        ddlEstCargoName = FindControl("ddlEstCargoName")
                        ddlEstCargoName.Text = EstCargoName
                        ' Se agregar para poblar la lista de requisitos de acuerdo con el cargo seleccionado
                        sSQLWhere = ""
                        sSQLOrder = ""
                        Call Lecturas.CreateTabs(NumeroPagina, CargosName, Request.QueryString("Id"), MyTabs, "CargosName", sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"))
                    Else
                        txtCargosName = FindControl("txtCargosName")
                        txtCargosName.Text = Session("CargosName")
                    End If
                Else
                    ddlEstCargoName = FindControl("ddlEstCargoName")
                    txtCargosDescription = FindControl("txtCargosDescription")
                    txtCargosName = FindControl("txtCargosName")
                End If
            Case "Ficha de Cliente"
                If Not IsPostBack Then
                    If Request.QueryString("Id") <> 0 Then
                        If t = Lecturas.LeerCliente(Request.QueryString("Id"), ClienteEMail, ClienteRut, ClienteName, ClienteApPaterno, ClienteApMaterno, ClienteCalle, ClienteNumero, ClienteDepartamento, ClienteComuna, ClienteCiudad, ClienteTelefonoParticular, ClienteCelular, ClienteTelefonoComercial1, ClienteTelefonoComercial2, ClienteFNacimiento) Then
                            txtEMail = FindControl("txtEMail")
                            txtEMail.Text = ClienteEMail
                            txtRut = FindControl("txtRut")
                            txtRut.Text = ClienteRut
                            txtName = FindControl("txtName")
                            txtName.Text = ClienteName
                            txtApPaterno = FindControl("txtApPaterno")
                            txtApPaterno.Text = ClienteApPaterno
                            txtApMaterno = FindControl("txtApMaterno")
                            txtApMaterno.Text = ClienteApMaterno
                            txtCalle = FindControl("txtCalle")
                            txtCalle.Text = ClienteCalle
                            txtNumero = FindControl("txtNumero")
                            txtNumero.Text = ClienteNumero
                            txtDepartamento = FindControl("txtDepartamento")
                            txtDepartamento.Text = ClienteDepartamento
                            txtComuna = FindControl("txtComuna")
                            txtComuna.Text = ClienteComuna
                            txtCiudad = FindControl("txtCiudad")
                            txtCiudad.Text = ClienteCiudad
                            txtTelefonoParticular = FindControl("txtTelefonoParticular")
                            txtTelefonoParticular.Text = ClienteTelefonoParticular
                            txtCelular = FindControl("txtCelular")
                            txtCelular.Text = ClienteCelular
                            txtTelefonoComercial1 = FindControl("txtTelefonoComercial1")
                            txtTelefonoComercial1.Text = ClienteTelefonoComercial1
                            txtTelefonoComercial2 = FindControl("txtTelefonoComercial2")
                            txtTelefonoComercial2.Text = ClienteTelefonoComercial2
                            txtFNacimiento = FindControl("txtFNacimiento")
                            txtFNacimiento.Text = FormatDateTime(ClienteFNacimiento, DateFormat.ShortDate)
                        Else
                            txtEMail = FindControl("txtEMail")
                            txtEMail.Text = Session("EMail")
                            txtRut = FindControl("txtRut")
                            txtRut.Text = Session("Rut")
                        End If
                    End If
                Else
                    txtEMail = FindControl("txtEMail")
                    txtRut = FindControl("txtRut")
                    txtName = FindControl("txtName")
                    txtApPaterno = FindControl("txtApPaterno")
                    txtApMaterno = FindControl("txtApMaterno")
                    txtCalle = FindControl("txtCalle")
                    txtNumero = FindControl("txtNumero")
                    txtDepartamento = FindControl("txtDepartamento")
                    txtComuna = FindControl("txtComuna")
                    txtCiudad = FindControl("txtCiudad")
                    txtTelefonoParticular = FindControl("txtTelefonoParticular")
                    txtCelular = FindControl("txtCelular")
                    txtTelefonoComercial1 = FindControl("txtTelefonoComercial1")
                    txtTelefonoComercial2 = FindControl("txtTelefonoComercial2")
                    txtFNacimiento = FindControl("txtFNacimiento")
                End If
            Case "Ficha de Portales"
                If Not IsPostBack Then
                    If t = Lecturas.LeerPortal(Request.QueryString("Id"), PortalesName, PortalesDescription, PortalesSecuencia) Then
                        txtPortalesName = FindControl("txtPortalesName")
                        txtPortalesName.Text = PortalesName
                        txtPortalesDescription = FindControl("txtPortalesDescription")
                        txtPortalesDescription.Text = PortalesDescription
                        txtPortalesSecuencia = FindControl("txtPortalesSecuencia")
                        txtPortalesSecuencia.Text = PortalesSecuencia
                        ' Se agregar para poblar la lista de requisitos de acuerdo con el cargo seleccionado
                        sSQLWhere = ""
                        sSQLOrder = " Order by Class, Secuencia"
                        Call Lecturas.CreateTabs(NumeroPagina, PortalesName, Request.QueryString("Id"), MyTabs, "SystemId", sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"))
                    Else
                        txtPortalesName = FindControl("txtPortalesName")
                        txtPortalesName.Text = Session("PortalesName")
                    End If
                Else
                    txtPortalesName = FindControl("txtPortalesName")
                    txtPortalesDescription = FindControl("txtPortalesDescription")
                    txtPortalesSecuencia = FindControl("txtPortalesSecuencia")
                End If
            Case "Ficha de Páginas"
                If Not IsPostBack Then
                    If t = Lecturas.LeerPagina(Request.QueryString("Id"), PaginaWebName, PaginaWebTitle, PaginaWebDescription, FormularioWebNumber, PaginaWebGroupValidation, PaginaWebStereotype, PaginaWebUserControl) Then
                        txtPaginaWebName = FindControl("txtPaginaWebName")
                        txtPaginaWebName.Text = PaginaWebName
                        txtPaginaWebTitle = FindControl("txtPaginaWebTitle")
                        txtPaginaWebTitle.Text = PaginaWebTitle
                        txtPaginaWebDescription = FindControl("txtPaginaWebDescription")
                        txtPaginaWebDescription.Text = PaginaWebDescription
                        txtFormularioWebNumber = FindControl("txtFormularioWebNumber")
                        txtFormularioWebNumber.Text = FormularioWebNumber
                        txtPaginaWebGroupValidation = FindControl("txtPaginaWebGroupValidation")
                        txtPaginaWebGroupValidation.Text = PaginaWebGroupValidation
                        txtPaginaWebStereotype = FindControl("txtPaginaWebStereotype")
                        txtPaginaWebStereotype.Text = PaginaWebStereotype
                        txtPaginaWebUserControl = FindControl("txtPaginaWebUserControl")
                        txtPaginaWebUserControl.Text = PaginaWebUserControl
                        ' Se agrega por ser la ficha de la descripción de una página web
                        Call Lecturas.MostrarFormulario(FormularioWebNumber, PaginaWebTitle, PaginaWebDescription, GroupValidation, MyFormulario, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton, CLng(Request.QueryString("MenuOptionsId")), Request.QueryString("MasterName"), CLng(Request.QueryString("MasterId")))
                    Else
                        txtPaginaWebName = FindControl("txtPaginaWebName")
                        txtPaginaWebName.Text = Session("PaginaWebName")
                        txtPaginaWebGroupValidation = FindControl("txtPaginaWebGroupValidation")
                        txtPaginaWebGroupValidation.Text = Session("PaginaWebGroupValidation")
                        txtPaginaWebStereotype = FindControl("txtPaginaWebStereotype")
                        txtPaginaWebStereotype.Text = Session("PaginaWebStereotype")
                        txtPaginaWebUserControl = FindControl("txtPaginaWebUserControl")
                        txtPaginaWebUserControl.Text = Session("PaginaWebUserControl")
                    End If
                Else
                    txtPaginaWebName = FindControl("txtPaginaWebName")
                    txtPaginaWebTitle = FindControl("txtPaginaWebTitle")
                    txtPaginaWebDescription = FindControl("txtPaginaWebDescription")
                    txtFormularioWebNumber = FindControl("txtFormularioWebNumber")
                    txtPaginaWebGroupValidation = FindControl("txtPaginaWebGroupValidation")
                    txtPaginaWebStereotype = FindControl("txtPaginaWebStereotype")
                    txtPaginaWebUserControl = FindControl("txtPaginaWebUserControl")
                End If
        End Select
    End Sub
End Class