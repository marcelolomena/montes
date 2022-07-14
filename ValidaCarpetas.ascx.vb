﻿Imports AjaxControlToolkit
Partial Class ValidaCarpetas
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 23-08-2011 23:44:57
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
    Dim txtMasterName As TextBox ' Etiqueta : Código - Control : txtMasterName - Variable : GruposCodigo
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim CarpetasName As String ' Etiqueta : Código - Control : txtMasterName - Variable : GruposCodigo
    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim Carpetas As New Carpetas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogin", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim CarpetasPId As Long = 0
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina
        Try
            MasterName = txtMasterName.Text
            MasterId = 0
            t = AccionesABM.MasterPartialInsert("CarpetasId", "CarpetasName", "Carpetas", MasterName, CLng(Session("PersonaId")), MasterId)
            If Len(Request.QueryString("MasterId")) > 0 Then
                CarpetasPId = CLng(Request.QueryString("MasterId"))
            Else
                CarpetasPId = 0
            End If
            t = Carpetas.CarpetasUpdatePId(MasterId, CarpetasPId, MasterName, CLng(Session("PersonaId")))
            Url = Url & "&Id=" & MasterId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
            Response.Redirect(Url)

            ' Se habilita creación de carpetas con el mismo nombre.
            ' Lo comentado corresponde a la versión anterior
            't = Lecturas.LeerMasterIdByMasterName("CarpetasId", "CarpetasName", "Carpetas", MasterName, MasterId)
            'If MasterId > 0 Then
            'Url = Url & "&Id=" & MasterId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
            'Response.Redirect(Url)
            'Else
            't = AccionesABM.MasterPartialInsert("CarpetasId", "CarpetasName", "Carpetas", MasterName, CLng(Session("PersonaId")), MasterId)
            'If Len(Request.QueryString("MasterId")) > 0 Then
            'CarpetasPId = CLng(Request.QueryString("MasterId"))
            'Else
            'CarpetasPId = 0
            'End If
            't = Carpetas.CarpetasUpdatePId(MasterId, CarpetasPId, MasterName, CLng(Session("PersonaId")))
            'Url = Url & "&Id=" & MasterId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
            'Response.Redirect(Url)
            'End If
        Catch
            t = 0
        End Try
    End Sub
    Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogout", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        Call Lecturas.CrearFormularioLogin(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyTable, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler LoginButton.Click, AddressOf RFC_Login
        AddHandler CancelButton.Click, AddressOf RFC_Logout
        If IsPostBack Then
            txtMasterName = FindControl("txtMasterName")
        End If
    End Sub
End Class
