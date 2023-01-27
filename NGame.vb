Imports System.Net.NetworkInformation
Imports System.Security.Cryptography.X509Certificates

Public Class NGame
    Private AllRolls As New List(Of Integer)
    Public FrameList As New List(Of Frame)
    Sub Adroll(ByVal pins As Integer)
        If pins >= 0 And pins <= 10 Then
            AllRolls.Add(pins)
        Else
            Throw New Exception($"ungültige Pinannzahl {pins} es müssen mindestens 0 Pins und maximal 10 Pins geworfen werden")
        End If

    End Sub
    Function TotalScore() As Integer
        Dim FinalSum = 0
        For Each frame As Frame In FrameList
            FinalSum += frame.Score
        Next
        If FinalSum > 300 Then
            Throw New Exception("Programmierfehler! Kann nicht sein.")
        End If
        Return FinalSum
    End Function
    Function IsLastFrame()
        Return FrameList.Count = 10
    End Function
    Sub BuildUpFrames()
        FrameList.Clear()
        For i = 0 To AllRolls.Count - 3
            Dim CurrentFrame As New Frame
            CurrentFrame.PinsRolled(0) = AllRolls(i)
            'Im letzten Frame wenn es ein Strike oder Spare ist
            If IsLastFrame() Then
                Dim cLastFrame As LastFrame = New LastFrame
                cLastFrame.ManageArrLeng()
                cLastFrame.PinsRolled(0) = AllRolls(i)
                If cLastFrame.IsStrike Then
                    i += 1
                    cLastFrame.PinsRolled(1) = AllRolls(i)
                    i += 1
                    cLastFrame.PinsRolled(2) = AllRolls(i)
                Else
                    i += 1
                    cLastFrame.PinsRolled(1) = AllRolls(i)
                    If cLastFrame.IsSpare Then
                        i += 1
                        cLastFrame.PinsRolled(2) = AllRolls(i)
                    End If
                    cLastFrame.Score = cLastFrame.PinsRolled.Sum
                    FrameList.Add(cLastFrame)
                    Exit Sub
                End If

            ElseIf CurrentFrame.IsStrike Then
                Console.WriteLine("Is Strike")
                CurrentFrame.Score = CurrentFrame.PinsRolled.Sum + AllRolls(i + 2) + AllRolls(i + 1)

            Else

                CurrentFrame.PinsRolled(1) = AllRolls(i + 1)
                If CurrentFrame.IsSpare Then
                    Console.WriteLine("Is Spare")
                    CurrentFrame.Score = CurrentFrame.PinsRolled.Sum + AllRolls(i + 2)

                Else
                    Console.WriteLine("Is Default")
                    CurrentFrame.Score = CurrentFrame.PinsRolled.Sum
                End If
                i += 1
            End If

            If FrameList.Count > 10 Then
                Throw New Exception("max 10 Frames")
            End If
            Console.WriteLine(FrameList.Count)
            FrameList.Add(CurrentFrame)
        Next


    End Sub

End Class
