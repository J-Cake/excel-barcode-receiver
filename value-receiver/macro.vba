Sub sample(data As Variant)
    Dim Cell As Range
    Set Cell = Range("B:B").Find(What:=data, After:=ActiveCell, LookIn:=xlFormulas, _
        LookAt:=xlWhole, SearchOrder:=xlByRows, SearchDirection:=xlNext, _
        MatchCase:=False, SearchFormat:=False)

    If Cell Is Nothing Then
        MsgBox "Value: " & data & " was not found"
    Else
        Dim target As Range
        Set target = Cell.Offset(0, 17)
        
        ActiveSheet.Cells(target.Row, target.Column).Select
    End If
End Sub
