'------------------------------------------------------------
' Código generado por ZRISMART SF el 23-02-2012 12:25:58
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA
Public Class CarpetaJudicialGastos
    Public Function LeerCarpetaJudicialGastos(ByVal CarpetaJudicialGastosId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialGastosSecuencia As Long, ByRef CarpetaJudicialGastosFecha As Date, ByRef CarpetaJudicialGastosConcepto As String, ByRef CarpetaJudicialGastosDocumento As String, ByRef CarpetaJudicialGastosMonto As Double, ByRef CarpetaJudicialGastosDescription As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialCodigo, CarpetaJudicialGastosSecuencia, CarpetaJudicialGastosFecha, CarpetaJudicialGastosConcepto, CarpetaJudicialGastosDocumento, CarpetaJudicialGastosMonto, CarpetaJudicialGastosDescription "
        sSQL = sSQL & "FROM (CarpetaJudicialGastos) "
        sSQL = sSQL & "WHERE (CarpetaJudicialGastos.CarpetaJudicialGastosId = " & CarpetaJudicialGastosId & ") "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CarpetaJudicialCodigo = CStr(dtr("CarpetaJudicialCodigo").ToString)
                If Len(dtr("CarpetaJudicialGastosSecuencia").ToString) = 0 Then
                    CarpetaJudicialGastosSecuencia = 0
                Else
                    CarpetaJudicialGastosSecuencia = CLng(dtr("CarpetaJudicialGastosSecuencia").ToString)
                End If
                If Len(dtr("CarpetaJudicialGastosFecha").ToString) = 0 Then
                    CarpetaJudicialGastosFecha = "01/01/01"
                Else
                    CarpetaJudicialGastosFecha = CDate(dtr("CarpetaJudicialGastosFecha").ToString)
                End If
                CarpetaJudicialGastosConcepto = CStr(dtr("CarpetaJudicialGastosConcepto").ToString)
                CarpetaJudicialGastosDocumento = CStr(dtr("CarpetaJudicialGastosDocumento").ToString)
                If Len(dtr("CarpetaJudicialGastosMonto").ToString) = 0 Then
                    CarpetaJudicialGastosMonto = 0
                Else
                    CarpetaJudicialGastosMonto = CDbl(dtr("CarpetaJudicialGastosMonto").ToString)
                End If
                CarpetaJudicialGastosDescription = CStr(dtr("CarpetaJudicialGastosDescription").ToString)
            End While
            LeerCarpetaJudicialGastos = True
            dtr.Close()
        Catch
            LeerCarpetaJudicialGastos = False
        End Try
    End Function
    Public Function CarpetaJudicialGastosUpdate(ByVal CarpetaJudicialGastosId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialGastosSecuencia As Long, ByRef CarpetaJudicialGastosFecha As Date, ByRef CarpetaJudicialGastosConcepto As String, ByRef CarpetaJudicialGastosDocumento As String, ByRef CarpetaJudicialGastosMonto As Double, ByRef CarpetaJudicialGastosDescription As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        strUpdate = "UPDATE CarpetaJudicialGastos SET "
        strUpdate = strUpdate & "CarpetaJudicialGastos.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialGastos.CarpetaJudicialGastosSecuencia = " & CarpetaJudicialGastosSecuencia & ", "
        strUpdate = strUpdate & "CarpetaJudicialGastos.CarpetaJudicialGastosFecha = '" & AccionesABM.DateTransform(CarpetaJudicialGastosFecha) & "', "
        strUpdate = strUpdate & "CarpetaJudicialGastos.CarpetaJudicialGastosConcepto = '" & CarpetaJudicialGastosConcepto & "', "
        strUpdate = strUpdate & "CarpetaJudicialGastos.CarpetaJudicialGastosDocumento = '" & CarpetaJudicialGastosDocumento & "', "
        strUpdate = strUpdate & "CarpetaJudicialGastos.CarpetaJudicialGastosMonto = " & CarpetaJudicialGastosMonto & ", "
        strUpdate = strUpdate & "CarpetaJudicialGastos.CarpetaJudicialGastosDescription = '" & CarpetaJudicialGastosDescription & "', "
        strUpdate = strUpdate & "CarpetaJudicialGastos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicialGastos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicialGastos.CarpetaJudicialGastosId = " & CarpetaJudicialGastosId
        Try
            CarpetaJudicialGastosUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & CarpetaJudicialCodigo, CarpetaJudicialGastosId, "CarpetaJudicialGastos", "")
        Catch
            CarpetaJudicialGastosUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & CarpetaJudicialCodigo, CarpetaJudicialGastosId, "CarpetaJudicialGastos", "")
        End Try
    End Function
    Public Function CarpetaJudicialGastosInsert(ByRef CarpetaJudicialGastosId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialGastosSecuencia As Long, ByRef CarpetaJudicialGastosFecha As Date, ByRef CarpetaJudicialGastosConcepto As String, ByRef CarpetaJudicialGastosDocumento As String, ByRef CarpetaJudicialGastosMonto As Double, ByRef CarpetaJudicialGastosDescription As String, ByVal UserId As Long) As Integer
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim CarpetaJudicialGastos As New CarpetaJudicialGastos
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = CarpetaJudicialCodigo
            DetailSecuencia = CarpetaJudicialGastosSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("CarpetaJudicialGastosId", "CarpetaJudicialCodigo", "CarpetaJudicialGastosSecuencia", "CarpetaJudicialGastos", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("CarpetaJudicialGastosId", "CarpetaJudicialCodigo", "CarpetaJudicialGastosSecuencia", "CarpetaJudicialGastos", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            CarpetaJudicialGastosInsert = CarpetaJudicialGastos.CarpetaJudicialGastosUpdate(DetailId, CStr(CarpetaJudicialCodigo), CLng(CarpetaJudicialGastosSecuencia), CDate(CarpetaJudicialGastosFecha), CStr(CarpetaJudicialGastosConcepto), CStr(CarpetaJudicialGastosDocumento), CDbl(CarpetaJudicialGastosMonto), CStr(CarpetaJudicialGastosDescription), UserId)
        Catch
            CarpetaJudicialGastosInsert = 0
        End Try
    End Function
    Public Function CarpetaJudicialGastosDelete(ByVal CarpetaJudicialGastosId As Long, ByVal CarpetaJudicialCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM (CarpetaJudicialGastos) "
        strUpdate = strUpdate & "WHERE (CarpetaJudicialGastos.CarpetaJudicialGastosId = " & CarpetaJudicialGastosId & ") "
        Try
            CarpetaJudicialGastosDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Gastos asociados al Juicio: " & CarpetaJudicialCodigo, CarpetaJudicialGastosId, "CarpetaJudicialGastos", "")
        Catch
            CarpetaJudicialGastosDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar Gastos asociados al juicio: " & CarpetaJudicialCodigo, CarpetaJudicialGastosId, "CarpetaJudicialGastos", "")
        End Try
    End Function
    Public Function ListarGastos(ByVal CarpetaJudicialCodigo As String, Optional ByVal Clase As String = "invisible", Optional ByVal Formato As String = "CodigoHTML") As String
        Dim CodigoHTML As String = ""
        Dim CarpetaJudicialGastos As New CarpetaJudicialGastos
        Dim Direcciones(15) As String
        Dim NumeroDirecciones As Integer = CarpetaJudicialGastos.LeerDatosGastos(CarpetaJudicialCodigo, Direcciones)
        Dim i As Integer
        ListarGastos = ""

        If NumeroDirecciones > 0 Then

            If Formato = "CodigoHTML" Then
                CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                CodigoHTML = CodigoHTML & "<tr>"
                CodigoHTML = CodigoHTML & "<td><h1>" & "Gastos del proceso judicial" & "</h1></td>"
                CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & "Gastos" & "')"" /></td>"
                CodigoHTML = CodigoHTML & "</tr>"
                CodigoHTML = CodigoHTML & "</table>"
                CodigoHTML = CodigoHTML & "<div id=""subgrilla" & "Gastos" & """ class=""" & Clase & """>"
                CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
            Else
                CodigoHTML = CodigoHTML & "<table width=""660"" border=""1"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Verdana;font-size:8pt;border:1px solid #FFFFFF;"">"
            End If


            For i = 0 To NumeroDirecciones
                CodigoHTML = CodigoHTML & Direcciones(i)
            Next
            CodigoHTML = CodigoHTML & "</table>"
            If Formato = "CodigoHTML" Then
                CodigoHTML = CodigoHTML & "</div>"
            End If
        End If

        ListarGastos = CodigoHTML
    End Function
    Public Function LeerDatosGastos(ByVal CarpetaJudicialCodigo As String, ByRef Direcciones() As String) As Integer

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim TotalGastos As Double = 0

        sSQL = "Select CarpetaJudicialGastosId as Id, CarpetaJudicialGastosFecha As Fecha, CarpetaJudicialGastosConcepto As Concepto, CarpetaJudicialGastosDocumento As Documento, CarpetaJudicialGastosMonto As Monto, CarpetaJudicialGastosDescription As Descripcion "
        sSQL = sSQL & "FROM CarpetaJudicialGastos "
        sSQL = sSQL & "WHERE CarpetaJudicialGastos.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' "
        sSQL = sSQL & "ORDER BY CarpetaJudicialGastos.CarpetaJudicialGastosSecuencia"

        Dim CodigoHTML As String = ""

        LeerDatosGastos = 0

        Direcciones(0) = "<tr><th width=""100"" align=""left"">Fecha</th><th width=""150"" align=""left"">Concepto</th><th width=""150"" align=""left"">Documento</th><th width=""125"" align=""right"">Monto</th><th width=""125"" align=""left"">Descripci&oacute;n</th></tr>"

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                TotalGastos = TotalGastos + CDbl(dtr("Monto").ToString)
                Direcciones(i) = "<tr><td>" & FormatDateTime(dtr("Fecha").ToString, DateFormat.ShortDate) & "</td><td>" & dtr("Concepto").ToString & "</td><td>" & dtr("Documento").ToString & "</td><td align=""right"">" & FormatCurrency(dtr("Monto").ToString / 100, 0) & "</td><td>" & dtr("Descripcion").ToString & "</td></tr>"
            End While
            i = i + 1
            Direcciones(i) = "<tr><td colspan=""3"">" & " " & "</td><td align=""right"" >" & FormatCurrency(TotalGastos / 100, 0) & "</td><td>" & " " & "</td></tr>"
            dtr.Close()
        Catch
            LeerDatosGastos = 0
        End Try


        LeerDatosGastos = i

    End Function


End Class
