Imports System.Windows.Forms

Public Class enddeb
    Dim suspendtext As String
    '12-21起D350/49停运给沪西动卧D306/5次
    '成局或被转配到6组25T 替换T8 T10车底 经由达成-襄渝-西康-陇海-郑西北环-京广 跟Z20后面跑 第二日晚发车 跟Z19后 路线不变
    'K818 K820停运
    '成都/重庆北-北京西回复动卧 经由达成-襄渝-西康-郑西高铁-京广高铁 14h 成渝-上海南暂不开D
    '哈大和哈齐开通后 哈齐特快停运 T262停运 车底整编为4组 替换K1062 升级为T91/2/3/4 经由变京哈-津霸-京九-石德-京广-陇海-焦柳-襄渝
    '南昌转配4组DC600V 25T给T238/7哈广特快 时间缩短一半
    'Z19/20 T41/2保留 Z53/4停运 T43/4可能停运

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If TextBox1.Text <> "" Then
            suspendtext = TextBox1.Text + "动议结束辩论"
            Form1.lblmain.Text = suspendtext
            Dim second = MsgBox("请问台下有无附议？", 32 + 4, "结束辩论")
            If second = vbNo Then
                suspendtext = suspendtext + vbCrLf + "未获通过"
                Form1.lblmain.Text = suspendtext
            Else
                Dim infavor = MsgBox("请支持此动议的国家高举国家牌。" + vbCrLf + "该动议是否获得通过？" + vbCrLf + "(注意: 支持动议的国家必须达到三分之二多数才可通过该动议)", 32 + 4, "结束辩论")
                If infavor = vbNo Then
                    suspendtext = suspendtext + vbCrLf + "未获通过"
                    Form1.lblmain.Text = suspendtext
                Else
                    suspendtext = suspendtext + vbCrLf + "获得通过，下面将进入投票环节"
                    Form1.lblmain.Text = suspendtext
                End If
            End If
            Form1.txthcmotion.Text = suspendtext
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()
        Else
            MsgBox("请填写提出动议的国家名称！", MsgBoxStyle.Exclamation, "结束辩论")
        End If
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub enddeb_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 660 - Me.Height
        Me.Left = 450
    End Sub
End Class
