Imports System.Collections.Generic
Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Web.Script.Services

Namespace ZRISMART.NET

    <ScriptService()> _
    <WebService(Namespace:="http://services.zrismart.net/")> _
    <WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Public Class CintacDataBroker
        Inherits System.Web.Services.WebService


        <WebMethod()> _
        Public Function FuncionGetAll(ByVal ObjectId As Long) As List(Of Funcion)
            Return ZRISMART.NET.Funcion.GetAll(ObjectId)
        End Function
        <WebMethod()> _
        Public Function FuncionGetOne(ByVal ReqId As Integer) As Funcion
            Return ZRISMART.NET.Funcion.GetOne(ReqId)
        End Function
        <WebMethod()> _
        Public Function FuncionSave(ByVal funcion As Funcion) As Boolean
            Return ZRISMART.NET.Funcion.Save(funcion)
        End Function
        <WebMethod()> _
        Public Function DependenciaCargoUpdate(ByVal ObjectId As Long, ByVal NewParentId As Long) As Boolean
            Return ZRISMART.NET.Cargo.SaveNuevaDependencia(ObjectId, NewParentId)
        End Function



    End Class

End Namespace
