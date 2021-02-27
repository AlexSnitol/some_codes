Module Module1
    Public LoginStatus As Boolean = False 'Проверка авторизации
    Public v1 As Boolean = True 'Проверка нажатия на кнопку Печать, первый раз или нет
    Public v2 As Boolean = False 'Нажата кнопка печати ли нет
    Public v3 As Boolean = False 'Изменены или не измененны исходные данные
    Public vUpdateTable As Boolean = False 'Проверка изменений в таблицах
    Public vUpdateTableVidRabot As Boolean = False 'Проверка изменений в таблице Виды работ 
    Public preview As Boolean = True 'Предпросмотр или нет
    Public vStudent As Boolean = False 'Известен студент или нет
    Public CheckVidRabot As Boolean = True
    Public RatingAvg As Single = 0 'Средний балл
    Public vRatingAvg As Boolean = False 'Все оценки или не ве
    Public v2RatingAvg As Boolean = False 'Есть двойки или нет
    Public pol As String = "m" 'Пол практиканта 
    Public uchpractika As String '
    Public vRefresh As Boolean = False 'Было обновление предпросмотра или нет
    Public PrevValue As Integer = -2 'Предыдущее значение поля со списком учебные практики
    Public ReDoc As Boolean = False 'Переформирование документа
    Public pChangeSetting As Boolean = False 'Проверка на изменение параметров
    Public tmp As String = "" 'Временное хранилище
    Public tmp2 As String = "" 'Временное хранилище
    Public c As Integer 'Для генерации фона в форме авторизации
    Public Sub RandomColor()
        Randomize()
        c = CInt(Math.Ceiling(Rnd() * 5))
    End Sub
End Module
