Imports AjaxControlToolkit
Imports System.IO
Partial Class FichaTareasDocs
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
    Dim txtTareasDocsSecuencia As TextBox ' Etiqueta : Secuencia - Control : txtTareasDocsSecuencia - Variable : TareasDocsSecuencia
    Dim txtTareasDocsCodigo As TextBox ' Etiqueta : Código de Documento - Control : txtTareasDocsCodigo - Variable : TareasDocsCodigo
    Dim txtTareasDocsNombre As TextBox ' Etiqueta : Título del Documento - Control : txtTareasDocsNombre - Variable : TareasDocsNombre
    Dim txtTareasDocsDescription As TextBox ' Etiqueta : Descripción - Control : txtTareasDocsDescription - Variable : TareasDocsDescription
    Dim txtTareasDocsPath As TextBox ' Etiqueta : Archivo Físico - Control : txtTareasDocsPath - Variable : TareasDocsPath
    Dim txtTareasPlantillaCodigo As TextBox ' Etiqueta : Formulario - Control : txtTareasPlantillaCodigo - Variable : TareasPlantillaCodigo
    Dim txtTareasPlantillaCodigoDescription As TextBox ' Etiqueta : Formulario - Control : txtTareasPlantillaCodigo - Variable : TareasPlantillaCodigo
    Dim txtTipoDocName As TextBox
    Dim txtTipoDocNameDescription As TextBox
    ' Se agregar para filtrar la lista de rutas por empresa y cliente
    Dim sqlSource As AccessDataSource
    ' ---------------------------------------------------------------
    Dim txtAreasName As TextBox ' Etiqueta : Área - Control : txtAreasName - Variable : AreasName
    Dim txtAreasNameDescription As TextBox ' Etiqueta : Área - Control : txtAreasName - Variable : AreasName
    Dim txtEmpresasCodigo As TextBox ' Etiqueta : Empresa - Control : txtEmpresasCodigo - Variable : EmpresasCodigo
    Dim txtEmpresasCodigoDescription As TextBox ' Etiqueta : Empresa - Control : txtEmpresasCodigo - Variable : EmpresasCodigo
    Dim txtContratoCodigo As TextBox ' Etiqueta : Contrato - Control : txtContratoCodigo - Variable : ContratoCodigo
    Dim txtContratoCodigoDescription As TextBox ' Etiqueta : Contrato - Control : txtContratoCodigo - Variable : ContratoCodigo
    Dim txtTareasDocsFEmision As TextBox ' Etiqueta : Fecha del Documento - Control : txtTareasDocsFEmision - Variable : TareasDocsFEmision
    Dim txtUsuariosCodigo As TextBox ' Etiqueta : Responsable Actividad - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim txtUsuariosCodigoDescription As TextBox ' Etiqueta : Responsable Actividad - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim txtTareasDocsObservaciones As TextBox ' Etiqueta : Observaciones - Control : txtTareasDocsObservaciones - Variable : TareasDocsObservaciones
    Dim txtTareasDocsResponsableArea As TextBox ' Etiqueta : Responsable Area - Control : txtTareasDocsResponsableArea - Variable : TareasDocsResponsableArea
    Dim txtTareasDocsCargoResponsable As TextBox ' Etiqueta : Cargos del Responsable - Control : txtTareasDocsCargoResponsable - Variable : TareasDocsCargoResponsable
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim TareasCodigo As String ' Etiqueta : Código Tarea - Control : txtTareasCodigo - Variable : TareasCodigo
    Dim TareasDocsSecuencia As Long ' Etiqueta : Secuencia - Control : txtTareasDocsSecuencia - Variable : TareasDocsSecuencia
    Dim TareasDocsCodigo As String ' Etiqueta : Código de Documento - Control : txtTareasDocsCodigo - Variable : TareasDocsCodigo
    Dim TareasDocsNombre As String ' Etiqueta : Título del Documento - Control : txtTareasDocsNombre - Variable : TareasDocsNombre
    Dim TareasDocsDescription As String ' Etiqueta : Descripción - Control : txtTareasDocsDescription - Variable : TareasDocsDescription
    Dim TareasDocsPath As String ' Etiqueta : Archivo Físico - Control : txtTareasDocsPath - Variable : TareasDocsPath
    Dim TareasPlantillaCodigo As String ' Etiqueta : Formulario - Control : txtTareasPlantillaCodigo - Variable : TareasPlantillaCodigo
    Dim AreasName As String ' Etiqueta : Área - Control : txtAreasName - Variable : AreasName
    Dim EmpresasCodigo As String ' Etiqueta : Empresa - Control : txtEmpresasCodigo - Variable : EmpresasCodigo
    Dim ContratoCodigo As String ' Etiqueta : Contrato - Control : txtContratoCodigo - Variable : ContratoCodigo
    Dim TareasDocsFEmision As Date ' Etiqueta : Fecha del Documento - Control : txtTareasDocsFEmision - Variable : TareasDocsFEmision
    Dim UsuariosCodigo As String ' Etiqueta : Responsable Actividad - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim TareasDocsObservaciones As String ' Etiqueta : Observaciones - Control : txtTareasDocsObservaciones - Variable : TareasDocsObservaciones
    Dim TareasDocsResponsableArea As String ' Etiqueta : Responsable Area - Control : txtTareasDocsResponsableArea - Variable : TareasDocsResponsableArea
    Dim TareasDocsCargoResponsable As String ' Etiqueta : Cargos del Responsable - Control : txtTareasDocsCargoResponsable - Variable : TareasDocsCargoResponsable
    Dim TipoDocName As String
    '-----------------------------------------------------------------------------------------
    ' Declaración de Campos de la Tabla DocumentosSGI                                        |
    '-----------------------------------------------------------------------------------------
    Dim DocumentosSGIId As Long
    Dim DocumentosSGICodigo As String ' ----> TareasDocsCodigo
    Dim DocumentosSGINombre As String ' ----> TareasDocsNombre
    Dim DocumentosSGIDescription As String '> TareasDocsDescription
    Dim DocumentosSGIPath As String ' ------> TareasDocsPath
    Dim DocumentosSGIOrigen As String ' ----> "-"
    Dim DocumentosSGITipo As String ' ------> TipoDocName
    Dim DocumentosSGIFEmision As Date ' ----> TareasDocsFEmision
    Dim DocumentosSGIFRevision As String ' -> Se va a poner el año y mes obtenido desde la tabla de Tareas
    Dim DocumentosSGIArea As String ' ------> AreasName
    Dim DocumentosSGIResponsable As String '> Se va a poner una lista de las API del proyecto asociado al PGG del que depende la tarea
    Dim DocumentosSGIEmpresa As String ' ---> Se va a poner el nombre de la empresa a la que corresponde el contrato indicado en la variable ContratoCodigo
    Dim DocumentosSGIContrato As String ' --> Se va a poner el nombre del contrato asociado con el valor del campo ContratoCodigo
    Dim DocumentosSGIPalabrasClaves As String
    '------------------------------------------------------------------------------------------
    ' Declaración de Campos de la Tabla para vincular el documento con el requisito de la norma
    '------------------------------------------------------------------------------------------
    'Dim DocumentosSGICodigo As String ' Etiqueta : Código - Control : txtDocumentosSGICodigo - Variable : DocumentosSGICodigo
    Dim APIDocumentosSGIId As Long
    Dim APIDocumentosSGISecuencia As Long ' > Lo debe calcular el sistema al introducir el registro
    Dim APIDocumentosSGICodigo As String ' -> DocumentosSGICodigo
    Dim MenuOptionsId As Long ' ------------> Se obtiene desde la tabla RequisitosPorAccion accediendo por el valor de AccionesCodigo que se obtiene desde la tabla de tareas
    Dim APIDocumentosSGIAmbito As String ' -> Es el atributo Texto de la Tabla MenuOptions, leida usando la variable MenuOptionsId
    Dim GruposName As String ' -------------> "Registro", queda en ese valor fijo
    Dim GruposSecuencia As Long ' ----------> Se resuelva al invocar el update del registro, es el número de secuencia del tipo de documento "Registro"


    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim s As Integer
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("MasterId")
        Dim AccionesABM As New AccionesABM
        Dim TareasDocs As New TareasDocs
        Dim DocumentosSGI As New DocumentosSGI
        Dim Carpetas As New Carpetas
        Dim ArchivoDestino As String = Server.MapPath("~/SGI/") & txtTareasDocsPath.Text

        Try
            s = TareasDocs.TareasDocsDelete(Session("Id"), Request.QueryString("MasterName"), CLng(Session("PersonaId")))
            If s = 1 Then 'Hay que eliminar el registro desde DocumentosSGI
                DocumentosSGICodigo = txtTareasDocsCodigo.Text
                t = Lecturas.LeerMasterIdByMasterName("DocumentosSGIId", "DocumentosSGICodigo", "DocumentosSGI", DocumentosSGICodigo, DocumentosSGIId)
                If DocumentosSGIId <> 0 Then 'Se encontro y se debe eliminar
                    t = DocumentosSGI.DocumentosSGIDelete(DocumentosSGIId, DocumentosSGICodigo, Session("PersonaId"))
                    t = Carpetas.DocumentosSGIPorCarpetaDelete(DocumentosSGIId, DocumentosSGICodigo, Session("PersonaId"))
                    ' Agregar que se elimine tambien de CarpetaJudicialDocs.
                    If File.Exists(ArchivoDestino) Then
                        File.Delete(ArchivoDestino)
                    End If
                End If
            End If
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
    Protected Sub RFC_Save(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Dim ArchivoDestino As String = ""

        If txtUploadFile.HasFile Then
            ArchivoDestino = Server.MapPath("~/SGI/") & txtUploadFile.FileName
            txtTareasDocsPath.Text = txtUploadFile.FileName
            If File.Exists(ArchivoDestino) Then
                File.Delete(ArchivoDestino)
            End If
            txtUploadFile.PostedFile.SaveAs(ArchivoDestino)
            UploadLink.NavigateUrl = "~/SGI/" & txtTareasDocsPath.Text
            UploadLink.Target = "_blank"
        End If
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
        Dim TareasDocs As New TareasDocs
        Dim Contrato As New Contrato
        Dim Empresas As New Empresas
        Dim DocumentosSGI As New DocumentosSGI
        Dim APIDocumentosSGI As New APIDocumentosSGI
        Dim Tareas As New Tareas

        ' Asignación de valores a campos dependientes de otros
        txtEmpresasCodigo.Text = txtContratoCodigo.Text
        txtTareasDocsCodigo.Text = txtTareasCodigo.Text & " - " & Session("Id")
        'txtTareasDocsNombre.Text = "Registro de " & DocumentosSGI.LeerDocumentosSGIDescriptionByName(txtTareasPlantillaCodigo.Text)
        'txtTareasDocsDescription.Text = txtTareasDocsNombre.Text & ", " & Tareas.LeerTareasMesAnoUsuarioByName(txtTareasCodigo.Text) & ", # de Tarea: " & txtTareasCodigo.Text
        Try
            If TareasDocs.TareasDocsUpdate(Session("Id"), CStr(txtTareasCodigo.Text), CLng(txtTareasDocsSecuencia.Text), CStr(txtTareasDocsCodigo.Text), CStr(txtTareasDocsNombre.Text), CStr(txtTareasDocsDescription.Text), CStr(txtTareasDocsPath.Text), CStr(txtTareasPlantillaCodigo.Text), CStr(txtAreasName.Text), CStr(txtEmpresasCodigo.Text), CStr(txtContratoCodigo.Text), CDate(txtTareasDocsFEmision.Text), CStr(txtUsuariosCodigo.Text), CStr(txtTareasDocsObservaciones.Text), CStr(txtTareasDocsResponsableArea.Text), CStr(txtTareasDocsCargoResponsable.Text), CStr(txtTipoDocName.Text), Session("PersonaId")) Then
                'Implica que se creo el registro o se modifico y por ende hay que intentar grabar el documento en la base de datos documental
                ' Pasos para grabar el documento en la base de datos documental
                ' El código del documento se asigna en forma automatica y esta en TareasDocsCodigo
                ' Primero verificamos si existe, y se crea en caso de que no exista.
                DocumentosSGICodigo = txtTareasDocsCodigo.Text
                t = Lecturas.LeerMasterIdByMasterName("DocumentosSGIId", "DocumentosSGICodigo", "DocumentosSGI", DocumentosSGICodigo, DocumentosSGIId)
                DocumentosSGINombre = CStr(txtTareasDocsNombre.Text)
                DocumentosSGIDescription = CStr(txtTareasDocsDescription.Text)
                DocumentosSGIPath = CStr(txtTareasDocsPath.Text)
                DocumentosSGIOrigen = "-"
                DocumentosSGITipo = CStr(txtTipoDocName.Text)
                DocumentosSGIFEmision = CDate(txtTareasDocsFEmision.Text)
                DocumentosSGIFRevision = CDate(txtTareasDocsFEmision.Text)
                DocumentosSGIArea = CStr(txtAreasName.Text)
                DocumentosSGIResponsable = CStr(txtTareasDocsResponsableArea.Text)
                DocumentosSGIEmpresa = CStr(txtContratoCodigo.Text)
                DocumentosSGIContrato = CStr(txtTareasDocsCargoResponsable.Text)
                DocumentosSGIPalabrasClaves = CStr(txtTareasDocsObservaciones.Text)
                If DocumentosSGIId = 0 Then ' Debemos crear el registro en la tabla Documentos SGI y a continuación lo actualizamos.
                    t = AccionesABM.MasterPartialInsert("DocumentosSGIId", "DocumentosSGICodigo", "DocumentosSGI", DocumentosSGICodigo, CLng(Session("PersonaId")), DocumentosSGIId)
                End If
                t = DocumentosSGI.DocumentosSGIUpdate(DocumentosSGIId, DocumentosSGICodigo, DocumentosSGINombre, DocumentosSGIDescription, DocumentosSGIPath, DocumentosSGIOrigen, DocumentosSGITipo, CDate(DocumentosSGIFEmision), DocumentosSGIFRevision, DocumentosSGIArea, DocumentosSGIResponsable, DocumentosSGIEmpresa, DocumentosSGIContrato, DocumentosSGIPalabrasClaves, Session("PersonaId"))
                ' Aquí debemos asegurarnos de grabar tambien un registro en CarpetaJudicialDocs.



            End If
        Catch
            t = 0
        End Try
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim TareasDocs As New TareasDocs
        Dim DocumentosSGI As New DocumentosSGI
        Dim TareasProgramadas As New TareasProgramadas
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim TipoDoc As New TipoDoc
        Dim Tareas As New Tareas
        Dim Areas As New Areas
        Dim Empresas As New Empresas
        Dim Contrato As New Contrato
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
        Call Lecturas.NuevaCrearFormularioV2(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton, SaveButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler DeleteButton.Click, AddressOf RFC_Delete
        AddHandler ReturnButton.Click, AddressOf RFC_Return
        AddHandler SaveButton.Click, AddressOf RFC_Save
        Try
            If Not IsPostBack Then
                MasterName = Request.QueryString("MasterName")
                Session("MasterId") = Request.QueryString("MasterId")
                DetailId = Request.QueryString("Id")
                If DetailId = 0 Then
                    DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("TareasCodigo", "TareasDocsSecuencia", "TareasDocs", MasterName)
                    t = AccionesABM.ObjectPartialInsert("TareasDocsId", "TareasCodigo", "TareasDocsSecuencia", "TareasDocs", MasterName, DetailSecuencia, CLng(Session("PersonaId")), DetailId)
                End If
                Session("Id") = DetailId
                If t = TareasDocs.LeerTareasDocs(Session("Id"), TareasCodigo, TareasDocsSecuencia, TareasDocsCodigo, TareasDocsNombre, TareasDocsDescription, TareasDocsPath, TareasPlantillaCodigo, AreasName, EmpresasCodigo, ContratoCodigo, TareasDocsFEmision, UsuariosCodigo, TareasDocsObservaciones, TareasDocsResponsableArea, TareasDocsCargoResponsable, TipoDocName) Then
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = TareasCodigo
                    txtTareasCodigo.ToolTip = Tareas.LeerTareasDescriptionByName(TareasCodigo)
                    txtTareasDocsSecuencia = FindControl("txtTareasDocsSecuencia")
                    txtTareasDocsSecuencia.Text = TareasDocsSecuencia
                    txtTareasDocsCodigo = FindControl("txtTareasDocsCodigo")
                    txtTareasDocsCodigo.Text = TareasDocsCodigo
                    txtTareasDocsNombre = FindControl("txtTareasDocsNombre")
                    txtTareasDocsNombre.Text = TareasDocsNombre
                    txtTareasDocsDescription = FindControl("txtTareasDocsDescription")
                    txtTareasDocsDescription.Text = TareasDocsDescription
                    txtTareasDocsPath = FindControl("txtTareasDocsPath")
                    txtTareasDocsPath.Text = TareasDocsPath
                    ' Se agregan manualmente para manejar el evento RFC_Save
                    txtUploadFile = FindControl("txtUploadFile")
                    UploadLink = FindControl("lnkFile")
                    UploadLink.NavigateUrl = "~/SGI/" & txtTareasDocsPath.Text
                    UploadLink.Target = "_blank"
                    ' -------------------------------------------------------------------
                    txtTareasPlantillaCodigo = FindControl("txtTareasPlantillaCodigo")
                    'Usaremos el campo txtTareasPlantillaCodigo para mostrar la desctipción de la acción
                    txtTareasPlantillaCodigo.Text = Tareas.LeerAccionesNameByTareasCodigo(TareasCodigo)
                    'txtTareasPlantillaCodigoDescription = FindControl("txtTareasPlantillaCodigoDescription")
                    'txtTareasPlantillaCodigoDescription.Text = ""
                    'Se elimina en esta versión el concepto de plantilla
                    '---------------------------------------------------
                    txtAreasName = FindControl("txtAreasName")
                    txtAreasName.Text = "Estudio"  'Se fija el valor del área, siempre en una evidencia, quien la registra es el estudio juridico
                    'txtAreasNameDescription = FindControl("txtAreasNameDescription")
                    'txtAreasNameDescription.Text = Areas.LeerAreasDescriptionByName(AreasName)
                    txtEmpresasCodigo = FindControl("txtEmpresasCodigo")
                    txtEmpresasCodigo.Text = EmpresasCodigo


                    'El campo txtContratoCodigo, será reemplazado por el código del stakeholder

                    txtContratoCodigo = FindControl("txtContratoCodigo")
                    If Len(ContratoCodigo) = 0 Then ContratoCodigo = CarpetaJudicial.LeerApellidosDeudorByTareasId(Session("MasterId"))
                    txtContratoCodigo.Text = ContratoCodigo
                    'txtContratoCodigoDescription = FindControl("txtContratoCodigoDescription")
                    'txtContratoCodigoDescription.Text = ""
                    txtTareasDocsFEmision = FindControl("txtTareasDocsFEmision")
                    txtTareasDocsFEmision.Text = TareasDocsFEmision
                    txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
                    If Len(UsuariosCodigo) = 0 Then UsuariosCodigo = Tareas.LeerTareasUsuariosCodigoByName(TareasCodigo)
                    txtUsuariosCodigo.Text = UsuariosCodigo
                    'txtUsuariosCodigoDescription = FindControl("txtUsuariosCodigoDescription")
                    'txtUsuariosCodigoDescription.Text = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)
                    txtTareasDocsObservaciones = FindControl("txtTareasDocsObservaciones")
                    txtTareasDocsObservaciones.Text = CarpetaJudicial.LeerDeudorByTareasId(Session("MasterId"))
                    txtTareasDocsResponsableArea = FindControl("txtTareasDocsResponsableArea")
                    txtTareasDocsResponsableArea.Text = TareasDocsResponsableArea
                    txtTareasDocsCargoResponsable = FindControl("txtTareasDocsCargoResponsable")
                    txtTareasDocsCargoResponsable.Text = TareasDocsCargoResponsable
                    txtTipoDocName = FindControl("txtTipoDocName")
                    txtTipoDocName.Text = TipoDocName
                    txtTipoDocNameDescription = FindControl("txtTipoDocNameDescription")
                    txtTipoDocNameDescription.Text = TipoDoc.LeerTipoDocDescriptionByName(TipoDocName)

                    txtTareasDocsCodigo.Text = txtTareasCodigo.Text & " - " & Session("Id")
                    t = DocumentosSGI.LeerDocumentosSGIByName(DocumentosSGIId, txtTareasDocsCodigo.Text)
                    If t = True Then
                        Session("DocumentosSGIId") = DocumentosSGIId
                        Session("CarpetaRaiz") = "Carpeta General"
                        'ctlControl = LoadControl("Vinculos.ascx")
                        'PlaceHolder1.Controls.Add(ctlControl)
                    End If

                Else
                    txtTareasCodigo = FindControl("txtTareasCodigo")
                    txtTareasCodigo.Text = Session("TareasCodigo")
                    txtTareasDocsSecuencia = FindControl("txtTareasDocsSecuencia")
                    txtTareasDocsSecuencia.Text = Session("TareasDocsSecuencia")
                End If
            Else
                txtTareasCodigo = FindControl("txtTareasCodigo")
                txtTareasDocsSecuencia = FindControl("txtTareasDocsSecuencia")
                txtTareasDocsCodigo = FindControl("txtTareasDocsCodigo")
                txtTareasDocsNombre = FindControl("txtTareasDocsNombre")
                txtTareasDocsDescription = FindControl("txtTareasDocsDescription")
                txtTareasDocsPath = FindControl("txtTareasDocsPath")
                ' Se agregan manualmente para manejar el evento RFC_Save
                txtUploadFile = FindControl("txtUploadFile")
                UploadLink = FindControl("lnkFile")
                ' ---------------
                txtTareasPlantillaCodigo = FindControl("txtTareasPlantillaCodigo")
                txtAreasName = FindControl("txtAreasName")
                txtEmpresasCodigo = FindControl("txtEmpresasCodigo")
                txtContratoCodigo = FindControl("txtContratoCodigo")
                txtTareasDocsFEmision = FindControl("txtTareasDocsFEmision")
                txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
                txtTareasDocsObservaciones = FindControl("txtTareasDocsObservaciones")
                txtTareasDocsResponsableArea = FindControl("txtTareasDocsResponsableArea")
                txtTareasDocsCargoResponsable = FindControl("txtTareasDocsCargoResponsable")
                txtTipoDocName = FindControl("txtTipoDocName")
            End If
        Catch
            t = False
        End Try
    End Sub
End Class
