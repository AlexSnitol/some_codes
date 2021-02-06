Imports Microsoft.Office.Interop
Imports System.Threading
Imports System.Drawing.Imaging

Public Class frm_index
    Dim pSize As Byte = 1
    Dim LoadingLabelInfo As String
    Dim LoadingLabelDescription As String
    Dim LoadingLabelDescriptionHead As String
    Dim LoadingLabelOptions As String
    Public ProgressValue As Integer = 0
    Public Progress100 As Boolean = False
    Dim iDisc As Integer = 0 'Номер текущей дисциплины в массиве с дисциплинами (в цикле)
    Dim iFindDisc As Integer = 0 'Номер подходящей пары для текущей дисциплины
    Dim i1Disc As Integer = 0 'Номер свободного места для дисциплины с 1-им часом после пройденной проверки
    Dim i2Disc As Integer = 0 'Номер для переноса дисциплины при проверке на занятость
    Dim jGroup As Integer = 0 'Переменная для внутреннего цикла с группами
    Dim j2Group As Integer = 0 'Переменная дла внутреннего цикла с группами
    Dim LineNumber As Integer = 0 'id выполняемой строки
    Public objAppWork As Excel.Application
    Public Th As System.Threading.Thread

    Sub ChangeLineNumber()
        frm_loading.LabelLineNumber.Visible = True
        frm_loading.LabelLineNumber.Text = "№ " & LineNumber
    End Sub

    Sub TimetableKRUProcess()

        'ВКЛЮЧЕНИЕ ВЫВОДА РАСПИСАНИЯ В ДИАЛОГОВОМ ОКНЕ
        Dim OnMsgBox As Boolean = False 'С комментариями
        Dim OnMsgBoxItog As Boolean = False 'Итоговое
        Dim OnMsgBoxCurrentGroup As Boolean = False 'Для пропуска сообщение по группе
        'ВКЛЮЧЕНИЕ ВЫВОДА РАСПИСАНИЯ В ДИАЛОГОВОМ ОКНЕ

        'ВКЛЮЧЕНИЕ ВЫВОДА РАСПИСАНИЯ В ТАБЛИЦЕ
        Dim RaspisaniePreview As Boolean = False
        'ВКЛЮЧЕНИЕ ВЫВОДА РАСПИСАНИЯ В ТАБЛИЦЕ

        Dim DetaledDesctiption As Boolean = False 'Вывод в область описания выполняемой задачи подробную информацию

        Dim ProverkaOnDisc As Boolean = False 'Запись используемой проверки для заполнения пары к дисциплине

        Dim ViewLineNumber As Boolean = False 'Вывод номера выполняемой строки
        LineNumber = 45
        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))

        If RaspisaniePreview = True Then
            frm_raspisanie_preview.Show()
            Me.Invoke(New ThreadStart(AddressOf LoadingActivate))
        End If

        Dim OutPut_iDisc As Boolean = False 'Вывод переменных iDisc, i1Disc, i2Disc, iFindDisc, jGroup, j2Group

        If OnMsgBox = True Or OnMsgBoxItog = True Or OnMsgBoxCurrentGroup = True Or OutPut_iDisc = True Or RaspisaniePreview = True Or ViewLineNumber = True Or ProverkaOnDisc = True Then
            LoadingLabelOptions = "Включены опции:"
            If OnMsgBox = True Then LoadingLabelOptions = LoadingLabelOptions & vbCrLf & " - Вывод распределения пар"
            If OnMsgBoxItog = True Then LoadingLabelOptions = LoadingLabelOptions & vbCrLf & " - Вывод расписания группы"
            If OnMsgBoxCurrentGroup = True Then LoadingLabelOptions = LoadingLabelOptions & vbCrLf & " - Пропуск вывода группы"
            If OutPut_iDisc = True Then LoadingLabelOptions = LoadingLabelOptions & vbCrLf & " - Вывод iDisc, i1Disc, i2Disc, iFindDisc," & vbCrLf & "jGroup, j2Group"
            If RaspisaniePreview = True Then LoadingLabelOptions = LoadingLabelOptions & vbCrLf & " - Предварительный просмотр расписания"
            If ViewLineNumber = True Then LoadingLabelOptions = LoadingLabelOptions & vbCrLf & " - Вывод номера выполняемой строки"
            If ProverkaOnDisc = True Then LoadingLabelOptions = LoadingLabelOptions & vbCrLf & " - Запись проверки в дисциплину"
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelOptionsChange))
        End If

        LoadingLabelInfo = "Идёт формирование расписания..."
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelInfoChange))
        LoadingLabelDescription = "Определение семестра"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
        LoadingLabelDescriptionHead = "Процесс формирования расписания"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionHeadChange))
        Me.Invoke(New ThreadStart(AddressOf TimerEnabled))
        Dim EXCELSemestr As String
        If Semestr = "1" Then EXCELSemestr = Me.EXCEL1Semestr.Text Else EXCELSemestr = Me.EXCEL2Semestr.Text

        CurrentProcess = "TimetableKRUProcess"
        ProgressValue = 0
        Progress100 = False
        Me.Invoke(New ThreadStart(AddressOf ProgressBarChange))
        sec = 0
        min = 0

        objAppWork = CreateObject("Excel.Application")
        Dim objBooksWork As Excel.Workbooks
        Dim objSheetsWork As Excel.Sheets
        Dim objSheetWork As Excel._Worksheet
        Dim objBookWork As Excel._Workbook
        FileExcel = Me.TextBoxExcelFile.Text

        LoadingLabelDescription = "Открытие документа"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
        Dim pError As Boolean = False
openfile: Try
            If pError = True Then Me.Invoke(New ThreadStart(AddressOf TimerEnabledDisabled))
            objBookWork = objAppWork.Workbooks.Open(FileExcel, ReadOnly:=True)
        Catch
            Me.Invoke(New ThreadStart(AddressOf TimerEnabledDisabled))
            If MsgBox("Ошибка чтения файла!" & vbCrLf & "Возможно файл не найден или занят другой программой.", 4117, "Расписание КРУ: Ошибка чтения файла!") = MsgBoxResult.Retry Then pError = True : GoTo openfile Else GoTo 0
        End Try
        objAppWork.Visible = False

        objSheetWork = objAppWork.Workbooks(1).Worksheets(ListExcel)

        Dim r As Integer = Me.EXCELFirstRow.Text 'Первая строчка с которой начинается выборка
        Dim r2 As Integer = 0 'Для внутренних циклов
        Erase Groups 'Массив с группами
        Dim kGroup As Integer 'Количество групп для добавления в расписание
        Dim SettingFile As String

        LoadingLabelDescription = "Проверка наличия групп"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
        Dim PresenceOfGroups As Boolean = False 'Наличие заранее распределённых групп 
        Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            reader.ReadLine() '[TimetableKRU]
            reader.ReadLine() 'FirstStart=
            reader.ReadLine() 'Welcome=
            reader.ReadLine() 'ExcelFile=
            reader.ReadLine() 'ExcelList=
            reader.ReadLine() 'ExcelListTeacher=
            reader.ReadLine() 'Semestr=
            reader.ReadLine() 'UsePassword=
            reader.ReadLine() 'Password=
            If Mid(reader.ReadLine(), 8, 1) <> "" Then PresenceOfGroups = True 'Groups=
            reader.Close()
        End Using
        If PresenceOfGroups = False Then
            Me.Invoke(New ThreadStart(AddressOf TimerEnabledDisabled))
            MsgBox("Список учебных групп ещё не создан." & vbCrLf & "Сейчас все имеющиеся группы будут собраны и отсортированы." & vbCrLf & "Для продолжения нажмите " & Chr(34) & "ОК" & Chr(34) & ".", MsgBoxStyle.Information, "Расписание КРУ: Выборка групп")
            LoadingLabelDescription = "Выборка учебных групп из документа"
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
            LoadingLabelDescriptionHead = "Отбор групп"
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionHeadChange))
            Dim pGroup As Boolean = False 'Проверка на добавление группы в расписание
            Do While objSheetWork.Range(Me.EXCELGroups.Text & r).Value <> ""
                If (objSheetWork.Range(Me.EXCELGroups.Text & r).Value <> objSheetWork.Range(Me.EXCELGroups.Text & r - 1).Value) Then pGroup = True
                If Not (objSheetWork.Range(EXCELSemestr & r).Value) = Nothing And pGroup = True Then kGroup = kGroup + 1 : pGroup = False
                r = r + 1
            Loop
            Erase Groups
            ReDim Preserve Groups(kGroup - 1)
            Dim nGroup As Integer = 0 'Порядковый номер группы
            iGroup = 0 'Порядковый номер группы для перебора
            Dim p1Group As Boolean = True 'Проверка на уникальность группы в массиве
            r = Me.EXCELFirstRow.Text
            Do While objSheetWork.Range(Me.EXCELGroups.Text & r).Value <> ""
                If (objSheetWork.Range(Me.EXCELGroups.Text & r).Value <> objSheetWork.Range(Me.EXCELGroups.Text & r - 1).Value) Then pGroup = True
                If Not (objSheetWork.Range(EXCELSemestr & r).Value) = Nothing And pGroup = True Then
                    For iGroup = 0 To Groups.GetUpperBound(0)
                        If Groups(iGroup) = objSheetWork.Range(Me.EXCELGroups.Text & r).Value Then p1Group = False : Exit For
                    Next
                    If p1Group = True Then Groups(nGroup) = objSheetWork.Range(Me.EXCELGroups.Text & r).Value : nGroup = nGroup + 1 : pGroup = False Else p1Group = True
                End If
                r = r + 1
            Loop
            ReDim Preserve Groups(nGroup - 1)
            Array.Sort(Groups)

            LoadingLabelDescription = "Сохранение выборки учебных групп из документа"
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'FirstStart=
                SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'Welcome=
                SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'ExcelFile=
                SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'ExcelList=
                SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'ExcelListTeacher=
                SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'Semestr=
                SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'UsePassword=
                SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'Password=
                SettingFile = SettingFile + vbCrLf + "Groups=" 'Groups=
                For iGroup = 0 To Groups.GetUpperBound(0)
                    SettingFile = SettingFile + Groups(iGroup) + "; "
                Next
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)

            For iGroup = 0 To Groups.GetUpperBound(0)
                frm_groups.ListBox1.Items.Add(Groups(iGroup))
            Next
            frm_groups.ButtonRefresh.Visible = False
            LoadingLabelDescription = "Ожидание распределения учебных групп пользователем"
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
            CurrentSubProcess = "Ожидание"
            Me.Invoke(New ThreadStart(AddressOf LoadingImageChange))
            Beep()
            If frm_groups.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Erase Groups
                ReDim Groups(frm_groups.ListBox1.Items.Count - 1)

                For iGroup = 0 To Groups.GetUpperBound(0)
                    Groups(iGroup) = frm_groups.ListBox1.Items(iGroup)
                Next

                Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                    SettingFile = reader.ReadLine() '[TimetableKRU]
                    SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'FirstStart=
                    SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'Welcome=
                    SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'ExcelFile=
                    SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'ExcelList=
                    SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'ExcelListTeacher=
                    SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'Semestr=
                    SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'UsePassword=
                    SettingFile = SettingFile + vbCrLf + reader.ReadLine() 'Password=
                    SettingFile = SettingFile + vbCrLf + "Groups=" 'Groups=
                    For iGroup = 0 To Groups.GetUpperBound(0)
                        SettingFile = SettingFile + Groups(iGroup) + "; "
                    Next
                    reader.ReadLine()
                    SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                    reader.Close()
                End Using
                IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)

            Else
                MsgBox("Значения выставлены по умолчанию!", MsgBoxStyle.Information, "Расписание КРУ: Значения по умолчанию")
            End If
            Me.Invoke(New ThreadStart(AddressOf TimerEnabledDisabled))
            CurrentSubProcess = ""
            Me.Invoke(New ThreadStart(AddressOf LoadingImageChange))
        End If

        LoadingLabelDescription = "Чтение сохранённых учебных групп и формирование массива"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
        kGroup = 0
        Dim GroupsRead As String
        Dim i1Sym As Integer = 1
        Dim i2Sym As Integer
        Dim pSym As Boolean = True
        Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            reader.ReadLine() '[TimetableKRU]
            reader.ReadLine() 'FirstStart=
            reader.ReadLine() 'Welcome=
            reader.ReadLine() 'ExcelFile=
            reader.ReadLine() 'ExcelList=
            reader.ReadLine() 'ExcelListTeacher=
            reader.ReadLine() 'Semestr=
            reader.ReadLine() 'UsePassword=
            reader.ReadLine() 'Password=
            GroupsRead = Mid(reader.ReadLine(), 8) 'Groups=
            For i2Sym = 1 To Len(GroupsRead)
                If Mid(GroupsRead, i2Sym, 1) = ";" Then pSym = True : i1Sym = i2Sym + 2
                If Mid(GroupsRead, i2Sym + 1, 1) = ";" And pSym = True Then pSym = False : kGroup = kGroup + 1
            Next
            reader.Close()
        End Using
        Erase Groups 'Обнуление массива
        ReDim Preserve Groups(kGroup - 1)
        kGroup = 0
        i1Sym = 1
        i2Sym = 0
        pSym = True 'Проверка по символу
        Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            reader.ReadLine() '[TimetableKRU]
            reader.ReadLine() 'FirstStart=
            reader.ReadLine() 'Welcome=
            reader.ReadLine() 'ExcelFile=
            reader.ReadLine() 'ExcelList=
            reader.ReadLine() 'ExcelListTeacher=
            reader.ReadLine() 'Semestr=
            reader.ReadLine() 'UsePassword=
            reader.ReadLine() 'Password=
            GroupsRead = Mid(reader.ReadLine(), 8) 'Groups=
            For i2Sym = 1 To Len(GroupsRead)
                If Mid(GroupsRead, i2Sym, 1) = ";" Then pSym = True : i1Sym = i2Sym + 2
                If Mid(GroupsRead, i2Sym + 1, 1) = ";" And pSym = True Then pSym = False : Groups(kGroup) = Mid(GroupsRead, i1Sym, i2Sym + 1 - i1Sym) : kGroup = kGroup + 1
            Next
            reader.Close()
        End Using

        Dim Raspisanie(119, Groups.GetUpperBound(0)) 'Массив с расписанием
        Dim Teachers(-1) 'Массив со всеми преподавателями
        Dim tmpDisc(-1, -1, -1) As String 'Временный массив с дисциплинами группы
        Dim tmpDiscRounding(-1, -1) As String 'Временный массив с дисциплинами и округлёнными часами
        Dim tmpp1Disc(-1) As String 'Временый массив с парами, в которых есть, либо только числитель, либо только знаменатель
        Dim tmpDiscRoundingSum As Integer 'Временная переменная для подстчёта суммы округлённых часов
        Dim tmppDiscRounding As Boolean = False 'Временная переменная для выполнения проверки после поиска дисциплин с делениями
        Dim tmpRaspisanieValue As String 'Временное место для хранения значения рассписания
        Dim tmpPrepod As String = "" 'Временное место для Фамилии И.О. преподавателя
        Dim tmpPrepod1 As String = "" 'Временное место для Фамилии И.О. первого преподавателя при делении
        Dim tmpPrepod2 As String = "" 'Временное место для Фамилии И.О. второго преподавателя при делении
        Dim Disc(-1, -1, -1) As String 'Временный массив с дисциплинами группы
        Dim kDisc As Integer = 50 'Количество диспицплин у группы
        Dim k1Disc As Integer = 0 'Количество пар со свободным часом
        Dim kUnevenDisc(-1) As Integer 'Количество дисциплин с нечётным количеством часов
        Dim kEvenDisc(-1) As Integer 'Количество дисциплин с чётным количеством часов
        Dim kTeacher As Integer = 0 'Количество преподавателей
        iDisc = 0 'Номер текущей дисциплины в массиве с дисциплинами (в цикле)
        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
        i1Disc = 0 'Номер свободного места для дисциплины с 1-им часом после пройденной проверки
        Dim i1_2Disc As Integer = 0 'Номер второго после i1Disc свободного места для дисциплины с 1-им часом после пройденной проверки
        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
        i2Disc = 0 'Номер для переноса дисциплины при проверке на занятость
        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
        Dim i4Disc As Integer = 90 'Номер 4 пар в расписании
        Dim itmpp1Disc As Integer = 0 'Номер в массиве с парами где есть свободный час
        Dim iTeacher As Integer = 0 'Номер в массиве с преподавателями
        Dim jDisc As Integer = 0 'Номер в массиве Raspisanie во внутреннем цикле
        Dim j3Group As Integer = 0 'Номер группы в массиве Group во внутреннем цикле
        Dim i0Disc As Integer = 0 'Номер текущей дисциплины для проверки p0Disc
        Dim itmpDisc As Integer = 0 'Временное хранилище iDisc
        Dim i1tmpDisc As Integer = 0 'Второе временное хранилище iDisc
        Dim iFind As Integer = 0 'Номер текущего символа в переборе
        iFindDisc = 0 'Номер подходящей пары для текущей дисциплины
        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIFindDiscChange))
        Dim i2FindDisc As Integer = 0 'Номер подходящей пары для текущей дисциплины для внутреннего цикла
        Dim i3FindDisc As Integer = 0 'Номер подходящей пары для текущей дисциплины для внутреннего цикла
        Dim iGroupDataGrid As Integer = -1 'Переменная для ограничения количества вывода групп в предпросмотр расписания
        Dim i3Index As Integer = 1 'Переменная для поиска символа - преподаватель
        Dim i4Index As Integer = 1 'Переменная для поиска символа - кабинет
        Dim NextIndexOf3 As Integer = 1 'Дополнительная переменная для поиска символа - преподаватель
        Dim NextIndexOf4 As Integer = 1 'Дополнительная переменная для поиска символа - кабинет
        Dim pDisc As Boolean = False 'Проверка на совпадение дисциплины в массиве дисциплин
        Dim p0Disc As Boolean = False 'Проверка на использование дисциплины в массиве рассписания текущей группы
        Dim p1Disc As Boolean = False 'Проверка на использование 1-го часа какой-либо дисциплины в массиве расписания
        Dim pFindDisc As Boolean = False 'Проверка на подходящую пару для заполнения
        Dim pLevelOne As Boolean = True 'Проверка на прохождение первого уровня проверки на занятость преподавателя
        Dim pLevelTwo As Boolean = True 'Проверка на прохождение второго уровня проверки на занятость преподавателя
        Dim pZan1Disc As Boolean = False 'Проверка на занятость первой пары
        Dim pZan2Disc As Boolean = False 'Проверка на занятость второй пары
        Dim p12Disc As Boolean = True 'Проверка на занятость i1Disc в i1_2Disc и i1_2Disc в i1Disc
        Dim rpDisc As Integer = 0 'Строчка текущей дисциплины в Excel
        Dim useDisc As Boolean = False 'Проверка на использование дисциплины в текущей операции цикла
        Dim CurrentDisc As Integer = 0 'Номер текущей дисциплины в массиве с дисциплинами
        Dim SelectDiscHour As Integer = 2 'Переменная для генератора выбора, какое количество часов распределять, имеет два значения: 1 и 2
        Dim SelectDiscPos As Integer = 1 'Переменная для генератора выбора позиции дисциплины с 1-им часом
        Dim SelectDisc As Integer = 1 'Переменная для выбора пары которую будем совмещать
        Dim RoundingFail As Boolean = False 'Переменная для проверки успешного округления
        jGroup = 0 'Переменная для внутреннего цикла с группами
        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
        j2Group = 0 'Переменная дла внутреннего цикла с группами
        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
        Dim nameDay As String = "" 'День недели
        Dim Proverka As String = "" 'Переменная для названия проверки
        Randomize()

        LoadingLabelDescription = "Чтение дисциплин из документа и формирование массива"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))

        'Выборка дисциплин для распределения часов
        CurrentSubProcess = "ВыборкаДисциплин"
        Me.Invoke(New ThreadStart(AddressOf LoadingImageChange))
        Erase tmpDiscipline
        Erase tmpDisciplineEdit
        Erase Disc
        Erase tmpDisc
        Erase kUnevenDisc
        Erase kEvenDisc
        ReDim tmpDiscipline(kDisc - 1, 4, Groups.GetUpperBound(0))
        ReDim tmpDisciplineEdit(kDisc - 1, 4, Groups.GetUpperBound(0))
        ReDim Disc(kDisc - 1, 1, Groups.GetUpperBound(0))
        ReDim tmpDisc(kDisc - 1, 1, Groups.GetUpperBound(0))
        ReDim kUnevenDisc(Groups.GetUpperBound(0))
        ReDim kEvenDisc(Groups.GetUpperBound(0))
        For iGroup = 0 To Groups.GetUpperBound(0)
            kDisc = 50
            r = Me.EXCELFirstRow.Text
            LoadingLabelDescriptionHead = "Обрабатывается " & iGroup + 1 & " группа из " & Groups.GetUpperBound(0) + 1 & ": " & Groups(iGroup)
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionHeadChange))
            LoadingLabelDescription = "Подсчёт количества дисциплин"
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
            frm_discipline.TabControlGroup.TabPages.Add(Groups(iGroup))
            kDisc = 0
            r = Me.EXCELFirstRow.Text
            Do While objSheetWork.Range(Me.EXCELGroups.Text & r).Value <> ""
                If (Groups(iGroup) = objSheetWork.Range(Me.EXCELGroups.Text & r).Value) And Not (objSheetWork.Range(EXCELSemestr & r).Value) = Nothing Then
                    LoadingLabelDescription = "Подготовка дисциплин для распределения"
                    Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                    tmpDiscipline(kDisc, 0, iGroup) = r
                    tmpDiscipline(kDisc, 1, iGroup) = objSheetWork.Range(EXCELPCK.Text & r).Value
                    If objSheetWork.Range(EXCELDisciplinesShort.Text & r).Value = Nothing Then tmpDiscipline(kDisc, 2, iGroup) = objSheetWork.Range(EXCELDisciplines.Text & r).Value Else tmpDiscipline(kDisc, 2, iGroup) = objSheetWork.Range(EXCELDisciplinesShort.Text & r).Value.ToString
                    tmpDiscipline(kDisc, 3, iGroup) = objSheetWork.Range(EXCELTeathers.Text & r).Value
                    tmpDiscipline(kDisc, 4, iGroup) = objSheetWork.Range(EXCELSemestr & r).Value
                    kDisc = kDisc + 1
                End If
                r = r + 1
            Loop
            For itmpDiscipline = 0 To kDisc - 1
                LoadingLabelDescription = "Подготовка дисциплин для распределения"
                Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                If iGroup = 0 Then
                    frm_discipline.DataGridView1.Rows.Add(1)
                    frm_discipline.DataGridView1.Rows(itmpDiscipline).Cells(0).Value = tmpDiscipline(itmpDiscipline, 0, iGroup)
                    frm_discipline.DataGridView1.Rows(itmpDiscipline).Cells(1).Value = tmpDiscipline(itmpDiscipline, 1, iGroup)
                    frm_discipline.DataGridView1.Rows(itmpDiscipline).Cells(2).Value = tmpDiscipline(itmpDiscipline, 2, iGroup)
                    frm_discipline.DataGridView1.Rows(itmpDiscipline).Cells(3).Value = tmpDiscipline(itmpDiscipline, 3, iGroup)
                    frm_discipline.DataGridView1.Rows(itmpDiscipline).Cells(4).Value = tmpDiscipline(itmpDiscipline, 4, iGroup)
                End If
                tmpDisciplineEdit(itmpDiscipline, 0, iGroup) = tmpDiscipline(itmpDiscipline, 0, iGroup)
                tmpDisciplineEdit(itmpDiscipline, 1, iGroup) = tmpDiscipline(itmpDiscipline, 1, iGroup)
                tmpDisciplineEdit(itmpDiscipline, 2, iGroup) = tmpDiscipline(itmpDiscipline, 2, iGroup)
                tmpDisciplineEdit(itmpDiscipline, 3, iGroup) = tmpDiscipline(itmpDiscipline, 3, iGroup)
                tmpDisciplineEdit(itmpDiscipline, 4, iGroup) = tmpDiscipline(itmpDiscipline, 4, iGroup)
            Next
            If Rounding = True Then
                LoadingLabelDescription = "Подготовка к округлению часов дисциплин"
                Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                tmpDiscRoundingSum = 0
                For itmpDisciplineEdit = 0 To tmpDisciplineEdit.GetUpperBound(0)
                    If tmpDisciplineEdit(itmpDisciplineEdit, 0, iGroup) = Nothing Then Exit For
                    tmpDiscRoundingSum = tmpDiscRoundingSum + CInt(tmpDisciplineEdit(itmpDisciplineEdit, 4, iGroup))
                    For jtmpDisciplineEdit = itmpDisciplineEdit + 1 To tmpDisciplineEdit.GetUpperBound(0)
                        If tmpDisciplineEdit(jtmpDisciplineEdit, 2, iGroup) = tmpDisciplineEdit(itmpDisciplineEdit, 2, iGroup) Or (tmpDisciplineEdit(jtmpDisciplineEdit, 1, iGroup) = Me.EXCELPCKForeignLang.Text And tmpDisciplineEdit(itmpDisciplineEdit, 1, iGroup) = Me.EXCELPCKForeignLang.Text) Then
                            tmpDiscRoundingSum = tmpDiscRoundingSum - CInt(tmpDisciplineEdit(jtmpDisciplineEdit, 4, iGroup))
                            Exit For
                        End If
                    Next
                Next
                If Me.Tag = "Округление по документу" Then
                    ReDim tmpDiscRounding(kDisc - 1, 1)
                    iDisc = 0
                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                    r = Me.EXCELFirstRow.Text
                    tmpDiscRoundingSum = 0
                    Do While objSheetWork.Range(Me.EXCELGroups.Text & r).Value <> ""
                        If (Groups(iGroup) = objSheetWork.Range(Me.EXCELGroups.Text & r).Value) And Not (objSheetWork.Range(EXCELSemestr & r).Value) = Nothing Then
                            r2 = Me.EXCELFirstRow.Text
                            tmppDiscRounding = False
                            If Not r = Me.EXCELFirstRow.Text Then
                                Do While objSheetWork.Range(Me.EXCELGroups.Text & r2).Value <> ""
                                    If (Groups(iGroup) = objSheetWork.Range(Me.EXCELGroups.Text & r2).Value) And Not (objSheetWork.Range(EXCELSemestr & r2).Value) = Nothing Then
                                        If (objSheetWork.Range(EXCELPCK.Text & r).Value = Me.EXCELPCKForeignLang.Text And objSheetWork.Range(EXCELPCK.Text & r).Value = objSheetWork.Range(EXCELPCK.Text & r2).Value) Or objSheetWork.Range(EXCELDisciplines.Text & r).Value = objSheetWork.Range(EXCELDisciplines.Text & r2).Value Then
                                            tmppDiscRounding = True
                                            Exit Do
                                        End If
                                    End If
                                    r2 = r2 + 1
                                    If r2 = r Then Exit Do
                                Loop
                            End If
                            If tmppDiscRounding = False Then tmpDiscRoundingSum = tmpDiscRoundingSum + CInt(objSheetWork.Range(EXCELSemestr & r).Value)
                        End If
                        r = r + 1
                    Loop
                End If
                r = Me.EXCELFirstRow.Text
                If tmpDiscRoundingSum = 36 Then
                    For itmpDisciplineEdit = 0 To kDisc - 1
                        tmpDisciplineEdit(itmpDisciplineEdit, 4, iGroup) = CInt(tmpDiscipline(itmpDisciplineEdit, 4, iGroup))
                    Next
                    If Me.Tag = "Document" Then
                        Do While objSheetWork.Range(Me.EXCELGroups.Text & r).Value <> ""
                            If (Groups(iGroup) = objSheetWork.Range(Me.EXCELGroups.Text & r).Value) And Not (objSheetWork.Range(EXCELSemestr & r).Value) = Nothing Then
                                If Not objSheetWork.Range(Me.EXCELDisciplinesShort.Text & r).Value = "" Then
                                    If Len(objSheetWork.Range(Me.EXCELDisciplinesShort.Text & r).Value) > 46 Then LoadingLabelDescription = "Округление часов дисциплины " & Mid(objSheetWork.Range(Me.EXCELDisciplinesShort.Text & r).Value, 1, 43) & "..." Else LoadingLabelDescription = "Округление часов дисциплины " & objSheetWork.Range(Me.EXCELDisciplinesShort.Text & r).Value
                                Else
                                    If Len(objSheetWork.Range(Me.EXCELDisciplines.Text & r).Value) > 46 Then LoadingLabelDescription = "Округление часов дисциплины " & Mid(objSheetWork.Range(Me.EXCELDisciplines.Text & r).Value, 1, 43) & "..." Else LoadingLabelDescription = "Округление часов дисциплины " & objSheetWork.Range(Me.EXCELDisciplines.Text & r).Value
                                End If
                                Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                tmpDiscRounding(iDisc, 0) = r
                                tmpDiscRounding(iDisc, 1) = CInt(objSheetWork.Range(EXCELSemestr & r).Value)
                                iDisc = iDisc + 1
                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                            End If
                            r = r + 1
                        Loop
                    End If
                Else
                    RoundingFail = True
                End If
            End If
            If Int((10 / (Groups.GetUpperBound(0) + 1))) = 0 Then ProgressValue = ProgressValue + 1 Else ProgressValue = ProgressValue + Int((10 / (Groups.GetUpperBound(0) + 1)))
            Me.Invoke(New ThreadStart(AddressOf ProgressBarChange))
        Next

        If (Rounding = True And RoundingFail = True) Or (Rounding = False And RoundingFail = False) Then
            LoadingLabelDescription = "Ожидание распределения часов пользователем"
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
            Me.Invoke(New ThreadStart(AddressOf TimerEnabledDisabled))
            frm_discipline.DataGridView1.Rows(0).Cells(4).Selected = True
            If (Groups.GetUpperBound(0) + 1) > 7 Then
                If Windows.Forms.Screen.PrimaryScreen.Bounds.Width < (599 + ((Groups.GetUpperBound(0) - 6) * 60)) Then
                    frm_discipline.WindowState = FormWindowState.Maximized
                Else
                    frm_discipline.Size = New Size(599 + ((Groups.GetUpperBound(0) - 6) * 60), 765)
                End If
            End If
            CurrentSubProcess = "Ожидание"
            Me.Invoke(New ThreadStart(AddressOf LoadingImageChange))
            Beep()
            If Not frm_discipline.ShowDialog() = Windows.Forms.DialogResult.OK Then MsgBox("Расписание не составлено!", MsgBoxStyle.Critical, "Расписание КРУ: Расписание не составлено!") : GoTo 0
            Me.Invoke(New ThreadStart(AddressOf TimerEnabledDisabled))
            CurrentSubProcess = "ВыборкаДисциплин"
            Me.Invoke(New ThreadStart(AddressOf LoadingImageChange))
            'Заполнение массива
            LoadingLabelDescription = "Начало формирования массива с дисциплинами"
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
        End If

        CurrentSubProcess = "ПроверкаНаПовторение"
        Me.Invoke(New ThreadStart(AddressOf LoadingImageChange))
        For iGroup = 0 To Groups.GetUpperBound(0)
            LoadingLabelDescriptionHead = "Обрабатывается " & iGroup + 1 & " группа из " & Groups.GetUpperBound(0) + 1 & ": " & Groups(iGroup)
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionHeadChange))

            kDisc = 0
            r = Me.EXCELFirstRow.Text
            LoadingLabelDescription = "Заполнение массива дисциплинами"
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))

            'Заполнение массива с дисциплинами для каждой группы
            If Me.Tag = "Document" Then
                Do While objSheetWork.Range(Me.EXCELGroups.Text & r).Value <> ""
                    If (Groups(iGroup) = objSheetWork.Range(Me.EXCELGroups.Text & r).Value) And Not (objSheetWork.Range(EXCELSemestr & r).Value) = Nothing Then
                        If Not objSheetWork.Range(Me.EXCELDisciplinesShort.Text & r).Value = "" Then
                            If Len(objSheetWork.Range(Me.EXCELDisciplinesShort.Text & r).Value) > 46 Then LoadingLabelDescription = "Проверка на повторение дисциплины " & Mid(objSheetWork.Range(Me.EXCELDisciplinesShort.Text & r).Value, 1, 43) & "... в массиве" Else LoadingLabelDescription = "Проверка на повторение дисциплины " & objSheetWork.Range(Me.EXCELDisciplinesShort.Text & r).Value & " в массиве"
                        Else
                            If Len(objSheetWork.Range(Me.EXCELDisciplines.Text & r).Value) > 46 Then LoadingLabelDescription = "Проверка на повторение дисциплины " & Mid(objSheetWork.Range(Me.EXCELDisciplines.Text & r).Value, 1, 43) & "... в массиве" Else LoadingLabelDescription = "Проверка на повторение дисциплины " & objSheetWork.Range(Me.EXCELDisciplines.Text & r).Value & " в массиве"
                        End If
                        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                        'Проверка на повторение дисциплины в массиве
                        For iDisc = 0 To tmpDisc.GetUpperBound(0)
                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                            If Not tmpDisc(iDisc, 0, iGroup) = Nothing Then
                                If Not tmpDisc(iDisc, 0, iGroup).IndexOf(r) = -1 Then
                                    For iFind = tmpDisc(iDisc, 0, iGroup).IndexOf(r) + 1 To Len(tmpDisc(iDisc, 0, iGroup))
                                        Try
                                            If Mid(tmpDisc(iDisc, 0, iGroup), iFind - 1, Len(r.ToString) + 1) = (" " & r.ToString) And Mid(tmpDisc(iDisc, 0, iGroup), iFind + Len(r.ToString), 1) = ";" Then pDisc = True
                                        Catch
                                            If Mid(tmpDisc(iDisc, 0, iGroup), iFind, Len(r.ToString) + 1) = (r.ToString & ";") Then pDisc = True
                                        End Try
                                    Next
                                End If
                            End If
                        Next
                        If pDisc = False Then
                            tmpDisc(kDisc, 0, iGroup) = r & "; "
                            For iDisc = 0 To tmpDisc.GetUpperBound(0)
                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                If tmpDisciplineEdit(iDisc, 0, iGroup) = Nothing Then Exit For
                                If tmpDisciplineEdit(iDisc, 0, iGroup) = r Then tmpDisc(kDisc, 1, iGroup) = tmpDisciplineEdit(iDisc, 4, iGroup)
                            Next
                            If Not objSheetWork.Range(Me.EXCELDisciplinesShort.Text & r).Value = "" Then
                                If Len(objSheetWork.Range(Me.EXCELDisciplinesShort.Text & r).Value) > 46 Then LoadingLabelDescription = "Проверка на повторение дисциплины " & Mid(objSheetWork.Range(Me.EXCELDisciplinesShort.Text & r).Value, 1, 43) & "... в документе" Else LoadingLabelDescription = "Проверка на повторение дисциплины " & objSheetWork.Range(Me.EXCELDisciplinesShort.Text & r).Value & " в документе"
                            Else
                                If Len(objSheetWork.Range(Me.EXCELDisciplines.Text & r).Value) > 46 Then LoadingLabelDescription = "Проверка на повторение дисциплины " & Mid(objSheetWork.Range(Me.EXCELDisciplines.Text & r).Value, 1, 43) & "... в документе" Else LoadingLabelDescription = "Проверка на повторение дисциплины " & objSheetWork.Range(Me.EXCELDisciplines.Text & r).Value & " в документе"
                            End If
                            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                            'Проверка на повторение дисциплины в Excel
                            rpDisc = r + 1
                            Try
                                Do While objSheetWork.Range(Me.EXCELGroups.Text & rpDisc).Value <> ""
                                    If (Groups(iGroup) = objSheetWork.Range(Me.EXCELGroups.Text & rpDisc).Value) And Not (objSheetWork.Range(EXCELSemestr & rpDisc).Value) = Nothing Then
                                        If (objSheetWork.Range(Me.EXCELDisciplines.Text & rpDisc).Value = objSheetWork.Range(Me.EXCELDisciplines.Text & r).Value) Or (objSheetWork.Range(Me.EXCELPCK.Text & r).Value = Me.EXCELPCKForeignLang.Text And objSheetWork.Range(Me.EXCELPCK.Text & rpDisc).Value = objSheetWork.Range(Me.EXCELPCK.Text & r).Value) Then
                                            tmpDisc(kDisc, 0, iGroup) = tmpDisc(kDisc, 0, iGroup) & rpDisc & "; "
                                        End If
                                    End If
                                    rpDisc = rpDisc + 1
                                Loop
                            Catch
                            End Try
                            kDisc = kDisc + 1
                        Else
                            pDisc = False
                        End If
                    End If
                    LoadingLabelDescription = "Поиск следующей дисциплины"
                    Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                    r = r + 1
                Loop
            Else
                For itmpDisciplineEdit = 0 To tmpDisciplineEdit.GetUpperBound(0)
                    If tmpDisciplineEdit(itmpDisciplineEdit, 0, iGroup) = Nothing Then Exit For
                    r = tmpDisciplineEdit(itmpDisciplineEdit, 0, iGroup)
                    LoadingLabelDescription = "Проверка дисциплин на деления по группам"
                    Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                    'Проверка на повторение дисциплины в массиве
                    For iDisc = 0 To tmpDisc.GetUpperBound(0)
                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                        If Not tmpDisc(iDisc, 0, iGroup) = Nothing Then
                            If Not tmpDisc(iDisc, 0, iGroup).IndexOf(r) = -1 Then
                                For iFind = tmpDisc(iDisc, 0, iGroup).IndexOf(r) + 1 To Len(tmpDisc(iDisc, 0, iGroup))
                                    Try
                                        If Mid(tmpDisc(iDisc, 0, iGroup), iFind - 1, Len(r.ToString) + 1) = (" " & r.ToString) And Mid(tmpDisc(iDisc, 0, iGroup), iFind + Len(r.ToString), 1) = ";" Then pDisc = True
                                    Catch
                                        If Mid(tmpDisc(iDisc, 0, iGroup), iFind, Len(r.ToString) + 1) = (r.ToString & ";") Then pDisc = True
                                    End Try
                                Next
                            End If
                        End If
                    Next
                    If pDisc = False Then
                        tmpDisc(kDisc, 0, iGroup) = r & "; "
                        For iDisc = 0 To tmpDisc.GetUpperBound(0)
                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                            If tmpDisciplineEdit(iDisc, 0, iGroup) = Nothing Then Exit For
                            If tmpDisciplineEdit(iDisc, 0, iGroup) = r Then tmpDisc(kDisc, 1, iGroup) = tmpDisciplineEdit(iDisc, 4, iGroup)
                        Next
                        'Проверка на повторение дисциплины в массиве
                        For jtmpDisciplineEdit = itmpDisciplineEdit + 1 To tmpDisciplineEdit.GetUpperBound(0)
                            If tmpDisciplineEdit(jtmpDisciplineEdit, 0, iGroup) = Nothing Then Exit For
                            rpDisc = tmpDisciplineEdit(jtmpDisciplineEdit, 0, iGroup)
                            If (objSheetWork.Range(Me.EXCELDisciplines.Text & rpDisc).Value = objSheetWork.Range(Me.EXCELDisciplines.Text & r).Value) Or (objSheetWork.Range(Me.EXCELPCK.Text & r).Value = Me.EXCELPCKForeignLang.Text And objSheetWork.Range(Me.EXCELPCK.Text & rpDisc).Value = objSheetWork.Range(Me.EXCELPCK.Text & r).Value) Then
                                tmpDisc(kDisc, 0, iGroup) = tmpDisc(kDisc, 0, iGroup) & rpDisc & "; "
                            End If
                        Next
                        kDisc = kDisc + 1
                    Else
                            pDisc = False
                    End If
                Next
            End If

            kEvenDisc(iGroup) = 0
            kUnevenDisc(iGroup) = 0
            LoadingLabelDescription = "Заполнение массива дисциплинами"
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
            For iDisc = 0 To Disc.GetUpperBound(0)
                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                If tmpDisc(iDisc, 0, iGroup) = Nothing Then Exit For
                Disc(iDisc, 0, iGroup) = tmpDisc(iDisc, 0, iGroup) 'Строка дисциплины в Excel
                Disc(iDisc, 1, iGroup) = tmpDisc(iDisc, 1, iGroup) 'Количество часов
                If Disc(iDisc, 1, iGroup) Mod 2 = 0 Then kEvenDisc(iGroup) = kEvenDisc(iGroup) + 1 'Счёт количества дисциплин с чётным количеством часов
                If Disc(iDisc, 1, iGroup) Mod 2 = 1 Then kUnevenDisc(iGroup) = kUnevenDisc(iGroup) + 1 'Счёт количества дисциплин с нечётным количеством часов
            Next
            If Int((10 / (Groups.GetUpperBound(0) + 1))) = 0 Then ProgressValue = ProgressValue + 1 Else ProgressValue = ProgressValue + Int((10 / (Groups.GetUpperBound(0) + 1)))
            Me.Invoke(New ThreadStart(AddressOf ProgressBarChange))
        Next

        'For iGroup = 0 To Groups.GetUpperBound(0)
        'MsgBox("Количество: " & Disc.GetUpperBound(0) + 1)
        'For iDisc = 0 To Disc.GetUpperBound(0)
        'MsgBox("Группа: " & Groups(iGroup) & vbCrLf & "Номер: " & iDisc + 1 & vbCrLf & "Дисциплина: " & Disc(iDisc, 0, iGroup) & vbCrLf & "Часов: " & Disc(iDisc, 1, iGroup))
        'Next
        'Next

        'Общий цикл заполнения расписания
        CurrentSubProcess = "ФормированиеРасписания"
        Me.Invoke(New ThreadStart(AddressOf LoadingImageChange))
        For iGroup = 0 To Groups.GetUpperBound(0)
            If RaspisaniePreview = True Then
                iGroupDataGrid = iGroupDataGrid + 1
                If iGroupDataGrid > 10 Then frm_raspisanie_preview.DataGridView1.Columns.Remove(frm_raspisanie_preview.DataGridView1.Columns(0).Name) : iGroupDataGrid = 10
                frm_raspisanie_preview.DataGridView1.Columns.Add(iGroupDataGrid, Groups(iGroup))
                If iGroupDataGrid = 0 Then frm_raspisanie_preview.DataGridView1.Rows.Add(24)
                For iDataGrid = 3 To 23 Step 4
                    frm_raspisanie_preview.DataGridView1.Rows(iDataGrid).Cells(iGroupDataGrid).Style.BackColor = Color.Gainsboro
                Next
            End If

            LoadingLabelDescriptionHead = "Обрабатывается " & iGroup + 1 & " группа из " & Groups.GetUpperBound(0) + 1 & ": " & Groups(iGroup)
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionHeadChange))
            LoadingLabelDescription = "Формирование массива расписания для текущей группы"
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))

            If OnMsgBox = True Then
                Beep()
                If MsgBox("Показывать сообщения для группы " & Groups(iGroup) & "?", 4100) = MsgBoxResult.Yes Then OnMsgBoxCurrentGroup = True Else OnMsgBoxCurrentGroup = False
            End If

            'Заполнение массива расписания дисциплинами текущей группы
            For iDisc = 0 To 85 Step 5
                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("iDisc начало: " & iDisc, 4096)

                'Первая генерация рандомной дисциплины
                CurrentDisc = CInt(Math.Ceiling(Rnd() * (Disc.GetUpperBound(0) + 1))) - 1

                p0Disc = True

                'Проверка: потрачены ли все часы дисциплин
                For i0Disc = 0 To Disc.GetUpperBound(0)
                    If Not Disc(i0Disc, 1, iGroup) = 0 Then p0Disc = False : Exit For
                Next

                'Выход из цикла, когда все дисциплины распределенны
                If p0Disc = True Then Exit For

                k1Disc = 0
                useDisc = False
                itmpDisc = iDisc
                p1Disc = False
                i2Disc = 0
                i4Disc = 0
                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                pLevelOne = True
                pLevelTwo = True
                Proverka = ""

                'Генератор рандомной дисциплины

                If kUnevenDisc(iGroup) = 0 Then
                    If Disc(CurrentDisc, 1, iGroup) = 0 Then
                        Do While Disc(CurrentDisc, 1, iGroup) = 0
                            CurrentDisc = CInt(Math.Ceiling(Rnd() * (Disc.GetUpperBound(0) + 1))) - 1
                        Loop
                    End If
                Else
                    If Disc(CurrentDisc, 1, iGroup) = 0 Or Disc(CurrentDisc, 1, iGroup) Mod 2 = 0 Then
                        Do While Disc(CurrentDisc, 1, iGroup) = 0 Or Disc(CurrentDisc, 1, iGroup) Mod 2 = 0
                            CurrentDisc = CInt(Math.Ceiling(Rnd() * (Disc.GetUpperBound(0) + 1))) - 1
                        Loop
                    End If
                End If

                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then
                    MsgBox("Сейчас буду распределять:" & vbCrLf & vbCrLf & "Дисциплина: " & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & vbCrLf & "Преподаватель: " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & vbCrLf & "Кол-во часов: " & Disc(CurrentDisc, 1, iGroup))
                End If

                LoadingLabelDescription = "Распределение дисциплины " & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))

                If RaspisaniePreview = True Then frm_raspisanie_preview.Label1.Text = "Сейчас распределяется:" & vbCrLf & "Дисциплина: " & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & vbCrLf & "Преподаватель: " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & vbCrLf & "Кол-во часов: " & Disc(CurrentDisc, 1, iGroup)

                'Распределение дисциплины с чётным количеством часов
                If Disc(CurrentDisc, 1, iGroup) Mod 2 = 0 Then

                    'Поиск свободной пары
                    If Not Raspisanie(iDisc + 1, iGroup) = Nothing Or Not Raspisanie(iDisc + 2, iGroup) = Nothing Or Not Raspisanie(iDisc, iGroup) = Nothing Then
                        If Not Raspisanie(iDisc, iGroup) = Nothing Then
                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0. Обнаружена основная дисциплина: " & Raspisanie(iDisc, iGroup), 4096)
                        End If
                        If Not Raspisanie(iDisc + 1, iGroup) = Nothing Then
                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0. Обнаружена дисциплина в числителе: " & Raspisanie(iDisc + 1, iGroup), 4096)
                        End If
                        If Not Raspisanie(iDisc + 2, iGroup) = Nothing Then
                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0. Обнаружена дисциплина в знаменателе: " & Raspisanie(iDisc + 2, iGroup), 4096)
                        End If
                        iDisc = 0
                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                        Do While Not Raspisanie(iDisc + 1, iGroup) = Nothing Or Not Raspisanie(iDisc + 2, iGroup) = Nothing Or Not Raspisanie(iDisc, iGroup) = Nothing
                            iDisc = iDisc + 5
                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                        Loop
                    End If

                    If Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") = Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") Then

                        If Not iGroup = 0 Then
                            'Проверяем занятость на текущей паре
                            For jGroup = 0 To iGroup - 1
                                LineNumber = 624
                                If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                If DetaledDesctiption = True Then
                                    Select Case (iDisc \ 15)
                                        Case 0
                                            nameDay = "понедельник"
                                        Case 1
                                            nameDay = "вторник"
                                        Case 2
                                            nameDay = "среду"
                                        Case 3
                                            nameDay = "четверг"
                                        Case 4
                                            nameDay = "пятницу"
                                        Case 5
                                            nameDay = "субботу"
                                    End Select
                                    LoadingLabelDescription = "Проверка на занятость преподавателя " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & " на " & ((iDisc / 5) - ((iDisc \ 15) * 3)) + 1 & " паре в " & nameDay
                                    Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                End If
                                'Если нашли преподавателя
                                If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                    If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                        iDisc = iDisc + 5
                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                        If Not iDisc > 85 Then
                                            'Поиск следующей свободной пары
                                            If Not Raspisanie(iDisc + 1, iGroup) = Nothing Or Not Raspisanie(iDisc + 2, iGroup) = Nothing Or Not Raspisanie(iDisc, iGroup) = Nothing Then
                                                If Not Raspisanie(iDisc, iGroup) = Nothing Then
                                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 1]. Обнаружена основная дисциплина: " & Raspisanie(iDisc, iGroup), 4096)
                                                End If
                                                If Not Raspisanie(iDisc + 1, iGroup) = Nothing Then
                                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 1]. Обнаружена дисциплина в числителе: " & Raspisanie(iDisc + 1, iGroup), 4096)
                                                End If
                                                If Not Raspisanie(iDisc + 2, iGroup) = Nothing Then
                                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 1]. Обнаружена дисциплина в знаменателе: " & Raspisanie(iDisc + 2, iGroup), 4096)
                                                End If
                                                Do While Not Raspisanie(iDisc + 1, iGroup) = Nothing Or Not Raspisanie(iDisc + 2, iGroup) = Nothing Or Not Raspisanie(iDisc, iGroup) = Nothing
                                                    iDisc = iDisc + 5
                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                    If iDisc > 85 Then
                                                        Exit Do
                                                    End If
                                                Loop
                                                If iDisc > 85 Then
                                                    pLevelOne = False
                                                    Exit For
                                                End If
                                            End If
                                        Else
                                            pLevelOne = False
                                            Exit For
                                        End If
                                        jGroup = -1
                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                    End If
                                End If
                            Next
                            'Если не удалось найти место среди свободных, ищем подходящее место независимо от занятости парами по текущей группы
                            If pLevelOne = False Then
                                iDisc = 0
                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 2]. Первая проверка не пройдена, ищем подходящую пару", 4096)
Link_pLevelOne:                 For jGroup = 0 To iGroup - 1
                                    LineNumber = 685
                                    If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                    If DetaledDesctiption = True Then
                                        Select Case (iDisc \ 15)
                                            Case 0
                                                nameDay = "понедельник"
                                            Case 1
                                                nameDay = "вторник"
                                            Case 2
                                                nameDay = "среду"
                                            Case 3
                                                nameDay = "четверг"
                                            Case 4
                                                nameDay = "пятницу"
                                            Case 5
                                                nameDay = "субботу"
                                        End Select
                                        LoadingLabelDescription = "Проверка на занятость преподавателя " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & " на " & ((iDisc / 5) - ((iDisc \ 15) * 3)) + 1 & " паре в " & nameDay
                                        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                    End If
                                    If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                        If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 2]. Нашёл преподавателя на паре под №" & iDisc & vbCrLf & "Перехожу к следующей и начинаю проверку сначала групп", 4096)
                                            iDisc = iDisc + 5
                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                            jGroup = -1
                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                            pLevelTwo = False
                                            'Если преподаватель занят во все дни на всех 3-х парах
                                            If iDisc > 85 Then
                                                'Ищем преподавателя на третьей паре
                                                For iFindDisc = 10 To 85 Step 15
                                                    For j2Group = 0 To iGroup - 1
                                                        If DetaledDesctiption = True Then
                                                            Select Case (iFindDisc \ 15)
                                                                Case 0
                                                                    nameDay = "понедельник"
                                                                Case 1
                                                                    nameDay = "вторник"
                                                                Case 2
                                                                    nameDay = "среду"
                                                                Case 3
                                                                    nameDay = "четверг"
                                                                Case 4
                                                                    nameDay = "пятницу"
                                                                Case 5
                                                                    nameDay = "субботу"
                                                            End Select
                                                            LoadingLabelDescription = "Проверка на занятость преподавателя " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & " на " & ((iFindDisc / 5) - ((iFindDisc \ 15) * 3)) + 1 & " паре в " & nameDay
                                                            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                                        End If
                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                                i4Disc = 90 + ((iFindDisc \ 15) * 5)
                                                                If Raspisanie(i4Disc + 3, iGroup) = Nothing Then
                                                                    'Проверяем на занятость преподавателя на 4 паре
                                                                    For j3Group = 0 To iGroup - 1
                                                                        If DetaledDesctiption = True Then
                                                                            Select Case (i4Disc \ 15)
                                                                                Case 0
                                                                                    nameDay = "понедельник"
                                                                                Case 1
                                                                                    nameDay = "вторник"
                                                                                Case 2
                                                                                    nameDay = "среду"
                                                                                Case 3
                                                                                    nameDay = "четверг"
                                                                                Case 4
                                                                                    nameDay = "пятницу"
                                                                                Case 5
                                                                                    nameDay = "субботу"
                                                                            End Select
                                                                            LoadingLabelDescription = "Проверка на занятость преподавателя " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & " на " & ((i4Disc / 5) - ((i4Disc \ 15) * 3)) + 1 & " паре в " & nameDay
                                                                            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                                                        End If
                                                                        If Not Raspisanie(i4Disc + 3, j3Group) = Nothing Then
                                                                            If Not Raspisanie(i4Disc + 3, j3Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                                                'Если преподаватель занят на 4 паре                                                                    
                                                                                iFindDisc = iFindDisc + 15
                                                                                j2Group = -1
                                                                                'Если преподаватель занят на всех 4 парах во все дни до субботы
                                                                                If iFindDisc = 85 Then
                                                                                    'Ищем где у преподавателя стоит 2-ая пара
                                                                                    iFindDisc = 5
                                                                                End If
                                                                                Exit For
                                                                            Else
                                                                                'Если преподаватель не занят на 4 паре 
                                                                                If j3Group = iGroup - 1 Then
                                                                                    iDisc = i4Disc
                                                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                                    GoTo Link_2_1_Raspisanie
                                                                                End If
                                                                            End If
                                                                        Else
                                                                            'Если преподаватель не занят на 4 паре 
                                                                            If j3Group = iGroup - 1 Then
                                                                                iDisc = i4Disc
                                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                                GoTo Link_2_1_Raspisanie
                                                                            End If
                                                                        End If
                                                                    Next
                                                                Else
                                                                    iFindDisc = iFindDisc + 15
                                                                    j2Group = -1
                                                                    If iFindDisc = 85 Then
                                                                        'Ищем где у преподавателя стоит 2-ая пара
                                                                        iFindDisc = 5
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    Next
                                                Next
                                            End If
                                        Else
                                            If jGroup = iGroup - 1 Then
                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                                If Raspisanie(iDisc + 1, iGroup) = Nothing And Raspisanie(iDisc + 2, iGroup) = Nothing Then
                                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 2]. Нашёл подходящую пару под №" & iDisc & vbCrLf & "Начинаю проверять на занятость пары", 4096)
                                                    pLevelTwo = True
                                                Else
                                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 2]. Нашёл подходящую пару под №" & iDisc & ", но она занята числителем и знаменателем" & vbCrLf & "Перехожу к следующей и начинаю проверку сначала групп", 4096)
                                                    iDisc = iDisc + 5
                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                    jGroup = -1
                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                                    pLevelTwo = False
                                                End If
                                            End If
                                        End If
                                    Else
                                        If jGroup = iGroup - 1 Then
                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                            If Raspisanie(iDisc + 1, iGroup) = Nothing And Raspisanie(iDisc + 2, iGroup) = Nothing Then
                                                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 2]. Нашёл подходящую пару под №" & iDisc & vbCrLf & "Начинаю проверять на занятость пары", 4096)
                                                pLevelTwo = True
                                            Else
                                                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 2]. Нашёл подходящую пару под №" & iDisc & ", но она занята числителем и знаменателем" & vbCrLf & "Перехожу к следующей и начинаю проверку сначала групп", 4096)
                                                iDisc = iDisc + 5
                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                jGroup = -1
                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                                pLevelTwo = False
                                            End If
                                        End If
                                    End If
                                Next
                                'Если подходящая пара занята, пробуем поменять местами
                                If pLevelTwo = True And Not Raspisanie(iDisc + 3, iGroup) = Nothing Then
                                    If Not Raspisanie(iDisc + 3, iGroup) = Nothing Then
                                        If Not Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " т.к. преподаватель этой пары такой же" & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                            iDisc = iDisc + 5
                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                            GoTo Link_pLevelOne
                                        End If
                                    End If
                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Пара под №" & iDisc & " занята" & vbCrLf & "Начинаю искать свободное место для этой пары, что бы её переместить", 4096)
                                    i2Disc = 0
                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                    'Поиск следующей свободной пары
                                    Do While Not Raspisanie(i2Disc + 1, iGroup) = Nothing Or Not Raspisanie(i2Disc + 2, iGroup) = Nothing Or Not Raspisanie(i2Disc, iGroup) = Nothing
                                        i2Disc = i2Disc + 5
                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                    Loop
                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Нашёл свободное место под №" & i2Disc & vbCrLf & "Начинаю проверять на занятость преподавателем", 4096)
                                    For jGroup = 0 To iGroup - 1
                                        LineNumber = 746
                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                        Select Case (i2Disc \ 15)
                                            Case 0
                                                nameDay = "понедельник"
                                            Case 1
                                                nameDay = "вторник"
                                            Case 2
                                                nameDay = "среду"
                                            Case 3
                                                nameDay = "четверг"
                                            Case 4
                                                nameDay = "пятницу"
                                            Case 5
                                                nameDay = "субботу"
                                        End Select
                                        'Если нет деления в паре которую хотим переместить
                                        If Raspisanie(iDisc, iGroup).ToString.IndexOf(";") = -1 Then
                                            If DetaledDesctiption = True Then
                                                LoadingLabelDescription = "Проверка на занятость преподавателя " & Raspisanie(iDisc + 3, iGroup) & " на " & ((i2Disc / 5) - ((i2Disc \ 15) * 3)) + 1 & " паре в " & nameDay
                                                Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                            End If
                                            If Not Raspisanie(i2Disc + 3, jGroup) = Nothing Then
                                                If Not Raspisanie(i2Disc + 3, jGroup).ToString.IndexOf(Raspisanie(iDisc + 3, iGroup)) = -1 Then
                                                    i2Disc = i2Disc + 5
                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                                    If i2Disc > 85 Then
                                                        If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                        iDisc = iDisc + 5
                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                        GoTo Link_pLevelOne
                                                    End If
                                                    If Not Raspisanie(i2Disc + 1, iGroup) = Nothing Or Not Raspisanie(i2Disc + 2, iGroup) = Nothing Or Not Raspisanie(i2Disc, iGroup) = Nothing Then
                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                                        If i2Disc > 85 Then
                                                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                            iDisc = iDisc + 5
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                            GoTo Link_pLevelOne
                                                        End If
                                                        Do While Not Raspisanie(i2Disc + 1, iGroup) = Nothing Or Not Raspisanie(i2Disc + 2, iGroup) = Nothing Or Not Raspisanie(i2Disc, iGroup) = Nothing
                                                            i2Disc = i2Disc + 5
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                                            If i2Disc > 85 Then
                                                                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                                iDisc = iDisc + 5
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                GoTo Link_pLevelOne
                                                            End If
                                                        Loop
                                                    Else
                                                        If jGroup = iGroup - 1 Then
                                                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                            iDisc = iDisc + 5
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                            GoTo Link_pLevelOne
                                                        End If
                                                    End If
                                                    jGroup = -1
                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                                End If
                                            End If
                                        Else 'Если есть деление в паре которую хотим переместить
                                            If DetaledDesctiption = True Then
                                                LoadingLabelDescription = "Проверка на занятость преподавателей " & Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";")) & " и " & Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 3, iGroup)) - (Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 4)) & " на " & ((i2Disc / 5) - ((i2Disc \ 15) * 3)) + 1 & " паре в " & nameDay
                                                Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                            End If
                                            If Not Raspisanie(i2Disc + 3, jGroup) = Nothing Then
                                                If Not Raspisanie(i2Disc + 3, jGroup).ToString.IndexOf(Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";"))) = -1 Or Not Raspisanie(i2Disc + 3, jGroup).ToString.IndexOf(Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 3, iGroup)) - (Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 4))) = -1 Then
                                                    i2Disc = i2Disc + 5
                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                                    If i2Disc > 85 Then
                                                        If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                        iDisc = iDisc + 5
                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                        GoTo Link_pLevelOne
                                                    End If
                                                    If Not Raspisanie(i2Disc + 1, iGroup) = Nothing Or Not Raspisanie(i2Disc + 2, iGroup) = Nothing Or Not Raspisanie(i2Disc, iGroup) = Nothing Then
                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                                        If i2Disc > 85 Then
                                                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                            iDisc = iDisc + 5
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                            GoTo Link_pLevelOne
                                                        End If
                                                        Do While Not Raspisanie(i2Disc + 1, iGroup) = Nothing Or Not Raspisanie(i2Disc + 2, iGroup) = Nothing Or Not Raspisanie(i2Disc, iGroup) = Nothing
                                                            i2Disc = i2Disc + 5
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                                            If i2Disc > 85 Then
                                                                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                                iDisc = iDisc + 5
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                GoTo Link_pLevelOne
                                                            End If
                                                        Loop
                                                    Else
                                                        If jGroup = iGroup - 1 Then
                                                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                            iDisc = iDisc + 5
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                            GoTo Link_pLevelOne
                                                        End If
                                                    End If
                                                    jGroup = -1
                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                                End If
                                            End If
                                        End If
                                    Next
                                    Raspisanie(i2Disc, iGroup) = Raspisanie(iDisc, iGroup)
                                    Raspisanie(iDisc, iGroup) = Nothing
                                    Raspisanie(i2Disc + 3, iGroup) = Raspisanie(iDisc + 3, iGroup)
                                    Raspisanie(iDisc + 3, iGroup) = Nothing
                                    Raspisanie(i2Disc + 4, iGroup) = Raspisanie(iDisc + 4, iGroup)
                                    Raspisanie(iDisc + 4, iGroup) = Nothing
                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Переместил пару №" & iDisc & " в пару под №" & i2Disc, 4096)
                                End If
                            End If
                        End If

Link_2_1_Raspisanie:    If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then Raspisanie(iDisc, iGroup) = objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value Else Raspisanie(iDisc, iGroup) = objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString
                        Raspisanie(iDisc + 3, iGroup) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                        Raspisanie(iDisc + 4, iGroup) = objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value

                    Else

                        If Not iGroup = 0 Then
                            For jGroup = 0 To iGroup - 1
                                LineNumber = 856
                                If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                Select Case (iDisc \ 15)
                                    Case 0
                                        nameDay = "понедельник"
                                    Case 1
                                        nameDay = "вторник"
                                    Case 2
                                        nameDay = "среду"
                                    Case 3
                                        nameDay = "четверг"
                                    Case 4
                                        nameDay = "пятницу"
                                    Case 5
                                        nameDay = "субботу"
                                End Select
                                If DetaledDesctiption = True Then
                                    LoadingLabelDescription = "Проверка на занятость преподавателей " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & " и " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value.ToString & " на " & ((iDisc / 5) - ((iDisc \ 15) * 3)) + 1 & " паре в " & nameDay
                                    Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                End If
                                If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                    If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Or Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value.ToString) = -1 Then
                                        iDisc = iDisc + 5
                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                        If Not iDisc > 85 Then
                                            'Поиск следующей свободной пары
                                            If Not Raspisanie(iDisc + 1, iGroup) = Nothing Or Not Raspisanie(iDisc + 2, iGroup) = Nothing Or Not Raspisanie(iDisc, iGroup) = Nothing Then
                                                If Not Raspisanie(iDisc, iGroup) = Nothing Then
                                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0. Обнаружена основная дисциплина: " & Raspisanie(iDisc, iGroup), 4096)
                                                End If
                                                If Not Raspisanie(iDisc + 1, iGroup) = Nothing Then
                                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0. Обнаружена дисциплина в числителе: " & Raspisanie(iDisc + 1, iGroup), 4096)
                                                End If
                                                If Not Raspisanie(iDisc + 2, iGroup) = Nothing Then
                                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0. Обнаружена дисциплина в знаменателе: " & Raspisanie(iDisc + 2, iGroup), 4096)
                                                End If
                                                Do While Not Raspisanie(iDisc + 1, iGroup) = Nothing Or Not Raspisanie(iDisc + 2, iGroup) = Nothing Or Not Raspisanie(iDisc, iGroup) = Nothing
                                                    iDisc = iDisc + 5
                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                    If iDisc > 85 Then
                                                        Exit Do
                                                    End If
                                                Loop
                                                If iDisc > 85 Then
                                                    pLevelOne = False
                                                    Exit For
                                                End If
                                            End If
                                        Else
                                            pLevelOne = False
                                            Exit For
                                        End If
                                        jGroup = -1
                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                    End If
                                End If
                            Next
                            'Если не удалось найти место среди свободных, ищем подходящее место независимо от занятости парами по текущей группы
                            If pLevelOne = False Then
                                iDisc = 0
                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 2]. Первая проверка не пройдена, ищем подходящую пару", 4096)
Link_pLevelOne_2:               For jGroup = 0 To iGroup - 1
                                    LineNumber = 916
                                    If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                    Select Case (iDisc \ 15)
                                        Case 0
                                            nameDay = "понедельник"
                                        Case 1
                                            nameDay = "вторник"
                                        Case 2
                                            nameDay = "среду"
                                        Case 3
                                            nameDay = "четверг"
                                        Case 4
                                            nameDay = "пятницу"
                                        Case 5
                                            nameDay = "субботу"
                                    End Select
                                    If DetaledDesctiption = True Then
                                        LoadingLabelDescription = "Проверка на занятость преподавателей " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & " и " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value.ToString & " на " & ((iDisc / 5) - ((iDisc \ 15) * 3)) + 1 & " паре в " & nameDay
                                        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                    End If
                                    If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                        If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Or Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value.ToString) = -1 Then
                                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 2]. Нашёл преподавателя на паре под №" & iDisc & vbCrLf & "Перехожу к следующей и начинаю проверку сначала групп", 4096)
                                            iDisc = iDisc + 5
                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                            jGroup = -1
                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                            pLevelTwo = False
                                            'Если преподаватель занят во все дни на всех 3-х парах
                                            If iDisc > 85 Then
                                                'Ищем преподавателя на третьей паре
                                                For iFindDisc = 10 To 85 Step 15
                                                    For j2Group = 0 To iGroup - 1
                                                        If DetaledDesctiption = True Then
                                                            Select Case (iFindDisc \ 15)
                                                                Case 0
                                                                    nameDay = "понедельник"
                                                                Case 1
                                                                    nameDay = "вторник"
                                                                Case 2
                                                                    nameDay = "среду"
                                                                Case 3
                                                                    nameDay = "четверг"
                                                                Case 4
                                                                    nameDay = "пятницу"
                                                                Case 5
                                                                    nameDay = "субботу"
                                                            End Select
                                                            LoadingLabelDescription = "Проверка на занятость преподавателя " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & " на " & ((iFindDisc / 5) - ((iFindDisc \ 15) * 3)) + 1 & " паре в " & nameDay
                                                            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                                        End If
                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value.ToString) = -1 Then
                                                                i4Disc = 90 + ((iFindDisc \ 15) * 5)
                                                                If Raspisanie(i4Disc + 3, iGroup) = Nothing Then
                                                                    'Проверяем на занятость преподавателя на 4 паре
                                                                    For j3Group = 0 To iGroup - 1
                                                                        If DetaledDesctiption = True Then
                                                                            Select Case (i4Disc \ 15)
                                                                                Case 0
                                                                                    nameDay = "понедельник"
                                                                                Case 1
                                                                                    nameDay = "вторник"
                                                                                Case 2
                                                                                    nameDay = "среду"
                                                                                Case 3
                                                                                    nameDay = "четверг"
                                                                                Case 4
                                                                                    nameDay = "пятницу"
                                                                                Case 5
                                                                                    nameDay = "субботу"
                                                                            End Select
                                                                            LoadingLabelDescription = "Проверка на занятость преподавателя " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & " на " & ((i4Disc / 5) - ((i4Disc \ 15) * 3)) + 1 & " паре в " & nameDay
                                                                            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                                                        End If
                                                                        If Not Raspisanie(i4Disc + 3, j3Group) = Nothing Then
                                                                            If Not Raspisanie(i4Disc + 3, j3Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Or Not Raspisanie(i4Disc + 3, j3Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value.ToString) = -1 Then
                                                                                'Если преподаватель занят на 4 паре                                                                    
                                                                                iFindDisc = iFindDisc + 15
                                                                                j2Group = -1
                                                                                'Если преподаватель занят на всех 4 парах во все дни до субботы
                                                                                If iFindDisc = 85 Then
                                                                                    'Ищем где у преподавателя стоит 2-ая пара
                                                                                    iFindDisc = 5
                                                                                End If
                                                                                Exit For
                                                                            Else
                                                                                'Если преподаватель не занят на 4 паре 
                                                                                If j3Group = iGroup - 1 Then
                                                                                    iDisc = i4Disc
                                                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                                    GoTo Link_2_2_Raspisanie
                                                                                End If
                                                                            End If
                                                                        Else
                                                                            'Если преподаватель не занят на 4 паре 
                                                                            If j3Group = iGroup - 1 Then
                                                                                iDisc = i4Disc
                                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                                GoTo Link_2_2_Raspisanie
                                                                            End If
                                                                        End If
                                                                    Next
                                                                Else
                                                                    'Если преподаватель занят на 4 паре                                                                    
                                                                    iFindDisc = iFindDisc + 15
                                                                    j2Group = -1
                                                                    If iFindDisc = 85 Then
                                                                        'Ищем где у преподавателя стоит 2-ая пара
                                                                        iFindDisc = 5
                                                                    End If
                                                                End If
                                                            End If
                                                        End If
                                                    Next
                                                Next
                                            End If
                                        Else
                                            If jGroup = iGroup - 1 Then
                                                If Raspisanie(iDisc + 1, iGroup) = Nothing And Raspisanie(iDisc + 2, iGroup) = Nothing Then
                                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 2]. Нашёл подходящую пару под №" & iDisc & vbCrLf & "Начинаю проверять на занятость пары", 4096)
                                                    pLevelTwo = True
                                                Else
                                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 2]. Нашёл подходящую пару под №" & iDisc & ", но она занята числителем и знаменателем" & vbCrLf & "Перехожу к следующей и начинаю проверку сначала групп", 4096)
                                                    iDisc = iDisc + 5
                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                    jGroup = -1
                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                                    pLevelTwo = False
                                                End If
                                            End If
                                        End If
                                    Else
                                        If jGroup = iGroup - 1 Then
                                            If Raspisanie(iDisc + 1, iGroup) = Nothing And Raspisanie(iDisc + 2, iGroup) = Nothing Then
                                                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 2]. Нашёл подходящую пару под №" & iDisc & vbCrLf & "Начинаю проверять на занятость пары", 4096)
                                                pLevelTwo = True
                                            Else
                                                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 2]. Нашёл подходящую пару под №" & iDisc & ", но она занята числителем и знаменателем" & vbCrLf & "Перехожу к следующей и начинаю проверку сначала групп", 4096)
                                                iDisc = iDisc + 5
                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                jGroup = -1
                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                                pLevelTwo = False
                                            End If
                                        End If
                                    End If
                                Next
                                'Если подходящая пара занята, пробуем поменять местами
                                If pLevelTwo = True And Not Raspisanie(iDisc + 3, iGroup) = Nothing Then
                                    If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                        If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 And Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value.ToString) = -1 Then
                                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " т.к. преподаватель этой пары такой же" & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                            iDisc = iDisc + 5
                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                            GoTo Link_pLevelOne_2
                                        End If
                                    End If
                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Пара под №" & iDisc & " занята" & vbCrLf & "Начинаю искать свободное место для этой пары, что бы её переместить", 4096)
                                    i2Disc = 0
                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                    'Поиск следующей свободной пары
                                    Do While Not Raspisanie(i2Disc + 1, iGroup) = Nothing Or Not Raspisanie(i2Disc + 2, iGroup) = Nothing Or Not Raspisanie(i2Disc, iGroup) = Nothing
                                        i2Disc = i2Disc + 5
                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                    Loop
                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Нашёл свободное место под №" & i2Disc & vbCrLf & "Начинаю проверять на занятость преподавателем", 4096)
                                    For jGroup = 0 To iGroup - 1
                                        LineNumber = 976
                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                        Select Case (i2Disc \ 15)
                                            Case 0
                                                nameDay = "понедельник"
                                            Case 1
                                                nameDay = "вторник"
                                            Case 2
                                                nameDay = "среду"
                                            Case 3
                                                nameDay = "четверг"
                                            Case 4
                                                nameDay = "пятницу"
                                            Case 5
                                                nameDay = "субботу"
                                        End Select
                                        'Если нет деления в паре которую хотим переместить
                                        If Raspisanie(iDisc, iGroup).ToString.IndexOf(";") = -1 Then
                                            If Not Raspisanie(i2Disc + 3, jGroup) = Nothing Then
                                                If Not Raspisanie(i2Disc + 3, jGroup).ToString.IndexOf(Raspisanie(iDisc + 3, iGroup)) = -1 Then
                                                    If DetaledDesctiption = True Then
                                                        LoadingLabelDescription = "Проверка на занятость преподавателя " & Raspisanie(iDisc + 3, iGroup) & " на " & ((i2Disc / 5) - ((i2Disc \ 15) * 3)) + 1 & " паре в " & nameDay
                                                        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                                    End If
                                                    i2Disc = i2Disc + 5
                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                                    If i2Disc > 85 Then
                                                        If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                        iDisc = iDisc + 5
                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                        GoTo Link_pLevelOne_2
                                                    End If
                                                    If Not Raspisanie(i2Disc + 1, iGroup) = Nothing Or Not Raspisanie(i2Disc + 2, iGroup) = Nothing Or Not Raspisanie(i2Disc, iGroup) = Nothing Then
                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                                        If i2Disc > 85 Then
                                                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                            iDisc = iDisc + 5
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                            GoTo Link_pLevelOne_2
                                                        End If
                                                        Do While Not Raspisanie(i2Disc + 1, iGroup) = Nothing Or Not Raspisanie(i2Disc + 2, iGroup) = Nothing Or Not Raspisanie(i2Disc, iGroup) = Nothing
                                                            i2Disc = i2Disc + 5
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                                            If i2Disc > 85 Then
                                                                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                                iDisc = iDisc + 5
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                GoTo Link_pLevelOne_2
                                                            End If
                                                        Loop
                                                    Else
                                                        If jGroup = iGroup - 1 Then
                                                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                            iDisc = iDisc + 5
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                            GoTo Link_pLevelOne_2
                                                        End If
                                                    End If
                                                    jGroup = -1
                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                                End If
                                            End If
                                        Else 'Если есть деление в паре которую хотим переместить
                                            If DetaledDesctiption = True Then
                                                LoadingLabelDescription = "Проверка на занятость преподавателей " & Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";")) & " и " & Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 3, iGroup)) - (Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 4)) & " на " & ((i2Disc / 5) - ((i2Disc \ 15) * 3)) + 1 & " паре в " & nameDay
                                                Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                            End If
                                            If Not Raspisanie(i2Disc + 3, jGroup) = Nothing Then
                                                If Not Raspisanie(i2Disc + 3, jGroup).ToString.IndexOf(Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";"))) = -1 Or Not Raspisanie(i2Disc + 3, jGroup).ToString.IndexOf(Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 3, iGroup)) - (Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 4))) = -1 Then
                                                    Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                                    i2Disc = i2Disc + 5
                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                                    If i2Disc > 85 Then
                                                        If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                        iDisc = iDisc + 5
                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                        GoTo Link_pLevelOne_2
                                                    End If
                                                    If Not Raspisanie(i2Disc + 1, iGroup) = Nothing Or Not Raspisanie(i2Disc + 2, iGroup) = Nothing Or Not Raspisanie(i2Disc, iGroup) = Nothing Then
                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                                        If i2Disc > 85 Then
                                                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                            iDisc = iDisc + 5
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                            GoTo Link_pLevelOne_2
                                                        End If
                                                        Do While Not Raspisanie(i2Disc + 1, iGroup) = Nothing Or Not Raspisanie(i2Disc + 2, iGroup) = Nothing Or Not Raspisanie(i2Disc, iGroup) = Nothing
                                                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                            i2Disc = i2Disc + 5
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI2DiscChange))
                                                            If i2Disc > 85 Then
                                                                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Не удалось переместить пару под №" & iDisc & " в пару под №" & i2Disc & vbCrLf & "Начинаю поиск следующей подходящей пары", 4096)
                                                                iDisc = iDisc + 5
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                GoTo Link_pLevelOne_2
                                                            End If
                                                        Loop
                                                    Else
                                                        If jGroup = iGroup - 1 Then
                                                            iDisc = iDisc + 5
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                            GoTo Link_pLevelOne_2
                                                        End If
                                                    End If
                                                    jGroup = -1
                                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                                End If
                                            End If
                                        End If
                                    Next
                                    Raspisanie(i2Disc, iGroup) = Raspisanie(iDisc, iGroup)
                                    Raspisanie(iDisc, iGroup) = Nothing
                                    Raspisanie(i2Disc + 3, iGroup) = Raspisanie(iDisc + 3, iGroup)
                                    Raspisanie(iDisc + 3, iGroup) = Nothing
                                    Raspisanie(i2Disc + 4, iGroup) = Raspisanie(iDisc + 4, iGroup)
                                    Raspisanie(iDisc + 4, iGroup) = Nothing
                                    If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("0.[Проверка 3]. Переместил пару №" & iDisc & " в пару под №" & i2Disc, 4096)
                                End If
                            End If
                        End If

Link_2_2_Raspisanie:    If Not objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then
                            Raspisanie(iDisc, iGroup) = objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                        Else
                            If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then Raspisanie(iDisc, iGroup) = objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value Else Raspisanie(iDisc, iGroup) = objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString
                        End If
                        If Not objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value = Nothing Then
                            Raspisanie(iDisc, iGroup) = Raspisanie(iDisc, iGroup) & "; " & objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; "
                        Else
                            If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value = Nothing Then Raspisanie(iDisc, iGroup) = Raspisanie(iDisc, iGroup) & "; " & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; " Else Raspisanie(iDisc, iGroup) = Raspisanie(iDisc, iGroup) & "; " & objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value.ToString & "; "
                        End If
                        Raspisanie(iDisc + 3, iGroup) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                        Raspisanie(iDisc + 3, iGroup) = Raspisanie(iDisc + 3, iGroup) & "; " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; "
                        Raspisanie(iDisc + 4, iGroup) = objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                        Raspisanie(iDisc + 4, iGroup) = Raspisanie(iDisc + 4, iGroup) & "; " & objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; "
                    End If
                    Disc(CurrentDisc, 1, iGroup) = Disc(CurrentDisc, 1, iGroup) - 2
                    kEvenDisc(iGroup) = kEvenDisc(iGroup) - 1
                    useDisc = True
                End If

                'Распределение дисциплины с нечётным количеством часов
                If useDisc = False And (Disc(CurrentDisc, 1, iGroup) Mod 2 = 1 And Not Disc(CurrentDisc, 1, iGroup) \ 2 = 0) Or ((Disc(CurrentDisc, 1, iGroup) Mod 2 = 1 And Disc(CurrentDisc, 1, iGroup) \ 2 = 0)) Then

                    p1Disc = False
                    pFindDisc = False

                    If Not iGroup = 0 Then
                        For jGroup = 0 To iGroup - 1
                            LineNumber = 1105
                            If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                            pFindDisc = False
                            tmpPrepod = Nothing
                            tmpPrepod1 = Nothing
                            tmpPrepod2 = Nothing
                            'Поиск подходящей пары (числитель, знаменатель), где наш текущий преподаватель занят
                            For iFindDisc = 0 To 85 Step 5
                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIFindDiscChange))
                                If DetaledDesctiption = True Then
                                    Select Case (iFindDisc \ 15)
                                        Case 0
                                            nameDay = "понедельник"
                                        Case 1
                                            nameDay = "вторник"
                                        Case 2
                                            nameDay = "среду"
                                        Case 3
                                            nameDay = "четверг"
                                        Case 4
                                            nameDay = "пятницу"
                                        Case 5
                                            nameDay = "субботу"
                                    End Select
                                End If
                                If Not Raspisanie(iFindDisc + 3, jGroup) = Nothing Then
                                    'Если только числитель и знаменатель
                                    If Raspisanie(iFindDisc, jGroup) = Nothing Then
                                        'Если нет деления по группам текущей дисциплины
                                        If Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") = Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") Then
                                            If DetaledDesctiption = True Then
                                                LoadingLabelDescription = "Проверка на занятость преподавателя " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & " на " & ((iFindDisc / 5) - ((iFindDisc \ 15) * 3)) + 1 & " паре в " & nameDay
                                                Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                            End If
                                            'Если есть преподаватель в найденной нами паре
                                            If Not Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                'Проверка на деление в числителе (в знаменателе не нужна)
                                                If Raspisanie(iFindDisc + 1, jGroup).ToString.IndexOf(";") = -1 Then
                                                    'Если числитель
                                                    If Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Then
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                            For j2Group = 0 To iGroup - 1
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                LineNumber = 1129
                                                                If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                If Not j2Group = jGroup Then
                                                                    'Если нашли преподавателя
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                                            pFindDisc = False
                                                                            Exit For
                                                                        End If
                                                                        'If j2Group = iGroup - 1 Then pFindDisc = True
                                                                    End If
                                                                End If
                                                                If j2Group = iGroup - 1 Then pFindDisc = True
                                                            Next
                                                        Else
                                                            pFindDisc = False
                                                        End If
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = False
                                                                iDisc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                SelectDiscPos = 2
                                                                Proverka = "[pFD-T-p1-F]"
                                                                Exit For
                                                            ElseIf Not Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                Exit For
                                                            ElseIf Raspisanie(iFindDisc + 1, iGroup) = Nothing And Not Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                'Пробуем поменять местами знаменатель с числителем
                                                                'Если нет деления по группам в знаменателе текущей группы
                                                                If Raspisanie(iFindDisc + 2, iGroup).ToString.IndexOf(";") = -1 Then
                                                                    tmpPrepod = Raspisanie(iFindDisc + 3, iGroup)
                                                                    'Проверка на занятость преподавателя в знаменателе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1161
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим знаменатель в числитель
                                                                        Raspisanie(iFindDisc + 1, iGroup) = "[Perenos1]" & Raspisanie(iFindDisc + 2, iGroup)
                                                                        Raspisanie(iFindDisc + 2, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Exit For
                                                                    End If
                                                                Else 'Если есть деление по группам в знаменателе текущей группы
                                                                    tmpPrepod1 = Mid(Raspisanie(iFindDisc + 3, iGroup), 1, Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";"))
                                                                    tmpPrepod2 = Mid(Raspisanie(iFindDisc + 3, iGroup), Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iFindDisc + 3, iGroup)) - (Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 4))
                                                                    'Проверка на занятость преподавателя в знаменателе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod1) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod2) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим знаменатель в числитель
                                                                        Raspisanie(iFindDisc + 1, iGroup) = "[Perenos1]" & Raspisanie(iFindDisc + 2, iGroup)
                                                                        Raspisanie(iFindDisc + 2, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Exit For
                                                                    End If
                                                                End If
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    Else 'Если знаменатель
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        For j2Group = 0 To iGroup - 1
                                                            LineNumber = 1214
                                                            If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                            If Not j2Group = jGroup Then
                                                                'Если нашли преподавателя
                                                                If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                                        pFindDisc = False
                                                                        Exit For
                                                                    End If
                                                                End If
                                                                'If j2Group = iGroup - 1 Then pFindDisc = True
                                                            End If
                                                            If j2Group = iGroup - 1 Then pFindDisc = True
                                                        Next
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = False
                                                                iDisc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                SelectDiscPos = 1
                                                                Proverka = "[pFD-T-p1-F]"
                                                                Exit For
                                                            ElseIf Not Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                'Пробуем поменять местами числитель с знаменателем
                                                                'Если нет деления по группам в числителе текущей группы
                                                                If Raspisanie(iFindDisc + 1, iGroup).ToString.IndexOf(";") = -1 Then
                                                                    tmpPrepod = Raspisanie(iFindDisc + 3, iGroup)
                                                                    'Проверка на занятость преподавателя в числителе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1241
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим числитель в знаменатель
                                                                        Raspisanie(iFindDisc + 2, iGroup) = "[Perenos2]" & Raspisanie(iFindDisc + 1, iGroup)
                                                                        Raspisanie(iFindDisc + 1, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Exit For
                                                                    End If
                                                                Else 'Если есть деление по группам в числителе текущей группы
                                                                    tmpPrepod1 = Mid(Raspisanie(iFindDisc + 3, iGroup), 1, Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";"))
                                                                    tmpPrepod2 = Mid(Raspisanie(iFindDisc + 3, iGroup), Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iFindDisc + 3, iGroup)) - (Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 4))
                                                                    'Проверка на занятость преподавателя в числителе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1266
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod1) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod2) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим числитель в знаменатель
                                                                        Raspisanie(iFindDisc + 2, iGroup) = "[Perenos2]" & Raspisanie(iFindDisc + 1, iGroup)
                                                                        Raspisanie(iFindDisc + 1, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Exit For
                                                                    End If
                                                                End If
                                                            ElseIf Raspisanie(iFindDisc + 1, iGroup) = Nothing And Not Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                Exit For
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    End If
                                                Else 'Если есть деление в числителе
                                                    'Если числитель
                                                    NextIndexOf3 = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2
                                                    For i3Index = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(iFindDisc + 3, jGroup))
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), i3Index, 1).ToString = ";" Then NextIndexOf3 = i3Index : Exit For
                                                    Next
                                                    If Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Or Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Then
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), (NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) + 2).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                            For j2Group = 0 To iGroup - 1
                                                                LineNumber = 1308
                                                                If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                If Not j2Group = jGroup Then
                                                                    'Если нашли преподавателя
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                                            pFindDisc = False
                                                                            Exit For
                                                                        End If
                                                                    End If
                                                                    'If j2Group = iGroup - 1 Then pFindDisc = True
                                                                End If
                                                                If j2Group = iGroup - 1 Then pFindDisc = True
                                                            Next
                                                        Else
                                                            pFindDisc = False
                                                        End If
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = False
                                                                iDisc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                SelectDiscPos = 2
                                                                Proverka = "[pFD-T-p1-F]"
                                                                Exit For
                                                            ElseIf Not Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                Exit For
                                                            ElseIf Raspisanie(iFindDisc + 1, iGroup) = Nothing And Not Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                'Пробуем поменять местами знаменатель с числителем
                                                                'Если нет деления по группам в знаменателе текущей группы
                                                                If Raspisanie(iFindDisc + 2, iGroup).ToString.IndexOf(";") = -1 Then
                                                                    tmpPrepod = Raspisanie(iFindDisc + 3, iGroup)
                                                                    'Проверка на занятость преподавателя в знаменателе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1340
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим знаменатель в числитель
                                                                        Raspisanie(iFindDisc + 1, iGroup) = "[Perenos3]" & Raspisanie(iFindDisc + 2, iGroup)
                                                                        Raspisanie(iFindDisc + 2, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        Exit For
                                                                    End If
                                                                Else 'Если есть деление по группам в знаменателе текущей группы
                                                                    tmpPrepod1 = Mid(Raspisanie(iFindDisc + 3, iGroup), 1, Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";"))
                                                                    tmpPrepod2 = Mid(Raspisanie(iFindDisc + 3, iGroup), Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iFindDisc + 3, iGroup)) - (Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 4))
                                                                    'Проверка на занятость преподавателя в знаменателе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1365
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod1) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod2) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим знаменатель в числитель
                                                                        Raspisanie(iFindDisc + 1, iGroup) = "[Perenos3]" & Raspisanie(iFindDisc + 2, iGroup)
                                                                        Raspisanie(iFindDisc + 2, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        Exit For
                                                                    End If
                                                                End If
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    Else 'Если знаменатель
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        For j2Group = 0 To iGroup - 1
                                                            LineNumber = 1395
                                                            If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                            If Not j2Group = jGroup Then
                                                                'Если нашли преподавателя
                                                                If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                                        pFindDisc = False
                                                                        Exit For
                                                                    End If
                                                                End If
                                                                'If j2Group = iGroup - 1 Then pFindDisc = True
                                                            End If
                                                            If j2Group = iGroup - 1 Then pFindDisc = True
                                                        Next
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = False
                                                                iDisc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                SelectDiscPos = 1
                                                                Proverka = "[pFD-T-p1-F]"
                                                                Exit For
                                                            ElseIf Not Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                'Пробуем поменять местами числитель с знаменателем
                                                                'Если нет деления по группам в числителе текущей группы
                                                                If Raspisanie(iFindDisc + 1, iGroup).ToString.IndexOf(";") = -1 Then
                                                                    tmpPrepod = Raspisanie(iFindDisc + 3, iGroup)
                                                                    'Проверка на занятость преподавателя в числителе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1422
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим числитель в знаменатель
                                                                        Raspisanie(iFindDisc + 2, iGroup) = "[Perenos4]" & Raspisanie(iFindDisc + 1, iGroup)
                                                                        Raspisanie(iFindDisc + 1, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        Exit For
                                                                    End If
                                                                Else 'Если есть деление по группам в числителе текущей группы
                                                                    tmpPrepod1 = Mid(Raspisanie(iFindDisc + 3, iGroup), 1, Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";"))
                                                                    tmpPrepod2 = Mid(Raspisanie(iFindDisc + 3, iGroup), Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iFindDisc + 3, iGroup)) - (Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 4))
                                                                    'Проверка на занятость преподавателя в числителе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1447
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod1) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod2) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим числитель в знаменатель
                                                                        Raspisanie(iFindDisc + 2, iGroup) = "[Perenos4]" & Raspisanie(iFindDisc + 1, iGroup)
                                                                        Raspisanie(iFindDisc + 1, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        Exit For
                                                                    End If
                                                                End If
                                                            ElseIf Raspisanie(iFindDisc + 1, iGroup) = Nothing And Not Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                Exit For
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Else 'Если есть деление по группам текущей дисциплины
                                            If DetaledDesctiption = True Then
                                                LoadingLabelDescription = "Проверка на занятость преподавателей " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & " и " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & " на " & ((iFindDisc / 5) - ((iFindDisc \ 15) * 3)) + 1 & " паре в " & nameDay
                                                Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                            End If
                                            'Если есть преподаватели в найденной нами паре
                                            If Not Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 And Not Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then
                                                'Проверка на деление в числителе и в знаменателе
                                                If Not Raspisanie(iFindDisc + 1, jGroup).ToString.IndexOf(";") = -1 And Raspisanie(iFindDisc + 2, jGroup).ToString.IndexOf(";") = -1 Then
                                                    'Если числитель
                                                    NextIndexOf3 = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2
                                                    For i3Index = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(iFindDisc + 3, jGroup))
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), i3Index, 1).ToString = ";" Then NextIndexOf3 = i3Index : Exit For
                                                    Next
                                                    If (Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Or Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) And (Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Or Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) Then
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3) + 2).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 And Mid(Raspisanie(iFindDisc + 3, jGroup), NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3) + 2).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then
                                                            For j2Group = 0 To iGroup - 1
                                                                LineNumber = 1498
                                                                If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                If Not j2Group = jGroup Then
                                                                    'Если нашли преподавателя
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then
                                                                            pFindDisc = False
                                                                            Exit For
                                                                        End If
                                                                    End If
                                                                    'If j2Group = iGroup - 1 Then pFindDisc = True
                                                                End If
                                                                If j2Group = iGroup - 1 Then pFindDisc = True
                                                            Next
                                                        Else
                                                            pFindDisc = False
                                                        End If
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = False
                                                                iDisc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                SelectDiscPos = 2
                                                                Proverka = "[pFD-T-p1-F]"
                                                                Exit For
                                                            ElseIf Not Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                Exit For
                                                            ElseIf Raspisanie(iFindDisc + 1, iGroup) = Nothing And Not Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                'Пробуем поменять местами знаменатель с числителем
                                                                'Если нет деления по группам в знаменателе текущей группы
                                                                If Raspisanie(iFindDisc + 2, iGroup).ToString.IndexOf(";") = -1 Then
                                                                    tmpPrepod = Raspisanie(iFindDisc + 3, iGroup)
                                                                    'Проверка на занятость преподавателя в знаменателе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1529
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим знаменатель в числитель
                                                                        Raspisanie(iFindDisc + 1, iGroup) = "[Perenos6]" & Raspisanie(iFindDisc + 2, iGroup)
                                                                        Raspisanie(iFindDisc + 2, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        Exit For
                                                                    End If
                                                                Else 'Если есть деление по группам в знаменателе текущей группы
                                                                    tmpPrepod1 = Mid(Raspisanie(iFindDisc + 3, iGroup), 1, Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";"))
                                                                    tmpPrepod2 = Mid(Raspisanie(iFindDisc + 3, iGroup), Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iFindDisc + 3, iGroup)) - (Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 4))
                                                                    'Проверка на занятость преподавателя в знаменателе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1554
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod1) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod2) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим знаменатель в числитель
                                                                        Raspisanie(iFindDisc + 1, iGroup) = "[Perenos6]" & Raspisanie(iFindDisc + 2, iGroup)
                                                                        Raspisanie(iFindDisc + 2, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        Exit For
                                                                    End If
                                                                End If
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    End If
                                                ElseIf Raspisanie(iFindDisc + 1, jGroup).ToString.IndexOf(";") = -1 And Not Raspisanie(iFindDisc + 2, jGroup).ToString.IndexOf(";") = -1 Then 'Если есть деление только в знаменателе
                                                    'Если знаменатель
                                                    NextIndexOf3 = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2
                                                    For i3Index = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(iFindDisc + 3, jGroup))
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), i3Index, 1).ToString = ";" Then NextIndexOf3 = i3Index : Exit For
                                                    Next
                                                    If (Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Or Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) And (Mid(Raspisanie(iFindDisc + 3, jGroup), NextIndexOf3 + 2, Len(Raspisanie(iFindDisc + 3, jGroup)) - (NextIndexOf3 + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Or Mid(Raspisanie(iFindDisc + 3, jGroup), NextIndexOf3 + 2, Len(Raspisanie(iFindDisc + 3, jGroup)) - (NextIndexOf3 + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) Then
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        If Not Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString And Not Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value Then
                                                            For j2Group = 0 To iGroup - 1
                                                                LineNumber = 1591
                                                                If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                If Not j2Group = jGroup Then
                                                                    'Если нашли преподавателя
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then
                                                                            pFindDisc = False
                                                                            Exit For
                                                                        End If
                                                                    End If
                                                                    'If j2Group = iGroup - 1 Then pFindDisc = True
                                                                End If
                                                                If j2Group = iGroup - 1 Then pFindDisc = True
                                                            Next
                                                        Else
                                                            pFindDisc = False
                                                        End If
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = False
                                                                iDisc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                SelectDiscPos = 1
                                                                Proverka = "[pFD-T-p1-F]"
                                                                Exit For
                                                            ElseIf Not Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                'Пробуем поменять местами числитель с знаменателем
                                                                'Если нет деления по группам в числителе текущей группы
                                                                If Raspisanie(iFindDisc + 1, iGroup).ToString.IndexOf(";") = -1 Then
                                                                    tmpPrepod = Raspisanie(iFindDisc + 3, iGroup)
                                                                    'Проверка на занятость преподавателя в числителе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1618
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим числитель в знаменатель
                                                                        Raspisanie(iFindDisc + 2, iGroup) = "[Perenos7]" & Raspisanie(iFindDisc + 1, iGroup)
                                                                        Raspisanie(iFindDisc + 1, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        Exit For
                                                                    End If
                                                                Else 'Если есть деление по группам в числителе текущей группы
                                                                    tmpPrepod1 = Mid(Raspisanie(iFindDisc + 3, iGroup), 1, Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";"))
                                                                    tmpPrepod2 = Mid(Raspisanie(iFindDisc + 3, iGroup), Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iFindDisc + 3, iGroup)) - (Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 4))
                                                                    'Проверка на занятость преподавателя в числителе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1643
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod1) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod2) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим числитель в знаменатель
                                                                        Raspisanie(iFindDisc + 2, iGroup) = "[Perenos7]" & Raspisanie(iFindDisc + 1, iGroup)
                                                                        Raspisanie(iFindDisc + 1, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        Exit For
                                                                    End If
                                                                End If
                                                            ElseIf Raspisanie(iFindDisc + 1, iGroup) = Nothing And Not Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                Exit For
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    End If
                                                ElseIf Not Raspisanie(iFindDisc + 1, jGroup).ToString.IndexOf(";") = -1 And Not Raspisanie(iFindDisc + 2, jGroup).ToString.IndexOf(";") = -1 Then
                                                    'Если числитель
                                                    NextIndexOf3 = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2
                                                    For i3Index = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(iFindDisc + 3, jGroup))
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), i3Index, 1).ToString = ";" Then NextIndexOf3 = i3Index : Exit For
                                                    Next
                                                    If (Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Or Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) And (Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Or Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) Then
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3) + 2).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 And Mid(Raspisanie(iFindDisc + 3, jGroup), NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3) + 2).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then
                                                            For j2Group = 0 To iGroup - 1
                                                                LineNumber = 1685
                                                                If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                If Not j2Group = jGroup Then
                                                                    'Если нашли преподавателя
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then
                                                                            pFindDisc = False
                                                                            Exit For
                                                                        End If
                                                                    End If
                                                                    'If j2Group = iGroup - 1 Then pFindDisc = True
                                                                End If
                                                                If j2Group = iGroup - 1 Then pFindDisc = True
                                                            Next
                                                        Else
                                                            pFindDisc = False
                                                        End If
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = False
                                                                iDisc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                SelectDiscPos = 2
                                                                Proverka = "[pFD-T-p1-F]"
                                                                Exit For
                                                            ElseIf Not Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                Exit For
                                                            ElseIf Raspisanie(iFindDisc + 1, iGroup) = Nothing And Not Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                'Пробуем поменять местами знаменатель с числителем
                                                                'Если нет деления по группам в знаменателе текущей группы
                                                                If Raspisanie(iFindDisc + 2, iGroup).ToString.IndexOf(";") = -1 Then
                                                                    tmpPrepod = Raspisanie(iFindDisc + 3, iGroup)
                                                                    'Проверка на занятость преподавателя в знаменателе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1717
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим знаменатель в числитель
                                                                        Raspisanie(iFindDisc + 1, iGroup) = "[Perenos8]" & Raspisanie(iFindDisc + 2, iGroup)
                                                                        Raspisanie(iFindDisc + 2, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        Exit For
                                                                    End If
                                                                Else 'Если есть деление по группам в знаменателе текущей группы
                                                                    tmpPrepod1 = Mid(Raspisanie(iFindDisc + 3, iGroup), 1, Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";"))
                                                                    tmpPrepod2 = Mid(Raspisanie(iFindDisc + 3, iGroup), Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iFindDisc + 3, iGroup)) - (Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 4))
                                                                    'Проверка на занятость преподавателя в знаменателе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1742
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod1) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod2) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим знаменатель в числитель
                                                                        Raspisanie(iFindDisc + 1, iGroup) = "[Perenos8]" & Raspisanie(iFindDisc + 2, iGroup)
                                                                        Raspisanie(iFindDisc + 2, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        Exit For
                                                                    End If
                                                                End If
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    Else 'Если знаменатель
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        For j2Group = 0 To iGroup - 1
                                                            LineNumber = 1772
                                                            If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                            If Not j2Group = jGroup Then
                                                                'Если нашли преподавателя
                                                                If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 And Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then
                                                                        pFindDisc = False
                                                                        Exit For
                                                                    End If
                                                                End If
                                                                'If j2Group = iGroup - 1 Then pFindDisc = True
                                                            End If
                                                            If j2Group = iGroup - 1 Then pFindDisc = True
                                                        Next
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = False
                                                                iDisc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                                                SelectDiscPos = 1
                                                                Proverka = "[pFD-T-p1-F]"
                                                                Exit For
                                                            ElseIf Not Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                'Пробуем поменять местами числитель с знаменателем
                                                                'Если нет деления по группам в числителе текущей группы
                                                                If Raspisanie(iFindDisc + 1, iGroup).ToString.IndexOf(";") = -1 Then
                                                                    tmpPrepod = Raspisanie(iFindDisc + 3, iGroup)
                                                                    'Проверка на занятость преподавателя в числителе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1799
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим числитель в знаменатель
                                                                        Raspisanie(iFindDisc + 2, iGroup) = "[Perenos9]" & Raspisanie(iFindDisc + 1, iGroup)
                                                                        Raspisanie(iFindDisc + 1, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        Exit For
                                                                    End If
                                                                Else 'Если есть деление по группам в числителе текущей группы
                                                                    tmpPrepod1 = Mid(Raspisanie(iFindDisc + 3, iGroup), 1, Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";"))
                                                                    tmpPrepod2 = Mid(Raspisanie(iFindDisc + 3, iGroup), Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iFindDisc + 3, iGroup)) - (Raspisanie(iFindDisc + 3, iGroup).ToString.IndexOf(";") + 4))
                                                                    'Проверка на занятость преподавателя в числителе текущей группы
                                                                    For j2Group = 0 To iGroup - 1
                                                                        LineNumber = 1824
                                                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                        'Если нашли преподавателя
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                            If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod1) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(tmpPrepod2) = -1 Then
                                                                                pFindDisc = False
                                                                                Exit For
                                                                            End If
                                                                        End If
                                                                    Next
                                                                    If pFindDisc = False Then
                                                                        Continue For
                                                                    Else
                                                                        'Переносим числитель в знаменатель
                                                                        Raspisanie(iFindDisc + 2, iGroup) = "[Perenos9]" & Raspisanie(iFindDisc + 1, iGroup)
                                                                        Raspisanie(iFindDisc + 1, iGroup) = Nothing
                                                                        p1Disc = True
                                                                        i1Disc = iFindDisc
                                                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                        Proverka = "[pFD-T-p1-T]"
                                                                        Exit For
                                                                    End If
                                                                End If
                                                            ElseIf Raspisanie(iFindDisc + 1, iGroup) = Nothing And Not Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                Exit For
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    End If
                                                Else 'Если нет деления
                                                    Continue For
                                                End If
                                            End If
                                    End If
                                    End If
                                End If
                            Next
                            If pFindDisc = True Then Exit For
                        Next
                    End If

                    If pFindDisc = False Then
                        'Поиск свободного часа в рассписании
                        k1Disc = 0
                        For i1Disc = 0 To 85 Step 5
                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                            If Raspisanie(i1Disc, iGroup) = Nothing And ((Raspisanie(i1Disc + 1, iGroup) = Nothing And Not Raspisanie(i1Disc + 2, iGroup) = Nothing) Or (Not Raspisanie(i1Disc + 1, iGroup) = Nothing And Raspisanie(i1Disc + 2, iGroup) = Nothing)) Then
                                p1Disc = True
                                k1Disc = k1Disc + 1
                            End If
                        Next
                        If p1Disc = True Then
                            Erase tmpp1Disc
                            ReDim tmpp1Disc(k1Disc - 1)
                            k1Disc = 0
                            For i1Disc = 0 To 85 Step 5
                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                If Raspisanie(i1Disc, iGroup) = Nothing And ((Raspisanie(i1Disc + 1, iGroup) = Nothing And Not Raspisanie(i1Disc + 2, iGroup) = Nothing) Or (Not Raspisanie(i1Disc + 1, iGroup) = Nothing And Raspisanie(i1Disc + 2, iGroup) = Nothing)) Then
                                    tmpp1Disc(k1Disc) = i1Disc
                                    k1Disc = k1Disc + 1
                                    If iGroup = 0 Then Exit For
                                End If
                            Next
                            'Проверка на занятость преподавателя
                            If Not iGroup = 0 Then
                                Proverka = "[pFD-F-p1-T]"
                                For itmpp1Disc = 0 To tmpp1Disc.GetUpperBound(0)
                                    p1Disc = True
                                    i1Disc = tmpp1Disc(itmpp1Disc)
                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                    For jGroup = 0 To iGroup - 1
                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                        LineNumber = 1897
                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                        If Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") = Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") Then
                                            If Not Raspisanie(tmpp1Disc(itmpp1Disc) + 3, jGroup) = Nothing Then
                                                If Not Raspisanie(tmpp1Disc(itmpp1Disc) + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then p1Disc = False : Proverka = "[pFD-F-p1-F]" : Exit For
                                            End If
                                        Else
                                            If Not Raspisanie(tmpp1Disc(itmpp1Disc) + 3, jGroup) = Nothing Then
                                                If Not Raspisanie(tmpp1Disc(itmpp1Disc) + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Or Not Raspisanie(tmpp1Disc(itmpp1Disc) + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then p1Disc = False : Proverka = "[pFD-F-p1-F]" : Exit For
                                            End If
                                        End If
                                    Next
                                Next
                            End If
                        End If
                    End If

                    'Если не нашли подходящую пару и свободный час и у нас осталась всего 1 нечётная пара
                    If p1Disc = False And kUnevenDisc(iGroup) = 1 Then
                        If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("1.[Проверка]. Не удалось найти подходящего места для последнего часа нечётных пар" & vbCrLf & "Сейчас буду искать пару с одним часом и искать подходящее место для них", 4096)
                        'Поиск свободного часа в рассписании
                        k1Disc = 0
                        For i1Disc = 0 To 85 Step 5
                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                            If Raspisanie(i1Disc, iGroup) = Nothing And ((Raspisanie(i1Disc + 1, iGroup) = Nothing And Not Raspisanie(i1Disc + 2, iGroup) = Nothing) Or (Not Raspisanie(i1Disc + 1, iGroup) = Nothing And Raspisanie(i1Disc + 2, iGroup) = Nothing)) Then
                                p1Disc = True
                                k1Disc = k1Disc + 1
                            End If
                        Next
                        Erase tmpp1Disc
                        ReDim tmpp1Disc(k1Disc - 1)
                        k1Disc = 0
                        For i1Disc = 0 To 85 Step 5
                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                            If Raspisanie(i1Disc, iGroup) = Nothing And ((Raspisanie(i1Disc + 1, iGroup) = Nothing And Not Raspisanie(i1Disc + 2, iGroup) = Nothing) Or (Not Raspisanie(i1Disc + 1, iGroup) = Nothing And Raspisanie(i1Disc + 2, iGroup) = Nothing)) Then
                                tmpp1Disc(k1Disc) = i1Disc
                                k1Disc = k1Disc + 1
                                If iGroup = 0 Then Exit For
                            End If
                        Next
                        If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("1.[Проверка]. Нашёл свободный час в паре под №" & i1Disc & ", сейчас буду проверять на занятость", 4096)
                        'Проверка на занятость преподавателей
                        pFindDisc = True
                        If Not iGroup = 0 Then
                            For itmpp1Disc = 0 To tmpp1Disc.GetUpperBound(0)
                                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then If pFindDisc = False Then MsgBox("1.[Проверка]. Преподаватель занят на паре под №" & i1Disc, 4096)
                                p1Disc = True
                                pFindDisc = True
                                i1Disc = tmpp1Disc(itmpp1Disc)
                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                For jGroup = 0 To iGroup - 1
                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                    LineNumber = 2337
                                    If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                    'Если нет деления в текущей дисциплине
                                    If Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") = Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") Then
                                        If Not Raspisanie(i1Disc + 3, jGroup) = Nothing Then
                                            If Not Raspisanie(i1Disc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then pFindDisc = False : p1Disc = False : Exit For
                                        End If
                                    Else 'Если есть деление в текущей дисциплине
                                        If Not Raspisanie(i1Disc + 3, jGroup) = Nothing Then
                                            If Not Raspisanie(i1Disc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Or Not Raspisanie(i1Disc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then pFindDisc = False : p1Disc = False : Exit For
                                        End If
                                    End If
                                Next
                            Next
                        End If
                        If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then If pFindDisc = False Then MsgBox("1.[Проверка]. Преподаватель занят на всех свободных парах, сейчас буду генерировать место для перемещения", 4096)
                        'Если не нашли свободного незанятого места, генерируем, какую пару будем перемещать
                        If pFindDisc = False Then
                            Proverka = "[kUD1][pFD-F]" & Proverka
                            i1Disc = tmpp1Disc((CInt(Math.Ceiling(Rnd() * tmpp1Disc.GetUpperBound(0) + 1))) - 1)
                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                            Do While pFindDisc = False
                                'ДОБАВИТЬ УСЛОВИЕ: ЕСЛИ НЕ СМОГ ДОБАВИТЬСЯ ТО ПЕРЕМЕЩАЕМСЯ ВМЕСТЕ
                                pFindDisc = True
                                iDisc = ((CInt(Math.Ceiling(Rnd() * 18)) * 5) - 5)
                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                'Ищем пустую пару куда попытаемся переместиться
                                Do While Not Raspisanie(iDisc, iGroup) = Nothing Or Not Raspisanie(iDisc + 1, iGroup) = Nothing Or Not Raspisanie(iDisc + 2, iGroup) = Nothing
                                    iDisc = ((CInt(Math.Ceiling(Rnd() * 18)) * 5) - 5)
                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                Loop
                                'Проверка на занятость преподавателей
                                If Not iGroup = 0 Then
                                    For jGroup = 0 To iGroup - 1
                                        LineNumber = 1950
                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                        'Если нет деления в текущей дисциплине
                                        If Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") = Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") Then
                                            If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                                If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then pFindDisc = False : Exit For
                                            End If
                                        Else 'Если есть деление в текущей дисциплине
                                            If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                                If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Or Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then pFindDisc = False : Exit For
                                            End If
                                        End If
                                        'Если нет деления в найденном часе
                                        If Raspisanie(i1Disc + 3, iGroup).ToString.IndexOf(";") = -1 Then
                                            If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                                If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(Raspisanie(i1Disc + 3, iGroup).ToString) = -1 Then pFindDisc = False : Exit For
                                            End If
                                        Else 'Если есть деление в найденном часе
                                            If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                                If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(Mid(Raspisanie(i1Disc + 3, iGroup), 1, Raspisanie(i1Disc + 3, iGroup).ToString.IndexOf(";"))) = -1 Or Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(Mid(Raspisanie(i1Disc + 3, iGroup), Raspisanie(i1Disc + 3, iGroup).ToString.IndexOf(";") + 3)) = -1 Then pFindDisc = False : Exit For
                                            End If
                                        End If
                                    Next
                                End If
                            Loop
                            If Not Raspisanie(i1Disc + 1, iGroup) = Nothing Then
                                If ProverkaOnDisc = True Then Raspisanie(iDisc + 1, iGroup) = Proverka & Raspisanie(i1Disc + 1, iGroup) Else Raspisanie(iDisc + 1, iGroup) = Raspisanie(i1Disc + 1, iGroup)
                                Raspisanie(i1Disc + 1, iGroup) = Nothing
                            Else
                                If ProverkaOnDisc = True Then Raspisanie(iDisc + 2, iGroup) = Proverka & Raspisanie(i1Disc + 2, iGroup) Else Raspisanie(iDisc + 2, iGroup) = Raspisanie(i1Disc + 2, iGroup)
                                Raspisanie(i1Disc + 2, iGroup) = Nothing
                            End If
                            Raspisanie(iDisc + 3, iGroup) = Raspisanie(i1Disc + 3, iGroup)
                            Raspisanie(i1Disc + 3, iGroup) = Nothing
                            Raspisanie(iDisc + 4, iGroup) = Raspisanie(i1Disc + 4, iGroup)
                            Raspisanie(i1Disc + 4, iGroup) = Nothing
                            If RaspisaniePreview = True Then
                                Select Case i1Disc / 5
                                    Case 0, 1, 2
                                        frm_raspisanie_preview.DataGridView1.Rows(i1Disc / 5).Cells(iGroupDataGrid).Value = ""
                                    Case 3, 4, 5
                                        frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 1).Cells(iGroupDataGrid).Value = ""
                                    Case 6, 7, 8
                                        frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 2).Cells(iGroupDataGrid).Value = ""
                                    Case 9, 10, 11
                                        frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 3).Cells(iGroupDataGrid).Value = ""
                                    Case 12, 13, 14
                                        frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 4).Cells(iGroupDataGrid).Value = ""
                                    Case 15, 16, 17
                                        frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 5).Cells(iGroupDataGrid).Value = ""
                                End Select
                            End If
                            p1Disc = True
                            Proverka = Mid(Proverka, 14)
                            i1Disc = iDisc
                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                        End If
                    End If

                    'Если есть пара только с занятым 1-им часом
Link_1_1_Raspisanie: If p1Disc = True Then

                        If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then If Raspisanie(i1Disc + 1, iGroup) = Nothing And Not Raspisanie(i1Disc + 2, iGroup) = Nothing Then MsgBox("1. Нашёл пару со свободным часом: первым под № " & i1Disc) Else MsgBox("1. Нашёл пару со свободным часом: вторым под № " & i1Disc, 4096)
                        If ProverkaOnDisc = False Then Proverka = ""

                        'Если числитель свободный
                        If Raspisanie(i1Disc + 1, iGroup) = Nothing And Not Raspisanie(i1Disc + 2, iGroup) = Nothing Then

                            'Если нет деления по группам
                            If Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") = Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") Then
                                If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then Raspisanie(i1Disc + 1, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value Else Raspisanie(i1Disc + 1, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString
                                Raspisanie(i1Disc + 3, iGroup) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & "; " & Raspisanie(i1Disc + 3, iGroup) & "; "
                                Raspisanie(i1Disc + 4, iGroup) = objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & "; " & Raspisanie(i1Disc + 4, iGroup) & "; "
                            Else 'Если есть деление по группам
                                If Not objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then Raspisanie(i1Disc + 1, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value Else If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then Raspisanie(i1Disc + 1, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value Else Raspisanie(i1Disc + 1, iGroup) = objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString
                                If Not objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value = Nothing Then Raspisanie(i1Disc + 1, iGroup) = Raspisanie(i1Disc + 1, iGroup) & "; " & Proverka & objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; " Else If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value = Nothing Then Raspisanie(i1Disc + 1, iGroup) = Raspisanie(i1Disc + 1, iGroup) & "; " & Proverka & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; " Else Raspisanie(i1Disc + 1, iGroup) = Raspisanie(i1Disc + 1, iGroup) & "; " & Proverka & objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value.ToString & "; "
                                tmpRaspisanieValue = Raspisanie(i1Disc + 3, iGroup)
                                Raspisanie(i1Disc + 3, iGroup) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                                Raspisanie(i1Disc + 3, iGroup) = Raspisanie(i1Disc + 3, iGroup) & "; " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; " & tmpRaspisanieValue & "; "
                                tmpRaspisanieValue = Raspisanie(i1Disc + 4, iGroup)
                                Raspisanie(i1Disc + 4, iGroup) = objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                                Raspisanie(i1Disc + 4, iGroup) = Raspisanie(i1Disc + 4, iGroup) & "; " & objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; " & tmpRaspisanieValue & "; "
                            End If

                        Else 'Если знаменатель свободный

                            'Если нет деления по группам
                            If Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") = Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") Then
                                If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then Raspisanie(i1Disc + 2, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value Else Raspisanie(i1Disc + 2, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString
                                Raspisanie(i1Disc + 3, iGroup) = Raspisanie(i1Disc + 3, iGroup) & "; " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & "; "
                                Raspisanie(i1Disc + 4, iGroup) = Raspisanie(i1Disc + 4, iGroup) & "; " & objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & "; "
                            Else 'Если есть деление по группам
                                If Not objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then Raspisanie(i1Disc + 2, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value Else If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then Raspisanie(i1Disc + 2, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value Else Raspisanie(i1Disc + 2, iGroup) = objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString
                                If Not objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value = Nothing Then Raspisanie(i1Disc + 2, iGroup) = Raspisanie(i1Disc + 2, iGroup) & "; " & Proverka & objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; " Else If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value = Nothing Then Raspisanie(i1Disc + 2, iGroup) = Raspisanie(i1Disc + 2, iGroup) & "; " & Proverka & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; " Else Raspisanie(i1Disc + 2, iGroup) = Raspisanie(i1Disc + 2, iGroup) & "; " & objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value.ToString & "; "
                                Raspisanie(i1Disc + 3, iGroup) = Raspisanie(i1Disc + 3, iGroup) & "; " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                                Raspisanie(i1Disc + 3, iGroup) = Raspisanie(i1Disc + 3, iGroup) & "; " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; "
                                Raspisanie(i1Disc + 4, iGroup) = Raspisanie(i1Disc + 4, iGroup) & "; " & objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                                Raspisanie(i1Disc + 4, iGroup) = Raspisanie(i1Disc + 4, iGroup) & "; " & objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; "
                            End If

                        End If

                    Else 'Если нет пары с занятым только 1-им часом

                        If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("1. Не нашёл пару со свободным часом", 4096)

                        'Генерируем позицию пары в расписании
                        If pFindDisc = False Then
                            Proverka = "[pFD-F-p1-F-Random]"
                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("1. Не смог найти подходящее место для часа, сейчас буду генерировать место", 4096)
                            Do While pFindDisc = False
                                pFindDisc = True
                                iDisc = ((CInt(Math.Ceiling(Rnd() * 18)) * 5) - 5)
                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                Do While Not Raspisanie(iDisc, iGroup) = Nothing Or Not Raspisanie(iDisc + 1, iGroup) = Nothing Or Not Raspisanie(iDisc + 2, iGroup) = Nothing
                                    iDisc = ((CInt(Math.Ceiling(Rnd() * 18)) * 5) - 5)
                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                Loop
                                'Проверка на занятость преподавателя
                                If Not iGroup = 0 Then
                                    For jGroup = 0 To iGroup - 1
                                        LineNumber = 2076
                                        If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                        If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                        If Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") = Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") Then
                                            If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                                If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then pFindDisc = False : Exit For
                                            End If
                                        Else
                                            If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                                If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Or Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then pFindDisc = False : Exit For
                                            End If
                                        End If
                                    Next
                                End If
                            Loop
                            pFindDisc = False
                            'Генерируем, какую часть займём: числитель или знаменатель
                            SelectDiscPos = CInt(Math.Ceiling(Rnd() * 2))
                        End If

                        If ProverkaOnDisc = False Then Proverka = ""

                        'Числитель
Link_1_2_Raspisanie:    If SelectDiscPos = 1 Then

                            'Если нет деления по группам
                            If Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") = Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") Then
                                If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then Raspisanie(iDisc + 1, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value Else Raspisanie(iDisc + 1, iGroup) = objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString
                                Raspisanie(iDisc + 3, iGroup) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                                Raspisanie(iDisc + 4, iGroup) = objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                            Else 'Если есть деление по группам
                                If Not objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then Raspisanie(iDisc + 1, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value Else If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then Raspisanie(iDisc + 1, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value Else Raspisanie(iDisc + 1, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString
                                If Not objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value = Nothing Then Raspisanie(iDisc + 1, iGroup) = Raspisanie(iDisc + 1, iGroup) & "; " & Proverka & objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; " Else If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value = Nothing Then Raspisanie(iDisc + 1, iGroup) = Raspisanie(iDisc + 1, iGroup) & "; " & Proverka & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; " Else Raspisanie(iDisc + 1, iGroup) = Raspisanie(iDisc + 1, iGroup) & "; " & Proverka & objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value.ToString & "; "
                                Raspisanie(iDisc + 3, iGroup) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                                Raspisanie(iDisc + 3, iGroup) = Raspisanie(iDisc + 3, iGroup) & "; " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value
                                Raspisanie(iDisc + 4, iGroup) = objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                                Raspisanie(iDisc + 4, iGroup) = Raspisanie(iDisc + 4, iGroup) & "; " & objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value
                            End If

                        Else 'Знаменатель

                            'Если нет деления по группам
                            If Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") = Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") Then
                                If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then Raspisanie(iDisc + 2, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value Else Raspisanie(iDisc + 2, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString
                                Raspisanie(iDisc + 3, iGroup) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                                Raspisanie(iDisc + 4, iGroup) = objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                            Else 'Если есть деление по группам
                                If Not objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then Raspisanie(iDisc + 2, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value Else If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value = Nothing Then Raspisanie(iDisc + 2, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value Else Raspisanie(iDisc + 2, iGroup) = Proverka & objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString
                                If Not objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value = Nothing Then Raspisanie(iDisc + 2, iGroup) = Raspisanie(iDisc + 2, iGroup) & "; " & Proverka & objSheetWork.Range(EXCELDisciplinesExtraShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; " Else If objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value = Nothing Then Raspisanie(iDisc + 2, iGroup) = Raspisanie(iDisc + 2, iGroup) & "; " & Proverka & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & "; " Else Raspisanie(iDisc + 2, iGroup) = Raspisanie(iDisc + 2, iGroup) & "; " & Proverka & objSheetWork.Range(EXCELDisciplinesShort.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value.ToString & "; "
                                Raspisanie(iDisc + 3, iGroup) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                                Raspisanie(iDisc + 3, iGroup) = Raspisanie(iDisc + 3, iGroup) & "; " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value
                                Raspisanie(iDisc + 4, iGroup) = objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value
                                Raspisanie(iDisc + 4, iGroup) = Raspisanie(iDisc + 4, iGroup) & "; " & objSheetWork.Range(EXCELClassrooms.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value
                            End If

                        End If

                    End If
                    Disc(CurrentDisc, 1, iGroup) = Disc(CurrentDisc, 1, iGroup) - 1
                    kUnevenDisc(iGroup) = kUnevenDisc(iGroup) - 1
                    itmpDisc = itmpDisc - 5

                    'Проверка на пары только с числителем или знаменателем при распределённых нечётных часов пар
Link_p12Disc:       If kUnevenDisc(iGroup) = 0 Then
                        p1Disc = False
                        p12Disc = True
                        'Поиск свободного часа в рассписании
                        For i1Disc = 0 To 85 Step 5
                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                            If Raspisanie(i1Disc, iGroup) = Nothing And ((Raspisanie(i1Disc + 1, iGroup) = Nothing And Not Raspisanie(i1Disc + 2, iGroup) = Nothing) Or (Not Raspisanie(i1Disc + 1, iGroup) = Nothing And Raspisanie(i1Disc + 2, iGroup) = Nothing)) Then
                                p1Disc = True
                                Exit For
                            End If
                        Next
                        If p1Disc = True Then
                            If ProverkaOnDisc = False Then Proverka = "" Else Proverka = "[p12]"
                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("1.[Проверка]. Все нечётные часы распределены, но при этом нашёл свободное место в паре под №" & i1Disc & ", сейчас буду искать следующую", 4096)
                            For i1_2Disc = i1Disc + 5 To 85 Step 5
                                If Raspisanie(i1_2Disc, iGroup) = Nothing And ((Raspisanie(i1_2Disc + 1, iGroup) = Nothing And Not Raspisanie(i1_2Disc + 2, iGroup) = Nothing) Or (Not Raspisanie(i1_2Disc + 1, iGroup) = Nothing And Raspisanie(i1_2Disc + 2, iGroup) = Nothing)) Then
                                    Exit For
                                End If
                            Next
                            If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("1.[Проверка]. Нашёл ещё одно свободное место в паре под №" & i1_2Disc & ", сейчас буду их перемещать", 4096)
                            pFindDisc = True
                            'Проверка на занятость преподавателей i1Disc в i1_2Disc
                            If Not iGroup = 0 Then
                                For jGroup = 0 To iGroup - 1
                                    LineNumber = 2154
                                    If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                    'Если нет деления в текущей дисциплине
                                    If Raspisanie(i1Disc + 3, iGroup).ToString.IndexOf(";") = -1 Then
                                        If Not Raspisanie(i1_2Disc + 3, jGroup) = Nothing Then
                                            If Not Raspisanie(i1_2Disc + 3, jGroup).ToString.IndexOf(Raspisanie(i1Disc + 3, iGroup)) = -1 Then pFindDisc = False : Exit For
                                        End If
                                    Else 'Если есть деление в текущей дисциплине
                                        If Not Raspisanie(i1_2Disc + 3, jGroup) = Nothing Then
                                            If Not Raspisanie(i1_2Disc + 3, jGroup).ToString.IndexOf(Mid(Raspisanie(i1Disc + 3, iGroup), 1, Raspisanie(i1Disc + 3, iGroup).ToString.IndexOf(";"))) = -1 Or Not Raspisanie(i1_2Disc + 3, jGroup).ToString.IndexOf(Mid(Raspisanie(i1Disc + 3, iGroup), Raspisanie(i1Disc + 3, iGroup).ToString.IndexOf(";") + 3)) = -1 Then pFindDisc = False : Exit For
                                        End If
                                    End If
                                Next
                            End If
                            If pFindDisc = False Then pZan1Disc = True Else pZan1Disc = False
                            pFindDisc = True
                            'Проверка на занятость преподавателей i1_2Disc в i1Disc
                            If Not iGroup = 0 Then
                                For jGroup = 0 To iGroup - 1
                                    LineNumber = 2174
                                    If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                    'Если нет деления в текущей дисциплине
                                    Try
                                        If Raspisanie(i1_2Disc + 3, iGroup).ToString.IndexOf(";") = -1 Then
                                            If Not Raspisanie(i1Disc + 3, jGroup) = Nothing Then
                                                If Not Raspisanie(i1Disc + 3, jGroup).ToString.IndexOf(Raspisanie(i1_2Disc + 3, iGroup)) = -1 Then pFindDisc = False : Exit For
                                            End If
                                        Else 'Если есть деление в текущей дисциплине
                                            If Not Raspisanie(i1Disc + 3, jGroup) = Nothing Then
                                                If Not Raspisanie(i1Disc + 3, jGroup).ToString.IndexOf(Mid(Raspisanie(i1_2Disc + 3, iGroup), 1, Raspisanie(i1_2Disc + 3, iGroup).ToString.IndexOf(";"))) = -1 Or Not Raspisanie(i1Disc + 3, jGroup).ToString.IndexOf(Mid(Raspisanie(i1_2Disc + 3, iGroup), Raspisanie(i1_2Disc + 3, iGroup).ToString.IndexOf(";") + 3)) = -1 Then pFindDisc = False : Exit For
                                            End If
                                        End If
                                    Catch
                                        'MsgBox(i1_2Disc & ": " & Raspisanie(i1_2Disc, iGroup) & vbCrLf & i1_2Disc + 1 & ": " & Raspisanie(i1_2Disc + 1, iGroup) & vbCrLf & i1_2Disc + 2 & ": " & Raspisanie(i1_2Disc + 2, iGroup) & vbCrLf & i1_2Disc + 3 & ": " & Raspisanie(i1_2Disc + 3, iGroup) & vbCrLf & i1_2Disc + 4 & ": " & Raspisanie(i1_2Disc + 4, iGroup))
                                    End Try
                                Next
                            End If
                            If pFindDisc = False Then pZan2Disc = True Else pZan2Disc = False
                            If pZan1Disc = True And pZan2Disc = True Then
                                p12Disc = False
                            ElseIf pZan1Disc = False And pZan2Disc = False Then
                                'Генерируем, какую дисциплину будем перемещать
                                SelectDisc = CInt(Math.Ceiling(Rnd() * 2))
                            ElseIf pZan1Disc = True And pZan2Disc = False Then
                                SelectDisc = 2
                            ElseIf pZan1Disc = False And pZan2Disc = True Then
                                SelectDisc = 1
                            End If
                            If p12Disc = True Then
                                Select Case SelectDisc
                                    Case 1
                                        If Raspisanie(i1_2Disc + 1, iGroup) = Nothing Then
                                            If Raspisanie(i1Disc + 1, iGroup) = Nothing Then
                                                Raspisanie(i1_2Disc + 1, iGroup) = Proverka & Raspisanie(i1Disc + 2, iGroup)
                                                Raspisanie(i1Disc + 2, iGroup) = Nothing
                                            Else
                                                Raspisanie(i1_2Disc + 1, iGroup) = Proverka & Raspisanie(i1Disc + 1, iGroup)
                                                Raspisanie(i1Disc + 1, iGroup) = Nothing
                                            End If
                                            Raspisanie(i1_2Disc + 3, iGroup) = Raspisanie(i1Disc + 3, iGroup) & "; " & Raspisanie(i1_2Disc + 3, iGroup) & "; "
                                            Raspisanie(i1_2Disc + 4, iGroup) = Raspisanie(i1Disc + 4, iGroup) & "; " & Raspisanie(i1_2Disc + 4, iGroup) & "; "
                                        Else
                                            If Raspisanie(i1Disc + 1, iGroup) = Nothing Then
                                                Raspisanie(i1_2Disc + 2, iGroup) = Proverka & Raspisanie(i1Disc + 2, iGroup)
                                                Raspisanie(i1Disc + 2, iGroup) = Nothing
                                            Else
                                                Raspisanie(i1_2Disc + 2, iGroup) = Proverka & Raspisanie(i1Disc + 1, iGroup)
                                                Raspisanie(i1Disc + 1, iGroup) = Nothing
                                            End If
                                            Raspisanie(i1_2Disc + 3, iGroup) = Raspisanie(i1_2Disc + 3, iGroup) & "; " & Raspisanie(i1Disc + 3, iGroup) & "; "
                                            Raspisanie(i1_2Disc + 4, iGroup) = Raspisanie(i1_2Disc + 4, iGroup) & "; " & Raspisanie(i1Disc + 4, iGroup) & "; "
                                        End If
                                        Raspisanie(i1Disc + 3, iGroup) = Nothing
                                        Raspisanie(i1Disc + 4, iGroup) = Nothing
                                        If RaspisaniePreview = True Then
                                            Select Case i1Disc / 5
                                                Case 0, 1, 2
                                                    frm_raspisanie_preview.DataGridView1.Rows(i1Disc / 5).Cells(iGroupDataGrid).Value = ""
                                                Case 3, 4, 5
                                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 1).Cells(iGroupDataGrid).Value = ""
                                                Case 6, 7, 8
                                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 2).Cells(iGroupDataGrid).Value = ""
                                                Case 9, 10, 11
                                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 3).Cells(iGroupDataGrid).Value = ""
                                                Case 12, 13, 14
                                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 4).Cells(iGroupDataGrid).Value = ""
                                                Case 15, 16, 17
                                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 5).Cells(iGroupDataGrid).Value = ""
                                            End Select
                                        End If
                                    Case 2
                                        If Raspisanie(i1Disc + 1, iGroup) = Nothing Then
                                            If Raspisanie(i1_2Disc + 1, iGroup) = Nothing Then
                                                Raspisanie(i1Disc + 1, iGroup) = Proverka & Raspisanie(i1_2Disc + 2, iGroup)
                                                Raspisanie(i1_2Disc + 2, iGroup) = Nothing
                                            Else
                                                Raspisanie(i1Disc + 1, iGroup) = Proverka & Raspisanie(i1_2Disc + 1, iGroup)
                                                Raspisanie(i1_2Disc + 1, iGroup) = Nothing
                                            End If
                                            Raspisanie(i1Disc + 3, iGroup) = Raspisanie(i1_2Disc + 3, iGroup) & "; " & Raspisanie(i1Disc + 3, iGroup) & "; "
                                            Raspisanie(i1Disc + 4, iGroup) = Raspisanie(i1_2Disc + 4, iGroup) & "; " & Raspisanie(i1Disc + 4, iGroup) & "; "
                                        Else
                                            If Raspisanie(i1_2Disc + 1, iGroup) = Nothing Then
                                                Raspisanie(i1Disc + 2, iGroup) = Proverka & Raspisanie(i1_2Disc + 2, iGroup)
                                                Raspisanie(i1_2Disc + 2, iGroup) = Nothing
                                            Else
                                                Raspisanie(i1Disc + 2, iGroup) = Proverka & Raspisanie(i1_2Disc + 1, iGroup)
                                                Raspisanie(i1_2Disc + 1, iGroup) = Nothing
                                            End If
                                            Raspisanie(i1Disc + 3, iGroup) = Raspisanie(i1Disc + 3, iGroup) & "; " & Raspisanie(i1_2Disc + 3, iGroup) & "; "
                                            Raspisanie(i1Disc + 4, iGroup) = Raspisanie(i1Disc + 4, iGroup) & "; " & Raspisanie(i1_2Disc + 4, iGroup) & "; "
                                        End If
                                        Raspisanie(i1_2Disc + 3, iGroup) = Nothing
                                        Raspisanie(i1_2Disc + 4, iGroup) = Nothing
                                        If RaspisaniePreview = True Then
                                            Select Case i1_2Disc / 5
                                                Case 0, 1, 2
                                                    frm_raspisanie_preview.DataGridView1.Rows(i1_2Disc / 5).Cells(iGroupDataGrid).Value = ""
                                                Case 3, 4, 5
                                                    frm_raspisanie_preview.DataGridView1.Rows((i1_2Disc / 5) + 1).Cells(iGroupDataGrid).Value = ""
                                                Case 6, 7, 8
                                                    frm_raspisanie_preview.DataGridView1.Rows((i1_2Disc / 5) + 2).Cells(iGroupDataGrid).Value = ""
                                                Case 9, 10, 11
                                                    frm_raspisanie_preview.DataGridView1.Rows((i1_2Disc / 5) + 3).Cells(iGroupDataGrid).Value = ""
                                                Case 12, 13, 14
                                                    frm_raspisanie_preview.DataGridView1.Rows((i1_2Disc / 5) + 4).Cells(iGroupDataGrid).Value = ""
                                                Case 15, 16, 17
                                                    frm_raspisanie_preview.DataGridView1.Rows((i1_2Disc / 5) + 5).Cells(iGroupDataGrid).Value = ""
                                            End Select
                                        End If
                                End Select
                            End If
                            If p12Disc = False Then iDisc = 0
                            Do While p12Disc = False
                                pFindDisc = True
                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                Do While Not Raspisanie(iDisc, iGroup) = Nothing Or Not Raspisanie(iDisc + 1, iGroup) = Nothing Or Not Raspisanie(iDisc + 2, iGroup) = Nothing
                                    iDisc = iDisc + 5
                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                                Loop
                                'Проверка на занятость преподавателей
                                For jGroup = 0 To iGroup - 1
                                    LineNumber = 2456
                                    If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                    If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingjGroupChange))
                                    'Если нет деления в i1Disc
                                    If Raspisanie(i1Disc + 3, iGroup).ToString.IndexOf(";") = -1 Then
                                        If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                            If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(Raspisanie(i1Disc + 3, iGroup)) = -1 Then pFindDisc = False : Exit For
                                        End If
                                    Else 'Если есть деление в i1Disc
                                        If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                            If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(Mid(Raspisanie(i1Disc + 3, iGroup), 1, Raspisanie(i1Disc + 3, iGroup).ToString.IndexOf(";"))) = -1 Or Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(Mid(Raspisanie(i1Disc + 3, iGroup), Raspisanie(i1Disc + 3, iGroup).ToString.IndexOf(";") + 3)) = -1 Then pFindDisc = False : Exit For
                                        End If
                                    End If
                                    'Если нет деления в i1_2Disc
                                    If Raspisanie(i1_2Disc + 3, iGroup).ToString.IndexOf(";") = -1 Then
                                        If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                            If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(Raspisanie(i1_2Disc + 3, iGroup)) = -1 Then pFindDisc = False : Exit For
                                        End If
                                    Else 'Если есть деление в i1_2Disc
                                        If Not Raspisanie(iDisc + 3, jGroup) = Nothing Then
                                            If Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(Mid(Raspisanie(i1_2Disc + 3, iGroup), 1, Raspisanie(i1_2Disc + 3, iGroup).ToString.IndexOf(";"))) = -1 Or Not Raspisanie(iDisc + 3, jGroup).ToString.IndexOf(Mid(Raspisanie(i1_2Disc + 3, iGroup), Raspisanie(i1_2Disc + 3, iGroup).ToString.IndexOf(";") + 3)) = -1 Then pFindDisc = False : Exit For
                                        End If
                                    End If
                                Next
                                If pFindDisc = True Then
                                    p12Disc = True
                                    'Генерируем, какая дисциплина будет в числителе
                                    SelectDisc = CInt(Math.Ceiling(Rnd() * 2))
                                    Select Case SelectDisc
                                        Case 1
                                            If Raspisanie(i1Disc + 1, iGroup) = Nothing Then
                                                Raspisanie(iDisc + 1, iGroup) = Proverka & Raspisanie(i1Disc + 2, iGroup)
                                                Raspisanie(i1Disc + 2, iGroup) = Nothing
                                            Else
                                                Raspisanie(iDisc + 1, iGroup) = Proverka & Raspisanie(i1Disc + 1, iGroup)
                                                Raspisanie(i1Disc + 1, iGroup) = Nothing
                                            End If
                                            If Raspisanie(i1_2Disc + 1, iGroup) = Nothing Then
                                                Raspisanie(iDisc + 2, iGroup) = Proverka & Raspisanie(i1_2Disc + 2, iGroup)
                                                Raspisanie(i1_2Disc + 2, iGroup) = Nothing
                                            Else
                                                Raspisanie(iDisc + 2, iGroup) = Proverka & Raspisanie(i1_2Disc + 1, iGroup)
                                                Raspisanie(i1_2Disc + 1, iGroup) = Nothing
                                            End If
                                            Raspisanie(iDisc + 3, iGroup) = Raspisanie(i1Disc + 3, iGroup) & "; " & Raspisanie(i1_2Disc + 3, iGroup) & "; "
                                            Raspisanie(iDisc + 4, iGroup) = Raspisanie(i1Disc + 4, iGroup) & "; " & Raspisanie(i1_2Disc + 4, iGroup) & "; "
                                            Raspisanie(i1_2Disc + 3, iGroup) = Nothing
                                            Raspisanie(i1_2Disc + 4, iGroup) = Nothing
                                            Raspisanie(i1Disc + 3, iGroup) = Nothing
                                            Raspisanie(i1Disc + 4, iGroup) = Nothing
                                        Case 2
                                            If Raspisanie(i1_2Disc + 1, iGroup) = Nothing Then
                                                Raspisanie(iDisc + 1, iGroup) = Proverka & Raspisanie(i1_2Disc + 2, iGroup)
                                                Raspisanie(i1_2Disc + 2, iGroup) = Nothing
                                            Else
                                                Raspisanie(iDisc + 1, iGroup) = Proverka & Raspisanie(i1_2Disc + 1, iGroup)
                                                Raspisanie(i1_2Disc + 1, iGroup) = Nothing
                                            End If
                                            If Raspisanie(i1Disc + 1, iGroup) = Nothing Then
                                                Raspisanie(iDisc + 2, iGroup) = Proverka & Raspisanie(i1Disc + 2, iGroup)
                                                Raspisanie(i1Disc + 2, iGroup) = Nothing
                                            Else
                                                Raspisanie(iDisc + 2, iGroup) = Proverka & Raspisanie(i1Disc + 1, iGroup)
                                                Raspisanie(i1Disc + 1, iGroup) = Nothing
                                            End If
                                            Raspisanie(iDisc + 3, iGroup) = Raspisanie(i1_2Disc + 3, iGroup) & "; " & Raspisanie(i1Disc + 3, iGroup) & "; "
                                            Raspisanie(iDisc + 4, iGroup) = Raspisanie(i1_2Disc + 4, iGroup) & "; " & Raspisanie(i1Disc + 4, iGroup) & "; "
                                            Raspisanie(i1_2Disc + 3, iGroup) = Nothing
                                            Raspisanie(i1_2Disc + 4, iGroup) = Nothing
                                            Raspisanie(i1Disc + 3, iGroup) = Nothing
                                            Raspisanie(i1Disc + 4, iGroup) = Nothing
                                    End Select
                                    If RaspisaniePreview = True Then
                                        Select Case i1Disc / 5
                                            Case 0, 1, 2
                                                frm_raspisanie_preview.DataGridView1.Rows(i1Disc / 5).Cells(iGroupDataGrid).Value = ""
                                            Case 3, 4, 5
                                                frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 1).Cells(iGroupDataGrid).Value = ""
                                            Case 6, 7, 8
                                                frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 2).Cells(iGroupDataGrid).Value = ""
                                            Case 9, 10, 11
                                                frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 3).Cells(iGroupDataGrid).Value = ""
                                            Case 12, 13, 14
                                                frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 4).Cells(iGroupDataGrid).Value = ""
                                            Case 15, 16, 17
                                                frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 5).Cells(iGroupDataGrid).Value = ""
                                        End Select
                                        Select Case i1_2Disc / 5
                                            Case 0, 1, 2
                                                frm_raspisanie_preview.DataGridView1.Rows(i1_2Disc / 5).Cells(iGroupDataGrid).Value = ""
                                            Case 3, 4, 5
                                                frm_raspisanie_preview.DataGridView1.Rows((i1_2Disc / 5) + 1).Cells(iGroupDataGrid).Value = ""
                                            Case 6, 7, 8
                                                frm_raspisanie_preview.DataGridView1.Rows((i1_2Disc / 5) + 2).Cells(iGroupDataGrid).Value = ""
                                            Case 9, 10, 11
                                                frm_raspisanie_preview.DataGridView1.Rows((i1_2Disc / 5) + 3).Cells(iGroupDataGrid).Value = ""
                                            Case 12, 13, 14
                                                frm_raspisanie_preview.DataGridView1.Rows((i1_2Disc / 5) + 4).Cells(iGroupDataGrid).Value = ""
                                            Case 15, 16, 17
                                                frm_raspisanie_preview.DataGridView1.Rows((i1_2Disc / 5) + 5).Cells(iGroupDataGrid).Value = ""
                                        End Select
                                    End If
                                Else
                                    iDisc = iDisc + 5
                                End If
                            Loop
                            GoTo Link_p12Disc
                        End If
                    End If

                    'Распределение дисциплины с часами больше 1
                    If Not (Disc(CurrentDisc, 1, iGroup) Mod 2 = 1 And Disc(CurrentDisc, 1, iGroup) \ 2 = 0) Then kEvenDisc(iGroup) = kEvenDisc(iGroup) + 1

                    If p1Disc = False And pFindDisc = True And Not iGroup = 0 And Not kUnevenDisc(iGroup) = 0 Then
                        For CurrentDisc = 0 To Disc.GetUpperBound(0)
                            If Disc(CurrentDisc, 0, iGroup) = Nothing Then Exit For
                            If Disc(CurrentDisc, 1, iGroup) = 0 Or Disc(CurrentDisc, 1, iGroup) Mod 2 = 0 Then
                                Continue For
                            Else
                                pFindDisc = False
                                'Поиск подходящей дисциплины в массиве дисциплин
                                If Not Raspisanie(iFindDisc + 3, jGroup) = Nothing Then
                                    'Если только числитель и знаменатель
                                    If Raspisanie(iFindDisc, jGroup) = Nothing Then
                                        'Если нет деления по группам текущей дисциплины
                                        If Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") = Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") Then
                                            If DetaledDesctiption = True Then
                                                LoadingLabelDescription = "Проверка на занятость преподавателя " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & " на " & ((iFindDisc / 5) - ((iFindDisc \ 15) * 3)) + 1 & " паре в " & nameDay
                                                Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                            End If
                                            'Если есть преподаватель в найденной нами паре
                                            If Not Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                'Проверка на деление в числителе (в знаменателе не нужна)
                                                If Raspisanie(iFindDisc + 1, jGroup).ToString.IndexOf(";") = -1 Then
                                                    'Если числитель
                                                    If Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Then
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                            For j2Group = 0 To iGroup - 1
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                LineNumber = 1129
                                                                If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                If Not j2Group = jGroup Then
                                                                    'Если нашли преподавателя
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                                            pFindDisc = False
                                                                            Exit For
                                                                        End If
                                                                        'If j2Group = iGroup - 1 Then pFindDisc = True
                                                                    End If
                                                                End If
                                                                If j2Group = iGroup - 1 Then pFindDisc = True
                                                            Next
                                                        Else
                                                            pFindDisc = False
                                                        End If
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Not Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                GoTo Link_1_1_Raspisanie
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    Else 'Если знаменатель
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        For j2Group = 0 To iGroup - 1
                                                            LineNumber = 1214
                                                            If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                            If Not j2Group = jGroup Then
                                                                'Если нашли преподавателя
                                                                If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                                        pFindDisc = False
                                                                        Exit For
                                                                    End If
                                                                End If
                                                                'If j2Group = iGroup - 1 Then pFindDisc = True
                                                            End If
                                                            If j2Group = iGroup - 1 Then pFindDisc = True
                                                        Next
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Raspisanie(iFindDisc + 1, iGroup) = Nothing And Not Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                GoTo Link_1_1_Raspisanie
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    End If
                                                Else 'Если есть деление в числителе
                                                    'Если числитель
                                                    NextIndexOf3 = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2
                                                    For i3Index = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(iFindDisc + 3, jGroup))
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), i3Index, 1).ToString = ";" Then NextIndexOf3 = i3Index : Exit For
                                                    Next
                                                    If Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Or Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Then
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), (NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) + 2).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                            For j2Group = 0 To iGroup - 1
                                                                LineNumber = 1308
                                                                If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                If Not j2Group = jGroup Then
                                                                    'Если нашли преподавателя
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                                            pFindDisc = False
                                                                            Exit For
                                                                        End If
                                                                    End If
                                                                    'If j2Group = iGroup - 1 Then pFindDisc = True
                                                                End If
                                                                If j2Group = iGroup - 1 Then pFindDisc = True
                                                            Next
                                                        Else
                                                            pFindDisc = False
                                                        End If
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Not Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                GoTo Link_1_1_Raspisanie
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    Else 'Если знаменатель
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        For j2Group = 0 To iGroup - 1
                                                            LineNumber = 1395
                                                            If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                            If Not j2Group = jGroup Then
                                                                'Если нашли преподавателя
                                                                If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Then
                                                                        pFindDisc = False
                                                                        Exit For
                                                                    End If
                                                                End If
                                                                'If j2Group = iGroup - 1 Then pFindDisc = True
                                                            End If
                                                            If j2Group = iGroup - 1 Then pFindDisc = True
                                                        Next
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Raspisanie(iFindDisc + 1, iGroup) = Nothing And Not Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                GoTo Link_1_1_Raspisanie
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        Else 'Если есть деление по группам текущей дисциплины
                                            If DetaledDesctiption = True Then
                                                LoadingLabelDescription = "Проверка на занятость преподавателей " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & " и " & objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value & " на " & ((iFindDisc / 5) - ((iFindDisc \ 15) * 3)) + 1 & " паре в " & nameDay
                                                Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                                            End If
                                            'Если есть преподаватели в найденной нами паре
                                            If Not Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 And Not Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then
                                                'Проверка на деление в числителе и в знаменателе
                                                If Not Raspisanie(iFindDisc + 1, jGroup).ToString.IndexOf(";") = -1 And Raspisanie(iFindDisc + 2, jGroup).ToString.IndexOf(";") = -1 Then
                                                    'Если числитель
                                                    NextIndexOf3 = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2
                                                    For i3Index = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(iFindDisc + 3, jGroup))
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), i3Index, 1).ToString = ";" Then NextIndexOf3 = i3Index : Exit For
                                                    Next
                                                    If (Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Or Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) And (Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Or Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) Then
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3) + 2).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 And Mid(Raspisanie(iFindDisc + 3, jGroup), NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3) + 2).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then
                                                            For j2Group = 0 To iGroup - 1
                                                                LineNumber = 1498
                                                                If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                If Not j2Group = jGroup Then
                                                                    'Если нашли преподавателя
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then
                                                                            pFindDisc = False
                                                                            Exit For
                                                                        End If
                                                                    End If
                                                                    'If j2Group = iGroup - 1 Then pFindDisc = True
                                                                End If
                                                                If j2Group = iGroup - 1 Then pFindDisc = True
                                                            Next
                                                        Else
                                                            pFindDisc = False
                                                        End If
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Not Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                GoTo Link_1_1_Raspisanie
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    End If
                                                ElseIf Raspisanie(iFindDisc + 1, jGroup).ToString.IndexOf(";") = -1 And Not Raspisanie(iFindDisc + 2, jGroup).ToString.IndexOf(";") = -1 Then 'Если есть деление только в знаменателе
                                                    'Если знаменатель
                                                    NextIndexOf3 = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2
                                                    For i3Index = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(iFindDisc + 3, jGroup))
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), i3Index, 1).ToString = ";" Then NextIndexOf3 = i3Index : Exit For
                                                    Next
                                                    If (Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Or Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) And (Mid(Raspisanie(iFindDisc + 3, jGroup), NextIndexOf3 + 2, Len(Raspisanie(iFindDisc + 3, jGroup)) - (NextIndexOf3 + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Or Mid(Raspisanie(iFindDisc + 3, jGroup), NextIndexOf3 + 2, Len(Raspisanie(iFindDisc + 3, jGroup)) - (NextIndexOf3 + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) Then
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        If Not Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString And Not Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value Then
                                                            For j2Group = 0 To iGroup - 1
                                                                LineNumber = 1591
                                                                If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                If Not j2Group = jGroup Then
                                                                    'Если нашли преподавателя
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then
                                                                            pFindDisc = False
                                                                            Exit For
                                                                        End If
                                                                    End If
                                                                    'If j2Group = iGroup - 1 Then pFindDisc = True
                                                                End If
                                                                If j2Group = iGroup - 1 Then pFindDisc = True
                                                            Next
                                                        Else
                                                            pFindDisc = False
                                                        End If
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Raspisanie(iFindDisc + 1, iGroup) = Nothing And Not Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                GoTo Link_1_1_Raspisanie
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    End If
                                                ElseIf Not Raspisanie(iFindDisc + 1, jGroup).ToString.IndexOf(";") = -1 And Not Raspisanie(iFindDisc + 2, jGroup).ToString.IndexOf(";") = -1 Then
                                                    'Если числитель
                                                    NextIndexOf3 = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2
                                                    For i3Index = Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(iFindDisc + 3, jGroup))
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), i3Index, 1).ToString = ";" Then NextIndexOf3 = i3Index : Exit For
                                                    Next
                                                    If (Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Or Mid(Raspisanie(iFindDisc + 3, jGroup), 1, Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";")) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) And (Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString Or Mid(Raspisanie(iFindDisc + 3, jGroup), Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3)) = objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) Then
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        If Mid(Raspisanie(iFindDisc + 3, jGroup), NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3) + 2).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 And Mid(Raspisanie(iFindDisc + 3, jGroup), NextIndexOf3 - (Raspisanie(iFindDisc + 3, jGroup).ToString.IndexOf(";") + 3) + 2).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then
                                                            For j2Group = 0 To iGroup - 1
                                                                LineNumber = 1685
                                                                If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                                If Not j2Group = jGroup Then
                                                                    'Если нашли преподавателя
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                        If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 Or Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then
                                                                            pFindDisc = False
                                                                            Exit For
                                                                        End If
                                                                    End If
                                                                    'If j2Group = iGroup - 1 Then pFindDisc = True
                                                                End If
                                                                If j2Group = iGroup - 1 Then pFindDisc = True
                                                            Next
                                                        Else
                                                            pFindDisc = False
                                                        End If
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Not Raspisanie(iFindDisc + 1, iGroup) = Nothing And Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                GoTo Link_1_1_Raspisanie
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    Else 'Если знаменатель
                                                        'Проверка на занятость преподавателя в найденной нами паре
                                                        For j2Group = 0 To iGroup - 1
                                                            LineNumber = 1772
                                                            If ViewLineNumber = True Then Me.Invoke(New ThreadStart(AddressOf ChangeLineNumber))
                                                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf Loadingj2GroupChange))
                                                            If Not j2Group = jGroup Then
                                                                'Если нашли преподавателя
                                                                If Not Raspisanie(iFindDisc + 3, j2Group) = Nothing Then
                                                                    If Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value.ToString) = -1 And Not Raspisanie(iFindDisc + 3, j2Group).ToString.IndexOf(objSheetWork.Range(EXCELTeathers.Text & Mid(Disc(CurrentDisc, 0, iGroup), Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") + 3, Disc(CurrentDisc, 0, iGroup).LastIndexOf(";") - Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";") - 2)).Value) = -1 Then
                                                                        pFindDisc = False
                                                                        Exit For
                                                                    End If
                                                                End If
                                                                'If j2Group = iGroup - 1 Then pFindDisc = True
                                                            End If
                                                            If j2Group = iGroup - 1 Then pFindDisc = True
                                                        Next
                                                        If pFindDisc = True Then
                                                            'Проверка на занятость пары текущей группы
                                                            If Raspisanie(iFindDisc + 1, iGroup) = Nothing And Not Raspisanie(iFindDisc + 2, iGroup) = Nothing Then
                                                                p1Disc = True
                                                                i1Disc = iFindDisc
                                                                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingI1DiscChange))
                                                                Proverka = "[pFD-T-p1-T]"
                                                                GoTo Link_1_1_Raspisanie
                                                            Else 'Если пара занята
                                                                Continue For
                                                            End If
                                                        Else
                                                            Continue For
                                                        End If
                                                    End If
                                                Else 'Если нет деления
                                                    Continue For
                                                End If
                                            End If
                                    End If
                                    End If
                                End If
                            End If
                        Next
                    End If

                    useDisc = True
                End If

                If RaspisaniePreview = True And RaspisaniePreview = False Then
                    If p1Disc = False Then
                        If Raspisanie(iDisc, iGroup) = Nothing Then
                            Select Case iDisc / 5
                                Case 0, 1, 2
                                    frm_raspisanie_preview.DataGridView1.Rows(iDisc / 5).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 1, iGroup) & " / " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 3, 4, 5
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 1).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 1, iGroup) & " / " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 6, 7, 8
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 2).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 1, iGroup) & " / " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 9, 10, 11
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 3).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 1, iGroup) & " / " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 12, 13, 14
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 4).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 1, iGroup) & " / " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 15, 16, 17
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 5).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 1, iGroup) & " / " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 18
                                    frm_raspisanie_preview.DataGridView1.Rows(3).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 1, iGroup) & " / " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 19
                                    frm_raspisanie_preview.DataGridView1.Rows(7).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 1, iGroup) & " / " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 20
                                    frm_raspisanie_preview.DataGridView1.Rows(11).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 1, iGroup) & " / " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 21
                                    frm_raspisanie_preview.DataGridView1.Rows(15).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 1, iGroup) & " / " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 22
                                    frm_raspisanie_preview.DataGridView1.Rows(19).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 1, iGroup) & " / " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 23
                                    frm_raspisanie_preview.DataGridView1.Rows(23).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 1, iGroup) & " / " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                            End Select
                        Else
                            Select Case iDisc / 5
                                Case 0, 1, 2
                                    frm_raspisanie_preview.DataGridView1.Rows(iDisc / 5).Cells(iGroupDataGrid).Value = Raspisanie(iDisc, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 3, 4, 5
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 1).Cells(iGroupDataGrid).Value = Raspisanie(iDisc, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 6, 7, 8
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 2).Cells(iGroupDataGrid).Value = Raspisanie(iDisc, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 9, 10, 11
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 3).Cells(iGroupDataGrid).Value = Raspisanie(iDisc, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 12, 13, 14
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 4).Cells(iGroupDataGrid).Value = Raspisanie(iDisc, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 15, 16, 17
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 5).Cells(iGroupDataGrid).Value = Raspisanie(iDisc, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 18
                                    frm_raspisanie_preview.DataGridView1.Rows(3).Cells(iGroupDataGrid).Value = Raspisanie(iDisc, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 19
                                    frm_raspisanie_preview.DataGridView1.Rows(7).Cells(iGroupDataGrid).Value = Raspisanie(iDisc, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 20
                                    frm_raspisanie_preview.DataGridView1.Rows(11).Cells(iGroupDataGrid).Value = Raspisanie(iDisc, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 21
                                    frm_raspisanie_preview.DataGridView1.Rows(15).Cells(iGroupDataGrid).Value = Raspisanie(iDisc, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 22
                                    frm_raspisanie_preview.DataGridView1.Rows(19).Cells(iGroupDataGrid).Value = Raspisanie(iDisc, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                                Case 23
                                    frm_raspisanie_preview.DataGridView1.Rows(23).Cells(iGroupDataGrid).Value = Raspisanie(iDisc, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & " [" & Raspisanie(iDisc + 4, iGroup) & "]"
                            End Select
                        End If
                    Else
                        If Raspisanie(i1Disc, iGroup) = Nothing Then
                            Select Case i1Disc / 5
                                Case 0, 1, 2
                                    frm_raspisanie_preview.DataGridView1.Rows(i1Disc / 5).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc + 1, iGroup) & " / " & Raspisanie(i1Disc + 2, iGroup) & vbCrLf & Raspisanie(i1Disc + 3, iGroup) & " [" & Raspisanie(i1Disc + 4, iGroup) & "]"
                                Case 3, 4, 5
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 1).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc + 1, iGroup) & " / " & Raspisanie(i1Disc + 2, iGroup) & vbCrLf & Raspisanie(i1Disc + 3, iGroup) & " [" & Raspisanie(i1Disc + 4, iGroup) & "]"
                                Case 6, 7, 8
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 2).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc + 1, iGroup) & " / " & Raspisanie(i1Disc + 2, iGroup) & vbCrLf & Raspisanie(i1Disc + 3, iGroup) & " [" & Raspisanie(i1Disc + 4, iGroup) & "]"
                                Case 9, 10, 11
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 3).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc + 1, iGroup) & " / " & Raspisanie(i1Disc + 2, iGroup) & vbCrLf & Raspisanie(i1Disc + 3, iGroup) & " [" & Raspisanie(i1Disc + 4, iGroup) & "]"
                                Case 12, 13, 14
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 4).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc + 1, iGroup) & " / " & Raspisanie(i1Disc + 2, iGroup) & vbCrLf & Raspisanie(i1Disc + 3, iGroup) & " [" & Raspisanie(i1Disc + 4, iGroup) & "]"
                                Case 15, 16, 17
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 5).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc + 1, iGroup) & " / " & Raspisanie(i1Disc + 2, iGroup) & vbCrLf & Raspisanie(i1Disc + 3, iGroup) & " [" & Raspisanie(i1Disc + 4, iGroup) & "]"
                            End Select
                        Else
                            Select Case i1Disc / 5
                                Case 0, 1, 2
                                    frm_raspisanie_preview.DataGridView1.Rows(i1Disc / 5).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc, iGroup) & vbCrLf & Raspisanie(i1Disc + 3, iGroup) & " [" & Raspisanie(i1Disc + 4, iGroup) & "]"
                                Case 3, 4, 5
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 1).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc, iGroup) & vbCrLf & Raspisanie(i1Disc + 3, iGroup) & " [" & Raspisanie(i1Disc + 4, iGroup) & "]"
                                Case 6, 7, 8
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 2).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc, iGroup) & vbCrLf & Raspisanie(i1Disc + 3, iGroup) & " [" & Raspisanie(i1Disc + 4, iGroup) & "]"
                                Case 9, 10, 11
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 3).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc, iGroup) & vbCrLf & Raspisanie(i1Disc + 3, iGroup) & " [" & Raspisanie(i1Disc + 4, iGroup) & "]"
                                Case 12, 13, 14
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 4).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc, iGroup) & vbCrLf & Raspisanie(i1Disc + 3, iGroup) & " [" & Raspisanie(i1Disc + 4, iGroup) & "]"
                                Case 15, 16, 17
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 5).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc, iGroup) & vbCrLf & Raspisanie(i1Disc + 3, iGroup) & " [" & Raspisanie(i1Disc + 4, iGroup) & "]"
                            End Select
                        End If
                    End If
                    If Not i2Disc = 0 Then
                        If Raspisanie(i2Disc, iGroup) = Nothing Then
                            Select Case i2Disc / 5
                                Case 0, 1, 2
                                    frm_raspisanie_preview.DataGridView1.Rows(i2Disc / 5).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc + 1, iGroup) & " / " & Raspisanie(i2Disc + 2, iGroup) & vbCrLf & Raspisanie(i2Disc + 3, iGroup) & " [" & Raspisanie(i2Disc + 4, iGroup) & "]"
                                Case 3, 4, 5
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 1).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc + 1, iGroup) & " / " & Raspisanie(i2Disc + 2, iGroup) & vbCrLf & Raspisanie(i2Disc + 3, iGroup) & " [" & Raspisanie(i2Disc + 4, iGroup) & "]"
                                Case 6, 7, 8
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 2).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc + 1, iGroup) & " / " & Raspisanie(i2Disc + 2, iGroup) & vbCrLf & Raspisanie(i2Disc + 3, iGroup) & " [" & Raspisanie(i2Disc + 4, iGroup) & "]"
                                Case 9, 10, 11
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 3).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc + 1, iGroup) & " / " & Raspisanie(i2Disc + 2, iGroup) & vbCrLf & Raspisanie(i2Disc + 3, iGroup) & " [" & Raspisanie(i2Disc + 4, iGroup) & "]"
                                Case 12, 13, 14
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 4).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc + 1, iGroup) & " / " & Raspisanie(i2Disc + 2, iGroup) & vbCrLf & Raspisanie(i2Disc + 3, iGroup) & " [" & Raspisanie(i2Disc + 4, iGroup) & "]"
                                Case 15, 16, 17
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 5).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc + 1, iGroup) & " / " & Raspisanie(i2Disc + 2, iGroup) & vbCrLf & Raspisanie(i2Disc + 3, iGroup) & " [" & Raspisanie(i2Disc + 4, iGroup) & "]"
                            End Select
                        Else
                            Select Case i2Disc / 5
                                Case 0, 1, 2
                                    frm_raspisanie_preview.DataGridView1.Rows(i2Disc / 5).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc, iGroup) & vbCrLf & Raspisanie(i2Disc + 3, iGroup) & " [" & Raspisanie(i2Disc + 4, iGroup) & "]"
                                Case 3, 4, 5
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 1).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc, iGroup) & vbCrLf & Raspisanie(i2Disc + 3, iGroup) & " [" & Raspisanie(i2Disc + 4, iGroup) & "]"
                                Case 6, 7, 8
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 2).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc, iGroup) & vbCrLf & Raspisanie(i2Disc + 3, iGroup) & " [" & Raspisanie(i2Disc + 4, iGroup) & "]"
                                Case 9, 10, 11
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 3).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc, iGroup) & vbCrLf & Raspisanie(i2Disc + 3, iGroup) & " [" & Raspisanie(i2Disc + 4, iGroup) & "]"
                                Case 12, 13, 14
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 4).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc, iGroup) & vbCrLf & Raspisanie(i2Disc + 3, iGroup) & " [" & Raspisanie(i2Disc + 4, iGroup) & "]"
                                Case 15, 16, 17
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 5).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc, iGroup) & vbCrLf & Raspisanie(i2Disc + 3, iGroup) & " [" & Raspisanie(i2Disc + 4, iGroup) & "]"
                            End Select
                        End If
                    End If
                    frm_raspisanie_preview.Label1.Text = "Жду следущего распределения.."
                End If

                'Вывод только преподавателей
                If RaspisaniePreview = True Then
                    If p1Disc = False Then
                        If Raspisanie(iDisc, iGroup) = Nothing Then
                            Select Case iDisc / 5
                                Case 0, 1, 2
                                    frm_raspisanie_preview.DataGridView1.Rows(iDisc / 5).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                                Case 3, 4, 5
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 1).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                                Case 6, 7, 8
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 2).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                                Case 9, 10, 11
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 3).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                                Case 12, 13, 14
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 4).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                                Case 15, 16, 17
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 5).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                                Case 18
                                    frm_raspisanie_preview.DataGridView1.Rows(3).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                                Case 19
                                    frm_raspisanie_preview.DataGridView1.Rows(7).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                                Case 20
                                    frm_raspisanie_preview.DataGridView1.Rows(11).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                                Case 21
                                    frm_raspisanie_preview.DataGridView1.Rows(15).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                                Case 22
                                    frm_raspisanie_preview.DataGridView1.Rows(19).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                                Case 23
                                    frm_raspisanie_preview.DataGridView1.Rows(23).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                            End Select
                        Else
                            Select Case iDisc / 5
                                Case 0, 1, 2
                                    frm_raspisanie_preview.DataGridView1.Rows(iDisc / 5).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                                Case 3, 4, 5
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 1).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                                Case 6, 7, 8
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 2).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                                Case 9, 10, 11
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 3).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                                Case 12, 13, 14
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 4).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                                Case 15, 16, 17
                                    frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 5).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                                Case 18
                                    frm_raspisanie_preview.DataGridView1.Rows(3).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                                Case 19
                                    frm_raspisanie_preview.DataGridView1.Rows(7).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                                Case 20
                                    frm_raspisanie_preview.DataGridView1.Rows(11).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                                Case 21
                                    frm_raspisanie_preview.DataGridView1.Rows(15).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                                Case 22
                                    frm_raspisanie_preview.DataGridView1.Rows(19).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                                Case 23
                                    frm_raspisanie_preview.DataGridView1.Rows(23).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                            End Select
                        End If
                    Else
                        If Raspisanie(i1Disc, iGroup) = Nothing Then
                            Select Case i1Disc / 5
                                Case 0, 1, 2
                                    frm_raspisanie_preview.DataGridView1.Rows(i1Disc / 5).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(i1Disc + 3, iGroup)
                                Case 3, 4, 5
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 1).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(i1Disc + 3, iGroup)
                                Case 6, 7, 8
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 2).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(i1Disc + 3, iGroup)
                                Case 9, 10, 11
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 3).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(i1Disc + 3, iGroup)
                                Case 12, 13, 14
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 4).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(i1Disc + 3, iGroup)
                                Case 15, 16, 17
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 5).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(i1Disc + 3, iGroup)
                            End Select
                        Else
                            Select Case i1Disc / 5
                                Case 0, 1, 2
                                    frm_raspisanie_preview.DataGridView1.Rows(i1Disc / 5).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc + 3, iGroup)
                                Case 3, 4, 5
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 1).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc + 3, iGroup)
                                Case 6, 7, 8
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 2).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc + 3, iGroup)
                                Case 9, 10, 11
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 3).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc + 3, iGroup)
                                Case 12, 13, 14
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 4).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc + 3, iGroup)
                                Case 15, 16, 17
                                    frm_raspisanie_preview.DataGridView1.Rows((i1Disc / 5) + 5).Cells(iGroupDataGrid).Value = Raspisanie(i1Disc + 3, iGroup)
                            End Select
                        End If
                    End If
                    If Not i2Disc = 0 Then
                        If Raspisanie(i2Disc, iGroup) = Nothing Then
                            Select Case i2Disc / 5
                                Case 0, 1, 2
                                    frm_raspisanie_preview.DataGridView1.Rows(i2Disc / 5).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(i2Disc + 3, iGroup)
                                Case 3, 4, 5
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 1).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(i2Disc + 3, iGroup)
                                Case 6, 7, 8
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 2).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(i2Disc + 3, iGroup)
                                Case 9, 10, 11
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 3).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(i2Disc + 3, iGroup)
                                Case 12, 13, 14
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 4).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(i2Disc + 3, iGroup)
                                Case 15, 16, 17
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 5).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(i2Disc + 3, iGroup)
                            End Select
                        Else
                            Select Case i2Disc / 5
                                Case 0, 1, 2
                                    frm_raspisanie_preview.DataGridView1.Rows(i2Disc / 5).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc + 3, iGroup)
                                Case 3, 4, 5
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 1).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc + 3, iGroup)
                                Case 6, 7, 8
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 2).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc + 3, iGroup)
                                Case 9, 10, 11
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 3).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc + 3, iGroup)
                                Case 12, 13, 14
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 4).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc + 3, iGroup)
                                Case 15, 16, 17
                                    frm_raspisanie_preview.DataGridView1.Rows((i2Disc / 5) + 5).Cells(iGroupDataGrid).Value = Raspisanie(i2Disc + 3, iGroup)
                            End Select
                        End If
                    End If
                    frm_raspisanie_preview.Label1.Text = "Жду следущего распределения.."
                End If

                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then
                    If p1Disc = False Then
                        MsgBox("№ в массиве: " & (iDisc + 5) / 5 & vbCrLf & "Основная пара: " & Raspisanie(iDisc, iGroup) & vbCrLf & "Числитель: " & Raspisanie(iDisc + 1, iGroup) & vbCrLf & "Знаменатель: " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & "Преподаватель: " & Raspisanie(iDisc + 3, iGroup) & vbCrLf & "Кабинет: " & Raspisanie(iDisc + 4, iGroup) & vbCrLf & vbCrLf & "Добавил: " & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & " (ост. " & Disc(CurrentDisc, 1, iGroup) & " ч.)")
                    Else
                        MsgBox("№ в массиве: " & (i1Disc + 5) / 5 & vbCrLf & "Основная пара: " & Raspisanie(i1Disc, iGroup) & vbCrLf & "Числитель: " & Raspisanie(i1Disc + 1, iGroup) & vbCrLf & "Знаменатель: " & Raspisanie(i1Disc + 2, iGroup) & vbCrLf & "Преподаватель: " & Raspisanie(i1Disc + 3, iGroup) & vbCrLf & "Кабинет: " & Raspisanie(i1Disc + 4, iGroup) & vbCrLf & vbCrLf & "Добавил: " & objSheetWork.Range(EXCELDisciplines.Text & Mid(Disc(CurrentDisc, 0, iGroup), 1, Disc(CurrentDisc, 0, iGroup).ToString.IndexOf(";"))).Value & " (ост. " & Disc(CurrentDisc, 1, iGroup) & " ч.)")
                    End If
                End If

                If itmpDisc < 0 Then itmpDisc = 0
                iDisc = itmpDisc
                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                If OnMsgBox = True And OnMsgBoxCurrentGroup = True Then MsgBox("iDisc конец: " & iDisc, 4096)
            Next

            If RaspisaniePreview = True Then
                For iDisc = 0 To 85 Step 5
                    If Raspisanie(iDisc, iGroup) = Nothing Then
                        Select Case iDisc / 5
                            Case 0, 1, 2
                                frm_raspisanie_preview.DataGridView1.Rows(iDisc / 5).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                            Case 3, 4, 5
                                frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 1).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                            Case 6, 7, 8
                                frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 2).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                            Case 9, 10, 11
                                frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 3).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                            Case 12, 13, 14
                                frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 4).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                            Case 15, 16, 17
                                frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 5).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                            Case 18
                                frm_raspisanie_preview.DataGridView1.Rows(3).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                            Case 19
                                frm_raspisanie_preview.DataGridView1.Rows(7).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                            Case 20
                                frm_raspisanie_preview.DataGridView1.Rows(11).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                            Case 21
                                frm_raspisanie_preview.DataGridView1.Rows(15).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                            Case 22
                                frm_raspisanie_preview.DataGridView1.Rows(19).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                            Case 23
                                frm_raspisanie_preview.DataGridView1.Rows(23).Cells(iGroupDataGrid).Value = " / " & vbCrLf & Raspisanie(iDisc + 3, iGroup)
                        End Select
                    Else
                        Select Case iDisc / 5
                            Case 0, 1, 2
                                frm_raspisanie_preview.DataGridView1.Rows(iDisc / 5).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                            Case 3, 4, 5
                                frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 1).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                            Case 6, 7, 8
                                frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 2).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                            Case 9, 10, 11
                                frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 3).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                            Case 12, 13, 14
                                frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 4).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                            Case 15, 16, 17
                                frm_raspisanie_preview.DataGridView1.Rows((iDisc / 5) + 5).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                            Case 18
                                frm_raspisanie_preview.DataGridView1.Rows(3).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                            Case 19
                                frm_raspisanie_preview.DataGridView1.Rows(7).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                            Case 20
                                frm_raspisanie_preview.DataGridView1.Rows(11).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                            Case 21
                                frm_raspisanie_preview.DataGridView1.Rows(15).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                            Case 22
                                frm_raspisanie_preview.DataGridView1.Rows(19).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                            Case 23
                                frm_raspisanie_preview.DataGridView1.Rows(23).Cells(iGroupDataGrid).Value = Raspisanie(iDisc + 3, iGroup)
                        End Select
                    End If
                Next
                frm_raspisanie_preview.Label1.Text = "Жду следущего распределения.."
            End If

            If OnMsgBoxItog = True Then
                Beep()
                Select Case MsgBox("Нажмите ПРЕРВАТЬ для того что бы экспортировать в Excel" & vbCrLf & "Нажмите ПОВТОР для того что бы его просмотреть" & vbCrLf & "Нажмите ПРОПУСТИТЬ для продолжления цикла", 4130)
                    Case 3 ' Прервать
                        Exit For : GoTo 0
                    Case 4 ' Повтор
                        For iDisc = 0 To 115 Step 5
                            If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                            If (Raspisanie(iDisc, iGroup) = Nothing And (Raspisanie(iDisc + 1, iGroup) = Nothing Or Raspisanie(iDisc + 2, iGroup) = Nothing)) Or (Not Raspisanie(iDisc, iGroup) = Nothing And (Not Raspisanie(iDisc + 1, iGroup) = Nothing Or Not Raspisanie(iDisc + 2, iGroup) = Nothing)) Then 'Or (Not (Raspisanie(iDisc, iGroup) = Nothing And Raspisanie(iDisc + 1, iGroup) = Nothing And Raspisanie(iDisc + 2, iGroup) = Nothing)) Then
                                MsgBox("Группа: " & Groups(iGroup) & vbCrLf & vbCrLf & "№ в массиве: " & (iDisc + 5) / 5 & vbCrLf & "Основная пара: " & Raspisanie(iDisc, iGroup) & vbCrLf & "Числитель: " & Raspisanie(iDisc + 1, iGroup) & vbCrLf & "Знаменатель: " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & "Преподаватель: " & Raspisanie(iDisc + 3, iGroup) & vbCrLf & "Кабинет: " & Raspisanie(iDisc + 4, iGroup), MsgBoxStyle.Exclamation)
                            Else
                                MsgBox("Группа: " & Groups(iGroup) & vbCrLf & vbCrLf & "№ в массиве: " & (iDisc + 5) / 5 & vbCrLf & "Основная пара: " & Raspisanie(iDisc, iGroup) & vbCrLf & "Числитель: " & Raspisanie(iDisc + 1, iGroup) & vbCrLf & "Знаменатель: " & Raspisanie(iDisc + 2, iGroup) & vbCrLf & "Преподаватель: " & Raspisanie(iDisc + 3, iGroup) & vbCrLf & "Кабинет: " & Raspisanie(iDisc + 4, iGroup))
                            End If
                        Next
                    Case 5 ' Пропустить

                End Select
            End If

            If Int((10 / (Groups.GetUpperBound(0) + 1))) = 0 Then ProgressValue = ProgressValue + 1 Else ProgressValue = ProgressValue + Int((40 / (Groups.GetUpperBound(0) + 1)))
            Me.Invoke(New ThreadStart(AddressOf ProgressBarChange))
        Next

CreateExcel: LoadingLabelDescription = "Создание документа Microsoft Excel для заполнения расписанием"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
        'Создание документа для расписания
        Dim objBooksResult As Excel.Workbooks
        Dim objSheetsResult As Excel.Sheets
        Dim objSheetResult As Excel._Worksheet
        Dim objAppResult = CreateObject("Excel.Application")
        Dim objBookResult = objAppResult.Workbooks.Add

        Dim iDay As Integer = 1 'Текущий день недели в цикле
        Dim iCouple As Integer = 1 'Текущая пара в цикле

        objSheetResult = objBookResult.Worksheets(1)
        objSheetResult.Name = "На стенд"

        'Параметры шрифтов для расписания

        Dim fontHead As String = "Times New Roman"
        Dim fontCommonHead As String = "Times New Roman"
        Dim fontHeadGroupOne As String = "Times New Roman"
        Dim fontHeadGroupTwo As String = "Times New Roman"
        Dim fontDay As String = "Times New Roman"
        Dim fontCouple As String = "Times New Roman"
        Dim fontDiscipline As String = "Times New Roman"
        Dim fontTeacher As String = "Times New Roman"
        Dim fontCabinet As String = "Times New Roman"
        Dim sizeHead As Single = "16"
        Dim sizeCommonHead As Single = "20"
        Dim sizeHeadGroupOne As Single = "48"
        Dim sizeHeadGroupTwo As Single = "34"
        Dim sizeDay As Single = "24"
        Dim sizeCouple As Single = "24"
        Dim sizeDiscipline As Single = "16"
        Dim sizeTeacher As Single = "16"
        Dim sizeCabinet As Single = "16"
        Dim boldHead As Boolean = False
        Dim boldCommonHead As Boolean = True
        Dim boldHeadGroupOne As Boolean = True
        Dim boldHeadGroupTwo As Boolean = True
        Dim boldDay As Boolean = True
        Dim boldCouple As Boolean = True
        Dim boldDiscipline As Boolean = True
        Dim boldTeacher As Boolean = False
        Dim boldCabinet As Boolean = True
        Dim italicHead As Boolean = False
        Dim italicCommonHead As Boolean = False
        Dim italicHeadGroupOne As Boolean = False
        Dim italicHeadGroupTwo As Boolean = False
        Dim italicDay As Boolean = False
        Dim italicCouple As Boolean = False
        Dim italicDiscipline As Boolean = False
        Dim italicTeacher As Boolean = False
        Dim italicCabinet As Boolean = False
        Dim alignHead As Integer = 1
        Dim alignCommonHead As Integer = 3
        Dim alignHeadGroupOne As Integer = 3
        Dim alignHeadGroupTwo As Integer = 3
        Dim alignDay As Integer = 3
        Dim alignCouple As Integer = 3
        Dim alignDiscipline As Integer = 3
        Dim alignTeacher As Integer = 3
        Dim alignCabinet As Integer = 3
        Dim valignHead As Integer = 2
        Dim valignCommonHead As Integer = 2
        Dim valignHeadGroupOne As Integer = 2
        Dim valignHeadGroupTwo As Integer = 2
        Dim valignDay As Integer = 2
        Dim valignCouple As Integer = 2
        Dim valignDiscipline As Integer = 2
        Dim valignTeacher As Integer = 2
        Dim valignCabinet As Integer = 2

        Dim SttRow As Integer
        Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            SettingFile = reader.ReadLine() '[TimetableKRU]
            For SttRow = 1 To 30
                reader.ReadLine()
            Next
            Dim ReadfontHead As String = Mid(reader.ReadLine(), Len("fontHead=") + 1)
            Dim ReadfontCommonHead As String = Mid(reader.ReadLine(), Len("fontCommonHead=") + 1)
            Dim ReadfontHeadGroupOne As String = Mid(reader.ReadLine(), Len("fontHeadGroupOne=") + 1)
            Dim ReadfontHeadGroupTwo As String = Mid(reader.ReadLine(), Len("fontHeadGroupTwo=") + 1)
            Dim ReadfontDay As String = Mid(reader.ReadLine(), Len("fontDay=") + 1)
            Dim ReadfontCouple As String = Mid(reader.ReadLine(), Len("fontCouple=") + 1)
            Dim ReadfontDiscipline As String = Mid(reader.ReadLine(), Len("fontDiscipline=") + 1)
            Dim ReadfontTeacher As String = Mid(reader.ReadLine(), Len("fontTeacher=") + 1)
            Dim ReadfontCabinet As String = Mid(reader.ReadLine(), Len("fontCabinet=") + 1)
            Dim ReadsizeHead As String = Mid(reader.ReadLine(), Len("sizeHead=") + 1)
            Dim ReadsizeCommonHead As String = Mid(reader.ReadLine(), Len("sizeCommonHead=") + 1)
            Dim ReadsizeHeadGroupOne As String = Mid(reader.ReadLine(), Len("sizeHeadGroupOne=") + 1)
            Dim ReadsizeHeadGroupTwo As String = Mid(reader.ReadLine(), Len("sizeHeadGroupTwo=") + 1)
            Dim ReadsizeDay As String = Mid(reader.ReadLine(), Len("sizeDay=") + 1)
            Dim ReadsizeCouple As String = Mid(reader.ReadLine(), Len("sizeCouple=") + 1)
            Dim ReadsizeDiscipline As String = Mid(reader.ReadLine(), Len("sizeDiscipline=") + 1)
            Dim ReadsizeTeacher As String = Mid(reader.ReadLine(), Len("sizeTeacher=") + 1)
            Dim ReadsizeCabinet As String = Mid(reader.ReadLine(), Len("sizeCabinet=") + 1)
            Dim ReadboldHead As String = Mid(reader.ReadLine(), Len("boldHead=") + 1)
            Dim ReadboldCommonHead As String = Mid(reader.ReadLine(), Len("boldCommonHead=") + 1)
            Dim ReadboldHeadGroupOne As String = Mid(reader.ReadLine(), Len("boldHeadGroupOne=") + 1)
            Dim ReadboldHeadGroupTwo As String = Mid(reader.ReadLine(), Len("boldHeadGroupTwo=") + 1)
            Dim ReadboldDay As String = Mid(reader.ReadLine(), Len("boldDay=") + 1)
            Dim ReadboldCouple As String = Mid(reader.ReadLine(), Len("boldCouple=") + 1)
            Dim ReadboldDiscipline As String = Mid(reader.ReadLine(), Len("boldDiscipline=") + 1)
            Dim ReadboldTeacher As String = Mid(reader.ReadLine(), Len("boldTeacher=") + 1)
            Dim ReadboldCabinet As String = Mid(reader.ReadLine(), Len("boldCabinet=") + 1)
            Dim ReaditalicHead As String = Mid(reader.ReadLine(), Len("italicHead=") + 1)
            Dim ReaditalicCommonHead As String = Mid(reader.ReadLine(), Len("italicCommonHead=") + 1)
            Dim ReaditalicHeadGroupOne As String = Mid(reader.ReadLine(), Len("italicHeadGroupOne=") + 1)
            Dim ReaditalicHeadGroupTwo As String = Mid(reader.ReadLine(), Len("italicHeadGroupTwo=") + 1)
            Dim ReaditalicDay As String = Mid(reader.ReadLine(), Len("italicDay=") + 1)
            Dim ReaditalicCouple As String = Mid(reader.ReadLine(), Len("italicCouple=") + 1)
            Dim ReaditalicDiscipline As String = Mid(reader.ReadLine(), Len("italicDiscipline=") + 1)
            Dim ReaditalicTeacher As String = Mid(reader.ReadLine(), Len("italicTeacher=") + 1)
            Dim ReaditalicCabinet As String = Mid(reader.ReadLine(), Len("italicCabinet=") + 1)
            Dim ReadalignHead As String = Mid(reader.ReadLine(), Len("alignHead=") + 1)
            Dim ReadalignCommonHead As String = Mid(reader.ReadLine(), Len("alignCommonHead=") + 1)
            Dim ReadalignHeadGroupOne As String = Mid(reader.ReadLine(), Len("alignHeadGroupOne=") + 1)
            Dim ReadalignHeadGroupTwo As String = Mid(reader.ReadLine(), Len("alignHeadGroupTwo=") + 1)
            Dim ReadalignDay As String = Mid(reader.ReadLine(), Len("alignDay=") + 1)
            Dim ReadalignCouple As String = Mid(reader.ReadLine(), Len("alignCouple=") + 1)
            Dim ReadalignDiscipline As String = Mid(reader.ReadLine(), Len("alignDiscipline=") + 1)
            Dim ReadalignTeacher As String = Mid(reader.ReadLine(), Len("alignTeacher=") + 1)
            Dim ReadalignCabinet As String = Mid(reader.ReadLine(), Len("alignCabinet=") + 1)
            Dim ReadvalignHead As String = Mid(reader.ReadLine(), Len("valignHead=") + 1)
            Dim ReadvalignCommonHead As String = Mid(reader.ReadLine(), Len("valignCommonHead=") + 1)
            Dim ReadvalignHeadGroupOne As String = Mid(reader.ReadLine(), Len("valignHeadGroupOne=") + 1)
            Dim ReadvalignHeadGroupTwo As String = Mid(reader.ReadLine(), Len("valignHeadGroupTwo=") + 1)
            Dim ReadvalignDay As String = Mid(reader.ReadLine(), Len("valignDay=") + 1)
            Dim ReadvalignCouple As String = Mid(reader.ReadLine(), Len("valignCouple=") + 1)
            Dim ReadvalignDiscipline As String = Mid(reader.ReadLine(), Len("valignDiscipline=") + 1)
            Dim ReadvalignTeacher As String = Mid(reader.ReadLine(), Len("valignTeacher=") + 1)
            Dim ReadvalignCabinet As String = Mid(reader.ReadLine(), Len("valignCabinet=") + 1)
            If Not ReadfontHead = "" Then fontHead = ReadfontHead
            If Not ReadfontCommonHead = "" Then fontCommonHead = ReadfontCommonHead
            If Not ReadfontHeadGroupOne = "" Then fontHeadGroupOne = ReadfontHeadGroupOne
            If Not ReadfontHeadGroupTwo = "" Then fontHeadGroupTwo = ReadfontHeadGroupTwo
            If Not ReadfontDay = "" Then fontDay = ReadfontDay
            If Not ReadfontCouple = "" Then fontCouple = ReadfontCouple
            If Not ReadfontDiscipline = "" Then fontDiscipline = ReadfontDiscipline
            If Not ReadfontTeacher = "" Then fontTeacher = ReadfontTeacher
            If Not ReadfontCabinet = "" Then fontCabinet = ReadfontCabinet
            If Not ReadsizeHead = "" Then sizeHead = ReadsizeHead
            If Not ReadsizeCommonHead = "" Then sizeCommonHead = ReadsizeCommonHead
            If Not ReadsizeHeadGroupOne = "" Then sizeHeadGroupOne = ReadsizeHeadGroupOne
            If Not ReadsizeHeadGroupTwo = "" Then sizeHeadGroupTwo = ReadsizeHeadGroupTwo
            If Not ReadsizeDay = "" Then sizeDay = ReadsizeDay
            If Not ReadsizeCouple = "" Then sizeCouple = ReadsizeCouple
            If Not ReadsizeDiscipline = "" Then sizeDiscipline = ReadsizeDiscipline
            If Not ReadsizeTeacher = "" Then sizeTeacher = ReadsizeTeacher
            If Not ReadsizeCabinet = "" Then sizeCabinet = ReadsizeCabinet
            If Not ReadboldHead = "" Then boldHead = ReadboldHead
            If Not ReadboldCommonHead = "" Then boldCommonHead = ReadboldCommonHead
            If Not ReadboldHeadGroupOne = "" Then boldHeadGroupOne = ReadboldHeadGroupOne
            If Not ReadboldHeadGroupTwo = "" Then boldHeadGroupTwo = ReadboldHeadGroupTwo
            If Not ReadboldDay = "" Then boldDay = ReadboldDay
            If Not ReadboldCouple = "" Then boldCouple = ReadboldCouple
            If Not ReadboldDiscipline = "" Then boldDiscipline = ReadboldDiscipline
            If Not ReadboldTeacher = "" Then boldTeacher = ReadboldTeacher
            If Not ReadboldCabinet = "" Then boldCabinet = ReadboldCabinet
            If Not ReaditalicHead = "" Then italicHead = ReaditalicHead
            If Not ReaditalicCommonHead = "" Then italicCommonHead = ReaditalicCommonHead
            If Not ReaditalicHeadGroupOne = "" Then italicHeadGroupOne = ReaditalicHeadGroupOne
            If Not ReaditalicHeadGroupTwo = "" Then italicHeadGroupTwo = ReaditalicHeadGroupTwo
            If Not ReaditalicDay = "" Then italicDay = ReaditalicDay
            If Not ReaditalicCouple = "" Then italicCouple = ReaditalicCouple
            If Not ReaditalicDiscipline = "" Then italicDiscipline = ReaditalicDiscipline
            If Not ReaditalicTeacher = "" Then italicTeacher = ReaditalicTeacher
            If Not ReaditalicCabinet = "" Then italicCabinet = ReaditalicCabinet
            If Not ReadalignHead = "" Then alignHead = ReadalignHead
            If Not ReadalignCommonHead = "" Then alignCommonHead = ReadalignCommonHead
            If Not ReadalignHeadGroupOne = "" Then alignHeadGroupOne = ReadalignHeadGroupOne
            If Not ReadalignHeadGroupTwo = "" Then alignHeadGroupTwo = ReadalignHeadGroupTwo
            If Not ReadalignDay = "" Then alignDay = ReadalignDay
            If Not ReadalignCouple = "" Then alignCouple = ReadalignCouple
            If Not ReadalignDiscipline = "" Then alignDiscipline = ReadalignDiscipline
            If Not ReadalignTeacher = "" Then alignTeacher = ReadalignTeacher
            If Not ReadalignCabinet = "" Then alignCabinet = ReadalignCabinet
            If Not ReadvalignHead = "" Then valignHead = ReadvalignHead
            If Not ReadvalignCommonHead = "" Then valignCommonHead = ReadvalignCommonHead
            If Not ReadvalignHeadGroupOne = "" Then valignHeadGroupOne = ReadvalignHeadGroupOne
            If Not ReadvalignHeadGroupTwo = "" Then valignHeadGroupTwo = ReadvalignHeadGroupTwo
            If Not ReadvalignDay = "" Then valignDay = ReadvalignDay
            If Not ReadvalignCouple = "" Then valignCouple = ReadvalignCouple
            If Not ReadvalignDiscipline = "" Then valignDiscipline = ReadvalignDiscipline
            If Not ReadvalignTeacher = "" Then valignTeacher = ReadvalignTeacher
            If Not ReadvalignCabinet = "" Then valignCabinet = ReadvalignCabinet
        End Using

        CurrentSubProcess = "ЗаполненениеДокументаРасписанием"
        Me.Invoke(New ThreadStart(AddressOf LoadingImageChange))

        LoadingLabelDescription = "Заполнение грифа утверждения документа"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))

        'Гриф утверждения документа
        Dim v0, v1, v2, v3, v4, v5 As String 'Пользовательские значения для грифа утверждения
        Dim s0, s1, s2, s3, s4, s5 As String 'Значения по умолчанию для грифа утверждения
        Dim m As String = Date.Now.Month
        Dim EXCELHeadFirstCol As String
        Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            reader.ReadLine() '[TimetableKRU]
            For SttRow = 1 To 9
                reader.ReadLine()
            Next
            Select Case m
                Case Is = 1
                    m = "января"
                Case Is = 2
                    m = "февраля"
                Case Is = 3
                    m = "марта"
                Case Is = 4
                    m = "апреля"
                Case Is = 5
                    m = "мая"
                Case Is = 6
                    m = "июня"
                Case Is = 7
                    m = "июля"
                Case Is = 8
                    m = "августа"
                Case Is = 9
                    m = "сентября"
                Case Is = 10
                    m = "октября"
                Case Is = 11
                    m = "ноября"
                Case Is = 12
                    m = "декабря"
            End Select
            s0 = "AI"
            s1 = "EXCELHead1Row=УТВЕРЖДАЮ:"
            s2 = "EXCELHead2Row=И.о. директора Котласского Филиала"
            s3 = "EXCELHead3Row=ФГБОУ ВО " & Chr(34) & "ГУМРФ имени адмирала С.О.Макарова" & Chr(34)
            s4 = "EXCELHead4Row=Э.А. Брессель"
            s5 = "EXCELHead5Row=" & Date.Now.Day & " " & m & " " & Date.Now.Year
            If Mid(reader.ReadLine, 28) = "True" Then
                If (Groups.GetUpperBound(0) - 2) <= 0 Then EXCELHeadFirstCol = "C" Else EXCELHeadFirstCol = ConvertToLetter(1 + (Groups.GetUpperBound(0) - 2) * 2)
                reader.ReadLine()
            Else
                v0 = Mid(reader.ReadLine(), 19)
                If v0 = "" Then
                    Me.Invoke(New ThreadStart(AddressOf TimerEnabledDisabled))
                    MsgBox("У вас не указан первый столбец, с которого начинается заполнение шапки!" & vbCrLf & "Значение будет выставлено по умолчанию.", MsgBoxStyle.Exclamation, "Расписание КРУ: Ошибка чтения значения!")
                    Me.Invoke(New ThreadStart(AddressOf TimerEnabledDisabled))
                    EXCELHeadFirstCol = s0
                Else
                    EXCELHeadFirstCol = v0
                End If
            End If
            v1 = Mid(reader.ReadLine(), 15)
            v2 = Mid(reader.ReadLine(), 15)
            v3 = Mid(reader.ReadLine(), 15)
            v4 = Mid(reader.ReadLine(), 15)
            v5 = Mid(reader.ReadLine(), 15)
        End Using
        If v1 = "[null]" Then
            objSheetResult.Range(EXCELHeadFirstCol & "1").Value = ""
        ElseIf v1 = "" Then
            objSheetResult.Range(EXCELHeadFirstCol & "1").Value = Mid(s1, 15)
        Else
            objSheetResult.Range(EXCELHeadFirstCol & "1").Value = v1
        End If
        If v2 = "[null]" Then
            objSheetResult.Range(EXCELHeadFirstCol & "2").Value = ""
        ElseIf v2 = "" Then
            objSheetResult.Range(EXCELHeadFirstCol & "2").Value = Mid(s2, 15)
        Else
            objSheetResult.Range(EXCELHeadFirstCol & "2").Value = v2
        End If
        If v3 = "[null]" Then
            objSheetResult.Range(EXCELHeadFirstCol & "3").Value = ""
        ElseIf v3 = "" Then
            objSheetResult.Range(EXCELHeadFirstCol & "3").Value = Mid(s3, 15)
        Else
            objSheetResult.Range(EXCELHeadFirstCol & "3").Value = v3
        End If
        If v4 = "[null]" Then
            objSheetResult.Cells(4, objSheetResult.Columns(EXCELHeadFirstCol).Column() + 2) = ""
        ElseIf v4 = "" Then
            objSheetResult.Cells(4, objSheetResult.Columns(EXCELHeadFirstCol).Column() + 2) = Mid(s4, 15)
        Else
            objSheetResult.Cells(4, objSheetResult.Columns(EXCELHeadFirstCol).Column() + 2) = v4
        End If
        If v5 = "[null]" Then
            objSheetResult.Range(EXCELHeadFirstCol & "5").Value = ""
        ElseIf v5 = "" Then
            objSheetResult.Range(EXCELHeadFirstCol & "5").Value = Mid(s5, 15)
        Else
            objSheetResult.Range(EXCELHeadFirstCol & "5").Value = v5
        End If

        With objSheetResult.Range(EXCELHeadFirstCol & "1:" & ConvertToLetter(objSheetResult.Columns(EXCELHeadFirstCol).Column() + 2) & "5")
            If boldHead = True Then .Font.Bold = True Else .Font.Bold = False
            If italicHead = True Then .Font.Italic = True Else .Font.Italic = False
            .Font.Name = fontHead
            .Font.Size = sizeHead
            .HorizontalAlignment = alignHead
            .VerticalAlignment = valignHead
        End With

        LoadingLabelDescription = "Заполнение документа общей шапкой"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))

        'Общая шапка
        objSheetResult.Range("A6:" & ConvertToLetter(((Groups.GetUpperBound(0) + 1) * 2) + 2) & "6").Merge()
        With objSheetResult.Range("A6")
            .Value = "РАСПИСАНИЕ УЧЕБНЫХ ЗАНЯТИЙ НА " & Semestr & " СЕМЕСТР " & Me.NumericUpDownYears1.Value & "-" & Me.NumericUpDownYears2.Value & " УЧЕБНОГО ГОДА"
            If boldCommonHead = True Then .Font.Bold = True Else .Font.Bold = False
            If italicCommonHead = True Then .Font.Italic = True Else .Font.Italic = False
            .Font.Name = fontCommonHead
            .Font.Size = sizeCommonHead
            .HorizontalAlignment = alignCommonHead
            .VerticalAlignment = valignCommonHead
            .RowHeight = 2.3 * sizeCommonHead
        End With

        LoadingLabelDescription = "Заполнение документа днями недели"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))

        'Дни недели
        objSheetResult.Range("A8:A15").Merge()
        objSheetResult.Range("A16:A23").Merge()
        objSheetResult.Range("A24:A31").Merge()
        objSheetResult.Range("A32:A39").Merge()
        objSheetResult.Range("A40:A47").Merge()
        objSheetResult.Range("A48:A53").Merge()
        objSheetResult.Range("A8").Value = "Понедельник"
        objSheetResult.Range("A16").Value = "Вторник"
        objSheetResult.Range("A24").Value = "Среда"
        objSheetResult.Range("A32").Value = "Четверг"
        objSheetResult.Range("A40").Value = "Пятница"
        objSheetResult.Range("A48").Value = "Суббота"
        With objSheetResult.Range("A8:A53")
            If boldDay = True Then .Font.Bold = True Else .Font.Bold = False
            If italicDay = True Then .Font.Italic = True Else .Font.Italic = False
            .Font.Name = fontDay
            .Font.Size = sizeDay
            .Orientation = "90"
            .HorizontalAlignment = alignDay
            .VerticalAlignment = valignDay
            .EntireColumn.AutoFit()
            .ColumnWidth = 0.35416666666666669 * sizeDay
        End With

        LoadingLabelDescription = "Заполнение документа номерами пар"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))

        'Пары
        For iDay = 8 To 40 Step 8
            objSheetResult.Range("B" & iDay & ":B" & (iDay + 1)).Merge()
            objSheetResult.Range("B" & iDay).Value = "1"
            objSheetResult.Range("B" & (iDay + 2) & ":B" & (iDay + 3)).Merge()
            objSheetResult.Range("B" & (iDay + 2)).Value = "2"
            objSheetResult.Range("B" & (iDay + 4) & ":B" & (iDay + 5)).Merge()
            objSheetResult.Range("B" & (iDay + 4)).Value = "3"
            objSheetResult.Range("B" & (iDay + 6) & ":B" & (iDay + 7)).Merge()
            objSheetResult.Range("B" & (iDay + 6)).Value = "4"
        Next
        objSheetResult.Range("B" & iDay & ":B" & (iDay + 1)).Merge()
        objSheetResult.Range("B" & iDay).Value = "1"
        objSheetResult.Range("B" & (iDay + 2) & ":B" & (iDay + 3)).Merge()
        objSheetResult.Range("B" & (iDay + 2)).Value = "2"
        objSheetResult.Range("B" & (iDay + 4) & ":B" & (iDay + 5)).Merge()
        objSheetResult.Range("B" & (iDay + 4)).Value = "3"
        With objSheetResult.Range("B8:B53")
            If boldCouple = True Then .Font.Bold = True Else .Font.Bold = False
            If italicCouple = True Then .Font.Italic = True Else .Font.Italic = False
            .Font.Name = fontCouple
            .Font.Size = sizeCouple
            .HorizontalAlignment = alignCouple
            .VerticalAlignment = valignCouple
            .EntireColumn.AutoFit()
            .ColumnWidth = 0.35416666666666669 * sizeCouple
            .RowHeight = 2.5 * sizeCouple
        End With

        'Заполнение документа расписанием
        Dim add As Integer = 0 'Переменная для прибавления к числу
        Dim add2 As Integer = 0 'Переменная для прибавления к числу 2 после первой итерации
        Dim rCouple As Integer = 8 'Строчка текущей пары
        Dim kCouple As Integer = 1 'Номер пары по счёту
        Dim tmpValue As String = "" 'Временное значение ячейки
        objSheetResult.Range("A7:B7").Merge()
        LoadingLabelDescription = "Заполнение документа расписанием"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
        For iGroup = 0 To Groups.GetUpperBound(0)
            LoadingLabelDescriptionHead = "Обрабатывается " & iGroup + 1 & " группа из " & Groups.GetUpperBound(0) + 1 & ": " & Groups(iGroup)
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionHeadChange))

            'Название группы
            If Groups(iGroup).IndexOf(" ") = -1 Then
                objSheetResult.Range(ConvertToLetter(iGroup + 3 + add) & "7:" & ConvertToLetter(iGroup + 4 + add) & "7").Merge()
                With objSheetResult.Range(ConvertToLetter(iGroup + 3 + add) & "7")
                    .Value = Groups(iGroup)
                    If boldHeadGroupOne = True Then .Font.Bold = True Else .Font.Bold = False
                    If italicHeadGroupOne = True Then .Font.Italic = True Else .Font.Italic = False
                    .Font.Name = fontHeadGroupOne
                    .Font.Size = sizeHeadGroupOne
                    .HorizontalAlignment = alignHeadGroupOne
                    .VerticalAlignment = valignHeadGroupOne
                End With
                If sizeHeadGroupOne > sizeHeadGroupTwo Then objSheetResult.Range(ConvertToLetter(iGroup + 3 + add) & "7:" & ConvertToLetter(iGroup + 4 + add) & "7").ColumnWidth = 0.35416666666666669 * sizeHeadGroupOne Else objSheetResult.Range(ConvertToLetter(iGroup + 3 + add) & "7:" & ConvertToLetter(iGroup + 4 + add) & "7").ColumnWidth = 0.35416666666666669 * sizeHeadGroupTwo
            Else
                objSheetResult.Range(ConvertToLetter(iGroup + 3 + add) & "7").Value = Mid(Groups(iGroup), 1, Groups(iGroup).IndexOf(" "))
                objSheetResult.Range(ConvertToLetter(iGroup + 4 + add) & "7").Value = Mid(Groups(iGroup), Groups(iGroup).IndexOf(" ") + 2)
                With objSheetResult.Range(ConvertToLetter(iGroup + 3 + add) & "7:" & ConvertToLetter(iGroup + 4 + add) & "7")
                    If boldHeadGroupTwo = True Then .Font.Bold = True Else .Font.Bold = False
                    If italicHeadGroupTwo = True Then .Font.Italic = True Else .Font.Italic = False
                    .Font.Name = fontHeadGroupTwo
                    .Font.Size = sizeHeadGroupTwo
                    .HorizontalAlignment = alignHeadGroupTwo
                    .VerticalAlignment = valignHeadGroupTwo
                    If sizeHeadGroupOne > sizeHeadGroupTwo Then .ColumnWidth = 0.35416666666666669 * sizeHeadGroupOne * 1.2 Else .ColumnWidth = 0.35416666666666669 * sizeHeadGroupTwo
                End With
            End If

            'Пары
            kCouple = 1
            rCouple = 8
            For iDisc = 0 To 115 Step 5
                If OutPut_iDisc = True Then Me.Invoke(New ThreadStart(AddressOf LoadingIDiscChange))
                tmpValue = ""
                If iDisc = 90 Then
                    rCouple = 14
                End If
                'Если целая пара
                If Not Raspisanie(iDisc, iGroup) = Nothing Then
                    'Если нет деления по группам
                    If Raspisanie(iDisc, iGroup).ToString.IndexOf(";") = -1 Then
                        objSheetResult.Range(ConvertToLetter(iGroup + 3 + add) & rCouple & ":" & ConvertToLetter(iGroup + 4 + add) & rCouple + 1).Merge()
                        objSheetResult.Cells(rCouple, iGroup + 3 + add) = Raspisanie(iDisc, iGroup) & vbCrLf & Raspisanie(iDisc + 3, iGroup) & vbCrLf & Raspisanie(iDisc + 4, iGroup)
                        With objSheetResult.Cells(rCouple, iGroup + 3 + add).Characters(1, Len(Raspisanie(iDisc, iGroup))).Font
                            If boldDiscipline = True Then .Bold = True Else .Bold = False
                            If italicDiscipline = True Then .Italic = True Else .Italic = False
                            .Name = fontDiscipline
                            .Size = sizeDiscipline
                        End With
                        With objSheetResult.Cells(rCouple, iGroup + 3 + add).Characters(Len(Raspisanie(iDisc, iGroup)) + 3, Len(Raspisanie(iDisc + 3, iGroup))).Font
                            If boldTeacher = True Then .Bold = True Else .Bold = False
                            If italicTeacher = True Then .Italic = True Else .Italic = False
                            .Name = fontTeacher
                            .Size = sizeTeacher
                        End With
                        With objSheetResult.Cells(rCouple, iGroup + 3 + add).Characters(Len(Raspisanie(iDisc, iGroup)) + Len(Raspisanie(iDisc + 3, iGroup)) + 5, Len(Raspisanie(iDisc + 4, iGroup))).Font
                            If boldCabinet = True Then .Bold = True Else .Bold = False
                            If italicCabinet = True Then .Italic = True Else .Italic = False
                            .Name = fontCabinet
                            .Size = sizeCabinet
                        End With
                    Else 'Если есть деление по группам
                        objSheetResult.Range(ConvertToLetter(iGroup + 3 + add) & rCouple & ":" & ConvertToLetter(iGroup + 3 + add) & rCouple + 1).Merge()
                        tmpValue = Mid(Raspisanie(iDisc, iGroup), 1, Raspisanie(iDisc, iGroup).ToString.IndexOf(";"))
                        If Not Raspisanie(iDisc + 3, iGroup) = Nothing Then If Not Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & vbCrLf & Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";"))
                        If Not Raspisanie(iDisc + 4, iGroup) = Nothing Then If Not Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & vbCrLf & Mid(Raspisanie(iDisc + 4, iGroup), 1, Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";"))
                        objSheetResult.Cells(rCouple, iGroup + 3 + add) = tmpValue
                        With objSheetResult.Cells(rCouple, iGroup + 3 + add).Characters(1, Len(Mid(Raspisanie(iDisc, iGroup), 1, Raspisanie(iDisc, iGroup).ToString.IndexOf(";")))).Font
                            If boldDiscipline = True Then .Bold = True Else .Bold = False
                            If italicDiscipline = True Then .Italic = True Else .Italic = False
                            .Name = fontDiscipline
                            .Size = sizeDiscipline
                        End With
                        With objSheetResult.Cells(rCouple, iGroup + 3 + add).Characters(Len(Mid(Raspisanie(iDisc, iGroup), 1, Raspisanie(iDisc, iGroup).ToString.IndexOf(";"))) + 3, Len(Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";")))).Font
                            If boldTeacher = True Then .Bold = True Else .Bold = False
                            If italicTeacher = True Then .Italic = True Else .Italic = False
                            .Name = fontTeacher
                            .Size = sizeTeacher
                        End With
                        With objSheetResult.Cells(rCouple, iGroup + 3 + add).Characters(Len(Mid(Raspisanie(iDisc, iGroup), 1, Raspisanie(iDisc, iGroup).ToString.IndexOf(";"))) + Len(Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";"))) + 5, Len(Mid(Raspisanie(iDisc + 4, iGroup), 1, Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";")))).Font
                            If boldCabinet = True Then .Bold = True Else .Bold = False
                            If italicCabinet = True Then .Italic = True Else .Italic = False
                            .Name = fontCabinet
                            .Size = sizeCabinet
                        End With
                        objSheetResult.Range(ConvertToLetter(iGroup + 4 + add) & rCouple & ":" & ConvertToLetter(iGroup + 4 + add) & rCouple + 1).Merge()
                        tmpValue = Mid(Raspisanie(iDisc, iGroup), Raspisanie(iDisc, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc, iGroup)) - (Raspisanie(iDisc, iGroup).ToString.IndexOf(";") + 4))
                        If Not Raspisanie(iDisc + 3, iGroup) = Nothing Then If Not Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & vbCrLf & Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 3, iGroup)) - (Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 4))
                        If Not Raspisanie(iDisc + 4, iGroup) = Nothing Then If Not Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & vbCrLf & Mid(Raspisanie(iDisc + 4, iGroup), Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 4, iGroup)) - (Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 4))
                        objSheetResult.Cells(rCouple, iGroup + 4 + add) = tmpValue
                        With objSheetResult.Cells(rCouple, iGroup + 4 + add).Characters(1, Len(Mid(Raspisanie(iDisc, iGroup), Raspisanie(iDisc, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc, iGroup)) - (Raspisanie(iDisc, iGroup).ToString.IndexOf(";") + 4)))).Font
                            If boldDiscipline = True Then .Bold = True Else .Bold = False
                            If italicDiscipline = True Then .Italic = True Else .Italic = False
                            .Name = fontDiscipline
                            .Size = sizeDiscipline
                        End With
                        With objSheetResult.Cells(rCouple, iGroup + 4 + add).Characters(Len(Mid(Raspisanie(iDisc, iGroup), Raspisanie(iDisc, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc, iGroup)) - (Raspisanie(iDisc, iGroup).ToString.IndexOf(";") + 4))) + 3, Len(Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 3, iGroup)) - (Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 4)))).Font
                            If boldTeacher = True Then .Bold = True Else .Bold = False
                            If italicTeacher = True Then .Italic = True Else .Italic = False
                            .Name = fontTeacher
                            .Size = sizeTeacher
                        End With
                        With objSheetResult.Cells(rCouple, iGroup + 4 + add).Characters(Len(Mid(Raspisanie(iDisc, iGroup), Raspisanie(iDisc, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc, iGroup)) - (Raspisanie(iDisc, iGroup).ToString.IndexOf(";") + 4))) + Len(Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 3, iGroup)) - (Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 4))) + 5, Len(Mid(Raspisanie(iDisc + 4, iGroup), Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 4, iGroup)) - (Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 4)))).Font
                            If boldCabinet = True Then .Bold = True Else .Bold = False
                            If italicCabinet = True Then .Italic = True Else .Italic = False
                            .Name = fontCabinet
                            .Size = sizeCabinet
                        End With
                    End If
                Else 'Если числитель и знаменатель
                    If Not Raspisanie(iDisc + 1, iGroup) = Nothing And Not Raspisanie(iDisc + 2, iGroup) = Nothing Then
                        'Если в числителе деление
                        If Not Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";") = -1 Then
                            tmpValue = Mid(Raspisanie(iDisc + 1, iGroup), 1, Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";"))
                            If Not Raspisanie(iDisc + 3, iGroup) = Nothing Then
                                If Not Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") = -1 Then
                                    tmpPrepod = Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";"))
                                    For i1Sym = 1 To Len(tmpPrepod)
                                        If Mid(tmpPrepod, i1Sym, 1) = " " Then tmpPrepod = Mid(tmpPrepod, 1, i1Sym - 1) : Exit For
                                    Next
                                    tmpValue = tmpValue & vbCrLf & tmpPrepod
                                End If
                            End If
                            If Not Raspisanie(iDisc + 4, iGroup) = Nothing Then If Not Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & vbCrLf & Mid(Raspisanie(iDisc + 4, iGroup), 1, Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";"))
                            objSheetResult.Cells(rCouple, iGroup + 3 + add) = tmpValue
                            With objSheetResult.Cells(rCouple, iGroup + 3 + add).Characters(1, Len(Mid(Raspisanie(iDisc + 1, iGroup), 1, Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";")))).Font
                                If boldDiscipline = True Then .Bold = True Else .Bold = False
                                If italicDiscipline = True Then .Italic = True Else .Italic = False
                                .Name = fontDiscipline
                                .Size = sizeDiscipline
                            End With
                            With objSheetResult.Cells(rCouple, iGroup + 3 + add).Characters(Len(Mid(Raspisanie(iDisc + 1, iGroup), 1, Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";"))) + 3, Len(tmpPrepod)).Font
                                If boldTeacher = True Then .Bold = True Else .Bold = False
                                If italicTeacher = True Then .Italic = True Else .Italic = False
                                .Name = fontTeacher
                                .Size = sizeTeacher
                            End With
                            With objSheetResult.Cells(rCouple, iGroup + 3 + add).Characters(Len(Mid(Raspisanie(iDisc + 1, iGroup), 1, Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";"))) + Len(tmpPrepod) + 5, Len(Mid(Raspisanie(iDisc + 4, iGroup), 1, Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";")))).Font
                                If boldCabinet = True Then .Bold = True Else .Bold = False
                                If italicCabinet = True Then .Italic = True Else .Italic = False
                                .Name = fontCabinet
                                .Size = sizeCabinet
                            End With
                            NextIndexOf3 = Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 2
                            NextIndexOf4 = Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2
                            For i3Index = Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(iDisc + 3, iGroup))
                                If Mid(Raspisanie(iDisc + 3, iGroup), i3Index, 1).ToString = ";" Then NextIndexOf3 = i3Index : Exit For
                            Next
                            For i4Index = Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(iDisc + 4, iGroup))
                                If Mid(Raspisanie(iDisc + 4, iGroup), i4Index, 1).ToString = ";" Then NextIndexOf4 = i4Index : Exit For
                            Next
                            tmpValue = Mid(Raspisanie(iDisc + 1, iGroup), Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 1, iGroup)) - (Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";") + 4))
                            If Not Raspisanie(iDisc + 3, iGroup) = Nothing Then
                                If Not Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") = -1 Then
                                    tmpPrepod = Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 3))
                                    For i1Sym = 1 To Len(tmpPrepod)
                                        If Mid(tmpPrepod, i1Sym, 1) = " " Then tmpPrepod = Mid(tmpPrepod, 1, i1Sym - 1) : Exit For
                                    Next
                                    tmpValue = tmpValue & vbCrLf & tmpPrepod
                                End If
                            End If
                            If Not Raspisanie(iDisc + 4, iGroup) = Nothing Then If Not Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & vbCrLf & Mid(Raspisanie(iDisc + 4, iGroup), Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 3, NextIndexOf4 - (Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 3))
                            objSheetResult.Cells(rCouple, iGroup + 4 + add) = tmpValue
                            With objSheetResult.Cells(rCouple, iGroup + 4 + add).Characters(1, Len(Mid(Raspisanie(iDisc + 1, iGroup), Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 1, iGroup)) - (Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";") + 4)))).Font
                                If boldDiscipline = True Then .Bold = True Else .Bold = False
                                If italicDiscipline = True Then .Italic = True Else .Italic = False
                                .Name = fontDiscipline
                                .Size = sizeDiscipline
                            End With
                            With objSheetResult.Cells(rCouple, iGroup + 4 + add).Characters(Len(Mid(Raspisanie(iDisc + 1, iGroup), Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 1, iGroup)) - (Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";") + 4))) + 3, Len(tmpPrepod)).Font
                                If boldTeacher = True Then .Bold = True Else .Bold = False
                                If italicTeacher = True Then .Italic = True Else .Italic = False
                                .Name = fontTeacher
                                .Size = sizeTeacher
                            End With
                            With objSheetResult.Cells(rCouple, iGroup + 4 + add).Characters(Len(Mid(Raspisanie(iDisc + 1, iGroup), Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 1, iGroup)) - (Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";") + 4))) + Len(tmpPrepod) + 5, Len(Mid(Raspisanie(iDisc + 4, iGroup), Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 3, NextIndexOf4 - (Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 3)))).Font
                                If boldCabinet = True Then .Bold = True Else .Bold = False
                                If italicCabinet = True Then .Italic = True Else .Italic = False
                                .Name = fontCabinet
                                .Size = sizeCabinet
                            End With
                        Else 'Если числитель целый
                            objSheetResult.Range(ConvertToLetter(iGroup + 3 + add) & rCouple & ":" & ConvertToLetter(iGroup + 4 + add) & rCouple).Merge()
                            tmpValue = Raspisanie(iDisc + 1, iGroup)
                            If Not Raspisanie(iDisc + 3, iGroup) = Nothing Then If Not Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & vbCrLf & Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";"))
                            If Not Raspisanie(iDisc + 4, iGroup) = Nothing Then If Not Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & "        " & Mid(Raspisanie(iDisc + 4, iGroup), 1, Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";"))
                            objSheetResult.Cells(rCouple, iGroup + 3 + add) = tmpValue
                            With objSheetResult.Cells(rCouple, iGroup + 3 + add).Characters(1, Len(Raspisanie(iDisc + 1, iGroup))).Font
                                If boldDiscipline = True Then .Bold = True Else .Bold = False
                                If italicDiscipline = True Then .Italic = True Else .Italic = False
                                .Name = fontDiscipline
                                .Size = sizeDiscipline
                            End With
                            With objSheetResult.Cells(rCouple, iGroup + 3 + add).Characters(Len(Raspisanie(iDisc + 1, iGroup)) + 3, Len(Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";")))).Font
                                If boldTeacher = True Then .Bold = True Else .Bold = False
                                If italicTeacher = True Then .Italic = True Else .Italic = False
                                .Name = fontTeacher
                                .Size = sizeTeacher
                            End With
                            With objSheetResult.Cells(rCouple, iGroup + 3 + add).Characters(Len(Raspisanie(iDisc + 1, iGroup)) + Len(Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";"))) + 11, Len(Mid(Raspisanie(iDisc + 4, iGroup), 1, Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";")))).Font
                                If boldCabinet = True Then .Bold = True Else .Bold = False
                                If italicCabinet = True Then .Italic = True Else .Italic = False
                                .Name = fontCabinet
                                .Size = sizeCabinet
                            End With
                        End If
                        'Если в знаменателе деление
                        If Not Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") = -1 Then
                            'Если в числителе деление
                            If Not Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";") = -1 Then
                                NextIndexOf3 = Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 2).ToString.IndexOf(";") + 2 + (Len(Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 2)))
                                NextIndexOf4 = Mid(Raspisanie(iDisc + 4, iGroup), Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2).ToString.IndexOf(";") + 2 + (Len(Mid(Raspisanie(iDisc + 4, iGroup), 1, Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2)))
                                For i3Index = Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 2).ToString.IndexOf(";") + 2 + (Len(Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 2))) To Len(Raspisanie(iDisc + 3, iGroup))
                                    If Mid(Raspisanie(iDisc + 3, iGroup), i3Index, 1).ToString = ";" Then NextIndexOf3 = i3Index : Exit For
                                Next
                                For i4Index = Mid(Raspisanie(iDisc + 4, iGroup), Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2).ToString.IndexOf(";") + 2 + (Len(Mid(Raspisanie(iDisc + 4, iGroup), 1, Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2))) To Len(Raspisanie(iDisc + 4, iGroup))
                                    If Mid(Raspisanie(iDisc + 4, iGroup), i4Index, 1).ToString = ";" Then NextIndexOf4 = i4Index : Exit For
                                Next
                                tmpValue = Mid(Raspisanie(iDisc + 2, iGroup), 1, Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";"))
                                If Not Raspisanie(iDisc + 3, iGroup) = Nothing Then
                                    If Not Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") = -1 Then
                                        tmpPrepod = Mid(Raspisanie(iDisc + 3, iGroup), Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 2).ToString.IndexOf(";") + 2 + (Len(Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 2))), NextIndexOf3 - (Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 2).ToString.IndexOf(";") + 2 + (Len(Mid(Raspisanie(iDisc + 3, iGroup), 1, Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 2)))))
                                        For i1Sym = 1 To Len(tmpPrepod)
                                            If Mid(tmpPrepod, i1Sym, 1) = " " Then tmpPrepod = Mid(tmpPrepod, 1, i1Sym - 1) : Exit For
                                        Next
                                        tmpValue = tmpValue & vbCrLf & tmpPrepod
                                    End If
                                End If
                                If Not Raspisanie(iDisc + 4, iGroup) = Nothing Then If Not Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & vbCrLf & Mid(Raspisanie(iDisc + 4, iGroup), Mid(Raspisanie(iDisc + 4, iGroup), Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2).ToString.IndexOf(";") + 2 + (Len(Mid(Raspisanie(iDisc + 4, iGroup), 1, Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2))), NextIndexOf4 - (Mid(Raspisanie(iDisc + 4, iGroup), Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2).ToString.IndexOf(";") + 2 + (Len(Mid(Raspisanie(iDisc + 4, iGroup), 1, Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2)))))
                                objSheetResult.Cells(rCouple + 1, iGroup + 3 + add) = tmpValue
                                With objSheetResult.Cells(rCouple + 1, iGroup + 3 + add).Characters(1, Len(Mid(Raspisanie(iDisc + 2, iGroup), 1, Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";")))).Font
                                    If boldDiscipline = True Then .Bold = True Else .Bold = False
                                    If italicDiscipline = True Then .Italic = True Else .Italic = False
                                    .Name = fontDiscipline
                                    .Size = sizeDiscipline
                                End With
                                With objSheetResult.Cells(rCouple + 1, iGroup + 3 + add).Characters(Len(Mid(Raspisanie(iDisc + 2, iGroup), 1, Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";"))) + 2, Len(tmpPrepod) + 1).Font
                                    If boldTeacher = True Then .Bold = True Else .Bold = False
                                    If italicTeacher = True Then .Italic = True Else .Italic = False
                                    .Name = fontTeacher
                                    .Size = sizeTeacher
                                End With
                                With objSheetResult.Cells(rCouple + 1, iGroup + 3 + add).Characters(Len(Mid(Raspisanie(iDisc + 2, iGroup), 1, Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";"))) + 2 + Len(tmpPrepod) + 3, Len(Mid(Raspisanie(iDisc + 4, iGroup), Mid(Raspisanie(iDisc + 4, iGroup), Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2).ToString.IndexOf(";") + 2 + (Len(Mid(Raspisanie(iDisc + 4, iGroup), 1, Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2))), NextIndexOf4 - (Mid(Raspisanie(iDisc + 4, iGroup), Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2).ToString.IndexOf(";") + 2 + (Len(Mid(Raspisanie(iDisc + 4, iGroup), 1, Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2))))))).Font
                                    If boldCabinet = True Then .Bold = True Else .Bold = False
                                    If italicCabinet = True Then .Italic = True Else .Italic = False
                                    .Name = fontCabinet
                                    .Size = sizeCabinet
                                End With
                                tmpValue = Mid(Raspisanie(iDisc + 2, iGroup), Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 2, iGroup)) - (Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 4))
                                If Not Raspisanie(iDisc + 3, iGroup) = Nothing Then
                                    If Not Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") = -1 Then
                                        tmpPrepod = Mid(Raspisanie(iDisc + 3, iGroup), NextIndexOf3 + 2, Len(Raspisanie(iDisc + 3, iGroup)) - (NextIndexOf3 + 3))
                                        For i1Sym = 1 To Len(tmpPrepod)
                                            If Mid(tmpPrepod, i1Sym, 1) = " " Then tmpPrepod = Mid(tmpPrepod, 1, i1Sym - 1) : Exit For
                                        Next
                                        tmpValue = tmpValue & vbCrLf & tmpPrepod
                                    End If
                                End If
                                If Not Raspisanie(iDisc + 4, iGroup) = Nothing Then If Not Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & vbCrLf & Mid(Raspisanie(iDisc + 4, iGroup), NextIndexOf4 + 2, Len(Raspisanie(iDisc + 4, iGroup)) - (NextIndexOf4 + 3))
                                objSheetResult.Cells(rCouple + 1, iGroup + 4 + add) = tmpValue
                                With objSheetResult.Cells(rCouple + 1, iGroup + 4 + add).Characters(1, Len(Mid(Raspisanie(iDisc + 2, iGroup), Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 2, iGroup)) - (Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 4)))).Font
                                    If boldDiscipline = True Then .Bold = True Else .Bold = False
                                    If italicDiscipline = True Then .Italic = True Else .Italic = False
                                    .Name = fontDiscipline
                                    .Size = sizeDiscipline
                                End With
                                With objSheetResult.Cells(rCouple + 1, iGroup + 4 + add).Characters(Len(Mid(Raspisanie(iDisc + 2, iGroup), Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 2, iGroup)) - (Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 4))) + 3, Len(tmpPrepod)).Font
                                    If boldTeacher = True Then .Bold = True Else .Bold = False
                                    If italicTeacher = True Then .Italic = True Else .Italic = False
                                    .Name = fontTeacher
                                    .Size = sizeTeacher
                                End With
                                With objSheetResult.Cells(rCouple + 1, iGroup + 4 + add).Characters(Len(Mid(Raspisanie(iDisc + 2, iGroup), Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 2, iGroup)) - (Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 4))) + Len(tmpPrepod) + 5, Len(Mid(Raspisanie(iDisc + 4, iGroup), NextIndexOf4 + 2, Len(Raspisanie(iDisc + 4, iGroup)) - (NextIndexOf4 + 3)))).Font
                                    If boldCabinet = True Then .Bold = True Else .Bold = False
                                    If italicCabinet = True Then .Italic = True Else .Italic = False
                                    .Name = fontCabinet
                                    .Size = sizeCabinet
                                End With
                            Else 'Если числитель целый
                                NextIndexOf3 = Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 2
                                NextIndexOf4 = Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2
                                For i3Index = Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(iDisc + 3, iGroup))
                                    If Mid(Raspisanie(iDisc + 3, iGroup), i3Index, 1).ToString = ";" Then NextIndexOf3 = i3Index : Exit For
                                Next
                                For i4Index = Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(iDisc + 4, iGroup))
                                    If Mid(Raspisanie(iDisc + 4, iGroup), i4Index, 1).ToString = ";" Then NextIndexOf4 = i4Index : Exit For
                                Next
                                tmpValue = Mid(Raspisanie(iDisc + 2, iGroup), 1, Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";"))
                                If Not Raspisanie(iDisc + 3, iGroup) = Nothing Then
                                    If Not Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") = -1 Then
                                        tmpPrepod = Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 3))
                                        For i1Sym = 1 To Len(tmpPrepod)
                                            If Mid(tmpPrepod, i1Sym, 1) = " " Then tmpPrepod = Mid(tmpPrepod, 1, i1Sym - 1) : Exit For
                                        Next
                                        tmpValue = tmpValue & vbCrLf & tmpPrepod
                                    End If
                                End If
                                If Not Raspisanie(iDisc + 4, iGroup) = Nothing Then If Not Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & vbCrLf & Mid(Raspisanie(iDisc + 4, iGroup), Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 3, NextIndexOf4 - (Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 3))
                                objSheetResult.Cells(rCouple + 1, iGroup + 3 + add) = tmpValue
                                With objSheetResult.Cells(rCouple + 1, iGroup + 3 + add).Characters(1, Len(Mid(Raspisanie(iDisc + 2, iGroup), 1, Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";")))).Font
                                    If boldDiscipline = True Then .Bold = True Else .Bold = False
                                    If italicDiscipline = True Then .Italic = True Else .Italic = False
                                    .Name = fontDiscipline
                                    .Size = sizeDiscipline
                                End With
                                With objSheetResult.Cells(rCouple + 1, iGroup + 3 + add).Characters(Len(Mid(Raspisanie(iDisc + 2, iGroup), 1, Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";"))) + 3, Len(tmpPrepod)).Font
                                    If boldTeacher = True Then .Bold = True Else .Bold = False
                                    If italicTeacher = True Then .Italic = True Else .Italic = False
                                    .Name = fontTeacher
                                    .Size = sizeTeacher
                                End With
                                With objSheetResult.Cells(rCouple + 1, iGroup + 3 + add).Characters(Len(Mid(Raspisanie(iDisc + 2, iGroup), 1, Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";"))) + Len(tmpPrepod) + 5, Len(Mid(Raspisanie(iDisc + 4, iGroup), Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 3, NextIndexOf4 - (Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 3)))).Font
                                    If boldCabinet = True Then .Bold = True Else .Bold = False
                                    If italicCabinet = True Then .Italic = True Else .Italic = False
                                    .Name = fontCabinet
                                    .Size = sizeCabinet
                                End With
                                tmpValue = Mid(Raspisanie(iDisc + 2, iGroup), Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 2, iGroup)) - (Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 4))
                                If Not Raspisanie(iDisc + 3, iGroup) = Nothing Then
                                    If Not Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") = -1 Then
                                        tmpPrepod = Mid(Raspisanie(iDisc + 3, iGroup), NextIndexOf3 + 2, Len(Raspisanie(iDisc + 3, iGroup)) - (NextIndexOf3 + 3))
                                        For i1Sym = 1 To Len(tmpPrepod)
                                            If Mid(tmpPrepod, i1Sym, 1) = " " Then tmpPrepod = Mid(tmpPrepod, 1, i1Sym - 1) : Exit For
                                        Next
                                        tmpValue = tmpValue & vbCrLf & tmpPrepod
                                    End If
                                End If
                                If Not Raspisanie(iDisc + 4, iGroup) = Nothing Then If Not Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & vbCrLf & Mid(Raspisanie(iDisc + 4, iGroup), NextIndexOf4 + 2, Len(Raspisanie(iDisc + 4, iGroup)) - (NextIndexOf4 + 3))
                                objSheetResult.Cells(rCouple + 1, iGroup + 4 + add) = tmpValue
                                With objSheetResult.Cells(rCouple + 1, iGroup + 4 + add).Characters(1, Len(Mid(Raspisanie(iDisc + 2, iGroup), Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 2, iGroup)) - (Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 4)))).Font
                                    If boldDiscipline = True Then .Bold = True Else .Bold = False
                                    If italicDiscipline = True Then .Italic = True Else .Italic = False
                                    .Name = fontDiscipline
                                    .Size = sizeDiscipline
                                End With
                                With objSheetResult.Cells(rCouple + 1, iGroup + 4 + add).Characters(Len(Mid(Raspisanie(iDisc + 2, iGroup), Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 2, iGroup)) - (Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 4))) + 3, Len(tmpPrepod)).Font
                                    If boldTeacher = True Then .Bold = True Else .Bold = False
                                    If italicTeacher = True Then .Italic = True Else .Italic = False
                                    .Name = fontTeacher
                                    .Size = sizeTeacher
                                End With
                                With objSheetResult.Cells(rCouple + 1, iGroup + 4 + add).Characters(Len(Mid(Raspisanie(iDisc + 2, iGroup), Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 2, iGroup)) - (Raspisanie(iDisc + 2, iGroup).ToString.IndexOf(";") + 4))) + Len(tmpPrepod) + 5, Len(Mid(Raspisanie(iDisc + 4, iGroup), NextIndexOf4 + 2, Len(Raspisanie(iDisc + 4, iGroup)) - (NextIndexOf4 + 3)))).Font
                                    If boldCabinet = True Then .Bold = True Else .Bold = False
                                    If italicCabinet = True Then .Italic = True Else .Italic = False
                                    .Name = fontCabinet
                                    .Size = sizeCabinet
                                End With
                            End If
                        Else 'Если знаменатель целый
                            objSheetResult.Range(ConvertToLetter(iGroup + 3 + add) & rCouple + 1 & ":" & ConvertToLetter(iGroup + 4 + add) & rCouple + 1).Merge()
                            tmpValue = Raspisanie(iDisc + 2, iGroup)
                            'Если в числителе деление
                            If Not Raspisanie(iDisc + 1, iGroup).ToString.IndexOf(";") = -1 Then
                                NextIndexOf3 = Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 2
                                NextIndexOf4 = Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2
                                For i3Index = Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(iDisc + 3, iGroup))
                                    If Mid(Raspisanie(iDisc + 3, iGroup), i3Index, 1).ToString = ";" Then NextIndexOf3 = i3Index : Exit For
                                Next
                                For i4Index = Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(iDisc + 4, iGroup))
                                    If Mid(Raspisanie(iDisc + 4, iGroup), i4Index, 1).ToString = ";" Then NextIndexOf4 = i4Index : Exit For
                                Next
                                If Not Raspisanie(iDisc + 3, iGroup) = Nothing Then If Not Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & vbCrLf & Mid(Raspisanie(iDisc + 3, iGroup), NextIndexOf3 + 2, Len(Raspisanie(iDisc + 3, iGroup)) - (NextIndexOf3 + 3))
                                If Not Raspisanie(iDisc + 4, iGroup) = Nothing Then If Not Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & "        " & Mid(Raspisanie(iDisc + 4, iGroup), NextIndexOf4 + 2, Len(Raspisanie(iDisc + 4, iGroup)) - (NextIndexOf4 + 3))
                                objSheetResult.Cells(rCouple + 1, iGroup + 3 + add) = tmpValue
                                '0
                                With objSheetResult.Cells(rCouple + 1, iGroup + 3 + add).Characters(1, Len(Raspisanie(iDisc + 2, iGroup))).Font
                                    If boldDiscipline = True Then .Bold = True Else .Bold = False
                                    If italicDiscipline = True Then .Italic = True Else .Italic = False
                                    .Name = fontDiscipline
                                    .Size = sizeDiscipline
                                End With
                                With objSheetResult.Cells(rCouple + 1, iGroup + 3 + add).Characters(Len(Raspisanie(iDisc + 2, iGroup)) + 3, Len(Mid(Raspisanie(iDisc + 3, iGroup), NextIndexOf3 + 2, Len(Raspisanie(iDisc + 3, iGroup)) - (NextIndexOf3 + 3)))).Font
                                    If boldTeacher = True Then .Bold = True Else .Bold = False
                                    If italicTeacher = True Then .Italic = True Else .Italic = False
                                    .Name = fontTeacher
                                    .Size = sizeTeacher
                                End With
                                With objSheetResult.Cells(rCouple + 1, iGroup + 3 + add).Characters(Len(Raspisanie(iDisc + 2, iGroup)) + Len(Mid(Raspisanie(iDisc + 3, iGroup), NextIndexOf3 + 2, Len(Raspisanie(iDisc + 3, iGroup)) - (NextIndexOf3 + 3))) + 11, Len(Mid(Raspisanie(iDisc + 4, iGroup), NextIndexOf4 + 2, Len(Raspisanie(iDisc + 4, iGroup)) - (NextIndexOf4 + 3)))).Font
                                    If boldCabinet = True Then .Bold = True Else .Bold = False
                                    If italicCabinet = True Then .Italic = True Else .Italic = False
                                    .Name = fontCabinet
                                    .Size = sizeCabinet
                                End With
                            Else 'Если числитель целый
                                If Not Raspisanie(iDisc + 3, iGroup) = Nothing Then If Not Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & vbCrLf & Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 3, iGroup)) - (Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 4))
                                If Not Raspisanie(iDisc + 4, iGroup) = Nothing Then If Not Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") = -1 Then tmpValue = tmpValue & "        " & Mid(Raspisanie(iDisc + 4, iGroup), Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 4, iGroup)) - (Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 4))
                                objSheetResult.Cells(rCouple + 1, iGroup + 3 + add) = tmpValue
                                With objSheetResult.Cells(rCouple + 1, iGroup + 3 + add).Characters(1, Len(Raspisanie(iDisc + 2, iGroup))).Font
                                    If boldDiscipline = True Then .Bold = True Else .Bold = False
                                    If italicDiscipline = True Then .Italic = True Else .Italic = False
                                    .Name = fontDiscipline
                                    .Size = sizeDiscipline
                                End With
                                With objSheetResult.Cells(rCouple + 1, iGroup + 3 + add).Characters(Len(Raspisanie(iDisc + 2, iGroup)) + 3, Len(Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 3, iGroup)) - (Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 4)))).Font
                                    If boldTeacher = True Then .Bold = True Else .Bold = False
                                    If italicTeacher = True Then .Italic = True Else .Italic = False
                                    .Name = fontTeacher
                                    .Size = sizeTeacher
                                End With
                                With objSheetResult.Cells(rCouple + 1, iGroup + 3 + add).Characters(Len(Raspisanie(iDisc + 2, iGroup)) + Len(Mid(Raspisanie(iDisc + 3, iGroup), Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 3, iGroup)) - (Raspisanie(iDisc + 3, iGroup).ToString.IndexOf(";") + 4))) + 11, Len(Mid(Raspisanie(iDisc + 4, iGroup), Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 3, Len(Raspisanie(iDisc + 4, iGroup)) - (Raspisanie(iDisc + 4, iGroup).ToString.IndexOf(";") + 4)))).Font
                                    If boldCabinet = True Then .Bold = True Else .Bold = False
                                    If italicCabinet = True Then .Italic = True Else .Italic = False
                                    .Name = fontCabinet
                                    .Size = sizeCabinet
                                End With
                            End If
                        End If
                    End If
                End If
                If iDisc > 85 Then
                    rCouple = rCouple + 8
                Else
                    If kCouple = 3 Then
                        If Not rCouple = 52 Then
                            If Raspisanie(90 + ((iDisc \ 15) * 5), iGroup) = Nothing And Raspisanie(91 + ((iDisc \ 15) * 5), iGroup) = Nothing And Raspisanie(92 + ((iDisc \ 15) * 5), iGroup) = Nothing Then
                                objSheetResult.Range(ConvertToLetter(iGroup + 3 + add) & (rCouple + 2) & ":" & ConvertToLetter(iGroup + 4 + add) & (rCouple + 3)).Merge()
                            End If
                            kCouple = 1
                            rCouple = rCouple + 4
                        End If
                    Else
                        kCouple = kCouple + 1
                        rCouple = rCouple + 2
                    End If
                End If
            Next
            add = add + 1
            If Int((20 / (Groups.GetUpperBound(0) + 1))) = 0 Then ProgressValue = ProgressValue + 1 Else ProgressValue = ProgressValue + Int((20 / (Groups.GetUpperBound(0) + 1)))
            Me.Invoke(New ThreadStart(AddressOf ProgressBarChange))
        Next

        With objSheetResult.Range("C8:AP53")
            .HorizontalAlignment = alignDiscipline
            .VerticalAlignment = valignDiscipline
        End With

        'Установка границ ячейкам
        objSheetResult.Range("A7:" & ConvertToLetter(((Groups.GetUpperBound(0) + 1) * 2) + 2) & "53").Borders.LineStyle = True

        'Формирование и заполнение листа с преподавателями
link_teachers: LoadingLabelDescription = "Формирование и заполнение листа с преподавателями"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))

        objSheetWork = Nothing
        objSheetWork = objAppWork.Workbooks(1).Worksheets(ListTeacherExcel)
        objSheetResult = objAppResult.Sheets.Add(After:=objAppResult.WorkSheets("На стенд"))
        objSheetResult.Name = "Преподаватели"

        iDay = 1 'Текущий день недели в цикле
        iCouple = 1 'Текущая пара в цикле

        'Параметры шрифтов для заполнения занятости преподавателей

        Dim fontTeacherHeadNumber As String = "Times New Roman"
        Dim fontTeacherHeadFIO As String = "Times New Roman"
        Dim fontTeacherNumber As String = "Times New Roman"
        Dim fontTeacherFIO As String = "Times New Roman"
        Dim fontTeacherGroupOne As String = "Times New Roman"
        Dim fontTeacherGroupTwo As String = "Times New Roman"
        Dim fontTeacherDay As String = "Times New Roman"
        Dim fontTeacherCouple As String = "Times New Roman"
        Dim sizeTeacherHeadNumber As String = "16"
        Dim sizeTeacherHeadFIO As String = "16"
        Dim sizeTeacherNumber As String = "16"
        Dim sizeTeacherFIO As String = "16"
        Dim sizeTeacherGroupOne As String = "16"
        Dim sizeTeacherGroupTwo As String = "16"
        Dim sizeTeacherDay As String = "16"
        Dim sizeTeacherCouple As String = "16"
        Dim boldTeacherHeadNumber As Boolean = True
        Dim boldTeacherHeadFIO As Boolean = True
        Dim boldTeacherNumber As Boolean = False
        Dim boldTeacherFIO As Boolean = False
        Dim boldTeacherGroupOne As Boolean = False
        Dim boldTeacherGroupTwo As Boolean = False
        Dim boldTeacherDay As Boolean = True
        Dim boldTeacherCouple As Boolean = True
        Dim italicTeacherHeadNumber As Boolean = False
        Dim italicTeacherHeadFIO As Boolean = False
        Dim italicTeacherNumber As Boolean = False
        Dim italicTeacherFIO As Boolean = False
        Dim italicTeacherGroupOne As Boolean = False
        Dim italicTeacherGroupTwo As Boolean = False
        Dim italicTeacherDay As Boolean = False
        Dim italicTeacherCouple As Boolean = False
        Dim alignTeacherHeadNumber As Integer = 3
        Dim alignTeacherHeadFIO As Integer = 3
        Dim alignTeacherNumber As Integer = 3
        Dim alignTeacherFIO As Integer = 3
        Dim alignTeacherGroupOne As Integer = 3
        Dim alignTeacherGroupTwo As Integer = 3
        Dim alignTeacherDay As Integer = 3
        Dim alignTeacherCouple As Integer = 3
        Dim valignTeacherHeadNumber As Integer = 2
        Dim valignTeacherHeadFIO As Integer = 2
        Dim valignTeacherNumber As Integer = 2
        Dim valignTeacherFIO As Integer = 2
        Dim valignTeacherGroupOne As Integer = 2
        Dim valignTeacherGroupTwo As Integer = 2
        Dim valignTeacherDay As Integer = 2
        Dim valignTeacherCouple As Integer = 2

        Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            SettingFile = reader.ReadLine() '[TimetableKRU]
            For SttRow = 1 To 84
                reader.ReadLine()
            Next
            Dim ReadfontTeacherHeadNumber As String = Mid(reader.ReadLine(), Len("fontTeacherHeadNumber=") + 1)
            Dim ReadfontTeacherHeadFIO As String = Mid(reader.ReadLine(), Len("fontTeacherHeadFIO=") + 1)
            Dim ReadfontTeacherNumber As String = Mid(reader.ReadLine(), Len("fontTeacherNumber=") + 1)
            Dim ReadfontTeacherFIO As String = Mid(reader.ReadLine(), Len("fontTeacherFIO=") + 1)
            Dim ReadfontTeacherGroupOne As String = Mid(reader.ReadLine(), Len("fontTeacherGroupOne=") + 1)
            Dim ReadfontTeacherGroupTwo As String = Mid(reader.ReadLine(), Len("fontTeacherGroupTwo=") + 1)
            Dim ReadfontTeacherDay As String = Mid(reader.ReadLine(), Len("fontTeacherDay=") + 1)
            Dim ReadfontTeacherCouple As String = Mid(reader.ReadLine(), Len("fontTeacherCouple=") + 1)
            Dim ReadsizeTeacherHeadNumber As String = Mid(reader.ReadLine(), Len("sizeTeacherHeadNumber=") + 1)
            Dim ReadsizeTeacherHeadFIO As String = Mid(reader.ReadLine(), Len("sizeTeacherHeadFIO=") + 1)
            Dim ReadsizeTeacherNumber As String = Mid(reader.ReadLine(), Len("sizeTeacherNumber=") + 1)
            Dim ReadsizeTeacherFIO As String = Mid(reader.ReadLine(), Len("sizeTeacherFIO=") + 1)
            Dim ReadsizeTeacherGroupOne As String = Mid(reader.ReadLine(), Len("sizeTeacherGroupOne=") + 1)
            Dim ReadsizeTeacherGroupTwo As String = Mid(reader.ReadLine(), Len("sizeTeacherGroupTwo=") + 1)
            Dim ReadsizeTeacherDay As String = Mid(reader.ReadLine(), Len("sizeTeacherDay=") + 1)
            Dim ReadsizeTeacherCouple As String = Mid(reader.ReadLine(), Len("sizeTeacherCouple=") + 1)
            Dim ReadboldTeacherHeadNumber As String = Mid(reader.ReadLine(), Len("boldTeacherHeadNumber=") + 1)
            Dim ReadboldTeacherHeadFIO As String = Mid(reader.ReadLine(), Len("boldTeacherHeadFIO=") + 1)
            Dim ReadboldTeacherNumber As String = Mid(reader.ReadLine(), Len("boldTeacherNumber=") + 1)
            Dim ReadboldTeacherFIO As String = Mid(reader.ReadLine(), Len("boldTeacherFIO=") + 1)
            Dim ReadboldTeacherGroupOne As String = Mid(reader.ReadLine(), Len("boldTeacherGroupOne=") + 1)
            Dim ReadboldTeacherGroupTwo As String = Mid(reader.ReadLine(), Len("boldTeacherGroupTwo=") + 1)
            Dim ReadboldTeacherDay As String = Mid(reader.ReadLine(), Len("boldTeacherDay=") + 1)
            Dim ReadboldTeacherCouple As String = Mid(reader.ReadLine(), Len("boldTeacherCouple=") + 1)
            Dim ReaditalicTeacherHeadNumber As String = Mid(reader.ReadLine(), Len("italicTeacherHeadNumber=") + 1)
            Dim ReaditalicTeacherHeadFIO As String = Mid(reader.ReadLine(), Len("italicTeacherHeadFIO=") + 1)
            Dim ReaditalicTeacherNumber As String = Mid(reader.ReadLine(), Len("italicTeacherNumber=") + 1)
            Dim ReaditalicTeacherFIO As String = Mid(reader.ReadLine(), Len("italicTeacherFIO=") + 1)
            Dim ReaditalicTeacherGroupOne As String = Mid(reader.ReadLine(), Len("italicTeacherGroupOne=") + 1)
            Dim ReaditalicTeacherGroupTwo As String = Mid(reader.ReadLine(), Len("italicTeacherGroupTwo=") + 1)
            Dim ReaditalicTeacherDay As String = Mid(reader.ReadLine(), Len("italicTeacherDay=") + 1)
            Dim ReaditalicTeacherCouple As String = Mid(reader.ReadLine(), Len("italicTeacherCouple=") + 1)
            Dim ReadalignTeacherHeadNumber As String = Mid(reader.ReadLine(), Len("alignTeacherHeadNumber=") + 1)
            Dim ReadalignTeacherHeadFIO As String = Mid(reader.ReadLine(), Len("alignTeacherHeadFIO=") + 1)
            Dim ReadalignTeacherNumber As String = Mid(reader.ReadLine(), Len("alignTeacherNumber=") + 1)
            Dim ReadalignTeacherFIO As String = Mid(reader.ReadLine(), Len("alignTeacherFIO=") + 1)
            Dim ReadalignTeacherGroupOne As String = Mid(reader.ReadLine(), Len("alignTeacherGroupOne=") + 1)
            Dim ReadalignTeacherGroupTwo As String = Mid(reader.ReadLine(), Len("alignTeacherGroupTwo=") + 1)
            Dim ReadalignTeacherDay As String = Mid(reader.ReadLine(), Len("alignTeacherDay=") + 1)
            Dim ReadalignTeacherCouple As String = Mid(reader.ReadLine(), Len("alignTeacherCouple=") + 1)
            Dim ReadvalignTeacherHeadNumber As String = Mid(reader.ReadLine(), Len("valignTeacherHeadNumber=") + 1)
            Dim ReadvalignTeacherHeadFIO As String = Mid(reader.ReadLine(), Len("valignTeacherHeadFIO=") + 1)
            Dim ReadvalignTeacherNumber As String = Mid(reader.ReadLine(), Len("valignTeacherNumber=") + 1)
            Dim ReadvalignTeacherFIO As String = Mid(reader.ReadLine(), Len("valignTeacherFIO=") + 1)
            Dim ReadvalignTeacherGroupOne As String = Mid(reader.ReadLine(), Len("valignTeacherGroupOne=") + 1)
            Dim ReadvalignTeacherGroupTwo As String = Mid(reader.ReadLine(), Len("valignTeacherGroupTwo=") + 1)
            Dim ReadvalignTeacherDay As String = Mid(reader.ReadLine(), Len("valignTeacherDay=") + 1)
            Dim ReadvalignTeacherCouple As String = Mid(reader.ReadLine(), Len("valignTeacherCouple=") + 1)
            If Not ReadfontTeacherHeadNumber = "" Then fontTeacherHeadNumber = ReadfontTeacherHeadNumber
            If Not ReadfontTeacherHeadFIO = "" Then fontTeacherHeadFIO = ReadfontTeacherHeadFIO
            If Not ReadfontTeacherNumber = "" Then fontTeacherNumber = ReadfontTeacherNumber
            If Not ReadfontTeacherFIO = "" Then fontTeacherFIO = ReadfontTeacherFIO
            If Not ReadfontTeacherGroupOne = "" Then fontTeacherGroupOne = ReadfontTeacherGroupOne
            If Not ReadfontTeacherGroupTwo = "" Then fontTeacherGroupTwo = ReadfontTeacherGroupTwo
            If Not ReadfontTeacherDay = "" Then fontTeacherDay = ReadfontTeacherDay
            If Not ReadfontTeacherCouple = "" Then fontTeacherCouple = ReadfontTeacherCouple
            If Not ReadsizeTeacherHeadNumber = "" Then sizeTeacherHeadNumber = ReadsizeTeacherHeadNumber
            If Not ReadsizeTeacherHeadFIO = "" Then sizeTeacherHeadFIO = ReadsizeTeacherHeadFIO
            If Not ReadsizeTeacherNumber = "" Then sizeTeacherNumber = ReadsizeTeacherNumber
            If Not ReadsizeTeacherFIO = "" Then sizeTeacherFIO = ReadsizeTeacherFIO
            If Not ReadsizeTeacherGroupOne = "" Then sizeTeacherGroupOne = ReadsizeTeacherGroupOne
            If Not ReadsizeTeacherGroupTwo = "" Then sizeTeacherGroupTwo = ReadsizeTeacherGroupTwo
            If Not ReadsizeTeacherDay = "" Then sizeTeacherDay = ReadsizeTeacherDay
            If Not ReadsizeTeacherCouple = "" Then sizeTeacherCouple = ReadsizeTeacherCouple
            If Not ReadboldTeacherHeadNumber = "" Then boldTeacherHeadNumber = ReadboldTeacherHeadNumber
            If Not ReadboldTeacherHeadFIO = "" Then boldTeacherHeadFIO = ReadboldTeacherHeadFIO
            If Not ReadboldTeacherNumber = "" Then boldTeacherNumber = ReadboldTeacherNumber
            If Not ReadboldTeacherFIO = "" Then boldTeacherFIO = ReadboldTeacherFIO
            If Not ReadboldTeacherGroupOne = "" Then boldTeacherGroupOne = ReadboldTeacherGroupOne
            If Not ReadboldTeacherGroupTwo = "" Then boldTeacherGroupTwo = ReadboldTeacherGroupTwo
            If Not ReadboldTeacherDay = "" Then boldTeacherDay = ReadboldTeacherDay
            If Not ReadboldTeacherCouple = "" Then boldTeacherCouple = ReadboldTeacherCouple
            If Not ReaditalicTeacherHeadNumber = "" Then italicTeacherHeadNumber = ReaditalicTeacherHeadNumber
            If Not ReaditalicTeacherHeadFIO = "" Then italicTeacherHeadFIO = ReaditalicTeacherHeadFIO
            If Not ReaditalicTeacherNumber = "" Then italicTeacherNumber = ReaditalicTeacherNumber
            If Not ReaditalicTeacherFIO = "" Then italicTeacherFIO = ReaditalicTeacherFIO
            If Not ReaditalicTeacherGroupOne = "" Then italicTeacherGroupOne = ReaditalicTeacherGroupOne
            If Not ReaditalicTeacherGroupTwo = "" Then italicTeacherGroupTwo = ReaditalicTeacherGroupTwo
            If Not ReaditalicTeacherDay = "" Then italicTeacherDay = ReaditalicTeacherDay
            If Not ReaditalicTeacherCouple = "" Then italicTeacherCouple = ReaditalicTeacherCouple
            If Not ReadalignTeacherHeadNumber = "" Then alignTeacherHeadNumber = ReadalignTeacherHeadNumber
            If Not ReadalignTeacherHeadFIO = "" Then alignTeacherHeadFIO = ReadalignTeacherHeadFIO
            If Not ReadalignTeacherNumber = "" Then alignTeacherNumber = ReadalignTeacherNumber
            If Not ReadalignTeacherFIO = "" Then alignTeacherFIO = ReadalignTeacherFIO
            If Not ReadalignTeacherGroupOne = "" Then alignTeacherGroupOne = ReadalignTeacherGroupOne
            If Not ReadalignTeacherGroupTwo = "" Then alignTeacherGroupTwo = ReadalignTeacherGroupTwo
            If Not ReadalignTeacherDay = "" Then alignTeacherDay = ReadalignTeacherDay
            If Not ReadalignTeacherCouple = "" Then alignTeacherCouple = ReadalignTeacherCouple
            If Not ReadvalignTeacherHeadNumber = "" Then valignTeacherHeadNumber = ReadvalignTeacherHeadNumber
            If Not ReadvalignTeacherHeadFIO = "" Then valignTeacherHeadFIO = ReadvalignTeacherHeadFIO
            If Not ReadvalignTeacherNumber = "" Then valignTeacherNumber = ReadvalignTeacherNumber
            If Not ReadvalignTeacherFIO = "" Then valignTeacherFIO = ReadvalignTeacherFIO
            If Not ReadvalignTeacherGroupOne = "" Then valignTeacherGroupOne = ReadvalignTeacherGroupOne
            If Not ReadvalignTeacherGroupTwo = "" Then valignTeacherGroupTwo = ReadvalignTeacherGroupTwo
            If Not ReadvalignTeacherDay = "" Then valignTeacherDay = ReadvalignTeacherDay
            If Not ReadvalignTeacherCouple = "" Then valignTeacherCouple = ReadvalignTeacherCouple
        End Using

        'Заполнение массива преподавателями
        Erase Teachers
        kTeacher = 0
        r = Me.EXCELFirstRowTeacher.Text
        Do While objSheetWork.Range(Me.EXCELTeatherList.Text & r).Value <> ""
            kTeacher = kTeacher + 1
            r = r + 1
        Loop
        ReDim Teachers(kTeacher - 1)
        kTeacher = 0
        r = Me.EXCELFirstRowTeacher.Text
        Do While objSheetWork.Range(Me.EXCELTeatherList.Text & r).Value <> ""
            Teachers(kTeacher) = objSheetWork.Range(Me.EXCELTeatherList.Text & r).Value
            kTeacher = kTeacher + 1
            r = r + 1
        Loop
        Array.Sort(Teachers)

        'Шапка
        objSheetResult.Range("A1:A2").Merge()
        objSheetResult.Range("A1").Value = "№ п/п"
        With objSheetResult.Range("A1:A2")
            If boldTeacherHeadNumber = True Then .Font.Bold = True Else .Font.Bold = False
            If italicTeacherHeadNumber = True Then .Font.Italic = True Else .Font.Italic = False
            .Font.Name = fontTeacherHeadNumber
            .Font.Size = sizeTeacherHeadNumber
            .HorizontalAlignment = alignTeacherHeadNumber
            .VerticalAlignment = valignTeacherHeadNumber
            .EntireColumn.AutoFit()
            '.ColumnWidth = 0.35416666666666669 * sizeTeacherHeadNumber
        End With

        objSheetResult.Range("B1:B2").Merge()
        objSheetResult.Range("B1").Value = "Фамилия И.О."
        With objSheetResult.Range("B1:B2")
            If boldTeacherHeadFIO = True Then .Font.Bold = True Else .Font.Bold = False
            If italicTeacherHeadFIO = True Then .Font.Italic = True Else .Font.Italic = False
            .Font.Name = fontTeacherHeadFIO
            .Font.Size = sizeTeacherHeadFIO
            .HorizontalAlignment = alignTeacherHeadFIO
            .VerticalAlignment = valignTeacherHeadFIO
            .EntireColumn.AutoFit()
            .ColumnWidth = 1.875 * sizeTeacherHeadFIO
        End With

        'Дни недели
        objSheetResult.Range("C1:F1").Merge()
        objSheetResult.Range("G1:J1").Merge()
        objSheetResult.Range("K1:N1").Merge()
        objSheetResult.Range("O1:R1").Merge()
        objSheetResult.Range("S1:V1").Merge()
        objSheetResult.Range("W1:Y1").Merge()
        objSheetResult.Range("C1").Value = "Понедельник"
        objSheetResult.Range("G1").Value = "Вторник"
        objSheetResult.Range("K1").Value = "Среда"
        objSheetResult.Range("O1").Value = "Четверг"
        objSheetResult.Range("S1").Value = "Пятница"
        objSheetResult.Range("W1").Value = "Суббота"
        With objSheetResult.Range("A1:Y1")
            If boldTeacherDay = True Then .Font.Bold = True Else .Font.Bold = False
            If italicTeacherDay = True Then .Font.Italic = True Else .Font.Italic = False
            .Font.Name = fontTeacherDay
            .Font.Size = sizeTeacherDay
            .HorizontalAlignment = alignTeacherDay
            .VerticalAlignment = valignTeacherDay
            .EntireColumn.AutoFit()
        End With

        'Пары
        For iDay = 3 To 22 Step 4
            objSheetResult.Range(ConvertToLetter(iDay) & 2).Value = "1"
            objSheetResult.Range(ConvertToLetter(iDay + 1) & 2).Value = "2"
            objSheetResult.Range(ConvertToLetter(iDay + 2) & 2).Value = "3"
            objSheetResult.Range(ConvertToLetter(iDay + 3) & 2).Value = "4"
        Next
        objSheetResult.Range("W2").Value = "1"
        objSheetResult.Range("X2").Value = "2"
        objSheetResult.Range("Y2").Value = "3"
        With objSheetResult.Range("C2:Y2")
            If boldTeacherCouple = True Then .Font.Bold = True Else .Font.Bold = False
            If italicTeacherCouple = True Then .Font.Italic = True Else .Font.Italic = False
            .Font.Name = fontTeacherCouple
            .Font.Size = sizeTeacherCouple
            .HorizontalAlignment = alignTeacherCouple
            .VerticalAlignment = valignTeacherCouple
            .EntireColumn.AutoFit()
            .ColumnWidth = 0.75 * sizeTeacherCouple
            '.RowHeight = 2.5 * sizeTeacherCouple
        End With

        'Общий цикл формирования нагрузки преподавателей
        For iTeacher = 0 To Teachers.GetUpperBound(0)
            LoadingLabelDescriptionHead = "Обрабатывается " & iTeacher + 1 & " преподаватель из " & Teachers.GetUpperBound(0) + 1 & ": " & Teachers(iTeacher)
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionHeadChange))
            objSheetResult.Range("A" & (iTeacher * 2) + 3 & ":A" & (iTeacher * 2) + 4).Merge()
            objSheetResult.Range("A" & (iTeacher * 2) + 3).Value = iTeacher + 1
            With objSheetResult.Range("A" & (iTeacher * 2) + 3)
                If boldTeacherNumber = True Then .Font.Bold = True Else .Font.Bold = False
                If italicTeacherNumber = True Then .Font.Italic = True Else .Font.Italic = False
                .Font.Name = fontTeacherNumber
                .Font.Size = sizeTeacherNumber
                .HorizontalAlignment = alignTeacherNumber
                .VerticalAlignment = valignTeacherNumber
                '.EntireColumn.AutoFit()
                '.ColumnWidth = 1.33333333333 * sizeTeacherNumber
                .RowHeight = 1.3125 * sizeTeacherNumber
            End With
            objSheetResult.Range("B" & (iTeacher * 2) + 3 & ":B" & (iTeacher * 2) + 4).Merge()
            objSheetResult.Range("B" & (iTeacher * 2) + 3).Value = Teachers(iTeacher)
            With objSheetResult.Range("B" & (iTeacher * 2) + 3)
                If boldTeacherFIO = True Then .Font.Bold = True Else .Font.Bold = False
                If italicTeacherFIO = True Then .Font.Italic = True Else .Font.Italic = False
                .Font.Name = fontTeacherFIO
                .Font.Size = sizeTeacherFIO
                .HorizontalAlignment = alignTeacherFIO
                .VerticalAlignment = valignTeacherFIO
                '.EntireColumn.AutoFit()
                .ColumnWidth = 1.875 * sizeTeacherFIO
                .RowHeight = 2.71875 * sizeTeacherFIO
            End With
            For iDisc = 0 To 85 Step 5
                itmpDisc = iDisc + (iDisc \ 15) * 5
                i1tmpDisc = iDisc
                pDisc = False
link_teacher_write: For iGroup = 0 To Groups.GetUpperBound(0)
                    If Not Raspisanie(i1tmpDisc + 3, iGroup) = Nothing Then
                        If Not Raspisanie(i1tmpDisc + 3, iGroup).ToString.IndexOf(Teachers(iTeacher)) = -1 Then
                            'Если основная пара
                            If Not Raspisanie(i1tmpDisc, iGroup) = Nothing Then
                                objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3) & ":" & ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 4)).Merge()
                                If Groups(iGroup).IndexOf(" ") = -1 Then
                                    objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3)).Value = Groups(iGroup)
                                Else
                                    objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3)).Value = Mid(Groups(iGroup), 1, Groups(iGroup).IndexOf(" ")) & vbCrLf & Mid(Groups(iGroup), Groups(iGroup).IndexOf(" ") + 2)
                                End If
                                With objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3) & ":" & ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 4))
                                    If boldTeacherGroupOne = True Then .Font.Bold = True Else .Font.Bold = False
                                    If italicTeacherGroupOne = True Then .Font.Italic = True Else .Font.Italic = False
                                    .Font.Name = fontTeacherGroupOne
                                    .Font.Size = sizeTeacherGroupOne
                                    .HorizontalAlignment = alignTeacherGroupOne
                                    .VerticalAlignment = valignTeacherGroupOne
                                    '.EntireColumn.AutoFit()
                                    .ColumnWidth = 0.75 * sizeTeacherGroupOne
                                    .RowHeight = 2.71875 * sizeTeacherFIO
                                End With
                                Exit For
                            Else 'Если числитель или знаменатель
                                'Если у преподавателя пара либо в числителе либо в знаменателе
                                If Raspisanie(i1tmpDisc + 3, iGroup).ToString.IndexOf(Teachers(iTeacher)) = Raspisanie(i1tmpDisc + 3, iGroup).ToString.LastIndexOf(Teachers(iTeacher)) Then
                                    'Проверка на деление в числителе (в знаменателе не нужна)
                                    If Raspisanie(i1tmpDisc + 1, iGroup).ToString.IndexOf(";") = -1 Then
                                        'Если числитель
                                        If Mid(Raspisanie(i1tmpDisc + 3, iGroup), 1, Raspisanie(i1tmpDisc + 3, iGroup).ToString.IndexOf(";")) = Teachers(iTeacher) Then
                                            If Groups(iGroup).IndexOf(" ") = -1 Then
                                                objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3)).Value = Groups(iGroup)
                                            Else
                                                objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3)).Value = Mid(Groups(iGroup), 1, Groups(iGroup).IndexOf(" ")) & vbCrLf & Mid(Groups(iGroup), Groups(iGroup).IndexOf(" ") + 2)
                                            End If
                                            With objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3) & ":" & ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 4))
                                                If boldTeacherGroupTwo = True Then .Font.Bold = True Else .Font.Bold = False
                                                If italicTeacherGroupTwo = True Then .Font.Italic = True Else .Font.Italic = False
                                                .Font.Name = fontTeacherGroupTwo
                                                .Font.Size = sizeTeacherGroupTwo
                                                .HorizontalAlignment = alignTeacherGroupTwo
                                                .VerticalAlignment = valignTeacherGroupTwo
                                                '.EntireColumn.AutoFit()
                                                .ColumnWidth = 0.75 * sizeTeacherGroupTwo
                                            End With
                                        Else 'Если знаменатель
                                            If Groups(iGroup).IndexOf(" ") = -1 Then
                                                objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 4)).Value = Groups(iGroup)
                                            Else
                                                objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 4)).Value = Mid(Groups(iGroup), 1, Groups(iGroup).IndexOf(" ")) & vbCrLf & Mid(Groups(iGroup), Groups(iGroup).IndexOf(" ") + 2)
                                            End If
                                            With objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3) & ":" & ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 4))
                                                If boldTeacherGroupTwo = True Then .Font.Bold = True Else .Font.Bold = False
                                                If italicTeacherGroupTwo = True Then .Font.Italic = True Else .Font.Italic = False
                                                .Font.Name = fontTeacherGroupTwo
                                                .Font.Size = sizeTeacherGroupTwo
                                                .HorizontalAlignment = alignTeacherGroupTwo
                                                .VerticalAlignment = valignTeacherGroupTwo
                                                '.EntireColumn.AutoFit()
                                                .ColumnWidth = 0.75 * sizeTeacherGroupTwo
                                            End With
                                        End If
                                    Else 'Если есть деление в числителе
                                        'Если числитель
                                        NextIndexOf3 = Raspisanie(i1tmpDisc + 3, iGroup).ToString.IndexOf(";") + 2
                                        For i3Index = Raspisanie(i1tmpDisc + 3, iGroup).ToString.IndexOf(";") + 2 To Len(Raspisanie(i1tmpDisc + 3, iGroup))
                                            If Mid(Raspisanie(i1tmpDisc + 3, iGroup), i3Index, 1).ToString = ";" Then NextIndexOf3 = i3Index : Exit For
                                        Next
                                        If Mid(Raspisanie(i1tmpDisc + 3, iGroup), 1, Raspisanie(i1tmpDisc + 3, iGroup).ToString.IndexOf(";")) = Teachers(iTeacher) Or Mid(Raspisanie(i1tmpDisc + 3, iGroup), Raspisanie(i1tmpDisc + 3, iGroup).ToString.IndexOf(";") + 3, NextIndexOf3 - (Raspisanie(i1tmpDisc + 3, iGroup).ToString.IndexOf(";") + 3)) = Teachers(iTeacher) Then
                                            If Groups(iGroup).IndexOf(" ") = -1 Then
                                                objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3)).Value = Groups(iGroup)
                                            Else
                                                objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3)).Value = Mid(Groups(iGroup), 1, Groups(iGroup).IndexOf(" ")) & vbCrLf & Mid(Groups(iGroup), Groups(iGroup).IndexOf(" ") + 2)
                                            End If
                                            With objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3) & ":" & ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 4))
                                                If boldTeacherGroupTwo = True Then .Font.Bold = True Else .Font.Bold = False
                                                If italicTeacherGroupTwo = True Then .Font.Italic = True Else .Font.Italic = False
                                                .Font.Name = fontTeacherGroupTwo
                                                .Font.Size = sizeTeacherGroupTwo
                                                .HorizontalAlignment = alignTeacherGroupTwo
                                                .VerticalAlignment = valignTeacherGroupTwo
                                                '.EntireColumn.AutoFit()
                                                .ColumnWidth = 0.75 * sizeTeacherGroupTwo
                                            End With
                                        Else 'Если знаменатель
                                            If Groups(iGroup).IndexOf(" ") = -1 Then
                                                objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 4)).Value = Groups(iGroup)
                                            Else
                                                objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 4)).Value = Mid(Groups(iGroup), 1, Groups(iGroup).IndexOf(" ")) & vbCrLf & Mid(Groups(iGroup), Groups(iGroup).IndexOf(" ") + 2)
                                            End If
                                            With objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3) & ":" & ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 4))
                                                If boldTeacherGroupTwo = True Then .Font.Bold = True Else .Font.Bold = False
                                                If italicTeacherGroupTwo = True Then .Font.Italic = True Else .Font.Italic = False
                                                .Font.Name = fontTeacherGroupTwo
                                                .Font.Size = sizeTeacherGroupTwo
                                                .HorizontalAlignment = alignTeacherGroupTwo
                                                .VerticalAlignment = valignTeacherGroupTwo
                                                '.EntireColumn.AutoFit()
                                                .ColumnWidth = 0.75 * sizeTeacherGroupTwo
                                            End With
                                        End If
                                    End If
                                Else 'Если у преподавателя пара и в числителе и в знаменателе
                                    If Groups(iGroup).IndexOf(" ") = -1 Then
                                        objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3)).Value = Groups(iGroup)
                                        objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 4)).Value = Groups(iGroup)
                                    Else
                                        objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3)).Value = Mid(Groups(iGroup), 1, Groups(iGroup).IndexOf(" ")) & vbCrLf & Mid(Groups(iGroup), Groups(iGroup).IndexOf(" ") + 2)
                                        objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 4)).Value = Mid(Groups(iGroup), 1, Groups(iGroup).IndexOf(" ")) & vbCrLf & Mid(Groups(iGroup), Groups(iGroup).IndexOf(" ") + 2)
                                    End If
                                    With objSheetResult.Range(ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 3) & ":" & ConvertToLetter((itmpDisc / 5) + 3) & ((iTeacher * 2) + 4))
                                        If boldTeacherGroupTwo = True Then .Font.Bold = True Else .Font.Bold = False
                                        If italicTeacherGroupTwo = True Then .Font.Italic = True Else .Font.Italic = False
                                        .Font.Name = fontTeacherGroupTwo
                                        .Font.Size = sizeTeacherGroupTwo
                                        .HorizontalAlignment = alignTeacherGroupTwo
                                        .VerticalAlignment = valignTeacherGroupTwo
                                        '.EntireColumn.AutoFit()
                                        .ColumnWidth = 0.75 * sizeTeacherGroupTwo
                                    End With
                                End If
                            End If
                        End If
                    End If
                Next
                If ((itmpDisc / 5) - ((itmpDisc \ 15) * 3)) + 1 = 3 And pDisc = False Then
                    itmpDisc = iDisc + 5
                    i1tmpDisc = 90 + ((iDisc \ 15) * 5)
                    pDisc = True
                    GoTo link_teacher_write
                End If
            Next
            If Int((10 / (Teachers.GetUpperBound(0) + 1))) = 0 Then ProgressValue = ProgressValue + 1 Else ProgressValue = ProgressValue + Int((10 / (Teachers.GetUpperBound(0) + 1)))
            Me.Invoke(New ThreadStart(AddressOf ProgressBarChange))
        Next

        'Установка границ ячейкам
        objSheetResult.Range("A1:Y" & ((Teachers.GetUpperBound(0) + 1) * 2) + 2).Borders.LineStyle = True

        LoadingLabelDescription = "Завершение работы"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))

        objAppWork.ActiveWindow.Close(SaveChanges:=False)
        objAppWork.Quit()
        objAppWork = Nothing
        GC.Collect()

savefile: LoadingLabelDescriptionHead = "Все группы обработанны"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionHeadChange))
        LoadingLabelInfo = "Формирование завершено"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelInfoChange))
        LoadingLabelDescription = "Сохранение готового документа Microsoft Excel"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
        ProgressValue = 100
        Progress100 = True
        Me.Invoke(New ThreadStart(AddressOf ProgressBarChange))
        Me.Invoke(New ThreadStart(AddressOf TimerEnabledDisabled))
        CurrentSubProcess = "Done"
        Me.Invoke(New ThreadStart(AddressOf LoadingImageChange))
        SaveFileDialog1.FileName = "Расписание занятий " & Semestr & " семестр " & Me.NumericUpDownYears1.Value & " - " & Me.NumericUpDownYears2.Value
        Beep()
        Try
            If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                LoadingLabelDescription = "Ожидание подтверждения пользователем об успешном сохранении документа Microsoft Excel"
                Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                objBookResult.SaveAs(SaveFileDialog1.FileName, Excel.XlFileFormat.xlWorkbookNormal)
                objAppResult.Quit()
                MsgBox("Файл успешно сохранён!" & vbCrLf & "Общее время формирования: " & min & " минут " & sec & " секунд", 4160, "Расписание КРУ: Файл сохранён!")
            Else
                Select Case MsgBox("Вы уверены что хотите прервать сохранение файла?", 4148, "Расписание КРУ: Сохранение файла")
                    Case 6 ' Yes
                        LoadingLabelDescription = "Ошибка сохранения документа Microsoft Excel"
                        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
                        objAppResult.ActiveWindow.Close(SaveChanges:=False)
                        MsgBox("Файл не сохранён!", 4112, "Расписание КРУ: Файл не сохранён!")
                    Case 7 ' No
                        GoTo savefile
                End Select
            End If
        Catch
            LoadingLabelDescription = "Ошибка сохранения документа Microsoft Excel"
            Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
            If MsgBox("Перезапись файла невозможна!" & vbCrLf & "Данный файл используется программой." & vbCrLf & "Пожалуйста введите другое имя файла.", 4629, "Расписание КРУ: Запись файла не возможна!") = MsgBoxResult.Retry Then GoTo savefile Else objAppResult.ActiveWindow.Close(SaveChanges:=False) : MsgBox("Файл не сохранён!", 4112, "Расписание КРУ: Файл не сохранён!")
        End Try
        min = 0
        sec = 0

        objAppResult.Quit()
        objAppResult = Nothing
        GC.Collect()
        Erase tmpDiscipline
        Erase tmpDisciplineEdit
        Erase Disc
        Erase tmpDisc
        Erase kUnevenDisc
        Erase kEvenDisc
        Erase Groups
        Erase Teachers

        ProgressValue = 0
        Progress100 = False
        Me.Invoke(New ThreadStart(AddressOf ProgressBarChange))

        LoadingLabelDescription = ""
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))

        frm_loading.Close()
        Me.Invoke(New ThreadStart(AddressOf FormEnabledTrue))

        Exit Sub

0:      Try
            objAppWork.ActiveWindow.Close(SaveChanges:=False)
            objAppWork.Quit()
            objAppWork = Nothing
        Catch
        End Try
        GC.Collect()

        ProgressValue = 0
        Progress100 = False
        Me.Invoke(New ThreadStart(AddressOf ProgressBarChange))
        LoadingLabelDescription = ""
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))

        frm_loading.Close()
        Me.Invoke(New ThreadStart(AddressOf FormEnabledTrue))
    End Sub

    Sub LoadingLabelInfoChange()
        frm_loading.LabelInfo.Text = LoadingLabelInfo
    End Sub

    Sub LoadingLabelDescriptionChange()
        frm_loading.LabelDescription.Text = LoadingLabelDescription
    End Sub

    Sub LoadingLabelDescriptionHeadChange()
        frm_loading.LabelDescriptionHead.Text = LoadingLabelDescriptionHead
    End Sub

    Sub LoadingActivate()
        frm_loading.Activate()
    End Sub

    Sub LoadingLabelOptionsChange()
        frm_loading.LabelOptions.Visible = True
        frm_loading.LabelOptions.Text = LoadingLabelOptions
    End Sub

    Sub LoadingIDiscChange()
        frm_loading.LabelIDisc.Visible = True
        frm_loading.Size = New Size(456, 468)
        Dim R, G, B As Integer
        Dim upperbound As Integer = 255 ' максимальное число диапазона
        Dim lowerbound As Integer = 1 ' минимальное число диапазона
        R = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        G = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        B = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        frm_loading.LabelIDisc.ForeColor = System.Drawing.Color.FromArgb(R, G, B)
        If Len(frm_loading.LabelIDisc.Text) > 76 Then frm_loading.LabelIDisc.Text = Mid(frm_loading.LabelIDisc.Text, 1, 6) & Mid(frm_loading.LabelIDisc.Text, Len(iDisc) + 7)
        frm_loading.LabelIDisc.Text = frm_loading.LabelIDisc.Text & iDisc & ","
    End Sub

    Sub LoadingIFindDiscChange()
        frm_loading.LabelIFindDisc.Visible = True
        frm_loading.Size = New Size(456, 468)
        Dim R, G, B As Integer
        Dim upperbound As Integer = 255 ' максимальное число диапазона
        Dim lowerbound As Integer = 1 ' минимальное число диапазона
        R = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        G = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        B = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        frm_loading.LabelIFindDisc.ForeColor = System.Drawing.Color.FromArgb(R, G, B)
        If Len(frm_loading.LabelIFindDisc.Text) > 71 Then frm_loading.LabelIFindDisc.Text = Mid(frm_loading.LabelIFindDisc.Text, 1, 11) & Mid(frm_loading.LabelIFindDisc.Text, Len(iFindDisc) + 12)
        frm_loading.LabelIFindDisc.Text = frm_loading.LabelIFindDisc.Text & iFindDisc & ","
    End Sub

    Sub LoadingI1DiscChange()
        frm_loading.LabelI1Disc.Visible = True
        frm_loading.Size = New Size(456, 468)
        Dim R, G, B As Integer
        Dim upperbound As Integer = 255 ' максимальное число диапазона
        Dim lowerbound As Integer = 1 ' минимальное число диапазона
        R = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        G = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        B = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        frm_loading.LabelI1Disc.ForeColor = System.Drawing.Color.FromArgb(R, G, B)
        If Len(frm_loading.LabelI1Disc.Text) > 75 Then frm_loading.LabelI1Disc.Text = Mid(frm_loading.LabelI1Disc.Text, 1, 7) & Mid(frm_loading.LabelI1Disc.Text, Len(i1Disc) + 8)
        frm_loading.LabelI1Disc.Text = frm_loading.LabelI1Disc.Text & i1Disc & ","
    End Sub

    Sub LoadingI2DiscChange()
        frm_loading.LabelI2Disc.Visible = True
        frm_loading.Size = New Size(456, 468)
        Dim R, G, B As Integer
        Dim upperbound As Integer = 255 ' максимальное число диапазона
        Dim lowerbound As Integer = 1 ' минимальное число диапазона
        R = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        G = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        B = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        frm_loading.LabelI2Disc.ForeColor = System.Drawing.Color.FromArgb(R, G, B)
        If Len(frm_loading.LabelI2Disc.Text) > 75 Then frm_loading.LabelI2Disc.Text = Mid(frm_loading.LabelI2Disc.Text, 1, 7) & Mid(frm_loading.LabelI2Disc.Text, Len(i2Disc) + 8)
        frm_loading.LabelI2Disc.Text = frm_loading.LabelI2Disc.Text & i2Disc & ","
    End Sub

    Sub LoadingjGroupChange()
        frm_loading.LabeljGroup.Visible = True
        frm_loading.Size = New Size(456, 468)
        Dim R, G, B As Integer
        Dim upperbound As Integer = 255 ' максимальное число диапазона
        Dim lowerbound As Integer = 1 ' минимальное число диапазона
        R = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        G = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        B = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        frm_loading.LabeljGroup.ForeColor = System.Drawing.Color.FromArgb(R, G, B)
        If Len(frm_loading.LabeljGroup.Text) > 75 Then frm_loading.LabeljGroup.Text = Mid(frm_loading.LabeljGroup.Text, 1, 7) & Mid(frm_loading.LabeljGroup.Text, Len(jGroup) + 8)
        frm_loading.LabeljGroup.Text = frm_loading.LabeljGroup.Text & jGroup & ","
    End Sub

    Sub Loadingj2GroupChange()
        frm_loading.Labelj2Group.Visible = True
        frm_loading.Size = New Size(456, 468)
        Dim R, G, B As Integer
        Dim upperbound As Integer = 255 ' максимальное число диапазона
        Dim lowerbound As Integer = 1 ' минимальное число диапазона
        R = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        G = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        B = CInt(Math.Floor((upperbound - lowerbound + 1) * Rnd())) + lowerbound
        frm_loading.Labelj2Group.ForeColor = System.Drawing.Color.FromArgb(R, G, B)
        If Len(frm_loading.Labelj2Group.Text) > 74 Then frm_loading.Labelj2Group.Text = Mid(frm_loading.Labelj2Group.Text, 1, 8) & Mid(frm_loading.Labelj2Group.Text, Len(j2Group) + 9)
        frm_loading.Labelj2Group.Text = frm_loading.Labelj2Group.Text & j2Group & ","
    End Sub

    Sub LoadingImageChange()
        Select Case CurrentSubProcess
            Case "Done"
                frm_loading.PictureBox1.Image = My.Resources.done
                frm_loading.Cursor = Cursors.Default
                frm_loading.LabelPlease.Visible = False
            Case "ВыборкаДисциплин"
                frm_loading.PictureBox1.Image = My.Resources.Magnify_1_5s_135px
            Case "Ожидание"
                frm_loading.PictureBox1.Image = My.Resources.wait
            Case "ФормированиеРасписания"
                frm_loading.PictureBox1.Image = My.Resources.Gear_2s_135px
            Case "ЗаполненениеДокументаРасписанием"
                frm_loading.PictureBox1.Image = My.Resources.filling_timetable
            Case "ПроверкаНаПовторение"
                frm_loading.PictureBox1.Image = My.Resources.Povtorenie
            Case Else
                frm_loading.PictureBox1.Image = My.Resources.Gear_2s_135px
        End Select
    End Sub

    Sub LoadingMinimized()
        frm_loading.WindowState = FormWindowState.Minimized
        Me.Activate()
    End Sub

    Sub ProgressBarChange()
        If ProgressValue >= frm_loading.ProgressBar1.Maximum Then
            If Progress100 = True Then
                ProgressValue = frm_loading.ProgressBar1.Maximum
            Else
                ProgressValue = frm_loading.ProgressBar1.Maximum - 1
            End If
        End If
        frm_loading.ProgressBar1.Value = ProgressValue
        frm_loading.LabelProgress.Text = ProgressValue & "%"
        If CurrentProcess = "GroupProcess" Then frm_loading.Text = "(" & ProgressValue & "%) Расписание КРУ: Формирование списка групп..." Else frm_loading.Text = "(" & ProgressValue & "%) Расписание КРУ: Формирование расписания..."
    End Sub

    Sub TimerEnabledDisabled()
        If frm_loading.Timer2.Enabled = True Then frm_loading.Timer2.Enabled = False Else frm_loading.Timer2.Enabled = True
    End Sub

    Sub TimerDisabled()
        If frm_loading.Timer2.Enabled = True Then frm_loading.Timer2.Enabled = False
    End Sub

    Sub TimerEnabled()
        If frm_loading.Timer2.Enabled = False Then
            frm_loading.Timer2.Enabled = True
            If frm_loading.LabelTimer.Text = "-:-" Then frm_loading.LabelTimer.Text = "00:00"
        End If
    End Sub

    Sub FormEnabledTrue()
        frm_loading.Close()
        If CurrentProcess = "GroupProcess" Then PictureBoxSetting_Click(PictureBoxSetting, New EventArgs()) Else PictureBoxTimetable_Click(PictureBoxTimetable, New EventArgs())
        Me.PanelLoading.Visible = False
        If CurrentProcess = "GroupProcess" Then Me.PanelSetting.Visible = True Else Me.PanelTimetable.Visible = True
        Me.Enabled = True
        Me.Focus()
    End Sub

    Private Sub ButtonForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonForm.Click
        Me.PanelLoading.Visible = True
        Me.PanelTimetable.Visible = False
        Me.PictureBoxTimetable.Image = My.Resources.icons8_calendar_filled_40_active_block
        Me.PictureBoxSetting.Image = My.Resources.icons8_settings_40_block
        Me.PictureBoxInfo.Image = My.Resources.icons8_information_40_block
        Me.PictureBoxExit.Image = My.Resources.icons8_exit_sign_filled_40_block
        frm_loading.Show()
        frm_loading.Focus()
        frm_loading.Text = "(0%) Расписание КРУ: Формирование расписания..."
        Me.Enabled = False

        Th = New System.Threading.Thread(AddressOf TimetableKRUProcess)
        Th.SetApartmentState(ApartmentState.STA)
        Th.Start()
    End Sub

    Dim MaxFrames_Animate_Form As Integer = 0
    Dim MaxFrames_Animate_Change_list As Integer = 0
    Dim MaxFrames_Animate_Change_list_teacher As Integer = 0
    Dim MaxFrames_Animate_Select_file As Integer = 0
    Dim Index_Animate_Form As Integer = 0
    Dim Index_Animate_Change_list As Integer = 0
    Dim Index_Animate_Change_list_teacher As Integer = 0
    Dim Index_Animate_Select_file As Integer = 0
    Dim gifImage_Animate_Form As Image
    Dim gifImage_Animate_Change_list As Image
    Dim gifImage_Animate_Change_list_teacher As Image
    Dim gifImage_Animate_Select_file As Image
    Dim ck_Animate_Form As Boolean = False
    Dim ck_Animate_Change_list As Boolean = False
    Dim ck_Animate_Change_list_teacher As Boolean = False
    Dim ck_Animate_Select_file As Boolean = False

    Private Sub ButtonForm_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm.MouseEnter
        ck_Animate_Form = False
        TimerAnimate_Form.Start()
    End Sub

    Private Sub ButtonForm_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm.MouseLeave
        ck_Animate_Form = True
        TimerAnimate_Form.Start()
    End Sub

    Private Sub ButtonExcelFile_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonExcelFile.MouseEnter
        ck_Animate_Select_file = False
        TimerAnimate_Select_file.Start()
    End Sub

    Private Sub ButtonExcelFile_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonExcelFile.MouseLeave
        ck_Animate_Select_file = True
        TimerAnimate_Select_file.Start()
    End Sub

    Private Sub ButtonList_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonList.MouseEnter
        ck_Animate_Change_list = False
        TimerAnimate_Change_list.Start()
    End Sub

    Private Sub ButtonList_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonList.MouseLeave
        ck_Animate_Change_list = True
        TimerAnimate_Change_list.Start()
    End Sub

    Private Sub ButtonListTeacher_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonListTeacher.MouseEnter
        ck_Animate_Change_list_teacher = False
        TimerAnimate_Change_list_Teacher.Start()
    End Sub

    Private Sub ButtonListTeacher_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonListTeacher.MouseLeave
        ck_Animate_Change_list_teacher = True
        TimerAnimate_Change_list_Teacher.Start()
    End Sub

    Private Sub TimerAnimate_Form_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerAnimate_Form.Tick
        If MaxFrames_Animate_Form = 0 Then Exit Sub
        If Index_Animate_Form < MaxFrames_Animate_Form And ck_Animate_Form = False Then
            Index_Animate_Form += 1
            If Index_Animate_Form = MaxFrames_Animate_Form Then
                ck_Animate_Form = True : Index_Animate_Form -= 1 : TimerAnimate_Form.Stop()
            End If

        ElseIf Index_Animate_Form > 0 And ck_Animate_Form = True Then
            Index_Animate_Form -= 1
            If Index_Animate_Form = 0 Then
                ck_Animate_Form = False : TimerAnimate_Form.Stop()
            End If
        End If

        gifImage_Animate_Form.SelectActiveFrame(New FrameDimension(gifImage_Animate_Form.FrameDimensionsList(0)), Index_Animate_Form)
        ButtonForm.BackgroundImage = gifImage_Animate_Form
        ButtonForm.Refresh()
    End Sub

    Private Sub TimerAnimate_Change_list_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerAnimate_Change_list.Tick
        If MaxFrames_Animate_Change_list = 0 Then Exit Sub
        If Index_Animate_Change_list < MaxFrames_Animate_Change_list And ck_Animate_Change_list = False Then
            Index_Animate_Change_list += 1
            If Index_Animate_Change_list = MaxFrames_Animate_Change_list Then
                ck_Animate_Change_list = True : Index_Animate_Change_list -= 1 : TimerAnimate_Change_list.Stop()
            End If

        ElseIf Index_Animate_Change_list > 0 And ck_Animate_Change_list = True Then
            Index_Animate_Change_list -= 1
            If Index_Animate_Change_list = 0 Then
                ck_Animate_Change_list = False : TimerAnimate_Change_list.Stop()
            End If
        End If

        gifImage_Animate_Change_list.SelectActiveFrame(New FrameDimension(gifImage_Animate_Change_list.FrameDimensionsList(0)), Index_Animate_Change_list)
        ButtonList.BackgroundImage = gifImage_Animate_Change_list
        ButtonList.Refresh()
    End Sub

    Private Sub TimerAnimate_Change_list_Teacher_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerAnimate_Change_list_Teacher.Tick
        If MaxFrames_Animate_Change_list_teacher = 0 Then Exit Sub
        If Index_Animate_Change_list_teacher < MaxFrames_Animate_Change_list_teacher And ck_Animate_Change_list_teacher = False Then
            Index_Animate_Change_list_teacher += 1
            If Index_Animate_Change_list_teacher = MaxFrames_Animate_Change_list_teacher Then
                ck_Animate_Change_list_teacher = True : Index_Animate_Change_list_teacher -= 1 : TimerAnimate_Change_list_Teacher.Stop()
            End If

        ElseIf Index_Animate_Change_list_teacher > 0 And ck_Animate_Change_list_teacher = True Then
            Index_Animate_Change_list_teacher -= 1
            If Index_Animate_Change_list_teacher = 0 Then
                ck_Animate_Change_list_teacher = False : TimerAnimate_Change_list_Teacher.Stop()
            End If
        End If

        gifImage_Animate_Change_list_teacher.SelectActiveFrame(New FrameDimension(gifImage_Animate_Change_list_teacher.FrameDimensionsList(0)), Index_Animate_Change_list_teacher)
        ButtonListTeacher.BackgroundImage = gifImage_Animate_Change_list_teacher
        ButtonListTeacher.Refresh()
    End Sub

    Private Sub TimerAnimate_Select_file_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerAnimate_Select_file.Tick
        If MaxFrames_Animate_Select_file = 0 Then Exit Sub
        If Index_Animate_Select_file < MaxFrames_Animate_Select_file And ck_Animate_Select_file = False Then
            Index_Animate_Select_file += 1
            If Index_Animate_Select_file = MaxFrames_Animate_Select_file Then
                ck_Animate_Select_file = True : Index_Animate_Select_file -= 1 : TimerAnimate_Select_file.Stop()
            End If

        ElseIf Index_Animate_Select_file > 0 And ck_Animate_Select_file = True Then
            Index_Animate_Select_file -= 1
            If Index_Animate_Select_file = 0 Then
                ck_Animate_Select_file = False : TimerAnimate_Select_file.Stop()
            End If
        End If

        gifImage_Animate_Select_file.SelectActiveFrame(New FrameDimension(gifImage_Animate_Select_file.FrameDimensionsList(0)), Index_Animate_Select_file)
        ButtonExcelFile.BackgroundImage = gifImage_Animate_Select_file
        ButtonExcelFile.Refresh()
    End Sub

    Function ConvertToLetter(ByVal iCol As Integer) As String
        Dim iAlpha As Integer
        Dim iRemainder As Integer
        iAlpha = Int(iCol / 27)
        iRemainder = iCol - (iAlpha * 26)
        If iAlpha > 0 Then
            ConvertToLetter = Chr(iAlpha + 64)
        End If
        If iRemainder > 0 Then
            ConvertToLetter = ConvertToLetter & Chr(iRemainder + 64)
        End If
    End Function

    Private Sub PictureBoxExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxExit.Click
        PictureBoxTimetable.BackColor = Color.Transparent
        PictureBoxTimetable.Image = My.Resources.icons8_calendar_filled_40
        PictureBoxSetting.BackColor = Color.Transparent
        PictureBoxSetting.Image = My.Resources.icons8_settings_40
        PictureBoxInfo.BackColor = Color.Transparent
        PictureBoxInfo.Image = My.Resources.icons8_information_40
        PictureBoxExit.BackColor = Color.White
        PictureBoxExit.Image = My.Resources.icons8_exit_sign_filled_40_active
        PanelTimetable.Visible = False
        PanelSetting.Visible = False
        PanelInfo.Visible = False
        PanelExit.Visible = True
    End Sub

    Private Sub PictureBoxInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxInfo.Click
        PictureBoxTimetable.BackColor = Color.Transparent
        PictureBoxTimetable.Image = My.Resources.icons8_calendar_filled_40
        PictureBoxSetting.BackColor = Color.Transparent
        PictureBoxSetting.Image = My.Resources.icons8_settings_40
        PictureBoxInfo.BackColor = Color.White
        PictureBoxInfo.Image = My.Resources.icons8_information_40_active
        PictureBoxExit.BackColor = Color.Transparent
        PictureBoxExit.Image = My.Resources.icons8_exit_sign_filled_40
        PanelTimetable.Visible = False
        PanelSetting.Visible = False
        PanelInfo.Visible = True
        PanelExit.Visible = False
    End Sub

    Private Sub PictureBoxSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxSetting.Click
        PictureBoxTimetable.BackColor = Color.Transparent
        PictureBoxTimetable.Image = My.Resources.icons8_calendar_filled_40
        PictureBoxSetting.BackColor = Color.White
        PictureBoxSetting.Image = My.Resources.icons8_settings_40_active
        PictureBoxInfo.BackColor = Color.Transparent
        PictureBoxInfo.Image = My.Resources.icons8_information_40
        PictureBoxExit.BackColor = Color.Transparent
        PictureBoxExit.Image = My.Resources.icons8_exit_sign_filled_40
        PanelTimetable.Visible = False
        PanelSetting.Visible = True
        PanelInfo.Visible = False
        PanelExit.Visible = False
    End Sub

    Private Sub PictureBoxTimetable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxTimetable.Click
        PictureBoxTimetable.BackColor = Color.White
        PictureBoxTimetable.Image = My.Resources.icons8_calendar_filled_40_active
        PictureBoxSetting.BackColor = Color.Transparent
        PictureBoxSetting.Image = My.Resources.icons8_settings_40
        PictureBoxInfo.BackColor = Color.Transparent
        PictureBoxInfo.Image = My.Resources.icons8_information_40
        PictureBoxExit.BackColor = Color.Transparent
        PictureBoxExit.Image = My.Resources.icons8_exit_sign_filled_40
        PanelTimetable.Visible = True
        PanelSetting.Visible = False
        PanelInfo.Visible = False
        PanelExit.Visible = False
    End Sub

    Private Sub frm_index_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter And PanelTimetable.Visible = True Then ButtonForm_Click(sender, e)

        If e.KeyCode = Keys.PageDown And PanelTimetable.Visible = True Then PictureBoxSetting_Click(sender, e) : Exit Sub
        If e.KeyCode = Keys.PageUp And PanelTimetable.Visible = True Then PictureBoxExit_Click(sender, e) : Exit Sub

        If e.KeyCode = Keys.PageDown And PanelSetting.Visible = True Then PictureBoxInfo_Click(sender, e) : Exit Sub
        If e.KeyCode = Keys.PageUp And PanelSetting.Visible = True Then PictureBoxTimetable_Click(sender, e) : Exit Sub

        If e.KeyCode = Keys.PageDown And PanelInfo.Visible = True Then PictureBoxExit_Click(sender, e) : Exit Sub
        If e.KeyCode = Keys.PageUp And PanelInfo.Visible = True Then PictureBoxSetting_Click(sender, e) : Exit Sub

        If e.KeyCode = Keys.PageDown And PanelExit.Visible = True Then PictureBoxTimetable_Click(sender, e) : Exit Sub
        If e.KeyCode = Keys.PageUp And PanelExit.Visible = True Then PictureBoxInfo_Click(sender, e) : Exit Sub
    End Sub

    Private Sub TextBoxExcelFile_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxExcelFile.KeyDown
        frm_index_KeyDown(sender, e)
    End Sub

    Private Sub TextBoxList_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxList.KeyDown
        frm_index_KeyDown(sender, e)
    End Sub

    Private Sub NumericUpDownYears1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NumericUpDownYears1.KeyDown
        frm_index_KeyDown(sender, e)
    End Sub

    Private Sub NumericUpDownYears2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NumericUpDownYears2.KeyDown
        frm_index_KeyDown(sender, e)
    End Sub

    Private Sub NumericUpDownSemestr_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles NumericUpDownSemestr.KeyDown
        frm_index_KeyDown(sender, e)
    End Sub

    Private Sub ButtonForm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ButtonForm.KeyDown
        frm_index_KeyDown(sender, e)
    End Sub

    Dim pUse As Boolean = False 'Проверка использования процедуры
    Private Sub frm_index_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pUse = False
        Try
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                reader.ReadLine() '[TimetableKRU]
                If Mid(reader.ReadLine(), 12, 1) = 1 Then  'FirstStart=
                    reader.Close()
                    frm_first.ShowDialog()
                    frm_index_Load(sender, e)
                Else
                    If Mid(reader.ReadLine(), 9, 1) = 1 Then CheckBoxWelcomeForm.Checked = True : frm_welcome.ShowDialog() Else CheckBoxWelcomeForm.Checked = False 'Welcome=
                    FileExcel = reader.ReadLine() 'ExcelFile=
                    ListExcel = reader.ReadLine() 'ExcelList=
                    ListTeacherExcel = reader.ReadLine() 'ExcelListTeacher=
                    TextBoxExcelFile.Text = Mid(FileExcel, 11, Len(FileExcel) - 10) : FileExcel = TextBoxExcelFile.Text
                    TextBoxList.Text = Mid(ListExcel, 11, Len(ListExcel) - 10) : ListExcel = TextBoxList.Text
                    TextBoxListTeacher.Text = Mid(ListTeacherExcel, 18, Len(ListTeacherExcel) - 17) : ListTeacherExcel = TextBoxListTeacher.Text
                    NumericUpDownSemestr.Value = Mid(reader.ReadLine(), 9, 1)  'Semestr=
                    Semestr = NumericUpDownSemestr.Value
                    If Mid(reader.ReadLine(), 13, 1) = 1 Then CheckBoxAuthorization.Checked = True : reader.Close() : frm_login.ShowDialog() Else CheckBoxAuthorization.Checked = False : reader.Close() : LoginFail = False 'UsePassword=
                    If LoginFail = True Then End
                    If frm_login.CheckBoxRememberMe.Checked = True Then
                        CheckBoxAuthorization.Checked = False
                        CheckBoxAuthorization_Click(sender, e)
                    End If
                End If
            End Using
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                Dim SttRow As Integer
                For SttRow = 1 To 17
                    reader.ReadLine()
                Next
                If Mid(reader.ReadLine(), 10, 1) = "1" Then RadioButtonAskCIntHour.Checked = True : Rounding = False Else RadioButtonAutoCIntHour.Checked = True : Rounding = True 'Rounding=
                EXCELFirstRow.Text = Mid(reader.ReadLine(), 15)
                EXCELDisciplines.Text = Mid(reader.ReadLine(), 18)
                EXCELDisciplinesShort.Text = Mid(reader.ReadLine(), 23)
                EXCELDisciplinesExtraShort.Text = Mid(reader.ReadLine(), 28)
                EXCELTeathers.Text = Mid(reader.ReadLine(), 15)
                EXCELGroups.Text = Mid(reader.ReadLine(), 13)
                EXCELClassrooms.Text = Mid(reader.ReadLine(), 17)
                EXCEL1Semestr.Text = Mid(reader.ReadLine(), 15)
                EXCEL2Semestr.Text = Mid(reader.ReadLine(), 15)
                EXCELPCK.Text = Mid(reader.ReadLine(), 10)
                EXCELPCKForeignLang.Text = Mid(reader.ReadLine(), 21)
                EXCELFirstRowTeacher.Text = Mid(reader.ReadLine(), 22)
                EXCELTeatherList.Text = Mid(reader.ReadLine(), 18)
                reader.Close()
            End Using
        Catch
            MsgBox("Что-то пошло не так!" & vbCrLf & "Похоже ваши параметры сбились." & vbCrLf & "Сейчас будет воспроизведён первый запуск программы.", MsgBoxStyle.Exclamation, "Расписание КРУ: Ошибка запуска!")
            Dim SettingFile As String = "[TimetableKRU]" & vbCrLf & "FirstStart=1"
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
            frm_first.ShowDialog()
            frm_index_Load(sender, e)
        End Try
        NumericUpDownYears1.Value = Today.Year
        NumericUpDownYears2.Value = Today.Year + 1
        pUse = True
        gifImage_Animate_Form = ButtonForm.BackgroundImage
        MaxFrames_Animate_Form = gifImage_Animate_Form.GetFrameCount(New FrameDimension(gifImage_Animate_Form.FrameDimensionsList(0)))
        gifImage_Animate_Change_list = ButtonList.BackgroundImage
        MaxFrames_Animate_Change_list = gifImage_Animate_Change_list.GetFrameCount(New FrameDimension(gifImage_Animate_Change_list.FrameDimensionsList(0)))
        gifImage_Animate_Change_list_teacher = ButtonListTeacher.BackgroundImage
        MaxFrames_Animate_Change_list_teacher = gifImage_Animate_Change_list_teacher.GetFrameCount(New FrameDimension(gifImage_Animate_Change_list_teacher.FrameDimensionsList(0)))
        gifImage_Animate_Select_file = ButtonExcelFile.BackgroundImage
        MaxFrames_Animate_Select_file = gifImage_Animate_Select_file.GetFrameCount(New FrameDimension(gifImage_Animate_Select_file.FrameDimensionsList(0)))
    End Sub

    Private Sub ButtonExcelFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExcelFile.Click
        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then TextBoxExcelFile.Text = OpenFileDialog1.FileName
        Dim SettingFile As String = IO.File.ReadAllText(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
        Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            SettingFile = reader.ReadLine() '[TimetableKRU]
            SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'FirstStart=
            SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'Welcome=
            SettingFile = SettingFile & vbCrLf & "ExcelFile=" & TextBoxExcelFile.Text 'ExcelFile=
            reader.ReadLine()
            SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
            reader.Close()
        End Using
        IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
    End Sub

    Private Sub LinkLabelRestart_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelRestart.LinkClicked
        Application.Restart()
    End Sub

    Private Sub ButtonList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonList.Click
        Me.Cursor = Cursors.AppStarting
        Try
            frm_excel_sheets.Label1.Text = "Выберите из имеющихся, лист с нагрузкой, дисциплинами и преподавателями:"
            frm_excel_sheets.Label1.Height = 43
            If frm_excel_sheets.ShowDialog() = Windows.Forms.DialogResult.OK Then Me.TextBoxList.Text = frm_excel_sheets.ListBox1.SelectedItem
            Dim SettingFile As String = IO.File.ReadAllText(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                reader.ReadLine() '[TimetableKRU]
                reader.ReadLine() 'FirstStart=
                reader.ReadLine() 'Welcome=
                reader.ReadLine() 'ExcelFile=
                SettingFile = SettingFile.Replace(reader.ReadLine(), "ExcelList=" & Me.TextBoxList.Text) 'ExcelList=
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        Catch
            If TextBoxExcelFile.Text = "" Then
                MsgBox("Вы не указали Excel файл!", MsgBoxStyle.Critical, "Расписание КРУ: Вы не указали файл Excel!")
            Else
                MsgBox("Указанный Excel файл не существует или повреждён!", MsgBoxStyle.Critical, "Расписание КРУ: Невозможно загрузить файл!")
            End If
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub TextBoxList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxList.TextChanged
        ListExcel = Me.TextBoxList.Text
    End Sub

    Private Sub ButtonListTeacher_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonListTeacher.Click
        Me.Cursor = Cursors.AppStarting
        Try
            frm_excel_sheets.Label1.Text = "Выберите из имеющихся, лист с преподавателями:"
            frm_excel_sheets.Label1.Height = 18
            If frm_excel_sheets.ShowDialog() = Windows.Forms.DialogResult.OK Then Me.TextBoxListTeacher.Text = frm_excel_sheets.ListBox1.SelectedItem
            Dim SettingFile As String = IO.File.ReadAllText(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                reader.ReadLine() '[TimetableKRU]
                reader.ReadLine() 'FirstStart=
                reader.ReadLine() 'Welcome=
                reader.ReadLine() 'ExcelFile=
                reader.ReadLine() 'ExcelList=
                SettingFile = SettingFile.Replace(reader.ReadLine(), "ExcelListTeacher=" & Me.TextBoxListTeacher.Text) 'ExcelListTeacher=
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        Catch
            If TextBoxExcelFile.Text = "" Then
                MsgBox("Вы не указали Excel файл!", MsgBoxStyle.Critical, "Расписание КРУ: Вы не указали файл Excel!")
            Else
                MsgBox("Указанный Excel файл не существует или повреждён!", MsgBoxStyle.Critical, "Расписание КРУ: Невозможно загрузить файл!")
            End If
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub TextBoxListTeacher_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxListTeacher.TextChanged
        ListTeacherExcel = Me.TextBoxListTeacher.Text
    End Sub

    Private Sub TextBoxExcelFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxExcelFile.TextChanged
        FileExcel = Me.TextBoxExcelFile.Text
        Me.ToolTip1.SetToolTip(Me.TextBoxExcelFile, TextBoxExcelFile.Text)
    End Sub

    Private Sub NumericUpDownSemestr_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDownSemestr.ValueChanged
        If pUse = True Then
            Dim SettingFile As String = IO.File.ReadAllText(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'FirstStart=
                SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'Welcome=
                SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'ExcelFile=
                SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'ExcelList=
                SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'ExcelListTeacher=
                SettingFile = SettingFile & vbCrLf & "Semestr=" & Me.NumericUpDownSemestr.Value 'Semestr=
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
            Semestr = NumericUpDownSemestr.Value
        End If
    End Sub

    Private Sub NumericUpDownYears1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDownYears1.ValueChanged
        NumericUpDownYears2.Value = NumericUpDownYears1.Value + 1
    End Sub

    Private Sub NumericUpDownYears2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDownYears2.ValueChanged
        NumericUpDownYears1.Value = NumericUpDownYears2.Value - 1
    End Sub

    Private Sub LinkLabelEnd_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelEnd.LinkClicked
        End
    End Sub

    Private Sub LinkLabelFirstStart_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelFirstStart.LinkClicked
        Dim SettingFile As String = IO.File.ReadAllText(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
        Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            reader.ReadLine() '[TimetableKRU]
            SettingFile = SettingFile.Replace(reader.ReadLine(), "FirstStart=1")  'FirstStart=
            reader.Close()
        End Using
        IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        LinkLabelFirstStart.Enabled = False
        If MsgBox("Перезапустить приложение?", MsgBoxStyle.YesNo, "Расписание КРУ: Перезагрузка") = MsgBoxResult.Yes Then Application.Restart()
    End Sub

    Private Sub CheckBoxAuthorization_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxAuthorization.Click
        Dim SettingFile As String
        Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            SettingFile = reader.ReadLine() '[TimetableKRU]
            SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'FirstStart=
            SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'Welcome=
            SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'ExcelFile=
            SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'ExcelList=
            SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'ExcelListTeacher=
            SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'Semestr=
            If CheckBoxAuthorization.Checked = True Then
                SettingFile = SettingFile & vbCrLf & "UsePassword=1"  'UsePassword=
            Else
                SettingFile = SettingFile & vbCrLf & "UsePassword=0"  'UsePassword=
            End If
            reader.ReadLine()
            SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
            reader.Close()
        End Using
        IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
    End Sub

    Private Sub LinkLabelChangePassword_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelChangePassword.LinkClicked
        frm_change_password.ShowDialog()
    End Sub

    Sub GroupProcess()
        CurrentProcess = "GroupProcess"
        Me.Invoke(New ThreadStart(AddressOf TimerDisabled))
        LoadingLabelInfo = "Происходит отбор всех групп " & Semestr & " семестра."
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelInfoChange))
        LoadingLabelDescription = "Открытие документа"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
        LoadingLabelDescriptionHead = "Отбор групп"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionHeadChange))
        ProgressValue = 0
        Progress100 = False
        Me.Invoke(New ThreadStart(AddressOf ProgressBarChange))

        Dim EXCELSemestr As String
        If Semestr = "1" Then EXCELSemestr = Me.EXCEL1Semestr.Text Else EXCELSemestr = Me.EXCEL2Semestr.Text

        Dim objSheetWork As Excel._Worksheet
        Dim objAppWork = CreateObject("Excel.Application")
        Dim objBookWork As Excel._Workbook

        objBookWork = objAppWork.Workbooks.Open(FileExcel, ReadOnly:=True)
        objAppWork.Visible = False

        objSheetWork = objAppWork.Workbooks(1).Worksheets(ListExcel)

        LoadingLabelDescription = "Выборка учебных групп из документа"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
        Dim r As Integer = Me.EXCELFirstRow.Text
        Dim pGroup As Boolean = False 'Проверка на добавление группы в расписание
        Dim kGroup As Integer 'Количество групп для добавления в расписание
        Do While objSheetWork.Range(Me.EXCELGroups.Text & r).Value <> ""
            If (objSheetWork.Range(Me.EXCELGroups.Text & r).Value <> objSheetWork.Range(Me.EXCELGroups.Text & r - 1).Value) Then pGroup = True
            If Not (objSheetWork.Range(EXCELSemestr & r).Value) = Nothing And pGroup = True Then kGroup = kGroup + 1 : pGroup = False
            r = r + 1
        Loop
        ProgressValue = ProgressValue + 20
        Me.Invoke(New ThreadStart(AddressOf ProgressBarChange))
        Dim Groups(kGroup - 1) As String 'Массив с группами
        Dim nGroup As Integer = 0 'Порядковый номер группы
        Dim iGroup1 As Integer = 0 'Порядковый номер группы для перебора
        Dim p1Group As Boolean = True 'Проверка на уникальность группы в массиве
        r = Me.EXCELFirstRow.Text
        Do While objSheetWork.Range(Me.EXCELGroups.Text & r).Value <> ""
            If (objSheetWork.Range(Me.EXCELGroups.Text & r).Value <> objSheetWork.Range(Me.EXCELGroups.Text & r - 1).Value) Then pGroup = True
            If Not (objSheetWork.Range(EXCELSemestr & r).Value) = Nothing And pGroup = True Then
                ProgressValue = ProgressValue + Int((60 / (kGroup)))
                Me.Invoke(New ThreadStart(AddressOf ProgressBarChange))
                For iGroup1 = 0 To Groups.GetUpperBound(0)
                    If Groups(iGroup1) = objSheetWork.Range(Me.EXCELGroups.Text & r).Value Then p1Group = False : Exit For
                Next
                If p1Group = True Then Groups(nGroup) = objSheetWork.Range(Me.EXCELGroups.Text & r).Value : nGroup = nGroup + 1 : pGroup = False Else p1Group = True
            End If
            r = r + 1
        Loop
        ReDim Preserve Groups(nGroup - 1)
        Array.Sort(Groups)

        LoadingLabelDescription = "Сохранение выборки учебных групп из документа"
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
        Dim SettingFile1 As String
        Using reader1 As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            SettingFile1 = reader1.ReadLine() '[TimetableKRU]
            SettingFile1 = SettingFile1 & vbCrLf & reader1.ReadLine() 'FirstStart=
            SettingFile1 = SettingFile1 & vbCrLf & reader1.ReadLine() 'Welcome=
            SettingFile1 = SettingFile1 & vbCrLf & reader1.ReadLine() 'ExcelFile=
            SettingFile1 = SettingFile1 & vbCrLf & reader1.ReadLine() 'ExcelList=
            SettingFile1 = SettingFile1 & vbCrLf & reader1.ReadLine() 'ExcelListTeacher=
            SettingFile1 = SettingFile1 & vbCrLf & reader1.ReadLine() 'Semestr=
            SettingFile1 = SettingFile1 & vbCrLf & reader1.ReadLine() 'UsePassword=
            SettingFile1 = SettingFile1 & vbCrLf & reader1.ReadLine() 'Password=
            SettingFile1 = SettingFile1 & vbCrLf & "Groups=" 'Groups=
            For iGroup1 = 0 To Groups.GetUpperBound(0)
                SettingFile1 = SettingFile1 & Groups(iGroup1) + "; "
            Next
            reader1.ReadLine()
            SettingFile1 = SettingFile1 & vbCrLf & reader1.ReadToEnd
            reader1.Close()
        End Using
        IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile1, System.Text.Encoding.Default)

        For iGroup1 = 0 To Groups.GetUpperBound(0)
            frm_groups.ListBox1.Items.Add(Groups(iGroup1))
        Next

        ProgressValue = ProgressValue + 20
        Progress100 = True
        Me.Invoke(New ThreadStart(AddressOf ProgressBarChange))

        objAppWork.ActiveWindow.Close(SaveChanges:=False)
        objAppWork.Quit()
        objAppWork = Nothing
        GC.Collect()
        frm_loading.Close()
        LoadingLabelDescription = ""
        Me.Invoke(New ThreadStart(AddressOf LoadingLabelDescriptionChange))
        Me.Invoke(New ThreadStart(AddressOf FormEnabledTrue))
        ProgressValue = 0
        Me.Invoke(New ThreadStart(AddressOf ProgressBarChange))
    End Sub

    Dim refresh As Boolean = False

    Private Sub LinkLabelGroups_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkLabelGroups.Click
        Me.Cursor = Cursors.AppStarting
        frm_groups.ListBox1.Items.Clear()
        frm_groups.ButtonRefresh.Visible = True
        Dim GroupsRead As String
        Dim i1Sym As Integer = 1
        Dim i2Sym As Integer
        Dim p As Boolean = True
        Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            reader.ReadLine() '[TimetableKRU]
            reader.ReadLine() 'FirstStart=
            reader.ReadLine() 'Welcome=
            reader.ReadLine() 'ExcelFile=
            reader.ReadLine() 'ExcelList=
            reader.ReadLine() 'ExcelListTeacher=
            reader.ReadLine() 'Semestr=
            reader.ReadLine() 'UsePassword=
            reader.ReadLine() 'Password=
            If refresh = False Then GroupsRead = Mid(reader.ReadLine(), 8) Else GroupsRead = "" 'Groups=
            If GroupsRead <> "" Then
                For i2Sym = 1 To Len(GroupsRead)
                    If Mid(GroupsRead, i2Sym, 1) = ";" Then p = True : i1Sym = i2Sym + 2
                    If Mid(GroupsRead, i2Sym + 1, 1) = ";" And p = True Then p = False : frm_groups.ListBox1.Items.Add(Mid(GroupsRead, i1Sym, i2Sym + 1 - i1Sym))
                Next
                reader.Close()
            Else
                reader.Close()
                If refresh = False Then
                    If MsgBox("Список учебных групп ещё не создан." & vbCrLf & "Сейчас все имеющиеся группы будут собраны и отсортированы." & vbCrLf & "Для продолжения нажмите " & Chr(34) & "ОК" & Chr(34) & ".", MsgBoxStyle.OkCancel, "Расписание КРУ: Выборка групп") = MsgBoxResult.Ok Then p = True Else p = False : Me.Cursor = Cursors.Default
                Else
                    p = True
                End If
                If p = True Then
                    Me.PanelLoading.Visible = True
                    Me.PanelSetting.Visible = False
                    Me.PictureBoxTimetable.Image = My.Resources.icons8_calendar_filled_40_block
                    Me.PictureBoxSetting.Image = My.Resources.icons8_settings_40_active_block
                    Me.PictureBoxInfo.Image = My.Resources.icons8_information_40_block
                    Me.PictureBoxExit.Image = My.Resources.icons8_exit_sign_filled_40_block
                    Me.Enabled = False
                    frm_loading.Text = "Расписание КРУ: (0%) Формирование списка групп"
                    frm_loading.LabelTimer.Text = "-:-"
                    Th = New System.Threading.Thread(AddressOf GroupProcess)
                    Th.SetApartmentState(ApartmentState.STA)
                    Th.Start()
                    frm_loading.ShowDialog()
                Else
                    Exit Sub
                End If
            End If
        End Using
        If p = True Then
            frm_groups.ListBox1.Items.Clear()
            i1Sym = 1
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                reader.ReadLine() '[TimetableKRU]
                reader.ReadLine() 'FirstStart=
                reader.ReadLine() 'Welcome=
                reader.ReadLine() 'ExcelFile=
                reader.ReadLine() 'ExcelList=
                reader.ReadLine() 'ExcelListTeacher=
                reader.ReadLine() 'Semestr=
                reader.ReadLine() 'UsePassword=
                reader.ReadLine() 'Password=
                GroupsRead = Mid(reader.ReadLine(), 8) 'Groups=
                For i2Sym = 1 To Len(GroupsRead)
                    If Mid(GroupsRead, i2Sym, 1) = ";" Then p = True : i1Sym = i2Sym + 2
                    If Mid(GroupsRead, i2Sym + 1, 1) = ";" And p = True Then frm_groups.ListBox1.Items.Add(Mid(GroupsRead, i1Sym, i2Sym + 1 - i1Sym))
                Next
                reader.Close()
            End Using
        End If
        Dim SettingFile As String = IO.File.ReadAllText(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
        Dim iGroup As Integer
        Select Case frm_groups.ShowDialog()
            Case Windows.Forms.DialogResult.OK
                Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                    SettingFile = reader.ReadLine() '[TimetableKRU]
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'FirstStart=
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'Welcome=
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'ExcelFile=
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'ExcelList=
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'ExcelListTeacher=
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'Semestr=
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'UsePassword=
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'Password=
                    SettingFile = SettingFile & vbCrLf & "Groups=" 'Groups=
                    For iGroup = 0 To frm_groups.ListBox1.Items.Count - 1
                        SettingFile = SettingFile & frm_groups.ListBox1.Items(iGroup) + "; "
                    Next
                    reader.ReadLine()
                    SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                    reader.Close()
                End Using
                IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
            Case Windows.Forms.DialogResult.Retry
                refresh = True
                LinkLabelGroups_Click(sender, e)
        End Select
        refresh = False
    End Sub

    Private Sub LinkLabelAutor_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelAutor.LinkClicked
        System.Diagnostics.Process.Start("http://vk.com/id141066071")
    End Sub

    Private Sub CheckBoxWelcomeForm_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxWelcomeForm.Click
        Dim SettingFile As String
        Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            SettingFile = reader.ReadLine() '[TimetableKRU]
            SettingFile = SettingFile & vbCrLf & reader.ReadLine() 'FirstStart=
            If CheckBoxWelcomeForm.Checked = True Then SettingFile = SettingFile & vbCrLf & "Welcome=1" Else SettingFile = SettingFile & vbCrLf & "Welcome=0" 'Welcome=
            reader.ReadLine()
            SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
            reader.Close()
        End Using
        IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
    End Sub
    Dim hPanelInInfo As Integer = 124
    Private Sub frm_index_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        If Me.Size.Width < 712 Then
            Label10.Height = 59
            PanelInInfo.Size = New Size(PanelInInfo.Width, Me.Height - hPanelInInfo)
        ElseIf Me.Size.Width >= 712 And Me.Size.Width < 1328 Then
            Label10.Height = 41
            PanelInInfo.Size = New Size(PanelInInfo.Width, Me.Height - hPanelInInfo + 18)
        ElseIf Me.Size.Width >= 1328 Then
            Label10.Height = 18
            PanelInInfo.Size = New Size(PanelInInfo.Width, Me.Height - hPanelInInfo + 23)
        End If
        PanelInInfo.Location = New Point(0, Label10.Location.Y + Label10.Size.Height + 6)
        PanelInfo.Refresh()
        If Me.Size.Width < 707 Then
            Label17.Size = New Size(Label17.Width, 76)
            Label18.Location = New Point(8, Label17.Location.Y + Label17.Size.Height)
        ElseIf Me.Size.Width > 706 And Me.Size.Width < 1004 Then
            Label17.Size = New Size(Label17.Width, 60)
            Label18.Location = New Point(8, Label17.Location.Y + Label17.Size.Height)
        ElseIf Me.Size.Width > 1003 And Me.Size.Width < 1918 Then
            Label17.Size = New Size(Label17.Width, 42)
            Label18.Location = New Point(8, Label17.Location.Y + Label17.Size.Height)
        Else
            Label17.Size = New Size(Label17.Width, 22)
            Label18.Location = New Point(8, Label17.Location.Y + Label17.Size.Height)
        End If
        If Me.Size.Width < 775 Then
            Label18.Size = New Size(Label18.Width, 40)
            Label19.Location = New Point(8, Label18.Location.Y + Label18.Size.Height)
        Else
            Label18.Size = New Size(Label18.Width, 24)
            Label19.Location = New Point(8, Label18.Location.Y + Label18.Size.Height)
        End If
        If Me.Size.Width < 861 Then
            Label19.Size = New Size(Label19.Width, 40)
            Label20.Location = New Point(8, Label19.Location.Y + Label19.Size.Height)
            Label21.Location = New Point(8, Label20.Location.Y + Label20.Size.Height + 4)
            Label22.Location = New Point(8, Label21.Location.Y + Label21.Size.Height)
            Label23.Location = New Point(8, Label22.Location.Y + Label22.Size.Height)
            LinkLabelAutor.Location = New Point(8, Label23.Location.Y + Label23.Size.Height + 12)
        Else
            Label19.Size = New Size(Label19.Width, 24)
            Label20.Location = New Point(8, Label19.Location.Y + Label19.Size.Height)
            Label21.Location = New Point(8, Label20.Location.Y + Label20.Size.Height + 4)
            Label22.Location = New Point(8, Label21.Location.Y + Label21.Size.Height)
            Label23.Location = New Point(8, Label22.Location.Y + Label22.Size.Height)
            LinkLabelAutor.Location = New Point(8, Label23.Location.Y + Label23.Size.Height + 12)
        End If
    End Sub

    Private Sub LinkLabelChangeHead_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelChangeHead.LinkClicked
        Me.Cursor = Cursors.AppStarting
        frm_change_head.Show()
    End Sub

    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonAskCIntHour.Click
        Dim SettingFile As String
        Dim SttRow As Integer
        Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            SettingFile = reader.ReadLine() '[TimetableKRU]
            For SttRow = 1 To 16
                SettingFile = SettingFile & vbCrLf & reader.ReadLine()
            Next
            If RadioButtonAskCIntHour.Checked = True Then SettingFile = SettingFile & vbCrLf & "Rounding=1" : Rounding = False Else SettingFile = SettingFile & vbCrLf & "Rounding=2" : Rounding = True
            reader.ReadLine()
            SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
            reader.Close()
        End Using
        IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
    End Sub

    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonAutoCIntHour.Click
        Dim SettingFile As String
        Dim SttRow As Integer
        Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
            SettingFile = reader.ReadLine() '[TimetableKRU]
            For SttRow = 1 To 16
                SettingFile = SettingFile & vbCrLf & reader.ReadLine()
            Next
            If RadioButtonAutoCIntHour.Checked = True Then SettingFile = SettingFile & vbCrLf & "Rounding=2" : Rounding = True Else SettingFile = SettingFile & vbCrLf & "Rounding=1" : Rounding = False
            reader.ReadLine()
            SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
            reader.Close()
        End Using
        IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
    End Sub

    Private Sub EXCELFirstRow_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELFirstRow.TextChanged
        If pUse = True Then
            Dim SettingFile As String
            Dim SttRow As Integer
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                For SttRow = 1 To 17
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                Next
                SettingFile = SettingFile & vbCrLf & "EXCELFirstRow=" & Me.EXCELFirstRow.Text
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        End If
    End Sub

    Private Sub EXCELDisciplines_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELDisciplines.TextChanged
        If pUse = True Then
            Dim SettingFile As String
            Dim SttRow As Integer
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                For SttRow = 1 To 18
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                Next
                SettingFile = SettingFile & vbCrLf & "EXCELDisciplines=" & Me.EXCELDisciplines.Text
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        End If
    End Sub

    Private Sub EXCELDisciplinesShort_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELDisciplinesShort.TextChanged
        If pUse = True Then
            Dim SettingFile As String
            Dim SttRow As Integer
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                For SttRow = 1 To 19
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                Next
                SettingFile = SettingFile & vbCrLf & "EXCELDisciplinesShort=" & Me.EXCELDisciplinesShort.Text
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        End If
    End Sub

    Private Sub EXCELDisciplinesExtraShort_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELDisciplinesExtraShort.TextChanged
        If pUse = True Then
            Dim SettingFile As String
            Dim SttRow As Integer
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                For SttRow = 1 To 20
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                Next
                SettingFile = SettingFile & vbCrLf & "EXCELDisciplinesExtraShort=" & Me.EXCELDisciplinesExtraShort.Text
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        End If
    End Sub

    Private Sub EXCELTeathers_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELTeathers.TextChanged
        If pUse = True Then
            Dim SettingFile As String
            Dim SttRow As Integer
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                For SttRow = 1 To 21
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                Next
                SettingFile = SettingFile & vbCrLf & "EXCELTeathers=" & Me.EXCELTeathers.Text
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        End If
    End Sub

    Private Sub EXCELGroups_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELGroups.TextChanged
        If pUse = True Then
            Dim SettingFile As String
            Dim SttRow As Integer
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                For SttRow = 1 To 22
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                Next
                SettingFile = SettingFile & vbCrLf & "EXCELGroups=" & Me.EXCELGroups.Text
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        End If
    End Sub

    Private Sub EXCELClassrooms_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELClassrooms.TextChanged
        If pUse = True Then
            Dim SettingFile As String
            Dim SttRow As Integer
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                For SttRow = 1 To 23
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                Next
                SettingFile = SettingFile & vbCrLf & "EXCELClassrooms=" & Me.EXCELClassrooms.Text
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        End If
    End Sub

    Private Sub EXCEL1Semestr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCEL1Semestr.TextChanged
        If pUse = True Then
            Dim SettingFile As String
            Dim SttRow As Integer
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                For SttRow = 1 To 24
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                Next
                SettingFile = SettingFile & vbCrLf & "EXCEL1Semestr=" & Me.EXCEL1Semestr.Text
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        End If
    End Sub

    Private Sub EXCEL2Semestr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCEL2Semestr.TextChanged
        If pUse = True Then
            Dim SettingFile As String
            Dim SttRow As Integer
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                For SttRow = 1 To 25
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                Next
                SettingFile = SettingFile & vbCrLf & "EXCEL2Semestr=" & Me.EXCEL2Semestr.Text
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        End If
    End Sub

    Private Sub EXCELPCK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELPCK.TextChanged
        If pUse = True Then
            Dim SettingFile As String
            Dim SttRow As Integer
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                For SttRow = 1 To 26
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                Next
                SettingFile = SettingFile & vbCrLf & "EXCELPCK=" & Me.EXCELPCK.Text
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        End If
    End Sub

    Private Sub EXCELPCKForeignLang_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELPCKForeignLang.TextChanged
        If pUse = True Then
            Dim SettingFile As String
            Dim SttRow As Integer
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                For SttRow = 1 To 27
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                Next
                SettingFile = SettingFile & vbCrLf & "EXCELPCKForeignLang=" & Me.EXCELPCKForeignLang.Text
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        End If
    End Sub

    Private Sub EXCELFirstRowTeacher_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELFirstRowTeacher.TextChanged
        If pUse = True Then
            Dim SettingFile As String
            Dim SttRow As Integer
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                For SttRow = 1 To 28
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                Next
                SettingFile = SettingFile & vbCrLf & "EXCELFirstRowTeacher=" & Me.EXCELFirstRowTeacher.Text
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        End If
    End Sub

    Private Sub EXCELTeatherList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXCELTeatherList.TextChanged
        If pUse = True Then
            Dim SettingFile As String
            Dim SttRow As Integer
            Using reader As New System.IO.StreamReader(CurDir() & "\Setting.ini", System.Text.Encoding.Default)
                SettingFile = reader.ReadLine() '[TimetableKRU]
                For SttRow = 1 To 29
                    SettingFile = SettingFile & vbCrLf & reader.ReadLine()
                Next
                SettingFile = SettingFile & vbCrLf & "EXCELTeatherList=" & Me.EXCELTeatherList.Text
                reader.ReadLine()
                SettingFile = SettingFile & vbCrLf & reader.ReadToEnd
                reader.Close()
            End Using
            IO.File.WriteAllText(CurDir() & "\Setting.ini", SettingFile, System.Text.Encoding.Default)
        End If
    End Sub

    Private Sub ButtonDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDefault.Click
        If MsgBox("Вы уверены что хотите установить значения по умолчанию?", 36, "Расписание КРУ: Значения по умолчанию") = MsgBoxResult.Yes Then
            CheckBoxWelcomeForm.Checked = True
            CheckBoxWelcomeForm_Click(sender, e)
            CheckBoxAuthorization.Checked = False
            CheckBoxAuthorization_Click(sender, e)
            RadioButtonAskCIntHour.Checked = True
            RadioButton1_Click(sender, e)
            EXCELFirstRow.Text = "5"
            EXCELDisciplines.Text = "A"
            EXCELDisciplinesShort.Text = "AD"
            EXCELDisciplinesExtraShort.Text = "AE"
            EXCELTeathers.Text = "C"
            EXCELGroups.Text = "D"
            EXCELClassrooms.Text = "AF"
            EXCEL1Semestr.Text = "E"
            EXCEL2Semestr.Text = "G"
            EXCELPCK.Text = "B"
            EXCELPCKForeignLang.Text = "ИнЯз"
            EXCELFirstRowTeacher.Text = "5"
            EXCELTeatherList.Text = "C"
        End If
    End Sub

    Private Sub LinkLabelFontSetting_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelFontSetting.LinkClicked
        Me.Cursor = Cursors.AppStarting
        frm_font_setting.Show()
    End Sub

    Private Sub LinkLabelHelp_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LinkLabelHelp.Click
        Try
            Process.Start(CurDir() & "\TimetableKRU.chm")
        Catch
            MsgBox("Файл справки не найден!", MsgBoxStyle.Critical, "Расписание КРУ: Ошибка чтения файла справки")
        End Try
    End Sub
End Class
