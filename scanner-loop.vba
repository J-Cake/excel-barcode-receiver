Sub ReadScanner()
    Dim finding_value, weight As Range
    Dim code As Variant
    
    Do While True
        
        code = InputBox("Bitte eine Chem ID scannen oder eingeben", "Auf Chem ID warten")
        
        Do While Len(code) > 5
            Dim rescan As Variant
            
        
            rescan = MsgBox("Ein ungültiger Barcode ist gescannt worden. Nochmal scannen?", vbOKCancel)
             
            If rescan = vbCancel Then
                Exit Sub
            End If
            
            code = InputBox("Bitte eine Chem ID scannen oder eingeben", "Auf Chem ID warten")
        Loop
        
        If code = "" Then
            Exit Sub
        End If
        
        With Range("B:B")
            Set finding_value = .Find(code)
            
            If finding_value Is Nothing Then
                Exit Sub
            Else
                
                Set weight = finding_value.Offset(0, 17)
                
                weight.Select
                
                Do
                    DoEvents
                Loop While Selection.Address = weight.Address
                
                Set weight = finding_value.Offset(0, 16)
                weight.Select
                
                Do
                    DoEvents
                Loop While Selection.Address = weight.Address
                
                finding_value.Offset(0, 15).Select
                
                SendKeys (Format(Now, "dd/mm/yyyy")) & "{Enter}"
                DoEvents
            End If
        End With
    Loop
End Sub

