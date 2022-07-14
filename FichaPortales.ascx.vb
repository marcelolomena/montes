
Partial Class FichaPortales
    Inherits System.Web.UI.UserControl
    '------------------------------------------------------------
    ' Código generado por ZRISMART SF el 29-08-2011 8:50:58
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
    Dim txtPortalesName As TextBox
    Dim txtPortalesDescription As TextBox
    Dim txtPortalesSecuencia As TextBox
    Dim txtPortalesURLIndex As TextBox
    Dim txtPortalesLogo1 As TextBox
    Dim txtPortalesBanner As TextBox
    Dim txtPortalesLogo2 As TextBox
    Dim txtPortalesMasterPage As TextBox

    '----------------------------------------
    ' Declaración de Campos de la Aplicación
    '----------------------------------------
    Dim PortalesName As String
    Dim PortalesDescription As String
    Dim PortalesSecuencia As Long
    Dim PortalesURLIndex As String
    Dim PortalesLogo1 As String
    Dim PortalesBanner As String
    Dim PortalesLogo2 As String
    Dim PortalesMasterPage As String
    '----------------------------------------
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click
        Dim Lecturas As New Lecturas
        Dim Portales As New Portales
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLDelete", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim Mensaje As String = ""
        Try
            t = Portales.PortalesDelete(Request.QueryString("Id"), CStr(txtPortalesName.Text), CLng(Session("PersonaId")), Mensaje)
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
        Response.Redirect(Url)
    End Sub
    Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLNew", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLLogout", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Response.Redirect(Url, True)
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&ID=" & Request.QueryString("Id") & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim AccionesABM As New AccionesABM
        Dim Portales As New Portales
        Try
            t = Portales.PortalesUpdate(Request.QueryString("Id"), CStr(txtPortalesName.Text), CLng(txtPortalesSecuencia.Text), CStr(txtPortalesDescription.Text), CStr(txtPortalesURLIndex.Text), CStr(txtPortalesLogo1.Text), CStr(txtPortalesBanner.Text), CStr(txtPortalesLogo2.Text), CStr(txtPortalesMasterPage.Text), Session("PersonaId"))
        Catch
            t = 0
        End Try
        Response.Redirect(Url, True)
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim Lecturas As New Lecturas
        Dim Portales As New Portales
        Dim t As Boolean
        Dim TituloPagina As String = ""
        Dim DescripcionPagina As String = ""
        Dim NumeroPagina As Integer = 0
        Dim GroupValidation As String = ""
        Dim PaginaWebName As String = ""
        Dim sSQLWhere As String = ""
        Dim sSQLOrder As String = ""
        t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString("MenuOptionsId")), Logo, BarMenu, SideBarMenu, PaginaWebName)
        t = Lecturas.LeerPaginaWeb(Request.QueryString("PaginaWebName"), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)
        Session("NumeroPagina") = NumeroPagina
        Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)
        AddHandler UpdateButton.Click, AddressOf RFC_Update
        AddHandler NewButton.Click, AddressOf RFC_New
        AddHandler SearchButton.Click, AddressOf RFC_Search
        AddHandler DeleteButton.Click, AddressOf RFC_Delete
        AddHandler CancelButton.Click, AddressOf RFC_Logout
        SearchButton.Visible = False
        If Not IsPostBack Then
            If Request.QueryString("Id") <> 0 Then
                If t = Portales.LeerPortales(Request.QueryString("Id"), PortalesName, PortalesSecuencia, PortalesDescription, PortalesURLIndex, PortalesLogo1, PortalesBanner, PortalesLogo2, PortalesMasterPage) Then
                    lblLinkNuevo.Text = "<a href=""IndexSGI.aspx?PaginaWebName=Ficha de MenuOptions&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=0&Carpeta=Indicar Nombre&PortalesId=" & Request.QueryString("Id") & "&PId=0"" >Agregar opción de Menú Principal</a>"
                    txtPortalesName = FindControl("txtPortalesName")
                    txtPortalesName.Text = PortalesName
                    txtPortalesSecuencia = FindControl("txtPortalesSecuencia")
                    txtPortalesSecuencia.Text = PortalesSecuencia
                    txtPortalesDescription = FindControl("txtPortalesDescription")
                    txtPortalesDescription.Text = PortalesDescription
                    txtPortalesURLIndex = FindControl("txtPortalesURLIndex")
                    txtPortalesURLIndex.Text = PortalesURLIndex
                    txtPortalesLogo1 = FindControl("txtPortalesLogo1")
                    txtPortalesLogo1.Text = PortalesLogo1
                    txtPortalesBanner = FindControl("txtPortalesBanner")
                    txtPortalesBanner.Text = PortalesBanner
                    txtPortalesLogo2 = FindControl("txtPortalesLogo2")
                    txtPortalesLogo2.Text = PortalesLogo2
                    txtPortalesMasterPage = FindControl("txtPortalesMasterPage")
                    txtPortalesMasterPage.Text = PortalesMasterPage
                    ' Variante para seleccionar las opciones de menú del portal (De esta forma se reutilizan opciones de menú entre portales y no hay que darse la lata de crearlas
                    CreatePerfil()
                Else
                    txtPortalesName = FindControl("txtPortalesName")
                    txtPortalesName.Text = Session("PortalesName")
                End If
            End If
        Else
            txtPortalesName = FindControl("txtPortalesName")
            txtPortalesSecuencia = FindControl("txtPortalesSecuencia")
            txtPortalesDescription = FindControl("txtPortalesDescription")
            txtPortalesURLIndex = FindControl("txtPortalesURLIndex")
            txtPortalesLogo1 = FindControl("txtPortalesLogo1")
            txtPortalesBanner = FindControl("txtPortalesBanner")
            txtPortalesLogo2 = FindControl("txtPortalesLogo2")
            txtPortalesMasterPage = FindControl("txtPortalesMasterPage")
        End If
    End Sub
    Sub CreatePerfil()
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim FuncionesPorPortal As New FuncionesPorPortal
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim Rol As New Rol
        Dim t As Boolean = False
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim FuncionesPorRolId As Long = 0
        Dim IsAuthorizedUser As Boolean = FuncionesPorRol.LeerFuncionesPorRol(Session("RolId"), CLng(Request.QueryString("MenuOptionsId")), "MenuOptions", FuncionesPorRolId)
        Dim RolName As String = Rol.LeerRolNameByRolId(Session("RolId"))
        Dim CodigoHTML As String = ""
        Dim CodigoHTMLCarpetas As String = ""
        Dim CarpetaRaiz As String = ""

        CodigoHTML = ""
        CodigoHTML = CodigoHTML & "<br /><div id=""ListaCarpetas"">" & FuncionesPorPortal.ListarFuncionesPorPortal(CodigoHTMLCarpetas, Session("PersonaId"), IsAuthorizedUser, Request.QueryString("Id")) & "</div>"
        MyTable.Controls.Add(New LiteralControl(CodigoHTML))
    End Sub


End Class
