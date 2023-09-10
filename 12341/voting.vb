Public Class voting

    Dim nations(100), opini(100) As String
    Dim yes, no, abst, pnat(99) As Integer
    Dim a, b, p, q As Integer
    Dim r2 As Boolean
    Dim a1, a2 As String
    Dim maj67 As Integer
    Dim current, max, lang As Integer
    Dim vfnish(2), pass(2), fail(2), veto(2), yy(2), nn(2), aa(2), noveto(2) As String

    '首先，请原谅我原来错误的想法，因为那时的我还不够成熟，对你的好意难以接受。
    '我终于想明白了。也许我们以后注定不能在一起，但是，相遇便是缘。无论如何，我们应该珍惜这一段感情。
    '过去的事情，就让它过去；从现在起，我们还做朋友吧，最好最好的朋友。好嘛？
    '北京西站 宋子睿。2012/12/26

    Sub record(ByVal passed As Boolean)
        Dim rectxt As String
        If passed = True Then
            rectxt = vfnish(lang) + lblhcname.Text + pass(lang)
        Else
            rectxt = vfnish(lang) + lblhcname.Text + fail(lang)
        End If
        Form1.lblmain.Text = rectxt
        If lang = 1 Then
            rectxt = rectxt + vbCrLf + "出席的国家数: " + lblpresent.Text + vbCrLf + "赞成的国家数: " + lblyes.Text + vbCrLf + "反对的国家数: " + lblno.Text + vbCrLf + "弃权的国家数: " + lblabst.Text
            If CheckBox6.Checked = True Then rectxt = rectxt + vbCrLf + Label5.Text
            rectxt = rectxt + vbCrLf + "具体投票情况如下:"
            For nj = 1 To a
                rectxt = rectxt + vbCrLf + nations(nj) + "——" + opini(nj)
            Next
        Else
            rectxt = rectxt + vbCrLf + "Present: " + lblpresent.Text + vbCrLf + "Yes: " + lblyes.Text + vbCrLf + "No: " + lblno.Text + vbCrLf + "Abstain: " + lblabst.Text
            If CheckBox6.Checked = True Then rectxt = rectxt + vbCrLf + Label5.Text
            rectxt = rectxt + vbCrLf + "The specific votes as follows:"
            For nj = 1 To a
                rectxt = rectxt + vbCrLf + nations(nj) + " - " + opini(nj)
            Next
        End If
        rectxt = rectxt + vbCrLf + Label5.Text
        Form1.txthcmotion.Text = rectxt
    End Sub

    Sub fanye()
        Button5.Enabled = True
        Button6.Enabled = True
        If current = max Then Button6.Enabled = False
        If current = 0 Then Button5.Enabled = False
    End Sub

    Sub foujue()
        Dim fj As Integer
        Dim fxk() As CheckBox = New CheckBox() {CheckBox1, CheckBox2, CheckBox3, CheckBox4, CheckBox5}
        For i = 0 To 4
            If fxk(i).Checked = True Then
                fj = fj + 1
                If fj > 1 Then Label5.Text = Label5.Text + ", "
                Label5.Text = Label5.Text + fxk(i).Text
            End If
        Next
        If fj > 0 Then
            Label5.Text = Label5.Text + veto(lang)
        Else
            Label5.Text = noveto(lang)
        End If
    End Sub

    Sub display(ByVal pages As Integer, ByVal nation As Boolean)
        If nation = True Then
            lblnat1.Text = ""
            lblnat2.Text = ""
            lblnat3.Text = ""
        Else
            lblop1.Text = ""
            lblop2.Text = ""
            lblop3.Text = ""
            lblyes.Text = yes
            lblno.Text = no
            lblabst.Text = abst
        End If
        If a = 0 Then Exit Sub
        For l1 = pages * 30 + 1 To a
            If nation = True Then
                lblnat1.Text = lblnat1.Text + nations(l1) + vbCrLf
            Else
                lblop1.Text = lblop1.Text + opini(l1) + vbCrLf
            End If
            If l1 > pages * 30 + 10 Then Exit For
        Next
        If a > pages * 30 + 10 Then
            For l2 = pages * 30 + 11 To a
                If nation = True Then
                    lblnat2.Text = lblnat2.Text + nations(l2) + vbCrLf
                Else
                    lblop2.Text = lblop2.Text + opini(l2) + vbCrLf
                End If
                If l2 > pages * 30 + 20 Then Exit For
            Next
        End If
        If a > pages * 30 + 20 Then
            For l3 = pages * 30 + 21 To a
                If nation = True Then
                    lblnat3.Text = lblnat3.Text + nations(l3) + vbCrLf
                Else
                    lblop3.Text = lblop3.Text + opini(l3) + vbCrLf
                End If
                If l3 > pages * 30 + 30 Then Exit For
            Next
        End If
        '==============================
        Dim p1, p2 As String
        max = (a - 1) \ 30
        p1 = current + 1
        p2 = max + 1
        Label4.Text = "第 " + p1 + "/" + p2 + " 页"
    End Sub

    Sub vote(ByVal op As String, ByVal r2 As Boolean)
        Select Case op
            Case "y"
                If r2 = True Then
                    opini(pnat(q)) = yy(lang)
                Else
                    opini(b) = yy(lang)
                End If
                yes = yes + 1
            Case "n"
                If r2 = True Then
                    opini(pnat(q)) = nn(lang)
                Else
                    opini(b) = nn(lang)
                End If
                no = no + 1
            Case "a"
                opini(b) = aa(lang)
                abst = abst + 1
            Case "p"
                p = p + 1
                pnat(p) = b
        End Select
        If r2 = False Then
            If nations(b + 1) = "" Then
                If p = 0 Then
                    Label7.Text = "请在右侧选择行使否决权的国家" + vbCrLf + "或直接结束投票"
                    Label6.Text = ""
                    CheckBox6.Enabled = True
                    Button4.Enabled = True
                Else
                    Label7.Text = "请开启下一轮投票"
                    Label6.Text = "---"
                    Button3.Enabled = True
                End If
                Call display(b \ 30, True)
                Call display(b \ 30, False)
                btnyes.Enabled = False
                btnno.Enabled = False
                btnabst.Enabled = False
                btnpass.Enabled = False
            Else
                Call display(b \ 30, True)
                Call display(b \ 30, False)
                current = b \ 30
                b = b + 1
                Label6.Text = nations(b)
            End If
        Else
            If nations(pnat(q + 1)) = "" Then
                Label7.Text = "请在右侧选择行使否决权的国家" + vbCrLf + "或直接结束投票"
                Label6.Text = ""
                Call display(pnat(q) \ 30, True)
                Call display(pnat(q) \ 30, False)
                CheckBox6.Enabled = True
                btnyes.Enabled = False
                btnno.Enabled = False
                Button4.Enabled = True
            Else
                Call display(pnat(q) \ 30, True)
                Call display(pnat(q) \ 30, False)
                current = pnat(q) \ 30
                q = q + 1
                Label6.Text = nations(pnat(q))
            End If
        End If
        Call fanye()
    End Sub

    Private Sub voting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblnat1.Text = ""
        lblnat2.Text = ""
        lblnat3.Text = ""
        lblop1.Text = ""
        lblop2.Text = ""
        lblop3.Text = ""
        Label5.Text = ""
        Dim path As String
        If loadnsave.langload = 1 Then
            path = "lang\vote1.edl"
            CheckBox1.Text = "中国"
            CheckBox2.Text = "美国"
            CheckBox3.Text = "英国"
            CheckBox4.Text = "法国"
            CheckBox5.Text = "俄罗斯"
            Label3.Text = "出席国家数:" + vbCrLf + vbCrLf + "简单多数:" + vbCrLf + vbCrLf + "2/3多数:"
            Label2.Text = "赞成:" + vbCrLf + vbCrLf + "反对:" + vbCrLf + vbCrLf + "弃权:"
            lang = 1
        Else
            path = "lang\vote2.edl"
            lang = 2
        End If
        Dim stradd As New System.IO.StreamReader(path)
        vfnish(lang) = stradd.ReadLine()
        pass(lang) = stradd.ReadLine()
        fail(lang) = stradd.ReadLine()
        yy(lang) = stradd.ReadLine()
        nn(lang) = stradd.ReadLine()
        aa(lang) = stradd.ReadLine()
        noveto(lang) = stradd.ReadLine()
        veto(lang) = stradd.ReadLine()
        stradd.Close()
        Me.Top = 0
        Me.Left = 0
        Dim conf, comite As String
        Dim mtopic(1) As String
        Dim multi1 As Integer
        Try
            Dim loada As New System.IO.StreamReader("DATA\PRESET_WELCOME.edb")
            multi1 = loada.ReadLine
            conf = loada.ReadLine
            comite = loada.ReadLine
            mtopic(0) = loada.ReadLine
            mtopic(1) = loada.ReadLine
            loada.Close()
            loada.Dispose()
            a1 = comite + "  " + mtopic(multi1)
            a2 = "" + Form1.lblmain.Text
            If conf <> "" Then a1 = conf + "  " + a1
            Label1.Text = a1 + vbCrLf + a2
        Catch ex As Exception
        End Try
        Try
            Dim loadnation As New System.IO.StreamReader("DATA\NATIONLIST.edb")
            Do Until loadnation Is Nothing
                CheckedListBox1.Items.Add(loadnation.ReadLine)
            Loop
            loadnation.Close()
            loadnation.Dispose()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnyes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnyes.Click
        Call vote("y", r2)
    End Sub

    Private Sub btnno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnno.Click
        Call vote("n", r2)
    End Sub

    Private Sub btnabst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnabst.Click
        Call vote("a", r2)
    End Sub

    Private Sub btnpass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpass.Click
        Call vote("p", r2)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i As Integer
        Do While i < CheckedListBox1.Items.Count
            If CheckedListBox1.GetItemChecked(i) = True Then
                a = a + 1
                nations(a) = CheckedListBox1.Items(i)
            End If
            i = i + 1
        Loop
        Call display(0, True)
        Call fanye()
        lblpresent.Text = a
        lbl50maj.Text = (a) \ 2 + 1
        lbl67maj.Text = (a) * 2 \ 3 + 1
        maj67 = a
        Label7.Text = "正在进行第1轮投票" + vbCrLf + "下一国家: "
        Label6.Text = nations(1)
        b = 1
        btnyes.Enabled = True
        btnno.Enabled = True
        btnabst.Enabled = True
        btnpass.Enabled = True
        Button1.Enabled = False
        CheckedListBox1.Enabled = False
    End Sub

    Private Sub CheckBox6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox6.CheckedChanged
        Dim fxk() As CheckBox = New CheckBox() {CheckBox1, CheckBox2, CheckBox3, CheckBox4, CheckBox5}
        If CheckBox6.Checked = True Then
            For k = 0 To 4
                fxk(k).Enabled = True
            Next
        Else
            For k = 0 To 4
                fxk(k).Enabled = False
            Next
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If p > 0 Then
            Label7.Text = "正在进行第2轮投票" + vbCrLf + "下一国家: "
            Label6.Text = nations(pnat(1))
            btnyes.Enabled = True
            btnno.Enabled = True
            Button3.Enabled = False
            r2 = True
            q = 1
            Call display(0, True)
            Call display(0, False)
            Call fanye()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If Button4.Text = "关闭" Then
            Call Form1.fclose()
            Me.Close()
        Else
            Call foujue()
            Label7.Text = "投票已结束！"
            CheckBox6.Enabled = False
            Dim fxk() As CheckBox = New CheckBox() {CheckBox1, CheckBox2, CheckBox3, CheckBox4, CheckBox5}
            For k = 0 To 4
                fxk(k).Enabled = False
            Next
            If yes >= (maj67 - abst) * 2 \ 3 + 1 Then
                If Label5.Text = noveto(lang) Then
                    a2 = vfnish(lang) + lblhcname.Text + pass(lang)
                    Call record(True)
                Else
                    a2 = vfnish(lang) + lblhcname.Text + fail(lang)
                    Call record(False)
                End If
            Else
                a2 = vfnish(lang) + lblhcname.Text + fail(lang)
                Call record(False)
            End If
            Label1.Text = a1 + vbCrLf + a2
            Button4.Text = "关闭"
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        current = current - 1
        Call display(current, True)
        Call display(current, False)
        Call fanye()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        current = current + 1
        Call display(current, True)
        Call display(current, False)
        Call fanye()
    End Sub

    Private Sub btnyes_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnyes.MouseDown
        btnyes.BackColor = Color.Red
        btnyes.ForeColor = Color.White
    End Sub

    Private Sub btnyes_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnyes.MouseUp
        btnyes.BackColor = Button3.BackColor
        btnyes.ForeColor = Button3.ForeColor
    End Sub

    Private Sub btnno_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnno.MouseDown
        btnno.BackColor = Color.Blue
        btnno.ForeColor = Color.White
    End Sub

    Private Sub btnno_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnno.MouseUp
        btnno.BackColor = Button3.BackColor
        btnno.ForeColor = Button3.ForeColor
    End Sub

    Private Sub btnabst_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnabst.MouseDown
        btnabst.BackColor = Color.Yellow
    End Sub

    Private Sub btnabst_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnabst.MouseUp
        btnabst.BackColor = Button3.BackColor
    End Sub

End Class