Imports AjaxControlToolkit
Imports System.IO
Partial Class FichaTareasAvales
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
    Dim txtTareasAvalesSecuencia As TextBox ' Etiqueta : Secuencia - Control : txtTareasAvalesSecuencia - Variable : TareasAvalesSecuencia
    Dim txtTareasAvalesRUT As TextBox
    Dim txtTareasAvalesNombres As TextBox
    Dim txtTareasAvalesApellidos As TextBox
    Dim txtTareasAvalesDireccion As TextBox
    Dim txtTareasAvalesComuna As TextBox
    Dim txtTareasAvalesProfesion As TextBox
    Dim txtTareasAvalesFechaEscritura As TextBox
    Dim txtTareasAvalesCiudadEscritura As TextBox
    Dim txtTareasAvalesNotarioEscritura As TextBox
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim TareasCodigo As String ' Etiqueta : Código Tarea - Control : txtTareasCodigo - Variable : TareasCodigo
    Dim TareasAvalesSecuencia As Long ' Etiqueta : Secuencia - Control : txtTareasAvalesSecuencia - Variable : TareasAvalesSecuencia
    Dim TareasAvalesRUT As String
    Dim TareasAvalesNombres As String
    Dim TareasAvalesApellidos As String
    Dim TareasAvalesDireccion As String
    Dim TareasAvalesComuna As String
    Dim TareasAvalesProfesion As String
    Dim TareasAvalesFechaEscritura As Date
    Dim TareasAvalesCiudadEscritura As String
    Dim TareasAvalesNotarioEscritura As String
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim s As Integer
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Dim AccionesABM As New AccionesABM
        Dim TareasAvales As New TareasAvales

        Try
            s = TareasAvales.TareasAvalesDelete(Session("Id"), Request.QueryString("MasterName"), CLng(Session("PersonaId")))
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
        Dim TareasAvales As New TareasAvales
        Dim Tareas As New Tareas

        Try
            t = TareasAvales.TareasAvalesUpdate(Session("Id"), CStr(txtTareasCodigo.Text), CLng(txtTareasAvalesSecuencia.Text), CStr(txtTareasAvalesRUT.Text), CStr(txtTareasAvalesNombres.Text), CStr(txtTareasAvalesApellidos.Text), CStr(txtTareasAvalesDireccion.Text), CStr(txtTareasAvalesComuna.Text), CStr(txtTareasAvalesProfesion.Text), CDate(txtTareasAvalesFechaEscritura.Text), CStr(txtTareasAvalesCiudadEscritura.Text), CStr(txtTareasAvalesNotarioEscritura.Text), Session("PersonaId"))
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
        Dim TareasAvales As New TareasAvales
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
                    DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("TareasCodigo", "TareasAvalesSecuencia", "TareasAvales", MasterName)
                    t = AccionesABM.ObjectPartialInsert("TareasAvalesId", "TareasCodigo", "TareasAvalesSecuencia", "TareasAvales", MasterName, DetailSecuencia, CLng(Session("PersonaId")), DetailId)
                End If
                Session("Id") = DetailId
                If t = TareasAvales.LeerTareasAvales(Session("Id"), TareasCodigo, TareasAvalesSecuencia, TareasAvalesRUT, TareasAvalesNombres, TareasAvalesApellidos, TareasAvalesDireccion, TareasAvalesComuna, TareasAvalesProfesion, TareasAvalesFechaEscritura, TareasAvalesCiudadEscritura, TareasAvalesNotarioEscritura) Then
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = TareasCodigo
                    txtTareasCodigo.ToolTip = Tareas.LeerTareasDescriptionByName(TareasCodigo)
                    txtTareasAvalesSecuencia = FindControl("txtTareasAvalesSecuencia")
                    txtTareasAvalesSecuencia.Text = TareasAvalesSecuencia
                    txtTareasAvalesRUT = FindControl("txtTareasAvalesRUT")
                    txtTareasAvalesRUT.Text = TareasAvalesRUT
                    txtTareasAvalesNombres = FindControl("txtTareasAvalesNombres")
                    txtTareasAvalesNombres.Text = TareasAvalesNombres
                    txtTareasAvalesApellidos = FindControl("txtTareasAvalesApellidos")
                    txtTareasAvalesApellidos.Text = TareasAvalesApellidos
                    txtTareasAvalesDireccion = FindControl("txtTareasAvalesDireccion")
                    txtTareasAvalesDireccion.Text = TareasAvalesDireccion
                    txtTareasAvalesComuna = FindControl("txtTareasAvalesComuna")
                    txtTareasAvalesComuna.Text = TareasAvalesComuna
                    txtTareasAvalesProfesion = FindControl("txtTareasAvalesProfesion")
                    txtTareasAvalesProfesion.Text = TareasAvalesProfesion
                    txtTareasAvalesFechaEscritura = FindControl("txtTareasAvalesFechaEscritura")
                    txtTareasAvalesCiudadEscritura = FindControl("txtTareasAvalesCiudadEscritura")
                    txtTareasAvalesNotarioEscritura = FindControl("txtTareasAvalesNotarioEscritura")
                    txtTareasAvalesFechaEscritura.Text = TareasAvalesFechaEscritura
                    txtTareasAvalesCiudadEscritura.Text = TareasAvalesCiudadEscritura
                    txtTareasAvalesNotarioEscritura.Text = TareasAvalesNotarioEscritura
                Else
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = Session("TareasCodigo")
                    txtTareasAvalesSecuencia = FindControl("txtTareasAvalesSecuencia")
                    txtTareasAvalesSecuencia.Text = Session("TareasAvalesSecuencia")
                End If
            Else
                txtTareasCodigo = FindControl("txtTareasCodigo")
                txtTareasAvalesSecuencia = FindControl("txtTareasAvalesSecuencia")
                txtTareasAvalesRUT = FindControl("txtTareasAvalesRUT")
                txtTareasAvalesNombres = FindControl("txtTareasAvalesNombres")
                txtTareasAvalesApellidos = FindControl("txtTareasAvalesApellidos")
                txtTareasAvalesDireccion = FindControl("txtTareasAvalesDireccion")
                txtTareasAvalesComuna = FindControl("txtTareasAvalesComuna")
                txtTareasAvalesProfesion = FindControl("txtTareasAvalesProfesion")
                txtTareasAvalesFechaEscritura = FindControl("txtTareasAvalesFechaEscritura")
                txtTareasAvalesCiudadEscritura = FindControl("txtTareasAvalesCiudadEscritura")
                txtTareasAvalesNotarioEscritura = FindControl("txtTareasAvalesNotarioEscritura")
            End If
        Catch
            t = False
        End Try
    End Sub
End Class
