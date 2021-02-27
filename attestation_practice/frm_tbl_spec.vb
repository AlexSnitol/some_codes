Public Class frm_tbl_spec

    Private Sub Tbl_specBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_specBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_specBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        vUpdateTable = True
        Me.Tbl_specTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_spec)
    End Sub

    Private Sub frm_tbl_spec_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_spec". При необходимости она может быть перемещена или удалена.
        Me.Tbl_specTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_spec)

    End Sub

    Private Sub Tbl_specDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_specDataGridView.DataError
        On Error Resume Next
    End Sub
End Class