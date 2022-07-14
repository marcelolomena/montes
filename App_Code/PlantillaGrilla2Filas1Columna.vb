Imports Microsoft.VisualBasic

Public Class PlantillaGrilla2Filas1Columna
    Implements ITemplate

    Private templateType As DataControlRowType
    Private columnName() As String
    Private codigoPGG As String
    Private TipoValor As String
    Private numeroMes As Integer
    Sub New(ByVal type As DataControlRowType, ByVal colname() As String, ByVal PGGCodigo As String, _
            ByVal ValorTipo As String, ByVal Mes As Integer)

        templateType = type
        columnName = colname
        codigoPGG = PGGCodigo
        TipoValor = ValorTipo
        numeroMes = Mes

    End Sub
    Sub InstantiateIn(ByVal container As System.Web.UI.Control) _
      Implements ITemplate.InstantiateIn

        Dim i As Integer = 0


        For i = 0 To columnName.Length - 1
            Dim firstName As New Label

            firstName.Text = columnName(i)
            AddHandler firstName.DataBinding, AddressOf FirstName_DataBinding

            container.Controls.Add(firstName)

        Next i

    End Sub
    Private Sub FirstName_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
        Dim Valor As String
        Dim Variable As String
        Dim l As Label = CType(sender, Label)
        Variable = l.Text
        Dim TareasProgramadas As Long = 0
        Dim TareasRealizadas As Long = 0
        Dim PorcentajeCumplimiento As Double = 0
        Dim TareasProgramadasAlMesAnteriorAlMesEnCurso As Long = 0
        Dim TareasRealizadasAlMesAnteriorAlMesEnCurso As Long = 0
        Dim PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso As Double = 0
        Dim HHProgramadas As Double = 0
        Dim HHConsumidas As Double = 0
        Dim USDProgramados As Double = 0
        Dim USDConsumidos As Double = 0
        Dim Meta As Double = 0
        Dim TextoIndicador As String = ""
        Dim Tareas As New Tareas
        Dim t As Boolean
        Dim IsManual As Boolean
        Dim ValorMeta As Double
        Dim NumeroMesEnCurso As Integer = System.DateTime.Today.Month
        Dim YearEnCurso As Integer = System.DateTime.Today.Year

        Dim row As GridViewRow = CType(l.NamingContainer, GridViewRow)
        Valor = DataBinder.Eval(row.DataItem, Variable).ToString()

        Select Case TipoValor
            Case "Estado"
                l.Text = "<table>"
                If Valor = "Cerrada" Then
                    ' La tarea esta terminada y debe llevar fondo verde
                    l.Text = l.Text & "<tr><td style=""background-color: #00FF00; width: 150px"">" & Valor & "</td></tr>"
                Else
                    If numeroMes < NumeroMesEnCurso Then
                        l.Text = l.Text & "<tr><td style=""background-color: #FF0000; color: #FFFFFF; width: 150px"">" & Valor & "</td></tr>"
                    End If
                    If numeroMes = NumeroMesEnCurso Then
                        l.Text = l.Text & "<tr><td style=""background-color: #FFFF00; width: 150px"">" & Valor & "</td></tr>"
                    End If
                    If numeroMes > NumeroMesEnCurso Then
                        l.Text = l.Text & "<tr><td>" & Valor & "</td></tr>"
                    End If
                End If
                l.Text = l.Text & "</table>"

            Case "Meta"
                    t = Tareas.LeerMetaByAccion(Valor, IsManual, ValorMeta, TextoIndicador)
                    If IsManual = True Then
                        l.Text = FormatNumber(ValorMeta / 100, 2)
                    Else
                        If ValorMeta = 0 Then
                            l.Text = ""
                        Else
                            l.Text = FormatNumber(ValorMeta / 100, 2)
                        End If
                    End If
            Case "Indicador"    ' calcula el valor del indicador indicado por la acción

                    ' ----------------------------------------------------------------------------------
                    ' Aqui hay que poner código para los indicadores de gestión
                    ' Por ahora partiremos con aquellos indicadores que corresponden a % de cumplimiento
                    ' ----------------------------------------------------------------------------------
                    ' ----------------------------------------------------------------------------------
                    ' Supuesto importante:  Si el indicador no se ingresa al sistema, se asume que es un
                    ' indicador de % de cumplimiento y eso es lo que vamos a implementar por ahora.
                    ' ----------------------------------------------------------------------------------
                    ' Con el código de la acción, se lee la acción y se ve si el indicador es de cálculo automatico
                    ' ----------------------------------------------------------------------------------
                    t = Tareas.LeerMetaByAccion(Valor, IsManual, ValorMeta, TextoIndicador)
                    If IsManual = False Then
                        If ValorMeta = 0 Then
                            l.Text = ""
                        Else
                            TareasProgramadas = Tareas.LeerTotalTareasProgramadas(Valor, codigoPGG)
                            TareasRealizadas = Tareas.LeerTotalTareasRealizadas(Valor, codigoPGG)
                            If TareasProgramadas > 0 Then
                                PorcentajeCumplimiento = TareasRealizadas / TareasProgramadas
                            Else
                                PorcentajeCumplimiento = 0
                            End If
                            If NumeroMesEnCurso > 1 Then
                                TareasProgramadasAlMesAnteriorAlMesEnCurso = Tareas.LeerTareasProgramadasAlMes(Valor, NumeroMesEnCurso - 1, codigoPGG)
                                TareasRealizadasAlMesAnteriorAlMesEnCurso = Tareas.LeerTareasRealizadasAlMes(Valor, NumeroMesEnCurso - 1, codigoPGG)
                                If TareasProgramadasAlMesAnteriorAlMesEnCurso > 0 Then
                                    PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso = TareasRealizadasAlMesAnteriorAlMesEnCurso / TareasProgramadasAlMesAnteriorAlMesEnCurso
                                Else
                                    PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso = 0
                                End If
                            End If
                            l.Text = "<table>"
                            If TareasProgramadas > 0 Then
                                If PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso >= (0.9) Then l.Text = l.Text & "<tr><td style=""background-color: #00FF00; width: 170px; heigth: 60px"">" & TextoIndicador & "</td></tr>"
                                If (PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso >= (0.8) And PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso < (0.9)) Then l.Text = l.Text & "<tr><td style=""background-color: #FFFF00; width: 170px; heigth: 60px"">" & TextoIndicador & "</td></tr>"
                                If (PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso < (0.8)) Then l.Text = l.Text & "<tr><td style=""background-color: #FF0000; color: #FFFFFF; width: 170px; heigth: 60px"">" & TextoIndicador & "</td></tr>"
                            Else
                                l.Text = l.Text & "<tr><td></td></tr>"
                            End If
                            l.Text = l.Text & "</table>"
                        End If

                    Else
                        l.Text = TextoIndicador
                    End If
            Case "PR"
                    l.Text = "<table>"
                    l.Text = l.Text & "<tr><td>P</td></tr>"
                    l.Text = l.Text & "<tr><td>R</td></tr>"
                    l.Text = l.Text & "</table>"
            Case "Nomenclatura"
                    l.Text = "<center><table>"
                    l.Text = l.Text & "<tr><td style=""text-align: center; width: 100px"">Rangos</td><td style=""text-align: center; width: 100px"">Colores</td></tr>"
                    l.Text = l.Text & "<tr><td style=""text-align: center; width: 100px"">100% - 90%</td><td style=""background-color: #00FF00; width: 100px""></td></tr>"
                    l.Text = l.Text & "<tr><td style=""text-align: center; width: 100px"">90% - 80%</td><td style=""background-color: #FFFF00; width: 100px""></td></tr>"
                    l.Text = l.Text & "<tr><td style=""text-align: center; width: 100px""><80%</td><td style=""background-color: #FF0000; width: 100px""></td></tr>"
                    l.Text = l.Text & "</table></center>"
            Case "PRMA"
                    l.Text = "<table>"
                    l.Text = l.Text & "<tr><td>Programado</td></tr>"
                    l.Text = l.Text & "<tr><td>Realizado</td></tr>"
                    l.Text = l.Text & "<tr><td>Mensual</td></tr>"
                    l.Text = l.Text & "<tr><td>Acumulado Anual</td></tr>"
                    l.Text = l.Text & "</table>"
            Case "HH"           ' calcula el valor de las HH presupuestas y las reales
                    HHProgramadas = Tareas.LeerHHProgramadas(Valor, codigoPGG)
                    HHConsumidas = Tareas.LeerHHConsumidas(Valor, codigoPGG)
                    l.Text = "<table>"
                    l.Text = l.Text & "<tr><td>" & FormatNumber(HHProgramadas / 100, 2) & "</td></tr>"
                    l.Text = l.Text & "<tr><td>" & FormatNumber(HHConsumidas / 100, 2) & "</td></tr>"
                    l.Text = l.Text & "</table>"
            Case "USD"          ' calcula el valor de los USD presupuestados vs los reales
                    USDProgramados = Tareas.LeerUSDProgramados(Valor, codigoPGG)
                    USDConsumidos = Tareas.LeerUSDConsumidos(Valor, codigoPGG)
                    l.Text = "<table>"
                    l.Text = l.Text & "<tr><td>" & FormatCurrency(USDProgramados / 100, 2) & "</td></tr>"
                    l.Text = l.Text & "<tr><td>" & FormatCurrency(USDConsumidos / 100, 2) & "</td></tr>"
                    l.Text = l.Text & "</table>"
            Case "HHFooter"           ' calcula el valor de las HH presupuestas y las reales
                    HHProgramadas = Tareas.LeerHHProgramadas("Todas", codigoPGG)
                    HHConsumidas = Tareas.LeerHHConsumidas("Todas", codigoPGG)
                    l.Text = "<table>"
                    l.Text = l.Text & "<tr><td>" & FormatNumber(HHProgramadas / 100, 2) & "</td></tr>"
                    l.Text = l.Text & "<tr><td>" & FormatNumber(HHConsumidas / 100, 2) & "</td></tr>"
                    l.Text = l.Text & "<tr><td> - </td></tr>"
                    l.Text = l.Text & "<tr><td> - </td></tr>"
                    l.Text = l.Text & "</table>"
            Case "USDFooter"          ' calcula el valor de los USD presupuestados vs los reales
                    USDProgramados = Tareas.LeerUSDProgramados("Todas", codigoPGG)
                    USDConsumidos = Tareas.LeerUSDConsumidos("Todas", codigoPGG)
                    l.Text = "<table>"
                    l.Text = l.Text & "<tr><td>" & FormatCurrency(USDProgramados / 100, 2) & "</td></tr>"
                    l.Text = l.Text & "<tr><td>" & FormatCurrency(USDConsumidos / 100, 2) & "</td></tr>"
                    l.Text = l.Text & "<tr><td> - </td></tr>"
                    l.Text = l.Text & "<tr><td> - </td></tr>"
                    l.Text = l.Text & "</table>"
            Case "Mes"          ' calcula el número de tareas asignadas vs las realizadas
                    TareasProgramadas = Tareas.LeerTareasProgramadas(Valor, numeroMes, codigoPGG)
                    TareasRealizadas = Tareas.LeerTareasRealizadas(Valor, numeroMes, codigoPGG)
                    If TareasProgramadas > 0 Then
                        PorcentajeCumplimiento = TareasRealizadas / TareasProgramadas
                    Else
                        PorcentajeCumplimiento = 0
                    End If
                    l.Text = "<table>"
                    If TareasProgramadas > 0 Then
                        l.Text = l.Text & "<tr><td><a href=""ReportesPGG.aspx?PaginaWebName=Reporte Cumplimiento Por Accion&PGGCodigo=" & codigoPGG & "&Accion=" & Valor & "&Mes=" & numeroMes & """ target=""_blank"">" & TareasProgramadas & "</a>"
                        'l.Text = l.Text & "<tr><td>" & TareasProgramadas & "</td></tr>"
                        ' Los colores solo se aplican a los meses inferiores al que esta en curso al momento de la consulta
                        If numeroMes < NumeroMesEnCurso Then
                            If PorcentajeCumplimiento >= (0.9) Then l.Text = l.Text & "<tr><td style=""background-color: #00FF00; width: 30px"">" & TareasRealizadas & "</td></tr>"
                            If (PorcentajeCumplimiento >= (0.8) And PorcentajeCumplimiento < (0.9)) Then l.Text = l.Text & "<tr><td style=""background-color: #FFFF00; width: 30px"">" & TareasRealizadas & "</td></tr>"
                            If (PorcentajeCumplimiento < (0.8)) Then l.Text = l.Text & "<tr><td style=""background-color: #FF0000; color: #FFFFFF; width: 40px"">" & TareasRealizadas & "</td></tr>"
                        Else
                            l.Text = l.Text & "<tr><td>" & TareasRealizadas & "</td></tr>"
                        End If
                    Else
                        l.Text = l.Text & "<tr><td></td></tr>"
                        l.Text = l.Text & "<tr><td></td></tr>"
                    End If
                    l.Text = l.Text & "</table>"
            Case "MesFooter"          ' calcula el número de tareas asignadas vs las realizadas
                    TareasProgramadas = Tareas.LeerTareasProgramadas("Todas", numeroMes, codigoPGG)
                    TareasRealizadas = Tareas.LeerTareasRealizadas("Todas", numeroMes, codigoPGG)

                    l.Text = "<table border=""1"">"

                    If TareasProgramadas > 0 Then
                        PorcentajeCumplimiento = TareasRealizadas / TareasProgramadas
                    Else
                        PorcentajeCumplimiento = 0
                    End If
                    If TareasProgramadas > 0 Then
                        l.Text = l.Text & "<tr><td>" & TareasProgramadas & "</td></tr>"
                        l.Text = l.Text & "<tr><td>" & TareasRealizadas & "</td></tr>"
                        If numeroMes < NumeroMesEnCurso Then
                            If PorcentajeCumplimiento >= (0.9) Then l.Text = l.Text & "<tr><td style=""background-color: #00FF00; width: 60px; heigth: 40px"">" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                            If (PorcentajeCumplimiento >= (0.8) And PorcentajeCumplimiento < (0.9)) Then l.Text = l.Text & "<tr><td style=""background-color: #FFFF00; width: 60px; heigth: 40px"">" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                            If (PorcentajeCumplimiento < (0.8)) Then l.Text = l.Text & "<tr><td style=""background-color: #FF0000; color: #FFFFFF; width: 60px; heigth: 40px"">" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                        Else
                            l.Text = l.Text & "<tr><td>" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                        End If
                    Else
                        l.Text = l.Text & "<tr><td> - </td></tr>"
                        l.Text = l.Text & "<tr><td> - </td></tr>"
                        l.Text = l.Text & "<tr><td> - </td></tr>"
                    End If
                    ' Ahora Calculamos el acumulado al Mes
                    TareasProgramadas = Tareas.LeerTareasProgramadasAlMes("Todas", numeroMes, codigoPGG)
                    TareasRealizadas = Tareas.LeerTareasRealizadasAlMes("Todas", numeroMes, codigoPGG)
                    If TareasProgramadas > 0 Then
                        PorcentajeCumplimiento = TareasRealizadas / TareasProgramadas
                    Else
                        PorcentajeCumplimiento = 0
                    End If
                    If TareasProgramadas > 0 Then
                        If numeroMes < NumeroMesEnCurso Then
                            If PorcentajeCumplimiento >= (0.9) Then l.Text = l.Text & "<tr><td style=""background-color: #00FF00; width: 60px"">" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                            If (PorcentajeCumplimiento >= (0.8) And PorcentajeCumplimiento < (0.9)) Then l.Text = l.Text & "<tr><td style=""background-color: #FFFF00; width: 60px"">" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                            If (PorcentajeCumplimiento < (0.8)) Then l.Text = l.Text & "<tr><td style=""background-color: #FF0000; color: #FFFFFF; width: 60px"">" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                        Else
                            l.Text = l.Text & "<tr><td>" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                        End If
                    Else
                        If (PorcentajeCumplimiento = 0) Then l.Text = l.Text & "<tr><td> - </td></tr>"
                    End If
                    l.Text = l.Text & "</table>"
            Case "Prc"          ' calcula la última columna con el porcentaje total de cumplimiento
                    TareasProgramadas = Tareas.LeerTotalTareasProgramadas(Valor, codigoPGG)
                    TareasRealizadas = Tareas.LeerTotalTareasRealizadas(Valor, codigoPGG)
                    'PorcentajeCumplimiento = TareasRealizadas / TareasProgramadas
                    If TareasProgramadas > 0 Then
                        PorcentajeCumplimiento = TareasRealizadas / TareasProgramadas
                    Else
                        PorcentajeCumplimiento = 0
                    End If
                    If NumeroMesEnCurso > 1 Then
                        TareasProgramadasAlMesAnteriorAlMesEnCurso = Tareas.LeerTareasProgramadasAlMes(Valor, NumeroMesEnCurso - 1, codigoPGG)
                        TareasRealizadasAlMesAnteriorAlMesEnCurso = Tareas.LeerTareasRealizadasAlMes(Valor, NumeroMesEnCurso - 1, codigoPGG)
                        If TareasProgramadasAlMesAnteriorAlMesEnCurso > 0 Then
                            PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso = TareasRealizadasAlMesAnteriorAlMesEnCurso / TareasProgramadasAlMesAnteriorAlMesEnCurso
                        Else
                            PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso = 0
                        End If
                    End If

                    l.Text = "<table>"
                    If TareasProgramadasAlMesAnteriorAlMesEnCurso > 0 Then
                        If PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso >= (0.9) Then l.Text = l.Text & "<tr><td style=""background-color: #00FF00; width: 60px; heigth: 60px"">" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                        If (PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso >= (0.8) And PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso < (0.9)) Then l.Text = l.Text & "<tr><td style=""background-color: #FFFF00; width: 60px; heigth: 60px"">" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                        If (PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso < (0.8)) Then l.Text = l.Text & "<tr><td style=""background-color: #FF0000; color: #FFFFFF; width: 60px; heigth: 60px"">" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                    Else
                        l.Text = l.Text & "<tr><td>" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                    End If
                    l.Text = l.Text & "</table>"
            Case "PrcFooter"          ' calcula la última columna con el porcentaje total de cumplimiento
                    TareasProgramadas = Tareas.LeerTotalTareasProgramadas("Todas", codigoPGG)
                    TareasRealizadas = Tareas.LeerTotalTareasRealizadas("Todas", codigoPGG)
                    If TareasProgramadas > 0 Then
                        PorcentajeCumplimiento = TareasRealizadas / TareasProgramadas
                    Else
                        PorcentajeCumplimiento = 0
                    End If
                    If NumeroMesEnCurso > 1 Then
                        TareasProgramadasAlMesAnteriorAlMesEnCurso = Tareas.LeerTareasProgramadasAlMes("Todas", NumeroMesEnCurso - 1, codigoPGG)
                        TareasRealizadasAlMesAnteriorAlMesEnCurso = Tareas.LeerTareasRealizadasAlMes("Todas", NumeroMesEnCurso - 1, codigoPGG)
                        If TareasProgramadasAlMesAnteriorAlMesEnCurso > 0 Then
                            PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso = TareasRealizadasAlMesAnteriorAlMesEnCurso / TareasProgramadasAlMesAnteriorAlMesEnCurso
                        Else
                            PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso = 0
                        End If
                    End If

                    l.Text = "<table border=""0"">"
                    l.Text = l.Text & "<tr><td> - </td></tr>"
                    l.Text = l.Text & "<tr><td> - </td></tr>"
                    l.Text = l.Text & "<tr><td> - </td></tr>"
                    If TareasProgramadasAlMesAnteriorAlMesEnCurso > 0 Then
                        If PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso >= (0.9) Then l.Text = l.Text & "<tr><td style=""background-color: #00FF00; width: 60px; heigth: 60px"">" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                        If (PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso >= (0.8) And PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso < (0.9)) Then l.Text = l.Text & "<tr><td style=""background-color: #FFFF00; width: 60px; heigth: 60px"">" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                        If (PorcentajeCumplimientoAlMesAnteriorAlMesEnCurso < (0.8)) Then l.Text = l.Text & "<tr><td style=""background-color: #FF0000; color: #FFFFFF; width: 60px; heigth: 60px"">" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                    Else
                        l.Text = l.Text & "<tr><td>" & FormatPercent(PorcentajeCumplimiento, 2) & "</td></tr>"
                    End If
                    l.Text = l.Text & "</table>"
        End Select

    End Sub
End Class
