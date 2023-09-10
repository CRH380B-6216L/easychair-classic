Imports System.Windows.Forms

Public Class umc
    Dim yiti As Boolean
    Dim umctext As String
    Dim nationname, topic, time As String

    Sub umcstringmake() 'preview
        nationname = TextBox1.Text
        topic = TextBox2.Text
        time = NumericUpDown1.Value
        If TextBox2.Text <> "" Then yiti = True Else yiti = False
        If CheckBox1.Checked = True Then yiti = True Else yiti = False
        If loadnsave.langload = 1 Then
            umctext = nationname + "动议一个自由磋商"
            If yiti = True Then
                umctext = umctext + vbCrLf + "议题为" + topic
            End If
            umctext = umctext + vbCrLf + "总时长为" + time + "分钟"
        Else
            umctext = nationname + " motions for an unmoderated caucus"
            If yiti = True Then
                umctext = umctext + vbCrLf + "Topic: " + topic
            End If
            umctext = umctext + vbCrLf + "Total time: " + time + " min"
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
            Dim second = MsgBox(motion(0), 32 + 4, "自由磋商")
            If second = vbNo Then
                umctext = umctext + vbCrLf + motion(3)
                Form1.lblmain.Text = umctext
                Form1.txthcmotion.Text = umctext
            Else
                Dim infavor = MsgBox(motion(1) + vbCrLf + motion(2), 32 + 4, "自由磋商")
                If infavor = vbNo Then
                    umctext = umctext + vbCrLf + motion(3)
                    Form1.lblmain.Text = umctext
                    Form1.txthcmotion.Text = umctext
                Else
                    Form1.txthci.Text = "0"
                    Form1.txthck.Text = "0"
                    Form1.numtime.Value = NumericUpDown1.Value * 60
                    Form1.numtime.Enabled = False
                    Form1.txthci.Text = NumericUpDown1.Value * 60
                    Form1.txthck.Text = NumericUpDown1.Value
                    Form1.txthcmotion.Text = umctext
                    Form1.lblhc1.Text = "UMC"
                    Form1.Timer2.Enabled = True
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

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.CheckBox1.Checked = True Then
            TextBox2.Enabled = True
        Else
            TextBox2.Enabled = False
        End If
    End Sub

    Private Sub umc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 660 - Me.Height
        Me.Left = 300
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        TextBox1.BackColor = Color.White
    End Sub
End Class
