﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_tbl_stat_sved
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_tbl_stat_sved))
        Me.Attestation_practiceDataSet = New attestation_practice.attestation_practiceDataSet()
        Me.Tbl_stat_svedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_stat_svedTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_stat_svedTableAdapter()
        Me.TableAdapterManager = New attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager()
        Me.Tbl_stat_svedBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Tbl_stat_svedBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.Tbl_stat_svedDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_stat_svedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_stat_svedBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Tbl_stat_svedBindingNavigator.SuspendLayout()
        CType(Me.Tbl_stat_svedDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Attestation_practiceDataSet
        '
        Me.Attestation_practiceDataSet.DataSetName = "attestation_practiceDataSet"
        Me.Attestation_practiceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.TableAdapterManager.tbl_orgTableAdapter = Nothing
        Me.TableAdapterManager.tbl_otv_lico_orgTableAdapter = Nothing
        Me.TableAdapterManager.tbl_ruckovod_practikiTableAdapter = Nothing
        Me.TableAdapterManager.tbl_specTableAdapter = Nothing
        Me.TableAdapterManager.tbl_stat_svedTableAdapter = Me.Tbl_stat_svedTableAdapter
        Me.TableAdapterManager.tbl_studTableAdapter = Nothing
        Me.TableAdapterManager.tbl_uch_practikaTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_beginTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_narekanTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_osnovTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_rabotTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_svodTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vid_rabotTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Tbl_stat_svedBindingNavigator
        '
        Me.Tbl_stat_svedBindingNavigator.AddNewItem = Nothing
        Me.Tbl_stat_svedBindingNavigator.BindingSource = Me.Tbl_stat_svedBindingSource
        Me.Tbl_stat_svedBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.Tbl_stat_svedBindingNavigator.DeleteItem = Nothing
        Me.Tbl_stat_svedBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.Tbl_stat_svedBindingNavigatorSaveItem})
        Me.Tbl_stat_svedBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.Tbl_stat_svedBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.Tbl_stat_svedBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.Tbl_stat_svedBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.Tbl_stat_svedBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.Tbl_stat_svedBindingNavigator.Name = "Tbl_stat_svedBindingNavigator"
        Me.Tbl_stat_svedBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.Tbl_stat_svedBindingNavigator.Size = New System.Drawing.Size(827, 25)
        Me.Tbl_stat_svedBindingNavigator.TabIndex = 0
        Me.Tbl_stat_svedBindingNavigator.Text = "BindingNavigator1"
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
        'Tbl_stat_svedBindingNavigatorSaveItem
        '
        Me.Tbl_stat_svedBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Tbl_stat_svedBindingNavigatorSaveItem.Image = CType(resources.GetObject("Tbl_stat_svedBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.Tbl_stat_svedBindingNavigatorSaveItem.Name = "Tbl_stat_svedBindingNavigatorSaveItem"
        Me.Tbl_stat_svedBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.Tbl_stat_svedBindingNavigatorSaveItem.Text = "Сохранить данные"
        '
        'Tbl_stat_svedDataGridView
        '
        Me.Tbl_stat_svedDataGridView.AllowUserToAddRows = False
        Me.Tbl_stat_svedDataGridView.AllowUserToDeleteRows = False
        Me.Tbl_stat_svedDataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Tbl_stat_svedDataGridView.AutoGenerateColumns = False
        Me.Tbl_stat_svedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Tbl_stat_svedDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2})
        Me.Tbl_stat_svedDataGridView.DataSource = Me.Tbl_stat_svedBindingSource
        Me.Tbl_stat_svedDataGridView.Location = New System.Drawing.Point(0, 53)
        Me.Tbl_stat_svedDataGridView.Name = "Tbl_stat_svedDataGridView"
        Me.Tbl_stat_svedDataGridView.Size = New System.Drawing.Size(827, 363)
        Me.Tbl_stat_svedDataGridView.TabIndex = 1
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "id_stat_sved"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Width = 45
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "stat_sved"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Статические сведения"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
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
        Me.RectangleShape1.Size = New System.Drawing.Size(825, 27)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(827, 416)
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
        Me.Label1.Size = New System.Drawing.Size(204, 16)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Таблица ""Статические сведения"""
        '
        'frm_tbl_stat_sved
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(827, 416)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Tbl_stat_svedDataGridView)
        Me.Controls.Add(Me.Tbl_stat_svedBindingNavigator)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MinimumSize = New System.Drawing.Size(579, 176)
        Me.Name = "frm_tbl_stat_sved"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Аттестация. Учебная практика: Таблица ""Статические сведения"""
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_stat_svedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_stat_svedBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Tbl_stat_svedBindingNavigator.ResumeLayout(False)
        Me.Tbl_stat_svedBindingNavigator.PerformLayout()
        CType(Me.Tbl_stat_svedDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Attestation_practiceDataSet As attestation_practice.attestation_practiceDataSet
    Friend WithEvents Tbl_stat_svedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_stat_svedTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_stat_svedTableAdapter
    Friend WithEvents TableAdapterManager As attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Tbl_stat_svedBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Tbl_stat_svedBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents Tbl_stat_svedDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
