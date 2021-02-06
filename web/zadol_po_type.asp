<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01//EN" "http://www.w3.org/TR/html4/strict.dtd">

<%
'if session("user") = "" or session("user") = "Студент" or session("user") = 0 then response.Redirect ("404.asp")
Response.Expires=-1
'---------------------------------------------------
'Защита от SQL-инъекции
'---------------------------------------------------
all= request.QueryString
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
	if mid(all,i,1)=";" then response.Redirect ("index.asp?err=1")
next
%>
<%
'--------------------------------
'Для перехода по страницам журанала
'--------------------------------
'go=request.querystring("go")
'if go <> 1 then
'output_str = 0
'else
'output_str = request.QueryString ("str")
'end if
%>
<%
'------------------------------------------------------
'Подключение БД
'------------------------------------------------------
Set Conn = Server.CreateObject("ADODB.Connection") 
Set RS_0_0 = Server.CreateObject("ADODB.Recordset")
Set RS_0_1 = Server.CreateObject("ADODB.Recordset")
Set RS_0_2 = Server.CreateObject("ADODB.Recordset")
Set rs_stud = Server.CreateObject("ADODB.Recordset")
strDBPath = Server.MapPath("base.mdb")
Conn.Open "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & _
strDBPath
'------------------------------------------------------
strSQL_0_0= "SELECT tbl_disc.disc_name, tbl_plan.ID_plan, tbl_user.user_fio FROM tbl_user INNER JOIN (tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) ON tbl_user.id_user = tbl_plan.Prepod_name WHERE (((tbl_plan.Semestr)='"& session ("sem") &"') AND ((tbl_group.group_name)='" & session ("gr") &"')) ORDER by tbl_disc.disc_name"
strSQL_0_2="SELECT tbl_group.group_name, tbl_user.user_fio FROM tbl_user INNER JOIN tbl_group ON tbl_user.id_user = tbl_group.group_ruk WHERE (((tbl_group.group_name)='" & session ("gr") &"'))"

strSQL_0_1 = "SELECT student_fio, tbl_student.id_student, tbl_student.student_number FROM tbl_group INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name WHERE ((tbl_group.group_name)='" & session("gr") &"') ORDER BY student_fio"

RS_0_0.Open strSQL_0_0, Conn, adOpenStatic
RS_0_1.Open strSQL_0_1, Conn, adOpenStatic
RS_0_2.Open strSQL_0_2, Conn, adOpenStatic

dim output 'Переменная для разрешения вывода ведомости
output = true

dim obyaz 'Переменная для фильтра по обязательнам работам
if request.form("cb_obyaz") = "on" then obyaz = true else obyaz = false

dim disc_value 'Название текущей дисциплины
disc_value = request.form("disc_selected")

if disc_value = "" then disc_value = request.querystring("disc")
if disc_value = "" then
	output = false
	obyaz = true
	disc_value = "all"
end if

dim stud_id 'id текущего студента
stud_id = request.form("student_id")
if stud_id = "" then
	output = false
	obyaz = true
	stud_id = "all"
end if

dim zan_type_name
dim zan_type 'Номер выбранного типа работы
zan_type_name = ""
zan_type = request.form("zan_type")
if zan_type = "" then output = false: zan_type = "2"

dim form_select
form_select = request.form("form_selected")
if form_select = "" then
	output = false
	obyaz = true
	form_select = "form_1"
end if

'Объявление используемых массивов и переменных неоднократно
dim dat()
dim disc()
dim student()
dim sob()
dim kdolg_stud 'Количество студентов с долгами
dim kdolg 'Количество долгов студента
dim kdolg_disc 'Количество дисциплин с долгами
dim pdolg 'Переменная для проверки на долг
dim p
dim a 
dim b 
dim c
kdolg_disc = 0

Set RS1 = Server.CreateObject("ADODB.Recordset")
Set RS2 = Server.CreateObject("ADODB.Recordset") 
Set RS3 = Server.CreateObject("ADODB.Recordset") 
Set RS4 = Server.CreateObject("ADODB.Recordset") 
Set RS5 = Server.CreateObject("ADODB.Recordset")
Set RS6 = Server.CreateObject("ADODB.Recordset") 
Set RS7 = Server.CreateObject("ADODB.RecordSet")
Set RS_prep = Server.CreateObject("ADODB.RecordSet")
'рекордсет с фамилиями студентов выбранной группы, отсортированный по алфавиту
strSQL1 = "SELECT tbl_student.student_fio, tbl_student.id_student FROM tbl_group INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name WHERE ((tbl_group.group_name)='" & session("gr") &"') ORDER BY tbl_student.student_fio"
sql_stud_sp = "SELECT student_fio, tbl_student.id_student, tbl_student.student_number FROM tbl_group INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name WHERE ((tbl_group.group_name)='" & session("gr") &"') ORDER BY student_fio"
'------------------------------
'Массив student, создание и заполнение id_stud и фамилия
'------------------------------
rs1.Open strsql1, conn,3
n_stud = cint(rs1.recordcount)
redim student(n_stud,4)
for i=1 to n_stud
	student(i, 1) = rs1.Fields (1) 'id_stud
	student(i, 2) = rs1.Fields (0) 'Фамилия студента
	rs1.MoveNext
next
rs1.Close
rs_stud.Open sql_stud_sp, Conn, adOpenStatic
%>

<html>
	<head>
		<meta content="text/html; charset=Windows-1251" http-equiv="content-type">
		<link rel="shortcut icon" href="images/favicon.ico" /> 
		<link rel="stylesheet" href="css/button.css">	
		<link rel="stylesheet" href="css/metro.css">
		<link rel="stylesheet" href="css/metro-colors.css">
		<link rel="stylesheet" href="css/metro-icons.css">
		<link rel="stylesheet" href="css/metro-responsive.css">
		<link rel="stylesheet" href="css/metro-rtl.css">
		<link rel="stylesheet" href="css/metro-schemes.css">
		<link rel="stylesheet" href="css/table_style.css">
		<script src="js/jquery-3.1.0.min.js"></script>
		<script src="js/metro.min.js"></script>
		<title>ИС "Электронный журнал". Задолженности по типам работ группы <% response.Write(session ("gr"))%></title>
		<style>
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
		</style>
		<%if output = true then%>
		<script>
			function onkeydown() {
            if (event.keyCode == 116) {
                showLoader();
                }
            if (event.keyCode == 27) {
                hideLoader();
                }
            }
			window.onbeforeunload = function(e) {
				showLoader();
			};
			function onLoad()
				{
					document.onkeydown=onkeydown;
				}
		</script>
		<%end if%>
	</head>
	<body <%if output = true then response.write("onload='javascript:onLoad();'")%>>
	<div id="loader" style="display: none">
		<div data-role="preloader" data-type="ring" data-style="blue" style="position: fixed; margin:auto; left: 50%; top: 50%; -webkit-transform: translate(-50%, -50%); -moz-transform: translate(-50%, -50%); -ms-transform: translate(-50%, -50%); -o-transform: translate(-50%, -50%); transform: translate(-50%, -50%); z-index: 1;"></div>
		<p style="text-align: center; color: white; position: fixed; margin:auto; left: 50%; top: 70%; -webkit-transform: translate(-50%, -50%); -moz-transform: translate(-50%, -50%); -ms-transform: translate(-50%, -50%); -o-transform: translate(-50%, -50%); transform: translate(-50%, -50%); z-index: 1;">Пожалуйста подождите... Идёт обработка запроса</p>
	</div>
	<!--Слой с загрузкой-->
	<script>
		function showLoader(){
			document.getElementById("loader").style.display = "block";
		}
		function hideLoader(){
			document.getElementById("loader").style.display = "none";
		}
	</script>
	<table style='width:90%; margin-top: 15px; margin-bottom: 15px; padding: 5px; border-width: 1px; border-style: solid; border-color: grey;' align=center> 
		<tr>
			<td>
				<!-- #include file="header.asp" -->
			</td>
		</tr>
		<tr>
			<td>
				<center>
					<h3>Задолженности по типам работ для группы <%response.Write(session ("gr"))%></h3><br>

						<% iswork = false 'Статус веб-страницы 
						
						if iswork=true then %>
							<p style="background-color: red; color: white; padding: 5px 0px 5px 0px"><b>Внимание! Проводятся работы.</b></p>
						<% end if %>
	
					<form method="post">
						<table col=3 align=center>
							<tr>
								<td width=380>
									<!--Обучающийся:-->
									<b><font size=2>Обучающийся: </font></b>
									<div class="input-control select" style='width: 340px'>
										<SELECT name="student_id" style='Font-family:Tahoma;font-size:8pt;Width:340px'>
											<%
											if stud_id = "all" then%>
												<OPTION value="all" selected>Все учащиеся</OPTION>
											<%
											else%>
												<OPTION value="all">Все учащиеся</OPTION>
											<%
											end if%>
											<%
											rs_stud.movefirst
											do until rs_stud.EOF
												rs_stud_id = "id_" & rs_stud.fields(1)
												if stud_id = rs_stud_id then response.write("<OPTION value=id_" & rs_stud.fields(1) & " selected>  " & rs_stud.fields(0) & "</OPTION>") else response.write("<OPTION value=id_" & rs_stud.fields(1) & ">" & rs_stud.fields(0) & "</OPTION>")
												rs_stud.MoveNext
											loop
											%>
										</SELECT>
									</div>
								</td>
								<td width=350>
									<!--Вид работы-->
									<b><font size=2>Вид работы: </font></b>
									<div class="input-control select" style='width: 340px'>
										<select name='zan_type' style='Font-family:Tahoma;font-size:8pt;Width:340px'>
											<%
											select case zan_type
												case "1"
													zan_type_name = "Теоретическая работа"
													%><option value='0'>Все работы<%
													%><option value='1' selected>Теоретическая работа<%
													%><option value='2'>Практическая работа<%
													%><option value='3'>Тест<%
													%><option value='4'>Лабораторная работа<%
													%><option value='5'>Самостоятельная работа<%
												case "2"
													zan_type_name = "Практическая работа"
													%><option value='0'>Все работы<%
													%><!--  <option value='1'>Теоретическая работа  --><%
													%><option value='2' selected>Практическая работа<%
													%><option value='3'>Тест<%
													%><option value='4'>Лабораторная работа<%
													%><option value='5'>Самостоятельная работа<%
												case "3"
													zan_type_name = "Тест"
													%><option value='0'>Все работы<%
													%><!--  <option value='1'>Теоретическая работа  --><%
													%><option value='2'>Практическая работа<%
													%><option value='3' selected>Тест<%
													%><option value='4'>Лабораторная работа<%
													%><option value='5'>Самостоятельная работа<%
												case "4"
													zan_type_name = "Лабораторная работа"
													%><option value='0'>Все работы<%
													%><!--  <option value='1'>Теоретическая работа  --><%
													%><option value='2'>Практическая работа<%
													%><option value='3'>Тест<%
													%><option value='4' selected>Лабораторная работа<%
													%><option value='5'>Самостоятельная работа<%
												case "5"
													zan_type_name = "Самостоятельная работа"
													%><option value='0'>Все работы<%
													%><!--  <option value='1'>Теоретическая работа  --><%
													%><option value='2'>Практическая работа<%
													%><option value='3'>Тест<%
													%><option value='4'>Лабораторная работа<%
													%><option value='5' selected>Самостоятельная работа<%
												case else
													zan_type_name = "Все работы"
													zan_type = "0"
													%><option value='0'  selected>Все работы<%
													%><!--  <option value='1'>Теоретическая работа  --><%
													%><option value='2'>Практическая работа<%
													%><option value='3'>Тест<%
													%><option value='4'>Лабораторная работа<%
													%><option value='5'>Самостоятельная работа<%
											end select
											%>
										</select>
									</div>
								</td>
								<td width=200>
									<!--Обязательные работы-->
									<label class='input-control checkbox small-check' style='margin-left: 25px; line-height: 0px; height: 17px; min-height:0px;'>
										<%if obyaz = false then%>
											<input type='checkbox' name='cb_obyaz'>
										<%else%>
											<input type='checkbox' name='cb_obyaz' checked>
										<%end if%>
										<span class='check' style='line-height: 0px;'>
										</span>  <font size=2>Обязательные работы</font>
									</label>
								</td>
							</tr>
							<tr>
								<td width=380>
									<!--Дисциплина:-->
									<b><font size=2>Дисциплина: </font></b>
									<div class="input-control select" style='width: 340px;'>
										<SELECT name="disc_selected" style='Font-family:Tahoma;font-size:8pt;Width:340px'>
											<%
											if disc_value = "all" then%>
												<OPTION value="all" selected>Все дисциплины</OPTION>
											<%
											else%>
												<OPTION value="all">Все дисциплины</OPTION>
											<%
											end if
											do until rs_0_0.EOF
												if disc_value = rs_0_0.fields(0) then response.write ("<OPTION value='" & rs_0_0.fields(0) & "' selected>" & rs_0_0.fields(0) & " (" & rs_0_0.Fields(2) & ")" & "</OPTION>") else response.write ("<OPTION value='" & rs_0_0.fields(0) & "'>" & rs_0_0.fields(0) & " (" & rs_0_0.Fields(2) & ")" & "</OPTION>")
												rs_0_0.MoveNext
											loop
											%>
										</SELECT>
									</div>
								</td>
								<td width=350>
									<!--Форма отчёта-->
									<b><font size=2>Форма отчёта: </font></b>
									<div class="input-control select" style='width: 340px;'>
										<SELECT name="form_selected" style='Font-family:Tahoma;font-size:8pt;Width:340px'>
											<%if form_select = "form_1" then%>
												<OPTION value="form_1" selected>Вертикальный</OPTION>
												<OPTION value="form_2">Горизонтальный</OPTION>
											<%else%>
												<OPTION value="form_1">Вертикальный</OPTION>
												<OPTION value="form_2" selected>Горизонтальный</OPTION>
											<%end if%>
										</SELECT>
									</div>
								</td>
								<td width=200>
									<INPUT type="submit" class="button primary" value="Вывести" name="Submit1" onclick="showLoader()" style="margin-left: 25px;"><br>
								</td>
							</tr>
						</table>
					</form>
<%
if output = true then
	'Если одна дисциплина
	if not disc_value = "all" then
		if not zan_type = "0" then strSQL2 = "SELECT tbl_zan.Date, tbl_zan.id_zan, tbl_zan.kontr, tbl_zan.prim_student, tbl_user.user_fio, tbl_zan.prim_student, tbl_zan.zan_type, tbl_disc.disc_name, tbl_plan.Semestr, tbl_group.group_name FROM tbl_user INNER JOIN ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group =tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) ON tbl_user.id_user = tbl_plan.Prepod_name WHERE (((tbl_zan.zan_type)=" & zan_type & ") AND ((tbl_disc.disc_name)='" & disc_value & "') AND ((tbl_plan.Semestr)='" & session("sem") & "') AND ((tbl_group.group_name)='" & session("gr") & "')) ORDER BY tbl_zan.date, tbl_zan.id_zan;" else strSQL2 = "SELECT tbl_zan.Date, tbl_zan.id_zan, tbl_zan.kontr, tbl_zan.prim_student, tbl_user.user_fio, tbl_zan.prim_student, tbl_zan.zan_type, tbl_disc.disc_name, tbl_plan.Semestr, tbl_group.group_name FROM tbl_user INNER JOIN ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group =tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) ON tbl_user.id_user = tbl_plan.Prepod_name WHERE (((tbl_disc.disc_name)='" & disc_value & "') AND ((tbl_plan.Semestr)='" & session("sem") & "') AND ((tbl_group.group_name)='" & session("gr") & "')) ORDER BY tbl_zan.date, tbl_zan.id_zan;"
		strSQL3 = "SELECT tbl_group.group_name, tbl_plan.Semestr, tbl_disc.disc_name, tbl_student.id_student, tbl_journal.sobytie, tbl_zan.id_zan, tbl_plan.ID_plan, tbl_user.user_fio, tbl_journal.edit, tbl_journal.edit_date, tbl_journal.id_journal, tbl_journal.comment, tbl_journal.sobytie_old, tbl_journal.nb1, tbl_journal.nb2 FROM tbl_user INNER JOIN ((((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON (tbl_zan.id_zan = tbl_journal.zan) AND (tbl_student.id_student = tbl_journal.student_name)) ON tbl_user.id_user = tbl_journal.Author WHERE (((tbl_group.group_name)='" & session("gr") &"') AND ((tbl_plan.Semestr)='" & session("sem") &"') AND ((tbl_disc.disc_name)='" & disc_value &"'));"
		'Рекордсет для записи id дисциплины в скрытое поле
		strSQL4 = "SELECT tbl_plan.Semestr, tbl_plan.ID_plan, tbl_disc.disc_name, tbl_group.group_name FROM tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc=tbl_plan.disc_name) ON tbl_group.id_group=tbl_plan.gr_name WHERE (((tbl_plan.Semestr)='" & session("sem") & "') AND ((tbl_disc.disc_name)='" & disc_value & "') AND ((tbl_group.group_name)='" & session("gr") & "'))"
		'Рекордсет подсчета пропущенных часов
		strSQL5 = "SELECT tbl_student.student_fio, Count(tbl_journal.sobytie)*2 AS [Count-sobytie] FROM (((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON (tbl_zan.id_zan = tbl_journal.zan) AND (tbl_student.id_student = tbl_journal.student_name) WHERE (((tbl_group.group_name)='"&session("gr")&"') AND ((tbl_disc.disc_name)='"&disc_value&"') AND ((tbl_plan.Semestr)='"&session("sem")&"') AND ((tbl_journal.sobytie)=6)) GROUP BY tbl_student.student_fio"
		'Рекордсет подсчета средней оценки
		strSQL6 = "SELECT tbl_student.student_fio, Avg(tbl_journal.sobytie) AS [Count-sobytie] FROM (((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON (tbl_zan.id_zan = tbl_journal.zan) AND (tbl_student.id_student = tbl_journal.student_name) WHERE (((tbl_group.group_name)='"&session("gr")&"') AND ((tbl_disc.disc_name)='"&disc_value&"') AND ((tbl_plan.Semestr)='"&session("sem")&"') AND ((tbl_journal.sobytie)<6)) GROUP BY tbl_student.student_fio"
		strSQL7 = "SELECT tbl_disc.disc_name, Count(tbl_zan.date) AS [Count-date], tbl_plan.Semestr, tbl_group.group_name FROM tbl_group INNER JOIN ((tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name WHERE (((tbl_disc.disc_name)='" & disc_value & "') AND ((tbl_plan.Semestr)='" & session("sem") & "') AND ((tbl_group.group_name)='" & session("gr") & "')) GROUP BY tbl_disc.disc_name, tbl_plan.Semestr, tbl_group.group_name" 
		strSQL_prep = "SELECT tbl_user.user_fio FROM tbl_user INNER JOIN (tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) ON tbl_user.id_user = tbl_plan.Prepod_name WHERE (((tbl_group.group_name)='"&session("gr")&"') AND ((tbl_disc.disc_name)='"&disc_value&"') AND ((tbl_plan.Semestr)='"&session("sem")&"'))"
		'------------------------------
		'Массив dat, создание и заполнение датами проведения занятий и контрольными работами
		'------------------------------
		rs1.Open strsql2, conn,3
		Erase dat
		n_dat = cint(rs1.recordcount)
		redim dat(8, n_dat)
		for i=1 to n_dat
			dat(1, i) = rs1.Fields (1) 'id_zan
			dat(2, i) = left(cstr(rs1.Fields (0)),5) 'Дата проведения занятия
			dat(3, i) = rs1.Fields (2) 'Контрольная работа
			dat(5, i) = rs1.Fields (3) 'Примечание
			dat(6, i) = rs1.Fields (4) 'Автор
			dat(7, i) = rs1.Fields (5) 'Примечание студент
			dat(8, i) = rs1.Fields (6) 'Тип занятия
			rs1.MoveNext
		next
		rs1.Close
		count_str = int ((n_dat-1) / 18) + 1
		'------------------------------
		'Массив sob, создание и заполнение оценками и пропусками
		'------------------------------
		rs1.Open strsql3, conn, 3
		Erase sob
		redim sob (n_stud, n_dat, 9)
		redim zan_title (n_stud, 5, 2)
		while not rs1.eof
			for i=1 to n_stud
				for j=1 to n_dat
					if rs1.Fields(3) = student (i, 1) and rs1.fields(5) = dat (1, j) then 
						sob (i, j, 1) = rs1.fields (4)' Оценка или нб
						sob (i, j, 2) = rs1.Fields (7)' Автор записи
						sob (i, j, 3) = rs1.Fields (8)' Признак редактирования
						sob (i, j, 4) = rs1.Fields (9)' Дата редактирования
						sob (i, j, 5) = rs1.Fields (10)' ID журнала <-------------------------------------------------------
						sob (i, j, 6) = rs1.Fields (11)' Комментарий <-------------------------------------------------------
						sob (i, j, 7) = rs1.fields (12)' Оценка или нб (старое) <-------------------------------------------------------
						sob (i, j, 8) = rs1.fields (13)' 1НБ <-------------------------------------------
						sob (i, j, 9) = rs1.fields (14)' 2НБ <-------------------------------------------
						if rs1.fields (4) > 0 and rs1.fields (4) < 6 then
							zan_title(i, dat(8, j), 1) = zan_title(i, dat(8, j), 1) + rs1.fields (4)
							zan_title(i, dat(8, j), 2) = zan_title(i, dat(8, j), 2) + 1
						end if
					end if
				next
			next
			rs1.MoveNext
		Wend
		rs1.close
		for i=1 to n_stud
			count_prop = 0
			count_oc = 0
			sum_oc = 0
			for j=1 to n_dat
				if sob(i,j,8) = True then count_prop = count_prop + 0.5 'Считаем пропуски
				if sob(i,j,9) = True then count_prop = count_prop + 1 '<-------------------------------------------------------
				if sob (i,j,1) < 6 and sob (i,j, 1) <> "" then 
					sum_oc = sum_oc + sob (i, j, 1)
					count_oc = count_oc + 1
				end if
			next
			student (i, 3) = count_prop * 2
			if count_oc > 0 then student (i, 4) = round (sum_oc/count_oc, 2) else student (i, 4) = "-"
		next
		'--------------------------------------
		'Определение преподавателя
		'--------------------------------------
		rs1.Open strSQL_prep, Conn, 3
		prep = rs1.Fields(0)
		rs1.Close
		%>
		<center>
		<h4 style="margin-top: 50px;"><%=disc_value%>. Преподаватель <u><%=prep %></u></h4>
		</center>

		<!-- Заголовок таблицы -->

		<%
		kdolg_stud = 0
		pdolg = 0
		finish = n_dat
		start = 1
		'Проверка на наличие долгов
				if n_dat > 0 then
					for j=start to finish
						if obyaz = false then
							if dat(3,j)= false then
								for i=1 to n_stud
									if (sob(i,j,1) >= 1 and sob(i,j,1) < 6) and dat(3,j)= False then
										pdolg = 1
										exit for
									end if
								next
							else
								pdolg = 1
							end if
						else
							if dat(3,j)= true then
								pdolg = 1
							end if
						end if
						if pdolg = 1 then
							for i=1 to n_stud
								if not stud_id = "all" then
									if student(i, 1) = cint(mid(stud_id, 4)) then
										if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
											kdolg_stud = kdolg_stud + 1
											exit for
										end if
									end if
								else
									if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
										kdolg_stud = kdolg_stud + 1
										exit for
									end if
								end if
							next
						end if
						pdolg = 0
					next
				end if
	else 'Если все дисциплины
		kdolg_stud = 1
		%>
		<center>
		<h4 style="margin-top: 50px;">Все дисциплины</u></h4>
		</center>
		<%
	end if
'Если есть долги
if kdolg_stud > 0 then
	'Вывод формы 1
	if form_select = "form_1" then
		'Если одна дисциплина
		if not disc_value = "all" then
			%>
			<section class="table_style_minimal">
			<table align="center">
			<tr align=center>
				<th nowrap><b>Фамилия И.О.</b></th>
				<th><b>Дисциплина</b></th>
				<th><b>Форма контроля</b></th>
				<th><b>Название работы</b></th>
				<th><b>Дата</b></th>
				<th><b>Оценка</b></th>
			</tr>
			<%
			'if output_str = 0 then 
				finish = n_dat
				start = 1
				'start = (count_str - 1) * 18 + 1
			'else
				'finish = output_str * 18
				'if finish > n_dat then finish = n_dat
				'start = (output_str - 1) * 18 + 1
			'end if
			%>
			<!-- Заполнение журнала студентами и оценками -->
			<%
			for i=1 to n_stud
				pdolg = 0
				kdolg = 0
				p = 0
				if n_dat > 0 then
					for j=start to finish
						if obyaz = false then
							if dat(3,j)= false then
								for ii=1 to n_stud
									if (sob(ii,j,1) >= 1 and sob(ii,j,1) < 6) and dat(3,j)= False then
										pdolg = 1
										exit for
									end if
								next
							else
								pdolg = 1
							end if
						else
							if dat(3,j)= true then
								pdolg = 1
							end if
						end if
						if pdolg = 1 then
							if not stud_id = "all" then
								if student(i, 1) = cint(mid(stud_id, 4)) then
									if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8  then
										kdolg = kdolg + 1
									end if
								end if
							else
								if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8  then
									kdolg = kdolg + 1
								end if
							end if
						end if
						pdolg = 0
					next
					for j=start to finish
						if obyaz = false then
							if dat(3,j)= false then
								for ii=1 to n_stud
									if (sob(ii,j,1) >= 1 and sob(ii,j,1) < 6) and dat(3,j)= False then
										pdolg = 1
										exit for
									end if
								next
							else
								pdolg = 1
							end if
						else
							if dat(3,j)= true then
								pdolg = 1
							end if
						end if
						if pdolg = 1 then
							if not stud_id = "all" then
								if student(i, 1) = cint(mid(stud_id, 4)) then
									if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
										p = 1
										exit for
									end if
								end if
							else
								if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
									p = 1
									exit for
								end if
							end if
						end if
						pdolg = 0
					next
				end if
				if p = 1 then
					%>
					<tr>
					<!-- Фамилия И.О. --> <td rowspan=<%=kdolg%> align=center nowrap><a href="stud.asp?id_stud=<%=student(i,1)%>" title="<%
					'Средний балл
					for h = 1 to 5
						a = zan_title(i, h, 1)
						b = zan_title(i, h, 2)
						c = "-"
						if a <> "" and a > 0 and b <> "" and b > 0 then 
							if h = 1 then response.write "Теоретические работы: "
							if h = 2 then response.write "Практические работы: "
							if h = 3 then response.write "Тесты: "
							if h = 4 then response.write "Лабораторные работы: "
							if h = 5 then response.write "Самостоятельные работы: "
							c = round(a / b, 2)
							response.write  c  & "&#013;"
						end if
					next
					response.write("Пропущенные часы: " & student(i,3))
					%>" target="_blank"><%=student(i,2)%></a>
					</td>
					<!-- Дисциплина --> <td rowspan=<%=kdolg%> align=center><%=disc_value%></td>
					<%
					p_stud = true 'Проверка на первую строку заполнения
					if n_dat > 0 then
						for j=start to finish
							title_sob = ""
							title_soba = ""
							if sob (i, j, 7) <> "" then 
								if sob (i, j, 7) = "6" then 
									title_sob = "Предыдущая оценка: 2 нб"
								end if 
								if sob (i, j, 7) = "8" then 
									title_sob = "Предыдущая оценка: 1 нб"
								end if 
								if sob (i, j, 7) = "7" then 
									title_sob = "Предыдущая оценка: зачет"
								end if 
								if sob (i, j, 7) < "6" then 
									title_sob = "Предыдущая оценка: " & sob (i, j, 7)
								end if
							end if	
							if sob (i, j, 8) = True then
									title_soba = "Пропущен 1 час"
							end if
							if sob (i, j, 9) = True then
									title_soba = "Пропущено 2 часа"
							end if
							pdolg = 0
							if obyaz = false then
								if dat(3,j)= false then
									for ii=1 to n_stud
										if (sob(ii,j,1) >= 1 and sob(ii,j,1) < 6) and dat(3,j)= False then
											pdolg = 1
											exit for
										end if
									next
								else
									pdolg = 1
								end if
							else
								if dat(3,j)= true then
									pdolg = 1
								end if
							end if
							if pdolg = 1 then
								if not stud_id = "all" then
									if student(i, 1) = cint(mid(stud_id, 4)) then
										if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
												if p_stud = true then
													p_stud = false
												else
													%>
													<tr>
												<%
												end if%>
												<!-- Форма контроля--> <td align=center nowrap>
												<%
												h = dat(8, j)
												if h = 1 then response.write "Теоретическая работа"
												if h = 2 then response.write "Практическая работа"
												if h = 3 then response.write "Тест"
												if h = 4 then response.write "Лабораторная работа"
												if h = 5 then response.write "Самостоятельная работа"
												%>
												</td>
												<!-- Название работы --> <%if dat(5 ,j) = "" then response.write("<td align=center>-</td>") else response.write("<td>" & dat(5 ,j) & "</td>")%>
												<!-- Дата --> <td nowrap><%=dat (2, j)%></td>
												<!-- Оценка --> <td title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>" align="center">
												<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("<font color='red'>") %>
												<b title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>"><%if sob(i,j,1) = 6 then response.Write ("2нб") else if sob(i,j,1) = 7 then response.Write ("зач") else if sob(i,j,1) = 8 then response.Write ("1нб") else if sob(i, j,1) = "" then response.Write ("-") else response.Write (sob(i,j,1))%></b>
												<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("</font>") %>
												</td>
											</tr>
											<%
										end if
									end if
								else
									if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
										if p_stud = true then
											p_stud = false
										else
											%>
											<tr>
											<%
										end if
										%>
										<!-- Форма контроля--> <td align=center nowrap>
										<%
										h = dat(8, j)
										if h = 1 then response.write "Теоретическая работа"
										if h = 2 then response.write "Практическая работа"
										if h = 3 then response.write "Тест"
										if h = 4 then response.write "Лабораторная работа"
										if h = 5 then response.write "Самостоятельная работа"
										%>
										</td>
										<!-- Название работы --> <%if dat(5 ,j) = "" then response.write("<td align=center>-</td>") else response.write("<td>" & dat(5 ,j) & "</td>")%>
										<!-- Дата --> <td align=center nowrap><%=dat (2, j)%></td>
										<!-- Оценка --> <td title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>" align="center">
										<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("<font color='red'>") %>
											<b title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>"><%if sob(i,j,1) = 6 then response.Write ("2нб") else if sob(i,j,1) = 7 then response.Write ("зач") else if sob(i,j,1) = 8 then response.Write ("1нб") else if sob(i, j,1) = "" then response.Write ("-") else response.Write (sob(i,j,1))%></b>
											<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("</font>") %>
											</td>
										</tr>
										<%
									end if
								end if
							end if
							pdolg = 0
						next
					end if
				end if
			next
			%>
			</table>
			</section>
			<%
		else
			%>
			<section id="table_vedomost" class="table_style_minimal" style="display: block">
			<table align="center">
			<tr align=center>
				<th nowrap><b>Фамилия И.О.</b></th>
				<th><b>Дисциплина</b></th>
				<th><b>Форма контроля</b></th>
				<th><b>Название работы</b></th>
				<th><b>Дата</b></th>
				<th><b>Оценка</b></th>
			</tr>
			<%
			'if output_str = 0 then 
				finish = n_dat
				start = 1
				'start = (count_str - 1) * 18 + 1
			'else
				'finish = output_str * 18
				'if finish > n_dat then finish = n_dat
				'start = (output_str - 1) * 18 + 1
			'end if
			%>
			<!-- Заполнение журнала студентами и оценками -->
			<%
			for i=1 to n_stud
				pdolg = 0
				kdolg = 0
				p_stud = true
				p = 0
				rs_0_0.movefirst
				do until rs_0_0.EOF
					disc_value = rs_0_0.fields(0)
					if not zan_type = "0" then strSQL2 = "SELECT tbl_zan.Date, tbl_zan.id_zan, tbl_zan.kontr, tbl_zan.prim_student, tbl_user.user_fio, tbl_zan.prim_student, tbl_zan.zan_type, tbl_disc.disc_name, tbl_plan.Semestr, tbl_group.group_name FROM tbl_user INNER JOIN ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group =tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) ON tbl_user.id_user = tbl_plan.Prepod_name WHERE (((tbl_zan.zan_type)=" & zan_type & ") AND ((tbl_disc.disc_name)='" & disc_value & "') AND ((tbl_plan.Semestr)='" & session("sem") & "') AND ((tbl_group.group_name)='" & session("gr") & "')) ORDER BY tbl_zan.date, tbl_zan.id_zan;" else strSQL2 = "SELECT tbl_zan.Date, tbl_zan.id_zan, tbl_zan.kontr, tbl_zan.prim_student, tbl_user.user_fio, tbl_zan.prim_student, tbl_zan.zan_type, tbl_disc.disc_name, tbl_plan.Semestr, tbl_group.group_name FROM tbl_user INNER JOIN ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group =tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) ON tbl_user.id_user = tbl_plan.Prepod_name WHERE (((tbl_disc.disc_name)='" & disc_value & "') AND ((tbl_plan.Semestr)='" & session("sem") & "') AND ((tbl_group.group_name)='" & session("gr") & "')) ORDER BY tbl_zan.date, tbl_zan.id_zan;"
					strSQL3 = "SELECT tbl_group.group_name, tbl_plan.Semestr, tbl_disc.disc_name, tbl_student.id_student, tbl_journal.sobytie, tbl_zan.id_zan, tbl_plan.ID_plan, tbl_user.user_fio, tbl_journal.edit, tbl_journal.edit_date, tbl_journal.id_journal, tbl_journal.comment, tbl_journal.sobytie_old, tbl_journal.nb1, tbl_journal.nb2 FROM tbl_user INNER JOIN ((((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON (tbl_zan.id_zan = tbl_journal.zan) AND (tbl_student.id_student = tbl_journal.student_name)) ON tbl_user.id_user = tbl_journal.Author WHERE (((tbl_group.group_name)='" & session("gr") &"') AND ((tbl_plan.Semestr)='" & session("sem") &"') AND ((tbl_disc.disc_name)='" & disc_value &"'));"
					'Рекордсет для записи id дисциплины в скрытое поле
					strSQL4 = "SELECT tbl_plan.Semestr, tbl_plan.ID_plan, tbl_disc.disc_name, tbl_group.group_name FROM tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc=tbl_plan.disc_name) ON tbl_group.id_group=tbl_plan.gr_name WHERE (((tbl_plan.Semestr)='" & session("sem") & "') AND ((tbl_disc.disc_name)='" & disc_value & "') AND ((tbl_group.group_name)='" & session("gr") & "'))"
					'Рекордсет подсчета пропущенных часов
					strSQL5 = "SELECT tbl_student.student_fio, Count(tbl_journal.sobytie)*2 AS [Count-sobytie] FROM (((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON (tbl_zan.id_zan = tbl_journal.zan) AND (tbl_student.id_student = tbl_journal.student_name) WHERE (((tbl_group.group_name)='"&session("gr")&"') AND ((tbl_disc.disc_name)='"&disc_value&"') AND ((tbl_plan.Semestr)='"&session("sem")&"') AND ((tbl_journal.sobytie)=6)) GROUP BY tbl_student.student_fio"
					'Рекордсет подсчета средней оценки
					strSQL6 = "SELECT tbl_student.student_fio, Avg(tbl_journal.sobytie) AS [Count-sobytie] FROM (((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON (tbl_zan.id_zan = tbl_journal.zan) AND (tbl_student.id_student = tbl_journal.student_name) WHERE (((tbl_group.group_name)='"&session("gr")&"') AND ((tbl_disc.disc_name)='"&disc_value&"') AND ((tbl_plan.Semestr)='"&session("sem")&"') AND ((tbl_journal.sobytie)<6)) GROUP BY tbl_student.student_fio"
					strSQL7 = "SELECT tbl_disc.disc_name, Count(tbl_zan.date) AS [Count-date], tbl_plan.Semestr, tbl_group.group_name FROM tbl_group INNER JOIN ((tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name WHERE (((tbl_disc.disc_name)='" & disc_value & "') AND ((tbl_plan.Semestr)='" & session("sem") & "') AND ((tbl_group.group_name)='" & session("gr") & "')) GROUP BY tbl_disc.disc_name, tbl_plan.Semestr, tbl_group.group_name" 
					strSQL_prep = "SELECT tbl_user.user_fio FROM tbl_user INNER JOIN (tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) ON tbl_user.id_user = tbl_plan.Prepod_name WHERE (((tbl_group.group_name)='"&session("gr")&"') AND ((tbl_disc.disc_name)='"&disc_value&"') AND ((tbl_plan.Semestr)='"&session("sem")&"'))"
					'------------------------------
					'Массив dat, создание и заполнение датами проведения занятий и контрольными работами
					'------------------------------
					rs1.Open strsql2, conn,3
					Erase dat
					n_dat = cint(rs1.recordcount)
					redim dat(8, n_dat)
					for ii=1 to n_dat
						dat(1, ii) = rs1.Fields (1) 'id_zan
						dat(2, ii) = left(cstr(rs1.Fields (0)),5) 'Дата проведения занятия
						dat(3, ii) = rs1.Fields (2) 'Контрольная работа
						dat(5, ii) = rs1.Fields (3) 'Примечание
						dat(6, ii) = rs1.Fields (4) 'Автор
						dat(7, ii) = rs1.Fields (5) 'Примечание студент
						dat(8, ii) = rs1.Fields (6) 'Тип занятия
						rs1.MoveNext
					next
					rs1.Close
					count_str = int ((n_dat-1) / 18) + 1
					%>
					<%
					'------------------------------
					'Массив sob, создание и заполнение оценками и пропусками
					'------------------------------
					rs1.Open strsql3, conn, 3
					Erase sob
					redim sob (n_stud, n_dat, 9)
					redim zan_title (n_stud, 5, 2)
					while not rs1.eof
						for ii=1 to n_stud
							for j=1 to n_dat
								if rs1.Fields(3) = student (ii, 1) and rs1.fields(5) = dat (1, j) then 
									sob (ii, j, 1) = rs1.fields (4)' Оценка или нб
									sob (ii, j, 2) = rs1.Fields (7)' Автор записи
									sob (ii, j, 3) = rs1.Fields (8)' Признак редактирования
									sob (ii, j, 4) = rs1.Fields (9)' Дата редактирования
									sob (ii, j, 5) = rs1.Fields (10)' ID журнала <-------------------------------------------------------
									sob (ii, j, 6) = rs1.Fields (11)' Комментарий <-------------------------------------------------------
									sob (ii, j, 7) = rs1.fields (12)' Оценка или нб (старое) <-------------------------------------------------------
									sob (ii, j, 8) = rs1.fields (13)' 1НБ <-------------------------------------------
									sob (ii, j, 9) = rs1.fields (14)' 2НБ <-------------------------------------------
									if rs1.fields (4) > 0 and rs1.fields (4) < 6 then
										zan_title(ii, dat(8, j), 1) = zan_title(ii, dat(8, j), 1) + rs1.fields (4)
										zan_title(ii, dat(8, j), 2) = zan_title(ii, dat(8, j), 2) + 1
									end if
								end if
							next
						next
						rs1.MoveNext
					Wend
					rs1.close
					for ii=1 to n_stud
						count_prop = 0
						count_oc = 0
						sum_oc = 0
						for j=1 to n_dat
							if sob(ii,j,8) = True then count_prop = count_prop + 0.5 'Считаем пропуски
							if sob(ii,j,9) = True then count_prop = count_prop + 1 '<-------------------------------------------------------
							if sob (ii,j,1) < 6 and sob (ii,j, 1) <> "" then 
								sum_oc = sum_oc + sob (ii, j, 1)
								count_oc = count_oc + 1
							end if
						next
						student (ii, 3) = count_prop * 2
						if count_oc > 0 then student (ii, 4) = round (sum_oc/count_oc, 2) else student (ii, 4) = "-"
					next
					'--------------------------------------
					'Определение преподавателя
					'--------------------------------------
					rs1.Open strSQL_prep, Conn, 3
					prep = rs1.Fields(0)
					rs1.Close
					kdolg_stud = 0
					kdolg = 0
					pdolg = 0
					finish = n_dat
					start = 1

					'Проверка на наличие долгов
					if n_dat > 0 then
						for j=start to finish
							if obyaz = false then
								if dat(3,j)= false then
									for ii=1 to n_stud
										if (sob(ii,j,1) >= 1 and sob(ii,j,1) < 6) and dat(3,j)= False then
											pdolg = 1
											exit for
										end if
									next
								else
									pdolg = 1
								end if
							else
								if dat(3,j)= true then
									pdolg = 1
								end if
							end if
							if pdolg = 1 then
								for ii=1 to n_stud
									if not stud_id = "all" then
										if student(ii, 1) = cint(mid(stud_id, 4)) then
											if (sob(ii,j,1) >= 0 and sob(ii,j,1)<=2.49) or sob(ii,j,1) = 6 or sob(ii,j,1) = 8 then
												kdolg_stud = kdolg_stud + 1
												exit for
											end if
										end if
									else
										if (sob(ii,j,1) >= 0 and sob(ii,j,1)<=2.49) or sob(ii,j,1) = 6 or sob(ii,j,1) = 8 then
											kdolg_stud = kdolg_stud + 1
											exit for
										end if
									end if
								next
							end if
							pdolg = 0
						next
					end if
					'Если есть долги
					if kdolg_stud > 0 then
						kdolg_disc = kdolg_disc + 1
						if n_dat > 0 then
							for j=start to finish
								if obyaz = false then
									if dat(3,j)= false then
										for ii=1 to n_stud
											if (sob(ii,j,1) >= 1 and sob(ii,j,1) < 6) and dat(3,j)= False then
												pdolg = 1
												exit for
											end if
										next
									else
										pdolg = 1
									end if
								else
									if dat(3,j)= true then
										pdolg = 1
									end if
								end if
								if pdolg = 1 then
									if not stud_id = "all" then
										if student(i, 1) = cint(mid(stud_id, 4)) then
											if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8  then
												kdolg = kdolg + 1
											end if
										end if
									else
										if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8  then
											kdolg = kdolg + 1
										end if
									end if
								end if
								pdolg = 0
							next
							for j=start to finish
								if obyaz = false then
									if dat(3,j)= false then
										for ii=1 to n_stud
											if (sob(ii,j,1) >= 1 and sob(ii,j,1) < 6) and dat(3,j)= False then
												pdolg = 1
												exit for
											end if
										next
									else
										pdolg = 1
									end if
								else
									if dat(3,j)= true then
										pdolg = 1
									end if
								end if
								if pdolg = 1 then
									if not stud_id = "all" then
										if student(i, 1) = cint(mid(stud_id, 4)) then
											if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
												p = 1
												exit for
											end if
										end if
									else
										if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
											p = 1
											exit for
										end if
									end if
								end if
								pdolg = 0
							next
						end if
						if p = 1 and kdolg > 0 then
							%>
							<tr>
							<%
							'if p_stud = true then
								%>
								<!-- Фамилия И.О. --> <td rowspan=<%=kdolg%> align=center nowrap><a href="stud.asp?id_stud=<%=student(i,1)%>" title="<%
								'Средний балл
								for h = 1 to 5
									a = zan_title(i, h, 1)
									b = zan_title(i, h, 2)
									c = "-"
									if a <> "" and a > 0 and b <> "" and b > 0 then 
										if h = 1 then response.write "Теоретические работы: "
										if h = 2 then response.write "Практические работы: "
										if h = 3 then response.write "Тесты: "
										if h = 4 then response.write "Лабораторные работы: "
										if h = 5 then response.write "Самостоятельные работы: "
										c = round(a / b, 2)
										response.write  c  & "&#013;"
									end if
								next
								response.write("Пропущенные часы: " & student(i,3))
								%>" target="_blank"><%=student(i,2)%></a>
								</td>
								<!-- Дисциплина --> <td rowspan=<%=kdolg%> align=center><%=disc_value%></td>
								<%
							'end if
							p_stud = true 'Проверка на первую строку заполнения
							if n_dat > 0 then
								for j=start to finish
									title_sob = ""
									title_soba = ""
									if sob (i, j, 7) <> "" then 
										if sob (i, j, 7) = "6" then 
											title_sob = "Предыдущая оценка: 2 нб"
										end if 
										if sob (i, j, 7) = "8" then 
											title_sob = "Предыдущая оценка: 1 нб"
										end if 
										if sob (i, j, 7) = "7" then 
											title_sob = "Предыдущая оценка: зачет"
										end if 
										if sob (i, j, 7) < "6" then 
											title_sob = "Предыдущая оценка: " & sob (i, j, 7)
										end if
									end if	
									if sob (i, j, 8) = True then
											title_soba = "Пропущен 1 час"
									end if
									if sob (i, j, 9) = True then
											title_soba = "Пропущено 2 часа"
									end if
									pdolg = 0
									if obyaz = false then
										if dat(3,j)= false then
											for ii=1 to n_stud
												if (sob(ii,j,1) >= 1 and sob(ii,j,1) < 6) and dat(3,j)= False then
													pdolg = 1
													exit for
												end if
											next
										else
											pdolg = 1
										end if
									else
										if dat(3,j)= true then
											pdolg = 1
										end if
									end if
									if pdolg = 1 then
										if not stud_id = "all" then
											if student(i, 1) = cint(mid(stud_id, 4)) then
												if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
														if p_stud = true then
															p_stud = false
														else
															%>
															<tr>
														<%
														end if%>
														<!-- Форма контроля--> <td align=center nowrap>
														<%
														h = dat(8, j)
														if h = 1 then response.write "Теоретическая работа"
														if h = 2 then response.write "Практическая работа"
														if h = 3 then response.write "Тест"
														if h = 4 then response.write "Лабораторная работа"
														if h = 5 then response.write "Самостоятельная работа"
														%>
														</td>
														<!-- Название работы --> <%if dat(5 ,j) = "" then response.write("<td align=center>-</td>") else response.write("<td>" & dat(5 ,j) & "</td>")%>
														<!-- Дата --> <td align=center nowrap><%=dat (2, j)%></td>
														<!-- Оценка --> <td title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>" align="center">
														<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("<font color='red'>") %>
														<b title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>"><%if sob(i,j,1) = 6 then response.Write ("2нб") else if sob(i,j,1) = 7 then response.Write ("зач") else if sob(i,j,1) = 8 then response.Write ("1нб") else if sob(i, j,1) = "" then response.Write ("-") else response.Write (sob(i,j,1))%></b>
														<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("</font>") %>
														</td>
													</tr>
													<%
												end if
											end if
										else
											if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
												if p_stud = true then
													p_stud = false
												else
													%>
													<tr>
													<%
												end if
												%>
												<!-- Форма контроля--> <td align=center nowrap>
												<%
												h = dat(8, j)
												if h = 1 then response.write "Теоретическая работа"
												if h = 2 then response.write "Практическая работа"
												if h = 3 then response.write "Тест"
												if h = 4 then response.write "Лабораторная работа"
												if h = 5 then response.write "Самостоятельная работа"
												%>
												</td>
												<!-- Название работы --> <%if dat(5 ,j) = "" then response.write("<td align=center>-</td>") else response.write("<td>" & dat(5 ,j) & "</td>")%>
												<!-- Дата --> <td align=center nowrap><%=dat (2, j)%></td>
												<!-- Оценка --> <td title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>" align="center">
												<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("<font color='red'>") %>
													<b title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>"><%if sob(i,j,1) = 6 then response.Write ("2нб") else if sob(i,j,1) = 7 then response.Write ("зач") else if sob(i,j,1) = 8 then response.Write ("1нб") else if sob(i, j,1) = "" then response.Write ("-") else response.Write (sob(i,j,1))%></b>
													<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("</font>") %>
													</td>
												</tr>
												<%
											end if
										end if
									end if
									pdolg = 0
								next
							end if
						end if
					else 'Если нет долгов
					end if
					rs_0_0.MoveNext
				loop
			next
			%>
			</table>
			</section>
			<%
			if kdolg_disc = 0 then
				%>
				<script>
					document.getElementById("table_vedomost").style.display = "none";
				</script>
				<center>
				<img style="padding: 45px 0px 5px 0px" widht=8% src=images/process_succesful.png>
				</center>
				<%
				if obyaz = false then
					if stud_id = "all" then%>
						<p style="padding: 5px 0px 20px 0px">У группы <b><%=session("gr")%></b> задолженностей по типу работы <b>"<%=zan_type_name%>"</b> не имеется.</p>
					<%
					else
						rs_stud.movefirst
						do until rs_stud.EOF
							rs_stud_id = "id_" & rs_stud.fields(1)
							if stud_id = rs_stud_id then
								stud_fio = rs_stud.fields(0)
								exit do
							end if
							rs_stud.MoveNext
						loop
					%>
						<p style="padding: 5px 0px 20px 0px">У студента/курсанта <b><%=stud_fio%></b> группы <b><%=session("gr")%></b> задолженностей по типу работы <b>"<%=zan_type_name%>"</b> не имеется.</p>
					<%
					end if%>
				<%
				else
					if stud_id = "all" then%>
						<p style="padding: 5px 0px 20px 0px">У группы <b><%=session("gr")%></b> задолженностей по обязательным работам типа <b>"<%=zan_type_name%>"</b> не имеется.</p>
					<%
					else
						rs_stud.movefirst
						do until rs_stud.EOF
							rs_stud_id = "id_" & rs_stud.fields(1)
							if stud_id = rs_stud_id then
								stud_fio = rs_stud.fields(0)
								exit do
							end if
							rs_stud.MoveNext
						loop
					%>
						<p style="padding: 5px 0px 20px 0px">У студента/курсанта <b><%=stud_fio%></b> группы <b><%=session("gr")%></b> задолженностей по обязательным работам типа <b>"<%=zan_type_name%>"</b> не имеется.</p>
					<%
					end if%>
				<%
				end if
			end if
		end if
	else 'Вывод Формы 2
		'Если одна дисциплина
		if not disc_value = "all" then
			%>
					<section class="table_style_minimal">
					<table align="center">
					<tr align=center>
						<th rowspan=2>№</th>
						<th nowrap rowspan=2><b>Фамилия И.О.</b></th>
						<th colspan=<%=kdolg_stud + 1%>><b><%=zan_type_name%></b></th>
						</tr>
						<tr align=center>
						<th align=center>Всего</th>
					<%
					'if output_str = 0 then 
						finish = n_dat
						start = 1
						'start = (count_str - 1) * 18 + 1
					'else
						'finish = output_str * 18
						'if finish > n_dat then finish = n_dat
						'start = (output_str - 1) * 18 + 1
					'end if
					if n_dat > 0 then
						for j = start to finish
							if obyaz = false then
								if dat(3,j)= false then
									for i=1 to n_stud
										if (sob(i,j,1) >= 1 and sob(i,j,1) < 6) and dat(3,j)= False then
											pdolg = 1
											exit for
										end if
									next
								else
									pdolg = 1
								end if
							else
								if dat(3,j)= true then
									pdolg = 1
								end if
							end if
							if pdolg = 1 then
								for i=1 to n_stud
									if not stud_id = "all" then
										if student(i, 1) = cint(mid(stud_id, 4)) then
											if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
												%>
												<th <%if dat(3,j)= True then response.write("bgcolor='lightblue' title = 'Обязательная практическая или контрольная работа' ")%>><%=dat(2,j)%><br /><input type="checkbox" disabled style="display: none;" <%if dat(3,j)= True then response.write("checked")%> /><%if dat(3,j)= True then response.write("<span class='mif-flag'></span>") %></th>
												<%
												exit for
											end if
										end if
									else
										if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
											%>
											<th <%if dat(3,j)= True then response.write("bgcolor='lightblue' title = 'Обязательная практическая или контрольная работа' ")%>><%=dat(2,j)%><br /><input type="checkbox" disabled style="display: none;" <%if dat(3,j)= True then response.write("checked")%> /><%if dat(3,j)= True then response.write("<span class='mif-flag'></span>") %></th>
											<%
											exit for
										end if
									end if
								next
							end if
							pdolg = 0
						next
					end if%>
					</tr>
					
					<!-- Заполнение журнала студентами и оценками -->

					<%
					for i=1 to n_stud
						pdolg = 0
						kdolg = 0
						p = 0
						if n_dat > 0 then
							for j=start to finish
								if obyaz = false then
									if dat(3,j)= false then
										for ii=1 to n_stud
											if (sob(ii,j,1) >= 1 and sob(ii,j,1) < 6) and dat(3,j)= False then
												pdolg = 1
												exit for
											end if
										next
									else
										pdolg = 1
									end if
								else
									if dat(3,j)= true then
										pdolg = 1
									end if
								end if
								if pdolg = 1 then
									if not stud_id = "all" then
										if student(i, 1) = cint(mid(stud_id, 4)) then
											if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8  then
												kdolg = kdolg + 1
											end if
										end if
									else
										if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8  then
											kdolg = kdolg + 1
										end if
									end if
								end if
								pdolg = 0
							next
							for j=start to finish
								if obyaz = false then
									if dat(3,j)= false then
										for ii=1 to n_stud
											if (sob(ii,j,1) >= 1 and sob(ii,j,1) < 6) and dat(3,j)= False then
												pdolg = 1
												exit for
											end if
										next
									else
										pdolg = 1
									end if
								else
									if dat(3,j)= true then
										pdolg = 1
									end if
								end if
								if pdolg = 1 then
									if not stud_id = "all" then
										if student(i, 1) = cint(mid(stud_id, 4)) then
											if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
												p = 1
												exit for
											end if
										end if
									else
										if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
											p = 1
											exit for
										end if
									end if
								end if
								pdolg = 0
							next
						end if
						if p = 1 then
						%>
							<tr onmouseover="this.bgColor='lightblue'" onmouseout="this.bgColor='white'">
								<!-- № --> <td align=center><%=i%></td>
								<!-- Фамилия И.О. --> <td nowrap><a href="stud.asp?id_stud=<%=student(i,1)%>" title="<%
								'Средний балл
							for h = 1 to 5
								a = zan_title(i, h, 1)
								b = zan_title(i, h, 2)
								c = "-"
								if a <> "" and a > 0 and b <> "" and b > 0 then 
									if h = 1 then response.write "Теоретические работы: "
									if h = 2 then response.write "Практические работы: "
									if h = 3 then response.write "Тесты: "
									if h = 4 then response.write "Лабораторные работы: "
									if h = 5 then response.write "Самостоятельные работы: "
									c = round(a / b, 2)
									response.write  c  & "&#013;"
								end if
							next
							response.write("Пропущенные часы: " & student(i,3))
						%>" target="_blank"><%=student(i,2)%></a></td>
								
							<td align=center><%=kdolg%></td>

							<%if n_dat > 0 then 
								for j=start to finish%>

								<% 
									title_sob = ""
									title_soba = ""
									if sob (i, j, 7) <> "" then 
										if sob (i, j, 7) = "6" then 
											title_sob = "Предыдущая оценка: 2 нб"
										end if 
										if sob (i, j, 7) = "8" then 
											title_sob = "Предыдущая оценка: 1 нб"
										end if 
										if sob (i, j, 7) = "7" then 
											title_sob = "Предыдущая оценка: зачет"
										end if 
										if sob (i, j, 7) < "6" then 
											title_sob = "Предыдущая оценка: " & sob (i, j, 7)
										end if
									end if	
									if sob (i, j, 8) = True then
											title_soba = "Пропущен 1 час"
									end if
									if sob (i, j, 9) = True then
											title_soba = "Пропущено 2 часа"
									end if
									pdolg = 0
									if obyaz = false then
										if dat(3,j)= false then
											for ii=1 to n_stud
												if (sob(ii,j,1) >= 1 and sob(ii,j,1) < 6) and dat(3,j)= False then
													pdolg = 1
													exit for
												end if
											next
										else
											pdolg = 1
										end if
									else
										if dat(3,j)= true then
											pdolg = 1
										end if
									end if
									if pdolg = 1 then
										for ii=1 to n_stud
											if not stud_id = "all" then
												if student(ii, 1) = cint(mid(stud_id, 4)) then
													if (sob(ii,j,1) >= 0 and sob(ii,j,1)<=2.49) or sob(ii,j,1) = 6 or sob(ii,j,1) = 8 then
									%>
									<td <%if dat(3,j)= True then response.write("bgcolor='lightblue'")%> title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>" align="center">
										
									<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("<font color='red'>") %>
											<b title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>"><%if sob(i,j,1) = 6 then response.Write ("2нб") else if sob(i,j,1) = 7 then response.Write ("зач") else if sob(i,j,1) = 8 then response.Write ("1нб") else if sob(i, j,1) = "" then response.Write ("&nbsp") else response.Write (sob(i,j,1))%></b>
										<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("</font>") %>
									</td>
												<%		exit for
													end if
												end if
											else
												if (sob(ii,j,1) >= 0 and sob(ii,j,1)<=2.49) or sob(ii,j,1) = 6 or sob(ii,j,1) = 8 then
									%>
									<td <%if dat(3,j)= True then response.write("bgcolor='lightblue'")%> title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>" align="center">
									
									<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("<font color='red'>") %>
										<b title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>"><%if sob(i,j,1) = 6 then response.Write ("2нб") else if sob(i,j,1) = 7 then response.Write ("зач") else if sob(i,j,1) = 8 then response.Write ("1нб") else if sob(i, j,1) = "" then response.Write ("&nbsp") else response.Write (sob(i,j,1))%></b>
										<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("</font>") %>
									</td>
											<%		exit for
												end if
											end if
										next
									end if
									pdolg = 0
								next
							end if%>
						</tr>
					<%
						end if
					next%>
					<%

					if zan_type = 0 then%>
					<tr>
						<td colspan =3><div style='line-height: 1.9;'><b>Теоретическая работа<br>Практическая работа<br>Тест<br>Лабораторная работа<br>Самостоятельная работа</b></div>
						</td>
						<%
							if n_dat>0 then
								for j=start to finish
									pdolg = 0
									if obyaz = false then
										if dat(3,j)= false then
											for i=1 to n_stud
												if (sob(i,j,1) >= 2 and sob(i,j,1) <= 5) and dat(3,j)= False then
													pdolg = 1
													exit for
												end if
											next
										else
											pdolg = 1
										end if
									else
										if dat(3,j)= true then
											pdolg = 1
										end if
									end if
									if pdolg = 1 then
										for ii=1 to n_stud
											if not stud_id = "all" then
												if student(ii, 1) = cint(mid(stud_id, 4)) then
													if (sob(ii,j,1) >= 0 and sob(ii,j,1)<=2.49) or sob(ii,j,1) = 6 or sob(ii,j,1) = 8 then
														old_p_name_type = "zan_type"&j
														response.write "<td align=center>"
														response.write "<input type='hidden' hidden name='old_zan_"& j &"' value='"& dat(8,j) & "'>"
															for h = 1 to 5
																if h = dat(8,j) then
																	'response.write "<label class='input-control checkbox small-check' style='line-height: 0px; height: 17px; min-height:0px;' title='" & dat(5 ,j) & "'><input type='checkbox' disabled name='"& old_p_name_type &"_"& h &"' checked><span class='check' style='line-height: 0px;'></span></label><br>"
																	if not dat(5 ,j) = "" then
																		response.write("<table cellpadding=0 cellspacing=0 bordercolor=white style='background: radial-gradient(50% 50%, #A7CECC, white); border-radius: 10px; border: 0px; margin: 0px; padding: 0px; cursor: help;'><tr><td style='margin: 0px; padding: 5px; border: 0px;' title='" & dat(5 ,j) & "'><input type='checkbox' style='cursor: help;' title='" & dat(5 ,j) & "' disabled name='"& old_p_name_type &"_"& h &"' checked></td></tr></table>")
																	else
																		response.write "<input type='checkbox' style='margin: 5px;' disabled name='"& old_p_name_type &"_"& h &"' checked><br>"
																	end if
																else
																	'response.write "<label class='input-control checkbox small-check' style='line-height: 0px; height: 17px; min-height:0px;'><input type='checkbox' disabled name='"& old_p_name_type &"_"& h &"'><span class='check' style='line-height: 0px;'></span></label><br>"
																	response.write "<input type='checkbox' style='margin: 5px;' disabled name='"& old_p_name_type &"_"& h &"'><br>"
																end if
															next
														response.write "</td>"
														exit for
													end if
												end if
											else
												if (sob(ii,j,1) >= 0 and sob(ii,j,1)<=2.49) or sob(ii,j,1) = 6 or sob(ii,j,1) = 8 then
													old_p_name_type = "zan_type"&j
													response.write "<td align=center>"
													response.write "<input type='hidden' hidden name='old_zan_"& j &"' value='"& dat(8,j) & "'>"
														for h = 1 to 5
															if h = dat(8,j) then
																'response.write "<label class='input-control checkbox small-check' style='line-height: 0px; height: 17px; min-height:0px;' title='" & dat(5 ,j) & "'><input type='checkbox' disabled name='"& old_p_name_type &"_"& h &"' checked><span class='check' style='line-height: 0px;'></span></label><br>"
																if not dat(5 ,j) = "" then
																	response.write("<table cellpadding=0 cellspacing=0 bordercolor=white style='background: radial-gradient(50% 50%, #A7CECC, white); border-radius: 10px; border: 0px; margin: 0px; padding: 0px; cursor: help;'><tr><td style='margin: 0px; padding: 5px; border: 0px;' title='" & dat(5 ,j) & "'><input type='checkbox' style='cursor: help;' title='" & dat(5 ,j) & "' disabled name='"& old_p_name_type &"_"& h &"' checked></td></tr></table>")
																else
																	response.write "<input type='checkbox' style='margin: 5px;' disabled name='"& old_p_name_type &"_"& h &"' checked><br>"
																end if
															else
																'response.write "<label class='input-control checkbox small-check' style='line-height: 0px; height: 17px; min-height:0px;'><input type='checkbox' disabled name='"& old_p_name_type &"_"& h &"'><span class='check' style='line-height: 0px;'></span></label><br>"
																response.write "<input type='checkbox' style='margin: 5px;' disabled name='"& old_p_name_type &"_"& h &"'><br>"
															end if
														next
													response.write "</td>"
													exit for
												end if
											end if
										next
									end if
								next
							end if
						%>
					</tr>
					<%
					end if%>
					</table>
					</section>
					<br>
					<%
		else 'Если все дисциплины
			rs_0_0.movefirst
			do until rs_0_0.EOF
				disc_value = rs_0_0.fields(0)
				if not zan_type = "0" then strSQL2 = "SELECT tbl_zan.Date, tbl_zan.id_zan, tbl_zan.kontr, tbl_zan.prim_student, tbl_user.user_fio, tbl_zan.prim_student, tbl_zan.zan_type, tbl_disc.disc_name, tbl_plan.Semestr, tbl_group.group_name FROM tbl_user INNER JOIN ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group =tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) ON tbl_user.id_user = tbl_plan.Prepod_name WHERE (((tbl_zan.zan_type)=" & zan_type & ") AND ((tbl_disc.disc_name)='" & disc_value & "') AND ((tbl_plan.Semestr)='" & session("sem") & "') AND ((tbl_group.group_name)='" & session("gr") & "')) ORDER BY tbl_zan.date, tbl_zan.id_zan;" else strSQL2 = "SELECT tbl_zan.Date, tbl_zan.id_zan, tbl_zan.kontr, tbl_zan.prim_student, tbl_user.user_fio, tbl_zan.prim_student, tbl_zan.zan_type, tbl_disc.disc_name, tbl_plan.Semestr, tbl_group.group_name FROM tbl_user INNER JOIN ((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group =tbl_plan.gr_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) ON tbl_user.id_user = tbl_plan.Prepod_name WHERE (((tbl_disc.disc_name)='" & disc_value & "') AND ((tbl_plan.Semestr)='" & session("sem") & "') AND ((tbl_group.group_name)='" & session("gr") & "')) ORDER BY tbl_zan.date, tbl_zan.id_zan;"
				strSQL3 = "SELECT tbl_group.group_name, tbl_plan.Semestr, tbl_disc.disc_name, tbl_student.id_student, tbl_journal.sobytie, tbl_zan.id_zan, tbl_plan.ID_plan, tbl_user.user_fio, tbl_journal.edit, tbl_journal.edit_date, tbl_journal.id_journal, tbl_journal.comment, tbl_journal.sobytie_old, tbl_journal.nb1, tbl_journal.nb2 FROM tbl_user INNER JOIN ((((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON (tbl_zan.id_zan = tbl_journal.zan) AND (tbl_student.id_student = tbl_journal.student_name)) ON tbl_user.id_user = tbl_journal.Author WHERE (((tbl_group.group_name)='" & session("gr") &"') AND ((tbl_plan.Semestr)='" & session("sem") &"') AND ((tbl_disc.disc_name)='" & disc_value &"'));"
				'Рекордсет для записи id дисциплины в скрытое поле
				strSQL4 = "SELECT tbl_plan.Semestr, tbl_plan.ID_plan, tbl_disc.disc_name, tbl_group.group_name FROM tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc=tbl_plan.disc_name) ON tbl_group.id_group=tbl_plan.gr_name WHERE (((tbl_plan.Semestr)='" & session("sem") & "') AND ((tbl_disc.disc_name)='" & disc_value & "') AND ((tbl_group.group_name)='" & session("gr") & "'))"
				'Рекордсет подсчета пропущенных часов
				strSQL5 = "SELECT tbl_student.student_fio, Count(tbl_journal.sobytie)*2 AS [Count-sobytie] FROM (((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON (tbl_zan.id_zan = tbl_journal.zan) AND (tbl_student.id_student = tbl_journal.student_name) WHERE (((tbl_group.group_name)='"&session("gr")&"') AND ((tbl_disc.disc_name)='"&disc_value&"') AND ((tbl_plan.Semestr)='"&session("sem")&"') AND ((tbl_journal.sobytie)=6)) GROUP BY tbl_student.student_fio"
				'Рекордсет подсчета средней оценки
				strSQL6 = "SELECT tbl_student.student_fio, Avg(tbl_journal.sobytie) AS [Count-sobytie] FROM (((tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) INNER JOIN tbl_student ON tbl_group.id_group = tbl_student.group_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) INNER JOIN tbl_journal ON (tbl_zan.id_zan = tbl_journal.zan) AND (tbl_student.id_student = tbl_journal.student_name) WHERE (((tbl_group.group_name)='"&session("gr")&"') AND ((tbl_disc.disc_name)='"&disc_value&"') AND ((tbl_plan.Semestr)='"&session("sem")&"') AND ((tbl_journal.sobytie)<6)) GROUP BY tbl_student.student_fio"
				strSQL7 = "SELECT tbl_disc.disc_name, Count(tbl_zan.date) AS [Count-date], tbl_plan.Semestr, tbl_group.group_name FROM tbl_group INNER JOIN ((tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) INNER JOIN tbl_zan ON tbl_plan.ID_plan = tbl_zan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name WHERE (((tbl_disc.disc_name)='" & disc_value & "') AND ((tbl_plan.Semestr)='" & session("sem") & "') AND ((tbl_group.group_name)='" & session("gr") & "')) GROUP BY tbl_disc.disc_name, tbl_plan.Semestr, tbl_group.group_name" 
				strSQL_prep = "SELECT tbl_user.user_fio FROM tbl_user INNER JOIN (tbl_group INNER JOIN (tbl_disc INNER JOIN tbl_plan ON tbl_disc.ID_disc = tbl_plan.disc_name) ON tbl_group.id_group = tbl_plan.gr_name) ON tbl_user.id_user = tbl_plan.Prepod_name WHERE (((tbl_group.group_name)='"&session("gr")&"') AND ((tbl_disc.disc_name)='"&disc_value&"') AND ((tbl_plan.Semestr)='"&session("sem")&"'))"
				'------------------------------
				'Массив dat, создание и заполнение датами проведения занятий и контрольными работами
				'------------------------------
				rs1.Open strsql2, conn,3
				Erase dat
				n_dat = cint(rs1.recordcount)
				redim dat(8, n_dat)
				for i=1 to n_dat
					dat(1, i) = rs1.Fields (1) 'id_zan
					dat(2, i) = left(cstr(rs1.Fields (0)),5) 'Дата проведения занятия
					dat(3, i) = rs1.Fields (2) 'Контрольная работа
					dat(5, i) = rs1.Fields (3) 'Примечание
					dat(6, i) = rs1.Fields (4) 'Автор
					dat(7, i) = rs1.Fields (5) 'Примечание студент
					dat(8, i) = rs1.Fields (6) 'Тип занятия
					rs1.MoveNext
				next
				rs1.Close
				count_str = int ((n_dat-1) / 18) + 1
				%>
				<%
				'------------------------------
				'Массив sob, создание и заполнение оценками и пропусками
				'------------------------------
				rs1.Open strsql3, conn, 3
				Erase sob
				redim sob (n_stud, n_dat, 9)
				redim zan_title (n_stud, 5, 2)
				while not rs1.eof
					for i=1 to n_stud
						for j=1 to n_dat
							if rs1.Fields(3) = student (i, 1) and rs1.fields(5) = dat (1, j) then 
								sob (i, j, 1) = rs1.fields (4)' Оценка или нб
								sob (i, j, 2) = rs1.Fields (7)' Автор записи
								sob (i, j, 3) = rs1.Fields (8)' Признак редактирования
								sob (i, j, 4) = rs1.Fields (9)' Дата редактирования
								sob (i, j, 5) = rs1.Fields (10)' ID журнала <-------------------------------------------------------
								sob (i, j, 6) = rs1.Fields (11)' Комментарий <-------------------------------------------------------
								sob (i, j, 7) = rs1.fields (12)' Оценка или нб (старое) <-------------------------------------------------------
								sob (i, j, 8) = rs1.fields (13)' 1НБ <-------------------------------------------
								sob (i, j, 9) = rs1.fields (14)' 2НБ <-------------------------------------------
								if rs1.fields (4) > 0 and rs1.fields (4) < 6 then
									zan_title(i, dat(8, j), 1) = zan_title(i, dat(8, j), 1) + rs1.fields (4)
									zan_title(i, dat(8, j), 2) = zan_title(i, dat(8, j), 2) + 1
								end if
							end if
						next
					next
					rs1.MoveNext
				Wend
				rs1.close
				for i=1 to n_stud
					count_prop = 0
					count_oc = 0
					sum_oc = 0
					for j=1 to n_dat
						if sob(i,j,8) = True then count_prop = count_prop + 0.5 'Считаем пропуски
						if sob(i,j,9) = True then count_prop = count_prop + 1 '<-------------------------------------------------------
						if sob (i,j,1) < 6 and sob (i,j, 1) <> "" then 
							sum_oc = sum_oc + sob (i, j, 1)
							count_oc = count_oc + 1
						end if
					next
					student (i, 3) = count_prop * 2
					if count_oc > 0 then student (i, 4) = round (sum_oc/count_oc, 2) else student (i, 4) = "-"
				next
				'--------------------------------------
				'Определение преподавателя
				'--------------------------------------
				rs1.Open strSQL_prep, Conn, 3
				prep = rs1.Fields(0)
				rs1.Close
				%>

				<!-- Заголовок таблицы -->

				<%
				i = 0
				kdolg_stud = 0
				pdolg = 0
				finish = n_dat
				start = 1

				'Проверка на наличие долгов
						if n_dat > 0 then
							for j=start to finish
								if obyaz = false then
									if dat(3,j)= false then
										for i=1 to n_stud
											if (sob(i,j,1) >= 1 and sob(i,j,1) < 6) and dat(3,j)= False then
												pdolg = 1
												exit for
											end if
										next
									else
										pdolg = 1
									end if
								else
									if dat(3,j)= true then
										pdolg = 1
									end if
								end if
								if pdolg = 1 then
									for i=1 to n_stud
										if not stud_id = "all" then
											if student(i, 1) = cint(mid(stud_id, 4)) then
												if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
													kdolg_stud = kdolg_stud + 1
													exit for
												end if
											end if
										else
											if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
												kdolg_stud = kdolg_stud + 1
												exit for
											end if
										end if
									next
								end if
								pdolg = 0
							next
						end if
					'Если есть долги
					if kdolg_stud > 0 then
						kdolg_disc = kdolg_disc + 1
						%>
						<center>
						<h4 style="margin-top: 50px;"><%=disc_value%>. Преподаватель <u><%=prep %></u></h4>
						</center>
						<section class="table_style_minimal">
						<table align="center">
						<tr align=center>
							<th rowspan=2>№</th>
							<th nowrap rowspan=2><b>Фамилия И.О.</b></th>
							<th colspan=<%=kdolg_stud + 1%>><b><%=zan_type_name%></b></th>
							</tr>
							<tr align=center>
							<th align=center>Всего</th>
						<%
						'if output_str = 0 then 
							finish = n_dat
							start = 1
							'start = (count_str - 1) * 18 + 1
						'else
							'finish = output_str * 18
							'if finish > n_dat then finish = n_dat
							'start = (output_str - 1) * 18 + 1
						'end if
						if n_dat > 0 then
							for j = start to finish
								if obyaz = false then
									if dat(3,j)= false then
										for i=1 to n_stud
											if (sob(i,j,1) >= 1 and sob(i,j,1) < 6) and dat(3,j)= False then
												pdolg = 1
												exit for
											end if
										next
									else
										pdolg = 1
									end if
								else
									if dat(3,j)= true then
										pdolg = 1
									end if
								end if
								if pdolg = 1 then
									for i=1 to n_stud
										if not stud_id = "all" then
											if student(i, 1) = cint(mid(stud_id, 4)) then
												if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
													%>
													<th <%if dat(3,j)= True then response.write("bgcolor='lightblue' title = 'Обязательная практическая или контрольная работа' ")%>><%=dat(2,j)%><br /><input type="checkbox" disabled style="display: none;" <%if dat(3,j)= True then response.write("checked")%> /><%if dat(3,j)= True then response.write("<span class='mif-flag'></span>") %></th>
													<%
													exit for
												end if
											end if
										else
											if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
												%>
												<th <%if dat(3,j)= True then response.write("bgcolor='lightblue' title = 'Обязательная практическая или контрольная работа' ")%>><%=dat(2,j)%><br /><input type="checkbox" disabled style="display: none;" <%if dat(3,j)= True then response.write("checked")%> /><%if dat(3,j)= True then response.write("<span class='mif-flag'></span>") %></th>
												<%
												exit for
											end if
										end if
									next
								end if
								pdolg = 0
							next
						end if%>
						</tr>
						
						<!-- Заполнение журнала студентами и оценками -->

						<%
						for i=1 to n_stud
							pdolg = 0
							kdolg = 0
							p = 0
							if n_dat > 0 then
								for j=start to finish
									if obyaz = false then
										if dat(3,j)= false then
											for ii=1 to n_stud
												if (sob(ii,j,1) >= 1 and sob(ii,j,1) < 6) and dat(3,j)= False then
													pdolg = 1
													exit for
												end if
											next
										else
											pdolg = 1
										end if
									else
										if dat(3,j)= true then
											pdolg = 1
										end if
									end if
									if pdolg = 1 then
										if not stud_id = "all" then
											if student(i, 1) = cint(mid(stud_id, 4)) then
												if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8  then
													kdolg = kdolg + 1
												end if
											end if
										else
											if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8  then
												kdolg = kdolg + 1
											end if
										end if
									end if
									pdolg = 0
								next
								for j=start to finish
									if obyaz = false then
										if dat(3,j)= false then
											for ii=1 to n_stud
												if (sob(ii,j,1) >= 1 and sob(ii,j,1) < 6) and dat(3,j)= False then
													pdolg = 1
													exit for
												end if
											next
										else
											pdolg = 1
										end if
									else
										if dat(3,j)= true then
											pdolg = 1
										end if
									end if
									if pdolg = 1 then
										if not stud_id = "all" then
											if student(i, 1) = cint(mid(stud_id, 4)) then
												if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
													p = 1
													exit for
												end if
											end if
										else
											if (sob(i,j,1) >= 0 and sob(i,j,1)<=2.49) or sob(i,j,1) = 6 or sob(i,j,1) = 8 then
												p = 1
												exit for
											end if
										end if
									end if
									pdolg = 0
								next
							end if
							if p = 1 then
							%>
								<tr onmouseover="this.bgColor='lightblue'" onmouseout="this.bgColor='white'">
									<!-- № --> <td align=center><%=i%></td>
									<!-- Фамилия И.О. --> <td nowrap><a href="stud.asp?id_stud=<%=student(i,1)%>" title="<%
									'Средний балл
								for h = 1 to 5
									a = zan_title(i, h, 1)
									b = zan_title(i, h, 2)
									c = "-"
									if a <> "" and a > 0 and b <> "" and b > 0 then 
										if h = 1 then response.write "Теоретические работы: "
										if h = 2 then response.write "Практические работы: "
										if h = 3 then response.write "Тесты: "
										if h = 4 then response.write "Лабораторные работы: "
										if h = 5 then response.write "Самостоятельные работы: "
										c = round(a / b, 2)
										response.write  c  & "&#013;"
									end if
								next
								response.write("Пропущенные часы: " & student(i,3))
							%>" target="_blank"><%=student(i,2)%></a></td>
									
								<td align=center><%=kdolg%></td>

								<%if n_dat > 0 then 
									for j=start to finish%>

									<% 
										title_sob = ""
										title_soba = ""
										if sob (i, j, 7) <> "" then 
											if sob (i, j, 7) = "6" then 
												title_sob = "Предыдущая оценка: 2 нб"
											end if 
											if sob (i, j, 7) = "8" then 
												title_sob = "Предыдущая оценка: 1 нб"
											end if 
											if sob (i, j, 7) = "7" then 
												title_sob = "Предыдущая оценка: зачет"
											end if 
											if sob (i, j, 7) < "6" then 
												title_sob = "Предыдущая оценка: " & sob (i, j, 7)
											end if
										end if	
										if sob (i, j, 8) = True then
												title_soba = "Пропущен 1 час"
										end if
										if sob (i, j, 9) = True then
												title_soba = "Пропущено 2 часа"
										end if
										pdolg = 0
										if obyaz = false then
											if dat(3,j)= false then
												for ii=1 to n_stud
													if (sob(ii,j,1) >= 1 and sob(ii,j,1) < 6) and dat(3,j)= False then
														pdolg = 1
														exit for
													end if
												next
											else
												pdolg = 1
											end if
										else
											if dat(3,j)= true then
												pdolg = 1
											end if
										end if
										if pdolg = 1 then
											for ii=1 to n_stud
												if not stud_id = "all" then
													if student(ii, 1) = cint(mid(stud_id, 4)) then
														if (sob(ii,j,1) >= 0 and sob(ii,j,1)<=2.49) or sob(ii,j,1) = 6 or sob(ii,j,1) = 8 then
										%>
										<td <%if dat(3,j)= True then response.write("bgcolor='lightblue'")%> title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>" align="center">
											
										<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("<font color='red'>") %>
												<b title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>"><%if sob(i,j,1) = 6 then response.Write ("2нб") else if sob(i,j,1) = 7 then response.Write ("зач") else if sob(i,j,1) = 8 then response.Write ("1нб") else if sob(i, j,1) = "" then response.Write ("&nbsp") else response.Write (sob(i,j,1))%></b>
											<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("</font>") %>
										</td>
													<%		exit for
														end if
													end if
												else
													if (sob(ii,j,1) >= 0 and sob(ii,j,1)<=2.49) or sob(ii,j,1) = 6 or sob(ii,j,1) = 8 then
										%>
										<td <%if dat(3,j)= True then response.write("bgcolor='lightblue'")%> title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>" align="center">
										
										<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("<font color='red'>") %>
											<b title="<%=student(i, 2)%> &#013;Дата: <%=dat (2, j)%> &#013;Описание: <%=dat(5 ,j)%>&#013;<%if sob(i,j,3)=True then response.write ("Последнее изменение: ") else response.write ("Автор записи: ")%> <%=sob(i,j,2)%> &#013;Дата записи: <%=sob(i,j,4)%>&#013;<% response.write(title_sob & "&#013;" & title_soba) %> " tabindex="<%=id%>"><%if sob(i,j,1) = 6 then response.Write ("2нб") else if sob(i,j,1) = 7 then response.Write ("зач") else if sob(i,j,1) = 8 then response.Write ("1нб") else if sob(i, j,1) = "" then response.Write ("&nbsp") else response.Write (sob(i,j,1))%></b>
											<%if sob(i,j,1) >= 0 and sob(i,j,1)<=2.5 then response.write("</font>") %>
										</td>
												<%		exit for
													end if
												end if
											next
										end if
										pdolg = 0
									next
								end if%>
							</tr>
						<%
							end if
						next%>
						<%

						if zan_type = 0 then%>
						<tr>
							<td colspan =3><div style='line-height: 1.9;'><b>Теоретическая работа<br>Практическая работа<br>Тест<br>Лабораторная работа<br>Самостоятельная работа</b></div>
							</td>
							<%
								if n_dat>0 then
									for j=start to finish
										pdolg = 0
										if obyaz = false then
											if dat(3,j)= false then
												for i=1 to n_stud
													if (sob(i,j,1) >= 2 and sob(i,j,1) <= 5) and dat(3,j)= False then
														pdolg = 1
														exit for
													end if
												next
											else
												pdolg = 1
											end if
										else
											if dat(3,j)= true then
												pdolg = 1
											end if
										end if
										if pdolg = 1 then
											for ii=1 to n_stud
												if not stud_id = "all" then
													if student(ii, 1) = cint(mid(stud_id, 4)) then
														if (sob(ii,j,1) >= 0 and sob(ii,j,1)<=2.49) or sob(ii,j,1) = 6 or sob(ii,j,1) = 8 then
															old_p_name_type = "zan_type"&j
															response.write "<td align=center>"
															response.write "<input type='hidden' hidden name='old_zan_"& j &"' value='"& dat(8,j) & "'>"
																for h = 1 to 5
																	if h = dat(8,j) then
																		'response.write "<label class='input-control checkbox small-check' style='line-height: 0px; height: 17px; min-height:0px;' title='" & dat(5 ,j) & "'><input type='checkbox' disabled name='"& old_p_name_type &"_"& h &"' checked><span class='check' style='line-height: 0px;'></span></label><br>"
																		if not dat(5 ,j) = "" then
																			response.write("<table cellpadding=0 cellspacing=0 bordercolor=white style='background: radial-gradient(50% 50%, #A7CECC, white); border-radius: 10px; border: 0px; margin: 0px; padding: 0px; cursor: help;'><tr><td style='margin: 0px; padding: 5px; border: 0px;' title='" & dat(5 ,j) & "'><input type='checkbox' style='cursor: help;' title='" & dat(5 ,j) & "' disabled name='"& old_p_name_type &"_"& h &"' checked></td></tr></table>")
																		else
																			response.write "<input type='checkbox' style='margin: 5px;' disabled name='"& old_p_name_type &"_"& h &"' checked><br>"
																		end if
																	else
																		'response.write "<label class='input-control checkbox small-check' style='line-height: 0px; height: 17px; min-height:0px;'><input type='checkbox' disabled name='"& old_p_name_type &"_"& h &"'><span class='check' style='line-height: 0px;'></span></label><br>"
																		response.write "<input type='checkbox' style='margin: 5px;' disabled name='"& old_p_name_type &"_"& h &"'><br>"
																	end if
																next
															response.write "</td>"
															exit for
														end if
													end if
												else
													if (sob(ii,j,1) >= 0 and sob(ii,j,1)<=2.49) or sob(ii,j,1) = 6 or sob(ii,j,1) = 8 then
														old_p_name_type = "zan_type"&j
														response.write "<td align=center>"
														response.write "<input type='hidden' hidden name='old_zan_"& j &"' value='"& dat(8,j) & "'>"
															for h = 1 to 5
																if h = dat(8,j) then
																	'response.write "<label class='input-control checkbox small-check' style='line-height: 0px; height: 17px; min-height:0px;' title='" & dat(5 ,j) & "'><input type='checkbox' disabled name='"& old_p_name_type &"_"& h &"' checked><span class='check' style='line-height: 0px;'></span></label><br>"
																	if not dat(5 ,j) = "" then
																		response.write("<table cellpadding=0 cellspacing=0 bordercolor=white style='background: radial-gradient(50% 50%, #A7CECC, white); border-radius: 10px; border: 0px; margin: 0px; padding: 0px; cursor: help;'><tr><td style='margin: 0px; padding: 5px; border: 0px;' title='" & dat(5 ,j) & "'><input type='checkbox' style='cursor: help;' title='" & dat(5 ,j) & "' disabled name='"& old_p_name_type &"_"& h &"' checked></td></tr></table>")
																	else
																		response.write "<input type='checkbox' style='margin: 5px;' disabled name='"& old_p_name_type &"_"& h &"' checked><br>"
																	end if
																else
																	'response.write "<label class='input-control checkbox small-check' style='line-height: 0px; height: 17px; min-height:0px;'><input type='checkbox' disabled name='"& old_p_name_type &"_"& h &"'><span class='check' style='line-height: 0px;'></span></label><br>"
																	response.write "<input type='checkbox' style='margin: 5px;' disabled name='"& old_p_name_type &"_"& h &"'><br>"
																end if
															next
														response.write "</td>"
														exit for
													end if
												end if
											next
										end if
									next
								end if
							%>
						</tr>
						<%
						end if%>
						</table>
						</section>
						<br>
						<%
				else 'Если нет долгов
				end if
				rs_0_0.MoveNext
			loop
			if kdolg_disc = 0 then
				%>
				<center>
				<img style="padding: 45px 0px 5px 0px" widht=8% src=images/process_succesful.png>
				</center>
				<%
				if obyaz = false then
					if stud_id = "all" then%>
						<p style="padding: 5px 0px 20px 0px">У группы <b><%=session("gr")%></b> задолженностей по типу работы <b>"<%=zan_type_name%>"</b> не имеется.</p>
					<%
					else
						rs_stud.movefirst
						do until rs_stud.EOF
							rs_stud_id = "id_" & rs_stud.fields(1)
							if stud_id = rs_stud_id then
								stud_fio = rs_stud.fields(0)
								exit do
							end if
							rs_stud.MoveNext
						loop
					%>
						<p style="padding: 5px 0px 20px 0px">У студента/курсанта <b><%=stud_fio%></b> группы <b><%=session("gr")%></b> задолженностей по типу работы <b>"<%=zan_type_name%>"</b> не имеется.</p>
					<%
					end if%>
				<%
				else
					if stud_id = "all" then%>
						<p style="padding: 5px 0px 20px 0px">У группы <b><%=session("gr")%></b> задолженностей по обязательным работам типа <b>"<%=zan_type_name%>"</b> не имеется.</p>
					<%
					else
						rs_stud.movefirst
						do until rs_stud.EOF
							rs_stud_id = "id_" & rs_stud.fields(1)
							if stud_id = rs_stud_id then
								stud_fio = rs_stud.fields(0)
								exit do
							end if
							rs_stud.MoveNext
						loop
					%>
						<p style="padding: 5px 0px 20px 0px">У студента/курсанта <b><%=stud_fio%></b> группы <b><%=session("gr")%></b> задолженностей по обязательным работам типа <b>"<%=zan_type_name%>"</b> не имеется.</p>
					<%
					end if%>
				<%
				end if%>
			<%
			end if
		end if
	end if
else 'Если долгов нет
	%>
	<center>
	<img style="padding: 45px 0px 5px 0px" width=8% src=images/process_succesful.png>
	</center>
	<%
	if obyaz = false then
		if stud_id = "all" then%>
			<p style="padding: 5px 0px 20px 0px">У группы <b><%=session("gr")%></b> задолженностей по типу работы <b>"<%=zan_type_name%>"</b> не имеется.</p>
		<%
		else
			rs_stud.movefirst
			do until rs_stud.EOF
				rs_stud_id = "id_" & rs_stud.fields(1)
				if stud_id = rs_stud_id then
					stud_fio = rs_stud.fields(0)
					exit do
				end if
				rs_stud.MoveNext
			loop
		%>
			<p style="padding: 5px 0px 20px 0px">У студента/курсанта <b><%=stud_fio%></b> группы <b><%=session("gr")%></b> задолженностей по типу работы <b>"<%=zan_type_name%>"</b> не имеется.</p>
		<%
		end if%>
	<%
	else
		if stud_id = "all" then%>
			<p style="padding: 5px 0px 20px 0px">У группы <b><%=session("gr")%></b> задолженностей по обязательным работам типа <b>"<%=zan_type_name%>"</b> не имеется.</p>
		<%
		else
			rs_stud.movefirst
			do until rs_stud.EOF
				rs_stud_id = "id_" & rs_stud.fields(1)
				if stud_id = rs_stud_id then
					stud_fio = rs_stud.fields(0)
					exit do
				end if
				rs_stud.MoveNext
			loop
		%>
			<p style="padding: 5px 0px 20px 0px">У студента/курсанта <b><%=stud_fio%></b> группы <b><%=session("gr")%></b> задолженностей по обязательным работам типа <b>"<%=zan_type_name%>"</b> не имеется.</p>
		<%
		end if%>
	<%
	end if%>
<%
end if 'Конец проверки на наличие долгов
else 'Если нет вывода ведомости
	%>
	<p style="text-align: left; margin: 50px 100px 5px 100px; text-indent: 25px;">На данной странице вы можете просматривать задолженности, как каждого учащегося, так и всей группы учебного заведения.</p>
	<p style="text-align: left; margin: 0px 100px 5px 100px; text-indent: 25px;">Для того что бы указать <b>учащегося</b>, выберите из выпадающего списка <i>"Обучающийся"</i> нужного вам студента/курсанта. Что бы вывести ведомость по всем учащимся, из списка выберите - "Все учащиеся".</p>
	<p style="text-align: left; margin: 0px 100px 5px 100px; text-indent: 25px;">Для того что бы указать определённую <b>дисциплину</b>, из выпадающего списка <i>"Дисциплина"</i> выберите нужную вам. Что бы вывести ведомость по всем дисциплинам, из списка выберите - "Все дисциплины".</p>
	<p style="text-align: left; margin: 0px 100px 5px 100px; text-indent: 25px;">Для того что бы вывести ведомость по определённому <b>виду работы</b>, из списка <i>"Вид работы"</i> укажите нужный вам вид.</p>
	<p style="text-align: left; margin: 0px 100px 5px 100px; text-indent: 25px;">Что бы ведомость задолженностей выводилась не только <b>по обязательным работам</b>, уберите галочку в пункте <i>"Обязательные работы"</i>.</p>
	<p style="text-align: left; margin: 0px 100px 25px 100px; text-indent: 25px;">Вы можете вывести ведомость задолженностей <b>в двух формах</b>: вертикальной и горизонтальной. Для этого воспользуйтесь выпадающим списком <i>"Форма отчёта"</i>. Пожалуйста учитывайте, что ведомость задолженностей в вертикальной форме выводится гораздо дольше, нежели в форме горизонтальной.</p>
	<%
end if 'Конец проверки переменной output (разрешения на вывод ведомости)
%>
<!-- Вывод страниц
			<%
			if count_str > 1 then
			%>
<table align=center>
	<tr align=center>
		<td>
			<font size=4>Страница:   </font>
			<%
				for i=1 to count_str
					response.write("<A class='button subinfo' style='padding-top: 10px; padding-bottom: 10px;' href='zadol_po_type.asp?str="& i &"&go=1&disc="&disc_value&"'><b> " & i &" </b></a>   ")
				next
			%>
		</td>
	</tr>
</table>
<br>
			<%
			end if
			%>
-->
					
					<%	
						on error resume next
						Conn.Close
						on error resume next
						RS_0_0.Close
						on error resume next
						RS_0_1.Close
						on error resume next
						RS_0_2.Close
						on error resume next
						RS1.Close
						on error resume next
						RS2.Close
						on error resume next
						RS3.Close
						on error resume next
						RS4.Close
						on error resume next
						RS5.Close
						on error resume next
						RS6.Close
						on error resume next
						RS7.Close
						on error resume next
						RS_prep.Close
						on error resume next
						rs_stud.Close
						Set RS_0_0 = Nothing
						Set RS_0_1 = Nothing
						Set RS_0_2 = Nothing
						Set RS1 = Nothing
						Set RS2 = Nothing
						Set RS3 = Nothing
						Set RS4 = Nothing
						Set RS5 = Nothing
						Set RS6 = Nothing
						Set RS7 = Nothing
						Set RS_prep = Nothing
						Set rs_stud = Nothing
						Set Conn = Nothing
					%>

					<br>
					<a href="disc_change.asp?go=1" class="button subinfo">Вернуться к выбору дисциплин и ведомостей</a>
					<br><a href="group_change.asp?go=1" class="button subinfo">Вернуться к выбору группы</a><br>
					
					<a href="help/03_7.asp" ><button class="button success"><span class="icon mif-info"></span> Помощь </button></a>
					<a href="exit.asp"><button class="button danger " ><span class="icon mif-exit"></span> Выход</button></a>
					<br><br>
					

					© 2009 - <% response.write( Year(now) ) %> Котласское речное училище. Все права защищены.<br><br>
				</center>
			
			</td>
		
		</tr>
	</table>
	<script>
		$("img").mousedown(function(){
		return false;
		});
		hideLoader();
	</script>
	</body>
