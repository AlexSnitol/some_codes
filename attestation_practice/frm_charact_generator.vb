Public Class frm_charact_generator

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        Me.Hide()
    End Sub
    Private Sub BeginGenerate()
        TextBox1.Clear()
        Dim pol1 As String
        If pol = "m" Then pol1 = "м"
        If pol = "f" Then pol1 = "ж"
        Dim r1, r2, r3 As Single
        r1 = 3.49
        r2 = 3
        r3 = 2
        'RatingAvg >= r1
        'RatingAvg >= r2 And RatingAvg < r1
        'RatingAvg >= r3 And RatingAvg < r2
        Randomize()
        Dim rand As Integer
        If IsNothing(uchpractika) = False Then
            If RatingAvg >= r1 Then
                Tbl_var_beginBindingSource1.Filter = "rating_var_begin >= '" & r1 & "' and (pol_var_begin = '" & pol1 & "' or pol_var_begin is Null) and use_uch_practika_var_begin = true"
            End If
            If RatingAvg >= r2 And RatingAvg < r1 Then
                Tbl_var_beginBindingSource1.Filter = "rating_var_begin >= '" & r2 & "' and rating_var_begin < '" & r1 & "' and (pol_var_begin = '" & pol1 & "' or pol_var_begin Is Null) and use_uch_practika_var_begin = true"
            End If
            If RatingAvg >= r3 And RatingAvg < r2 Then
                Tbl_var_beginBindingSource1.Filter = "rating_var_begin >= '" & r3 & "' and rating_var_begin < '" & r2 & "' and (pol_var_begin = '" & pol1 & "' or pol_var_begin Is Null) and use_uch_practika_var_begin = true"
            End If
            rand = CInt(Math.Ceiling(Rnd() * Tbl_var_beginBindingSource1.Count)) - 1
            Try
                TextBox1.Text = Tbl_var_beginBindingSource1.Item(rand)(1) & " " & Attestation_practiceDataSet.tbl_uch_practika.FindByid_uch_practiki(uchpractika).Item(9) & "."
            Catch ex As Exception
            End Try
        Else
            If RatingAvg >= r1 Then
                Tbl_var_beginBindingSource1.Filter = "rating_var_begin >= '" & r1 & "' and (pol_var_begin = '" & pol1 & "' or pol_var_begin Is Null) and use_uch_practika_var_begin = false"
            End If
            If RatingAvg >= r2 And RatingAvg < r1 Then
                Tbl_var_beginBindingSource1.Filter = "rating_var_begin >= '" & r2 & "' and rating_var_begin < '" & r1 & "' and (pol_var_begin = '" & pol1 & "' or pol_var_begin Is Null) and use_uch_practika_var_begin = false"
            End If
            If RatingAvg >= r3 And RatingAvg < r2 Then
                Tbl_var_beginBindingSource1.Filter = "rating_var_begin >= '" & r3 & "' and rating_var_begin < '" & r2 & "' and (pol_var_begin = '" & pol1 & "' or pol_var_begin Is Null) and use_uch_practika_var_begin = false"
            End If
            rand = CInt(Math.Ceiling(Rnd() * Tbl_var_beginBindingSource1.Count)) - 1
            Try
                TextBox1.Text = Tbl_var_beginBindingSource1.Item(rand)(1)
            Catch ex As Exception
            End Try
        End If
        Tbl_var_beginBindingSource1.RemoveFilter()
        If RatingAvg >= r1 Then
            Tbl_var_rabotBindingSource1.Filter = "(rating_var_rabot >= '" & r1 & "' or rating_var_rabot Is Null) and (pol_var_rabot = '" & pol1 & "' or pol_var_rabot Is Null)"
        End If
        If RatingAvg >= r2 And RatingAvg < r1 Then
            Tbl_var_rabotBindingSource1.Filter = "((rating_var_rabot >= '" & r2 & "' and rating_var_rabot < '" & r1 & "') or rating_var_rabot Is Null) and (pol_var_rabot = '" & pol1 & "' or pol_var_rabot Is Null)"
        End If
        If RatingAvg >= r3 And RatingAvg < r2 Then
            Tbl_var_rabotBindingSource1.Filter = "((rating_var_rabot >= '" & r3 & "' and rating_var_rabot < '" & r2 & "') or rating_var_rabot Is Null) and (pol_var_rabot = '" & pol1 & "' or pol_var_rabot Is Null)"
        End If
        rand = CInt(Math.Ceiling(Rnd() * Tbl_var_rabotBindingSource1.Count)) - 1
        Try
            TextBox1.Text = TextBox1.Text & " " & Tbl_var_rabotBindingSource1.Item(rand)(1)
        Catch ex As Exception
        End Try
        Tbl_var_rabotBindingSource1.RemoveFilter()
    End Sub

    Private Sub OsnovGenerate()
        TextBox2.Clear()
        Dim pol1 As String
        If pol = "m" Then pol1 = "м"
        If pol = "f" Then pol1 = "ж"
        Dim r1, r2, r3 As Single
        r1 = 3.49
        r2 = 3
        r3 = 2
        'RatingAvg >= r1
        'RatingAvg >= r2 And RatingAvg < r1
        'RatingAvg >= r3 And RatingAvg < r2
        Randomize()
        Dim rand As Integer
        rand = CInt(Math.Ceiling(Rnd() * 2)) - 1
        If RatingAvg >= r1 Then
            Tbl_var_osnovBindingSource1.Filter = "(rating_var_osnov >= '" & r1 & "' or rating_var_osnov is Null)  and (pol_var_osnov = '" & pol1 & "' or pol_var_osnov is Null)"
        End If
        If RatingAvg >= r2 And RatingAvg < r1 Then
            Tbl_var_osnovBindingSource1.Filter = "((rating_var_osnov >= '" & r2 & "' and rating_var_osnov < '" & r1 & "') or rating_var_osnov is Null) and (pol_var_osnov = '" & pol1 & "' or pol_var_osnov Is Null)"
        End If
        If RatingAvg >= r3 And RatingAvg < r2 Then
            Tbl_var_osnovBindingSource1.Filter = "((rating_var_osnov >= '" & r3 & "' and rating_var_osnov < '" & r2 & "') or rating_var_osnov is Null) and (pol_var_osnov = '" & pol1 & "' or pol_var_osnov Is Null)"
        End If
        rand = CInt(Math.Ceiling(Rnd() * Tbl_var_osnovBindingSource1.Count)) - 1
        Try
            TextBox2.Text = Tbl_var_osnovBindingSource1.Item(rand)(1)
        Catch ex As Exception
        End Try
        Tbl_var_osnovBindingSource1.RemoveFilter()
    End Sub

    Private Sub NarekanGenerate()
        TextBox3.Clear()
        Dim pol1 As String
        If pol = "m" Then pol1 = "м"
        If pol = "f" Then pol1 = "ж"
        Dim r1, r2, r3 As Single
        r1 = 3.49
        r2 = 3
        r3 = 2
        'RatingAvg >= r1
        'RatingAvg >= r2 And RatingAvg < r1
        'RatingAvg >= r3 And RatingAvg < r2
        Randomize()
        Dim rand As Integer
        rand = CInt(Math.Ceiling(Rnd() * 2)) - 1
        If RatingAvg >= r1 Then
            Tbl_var_narekanBindingSource1.Filter = "(rating_var_narekan >= '" & r1 & "' or rating_var_narekan is Null) and (pol_var_narekan = '" & pol1 & "' or pol_var_narekan is Null)"
        End If
        If RatingAvg >= r2 And RatingAvg < r1 Then
            Tbl_var_narekanBindingSource1.Filter = "((rating_var_narekan >= '" & r2 & "' and rating_var_narekan < '" & r1 & "') or rating_var_narekan is Null) and (pol_var_narekan = '" & pol1 & "' or pol_var_narekan Is Null)"
        End If
        If RatingAvg >= r3 And RatingAvg < r2 Then
            Tbl_var_narekanBindingSource1.Filter = "((rating_var_narekan >= '" & r3 & "' and rating_var_narekan < '" & r2 & "') or rating_var_narekan is Null) and (pol_var_narekan = '" & pol1 & "' or pol_var_narekan Is Null)"
        End If
        rand = CInt(Math.Ceiling(Rnd() * Tbl_var_narekanBindingSource1.Count)) - 1
        Try
            TextBox3.Text = Tbl_var_narekanBindingSource1.Item(rand)(1)
        Catch ex As Exception
        End Try
        Tbl_var_narekanBindingSource1.RemoveFilter()
    End Sub

    Private Sub SvodGenerate()
        TextBox4.Clear()
        Dim pol1 As String
        If pol = "m" Then pol1 = "м"
        If pol = "f" Then pol1 = "ж"
        Dim r1, r2, r3 As Single
        r1 = 3.49
        r2 = 3
        r3 = 2
        'RatingAvg >= r1
        'RatingAvg >= r2 And RatingAvg < r1
        'RatingAvg >= r3 And RatingAvg < r2
        Randomize()
        Dim rand As Integer
        rand = CInt(Math.Ceiling(Rnd() * 2)) - 1
        If RatingAvg >= r1 Then
            Tbl_var_svodBindingSource1.Filter = "(rating_var_svod >= '" & r1 & "' or rating_var_svod is Null) and (pol_var_svod = '" & pol1 & "' or pol_var_svod is Null)"
        End If
        If RatingAvg >= r2 And RatingAvg < r1 Then
            Tbl_var_svodBindingSource1.Filter = "((rating_var_svod >= '" & r2 & "' and rating_var_svod < '" & r1 & "')  or rating_var_svod is Null) and (pol_var_svod = '" & pol1 & "' or pol_var_svod Is Null)"
        End If
        If RatingAvg >= r3 And RatingAvg < r2 Then
            Tbl_var_svodBindingSource1.Filter = "((rating_var_svod >= '" & r3 & "' and rating_var_svod < '" & r2 & "')  or rating_var_svod is Null) and (pol_var_svod = '" & pol1 & "' or pol_var_svod Is Null)"
        End If
        rand = CInt(Math.Ceiling(Rnd() * Tbl_var_svodBindingSource1.Count)) - 1
        Try
            TextBox4.Text = Tbl_var_svodBindingSource1.Item(rand)(1)
        Catch ex As Exception
        End Try
        Tbl_var_svodBindingSource1.RemoveFilter()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        BeginGenerate()
        OsnovGenerate()
        NarekanGenerate()
        SvodGenerate()
    End Sub

    Private Sub frm_charact_generator_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_uch_practika". При необходимости она может быть перемещена или удалена.
        Me.Tbl_uch_practikaTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_uch_practika)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_svod". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_svodTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_svod)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_rabot". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_rabotTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_rabot)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_osnov". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_osnovTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_osnov)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_narekan". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_narekanTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_narekan)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_begin". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_beginTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_begin)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_svod". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_svodTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_svod)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_rabot". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_rabotTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_rabot)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_osnov". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_osnovTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_osnov)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_narekan". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_narekanTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_narekan)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_begin". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_beginTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_begin)
        If v2RatingAvg = True Then RatingAvg = 2
        If vRatingAvg = True Then
            frm_select_rating.ShowDialog()
            If frm_select_rating.DialogResult = Windows.Forms.DialogResult.OK And frm_select_rating.RadioButton1.Checked = True Then RatingAvg = CDec(Mid(frm_select_rating.ComboBox1.Text, Len(frm_select_rating.ComboBox1.Text) - 1, 1))
            If frm_select_rating.DialogResult = Windows.Forms.DialogResult.OK And frm_select_rating.RadioButton2.Checked = True Then ReDoc = True : Me.Close()
        End If
        Button3_Click(sender, e)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        BeginGenerate()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        OsnovGenerate()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        NarekanGenerate()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        SvodGenerate()
    End Sub

    Private Sub frm_charact_generator_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Activate()
    End Sub
End Class