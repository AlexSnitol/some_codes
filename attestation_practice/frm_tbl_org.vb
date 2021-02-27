Public Class frm_tbl_org

    Private Sub Tbl_orgBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_orgBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_orgBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        vUpdateTable = True
        Me.Tbl_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_org)
    End Sub

    Private Sub frm_tbl_org_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_org". При необходимости она может быть перемещена или удалена.
        Me.Tbl_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_org)

    End Sub

    Private Sub Tbl_orgDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_orgDataGridView.DataError
        On Error Resume Next
    End Sub
End Class