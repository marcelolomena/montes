Partial Class BuscaEntidades
    Inherits System.Web.UI.UserControl
    Dim WithEvents LoginButton As Button
    Dim WithEvents UpdateButton As Button
    Dim WithEvents CancelButton As Button
    Dim WithEvents NewButton As Button
    Dim WithEvents SearchButton As Button
    Dim WithEvents DeleteButton As Button
    Dim WithEvents ReturnButton As Button
    ' Declaración de Controles de Búsqueda
    '-------------------------------------
    'Comunas
    Dim txtComunaName As DropDownList
    Dim txtComunaProvincia As DropDownList
    Dim txtComunaRegion As DropDownList
    'Familias de Cargos
    Dim txtEstCargoName As DropDownList
    Dim txtEstCargoPlanta As DropDownList
    'Cargos
    Dim txtCargosName As DropDownList
    ' Clientes
    Dim txtEMail As DropDownList
    Dim txtRut As DropDownList
    Dim txtName As DropDownList
    Dim txtApPaterno As DropDownList
    Dim txtComuna As DropDownList
    ' Portales
    Dim txtPortalesName As DropDownList
    ' PaginaWeb
    Dim txtPaginaWebName As DropDownList
    Dim txtFormularioWebNumber As DropDownList
    Dim txtPaginaWebStereotype As DropDownList
    Dim txtPaginaWebUserControl As DropDownList

    ' Declaración de controles de indicador de búsqueda por la variable asociado al checkbox
    '----------------------------------------------------------------------------------------
    ' Clientes
    Dim chktxtEMail As CheckBox
    Dim chktxtRut As CheckBox
    Dim chktxtName As CheckBox
    Dim chktxtApPaterno As CheckBox
    Dim chktxtComuna As CheckBox
    'Comunas
    Dim chktxtComunaName As CheckBox
    Dim chktxtComunaProvincia As CheckBox
    Dim chktxtComunaRegion As CheckBox
    'Familias de Cargos
    Dim chktxtEstCargoName As CheckBox
    Dim chktxtEstCargoPlanta As CheckBox
    'Cargos
    Dim chktxtCargosName As CheckBox
    'Portales
    Dim chktxtPortalesName As CheckBox
    ' PaginaWeb
    Dim chktxtPaginaWebName As CheckBox
    Dim chktxtFormularioWebNumber As CheckBox
    Dim chktxtPaginaWebStereotype As CheckBox
    Dim chktxtPaginaWebUserControl As CheckBox
    ' Declaración de controles de validación
    Dim valTextBox As RequiredFieldValidator
    Dim sumValidacion As ValidationSummary
    Dim REValidacion As RegularExpressionValidator
    Dim CuValidacion As CustomValidator
    Dim CoValidacion As CompareValidator
    ' Declaración de Campos de la Aplicación
    '---------------------------------------
    'Comunas
    Dim ComunaId As Long
    Dim ComunaName As String
    Dim ComunaDescription As String
    Dim ComunaProvincia As String
    Dim ComunaRegion As String
    'Familias de Cargos
    Dim EstCargoId As Long
    Dim EstCargoName As String
    Dim EstCargoDescription As String
    Dim EstCargoSecuencia As Long
    Dim EstCargoPlanta As String
    'Cargos
    Dim CargosId As Long
    Dim CargosName As String
    Dim CargosDescription As String
    ' Clientes
    Dim ClienteId As Long
    Dim ClienteEMail As String
    Dim ClienteRut As String
    Dim ClienteName As String
    Dim ClienteApPaterno As String
    Dim ClienteApMaterno As String
    Dim ClienteCalle As String
    Dim ClienteNumero As String
    Dim ClienteDepartamento As String
    Dim ClienteComuna As String
    Dim ClienteCiudad As String
    Dim ClienteTelefonoParticular As String
    Dim ClienteCelular As String
    Dim ClienteTelefonoComercial1 As String
    Dim ClienteTelefonoComercial2 As String
    Dim ClienteFNacimiento As Date
    'Portales
    Dim PortalesId As Long
    Dim PortalesName As String
    Dim PortalesDescription As String
    Dim PortalesSecuencia As Long
    'PaginaWeb
    Dim PaginaWebId As Long
    Dim PaginaWebName As String
    Dim PaginaWebTitle As String
    Dim PaginaWebDescription As String
    Dim FormularioWebNumber As Long
    Dim PaginaWebGroupValidation As String
    Dim PaginaWebStereotype As String
    Dim PaginaWebUserControl As String
    ' Declaración de Variables de la Aplicación
    Dim t As Boolean
    Dim Logo As String = ""
    Dim BarMenu As String = ""
    Dim SideBarMenu As String = ""
    'Dim PaginaWebName As String = ""
    Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click
        'Se pone solo por completitud
    End Sub
    Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim Pagina As String = ""
        Dim NombrePagina As String = ""
        Dim Cantidad As Integer = 0
        Dim Codigo As Long = 0

        t = Lecturas.LeerURLStatementFormularioWeb("URLUpdate", Pagina, NombrePagina, Session("NumeroPagina"))
        Dim Url As String = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=" & NombrePagina & "&MenuOptionsId=" & Request.QueryString("MenuOptionsId")
        Dim sSQLWhere As String = ""
        Dim sSQL As String = ""

        Select Case Request.QueryString("PaginaWebName")
            Case "Busca Comuna"
                If chktxtComunaName.Checked = True Then
                    sSQLWhere = " Where Comuna.ComunaName = '" & txtComunaName.Text & "' "
                End If
                If chktxtComunaProvincia.Checked = True Then
                    If Len(sSQLWhere) = 0 Then
                        sSQLWhere = " Where Comuna.ComunaProvincia = '" & txtComunaProvincia.Text & "' "
                    Else
                        sSQLWhere = sSQLWhere & "AND Comuna.ComunaProvincia = '" & txtComunaProvincia.Text & "' "
                    End If
                End If
                If chktxtComunaRegion.Checked = True Then
                    If Len(sSQLWhere) = 0 Then
                        sSQLWhere = " Where Comuna.ComunaRegion = '" & txtComunaRegion.Text & "' "
                    Else
                        sSQLWhere = sSQLWhere & "AND Comuna.ComunaRegion = '" & txtComunaRegion.Text & "' "
                    End If
                End If
                If Len(sSQLWhere) > 0 Then
                    Url = Url & "&sSqlWhere=" & sSQLWhere
                End If

                lblMensaje.Visible = "False"
                sSQL = "SELECT Count(*) AS Cantidad, Max(ComunaId) AS Codigo FROM Comuna" & sSQLWhere
                t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)
                If Cantidad > 1 Then
                    Response.Redirect(Url)  'Se pasa a la página que muestra la lista de comunas
                Else
                    If Cantidad = 1 Then    'Se pasa a la página que muestra la ficha de la única comuna seleccionada
                        Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=Ficha de Comuna&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Codigo
                        Response.Redirect(Url)
                    Else                    'No hay registros que cumplan con el criterio de selección
                        lblMensaje.Text = "No existen registros que cumplan con el criterio de selección"
                        lblMensaje.Visible = "True"
                    End If
                End If
            Case "Busca EstCargo"
                If chktxtEstCargoName.Checked = True Then
                    sSQLWhere = " Where EstereotiposCargos.EstCargoName = '" & txtEstCargoName.Text & "' "
                End If
                If chktxtEstCargoPlanta.Checked = True Then
                    If Len(sSQLWhere) = 0 Then
                        sSQLWhere = " Where EstereotiposCargos.EstCargoPlanta = '" & txtEstCargoPlanta.Text & "' "
                    Else
                        sSQLWhere = sSQLWhere & "AND EstereotiposCargos.EstCargoPlanta = '" & txtEstCargoPlanta.Text & "' "
                    End If
                End If

                lblMensaje.Visible = "False"
                sSQL = "SELECT Count(*) AS Cantidad, Max(EstCargoId) AS Codigo FROM EstereotiposCargos" & sSQLWhere
                t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)

                If Cantidad > 1 Then
                    If Len(sSQLWhere) > 0 Then
                        Url = Url & "&sSqlWhere=" & sSQLWhere & "&sSQLOrderBy=Order By EstereotiposCargos.EstCargoSecuencia"
                    End If
                    Response.Redirect(Url)  'Se pasa a la página que muestra la lista de familias de cargos
                Else
                    If Cantidad = 1 Then    'Se pasa a la página que muestra la ficha de la única familia seleccionada
                        Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=Ficha de EstCargo&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Codigo
                        Response.Redirect(Url)
                    Else                    'No hay registros que cumplan con el criterio de selección
                        lblMensaje.Text = "No existen registros que cumplan con el criterio de selección"
                        lblMensaje.Visible = "True"
                    End If
                End If

            Case "Busca Cargos"
                If chktxtCargosName.Checked = True Then
                    sSQLWhere = " Where Cargos.CargosName = '" & txtCargosName.Text & "' "
                End If
                If chktxtEstCargoName.Checked = True Then
                    If Len(sSQLWhere) = 0 Then
                        sSQLWhere = " Where Cargos.EstCargoName = '" & txtEstCargoName.Text & "' "
                    Else
                        sSQLWhere = sSQLWhere & "AND Cargos.EstCargoName = '" & txtEstCargoName.Text & "' "
                    End If
                End If

                lblMensaje.Visible = "False"
                sSQL = "SELECT Count(*) AS Cantidad, Max(CargosId) AS Codigo FROM Cargos" & sSQLWhere
                t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)

                If Cantidad > 1 Then
                    If Len(sSQLWhere) > 0 Then
                        Url = Url & "&sSqlWhere=" & sSQLWhere & "&sSQLOrderBy=Order By Cargos.EstCargoName"
                    End If
                    Response.Redirect(Url)  'Se pasa a la página que muestra la lista de cargos
                Else
                    If Cantidad = 1 Then    'Se pasa a la página que muestra la ficha del único cargo seleccionado
                        Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=Ficha de Cargos&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Codigo
                        Response.Redirect(Url)
                    Else                    'No hay registros que cumplan con el criterio de selección
                        lblMensaje.Text = "No existen registros que cumplan con el criterio de selección"
                        lblMensaje.Visible = "True"
                    End If
                End If
            Case "Busca Cliente"
                If chktxtEMail.Checked = True Then
                    sSQLWhere = " Where Cliente.ClienteEMail = '" & txtEMail.Text & "' "
                End If

                If chktxtRut.Checked = True Then
                    If Len(sSQLWhere) = 0 Then
                        sSQLWhere = " Where Cliente.ClienteRut = '" & txtRut.Text & "' "
                    Else
                        sSQLWhere = sSQLWhere & "AND Cliente.ClienteRut = '" & txtRut.Text & "' "
                    End If
                End If

                If chktxtName.Checked = True Then
                    If Len(sSQLWhere) = 0 Then
                        sSQLWhere = " Where Cliente.ClienteName = '" & txtName.Text & "' "
                    Else
                        sSQLWhere = sSQLWhere & "AND Cliente.ClienteName = '" & txtName.Text & "' "
                    End If
                End If

                If chktxtApPaterno.Checked = True Then
                    If Len(sSQLWhere) = 0 Then
                        sSQLWhere = " Where Cliente.ClienteApPaterno = '" & txtApPaterno.Text & "' "
                    Else
                        sSQLWhere = sSQLWhere & "AND Cliente.ClienteApPaterno = '" & txtApPaterno.Text & "' "
                    End If
                End If

                If chktxtComuna.Checked = True Then
                    If Len(sSQLWhere) = 0 Then
                        sSQLWhere = " Where Cliente.ClienteComuna = '" & txtComuna.Text & "' "
                    Else
                        sSQLWhere = sSQLWhere & "AND Cliente.ClienteComuna = '" & txtComuna.Text & "' "
                    End If
                End If

                lblMensaje.Visible = "False"
                sSQL = "SELECT Count(*) AS Cantidad, Max(ClienteId) AS Codigo FROM Cliente" & sSQLWhere
                t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)

                If Cantidad > 1 Then
                    If Len(sSQLWhere) > 0 Then
                        Url = Url & "&sSqlWhere=" & sSQLWhere ' & "&sSQLOrderBy=Order By Cliente.ClienteApPaterno"
                    End If
                    Response.Redirect(Url)  'Se pasa a la página que muestra la lista de cargos
                Else
                    If Cantidad = 1 Then    'Se pasa a la página que muestra la ficha del único cargo seleccionado
                        Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=Ficha de Cliente&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Codigo
                        Response.Redirect(Url)
                    Else                    'No hay registros que cumplan con el criterio de selección
                        lblMensaje.Text = "No existen registros que cumplan con el criterio de selección"
                        lblMensaje.Visible = "True"
                    End If
                End If
            Case "Busca Portales"
                If chktxtPortalesName.Checked = True Then
                    sSQLWhere = " Where Portales.PortalesName = '" & txtPortalesName.Text & "' "
                End If

                lblMensaje.Visible = "False"
                sSQL = "SELECT Count(*) AS Cantidad, Max(PortalesId) AS Codigo FROM Portales" & sSQLWhere
                t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)

                If Cantidad > 1 Then
                    If Len(sSQLWhere) > 0 Then
                        Url = Url & "&sSqlWhere=" & sSQLWhere & "&sSQLOrderBy=Order By Portales.PortalesSecuencia"
                    End If
                    Response.Redirect(Url)  'Se pasa a la página que muestra la lista de portales
                Else
                    If Cantidad = 1 Then    'Se pasa a la página que muestra la ficha del único portal seleccionado
                        Url = Pagina & "?PaginaWebName=Ficha de Portales&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Codigo
                        Response.Redirect(Url)
                    Else                    'No hay registros que cumplan con el criterio de selección
                        lblMensaje.Text = "No existen registros que cumplan con el criterio de selección"
                        lblMensaje.Visible = "True"
                    End If
                End If
            Case "Busca Páginas"
                If chktxtPaginaWebName.Checked = True Then
                    sSQLWhere = " Where PaginaWeb.PaginaWebName = '" & txtPaginaWebName.Text & "' "
                End If

                If chktxtFormularioWebNumber.Checked = True Then
                    If Len(sSQLWhere) = 0 Then
                        sSQLWhere = " Where PaginaWeb.FormularioWebNumber = " & txtFormularioWebNumber.Text & " "
                    Else
                        sSQLWhere = sSQLWhere & "AND PaginaWeb.FormularioWebNumber = " & txtFormularioWebNumber.Text & " "
                    End If
                End If

                If chktxtPaginaWebStereotype.Checked = True Then
                    If Len(sSQLWhere) = 0 Then
                        sSQLWhere = " Where PaginaWeb.PaginaWebStereotype = '" & txtPaginaWebStereotype.Text & "' "
                    Else
                        sSQLWhere = sSQLWhere & "AND PaginaWeb.PaginaWebStereotype = '" & txtPaginaWebStereotype.Text & "' "
                    End If
                End If

                If chktxtPaginaWebUserControl.Checked = True Then
                    If Len(sSQLWhere) = 0 Then
                        sSQLWhere = " Where PaginaWeb.PaginaWebUserControl = '" & txtPaginaWebUserControl.Text & "' "
                    Else
                        sSQLWhere = sSQLWhere & "AND PaginaWeb.PaginaWebUserControl = '" & txtPaginaWebUserControl.Text & "' "
                    End If
                End If

                lblMensaje.Visible = "False"
                sSQL = "SELECT Count(*) AS Cantidad, Max(PaginaWebId) AS Codigo FROM PaginaWeb" & sSQLWhere
                t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)

                If Cantidad > 1 Then
                    If Len(sSQLWhere) > 0 Then
                        Url = Url & "&sSqlWhere=" & sSQLWhere & "&sSQLOrderBy=Order By PaginaWeb.FormularioWebNumber"
                    End If
                    Response.Redirect(Url)  'Se pasa a la página que muestra la lista de páginas
                Else
                    If Cantidad = 1 Then    'Se pasa a la página que muestra la ficha de la única pagina web seleccionada
                        Url = Pagina & "?Pagina=" & Request.QueryString("Pagina") & "&SideBar=" & Request.QueryString("SideBar") & "&PaginaWebName=Ficha de Páginas&MenuOptionsId=" & Request.QueryString("MenuOptionsId") & "&Id=" & Codigo
                        Response.Redirect(Url)
                    Else                    'No hay registros que cumplan con el criterio de selección
                        lblMensaje.Text = "No existen registros que cumplan con el criterio de selección"
                        lblMensaje.Visible = "True"
                    End If
                End If
        End Select
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

        If IsPostBack Then
            Select Case Request.QueryString("PaginaWebName")
                Case "Busca Comuna"
                    txtComunaName = FindControl("txtComunaName")
                    txtComunaProvincia = FindControl("txtComunaProvincia")
                    txtComunaRegion = FindControl("txtComunaRegion")
                    chktxtComunaName = FindControl("chktxtComunaName")
                    chktxtComunaProvincia = FindControl("chktxtComunaProvincia")
                    chktxtComunaRegion = FindControl("chktxtComunaRegion")
                Case "Busca EstCargo"
                    txtEstCargoName = FindControl("txtEstCargoName")
                    chktxtEstCargoName = FindControl("chktxtEstCargoName")
                    txtEstCargoPlanta = FindControl("txtEstCargoPlanta")
                    chktxtEstCargoPlanta = FindControl("chktxtEstCargoPlanta")
                Case "Busca Cargos"
                    txtEstCargoName = FindControl("txtEstCargoName")
                    chktxtEstCargoName = FindControl("chktxtEstCargoName")
                    txtCargosName = FindControl("txtCargosName")
                    chktxtCargosName = FindControl("chktxtCargosName")
                Case "Busca Cliente"
                    txtEMail = FindControl("txtEMail")
                    txtRut = FindControl("txtRut")
                    txtName = FindControl("txtName")
                    txtApPaterno = FindControl("txtApPaterno")
                    txtComuna = FindControl("txtComuna")
                    chktxtEMail = FindControl("chktxtEMail")
                    chktxtRut = FindControl("chktxtRut")
                    chktxtName = FindControl("chktxtName")
                    chktxtApPaterno = FindControl("chktxtApPaterno")
                    chktxtComuna = FindControl("chktxtComuna")
                Case "Busca Portales"
                    txtPortalesName = FindControl("txtPortalesName")
                    chktxtPortalesName = FindControl("chktxtPortalesName")
                Case "Busca Páginas"
                    txtPaginaWebName = FindControl("txtPaginaWebName")
                    txtFormularioWebNumber = FindControl("txtFormularioWebNumber")
                    txtPaginaWebStereotype = FindControl("txtPaginaWebStereotype")
                    txtPaginaWebUserControl = FindControl("txtPaginaWebUserControl")
                    chktxtPaginaWebName = FindControl("chktxtPaginaWebName")
                    chktxtFormularioWebNumber = FindControl("chktxtFormularioWebNumber")
                    chktxtPaginaWebStereotype = FindControl("chktxtPaginaWebStereotype")
                    chktxtPaginaWebUserControl = FindControl("chktxtPaginaWebUserControl")
            End Select
        End If
    End Sub
End Class
