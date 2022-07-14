Imports AjaxControlToolkit
Imports System.IO
Partial Class FichaTareasHipotecas
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
    Dim txtTareasHipotecasSecuencia As TextBox ' Etiqueta : Secuencia - Control : txtTareasHipotecasSecuencia - Variable : TareasHipotecasSecuencia
    Dim txtTareasHipotecasDescription As TextBox ' Etiqueta : Descripción - Control : txtTareasHipotecasDescription - Variable : TareasHipotecasDescription
    Dim txtTareasHipotecasInscripcionFojas As TextBox
    Dim txtTareasHipotecasInscripcionNumero As TextBox
    Dim txtTareasHipotecasInscripcionAno As TextBox
    Dim txtTareasHipotecasInscripcionCiudad As TextBox
    Dim txtTareasHipotecasFojas As TextBox
    Dim txtTareasHipotecasNumero As TextBox
    Dim txtTareasHipotecasAno As TextBox
    Dim txtTareasHipotecasCiudad As TextBox
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim TareasCodigo As String ' Etiqueta : Código Tarea - Control : txtTareasCodigo - Variable : TareasCodigo
    Dim TareasHipotecasSecuencia As Long ' Etiqueta : Secuencia - Control : txtTareasHipotecasSecuencia - Variable : TareasHipotecasSecuencia
    Dim TareasHipotecasDescription As String ' Etiqueta : Descripción - Control : txtTareasHipotecasDescription - Variable : TareasHipotecasDescription
    Dim TareasHipotecasInscripcionFojas As String
    Dim TareasHipotecasInscripcionNumero As String
    Dim TareasHipotecasInscripcionAno As Integer
    Dim TareasHipotecasInscripcionCiudad As String
    Dim TareasHipotecasFojas As String
    Dim TareasHipotecasNumero As String
    Dim TareasHipotecasAno As Integer
    Dim TareasHipotecasCiudad As String
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim s As Integer
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Dim AccionesABM As New AccionesABM
        Dim TareasHipotecas As New TareasHipotecas

        Try
            s = TareasHipotecas.TareasHipotecasDelete(Session("Id"), Request.QueryString("MasterName"), CLng(Session("PersonaId")))
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
        Dim TareasHipotecas As New TareasHipotecas
        Dim Tareas As New Tareas

        Try
            t = TareasHipotecas.TareasHipotecasUpdate(Session("Id"), CStr(txtTareasCodigo.Text), CLng(txtTareasHipotecasSecuencia.Text), CStr(txtTareasHipotecasDescription.Text), CStr(txtTareasHipotecasInscripcionFojas.Text), CStr(txtTareasHipotecasInscripcionNumero.Text), CInt(txtTareasHipotecasInscripcionAno.Text), CStr(txtTareasHipotecasInscripcionCiudad.Text), CStr(txtTareasHipotecasFojas.Text), CStr(txtTareasHipotecasNumero.Text), CInt(txtTareasHipotecasAno.Text), CStr(txtTareasHipotecasCiudad.Text), Session("PersonaId"))
            If t = False Then
                MyMessage1.Text = "No pudo actualizar hipoteca"
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
        Dim TareasHipotecas As New TareasHipotecas
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
                    DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("TareasCodigo", "TareasHipotecasSecuencia", "TareasHipotecas", MasterName)
                    t = AccionesABM.ObjectPartialInsert("TareasHipotecasId", "TareasCodigo", "TareasHipotecasSecuencia", "TareasHipotecas", MasterName, DetailSecuencia, CLng(Session("PersonaId")), DetailId)
                End If
                Session("Id") = DetailId
                If t = TareasHipotecas.LeerTareasHipotecas(Session("Id"), TareasCodigo, TareasHipotecasSecuencia, TareasHipotecasDescription, TareasHipotecasInscripcionFojas, TareasHipotecasInscripcionNumero, TareasHipotecasInscripcionAno, TareasHipotecasInscripcionCiudad, TareasHipotecasFojas, TareasHipotecasNumero, TareasHipotecasAno, TareasHipotecasCiudad) Then
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = TareasCodigo
                    txtTareasCodigo.ToolTip = Tareas.LeerTareasDescriptionByName(TareasCodigo)
                    txtTareasHipotecasSecuencia = FindControl("txtTareasHipotecasSecuencia")
                    txtTareasHipotecasSecuencia.Text = TareasHipotecasSecuencia
                    txtTareasHipotecasDescription = FindControl("txtTareasHipotecasDescription")
                    txtTareasHipotecasDescription.Text = TareasHipotecasDescription
                    txtTareasHipotecasInscripcionFojas = FindControl("txtTareasHipotecasInscripcionFojas")
                    txtTareasHipotecasInscripcionFojas.Text = TareasHipotecasInscripcionFojas
                    txtTareasHipotecasInscripcionNumero = FindControl("txtTareasHipotecasInscripcionNumero")
                    txtTareasHipotecasInscripcionNumero.Text = TareasHipotecasInscripcionNumero
                    txtTareasHipotecasInscripcionAno = FindControl("txtTareasHipotecasInscripcionAno")
                    txtTareasHipotecasInscripcionAno.Text = TareasHipotecasInscripcionAno
                    txtTareasHipotecasInscripcionCiudad = FindControl("txtTareasHipotecasInscripcionCiudad")
                    txtTareasHipotecasInscripcionCiudad.Text = TareasHipotecasInscripcionCiudad
                    txtTareasHipotecasFojas = FindControl("txtTareasHipotecasFojas")
                    txtTareasHipotecasFojas.Text = TareasHipotecasFojas
                    txtTareasHipotecasNumero = FindControl("txtTareasHipotecasNumero")
                    txtTareasHipotecasNumero.Text = TareasHipotecasNumero
                    txtTareasHipotecasAno = FindControl("txtTareasHipotecasAno")
                    txtTareasHipotecasAno.Text = TareasHipotecasAno
                    txtTareasHipotecasCiudad = FindControl("txtTareasHipotecasCiudad")
                    txtTareasHipotecasCiudad.Text = TareasHipotecasCiudad

                Else
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = Session("TareasCodigo")
                    txtTareasHipotecasSecuencia = FindControl("txtTareasHipotecasSecuencia")
                    txtTareasHipotecasSecuencia.Text = Session("TareasHipotecasSecuencia")
                End If
            Else
                txtTareasCodigo = FindControl("txtTareasCodigo")
                txtTareasHipotecasSecuencia = FindControl("txtTareasHipotecasSecuencia")
                txtTareasHipotecasDescription = FindControl("txtTareasHipotecasDescription")
                txtTareasHipotecasInscripcionFojas = FindControl("txtTareasHipotecasInscripcionFojas")
                txtTareasHipotecasInscripcionNumero = FindControl("txtTareasHipotecasInscripcionNumero")
                txtTareasHipotecasInscripcionAno = FindControl("txtTareasHipotecasInscripcionAno")
                txtTareasHipotecasInscripcionCiudad = FindControl("txtTareasHipotecasInscripcionCiudad")
                txtTareasHipotecasFojas = FindControl("txtTareasHipotecasFojas")
                txtTareasHipotecasNumero = FindControl("txtTareasHipotecasNumero")
                txtTareasHipotecasAno = FindControl("txtTareasHipotecasAno")
                txtTareasHipotecasCiudad = FindControl("txtTareasHipotecasCiudad")

            End If
        Catch
            t = False
        End Try
    End Sub
End Class
