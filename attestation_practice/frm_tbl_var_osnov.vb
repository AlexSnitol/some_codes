Public Class frm_tbl_var_osnov

    Private Sub Tbl_var_osnovBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_var_osnovBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_var_osnovBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        vUpdateTable = True
        Me.Tbl_var_osnovTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_osnov)
    End Sub

    Private Sub frm_tbl_var_osnov_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_osnov". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_osnovTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_osnov)

    End Sub

    Private Sub Tbl_var_osnovDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_var_osnovDataGridView.DataError
        On Error Resume Next
    End Sub
End Class