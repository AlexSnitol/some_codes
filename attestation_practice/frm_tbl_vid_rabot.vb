Public Class frm_tbl_vid_rabot

    Private Sub Tbl_vid_rabotBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_vid_rabotBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_vid_rabotBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        vUpdateTableVidRabot = True
        Me.Tbl_vid_rabotTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_vid_rabot)
    End Sub

    Private Sub frm_tbl_vid_rabot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_uch_practika". При необходимости она может быть перемещена или удалена.
        Me.Tbl_uch_practikaTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_uch_practika)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_vid_rabot". При необходимости она может быть перемещена или удалена.
        Me.Tbl_vid_rabotTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_vid_rabot)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_spec". При необходимости она может быть перемещена или удалена.
        Me.Tbl_specTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_spec)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_uch_practika". При необходимости она может быть перемещена или удалена.
        Me.Qr_uch_practikaTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_uch_practika)
        TblspecBindingSource.Sort = "nam_spec ASC"
        Qr_uch_practikaBindingSource.Sort = "nam_prof_modul_uch_practiki ASC"
        TbluchpractikaBindingSource1.Sort = "nam_uch_practiki ASC"
        Tbl_vid_rabotBindingSource.Sort = "id_uch_practika_vid_rabot ASC"
        ComboBoxTbl_spec.SelectedIndex = -1
        ComboBoxTbl_uch_practika_modul.SelectedIndex = -1
        ComboBoxTbl_uch_practika.SelectedIndex = -1
        Tbl_vid_rabotBindingSource.RemoveFilter()
    End Sub

    Private Sub Tbl_vid_rabotDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_vid_rabotDataGridView.DataError
        On Error Resume Next
    End Sub

    Private Sub ComboBoxTbl_spec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_spec.SelectedIndexChanged
        ComboBoxTbl_uch_practika_modul.SelectedIndex = -1
        ComboBoxTbl_uch_practika.SelectedIndex = -1
        Tbl_vid_rabotBindingSource.Filter = "id_uch_practika_vid_rabot = " & 0
        Dim v As Integer = ComboBoxTbl_spec.SelectedValue
        If Not ComboBoxTbl_spec.Text = "" Then
            Qr_uch_practikaBindingSource.Filter = "id_spec_uch_practiki = " & v
            TbluchpractikaBindingSource1.Filter = "nam_prof_modul_uch_practiki = '" & ComboBoxTbl_uch_practika_modul.Text & "'"
            ComboBoxTbl_uch_practika_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub ComboBoxTbl_uch_practika_modul_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_uch_practika_modul.SelectedIndexChanged
        TbluchpractikaBindingSource1.Filter = "nam_prof_modul_uch_practiki = '" & ComboBoxTbl_uch_practika_modul.Text & "'"
        ComboBoxTbl_uch_practika_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub ComboBoxTbl_uch_practika_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_uch_practika.SelectedIndexChanged
        If Not ComboBoxTbl_uch_practika.Text = Nothing Then
            Dim v As Integer = ComboBoxTbl_uch_practika.SelectedValue
            Tbl_vid_rabotBindingSource.Filter = "id_uch_practika_vid_rabot = " & v
        End If
        Me.Tbl_vid_rabotTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_vid_rabot)
    End Sub

    Private Sub ButtonClearTbl_spec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearTbl_spec.Click
        ComboBoxTbl_spec.SelectedIndex = -1
        ComboBoxTbl_uch_practika_modul.SelectedIndex = -1
        ComboBoxTbl_uch_practika.SelectedIndex = -1
        Tbl_vid_rabotBindingSource.RemoveFilter()
    End Sub
End Class