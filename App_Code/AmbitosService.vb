Imports System
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports AjaxControlToolkit
Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Web.Script.Services
Imports System.Data.OleDb

' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class AmbitosService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function GetAmbitos(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim dtr As IDataReader
        Dim sSQL As String = "SELECT MenuOptions.Texto AS AmbitosName, MenuOptions.MenuOptionsId As AmbitosId FROM(MenuOptions) WHERE (((MenuOptions.PortalesName)='SGI') AND ((MenuOptions.Zona)='BarMenu')) ORDER BY MenuOptions.Secuencia"
        Dim makeValues As New List(Of CascadingDropDownNameValue)()

        dtr = AccesoEA.ListarRegistros(sSQL)
        While dtr.Read
            makeValues.Add(New CascadingDropDownNameValue(dtr("AmbitosName").ToString(), dtr("AmbitosId").ToString()))
        End While

        Return makeValues.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetHojas(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim kv As StringDictionary = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)
        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim dtr As IDataReader
        Dim sSQL As String = ""
        Dim SideBarName As String = ""


        Dim AmbitosId As Integer
        If ((Not kv.ContainsKey("Ambitos")) Or (Not Int32.TryParse(kv("Ambitos"), AmbitosId))) Then
            Return Nothing
        End If
        SideBarName = Lecturas.SideBarClassName(CLng(kv("Ambitos")))
        'Dim carModelAdapter As New dsCarModelsTableAdapters.CarModelsTableAdapter()

        sSQL = "SELECT MenuOptions.Texto AS HojasName, MenuOptions.MenuOptionsId as HojasId FROM MenuOptions "
        sSQL = sSQL & "WHERE (((MenuOptions.SideBarmenu)='" & SideBarName & "') AND ((MenuOptions.IsNodoHoja)='HOJA') AND ((MenuOptions.PortalesName)='SGI') AND ((MenuOptions.Zona)='SideBarMenu')) "
        sSQL = sSQL & "ORDER BY MenuOptions.Texto"


        Dim modelValues As New List(Of CascadingDropDownNameValue)()

        dtr = AccesoEA.ListarRegistros(sSQL)
        While dtr.Read
            modelValues.Add(New CascadingDropDownNameValue(dtr("HojasName").ToString(), dtr("HojasId").ToString()))
        End While

        Return modelValues.ToArray()
    End Function

    <WebMethod()> _
    Public Function GetDocumentos(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
        Dim kv As StringDictionary = CascadingDropDown.ParseKnownCategoryValuesString(knownCategoryValues)
        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim dtr As IDataReader
        Dim sSQL As String = ""
        Dim HojaName As String = ""

        Dim HojasId As Integer
        If ((Not kv.ContainsKey("Hojas")) Or (Not Int32.TryParse(kv("Hojas"), HojasId))) Then
            Return Nothing
        End If
        HojaName = Lecturas.HojaName(CLng(kv("Hojas")))
        'Dim carModelAdapter As New dsCarModelsTableAdapters.CarModelsTableAdapter()

        sSQL = "SELECT APIDocumentosSGI.GruposName + ' - ' + Cstr(APIDocumentosSGI.APIDocumentosSGISecuencia) +  ' - ' + DocumentosSGI.DocumentosSGINombre as DocumentosName, APIDocumentosSGI.APIDocumentosSGIId as DocumentosId "
        sSQL = sSQL & "FROM (APIDocumentosSGI INNER JOIN Grupos ON APIDocumentosSGI.GruposName = Grupos.GruposName) INNER JOIN DocumentosSGI ON APIDocumentosSGI.DocumentosSGICodigo = DocumentosSGI.DocumentosSGICodigo "
        sSQL = sSQL & "WHERE (((APIDocumentosSGI.APIDocumentosSGICodigo)='" & HojaName & "')) "
        sSQL = sSQL & "ORDER BY Grupos.GruposSecuencia, APIDocumentosSGI.APIDocumentosSGISecuencia"

        Dim modelValues As New List(Of CascadingDropDownNameValue)()

        dtr = AccesoEA.ListarRegistros(sSQL)
        While dtr.Read
            modelValues.Add(New CascadingDropDownNameValue(dtr("DocumentosName").ToString(), dtr("DocumentosId").ToString()))
        End While

        Return modelValues.ToArray()
    End Function

End Class