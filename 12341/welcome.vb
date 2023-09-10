Imports System.Windows.Forms
Imports System
Imports System.IO
Imports System.Text

Public Class welcome

    Dim conf, comite As String
    Dim welcomestring As String
    Dim statusstring, mtostring As String
    Dim munnamee As Boolean
    Dim info As Boolean
    Dim mtopic(1) As String
    Dim multi1 As Integer
    Dim lang As Integer
    Dim infoString(5) As String

    Sub openedit()
        Label1.Enabled = True
        Label2.Enabled = True
        Label3.Enabled = True
        Label4.Enabled = True
        Label7.Enabled = True
        txtmunname.Enabled = True
        txtcommname.Enabled = True
        txtyiti.Enabled = True
        CheckBox1.Enabled = True
        LinkLabel1.Enabled = False
        optsc.Enabled = True
        opteng.Enabled = True
        txtmunname.Focus()
    End Sub

    Sub welcomestringmake()
        Dim lang1 As String
        If lang = 1 Then
            lang1 = "lang\info1.edl"
        Else
            lang1 = "lang\info2.edl"
        End If
        Dim tload As New System.IO.StreamReader(lang1)
        For r = 1 To 6
            infoString(r - 1) = tload.ReadLine
        Next
        tload.Close()
        comite = txtcommname.Text
        conf = txtmunname.Text
        If multi1 = 2 Then
            mtopic(0) = txtyiti.Text
            mtopic(1) = TextBox1.Text
        Else
            mtopic(multi1) = txtyiti.Text + vbCrLf
        End If
        If multi1 = 2 Then
            mtostring = infoString(0) + mtopic(0) + vbCrLf + infoString(1) + mtopic(1)
            statusstring = comite + vbCrLf + infoString(2) + txthuiqi.Text + infoString(3)
        Else
            statusstring = comite + vbCrLf + mtopic(multi1) + infoString(2) + txthuiqi.Text + infoString(3)
        End If
        If conf <> "" Then
            conf = txtmunname.Text + vbCrLf
            statusstring = conf + statusstring
        End If
        If lang = 1 Then
            welcomestring = "欢迎参加" + statusstring
        Else
            welcomestring = "Welcome to " + statusstring
        End If
    End Sub

    Sub loadpreset()
        Try
            Dim load As StreamReader = New StreamReader("DATA\PRESET_WELCOME.edb")
            multi1 = load.ReadLine
            conf = load.ReadLine
            comite = load.ReadLine
            mtopic(0) = load.ReadLine
            mtopic(1) = load.ReadLine
            load.Close()
            load.Dispose()
        Catch ex As Exception
        End Try
        txtmunname.Text = conf
        txtcommname.Text = comite
        Select Case multi1
            Case 2
                Me.Height = 243
                Label3.Text = "备选议题1"
                Label6.Visible = True
                TextBox1.Visible = True
                CheckBox1.Checked = True
                txtyiti.Text = mtopic(0)
                TextBox1.Text = mtopic(1)
            Case 1
                txtyiti.Text = mtopic(1)
            Case Else
                txtyiti.Text = mtopic(0)
        End Select
    End Sub

    Sub savepreset()
        conf = txtmunname.Text
        comite = txtcommname.Text
        mtopic(0) = txtyiti.Text
        mtopic(1) = TextBox1.Text
        Dim save As StreamWriter = New StreamWriter("DATA\PRESET_WELCOME.edb")
        save.WriteLine(multi1)
        save.WriteLine(conf)
        save.WriteLine(comite)
        save.WriteLine(mtopic(0))
        save.WriteLine(mtopic(1))
        save.Close()
        save.Dispose()
        'MsgBox("预设保存成功！", MsgBoxStyle.Information, "会议信息")
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If optsc.Checked = True Then
            lang = 1
            Form1.Label3.Text = "出席国家数:" + vbCrLf + vbCrLf + "简单多数:" + vbCrLf + vbCrLf + "2/3多数:" + vbCrLf + vbCrLf + "20%:"
            Form1.Label2.Text = "总时长"
            Form1.lblmain.Font = Form1.lblzh.Font
        Else
            lang = 2
            Form1.lblmain.Font = Form1.lblen.Font
        End If
        Call welcomestringmake()
        If comite = "" Or txthuiqi.Text = "" Then info = True
        If info = False Then
            If multi1 = 2 Then
                Form1.lblstatusmain.Text = mtostring
                Form1.lblmain.Text = welcomestring + vbCrLf + mtostring
                Form1.txtrecord.Text = Date.Today + " " + TimeOfDay + vbCrLf + statusstring + infoString(4) + vbCrLf + mtostring + vbCrLf + vbCrLf + Form1.txtrecord.Text
                Form1.Text = comite + infoString(5) + infoString(2) + txthuiqi.Text + infoString(3)
            Else
                Form1.txtrecord.Text = Date.Today + " " + TimeOfDay + vbCrLf + statusstring + infoString(4) + vbCrLf + vbCrLf + Form1.txtrecord.Text
                Form1.lblstatusmain.Text = statusstring
                Form1.lblmain.Text = welcomestring
                Form1.Text = comite + infoString(5) + txtyiti.Text + infoString(5) + infoString(2) + txthuiqi.Text + infoString(3)
            End If
            Call Form1.tstringload()
            Form1.lblhc2.Text = txthuiqi.Text

            Dim autosave As New System.IO.StreamWriter("DATA\RECORD.edb", True)
            autosave.Write(Date.Today + " " + TimeOfDay + vbCrLf + statusstring + infoString(4) + vbCrLf + mtostring + vbCrLf)
            If multi1 = 2 Then
                autosave.WriteLine("")
            End If
            autosave.Close()
            autosave.Dispose()

            Call savepreset()

            Dim ssave As New System.IO.StreamWriter("DATA\STATUS.edb")
            ssave.WriteLine(lang)
            ssave.WriteLine("True")
            ssave.WriteLine("True")
            ssave.WriteLine("False")
            ssave.WriteLine("False")
            ssave.WriteLine("False")
            ssave.WriteLine("False")
            ssave.WriteLine(txthuiqi.Text)
            ssave.Close()
            Call Form1.loadstat()
            Call Form1.stringLoad()
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("请检查所有项目是否已经填写完成！", MsgBoxStyle.Exclamation, "会议信息")
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        conf = ""
        comite = ""
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnpreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call welcomestringmake()
        Form1.lblmain.Text = welcomestring
    End Sub

    Private Sub btnclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        conf = ""
        comite = ""
        mtopic(0) = ""
        mtopic(1) = ""
        welcomestring = ""
        statusstring = ""
        munnamee = False
        txtcommname.Text = ""
        txthuiqi.Text = ""
        txtmunname.Text = ""
        txtyiti.Text = ""
        TextBox1.Text = ""
        Form1.lblmain.Text = ""
        Me.Height = 217
        CheckBox1.Checked = False
        Label3.Text = "议题"
        Label6.Visible = False
        TextBox1.Visible = False
        multi1 = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call loadpreset()
        txthuiqi.Select()
    End Sub

    Private Sub welcome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Height = 217
        Me.Top = 660 - Me.Height
        Me.Left = 32
        Call loadpreset()
        txthuiqi.Select()
        If conf = "" Then Call openedit()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Call savepreset()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            Me.Height = 243
            Label3.Text = "备选议题1"
            Label6.Visible = True
            TextBox1.Visible = True
            multi1 = 2
        Else
            Me.Height = 217
            Label3.Text = "议题"
            Label6.Visible = False
            TextBox1.Visible = False
            multi1 = 0
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Call openedit()
    End Sub

    Private Sub txtmunname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmunname.KeyPress
        If e.KeyChar = Chr(13) Then
            txtcommname.Focus()
        End If
    End Sub

    Private Sub txtcommname_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtcommname.KeyPress
        If e.KeyChar = Chr(13) Then
            txtyiti.Focus()
        End If
    End Sub

    Private Sub txtyiti_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtyiti.KeyPress
        If e.KeyChar = Chr(13) Then
            txthuiqi.Focus()
        End If
    End Sub

    Private Sub txthuiqi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txthuiqi.KeyPress
        If e.KeyChar = Chr(13) Then
            OK_Button.Focus()
        End If
    End Sub

End Class
