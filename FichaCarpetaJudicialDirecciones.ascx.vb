Imports AjaxControlToolkit
Partial Class FichaCarpetaJudicialDirecciones
    Inherits System.Web.UI.UserControl
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
    Dim txtCarpetaJudicialCodigo As TextBox ' Etiqueta : Código o Rut - Control : txtCarpetaJudicialCodigo - Variable : CarpetaJudicialCodigo
    Dim txtCarpetaJudicialDireccionesSecuencia As TextBox ' Etiqueta : Secuencia - Control : txtCarpetaJudicialDireccionesSecuencia - Variable : CarpetaJudicialDireccionesSecuencia
    Dim txtCarpetaJudicialTipoDireccionesName As TextBox ' Etiqueta : Tipo Dirección - Control : txtCarpetaJudicialTipoDireccionesName - Variable : CarpetaJudicialTipoDireccionesName
    Dim txtCarpetaJudicialDireccionesDireccion As TextBox ' Etiqueta : Dirección Completa - Control : txtCarpetaJudicialDireccionesDireccion - Variable : CarpetaJudicialDireccionesDireccion
    Dim txtCarpetaJudicialDireccionesLocalidad As TextBox ' Etiqueta : Ciudad o Localidad - Control : txtCarpetaJudicialDireccionesLocalidad - Variable : CarpetaJudicialDireccionesLocalidad
    Dim txtComunasCodigo As TextBox ' Etiqueta : Comuna - Control : txtComunasCodigo - Variable : ComunasCodigo
    Dim txtCarpetaJudicialDireccionesTelefono As TextBox ' Etiqueta : Teléfonos - Control : txtCarpetaJudicialDireccionesTelefono - Variable : CarpetaJudicialDireccionesTelefono
    Dim txtCarpetaJudicialDireccionesCorreo As TextBox ' Etiqueta : Correo Electrónico - Control : txtCarpetaJudicialDireccionesCorreo - Variable : CarpetaJudicialDireccionesCorreo
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim CarpetaJudicialCodigo As String ' Etiqueta : Código o Rut - Control : txtCarpetaJudicialCodigo - Variable : CarpetaJudicialCodigo
    Dim CarpetaJudicialDireccionesSecuencia As Long ' Etiqueta : Secuencia - Control : txtCarpetaJudicialDireccionesSecuencia - Variable : CarpetaJudicialDireccionesSecuencia
    Dim CarpetaJudicialTipoDireccionesName As String ' Etiqueta : Tipo Dirección - Control : txtCarpetaJudicialTipoDireccionesName - Variable : CarpetaJudicialTipoDireccionesName
    Dim CarpetaJudicialDireccionesDireccion As String ' Etiqueta : Dirección Completa - Control : txtCarpetaJudicialDireccionesDireccion - Variable : CarpetaJudicialDireccionesDireccion
    Dim CarpetaJudicialDireccionesLocalidad As String ' Etiqueta : Ciudad o Localidad - Control : txtCarpetaJudicialDireccionesLocalidad - Variable : CarpetaJudicialDireccionesLocalidad
    Dim ComunasCodigo As String ' Etiqueta : Comuna - Control : txtComunasCodigo - Variable : ComunasCodigo
    Dim CarpetaJudicialDireccionesTelefono As String ' Etiqueta : Teléfonos - Control : txtCarpetaJudicialDireccionesTelefono - Variable : CarpetaJudicialDireccionesTelefono
    Dim CarpetaJudicialDireccionesCorreo As String ' Etiqueta : Correo Electrónico - Control : txtCarpetaJudicialDireccionesCorreo - Variable : CarpetaJudicialDireccionesCorreo
    '----------------------------------------
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""

        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")

        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicialDirecciones As New CarpetaJudicialDirecciones
        Try
            t = CarpetaJudicialDirecciones.CarpetaJudicialDireccionesDelete(Session("Id"), Request.QueryString("MasterName"), CLng(Session("PersonaId")))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Return(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReturnButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLReturn", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim Url As String = ""
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas
        Dim CarpetaJudicialCodigo As String = ""

        t = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))
        Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & Request.QueryString("MasterName") & "&MasterId=" & Request.QueryString("MasterId")
        If NombrePagina = "Ficha de TareasDirecciones" Then
            'MasterName cambia al código de la caprpeta judicial
            'MasterId se mantiene en el Id de la Tarea.
            CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
            Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & CarpetaJudicialCodigo & "&MasterId=" & Request.QueryString("MasterId")
        End If

        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim Url As String = ""
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas
        Dim CarpetaJudicialCodigo As String = ""


        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Session("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & Request.QueryString("MasterName") & "&MasterId=" & Request.QueryString("MasterId")
        If NombrePagina = "Ficha de TareasDirecciones" Then
            'MasterName cambia al código de la caprpeta judicial
            'MasterId se mantiene en el Id de la Tarea.
            CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
            Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Session("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & CarpetaJudicialCodigo & "&MasterId=" & Request.QueryString("MasterId")
        End If

        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicialDirecciones As New CarpetaJudicialDirecciones
        Try
            t = CarpetaJudicialDirecciones.CarpetaJudicialDireccionesUpdate(Session("Id"), CStr(txtCarpetaJudicialCodigo.Text), CLng(txtCarpetaJudicialDireccionesSecuencia.Text), CStr(txtCarpetaJudicialTipoDireccionesName.Text), CStr(txtCarpetaJudicialDireccionesDireccion.Text), CStr(txtCarpetaJudicialDireccionesLocalidad.Text), CStr(txtComunasCodigo.Text), CStr(txtCarpetaJudicialDireccionesTelefono.Text), CStr(txtCarpetaJudicialDireccionesCorreo.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicialDirecciones As New CarpetaJudicialDirecciones
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas

        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim PaginaWebName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim MasterName As String = "" ' Guarda el nombre del Maestro al que pertenece el detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler DeleteButton.Click, AddressOf RFC_Delete
        AddHandler ReturnButton.Click, AddressOf RFC_Return
        Try
            If Not IsPostBack Then
                MasterName = Request.QueryString("MasterName")
                If Request.QueryString("PaginaWebName") = "Ficha de TareasDirecciones" Then
                    MasterName = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
                End If
                Session("MasterId") = Request.QueryString("MasterId")
                DetailId = Request.QueryString("Id")
                If DetailId = 0 Then
                    DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("CarpetaJudicialCodigo", "CarpetaJudicialDireccionesSecuencia", "CarpetaJudicialDirecciones", MasterName)
                    t = AccionesABM.ObjectPartialInsert("CarpetaJudicialDireccionesId", "CarpetaJudicialCodigo", "CarpetaJudicialDireccionesSecuencia", "CarpetaJudicialDirecciones", MasterName, DetailSecuencia, CLng(Session("PersonaId")), DetailId)
                End If
                Session("Id") = DetailId
                If t = CarpetaJudicialDirecciones.LeerCarpetaJudicialDirecciones(Session("Id"), CarpetaJudicialCodigo, CarpetaJudicialDireccionesSecuencia, CarpetaJudicialTipoDireccionesName, CarpetaJudicialDireccionesDireccion, CarpetaJudicialDireccionesLocalidad, ComunasCodigo, CarpetaJudicialDireccionesTelefono, CarpetaJudicialDireccionesCorreo) Then
                    txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                    txtCarpetaJudicialCodigo.Text = CarpetaJudicialCodigo
                    txtCarpetaJudicialDireccionesSecuencia = FindControl("txtCarpetaJudicialDireccionesSecuencia")
                    txtCarpetaJudicialDireccionesSecuencia.Text = CarpetaJudicialDireccionesSecuencia
                    txtCarpetaJudicialTipoDireccionesName = FindControl("txtCarpetaJudicialTipoDireccionesName")
                    txtCarpetaJudicialTipoDireccionesName.Text = CarpetaJudicialTipoDireccionesName
                    txtCarpetaJudicialDireccionesDireccion = FindControl("txtCarpetaJudicialDireccionesDireccion")
                    txtCarpetaJudicialDireccionesDireccion.Text = CarpetaJudicialDireccionesDireccion
                    txtCarpetaJudicialDireccionesLocalidad = FindControl("txtCarpetaJudicialDireccionesLocalidad")
                    txtCarpetaJudicialDireccionesLocalidad.Text = CarpetaJudicialDireccionesLocalidad
                    txtComunasCodigo = FindControl("txtComunasCodigo")
                    txtComunasCodigo.Text = ComunasCodigo
                    txtCarpetaJudicialDireccionesTelefono = FindControl("txtCarpetaJudicialDireccionesTelefono")
                    txtCarpetaJudicialDireccionesTelefono.Text = CarpetaJudicialDireccionesTelefono
                    txtCarpetaJudicialDireccionesCorreo = FindControl("txtCarpetaJudicialDireccionesCorreo")
                    txtCarpetaJudicialDireccionesCorreo.Text = CarpetaJudicialDireccionesCorreo
                Else
                    txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                    txtCarpetaJudicialCodigo.Text = Session("CarpetaJudicialCodigo")
                    txtCarpetaJudicialDireccionesSecuencia = FindControl("txtCarpetaJudicialDireccionesSecuencia")
                    txtCarpetaJudicialDireccionesSecuencia.Text = Session("CarpetaJudicialDireccionesSecuencia")
                End If
            Else
                txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                txtCarpetaJudicialDireccionesSecuencia = FindControl("txtCarpetaJudicialDireccionesSecuencia")
                txtCarpetaJudicialTipoDireccionesName = FindControl("txtCarpetaJudicialTipoDireccionesName")
                txtCarpetaJudicialDireccionesDireccion = FindControl("txtCarpetaJudicialDireccionesDireccion")
                txtCarpetaJudicialDireccionesLocalidad = FindControl("txtCarpetaJudicialDireccionesLocalidad")
                txtComunasCodigo = FindControl("txtComunasCodigo")
                txtCarpetaJudicialDireccionesTelefono = FindControl("txtCarpetaJudicialDireccionesTelefono")
                txtCarpetaJudicialDireccionesCorreo = FindControl("txtCarpetaJudicialDireccionesCorreo")
            End If
        Catch
            t = False
        End Try
    End Sub
End Class
