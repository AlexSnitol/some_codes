<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_charact_generator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_charact_generator))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape4 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape3 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.RectangleShape2 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Attestation_practiceDataSet = New attestation_practice.attestation_practiceDataSet()
        Me.Tbl_var_beginBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_var_beginTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_var_beginTableAdapter()
        Me.TableAdapterManager = New attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager()
        Me.Tbl_var_narekanTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_var_narekanTableAdapter()
        Me.Tbl_var_osnovTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_var_osnovTableAdapter()
        Me.Tbl_var_rabotTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_var_rabotTableAdapter()
        Me.Tbl_var_svodTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_var_svodTableAdapter()
        Me.Tbl_var_narekanBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_var_osnovBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_var_rabotBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_var_svodBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_uch_practikaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_uch_practikaTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_uch_practikaTableAdapter()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_var_beginBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_var_narekanBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_var_osnovBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_var_rabotBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_var_svodBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_uch_practikaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(26, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Основа"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(26, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Начало"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(26, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Нарекания"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(27, 272)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Сводка"
        '
        'RectangleShape1
        '
        Me.RectangleShape1.AccessibleRole = System.Windows.Forms.AccessibleRole.[Default]
        Me.RectangleShape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.Color.Transparent
        Me.RectangleShape1.FillColor = System.Drawing.Color.Transparent
        Me.RectangleShape1.FillGradientColor = System.Drawing.Color.Transparent
        Me.RectangleShape1.Location = New System.Drawing.Point(10, 10)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape1.Size = New System.Drawing.Size(5, 82)
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape4, Me.RectangleShape3, Me.RectangleShape2, Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(659, 408)
        Me.ShapeContainer1.TabIndex = 13
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape4
        '
        Me.RectangleShape4.AccessibleRole = System.Windows.Forms.AccessibleRole.[Default]
        Me.RectangleShape4.BackColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.RectangleShape4.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape4.BorderColor = System.Drawing.Color.Transparent
        Me.RectangleShape4.FillColor = System.Drawing.Color.Transparent
        Me.RectangleShape4.FillGradientColor = System.Drawing.Color.Transparent
        Me.RectangleShape4.Location = New System.Drawing.Point(10, 269)
        Me.RectangleShape4.Name = "RectangleShape4"
        Me.RectangleShape4.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape4.Size = New System.Drawing.Size(5, 82)
        '
        'RectangleShape3
        '
        Me.RectangleShape3.AccessibleRole = System.Windows.Forms.AccessibleRole.[Default]
        Me.RectangleShape3.BackColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.RectangleShape3.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape3.BorderColor = System.Drawing.Color.Transparent
        Me.RectangleShape3.FillColor = System.Drawing.Color.Transparent
        Me.RectangleShape3.FillGradientColor = System.Drawing.Color.Transparent
        Me.RectangleShape3.Location = New System.Drawing.Point(10, 183)
        Me.RectangleShape3.Name = "RectangleShape3"
        Me.RectangleShape3.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape3.Size = New System.Drawing.Size(5, 82)
        '
        'RectangleShape2
        '
        Me.RectangleShape2.AccessibleRole = System.Windows.Forms.AccessibleRole.[Default]
        Me.RectangleShape2.BackColor = System.Drawing.Color.FromArgb(CType(CType(87, Byte), Integer), CType(CType(74, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.RectangleShape2.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape2.BorderColor = System.Drawing.Color.Transparent
        Me.RectangleShape2.FillColor = System.Drawing.Color.Transparent
        Me.RectangleShape2.FillGradientColor = System.Drawing.Color.Transparent
        Me.RectangleShape2.Location = New System.Drawing.Point(10, 97)
        Me.RectangleShape2.Name = "RectangleShape2"
        Me.RectangleShape2.SelectionColor = System.Drawing.Color.Transparent
        Me.RectangleShape2.Size = New System.Drawing.Size(5, 82)
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(29, 35)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(586, 55)
        Me.TextBox1.TabIndex = 0
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox2.ForeColor = System.Drawing.Color.Black
        Me.TextBox2.Location = New System.Drawing.Point(29, 118)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(586, 55)
        Me.TextBox2.TabIndex = 2
        '
        'TextBox3
        '
        Me.TextBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox3.ForeColor = System.Drawing.Color.Black
        Me.TextBox3.Location = New System.Drawing.Point(29, 204)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(586, 55)
        Me.TextBox3.TabIndex = 4
        '
        'TextBox4
        '
        Me.TextBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox4.ForeColor = System.Drawing.Color.Black
        Me.TextBox4.Location = New System.Drawing.Point(29, 291)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(586, 55)
        Me.TextBox4.TabIndex = 6
        '
        'Attestation_practiceDataSet
        '
        Me.Attestation_practiceDataSet.DataSetName = "attestation_practiceDataSet"
        Me.Attestation_practiceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Tbl_var_beginBindingSource1
        '
        Me.Tbl_var_beginBindingSource1.DataMember = "tbl_var_begin"
        Me.Tbl_var_beginBindingSource1.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_var_beginTableAdapter
        '
        Me.Tbl_var_beginTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.tbl_var_beginTableAdapter = Me.Tbl_var_beginTableAdapter
        Me.TableAdapterManager.tbl_var_narekanTableAdapter = Me.Tbl_var_narekanTableAdapter
        Me.TableAdapterManager.tbl_var_osnovTableAdapter = Me.Tbl_var_osnovTableAdapter
        Me.TableAdapterManager.tbl_var_rabotTableAdapter = Me.Tbl_var_rabotTableAdapter
        Me.TableAdapterManager.tbl_var_svodTableAdapter = Me.Tbl_var_svodTableAdapter
        Me.TableAdapterManager.tbl_vid_rabotTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Tbl_var_narekanTableAdapter
        '
        Me.Tbl_var_narekanTableAdapter.ClearBeforeFill = True
        '
        'Tbl_var_osnovTableAdapter
        '
        Me.Tbl_var_osnovTableAdapter.ClearBeforeFill = True
        '
        'Tbl_var_rabotTableAdapter
        '
        Me.Tbl_var_rabotTableAdapter.ClearBeforeFill = True
        '
        'Tbl_var_svodTableAdapter
        '
        Me.Tbl_var_svodTableAdapter.ClearBeforeFill = True
        '
        'Tbl_var_narekanBindingSource1
        '
        Me.Tbl_var_narekanBindingSource1.DataMember = "tbl_var_narekan"
        Me.Tbl_var_narekanBindingSource1.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_var_osnovBindingSource1
        '
        Me.Tbl_var_osnovBindingSource1.DataMember = "tbl_var_osnov"
        Me.Tbl_var_osnovBindingSource1.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_var_rabotBindingSource1
        '
        Me.Tbl_var_rabotBindingSource1.DataMember = "tbl_var_rabot"
        Me.Tbl_var_rabotBindingSource1.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_var_svodBindingSource1
        '
        Me.Tbl_var_svodBindingSource1.DataMember = "tbl_var_svod"
        Me.Tbl_var_svodBindingSource1.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_uch_practikaBindingSource
        '
        Me.Tbl_uch_practikaBindingSource.DataMember = "tbl_uch_practika"
        Me.Tbl_uch_practikaBindingSource.DataSource = Me.Attestation_practiceDataSet
        '
        'Tbl_uch_practikaTableAdapter
        '
        Me.Tbl_uch_practikaTableAdapter.ClearBeforeFill = True
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Image = Global.attestation_practice.My.Resources.Resources.frm_button_reload
        Me.Button7.Location = New System.Drawing.Point(617, 44)
        Me.Button7.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(38, 38)
        Me.Button7.TabIndex = 1
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Image = Global.attestation_practice.My.Resources.Resources.frm_button_reload
        Me.Button6.Location = New System.Drawing.Point(617, 127)
        Me.Button6.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(38, 38)
        Me.Button6.TabIndex = 3
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Image = Global.attestation_practice.My.Resources.Resources.frm_button_reload
        Me.Button5.Location = New System.Drawing.Point(617, 300)
        Me.Button5.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(38, 38)
        Me.Button5.TabIndex = 7
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Image = Global.attestation_practice.My.Resources.Resources.frm_button_reload
        Me.Button4.Location = New System.Drawing.Point(617, 213)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(38, 38)
        Me.Button4.TabIndex = 5
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Image = Global.attestation_practice.My.Resources.Resources.frm_button_generate
        Me.Button3.Location = New System.Drawing.Point(10, 362)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(155, 33)
        Me.Button3.TabIndex = 8
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Image = Global.attestation_practice.My.Resources.Resources.frm_button_Cancel
        Me.Button2.Location = New System.Drawing.Point(560, 362)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 33)
        Me.Button2.TabIndex = 10
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
        Me.Button1.Location = New System.Drawing.Point(443, 362)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 33)
        Me.Button1.TabIndex = 9
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frm_charact_generator
        '
        Me.AcceptButton = Me.Button1
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.Button2
        Me.ClientSize = New System.Drawing.Size(659, 408)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frm_charact_generator"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Аттестация. Учебная практика: Генератор характеристики"
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_var_beginBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_var_narekanBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_var_osnovBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_var_rabotBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_var_svodBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_uch_practikaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape4 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape3 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents RectangleShape2 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Tbl_var_beginBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_var_narekanBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_var_osnovBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_var_rabotBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_var_svodBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Attestation_practiceDataSet As attestation_practice.attestation_practiceDataSet
    Friend WithEvents Tbl_var_beginBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_var_beginTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_var_beginTableAdapter
    Friend WithEvents TableAdapterManager As attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager
    Friend WithEvents Tbl_var_narekanTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_var_narekanTableAdapter
    Friend WithEvents Tbl_var_narekanBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_var_osnovTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_var_osnovTableAdapter
    Friend WithEvents Tbl_var_osnovBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_var_rabotTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_var_rabotTableAdapter
    Friend WithEvents Tbl_var_rabotBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_var_svodTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_var_svodTableAdapter
    Friend WithEvents Tbl_var_svodBindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_uch_practikaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_uch_practikaTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_uch_practikaTableAdapter
End Class
