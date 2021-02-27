Public Class frm_tbl_var_svod

    Private Sub Tbl_var_svodBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_var_svodBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_var_svodBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        vUpdateTable = True
        Me.Tbl_var_svodTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_svod)
    End Sub

    Private Sub frm_tbl_var_svod_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_svod". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_svodTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_svod)

    End Sub

    Private Sub Tbl_var_svodDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_var_svodDataGridView.DataError
        On Error Resume Next
    End Sub
End Class