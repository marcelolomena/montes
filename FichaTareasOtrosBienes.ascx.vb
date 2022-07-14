Imports AjaxControlToolkit
Imports System.IO
Partial Class FichaTareasOtrosBienes
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 25-04-2011 9:53:43
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
    Dim txtTareasCodigo As TextBox ' Etiqueta : Código Tarea - Control : txtTareasCodigo - Variable : TareasCodigo
    Dim txtTareasOtrosBienesSecuencia As TextBox ' Etiqueta : Secuencia - Control : txtTareasOtrosBienesSecuencia - Variable : TareasOtrosBienesSecuencia
    Dim txtTareasOtrosBienesDescription As TextBox ' Etiqueta : Descripción - Control : txtTareasOtrosBienesDescription - Variable : TareasOtrosBienesDescription
    Dim txtTareasOtrosBienesInscripcionFojas As TextBox
    Dim txtTareasOtrosBienesInscripcionNumero As TextBox
    Dim txtTareasOtrosBienesInscripcionAno As TextBox
    Dim txtTareasOtrosBienesInscripcionCiudad As TextBox
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim TareasCodigo As String ' Etiqueta : Código Tarea - Control : txtTareasCodigo - Variable : TareasCodigo
    Dim TareasOtrosBienesSecuencia As Long ' Etiqueta : Secuencia - Control : txtTareasOtrosBienesSecuencia - Variable : TareasOtrosBienesSecuencia
    Dim TareasOtrosBienesDescription As String ' Etiqueta : Descripción - Control : txtTareasOtrosBienesDescription - Variable : TareasOtrosBienesDescription
    Dim TareasOtrosBienesInscripcionFojas As String
    Dim TareasOtrosBienesInscripcionNumero As String
    Dim TareasOtrosBienesInscripcionAno As Integer
    Dim TareasOtrosBienesInscripcionCiudad As String
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim s As Integer
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Dim AccionesABM As New AccionesABM
        Dim TareasOtrosBienes As New TareasOtrosBienes

        Try
            s = TareasOtrosBienes.TareasOtrosBienesDelete(Session("Id"), Request.QueryString("MasterName"), CLng(Session("PersonaId")))
        Catch
            t = 0
        End Try
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_Return(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReturnButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLReturn", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & Request.QueryString("MasterName") & "&MasterId=" & Request.QueryString("MasterId")
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Session("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & Request.QueryString("MasterName") & "&MasterId=" & Request.QueryString("MasterId")
        Dim AccionesABM As New AccionesABM
        Dim TareasOtrosBienes As New TareasOtrosBienes
        Dim Tareas As New Tareas

        Try
            t = TareasOtrosBienes.TareasOtrosBienesUpdate(Session("Id"), CStr(txtTareasCodigo.Text), CLng(txtTareasOtrosBienesSecuencia.Text), CStr(txtTareasOtrosBienesDescription.Text), CStr(txtTareasOtrosBienesInscripcionFojas.Text), CStr(txtTareasOtrosBienesInscripcionNumero.Text), CInt(txtTareasOtrosBienesInscripcionAno.Text), CStr(txtTareasOtrosBienesInscripcionCiudad.Text), Session("PersonaId"))
            If t = False Then
                MyMessage1.Text = "No pudo eliminar el otro bien"
            Else
                Response.Redirect(Url, True)
            End If
        Catch
            t = 0
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim TareasOtrosBienes As New TareasOtrosBienes
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
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
                    DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("TareasCodigo", "TareasOtrosBienesSecuencia", "TareasOtrosBienes", MasterName)
                    t = AccionesABM.ObjectPartialInsert("TareasOtrosBienesId", "TareasCodigo", "TareasOtrosBienesSecuencia", "TareasOtrosBienes", MasterName, DetailSecuencia, CLng(Session("PersonaId")), DetailId)
                End If
                Session("Id") = DetailId
                If t = TareasOtrosBienes.LeerTareasOtrosBienes(Session("Id"), TareasCodigo, TareasOtrosBienesSecuencia, TareasOtrosBienesDescription, TareasOtrosBienesInscripcionFojas, TareasOtrosBienesInscripcionNumero, TareasOtrosBienesInscripcionAno, TareasOtrosBienesInscripcionCiudad) Then
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = TareasCodigo
                    txtTareasCodigo.ToolTip = Tareas.LeerTareasDescriptionByName(TareasCodigo)
                    txtTareasOtrosBienesSecuencia = FindControl("txtTareasOtrosBienesSecuencia")
                    txtTareasOtrosBienesSecuencia.Text = TareasOtrosBienesSecuencia
                    txtTareasOtrosBienesDescription = FindControl("txtTareasOtrosBienesDescription")
                    txtTareasOtrosBienesDescription.Text = TareasOtrosBienesDescription
                    txtTareasOtrosBienesInscripcionFojas = FindControl("txtTareasOtrosBienesInscripcionFojas")
                    txtTareasOtrosBienesInscripcionFojas.Text = TareasOtrosBienesInscripcionFojas
                    txtTareasOtrosBienesInscripcionNumero = FindControl("txtTareasOtrosBienesInscripcionNumero")
                    txtTareasOtrosBienesInscripcionNumero.Text = TareasOtrosBienesInscripcionNumero
                    txtTareasOtrosBienesInscripcionAno = FindControl("txtTareasOtrosBienesInscripcionAno")
                    txtTareasOtrosBienesInscripcionAno.Text = TareasOtrosBienesInscripcionAno
                    txtTareasOtrosBienesInscripcionCiudad = FindControl("txtTareasOtrosBienesInscripcionCiudad")
                    txtTareasOtrosBienesInscripcionCiudad.Text = TareasOtrosBienesInscripcionCiudad
                Else
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = Session("TareasCodigo")
                    txtTareasOtrosBienesSecuencia = FindControl("txtTareasOtrosBienesSecuencia")
                    txtTareasOtrosBienesSecuencia.Text = Session("TareasOtrosBienesSecuencia")
                End If
            Else
                txtTareasCodigo = FindControl("txtTareasCodigo")
                txtTareasOtrosBienesSecuencia = FindControl("txtTareasOtrosBienesSecuencia")
                txtTareasOtrosBienesDescription = FindControl("txtTareasOtrosBienesDescription")
                txtTareasOtrosBienesInscripcionFojas = FindControl("txtTareasOtrosBienesInscripcionFojas")
                txtTareasOtrosBienesInscripcionNumero = FindControl("txtTareasOtrosBienesInscripcionNumero")
                txtTareasOtrosBienesInscripcionAno = FindControl("txtTareasOtrosBienesInscripcionAno")
                txtTareasOtrosBienesInscripcionCiudad = FindControl("txtTareasOtrosBienesInscripcionCiudad")
            End If
        Catch
            t = False
        End Try
    End Sub
End Class
