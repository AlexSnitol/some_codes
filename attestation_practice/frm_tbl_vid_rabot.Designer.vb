<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tbl_vid_rabot
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_tbl_vid_rabot))
        Me.Attestation_practiceDataSet = New attestation_practice.attestation_practiceDataSet()
        Me.Tbl_vid_rabotBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_vid_rabotTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_vid_rabotTableAdapter()
        Me.TableAdapterManager = New attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager()
        Me.Tbl_uch_practikaTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_uch_practikaTableAdapter()
        Me.Tbl_vid_rabotBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Tbl_vid_rabotBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.Tbl_vid_rabotDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TbluchpractikaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelModul = New System.Windows.Forms.Label()
        Me.ComboBoxTbl_uch_practika_modul = New System.Windows.Forms.ComboBox()
        Me.ButtonClearTbl_spec = New System.Windows.Forms.Button()
        Me.ComboBoxTbl_spec = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LabelUch_praktika = New System.Windows.Forms.Label()
        Me.ComboBoxTbl_uch_practika = New System.Windows.Forms.ComboBox()
        Me.TblspecBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_specTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_specTableAdapter()
        Me.Qr_uch_practikaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Qr_uch_practikaTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.qr_uch_practikaTableAdapter()
        Me.TbluchpractikaBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_vid_rabotBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_vid_rabotBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tbl_vid_rabotBindingNavigator.SuspendLayout()
        CType(Me.Tbl_vid_rabotDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbluchpractikaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblspecBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Qr_uch_practikaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbluchpractikaBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Attestation_practiceDataSet
        '
        Me.Attestation_practiceDataSet.DataSetName = "attestation_practiceDataSet"
        Me.Attestation_practiceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Tbl_vid_rabotBindingSource
        '
        Me.Tbl_vid_rabotBindingSource.DataMember = "tbl_vid_rabot"
        Me.Tbl_vid_rabotBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_vid_rabotTableAdapter
        '
        Me.Tbl_vid_rabotTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.tbl_accountTableAdapter = Nothing
        Me.TableAdapterManager.tbl_journal_ratingTableAdapter = Nothing
        Me.TableAdapterManager.tbl_orgTableAdapter = Nothing
        Me.TableAdapterManager.tbl_otv_lico_orgTableAdapter = Nothing
        Me.TableAdapterManager.tbl_ruckovod_practikiTableAdapter = Nothing
        Me.TableAdapterManager.tbl_specTableAdapter = Nothing
        Me.TableAdapterManager.tbl_stat_svedTableAdapter = Nothing
        Me.TableAdapterManager.tbl_studTableAdapter = Nothing
        Me.TableAdapterManager.tbl_uch_practikaTableAdapter = Me.Tbl_uch_practikaTableAdapter
        Me.TableAdapterManager.tbl_var_beginTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_narekanTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_osnovTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_rabotTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_svodTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vid_rabotTableAdapter = Me.Tbl_vid_rabotTableAdapter
        Me.TableAdapterManager.UpdateOrder = attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Tbl_uch_practikaTableAdapter
        '
        Me.Tbl_uch_practikaTableAdapter.ClearBeforeFill = True
        '
        'Tbl_vid_rabotBindingNavigator
        '
        Me.Tbl_vid_rabotBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.Tbl_vid_rabotBindingNavigator.BindingSource = Me.Tbl_vid_rabotBindingSource
        Me.Tbl_vid_rabotBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.Tbl_vid_rabotBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.Tbl_vid_rabotBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.Tbl_vid_rabotBindingNavigatorSaveItem})
        Me.Tbl_vid_rabotBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.Tbl_vid_rabotBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.Tbl_vid_rabotBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.Tbl_vid_rabotBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.Tbl_vid_rabotBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.Tbl_vid_rabotBindingNavigator.Name = "Tbl_vid_rabotBindingNavigator"
        Me.Tbl_vid_rabotBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.Tbl_vid_rabotBindingNavigator.Size = New System.Drawing.Size(862, 25)
        Me.Tbl_vid_rabotBindingNavigator.TabIndex = 0
        Me.Tbl_vid_rabotBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Добавить"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(43, 22)
        Me.BindingNavigatorCountItem.Text = "для {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Общее число элементов"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Удалить"
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
        'Tbl_vid_rabotBindingNavigatorSaveItem
        '
        Me.Tbl_vid_rabotBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tbl_vid_rabotBindingNavigatorSaveItem.Image = CType(resources.GetObject("Tbl_vid_rabotBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.Tbl_vid_rabotBindingNavigatorSaveItem.Name = "Tbl_vid_rabotBindingNavigatorSaveItem"
        Me.Tbl_vid_rabotBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.Tbl_vid_rabotBindingNavigatorSaveItem.Text = "Сохранить данные"
        '
        'Tbl_vid_rabotDataGridView
        '
        Me.Tbl_vid_rabotDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tbl_vid_rabotDataGridView.AutoGenerateColumns = False
        Me.Tbl_vid_rabotDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Tbl_vid_rabotDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Tbl_vid_rabotDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn4})
        Me.Tbl_vid_rabotDataGridView.DataSource = Me.Tbl_vid_rabotBindingSource
        Me.Tbl_vid_rabotDataGridView.Location = New System.Drawing.Point(0, 148)
        Me.Tbl_vid_rabotDataGridView.Name = "Tbl_vid_rabotDataGridView"
        Me.Tbl_vid_rabotDataGridView.Size = New System.Drawing.Size(862, 370)
        Me.Tbl_vid_rabotDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "id_vid_rabot"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 45
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "nam_vid_rabot"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Название работы"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "id_uch_practika_vid_rabot"
        Me.DataGridViewTextBoxColumn3.DataSource = Me.TbluchpractikaBindingSource
        Me.DataGridViewTextBoxColumn3.DisplayMember = "nam_uch_practiki"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Учебная практика"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn3.ValueMember = "id_uch_practiki"
        '
        'TbluchpractikaBindingSource
        '
        Me.TbluchpractikaBindingSource.DataMember = "tbl_uch_practika"
        Me.TbluchpractikaBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "check_vid_rabot"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Выбор (по умолчанию)"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "rating_vid_rabot"
        Me.DataGridViewTextBoxColumn4.HeaderText = "rating_vid_rabot"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RectangleShape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RectangleShape1.Location = New System.Drawing.Point(1, 26)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(860, 27)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(862, 518)
        Me.ShapeContainer1.TabIndex = 2
        Me.ShapeContainer1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Location = New System.Drawing.Point(3, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Таблица ""Виды работ"""
        '
        'LabelModul
        '
        Me.LabelModul.AutoSize = True
        Me.LabelModul.Location = New System.Drawing.Point(10, 91)
        Me.LabelModul.Name = "LabelModul"
        Me.LabelModul.Size = New System.Drawing.Size(97, 16)
        Me.LabelModul.TabIndex = 24
        Me.LabelModul.Text = "Проф. модуль:"
        '
        'ComboBoxTbl_uch_practika_modul
        '
        Me.ComboBoxTbl_uch_practika_modul.BackColor = System.Drawing.Color.White
        Me.ComboBoxTbl_uch_practika_modul.DataSource = Me.Qr_uch_practikaBindingSource
        Me.ComboBoxTbl_uch_practika_modul.DisplayMember = "nam_prof_modul_uch_practiki"
        Me.ComboBoxTbl_uch_practika_modul.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTbl_uch_practika_modul.FormattingEnabled = True
        Me.ComboBoxTbl_uch_practika_modul.Location = New System.Drawing.Point(119, 88)
        Me.ComboBoxTbl_uch_practika_modul.Name = "ComboBoxTbl_uch_practika_modul"
        Me.ComboBoxTbl_uch_practika_modul.Size = New System.Drawing.Size(350, 24)
        Me.ComboBoxTbl_uch_practika_modul.TabIndex = 23
        '
        'ButtonClearTbl_spec
        '
        Me.ButtonClearTbl_spec.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearTbl_spec.FlatAppearance.BorderSize = 0
        Me.ButtonClearTbl_spec.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearTbl_spec.Image = CType(resources.GetObject("ButtonClearTbl_spec.Image"), System.Drawing.Image)
        Me.ButtonClearTbl_spec.Location = New System.Drawing.Point(475, 58)
        Me.ButtonClearTbl_spec.Name = "ButtonClearTbl_spec"
        Me.ButtonClearTbl_spec.Size = New System.Drawing.Size(26, 26)
        Me.ButtonClearTbl_spec.TabIndex = 22
        Me.ButtonClearTbl_spec.UseVisualStyleBackColor = True
        '
        'ComboBoxTbl_spec
        '
        Me.ComboBoxTbl_spec.BackColor = System.Drawing.Color.White
        Me.ComboBoxTbl_spec.DataSource = Me.TblspecBindingSource
        Me.ComboBoxTbl_spec.DisplayMember = "nam_spec"
        Me.ComboBoxTbl_spec.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTbl_spec.FormattingEnabled = True
        Me.ComboBoxTbl_spec.Location = New System.Drawing.Point(119, 60)
        Me.ComboBoxTbl_spec.Name = "ComboBoxTbl_spec"
        Me.ComboBoxTbl_spec.Size = New System.Drawing.Size(350, 24)
        Me.ComboBoxTbl_spec.TabIndex = 21
        Me.ComboBoxTbl_spec.ValueMember = "id_spec"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Location = New System.Drawing.Point(10, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Специальность:"
        '
        'LabelUch_praktika
        '
        Me.LabelUch_praktika.AutoSize = True
        Me.LabelUch_praktika.Location = New System.Drawing.Point(10, 121)
        Me.LabelUch_praktika.Name = "LabelUch_praktika"
        Me.LabelUch_praktika.Size = New System.Drawing.Size(87, 16)
        Me.LabelUch_praktika.TabIndex = 26
        Me.LabelUch_praktika.Text = "Уч. практика:"
        '
        'ComboBoxTbl_uch_practika
        '
        Me.ComboBoxTbl_uch_practika.BackColor = System.Drawing.Color.White
        Me.ComboBoxTbl_uch_practika.DataSource = Me.TbluchpractikaBindingSource1
        Me.ComboBoxTbl_uch_practika.DisplayMember = "nam_uch_practiki"
        Me.ComboBoxTbl_uch_practika.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTbl_uch_practika.FormattingEnabled = True
        Me.ComboBoxTbl_uch_practika.Location = New System.Drawing.Point(119, 118)
        Me.ComboBoxTbl_uch_practika.Name = "ComboBoxTbl_uch_practika"
        Me.ComboBoxTbl_uch_practika.Size = New System.Drawing.Size(350, 24)
        Me.ComboBoxTbl_uch_practika.TabIndex = 27
        Me.ComboBoxTbl_uch_practika.ValueMember = "id_uch_practiki"
        '
        'TblspecBindingSource
        '
        Me.TblspecBindingSource.DataMember = "tbl_spec"
        Me.TblspecBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_specTableAdapter
        '
        Me.Tbl_specTableAdapter.ClearBeforeFill = True
        '
        'Qr_uch_practikaBindingSource
        '
        Me.Qr_uch_practikaBindingSource.DataMember = "qr_uch_practika"
        Me.Qr_uch_practikaBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'Qr_uch_practikaTableAdapter
        '
        Me.Qr_uch_practikaTableAdapter.ClearBeforeFill = True
        '
        'TbluchpractikaBindingSource1
        '
        Me.TbluchpractikaBindingSource1.DataMember = "tbl_uch_practika"
        Me.TbluchpractikaBindingSource1.DataSource = Me.Attestation_practiceDataSet
        '
        'frm_tbl_vid_rabot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(862, 518)
        Me.Controls.Add(Me.LabelUch_praktika)
        Me.Controls.Add(Me.ComboBoxTbl_uch_practika)
        Me.Controls.Add(Me.LabelModul)
        Me.Controls.Add(Me.ComboBoxTbl_uch_practika_modul)
        Me.Controls.Add(Me.ButtonClearTbl_spec)
        Me.Controls.Add(Me.ComboBoxTbl_spec)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Tbl_vid_rabotDataGridView)
        Me.Controls.Add(Me.Tbl_vid_rabotBindingNavigator)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(579, 176)
        Me.Name = "frm_tbl_vid_rabot"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Аттестация. Учебная практика: Таблица ""Виды работ"""
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_vid_rabotBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_vid_rabotBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tbl_vid_rabotBindingNavigator.ResumeLayout(False)
        Me.Tbl_vid_rabotBindingNavigator.PerformLayout()
        CType(Me.Tbl_vid_rabotDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbluchpractikaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblspecBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Qr_uch_practikaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbluchpractikaBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Attestation_practiceDataSet As attestation_practice.attestation_practiceDataSet
    Friend WithEvents Tbl_vid_rabotBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_vid_rabotTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_vid_rabotTableAdapter
    Friend WithEvents TableAdapterManager As attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Tbl_vid_rabotBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Tbl_vid_rabotBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tbl_vid_rabotDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tbl_uch_practikaTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_uch_practikaTableAdapter
    Friend WithEvents TbluchpractikaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LabelModul As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTbl_uch_practika_modul As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonClearTbl_spec As System.Windows.Forms.Button
    Friend WithEvents ComboBoxTbl_spec As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LabelUch_praktika As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTbl_uch_practika As System.Windows.Forms.ComboBox
    Friend WithEvents TblspecBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_specTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_specTableAdapter
    Friend WithEvents Qr_uch_practikaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Qr_uch_practikaTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.qr_uch_practikaTableAdapter
    Friend WithEvents TbluchpractikaBindingSource1 As System.Windows.Forms.BindingSource
End Class
