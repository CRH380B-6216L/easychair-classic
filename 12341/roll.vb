Imports System.Windows.Forms

Public Class roll
    Dim rec As Boolean
    Dim origin As String

    Sub collapse()
        Me.Left = 764
        Me.Width = 258
        Button23.Text = "编辑列表"
        GroupBox3.Visible = False
    End Sub

    Sub loadChecked()
        Dim loadnation As New System.IO.StreamReader("DATA\NATIONLIST.edb")
        Try
            Do Until loadnation Is Nothing
                CheckedListBox1.Items.Add(loadnation.ReadLine)
            Loop
            loadnation.Close()
        Catch ex As Exception
            loadnation.Close()
        End Try

        rec = Form1.Label7.Text
        If rec = True Then
            Button2.Text = "更新国家数"
        Else
            Button2.Text = "生成点名记录"
        End If


        Dim pload As New System.IO.StreamReader("DATA\NATIONLIST_P.edb")
        Dim p1, i As Integer
        Do While i < CheckedListBox1.Items.Count
            If pload.ReadLine = "True" Then
                CheckedListBox1.SetItemCheckState(i, CheckState.Checked)
                p1 = p1 + 1
            Else
                CheckedListBox1.SetItemCheckState(i, CheckState.Unchecked)
            End If
            i = i + 1
        Loop
        pload.Close()
        Call pcalc(p1)
    End Sub

    Sub save()
        Dim sav As New System.IO.StreamWriter("DATA\NATIONLIST.edb")
        sav.Write(TextBox2.Text)
        sav.Close()
        sav.Dispose()
        Dim sav1 As New System.IO.StreamWriter("DATA\NATIONLIST_P.edb")
        sav1.Write("")
        sav1.Close()
        sav1.Dispose()
        Timer1.Enabled = True
        CheckedListBox1.Items.Clear()
        Form1.Label7.Text = "False"
        Call loadChecked()
        Call collapse()
    End Sub

    Sub pcalc(ByVal p As Integer)
        If p = 0 Then
            lblpresent.Text = 0
            lbl20maj.Text = 0
            lbl50maj.Text = 0
            lbl67maj.Text = 0
            Form1.lblpresent.Text = 0
            Form1.lbl20maj.Text = 0
            Form1.lbl50maj.Text = 0
            Form1.lbl67maj.Text = 0
        Else
            lblpresent.Text = p
            lbl20maj.Text = (p) \ 5
            lbl50maj.Text = (p) \ 2 + 1
            lbl67maj.Text = (p) * 2 \ 3
            Form1.lblpresent.Text = p
            Form1.lbl20maj.Text = (p) \ 5
            Form1.lbl50maj.Text = (p) \ 2 + 1
            Form1.lbl67maj.Text = (p) * 2 \ 3
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub roll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 5
        Me.Left = 764
        Me.Width = 258

        If loadnsave.langload = 1 Then
            Label3.Text = "出席国家数:" + vbCrLf + vbCrLf + "简单多数:" + vbCrLf + vbCrLf + "2/3多数:" + vbCrLf + vbCrLf + "20%:"
        Else
            Label3.Text = "Presents:" + vbCrLf + vbCrLf + "Simple Majority:" + vbCrLf + vbCrLf + "2/3 Majority:" + vbCrLf + vbCrLf + "20%:"
        End If

        Call loadChecked()
    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.GotFocus
        If TextBox1.Text = "按Enter键确认添加" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.LostFocus
        If TextBox1.Text = "" Then
            TextBox1.Text = "按Enter键确认添加"
            TextBox1.ForeColor = Color.FromArgb(255, 200, 200, 200)
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim aq = 0
            If TextBox1.Text <> "" Then
                CheckedListBox1.Items.Add(TextBox1.Text)
                Dim add As New System.IO.StreamWriter("DATA\NATIONLIST.edb")
                Do While aq < CheckedListBox1.Items.Count
                    add.WriteLine(CheckedListBox1.GetItemText(CheckedListBox1.Items(aq)))
                    aq = aq + 1
                Loop
                add.Close()
                TextBox1.Text = ""
                TextBox1.Select()
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim report As String
        Dim n As Integer
        Dim psave As New System.IO.StreamWriter("DATA\NATIONLIST_P.edb")
        Do While n < CheckedListBox1.Items.Count
            psave.WriteLine(CheckedListBox1.GetItemChecked(n))
            n = n + 1
        Loop
        psave.Close()
        If rec = False Then
            If loadnsave.langload = 1 Then
                report = "本次会议实际有" + lblpresent.Text + "国家出席" + vbCrLf + "简单多数为" + lbl50maj.Text + vbCrLf + "三分之二多数为" + lbl67maj.Text + vbCrLf + "20%国家数为" + lbl20maj.Text
            Else
                report = "" + lblpresent.Text + " nations present in the conference" + vbCrLf + "Simple majority: " + lbl50maj.Text + vbCrLf + "2/3 majority: " + lbl67maj.Text + vbCrLf + "20% count of nations: " + lbl20maj.Text
            End If
            Form1.txthcmotion.Text = report
            Form1.lblmain.Text = report
            rec = True
            Form1.Label7.Text = rec
            Button2.Text = "更新国家数"
            Me.Close()
        End If
    End Sub

    Private Sub CheckedListBox1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles CheckedListBox1.DragDrop

    End Sub

    Private Sub CheckedListBox1_itemcheck(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.ItemCheck
        Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim i, k As Integer
        i = 0
        k = 0
        Do While i < CheckedListBox1.Items.Count
            If CheckedListBox1.GetItemChecked(i) = True Then
                k = k + 1
            End If
            i = i + 1
        Loop
        Call pcalc(k)
        Timer1.Enabled = False
    End Sub

    Private Sub CheckedListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckedListBox1.SelectedIndexChanged

    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        If Button23.Text = "收起" Then
            Call collapse()
        Else
            Me.Left = 527
            Me.Width = 495
            Button23.Text = "收起"
            GroupBox3.Visible = True
            Dim load As New System.IO.StreamReader("DATA\NATIONLIST.edb")
            origin = load.ReadToEnd
            load.Close()
            load.Dispose()
            TextBox2.Text = origin
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Call save()
        origin = TextBox2.Text
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        TextBox2.Text = origin
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MsgBox("确实要清空列表吗？", 48 + 4, "编辑国家列表") = 6 Then
            TextBox2.Text = ""
            Call save()
            origin = TextBox2.Text
        End If
    End Sub
End Class
