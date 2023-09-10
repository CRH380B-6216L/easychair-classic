Imports System.Windows.Forms

Public Class mc
    Dim mctext As String
    Dim nationname, topic, timek, timei As String

    Sub mcstringmake()
        nationname = TextBox1.Text
        topic = TextBox2.Text
        timek = NumericUpDown1.Value
        timei = NumericUpDown2.Value
        If loadnsave.langload = 1 Then
            mctext = nationname + "动议一个有主持核心磋商" + vbCrLf + "议题为" + topic + vbCrLf + "总时长为" + timek + "分钟, 每位代表" + timei + "秒"
        Else
            mctext = nationname + " motions for a moderated caucus" + vbCrLf + "Topic: " + topic + vbCrLf + "Total time: " + timek + " min, " + timei + " sec for each"
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Dim motion(3) As String, liang2 As String
        If loadnsave.langload = 1 Then
            liang2 = "lang\motion1.edl"
        Else
            liang2 = "lang\motion2.edl"
        End If
        Dim mload As New System.IO.StreamReader(liang2)
        For r = 1 To 4
            motion(r - 1) = mload.ReadLine
        Next
        mload.Close()
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("请填写国家和议题！", MsgBoxStyle.Exclamation, "有主持核心磋商")
        Else
            Call mcstringmake()
            Form1.lblmain.Text = mctext
            Dim second = MsgBox(motion(0), 32 + 4, "有主持核心磋商")
            If second = vbNo Then
                mctext = mctext + vbCrLf + motion(3)
                Form1.lblmain.Text = mctext
                Form1.txthcmotion.Text = mctext
            Else
                Dim infavor = MsgBox(motion(1) + vbCrLf + motion(2), 32 + 4, "有主持核心磋商")
                If infavor = vbNo Then
                    mctext = mctext + vbCrLf + motion(3)
                    Form1.lblmain.Text = mctext
                    Form1.txthcmotion.Text = mctext
                Else
                    Form1.txthci.Text = "0"
                    Form1.txthck.Text = "0"
                    Form1.numtime.Value = NumericUpDown2.Value
                    Form1.numtime.Enabled = False
                    Form1.txthci.Text = NumericUpDown2.Value
                    Form1.txthck.Text = NumericUpDown1.Value
                    Form1.txthcmotion.Text = mctext
                    Form1.lblhc1.Text = "MC"
                    Call Form1.mcready(0)
                    Form1.TextBox2.Text = nationname
                End If
            End If
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnpreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpreview.Click
        If btnpreview.Text = "高级功能" Then
            LinkLabel1.Visible = True
            btnpreview.Text = "收起"
            Me.Height = 205
        Else
            LinkLabel1.Visible = False
            btnpreview.Text = "高级功能"
            Me.Height = 170
        End If
    End Sub

    Private Sub mc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 660 - Me.Height
        Me.Left = 216
        Me.Height = 170
        TextBox1.Focus()
        'If ComboBox1.SelectedItem = "" Then
        'LinkLabel2.Enabled = False
        'ComboBox1.Enabled = False
        'End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MsgBox("提示: 下面将进入议题辩论环节。" + vbCrLf + "请分别支持两个备选议题的国家先后高举国家牌，主席分别抽取3个国家发言。" + vbCrLf + "若发言完毕后有超过一位代表的发言时间剩余，直接点击" + Chr(34) + "提前结束" + Chr(34) + "即可结束议题辩论。" + vbCrLf + "辩论结束后点击主控制台的" + Chr(34) + "议题选定" + Chr(34) + "以开始对备选议题的投票。", 64, "有主持核心磋商")
        Form1.txthci.Text = "0"
        Form1.txthck.Text = "0"
        Form1.numtime.Value = NumericUpDown2.Value
        Form1.numtime.Enabled = False
        Form1.txthci.Text = NumericUpDown2.Value
        Form1.txthck.Text = NumericUpDown2.Value \ 10
        timek = NumericUpDown2.Value \ 10
        timei = NumericUpDown2.Value
        Form1.txthcmotion.Text = "对备选议题进行讨论" + vbCrLf + "请分别支持两个议题的各3位代表发言" + vbCrLf + "总时长为" + timek + "分钟, 每位代表" + timei + "秒"
        Form1.lblmain.Text = Form1.txthcmotion.Text
        Form1.lblhc1.Text = "MC"
        Call Form1.mcready(1)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) And TextBox1.Text <> "" Then
            TextBox2.Focus()
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) And TextBox2.Text <> "" Then
            NumericUpDown1.Focus()
        End If
    End Sub

    Private Sub NumericUpDown1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NumericUpDown1.KeyPress
        If e.KeyChar = Chr(13) Then
            NumericUpDown2.Focus()
        End If
    End Sub

    Private Sub NumericUpDown2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles NumericUpDown2.KeyPress
        If e.KeyChar = Chr(13) Then
            OK_Button.Focus()
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged
        NumericUpDown2.Maximum = NumericUpDown1.Value * 60
    End Sub
End Class
