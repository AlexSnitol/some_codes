<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_login
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_login))
        Me.TextBoxLogin = New System.Windows.Forms.TextBox()
        Me.TextBoxPassword = New System.Windows.Forms.TextBox()
        Me.ButtonLogIn = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BindingSourceAccount = New System.Windows.Forms.BindingSource(Me.components)
        Me.Attestation_practiceDataSet = New attestation_practice.attestation_practiceDataSet()
        Me.Tbl_accountTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_accountTableAdapter()
        Me.Tbl_stat_svedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Tbl_stat_svedTableAdapter = New attestation_practice.attestation_practiceDataSetTableAdapters.tbl_stat_svedTableAdapter()
        Me.TableAdapterManager = New attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager()
        CType(Me.ButtonLogIn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSourceAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tbl_stat_svedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBoxLogin
        '
        Me.TextBoxLogin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.TextBoxLogin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxLogin.Font = New System.Drawing.Font("Comfortaa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBoxLogin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(86, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.TextBoxLogin.Location = New System.Drawing.Point(46, 304)
        Me.TextBoxLogin.Name = "TextBoxLogin"
        Me.TextBoxLogin.Size = New System.Drawing.Size(210, 26)
        Me.TextBoxLogin.TabIndex = 1
        Me.TextBoxLogin.Text = "Имя пользователя"
        Me.TextBoxLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxLogin.WordWrap = False
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.TextBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxPassword.Font = New System.Drawing.Font("Comfortaa", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TextBoxPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(86, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.TextBoxPassword.Location = New System.Drawing.Point(46, 373)
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.Size = New System.Drawing.Size(210, 26)
        Me.TextBoxPassword.TabIndex = 2
        Me.TextBoxPassword.Text = "Пароль"
        Me.TextBoxPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxPassword.UseSystemPasswordChar = True
        '
        'ButtonLogIn
        '
        Me.ButtonLogIn.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonLogIn.Image = Global.attestation_practice.My.Resources.Resources.frm_login_3_button
        Me.ButtonLogIn.Location = New System.Drawing.Point(86, 431)
        Me.ButtonLogIn.Name = "ButtonLogIn"
        Me.ButtonLogIn.Size = New System.Drawing.Size(132, 57)
        Me.ButtonLogIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ButtonLogIn.TabIndex = 6
        Me.ButtonLogIn.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PictureBox1.Image = Global.attestation_practice.My.Resources.Resources.frm_login_pass_show
        Me.PictureBox1.Location = New System.Drawing.Point(209, 364)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(59, 46)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'BindingSourceAccount
        '
        Me.BindingSourceAccount.DataMember = "tbl_account"
        Me.BindingSourceAccount.DataSource = Me.Attestation_practiceDataSet
        '
        'Attestation_practiceDataSet
        '
        Me.Attestation_practiceDataSet.DataSetName = "attestation_practiceDataSet"
        Me.Attestation_practiceDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Tbl_accountTableAdapter
        '
        Me.Tbl_accountTableAdapter.ClearBeforeFill = True
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
        Me.TableAdapterManager.tbl_accountTableAdapter = Me.Tbl_accountTableAdapter
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
        'frm_login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(9, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BackgroundImage = Global.attestation_practice.My.Resources.Resources.frm_login_3
        Me.ClientSize = New System.Drawing.Size(302, 538)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonLogIn)
        Me.Controls.Add(Me.TextBoxPassword)
        Me.Controls.Add(Me.TextBoxLogin)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frm_login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Аттестация. Учебная практика: Авторизация"
        CType(Me.ButtonLogIn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSourceAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Attestation_practiceDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tbl_stat_svedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxLogin As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents BindingSourceAccount As System.Windows.Forms.BindingSource
    Friend WithEvents Attestation_practiceDataSet As attestation_practice.attestation_practiceDataSet
    Friend WithEvents Tbl_accountTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_accountTableAdapter
    Friend WithEvents Tbl_stat_svedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Tbl_stat_svedTableAdapter As attestation_practice.attestation_practiceDataSetTableAdapters.tbl_stat_svedTableAdapter
    Friend WithEvents TableAdapterManager As attestation_practice.attestation_practiceDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ButtonLogIn As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox

End Class
