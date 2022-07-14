Imports AjaxControlToolkit
Imports System.IO
Partial Class FichaCarpetaJudicialHipotecas
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
    Dim txtCarpetaJudicialCodigo As TextBox ' Etiqueta : Código Tarea - Control : txtCarpetaJudicialCodigo - Variable : CarpetaJudicialCodigo
    Dim txtCarpetaJudicialHipotecasSecuencia As TextBox ' Etiqueta : Secuencia - Control : txtCarpetaJudicialHipotecasSecuencia - Variable : CarpetaJudicialHipotecasSecuencia
    Dim txtCarpetaJudicialHipotecasDescription As TextBox ' Etiqueta : Descripción - Control : txtCarpetaJudicialHipotecasDescription - Variable : CarpetaJudicialHipotecasDescription
    Dim txtCarpetaJudicialHipotecasInscripcionFojas As TextBox
    Dim txtCarpetaJudicialHipotecasInscripcionNumero As TextBox
    Dim txtCarpetaJudicialHipotecasInscripcionAno As TextBox
    Dim txtCarpetaJudicialHipotecasInscripcionCiudad As TextBox
    Dim txtCarpetaJudicialHipotecasFojas As TextBox
    Dim txtCarpetaJudicialHipotecasNumero As TextBox
    Dim txtCarpetaJudicialHipotecasAno As TextBox
    Dim txtCarpetaJudicialHipotecasCiudad As TextBox
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim CarpetaJudicialCodigo As String ' Etiqueta : Código Tarea - Control : txtCarpetaJudicialCodigo - Variable : CarpetaJudicialCodigo
    Dim CarpetaJudicialHipotecasSecuencia As Long ' Etiqueta : Secuencia - Control : txtCarpetaJudicialHipotecasSecuencia - Variable : CarpetaJudicialHipotecasSecuencia
    Dim CarpetaJudicialHipotecasDescription As String ' Etiqueta : Descripción - Control : txtCarpetaJudicialHipotecasDescription - Variable : CarpetaJudicialHipotecasDescription
    Dim CarpetaJudicialHipotecasInscripcionFojas As String
    Dim CarpetaJudicialHipotecasInscripcionNumero As String
    Dim CarpetaJudicialHipotecasInscripcionAno As Integer
    Dim CarpetaJudicialHipotecasInscripcionCiudad As String
    Dim CarpetaJudicialHipotecasFojas As String
    Dim CarpetaJudicialHipotecasNumero As String
    Dim CarpetaJudicialHipotecasAno As Integer
    Dim CarpetaJudicialHipotecasCiudad As String
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim s As Integer
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicialHipotecas As New CarpetaJudicialHipotecas

        Try
            s = CarpetaJudicialHipotecas.CarpetaJudicialHipotecasDelete(Session("Id"), Request.QueryString("MasterName"), CLng(Session("PersonaId")))
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
        Dim Url As String = ""
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas
        Dim CarpetaJudicialCodigo As String = ""

        t = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))
        Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & Request.QueryString("MasterName") & "&MasterId=" & Request.QueryString("MasterId")

        If NombrePagina = "Ficha de TareasHipotecas" Then
            'MasterName cambia al código de la caprpeta judicial
            'MasterId se mantiene en el Id de la Tarea.
            CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
            Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=0&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & CarpetaJudicialCodigo & "&MasterId=" & Request.QueryString("MasterId")
        End If

        Response.Redirect(Url, True)
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
        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicialHipotecas As New CarpetaJudicialHipotecas

        If NombrePagina = "Ficha de TareasHipotecas" Then
            'MasterName cambia al código de la caprpeta judicial
            'MasterId se mantiene en el Id de la Tarea.
            CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
            Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Session("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & CarpetaJudicialCodigo & "&MasterId=" & Request.QueryString("MasterId")
        End If

        Try
            t = CarpetaJudicialHipotecas.CarpetaJudicialHipotecasUpdate(Session("Id"), CStr(txtCarpetaJudicialCodigo.Text), CLng(txtCarpetaJudicialHipotecasSecuencia.Text), CStr(txtCarpetaJudicialHipotecasDescription.Text), CStr(txtCarpetaJudicialHipotecasInscripcionFojas.Text), CStr(txtCarpetaJudicialHipotecasInscripcionNumero.Text), CInt(txtCarpetaJudicialHipotecasInscripcionAno.Text), CStr(txtCarpetaJudicialHipotecasInscripcionCiudad.Text), CStr(txtCarpetaJudicialHipotecasFojas.Text), CStr(txtCarpetaJudicialHipotecasNumero.Text), CInt(txtCarpetaJudicialHipotecasAno.Text), CStr(txtCarpetaJudicialHipotecasCiudad.Text), Session("PersonaId"))
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
        Dim CarpetaJudicialHipotecas As New CarpetaJudicialHipotecas
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

        If Request.QueryString("PaginaWebName") = "Ficha de TareasHipotecas" Then
            CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
            MyDeudor.Controls.Add(New LiteralControl(Tareas.ListarDatosDelDeudorPorTareasId(CLng(Request.QueryString("MasterId")), CarpetaJudicialCodigo)))
        End If

        Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler DeleteButton.Click, AddressOf RFC_Delete
        AddHandler ReturnButton.Click, AddressOf RFC_Return
        Try
            If Not IsPostBack Then
                MasterName = Request.QueryString("MasterName")
                If Request.QueryString("PaginaWebName") = "Ficha de TareasHipotecas" Then
                    MasterName = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
                End If
                Session("MasterId") = Request.QueryString("MasterId")
                DetailId = Request.QueryString("Id")
                If DetailId = 0 Then
                    DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("CarpetaJudicialCodigo", "CarpetaJudicialHipotecasSecuencia", "CarpetaJudicialHipotecas", MasterName)
                    t = AccionesABM.ObjectPartialInsert("CarpetaJudicialHipotecasId", "CarpetaJudicialCodigo", "CarpetaJudicialHipotecasSecuencia", "CarpetaJudicialHipotecas", MasterName, DetailSecuencia, CLng(Session("PersonaId")), DetailId)
                End If
                Session("Id") = DetailId
                If t = CarpetaJudicialHipotecas.LeerCarpetaJudicialHipotecas(Session("Id"), CarpetaJudicialCodigo, CarpetaJudicialHipotecasSecuencia, CarpetaJudicialHipotecasDescription, CarpetaJudicialHipotecasInscripcionFojas, CarpetaJudicialHipotecasInscripcionNumero, CarpetaJudicialHipotecasInscripcionAno, CarpetaJudicialHipotecasInscripcionCiudad, CarpetaJudicialHipotecasFojas, CarpetaJudicialHipotecasNumero, CarpetaJudicialHipotecasAno, CarpetaJudicialHipotecasCiudad) Then
                    txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                    txtCarpetaJudicialCodigo.Text = CarpetaJudicialCodigo
                    'txtCarpetaJudicialCodigo.ToolTip = CarpetaJudicial.LeerCarpetaJudicialDescriptionByName(CarpetaJudicialCodigo)
                    txtCarpetaJudicialHipotecasSecuencia = FindControl("txtCarpetaJudicialHipotecasSecuencia")
                    txtCarpetaJudicialHipotecasSecuencia.Text = CarpetaJudicialHipotecasSecuencia
                    txtCarpetaJudicialHipotecasDescription = FindControl("txtCarpetaJudicialHipotecasDescription")
                    txtCarpetaJudicialHipotecasDescription.Text = CarpetaJudicialHipotecasDescription
                    txtCarpetaJudicialHipotecasInscripcionFojas = FindControl("txtCarpetaJudicialHipotecasInscripcionFojas")
                    txtCarpetaJudicialHipotecasInscripcionFojas.Text = CarpetaJudicialHipotecasInscripcionFojas
                    txtCarpetaJudicialHipotecasInscripcionNumero = FindControl("txtCarpetaJudicialHipotecasInscripcionNumero")
                    txtCarpetaJudicialHipotecasInscripcionNumero.Text = CarpetaJudicialHipotecasInscripcionNumero
                    txtCarpetaJudicialHipotecasInscripcionAno = FindControl("txtCarpetaJudicialHipotecasInscripcionAno")
                    txtCarpetaJudicialHipotecasInscripcionAno.Text = CarpetaJudicialHipotecasInscripcionAno
                    txtCarpetaJudicialHipotecasInscripcionCiudad = FindControl("txtCarpetaJudicialHipotecasInscripcionCiudad")
                    txtCarpetaJudicialHipotecasInscripcionCiudad.Text = CarpetaJudicialHipotecasInscripcionCiudad
                    txtCarpetaJudicialHipotecasFojas = FindControl("txtCarpetaJudicialHipotecasFojas")
                    txtCarpetaJudicialHipotecasFojas.Text = CarpetaJudicialHipotecasFojas
                    txtCarpetaJudicialHipotecasNumero = FindControl("txtCarpetaJudicialHipotecasNumero")
                    txtCarpetaJudicialHipotecasNumero.Text = CarpetaJudicialHipotecasNumero
                    txtCarpetaJudicialHipotecasAno = FindControl("txtCarpetaJudicialHipotecasAno")
                    txtCarpetaJudicialHipotecasAno.Text = CarpetaJudicialHipotecasAno
                    txtCarpetaJudicialHipotecasCiudad = FindControl("txtCarpetaJudicialHipotecasCiudad")
                    txtCarpetaJudicialHipotecasCiudad.Text = CarpetaJudicialHipotecasCiudad

                Else
                    txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                    txtCarpetaJudicialCodigo.Text = Session("CarpetaJudicialCodigo")
                    txtCarpetaJudicialHipotecasSecuencia = FindControl("txtCarpetaJudicialHipotecasSecuencia")
                    txtCarpetaJudicialHipotecasSecuencia.Text = Session("CarpetaJudicialHipotecasSecuencia")
                End If
            Else
                txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                txtCarpetaJudicialHipotecasSecuencia = FindControl("txtCarpetaJudicialHipotecasSecuencia")
                txtCarpetaJudicialHipotecasDescription = FindControl("txtCarpetaJudicialHipotecasDescription")
                txtCarpetaJudicialHipotecasInscripcionFojas = FindControl("txtCarpetaJudicialHipotecasInscripcionFojas")
                txtCarpetaJudicialHipotecasInscripcionNumero = FindControl("txtCarpetaJudicialHipotecasInscripcionNumero")
                txtCarpetaJudicialHipotecasInscripcionAno = FindControl("txtCarpetaJudicialHipotecasInscripcionAno")
                txtCarpetaJudicialHipotecasInscripcionCiudad = FindControl("txtCarpetaJudicialHipotecasInscripcionCiudad")
                txtCarpetaJudicialHipotecasFojas = FindControl("txtCarpetaJudicialHipotecasFojas")
                txtCarpetaJudicialHipotecasNumero = FindControl("txtCarpetaJudicialHipotecasNumero")
                txtCarpetaJudicialHipotecasAno = FindControl("txtCarpetaJudicialHipotecasAno")
                txtCarpetaJudicialHipotecasCiudad = FindControl("txtCarpetaJudicialHipotecasCiudad")

            End If
        Catch
            t = False
        End Try
    End Sub
End Class
