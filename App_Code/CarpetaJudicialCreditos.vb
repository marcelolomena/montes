'------------------------------------------------------------
' Código generado por ZRISMART SF el 23-02-2012 12:25:58
'------------------------------------------------------------
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
Imports AjaxControlToolkit
Imports AccesoEA

Public Class CarpetaJudicialCreditos
    Public Function LeerCarpetaJudicialCreditos(ByVal CarpetaJudicialCreditosId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialCreditosSecuencia As Long, ByRef TipoCreditoName As String, ByRef CarpetaJudicialCreditosNroOperacion As String, ByRef CarpetaJudicialCreditosCapInicial As Double, ByRef CarpetaJudicialCreditosMoneda As String, ByRef CarpetaJudicialCreditosFechaSuscripcion As Date, ByRef CarpetaJudicialCreditosFechaEntroEnMora As Date, ByRef BancoPrestamistaName As String, _
                                                ByRef CarpetaJudicialCreditosMesesPlazo As Long, ByRef CarpetaJudicialCreditosTasaInteresAnual As Double, ByRef CarpetaJudicialCreditosFechaPrimerVencimiento As Date, ByRef CarpetaJudicialCreditosValorCuota As Double, ByRef CarpetaJudicialCreditosUltimaCuota As Double, ByRef CarpetaJudicialCreditosFechaEscritura As Date, _
                                                ByRef CarpetaJudicialCreditosNotarioEscritura As String, ByRef CarpetaJudicialCreditosCiudadEscritura As String, ByRef CarpetaJudicialCreditosDeudaCapitalPesos As Double, ByRef CarpetaJudicialCreditosDeudaCapitalUF As Double, ByRef CarpetaJudicialCreditosDeudaDividendosPesos As Double, ByRef CarpetaJudicialCreditosDeudaDividendosUF As Double, _
                                                ByRef CarpetaJudicialCreditosInteresesPenalesPesos As Double, ByRef CarpetaJudicialCreditosInteresesPenalesUF As Double, ByRef CarpetaJudicialCreditosDeudaTotalPesos As Double, ByRef CarpetaJudicialCreditosDeudaTotalUF As Double) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select CarpetaJudicialCodigo, CarpetaJudicialCreditosSecuencia, TipoCreditoName, CarpetaJudicialCreditosNroOperacion, CarpetaJudicialCreditosCapInicial, CarpetaJudicialCreditosMoneda, CarpetaJudicialCreditosFechaSuscripcion, CarpetaJudicialCreditosFechaEntroEnMora, BancoPrestamistaName, "
        sSQL = sSQL & "CarpetaJudicialCreditosMesesPlazo, CarpetaJudicialCreditosTasaInteresAnual, CarpetaJudicialCreditosFechaPrimerVencimiento, CarpetaJudicialCreditosValorCuota, CarpetaJudicialCreditosUltimaCuota, CarpetaJudicialCreditosFechaEscritura, "
        sSQL = sSQL & "CarpetaJudicialCreditosNotarioEscritura, CarpetaJudicialCreditosCiudadEscritura, CarpetaJudicialCreditosDeudaCapitalPesos, CarpetaJudicialCreditosDeudaCapitalUF, CarpetaJudicialCreditosDeudaDividendosPesos, CarpetaJudicialCreditosDeudaDividendosUF, "
        sSQL = sSQL & "CarpetaJudicialCreditosInteresesPenalesPesos, CarpetaJudicialCreditosInteresesPenalesUF, CarpetaJudicialCreditosDeudaTotalPesos, CarpetaJudicialCreditosDeudaTotalUF "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos "
        sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCreditosId = " & CarpetaJudicialCreditosId & " "
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                CarpetaJudicialCodigo = CStr(dtr("CarpetaJudicialCodigo").ToString)
                If Len(dtr("CarpetaJudicialCreditosSecuencia").ToString) = 0 Then
                    CarpetaJudicialCreditosSecuencia = 0
                Else
                    CarpetaJudicialCreditosSecuencia = CLng(dtr("CarpetaJudicialCreditosSecuencia").ToString)
                End If
                TipoCreditoName = CStr(dtr("TipoCreditoName").ToString)
                CarpetaJudicialCreditosNroOperacion = CStr(dtr("CarpetaJudicialCreditosNroOperacion").ToString)
                If Len(dtr("CarpetaJudicialCreditosCapInicial").ToString) = 0 Then
                    CarpetaJudicialCreditosCapInicial = 0
                Else
                    CarpetaJudicialCreditosCapInicial = CDbl(dtr("CarpetaJudicialCreditosCapInicial").ToString)
                End If
                CarpetaJudicialCreditosMoneda = CStr(dtr("CarpetaJudicialCreditosMoneda").ToString)
                If Len(dtr("CarpetaJudicialCreditosFechaSuscripcion").ToString) = 0 Then
                    CarpetaJudicialCreditosFechaSuscripcion = "01/01/01"
                Else
                    CarpetaJudicialCreditosFechaSuscripcion = CDate(dtr("CarpetaJudicialCreditosFechaSuscripcion").ToString)
                End If
                If Len(dtr("CarpetaJudicialCreditosFechaEntroEnMora").ToString) = 0 Then
                    CarpetaJudicialCreditosFechaEntroEnMora = "01/01/01"
                Else
                    CarpetaJudicialCreditosFechaEntroEnMora = CDate(dtr("CarpetaJudicialCreditosFechaEntroEnMora").ToString)
                End If
                BancoPrestamistaName = CStr(dtr("BancoPrestamistaName").ToString)
                If Len(dtr("CarpetaJudicialCreditosMesesPlazo").ToString) = 0 Then
                    CarpetaJudicialCreditosMesesPlazo = 0
                Else
                    CarpetaJudicialCreditosMesesPlazo = CDbl(dtr("CarpetaJudicialCreditosMesesPlazo").ToString)
                End If
                If Len(dtr("CarpetaJudicialCreditosTasaInteresAnual").ToString) = 0 Then
                    CarpetaJudicialCreditosTasaInteresAnual = 0
                Else
                    CarpetaJudicialCreditosTasaInteresAnual = CDbl(dtr("CarpetaJudicialCreditosTasaInteresAnual").ToString)
                End If
                If Len(dtr("CarpetaJudicialCreditosFechaPrimerVencimiento").ToString) = 0 Then
                    CarpetaJudicialCreditosFechaPrimerVencimiento = "01/01/01"
                Else
                    CarpetaJudicialCreditosFechaPrimerVencimiento = CDate(dtr("CarpetaJudicialCreditosFechaPrimerVencimiento").ToString)
                End If
                If Len(dtr("CarpetaJudicialCreditosValorCuota").ToString) = 0 Then
                    CarpetaJudicialCreditosValorCuota = 0
                Else
                    CarpetaJudicialCreditosValorCuota = CDbl(dtr("CarpetaJudicialCreditosValorCuota").ToString)
                End If
                If Len(dtr("CarpetaJudicialCreditosUltimaCuota").ToString) = 0 Then
                    CarpetaJudicialCreditosUltimaCuota = 0
                Else
                    CarpetaJudicialCreditosUltimaCuota = CDbl(dtr("CarpetaJudicialCreditosUltimaCuota").ToString)
                End If
                If Len(dtr("CarpetaJudicialCreditosFechaEscritura").ToString) = 0 Then
                    CarpetaJudicialCreditosFechaEscritura = "01/01/01"
                Else
                    CarpetaJudicialCreditosFechaEscritura = CDate(dtr("CarpetaJudicialCreditosFechaEscritura").ToString)
                End If
                CarpetaJudicialCreditosNotarioEscritura = CStr(dtr("CarpetaJudicialCreditosNotarioEscritura").ToString)
                CarpetaJudicialCreditosCiudadEscritura = CStr(dtr("CarpetaJudicialCreditosCiudadEscritura").ToString)
                If Len(dtr("CarpetaJudicialCreditosDeudaCapitalPesos").ToString) = 0 Then
                    CarpetaJudicialCreditosDeudaCapitalPesos = 0
                Else
                    CarpetaJudicialCreditosDeudaCapitalPesos = CDbl(dtr("CarpetaJudicialCreditosDeudaCapitalPesos").ToString)
                End If
                If Len(dtr("CarpetaJudicialCreditosDeudaCapitalUF").ToString) = 0 Then
                    CarpetaJudicialCreditosDeudaCapitalUF = 0
                Else
                    CarpetaJudicialCreditosDeudaCapitalUF = CDbl(dtr("CarpetaJudicialCreditosDeudaCapitalUF").ToString)
                End If
                If Len(dtr("CarpetaJudicialCreditosDeudaDividendosPesos").ToString) = 0 Then
                    CarpetaJudicialCreditosDeudaDividendosPesos = 0
                Else
                    CarpetaJudicialCreditosDeudaDividendosPesos = CDbl(dtr("CarpetaJudicialCreditosDeudaDividendosPesos").ToString)
                End If
                If Len(dtr("CarpetaJudicialCreditosDeudaDividendosUF").ToString) = 0 Then
                    CarpetaJudicialCreditosDeudaDividendosUF = 0
                Else
                    CarpetaJudicialCreditosDeudaDividendosUF = CDbl(dtr("CarpetaJudicialCreditosDeudaDividendosUF").ToString)
                End If
                If Len(dtr("CarpetaJudicialCreditosInteresesPenalesPesos").ToString) = 0 Then
                    CarpetaJudicialCreditosInteresesPenalesPesos = 0
                Else
                    CarpetaJudicialCreditosInteresesPenalesPesos = CDbl(dtr("CarpetaJudicialCreditosInteresesPenalesPesos").ToString)
                End If
                If Len(dtr("CarpetaJudicialCreditosInteresesPenalesUF").ToString) = 0 Then
                    CarpetaJudicialCreditosInteresesPenalesUF = 0
                Else
                    CarpetaJudicialCreditosInteresesPenalesUF = CDbl(dtr("CarpetaJudicialCreditosInteresesPenalesUF").ToString)
                End If
                If Len(dtr("CarpetaJudicialCreditosDeudaTotalPesos").ToString) = 0 Then
                    CarpetaJudicialCreditosDeudaTotalPesos = 0
                Else
                    CarpetaJudicialCreditosDeudaTotalPesos = CDbl(dtr("CarpetaJudicialCreditosDeudaTotalPesos").ToString)
                End If
                If Len(dtr("CarpetaJudicialCreditosDeudaTotalUF").ToString) = 0 Then
                    CarpetaJudicialCreditosDeudaTotalUF = 0
                Else
                    CarpetaJudicialCreditosDeudaTotalUF = CDbl(dtr("CarpetaJudicialCreditosDeudaTotalUF").ToString)
                End If

            End While
            LeerCarpetaJudicialCreditos = True
            dtr.Close()
        Catch
            LeerCarpetaJudicialCreditos = False
        End Try
    End Function
    Public Function CarpetaJudicialCreditosUpdate(ByVal CarpetaJudicialCreditosId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialCreditosSecuencia As Long, ByRef TipoCreditoName As String, ByRef CarpetaJudicialCreditosNroOperacion As String, ByRef CarpetaJudicialCreditosCapInicial As Double, ByRef CarpetaJudicialCreditosMoneda As String, ByRef CarpetaJudicialCreditosFechaSuscripcion As Date, ByRef CarpetaJudicialCreditosFechaEntroEnMora As Date, ByRef BancoPrestamistaName As String, _
                                                ByRef CarpetaJudicialCreditosMesesPlazo As Long, ByRef CarpetaJudicialCreditosTasaInteresAnual As Double, ByRef CarpetaJudicialCreditosFechaPrimerVencimiento As Date, ByRef CarpetaJudicialCreditosValorCuota As Double, ByRef CarpetaJudicialCreditosUltimaCuota As Double, ByRef CarpetaJudicialCreditosFechaEscritura As Date, _
                                                ByRef CarpetaJudicialCreditosNotarioEscritura As String, ByRef CarpetaJudicialCreditosCiudadEscritura As String, ByRef CarpetaJudicialCreditosDeudaCapitalPesos As Double, ByRef CarpetaJudicialCreditosDeudaCapitalUF As Double, ByRef CarpetaJudicialCreditosDeudaDividendosPesos As Double, ByRef CarpetaJudicialCreditosDeudaDividendosUF As Double, _
                                                ByRef CarpetaJudicialCreditosInteresesPenalesPesos As Double, ByRef CarpetaJudicialCreditosInteresesPenalesUF As Double, ByRef CarpetaJudicialCreditosDeudaTotalPesos As Double, ByRef CarpetaJudicialCreditosDeudaTotalUF As Double, _
                                                ByVal UserId As Long) As Integer


        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas

        Dim TareasId As Long = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
        Dim TareasCodigo As String = ""
        Dim b As Boolean

        b = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)
        Dim UserIdCodigo As String = ""
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(TareasId)
        Dim TareasLogActividad As String = ""

        TareasLogActividad = "Registra Créditos: " & TipoCreditoName & " " & FormatNumber(CarpetaJudicialCreditosCapInicial / 10000, 4) & " " & CarpetaJudicialCreditosMoneda

        strUpdate = "UPDATE CarpetaJudicialCreditos SET "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "', "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosSecuencia = " & CarpetaJudicialCreditosSecuencia & ", "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.TipoCreditoName = '" & TipoCreditoName & "', "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosNroOperacion = '" & CarpetaJudicialCreditosNroOperacion & "', "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosCapInicial = " & CarpetaJudicialCreditosCapInicial & ", "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosMoneda = '" & CarpetaJudicialCreditosMoneda & "', "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosFechaSuscripcion = '" & AccionesABM.DateTransform(CarpetaJudicialCreditosFechaSuscripcion) & "', "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosFechaEntroEnMora = '" & AccionesABM.DateTransform(CarpetaJudicialCreditosFechaEntroEnMora) & "', "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.BancoPrestamistaName = '" & BancoPrestamistaName & "', "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosMesesPlazo = " & CarpetaJudicialCreditosMesesPlazo & ", "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosTasaInteresAnual = " & CarpetaJudicialCreditosTasaInteresAnual & ", "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosFechaPrimerVencimiento = '" & AccionesABM.DateTransform(CarpetaJudicialCreditosFechaPrimerVencimiento) & "', "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosValorCuota = " & CarpetaJudicialCreditosValorCuota & ", "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosUltimaCuota = " & CarpetaJudicialCreditosUltimaCuota & ", "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosFechaEscritura = '" & AccionesABM.DateTransform(CarpetaJudicialCreditosFechaEscritura) & "', "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosNotarioEscritura = '" & CarpetaJudicialCreditosNotarioEscritura & "', "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosCiudadEscritura = '" & CarpetaJudicialCreditosCiudadEscritura & "', "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosDeudaCapitalPesos = " & CarpetaJudicialCreditosDeudaCapitalPesos & ", "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosDeudaCapitalUF = " & CarpetaJudicialCreditosDeudaCapitalUF & ", "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosDeudaDividendosPesos = " & CarpetaJudicialCreditosDeudaDividendosPesos & ", "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosDeudaDividendosUF = " & CarpetaJudicialCreditosDeudaDividendosUF & ", "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosInteresesPenalesPesos = " & CarpetaJudicialCreditosInteresesPenalesPesos & ", "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosInteresesPenalesUF = " & CarpetaJudicialCreditosInteresesPenalesUF & ", "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosDeudaTotalPesos = " & CarpetaJudicialCreditosDeudaTotalPesos & ", "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.CarpetaJudicialCreditosDeudaTotalUF = " & CarpetaJudicialCreditosDeudaTotalUF & ", "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "CarpetaJudicialCreditos.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCreditosId = " & CarpetaJudicialCreditosId
        Try
            CarpetaJudicialCreditosUpdate = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza " & CarpetaJudicialCodigo, CarpetaJudicialCreditosId, "CarpetaJudicialCreditos", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CarpetaJudicialCreditosUpdate = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de actualizar el registro de " & CarpetaJudicialCodigo, CarpetaJudicialCreditosId, "CarpetaJudicialCreditos", "")
        End Try
    End Function
    Public Function CarpetaJudicialCreditosInsert(ByRef CarpetaJudicialCreditosId As Long, ByRef CarpetaJudicialCodigo As String, ByRef CarpetaJudicialCreditosSecuencia As Long, ByRef TipoCreditoName As String, ByRef CarpetaJudicialCreditosNroOperacion As String, ByRef CarpetaJudicialCreditosCapInicial As Double, ByRef CarpetaJudicialCreditosMoneda As String, ByRef CarpetaJudicialCreditosFechaSuscripcion As Date, ByRef CarpetaJudicialCreditosFechaEntroEnMora As Date, ByRef BancoPrestamistaName As String, _
                                                ByRef CarpetaJudicialCreditosMesesPlazo As Long, ByRef CarpetaJudicialCreditosTasaInteresAnual As Double, ByRef CarpetaJudicialCreditosFechaPrimerVencimiento As Date, ByRef CarpetaJudicialCreditosValorCuota As Double, ByRef CarpetaJudicialCreditosUltimaCuota As Double, ByRef CarpetaJudicialCreditosFechaEscritura As Date, _
                                                ByRef CarpetaJudicialCreditosNotarioEscritura As String, ByRef CarpetaJudicialCreditosCiudadEscritura As String, ByRef CarpetaJudicialCreditosDeudaCapitalPesos As Double, ByRef CarpetaJudicialCreditosDeudaCapitalUF As Double, ByRef CarpetaJudicialCreditosDeudaDividendosPesos As Double, ByRef CarpetaJudicialCreditosDeudaDividendosUF As Double, _
                                                ByRef CarpetaJudicialCreditosInteresesPenalesPesos As Double, ByRef CarpetaJudicialCreditosInteresesPenalesUF As Double, ByRef CarpetaJudicialCreditosDeudaTotalPesos As Double, ByRef CarpetaJudicialCreditosDeudaTotalUF As Double, _
                                                ByVal UserId As Long) As Integer


        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim t As Integer = 0
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Dim MasterId As Long = 0
        Dim MasterName As String = ""
        Dim DetailId As Long = 0  'Guarda el identity del registro de detalle
        Dim DetailSecuencia As Long = 0  'Guarda el número de secuencia del registro de detalle
        Try
            MasterName = CarpetaJudicialCodigo
            DetailSecuencia = CarpetaJudicialCreditosSecuencia
            DetailId = 0
            t = Lecturas.LeerObjectByNameAndSecuencia("CarpetaJudicialCreditosId", "CarpetaJudicialCodigo", "CarpetaJudicialCreditosSecuencia", "CarpetaJudicialCreditos", MasterName, DetailSecuencia, DetailId)
            If DetailId = 0 Then
                t = AccionesABM.ObjectPartialInsert("CarpetaJudicialCreditosId", "CarpetaJudicialCodigo", "CarpetaJudicialCreditosSecuencia", "CarpetaJudicialCreditos", MasterName, DetailSecuencia, UserId, DetailId)
            End If
            CarpetaJudicialCreditosInsert = CarpetaJudicialCreditos.CarpetaJudicialCreditosUpdate(DetailId, CStr(CarpetaJudicialCodigo), CLng(CarpetaJudicialCreditosSecuencia), CStr(TipoCreditoName), CStr(CarpetaJudicialCreditosNroOperacion), CDbl(CarpetaJudicialCreditosCapInicial), CStr(CarpetaJudicialCreditosMoneda), CDate(CarpetaJudicialCreditosFechaSuscripcion), CDate(CarpetaJudicialCreditosFechaEntroEnMora), CStr(BancoPrestamistaName), CLng(CarpetaJudicialCreditosMesesPlazo), CDbl(CarpetaJudicialCreditosTasaInteresAnual), CDate(CarpetaJudicialCreditosFechaPrimerVencimiento), CDbl(CarpetaJudicialCreditosValorCuota), CDbl(CarpetaJudicialCreditosUltimaCuota), CDate(CarpetaJudicialCreditosFechaEscritura), CStr(CarpetaJudicialCreditosNotarioEscritura), CStr(CarpetaJudicialCreditosCiudadEscritura), CDbl(CarpetaJudicialCreditosDeudaCapitalPesos), CDbl(CarpetaJudicialCreditosDeudaCapitalUF), CDbl(CarpetaJudicialCreditosDeudaDividendosPesos), CDbl(CarpetaJudicialCreditosDeudaDividendosUF), CDbl(CarpetaJudicialCreditosInteresesPenalesPesos), CDbl(CarpetaJudicialCreditosInteresesPenalesUF), CDbl(CarpetaJudicialCreditosDeudaTotalPesos), CDbl(CarpetaJudicialCreditosDeudaTotalUF), UserId)
        Catch
            CarpetaJudicialCreditosInsert = 0
        End Try
    End Function
    Public Function LeerDatosBasicosCreditos(ByVal CarpetaJudicialCreditosId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        Dim TipoCreditoName As String = ""
        Dim CarpetaJudicialCreditosCapInicial As Double = 0
        Dim CarpetaJudicialCreditosMoneda As String = ""

        sSQL = "Select TipoCreditoName, CarpetaJudicialCreditosCapInicial, CarpetaJudicialCreditosMoneda "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos "
        sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCreditosId = " & CarpetaJudicialCreditosId & " "

        LeerDatosBasicosCreditos = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                TipoCreditoName = CStr(dtr("TipoCreditoName").ToString)
                If Len(dtr("CarpetaJudicialCreditosCapInicial").ToString) = 0 Then
                    CarpetaJudicialCreditosCapInicial = 0
                Else
                    CarpetaJudicialCreditosCapInicial = CDbl(dtr("CarpetaJudicialCreditosCapInicial").ToString)
                End If
                CarpetaJudicialCreditosMoneda = CStr(dtr("CarpetaJudicialCreditosMoneda").ToString)
                LeerDatosBasicosCreditos = TipoCreditoName & " " & FormatNumber(CarpetaJudicialCreditosCapInicial / 10000, 4) & " " & CarpetaJudicialCreditosMoneda
            End While
            dtr.Close()
        Catch
            LeerDatosBasicosCreditos = ""
        End Try
    End Function


    Public Function CarpetaJudicialCreditosDelete(ByVal CarpetaJudicialCreditosId As Long, ByVal CarpetaJudicialCodigo As String, ByVal UserId As Long) As Integer
        Dim AccesoEA As New AccesoEA
        Dim strUpdate As String
        Dim AccionesABM As New AccionesABM
        Dim t As Integer
        Dim Tareas As New Tareas
        Dim Usuarios As New Usuarios
        Dim EstadoTareas As New EstadoTareas
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos

        Dim TareasId As Long = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
        Dim TareasCodigo As String = ""
        Dim b As Boolean
        b = Tareas.LeerTareasCodigoById(TareasId, TareasCodigo)
        Dim UserIdCodigo As String = ""
        Dim EstadoTareasCodigo As String = Tareas.LeerEstadoTareasCodigo(TareasId)
        b = Usuarios.LeerUsuariosCodigoByUsuariosId(UserId, UserIdCodigo)
        Dim TareasLogRol As String = EstadoTareas.LeerRolResponsableSegunEstadoDeTareas(TareasId)
        Dim TareasLogActividad As String = ""

        TareasLogActividad = "Elimina Crédito: " & CarpetaJudicialCreditos.LeerDatosBasicosCreditos(CarpetaJudicialCreditosId)


        strUpdate = "Delete "
        strUpdate = strUpdate & "FROM CarpetaJudicialCreditos "
        strUpdate = strUpdate & "WHERE (CarpetaJudicialCreditos.CarpetaJudicialCreditosId = " & CarpetaJudicialCreditosId & ") "
        Try
            CarpetaJudicialCreditosDelete = AccesoEA.ABMRegistros(strUpdate)
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Elimina Creditos asociados al Juicio: " & CarpetaJudicialCodigo, CarpetaJudicialCreditosId, "CarpetaJudicialCreditos", "")
            t = AccionesABM.TareasLogInsert(TareasCodigo, UserIdCodigo, TareasLogRol, TareasLogActividad)
        Catch
            CarpetaJudicialCreditosDelete = 0
            t = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento fallido de eliminar Creditos asociados al juicio: " & CarpetaJudicialCodigo, CarpetaJudicialCreditosId, "CarpetaJudicialCreditos", "")
        End Try
    End Function

    Public Function ListarCreditos(ByVal CarpetaJudicialCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        sSQL = "Select TipoCreditoName, CarpetaJudicialCreditosNroOperacion, CarpetaJudicialCreditosCapInicial, CarpetaJudicialCreditosMoneda, CarpetaJudicialCreditosFechaSuscripcion, CarpetaJudicialCreditosDeudaTotalPesos, CarpetaJudicialCreditosFechaEntroEnMora "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos "
        sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' "
        Dim CodigoHTML As String = ""
        Dim DeudaTotalPesos As Double = 0
        Dim Totales As Double = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If Len(dtr("CarpetaJudicialCreditosDeudaTotalPesos").ToString) = 0 Then
                    DeudaTotalPesos = 0
                Else
                    DeudaTotalPesos = CDbl(dtr("CarpetaJudicialCreditosDeudaTotalPesos").ToString)
                    Totales = Totales + DeudaTotalPesos
                End If
                CodigoHTML = CodigoHTML & "<tr><td>" & dtr("TipoCreditoName").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & dtr("CarpetaJudicialCreditosNroOperacion").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosCapInicial").ToString / 10000, 4) & " " & dtr("CarpetaJudicialCreditosMoneda").ToString & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & FormatDateTime(dtr("CarpetaJudicialCreditosFechaSuscripcion").ToString, DateFormat.ShortDate) & "</td>"
                CodigoHTML = CodigoHTML & "<td>" & FormatDateTime(dtr("CarpetaJudicialCreditosFechaEntroEnMora").ToString, DateFormat.ShortDate) & "</td>"
                CodigoHTML = CodigoHTML & "<td align=""right"">" & "$ " & FormatNumber(DeudaTotalPesos / 10000, 0) & "</td></tr>"
            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try
        If Totales > 0 Then
            CodigoHTML = CodigoHTML & "<tr><td colspan=""5"" >" & " " & "</td>"
            CodigoHTML = CodigoHTML & "<td align=""right"">" & "$ " & FormatNumber(Totales / 10000, 0) & "</td></tr>"
        End If
        ListarCreditos = CodigoHTML

    End Function

    Public Function MateriaJuicio(ByVal CarpetaJudicialCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0

        sSQL = "Select DISTINCT TipoCreditoName "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos "
        sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' "
        Dim CodigoHTML As String = ""
        Dim DeudaTotalPesos As Double = 0

        MateriaJuicio = "COBRO DE "

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    MateriaJuicio = MateriaJuicio & UCase(dtr("TipoCreditoName").ToString)
                Else
                    MateriaJuicio = MateriaJuicio & " Y " & UCase(dtr("TipoCreditoName").ToString)
                End If
            End While
            dtr.Close()
        Catch
            MateriaJuicio = ""
        End Try
    End Function

    Public Function LeerCreditosIdPorTipo(ByVal CarpetaJudicialCodigo As String, ByVal TipoCreditoName As String, ByRef CarpetaJudicialCreditosId() As Long) As Integer

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0

        sSQL = "Select CarpetaJudicialCreditosId As Id "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos "
        sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' AND CarpetaJudicialCreditos.TipoCreditoName = '" & TipoCreditoName & "' "
        Dim CodigoHTML As String = ""
        Dim DeudaTotalPesos As Double = 0

        LeerCreditosIdPorTipo = 0

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                CarpetaJudicialCreditosId(i) = CLng(dtr("Id").ToString)
            End While
            dtr.Close()
        Catch
            LeerCreditosIdPorTipo = 0
        End Try

        LeerCreditosIdPorTipo = i

    End Function





    Public Function LeerCantidadEscriturasPublicas(ByVal CarpetaJudicialCodigo As String) As Integer

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim j As Integer = 0 'Cuenta los distintos

        Dim Fecha As Date
        Dim Ciudad As String = ""
        Dim Notario As String = ""

        sSQL = "Select CarpetaJudicialCreditosFechaEscritura As Fecha, CarpetaJudicialCreditosCiudadEscritura As Ciudad, CarpetaJudicialCreditosNotarioEscritura As Notario "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos "
        sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' AND CarpetaJudicialCreditos.TipoCreditoName <> 'Pagare' "
        sSQL = sSQL & "ORDER BY CarpetaJudicialCreditosFechaEscritura, CarpetaJudicialCreditosCiudadEscritura, CarpetaJudicialCreditosNotarioEscritura"

        LeerCantidadEscriturasPublicas = j

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    Fecha = CDate(dtr("Fecha").ToString)
                    Ciudad = CStr(dtr("Ciudad").ToString)
                    Notario = CStr(dtr("Notario").ToString)
                    j = 1
                Else
                    If (Fecha = CDate(dtr("Fecha").ToString) And Ciudad = CStr(dtr("Ciudad").ToString) And Notario = CStr(dtr("Notario").ToString)) Then
                        j = j 'se mantiene el valo de j, hay igualdad
                    Else
                        Fecha = CDate(dtr("Fecha").ToString)
                        Ciudad = CStr(dtr("Ciudad").ToString)
                        Notario = CStr(dtr("Notario").ToString)
                        j = j + 1
                    End If
                End If
            End While
            dtr.Close()
        Catch
            LeerCantidadEscriturasPublicas = 0
        End Try

        LeerCantidadEscriturasPublicas = j

    End Function
    Public Function LeerTotalDeuda(ByVal CarpetaJudicialCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim j As Integer = 0 'Cuenta los distintos

        Dim DeudaUF As Double = 0
        Dim DeudaPesos As Double = 0


        sSQL = "Select CarpetaJudicialCreditosMoneda As Moneda, CarpetaJudicialCreditosDeudaTotalUF As DeudaUF, CarpetaJudicialCreditosDeudaTotalPesos As DeudaPesos "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos "
        sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' AND CarpetaJudicialCreditos.TipoCreditoName <> 'Pagare' "

        LeerTotalDeuda = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                DeudaPesos = DeudaPesos + CDbl(dtr("DeudaPesos").ToString)
                If dtr("Moneda").ToString = "UF" Then
                    DeudaUF = DeudaUF + CDbl(dtr("DeudaUF").ToString)
                End If
            End While
            dtr.Close()
        Catch
            LeerTotalDeuda = ""
        End Try

        If DeudaUF = 0 Then
            LeerTotalDeuda = " $ " & FormatNumber(DeudaPesos / 10000, 0) & ".-"
        Else
            LeerTotalDeuda = FormatNumber(DeudaUF / 10000, 4) & " UF equivalentes a $ " & FormatNumber(DeudaPesos / 10000, 0) & ".-"
        End If

    End Function
    Public Function LeerTotalDeudaPagares(ByVal CarpetaJudicialCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim j As Integer = 0 'Cuenta los distintos

        Dim DeudaUF As Double = 0
        Dim DeudaPesos As Double = 0

        Dim GlosaPesos As String = ""
        Dim GlosaUF As String = ""

        sSQL = "Select CarpetaJudicialCreditosMoneda As Moneda, CarpetaJudicialCreditosDeudaTotalUF As DeudaUF, CarpetaJudicialCreditosDeudaTotalPesos As DeudaPesos "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos "
        sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' AND CarpetaJudicialCreditos.TipoCreditoName = 'Pagare' "

        LeerTotalDeudaPagares = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                DeudaPesos = DeudaPesos + CDbl(dtr("DeudaPesos").ToString)
                DeudaUF = DeudaUF + CDbl(dtr("DeudaUF").ToString)
            End While
            dtr.Close()
        Catch
            LeerTotalDeudaPagares = ""
        End Try

        If DeudaPesos > 0 Then GlosaPesos = " $ " & FormatNumber(DeudaPesos / 10000, 0) & ".-"
        If DeudaUF > 0 Then GlosaUF = ", más UF " & FormatNumber(DeudaUF / 10000, 4) & ".-"

        LeerTotalDeudaPagares = GlosaPesos & GlosaUF


    End Function


    Public Function BancoDemandante(ByVal CarpetaJudicialCodigo As String) As String

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0

        sSQL = "Select DISTINCT BancoPrestamistaName As Banco "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos "
        sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' "
        Dim CodigoHTML As String = ""
        Dim DeudaTotalPesos As Double = 0

        BancoDemandante = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                If dtr("Banco").ToString <> "Scotiabank Chile" Then
                    i = i + 1
                    If i = 1 Then
                        BancoDemandante = BancoDemandante & UCase(dtr("Banco").ToString)
                    Else
                        BancoDemandante = BancoDemandante & " y del " & UCase(dtr("Banco").ToString)
                    End If
                End If

            End While
            dtr.Close()
        Catch
            BancoDemandante = ""
        End Try
    End Function

    Public Function ParrafoMutuoEndosable(ByVal CarpetaJudicialCreditosId As Long, NumeroCredito As Integer) As String
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Lecturas As New Lecturas
        Dim t As Boolean
        Dim CodigoHTML As String = ""



        Dim CarpetaJudicialCodigo As String = "" ' Etiqueta : # Interno - Control : txtCarpetaJudicialCodigo - Variable : CarpetaJudicialCodigo
        Dim CarpetaJudicialCreditosSecuencia As Long ' Etiqueta : # Secuencia - Control : txtCarpetaJudicialGastosSecuencia - Variable : CarpetaJudicialGastosSecuencia
        Dim CarpetaJudicialCreditosNroOperacion As String = "" ' Etiqueta : # Operación - Control : txtCarpetaJudicialNroOperacion - Variable : CarpetaJudicialNroOperacion
        Dim CarpetaJudicialCreditosCapInicial As Double ' Etiqueta : Capital Inicial - Control : txtCarpetaJudicialCapInicial - Variable : CarpetaJudicialCapInicial
        Dim CarpetaJudicialCreditosMoneda As String = "" ' Etiqueta : Moneda - Control : txtCarpetaJudicialMoneda - Variable : CarpetaJudicialMoneda
        Dim CarpetaJudicialCreditosFechaSuscripcion As Date ' Etiqueta : Fecha Suscripción - Control : txtCarpetaJudicialFechaSuscripcion - Variable : CarpetaJudicialFechaSuscripcion
        Dim CarpetaJudicialCreditosFechaEntroEnMora As Date ' Etiqueta : Fecha entro en mora - Control : txtCarpetaJudicialFechaEntroEnMora - Variable : CarpetaJudicialFechaEntroEnMora
        Dim BancoPrestamistaName As String = ""
        Dim TipoCreditoName As String = ""
        Dim CarpetaJudicialCreditosMesesPlazo As Long
        Dim CarpetaJudicialCreditosTasaInteresAnual As Double
        Dim CarpetaJudicialCreditosFechaPrimerVencimiento As Date
        Dim CarpetaJudicialCreditosValorCuota As Double
        Dim CarpetaJudicialCreditosUltimaCuota As Double
        Dim CarpetaJudicialCreditosFechaEscritura As Date
        Dim CarpetaJudicialCreditosNotarioEscritura As String = ""
        Dim CarpetaJudicialCreditosCiudadEscritura As String = ""
        Dim CarpetaJudicialCreditosDeudaCapitalPesos As Double
        Dim CarpetaJudicialCreditosDeudaCapitalUF As Double
        Dim CarpetaJudicialCreditosDeudaDividendosPesos As Double
        Dim CarpetaJudicialCreditosDeudaDividendosUF As Double
        Dim CarpetaJudicialCreditosInteresesPenalesPesos As Double
        Dim CarpetaJudicialCreditosInteresesPenalesUF As Double
        Dim CarpetaJudicialCreditosDeudaTotalPesos As Double
        Dim CarpetaJudicialCreditosDeudaTotalUF As Double
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"
        Dim TextoFechaEscritura As String = ""
        Dim Profesion As String = ""
        Dim GlosaBanco As String = ""
        Dim GlosaCredito As String = ""

        t = CarpetaJudicialCreditos.LeerCarpetaJudicialCreditos(CarpetaJudicialCreditosId, CarpetaJudicialCodigo, CarpetaJudicialCreditosSecuencia, TipoCreditoName, CarpetaJudicialCreditosNroOperacion, CarpetaJudicialCreditosCapInicial, CarpetaJudicialCreditosMoneda, CarpetaJudicialCreditosFechaSuscripcion, CarpetaJudicialCreditosFechaEntroEnMora, BancoPrestamistaName, CarpetaJudicialCreditosMesesPlazo, CarpetaJudicialCreditosTasaInteresAnual, CarpetaJudicialCreditosFechaPrimerVencimiento, CarpetaJudicialCreditosValorCuota, CarpetaJudicialCreditosUltimaCuota, CarpetaJudicialCreditosFechaEscritura, CarpetaJudicialCreditosNotarioEscritura, CarpetaJudicialCreditosCiudadEscritura, CarpetaJudicialCreditosDeudaCapitalPesos, CarpetaJudicialCreditosDeudaCapitalUF, CarpetaJudicialCreditosDeudaDividendosPesos, CarpetaJudicialCreditosDeudaDividendosUF, CarpetaJudicialCreditosInteresesPenalesPesos, CarpetaJudicialCreditosInteresesPenalesUF, CarpetaJudicialCreditosDeudaTotalPesos, CarpetaJudicialCreditosDeudaTotalUF)



        If BancoPrestamistaName <> "Banco Scotiabank Chile" Then
            GlosaBanco = BancoPrestamistaName & ", hoy Banco Scotiabank Chile"
        Else
            GlosaBanco = "Banco Scotiabank Chile"
        End If

        If CarpetaJudicialCreditosMoneda = "UF" Then
            GlosaCredito = FormatNumber(CarpetaJudicialCreditosCapInicial / 10000, 4) & " Unidades de Fomento, "
        Else  'Por defecto se asumen sólo dos monedas, si no es UF es pesos.
            GlosaCredito = FormatNumber(CarpetaJudicialCreditosCapInicial / 10000, 2) & " Pesos, "
        End If

        GlosaCredito = GlosaCredito & "que gana los intereses y se amortizan en los plazos y condiciones establecidas en la citada escritura pública. "
        GlosaCredito = GlosaCredito & "La obligación genera un interés del " & FormatNumber(CarpetaJudicialCreditosTasaInteresAnual / 10000, 2) & "% anual vencido."


        If TipoCreditoName = "Mutuo" Then
            If NumeroCredito = 1 Then
                CodigoHTML = "<p>" & Espacios & Espacios & "Consta de la escritura pública de fecha " & Lecturas.FechaEscrita(CarpetaJudicialCreditosFechaEscritura) & ", otorgada en la Notaría de " & CarpetaJudicialCreditosCiudadEscritura & " de " & CarpetaJudicialCreditosNotarioEscritura & ", que el " & GlosaBanco & " otorgó a "
            Else
                If CarpetaJudicialCreditos.LeerCantidadEscriturasPublicas(CarpetaJudicialCodigo) = 1 Then
                    CodigoHTML = "<p>" & Espacios & Espacios & "Adicionalmente por la misma escritura el " & GlosaBanco & " otorgó a "
                Else
                    CodigoHTML = "<p>" & Espacios & Espacios & "Adicionalmente, consta de la escritura pública de fecha " & Lecturas.FechaEscrita(CarpetaJudicialCreditosFechaEscritura) & ", otorgada en la Notaría de " & CarpetaJudicialCreditosCiudadEscritura & " de " & CarpetaJudicialCreditosNotarioEscritura & ", que el " & GlosaBanco & " otorgó a "
                End If
            End If
            CodigoHTML = CodigoHTML & CarpetaJudicial.LeerIdentificacionProfesionDireccion(CarpetaJudicialCodigo) & " un " & CarpetaJudicialCreditos.LeerTipoCreditoDescription(TipoCreditoName) & " por la cantidad equivalente de " & GlosaCredito & "</p>"
            CodigoHTML = CodigoHTML & "<p>" & Espacios & Espacios & "El deudor se obligó a pagar la cantidad recibida en mutuo en el plazo de " & CarpetaJudicialCreditosMesesPlazo & " meses, por medio de dividendos anticipados, mensuales y sucesivos, pactados en " & CarpetaJudicialCreditosMoneda & " del día de pago, dividendos que comprenden la amortización, los intereses pactados y la comisión estipulada en el mutuo.</p>"
            CodigoHTML = CodigoHTML & "<p>" & Espacios & Espacios & "Los dividendos deben pagarse dentro de los primeros diez días de cada mes, en efectivo, en el domicilio del acreedor. En el caso de no pago oportuno de cualquiera de los dividendos dentro del plazo establecido, se devengan intereses penales o moratorios equivalentes al máximo que la ley permite estipular para operaciones de crédito de dinero reajustables en moneda nacional que se aplican desde la fecha de la mora y hasta la de pago efectivo de toda la deuda.</p>"
        Else
            If NumeroCredito = 1 Then  'Si se da este caso, implica que no hubo mutuo y solo se demanda el mutuo complementario (No creo que esto se de).
                CodigoHTML = "<p>" & Espacios & Espacios & "Consta de la escritura pública de fecha " & Lecturas.FechaEscrita(CarpetaJudicialCreditosFechaEscritura) & ", otorgada en la Notaría de " & CarpetaJudicialCreditosCiudadEscritura & " de " & CarpetaJudicialCreditosNotarioEscritura & ", que el " & GlosaBanco & " otorgó a "
                CodigoHTML = CodigoHTML & CarpetaJudicial.LeerIdentificacionProfesionDireccion(CarpetaJudicialCodigo) & " un " & CarpetaJudicialCreditos.LeerTipoCreditoDescription(TipoCreditoName) & " por la cantidad equivalente de " & GlosaCredito & "</p>"
                CodigoHTML = CodigoHTML & "<p>" & Espacios & Espacios & "El deudor se obligó a pagar la cantidad recibida en mutuo en el plazo de " & CarpetaJudicialCreditosMesesPlazo & " meses, por medio de dividendos anticipados, mensuales y sucesivos, pactados en " & CarpetaJudicialCreditosMoneda & " del día de pago, dividendos que comprenden la amortización, los intereses pactados y la comisión estipulada en el mutuo.</p>"
                CodigoHTML = CodigoHTML & "<p>" & Espacios & Espacios & "Los dividendos deben pagarse dentro de los primeros diez días de cada mes, en efectivo, en el domicilio del acreedor. En el caso de no pago oportuno de cualquiera de los dividendos dentro del plazo establecido, se devengan intereses penales o moratorios equivalentes al máximo que la ley permite estipular para operaciones de crédito de dinero reajustables en moneda nacional que se aplican desde la fecha de la mora y hasta la de pago efectivo de toda la deuda.</p>"
            Else
                If CarpetaJudicialCreditos.LeerCantidadEscriturasPublicas(CarpetaJudicialCodigo) = 1 Then
                    CodigoHTML = "<p>" & Espacios & Espacios & "Adicionalmente por la misma escritura el " & GlosaBanco & " otorgó a "
                Else
                    CodigoHTML = "<p>" & Espacios & Espacios & "Adicionalmente, consta de la escritura pública de fecha " & Lecturas.FechaEscrita(CarpetaJudicialCreditosFechaEscritura) & ", otorgada en la Notaría de " & CarpetaJudicialCreditosCiudadEscritura & " de " & CarpetaJudicialCreditosNotarioEscritura & ", que el " & GlosaBanco & " otorgó a "
                End If
                CodigoHTML = CodigoHTML & CarpetaJudicial.LeerIdentificacionProfesionDireccion(CarpetaJudicialCodigo) & " un " & CarpetaJudicialCreditos.LeerTipoCreditoDescription(TipoCreditoName) & " por la cantidad equivalente de " & GlosaCredito & "</p>"
            End If
        End If
        CodigoHTML = CodigoHTML & "<p>" & Espacios & Espacios & "El dividendo que el deudor debió pagar el " & Lecturas.FechaEscrita(CarpetaJudicialCreditosFechaEntroEnMora) & " y los sucesivos dividendos a contar de ese, se encuentran impagos hasta esta fecha. De acuerdo con la liquidación practicada por el Banco Scotiabank Chile, la deuda es de "
        If CarpetaJudicialCreditosMoneda = "UF" Then
            CodigoHTML = CodigoHTML & FormatNumber(CarpetaJudicialCreditosDeudaCapitalUF / 10000, 4) & " " & CarpetaJudicialCreditosMoneda & " por concepto de capital insoluto y " & FormatNumber(CarpetaJudicialCreditosDeudaDividendosUF / 10000, 4) & " " & CarpetaJudicialCreditosMoneda & " por concepto de dividendos pendientes y de " & FormatNumber(CarpetaJudicialCreditosInteresesPenalesUF / 10000, 4) & " " & CarpetaJudicialCreditosMoneda & " por intereses penales, lo cual suma " & FormatNumber(CarpetaJudicialCreditosDeudaTotalUF / 10000, 4) & " " & CarpetaJudicialCreditosMoneda & ", equivalentes a " & FormatCurrency(CarpetaJudicialCreditosDeudaTotalPesos / 10000, 0) & ".-"
        Else
            CodigoHTML = CodigoHTML & FormatNumber(CarpetaJudicialCreditosDeudaCapitalPesos / 10000, 0) & " " & CarpetaJudicialCreditosMoneda & " por concepto de capital insoluto y " & FormatNumber(CarpetaJudicialCreditosDeudaDividendosPesos / 10000, 0) & " " & CarpetaJudicialCreditosMoneda & " por concepto de dividendos pendientes y de " & FormatNumber(CarpetaJudicialCreditosInteresesPenalesPesos / 10000, 0) & " " & CarpetaJudicialCreditosMoneda & " por intereses penales, lo cual suma " & FormatCurrency(CarpetaJudicialCreditosDeudaTotalPesos / 10000, 0) & ".-"
        End If
        CodigoHTML = CodigoHTML & "</p>"
        ' Ahora ponemos párrafo referido a garantia si es que fue constituida en forma de una hipoteca para el crédito
        CodigoHTML = CodigoHTML & CarpetaJudicialCreditos.ParrafoHipoteca(CarpetaJudicialCreditosId)
        ' Ahora ponemos párrafo referido a avales si es que fue necesario para el otorgamiento del crédito
        CodigoHTML = CodigoHTML & CarpetaJudicialCreditos.ParrafoAvales(CarpetaJudicialCreditosId)

        ParrafoMutuoEndosable = CodigoHTML
    End Function
    Public Function ParrafoMutuoPagare(ByVal CarpetaJudicialCreditosId As Long, NumeroCredito As Integer) As String
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Lecturas As New Lecturas

        Dim t As Boolean
        Dim CodigoHTML As String = ""

        Dim CarpetaJudicialCodigo As String = "" ' Etiqueta : # Interno - Control : txtCarpetaJudicialCodigo - Variable : CarpetaJudicialCodigo
        Dim CarpetaJudicialCreditosSecuencia As Long ' Etiqueta : # Secuencia - Control : txtCarpetaJudicialGastosSecuencia - Variable : CarpetaJudicialGastosSecuencia
        Dim CarpetaJudicialCreditosNroOperacion As String = "" ' Etiqueta : # Operación - Control : txtCarpetaJudicialNroOperacion - Variable : CarpetaJudicialNroOperacion
        Dim CarpetaJudicialCreditosCapInicial As Double ' Etiqueta : Capital Inicial - Control : txtCarpetaJudicialCapInicial - Variable : CarpetaJudicialCapInicial
        Dim CarpetaJudicialCreditosMoneda As String = "" ' Etiqueta : Moneda - Control : txtCarpetaJudicialMoneda - Variable : CarpetaJudicialMoneda
        Dim CarpetaJudicialCreditosFechaSuscripcion As Date ' Etiqueta : Fecha Suscripción - Control : txtCarpetaJudicialFechaSuscripcion - Variable : CarpetaJudicialFechaSuscripcion
        Dim CarpetaJudicialCreditosFechaEntroEnMora As Date ' Etiqueta : Fecha entro en mora - Control : txtCarpetaJudicialFechaEntroEnMora - Variable : CarpetaJudicialFechaEntroEnMora
        Dim BancoPrestamistaName As String = ""
        Dim TipoCreditoName As String = ""
        Dim CarpetaJudicialCreditosMesesPlazo As Long
        Dim CarpetaJudicialCreditosTasaInteresAnual As Double
        Dim CarpetaJudicialCreditosFechaPrimerVencimiento As Date
        Dim CarpetaJudicialCreditosValorCuota As Double
        Dim CarpetaJudicialCreditosUltimaCuota As Double
        Dim CarpetaJudicialCreditosFechaEscritura As Date
        Dim CarpetaJudicialCreditosNotarioEscritura As String
        Dim CarpetaJudicialCreditosCiudadEscritura As String
        Dim CarpetaJudicialCreditosDeudaCapitalPesos As Double
        Dim CarpetaJudicialCreditosDeudaCapitalUF As Double
        Dim CarpetaJudicialCreditosDeudaDividendosPesos As Double
        Dim CarpetaJudicialCreditosDeudaDividendosUF As Double
        Dim CarpetaJudicialCreditosInteresesPenalesPesos As Double
        Dim CarpetaJudicialCreditosInteresesPenalesUF As Double
        Dim CarpetaJudicialCreditosDeudaTotalPesos As Double
        Dim CarpetaJudicialCreditosDeudaTotalUF As Double
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"


        Dim Profesion As String = ""
        Dim GlosaBanco As String = ""
        Dim GlosaCredito As String = ""

        t = CarpetaJudicialCreditos.LeerCarpetaJudicialCreditos(CarpetaJudicialCreditosId, CarpetaJudicialCodigo, CarpetaJudicialCreditosSecuencia, TipoCreditoName, CarpetaJudicialCreditosNroOperacion, CarpetaJudicialCreditosCapInicial, CarpetaJudicialCreditosMoneda, CarpetaJudicialCreditosFechaSuscripcion, CarpetaJudicialCreditosFechaEntroEnMora, BancoPrestamistaName, CarpetaJudicialCreditosMesesPlazo, CarpetaJudicialCreditosTasaInteresAnual, CarpetaJudicialCreditosFechaPrimerVencimiento, CarpetaJudicialCreditosValorCuota, CarpetaJudicialCreditosUltimaCuota, CarpetaJudicialCreditosFechaEscritura, CarpetaJudicialCreditosNotarioEscritura, CarpetaJudicialCreditosCiudadEscritura, CarpetaJudicialCreditosDeudaCapitalPesos, CarpetaJudicialCreditosDeudaCapitalUF, CarpetaJudicialCreditosDeudaDividendosPesos, CarpetaJudicialCreditosDeudaDividendosUF, CarpetaJudicialCreditosInteresesPenalesPesos, CarpetaJudicialCreditosInteresesPenalesUF, CarpetaJudicialCreditosDeudaTotalPesos, CarpetaJudicialCreditosDeudaTotalUF)

        If BancoPrestamistaName <> "Banco Scotiabank Chile" Then
            GlosaBanco = BancoPrestamistaName & ", hoy Banco Scotiabank Chile"
        Else
            GlosaBanco = "Banco Scotiabank Chile"
        End If

        If CarpetaJudicialCreditosMoneda = "UF" Then
            GlosaCredito = FormatNumber(CarpetaJudicialCreditosCapInicial / 10000, 4) & " Unidades de Fomento, "
        Else  'Por defecto se asumen sólo dos monedas, si no es UF es pesos.
            GlosaCredito = FormatNumber(CarpetaJudicialCreditosCapInicial / 10000, 0) & " Pesos, "
        End If

        GlosaCredito = GlosaCredito & "con un interés del " & FormatNumber(CarpetaJudicialCreditosTasaInteresAnual / 10000, 2) & " % mensual vencido, pagadero en " & CarpetaJudicialCreditosMesesPlazo & " cuotas mensuales y sucesivas, las primeras " & (CarpetaJudicialCreditosMesesPlazo - 1) & " cuotas por un valor de "
        If CarpetaJudicialCreditosMoneda = "UF" Then
            GlosaCredito = GlosaCredito & FormatNumber(CarpetaJudicialCreditosValorCuota / 10000, 4) & " " & CarpetaJudicialCreditosMoneda & " y la última por un valor de " & FormatNumber(CarpetaJudicialCreditosUltimaCuota / 10000, 4) & " " & CarpetaJudicialCreditosMoneda & ", venciendo la primera de ellas el " & Lecturas.FechaEscrita(CarpetaJudicialCreditosFechaPrimerVencimiento) & ". "
        Else
            GlosaCredito = GlosaCredito & FormatNumber(CarpetaJudicialCreditosValorCuota / 10000, 0) & " " & CarpetaJudicialCreditosMoneda & " y la última por un valor de " & FormatNumber(CarpetaJudicialCreditosUltimaCuota / 10000, 0) & " " & CarpetaJudicialCreditosMoneda & ", venciendo la primera de ellas el " & Lecturas.FechaEscrita(CarpetaJudicialCreditosFechaPrimerVencimiento) & ". "
        End If

        CodigoHTML = "<p>" & Espacios & Espacios & "Por otra parte, con fecha " & Lecturas.FechaEscrita(CarpetaJudicialCreditosFechaSuscripcion) & ", el " & GlosaBanco & " otorgó a "
        CodigoHTML = CodigoHTML & CarpetaJudicial.LeerIdentificacionProfesionDireccion(CarpetaJudicialCodigo) & " un " & CarpetaJudicialCreditos.LeerTipoCreditoDescription(TipoCreditoName) & " por " & GlosaCredito & "</p>"
        CodigoHTML = CodigoHTML & "<p>" & Espacios & Espacios & "La cuota que debió pagar el " & Lecturas.FechaEscrita(CarpetaJudicialCreditosFechaEntroEnMora) & " y las siguientes, se encuentran vencidas e impagas. En el pagaré se estipuló que la mora en el pago de cualquier cuota, da derecho al acreedor para exigir toda la obligación como si fuere de plazo vencido.</p>"
        'De acuerdo al cronograma del plan de pagos que se acompaña, el saldo de capital era de $ 838.795.-
        CodigoHTML = CodigoHTML & "<p>" & Espacios & Espacios & "De acuerdo al cronograma del plan de pagos que se acompaña, el saldo de capital era de "

        If CarpetaJudicialCreditosMoneda = "UF" Then
            CodigoHTML = CodigoHTML & FormatNumber(CarpetaJudicialCreditosDeudaTotalUF / 10000, 4) & " " & CarpetaJudicialCreditosMoneda & ".-"
        Else
            CodigoHTML = CodigoHTML & FormatNumber(CarpetaJudicialCreditosDeudaTotalPesos / 10000, 0) & " " & CarpetaJudicialCreditosMoneda & ".-"
        End If

        ParrafoMutuoPagare = CodigoHTML
    End Function



    Public Function ParrafoHipoteca(ByVal CarpetaJudicialCreditosId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"


        sSQL = "SELECT CarpetaJudicialHipotecasPorCarpetaJudicialCreditos.CarpetaJudicialCreditosId As Id, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasDescription As Descripcion, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionFojas As Fojas, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionNumero As Numero, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionAno As Ano, CarpetaJudicialHipotecas.CarpetaJudicialHipotecasInscripcionCiudad As Ciudad "
        sSQL = sSQL & "FROM CarpetaJudicialHipotecasPorCarpetaJudicialCreditos INNER JOIN CarpetaJudicialHipotecas ON CarpetaJudicialHipotecasPorCarpetaJudicialCreditos.CarpetaJudicialHipotecasId = CarpetaJudicialHipotecas.CarpetaJudicialHipotecasId "
        sSQL = sSQL & "WHERE (((CarpetaJudicialHipotecasPorCarpetaJudicialCreditos.CarpetaJudicialCreditosId)=" & CarpetaJudicialCreditosId & "))"

        Dim CodigoHTML As String = ""

        ParrafoHipoteca = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    CodigoHTML = "<p>" & Espacios & Espacios & "En garantía de las obligaciones que el deudor asumió en el contrato de mutuo antes referido, en el mismo instrumento constituyó hipoteca sobre el inmueble de su propiedad consistente en " & dtr("Descripcion").ToString & " inscrita a su nombre fojas " & dtr("Fojas").ToString & " Número " & dtr("Numero").ToString & " del Registro de Propiedad del Conservador de Bienes Raíces de " & dtr("Ciudad").ToString & " del año " & dtr("Ano").ToString & ".</p>"
                Else
                    CodigoHTML = CodigoHTML & "<p>" & Espacios & Espacios & "Adicionalmente, constituyó hipoteca sobre el inmueble de su propiedad consistente en " & dtr("Descripcion").ToString & " inscrita a su nombre fojas " & dtr("Fojas").ToString & " Número " & dtr("Numero").ToString & " del Registro de Propiedad del Conservador de Bienes Raíces de " & dtr("Ciudad").ToString & " del año " & dtr("Ano").ToString & ".</p>"
                End If

            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try

        ParrafoHipoteca = CodigoHTML

    End Function
    Public Function ParrafoAvales(ByVal CarpetaJudicialCreditosId As Long) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim Espacios As String = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"

        sSQL = "SELECT CarpetaJudicialAvalesPorCarpetaJudicialCreditos.CarpetaJudicialCreditosId, CarpetaJudicialAvales.CarpetaJudicialAvalesRUT As RUT, CarpetaJudicialAvales.CarpetaJudicialAvalesNombres As Nombres, CarpetaJudicialAvales.CarpetaJudicialAvalesApellidos As Apellidos, CarpetaJudicialAvales.CarpetaJudicialAvalesDireccion As Direccion, CarpetaJudicialAvales.CarpetaJudicialAvalesComuna As Comuna, CarpetaJudicialAvales.CarpetaJudicialAvalesProfesion As Profesion, CarpetaJudicialAvales.CarpetaJudicialAvalesIsReciproco As IsReciproco "
        sSQL = sSQL & "FROM CarpetaJudicialAvalesPorCarpetaJudicialCreditos INNER JOIN CarpetaJudicialAvales ON CarpetaJudicialAvalesPorCarpetaJudicialCreditos.CarpetaJudicialAvalesId = CarpetaJudicialAvales.CarpetaJudicialAvalesId "
        sSQL = sSQL & "WHERE (((CarpetaJudicialAvalesPorCarpetaJudicialCreditos.CarpetaJudicialCreditosId)=" & CarpetaJudicialCreditosId & "))"

        Dim CodigoHTML As String = ""

        ParrafoAvales = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If i = 1 Then
                    CodigoHTML = "<p>" & Espacios & Espacios & "En la misma escritura, " & dtr("Nombres").ToString & " " & dtr("Apellidos").ToString & ", " & dtr("Profesion").ToString & ", rut " & dtr("rut").ToString & ", con domicilio en " & dtr("Domicilio").ToString & ", comuna " & dtr("Comuna").ToString & ", se constituyó como aval y codeudor solidario, en relación con las obligaciones de ella provenientes del  mutuo antes citado. "
                    If CBool(dtr("IsReciproco").ToString) = True Then
                        CodigoHTML = CodigoHTML & "Adicionalmente, " & CarpetaJudicial.LeerNombreCompletoDeudor(CarpetaJudicialCreditosId) & "y " & UCase(dtr("Nombres").ToString) & " " & UCase(dtr("Apellidos").ToString) & " se otorgaron mandato judicial recíproco, de modo que la notificación de uno cualquiera de ellos emplaza al otro."
                    End If
                    CodigoHTML = CodigoHTML & "</p>"
                Else
                    CodigoHTML = CodigoHTML & "<p>" & Espacios & Espacios & "Adicionalmente, " & dtr("Nombres").ToString & " " & dtr("Apellidos").ToString & ", " & dtr("Profesion").ToString & ", rut " & dtr("rut").ToString & ", con domicilio en " & dtr("Domicilio").ToString & ", comuna " & dtr("Comuna").ToString & ", se constituyó como aval y codeudor solidario, en relación con las obligaciones de ella provenientes del  mutuo antes citado. "
                    If CBool(dtr("IsReciproco").ToString) = True Then
                        CodigoHTML = CodigoHTML & "Adicionalmente, " & CarpetaJudicial.LeerNombreCompletoDeudor(CarpetaJudicialCreditosId) & "y " & UCase(dtr("Nombres").ToString) & " " & UCase(dtr("Apellidos").ToString) & " se otorgaron mandato judicial recíproco, de modo que la notificación de uno cualquiera de ellos emplaza al otro."
                    End If
                    CodigoHTML = CodigoHTML & "</p>"
                End If

            End While
            dtr.Close()
        Catch
            CodigoHTML = ""
        End Try

        ParrafoAvales = CodigoHTML

    End Function



    Public Function LeerMasterNameMasterId(ByVal CarpetaJudicialCreditosId As Long, ByRef MasterId As Long, ByRef MasterName As String) As Boolean
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT CarpetaJudicial.TareasId As MasterId, Tareas.TareasCodigo As MasterName "
        sSQL = sSQL & "FROM (CarpetaJudicialCreditos INNER JOIN CarpetaJudicial ON CarpetaJudicialCreditos.CarpetaJudicialCodigo = CarpetaJudicial.CarpetaJudicialCodigo) INNER JOIN Tareas ON CarpetaJudicial.TareasId = Tareas.TareasId "
        sSQL = sSQL & "WHERE (((CarpetaJudicialCreditos.[CarpetaJudicialCreditosId])=" & CarpetaJudicialCreditosId & "))"
        LeerMasterNameMasterId = False
        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                MasterId = CLng(dtr("MasterId").ToString)
                MasterName = CStr(dtr("MasterName").ToString)
                LeerMasterNameMasterId = True
            End While
            dtr.Close()
        Catch
            LeerMasterNameMasterId = False
        End Try
    End Function
    Public Function LeerTipoCreditoDescription(ByVal TipoCreditoName As String) As String
        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String

        sSQL = "SELECT TipoCredito.TipoCreditoDescription As Descripcion "
        sSQL = sSQL & "FROM TipoCredito "
        sSQL = sSQL & "WHERE TipoCredito.TipoCreditoName = '" & TipoCreditoName & "'"

        LeerTipoCreditoDescription = ""

        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                LeerTipoCreditoDescription = CStr(dtr("Descripcion").ToString)
            End While
            dtr.Close()
        Catch
            LeerTipoCreditoDescription = ""
        End Try

    End Function
    Public Function ListarDatosDelCredito(ByVal CarpetaJudicialCodigo As String, Optional ByVal IsPagares As Boolean = False, Optional ByVal Clase As String = "invisible", Optional ByVal Formato As String = "CodigoHTML") As String
        Dim CodigoHTML As String = ""
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Dim Creditos(15) As String
        Dim NumeroCreditos As Integer = CarpetaJudicialCreditos.LeerDatosCreditosPorTipo(CarpetaJudicialCodigo, IsPagares, Creditos)
        Dim i As Integer
        ListarDatosDelCredito = ""

        If NumeroCreditos > 0 Then
            If IsPagares = False Then
                If Formato = "CodigoHTML" Then
                    CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td><h1>" & "Créditos: Mutuos y Mutuos Complementarios" & "</h1></td>"
                    CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & "Mutuos" & "')"" /></td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                    CodigoHTML = CodigoHTML & "</table>"
                    CodigoHTML = CodigoHTML & "<div id=""subgrilla" & "Mutuos" & """ class=""" & Clase & """>"
                    CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
                Else
                    CodigoHTML = CodigoHTML & "<table width=""660"" border=""1"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Verdana;font-size:8pt;border:1px solid #FFFFFF;"">"
                End If
            Else
                If Formato = "CodigoHTML" Then
                    CodigoHTML = CodigoHTML & "<table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""popups_titulo_con_enlaces"">"
                    CodigoHTML = CodigoHTML & "<tr>"
                    CodigoHTML = CodigoHTML & "<td><h1>" & "Créditos: Pagarés" & "</h1></td>"
                    CodigoHTML = CodigoHTML & "<td align=""right""><img src=""imgs/expandir.png"" width=""25"" height=""25"" alt=""Expandir"" onclick=""aparecer('subgrilla" & "Pagares" & "')"" /></td>"
                    CodigoHTML = CodigoHTML & "</tr>"
                    CodigoHTML = CodigoHTML & "</table>"
                    CodigoHTML = CodigoHTML & "<div id=""subgrilla" & "Pagares" & """ class=""" & Clase & """>"
                    CodigoHTML = CodigoHTML & "<table class=""popup_tabla_de_datos_tareas"">"
                Else
                    CodigoHTML = CodigoHTML & "<table width=""660"" border=""1"" cellpadding=""0"" cellspacing=""0"" style=""font-family:Verdana;font-size:8pt;border:1px solid #FFFFFF;"">"
                End If
            End If
            For i = 0 To 15
                CodigoHTML = CodigoHTML & Creditos(i)
            Next
            CodigoHTML = CodigoHTML & "</table>"
            If Formato = "CodigoHTML" Then
                CodigoHTML = CodigoHTML & "</div>"
            End If
        End If

        ListarDatosDelCredito = CodigoHTML
    End Function
    Public Function LeerDatosCreditosPorTipo(ByVal CarpetaJudicialCodigo As String, ByVal IsPagares As Boolean, ByRef Creditos() As String) As Integer

        Dim AccesoEA As New AccesoEA
        Dim dtr As IDataReader
        Dim sSQL As String
        Dim i As Integer = 0
        Dim j As Integer = 0

        sSQL = "Select CarpetaJudicialCreditosNroOperacion, CarpetaJudicialCreditosCapInicial, CarpetaJudicialCreditosMoneda, CarpetaJudicialCreditosFechaSuscripcion, CarpetaJudicialCreditosFechaEntroEnMora, BancoPrestamistaName, "
        sSQL = sSQL & "CarpetaJudicialCreditosMesesPlazo, CarpetaJudicialCreditosTasaInteresAnual, CarpetaJudicialCreditosFechaPrimerVencimiento, CarpetaJudicialCreditosValorCuota, CarpetaJudicialCreditosUltimaCuota, CarpetaJudicialCreditosFechaEscritura, "
        sSQL = sSQL & "CarpetaJudicialCreditosNotarioEscritura, CarpetaJudicialCreditosCiudadEscritura, CarpetaJudicialCreditosDeudaCapitalPesos, CarpetaJudicialCreditosDeudaCapitalUF, CarpetaJudicialCreditosDeudaDividendosPesos, CarpetaJudicialCreditosDeudaDividendosUF, "
        sSQL = sSQL & "CarpetaJudicialCreditosInteresesPenalesPesos, CarpetaJudicialCreditosInteresesPenalesUF, CarpetaJudicialCreditosDeudaTotalPesos, CarpetaJudicialCreditosDeudaTotalUF "
        sSQL = sSQL & "FROM CarpetaJudicialCreditos "
        If IsPagares = False Then
            sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' AND CarpetaJudicialCreditos.TipoCreditoName <> 'Pagare' "
        Else
            sSQL = sSQL & "WHERE CarpetaJudicialCreditos.CarpetaJudicialCodigo = '" & CarpetaJudicialCodigo & "' AND CarpetaJudicialCreditos.TipoCreditoName = 'Pagare' "
        End If
        sSQL = sSQL & "ORDER BY CarpetaJudicialCreditos.CarpetaJudicialCreditosNroOperacion"

        Dim CodigoHTML As String = ""
        Dim DeudaTotalPesos As Double = 0

        LeerDatosCreditosPorTipo = 0

        If IsPagares = False Then
            Creditos(0) = "<tr><th align=""left""># de Operación</th>"
            Creditos(1) = "<tr><th align=""left"">Banco</th>"
            Creditos(2) = "<tr><th align=""left"">Fecha Suscripción</th>"
            Creditos(3) = "<tr><th align=""left"">Fecha Escritura</th>"
            Creditos(4) = "<tr><th align=""left"">Notaria</th>"
            Creditos(5) = "<tr><th align=""left"">Ciudad</th>"
            Creditos(6) = "<tr><th align=""left"">Capital Inicial</th>"
            Creditos(7) = "<tr><th align=""left"">Moneda</th>"
            Creditos(8) = "<tr><th align=""left"">Plazo</th>"
            Creditos(9) = "<tr><th align=""left"">Tasa de Interés</th>"
            Creditos(10) = "<tr><th align=""left"">Fecha Entro en Mora</th>"
            Creditos(11) = "<tr><th align=""left"">Deuda Capital</th>"
            Creditos(12) = "<tr><th align=""left"">Deuda Dividendos</th>"
            Creditos(13) = "<tr><th align=""left"">Intereses Penales</th>"
            Creditos(14) = "<tr><th align=""left"">Deuda Total en UF</th>"
            Creditos(15) = "<tr><th align=""left"">Deuda Total en $</th>"
        Else
            Creditos(0) = "<tr><th align=""left""># de Operación</th>"
            Creditos(1) = "<tr><th align=""left"">Banco</th>"
            Creditos(2) = "<tr><th align=""left"">Fecha Suscripción</th>"
            Creditos(3) = "<tr><th align=""left"">Fecha Escritura</th>"
            Creditos(4) = "<tr><th align=""left"">Notaria</th>"
            Creditos(5) = "<tr><th align=""left"">Ciudad</th>"
            Creditos(6) = "<tr><th align=""left"">Capital Inicial</th>"
            Creditos(7) = "<tr><th align=""left"">Moneda</th>"
            Creditos(8) = "<tr><th align=""left"">Plazo</th>"
            Creditos(9) = "<tr><th align=""left"">Tasa de Interés</th>"
            Creditos(10) = "<tr><th align=""left"">Primer Vencimiento</th>"
            Creditos(11) = "<tr><th align=""left"">Cuota Mensual</th>"
            Creditos(12) = "<tr><th align=""left"">Última Cuota</th>"
            Creditos(13) = "<tr><th align=""left"">Fecha Entro en Mora</th>"
            Creditos(14) = "<tr><th align=""left"">Deuda Capital</th>"
            Creditos(15) = "<tr><th align=""left"">Deuda Total en $</th>"
        End If



        Try
            dtr = AccesoEA.ListarRegistros(sSQL)
            While dtr.Read
                i = i + 1
                If IsPagares = False Then
                    Creditos(0) = Creditos(0) & "<th>" & dtr("CarpetaJudicialCreditosNroOperacion").ToString & "</th>"
                    Creditos(1) = Creditos(1) & "<td>" & dtr("BancoPrestamistaName").ToString & "</td>"
                    If Len(dtr("CarpetaJudicialCreditosFechaSuscripcion").ToString) = 0 Then
                        Creditos(2) = Creditos(2) & "<td align=""right"">" & "No registrada" & "</td>"
                    Else
                        Creditos(2) = Creditos(2) & "<td align=""right"">" & FormatDateTime(dtr("CarpetaJudicialCreditosFechaSuscripcion").ToString, DateFormat.ShortDate) & "</td>"
                    End If
                    If Len(dtr("CarpetaJudicialCreditosFechaEscritura").ToString) = 0 Then
                        Creditos(3) = Creditos(3) & "<td align=""right"">" & "No registrada" & "</td>"
                    Else
                        Creditos(3) = Creditos(3) & "<td align=""right"">" & FormatDateTime(dtr("CarpetaJudicialCreditosFechaEscritura").ToString, DateFormat.ShortDate) & "</td>"
                    End If
                    Creditos(4) = Creditos(4) & "<td>" & dtr("CarpetaJudicialCreditosNotarioEscritura").ToString & "</td>"
                    Creditos(5) = Creditos(5) & "<td>" & dtr("CarpetaJudicialCreditosCiudadEscritura").ToString & "</td>"
                    If Len(dtr("CarpetaJudicialCreditosMesesPlazo").ToString) = 0 Then
                        Creditos(8) = Creditos(8) & "<td align=""right"">" & "No Registrada" & "</td>"
                    Else
                        Creditos(8) = Creditos(8) & "<td align=""right"">" & dtr("CarpetaJudicialCreditosMesesPlazo").ToString & "</td>"
                    End If
                    If Len(dtr("CarpetaJudicialCreditosTasaInteresAnual").ToString) = 0 Then
                        Creditos(9) = Creditos(9) & "<td align=""right"">" & "No registrada" & "</td>"
                    Else
                        Creditos(9) = Creditos(9) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosTasaInteresAnual").ToString / 10000, 2) & "</td>"
                    End If
                    If Len(dtr("CarpetaJudicialCreditosFechaEntroEnMora").ToString) = 0 Then
                        Creditos(10) = Creditos(10) & "<td align=""right"">" & "No registrada" & "</td>"
                    Else
                        Creditos(10) = Creditos(10) & "<td align=""right"">" & FormatDateTime(dtr("CarpetaJudicialCreditosFechaEntroEnMora").ToString, DateFormat.ShortDate) & "</td>"
                    End If
                    If dtr("CarpetaJudicialCreditosMoneda").ToString = "UF" Then
                        If Len(dtr("CarpetaJudicialCreditosCapInicial").ToString) = 0 Then
                            Creditos(6) = Creditos(6) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(6) = Creditos(6) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosCapInicial").ToString / 10000, 4) & "</td>"
                        End If
                        Creditos(7) = Creditos(7) & "<td>" & dtr("CarpetaJudicialCreditosMoneda").ToString & "</td>"
                        If Len(dtr("CarpetaJudicialCreditosDeudaCapitalUF").ToString) = 0 Then
                            Creditos(11) = Creditos(11) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(11) = Creditos(11) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosDeudaCapitalUF").ToString / 10000, 4) & "</td>"
                        End If
                        If Len(dtr("CarpetaJudicialCreditosDeudaDividendosUF").ToString) = 0 Then
                            Creditos(12) = Creditos(12) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(12) = Creditos(12) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosDeudaDividendosUF").ToString / 10000, 4) & "</td>"
                        End If
                        If Len(dtr("CarpetaJudicialCreditosInteresesPenalesUF").ToString) = 0 Then
                            Creditos(13) = Creditos(13) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(13) = Creditos(13) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosInteresesPenalesUF").ToString / 10000, 4) & "</td>"
                        End If
                        If Len(dtr("CarpetaJudicialCreditosDeudaTotalUF").ToString) = 0 Then
                            Creditos(14) = Creditos(14) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(14) = Creditos(14) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosDeudaTotalUF").ToString / 10000, 4) & "</td>"
                        End If
                        If Len(dtr("CarpetaJudicialCreditosDeudaTotalPesos").ToString) = 0 Then
                            Creditos(15) = Creditos(15) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(15) = Creditos(15) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosDeudaTotalPesos").ToString / 10000, 0) & "</td>"
                        End If
                    Else
                        If Len(dtr("CarpetaJudicialCreditosCapInicial").ToString) = 0 Then
                            Creditos(6) = Creditos(6) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(6) = Creditos(6) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosCapInicial").ToString / 10000, 0) & "</td>"
                        End If
                        Creditos(7) = Creditos(7) & "<td>" & dtr("CarpetaJudicialCreditosMoneda").ToString & "</td>"
                        If Len(dtr("CarpetaJudicialCreditosDeudaCapitalPesos").ToString) = 0 Then
                            Creditos(11) = Creditos(11) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(11) = Creditos(11) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosDeudaCapitalPesos").ToString / 10000, 0) & "</td>"
                        End If
                        If Len(dtr("CarpetaJudicialCreditosDeudaDividendosPesos").ToString) = 0 Then
                            Creditos(12) = Creditos(12) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(12) = Creditos(12) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosDeudaDividendosPesos").ToString / 10000, 0) & "</td>"
                        End If
                        If Len(dtr("CarpetaJudicialCreditosInteresesPenalesPesos").ToString) = 0 Then
                            Creditos(13) = Creditos(13) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(13) = Creditos(13) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosInteresesPenalesPesos").ToString / 10000, 0) & "</td>"
                        End If

                        Creditos(14) = Creditos(14) & "<td>" & "" & "</td>"
                        If Len(dtr("CarpetaJudicialCreditosDeudaTotalPesos").ToString) = 0 Then
                            Creditos(15) = Creditos(15) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(15) = Creditos(15) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosDeudaTotalPesos").ToString / 10000, 0) & "</td>"
                        End If
                    End If
                Else
                    Creditos(0) = Creditos(0) & "<th>" & dtr("CarpetaJudicialCreditosNroOperacion").ToString & "</th>"
                    Creditos(1) = Creditos(1) & "<td>" & dtr("BancoPrestamistaName").ToString & "</td>"
                    If Len(dtr("CarpetaJudicialCreditosFechaSuscripcion").ToString) = 0 Then
                        Creditos(2) = Creditos(2) & "<td align=""right"">" & "No registrada" & "</td>"
                    Else
                        Creditos(2) = Creditos(2) & "<td align=""right"">" & FormatDateTime(dtr("CarpetaJudicialCreditosFechaSuscripcion").ToString, DateFormat.ShortDate) & "</td>"
                    End If
                    If Len(dtr("CarpetaJudicialCreditosFechaEscritura").ToString) = 0 Then
                        Creditos(3) = Creditos(3) & "<td align=""right"">" & "No registrada" & "</td>"
                    Else
                        Creditos(3) = Creditos(3) & "<td align=""right"">" & FormatDateTime(dtr("CarpetaJudicialCreditosFechaEscritura").ToString, DateFormat.ShortDate) & "</td>"
                    End If
                    Creditos(4) = Creditos(4) & "<td>" & dtr("CarpetaJudicialCreditosNotarioEscritura").ToString & "</td>"
                    Creditos(5) = Creditos(5) & "<td>" & dtr("CarpetaJudicialCreditosCiudadEscritura").ToString & "</td>"
                    If Len(dtr("CarpetaJudicialCreditosMesesPlazo").ToString) = 0 Then
                        Creditos(8) = Creditos(8) & "<td align=""right"">" & "No Registrada" & "</td>"
                    Else
                        Creditos(8) = Creditos(8) & "<td align=""right"">" & dtr("CarpetaJudicialCreditosMesesPlazo").ToString & "</td>"
                    End If
                    If Len(dtr("CarpetaJudicialCreditosTasaInteresAnual").ToString) = 0 Then
                        Creditos(9) = Creditos(9) & "<td align=""right"">" & "No registrada" & "</td>"
                    Else
                        Creditos(9) = Creditos(9) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosTasaInteresAnual").ToString / 10000, 2) & "</td>"
                    End If
                    If Len(dtr("CarpetaJudicialCreditosFechaEntroEnMora").ToString) = 0 Then
                        Creditos(13) = Creditos(13) & "<td align=""right"">" & "No registrada" & "</td>"
                    Else
                        Creditos(13) = Creditos(13) & "<td align=""right"">" & FormatDateTime(dtr("CarpetaJudicialCreditosFechaEntroEnMora").ToString, DateFormat.ShortDate) & "</td>"
                    End If
                    If Len(dtr("CarpetaJudicialCreditosFechaPrimerVencimiento").ToString) = 0 Then
                        Creditos(10) = Creditos(10) & "<td align=""right"">" & "No registrada" & "</td>"
                    Else
                        Creditos(10) = Creditos(10) & "<td align=""right"">" & FormatDateTime(dtr("CarpetaJudicialCreditosFechaPrimerVencimiento").ToString, DateFormat.ShortDate) & "</td>"
                    End If

                    If dtr("CarpetaJudicialCreditosMoneda").ToString = "UF" Then
                        If Len(dtr("CarpetaJudicialCreditosCapInicial").ToString) = 0 Then
                            Creditos(6) = Creditos(6) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(6) = Creditos(6) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosCapInicial").ToString / 10000, 4) & "</td>"
                        End If
                        Creditos(7) = Creditos(7) & "<td>" & dtr("CarpetaJudicialCreditosMoneda").ToString & "</td>"
                        If Len(dtr("CarpetaJudicialCreditosDeudaCapitalUF").ToString) = 0 Then
                            Creditos(14) = Creditos(14) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(14) = Creditos(14) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosDeudaCapitalUF").ToString / 10000, 4) & "</td>"
                        End If
                        If Len(dtr("CarpetaJudicialCreditosValorCuota").ToString) = 0 Then
                            Creditos(11) = Creditos(11) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(11) = Creditos(11) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosValorCuota").ToString / 10000, 4) & "</td>"
                        End If
                        If Len(dtr("CarpetaJudicialCreditosUltimaCuota").ToString) = 0 Then
                            Creditos(12) = Creditos(12) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(12) = Creditos(12) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosUltimaCuota").ToString / 10000, 4) & "</td>"
                        End If
                        If Len(dtr("CarpetaJudicialCreditosDeudaTotalPesos").ToString) = 0 Then
                            Creditos(15) = Creditos(15) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(15) = Creditos(15) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosDeudaTotalPesos").ToString / 10000, 0) & "</td>"
                        End If
                    Else
                        If Len(dtr("CarpetaJudicialCreditosCapInicial").ToString) = 0 Then
                            Creditos(6) = Creditos(6) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(6) = Creditos(6) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosCapInicial").ToString / 10000, 0) & "</td>"
                        End If
                        Creditos(7) = Creditos(7) & "<td>" & dtr("CarpetaJudicialCreditosMoneda").ToString & "</td>"
                        If Len(dtr("CarpetaJudicialCreditosDeudaCapitalPesos").ToString) = 0 Then
                            Creditos(14) = Creditos(14) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(14) = Creditos(14) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosDeudaCapitalUF").ToString / 10000, 0) & "</td>"
                        End If
                        If Len(dtr("CarpetaJudicialCreditosValorCuota").ToString) = 0 Then
                            Creditos(11) = Creditos(11) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(11) = Creditos(11) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosValorCuota").ToString / 10000, 0) & "</td>"
                        End If
                        If Len(dtr("CarpetaJudicialCreditosUltimaCuota").ToString) = 0 Then
                            Creditos(12) = Creditos(12) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(12) = Creditos(12) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosUltimaCuota").ToString / 10000, 0) & "</td>"
                        End If
                        If Len(dtr("CarpetaJudicialCreditosDeudaTotalPesos").ToString) = 0 Then
                            Creditos(15) = Creditos(15) & "<td align=""right"">" & "No registrado" & "</td>"
                        Else
                            Creditos(15) = Creditos(15) & "<td align=""right"">" & FormatNumber(dtr("CarpetaJudicialCreditosDeudaTotalPesos").ToString / 10000, 0) & "</td>"
                        End If
                    End If
                End If


            End While
            dtr.Close()
        Catch
            LeerDatosCreditosPorTipo = 0
        End Try
        For j = 0 To 15
            Creditos(j) = Creditos(j) & "</tr>"
        Next

        LeerDatosCreditosPorTipo = i

    End Function
End Class
