Imports System.Windows.Forms

Public Class changetime
    Dim umctext As String
    Dim time(1) As Integer
    Dim mm, ss As String

    Sub isChangePanDing()
        Dim isChanged As Boolean
        isChanged = False
        If NumericUpDown1.Value <> time(0) Then isChanged = True
        If NumericUpDown2.Value <> time(1) Then isChanged = True
        If isChanged = True Then
            OK_Button.Enabled = True
        Else
            OK_Button.Enabled = False
        End If
    End Sub

    Sub umcstringmake() 'preview
        mm = NumericUpDown1.Value
        ss = NumericUpDown2.Value
        If loadnsave.langload = 1 Then
            umctext = TextBox1.Text + "动议修改发言时间至" + mm + "分"
            If NumericUpDown2.Value <> 0 Then umctext = umctext + ss + "秒"
        Else
            umctext = TextBox1.Text + " motions to change the time span to " + mm + "m "
            If NumericUpDown2.Value <> 0 Then umctext = umctext + ss + "s"
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
        If TextBox1.Text <> "" Then
            Call umcstringmake()
            Form1.lblmain.Text = umctext
            Dim second = MsgBox(motion(0), 32 + 4, "修改发言时间")
            If second = vbNo Then
                umctext = umctext + vbCrLf + motion(3)
                Form1.lblmain.Text = umctext
                Form1.txthcmotion.Text = umctext
            Else
                Dim infavor = MsgBox(motion(1) + vbCrLf + motion(2), 32 + 4, "修改发言时间")
                If infavor = vbNo Then
                    umctext = umctext + vbCrLf + motion(3)
                    Form1.lblmain.Text = umctext
                    Form1.txthcmotion.Text = umctext
                Else
                    Call speaker.timeCHange(NumericUpDown1.Value, NumericUpDown2.Value)
                    Form1.txthcmotion.Text = umctext
                End If
            End If
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            TextBox1.BackColor = Color.Yellow
            MsgBox("请填写提出动议的国家名称！", MsgBoxStyle.Exclamation, "自由磋商")
            TextBox1.Focus()
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub changetime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 535
        Me.Left = 553
        time(0) = Val(speaker.Label4.Text)
        time(1) = Val(speaker.Label5.Text)
        NumericUpDown1.Value = time(0)
        NumericUpDown2.Value = time(1)
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown1.ValueChanged, NumericUpDown2.ValueChanged
        Call isChangePanDing()
    End Sub
End Class
