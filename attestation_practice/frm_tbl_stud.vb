Public Class frm_tbl_stud
    Private Sub Tbl_studBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tbl_studBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.Tbl_studBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.Attestation_practiceDataSet)
        vUpdateTable = True
        Me.Tbl_studTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_stud)
    End Sub
    Private Sub frm_tbl_stud_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_spec". При необходимости она может быть перемещена или удалена.
        Me.Tbl_specTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_spec)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_stud". При необходимости она может быть перемещена или удалена.
        Me.Tbl_studTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_stud)
        TblspecBindingSource.Sort = "nam_spec ASC"
        ComboBoxTbl_spec.SelectedIndex = -1
    End Sub

    Private Sub Tbl_studDataGridView_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles Tbl_studDataGridView.DataError
        On Error Resume Next
    End Sub

    Private Sub ButtonClearTbl_spec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearTbl_spec.Click
        ComboBoxTbl_spec.SelectedIndex = -1
        Tbl_studBindingSource.RemoveFilter()
        If Not ComboBoxKurs.Text = Nothing Then
            Dim kurs As Integer = Val(ComboBoxKurs.Text)
            Tbl_studBindingSource.Filter = "kurs_stud = " & kurs
        End If
    End Sub

    Private Sub ButtonClearKurs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearKurs.Click
        ComboBoxKurs.SelectedIndex = -1
        Tbl_studBindingSource.RemoveFilter()
        If Not ComboBoxTbl_spec.Text = "" Then
            Dim v As Integer = ComboBoxTbl_spec.SelectedValue
            Tbl_studBindingSource.Filter = "id_spec_stud = " & v
        End If
    End Sub

    Private Sub ComboBoxTbl_spec_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_spec.SelectedIndexChanged
        If Not ComboBoxKurs.Text = Nothing And Not ComboBoxTbl_spec.Text = Nothing Then
            Dim v As Integer = ComboBoxTbl_spec.SelectedValue
            Dim kurs As Integer = Val(ComboBoxKurs.Text)
            Tbl_studBindingSource.Filter = "id_spec_stud = " & v & " and kurs_stud = " & kurs
        Else
            If Not ComboBoxTbl_spec.Text = Nothing Then
                Dim v As Integer = ComboBoxTbl_spec.SelectedValue
                Tbl_studBindingSource.Filter = "id_spec_stud = " & v
            End If
            If Not ComboBoxKurs.Text = Nothing Then
                Dim kurs As Integer = Val(ComboBoxKurs.Text)
                Tbl_studBindingSource.Filter = "kurs_stud = " & kurs
            End If
        End If
    End Sub

    Private Sub ComboBoxKurs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxKurs.SelectedIndexChanged
        If Not ComboBoxKurs.Text = Nothing And Not ComboBoxTbl_spec.Text = Nothing Then
            Dim v As Integer = ComboBoxTbl_spec.SelectedValue
            Dim kurs As Integer = Val(ComboBoxKurs.Text)
            Tbl_studBindingSource.Filter = "id_spec_stud = " & v & " and kurs_stud = " & kurs
        Else
            If Not ComboBoxTbl_spec.Text = Nothing Then
                Dim v As Integer = ComboBoxTbl_spec.SelectedValue
                Tbl_studBindingSource.Filter = "id_spec_stud = " & v
            End If
            If Not ComboBoxKurs.Text = Nothing Then
                Dim kurs As Integer = Val(ComboBoxKurs.Text)
                Tbl_studBindingSource.Filter = "kurs_stud = " & kurs
            End If
        End If
    End Sub
End Class