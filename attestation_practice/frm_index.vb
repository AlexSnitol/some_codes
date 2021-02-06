Imports Microsoft.Office.Interop
Imports System.Threading

Public Class frm_index

    Public Th As System.Threading.Thread

    Private Sub frm_index_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If vUpdateTable = True Then
            vUpdateTable = False
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_journal_rating". При необходимости она может быть перемещена или удалена.
            Me.Tbl_journal_ratingTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_journal_rating)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_journal_rating". При необходимости она может быть перемещена или удалена.
            Me.Tbl_journal_ratingTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_journal_rating)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_stat_sved". При необходимости она может быть перемещена или удалена.
            Me.Tbl_stat_svedTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_stat_sved)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_org". При необходимости она может быть перемещена или удалена.
            Me.Tbl_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_org)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_otv_lico_org". При необходимости она может быть перемещена или удалена.
            Me.Qr_otv_lico_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_otv_lico_org)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_otv_lico_org". При необходимости она может быть перемещена или удалена.
            Me.Tbl_otv_lico_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_otv_lico_org)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_ruckovod_practiki". При необходимости она может быть перемещена или удалена.
            Me.Qr_ruckovod_practikiTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_ruckovod_practiki)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_ruckovod_practiki". При необходимости она может быть перемещена или удалена.
            Me.Tbl_ruckovod_practikiTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_ruckovod_practiki)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_stud". При необходимости она может быть перемещена или удалена.
            Me.Qr_studTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_stud)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_uch_practika". При необходимости она может быть перемещена или удалена.
            Me.Tbl_uch_practikaTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_uch_practika)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_stud". При необходимости она может быть перемещена или удалена.
            Me.Tbl_studTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_stud)
            'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_spec". При необходимости она может быть перемещена или удалена.
            Me.Tbl_specTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_spec)
        End If
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_vid_rabot". При необходимости она может быть перемещена или удалена.
        If vUpdateTableVidRabot = True Then vUpdateTableVidRabot = False : Me.Tbl_vid_rabotTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_vid_rabot)
    End Sub

    Private Sub frm_index_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If IO.File.Exists(CurDir() & "\attestation_practice_tmp.htm") Then IO.File.Delete(CurDir() & "\attestation_practice_tmp.htm")
        If IO.File.Exists(CurDir() & "\attestation_practice_tmp.docx") Then IO.File.Delete(CurDir() & "\attestation_practice_tmp.docx")
        If IO.Directory.Exists(CurDir() & "\attestation_practice_tmp.files") Then IO.Directory.Delete(CurDir() & "\attestation_practice_tmp.files", True)
        If IO.Directory.Exists(CurDir() & "\attestation_practice_tmp (1).files") Then IO.Directory.Delete(CurDir() & "\attestation_practice_tmp (1).files", True)
        End
    End Sub

    Dim LoadingLogin As Boolean = False 'Проверка на причину вызова загрузки

    Private Sub frm_index_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
start:  If Not IO.File.Exists(CurDir() & "\attestation_practice.accdb") Then
            If MsgBox("Файл базы данных не найден!" & vbCrLf & "Для продолжения работы с программой, пожалуйста укажите существующий файл базы данных или переустановите приложение!" & vbCrLf & "Для указания файла базы данных нажмите " & Chr(34) & "ОК" & Chr(34) & ".", MsgBoxStyle.Critical, "Ошибка чтения файла базы данных!") = MsgBoxResult.Ok Then
openfile:       OpenFileDialog1.FileName = "attestation_practice.accdb"
                OpenFileDialog1.InitialDirectory = CurDir()
                Try
                    If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                        My.Computer.FileSystem.CopyFile(OpenFileDialog1.FileName, CurDir() & "\attestation_practice.accdb", True)
                        MsgBox("Для подключения базы данных программа будет перезапущена.", MsgBoxStyle.Information, "Перезагрузка программы")
                        System.Diagnostics.Process.Start(Application.ExecutablePath)
                        Application.Exit()
                        'Application.Restart()
                        Exit Sub
                    End If
                Catch
                    If MsgBox("Не удалось открыть обозреватель файлов! Попробовать ещё раз?", MsgBoxStyle.RetryCancel, "Ошибка обозревателя файлов") = MsgBoxResult.Retry Then GoTo openfile
                End Try
            Else
                End
            End If
        End If
        Try
            Using reader As New System.IO.StreamReader(CurDir() & "\attestation_practice.ini", System.Text.Encoding.UTF8)
                reader.ReadLine()
                reader.ReadLine()
                reader.ReadLine()
                reader.ReadLine()
                reader.ReadLine()
                If reader.ReadLine() = True Then
                    Me.Enabled = True
                    Me.menu_Remember_User.Checked = True
                    Me.Focus()
                    Me.Size = New Size(1026, 679)
                    LoginStatus = True
                    Select Case reader.ReadLine()
                        Case "d033e22ae348aeb5660fc2140aec35850c4da997"
                            Me.Tag = "admin"
                            Me.menu_Accounts.Visible = True
                            Me.menu_History.Visible = False
                            Me.menu_Select_Att_List.Visible = False
                            Me.menu_PrintViewer.Visible = True
                            Me.ButtonExportToWord.Location = New Point(13, 607)
                            Me.ButtonPrint.Location = New Point(146, 607)
                            Me.ButtonPrintPreview.Visible = True
                        Case "1a8565a9dc72048ba03b4156be3e569f22771f23"
                            Me.Tag = "manager"
                            Me.menu_Accounts.Visible = False
                            Me.menu_History.Visible = False
                            Me.menu_Select_Att_List.Visible = False
                            Me.menu_PrintViewer.Visible = False
                            Me.ButtonExportToWord.Location = New Point(113, 607)
                            Me.ButtonPrint.Location = New Point(246, 607)
                            Me.ButtonPrintPreview.Visible = False
                        Case "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3"
                            Me.Tag = "test"
                            Me.menu_Accounts.Visible = True
                            Me.menu_History.Visible = True
                            Me.menu_Select_Att_List.Visible = True
                            Me.menu_PrintViewer.Visible = False
                            Me.ButtonExportToWord.Location = New Point(113, 607)
                            Me.ButtonPrint.Location = New Point(246, 607)
                            Me.ButtonPrintPreview.Visible = False
                        Case Else
                            LoginStatus = False
                            frm_login.ShowDialog()
                    End Select
                Else
                    frm_login.ShowDialog()
                End If
                reader.Close()
            End Using
        Catch
            MsgBox("Файл с параметрами отсутствует!" & vbCrLf & "Пожалуйста установите параметры снова.", MsgBoxStyle.Critical, "Ошибка чтения файла")
            frm_pagesetup.FontDialog1.Font = New Font("Time New Romans", 12, FontStyle.Regular)
            If frm_pagesetup.FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Using writer As New System.IO.StreamWriter(CurDir() & "\attestation_practice.ini", False, System.Text.Encoding.UTF8)
                    writer.WriteLine(frm_pagesetup.FontDialog1.Font.Name)
                    writer.WriteLine(frm_pagesetup.FontDialog1.Font.Size)
                    writer.WriteLine(frm_pagesetup.FontDialog1.Font.Bold)
                    writer.WriteLine(frm_pagesetup.FontDialog1.Font.Italic)
                    writer.WriteLine(frm_pagesetup.FontDialog1.Font.Bold And frm_pagesetup.FontDialog1.Font.Italic)
                    writer.WriteLine("False")
                    writer.Close()
                End Using
            Else
                Using writer As New System.IO.StreamWriter(CurDir() & "\attestation_practice.ini", False, System.Text.Encoding.UTF8)
                    writer.WriteLine("Times New Roman")
                    writer.WriteLine("12")
                    writer.WriteLine("False")
                    writer.WriteLine("False")
                    writer.WriteLine("False")
                    writer.WriteLine("False")
                    writer.Close()
                End Using
                MsgBox("Значения выставлены по умолчанию.", MsgBoxStyle.Information, "Значения по умолчанию")
            End If
            GoTo start
        End Try
        If LoginStatus = False Then End
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_uch_practika". При необходимости она может быть перемещена или удалена.
        Me.Qr_uch_practikaTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_uch_practika)
        Me.CenterToScreen()
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_journal_rating". При необходимости она может быть перемещена или удалена.
        Me.Tbl_journal_ratingTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_journal_rating)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_journal_rating". При необходимости она может быть перемещена или удалена.
        Me.Tbl_journal_ratingTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_journal_rating)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_stat_sved". При необходимости она может быть перемещена или удалена.
        Me.Tbl_stat_svedTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_stat_sved)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_vid_rabot". При необходимости она может быть перемещена или удалена.
        Me.Tbl_vid_rabotTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_vid_rabot)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_org". При необходимости она может быть перемещена или удалена.
        Me.Tbl_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_org)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_otv_lico_org". При необходимости она может быть перемещена или удалена.
        Me.Qr_otv_lico_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_otv_lico_org)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_otv_lico_org". При необходимости она может быть перемещена или удалена.
        Me.Tbl_otv_lico_orgTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_otv_lico_org)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_ruckovod_practiki". При необходимости она может быть перемещена или удалена.
        Me.Qr_ruckovod_practikiTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_ruckovod_practiki)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_ruckovod_practiki". При необходимости она может быть перемещена или удалена.
        Me.Tbl_ruckovod_practikiTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_ruckovod_practiki)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.qr_stud". При необходимости она может быть перемещена или удалена.
        Me.Qr_studTableAdapter.Fill(Me.Attestation_practiceDataSet.qr_stud)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_uch_practika". При необходимости она может быть перемещена или удалена.
        Me.Tbl_uch_practikaTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_uch_practika)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_stud". При необходимости она может быть перемещена или удалена.
        Me.Tbl_studTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_stud)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_spec". При необходимости она может быть перемещена или удалена.
        Me.Tbl_specTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_spec)
        TblspecBindingSource.Sort = "nam_spec ASC"
        QrstudBindingSource.Sort = "fio_stud ASC"
        Qr_uch_practikaBindingSource.Sort = "nam_prof_modul_uch_practiki ASC"
        TbluchpractikaBindingSource1.Sort = "nam_uch_practiki ASC"
        QrotvlicoorgBindingSource.Sort = "fio_otv_lico_org ASC"
        QrruckovodpractikiBindingSource.Sort = "fio_ruckovod_practiki ASC"
        TblorgBindingSource.Sort = "nam_org ASC"
        ComboBoxTbl_spec.SelectedIndex = -1
        ComboBoxKurs.SelectedIndex = -1
        ComboBoxTbl_stud.SelectedIndex = -1
        ComboBoxTbl_uch_practika_modul.SelectedIndex = -1
        ComboBoxTbl_uch_practika.SelectedIndex = -1
        ComboBoxTbl_otv_lico.SelectedIndex = -1
        ComboBoxTbl_rukovod_praktiki.SelectedIndex = -1
        TextBoxHour.Text = ""
        'TblvidrabotBindingSource.Filter = "id_uch_practika_vid_rabot = 0"
        Tbl_vid_rabotDataGridView.RowHeadersVisible = False
    End Sub
    Private Sub SplitContainer1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainer1.DoubleClick
        SplitContainer1.SplitterDistance = 543
    End Sub

    Private Sub ComboBoxTbl_spec_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_spec.SelectedIndexChanged
        If CheckBoxTbl_spec.Checked = True Then
            Dim v As Integer = ComboBoxTbl_spec.SelectedValue
            Dim kurs As Integer = Val(ComboBoxKurs.Text)
            If ComboBoxTbl_spec.Text = "" Then
                QrstudBindingSource.RemoveFilter()
            Else
                If kurs = 0 Then
                    QrstudBindingSource.Filter = "id_spec_stud = " & v
                Else
                    QrstudBindingSource.Filter = "id_spec_stud = " & v & " and kurs_stud = " & kurs
                End If
                Qr_uch_practikaBindingSource.Filter = "id_spec_uch_practiki = " & v
                TbluchpractikaBindingSource1.Filter = "nam_prof_modul_uch_practiki = '" & ComboBoxTbl_uch_practika_modul.Text & "'"
                ComboBoxTbl_uch_practika_SelectedIndexChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub ComboBoxKurs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxKurs.SelectedIndexChanged
        If CheckBoxKurs.Checked = True And CheckBoxTbl_spec.Checked = True Then ComboBoxTbl_spec_SelectedIndexChanged(sender, e) : Exit Sub
        If CheckBoxKurs.Checked = True And CheckBoxTbl_spec.Checked = False Then
            Dim kurs As Integer = Val(ComboBoxKurs.Text)
            QrstudBindingSource.Filter = "kurs_stud = " & kurs
        End If
    End Sub

    Private Sub ComboBoxTbl_uch_practika_modul_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_uch_practika_modul.SelectedIndexChanged
        If CheckBoxTbl_uch_practika.Checked = True Then
            TbluchpractikaBindingSource1.Filter = "nam_prof_modul_uch_practiki = '" & ComboBoxTbl_uch_practika_modul.Text & "'"
            ComboBoxTbl_uch_practika_SelectedIndexChanged(sender, e)
        End If
    End Sub

    Private Sub ComboBoxTbl_uch_practika_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_uch_practika.SelectedIndexChanged
        If IsNothing(ComboBoxTbl_uch_practika.SelectedValue) = False Then PrevValue = ComboBoxTbl_uch_practika.SelectedValue
        If CheckBoxTbl_uch_practika1.Checked = True Then
            If ComboBoxTbl_uch_practika.Text = "" Then
                'TblvidrabotBindingSource.RemoveFilter()
            Else
                Dim v As Integer = ComboBoxTbl_uch_practika.SelectedValue
                If CheckBoxTbl_uch_practika.Checked = True And IsNothing(ComboBoxTbl_uch_practika.SelectedValue) = False Then
                    If IsNothing(ComboBoxTbl_uch_practika_modul.SelectedValue) = True Then Exit Sub
                    If IsDBNull(Attestation_practiceDataSet.tbl_uch_practika.Rows.Find(ComboBoxTbl_uch_practika.SelectedValue).Item(6)) = False Then TextBoxHour.Text = Attestation_practiceDataSet.tbl_uch_practika.Rows.Find(ComboBoxTbl_uch_practika.SelectedValue).Item(6).ToString()
                    If IsDBNull(Attestation_practiceDataSet.tbl_uch_practika.Rows.Find(ComboBoxTbl_uch_practika.SelectedValue).Item(8)) = False Then DateTimePicker1.Value = Attestation_practiceDataSet.tbl_uch_practika.Rows.Find(ComboBoxTbl_uch_practika.SelectedValue).Item(7).ToString() Else DateTimePicker1.Value = Date.Today
                    If IsDBNull(Attestation_practiceDataSet.tbl_uch_practika.Rows.Find(ComboBoxTbl_uch_practika.SelectedValue).Item(8)) = False Then DateTimePicker2.Value = Attestation_practiceDataSet.tbl_uch_practika.Rows.Find(ComboBoxTbl_uch_practika.SelectedValue).Item(8).ToString() Else DateTimePicker2.Value = Date.Today
                    DateTimePicker3.Value = DateTimePicker2.Value
                    If IsDBNull(Attestation_practiceDataSet.tbl_uch_practika.Rows.Find(ComboBoxTbl_uch_practika.SelectedValue).Item(4)) = False Then ComboBoxTbl_rukovod_praktiki.SelectedValue = Attestation_practiceDataSet.tbl_uch_practika.Rows.Find(ComboBoxTbl_uch_practika.SelectedValue).Item(4).ToString()
                    If IsDBNull(Attestation_practiceDataSet.tbl_uch_practika.Rows.Find(ComboBoxTbl_uch_practika.SelectedValue).Item(5)) = False Then ComboBoxTbl_otv_lico.SelectedValue = Attestation_practiceDataSet.tbl_uch_practika.Rows.Find(ComboBoxTbl_uch_practika.SelectedValue).Item(5).ToString()
                    TblvidrabotBindingSource.Filter = "id_uch_practika_vid_rabot = " & v
                End If
            End If
        End If
        Me.Tbl_vid_rabotTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_vid_rabot)
    End Sub

    Private Sub ComboBoxTbl_uch_practika_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_uch_practika.TextChanged
        ComboBoxTbl_uch_practika_SelectedIndexChanged(sender, e)
        v3 = True
    End Sub

    Private Sub ButtonClearTbl_spec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearTbl_spec.Click
        TblspecBindingSource.RemoveFilter()
    End Sub

    Private Sub ButtonClearTbl_stud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearTbl_stud.Click
        QrstudBindingSource.RemoveFilter()
    End Sub

    Private Sub ButtonClearTbl_uch_practika_modul_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearTbl_uch_practika_modul.Click
        TbluchpractikaBindingSource.RemoveFilter()
    End Sub

    Private Sub ButtonClearTbl_uch_practika_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearTbl_uch_practika.Click
        TbluchpractikaBindingSource1.RemoveFilter()
    End Sub

    Private Sub ButtonClearTbl_vid_rabot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearTbl_vid_rabot.Click
        TblvidrabotBindingSource.RemoveFilter()
        PrevValue = -3
        CheckBoxTbl_uch_practika1.Checked = False
    End Sub

    Private Sub ButtonPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrint.Click
        If v3 = True And vRefresh = True Then
            frm_quest_PrintDialog.ShowDialog()
            Select Case frm_quest_PrintDialog.DialogResult
                Case Windows.Forms.DialogResult.Ignore
                    v1 = True
                Case Windows.Forms.DialogResult.Retry
                    v2 = True
                    preview = False
                    WordDocument()
                    'ButtonPreview_Click(sender, e)
                    Exit Sub
                Case Windows.Forms.DialogResult.Cancel
                    frm_quest_PrintDialog.Close()
                    Exit Sub
            End Select
        End If
        If vRefresh = True And v1 = True Then
            'v1 = False
            If pChangeSetting = True Then
                If MsgBox("Внимание! Параметры были изменены!" & vbCrLf & "Для того что бы применить эти изменения необходимо обновить текущий документ!" & vbCrLf & vbCrLf & "Продолжить без обновления?", MsgBoxStyle.YesNo, "Параметры были изменены") = MsgBoxResult.No Then Exit Sub
                pChangeSetting = False
            End If
            Me.Cursor = Cursors.AppStarting
            Dim WordApp = CreateObject("Word.Application")
            Dim WordDoc As Word.Document
            WordDoc = WordApp.Documents.Add(CurDir() & "\attestation_practice_tmp.htm")
            WordApp.ActiveDocument.SaveAs(CurDir() & "\attestation_practice_tmp", FileFormat:=16)
            WordDoc.Close()
            WordDoc = WordApp.Documents.Add(CurDir() & "\attestation_practice_tmp.docx")
            WordDoc.ActiveWindow.View.Type = Word.WdViewType.wdPrintPreview
            WordApp.Visible = True
            Me.Cursor = Cursors.Default
            Me.WindowState = FormWindowState.Minimized
            WordApp.Dialogs.Item(Word.WdWordDialog.wdDialogFilePrint).Show()
            'WebBrowser1.ShowPrintDialog()
        Else
            v2 = True
            preview = False
            WordDocument()
            'ButtonPreview_Click(sender, e)
        End If
    End Sub

    Private Sub ButtonPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrintPreview.Click
        Me.Cursor = Cursors.AppStarting
        WebBrowser1.ShowPrintPreviewDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ButtonExportToWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportToWord.Click
        If v3 = True And vRefresh = True Then
            frm_quest_Export_to_Word.ShowDialog()
            Select Case frm_quest_Export_to_Word.DialogResult
                Case Windows.Forms.DialogResult.Ignore
                Case Windows.Forms.DialogResult.Retry
                    preview = False
                    WordDocument()
                    Exit Sub
                Case Windows.Forms.DialogResult.Cancel
                    frm_quest_Export_to_Word.Close()
                    Exit Sub
            End Select
        End If
        If vRefresh = True Then
            If pChangeSetting = True Then
                If MsgBox("Внимание! Параметры были изменены!" & vbCrLf & "Для того что бы применить эти изменения необходимо обновить текущий документ!" & vbCrLf & vbCrLf & "Продолжить без обновления?", MsgBoxStyle.YesNo, "Параметры были изменены") = MsgBoxResult.No Then Exit Sub
                pChangeSetting = False
            End If
            Me.Cursor = Cursors.AppStarting
            Dim WordApp = CreateObject("Word.Application")
            Dim WordDoc As Word.Document
            WordDoc = WordApp.Documents.Add(CurDir() & "\attestation_practice_tmp.htm")
            WordApp.ActiveDocument.SaveAs(CurDir() & "\attestation_practice_tmp", FileFormat:=16)
            WordDoc.Close()
            WordDoc = WordApp.Documents.Add(CurDir() & "\attestation_practice_tmp.docx")
            WordDoc.ActiveWindow.View.Type = Word.WdViewType.wdPrintView
            WordApp.visible = True
            Me.Cursor = Cursors.Default
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
        End If
        preview = False
        WordDocument()
        Exit Sub
    End Sub

    Sub Loading()
        If ErrorPreview = True Then frm_loading.Label1.Text = "Пожалуйста подождите идёт восстановление файла страницы предварительного просмотра по умолчанию." : ErrorPreview = False
        If LoadingLogin = True Then frm_loading.Label1.Text = "Добро пожаловать!" & vbCrLf & "Пожалуйста подождите. Идёт загрузка..." : LoadingLogin = False
        frm_loading.ShowDialog()
    End Sub

    Sub LoadingClose()
        frm_loading.Close()
        Th.Abort()
    End Sub
    Dim pQuestParam = True
    Private Sub WordDocument()
        If pQuestParam = True Then
            If ComboBoxTbl_spec.Text = "" Or ComboBoxKurs.Text = "" Or ComboBoxTbl_stud.Text = "" Or ComboBoxTbl_uch_practika_modul.Text = "" Or ComboBoxTbl_uch_practika.Text = "" Or TextBoxHour.Text = "" Or DateTimePicker1.Text = "" Or DateTimePicker2.Text = "" Or DateTimePicker3.Text = "" Or ComboBoxTbl_rukovod_praktiki.Text = "" Or ComboBoxTbl_otv_lico.Text = "" Or ComboBoxTbl_org.Text = "" Then
                Dim txtquestion As String = ""
                Dim val As Boolean = False
                If ComboBoxTbl_spec.Text = "" Then txtquestion = "специальность" : val = True
                If ComboBoxKurs.Text = "" Then
                    If val = True Then txtquestion = txtquestion & ", курс" Else txtquestion = "курс" : val = True
                End If
                If ComboBoxTbl_stud.Text = "" Then
                    If val = True Then txtquestion = txtquestion & ", имя студента (курсанта)" Else txtquestion = "имя студента (курсанта)" : val = True
                    vStudent = True
                Else
                    vStudent = False
                End If
                If ComboBoxTbl_uch_practika_modul.Text = "" Then
                    If val = True Then txtquestion = txtquestion & ", профессиональный модуль" Else txtquestion = "профессиональный модуль" : val = True
                End If
                If ComboBoxTbl_uch_practika.Text = "" Then
                    If val = True Then txtquestion = txtquestion & ", вид учебной практики" Else txtquestion = "вид учебной практики" : val = True
                End If
                If TextBoxHour.Text = "" Then
                    If val = True Then txtquestion = txtquestion & ", объём (часы)" Else txtquestion = "объём (часы)" : val = True
                End If
                If DateTimePicker1.Text = "" Then
                    If val = True Then txtquestion = txtquestion & ", дату начала практики" Else txtquestion = "дату начала практики" : val = True
                End If
                If DateTimePicker2.Text = "" Then
                    If val = True Then txtquestion = txtquestion & ", дату окончания практики" Else txtquestion = "дату окончания практики" : val = True
                End If
                If DateTimePicker3.Text = "" Then
                    If val = True Then txtquestion = txtquestion & ", дату оценивания" Else txtquestion = "дату оценивания" : val = True
                End If
                If ComboBoxTbl_rukovod_praktiki.Text = "" Then
                    If val = True Then txtquestion = txtquestion & ", руководителя учебной практики" Else txtquestion = "руководителя учебной практики" : val = True
                End If
                If ComboBoxTbl_otv_lico.Text = "" Then
                    If val = True Then txtquestion = txtquestion & ", ответственное лицо организации" Else txtquestion = "ответственное лицо организации" : val = True
                End If
                If ComboBoxTbl_org.Text = "" Then
                    If val = True Then txtquestion = txtquestion & ", организацию" Else txtquestion = "организацию"
                End If
                If MsgBox("Вы не указали: " & txtquestion & "! Продолжить?", MsgBoxStyle.YesNo, "Ошибка экспорта в Microsoft Word") = MsgBoxResult.No Then v2 = False : Exit Sub
            Else
                vStudent = False
            End If
        Else
            pQuestParam = True
        End If
0:      Th = New System.Threading.Thread(AddressOf Loading)
        Th.SetApartmentState(ApartmentState.STA)
        Th.Start()
        FormEnabledTrueFalse()

        v3 = False
        Dim WordApp = CreateObject("Word.Application")
        Dim WordDoc As Word.Document
        'If preview = False Then WordApp.visible = True Else WordApp.visible = False
        If preview = False Then WordApp.visible = False
        WordDoc = WordApp.Documents.Add()
        Dim DocTable1 As Word.Table
        Dim DocTable2 As Word.Table
        Dim DocTable3 As Word.Table
        Dim DocTableFio As Word.Table
        Dim TableP1 As Word.Paragraph
        Dim TableP2 As Word.Paragraph
        Dim TableP3 As Word.Paragraph
        Dim TableP4 As Word.Paragraph
        Dim TableP5 As Word.Paragraph
        Dim TableP6 As Word.Paragraph
        Dim lm, bm, rm, tm As Object
        Dim r As Integer
        Dim RangeText
        Dim RangeTextDocTable2
        RatingAvg = 0
        vRatingAvg = False
        v2RatingAvg = False
        uchpractika = ComboBoxTbl_uch_practika.SelectedValue
        lm = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup", "margin_left", "")
        bm = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup", "margin_bottom", "")
        rm = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup", "margin_right", "")
        tm = My.Computer.Registry.GetValue("HKEY_CURRENT_USER\Software\Microsoft\Internet Explorer\PageSetup", "margin_top", "")
        Dim slm, sbm, srm, stm As Single
        Dim k As Integer = 0
        For i = 1 To Len(lm)
            If Mid(lm, i, 1) = "." Then slm = Mid(lm, 1, i - 1) & "," & Mid(lm, i + 1, Len(lm)) : Exit For
        Next
        If k >= 1 Then slm = lm : k = 0
        For i = 1 To Len(bm)
            If Mid(bm, i, 1) = "." Then sbm = Mid(bm, 1, i - 1) & "," & Mid(bm, i + 1, Len(bm)) : Exit For
        Next
        If k >= 1 Then sbm = bm : k = 0
        For i = 1 To Len(rm)
            If Mid(rm, i, 1) = "." Then srm = Mid(rm, 1, i - 1) & "," & Mid(rm, i + 1, Len(rm)) : Exit For
        Next
        If k >= 1 Then srm = rm : k = 0
        For i = 1 To Len(tm)
            If Mid(tm, i, 1) = "." Then stm = Mid(tm, 1, i - 1) & "," & Mid(tm, i + 1, Len(tm)) : Exit For
        Next
        If k >= 1 Then stm = tm : k = 0
        With WordDoc
            .PageSetup.LeftMargin = slm / 10 * 25.4 * 28.3333333
            .PageSetup.BottomMargin = sbm / 10 * 25.4 * 28.3333333
            .PageSetup.RightMargin = srm / 10 * 25.4 * 28.3333333
            .PageSetup.TopMargin = stm / 10 * 25.4 * 28.3333333
        End With
        Dim fname As String
        Dim fsize As Single
        Dim fbold As Boolean
        Dim fitalic As Boolean
        Dim fboldfitalic As Boolean
        Dim fstyle As System.Drawing.FontStyle = 3
        Try
            Using reader As New System.IO.StreamReader(CurDir() & "\attestation_practice.ini", System.Text.Encoding.UTF8)
                fname = reader.ReadLine()
                fsize = reader.ReadLine()
                fbold = reader.ReadLine()
                fitalic = reader.ReadLine()
                fboldfitalic = reader.ReadLine()
                reader.Close()
            End Using
        Catch ex As Exception
            If MsgBox("Файл с параметрами отсутствует! Пожалуйста установите параметры снова.", MsgBoxStyle.OkCancel, "Ошибка чтения файла") = vbOK Then
                frm_pagesetup.FontDialog1.Font = New Font("Time New Romans", 12, FontStyle.Regular)
                If frm_pagesetup.FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Using writer As New System.IO.StreamWriter(CurDir() & "\attestation_practice.ini", False, System.Text.Encoding.UTF8)
                        writer.WriteLine(frm_pagesetup.FontDialog1.Font.Name)
                        writer.WriteLine(frm_pagesetup.FontDialog1.Font.Size)
                        writer.WriteLine(frm_pagesetup.FontDialog1.Font.Bold)
                        writer.WriteLine(frm_pagesetup.FontDialog1.Font.Italic)
                        writer.WriteLine(frm_pagesetup.FontDialog1.Font.Bold And frm_pagesetup.FontDialog1.Font.Italic)
                        If menu_Remember_User.Checked = True Then
                            writer.WriteLine("True")
                            Select Case Me.Tag
                                Case "admin"
                                    writer.WriteLine("d033e22ae348aeb5660fc2140aec35850c4da997")
                                Case "manager"
                                    writer.WriteLine("1a8565a9dc72048ba03b4156be3e569f22771f23")
                                Case "test"
                                    writer.WriteLine("a94a8fe5ccb19ba61c4c0873d391e987982fbbd3")
                                Case Else
                                    writer.WriteLine("1a8565a9dc72048ba03b4156be3e569f22771f23")
                            End Select
                        Else
                            writer.WriteLine("False")
                        End If
                        writer.Close()
                    End Using
                Else
                    Using writer As New System.IO.StreamWriter(CurDir() & "\attestation_practice.ini", False, System.Text.Encoding.UTF8)
                        writer.WriteLine("Times New Roman")
                        writer.WriteLine("12")
                        writer.WriteLine("False")
                        writer.WriteLine("False")
                        writer.WriteLine("False")
                        If menu_Remember_User.Checked = True Then
                            writer.WriteLine("True")
                            Select Case Me.Tag
                                Case "admin"
                                    writer.WriteLine("d033e22ae348aeb5660fc2140aec35850c4da997")
                                Case "manager"
                                    writer.WriteLine("1a8565a9dc72048ba03b4156be3e569f22771f23")
                                Case "test"
                                    writer.WriteLine("a94a8fe5ccb19ba61c4c0873d391e987982fbbd3")
                                Case Else
                                    writer.WriteLine("1a8565a9dc72048ba03b4156be3e569f22771f23")
                            End Select
                        Else
                            writer.WriteLine("False")
                        End If
                        writer.Close()
                    End Using
                    MsgBox("Значения выставлены по умолчанию.", MsgBoxStyle.Information, "Значения по умолчанию")
                End If
                Using reader As New System.IO.StreamReader(CurDir() & "\attestation_practice.ini", System.Text.Encoding.UTF8)
                    fname = reader.ReadLine()
                    fsize = reader.ReadLine()
                    fbold = reader.ReadLine()
                    fitalic = reader.ReadLine()
                    fboldfitalic = reader.ReadLine()
                    reader.Close()
                End Using
            Else
                MsgBox("Параметры не были установлены!", MsgBoxStyle.Critical, "Параметры не были установлены")
                Exit Sub
            End If
        End Try
        With WordDoc.Range
            .Font.Name = fname
            .Font.Color = Word.WdColor.wdColorBlack
            .Font.Size = fsize
            If fbold = False And fitalic = False Then .Font.Bold = False : .Font.Italic = False
            If fbold = True And fitalic = False Then .Font.Bold = True : .Font.Italic = False
            If fbold = False And fitalic = True Then .Font.Bold = False : .Font.Italic = True
            If fboldfitalic = True Then .Font.Bold = True : .Font.Italic = True
        End With

        'Заполнение документа
        DocTable1 = WordDoc.Tables.Add(WordDoc.Bookmarks.Item("\StartOfDoc").Range, 1, 1)
        With DocTable1
            .Range.ParagraphFormat.SpaceBefore = 0
            .Range.ParagraphFormat.SpaceAfter = 0
            .Range.ParagraphFormat.LineSpacingRule = Word.WdLineSpacing.wdLineSpaceSingle
            .Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter
            .Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle
            .Borders.OutsideLineWidth = Word.WdLineWidth.wdLineWidth050pt
            .Cell(1, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
        End With

        'Добавление заголовка
        TableP1 = DocTable1.Cell(1, 1).Range.Paragraphs.Add(WordDoc.Bookmarks.Item("\Table").Range)
        TableP1.Range.Bold = True
        TableP1.Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(4)(1)
        TableP1.Range.ParagraphFormat.SpaceBefore = 6
        TableP1.Range.ParagraphFormat.SpaceAfter = 6
        TableP1.Range.InsertParagraphAfter()
        TableP1.Range.ParagraphFormat.SpaceBefore = 0
        TableP1.Range.ParagraphFormat.SpaceAfter = 0

        'Добавление ФИО
        WordDoc.Paragraphs(1).Range.Select()
        DocTableFio = WordDoc.Tables.Add(WordDoc.Bookmarks.Item("\EndOfSel").Range, 1, 2)
        With DocTableFio
            .Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter
            .Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            .Range.ParagraphFormat.SpaceAfter = 0
            .Range.ParagraphFormat.SpaceBefore = 0
            .Range.Bold = True
            'If fbold = True And fitalic = False Then .Range.Bold = True : .Range.Italic = False
            If fbold = False And fitalic = True Then .Range.Italic = True
            If fboldfitalic = True Then .Range.Bold = True : .Range.Italic = True
            .Cell(1, 1).Borders(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleSingle
            .Cell(1, 1).Range.Text = ComboBoxTbl_stud.Text
            .Cell(1, 1).PreferredWidth = 400
            .Cell(1, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            .Cell(1, 2).PreferredWidth = 25
            .Cell(1, 2).Range.Text = ","
        End With

        'Добавление вводных сведений
        WordDoc.Paragraphs(4).Range.Select()
        TableP2 = DocTable1.Cell(1, 1).Range.Paragraphs.Add(WordDoc.Bookmarks.Item("\EndOfSel").Range)
        With TableP2
            .Range.Bold = False
            If fbold = True And fitalic = False Then .Range.Bold = True : .Range.Italic = False
            If fbold = False And fitalic = True Then .Range.Bold = False : .Range.Italic = True
            If fboldfitalic = True Then .Range.Bold = True : .Range.Italic = True
        End With
        If vStudent = True Then GoTo 1
        Try
            If Attestation_practiceDataSet.tbl_stud.Rows.Find(ComboBoxTbl_stud.SelectedValue).Item(6) = "м" Then pol = "m" Else pol = "f"
        Catch ex As Exception
            GoTo 1
        End Try
2:      If pol = "m" Then TableP2.Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(5)(1) Else TableP2.Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(6)(1)
        With TableP2.Range()
            .InsertAfter(" ")
            If ComboBoxKurs.Text = "" Then .InsertAfter("__") Else .InsertAfter(ComboBoxKurs.Text)
            .InsertAfter(" ")
            .InsertAfter(Attestation_practiceDataSet.tbl_stat_sved.Rows(7)(1))
            .InsertAfter(" ")
            If ComboBoxTbl_spec.Text = "" Then .InsertAfter("_____________________________") Else .InsertAfter(ComboBoxTbl_spec.Text)
            .InsertAfter(vbCrLf)
            If pol = "m" Then .InsertAfter(Attestation_practiceDataSet.tbl_stat_sved.Rows(8)(1)) Else .InsertAfter(Attestation_practiceDataSet.tbl_stat_sved.Rows(0)(1))
            .InsertAfter(vbCrLf)
            .InsertAfter(Attestation_practiceDataSet.tbl_stat_sved.Rows(1)(1))
            .InsertAfter(" ")
            If ComboBoxTbl_uch_practika_modul.Text = "" Then .InsertAfter("_____________________________________") Else .InsertAfter(ComboBoxTbl_uch_practika_modul.Text)
            .InsertAfter(vbCrLf)
            .InsertAfter(Attestation_practiceDataSet.tbl_stat_sved.Rows(9)(1))
            .InsertAfter(" ")
            If TextBoxHour.Text = "" Then .InsertAfter("__") Else .InsertAfter(TextBoxHour.Text)
            .InsertAfter(" часов с ")
            .InsertAfter(DateTimePicker1.Text)
            .InsertAfter(" по ")
            .InsertAfter(DateTimePicker2.Text)
            .InsertAfter(vbCrLf)
            .InsertAfter(Attestation_practiceDataSet.tbl_stat_sved.Rows(10)(1))
            .InsertAfter(" ")
            If ComboBoxTbl_org.Text = "" Then .InsertAfter("_______________________________________________________") Else .InsertAfter(ComboBoxTbl_org.Text)
            .InsertAfter(vbCrLf)
        End With

        'Добавление перечня выполненных работ
        If PrevValue = -3 Then
            TblvidrabotBindingSource.Filter = "check_vid_rabot = true"
        Else
            If IsNothing(ComboBoxTbl_uch_practika.SelectedValue) = False Then
                If CheckBoxTbl_uch_practika1.Checked = True Then TblvidrabotBindingSource.Filter = "id_uch_practika_vid_rabot = " & ComboBoxTbl_uch_practika.SelectedValue & " and check_vid_rabot = true" ' Else TblvidrabotBindingSource.Filter = "id_uch_practika_vid_rabot = " & PrevValue & " and check_vid_rabot = true"
            Else
                If PrevValue = -2 Then TblvidrabotBindingSource.Filter = "check_vid_rabot = true" Else TblvidrabotBindingSource.Filter = "id_uch_practika_vid_rabot = " & PrevValue & " and check_vid_rabot = true"
            End If
        End If
        WordDoc.Paragraphs(9).Range.Select()
        DocTable2 = WordDoc.Tables.Add(WordDoc.Bookmarks.Item("\EndOfSel").Range, TblvidrabotBindingSource.Count + 3, 2)
        With DocTable2
            .Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle
            .Borders.OutsideLineWidth = Word.WdLineWidth.wdLineWidth050pt
            .Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle
            .Borders.InsideLineWidth = Word.WdLineWidth.wdLineWidth050pt
        End With
        DocTable2.Rows(1).Cells(1).Merge(DocTable2.Rows(1).Cells(2))
        DocTable2.Rows(3).Cells(1).Merge(DocTable2.Rows(3).Cells(2))
        r = 0
        With DocTable2
            .Cell(1, 1).Borders(Word.WdBorderType.wdBorderLeft).LineStyle = Word.WdLineStyle.wdLineStyleNone
            .Cell(1, 1).Borders(Word.WdBorderType.wdBorderTop).LineStyle = Word.WdLineStyle.wdLineStyleNone
            .Cell(1, 1).Borders(Word.WdBorderType.wdBorderRight).LineStyle = Word.WdLineStyle.wdLineStyleNone
            .Cell(1, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            .Cell(1, 1).Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(11)(1)
            .Cell(1, 1).Range.Bold = True
            If pol = "m" Then .Cell(2, 1).Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(12)(1) Else .Cell(2, 1).Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(13)(1)
            .Cell(2, 1).Range.ParagraphFormat.SpaceBefore = 6
            .Cell(2, 1).Range.ParagraphFormat.SpaceAfter = 6
            .Cell(2, 2).Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(14)(1)
            .Cell(2, 2).Range.ParagraphFormat.SpaceBefore = 6
            .Cell(2, 2).Range.ParagraphFormat.SpaceAfter = 6
            .Rows(2).Cells(1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
            .Rows(2).Cells(2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
            If ComboBoxTbl_uch_practika.Text = "" Then .Cell(3, 1).Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(15)(1) & " ___________________________" Else .Cell(3, 1).Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(15)(1) & " " & Chr(171) & ComboBoxTbl_uch_practika.Text & Chr(187)
            .Cell(3, 1).Range.Bold = True
            .Cell(3, 1).Range.Italic = True
            For r = 4 To TblvidrabotBindingSource.Count + 3
                .Cell(r, 1).Range.Text = r - 3 & ". " & TblvidrabotBindingSource.Item(r - 4)(1)
                .Cell(r, 1).Range.ParagraphFormat.SpaceBefore = 6
                .Cell(r, 1).Range.ParagraphFormat.SpaceAfter = 6
                .Cell(r, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
                .Rows(r).Cells(1).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                .Rows(r).Cells(2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter
                RangeTextDocTable2 = DocTable2.Cell(r, 2).Range
                If IsDBNull(TblvidrabotBindingSource.Item(r - 4)(4)) = True Then TblvidrabotBindingSource.Item(r - 4)(4) = "0"
                If (TblvidrabotBindingSource.Item(r - 4)(4).ToString = "2" Or TblvidrabotBindingSource.Item(r - 4)(4).ToString = "3" Or TblvidrabotBindingSource.Item(r - 4)(4).ToString = "4" Or TblvidrabotBindingSource.Item(r - 4)(4).ToString = "5") = False Then TblvidrabotBindingSource.Item(r - 4)(4) = "0"

                Select Case TblvidrabotBindingSource.Item(r - 4)(4)
                    Case "5"
                        .Cell(r, 2).Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1) & " " & TblvidrabotBindingSource.Item(r - 4)(4) & " (отлично)"
                        WordDoc.Range(RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1, RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1 + Len(TblvidrabotBindingSource.Item(r - 4)(4) & " (отлично)")).Font.Italic = True
                        WordDoc.Range(RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1, RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1 + Len(TblvidrabotBindingSource.Item(r - 4)(4) & " (отлично)")).Font.Bold = True
                        WordDoc.Range(RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1, RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1 + Len(TblvidrabotBindingSource.Item(r - 4)(4) & " (отлично)")).Font.Underline = True
                        RatingAvg = RatingAvg + 5
                    Case "4"
                        .Cell(r, 2).Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1) & " " & TblvidrabotBindingSource.Item(r - 4)(4) & " (хорошо)"
                        WordDoc.Range(RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1, RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1 + Len(TblvidrabotBindingSource.Item(r - 4)(4) & " (хорошо)")).Font.Italic = True
                        WordDoc.Range(RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1, RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1 + Len(TblvidrabotBindingSource.Item(r - 4)(4) & " (хорошо)")).Font.Bold = True
                        WordDoc.Range(RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1, RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1 + Len(TblvidrabotBindingSource.Item(r - 4)(4) & " (хорошо)")).Font.Underline = True
                        RatingAvg = RatingAvg + 4
                    Case "3"
                        .Cell(r, 2).Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1) & " " & TblvidrabotBindingSource.Item(r - 4)(4) & " (удовлетворительно)"
                        WordDoc.Range(RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1, RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1 + Len(TblvidrabotBindingSource.Item(r - 4)(4) & " (удовлетворительно)")).Font.Italic = True
                        WordDoc.Range(RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1, RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1 + Len(TblvidrabotBindingSource.Item(r - 4)(4) & " (удовлетворительно)")).Font.Bold = True
                        WordDoc.Range(RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1, RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1 + Len(TblvidrabotBindingSource.Item(r - 4)(4) & " (удовлетворительно)")).Font.Underline = True
                        RatingAvg = RatingAvg + 3
                    Case "2"
                        .Cell(r, 2).Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1) & " " & TblvidrabotBindingSource.Item(r - 4)(4) & " (неудовлетворительно)"
                        WordDoc.Range(RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1, RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1 + Len(TblvidrabotBindingSource.Item(r - 4)(4) & " (неудовлетворительно)")).Font.Italic = True
                        WordDoc.Range(RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1, RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1 + Len(TblvidrabotBindingSource.Item(r - 4)(4) & " (неудовлетворительно)")).Font.Bold = True
                        WordDoc.Range(RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1, RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1 + Len(TblvidrabotBindingSource.Item(r - 4)(4) & " (неудовлетворительно)")).Font.Underline = True
                        RatingAvg = RatingAvg + 2
                        v2RatingAvg = True
                    Case Else
                        .Cell(r, 2).Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1) & " ___________"
                        WordDoc.Range(RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString) + 1, RangeTextDocTable2.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(3)(1).ToString & " ___________") + 1).Font.Bold = True
                        vRatingAvg = True
                End Select
                .Cell(r, 2).Range.ParagraphFormat.SpaceBefore = 6
                .Cell(r, 2).Range.ParagraphFormat.SpaceAfter = 6
                .PreferredWidthType = Word.WdPreferredWidthType.wdPreferredWidthAuto
            Next
            RatingAvg = RatingAvg / TblvidrabotBindingSource.Count
        End With


        'Описание характеристики
        WordDoc.Paragraphs(16 + TblvidrabotBindingSource.Count * 3).Range.Select()
        TableP3 = DocTable1.Cell(1, 1).Range.Paragraphs.Add(WordDoc.Bookmarks.Item("\EndOfSel").Range)
        With TableP3
            .Range.Bold = True
            'If fbold = True And fitalic = False Then .Range.Bold = True : .Range.Italic = False
            If fbold = False And fitalic = True Then .Range.Italic = True
            If fboldfitalic = True Then .Range.Bold = True : .Range.Italic = True
        End With
        If pol = "m" Then TableP3.Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(16)(1) & " " & Attestation_practiceDataSet.tbl_stat_sved.Rows(2)(1) & ":" Else TableP3.Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(17)(1) & " " & Attestation_practiceDataSet.tbl_stat_sved.Rows(2)(1) & ":"
        TableP3.Format.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
        RangeText = TableP3.Range
        If pol = "m" Then
            With WordDoc.Range(RangeText.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(16)(1).ToString) + 1, RangeText.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(16)(1).ToString) + 1 + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(2)(1)))
                .Font.Italic = True
                .Font.Bold = False
                If fbold = True And fitalic = False Then .Font.Bold = True : .Font.Italic = False
                If fbold = False And fitalic = True Then .Font.Bold = False : .Font.Italic = True
                If fboldfitalic = True Then .Font.Bold = True : .Font.Italic = True
            End With
        Else
            With WordDoc.Range(RangeText.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(17)(1).ToString) + 1, RangeText.Start + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(17)(1).ToString) + 1 + Len(Attestation_practiceDataSet.tbl_stat_sved.Rows(2)(1)))
                .Font.Italic = True
                .Font.Bold = False
                If fbold = True And fitalic = False Then .Font.Bold = True : .Font.Italic = False
                If fbold = False And fitalic = True Then .Font.Bold = False : .Font.Italic = True
                If fboldfitalic = True Then .Font.Bold = True : .Font.Italic = True
            End With
        End If
        TableP3.Range.ParagraphFormat.SpaceAfter = 0
        TableP3.Range.InsertAfter(vbCrLf)
        TableP3.Range.InsertAfter(vbCrLf)
        With TableP3
            .Range.Italic = True
            If fbold = True And fitalic = False Then .Range.Bold = True : .Range.Italic = False
            If fbold = False And fitalic = True Then .Range.Bold = False : .Range.Italic = True
            If fboldfitalic = True Then .Range.Bold = True : .Range.Italic = True
        End With
        TableP3.Format.LineSpacingRule = 1
        TableP3.Format.FirstLineIndent = 1 * 28.3465

        'Характеристика
        WordDoc.Paragraphs(18 + TblvidrabotBindingSource.Count * 3).Range.Select()
        TableP4 = DocTable1.Cell(1, 1).Range.Paragraphs.Add(WordDoc.Bookmarks.Item("\EndOfSel").Range)

        Dim select1 As Integer = 0
        frm_charact_generator.ShowDialog()

        'переменная для путешествия по документу
        select1 = 23 + TblvidrabotBindingSource.Count * 3
        If frm_charact_generator.DialogResult = Windows.Forms.DialogResult.Cancel Then
            TableP4.Range.Text = " "
            TableP4.Range.InsertAfter(vbCrLf)
            TableP4.Range.InsertAfter(vbCrLf)
            TableP4.Range.InsertAfter(vbCrLf)
            TableP4.Range.InsertAfter(vbCrLf)
        Else
            TableP4.Range.Text = frm_charact_generator.TextBox1.Text
            TableP4.Range.InsertAfter(vbCrLf)
            TableP4.Range.Text = frm_charact_generator.TextBox2.Text
            TableP4.Range.InsertAfter(vbCrLf)
            TableP4.Range.Text = frm_charact_generator.TextBox3.Text
            TableP4.Range.InsertAfter(vbCrLf)
            TableP4.Range.Text = frm_charact_generator.TextBox4.Text
            TableP4.Range.InsertAfter(vbCrLf)
        End If
        If ReDoc = True Then GoTo 10
        TableP4.Range.InsertAfter(vbCrLf)
        TableP4.Format.FirstLineIndent = 0
        TableP4.Range.ParagraphFormat.SpaceAfter = 6
        With TableP4
            .Range.Italic = False
            If fbold = True And fitalic = False Then .Range.Bold = True : .Range.Italic = False
            If fbold = False And fitalic = True Then .Range.Bold = False : .Range.Italic = True
            If fboldfitalic = True Then .Range.Bold = True : .Range.Italic = True
        End With

        TableP3.Format.LineSpacingRule = 0

        'Дата оценивания
        WordDoc.Paragraphs(select1).Range.Select()
        TableP5 = DocTable1.Cell(1, 1).Range.Paragraphs.Add(WordDoc.Bookmarks.Item("\EndOfSel").Range)
        TableP5.Range.ParagraphFormat.SpaceAfter = 6
        With TableP5
            .Range.Italic = False
            If fbold = True And fitalic = False Then .Range.Bold = True : .Range.Italic = False
            If fbold = False And fitalic = True Then .Range.Bold = False : .Range.Italic = True
            If fboldfitalic = True Then .Range.Bold = True : .Range.Italic = True
        End With

        TableP5.Format.FirstLineIndent = 0
        TableP3.Format.LineSpacingRule = 0
        Select Case DateTimePicker3.Value.Month
            Case 1
                TableP5.Range.Text = "Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " января " & DateTimePicker3.Value.Year & " г."
                RangeText = TableP5.Range
                WordDoc.Range(RangeText.Start + 5, RangeText.Start + Len("Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " января " & DateTimePicker3.Value.Year & " г.")).Font.Underline = True
            Case 2
                TableP5.Range.Text = "Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " февраля " & DateTimePicker3.Value.Year & " г."
                RangeText = TableP5.Range
                WordDoc.Range(RangeText.Start + 5, RangeText.Start + Len("Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " февраля " & DateTimePicker3.Value.Year & " г.")).Font.Underline = True
            Case 3
                TableP5.Range.Text = "Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " марта " & DateTimePicker3.Value.Year & " г."
                RangeText = TableP5.Range
                WordDoc.Range(RangeText.Start + 5, RangeText.Start + Len("Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " марта " & DateTimePicker3.Value.Year & " г.")).Font.Underline = True
            Case 4
                TableP5.Range.Text = "Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " апреля " & DateTimePicker3.Value.Year & " г."
                RangeText = TableP5.Range
                WordDoc.Range(RangeText.Start + 5, RangeText.Start + Len("Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " апреля " & DateTimePicker3.Value.Year & " г.")).Font.Underline = True
            Case 5
                TableP5.Range.Text = "Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " мая " & DateTimePicker3.Value.Year & " г."
                RangeText = TableP5.Range
                WordDoc.Range(RangeText.Start + 5, RangeText.Start + Len("Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " мая " & DateTimePicker3.Value.Year & " г.")).Font.Underline = True
            Case 6
                TableP5.Range.Text = "Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " июня " & DateTimePicker3.Value.Year & " г."
                RangeText = TableP5.Range
                WordDoc.Range(RangeText.Start + 5, RangeText.Start + Len("Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " июня " & DateTimePicker3.Value.Year & " г.")).Font.Underline = True
            Case 7
                TableP5.Range.Text = "Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " июля " & DateTimePicker3.Value.Year & " г."
                RangeText = TableP5.Range
                WordDoc.Range(RangeText.Start + 5, RangeText.Start + Len("Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " июля " & DateTimePicker3.Value.Year & " г.")).Font.Underline = True
            Case 8
                TableP5.Range.Text = "Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " августа " & DateTimePicker3.Value.Year & " г."
                RangeText = TableP5.Range
                WordDoc.Range(RangeText.Start + 5, RangeText.Start + Len("Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " августа " & DateTimePicker3.Value.Year & " г.")).Font.Underline = True
            Case 9
                TableP5.Range.Text = "Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " сентября " & DateTimePicker3.Value.Year & " г."
                RangeText = TableP5.Range
                WordDoc.Range(RangeText.Start + 5, RangeText.Start + Len("Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " сентября " & DateTimePicker3.Value.Year & " г.")).Font.Underline = True
            Case 10
                TableP5.Range.Text = "Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " октября " & DateTimePicker3.Value.Year & " г."
                RangeText = TableP5.Range
                WordDoc.Range(RangeText.Start + 5, RangeText.Start + Len("Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " октября " & DateTimePicker3.Value.Year & " г.")).Font.Underline = True
            Case 11
                TableP5.Range.Text = "Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " ноября " & DateTimePicker3.Value.Year & " г."
                RangeText = TableP5.Range
                WordDoc.Range(RangeText.Start + 5, RangeText.Start + Len("Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " ноября " & DateTimePicker3.Value.Year & " г.")).Font.Underline = True
            Case 12
                TableP5.Range.Text = "Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " декабря " & DateTimePicker3.Value.Year & " г."
                RangeText = TableP5.Range
                WordDoc.Range(RangeText.Start + 5, RangeText.Start + Len("Дата " & Chr(171) & " " & DateTimePicker3.Value.Day & " " & Chr(187) & " декабря " & DateTimePicker3.Value.Year & " г.")).Font.Underline = True
        End Select
        TableP5.Range.InsertAfter(vbCrLf)
        TableP5.Range.Font.Underline = False

        'Подписи
        WordDoc.Paragraphs(select1 + 1).Range.Select()
        DocTable3 = WordDoc.Tables.Add(WordDoc.Bookmarks.Item("\EndOfSel").Range, 2, 4)
        With DocTable3
            .Cell(1, 2).Borders(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleSingle
            .Cell(1, 2).Borders(Word.WdBorderType.wdBorderBottom).LineWidth = Word.WdLineWidth.wdLineWidth050pt
            .Cell(1, 3).Borders(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleSingle
            .Cell(1, 3).Borders(Word.WdBorderType.wdBorderBottom).LineWidth = Word.WdLineWidth.wdLineWidth050pt
            .Cell(1, 4).Borders(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleSingle
            .Cell(1, 4).Borders(Word.WdBorderType.wdBorderBottom).LineWidth = Word.WdLineWidth.wdLineWidth050pt
            .Cell(2, 2).Borders(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleSingle
            .Cell(2, 2).Borders(Word.WdBorderType.wdBorderBottom).LineWidth = Word.WdLineWidth.wdLineWidth050pt
            .Cell(2, 3).Borders(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleSingle
            .Cell(2, 3).Borders(Word.WdBorderType.wdBorderBottom).LineWidth = Word.WdLineWidth.wdLineWidth050pt
            .Cell(2, 4).Borders(Word.WdBorderType.wdBorderBottom).LineStyle = Word.WdLineStyle.wdLineStyleSingle
            .Cell(2, 4).Borders(Word.WdBorderType.wdBorderBottom).LineWidth = Word.WdLineWidth.wdLineWidth050pt
            .Cell(1, 1).Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(18)(1)
            .Cell(2, 1).Range.Text = Attestation_practiceDataSet.tbl_stat_sved.Rows(19)(1)
            .Cell(1, 2).Range.Text = "/"
            .Cell(1, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            .Rows(1).Cells(2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalBottom
            .Cell(2, 2).Range.Text = "/"
            .Cell(2, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight
            .Rows(2).Cells(2).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalBottom
            .Cell(1, 4).Range.Text = "/"
            .Cell(1, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            .Rows(1).Cells(4).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalBottom
            .Cell(2, 4).Range.Text = "/"
            .Cell(2, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft
            .Rows(2).Cells(4).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalBottom
            .Cell(1, 3).Range.Text = ComboBoxTbl_rukovod_praktiki.Text
            .Cell(1, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            .Rows(1).Cells(3).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalBottom
            .Cell(2, 3).Range.Text = ComboBoxTbl_otv_lico.Text
            .Cell(2, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter
            .Rows(2).Cells(3).VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalBottom
            .Cell(1, 4).PreferredWidth = 5
            .Cell(2, 4).PreferredWidth = 5

            .AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent)
            .Cell(1, 1).PreferredWidth = 200
            .Cell(2, 1).PreferredWidth = 200
            .Cell(1, 2).PreferredWidth = 130
            .Cell(2, 2).PreferredWidth = 130
            .Cell(1, 3).PreferredWidth = 200
            .Cell(2, 3).PreferredWidth = 200
            .Cell(1, 1).LeftPadding = 0
            .Cell(2, 1).LeftPadding = 0

        End With
        WordDoc.Paragraphs(select1 + 11).Range.Select()
        TableP6 = DocTable1.Cell(1, 1).Range.Paragraphs.Add(WordDoc.Bookmarks.Item("\EndOfSel").Range)
        TableP6.Range.Text = " "
        TableP6.Range.Font.Size = 8
        TableP6.Range.ParagraphFormat.SpaceAfter = 0

        If preview = True Then
            WebBrowser1.Navigate(CurDir() & "\attestation_practice_default.htm")
            Try
                WordApp.ActiveDocument.SaveAs(CurDir() & "\attestation_practice_tmp", FileFormat:=8)
                WordApp.Documents.Close()
                WordApp.Quit()
                WordApp = Nothing
                GC.Collect()
            Catch ex As Exception
                If MsgBox("Не удалось сохранить документ для предварительного просмотра! Попробовать снова?", MsgBoxStyle.YesNo, "Ошибка загрузки предварительного просмотра") = MsgBoxResult.Yes Then GoTo 0
            End Try
            Try
                WebBrowser1.Navigate(CurDir() & "\attestation_practice_tmp.htm")
                Me.Focus()
                Me.WebBrowser1.Focus()
            Catch ex As Exception
                If MsgBox("Не удалось загрузить предварительный просмотр! Попробовать снова?", MsgBoxStyle.YesNo, "Ошибка загрузки предварительного просмотра") = MsgBoxResult.Yes Then GoTo 0
            End Try
        Else
            WordDoc.ActiveWindow.View.Type = Word.WdViewType.wdPrintView
            WordApp.Visible = True
            Me.WindowState = FormWindowState.Minimized
        End If

        'Сохранение значений в истории
        Tbl_journal_ratingBindingSource.Filter = ""
        If IsNothing(ComboBoxTbl_spec.SelectedValue) = False Then
            If IsNothing(ComboBoxKurs.Text) = False Then
                If IsNothing(ComboBoxTbl_stud.SelectedValue) = False Then

                End If
            End If
            If IsNothing(ComboBoxTbl_uch_practika_modul.SelectedValue) = False Then

            End If
            If IsNothing(ComboBoxTbl_uch_practika.SelectedValue) = False Then

            End If
            If IsNothing(ComboBoxTbl_rukovod_praktiki.SelectedValue) = False Then

            End If
            If IsNothing(ComboBoxTbl_otv_lico.SelectedValue) = False Then

            End If
            If IsNothing(ComboBoxTbl_org.SelectedValue) = False Then

            End If
        End If

        If PrevValue = -3 Then
            TblvidrabotBindingSource.RemoveFilter()
        Else
            If IsNothing(ComboBoxTbl_uch_practika.SelectedValue) = False Then
                If CheckBoxTbl_uch_practika1.Checked = True Then TblvidrabotBindingSource.Filter = "id_uch_practika_vid_rabot = " & ComboBoxTbl_uch_practika.SelectedValue ' Else TblvidrabotBindingSource.Filter = "id_uch_practika_vid_rabot = " & PrevValue
            Else
                If PrevValue = -2 Then TblvidrabotBindingSource.RemoveFilter() Else TblvidrabotBindingSource.Filter = "id_uch_practika_vid_rabot = " & PrevValue
            End If
        End If

        'ComboBoxTbl_uch_practika_modul_SelectedIndexChanged(ComboBoxTbl_uch_practika_modul, New EventArgs())

10:     LoadingClose()
        FormEnabledTrueFalse()
        If ReDoc = True Then
            ReDoc = False
            pQuestParam = False
            WordDocument()
            Exit Sub
        End If
        If v2 = True Then
            Me.Cursor = Cursors.AppStarting
            WordDoc.ActiveWindow.View.Type = Word.WdViewType.wdPrintPreview
            WordApp.Visible = True
            Me.Cursor = Cursors.Default
            Me.WindowState = FormWindowState.Minimized
            WordApp.Dialogs.Item(Word.WdWordDialog.wdDialogFilePrint).Show()
        End If
        'If v2 = True Then v1 = True : MsgBox("Для печати документа пожалуйста нажмите на кнопку " & Chr(34) & "Печать" & Chr(34) & " ещё раз.", MsgBoxStyle.Information, "Печать документа")
        'ButtonPrint_Click(ButtonPrint, New EventArgs())
        v2 = False

        Exit Sub

1:      If vStudent = False Then
            frm_student_pol.Label1.Text = "Студент (курсант) " & ComboBoxTbl_stud.Text & " отсутствует в списке." & vbCrLf & "Выберите его пол:"
        Else
            frm_student_pol.Label1.Text = "Вы не указали студента (курсанта)." & vbCrLf & "Выберите его пол:"
        End If
        frm_student_pol.ShowDialog()
        If frm_student_pol.DialogResult = Windows.Forms.DialogResult.OK Then
            If frm_student_pol.ComboBox1.Text = "Мужской" Then pol = "m" : GoTo 2 Else pol = "f" : GoTo 2
            frm_student_pol.Close()
        Else
            frm_student_pol.Close()
            LoadingClose()
            FormEnabledTrueFalse()
        End If

    End Sub

    Sub FormEnabledTrueFalse()
        If Me.Enabled = True Then Me.Enabled = False Else Me.Enabled = True : Me.Focus()
    End Sub

    Dim ErrorPreview As Boolean = False

    Private Sub frm_index_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Focus()
        If IO.File.Exists(CurDir() & "\attestation_practice_default.htm") Then
            GoTo 4
        Else
            MsgBox("Похоже у вас пропал или повредился файл страницы предварительного просмотра по умолчанию!" & vbCrLf & "Для восстановления файла нажмите " & Chr(34) & "ОК" & Chr(34), MsgBoxStyle.Exclamation, "Ошибка загрузки предварительного просмотра по умолчанию")
            ErrorPreview = True
            Th = New System.Threading.Thread(AddressOf Loading)
            Th.SetApartmentState(ApartmentState.STA)
            Th.Start()
            Dim WordApp = CreateObject("Word.Application")
            Dim WordDoc As Word.Document
            WordDoc = WordApp.Documents.Add()
            WordDoc.ActiveWindow.View.DisplayBackgrounds = True
            WordDoc.Background.Fill.Visible = True
            WordDoc.Background.Fill.ForeColor.RGB = RGB(216, 216, 216)
            WordDoc.Background.Fill.Transparency = 0.0#
            WordDoc.Range.Font.TextColor.RGB = RGB(17, 17, 17)
            WordDoc.Range.Font.Name = "Arial"
            WordDoc.Range.Font.Size = 9
            WordDoc.Range.Text = "Для предварительного просмотра документа нажмите «Обновить»."
            WordApp.ActiveDocument.SaveAs(CurDir() & "\attestation_practice_default", FileFormat:=8)
            WordDoc.Close()
            LoadingClose()
        End If
4:      Try
            WebBrowser1.Navigate(CurDir() & "\attestation_practice_default.htm")
        Catch ex As Exception
            If MsgBox("Не удалось загрузить страницу предварительного просмотра по умолчанию! Попробовать снова?", MsgBoxStyle.YesNo, "Ошибка загрузки предварительного просмотра по умолчанию") = MsgBoxResult.Yes Then GoTo 4
        End Try
    End Sub

    Private Sub frm_index_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        On Error Resume Next
        If Me.MaximizeBox = True Then SplitContainer1.SplitterDistance = 543
    End Sub

    Private Sub ButtonPageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPageSetup.Click
        frm_pagesetup.Show()
    End Sub

    Private Sub ButtonPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPreview.Click
        v1 = True
        preview = True
        vRefresh = True
        WordDocument()
    End Sub

    Private Sub Tbl_vid_rabotDataGridView_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Tbl_vid_rabotDataGridView.CellEndEdit
        v3 = True
    End Sub

    Private Sub Tbl_vid_rabotDataGridView_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Tbl_vid_rabotDataGridView.ColumnHeaderMouseClick
        Dim r As Integer = 0
        If CheckVidRabot = True Then
            For r = 0 To TblvidrabotBindingSource.Count - 1
                TblvidrabotBindingSource.Item(r)(3) = False
            Next
            CheckVidRabot = False
        Else
            For r = 0 To TblvidrabotBindingSource.Count - 1
                TblvidrabotBindingSource.Item(r)(3) = True
            Next
            CheckVidRabot = True
        End If
        TblvidrabotBindingSource.Position = 0
        Tbl_vid_rabotDataGridView.Refresh()
    End Sub

    Private Sub DateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker2.ValueChanged
        DateTimePicker3.Value = DateTimePicker2.Value
        v3 = True
    End Sub

    Private Sub CheckBoxTbl_uch_practika1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxTbl_uch_practika1.CheckedChanged
        If CheckBoxTbl_uch_practika1.Checked = True Then CheckBoxTbl_uch_practika1.Image = My.Resources.icons8_link_15
        If CheckBoxTbl_uch_practika1.Checked = False Then CheckBoxTbl_uch_practika1.Image = My.Resources.icons8_link_15_deactive
    End Sub

    Private Sub CheckBoxTbl_spec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxTbl_spec.CheckedChanged
        If CheckBoxTbl_spec.Checked = True Then CheckBoxTbl_spec.Image = My.Resources.icons8_link_15
        If CheckBoxTbl_spec.Checked = False Then CheckBoxTbl_spec.Image = My.Resources.icons8_link_15_deactive
    End Sub

    Private Sub CheckBoxKurs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxKurs.CheckedChanged
        If CheckBoxKurs.Checked = True Then CheckBoxKurs.Image = My.Resources.icons8_link_15
        If CheckBoxKurs.Checked = False Then CheckBoxKurs.Image = My.Resources.icons8_link_15_deactive
    End Sub

    Private Sub CheckBoxTbl_uch_practika_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxTbl_uch_practika.CheckedChanged
        If CheckBoxTbl_uch_practika.Checked = True Then CheckBoxTbl_uch_practika.Image = My.Resources.icons8_link_15
        If CheckBoxTbl_uch_practika.Checked = False Then CheckBoxTbl_uch_practika.Image = My.Resources.icons8_link_15_deactive
    End Sub

    Private Sub menu_Change_User_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Change_User.Click
        If MsgBox("Вы уверены что хотите сменить пользователя?", MsgBoxStyle.YesNo, "Смена пользователя") = MsgBoxResult.Yes Then
            Try
                Dim SettingFile As String
                Using reader As New System.IO.StreamReader(CurDir() & "\attestation_practice.ini", System.Text.Encoding.UTF8)
                    SettingFile = reader.ReadLine()
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                    SettingFile = SettingFile & vbCrLf & "False"
                    reader.Close()
                    IO.File.WriteAllText(CurDir() & "\attestation_practice.ini", SettingFile, System.Text.Encoding.UTF8)
                End Using
            Catch ex As Exception
                If MsgBox("Файл с параметрами отсутствует! Пожалуйста установите параметры снова.", MsgBoxStyle.OkCancel, "Ошибка чтения файла") = vbOK Then
                    GoTo 1
                Else
                    MsgBox("Параметры не были установлены!", MsgBoxStyle.Critical, "Параметры")
                    Exit Sub
                End If
            End Try
            Me.Hide()
            LoginStatus = False
            frm_login.ShowDialog()
            Exit Sub
1:          frm_pagesetup.FontDialog1.Font = New Font("Time New Romans", 12, FontStyle.Regular)
            If frm_pagesetup.FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Using writer As New System.IO.StreamWriter(CurDir() & "\attestation_practice.ini", False, System.Text.Encoding.UTF8)
                    writer.WriteLine(frm_pagesetup.FontDialog1.Font.Name)
                    writer.WriteLine(frm_pagesetup.FontDialog1.Font.Size)
                    writer.WriteLine(frm_pagesetup.FontDialog1.Font.Bold)
                    writer.WriteLine(frm_pagesetup.FontDialog1.Font.Italic)
                    writer.WriteLine(frm_pagesetup.FontDialog1.Font.Bold And frm_pagesetup.FontDialog1.Font.Italic)
                    writer.WriteLine("False")
                    writer.Close()
                End Using
            Else
                Using writer As New System.IO.StreamWriter(CurDir() & "\attestation_practice.ini", False, System.Text.Encoding.UTF8)
                    writer.WriteLine("Times New Roman")
                    writer.WriteLine("12")
                    writer.WriteLine("False")
                    writer.WriteLine("False")
                    writer.WriteLine("False")
                    writer.WriteLine("False")
                    writer.Close()
                End Using
                MsgBox("Значения выставлены по умолчанию.", MsgBoxStyle.Information, "Значения по умолчанию")
            End If
        End If
    End Sub

    Private Sub menu_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Exit.Click
        If IO.File.Exists(CurDir() & "\attestation_practice_tmp.htm") Then IO.File.Delete(CurDir() & "\attestation_practice_tmp.htm")
        If IO.File.Exists(CurDir() & "\attestation_practice_tmp.docx") Then IO.File.Delete(CurDir() & "\attestation_practice_tmp.docx")
        If IO.Directory.Exists(CurDir() & "\attestation_practice_tmp.files") Then IO.Directory.Delete(CurDir() & "\attestation_practice_tmp.files", True)
        If IO.Directory.Exists(CurDir() & "\attestation_practice_tmp (1).files") Then IO.Directory.Delete(CurDir() & "\attestation_practice_tmp (1).files", True)
        End
    End Sub

    Private Sub menu_CLS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_CLS.Click
        If IO.File.Exists(CurDir() & "\attestation_practice_tmp.htm") Then IO.File.Delete(CurDir() & "\attestation_practice_tmp.htm")
        If IO.File.Exists(CurDir() & "\attestation_practice_tmp.docx") Then IO.File.Delete(CurDir() & "\attestation_practice_tmp.docx")
        If IO.Directory.Exists(CurDir() & "\attestation_practice_tmp.files") Then IO.Directory.Delete(CurDir() & "\attestation_practice_tmp.files", True)
        If IO.Directory.Exists(CurDir() & "\attestation_practice_tmp (1).files") Then IO.Directory.Delete(CurDir() & "\attestation_practice_tmp (1).files", True)
        TblvidrabotBindingSource.RemoveFilter()
        TblstudBindingSource.RemoveFilter()
        TbluchpractikaBindingSource.RemoveFilter()
        TbluchpractikaBindingSource1.RemoveFilter()
        ComboBoxTbl_spec.SelectedIndex = -1
        ComboBoxKurs.SelectedIndex = -1
        ComboBoxTbl_stud.SelectedIndex = -1
        ComboBoxTbl_uch_practika_modul.SelectedIndex = -1
        ComboBoxTbl_uch_practika.SelectedIndex = -1
        ComboBoxTbl_otv_lico.SelectedIndex = -1
        ComboBoxTbl_rukovod_praktiki.SelectedIndex = -1
        TextBoxHour.Text = ""
        DateTimePicker1.Value = Date.Today
        DateTimePicker2.Value = Date.Today
        DateTimePicker3.Value = Date.Today
        PrevValue = -2
        preview = False
        CheckVidRabot = True
        v1 = True
        v2 = False
        v3 = False
        vRefresh = False
        Me.Tbl_vid_rabotTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_vid_rabot)
        'TODO: данная строка кода позволяет загрузить данные в таблицу "Attestation_practiceDataSet.tbl_org". При необходимости она может быть перемещена или удалена.
5:      Try
            WebBrowser1.Navigate(CurDir() & "\attestation_practice_default.htm")
        Catch ex As Exception
            If MsgBox("Не удалось загрузить предварительный просмотр! Попробовать снова?", MsgBoxStyle.YesNo, "Ошибка загрузки предварительного просмотра") = MsgBoxResult.Yes Then GoTo 5
        End Try
    End Sub

    Private Sub menu_Refresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Refresh.Click
        ButtonPreview_Click(sender, e)
    End Sub

    Private Sub menu_PageSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_PageSetup.Click
        ButtonPageSetup_Click(sender, e)
    End Sub

    Private Sub menu_ExportToWord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_ExportToWord.Click
        ButtonExportToWord_Click(sender, e)
    End Sub

    Private Sub menu_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Print.Click
        ButtonPrint_Click(sender, e)
    End Sub

    Private Sub menu_PrintViewer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_PrintViewer.Click
        ButtonPrintPreview_Click(sender, e)
    End Sub

    Private Sub menu_About_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_About.Click
        frm_about.ShowDialog()
    End Sub

    Private Sub ComboBoxTbl_stud_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_stud.SelectedIndexChanged
        Me.Tbl_vid_rabotTableAdapter.Fill(Me.Attestation_practiceDataSet.tbl_vid_rabot)
    End Sub

    Private Sub menu_History_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_History.Click
        frm_tbl_journal_rating.Show()
    End Sub

    Private Sub menu_Stud_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Stud.Click
        frm_tbl_stud.Show()
    End Sub

    Private Sub menu_Accounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Accounts.Click
        frm_tbl_account.Show()
    End Sub

    Private Sub menu_Vid_rabot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Vid_rabot.Click
        frm_tbl_vid_rabot.Show()
    End Sub

    Private Sub menu_Org_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Org.Click
        frm_tbl_org.Show()
    End Sub

    Private Sub menu_Otv_lica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Otv_lica.Click
        frm_tbl_otv_lico_org.Show()
    End Sub

    Private Sub menu_Uch_practiki_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Uch_practiki.Click
        frm_tbl_uch_practika.Show()
    End Sub

    Private Sub menu_Rukovod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Rukovod.Click
        frm_tbl_ruckovod_practiki.Show()
    End Sub

    Private Sub menu_Spec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Spec.Click
        frm_tbl_spec.Show()
    End Sub

    Private Sub menu_Stat_sved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Stat_sved.Click
        frm_tbl_stat_sved.Show()
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        frm_tbl_var_begin.Show()
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        frm_tbl_var_rabot.Show()
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        frm_tbl_var_osnov.Show()
    End Sub

    Private Sub ToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem15.Click
        frm_tbl_var_narekan.Show()
    End Sub

    Private Sub ToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem16.Click
        frm_tbl_var_svod.Show()
    End Sub

    Private Sub ComboBoxTbl_spec_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_spec.TextChanged
        v3 = True
    End Sub

    Private Sub ComboBoxKurs_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxKurs.TextChanged
        v3 = True
    End Sub

    Private Sub ComboBoxTbl_stud_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_stud.TextChanged
        v3 = True
    End Sub

    Private Sub ComboBoxTbl_uch_practika_modul_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_uch_practika_modul.TextChanged
        v3 = True
    End Sub

    Private Sub TextBoxHour_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxHour.TextChanged
        v3 = True
    End Sub

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        v3 = True
    End Sub

    Private Sub DateTimePicker3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePicker3.ValueChanged
        v3 = True
    End Sub

    Private Sub ComboBoxTbl_otv_lico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_otv_lico.TextChanged
        v3 = True
    End Sub

    Private Sub ComboBoxTbl_rukovod_praktiki_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_rukovod_praktiki.TextChanged
        v3 = True
    End Sub

    Private Sub ComboBoxTbl_org_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxTbl_org.TextChanged
        v3 = True
    End Sub

    Private Sub menu_Select_Att_List_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Select_Att_List.Click
        frm_select_att_list.Show()
    End Sub

    Private Sub menu_Browse_DB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Browse_DB.Click
9:      OpenFileDialog1.FileName = "attestation_practice.accdb"
        OpenFileDialog1.InitialDirectory = CurDir()
        Try
            If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If MsgBox("Произойдёт замена существующего файла базы данных. Вы уверены что хотите это сделать?", MsgBoxStyle.YesNo, "Замена файла базы данных") = MsgBoxResult.Yes Then
                    My.Computer.FileSystem.CopyFile(OpenFileDialog1.FileName, CurDir() & "\attestation_practice.accdb", True)
                    MsgBox("Для подключения базы данных программа будет перезапущена.", MsgBoxStyle.Information, "Перезагрузка программы")
                    System.Diagnostics.Process.Start(Application.ExecutablePath)
                    Application.Exit()
                    'Application.Restart()
                End If
            End If
        Catch
            If MsgBox("Не удалось открыть обозреватель файлов! Попробовать ещё раз?", MsgBoxStyle.RetryCancel, "Ошибка обозревателя файлов") = MsgBoxResult.Retry Then GoTo 9
        End Try
    End Sub

    Private Sub menu_File_Help_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_File_Help.Click
        Try
            Process.Start(CurDir() & "\attestation_practice.chm")
        Catch
            MsgBox("Файл справки не найден!", MsgBoxStyle.Critical, "Ошибка чтения файла справки")
        End Try
    End Sub

    Private Sub menu_Remember_User_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menu_Remember_User.Click
        Try
            Dim SettingFile As String
            Using reader As New System.IO.StreamReader(CurDir() & "\attestation_practice.ini", System.Text.Encoding.UTF8)
                SettingFile = reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                If menu_Remember_User.Checked = True Then
                    SettingFile = SettingFile & vbCrLf & "True"
                    Select Case Me.Tag
                        Case "admin"
                            SettingFile = SettingFile & vbCrLf & "d033e22ae348aeb5660fc2140aec35850c4da997"
                        Case "manager"
                            SettingFile = SettingFile & vbCrLf & "1a8565a9dc72048ba03b4156be3e569f22771f23"
                        Case "test"
                            SettingFile = SettingFile & vbCrLf & "a94a8fe5ccb19ba61c4c0873d391e987982fbbd3"
                        Case Else
                            SettingFile = SettingFile & vbCrLf & "1a8565a9dc72048ba03b4156be3e569f22771f23"
                    End Select
                Else
                    SettingFile = SettingFile & vbCrLf & "False"
                End If
                reader.Close()
                IO.File.WriteAllText(CurDir() & "\attestation_practice.ini", SettingFile, System.Text.Encoding.UTF8)
            End Using
        Catch ex As Exception
            If MsgBox("Файл с параметрами отсутствует! Пожалуйста установите параметры снова.", MsgBoxStyle.OkCancel, "Ошибка чтения файла") = vbOK Then
                GoTo 1
            Else
                MsgBox("Параметры не были установлены!", MsgBoxStyle.Critical, "Параметры")
                Exit Sub
            End If
        End Try
        Exit Sub
1:      frm_pagesetup.FontDialog1.Font = New Font("Time New Romans", 12, FontStyle.Regular)
        If frm_pagesetup.FontDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Using writer As New System.IO.StreamWriter(CurDir() & "\attestation_practice.ini", False, System.Text.Encoding.UTF8)
                writer.WriteLine(frm_pagesetup.FontDialog1.Font.Name)
                writer.WriteLine(frm_pagesetup.FontDialog1.Font.Size)
                writer.WriteLine(frm_pagesetup.FontDialog1.Font.Bold)
                writer.WriteLine(frm_pagesetup.FontDialog1.Font.Italic)
                writer.WriteLine(frm_pagesetup.FontDialog1.Font.Bold And frm_pagesetup.FontDialog1.Font.Italic)
                If menu_Remember_User.Checked = True Then
                    writer.WriteLine("True")
                    Select Case Me.Tag
                        Case "admin"
                            writer.WriteLine("d033e22ae348aeb5660fc2140aec35850c4da997")
                        Case "manager"
                            writer.WriteLine("1a8565a9dc72048ba03b4156be3e569f22771f23")
                        Case "test"
                            writer.WriteLine("a94a8fe5ccb19ba61c4c0873d391e987982fbbd3")
                        Case Else
                            writer.WriteLine("1a8565a9dc72048ba03b4156be3e569f22771f23")
                    End Select
                Else
                    writer.WriteLine("False")
                End If
                writer.Close()
            End Using
        Else
            Using writer As New System.IO.StreamWriter(CurDir() & "\attestation_practice.ini", False, System.Text.Encoding.UTF8)
                writer.WriteLine("Times New Roman")
                writer.WriteLine("12")
                writer.WriteLine("False")
                writer.WriteLine("False")
                writer.WriteLine("False")
                If menu_Remember_User.Checked = True Then
                    writer.WriteLine("True")
                    Select Case Me.Tag
                        Case "admin"
                            writer.WriteLine("d033e22ae348aeb5660fc2140aec35850c4da997")
                        Case "manager"
                            writer.WriteLine("1a8565a9dc72048ba03b4156be3e569f22771f23")
                        Case "test"
                            writer.WriteLine("a94a8fe5ccb19ba61c4c0873d391e987982fbbd3")
                        Case Else
                            writer.WriteLine("1a8565a9dc72048ba03b4156be3e569f22771f23")
                    End Select
                Else
                    writer.WriteLine("False")
                End If
                writer.Close()
            End Using
            MsgBox("Значения выставлены по умолчанию.", MsgBoxStyle.Information, "Значения по умолчанию")
        End If
    End Sub
End Class
