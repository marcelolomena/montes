Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class MenuOptions
    Public Function LeerMenuOptions(ByVal MenuOptionsId As Long, ByRef MenuOptionsPID As Long, ByRef Secuencia As Long, _
                            ByRef GrupoOpciones As String, ByRef href As String, ByRef title As String, ByRef Texto As String, _
                            ByRef Logo As String, ByRef BarMenu As String, ByRef SideBarMenu As String, _
                            ByRef PaginaWebName As String, ByRef SystemId As Long, ByRef PortalesName As String, _
                            ByRef Zona As String, ByRef OptionsType As String, ByRef IsNodoHoja As String, _
                            ByRef Description As String, _
                            Optional ByRef cssClass As String = "", Optional ByRef MenuOptionsWidth As String = "") As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select MenuOptionsPID, Secuencia, Class, href, title, Texto, Logo, BarMenu, SideBarMenu, PaginaWebName, SystemId, PortalesName, Zona, OptionsType, IsNodoHoja, Description, cssClass, MenuOptionsWidth "
        sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.MenuOptionsId) = " & MenuOptionsId & ")) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                MenuOptionsPID = CLng(dtr("MenuOptionsPId").ToString)
                Secuencia = CLng(dtr("Secuencia").ToString)
                GrupoOpciones = dtr("Class").ToString
                href = dtr("href").ToString
                title = dtr("title").ToString
                Texto = dtr("Texto").ToString
                Logo = dtr("Logo").ToString
                BarMenu = dtr("BarMenu").ToString
                SideBarMenu = dtr("SideBarMenu").ToString
                PaginaWebName = dtr("PaginaWebName").ToString
                SystemId = CLng(dtr("SystemId").ToString)
                PortalesName = dtr("PortalesName").ToString
                Zona = dtr("Zona").ToString
                OptionsType = dtr("OptionsType").ToString
                IsNodoHoja = dtr("IsNodoHoja").ToString
                Description = dtr("Description").ToString
                cssClass = dtr("cssClass").ToString
                MenuOptionsWidth = dtr("MenuOptionsWidth").ToString
            End While
            LeerMenuOptions = True
            dtr.Close()
        Catch
            LeerMenuOptions = False
        End Try
    End Function
    Public Function DescripcionDelRequisito(ByVal MenuOptionsId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Description "
        sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.MenuOptionsId) = " & MenuOptionsId & ")) "

        DescripcionDelRequisito = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                DescripcionDelRequisito = dtr("Description").ToString
            End While
            dtr.Close()
        Catch
            DescripcionDelRequisito = ""
        End Try
    End Function

    Public Function UpdateDescripcionRequisito(ByVal MenuOptionsId As Long, ByVal Description As String, ByVal UserId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "UPDATE [montes].[dbo].MenuOptions "
        strUpdate = strUpdate & "SET "
        strUpdate = strUpdate & "MenuOptions.Description = '" & Description & "', "
        strUpdate = strUpdate & "MenuOptions.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "MenuOptions.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE MenuOptions.MenuOptionsId = " & MenuOptionsId
        Try
            UpdateDescripcionRequisito = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Opción de Menú: " & MenuOptionsId, MenuOptionsId, "MenuOptions", "")
        Catch
            UpdateDescripcionRequisito = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar la opción de menú: " & MenuOptionsId, MenuOptionsId, "MenuOptions", "")
        End Try
    End Function
    Public Function LeerMenuOptionsPId(ByVal MenuOptionsId As Long) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select MenuOptionsPID "
        sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.MenuOptionsId) = " & MenuOptionsId & ")) "

        LeerMenuOptionsPId = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                LeerMenuOptionsPId = CLng(dtr("MenuOptionsPId").ToString)
            End While
            dtr.Close()
        Catch
            LeerMenuOptionsPId = 0
        End Try

    End Function
    Public Function LeerTexto(ByVal MenuOptionsId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Texto "
        sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.MenuOptionsId) = " & MenuOptionsId & ")) "

        LeerTexto = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                LeerTexto = dtr("Texto").ToString
            End While
            dtr.Close()
        Catch
            LeerTexto = ""
        End Try
    End Function
    Public Function LeerFullTexto(ByVal MenuOptionsId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim PId As Long = MenuOptionsId
        LeerFullTexto = ">"

        Do While PId > 0

            sSQL = "Select Texto, MenuOptionsPId As PId "
            sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
            sSQL = sSQL & "WHERE (((MenuOptions.MenuOptionsId) = " & PId & ")) "

            Try
                dtr = AccesoEA.ListarRegistros(sSQL)

                While dtr.Read
                    LeerFullTexto = ">" & dtr("Texto").ToString & LeerFullTexto
                    PId = CLng(dtr("PId").ToString)
                End While
                dtr.Close()
            Catch
                LeerFullTexto = ""
            End Try


        Loop



    End Function



    Public Function LeerIsNodoHoja(ByVal MenuOptionsId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select IsNodoHoja "
        sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.MenuOptionsId) = " & MenuOptionsId & ")) "

        LeerIsNodoHoja = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                Select Case dtr("IsNodoHoja").ToString
                    Case "MenuHoja"
                        LeerIsNodoHoja = "Raiz"
                    Case "Raiz"
                        LeerIsNodoHoja = "Nodo"
                    Case "Nodo"
                        LeerIsNodoHoja = "Hoja"
                    Case Else
                        LeerIsNodoHoja = ""
                End Select
            End While
            dtr.Close()
        Catch
            LeerIsNodoHoja = ""
        End Try
    End Function

    Public Function LoadEditarRaicesCarpeta(ByRef CodigoHTML As String, ByVal UserId As Long, ByVal IsAuthorizedUser As Boolean, ByVal MenuOptionsId As Long) As String
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim t As Boolean
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;"
        Dim MenuOptions As New MenuOptions
        Dim l As String = ""
        Dim Pagina As String = ""

        Dim UrlEditarCarpeta As String = "*"
        Dim UrlCrearSubCarpeta As String = "*"

        Dim PId As Long = 0


        sSQL = "SELECT MenuOptionsId As PId, Texto As Carpeta, Description As Descripcion, PaginaWebName as Pagina, Secuencia  "
        sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = 0 AND Zona = 'BarMenu' "
        sSQL = sSQL & "ORDER by MenuOptions.Secuencia"

        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""vinculo_carpeta"">"
        CodigoHTML = CodigoHTML & "<tr><th width=""200"" align=""left"">Opción de Menú</th><th width=""250"" align=""left"">Descripción</th><th width=""150"" align=""left"">Página</th><th width=""68"" align=""center"">Editar</th></tr>"
        LoadEditarRaicesCarpeta = ""
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read
                Pagina = ""
                If dtrFunciones("Pagina").ToString <> "Por definir" Then
                    Pagina = dtrFunciones("Pagina").ToString
                End If
                UrlEditarCarpeta = "IndexSGI.aspx?PaginaWebName=Ficha de MenuOptions&MenuOptionsId=" & MenuOptionsId & "&Carpeta=" & dtrFunciones("Carpeta").ToString & "&Id=" & dtrFunciones("Pid").ToString
                l = "<input id=""txtInputbox" & dtrFunciones("Pid").ToString & """ type=""text"" style=""text-align:right;width: 25px"" class=""textoboxgris""  value=""" & FormatNumber(CLng(dtrFunciones("Secuencia").ToString), 0) & """ onblur=""MenuOptionsUpdateSecuencia(" & CLng(dtrFunciones("Pid").ToString) & ", " & PId & ", " & UserId & ")""  />&nbsp;&nbsp;<a href=""" & UrlEditarCarpeta & """><img src=""img/editar.png"" alt=""Editar Opción de Menú"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Editar opción de Menú"" /></a>"
                CodigoHTML = CodigoHTML & "<tr>"
                If IsAuthorizedUser = True Then
                    CodigoHTML = CodigoHTML & "<td width=""250"" align=""left"">" & dtrFunciones("Carpeta").ToString & "</td><td width=""250"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""100"" align=""left"">" & Pagina & "</td><td width=""68"" align=""center"">" & l & "</td>"
                Else
                    CodigoHTML = CodigoHTML & "<td width=""250"" align=""left"">" & dtrFunciones("Carpeta").ToString & "</td><td width=""250"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""100"" align=""left"">" & Pagina & "</td><td width=""68"" align=""center""></td>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                t = MenuOptions.LoadEditarNodosCarpetas(CLng(dtrFunciones("PId").ToString), CodigoHTML, UserId, Espacios, IsAuthorizedUser, MenuOptionsId, PId)
            End While
            dtrFunciones.Close()
        Catch
            LoadEditarRaicesCarpeta = ""
        End Try
        LoadEditarRaicesCarpeta = CodigoHTML & "</table>"
    End Function
    Public Function LoadEditarNodosCarpetas(ByVal CarpetasPId As Long, ByRef CodigoHTML As String, ByVal UserId As Long, ByVal Espacios As String, ByVal IsAuthorizedUser As Boolean, ByVal MenuOptionsId As Long, ByVal PId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim MenuOptions As New MenuOptions
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim t As Boolean
        Dim EspacioMasAbajo As String = Espacios & "&nbsp;&nbsp;&nbsp;"
        Dim l As String = ""
        Dim m As String = ""
        Dim UrlEditarCarpeta As String = "*"
        Dim UrlCrearSubCarpeta As String = "*"
        Dim Pagina As String = ""


        sSQL = "SELECT MenuOptionsId As PId, Texto As Carpeta, Description As Descripcion, PaginaWebName as Pagina, Secuencia "
        sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = " & CarpetasPId
        sSQL = sSQL & " ORDER by MenuOptions.Secuencia"
        LoadEditarNodosCarpetas = False
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)
            While dtrFunciones.Read
                Pagina = ""
                If dtrFunciones("Pagina").ToString <> "Por definir" Then
                    Pagina = dtrFunciones("Pagina").ToString
                End If
                UrlEditarCarpeta = "IndexSGI.aspx?PaginaWebName=Ficha de MenuOptions&MenuOptionsId=" & MenuOptionsId & "&Carpeta=" & dtrFunciones("Carpeta").ToString & "&Id=" & dtrFunciones("Pid").ToString
                l = "<a href=""" & UrlCrearSubCarpeta & """><img src=""img/WebResource2.gif"" alt=""Crear Subcarpeta"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Crear Subcarpeta"" /></a>"
                m = "<input id=""txtInputbox" & dtrFunciones("Pid").ToString & """ type=""text"" style=""text-align:right;width: 25px"" class=""textoboxgris""  value=""" & FormatNumber(CLng(dtrFunciones("Secuencia").ToString), 0) & """ onblur=""MenuOptionsUpdateSecuencia(" & CLng(dtrFunciones("Pid").ToString) & ", " & PId & ", " & UserId & ")""  />&nbsp;&nbsp;<a href=""" & UrlEditarCarpeta & """><img src=""img/editar.png"" alt=""Editar Carpeta"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Editar Descripción y Posición y Asociar Archivos"" /></a>"
                CodigoHTML = CodigoHTML & "<tr>"
                If IsAuthorizedUser Then
                    CodigoHTML = CodigoHTML & "<td width=""250"" align=""left"">" & Espacios & dtrFunciones("Carpeta").ToString & "</td><td width=""250"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""100"" align=""left"">" & Pagina & "</td><td width=""68"" align=""center"">" & m & "</td>"
                Else
                    CodigoHTML = CodigoHTML & "<td width=""250"" align=""left"">" & Espacios & dtrFunciones("Carpeta").ToString & "</td><td width=""250"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""100"" align=""left"">" & Pagina & "</td><td width=""68"" align=""center""></td>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                t = MenuOptions.LoadEditarNodosCarpetas(CLng(dtrFunciones("PId").ToString), CodigoHTML, UserId, EspacioMasAbajo, IsAuthorizedUser, MenuOptionsId, PId)
                LoadEditarNodosCarpetas = True
            End While
            dtrFunciones.Close()
        Catch
            LoadEditarNodosCarpetas = False
        End Try
    End Function
    Public Function MenuOptionsDelete(ByVal MenuOptionsId As Long, ByVal Texto As String, ByVal UserId As Long, ByRef Mensaje As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String = ""
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim Total As Long
        Dim MenuOptions As New MenuOptions
        Dim MensajeEliminar As String = ""

        ' Lee la cantidad de veces que el área es usada en la tabla de documentos del SGI
        '------------------------------------------
        Total = MenuOptions.LeerTotalSubMenusRelacionados(MenuOptionsId)
        MenuOptionsDelete = False
        If Total > 0 Then
            'Mensaje = "Existen " & Total & " menus subordinados a la opción de menu " & Texto & vbCrLf
            'Mensaje = Mensaje & ", elimine los submenus antes de eliminarlo de la lista"
            Mensaje = MensajeEliminar
            MenuOptionsDelete = False
        Else
            Try
                ' Borra registro de la tabla de Carpetas
                '-------------------------------------
                strUpdate = "DELETE FROM [montes].[dbo].MenuOptions WHERE MenuOptionsId = " & MenuOptionsId
                t = AccesoEA.ABMRegistros(strUpdate)
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina el submenu: " & Texto, MenuOptionsId, "MenuOptions", "")
                MenuOptionsDelete = True
            Catch
                t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar la opción de menú: " & Texto, MenuOptionsId, "MenuOptions", "")
                MenuOptionsDelete = False
            End Try
        End If
    End Function
    Public Function LeerTotalSubMenusRelacionados(ByVal MenuOptionsPId As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        'Verifica si tiene submenues
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.MenuOptionsPId)=" & MenuOptionsPId & "))"
        LeerTotalSubMenusRelacionados = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalSubMenusRelacionados = CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalSubMenusRelacionados = 0
        End Try

        'Verifica si tiene autorizaciones de acceso
        sSQL = "SELECT Count(*) AS Total "
        sSQL = sSQL & "FROM [montes].[dbo].FuncionesPorRol "
        sSQL = sSQL & "WHERE (((FuncionesPorRol.FuncionId)=" & MenuOptionsPId & " AND (FuncionesPorRol.EntidadNombreTabla) = 'MenuOptions'))"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTotalSubMenusRelacionados = LeerTotalSubMenusRelacionados + CLng(dtr("Total").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalSubMenusRelacionados = LeerTotalSubMenusRelacionados + 0
        End Try


    End Function
    Public Function MenuOptionsUpdate(ByVal MenuOptionsId As Long, ByVal MenuOptionsPId As Long, ByVal MenuOptionsSecuencia As Long, ByVal MenuOptionsClass As String, ByVal MenuOptionsHref As String, ByVal MenuOptionsTitle As String, ByVal MenuOptionsTexto As String, ByVal MenuOptionsLogo As String, ByVal MenuOptionsBarMenu As String, ByVal MenuOptionsSideBarMenu As String, ByVal MenuOptionsPaginaWebName As String, ByVal MenuOptionsSystemId As Long, ByVal MenuOptionsPortalesName As String, ByVal MenuOptionsZona As String, ByVal MenuOptionsType As String, ByVal MenuOptionsIsNodoHoja As String, ByVal MenuOptionsDescription As String, ByVal MenuOptionsCssClass As String, ByVal MenuOptionsWidth As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "UPDATE [montes].[dbo].MenuOptions SET "
        strUpdate = strUpdate & "MenuOptions.MenuOptionsPId = " & MenuOptionsPId & ", "
        strUpdate = strUpdate & "MenuOptions.Secuencia = " & MenuOptionsSecuencia & ", "
        strUpdate = strUpdate & "MenuOptions.Class = '" & MenuOptionsClass & "', "
        strUpdate = strUpdate & "MenuOptions.href = '" & MenuOptionsHref & "', "
        strUpdate = strUpdate & "MenuOptions.title = '" & MenuOptionsTitle & "', "
        strUpdate = strUpdate & "MenuOptions.Texto = '" & MenuOptionsTexto & "', "
        strUpdate = strUpdate & "MenuOptions.Logo = '" & MenuOptionsLogo & "', "
        strUpdate = strUpdate & "MenuOptions.BarMenu = '" & MenuOptionsBarMenu & "', "
        strUpdate = strUpdate & "MenuOptions.SideBarMenu = '" & MenuOptionsSideBarMenu & "', "
        strUpdate = strUpdate & "MenuOptions.PaginaWebName = '" & MenuOptionsPaginaWebName & "', "
        strUpdate = strUpdate & "MenuOptions.SystemId = " & MenuOptionsSystemId & ", "
        strUpdate = strUpdate & "MenuOptions.PortalesName = '" & MenuOptionsPortalesName & "', "
        strUpdate = strUpdate & "MenuOptions.Zona = '" & MenuOptionsZona & "', "
        strUpdate = strUpdate & "MenuOptions.OptionsType = '" & MenuOptionsType & "', "
        strUpdate = strUpdate & "MenuOptions.IsNodoHoja = '" & MenuOptionsIsNodoHoja & "', "
        strUpdate = strUpdate & "MenuOptions.Description = '" & MenuOptionsDescription & "', "
        strUpdate = strUpdate & "MenuOptions.cssClass = '" & MenuOptionsCssClass & "', "
        strUpdate = strUpdate & "MenuOptions.MenuOptionsWidth = '" & MenuOptionsWidth & "', "
        strUpdate = strUpdate & "MenuOptions.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "MenuOptions.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE MenuOptions.MenuOptionsId = " & MenuOptionsId
        Try
            MenuOptionsUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & MenuOptionsTexto, MenuOptionsId, "MenuOptions", "")
        Catch
            MenuOptionsUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & MenuOptionsTexto, MenuOptionsId, "MenuOptions", "")
        End Try
    End Function
    Public Function MenuOptionsUpdatePId(ByVal MenuOptionsId As Long, ByVal MenuOptionsPId As Long, ByVal MenuOptionsTexto As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0

        strUpdate = "UPDATE [montes].[dbo].MenuOptions SET "
        strUpdate = strUpdate & "MenuOptions.CarpetasPId = " & MenuOptionsPId & ", "
        strUpdate = strUpdate & "MenuOptions.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "MenuOptions.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE MenuOptions.MenuOptionsId = " & MenuOptionsId
        Try
            MenuOptionsUpdatePId = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza PId de " & MenuOptionsTexto, MenuOptionsId, "CarpMenuOptionsetas", "")
        Catch
            MenuOptionsUpdatePId = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el PId  del registro de " & MenuOptionsTexto, MenuOptionsId, "MenuOptions", "")
        End Try
    End Function
    Public Function MenuOptionsInsert(ByRef MenuOptionsId As Long, ByVal MenuOptionsPId As Long, ByVal MenuOptionsSecuencia As Long, ByVal MenuOptionsTexto As String, ByVal Zona As String, ByVal IsNodoHoja As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim AccesoEA As New AccesoEA
        Dim t As Integer = 0
        Dim strUpdate As String = ""
        Dim sSQL As String = ""

        strUpdate = "INSERT INTO MenuOptions (MenuOptionsPId, Secuencia, texto, Zona, IsNodoHoja, DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES (" & MenuOptionsPId & ", " & MenuOptionsSecuencia & ", '" & MenuOptionsTexto & "', '" & Zona & "', '" & IsNodoHoja & "', '" & AccionesABM.DateTransform(Now()) & "', " & UserId & ")"




        Try
            MenuOptionsInsert = AccesoEA.ABMRegistros(strUpdate)
            MenuOptionsId = Lecturas.LeerMaximoId("Select Max(MenuOptionsId) as MaximoId FROM MenuOptions")
            sSQL = "UPDATE [montes].[dbo].MenuOptions SET "
            sSQL = sSQL & "MenuOptions.href = '" & "IndexSGI.aspx?PaginaWebName=Por definir&MenuOptionsId=" & MenuOptionsId & "', "
            sSQL = sSQL & "MenuOptions.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
            sSQL = sSQL & "MenuOptions.UserLastUpdate = " & UserId & " "
            sSQL = sSQL & "WHERE MenuOptions.MenuOptionsId = " & MenuOptionsId
            MenuOptionsInsert = AccesoEA.ABMRegistros(sSQL)
            MenuOptionsInsert = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta una nueva Opción de Menú: " & MenuOptionsTexto, MenuOptionsId, "MenuOptions", "")
        Catch
            MenuOptionsInsert = 0
            MenuOptionsId = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar una nueva Opción de Menú: " & MenuOptionsTexto, MenuOptionsId, "MenuOptions", "")
        End Try
    End Function
    Public Function LoadRaizPorMenu(ByVal node As TreeNode, ByVal SystemId As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        'Dim dtrPackages As OleDbDataReader
        Dim dtrPackages As IDataReader
        Dim sSQL As String

        sSQL = "SELECT MenuOptionsId AS Numero, Texto AS Cargo, Description as Objetivo "
        sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
        sSQL = sSQL & "WHERE MenuOptions.SystemId = " & SystemId & " AND Zona = 'BarMenu' "
        sSQL = sSQL & "ORDER By Secuencia"

        LoadRaizPorMenu = False

        Try
            dtrPackages = AccesoEA.ListarRegistros(sSQL)
            While dtrPackages.Read
                Dim urlPaginaCargos As String = "javascript:handleGetDocumento('" & dtrPackages("Cargo") & "','" & dtrPackages("Numero") & "');"
                Dim newNode As TreeNode = New TreeNode(dtrPackages("Cargo"), dtrPackages("Numero"), "", urlPaginaCargos, "")
                newNode.SelectAction = TreeNodeSelectAction.Expand
                newNode.PopulateOnDemand = True
                node.ChildNodes.Add(newNode)
                LoadRaizPorMenu = True
            End While
            dtrPackages.Close()
        Catch
            LoadRaizPorMenu = False
        End Try

    End Function
    Public Function LoadHojaPorMenu(ByVal node As TreeNode) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrPackages As IDataReader
        Dim sSQL As String
        Dim ObjectId As String = node.Value

        sSQL = "SELECT MenuOptions_1.MenuOptionsId AS Numero, MenuOptions_1.Texto AS Cargo "
        sSQL = sSQL & "FROM [montes].[dbo].MenuOptions INNER JOIN MenuOptions AS MenuOptions_1 ON MenuOptions.MenuOptionsId = MenuOptions_1.MenuOptionsPId "
        sSQL = sSQL & "WHERE (((MenuOptions.MenuOptionsId) = " & ObjectId & ")) "
        sSQL = sSQL & "ORDER BY MenuOptions_1.Secuencia"

        LoadHojaPorMenu = False

        Try
            dtrPackages = AccesoEA.ListarRegistros(sSQL)
            While dtrPackages.Read
                'Dim urlPaginaCargos As String = "CambiarCargoSuperior.aspx?Nuevoid=" & dtrPackages("Numero") & "&NuevoCargo=" & dtrPackages("Cargo")
                Dim urlPaginaCargos As String = "javascript:handleGetDocumento('" & dtrPackages("Cargo") & "','" & dtrPackages("Numero") & "');"
                Dim newNode As TreeNode = New TreeNode(dtrPackages("Cargo"), dtrPackages("Numero"), "", urlPaginaCargos, "")
                newNode.SelectAction = TreeNodeSelectAction.Expand
                newNode.PopulateOnDemand = True
                node.ChildNodes.Add(newNode)
                LoadHojaPorMenu = True
            End While
            dtrPackages.Close()
        Catch
            LoadHojaPorMenu = False
        End Try
    End Function
    Public Function LoadEditarSubNodos(ByRef CodigoHTML As String, ByVal Id As Long, ByVal UserId As Long, ByVal IsAuthorizedUser As Boolean, ByVal MenuOptionsId As Long) As String
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim t As Boolean
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;"
        Dim MenuOptions As New MenuOptions
        Dim l As String = ""
        Dim Pagina As String = ""

        Dim UrlEditarCarpeta As String = "*"
        Dim UrlCrearSubCarpeta As String = "*"

        If Id = 0 Then
            sSQL = "SELECT MenuOptionsId As PId, Texto As Carpeta, Description As Descripcion, PaginaWebName as Pagina, Secuencia  "
            sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
            sSQL = sSQL & "WHERE MenuOptionsPId = 0 AND Zona = 'BarMenu' "
            sSQL = sSQL & "ORDER by MenuOptions.Secuencia"
        Else
            sSQL = "SELECT MenuOptionsId As PId, Texto As Carpeta, Description As Descripcion, PaginaWebName as Pagina, Secuencia "
            sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
            sSQL = sSQL & "WHERE MenuOptionsPId = " & Id & " "
            sSQL = sSQL & "ORDER by MenuOptions.Secuencia"
        End If

        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""vinculo_carpeta"">"
        CodigoHTML = CodigoHTML & "<tr><th width=""200"" align=""left"">Opción de Menú</th><th width=""250"" align=""left"">Descripción</th><th width=""150"" align=""left"">Página</th><th width=""68"" align=""center"">Editar</th></tr>"
        LoadEditarSubNodos = ""
        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read
                Pagina = ""
                If dtrFunciones("Pagina").ToString <> "Por definir" Then
                    Pagina = dtrFunciones("Pagina").ToString
                End If
                UrlEditarCarpeta = "IndexSGI.aspx?PaginaWebName=Ficha de MenuOptions&MenuOptionsId=" & MenuOptionsId & "&Carpeta=" & dtrFunciones("Carpeta").ToString & "&Id=" & dtrFunciones("Pid").ToString
                l = "<input id=""txtInputbox" & dtrFunciones("Pid").ToString & """ type=""text"" style=""text-align:right;width: 25px"" class=""textoboxgris""  value=""" & FormatNumber(CLng(dtrFunciones("Secuencia").ToString), 0) & """ onblur=""MenuOptionsUpdateSecuencia(" & CLng(dtrFunciones("Pid").ToString) & ", " & Id & ", " & UserId & ")""  />&nbsp;&nbsp;<a href=""" & UrlEditarCarpeta & """><img src=""img/editar.png"" alt=""Editar Opción de Menú"" style=""cursor:hand; vertical-align:bottom;"" hspace=""5"" border=""0"" title=""Editar opción de Menú"" /></a>"
                CodigoHTML = CodigoHTML & "<tr>"
                If IsAuthorizedUser = True Then
                    CodigoHTML = CodigoHTML & "<td width=""250"" align=""left"">" & dtrFunciones("Carpeta").ToString & "</td><td width=""250"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""100"" align=""left"">" & Pagina & "</td><td width=""68"" align=""center"">" & l & "</td>"
                Else
                    CodigoHTML = CodigoHTML & "<td width=""250"" align=""left"">" & dtrFunciones("Carpeta").ToString & "</td><td width=""250"" align=""left"">" & dtrFunciones("Descripcion").ToString & "</td><td width=""100"" align=""left"">" & Pagina & "</td><td width=""68"" align=""center""></td>"
                End If
                CodigoHTML = CodigoHTML & "<tr>"
                t = MenuOptions.LoadEditarNodosCarpetas(CLng(dtrFunciones("PId").ToString), CodigoHTML, UserId, Espacios, IsAuthorizedUser, MenuOptionsId, Id)
            End While
            dtrFunciones.Close()
        Catch
            LoadEditarSubNodos = ""
        End Try
        LoadEditarSubNodos = CodigoHTML & "</table>"
    End Function
    Public Function LoadRaicesDeBarraMenu(ByVal RolId As Long, ByVal PortalesId As Long) As String
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim MenuOption As String = ""
        Dim t As Boolean
        Dim Espacios As String = ""
        Dim CodigoHTML As String = ""
        Dim FuncionesPorRol = New FuncionesPorRol
        Dim FuncionesPorRolId As Long = 0

        CodigoHTML = "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""menu_principal"">"
        CodigoHTML = CodigoHTML & "<tr>"

        sSQL = "SELECT MenuOptions.MenuOptionsId As Numero, MenuOptions.Texto As Cargo, MenuOptions.Description As Objetivo, MenuOptions.href, MenuOptions.cssClass As FormatClass, MenuOptions.MenuOptionsWidth "
        sSQL = sSQL & "FROM (Portales INNER JOIN FuncionesPorPortal ON Portales.PortalesId = FuncionesPorPortal.PortalesId) INNER JOIN MenuOptions ON FuncionesPorPortal.MenuOptionsId = MenuOptions.MenuOptionsId "
        sSQL = sSQL & "WHERE(((Portales.[PortalesId]) = " & PortalesId & ")) "
        sSQL = sSQL & "ORDER BY FuncionesPorPortal.Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read
                If FuncionesPorRol.LeerFuncionesPorRol(RolId, CLng(dtrFunciones("Numero")), "MenuOptions", FuncionesPorRolId) Then
                    CodigoHTML = CodigoHTML & "<td width=""" & dtrFunciones("MenuOptionsWidth").ToString & """ height=""40"" class=""" & dtrFunciones("FormatClass").ToString & """><a href=""" & dtrFunciones("href") & """ >" & dtrFunciones("Cargo").ToString & "</a></td>"
                End If
            End While
            dtrFunciones.Close()
        Catch
            CodigoHTML = CodigoHTML & "<td></td>"
        End Try

        CodigoHTML = CodigoHTML & "</tr></table>"
        LoadRaicesDeBarraMenu = CodigoHTML
    End Function
    Public Function LeerMenuItemContext(ByVal MenuOptionsId As Long, ByRef Logo As String, ByRef BarMenu As String, ByRef SideBarMenu As String, ByRef PaginaWebName As String) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Logo, BarMenu, SideBarMenu, PaginaWebName "
        sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.MenuOptionsId) = " & MenuOptionsId & ")) "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                Logo = dtr("Logo").ToString
                BarMenu = dtr("BarMenu").ToString
                SideBarMenu = dtr("SideBarMenu").ToString
                PaginaWebName = dtr("PaginaWebName").ToString
            End While
            LeerMenuItemContext = True
            dtr.Close()
        Catch
            LeerMenuItemContext = False
        End Try
    End Function
    Public Function LoadRaicesDeBarraSubMenu(ByRef MyTable As PlaceHolder, ByVal NodoId As Long, ByVal Rol As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim MenuOption As String = ""
        Dim t As Boolean
        Dim Espacios As String = ""
        Dim BarraSubMenu As String = "<table width=""1000"" border=""0"" cellpadding=""0"" cellspacing=""0"" id=""submenu"">"

        'Aquí sólo creo la tabla y le traspaso el MenuOptionsId a la siguiente rutina.
        'La siguiente rutina lee las columnas de la barra de sub menu y por cada registro
        'crea una columna, pone el título y luego invoca la tercera rutina que agrega a dicha 
        'columna los link a las aplicaciones.


        'De esta instrucción nos interesa rescatar sólo el MenuOptionsId que vamos a usar como 
        'ParentId para rescatar los nodos del sub menu.

        sSQL = "SELECT MenuOptionsId "
        sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = " & NodoId & " "
        sSQL = sSQL & "ORDER by Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)

            While dtrFunciones.Read

                t = LoadNodosBarraDeSubMenu(BarraSubMenu, CLng(dtrFunciones("MenuOptionsId").ToString), NodoId, Rol)
                BarraSubMenu = BarraSubMenu & "</table>"
                MyTable.Controls.Add(New LiteralControl(BarraSubMenu))

            End While
            LoadRaicesDeBarraSubMenu = True
            dtrFunciones.Close()
        Catch
            LoadRaicesDeBarraSubMenu = False
        End Try

    End Function
    Public Function LoadNodosBarraDeSubMenu(ByRef BarraSubMenu As String, ByVal MenuOptionsPId As Long, ByVal NodoId As Long, ByVal Rol As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtrFunciones As IDataReader
        Dim sSQL As String
        Dim MenuOption As String = ""
        Dim t As Boolean
        Dim Espacios As String = ""
        Dim FilaEncabezado As String = "<tr>"
        Dim FilaOpciones As String = "<tr>"
        Dim i As Integer = 0

        'Se llena la primera fila, con sus respectivas columnas de título

        'Se leen los encabezados y por cada uno se va llenando la Fila de Encabezado y 
        'se invoca la siguiente rutina para llenar las opciones del menu.


        sSQL = "SELECT MenuOptionsId, Class, href, title, texto, IsNodoHoja "
        sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = " & MenuOptionsPId & " "
        sSQL = sSQL & "ORDER by Secuencia"

        Try
            dtrFunciones = AccesoEA.ListarRegistros(sSQL)


            While dtrFunciones.Read
                i = i + 1
                FilaEncabezado = FilaEncabezado & "<th scope=""col"">" & dtrFunciones("texto").ToString & "</th>"
                t = LoadOpcionesBarraSubMenu(FilaOpciones, CLng(dtrFunciones("MenuOptionsId").ToString), Espacios, NodoId, Rol)
            End While
            LoadNodosBarraDeSubMenu = True
            dtrFunciones.Close()
        Catch
            LoadNodosBarraDeSubMenu = False
        End Try
        FilaEncabezado = FilaEncabezado & "</tr>"
        FilaOpciones = FilaOpciones & "</tr>"
        BarraSubMenu = BarraSubMenu & FilaEncabezado & FilaOpciones


    End Function
    Public Function LoadOpcionesBarraSubMenu(ByRef FilaOpciones As String, ByVal MenuOptionsId As Long, ByRef Espacios As String, ByVal NodoId As Long, ByVal Rol As Long) As Boolean
        Dim AccesoEA = New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim MenuOption As String = ""
        Dim FuncionesPorRol As New FuncionesPorRol
        Dim FuncionesPorRolId As Long = 0

        'Se leen las opciones del menú que estan asociados a vínculos a las aplicaciones
        sSQL = "SELECT MenuOptionsId, Class, href, title, texto, IsNodoHoja "
        sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
        sSQL = sSQL & "WHERE MenuOptionsPId = " & MenuOptionsId
        sSQL = sSQL & " ORDER by Secuencia"

        FilaOpciones = FilaOpciones & "<td>"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                'Se asume que todas son opciones 
                If FuncionesPorRol.LeerFuncionesPorRol(Rol, CLng(dtr("MenuOptionsId").ToString), "MenuOptions", FuncionesPorRolId) Then
                    FilaOpciones = FilaOpciones & "<a href='" & dtr("href").ToString & "' class='linksubmenu'>" & Espacios & dtr("texto").ToString & "</a><br />"
                End If
            End While
            LoadOpcionesBarraSubMenu = True
            dtr.Close()
        Catch
            LoadOpcionesBarraSubMenu = False
        End Try
        FilaOpciones = FilaOpciones & "</td>"
    End Function
    Public Function LeerHastaBarMenu(ByRef MenuOptionsId As Long) As Long

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        Dim MenuOptionsPId As Long = MenuOptionsId
        LeerHastaBarMenu = MenuOptionsPId

        Do While MenuOptionsPId > 0

            MenuOptionsId = MenuOptionsPId 'Con esto aseguro leer el primer registro que me mandan

            sSQL = "Select MenuOptionsId As Id, MenuOptionsPId As PId "
            sSQL = sSQL & "FROM [montes].[dbo].MenuOptions "
            sSQL = sSQL & "WHERE (((MenuOptions.MenuOptionsId) = " & MenuOptionsId & ")) "

            Try
                dtr = AccesoEA.ListarRegistros(sSQL)

                While dtr.Read
                    MenuOptionsPId = CLng(dtr("PId").ToString)
                    MenuOptionsId = CLng(dtr("Id").ToString)
                End While
                dtr.Close()
            Catch
                LeerHastaBarMenu = MenuOptionsId
            End Try
        Loop
        LeerHastaBarMenu = MenuOptionsId
    End Function
    Public Function ObtenerURLInicioPortal(ByRef PortalesId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String


        sSQL = "SELECT MenuOptions.href As URLInicio "
        sSQL = sSQL & "FROM [montes].[dbo].Portales INNER JOIN [montes].[dbo].FuncionesPorPortal ON [montes].[dbo].Portales.PortalesId = [montes].[dbo].FuncionesPorPortal.PortalesId INNER JOIN [montes].[dbo].MenuOptions ON [montes].[dbo].FuncionesPorPortal.MenuOptionsId = [montes].[dbo].MenuOptions.MenuOptionsId "
        sSQL = sSQL & "WHERE(((Portales.PortalesId) = " & PortalesId & ") And ((FuncionesPorPortal.Secuencia) = 1))"


        ObtenerURLInicioPortal = "LoginPampaNorte.aspx"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ObtenerURLInicioPortal = dtr("URLInicio").ToString
            End While
            dtr.Close()
        Catch
            ObtenerURLInicioPortal = "LoginPampaNorte.aspx"  'Se manda a la página de Login
        End Try
    End Function
    Public Function MenuOptionsUpdateSecuencia(ByVal MenuOptionsId As Long, ByVal Id As Long, ByVal Secuencia As Long, ByVal UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim FuncionesPorPortalId As Long = 0
        Dim SecuenciaGrabada As Long = 0
        Dim MenuOptions As New MenuOptions
        Dim CodigoHTMLCarpetas = ""

        MenuOptionsUpdateSecuencia = "0"


        strUpdate = "UPDATE [montes].[dbo].MenuOptions SET "
        strUpdate = strUpdate & "MenuOptions.Secuencia = " & Secuencia & ", "
        strUpdate = strUpdate & "MenuOptions.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "MenuOptions.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE MenuOptions.MenuOptionsId = " & MenuOptionsId
        Try
            t = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Secuencia de la Opción de Menu " & MenuOptionsId, MenuOptionsId, "MenuOptions", "")
            MenuOptionsUpdateSecuencia = MenuOptions.LoadEditarSubNodos(CodigoHTMLCarpetas, Id, UserId, True, MenuOptionsId)
        Catch
            t = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar la secuencia de la Opción de Menú " & MenuOptionsId, MenuOptionsId, "MenuOptions", "")
        End Try

    End Function
End Class
