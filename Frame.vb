Public Class Frame

    Public PinsRolled(1) As Integer
    Public Score As Integer

    Public Function IsStrike() As Boolean
        Return PinsRolled(0) = 10
    End Function
    Public Function IsSpare() As Boolean
        Return PinsRolled(0) + PinsRolled(1) = 10
    End Function

End Class
Public Class LastFrame
    Inherits Frame
    Sub ManageArrLeng()
        ReDim PinsRolled(2)
    End Sub

End Class


