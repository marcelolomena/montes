Imports AjaxControlToolkit
Partial Class FichaCarpetaJudicialGastos
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 25-02-2012 6:49:09
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
    Dim txtCarpetaJudicialCodigo As TextBox ' Etiqueta : # Interno - Control : txtCarpetaJudicialCodigo - Variable : CarpetaJudicialCodigo
    Dim txtCarpetaJudicialGastosSecuencia As TextBox ' Etiqueta : # Secuencia - Control : txtCarpetaJudicialGastosSecuencia - Variable : CarpetaJudicialGastosSecuencia
    Dim txtCarpetaJudicialGastosFecha As TextBox ' Etiqueta : Fecha - Control : txtCarpetaJudicialGastosFecha - Variable : CarpetaJudicialGastosFecha
    Dim txtCarpetaJudicialGastosConcepto As TextBox ' Etiqueta : Concepto - Control : txtCarpetaJudicialGastosConcepto - Variable : CarpetaJudicialGastosConcepto
    Dim txtCarpetaJudicialGastosDocumento As TextBox ' Etiqueta : Documento - Control : txtCarpetaJudicialGastosDocumento - Variable : CarpetaJudicialGastosDocumento
    Dim txtCarpetaJudicialGastosMonto As TextBox ' Etiqueta : Monto - Control : txtCarpetaJudicialGastosMonto - Variable : CarpetaJudicialGastosMonto
    Dim txtCarpetaJudicialGastosDescription As TextBox ' Etiqueta : Descripción - Control : txtCarpetaJudicialGastosDescription - Variable : CarpetaJudicialGastosDescription
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim CarpetaJudicialCodigo As String ' Etiqueta : # Interno - Control : txtCarpetaJudicialCodigo - Variable : CarpetaJudicialCodigo
    Dim CarpetaJudicialGastosSecuencia As Long ' Etiqueta : # Secuencia - Control : txtCarpetaJudicialGastosSecuencia - Variable : CarpetaJudicialGastosSecuencia
    Dim CarpetaJudicialGastosFecha As Date ' Etiqueta : Fecha - Control : txtCarpetaJudicialGastosFecha - Variable : CarpetaJudicialGastosFecha
    Dim CarpetaJudicialGastosConcepto As String ' Etiqueta : Concepto - Control : txtCarpetaJudicialGastosConcepto - Variable : CarpetaJudicialGastosConcepto
    Dim CarpetaJudicialGastosDocumento As String ' Etiqueta : Documento - Control : txtCarpetaJudicialGastosDocumento - Variable : CarpetaJudicialGastosDocumento
    Dim CarpetaJudicialGastosMonto As Double ' Etiqueta : Monto - Control : txtCarpetaJudicialGastosMonto - Variable : CarpetaJudicialGastosMonto
    Dim CarpetaJudicialGastosDescription As String ' Etiqueta : Descripción - Control : txtCarpetaJudicialGastosDescription - Variable : CarpetaJudicialGastosDescription
    '----------------------------------------
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicialGastos As New CarpetaJudicialGastos
        Try
            t = CarpetaJudicialGastos.CarpetaJudicialGastosDelete(Session("Id"), Request.QueryString("MasterName"), CLng(Session("PersonaId")))
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
        t = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & Request.QueryString("MasterName") & "&MasterId=" & Request.QueryString("MasterId")
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Session("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & Request.QueryString("MasterName") & "&MasterId=" & Request.QueryString("MasterId")
        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicialGastos As New CarpetaJudicialGastos
        Try
            t = CarpetaJudicialGastos.CarpetaJudicialGastosUpdate(Session("Id"), CStr(txtCarpetaJudicialCodigo.Text), CLng(txtCarpetaJudicialGastosSecuencia.Text), CDate(txtCarpetaJudicialGastosFecha.Text), CStr(txtCarpetaJudicialGastosConcepto.Text), CStr(txtCarpetaJudicialGastosDocumento.Text), CDbl(txtCarpetaJudicialGastosMonto.Text * 100), CStr(txtCarpetaJudicialGastosDescription.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicialGastos As New CarpetaJudicialGastos
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
                Session("MasterId") = Request.QueryString("MasterId")
                DetailId = Request.QueryString("Id")
                If DetailId = 0 Then
                    DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("CarpetaJudicialCodigo", "CarpetaJudicialGastosSecuencia", "CarpetaJudicialGastos", MasterName)
                    t = AccionesABM.ObjectPartialInsert("CarpetaJudicialGastosId", "CarpetaJudicialCodigo", "CarpetaJudicialGastosSecuencia", "CarpetaJudicialGastos", MasterName, DetailSecuencia, CLng(Session("PersonaId")), DetailId)
                End If
                Session("Id") = DetailId
                If t = CarpetaJudicialGastos.LeerCarpetaJudicialGastos(Session("Id"), CarpetaJudicialCodigo, CarpetaJudicialGastosSecuencia, CarpetaJudicialGastosFecha, CarpetaJudicialGastosConcepto, CarpetaJudicialGastosDocumento, CarpetaJudicialGastosMonto, CarpetaJudicialGastosDescription) Then
                    txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                    txtCarpetaJudicialCodigo.Text = CarpetaJudicialCodigo
                    txtCarpetaJudicialGastosSecuencia = FindControl("txtCarpetaJudicialGastosSecuencia")
                    txtCarpetaJudicialGastosSecuencia.Text = CarpetaJudicialGastosSecuencia
                    txtCarpetaJudicialGastosFecha = FindControl("txtCarpetaJudicialGastosFecha")
                    txtCarpetaJudicialGastosFecha.Text = CarpetaJudicialGastosFecha
                    txtCarpetaJudicialGastosConcepto = FindControl("txtCarpetaJudicialGastosConcepto")
                    txtCarpetaJudicialGastosConcepto.Text = CarpetaJudicialGastosConcepto
                    txtCarpetaJudicialGastosDocumento = FindControl("txtCarpetaJudicialGastosDocumento")
                    txtCarpetaJudicialGastosDocumento.Text = CarpetaJudicialGastosDocumento
                    txtCarpetaJudicialGastosMonto = FindControl("txtCarpetaJudicialGastosMonto")
                    txtCarpetaJudicialGastosMonto.Text = FormatNumber(CarpetaJudicialGastosMonto / 100, 2)
                    txtCarpetaJudicialGastosDescription = FindControl("txtCarpetaJudicialGastosDescription")
                    txtCarpetaJudicialGastosDescription.Text = CarpetaJudicialGastosDescription
                Else
                    txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                    txtCarpetaJudicialCodigo.Text = Session("CarpetaJudicialCodigo")
                    txtCarpetaJudicialGastosSecuencia = FindControl("txtCarpetaJudicialGastosSecuencia")
                    txtCarpetaJudicialGastosSecuencia.Text = Session("CarpetaJudicialGastosSecuencia")
                End If
            Else
                txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                txtCarpetaJudicialGastosSecuencia = FindControl("txtCarpetaJudicialGastosSecuencia")
                txtCarpetaJudicialGastosFecha = FindControl("txtCarpetaJudicialGastosFecha")
                txtCarpetaJudicialGastosConcepto = FindControl("txtCarpetaJudicialGastosConcepto")
                txtCarpetaJudicialGastosDocumento = FindControl("txtCarpetaJudicialGastosDocumento")
                txtCarpetaJudicialGastosMonto = FindControl("txtCarpetaJudicialGastosMonto")
                txtCarpetaJudicialGastosDescription = FindControl("txtCarpetaJudicialGastosDescription")
            End If
        Catch
            t = False
        End Try
    End Sub
End Class
