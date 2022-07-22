
Partial Class noticias
    Inherits System.Web.UI.UserControl
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim NotasTransversales As New NotasTransversales
        Dim PaginaWeb As New PaginaWeb
        Dim CodigoHTML As String = ""
        Dim CarpetaJudicialId As Long = 0
        Dim CarpetaJudicialCodigo As String = ""
        Dim TareasId As Long = 0
        Dim CarpetaJudicial As New CarpetaJudicial
        Dim t As Boolean
        Dim Tareas As New Tareas
        '--------------------------------------------------------------------
        'Reportes de Gestión General del Estudio Juridico
        'Decido quitarlos de aquí porque quedan abiertos a todo el mundo
        'Quedarán protegidos en base al rol en las opciones propias del menú.
        '27 de junio de 2022. Daniel Andrade Espinosa
        '--------------------------------------------------------------------
        'CodigoHTML = CodigoHTML & "<table width=""240"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""nueva_alerta"">"
        'CodigoHTML = CodigoHTML & "<tr><th scope=""col"">Informes de Gestión y Control</th></tr>"
        'CodigoHTML = CodigoHTML & "<tr><td><a href=""ReportesPGG.aspx?PaginaWebName=Reporte General&MenuOptionsId=425"">Informe General</a></td></tr>"
        'CodigoHTML = CodigoHTML & "<tr><td><a href=""ReportesPGG.aspx?PaginaWebName=Estado Diario&MenuOptionsId=425"">Informe de Estado Diario</a></td></tr>"
        'CodigoHTML = CodigoHTML & "<tr><td><a href=""ReportesPGG.aspx?PaginaWebName=Movimiento Diario&MenuOptionsId=425"">Informe de Movimiento Diario</a></td></tr>"
        'CodigoHTML = CodigoHTML & "</table>"
        '--------------------------------------------------------------------
        If PaginaWeb.MostrarListaNovedades(Request.QueryString("PaginaWebName")) Then 'Se adiciona la lista de novedades por Programa

            If Request.QueryString("PaginaWebName") = "Ficha de CarpetaJudicial" Then
                CarpetaJudicialId = Request.QueryString("Id")
                CarpetaJudicialCodigo = CarpetaJudicial.LeerCarpetaJudicialCodigoById(CarpetaJudicialId)
            Else
                CarpetaJudicialCodigo = Request.QueryString("MasterName")
                t = CarpetaJudicial.LeerCarpetaJudicialByName(CarpetaJudicialId, Request.QueryString("MasterName"))
            End If
            Session("CarpetaJudicialId") = CarpetaJudicialId
            'ctlControl = LoadControl("Novedades.ascx")
            'PlaceHolder1.Controls.Add(ctlControl)
            'Reportes de Control y Seguimiento de un juicio.
            '------------------------------------------------
            CodigoHTML = CodigoHTML & "<table width=""240"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""nueva_alerta"">"
            CodigoHTML = CodigoHTML & "<tr><th scope=""col"">" & CarpetaJudicialCodigo & " - Reportes</th></tr>"
            CodigoHTML = CodigoHTML & "<tr><td><a href=""ImprimirPerfilCarpetaEnWord.aspx?Id=" & CarpetaJudicialId & """ target=""_blank"" >Estado del Proceso</a></td></tr>"
            CodigoHTML = CodigoHTML & "<tr><td><a href=""ImprimirPlanEnWord.aspx?Id=" & CarpetaJudicialId & """ target=""_blank"" >Plan de Trabajo</a></td></tr>"
            CodigoHTML = CodigoHTML & "<tr><td><a href=""ReportesPGG.aspx?PaginaWebName=Carta Gantt&Id=" & Request.QueryString("Id") & "&MenuOptionsId=515"" >Carta Gantt</a></td></tr>"
            CodigoHTML = CodigoHTML & "</table>"
            'Plantilla personalizadas para un juicio.
            '-----------------------------------------------------------------
            '27 de junio de 2022, decido dejar sólo la plantilla de la Demanda
            'El resto de plantillas no fue nunca desarrollada
            'En la medida de que las desarrollemos las incluire.
            '-----------------------------------------------------------------
            CodigoHTML = CodigoHTML & "<table width=""240"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""nueva_alerta"">"
            CodigoHTML = CodigoHTML & "<tr><th scope=""col"">" & CarpetaJudicialCodigo & " - Plantillas</th></tr>"
            'CodigoHTML = CodigoHTML & "<tr><td scope=""col"" style=""background:#FFFFFF;"">&nbsp;</td></tr>"
            TareasId = CarpetaJudicial.LeerTareasIdByCarpetaJudicialCodigo(CarpetaJudicialCodigo)
            CodigoHTML = CodigoHTML & "<tr><td><a href=""DemandaJuicioEjecutivoEnWord.aspx?Id=" & TareasId & """ target=""_blank"" >Ver Demanda</a></td></tr>"
            '--------------
            'CodigoHTML = CodigoHTML & "<tr><td><a href=""DemandaJuicioEjecutivoEnWord.aspx?Id=" & TareasId & """ target=""_blank"" >Carta Al Banco</a></td></tr>"
            'CodigoHTML = CodigoHTML & "<tr><td><a href=""DemandaJuicioEjecutivoEnWord.aspx?Id=" & TareasId & """ target=""_blank"" >Cédula</a></td></tr>"
            'CodigoHTML = CodigoHTML & "<tr><td><a href=""DemandaJuicioEjecutivoEnWord.aspx?Id=" & TareasId & """ target=""_blank"" >Estampe</a></td></tr>"
            'CodigoHTML = CodigoHTML & "<tr><td><a href=""ReportesPGG.aspx?PaginaWebName=Plantilla Articulo44&Id=" & TareasId & """ target=""_blank"" >Solicitar 44</a></td></tr>"
            '--------------
            CodigoHTML = CodigoHTML & "</table>"
            'Ultimas actividades en relación a la tarea en curso
            '---------------------------------------------------
            CodigoHTML = CodigoHTML & "<table width=""240"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""nueva_alerta"">"
            CodigoHTML = CodigoHTML & "<tr><th scope=""col"">" & CarpetaJudicialCodigo & " - Actividades</th></tr>"
            'CodigoHTML = CodigoHTML & "<tr><td scope=""col"" style=""background:#FFFFFF;"">&nbsp;</td></tr>"
            'CodigoHTML = CodigoHTML & "<tr><td align=""right"" style=""background:#FFFFFF;"">&nbsp;</td></tr>"
            CodigoHTML = CodigoHTML & "</table>"
            CodigoHTML = CodigoHTML & "<div id=""ListaUltimasActividades"">" & Tareas.MostrarUltimasActividades(TareasId) & "</div>"
        End If


        CodigoHTML = CodigoHTML & "<table width=""240"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""nueva_alerta"">"
        CodigoHTML = CodigoHTML & "<tr><th scope=""col"">Notassssssss</th></tr>"
        CodigoHTML = CodigoHTML & "<tr><td scope=""col"" style=""background:#FFFFFF;"">&nbsp;</td></tr>"
        CodigoHTML = CodigoHTML & "<tr><td><textarea name=""txtNota"" id=""txtNota"" onfocus=""if(!this._haschanged){this.value=''};this._haschanged=true;"" >Ingrese una nueva nota</textarea></td></tr>"
        CodigoHTML = CodigoHTML & "<tr><td align=""right"" style=""background:#FFFFFF;"">&nbsp;</td></tr>"
        CodigoHTML = CodigoHTML & "<tr><td align=""right"" style=""background:#FFFFFF;""><span class=""submit""><input  id=""SubmitNota"" type=""button"" value=""Agregar"" onclick=""UpdateNota(" & Session("PersonaId") & ");"" /></span></td></tr></table><br />"
        CodigoHTML = CodigoHTML & "<br /><div id=""ListaNotas"">" & NotasTransversales.MostrarNotasTransversales(10, Session("PersonaId")) & "</div>"
        MyTable.Controls.Add(New LiteralControl(CodigoHTML))
    End Sub
End Class
