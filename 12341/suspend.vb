Imports System.Windows.Forms

Public Class suspend
    Dim suspendtext As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If TextBox1.Text <> "" Then
            suspendtext = TextBox1.Text + "动议休会"
            Form1.lblmain.Text = suspendtext
            Dim second = MsgBox("请问台下有无附议？", 32 + 4, "休会")
            If second = vbNo Then
                suspendtext = suspendtext + vbCrLf + "未获通过"
                Form1.lblmain.Text = suspendtext
            Else
                Dim infavor = MsgBox("请支持此动议的国家高举国家牌。" + vbCrLf + "该动议是否获得通过？", 32 + 4, "休会")
                If infavor = vbNo Then
                    suspendtext = suspendtext + vbCrLf + "未获通过"
                    Form1.lblmain.Text = suspendtext
                Else
                    suspendtext = suspendtext + vbCrLf + "获得通过，第" + Form1.lblhc2.Text + "会期结束"
                    Form1.lblmain.Text = suspendtext
                    Call Form1.susp()
                End If
            End If
            Form1.txthcmotion.Text = suspendtext
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("请填写提出动议的国家名称！", MsgBoxStyle.Exclamation, "休会")
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub suspend_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 660 - Me.Height
        Me.Left = 450
    End Sub
End Class
