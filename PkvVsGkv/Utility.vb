Public Module Utility

    'decay
    Public Function Factor(startValue As Double, endValue As Double, range As Integer, t As Integer) As Double
        Dim r As Double
        Dim right As Double
        Dim initialFactor As Double

        right = endValue / startValue
        initialFactor = Math.Pow(right, 1 / range)
        r = startValue * Math.Pow(initialFactor, t)

        Return r
    End Function



End Module
