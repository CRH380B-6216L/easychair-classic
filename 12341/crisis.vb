Imports System.Windows.Forms

Public Class crisis
    Dim record As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.txthci.Text = "0"
        Form1.txthck.Text = "0"
        Form1.numtime.Value = NumericUpDown1.Value * 60
        Form1.numtime.Enabled = False
        Form1.txthci.Text = NumericUpDown1.Value * 60
        Form1.txthck.Text = NumericUpDown1.Value
        Form1.lblhc1.Text = "CR"
        Form1.Timer2.Enabled = True
        If loadnsave.langload = 1 Then
            record = "阅读危机 (" + NumericUpDown1.Text + "分钟)"
        Else
            record = "Crisis (Reading time: " + NumericUpDown1.Text + " minutes)"
        End If
        If TextBox1.Text <> "" Then
            record = record + vbCrLf + TextBox1.Text
        End If
        Form1.lblmain.Text = record
        Form1.txthcmotion.Text = Form1.lblmain.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub crisis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 695 - Me.Height
        Me.Left = 100
        If loadnsave.langload = 1 Then
            Label2.Text = "危机正文(不超过160个汉字):"
            TextBox1.MaxLength = 160
        Else
            Label2.Text = "危机正文(not exceed 800 characters):"
            TextBox1.MaxLength = 800
        End If
    End Sub
End Class
