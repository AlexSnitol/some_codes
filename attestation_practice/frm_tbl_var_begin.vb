Public Class frm_tbl_var_begin

    Private Sub Tbl_var_beginBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_var_beginBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_var_beginBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        vUpdateTable = True
        Me.Tbl_var_beginTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_begin)
    End Sub

    Private Sub frm_tbl_var_begin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_begin". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_beginTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_begin)

    End Sub

    Private Sub Tbl_var_beginDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_var_beginDataGridView.DataError
        On Error Resume Next
    End Sub
End Class