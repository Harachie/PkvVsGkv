Public Class KvData

    '  Public Const BbgMultiplier As Double = 1.028
    '  Public Const PkvMultiplier As Double = 1.035


    Public Property Age As Integer
    Public Property Bbg As Double = 4350
    Public Property GkvPflegeM As Double = 0.0255

    Public Property PkvKosten As Double
    Public Property PkvZusatz As Double
    Public Property Ppf As Double
    Public Property PkvKrankentagegeld As Double

    Public Property GkvZusatzM As Double = 0.01

    Public ReadOnly Property Gpf As Double
        Get
            Return Me.Bbg * (Me.GkvPflegeM + 0.0025)
        End Get
    End Property

    Public ReadOnly Property Gkv As Double
        Get
            Return Me.Bbg * (0.146 + Me.GkvZusatzM)
        End Get
    End Property

    Public ReadOnly Property GkvUndGpf As Double
        Get
            Return Me.Gpf + Me.Gkv
        End Get
    End Property

    Public ReadOnly Property GkvUndGpfEmployee As Double
        Get
            Return Me.GkvEmployee + Me.GpfEmployee
        End Get
    End Property

    Public ReadOnly Property PkvUndPpf As Double
        Get
            Return Me.PkvKosten + Me.PkvZusatz + Me.Ppf + Me.PkvKrankentagegeld
        End Get
    End Property

    Public ReadOnly Property GkvEmployer As Double
        Get
            Return Me.Bbg * 0.073
        End Get
    End Property

    Public ReadOnly Property GkvEmployee As Double
        Get
            Return Me.Bbg * (0.073 + Me.GkvZusatzM)
        End Get
    End Property

    Public ReadOnly Property GpfEmployer As Double
        Get
            Return Math.Round(Me.Bbg * (Me.GkvPflegeM / 2.0), 2)
        End Get
    End Property

    Public ReadOnly Property GpfEmployee As Double
        Get
            Return Math.Round(Me.Bbg * ((Me.GkvPflegeM / 2.0) + 0.0025), 2)
        End Get
    End Property

    Public ReadOnly Property Pkv As Double
        Get
            Return Me.PkvKosten + Me.PkvZusatz + Me.PkvKrankentagegeld
        End Get
    End Property

    Public ReadOnly Property PkvEmployer As Double
        Get
            Dim half As Double

            half = Me.Pkv / 2.0

            Return Math.Min(half, Me.GkvEmployer)
        End Get
    End Property

    Public ReadOnly Property PkvEmployee As Double
        Get
            Return Me.Pkv - Me.PkvEmployer
        End Get
    End Property

    Public ReadOnly Property PpfEmployer As Double
        Get
            Dim half As Double

            half = Me.Ppf / 2.0

            Return Math.Min(half, Me.GpfEmployer)
        End Get
    End Property

    Public ReadOnly Property PpfEmployee As Double
        Get
            Return Me.Ppf - Me.PpfEmployer
        End Get
    End Property

    Public ReadOnly Property PkvUndPpfEmployee As Double
        Get
            Return Me.PkvEmployee + Me.PpfEmployee
        End Get
    End Property

    Public ReadOnly Property PkvSavings As Double 'des ist richtig... nochmal nachgeprüft
        Get
            Return Math.Max(0.0, Me.GkvUndGpfEmployee - Me.PkvUndPpfEmployee)
        End Get
    End Property

    Public ReadOnly Property PkvTest As Double
        Get
            Dim money As Double = 10000

            money -= Me.Pkv
            money -= Me.Ppf
            money += Me.PkvEmployer
            money += Me.PpfEmployer

            Return money
        End Get
    End Property

    Public ReadOnly Property GkvTest As Double
        Get
            Dim money As Double = 10000

            money -= Me.Gkv
            money -= Me.Gpf
            money += Me.GkvEmployer
            money += Me.GpfEmployer

            Return money
        End Get
    End Property

    Public ReadOnly Property Savings As Double
        Get
            Return Math.Max(0.0, Me.PkvTest - Me.GkvTest)
        End Get
    End Property


    Public Sub New(age As Integer, pkvKosten As Double, pkvZusatz As Double, pkvPflege As Double, pkvKrankentagegeld As Double)
        Me.Age = age
        Me.PkvKosten = pkvKosten
        Me.PkvZusatz = pkvZusatz
        Me.Ppf = pkvPflege
        Me.PkvKrankentagegeld = pkvKrankentagegeld
    End Sub

    Private Sub New()
    End Sub

    Public Function NextYear(tRange As Integer, t As Integer,
                              bbgM As Double, pkvM As Double,
                              startPflegeM As Double, endPflegeM As Double,
                              startZusatzM As Double, endZusatzM As Double) As KvData
        Dim r As New KvData

        r.Age = Me.Age + 1
        r.Bbg = Me.Bbg * bbgM
        r.PkvKosten = Me.PkvKosten * pkvM
        r.PkvKrankentagegeld = Me.PkvKrankentagegeld * pkvM
        r.Ppf = Me.Ppf * pkvM
        r.PkvZusatz = Me.PkvZusatz * pkvM
        r.GkvPflegeM = Factor(startPflegeM, endPflegeM, tRange, t)
        r.GkvZusatzM = Factor(startZusatzM, endZusatzM, tRange, t)

        If r.Age > 60 Then
            r.PkvZusatz = 0 'ab 60 gibts keine zusatzkosten mehr
        End If

        If r.Age > 65 Then
            r.PkvKrankentagegeld = 0 'ab 65 gibts kein krankentagegeld mehr
        End If

        Return r
    End Function

End Class
