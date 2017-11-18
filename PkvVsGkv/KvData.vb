Public Class KvData

    Public Const BbgMultiplier As Double = 1.025

    Public Property Bbg As Double = 4350
    Public Property PkvKosten As Double
    Public Property PkvZusatz As Double
    Public Property PkvPflege As Double
    Public Property PkvKrankentageGeld As Double

    Public Function NextYear() As KvData
        Dim r As New KvData

        r.Bbg = Me.Bbg * BbgMultiplier
    End Function


End Class
