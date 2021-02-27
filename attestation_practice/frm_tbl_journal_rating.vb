Public Class frm_tbl_journal_rating

    Private Sub Tbl_studBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_studBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_studBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        vUpdateTable = True
        Me.Tbl_journal_ratingTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_journal_rating)
    End Sub

    Private Sub frm_tbl_journal_rating_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_org". При необходимости она может быть перемещена или удалена.
        Me.Tbl_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_org)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_ruckovod_practiki". При необходимости она может быть перемещена или удалена.
        Me.Qr_ruckovod_practikiTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_ruckovod_practiki)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_otv_lico_org". При необходимости она может быть перемещена или удалена.
        Me.Qr_otv_lico_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_otv_lico_org)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_otv_lico_org". При необходимости она может быть перемещена или удалена.
        Me.Tbl_otv_lico_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_otv_lico_org)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_vid_rabot". При необходимости она может быть перемещена или удалена.
        Me.Tbl_vid_rabotTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_vid_rabot)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_uch_practika". При необходимости она может быть перемещена или удалена.
        Me.Tbl_uch_practikaTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_uch_practika)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_spec". При необходимости она может быть перемещена или удалена.
        Me.Tbl_specTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_spec)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_stud". При необходимости она может быть перемещена или удалена.
        Me.Qr_studTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_stud)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_journal_rating". При необходимости она может быть перемещена или удалена.
        Me.Tbl_journal_ratingTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_journal_rating)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_stud". При необходимости она может быть перемещена или удалена.
        Me.Tbl_studTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_stud)

    End Sub

    Private Sub Tbl_journal_ratingDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_journal_ratingDataGridView.DataError
        On Error Resume Next
    End Sub
End Class