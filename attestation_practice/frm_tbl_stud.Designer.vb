<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tbl_stud
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_tbl_stud))
        Me.Attestation_practiceDataSet = New attestation_practice.attestation_practiceDataSet()
        Me.Tbl_studBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_studTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_studTableAdapter()
        Me.TableAdapterManager = New attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager()
        Me.Tbl_studBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
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
        Me.Tbl_studBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.Tbl_studDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TblspecBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Tbl_specTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_specTableAdapter()
        Me.ComboBoxKurs = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBoxTbl_spec = New System.Windows.Forms.ComboBox()
        Me.ButtonClearTbl_spec = New System.Windows.Forms.Button()
        Me.ButtonClearKurs = New System.Windows.Forms.Button()
        Me.TblspecBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_studBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_studBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tbl_studBindingNavigator.SuspendLayout()
        CType(Me.Tbl_studDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblspecBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblspecBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Attestation_practiceDataSet
        '
        Me.Attestation_practiceDataSet.DataSetName = "attestation_practiceDataSet"
        Me.Attestation_practiceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Tbl_studBindingSource
        '
        Me.Tbl_studBindingSource.DataMember = "tbl_stud"
        Me.Tbl_studBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_studTableAdapter
        '
        Me.Tbl_studTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.tbl_studTableAdapter = Me.Tbl_studTableAdapter
        Me.TableAdapterManager.tbl_uch_practikaTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_beginTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_narekanTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_osnovTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_rabotTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_svodTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vid_rabotTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Tbl_studBindingNavigator
        '
        Me.Tbl_studBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.Tbl_studBindingNavigator.BindingSource = Me.Tbl_studBindingSource
        Me.Tbl_studBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.Tbl_studBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.Tbl_studBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.Tbl_studBindingNavigatorSaveItem})
        Me.Tbl_studBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.Tbl_studBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.Tbl_studBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.Tbl_studBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.Tbl_studBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.Tbl_studBindingNavigator.Name = "Tbl_studBindingNavigator"
        Me.Tbl_studBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.Tbl_studBindingNavigator.Size = New System.Drawing.Size(827, 25)
        Me.Tbl_studBindingNavigator.TabIndex = 3
        Me.Tbl_studBindingNavigator.Text = "BindingNavigator1"
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
        'Tbl_studBindingNavigatorSaveItem
        '
        Me.Tbl_studBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tbl_studBindingNavigatorSaveItem.Image = CType(resources.GetObject("Tbl_studBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.Tbl_studBindingNavigatorSaveItem.Name = "Tbl_studBindingNavigatorSaveItem"
        Me.Tbl_studBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.Tbl_studBindingNavigatorSaveItem.Text = "Сохранить данные"
        '
        'Tbl_studDataGridView
        '
        Me.Tbl_studDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tbl_studDataGridView.AutoGenerateColumns = False
        Me.Tbl_studDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Tbl_studDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Tbl_studDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7})
        Me.Tbl_studDataGridView.DataSource = Me.Tbl_studBindingSource
        Me.Tbl_studDataGridView.Location = New System.Drawing.Point(1, 88)
        Me.Tbl_studDataGridView.Name = "Tbl_studDataGridView"
        Me.Tbl_studDataGridView.Size = New System.Drawing.Size(825, 328)
        Me.Tbl_studDataGridView.TabIndex = 4
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "id_stud"
        Me.DataGridViewTextBoxColumn1.FillWeight = 53.29949!
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 45
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "fam_stud"
        Me.DataGridViewTextBoxColumn2.FillWeight = 107.7834!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Фамилия"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "nam_stud"
        Me.DataGridViewTextBoxColumn3.FillWeight = 107.7834!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Имя"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "sur_stud"
        Me.DataGridViewTextBoxColumn4.FillWeight = 107.7834!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Отчество"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "kurs_stud"
        Me.DataGridViewTextBoxColumn5.FillWeight = 107.7834!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Курс"
        Me.DataGridViewTextBoxColumn5.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn5.Width = 62
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "id_spec_stud"
        Me.DataGridViewTextBoxColumn6.DataSource = Me.TblspecBindingSource
        Me.DataGridViewTextBoxColumn6.DisplayMember = "nam_spec"
        Me.DataGridViewTextBoxColumn6.FillWeight = 107.7834!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Специальность"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn6.ValueMember = "id_spec"
        '
        'TblspecBindingSource
        '
        Me.TblspecBindingSource.DataMember = "tbl_spec"
        Me.TblspecBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "pol_stud"
        Me.DataGridViewTextBoxColumn7.FillWeight = 107.7834!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Пол"
        Me.DataGridViewTextBoxColumn7.Items.AddRange(New Object() {"м", "ж"})
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn7.Width = 56
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Location = New System.Drawing.Point(4, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 16)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Таблица ""Студенты (курсанты)"""
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RectangleShape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RectangleShape1.Location = New System.Drawing.Point(1, 25)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(825, 27)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(827, 416)
        Me.ShapeContainer1.TabIndex = 7
        Me.ShapeContainer1.TabStop = False
        '
        'Tbl_specTableAdapter
        '
        Me.Tbl_specTableAdapter.ClearBeforeFill = True
        '
        'ComboBoxKurs
        '
        Me.ComboBoxKurs.BackColor = System.Drawing.Color.White
        Me.ComboBoxKurs.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxKurs.FormattingEnabled = True
        Me.ComboBoxKurs.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.ComboBoxKurs.Location = New System.Drawing.Point(59, 58)
        Me.ComboBoxKurs.Name = "ComboBoxKurs"
        Me.ComboBoxKurs.Size = New System.Drawing.Size(55, 24)
        Me.ComboBoxKurs.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Location = New System.Drawing.Point(12, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Курс:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Location = New System.Drawing.Point(155, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 16)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Специальность:"
        '
        'ComboBoxTbl_spec
        '
        Me.ComboBoxTbl_spec.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxTbl_spec.BackColor = System.Drawing.Color.White
        Me.ComboBoxTbl_spec.DataSource = Me.TblspecBindingSource1
        Me.ComboBoxTbl_spec.DisplayMember = "nam_spec"
        Me.ComboBoxTbl_spec.ForeColor = System.Drawing.Color.Black
        Me.ComboBoxTbl_spec.FormattingEnabled = True
        Me.ComboBoxTbl_spec.Location = New System.Drawing.Point(264, 58)
        Me.ComboBoxTbl_spec.Name = "ComboBoxTbl_spec"
        Me.ComboBoxTbl_spec.Size = New System.Drawing.Size(350, 24)
        Me.ComboBoxTbl_spec.TabIndex = 12
        Me.ComboBoxTbl_spec.ValueMember = "id_spec"
        '
        'ButtonClearTbl_spec
        '
        Me.ButtonClearTbl_spec.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClearTbl_spec.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearTbl_spec.FlatAppearance.BorderSize = 0
        Me.ButtonClearTbl_spec.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearTbl_spec.Image = CType(resources.GetObject("ButtonClearTbl_spec.Image"), System.Drawing.Image)
        Me.ButtonClearTbl_spec.Location = New System.Drawing.Point(620, 56)
        Me.ButtonClearTbl_spec.Name = "ButtonClearTbl_spec"
        Me.ButtonClearTbl_spec.Size = New System.Drawing.Size(26, 26)
        Me.ButtonClearTbl_spec.TabIndex = 13
        Me.ButtonClearTbl_spec.UseVisualStyleBackColor = True
        '
        'ButtonClearKurs
        '
        Me.ButtonClearKurs.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearKurs.FlatAppearance.BorderSize = 0
        Me.ButtonClearKurs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearKurs.Image = CType(resources.GetObject("ButtonClearKurs.Image"), System.Drawing.Image)
        Me.ButtonClearKurs.Location = New System.Drawing.Point(120, 56)
        Me.ButtonClearKurs.Name = "ButtonClearKurs"
        Me.ButtonClearKurs.Size = New System.Drawing.Size(26, 26)
        Me.ButtonClearKurs.TabIndex = 14
        Me.ButtonClearKurs.UseVisualStyleBackColor = True
        '
        'TblspecBindingSource1
        '
        Me.TblspecBindingSource1.DataMember = "tbl_spec"
        Me.TblspecBindingSource1.DataSource = Me.Attestation_practiceDataSet
        '
        'frm_tbl_stud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(827, 416)
        Me.Controls.Add(Me.ButtonClearKurs)
        Me.Controls.Add(Me.ButtonClearTbl_spec)
        Me.Controls.Add(Me.ComboBoxTbl_spec)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBoxKurs)
        Me.Controls.Add(Me.Tbl_studDataGridView)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Tbl_studBindingNavigator)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(579, 176)
        Me.Name = "frm_tbl_stud"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Аттестация. Учебная практика: Таблица ""Студенты (курсанты)"""
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_studBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_studBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tbl_studBindingNavigator.ResumeLayout(False)
        Me.Tbl_studBindingNavigator.PerformLayout()
        CType(Me.Tbl_studDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblspecBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblspecBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Attestation_practiceDataSet As attestation_practice.attestation_practiceDataSet
    Friend WithEvents Tbl_studBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_studTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_studTableAdapter
    Friend WithEvents TableAdapterManager As attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Tbl_studBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents Tbl_studBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tbl_studDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents TblspecBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_specTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_specTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents ComboBoxKurs As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTbl_spec As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonClearTbl_spec As System.Windows.Forms.Button
    Friend WithEvents ButtonClearKurs As System.Windows.Forms.Button
    Friend WithEvents TblspecBindingSource1 As System.Windows.Forms.BindingSource
End Class
