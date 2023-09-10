Imports System.Windows.Forms

Public Class topicsel
    Dim conf, comite As String
    Dim mtopic(1) As String
    Dim multi1 As Integer

    Sub seltopic(ByVal a As Integer)
        MsgBox("设定成功！" + vbCrLf + "议题将确定为: " + mtopic(a), 64, "议题选定")
        Form1.Text = comite + "  " + mtopic(a) + "  第" + Form1.lblhc2.Text + "会期"
        Form1.lblstatusmain.Text = comite + vbCrLf + mtopic(a) + vbCrLf + "第" + Form1.lblhc2.Text + "会期"
        If conf <> "" Then Form1.lblstatusmain.Text = conf + vbCrLf + Form1.lblstatusmain.Text
        Form1.lblmain.Text = "本次会议的议题选定为: " + vbCrLf + mtopic(a)
        Form1.txthcmotion.Text = "本次会议的议题选定为: " + vbCrLf + mtopic(a)
        Dim save As New System.IO.StreamWriter("DATA\PRESET_WELCOME.edb")
        save.WriteLine(a)
        save.WriteLine(conf)
        save.WriteLine(comite)
        save.WriteLine(mtopic(0))
        save.WriteLine(mtopic(1))
        save.Close()
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If nume1.Value > nume2.Value Then
            Call seltopic(0)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        ElseIf nume1.Value < nume2.Value Then
            Call seltopic(1)
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("两议题票数相同，请重新投票！", 48, "议题选定")
            nume1.Value = 0
            nume2.Value = 0
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub topicsel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 660 - Me.Height
        Me.Left = 55
        Try
            Dim load As New System.IO.StreamReader("DATA\PRESET_WELCOME.edb")
            multi1 = load.ReadLine
            conf = load.ReadLine
            comite = load.ReadLine
            mtopic(0) = load.ReadLine
            mtopic(1) = load.ReadLine
            load.Close()
        Catch ex As Exception

        End Try
        Label1.Text = comite
        If conf <> "" Then Label1.Text = conf + " " + Label1.Text
        Select Case multi1
            Case 2
                Label1.Text = Label1.Text + vbCrLf + "议题选定"
                Label2.Text = mtopic(0)
                Label3.Text = mtopic(1)
                Label4.Visible = False
            Case Else
                Label1.Text = Label1.Text + vbCrLf + "议题已选定！"
                Label2.Visible = False
                Label3.Visible = False
                Label4.Text = mtopic(multi1)
                OK_Button.Enabled = False
                nume1.Visible = False
                nume2.Visible = False
                If Label4.Width > Label1.Width Then
                    Me.Width = Label4.Width + 38
                Else
                    Me.Width = Label1.Width + 38
                End If
        End Select
    End Sub
End Class
