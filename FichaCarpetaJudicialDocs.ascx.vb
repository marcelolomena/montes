Imports AjaxControlToolkit
Imports System.IO
Partial Class FichaCarpetaJudicialDocs
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
    Dim txtCarpetaJudicialDocsSecuencia As TextBox ' Etiqueta : Secuencia - Control : txtCarpetaJudicialDocsSecuencia - Variable : CarpetaJudicialDocsSecuencia
    Dim txtCarpetaJudicialDocsCodigo As TextBox ' Etiqueta : Código de Documento - Control : txtCarpetaJudicialDocsCodigo - Variable : CarpetaJudicialDocsCodigo
    Dim txtCarpetaJudicialDocsNombre As TextBox ' Etiqueta : Título del Documento - Control : txtCarpetaJudicialDocsNombre - Variable : CarpetaJudicialDocsNombre
    Dim txtCarpetaJudicialDocsDescription As TextBox ' Etiqueta : Descripción - Control : txtCarpetaJudicialDocsDescription - Variable : CarpetaJudicialDocsDescription
    Dim txtCarpetaJudicialDocsPath As TextBox ' Etiqueta : Archivo Físico - Control : txtCarpetaJudicialDocsPath - Variable : CarpetaJudicialDocsPath
    Dim txtCarpetaJudicialPlantillaCodigo As TextBox ' Etiqueta : Formulario - Control : txtCarpetaJudicialPlantillaCodigo - Variable : CarpetaJudicialPlantillaCodigo
    Dim txtCarpetaJudicialPlantillaCodigoDescription As TextBox ' Etiqueta : Formulario - Control : txtCarpetaJudicialPlantillaCodigo - Variable : CarpetaJudicialPlantillaCodigo
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
    Dim txtCarpetaJudicialDocsFEmision As TextBox ' Etiqueta : Fecha del Documento - Control : txtCarpetaJudicialDocsFEmision - Variable : CarpetaJudicialDocsFEmision
    Dim txtUsuariosCodigo As TextBox ' Etiqueta : Responsable Actividad - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim txtUsuariosCodigoDescription As TextBox ' Etiqueta : Responsable Actividad - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim txtCarpetaJudicialDocsObservaciones As TextBox ' Etiqueta : Observaciones - Control : txtCarpetaJudicialDocsObservaciones - Variable : CarpetaJudicialDocsObservaciones
    Dim txtCarpetaJudicialDocsResponsableArea As TextBox ' Etiqueta : Responsable Area - Control : txtCarpetaJudicialDocsResponsableArea - Variable : CarpetaJudicialDocsResponsableArea
    Dim txtCarpetaJudicialDocsCargoResponsable As TextBox ' Etiqueta : Cargos del Responsable - Control : txtCarpetaJudicialDocsCargoResponsable - Variable : CarpetaJudicialDocsCargoResponsable
    Dim chkCarpetaJudicialDocsIsAdjunto As CheckBox
    Dim chkCarpetaJudicialDocsIsAvailable As CheckBox
    Dim txtCarpetaJudicialDocsCorreoResponsable As TextBox
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim CarpetaJudicialCodigo As String ' Etiqueta : Código Tarea - Control : txtCarpetaJudicialCodigo - Variable : CarpetaJudicialCodigo
    Dim CarpetaJudicialDocsSecuencia As Long ' Etiqueta : Secuencia - Control : txtCarpetaJudicialDocsSecuencia - Variable : CarpetaJudicialDocsSecuencia
    Dim CarpetaJudicialDocsCodigo As String ' Etiqueta : Código de Documento - Control : txtCarpetaJudicialDocsCodigo - Variable : CarpetaJudicialDocsCodigo
    Dim CarpetaJudicialDocsNombre As String ' Etiqueta : Título del Documento - Control : txtCarpetaJudicialDocsNombre - Variable : CarpetaJudicialDocsNombre
    Dim CarpetaJudicialDocsDescription As String ' Etiqueta : Descripción - Control : txtCarpetaJudicialDocsDescription - Variable : CarpetaJudicialDocsDescription
    Dim CarpetaJudicialDocsPath As String ' Etiqueta : Archivo Físico - Control : txtCarpetaJudicialDocsPath - Variable : CarpetaJudicialDocsPath
    Dim CarpetaJudicialPlantillaCodigo As String ' Etiqueta : Formulario - Control : txtCarpetaJudicialPlantillaCodigo - Variable : CarpetaJudicialPlantillaCodigo
    Dim AreasName As String ' Etiqueta : Área - Control : txtAreasName - Variable : AreasName
    Dim EmpresasCodigo As String ' Etiqueta : Empresa - Control : txtEmpresasCodigo - Variable : EmpresasCodigo
    Dim ContratoCodigo As String ' Etiqueta : Contrato - Control : txtContratoCodigo - Variable : ContratoCodigo
    Dim CarpetaJudicialDocsFEmision As Date ' Etiqueta : Fecha del Documento - Control : txtCarpetaJudicialDocsFEmision - Variable : CarpetaJudicialDocsFEmision
    Dim UsuariosCodigo As String ' Etiqueta : Responsable Actividad - Control : txtUsuariosCodigo - Variable : UsuariosCodigo
    Dim CarpetaJudicialDocsObservaciones As String ' Etiqueta : Observaciones - Control : txtCarpetaJudicialDocsObservaciones - Variable : CarpetaJudicialDocsObservaciones
    Dim CarpetaJudicialDocsResponsableArea As String ' Etiqueta : Responsable Area - Control : txtCarpetaJudicialDocsResponsableArea - Variable : CarpetaJudicialDocsResponsableArea
    Dim CarpetaJudicialDocsCargoResponsable As String ' Etiqueta : Cargos del Responsable - Control : txtCarpetaJudicialDocsCargoResponsable - Variable : CarpetaJudicialDocsCargoResponsable
    Dim TipoDocName As String
    Dim CarpetaJudicialDocsIsAdjunto As Boolean
    Dim CarpetaJudicialDocsIsAvailable As Boolean
    Dim CarpetaJudicialDocsCorreoResponsable As String
    '-----------------------------------------------------------------------------------------
    ' Declaración de Campos de la Tabla DocumentosSGI                                        |
    '-----------------------------------------------------------------------------------------
    Dim DocumentosSGIId As Long
    Dim DocumentosSGICodigo As String ' ----> CarpetaJudicialDocsCodigo
    Dim DocumentosSGINombre As String ' ----> CarpetaJudicialDocsNombre
    Dim DocumentosSGIDescription As String '> CarpetaJudicialDocsDescription
    Dim DocumentosSGIPath As String ' ------> CarpetaJudicialDocsPath
    Dim DocumentosSGIOrigen As String ' ----> "-"
    Dim DocumentosSGITipo As String ' ------> TipoDocName
    Dim DocumentosSGIFEmision As Date ' ----> CarpetaJudicialDocsFEmision
    Dim DocumentosSGIFRevision As String ' -> Se va a poner el año y mes obtenido desde la tabla de CarpetaJudicial
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
    Dim MenuOptionsId As Long ' ------------> Se obtiene desde la tabla RequisitosPorAccion accediendo por el valor de AccionesCodigo que se obtiene desde la tabla de CarpetaJudicial
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
        Dim CarpetaJudicialDocs As New CarpetaJudicialDocs
        Dim DocumentosSGI As New DocumentosSGI
        Dim Carpetas As New Carpetas
        Dim ArchivoDestino As String = Server.MapPath("~/SGI/") & txtCarpetaJudicialDocsPath.Text

        Try
            s = CarpetaJudicialDocs.CarpetaJudicialDocsDelete(Session("Id"), Request.QueryString("MasterName"), CLng(Session("PersonaId")))
            If s = 1 Then 'Hay que eliminar el registro desde DocumentosSGI
                DocumentosSGICodigo = txtCarpetaJudicialDocsCodigo.Text
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
    Protected Sub RFC_Save(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveButton.Click
        Dim ArchivoDestino As String = ""

        If txtUploadFile.HasFile Then
            ArchivoDestino = Server.MapPath("~/SGI/") & txtUploadFile.FileName
            txtCarpetaJudicialDocsPath.Text = txtUploadFile.FileName
            If File.Exists(ArchivoDestino) Then
                File.Delete(ArchivoDestino)
            End If
            txtUploadFile.PostedFile.SaveAs(ArchivoDestino)
            UploadLink.NavigateUrl = "~/SGI/" & txtCarpetaJudicialDocsPath.Text
            UploadLink.Target = "_blank"
        End If
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

        If NombrePagina = "Ficha de TareasDocs" Then
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
        Dim CarpetaJudicialDocs As New CarpetaJudicialDocs
        Dim Contrato As New Contrato
        Dim Empresas As New Empresas
        Dim DocumentosSGI As New DocumentosSGI
        Dim APIDocumentosSGI As New APIDocumentosSGI

        If NombrePagina = "Ficha de TareasDocs" Then
            'MasterName cambia al código de la caprpeta judicial
            'MasterId se mantiene en el Id de la Tarea.
            CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
            Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Session("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&MasterName=" & CarpetaJudicialCodigo & "&MasterId=" & Request.QueryString("MasterId")
        End If

        ' Asignación de valores a campos dependientes de otros
        txtEmpresasCodigo.Text = txtContratoCodigo.Text
        txtCarpetaJudicialDocsCodigo.Text = txtCarpetaJudicialCodigo.Text & " - " & Session("Id")
        txtAreasName.Text = "Estudio" 'Corresponde al área
        'txtCarpetaJudicialDocsNombre.Text = "Registro de " & DocumentosSGI.LeerDocumentosSGIDescriptionByName(txtCarpetaJudicialPlantillaCodigo.Text)
        'txtCarpetaJudicialDocsDescription.Text = txtCarpetaJudicialDocsNombre.Text & ", " & CarpetaJudicial.LeerCarpetaJudicialMesAnoUsuarioByName(txtCarpetaJudicialCodigo.Text) & ", # de Tarea: " & txtCarpetaJudicialCodigo.Text
        Try
            If CarpetaJudicialDocs.CarpetaJudicialDocsUpdate(Session("Id"), CStr(txtCarpetaJudicialCodigo.Text), CLng(txtCarpetaJudicialDocsSecuencia.Text), CStr(txtCarpetaJudicialDocsCodigo.Text), CStr(txtCarpetaJudicialDocsNombre.Text), CStr(txtCarpetaJudicialDocsDescription.Text), CStr(txtCarpetaJudicialDocsPath.Text), CStr(txtCarpetaJudicialPlantillaCodigo.Text), CStr(txtAreasName.Text), CStr(txtEmpresasCodigo.Text), CStr(txtContratoCodigo.Text), CDate(txtCarpetaJudicialDocsFEmision.Text), CStr(txtUsuariosCodigo.Text), CStr(txtCarpetaJudicialDocsObservaciones.Text), CStr(txtCarpetaJudicialDocsResponsableArea.Text), CStr(txtCarpetaJudicialDocsCargoResponsable.Text), CStr(txtTipoDocName.Text), CBool(chkCarpetaJudicialDocsIsAdjunto.Checked), CBool(chkCarpetaJudicialDocsIsAvailable.Checked), CStr(txtCarpetaJudicialDocsCorreoResponsable.Text), Session("PersonaId")) Then
                'Implica que se creo el registro o se modifico y por ende hay que intentar grabar el documento en la base de datos documental
                ' Pasos para grabar el documento en la base de datos documental
                ' El código del documento se asigna en forma automatica y esta en CarpetaJudicialDocsCodigo
                ' Primero verificamos si existe, y se crea en caso de que no exista.
                DocumentosSGICodigo = txtCarpetaJudicialDocsCodigo.Text
                t = Lecturas.LeerMasterIdByMasterName("DocumentosSGIId", "DocumentosSGICodigo", "DocumentosSGI", DocumentosSGICodigo, DocumentosSGIId)
                DocumentosSGINombre = CStr(txtCarpetaJudicialDocsNombre.Text)
                DocumentosSGIDescription = CStr(txtCarpetaJudicialDocsDescription.Text)
                DocumentosSGIPath = CStr(txtCarpetaJudicialDocsPath.Text)
                DocumentosSGIOrigen = "-"
                DocumentosSGITipo = CStr(txtTipoDocName.Text)
                DocumentosSGIFEmision = CDate(txtCarpetaJudicialDocsFEmision.Text)
                DocumentosSGIFRevision = CDate(txtCarpetaJudicialDocsFEmision.Text)
                DocumentosSGIArea = CStr(txtAreasName.Text)
                DocumentosSGIResponsable = CStr(txtCarpetaJudicialDocsResponsableArea.Text)
                DocumentosSGIEmpresa = CStr(txtContratoCodigo.Text)
                DocumentosSGIContrato = CStr(txtCarpetaJudicialDocsCargoResponsable.Text)
                DocumentosSGIPalabrasClaves = CStr(txtCarpetaJudicialDocsObservaciones.Text)
                If DocumentosSGIId = 0 Then ' Debemos crear el registro en la tabla Documentos SGI y a continuación lo actualizamos.
                    t = AccionesABM.MasterPartialInsert("DocumentosSGIId", "DocumentosSGICodigo", "DocumentosSGI", DocumentosSGICodigo, CLng(Session("PersonaId")), DocumentosSGIId)
                End If
                t = DocumentosSGI.DocumentosSGIUpdate(DocumentosSGIId, DocumentosSGICodigo, DocumentosSGINombre, DocumentosSGIDescription, DocumentosSGIPath, DocumentosSGIOrigen, DocumentosSGITipo, CDate(DocumentosSGIFEmision), DocumentosSGIFRevision, DocumentosSGIArea, DocumentosSGIResponsable, DocumentosSGIEmpresa, DocumentosSGIContrato, DocumentosSGIPalabrasClaves, Session("PersonaId"))
                ' Aquí debemos asegurarnos de grabar tambien un registro en CarpetaJudicialDocs.



            End If
        Catch
            t = 0
        End Try
        Response.Redirect(Url, True)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim CarpetaJudicialDocs As New CarpetaJudicialDocs
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

        If Request.QueryString("PaginaWebName") = "Ficha de TareasDocs" Then
            CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
            MyDeudor.Controls.Add(New LiteralControl(Tareas.ListarDatosDelDeudorPorTareasId(CLng(Request.QueryString("MasterId")), CarpetaJudicialCodigo)))
        End If

        Call Lecturas.NuevaCrearFormularioV2(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton, SaveButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler DeleteButton.Click, AddressOf RFC_Delete
        AddHandler ReturnButton.Click, AddressOf RFC_Return
        AddHandler SaveButton.Click, AddressOf RFC_Save
        Try
            If Not IsPostBack Then
                MasterName = Request.QueryString("MasterName")
                If Request.QueryString("PaginaWebName") = "Ficha de TareasDocs" Then
                    MasterName = CarpetaJudicial.LeerCarpetaJudicialCodigoById(Tareas.LeerCarpetaJudicialIdbyTareasId(CLng(Request.QueryString("MasterId"))))
                End If
                Session("MasterId") = Request.QueryString("MasterId")
                DetailId = Request.QueryString("Id")
                If DetailId = 0 Then
                    DetailSecuencia = Lecturas.CalcularNextSecuenciaObject("CarpetaJudicialCodigo", "CarpetaJudicialDocsSecuencia", "CarpetaJudicialDocs", MasterName)
                    t = AccionesABM.ObjectPartialInsert("CarpetaJudicialDocsId", "CarpetaJudicialCodigo", "CarpetaJudicialDocsSecuencia", "CarpetaJudicialDocs", MasterName, DetailSecuencia, CLng(Session("PersonaId")), DetailId)
                End If
                Session("Id") = DetailId
                If t = CarpetaJudicialDocs.LeerCarpetaJudicialDocs(Session("Id"), CarpetaJudicialCodigo, CarpetaJudicialDocsSecuencia, CarpetaJudicialDocsCodigo, CarpetaJudicialDocsNombre, CarpetaJudicialDocsDescription, CarpetaJudicialDocsPath, CarpetaJudicialPlantillaCodigo, AreasName, EmpresasCodigo, ContratoCodigo, CarpetaJudicialDocsFEmision, UsuariosCodigo, CarpetaJudicialDocsObservaciones, CarpetaJudicialDocsResponsableArea, CarpetaJudicialDocsCargoResponsable, TipoDocName, CarpetaJudicialDocsIsAdjunto, CarpetaJudicialDocsIsAvailable, CarpetaJudicialDocsCorreoResponsable) Then
                    txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                    txtCarpetaJudicialCodigo.Text = CarpetaJudicialCodigo
                    'txtCarpetaJudicialCodigo.ToolTip = CarpetaJudicial.LeerCarpetaJudicialDescriptionByName(CarpetaJudicialCodigo)
                    txtCarpetaJudicialDocsSecuencia = FindControl("txtCarpetaJudicialDocsSecuencia")
                    txtCarpetaJudicialDocsSecuencia.Text = CarpetaJudicialDocsSecuencia
                    txtCarpetaJudicialDocsCodigo = FindControl("txtCarpetaJudicialDocsCodigo")
                    txtCarpetaJudicialDocsCodigo.Text = CarpetaJudicialDocsCodigo
                    txtCarpetaJudicialDocsNombre = FindControl("txtCarpetaJudicialDocsNombre")
                    txtCarpetaJudicialDocsNombre.Text = CarpetaJudicialDocsNombre
                    txtCarpetaJudicialDocsDescription = FindControl("txtCarpetaJudicialDocsDescription")
                    txtCarpetaJudicialDocsDescription.Text = CarpetaJudicialDocsDescription
                    txtCarpetaJudicialDocsPath = FindControl("txtCarpetaJudicialDocsPath")
                    txtCarpetaJudicialDocsPath.Text = CarpetaJudicialDocsPath
                    ' Se agregan manualmente para manejar el evento RFC_Save
                    txtUploadFile = FindControl("txtUploadFile")
                    UploadLink = FindControl("lnkFile")
                    UploadLink.NavigateUrl = "~/SGI/" & txtCarpetaJudicialDocsPath.Text
                    UploadLink.Target = "_blank"
                    ' -------------------------------------------------------------------
                    txtCarpetaJudicialPlantillaCodigo = FindControl("txtCarpetaJudicialPlantillaCodigo")
                    'Usaremos el campo txtCarpetaJudicialPlantillaCodigo para mostrar la desctipción de la acción
                    txtCarpetaJudicialPlantillaCodigo.Text = Tareas.LeerAccionesNameByTareasId(CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo))
                    'txtCarpetaJudicialPlantillaCodigoDescription = FindControl("txtCarpetaJudicialPlantillaCodigoDescription")
                    'txtCarpetaJudicialPlantillaCodigoDescription.Text = ""
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
                    If Len(ContratoCodigo) = 0 Then ContratoCodigo = CarpetaJudicial.LeerApellidosDeudorByTareasId(CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo))
                    txtContratoCodigo.Text = ContratoCodigo
                    'txtContratoCodigoDescription = FindControl("txtContratoCodigoDescription")
                    'txtContratoCodigoDescription.Text = ""
                    txtCarpetaJudicialDocsFEmision = FindControl("txtCarpetaJudicialDocsFEmision")
                    txtCarpetaJudicialDocsFEmision.Text = CarpetaJudicialDocsFEmision
                    txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
                    If Len(UsuariosCodigo) = 0 Then UsuariosCodigo = Tareas.LeerTareasUsuariosCodigoByTareasId(CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo))
                    txtUsuariosCodigo.Text = UsuariosCodigo
                    'txtUsuariosCodigoDescription = FindControl("txtUsuariosCodigoDescription")
                    'txtUsuariosCodigoDescription.Text = Usuarios.LeerUsuariosDescriptionByName(UsuariosCodigo)
                    txtCarpetaJudicialDocsObservaciones = FindControl("txtCarpetaJudicialDocsObservaciones")
                    txtCarpetaJudicialDocsObservaciones.Text = CarpetaJudicial.LeerDeudorByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
                    txtCarpetaJudicialDocsResponsableArea = FindControl("txtCarpetaJudicialDocsResponsableArea")
                    txtCarpetaJudicialDocsResponsableArea.Text = CarpetaJudicialDocsResponsableArea
                    txtCarpetaJudicialDocsCargoResponsable = FindControl("txtCarpetaJudicialDocsCargoResponsable")
                    txtCarpetaJudicialDocsCargoResponsable.Text = CarpetaJudicialDocsCargoResponsable
                    txtTipoDocName = FindControl("txtTipoDocName")
                    txtTipoDocName.Text = TipoDocName
                    txtTipoDocNameDescription = FindControl("txtTipoDocNameDescription")
                    txtTipoDocNameDescription.Text = TipoDoc.LeerTipoDocDescriptionByName(TipoDocName)

                    txtCarpetaJudicialDocsCodigo.Text = txtCarpetaJudicialCodigo.Text & " - " & Session("Id")
                    t = DocumentosSGI.LeerDocumentosSGIByName(DocumentosSGIId, txtCarpetaJudicialDocsCodigo.Text)
                    If t = True Then
                        Session("DocumentosSGIId") = DocumentosSGIId
                        Session("CarpetaRaiz") = "Carpeta General"
                        'ctlControl = LoadControl("Vinculos.ascx")
                        'PlaceHolder1.Controls.Add(ctlControl)
                    End If
                    chkCarpetaJudicialDocsIsAdjunto = FindControl("chkCarpetaJudicialDocsIsAdjunto")
                    chkCarpetaJudicialDocsIsAdjunto.Checked = CBool(CarpetaJudicialDocsIsAdjunto)
                    chkCarpetaJudicialDocsIsAvailable = FindControl("chkCarpetaJudicialDocsIsAvailable")
                    chkCarpetaJudicialDocsIsAvailable.Checked = CBool(CarpetaJudicialDocsIsAvailable)
                    txtCarpetaJudicialDocsCorreoResponsable = FindControl("txtCarpetaJudicialDocsCorreoResponsable")
                    txtCarpetaJudicialDocsCorreoResponsable.Text = CarpetaJudicialDocsCorreoResponsable
                Else
                    txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                    txtCarpetaJudicialCodigo.Text = Session("CarpetaJudicialCodigo")
                    txtCarpetaJudicialDocsSecuencia = FindControl("txtCarpetaJudicialDocsSecuencia")
                    txtCarpetaJudicialDocsSecuencia.Text = Session("CarpetaJudicialDocsSecuencia")
                End If
            Else
                txtCarpetaJudicialCodigo = FindControl("txtCarpetaJudicialCodigo")
                txtCarpetaJudicialDocsSecuencia = FindControl("txtCarpetaJudicialDocsSecuencia")
                txtCarpetaJudicialDocsCodigo = FindControl("txtCarpetaJudicialDocsCodigo")
                txtCarpetaJudicialDocsNombre = FindControl("txtCarpetaJudicialDocsNombre")
                txtCarpetaJudicialDocsDescription = FindControl("txtCarpetaJudicialDocsDescription")
                txtCarpetaJudicialDocsPath = FindControl("txtCarpetaJudicialDocsPath")
                ' Se agregan manualmente para manejar el evento RFC_Save
                txtUploadFile = FindControl("txtUploadFile")
                UploadLink = FindControl("lnkFile")
                ' ---------------
                txtCarpetaJudicialPlantillaCodigo = FindControl("txtCarpetaJudicialPlantillaCodigo")
                txtAreasName = FindControl("txtAreasName")
                txtEmpresasCodigo = FindControl("txtEmpresasCodigo")
                txtContratoCodigo = FindControl("txtContratoCodigo")
                txtCarpetaJudicialDocsFEmision = FindControl("txtCarpetaJudicialDocsFEmision")
                txtUsuariosCodigo = FindControl("txtUsuariosCodigo")
                txtCarpetaJudicialDocsObservaciones = FindControl("txtCarpetaJudicialDocsObservaciones")
                txtCarpetaJudicialDocsResponsableArea = FindControl("txtCarpetaJudicialDocsResponsableArea")
                txtCarpetaJudicialDocsCargoResponsable = FindControl("txtCarpetaJudicialDocsCargoResponsable")
                txtTipoDocName = FindControl("txtTipoDocName")
                chkCarpetaJudicialDocsIsAdjunto = FindControl("chkCarpetaJudicialDocsIsAdjunto")
                chkCarpetaJudicialDocsIsAvailable = FindControl("chkCarpetaJudicialDocsIsAvailable")
                txtCarpetaJudicialDocsCorreoResponsable = FindControl("txtCarpetaJudicialDocsCorreoResponsable")
            End If
        Catch
            t = False
        End Try
    End Sub
End Class
