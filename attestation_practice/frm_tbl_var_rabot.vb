Public Class frm_tbl_var_rabot

    Private Sub Tbl_var_rabotBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_var_rabotBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_var_rabotBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        vUpdateTable = True
        Me.Tbl_var_rabotTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_rabot)
    End Sub

    Private Sub frm_tbl_var_rabot_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_rabot". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_rabotTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_rabot)

    End Sub

    Private Sub Tbl_var_rabotDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_var_rabotDataGridView.DataError
        On Error Resume Next
    End Sub
End Class