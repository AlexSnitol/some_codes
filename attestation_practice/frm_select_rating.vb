Public Class frm_select_rating

    Private Sub frm_select_rating_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Tbl_vid_rabotDataGridView.RowHeadersVisible = False
        Tbl_vid_rabotDataGridView.Columns(0).Visible = False
        Tbl_vid_rabotDataGridView.DataSource = frm_index.TblvidrabotBindingSource
        Dim c As Integer = 0
        Dim r As Integer = 0
        p = True
        For r = 0 To frm_index.TblvidrabotBindingSource.Count - 1
            Select Case frm_index.TblvidrabotBindingSource.Item(r)(4).ToString
                Case "5", "4", "3", "2"
                    For c = 0 To Tbl_vid_rabotDataGridView.ColumnCount - 1
                        Tbl_vid_rabotDataGridView.Rows(r).Cells(c).Style.BackColor = Color.LightGreen
                    Next
                Case Else
                    For c = 0 To Tbl_vid_rabotDataGridView.ColumnCount - 1
                        Tbl_vid_rabotDataGridView.Rows(r).Cells(c).Style.BackColor = Color.Tomato
                        p = False
                    Next
            End Select
        Next
        If Me.RadioButton2.Checked = True Then If p = False Then Me.Button1.Enabled = False Else Me.Button1.Enabled = True Else Me.Button1.Enabled = True
    End Sub
    Dim p As Boolean = False 'Проверка на правильность заполнения
    Private Sub frm_select_rating_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Tbl_vid_rabotDataGridView.RowHeadersVisible = False
        Tbl_vid_rabotDataGridView.DataSource = frm_index.TblvidrabotBindingSource
        Dim c As Integer = 0
        Dim r As Integer = 0
        For r = 0 To frm_index.TblvidrabotBindingSource.Count - 1
            Select Case frm_index.TblvidrabotBindingSource.Item(r)(4).ToString
                Case "5", "4", "3", "2"
                    For c = 0 To Tbl_vid_rabotDataGridView.ColumnCount - 1
                        Tbl_vid_rabotDataGridView.Rows(r).Cells(c).Style.BackColor = Color.LightGreen
                    Next
                Case Else
                    For c = 0 To Tbl_vid_rabotDataGridView.ColumnCount - 1
                        Tbl_vid_rabotDataGridView.Rows(r).Cells(c).Style.BackColor = Color.Tomato
                    Next
            End Select
        Next
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then Tbl_vid_rabotDataGridView.Enabled = False : ComboBox1.Enabled = True : Button1.Enabled = True Else Tbl_vid_rabotDataGridView.Enabled = True : ComboBox1.Enabled = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton1.Checked = True Then Tbl_vid_rabotDataGridView.Enabled = False : ComboBox1.Enabled = True Else Tbl_vid_rabotDataGridView.Enabled = True : ComboBox1.Enabled = False : frm_select_rating_Activated(sender, e)
    End Sub

    Private Sub Tbl_vid_rabotDataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Tbl_vid_rabotDataGridView.CellEndEdit
        Dim c As Integer = 0
        Dim r As Integer = 0
        p = True
        For r = 0 To frm_index.TblvidrabotBindingSource.Count - 1
            Select Case frm_index.TblvidrabotBindingSource.Item(r)(4).ToString
                Case "5", "4", "3", "2"
                    For c = 0 To Tbl_vid_rabotDataGridView.ColumnCount - 1
                        Tbl_vid_rabotDataGridView.Rows(r).Cells(c).Style.BackColor = Color.LightGreen
                    Next
                Case Else
                    For c = 0 To Tbl_vid_rabotDataGridView.ColumnCount - 1
                        Tbl_vid_rabotDataGridView.Rows(r).Cells(c).Style.BackColor = Color.Tomato
                        p = False
                    Next
            End Select
        Next
        If Me.RadioButton2.Checked = True Then If p = False Then Me.Button1.Enabled = False Else Me.Button1.Enabled = True Else Me.Button1.Enabled = True
    End Sub

    Private Sub Tbl_vid_rabotDataGridView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Tbl_vid_rabotDataGridView.Click
        RadioButton2_CheckedChanged(sender, e)
    End Sub

    Private Sub ComboBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.Click
        RadioButton1_CheckedChanged(sender, e)
    End Sub

    Private Sub frm_select_rating_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Activate()
    End Sub
End Class