#define _CRT_SECURE_NO_WARNINGS

#include <fstream>
#include <iostream>
#include <windows.h>
#include <string>
#include <tchar.h>
#include <msclr/marshal_cppstd.h>
#include <cstring>
#include <iomanip>
#include <stdio.h>
#include <stdlib.h>
#include <malloc.h>
#include <time.h>


#pragma once

namespace AdditionalUtilitiesFrontol5 {

	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;

	/// <summary>
	/// Сводка для Index
	/// </summary>
	public ref class Index : public System::Windows::Forms::Form
	{
	public:
		Index(void)
		{
			InitializeComponent();
			//
			//TODO: добавьте код конструктора
			//
		}

	protected:
		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		~Index()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::Label^  label_program_name;
	protected:

	private: System::Windows::Forms::Panel^  panel1;
	private: System::Windows::Forms::Panel^  panel2;
	private: System::Windows::Forms::Label^  label_version;

	private: System::Windows::Forms::Label^  label_creater;
	private: System::Windows::Forms::TabControl^  index_tabControl;


	private: System::Windows::Forms::TabPage^  tabPage1;
	private: System::Windows::Forms::ProgressBar^  progressBar1;
	private: System::Windows::Forms::Label^  fix_errors_label_files;


	private: System::Windows::Forms::Button^  fix_errors_delete;


	private: System::Windows::Forms::Button^  fix_errors_add;

	private: System::Windows::Forms::TextBox^  fix_errors_filename;
	private: System::Windows::Forms::Label^  fix_errors_label_filename;




	private: System::Windows::Forms::Button^  fix_errors_run;
	private: System::Windows::Forms::Button^  fix_errors_appy;
	private: System::Windows::Forms::CheckBox^  fix_errors_copy;
	private: System::Windows::Forms::FolderBrowserDialog^ folderBrowserDialog1;
	private: System::Windows::Forms::SplitContainer^ splitContainer1;


	private: System::Windows::Forms::TextBox^ Consol;
	private: System::Windows::Forms::CheckedListBox^ fix_errors_files;
	private: System::Windows::Forms::Button^ fix_errors_uncheck_all;
	private: System::Windows::Forms::Button^ fix_errors_check_all;
	private: System::Windows::Forms::Button^ show_hide_journal;
	private: System::Windows::Forms::Button^ journal_clear;
	private: System::Windows::Forms::TabPage^ tabPage2;
	private: System::Windows::Forms::Panel^ panel3;
	private: System::Windows::Forms::DataGridView^ db_dataGridView_card;


	private: System::Windows::Forms::Label^ label1;
	private: System::Windows::Forms::DataGridView^ db_dataGridView_client;


	private: System::Windows::Forms::Label^ label2;
	private: System::Windows::Forms::Button^ db_card_add;
	private: System::Windows::Forms::Button^ db_client_add;
	private: System::Windows::Forms::Button^ db_client_remove;




	private: System::Windows::Forms::Button^ db_card_delete;
	private: System::Windows::Forms::Button^ db_client_send_request;
	private: System::Windows::Forms::Button^ db_card_send_request;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ card_old;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ card_new;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ client_old;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ client_new;
	private: System::Windows::Forms::Button^ db_uncheck_all;
	private: System::Windows::Forms::Button^ db_check_all;



	private: System::Windows::Forms::Label^ label3;
	private: System::Windows::Forms::TextBox^ db_text_path;

	private: System::Windows::Forms::Label^ label4;
	private: System::Windows::Forms::Button^ db_delete;

	private: System::Windows::Forms::Button^ db_add;
	private: System::Windows::Forms::Button^ db_appy;
	private: System::Windows::Forms::DataGridView^ db_dataGridView_paths;
	private: System::Windows::Forms::DataGridViewCheckBoxColumn^ checkbox;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ description;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ path;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ username;
	private: System::Windows::Forms::DataGridViewTextBoxColumn^ password;
private: System::Windows::Forms::GroupBox^ groupBox2;
private: System::Windows::Forms::Button^ button12;
private: System::Windows::Forms::Button^ button14;
private: System::Windows::Forms::Button^ button15;
private: System::Windows::Forms::Button^ button16;
private: System::Windows::Forms::Button^ button17;
private: System::Windows::Forms::Button^ button18;
private: System::Windows::Forms::Button^ button19;
private: System::Windows::Forms::Button^ button20;
private: System::Windows::Forms::Button^ button21;
private: System::Windows::Forms::Button^ button22;
private: System::Windows::Forms::Button^ button23;
private: System::Windows::Forms::Button^ button24;
private: System::Windows::Forms::GroupBox^ groupBox1;
private: System::Windows::Forms::Button^ button13;
private: System::Windows::Forms::Button^ button11;
private: System::Windows::Forms::Button^ button10;
private: System::Windows::Forms::Button^ button9;
private: System::Windows::Forms::Button^ button8;
private: System::Windows::Forms::Button^ button7;
private: System::Windows::Forms::Button^ button6;
private: System::Windows::Forms::Button^ button5;
private: System::Windows::Forms::Button^ button4;
private: System::Windows::Forms::Button^ button3;
private: System::Windows::Forms::Button^ button2;
private: System::Windows::Forms::Button^ button1;
private: System::Windows::Forms::Button^ button25;
private: System::Windows::Forms::OpenFileDialog^ openFileDialogGDB;






























	protected:

	private:
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		void InitializeComponent(void)
		{
			this->label_program_name = (gcnew System::Windows::Forms::Label());
			this->panel1 = (gcnew System::Windows::Forms::Panel());
			this->journal_clear = (gcnew System::Windows::Forms::Button());
			this->show_hide_journal = (gcnew System::Windows::Forms::Button());
			this->panel2 = (gcnew System::Windows::Forms::Panel());
			this->progressBar1 = (gcnew System::Windows::Forms::ProgressBar());
			this->label_version = (gcnew System::Windows::Forms::Label());
			this->label_creater = (gcnew System::Windows::Forms::Label());
			this->index_tabControl = (gcnew System::Windows::Forms::TabControl());
			this->tabPage1 = (gcnew System::Windows::Forms::TabPage());
			this->fix_errors_uncheck_all = (gcnew System::Windows::Forms::Button());
			this->fix_errors_check_all = (gcnew System::Windows::Forms::Button());
			this->fix_errors_files = (gcnew System::Windows::Forms::CheckedListBox());
			this->fix_errors_copy = (gcnew System::Windows::Forms::CheckBox());
			this->fix_errors_run = (gcnew System::Windows::Forms::Button());
			this->fix_errors_appy = (gcnew System::Windows::Forms::Button());
			this->fix_errors_filename = (gcnew System::Windows::Forms::TextBox());
			this->fix_errors_label_filename = (gcnew System::Windows::Forms::Label());
			this->fix_errors_delete = (gcnew System::Windows::Forms::Button());
			this->fix_errors_add = (gcnew System::Windows::Forms::Button());
			this->fix_errors_label_files = (gcnew System::Windows::Forms::Label());
			this->tabPage2 = (gcnew System::Windows::Forms::TabPage());
			this->panel3 = (gcnew System::Windows::Forms::Panel());
			this->groupBox2 = (gcnew System::Windows::Forms::GroupBox());
			this->button25 = (gcnew System::Windows::Forms::Button());
			this->button12 = (gcnew System::Windows::Forms::Button());
			this->button14 = (gcnew System::Windows::Forms::Button());
			this->button15 = (gcnew System::Windows::Forms::Button());
			this->button16 = (gcnew System::Windows::Forms::Button());
			this->button17 = (gcnew System::Windows::Forms::Button());
			this->button18 = (gcnew System::Windows::Forms::Button());
			this->button19 = (gcnew System::Windows::Forms::Button());
			this->button20 = (gcnew System::Windows::Forms::Button());
			this->button21 = (gcnew System::Windows::Forms::Button());
			this->button22 = (gcnew System::Windows::Forms::Button());
			this->button23 = (gcnew System::Windows::Forms::Button());
			this->button24 = (gcnew System::Windows::Forms::Button());
			this->groupBox1 = (gcnew System::Windows::Forms::GroupBox());
			this->button13 = (gcnew System::Windows::Forms::Button());
			this->button11 = (gcnew System::Windows::Forms::Button());
			this->button10 = (gcnew System::Windows::Forms::Button());
			this->button9 = (gcnew System::Windows::Forms::Button());
			this->button8 = (gcnew System::Windows::Forms::Button());
			this->button7 = (gcnew System::Windows::Forms::Button());
			this->button6 = (gcnew System::Windows::Forms::Button());
			this->button5 = (gcnew System::Windows::Forms::Button());
			this->button4 = (gcnew System::Windows::Forms::Button());
			this->button3 = (gcnew System::Windows::Forms::Button());
			this->button2 = (gcnew System::Windows::Forms::Button());
			this->button1 = (gcnew System::Windows::Forms::Button());
			this->db_dataGridView_paths = (gcnew System::Windows::Forms::DataGridView());
			this->checkbox = (gcnew System::Windows::Forms::DataGridViewCheckBoxColumn());
			this->description = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->path = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->username = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->password = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->db_appy = (gcnew System::Windows::Forms::Button());
			this->db_text_path = (gcnew System::Windows::Forms::TextBox());
			this->label4 = (gcnew System::Windows::Forms::Label());
			this->db_delete = (gcnew System::Windows::Forms::Button());
			this->db_add = (gcnew System::Windows::Forms::Button());
			this->db_uncheck_all = (gcnew System::Windows::Forms::Button());
			this->db_check_all = (gcnew System::Windows::Forms::Button());
			this->label3 = (gcnew System::Windows::Forms::Label());
			this->db_client_send_request = (gcnew System::Windows::Forms::Button());
			this->db_card_send_request = (gcnew System::Windows::Forms::Button());
			this->db_client_remove = (gcnew System::Windows::Forms::Button());
			this->db_card_delete = (gcnew System::Windows::Forms::Button());
			this->db_client_add = (gcnew System::Windows::Forms::Button());
			this->db_card_add = (gcnew System::Windows::Forms::Button());
			this->db_dataGridView_client = (gcnew System::Windows::Forms::DataGridView());
			this->client_old = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->client_new = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->label2 = (gcnew System::Windows::Forms::Label());
			this->db_dataGridView_card = (gcnew System::Windows::Forms::DataGridView());
			this->card_old = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->card_new = (gcnew System::Windows::Forms::DataGridViewTextBoxColumn());
			this->label1 = (gcnew System::Windows::Forms::Label());
			this->folderBrowserDialog1 = (gcnew System::Windows::Forms::FolderBrowserDialog());
			this->splitContainer1 = (gcnew System::Windows::Forms::SplitContainer());
			this->Consol = (gcnew System::Windows::Forms::TextBox());
			this->openFileDialogGDB = (gcnew System::Windows::Forms::OpenFileDialog());
			this->panel1->SuspendLayout();
			this->panel2->SuspendLayout();
			this->index_tabControl->SuspendLayout();
			this->tabPage1->SuspendLayout();
			this->tabPage2->SuspendLayout();
			this->panel3->SuspendLayout();
			this->groupBox2->SuspendLayout();
			this->groupBox1->SuspendLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->db_dataGridView_paths))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->db_dataGridView_client))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->db_dataGridView_card))->BeginInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->splitContainer1))->BeginInit();
			this->splitContainer1->Panel1->SuspendLayout();
			this->splitContainer1->Panel2->SuspendLayout();
			this->splitContainer1->SuspendLayout();
			this->SuspendLayout();
			// 
			// label_program_name
			// 
			this->label_program_name->AutoSize = true;
			this->label_program_name->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(236)),
				static_cast<System::Int32>(static_cast<System::Byte>(27)), static_cast<System::Int32>(static_cast<System::Byte>(46)));
			this->label_program_name->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 15.75F, System::Drawing::FontStyle::Bold,
				System::Drawing::GraphicsUnit::Point, static_cast<System::Byte>(204)));
			this->label_program_name->ForeColor = System::Drawing::Color::White;
			this->label_program_name->Location = System::Drawing::Point(12, 9);
			this->label_program_name->Name = L"label_program_name";
			this->label_program_name->Size = System::Drawing::Size(545, 25);
			this->label_program_name->TabIndex = 0;
			this->label_program_name->Text = L"Дополнительные утилиты для работы с Frontol 5";
			// 
			// panel1
			// 
			this->panel1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->panel1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(236)), static_cast<System::Int32>(static_cast<System::Byte>(27)),
				static_cast<System::Int32>(static_cast<System::Byte>(46)));
			this->panel1->Controls->Add(this->journal_clear);
			this->panel1->Controls->Add(this->show_hide_journal);
			this->panel1->Location = System::Drawing::Point(0, 0);
			this->panel1->Name = L"panel1";
			this->panel1->Size = System::Drawing::Size(920, 46);
			this->panel1->TabIndex = 1;
			// 
			// journal_clear
			// 
			this->journal_clear->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->journal_clear->BackColor = System::Drawing::Color::DimGray;
			this->journal_clear->Cursor = System::Windows::Forms::Cursors::Hand;
			this->journal_clear->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->journal_clear->ForeColor = System::Drawing::Color::White;
			this->journal_clear->Location = System::Drawing::Point(685, 21);
			this->journal_clear->Name = L"journal_clear";
			this->journal_clear->Size = System::Drawing::Size(114, 23);
			this->journal_clear->TabIndex = 4;
			this->journal_clear->Text = L"Очистить журнал";
			this->journal_clear->UseVisualStyleBackColor = false;
			this->journal_clear->Click += gcnew System::EventHandler(this, &Index::journal_clear_Click);
			// 
			// show_hide_journal
			// 
			this->show_hide_journal->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->show_hide_journal->BackColor = System::Drawing::Color::DimGray;
			this->show_hide_journal->Cursor = System::Windows::Forms::Cursors::Hand;
			this->show_hide_journal->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->show_hide_journal->ForeColor = System::Drawing::Color::White;
			this->show_hide_journal->Location = System::Drawing::Point(805, 21);
			this->show_hide_journal->Name = L"show_hide_journal";
			this->show_hide_journal->Size = System::Drawing::Size(114, 23);
			this->show_hide_journal->TabIndex = 3;
			this->show_hide_journal->Text = L"Скрыть журнал";
			this->show_hide_journal->UseVisualStyleBackColor = false;
			this->show_hide_journal->Click += gcnew System::EventHandler(this, &Index::show_hide_journal_Click);
			// 
			// panel2
			// 
			this->panel2->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->panel2->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(236)), static_cast<System::Int32>(static_cast<System::Byte>(27)),
				static_cast<System::Int32>(static_cast<System::Byte>(46)));
			this->panel2->Controls->Add(this->progressBar1);
			this->panel2->Controls->Add(this->label_version);
			this->panel2->Controls->Add(this->label_creater);
			this->panel2->Location = System::Drawing::Point(0, 540);
			this->panel2->Name = L"panel2";
			this->panel2->Size = System::Drawing::Size(920, 21);
			this->panel2->TabIndex = 2;
			// 
			// progressBar1
			// 
			this->progressBar1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->progressBar1->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(80)), static_cast<System::Int32>(static_cast<System::Byte>(176)),
				static_cast<System::Int32>(static_cast<System::Byte>(21)));
			this->progressBar1->Location = System::Drawing::Point(97, 0);
			this->progressBar1->Name = L"progressBar1";
			this->progressBar1->Size = System::Drawing::Size(726, 23);
			this->progressBar1->TabIndex = 5;
			// 
			// label_version
			// 
			this->label_version->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->label_version->AutoSize = true;
			this->label_version->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(236)), static_cast<System::Int32>(static_cast<System::Byte>(27)),
				static_cast<System::Int32>(static_cast<System::Byte>(46)));
			this->label_version->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->label_version->ForeColor = System::Drawing::Color::White;
			this->label_version->Location = System::Drawing::Point(830, 3);
			this->label_version->Name = L"label_version";
			this->label_version->Size = System::Drawing::Size(77, 15);
			this->label_version->TabIndex = 4;
			this->label_version->Text = L"version 0.3";
			// 
			// label_creater
			// 
			this->label_creater->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->label_creater->AutoSize = true;
			this->label_creater->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(236)), static_cast<System::Int32>(static_cast<System::Byte>(27)),
				static_cast<System::Int32>(static_cast<System::Byte>(46)));
			this->label_creater->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 9, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->label_creater->ForeColor = System::Drawing::Color::White;
			this->label_creater->Location = System::Drawing::Point(3, 3);
			this->label_creater->Name = L"label_creater";
			this->label_creater->Size = System::Drawing::Size(71, 15);
			this->label_creater->TabIndex = 3;
			this->label_creater->Text = L"AlexSnitol";
			// 
			// index_tabControl
			// 
			this->index_tabControl->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->index_tabControl->Controls->Add(this->tabPage1);
			this->index_tabControl->Controls->Add(this->tabPage2);
			this->index_tabControl->HotTrack = true;
			this->index_tabControl->Location = System::Drawing::Point(1, 1);
			this->index_tabControl->Name = L"index_tabControl";
			this->index_tabControl->SelectedIndex = 0;
			this->index_tabControl->Size = System::Drawing::Size(463, 495);
			this->index_tabControl->TabIndex = 0;
			// 
			// tabPage1
			// 
			this->tabPage1->Controls->Add(this->fix_errors_uncheck_all);
			this->tabPage1->Controls->Add(this->fix_errors_check_all);
			this->tabPage1->Controls->Add(this->fix_errors_files);
			this->tabPage1->Controls->Add(this->fix_errors_copy);
			this->tabPage1->Controls->Add(this->fix_errors_run);
			this->tabPage1->Controls->Add(this->fix_errors_appy);
			this->tabPage1->Controls->Add(this->fix_errors_filename);
			this->tabPage1->Controls->Add(this->fix_errors_label_filename);
			this->tabPage1->Controls->Add(this->fix_errors_delete);
			this->tabPage1->Controls->Add(this->fix_errors_add);
			this->tabPage1->Controls->Add(this->fix_errors_label_files);
			this->tabPage1->Location = System::Drawing::Point(4, 22);
			this->tabPage1->Name = L"tabPage1";
			this->tabPage1->Padding = System::Windows::Forms::Padding(3);
			this->tabPage1->Size = System::Drawing::Size(455, 469);
			this->tabPage1->TabIndex = 0;
			this->tabPage1->Text = L"Исправление ошибок";
			this->tabPage1->UseVisualStyleBackColor = true;
			// 
			// fix_errors_uncheck_all
			// 
			this->fix_errors_uncheck_all->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->fix_errors_uncheck_all->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->fix_errors_uncheck_all->Cursor = System::Windows::Forms::Cursors::Hand;
			this->fix_errors_uncheck_all->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->fix_errors_uncheck_all->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(64)),
				static_cast<System::Int32>(static_cast<System::Byte>(64)), static_cast<System::Int32>(static_cast<System::Byte>(64)));
			this->fix_errors_uncheck_all->Location = System::Drawing::Point(357, 3);
			this->fix_errors_uncheck_all->Name = L"fix_errors_uncheck_all";
			this->fix_errors_uncheck_all->Size = System::Drawing::Size(92, 23);
			this->fix_errors_uncheck_all->TabIndex = 12;
			this->fix_errors_uncheck_all->Text = L"Убрать все";
			this->fix_errors_uncheck_all->UseVisualStyleBackColor = false;
			this->fix_errors_uncheck_all->Click += gcnew System::EventHandler(this, &Index::fix_errors_uncheck_all_Click);
			// 
			// fix_errors_check_all
			// 
			this->fix_errors_check_all->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->fix_errors_check_all->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)), static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->fix_errors_check_all->Cursor = System::Windows::Forms::Cursors::Hand;
			this->fix_errors_check_all->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->fix_errors_check_all->ForeColor = System::Drawing::Color::DarkOliveGreen;
			this->fix_errors_check_all->Location = System::Drawing::Point(259, 3);
			this->fix_errors_check_all->Name = L"fix_errors_check_all";
			this->fix_errors_check_all->Size = System::Drawing::Size(92, 23);
			this->fix_errors_check_all->TabIndex = 11;
			this->fix_errors_check_all->Text = L"Выбрать все";
			this->fix_errors_check_all->UseVisualStyleBackColor = false;
			this->fix_errors_check_all->Click += gcnew System::EventHandler(this, &Index::fix_errors_check_all_Click);
			// 
			// fix_errors_files
			// 
			this->fix_errors_files->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->fix_errors_files->ForeColor = System::Drawing::Color::Black;
			this->fix_errors_files->FormattingEnabled = true;
			this->fix_errors_files->Location = System::Drawing::Point(6, 28);
			this->fix_errors_files->Name = L"fix_errors_files";
			this->fix_errors_files->Size = System::Drawing::Size(443, 349);
			this->fix_errors_files->TabIndex = 10;
			this->fix_errors_files->ItemCheck += gcnew System::Windows::Forms::ItemCheckEventHandler(this, &Index::fix_errors_files_ItemCheck);
			// 
			// fix_errors_copy
			// 
			this->fix_errors_copy->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->fix_errors_copy->AutoSize = true;
			this->fix_errors_copy->Checked = true;
			this->fix_errors_copy->CheckState = System::Windows::Forms::CheckState::Checked;
			this->fix_errors_copy->Cursor = System::Windows::Forms::Cursors::Hand;
			this->fix_errors_copy->Location = System::Drawing::Point(9, 419);
			this->fix_errors_copy->Name = L"fix_errors_copy";
			this->fix_errors_copy->Size = System::Drawing::Size(113, 17);
			this->fix_errors_copy->TabIndex = 9;
			this->fix_errors_copy->Text = L"Создавать копии";
			this->fix_errors_copy->UseVisualStyleBackColor = true;
			this->fix_errors_copy->CheckedChanged += gcnew System::EventHandler(this, &Index::fix_errors_copy_CheckedChanged);
			// 
			// fix_errors_run
			// 
			this->fix_errors_run->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->fix_errors_run->BackColor = System::Drawing::SystemColors::Control;
			this->fix_errors_run->Cursor = System::Windows::Forms::Cursors::Hand;
			this->fix_errors_run->FlatStyle = System::Windows::Forms::FlatStyle::System;
			this->fix_errors_run->Location = System::Drawing::Point(293, 440);
			this->fix_errors_run->Name = L"fix_errors_run";
			this->fix_errors_run->Size = System::Drawing::Size(75, 23);
			this->fix_errors_run->TabIndex = 7;
			this->fix_errors_run->Text = L"Запустить";
			this->fix_errors_run->UseVisualStyleBackColor = false;
			this->fix_errors_run->Click += gcnew System::EventHandler(this, &Index::fix_errors_run_Click);
			// 
			// fix_errors_appy
			// 
			this->fix_errors_appy->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->fix_errors_appy->BackColor = System::Drawing::SystemColors::Control;
			this->fix_errors_appy->Cursor = System::Windows::Forms::Cursors::Hand;
			this->fix_errors_appy->Enabled = false;
			this->fix_errors_appy->FlatStyle = System::Windows::Forms::FlatStyle::System;
			this->fix_errors_appy->Location = System::Drawing::Point(374, 440);
			this->fix_errors_appy->Name = L"fix_errors_appy";
			this->fix_errors_appy->Size = System::Drawing::Size(75, 23);
			this->fix_errors_appy->TabIndex = 6;
			this->fix_errors_appy->Text = L"Применить";
			this->fix_errors_appy->UseVisualStyleBackColor = false;
			this->fix_errors_appy->Click += gcnew System::EventHandler(this, &Index::fix_errors_appy_Click);
			// 
			// fix_errors_filename
			// 
			this->fix_errors_filename->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->fix_errors_filename->Location = System::Drawing::Point(107, 389);
			this->fix_errors_filename->Name = L"fix_errors_filename";
			this->fix_errors_filename->Size = System::Drawing::Size(180, 20);
			this->fix_errors_filename->TabIndex = 5;
			this->fix_errors_filename->Text = L"output.txt";
			this->fix_errors_filename->TextChanged += gcnew System::EventHandler(this, &Index::fix_errors_filename_TextChanged);
			// 
			// fix_errors_label_filename
			// 
			this->fix_errors_label_filename->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->fix_errors_label_filename->AutoSize = true;
			this->fix_errors_label_filename->Location = System::Drawing::Point(6, 391);
			this->fix_errors_label_filename->Name = L"fix_errors_label_filename";
			this->fix_errors_label_filename->Size = System::Drawing::Size(95, 13);
			this->fix_errors_label_filename->TabIndex = 4;
			this->fix_errors_label_filename->Text = L"Название файла:";
			// 
			// fix_errors_delete
			// 
			this->fix_errors_delete->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->fix_errors_delete->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->fix_errors_delete->Cursor = System::Windows::Forms::Cursors::Hand;
			this->fix_errors_delete->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->fix_errors_delete->ForeColor = System::Drawing::Color::Maroon;
			this->fix_errors_delete->Location = System::Drawing::Point(374, 389);
			this->fix_errors_delete->Name = L"fix_errors_delete";
			this->fix_errors_delete->Size = System::Drawing::Size(75, 23);
			this->fix_errors_delete->TabIndex = 3;
			this->fix_errors_delete->Text = L"Удалить";
			this->fix_errors_delete->UseVisualStyleBackColor = false;
			this->fix_errors_delete->Click += gcnew System::EventHandler(this, &Index::fix_errors_delete_Click);
			// 
			// fix_errors_add
			// 
			this->fix_errors_add->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->fix_errors_add->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(239)),
				static_cast<System::Int32>(static_cast<System::Byte>(200)));
			this->fix_errors_add->Cursor = System::Windows::Forms::Cursors::Hand;
			this->fix_errors_add->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->fix_errors_add->ForeColor = System::Drawing::Color::DarkOliveGreen;
			this->fix_errors_add->Location = System::Drawing::Point(293, 389);
			this->fix_errors_add->Name = L"fix_errors_add";
			this->fix_errors_add->Size = System::Drawing::Size(75, 23);
			this->fix_errors_add->TabIndex = 2;
			this->fix_errors_add->Text = L"Добавить";
			this->fix_errors_add->UseVisualStyleBackColor = false;
			this->fix_errors_add->Click += gcnew System::EventHandler(this, &Index::fix_errors_add_Click);
			// 
			// fix_errors_label_files
			// 
			this->fix_errors_label_files->AutoSize = true;
			this->fix_errors_label_files->Location = System::Drawing::Point(6, 8);
			this->fix_errors_label_files->Name = L"fix_errors_label_files";
			this->fix_errors_label_files->Size = System::Drawing::Size(80, 13);
			this->fix_errors_label_files->TabIndex = 1;
			this->fix_errors_label_files->Text = L"Список папок:";
			// 
			// tabPage2
			// 
			this->tabPage2->Controls->Add(this->panel3);
			this->tabPage2->Location = System::Drawing::Point(4, 22);
			this->tabPage2->Name = L"tabPage2";
			this->tabPage2->Size = System::Drawing::Size(455, 469);
			this->tabPage2->TabIndex = 1;
			this->tabPage2->Text = L"Работа с БД";
			this->tabPage2->UseVisualStyleBackColor = true;
			// 
			// panel3
			// 
			this->panel3->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->panel3->AutoScroll = true;
			this->panel3->Controls->Add(this->groupBox2);
			this->panel3->Controls->Add(this->groupBox1);
			this->panel3->Controls->Add(this->db_dataGridView_paths);
			this->panel3->Controls->Add(this->db_appy);
			this->panel3->Controls->Add(this->db_text_path);
			this->panel3->Controls->Add(this->label4);
			this->panel3->Controls->Add(this->db_delete);
			this->panel3->Controls->Add(this->db_add);
			this->panel3->Controls->Add(this->db_uncheck_all);
			this->panel3->Controls->Add(this->db_check_all);
			this->panel3->Controls->Add(this->label3);
			this->panel3->Controls->Add(this->db_client_send_request);
			this->panel3->Controls->Add(this->db_card_send_request);
			this->panel3->Controls->Add(this->db_client_remove);
			this->panel3->Controls->Add(this->db_card_delete);
			this->panel3->Controls->Add(this->db_client_add);
			this->panel3->Controls->Add(this->db_card_add);
			this->panel3->Controls->Add(this->db_dataGridView_client);
			this->panel3->Controls->Add(this->label2);
			this->panel3->Controls->Add(this->db_dataGridView_card);
			this->panel3->Controls->Add(this->label1);
			this->panel3->ForeColor = System::Drawing::Color::Black;
			this->panel3->Location = System::Drawing::Point(0, 0);
			this->panel3->Name = L"panel3";
			this->panel3->Size = System::Drawing::Size(452, 466);
			this->panel3->TabIndex = 0;
			// 
			// groupBox2
			// 
			this->groupBox2->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->groupBox2->Controls->Add(this->button25);
			this->groupBox2->Controls->Add(this->button12);
			this->groupBox2->Controls->Add(this->button14);
			this->groupBox2->Controls->Add(this->button15);
			this->groupBox2->Controls->Add(this->button16);
			this->groupBox2->Controls->Add(this->button17);
			this->groupBox2->Controls->Add(this->button18);
			this->groupBox2->Controls->Add(this->button19);
			this->groupBox2->Controls->Add(this->button20);
			this->groupBox2->Controls->Add(this->button21);
			this->groupBox2->Controls->Add(this->button22);
			this->groupBox2->Controls->Add(this->button23);
			this->groupBox2->Controls->Add(this->button24);
			this->groupBox2->Location = System::Drawing::Point(7, 1228);
			this->groupBox2->Name = L"groupBox2";
			this->groupBox2->Size = System::Drawing::Size(425, 196);
			this->groupBox2->TabIndex = 25;
			this->groupBox2->TabStop = false;
			this->groupBox2->Text = L"Обновление цен";
			// 
			// button25
			// 
			this->button25->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button25->Location = System::Drawing::Point(132, 22);
			this->button25->Name = L"button25";
			this->button25->Size = System::Drawing::Size(120, 29);
			this->button25->TabIndex = 36;
			this->button25->Text = L"cut from server";
			this->button25->UseVisualStyleBackColor = true;
			this->button25->Click += gcnew System::EventHandler(this, &Index::button25_Click);
			// 
			// button12
			// 
			this->button12->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button12->Location = System::Drawing::Point(132, 159);
			this->button12->Name = L"button12";
			this->button12->Size = System::Drawing::Size(120, 29);
			this->button12->TabIndex = 35;
			this->button12->Text = L"copy in 11";
			this->button12->UseVisualStyleBackColor = true;
			this->button12->Click += gcnew System::EventHandler(this, &Index::button12_Click);
			// 
			// button14
			// 
			this->button14->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button14->Location = System::Drawing::Point(6, 54);
			this->button14->Name = L"button14";
			this->button14->Size = System::Drawing::Size(120, 29);
			this->button14->TabIndex = 33;
			this->button14->Text = L"copy in 1";
			this->button14->UseVisualStyleBackColor = true;
			this->button14->Click += gcnew System::EventHandler(this, &Index::button14_Click);
			// 
			// button15
			// 
			this->button15->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button15->Location = System::Drawing::Point(132, 57);
			this->button15->Name = L"button15";
			this->button15->Size = System::Drawing::Size(120, 29);
			this->button15->TabIndex = 32;
			this->button15->Text = L"copy in 2";
			this->button15->UseVisualStyleBackColor = true;
			this->button15->Click += gcnew System::EventHandler(this, &Index::button15_Click);
			// 
			// button16
			// 
			this->button16->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button16->Location = System::Drawing::Point(6, 159);
			this->button16->Name = L"button16";
			this->button16->Size = System::Drawing::Size(120, 29);
			this->button16->TabIndex = 31;
			this->button16->Text = L"copy in 10";
			this->button16->UseVisualStyleBackColor = true;
			this->button16->Click += gcnew System::EventHandler(this, &Index::button16_Click);
			// 
			// button17
			// 
			this->button17->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button17->Location = System::Drawing::Point(258, 127);
			this->button17->Name = L"button17";
			this->button17->Size = System::Drawing::Size(120, 29);
			this->button17->TabIndex = 30;
			this->button17->Text = L"copy in 9";
			this->button17->UseVisualStyleBackColor = true;
			this->button17->Click += gcnew System::EventHandler(this, &Index::button17_Click);
			// 
			// button18
			// 
			this->button18->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button18->Location = System::Drawing::Point(132, 124);
			this->button18->Name = L"button18";
			this->button18->Size = System::Drawing::Size(120, 29);
			this->button18->TabIndex = 29;
			this->button18->Text = L"copy in 8";
			this->button18->UseVisualStyleBackColor = true;
			this->button18->Click += gcnew System::EventHandler(this, &Index::button18_Click);
			// 
			// button19
			// 
			this->button19->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button19->Location = System::Drawing::Point(6, 124);
			this->button19->Name = L"button19";
			this->button19->Size = System::Drawing::Size(120, 29);
			this->button19->TabIndex = 28;
			this->button19->Text = L"copy in 7";
			this->button19->UseVisualStyleBackColor = true;
			this->button19->Click += gcnew System::EventHandler(this, &Index::button19_Click);
			// 
			// button20
			// 
			this->button20->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button20->Location = System::Drawing::Point(258, 92);
			this->button20->Name = L"button20";
			this->button20->Size = System::Drawing::Size(120, 29);
			this->button20->TabIndex = 27;
			this->button20->Text = L"copy in 6";
			this->button20->UseVisualStyleBackColor = true;
			this->button20->Click += gcnew System::EventHandler(this, &Index::button20_Click);
			// 
			// button21
			// 
			this->button21->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button21->Location = System::Drawing::Point(132, 89);
			this->button21->Name = L"button21";
			this->button21->Size = System::Drawing::Size(120, 29);
			this->button21->TabIndex = 26;
			this->button21->Text = L"copy in 5";
			this->button21->UseVisualStyleBackColor = true;
			this->button21->Click += gcnew System::EventHandler(this, &Index::button21_Click);
			// 
			// button22
			// 
			this->button22->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button22->Location = System::Drawing::Point(6, 89);
			this->button22->Name = L"button22";
			this->button22->Size = System::Drawing::Size(120, 29);
			this->button22->TabIndex = 25;
			this->button22->Text = L"copy in 4";
			this->button22->UseVisualStyleBackColor = true;
			this->button22->Click += gcnew System::EventHandler(this, &Index::button22_Click);
			// 
			// button23
			// 
			this->button23->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button23->Location = System::Drawing::Point(258, 57);
			this->button23->Name = L"button23";
			this->button23->Size = System::Drawing::Size(120, 29);
			this->button23->TabIndex = 24;
			this->button23->Text = L"copy in 3";
			this->button23->UseVisualStyleBackColor = true;
			this->button23->Click += gcnew System::EventHandler(this, &Index::button23_Click);
			// 
			// button24
			// 
			this->button24->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button24->Location = System::Drawing::Point(6, 19);
			this->button24->Name = L"button24";
			this->button24->Size = System::Drawing::Size(120, 29);
			this->button24->TabIndex = 23;
			this->button24->Text = L"copy in all stantion";
			this->button24->UseVisualStyleBackColor = true;
			this->button24->Click += gcnew System::EventHandler(this, &Index::button24_Click);
			// 
			// groupBox1
			// 
			this->groupBox1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->groupBox1->Controls->Add(this->button13);
			this->groupBox1->Controls->Add(this->button11);
			this->groupBox1->Controls->Add(this->button10);
			this->groupBox1->Controls->Add(this->button9);
			this->groupBox1->Controls->Add(this->button8);
			this->groupBox1->Controls->Add(this->button7);
			this->groupBox1->Controls->Add(this->button6);
			this->groupBox1->Controls->Add(this->button5);
			this->groupBox1->Controls->Add(this->button4);
			this->groupBox1->Controls->Add(this->button3);
			this->groupBox1->Controls->Add(this->button2);
			this->groupBox1->Controls->Add(this->button1);
			this->groupBox1->Location = System::Drawing::Point(7, 1026);
			this->groupBox1->Name = L"groupBox1";
			this->groupBox1->Size = System::Drawing::Size(425, 196);
			this->groupBox1->TabIndex = 24;
			this->groupBox1->TabStop = false;
			this->groupBox1->Text = L"Добавление клиентов";
			// 
			// button13
			// 
			this->button13->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button13->Location = System::Drawing::Point(132, 156);
			this->button13->Name = L"button13";
			this->button13->Size = System::Drawing::Size(120, 29);
			this->button13->TabIndex = 35;
			this->button13->Text = L"copy in 11";
			this->button13->UseVisualStyleBackColor = true;
			this->button13->Click += gcnew System::EventHandler(this, &Index::button13_Click);
			// 
			// button11
			// 
			this->button11->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button11->Location = System::Drawing::Point(6, 51);
			this->button11->Name = L"button11";
			this->button11->Size = System::Drawing::Size(120, 29);
			this->button11->TabIndex = 33;
			this->button11->Text = L"copy in 1";
			this->button11->UseVisualStyleBackColor = true;
			this->button11->Click += gcnew System::EventHandler(this, &Index::button11_Click);
			// 
			// button10
			// 
			this->button10->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button10->Location = System::Drawing::Point(132, 54);
			this->button10->Name = L"button10";
			this->button10->Size = System::Drawing::Size(120, 29);
			this->button10->TabIndex = 32;
			this->button10->Text = L"copy in 2";
			this->button10->UseVisualStyleBackColor = true;
			this->button10->Click += gcnew System::EventHandler(this, &Index::button10_Click);
			// 
			// button9
			// 
			this->button9->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button9->Location = System::Drawing::Point(6, 156);
			this->button9->Name = L"button9";
			this->button9->Size = System::Drawing::Size(120, 29);
			this->button9->TabIndex = 31;
			this->button9->Text = L"copy in 10";
			this->button9->UseVisualStyleBackColor = true;
			this->button9->Click += gcnew System::EventHandler(this, &Index::button9_Click);
			// 
			// button8
			// 
			this->button8->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button8->Location = System::Drawing::Point(258, 124);
			this->button8->Name = L"button8";
			this->button8->Size = System::Drawing::Size(120, 29);
			this->button8->TabIndex = 30;
			this->button8->Text = L"copy in 9";
			this->button8->UseVisualStyleBackColor = true;
			this->button8->Click += gcnew System::EventHandler(this, &Index::button8_Click);
			// 
			// button7
			// 
			this->button7->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button7->Location = System::Drawing::Point(132, 121);
			this->button7->Name = L"button7";
			this->button7->Size = System::Drawing::Size(120, 29);
			this->button7->TabIndex = 29;
			this->button7->Text = L"copy in 8";
			this->button7->UseVisualStyleBackColor = true;
			this->button7->Click += gcnew System::EventHandler(this, &Index::button7_Click);
			// 
			// button6
			// 
			this->button6->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button6->Location = System::Drawing::Point(6, 121);
			this->button6->Name = L"button6";
			this->button6->Size = System::Drawing::Size(120, 29);
			this->button6->TabIndex = 28;
			this->button6->Text = L"copy in 7";
			this->button6->UseVisualStyleBackColor = true;
			this->button6->Click += gcnew System::EventHandler(this, &Index::button6_Click);
			// 
			// button5
			// 
			this->button5->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button5->Location = System::Drawing::Point(258, 89);
			this->button5->Name = L"button5";
			this->button5->Size = System::Drawing::Size(120, 29);
			this->button5->TabIndex = 27;
			this->button5->Text = L"copy in 6";
			this->button5->UseVisualStyleBackColor = true;
			this->button5->Click += gcnew System::EventHandler(this, &Index::button5_Click);
			// 
			// button4
			// 
			this->button4->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button4->Location = System::Drawing::Point(132, 86);
			this->button4->Name = L"button4";
			this->button4->Size = System::Drawing::Size(120, 29);
			this->button4->TabIndex = 26;
			this->button4->Text = L"copy in 5";
			this->button4->UseVisualStyleBackColor = true;
			this->button4->Click += gcnew System::EventHandler(this, &Index::button4_Click);
			// 
			// button3
			// 
			this->button3->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button3->Location = System::Drawing::Point(6, 86);
			this->button3->Name = L"button3";
			this->button3->Size = System::Drawing::Size(120, 29);
			this->button3->TabIndex = 25;
			this->button3->Text = L"copy in 4";
			this->button3->UseVisualStyleBackColor = true;
			this->button3->Click += gcnew System::EventHandler(this, &Index::button3_Click);
			// 
			// button2
			// 
			this->button2->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button2->Location = System::Drawing::Point(258, 54);
			this->button2->Name = L"button2";
			this->button2->Size = System::Drawing::Size(120, 29);
			this->button2->TabIndex = 24;
			this->button2->Text = L"copy in 3";
			this->button2->UseVisualStyleBackColor = true;
			this->button2->Click += gcnew System::EventHandler(this, &Index::button2_Click);
			// 
			// button1
			// 
			this->button1->Cursor = System::Windows::Forms::Cursors::Hand;
			this->button1->Location = System::Drawing::Point(6, 16);
			this->button1->Name = L"button1";
			this->button1->Size = System::Drawing::Size(120, 29);
			this->button1->TabIndex = 23;
			this->button1->Text = L"copy in all stantion";
			this->button1->UseVisualStyleBackColor = true;
			this->button1->Click += gcnew System::EventHandler(this, &Index::button1_Click);
			// 
			// db_dataGridView_paths
			// 
			this->db_dataGridView_paths->AllowUserToAddRows = false;
			this->db_dataGridView_paths->AllowUserToResizeColumns = false;
			this->db_dataGridView_paths->AllowUserToResizeRows = false;
			this->db_dataGridView_paths->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->db_dataGridView_paths->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->db_dataGridView_paths->Columns->AddRange(gcnew cli::array< System::Windows::Forms::DataGridViewColumn^  >(5) {
				this->checkbox,
					this->description, this->path, this->username, this->password
			});
			this->db_dataGridView_paths->Location = System::Drawing::Point(3, 35);
			this->db_dataGridView_paths->MultiSelect = false;
			this->db_dataGridView_paths->Name = L"db_dataGridView_paths";
			this->db_dataGridView_paths->Size = System::Drawing::Size(429, 313);
			this->db_dataGridView_paths->TabIndex = 22;
			this->db_dataGridView_paths->CellEndEdit += gcnew System::Windows::Forms::DataGridViewCellEventHandler(this, &Index::db_dataGridView_paths_CellEndEdit);
			// 
			// checkbox
			// 
			this->checkbox->AutoSizeMode = System::Windows::Forms::DataGridViewAutoSizeColumnMode::AllCells;
			this->checkbox->HeaderText = L"";
			this->checkbox->MinimumWidth = 25;
			this->checkbox->Name = L"checkbox";
			this->checkbox->Width = 25;
			// 
			// description
			// 
			this->description->AutoSizeMode = System::Windows::Forms::DataGridViewAutoSizeColumnMode::AllCells;
			this->description->HeaderText = L"Описание";
			this->description->Name = L"description";
			this->description->Width = 82;
			// 
			// path
			// 
			this->path->AutoSizeMode = System::Windows::Forms::DataGridViewAutoSizeColumnMode::Fill;
			this->path->HeaderText = L"Полный путь";
			this->path->Name = L"path";
			// 
			// username
			// 
			this->username->AutoSizeMode = System::Windows::Forms::DataGridViewAutoSizeColumnMode::AllCells;
			this->username->HeaderText = L"Пользователь";
			this->username->Name = L"username";
			this->username->Width = 105;
			// 
			// password
			// 
			this->password->AutoSizeMode = System::Windows::Forms::DataGridViewAutoSizeColumnMode::AllCells;
			this->password->HeaderText = L"Пароль";
			this->password->Name = L"password";
			this->password->Width = 70;
			// 
			// db_appy
			// 
			this->db_appy->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->db_appy->BackColor = System::Drawing::SystemColors::Control;
			this->db_appy->Cursor = System::Windows::Forms::Cursors::Hand;
			this->db_appy->Enabled = false;
			this->db_appy->FlatStyle = System::Windows::Forms::FlatStyle::System;
			this->db_appy->Location = System::Drawing::Point(357, 383);
			this->db_appy->Name = L"db_appy";
			this->db_appy->Size = System::Drawing::Size(75, 23);
			this->db_appy->TabIndex = 21;
			this->db_appy->Text = L"Применить";
			this->db_appy->UseVisualStyleBackColor = false;
			this->db_appy->Click += gcnew System::EventHandler(this, &Index::db_appy_Click);
			// 
			// db_text_path
			// 
			this->db_text_path->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->db_text_path->Location = System::Drawing::Point(140, 356);
			this->db_text_path->Name = L"db_text_path";
			this->db_text_path->Size = System::Drawing::Size(99, 20);
			this->db_text_path->TabIndex = 20;
			// 
			// label4
			// 
			this->label4->AutoSize = true;
			this->label4->Location = System::Drawing::Point(9, 359);
			this->label4->Name = L"label4";
			this->label4->Size = System::Drawing::Size(125, 13);
			this->label4->TabIndex = 19;
			this->label4->Text = L"Полный путь до файла:";
			// 
			// db_delete
			// 
			this->db_delete->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->db_delete->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(255)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->db_delete->Cursor = System::Windows::Forms::Cursors::Hand;
			this->db_delete->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->db_delete->ForeColor = System::Drawing::Color::Maroon;
			this->db_delete->Location = System::Drawing::Point(357, 354);
			this->db_delete->Name = L"db_delete";
			this->db_delete->Size = System::Drawing::Size(75, 23);
			this->db_delete->TabIndex = 18;
			this->db_delete->Text = L"Удалить";
			this->db_delete->UseVisualStyleBackColor = false;
			this->db_delete->Click += gcnew System::EventHandler(this, &Index::db_delete_Click);
			// 
			// db_add
			// 
			this->db_add->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->db_add->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(239)),
				static_cast<System::Int32>(static_cast<System::Byte>(200)));
			this->db_add->Cursor = System::Windows::Forms::Cursors::Hand;
			this->db_add->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->db_add->ForeColor = System::Drawing::Color::DarkOliveGreen;
			this->db_add->Location = System::Drawing::Point(276, 354);
			this->db_add->Name = L"db_add";
			this->db_add->Size = System::Drawing::Size(75, 23);
			this->db_add->TabIndex = 17;
			this->db_add->Text = L"Добавить";
			this->db_add->UseVisualStyleBackColor = false;
			this->db_add->Click += gcnew System::EventHandler(this, &Index::db_add_Click);
			// 
			// db_uncheck_all
			// 
			this->db_uncheck_all->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->db_uncheck_all->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
				static_cast<System::Int32>(static_cast<System::Byte>(255)));
			this->db_uncheck_all->Cursor = System::Windows::Forms::Cursors::Hand;
			this->db_uncheck_all->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->db_uncheck_all->ForeColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(64)), static_cast<System::Int32>(static_cast<System::Byte>(64)),
				static_cast<System::Int32>(static_cast<System::Byte>(64)));
			this->db_uncheck_all->Location = System::Drawing::Point(340, 5);
			this->db_uncheck_all->Name = L"db_uncheck_all";
			this->db_uncheck_all->Size = System::Drawing::Size(92, 23);
			this->db_uncheck_all->TabIndex = 16;
			this->db_uncheck_all->Text = L"Убрать все";
			this->db_uncheck_all->UseVisualStyleBackColor = false;
			this->db_uncheck_all->Click += gcnew System::EventHandler(this, &Index::db_uncheck_all_Click);
			// 
			// db_check_all
			// 
			this->db_check_all->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->db_check_all->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(255)), static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->db_check_all->Cursor = System::Windows::Forms::Cursors::Hand;
			this->db_check_all->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->db_check_all->ForeColor = System::Drawing::Color::DarkOliveGreen;
			this->db_check_all->Location = System::Drawing::Point(242, 5);
			this->db_check_all->Name = L"db_check_all";
			this->db_check_all->Size = System::Drawing::Size(92, 23);
			this->db_check_all->TabIndex = 15;
			this->db_check_all->Text = L"Выбрать все";
			this->db_check_all->UseVisualStyleBackColor = false;
			this->db_check_all->Click += gcnew System::EventHandler(this, &Index::db_check_all_Click);
			// 
			// label3
			// 
			this->label3->AutoSize = true;
			this->label3->Location = System::Drawing::Point(9, 11);
			this->label3->Name = L"label3";
			this->label3->Size = System::Drawing::Size(112, 13);
			this->label3->TabIndex = 13;
			this->label3->Text = L"Список путей до БД:";
			// 
			// db_client_send_request
			// 
			this->db_client_send_request->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->db_client_send_request->Cursor = System::Windows::Forms::Cursors::Hand;
			this->db_client_send_request->Location = System::Drawing::Point(290, 993);
			this->db_client_send_request->Name = L"db_client_send_request";
			this->db_client_send_request->Size = System::Drawing::Size(142, 29);
			this->db_client_send_request->TabIndex = 9;
			this->db_client_send_request->Text = L"Отправить запрос";
			this->db_client_send_request->UseVisualStyleBackColor = true;
			this->db_client_send_request->Click += gcnew System::EventHandler(this, &Index::db_client_send_request_Click);
			// 
			// db_card_send_request
			// 
			this->db_card_send_request->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->db_card_send_request->Cursor = System::Windows::Forms::Cursors::Hand;
			this->db_card_send_request->Location = System::Drawing::Point(290, 688);
			this->db_card_send_request->Name = L"db_card_send_request";
			this->db_card_send_request->Size = System::Drawing::Size(142, 29);
			this->db_card_send_request->TabIndex = 8;
			this->db_card_send_request->Text = L"Отправить запрос";
			this->db_card_send_request->UseVisualStyleBackColor = true;
			this->db_card_send_request->Click += gcnew System::EventHandler(this, &Index::db_card_send_request_Click);
			// 
			// db_client_remove
			// 
			this->db_client_remove->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->db_client_remove->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(255)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->db_client_remove->Cursor = System::Windows::Forms::Cursors::Hand;
			this->db_client_remove->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->db_client_remove->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->db_client_remove->ForeColor = System::Drawing::Color::Maroon;
			this->db_client_remove->Location = System::Drawing::Point(387, 725);
			this->db_client_remove->Name = L"db_client_remove";
			this->db_client_remove->Size = System::Drawing::Size(25, 25);
			this->db_client_remove->TabIndex = 7;
			this->db_client_remove->Text = L"-";
			this->db_client_remove->UseVisualStyleBackColor = false;
			this->db_client_remove->Click += gcnew System::EventHandler(this, &Index::db_client_remove_Click);
			// 
			// db_card_delete
			// 
			this->db_card_delete->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->db_card_delete->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(255)), static_cast<System::Int32>(static_cast<System::Byte>(192)),
				static_cast<System::Int32>(static_cast<System::Byte>(192)));
			this->db_card_delete->Cursor = System::Windows::Forms::Cursors::Hand;
			this->db_card_delete->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->db_card_delete->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->db_card_delete->ForeColor = System::Drawing::Color::Maroon;
			this->db_card_delete->Location = System::Drawing::Point(387, 421);
			this->db_card_delete->Name = L"db_card_delete";
			this->db_card_delete->Size = System::Drawing::Size(25, 25);
			this->db_card_delete->TabIndex = 6;
			this->db_card_delete->Text = L"-";
			this->db_card_delete->UseVisualStyleBackColor = false;
			this->db_card_delete->Click += gcnew System::EventHandler(this, &Index::db_card_delete_Click);
			// 
			// db_client_add
			// 
			this->db_client_add->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->db_client_add->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(239)),
				static_cast<System::Int32>(static_cast<System::Byte>(200)));
			this->db_client_add->Cursor = System::Windows::Forms::Cursors::Hand;
			this->db_client_add->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->db_client_add->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->db_client_add->ForeColor = System::Drawing::Color::DarkOliveGreen;
			this->db_client_add->Location = System::Drawing::Point(356, 725);
			this->db_client_add->Name = L"db_client_add";
			this->db_client_add->Size = System::Drawing::Size(25, 25);
			this->db_client_add->TabIndex = 5;
			this->db_client_add->Text = L"+";
			this->db_client_add->UseVisualStyleBackColor = false;
			this->db_client_add->Click += gcnew System::EventHandler(this, &Index::db_client_add_Click);
			// 
			// db_card_add
			// 
			this->db_card_add->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->db_card_add->BackColor = System::Drawing::Color::FromArgb(static_cast<System::Int32>(static_cast<System::Byte>(192)), static_cast<System::Int32>(static_cast<System::Byte>(239)),
				static_cast<System::Int32>(static_cast<System::Byte>(200)));
			this->db_card_add->Cursor = System::Windows::Forms::Cursors::Hand;
			this->db_card_add->FlatStyle = System::Windows::Forms::FlatStyle::Flat;
			this->db_card_add->Font = (gcnew System::Drawing::Font(L"Microsoft Sans Serif", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->db_card_add->ForeColor = System::Drawing::Color::DarkOliveGreen;
			this->db_card_add->Location = System::Drawing::Point(356, 421);
			this->db_card_add->Name = L"db_card_add";
			this->db_card_add->Size = System::Drawing::Size(25, 25);
			this->db_card_add->TabIndex = 4;
			this->db_card_add->Text = L"+";
			this->db_card_add->UseVisualStyleBackColor = false;
			this->db_card_add->Click += gcnew System::EventHandler(this, &Index::db_card_add_Click);
			// 
			// db_dataGridView_client
			// 
			this->db_dataGridView_client->AllowUserToAddRows = false;
			this->db_dataGridView_client->AllowUserToResizeColumns = false;
			this->db_dataGridView_client->AllowUserToResizeRows = false;
			this->db_dataGridView_client->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->db_dataGridView_client->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->db_dataGridView_client->Columns->AddRange(gcnew cli::array< System::Windows::Forms::DataGridViewColumn^  >(2) {
				this->client_old,
					this->client_new
			});
			this->db_dataGridView_client->Location = System::Drawing::Point(0, 756);
			this->db_dataGridView_client->MultiSelect = false;
			this->db_dataGridView_client->Name = L"db_dataGridView_client";
			this->db_dataGridView_client->Size = System::Drawing::Size(432, 231);
			this->db_dataGridView_client->TabIndex = 3;
			// 
			// client_old
			// 
			this->client_old->AutoSizeMode = System::Windows::Forms::DataGridViewAutoSizeColumnMode::Fill;
			this->client_old->HeaderText = L"Старый";
			this->client_old->Name = L"client_old";
			this->client_old->Resizable = System::Windows::Forms::DataGridViewTriState::False;
			// 
			// client_new
			// 
			this->client_new->AutoSizeMode = System::Windows::Forms::DataGridViewAutoSizeColumnMode::Fill;
			this->client_new->HeaderText = L"Новый";
			this->client_new->Name = L"client_new";
			this->client_new->Resizable = System::Windows::Forms::DataGridViewTriState::False;
			// 
			// label2
			// 
			this->label2->AutoSize = true;
			this->label2->Location = System::Drawing::Point(9, 734);
			this->label2->Name = L"label2";
			this->label2->Size = System::Drawing::Size(151, 13);
			this->label2->TabIndex = 2;
			this->label2->Text = L"Замена табельного номера:";
			// 
			// db_dataGridView_card
			// 
			this->db_dataGridView_card->AllowUserToAddRows = false;
			this->db_dataGridView_card->AllowUserToResizeColumns = false;
			this->db_dataGridView_card->AllowUserToResizeRows = false;
			this->db_dataGridView_card->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->db_dataGridView_card->ColumnHeadersHeightSizeMode = System::Windows::Forms::DataGridViewColumnHeadersHeightSizeMode::AutoSize;
			this->db_dataGridView_card->Columns->AddRange(gcnew cli::array< System::Windows::Forms::DataGridViewColumn^  >(2) {
				this->card_old,
					this->card_new
			});
			this->db_dataGridView_card->Location = System::Drawing::Point(0, 452);
			this->db_dataGridView_card->MultiSelect = false;
			this->db_dataGridView_card->Name = L"db_dataGridView_card";
			this->db_dataGridView_card->Size = System::Drawing::Size(432, 231);
			this->db_dataGridView_card->TabIndex = 1;
			// 
			// card_old
			// 
			this->card_old->AutoSizeMode = System::Windows::Forms::DataGridViewAutoSizeColumnMode::Fill;
			this->card_old->HeaderText = L"Старый";
			this->card_old->Name = L"card_old";
			this->card_old->Resizable = System::Windows::Forms::DataGridViewTriState::False;
			// 
			// card_new
			// 
			this->card_new->AutoSizeMode = System::Windows::Forms::DataGridViewAutoSizeColumnMode::Fill;
			this->card_new->HeaderText = L"Новый";
			this->card_new->Name = L"card_new";
			this->card_new->Resizable = System::Windows::Forms::DataGridViewTriState::False;
			// 
			// label1
			// 
			this->label1->AutoSize = true;
			this->label1->Location = System::Drawing::Point(7, 431);
			this->label1->Name = L"label1";
			this->label1->Size = System::Drawing::Size(99, 13);
			this->label1->TabIndex = 0;
			this->label1->Text = L"Замена пропуска:";
			// 
			// splitContainer1
			// 
			this->splitContainer1->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom)
				| System::Windows::Forms::AnchorStyles::Left)
				| System::Windows::Forms::AnchorStyles::Right));
			this->splitContainer1->Location = System::Drawing::Point(0, 44);
			this->splitContainer1->Name = L"splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this->splitContainer1->Panel1->Controls->Add(this->index_tabControl);
			this->splitContainer1->Panel1MinSize = 338;
			// 
			// splitContainer1.Panel2
			// 
			this->splitContainer1->Panel2->Controls->Add(this->Consol);
			this->splitContainer1->Panel2MinSize = 100;
			this->splitContainer1->Size = System::Drawing::Size(920, 496);
			this->splitContainer1->SplitterDistance = 460;
			this->splitContainer1->TabIndex = 10;
			this->splitContainer1->MouseDoubleClick += gcnew System::Windows::Forms::MouseEventHandler(this, &Index::splitContainer1_MouseDoubleClick);
			// 
			// Consol
			// 
			this->Consol->BackColor = System::Drawing::Color::DimGray;
			this->Consol->BorderStyle = System::Windows::Forms::BorderStyle::None;
			this->Consol->Cursor = System::Windows::Forms::Cursors::Default;
			this->Consol->Dock = System::Windows::Forms::DockStyle::Fill;
			this->Consol->Font = (gcnew System::Drawing::Font(L"Consolas", 8.25F, System::Drawing::FontStyle::Bold, System::Drawing::GraphicsUnit::Point,
				static_cast<System::Byte>(204)));
			this->Consol->ForeColor = System::Drawing::Color::White;
			this->Consol->HideSelection = false;
			this->Consol->Location = System::Drawing::Point(0, 0);
			this->Consol->Multiline = true;
			this->Consol->Name = L"Consol";
			this->Consol->ReadOnly = true;
			this->Consol->ScrollBars = System::Windows::Forms::ScrollBars::Vertical;
			this->Consol->Size = System::Drawing::Size(456, 496);
			this->Consol->TabIndex = 0;
			this->Consol->Text = L"Добро пожаловать!  Здесь отображается история операций.";
			// 
			// openFileDialogGDB
			// 
			this->openFileDialogGDB->FileName = L"openFileDialogGDB";
			this->openFileDialogGDB->Filter = L"Firebird база данных (*.GDB)|*GDB|Все файлы|*.*";
			this->openFileDialogGDB->RestoreDirectory = true;
			this->openFileDialogGDB->Title = L"Выберите базу данных Firebird";
			// 
			// Index
			// 
			this->AcceptButton = this->fix_errors_run;
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::None;
			this->BackColor = System::Drawing::Color::White;
			this->ClientSize = System::Drawing::Size(919, 561);
			this->Controls->Add(this->splitContainer1);
			this->Controls->Add(this->panel2);
			this->Controls->Add(this->label_program_name);
			this->Controls->Add(this->panel1);
			this->Name = L"Index";
			this->StartPosition = System::Windows::Forms::FormStartPosition::CenterScreen;
			this->Text = L"Дополнительные утилиты Frontol 5";
			this->FormClosed += gcnew System::Windows::Forms::FormClosedEventHandler(this, &Index::Index_FormClosed);
			this->Load += gcnew System::EventHandler(this, &Index::Index_Load);
			this->Shown += gcnew System::EventHandler(this, &Index::Index_Shown);
			this->panel1->ResumeLayout(false);
			this->panel2->ResumeLayout(false);
			this->panel2->PerformLayout();
			this->index_tabControl->ResumeLayout(false);
			this->tabPage1->ResumeLayout(false);
			this->tabPage1->PerformLayout();
			this->tabPage2->ResumeLayout(false);
			this->panel3->ResumeLayout(false);
			this->panel3->PerformLayout();
			this->groupBox2->ResumeLayout(false);
			this->groupBox1->ResumeLayout(false);
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->db_dataGridView_paths))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->db_dataGridView_client))->EndInit();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->db_dataGridView_card))->EndInit();
			this->splitContainer1->Panel1->ResumeLayout(false);
			this->splitContainer1->Panel2->ResumeLayout(false);
			this->splitContainer1->Panel2->PerformLayout();
			(cli::safe_cast<System::ComponentModel::ISupportInitialize^>(this->splitContainer1))->EndInit();
			this->splitContainer1->ResumeLayout(false);
			this->ResumeLayout(false);
			this->PerformLayout();

		}
#pragma endregion

	std::string CutText(std::string Text, int Begin, int End)
	{
		std::string Result;
		Result = "";
		for (int i = Begin; i < End; i++)
		{
			Result = Result + Text[i];
		}
		return Result;
	}
	
	int ProgressBarStatus(int Value)
	{
		if (Value > 100) { Value = 100; };
		if (Value < 0) { Value = 0; };
		progressBar1->Value = Value;
		return 0;
	}

	private: System::Void Index_Load(System::Object^  sender, System::EventArgs^  e) {
		wchar_t CurDirExe[MAX_PATH];
		GetModuleFileName(GetModuleHandle(0), CurDirExe, MAX_PATH);
		String^ CurDirExeSTR1 = msclr::interop::marshal_as<String^>(CurDirExe);
		std::string CurDirExeSTR2 = msclr::interop::marshal_as<std::string>(CurDirExeSTR1);
		std::string CurDir = "";
		std::string CurSym;
		int begin = 0;
		int begin_1 = 0;
		for (int i = 0; i < CurDirExeSTR2.size(); i++)
		{
			CurSym = CurDirExeSTR2[i];
			if (CurSym == CutText("\\", 0, 1))
			{
				CurDir = CurDir + CutText(CurDirExeSTR2, begin, i + 1) + CutText("\\", 0, 1);
				begin = i + 1;
			}
		}
		std::ifstream filein(CurDir + "settings.ini");
		std::string setting_current_row;
		std::string setting_head;
		std::string setting_type;
		std::string setting_value;
		int k = 0;
		int k_par = 1;
		int i_buf = 0;
		if (filein.is_open())
		{
			while (getline(filein, setting_current_row))
			{
				if (CutText(setting_current_row, 0, 1) == "[")
				{
					setting_head = CutText(setting_current_row, 1, setting_current_row.size() - 1);
				}
				else if (CutText(setting_current_row, 0, 1) == ";")
				{
					setting_head = "";
					setting_type = "";
				}
				if (setting_head == "general")
				{
					for (int i = 0; i < setting_current_row.size(); i++)
					{
						CurSym = setting_current_row[i];
						if (CurSym == "=")
						{
							setting_type = CutText(setting_current_row, 1, i);
							setting_value = CutText(setting_current_row, i + 1, setting_current_row.size());
							break;
						}
					}
					if (setting_type == "window_state")
					{
						if (CutText(setting_value, 0, setting_value.size() - 1) == "Maximized")
						{
							this->WindowState = System::Windows::Forms::FormWindowState::Maximized;
						}
						else
						{
							this->WindowState = System::Windows::Forms::FormWindowState::Normal;
						}
					}
					if (setting_type == "window_height")
					{
						this->Height = stoi(CutText(setting_value, 0, setting_value.size() - 1));
					}
					if (setting_type == "window_width")
					{
						this->Width = stoi(CutText(setting_value, 0, setting_value.size() - 1));
					}
					if (setting_type == "splitContainer_SplitterDistance")
					{
						splitContainer1->SplitterDistance = stoi(CutText(setting_value, 0, setting_value.size() - 1));
					}
					if (setting_type == "window_state")
					{
						if (CutText(setting_value, 0, setting_value.size() - 1) == "Maximized")
						{
							this->WindowState = System::Windows::Forms::FormWindowState::Maximized;
						}
						else
						{
							this->WindowState = System::Windows::Forms::FormWindowState::Normal;
						}
					}
					if (setting_type == "journal_state")
					{
						if (CutText(setting_value, 0, setting_value.size() - 1) == "show")
						{
							splitContainer1->Panel2Collapsed = false;
							show_hide_journal->Text = "Скрыть журнал";
							journal_clear->Visible = true;
						}
						else
						{
							splitContainer1->Panel2Collapsed = true;
							show_hide_journal->Text = "Показать журнал";
							journal_clear->Visible = false;
						}
					}
					if (setting_type == "tabcontrol_index")
					{
						index_tabControl->SelectedIndex = stoi(CutText(setting_value, 0, setting_value.size() - 1));
					}
				}
				begin = 0;
				if (setting_head == "utility fix_errors")
				{
					for (int i = 0; i < setting_current_row.size(); i++)
					{
						CurSym = setting_current_row[i];
						if (CurSym == "=")
						{
							setting_type = CutText(setting_current_row, 1, i);
							setting_value = CutText(setting_current_row, i + 1, setting_current_row.size());
							break;
						}
					}
					if (setting_type == "folders")
					{
						for (int i = 0; i < setting_value.size(); i++)
						{
							CurSym = setting_value[i];
							if (CurSym == ";")
							{
								fix_errors_files->Items->Add(msclr::interop::marshal_as<String^>(CutText(setting_value, begin + 3, i)));
								if (CutText(setting_value, begin + 1, begin + 2) == "1")
								{
									fix_errors_files->SetItemChecked(k, true);
								}
								else
								{
									fix_errors_files->SetItemChecked(k, false);
								}
								begin = i + 1;
								k = k + 1;
							}
						}
						k = 0;
						begin = 0;
					}
					if (setting_type == "file_name")
					{
						fix_errors_filename->Text = msclr::interop::marshal_as<String^>(CutText(setting_value, 0, setting_value.size() - 1));
					}
					if (setting_type == "save_copy")
					{
						if (CutText(setting_value, 0, setting_value.size() - 1) == "true")
						{
							fix_errors_copy->Checked = true;
						}
						else if (CutText(setting_value, 0, setting_value.size() - 1) == "false")
						{
							fix_errors_copy->Checked = false;
						}
						else
						{
							fix_errors_copy->Checked = true;
						}
					}
				}
				begin = 0;
				k = 0;
				if (setting_head == "utility db")
				{
					for (int i = 0; i < setting_current_row.size(); i++)
					{
						CurSym = setting_current_row[i];
						if (CurSym == "=")
						{
							setting_type = CutText(setting_current_row, 1, i);
							setting_value = CutText(setting_current_row, i + 1, setting_current_row.size());
							break;
						}
					}
					if (setting_type == "paths")
					{
						for (int i = 0; i < setting_value.size(); i++)
						{
							CurSym = setting_value[i];
							if (CurSym == ";")
							{
								db_dataGridView_paths->Rows->Add();
								for (int j = begin + 3; j < i; j++)
								{
									if (CutText(setting_value, j, j + 1) == "[")
									{
										db_dataGridView_paths->Rows[k]->Cells[2]->Value = msclr::interop::marshal_as<String^>(CutText(setting_value, begin + 3, j));
										for (int j1 = j; j1 < i; j1++)
										{
											if (CutText(setting_value, j1, j1 + 1) == ":")
											{
												if (k_par == 1)
												{
													db_dataGridView_paths->Rows[k]->Cells[1]->Value = msclr::interop::marshal_as<String^>(CutText(setting_value, j + 1, j1));
													i_buf = j1;
												}
												if (k_par == 2)
												{
													db_dataGridView_paths->Rows[k]->Cells[3]->Value = msclr::interop::marshal_as<String^>(CutText(setting_value, i_buf + 1, j1));
													db_dataGridView_paths->Rows[k]->Cells[4]->Value = msclr::interop::marshal_as<String^>(CutText(setting_value, j1 + 1, i - 1));
													k_par = 1;
													break;
												}
												k_par = k_par + 1;
											}
										}
									}
								}
								if (CutText(setting_value, begin + 1, begin + 2) == "1")
								{
									db_dataGridView_paths->Rows[k]->Cells[0]->Value = true;
								}
								else
								{
									db_dataGridView_paths->Rows[k]->Cells[0]->Value = false;
								}
								begin = i + 1;
								k = k + 1;
							}
						}
						k = 0;
					}
					if (setting_type == "card_data")
					{
						for (int i = 0; i < setting_value.size(); i++)
						{
							CurSym = setting_value[i];
							if (CurSym == ";")
							{
								if (k == 0)
								{
									begin_1 = i + 1;
									k = k + 1;
								}
								else
								{
									db_dataGridView_card->Rows->Add(msclr::interop::marshal_as<String^>(CutText(setting_value, begin, begin_1 - 1)), msclr::interop::marshal_as<String^>(CutText(setting_value, begin_1, i)));
									begin = i + 1;
									k = 0;
								}
							}
						}
						k = 0;
						begin = 0;
					}
					if (setting_type == "client_data")
						{
							for (int i = 0; i < setting_value.size(); i++)
							{
								CurSym = setting_value[i];
								if (CurSym == ";")
								{
									if (k == 0)
									{
										begin_1 = i + 1;
										k = k + 1;
									}
									else
									{
										db_dataGridView_client->Rows->Add(msclr::interop::marshal_as<String^>(CutText(setting_value, begin, begin_1 - 1)), msclr::interop::marshal_as<String^>(CutText(setting_value, begin_1, i)));
										begin = i + 1;
										k = 0;
									}
								}
							}
							k = 0;
							begin = 0;
						}
						if (setting_type == "file_name")
						{
							fix_errors_filename->Text = msclr::interop::marshal_as<String^>(CutText(setting_value, 0, setting_value.size() - 1));
						}
						if (setting_type == "save_copy")
						{
							if (CutText(setting_value, 0, setting_value.size() - 1) == "true")
							{
								fix_errors_copy->Checked = true;
							}
							else if (CutText(setting_value, 0, setting_value.size() - 1) == "false")
							{
								fix_errors_copy->Checked = false;
							}
							else
							{
								fix_errors_copy->Checked = true;
							}
						}
					}
				}
			}
		else
		{
			MessageBox::Show("Файл настроек не найден или повреждён.", "Ошибка чтения файла", MessageBoxButtons::RetryCancel, MessageBoxIcon::Error);
		}
		filein.close();
		db_dataGridView_card->RowHeadersVisible = false;
		db_dataGridView_client->RowHeadersVisible = false;
		db_dataGridView_paths->RowHeadersVisible = false;
		//MessageBox::Show(msclr::interop::marshal_as<String^>(setting_head), "", MessageBoxButtons::OKCancel, MessageBoxIcon::Information);
	}
private: System::Void Index_FormClosed(System::Object^ sender, System::Windows::Forms::FormClosedEventArgs^ e) {
	wchar_t CurDirExe[MAX_PATH];
	GetModuleFileName(GetModuleHandle(0), CurDirExe, MAX_PATH);
	String^ CurDirExeSTR1 = msclr::interop::marshal_as<String^>(CurDirExe);
	std::string CurDirExeSTR2 = msclr::interop::marshal_as<std::string>(CurDirExeSTR1);
	std::string CurDir = "";
	std::string CurSym;
	int begin = 0;
	for (int i = 0; i < CurDirExeSTR2.size(); i++)
	{
		CurSym = CurDirExeSTR2[i];
		if (CurSym == CutText("\\", 0, 1))
		{
			CurDir = CurDir + CutText(CurDirExeSTR2, begin, i + 1) + CutText("\\", 0, 1);
			begin = i + 1;
		}
	}
	std::ifstream filein(CurDir + "settings.ini");
	std::string setting_current_row;
	std::string setting_head;
	std::string setting_type;
	int k = 0;
	if (filein.is_open())
	{
		while (getline(filein, setting_current_row))
		{
			k = k + 1;
		}
	}
	else
	{
		MessageBox::Show("Файл настроек не найден или повреждён.", "Ошибка чтения файла", MessageBoxButtons::RetryCancel, MessageBoxIcon::Error);
	}
	filein.close();
	filein.open(CurDir + "settings.ini");
	std::string* settings = new std::string[k];
	k = 0;
	if (filein.is_open())
	{
		while (getline(filein, setting_current_row))
		{
			settings[k] = setting_current_row;
			if (CutText(settings[k], 0, 1) == "[")
			{
				setting_head = CutText(settings[k], 1, settings[k].size() - 1);
			}
			else if (CutText(settings[k], 0, 1) == ";")
			{
				setting_head = "";
				setting_type = "";
			}
			begin = 0;
			if (setting_head == "general")
			{
				for (int i = 0; i < settings[k].size(); i++)
				{
					CurSym = settings[k][i];
					if (CurSym == "=")
					{
						setting_type = CutText(settings[k], 1, i);
						break;
					}
				}
				if (setting_type == "window_height")
				{
					settings[k] = ".window_height=" + msclr::interop::marshal_as<std::string>(Convert::ToString(this->Height)) + ";";
				}
				if (setting_type == "window_width")
				{
					settings[k] = ".window_width=" + msclr::interop::marshal_as<std::string>(Convert::ToString(this->Width)) + ";";
				}
				if (setting_type == "window_state")
				{
					settings[k] = ".window_state=" + msclr::interop::marshal_as<std::string>(Convert::ToString(this->WindowState)) + ";";
				}
				if (setting_type == "splitContainer_SplitterDistance")
				{
					settings[k] = ".splitContainer_SplitterDistance=" + msclr::interop::marshal_as<std::string>(Convert::ToString(splitContainer1->SplitterDistance)) + ";";
				}
				if (setting_type == "journal_state")
				{
					if (show_hide_journal->Text == "Скрыть журнал")
					{
						settings[k] = ".journal_state=show;";
					}
					else
					{
						settings[k] = ".journal_state=hide;";
					}
				}
				if (setting_type == "tabcontrol_index")
				{
					settings[k] = ".tabcontrol_index=" + msclr::interop::marshal_as<std::string>(Convert::ToString(index_tabControl->SelectedIndex)) + ";";
				}
			}
			if (setting_head == "utility db")
			{
				for (int i = 0; i < settings[k].size(); i++)
				{
					CurSym = settings[k][i];
					if (CurSym == "=")
					{
						setting_type = CutText(settings[k], 1, i);
						break;
					}
				}
				if (setting_type == "card_data")
				{
					settings[k] = ".card_data=";
					for (int i = 0; i < db_dataGridView_card->RowCount; i++)
					{
						settings[k] = settings[k] + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_card->Rows[i]->Cells[0]->Value)) + ";" + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_card->Rows[i]->Cells[1]->Value)) + ";";
					}
				}
				if (setting_type == "client_data")
				{
					settings[k] = ".client_data=";
					for (int i = 0; i < db_dataGridView_client->RowCount; i++)
					{
						settings[k] = settings[k] + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_client->Rows[i]->Cells[0]->Value)) + ";" + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_client->Rows[i]->Cells[1]->Value)) + ";";
					}
				}
			}
			k = k + 1;
		}
	}
	else
	{
		MessageBox::Show("Файл настроек не найден или повреждён.", "Ошибка чтения файла", MessageBoxButtons::RetryCancel, MessageBoxIcon::Error);
	}
	filein.close();
	std::ofstream fileout(CurDir + "settings.ini");
	if (fileout.is_open())
	{
		for (int i = 0; i < k; i++)
		{
			fileout << settings[i] << std::endl;
		}
	}
	else
	{
		MessageBox::Show("Файл настроек не найден или повреждён.", "Ошибка чтения файла", MessageBoxButtons::RetryCancel, MessageBoxIcon::Error);
	}
	fileout.close();
	delete[] settings;
}
private: System::Void fix_errors_add_Click(System::Object^  sender, System::EventArgs^  e) {
	if (folderBrowserDialog1->ShowDialog() == Windows::Forms::DialogResult::OK)
	{
		fix_errors_files->Items->Add(folderBrowserDialog1->SelectedPath);
		fix_errors_files->SetItemChecked(fix_errors_files->Items->Count - 1, true);
		fix_errors_files->SetSelected(fix_errors_files->Items->Count - 1, true);
		fix_errors_appy->Enabled = true;
	}
}
private: System::Void fix_errors_delete_Click(System::Object^ sender, System::EventArgs^ e) {
	int index = fix_errors_files->SelectedIndex;
	if (fix_errors_files->Items->Count > 1)
	{
		if (fix_errors_files->SelectedIndex == 0)
		{
			fix_errors_files->SetSelected(1, true);
		}
		else
		{
			fix_errors_files->SetSelected(fix_errors_files->SelectedIndex - 1, true);
		}
	}
	fix_errors_files->Items->Remove(fix_errors_files->Items[index]);
	fix_errors_appy->Enabled = true;
}
private: System::Void fix_errors_appy_Click(System::Object^ sender, System::EventArgs^ e) {
	wchar_t CurDirExe[MAX_PATH];
	GetModuleFileName(GetModuleHandle(0), CurDirExe, MAX_PATH);
	String^ CurDirExeSTR1 = msclr::interop::marshal_as<String^>(CurDirExe);
	std::string CurDirExeSTR2 = msclr::interop::marshal_as<std::string>(CurDirExeSTR1);
	std::string CurDir = "";
	std::string CurSym;
	int begin = 0;
	for (int i = 0; i < CurDirExeSTR2.size(); i++)
	{
		CurSym = CurDirExeSTR2[i];
		if (CurSym == CutText("\\", 0, 1))
		{
			CurDir = CurDir + CutText(CurDirExeSTR2, begin, i + 1) + CutText("\\", 0, 1);
			begin = i + 1;
		}
	}
	std::ifstream filein(CurDir + "settings.ini");
	std::string setting_current_row;
	std::string setting_head;
	std::string setting_type;
	int k = 0;
	if (filein.is_open())
	{
		while (getline(filein, setting_current_row))
		{
			k = k + 1;
		}
	}
	else
	{
		MessageBox::Show("Файл настроек не найден или повреждён.", "Ошибка чтения файла", MessageBoxButtons::RetryCancel, MessageBoxIcon::Error);
	}
	filein.close();
	filein.open(CurDir + "settings.ini");
	std::string* settings = new std::string[k];
	k = 0;
	if (filein.is_open())
	{
		while (getline(filein, setting_current_row))
		{
			settings[k] = setting_current_row;
			if (CutText(settings[k], 0, 1) == "[")
			{
				setting_head = CutText(settings[k], 1, settings[k].size() - 1);
			}
			else if (CutText(settings[k], 0, 1) == ";")
			{
				setting_head = "";
				setting_type = "";
			}
			begin = 0;
			if (setting_head == "utility fix_errors")
			{
				for (int i = 0; i < settings[k].size(); i++)
				{
					CurSym = settings[k][i];
					if (CurSym == "=")
					{
						setting_type = CutText(settings[k], 1, i);
						break;
					}
				}
				if (setting_type == "folders")
				{
					settings[k] = ".folders=";
					for (int i = 0; i < fix_errors_files->Items->Count; i++)
					{
						if (fix_errors_files->GetItemChecked(i) == true)
						{
							settings[k] = settings[k] + "[1]" + msclr::interop::marshal_as<std::string>(fix_errors_files->GetItemText(fix_errors_files->Items[i])) + ";";
						}
						else
						{
							settings[k] = settings[k] + "[0]" + msclr::interop::marshal_as<std::string>(fix_errors_files->GetItemText(fix_errors_files->Items[i])) + ";";
						}
					}
				}
				if (setting_type == "file_name")
				{
					settings[k] = ".file_name=" + msclr::interop::marshal_as<std::string>(fix_errors_filename->Text) + ";";
				}
				if (setting_type == "save_copy")
				{
					if (fix_errors_copy->Checked == true)
					{
						settings[k] = ".save_copy=true;";
					}
					else
					{
						settings[k] = ".save_copy=false;";
					}
				}
			}
			k = k + 1;
		}
	}
	else
	{
		MessageBox::Show("Файл настроек не найден или повреждён.", "Ошибка чтения файла", MessageBoxButtons::RetryCancel, MessageBoxIcon::Error);
	}
	filein.close();
	std::ofstream fileout(CurDir + "settings.ini");
	if (fileout.is_open())
	{
		for (int i = 0; i < k; i++)
		{
			fileout << settings[i] << std::endl;
		}
	}
	else
	{
		MessageBox::Show("Файл настроек не найден или повреждён.", "Ошибка чтения файла", MessageBoxButtons::RetryCancel, MessageBoxIcon::Error);
	}
	fileout.close();
	delete[] settings;
	fix_errors_appy->Enabled = false;
	//MessageBox::Show(msclr::interop::marshal_as<String^>(settings[k]), "Проверка переменной", MessageBoxButtons::OK, MessageBoxIcon::Information);
}
private: System::Void fix_errors_filename_TextChanged(System::Object^ sender, System::EventArgs^ e) {
	fix_errors_appy->Enabled = true;
}
private: System::Void fix_errors_copy_CheckedChanged(System::Object^ sender, System::EventArgs^ e) {
	fix_errors_appy->Enabled = true;
}
private: System::Void Index_Shown(System::Object^ sender, System::EventArgs^ e) {
	fix_errors_appy->Enabled = false;
}
private: System::Void fix_errors_files_ItemCheck(System::Object^ sender, System::Windows::Forms::ItemCheckEventArgs^ e) {
	fix_errors_appy->Enabled = true;
}
private: System::Void fix_errors_run_Click(System::Object^ sender, System::EventArgs^ e) {
	Consol->AppendText("\r\n" + "Запущена утилита очистки ошибок.");
	ProgressBarStatus(0);
	std::string FileDir, FileDirTmp, CurSym, file_current_row = "";
	std::ifstream filein;
	std::ofstream fileout;
	int begin, k, k_max, col, i1, i_sym, file_size, error_size  = 0;
	int k_errors = 0;
	int k_succesful = 0;
	int k_errors_sum = 0;
	for (int i_file = 0; i_file < fix_errors_files->Items->Count; i_file++)
	{
		if (fix_errors_files->GetItemChecked(i_file) == true)
		{
			FileDirTmp = msclr::interop::marshal_as<std::string>(fix_errors_files->GetItemText(fix_errors_files->Items[i_file]));
			FileDir = "";
			begin = 0;
			for (int i = 0; i < FileDirTmp.size(); i++)
			{
				if (CutText(FileDirTmp, i, i + 1) == "\\")
				{
					FileDir = FileDir + CutText(FileDirTmp, begin, i + 1) + "\\";
					begin = i + 1;
				}
			}
			if (CutText(FileDir, 0, 4) == "\\\\\\\\")
			{
				FileDir = CutText(FileDir, 2, FileDir.size());
			}
			FileDir = FileDir + CutText(FileDirTmp, begin, FileDirTmp.size()) + "\\\\";
			filein.open(FileDir + msclr::interop::marshal_as<std::string>(fix_errors_filename->Text));
			begin = 0;
			k = 0;
			if (filein.is_open())
			{
				//Создание копии файла
				if (fix_errors_copy->Checked == true)
				{
					std::ifstream src(FileDir + msclr::interop::marshal_as<std::string>(fix_errors_filename->Text), std::ios::binary);
					for (i_sym = 0; i_sym < msclr::interop::marshal_as<std::string>(fix_errors_filename->Text).size(); i_sym++)
					{
						if (CutText(msclr::interop::marshal_as<std::string>(fix_errors_filename->Text), i_sym, i_sym + 1) == ".")
						{
							break;
						}
					}

					//Добавление к имени копии файла текущую дату и время
					time_t t = time(NULL);
					struct tm* aTm = localtime(&t);
					String^ current_year;
					String^ current_month;
					String^ current_day;
					String^ current_hour;
					String^ current_min;
					String^ current_sec;
					current_year = Convert::ToString(aTm->tm_year + 1900);
					current_month = Convert::ToString(aTm->tm_mon + 1);
					current_day = Convert::ToString(aTm->tm_mday);
					current_hour = Convert::ToString(aTm->tm_hour);
					current_min = Convert::ToString(aTm->tm_min);
					current_sec = Convert::ToString(aTm->tm_sec);
					if (msclr::interop::marshal_as<std::string>(current_month).size() == 1) { current_month = "0" + current_month; };
					if (msclr::interop::marshal_as<std::string>(current_day).size() == 1) { current_day = "0" + current_day; };
					if (msclr::interop::marshal_as<std::string>(current_hour).size() == 1) { current_hour = "0" + current_hour; };
					if (msclr::interop::marshal_as<std::string>(current_min).size() == 1) { current_min = "0" + current_min; };
					if (msclr::interop::marshal_as<std::string>(current_sec).size() == 1) { current_sec = "0" + current_sec; };
					//Проверка на существование файла с таким же названием
					int file_check_k = 1;
					std::string file_number = "";
					if (file_check_k < 100) { file_number = "0" + msclr::interop::marshal_as<std::string>(Convert::ToString(file_check_k)); };
					if (file_check_k < 10) { file_number = "00" + msclr::interop::marshal_as<std::string>(Convert::ToString(file_check_k)); };
					bool file_check_status = false;
					while (file_check_status == false)
					{
						std::ifstream file_check(FileDir +
							CutText(msclr::interop::marshal_as<std::string>(fix_errors_filename->Text), 0, i_sym) +
							"_copy_" +
							msclr::interop::marshal_as<std::string>(current_year + "-" + current_month + "-" + current_day + "_" + current_hour + "-" + current_min + "-" + current_sec) +
							+"_" + file_number +
							CutText(msclr::interop::marshal_as<std::string>(fix_errors_filename->Text), i_sym, msclr::interop::marshal_as<std::string>(fix_errors_filename->Text).size()), std::ios::binary);
						if (file_check.is_open()) {
							file_check_k = file_check_k + 1;
							if (file_check_k < 100) { file_number = "0" + msclr::interop::marshal_as<std::string>(Convert::ToString(file_check_k)); };
							if (file_check_k < 10) { file_number = "00" + msclr::interop::marshal_as<std::string>(Convert::ToString(file_check_k)); };
						}
						else {
							file_check_status = true;
						}
					}
					std::ofstream dst(FileDir +
						CutText(msclr::interop::marshal_as<std::string>(fix_errors_filename->Text), 0, i_sym) +
						"_copy_" +
						msclr::interop::marshal_as<std::string>(current_year + "-" + current_month + "-" + current_day + "_" + current_hour + "-" + current_min + "-" + current_sec) +
						+"_" + file_number +
						CutText(msclr::interop::marshal_as<std::string>(fix_errors_filename->Text), i_sym, msclr::interop::marshal_as<std::string>(fix_errors_filename->Text).size()), std::ios::binary);
					dst << src.rdbuf();
				}
				while (getline(filein, file_current_row))
				{
					k = k + 1;
				}
				k_max = k;
				filein.close();
				filein.open(FileDir + msclr::interop::marshal_as<std::string>(fix_errors_filename->Text));
				Consol->AppendText("\r\n" + "Обрабатывается файл " + fix_errors_files->GetItemText(fix_errors_files->Items[i_file]) + "\\" + fix_errors_filename->Text);
				std::string* file = new std::string[k];
				k = 0;
				k_errors = 0;
				while (getline(filein, file[k]))
				{
					col = 0;
					i1 = 0;
					file_size = file[k].size();
					for (int i = 0; i < file_size; i++)
					{
						if (CutText(file[k], i, i + 1) == ";")
						{
							col = col + 1;
						}
						if ((col == 11 | col == 15) & i1 == 0)
						{
							i1 = i;
						}
						if ((col == 12 | col == 16) & i1 != 0)
						{
							for (int j = 0; j < CutText(file[k], i1 + 1, i).size(); j++)
							{
								if (CutText(CutText(file[k], i1 + 1, i), j, j + 1) == "E")
								{
									error_size = CutText(file[k], i1 + 1, i).size();
									file[k] = CutText(file[k], 0, i1 + 1) + CutText(file[k], i, file[k].size());
									file_size = file_size - error_size;
									i = i1 + 2;
									k_errors = k_errors + 1;
									break;
								}
							}
							i1 = 0;
						}
					}
					k = k + 1;
					if (k == k_max)
					{
						break;
					}
				}
				filein.close();
				if (k_errors == 0)
				{
					Consol->AppendText("\r\n" + "Ошибок не найдено.");
				}
				else
				{
					fileout.open(FileDir + msclr::interop::marshal_as<std::string>(fix_errors_filename->Text));
					for (int i = 0; i < k; i++)
					{
						fileout << file[i] << std::endl;
					}
					fileout.close();
					Consol->AppendText("\r\n" + "Исправленно " + k_errors + " ошибок.");
					k_errors_sum = k_errors_sum + k_errors;
				}
				delete[] file;
				k_succesful = k_succesful + 1;
			}
			else
			{
				Consol->AppendText("\r\n" + "Файл " + fix_errors_files->GetItemText(fix_errors_files->Items[i_file]) + "\\" + fix_errors_filename->Text + " не найден.");
			}
			ProgressBarStatus(100 / fix_errors_files->Items->Count * (i_file + 1));
			begin, k, k_max, col, i1, file_size, error_size, k_errors = 0;
			FileDir, FileDirTmp, CurSym, file_current_row = "";
		}
	}
	Consol->AppendText("\r\n" + "Успешно обработанно " + k_succesful + " файлов из " + fix_errors_files->CheckedItems->Count + ".");
	Consol->AppendText("\r\n" + "Всего исправленно " + k_errors_sum + " ошибок.");
	k_errors_sum = 0;
	ProgressBarStatus(100);
}
private: System::Void fix_errors_uncheck_all_Click(System::Object^ sender, System::EventArgs^ e) {
	for (int i = 0; i < fix_errors_files->Items->Count; i++)
	{
		fix_errors_files->SetItemChecked(i, false);
	}
}
private: System::Void fix_errors_check_all_Click(System::Object^ sender, System::EventArgs^ e) {
	for (int i = 0; i < fix_errors_files->Items->Count; i++)
	{
		fix_errors_files->SetItemChecked(i, true);
	}
}
private: System::Void show_hide_journal_Click(System::Object^ sender, System::EventArgs^ e) {
	if (show_hide_journal->Text == "Скрыть журнал")
	{
		splitContainer1->Panel2Collapsed = true;
		show_hide_journal->Text = "Показать журнал";
		journal_clear->Visible = false;
	}
	else
	{
		splitContainer1->Panel2Collapsed = false;
		show_hide_journal->Text = "Скрыть журнал";
		journal_clear->Visible = true;
	}
}
private: System::Void journal_clear_Click(System::Object^ sender, System::EventArgs^ e) {
	Consol->Clear();
}
private: System::Void splitContainer1_MouseDoubleClick(System::Object^ sender, System::Windows::Forms::MouseEventArgs^ e) {
	splitContainer1->SplitterDistance = splitContainer1->Width / 2;
}
private: System::Void db_card_add_Click(System::Object^ sender, System::EventArgs^ e) {
	db_dataGridView_card->Rows->Add();
}
private: System::Void db_card_delete_Click(System::Object^ sender, System::EventArgs^ e) {
	try
	{
		db_dataGridView_card->Rows->RemoveAt(db_dataGridView_card->CurrentRow->Index);
	}
	catch(...)
	{
	}
}
private: System::Void db_client_add_Click(System::Object^ sender, System::EventArgs^ e) {
	db_dataGridView_client ->Rows->Add();
}
private: System::Void db_client_remove_Click(System::Object^ sender, System::EventArgs^ e) {
	try
	{
		db_dataGridView_client->Rows->RemoveAt(db_dataGridView_client->CurrentRow->Index);
	}
	catch(...)
	{
	}
}
private: System::Void db_card_send_request_Click(System::Object^ sender, System::EventArgs^ e) {
	Consol->AppendText("\r\n" + "Происходит выполнение операций по обработке запроса на редактирование пропуска (-ов) клиента (-ов).");
	wchar_t CurDirExe[MAX_PATH];
	GetModuleFileName(GetModuleHandle(0), CurDirExe, MAX_PATH);
	String^ CurDirExeSTR1 = msclr::interop::marshal_as<String^>(CurDirExe);
	std::string CurDirExeSTR2 = msclr::interop::marshal_as<std::string>(CurDirExeSTR1);
	std::string CurDir = "";
	std::string CurSym;
	int begin = 0;
	for (int i = 0; i < CurDirExeSTR2.size(); i++)
	{
		CurSym = CurDirExeSTR2[i];
		if (CurSym == CutText("\\", 0, 1))
		{
			CurDir = CurDir + CutText(CurDirExeSTR2, begin, i + 1) + CutText("\\", 0, 1);
			begin = i + 1;
		}
	}
	int k = 0;
	std::ofstream fileout(CurDir + "query.sql");
	if (fileout.is_open())
	{
		for (int i_path = 0; i_path < db_dataGridView_paths->Rows->Count; i_path++)
		{
			if (db_dataGridView_paths->Rows[i_path]->Cells[0]->Value->ToString() == "True")
			{
				fileout << "CONNECT '" + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_paths->Rows[i_path]->Cells[2]->Value)) + "' user '" + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_paths->Rows[i_path]->Cells[3]->Value)) + "' password '" + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_paths->Rows[i_path]->Cells[4]->Value)) + "';" << std::endl;
				for (int j = 0; j < db_dataGridView_card->RowCount; j++)
				{
					fileout << "UPDATE CCARD SET CCARD.VAL = " + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_card->Rows[j]->Cells[1]->Value)) + " WHERE CCARD.VAL = " + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_card->Rows[j]->Cells[0]->Value)) + ";" << std::endl;
					fileout << "UPDATE GIFTCARD SET GIFTCARD.NAME = '" + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_card->Rows[j]->Cells[1]->Value)) + "' WHERE GIFTCARD.NAME = '" + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_card->Rows[j]->Cells[0]->Value)) + "';" << std::endl;
				}
				fileout << "commit work;" << std::endl;
			}
		}
		fileout << "QUIT;" << std::endl;
	}
	else
	{
		MessageBox::Show("Файл настроек не найден или повреждён.", "Ошибка чтения файла", MessageBoxButtons::RetryCancel, MessageBoxIcon::Error);
	}
	fileout.close();
	try
	{
		System::Diagnostics::Process::Start(msclr::interop::marshal_as<String^>(CurDir) + "send query.bat.lnk");
	}
	catch (...)
	{
		begin = 0;
		CurDir = "";
		for (int i = 0; i < CurDirExeSTR2.size(); i++)
		{
			CurSym = CurDirExeSTR2[i];
			if (CurSym == CutText("\\", 0, 1))
			{
				CurDir = CurDir + CutText(CurDirExeSTR2, begin, i);
				begin = i;
			}
		}
		MessageBox::Show("Ошибка запуска BAT файла\r\n\r\nЭто может возникнуть по одной из следющих причин:\r\n" +
			"\r\n" + " 1. Вы отменини запуск от имени администратора." +
			"\r\n" + " 2. Файл по пути " + msclr::interop::marshal_as<String^>(CurDir) + "\send query.bat.lnk" + " отсутствует." +
			"\r\n" + " 3. Файл повреждён."
			, "Ошибка запуска BAT файла", MessageBoxButtons::OK, MessageBoxIcon::Error);
	}
	Consol->AppendText("\r\n" + "Операции для обработки запроса на редактирование пропуска (-ов) клиента (-ов) завершены.");
}
private: System::Void db_uncheck_all_Click(System::Object^ sender, System::EventArgs^ e) {
	for (int i = 0; i < db_dataGridView_paths->Rows->Count; i++)
	{
		db_dataGridView_paths->Rows[i]->Cells[0]->Value = false;
	}
	db_appy->Enabled = true;
}
private: System::Void db_add_Click(System::Object^ sender, System::EventArgs^ e) {
	if (db_text_path->Text != "")
	{
		db_dataGridView_paths->Rows->Add(true, "", db_text_path->Text, "SYSDBA", "masterkey");
		db_text_path->Text = "";
		db_appy->Enabled = true;
	}
	else
	{
		if (openFileDialogGDB->ShowDialog() == Windows::Forms::DialogResult::OK)
		{
			db_dataGridView_paths->Rows->Add(true, "", openFileDialogGDB->FileName, "SYSDBA", "masterkey");
			db_appy->Enabled = true;
		}
	}
}
private: System::Void db_delete_Click(System::Object^ sender, System::EventArgs^ e) {
	try
	{
		db_dataGridView_paths->Rows->RemoveAt(db_dataGridView_paths->CurrentRow->Index);
	}
	catch (...)
	{
	}
	db_appy->Enabled = true;
}
private: System::Void db_check_all_Click(System::Object^ sender, System::EventArgs^ e) {
	for (int i = 0; i < db_dataGridView_paths->Rows->Count; i++)
	{
		db_dataGridView_paths->Rows[i]->Cells[0]->Value = true;
	}
	db_appy->Enabled = true;
}
private: System::Void db_appy_Click(System::Object^ sender, System::EventArgs^ e) {
	wchar_t CurDirExe[MAX_PATH];
	GetModuleFileName(GetModuleHandle(0), CurDirExe, MAX_PATH);
	String^ CurDirExeSTR1 = msclr::interop::marshal_as<String^>(CurDirExe);
	std::string CurDirExeSTR2 = msclr::interop::marshal_as<std::string>(CurDirExeSTR1);
	std::string CurDir = "";
	std::string CurSym;
	int begin = 0;
	for (int i = 0; i < CurDirExeSTR2.size(); i++)
	{
		CurSym = CurDirExeSTR2[i];
		if (CurSym == CutText("\\", 0, 1))
		{
			CurDir = CurDir + CutText(CurDirExeSTR2, begin, i + 1) + CutText("\\", 0, 1);
			begin = i + 1;
		}
	}
	std::ifstream filein(CurDir + "settings.ini");
	std::string setting_current_row;
	std::string setting_head;
	std::string setting_type;
	int k = 0;
	if (filein.is_open())
	{
		while (getline(filein, setting_current_row))
		{
			k = k + 1;
		}
	}
	else
	{
		MessageBox::Show("Файл настроек не найден или повреждён.", "Ошибка чтения файла", MessageBoxButtons::RetryCancel, MessageBoxIcon::Error);
	}
	filein.close();
	filein.open(CurDir + "settings.ini");
	std::string* settings = new std::string[k];
	k = 0;
	if (filein.is_open())
	{
		while (getline(filein, setting_current_row))
		{
			settings[k] = setting_current_row;
			if (CutText(settings[k], 0, 1) == "[")
			{
				setting_head = CutText(settings[k], 1, settings[k].size() - 1);
			}
			else if (CutText(settings[k], 0, 1) == ";")
			{
				setting_head = "";
				setting_type = "";
			}
			begin = 0;
			if (setting_head == "utility db")
			{
				for (int i = 0; i < settings[k].size(); i++)
				{
					CurSym = settings[k][i];
					if (CurSym == "=")
					{
						setting_type = CutText(settings[k], 1, i);
						break;
					}
				}
				if (setting_type == "paths")
				{
					settings[k] = ".paths=";
					for (int i = 0; i < db_dataGridView_paths->Rows->Count; i++)
					{
						if (db_dataGridView_paths->Rows[i]->Cells[0]->Value->ToString() == "True")
						{
							settings[k] = settings[k] + "[1]" + msclr::interop::marshal_as<std::string>(db_dataGridView_paths->Rows[i]->Cells[2]->Value + "[" + db_dataGridView_paths->Rows[i]->Cells[1]->Value + ":" + db_dataGridView_paths->Rows[i]->Cells[3]->Value + ":" + db_dataGridView_paths->Rows[i]->Cells[4]->Value + "]") + ";";
						}
						else
						{
							settings[k] = settings[k] + "[0]" + msclr::interop::marshal_as<std::string>(db_dataGridView_paths->Rows[i]->Cells[2]->Value + "[" + db_dataGridView_paths->Rows[i]->Cells[1]->Value + ":" + db_dataGridView_paths->Rows[i]->Cells[3]->Value + ":" + db_dataGridView_paths->Rows[i]->Cells[4]->Value + "]") + ";";
						}
					}
				}
			}
			k = k + 1;
		}
	}
	else
	{
		MessageBox::Show("Файл настроек не найден или повреждён.", "Ошибка чтения файла", MessageBoxButtons::RetryCancel, MessageBoxIcon::Error);
	}
	filein.close();
	std::ofstream fileout(CurDir + "settings.ini");
	if (fileout.is_open())
	{
		for (int i = 0; i < k; i++)
		{
			fileout << settings[i] << std::endl;
		}
	}
	else
	{
		MessageBox::Show("Файл настроек не найден или повреждён.", "Ошибка чтения файла", MessageBoxButtons::RetryCancel, MessageBoxIcon::Error);
	}
	fileout.close();
	delete[] settings;
	db_appy->Enabled = false;
}
private: System::Void db_client_send_request_Click(System::Object^ sender, System::EventArgs^ e) {
	Consol->AppendText("\r\n" + "Происходит выполнение операций по обработке запроса на редактирование табельного (-ых) номера (-ов).");
	wchar_t CurDirExe[MAX_PATH];
	GetModuleFileName(GetModuleHandle(0), CurDirExe, MAX_PATH);
	String^ CurDirExeSTR1 = msclr::interop::marshal_as<String^>(CurDirExe);
	std::string CurDirExeSTR2 = msclr::interop::marshal_as<std::string>(CurDirExeSTR1);
	std::string CurDir = "";
	std::string CurSym;
	int begin = 0;
	for (int i = 0; i < CurDirExeSTR2.size(); i++)
	{
		CurSym = CurDirExeSTR2[i];
		if (CurSym == CutText("\\", 0, 1))
		{
			CurDir = CurDir + CutText(CurDirExeSTR2, begin, i + 1) + CutText("\\", 0, 1);
			begin = i + 1;
		}
	}
	int k = 0;
	std::ofstream fileout(CurDir + "query.sql");
	if (fileout.is_open())
	{
		for (int i_path = 0; i_path < db_dataGridView_paths->Rows->Count; i_path++)
		{
			if (db_dataGridView_paths->Rows[i_path]->Cells[0]->Value->ToString() == "True")
			{
				fileout << "CONNECT '" + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_paths->Rows[i_path]->Cells[2]->Value)) + "' user '" + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_paths->Rows[i_path]->Cells[3]->Value)) + "' password '" + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_paths->Rows[i_path]->Cells[4]->Value)) + "';" << std::endl;
				for (int j = 0; j < db_dataGridView_client->Rows->Count; j++)
				{
					fileout << "UPDATE CLIENT SET CLIENT.CODE = " + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_client->Rows[j]->Cells[1]->Value)) + " WHERE CLIENT.CODE = " + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_client->Rows[j]->Cells[0]->Value)) + ";" << std::endl;
					fileout << "UPDATE CCARD SET CCARD.CODE = " + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_client->Rows[j]->Cells[1]->Value)) + " WHERE CCARD.CODE = " + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_client->Rows[j]->Cells[0]->Value)) + ";" << std::endl;
					fileout << "UPDATE GIFTCARD SET GIFTCARD.CODE = " + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_client->Rows[j]->Cells[1]->Value)) + " WHERE GIFTCARD.CODE = " + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_client->Rows[j]->Cells[0]->Value)) + ";" << std::endl;
				}
				fileout << "commit work;" << std::endl;
			}
		}
		fileout << "QUIT;" << std::endl;
	}
	else
	{
		MessageBox::Show("Файл настроек не найден или повреждён.", "Ошибка чтения файла", MessageBoxButtons::RetryCancel, MessageBoxIcon::Error);
	}
	fileout.close();
	try
	{
		System::Diagnostics::Process::Start(msclr::interop::marshal_as<String^>(CurDir) + "send query.bat.lnk");
	}
	catch (...)
	{
		begin = 0;
		CurDir = "";
		for (int i = 0; i < CurDirExeSTR2.size(); i++)
		{
			CurSym = CurDirExeSTR2[i];
			if (CurSym == CutText("\\", 0, 1))
			{
				CurDir = CurDir + CutText(CurDirExeSTR2, begin, i);
				begin = i;
			}
		}
		MessageBox::Show("Ошибка запуска BAT файла\r\n\r\nЭто может возникнуть по одной из следющих причин:\r\n" +
			"\r\n" + " 1. Вы отменини запуск от имени администратора." +
			"\r\n" + " 2. Файл по пути " + msclr::interop::marshal_as<String^>(CurDir) + "\send query.bat.lnk" + " отсутствует." +
			"\r\n" + " 3. Файл повреждён."
			, "Ошибка запуска BAT файла", MessageBoxButtons::OK, MessageBoxIcon::Error);
	}
	Consol->AppendText("\r\n" + "Операции для обработки запроса на редактирование табельного (-ых) номера (-ов) завершены.");
}
private: System::Void db_dataGridView_paths_CellEndEdit(System::Object^ sender, System::Windows::Forms::DataGridViewCellEventArgs^ e) {
	db_appy->Enabled = true;
}
private: System::Void db_card_send_request_client_Click(System::Object^ sender, System::EventArgs^ e) {
	Consol->AppendText("\r\n" + "Происходит выполнение операций по обработке запроса на получение сведений о клиенте (-ах).");
	wchar_t CurDirExe[MAX_PATH];
	GetModuleFileName(GetModuleHandle(0), CurDirExe, MAX_PATH);
	String^ CurDirExeSTR1 = msclr::interop::marshal_as<String^>(CurDirExe);
	std::string CurDirExeSTR2 = msclr::interop::marshal_as<std::string>(CurDirExeSTR1);
	std::string CurDir = "";
	std::string CurSym;
	int begin = 0;
	for (int i = 0; i < CurDirExeSTR2.size(); i++)
	{
		CurSym = CurDirExeSTR2[i];
		if (CurSym == CutText("\\", 0, 1))
		{
			CurDir = CurDir + CutText(CurDirExeSTR2, begin, i + 1) + CutText("\\", 0, 1);
			begin = i + 1;
		}
	}
	std::string filename1 = CurDir + "output.txt";
	remove(filename1.c_str());
	int k = 0;
	std::ofstream fileout(CurDir + "query.sql");
	if (fileout.is_open())
	{
		for (int i_path = 0; i_path < db_dataGridView_paths->Rows->Count; i_path++)
		{
			if (db_dataGridView_paths->Rows[i_path]->Cells[0]->Value->ToString() == "True")
			{
				fileout << "CONNECT '" + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_paths->Rows[i_path]->Cells[2]->Value)) + "' user '" + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_paths->Rows[i_path]->Cells[3]->Value)) + "' password '" + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_paths->Rows[i_path]->Cells[4]->Value)) + "';" << std::endl;
				for (int j = 0; j < db_dataGridView_card->RowCount; j++)
				{
					fileout << "SELECT CCARD.CODE, CCARD.VAL FROM CCARD WHERE CCARD.VAL = " + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_card->Rows[j]->Cells[0]->Value)) + ";" << std::endl;
					fileout << "SELECT GIFTCARD.CODE, GIFTCARD.NAME FROM GIFTCARD WHERE GIFTCARD.NAME = '" + msclr::interop::marshal_as<std::string>(Convert::ToString(db_dataGridView_card->Rows[j]->Cells[0]->Value)) + "';" << std::endl;
				}
				fileout << "commit work;" << std::endl;
			}
		}
		fileout << "QUIT;" << std::endl;
	}
	else
	{
		MessageBox::Show("Файл настроек не найден или повреждён.", "Ошибка чтения файла", MessageBoxButtons::RetryCancel, MessageBoxIcon::Error);
	}
	fileout.close();
	try
	{
		System::Diagnostics::Process::Start(msclr::interop::marshal_as<String^>(CurDir) + "send query.bat.lnk");
	}
	catch (...)
	{
		begin = 0;
		CurDir = "";
		for (int i = 0; i < CurDirExeSTR2.size(); i++)
		{
			CurSym = CurDirExeSTR2[i];
			if (CurSym == CutText("\\", 0, 1))
			{
				CurDir = CurDir + CutText(CurDirExeSTR2, begin, i);
				begin = i;
			}
		}
		MessageBox::Show("Ошибка запуска BAT файла\r\n\r\nЭто может возникнуть по одной из следющих причин:\r\n" +
			"\r\n" + " 1. Вы отменини запуск от имени администратора." +
			"\r\n" + " 2. Файл по пути " + msclr::interop::marshal_as<String^>(CurDir) + "\send query.bat.lnk" + " отсутствует." +
			"\r\n" + " 3. Файл повреждён."
			, "Ошибка запуска BAT файла", MessageBoxButtons::OK, MessageBoxIcon::Error);
	}
	//Consol->AppendText("\r\n" + "Операции для обработки запроса на получение сведений о клиенте (-ах) завершены.");
}
private: System::Void button1_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для добавления и блокирования клиентов\\copy in all stantion.bat");
}
private: System::Void button11_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для добавления и блокирования клиентов\\copy in 1 - Дружба.bat");
}
private: System::Void button10_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для добавления и блокирования клиентов\\copy in 2 - Северянка.bat");
}
private: System::Void button2_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для добавления и блокирования клиентов\\copy in 3 - б. Северянка.bat");
}
private: System::Void button3_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для добавления и блокирования клиентов\\copy in 4 - Магазин.bat");
}
private: System::Void button4_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для добавления и блокирования клиентов\\copy in 5 - МП1.bat");
}
private: System::Void button5_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для добавления и блокирования клиентов\\copy in 6 - КБП.bat");
}
private: System::Void button6_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для добавления и блокирования клиентов\\copy in 7 - Сударушка.bat");
}
private: System::Void button7_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для добавления и блокирования клиентов\\copy in 8 - Ёлочка.bat");
}
private: System::Void button8_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для добавления и блокирования клиентов\\copy in 9 - РМП.bat");
}
private: System::Void button9_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для добавления и блокирования клиентов\\copy in 10 - ТЭЦ.bat");
}
private: System::Void button13_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для добавления и блокирования клиентов\\copy in 11 - БДМ7.bat");
}
private: System::Void button24_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для обновления цен и товаров\\copy in all stantion.bat");
}
private: System::Void button14_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для обновления цен и товаров\\copy in 1 - Дружба.bat");
}
private: System::Void button15_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для обновления цен и товаров\\copy in 2 - Северянка.bat");
}
private: System::Void button23_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для обновления цен и товаров\\copy in 3 - б. Северянка.bat");
}
private: System::Void button22_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для обновления цен и товаров\\copy in 4 - Магазин.bat");
}
private: System::Void button21_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для обновления цен и товаров\\copy in 5 - МП1.bat");
}
private: System::Void button20_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для обновления цен и товаров\\copy in 6 - КБП.bat");
}
private: System::Void button19_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для обновления цен и товаров\\copy in 7 - Сударушка.bat");
}
private: System::Void button18_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для обновления цен и товаров\\copy in 8 - Ёлочка.bat");
}
private: System::Void button17_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для обновления цен и товаров\\copy in 9 - РМП.bat");
}
private: System::Void button16_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для обновления цен и товаров\\copy in 10 - ТЭЦ.bat");
}
private: System::Void button12_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для обновления цен и товаров\\copy in 11 - БДМ7.bat");
}
private: System::Void button25_Click(System::Object^ sender, System::EventArgs^ e) {
	System::Diagnostics::Process::Start("F:\\input для обновления цен и товаров\\cut from server.bat");
}
};
}
