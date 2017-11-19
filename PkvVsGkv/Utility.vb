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

    Public Function CalculateIncomeTaxMonthly(monthlyGross As Double, companyCarValue As Double, companyCarDistance As Double) As Double
        Dim yearlyGross As Double
        Dim compoundMonthlyGross As Double
        Dim monthlyCompanyCar As Double

        monthlyCompanyCar = companyCarValue * 0.01
        compoundMonthlyGross = monthlyGross + monthlyCompanyCar + companyCarDistance * monthlyCompanyCar * 0.03
        yearlyGross = monthlyGross * 12.0

        If yearlyGross <= 7834.0 Then
            Return 0.0
        End If

        If yearlyGross <= 13139.0 Then

        End If

        If yearlyGross <= 52551.0 Then

        End If

        If yearlyGross <= 250400 Then
            Return (0.42 * Math.Floor(yearlyGross) - 8475.44) / 12.0
        End If

        Return 0.0
    End Function



End Module
