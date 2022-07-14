
Partial Class PerfilCarpeta
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim CarpetaJudicialId As String = Request.QueryString("Id")
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim CarpetaJudicialCreditos As New CarpetaJudicialCreditos
        Dim CarpetaJudicialDirecciones As New CarpetaJudicialDirecciones
        Dim CarpetaJudicialAvales As New CarpetaJudicialAvales
        Dim CarpetaJudicialHipotecas As New CarpetaJudicialHipotecas
        Dim CarpetaJudicialDocs As New CarpetaJudicialDocs
        Dim CarpetaJudicialGastos As New CarpetaJudicialGastos
        Dim CarpetaJudicialLog As New CarpetaJudicialLog
        Dim CarpetaJudicialCodigo As String = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
        Dim TareasId As Long = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
        Dim Tareas As New Tareas
        MyDeudor.Controls.Add(New LiteralControl(Tareas.ListarDatosDelDeudorPorTareasId(TareasId, CarpetaJudicialCodigo, "visible")))
        MisResponsables.Controls.Add(New LiteralControl(CarpetaJudicial.ListarDatosDelProcesoJudicial(CarpetaJudicialId, "visible")))
        MisMutuos.Controls.Add(New LiteralControl(CarpetaJudicialCreditos.ListarDatosDelCredito(CarpetaJudicialCodigo, False, "visible")))
        MisPagares.Controls.Add(New LiteralControl(CarpetaJudicialCreditos.ListarDatosDelCredito(CarpetaJudicialCodigo, True, "visible")))
        MisDirecciones.Controls.Add(New LiteralControl(CarpetaJudicialDirecciones.ListarDirecciones(CarpetaJudicialCodigo, "visible")))
        MisAvales.Controls.Add(New LiteralControl(CarpetaJudicialAvales.ListarAvales(CarpetaJudicialCodigo, "visible")))
        MisHipotecas.Controls.Add(New LiteralControl(CarpetaJudicialHipotecas.ListarHipotecas(CarpetaJudicialCodigo, "visible")))
        MisDocumentos.Controls.Add(New LiteralControl(CarpetaJudicialDocs.ListarDocs(CarpetaJudicialCodigo, "visible")))
        MisGastos.Controls.Add(New LiteralControl(CarpetaJudicialGastos.ListarGastos(CarpetaJudicialCodigo, "visible")))
        MiBitacora.Controls.Add(New LiteralControl(CarpetaJudicialLog.ListarLog(CarpetaJudicialCodigo, "visible")))

    End Sub
End Class
