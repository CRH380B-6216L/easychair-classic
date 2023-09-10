Imports System.Windows.Forms

Public Class filesvb
    Dim filename, screen As String

    Sub create()
        filename = ComboBox1.Text + TextBox1.Text + "." + TextBox2.Text
        If ComboBox1.Text = "Amendment" Then
            filename = filename + "." + TextBox3.Text
        ElseIf ComboBox1.Text = "修正案" Then
            filename = filename + "." + TextBox3.Text
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Form1.txthci.Text = "0"
        Form1.txthck.Text = "0"
        Form1.numtime.Enabled = False
        If TabControl1.SelectedIndex = 0 Then
            Call create()
            Dim cungenadd As New System.IO.StreamWriter("DATA\FILES.edb", True)
            cungenadd.WriteLine(filename)
            cungenadd.Close()
            If loadnsave.langload = 1 Then
                screen = "阅读" + filename
                If TextBox4.Text <> "" Then screen = screen + vbCrLf + "起草国: " + TextBox4.Text
                If TextBox5.Text <> "" Then screen = screen + vbCrLf + "附议国: " + TextBox5.Text
                screen = screen + vbCrLf + "阅读时间:" + Str(NumericUpDown1.Value) + "分钟"
                Form1.lblmain.Text = "请" + screen
            Else
                screen = "read " + filename
                If TextBox4.Text <> "" Then screen = screen + vbCrLf + "Sponsors: " + TextBox4.Text
                If TextBox5.Text <> "" Then screen = screen + vbCrLf + "Signatories: " + TextBox5.Text
                screen = screen + vbCrLf + "Reading time:" + Str(NumericUpDown1.Value) + " minutes"
                Form1.lblmain.Text = "Please " + screen
            End If
            Form1.numtime.Value = NumericUpDown1.Value * 60
            Form1.txthci.Text = NumericUpDown1.Value * 60
            Form1.txthck.Text = NumericUpDown1.Value
            Form1.lblhc1.Text = "FI"
        Else
            If loadnsave.langload = 1 Then
                screen = "介绍" + ComboBox3.Text
                If TextBox6.Text <> "" Then screen = screen + vbCrLf + "发言的国家: " + TextBox6.Text
                screen = screen + vbCrLf + "时间:" + Str(NumericUpDown2.Value) + "分钟"
            Else
                screen = "Introduction of " + ComboBox3.Text
                If TextBox6.Text <> "" Then screen = screen + vbCrLf + "Nations coming up speech: " + TextBox6.Text
                screen = screen + vbCrLf + "Time:" + Str(NumericUpDown2.Value) + " minutes"
            End If
            Form1.txthci.Text = NumericUpDown2.Value * 60
            Form1.txthck.Text = NumericUpDown2.Value
            Form1.numtime.Value = NumericUpDown2.Value * 60
            Form1.lblhc1.Text = "FS"
        End If
        Form1.txthcmotion.Text = screen
        Form1.Timer2.Enabled = True
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub filesvb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 695 - Me.Height
        Me.Left = 32
        TextBox1.Text = Form1.lblhc2.Text
        Dim filename As String
        If loadnsave.langload = 1 Then
            filename = "lang\file1.edl"
            Me.Width = 320
        Else
            filename = "lang\file2.edl"
            Me.Width = 370
        End If
        Dim cungenload As New System.IO.StreamReader("DATA\FILES.edb")
        Try
            Do Until cungenload Is Nothing
                ComboBox3.Items.Add(cungenload.ReadLine)
            Loop
            cungenload.Close()
            ComboBox3.SelectedIndex = 0
        Catch ex As Exception
            cungenload.Close()
        End Try
        Dim loadfile As New System.IO.StreamReader(filename)
        For i = 1 To 4
            ComboBox1.Items.Add(loadfile.ReadLine)
        Next
        loadfile.Close()
        ComboBox1.SelectedIndex = 0
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        TextBox2.Select()
    End Sub
End Class
