Imports System.Windows.Forms

Public Class award

    Dim awardstring As String
    Dim renshu As Integer
    Dim info As Boolean

    Sub awardstringmake()
        If info = True Then
            MsgBox("请检查所有项目是否已经填写完成！", MsgBoxStyle.Exclamation, "颁奖")
        Else
            awardstring = ComboBox1.Text + vbCrLf + "Award to delegate of " + TextBox1.Text + "" + vbCrLf
            If renshu = 1 Then
                awardstring = awardstring + TextBox2.Text + vbCrLf + "From " + TextBox5.Text + vbCrLf + "Congratulations!!"
            ElseIf renshu = 2 Then
                awardstring = awardstring + TextBox2.Text + " and " + TextBox3.Text + vbCrLf + "From " + TextBox5.Text + vbCrLf + "Congratulations!!"
            ElseIf renshu = 3 Then
                awardstring = awardstring + TextBox2.Text + ", " + TextBox3.Text + " and " + TextBox4.Text + vbCrLf + "From " + TextBox5.Text + vbCrLf + "Congratulations!!"
            End If
        End If
    End Sub
    Sub renshua()
        If TextBox2.Text <> "" Then
            renshu = 1
            If TextBox3.Text <> "" And CheckBox1.Checked = True Then
                renshu = 2
                If TextBox4.Text <> "" And CheckBox2.Checked = True Then
                    renshu = 3
                End If
            End If
        Else
            renshu = 0
        End If
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Call renshua()
        If ComboBox1.Text = "" Or TextBox1.Text = "" Or TextBox5.Text = "" Or renshu = 0 Then info = True
        Call awardstringmake()
        If info = False Then
            Form1.lblmain.Text = awardstring
            Form1.txthcmotion.Text = awardstring
            renshu = 0
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox3.Enabled = True
            CheckBox2.Enabled = True
        Else
            TextBox3.Enabled = False
            CheckBox2.Checked = False
            CheckBox2.Enabled = False
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            TextBox4.Enabled = True
        Else
            TextBox4.Enabled = False
        End If
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ComboBox1.Text = ""
        Form1.lblmain.Text = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
    End Sub

    Private Sub btnpreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call renshua()
        If ComboBox1.Text = "" Or TextBox1.Text = "" Or TextBox5.Text = "" Or renshu = 0 Then info = True
        Call awardstringmake()
        Form1.lblmain.Text = awardstring
    End Sub

    Private Sub award_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 695 - Me.Height
        Me.Left = 216
    End Sub
End Class
