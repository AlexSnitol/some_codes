<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_index
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_index))
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.CheckBoxTbl_uch_practika1 = New System.Windows.Forms.CheckBox()
        Me.ButtonClearTbl_vid_rabot = New System.Windows.Forms.Button()
        Me.ButtonClearTbl_uch_practika = New System.Windows.Forms.Button()
        Me.ButtonClearTbl_uch_practika_modul = New System.Windows.Forms.Button()
        Me.ButtonClearTbl_stud = New System.Windows.Forms.Button()
        Me.ButtonClearTbl_spec = New System.Windows.Forms.Button()
        Me.CheckBoxTbl_spec = New System.Windows.Forms.CheckBox()
        Me.CheckBoxKurs = New System.Windows.Forms.CheckBox()
        Me.CheckBoxTbl_uch_practika = New System.Windows.Forms.CheckBox()
        Me.LabelOtv_lico = New System.Windows.Forms.Label()
        Me.ComboBoxTbl_otv_lico = New System.Windows.Forms.ComboBox()
        Me.QrotvlicoorgBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Attestation_practiceDataSet = New attestation_practice.attestation_practiceDataSet()
        Me.LabelRukovod = New System.Windows.Forms.Label()
        Me.ComboBoxTbl_rukovod_praktiki = New System.Windows.Forms.ComboBox()
        Me.QrruckovodpractikiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelDataRating = New System.Windows.Forms.Label()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.Tbl_vid_rabotDataGridView = New System.Windows.Forms.DataGridView()
        Me.IdvidrabotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IduchpractikavidrabotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckvidrabotDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NamvidrabotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RatingvidrabotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TblvidrabotBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelOrg = New System.Windows.Forms.Label()
        Me.ComboBoxTbl_org = New System.Windows.Forms.ComboBox()
        Me.TblorgBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.LabelData = New System.Windows.Forms.Label()
        Me.TextBoxHour = New System.Windows.Forms.TextBox()
        Me.LabelHour = New System.Windows.Forms.Label()
        Me.LabelUch_praktika = New System.Windows.Forms.Label()
        Me.ComboBoxTbl_uch_practika = New System.Windows.Forms.ComboBox()
        Me.TbluchpractikaBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelModul = New System.Windows.Forms.Label()
        Me.ComboBoxTbl_uch_practika_modul = New System.Windows.Forms.ComboBox()
        Me.Qr_uch_practikaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelSpec = New System.Windows.Forms.Label()
        Me.ComboBoxTbl_spec = New System.Windows.Forms.ComboBox()
        Me.TblspecBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelKurs = New System.Windows.Forms.Label()
        Me.ComboBoxKurs = New System.Windows.Forms.ComboBox()
        Me.LabelStud = New System.Windows.Forms.Label()
        Me.ComboBoxTbl_stud = New System.Windows.Forms.ComboBox()
        Me.QrstudBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.menu_File = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Change_User = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Operation = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Select_Att_List = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Browse_DB = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Refresh = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_PrintViewer = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_PageSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_CLS = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Print = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_ExportToWord = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Tables = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Accounts = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Vid_rabot = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_History = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Org = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Otv_lica = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Uch_practiki = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Rukovod = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Spec = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Stat_sved = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Stud = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Charact = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem12 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem13 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem14 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem15 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem16 = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_Help = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_File_Help = New System.Windows.Forms.ToolStripMenuItem()
        Me.menu_About = New System.Windows.Forms.ToolStripMenuItem()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ButtonPreview = New System.Windows.Forms.Button()
        Me.ButtonPageSetup = New System.Windows.Forms.Button()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.ButtonPrintPreview = New System.Windows.Forms.Button()
        Me.ButtonPrint = New System.Windows.Forms.Button()
        Me.ButtonExportToWord = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TbluchpractikaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_specTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_specTableAdapter()
        Me.TblstudBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_studTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_studTableAdapter()
        Me.Tbl_uch_practikaTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_uch_practikaTableAdapter()
        Me.Qr_studTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.qr_studTableAdapter()
        Me.TblruckovodpractikiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_ruckovod_practikiTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_ruckovod_practikiTableAdapter()
        Me.Qr_ruckovod_practikiTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.qr_ruckovod_practikiTableAdapter()
        Me.TblotvlicoorgBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_otv_lico_orgTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_otv_lico_orgTableAdapter()
        Me.Qr_otv_lico_orgTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.qr_otv_lico_orgTableAdapter()
        Me.Tbl_orgTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_orgTableAdapter()
        Me.Tbl_vid_rabotTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_vid_rabotTableAdapter()
        Me.Tbl_stat_svedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_stat_svedTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_stat_svedTableAdapter()
        Me.TableAdapterManager = New attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager()
        Me.Tbl_journal_ratingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_journal_ratingTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_journal_ratingTableAdapter()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Qr_uch_practikaTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.qr_uch_practikaTableAdapter()
        Me.menu_Remember_User = New System.Windows.Forms.ToolStripMenuItem()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.QrotvlicoorgBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QrruckovodpractikiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_vid_rabotDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblvidrabotBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblorgBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbluchpractikaBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Qr_uch_practikaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblspecBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QrstudBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.TbluchpractikaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblstudBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblruckovodpractikiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblotvlicoorgBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_stat_svedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_journal_ratingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBoxTbl_uch_practika1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonClearTbl_vid_rabot)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonClearTbl_uch_practika)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonClearTbl_uch_practika_modul)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonClearTbl_stud)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonClearTbl_spec)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBoxTbl_spec)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBoxKurs)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBoxTbl_uch_practika)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelOtv_lico)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxTbl_otv_lico)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelRukovod)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxTbl_rukovod_praktiki)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelDataRating)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePicker3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Tbl_vid_rabotDataGridView)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelOrg)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxTbl_org)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePicker2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelData)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxHour)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelHour)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelUch_praktika)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxTbl_uch_practika)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelModul)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxTbl_uch_practika_modul)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelSpec)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxTbl_spec)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelKurs)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxKurs)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelStud)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxTbl_stud)
        Me.SplitContainer1.Panel1.Controls.Add(Me.MenuStrip1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ShapeContainer1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SplitContainer1.Panel2.Controls.Add(Me.ButtonPreview)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ButtonPageSetup)
        Me.SplitContainer1.Panel2.Controls.Add(Me.WebBrowser1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ButtonPrintPreview)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ButtonPrint)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ButtonExportToWord)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1010, 641)
        Me.SplitContainer1.SplitterDistance = 543
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 0
        '
        'CheckBoxTbl_uch_practika1
        '
        Me.CheckBoxTbl_uch_practika1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxTbl_uch_practika1.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxTbl_uch_practika1.AutoSize = True
        Me.CheckBoxTbl_uch_practika1.Checked = True
        Me.CheckBoxTbl_uch_practika1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxTbl_uch_practika1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CheckBoxTbl_uch_practika1.FlatAppearance.BorderSize = 0
        Me.CheckBoxTbl_uch_practika1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxTbl_uch_practika1.Image = CType(resources.GetObject("CheckBoxTbl_uch_practika1.Image"), System.Drawing.Image)
        Me.CheckBoxTbl_uch_practika1.Location = New System.Drawing.Point(517, 158)
        Me.CheckBoxTbl_uch_practika1.Name = "CheckBoxTbl_uch_practika1"
        Me.CheckBoxTbl_uch_practika1.Size = New System.Drawing.Size(21, 21)
        Me.CheckBoxTbl_uch_practika1.TabIndex = 11
        Me.CheckBoxTbl_uch_practika1.UseVisualStyleBackColor = True
        '
        'ButtonClearTbl_vid_rabot
        '
        Me.ButtonClearTbl_vid_rabot.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClearTbl_vid_rabot.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearTbl_vid_rabot.FlatAppearance.BorderSize = 0
        Me.ButtonClearTbl_vid_rabot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearTbl_vid_rabot.Image = CType(resources.GetObject("ButtonClearTbl_vid_rabot.Image"), System.Drawing.Image)
        Me.ButtonClearTbl_vid_rabot.Location = New System.Drawing.Point(398, 493)
        Me.ButtonClearTbl_vid_rabot.Name = "ButtonClearTbl_vid_rabot"
        Me.ButtonClearTbl_vid_rabot.Size = New System.Drawing.Size(140, 28)
        Me.ButtonClearTbl_vid_rabot.TabIndex = 17
        Me.ButtonClearTbl_vid_rabot.UseVisualStyleBackColor = True
        '
        'ButtonClearTbl_uch_practika
        '
        Me.ButtonClearTbl_uch_practika.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearTbl_uch_practika.FlatAppearance.BorderSize = 0
        Me.ButtonClearTbl_uch_practika.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearTbl_uch_practika.Image = CType(resources.GetObject("ButtonClearTbl_uch_practika.Image"), System.Drawing.Image)
        Me.ButtonClearTbl_uch_practika.Location = New System.Drawing.Point(137, 155)
        Me.ButtonClearTbl_uch_practika.Name = "ButtonClearTbl_uch_practika"
        Me.ButtonClearTbl_uch_practika.Size = New System.Drawing.Size(26, 26)
        Me.ButtonClearTbl_uch_practika.TabIndex = 12
        Me.ButtonClearTbl_uch_practika.UseVisualStyleBackColor = True
        '
        'ButtonClearTbl_uch_practika_modul
        '
        Me.ButtonClearTbl_uch_practika_modul.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearTbl_uch_practika_modul.FlatAppearance.BorderSize = 0
        Me.ButtonClearTbl_uch_practika_modul.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearTbl_uch_practika_modul.Image = CType(resources.GetObject("ButtonClearTbl_uch_practika_modul.Image"), System.Drawing.Image)
        Me.ButtonClearTbl_uch_practika_modul.Location = New System.Drawing.Point(137, 126)
        Me.ButtonClearTbl_uch_practika_modul.Name = "ButtonClearTbl_uch_practika_modul"
        Me.ButtonClearTbl_uch_practika_modul.Size = New System.Drawing.Size(26, 26)
        Me.ButtonClearTbl_uch_practika_modul.TabIndex = 9
        Me.ButtonClearTbl_uch_practika_modul.UseVisualStyleBackColor = True
        '
        'ButtonClearTbl_stud
        '
        Me.ButtonClearTbl_stud.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearTbl_stud.FlatAppearance.BorderSize = 0
        Me.ButtonClearTbl_stud.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearTbl_stud.Image = CType(resources.GetObject("ButtonClearTbl_stud.Image"), System.Drawing.Image)
        Me.ButtonClearTbl_stud.Location = New System.Drawing.Point(137, 94)
        Me.ButtonClearTbl_stud.Name = "ButtonClearTbl_stud"
        Me.ButtonClearTbl_stud.Size = New System.Drawing.Size(26, 26)
        Me.ButtonClearTbl_stud.TabIndex = 6
        Me.ButtonClearTbl_stud.UseVisualStyleBackColor = True
        '
        'ButtonClearTbl_spec
        '
        Me.ButtonClearTbl_spec.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearTbl_spec.FlatAppearance.BorderSize = 0
        Me.ButtonClearTbl_spec.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearTbl_spec.Image = CType(resources.GetObject("ButtonClearTbl_spec.Image"), System.Drawing.Image)
        Me.ButtonClearTbl_spec.Location = New System.Drawing.Point(137, 35)
        Me.ButtonClearTbl_spec.Name = "ButtonClearTbl_spec"
        Me.ButtonClearTbl_spec.Size = New System.Drawing.Size(26, 26)
        Me.ButtonClearTbl_spec.TabIndex = 2
        Me.ButtonClearTbl_spec.UseVisualStyleBackColor = True
        '
        'CheckBoxTbl_spec
        '
        Me.CheckBoxTbl_spec.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxTbl_spec.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxTbl_spec.AutoSize = True
        Me.CheckBoxTbl_spec.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBoxTbl_spec.Checked = True
        Me.CheckBoxTbl_spec.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxTbl_spec.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CheckBoxTbl_spec.FlatAppearance.BorderSize = 0
        Me.CheckBoxTbl_spec.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxTbl_spec.Image = Global.attestation_practice.My.Resources.Resources.icons8_link_15
        Me.CheckBoxTbl_spec.Location = New System.Drawing.Point(517, 37)
        Me.CheckBoxTbl_spec.Name = "CheckBoxTbl_spec"
        Me.CheckBoxTbl_spec.Size = New System.Drawing.Size(21, 21)
        Me.CheckBoxTbl_spec.TabIndex = 1
        Me.CheckBoxTbl_spec.UseVisualStyleBackColor = True
        '
        'CheckBoxKurs
        '
        Me.CheckBoxKurs.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxKurs.AutoSize = True
        Me.CheckBoxKurs.Checked = True
        Me.CheckBoxKurs.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxKurs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CheckBoxKurs.FlatAppearance.BorderSize = 0
        Me.CheckBoxKurs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxKurs.Image = CType(resources.GetObject("CheckBoxKurs.Image"), System.Drawing.Image)
        Me.CheckBoxKurs.Location = New System.Drawing.Point(222, 67)
        Me.CheckBoxKurs.Name = "CheckBoxKurs"
        Me.CheckBoxKurs.Size = New System.Drawing.Size(21, 21)
        Me.CheckBoxKurs.TabIndex = 4
        Me.CheckBoxKurs.UseVisualStyleBackColor = True
        '
        'CheckBoxTbl_uch_practika
        '
        Me.CheckBoxTbl_uch_practika.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxTbl_uch_practika.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxTbl_uch_practika.AutoSize = True
        Me.CheckBoxTbl_uch_practika.Checked = True
        Me.CheckBoxTbl_uch_practika.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxTbl_uch_practika.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CheckBoxTbl_uch_practika.FlatAppearance.BorderSize = 0
        Me.CheckBoxTbl_uch_practika.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxTbl_uch_practika.Image = CType(resources.GetObject("CheckBoxTbl_uch_practika.Image"), System.Drawing.Image)
        Me.CheckBoxTbl_uch_practika.Location = New System.Drawing.Point(517, 129)
        Me.CheckBoxTbl_uch_practika.Name = "CheckBoxTbl_uch_practika"
        Me.CheckBoxTbl_uch_practika.Size = New System.Drawing.Size(21, 21)
        Me.CheckBoxTbl_uch_practika.TabIndex = 8
        Me.CheckBoxTbl_uch_practika.UseVisualStyleBackColor = True
        '
        'LabelOtv_lico
        '
        Me.LabelOtv_lico.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelOtv_lico.AutoSize = True
        Me.LabelOtv_lico.Location = New System.Drawing.Point(22, 535)
        Me.LabelOtv_lico.Name = "LabelOtv_lico"
        Me.LabelOtv_lico.Size = New System.Drawing.Size(95, 16)
        Me.LabelOtv_lico.TabIndex = 25
        Me.LabelOtv_lico.Text = "Отв. лицо орг.:"
        '
        'ComboBoxTbl_otv_lico
        '
        Me.ComboBoxTbl_otv_lico.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxTbl_otv_lico.BackColor = System.Drawing.Color.White
        Me.ComboBoxTbl_otv_lico.DataSource = Me.QrotvlicoorgBindingSource
        Me.ComboBoxTbl_otv_lico.DisplayMember = "fio_otv_lico_org"
        Me.ComboBoxTbl_otv_lico.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTbl_otv_lico.FormattingEnabled = True
        Me.ComboBoxTbl_otv_lico.Location = New System.Drawing.Point(123, 532)
        Me.ComboBoxTbl_otv_lico.Name = "ComboBoxTbl_otv_lico"
        Me.ComboBoxTbl_otv_lico.Size = New System.Drawing.Size(402, 24)
        Me.ComboBoxTbl_otv_lico.TabIndex = 19
        Me.ComboBoxTbl_otv_lico.ValueMember = "id_otv_lica_org"
        '
        'QrotvlicoorgBindingSource
        '
        Me.QrotvlicoorgBindingSource.DataMember = "qr_otv_lico_org"
        Me.QrotvlicoorgBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'Attestation_practiceDataSet
        '
        Me.Attestation_practiceDataSet.DataSetName = "attestation_practiceDataSet"
        Me.Attestation_practiceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LabelRukovod
        '
        Me.LabelRukovod.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelRukovod.AutoSize = True
        Me.LabelRukovod.Location = New System.Drawing.Point(22, 571)
        Me.LabelRukovod.Name = "LabelRukovod"
        Me.LabelRukovod.Size = New System.Drawing.Size(94, 16)
        Me.LabelRukovod.TabIndex = 23
        Me.LabelRukovod.Text = "Рук. практики:"
        '
        'ComboBoxTbl_rukovod_praktiki
        '
        Me.ComboBoxTbl_rukovod_praktiki.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxTbl_rukovod_praktiki.BackColor = System.Drawing.Color.White
        Me.ComboBoxTbl_rukovod_praktiki.DataSource = Me.QrruckovodpractikiBindingSource
        Me.ComboBoxTbl_rukovod_praktiki.DisplayMember = "fio_ruckovod_practiki"
        Me.ComboBoxTbl_rukovod_praktiki.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTbl_rukovod_praktiki.FormattingEnabled = True
        Me.ComboBoxTbl_rukovod_praktiki.Location = New System.Drawing.Point(123, 568)
        Me.ComboBoxTbl_rukovod_praktiki.Name = "ComboBoxTbl_rukovod_praktiki"
        Me.ComboBoxTbl_rukovod_praktiki.Size = New System.Drawing.Size(402, 24)
        Me.ComboBoxTbl_rukovod_praktiki.TabIndex = 20
        Me.ComboBoxTbl_rukovod_praktiki.ValueMember = "id_ruckovod_practiki"
        '
        'QrruckovodpractikiBindingSource
        '
        Me.QrruckovodpractikiBindingSource.DataMember = "qr_ruckovod_practiki"
        Me.QrruckovodpractikiBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'LabelDataRating
        '
        Me.LabelDataRating.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelDataRating.AutoSize = True
        Me.LabelDataRating.Location = New System.Drawing.Point(23, 504)
        Me.LabelDataRating.Name = "LabelDataRating"
        Me.LabelDataRating.Size = New System.Drawing.Size(40, 16)
        Me.LabelDataRating.TabIndex = 21
        Me.LabelDataRating.Text = "Дата:"
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DateTimePicker3.CalendarForeColor = System.Drawing.Color.Black
        Me.DateTimePicker3.CalendarMonthBackground = System.Drawing.Color.White
        Me.DateTimePicker3.Location = New System.Drawing.Point(72, 500)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(156, 22)
        Me.DateTimePicker3.TabIndex = 18
        '
        'Tbl_vid_rabotDataGridView
        '
        Me.Tbl_vid_rabotDataGridView.AllowUserToAddRows = False
        Me.Tbl_vid_rabotDataGridView.AllowUserToDeleteRows = False
        Me.Tbl_vid_rabotDataGridView.AllowUserToResizeRows = False
        Me.Tbl_vid_rabotDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tbl_vid_rabotDataGridView.AutoGenerateColumns = False
        Me.Tbl_vid_rabotDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Tbl_vid_rabotDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.IdvidrabotDataGridViewTextBoxColumn, Me.IduchpractikavidrabotDataGridViewTextBoxColumn, Me.CheckvidrabotDataGridViewCheckBoxColumn, Me.NamvidrabotDataGridViewTextBoxColumn, Me.RatingvidrabotDataGridViewTextBoxColumn})
        Me.Tbl_vid_rabotDataGridView.DataSource = Me.TblvidrabotBindingSource
        Me.Tbl_vid_rabotDataGridView.GridColor = System.Drawing.Color.Silver
        Me.Tbl_vid_rabotDataGridView.Location = New System.Drawing.Point(-1, 232)
        Me.Tbl_vid_rabotDataGridView.MultiSelect = False
        Me.Tbl_vid_rabotDataGridView.Name = "Tbl_vid_rabotDataGridView"
        Me.Tbl_vid_rabotDataGridView.Size = New System.Drawing.Size(543, 261)
        Me.Tbl_vid_rabotDataGridView.TabIndex = 16
        '
        'IdvidrabotDataGridViewTextBoxColumn
        '
        Me.IdvidrabotDataGridViewTextBoxColumn.DataPropertyName = "id_vid_rabot"
        Me.IdvidrabotDataGridViewTextBoxColumn.HeaderText = "id_vid_rabot"
        Me.IdvidrabotDataGridViewTextBoxColumn.Name = "IdvidrabotDataGridViewTextBoxColumn"
        Me.IdvidrabotDataGridViewTextBoxColumn.Visible = False
        '
        'IduchpractikavidrabotDataGridViewTextBoxColumn
        '
        Me.IduchpractikavidrabotDataGridViewTextBoxColumn.DataPropertyName = "id_uch_practika_vid_rabot"
        Me.IduchpractikavidrabotDataGridViewTextBoxColumn.HeaderText = "id_uch_practika_vid_rabot"
        Me.IduchpractikavidrabotDataGridViewTextBoxColumn.Name = "IduchpractikavidrabotDataGridViewTextBoxColumn"
        Me.IduchpractikavidrabotDataGridViewTextBoxColumn.Visible = False
        '
        'CheckvidrabotDataGridViewCheckBoxColumn
        '
        Me.CheckvidrabotDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.CheckvidrabotDataGridViewCheckBoxColumn.DataPropertyName = "check_vid_rabot"
        Me.CheckvidrabotDataGridViewCheckBoxColumn.HeaderText = "Выбор"
        Me.CheckvidrabotDataGridViewCheckBoxColumn.Name = "CheckvidrabotDataGridViewCheckBoxColumn"
        Me.CheckvidrabotDataGridViewCheckBoxColumn.Width = 53
        '
        'NamvidrabotDataGridViewTextBoxColumn
        '
        Me.NamvidrabotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.NamvidrabotDataGridViewTextBoxColumn.DataPropertyName = "nam_vid_rabot"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NamvidrabotDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle7
        Me.NamvidrabotDataGridViewTextBoxColumn.HeaderText = "Вид работы"
        Me.NamvidrabotDataGridViewTextBoxColumn.Name = "NamvidrabotDataGridViewTextBoxColumn"
        '
        'RatingvidrabotDataGridViewTextBoxColumn
        '
        Me.RatingvidrabotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.RatingvidrabotDataGridViewTextBoxColumn.DataPropertyName = "rating_vid_rabot"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RatingvidrabotDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle8
        Me.RatingvidrabotDataGridViewTextBoxColumn.HeaderText = "Оценка"
        Me.RatingvidrabotDataGridViewTextBoxColumn.Name = "RatingvidrabotDataGridViewTextBoxColumn"
        Me.RatingvidrabotDataGridViewTextBoxColumn.Width = 77
        '
        'TblvidrabotBindingSource
        '
        Me.TblvidrabotBindingSource.DataMember = "tbl_vid_rabot"
        Me.TblvidrabotBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'LabelOrg
        '
        Me.LabelOrg.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelOrg.AutoSize = True
        Me.LabelOrg.Location = New System.Drawing.Point(23, 603)
        Me.LabelOrg.Name = "LabelOrg"
        Me.LabelOrg.Size = New System.Drawing.Size(89, 16)
        Me.LabelOrg.TabIndex = 19
        Me.LabelOrg.Text = "Организация:"
        '
        'ComboBoxTbl_org
        '
        Me.ComboBoxTbl_org.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxTbl_org.BackColor = System.Drawing.Color.White
        Me.ComboBoxTbl_org.DataSource = Me.TblorgBindingSource
        Me.ComboBoxTbl_org.DisplayMember = "nam_org"
        Me.ComboBoxTbl_org.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTbl_org.FormattingEnabled = True
        Me.ComboBoxTbl_org.Location = New System.Drawing.Point(123, 600)
        Me.ComboBoxTbl_org.Name = "ComboBoxTbl_org"
        Me.ComboBoxTbl_org.Size = New System.Drawing.Size(402, 24)
        Me.ComboBoxTbl_org.TabIndex = 21
        Me.ComboBoxTbl_org.ValueMember = "id_org"
        '
        'TblorgBindingSource
        '
        Me.TblorgBindingSource.DataMember = "tbl_org"
        Me.TblorgBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.CalendarForeColor = System.Drawing.Color.Black
        Me.DateTimePicker2.CalendarMonthBackground = System.Drawing.Color.White
        Me.DateTimePicker2.Location = New System.Drawing.Point(372, 193)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(157, 22)
        Me.DateTimePicker2.TabIndex = 15
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CalendarForeColor = System.Drawing.Color.Black
        Me.DateTimePicker1.CalendarMonthBackground = System.Drawing.Color.White
        Me.DateTimePicker1.Location = New System.Drawing.Point(181, 192)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(157, 22)
        Me.DateTimePicker1.TabIndex = 14
        '
        'LabelData
        '
        Me.LabelData.AutoSize = True
        Me.LabelData.Location = New System.Drawing.Point(344, 194)
        Me.LabelData.Name = "LabelData"
        Me.LabelData.Size = New System.Drawing.Size(22, 16)
        Me.LabelData.TabIndex = 14
        Me.LabelData.Text = "по"
        '
        'TextBoxHour
        '
        Me.TextBoxHour.Location = New System.Drawing.Point(77, 192)
        Me.TextBoxHour.Name = "TextBoxHour"
        Me.TextBoxHour.Size = New System.Drawing.Size(47, 22)
        Me.TextBoxHour.TabIndex = 13
        '
        'LabelHour
        '
        Me.LabelHour.AutoSize = True
        Me.LabelHour.Location = New System.Drawing.Point(23, 194)
        Me.LabelHour.Name = "LabelHour"
        Me.LabelHour.Size = New System.Drawing.Size(153, 16)
        Me.LabelHour.TabIndex = 12
        Me.LabelHour.Text = "Объём:               час.  с"
        '
        'LabelUch_praktika
        '
        Me.LabelUch_praktika.AutoSize = True
        Me.LabelUch_praktika.Location = New System.Drawing.Point(22, 160)
        Me.LabelUch_praktika.Name = "LabelUch_praktika"
        Me.LabelUch_praktika.Size = New System.Drawing.Size(87, 16)
        Me.LabelUch_praktika.TabIndex = 10
        Me.LabelUch_praktika.Text = "Уч. практика:"
        '
        'ComboBoxTbl_uch_practika
        '
        Me.ComboBoxTbl_uch_practika.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxTbl_uch_practika.BackColor = System.Drawing.Color.White
        Me.ComboBoxTbl_uch_practika.DataSource = Me.TbluchpractikaBindingSource1
        Me.ComboBoxTbl_uch_practika.DisplayMember = "nam_uch_practiki"
        Me.ComboBoxTbl_uch_practika.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTbl_uch_practika.FormattingEnabled = True
        Me.ComboBoxTbl_uch_practika.Location = New System.Drawing.Point(164, 156)
        Me.ComboBoxTbl_uch_practika.Name = "ComboBoxTbl_uch_practika"
        Me.ComboBoxTbl_uch_practika.Size = New System.Drawing.Size(350, 24)
        Me.ComboBoxTbl_uch_practika.TabIndex = 10
        Me.ComboBoxTbl_uch_practika.ValueMember = "id_uch_practiki"
        '
        'TbluchpractikaBindingSource1
        '
        Me.TbluchpractikaBindingSource1.DataMember = "tbl_uch_practika"
        Me.TbluchpractikaBindingSource1.DataSource = Me.Attestation_practiceDataSet
        '
        'LabelModul
        '
        Me.LabelModul.AutoSize = True
        Me.LabelModul.Location = New System.Drawing.Point(22, 130)
        Me.LabelModul.Name = "LabelModul"
        Me.LabelModul.Size = New System.Drawing.Size(97, 16)
        Me.LabelModul.TabIndex = 8
        Me.LabelModul.Text = "Проф. модуль:"
        '
        'ComboBoxTbl_uch_practika_modul
        '
        Me.ComboBoxTbl_uch_practika_modul.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxTbl_uch_practika_modul.BackColor = System.Drawing.Color.White
        Me.ComboBoxTbl_uch_practika_modul.DataSource = Me.Qr_uch_practikaBindingSource
        Me.ComboBoxTbl_uch_practika_modul.DisplayMember = "nam_prof_modul_uch_practiki"
        Me.ComboBoxTbl_uch_practika_modul.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTbl_uch_practika_modul.FormattingEnabled = True
        Me.ComboBoxTbl_uch_practika_modul.Location = New System.Drawing.Point(164, 126)
        Me.ComboBoxTbl_uch_practika_modul.Name = "ComboBoxTbl_uch_practika_modul"
        Me.ComboBoxTbl_uch_practika_modul.Size = New System.Drawing.Size(350, 24)
        Me.ComboBoxTbl_uch_practika_modul.TabIndex = 7
        '
        'Qr_uch_practikaBindingSource
        '
        Me.Qr_uch_practikaBindingSource.DataMember = "qr_uch_practika"
        Me.Qr_uch_practikaBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'LabelSpec
        '
        Me.LabelSpec.AutoSize = True
        Me.LabelSpec.Location = New System.Drawing.Point(22, 39)
        Me.LabelSpec.Name = "LabelSpec"
        Me.LabelSpec.Size = New System.Drawing.Size(103, 16)
        Me.LabelSpec.TabIndex = 6
        Me.LabelSpec.Text = "Специальность:"
        '
        'ComboBoxTbl_spec
        '
        Me.ComboBoxTbl_spec.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxTbl_spec.BackColor = System.Drawing.Color.White
        Me.ComboBoxTbl_spec.DataSource = Me.TblspecBindingSource
        Me.ComboBoxTbl_spec.DisplayMember = "nam_spec"
        Me.ComboBoxTbl_spec.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTbl_spec.FormattingEnabled = True
        Me.ComboBoxTbl_spec.Location = New System.Drawing.Point(164, 37)
        Me.ComboBoxTbl_spec.Name = "ComboBoxTbl_spec"
        Me.ComboBoxTbl_spec.Size = New System.Drawing.Size(350, 24)
        Me.ComboBoxTbl_spec.TabIndex = 0
        Me.ComboBoxTbl_spec.ValueMember = "id_spec"
        '
        'TblspecBindingSource
        '
        Me.TblspecBindingSource.DataMember = "tbl_spec"
        Me.TblspecBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'LabelKurs
        '
        Me.LabelKurs.AutoSize = True
        Me.LabelKurs.Location = New System.Drawing.Point(23, 68)
        Me.LabelKurs.Name = "LabelKurs"
        Me.LabelKurs.Size = New System.Drawing.Size(41, 16)
        Me.LabelKurs.TabIndex = 4
        Me.LabelKurs.Text = "Курс:"
        '
        'ComboBoxKurs
        '
        Me.ComboBoxKurs.BackColor = System.Drawing.Color.White
        Me.ComboBoxKurs.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxKurs.FormattingEnabled = True
        Me.ComboBoxKurs.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.ComboBoxKurs.Location = New System.Drawing.Point(164, 66)
        Me.ComboBoxKurs.Name = "ComboBoxKurs"
        Me.ComboBoxKurs.Size = New System.Drawing.Size(55, 24)
        Me.ComboBoxKurs.TabIndex = 3
        '
        'LabelStud
        '
        Me.LabelStud.AutoSize = True
        Me.LabelStud.Location = New System.Drawing.Point(23, 98)
        Me.LabelStud.Name = "LabelStud"
        Me.LabelStud.Size = New System.Drawing.Size(118, 16)
        Me.LabelStud.TabIndex = 2
        Me.LabelStud.Text = "Студент (курсант):"
        '
        'ComboBoxTbl_stud
        '
        Me.ComboBoxTbl_stud.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxTbl_stud.BackColor = System.Drawing.Color.White
        Me.ComboBoxTbl_stud.DataSource = Me.QrstudBindingSource
        Me.ComboBoxTbl_stud.DisplayMember = "fio_stud"
        Me.ComboBoxTbl_stud.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTbl_stud.FormattingEnabled = True
        Me.ComboBoxTbl_stud.Location = New System.Drawing.Point(164, 96)
        Me.ComboBoxTbl_stud.Name = "ComboBoxTbl_stud"
        Me.ComboBoxTbl_stud.Size = New System.Drawing.Size(350, 24)
        Me.ComboBoxTbl_stud.TabIndex = 5
        Me.ComboBoxTbl_stud.ValueMember = "id_stud"
        '
        'QrstudBindingSource
        '
        Me.QrstudBindingSource.DataMember = "qr_stud"
        Me.QrstudBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_File, Me.menu_Operation, Me.menu_Tables, Me.menu_Help})
        Me.MenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(541, 24)
        Me.MenuStrip1.TabIndex = 30
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'menu_File
        '
        Me.menu_File.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_Change_User, Me.menu_Remember_User, Me.menu_Exit})
        Me.menu_File.Name = "menu_File"
        Me.menu_File.Size = New System.Drawing.Size(48, 20)
        Me.menu_File.Text = "Файл"
        '
        'menu_Change_User
        '
        Me.menu_Change_User.Name = "menu_Change_User"
        Me.menu_Change_User.Size = New System.Drawing.Size(203, 22)
        Me.menu_Change_User.Text = "Сменить пользователя"
        '
        'menu_Exit
        '
        Me.menu_Exit.Name = "menu_Exit"
        Me.menu_Exit.Size = New System.Drawing.Size(203, 22)
        Me.menu_Exit.Text = "Выход"
        '
        'menu_Operation
        '
        Me.menu_Operation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_Select_Att_List, Me.menu_Browse_DB, Me.menu_Refresh, Me.menu_PrintViewer, Me.menu_PageSetup, Me.menu_CLS, Me.menu_Print, Me.menu_ExportToWord})
        Me.menu_Operation.Name = "menu_Operation"
        Me.menu_Operation.Size = New System.Drawing.Size(75, 20)
        Me.menu_Operation.Text = "Операции"
        '
        'menu_Select_Att_List
        '
        Me.menu_Select_Att_List.Name = "menu_Select_Att_List"
        Me.menu_Select_Att_List.Size = New System.Drawing.Size(291, 22)
        Me.menu_Select_Att_List.Text = "Выбрать готовый аттестационный лист"
        '
        'menu_Browse_DB
        '
        Me.menu_Browse_DB.Name = "menu_Browse_DB"
        Me.menu_Browse_DB.Size = New System.Drawing.Size(291, 22)
        Me.menu_Browse_DB.Text = "Выбрать файл БД..."
        '
        'menu_Refresh
        '
        Me.menu_Refresh.Name = "menu_Refresh"
        Me.menu_Refresh.Size = New System.Drawing.Size(291, 22)
        Me.menu_Refresh.Text = "Обновить предпросмотр"
        '
        'menu_PrintViewer
        '
        Me.menu_PrintViewer.Name = "menu_PrintViewer"
        Me.menu_PrintViewer.Size = New System.Drawing.Size(291, 22)
        Me.menu_PrintViewer.Text = "Открыть окно предпросмотра"
        '
        'menu_PageSetup
        '
        Me.menu_PageSetup.Name = "menu_PageSetup"
        Me.menu_PageSetup.Size = New System.Drawing.Size(291, 22)
        Me.menu_PageSetup.Text = "Открыть параметры страницы"
        '
        'menu_CLS
        '
        Me.menu_CLS.Name = "menu_CLS"
        Me.menu_CLS.Size = New System.Drawing.Size(291, 22)
        Me.menu_CLS.Text = "Очистить всё"
        '
        'menu_Print
        '
        Me.menu_Print.Name = "menu_Print"
        Me.menu_Print.Size = New System.Drawing.Size(291, 22)
        Me.menu_Print.Text = "Печать"
        '
        'menu_ExportToWord
        '
        Me.menu_ExportToWord.Name = "menu_ExportToWord"
        Me.menu_ExportToWord.Size = New System.Drawing.Size(291, 22)
        Me.menu_ExportToWord.Text = "Экспорт в Word"
        '
        'menu_Tables
        '
        Me.menu_Tables.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_Accounts, Me.menu_Vid_rabot, Me.menu_History, Me.menu_Org, Me.menu_Otv_lica, Me.menu_Uch_practiki, Me.menu_Rukovod, Me.menu_Spec, Me.menu_Stat_sved, Me.menu_Stud, Me.menu_Charact})
        Me.menu_Tables.Name = "menu_Tables"
        Me.menu_Tables.Size = New System.Drawing.Size(69, 20)
        Me.menu_Tables.Text = "Таблицы"
        '
        'menu_Accounts
        '
        Me.menu_Accounts.Name = "menu_Accounts"
        Me.menu_Accounts.Size = New System.Drawing.Size(250, 22)
        Me.menu_Accounts.Text = "Аккаунты"
        '
        'menu_Vid_rabot
        '
        Me.menu_Vid_rabot.Name = "menu_Vid_rabot"
        Me.menu_Vid_rabot.Size = New System.Drawing.Size(250, 22)
        Me.menu_Vid_rabot.Text = "Виды работ"
        '
        'menu_History
        '
        Me.menu_History.Name = "menu_History"
        Me.menu_History.Size = New System.Drawing.Size(250, 22)
        Me.menu_History.Text = "История практикантов"
        '
        'menu_Org
        '
        Me.menu_Org.Name = "menu_Org"
        Me.menu_Org.Size = New System.Drawing.Size(250, 22)
        Me.menu_Org.Text = "Организации"
        '
        'menu_Otv_lica
        '
        Me.menu_Otv_lica.Name = "menu_Otv_lica"
        Me.menu_Otv_lica.Size = New System.Drawing.Size(250, 22)
        Me.menu_Otv_lica.Text = "Ответственные лица"
        '
        'menu_Uch_practiki
        '
        Me.menu_Uch_practiki.Name = "menu_Uch_practiki"
        Me.menu_Uch_practiki.Size = New System.Drawing.Size(250, 22)
        Me.menu_Uch_practiki.Text = "Проф. модули и учеб. практики"
        '
        'menu_Rukovod
        '
        Me.menu_Rukovod.Name = "menu_Rukovod"
        Me.menu_Rukovod.Size = New System.Drawing.Size(250, 22)
        Me.menu_Rukovod.Text = "Руководители практики"
        '
        'menu_Spec
        '
        Me.menu_Spec.Name = "menu_Spec"
        Me.menu_Spec.Size = New System.Drawing.Size(250, 22)
        Me.menu_Spec.Text = "Специальности"
        '
        'menu_Stat_sved
        '
        Me.menu_Stat_sved.Name = "menu_Stat_sved"
        Me.menu_Stat_sved.Size = New System.Drawing.Size(250, 22)
        Me.menu_Stat_sved.Text = "Статические сведения"
        '
        'menu_Stud
        '
        Me.menu_Stud.Name = "menu_Stud"
        Me.menu_Stud.Size = New System.Drawing.Size(250, 22)
        Me.menu_Stud.Text = "Студенты (курсанты)"
        '
        'menu_Charact
        '
        Me.menu_Charact.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem12, Me.ToolStripMenuItem13, Me.ToolStripMenuItem14, Me.ToolStripMenuItem15, Me.ToolStripMenuItem16})
        Me.menu_Charact.Name = "menu_Charact"
        Me.menu_Charact.Size = New System.Drawing.Size(250, 22)
        Me.menu_Charact.Text = "Характеристика"
        '
        'ToolStripMenuItem12
        '
        Me.ToolStripMenuItem12.Name = "ToolStripMenuItem12"
        Me.ToolStripMenuItem12.Size = New System.Drawing.Size(194, 22)
        Me.ToolStripMenuItem12.Text = "Начало"
        '
        'ToolStripMenuItem13
        '
        Me.ToolStripMenuItem13.Name = "ToolStripMenuItem13"
        Me.ToolStripMenuItem13.Size = New System.Drawing.Size(194, 22)
        Me.ToolStripMenuItem13.Text = "Дополнение к началу"
        '
        'ToolStripMenuItem14
        '
        Me.ToolStripMenuItem14.Name = "ToolStripMenuItem14"
        Me.ToolStripMenuItem14.Size = New System.Drawing.Size(194, 22)
        Me.ToolStripMenuItem14.Text = "Основа"
        '
        'ToolStripMenuItem15
        '
        Me.ToolStripMenuItem15.Name = "ToolStripMenuItem15"
        Me.ToolStripMenuItem15.Size = New System.Drawing.Size(194, 22)
        Me.ToolStripMenuItem15.Text = "Нарекания"
        '
        'ToolStripMenuItem16
        '
        Me.ToolStripMenuItem16.Name = "ToolStripMenuItem16"
        Me.ToolStripMenuItem16.Size = New System.Drawing.Size(194, 22)
        Me.ToolStripMenuItem16.Text = "Итог"
        '
        'menu_Help
        '
        Me.menu_Help.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menu_File_Help, Me.menu_About})
        Me.menu_Help.Name = "menu_Help"
        Me.menu_Help.Size = New System.Drawing.Size(65, 20)
        Me.menu_Help.Text = "Справка"
        '
        'menu_File_Help
        '
        Me.menu_File_Help.Name = "menu_File_Help"
        Me.menu_File_Help.Size = New System.Drawing.Size(179, 22)
        Me.menu_File_Help.Text = "Просмотр справки"
        '
        'menu_About
        '
        Me.menu_About.Name = "menu_About"
        Me.menu_About.Size = New System.Drawing.Size(179, 22)
        Me.menu_About.Text = "О программе"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.AutoScroll = True
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape2, Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(541, 639)
        Me.ShapeContainer1.TabIndex = 31
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape2
        '
        Me.RectangleShape2.AccessibleRole = System.Windows.Forms.AccessibleRole.[Default]
        Me.RectangleShape2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RectangleShape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.RectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape2.BorderColor = System.Drawing.Color.Transparent
        Me.RectangleShape2.Location = New System.Drawing.Point(10, 498)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape2.Size = New System.Drawing.Size(5, 127)
        '
        'RectangleShape1
        '
        Me.RectangleShape1.AccessibleRole = System.Windows.Forms.AccessibleRole.[Default]
        Me.RectangleShape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.Color.Transparent
        Me.RectangleShape1.Location = New System.Drawing.Point(10, 32)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape1.Size = New System.Drawing.Size(5, 181)
        '
        'ButtonPreview
        '
        Me.ButtonPreview.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPreview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonPreview.FlatAppearance.BorderSize = 0
        Me.ButtonPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPreview.Image = Global.attestation_practice.My.Resources.Resources.frm_button_refresh
        Me.ButtonPreview.Location = New System.Drawing.Point(323, 2)
        Me.ButtonPreview.Name = "ButtonPreview"
        Me.ButtonPreview.Size = New System.Drawing.Size(122, 29)
        Me.ButtonPreview.TabIndex = 23
        Me.ButtonPreview.UseVisualStyleBackColor = True
        '
        'ButtonPageSetup
        '
        Me.ButtonPageSetup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonPageSetup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonPageSetup.FlatAppearance.BorderSize = 0
        Me.ButtonPageSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPageSetup.Image = Global.attestation_practice.My.Resources.Resources.frm_button_pagesetup
        Me.ButtonPageSetup.Location = New System.Drawing.Point(186, 2)
        Me.ButtonPageSetup.Name = "ButtonPageSetup"
        Me.ButtonPageSetup.Size = New System.Drawing.Size(131, 29)
        Me.ButtonPageSetup.TabIndex = 22
        Me.ButtonPageSetup.UseVisualStyleBackColor = True
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 37)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(23, 25)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(451, 563)
        Me.WebBrowser1.TabIndex = 27
        '
        'ButtonPrintPreview
        '
        Me.ButtonPrintPreview.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonPrintPreview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonPrintPreview.FlatAppearance.BorderSize = 0
        Me.ButtonPrintPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPrintPreview.Image = Global.attestation_practice.My.Resources.Resources.frm_button_printpreview
        Me.ButtonPrintPreview.Location = New System.Drawing.Point(253, 607)
        Me.ButtonPrintPreview.Name = "ButtonPrintPreview"
        Me.ButtonPrintPreview.Size = New System.Drawing.Size(194, 29)
        Me.ButtonPrintPreview.TabIndex = 26
        Me.ButtonPrintPreview.UseVisualStyleBackColor = True
        Me.ButtonPrintPreview.Visible = False
        '
        'ButtonPrint
        '
        Me.ButtonPrint.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonPrint.BackColor = System.Drawing.Color.Transparent
        Me.ButtonPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonPrint.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonPrint.FlatAppearance.BorderSize = 0
        Me.ButtonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPrint.Image = Global.attestation_practice.My.Resources.Resources.frm_button_print
        Me.ButtonPrint.Location = New System.Drawing.Point(146, 607)
        Me.ButtonPrint.Name = "ButtonPrint"
        Me.ButtonPrint.Size = New System.Drawing.Size(102, 29)
        Me.ButtonPrint.TabIndex = 25
        Me.ButtonPrint.UseVisualStyleBackColor = False
        '
        'ButtonExportToWord
        '
        Me.ButtonExportToWord.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.ButtonExportToWord.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonExportToWord.FlatAppearance.BorderSize = 0
        Me.ButtonExportToWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonExportToWord.Image = Global.attestation_practice.My.Resources.Resources.frm_button_Export_to_Word
        Me.ButtonExportToWord.Location = New System.Drawing.Point(13, 607)
        Me.ButtonExportToWord.Name = "ButtonExportToWord"
        Me.ButtonExportToWord.Size = New System.Drawing.Size(130, 29)
        Me.ButtonExportToWord.TabIndex = 24
        Me.ButtonExportToWord.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(3, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(391, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Предварительный просмотр"
        '
        'TbluchpractikaBindingSource
        '
        Me.TbluchpractikaBindingSource.DataMember = "tbl_uch_practika"
        Me.TbluchpractikaBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_specTableAdapter
        '
        Me.Tbl_specTableAdapter.ClearBeforeFill = True
        '
        'TblstudBindingSource
        '
        Me.TblstudBindingSource.DataMember = "tbl_stud"
        Me.TblstudBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_studTableAdapter
        '
        Me.Tbl_studTableAdapter.ClearBeforeFill = True
        '
        'Tbl_uch_practikaTableAdapter
        '
        Me.Tbl_uch_practikaTableAdapter.ClearBeforeFill = True
        '
        'Qr_studTableAdapter
        '
        Me.Qr_studTableAdapter.ClearBeforeFill = True
        '
        'TblruckovodpractikiBindingSource
        '
        Me.TblruckovodpractikiBindingSource.DataMember = "tbl_ruckovod_practiki"
        Me.TblruckovodpractikiBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_ruckovod_practikiTableAdapter
        '
        Me.Tbl_ruckovod_practikiTableAdapter.ClearBeforeFill = True
        '
        'Qr_ruckovod_practikiTableAdapter
        '
        Me.Qr_ruckovod_practikiTableAdapter.ClearBeforeFill = True
        '
        'TblotvlicoorgBindingSource
        '
        Me.TblotvlicoorgBindingSource.DataMember = "tbl_otv_lico_org"
        Me.TblotvlicoorgBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_otv_lico_orgTableAdapter
        '
        Me.Tbl_otv_lico_orgTableAdapter.ClearBeforeFill = True
        '
        'Qr_otv_lico_orgTableAdapter
        '
        Me.Qr_otv_lico_orgTableAdapter.ClearBeforeFill = True
        '
        'Tbl_orgTableAdapter
        '
        Me.Tbl_orgTableAdapter.ClearBeforeFill = True
        '
        'Tbl_vid_rabotTableAdapter
        '
        Me.Tbl_vid_rabotTableAdapter.ClearBeforeFill = True
        '
        'Tbl_stat_svedBindingSource
        '
        Me.Tbl_stat_svedBindingSource.DataMember = "tbl_stat_sved"
        Me.Tbl_stat_svedBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_stat_svedTableAdapter
        '
        Me.Tbl_stat_svedTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.tbl_accountTableAdapter = Nothing
        Me.TableAdapterManager.tbl_journal_ratingTableAdapter = Nothing
        Me.TableAdapterManager.tbl_orgTableAdapter = Me.Tbl_orgTableAdapter
        Me.TableAdapterManager.tbl_otv_lico_orgTableAdapter = Me.Tbl_otv_lico_orgTableAdapter
        Me.TableAdapterManager.tbl_ruckovod_practikiTableAdapter = Me.Tbl_ruckovod_practikiTableAdapter
        Me.TableAdapterManager.tbl_specTableAdapter = Me.Tbl_specTableAdapter
        Me.TableAdapterManager.tbl_stat_svedTableAdapter = Me.Tbl_stat_svedTableAdapter
        Me.TableAdapterManager.tbl_studTableAdapter = Me.Tbl_studTableAdapter
        Me.TableAdapterManager.tbl_uch_practikaTableAdapter = Me.Tbl_uch_practikaTableAdapter
        Me.TableAdapterManager.tbl_var_beginTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_narekanTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_osnovTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_rabotTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_svodTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vid_rabotTableAdapter = Me.Tbl_vid_rabotTableAdapter
        Me.TableAdapterManager.UpdateOrder = attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Tbl_journal_ratingBindingSource
        '
        Me.Tbl_journal_ratingBindingSource.DataMember = "tbl_journal_rating"
        Me.Tbl_journal_ratingBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_journal_ratingTableAdapter
        '
        Me.Tbl_journal_ratingTableAdapter.ClearBeforeFill = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "Файлы баз данных Microsoft Access (*.accdb)|*.accdb"
        Me.OpenFileDialog1.Title = "Выбор файла базы данных Microsoft Access"
        '
        'Qr_uch_practikaTableAdapter
        '
        Me.Qr_uch_practikaTableAdapter.ClearBeforeFill = True
        '
        'menu_Remember_User
        '
        Me.menu_Remember_User.CheckOnClick = True
        Me.menu_Remember_User.Name = "menu_Remember_User"
        Me.menu_Remember_User.Size = New System.Drawing.Size(203, 22)
        Me.menu_Remember_User.Text = "Входить автоматически"
        '
        'frm_index
        '
        Me.AcceptButton = Me.ButtonPrint
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1010, 641)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MinimumSize = New System.Drawing.Size(16, 465)
        Me.Name = "frm_index"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Аттестация. Учебная практика"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.QrotvlicoorgBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QrruckovodpractikiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_vid_rabotDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblvidrabotBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblorgBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbluchpractikaBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Qr_uch_practikaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblspecBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QrstudBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.TbluchpractikaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblstudBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblruckovodpractikiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblotvlicoorgBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_stat_svedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_journal_ratingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelStud As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTbl_stud As System.Windows.Forms.ComboBox
    Friend WithEvents LabelSpec As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTbl_spec As System.Windows.Forms.ComboBox
    Friend WithEvents LabelKurs As System.Windows.Forms.Label
    Friend WithEvents ComboBoxKurs As System.Windows.Forms.ComboBox
    Friend WithEvents LabelUch_praktika As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTbl_uch_practika As System.Windows.Forms.ComboBox
    Friend WithEvents LabelModul As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTbl_uch_practika_modul As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxHour As System.Windows.Forms.TextBox
    Friend WithEvents LabelHour As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelData As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelOrg As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTbl_org As System.Windows.Forms.ComboBox
    Friend WithEvents Tbl_vid_rabotDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents LabelDataRating As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelOtv_lico As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTbl_otv_lico As System.Windows.Forms.ComboBox
    Friend WithEvents LabelRukovod As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTbl_rukovod_praktiki As System.Windows.Forms.ComboBox
    Friend WithEvents Attestation_practiceDataSet As attestation_practice.attestation_practiceDataSet
    Friend WithEvents TblspecBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_specTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_specTableAdapter
    Friend WithEvents TblstudBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_studTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_studTableAdapter
    Friend WithEvents TbluchpractikaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_uch_practikaTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_uch_practikaTableAdapter
    Friend WithEvents QrstudBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Qr_studTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.qr_studTableAdapter
    Friend WithEvents TblruckovodpractikiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_ruckovod_practikiTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_ruckovod_practikiTableAdapter
    Friend WithEvents QrruckovodpractikiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Qr_ruckovod_practikiTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.qr_ruckovod_practikiTableAdapter
    Friend WithEvents TblotvlicoorgBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_otv_lico_orgTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_otv_lico_orgTableAdapter
    Friend WithEvents QrotvlicoorgBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Qr_otv_lico_orgTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.qr_otv_lico_orgTableAdapter
    Friend WithEvents TblorgBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_orgTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_orgTableAdapter
    Friend WithEvents TblvidrabotBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_vid_rabotTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_vid_rabotTableAdapter
    Friend WithEvents CheckBoxTbl_uch_practika As System.Windows.Forms.CheckBox
    Friend WithEvents TbluchpractikaBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents CheckBoxTbl_spec As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxKurs As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonClearTbl_uch_practika As System.Windows.Forms.Button
    Friend WithEvents ButtonClearTbl_uch_practika_modul As System.Windows.Forms.Button
    Friend WithEvents ButtonClearTbl_stud As System.Windows.Forms.Button
    Friend WithEvents ButtonClearTbl_spec As System.Windows.Forms.Button
    Friend WithEvents ButtonClearTbl_vid_rabot As System.Windows.Forms.Button
    Friend WithEvents ButtonPrintPreview As System.Windows.Forms.Button
    Friend WithEvents ButtonPrint As System.Windows.Forms.Button
    Friend WithEvents ButtonExportToWord As System.Windows.Forms.Button
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents ButtonPageSetup As System.Windows.Forms.Button
    Friend WithEvents Tbl_stat_svedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_stat_svedTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_stat_svedTableAdapter
    Friend WithEvents TableAdapterManager As attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ButtonPreview As System.Windows.Forms.Button
    Friend WithEvents CheckBoxTbl_uch_practika1 As System.Windows.Forms.CheckBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents menu_File As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Change_User As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Operation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents menu_CLS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Refresh As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_PageSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_ExportToWord As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Print As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_PrintViewer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Tables As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Spec As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Stud As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Uch_practiki As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Vid_rabot As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Rukovod As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Otv_lica As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Org As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Stat_sved As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_History As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Accounts As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Charact As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem12 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem13 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem14 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem15 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem16 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Help As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_File_Help As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_About As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IdvidrabotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IduchpractikavidrabotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckvidrabotDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NamvidrabotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RatingvidrabotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tbl_journal_ratingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_journal_ratingTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_journal_ratingTableAdapter
    Friend WithEvents menu_Select_Att_List As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menu_Browse_DB As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Qr_uch_practikaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Qr_uch_practikaTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.qr_uch_practikaTableAdapter
    Friend WithEvents menu_Remember_User As System.Windows.Forms.ToolStripMenuItem
End Class
