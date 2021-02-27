Public Class frm_tbl_account

    Private Sub Tbl_accountBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_accountBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_accountBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        Me.Tbl_accountTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_account)
    End Sub

    Private Sub frm_tbl_account_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_account". При необходимости она может быть перемещена или удалена.
        Me.Tbl_accountTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_account)

    End Sub

    Private Sub Tbl_accountDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_accountDataGridView.DataError
        On Error Resume Next
    End Sub
End Class