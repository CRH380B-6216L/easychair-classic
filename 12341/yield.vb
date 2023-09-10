Imports System.Windows.Forms

Public Class yield

    Dim yieldType As Integer

    Sub yieldAction(ByVal type As Integer)
        Select Case type
            Case 1
                Me.Text = "让渡给他国代表"
                Label1.Text = "请选择被让渡的国家："
                yieldType = 1
            Case 2
                Me.Text = "让渡给问题"
                Label1.Text = "请选择提问的国家："
                Button1.Text = "提问完毕后开始计时"
                yieldType = 2
            Case 3
                Me.Text = "让渡给评论"
                Label1.Text = "请选择评论的国家："
                yieldType = 3
        End Select
    End Sub


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub yield_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = 474
        Me.Top = 554
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Button1.Text = "开始计时" Or Button1.Text = "提问完毕后开始计时" Then
            Call Form1.yieldAct(yieldType, True)
            Button1.Text = "结束"
        Else
            Call Form1.yieldAct(yieldType, False)
            Me.Close()
        End If
    End Sub
End Class
