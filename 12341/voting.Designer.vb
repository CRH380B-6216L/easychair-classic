<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class voting
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lbl67maj = New System.Windows.Forms.Label()
        Me.lbl50maj = New System.Windows.Forms.Label()
        Me.lblpresent = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblno = New System.Windows.Forms.Label()
        Me.lblabst = New System.Windows.Forms.Label()
        Me.lblyes = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblnat1 = New System.Windows.Forms.Label()
        Me.lblop1 = New System.Windows.Forms.Label()
        Me.lblnat3 = New System.Windows.Forms.Label()
        Me.lblop3 = New System.Windows.Forms.Label()
        Me.lblnat2 = New System.Windows.Forms.Label()
        Me.lblop2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnpass = New System.Windows.Forms.Button()
        Me.btnabst = New System.Windows.Forms.Button()
        Me.btnno = New System.Windows.Forms.Button()
        Me.btnyes = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblhcname = New System.Windows.Forms.Label()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lbl67maj
        '
        Me.lbl67maj.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lbl67maj.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl67maj.Location = New System.Drawing.Point(90, 97)
        Me.lbl67maj.Name = "lbl67maj"
        Me.lbl67maj.Size = New System.Drawing.Size(77, 30)
        Me.lbl67maj.TabIndex = 9
        Me.lbl67maj.Text = "0"
        Me.lbl67maj.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbl50maj
        '
        Me.lbl50maj.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lbl50maj.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbl50maj.Location = New System.Drawing.Point(97, 54)
        Me.lbl50maj.Name = "lbl50maj"
        Me.lbl50maj.Size = New System.Drawing.Size(70, 30)
        Me.lbl50maj.TabIndex = 8
        Me.lbl50maj.Text = "0"
        Me.lbl50maj.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblpresent
        '
        Me.lblpresent.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lblpresent.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblpresent.Location = New System.Drawing.Point(97, 12)
        Me.lblpresent.Name = "lblpresent"
        Me.lblpresent.Size = New System.Drawing.Size(70, 30)
        Me.lblpresent.TabIndex = 7
        Me.lblpresent.Text = "0"
        Me.lblpresent.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(9, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 105)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Present:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Simple:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2/3:"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.lblno)
        Me.GroupBox3.Controls.Add(Me.lblabst)
        Me.GroupBox3.Controls.Add(Me.lbl50maj)
        Me.GroupBox3.Controls.Add(Me.lblyes)
        Me.GroupBox3.Controls.Add(Me.lbl67maj)
        Me.GroupBox3.Controls.Add(Me.lblpresent)
        Me.GroupBox3.Location = New System.Drawing.Point(681, 543)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(317, 143)
        Me.GroupBox3.TabIndex = 15
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "国家数"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(173, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 105)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Yes:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "No:" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Abst.:"
        '
        'lblno
        '
        Me.lblno.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblno.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lblno.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblno.Location = New System.Drawing.Point(224, 54)
        Me.lblno.Name = "lblno"
        Me.lblno.Size = New System.Drawing.Size(74, 30)
        Me.lblno.TabIndex = 8
        Me.lblno.Text = "0"
        Me.lblno.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblabst
        '
        Me.lblabst.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblabst.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lblabst.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblabst.Location = New System.Drawing.Point(224, 97)
        Me.lblabst.Name = "lblabst"
        Me.lblabst.Size = New System.Drawing.Size(74, 30)
        Me.lblabst.TabIndex = 9
        Me.lblabst.Text = "0"
        Me.lblabst.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblyes
        '
        Me.lblyes.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblyes.Font = New System.Drawing.Font("Segoe UI", 20.0!)
        Me.lblyes.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblyes.Location = New System.Drawing.Point(224, 12)
        Me.lblyes.Name = "lblyes"
        Me.lblyes.Size = New System.Drawing.Size(74, 30)
        Me.lblyes.TabIndex = 7
        Me.lblyes.Text = "0"
        Me.lblyes.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(986, 97)
        Me.Label1.TabIndex = 16
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblnat1
        '
        Me.lblnat1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnat1.Location = New System.Drawing.Point(14, 106)
        Me.lblnat1.Name = "lblnat1"
        Me.lblnat1.Size = New System.Drawing.Size(294, 371)
        Me.lblnat1.TabIndex = 17
        Me.lblnat1.Text = "1" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "5" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "6" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "8" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "10" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "11" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "12" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "13" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "14" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "15" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblop1
        '
        Me.lblop1.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblop1.Location = New System.Drawing.Point(238, 106)
        Me.lblop1.Name = "lblop1"
        Me.lblop1.Size = New System.Drawing.Size(83, 412)
        Me.lblop1.TabIndex = 17
        Me.lblop1.Text = "赞成" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "反对" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "弃权" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Yes" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "No" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Abst." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "7" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "8" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "9" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "10"
        Me.lblop1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblnat3
        '
        Me.lblnat3.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnat3.Location = New System.Drawing.Point(681, 106)
        Me.lblnat3.Name = "lblnat3"
        Me.lblnat3.Size = New System.Drawing.Size(298, 412)
        Me.lblnat3.TabIndex = 17
        Me.lblnat3.Text = "21" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "22" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "23" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "24" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "25" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "26" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "27" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "28" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "29" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "30"
        '
        'lblop3
        '
        Me.lblop3.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblop3.Location = New System.Drawing.Point(905, 106)
        Me.lblop3.Name = "lblop3"
        Me.lblop3.Size = New System.Drawing.Size(83, 412)
        Me.lblop3.TabIndex = 17
        Me.lblop3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblnat2
        '
        Me.lblnat2.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblnat2.Location = New System.Drawing.Point(350, 106)
        Me.lblnat2.Name = "lblnat2"
        Me.lblnat2.Size = New System.Drawing.Size(300, 412)
        Me.lblnat2.TabIndex = 17
        Me.lblnat2.Text = "11" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "12" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "13" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "14" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "15" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "16" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "17" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "18" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "19" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "20" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'lblop2
        '
        Me.lblop2.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblop2.Location = New System.Drawing.Point(574, 106)
        Me.lblop2.Name = "lblop2"
        Me.lblop2.Size = New System.Drawing.Size(83, 412)
        Me.lblop2.TabIndex = 17
        Me.lblop2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(812, 503)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 12)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "第 1/1 页"
        '
        'Button6
        '
        Me.Button6.Enabled = False
        Me.Button6.Location = New System.Drawing.Point(877, 499)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(27, 21)
        Me.Button6.TabIndex = 28
        Me.Button6.Text = ">"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Location = New System.Drawing.Point(779, 499)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(27, 21)
        Me.Button5.TabIndex = 27
        Me.Button5.Text = "<"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.btnpass)
        Me.GroupBox2.Controls.Add(Me.btnabst)
        Me.GroupBox2.Controls.Add(Me.btnno)
        Me.GroupBox2.Controls.Add(Me.btnyes)
        Me.GroupBox2.Location = New System.Drawing.Point(246, 543)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(429, 143)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "控制台"
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(325, 105)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(86, 26)
        Me.Button4.TabIndex = 20
        Me.Button4.Text = "投票结束"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(234, 105)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(85, 26)
        Me.Button3.TabIndex = 19
        Me.Button3.Text = "开启下一轮"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.CheckBox5)
        Me.GroupBox5.Controls.Add(Me.CheckBox6)
        Me.GroupBox5.Controls.Add(Me.CheckBox1)
        Me.GroupBox5.Controls.Add(Me.CheckBox2)
        Me.GroupBox5.Controls.Add(Me.CheckBox4)
        Me.GroupBox5.Controls.Add(Me.CheckBox3)
        Me.GroupBox5.Location = New System.Drawing.Point(235, 22)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(176, 68)
        Me.GroupBox5.TabIndex = 12
        Me.GroupBox5.TabStop = False
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Enabled = False
        Me.CheckBox5.Location = New System.Drawing.Point(97, 44)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(60, 16)
        Me.CheckBox5.TabIndex = 10
        Me.CheckBox5.Text = "Russia"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Enabled = False
        Me.CheckBox6.Location = New System.Drawing.Point(8, 0)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(84, 16)
        Me.CheckBox6.TabIndex = 11
        Me.CheckBox6.Text = "行使否决权"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Enabled = False
        Me.CheckBox1.Location = New System.Drawing.Point(13, 22)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(54, 16)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "China"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Location = New System.Drawing.Point(74, 22)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(42, 16)
        Me.CheckBox2.TabIndex = 7
        Me.CheckBox2.Text = "USA"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Enabled = False
        Me.CheckBox4.Location = New System.Drawing.Point(13, 44)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(60, 16)
        Me.CheckBox4.TabIndex = 9
        Me.CheckBox4.Text = "France"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Enabled = False
        Me.CheckBox3.Location = New System.Drawing.Point(121, 22)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(36, 16)
        Me.CheckBox3.TabIndex = 8
        Me.CheckBox3.Text = "UK"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 46)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(203, 44)
        Me.Label6.TabIndex = 5
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(161, 24)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "请封闭会场, 并进行点名" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "点名完成后点击按钮开始投票"
        '
        'btnpass
        '
        Me.btnpass.Enabled = False
        Me.btnpass.Location = New System.Drawing.Point(172, 105)
        Me.btnpass.Name = "btnpass"
        Me.btnpass.Size = New System.Drawing.Size(46, 26)
        Me.btnpass.TabIndex = 3
        Me.btnpass.Text = "Pass"
        Me.btnpass.UseVisualStyleBackColor = True
        '
        'btnabst
        '
        Me.btnabst.Enabled = False
        Me.btnabst.Location = New System.Drawing.Point(120, 105)
        Me.btnabst.Name = "btnabst"
        Me.btnabst.Size = New System.Drawing.Size(46, 26)
        Me.btnabst.TabIndex = 2
        Me.btnabst.Text = "弃权"
        Me.btnabst.UseVisualStyleBackColor = True
        '
        'btnno
        '
        Me.btnno.Enabled = False
        Me.btnno.Location = New System.Drawing.Point(68, 105)
        Me.btnno.Name = "btnno"
        Me.btnno.Size = New System.Drawing.Size(46, 26)
        Me.btnno.TabIndex = 1
        Me.btnno.Text = "反对"
        Me.btnno.UseVisualStyleBackColor = True
        '
        'btnyes
        '
        Me.btnyes.Enabled = False
        Me.btnyes.Location = New System.Drawing.Point(16, 105)
        Me.btnyes.Name = "btnyes"
        Me.btnyes.Size = New System.Drawing.Size(46, 26)
        Me.btnyes.TabIndex = 0
        Me.btnyes.Text = "赞成"
        Me.btnyes.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.CheckedListBox1)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 543)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(219, 143)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "投票点名"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(19, 110)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(186, 21)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "计算国家数并开始投票"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.CheckOnClick = True
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(19, 20)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.ScrollAlwaysVisible = True
        Me.CheckedListBox1.Size = New System.Drawing.Size(186, 84)
        Me.CheckedListBox1.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 477)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(718, 43)
        Me.Label5.TabIndex = 30
        Me.Label5.Text = "Label5"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblhcname
        '
        Me.lblhcname.AutoSize = True
        Me.lblhcname.Location = New System.Drawing.Point(10, 4)
        Me.lblhcname.Name = "lblhcname"
        Me.lblhcname.Size = New System.Drawing.Size(59, 12)
        Me.lblhcname.TabIndex = 31
        Me.lblhcname.Text = "lblhcname"
        Me.lblhcname.Visible = False
        '
        'voting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1010, 698)
        Me.Controls.Add(Me.lblhcname)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.lblop3)
        Me.Controls.Add(Me.lblop2)
        Me.Controls.Add(Me.lblop1)
        Me.Controls.Add(Me.lblnat3)
        Me.Controls.Add(Me.lblnat2)
        Me.Controls.Add(Me.lblnat1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "voting"
        Me.Text = " "
        Me.TopMost = True
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbl67maj As System.Windows.Forms.Label
    Friend WithEvents lbl50maj As System.Windows.Forms.Label
    Friend WithEvents lblpresent As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblno As System.Windows.Forms.Label
    Friend WithEvents lblabst As System.Windows.Forms.Label
    Friend WithEvents lblyes As System.Windows.Forms.Label
    Friend WithEvents lblnat1 As System.Windows.Forms.Label
    Friend WithEvents lblop1 As System.Windows.Forms.Label
    Friend WithEvents lblnat3 As System.Windows.Forms.Label
    Friend WithEvents lblop3 As System.Windows.Forms.Label
    Friend WithEvents lblnat2 As System.Windows.Forms.Label
    Friend WithEvents lblop2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnpass As System.Windows.Forms.Button
    Friend WithEvents btnabst As System.Windows.Forms.Button
    Friend WithEvents btnno As System.Windows.Forms.Button
    Friend WithEvents btnyes As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckedListBox1 As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblhcname As System.Windows.Forms.Label
End Class
