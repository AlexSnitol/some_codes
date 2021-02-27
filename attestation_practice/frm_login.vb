Imports System.Threading

Public Class frm_login

    Private Sub frm_login_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_stat_sved". При необходимости она может быть перемещена или удалена.
        Me.Tbl_stat_svedTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_stat_sved)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_account". При необходимости она может быть перемещена или удалена.
        Me.Tbl_accountTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_account)
        TextBoxPassword.Parent = PictureBox1.Parent
        RandomColor()
        Select Case c
            Case 1
                Me.BackgroundImage = My.Resources.frm_login_1
                ButtonLogIn.Image = My.Resources.frm_login_1_button
            Case 2
                Me.BackgroundImage = My.Resources.frm_login_2
                ButtonLogIn.Image = My.Resources.frm_login_2_button
            Case 3
                Me.BackgroundImage = My.Resources.frm_login_3
                ButtonLogIn.Image = My.Resources.frm_login_3_button
            Case 4
                Me.BackgroundImage = My.Resources.frm_login_4
                ButtonLogIn.Image = My.Resources.frm_login_4_button
            Case 5
                Me.BackgroundImage = My.Resources.frm_login_5
                ButtonLogIn.Image = My.Resources.frm_login_5_button
            Case Else
                Me.BackgroundImage = My.Resources.frm_login_3
                ButtonLogIn.Image = My.Resources.frm_login_3_button
        End Select
    End Sub

    Private Sub frm_login_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If frm_index.Visible = False Then End
    End Sub

    Private Sub frm_login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_stat_sved". При необходимости она может быть перемещена или удалена.
        Me.Tbl_stat_svedTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_stat_sved)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_account". При необходимости она может быть перемещена или удалена.
        Me.Tbl_accountTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_account)
        TextBoxPassword.Parent = PictureBox1.Parent
        RandomColor()
        Select Case c
            Case 1
                Me.BackgroundImage = My.Resources.frm_login_1
                ButtonLogIn.Image = My.Resources.frm_login_1_button
            Case 2
                Me.BackgroundImage = My.Resources.frm_login_2
                ButtonLogIn.Image = My.Resources.frm_login_2_button
            Case 3
                Me.BackgroundImage = My.Resources.frm_login_3
                ButtonLogIn.Image = My.Resources.frm_login_3_button
            Case 4
                Me.BackgroundImage = My.Resources.frm_login_4
                ButtonLogIn.Image = My.Resources.frm_login_4_button
            Case 5
                Me.BackgroundImage = My.Resources.frm_login_5
                ButtonLogIn.Image = My.Resources.frm_login_5_button
            Case Else
                Me.BackgroundImage = My.Resources.frm_login_3
                ButtonLogIn.Image = My.Resources.frm_login_3_button
        End Select
        TextBoxLogin.AutoSize = False
        TextBoxLogin.Size = New Size(210, 26)
        TextBoxPassword.AutoSize = False
        TextBoxPassword.Size = New Size(210, 26)
    End Sub

    Private Sub TextBoxPassword_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPassword.Click
        TextBoxPassword.SelectAll()
    End Sub

    Private Sub TextBoxPassword_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPassword.LostFocus
        If TextBoxPassword.Text = "" Then TextBoxPassword.Text = "Пароль"
    End Sub

    Private Sub TextBoxLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxLogin.Click
        TextBoxLogin.SelectAll()
    End Sub

    Private Sub TextBoxLogin_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxLogin.GotFocus
        If TextBoxLogin.Text = "Имя пользователя" Then TextBoxLogin.Text = ""
    End Sub

    Private Sub TextBoxLogin_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxLogin.LostFocus
        If TextBoxLogin.Text = "" Then TextBoxLogin.Text = "Имя пользователя"
    End Sub

    Private Sub TextBoxPassword_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxPassword.GotFocus
        If TextBoxPassword.Text = "Пароль" Then TextBoxPassword.Text = ""
    End Sub

    Private Sub ButtonLogIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLogIn.Click
        Dim k As Integer = 0
        Dim i As Integer = 0
        Dim pass As String = TextBoxPassword.Text
        If pass = "Пароль" Then pass = ""
        For i = 0 To Attestation_practiceDataSet.Tables("tbl_account").Rows.Count - 1
            On Error GoTo 1
            If Attestation_practiceDataSet.Tables("tbl_account").Rows(i)(0) = TextBoxLogin.Text And Attestation_practiceDataSet.Tables("tbl_account").Rows(i)(1).ToString = pass Then
                k = 1
                frm_index.Tag = Attestation_practiceDataSet.Tables("tbl_account").Rows(i)(2)
                frm_index.Focus()
                frm_index.menu_Remember_User.Checked = False
                frm_index.WindowState = FormWindowState.Normal
                frm_index.Size = New Size(1026, 679)
                frm_index.Tag = Attestation_practiceDataSet.Tables("tbl_account").Rows(i)(2)
                LoginStatus = True
                Select Case Attestation_practiceDataSet.Tables("tbl_account").Rows(i)(2)
                    Case "admin"
                        frm_index.menu_Accounts.Visible = True
                        frm_index.menu_History.Visible = False
                        frm_index.menu_Select_Att_List.Visible = False
                        frm_index.menu_PrintViewer.Visible = True
                        frm_index.ButtonExportToWord.Location = New Point(13, 607)
                        frm_index.ButtonPrint.Location = New Point(146, 607)
                        frm_index.ButtonPrintPreview.Visible = True
                    Case "manager"
                        frm_index.menu_Accounts.Visible = False
                        frm_index.menu_History.Visible = False
                        frm_index.menu_Select_Att_List.Visible = False
                        frm_index.menu_PrintViewer.Visible = False
                        frm_index.ButtonExportToWord.Location = New Point(113, 607)
                        frm_index.ButtonPrint.Location = New Point(246, 607)
                        frm_index.ButtonPrintPreview.Visible = False
                    Case "test"
                        frm_index.menu_Accounts.Visible = True
                        frm_index.menu_History.Visible = True
                        frm_index.menu_Select_Att_List.Visible = True
                        frm_index.menu_PrintViewer.Visible = False
                        frm_index.ButtonExportToWord.Location = New Point(113, 607)
                        frm_index.ButtonPrint.Location = New Point(246, 607)
                        frm_index.ButtonPrintPreview.Visible = False
                    Case Else
                        frm_index.menu_Accounts.Visible = False
                        frm_index.menu_History.Visible = False
                        frm_index.menu_Select_Att_List.Visible = False
                        frm_index.menu_PrintViewer.Visible = False
                        frm_index.ButtonExportToWord.Location = New Point(113, 607)
                        frm_index.ButtonPrint.Location = New Point(246, 607)
                        frm_index.ButtonPrintPreview.Visible = False
                End Select
                If frm_index.Visible = False Then frm_index.Visible = True
                Me.Close()
            End If
        Next
1:      If k = 0 Then MsgBox("Введёны неправильно имя пользователя или пароль!", MsgBoxStyle.Critical, "Ошибка авторизации!")
        Exit Sub
    End Sub
    Private Sub TextBoxPassword_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBoxPassword.KeyPress
        If Asc(e.KeyChar) = 13 Then ButtonLogIn_Click(ButtonLogIn, New EventArgs())
    End Sub

    Private Sub TextBoxLogin_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBoxLogin.KeyPress
        If Asc(e.KeyChar) = 13 Then ButtonLogIn_Click(ButtonLogIn, New EventArgs())
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click
        If v1 = True Then
            TextBoxPassword.UseSystemPasswordChar = False
            PictureBox1.Image = My.Resources.frm_login_pass_hide
            v1 = False
        Else
            TextBoxPassword.UseSystemPasswordChar = True
            PictureBox1.Image = My.Resources.frm_login_pass_show
            v1 = True
        End If
    End Sub

    Private Sub TextBoxPassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxPassword.TextChanged
        If Len(TextBoxPassword.Text) > 9 Then
            If ((209 + (Len(TextBoxPassword.Text) - 9) * 6)) <= 239 Then PictureBox1.Location = New Point(209 + (Len(TextBoxPassword.Text) - 9) * 6, 364) Else PictureBox1.Location = New Point(240, 364)
        Else
            PictureBox1.Location = New Point(209, 364)
        End If
    End Sub

    Private Sub frm_login_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Activate()
    End Sub
End Class
