Public Class frm_pagesetup

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim lm, bm, rm, tm As Single
        lm = NumericUpDown2.Value * 10 / 25.4
        rm = NumericUpDown3.Value * 10 / 25.4
        bm = NumericUpDown4.Value * 10 / 25.4
        tm = NumericUpDown1.Value * 10 / 25.4
        Dim slm, sbm, srm, stm As String
        Dim k As Integer = 0
        For i = 1 To Len(lm)
            If Mid(lm, i, 1) = "," Then slm = Mid(lm, 1, i - 1) & "." & Mid(lm, i + 1, Len(lm)) : Exit For
        Next
        If k >= 1 Then slm = lm : k = 0
        For i = 1 To Len(bm)
            If Mid(bm, i, 1) = "," Then sbm = Mid(bm, 1, i - 1) & "." & Mid(bm, i + 1, Len(bm)) : Exit For
        Next
        If k >= 1 Then sbm = bm : k = 0
        For i = 1 To Len(rm)
            If Mid(rm, i, 1) = "," Then srm = Mid(rm, 1, i - 1) & "." & Mid(rm, i + 1, Len(rm)) : Exit For
        Next
        If k >= 1 Then srm = rm : k = 0
        For i = 1 To Len(tm)
            If Mid(tm, i, 1) = "," Then stm = Mid(tm, 1, i - 1) & "." & Mid(tm, i + 1, Len(tm)) : Exit For
        Next
        If k >= 1 Then stm = tm : k = 0
        If slm = "" Then slm = "0"
        If srm = "" Then srm = "0"
        If stm = "" Then stm = "0"
        If sbm = "" Then sbm = "0"
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup", "header", "")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup", "footer", "")
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup", "margin_left", slm)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup", "margin_right", srm)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup", "margin_top", stm)
        My.Computer.Registry.SetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup", "margin_bottom", sbm)
        pChangeSetting = True
        Me.Close()
    End Sub

    Private Sub frm_pagesetup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim lm, bm, rm, tm As Object
        lm = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup", "margin_left", "")
        bm = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup", "margin_bottom", "")
        rm = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup", "margin_right", "")
        tm = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup", "margin_top", "")
        Dim slm, sbm, srm, stm As Single
        Dim k As Integer = 0
        For i = 1 To Len(lm)
            If Mid(lm, i, 1) = "." Then slm = Mid(lm, 1, i - 1) & "," & Mid(lm, i + 1, Len(lm)) : Exit For
        Next
        If k >= 1 Then slm = lm : k = 0
        For i = 1 To Len(bm)
            If Mid(bm, i, 1) = "." Then sbm = Mid(bm, 1, i - 1) & "," & Mid(bm, i + 1, Len(bm)) : Exit For
        Next
        If k >= 1 Then sbm = bm : k = 0
        For i = 1 To Len(rm)
            If Mid(rm, i, 1) = "." Then srm = Mid(rm, 1, i - 1) & "," & Mid(rm, i + 1, Len(rm)) : Exit For
        Next
        If k >= 1 Then srm = rm : k = 0
        For i = 1 To Len(tm)
            If Mid(tm, i, 1) = "." Then stm = Mid(tm, 1, i - 1) & "," & Mid(tm, i + 1, Len(tm)) : Exit For
        Next
        If k >= 1 Then stm = tm : k = 0
        NumericUpDown2.Value = slm / 10 * 25.4
        NumericUpDown3.Value = srm / 10 * 25.4
        NumericUpDown1.Value = stm / 10 * 25.4
        NumericUpDown4.Value = sbm / 10 * 25.4
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            Using reader As New System.IO.StreamReader(CurDir() & "\attestation_practice.ini", System.Text.Encoding.UTF8)
                Dim fname As String
                Dim fsize As Single
                Dim fbold As Boolean
                Dim fitalic As Boolean
                Dim fboldfitalic As Boolean
                Dim fstyle As System.Drawing.FontStyle = 3
                fname = reader.ReadLine()
                fsize = reader.ReadLine()
                fbold = reader.ReadLine()
                fitalic = reader.ReadLine()
                fboldfitalic = reader.ReadLine()
                If fbold = False And fitalic = False Then FontDialog1.Font = New Font(fname, fsize, FontStyle.Regular)
                If fbold = True And fitalic = False Then FontDialog1.Font = New Font(fname, fsize, FontStyle.Bold)
                If fbold = False And fitalic = True Then FontDialog1.Font = New Font(fname, fsize, FontStyle.Italic)
                If fboldfitalic = True Then FontDialog1.Font = New Font(fname, fsize, fstyle)
                reader.Close()
            End Using
        Catch ex As Exception
            If MsgBox("Файл с параметрами отсутствует! Пожалуйста установите параметры снова.", MsgBoxStyle.OkCancel, "Ошибка чтения файла") = vbOK Then
                FontDialog1.Font = New Font("Time New Romans", 12, FontStyle.Regular)
                GoTo 1
            Else
                MsgBox("Параметры не были установлены!", MsgBoxStyle.Critical, "Параметры не были установелены!")
                Exit Sub
            End If
        End Try
1:      If FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Using writer As New System.IO.StreamWriter(CurDir() & "\attestation_practice.ini", False, System.Text.Encoding.UTF8)
                writer.WriteLine(FontDialog1.Font.Name)
                writer.WriteLine(FontDialog1.Font.Size)
                writer.WriteLine(FontDialog1.Font.Bold)
                writer.WriteLine(FontDialog1.Font.Italic)
                writer.WriteLine(FontDialog1.Font.Bold And FontDialog1.Font.Italic)
                If frm_index.menu_Remember_User.Checked = True Then
                    writer.WriteLine("true")
                    Select Case frm_index.Tag
                        Case "admin"
                            writer.WriteLine("d033e22ae348aeb5660fc2140aec35850c4da997")
                        Case "manager"
                            writer.WriteLine("1a8565a9dc72048ba03b4156be3e569f22771f23")
                        Case "test"
                            writer.WriteLine("a94a8fe5ccb19ba61c4c0873d391e987982fbbd3")
                        Case Else
                            writer.WriteLine("1a8565a9dc72048ba03b4156be3e569f22771f23")
                    End Select
                Else
                    writer.WriteLine("false")
                End If
                writer.Close()
            End Using
            pChangeSetting = True
        End If
    End Sub
End Class