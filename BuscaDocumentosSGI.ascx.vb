Imports AjaxControlToolkit
Partial Class BuscaDocumentosSGI
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 01-12-2010 19:29:14
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
    Dim txtDocumentosSGICodigo As DropDownList ' Etiqueta : Código - Control : txtDocumentosSGICodigo - Variable : DocumentosSGICodigo
    Dim txtDocumentosSGINombre As DropDownList ' Etiqueta : Nombre - Control : txtDocumentosSGINombre - Variable : DocumentosSGINombre
    Dim txtDocumentosSGITipo As DropDownList ' Etiqueta : Tipo de Documento - Control : txtDocumentosSGITipo - Variable : DocumentosSGITipo
    Dim txtDocumentosSGIArea As DropDownList ' Etiqueta : Area - Control : txtDocumentosSGIArea - Variable : DocumentosSGIArea
    Dim txtDocumentosSGIEmpresa As DropDownList ' Etiqueta : Empresa Contratista - Control : txtDocumentosSGIEmpresa - Variable : DocumentosSGIEmpresa

    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim DocumentosSGICodigo As String ' Etiqueta : Código - Control : txtDocumentosSGICodigo - Variable : DocumentosSGICodigo
    Dim DocumentosSGINombre As String ' Etiqueta : Nombre - Control : txtDocumentosSGINombre - Variable : DocumentosSGINombre
    Dim DocumentosSGITipo As String ' Etiqueta : Tipo de Documento - Control : txtDocumentosSGITipo - Variable : DocumentosSGITipo
    Dim DocumentosSGIArea As String ' Etiqueta : Area - Control : txtDocumentosSGIArea - Variable : DocumentosSGIArea
    Dim DocumentosSGIEmpresa As String ' Etiqueta : Empresa Contratista - Control : txtDocumentosSGIEmpresa - Variable : DocumentosSGIEmpresa
    '----------------------------------------------------------------------------------------
    ' Declaración de controles de indicador de búsqueda por la variable asociado al checkbox
    '----------------------------------------------------------------------------------------
    Dim chktxtDocumentosSGICodigo As CheckBox ' Etiqueta : Código - Control : txtDocumentosSGICodigo - Variable : DocumentosSGICodigo
    Dim chktxtDocumentosSGINombre As CheckBox ' Etiqueta : Nombre - Control : txtDocumentosSGINombre - Variable : DocumentosSGINombre
    Dim chktxtDocumentosSGITipo As CheckBox ' Etiqueta : Tipo de Documento - Control : txtDocumentosSGITipo - Variable : DocumentosSGITipo
    Dim chktxtDocumentosSGIArea As CheckBox ' Etiqueta : Area - Control : txtDocumentosSGIArea - Variable : DocumentosSGIArea
    Dim chktxtDocumentosSGIEmpresa As CheckBox ' Etiqueta : Empresa Contratista - Control : txtDocumentosSGIEmpresa - Variable : DocumentosSGIEmpresa

    '----------------------------------------
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim Cantidad As Integer = 0
        Dim Codigo As Long = 0
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String
        Dim sSQLWhere As String = ""
        Dim sSQL As String = ""

        Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")

        If Session("RolName") = "Lector" Then
            Url = "IndexSGI.aspx?PaginaWebName=Lista Politicas&MenuOptionsId=211&GrupoDocs=Lista de Documentos&Titulo=Formularios"
        End If

        If chktxtDocumentosSGICodigo.Checked = True Then
            If Len(sSQLWhere) = 0 Then
                sSQLWhere = " Where DocumentosSGICodigo = '" & txtDocumentosSGICodigo.Text & "' "
            Else
                sSQLWhere = sSQLWhere & " AND DocumentosSGICodigo = '" & txtDocumentosSGICodigo.Text & "' "
            End If
        End If
        If chktxtDocumentosSGINombre.Checked = True Then
            If Len(sSQLWhere) = 0 Then
                sSQLWhere = " Where DocumentosSGINombre = '" & txtDocumentosSGINombre.Text & "' "
            Else
                sSQLWhere = sSQLWhere & " AND DocumentosSGINombre = '" & txtDocumentosSGINombre.Text & "' "
            End If
        End If
        If chktxtDocumentosSGITipo.Checked = True Then
            If Len(sSQLWhere) = 0 Then
                sSQLWhere = " Where DocumentosSGITipo = '" & txtDocumentosSGITipo.Text & "' "
            Else
                sSQLWhere = sSQLWhere & " AND DocumentosSGITipo = '" & txtDocumentosSGITipo.Text & "' "
            End If
        End If
        If chktxtDocumentosSGIArea.Checked = True Then
            If Len(sSQLWhere) = 0 Then
                sSQLWhere = " Where DocumentosSGIArea = '" & txtDocumentosSGIArea.Text & "' "
            Else
                sSQLWhere = sSQLWhere & " AND DocumentosSGIArea = '" & txtDocumentosSGIArea.Text & "' "
            End If
        End If
        If chktxtDocumentosSGIEmpresa.Checked = True Then
            If Len(sSQLWhere) = 0 Then
                sSQLWhere = " Where DocumentosSGIEmpresa = '" & txtDocumentosSGIEmpresa.Text & "' "
            Else
                sSQLWhere = sSQLWhere & " AND DocumentosSGIEmpresa = '" & txtDocumentosSGIEmpresa.Text & "' "
            End If
        End If
        If Len(sSQLWhere) > 0 Then
            Url = Url & "&sSqlWhere=" & sSQLWhere
        End If
        lblMensaje.Visible = "False"
        sSQL = "SELECT Count(*) AS Cantidad, Max(DocumentosSGIId) AS Codigo FROM DocumentosSGI" & sSQLWhere
        t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)
        If Cantidad > 1 Then
            Response.Redirect(Url)  'Se pasa a la página que muestra la lista de comunas
        Else
            If Cantidad = 1 Then    'Se pasa a la página que muestra la ficha de la única comuna seleccionada
                ' Solo en el caso que el rol sea distinto a lector, en el otro caso muestra la lista aunque contenga un único elemento
                If Session("RolName") <> "Lector" Then
                    Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=Ficha de DocumentosSGI&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Codigo
                End If
                Response.Redirect(Url)
            Else
                lblMensaje.Text = "No existen registros que cumplan con el criterio de selección"
                lblMensaje.Visible = "True"
            End If
            End If
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim sSQLWhere As String = ""
        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        Call Lecturas.CrearFormularioLogin(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyTable, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        txtDocumentosSGICodigo = FindControl("txtDocumentosSGICodigo")
        chktxtDocumentosSGICodigo = FindControl("chktxtDocumentosSGICodigo")
        txtDocumentosSGINombre = FindControl("txtDocumentosSGINombre")
        chktxtDocumentosSGINombre = FindControl("chktxtDocumentosSGINombre")
        txtDocumentosSGITipo = FindControl("txtDocumentosSGITipo")
        chktxtDocumentosSGITipo = FindControl("chktxtDocumentosSGITipo")
        txtDocumentosSGIArea = FindControl("txtDocumentosSGIArea")
        chktxtDocumentosSGIArea = FindControl("chktxtDocumentosSGIArea")
        txtDocumentosSGIEmpresa = FindControl("txtDocumentosSGIEmpresa")
        chktxtDocumentosSGIEmpresa = FindControl("chktxtDocumentosSGIEmpresa")
    End Sub

    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim Cantidad As Integer = 0
        Dim Codigo As Long = 0
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String
        Dim sSQLWhere As String = ""
        Dim sSQL As String = ""

        Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        sSQLWhere = " Where DocumentosSGINombre LIKE '%" & txtDescription.Text & "%' "

        If Session("RolName") = "Lector" Then
            Url = "IndexSGI.aspx?PaginaWebName=Lista Politicas&MenuOptionsId=211&GrupoDocs=Lista de Documentos&Titulo=Formularios"
        End If

        If Len(sSQLWhere) > 0 Then
            Url = Url & "&sSqlWhere=" & sSQLWhere
        End If
        lblMensaje.Visible = "False"
        sSQL = "SELECT Count(*) AS Cantidad, Max(DocumentosSGIId) AS Codigo FROM DocumentosSGI" & sSQLWhere
        t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)
        If Cantidad > 1 Then
            Response.Redirect(Url)  'Se pasa a la página que muestra la lista de comunas
        Else
            If Cantidad = 1 Then    'Se pasa a la página que muestra la ficha de la única comuna seleccionada
                ' Solo en el caso que el rol sea distinto a lector, en el otro caso muestra la lista aunque contenga un único elemento
                If Session("RolName") <> "Lector" Then
                    Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=Ficha de DocumentosSGI&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Codigo
                End If
                Response.Redirect(Url)
            Else
                lblMensaje.Text = "No existen registros que cumplan con el criterio de selección"
                lblMensaje.Visible = "True"
            End If
        End If
    End Sub
End Class
