Imports System.Windows.Forms

Public Class clear

    Public Function ensure()
        Dim a = MsgBox("确实要执行初始化操作吗？", 32 + 4, "初始化")
        If a = 6 Then
            If RadioButton2.Checked = True Then
                Dim b = MsgBox("注意: 此操作将清除全部会议内容！" + vbCrLf + "确实要执行吗？请再次确认！", 48 + 4, "初始化")
                Return b
                Exit Function
            End If
        End If
        Return a
    End Function

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If ensure() = 6 Then
            If RadioButton1.Checked = True Then
                Call loadnsave.clear(True, True, False, False, False, False)
            ElseIf RadioButton2.Checked = True Then
                Call loadnsave.clear(True, True, True, True, True, True)
            Else
                Call loadnsave.clear(CheckBox1.Checked, CheckBox2.Checked, CheckBox3.Checked, CheckBox4.Checked, CheckBox5.Checked, CheckBox6.Checked)
            End If
            Form1.lblmain.Text = "Data cleared, please restart application"
            MsgBox("初始化完成，请重新启动程序。", 64, "初始化")
            End
        Else
            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CheckBox4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then CheckBox1.Checked = True
    End Sub

    Private Sub clear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 695 - Me.Height
        Me.Left = 380
        RadioButton1.Checked = True
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            Label2.ForeColor = Color.Black
            Label3.ForeColor = Label4.ForeColor
            GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            Label3.ForeColor = Color.Black
            Label2.ForeColor = Label4.ForeColor
            GroupBox1.Enabled = False
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then
            Label2.ForeColor = Label4.ForeColor
            Label3.ForeColor = Label4.ForeColor
            GroupBox1.Enabled = True
        End If
    End Sub
End Class
