Module Program

    Sub Main()
        Dim startValue As Double = 1.0028
        Dim endValue As Double = 1.005
        Dim range As Integer = 30


        Dim startPflege As Double = 0.028
        Dim endPflege As Double = 0.055

        Dim data As New KvData(30, 532.41, 53.24, 25.67, 47)
        Dim ds As New List(Of KvData)
        Dim savings As Double

        ds.Add(data)
        savings += (data.PkvSavings * 12)
        savings *= 1.07

        For i As Integer = 1 To 30
            data = data.NextYear(30, i, 1.028, 1.035, 0.0255, 0.05, 0.01, 0.03)
            savings += (data.PkvSavings * 12)
            savings *= 1.07
            ds.Add(data)
        Next

        For i As Integer = 1 To 7
            data = data.NextYear(7, i, 1.028, 1.035, 0.05, 0.055, 0.03, 0.035) 'ahso... man muss ja nu bis 67 arbeiten
            savings += (data.PkvSavings * 12)
            savings *= 1.07
            ds.Add(data)
        Next

        For i As Integer = 1 To 18
            data = data.NextYear(20, i, 1.028, 1.02, 0.055, 0.07, 0.035, 0.04) 'nurnoch 2% pkv anstieg im alter...  gkv ersparnisse hat man eh nicht mehr... weil rente ^^
            ds.Add(data)
        Next

        Console.ReadLine()
    End Sub

End Module
