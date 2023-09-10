Imports System.Windows.Forms

Public Class custom

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text <> "" Then
            Form1.lblmain.Text = TextBox1.Text
            Form1.txthcmotion.Text = TextBox1.Text
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("请填写消息内容！", MsgBoxStyle.Exclamation, "自定义消息")
        End If
    End Sub

    Private Sub custom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 660 - Me.Height
        Me.Left = 580
    End Sub

    Private Sub lblpreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
