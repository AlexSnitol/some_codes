Public Class frm_select_att_list

    Private Sub frm_select_att_list_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If vUpdateTable = True Then
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_journal_rating". При необходимости она может быть перемещена или удалена.
            Me.Tbl_journal_ratingTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_journal_rating)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_stud". При необходимости она может быть перемещена или удалена.
            Me.Tbl_studTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_stud)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_uch_practika". При необходимости она может быть перемещена или удалена.
            Me.Tbl_uch_practikaTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_uch_practika)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_spec". При необходимости она может быть перемещена или удалена.
            Me.Tbl_specTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_spec)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_stud". При необходимости она может быть перемещена или удалена.
            Me.Qr_studTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_stud)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_journal_rating". При необходимости она может быть перемещена или удалена.
            Me.Qr_journal_ratingTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_journal_rating)
            vUpdateTable = False
        End If
    End Sub

    Private Sub frm_select_att_list_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_journal_rating". При необходимости она может быть перемещена или удалена.
        Me.Tbl_journal_ratingTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_journal_rating)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_stud". При необходимости она может быть перемещена или удалена.
        Me.Tbl_studTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_stud)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_uch_practika". При необходимости она может быть перемещена или удалена.
        Me.Tbl_uch_practikaTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_uch_practika)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_spec". При необходимости она может быть перемещена или удалена.
        Me.Tbl_specTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_spec)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_stud". При необходимости она может быть перемещена или удалена.
        Me.Qr_studTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_stud)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_journal_rating". При необходимости она может быть перемещена или удалена.
        Me.Qr_journal_ratingTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_journal_rating)
        Qr_journal_ratingDataGridView.RowHeadersVisible = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frm_tbl_journal_rating.Show()
    End Sub

    Private Sub Qr_journal_ratingDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Qr_journal_ratingDataGridView.DataError
        On Error Resume Next
    End Sub

    Private Sub ComboBoxTbl_spec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_spec.SelectedIndexChanged
        Dim v As Integer = ComboBoxTbl_spec.SelectedValue
        Dim vProf_modul As Integer = ComboBoxTbl_uch_practika.SelectedValue
        TbluchpractikaBindingSource2.Filter = "id_spec_uch_practiki = " & v
        TbluchpractikaBindingSource3.Filter = "id_spec_uch_practiki = " & v
        If CheckBoxData.Checked = True Then Qr_journal_ratingBindingSource.Filter = "id_spec_journal_rating =" & v & "and id_prof_modul_journal_rating = " & vProf_modul & " and data_journal_rating = " & DateTimePicker3.Value.Date Else Qr_journal_ratingBindingSource.Filter = "id_spec_journal_rating =" & v & "and id_prof_modul_journal_rating = " & vProf_modul
    End Sub

    Private Sub ButtonClearTbl_vid_rabot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearTbl_vid_rabot.Click
        Qr_journal_ratingBindingSource.RemoveFilter()
    End Sub

    Private Sub ComboBoxTbl_uch_practika_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_uch_practika.SelectedIndexChanged
        Dim v As Integer = ComboBoxTbl_spec.SelectedValue
        Dim vUch_practika As Integer = ComboBoxTbl_uch_practika.SelectedValue
        ComboBoxTbl_uch_practika_modul.SelectedValue = vUch_practika
        MsgBox(DateTimePicker3.Value.Date)
        If CheckBoxData.Checked = True Then Qr_journal_ratingBindingSource.Filter = "id_spec_journal_rating =" & v & "and id_prof_modul_journal_rating = " & vUch_practika & " and data_journal_rating = " & DateTimePicker3.Value.Date Else Qr_journal_ratingBindingSource.Filter = "id_spec_journal_rating =" & v & "and id_prof_modul_journal_rating = " & vUch_practika
    End Sub

    Private Sub ComboBoxTbl_uch_practika_modul_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_uch_practika_modul.SelectedIndexChanged
        Dim v As Integer = ComboBoxTbl_spec.SelectedValue
        Dim vProf_modul As Integer = ComboBoxTbl_uch_practika_modul.SelectedValue
        ComboBoxTbl_uch_practika.SelectedValue = vProf_modul
        If CheckBoxData.Checked = True Then Qr_journal_ratingBindingSource.Filter = "id_spec_journal_rating =" & v & "and id_prof_modul_journal_rating = " & vProf_modul & " and data_journal_rating = " & DateTimePicker3.Value.Date Else Qr_journal_ratingBindingSource.Filter = "id_spec_journal_rating =" & v & "and id_prof_modul_journal_rating = " & vProf_modul
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Tbl_journal_ratingBindingSource.Filter = "id_stud_journal_rating = " & Qr_journal_ratingBindingSource.Item(Qr_journal_ratingBindingSource.Position)(0) & " and prof_modul_journal_rating = " & ComboBoxTbl_uch_practika_modul.SelectedValue & " and data_journal_rating = " & Qr_journal_ratingBindingSource.Item(Qr_journal_ratingBindingSource.Position)(9)
    End Sub
End Class