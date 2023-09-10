Imports System.Windows.Forms

Public Class speaker
    Declare Function SetWindowPos Lib "user32" (ByVal hwnd As Long, ByVal hWndInsertAfter As Long, ByVal x As Long, ByVal y As Long, ByVal cx As Long, ByVal cy As Long, ByVal wFlags As Long) As Long
    'Public Const hwnd = 0
    'Public Const SWP_NOMOVE = &H2    '不移动窗体
    'Public Const SWP_NOSIZE = &H1 '不改变窗体尺寸
    'Public Const Flag = SWP_NOMOVE Or SWP_NOSIZE
    'Public Const HWND_TOPMOST = -1 '窗体总在最前面
    'Public Const HWND_NOTOPMOST = -2 '窗体不在最前面

    Dim a, b As Integer
    Dim nations(193) As String, spoken(193) As Boolean
    Dim timing As Integer
    Dim slstring As String
    Dim mm, ss As String
    Dim current, max As Integer

    Sub timeCHange(ByVal m As Integer, ByVal s As Integer)
        Label4.Text = m
        Label5.Text = s
        mm = Label4.Text
        ss = Label5.Text
        timing = Val(Label4.Text) * 60 + Val(Label5.Text)
        Call savefile()
    End Sub

    Sub timerContinue()
        Form1.Timer2.Enabled = True
        Button2.Text = "暂停"
        ComboBox1.Enabled = False
        Form1.Timer3.Enabled = True
        Call fanye()
    End Sub

    Sub nationadd()
        If TextBox2.Text = "" Then
        Else
            a = Val(TextBox1.Text)
            nations(a) = TextBox2.Text
            TextBox1.Text = a + 1
            TextBox2.Text = ""
            TextBox2.Select()
            If a = 1 Then
                TextBox3.Text = b + 1
                TextBox4.Text = nations(b + 1)
            End If
            If a = 51 Then Button5.Enabled = True
            Call display((a - 1) \ 50)
            current = (a - 1) \ 50
            Call fanye()
            Call savefile()
        End If
    End Sub

    Sub fanye()
        Button5.Enabled = True
        Button6.Enabled = True
        If current = max Then Button6.Enabled = False
        If current = 0 Then Button5.Enabled = False
    End Sub

    Sub strmake()
        mm = Label4.Text
        ss = Label5.Text
        If loadnsave.langload = 1 Then
            slstring = "主发言名单 (" + mm
            If Label5.Text = 0 Then
                slstring = slstring + "分钟)"
            Else
                slstring = slstring + "分" + ss + "秒)"
            End If
            slstring = slstring + vbCrLf + "当前发言: " + nations(b + 1)
        Else
            slstring = "Speakers' List (" + mm
            If Label5.Text = 0 Then
                slstring = slstring + " minutes)"
            Else
                slstring = slstring + "m " + ss + "s)"
            End If
            slstring = slstring + vbCrLf + "Current: " + nations(b + 1)
        End If
        Form1.txthcmotion.Text = slstring
    End Sub

    Sub loadfile()
        Try
            Dim load1 As New System.IO.StreamReader("DATA\SPEAKERS.edb")
            a = load1.ReadLine()
            b = load1.ReadLine()
            Label4.Text = load1.ReadLine()
            Label5.Text = load1.ReadLine()
            For i = 1 To a
                nations(i) = load1.ReadLine
                spoken(i) = load1.ReadLine
            Next
            load1.Close()
        Catch ex As Exception

        End Try
        TextBox1.Text = a + 1
        TextBox3.Text = b + 1
        TextBox4.Text = nations(b + 1)
        timing = Val(Label4.Text) * 60 + Val(Label5.Text)
    End Sub

    Sub savefile()
        Try
            Dim save1 As New System.IO.StreamWriter("DATA\SPEAKERS.edb")
            save1.WriteLine(a)
            save1.WriteLine(b)
            save1.WriteLine(Label4.Text)
            save1.WriteLine(Label5.Text)
            For ii = 1 To a
                save1.WriteLine(nations(ii))
                save1.WriteLine(spoken(ii))
            Next
            save1.Close()
        Catch ex As Exception

        End Try
    End Sub

    Sub display(ByVal pages As Integer)
        lblnat1.Text = ""
        lblnat2.Text = ""
        lblnat3.Text = ""
        lblnat4.Text = ""
        lblnat5.Text = ""
        If a = 0 Then Exit Sub
        For l1 = pages * 50 + 1 To a
            If spoken(l1) = True Then
                lblnat1.Text = lblnat1.Text + "× " + nations(l1) + vbCrLf
            Else
                lblnat1.Text = lblnat1.Text + "¤ " + nations(l1) + vbCrLf
            End If
            If l1 > pages * 50 + 10 Then Exit For
        Next
        If a > pages * 50 + 10 Then
            For l2 = pages * 50 + 11 To a
                If spoken(l2) = True Then
                    lblnat2.Text = lblnat2.Text + "× " + nations(l2) + vbCrLf
                Else
                    lblnat2.Text = lblnat2.Text + "¤ " + nations(l2) + vbCrLf
                End If
                If l2 > pages * 50 + 20 Then Exit For
            Next
        End If
        If a > pages * 50 + 20 Then
            For l3 = pages * 50 + 21 To a
                If spoken(l3) = True Then
                    lblnat3.Text = lblnat3.Text + "× " + nations(l3) + vbCrLf
                Else
                    lblnat3.Text = lblnat3.Text + "¤ " + nations(l3) + vbCrLf
                End If
                If l3 > pages * 50 + 30 Then Exit For
            Next
        End If
        If a > pages * 50 + 30 Then
            For l4 = pages * 50 + 31 To a
                If spoken(l4) = True Then
                    lblnat4.Text = lblnat4.Text + "× " + nations(l4) + vbCrLf
                Else
                    lblnat4.Text = lblnat4.Text + "¤ " + nations(l4) + vbCrLf
                End If
                If l4 > pages * 50 + 40 Then Exit For
            Next
        End If
        If a > pages * 50 + 40 Then
            For l5 = pages * 50 + 41 To a
                If spoken(l5) = True Then
                    lblnat5.Text = lblnat5.Text + "× " + nations(l5) + vbCrLf
                Else
                    lblnat5.Text = lblnat5.Text + "¤ " + nations(l5) + vbCrLf
                End If
                If l5 > pages * 50 + 50 Then Exit For
            Next
        End If
        '==============================
        Dim p1, p2 As String
        max = (a - 1) \ 50
        p1 = current + 1
        p2 = max + 1
        Label3.Text = "第 " + p1 + "/" + p2 + " 页"
    End Sub

    Sub speaknext()
        b = b + 1
        spoken(b) = True
        Button2.Enabled = True
        ComboBox1.Enabled = False
        Cancel_Button.Enabled = True
        Form1.numtime.Enabled = False
        If b = a Then
        Else
            TextBox3.Text = b + 1
            TextBox4.Text = nations(b + 1)
        End If
        Call display((b - 1) \ 50)
        current = (b - 1) \ 50
        Call fanye()
        Call savefile()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub speaker_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call Form1.fclose()
        Form1.numtime.Enabled = True
        Form1.lblcount.Text = ""
    End Sub

    Private Sub speaker_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 250
        Me.Left = 5
        max = (a - 1) \ 50 + 1
        ComboBox1.SelectedIndex = 0
        Call loadfile()
        Call display(current)
        Call fanye()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call nationadd()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call Form1.speakerend(False)
        Call speaknext()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Button2.Text = "开始" Then
            Form1.numtime.Value = timing
            Form1.numtime.Enabled = False
            Form1.lblhc1.Text = "SL"
            Button2.Text = "暂停"
            Cancel_Button.Enabled = False
            ComboBox1.Enabled = False
            Call display((b - 1) \ 50)
            current = (b - 1) \ 50
            Call fanye()
            Button5.Enabled = False
            Button6.Enabled = False
            Call strmake()
            Call Form1.speakergo()
        ElseIf Button2.Text = "暂停" Then
            Form1.Timer2.Enabled = False
            Button2.Text = "继续"
            Form1.lblmain.Text = Form1.lblmain.Text + " - 已暂停"
            Form1.Timer3.Enabled = False
            Form1.lblcount.ForeColor = Color.Blue
            ComboBox1.Enabled = True
        Else
            Call timerContinue()
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        current = current - 1
        Call display(current)
        Call fanye()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        current = current + 1
        Call display(current)
        Call fanye()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        changetime.Show()
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Call nationadd()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.SelectedIndex
            Case 1
                yield.Show()
                Call yield.yieldAction(1)
            Case 2
                yield.Show()
                Call yield.yieldAction(2)
            Case 3
                yield.Show()
                Call yield.yieldAction(3)
            Case 4
                Call Form1.yieldAct(4, False)
                Call speaknext()
            Case Else

        End Select
        ComboBox1.SelectedIndex = 0
    End Sub
End Class
