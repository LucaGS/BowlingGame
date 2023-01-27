Imports System.Runtime.Remoting.Messaging
Imports System.Xml.Schema

Module Main

    Sub Main()
        Dim bowling As New NGame
        Dim tempScore As New List(Of Integer)
        '{1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6} OK
        '{10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10} Ein Wurf zu viel
        '{9,1,8,2,10,9,1,8,0,8,2,9,9,10,10,10,9,1}  müsste 191 sein, geht nicht weil mehr Pins umgeworfen werden als Existieren
        'https://www.bowling-wissen.de/regeln/punktezaehlung/frame-6-10 Beispiele eingeben und probieren, ob das richtige rauskommt

        Dim game() As Integer = {9, 1, 8, 2, 10, 9, 1, 8, 0, 8, 2, 9, 0, 10, 10, 10, 9, 1}
        For Each roll In Game
            Bowling.AdRoll(roll)
        Next
        Dim ScoreCounter As Integer = 0
        bowling.BuildUpFrames()
        For Each cFrame In bowling.FrameList

            Console.Write("[")
            Dim Count = 0
            For Each roll In cFrame.PinsRolled
                If Count = 1 And roll = 0 Then

                Else
                    Console.Write($" {roll}")
                End If
                Count += 1
            Next
            ScoreCounter += cFrame.Score
            Console.Write($"] {cFrame.Score} | Total: { ScoreCounter} " & Environment.NewLine)

        Next
        Console.WriteLine(Bowling.TotalScore())
        Console.ReadKey()
    End Sub

End Module
