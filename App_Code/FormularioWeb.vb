'------------------------------------------------------------
' Código generado por ZRISMART SF el 24-08-2010 19:36:47
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class FormularioWeb
    Public Function LeerFormularioWeb(ByVal FormularioWebId As Long, ByRef FormularioWebNumber As Long, ByRef FormularioWebPId As Long, ByRef FormularioWebSecuencia As Long, ByRef FormularioWebGroupType As String, ByRef FormularioWebLabel As String, ByRef FormularioWebControl As String, ByRef FormularioWebTipoControl As String, ByRef FormularioWebControlBase As String, ByRef FormularioWebCssClassLabel As String, ByRef FormularioWebCssClassControl As String, ByRef FormularioWebLabelAlign As String, ByRef FormularioWebControlWidth As String, ByRef FormularioWebControlTextMode As Long, ByRef FormularioWebToolTip As String, ByRef FormularioWebIsRequiredField As Boolean, ByRef FormularioWebIsNotEnabled As Boolean, ByRef FormularioWebDomainField As String, ByRef FormularioWebDataTextField As String, ByRef FormularioWebTipoDatos As String, ByRef FormularioWebDataFile As String, ByRef FormularioWebSelectCommand As String, ByRef FormularioWebSection As String, ByRef FormularioWebGroupValidation As String, ByRef FormularioWebEvent As String, ByRef FormularioWebPageCall As String, ByRef FormularioWebFormCall As String, ByRef FormularioWebURL As String, ByRef FormularioWebServiceCall As String, ByRef FormularioWebIsPerfilable As Boolean, ByRef FormularioWebIsAbleToDisappear As Boolean, ByRef FormularioWebIsVisibleToInit As Boolean, ByRef FormularioWebDescription As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select FormularioWebNumber, FormularioWebPId, FormularioWebSecuencia, FormularioWebGroupType, FormularioWebLabel, FormularioWebControl, FormularioWebTipoControl, FormularioWebControlBase, FormularioWebCssClassLabel, FormularioWebCssClassControl, FormularioWebLabelAlign, FormularioWebControlWidth, FormularioWebControlTextMode, FormularioWebToolTip, FormularioWebIsRequiredField, FormularioWebIsNotEnabled, FormularioWebDomainField, FormularioWebDataTextField, FormularioWebTipoDatos, FormularioWebDataFile, FormularioWebSelectCommand, FormularioWebSection, FormularioWebGroupValidation, FormularioWebEvent, FormularioWebPageCall, FormularioWebFormCall, FormularioWebURL, FormularioWebServiceCall, FormularioWebIsPerfilable, FormularioWebIsAbleToDisappear, FormularioWebIsVisibleToInit, FormularioWebDescription "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE (FormularioWeb.FormularioWebId = " & FormularioWebId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                FormularioWebNumber = CLng(dtr("FormularioWebNumber").ToString)
                FormularioWebPId = CLng(dtr("FormularioWebPId").ToString)
                FormularioWebSecuencia = CLng(dtr("FormularioWebSecuencia").ToString)
                FormularioWebGroupType = CStr(dtr("FormularioWebGroupType").ToString)
                FormularioWebLabel = CStr(dtr("FormularioWebLabel").ToString)
                FormularioWebControl = CStr(dtr("FormularioWebControl").ToString)
                FormularioWebTipoControl = CStr(dtr("FormularioWebTipoControl").ToString)
                FormularioWebControlBase = CStr(dtr("FormularioWebControlBase").ToString)
                FormularioWebCssClassLabel = CStr(dtr("FormularioWebCssClassLabel").ToString)
                FormularioWebCssClassControl = CStr(dtr("FormularioWebCssClassControl").ToString)
                FormularioWebLabelAlign = CStr(dtr("FormularioWebLabelAlign").ToString)
                FormularioWebControlWidth = CStr(dtr("FormularioWebControlWidth").ToString)
                FormularioWebControlTextMode = CLng(dtr("FormularioWebControlTextMode").ToString)
                FormularioWebToolTip = CStr(dtr("FormularioWebToolTip").ToString)
                FormularioWebIsRequiredField = CBool(dtr("FormularioWebIsRequiredField").ToString)
                FormularioWebIsNotEnabled = CBool(dtr("FormularioWebIsNotEnabled").ToString)
                FormularioWebDomainField = CStr(dtr("FormularioWebDomainField").ToString)
                FormularioWebDataTextField = CStr(dtr("FormularioWebDataTextField").ToString)
                FormularioWebTipoDatos = CStr(dtr("FormularioWebTipoDatos").ToString)
                FormularioWebDataFile = CStr(dtr("FormularioWebDataFile").ToString)
                FormularioWebSelectCommand = CStr(dtr("FormularioWebSelectCommand").ToString)
                FormularioWebSection = CStr(dtr("FormularioWebSection").ToString)
                FormularioWebGroupValidation = CStr(dtr("FormularioWebGroupValidation").ToString)
                FormularioWebEvent = CStr(dtr("FormularioWebEvent").ToString)
                FormularioWebPageCall = CStr(dtr("FormularioWebPageCall").ToString)
                FormularioWebFormCall = CStr(dtr("FormularioWebFormCall").ToString)
                FormularioWebURL = CStr(dtr("FormularioWebURL").ToString)
                FormularioWebServiceCall = CStr(dtr("FormularioWebServiceCall").ToString)
                FormularioWebIsPerfilable = CBool(dtr("FormularioWebIsPerfilable").ToString)
                FormularioWebIsAbleToDisappear = CBool(dtr("FormularioWebIsAbleToDisappear").ToString)
                FormularioWebIsVisibleToInit = CBool(dtr("FormularioWebIsVisibleToInit").ToString)
                FormularioWebDescription = CStr(dtr("FormularioWebDescription").ToString)
            End While
            LeerFormularioWeb = True
            dtr.Close()
        Catch
            LeerFormularioWeb = False
        End Try
    End Function
    Public Function FormularioWebUpdate(ByVal FormularioWebId As Long, ByRef FormularioWebNumber As Long, ByRef FormularioWebPId As Long, ByRef FormularioWebSecuencia As Long, ByRef FormularioWebGroupType As String, ByRef FormularioWebLabel As String, ByRef FormularioWebControl As String, ByRef FormularioWebTipoControl As String, ByRef FormularioWebControlBase As String, ByRef FormularioWebCssClassLabel As String, ByRef FormularioWebCssClassControl As String, ByRef FormularioWebLabelAlign As String, ByRef FormularioWebControlWidth As String, ByRef FormularioWebControlTextMode As Long, ByRef FormularioWebToolTip As String, ByRef FormularioWebIsRequiredField As Boolean, ByRef FormularioWebIsNotEnabled As Boolean, ByRef FormularioWebDomainField As String, ByRef FormularioWebDataTextField As String, ByRef FormularioWebTipoDatos As String, ByRef FormularioWebDataFile As String, ByRef FormularioWebSelectCommand As String, ByRef FormularioWebSection As String, ByRef FormularioWebGroupValidation As String, ByRef FormularioWebEvent As String, ByRef FormularioWebPageCall As String, ByRef FormularioWebFormCall As String, ByRef FormularioWebURL As String, ByRef FormularioWebServiceCall As String, ByRef FormularioWebIsPerfilable As Boolean, ByRef FormularioWebIsAbleToDisappear As Boolean, ByRef FormularioWebIsVisibleToInit As Boolean, ByRef FormularioWebDescription As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE FormularioWeb SET "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebNumber = " & FormularioWebNumber & ", "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebPId = " & FormularioWebPId & ", "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebSecuencia = " & FormularioWebSecuencia & ", "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebGroupType = '" & FormularioWebGroupType & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebLabel = '" & FormularioWebLabel & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebControl = '" & FormularioWebControl & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebTipoControl = '" & FormularioWebTipoControl & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebControlBase = '" & FormularioWebControlBase & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebCssClassLabel = '" & FormularioWebCssClassLabel & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebCssClassControl = '" & FormularioWebCssClassControl & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebLabelAlign = '" & FormularioWebLabelAlign & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebControlWidth = '" & FormularioWebControlWidth & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebControlTextMode = " & FormularioWebControlTextMode & ", "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebToolTip = '" & FormularioWebToolTip & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebIsRequiredField = " & FormularioWebIsRequiredField & ", "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebIsNotEnabled = " & FormularioWebIsNotEnabled & ", "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebDomainField = '" & FormularioWebDomainField & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebDataTextField = '" & FormularioWebDataTextField & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebTipoDatos = '" & FormularioWebTipoDatos & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebDataFile = '" & FormularioWebDataFile & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebSelectCommand = '" & FormularioWebSelectCommand & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebSection = '" & FormularioWebSection & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebGroupValidation = '" & FormularioWebGroupValidation & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebEvent = '" & FormularioWebEvent & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebPageCall = '" & FormularioWebPageCall & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebFormCall = '" & FormularioWebFormCall & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebURL = '" & FormularioWebURL & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebServiceCall = '" & FormularioWebServiceCall & "', "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebIsPerfilable = " & FormularioWebIsPerfilable & ", "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebIsAbleToDisappear = " & FormularioWebIsAbleToDisappear & ", "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebIsVisibleToInit = " & FormularioWebIsVisibleToInit & ", "
        strUpdate = strUpdate & "FormularioWeb.FormularioWebDescription = '" & FormularioWebDescription & "', "
        strUpdate = strUpdate & "FormularioWeb.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "FormularioWeb.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE FormularioWeb.FormularioWebId = " & FormularioWebId
        Try
            FormularioWebUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & FormularioWebNumber, FormularioWebId, "FormularioWeb", "")
        Catch
            FormularioWebUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & FormularioWebNumber, FormularioWebId, "FormularioWeb", "")
        End Try
    End Function
    Public Function FormularioWebInsert(ByRef FormularioWebId As Long, ByRef FormularioWebNumber As Long, ByRef FormularioWebPId As Long, ByRef FormularioWebSecuencia As Long, ByRef FormularioWebGroupType As String, ByRef FormularioWebLabel As String, ByRef FormularioWebControl As String, ByRef FormularioWebTipoControl As String, ByRef FormularioWebControlBase As String, ByRef FormularioWebCssClassLabel As String, ByRef FormularioWebCssClassControl As String, ByRef FormularioWebLabelAlign As String, ByRef FormularioWebControlWidth As String, ByRef FormularioWebControlTextMode As Long, ByRef FormularioWebToolTip As String, ByRef FormularioWebIsRequiredField As Boolean, ByRef FormularioWebIsNotEnabled As Boolean, ByRef FormularioWebDomainField As String, ByRef FormularioWebDataTextField As String, ByRef FormularioWebTipoDatos As String, ByRef FormularioWebDataFile As String, ByRef FormularioWebSelectCommand As String, ByRef FormularioWebSection As String, ByRef FormularioWebGroupValidation As String, ByRef FormularioWebEvent As String, ByRef FormularioWebPageCall As String, ByRef FormularioWebFormCall As String, ByRef FormularioWebURL As String, ByRef FormularioWebServiceCall As String, ByRef FormularioWebIsPerfilable As Boolean, ByRef FormularioWebIsAbleToDisappear As Boolean, ByRef FormularioWebIsVisibleToInit As Boolean, ByRef FormularioWebDescription As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim FormularioWeb As New FormularioWeb
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Try
            MasterName = FormularioWebSection
            MasterId = 0
            t = FormularioWeb.FormularioWebPartialInsert("FormularioWebId", "FormularioWebSection", "FormularioWeb", MasterName, CLng(UserId), MasterId)
            FormularioWebInsert = FormularioWeb.FormularioWebUpdate(MasterId, CLng(FormularioWebNumber), CLng(FormularioWebPId), CLng(FormularioWebSecuencia), CStr(FormularioWebGroupType), CStr(FormularioWebLabel), CStr(FormularioWebControl), CStr(FormularioWebTipoControl), CStr(FormularioWebControlBase), CStr(FormularioWebCssClassLabel), CStr(FormularioWebCssClassControl), CStr(FormularioWebLabelAlign), CStr(FormularioWebControlWidth), CLng(FormularioWebControlTextMode), CStr(FormularioWebToolTip), CBool(FormularioWebIsRequiredField), CBool(FormularioWebIsNotEnabled), CStr(FormularioWebDomainField), CStr(FormularioWebDataTextField), CStr(FormularioWebTipoDatos), CStr(FormularioWebDataFile), CStr(FormularioWebSelectCommand), CStr(FormularioWebSection), CStr(FormularioWebGroupValidation), CStr(FormularioWebEvent), CStr(FormularioWebPageCall), CStr(FormularioWebFormCall), CStr(FormularioWebURL), CStr(FormularioWebServiceCall), CBool(FormularioWebIsPerfilable), CBool(FormularioWebIsAbleToDisappear), CBool(FormularioWebIsVisibleToInit), CStr(FormularioWebDescription), UserId)

        Catch
            FormularioWebInsert = 0
        End Try
        FormularioWebId = MasterId
    End Function
    Public Function FormularioWebPartialInsert(ByVal ObjectId As String, _
                                        ByVal ObjectName As String, _
                                        ByVal ObjectTable As String, _
                                        ByVal MasterName As String, _
                                        ByVal UserId As Long, _
                                        ByRef MasterId As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String

        Dim s As Integer

        strUpdate = "INSERT INTO " & ObjectTable & " (" & ObjectName & ", DateLastUpdate, UserLastUpdate) "
        strUpdate = strUpdate & "VALUES ('" & MasterName & "', '" & AccionesABM.DateTransform(Now()) & "', " & UserId & ")"

        Try
            FormularioWebPartialInsert = AccesoEA.ABMRegistros(strUpdate)
            MasterId = Lecturas.LeerMaximoId("Select Max(FormularioWebID) as MaximoId FROM (FormularioWeb)")
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Inserta " & MasterName, MasterId, ObjectTable, "")
        Catch
            FormularioWebPartialInsert = 0
            MasterId = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de insertar " & MasterName, MasterId, ObjectTable, "")
        End Try
    End Function
    Public Function CalcularNextFormularioWebNumber() As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select Max(FormularioWeb.FormularioWebNumber) as Maximo "
        sSQL = sSQL & "FROM FormularioWeb"

        CalcularNextFormularioWebNumber = 1

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                CalcularNextFormularioWebNumber = CLng(dtr("Maximo").ToString) + 1
            End While
            dtr.Close()
        Catch
            CalcularNextFormularioWebNumber = 1
        End Try
    End Function
    Public Function LeerControlesYCamposFormularioWebV2(ByRef ArrLabel() As String, ByRef ArrControl() As String, ByRef ArrDominios() As String, _
                                        ByRef FormularioWebNumber As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebControl, FormularioWebDataTextField, FormularioWebDomainField "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND FormularioWeb.FormularioWebSection = 'Form' )) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("FormularioWebDataTextField").ToString
                ArrControl(i) = dtr("FormularioWebControl").ToString
                ArrDominios(i) = dtr("FormularioWebDomainField").ToString
                i = i + 1
            End While
            LeerControlesYCamposFormularioWebV2 = True
            dtr.Close()
        Catch
            LeerControlesYCamposFormularioWebV2 = False
        End Try
    End Function
    Public Function LeerCheckFormularioWebV2(ByRef ArrLabel() As String, ByRef ArrControl() As String, ByVal ArrchkControl() As String, ByVal ArrTipos() As String, _
                                        ByRef FormularioWebNumber As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select 'chk' + FormularioWeb.FormularioWebControl + '.Checked' As CampoCheck, FormularioWeb.FormularioWebControl + '.Text' as CampoControl, FormularioWebDataTextField as Variable, FormularioWebTipoDatos as Tipos "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' OR FormularioWeb.FormularioWebSection = 'Form' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("Variable").ToString
                ArrControl(i) = dtr("CampoControl").ToString
                ArrchkControl(i) = dtr("CampoCheck").ToString
                ArrTipos(i) = dtr("Tipos").ToString
                i = i + 1
            End While
            LeerCheckFormularioWebV2 = True
            dtr.Close()
        Catch
            LeerCheckFormularioWebV2 = False
        End Try
    End Function
    Public Function LeerFormularioWebNumber(ByVal PaginaWebName As String) As Long
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select PaginaWeb.FormularioWebNumber "
        sSQL = sSQL & "FROM PaginaWeb "
        sSQL = sSQL & "WHERE ((PaginaWeb.PaginaWebName) = '" & PaginaWebName & "')"

        LeerFormularioWebNumber = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                LeerFormularioWebNumber = CLng(dtr("FormularioWebNumber").ToString)
            End While
            dtr.Close()
        Catch
            LeerFormularioWebNumber = 0

        End Try
    End Function
    Public Function LeerDeclaracionControlesFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                        ByRef FormularioWebNumber As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select 'Dim ' + FormularioWeb.FormularioWebControl + ' As ' + FormularioWeb.FormularioWebControlBase as Definicion, ' Etiqueta : ' + FormularioWebLabel + ' - Control : ' + FormularioWebControl + ' - Variable : ' + FormularioWebDataTextField as Glosa  "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' OR FormularioWeb.FormularioWebSection = 'Form' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("Glosa").ToString
                ArrControl(i) = dtr("Definicion").ToString
                i = i + 1
            End While
            LeerDeclaracionControlesFormularioWeb = True
            dtr.Close()
        Catch
            LeerDeclaracionControlesFormularioWeb = False
        End Try
    End Function
    Public Function LeerDeclaracionCamposFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                        ByRef FormularioWebNumber As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select 'Dim ' + FormularioWeb.FormularioWebDataTextField + ' As ' + FormularioWeb.FormularioWebTipoDatos as Definicion, ' Etiqueta : ' + FormularioWebLabel + ' - Control : ' + FormularioWebControl + ' - Variable : ' + FormularioWebDataTextField as Glosa "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE((FormularioWeb.FormularioWebNumber = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' OR FormularioWeb.FormularioWebSection = 'Form' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("Glosa").ToString
                ArrControl(i) = dtr("Definicion").ToString
                i = i + 1
            End While
            LeerDeclaracionCamposFormularioWeb = True
            dtr.Close()
        Catch
            LeerDeclaracionCamposFormularioWeb = False
        End Try
    End Function
    Public Function FormarStringUpdate(ByRef FormularioWebNumber As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim StringUpdate As String = ""

        sSQL = "Select FormularioWeb.FormularioWebControl as Definicion, FormularioWebTipoDatos as TipoDatos "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        FormarStringUpdate = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                Select Case dtr("TipoDatos")
                    Case "String"
                        StringUpdate = StringUpdate & "CStr(" & dtr("Definicion") & ".Text" & "), "
                    Case "Long"
                        StringUpdate = StringUpdate & "CLng(" & dtr("Definicion") & ".Text" & "), "
                    Case "Date"
                        StringUpdate = StringUpdate & "CDate(" & dtr("Definicion") & ".Text" & "), "
                    Case "Boolean"
                        StringUpdate = StringUpdate & "CBool(" & dtr("Definicion") & ".Checked" & "), "
                    Case "Double"
                        StringUpdate = StringUpdate & "CDbl(" & dtr("Definicion") & ".Text * 100" & "), "
                End Select
            End While
            dtr.Close()
        Catch
            StringUpdate = ""
        End Try

        sSQL = "Select FormularioWeb.FormularioWebControl as Definicion, FormularioWebTipoDatos as TipoDatos "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE((FormularioWeb.FormularioWebNumber = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'Form' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                Select Case dtr("TipoDatos")
                    Case "String"
                        StringUpdate = StringUpdate & "CStr(" & dtr("Definicion") & ".Text" & "), "
                    Case "Long"
                        StringUpdate = StringUpdate & "CLng(" & dtr("Definicion") & ".Text" & "), "
                    Case "Date"
                        StringUpdate = StringUpdate & "CDate(" & dtr("Definicion") & ".Text" & "), "
                    Case "Boolean"
                        StringUpdate = StringUpdate & "CBool(" & dtr("Definicion") & ".Checked" & "), "
                    Case "Double"
                        StringUpdate = StringUpdate & "CDbl(" & dtr("Definicion") & ".Text * 100" & "), "
                End Select
            End While
            FormarStringUpdate = StringUpdate
            dtr.Close()
        Catch
            FormarStringUpdate = ""
        End Try

    End Function
    Public Function FormarStringBinding(ByVal FormularioWebNumber As Long, ByRef arrBinding() As String, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim StringUpdate As String = ""

        sSQL = "Select FormularioWeb.FormularioWebDataTextField as Definicion, FormularioWebTipoDatos as TipoDatos "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' OR FormularioWeb.FormularioWebSection = 'Form' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"

        i = 0
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                Select Case dtr("TipoDatos")
                    Case "String"
                        arrBinding(i) = dtr("Definicion").ToString & " = " & "CStr(dtr(""" & dtr("Definicion") & """).ToString)"
                    Case "Long"
                        arrBinding(i) = dtr("Definicion").ToString & " = " & "CLng(dtr(""" & dtr("Definicion") & """).ToString)"
                    Case "Date"
                        arrBinding(i) = dtr("Definicion").ToString & " = " & "CDate(dtr(""" & dtr("Definicion") & """).ToString)"
                    Case "Boolean"
                        arrBinding(i) = dtr("Definicion").ToString & " = " & "CBool(dtr(""" & dtr("Definicion") & """).ToString)"
                End Select
                i = i + 1
            End While
            dtr.Close()
            FormarStringBinding = True
        Catch
            FormarStringBinding = False
        End Try

    End Function
    Public Function FormarStringLeer(ByRef FormularioWebNumber As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim StringLeer As String = ""

        sSQL = "Select FormularioWeb.FormularioWebDataTextField as Definicion "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        FormarStringLeer = ""
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                StringLeer = StringLeer & ", " & dtr("Definicion")
            End While
            dtr.Close()
        Catch
            StringLeer = ""
        End Try

        sSQL = "Select FormularioWeb.FormularioWebDataTextField as Definicion "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND (FormularioWeb.FormularioWebSection = 'Form'))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                StringLeer = StringLeer & ", " & dtr("Definicion")
            End While
            FormarStringLeer = StringLeer
            dtr.Close()
        Catch
            FormarStringLeer = ""
        End Try

    End Function
    Public Function LeerControlesYCamposFormularioWebKeys(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                        ByRef FormularioWebNumber As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebControl, FormularioWebDataTextField "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND FormularioWeb.FormularioWebSection = 'FormKeys' )) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("FormularioWebDataTextField").ToString
                ArrControl(i) = dtr("FormularioWebControl").ToString
                i = i + 1
            End While
            LeerControlesYCamposFormularioWebKeys = True
            dtr.Close()
        Catch
            LeerControlesYCamposFormularioWebKeys = False
        End Try
    End Function
    Public Function LeerControlesYCamposFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                        ByRef FormularioWebNumber As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebControl, FormularioWebDataTextField "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND FormularioWeb.FormularioWebSection = 'Form' )) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("FormularioWebDataTextField").ToString
                ArrControl(i) = dtr("FormularioWebControl").ToString
                i = i + 1
            End While
            LeerControlesYCamposFormularioWeb = True
            dtr.Close()
        Catch
            LeerControlesYCamposFormularioWeb = False
        End Try
    End Function
    Public Function LeerDeclaracionControlesCheckFormularioWeb(ByRef ArrLabel() As String, ByRef ArrControl() As String, _
                                        ByRef FormularioWebNumber As Long, ByRef i As Integer) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select 'Dim chk' + FormularioWeb.FormularioWebControl + ' As CheckBox' as Definicion, ' Etiqueta : ' + FormularioWebLabel + ' - Control : ' + FormularioWebControl + ' - Variable : ' + FormularioWebDataTextField as Glosa  "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE(((FormularioWeb.FormularioWebNumber) = " & FormularioWebNumber & " AND ( FormularioWeb.FormularioWebSection = 'FormKeys' OR FormularioWeb.FormularioWebSection = 'Form' ))) "
        sSQL = sSQL & "ORDER BY FormularioWeb.FormularioWebPId, FormularioWeb.FormularioWebSecuencia"
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                ArrLabel(i) = dtr("Glosa").ToString
                ArrControl(i) = dtr("Definicion").ToString
                i = i + 1
            End While
            LeerDeclaracionControlesCheckFormularioWeb = True
            dtr.Close()
        Catch
            LeerDeclaracionControlesCheckFormularioWeb = False
        End Try
    End Function
    Public Function CampoIsVisible(ByVal FormularioWebId As Long) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebIsVisibleToInit "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE (((FormularioWeb.FormularioWebId) = " & FormularioWebId & "))"

        CampoIsVisible = False

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                CampoIsVisible = CBool(dtr("FormularioWebIsVisibleToInit").ToString)
            End While
            dtr.Close()
        Catch
            CampoIsVisible = False
        End Try
    End Function
    Public Function CampoIsVisibleV2(ByVal Section As String, ByVal FormularioWebId As Long, ByVal i As Integer) As Boolean

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "Select FormularioWeb.FormularioWebIsVisibleToInit "
        sSQL = sSQL & "FROM FormularioWeb "
        sSQL = sSQL & "WHERE (((FormularioWeb.FormularioWebNumber) = " & FormularioWebId & " AND (FormularioWeb.FormularioWebSecuencia) = " & i & " AND (FormularioWeb.FormularioWebSection) = '" & Section & "')) "
        CampoIsVisibleV2 = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)

            While dtr.Read
                CampoIsVisibleV2 = CBool(dtr("FormularioWebIsVisibleToInit").ToString)
            End While
            dtr.Close()
        Catch
            CampoIsVisibleV2 = False
        End Try
    End Function

End Class
