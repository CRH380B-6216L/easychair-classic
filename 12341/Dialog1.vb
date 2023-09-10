Imports System.Windows.Forms

Public Class teabreak
    Dim record As String

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        record = Form1.txtrecord.Text
        Form1.txthci.Text = "0"
        Form1.txthck.Text = "0"
        Form1.numtime.Value = NumericUpDown1.Value * 60
        Form1.numtime.Enabled = False
        Form1.txthci.Text = NumericUpDown1.Value * 60
        Form1.txthck.Text = NumericUpDown1.Value
        Form1.lblhc1.Text = "TB"
        Form1.Timer2.Enabled = True
        If loadnsave.langload = 1 Then
            Form1.lblmain.Text = "茶歇 (" + NumericUpDown1.Text + " 分钟)"
        Else
            Form1.lblmain.Text = "Tea-break (" + NumericUpDown1.Text + " minutes)"
        End If
        Form1.txthcmotion.Text = Form1.lblmain.Text
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub teabreak_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 660 - Me.Height
        Me.Left = 400
    End Sub
End Class
