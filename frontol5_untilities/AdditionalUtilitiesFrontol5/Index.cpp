#include "Index.h"

using namespace System;
using namespace System::Windows::Forms;

[STAThread]
void main(array<String^>^ arg) {
	Application::EnableVisualStyles();
	Application::SetCompatibleTextRenderingDefault(false);

	AdditionalUtilitiesFrontol5::Index form;
	Application::Run(%form);
}