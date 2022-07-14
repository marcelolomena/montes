Imports AjaxControlToolkit
Imports System.IO
Partial Class FichaCarpetaJudicialAvales
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
    Dim txtCarpetaJudicialCodigo As TextBox ' Etiqueta : Código Tarea - Control : txtCarpetaJudicialCodigo - Variable : CarpetaJudicialCodigo
    Dim txtCarpetaJudicialAvalesSecuencia As TextBox ' Etiqueta : Secuencia - Control : txtCarpetaJudicialAvalesSecuencia - Variable : CarpetaJudicialAvalesSecuencia
    Dim txtCarpetaJudicialAvalesRUT As TextBox
    Dim txtCarpetaJudicialAvalesNombres As TextBox
    Dim txtCarpetaJudicialAvalesApellidos As TextBox
    Dim txtCarpetaJudicialAvalesDireccion As TextBox
    Dim txtCarpetaJudicialAvalesComuna As TextBox
    Dim txtCarpetaJudicialAvalesProfesion As TextBox
    Dim txtCarpetaJudicialAvalesIsReciproco As CheckBox
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim CarpetaJudicialCodigo As String ' Etiqueta : Código Tarea - Control : txtCarpetaJudicialCodigo - Variable : CarpetaJudicialCodigo
    Dim CarpetaJudicialAvalesSecuencia As Long ' Etiqueta : Secuencia - Control : txtCarpetaJudicialAvalesSecuencia - Variable : CarpetaJudicialAvalesSecuencia
    Dim CarpetaJudicialAvalesRUT As String
    Dim CarpetaJudicialAvalesNombres As String
    Dim CarpetaJudicialAvalesApellidos As String
    Dim CarpetaJudicialAvalesDireccion As String
    Dim CarpetaJudicialAvalesComuna As String
    Dim CarpetaJudicialAvalesProfesion As String
    Dim CarpetaJudicialAvalesIsReciproco As Boolean
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim s As Integer
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicialAvales As New CarpetaJudicialAvales

        Try
            s = CarpetaJudicialAvales.CarpetaJudicialAvalesDelete(Session("Id"), Request.QueryString("MasterName"), CLng(Session("PersonaId")))
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

        If NombrePagina = "Ficha de TareasAvales" Then
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
        Dim CarpetaJudicialAvales As New CarpetaJudicialAvales

        If NombrePagina = "Ficha de TareasAvales" Then
            'MasterName cambia al código de la caprpeta judicial
            'MasterId se mantiene en el Id de la Tarea.
            CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
            Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Session("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & CarpetaJudicialCodigo & "&MasterId=" & Request.QueryString("MasterId")
        End If



        Try
            t = CarpetaJudicialAvales.CarpetaJudicialAvalesUpdate(Session("Id"), CStr(txtCarpetaJudicialCodigo.Text), CLng(txtCarpetaJudicialAvalesSecuencia.Text), CStr(txtCarpetaJudicialAvalesRUT.Text), CStr(txtCarpetaJudicialAvalesNombres.Text), CStr(txtCarpetaJudicialAvalesApellidos.Text), CStr(txtCarpetaJudicialAvalesDireccion.Text), CStr(txtCarpetaJudicialAvalesComuna.Text), CStr(txtCarpetaJudicialAvalesProfesion.Text), CBool(txtCarpetaJudicialAvalesIsReciproco.Checked), Session("PersonaId"))
            If t = False Then
                MyMessage1.Text = "No pudo actualizar los datos del aval"
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
        Dim CarpetaJudicialAvales As New CarpetaJudicialAvales
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

        If Request.QueryString("PaginaWebName") = "Ficha de TareasAvales" Then
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
                If Request.QueryString("PaginaWebName") = "Ficha de TareasAvales" Then
                    MasterName = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
                End If
                Session("MasterId") = Request.QueryString("MasterId")
                DetailId = Request.QueryString("Id")
                If DetailId = 0 Then
                    DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("CarpetaJudicialCodigo", "CarpetaJudicialAvalesSecuencia", "CarpetaJudicialAvales", MasterName)
                    t = AccionesABM.ObjectPartialInsert("CarpetaJudicialAvalesId", "CarpetaJudicialCodigo", "CarpetaJudicialAvalesSecuencia", "CarpetaJudicialAvales", MasterName, DetailSecuencia, CLng(Session("PersonaId")), DetailId)
                End If
                Session("Id") = DetailId
                If t = CarpetaJudicialAvales.LeerCarpetaJudicialAvales(Session("Id"), CarpetaJudicialCodigo, CarpetaJudicialAvalesSecuencia, CarpetaJudicialAvalesRUT, CarpetaJudicialAvalesNombres, CarpetaJudicialAvalesApellidos, CarpetaJudicialAvalesDireccion, CarpetaJudicialAvalesComuna, CarpetaJudicialAvalesProfesion, CarpetaJudicialAvalesIsReciproco) Then
                    txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                    txtCarpetaJudicialCodigo.Text = CarpetaJudicialCodigo
                    'txtCarpetaJudicialCodigo.ToolTip = CarpetaJudicial.LeerCarpetaJudicialDescriptionByName(CarpetaJudicialCodigo)
                    txtCarpetaJudicialAvalesSecuencia = FindControl("txtCarpetaJudicialAvalesSecuencia")
                    txtCarpetaJudicialAvalesSecuencia.Text = CarpetaJudicialAvalesSecuencia
                    txtCarpetaJudicialAvalesRUT = FindControl("txtCarpetaJudicialAvalesRUT")
                    txtCarpetaJudicialAvalesRUT.Text = CarpetaJudicialAvalesRUT
                    txtCarpetaJudicialAvalesNombres = FindControl("txtCarpetaJudicialAvalesNombres")
                    txtCarpetaJudicialAvalesNombres.Text = CarpetaJudicialAvalesNombres
                    txtCarpetaJudicialAvalesApellidos = FindControl("txtCarpetaJudicialAvalesApellidos")
                    txtCarpetaJudicialAvalesApellidos.Text = CarpetaJudicialAvalesApellidos
                    txtCarpetaJudicialAvalesDireccion = FindControl("txtCarpetaJudicialAvalesDireccion")
                    txtCarpetaJudicialAvalesDireccion.Text = CarpetaJudicialAvalesDireccion
                    txtCarpetaJudicialAvalesComuna = FindControl("txtCarpetaJudicialAvalesComuna")
                    txtCarpetaJudicialAvalesComuna.Text = CarpetaJudicialAvalesComuna
                    txtCarpetaJudicialAvalesProfesion = FindControl("txtCarpetaJudicialAvalesProfesion")
                    txtCarpetaJudicialAvalesProfesion.Text = CarpetaJudicialAvalesProfesion
                    txtCarpetaJudicialAvalesIsReciproco = FindControl("txtCarpetaJudicialAvalesIsReciproco")
                    txtCarpetaJudicialAvalesIsReciproco.Checked = CBool(CarpetaJudicialAvalesIsReciproco)
                Else
                    txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                    txtCarpetaJudicialCodigo.Text = Session("CarpetaJudicialCodigo")
                    txtCarpetaJudicialAvalesSecuencia = FindControl("txtCarpetaJudicialAvalesSecuencia")
                    txtCarpetaJudicialAvalesSecuencia.Text = Session("CarpetaJudicialAvalesSecuencia")
                End If
            Else
                txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                txtCarpetaJudicialAvalesSecuencia = FindControl("txtCarpetaJudicialAvalesSecuencia")
                txtCarpetaJudicialAvalesRUT = FindControl("txtCarpetaJudicialAvalesRUT")
                txtCarpetaJudicialAvalesNombres = FindControl("txtCarpetaJudicialAvalesNombres")
                txtCarpetaJudicialAvalesApellidos = FindControl("txtCarpetaJudicialAvalesApellidos")
                txtCarpetaJudicialAvalesDireccion = FindControl("txtCarpetaJudicialAvalesDireccion")
                txtCarpetaJudicialAvalesComuna = FindControl("txtCarpetaJudicialAvalesComuna")
                txtCarpetaJudicialAvalesProfesion = FindControl("txtCarpetaJudicialAvalesProfesion")
                txtCarpetaJudicialAvalesIsReciproco = FindControl("txtCarpetaJudicialAvalesIsReciproco")
            End If
        Catch
            t = False
        End Try
    End Sub

End Class
