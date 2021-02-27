Public Class frm_tbl_ruckovod_practiki

    Private Sub Tbl_ruckovod_practikiBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_ruckovod_practikiBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_ruckovod_practikiBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        vUpdateTable = True
        Me.Tbl_ruckovod_practikiTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_ruckovod_practiki)
    End Sub

    Private Sub frm_tbl_ruckovod_practiki_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_ruckovod_practiki". При необходимости она может быть перемещена или удалена.
        Me.Tbl_ruckovod_practikiTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_ruckovod_practiki)
    End Sub

    Private Sub Tbl_ruckovod_practikiDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_ruckovod_practikiDataGridView.DataError
        On Error Resume Next
    End Sub

End Class