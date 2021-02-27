<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tbl_journal_rating
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_tbl_journal_rating))
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Attestation_practiceDataSet = New attestation_practice.attestation_practiceDataSet()
        Me.Tbl_studBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_studTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_studTableAdapter()
        Me.TableAdapterManager = New attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager()
        Me.Tbl_journal_ratingTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_journal_ratingTableAdapter()
        Me.Tbl_journal_ratingBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.Tbl_journal_ratingBindingSource = New System.Windows.Forms.BindingSource(Me.components)
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
        Me.Tbl_journal_ratingDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TblspecBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.QrstudBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn2 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TbluchpractikaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn3 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TbluchpractikaBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn4 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TblvidrabotBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.QrotvlicoorgBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn5 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.QrruckovodpractikiBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn6 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.TblorgBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewCheckBoxColumn7 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qr_studTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.qr_studTableAdapter()
        Me.Tbl_specTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_specTableAdapter()
        Me.Tbl_uch_practikaTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_uch_practikaTableAdapter()
        Me.Tbl_vid_rabotTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_vid_rabotTableAdapter()
        Me.TblotvlicoorgBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_otv_lico_orgTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_otv_lico_orgTableAdapter()
        Me.Qr_otv_lico_orgTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.qr_otv_lico_orgTableAdapter()
        Me.Qr_ruckovod_practikiTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.qr_ruckovod_practikiTableAdapter()
        Me.Tbl_orgTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_orgTableAdapter()
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_studBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_journal_ratingBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tbl_journal_ratingBindingNavigator.SuspendLayout()
        CType(Me.Tbl_journal_ratingBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_journal_ratingDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblspecBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QrstudBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbluchpractikaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TbluchpractikaBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblvidrabotBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QrotvlicoorgBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QrruckovodpractikiBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblorgBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TblotvlicoorgBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(825, 490)
        Me.ShapeContainer1.TabIndex = 0
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RectangleShape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RectangleShape1.Location = New System.Drawing.Point(0, 25)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(825, 27)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Location = New System.Drawing.Point(3, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "История практикантов"
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
        Me.TableAdapterManager.tbl_journal_ratingTableAdapter = Me.Tbl_journal_ratingTableAdapter
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
        'Tbl_journal_ratingTableAdapter
        '
        Me.Tbl_journal_ratingTableAdapter.ClearBeforeFill = True
        '
        'Tbl_journal_ratingBindingNavigator
        '
        Me.Tbl_journal_ratingBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.Tbl_journal_ratingBindingNavigator.BindingSource = Me.Tbl_journal_ratingBindingSource
        Me.Tbl_journal_ratingBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.Tbl_journal_ratingBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.Tbl_journal_ratingBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.Tbl_studBindingNavigatorSaveItem})
        Me.Tbl_journal_ratingBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.Tbl_journal_ratingBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.Tbl_journal_ratingBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.Tbl_journal_ratingBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.Tbl_journal_ratingBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.Tbl_journal_ratingBindingNavigator.Name = "Tbl_journal_ratingBindingNavigator"
        Me.Tbl_journal_ratingBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.Tbl_journal_ratingBindingNavigator.Size = New System.Drawing.Size(825, 25)
        Me.Tbl_journal_ratingBindingNavigator.TabIndex = 2
        Me.Tbl_journal_ratingBindingNavigator.Text = "BindingNavigator1"
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
        'Tbl_journal_ratingBindingSource
        '
        Me.Tbl_journal_ratingBindingSource.DataMember = "tbl_journal_rating"
        Me.Tbl_journal_ratingBindingSource.DataSource = Me.Attestation_practiceDataSet
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
        'Tbl_journal_ratingDataGridView
        '
        Me.Tbl_journal_ratingDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tbl_journal_ratingDataGridView.AutoGenerateColumns = False
        Me.Tbl_journal_ratingDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Tbl_journal_ratingDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewCheckBoxColumn1, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewCheckBoxColumn2, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewCheckBoxColumn3, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewCheckBoxColumn4, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13, Me.DataGridViewCheckBoxColumn5, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewCheckBoxColumn6, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewCheckBoxColumn7, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22, Me.DataGridViewTextBoxColumn23})
        Me.Tbl_journal_ratingDataGridView.DataSource = Me.Tbl_journal_ratingBindingSource
        Me.Tbl_journal_ratingDataGridView.Location = New System.Drawing.Point(0, 53)
        Me.Tbl_journal_ratingDataGridView.Name = "Tbl_journal_ratingDataGridView"
        Me.Tbl_journal_ratingDataGridView.Size = New System.Drawing.Size(825, 437)
        Me.Tbl_journal_ratingDataGridView.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "id_journal_rating"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 45
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "id_spec_journal_rating"
        Me.DataGridViewTextBoxColumn2.DataSource = Me.TblspecBindingSource
        Me.DataGridViewTextBoxColumn2.DisplayMember = "nam_spec"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Специальность"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn2.ValueMember = "id_spec"
        Me.DataGridViewTextBoxColumn2.Width = 124
        '
        'TblspecBindingSource
        '
        Me.TblspecBindingSource.DataMember = "tbl_spec"
        Me.TblspecBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "spec_journal_rating"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Специальность (нет в БД)"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Width = 138
        '
        'DataGridViewCheckBoxColumn1
        '
        Me.DataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn1.DataPropertyName = "spec_v_journal_rating"
        Me.DataGridViewCheckBoxColumn1.HeaderText = "Специальность (в БД)"
        Me.DataGridViewCheckBoxColumn1.Name = "DataGridViewCheckBoxColumn1"
        Me.DataGridViewCheckBoxColumn1.Width = 112
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "kurs_journal_rating"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Курс"
        Me.DataGridViewTextBoxColumn4.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn4.Width = 62
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "id_stud_journal_rating"
        Me.DataGridViewTextBoxColumn5.DataSource = Me.QrstudBindingSource
        Me.DataGridViewTextBoxColumn5.DisplayMember = "fio_stud"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Студент (курсант)"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn5.ValueMember = "id_stud"
        Me.DataGridViewTextBoxColumn5.Width = 127
        '
        'QrstudBindingSource
        '
        Me.QrstudBindingSource.DataMember = "qr_stud"
        Me.QrstudBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "stud_journal_rating"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Студент (курсант) (нет в БД)"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Width = 165
        '
        'DataGridViewCheckBoxColumn2
        '
        Me.DataGridViewCheckBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn2.DataPropertyName = "stud_v_journal_rating"
        Me.DataGridViewCheckBoxColumn2.HeaderText = "Студент (курсант) (в БД)"
        Me.DataGridViewCheckBoxColumn2.Name = "DataGridViewCheckBoxColumn2"
        Me.DataGridViewCheckBoxColumn2.Width = 112
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "id_prof_modul_journal_rating"
        Me.DataGridViewTextBoxColumn7.DataSource = Me.TbluchpractikaBindingSource
        Me.DataGridViewTextBoxColumn7.DisplayMember = "nam_prof_modul_uch_practiki"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Проф. модуль"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn7.ValueMember = "id_uch_practiki"
        Me.DataGridViewTextBoxColumn7.Width = 108
        '
        'TbluchpractikaBindingSource
        '
        Me.TbluchpractikaBindingSource.DataMember = "tbl_uch_practika"
        Me.TbluchpractikaBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "prof_modul_journal_rating"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Проф. модуль (нет в БД)"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 132
        '
        'DataGridViewCheckBoxColumn3
        '
        Me.DataGridViewCheckBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn3.DataPropertyName = "prof_modul_v_journal_rating"
        Me.DataGridViewCheckBoxColumn3.HeaderText = "Проф. модуль (в БД)"
        Me.DataGridViewCheckBoxColumn3.Name = "DataGridViewCheckBoxColumn3"
        Me.DataGridViewCheckBoxColumn3.Width = 106
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "id_uch_practika_journal_rating"
        Me.DataGridViewTextBoxColumn9.DataSource = Me.TbluchpractikaBindingSource1
        Me.DataGridViewTextBoxColumn9.DisplayMember = "nam_uch_practiki"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Учебная практика"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn9.ValueMember = "id_uch_practiki"
        Me.DataGridViewTextBoxColumn9.Width = 127
        '
        'TbluchpractikaBindingSource1
        '
        Me.TbluchpractikaBindingSource1.DataMember = "tbl_uch_practika"
        Me.TbluchpractikaBindingSource1.DataSource = Me.Attestation_practiceDataSet
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "uch_practika_journal_rating"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Учебная практика (нет в БД)"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.Width = 165
        '
        'DataGridViewCheckBoxColumn4
        '
        Me.DataGridViewCheckBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn4.DataPropertyName = "uch_practika_v_journal_rating"
        Me.DataGridViewCheckBoxColumn4.HeaderText = "Учебная практика (в БД)"
        Me.DataGridViewCheckBoxColumn4.Name = "DataGridViewCheckBoxColumn4"
        Me.DataGridViewCheckBoxColumn4.Width = 112
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "id_vid_rabot_journal_rating"
        Me.DataGridViewTextBoxColumn11.DataSource = Me.TblvidrabotBindingSource
        Me.DataGridViewTextBoxColumn11.DisplayMember = "nam_vid_rabot"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Вид работы"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn11.ValueMember = "id_vid_rabot"
        Me.DataGridViewTextBoxColumn11.Width = 95
        '
        'TblvidrabotBindingSource
        '
        Me.TblvidrabotBindingSource.DataMember = "tbl_vid_rabot"
        Me.TblvidrabotBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "id_otv_lico_org_journal_rating"
        Me.DataGridViewTextBoxColumn12.DataSource = Me.QrotvlicoorgBindingSource
        Me.DataGridViewTextBoxColumn12.DisplayMember = "fio_otv_lico_org"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Отв. лицо"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn12.ValueMember = "id_otv_lica_org"
        Me.DataGridViewTextBoxColumn12.Width = 84
        '
        'QrotvlicoorgBindingSource
        '
        Me.QrotvlicoorgBindingSource.DataMember = "qr_otv_lico_org"
        Me.QrotvlicoorgBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "otv_lico_org_journal_rating"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Отв. лицо (нет в БД)"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Width = 112
        '
        'DataGridViewCheckBoxColumn5
        '
        Me.DataGridViewCheckBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn5.DataPropertyName = "otv_lico_org_v_journal_rating"
        Me.DataGridViewCheckBoxColumn5.HeaderText = "Отв. лицо (в БД)"
        Me.DataGridViewCheckBoxColumn5.Name = "DataGridViewCheckBoxColumn5"
        Me.DataGridViewCheckBoxColumn5.Width = 82
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "id_ruckovod_practiki_journal_rating"
        Me.DataGridViewTextBoxColumn14.DataSource = Me.QrruckovodpractikiBindingSource
        Me.DataGridViewTextBoxColumn14.DisplayMember = "fio_ruckovod_practiki"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Руковод. практики"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn14.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn14.ValueMember = "id_ruckovod_practiki"
        Me.DataGridViewTextBoxColumn14.Width = 132
        '
        'QrruckovodpractikiBindingSource
        '
        Me.QrruckovodpractikiBindingSource.DataMember = "qr_ruckovod_practiki"
        Me.QrruckovodpractikiBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "ruckovod_practiki_journal_rating"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Руковод. практики (нет в БД)"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Width = 169
        '
        'DataGridViewCheckBoxColumn6
        '
        Me.DataGridViewCheckBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn6.DataPropertyName = "ruckovod_practiki_v_journal_rating"
        Me.DataGridViewCheckBoxColumn6.HeaderText = "Руковод. практики (в БД)"
        Me.DataGridViewCheckBoxColumn6.Name = "DataGridViewCheckBoxColumn6"
        Me.DataGridViewCheckBoxColumn6.Width = 116
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "id_org_journal_rating"
        Me.DataGridViewTextBoxColumn16.DataSource = Me.TblorgBindingSource
        Me.DataGridViewTextBoxColumn16.DisplayMember = "nam_org"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Организация"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewTextBoxColumn16.ValueMember = "id_org"
        Me.DataGridViewTextBoxColumn16.Width = 110
        '
        'TblorgBindingSource
        '
        Me.TblorgBindingSource.DataMember = "tbl_org"
        Me.TblorgBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "org_journal_rating"
        Me.DataGridViewTextBoxColumn17.HeaderText = "Организация (нет БД)"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Width = 129
        '
        'DataGridViewCheckBoxColumn7
        '
        Me.DataGridViewCheckBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewCheckBoxColumn7.DataPropertyName = "org_v_journal_rating"
        Me.DataGridViewCheckBoxColumn7.HeaderText = "Организация (в БД)"
        Me.DataGridViewCheckBoxColumn7.Name = "DataGridViewCheckBoxColumn7"
        Me.DataGridViewCheckBoxColumn7.Width = 99
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "rating_journal_rating"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Оценка"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Width = 77
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "chas_journal_rating"
        Me.DataGridViewTextBoxColumn19.HeaderText = "Объём (часов)"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Width = 111
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "data_b_journal_rating"
        Me.DataGridViewTextBoxColumn20.HeaderText = "Дата начала"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Width = 98
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "data_e_journal_rating"
        Me.DataGridViewTextBoxColumn21.HeaderText = "Дата окончания"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.Width = 116
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "data_journal_rating"
        Me.DataGridViewTextBoxColumn22.HeaderText = "Дата оценивания"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.Width = 123
        '
        'DataGridViewTextBoxColumn23
        '
        Me.DataGridViewTextBoxColumn23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn23.DataPropertyName = "charac_journal_rating"
        Me.DataGridViewTextBoxColumn23.HeaderText = "Характеристика"
        Me.DataGridViewTextBoxColumn23.Name = "DataGridViewTextBoxColumn23"
        Me.DataGridViewTextBoxColumn23.Width = 125
        '
        'Qr_studTableAdapter
        '
        Me.Qr_studTableAdapter.ClearBeforeFill = True
        '
        'Tbl_specTableAdapter
        '
        Me.Tbl_specTableAdapter.ClearBeforeFill = True
        '
        'Tbl_uch_practikaTableAdapter
        '
        Me.Tbl_uch_practikaTableAdapter.ClearBeforeFill = True
        '
        'Tbl_vid_rabotTableAdapter
        '
        Me.Tbl_vid_rabotTableAdapter.ClearBeforeFill = True
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
        'Qr_ruckovod_practikiTableAdapter
        '
        Me.Qr_ruckovod_practikiTableAdapter.ClearBeforeFill = True
        '
        'Tbl_orgTableAdapter
        '
        Me.Tbl_orgTableAdapter.ClearBeforeFill = True
        '
        'frm_tbl_journal_rating
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(825, 490)
        Me.Controls.Add(Me.Tbl_journal_ratingDataGridView)
        Me.Controls.Add(Me.Tbl_journal_ratingBindingNavigator)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(579, 176)
        Me.Name = "frm_tbl_journal_rating"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Аттестация. Учебная практика: История практикантов"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_studBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_journal_ratingBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tbl_journal_ratingBindingNavigator.ResumeLayout(False)
        Me.Tbl_journal_ratingBindingNavigator.PerformLayout()
        CType(Me.Tbl_journal_ratingBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_journal_ratingDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblspecBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QrstudBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbluchpractikaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TbluchpractikaBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblvidrabotBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QrotvlicoorgBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QrruckovodpractikiBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblorgBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TblotvlicoorgBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Attestation_practiceDataSet As attestation_practice.attestation_practiceDataSet
    Friend WithEvents Tbl_studBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_studTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_studTableAdapter
    Friend WithEvents TableAdapterManager As attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Tbl_journal_ratingBindingNavigator As System.Windows.Forms.BindingNavigator
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
    Friend WithEvents Tbl_journal_ratingTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_journal_ratingTableAdapter
    Friend WithEvents Tbl_journal_ratingBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_journal_ratingDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents QrstudBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Qr_studTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.qr_studTableAdapter
    Friend WithEvents TblspecBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_specTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_specTableAdapter
    Friend WithEvents TbluchpractikaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_uch_practikaTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_uch_practikaTableAdapter
    Friend WithEvents TbluchpractikaBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents TblvidrabotBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_vid_rabotTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_vid_rabotTableAdapter
    Friend WithEvents TblotvlicoorgBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_otv_lico_orgTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_otv_lico_orgTableAdapter
    Friend WithEvents QrotvlicoorgBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Qr_otv_lico_orgTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.qr_otv_lico_orgTableAdapter
    Friend WithEvents QrruckovodpractikiBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Qr_ruckovod_practikiTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.qr_ruckovod_practikiTableAdapter
    Friend WithEvents TblorgBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_orgTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_orgTableAdapter
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn1 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn3 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn4 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn5 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn6 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewCheckBoxColumn7 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn23 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
