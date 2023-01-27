
'Class Game

'    Private AllRolls As New List(Of Integer)

'    Public FrameList As New List(Of Frame)

'    Public Sub New()

'    End Sub

'    Sub AdRoll(ByVal pins As Integer)

'        If Over() Then
'            Throw New Exception("To many Rolls")
'        End If

'        If pins < 0 Or pins > 10 Then
'            Throw New Exception("Invalid amount of Pins")
'        End If

'        AllRolls.Add(pins)

'    End Sub

'    Function TotalScore() As Integer
'        Dim FinalSum = 0
'        For Each frame As Frame In FrameList
'            FinalSum += frame.Score
'        Next
'        If FinalSum > 300 Then
'            Throw New Exception("Programmierfehler! Kann nicht sein.")
'        End If
'        Return FinalSum
'    End Function

'    Sub BuildUpFrames()

'        ' Benennung
'        ' Framesliste neu initialisieren?

'        FrameList.Clear()

'        For i = 0 To AllRolls.Count - 3

'            Dim CurrentFrame As Frame = New Frame
'            'Default

'            If AllRolls(i) < 10 And AllRolls(i) + AllRolls(i + 1) < 10 Then
'                Console.WriteLine("Default")
'                CurrentFrame.PinsRolled.Add(AllRolls(i))
'                CurrentFrame.PinsRolled.Add(AllRolls(i + 1))
'                i += 1
'                CurrentFrame.Score = CurrentFrame.PinsRolled.Sum

'                'Strike
'            ElseIf AllRolls(i) >= 10 Then
'                Console.WriteLine("Strike")
'                CurrentFrame.PinsRolled.Add(AllRolls(i))
'                CurrentFrame.Score = CurrentFrame.PinsRolled.Sum + AllRolls(i + 1) + AllRolls(i + 2)

'                'in der Letzten Runde Wenn ein Spare oder Strike geworfen wird kommt noch ein Wert hinzu
'            ElseIf i = AllRolls.Count - 3 And AllRolls(i) + AllRolls(i + 1) >= 10 Or AllRolls(i) >= 10 Then
'                Console.WriteLine("Letzt Runde Strike oder Spare")
'                CurrentFrame.PinsRolled.Add(AllRolls(i))
'                CurrentFrame.PinsRolled.Add(AllRolls(i + 1))
'                CurrentFrame.PinsRolled.Add(AllRolls(i + 2))
'                CurrentFrame.Score = CurrentFrame.PinsRolled.Sum

'                'Die Letzte Runde wenn kein Strike oder Spare geworfen wird
'            ElseIf i = AllRolls.Count - 3 Then
'                Console.WriteLine("Letzte Runde Default")
'                CurrentFrame.PinsRolled.Add(AllRolls(i))
'                CurrentFrame.PinsRolled.Add(AllRolls(i + 1))
'                CurrentFrame.Score = CurrentFrame.PinsRolled.Sum

'                'Spare
'            ElseIf AllRolls(i) + AllRolls(i + 1) >= 10 Then
'                Console.WriteLine("Spare")
'                CurrentFrame.PinsRolled.Add(AllRolls(i))
'                i += 1
'                CurrentFrame.PinsRolled.Add(AllRolls(i))
'                If i < AllRolls.Count - 1 Then
'                    CurrentFrame.Score = CurrentFrame.PinsRolled.Sum + AllRolls(i + 1)
'                End If

'            Else
'                Throw New Exception("Dieser Teil des Codes sollte nicht erreichbar sein")
'            End If

'            If FrameList.Count > 10 Then
'                Throw New Exception("max 10 Frames")
'            Else
'                FrameList.Add(CurrentFrame)
'                If Over() = True Then
'                    Throw New Exception("To many Frames")
'                End If
'            End If


'        Next

'    End Sub

'    Function Over() As Boolean

'        Return FrameList.Count > 10 Or AllRolls.Count > 20

'    End Function

'    Protected Overrides Sub Finalize()
'        MyBase.Finalize()
'    End Sub
'End Class
