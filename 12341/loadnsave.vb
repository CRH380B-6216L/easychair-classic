Imports System.IO

Public Class loadnsave

    Public Shared Sub nationload()
        Dim nload As New StreamReader("DATA\NATIONLIST.edb")
        Dim pload As New StreamReader("DATA\NATIONLIST_P.edb")
        Dim pwrite As New StreamWriter("DATA\natemp.tmp")
        Dim nat1 As String, nat2 As Boolean
        nat1 = nload.ReadLine()
        Do Until nat1 Is Nothing
            nat2 = pload.ReadLine()
            If nat2 = True Then
                pwrite.WriteLine(nat1)
            End If
        Loop
        pwrite.Close()
        nload.Close()
        pload.Close()
    End Sub

    Public Shared Function langload()
        Dim lload As Integer
        Dim langload1 As New System.IO.StreamReader("DATA\STATUS.edb")
        lload = langload1.ReadLine()
        langload1.Close()
        Return lload
    End Function

    Public Shared Sub motion(ByVal nation As String, ByVal topic As String, ByVal mode As String, ByVal timek As Integer, ByVal timei As Integer)
        'Call umcstringmake()
        Dim motiontext As String
        Form1.lblmain.Text = motiontext

        Dim second = MsgBox("Are there any second?", 32 + 4, "自由磋商")
        If second = vbNo Then
            motiontext = motiontext + vbCrLf + "Motion Failed"
            Form1.lblmain.Text = motiontext
            Form1.txthcmotion.Text = motiontext
        Else
            Dim infavor = MsgBox("Delegates who are in favor of this motion, please raise your placards." + vbCrLf + "Does the motion pass?", 32 + 4, "自由磋商")
            If infavor = vbNo Then
                motiontext = motiontext + vbCrLf + "Motion Failed"
                Form1.lblmain.Text = motiontext
                Form1.txthcmotion.Text = motiontext
            Else
                Form1.txthci.Text = "0"
                Form1.txthck.Text = "0"
                Form1.numtime.Value = timei * 60
                Form1.numtime.Enabled = False
                Form1.txthci.Text = timei * 60
                Form1.txthck.Text = timek
                Form1.txthcmotion.Text = motiontext
                Form1.lblhc1.Text = mode
                Form1.Timer2.Enabled = True
            End If
        End If

    End Sub

    Public Shared Function loadfile(ByVal fname As String)
        Dim fill As String
        Dim load1 As New StreamReader(fname)
        If load1.ReadLine = "EasyChair Model UN Conference Database File" Then
            Try
                For i = 1 To 6
                    Dim s As New StreamWriter("DATA\" + load1.ReadLine)
                    Do
                        fill = load1.ReadLine
                        If fill = "FileEnd" Then Exit Do
                        s.WriteLine(fill)
                    Loop
                    s.Close()
                Next
                Return 0
            Catch ex As Exception
                MsgBox(fname + "不是有效的EasyChair会议数据文件。", 32, "读取会议数据")
                Return 1
            Finally
                load1.Close()
                load1.Dispose()
            End Try
        Else
            MsgBox(fname + "不是有效的EasyChair会议数据文件。", 32, "读取会议数据")
            Return 1
        End If
    End Function

    Public Shared Sub savefile(ByVal fname As String)
        Dim save1 As New StreamWriter(fname)
        Dim files As String
        save1.WriteLine("EasyChair Model UN Conference Database File")

        save1.WriteLine("PRESET_WELCOME.edb")
        Dim l1 As New StreamReader("DATA\PRESET_WELCOME.edb")
        files = l1.ReadToEnd()
        l1.Close()
        save1.Write(files)
        save1.WriteLine(vbCrLf + "FileEnd")

        save1.WriteLine("STATUS.edb")
        Dim l2 As New StreamReader("DATA\STATUS.edb")
        files = l2.ReadToEnd()
        l2.Close()
        save1.Write(files)
        save1.WriteLine(vbCrLf + "FileEnd")

        save1.WriteLine("NATIONLIST.edb")
        Dim l3 As New StreamReader("DATA\NATIONLIST.edb")
        files = l3.ReadToEnd()
        l3.Close()
        save1.Write(files)
        save1.WriteLine(vbCrLf + "FileEnd")

        save1.WriteLine("NATIONLIST_P.edb")
        Dim l4 As New StreamReader("DATA\NATIONLIST_P.edb")
        files = l4.ReadToEnd()
        l4.Close()
        save1.Write(files)
        save1.WriteLine(vbCrLf + "FileEnd")

        save1.WriteLine("SPEAKERS.edb")
        Dim l5 As New StreamReader("DATA\SPEAKERS.edb")
        files = l5.ReadToEnd()
        l5.Close()
        save1.Write(files)
        save1.WriteLine(vbCrLf + "FileEnd")

        save1.WriteLine("FILES.edb")
        Dim l6 As New StreamReader("DATA\FILES.edb")
        files = l6.ReadToEnd()
        l6.Close()
        save1.Write(files)
        save1.WriteLine(vbCrLf + "FileEnd")

        save1.WriteLine("DatabaseEnd")
        save1.Close()
        save1.Dispose()
    End Sub

    Public Shared Sub clear(ByVal f1 As Boolean, ByVal f2 As Boolean, ByVal f3 As Boolean, ByVal f4 As Boolean, ByVal f5 As Boolean, ByVal f6 As Boolean)
        If f1 = True Then
            Dim c1 As New StreamWriter("DATA\NATIONLIST_P.edb")
            c1.Write("")
            c1.Close()
        End If
        If f2 = True Then
            Dim c2 As New StreamWriter("DATA\STATUS.edb")
            c2.WriteLine("1")       '工作语言
            c2.WriteLine(False)    '会议是否开始
            c2.WriteLine(True)       '控制台是否可使用
            c2.WriteLine(False)        '点名是否完成
            c2.WriteLine(False)   '主发言名单窗体是否开启
            c2.WriteLine(False)        '是否正在进行MC
            c2.WriteLine(False)      '投票窗体是否打开
        End If
        If f3 = True Then
            Dim c3 As New StreamWriter("DATA\PRESET_WELCOME.edb")
            c3.Write("")
            c3.Close()
        End If
        If f4 = True Then
            Dim c4 As New StreamWriter("DATA\NATIONLIST.edb")
            c4.Write("")
            c4.Close()
        End If
        If f5 = True Then
            Dim c5 As New StreamWriter("DATA\SPEAKERS.edb")
            c5.WriteLine("0")
            c5.WriteLine("0")
            c5.WriteLine("2")
            c5.WriteLine("0")
            c5.Close()
        End If
        If f6 = True Then
            Dim c6 As New StreamWriter("DATA\FILES.edb")
            c6.Write("")
            c6.Close()
        End If
    End Sub
End Class
