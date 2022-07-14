Imports AjaxControlToolkit
Partial Class FichaTareasNotas
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 15-06-2011 11:14:07
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
    Dim txtTareasCodigo As TextBox ' Etiqueta : Tarea # - Control : txtTareasCodigo - Variable : TareasCodigo
    Dim txtTareasNotasSecuencia As TextBox ' Etiqueta : Secuencia - Control : txtTareasNotasSecuencia - Variable : TareasNotasSecuencia
    Dim txtTareasNotasTime As TextBox ' Etiqueta : Fecha y Hora - Control : txtTareasNotasTime - Variable : TareasNotasTime
    Dim txtTareasNotasFrom As TextBox ' Etiqueta : De - Control : txtTareasNotasFrom - Variable : TareasNotasFrom
    Dim txtTareasNotasTo As TextBox ' Etiqueta : A - Control : txtTareasNotasTo - Variable : TareasNotasTo
    Dim txtTareasNotasSubject As TextBox ' Etiqueta : Materia - Control : txtTareasNotasSubject - Variable : TareasNotasSubject
    Dim txtTareasNotasBody As TextBox ' Etiqueta : Texto del Mensaje - Control : txtTareasNotasBody - Variable : TareasNotasBody
    '-------------------------------------------------------
    ' Atributos para aplicar el cambio de estado de la tarea
    '-------------------------------------------------------
    Dim txtEstadoTareasCodigo As DropDownList ' Etiqueta : Estado de Tarea - Control : txtEstadoTareasCodigo - Variable : EstadoTareasCodigo
    Dim txtEstadoTareasCodigoDescription As TextBox ' Etiqueta : Estado de Tarea - Control : txtEstadoTareasCodigo - Variable : EstadoTareasCodigo
    Dim chkEstadoTareasCodigo As CheckBox
    Dim EstadoTareasCodigo As String
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim TareasCodigo As String ' Etiqueta : Tarea # - Control : txtTareasCodigo - Variable : TareasCodigo
    Dim TareasNotasSecuencia As Long ' Etiqueta : Secuencia - Control : txtTareasNotasSecuencia - Variable : TareasNotasSecuencia
    Dim TareasNotasTime As Date ' Etiqueta : Fecha y Hora - Control : txtTareasNotasTime - Variable : TareasNotasTime
    Dim TareasNotasFrom As String ' Etiqueta : De - Control : txtTareasNotasFrom - Variable : TareasNotasFrom
    Dim TareasNotasTo As String ' Etiqueta : A - Control : txtTareasNotasTo - Variable : TareasNotasTo
    Dim TareasNotasSubject As String ' Etiqueta : Materia - Control : txtTareasNotasSubject - Variable : TareasNotasSubject
    Dim TareasNotasBody As String ' Etiqueta : Texto del Mensaje - Control : txtTareasNotasBody - Variable : TareasNotasBody
    '----------------------------------------
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Dim AccionesABM As New AccionesABM
        Dim TareasNotas As New TareasNotas
        Try
            t = TareasNotas.TareasNotasDelete(Session("Id"), Request.QueryString("MasterName"), CLng(Session("PersonaId")))
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
        Dim AccionesABM As New AccionesABM
        't = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        'Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Session("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & Request.QueryString("MasterName") & "&MasterId=" & Request.QueryString("MasterId")
        t = Lecturas.LeerURLStatementFormularioWeb("URLReturn", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Dim TareasNotas As New TareasNotas
        Dim TareasId As Long
        Dim Tareas As New Tareas
        Try
            t = TareasNotas.TareasNotasUpdate(Session("Id"), CStr(txtTareasCodigo.Text), CLng(txtTareasNotasSecuencia.Text), CDate(txtTareasNotasTime.Text), CStr(txtTareasNotasFrom.Text), CStr(txtTareasNotasTo.Text), CStr(txtTareasNotasSubject.Text), CStr(txtTareasNotasBody.Text), Session("PersonaId"))
            t = Tareas.LeerTareasByName(TareasId, txtTareasCodigo.Text)
            t = AccionesABM.EnviarMensaje(TareasId, Session("Id"), Session("PersonaId"))
            If chkEstadotareasCodigo.Checked = True Then
                'Insertar código para cambiar el estado de la tarea.
                t = Tareas.EstadoTareasCodigoUpdate(TareasId, txtTareasCodigo.Text, txtEstadoTareasCodigo.Text, Session("PersonaId"))
            End If
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim TareasNotas As New TareasNotas
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim Coordinador As String
        Dim Ejecutor As String
        Dim UsuariosCodigo As String
        Dim now As DateTime = DateTime.Now
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim PaginaWebName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim MasterName As String = "" ' Guarda el nombre del Maestro al que pertenece el detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Dim sSQL As String = ""
        Dim sqlSource As AccessDataSource

        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler DeleteButton.Click, AddressOf RFC_Delete
        AddHandler ReturnButton.Click, AddressOf RFC_Return
        ReturnButton.Visible = False
        NewButton.Visible = False
        Try
            If Not IsPostBack Then
                MasterName = Request.QueryString("MasterName")
                Session("MasterId") = Request.QueryString("MasterId")
                DetailId = Request.QueryString("Id")
                If DetailId = 0 Then
                    DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("TareasCodigo", "TareasNotasSecuencia", "TareasNotas", MasterName)
                    t = AccionesABM.ObjectPartialInsert("TareasNotasId", "TareasCodigo", "TareasNotasSecuencia", "TareasNotas", MasterName, DetailSecuencia, CLng(Session("PersonaId")), DetailId)
                End If
                Session("Id") = DetailId
                If t = TareasNotas.LeerTareasNotas(Session("Id"), TareasCodigo, TareasNotasSecuencia, TareasNotasTime, TareasNotasFrom, TareasNotasTo, TareasNotasSubject, TareasNotasBody) Then
                    If Len(TareasNotasFrom) = 0 And Len(TareasNotasTo) = 0 Then
                        Coordinador = Tareas.LeerCoordinadorDeTareas(TareasCodigo)
                        Ejecutor = Tareas.LeerEjecutorDeTareas(TareasCodigo)
                        UsuariosCodigo = Tareas.LeerTareasUsuariosCodigoByName(TareasCodigo)
                        If UsuariosCodigo = Coordinador Then    'Mensaje del coordinador al ejecutor
                            TareasNotasFrom = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)
                            TareasNotasTo = Usuarios.LeerUsuariosDescriptionByName(Ejecutor)
                        Else                                    'Mensaje del ejecutor al coordinador
                            TareasNotasFrom = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)
                            TareasNotasTo = Usuarios.LeerUsuariosDescriptionByName(Coordinador)
                        End If
                        TareasNotasTime = Now
                    End If
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = TareasCodigo
                    txtTareasNotasSecuencia = FindControl("txtTareasNotasSecuencia")
                    txtTareasNotasSecuencia.Text = TareasNotasSecuencia
                    txtTareasNotasTime = FindControl("txtTareasNotasTime")
                    txtTareasNotasTime.Text = TareasNotasTime
                    txtTareasNotasFrom = FindControl("txtTareasNotasFrom")
                    txtTareasNotasFrom.Text = TareasNotasFrom
                    txtTareasNotasTo = FindControl("txtTareasNotasTo")
                    txtTareasNotasTo.Text = TareasNotasTo
                    txtTareasNotasSubject = FindControl("txtTareasNotasSubject")
                    txtTareasNotasSubject.Text = TareasNotasSubject
                    txtTareasNotasBody = FindControl("txtTareasNotasBody")
                    txtTareasNotasBody.Text = TareasNotasBody
                    '---------------------------------------------------------------------
                    txtEstadoTareasCodigo = FindControl("txtEstadoTareasCodigo")
                    EstadoTareasCodigo = Tareas.LeerEstadoTareasCodigo(Request.QueryString("MasterId"))
                    sSQL = "Select EstadoTareas_1.EstadoTareasName As EstadoTareasCodigo "
                    sSQL = sSQL & "FROM (EstadoTareas INNER JOIN TransicionEstadoTareas ON EstadoTareas.EstadoTareasId = TransicionEstadoTareas.CurrentStateId) INNER JOIN EstadoTareas AS EstadoTareas_1 ON TransicionEstadoTareas.NextStateId = EstadoTareas_1.EstadoTareasId "
                    sSQL = sSQL & "WHERE (((EstadoTareas.EstadoTareasName)= '" & EstadoTareasCodigo & "'))"
                    sqlSource = FindControl("dstxtEstadoTareasCodigo")
                    sqlSource.SelectCommand = sSQL
                    txtEstadoTareasCodigoDescription = FindControl("txtEstadoTareasCodigoDescription")
                    chkEstadoTareasCodigo = FindControl("chkEstadoTareasCodigo")
                    chkEstadoTareasCodigo.Checked = False
                Else
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = Session("TareasCodigo")
                    txtTareasNotasSecuencia = FindControl("txtTareasNotasSecuencia")
                    txtTareasNotasSecuencia.Text = Session("TareasNotasSecuencia")
                End If
            Else
                txtTareasCodigo = FindControl("txtTareasCodigo")
                txtTareasNotasSecuencia = FindControl("txtTareasNotasSecuencia")
                txtTareasNotasTime = FindControl("txtTareasNotasTime")
                txtTareasNotasFrom = FindControl("txtTareasNotasFrom")
                txtTareasNotasTo = FindControl("txtTareasNotasTo")
                txtTareasNotasSubject = FindControl("txtTareasNotasSubject")
                txtTareasNotasBody = FindControl("txtTareasNotasBody")
                txtEstadoTareasCodigo = FindControl("txtEstadoTareasCodigo")
                chkEstadoTareasCodigo = FindControl("chkEstadoTareasCodigo")
            End If
        Catch
            t = False
        End Try
    End Sub
End Class
