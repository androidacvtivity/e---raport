Sub FiltrareSiCopiereRanduriColoanaH()
    Dim wsSursa As Worksheet
    Dim wsDestinatie As Worksheet
    Dim cell As Range
    Dim rng As Range
    Dim lastRow As Long
    Dim destinatieRow As Long
    Dim colHIndex As Integer

    Set wsSursa = ActiveSheet
lastRow = wsSursa.Cells(wsSursa.Rows.Count, "H").End(xlUp).Row
    Set rng = wsSursa.Range("H1:H" & lastRow)
colHIndex = 8 ' Coloana H = coloana 8

' Șterge dacă există deja foaia "Filtrate"
    On Error Resume Next
Application.DisplayAlerts = False
Worksheets("Filtrate").Delete
Application.DisplayAlerts = True
    On Error GoTo 0

' Creează o nouă foaie
    Set wsDestinatie = Worksheets.Add
wsDestinatie.Name = "Filtrate"

destinatieRow = 1

    For Each cell In rng
        If Len(cell.Value) >= 2 Then
            If Left(cell.Value, 2) = "01" Then
' Colorează doar primele 2 caractere în roșu în foaia sursă
cell.Characters(1, 2).Font.Color = RGB(255, 0, 0)

' Copiază întregul rând în noul sheet
wsSursa.Rows(cell.Row).Copy Destination:= wsDestinatie.Rows(destinatieRow)

' Colorează și în sheet-ul nou
                With wsDestinatie.Cells(destinatieRow, colHIndex)
    .Characters(1, 2).Font.Color = RGB(255, 0, 0)
                End With

destinatieRow = destinatieRow + 1
            End If
        End If
    Next cell

    MsgBox "Rândurile au fost copiate în foaia 'Filtrate'."
End Sub
