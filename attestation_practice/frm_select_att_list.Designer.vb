<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_select_att_list
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_select_att_list))
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LabelUch_praktika = New System.Windows.Forms.Label()
        Me.ComboBoxTbl_uch_practika = New System.Windows.Forms.ComboBox()
        Me.TbluchpractikaBindingSource3 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Attestation_practiceDataSet = New attestation_practice.attestation_practiceDataSet()
        Me.LabelModul = New System.Windows.Forms.Label()
        Me.ComboBoxTbl_uch_practika_modul = New System.Windows.Forms.ComboBox()
        Me.TbluchpractikaBindingSource2 = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelSpec = New System.Windows.Forms.Label()
        Me.ComboBoxTbl_spec = New System.Windows.Forms.ComboBox()
        Me.TblspecBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.LabelDataRating = New System.Windows.Forms.Label()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.CheckBoxData = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Qr_journal_ratingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Qr_journal_ratingTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.qr_journal_ratingTableAdapter()
        Me.TableAdapterManager = New attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager()
        Me.Tbl_specTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_specTableAdapter()
        Me.Tbl_uch_practikaTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_uch_practikaTableAdapter()
        Me.Qr_journal_ratingBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Qr_journal_ratingDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.QrstudBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TblspecBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TbluchpractikaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TbluchpractikaBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qr_studTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.qr_studTableAdapter()
        Me.TblstudBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_studTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_studTableAdapter()
        Me.QrstudBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ButtonClearTbl_vid_rabot = New System.Windows.Forms.Button()
        Me.Tbl_journal_ratingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_journal_ratingTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_journal_ratingTableAdapter()
        Me.Tbl_journal_ratingDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn7 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn33 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn34 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.TbluchpractikaBindingSource3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbluchpractikaBindingSource2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblspecBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Qr_journal_ratingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Qr_journal_ratingBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Qr_journal_ratingBindingNavigator.SuspendLayout()
        CType(Me.Qr_journal_ratingDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QrstudBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblspecBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbluchpractikaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbluchpractikaBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblstudBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QrstudBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_journal_ratingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_journal_ratingDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RectangleShape1
        '
        Me.RectangleShape1.AccessibleRole = System.Windows.Forms.AccessibleRole.[Default]
        Me.RectangleShape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.Color.Transparent
        Me.RectangleShape1.Location = New System.Drawing.Point(10, 60)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape1.Size = New System.Drawing.Size(5, 134)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(860, 750)
        Me.ShapeContainer1.TabIndex = 3
        Me.ShapeContainer1.TabStop = False
        '
        'LabelUch_praktika
        '
        Me.LabelUch_praktika.AutoSize = True
        Me.LabelUch_praktika.Location = New System.Drawing.Point(23, 133)
        Me.LabelUch_praktika.Name = "LabelUch_praktika"
        Me.LabelUch_praktika.Size = New System.Drawing.Size(87, 16)
        Me.LabelUch_praktika.TabIndex = 18
        Me.LabelUch_praktika.Text = "Уч. практика:"
        '
        'ComboBoxTbl_uch_practika
        '
        Me.ComboBoxTbl_uch_practika.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxTbl_uch_practika.DataSource = Me.TbluchpractikaBindingSource3
        Me.ComboBoxTbl_uch_practika.DisplayMember = "nam_uch_practiki"
        Me.ComboBoxTbl_uch_practika.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTbl_uch_practika.FormattingEnabled = True
        Me.ComboBoxTbl_uch_practika.Location = New System.Drawing.Point(147, 131)
        Me.ComboBoxTbl_uch_practika.Name = "ComboBoxTbl_uch_practika"
        Me.ComboBoxTbl_uch_practika.Size = New System.Drawing.Size(383, 24)
        Me.ComboBoxTbl_uch_practika.TabIndex = 2
        Me.ComboBoxTbl_uch_practika.ValueMember = "id_uch_practiki"
        '
        'TbluchpractikaBindingSource3
        '
        Me.TbluchpractikaBindingSource3.DataMember = "tbl_uch_practika"
        Me.TbluchpractikaBindingSource3.DataSource = Me.Attestation_practiceDataSet
        '
        'Attestation_practiceDataSet
        '
        Me.Attestation_practiceDataSet.DataSetName = "attestation_practiceDataSet"
        Me.Attestation_practiceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'LabelModul
        '
        Me.LabelModul.AutoSize = True
        Me.LabelModul.Location = New System.Drawing.Point(23, 103)
        Me.LabelModul.Name = "LabelModul"
        Me.LabelModul.Size = New System.Drawing.Size(97, 16)
        Me.LabelModul.TabIndex = 16
        Me.LabelModul.Text = "Проф. модуль:"
        '
        'ComboBoxTbl_uch_practika_modul
        '
        Me.ComboBoxTbl_uch_practika_modul.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxTbl_uch_practika_modul.DataSource = Me.TbluchpractikaBindingSource2
        Me.ComboBoxTbl_uch_practika_modul.DisplayMember = "nam_prof_modul_uch_practiki"
        Me.ComboBoxTbl_uch_practika_modul.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTbl_uch_practika_modul.FormattingEnabled = True
        Me.ComboBoxTbl_uch_practika_modul.Location = New System.Drawing.Point(147, 101)
        Me.ComboBoxTbl_uch_practika_modul.Name = "ComboBoxTbl_uch_practika_modul"
        Me.ComboBoxTbl_uch_practika_modul.Size = New System.Drawing.Size(383, 24)
        Me.ComboBoxTbl_uch_practika_modul.TabIndex = 1
        Me.ComboBoxTbl_uch_practika_modul.ValueMember = "id_uch_practiki"
        '
        'TbluchpractikaBindingSource2
        '
        Me.TbluchpractikaBindingSource2.DataMember = "tbl_uch_practika"
        Me.TbluchpractikaBindingSource2.DataSource = Me.Attestation_practiceDataSet
        '
        'LabelSpec
        '
        Me.LabelSpec.AutoSize = True
        Me.LabelSpec.Location = New System.Drawing.Point(23, 71)
        Me.LabelSpec.Name = "LabelSpec"
        Me.LabelSpec.Size = New System.Drawing.Size(103, 16)
        Me.LabelSpec.TabIndex = 14
        Me.LabelSpec.Text = "Специальность:"
        '
        'ComboBoxTbl_spec
        '
        Me.ComboBoxTbl_spec.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxTbl_spec.DataSource = Me.TblspecBindingSource1
        Me.ComboBoxTbl_spec.DisplayMember = "nam_spec"
        Me.ComboBoxTbl_spec.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTbl_spec.FormattingEnabled = True
        Me.ComboBoxTbl_spec.Location = New System.Drawing.Point(147, 71)
        Me.ComboBoxTbl_spec.Name = "ComboBoxTbl_spec"
        Me.ComboBoxTbl_spec.Size = New System.Drawing.Size(383, 24)
        Me.ComboBoxTbl_spec.TabIndex = 0
        Me.ComboBoxTbl_spec.ValueMember = "id_spec"
        '
        'TblspecBindingSource1
        '
        Me.TblspecBindingSource1.DataMember = "tbl_spec"
        Me.TblspecBindingSource1.DataSource = Me.Attestation_practiceDataSet
        '
        'LabelDataRating
        '
        Me.LabelDataRating.AutoSize = True
        Me.LabelDataRating.Location = New System.Drawing.Point(23, 165)
        Me.LabelDataRating.Name = "LabelDataRating"
        Me.LabelDataRating.Size = New System.Drawing.Size(40, 16)
        Me.LabelDataRating.TabIndex = 23
        Me.LabelDataRating.Text = "Дата:"
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.CalendarForeColor = System.Drawing.Color.Black
        Me.DateTimePicker3.Location = New System.Drawing.Point(147, 162)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(156, 22)
        Me.DateTimePicker3.TabIndex = 3
        '
        'CheckBoxData
        '
        Me.CheckBoxData.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBoxData.AutoSize = True
        Me.CheckBoxData.Checked = True
        Me.CheckBoxData.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxData.FlatAppearance.BorderSize = 0
        Me.CheckBoxData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBoxData.Image = CType(resources.GetObject("CheckBoxData.Image"), System.Drawing.Image)
        Me.CheckBoxData.Location = New System.Drawing.Point(306, 161)
        Me.CheckBoxData.Name = "CheckBoxData"
        Me.CheckBoxData.Size = New System.Drawing.Size(21, 21)
        Me.CheckBoxData.TabIndex = 24
        Me.CheckBoxData.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(365, 16)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Выбор готового аттестационного листа студента (курсанта):"
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.attestation_practice.My.Resources.Resources.frm_button_Cancel
        Me.Button2.Location = New System.Drawing.Point(761, 817)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 33)
        Me.Button2.TabIndex = 8
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.attestation_practice.My.Resources.Resources.frm_button_Accept
        Me.Button1.Location = New System.Drawing.Point(644, 817)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 33)
        Me.Button1.TabIndex = 7
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = Global.attestation_practice.My.Resources.Resources.frm_button_open_for_edit
        Me.Button3.Location = New System.Drawing.Point(10, 817)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(197, 33)
        Me.Button3.TabIndex = 6
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Qr_journal_ratingBindingSource
        '
        Me.Qr_journal_ratingBindingSource.DataMember = "qr_journal_rating"
        Me.Qr_journal_ratingBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'Qr_journal_ratingTableAdapter
        '
        Me.Qr_journal_ratingTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.tbl_accountTableAdapter = Nothing
        Me.TableAdapterManager.tbl_journal_ratingTableAdapter = Nothing
        Me.TableAdapterManager.tbl_orgTableAdapter = Nothing
        Me.TableAdapterManager.tbl_otv_lico_orgTableAdapter = Nothing
        Me.TableAdapterManager.tbl_ruckovod_practikiTableAdapter = Nothing
        Me.TableAdapterManager.tbl_specTableAdapter = Me.Tbl_specTableAdapter
        Me.TableAdapterManager.tbl_stat_svedTableAdapter = Nothing
        Me.TableAdapterManager.tbl_studTableAdapter = Nothing
        Me.TableAdapterManager.tbl_uch_practikaTableAdapter = Me.Tbl_uch_practikaTableAdapter
        Me.TableAdapterManager.tbl_var_beginTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_narekanTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_osnovTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_rabotTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_svodTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vid_rabotTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Tbl_specTableAdapter
        '
        Me.Tbl_specTableAdapter.ClearBeforeFill = True
        '
        'Tbl_uch_practikaTableAdapter
        '
        Me.Tbl_uch_practikaTableAdapter.ClearBeforeFill = True
        '
        'Qr_journal_ratingBindingNavigator
        '
        Me.Qr_journal_ratingBindingNavigator.AddNewItem = Nothing
        Me.Qr_journal_ratingBindingNavigator.BindingSource = Me.Qr_journal_ratingBindingSource
        Me.Qr_journal_ratingBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.Qr_journal_ratingBindingNavigator.DeleteItem = Nothing
        Me.Qr_journal_ratingBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2})
        Me.Qr_journal_ratingBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.Qr_journal_ratingBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.Qr_journal_ratingBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.Qr_journal_ratingBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.Qr_journal_ratingBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.Qr_journal_ratingBindingNavigator.Name = "Qr_journal_ratingBindingNavigator"
        Me.Qr_journal_ratingBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.Qr_journal_ratingBindingNavigator.Size = New System.Drawing.Size(860, 25)
        Me.Qr_journal_ratingBindingNavigator.TabIndex = 31
        Me.Qr_journal_ratingBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(43, 22)
        Me.BindingNavigatorCountItem.Text = "для {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Общее число элементов"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Переместить в начало"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Переместить назад"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Положение"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Текущее положение"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Переместить вперед"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Переместить в конец"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'Qr_journal_ratingDataGridView
        '
        Me.Qr_journal_ratingDataGridView.AllowUserToAddRows = False
        Me.Qr_journal_ratingDataGridView.AllowUserToDeleteRows = False
        Me.Qr_journal_ratingDataGridView.AllowUserToResizeRows = False
        Me.Qr_journal_ratingDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Qr_journal_ratingDataGridView.AutoGenerateColumns = False
        Me.Qr_journal_ratingDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Qr_journal_ratingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Qr_journal_ratingDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11})
        Me.Qr_journal_ratingDataGridView.DataSource = Me.Qr_journal_ratingBindingSource
        Me.Qr_journal_ratingDataGridView.Location = New System.Drawing.Point(0, 224)
        Me.Qr_journal_ratingDataGridView.MultiSelect = False
        Me.Qr_journal_ratingDataGridView.Name = "Qr_journal_ratingDataGridView"
        Me.Qr_journal_ratingDataGridView.ReadOnly = True
        Me.Qr_journal_ratingDataGridView.Size = New System.Drawing.Size(860, 279)
        Me.Qr_journal_ratingDataGridView.TabIndex = 4
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "id_stud_journal_rating"
        Me.DataGridViewTextBoxColumn1.DataSource = Me.QrstudBindingSource
        Me.DataGridViewTextBoxColumn1.DisplayMember = "fio_stud"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Студент (курсант)"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn1.ValueMember = "id_stud"
        Me.DataGridViewTextBoxColumn1.Width = 127
        '
        'QrstudBindingSource
        '
        Me.QrstudBindingSource.DataMember = "qr_stud"
        Me.QrstudBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "stud_journal_rating"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Студент (курсант) (нет в БД)"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 165
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "id_spec_journal_rating"
        Me.DataGridViewTextBoxColumn3.DataSource = Me.TblspecBindingSource
        Me.DataGridViewTextBoxColumn3.DisplayMember = "nam_spec"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Специальность"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn3.ValueMember = "id_spec"
        Me.DataGridViewTextBoxColumn3.Width = 124
        '
        'TblspecBindingSource
        '
        Me.TblspecBindingSource.DataMember = "tbl_spec"
        Me.TblspecBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "spec_journal_rating"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Специальность (нет в БД)"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 138
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "kurs_journal_rating"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Курс"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 62
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "id_prof_modul_journal_rating"
        Me.DataGridViewTextBoxColumn6.DataSource = Me.TbluchpractikaBindingSource
        Me.DataGridViewTextBoxColumn6.DisplayMember = "nam_prof_modul_uch_practiki"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Проф. модуль"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn6.ValueMember = "id_uch_practiki"
        Me.DataGridViewTextBoxColumn6.Width = 108
        '
        'TbluchpractikaBindingSource
        '
        Me.TbluchpractikaBindingSource.DataMember = "tbl_uch_practika"
        Me.TbluchpractikaBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "prof_modul_journal_rating"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Проф. модуль (нет в БД)"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 132
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "id_uch_practika_journal_rating"
        Me.DataGridViewTextBoxColumn8.DataSource = Me.TbluchpractikaBindingSource1
        Me.DataGridViewTextBoxColumn8.DisplayMember = "nam_uch_practiki"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Уч. практика"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn8.ValueMember = "id_uch_practiki"
        Me.DataGridViewTextBoxColumn8.Width = 99
        '
        'TbluchpractikaBindingSource1
        '
        Me.TbluchpractikaBindingSource1.DataMember = "tbl_uch_practika"
        Me.TbluchpractikaBindingSource1.DataSource = Me.Attestation_practiceDataSet
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "uch_practika_journal_rating"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Уч. практика (нет в БД)"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 123
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "data_journal_rating"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Дата оценивания"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 123
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "charac_journal_rating"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Характеристика"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 125
        '
        'Qr_studTableAdapter
        '
        Me.Qr_studTableAdapter.ClearBeforeFill = True
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
        'QrstudBindingSource1
        '
        Me.QrstudBindingSource1.DataMember = "qr_stud"
        Me.QrstudBindingSource1.DataSource = Me.Attestation_practiceDataSet
        '
        'ButtonClearTbl_vid_rabot
        '
        Me.ButtonClearTbl_vid_rabot.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClearTbl_vid_rabot.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearTbl_vid_rabot.FlatAppearance.BorderSize = 0
        Me.ButtonClearTbl_vid_rabot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearTbl_vid_rabot.Image = CType(resources.GetObject("ButtonClearTbl_vid_rabot.Image"), System.Drawing.Image)
        Me.ButtonClearTbl_vid_rabot.Location = New System.Drawing.Point(720, 190)
        Me.ButtonClearTbl_vid_rabot.Name = "ButtonClearTbl_vid_rabot"
        Me.ButtonClearTbl_vid_rabot.Size = New System.Drawing.Size(140, 28)
        Me.ButtonClearTbl_vid_rabot.TabIndex = 5
        Me.ButtonClearTbl_vid_rabot.UseVisualStyleBackColor = True
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
        'Tbl_journal_ratingDataGridView
        '
        Me.Tbl_journal_ratingDataGridView.AutoGenerateColumns = False
        Me.Tbl_journal_ratingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Tbl_journal_ratingDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewCheckBoxColumn4, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23, Me.DataGridViewTextBoxColumn24, Me.DataGridViewCheckBoxColumn5, Me.DataGridViewTextBoxColumn25, Me.DataGridViewTextBoxColumn26, Me.DataGridViewCheckBoxColumn6, Me.DataGridViewTextBoxColumn27, Me.DataGridViewTextBoxColumn28, Me.DataGridViewCheckBoxColumn7, Me.DataGridViewTextBoxColumn29, Me.DataGridViewTextBoxColumn30, Me.DataGridViewTextBoxColumn31, Me.DataGridViewTextBoxColumn32, Me.DataGridViewTextBoxColumn33, Me.DataGridViewTextBoxColumn34})
        Me.Tbl_journal_ratingDataGridView.DataSource = Me.Tbl_journal_ratingBindingSource
        Me.Tbl_journal_ratingDataGridView.Location = New System.Drawing.Point(6, 540)
        Me.Tbl_journal_ratingDataGridView.Name = "Tbl_journal_ratingDataGridView"
        Me.Tbl_journal_ratingDataGridView.Size = New System.Drawing.Size(805, 220)
        Me.Tbl_journal_ratingDataGridView.TabIndex = 0
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "id_journal_rating"
        Me.DataGridViewTextBoxColumn12.HeaderText = "id_journal_rating"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "id_spec_journal_rating"
        Me.DataGridViewTextBoxColumn13.HeaderText = "id_spec_journal_rating"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "spec_journal_rating"
        Me.DataGridViewTextBoxColumn14.HeaderText = "spec_journal_rating"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "spec_v_journal_rating"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "spec_v_journal_rating"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "kurs_journal_rating"
        Me.DataGridViewTextBoxColumn15.HeaderText = "kurs_journal_rating"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "id_stud_journal_rating"
        Me.DataGridViewTextBoxColumn16.HeaderText = "id_stud_journal_rating"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "stud_journal_rating"
        Me.DataGridViewTextBoxColumn17.HeaderText = "stud_journal_rating"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "stud_v_journal_rating"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "stud_v_journal_rating"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "id_prof_modul_journal_rating"
        Me.DataGridViewTextBoxColumn18.HeaderText = "id_prof_modul_journal_rating"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "prof_modul_journal_rating"
        Me.DataGridViewTextBoxColumn19.HeaderText = "prof_modul_journal_rating"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "prof_modul_v_journal_rating"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "prof_modul_v_journal_rating"
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "id_uch_practika_journal_rating"
        Me.DataGridViewTextBoxColumn20.HeaderText = "id_uch_practika_journal_rating"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "uch_practika_journal_rating"
        Me.DataGridViewTextBoxColumn21.HeaderText = "uch_practika_journal_rating"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        '
        'DataGridViewCheckBoxColumn4
        '
        Me.DataGridViewCheckBoxColumn4.DataPropertyName = "uch_practika_v_journal_rating"
        Me.DataGridViewCheckBoxColumn4.HeaderText = "uch_practika_v_journal_rating"
        Me.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4"
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "id_vid_rabot_journal_rating"
        Me.DataGridViewTextBoxColumn22.HeaderText = "id_vid_rabot_journal_rating"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "id_otv_lico_org_journal_rating"
        Me.DataGridViewTextBoxColumn23.HeaderText = "id_otv_lico_org_journal_rating"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        '
        'DataGridViewTextBoxColumn24
        '
        Me.DataGridViewTextBoxColumn24.DataPropertyName = "otv_lico_org_journal_rating"
        Me.DataGridViewTextBoxColumn24.HeaderText = "otv_lico_org_journal_rating"
        Me.DataGridViewTextBoxColumn24.Name = "DataGridViewTextBoxColumn24"
        '
        'DataGridViewCheckBoxColumn5
        '
        Me.DataGridViewCheckBoxColumn5.DataPropertyName = "otv_lico_org_v_journal_rating"
        Me.DataGridViewCheckBoxColumn5.HeaderText = "otv_lico_org_v_journal_rating"
        Me.DataGridViewCheckBoxColumn5.Name = "DataGridViewCheckBoxColumn5"
        '
        'DataGridViewTextBoxColumn25
        '
        Me.DataGridViewTextBoxColumn25.DataPropertyName = "id_ruckovod_practiki_journal_rating"
        Me.DataGridViewTextBoxColumn25.HeaderText = "id_ruckovod_practiki_journal_rating"
        Me.DataGridViewTextBoxColumn25.Name = "DataGridViewTextBoxColumn25"
        '
        'DataGridViewTextBoxColumn26
        '
        Me.DataGridViewTextBoxColumn26.DataPropertyName = "ruckovod_practiki_journal_rating"
        Me.DataGridViewTextBoxColumn26.HeaderText = "ruckovod_practiki_journal_rating"
        Me.DataGridViewTextBoxColumn26.Name = "DataGridViewTextBoxColumn26"
        '
        'DataGridViewCheckBoxColumn6
        '
        Me.DataGridViewCheckBoxColumn6.DataPropertyName = "ruckovod_practiki_v_journal_rating"
        Me.DataGridViewCheckBoxColumn6.HeaderText = "ruckovod_practiki_v_journal_rating"
        Me.DataGridViewCheckBoxColumn6.Name = "DataGridViewCheckBoxColumn6"
        '
        'DataGridViewTextBoxColumn27
        '
        Me.DataGridViewTextBoxColumn27.DataPropertyName = "id_org_journal_rating"
        Me.DataGridViewTextBoxColumn27.HeaderText = "id_org_journal_rating"
        Me.DataGridViewTextBoxColumn27.Name = "DataGridViewTextBoxColumn27"
        '
        'DataGridViewTextBoxColumn28
        '
        Me.DataGridViewTextBoxColumn28.DataPropertyName = "org_journal_rating"
        Me.DataGridViewTextBoxColumn28.HeaderText = "org_journal_rating"
        Me.DataGridViewTextBoxColumn28.Name = "DataGridViewTextBoxColumn28"
        '
        'DataGridViewCheckBoxColumn7
        '
        Me.DataGridViewCheckBoxColumn7.DataPropertyName = "org_v_journal_rating"
        Me.DataGridViewCheckBoxColumn7.HeaderText = "org_v_journal_rating"
        Me.DataGridViewCheckBoxColumn7.Name = "DataGridViewCheckBoxColumn7"
        '
        'DataGridViewTextBoxColumn29
        '
        Me.DataGridViewTextBoxColumn29.DataPropertyName = "rating_journal_rating"
        Me.DataGridViewTextBoxColumn29.HeaderText = "rating_journal_rating"
        Me.DataGridViewTextBoxColumn29.Name = "DataGridViewTextBoxColumn29"
        '
        'DataGridViewTextBoxColumn30
        '
        Me.DataGridViewTextBoxColumn30.DataPropertyName = "chas_journal_rating"
        Me.DataGridViewTextBoxColumn30.HeaderText = "chas_journal_rating"
        Me.DataGridViewTextBoxColumn30.Name = "DataGridViewTextBoxColumn30"
        '
        'DataGridViewTextBoxColumn31
        '
        Me.DataGridViewTextBoxColumn31.DataPropertyName = "data_b_journal_rating"
        Me.DataGridViewTextBoxColumn31.HeaderText = "data_b_journal_rating"
        Me.DataGridViewTextBoxColumn31.Name = "DataGridViewTextBoxColumn31"
        '
        'DataGridViewTextBoxColumn32
        '
        Me.DataGridViewTextBoxColumn32.DataPropertyName = "data_e_journal_rating"
        Me.DataGridViewTextBoxColumn32.HeaderText = "data_e_journal_rating"
        Me.DataGridViewTextBoxColumn32.Name = "DataGridViewTextBoxColumn32"
        '
        'DataGridViewTextBoxColumn33
        '
        Me.DataGridViewTextBoxColumn33.DataPropertyName = "data_journal_rating"
        Me.DataGridViewTextBoxColumn33.HeaderText = "data_journal_rating"
        Me.DataGridViewTextBoxColumn33.Name = "DataGridViewTextBoxColumn33"
        '
        'DataGridViewTextBoxColumn34
        '
        Me.DataGridViewTextBoxColumn34.DataPropertyName = "charac_journal_rating"
        Me.DataGridViewTextBoxColumn34.HeaderText = "charac_journal_rating"
        Me.DataGridViewTextBoxColumn34.Name = "DataGridViewTextBoxColumn34"
        '
        'frm_select_att_list
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(860, 750)
        Me.Controls.Add(Me.Tbl_journal_ratingDataGridView)
        Me.Controls.Add(Me.ButtonClearTbl_vid_rabot)
        Me.Controls.Add(Me.Qr_journal_ratingDataGridView)
        Me.Controls.Add(Me.Qr_journal_ratingBindingNavigator)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBoxData)
        Me.Controls.Add(Me.LabelDataRating)
        Me.Controls.Add(Me.DateTimePicker3)
        Me.Controls.Add(Me.LabelUch_praktika)
        Me.Controls.Add(Me.ComboBoxTbl_uch_practika)
        Me.Controls.Add(Me.LabelModul)
        Me.Controls.Add(Me.ComboBoxTbl_uch_practika_modul)
        Me.Controls.Add(Me.LabelSpec)
        Me.Controls.Add(Me.ComboBoxTbl_spec)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_select_att_list"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Аттестация. Учебная практика: Выбор готового аттестационного листа"
        CType(Me.TbluchpractikaBindingSource3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbluchpractikaBindingSource2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblspecBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Qr_journal_ratingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Qr_journal_ratingBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Qr_journal_ratingBindingNavigator.ResumeLayout(False)
        Me.Qr_journal_ratingBindingNavigator.PerformLayout()
        CType(Me.Qr_journal_ratingDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QrstudBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblspecBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbluchpractikaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbluchpractikaBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblstudBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QrstudBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_journal_ratingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_journal_ratingDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LabelUch_praktika As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTbl_uch_practika As System.Windows.Forms.ComboBox
    Friend WithEvents LabelModul As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTbl_uch_practika_modul As System.Windows.Forms.ComboBox
    Friend WithEvents LabelSpec As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTbl_spec As System.Windows.Forms.ComboBox
    Friend WithEvents LabelDataRating As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents CheckBoxData As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Attestation_practiceDataSet As attestation_practice.attestation_practiceDataSet
    Friend WithEvents Qr_journal_ratingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Qr_journal_ratingTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.qr_journal_ratingTableAdapter
    Friend WithEvents TableAdapterManager As attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Qr_journal_ratingBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Qr_journal_ratingDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents QrstudBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Qr_studTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.qr_studTableAdapter
    Friend WithEvents Tbl_specTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_specTableAdapter
    Friend WithEvents TblspecBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_uch_practikaTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_uch_practikaTableAdapter
    Friend WithEvents TbluchpractikaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TbluchpractikaBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents TblstudBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_studTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_studTableAdapter
    Friend WithEvents TbluchpractikaBindingSource3 As System.Windows.Forms.BindingSource
    Friend WithEvents TbluchpractikaBindingSource2 As System.Windows.Forms.BindingSource
    Friend WithEvents TblspecBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents QrstudBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents ButtonClearTbl_vid_rabot As System.Windows.Forms.Button
    Friend WithEvents Tbl_journal_ratingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_journal_ratingTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_journal_ratingTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tbl_journal_ratingDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn24 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn25 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn6 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn7 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn29 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn33 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn34 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
