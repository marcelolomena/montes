Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports System.IO

Public Class AccesoFiles
    Public Function GrabarArchivoEntidadvb(ByRef NombreArchivo As String, _
                                                ByVal NombreClase As String, _
                                                ByVal NumeroPagina As Long, _
                                                ByVal ServicioLectura As String, _
                                                ByVal ServicioUpdate As String, _
                                                ByVal ServicioDelete As String, _
                                                ByVal CampoId As String, _
                                                ByVal CampoMaestro As String, _
                                                ByVal CampoSecuencia As String, _
                                                ByVal NombreTabla As String) As Boolean

        Dim objStreamWriter As StreamWriter
        Dim arrLabel(51) As String
        Dim arrControl(51) As String
        Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim strUpdate As String = ""


        'Este metodo genera una clase con el nombre de la entidad, por ejemplo Comuna.vb
        'en donde se encuentran los metodos que requieren los controles de usuario generados 
        'en el resto de los métodos de generación



        Try
            NombreArchivo = Path.GetTempFileName
            objStreamWriter = File.CreateText(NombreArchivo)
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            objStreamWriter.WriteLine("' Código generado por ZRISMART SF el " & FormatDateTime(Now()))
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            objStreamWriter.WriteLine("Imports Microsoft.VisualBasic")
            objStreamWriter.WriteLine("Imports System.Data")
            objStreamWriter.WriteLine("Imports System.Data.SqlClient")
            objStreamWriter.WriteLine("Imports System.Data.OleDb")
            objStreamWriter.WriteLine("Imports AjaxControlToolkit")
            objStreamWriter.WriteLine("Imports AccesoEA")
            objStreamWriter.WriteLine("Public Class " & NombreClase)

            ' ----------------------------------------
            ' Generar metodo de lectura de la entidad
            ' ----------------------------------------
            strUpdate = "ByVal " & CampoId & " As Long" & Lecturas.DeclaracionAtributosPorEntidad(NumeroPagina)

            objStreamWriter.WriteLine("Public Function Leer" & NombreClase & "(" & strUpdate & ") As Boolean")
            objStreamWriter.WriteLine("Dim AccesoEA As New AccesoEA")
            objStreamWriter.WriteLine("Dim dtr As IDataReader")
            objStreamWriter.WriteLine("Dim sSQL As String")

            objStreamWriter.WriteLine("sSQL = ""Select " & Lecturas.ListaAtributosPorEntidad(NumeroPagina) & " """)
            objStreamWriter.WriteLine("sSQL = sSQL & ""FROM " & NombreTabla & " """)
            objStreamWriter.WriteLine("sSQL = sSQL & ""WHERE " & NombreTabla & "." & CampoId & " = "" & " & CampoId & " & "" """)

            objStreamWriter.WriteLine("Try")
            objStreamWriter.WriteLine("dtr = AccesoEA.ListarRegistros(sSQL)")

            objStreamWriter.WriteLine("While dtr.Read")
            i = 0
            t = Lecturas.FormarStringBinding(NumeroPagina, arrLabel, i)
            For k = 0 To i - 1
                objStreamWriter.WriteLine(arrLabel(k))
            Next
            objStreamWriter.WriteLine("End While")
            objStreamWriter.WriteLine("Leer" & NombreClase & " = True")
            objStreamWriter.WriteLine("dtr.Close()")
            objStreamWriter.WriteLine("Catch")
            objStreamWriter.WriteLine("Leer" & NombreClase & " = False")
            objStreamWriter.WriteLine("End Try")
            objStreamWriter.WriteLine("End Function")

            ' ----------------------------------------
            ' Generar metodo de update de la entidad
            ' ----------------------------------------

            strUpdate = "ByVal " & CampoId & " As Long" & Lecturas.DeclaracionAtributosPorEntidad(NumeroPagina) & ", ByVal UserId As Long"

            objStreamWriter.WriteLine("Public Function " & NombreClase & "Update(" & strUpdate & ") As Integer")
            objStreamWriter.WriteLine("Dim AccesoEA As New AccesoEA")
            objStreamWriter.WriteLine("Dim strUpdate As String")
            objStreamWriter.WriteLine("Dim AccionesABM As New AccionesABM")
            objStreamWriter.WriteLine("Dim t As Integer = 0")

            i = 0
            t = Lecturas.UpdateAtributosPorEntidad(NumeroPagina, NombreTabla, arrLabel, i)
            For k = 0 To i - 1
                objStreamWriter.WriteLine(arrLabel(k))
            Next
            objStreamWriter.WriteLine("strUpdate = strUpdate & """ & NombreTabla & ".DateLastUpdate = '"" & AccionesABM.DateTransform(Now()) & ""', """)
            objStreamWriter.WriteLine("strUpdate = strUpdate & """ & NombreTabla & ".UserLastUpdate = "" & UserId & "" """)
            objStreamWriter.WriteLine("strUpdate = strUpdate & ""WHERE " & NombreTabla & "." & CampoId & " = "" & " & CampoId)
            objStreamWriter.WriteLine("Try")
            objStreamWriter.WriteLine(NombreClase & "Update = AccesoEA.ABMRegistros(strUpdate)")
            objStreamWriter.WriteLine("t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, ""'"", "" ""), 0, 0, ""Actualiza "" & " & CampoMaestro & ", " & CampoId & ", """ & NombreTabla & """, """")")
            objStreamWriter.WriteLine("Catch")
            objStreamWriter.WriteLine(NombreClase & "Update = 0")
            objStreamWriter.WriteLine("t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, ""'"", "" ""), 0, 0, ""Intento fallido de actualizar el registro de "" & " & CampoMaestro & ", " & CampoId & ", """ & NombreTabla & """, """")")
            objStreamWriter.WriteLine("End Try")
            objStreamWriter.WriteLine("End Function")

            objStreamWriter.WriteLine("End Class")
            objStreamWriter.Close()
            GrabarArchivoEntidadvb = True
        Catch
            GrabarArchivoEntidadvb = False
        End Try
    End Function
    Public Function GrabarArchivoEntidadesascx(ByRef NombreArchivo As String, _
                                                ByVal NombreVista As String) As Boolean
        Dim objStreamWriter As StreamWriter
        Try
            NombreArchivo = Path.GetTempFileName
            Dim pp = Path.GetFileName(NombreArchivo)
            Dim qk = HttpContext.Current.Server.MapPath(".")
            NombreArchivo = qk & "\" & pp
            objStreamWriter = File.CreateText(NombreArchivo)
            objStreamWriter.WriteLine("<%@ Control Language=""VB"" AutoEventWireup=""false"" CodeFile=""" & NombreVista & ".ascx.vb"" Inherits=""" & NombreVista & """ %>")
            objStreamWriter.WriteLine("<! -- Código generado por ZRISMART SF el " & FormatDateTime(Now()) & " -->")
            objStreamWriter.WriteLine("<script type=""text/javascript"">")
            objStreamWriter.WriteLine("function PanelClick(sender, e) {")
            objStreamWriter.WriteLine("}")
            objStreamWriter.WriteLine("function ActiveTabChanged(sender, e) {")
            objStreamWriter.WriteLine("}")
            objStreamWriter.WriteLine("</script>")
            objStreamWriter.WriteLine("<script type=""text/vbscript"" language=""vbscript"">")
            objStreamWriter.WriteLine("Sub RutValidator_ClientValidate(s, e)")
            objStreamWriter.WriteLine("e.IsValid = True")
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("</script>")
            objStreamWriter.WriteLine("<asp:PlaceHolder ID=""MyView"" runat=""server""></asp:PlaceHolder>")
            objStreamWriter.WriteLine("<asp:table id=""MyTabs"" runat=""server"" width=""100%"" cellspacing=""2"" cellpadding=""2"" />")
            objStreamWriter.WriteLine("<asp:PlaceHolder ID=""MyFormulario"" runat=""server""></asp:PlaceHolder>")
            objStreamWriter.Close()
            NombreArchivo = "~/" & pp
            GrabarArchivoEntidadesascx = True
        Catch
            GrabarArchivoEntidadesascx = False
        End Try
    End Function
    Public Function GrabarArchivoEntidadesascxvb(ByRef NombreArchivo As String, _
                                                ByVal NombreVista As String, _
                                                ByVal NumeroPagina As Long, _
                                                ByVal ServicioLectura As String, _
                                                ByVal ServicioUpdate As String, _
                                                ByVal NombreClase As String) As Boolean
        Dim objStreamWriter As StreamWriter
        Dim arrLabel(51) As String
        Dim arrControl(51) As String
        Dim arrDominios(51) As String
        Dim Lecturas As New Lecturas
        Dim FormularioWeb As New FormularioWeb
        Dim t As Boolean = False
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim strUpdate As String = ""

        Try
            NombreArchivo = Path.GetTempFileName
            Dim pp = Path.GetFileName(NombreArchivo)

            Dim qk = HttpContext.Current.Server.MapPath(".")
            NombreArchivo = qk & "\" & pp
            objStreamWriter = File.CreateText(NombreArchivo)
            objStreamWriter.WriteLine("Imports AjaxControlToolkit")
            objStreamWriter.WriteLine("Partial Class " & NombreVista)
            objStreamWriter.WriteLine("Inherits System.Web.UI.UserControl")
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            objStreamWriter.WriteLine("' Código generado por ZRISMART SF el " & FormatDateTime(Now()))
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            objStreamWriter.WriteLine("' Declaración de botones del formulario")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("Dim WithEvents LoginButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents UpdateButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents CancelButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents NewButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents SearchButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents DeleteButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents ReturnButton As Button")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("' Declaración de controles de validación")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("Dim valTextBox As RequiredFieldValidator")
            objStreamWriter.WriteLine("Dim sumValidacion As ValidationSummary")
            objStreamWriter.WriteLine("Dim REValidacion As RegularExpressionValidator")
            objStreamWriter.WriteLine("Dim CuValidacion As CustomValidator")
            objStreamWriter.WriteLine("Dim CoValidacion As CompareValidator")
            objStreamWriter.WriteLine("'------------------------------------------")
            objStreamWriter.WriteLine("' Declaración de Variables de la Aplicación")
            objStreamWriter.WriteLine("'------------------------------------------")
            objStreamWriter.WriteLine("Dim t As Boolean = False")
            objStreamWriter.WriteLine("Dim Logo As String = """"")
            objStreamWriter.WriteLine("Dim BarMenu As String = """"")
            objStreamWriter.WriteLine("Dim SideBarMenu As String = """"")
            objStreamWriter.WriteLine("Dim PaginaWebName As String = """"")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("' Declaración de Controles del Formulario")
            objStreamWriter.WriteLine("'----------------------------------------")
            i = 0
            t = FormularioWeb.LeerDeclaracionControlesFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                objStreamWriter.WriteLine(arrControl(k) & " '" & arrLabel(k))
            Next
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("' Declaración de Campos de la Aplicación")
            objStreamWriter.WriteLine("'----------------------------------------")
            i = 0
            t = FormularioWeb.LeerDeclaracionCamposFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                objStreamWriter.WriteLine(arrControl(k) & " '" & arrLabel(k))
            Next
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click")
            objStreamWriter.WriteLine("'Se pone solo por completitud")
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click")
            objStreamWriter.WriteLine("'Se pone solo por completitud")
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("Protected Sub RFC_Search(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchButton.Click")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim t As Boolean = False")
            objStreamWriter.WriteLine("Dim Pagina As String = """"")
            objStreamWriter.WriteLine("Dim NombrePagina As String = """"")
            objStreamWriter.WriteLine("t = Lecturas.LeerURLStatementFormularioWeb(""URLSearch"", Pagina, NombrePagina, Session(""NumeroPagina""))")
            objStreamWriter.WriteLine("Dim Url As String = Pagina & ""?Pagina="" & Request.QueryString(""Pagina"") & ""&SideBar="" & Request.QueryString(""SideBar"") & ""&PaginaWebName="" & NombrePagina & ""&MenuOptionsId="" & Request.QueryString(""MenuOptionsId"")")
            objStreamWriter.WriteLine("Response.Redirect(Url)")
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim t As Boolean")
            objStreamWriter.WriteLine("Dim Pagina As String = """"")
            objStreamWriter.WriteLine("Dim NombrePagina As String = """"")
            objStreamWriter.WriteLine("t = Lecturas.LeerURLStatementFormularioWeb(""URLNew"", Pagina, NombrePagina, Session(""NumeroPagina""))")
            objStreamWriter.WriteLine("Dim Url As String = Pagina & ""?Pagina="" & Request.QueryString(""Pagina"") & ""&SideBar="" & Request.QueryString(""SideBar"") & ""&PaginaWebName="" & NombrePagina & ""&MenuOptionsId="" & Request.QueryString(""MenuOptionsId"")")
            objStreamWriter.WriteLine("Response.Redirect(Url)")
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click")
            objStreamWriter.WriteLine("'Se pone solo por completitud")
            objStreamWriter.WriteLine("End Sub")

            objStreamWriter.WriteLine("Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim t As Boolean")
            objStreamWriter.WriteLine("Dim Pagina As String = """"")
            objStreamWriter.WriteLine("Dim NombrePagina As String = """"")
            objStreamWriter.WriteLine("t = Lecturas.LeerURLStatementFormularioWeb(""URLUpdate"", Pagina, NombrePagina, Session(""NumeroPagina""))")
            objStreamWriter.WriteLine("Dim Url As String = Pagina & ""?Pagina="" & Request.QueryString(""Pagina"") & ""&SideBar="" & Request.QueryString(""SideBar"") & ""&PaginaWebName="" & NombrePagina & ""&ID="" & Request.QueryString(""Id"") & ""&MenuOptionsId="" & Request.QueryString(""MenuOptionsId"")")
            objStreamWriter.WriteLine("Dim AccionesABM As New AccionesABM")
            objStreamWriter.WriteLine("Dim " & NombreClase & " As New " & NombreClase)
            objStreamWriter.WriteLine("Try")
            strUpdate = "Request.QueryString(""Id""), " & FormularioWeb.FormarStringUpdate(NumeroPagina) & "Session(""PersonaId"")"
            'strUpdate = "t = AccionesABM.FormularioWebUpdate(" & strUpdate & ")"
            strUpdate = "t = " & ServicioUpdate & "(" & strUpdate & ")"
            objStreamWriter.WriteLine(strUpdate)
            objStreamWriter.WriteLine("Catch")
            objStreamWriter.WriteLine("t = 0")
            objStreamWriter.WriteLine("End Try")
            objStreamWriter.WriteLine("Response.Redirect(Url)")
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim " & NombreClase & " As New " & NombreClase)
            objStreamWriter.WriteLine("Dim t As Boolean")
            objStreamWriter.WriteLine("Dim TituloPagina As String = """"")
            objStreamWriter.WriteLine("Dim DescripcionPagina As String = """"")
            objStreamWriter.WriteLine("Dim NumeroPagina As Integer = 0")
            objStreamWriter.WriteLine("Dim GroupValidation As String = """"")
            objStreamWriter.WriteLine("Dim PaginaWebName As String = """"")
            objStreamWriter.WriteLine("Dim sSQLWhere As String = """"")
            objStreamWriter.WriteLine("Dim sSQLOrder As String = """"")
            objStreamWriter.WriteLine("t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString(""MenuOptionsId"")), Logo, BarMenu, SideBarMenu, PaginaWebName)")
            objStreamWriter.WriteLine("t = Lecturas.LeerPaginaWeb(Request.QueryString(""PaginaWebName""), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)")
            objStreamWriter.WriteLine("Session(""NumeroPagina"") = NumeroPagina")
            objStreamWriter.WriteLine("Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)")
            objStreamWriter.WriteLine("AddHandler UpdateButton.Click, AddressOf RFC_Update")
            objStreamWriter.WriteLine("AddHandler NewButton.Click, AddressOf RFC_New")
            objStreamWriter.WriteLine("AddHandler SearchButton.Click, AddressOf RFC_Search")
            'AddHandler DeleteButton.Click, AddressOf RFC_Delete
            strUpdate = "Request.QueryString(""Id"")" & FormularioWeb.FormarStringLeer(NumeroPagina)
            'strUpdate = "If t = Lecturas.LeerFormularioWeb(" & strUpdate & ") Then"
            strUpdate = "If t = " & ServicioLectura & "(" & strUpdate & ") Then"
            objStreamWriter.WriteLine("If Not IsPostBack Then")
            objStreamWriter.WriteLine("If Request.QueryString(""Id"") <> 0 Then")
            objStreamWriter.WriteLine(strUpdate)
            i = 0
            t = FormularioWeb.LeerControlesYCamposFormularioWebKeys(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                strUpdate = arrControl(k) & " = FindControl(""" & arrControl(k) & """)"
                objStreamWriter.WriteLine(strUpdate)
                If Mid(arrControl(k), 1, 3) = "chk" Then
                    strUpdate = arrControl(k) & ".Checked = " & arrLabel(k)
                Else
                    strUpdate = arrControl(k) & ".Text = " & arrLabel(k)
                End If

                objStreamWriter.WriteLine(strUpdate)
            Next
            i = 0
            t = FormularioWeb.LeerControlesYCamposFormularioWebV2(arrLabel, arrControl, arrDominios, NumeroPagina, i)
            For k = 0 To i - 1
                strUpdate = arrControl(k) & " = FindControl(""" & arrControl(k) & """)"
                objStreamWriter.WriteLine(strUpdate)
                If Mid(arrControl(k), 1, 3) = "chk" Then
                    strUpdate = arrControl(k) & ".Checked = " & arrLabel(k)
                Else
                    strUpdate = arrControl(k) & ".Text = " & arrLabel(k)
                    Select Case arrDominios(k)
                        Case "NbEntero"
                            strUpdate = arrControl(k) & ".Text = FormatNumber(" & arrLabel(k) & ",0)"
                        Case "NbDecimales"
                            strUpdate = arrControl(k) & ".Text = FormatNumber(" & arrLabel(k) & "/100,2)"
                        Case "NbMoneda"
                            strUpdate = arrControl(k) & ".Text = FormatCurrency(" & arrLabel(k) & "/100,2)"
                        Case "NbPorcentaje"
                            strUpdate = arrControl(k) & ".Text = FormatPercent(" & arrLabel(k) & "/100,2)"
                    End Select

                End If
                objStreamWriter.WriteLine(strUpdate)
            Next
            'Aquí debo agregar código para invocar el uso de los tabs
            objStreamWriter.WriteLine("' Aquí colocare código para invocar uso de las tabs")
            objStreamWriter.WriteLine("sSQLWhere = """"")
            objStreamWriter.WriteLine("sSQLOrder = """"")
            objStreamWriter.WriteLine("")

            objStreamWriter.WriteLine("Else")
            i = 0
            t = FormularioWeb.LeerControlesYCamposFormularioWebKeys(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                strUpdate = arrControl(k) & " = FindControl(""" & arrControl(k) & """)"
                objStreamWriter.WriteLine(strUpdate)
                strUpdate = arrControl(k) & ".Text = Session(""" & arrLabel(k) & """)"
                objStreamWriter.WriteLine(strUpdate)
            Next
            objStreamWriter.WriteLine("End If")
            objStreamWriter.WriteLine("End If")
            objStreamWriter.WriteLine("Else")
            i = 0
            t = FormularioWeb.LeerControlesYCamposFormularioWebKeys(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                strUpdate = arrControl(k) & " = FindControl(""" & arrControl(k) & """)"
                objStreamWriter.WriteLine(strUpdate)
            Next
            i = 0
            ' Me tinca que aqui debo usar V2, pero no estoy seguro, mantendre tal cual 30-03-2011
            t = FormularioWeb.LeerControlesYCamposFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                strUpdate = arrControl(k) & " = FindControl(""" & arrControl(k) & """)"
                objStreamWriter.WriteLine(strUpdate)
            Next
            objStreamWriter.WriteLine("End If")
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("End Class")
            objStreamWriter.Close()
            NombreArchivo = "~/" & pp
            GrabarArchivoEntidadesascxvb = True
        Catch
            GrabarArchivoEntidadesascxvb = False
        End Try
    End Function
    Public Function GrabarArchivoNewDetailsascx(ByRef NombreArchivo As String, _
                                                ByVal NombreVista As String) As Boolean
        Dim objStreamWriter As StreamWriter
        Try
            NombreArchivo = Path.GetTempFileName
            Dim pp = Path.GetFileName(NombreArchivo)
            Dim qk = HttpContext.Current.Server.MapPath(".")
            NombreArchivo = qk & "\" & pp
            objStreamWriter = File.CreateText(NombreArchivo)
            objStreamWriter.WriteLine("<%@ Control Language=""VB"" AutoEventWireup=""false"" CodeFile=""" & NombreVista & ".ascx.vb"" Inherits=""" & NombreVista & """ %>")
            objStreamWriter.WriteLine("<script type=""text/javascript"">")
            objStreamWriter.WriteLine("function PanelClick(sender, e) {")
            objStreamWriter.WriteLine("}")
            objStreamWriter.WriteLine("function ActiveTabChanged(sender, e) {")
            objStreamWriter.WriteLine("}")
            objStreamWriter.WriteLine("</script>")
            objStreamWriter.WriteLine("<asp:PlaceHolder ID=""MyView"" runat=""server""></asp:PlaceHolder>")
            objStreamWriter.Close()
            NombreArchivo = "~/" & pp
            GrabarArchivoNewDetailsascx = True
        Catch
            GrabarArchivoNewDetailsascx = False
        End Try
    End Function
    Public Function GrabarArchivoNewDetailsascxvb(ByRef NombreArchivo As String, _
                                                ByVal NombreVista As String, _
                                                ByVal NumeroPagina As Long, _
                                                ByVal ServicioLectura As String, _
                                                ByVal ServicioUpdate As String, _
                                                ByVal ServicioDelete As String, _
                                                ByVal CampoId As String, _
                                                ByVal CampoMaestro As String, _
                                                ByVal CampoSecuencia As String, _
                                                ByVal NombreTabla As String, _
                                                ByVal NombreClase As String) As Boolean
        Dim objStreamWriter As StreamWriter
        Dim arrLabel(51) As String
        Dim arrControl(51) As String
        Dim FormularioWeb As New FormularioWeb
        Dim t As Boolean = False
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim strUpdate As String = ""

        Try
            NombreArchivo = Path.GetTempFileName
            Dim pp = Path.GetFileName(NombreArchivo)
            Dim qk = HttpContext.Current.Server.MapPath(".")
            NombreArchivo = qk & "\" & pp
            objStreamWriter = File.CreateText(NombreArchivo)
            objStreamWriter.WriteLine("Imports AjaxControlToolkit")
            objStreamWriter.WriteLine("Partial Class " & NombreVista)
            objStreamWriter.WriteLine("Inherits System.Web.UI.UserControl")
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            objStreamWriter.WriteLine("' Código generado por ZRISMART SF el " & FormatDateTime(Now()))
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            objStreamWriter.WriteLine("' Declaración de botones del formulario")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("Dim WithEvents LoginButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents UpdateButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents CancelButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents NewButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents SearchButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents DeleteButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents ReturnButton As Button")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("' Declaración de controles de validación")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("Dim valTextBox As RequiredFieldValidator")
            objStreamWriter.WriteLine("Dim sumValidacion As ValidationSummary")
            objStreamWriter.WriteLine("Dim REValidacion As RegularExpressionValidator")
            objStreamWriter.WriteLine("Dim CuValidacion As CustomValidator")
            objStreamWriter.WriteLine("Dim CoValidacion As CompareValidator")
            objStreamWriter.WriteLine("'------------------------------------------")
            objStreamWriter.WriteLine("' Declaración de Variables de la Aplicación")
            objStreamWriter.WriteLine("'------------------------------------------")
            objStreamWriter.WriteLine("Dim t As Boolean = False")
            objStreamWriter.WriteLine("Dim Logo As String = """"")
            objStreamWriter.WriteLine("Dim BarMenu As String = """"")
            objStreamWriter.WriteLine("Dim SideBarMenu As String = """"")
            objStreamWriter.WriteLine("Dim PaginaWebName As String = """"")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("' Declaración de Controles del Formulario")
            objStreamWriter.WriteLine("'----------------------------------------")
            i = 0
            t = FormularioWeb.LeerDeclaracionControlesFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                objStreamWriter.WriteLine(arrControl(k) & " '" & arrLabel(k))
            Next
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("' Declaración de Campos de la Aplicación")
            objStreamWriter.WriteLine("'----------------------------------------")
            i = 0
            t = FormularioWeb.LeerDeclaracionCamposFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                objStreamWriter.WriteLine(arrControl(k) & " '" & arrLabel(k))
            Next
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("Protected Sub RFC_Delete(ByVal sender As Object, ByVal e As System.EventArgs) Handles DeleteButton.Click")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim t As Boolean")
            objStreamWriter.WriteLine("Dim Pagina As String = """"")
            objStreamWriter.WriteLine("Dim NombrePagina As String = """"")
            objStreamWriter.WriteLine("t = Lecturas.LeerURLStatementFormularioWeb(""URLDelete"", Pagina, NombrePagina, Session(""NumeroPagina""))")
            objStreamWriter.WriteLine("Dim Url As String = Pagina & ""?Pagina="" & Request.QueryString(""Pagina"") & ""&SideBar="" & Request.QueryString(""SideBar"") & ""&PaginaWebName="" & NombrePagina & ""&MenuOptionsId="" & Request.QueryString(""MenuOptionsId"") & ""&ID="" & Request.QueryString(""MasterId"")")
            objStreamWriter.WriteLine("Dim AccionesABM As New AccionesABM")
            objStreamWriter.WriteLine("Dim " & NombreClase & " As New " & NombreClase)
            objStreamWriter.WriteLine("Try")
            objStreamWriter.WriteLine("t = " & ServicioDelete & "(Session(""Id""), Request.QueryString(""MasterName""), CLng(Session(""PersonaId"")))")
            objStreamWriter.WriteLine("Catch")
            objStreamWriter.WriteLine("t = 0")
            objStreamWriter.WriteLine("End Try")
            objStreamWriter.WriteLine("Response.Redirect(Url)")
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("Protected Sub RFC_Return(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReturnButton.Click")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim t As Boolean")
            objStreamWriter.WriteLine("Dim Pagina As String = """"")
            objStreamWriter.WriteLine("Dim NombrePagina As String = """"")
            objStreamWriter.WriteLine("t = Lecturas.LeerURLStatementFormularioWeb(""URLReturn"", Pagina, NombrePagina, Session(""NumeroPagina""))")
            objStreamWriter.WriteLine("Dim Url As String = Pagina & ""?Pagina="" & Request.QueryString(""Pagina"") & ""&SideBar="" & Request.QueryString(""SideBar"") & ""&PaginaWebName="" & NombrePagina & ""&MenuOptionsId="" & Request.QueryString(""MenuOptionsId"") & ""&ID="" & Request.QueryString(""MasterId"")")
            objStreamWriter.WriteLine("Response.Redirect(Url)")
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("Protected Sub RFC_New(ByVal sender As Object, ByVal e As System.EventArgs) Handles NewButton.Click")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim t As Boolean")
            objStreamWriter.WriteLine("Dim Pagina As String = """"")
            objStreamWriter.WriteLine("Dim NombrePagina As String = """"")
            objStreamWriter.WriteLine("t = Lecturas.LeerURLStatementFormularioWeb(""URLNew"", Pagina, NombrePagina, Session(""NumeroPagina""))")
            objStreamWriter.WriteLine("Dim Url As String = Pagina & ""?Pagina="" & Request.QueryString(""Pagina"") & ""&SideBar="" & Request.QueryString(""SideBar"") & ""&PaginaWebName="" & NombrePagina & ""&ID=0&MenuOptionsId="" & Request.QueryString(""MenuOptionsId"") & ""&MasterName="" & Request.QueryString(""MasterName"") & ""&MasterId="" & Request.QueryString(""MasterId"")")
            objStreamWriter.WriteLine("Response.Redirect(Url)")
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim t As Boolean")
            objStreamWriter.WriteLine("Dim Pagina As String = """"")
            objStreamWriter.WriteLine("Dim NombrePagina As String = """"")
            objStreamWriter.WriteLine("t = Lecturas.LeerURLStatementFormularioWeb(""URLUpdate"", Pagina, NombrePagina, Session(""NumeroPagina""))")
            objStreamWriter.WriteLine("Dim Url As String = Pagina & ""?Pagina="" & Request.QueryString(""Pagina"") & ""&SideBar="" & Request.QueryString(""SideBar"") & ""&PaginaWebName="" & NombrePagina & ""&ID="" & Session(""Id"") & ""&MenuOptionsId="" & Request.QueryString(""MenuOptionsId"") & ""&MasterName="" & Request.QueryString(""MasterName"") & ""&MasterId="" & Request.QueryString(""MasterId"")")
            objStreamWriter.WriteLine("Dim AccionesABM As New AccionesABM")
            objStreamWriter.WriteLine("Dim " & NombreClase & " As New " & NombreClase)
            objStreamWriter.WriteLine("Try")
            strUpdate = "Session(""Id""), " & FormularioWeb.FormarStringUpdate(NumeroPagina) & "Session(""PersonaId"")"
            strUpdate = "t = " & ServicioUpdate & "(" & strUpdate & ")"
            objStreamWriter.WriteLine(strUpdate)
            objStreamWriter.WriteLine("Catch")
            objStreamWriter.WriteLine("t = 0")
            objStreamWriter.WriteLine("End Try")
            objStreamWriter.WriteLine("Response.Redirect(Url)")
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim AccionesABM As New AccionesABM")
            objStreamWriter.WriteLine("Dim " & NombreClase & " As New " & NombreClase)
            objStreamWriter.WriteLine("Dim t As Boolean")
            objStreamWriter.WriteLine("Dim TituloPagina As String = """"")
            objStreamWriter.WriteLine("Dim DescripcionPagina As String = """"")
            objStreamWriter.WriteLine("Dim NumeroPagina As Integer = 0")
            objStreamWriter.WriteLine("Dim GroupValidation As String = """"")
            objStreamWriter.WriteLine("Dim PaginaWebName As String = """"")
            objStreamWriter.WriteLine("Dim DetailId As Long = 0  'Guarda el identity del registro de detalle")
            objStreamWriter.WriteLine("Dim MasterName As String = """" ' Guarda el nombre del Maestro al que pertenece el detalle")
            objStreamWriter.WriteLine("Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle")
            objStreamWriter.WriteLine("t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString(""MenuOptionsId"")), Logo, BarMenu, SideBarMenu, PaginaWebName)")
            objStreamWriter.WriteLine("t = Lecturas.LeerPaginaWeb(Request.QueryString(""PaginaWebName""), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)")
            objStreamWriter.WriteLine("Session(""NumeroPagina"") = NumeroPagina")
            objStreamWriter.WriteLine("Call Lecturas.NuevaCrearFormulario(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyView, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)")
            objStreamWriter.WriteLine("AddHandler UpdateButton.Click, AddressOf RFC_Update")
            objStreamWriter.WriteLine("AddHandler NewButton.Click, AddressOf RFC_New")
            objStreamWriter.WriteLine("AddHandler DeleteButton.Click, AddressOf RFC_Delete")
            objStreamWriter.WriteLine("AddHandler ReturnButton.Click, AddressOf RFC_Return")
            objStreamWriter.WriteLine("Try")
            objStreamWriter.WriteLine("If Not IsPostBack Then")
            objStreamWriter.WriteLine("MasterName = Request.QueryString(""MasterName"")")
            objStreamWriter.WriteLine("Session(""MasterId"") = Request.QueryString(""MasterId"")")
            objStreamWriter.WriteLine("DetailId = Request.QueryString(""Id"")")
            objStreamWriter.WriteLine("If DetailId = 0 Then")
            objStreamWriter.WriteLine("DetailSecuencia = Lecturas.CalcularNextSecuenciaObject(""" & CampoMaestro & """, """ & CampoSecuencia & """, """ & NombreTabla & """, MasterName)")
            objStreamWriter.WriteLine("t = AccionesABM.ObjectPartialInsert(""" & CampoId & """, """ & CampoMaestro & """, """ & CampoSecuencia & """, """ & NombreTabla & """, MasterName, DetailSecuencia, CLng(Session(""PersonaId"")), DetailId)")
            objStreamWriter.WriteLine("End If")
            objStreamWriter.WriteLine("Session(""Id"") = DetailId")
            strUpdate = "Session(""Id"")" & FormularioWeb.FormarStringLeer(NumeroPagina)
            strUpdate = "If t = " & ServicioLectura & "(" & strUpdate & ") Then"
            objStreamWriter.WriteLine(strUpdate)
            i = 0
            t = FormularioWeb.LeerControlesYCamposFormularioWebKeys(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                strUpdate = arrControl(k) & " = FindControl(""" & arrControl(k) & """)"
                objStreamWriter.WriteLine(strUpdate)
                strUpdate = arrControl(k) & ".Text = " & arrLabel(k)
                objStreamWriter.WriteLine(strUpdate)
            Next
            i = 0
            t = FormularioWeb.LeerControlesYCamposFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                strUpdate = arrControl(k) & " = FindControl(""" & arrControl(k) & """)"
                objStreamWriter.WriteLine(strUpdate)
                strUpdate = arrControl(k) & ".Text = " & arrLabel(k)
                objStreamWriter.WriteLine(strUpdate)
            Next
            objStreamWriter.WriteLine("Else")
            i = 0
            t = FormularioWeb.LeerControlesYCamposFormularioWebKeys(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                strUpdate = arrControl(k) & " = FindControl(""" & arrControl(k) & """)"
                objStreamWriter.WriteLine(strUpdate)
                strUpdate = arrControl(k) & ".Text = Session(""" & arrLabel(k) & """)"
                objStreamWriter.WriteLine(strUpdate)
            Next
            objStreamWriter.WriteLine("End If")
            objStreamWriter.WriteLine("Else")
            i = 0
            t = FormularioWeb.LeerControlesYCamposFormularioWebKeys(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                strUpdate = arrControl(k) & " = FindControl(""" & arrControl(k) & """)"
                objStreamWriter.WriteLine(strUpdate)
            Next
            i = 0
            t = FormularioWeb.LeerControlesYCamposFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                strUpdate = arrControl(k) & " = FindControl(""" & arrControl(k) & """)"
                objStreamWriter.WriteLine(strUpdate)
            Next
            objStreamWriter.WriteLine("End If")
            objStreamWriter.WriteLine("Catch")
            objStreamWriter.WriteLine("t = False")
            objStreamWriter.WriteLine("End Try")
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("End Class")
            objStreamWriter.Close()
            NombreArchivo = "~/" & pp
            GrabarArchivoNewDetailsascxvb = True
        Catch
            GrabarArchivoNewDetailsascxvb = False
        End Try
    End Function
    Public Function GrabarArchivoBuscaEntidadesascx(ByRef NombreArchivo As String, _
                                                ByVal NombreVista As String) As Boolean
        Dim objStreamWriter As StreamWriter
        Try
            NombreArchivo = Path.GetTempFileName
            Dim pp = Path.GetFileName(NombreArchivo)

            Dim qk = HttpContext.Current.Server.MapPath(".")
            NombreArchivo = qk & "\" & pp
            objStreamWriter = File.CreateText(NombreArchivo)
            objStreamWriter.WriteLine("<%@ Control Language=""VB"" AutoEventWireup=""false"" CodeFile=""" & NombreVista & ".ascx.vb"" Inherits=""" & NombreVista & """ %>")
            objStreamWriter.WriteLine("<! -- Código generado por ZRISMART SF el " & FormatDateTime(Now()) & " -->")
            objStreamWriter.WriteLine("<asp:table id=""MyTable"" runat=""server"" width=""100%"" cellspacing=""2"" cellpadding=""2"" />")
            objStreamWriter.WriteLine("<asp:Label ID=""lblMensaje"" CssClass=""tab_contenido"" Visible=""false"" runat=""server"" Text=""Label""></asp:Label>")
            objStreamWriter.Close()
            NombreArchivo = "~/" & pp
            GrabarArchivoBuscaEntidadesascx = True
        Catch
            GrabarArchivoBuscaEntidadesascx = False
        End Try
    End Function
    Public Function GrabarArchivoBuscaEntidadesascxvb(ByRef NombreArchivo As String, _
                                                ByVal NombreVista As String, _
                                                ByVal NumeroPagina As Long, _
                                                ByVal NombreFicha As String, _
                                                ByVal CampoId As String, _
                                                ByVal NombreTabla As String, _
                                                ByVal NombreFichaRegistro As String) As Boolean

        Dim objStreamWriter As StreamWriter
        Dim arrLabel(51) As String
        Dim arrControl(51) As String
        Dim arrChkControl(51) As String
        Dim arrTipos(51) As String
        Dim FormularioWeb As New FormularioWeb
        Dim t As Boolean = False
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim strUpdate As String = ""

        Try
            NombreArchivo = Path.GetTempFileName
            Dim pp = Path.GetFileName(NombreArchivo)

            Dim qk = HttpContext.Current.Server.MapPath(".")
            NombreArchivo = qk & "\" & pp
            objStreamWriter = File.CreateText(NombreArchivo)
            objStreamWriter.WriteLine("Imports AjaxControlToolkit")
            objStreamWriter.WriteLine("Partial Class " & NombreVista)
            objStreamWriter.WriteLine("Inherits System.Web.UI.UserControl")
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            objStreamWriter.WriteLine("' Código generado por ZRISMART SF el " & FormatDateTime(Now()))
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            objStreamWriter.WriteLine("' Declaración de botones del formulario")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("Dim WithEvents LoginButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents UpdateButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents CancelButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents NewButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents SearchButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents DeleteButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents ReturnButton As Button")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("' Declaración de controles de validación")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("Dim valTextBox As RequiredFieldValidator")
            objStreamWriter.WriteLine("Dim sumValidacion As ValidationSummary")
            objStreamWriter.WriteLine("Dim REValidacion As RegularExpressionValidator")
            objStreamWriter.WriteLine("Dim CuValidacion As CustomValidator")
            objStreamWriter.WriteLine("Dim CoValidacion As CompareValidator")
            objStreamWriter.WriteLine("'------------------------------------------")
            objStreamWriter.WriteLine("' Declaración de Variables de la Aplicación")
            objStreamWriter.WriteLine("'------------------------------------------")
            objStreamWriter.WriteLine("Dim t As Boolean = False")
            objStreamWriter.WriteLine("Dim Logo As String = """"")
            objStreamWriter.WriteLine("Dim BarMenu As String = """"")
            objStreamWriter.WriteLine("Dim SideBarMenu As String = """"")
            objStreamWriter.WriteLine("Dim PaginaWebName As String = """"")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("' Declaración de Controles del Formulario")
            objStreamWriter.WriteLine("'----------------------------------------")
            i = 0
            t = FormularioWeb.LeerDeclaracionControlesFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                objStreamWriter.WriteLine(arrControl(k) & " '" & arrLabel(k))
            Next

            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("' Declaración de Campos de la Aplicación")
            objStreamWriter.WriteLine("'----------------------------------------")
            i = 0
            t = FormularioWeb.LeerDeclaracionCamposFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                objStreamWriter.WriteLine(arrControl(k) & " '" & arrLabel(k))
            Next
            objStreamWriter.WriteLine("'----------------------------------------------------------------------------------------")
            objStreamWriter.WriteLine("' Declaración de controles de indicador de búsqueda por la variable asociado al checkbox")
            objStreamWriter.WriteLine("'----------------------------------------------------------------------------------------")
            i = 0
            t = FormularioWeb.LeerDeclaracionControlesCheckFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                objStreamWriter.WriteLine(arrControl(k) & " '" & arrLabel(k))
            Next
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("Protected Sub RFC_Update(ByVal sender As Object, ByVal e As System.EventArgs) Handles UpdateButton.Click")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim t As Boolean")
            objStreamWriter.WriteLine("Dim Pagina As String = """"")
            objStreamWriter.WriteLine("Dim NombrePagina As String = """"")
            objStreamWriter.WriteLine("Dim Cantidad As Integer = 0")
            objStreamWriter.WriteLine("Dim Codigo As Long = 0")

            objStreamWriter.WriteLine("t = Lecturas.LeerURLStatementFormularioWeb(""URLUpdate"", Pagina, NombrePagina, Session(""NumeroPagina""))")
            objStreamWriter.WriteLine("Dim Url As String = Pagina & ""?Pagina="" & Request.QueryString(""Pagina"") & ""&SideBar="" & Request.QueryString(""SideBar"") & ""&PaginaWebName="" & NombrePagina & ""&MenuOptionsId="" & Request.QueryString(""MenuOptionsId"")")
            objStreamWriter.WriteLine("Dim sSQLWhere As String = """"")
            objStreamWriter.WriteLine("Dim sSQL As String = """"")
            i = 0
            t = FormularioWeb.LeerCheckFormularioWebV2(arrLabel, arrControl, arrChkControl, arrTipos, NumeroPagina, i)
            For k = 0 To i - 1
                If (arrTipos(k) = "Long" Or arrTipos(k) = "Double" Or arrTipos(k) = "Boolean") Then
                    objStreamWriter.WriteLine("If " & arrChkControl(k) & " = True Then")
                    objStreamWriter.WriteLine("If Len(sSQLWhere) = 0 Then")
                    objStreamWriter.WriteLine("sSQLWhere = "" Where " & arrLabel(k) & " = "" & " & arrControl(k) & " & "" """)
                    objStreamWriter.WriteLine("Else")
                    objStreamWriter.WriteLine("sSQLWhere = sSQLWhere & "" AND " & arrLabel(k) & " = "" & " & arrControl(k) & " & "" """)
                    objStreamWriter.WriteLine("End If")
                    objStreamWriter.WriteLine("End If")
                Else
                    objStreamWriter.WriteLine("If " & arrChkControl(k) & " = True Then")
                    objStreamWriter.WriteLine("If Len(sSQLWhere) = 0 Then")
                    objStreamWriter.WriteLine("sSQLWhere = "" Where " & arrLabel(k) & " = '"" & " & arrControl(k) & " & ""' """)
                    objStreamWriter.WriteLine("Else")
                    objStreamWriter.WriteLine("sSQLWhere = sSQLWhere & "" AND " & arrLabel(k) & " = '"" & " & arrControl(k) & " & ""' """)
                    objStreamWriter.WriteLine("End If")
                    objStreamWriter.WriteLine("End If")
                End If

            Next
            objStreamWriter.WriteLine("If Len(sSQLWhere) > 0 Then")
            objStreamWriter.WriteLine("Url = Url & ""&sSqlWhere="" & sSQLWhere")
            objStreamWriter.WriteLine("End If")
            objStreamWriter.WriteLine("lblMensaje.Visible = ""False""")
            objStreamWriter.WriteLine("sSQL = ""SELECT Count(*) AS Cantidad, Max(" & CampoId & ") AS Codigo FROM " & NombreTabla & """ & sSQLWhere")
            objStreamWriter.WriteLine("t = Lecturas.LeerCantidadComunaBysSQLWhere(sSQL, Cantidad, Codigo)")
            objStreamWriter.WriteLine("If Cantidad > 1 Then")
            objStreamWriter.WriteLine("Response.Redirect(Url)  'Se pasa a la página que muestra la lista de comunas")
            objStreamWriter.WriteLine("Else")
            objStreamWriter.WriteLine("If Cantidad = 1 Then    'Se pasa a la página que muestra la ficha de la única comuna seleccionada")
            objStreamWriter.WriteLine("Url = Pagina & ""?Pagina="" & Request.QueryString(""Pagina"") & ""&SideBar="" & Request.QueryString(""SideBar"") & ""&PaginaWebName=" & NombreFichaRegistro & "&MenuOptionsId="" & Request.QueryString(""MenuOptionsId"") & ""&Id="" & Codigo")
            objStreamWriter.WriteLine("Response.Redirect(Url)")
            objStreamWriter.WriteLine("Else")                    'No hay registros que cumplan con el criterio de selección
            objStreamWriter.WriteLine("lblMensaje.Text = ""No existen registros que cumplan con el criterio de selección""")
            objStreamWriter.WriteLine("lblMensaje.Visible = ""True""")
            objStreamWriter.WriteLine("End If")
            objStreamWriter.WriteLine("End If")
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim t As Boolean")
            objStreamWriter.WriteLine("Dim TituloPagina As String = """"")
            objStreamWriter.WriteLine("Dim DescripcionPagina As String = """"")
            objStreamWriter.WriteLine("Dim NumeroPagina As Integer = 0")
            objStreamWriter.WriteLine("Dim GroupValidation As String = """"")
            objStreamWriter.WriteLine("Dim sSQLWhere As String = """"")
            objStreamWriter.WriteLine("t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString(""MenuOptionsId"")), Logo, BarMenu, SideBarMenu, PaginaWebName)")
            objStreamWriter.WriteLine("t = Lecturas.LeerPaginaWeb(Request.QueryString(""PaginaWebName""), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)")
            objStreamWriter.WriteLine("Session(""NumeroPagina"") = NumeroPagina")
            objStreamWriter.WriteLine("Call Lecturas.CrearFormularioLogin(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyTable, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)")
            objStreamWriter.WriteLine("AddHandler UpdateButton.Click, AddressOf RFC_Update")
            i = 0
            t = FormularioWeb.LeerControlesYCamposFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                strUpdate = arrControl(k) & " = FindControl(""" & arrControl(k) & """)"
                objStreamWriter.WriteLine(strUpdate)
                strUpdate = "chk" & arrControl(k) & " = FindControl(""" & "chk" & arrControl(k) & """)"
                objStreamWriter.WriteLine(strUpdate)
            Next
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("End Class")
            objStreamWriter.Close()
            NombreArchivo = "~/" & pp
            GrabarArchivoBuscaEntidadesascxvb = True
        Catch
            GrabarArchivoBuscaEntidadesascxvb = False
        End Try
    End Function
    Public Function GrabarArchivoValidaEntidadesascx(ByRef NombreArchivo As String, _
                                                ByVal NombreVista As String) As Boolean
        Dim objStreamWriter As StreamWriter
        Try
            NombreArchivo = Path.GetTempFileName
            Dim pp = Path.GetFileName(NombreArchivo)

            Dim qk = HttpContext.Current.Server.MapPath(".")
            NombreArchivo = qk & "\" & pp
            objStreamWriter = File.CreateText(NombreArchivo)
            objStreamWriter.WriteLine("<%@ Control Language=""VB"" AutoEventWireup=""false"" CodeFile=""" & NombreVista & ".ascx.vb"" Inherits=""" & NombreVista & """ %>")
            objStreamWriter.WriteLine("<! -- Código generado por ZRISMART SF el " & FormatDateTime(Now()) & " -->")
            objStreamWriter.WriteLine("<asp:table id=""MyTable"" runat=""server"" width=""100%"" cellspacing=""2"" cellpadding=""2"" />")
            objStreamWriter.Close()
            NombreArchivo = "~/" & pp
            GrabarArchivoValidaEntidadesascx = True
        Catch
            GrabarArchivoValidaEntidadesascx = False
        End Try
    End Function
    Public Function GrabarArchivoValidaEntidadesascxvb(ByRef NombreArchivo As String, _
                                                ByVal NombreVista As String, _
                                                ByVal NumeroPagina As Long, _
                                                ByVal CampoId As String, _
                                                ByVal CampoMaestro As String, _
                                                ByVal NombreTabla As String) As Boolean
        Dim objStreamWriter As StreamWriter
        Dim arrLabel(51) As String
        Dim arrControl(51) As String
        Dim arrChkControl(51) As String
        Dim FormularioWeb As New FormularioWeb
        Dim t As Boolean = False
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim strUpdate As String = ""

        CampoMaestro = CampoName(NombreTabla)

        Try
            NombreArchivo = Path.GetTempFileName
            Dim pp = Path.GetFileName(NombreArchivo)

            Dim qk = HttpContext.Current.Server.MapPath(".")
            NombreArchivo = qk & "\" & pp
            objStreamWriter = File.CreateText(NombreArchivo)
            objStreamWriter.WriteLine("Imports AjaxControlToolkit")
            objStreamWriter.WriteLine("Partial Class " & NombreVista)
            objStreamWriter.WriteLine("Inherits System.Web.UI.UserControl")
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            objStreamWriter.WriteLine("' Código generado por ZRISMART SF el " & FormatDateTime(Now()))
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            objStreamWriter.WriteLine("' Declaración de botones del formulario")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("Dim WithEvents LoginButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents UpdateButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents CancelButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents NewButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents SearchButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents DeleteButton As Button")
            objStreamWriter.WriteLine("Dim WithEvents ReturnButton As Button")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("' Declaración de controles de validación")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("Dim valTextBox As RequiredFieldValidator")
            objStreamWriter.WriteLine("Dim sumValidacion As ValidationSummary")
            objStreamWriter.WriteLine("Dim REValidacion As RegularExpressionValidator")
            objStreamWriter.WriteLine("Dim CuValidacion As CustomValidator")
            objStreamWriter.WriteLine("Dim CoValidacion As CompareValidator")
            objStreamWriter.WriteLine("'------------------------------------------")
            objStreamWriter.WriteLine("' Declaración de Variables de la Aplicación")
            objStreamWriter.WriteLine("'------------------------------------------")
            objStreamWriter.WriteLine("Dim t As Boolean = False")
            objStreamWriter.WriteLine("Dim Logo As String = """"")
            objStreamWriter.WriteLine("Dim BarMenu As String = """"")
            objStreamWriter.WriteLine("Dim SideBarMenu As String = """"")
            objStreamWriter.WriteLine("Dim PaginaWebName As String = """"")
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("' Declaración de Controles del Formulario")
            objStreamWriter.WriteLine("'----------------------------------------")
            i = 0
            t = FormularioWeb.LeerDeclaracionControlesFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                objStreamWriter.WriteLine(arrControl(k) & " '" & arrLabel(k))
            Next

            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("' Declaración de Campos de la Aplicación")
            objStreamWriter.WriteLine("'----------------------------------------")
            i = 0
            t = FormularioWeb.LeerDeclaracionCamposFormularioWeb(arrLabel, arrControl, NumeroPagina, i)
            For k = 0 To i - 1
                objStreamWriter.WriteLine(arrControl(k) & " '" & arrLabel(k))
            Next
            objStreamWriter.WriteLine("'----------------------------------------")
            objStreamWriter.WriteLine("Protected Sub RFC_Login(ByVal sender As Object, ByVal e As System.EventArgs) Handles LoginButton.Click")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim AccionesABM As New AccionesABM")
            objStreamWriter.WriteLine("Dim t As Boolean")
            objStreamWriter.WriteLine("Dim Pagina As String = """"")
            objStreamWriter.WriteLine("Dim NombrePagina As String = """"")
            objStreamWriter.WriteLine("t = Lecturas.LeerURLStatementFormularioWeb(""URLLogin"", Pagina, NombrePagina, Session(""NumeroPagina""))")
            objStreamWriter.WriteLine("Dim MasterId As Long = 0")
            objStreamWriter.WriteLine("Dim MasterName As String = """"")
            objStreamWriter.WriteLine("Dim Url As String = Pagina & ""?Pagina="" & Request.QueryString(""Pagina"") & ""&SideBar="" & Request.QueryString(""SideBar"") & ""&PaginaWebName="" & NombrePagina")
            objStreamWriter.WriteLine("Try")
            objStreamWriter.WriteLine("MasterName = txtMasterName.Text")
            objStreamWriter.WriteLine("MasterId = 0")
            objStreamWriter.WriteLine("t = Lecturas.LeerMasterIdByMasterName(""" & CampoId & """, """ & CampoMaestro & """, """ & NombreTabla & """, MasterName, MasterId)")
            objStreamWriter.WriteLine("If MasterId > 0 Then")
            objStreamWriter.WriteLine("Url = Url & ""&Id="" & MasterId & ""&MenuOptionsId="" & Request.QueryString(""MenuOptionsId"")")
            objStreamWriter.WriteLine("Response.Redirect(Url)")
            objStreamWriter.WriteLine("Else")
            objStreamWriter.WriteLine("t = AccionesABM.MasterPartialInsert(""" & CampoId & """, """ & CampoMaestro & """, """ & NombreTabla & """, MasterName, CLng(Session(""PersonaId"")), MasterId)")
            objStreamWriter.WriteLine("Url = Url & ""&Id="" & MasterId & ""&MenuOptionsId="" & Request.QueryString(""MenuOptionsId"")")
            objStreamWriter.WriteLine("Response.Redirect(Url)")
            objStreamWriter.WriteLine("End If")
            objStreamWriter.WriteLine("Catch")
            objStreamWriter.WriteLine("t = 0")
            objStreamWriter.WriteLine("End Try")
            objStreamWriter.WriteLine("End Sub")
            objStreamWriter.WriteLine("Protected Sub RFC_Logout(ByVal sender As Object, ByVal e As System.EventArgs) Handles CancelButton.Click")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim t As Boolean")
            objStreamWriter.WriteLine("Dim Pagina As String = """"")
            objStreamWriter.WriteLine("Dim NombrePagina As String = """"")
            objStreamWriter.WriteLine("t = Lecturas.LeerURLStatementFormularioWeb(""URLLogout"", Pagina, NombrePagina, Session(""NumeroPagina""))")
            objStreamWriter.WriteLine("Dim Url As String = Pagina & ""?Pagina="" & Request.QueryString(""Pagina"") & ""&SideBar="" & Request.QueryString(""SideBar"") & ""&PaginaWebName="" & NombrePagina & ""&MenuOptionsId="" & Request.QueryString(""MenuOptionsId"")")
            objStreamWriter.WriteLine("Response.Redirect(Url)")
            objStreamWriter.WriteLine("End Sub")

            objStreamWriter.WriteLine("Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim t As Boolean")
            objStreamWriter.WriteLine("Dim TituloPagina As String = """"")
            objStreamWriter.WriteLine("Dim DescripcionPagina As String = """"")
            objStreamWriter.WriteLine("Dim NumeroPagina As Integer = 0")
            objStreamWriter.WriteLine("Dim GroupValidation As String = """"")

            objStreamWriter.WriteLine("t = Lecturas.LeerMenuItemContext(CLng(Request.QueryString(""MenuOptionsId"")), Logo, BarMenu, SideBarMenu, PaginaWebName)")
            objStreamWriter.WriteLine("t = Lecturas.LeerPaginaWeb(Request.QueryString(""PaginaWebName""), TituloPagina, DescripcionPagina, NumeroPagina, GroupValidation)")
            objStreamWriter.WriteLine("Session(""NumeroPagina"") = NumeroPagina")
            objStreamWriter.WriteLine("Call Lecturas.CrearFormularioLogin(NumeroPagina, TituloPagina, DescripcionPagina, GroupValidation, MyTable, sumValidacion, valTextBox, REValidacion, CuValidacion, CoValidacion, LoginButton, CancelButton, UpdateButton, NewButton, SearchButton, DeleteButton, ReturnButton)")
            objStreamWriter.WriteLine("AddHandler LoginButton.Click, AddressOf RFC_Login")
            objStreamWriter.WriteLine("AddHandler CancelButton.Click, AddressOf RFC_Logout")
            objStreamWriter.WriteLine("If IsPostBack Then")
            objStreamWriter.WriteLine("txtMasterName = FindControl(""txtMasterName"")")
            objStreamWriter.WriteLine("End If")

            objStreamWriter.WriteLine("End Sub")

            objStreamWriter.WriteLine("End Class")
            objStreamWriter.Close()
            NombreArchivo = "~/" & pp
            GrabarArchivoValidaEntidadesascxvb = True
        Catch
            GrabarArchivoValidaEntidadesascxvb = False
        End Try
    End Function

    Public Function GrabarArchivoDDL(ByRef NombreArchivo As String, _
                                    ByVal NombreTabla As String) As Boolean

        Dim objStreamWriter As StreamWriter
        Dim sSQL As String = "Select * From " & NombreTabla

        Dim AccesoEA = New AccesoEA
        Dim dtr As IDataReader
        Dim dtrSchema As DataTable
        Dim dtrItem As DataRow
        Dim NombreCampo As String = ""
        Dim TipoDato As String = ""
        Dim Largo As Long = 0
        Dim Secuencia As Long = 0
        Dim Registro As String = ""
        Try
            dtr = AccesoEA.ObtenerSchema(sSQL)
            dtrSchema = dtr.GetSchemaTable()

            NombreArchivo = Path.GetTempFileName
            objStreamWriter = File.CreateText(NombreArchivo)
            objStreamWriter.WriteLine("Documentación de Tablas del Sistema")
            objStreamWriter.WriteLine("Tabla " & NombreTabla)
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            objStreamWriter.WriteLine("' Código generado por ZRISMART SF el " & FormatDateTime(Now()))
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            objStreamWriter.WriteLine("' Lista de Atributos de la Tabla " & NombreTabla)
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            For Each dtrItem In dtrSchema.Rows
                Select Case dtrItem("ProviderType").ToString
                    Case "3"
                        TipoDato = "Long"
                    Case "7"
                        TipoDato = "Date"
                    Case "11"
                        TipoDato = "Boolean"
                    Case "202"
                        TipoDato = "String"
                    Case "203"
                        TipoDato = "String"   'Pero del tipo MEMO
                End Select
                NombreCampo = dtrItem("ColumnName").ToString
                Largo = CLng(dtrItem("ColumnSize").ToString)
                Secuencia = CLng(dtrItem("ColumnOrdinal").ToString)
                Registro = FormatNumber(Secuencia, 0, , , TriState.True) & Space(3)
                Registro &= NombreCampo & Space(35 - Len(NombreCampo))
                Registro &= FormatNumber(Largo, 0, , , TriState.True) & Space(15 - Len(FormatNumber(Largo, 0, , , TriState.True)))
                Registro &= TipoDato

                objStreamWriter.WriteLine(Registro)
            Next

            objStreamWriter.Close()
            GrabarArchivoDDL = True
            dtr.Close()
        Catch
            GrabarArchivoDDL = False
        End Try

    End Function

    Public Function GrabarArchivoEntidadvbV2(ByRef NombreArchivo As String, _
                                                ByVal NombreClase As String, _
                                                ByVal NombreTabla As String, _
                                                ByVal TableType As String) As Boolean

        Dim objStreamWriter As StreamWriter
        Dim arrLabel(401) As String
        Dim arrControl(401) As String
        'Dim Lecturas As New Lecturas
        Dim t As Boolean = False
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim strUpdate As String = ""
        Dim CampoId As String = CampoIdentity(NombreTabla)
        Dim CampoMaestro As String = CampoName(NombreTabla)
        Dim SecuenciaField As String = CampoSecuencia(NombreTabla)

        'Este metodo genera una clase con el nombre de la entidad, por ejemplo Comuna.vb
        'en donde se encuentran los metodos que requieren los controles de usuario generados 
        'en el resto de los métodos de generación



        Try
            NombreArchivo = Path.GetTempFileName
            Dim pp = Path.GetFileName(NombreArchivo)

            Dim qk = HttpContext.Current.Server.MapPath(".")
            NombreArchivo = qk & "\" & pp
            objStreamWriter = File.CreateText(NombreArchivo)
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            objStreamWriter.WriteLine("' Código generado por ZRISMART SF el " & FormatDateTime(Now()))
            objStreamWriter.WriteLine("'------------------------------------------------------------")
            objStreamWriter.WriteLine("Imports Microsoft.VisualBasic")
            objStreamWriter.WriteLine("Imports System.Data")
            objStreamWriter.WriteLine("Imports System.Data.SqlClient")
            objStreamWriter.WriteLine("Imports System.Data.OleDb")
            objStreamWriter.WriteLine("Imports AjaxControlToolkit")
            objStreamWriter.WriteLine("Imports AccesoEA")
            objStreamWriter.WriteLine("Public Class " & NombreClase)

            ' ----------------------------------------
            ' Generar metodo de lectura de la entidad
            ' ----------------------------------------
            strUpdate = "ByVal " & CampoId & " As Long" & DeclaracionAtributosPorEntidad(NombreTabla, CampoId)

            objStreamWriter.WriteLine("Public Function Leer" & NombreClase & "(" & strUpdate & ") As Boolean")
            objStreamWriter.WriteLine("Dim AccesoEA As New AccesoEA")
            objStreamWriter.WriteLine("Dim dtr As IDataReader")
            objStreamWriter.WriteLine("Dim sSQL As String")

            objStreamWriter.WriteLine("sSQL = ""Select " & ListaAtributosPorEntidad(NombreTabla, CampoId) & " """)
            objStreamWriter.WriteLine("sSQL = sSQL & ""FROM " & NombreTabla & " """)
            objStreamWriter.WriteLine("sSQL = sSQL & ""WHERE " & NombreTabla & "." & CampoId & " = "" & " & CampoId & " & "" """)

            objStreamWriter.WriteLine("Try")
            objStreamWriter.WriteLine("dtr = AccesoEA.ListarRegistros(sSQL)")

            objStreamWriter.WriteLine("While dtr.Read")
            i = 0
            t = FormarStringBinding(NombreTabla, arrLabel, i, CampoId)
            For k = 0 To i - 1
                objStreamWriter.WriteLine(arrLabel(k))
            Next
            objStreamWriter.WriteLine("End While")
            objStreamWriter.WriteLine("Leer" & NombreClase & " = True")
            objStreamWriter.WriteLine("dtr.Close()")
            objStreamWriter.WriteLine("Catch")
            objStreamWriter.WriteLine("Leer" & NombreClase & " = False")
            objStreamWriter.WriteLine("End Try")
            objStreamWriter.WriteLine("End Function")

            ' ----------------------------------------------------------------------------------------------
            ' Generar metodo de leer por nombre o clave única de la entidad (Solo para entidad tipo maestra)
            ' ----------------------------------------------------------------------------------------------

            If TableType = "Maestra" Then

                strUpdate = "ByRef " & CampoId & " As Long" & ", ByVal " & CampoMaestro & " As String"

                objStreamWriter.WriteLine("Public Function Leer" & NombreClase & "ByName(" & strUpdate & ") As Boolean")
                objStreamWriter.WriteLine("Dim AccesoEA As New AccesoEA")
                objStreamWriter.WriteLine("Dim dtr As IDataReader")
                objStreamWriter.WriteLine("Dim sSQL As String")

                objStreamWriter.WriteLine("sSQL = ""Select " & CampoId & " """)
                objStreamWriter.WriteLine("sSQL = sSQL & ""FROM (" & NombreTabla & ") """)
                objStreamWriter.WriteLine("sSQL = sSQL & ""WHERE (" & NombreTabla & "." & CampoMaestro & " = '"" & " & CampoMaestro & " & ""') """)

                objStreamWriter.WriteLine("Try")
                objStreamWriter.WriteLine("dtr = AccesoEA.ListarRegistros(sSQL)")

                objStreamWriter.WriteLine("While dtr.Read")
                objStreamWriter.WriteLine(CampoId & " = CLng(dtr(""" & CampoId & """).ToString)")
                'i = 0
                't = FormarStringBinding(NombreTabla, arrLabel, i, CampoId)
                'For k = 0 To i - 1
                'objStreamWriter.WriteLine(arrLabel(k))
                'Next
                objStreamWriter.WriteLine("End While")
                objStreamWriter.WriteLine("Leer" & NombreClase & "ByName = True")
                objStreamWriter.WriteLine("dtr.Close()")
                objStreamWriter.WriteLine("Catch")
                objStreamWriter.WriteLine("Leer" & NombreClase & "ByName = False")
                objStreamWriter.WriteLine("End Try")
                objStreamWriter.WriteLine("End Function")

            End If

            ' ----------------------------------------
            ' Generar metodo de update de la entidad
            ' ----------------------------------------

            strUpdate = "ByVal " & CampoId & " As Long" & DeclaracionAtributosPorEntidad(NombreTabla, CampoId) & ", ByVal UserId As Long"

            objStreamWriter.WriteLine("Public Function " & NombreClase & "Update(" & strUpdate & ") As Integer")
            objStreamWriter.WriteLine("Dim AccesoEA As New AccesoEA")
            objStreamWriter.WriteLine("Dim strUpdate As String")
            objStreamWriter.WriteLine("Dim AccionesABM As New AccionesABM")
            objStreamWriter.WriteLine("Dim t As Integer = 0")

            i = 0
            t = UpdateAtributosPorEntidad(NombreTabla, arrLabel, i, CampoId)
            For k = 0 To i - 1
                objStreamWriter.WriteLine(arrLabel(k))
            Next
            objStreamWriter.WriteLine("strUpdate = strUpdate & """ & NombreTabla & ".DateLastUpdate = '"" & AccionesABM.DateTransform(Now()) & ""', """)
            objStreamWriter.WriteLine("strUpdate = strUpdate & """ & NombreTabla & ".UserLastUpdate = "" & UserId & "" """)
            objStreamWriter.WriteLine("strUpdate = strUpdate & ""WHERE " & NombreTabla & "." & CampoId & " = "" & " & CampoId)
            objStreamWriter.WriteLine("Try")
            objStreamWriter.WriteLine(NombreClase & "Update = AccesoEA.ABMRegistros(strUpdate)")
            objStreamWriter.WriteLine("t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, ""'"", "" ""), 0, 0, ""Actualiza "" & " & CampoMaestro & ", " & CampoId & ", """ & NombreTabla & """, """")")
            objStreamWriter.WriteLine("Catch")
            objStreamWriter.WriteLine(NombreClase & "Update = 0")
            objStreamWriter.WriteLine("t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, ""'"", "" ""), 0, 0, ""Intento fallido de actualizar el registro de "" & " & CampoMaestro & ", " & CampoId & ", """ & NombreTabla & """, """")")
            objStreamWriter.WriteLine("End Try")
            objStreamWriter.WriteLine("End Function")

            ' ----------------------------------------
            ' Generar metodo de insert de la entidad
            ' ----------------------------------------

            strUpdate = "ByRef " & CampoId & " As Long" & DeclaracionAtributosPorEntidad(NombreTabla, CampoId) & ", ByVal UserId As Long"

            objStreamWriter.WriteLine("Public Function " & NombreClase & "Insert(" & strUpdate & ") As Integer")
            objStreamWriter.WriteLine("Dim Lecturas As New Lecturas")
            objStreamWriter.WriteLine("Dim AccionesABM As New AccionesABM")
            objStreamWriter.WriteLine("Dim t As Integer = 0")
            objStreamWriter.WriteLine("Dim " & NombreClase & " As New " & NombreClase)
            objStreamWriter.WriteLine("Dim MasterId As Long = 0")
            objStreamWriter.WriteLine("Dim MasterName As String = """"")
            objStreamWriter.WriteLine("Dim DetailId As Long = 0  'Guarda el identity del registro de detalle")
            objStreamWriter.WriteLine("Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle")
            objStreamWriter.WriteLine("Try")
            objStreamWriter.WriteLine("MasterName = " & CampoMaestro)
            If TableType = "Hija" Then
                objStreamWriter.WriteLine("DetailSecuencia = " & CampoSecuencia(NombreTabla))
                objStreamWriter.WriteLine("DetailId = 0")
                objStreamWriter.WriteLine("t = Lecturas.LeerObjectByNameAndSecuencia(""" & CampoId & """, """ & CampoMaestro & """, """ & CampoSecuencia(NombreTabla) & """, """ & NombreTabla & """, MasterName, DetailSecuencia, DetailId)")
                objStreamWriter.WriteLine("If DetailId = 0 Then")
                objStreamWriter.WriteLine("t = AccionesABM.ObjectPartialInsert(""" & CampoId & """, """ & CampoMaestro & """, """ & CampoSecuencia(NombreTabla) & """, """ & NombreTabla & """, MasterName, DetailSecuencia, UserId, DetailId)")
                objStreamWriter.WriteLine("End If")
                strUpdate = "DetailId, " & FormarStringUpdate(NombreTabla, CampoId) & "UserId"
            Else
                objStreamWriter.WriteLine("MasterId = 0")
                objStreamWriter.WriteLine("t = Lecturas.LeerMasterIdByMasterName(""" & CampoId & """, """ & CampoMaestro & """, """ & NombreTabla & """, MasterName, MasterId)")
                objStreamWriter.WriteLine("If MasterId = 0 Then")  'Significa que el registro existe y solo se actualiza
                objStreamWriter.WriteLine("t = AccionesABM.MasterPartialInsert(""" & CampoId & """, """ & CampoMaestro & """, """ & NombreTabla & """, MasterName, CLng(UserId), MasterId)")
                objStreamWriter.WriteLine("End If")
                strUpdate = "MasterId, " & FormarStringUpdate(NombreTabla, CampoId) & "UserId"
            End If

            strUpdate = NombreClase & "Insert = " & NombreClase & "." & NombreClase & "Update(" & strUpdate & ")"
            objStreamWriter.WriteLine(strUpdate)
            objStreamWriter.WriteLine("Catch")
            objStreamWriter.WriteLine(NombreClase & "Insert = 0")
            objStreamWriter.WriteLine("End Try")


            objStreamWriter.WriteLine("End Function")

            ' ----------------------------------------------------------------------------------------------
            ' Generar metodo delete por clave única de la entidad (Solo para entidad tipo hija)
            ' ----------------------------------------------------------------------------------------------
            If TableType = "Hija" Then

                strUpdate = "ByVal " & CampoId & " As Long" & ", ByVal " & CampoMaestro & " As String" & ", ByVal UserId As Long"

                objStreamWriter.WriteLine("Public Function " & NombreClase & "Delete(" & strUpdate & ") As Integer")
                objStreamWriter.WriteLine("Dim AccesoEA As New AccesoEA")
                objStreamWriter.WriteLine("Dim strUpdate As String")
                objStreamWriter.WriteLine("Dim AccionesABM As New AccionesABM")
                objStreamWriter.WriteLine("Dim t As Integer")

                objStreamWriter.WriteLine("strUpdate = ""Delete """)
                objStreamWriter.WriteLine("strUpdate = strUpdate & ""FROM (" & NombreTabla & ") """)
                objStreamWriter.WriteLine("strUpdate = strUpdate & ""WHERE (" & NombreTabla & "." & CampoId & " = "" & " & CampoId & " & "") """)

                objStreamWriter.WriteLine("Try")
                objStreamWriter.WriteLine(NombreClase & "Delete = AccesoEA.ABMRegistros(strUpdate)")
                objStreamWriter.WriteLine("t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, ""'"", "" ""), 0, 0, ""Elimina API asociada al Proyecto: "" & " & CampoMaestro & ", " & CampoId & ", """ & NombreTabla & """, """")")
                objStreamWriter.WriteLine("Catch")
                objStreamWriter.WriteLine(NombreClase & "Delete = 0")
                objStreamWriter.WriteLine("t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, ""'"", "" ""), 0, 0, ""Intento fallido de eliminar API asociada al proyecto: "" & " & CampoMaestro & ", " & CampoId & ", """ & NombreTabla & """, """")")
                objStreamWriter.WriteLine("End Try")
                objStreamWriter.WriteLine("End Function")

            Else

                '----------------------------------------------------------------------------------------------------------------------
                ' Si la tabla es del tipo Maestra, generamos parte del código, dejando el espacio para que el desarrollador lo complete
                '----------------------------------------------------------------------------------------------------------------------
                ' 24-03-2012 23:10:00
                '--------------------------------------------
                ' Lo primero es validar si tiene tablas hijas
                '--------------------------------------------

                strUpdate = "ByVal " & CampoMaestro & " As String"

                objStreamWriter.WriteLine("Public Function LeerTotal" & NombreClase & "EnTablasRelacionadas(" & strUpdate & ") As Long")
                objStreamWriter.WriteLine("Dim AccesoEA As New AccesoEA")
                objStreamWriter.WriteLine("Dim dtr As IDataReader")
                objStreamWriter.WriteLine("Dim sSQL As string")
                objStreamWriter.WriteLine("' Esta instrucción debe ser completada por el desarrollador, reemplazando XXXXXX por el nombre de la tabla relacionada")
                objStreamWriter.WriteLine("sSQL = ""SELECT Count(*) AS Total """)
                objStreamWriter.WriteLine("sSQL = sSQL & ""FROM " & NombreTabla & " INNER JOIN XXXXXXXXXXX ON " & NombreTabla & "." & CampoMaestro & " = XXXXXXXXXXXX." & CampoMaestro & " """)
                objStreamWriter.WriteLine("sSQL = sSQL & ""WHERE " & NombreTabla & "." & CampoMaestro & " = '"" & " & CampoMaestro & " & ""' """)

                objStreamWriter.WriteLine("LeerTotal" & NombreClase & "EnTablasRelacionadas = 0")
                objStreamWriter.WriteLine("Try")
                objStreamWriter.WriteLine("dtr = AccesoEA.ListarRegistros(sSQL)")
                objStreamWriter.WriteLine("While dtr.Read")
                objStreamWriter.WriteLine("LeerTotal" & NombreClase & "EnTablasRelacionadas = LeerTotal" & NombreClase & "EnTablasRelacionadas + CLng(dtr(""Total"").ToString)")
                objStreamWriter.WriteLine("End While")
                objStreamWriter.WriteLine("dtr.Close()")
                objStreamWriter.WriteLine("Catch")
                objStreamWriter.WriteLine("LeerTotal" & NombreClase & "EnTablasRelacionadas = 0")
                objStreamWriter.WriteLine("End Try")
                objStreamWriter.WriteLine("End Function")

                strUpdate = "ByVal " & CampoId & " As Long" & ", ByVal " & CampoMaestro & " As String" & ", ByVal UserId As Long"

                objStreamWriter.WriteLine("Public Function " & NombreClase & "Delete(" & strUpdate & ") As Integer")
                objStreamWriter.WriteLine("Dim AccesoEA As New AccesoEA")
                objStreamWriter.WriteLine("Dim strUpdate As String = "" """)
                objStreamWriter.WriteLine("Dim AccionesABM As New AccionesABM")
                objStreamWriter.WriteLine("Dim t As Integer")
                objStreamWriter.WriteLine("Dim Total As Long")
                objStreamWriter.WriteLine("Dim Mensaje As String")

                objStreamWriter.WriteLine("Dim " & NombreClase & " As New " & NombreClase)

                objStreamWriter.WriteLine("' Lee la cantidad de veces que el registro es usado en tablas relacionadas")
                '------------------------------------------
                objStreamWriter.WriteLine("Total = " & NombreClase & ".LeerTotal" & NombreClase & "EnTablasRelacionadas(" & CampoMaestro & ")")

                objStreamWriter.WriteLine("If Total > 0 Then")
                objStreamWriter.WriteLine("Mensaje = ""Existen "" & Total & "" de registros en tablas relacionadas con la tabla " & NombreTabla & " "" & vbCrLf")
                objStreamWriter.WriteLine("Mensaje = Mensaje & ""El registro no puede ser eliminado""")
                objStreamWriter.WriteLine(NombreClase & "Delete = False")
                objStreamWriter.WriteLine("Else")
                objStreamWriter.WriteLine("Try")

                objStreamWriter.WriteLine("strUpdate = ""DELETE """)
                objStreamWriter.WriteLine("strUpdate = strUpdate & ""FROM " & NombreTabla & " """)
                objStreamWriter.WriteLine("strUpdate = strUpdate & ""WHERE " & NombreTabla & "." & CampoId & " = "" & " & CampoId)

                objStreamWriter.WriteLine(NombreClase & "Delete = AccesoEA.ABMRegistros(strUpdate)")
                objStreamWriter.WriteLine("t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, ""'"", "" ""), 0, 0, ""Elimina Registro: "" & " & CampoMaestro & ", " & CampoId & ", """ & NombreTabla & """, """")")
                objStreamWriter.WriteLine("Catch")
                objStreamWriter.WriteLine(NombreClase & "Delete = 0")
                objStreamWriter.WriteLine("t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, ""'"", "" ""), 0, 0, ""Intento fallido de eliminar Registro: "" & " & CampoMaestro & ", " & CampoId & ", """ & NombreTabla & """, """")")
                objStreamWriter.WriteLine("End Try")
                objStreamWriter.WriteLine("End If")
                objStreamWriter.WriteLine("End Function")
            End If

            objStreamWriter.WriteLine("End Class")
            objStreamWriter.Close()
            GrabarArchivoEntidadvbV2 = True
            NombreArchivo = "~/" & pp
        Catch
            GrabarArchivoEntidadvbV2 = False
        End Try
    End Function
    Public Function DeclaracionAtributosPorEntidad(ByRef NombreTabla As String, ByVal CampoId As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String = "Select * From " & NombreTabla
        Dim dtrSchema As DataTable
        Dim dtrItem As DataRow
        Dim NombreCampo As String = ""
        Dim TipoDato As String = ""

        DeclaracionAtributosPorEntidad = ""
        Try
            dtr = AccesoEA.ObtenerSchema(sSQL)
            dtrSchema = dtr.GetSchemaTable()


            For Each dtrItem In dtrSchema.Rows
                Select Case dtrItem("ProviderType").ToString
                    Case "3"
                        TipoDato = "Long"
                    Case "7"
                        TipoDato = "Date"
                    Case "11"
                        TipoDato = "Boolean"
                    Case "202"
                        TipoDato = "String"
                    Case "203"
                        TipoDato = "String"   'Pero del tipo MEMO
                        'Se agrega el 09-02-2011, para manejar datos del tipo double
                    Case "5"
                        TipoDato = "Double"
                End Select

                NombreCampo = dtrItem("ColumnName").ToString
                If NombreCampo <> CampoId And NombreCampo <> "DateLastUpdate" And NombreCampo <> "UserLastUpdate" Then
                    DeclaracionAtributosPorEntidad &= ", ByRef " & NombreCampo & " As " & TipoDato
                End If
            Next
            dtr.Close()
        Catch
            DeclaracionAtributosPorEntidad = ""
        End Try

    End Function
    Public Function ListaAtributosPorEntidad(ByRef NombreTabla As String, ByVal CampoId As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String = "Select * From " & NombreTabla
        Dim dtrSchema As DataTable
        Dim dtrItem As DataRow
        Dim NombreCampo As String = ""
        Dim TipoDato As String = ""
        Dim i As Integer = 0

        ListaAtributosPorEntidad = ""

        Try
            dtr = AccesoEA.ObtenerSchema(sSQL)
            dtrSchema = dtr.GetSchemaTable()
            For Each dtrItem In dtrSchema.Rows
                NombreCampo = dtrItem("ColumnName").ToString
                If NombreCampo <> CampoId And NombreCampo <> "DateLastUpdate" And NombreCampo <> "UserLastUpdate" Then
                    ListaAtributosPorEntidad &= NombreCampo & ", "
                    i = i + 1
                End If
            Next
            ListaAtributosPorEntidad = Mid(ListaAtributosPorEntidad, 1, Len(ListaAtributosPorEntidad) - 2)
            dtr.Close()
        Catch
            ListaAtributosPorEntidad = ""
        End Try
    End Function
    Public Function CampoIdentity(ByRef NombreTabla As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String = "Select * From " & NombreTabla
        Dim dtrSchema As DataTable
        Dim dtrItem As DataRow
        Dim NombreCampo As String = ""
        Dim TipoDato As String = ""

        CampoIdentity = ""
        Try
            dtr = AccesoEA.ObtenerSchema(sSQL)
            dtrSchema = dtr.GetSchemaTable()
            dtrItem = dtrSchema.Rows(0)
            CampoIdentity = dtrItem("ColumnName").ToString
            dtr.Close()
        Catch
            CampoIdentity = ""
        End Try
    End Function
    Public Function FormarStringBinding(ByVal NombreTabla As String, ByRef arrBinding() As String, ByRef i As Integer, ByVal CampoId As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String = "Select * From " & NombreTabla
        Dim dtrSchema As DataTable
        Dim dtrItem As DataRow
        Dim NombreCampo As String = ""
        Dim TipoDato As String = ""

        Try
            dtr = AccesoEA.ObtenerSchema(sSQL)
            dtrSchema = dtr.GetSchemaTable()

            i = 0
            For Each dtrItem In dtrSchema.Rows
                Select Case dtrItem("ProviderType").ToString
                    Case "3"
                        TipoDato = "Long"
                    Case "7"
                        TipoDato = "Date"
                    Case "11"
                        TipoDato = "Boolean"
                    Case "202"
                        TipoDato = "String"
                    Case "203"
                        TipoDato = "String"   'Pero del tipo MEMO
                        'Se agrega el 09-02-2011, para manejar datos del tipo double
                    Case "5"
                        TipoDato = "Double"
                End Select
                NombreCampo = dtrItem("ColumnName").ToString
                If NombreCampo <> CampoId And NombreCampo <> "DateLastUpdate" And NombreCampo <> "UserLastUpdate" Then
                    Select Case TipoDato
                        Case "String"
                            arrBinding(i) = NombreCampo & " = " & "CStr(dtr(""" & NombreCampo & """).ToString)"
                        Case "Long"
                            ' Corrección del día 16-11-2010
                            arrBinding(i) = "If Len(dtr(""" & NombreCampo & """).ToString) = 0 Then"
                            i = i + 1
                            arrBinding(i) = NombreCampo & " = 0"
                            i = i + 1
                            arrBinding(i) = "Else"
                            i = i + 1
                            arrBinding(i) = NombreCampo & " = CLng(dtr(""" & NombreCampo & """).ToString)"
                            i = i + 1
                            arrBinding(i) = "End If"
                            'arrBinding(i) = NombreCampo & " = " & "CLng(dtr(""" & NombreCampo & """).ToString)"
                        Case "Double"
                            ' Corrección del día 09-02-2011
                            arrBinding(i) = "If Len(dtr(""" & NombreCampo & """).ToString) = 0 Then"
                            i = i + 1
                            arrBinding(i) = NombreCampo & " = 0"
                            i = i + 1
                            arrBinding(i) = "Else"
                            i = i + 1
                            arrBinding(i) = NombreCampo & " = CDbl(dtr(""" & NombreCampo & """).ToString)"
                            i = i + 1
                            arrBinding(i) = "End If"
                            'arrBinding(i) = NombreCampo & " = " & "CLng(dtr(""" & NombreCampo & """).ToString)"
                        Case "Date"
                            ' Corrección del día 01-12-2010, aplicando lo mismo de Long pero a Date
                            arrBinding(i) = "If Len(dtr(""" & NombreCampo & """).ToString) = 0 Then"
                            i = i + 1
                            arrBinding(i) = NombreCampo & " = ""01/01/01"""
                            i = i + 1
                            arrBinding(i) = "Else"
                            i = i + 1
                            arrBinding(i) = NombreCampo & " = " & "CDate(dtr(""" & NombreCampo & """).ToString)"
                            i = i + 1
                            arrBinding(i) = "End If"

                            'arrBinding(i) = NombreCampo & " = " & "CDate(dtr(""" & NombreCampo & """).ToString)"
                        Case "Boolean"
                            arrBinding(i) = NombreCampo & " = " & "CBool(dtr(""" & NombreCampo & """).ToString)"
                    End Select
                    i = i + 1
                End If

            Next
            dtr.Close()
            FormarStringBinding = True
        Catch
            FormarStringBinding = False
        End Try

    End Function
    Public Function UpdateAtributosPorEntidad(ByVal NombreTabla As String, _
                                              ByRef arrLabel() As String, _
                                              ByRef i As Integer, _
                                              ByVal CampoId As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String = "Select * From " & NombreTabla
        Dim dtrSchema As DataTable
        Dim dtrItem As DataRow
        Dim NombreCampo As String = ""
        Dim TipoDato As String = ""

        i = 0
        arrLabel(i) = "strUpdate = ""UPDATE " & NombreTabla & " SET """
        i = i + 1

        Try
            dtr = AccesoEA.ObtenerSchema(sSQL)
            dtrSchema = dtr.GetSchemaTable()

            For Each dtrItem In dtrSchema.Rows
                Select Case dtrItem("ProviderType").ToString
                    Case "3"
                        TipoDato = "Long"
                    Case "7"
                        TipoDato = "Date"
                    Case "11"
                        TipoDato = "Boolean"
                    Case "202"
                        TipoDato = "String"
                    Case "203"
                        TipoDato = "String"   'Pero del tipo MEMO
                        'Se agrega el 09-02-2011 para manejar el tipo de dato Double
                    Case "5"
                        TipoDato = "Double"
                End Select
                NombreCampo = dtrItem("ColumnName").ToString
                If NombreCampo <> CampoId And NombreCampo <> "DateLastUpdate" And NombreCampo <> "UserLastUpdate" Then
                    Select Case TipoDato
                        Case "String"
                            arrLabel(i) = "strUpdate = strUpdate & """ & NombreTabla & "." & NombreCampo & " = '"" & " & NombreCampo & " & ""', """
                        Case "Long"
                            arrLabel(i) = "strUpdate = strUpdate & """ & NombreTabla & "." & NombreCampo & " = "" & " & NombreCampo & " & "", """
                        Case "Date"
                            arrLabel(i) = "strUpdate = strUpdate & """ & NombreTabla & "." & NombreCampo & " = '"" & AccionesABM.DateTransform(" & NombreCampo & ") & ""', """
                        Case "Boolean"
                            arrLabel(i) = "strUpdate = strUpdate & """ & NombreTabla & "." & NombreCampo & " = "" & " & NombreCampo & " & "", """
                        Case "Double"
                            arrLabel(i) = "strUpdate = strUpdate & """ & NombreTabla & "." & NombreCampo & " = "" & " & NombreCampo & " & "", """

                    End Select
                    i = i + 1
                End If

            Next
            dtr.Close()
            UpdateAtributosPorEntidad = True
        Catch
            UpdateAtributosPorEntidad = False
        End Try
    End Function
    Public Function CampoName(ByRef NombreTabla As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String = "Select * From " & NombreTabla
        Dim dtrSchema As DataTable
        Dim dtrItem As DataRow
        Dim NombreCampo As String = ""
        Dim TipoDato As String = ""

        CampoName = ""
        Try
            dtr = AccesoEA.ObtenerSchema(sSQL)
            dtrSchema = dtr.GetSchemaTable()
            dtrItem = dtrSchema.Rows(1)
            CampoName = dtrItem("ColumnName").ToString
            dtr.Close()
        Catch
            CampoName = ""
        End Try
    End Function
    Public Function CampoSecuencia(ByRef NombreTabla As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String = "Select * From " & NombreTabla
        Dim dtrSchema As DataTable
        Dim dtrItem As DataRow
        Dim NombreCampo As String = ""
        Dim TipoDato As String = ""

        CampoSecuencia = ""
        Try
            dtr = AccesoEA.ObtenerSchema(sSQL)
            dtrSchema = dtr.GetSchemaTable()
            dtrItem = dtrSchema.Rows(2)
            CampoSecuencia = dtrItem("ColumnName").ToString
            dtr.Close()
        Catch
            CampoSecuencia = ""
        End Try
    End Function
    Public Function InsertAtributosPorEntidad(ByVal NombreTabla As String, _
                                              ByRef arrLabel() As String, _
                                              ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String = "Select * From " & NombreTabla
        Dim dtrSchema As DataTable
        Dim dtrItem As DataRow
        Dim NombreCampo As String = ""
        Dim TipoDato As String = ""

        i = 0
        arrLabel(i) = "strUpdate = ""UPDATE " & NombreTabla & " SET """
        i = i + 1

        Try
            dtr = AccesoEA.ObtenerSchema(sSQL)
            dtrSchema = dtr.GetSchemaTable()

            For Each dtrItem In dtrSchema.Rows
                Select Case dtrItem("ProviderType").ToString
                    Case "3"
                        TipoDato = "Long"
                    Case "7"
                        TipoDato = "Date"
                    Case "11"
                        TipoDato = "Boolean"
                    Case "202"
                        TipoDato = "String"
                    Case "203"
                        TipoDato = "String"   'Pero del tipo MEMO
                End Select
                NombreCampo = dtrItem("ColumnName").ToString
                If NombreCampo <> NombreTabla & "Id" And NombreCampo <> "DateLastUpdate" And NombreCampo <> "UserLastUpdate" Then
                    Select Case TipoDato
                        Case "String"
                            arrLabel(i) = "strUpdate = strUpdate & """ & NombreTabla & "." & NombreCampo & " = '"" & " & NombreCampo & " & ""', """
                        Case "Long"
                            arrLabel(i) = "strUpdate = strUpdate & """ & NombreTabla & "." & NombreCampo & " = "" & " & NombreCampo & " & "", """
                        Case "Date"
                            arrLabel(i) = "strUpdate = strUpdate & """ & NombreTabla & "." & NombreCampo & " = '"" & DateTransform(" & NombreCampo & ") & ""', """
                        Case "Boolean"
                            arrLabel(i) = "strUpdate = strUpdate & """ & NombreTabla & "." & NombreCampo & " = "" & " & NombreCampo & " & "", """

                    End Select
                    i = i + 1
                End If

            Next
            dtr.Close()
            InsertAtributosPorEntidad = True
        Catch
            InsertAtributosPorEntidad = False
        End Try
    End Function
    Public Function FormarStringUpdate(ByRef NombreTabla As String, ByVal CampoId As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String = "Select * From " & NombreTabla
        Dim dtrSchema As DataTable
        Dim dtrItem As DataRow
        Dim NombreCampo As String = ""
        Dim TipoDato As String = ""
        Dim StringUpdate As String = ""

        Try
            dtr = AccesoEA.ObtenerSchema(sSQL)
            dtrSchema = dtr.GetSchemaTable()

            For Each dtrItem In dtrSchema.Rows
                Select Case dtrItem("ProviderType").ToString
                    Case "3"
                        TipoDato = "Long"
                    Case "7"
                        TipoDato = "Date"
                    Case "11"
                        TipoDato = "Boolean"
                    Case "202"
                        TipoDato = "String"
                    Case "203"
                        TipoDato = "String"   'Pero del tipo MEMO
                        'Se agrega el 09-02-2011 para manejar el TipoDato Double
                    Case "5"
                        TipoDato = "Double"
                End Select
                NombreCampo = dtrItem("ColumnName").ToString
                If NombreCampo <> CampoId And NombreCampo <> "DateLastUpdate" And NombreCampo <> "UserLastUpdate" Then
                    Select Case TipoDato
                        Case "String"
                            StringUpdate = StringUpdate & "CStr(" & NombreCampo & "), "
                        Case "Long"
                            StringUpdate = StringUpdate & "CLng(" & NombreCampo & "), "
                        Case "Date"
                            StringUpdate = StringUpdate & "CDate(" & NombreCampo & "), "
                        Case "Boolean"
                            StringUpdate = StringUpdate & "CBool(" & NombreCampo & "), "
                            ' Se agrega el 09-2-02-2011 para manejar el tipo de dato Double    
                        Case "Double"
                            StringUpdate = StringUpdate & "CDbl(" & NombreCampo & "), "

                    End Select
                End If

            Next
            dtr.Close()
            FormarStringUpdate = StringUpdate
        Catch
            FormarStringUpdate = ""
        End Try

    End Function

    Public Function CrearEntidadNegocio(ByVal NombreTabla As String, _
                                        ByVal NombreEntidad As String, _
                                        ByVal Tipo As String, _
                                        ByVal NombreClase As String, _
                                        ByVal NombreTablaPadre As String, _
                                        ByVal UserId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String = "Select * From " & NombreTabla
        Dim dtrSchema As DataTable
        Dim dtrItem As DataRow
        Dim i As Integer = 0
        Dim j As Integer = 0

        Dim Entidad As New Entidad
        Dim AttrEntidad As New AttrEntidad
        Dim t As Integer
        ' Definición de datos de la tabla Entidad
        Dim EntidadId As Long
        Dim EntidadNombreTabla As String
        Dim EntidadNombreEntidad As String
        Dim EntidadDescription As String
        Dim EntidadTipo As String
        Dim EntidadCampoId As String
        Dim EntidadCampoName As String
        Dim EntidadCampoSecuencia As String
        Dim EntidadNombreTablaPadre As String
        Dim EntidadMasterId As String
        Dim EntidadMasterName As String
        Dim EntidadNombreClase As String
        Dim EntidadServicioLectura As String
        Dim EntidadServicioUpdate As String
        Dim EntidadServicioInsert As String
        Dim EntidadVistaMantener As String
        Dim EntidadVistaBuscar As String
        Dim EntidadVistaValidar As String
        Dim EntidadVistaListar As String
        ' Definicio de datos de la tabla AttrEntidad
        Dim AttrEntidadId As Long
        'Dim EntidadNombreTabla As String
        Dim AttrEntidadSecuencia As Long
        Dim AttrEntidadColumnName As String
        Dim AttrEntidadColumnDescription As String
        Dim AttrEntidadColumnOrdinal As Long
        Dim AttrEntidadColumnDataType As String
        Dim AttrEntidadColumnSize As Long
        Dim AttrEntidadIsRequerido As Boolean
        Dim AttrEntidadDomainField As String
        Dim AttrEntidadIsForeignKey As Boolean
        Dim AttrEntidadForeignTable As String
        Dim AttrEntidadForeignSQL As String
        Dim AttrEntidadColumnLabel As String
        Dim AttrEntidadColumnControlName As String
        Dim AttrEntidadColumnControlBase As String
        Dim AttrEntidadColumnTipoControl As String
        Dim AttrEntidadColumnControlWidth As String
        Dim AttrEntidadColumnTextMode As Long
        Dim AttrEntidadColumnToolTip As String
        Dim AttrEntidadIsFilterField As Boolean
        Dim AttrEntidadIsColumnField As Boolean
        Dim AttrEntidadColumnNumber As Long
        Dim AttrEntidadColumnHeader As String
        Dim AttrEntidadIsInVistaValidar As Boolean
        Dim AttrEntidadIsEnabledInVistaMantener As Boolean
        Dim AttrEntidadIsFormKeys As Boolean
        Dim AttrEntidadIsAutocomplete As Boolean
        Dim AttrEntidadAutocompleteMethod As String
        Dim AttrEntidadColumnGroupNumber As Long
        Dim AttrEntidadColumnGroupOrdinal As Long
        Dim AttrEntidadColumnGroupName As String


        'Este metodo genera un registro en la tabla Entidad y los registros que correspondan en la 
        'tabla AttrEntidad a para de la metadata de la tabla indicada por el usuario.

        '---------------------------------------------------------------------------------------------
        '       Inserta registro en la tabla Entidad
        '---------------------------------------------------------------------------------------------

        ' Prepara Datos para hacer la inserción del registro en la tabla Entidad.

        EntidadNombreTabla = NombreTabla
        EntidadNombreEntidad = NombreEntidad
        EntidadDescription = NombreEntidad
        EntidadTipo = Tipo
        EntidadCampoId = CampoIdentity(NombreTabla)
        EntidadCampoName = CampoName(NombreTabla)
        EntidadCampoSecuencia = ""
        If Tipo = "Hija" Then
            EntidadCampoSecuencia = CampoSecuencia(NombreTabla)
            EntidadNombreTablaPadre = NombreTablaPadre
            EntidadMasterId = CampoIdentity(NombreTablaPadre)
            EntidadMasterName = CampoName(NombreTablaPadre)
        Else
            EntidadCampoSecuencia = ""
            EntidadNombreTablaPadre = ""
            EntidadMasterId = ""
            EntidadMasterName = ""
        End If
        EntidadNombreClase = NombreClase
        EntidadServicioLectura = NombreClase & ".Leer" & NombreClase
        EntidadServicioUpdate = NombreClase & "." & NombreClase & "Update"
        EntidadServicioInsert = NombreClase & "." & NombreClase & "Update"
        EntidadVistaMantener = "Ficha de " & NombreClase
        EntidadVistaBuscar = "Busca " & NombreClase
        EntidadVistaValidar = "Valida " & NombreClase
        EntidadVistaListar = "Lista de " & NombreClase

        Try
            t = Entidad.EntidadInsert(EntidadId, EntidadNombreTabla, EntidadNombreEntidad, EntidadDescription, EntidadTipo, EntidadCampoId, EntidadCampoName, EntidadCampoSecuencia, EntidadNombreTablaPadre, EntidadMasterId, EntidadMasterName, EntidadNombreClase, EntidadServicioLectura, EntidadServicioUpdate, EntidadServicioInsert, EntidadVistaMantener, EntidadVistaBuscar, EntidadVistaValidar, EntidadVistaListar, UserId)

            dtr = AccesoEA.ObtenerSchema(sSQL)
            dtrSchema = dtr.GetSchemaTable()

            For Each dtrItem In dtrSchema.Rows
                AttrEntidadColumnName = dtrItem("ColumnName").ToString
                AttrEntidadColumnDataType = ""
                AttrEntidadColumnControlName = ""
                AttrEntidadColumnControlBase = ""
                AttrEntidadColumnTipoControl = ""
                AttrEntidadColumnControlWidth = ""
                AttrEntidadColumnGroupName = ""
                Select Case dtrItem("ProviderType").ToString
                    Case "3"
                        AttrEntidadColumnDataType = "Long"
                        AttrEntidadColumnControlName = "txt" & AttrEntidadColumnName
                        AttrEntidadColumnControlBase = "TextBox"
                        AttrEntidadColumnTipoControl = "TextBox"
                        AttrEntidadColumnControlWidth = "100px"
                        AttrEntidadColumnTextMode = "0"
                    Case "7"
                        AttrEntidadColumnDataType = "Date"
                        AttrEntidadColumnControlName = "txt" & AttrEntidadColumnName
                        AttrEntidadColumnControlBase = "TextBox"
                        AttrEntidadColumnTipoControl = "TextBoxCalendar"
                        AttrEntidadColumnControlWidth = "70px"
                        AttrEntidadColumnTextMode = "0"
                    Case "11"
                        AttrEntidadColumnDataType = "Boolean"
                        AttrEntidadColumnControlName = "chk" & AttrEntidadColumnName
                        AttrEntidadColumnControlBase = "CheckBox"
                        AttrEntidadColumnTipoControl = "CheckBox"
                        AttrEntidadColumnControlWidth = "50px"
                        AttrEntidadColumnTextMode = "0"
                    Case "202"
                        AttrEntidadColumnDataType = "String"
                        AttrEntidadColumnControlName = "txt" & AttrEntidadColumnName
                        AttrEntidadColumnControlBase = "Textbox"
                        AttrEntidadColumnTipoControl = "TextBox"
                        AttrEntidadColumnControlWidth = "500px"
                        AttrEntidadColumnTextMode = "0"
                    Case "203"
                        AttrEntidadColumnDataType = "String"   'Pero del tipo MEMO
                        AttrEntidadColumnControlName = "txt" & AttrEntidadColumnName
                        AttrEntidadColumnControlBase = "Textbox"
                        AttrEntidadColumnTipoControl = "TextBox"
                        AttrEntidadColumnControlWidth = "500px"
                        AttrEntidadColumnTextMode = "1"
                    Case "5"  'se crea el 09-02-2011 para manejar el tipo de dato double
                        AttrEntidadColumnDataType = "Double"
                        AttrEntidadColumnControlName = "txt" & AttrEntidadColumnName
                        AttrEntidadColumnControlBase = "TextBox"
                        AttrEntidadColumnTipoControl = "TextBox"
                        AttrEntidadColumnControlWidth = "150px"
                        AttrEntidadColumnTextMode = "0"
                End Select

                If AttrEntidadColumnName <> CampoIdentity(NombreTabla) And AttrEntidadColumnName <> "DateLastUpdate" And AttrEntidadColumnName <> "UserLastUpdate" Then

                    ' Prepara Datos para hacer la inserción del registro en la tabla AttrEntidades.

                    AttrEntidadSecuencia = CLng(dtrItem("ColumnOrdinal").ToString)
                    AttrEntidadColumnName = dtrItem("ColumnName").ToString
                    AttrEntidadColumnDescription = ""
                    AttrEntidadColumnOrdinal = CLng(dtrItem("ColumnOrdinal").ToString)
                    AttrEntidadColumnSize = CLng(dtrItem("ColumnSize").ToString)
                    AttrEntidadIsRequerido = False
                    AttrEntidadDomainField = ""
                    AttrEntidadIsForeignKey = False
                    AttrEntidadForeignTable = ""
                    AttrEntidadForeignSQL = ""
                    AttrEntidadColumnLabel = AttrEntidadColumnName
                    AttrEntidadColumnToolTip = AttrEntidadColumnName
                    AttrEntidadIsFilterField = False
                    AttrEntidadIsColumnField = False
                    AttrEntidadColumnNumber = 0
                    AttrEntidadColumnHeader = ""
                    If Tipo = "Maestra" Then
                        If (AttrEntidadColumnName = CampoName(NombreTabla)) Then
                            AttrEntidadIsInVistaValidar = True
                            AttrEntidadIsEnabledInVistaMantener = False
                            AttrEntidadIsFormKeys = True
                            AttrEntidadColumnGroupNumber = 0
                            j = j + 1
                            AttrEntidadColumnGroupOrdinal = j
                            AttrEntidadColumnGroupName = "FormKeys de " & NombreEntidad
                        Else
                            AttrEntidadIsInVistaValidar = False
                            AttrEntidadIsEnabledInVistaMantener = True
                            AttrEntidadIsFormKeys = False
                            AttrEntidadColumnGroupNumber = 1
                            i = i + 1
                            AttrEntidadColumnGroupOrdinal = i
                            AttrEntidadColumnGroupName = "Atributos de " & NombreEntidad
                        End If
                    ElseIf Tipo = "Hija" Then
                        If (AttrEntidadColumnName = CampoName(NombreTabla) Or AttrEntidadColumnName = CampoSecuencia(NombreTabla)) Then
                            AttrEntidadIsInVistaValidar = True
                            AttrEntidadIsEnabledInVistaMantener = False
                            AttrEntidadIsFormKeys = True
                            AttrEntidadColumnGroupNumber = 0
                            j = j + 1
                            AttrEntidadColumnGroupOrdinal = j
                            AttrEntidadColumnGroupName = "FormKeys de " & NombreEntidad
                        Else
                            AttrEntidadIsInVistaValidar = False
                            AttrEntidadIsEnabledInVistaMantener = True
                            AttrEntidadIsFormKeys = False
                            AttrEntidadColumnGroupNumber = 1
                            i = i + 1
                            AttrEntidadColumnGroupOrdinal = i
                            AttrEntidadColumnGroupName = "Atributos de " & NombreEntidad
                        End If

                    End If
                    AttrEntidadIsAutocomplete = False
                    AttrEntidadAutocompleteMethod = ""


                    t = AttrEntidad.AttrEntidadInsert(AttrEntidadId, EntidadNombreTabla, AttrEntidadSecuencia, _
                                                      AttrEntidadColumnName, AttrEntidadColumnDescription, AttrEntidadColumnOrdinal, _
                                                      AttrEntidadColumnDataType, AttrEntidadColumnSize, AttrEntidadIsRequerido, _
                                                      AttrEntidadDomainField, AttrEntidadIsForeignKey, AttrEntidadForeignTable, _
                                                      AttrEntidadForeignSQL, AttrEntidadColumnLabel, AttrEntidadColumnControlName, _
                                                      AttrEntidadColumnControlBase, AttrEntidadColumnTipoControl, AttrEntidadColumnControlWidth, AttrEntidadColumnTextMode, _
                                                      AttrEntidadColumnToolTip, AttrEntidadIsFilterField, AttrEntidadIsColumnField, _
                                                      AttrEntidadColumnNumber, AttrEntidadColumnHeader, AttrEntidadIsInVistaValidar, _
                                                      AttrEntidadIsEnabledInVistaMantener, AttrEntidadIsFormKeys, AttrEntidadIsAutocomplete, _
                                                      AttrEntidadAutocompleteMethod, AttrEntidadColumnGroupNumber, AttrEntidadColumnGroupOrdinal, _
                                                      AttrEntidadColumnGroupName, UserId)


                End If

            Next
            dtr.Close()

            CrearEntidadNegocio = True
        Catch
            CrearEntidadNegocio = False
        End Try
    End Function

    Public Function CrearPaginaWebTipoLista(ByVal NombreTabla As String, _
                                            ByVal MasterPage As String, _
                                            ByVal OpcionDeMenu As String, _
                                         ByVal UserId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim dtr As IDataReader
        Dim sSQL As String = ""
        Dim sqlSelect As String = "Select " & NombreTabla & "." & CampoIdentity(NombreTabla) & " As Id"

        Dim Entidad As New Entidad
        Dim AttrEntidad As New AttrEntidad
        Dim PaginaWeb As New PaginaWeb
        Dim Formularioweb As New FormularioWeb

        Dim t As Integer = 0

        ' Definición de datos de la tabla Entidad
        Dim EntidadId As Long = 0
        Dim EntidadNombreTabla As String = ""
        Dim EntidadNombreEntidad As String = ""
        Dim EntidadDescription As String = ""
        Dim EntidadTipo As String = ""
        Dim EntidadCampoId As String = ""
        Dim EntidadCampoName As String = ""
        Dim EntidadCampoSecuencia As String = ""
        Dim EntidadNombreTablaPadre As String = ""
        Dim EntidadMasterId As String = ""
        Dim EntidadMasterName As String = ""
        Dim EntidadNombreClase As String = ""
        Dim EntidadServicioLectura As String = ""
        Dim EntidadServicioUpdate As String = ""
        Dim EntidadServicioInsert As String = ""
        Dim EntidadVistaMantener As String = ""
        Dim EntidadVistaBuscar As String = ""
        Dim EntidadVistaValidar As String = ""
        Dim EntidadVistaListar As String = ""
        ' Definicio de datos de la tabla AttrEntidad
        Dim AttrEntidadId As Long = 0
        'Dim EntidadNombreTabla As String
        Dim AttrEntidadSecuencia As Long = 0
        Dim AttrEntidadColumnName As String = ""
        Dim AttrEntidadColumnDescription As String = ""
        Dim AttrEntidadColumnOrdinal As Long = 0
        Dim AttrEntidadColumnDataType As String = ""
        Dim AttrEntidadColumnSize As Long = 0
        Dim AttrEntidadIsRequerido As Boolean = False
        Dim AttrEntidadDomainField As String = ""
        Dim AttrEntidadIsForeignKey As Boolean = False
        Dim AttrEntidadForeignTable As String = ""
        Dim AttrEntidadForeignSQL As String = ""
        Dim AttrEntidadColumnLabel As String = ""
        Dim AttrEntidadColumnControlName As String = ""
        Dim AttrEntidadColumnControlBase As String = ""
        Dim AttrEntidadColumnTextMode As Long = 0
        Dim AttrEntidadColumnToolTip As String = ""
        Dim AttrEntidadIsFilterField As Boolean = False
        Dim AttrEntidadIsColumnField As Boolean = False
        Dim AttrEntidadColumnNumber As Long = 0
        Dim AttrEntidadColumnHeader As String = ""
        Dim AttrEntidadIsInVistaValidar As Boolean = False
        Dim AttrEntidadIsEnabledInVistaMantener As Boolean = False
        Dim AttrEntidadIsAutocomplete As Boolean = False
        Dim AttrEntidadAutocompleteMethod As String = ""
        Dim AttrEntidadColumnGroupNumber As Long = 0
        Dim AttrEntidadColumnGroupOrdinal As Long = 0
        Dim AttrEntidadColumnGroupName As String = ""
        ' Definición de la tabla PaginaWeb
        Dim PaginaWebId As Long = 0
        Dim PaginaWebName As String = ""
        Dim PaginaWebTitle As String = ""
        Dim PaginaWebDescription As String = ""
        Dim PaginaWebDescription2 As String = ""
        Dim FormularioWebNumber As Long = 0
        Dim PaginaWebGroupValidation As String = ""
        Dim PaginaWebStereotype As String = ""
        Dim PaginaWebUserControl As String = ""
        'Dim EntidadNombreTabla As String
        ' Definición de la tabla Formulario Web
        Dim FormularioWebId As Long
        'Dim FormularioWebNumber As Long
        Dim FormularioWebPId As Long
        Dim FormularioWebSecuencia As Long
        Dim FormularioWebGroupType As String
        Dim FormularioWebLabel As String
        Dim FormularioWebControl As String
        Dim FormularioWebTipoControl As String
        Dim FormularioWebControlBase As String
        Dim FormularioWebCssClassLabel As String
        Dim FormularioWebCssClassControl As String
        Dim FormularioWebLabelAlign As String
        Dim FormularioWebControlWidth As String
        Dim FormularioWebControlTextMode As Long
        Dim FormularioWebToolTip As String
        Dim FormularioWebIsRequiredField As Boolean
        Dim FormularioWebIsNotEnabled As Boolean
        Dim FormularioWebDomainField As String
        Dim FormularioWebDataTextField As String
        Dim FormularioWebTipoDatos As String
        Dim FormularioWebDataFile As String
        Dim FormularioWebSelectCommand As String
        Dim FormularioWebSection As String
        Dim FormularioWebGroupValidation As String
        Dim FormularioWebEvent As String
        Dim FormularioWebPageCall As String
        Dim FormularioWebFormCall As String
        Dim FormularioWebURL As String
        Dim FormularioWebServiceCall As String
        Dim FormularioWebIsPerfilable As Boolean
        Dim FormularioWebIsAbleToDisappear As Boolean
        Dim FormularioWebIsVisibleToInit As Boolean
        Dim FormularioWebDescription As String


        'Este metodo genera un registro en la tabla PaginaWeb y los registros que correspondan en la 
        'tabla FormularioWeb con el fin de generar la vista que permite obtener una lista de las instancias
        'de la Entidad de Negocio indicada por el usuario en la variable NombreEntidad

        '---------------------------------------------------------------------------------------------
        '       Inserta registro en la tabla PaginaWeb
        '---------------------------------------------------------------------------------------------

        ' Prepara Datos para hacer la inserción del registro en la tabla PaginaWeb.

        Try
            EntidadNombreTabla = NombreTabla
            t = Entidad.LeerEntidadByName(EntidadId, EntidadNombreTabla, EntidadNombreEntidad, EntidadDescription, EntidadTipo, EntidadCampoId, EntidadCampoName, EntidadCampoSecuencia, EntidadNombreTablaPadre, EntidadMasterId, EntidadMasterName, EntidadNombreClase, EntidadServicioLectura, EntidadServicioUpdate, EntidadServicioInsert, EntidadVistaMantener, EntidadVistaBuscar, EntidadVistaValidar, EntidadVistaListar)

            PaginaWebName = EntidadVistaListar
            PaginaWebTitle = "Lista de " & EntidadNombreEntidad
            PaginaWebDescription = "Seleccione un elemento de la lista en caso de requerir actualizar sus datos, presione el botón ""Nuevo"" para registrar un nuevo registro o presione el botón ""Buscar"" para definir un nuevo criterio de búsqueda"
            PaginaWebDescription2 = ""
            FormularioWebNumber = Formularioweb.CalcularNextFormularioWebNumber
            PaginaWebGroupValidation = ""
            PaginaWebStereotype = "ObjectList"
            PaginaWebUserControl = "ListaEntidades.ascx"

            t = PaginaWeb.PaginaWebInsert(PaginaWebId, PaginaWebName, PaginaWebTitle, PaginaWebDescription, PaginaWebDescription2, FormularioWebNumber, PaginaWebGroupValidation, PaginaWebStereotype, PaginaWebUserControl, EntidadNombreTabla, UserId)

            ' Inserción de registro de cabecera del Formulario Web

            'Dim FormularioWebId As Long
            'Dim FormularioWebNumber As Long
            FormularioWebPId = 0
            FormularioWebSecuencia = 1
            FormularioWebGroupType = ""
            FormularioWebLabel = "Lista de " & EntidadNombreEntidad
            FormularioWebControl = "Grid1"
            FormularioWebTipoControl = "GridView"
            FormularioWebControlBase = "GridView"
            FormularioWebCssClassLabel = ""
            FormularioWebCssClassControl = ""
            FormularioWebLabelAlign = ""
            FormularioWebControlWidth = "700"
            FormularioWebControlTextMode = 0
            FormularioWebToolTip = ""
            FormularioWebIsRequiredField = True
            FormularioWebIsNotEnabled = False
            FormularioWebDomainField = ""
            FormularioWebDataTextField = ""
            FormularioWebTipoDatos = ""
            FormularioWebDataFile = ""
            FormularioWebSelectCommand = ""
            FormularioWebSection = "FormHeader"
            FormularioWebGroupValidation = ""
            FormularioWebEvent = ""
            FormularioWebPageCall = ""
            FormularioWebFormCall = ""
            FormularioWebURL = ""
            FormularioWebServiceCall = ""
            FormularioWebIsPerfilable = True
            FormularioWebIsAbleToDisappear = True
            FormularioWebIsVisibleToInit = True
            FormularioWebDescription = ""

            t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

            ' Inserción de registro Id de los elementos de la grilla

            'Dim FormularioWebId As Long
            'Dim FormularioWebNumber As Long
            FormularioWebPId = 0
            FormularioWebSecuencia = 1
            FormularioWebGroupType = ""
            FormularioWebLabel = "Id"
            FormularioWebControl = "Id"
            FormularioWebTipoControl = "HyperLinkField"
            FormularioWebControlBase = "HyperLinkField"
            FormularioWebCssClassLabel = "NA"
            FormularioWebCssClassControl = "NA"
            FormularioWebLabelAlign = "left"
            FormularioWebControlWidth = "15"
            FormularioWebControlTextMode = 0
            FormularioWebToolTip = ""
            FormularioWebIsRequiredField = True
            FormularioWebIsNotEnabled = False
            FormularioWebDomainField = ""
            FormularioWebDataTextField = "Id"
            FormularioWebTipoDatos = ""
            FormularioWebDataFile = ""
            FormularioWebSelectCommand = ""
            FormularioWebSection = "Grilla"
            FormularioWebGroupValidation = ""
            FormularioWebEvent = ""
            FormularioWebPageCall = ""
            FormularioWebFormCall = ""
            FormularioWebURL = MasterPage & "?PaginaWebName=" & EntidadVistaMantener & "&MenuOptionsId=" & OpcionDeMenu
            FormularioWebServiceCall = ""
            FormularioWebIsPerfilable = False
            FormularioWebIsAbleToDisappear = True
            FormularioWebIsVisibleToInit = True
            FormularioWebDescription = ""

            t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

            ' Inserción de las columnas de la grilla

            sSQL = "Select EntidadNombreTabla, AttrEntidadSecuencia, AttrEntidadColumnName, AttrEntidadColumnDescription, AttrEntidadColumnOrdinal, AttrEntidadColumnDataType, AttrEntidadColumnSize, AttrEntidadIsRequerido, AttrEntidadDomainField, AttrEntidadIsForeignKey, AttrEntidadForeignTable, AttrEntidadForeignSQL, AttrEntidadColumnLabel, AttrEntidadColumnControlName, AttrEntidadColumnControlBase, AttrEntidadColumnTextMode, AttrEntidadColumnToolTip, AttrEntidadIsFilterField, AttrEntidadIsColumnField, AttrEntidadColumnNumber, AttrEntidadColumnHeader, AttrEntidadIsInVistaValidar, AttrEntidadIsEnabledInVistaMantener, AttrEntidadIsAutocomplete, AttrEntidadAutocompleteMethod, AttrEntidadColumnGroupNumber, AttrEntidadColumnGroupOrdinal, AttrEntidadColumnGroupName "
            sSQL = sSQL & "FROM AttrEntidad "
            sSQL = sSQL & "WHERE (AttrEntidad.EntidadNombreTabla = '" & NombreTabla & "' AND AttrEntidad.AttrEntidadIsColumnField = True) ORDER By AttrEntidadColumnNumber "

            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                FormularioWebPId = 0
                FormularioWebSecuencia = CLng(dtr("AttrEntidadColumnNumber").ToString) + 1
                FormularioWebLabel = CStr(dtr("AttrEntidadColumnHeader").ToString)
                FormularioWebControl = CStr(dtr("AttrEntidadColumnHeader").ToString)
                FormularioWebTipoControl = "TemplateField"
                FormularioWebControlBase = "TemplateField"
                FormularioWebDataTextField = CStr(dtr("AttrEntidadColumnName").ToString)
                FormularioWebSection = "Grilla"
                FormularioWebURL = ""
                ' Incluyo columna en la instrucción select
                sqlSelect &= ", " & NombreTabla & "." & CStr(dtr("AttrEntidadColumnName").ToString) & " As " & CStr(dtr("AttrEntidadColumnHeader").ToString)

                t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)
            End While

            ' Inserción de la fila con la instrucción SQL

            sqlSelect &= " FROM " & NombreTabla

            FormularioWebPId = 0
            FormularioWebSecuencia = 1
            FormularioWebGroupType = ""
            FormularioWebLabel = "Lista" & NombreTabla
            FormularioWebControl = "Lista" & NombreTabla
            FormularioWebTipoControl = "SQLSelect"
            FormularioWebControlBase = "AccesDataSource"
            FormularioWebDataTextField = ""
            FormularioWebDataFile = "App_Data\BDCAS.mdb"
            FormularioWebSelectCommand = sqlSelect
            FormularioWebSection = "SQLStatement"
            FormularioWebGroupValidation = "NO"

            t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

            ' Inserción de las filas con los botones de la vista

            FormularioWebPId = 0
            FormularioWebSecuencia = 1
            FormularioWebGroupType = ""
            FormularioWebLabel = "Nuevo"
            FormularioWebControl = "NewButton"
            FormularioWebTipoControl = "Button"
            FormularioWebControlBase = "Button"
            FormularioWebCssClassLabel = "textocontgris10bold"
            FormularioWebCssClassControl = "boxceleste"
            FormularioWebLabelAlign = "left"
            FormularioWebControlWidth = "80px"
            FormularioWebControlTextMode = 0
            FormularioWebToolTip = "Presione para crear un nuevo registro"
            FormularioWebDataTextField = ""
            FormularioWebDataFile = ""
            FormularioWebSelectCommand = ""
            FormularioWebSection = "Button"
            FormularioWebGroupValidation = "NO"
            FormularioWebEvent = "URLNew"
            FormularioWebPageCall = MasterPage
            FormularioWebFormCall = EntidadVistaValidar

            t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

            FormularioWebPId = 0
            FormularioWebSecuencia = 2
            FormularioWebGroupType = ""
            FormularioWebLabel = "Buscar"
            FormularioWebControl = "SearchButton"
            FormularioWebTipoControl = "Button"
            FormularioWebControlBase = "Button"
            FormularioWebCssClassLabel = "textocontgris10bold"
            FormularioWebCssClassControl = "boxceleste"
            FormularioWebLabelAlign = "left"
            FormularioWebControlWidth = "80px"
            FormularioWebControlTextMode = 0
            FormularioWebToolTip = "Presione para acceder a un criterio de búsqueda de registros"
            FormularioWebDataTextField = ""
            FormularioWebDataFile = ""
            FormularioWebSelectCommand = ""
            FormularioWebSection = "Button"
            FormularioWebGroupValidation = "NO"
            FormularioWebEvent = "URLSearch"
            FormularioWebPageCall = MasterPage
            FormularioWebFormCall = EntidadVistaBuscar

            t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

            CrearPaginaWebTipoLista = True
        Catch ex As Exception
            CrearPaginaWebTipoLista = False
        End Try

    End Function
    Public Function CrearPaginaWebTipoFicha(ByVal NombreTabla As String, _
                                            ByVal MasterPage As String, _
                                            ByVal OpcionDeMenu As String, _
                                         ByVal UserId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim dtrGroup As IDataReader
        Dim dtrLeaf As IDataReader
        Dim dtr As IDataReader
        Dim TablaHija As String = ""
        Dim sqlSelect As String = "Select " & TablaHija & "." & CampoIdentity(TablaHija) & " As Id"

        Dim Entidad As New Entidad
        Dim AttrEntidad As New AttrEntidad
        Dim PaginaWeb As New PaginaWeb
        Dim Formularioweb As New FormularioWeb
        Dim VistaMantener As String = ""

        Dim t As Integer = 0

        ' Definición de datos de la tabla Entidad
        Dim EntidadId As Long = 0
        Dim EntidadNombreTabla As String = ""
        Dim EntidadNombreEntidad As String = ""
        Dim EntidadDescription As String = ""
        Dim EntidadTipo As String = ""
        Dim EntidadCampoId As String = ""
        Dim EntidadCampoName As String = ""
        Dim EntidadCampoSecuencia As String = ""
        Dim EntidadNombreTablaPadre As String = ""
        Dim EntidadMasterId As String = ""
        Dim EntidadMasterName As String = ""
        Dim EntidadNombreClase As String = ""
        Dim EntidadServicioLectura As String = ""
        Dim EntidadServicioUpdate As String = ""
        Dim EntidadServicioInsert As String = ""
        Dim EntidadVistaMantener As String = ""
        Dim EntidadVistaBuscar As String = ""
        Dim EntidadVistaValidar As String = ""
        Dim EntidadVistaListar As String = ""
        ' Definicio de datos de la tabla AttrEntidad
        Dim AttrEntidadId As Long = 0
        'Dim EntidadNombreTabla As String
        Dim AttrEntidadSecuencia As Long = 0
        Dim AttrEntidadColumnName As String = ""
        Dim AttrEntidadColumnDescription As String = ""
        Dim AttrEntidadColumnOrdinal As Long = 0
        Dim AttrEntidadColumnDataType As String = ""
        Dim AttrEntidadColumnSize As Long = 0
        Dim AttrEntidadIsRequerido As Boolean = False
        Dim AttrEntidadDomainField As String = ""
        Dim AttrEntidadIsForeignKey As Boolean = False
        Dim AttrEntidadForeignTable As String = ""
        Dim AttrEntidadForeignSQL As String = ""
        Dim AttrEntidadColumnLabel As String = ""
        Dim AttrEntidadColumnControlName As String = ""
        Dim AttrEntidadColumnControlBase As String = ""
        Dim AttrEntidadColumnTipoControl As String = ""
        Dim AttrEntidadColumnControlWidth As String = ""
        Dim AttrEntidadColumnTextMode As Long = 0
        Dim AttrEntidadColumnToolTip As String = ""
        Dim AttrEntidadIsFilterField As Boolean = False
        Dim AttrEntidadIsColumnField As Boolean = False
        Dim AttrEntidadColumnNumber As Long = 0
        Dim AttrEntidadColumnHeader As String = ""
        Dim AttrEntidadIsInVistaValidar As Boolean = False
        Dim AttrEntidadIsEnabledInVistaMantener As Boolean = False
        Dim AttrEntidadIsFormKeys As Boolean = False
        Dim AttrEntidadIsAutocomplete As Boolean = False
        Dim AttrEntidadAutocompleteMethod As String = ""
        Dim AttrEntidadColumnGroupNumber As Long = 0
        Dim AttrEntidadColumnGroupOrdinal As Long = 0
        Dim AttrEntidadColumnGroupName As String = ""
        ' Definición de la tabla PaginaWeb
        Dim PaginaWebId As Long = 0
        Dim PaginaWebName As String = ""
        Dim PaginaWebTitle As String = ""
        Dim PaginaWebDescription As String = ""
        Dim PaginaWebDescription2 As String = ""
        Dim FormularioWebNumber As Long = 0
        Dim PaginaWebGroupValidation As String = ""
        Dim PaginaWebStereotype As String = ""
        Dim PaginaWebUserControl As String = ""
        'Dim EntidadNombreTabla As String
        ' Definición de la tabla Formulario Web
        Dim FormularioWebId As Long
        'Dim FormularioWebNumber As Long
        Dim FormularioWebPId As Long
        Dim FormularioWebSecuencia As Long
        Dim FormularioWebGroupType As String
        Dim FormularioWebLabel As String
        Dim FormularioWebControl As String
        Dim FormularioWebTipoControl As String
        Dim FormularioWebControlBase As String
        Dim FormularioWebCssClassLabel As String
        Dim FormularioWebCssClassControl As String
        Dim FormularioWebLabelAlign As String
        Dim FormularioWebControlWidth As String
        Dim FormularioWebControlTextMode As Long
        Dim FormularioWebToolTip As String
        Dim FormularioWebIsRequiredField As Boolean
        Dim FormularioWebIsNotEnabled As Boolean
        Dim FormularioWebDomainField As String
        Dim FormularioWebDataTextField As String
        Dim FormularioWebTipoDatos As String
        Dim FormularioWebDataFile As String
        Dim FormularioWebSelectCommand As String
        Dim FormularioWebSection As String
        Dim FormularioWebGroupValidation As String
        Dim FormularioWebEvent As String
        Dim FormularioWebPageCall As String
        Dim FormularioWebFormCall As String
        Dim FormularioWebURL As String
        Dim FormularioWebServiceCall As String
        Dim FormularioWebIsPerfilable As Boolean
        Dim FormularioWebIsAbleToDisappear As Boolean
        Dim FormularioWebIsVisibleToInit As Boolean
        Dim FormularioWebDescription As String


        'Este metodo genera un registro en la tabla PaginaWeb y los registros que correspondan en la 
        'tabla FormularioWeb con el fin de generar la vista que permite obtener una lista de las instancias
        'de la Entidad de Negocio indicada por el usuario en la variable NombreEntidad

        '---------------------------------------------------------------------------------------------
        '       Inserta registro en la tabla PaginaWeb
        '---------------------------------------------------------------------------------------------

        ' Prepara Datos para hacer la inserción del registro en la tabla PaginaWeb.

        Try
            EntidadNombreTabla = NombreTabla
            t = Entidad.LeerEntidadByName(EntidadId, EntidadNombreTabla, EntidadNombreEntidad, EntidadDescription, EntidadTipo, EntidadCampoId, EntidadCampoName, EntidadCampoSecuencia, EntidadNombreTablaPadre, EntidadMasterId, EntidadMasterName, EntidadNombreClase, EntidadServicioLectura, EntidadServicioUpdate, EntidadServicioInsert, EntidadVistaMantener, EntidadVistaBuscar, EntidadVistaValidar, EntidadVistaListar)

            PaginaWebName = EntidadVistaMantener
            PaginaWebTitle = "Mantención de datos de " & EntidadNombreEntidad
            PaginaWebDescription = "Modifique los datos requeridos y luego de un click de mousse sobre el botón ""Guardar Datos"" para confirmar la modificación o bien un click de mousse sobre el botón ""Cancelar"" para dejar sin efecto el cambio"
            PaginaWebDescription2 = ""
            FormularioWebNumber = Formularioweb.CalcularNextFormularioWebNumber
            PaginaWebGroupValidation = "InputValidation"
            PaginaWebStereotype = "DataEntry"
            PaginaWebUserControl = "Ficha" & EntidadNombreClase & ".ascx"

            t = PaginaWeb.PaginaWebInsert(PaginaWebId, PaginaWebName, PaginaWebTitle, PaginaWebDescription, PaginaWebDescription2, FormularioWebNumber, PaginaWebGroupValidation, PaginaWebStereotype, PaginaWebUserControl, EntidadNombreTabla, UserId)

            ' Inserción de registro de cabecera del Formulario Web

            'Dim FormularioWebId As Long
            'Dim FormularioWebNumber As Long
            FormularioWebPId = 0
            FormularioWebSecuencia = 1
            FormularioWebGroupType = ""
            FormularioWebLabel = "Ficha de " & EntidadNombreEntidad
            FormularioWebControl = "frmHeader"
            FormularioWebTipoControl = ""
            FormularioWebControlBase = ""
            FormularioWebCssClassLabel = ""
            FormularioWebCssClassControl = ""
            FormularioWebLabelAlign = ""
            FormularioWebControlWidth = ""
            FormularioWebControlTextMode = 0
            FormularioWebToolTip = ""
            FormularioWebIsRequiredField = True
            FormularioWebIsNotEnabled = False
            FormularioWebDomainField = ""
            FormularioWebDataTextField = ""
            FormularioWebTipoDatos = ""
            FormularioWebDataFile = ""
            FormularioWebSelectCommand = ""
            FormularioWebSection = "FormHeader"
            FormularioWebGroupValidation = ""
            FormularioWebEvent = ""
            FormularioWebPageCall = ""
            FormularioWebFormCall = ""
            FormularioWebURL = ""
            FormularioWebServiceCall = ""
            FormularioWebIsPerfilable = True
            FormularioWebIsAbleToDisappear = True
            FormularioWebIsVisibleToInit = True
            FormularioWebDescription = ""

            t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)
            Dim PIdGroup As Long = FormularioWebId ' Dejamos marcado el PIdGroup con el Id del registro de cabecera del formulario Web
            ' Inserción del o los controles que conforman las claves únicas de la entidad (FormKeys)
            ' Sabemos que las FormKeys conforman el grupo 0 de los atributos de la Entidad
            ' Nos vamos directos a insertar los registros que corresponden a las claves de la entidad
            ' Cambio del 08-11-2010
            ' Vamos a seleccionar los campos que estas marcados con el atributo AttrEntidadIsFormKeys en true.

            Dim PIdLeaf As Long = 0
            Dim LeafSecuencia = 0
            Dim sSQL As String = ""
            sSQL = "Select EntidadNombreTabla, AttrEntidadSecuencia, AttrEntidadColumnName, AttrEntidadColumnDescription, AttrEntidadColumnOrdinal, AttrEntidadColumnDataType, AttrEntidadColumnSize, AttrEntidadIsRequerido, AttrEntidadDomainField, AttrEntidadIsForeignKey, AttrEntidadForeignTable, AttrEntidadForeignSQL, AttrEntidadColumnLabel, AttrEntidadColumnControlName, AttrEntidadColumnControlBase, AttrEntidadColumnTipoControl, AttrEntidadColumnControlWidth, AttrEntidadColumnTextMode, AttrEntidadColumnToolTip, AttrEntidadIsFilterField, AttrEntidadIsColumnField, AttrEntidadColumnNumber, AttrEntidadColumnHeader, AttrEntidadIsInVistaValidar, AttrEntidadIsEnabledInVistaMantener, AttrEntidadIsAutocomplete, AttrEntidadAutocompleteMethod, AttrEntidadColumnGroupNumber, AttrEntidadColumnGroupOrdinal, AttrEntidadColumnGroupName "
            sSQL = sSQL & "FROM AttrEntidad "
            sSQL = sSQL & "Where AttrEntidad.AttrEntidadIsFormKeys = true and AttrEntidad.EntidadNombreTabla = '" & NombreTabla & "' order by AttrEntidad.AttrEntidadColumnGroupOrdinal"

            dtrLeaf = AccesoEA.ListarRegistros(sSQL)
            While dtrLeaf.Read
                FormularioWebPId = PIdLeaf
                LeafSecuencia = LeafSecuencia + 1
                FormularioWebSecuencia = LeafSecuencia
                FormularioWebGroupType = ""
                FormularioWebLabel = CStr(dtrLeaf("AttrEntidadColumnLabel").ToString)
                FormularioWebControl = CStr(dtrLeaf("AttrEntidadColumnControlName").ToString)
                FormularioWebTipoControl = CStr(dtrLeaf("AttrEntidadColumnTipoControl").ToString)
                FormularioWebControlBase = CStr(dtrLeaf("AttrEntidadColumnControlBase").ToString)
                FormularioWebCssClassLabel = "textocontgris10bold"
                FormularioWebCssClassControl = "textoboxgris"
                FormularioWebLabelAlign = "right"
                FormularioWebControlWidth = CStr(dtrLeaf("AttrEntidadColumnControlWidth").ToString)
                FormularioWebControlTextMode = CLng(dtrLeaf("AttrEntidadColumnTextMode").ToString)
                If FormularioWebControlTextMode = 1 Then FormularioWebControlWidth = "500px"
                FormularioWebToolTip = CStr(dtrLeaf("AttrEntidadColumnToolTip").ToString)
                FormularioWebIsRequiredField = CBool(dtrLeaf("AttrEntidadIsRequerido").ToString)
                FormularioWebIsNotEnabled = Not CBool(dtrLeaf("AttrEntidadIsEnabledInVistaMantener").ToString)
                FormularioWebDomainField = CStr(dtrLeaf("AttrEntidadDomainField").ToString)
                FormularioWebDataTextField = CStr(dtrLeaf("AttrEntidadColumnName").ToString)
                FormularioWebTipoDatos = CStr(dtrLeaf("AttrEntidadColumnDataType").ToString)
                FormularioWebDataFile = ""
                FormularioWebSelectCommand = ""
                FormularioWebSection = "FormKeys"
                If FormularioWebIsRequiredField Then
                    FormularioWebGroupValidation = "InputValidation"
                Else
                    FormularioWebGroupValidation = ""
                End If
                FormularioWebEvent = ""
                FormularioWebPageCall = ""
                FormularioWebFormCall = ""
                FormularioWebURL = ""
                FormularioWebServiceCall = ""
                FormularioWebIsPerfilable = True
                FormularioWebIsAbleToDisappear = True
                FormularioWebIsVisibleToInit = True
                FormularioWebDescription = ""

                t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)
            End While

            ' Inserción de registro de grupo de controles del formulario
            ' Primero determinamos el número de grupos y los nombres de cada uno y luego leemos los controles de cada grupo y creamos sus registros en el formulario web

            Dim GroupSecuencia = 0
            Dim GroupName As String = ""
            Dim sSQLGroup As String = ""
            sSQLGroup = "Select DISTINCT AttrEntidad.AttrEntidadColumnGroupName As Grupo, AttrEntidad.AttrEntidadColumnGroupNumber As NumeroGrupo From AttrEntidad Where AttrEntidad.EntidadNombreTabla = '" & NombreTabla & "' Order By AttrEntidad.AttrEntidadColumnGroupNumber"
            dtrGroup = AccesoEA.ListarRegistros(sSQLGroup)
            While dtrGroup.Read
                If dtrGroup("NumeroGrupo") > 0 Then  ' El grupo 0 son las FormKeys
                    FormularioWebPId = PIdGroup
                    GroupSecuencia = GroupSecuencia + 1
                    FormularioWebSecuencia = GroupSecuencia
                    GroupName = dtrGroup("Grupo").ToString
                    FormularioWebLabel = GroupName
                    FormularioWebControl = "frmGroup" & GroupSecuencia
                    FormularioWebTipoControl = ""
                    FormularioWebControlBase = ""
                    FormularioWebDataTextField = ""
                    FormularioWebSection = "FormGroup"
                    FormularioWebURL = ""
                    FormularioWebCssClassLabel = ""
                    FormularioWebCssClassControl = ""
                    FormularioWebLabelAlign = ""
                    FormularioWebControlWidth = ""
                    FormularioWebControlTextMode = 0
                    FormularioWebToolTip = ""
                    FormularioWebIsRequiredField = False
                    FormularioWebIsNotEnabled = False
                    FormularioWebDomainField = ""
                    FormularioWebDataTextField = ""
                    FormularioWebTipoDatos = ""
                    FormularioWebDataFile = ""
                    FormularioWebSelectCommand = ""


                    t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

                    ' En segundo término por cada grupo leemos los registros subordinados y los insertamos en el formulario web

                    PIdLeaf = FormularioWebId
                    LeafSecuencia = 0
                    sSQL = ""
                    sSQL = "Select EntidadNombreTabla, AttrEntidadSecuencia, AttrEntidadColumnName, AttrEntidadColumnDescription, AttrEntidadColumnOrdinal, AttrEntidadColumnDataType, AttrEntidadColumnSize, AttrEntidadIsRequerido, AttrEntidadDomainField, AttrEntidadIsForeignKey, AttrEntidadForeignTable, AttrEntidadForeignSQL, AttrEntidadColumnLabel, AttrEntidadColumnControlName, AttrEntidadColumnControlBase, AttrEntidadColumnTipoControl, AttrEntidadColumnControlWidth, AttrEntidadColumnTextMode, AttrEntidadColumnToolTip, AttrEntidadIsFilterField, AttrEntidadIsColumnField, AttrEntidadColumnNumber, AttrEntidadColumnHeader, AttrEntidadIsInVistaValidar, AttrEntidadIsEnabledInVistaMantener, AttrEntidadIsAutocomplete, AttrEntidadAutocompleteMethod, AttrEntidadColumnGroupNumber, AttrEntidadColumnGroupOrdinal, AttrEntidadColumnGroupName "
                    sSQL = sSQL & "FROM AttrEntidad "
                    sSQL = sSQL & "Where AttrEntidad.AttrEntidadColumnGroupName = '" & GroupName & "' and AttrEntidad.EntidadNombreTabla = '" & NombreTabla & "' order by AttrEntidad.AttrEntidadColumnGroupOrdinal"

                    dtrLeaf = AccesoEA.ListarRegistros(sSQL)
                    While dtrLeaf.Read
                        FormularioWebPId = PIdLeaf
                        LeafSecuencia = LeafSecuencia + 1
                        FormularioWebSecuencia = LeafSecuencia
                        FormularioWebGroupType = ""
                        FormularioWebLabel = CStr(dtrLeaf("AttrEntidadColumnLabel").ToString)
                        FormularioWebControl = CStr(dtrLeaf("AttrEntidadColumnControlName").ToString)
                        FormularioWebTipoControl = CStr(dtrLeaf("AttrEntidadColumnTipoControl").ToString)
                        FormularioWebControlBase = CStr(dtrLeaf("AttrEntidadColumnControlBase").ToString)
                        FormularioWebCssClassLabel = "textocontgris10bold"
                        FormularioWebCssClassControl = "textoboxgris"
                        FormularioWebLabelAlign = "right"
                        FormularioWebControlWidth = CStr(dtrLeaf("AttrEntidadColumnControlWidth").ToString)
                        FormularioWebControlTextMode = CLng(dtrLeaf("AttrEntidadColumnTextMode").ToString)
                        If FormularioWebControlTextMode = 1 Then FormularioWebControlWidth = "500px"
                        FormularioWebToolTip = CStr(dtrLeaf("AttrEntidadColumnToolTip").ToString)
                        FormularioWebIsRequiredField = CBool(dtrLeaf("AttrEntidadIsRequerido").ToString)
                        FormularioWebIsNotEnabled = Not CBool(dtrLeaf("AttrEntidadIsEnabledInVistaMantener").ToString)
                        FormularioWebDomainField = CStr(dtrLeaf("AttrEntidadDomainField").ToString)
                        FormularioWebDataTextField = CStr(dtrLeaf("AttrEntidadColumnName").ToString)
                        FormularioWebTipoDatos = CStr(dtrLeaf("AttrEntidadColumnDataType").ToString)
                        If CBool(dtrLeaf("AttrEntidadIsForeignKey").ToString) = "True" Then
                            FormularioWebDataFile = "App_Data\BDCAS.mdb"
                            FormularioWebSelectCommand = CStr(dtrLeaf("AttrEntidadForeignSQL").ToString)
                        Else
                            FormularioWebDataFile = ""
                            FormularioWebSelectCommand = ""
                        End If

                        FormularioWebSection = "Form"
                        If FormularioWebIsRequiredField Then
                            FormularioWebGroupValidation = "InputValidation"
                        Else
                            FormularioWebGroupValidation = ""
                        End If
                        FormularioWebEvent = ""
                        FormularioWebPageCall = ""
                        FormularioWebFormCall = ""
                        FormularioWebURL = ""
                        FormularioWebServiceCall = ""
                        FormularioWebIsPerfilable = True
                        FormularioWebIsAbleToDisappear = True
                        FormularioWebIsVisibleToInit = True
                        FormularioWebDescription = ""

                        t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)
                    End While
                End If
            End While


            ' Inserción de las filas con los botones de la vista

            Select Case Entidad.LeerEntidadTipo(NombreTabla)

                Case "Maestra"

                    FormularioWebPId = 0
                    FormularioWebSecuencia = 1
                    FormularioWebGroupType = ""
                    FormularioWebLabel = "Guardar Datos"
                    FormularioWebControl = "UpdateButton"
                    FormularioWebTipoControl = "Button"
                    FormularioWebControlBase = "Button"
                    FormularioWebCssClassLabel = "textocontgris10bold"
                    FormularioWebCssClassControl = "boxceleste"
                    FormularioWebLabelAlign = "left"
                    FormularioWebControlWidth = "100px"
                    FormularioWebControlTextMode = 0
                    FormularioWebToolTip = "Presione para actualizar los datos modificados"
                    FormularioWebIsRequiredField = True
                    FormularioWebDataTextField = ""
                    FormularioWebTipoDatos = ""
                    FormularioWebDataFile = ""
                    FormularioWebSelectCommand = ""
                    FormularioWebSection = "Button"
                    FormularioWebGroupValidation = "InputValidation"
                    FormularioWebEvent = "URLUpdate"
                    FormularioWebPageCall = MasterPage
                    FormularioWebFormCall = EntidadVistaMantener

                    t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

                    FormularioWebPId = 0
                    FormularioWebSecuencia = 2
                    FormularioWebGroupType = ""
                    FormularioWebLabel = "Nuevo"
                    FormularioWebControl = "NewButton"
                    FormularioWebTipoControl = "Button"
                    FormularioWebControlBase = "Button"
                    FormularioWebCssClassLabel = "textocontgris10bold"
                    FormularioWebCssClassControl = "boxceleste"
                    FormularioWebLabelAlign = "left"
                    FormularioWebControlWidth = "80px"
                    FormularioWebControlTextMode = 0
                    FormularioWebToolTip = "Presione para iniciar el proceso de inserción de un nuevo registro"
                    FormularioWebIsRequiredField = False
                    FormularioWebDataTextField = ""
                    FormularioWebTipoDatos = ""
                    FormularioWebDataFile = ""
                    FormularioWebSelectCommand = ""
                    FormularioWebSection = "Button"
                    FormularioWebGroupValidation = ""
                    FormularioWebEvent = "URLNew"
                    FormularioWebPageCall = MasterPage
                    FormularioWebFormCall = EntidadVistaValidar

                    t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

                    FormularioWebPId = 0
                    FormularioWebSecuencia = 3
                    FormularioWebGroupType = ""
                    FormularioWebLabel = "Buscar"
                    FormularioWebControl = "SearchButton"
                    FormularioWebTipoControl = "Button"
                    FormularioWebControlBase = "Button"
                    FormularioWebCssClassLabel = "textocontgris10bold"
                    FormularioWebCssClassControl = "boxceleste"
                    FormularioWebLabelAlign = "left"
                    FormularioWebControlWidth = "80px"
                    FormularioWebControlTextMode = 0
                    FormularioWebToolTip = "Presione para ingresar un criterio de búsqueda"
                    FormularioWebIsRequiredField = False
                    FormularioWebDataTextField = ""
                    FormularioWebTipoDatos = ""
                    FormularioWebDataFile = ""
                    FormularioWebSelectCommand = ""
                    FormularioWebSection = "Button"
                    FormularioWebGroupValidation = ""
                    FormularioWebEvent = "URLSearch"
                    FormularioWebPageCall = MasterPage
                    FormularioWebFormCall = EntidadVistaBuscar

                    t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

                Case "Hija"

                    FormularioWebPId = 0
                    FormularioWebSecuencia = 1
                    FormularioWebGroupType = ""
                    FormularioWebLabel = "Guardar Datos"
                    FormularioWebControl = "UpdateButton"
                    FormularioWebTipoControl = "Button"
                    FormularioWebControlBase = "Button"
                    FormularioWebCssClassLabel = "textocontgris10bold"
                    FormularioWebCssClassControl = "boxceleste"
                    FormularioWebLabelAlign = "left"
                    FormularioWebControlWidth = "100px"
                    FormularioWebControlTextMode = 0
                    FormularioWebToolTip = "Presione para actualizar los datos modificados"
                    FormularioWebIsRequiredField = True
                    FormularioWebDataTextField = ""
                    FormularioWebTipoDatos = ""
                    FormularioWebDataFile = ""
                    FormularioWebSelectCommand = ""
                    FormularioWebSection = "Button"
                    FormularioWebGroupValidation = "InputValidation"
                    FormularioWebEvent = "URLUpdate"
                    FormularioWebPageCall = MasterPage
                    FormularioWebFormCall = EntidadVistaMantener

                    t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

                    FormularioWebPId = 0
                    FormularioWebSecuencia = 2
                    FormularioWebGroupType = ""
                    FormularioWebLabel = "Nuevo"
                    FormularioWebControl = "NewButton"
                    FormularioWebTipoControl = "Button"
                    FormularioWebControlBase = "Button"
                    FormularioWebCssClassLabel = "textocontgris10bold"
                    FormularioWebCssClassControl = "boxceleste"
                    FormularioWebLabelAlign = "left"
                    FormularioWebControlWidth = "80px"
                    FormularioWebControlTextMode = 0
                    FormularioWebToolTip = "Presione para iniciar el proceso de inserción de un nuevo registro"
                    FormularioWebIsRequiredField = False
                    FormularioWebDataTextField = ""
                    FormularioWebTipoDatos = ""
                    FormularioWebDataFile = ""
                    FormularioWebSelectCommand = ""
                    FormularioWebSection = "Button"
                    FormularioWebGroupValidation = "NO"
                    FormularioWebEvent = "URLNew"
                    FormularioWebPageCall = MasterPage
                    FormularioWebFormCall = EntidadVistaMantener

                    t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

                    FormularioWebPId = 0
                    FormularioWebSecuencia = 3
                    FormularioWebGroupType = ""
                    FormularioWebLabel = "Eliminar"
                    FormularioWebControl = "DeleteButton"
                    FormularioWebTipoControl = "Button"
                    FormularioWebControlBase = "Button"
                    FormularioWebCssClassLabel = "textocontgris10bold"
                    FormularioWebCssClassControl = "boxceleste"
                    FormularioWebLabelAlign = "left"
                    FormularioWebControlWidth = "80px"
                    FormularioWebControlTextMode = 0
                    FormularioWebToolTip = "Presione para eliminar el registro"
                    FormularioWebIsRequiredField = False
                    FormularioWebDataTextField = ""
                    FormularioWebTipoDatos = ""
                    FormularioWebDataFile = ""
                    FormularioWebSelectCommand = ""
                    FormularioWebSection = "Button"
                    FormularioWebGroupValidation = "NO"
                    FormularioWebEvent = "URLDelete"
                    FormularioWebPageCall = MasterPage
                    FormularioWebFormCall = Entidad.LeerEntidadVistaMantenerPadre(NombreTabla)

                    t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

                    FormularioWebPId = 0
                    FormularioWebSecuencia = 4
                    FormularioWebGroupType = ""
                    FormularioWebLabel = "Volver"
                    FormularioWebControl = "ReturnButton"
                    FormularioWebTipoControl = "Button"
                    FormularioWebControlBase = "Button"
                    FormularioWebCssClassLabel = "textocontgris10bold"
                    FormularioWebCssClassControl = "boxceleste"
                    FormularioWebLabelAlign = "left"
                    FormularioWebControlWidth = "80px"
                    FormularioWebControlTextMode = 0
                    FormularioWebToolTip = "Presione para volver a la ficha del registro padre"
                    FormularioWebIsRequiredField = False
                    FormularioWebDataTextField = ""
                    FormularioWebTipoDatos = ""
                    FormularioWebDataFile = ""
                    FormularioWebSelectCommand = ""
                    FormularioWebSection = "Button"
                    FormularioWebGroupValidation = "NO"
                    FormularioWebEvent = "URLReturn"
                    FormularioWebPageCall = MasterPage
                    FormularioWebFormCall = Entidad.LeerEntidadVistaMantenerPadre(NombreTabla)

                    t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

            End Select


            ' Puede que la Entidad sea padre de una o más entidades hijas, en cuyo caso se debe crear un tabcontainer para cada entidad hija
            ' Luego bajo cada tabcontainer se debe agregar una lista de las columnas que deben aparecer por cada entidad hija, encabezadas a su vez por un link que permita agregar una nueva instancia de la entidad hija.
            ' Comencemos por examinar si la entidad posee entidades hijas.

            ' Esto lo hacemos leyendo sobre la misma tabla Entidad para obtener la lista de entidades hijas.


            PIdGroup = 0
            GroupSecuencia = 0
            GroupName = ""
            sSQLGroup = ""
            sSQLGroup = "Select Entidad.EntidadNombreTabla As TablaHija, Entidad.EntidadNombreEntidad as EntidadHija, Entidad.EntidadVistaMantener as VistaMantener From Entidad Where Entidad.EntidadNombreTablaPadre = '" & NombreTabla & "' "
            dtrGroup = AccesoEA.ListarRegistros(sSQLGroup)
            While dtrGroup.Read
                TablaHija = dtrGroup("TablaHija")
                sqlSelect = "Select " & TablaHija & "." & CampoIdentity(TablaHija) & " As Id"
                VistaMantener = dtrGroup("VistaMantener")
                FormularioWebPId = PIdGroup
                GroupSecuencia = GroupSecuencia + 1
                FormularioWebSecuencia = GroupSecuencia
                GroupName = dtrGroup("EntidadHija").ToString
                FormularioWebLabel = GroupName
                FormularioWebControl = "tab" & GroupSecuencia
                FormularioWebTipoControl = "Tabs"
                FormularioWebControlBase = "TabContainer"
                FormularioWebDataTextField = ""
                FormularioWebSection = "Tabs"
                FormularioWebURL = ""
                FormularioWebCssClassLabel = "NA"
                FormularioWebCssClassControl = "NA"
                FormularioWebLabelAlign = "left"
                FormularioWebControlWidth = ""
                FormularioWebControlTextMode = 0
                FormularioWebToolTip = ""
                FormularioWebIsRequiredField = False
                FormularioWebIsNotEnabled = False
                FormularioWebDomainField = ""
                FormularioWebDataTextField = ""
                FormularioWebTipoDatos = ""
                FormularioWebDataFile = ""
                FormularioWebSelectCommand = ""
                FormularioWebGroupValidation = ""
                FormularioWebEvent = ""
                FormularioWebPageCall = MasterPage
                FormularioWebFormCall = dtrGroup("VistaMantener").ToString


                t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

                ' En segundo término por cada tab leemos los registros subordinados y los insertamos en el formulario web

                PIdLeaf = FormularioWebId
                LeafSecuencia = 0

                sSQL = "Select EntidadNombreTabla, AttrEntidadSecuencia, AttrEntidadColumnName, AttrEntidadColumnDescription, AttrEntidadColumnOrdinal, AttrEntidadColumnDataType, AttrEntidadColumnSize, AttrEntidadIsRequerido, AttrEntidadDomainField, AttrEntidadIsForeignKey, AttrEntidadForeignTable, AttrEntidadForeignSQL, AttrEntidadColumnLabel, AttrEntidadColumnControlName, AttrEntidadColumnControlBase, AttrEntidadColumnTextMode, AttrEntidadColumnToolTip, AttrEntidadIsFilterField, AttrEntidadIsColumnField, AttrEntidadColumnNumber, AttrEntidadColumnHeader, AttrEntidadIsInVistaValidar, AttrEntidadIsEnabledInVistaMantener, AttrEntidadIsAutocomplete, AttrEntidadAutocompleteMethod, AttrEntidadColumnGroupNumber, AttrEntidadColumnGroupOrdinal, AttrEntidadColumnGroupName "
                sSQL = sSQL & "FROM AttrEntidad "
                sSQL = sSQL & "WHERE (AttrEntidad.EntidadNombreTabla = '" & TablaHija & "' AND AttrEntidad.AttrEntidadIsColumnField = True) ORDER By AttrEntidadColumnNumber "

                dtr = AccesoEA.ListarRegistros(sSQL)
                While dtr.Read
                    FormularioWebPId = PIdLeaf
                    LeafSecuencia = LeafSecuencia + 1
                    FormularioWebSecuencia = LeafSecuencia
                    FormularioWebGroupType = ""
                    If LeafSecuencia = 1 Then
                        FormularioWebLabel = "Id"
                        FormularioWebControl = "Id"
                        FormularioWebTipoControl = "HyperLinkField"
                        FormularioWebControlBase = "HyperLinkField"
                        FormularioWebCssClassLabel = "NA"
                        FormularioWebCssClassControl = "NA"
                        FormularioWebLabelAlign = "left"
                        FormularioWebControlWidth = "15"
                        FormularioWebControlTextMode = 0
                        FormularioWebToolTip = ""
                        FormularioWebDataTextField = CStr(dtr("AttrEntidadColumnName").ToString)
                        FormularioWebTipoDatos = ""
                        FormularioWebSection = "Grilla"
                        FormularioWebGroupValidation = "NO"
                        FormularioWebEvent = ""
                        FormularioWebPageCall = ""
                        FormularioWebFormCall = ""
                        FormularioWebURL = MasterPage & "?PaginaWebName=" & VistaMantener & "&MenuOptionsId=" & OpcionDeMenu
                    Else
                        FormularioWebLabel = CStr(dtr("AttrEntidadColumnHeader").ToString)
                        FormularioWebControl = CStr(dtr("AttrEntidadColumnHeader").ToString)
                        FormularioWebTipoControl = "TemplateField"
                        FormularioWebControlBase = "TemplateField"
                        FormularioWebCssClassLabel = "NA"
                        FormularioWebCssClassControl = "NA"
                        FormularioWebLabelAlign = "Left"
                        FormularioWebControlWidth = "80"
                        FormularioWebControlTextMode = 0
                        FormularioWebToolTip = ""
                        FormularioWebDataTextField = CStr(dtr("AttrEntidadColumnName").ToString)
                        FormularioWebSection = "Grilla"
                        FormularioWebGroupValidation = "NO"
                        FormularioWebEvent = ""
                        FormularioWebPageCall = ""
                        FormularioWebFormCall = ""
                        FormularioWebURL = ""
                    End If

                    ' Incluyo columna en la instrucción select
                    sqlSelect &= ", " & TablaHija & "." & CStr(dtr("AttrEntidadColumnName").ToString) & " As " & CStr(dtr("AttrEntidadColumnHeader").ToString)

                    t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)
                End While

                ' Inserción de la fila con la instrucción SQL

                sqlSelect &= " FROM " & TablaHija

                FormularioWebPId = PIdLeaf 'Se agrega el PId 03-04-2011
                FormularioWebSecuencia = 1
                FormularioWebGroupType = ""
                FormularioWebLabel = "Lista" & TablaHija
                FormularioWebControl = "Lista" & TablaHija
                FormularioWebTipoControl = "SQLSelect"
                FormularioWebControlBase = "AccesDataSource"
                FormularioWebDataTextField = ""
                FormularioWebDataFile = "App_Data\BDCAS.mdb"
                FormularioWebSelectCommand = sqlSelect
                FormularioWebSection = "SQLStatement"
                FormularioWebGroupValidation = "NO"
                FormularioWebEvent = ""
                FormularioWebPageCall = ""
                FormularioWebFormCall = ""
                FormularioWebURL = ""

                t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

            End While
            CrearPaginaWebTipoFicha = True
        Catch ex As Exception
            CrearPaginaWebTipoFicha = False
        End Try

    End Function
    Public Function CrearPaginaWebTipoValidar(ByVal NombreTabla As String, _
                                              ByVal MasterPage As String, _
                                         ByVal UserId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim dtrLeaf As IDataReader
        Dim TablaHija As String = ""
        Dim sqlSelect As String = "Select " & TablaHija & "." & CampoIdentity(TablaHija) & " As Id"

        Dim Entidad As New Entidad
        Dim AttrEntidad As New AttrEntidad
        Dim PaginaWeb As New PaginaWeb
        Dim Formularioweb As New FormularioWeb
        Dim VistaMantener As String = ""

        Dim t As Integer = 0

        ' Definición de datos de la tabla Entidad
        Dim EntidadId As Long = 0
        Dim EntidadNombreTabla As String = ""
        Dim EntidadNombreEntidad As String = ""
        Dim EntidadDescription As String = ""
        Dim EntidadTipo As String = ""
        Dim EntidadCampoId As String = ""
        Dim EntidadCampoName As String = ""
        Dim EntidadCampoSecuencia As String = ""
        Dim EntidadNombreTablaPadre As String = ""
        Dim EntidadMasterId As String = ""
        Dim EntidadMasterName As String = ""
        Dim EntidadNombreClase As String = ""
        Dim EntidadServicioLectura As String = ""
        Dim EntidadServicioUpdate As String = ""
        Dim EntidadServicioInsert As String = ""
        Dim EntidadVistaMantener As String = ""
        Dim EntidadVistaBuscar As String = ""
        Dim EntidadVistaValidar As String = ""
        Dim EntidadVistaListar As String = ""
        ' Definicio de datos de la tabla AttrEntidad
        Dim AttrEntidadId As Long = 0
        'Dim EntidadNombreTabla As String
        Dim AttrEntidadSecuencia As Long = 0
        Dim AttrEntidadColumnName As String = ""
        Dim AttrEntidadColumnDescription As String = ""
        Dim AttrEntidadColumnOrdinal As Long = 0
        Dim AttrEntidadColumnDataType As String = ""
        Dim AttrEntidadColumnSize As Long = 0
        Dim AttrEntidadIsRequerido As Boolean = False
        Dim AttrEntidadDomainField As String = ""
        Dim AttrEntidadIsForeignKey As Boolean = False
        Dim AttrEntidadForeignTable As String = ""
        Dim AttrEntidadForeignSQL As String = ""
        Dim AttrEntidadColumnLabel As String = ""
        Dim AttrEntidadColumnControlName As String = ""
        Dim AttrEntidadColumnControlBase As String = ""
        Dim AttrEntidadColumnTipoControl As String = ""
        Dim AttrEntidadColumnControlWidth As String = ""
        Dim AttrEntidadColumnTextMode As Long = 0
        Dim AttrEntidadColumnToolTip As String = ""
        Dim AttrEntidadIsFilterField As Boolean = False
        Dim AttrEntidadIsColumnField As Boolean = False
        Dim AttrEntidadColumnNumber As Long = 0
        Dim AttrEntidadColumnHeader As String = ""
        Dim AttrEntidadIsInVistaValidar As Boolean = False
        Dim AttrEntidadIsEnabledInVistaMantener As Boolean = False
        Dim AttrEntidadIsFormKeys As Boolean = False
        Dim AttrEntidadIsAutocomplete As Boolean = False
        Dim AttrEntidadAutocompleteMethod As String = ""
        Dim AttrEntidadColumnGroupNumber As Long = 0
        Dim AttrEntidadColumnGroupOrdinal As Long = 0
        Dim AttrEntidadColumnGroupName As String = ""
        ' Definición de la tabla PaginaWeb
        Dim PaginaWebId As Long = 0
        Dim PaginaWebName As String = ""
        Dim PaginaWebTitle As String = ""
        Dim PaginaWebDescription As String = ""
        Dim PaginaWebDescription2 As String = ""
        Dim FormularioWebNumber As Long = 0
        Dim PaginaWebGroupValidation As String = ""
        Dim PaginaWebStereotype As String = ""
        Dim PaginaWebUserControl As String = ""
        'Dim EntidadNombreTabla As String
        ' Definición de la tabla Formulario Web
        Dim FormularioWebId As Long
        'Dim FormularioWebNumber As Long
        Dim FormularioWebPId As Long
        Dim FormularioWebSecuencia As Long
        Dim FormularioWebGroupType As String
        Dim FormularioWebLabel As String
        Dim FormularioWebControl As String
        Dim FormularioWebTipoControl As String
        Dim FormularioWebControlBase As String
        Dim FormularioWebCssClassLabel As String
        Dim FormularioWebCssClassControl As String
        Dim FormularioWebLabelAlign As String
        Dim FormularioWebControlWidth As String
        Dim FormularioWebControlTextMode As Long
        Dim FormularioWebToolTip As String
        Dim FormularioWebIsRequiredField As Boolean
        Dim FormularioWebIsNotEnabled As Boolean
        Dim FormularioWebDomainField As String = ""
        Dim FormularioWebDataTextField As String = ""
        Dim FormularioWebTipoDatos As String = ""
        Dim FormularioWebDataFile As String
        Dim FormularioWebSelectCommand As String
        Dim FormularioWebSection As String
        Dim FormularioWebGroupValidation As String
        Dim FormularioWebEvent As String
        Dim FormularioWebPageCall As String
        Dim FormularioWebFormCall As String
        Dim FormularioWebURL As String = ""
        Dim FormularioWebServiceCall As String = ""
        Dim FormularioWebIsPerfilable As Boolean
        Dim FormularioWebIsAbleToDisappear As Boolean
        Dim FormularioWebIsVisibleToInit As Boolean
        Dim FormularioWebDescription As String = ""


        'Este metodo genera un registro en la tabla PaginaWeb y los registros que correspondan en la 
        'tabla FormularioWeb con el fin de generar la vista que permite obtener una lista de las instancias
        'de la Entidad de Negocio indicada por el usuario en la variable NombreEntidad

        '---------------------------------------------------------------------------------------------
        '       Inserta registro en la tabla PaginaWeb
        '---------------------------------------------------------------------------------------------

        ' Prepara Datos para hacer la inserción del registro en la tabla PaginaWeb.

        Try
            EntidadNombreTabla = NombreTabla
            t = Entidad.LeerEntidadByName(EntidadId, EntidadNombreTabla, EntidadNombreEntidad, EntidadDescription, EntidadTipo, EntidadCampoId, EntidadCampoName, EntidadCampoSecuencia, EntidadNombreTablaPadre, EntidadMasterId, EntidadMasterName, EntidadNombreClase, EntidadServicioLectura, EntidadServicioUpdate, EntidadServicioInsert, EntidadVistaMantener, EntidadVistaBuscar, EntidadVistaValidar, EntidadVistaListar)

            PaginaWebName = EntidadVistaValidar
            PaginaWebTitle = "Mantención de datos de " & EntidadNombreEntidad
            PaginaWebDescription = "Ingrese los datos solicitados, para validar que no exista previamente y asi evitar duplicar registros"
            PaginaWebDescription2 = ""
            FormularioWebNumber = Formularioweb.CalcularNextFormularioWebNumber
            PaginaWebGroupValidation = "InputValidation"
            PaginaWebStereotype = "DataEntry"
            PaginaWebUserControl = "Valida" & EntidadNombreClase & ".ascx"

            t = PaginaWeb.PaginaWebInsert(PaginaWebId, PaginaWebName, PaginaWebTitle, PaginaWebDescription, PaginaWebDescription2, FormularioWebNumber, PaginaWebGroupValidation, PaginaWebStereotype, PaginaWebUserControl, EntidadNombreTabla, UserId)

            ' Inserción del o los controles que conforman las claves únicas de la entidad (FormKeys)
            ' Sabemos que las FormKeys conforman el grupo 0 de los atributos de la Entidad
            ' Nos vamos directos a insertar los registros que corresponden a las claves de la entidad
            ' Cambio del 08-11-2010
            ' Vamos a seleccionar los campos que estas marcados con el atributo AttrEntidadIsFormKeys en true.

            Dim PIdLeaf As Long = 0
            Dim LeafSecuencia = 0
            Dim sSQL As String = ""
            sSQL = "Select EntidadNombreTabla, AttrEntidadSecuencia, AttrEntidadColumnName, AttrEntidadColumnDescription, AttrEntidadColumnOrdinal, AttrEntidadColumnDataType, AttrEntidadColumnSize, AttrEntidadIsRequerido, AttrEntidadDomainField, AttrEntidadIsForeignKey, AttrEntidadForeignTable, AttrEntidadForeignSQL, AttrEntidadColumnLabel, AttrEntidadColumnControlName, AttrEntidadColumnControlBase, AttrEntidadColumnTipoControl, AttrEntidadColumnControlWidth, AttrEntidadColumnTextMode, AttrEntidadColumnToolTip, AttrEntidadIsFilterField, AttrEntidadIsColumnField, AttrEntidadColumnNumber, AttrEntidadColumnHeader, AttrEntidadIsInVistaValidar, AttrEntidadIsEnabledInVistaMantener, AttrEntidadIsAutocomplete, AttrEntidadAutocompleteMethod, AttrEntidadColumnGroupNumber, AttrEntidadColumnGroupOrdinal, AttrEntidadColumnGroupName "
            sSQL = sSQL & "FROM AttrEntidad "
            sSQL = sSQL & "Where AttrEntidad.AttrEntidadIsFormKeys = true and AttrEntidad.EntidadNombreTabla = '" & NombreTabla & "' order by AttrEntidad.AttrEntidadColumnGroupOrdinal"

            dtrLeaf = AccesoEA.ListarRegistros(sSQL)
            While dtrLeaf.Read
                FormularioWebPId = PIdLeaf
                LeafSecuencia = LeafSecuencia + 1
                FormularioWebSecuencia = LeafSecuencia
                FormularioWebGroupType = ""
                FormularioWebLabel = CStr(dtrLeaf("AttrEntidadColumnLabel").ToString)
                'FormularioWebControl = CStr(dtrLeaf("AttrEntidadColumnControlName").ToString)
                FormularioWebControl = "txtMasterName"
                FormularioWebTipoControl = CStr(dtrLeaf("AttrEntidadColumnTipoControl").ToString)
                FormularioWebControlBase = CStr(dtrLeaf("AttrEntidadColumnControlBase").ToString)
                FormularioWebCssClassLabel = "textocontgris10bold"
                FormularioWebCssClassControl = "textoboxgris"
                FormularioWebLabelAlign = "right"
                FormularioWebControlWidth = CStr(dtrLeaf("AttrEntidadColumnControlWidth").ToString)
                FormularioWebControlTextMode = CLng(dtrLeaf("AttrEntidadColumnTextMode").ToString)
                If FormularioWebControlTextMode = 1 Then FormularioWebControlWidth = "500px"
                FormularioWebToolTip = CStr(dtrLeaf("AttrEntidadColumnToolTip").ToString)
                FormularioWebIsRequiredField = Not CBool(dtrLeaf("AttrEntidadIsRequerido").ToString)
                FormularioWebIsNotEnabled = CBool(dtrLeaf("AttrEntidadIsEnabledInVistaMantener").ToString)
                FormularioWebDomainField = CStr(dtrLeaf("AttrEntidadDomainField").ToString)
                FormularioWebDataTextField = CStr(dtrLeaf("AttrEntidadColumnName").ToString)
                FormularioWebTipoDatos = CStr(dtrLeaf("AttrEntidadColumnDataType").ToString)
                FormularioWebDataFile = ""
                FormularioWebSelectCommand = ""
                FormularioWebSection = "Form"
                If FormularioWebIsRequiredField Then
                    FormularioWebGroupValidation = "InputValidation"
                Else
                    FormularioWebGroupValidation = ""
                End If
                FormularioWebEvent = ""
                FormularioWebPageCall = ""
                FormularioWebFormCall = ""
                FormularioWebURL = ""
                FormularioWebServiceCall = ""
                FormularioWebIsPerfilable = True
                FormularioWebIsAbleToDisappear = True
                FormularioWebIsVisibleToInit = True
                FormularioWebDescription = ""

                t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)
            End While


            ' Inserción de las filas con los botones de la vista

            FormularioWebPId = 0
            FormularioWebSecuencia = 1
            FormularioWebGroupType = ""
            FormularioWebLabel = "Validar"
            FormularioWebControl = "LoginButton"
            FormularioWebTipoControl = "Button"
            FormularioWebControlBase = "Button"
            FormularioWebCssClassLabel = "textocontgris10bold"
            FormularioWebCssClassControl = "boxceleste"
            FormularioWebLabelAlign = "left"
            FormularioWebControlWidth = "80px"
            FormularioWebControlTextMode = 0
            FormularioWebToolTip = "Presione para validar existencia previa del registro"
            FormularioWebIsRequiredField = True
            FormularioWebDataTextField = ""
            FormularioWebTipoDatos = ""
            FormularioWebDataFile = ""
            FormularioWebSelectCommand = ""
            FormularioWebSection = "Button"
            FormularioWebGroupValidation = "InputValidation"
            FormularioWebEvent = "URLLogin"
            FormularioWebPageCall = MasterPage
            FormularioWebFormCall = EntidadVistaMantener

            t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)

            FormularioWebPId = 0
            FormularioWebSecuencia = 2
            FormularioWebGroupType = ""
            FormularioWebLabel = "Cancelar"
            FormularioWebControl = "CancelButton"
            FormularioWebTipoControl = "Button"
            FormularioWebControlBase = "Button"
            FormularioWebCssClassLabel = "textocontgris10bold"
            FormularioWebCssClassControl = "boxceleste"
            FormularioWebLabelAlign = "left"
            FormularioWebControlWidth = "80px"
            FormularioWebControlTextMode = 0
            FormularioWebToolTip = "Presione para cancelar y anular la creación de un nuevo registro"
            FormularioWebIsRequiredField = False
            FormularioWebDataTextField = ""
            FormularioWebTipoDatos = ""
            FormularioWebDataFile = ""
            FormularioWebSelectCommand = ""
            FormularioWebSection = "Button"
            FormularioWebGroupValidation = "NO"
            FormularioWebEvent = "URLLogout"
            FormularioWebPageCall = MasterPage
            FormularioWebFormCall = EntidadVistaListar

            t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)


            ' Puede que la Entidad sea padre de una o más entidades hijas, en cuyo caso se debe crear un tabcontainer para cada entidad hija
            ' Luego bajo cada tabcontainer se debe agregar una lista de las columnas que deben aparecer por cada entidad hija, encabezadas a su vez por un link que permita agregar una nueva instancia de la entidad hija.
            ' Comencemos por examinar si la entidad posee entidades hijas.

            ' Esto lo hacemos leyendo sobre la misma tabla Entidad para obtener la lista de entidades hijas.



            CrearPaginaWebTipoValidar = True
        Catch ex As Exception
            CrearPaginaWebTipoValidar = False
        End Try

    End Function

    Public Function CrearPaginaWebTipoBuscar(ByVal NombreTabla As String, _
                                             ByVal MasterPage As String, _
                                         ByVal UserId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim dtrLeaf As IDataReader
        Dim TablaHija As String = ""
        Dim sqlSelect As String = "Select " & TablaHija & "." & CampoIdentity(TablaHija) & " As Id"

        Dim Entidad As New Entidad
        Dim AttrEntidad As New AttrEntidad
        Dim PaginaWeb As New PaginaWeb
        Dim Formularioweb As New FormularioWeb
        Dim VistaMantener As String = ""

        Dim t As Integer = 0

        ' Definición de datos de la tabla Entidad
        Dim EntidadId As Long = 0
        Dim EntidadNombreTabla As String = ""
        Dim EntidadNombreEntidad As String = ""
        Dim EntidadDescription As String = ""
        Dim EntidadTipo As String = ""
        Dim EntidadCampoId As String = ""
        Dim EntidadCampoName As String = ""
        Dim EntidadCampoSecuencia As String = ""
        Dim EntidadNombreTablaPadre As String = ""
        Dim EntidadMasterId As String = ""
        Dim EntidadMasterName As String = ""
        Dim EntidadNombreClase As String = ""
        Dim EntidadServicioLectura As String = ""
        Dim EntidadServicioUpdate As String = ""
        Dim EntidadServicioInsert As String = ""
        Dim EntidadVistaMantener As String = ""
        Dim EntidadVistaBuscar As String = ""
        Dim EntidadVistaValidar As String = ""
        Dim EntidadVistaListar As String = ""
        ' Definicio de datos de la tabla AttrEntidad
        Dim AttrEntidadId As Long = 0
        'Dim EntidadNombreTabla As String
        Dim AttrEntidadSecuencia As Long = 0
        Dim AttrEntidadColumnName As String = ""
        Dim AttrEntidadColumnDescription As String = ""
        Dim AttrEntidadColumnOrdinal As Long = 0
        Dim AttrEntidadColumnDataType As String = ""
        Dim AttrEntidadColumnSize As Long = 0
        Dim AttrEntidadIsRequerido As Boolean = False
        Dim AttrEntidadDomainField As String = ""
        Dim AttrEntidadIsForeignKey As Boolean = False
        Dim AttrEntidadForeignTable As String = ""
        Dim AttrEntidadForeignSQL As String = ""
        Dim AttrEntidadColumnLabel As String = ""
        Dim AttrEntidadColumnControlName As String = ""
        Dim AttrEntidadColumnControlBase As String = ""
        Dim AttrEntidadColumnTipoControl As String = ""
        Dim AttrEntidadColumnControlWidth As String = ""
        Dim AttrEntidadColumnTextMode As Long = 0
        Dim AttrEntidadColumnToolTip As String = ""
        Dim AttrEntidadIsFilterField As Boolean = False
        Dim AttrEntidadIsColumnField As Boolean = False
        Dim AttrEntidadColumnNumber As Long = 0
        Dim AttrEntidadColumnHeader As String = ""
        Dim AttrEntidadIsInVistaValidar As Boolean = False
        Dim AttrEntidadIsEnabledInVistaMantener As Boolean = False
        Dim AttrEntidadIsFormKeys As Boolean = False
        Dim AttrEntidadIsAutocomplete As Boolean = False
        Dim AttrEntidadAutocompleteMethod As String = ""
        Dim AttrEntidadColumnGroupNumber As Long = 0
        Dim AttrEntidadColumnGroupOrdinal As Long = 0
        Dim AttrEntidadColumnGroupName As String = ""
        ' Definición de la tabla PaginaWeb
        Dim PaginaWebId As Long = 0
        Dim PaginaWebName As String = ""
        Dim PaginaWebTitle As String = ""
        Dim PaginaWebDescription As String = ""
        Dim PaginaWebDescription2 As String = ""
        Dim FormularioWebNumber As Long = 0
        Dim PaginaWebGroupValidation As String = ""
        Dim PaginaWebStereotype As String = ""
        Dim PaginaWebUserControl As String = ""
        'Dim EntidadNombreTabla As String
        ' Definición de la tabla Formulario Web
        Dim FormularioWebId As Long
        'Dim FormularioWebNumber As Long
        Dim FormularioWebPId As Long
        Dim FormularioWebSecuencia As Long
        Dim FormularioWebGroupType As String
        Dim FormularioWebLabel As String
        Dim FormularioWebControl As String
        Dim FormularioWebTipoControl As String
        Dim FormularioWebControlBase As String
        Dim FormularioWebCssClassLabel As String
        Dim FormularioWebCssClassControl As String
        Dim FormularioWebLabelAlign As String
        Dim FormularioWebControlWidth As String
        Dim FormularioWebControlTextMode As Long
        Dim FormularioWebToolTip As String
        Dim FormularioWebIsRequiredField As Boolean
        Dim FormularioWebIsNotEnabled As Boolean
        Dim FormularioWebDomainField As String = ""
        Dim FormularioWebDataTextField As String = ""
        Dim FormularioWebTipoDatos As String = ""
        Dim FormularioWebDataFile As String
        Dim FormularioWebSelectCommand As String
        Dim FormularioWebSection As String
        Dim FormularioWebGroupValidation As String
        Dim FormularioWebEvent As String
        Dim FormularioWebPageCall As String
        Dim FormularioWebFormCall As String
        Dim FormularioWebURL As String = ""
        Dim FormularioWebServiceCall As String = ""
        Dim FormularioWebIsPerfilable As Boolean
        Dim FormularioWebIsAbleToDisappear As Boolean
        Dim FormularioWebIsVisibleToInit As Boolean
        Dim FormularioWebDescription As String = ""


        'Este metodo genera un registro en la tabla PaginaWeb y los registros que correspondan en la 
        'tabla FormularioWeb con el fin de generar la vista que permite obtener una lista de las instancias
        'de la Entidad de Negocio indicada por el usuario en la variable NombreEntidad

        '---------------------------------------------------------------------------------------------
        '       Inserta registro en la tabla PaginaWeb
        '---------------------------------------------------------------------------------------------

        ' Prepara Datos para hacer la inserción del registro en la tabla PaginaWeb.

        Try
            EntidadNombreTabla = NombreTabla
            t = Entidad.LeerEntidadByName(EntidadId, EntidadNombreTabla, EntidadNombreEntidad, EntidadDescription, EntidadTipo, EntidadCampoId, EntidadCampoName, EntidadCampoSecuencia, EntidadNombreTablaPadre, EntidadMasterId, EntidadMasterName, EntidadNombreClase, EntidadServicioLectura, EntidadServicioUpdate, EntidadServicioInsert, EntidadVistaMantener, EntidadVistaBuscar, EntidadVistaValidar, EntidadVistaListar)

            PaginaWebName = EntidadVistaBuscar
            PaginaWebTitle = "Mantención de datos de " & EntidadNombreEntidad
            PaginaWebDescription = "Seleccione los valores de los campos de búsqueda y luego presione el botón Buscar para obtener la lista de los registros que cumplen con el criterio de busqueda indicado o presione el botón Cancelar para volver a la página anterior"
            PaginaWebDescription2 = ""
            FormularioWebNumber = Formularioweb.CalcularNextFormularioWebNumber
            PaginaWebGroupValidation = ""
            PaginaWebStereotype = "Finder"
            PaginaWebUserControl = "Busca" & EntidadNombreClase & ".ascx"

            t = PaginaWeb.PaginaWebInsert(PaginaWebId, PaginaWebName, PaginaWebTitle, PaginaWebDescription, PaginaWebDescription2, FormularioWebNumber, PaginaWebGroupValidation, PaginaWebStereotype, PaginaWebUserControl, EntidadNombreTabla, UserId)

            ' Inserción del o los controles que conforman las claves únicas de la entidad (FormKeys)
            ' Sabemos que las FormKeys conforman el grupo 0 de los atributos de la Entidad
            ' Nos vamos directos a insertar los registros que corresponden a las claves de la entidad
            ' Cambio del 08-11-2010
            ' Vamos a seleccionar los campos que estas marcados con el atributo AttrEntidadIsFormKeys en true.

            Dim PIdLeaf As Long = 0
            Dim LeafSecuencia = 0
            Dim sSQL As String = ""
            sSQL = "Select EntidadNombreTabla, AttrEntidadSecuencia, AttrEntidadColumnName, AttrEntidadColumnDescription, AttrEntidadColumnOrdinal, AttrEntidadColumnDataType, AttrEntidadColumnSize, AttrEntidadIsRequerido, AttrEntidadDomainField, AttrEntidadIsForeignKey, AttrEntidadForeignTable, AttrEntidadForeignSQL, AttrEntidadColumnLabel, AttrEntidadColumnControlName, AttrEntidadColumnControlBase, AttrEntidadColumnTipoControl, AttrEntidadColumnControlWidth, AttrEntidadColumnTextMode, AttrEntidadColumnToolTip, AttrEntidadIsFilterField, AttrEntidadIsColumnField, AttrEntidadColumnNumber, AttrEntidadColumnHeader, AttrEntidadIsInVistaValidar, AttrEntidadIsEnabledInVistaMantener, AttrEntidadIsAutocomplete, AttrEntidadAutocompleteMethod, AttrEntidadColumnGroupNumber, AttrEntidadColumnGroupOrdinal, AttrEntidadColumnGroupName "
            sSQL = sSQL & "FROM AttrEntidad "
            sSQL = sSQL & "Where AttrEntidad.AttrEntidadIsFilterField = true and AttrEntidad.EntidadNombreTabla = '" & NombreTabla & "' order by AttrEntidad.AttrEntidadSecuencia"

            dtrLeaf = AccesoEA.ListarRegistros(sSQL)
            While dtrLeaf.Read
                FormularioWebPId = PIdLeaf
                LeafSecuencia = LeafSecuencia + 1
                FormularioWebSecuencia = LeafSecuencia
                FormularioWebGroupType = ""
                FormularioWebLabel = CStr(dtrLeaf("AttrEntidadColumnLabel").ToString)
                FormularioWebControl = CStr(dtrLeaf("AttrEntidadColumnControlName").ToString)
                FormularioWebTipoControl = "DropDownSearch"
                FormularioWebControlBase = "DropDownList"
                FormularioWebCssClassLabel = "textocontgris10bold"
                FormularioWebCssClassControl = "textoboxgris"
                FormularioWebLabelAlign = "right"
                FormularioWebControlWidth = CStr(dtrLeaf("AttrEntidadColumnControlWidth").ToString)
                FormularioWebControlTextMode = CLng(dtrLeaf("AttrEntidadColumnTextMode").ToString)
                If FormularioWebControlTextMode = 1 Then FormularioWebControlWidth = "500px"
                FormularioWebToolTip = CStr(dtrLeaf("AttrEntidadColumnToolTip").ToString)
                FormularioWebIsRequiredField = False
                FormularioWebIsNotEnabled = False
                FormularioWebDomainField = CStr(dtrLeaf("AttrEntidadDomainField").ToString)
                FormularioWebDataTextField = CStr(dtrLeaf("AttrEntidadColumnName").ToString)
                FormularioWebTipoDatos = CStr(dtrLeaf("AttrEntidadColumnDataType").ToString)
                FormularioWebDataFile = "App_Data\BDCAS.mdb"
                FormularioWebSelectCommand = "SELECT distinct " & NombreTabla & ".[" & FormularioWebDataTextField & "] FROM " & NombreTabla
                FormularioWebSection = "Form"
                If FormularioWebIsRequiredField Then
                    FormularioWebGroupValidation = "InputValidation"
                Else
                    FormularioWebGroupValidation = "NO"
                End If
                FormularioWebEvent = ""
                FormularioWebPageCall = ""
                FormularioWebFormCall = ""
                FormularioWebURL = ""
                FormularioWebServiceCall = ""
                FormularioWebIsPerfilable = True
                FormularioWebIsAbleToDisappear = True
                FormularioWebIsVisibleToInit = True
                FormularioWebDescription = ""

                t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)
            End While


            ' Inserción de las filas con los botones de la vista

            FormularioWebPId = 0
            FormularioWebSecuencia = 1
            FormularioWebGroupType = ""
            FormularioWebLabel = "Buscar"
            FormularioWebControl = "UpdateButton"
            FormularioWebTipoControl = "Button"
            FormularioWebControlBase = "Button"
            FormularioWebCssClassLabel = "textocontgris10bold"
            FormularioWebCssClassControl = "boxceleste"
            FormularioWebLabelAlign = "left"
            FormularioWebControlWidth = "80px"
            FormularioWebControlTextMode = 0
            FormularioWebToolTip = "Presione para buscar registros que cumplan con el criterio de selección"
            FormularioWebIsRequiredField = False
            FormularioWebDataTextField = ""
            FormularioWebTipoDatos = ""
            FormularioWebDataFile = ""
            FormularioWebSelectCommand = ""
            FormularioWebSection = "Button"
            FormularioWebGroupValidation = "NO"
            FormularioWebEvent = "URLUpdate"
            FormularioWebPageCall = MasterPage
            FormularioWebFormCall = EntidadVistaListar

            t = Formularioweb.FormularioWebInsert(FormularioWebId, FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription, UserId)


            CrearPaginaWebTipoBuscar = True
        Catch ex As Exception
            CrearPaginaWebTipoBuscar = False
        End Try

    End Function


End Class
