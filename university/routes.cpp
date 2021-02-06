#include <iostream>
#include <fstream>
#include <string>
#include <cmath>
#include <locale>
#include <vector>
#include <windows.h>

using namespace std;

int n0();

void save_map(vector <vector <vector <string>>> map)
{
    ofstream fout("12.txt");
    for (size_t i = 0; i < map.size(); i++) //Маршруты/линии
    {
        fout << map[i][0][0] << ";";

        for (size_t j = 0; j < map[i].size(); j++) //Остановки
        {
            fout << map[i][j][1];

            if (map[i][j][2] == "1")
            {
                fout << "'";
            }

            fout << "[" << map[i][j][3] << "];";
        }
        if (i != map.size() - 1)
        {
            fout << "\n";
        }
    }
    fout.close();
    cout << "\nИзменения сохранены!\n\n";
}

int main()
{
    SetConsoleCP(1251);
    SetConsoleOutputCP(1251);
    n0();
    return 0;
}

//Главное меню
int n0()
{
    int v = -1, v1 = -1, v2 = -1, v3 = -1, v4 = -1, v5 = -1;

    string buf = "", buf2 = "", cur = "", buf_line_name = "", buf_point_name = "", buf_point_dist = "";
    int i0 = 0, k_line = -1, k_point = -1, k_succ = 0, k_open = 0, cur_v = 0, i_min = 0, k_hour = 0, k_used = 0;
    float f_buf = 0, sum = 0, min = 0;
    bool p = true, p_u = false;
    bool log = false;                            //параметр для разработчика, что бы выводить логи
    vector <vector <vector <string>>> map;      //основной массив с маршрутами
    vector <vector <vector <string>>> variants; //временный массив с вариантами оптимальных путей
    vector <vector <string>> used;              //временный массив с использованными остановками

    ifstream fin("12.txt");
    if (fin.is_open())
    {
        while (getline(fin, buf))
        {
            map.resize(++k_line + 1);
            k_point = -1;
            buf_line_name = "";
            i0 = 0;
            for (size_t i = 0; i < buf.size(); i++)
            {
                cur = buf[i];
                if (cur == ";")
                {
                    if (++k_point != 0)
                    {
                        map[k_line].resize(k_point);
                        map[k_line][k_point - 1].resize(4); // 0 - к какой линии принадлежит остановка; 1 - название остановки; 2 - является ли остановка конечной (1 - да, 0 - нет); 3 - кол-во времени до этой остановки
                        map[k_line][k_point - 1][0] = buf_line_name; //Название маршрута/линии
                        map[k_line][k_point - 1][1] = "";
                        map[k_line][k_point - 1][2] = "";
                        map[k_line][k_point - 1][3] = "";
                    }

                    p = true;

                    for (size_t i1 = i0; i1 < i; i1++)
                    {
                        cur = buf[i1];

                        if (k_point != 0)
                        {
                            if (cur == "'")
                            {
                                map[k_line][k_point - 1][2] = "1"; //Конечная остановка
                                p = false;
                            }
                            else if (cur == "[")
                            {
                                p = false;
                            }

                            if (p == true)
                            {
                                map[k_line][k_point - 1][1] = map[k_line][k_point - 1][1] + buf[i1]; //Название остановки
                            }
                            else if (p == false && cur != "[" && cur != "]" && cur != "'")
                            {
                                map[k_line][k_point - 1][3] = map[k_line][k_point - 1][3] + buf[i1]; //Дистанция остановки
                            }
                        }
                        else
                        {
                            buf_line_name = buf_line_name + buf[i1]; //Название/номер маршрута
                        }
                    }

                    if (k_point != 0)
                    {
                        if (map[k_line][k_point - 1][2] != "1")
                        {
                            map[k_line][k_point - 1][2] = "0";
                        }
                    }

                    i0 = i + 1;
                }
            }
        }
        fin.close();
    }
    else
    {
        cout << "Ошибка чтения файла!\n";
        n0();
        return 0;
    }

    while (v == -1)
    {
        cout << "\n# Индивидуальное задание #\n\nФормирование самого короткого маршрута";
        cout << "\n\n";
        cout << "Текущие маршруты:\n\n";

        for (size_t i = 0; i < map.size(); i++) //Маршруты/линии
        {
            cout << "Маршрут " << map[i][0][0] << " :";

            for (size_t j = 0; j < map[i].size(); j++) //Остановки
            {
                cout << " " << map[i][j][1];

                if (map[i][j][2] == "1" && j != 0)
                {
                    cout << " (конечная, ";
                }
                else
                {
                    cout << " (";
                }

                if (map[i][j][3] == "")
                {
                    cout << "- мин.)";
                }
                else
                {
                    cout << map[i][j][3] << " мин.)";
                }

                if (j != map[i].size() - 1)
                {
                    cout << "\t-->";
                }
            }
            if (i != map.size() - 1)
            {
                cout << "\n";
            }
        }

        cout << "\n\nВыберите действие:\n\n";
        cout << "1. Указать путь\n";
        cout << "2. Редактор маршрутов\n\n";
        cout << "0. Вернуться в главное меню\n\n";
        cout << "> ";
        cin >> v;
        cout << "\n";
        if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
        v1 = -1;
        if (v == 1) //Указать путь
        {
            while (v1 == -1)
            {
                cout << "Выберите маршрут начала:\n\n";
                for (size_t i = 0; i < map.size(); i++)
                {
                    cout << i + 1 << ". " << map[i][0][0] << endl;
                }
                cout << "\n0. Вернуться";
                cout << "\n\n> ";
                cin >> v1;
                if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                cout << "\n";
                v2 = -1;
                if (v1 == 0)
                {
                    v = -1;
                }
                else if (v1 > map.size() || v1 < 0)
                {
                    cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                    v1 = -1;
                }
                else //Выбрали маршрут начала
                {
                    v1--;
                    while (v2 == -1)
                    {
                        cout << "Выберите остановку начала:\n\n";
                        for (size_t j = 0; j < map[v1].size(); j++)
                        {
                            p = true;

                            for (size_t k = 0; k < j; k++)
                            {
                                if (map[v1][k][1] == map[v1][j][1])
                                {
                                    p = false;
                                    break;
                                }
                            }

                            if (p)
                            {
                                cout << j + 1 << ". " << map[v1][j][1] << endl;
                            }
                        }
                        cout << "\n0. Вернуться\n";
                        cout << "\n> ";
                        cin >> v2;
                        if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                        cout << "\n";
                        v3 = -1;
                        if (v2 == 0)
                        {
                            v1 = -1;
                        }
                        else if (v2 > map[v1].size() || v2 < 0)
                        {
                            cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                            v2 = -1;
                        }
                        else //Выбрали остановку начала
                        {
                            v2--;
                            while (v3 == -1)
                            {
                                cout << "Выберите маршрут конца:\n\n";
                                for (size_t i = 0; i < map.size(); i++)
                                {
                                    cout << i + 1 << ". " << map[i][0][0] << endl;
                                }
                                cout << "\n0. Вернуться";
                                cout << "\n\n> ";
                                cin >> v3;
                                if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                cout << "\n";
                                v4 = -1;
                                if (v3 == 0)
                                {
                                    v2 = -1;
                                }
                                else if (v3 > map.size() || v3 < 0)
                                {
                                    cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                    v3 = -1;
                                }
                                else //Выбрали маршрут конца
                                {
                                    v3--;
                                    while (v4 == -1)
                                    {
                                        cout << "Выберите остановку конца:\n\n";
                                        for (size_t j = 0; j < map[v3].size(); j++)
                                        {
                                            p = true;

                                            for (size_t k = 0; k < j; k++)
                                            {
                                                if (map[v3][k][1] == map[v3][j][1])
                                                {
                                                    p = false;
                                                    break;
                                                }
                                            }

                                            if (p)
                                            {
                                                cout << j + 1 << ". " << map[v3][j][1] << endl;
                                            }
                                        }
                                        cout << "\n0. Вернуться\n";
                                        cout << "\n> ";
                                        cin >> v4;
                                        if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                        cout << "\n";
                                        v5 = -1;
                                        if (v4 == 0)
                                        {
                                            v3 = -1;
                                        }
                                        else if (v4 > map[v3].size() || v4 < 0)
                                        {
                                            cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                            v4 = -1;
                                        }
                                        else //Выбрали остановку конца
                                        {
                                            v4--;

                                            //Процесс поиска вариантов
                                            cout << "Маршрут: " << map[v1][v2][1];
                                            if (map[v1][v2][2] == "1")
                                            {
                                                cout << " (конечная)";
                                            }
                                            cout << " -> " << map[v3][v4][1];
                                            if (map[v3][v4][2] == "1")
                                            {
                                                cout << " (конечная)";
                                            }
                                            
                                            if (map[v1][v2][1] != map[v3][v4][1])
                                            {

                                                p = true;
                                                variants.resize(1);
                                                variants[0].resize(1);
                                                variants[0][0].resize(3);
                                                variants[0][0][1] = map[v1][v2][1]; // Добавили в массив вариантов название остановки
                                                variants[0][0][0] = map[v1][v2][0]; // и название/номер маршрута начала
                                                variants[0][0][2] = "1";            // также активировали данный вариант
                                                while (p)
                                                {
                                                    for (size_t i_v = 0; i_v < variants.size(); i_v++)
                                                    {
                                                        if (log)
                                                        {
                                                            cout << " \n\n*i_v: " << i_v;
                                                            cout << " \n*{" << variants[i_v][variants[i_v].size() - 1][1] << "} ";
                                                        }

                                                        cur_v = variants[i_v].size() - 1;
                                                        if (variants[i_v][variants[i_v].size() - 1][1] == map[v3][v4][1] || variants[i_v][0][2] == "0")
                                                        {
                                                            if (log)
                                                            {
                                                                cout << "\n *skip";
                                                            }
                                                            continue;
                                                        }
                                                        k_point = 0;
                                                        for (size_t i = 0; i < map.size(); i++)
                                                        {
                                                            k_used = 0;
                                                            for (size_t j = 0; j < map[i].size(); j++)
                                                            {
                                                                if (map[i][j][1] == variants[i_v][cur_v][1] && j != map[i].size() - 1)
                                                                {

                                                                    p_u = false;
                                                                    for (size_t i_u = 0; i_u < used.size(); i_u++)
                                                                    {
                                                                        if (variants[i_v][cur_v][1] == used[i_u][0])
                                                                        {
                                                                            p_u = true;
                                                                            break;
                                                                        }
                                                                    }
                                                                    if (p_u == false)
                                                                    {
                                                                        k_used++;
                                                                    }

                                                                    if (log)
                                                                    {
                                                                        cout << "\n *k_used: " << k_used;
                                                                    }

                                                                    //Проверка следующей остановки на использованность
                                                                    p_u = false;
                                                                    for (size_t i_u = 0; i_u < used.size(); i_u++)
                                                                    {
                                                                        if (map[i][j + 1][1] == used[i_u][0] && stof(used[i_u][1]) <= 0)
                                                                        {
                                                                            p_u = true;
                                                                            k_used = 0;
                                                                            if (k_point == 0)
                                                                            {
                                                                                variants[i_v][0][2] = "0";
                                                                                if (log)
                                                                                {
                                                                                    cout << "\n *block";
                                                                                }
                                                                            }
                                                                            break;
                                                                        }
                                                                    }

                                                                    if (log)
                                                                    {
                                                                        cout << "\n *--> " << map[i][j + 1][1];
                                                                        cout << "\n\n *1 complete";
                                                                        cout << "\n i: " << i << " j: " << j;
                                                                        cout << "\n *2 start";
                                                                    }

                                                                    if (p_u == false)
                                                                    {
                                                                        // Если от текущей остановки есть ещё один путь
                                                                        if (k_point == 1)
                                                                        {
                                                                            for (size_t i_u = 0; i_u < used.size(); i_u++)
                                                                            {
                                                                                if (variants[i_v][cur_v][1] == used[i_u][0])
                                                                                {
                                                                                    used[i_u][1] = to_string(int(stof(used[i_u][1]) + 1));
                                                                                    break;
                                                                                }
                                                                            }
                                                                            k_point = 0;
                                                                            variants.resize(variants.size() + 1);
                                                                            variants[variants.size() - 1].resize(variants[i_v].size());

                                                                            for (size_t j_v = 0; j_v < variants[i_v].size() - 1; j_v++)
                                                                            {
                                                                                variants[variants.size() - 1][j_v].resize(3);
                                                                                variants[variants.size() - 1][j_v][1] = variants[i_v][j_v][1];
                                                                                variants[variants.size() - 1][j_v][0] = variants[i_v][j_v][0];
                                                                            }
                                                                            variants[variants.size() - 1][variants[variants.size() - 1].size() - 1].resize(3);

                                                                            variants[variants.size() - 1][0][2] = "1";
                                                                            variants[variants.size() - 1][variants[variants.size() - 1].size() - 1][1] = map[i][j + 1][1];
                                                                            variants[variants.size() - 1][variants[variants.size() - 1].size() - 1][0] = map[i][j + 1][0];

                                                                            if (log)
                                                                            {
                                                                                cout << "\n *add variant";
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            variants[i_v].resize(variants[i_v].size() + 1);
                                                                            variants[i_v][variants[i_v].size() - 1].resize(3);

                                                                            variants[i_v][variants[i_v].size() - 1][1] = map[i][j + 1][1];

                                                                            variants[i_v][variants[i_v].size() - 1][0] = map[i][j + 1][0];

                                                                            variants[i_v][0][2] = "1";

                                                                            if (log)
                                                                            {
                                                                                cout << "\n *add point";
                                                                            }
                                                                        }

                                                                        k_point++;

                                                                        for (size_t i_u = 0; i_u < used.size(); i_u++)
                                                                        {
                                                                            if (variants[i_v][cur_v][1] == used[i_u][0])
                                                                            {
                                                                                used[i_u][1] = to_string(int(stof(used[i_u][1]) - 1));
                                                                                p_u = true;
                                                                                break;
                                                                            }
                                                                        }
                                                                        if (p_u == false)
                                                                        {
                                                                            used.resize(used.size() + 1);
                                                                            used[used.size() - 1].resize(2);
                                                                            used[used.size() - 1][0] = variants[i_v][cur_v][1];
                                                                            used[used.size() - 1][1] = to_string(int(k_used - 1));
                                                                            
                                                                            if (log)
                                                                            {
                                                                                cout << "\n *add to used (" << variants[i_v][cur_v][1] << ")";
                                                                            }
                                                                        }
                                                                    }

                                                                    if (log)
                                                                    {
                                                                        cout << "\n *k_used: " << used[used.size() - 1][1];
                                                                        cout << "\n *2 complete";
                                                                    }
                                                                }
                                                                if (variants[i_v][variants[i_v].size() - 1][1] == map[v3][v4][1])
                                                                {
                                                                    break;
                                                                }
                                                            }
                                                            if (variants[i_v][variants[i_v].size() - 1][1] == map[v3][v4][1])
                                                            {
                                                                break;
                                                            }
                                                        }
                                                    }

                                                    //Проверка на готовность вариантов
                                                    k_succ = 0;
                                                    k_open = 0;
                                                    for (size_t i_v = 0; i_v < variants.size(); i_v++)
                                                    {
                                                        if (variants[i_v][variants[i_v].size() - 1][1] == map[v3][v4][1] && variants[i_v][0][2] == "1")
                                                        {
                                                            k_succ++;
                                                        }
                                                        if (variants[i_v][0][2] == "1")
                                                        {
                                                            k_open++;
                                                        }
                                                    }
                                                    if (k_succ == k_open)
                                                    {
                                                        p = false;
                                                    }

                                                    if (log)
                                                    {
                                                        cout << "\n *4 complete";
                                                    }
                                                }

                                                if (log)
                                                {
                                                    cout << "\n *used: ";
                                                    for (size_t i = 0; i < used.size(); i++)
                                                    {
                                                        cout << used[i][0] << "; ";
                                                    }
                                                    cout << "\n";
                                                    for (size_t i = 0; i < variants.size(); i++)
                                                    {
                                                        cout << i << ": ";
                                                        cout << "[" << variants[i][0][2] << "] ";
                                                        for (size_t j = 0; j < variants[i].size() - 1; j++)
                                                        {
                                                            cout << variants[i][j][1] << " --> ";
                                                        }
                                                        cout << variants[i][variants[i].size() - 1][1];
                                                        cout << "\n";
                                                    }
                                                    cout << "\n";
                                                }

                                                //Вычисление оптимального пути
                                                i_min = 0;
                                                min = 0;
                                                k_hour = 0;
                                                k_line = 0;
                                                for (size_t i_v = 0; i_v < variants.size(); i_v++)
                                                {
                                                    sum = 0;
                                                    if (variants[i_v][0][2] == "1")
                                                    {
                                                        k_line++;
                                                        for (size_t j_v = 0; j_v < variants[i_v].size(); j_v++)
                                                        {

                                                            if (log)
                                                            {
                                                                cout << "\n *i_v: " << i_v << " j_v: " << j_v << "\tvariants[i_v][j_v][0]:\t" << variants[i_v][j_v][0];
                                                            }

                                                            for (size_t i = 0; i < map.size(); i++)
                                                            {
                                                                for (size_t j = 0; j < map[i].size(); j++)
                                                                {
                                                                    if (map[i][j][1] == variants[i_v][j_v][1] && map[i][j][0] == variants[i_v][j_v][0])
                                                                    {
                                                                        if (!(j_v == 0 && map[i][j][2] == "1") && !(j == map[i].size() - 1 && map[i][j][1] != map[v3][v4][1]))
                                                                        {
                                                                            if (j != 0 && j_v != 0)
                                                                            {
                                                                                if (map[i][j - 1][1] == variants[i_v][j_v - 1][1])
                                                                                {
                                                                                    if (log)
                                                                                    {
                                                                                        cout << "\n\n *map[i][j - 1][1]: " << map[i][j - 1][1];
                                                                                        cout << "\n *variants[i_v][j_v - 1][1]: " << variants[i_v][j_v - 1][1];
                                                                                    }
                                                                                    sum = sum + stof(map[i][j][3]);
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                sum = sum + stof(map[i][j][3]);
                                                                            }

                                                                            if (log)
                                                                            {
                                                                                cout << "\n\n *i: " << i << " j: " << j << "\tmap[i][j][0]:\t" << map[i][j][0];
                                                                                cout << "\n *variants[i_v][j_v][1]: " << variants[i_v][j_v][1];
                                                                                cout << "\n *sum: " << sum << " + " << map[i][j][3] << "\n\n";
                                                                            }

                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        variants[i_v].resize(variants[i_v].size() + 1);
                                                        variants[i_v][variants[i_v].size() - 1].resize(1);
                                                        variants[i_v][variants[i_v].size() - 1][0] = to_string(sum);
                                                        if (sum < min || k_line == 1)
                                                        {
                                                            min = sum;
                                                            i_min = i_v;
                                                        }
                                                    }
                                                }

                                                if (log)
                                                {
                                                    cout << "\n *min: " << min;
                                                }

                                                //Проверка на оптимальные маршруты с одинаковым временем
                                                p = false;
                                                for (size_t i = 0; i < variants.size(); i++)
                                                {
                                                    if (variants[i][0][2] == "1" && stof(variants[i][variants[i].size() - 1][0]) == min && i != i_min)
                                                    {
                                                        p = true;
                                                        break;
                                                    }

                                                }

                                                cout << "\n\n";
                                                if (p)
                                                {
                                                    cout << "Вам подойдут следующие маршруты:";
                                                    k_line = 0;
                                                }
                                                else
                                                {
                                                    cout << "Вам подойдёт следующий маршрут:";
                                                }
                                                cout << "\n";

                                                for (size_t i = 0; i < variants.size(); i++)
                                                {
                                                    if (variants[i][0][2] == "1" && stof(variants[i][variants[i].size() - 1][0]) == min)
                                                    {
                                                        if (p)
                                                        {
                                                            cout << "\nВариант " << ++k_line << " \n\n";
                                                        }
                                                        for (size_t j = 0; j < variants[i].size() - 2; j++)
                                                        {
                                                            cout << variants[i][j][1];
                                                            if (variants[i][j][0] != variants[i][j + 1][0])
                                                            {
                                                                cout << "\nПересадка на маршрут: " << variants[i][j + 1][0] << "\n";
                                                                cout << variants[i][j][1];
                                                            }
                                                            cout << " --> ";
                                                        }
                                                        cout << variants[i][variants[i].size() - 2][1];
                                                        cout << "\n";
                                                    }
                                                }

                                                if (min >= 60)
                                                {
                                                    k_hour = min / 60;
                                                    if ((int(min) % 60) == 0 && int(min) == min)
                                                    {
                                                        cout << "\nРасчётное время путешествия: " << k_hour << " ч.\n";
                                                    }
                                                    else
                                                    {
                                                        cout << "\nРасчётное время путешествия: " << k_hour << " ч. " << min - (k_hour * 60) << " мин.\n";
                                                    }
                                                }
                                                else
                                                {
                                                    cout << "\nРасчётное время путешествия: " << min << " мин.\n";
                                                }

                                                p = false;
                                                k_line = 0;
                                                k_point = 0;

                                                for (size_t i = 0; i < variants.size(); i++)
                                                {
                                                    if (variants[i][0][2] == "1" && stof(variants[i][variants[i].size() - 1][0]) != min)
                                                    {
                                                        p = true;
                                                        k_line++;
                                                    }
                                                }

                                                if (p)
                                                {
                                                    
                                                    k_hour = 0;
                                                    k_point = 0;

                                                    if (k_line == 1)
                                                    {
                                                        cout << "\n\nВы также можете рассмотреть следующий маршрут:\n";
                                                    }
                                                    else if (k_line > 1)
                                                    {
                                                        cout << "\n\nВы также можете рассмотреть следующие маршруты:\n";
                                                    }

                                                    for (size_t i = 0; i < variants.size(); i++)
                                                    {
                                                        if (variants[i][0][2] == "1" && stof(variants[i][variants[i].size() - 1][0]) != min)
                                                        {
                                                            if (k_line > 1)
                                                            {
                                                                cout << "\nВариант " << ++k_point << " \n\n";
                                                            }
                                                            for (size_t j = 0; j < variants[i].size() - 2; j++)
                                                            {
                                                                cout << variants[i][j][1];
                                                                if (variants[i][j][0] != variants[i][j + 1][0])
                                                                {
                                                                    cout << "\nПересадка на маршрут: " << variants[i][j + 1][0] << "\n";
                                                                    cout << variants[i][j][1];
                                                                }
                                                                cout << " --> ";
                                                            }
                                                            cout << variants[i][variants[i].size() - 2][1];
                                                            cout << "\n";
                                                            if (stof(variants[i][variants[i].size() - 1][0]) >= 60)
                                                            {
                                                                k_hour = stof(variants[i][variants[i].size() - 1][0]) / 60;
                                                                if ((int(stof(variants[i][variants[i].size() - 1][0])) % 60) == 0 && int(stof(variants[i][variants[i].size() - 1][0])) == stof(variants[i][variants[i].size() - 1][0]))
                                                                {
                                                                    cout << "\nРасчётное время путешествия: " << k_hour << " ч.\n";
                                                                }
                                                                else
                                                                {
                                                                    cout << "\nРасчётное время путешествия: " << k_hour << " ч. " << stof(variants[i][variants[i].size() - 1][0]) - (k_hour * 60) << " мин.\n";
                                                                }
                                                            }
                                                            else
                                                            {
                                                                cout << "\nРасчётное время путешествия: " << stof(variants[i][variants[i].size() - 1][0]) << " мин.\n";
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                cout << "\n\nВы уже находитесь на этой остановке.\n";
                                            }

                                            cout << "\n";

                                            v = -1;

                                            variants.clear();
                                            used.clear();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else if (v == 2) //Выбор маршрута
        {
            while (v1 == -1)
            {
                cout << "Редактор маршрутов\n\n";
                cout << "1. Изменить маршрут\n";
                cout << "2. Добавить маршрут\n";
                cout << "3. Удалить маршрут\n";
                cout << "\n0. Вернуться\n";
                cout << "\n> ";
                cin >> v1;
                if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                cout << "\n";
                v2 = -1;
                if (v1 == 1) // Изменить маршрут
                {
                    while (v2 == -1)
                    {
                        cout << "Изменение маршрута\n\n";
                        cout << "Выберите маршрут:\n\n";
                        for (size_t i = 0; i < map.size(); i++)
                        {
                            cout << i + 1 << ". " << map[i][0][0] << endl;
                        }
                        cout << "\n0. Вернуться";
                        cout << "\n\n> ";
                        cin >> v2;
                        if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                        cout << "\n";
                        v3 = -1;
                        if (v2 == 0)
                        {
                            v1 = -1;
                        }
                        else if (v2 > map.size() || v2 < 0)
                        {
                            cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                            v2 = -1;
                        }
                        else //Выбрали маршрут
                        {
                            v2--;
                            while (v3 == -1)
                            {
                                cout << "Текущий маршрут: " << map[v2][0][0] << "\n\n";
                                cout << "Выберите действие\n\n";
                                cout << "1. Изменить сведения остановки\n";
                                cout << "2. Добавить остановку\n";
                                cout << "3. Удалить остановку\n";
                                cout << "\n0. Вернуться\n";
                                cout << "\n> ";
                                cin >> v3;
                                if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                cout << "\n";
                                v4 = -1;
                                if (v3 == 1) //Изменить сведения остановки
                                {
                                    while (v4 == -1)
                                    {
                                        cout << "Выберите остановку:\n\n";
                                        for (size_t j = 0; j < map[v2].size(); j++)
                                        {
                                            cout << j + 1 << ". " << map[v2][j][1] << endl;
                                        }
                                        cout << "\n0. Вернуться\n";
                                        cout << "\n> ";
                                        cin >> v4;
                                        if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                        cout << "\n";
                                        v5 = -1;
                                        if (v4 == 0)
                                        {
                                            v3 = -1;
                                        }
                                        else if (v4 > map[v2].size() || v4 < 0)
                                        {
                                            cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                            v4 = -1;
                                        }
                                        else //Выбрали остановку
                                        {
                                            v4--;
                                            while (v5 == -1)
                                            {
                                                cout << "Текущая остановка: " << map[v2][v4][1];
                                                if (map[v2][v4][2] == "1")
                                                {
                                                    cout << " (конечная, " << map[v2][v4][3] << " мин.)";
                                                }
                                                else
                                                {
                                                    cout << " (" << map[v2][v4][3] << " мин.)";
                                                }
                                                cout << "\n\n";
                                                cout << "Выберите действие\n\n";
                                                if (map[v2][v4][2] == "1")
                                                {
                                                    cout << "1. Сделать остановку контрольной\n";
                                                }
                                                else
                                                {
                                                    cout << "1. Сделать остановку конечной\n";
                                                }
                                                cout << "2. Изменить название\\номер остановки\n";
                                                cout << "3. Изменить время остановки\n";
                                                cout << "\n0. Вернуться\n";
                                                cout << "\n> ";
                                                cin >> v5;
                                                if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                                if (v5 == 1) //Сделать остановку контрольной/конечной
                                                {
                                                    if (map[v2][v4][2] == "1")
                                                    {
                                                        map[v2][v4][2] = "0";
                                                    }
                                                    else
                                                    {
                                                        map[v2][v4][2] = "1";
                                                    }
                                                    save_map(map);
                                                    v5 = -1;
                                                }
                                                else if (v5 == 2) //Изменить название/номер остановки
                                                {
                                                    cout << "Введите новое имя\\номер: ";
                                                    getline(cin, buf);
                                                    getline(cin, buf);
                                                    if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                                    map[v2][v4][1] = buf;
                                                    save_map(map);
                                                    v5 = -1;
                                                }
                                                else if (v5 == 3) //Изменить время остановки
                                                {
                                                    cout << "Введите новое время в минутах: ";
                                                    cin >> f_buf;
                                                    if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                                    if (f_buf == int(f_buf))
                                                    {
                                                        map[v2][v4][3] = to_string(int(f_buf));
                                                    }
                                                    else
                                                    {
                                                        map[v2][v4][3] = to_string(f_buf);
                                                    }
                                                    save_map(map);
                                                    v5 = -1;
                                                }
                                                else if (v5 == 0) //Вернуться
                                                {
                                                    v4 = -1;
                                                }
                                                else if (v5 != -1)
                                                {
                                                    cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                                    v5 = -1;
                                                }
                                            }
                                        }
                                    }
                                }
                                else if (v3 == 2) //Добавить остановку
                                {
                                    while (v4 == -1)
                                    {
                                        cout << "Выберите действие:\n\n";
                                        cout << "1. Добавить остановку в конец\n";
                                        cout << "2. Добавить остановку после указанной\n";
                                        cout << "\n0. Вернуться\n";
                                        cout << "\n> ";
                                        cin >> v4;
                                        if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                        cout << "\n";
                                        v5 = -1;
                                        if (v4 == 0)
                                        {
                                            v3 = -1;
                                        }
                                        else if (v4 == 1) //Добавить остановку в конец
                                        {
                                            map[v2].resize(map[v2].size() + 1);
                                            map[v2][map[v2].size() - 1].resize(4);
                                            map[v2][map[v2].size() - 1][0] = v2;
                                            cout << "Введите название\\номер остановки: ";
                                            getline(cin, map[v2][map[v2].size() - 1][1]);
                                            getline(cin, map[v2][map[v2].size() - 1][1]);
                                            if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                            cout << "Данная остановка является конечной? (1 - да; 0 - нет)\n> ";
                                            cin >> buf;
                                            if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                            if (buf == "0" || buf == "1")
                                            {
                                                map[v2][map[v2].size() - 1][2] = buf;
                                            }
                                            else
                                            {
                                                map[v2].resize(map[v2].size() - 1);
                                                cout << "\nВы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                                cin.clear();
                                                v4 = -1;
                                            }
                                            cout << "Введите время, за которое можно добраться до остановки в минутах: ";
                                            cin >> map[v2][map[v2].size() - 1][3];
                                            if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                            save_map(map);
                                            v3 = -1;
                                            cout << "\n";
                                        }
                                        else if (v4 == 2) //Добавить остановку после указанной
                                        {
                                            while (v5 == -1)
                                            {
                                                cout << "Выберите остановку:\n\n";
                                                for (size_t j = 0; j < map[v2].size(); j++)
                                                {
                                                    cout << j + 1 << ". " << map[v2][j][1] << endl;
                                                }
                                                cout << "\n0. Вернуться\n";
                                                cout << "\n> ";
                                                cin >> v5;
                                                if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                                cout << "\n";
                                                if (v5 == 0)
                                                {
                                                    v5 = -1;
                                                }
                                                else if (v5 > map[v2].size() || v5 < 0)
                                                {
                                                    cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                                    v5 = -1;
                                                }
                                                else //Выбрали остановку
                                                {
                                                    v5--;
                                                    cout << "Текущая остановка: " << map[v2][v5][1];
                                                    if (map[v2][v5][2] == "1")
                                                    {
                                                        cout << " (конечная, " << map[v2][v5][3] << " мин.)";
                                                    }
                                                    else
                                                    {
                                                        cout << " (" << map[v2][v5][3] << " мин.)";
                                                    }
                                                    cout << "\n\n";

                                                    map[v2].resize(map[v2].size() + 1);
                                                    map[v2][map[v2].size() - 1].resize(4);

                                                    for (size_t j = map[v2].size() - 1; j > v5 + 1; j--)
                                                    {
                                                        map[v2][j][0] = map[v2][j - 1][0];
                                                        map[v2][j][1] = map[v2][j - 1][1];
                                                        map[v2][j][2] = map[v2][j - 1][2];
                                                        map[v2][j][3] = map[v2][j - 1][3];
                                                    }

                                                    cout << "Введите название\\номер остановки: ";
                                                    getline(cin, map[v2][v5 + 1][1]);
                                                    getline(cin, map[v2][v5 + 1][1]);
                                                    if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                                    cout << "Данная остановка является конечной? (1 - да; 0 - нет)\n> ";
                                                    cin >> buf;
                                                    if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                                    if (buf == "0" || buf == "1")
                                                    {
                                                        map[v2][v5 + 1][2] = buf;
                                                    }
                                                    else
                                                    {
                                                        for (size_t j = v5 + 1; j < map[v2].size() - 1; j++)
                                                        {
                                                            map[v2][j][0] = map[v2][j + 1][0];
                                                            map[v2][j][1] = map[v2][j + 1][1];
                                                            map[v2][j][2] = map[v2][j + 1][2];
                                                            map[v2][j][3] = map[v2][j + 1][3];
                                                        }
                                                        map[v2].resize(map[v2].size() - 1);
                                                        cout << "\nВы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                                        cin.clear();
                                                        v5 = -1;
                                                    }
                                                    cout << "Введите время, за которое можно добраться до остановки в минутах: ";
                                                    cin >> map[v2][v5 + 1][3];
                                                    if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                                    save_map(map);
                                                    v3 = -1;
                                                    cout << "\n";
                                                }
                                            }
                                        }
                                        else if (v4 != -1)
                                        {
                                            cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                            v4 = -1;
                                        }
                                    }
                                }
                                else if (v3 == 3) //Удалить остановку
                                {
                                    while (v4 == -1)
                                    {
                                        cout << "Выберите остановку:\n\n";
                                        for (size_t j = 0; j < map[v2].size(); j++)
                                        {
                                            cout << j + 1 << ". " << map[v2][j][1] << endl;
                                        }
                                        cout << "\n0. Вернуться\n";
                                        cout << "\n> ";
                                        cin >> v4;
                                        if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                        cout << "\n";
                                        if (v4 == 0)
                                        {
                                            v3 = -1;
                                        }
                                        else if (v4 > map[v2].size() || v4 < 0)
                                        {
                                            cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                            v4 = -1;
                                        }
                                        else //Выбрали остановку
                                        {
                                            v4--;
                                            for (size_t j = v4; j < map[v2].size() - 1; j++)
                                            {
                                                map[v2][j][0] = map[v2][j + 1][0];
                                                map[v2][j][1] = map[v2][j + 1][1];
                                                map[v2][j][2] = map[v2][j + 1][2];
                                                map[v2][j][3] = map[v2][j + 1][3];
                                            }
                                            map[v2].resize(map[v2].size() - 1);
                                            save_map(map);
                                            v3 = -1;
                                        }
                                    }
                                }
                                else if (v3 == 0) //Вернуться
                                {
                                    v2 = -1;
                                }
                                else if (v3 != -1)
                                {
                                    cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                    v3 = -1;
                                }
                            }
                        }
                    }
                }
                else if (v1 == 2) // Добавить маршрут
                {
                    while (v2 == -1)
                    {
                        cout << "Добавление нового маршрута\n\n";
                        cout << "1. Добавить маршрут в конец\n";
                        cout << "2. Добавить маршрут после указанного\n";
                        cout << "\n0. Вернуться\n";
                        cout << "\n> ";
                        cin >> v2;
                        if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                        cout << "\n";
                        if (v2 == 0)
                        {
                            v1 = -1;
                        }
                        else if (v2 == 1) //Добавить маршрут в конец
                        {
                            map.resize(map.size() + 1);
                            map[map.size() - 1].resize(1);
                            map[map.size() - 1][0].resize(4);
                            cout << "Введите название маршрута: ";
                            getline(cin, map[map.size() - 1][0][0]);
                            getline(cin, map[map.size() - 1][0][0]);
                            cout << "Введите название первой остановки: ";
                            getline(cin, map[map.size() - 1][0][1]);
                            cout << "Данная остановка является конечной? (1 - да; 0 - нет)\n> ";
                            cin >> buf;
                            if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                            if (buf == "0" || buf == "1")
                            {
                                map[map.size() - 1][0][2] = buf;
                            }
                            else
                            {
                                map[map.size() - 1].resize(map[map.size() - 1].size() - 1);
                                cout << "\nВы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                cin.clear();
                                v2 = -1;
                            }
                            cout << "Введите время, за которое можно добраться до остановки в минутах (если отсутствует введите -): ";
                            cin >> buf;
                            if (buf != "-")
                            {
                                map[map.size() - 1][0][3] = buf;
                            }
                            cout << "\n";
                            while (v3 == -1)
                            {
                                cout << "Текущий маршрут: " << map[map.size() - 1][0][0];
                                cout << "\n\nПуть: ";
                                for (size_t j = 0; j < map[map.size() - 1].size() - 1; j++)
                                {
                                    cout << map[map.size() - 1][j][1];

                                    if (map[map.size() - 1][j][2] == "1" && j != 0)
                                    {
                                        cout << " (конечная, ";
                                    }
                                    else
                                    {
                                        cout << " (";
                                    }
                                    
                                    if (map[map.size() - 1][j][3] == "")
                                    {
                                        cout << "- мин.) --> ";
                                    }
                                    else
                                    {
                                        cout << map[map.size() - 1][j][3] << " мин.) --> ";
                                    }
                                }
                                cout << map[map.size() - 1][map[map.size() - 1].size() - 1][1];
                                if (map[map.size() - 1][map[map.size() - 1].size() - 1][2] == "1")
                                {
                                    cout << " (конечная, ";
                                }
                                else
                                {
                                    cout << " (";
                                }

                                if (map[map.size() - 1][map[map.size() - 1].size() - 1][3] == "")
                                {
                                    cout << "- мин.)";
                                }
                                else
                                {
                                    cout << map[map.size() - 1][map[map.size() - 1].size() - 1][3] << " мин.)";
                                }

                                cout << "\n\n";
                                cout << "Выберите действие: \n\n";
                                cout << "1. Добавить остановку\n";
                                cout << "0. Закончить добавление остановок\n";
                                cout << "\n> ";
                                cin >> v3;
                                if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                cout << "\n";
                                if (v3 == 0)
                                {
                                    save_map(map);
                                    v = -1;
                                }
                                else if (v3 == 1)
                                {
                                    map[map.size() - 1].resize(map[map.size() - 1].size() + 1);
                                    map[map.size() - 1][map[map.size() - 1].size() - 1].resize(4);
                                    map[map.size() - 1][map[map.size() - 1].size() - 1][0] = map.size() - 1;
                                    cout << "Введите название\\номер остановки: ";
                                    getline(cin, map[map.size() - 1][map[map.size() - 1].size() - 1][1]);
                                    getline(cin, map[map.size() - 1][map[map.size() - 1].size() - 1][1]);
                                    if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                    cout << "Данная остановка является конечной? (1 - да; 0 - нет)\n> ";
                                    cin >> buf;
                                    if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                    if (buf == "0" || buf == "1")
                                    {
                                        map[map.size() - 1][map[map.size() - 1].size() - 1][2] = buf;
                                    }
                                    else
                                    {
                                        map[map.size() - 1].resize(map[map.size() - 1].size() - 1);
                                        cout << "\nВы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                        cin.clear();
                                        v3 = -1;
                                    }
                                    cout << "Введите время, за которое можно добраться до остановки в минутах: ";
                                    cin >> map[map.size() - 1][map[map.size() - 1].size() - 1][3];
                                    if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                    v3 = -1;
                                    cout << "\n";
                                }
                                else
                                {
                                    cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                    v3 = -1;
                                }
                            }

                        }
                        else if (v2 == 2) //Добавить маршрут после указанного
                        {
                            while (v3 == -1)
                            {
                                cout << "Выберите маршрут:\n\n";
                                for (size_t i = 0; i < map.size(); i++)
                                {
                                    cout << i + 1 << ". " << map[i][0][0] << endl;
                                }
                                cout << "\n0. Вернуться";
                                cout << "\n\n> ";
                                cin >> v3;
                                if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                cout << "\n";
                                v4 = -1;
                                if (v3 == 0)
                                {
                                    v2 = -1;
                                }
                                else if (v3 > map.size() || v3 < 0)
                                {
                                    cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                    v3 = -1;
                                }
                                else //Выбрали маршрут
                                {
                                    v3--;
                                    map.resize(map.size() + 1);
                                    for (size_t i = map.size() - 1; i > v3 + 1; i--)
                                    {
                                        map[i].resize(map[i - 1].size());
                                        for (size_t j = 0; j < map[i - 1].size(); j++)
                                        {
                                            map[i][j].resize(4);
                                            map[i][j][0] = map[i - 1][j][0];
                                            map[i][j][1] = map[i - 1][j][1];
                                            map[i][j][2] = map[i - 1][j][2];
                                            map[i][j][3] = map[i - 1][j][3];
                                        }
                                    }

                                    map[v3 + 1].resize(1);
                                    map[v3 + 1][0].resize(4);
                                    map[v3 + 1][0][0] = "";
                                    map[v3 + 1][0][1] = "";
                                    map[v3 + 1][0][2] = "";
                                    map[v3 + 1][0][3] = "";
                                    cout << "Введите название маршрута: ";
                                    getline(cin, map[v3 + 1][0][0]);
                                    getline(cin, map[v3 + 1][0][0]);
                                    cout << "Введите название первой остановки: ";
                                    getline(cin, map[v3 + 1][0][1]);
                                    cout << "Данная остановка является конечной? (1 - да; 0 - нет)\n> ";
                                    cin >> buf;
                                    if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                    if (buf == "0" || buf == "1")
                                    {
                                        map[v3 + 1][0][2] = buf;
                                    }
                                    else
                                    {
                                        map[v3 + 1].resize(map[v3 + 1].size() - 1);
                                        cout << "\nВы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                        cin.clear();
                                        v2 = -1;
                                    }
                                    cout << "Введите время, за которое можно добраться до остановки в минутах (если отсутствует введите -): ";
                                    cin >> buf;
                                    if (buf != "-")
                                    {
                                        map[v3 + 1][0][3] = buf;
                                    }
                                    cout << "\n";
                                    while (v4 == -1)
                                    {
                                        cout << "Текущий маршрут: " << map[v3 + 1][0][0];
                                        cout << "\n\nПуть: ";
                                        for (size_t j = 0; j < map[v3 + 1].size() - 1; j++)
                                        {
                                            cout << map[v3 + 1][j][1];

                                            if (map[v3 + 1][j][2] == "1" && j != 0)
                                            {
                                                cout << " (конечная, ";
                                            }
                                            else
                                            {
                                                cout << " (";
                                            }

                                            if (map[v3 + 1][j][3] == "")
                                            {
                                                cout << "- мин.) --> ";
                                            }
                                            else
                                            {
                                                cout << map[v3 + 1][j][3] << " мин.) --> ";
                                            }
                                        }
                                        cout << map[v3 + 1][map[v3 + 1].size() - 1][1];
                                        if (map[v3 + 1][map[v3 + 1].size() - 1][2] == "1")
                                        {
                                            cout << " (конечная, ";
                                        }
                                        else
                                        {
                                            cout << " (";
                                        }

                                        if (map[v3 + 1][map[v3 + 1].size() - 1][3] == "")
                                        {
                                            cout << "- мин.)";
                                        }
                                        else
                                        {
                                            cout << map[v3 + 1][map[v3 + 1].size() - 1][3] << " мин.)";
                                        }

                                        cout << "\n\n";
                                        cout << "Выберите действие: \n\n";
                                        cout << "1. Добавить остановку\n";
                                        cout << "0. Закончить добавление остановок\n";
                                        cout << "\n> ";
                                        cin >> v4;
                                        if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                        cout << "\n";
                                        if (v4 == 0)
                                        {
                                            save_map(map);
                                            v = -1;
                                        }
                                        else if (v4 == 1)
                                        {
                                            map[v3 + 1].resize(map[v3 + 1].size() + 1);
                                            map[v3 + 1][map[v3 + 1].size() - 1].resize(4);
                                            map[v3 + 1][map[v3 + 1].size() - 1][0] = v3 + 1;
                                            cout << "Введите название\\номер остановки: ";
                                            getline(cin, map[v3 + 1][map[v3 + 1].size() - 1][1]);
                                            getline(cin, map[v3 + 1][map[v3 + 1].size() - 1][1]);
                                            if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                            cout << "Данная остановка является конечной? (1 - да; 0 - нет)\n> ";
                                            cin >> buf;
                                            if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                            if (buf == "0" || buf == "1")
                                            {
                                                map[v3 + 1][map[v3 + 1].size() - 1][2] = buf;
                                            }
                                            else
                                            {
                                                map[v3 + 1].resize(map[v3 + 1].size() - 1);
                                                cout << "\nВы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                                cin.clear();
                                                v3 = -1;
                                            }
                                            cout << "Введите время, за которое можно добраться до остановки в минутах: ";
                                            cin >> map[v3 + 1][map[v3 + 1].size() - 1][3];
                                            if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                                            v4 = -1;
                                            cout << "\n";
                                        }
                                        else
                                        {
                                            cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                                            v4 = -1;
                                        }
                                    }
                                }
                            }
                        }
                        else if (v2 != -1)
                        {
                            cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                            v2 = -1;
                        }
                    }
                }
                else if (v1 == 3) // Удалить маршрут
                {
                    while (v2 == -1)
                    {
                        cout << "Выберите маршрут:\n\n";
                        for (size_t i = 0; i < map.size(); i++)
                        {
                            cout << i + 1 << ". " << map[i][0][0] << endl;
                        }
                        cout << "\n0. Вернуться";
                        cout << "\n\n> ";
                        cin >> v2;
                        if (cin.fail()) { cout << "Ошибка ввода! (Неверный тип данных)"; cin.clear(); n0(); return -1; };
                        cout << "\n";
                        v3 = -1;
                        if (v2 == 0)
                        {
                            v2 = -1;
                        }
                        else if (v2 > map.size() || v2 < 0)
                        {
                            cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                            v2 = -1;
                        }
                        else //Выбрали маршрут
                        {
                            v2--;
                            for (size_t i = v2; i < map.size() - 1; i++)
                            {
                                map[i].resize(map[i + 1].size());
                                for (size_t j = 0; j < map[i + 1].size(); j++)
                                {
                                    map[i][j].resize(4);
                                    map[i][j][0] = map[i + 1][j][0];
                                    map[i][j][1] = map[i + 1][j][1];
                                    map[i][j][2] = map[i + 1][j][2];
                                    map[i][j][3] = map[i + 1][j][3];
                                }
                            }
                            map.resize(map.size() - 1);
                            save_map(map);
                            v = -1;
                        }
                    }
                }
                else if (v1 == 0) // Вернуться
                {
                    v = -1;
                }
                else if (v1 != -1)
                {
                    cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
                    v1 = -1;
                }
            }
        }
        else if (v == 0) //Вернуться в главное меню
        {
            n0();
            return 0;
        }
        else if (v != -1)
        {
            cout << "Вы выбрали несуществующий вариант, пожалуйста попробуйте ещё раз!";
            v = -1;
        }
    }
    n0();
    return 0;
}
