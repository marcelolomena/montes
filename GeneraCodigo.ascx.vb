Imports System.IO
Imports System.Net.Mail
Partial Class GeneraCodigo
    Inherits System.Web.UI.UserControl
    Protected Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim AccesoFiles = New AccesoFiles
        Dim t As Boolean = True
        Dim NombreArchivo As String = ""

        t = AccesoFiles.GrabarArchivoEntidadesascx(NombreArchivo, "Ficha" & txtNombreTabla.Text)
        lblNombreArchivoascx.Text = NombreArchivo
        HyperLink2.Text = "Ver " & "Ficha" & txtNombreTabla.Text & ".ascx"
        HyperLink2.NavigateUrl = NombreArchivo
        Dim qk = HttpContext.Current.Server.MapPath(".")
        lblNombreArchivoascxDestino.Text = qk & "\" & "Ficha" & txtNombreTabla.Text & ".ascx"
    End Sub
    Protected Sub Button3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim AccesoFiles = New AccesoFiles
        Dim t As Boolean = True
        Dim NombreArchivo As String = ""
        Dim FormularioWeb As New FormularioWeb

        t = AccesoFiles.GrabarArchivoEntidadesascxvb(NombreArchivo, "Ficha" & txtNombreTabla.Text, FormularioWeb.LeerFormularioWebNumber("Ficha de " & txtNombreTabla.Text), txtNombreTabla.Text & ".Leer" & txtNombreTabla.Text, txtNombreTabla.Text & "." & txtNombreTabla.Text & "Update", txtNombreTabla.Text)

        lblNombreArchivoascxvb.Text = NombreArchivo
        HyperLink3.Text = "Ver " & "Ficha" & txtNombreTabla.Text & ".ascx.vb"
        HyperLink3.NavigateUrl = NombreArchivo
        Dim qk = HttpContext.Current.Server.MapPath(".")
        lblNombreArchivoascxvbDestino.Text = qk & "\" & "Ficha" & txtNombreTabla.Text & ".ascx.vb"
    End Sub
    Protected Sub Button5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim AccesoFiles = New AccesoFiles
        Dim t As Boolean = True
        Dim NombreArchivo As String = ""
        Dim FormularioWeb As New FormularioWeb
        Dim CampoId As String = AccesoFiles.CampoIdentity(txtNombreTabla.Text)
        Dim CampoMaestro As String = AccesoFiles.CampoName(txtParentTableName.Text)
        Dim CampoSecuencia As String = AccesoFiles.CampoSecuencia(txtNombreTabla.Text)

        t = AccesoFiles.GrabarArchivoNewDetailsascxvb(NombreArchivo, "Ficha" & txtNombreTabla.Text, FormularioWeb.LeerFormularioWebNumber("Ficha de " & txtNombreTabla.Text), txtNombreTabla.Text & ".Leer" & txtNombreTabla.Text, txtNombreTabla.Text & "." & txtNombreTabla.Text & "Update", txtNombreTabla.Text & "." & txtNombreTabla.Text & "Delete", CampoId, CampoMaestro, CampoSecuencia, txtNombreTabla.Text, txtNombreTabla.Text)
        lblNombreArchivoNewDetailsascxvb.Text = NombreArchivo
        HyperLink5.Text = "Ver " & "Ficha" & txtNombreTabla.Text & ".ascx.vb"
        HyperLink5.NavigateUrl = NombreArchivo
        Dim qk = HttpContext.Current.Server.MapPath(".")
        lblNombreArchivoNewDetailsascxvbDestino.Text = qk & "\" & "Ficha" & txtNombreTabla.Text & ".ascx.vb"
    End Sub
    Protected Sub Button4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim AccesoFiles = New AccesoFiles
        Dim t As Boolean = True
        Dim NombreArchivo As String = ""

        t = AccesoFiles.GrabarArchivoNewDetailsascx(NombreArchivo, "Ficha" & txtNombreTabla.Text)
        LblNombreArchivoNewDetailsascx.Text = NombreArchivo
        HyperLink4.Text = "Ver " & "Ficha" & txtNombreTabla.Text & ".ascx"
        HyperLink4.NavigateUrl = NombreArchivo
        Dim qk = HttpContext.Current.Server.MapPath(".")
        LblNombreArchivoNewDetailsascxDestino.Text = qk & "\" & "Ficha" & txtNombreTabla.Text & ".ascx"
    End Sub
    Protected Sub Button6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim AccesoFiles = New AccesoFiles
        Dim t As Boolean = True
        Dim NombreArchivo As String = ""

        t = AccesoFiles.GrabarArchivoBuscaEntidadesascx(NombreArchivo, "Busca" & txtNombreTabla.Text)
        LblNombreArchivoBuscaEntidadesascx.Text = NombreArchivo
        HyperLink6.Text = "Ver " & "Busca" & txtNombreTabla.Text & ".ascx"
        HyperLink6.NavigateUrl = NombreArchivo
        Dim qk = HttpContext.Current.Server.MapPath(".")
        LblNombreArchivoBuscaEntidadesascxDestino.Text = qk & "\" & "Busca" & txtNombreTabla.Text & ".ascx"

    End Sub
    Protected Sub Button7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim AccesoFiles = New AccesoFiles
        Dim t As Boolean = True
        Dim NombreArchivo As String = ""
        Dim FormularioWeb = New FormularioWeb

        t = AccesoFiles.GrabarArchivoBuscaEntidadesascxvb(NombreArchivo, "Busca" & txtNombreTabla.Text, FormularioWeb.LeerFormularioWebNumber("Busca " & txtNombreTabla.Text), "Busca" & txtNombreTabla.Text, txtNombreTabla.Text & "Id", txtNombreTabla.Text, "Ficha de " & txtNombreTabla.Text)
        lblNombreArchivoBuscaEntidadesascxvb.Text = NombreArchivo
        HyperLink7.Text = "Ver " & "Busca" & txtNombreTabla.Text & ".ascx.vb"
        HyperLink7.NavigateUrl = NombreArchivo
        Dim qk = HttpContext.Current.Server.MapPath(".")
        lblNombreArchivoBuscaEntidadesascxvbDestino.Text = qk & "\" & "Busca" & txtNombreTabla.Text & ".ascx.vb"

    End Sub
    Protected Sub Button8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim AccesoFiles = New AccesoFiles
        Dim t As Boolean = True
        Dim NombreArchivo As String = ""

        t = AccesoFiles.GrabarArchivoValidaEntidadesascx(NombreArchivo, "Valida" & txtNombreTabla.Text)
        LblNombreArchivoValidaEntidadesascx.Text = NombreArchivo
        HyperLink8.Text = "Ver " & "Valida" & txtNombreTabla.Text & ".ascx"
        HyperLink8.NavigateUrl = NombreArchivo
        Dim qk = HttpContext.Current.Server.MapPath(".")
        LblNombreArchivoValidaEntidadesascxDestino.Text = qk & "\" & "Valida" & txtNombreTabla.Text & ".ascx"
    End Sub
    Protected Sub Button9_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim AccesoFiles = New AccesoFiles
        Dim t As Boolean = True
        Dim NombreArchivo As String = ""
        Dim FormularioWeb = New FormularioWeb

        t = AccesoFiles.GrabarArchivoValidaEntidadesascxvb(NombreArchivo, "Valida" & txtNombreTabla.Text, FormularioWeb.LeerFormularioWebNumber("Valida " & txtNombreTabla.Text), txtNombreTabla.Text & "Id", txtNombreTabla.Text & "Name", txtNombreTabla.Text)
        lblNombreArchivoValidaEntidadesascxvb.Text = NombreArchivo
        HyperLink9.Text = "Ver " & "Valida" & txtNombreTabla.Text & ".ascx.vb"
        HyperLink9.NavigateUrl = NombreArchivo
        Dim qk = HttpContext.Current.Server.MapPath(".")
        lblNombreArchivoValidaEntidadesascxvbDestino.Text = qk & "\" & "Valida" & txtNombreTabla.Text & ".ascx.vb"
    End Sub
    Protected Sub Button11_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button11.Click
        FileUpload2.PostedFile.SaveAs(lblNombreArchivoascxDestino.Text)
        Label1.Text = "Done"
    End Sub
    Protected Sub Button12_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button12.Click
        FileUpload3.PostedFile.SaveAs(lblNombreArchivoascxvbDestino.Text)
        Label2.Text = "Done"
    End Sub
    Protected Sub Button13_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button13.Click
        FileUpload4.PostedFile.SaveAs(LblNombreArchivoBuscaEntidadesascxDestino.Text)
        Label5.Text = "Done"
    End Sub
    Protected Sub Button14_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button14.Click
        FileUpload5.PostedFile.SaveAs(lblNombreArchivoBuscaEntidadesascxvbDestino.Text)
        Label6.Text = "Done"
    End Sub
    Protected Sub Button15_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button15.Click
        FileUpload6.PostedFile.SaveAs(LblNombreArchivoValidaEntidadesascxDestino.Text)
        Label7.Text = "Done"
    End Sub
    Protected Sub Button16_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button16.Click
        FileUpload7.PostedFile.SaveAs(lblNombreArchivoValidaEntidadesascxvbDestino.Text)
        Label8.Text = "Done"
    End Sub
    Protected Sub Button17_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button17.Click
        Dim AccesoFiles = New AccesoFiles
        Dim t As Boolean = True
        Dim NombreArchivo As String = ""
        Dim Entidad As New Entidad

        t = AccesoFiles.GrabarArchivoEntidadvbV2(NombreArchivo, txtClassName.Text, txtNombreTabla.Text, txtTableType.Text)
        lblNombreArchivovbV2.Text = NombreArchivo
        HyperLink1.Text = "Ver " & txtNombreTabla.Text & ".vb"
        HyperLink1.NavigateUrl = NombreArchivo
        Dim qk = HttpContext.Current.Server.MapPath(".")
        lblNombreArchivovbDestinoV2.Text = qk & "\App_Code\" & txtNombreTabla.Text & ".vb"

    End Sub
    Protected Sub Button18_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button18.Click
        FileUpload8.PostedFile.SaveAs(lblNombreArchivovbDestinoV2.Text)
    End Sub

    Protected Sub Button19_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button19.Click
        Dim AccesoFiles = New AccesoFiles
        Dim t As Boolean = True

        t = AccesoFiles.CrearEntidadNegocio(txtTablaName.Text, txtEntidadName.Text, txtTipo.Text, txtClaseName.Text, txtParentTableName.Text, Session("PersonaId"))
    End Sub

    Protected Sub Button20_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button20.Click
        Dim AccesoFiles = New AccesoFiles
        Dim t As Boolean = True

        t = AccesoFiles.CrearPaginaWebTipoLista(txtEntidadNameLista.Text, txtMasterPage.Text, txtMenuOptions.Text, Session("PersonaId"))
    End Sub

    Protected Sub Button21_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button21.Click
        Dim AccesoFiles = New AccesoFiles
        Dim t As Boolean = True

        t = AccesoFiles.CrearPaginaWebTipoFicha(txtEntidadNameLista.Text, txtMasterPage.Text, txtMenuOptions.Text, Session("PersonaId"))
    End Sub

    Protected Sub Button22_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button22.Click
        Dim AccesoFiles = New AccesoFiles
        Dim t As Boolean = True

        t = AccesoFiles.CrearPaginaWebTipoValidar(txtEntidadNameLista.Text, txtMasterPage.Text, Session("PersonaId"))
    End Sub

    Protected Sub Button23_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button23.Click
        Dim AccesoFiles = New AccesoFiles
        Dim t As Boolean = True

        t = AccesoFiles.CrearPaginaWebTipoBuscar(txtEntidadNameLista.Text, txtMasterPage.Text, Session("PersonaId"))
    End Sub
    Protected Sub Button24_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button24.Click
        FileUpload10.PostedFile.SaveAs(LblNombreArchivoNewDetailsascxDestino.Text)
        Label3.Text = "Done"
    End Sub

    Protected Sub Button29_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button29.Click
        FileUpload11.PostedFile.SaveAs(lblNombreArchivoNewDetailsascxvbDestino.Text)
        Label4.Text = "Done"
    End Sub
End Class
