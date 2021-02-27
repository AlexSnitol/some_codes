<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_select_rating
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_select_rating))
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Tbl_vid_rabotTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_vid_rabotTableAdapter()
        Me.TblvidrabotBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Attestation_practiceDataSet = New attestation_practice.attestation_practiceDataSet()
        Me.TableAdapterManager = New attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager()
        Me.Tbl_vid_rabotDataGridView = New System.Windows.Forms.DataGridView()
        Me.IdvidrabotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IduchpractikavidrabotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CheckvidrabotDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.NamvidrabotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RatingvidrabotDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        CType(Me.TblvidrabotBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_vid_rabotDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.attestation_practice.My.Resources.Resources.frm_button_Cancel
        Me.Button2.Location = New System.Drawing.Point(526, 461)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 33)
        Me.Button2.TabIndex = 2
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Image = Global.attestation_practice.My.Resources.Resources.frm_button_Accept
        Me.Button1.Location = New System.Drawing.Point(409, 461)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 33)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(24, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(432, 55)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Вы указали не все оценки или совсем их не указали за выполненные работы студентом" & _
            " (курсантом)." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Пожалуйста выберите, как вы оцениваете практиканта?"
        '
        'ComboBox1
        '
        Me.ComboBox1.ForeColor = System.Drawing.Color.Black
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"Отлично (5)", "Хорошо (4)", "Удовлетворительно (3)", "Неудовлетворительно (2)"})
        Me.ComboBox1.Location = New System.Drawing.Point(148, 83)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(209, 24)
        Me.ComboBox1.TabIndex = 0
        Me.ComboBox1.Text = "Отлично (5)"
        '
        'RectangleShape1
        '
        Me.RectangleShape1.AccessibleRole = System.Windows.Forms.AccessibleRole.[Default]
        Me.RectangleShape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.Color.Transparent
        Me.RectangleShape1.FillColor = System.Drawing.Color.Transparent
        Me.RectangleShape1.FillGradientColor = System.Drawing.Color.Transparent
        Me.RectangleShape1.Location = New System.Drawing.Point(11, 11)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape1.Size = New System.Drawing.Size(5, 60)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(625, 507)
        Me.ShapeContainer1.TabIndex = 17
        Me.ShapeContainer1.TabStop = False
        '
        'Tbl_vid_rabotTableAdapter
        '
        Me.Tbl_vid_rabotTableAdapter.ClearBeforeFill = True
        '
        'TblvidrabotBindingSource
        '
        Me.TblvidrabotBindingSource.DataMember = "tbl_vid_rabot"
        Me.TblvidrabotBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'Attestation_practiceDataSet
        '
        Me.Attestation_practiceDataSet.DataSetName = "attestation_practiceDataSet"
        Me.Attestation_practiceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
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
        Me.TableAdapterManager.tbl_uch_practikaTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_beginTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_narekanTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_osnovTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_rabotTableAdapter = Nothing
        Me.TableAdapterManager.tbl_var_svodTableAdapter = Nothing
        Me.TableAdapterManager.tbl_vid_rabotTableAdapter = Me.Tbl_vid_rabotTableAdapter
        Me.TableAdapterManager.UpdateOrder = attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
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
        Me.Tbl_vid_rabotDataGridView.Location = New System.Drawing.Point(27, 151)
        Me.Tbl_vid_rabotDataGridView.MultiSelect = False
        Me.Tbl_vid_rabotDataGridView.Name = "Tbl_vid_rabotDataGridView"
        Me.Tbl_vid_rabotDataGridView.Size = New System.Drawing.Size(568, 296)
        Me.Tbl_vid_rabotDataGridView.TabIndex = 18
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.NamvidrabotDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle1
        Me.NamvidrabotDataGridViewTextBoxColumn.HeaderText = "Вид работы"
        Me.NamvidrabotDataGridViewTextBoxColumn.Name = "NamvidrabotDataGridViewTextBoxColumn"
        '
        'RatingvidrabotDataGridViewTextBoxColumn
        '
        Me.RatingvidrabotDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.RatingvidrabotDataGridViewTextBoxColumn.DataPropertyName = "rating_vid_rabot"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.RatingvidrabotDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.RatingvidrabotDataGridViewTextBoxColumn.HeaderText = "Оценка"
        Me.RatingvidrabotDataGridViewTextBoxColumn.Name = "RatingvidrabotDataGridViewTextBoxColumn"
        Me.RatingvidrabotDataGridViewTextBoxColumn.Width = 77
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RadioButton1.ForeColor = System.Drawing.Color.Black
        Me.RadioButton1.Location = New System.Drawing.Point(24, 84)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(118, 20)
        Me.RadioButton1.TabIndex = 20
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Общая оценка:"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RadioButton2.ForeColor = System.Drawing.Color.Black
        Me.RadioButton2.Location = New System.Drawing.Point(24, 125)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(163, 20)
        Me.RadioButton2.TabIndex = 21
        Me.RadioButton2.Text = "Оценки за виды работ:"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'frm_select_rating
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(625, 507)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.Tbl_vid_rabotDataGridView)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.Name = "frm_select_rating"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Аттестация. Учебная практика: Укажите общую успеваемость практиканта"
        CType(Me.TblvidrabotBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_vid_rabotDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents Tbl_vid_rabotTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_vid_rabotTableAdapter
    Friend WithEvents TblvidrabotBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Attestation_practiceDataSet As attestation_practice.attestation_practiceDataSet
    Friend WithEvents TableAdapterManager As attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Tbl_vid_rabotDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents IdvidrabotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IduchpractikavidrabotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CheckvidrabotDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents NamvidrabotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RatingvidrabotDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
End Class
