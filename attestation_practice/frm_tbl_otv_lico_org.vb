Public Class frm_tbl_otv_lico_org

    Private Sub Tbl_otv_lico_orgBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_otv_lico_orgBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_otv_lico_orgBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        vUpdateTable = True
        Me.Tbl_otv_lico_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_otv_lico_org)
    End Sub

    Private Sub frm_tbl_otv_lico_org_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_otv_lico_org". При необходимости она может быть перемещена или удалена.
        Me.Tbl_otv_lico_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_otv_lico_org)

    End Sub

    Private Sub Tbl_otv_lico_orgDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_otv_lico_orgDataGridView.DataError
        On Error Resume Next
    End Sub
End Class