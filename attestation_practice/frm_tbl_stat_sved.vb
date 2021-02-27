Public Class frm_tbl_stat_sved

    Private Sub Tbl_stat_svedBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_stat_svedBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_stat_svedBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        vUpdateTable = True
        Me.Tbl_stat_svedTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_stat_sved)
    End Sub

    Private Sub frm_tbl_stat_sved_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_stat_sved". При необходимости она может быть перемещена или удалена.
        Me.Tbl_stat_svedTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_stat_sved)

    End Sub

    Private Sub Tbl_stat_svedDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_stat_svedDataGridView.DataError
        On Error Resume Next
    End Sub
End Class