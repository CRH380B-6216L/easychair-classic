Imports System.Windows.Forms
Imports System.IO

Public Class votctrl
    Dim nations(100), opini(100) As String
    Dim yes, no, abst As Integer
    Dim a, b As Integer

    Sub display(ByVal pages As Integer, ByVal nation As Boolean)
        If nation = True Then
            voting.lblnat1.Text = ""
            voting.lblnat2.Text = ""
            voting.lblnat3.Text = ""
        Else
            voting.lblop1.Text = ""
            voting.lblop2.Text = ""
            voting.lblop3.Text = ""
            voting.lblyes.Text = yes
            voting.lblno.Text = no
            voting.lblabst.Text = abst
        End If
        If a = 0 Then Exit Sub
        For l1 = pages * 30 + 1 To a
            If nation = True Then
                voting.lblnat1.Text = voting.lblnat1.Text + nations(l1) + vbCrLf
            Else
                voting.lblop1.Text = voting.lblop1.Text + opini(l1) + vbCrLf
            End If
            If l1 > pages * 50 + 10 Then Exit For
        Next
        If a > pages * 30 + 10 Then
            For l2 = pages * 50 + 11 To a
                If nation = True Then
                    voting.lblnat2.Text = voting.lblnat2.Text + nations(l2) + vbCrLf
                Else
                    voting.lblop2.Text = voting.lblop2.Text + opini(l2) + vbCrLf
                End If
                If l2 > pages * 50 + 20 Then Exit For
            Next
        End If
        If a > pages * 30 + 20 Then
            For l3 = pages * 50 + 21 To a
                If nation = True Then
                    voting.lblnat3.Text = voting.lblnat3.Text + nations(l3) + vbCrLf
                Else
                    voting.lblop3.Text = voting.lblop3.Text + opini(l3) + vbCrLf
                End If
                If l3 > pages * 50 + 30 Then Exit For
            Next
        End If
        '==============================
        Dim current, max As Integer
        Dim p1, p2 As String
        max = (a - 1) \ 50
        p1 = current + 1
        p2 = max + 1
        'Label3.Text = "第 " + p1 + "/" + p2 + " 页"
    End Sub

    Sub vote(ByVal op As String)
        Select Case op
            Case "y"
                opini(b) = "赞成"
                yes = yes + 1
            Case "n"
                opini(b) = "反对"
                no = no + 1
            Case "a"
                opini(b) = "弃权"
                abst = abst + 1
            Case "p"
        End Select
        If nations(b + 1) = "" Then
            Label4.Text = "---"
            btnyes.Enabled = False
            btnno.Enabled = False
            btnabst.Enabled = False
            btnpass.Enabled = False
        Else
            b = b + 1
            Label4.Text = nations(b)
        End If
        Call display(0, False)
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub votctrl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 550
        Me.Left = 5
        Dim conf, comite As String
        Dim mtopic(1) As String
        Dim multi1 As Integer
        Try
            Dim loada As New StreamReader("DATA\PRESET_WELCOME.edb")
            multi1 = loada.ReadLine
            conf = loada.ReadLine
            comite = loada.ReadLine
            mtopic(0) = loada.ReadLine
            mtopic(1) = loada.ReadLine
            loada.Close()
            loada.Dispose()
            voting.Label1.Text = comite + "  " + mtopic(multi1) + vbCrLf + "正在" + Form1.lblmain.Text
            If conf <> "" Then voting.Label1.Text = conf + "  " + voting.Label1.Text
        Catch ex As Exception

        End Try
        Try
            Dim loadnation As New StreamReader("DATA\NATIONLIST.edb")
            Do Until loadnation Is Nothing
                CheckedListBox1.Items.Add(loadnation.ReadLine)
            Loop
            loadnation.Close()
            loadnation.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i, k As Integer
        Do While i < CheckedListBox1.Items.Count
            If CheckedListBox1.GetItemChecked(i) = True Then
                k = k + 1
                a = a + 1
                nations(k) = CheckedListBox1.Items(i)
            End If
            i = i + 1
        Loop
        Call display(0, True)
        voting.lblpresent.Text = k
        voting.lbl50maj.Text = (k) \ 2 + 1
        voting.lbl67maj.Text = (k) * 2 \ 3 + 1
        Label2.Text = "正在进行第1轮投票" + vbCrLf + "下一国家: "
        Label4.Text = nations(1)
        b = 1
        btnyes.Enabled = True
        btnno.Enabled = True
        btnabst.Enabled = True
        btnpass.Enabled = True
        Button1.Enabled = False
        CheckedListBox1.Enabled = False
    End Sub

    Private Sub btnyes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnyes.Click
        Call vote("y")
    End Sub

    Private Sub btnno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnno.Click
        Call vote("n")
    End Sub

    Private Sub btnabst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnabst.Click
        Call vote("a")
    End Sub

    Private Sub btnpass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpass.Click
        Call vote("p")
    End Sub
End Class
