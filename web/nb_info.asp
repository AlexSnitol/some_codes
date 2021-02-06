<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">
<%
if session("user") = "" or session("user") = "Студент" or session("user") = 0 then response.Redirect ("404.asp")
'---------------------------------------------------
'Защита от SQL-инъекции
'---------------------------------------------------
all = request.QueryString
for i=1 to len(all)
    if len(all)-6 > 0 then
        if mid(all,i,6)="SELECT" or mid(all,i,6)="INSERT" or mid(all,i,6)="DELETE" or mid(all,i,5)="UNION" then 
            response.redirect("index.asp?err=1")
        end if
    end if
    if len (all)-3 > 0 then
        if mid(all,i,3)="AND" or mid(all,i,3)="XOR" then
            response.Redirect ("index.asp?err=1")
        end if
    end if
    if mid(all,i,1)=";" then response.Redirect ("index.html?err=1")
next
'---------------------------------------------------
'Проверка подлинности пользователя и прав администратора
'---------------------------------------------------
Response.Expires=-1
if session("user") = "" then response.Redirect ("exit.asp")
'----------------------------------------------------
'Подключение БД
'----------------------------------------------------
Set Conn = Server.CreateObject("ADODB.Connection") 
strDBPath = Server.MapPath("base.mdb")
Conn.Open "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & strDBPath
Set RS_group = Server.CreateObject("ADODB.Recordset")
Set RS_disGroup = Server.CreateObject("ADODB.Recordset")
Set RS_studgr = Server.CreateObject("ADODB.Recordset")
Set RS_prep = Server.CreateObject("ADODB.Recordset")
Set RS_disc = Server.CreateObject("ADODB.Recordset")
Set RS_save = Server.CreateObject("ADODB.Recordset")
%>
<html>
	<head>
		<meta content="text/html; charset=Windows-1251" http-equiv="content-type">
		<link rel="shortcut icon" href="images/favicon.ico" /> 
		<link rel="stylesheet" href="css/metro.css">
		<link rel="stylesheet" href="css/metro-colors.css">
		<link rel="stylesheet" href="css/metro-icons.css">
		<link rel="stylesheet" href="css/metro-responsive.css">
		<link rel="stylesheet" href="css/metro-rtl.css">
		<link rel="stylesheet" href="css/metro-schemes.css">
        <link rel="stylesheet" href="css/table_style.css">
		<script src="js/jquery-3.1.0.min.js"></script>
		<script src="js/metro.min.js"></script>
		<title>ИС "Электронный журнал". Журнал учёта пропусков занятий на <% response.write (mid(now(),1,10))%></title>
        <style>
            .button_group_normal{
                background-color: #60a917;
                color: white;
                border-style: solid;
                border-width: 2px;
                border-color: #60a917;
                display: table-cell;
                vertical-align: middle;
                margin: 5px;
                width: 150px;
                height: 65px;
                text-align: center;
                cursor: pointer;
                transition: 0.1s;
            }
            .button_group_normal:hover{
                background-color: white;
                color: #60a917;
                font-weight: 500;
            }
            .button_group_normal.active{
                border-color: #00356a;
            }
            .button_group_edit{
                background-color: #ce352c;
                color: white;
                border-style: solid;
                border-width: 2px;
                border-color: #ce352c;
                display: table-cell;
                vertical-align: middle;
                margin: 5px;
                width: 150px;
                height: 65px;
                text-align: center;
                cursor: pointer;
                transition: 0.1s;
            }
            .button_group_edit:hover{
                background-color: white;
                color: #ce352c;
                font-weight: 500;
            }
            .button_group_edit.active{
                border-color: #00356a;
            }
            .button_semestr{
                background-color: #59cde2;
                color: white;
                border-style: solid;
                border-width: 2px;
                border-color: #59cde2;
                display: table-cell;
                vertical-align: middle;
                margin: 5px;
                width: 300px;
                height: 65px;
                text-align: center;
                cursor: pointer;
                transition: 0.1s;
            }
            .button_semestr:hover{
                background-color: white;
                color: #59cde2;
                border-color: #59cde2;
                font-weight: 500;
            }
            .button_semestr_active{
                background-color: #2086bf;
                color: white;
                border-style: solid;
                border-width: 2px;
                border-color: #00356a;
                display: table-cell;
                vertical-align: middle;
                margin: 5px;
                width: 300px;
                height: 65px;
                text-align: center;
                cursor: pointer;
                transition: 0.1s;
            }
            .button_semestr_active:hover{
                background-color: white;
                color: #2086bf;
                border-color: #00356a;
                font-weight: 500;
            }
            .table_group_normal{
                border-width: 2px;
                border-style: solid;
                border-collapse: separate;
                border-color: #60a917;
                padding: 0px;
                font-size: 12pt;
            }
            .table_group_normal th{
                background-color: #60a917;
                color: white;
                cursor: default;
                font-weight: 500;
                border-width: 1px;
                border-style: double;
                border-color: #FFFFFF;
                box-shadow: inset 0px 0px 0px 1px #FFFFFF;
                font-size: 10pt;
            }
            .table_group_normal td{
                border-style: solid;
                border-color: #000000;
                font-size: 10pt;
                padding: 5px;
            }
            .table_group_normal tr:hover{
                background-color: #60a917;
                color: white;
                border-style: solid;
                border-color: #60a917;
                border-width: 1px;
            }
            .table_group_normal a{
                color: white;
            }
            .table_group_edit{
                border-width: 2px;
                border-style: solid;
                border-collapse: separate;
                border-color: #ce352c;
                padding: 0px;
                font-size: 12pt;
            }
            .table_group_edit th{
                background-color: #ce352c;
                color: white;
                cursor: default;
                font-weight: 500;
                border-width: 1px;
                border-style: double;
                border-color: #FFFFFF;
                box-shadow: inset 0px 0px 0px 1px #FFFFFF;
                font-size: 10pt;
            }
            .table_group_edit td{
                border-style: solid;
                border-color: #000000;
                font-size: 10pt;
                padding: 5px;
            }
            .table_group_edit tr:hover{
                background-color: #ce352c;
                color: white;
                border-style: solid;
                border-color: #ce352c;
                border-width: 1px;
            }
            .table_group_edit a{
                color: white;
            }
            .text_description{
                text-align: center;
                padding: .45rem;
                width: 50px;
                transition: 0.5s;
                }
            #loader {
                position: fixed;
                width: 100%;
                height: 100%;
                background-color: rgba(0,0,0,0.50);
                left: 0;
                top: 0;
                z-index: 1;
                display: block;
                }
            .button_save{
                position: fixed;
                right: 0;
                bottom: 0;
                width: 80px;
                height: 80px;
                padding: 12px;
                margin: 20px;
                border-radius: 5px;
                background-color: #0072c6;
                /*border-color: #0072c6;*/
                border-color: #00356a;
                border-style: solid;
                border-width: 2px;
                font-family: Calibri;
                color: white;
                text-align: center;
                font-size: 9pt;
                box-shadow: 0 0 20px rgba(0,0,0,0.2);
                transition: 0.2s;
                }
            .mif-floppy-disk {
                color: white;
                margin: 0;
                padding: 6px;
                }
            .button_save p{
                color: white;
                margin: 0;
                padding: 0;
                }
            .button_save:hover{
                background-color: #FFFFFF;
                border-color: #0072c6;
                font-family: Calibri;
                color: #0072c6;
                text-align: center;
                font-size: 8pt;
                }
            .button_save:hover p{
                color: #0072c6;
                font-size: 9pt;
                }
            .button_save:hover .mif-floppy-disk{
                color: #0072c6;
                }
            @media print {
                .button_save{
                    display: none;
                    }
                }
        </style>
	</head>
    <script>
        function ShowHideLoader(operation){
			if (operation == "hide"){
                document.getElementById("loader").style.display = "none";
            } else {
                document.getElementById("loader").style.display = "block";    
            }
		}
        function onPOST(group_name, form_name, status, operation, action){
            document.getElementById("select_group").value = group_name;
            document.getElementById("select_group_status").value = status;
            if (operation == "Save"){
                document.getElementById("select_operation").value = "save";
                }
            if (operation == "Reset"){
                document.getElementById("select_operation").value = "reset";
                }
            document.getElementById(form_name).submit();
        }
        function changeSemestr(semestr){
            var myDate = new Date();
            document.getElementById("select_semestr").value = semestr;
            if (semestr == 1){
                if (myDate.getMonth() >= 9 && myDate.getMonth() <= 12){
                    document.getElementById("select_data_first").value = (myDate.getFullYear()) + "-09-01";
                    document.getElementById("select_data_second").value = (myDate.getFullYear()) + "-12-31";
                } else {
                    document.getElementById("select_data_first").value = (myDate.getFullYear() - 1) + "-09-01";
                    document.getElementById("select_data_second").value = (myDate.getFullYear() - 1) + "-12-31";
                }
            } else {
                if (myDate.getMonth() >= 9 && myDate.getMonth() <= 12) {
                    document.getElementById("select_data_first").value = (myDate.getFullYear() + 1) + "-01-01";
                    document.getElementById("select_data_second").value = (myDate.getFullYear() + 1) + "-08-31";
                } else {
                    document.getElementById("select_data_first").value = myDate.getFullYear() + "-01-01";
                    document.getElementById("select_data_second").value = myDate.getFullYear() + "-08-31";
                }
            }
        }
        function changeSortData(sort){
            if (sort == "ASC"){
                    document.getElementById("select_sort_data").value = "DESC";
                } else {
                    document.getElementById("select_sort_data").value = "ASC";
                }
            }
        function onkeydown() {
            if (event.keyCode == 116) {
                ShowHideLoader('show');
                }
            if (event.keyCode == 27) {
                ShowHideLoader('hide');
                }
            }
        window.onbeforeunload = function(e) {
			ShowHideLoader('show');
		};
        function onLoad()
            {
                document.onkeydown=onkeydown;
            }
        //Скрипт для подгонки ширины внутренней таблицы под основную
        function changeWidth(table_id){
            var twidth = document.getElementById("table_content").offsetWidth;
            document.getElementById(table_id).style.width = (twidth - 4) + "px";
        }
        //Скрипт для установления причин по датам (НАДО ДОДЕЛАТЬ)
        function ChangeSelectTypeNb(id_stud){
            var data_first = document.getElementById("select_data_first_stud_" + id_stud).value;
            var data_second = document.getElementById("select_data_second_stud_" + id_stud).value;
            while (data_first <= data_second){
                alert(data_first);
                data_first.addDays(1);
                }
            var data = document.getElementById("data_id_stud_" + id_stud).value
            }
    </script>
    <body onload='javascript:onLoad();'>
<%
'----------------------------------------------------
'Объявление и присваивание значений переменным
'----------------------------------------------------
dim output 'Переменная для разрешения вывода
output = true
dim output_par 'Переменная для разрешения вывода параметров
output_par = true
dim current_semestr
current_semestr = ""
current_semestr = current_semestr & request.form("select_semestr")
if current_semestr = "" then
    if Month(Date())=>9 then
        current_semestr = 1
    else
        current_semestr = 2
    end if
end if
dim current_group
current_group = ""
current_group = current_group & request.form("select_group")
if current_group = "" then
    output_par = false
    output = false
end if
dim disc()
dim current_disc
current_disc = ""
current_disc = current_disc & request.form("select_disc")
if current_disc = "" then
	current_disc = "all"
end if
dim stud_id
stud_id = ""
stud_id = stud_id & request.form("select_stud")
if stud_id = "" then
    stud_id = "all"
    output = false
end if
dim disGroup() 'массив с записями группы
dim p_stud 'Проверка на учащегося
dim p_disc 'Проверка на обработку записи
dim k_nb 'Количество нб учащегося
k_nb = 0
dim k_stud 'Количество студентов с нб
k_stud = 0
dim stud()
dim current_sort_data
current_sort_data = ""
current_sort_data = current_sort_data & request.form("select_sort_data")
if current_sort_data = "" then
    current_sort_data = "DESC"
end if
dim current_data_first
dim current_data_second
dim current_data_first_html
dim current_data_second_html
current_data_first_html = ""
current_data_second_html = ""
current_data_first_html = current_data_first_html & request.form("select_data_first")
current_data_second_html = current_data_second_html & request.form("select_data_second")
if current_data_first_html = "" or current_data_second_html = "" then
    if current_semestr = 1 then
        if month(now()) >= 9 and month(now()) <= 12 then
            current_data_first_html = Year(now) & "-09-01" 
            current_data_second_html = Year(now) & "-12-31"
        else
            current_data_first_html = Year(now) - 1 & "-09-01"
            current_data_second_html = Year(now) - 1 & "-12-31"
        end if
    else
        if month(now()) >= 9 and month(now()) <= 12 then
            current_data_first_html = Year(now) + 1 & "-01-01"
            current_data_second_html = Year(now) + 1 & "-08-31"
        else
            current_data_first_html = Year(now) & "-01-01"
            current_data_second_html = Year(now) & "-08-31"
        end if
    end if
end if
dim current_output_nb_all 'Переменная для фильтра обработанных записей
current_output_nb_all = current_output_nb_all & request.form("select_output_nb_all")
if current_output_nb_all = "" then
    current_output_nb_all = false
else
    if current_output_nb_all = "off" then current_output_nb_all = false else current_output_nb_all = true
end if
dim current_group_status 'Статус группы
current_group_status = ""
current_group_status = current_group_status & request.form("select_group_status")
'------------------------------------------------------------
'СОХРАНЕНИЕ
'------------------------------------------------------------
dim current_operation
current_operation = request.form("select_operation")
if current_operation = "save" then
    'Меняем формат даты с 2019-12-01 на 12/01/2019
    for i_sym = 1 to len(current_data_first_html)
        if mid(current_data_first_html, i_sym, 1) = "-" then
            for j_sym = i_sym + 1 to len(current_data_first_html)
                if mid(current_data_first_html, j_sym, 1) = "-" then
                    current_data_first = mid(current_data_first_html, i_sym + 1, j_sym - i_sym - 1) & "/" & mid(current_data_first_html, j_sym + 1) & "/" & mid(current_data_first_html, 1, i_sym - 1)
                    exit for
                end if
            next
        end if
    next
    for i_sym = 1 to len(current_data_second_html)
        if mid(current_data_second_html, i_sym, 1) = "-" then
            for j_sym = i_sym + 1 to len(current_data_second_html)
                if mid(current_data_second_html, j_sym, 1) = "-" then
                    current_data_second = mid(current_data_second_html, i_sym + 1, j_sym - i_sym - 1) & "/" & mid(current_data_second_html, j_sym + 1) & "/" & mid(current_data_second_html, 1, i_sym - 1)
                    exit for
                end if
            next
        end if
    next
    '----------------------------------------------------
    'Список студентов
    '----------------------------------------------------
    strSQL_studgr = "SELECT tbl_student.id_student, tbl_student.student_fio, tbl_group.group_name FROM tbl_group INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name WHERE ((tbl_group.group_name)='" & current_group & "') ORDER BY tbl_student.student_fio ASC"
    RS_studgr.Open strSQL_studgr, Conn, 3
    n_studgr = cint(RS_studgr.recordcount)
    RS_studgr.MoveFirst
    for i = 1 to n_studgr
        '----------------------------------------------------
        'Список студентов, группа, семестр и др. по которым есть 1 или 2 нб
        '----------------------------------------------------
        if current_disc = "all" then
            strSQL_disGroup = "SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_journal.student_name)=" & RS_studgr.Fields(0) & ") AND ((tbl_group.group_name)='" & current_group & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_zan.date) Between #" & current_data_first & "# AND #" & current_data_second & "#) AND ((tbl_journal.nb1)=True)) ORDER BY tbl_zan.date ASC UNION SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_journal.student_name)=" & RS_studgr.Fields(0) & ") AND ((tbl_group.group_name)='" & current_group & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_zan.date) Between #" & current_data_first & "# AND #" & current_data_second & "#) AND ((tbl_journal.nb2)=True)) ORDER BY tbl_zan.date " & current_sort_data
        else
            strSQL_disGroup = "SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal, tbl_plan.ID_plan FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_journal.student_name)=" & RS_studgr.Fields(0) & ") AND ((tbl_group.group_name)='" & current_group & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_plan.ID_plan)=" & mid(current_disc, 4) & ") AND ((tbl_zan.date) Between #" & current_data_first & "# AND #" & current_data_second & "#) AND ((tbl_journal.nb1)=True)) ORDER BY tbl_zan.date ASC UNION SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal, tbl_plan.ID_plan FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_journal.student_name)=" & RS_studgr.Fields(0) & ") AND ((tbl_group.group_name)='" & current_group & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_plan.ID_plan)=" & mid(current_disc, 4) & ") AND ((tbl_zan.date) Between #" & current_data_first & "# AND #" & current_data_second & "#) AND ((tbl_journal.nb2)=True)) ORDER BY tbl_zan.date " & current_sort_data
        end if
        RS_disGroup.Open strSQL_disGroup, Conn, 3
        n_disGroup = cint(RS_disGroup.recordcount)
        on error resume next
        RS_disGroup.MoveFirst
        for j = 1 to n_disGroup
            if request.form("id_" & RS_disGroup.Fields(12)) = "edit" then
                'response.write("<script>alert('Изменил: " & RS_disGroup.Fields(12) & " i[" & i & "]')</script>")
                current_type_nb = ""
                current_type_nb = current_type_nb & request.form("select_type_nb_" & RS_disGroup.Fields(12))
                current_comment_nb = ""
                current_comment_nb = current_comment_nb & request.form("comment_nb_" & RS_disGroup.Fields(12))
                if current_comment_nb = "" then current_comment_nb = "Null"
                if current_type_nb = "" then current_type_nb = "Null"
                strSQL_save = "UPDATE tbl_journal SET tbl_journal.nb_type = " & request.form("select_type_nb_" & RS_disGroup.Fields(12)) & ", tbl_journal.nb_comment = '" & request.form("comment_nb_" & RS_disGroup.Fields(12)) & "', tbl_journal.nb_edit_data = #" & month(now()) & "/" & day(now()) & "/" & year(now()) & "#, tbl_journal.nb_edit_autor = " & session("user") & " WHERE (((tbl_journal.id_journal)=" & RS_disGroup.Fields(12) & "));"
		        RS_save.Open strSQL_save, Conn, adOpenStatic 
                strSQL_save = "UPDATE tbl_group SET tbl_group.nb_edit_data = #" & month(now()) & "/" & day(now()) & "/" & year(now()) & "# WHERE (((tbl_group.group_name)='" & current_group & "'));"
		        RS_save.Open strSQL_save, Conn, adOpenStatic
            end if
            RS_disGroup.MoveNext
        next
        RS_disGroup.Close
        RS_studgr.MoveNext
    next
    RS_studgr.Close
    response.write("<script>$.Notify({caption: 'Сохраненно', content: 'Изменения сохраненны', type: 'success'});</script>")
elseif current_operation = "reset" then
    if Month(Date())=>9 then
        current_semestr = 1
    else
        current_semestr = 2
    end if
    current_group = ""
    current_disc = "all"
    stud_id = "all"
    current_sort_data = ""
    if current_semestr = 1 then
        if month(now()) >= 9 and month(now()) <= 12 then
            current_data_first_html = Year(now) & "-09-01" 
            current_data_second_html = Year(now) & "-12-31"
        else
            current_data_first_html = Year(now) - 1 & "-09-01"
            current_data_second_html = Year(now) - 1 & "-12-31"
        end if
    else
        if month(now()) >= 9 and month(now()) <= 12 then
            current_data_first_html = Year(now) + 1 & "-01-01"
            current_data_second_html = Year(now) + 1 & "-08-31"
        else
            current_data_first_html = Year(now) & "-01-01"
            current_data_second_html = Year(now) & "-08-31"
        end if
    end if
    output_par = false
    output = false
    current_output_nb_all = false
    response.write("<script>$.Notify({caption: 'Сброс', content: 'Все параметры были сброшены', type: 'warning'});</script>")
end if
current_operation = "none"
'------------------------------------------------------------
'СОХРАНЕНИЕ
'------------------------------------------------------------
%>
<!--Слой с загрузкой-->
<div id="loader" style="display: none; z-index: 3;">
        <div data-role="preloader" data-type="ring" data-style="blue" style="position: fixed; margin:auto; left: 50%; top: 50%; -webkit-transform: translate(-50%, -50%); -moz-transform: translate(-50%, -50%); -ms-transform: translate(-50%, -50%); -o-transform: translate(-50%, -50%); transform: translate(-50%, -50%); z-index: 1;"></div>
    <p style="text-align: center; color: white; position: fixed; margin:auto; left: 50%; top: 70%; -webkit-transform: translate(-50%, -50%); -moz-transform: translate(-50%, -50%); -ms-transform: translate(-50%, -50%); -o-transform: translate(-50%, -50%); transform: translate(-50%, -50%); z-index: 1;">Пожалуйста подождите... Идёт обработка запроса</p>
</div>
<%if output = true then%>
    <script>ShowHideLoader('show')</script>
<%end if%>
        <table class="table border" style='width:90%; margin-top: 15px;' align=center> 
            <tr>
                <td>
                    <!-- #include file="header.asp" -->
                </td>
            </tr>
            <tr>
                <td>
                    <h3 align=center>Журнал учёта пропусков занятий на <% response.write (mid(now(),1,10))%></h3><br>
                    <form name=FormParameters1 id=FormParameters1 method=POST>
                        <% if current_semestr = 1 then %>
                            <input type="hidden" id="select_semestr" name="select_semestr" value="1">
                        <% else %>
                            <input type="hidden" id="select_semestr" name="select_semestr" value="2">
                        <% end if %>
                        <center>
                        <%if current_group = "" then%>
                            <input type="hidden" id="select_group" name="select_group" value="all">
                        <%else%>
                            <input type="hidden" id="select_group" name="select_group" value="<%response.write(current_group)%>">
                        <%end if%>
                        <input type="hidden" id="select_data_first" name="select_data_first" value="<%response.write(current_data_first_html)%>">
                        <input type="hidden" id="select_data_second" name="select_data_second" value="<%response.write(current_data_second_html)%>">
                        <input type="hidden" id="select_output_nb_all" name="select_output_nb_all" value="<%if current_output_nb_all = true then response.write("on") else response.write("off")%>">
                        <input type="hidden" id="select_group_status" name="select_group_status" value="<%response.write(current_group_status)%>">
                        <center>
                        <div class="panel <%if output = true or output_par = true then response.write("collapsed")%>" data-role="panel" style="width: 650px;">
                            <div class="heading">
                                <span class="title">Семестр <%if current_semestr = 1 then response.write("(выбран 1 семестр)") else response.write("(выбран 2 семестр)")%></span>
                            </div>
                            <div class="content" style="padding: 15px 0px 15px 0px;">
                                <a href='#' onclick="changeSemestr('1'); onPOST('<%=current_group%>', 'FormParameters1'); ShowHideLoader('show');"><div class='<% if current_semestr = 1 then response.write("button_semestr_active") else response.write("button_semestr")%>' style="width: 300px;">1</div></a>
                                <a href='#' onclick="changeSemestr('2'); onPOST('<%=current_group%>', 'FormParameters1'); ShowHideLoader('show');"><div class='<% if current_semestr = 2 then response.write("button_semestr_active") else response.write("button_semestr")%>' style="width: 300px;">2</div></a>
                            </div>
                        </div>
                        <br>
                        <div class="panel <%if output = true or output_par = true then response.write("collapsed")%>" data-role="panel" style="width: 650px;">
                            <div class="heading">
                                <span class="title">Группа <%if not current_group = "" then response.write("(выбрана группа " & current_group & ")")%></span>
                            </div>
                            <div class="content" style="padding: 15px 0px 15px 0px;">
                                <%
                                '----------------------------------------------------
                                'Список групп
                                '----------------------------------------------------
                                strSQL_group = "SELECT Right$([tbl_group]![group_name],2) AS right2symbol, tbl_group.group_name, tbl_group.nb_edit_data FROM tbl_group ORDER BY Right$([tbl_group]![group_name],2), tbl_group.group_name;"
                                RS_group.Open strSQL_group, Conn, adOpenStatic
                                dim pred_group_1
                                dim pred_group_2
                                dim nb_data_edit
                                rs_group.movefirst
                                do until rs_group.EOF
                                    if not pred_group_2 = pred_group_1 then response.write("<br><br>")
                                    pred_group_1 = mid(rs_group.fields(0), 1, 1)
                                    nb_data_edit = ""
                                    nb_data_edit = nb_data_edit & rs_group.fields(2)
                                    strSQL_disGroup = "SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal, tbl_plan.ID_plan FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_group.group_name)='" & rs_group.fields(1) & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_journal.nb1)=True) AND ((tbl_journal.nb_type) Is Null)) OR (((tbl_journal.nb_type)='0')) UNION SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal, tbl_plan.ID_plan FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_group.group_name)='" & rs_group.fields(1) & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_journal.nb2)=True) AND ((tbl_journal.nb_type) Is Null)) OR (((tbl_journal.nb_type)='0'))"
                                    RS_disGroup.Open strSQL_disGroup, Conn, 3
                                    n_disGroup = cint(RS_disGroup.recordcount)
                                    %>
                                    <a href='#' onclick="onPOST('<%response.write(rs_group.fields(1))%>', 'FormParameters1'<%if n_disGroup > 0 then response.write(", 'edit'") else response.write(", 'normal'")%>); ShowHideLoader('show')"><div class='<%if n_disGroup > 0 then response.write("button_group_edit") else response.write("button_group_normal")%> <%if rs_group.fields(1) = current_group then Response.Write(" active")%>'><%response.write(rs_group.fields(1))%><br><font size=1>Последнее изменение:<br><%if nb_data_edit = "" then response.write("никогда") else response.write(nb_data_edit)%></font></div></a>
                                    <%
                                    RS_disGroup.Close
                                    rs_group.MoveNext
                                    on error resume next
                                    pred_group_2 = mid(rs_group.fields(0), 1, 1)
                                loop
                                rs_group.Close
                                %>
                            </div>
                        </div>
                        </center>
                    </form>
                    </center>
                    <br>
                    <%if output_par = true then%>
                        <form target="" name=FormParameters3 id=FormParameters3 action="" method=POST>
                                <%
                                '----------------------------------------------------
                                'Список групп
                                '----------------------------------------------------
                                strSQL_disGroup = "SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal, tbl_plan.ID_plan FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_group.group_name)='" & current_group & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_journal.nb1)=True) AND ((tbl_journal.nb_type) Is Null)) OR (((tbl_journal.nb_type)='0')) UNION SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal, tbl_plan.ID_plan FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_group.group_name)='" & current_group & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_journal.nb2)=True) AND ((tbl_journal.nb_type) Is Null)) OR (((tbl_journal.nb_type)='0'))"
                                RS_disGroup.Open strSQL_disGroup, Conn, 3
                                n_disGroup = cint(RS_disGroup.recordcount)
                                if n_disGroup > 0 then
                                    current_group_status = "edit"
                                else
                                    current_group_status = "normal"
                                end if
                                RS_disGroup.Close
                                %>
                                <%if current_group = "" then%>
                                    <input type="hidden" id="select_group" name="select_group" value="all">
                                <%else%>
                                    <input type="hidden" id="select_group" name="select_group" value="<%response.write(current_group)%>">
                                <%end if%>
                                <% if current_semestr = 1 then %>
                                    <input type="hidden" id="select_semestr" name="select_semestr" value="1">
                                <% else %>
                                    <input type="hidden" id="select_semestr" name="select_semestr" value="2">
                                <% end if %>
                                <input type="hidden" id="select_sort_data" name="select_sort_data" value="<%=current_sort_data%>">
                                <input type="hidden" id="select_group_status" name="select_group_status" value="<%response.write(current_group_status)%>">
                                <%
                                '----------------------------------------------------
                                'Список студентов
                                '----------------------------------------------------
                                strSQL_studgr = "SELECT tbl_student.id_student, tbl_student.student_fio, tbl_group.group_name FROM tbl_group INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name WHERE ((tbl_group.group_name)='" & current_group & "') ORDER BY tbl_student.student_fio ASC"
                                RS_studgr.Open strSQL_studgr, Conn, 3
                                n_studgr = cint(RS_studgr.recordcount)
                                redim stud(n_studgr, 3)
                                for i = 1 to n_studgr
                                    stud(i,1)=RS_studgr.Fields(0)'id
                                    stud(i,2)=RS_studgr.Fields(1)'ФИО студентов
                                    stud(i,3)=RS_studgr.Fields(2)'группа студента
                                    RS_studgr.MoveNext
                                next
                                RS_studgr.Close
                                '----------------------------------------------------
                                'Список дисциплин
                                '----------------------------------------------------
                                strSQL_disc = "SELECT tbl_disc.disc_name, tbl_plan.ID_plan, tbl_user.user_fio FROM tbl_user INNER JOIN (tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) ON tbl_user.id_user = tbl_plan.Prepod_name WHERE (((tbl_plan.Semestr)='"& current_semestr &"') AND ((tbl_group.group_name)='" & current_group &"')) ORDER by tbl_disc.disc_name"
                                RS_disc.Open strSQL_disc, Conn, 3
                                
                                n_disc = cint(RS_disc.recordcount)
                                redim disc(n_disc, 3)
                                for i = 1 to n_disc
                                    disc(i,1)=RS_disc.Fields(1)'id
                                    disc(i,2)=RS_disc.Fields(0)'название
                                    disc(i,3)=RS_disc.Fields(2)'преподаватель
                                    RS_disc.MoveNext
                                next
                                RS_disc.Close
                                %>
                            <center>
                            <div class="panel <%if output = true then response.write("collapsed")%>" data-role="panel" style="width: 650px;">
                                <div class="heading">
                                    <span class="title">Параметры</span>
                                </div>
                                <div class="content" style="padding: 15px 0px 15px 0px;">
                                    <table style="padding: 0; margin: 0; background-color: #e8f1f4;">
                                        <tr>
                                            <td style="padding: 0; margin: 0;"><b>Обучающийся: </b></td>
                                            <td style="padding: 0; margin: 0;">    
                                                <div class="input-control select" style="margin: 10px; width: 200px;">
                                                    <select name='select_stud' style='Font-family:Tahoma;font-size:8pt; margin: 0;'>
                                                        <OPTION value="all" <%if stud_id = "all" then response.write("selected")%> >Все учащиеся</OPTION>
                                                        <%
                                                        for i = 1 to n_studgr
                                                            if not stud_id = "all" then
                                                                if int(mid(stud_id, 4)) = stud(i,1) then
                                                                    response.write("<OPTION value=id_" & stud(i,1) & " selected>  " & stud(i,2) & "</OPTION>")
                                                                else
                                                                    response.write("<OPTION value=id_" & stud(i,1) & ">" & stud(i,2) & "</OPTION>")
                                                                end if
                                                            else
                                                                response.write("<OPTION value=id_" & stud(i,1) & ">" & stud(i,2) & "</OPTION>")
                                                            end if
                                                        next
                                                        %>
                                                    </select>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 0; margin: 0;"><b>Дисциплина: </b></td>
                                            <td style="padding: 0; margin: 0;">
                                                <div class="input-control select" style="margin: 10px; width: 200px;">
                                                    <select name='select_disc' style='Font-family:Tahoma;font-size:8pt; margin: 0;'>
                                                        <%
                                                        if current_disc = "all" then%>
                                                            <OPTION value="all" selected>Все дисциплины</OPTION>
                                                        <%
                                                        else%>
                                                            <OPTION value="all">Все дисциплины</OPTION>
                                                        <%
                                                        end if
                                                        for i = 1 to n_disc
                                                            if not current_disc = "all" then
                                                                if int(mid(current_disc, 4)) = disc(i, 1) then response.write ("<OPTION value='id_" & disc(i, 1) & "' selected>" & disc(i, 2) & " (" & disc(i, 3) & ")" & "</OPTION>") else response.write ("<OPTION value='id_" & disc(i, 1) & "'>" & disc(i, 2) & " (" & disc(i, 3) & ")" & "</OPTION>")
                                                            else
                                                                response.write ("<OPTION value='id_" & disc(i, 1) & "'>" & disc(i, 2) & " (" & disc(i, 3) & ")" & "</OPTION>")
                                                            end if
                                                        next
                                                        %>
                                                    </select>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="padding: 0; margin: 0;"><b>Дата:</b></td>
                                            <td style="padding: 0; margin: 0;">
                                                <b style="padding-left: 5px; padding-right: 5px;"> от </b>
                                                <div class="input-control select" style="margin: 0; width: 150px;">
                                                    <input type="date" id="select_data_first" name="select_data_first" value="<%=current_data_first_html%>">
                                                </div>
                                                <br><br><b style="padding-left: 5px; padding-right: 5px;"> до </b>
                                                <div class="input-control select" style="margin: 0; width: 150px;">
                                                    <input type="date" id="select_data_second" name="select_data_second" value="<%=current_data_second_html%>">
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan=2 style="padding: 0; margin: 0;" align=center>
                                                <label title="Выводить все пропуски, включая уже обработанные" class="input-control checkbox small-check">
                                                    <input id="select_output_nb_all" name="select_output_nb_all" type="checkbox" <%if current_output_nb_all = true then response.write("checked")%> onchange="FormParameters1.select_output_nb_all.value=FormParameters3.select_output_nb_all.value">
                                                    <span class="check"></span>
                                                    <span class="caption" >Выводить все</span>
                                                </label>
                                                <br>
                                                <INPUT type="button" class="button primary" value="Вывести" onclick="this.form.action=''; this.form.target=''; onPOST('<%=current_group%>', 'FormParameters3'); ShowHideLoader('show')"><br><br>
                                                <INPUT type="button" class="button info" value="Вывести отчёт" onclick="FormParameters3.select_stud.value='all'; this.form.action='nb_info_othet.asp'; this.form.target='_blank'; onPOST('<%=current_group%>', 'FormParameters3');"><br>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </div>
                            </center>
                        </form>
                        <br>
                    <%end if%>
                    <%if output = true then
                        '----------------------------------------------------
                        'Список студентов
                        '----------------------------------------------------
                        strSQL_studgr = "SELECT tbl_student.id_student, tbl_student.student_fio, tbl_group.group_name FROM tbl_group INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name WHERE ((tbl_group.group_name)='" & current_group & "') ORDER BY tbl_student.student_fio ASC"
                        RS_studgr.Open strSQL_studgr, Conn, 3
                        Erase stud
                        n_studgr = cint(RS_studgr.recordcount)
                        redim stud(n_studgr, 3)
                        for i = 1 to n_studgr
                            stud(i,1)=RS_studgr.Fields(0)'id
                            stud(i,2)=RS_studgr.Fields(1)'ФИО студентов
                            stud(i,3)=RS_studgr.Fields(2)'группа студента
                            RS_studgr.MoveNext
                        next
                        RS_studgr.Close
                        '----------------------------------------------------
                        'Список дисциплин
                        '----------------------------------------------------
                        strSQL_disc = "SELECT tbl_disc.disc_name, tbl_plan.ID_plan, tbl_user.user_fio FROM tbl_user INNER JOIN (tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) ON tbl_user.id_user = tbl_plan.Prepod_name WHERE (((tbl_plan.Semestr)='"& current_semestr &"') AND ((tbl_group.group_name)='" & current_group &"')) ORDER by tbl_disc.disc_name"
                        RS_disc.Open strSQL_disc, Conn, 3
                        Erase disc
                        n_disc = cint(RS_disc.recordcount)
                        redim disc(n_disc, 3)
                        for i = 1 to n_disc
                            disc(i,1)=RS_disc.Fields(1)'id
                            disc(i,2)=RS_disc.Fields(0)'название
                            disc(i,3)=RS_disc.Fields(2)'преподаватель
                            RS_disc.MoveNext
                        next
                        RS_disc.Close
                        %>
                        <table id="table_content" name="table_content" class="<%if current_group_status = "normal" then response.write("table_group_normal") else response.write("table_group_edit")%>" cellpadding=0 cellspacing=0 border="1" align="center">
                            <tr>
                                <th colspan=9 style="padding: 5px; font-size: 14pt;"><%=current_group%></th>
                            </tr>
                            <form name=FormParameters2 id=FormParameters2 method=POST>
                                <%if current_group = "" then%>
                                    <input type="hidden" id="select_group" name="select_group" value="all">
                                <%else%>
                                    <input type="hidden" id="select_group" name="select_group" value="<%response.write(current_group)%>">
                                <%end if%>
                                <% if current_semestr = 1 then %>
                                    <input type="hidden" id="select_semestr" name="select_semestr" value="1">
                                <% else %>
                                    <input type="hidden" id="select_semestr" name="select_semestr" value="2">
                                <% end if %>
                                <input type="hidden" id="select_sort_data" name="select_sort_data" value="<%=current_sort_data%>">
                                <input type="hidden" id="select_operation" name="select_operation" value="none">
                                <input type="hidden" id="select_group_status" name="select_group_status" value="<%response.write(current_group_status)%>">
                                <tr>
                                    <th colspan=9 style="padding: 5px; text-align: left;">
                                        <style>
                                            .table_style_invisible td{
                                                padding: 5px;
                                                color: white;
                                                }
                                            .table_style_invisible tr{
                                                padding: 5px;
                                                margin: 0;
                                                background-color: <%if current_group_status = "normal" then response.write("#60a917") else response.write("#ce352c")%>;
                                                }
                                            .table_style_invisible tr:hover{
                                                padding: 5px;
                                                margin: 0;
                                                border: 0;
                                                background-color: <%if current_group_status = "normal" then response.write("#60a917") else response.write("#ce352c")%>;
                                                }
                                        </style>
                                        <section class="table_style_invisible">
                                            <center>
                                                <table align=center>
                                                    <tr>
                                                        <td align=center>
                                                            <b>Обучающийся: </b>
                                                            <div class="input-control select" style="margin: 0; width: 125px;">
                                                                <select name='select_stud' style='Font-family:Tahoma;font-size:8pt; margin: 0;'>
                                                                    <OPTION value="all" <%if stud_id = "all" then response.write("selected")%> >Все учащиеся</OPTION>
                                                                    <%
                                                                    for i = 1 to n_studgr
                                                                        if not stud_id = "all" then
                                                                            if int(mid(stud_id, 4)) = stud(i,1) then
                                                                                response.write("<OPTION value=id_" & stud(i,1) & " selected>  " & stud(i,2) & "</OPTION>")
                                                                            else
                                                                                response.write("<OPTION value=id_" & stud(i,1) & ">" & stud(i,2) & "</OPTION>")
                                                                            end if
                                                                        else
                                                                            response.write("<OPTION value=id_" & stud(i,1) & ">" & stud(i,2) & "</OPTION>")
                                                                        end if
                                                                    next
                                                                    %>
                                                                </select>
                                                            </div>
                                                        </td>
                                                        <td align=center>
                                                            <b>Дисциплина: </b>
                                                            <div class="input-control select" style="margin: 0; width: 200px;">
                                                                <select name='select_disc' style='Font-family:Tahoma;font-size:8pt; margin: 0;'>
                                                                    <%
                                                                    if current_disc = "all" then%>
                                                                        <OPTION value="all" selected>Все дисциплины</OPTION>
                                                                    <%
                                                                    else%>
                                                                        <OPTION value="all">Все дисциплины</OPTION>
                                                                    <%
                                                                    end if
                                                                    for i = 1 to n_disc
                                                                        if not current_disc = "all" then
                                                                            if int(mid(current_disc, 4)) = disc(i, 1) then response.write ("<OPTION value='id_" & disc(i, 1) & "' selected>" & disc(i, 2) & " (" & disc(i, 3) & ")" & "</OPTION>") else response.write ("<OPTION value='id_" & disc(i, 1) & "'>" & disc(i, 2) & " (" & disc(i, 3) & ")" & "</OPTION>")
                                                                        else
                                                                            response.write ("<OPTION value='id_" & disc(i, 1) & "'>" & disc(i, 2) & " (" & disc(i, 3) & ")" & "</OPTION>")
                                                                        end if
                                                                    next
                                                                    %>
                                                                </select>
                                                            </div>
                                                        </td>
                                                        <td align=center>
                                                            <label title="Выводить все пропуски, включая уже обработанные" class="input-control checkbox small-check">
                                                                <input id="select_output_nb_all" name="select_output_nb_all" type="checkbox" <%if current_output_nb_all = true then response.write("checked")%> onchange="FormParameters1.select_output_nb_all.value=FormParameters2.select_output_nb_all.value">
                                                                <span class="check"></span>
                                                                <span class="caption" >Выводить все</span>
                                                            </label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align=center colspan=2>
                                                            <b>Дата: от </b>
                                                            <div class="input-control select" style="margin: 0; width: 150px;">
                                                                <input type="date" id="select_data_first" name="select_data_first" value="<%=current_data_first_html%>">
                                                            </div>
                                                            <b style="padding-left: 5px; padding-right: 5px;"> до </b>
                                                            <div class="input-control select" style="margin: 0; width: 150px;">
                                                                <input type="date" id="select_data_second" name="select_data_second" value="<%=current_data_second_html%>">
                                                            </div>
                                                        </td>
                                                        <td align=center>
                                                            <INPUT type="button" class="button primary" value="Вывести" onclick="onPOST('<%=current_group%>', 'FormParameters2'); ShowHideLoader('show')"><INPUT type="button" class="button warning" value="Сброс" style="margin-left: 5px;" onclick="onPOST('<%=current_group%>', 'FormParameters2', '', 'Reset'); ShowHideLoader('show')"><br>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </section>
                                        </center>
                                    </th>
                                </tr>
                                    <%
                                    '----------------------------------------------------
                                    'Список преподавателей
                                    '----------------------------------------------------	
                                    strSQL_prep = "SELECT tbl_user.id_user, tbl_user.user_fio FROM tbl_user"
                                    RS_prep.Open strSQL_prep, Conn, 3
                                    dim prep()
                                    n_prep= cint(RS_prep.recordcount)
                                    redim prep(n_prep, 2)
                                    for i = 1 to n_prep
                                        prep(i,1)=RS_prep.Fields(0)'id
                                        prep(i,2)=RS_prep.Fields(1)'ФИО преподавателя
                                        RS_prep.MoveNext
                                    next
                                    RS_prep.Close
                                    'Меняем формат даты с 2019-12-01 на 12/01/2019
                                    for i_sym = 1 to len(current_data_first_html)
                                        if mid(current_data_first_html, i_sym, 1) = "-" then
                                            for j_sym = i_sym + 1 to len(current_data_first_html)
                                                if mid(current_data_first_html, j_sym, 1) = "-" then
                                                    current_data_first = mid(current_data_first_html, i_sym + 1, j_sym - i_sym - 1) & "/" & mid(current_data_first_html, j_sym + 1) & "/" & mid(current_data_first_html, 1, i_sym - 1)
                                                    exit for
                                                end if
                                            next
                                        end if
                                    next
                                    for i_sym = 1 to len(current_data_second_html)
                                        if mid(current_data_second_html, i_sym, 1) = "-" then
                                            for j_sym = i_sym + 1 to len(current_data_second_html)
                                                if mid(current_data_second_html, j_sym, 1) = "-" then
                                                    current_data_second = mid(current_data_second_html, i_sym + 1, j_sym - i_sym - 1) & "/" & mid(current_data_second_html, j_sym + 1) & "/" & mid(current_data_second_html, 1, i_sym - 1)
                                                    exit for
                                                end if
                                            next
                                        end if
                                    next
                                    for i = 1 to n_studgr
                                        p_stud = true
                                        if not stud_id = "all" then
                                            if not stud(i, 1) = int(mid(stud_id, 4)) then p_stud = false
                                        else
                                            '----------------------------------------------------
                                            'Список студентов, группа, семестр и др. по которым есть 1 или 2 нб
                                            '----------------------------------------------------
                                            if current_disc = "all" then
                                                strSQL_disGroup = "SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_journal.student_name)=" & stud(i,1) & ") AND ((tbl_group.group_name)='" & current_group & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_zan.date) Between #" & current_data_first & "# AND #" & current_data_second & "#) AND ((tbl_journal.nb1)=True)) ORDER BY tbl_zan.date ASC UNION SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_journal.student_name)=" & stud(i,1) & ") AND ((tbl_group.group_name)='" & current_group & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_zan.date) Between #" & current_data_first & "# AND #" & current_data_second & "#) AND ((tbl_journal.nb2)=True)) ORDER BY tbl_zan.date " & current_sort_data
                                            else
                                                strSQL_disGroup = "SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal, tbl_plan.ID_plan FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_journal.student_name)=" & stud(i,1) & ") AND ((tbl_group.group_name)='" & current_group & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_plan.ID_plan)=" & mid(current_disc, 4) & ") AND ((tbl_zan.date) Between #" & current_data_first & "# AND #" & current_data_second & "#) AND ((tbl_journal.nb1)=True)) ORDER BY tbl_zan.date ASC UNION SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal, tbl_plan.ID_plan FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_journal.student_name)=" & stud(i,1) & ") AND ((tbl_group.group_name)='" & current_group & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_plan.ID_plan)=" & mid(current_disc, 4) & ") AND ((tbl_zan.date) Between #" & current_data_first & "# AND #" & current_data_second & "#) AND ((tbl_journal.nb2)=True)) ORDER BY tbl_zan.date " & current_sort_data
                                            end if
                                            RS_disGroup.Open strSQL_disGroup, Conn, 3
                                            n_disGroup = cint(RS_disGroup.recordcount)
                                            if n_disGroup = 0 then p_stud = false
                                            RS_disGroup.Close
                                        end if
                                        '----------------------------------------------------
                                        'Список студентов, группа, семестр и др. по которым есть 1 или 2 нб
                                        '----------------------------------------------------
                                        if current_disc = "all" then
                                            strSQL_disGroup = "SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_journal.student_name)=" & stud(i,1) & ") AND ((tbl_group.group_name)='" & current_group & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_zan.date) Between #" & current_data_first & "# AND #" & current_data_second & "#) AND ((tbl_journal.nb1)=True)) ORDER BY tbl_zan.date ASC UNION SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_journal.student_name)=" & stud(i,1) & ") AND ((tbl_group.group_name)='" & current_group & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_zan.date) Between #" & current_data_first & "# AND #" & current_data_second & "#) AND ((tbl_journal.nb2)=True)) ORDER BY tbl_zan.date " & current_sort_data
                                        else
                                            strSQL_disGroup = "SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal, tbl_plan.ID_plan FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_journal.student_name)=" & stud(i,1) & ") AND ((tbl_group.group_name)='" & current_group & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_plan.ID_plan)=" & mid(current_disc, 4) & ") AND ((tbl_zan.date) Between #" & current_data_first & "# AND #" & current_data_second & "#) AND ((tbl_journal.nb1)=True)) ORDER BY tbl_zan.date ASC UNION SELECT tbl_journal.student_name, tbl_disc.disc_name, tbl_group.group_name, tbl_plan.Semestr, tbl_plan.Prepod_name, tbl_zan.date, tbl_journal.nb1, tbl_journal.nb2, tbl_journal.nb_type, tbl_journal.nb_comment, tbl_journal.nb_edit_data, tbl_journal.nb_edit_autor, tbl_journal.id_journal, tbl_plan.ID_plan FROM ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON tbl_zan.id_zan = tbl_journal.zan WHERE (((tbl_journal.student_name)=" & stud(i,1) & ") AND ((tbl_group.group_name)='" & current_group & "') AND ((tbl_plan.Semestr)='" & current_semestr & "') AND ((tbl_plan.ID_plan)=" & mid(current_disc, 4) & ") AND ((tbl_zan.date) Between #" & current_data_first & "# AND #" & current_data_second & "#) AND ((tbl_journal.nb2)=True)) ORDER BY tbl_zan.date " & current_sort_data
                                        end if
                                        'Проверка на обработанные записи
                                        if current_output_nb_all = false and p_stud = true then
                                            RS_disGroup.Open strSQL_disGroup, Conn, 3
                                            p_stud = false
                                            n_disGroup = cint(RS_disGroup.recordcount)
                                            RS_disGroup.MoveFirst
                                            for j = 1 to n_disGroup
                                                type_nb = ""
                                                type_nb = type_nb & RS_disGroup.fields(8)
                                                if type_nb = "" or type_nb = "0" then
                                                    p_stud = true
                                                    exit for
                                                end if
                                                RS_disGroup.MoveNext
                                            next
                                            RS_disGroup.Close
                                            if p_stud = false and not stud_id = "all" then
                                                if not n_disGroup = 0 then
                                                    Response.Write ("<tr><th colspan=9 style='padding: 5px; font-size: 14pt; text-align: left;'>" & stud(i,2) & "</th></tr><tr><td colspan=9>У учащегося все пропуски обработанны</td></tr>")
                                                else
                                                    Response.Write ("<tr><th colspan=9 style='padding: 5px; font-size: 14pt; text-align: left;'>" & stud(i,2) & "</th></tr><tr><td colspan=9>У учащегося нет пропусков</td></tr>")
                                                end if
                                            end if
                                        end if
                                        if p_stud = true then
                                            k_stud = k_stud + 1
                                            RS_disGroup.Open strSQL_disGroup, Conn, 3
                                            n_disGroup = cint(RS_disGroup.recordcount)
                                            Erase disGroup
                                            redim disGroup(n_disGroup, 12)
                                            RS_disGroup.MoveFirst
                                            for j = 1 to n_disGroup
                                                disGroup(j,0)=RS_disGroup.Fields(12)'id записи в журнале
                                                disGroup(j,1)=RS_disGroup.Fields(0)'id студента
                                                disGroup(j,2)=RS_disGroup.Fields(1)'дисциплина
                                                disGroup(j,3)=RS_disGroup.Fields(2)'группа
                                                disGroup(j,4)=RS_disGroup.Fields(3)'семестр		
                                                disGroup(j,5)=RS_disGroup.Fields(4)'преподаватель
                                                disGroup(j,6)=RS_disGroup.Fields(5)'дата занятия		
                                                disGroup(j,7)=RS_disGroup.Fields(6)'1нб
                                                disGroup(j,8)=RS_disGroup.Fields(7)'2нб
                                                disGroup(j,9)=RS_disGroup.Fields(8)'нб тип
                                                disGroup(j,10)=RS_disGroup.Fields(9)'нб коментарий
                                                disGroup(j,11)=RS_disGroup.Fields(10)'дата редак. нб
                                                disGroup(j,12)=RS_disGroup.Fields(11)'автор редак. нб	
                                                RS_disGroup.MoveNext
                                            next
                                            RS_disGroup.Close
                                            %>
                                            <tr>
                                                <th colspan=8 style="padding: 5px; font-size: 14pt; text-align: left;"><%=stud(i,2)%></th>
                                                <!--ДЛЯ ВЫСТАВЛЕНИЯ ПРИЧИН В РАЗРЕЗЕ ДАТ
                                                <th colspan=8 style="padding: 0">
                                                    <table name="stud_header_<%response.write(stud(i, 1))%>" id="stud_header_<%response.write(stud(i, 1))%>" style="width: 1000px; margin: 0;">
                                                        <tr>
                                                            <th style="padding: 5px; font-size: 14pt; text-align: left;"><%=stud(i,2)%></th>
                                                            <th style="padding: 5px; text-align: right;">
                                                                <b style="padding-right: 5px;">Дата: от </b>
                                                                <div class="input-control select" style="margin: 8px 0px 0px 0px; width: 150px; height: 30px;">
                                                                    <input type="date" id="select_data_first_stud_<%=response.write(stud(i,1))%>" name="select_data_first_stud_<%=response.write(stud(i,1))%>" value="<%=current_data_first_html%>" style="height: 30px;">
                                                                </div>
                                                                <b style="padding-left: 5px; padding-right: 5px;"> до </b>
                                                                <div class="input-control select" style="margin: 8px 0px 0px 0px; width: 150px; height: 30px;">
                                                                    <input type="date" id="select_data_second_stud_<%=response.write(stud(i,1))%>" name="select_data_second_stud_<%=response.write(stud(i,1))%>" value="<%=current_data_second_html%>" style="height: 30px;">
                                                                </div>
                                                                <b style="padding-left: 10px; padding-right: 8px;">Причина: </b>
                                                                <div class="input-control select" style="margin: 8px 0px 0px 0px; width: 125px; height: 30px;">
                                                                    <select name="select_type_nb_stud_<%=response.write(stud(i,1))%>" id="select_type_nb_stud_<%=response.write(stud(i,1))%>" style="Font-family:Tahoma;font-size:8pt; margin: 0; height: 30px;">
                                                                        <optgroup label="Уважительные">
                                                                            <option value=1 >Больничный</option>
                                                                            <option value=2 >Дежурство</option>
                                                                            <option value=3 >Освобождение (заявление)</option>
                                                                            <option value=4 >Другое (уважительная)</option>
                                                                        </optgroup>
                                                                        <optgroup label="Не уважительные">
                                                                            <option value=5 selected>Прогул</option>
                                                                            <option value=6 >Удалён с занятия</option>
                                                                            <option value=7 >Другое (не уважительная)</option>
                                                                        </optgroup>
                                                                        <optgroup label="По умолчанию">
                                                                            <option value=0 >Не указана</option>
                                                                        </optgroup>
                                                                    </select>
                                                                </div>
                                                                <INPUT type="button" class="button primary" style="margin: 0px 5px 0px 5px; height: 30px; font-size: 10pt;" value="Применить" onclick="ChangeSelectTypeNb('<%response.write(stud(i, 1))%>')">
                                                            </th>
                                                        </tr>
                                                    </table>
                                                </th>-->
                                                </th>
                                            </tr>
                                            <%
                                            if not n_disGroup = 0 then%>
                                                <tr>
                                                    <th nowrap style="padding: 5px">№</th>
                                                    <th style="padding: 5px">Дисциплина</th>
                                                    <th nowrap style="padding: 5px; width: 120px;"><a title="Нажмите что бы сменить сортировку" href="#" onclick="changeSortData('<%=current_sort_data%>'); onPOST('<%=current_group%>', 'FormParameters2'); ShowHideLoader('show')">Дата занятия <img  src=<% if current_sort_data = "ASC" then response.write("images/sort_ASC.png") else response.write("images/sort_DESC.png")%>></a></th>
                                                    <th style="padding: 5px">Кол-во нб</th>
                                                    <th style="padding: 5px">Причина</th>
                                                    <th style="padding: 5px">Описание</th>
                                                    <th style="padding: 5px">Автор</th>
                                                    <th style="padding: 5px">Дата обработки</th>
                                                </tr>
                                                <%
                                                i_nb = 0
                                                for j2 = 1 to n_disGroup
                                                    p_disc = true
                                                    type_nb = ""
                                                    type_nb = type_nb & disGroup(j2,9)
                                                    if current_output_nb_all = false then if not type_nb = "" and not type_nb = "0" then p_disc = false
                                                    comment_nb = ""
                                                    comment_nb = comment_nb & disGroup(j2,10)
                                                    autor_nb = ""
                                                    autor_nb = autor_nb & disGroup(j2,11)
                                                    data_nb = ""
                                                    data_nb = data_nb & disGroup(j2,12)
                                                    if p_disc = true then
                                                    i_nb = i_nb + 1
                                                    %>
                                                        <tr>
                                                            <input type="hidden" name="id_<%response.write(disGroup(j2,0))%>" id="id_<%response.write(disGroup(j2,0))%>" value="none">
                                                            <input type="hidden" name="id_stud_<%response.write(stud(i, 1))%>" id="id_stud_<%response.write(stud(i, 1))%>" value="select_type_nb_<%response.write(disGroup(j2,0))%>">
                                                            <input type="hidden" name="data_id_stud_<%response.write(stud(i, 1))%>" id="data_id_stud_<%response.write(stud(i, 1))%>" value="<%response.write(disGroup(j2,6))%>">
                                                            <!--№-->
                                                            <td nowrap style="padding: 5px; border-left-style: hidden;" align=center><%response.write(i_nb) 'response.write(j2)%></td>
                                                            <!--Дисциплина-->
                                                            <td style="padding: 5px">
                                                                <%for x = 1 to n_prep
                                                                    if disGroup(j2,5) = prep(x,1) then  response.write(disGroup(j2,2) &" (" & prep(x,2) &")")
                                                                next%>
                                                            </td>
                                                            <!--Дата занятия-->
                                                            <td style="padding: 5px" align=center><%response.write(disGroup(j2,6))%></td>
                                                            <!--Кол-во нб-->
                                                            <td style="padding: 5px" align=center><%if disGroup(j2,7) = True then response.write("1нб") else if disGroup(j2,8) = True then response.write("2нб") else response.write("")%></td>
                                                            <!--Причина-->
                                                            <td style="padding: 5px" align=center>
                                                                <div class="input-control select" style="margin: 0; width: 125px;">
                                                                    <select name="select_type_nb_<%response.write(disGroup(j2,0))%>" style="Font-family:Tahoma;font-size:8pt; margin: 0;" onchange="FormParameters2.id_<%response.write(disGroup(j2,0))%>.value='edit'">
                                                                        <optgroup label="Уважительные">
                                                                            <option value=1 <%if disGroup(j2,9) = 1 then response.write("selected")%> >Больничный</option>
                                                                            <option value=2 <%if disGroup(j2,9) = 2 then response.write("selected")%> >Дежурство</option>
                                                                            <option value=3 <%if disGroup(j2,9) = 3 then response.write("selected")%> >Освобождение (заявление)</option>
                                                                            <option value=4 <%if disGroup(j2,9) = 4 then response.write("selected")%> >Другое (уважительная)</option>
                                                                        </optgroup>
                                                                        <optgroup label="Не уважительные">
                                                                            <option value=5 <%if disGroup(j2,9) = 5 then response.write("selected")%> >Прогул</option>
                                                                            <option value=6 <%if disGroup(j2,9) = 6 then response.write("selected")%> >Удалён с занятия</option>
                                                                            <option value=7 <%if disGroup(j2,9) = 7 then response.write("selected")%> >Другое (не уважительная)</option>
                                                                        </optgroup>
                                                                        <optgroup label="По умолчанию">
                                                                            <option value=0 <%if type_nb = "" or disGroup(j2,9) = 0 then response.write("selected")%> >Не указана</option>
                                                                        </optgroup>
                                                                    </select>
                                                                </div>
                                                            </td>
                                                            <!--Описание-->
                                                            <td style="padding: 5px" align=center>
                                                                <%if comment_nb = "" or comment_nb = "-" then%>
                                                                    <input type=text class="text_description" name="<%response.write("comment_nb_" & disGroup(j2,0))%>" id="<%response.write("comment_nb_" & disGroup(j2,0))%>" value="-" title="Нет описания" onchange="this.title='Описание было изменено. Для просмотра сохраните изменения.'; FormParameters2.id_<%response.write(disGroup(j2,0))%>.value='edit'" onclick="this.select(); gowidth('<%response.write("comment_nb_" & disGroup(j2,0))%>');" onblur="backwidth('<%response.write("comment_nb_" & disGroup(j2,0))%>');">
                                                                <%else%>
                                                                    <input type=text class="text_description" name="<%response.write("comment_nb_" & disGroup(j2,0))%>" id="<%response.write("comment_nb_" & disGroup(j2,0))%>" value="<%response.write(disGroup(j2,10))%>" title="<%response.write(disGroup(j2,10))%>" onchange="this.title='Описание было изменено. Для просмотра сохраните изменения.'; FormParameters2.id_<%response.write(disGroup(j2,0))%>.value='edit'" onclick="this.select(); gowidth('<%response.write("comment_nb_" & disGroup(j2,0))%>');" onblur="backwidth('<%response.write("comment_nb_" & disGroup(j2,0))%>');">
                                                                <%end if%>
                                                            </td>
                                                            <!--Автор-->
                                                            <td style="padding: 5px" align=center>
                                                                <%if autor_nb = "" then
                                                                    response.write("-")
                                                                else
                                                                    for x = 1 to n_prep
                                                                        if disGroup(j2,12) = prep(x,1) then response.write(prep(x,2))
                                                                    next
                                                                end if%>
                                                            </td>
                                                            <!--Дата-->
                                                            <td style="padding: 5px; border-right-style: hidden;" align=center><%if data_nb = "" then response.write("-") else response.write(disGroup(j2,11))%></td>
                                                        </tr>
                                                    <% 
                                                    end if
                                                next
                                            else
                                                if not stud_id = "all" then Response.Write ("<tr><td colspan=9>У учащегося нет пропусков</td></tr>")
                                            end if
                                        end if
                                    next
                                    if k_stud = 0 and stud_id = "all" then
                                        if current_output_nb_all = true then
                                            Response.Write ("<tr><td colspan=9>У учащихся нет пропусков</td></tr>")
                                        else
                                            Response.Write ("<tr><td colspan=9>У учащихся все пропуски обработанны</td></tr>")
                                        end if
                                    end if
                                    'ДЛЯ ПОДГОНКИ ТАБЛИЦ К ОБЩЕЙ
                                    'for i = 1 to n_studgr
                                    '    response.write("<script>changeWidth('stud_header_" & stud(i, 1) & "')</script>")
                                    'next
                                    Conn.Close
                                    Set RS_group = Nothing
                                    Set Conn = Nothing
                                    %>
                            </form>
                        </table>
                        <br>
                    <%end if%>				
                    <center>
                    <a href="group_change.asp?go=1" class="button subinfo">Вернуться к выбору группы</a><br>
					<a href="help/02_11.asp" ><button class="button success"><span class="icon mif-info"></span> Помощь </button></a>
					<a href="exit.asp"><button class="button danger " ><span class="icon mif-exit"></span> Выход</button></a>
                    </center>
                </td>
            </tr>
        </table>
        <br>
        <%if output = true and not k_stud = 0 then%>
        <a href="#" onclick="onPOST('<%=current_group%>', 'FormParameters2', '', 'Save'); ShowHideLoader('show')" class="button_save" title="Нажмите что бы сохранить изменения">
            <span class="mif-floppy-disk mif-2x"></span>
            <p>Сохранить</p>
        </a>
        <%end if%>
        <!--Скрипт для расширения text-->
        <script>
            function gowidth(id){	
                document.getElementById(id).style.width = "200px";
            }
            function backwidth(id){	
                document.getElementById(id).style.width = "50px";
            }
        </script>
        <!--Отключение загрузки-->
        <script>ShowHideLoader('hide')</script>
	    <!-- Скрипт для отключения перетаскивания всех изображений -->
		<script>
			$("img").mousedown(function(){
			return false;
			});
		</script>
	</body>
</html>
