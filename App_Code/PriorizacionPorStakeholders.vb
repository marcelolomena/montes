Imports Microsoft.VisualBasic

Public Class PriorizacionPorStakeholders
    Public Function PriorizacionPorStakeholdersUpdate(ByVal RelationTable As String, _
                                     ByVal RelationTableId As Long, _
                                     ByVal Puntaje As Long, _
                                     ByVal ProgramasMapaId As Long, _
                                     ByRef UserId As Long) As String

        Dim AccesoEA As New AccesoEA
        Dim Lecturas As New Lecturas
        Dim AccionesABM As New AccionesABM
        Dim strUpdate As String
        Dim s As Integer
        Dim ProgramasMapa As New ProgramasMapa

        PriorizacionPorStakeholdersUpdate = 0

        strUpdate = "UPDATE PriorizacionPorStakeholders SET "
        strUpdate = strUpdate & "PriorizacionPorStakeholders.PriorizacionPorStakeholdersValor = " & Puntaje & ", "
        strUpdate = strUpdate & "PriorizacionPorStakeholders.DateLastUpdate = '" & AccionesABM.DateTransform(Now()) & "', "
        strUpdate = strUpdate & "PriorizacionPorStakeholders.UserLastUpdate = " & UserId & " "
        strUpdate = strUpdate & "WHERE PriorizacionPorStakeholders.PriorizacionPorStakeholdersId = " & RelationTableId

        Try
            s = AccesoEA.ABMRegistros(strUpdate)
            PriorizacionPorStakeholdersUpdate = CStr(ProgramasMapa.ProgramasMapaUpdateImportancia(ProgramasMapaId, UserId))
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Actualiza Priorización de Stakeholders ", RelationTableId, RelationTable, "")
        Catch
            PriorizacionPorStakeholdersUpdate = 0
            s = AccionesABM.BitacoraInsert(UserId, Replace(strUpdate, "'", " "), 0, 0, "Intento Fallido de Actualizar Priorización de Stakeholders ", RelationTableId, RelationTable, "")
        End Try
    End Function
End Class
