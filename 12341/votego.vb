Imports System.Windows.Forms

Public Class votego

    Dim vstring As String

    Sub vstringmake()
        vstring = "Voting for " + ComboBox1.SelectedItem + ""
        If TextBox1.Enabled = True Then vstring = TextBox1.Text + " motions to " + vstring
    End Sub

    Sub vstart()
        Call vstringmake()
        voting.Show()
        If loadnsave.langload = 1 Then
            voting.Text = "正在对" + ComboBox1.SelectedItem + "进行投票"
        Else
            voting.Text = "Voting for " + ComboBox1.SelectedItem + ""
        End If
        voting.lblhcname.Text = ComboBox1.SelectedItem
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
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
        If TextBox1.Enabled = True Then
            If TextBox1.Text = "" Then
                MsgBox("请填写动议国！", 48, "开始投票")
            Else
                Call vstringmake()
                Form1.lblmain.Text = vstring
                Dim second = MsgBox(motion(0), 32 + 4, "动议投票")
                If second = vbNo Then
                    vstring = vstring + vbCrLf + motion(3)
                    Form1.lblmain.Text = vstring
                    Form1.txthcmotion.Text = vstring
                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    Dim infavor = MsgBox(motion(1) + vbCrLf + motion(2), 32 + 4, "动议投票")
                    If infavor = vbNo Then
                        vstring = vstring + vbCrLf + motion(3)
                        Form1.lblmain.Text = vstring
                        Form1.txthcmotion.Text = vstring + vbCrLf
                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()
                    Else
                        If loadnsave.langload = 1 Then
                            Form1.txthcmotion.Text = vstring + "获得通过，投票开始"
                        Else
                            Form1.txthcmotion.Text = vstring + "Motion passed, voting starts"
                        End If

                        Call Form1.kztctrl(False)
                        Call vstart()
                    End If
                End If
            End If
        Else
            Call vstringmake()
            Form1.lblmain.Text = vstring
            Form1.txthcmotion.Text = "开始" + vstring
            Call Form1.kztctrl(False)
            Call vstart()
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub votego_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 695 - Me.Height
        Me.Left = 120
        Dim cungenload As New System.IO.StreamReader("DATA\FILES.edb")
        Try
            Do Until cungenload Is Nothing
                ComboBox1.Items.Add(cungenload.ReadLine)
            Loop
            ComboBox1.SelectedIndex = 0
        Catch ex As Exception
            cungenload.Close()
            'MsgBox("没有发布任何文件！", 16, "投票")
            'Me.Close()
        End Try
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            TextBox1.Enabled = True
        Else
            TextBox1.Enabled = False
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton2.Checked = True Then
            TextBox1.Enabled = True
        Else
            TextBox1.Enabled = False
        End If
    End Sub
End Class
