#include <iostream>
#include <fstream>
#include <string>
#include <cmath>
#include <locale>
#include <vector>

using namespace std;

int n0();
int n6_1(); int n6_2();
string En_De_cryption(string txt, bool operation);

int p = 0;
int cur_work = 6;

int main()
{
    setlocale(LC_ALL, "RU-ru");
    n0();
    return 0;
}

//Главное меню
int n0()
{
    string n = "-1";
    if (p == 1)
    {
        cout << "\n\n_____________________________________________________________\n";
    }
    else
    {
        p = 1;
    };
    if (cur_work == 6)
    {
        cout << "\nДля продолжения выберите программу из списка, введя её номер:\n";
        cout << "\nОбработка текстовых файлов\n\n";
        cout << "6.1. Шифрование текстового файла сдвигом в алфавите (№ 32 из списка)\n";
        cout << "6.2. Преобразование текста в цепочку ASCII-кодов (№ 8 из списка)\n";
        cout << "\n0. Вернуться\n\n";
        cout << "\n-1. Выход\n\n";
    }
    else if (cur_work == -1)
    {
        return 0;
    }
    else
    {
        main();
        return 0;
    }
    cout << "> ";
    cin >> n;
    cout << "\n";
    if (n == "6.1" || (cur_work == 6 && n == "1"))
    {
        n6_1();
    }
    else if (n == "6.2" || (cur_work == 6 && n == "2"))
    {
        n6_2();
    }
    else if (n == "-1")
    {
        return 0;
    }
    else
    {
        main();
    }
    return 0;
}

string space_map = "";
int k_space = 0;

//Шифрование текстового файла сдвигом в алфавите (№ 32 из списка)
int n6_1() {
    int n = 0, n1 = 0, n2 = 0, i = 0;
    float k = 0, k_progress = 0, progress = 0;
    k_space = 0;
    space_map = "";
    cout << "\nШифрование текстового файла сдвигом в алфавите (№ 32 из списка)";
    cout << "\n\nДля продолжения выберите команду из списка, введя её номер:\n";
    cout << "\n1. Шифрование";
    cout << "\n2. Дешифрование";
    cout << "\n\n> ";
    cin >> n;
    if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); cin.ignore(numeric_limits<streamsize>::max(), '\n'); n0(); return -1; };
    string buf1, buf2, buf, cur;
    vector<vector <string> > buf_array;
    if (n == 1 || n == 2)
    {
        cout << "\n\n1. Открыть файл 6.txt в рабочей директории";
        cout << "\n2. Открыть файл 6.txt в рабочей директории и перезаписать";
        cout << "\n3. Ввести произвольный текст";
        cout << "\n4. Ввести произвольный текст и записать в файл";
        cout << "\n\n> ";
        cin >> n1;
        if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); cin.ignore(numeric_limits<streamsize>::max(), '\n'); n0(); return -1; };
        cout << "\n";
        if (n1 == 2 || n1 == 4)
        {
            cout << "Выберите вариант вывода результата:";
            cout << "\n\n1. Прогресс в процентах";
            cout << "\n2. Вывод результата построчно";
            cout << "\n\n> ";
            cin >> n2;
            if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); cin.ignore(numeric_limits<streamsize>::max(), '\n'); n0(); return -1; };
            if (!(n2 == 1 || n2 == 2)) { cout << "Ошибка ввода! (Несуществующий вариант)"; cin.clear(); cin.ignore(numeric_limits<streamsize>::max(), '\n'); n0(); return -1; };
        }
        if (n1 == 1 || n1 == 2)
        {
            if (n2 == 1)
            {
                ifstream fin_txt_1("6.txt");
                if (fin_txt_1.is_open())
                {
                    while (getline(fin_txt_1, buf))
                    {
                        k_progress++;
                    }
                }
                else
                {
                    cout << "Ошибка открытия файла 6.txt!";
                    n0();
                    return 0;
                }
                fin_txt_1.close();
            }
            ifstream fin_txt("6.txt");
            ifstream fin_space_map("6_space_map.txt");
            if (fin_txt.is_open())
            {
                if (fin_space_map.is_open())
                {
                    if (n2 == 1)
                    {
                        cout << "Обработка 0%\n";
                    }
                    while (getline(fin_txt, buf))
                    {

                        if (n == 1)
                        {
                            k_space = 0;
                            buf = En_De_cryption(buf, 1);
                            buf1 = "";
                            for (int i = 0; i < buf.length(); i++)
                            {
                                cur = buf[i];
                                if (cur != " ")
                                    buf1 = buf1 + buf[i];
                            }
                            buf = buf1;
                        }
                        else
                        {
                            getline(fin_space_map, space_map);
                            buf = En_De_cryption(buf, 0);
                        }
                        if (n2 == 2 || n1 == 1 || n1 == 3)
                            cout << buf << "\n";
                        buf_array.resize(k + 1);
                        buf_array[k].resize(2);
                        buf_array[k][0] = buf;
                        buf_array[k][1] = space_map;
                        k = k + 1;
                        if (n2 == 1)
                        {
                            progress = k / (k_progress / 100);
                            if (progress == 0)
                            {
                                progress = 1;
                            }
                            else if (progress >= 100 && k_progress != k)
                            {
                                progress = 99;
                            }
                            else if ((progress >= 100) && (k >= k_progress))
                            {
                                progress = 100;
                            }
                            system("cls");
                            if (n == 1)
                                cout << "Шифрование файла\n\n";
                            if (n == 2)
                                cout << "Дешифрование файла\n\n";
                            cout << "Обработка " << int(progress) << "%\n";
                        }
                    }
                    fin_space_map.close();
                }
                else
                {
                    cout << "Ошибка открытия файла 6_space_map.txt!";
                    n0();
                    return 0;
                }
                fin_txt.close();
            }
            else
            {
                cout << "Ошибка открытия файла 6.txt!";
                n0();
                return 0;
            }
            if ((n1 == 2) && (k != 0))
            {
                ofstream fout_txt("6.txt");
                for (i = 0; i < k - 1; i++)
                {
                    fout_txt << buf_array[i][0] << endl;
                }
                fout_txt << buf_array[i][0];
                fout_txt.close();
                if (n == 1)
                {
                    ofstream fout_space_map("6_space_map.txt");
                    for (i = 0; i < k - 1; i++)
                    {
                        fout_space_map << buf_array[i][1] << endl;
                    }
                    fout_space_map << buf_array[i][1];
                    fout_space_map.close();
                }
            }
            else if (k == 0)
            {
                cout << "Файл пустой!";
            }
        }
        else if (n1 == 3 || n1 == 4)
        {
            cout << "\nВведите текст: ";
            getline(cin, buf);
            getline(cin, buf);
            if (n == 1)
            {
                buf = En_De_cryption(buf, 1);
            }
            else
            {
                buf = En_De_cryption(buf, 0);
            }
            if (n2 == 2 || n1 == 1 || n1 == 3)
                cout << "\nРезультат: " << buf;
            if (n1 == 4)
            {
                ofstream fout("6.txt");
                fout << buf;
                fout.close();
            }
        }
        else
        {
            cout << "Ошибка! Вы выбрали несуществующий вариант. Повторите попытку.";
        }        
    }
    else
    {
        cout << "Ошибка! Вы выбрали несуществующий вариант. Повторите попытку.";
    }
    n0();
    return 0;
}

//Преобразование текста в цепочку ASCII-кодов (№ 8 из списка)
int n6_2()
{
    int n = 0, n1 = 0, i = 0, k = 0;
    cout << "\nПреобразование текста в цепочку ASCII-кодов (№ 8 из списка)";
    cout << "\n\nДля продолжения выберите команду из списка, введя её номер:\n";
    string buf;
    vector<string> buf_array;
    string itog = "";
    cout << "\n\n1. Открыть файл 6.txt в рабочей директории";
    cout << "\n2. Открыть файл 6.txt в рабочей директории и перезаписать";
    cout << "\n3. Ввести произвольный текст";
    cout << "\n4. Ввести произвольный текст и записать в файл";
    cout << "\n\n> ";
    cin >> n1;
    if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); cin.ignore(numeric_limits<streamsize>::max(), '\n'); n0(); return -1; };
    cout << "\n";
    if (n1 == 1 || n1 == 2)
    {
        ifstream fin("6.txt");
        if (fin.is_open())
        {
            while (getline(fin, buf))
            {
                for (int i = 0; i < buf.length(); i++)
                {
                    
                    itog = itog + to_string(static_cast<int>(buf[i]));
                }
                cout << itog << "\n";
                buf_array.resize(k + 1);
                buf_array[k] = itog;
                k = k + 1;
            }
            fin.close();
        }
        if ((n1 == 2) && (k != 0))
        {
            ofstream fout("6.txt");
            for (int i = 0; i < k - 1; i++)
            {
                fout << buf_array[i] << endl;
            }
            fout << buf_array[i + 1];
            fout.close();
        }
        else if (k == 0)
        {
            cout << "Файл пустой!";
        }
    }
    else if (n1 == 3 || n1 == 4)
    {
        cout << "\n\n> ";
        getline(cin, buf);
        getline(cin, buf);
        for (int i = 0; i < buf.length(); i++)
        {

            itog = itog + to_string(static_cast<int>(buf[i]));
        }
        cout << "\nРезультат: " << itog;
        if (n1 == 4)
        {
            ofstream fout("6.txt");
            fout << itog;
            fout.close();
        }
    }
    else
    {
        cout << "Ошибка! Вы выбрали несуществующий вариант. Повторите попытку.";
    }
    n0();
    return 0;
}

//Шифратор (true) и дешифратор (false) с перестановкой в алфавите 
string En_De_cryption(string txt, bool operation)
{
    string abc_EN = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    string abc_en = "abcdefghijklmnopqrstuvwxy";
    string abc_RU = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
    string abc_ru = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    string abc_NUM = "0123456789";
    string abc_SPEC = "!@#$%^&*()[]{}_-+='№;%:?~`.,";
    string itog = "";
    string cur = "";
    string buf = "";
    int i1_sm = 0, i2_sm = 0, n_sm = 0;
    if (operation)
        space_map = " ";
    bool p = false;
    for (int i = 0; i < txt.length(); i++)
    {
        p = false;
        cur = txt[i];
        if (cur == " " && operation == true)
        {
            space_map = space_map + to_string(i-k_space) + ";";
            k_space++;
        }
        else
        {
            for (i2_sm = 0; i2_sm < space_map.length(); i2_sm++)
            {
                cur = space_map[i2_sm];
                if (cur == ";")
                {
                    for (i1_sm; i1_sm < i2_sm; i1_sm++)
                    {
                        buf = buf + space_map[i1_sm];
                    }
                    n_sm = stof(buf);
                    //cout << "[" << n_sm << "]" << "[" << i << "]";
                    if (n_sm == i)
                    {
                        itog = itog + " ";
                        buf = "";
                        for (int i3 = (i2_sm + 1); i3 < space_map.length(); i3++)
                        {
                            buf = buf + space_map[i3];
                        }
                        space_map = buf;
                        break;
                    }
                }
            }
            for (int j = 0; j < abc_NUM.length(); j++)
            {
                if (txt[i] == abc_NUM[j])
                {
                    if (operation == true)
                    {
                        if (j == abc_NUM.length() - 1)
                        {
                            itog = itog + abc_NUM[0];
                        }
                        else
                        {
                            itog = itog + abc_NUM[j + 1];
                        }
                    }
                    else
                    {
                        if (j == 0)
                        {
                            itog = itog + abc_NUM[abc_NUM.length() - 1];
                        }
                        else
                        {
                            itog = itog + abc_NUM[j - 1];
                        }
                    }
                    p = true;
                    break;
                }
            }
            if (p != true)
            {
                for (int j = 0; j < abc_SPEC.length(); j++)
                {
                    if (txt[i] == abc_SPEC[j])
                    {
                        if (operation == true)
                        {
                            if (j == abc_SPEC.length() - 1)
                            {
                                itog = itog + abc_SPEC[0];
                            }
                            else
                            {
                                itog = itog + abc_SPEC[j + 1];
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                itog = itog + abc_SPEC[abc_SPEC.length() - 1];
                            }
                            else
                            {
                                itog = itog + abc_SPEC[j - 1];
                            }
                        }
                        p = true;
                        break;
                    }
                }
            }
            else
            {
                continue;
            }
            if (p != true)
            {
                for (int j = 0; j < abc_EN.length(); j++)
                {
                    if (txt[i] == abc_EN[j])
                    {
                        if (operation == true)
                        {
                            if (j == abc_EN.length() - 1)
                            {
                                itog = itog + abc_EN[0];
                            }
                            else
                            {
                                itog = itog + abc_EN[j + 1];
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                itog = itog + abc_EN[abc_EN.length() - 1];
                            }
                            else
                            {
                                itog = itog + abc_EN[j - 1];
                            }
                        }
                        p = true;
                        break;
                    }
                }
            }
            else
            {
                continue;
            }
            if (p != true)
            {
                for (int j = 0; j < abc_en.length(); j++)
                {
                    if (txt[i] == abc_en[j])
                    {
                        if (operation == true)
                        {
                            if (j == abc_en.length() - 1)
                            {
                                itog = itog + abc_en[0];
                            }
                            else
                            {
                                itog = itog + abc_en[j + 1];
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                itog = itog + abc_en[abc_en.length() - 1];
                            }
                            else
                            {
                                itog = itog + abc_en[j - 1];
                            }
                        }
                        p = true;
                        break;
                    }
                }
            }
            else
            {
                continue;
            }
            if (p != true)
            {
                for (int j = 0; j < abc_RU.length(); j++)
                {
                    if (txt[i] == abc_RU[j])
                    {
                        if (operation == true)
                        {
                            if (j == abc_RU.length() - 1)
                            {
                                itog = itog + abc_RU[0];
                            }
                            else
                            {
                                itog = itog + abc_RU[j + 1];
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                itog = itog + abc_RU[abc_RU.length() - 1];
                            }
                            else
                            {
                                itog = itog + abc_RU[j - 1];
                            }
                        }
                        p = true;
                        break;
                    }
                }
            }
            else
            {
                continue;
            }
            if (p != true)
            {
                for (int j = 0; j < abc_ru.length(); j++)
                {
                    if (txt[i] == abc_ru[j])
                    {
                        if (operation == true)
                        {
                            if (j == abc_ru.length() - 1)
                            {
                                itog = itog + abc_ru[0];
                            }
                            else
                            {
                                itog = itog + abc_ru[j + 1];
                            }
                        }
                        else
                        {
                            if (j == 0)
                            {
                                itog = itog + abc_ru[abc_ru.length() - 1];
                            }
                            else
                            {
                                itog = itog + abc_ru[j - 1];
                            }
                        }
                        p = true;
                        break;
                    }
                }
            }
            if (p != true)
            {
                itog = itog + txt[i];
            }
        }
    }
    return itog;
}
