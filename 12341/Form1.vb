
Option Explicit On
Imports EasyChairNew.loadnsave

Public Class Form1
    '定义状态变量:
    Dim started As Boolean
    Dim session, formTitle As String
    Dim kzta, rec, speakera, mca, votea, isCabinet As Boolean
    Dim lang As Integer
    '定义计时器变量:
    Dim k, kminute, ksecond As Integer
    Dim i, iminute, isecond, ilimit As Integer
    Dim countrunning, manual, maohao As Boolean
    Dim line1 As String
    Dim timer(9) As String
    Dim cabinTime As Date, rate, rawrate As Integer
    Dim x() As Integer = {1, 2, 3, 5, 10, 20, 30, 60, 120, 180, 360, 720, 1440}
    '定义MC使用变量:
    Dim nations(30) As String, spoken(30) As Boolean
    Dim a, b, all, add As Integer
    Dim full As Boolean
    Dim nationstr As String
    Dim zj, added As Boolean
    Dim mcmode As Integer
    '
    Dim yieldText As String
    Dim yieldString(5) As String
    Dim isYield As Boolean

    '长期以来，农业是非洲经济的重要部门。然而，由于长年受殖民统治，以及多数地区的耕作方式和技术的落后，非洲的农业生产水平一直非常低下，80%的国家和地区粮食不能自给。这使得非洲陷入了严重的饥饿威胁之中。
    '由于目前粮食作物需求增速迅猛且快于其供应增速，近年来全球粮食价格上涨迅速。非洲解决饥饿问题的主要方式是接受国际粮食援助，但是在粮价居高不下的情况下，购买紧急援助粮食的价格提高了，这对于饥饿问题严重的非洲来说无疑是雪上加霜。
    '近几年来，为了减少对化石燃料的依赖、缓解高油价对本国经济的压力，并增加财政收入以发展农业，一些非洲国家已经开始或正在酝酿本国的生物能源项目。然而，将粮食作物大量用于生物能源的生产可能会造成非洲主要粮食价格的进一步上涨，这将不利于非洲饥饿问题的消除。

    Sub timeDisp()
        Dim mina, seca, timeleft As String
        kminute = k \ 60
        ksecond = k Mod 60
        iminute = i \ 60
        isecond = i Mod 60
        '============================
        timeleft = ""
        mina = iminute
        seca = isecond
        If iminute < 10 Then
            timeleft = "0"
        Else
            timeleft = ""
        End If
        timeleft = timeleft + mina + ":"
        If isecond < 10 Then timeleft = timeleft + "0"
        timeleft = timeleft + seca
        '============================
        If i <= ilimit Then
            lblcount.ForeColor = Color.Red
        Else
            lblcount.ForeColor = Color.Black
        End If
        lblcount.Text = timeleft
    End Sub

    Sub stringLoad()
        Call tstringload()
        Call ystringload()
    End Sub

    Sub sperkerClose()
        countrunning = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Button17.Enabled = True
        Button18.Enabled = True
        numtime.Enabled = True
        Button17.Text = "开始"
        '=======================
        speaker.Button1.Enabled = True
        speaker.Button4.Enabled = True
        speaker.Button2.Enabled = True
        speaker.TextBox2.Enabled = True
        speaker.Button2.Text = "开始"
        lblcount.Text = ""
    End Sub

    Sub writeRecord(ByVal neiRong As String)
        txtrecord.Text = TimeOfDay + vbCrLf + neiRong + vbCrLf + vbCrLf + txtrecord.Text
        Dim autosave As New System.IO.StreamWriter("DATA\RECORD.edb", True)
        autosave.Write(TimeOfDay + vbCrLf + neiRong + vbCrLf + vbCrLf)
        autosave.Close()
        autosave.Dispose()
    End Sub

    Sub ystringload()
        Dim lang1 As String
        If loadnsave.langload = 1 Then
            lang1 = "lang\yield1.edl"
        Else
            lang1 = "lang\yield2.edl"
        End If
        Dim tload As New System.IO.StreamReader(lang1)
        For r = 1 To 6
            yieldString(r - 1) = tload.ReadLine
        Next
        tload.Close()
    End Sub

    Sub yieldAct(ByVal type As Integer, ByVal start As Boolean)
        isYield = True
        If start = True Then
            Select Case type
                Case 1
                    yieldText = yieldString(0) + yield.TextBox1.Text
                    If loadnsave.langload = 1 Then
                        yieldText = yieldText + "代表"
                    End If
                    txthcmotion.Text = txthcmotion.Text + vbCrLf + yieldText
                Case 2
                    yieldText = yieldString(1) + vbCrLf + yieldString(2) + yield.TextBox1.Text
                    txthcmotion.Text = txthcmotion.Text + vbCrLf + yieldText
                Case 3
                    yieldText = yieldString(3) + vbCrLf + yieldString(4) + yield.TextBox1.Text
                    txthcmotion.Text = txthcmotion.Text + vbCrLf + yieldText
            End Select
            Call writeRecord(yieldText)
            Call speaker.timerContinue()
        Else
            Call sperkerClose()
            Call speaker.speaknext()
            If type = 4 Then
                lblmain.Text = txthcmotion.Text + vbCrLf + yieldString(5)
            Else
                If lang = 1 Then
                    lblmain.Text = txthcmotion.Text + vbCrLf + "让渡发言结束"
                Else
                    lblmain.Text = txthcmotion.Text + vbCrLf + "Yield-time Speech Finished"
                End If
            End If
            isYield = False
        End If
    End Sub

    Sub countstart()
        If lblhc1.Text = "" Then
            k = numtime.Value
            i = numtime.Value
            countrunning = True
            Timer2.Enabled = True
            Timer3.Enabled = True
            Button17.Text = "暂停"
            manual = True
            numtime.Enabled = False
        End If
        Call timeDisp()
        maohao = False
        lblmaohao.Visible = False
        Timer3.Enabled = True
    End Sub

    Sub cabinsave()
        Dim csave As New System.IO.StreamWriter("DATA\clock.edb")
        csave.WriteLine(isCabinet)
        csave.WriteLine(cabinTime)
        csave.WriteLine(rawrate)
        csave.Close()
    End Sub

    Sub cabingo()
        Dim cload As New System.IO.StreamReader("DATA\clock.edb")
        isCabinet = cload.ReadLine
        cabinTime = cload.ReadLine
        rawrate = cload.ReadLine
        rate = x(rawrate)
        cload.Close()
        Me.Text = formTitle
        If loadnsave.langload = 1 Then
            If isCabinet = True Then Me.Text = Me.Text + "  内阁时钟已启动"
        Else
            If isCabinet = True Then Me.Text = Me.Text + " [Cabinet Clock Enabled]"
        End If
    End Sub

    Sub tstringload()
        Dim lang1 As String
        If loadnsave.langload = 1 Then
            lang1 = "lang\timer1.edl"
        Else
            lang1 = "lang\timer2.edl"
        End If
        Dim tload As New System.IO.StreamReader(lang1)
        For r = 1 To 10
            timer(r - 1) = tload.ReadLine
        Next
        tload.Close()
    End Sub

    Sub nationadd(ByVal mc As Boolean)
        If mc = True Then
            Dim a1, a2 As Integer
            a1 = a + 1
            If TextBox2.Text = "" Then
            Else
                a = a1
                TextBox5.Text = a1 + 1
                nations(a) = TextBox2.Text
                Call nationlist()
                TextBox2.Focus()
                If a >= all Then
                    TextBox2.Text = ""
                    Label6.Text = "请开始发言"
                    TextBox2.Enabled = False
                    Button26.Enabled = False
                    Button25.Enabled = True
                    Button25.Focus()
                    TextBox3.Text = b
                    TextBox4.Text = nations(b)
                Else
                    If zj = True Then
                        b = b + 1
                        TextBox3.Text = b
                        TextBox4.Text = nations(b)
                        zj = False
                    End If
                    If a = 1 Then
                        Button25.Enabled = True
                        TextBox3.Text = a
                        TextBox4.Text = nations(1)
                        b = 1
                    End If
                    TextBox2.Text = ""
                    a2 = all - a
                    Label6.Text = a2
                    Label6.Text = "还可继续添加" + Label6.Text + "个国家"
                    TextBox2.Select()
                End If
            End If
        Else
        End If
    End Sub

    Sub lbltimerdisp(ByVal mh As Boolean)
        Dim mina, seca, timeleft As String
        mina = ""
        If iminute < 10 Then
            timeleft = "0"
        Else
            timeleft = ""
        End If
        mina = iminute
        timeleft = timeleft + mina
        If mh = True Then
            lblmaohao.Visible = False
        Else
            lblmaohao.Visible = True
        End If
        seca = isecond
        If isecond < 10 Then
            timeleft = timeleft + ":0" + seca
        Else
            timeleft = timeleft + ":" + seca
        End If
        lblcount.Text = timeleft
    End Sub

    Sub susp()
        started = False
        rec = False
        isCabinet = False
        Label7.Text = rec
        Call cabinsave()
        Me.Text = formTitle
    End Sub

    Sub loadstat()
        Dim conf, comite, topic As String
        Dim multi1 As Integer
        Dim mtopic(1) As String
        Call cabingo()
        Dim sload As New System.IO.StreamReader("DATA\STATUS.edb")
        Try
            lang = sload.ReadLine
            started = sload.ReadLine
            kzta = sload.ReadLine
            rec = sload.ReadLine
            speakera = sload.ReadLine
            mca = sload.ReadLine
            votea = sload.ReadLine
            If started = True Then
                session = sload.ReadLine()
                Dim aa As New System.IO.StreamReader("DATA\PRESET_WELCOME.edb")
                multi1 = aa.ReadLine
                conf = aa.ReadLine
                comite = aa.ReadLine
                mtopic(0) = aa.ReadLine
                mtopic(1) = aa.ReadLine
                If lang = 1 Then
                    Select Case multi1
                        Case 2
                            Me.Text = comite + "  第" + session + "会期"
                            lblstatusmain.Text = "备选议题1: " + mtopic(0) + vbCrLf + "备选议题2: " + mtopic(1)
                        Case Else
                            topic = mtopic(multi1)
                            Me.Text = comite + "  " + topic + "  第" + session + "会期"
                            lblstatusmain.Text = comite + vbCrLf + mtopic(multi1) + vbCrLf + "第" + session + "会期"
                            If conf <> "" Then lblstatusmain.Text = conf + vbCrLf + lblstatusmain.Text
                    End Select
                    formTitle = Me.Text
                    If isCabinet = True Then Me.Text = Me.Text + "  内阁时钟已启动"
                Else
                    Select Case multi1
                        Case 2
                            Me.Text = comite + "Session " + session
                            lblstatusmain.Text = "Topic 1: " + mtopic(0) + vbCrLf + "Topic 2: " + mtopic(1)
                        Case Else
                            topic = mtopic(multi1)
                            Me.Text = comite + " - " + topic + " - Session" + session
                            lblstatusmain.Text = comite + vbCrLf + mtopic(multi1) + vbCrLf + "Session " + session
                            If conf <> "" Then lblstatusmain.Text = conf + vbCrLf + lblstatusmain.Text
                    End Select
                    formTitle = Me.Text
                    If isCabinet = True Then Me.Text = Me.Text + " [Cabinet Clock Enabled]"
                End If
                aa.Close()
            End If
            sload.Close()
        Catch ex As Exception
            sload.Close()
        End Try
        Label7.Text = rec
        NotifyIcon1.Text = Me.Text
        lblhc2.Text = session
    End Sub

    Sub writestat()
        rec = Label7.Text
        Dim ssave As New System.IO.StreamWriter("DATA\STATUS.edb")
        ssave.WriteLine(lang)       '工作语言
        ssave.WriteLine(started)    '会议是否开始
        ssave.WriteLine(kzta)       '控制台是否可使用
        ssave.WriteLine(rec)        '点名是否完成
        ssave.WriteLine(speakera)   '主发言名单窗体是否开启
        ssave.WriteLine(mca)        '是否正在进行MC
        ssave.WriteLine(votea)      '投票窗体是否打开
        ssave.WriteLine(session)    '会期
        ssave.Close()
    End Sub

    Sub fclose()
        speakera = False
        votea = False
        PictureBox1.Visible = False
        PictureBox1.Dispose()
        Call kztctrl(True)
    End Sub

    Sub kztctrl(ByVal enab As Boolean)
        If enab = True Then
            GroupBox3.Enabled = True
            kzta = True
        Else
            GroupBox3.Enabled = False
            kzta = False
        End If
        Call writestat()
    End Sub

    Sub pcalc(ByVal p As Integer)
        If p = 0 Then Exit Sub
        lblpresent.Text = p
        lbl20maj.Text = (p) \ 5 + 1
        lbl50maj.Text = (p) \ 2 + 1
        lbl67maj.Text = (p) * 2 \ 3 + 1
    End Sub

    Sub speakergo()
        k = numtime.Value
        i = numtime.Value
        countrunning = True
        Timer2.Enabled = True
        Timer3.Enabled = True
        Button17.Enabled = False
        Button18.Enabled = False
        '=======================
        speaker.Button1.Enabled = False
        speaker.Button4.Enabled = False
        speaker.TextBox2.Enabled = False
    End Sub

    Sub speakerend(ByVal timeout As Boolean)
        Call sperkerClose()
        If timeout = False Then
            If lang = 1 Then
                lblmain.Text = txthcmotion.Text + vbCrLf + "发言结束"
            Else
                lblmain.Text = txthcmotion.Text + vbCrLf + "Speech Finished"
            End If
            lblcount.Text = ""
        Else
            Call speaker.speaknext()
        End If
    End Sub

    Sub mcend()
        Dim nationstri As String
        nationstri = ""
        Button25.Enabled = False
        Button24.Enabled = False
        TextBox2.Enabled = False
        Button26.Enabled = False
        Button29.Enabled = False
        Button27.Enabled = False
        Button28.Enabled = False
        Button17.Enabled = True
        Button18.Enabled = True
        numtime.Enabled = True
        lblnat1.Visible = False
        lblnat2.Visible = False
        lblnat3.Visible = False
        lblmain.Height = 541
        '=======================
        For c = 1 To a
            nationstri = nationstri + nations(c) + vbCrLf
            nations(c) = ""
            spoken(c) = False
        Next
        Dim mclear As New System.IO.StreamWriter("DATA\CURRENT_NATIONS.edb")
        mclear.Write("")
        mclear.Close()
        nationstr = nationstr + nationstri
        TextBox3.Text = "0"
        TextBox4.Text = ""
        TextBox5.Text = "1"
        lblhc1.Text = ""
        lblnat1.Text = ""
        lblnat2.Text = ""
        lblcount.Text = ""
        Label6.Text = "未进入有主持核心磋商"
        k = 0
        txthcmotion.Text = nationstr
        Call kztctrl(True)
    End Sub

    Sub mcnext()
        spoken(b) = True
        Call nationlist()
        Button24.Enabled = False
        countrunning = False
        Timer2.Enabled = False
        Timer3.Enabled = False
        Button17.Text = "开始"
        If b >= a Then
            If k >= 60 And mcmode = 0 Then
                Button29.Enabled = True
                Button28.Enabled = True
                Button29.Focus()
                zj = True
                added = True
                add = k \ numtime.Value
                Label6.Text = add
                Label6.Text = "可向列表追加" + Label6.Text + "个国家"
            Else
                Button27.Enabled = True
                Button27.Focus()
                Label6.Text = "点击" + Chr(34) + "结束" + Chr(34) + "以完成本轮发言"
            End If
            If k < 60 Then
            Else
            End If
        Else
            b = b + 1
            TextBox3.Text = b
            TextBox4.Text = nations(b)
            Button25.Enabled = True
            Button25.Focus()
        End If
    End Sub

    Sub mcready(ByVal mode As Integer)
        mcmode = mode
        mca = True
        TextBox2.Enabled = True
        Button26.Enabled = True
        Button18.Enabled = False
        lblnat1.Visible = True
        lblnat2.Visible = True
        lblnat3.Visible = True
        Button17.Enabled = False
        lblmain.Height = 474
        Call line1add()
        Call kztctrl(False)
        '=============
        all = k / i
        Label6.Text = all
        Label6.Text = "最多有" + Label6.Text + "个国家可加入发言列表"
        TextBox2.Focus()
        a = 0
        b = 0
    End Sub

    Sub nationlist()
        lblnat1.Text = ""
        lblnat2.Text = ""
        lblnat3.Text = ""
        For l1 = 1 To a
            If spoken(l1) = True Then
                lblnat1.Text = lblnat1.Text + "× " + nations(l1) + vbCrLf
            Else
                lblnat1.Text = lblnat1.Text + "¤ " + nations(l1) + vbCrLf
            End If
            If a > 8 Then
                lblnat1.Font = lblnat2.Font
            Else
                lblnat1.Font = lblmain.Font
            End If
            If l1 > 10 Then Exit For
        Next
        If a > 10 Then
            For l2 = 11 To a
                If spoken(l2) = True Then
                    lblnat2.Text = lblnat2.Text + "× " + nations(l2) + vbCrLf
                Else
                    lblnat2.Text = lblnat2.Text + "¤ " + nations(l2) + vbCrLf
                End If
                If l2 > 20 Then Exit For
            Next
        End If
        If a > 20 Then
            For l3 = 21 To a
                If spoken(l3) = True Then
                    lblnat3.Text = lblnat3.Text + "× " + nations(l3) + vbCrLf
                Else
                    lblnat3.Text = lblnat3.Text + "¤ " + nations(l3) + vbCrLf
                End If
            Next
        End If
    End Sub

    Sub line1add()
        Select Case lblhc1.Text
            Case "FI"
                If loadnsave.langload = 1 Then
                    line1 = "请" + txthcmotion.Text
                Else
                    line1 = "Please " + txthcmotion.Text
                End If
            Case Else
                line1 = txthcmotion.Text
        End Select
    End Sub

    Sub timeract()
        Dim line2 As String
        Call line1add()
        line2 = ""
        If k = 0 Then
            Select Case lblhc1.Text
                Case "TP"
                    line2 = timer(0)
                    ilimit = 20
                Case "MC"
                    line2 = timer(1)
                    ilimit = 20
                Case "CR"
                    line2 = timer(2)
                    ilimit = 30
                Case "FI"
                    line2 = timer(2)
                    ilimit = 30
                Case "FS"
                    line2 = timer(3)
                    ilimit = 30
                Case "SL"
                    line2 = timer(4)
                    Call speakerend(True)
                    ilimit = 20
                Case "TB"
                    line2 = timer(5)
                    ilimit = 60
                Case "UMC"
                    line2 = timer(5)
                    ilimit = 60
                Case Else
                    ilimit = 20
            End Select
            lblhc1.Text = ""
        ElseIf k < 60 Then
            line2 = timer(6) + Str(ksecond) + timer(8)
        Else
            line2 = timer(6) + Str(kminute) + timer(7) + Str(ksecond) + timer(8)
        End If
        If i = 0 And lblhc1.Text = "MC" Then Call mcnext()
        lblmain.Text = line1 + vbCrLf + line2
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If isCabinet = True Then
            cabinTime = cabinTime.AddMilliseconds(rate * 50)
            lbltime.Text = cabinTime
        Else
            lbltime.Text = Date.Today + " " + TimeOfDay
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        PictureBox1.Visible = True
        PictureBox1.Image = Image.FromFile("DATA\aboutimg.edb")
        AboutBox1.Show()
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        welcome.Show()
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        teabreak.Show()
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        If Button17.Text = "开始" Then
            Call countstart()
        ElseIf Button17.Text = "暂停" Then
            Timer2.Enabled = False
            Timer3.Enabled = False
            maohao = False
            lblmaohao.Visible = False
            Button17.Text = "继续"
            If lblhc1.Text <> "" Then
                lblmain.Text = lblmain.Text + " - " + timer(9)
            End If
            lblcount.ForeColor = Color.Blue
        Else
            Timer2.Enabled = True
            Timer3.Enabled = True
            Button17.Text = "暂停"
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Select Case lblhc1.Text
            Case "TP"
                ilimit = 20
            Case "MC"
                ilimit = 20
            Case "CR"
                ilimit = 30
            Case "FI"
                ilimit = 30
            Case "FS"
                ilimit = 30
            Case "SL"
                ilimit = 20
            Case "TB"
                ilimit = 60
            Case "UMC"
                ilimit = 60
            Case Else
                ilimit = 20
        End Select
        '============================
        If k = 0 Or i = 0 Then
        Else
            countrunning = True
            Button17.Text = "暂停"
            k = k - 1
            i = i - 1
            kminute = k \ 60
            ksecond = k Mod 60
            iminute = i \ 60
            isecond = i Mod 60
        End If
        Call timeDisp()
        '============================
        If i <= ilimit Then
            lblcount.ForeColor = Color.Red
        Else
            lblcount.ForeColor = Color.Black
        End If
        '============================
        Select Case i
            Case 0
                Try
                    Dim play As New System.Media.SoundPlayer("SOUNDS\timenotify.wav")
                    play.Play()
                    play.Dispose()
                Catch ex As Exception

                End Try
                Timer2.Enabled = False
                Timer3.Enabled = False
                lblmaohao.Visible = False
                countrunning = False
                If isYield = True Then yield.Close()
                isYield = False
                If lblhc1.Text <> "MC" Then numtime.Enabled = True
                Button17.Text = "开始"
                speaker.Button2.Enabled = False
                speaker.Button3.Enabled = True
            Case ilimit
                Try
                    Dim play As New System.Media.SoundPlayer("SOUNDS\20notify.wav")
                    play.Play()
                    play.Dispose()
                Catch ex As Exception

                End Try
        End Select
        maohao = True
        Timer3.Enabled = True
        If manual = False Then Call timeract()
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Timer2.Enabled = False
        Timer3.Enabled = False
        countrunning = False
        numtime.Enabled = True
        lblcount.ForeColor = Color.Black
        k = 0
        i = 0
        lblcount.Text = ""
        lblhc1.Text = ""
        Button17.Text = "开始"
        manual = False
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Call writestat()
        Call cabinsave()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        Me.Left = 0
        PictureBox1.Width = 1026
        PictureBox1.Height = 736
        GroupBox6.Top = 213
        GroupBox6.Height = 300
        lblhc1.Text = ""
        Dim mtopic(1) As String
        lblmain.Height = 541
        '读取程序状态
        '======================================
        Call loadstat()
        If lang = 1 Then
            Label3.Text = "出席国家数:" + vbCrLf + vbCrLf + "简单多数:" + vbCrLf + vbCrLf + "2/3多数:" + vbCrLf + vbCrLf + "20%:"
            lblmain.Font = lblzh.Font
        Else
            Label3.Text = "Presents:" + vbCrLf + vbCrLf + "Simple Majority:" + vbCrLf + vbCrLf + "2/3 Majority:" + vbCrLf + vbCrLf + "20%:"
            lblmain.Font = lblen.Font
        End If

        '读取工作语言
        '======================================
        Call stringLoad()
        SplashScreen1.Close()
    End Sub

    Private Sub txthci_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthci.TextChanged
        i = Val(txthci.Text)
    End Sub

    Private Sub txthck_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthck.TextChanged
        k = Val(txthck.Text) * 60
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        umc.Show()
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        suspend.Show()
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call nationadd(False)
    End Sub


    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        speaker.Show()
        Call kztctrl(False)
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        Call mcnext()
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        i = numtime.Value
        Label6.Text = "停止发言请点击" + Chr(34) + "下一个" + Chr(34)
        countrunning = True
        Timer2.Enabled = True
        Timer3.Enabled = True
        Button17.Text = "暂停"
        Button25.Enabled = False
        Button24.Enabled = True
        TextBox2.Enabled = False
        Button26.Enabled = False
        Button24.Focus()
        Call timeDisp()
    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        mc.Show()
    End Sub

    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        all = a + add
        Button29.Enabled = False
        TextBox2.Enabled = True
        Button26.Enabled = True
        Button25.Enabled = True
        Button28.Enabled = False
        TextBox5.Text = a + 1
        TextBox2.Focus()
    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        Select Case mcmode
            Case 0
                lblmain.Text = txthcmotion.Text + vbCrLf + "本轮动议结束"
                nationstr = "本轮动议结束, 参加发言的国家有: " + vbCrLf
            Case 1
                lblmain.Text = txthcmotion.Text + vbCrLf + "议题辩论结束"
                nationstr = "议题辩论结束, 参加发言的国家有: " + vbCrLf
            Case 2
                lblmain.Text = txthcmotion.Text + vbCrLf + "文件介绍环节结束，现在请出关于文件的3个问题或语法错误"
                nationstr = "文件介绍环节结束, 参加发言的国家有: " + vbCrLf
        End Select
        Call mcend()
    End Sub

    Private Sub txthcmotion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txthcmotion.TextChanged
        If isYield = False Then
            If txthcmotion.Text <> "" Then
                Call writeRecord(txthcmotion.Text)
            End If
        End If
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        custom.Show()
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        crisis.Show()
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        award.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        filesvb.Show()
    End Sub

    Private Sub txtrecord_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrecord.TextChanged

    End Sub

    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        Call nationadd(True)
    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        If lang = 1 Then
            lblmain.Text = txthcmotion.Text + vbCrLf + "本轮动议提前结束"
            nationstr = "本轮动议提前结束, 参加发言的国家有: " + vbCrLf
        Else
            lblmain.Text = txthcmotion.Text + vbCrLf + "Motion Expired"
            nationstr = "Motion expired, nations came up speech: " + vbCrLf
        End If

        Call mcend()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        enddeb.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        votego.Show()
    End Sub

    Private Sub Button31_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        txtrecord.Text = ""
    End Sub

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        recview.Show()
    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
        topicsel.Show()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        SaveFileDialog1.Title = "保存数据"
        SaveFileDialog1.OverwritePrompt = True
        If SaveFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            Call loadnsave.savefile(SaveFileDialog1.FileName)
            If lang = 1 Then
                lblmain.Text = "会议数据已保存至" + SaveFileDialog1.FileName
            Else
                lblmain.Text = "Conference data file saved to " + SaveFileDialog1.FileName
            End If
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        clear.Show()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        OpenFileDialog1.Title = "读取数据"
        If OpenFileDialog1.ShowDialog() <> Windows.Forms.DialogResult.Cancel Then
            If loadnsave.loadfile(OpenFileDialog1.FileName) = 0 Then
                If lang = 1 Then
                    lblmain.Text = "成功读取会议数据文件" + vbCrLf + OpenFileDialog1.FileName + vbCrLf + "请重启程序以继续"
                Else
                    lblmain.Text = "Successfully loaded conference data file " + vbCrLf + OpenFileDialog1.FileName + vbCrLf + "Please restart application to continue"
                End If
                MsgBox("成功读取会议数据文件" + vbCrLf + OpenFileDialog1.FileName + vbCrLf + "请重新启动程序。", 64, "初始化")
                End
            End If
        End If
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim dizhi As String
        dizhi = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\powerpnt.exe\", "", "")
        Shell(dizhi + " /O .\EasyChair 用户指引.ppt", AppWinStyle.NormalFocus)
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        If maohao = True Then
            lblmaohao.Visible = False
            maohao = False
        Else
            lblmaohao.Visible = True
            maohao = True
        End If
        If i = 0 Then Timer3.Enabled = False
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            Call nationadd(False)
        End If
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Call nationadd(True)
        End If
    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        roll.Show()
    End Sub

    Private Sub lbltime_doubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbltime.DoubleClick
        Call cabinsave()
        cabinet.Show()
    End Sub

    Private Sub numtime_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles numtime.KeyPress
        If e.KeyChar = Chr(13) Then
            Call countstart()
        End If
    End Sub

    Private Sub lblmain_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblmain.DoubleClick
        lblmain.Text = ""
    End Sub
End Class
