Public Class frm_tbl_uch_practika

    Private Sub Tbl_uch_practikaBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_uch_practikaBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_uch_practikaBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        vUpdateTable = True
        tmp2 = tmp
        Me.Tbl_uch_practikaTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_uch_practika)
        Me.Qr_uch_practikaTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_uch_practika)
        ComboBoxTbl_uch_practika_modul.Text = tmp2
    End Sub

    Private Sub frm_tbl_uch_practika_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_otv_lico_org". При необходимости она может быть перемещена или удалена.
        Me.Qr_otv_lico_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_otv_lico_org)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_otv_lico_org". При необходимости она может быть перемещена или удалена.
        Me.Tbl_otv_lico_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_otv_lico_org)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_ruckovod_practiki". При необходимости она может быть перемещена или удалена.
        Me.Qr_ruckovod_practikiTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_ruckovod_practiki)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_spec". При необходимости она может быть перемещена или удалена.
        Me.Tbl_specTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_spec)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_uch_practika". При необходимости она может быть перемещена или удалена.
        Me.Tbl_uch_practikaTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_uch_practika)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_uch_practika". При необходимости она может быть перемещена или удалена.
        Me.Qr_uch_practikaTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_uch_practika)
        TblspecBindingSource.Sort = "nam_spec ASC"
        Qr_uch_practikaBindingSource.Sort = "nam_prof_modul_uch_practiki ASC"
        ComboBoxTbl_spec.SelectedIndex = -1
        Qr_uch_practikaBindingSource.RemoveFilter()
        ComboBoxTbl_uch_practika_modul.SelectedIndex = -1
        Tbl_uch_practikaBindingSource.RemoveFilter()
    End Sub

    Private Sub Tbl_uch_practikaDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_uch_practikaDataGridView.DataError
        On Error Resume Next
    End Sub

    Private Sub ButtonClearTbl_spec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearTbl_spec.Click
        ComboBoxTbl_spec.SelectedIndex = -1
        Tbl_uch_practikaBindingSource.RemoveFilter()
        If Not ComboBoxTbl_uch_practika_modul.Text = Nothing Then
            Dim prof_modul As String = ComboBoxTbl_uch_practika_modul.Text
            Tbl_uch_practikaBindingSource.Filter = "nam_prof_modul_uch_practiki = '" & prof_modul & "'"
        End If
    End Sub

    Private Sub ComboBoxTbl_spec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_spec.SelectedIndexChanged
        Dim v As Integer = ComboBoxTbl_spec.SelectedValue
        Qr_uch_practikaBindingSource.Filter = "id_spec_uch_practiki = " & v
        ComboBoxTbl_uch_practika_modul.SelectedIndex = -1
        If Not ComboBoxTbl_uch_practika_modul.Text = Nothing And Not ComboBoxTbl_spec.Text = Nothing Then
            Dim prof_modul As String = ComboBoxTbl_uch_practika_modul.Text
            Tbl_uch_practikaBindingSource.Filter = "id_spec_uch_practiki = " & v & " and nam_prof_modul_uch_practiki = '" & prof_modul & "'"
        Else
            If Not ComboBoxTbl_spec.Text = Nothing Then
                Tbl_uch_practikaBindingSource.Filter = "id_spec_uch_practiki = " & v
            End If
            If Not ComboBoxTbl_uch_practika_modul.Text = Nothing Then
                Dim prof_modul As String = ComboBoxTbl_uch_practika_modul.Text
                Tbl_uch_practikaBindingSource.Filter = "nam_prof_modul_uch_practiki = '" & prof_modul & "'"
            End If
        End If
    End Sub

    Private Sub ComboBoxTbl_uch_practika_modul_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_uch_practika_modul.SelectedIndexChanged
        If Not ComboBoxTbl_uch_practika_modul.Text = Nothing And Not ComboBoxTbl_spec.Text = Nothing Then
            Dim v As Integer = ComboBoxTbl_spec.SelectedValue
            Dim prof_modul As String = ComboBoxTbl_uch_practika_modul.Text
            Tbl_uch_practikaBindingSource.Filter = "id_spec_uch_practiki = " & v & " and nam_prof_modul_uch_practiki = '" & prof_modul & "'"
        Else
            If Not ComboBoxTbl_spec.Text = Nothing Then
                Dim v As Integer = ComboBoxTbl_spec.SelectedValue
                Tbl_uch_practikaBindingSource.Filter = "id_spec_uch_practiki = " & v
            End If
            If Not ComboBoxTbl_uch_practika_modul.Text = Nothing Then
                Dim prof_modul As String = ComboBoxTbl_uch_practika_modul.Text
                Tbl_uch_practikaBindingSource.Filter = "nam_prof_modul_uch_practiki = '" & prof_modul & "'"
            End If
        End If
        tmp = ComboBoxTbl_uch_practika_modul.Text
    End Sub

    Private Sub ButtonClearTbl_uch_practika_modul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearTbl_uch_practika_modul.Click
        ComboBoxTbl_uch_practika_modul.SelectedIndex = -1
        Tbl_uch_practikaBindingSource.RemoveFilter()
        If Not ComboBoxTbl_spec.Text = Nothing Then
            Dim v As Integer = ComboBoxTbl_spec.SelectedValue
            Tbl_uch_practikaBindingSource.Filter = "id_spec_uch_practiki = " & v
        End If
        tmp = ""
    End Sub
End Class