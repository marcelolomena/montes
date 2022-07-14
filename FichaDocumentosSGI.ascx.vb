Imports AjaxControlToolkit
Imports System.IO

Partial Class FichaDocumentosSGI
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 01-12-2010 19:21:51
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
    '----------------------------------------
    ' Declaración de controles de para hacer upload de archivo
    '----------------------------------------
    Dim txtUploadFile As FileUpload

    Dim WithEvents SaveButton As Button
    Dim UploadLink As HyperLink
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
    Dim txtDocumentosSGICodigo As TextBox ' Etiqueta : Código - Control : txtDocumentosSGICodigo - Variable : DocumentosSGICodigo
    Dim txtDocumentosSGINombre As TextBox ' Etiqueta : Nombre - Control : txtDocumentosSGINombre - Variable : DocumentosSGINombre
    Dim txtDocumentosSGIDescription As TextBox ' Etiqueta : Descripción - Control : txtDocumentosSGIDescription - Variable : DocumentosSGIDescription
    Dim txtDocumentosSGIPath As TextBox ' Etiqueta : Ubicación Física - Control : txtDocumentosSGIPath - Variable : DocumentosSGIPath
    Dim txtDocumentosSGIOrigen As TextBox ' Etiqueta : Código de Origen - Control : txtDocumentosSGIOrigen - Variable : DocumentosSGIOrigen
    Dim txtDocumentosSGITipo As TextBox ' Etiqueta : Tipo de Documento - Control : txtDocumentosSGITipo - Variable : DocumentosSGITipo
    'Dim txtDocumentosSGITipo As DropDownList ' Etiqueta : Tipo de Documento - Control : txtDocumentosSGITipo - Variable : DocumentosSGITipo
    Dim txtDocumentosSGITipoDescription As TextBox '
    Dim txtDocumentosSGIFEmision As TextBox ' Etiqueta : Fecha de Emisión - Control : txtDocumentosSGIFEmision - Variable : DocumentosSGIFEmision
    Dim txtDocumentosSGIFRevision As TextBox ' Etiqueta : Fecha de Revisión - Control : txtDocumentosSGIFRevision - Variable : DocumentosSGIFRevision
    Dim txtDocumentosSGIArea As TextBox ' Etiqueta : Area - Control : txtDocumentosSGIArea - Variable : DocumentosSGIArea
    Dim txtDocumentosSGIAreaDescription As TextBox
    Dim txtDocumentosSGIResponsable As TextBox ' Etiqueta : Responsable - Control : txtDocumentosSGIResponsable - Variable : DocumentosSGIResponsable
    Dim txtDocumentosSGIEmpresa As TextBox ' Etiqueta : Empresa Contratista - Control : txtDocumentosSGIEmpresa - Variable : DocumentosSGIEmpresa
    Dim txtDocumentosSGIContrato As TextBox ' Etiqueta : Número de Contrato - Control : txtDocumentosSGIContrato - Variable : DocumentosSGIContrato
    Dim txtDocumentosSGIPalabrasClaves As TextBox ' Etiqueta : Número de Contrato - Control : txtDocumentosSGIContrato - Variable : DocumentosSGIContrato

    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim DocumentosSGICodigo As String ' Etiqueta : Código - Control : txtDocumentosSGICodigo - Variable : DocumentosSGICodigo
    Dim DocumentosSGINombre As String ' Etiqueta : Nombre - Control : txtDocumentosSGINombre - Variable : DocumentosSGINombre
    Dim DocumentosSGIDescription As String ' Etiqueta : Descripción - Control : txtDocumentosSGIDescription - Variable : DocumentosSGIDescription
    Dim DocumentosSGIPath As String ' Etiqueta : Ubicación Física - Control : txtDocumentosSGIPath - Variable : DocumentosSGIPath
    Dim DocumentosSGIOrigen As String ' Etiqueta : Código de Origen - Control : txtDocumentosSGIOrigen - Variable : DocumentosSGIOrigen
    Dim DocumentosSGITipo As String ' Etiqueta : Tipo de Documento - Control : txtDocumentosSGITipo - Variable : DocumentosSGITipo
    Dim DocumentosSGIFEmision As Date ' Etiqueta : Fecha de Emisión - Control : txtDocumentosSGIFEmision - Variable : DocumentosSGIFEmision
    Dim DocumentosSGIFRevision As String ' Etiqueta : Fecha de Revisión - Control : txtDocumentosSGIFRevision - Variable : DocumentosSGIFRevision
    Dim DocumentosSGIArea As String ' Etiqueta : Area - Control : txtDocumentosSGIArea - Variable : DocumentosSGIArea
    Dim DocumentosSGIResponsable As String ' Etiqueta : Responsable - Control : txtDocumentosSGIResponsable - Variable : DocumentosSGIResponsable
    Dim DocumentosSGIEmpresa As String ' Etiqueta : Empresa Contratista - Control : txtDocumentosSGIEmpresa - Variable : DocumentosSGIEmpresa
    Dim DocumentosSGIContrato As String ' Etiqueta : Número de Contrato - Control : txtDocumentosSGIContrato - Variable : DocumentosSGIContrato
    Dim DocumentosSGIPalabrasClaves As String
    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""

        Dim ArchivoDestino As String = Server.MapPath("~/SGI/") & txtDocumentosSGIPath.Text
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        If Request.QueryString("MenuOptionsId") = 507 Then  'Se adapta para tipo de documento Compliance
            Url = Url & "&Tipo=Compliance"
        End If

        Dim DocumentosSGI As New DocumentosSGI
        Dim Carpetas As New Carpetas
        Try
            t = DocumentosSGI.DocumentosSGIDelete(Request.QueryString("Id"), CStr(txtDocumentosSGICodigo.Text), CLng(Session("PersonaId")))
            t = Carpetas.DocumentosSGIPorCarpetaDelete(Request.QueryString("Id"), CStr(txtDocumentosSGICodigo.Text), CLng(Session("PersonaId")))
            If File.Exists(ArchivoDestino) Then
                File.Delete(ArchivoDestino)
            End If
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
        If Request.QueryString("MenuOptionsId") = 507 Then  'Se adapta para tipo de documento Compliance
            Url = Url & "&Tipo=Compliance"
        End If
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Save(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Dim ArchivoDestino As String = ""
        If txtUploadFile.HasFile Then

            ArchivoDestino = Server.MapPath("~/SGI/") & txtUploadFile.FileName
            txtDocumentosSGIPath.Text = txtUploadFile.FileName
            If File.Exists(ArchivoDestino) Then
                File.Delete(ArchivoDestino)
            End If
            txtUploadFile.PostedFile.SaveAs(ArchivoDestino)
            UploadLink.NavigateUrl = "~/SGI/" & txtDocumentosSGIPath.Text
            UploadLink.Target = "_blank"
        End If
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Request.QueryString("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim AccionesABM As New AccionesABM
        Dim DocumentosSGI As New DocumentosSGI
        If Request.QueryString("MenuOptionsId") = 507 Then  'Se adapta para tipo de documento Compliance
            txtDocumentosSGITipo.Text = "Compliance"
            DocumentosSGITipo = "Compliance"
        End If
        Try
            t = DocumentosSGI.DocumentosSGIUpdate(Request.QueryString("Id"), CStr(txtDocumentosSGICodigo.Text), CStr(txtDocumentosSGINombre.Text), CStr(txtDocumentosSGIDescription.Text), CStr(txtDocumentosSGIPath.Text), CStr(txtDocumentosSGIOrigen.Text), CStr(txtDocumentosSGITipo.Text), CDate(txtDocumentosSGIFEmision.Text), CStr(txtDocumentosSGIFRevision.Text), CStr(txtDocumentosSGIArea.Text), CStr(txtDocumentosSGIResponsable.Text), CStr(txtDocumentosSGIEmpresa.Text), CStr(txtDocumentosSGIContrato.Text), CStr(txtDocumentosSGIPalabrasClaves.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ctlControl As Control
        Dim Lecturas As New Lecturas
        Dim DocumentosSGI As New DocumentosSGI
        Dim Areas As New Areas
        Dim TipoDoc As New TipoDoc
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
        Call Lecturas.NuevaCrearFormularioV2(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton, SaveButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler SearchButton.Click, AddressOf RFC_Search
        AddHandler SaveButton.Click, AddressOf RFC_Save
        AddHandler DeleteButton.Click, AddressOf RFC_Delete
        AddHandler CancelButton.Click, AddressOf RFC_Logout
        If Not IsPostBack Then
            If Request.QueryString("Id") <> 0 Then
                If t = DocumentosSGI.LeerDocumentosSGI(Request.QueryString("Id"), DocumentosSGICodigo, DocumentosSGINombre, DocumentosSGIDescription, DocumentosSGIPath, DocumentosSGIOrigen, DocumentosSGITipo, DocumentosSGIFEmision, DocumentosSGIFRevision, DocumentosSGIArea, DocumentosSGIResponsable, DocumentosSGIEmpresa, DocumentosSGIContrato, DocumentosSGIPalabrasClaves) Then
                    txtDocumentosSGICodigo = FindControl("txtDocumentosSGICodigo")
                    txtDocumentosSGICodigo.Text = DocumentosSGICodigo
                    txtDocumentosSGINombre = FindControl("txtDocumentosSGINombre")
                    txtDocumentosSGINombre.Text = DocumentosSGINombre
                    txtDocumentosSGIDescription = FindControl("txtDocumentosSGIDescription")
                    txtDocumentosSGIDescription.Text = DocumentosSGIDescription
                    txtDocumentosSGIPath = FindControl("txtDocumentosSGIPath")
                    txtDocumentosSGIPath.Text = DocumentosSGIPath
                    ' Se agregan manualmente para manejar el evento RFC_Save
                    txtUploadFile = FindControl("txtUploadFile")
                    UploadLink = FindControl("lnkFile")
                    UploadLink.NavigateUrl = "~/SGI/" & txtDocumentosSGIPath.Text
                    UploadLink.Target = "_blank"
                    ' ---------------
                    txtDocumentosSGIOrigen = FindControl("txtDocumentosSGIOrigen")
                    txtDocumentosSGIOrigen.Text = DocumentosSGIOrigen
                    'Si MenuOptionID=507 ---> El tipo de documento es solo Compliance y no puede ser modificado
                    txtDocumentosSGITipo = FindControl("txtDocumentosSGITipo")
                    txtDocumentosSGITipo.Text = DocumentosSGITipo
                    ' -----------------------------
                    txtDocumentosSGITipoDescription = FindControl("txtDocumentosSGITipoDescription")
                    txtDocumentosSGITipoDescription.Text = TipoDoc.LeerTipoDocDescriptionByName(DocumentosSGITipo)
                    If Request.QueryString("MenuOptionsId") = 507 Then  'Se adapta para tipo de documento Compliance
                        txtDocumentosSGITipo.Text = "Compliance"
                        DocumentosSGITipo = "Compliance"
                        txtDocumentosSGITipoDescription.Text = TipoDoc.LeerTipoDocDescriptionByName(DocumentosSGITipo)
                        txtDocumentosSGITipo.Enabled = False
                        txtDocumentosSGITipoDescription.Enabled = False
                    End If

                    txtDocumentosSGIFEmision = FindControl("txtDocumentosSGIFEmision")
                    txtDocumentosSGIFEmision.Text = DocumentosSGIFEmision
                    txtDocumentosSGIFRevision = FindControl("txtDocumentosSGIFRevision")
                    txtDocumentosSGIFRevision.Text = DocumentosSGIFRevision
                    txtDocumentosSGIArea = FindControl("txtDocumentosSGIArea")
                    txtDocumentosSGIArea.Text = DocumentosSGIArea
                    ' -----------------------------
                    txtDocumentosSGIAreaDescription = FindControl("txtDocumentosSGIAreaDescription")
                    txtDocumentosSGIAreaDescription.Text = Areas.LeerAreasDescriptionByName(DocumentosSGIArea)
                    txtDocumentosSGIResponsable = FindControl("txtDocumentosSGIResponsable")
                    txtDocumentosSGIResponsable.Text = DocumentosSGIResponsable
                    txtDocumentosSGIEmpresa = FindControl("txtDocumentosSGIEmpresa")
                    txtDocumentosSGIEmpresa.Text = DocumentosSGIEmpresa
                    txtDocumentosSGIContrato = FindControl("txtDocumentosSGIContrato")
                    txtDocumentosSGIContrato.Text = DocumentosSGIContrato
                    txtDocumentosSGIPalabrasClaves = FindControl("txtDocumentosSGIPalabrasClaves")
                    txtDocumentosSGIPalabrasClaves.Text = DocumentosSGIPalabrasClaves
                    ' Se agregar para poblar la lista de requisitos de acuerdo con el cargo seleccionado
                    sSQLWhere = ""
                    sSQLOrder = ""
                    'Call Lecturas.CreateTabs(NumeroPagina, DocumentosSGICodigo, Request.QueryString("Id"), MyTabs, "DocumentosSGICodigo", sSQLWhere, sSQLOrder, Request.QueryString("PaginaWebName"), Request.QueryString("MenuOptionsId"))
                    Session("DocumentosSGIId") = Request.QueryString("Id")
                    If Request.QueryString("MenuOptionsId") = 507 Then
                        Session("CarpetaRaiz") = "Carpeta Compliance"
                    Else
                        Session("CarpetaRaiz") = "Carpeta General"
                    End If
                    'ctlControl = LoadControl("Vinculos.ascx")
                    'PlaceHolder1.Controls.Add(ctlControl)
                Else
                    txtDocumentosSGICodigo = FindControl("txtDocumentosSGICodigo")
                    txtDocumentosSGICodigo.Text = Session("DocumentosSGICodigo")
                End If
            End If
        Else
            txtDocumentosSGICodigo = FindControl("txtDocumentosSGICodigo")
            txtDocumentosSGINombre = FindControl("txtDocumentosSGINombre")
            txtDocumentosSGIDescription = FindControl("txtDocumentosSGIDescription")
            txtDocumentosSGIPath = FindControl("txtDocumentosSGIPath")
            ' Se agregan manualmente para manejar el evento RFC_Save
            txtUploadFile = FindControl("txtUploadFile")
            UploadLink = FindControl("lnkFile")
            ' ---------------
            txtDocumentosSGIOrigen = FindControl("txtDocumentosSGIOrigen")
            txtDocumentosSGITipo = FindControl("txtDocumentosSGITipo")
            txtDocumentosSGIFEmision = FindControl("txtDocumentosSGIFEmision")
            txtDocumentosSGIFRevision = FindControl("txtDocumentosSGIFRevision")
            txtDocumentosSGIArea = FindControl("txtDocumentosSGIArea")
            txtDocumentosSGIResponsable = FindControl("txtDocumentosSGIResponsable")
            txtDocumentosSGIEmpresa = FindControl("txtDocumentosSGIEmpresa")
            txtDocumentosSGIContrato = FindControl("txtDocumentosSGIContrato")
            txtDocumentosSGIPalabrasClaves = FindControl("txtDocumentosSGIPalabrasClaves")
        End If
    End Sub
End Class
