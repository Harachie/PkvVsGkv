Module Program

    Sub Main()
        Dim startValue As Double = 0.028
        Dim endValue As Double = 0.05
        Dim range As Integer = 30

        For i As Integer = 0 To range
            Console.WriteLine(Factor(startValue, endValue, range, i))
        Next

        Console.ReadLine()
    End Sub

End Module
