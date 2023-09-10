Imports System.Windows.Forms

Public Class recview

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub recview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim load As New System.IO.StreamReader("DATA\RECORD.edb")
            TextBox1.Text = load.ReadToEnd
            load.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim a = MsgBox("确实要删除记录吗？", 32 + 4, "查看会议记录")
        If a = 6 Then
            Dim clear As New System.IO.StreamWriter("DATA\RECORD.edb")
            clear.Write("")
            clear.Close()
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveFileDialog1.Title = "保存会议记录"
        SaveFileDialog1.OverwritePrompt = True
        If SaveFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Dim saveas As New System.IO.StreamWriter(SaveFileDialog1.FileName)
            saveas.Write(TextBox1.Text)
            saveas.Close()
            saveas.Dispose()
        End If
    End Sub
End Class
