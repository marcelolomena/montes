Imports AjaxControlToolkit
Partial Class FichaMenuOptions
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 23-08-2011 23:42:51
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
    'Dim txtMenuOptionsPId As TextBox ' Etiqueta : Código - Control : txtGruposCodigo - Variable : GruposCodigo
    Dim txtSecuencia As TextBox
    Dim txtClass As TextBox ' Etiqueta : Nombre - Control : txtGruposName - Variable : GruposName
    Dim txthref As TextBox ' Etiqueta : Descripción - Control : txtGruposDescription - Variable : GruposDescription
    Dim txtTitle As TextBox
    Dim txtTexto As TextBox ' Etiqueta : Código - Control : txtGruposCodigo - Variable : GruposCodigo
    Dim txtLogo As TextBox
    Dim txtBarMenu As TextBox ' Etiqueta : Nombre - Control : txtGruposName - Variable : GruposName
    Dim txtSideBarMenu As TextBox
    Dim txtPaginaWebName As TextBox ' Etiqueta : Código - Control : txtGruposCodigo - Variable : GruposCodigo
    Dim txtSystemId As TextBox
    Dim txtPortalesName As TextBox ' Etiqueta : Nombre - Control : txtGruposName - Variable : GruposName
    Dim txtZona As TextBox
    Dim txtOptionsType As TextBox
    Dim txtIsNodoHoja As TextBox ' Etiqueta : Código - Control : txtGruposCodigo - Variable : GruposCodigo
    Dim txtDescription As TextBox
    Dim txtcssClas As TextBox
    Dim txtMenuOptionsWidth As TextBox
    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim MenuOptionsId As Long
    Dim MenuOptionsPId As Long ' Etiqueta : Código - Control : txtGruposCodigo - Variable : GruposCodigo
    Dim Secuencia As Long
    Dim MenuOptionsClass As String ' Etiqueta : Nombre - Control : txtGruposName - Variable : GruposName
    Dim MenuOptionshref As String ' Etiqueta : Descripción - Control : txtGruposDescription - Variable : GruposDescription
    Dim MenuOptionsTitle As String ' Etiqueta : Código - Control : txtGruposCodigo - Variable : GruposCodigo
    Dim MenuOptionsTexto As String ' Etiqueta : Código - Control : txtGruposCodigo - Variable : GruposCodigo
    Dim MenuOptionsLogo As String
    Dim MenuOptionsBarMenu As String ' Etiqueta : Nombre - Control : txtGruposName - Variable : GruposName
    Dim MenuOptionsSideBarMenu As String
    Dim MenuOptionsPaginaWebName As String ' Etiqueta : Código - Control : txtGruposCodigo - Variable : GruposCodigo
    Dim MenuOptionsSystemId As String
    Dim MenuOptionsPortalesName As String ' Etiqueta : Nombre - Control : txtGruposName - Variable : GruposName
    Dim MenuOptionsZona As String
    Dim MenuOptionsType As String
    Dim MenuOptionsIsNodoHoja As String ' Etiqueta : Código - Control : txtGruposCodigo - Variable : GruposCodigo
    Dim MenuOptionsDescription As String
    Dim MenuOptionscssClas As String
    Dim MenuOptionsWidth As String
    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim MenuOptions As New MenuOptions
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&ID=" & Request.QueryString("PortalesId")
        Dim Mensaje As String = ""
        Try
            t = MenuOptions.MenuOptionsDelete(Request.QueryString("Id"), CStr(txtTexto.Text), CLng(Session("PersonaId")), Mensaje)
            If t = False Then
                MyMessage1.Text = Mensaje
            Else
                Response.Redirect(Url, True)
            End If
        Catch
            t = 0
        End Try
    End Sub
    Protected Sub RFC_Search(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLSearch", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&PortalesId=" & Request.QueryString("PortalesId")
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogout", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Request.QueryString("PortalesId")
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Integer
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Request.QueryString("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&PortalesId=" & Request.QueryString("PortalesId")
        Dim AccionesABM As New AccionesABM
        Dim MenuOptions As New MenuOptions
        txthref.Text = "IndexSGI.aspx?PaginaWebName=" & txtPaginaWebName.Text & "&MenuOptionsId=" & Request.QueryString("Id")
        Try
            t = MenuOptions.MenuOptionsUpdate(Request.QueryString("Id"), CLng(txtMenuOptionsPId.Value), CLng(txtSecuencia.Text), CStr(txtClass.Text), CStr(txthref.Text), CStr(txtTitle.Text), CStr(txtTexto.Text), CStr(txtLogo.Text), CStr(txtBarMenu.Text), CStr(txtSideBarMenu.Text), CStr(txtPaginaWebName.Text), CLng(txtSystemId.Text), CStr(txtPortalesName.Text), CStr(txtZona.Text), CStr(txtOptionsType.Text), CStr(txtIsNodoHoja.Text), CStr(txtDescription.Text), CStr(txtcssClas.Text), CStr(txtMenuOptionsWidth.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url, True)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim MenuOptions As New MenuOptions
        Dim Portales As New Portales
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim PaginaWebName As String = ""
        Dim sSQLWhere As String = ""
        Dim sSQLOrder As String = ""
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim PId As Long = 0
        Dim Total As Long = 0

        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler SearchButton.Click, AddressOf RFC_Search
        AddHandler DeleteButton.Click, AddressOf RFC_Delete
        AddHandler CancelButton.Click, AddressOf RFC_Logout
        NewButton.Visible = False
        SearchButton.Visible = False
        If Not IsPostBack Then
            If Request.QueryString("Id") <> 0 Then
                If t = MenuOptions.LeerMenuOptions(Request.QueryString("Id"), MenuOptionsPId, Secuencia, MenuOptionsClass, MenuOptionshref, MenuOptionsTitle, MenuOptionsTexto, MenuOptionsLogo, MenuOptionsBarMenu, MenuOptionsSideBarMenu, MenuOptionsPaginaWebName, MenuOptionsSystemId, MenuOptionsPortalesName, MenuOptionsZona, MenuOptionsType, MenuOptionsIsNodoHoja, MenuOptionsDescription, MenuOptionscssClas, MenuOptionsWidth) Then
                    If MenuOptionsIsNodoHoja <> "Hoja" Then
                        lblLinkNuevo.Text = "<a href=""IndexSGI.aspx?PaginaWebName=Ficha de MenuOptions&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=0&Carpeta=Indicar Nombre&PId=" & Request.QueryString("Id") & """ >Agregar opción de Menú</a>"
                    End If
                    If MenuOptions.LeerTotalSubMenusRelacionados(Request.QueryString("Id")) > 0 Then
                        DeleteButton.Visible = False
                    End If
                    'Cargo valores en campos de cabecera
                    txtOpcionSuperior.Text = MenuOptions.LeerFullTexto(MenuOptionsPId)
                    txtOpcion.Text = MenuOptionsTexto
                    '-----------------
                    txtMenuOptionsPId = FindControl("txtMenuOptionsPId")
                    txtMenuOptionsPId.Value = MenuOptionsPId
                    txtSecuencia = FindControl("txtSecuencia")
                    txtSecuencia.Text = Secuencia
                    txtClass = FindControl("txtClass")
                    txtClass.Text = MenuOptionsClass
                    txthref = FindControl("txthref")
                    txthref.Text = MenuOptionshref
                    txtTitle = FindControl("txtTitle")
                    txtTitle.Text = MenuOptionsTitle
                    txtTexto = FindControl("txtTexto")
                    txtTexto.Text = MenuOptionsTexto
                    txtLogo = FindControl("txtLogo")
                    txtLogo.Text = MenuOptionsLogo
                    txtBarMenu = FindControl("txtBarMenu")
                    txtBarMenu.Text = MenuOptionsBarMenu
                    txtSideBarMenu = FindControl("txtSideBarMenu")
                    txtSideBarMenu.Text = MenuOptionsSideBarMenu
                    txtPaginaWebName = FindControl("txtPaginaWebName")
                    txtPaginaWebName.Text = MenuOptionsPaginaWebName
                    txtSystemId = FindControl("txtSystemId")
                    txtSystemId.Text = MenuOptionsSystemId
                    txtPortalesName = FindControl("txtPortalesName")
                    txtPortalesName.Text = MenuOptionsPortalesName
                    txtZona = FindControl("txtZona")
                    txtZona.Text = MenuOptionsZona
                    txtOptionsType = FindControl("txtOptionsType")
                    txtOptionsType.Text = MenuOptionsType
                    txtIsNodoHoja = FindControl("txtIsNodoHoja")
                    txtIsNodoHoja.Text = MenuOptionsIsNodoHoja
                    txtDescription = FindControl("txtDescription")
                    txtDescription.Text = MenuOptionsDescription
                    txtcssClas = FindControl("txtcssClas")
                    txtcssClas.Text = MenuOptionscssClas
                    txtMenuOptionsWidth = FindControl("txtMenuOptionsWidth")
                    txtMenuOptionsWidth.Text = MenuOptionsWidth
                    ' Variante para administrar el mapa del sitio del portal
                    If MenuOptionsIsNodoHoja <> "Hoja" Then
                        CreateTable(NumeroPagina, TituloPagina, DescripcionPagina, CLng(Request.QueryString("Id")), CLng(Request.QueryString("MenuOptionsId")))
                    End If
                Else
                    txtTexto = FindControl("txtTexto")
                    txtTexto.Text = Request.QueryString("Carpeta")
                End If
            Else  ' Cuando Id es igual a 0 y por tanto se debe crear un nuevo registro bajo el PId Indicado
                ' Debo grabar un registro nuevo con el PId dado y la cosa cambio si el Pid es 0 o mayor a 0.
                PId = CLng(Request.QueryString("PId")) ' De quien depende 
                If PId = 0 Then 'Es una opción de menú principal, se agregar un MenuHoja, una Raiz, un Nodo y una Hoja de Menu 
                    'Opción de menu principal
                    Secuencia = Lecturas.LeerMaximoId("Select Max(Secuencia) as MaximoId FROM MenuOptions Where Zona = 'BarMenu'") + 1
                    MenuOptionsZona = "BarMenu"
                    MenuOptionsIsNodoHoja = "MenuHoja"
                    MenuOptionsId = 0
                    t = MenuOptions.MenuOptionsInsert(MenuOptionsId, PId, Secuencia, Request.QueryString("Carpeta"), MenuOptionsZona, MenuOptionsIsNodoHoja, Session("PersonaId"))
                    'Opción Raiz
                    Secuencia = 1
                    MenuOptionsZona = "SideBarMenu"
                    MenuOptionsIsNodoHoja = "Raiz"
                    PId = MenuOptionsId
                    MenuOptionsId = 0
                    t = MenuOptions.MenuOptionsInsert(MenuOptionsId, PId, Secuencia, Request.QueryString("Carpeta"), MenuOptionsZona, MenuOptionsIsNodoHoja, Session("PersonaId"))
                    'Opción Nodo
                    Secuencia = 1
                    MenuOptionsZona = "SideBarMenu"
                    MenuOptionsIsNodoHoja = "Nodo"
                    PId = MenuOptionsId
                    MenuOptionsId = 0
                    t = MenuOptions.MenuOptionsInsert(MenuOptionsId, PId, Secuencia, Request.QueryString("Carpeta"), MenuOptionsZona, MenuOptionsIsNodoHoja, Session("PersonaId"))
                    'Opción Hoja
                    Secuencia = 1
                    MenuOptionsZona = "SideBarMenu"
                    MenuOptionsIsNodoHoja = "Hoja"
                    PId = MenuOptionsId
                    MenuOptionsId = 0
                    t = MenuOptions.MenuOptionsInsert(MenuOptionsId, PId, Secuencia, Request.QueryString("Carpeta"), MenuOptionsZona, MenuOptionsIsNodoHoja, Session("PersonaId"))
                Else
                    Secuencia = Lecturas.LeerMaximoId("Select Max(Secuencia) as MaximoId FROM MenuOptions Where MenuOptionsPId = " & PId) + 1
                    MenuOptionsZona = "SideBarMenu"
                    MenuOptionsIsNodoHoja = MenuOptions.LeerIsNodoHoja(PId)
                    ' Si PId es > 0 se debe ver de que nodo se trata y crear todos los registros hasta la hoja, no puede ser MenuHoja
                    Select Case MenuOptionsIsNodoHoja
                        Case "Raiz"     'Se debe crear la raiz solicitada, un nodo y una hoja
                            MenuOptionsId = 0
                            t = MenuOptions.MenuOptionsInsert(MenuOptionsId, PId, Secuencia, Request.QueryString("Carpeta"), MenuOptionsZona, MenuOptionsIsNodoHoja, Session("PersonaId"))
                            'Opción Nodo
                            Secuencia = 1
                            MenuOptionsZona = "SideBarMenu"
                            MenuOptionsIsNodoHoja = "Nodo"
                            PId = MenuOptionsId
                            MenuOptionsId = 0
                            t = MenuOptions.MenuOptionsInsert(MenuOptionsId, PId, Secuencia, Request.QueryString("Carpeta"), MenuOptionsZona, MenuOptionsIsNodoHoja, Session("PersonaId"))
                            'Opción Hoja
                            Secuencia = 1
                            MenuOptionsZona = "SideBarMenu"
                            MenuOptionsIsNodoHoja = "Hoja"
                            PId = MenuOptionsId
                            MenuOptionsId = 0
                            t = MenuOptions.MenuOptionsInsert(MenuOptionsId, PId, Secuencia, Request.QueryString("Carpeta"), MenuOptionsZona, MenuOptionsIsNodoHoja, Session("PersonaId"))
                        Case "Nodo"     'Se debe crear el nodo solicitado y la hoja
                            MenuOptionsId = 0
                            t = MenuOptions.MenuOptionsInsert(MenuOptionsId, PId, Secuencia, Request.QueryString("Carpeta"), MenuOptionsZona, MenuOptionsIsNodoHoja, Session("PersonaId"))
                            'Opción Hoja
                            Secuencia = 1
                            MenuOptionsZona = "SideBarMenu"
                            MenuOptionsIsNodoHoja = "Hoja"
                            PId = MenuOptionsId
                            MenuOptionsId = 0
                            t = MenuOptions.MenuOptionsInsert(MenuOptionsId, PId, Secuencia, Request.QueryString("Carpeta"), MenuOptionsZona, MenuOptionsIsNodoHoja, Session("PersonaId"))
                        Case "Hoja"     'Se debe crear el nodo solicitado y la hoja
                            MenuOptionsId = 0
                            t = MenuOptions.MenuOptionsInsert(MenuOptionsId, PId, Secuencia, Request.QueryString("Carpeta"), MenuOptionsZona, MenuOptionsIsNodoHoja, Session("PersonaId"))
                    End Select
                End If
                t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
                Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & MenuOptionsId & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
                Response.Redirect(Url, True)
            End If
        Else
            txtMenuOptionsPId = FindControl("txtMenuOptionsPId")
            txtSecuencia = FindControl("txtSecuencia")
            txtClass = FindControl("txtClass")
            txthref = FindControl("txthref")
            txtTitle = FindControl("txtTitle")
            txtTexto = FindControl("txtTexto")
            txtLogo = FindControl("txtLogo")
            txtBarMenu = FindControl("txtBarMenu")
            txtSideBarMenu = FindControl("txtSideBarMenu")
            txtPaginaWebName = FindControl("txtPaginaWebName")
            txtSystemId = FindControl("txtSystemId")
            txtPortalesName = FindControl("txtPortalesName")
            txtZona = FindControl("txtZona")
            txtOptionsType = FindControl("txtOptionsType")
            txtIsNodoHoja = FindControl("txtIsNodoHoja")
            txtDescription = FindControl("txtDescription")
            txtcssClas = FindControl("txtcssClas")
            txtMenuOptionsWidth = FindControl("txtMenuOptionsWidth")
        End If
    End Sub
    Sub CreateTable(ByVal NumeroPagina As Integer, ByVal TituloPagina As String, ByVal DescripcionPagina As String, ByVal Id As Long, ByVal MenuOptionsId As Long)
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim Rol As New Rol
        Dim t As Boolean = False
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim FuncionesPorRolId As Long = 0
        Dim IsAuthorizedUser As Boolean = FuncionesPorRol.LeerFuncionesPorRol(Session("RolId"), CLng(Request.QueryString("MenuOptionsId")), "MenuOptions", FuncionesPorRolId)
        Dim RolName As String = Rol.LeerRolNameByRolId(Session("RolId"))
        Dim MenuOptions As New MenuOptions
        Dim CodigoHTML As String = ""
        Dim CodigoHTMLCarpetas As String = ""
        Dim CarpetaRaiz As String = ""

        'Session("CarpetaRaiz") = PortalesName
        'CodigoHTML = "<h1>" & TituloPagina & "</h1>"
        CodigoHTML = ""
        CodigoHTML = CodigoHTML & "<br /><div id=""ListaCarpetas"">" & MenuOptions.LoadEditarSubNodos(CodigoHTMLCarpetas, Id, Session("PersonaId"), IsAuthorizedUser, MenuOptionsId) & "</div>"
        MyTable.Controls.Add(New LiteralControl(CodigoHTML))



    End Sub



End Class
