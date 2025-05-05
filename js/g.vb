Sub ColorarePrimeleDouaCaractereRosu()
    Dim ws As Worksheet
    Dim rng As Range
    Dim cell As Range
    Dim lastRow As Long

    Set ws = ActiveSheet
    lastRow = ws.Cells(ws.Rows.Count, "G").End(xlUp).Row
    Set rng = ws.Range("G1:G" & lastRow)

    For Each cell In rng
        If Len(cell.Value) >= 2 Then
            If Left(cell.Value, 2) = "01" Then
                ' Resetează culoarea pentru întreaga celulă
                cell.Font.Color = RGB(0, 0, 0)
                ' Colorează doar primele 2 caractere în roșu
                cell.Characters(1, 2).Font.Color = RGB(255, 0, 0)
            End If
        End If
    Next cell
End Sub
