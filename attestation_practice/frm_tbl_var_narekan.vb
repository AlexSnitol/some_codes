Public Class frm_tbl_var_narekan

    Private Sub Tbl_var_narekanBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_var_narekanBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_var_narekanBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        vUpdateTable = True
        Me.Tbl_var_narekanTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_narekan)
    End Sub

    Private Sub frm_tbl_var_narekan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_var_narekan". При необходимости она может быть перемещена или удалена.
        Me.Tbl_var_narekanTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_var_narekan)

    End Sub

    Private Sub Tbl_var_narekanDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_var_narekanDataGridView.DataError
        On Error Resume Next
    End Sub
End Class