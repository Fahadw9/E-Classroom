--Or rename this to your database name
create database classroom
go
use classroom
go

--DDL Script
CREATE TABLE student
  (
     --roll_no    INT PRIMARY KEY AUTO_INCREMENT, --every time a unique primary key will be generated, no need for this
     [name]      VARCHAR(25) NOT NULL,
     email 	varchar(30) PRIMARY KEY,
     age        INT,
     address    VARCHAR(50),
     contact_no VARCHAR(11),
     password   VARCHAR(20),
     Check(age>=10 AND age <= 70)
  )
  go

  CREATE TABLE teacher
  (
     --id         INT PRIMARY KEY AUTO_INCREMENT, --no need for this
     email 	varchar(30) PRIMARY KEY, --could be second primary key
     [name]      VARCHAR(25) NOT NULL,
     age        INT,
     address    VARCHAR(50),
     contact_no VARCHAR(11),
     password   NVARCHAR(20),
     Check(age>=25 AND age <= 80)
  )
  go

  CREATE TABLE grade
  (
     studentemail varchar(30) FOREIGN KEY REFERENCES student(email),
     course    VARCHAR(25) FOREIGN KEY REFERENCES courses(course_name),
     lettergrade   NCHAR(1),
     PRIMARY KEY (studentemail, course),
     Check(lettergrade >='A' AND lettergrade<='F')
  )
  go

  CREATE TABLE courses
  (
     course_name VARCHAR(25) Primary key,
	 teacher VARCHAR(30) FOREIGN KEY REFERENCES teacher([email])
  )
  go

  CREATE TABLE assesment --removes the need for multiple tables
  (
     id	INT,
     email varchar(30) FOREIGN KEY REFERENCES student(email),
     course  VARCHAR(25) REFERENCES courses(course_name),
     assesment_type varchar(15) NOT NULL,
	 assesment_name varchar(30),
     taken_date DATE,
     marks      INT,
	total INT,
	PRIMARY KEY(id,course,email,assesment_type),
	Check(assesment_type = 'quiz' OR assesment_type = 'homework' OR assesment_type= 'assignment'),
	CHECK(marks >= 0 AND marks <=total),
	CHECK(total >=0 ),
  )
  go

  CREATE TABLE enrollment
  (
     course_name  varchar(25) FOREIGN KEY REFERENCES courses(course_name),
     s_email   varchar(30),
	 t_email varchar(30),
     PRIMARY KEY(course_name, s_email, t_email)
  )
  go

  CREATE TABLE attendance
  (
     attendance_date varchar(20) not null,
     course     varchar(25) REFERENCES courses(course_name),
     s_email         varchar(30) REFERENCES student(email),
     classattendance NCHAR(1) not null,
     PRIMARY KEY(attendance_date, course, s_email),
     Check(classattendance = 'A' OR classattendance = 'P')
  )
  go

  CREATE TABLE helpingmaterial
  (
     materialid   INT,
     materialtype VARCHAR(30),
     materialname VARCHAR(30),
     --course_id    INT REFERENCES courses(id),
	 course_name VARCHAR(25) References courses(course_name),
	 ref_link VARCHAR(50),
	 Primary key(materialid, materialtype,course_name),
     Check(materialtype = 'book' OR materialtype = 'practice' OR materialtype = 'notes')
  )
  go

--DML Script
  insert into student values ('ali','ali@gmail',20,'Lahore','03097411851','sa')
  insert into student values ('ahmad','ahmad@gmail',18,'Lahore','03211234567','sa')
  insert into student values ('fahad','fahad@gmail',18,'Lahore','03021234567','sa')
  --delete from student where email='fahad'
  go

  insert into teacher values ('Ahsan@example.com','mike',29,'xstreet'	,'03211234567','sa')
  insert into teacher values ('Akbar@example.com','mike',29,'xstreet'	,'03211234567','sa')
  insert into teacher values ('fahad@example.com','mike',29,'xstreet'	,'03211234567','sa')
  insert into teacher values ('Art@example.com','mike',29,'xstreet'	,'03211234567','sa')
  insert into teacher values ('Mustafa@example.com','mike',29,'xstreet'	,'03211234567','sa')
  go

  Insert into courses VALUES('Programming Fundamentals', 'Ahsan@example.com');
  Insert into courses VALUES('Calculus 1', 'Akbar@example.com');
  Insert into courses VALUES('Physics', 'fahad@example.com');
  Insert into courses VALUES('ICT','Art@example.com');
  Insert into courses VALUES('Pakistan Studies', 'Mustafa@example.com');
  go

  insert into assesment values(1, 'ahmad@gmail', 'Calculus 1', 'assignment','assignment-1','2/2/22',10,20)
  insert into assesment values(1, 'ali@gmail', 'Calculus 1', 'assignment','assignment-1','2/2/22',19,20)
  insert into assesment values(1, 'fahad@gmail', 'Calculus 1', 'assignment','assignment-1','2/2/22',19,20)

  insert into assesment values(2, 'ali@gmail', 'Calculus 1', 'assignment','assignment-2','4/15/22',18,30)
  insert into assesment values(2, 'fahad@gmail', 'Calculus 1', 'assignment','assignment-2','4/15/22',12,30)

  insert into assesment values(3, 'ali@gmail', 'ICT', 'assignment','assignment-3','5/5/22',10,10)
  insert into assesment values(4, 'ahmad@gmail', 'ICT', 'assignment','assignment-4','6/11/22',8,10)
  go

  insert into enrollment values ('Calculus 1', 'fahad@gmail', 'Art@example.com')
  insert into enrollment values ('Calculus 1', 'ali@gmail', 'Art@example.com')
  insert into enrollment values ('ICT', 'ahmad@gmail', 'Art@example.com')
  go

  insert into attendance values ('2022-05-27', 'Calculus 1', 'fahad@gmail', 'P')
  go

  insert into helpingmaterial values (1,'book','Basic Programming','Programming Fundamentals','site.com')
  insert into helpingmaterial values (2,'book','Intro to Programming','Programming Fundamentals','www.books.com')
  insert into helpingmaterial values (1,'practice','Exception Handling','Programming Fundamentals','Attempt Hw Problems')
  insert into helpingmaterial values (2,'practice','Conditional Statements','Programming Fundamentals','Attempt last 4 questions Ex 2.8')
  insert into helpingmaterial values (3,'practice','Review Exercise','Programming Fundamentals','Attempt first 10 questions Review 2')
  insert into helpingmaterial values (1,'notes','Lecture-1','Programming Fundamentals','lectures.org')
  insert into helpingmaterial values (2,'notes','Lecture-2','Programming Fundamentals','lectures.org')
  insert into helpingmaterial values (1,'book','Cal-I Recommended','Calculus 1','site.com')
  insert into helpingmaterial values (2,'book','Book2','Calculus 1','www.books.com')
  insert into helpingmaterial values (3,'book','Diff Equations','Calculus 1','https:\\maths.com')
  insert into helpingmaterial values (1,'practice','Heat Equation','Calculus 1','Attempt any one long question')
  insert into helpingmaterial values (2,'practice','Integration','Calculus 1','Practice given homework')
  insert into helpingmaterial values (3,'practice','Partial derivate','Calculus 1','Follow the link: practice.org')
  insert into helpingmaterial values (3,'notes','Lecture-3','Calculus 1','www.link3.com')
  insert into helpingmaterial values (1,'book','Electromagnetism','Physics','physicist.org')
  insert into helpingmaterial values (2,'book','Recommended Book','Physics','www.books.com')
  insert into helpingmaterial values (3,'book','Good Algorithms','Physics','https:\\sci.com')
  insert into helpingmaterial values (1,'practice','Inertia','Physics','Practice Hw-5')
  insert into helpingmaterial values (2,'practice','Gravity','Physics','Attempt last 4 questions Recommended Book')
  insert into helpingmaterial values (2,'notes','Lecture-2','Physics','www.notes.com')
  insert into helpingmaterial values (1,'book','Murder of History','Pakistan Studies','history.org')
  insert into helpingmaterial values (2,'book','Mera Mulk','Pakistan Studies','www.books.com')
  insert into helpingmaterial values (5,'notes','Lecture-5','Pakistan Studies','www.notes.com')
  insert into helpingmaterial values (1,'book','Book1','ICT','www.IntrotoIct.com')
  insert into helpingmaterial values (2,'book','Book2','ICT','www.books.com')
  insert into helpingmaterial values (1,'practice','Round Robin','ICT','practice.org')
  go

  --SELECT * FROM assesment
  --SELECT * FROM attendance
  --SELECT * FROM courses
  --SELECT * FROM enrollment
  --SELECT * FROM helpingmaterial
  --SELECT * FROM student
  --SELECT * FROM teacher
  --go

-- Views, Procedures and Triggers

  create view assignment
  as
  select id,email,course,assesment_name,taken_date, marks, total from assesment where assesment_type='assignment'
  go

  create view quiz
  as
  select id,email,course,assesment_name,taken_date, marks, total from assesment where assesment_type='quiz'
  go

  create view homework
  as
  select id,email,course,assesment_name,taken_date, marks, total from assesment where assesment_type='homework'
  go

  create view allstudents
  as
  Select * From student
  go
	
  create view allteachers
  as 
  Select * From teacher
  go

create procedure StudentSignUp
@email varchar(30),
@name varchar(25),
@password varchar(30),
@age int, 
@address varchar(50),
@contact_no varchar(11)
as
begin
DECLARE @check varchar(20) = null;
set @check = (Select q.email From 
(Select * 
From  allteachers
Where email = @email) as q)
if (@check = @email)
begin
print('This email already exists'); --or we can release a trigger here
end
else
begin
insert into allstudents Values(@name, @email, @age, @address, @contact_no, @password) --change according to the table
print('Sign up successful')
end
end
go

create procedure TeacherSignUp
@name varchar(25),
@email varchar(30),
@password varchar(30),
@age int, 
@address varchar(50),
@contact_no varchar(11)
as
begin
DECLARE @check varchar(20) = null;
set @check = (Select q.email From 
(Select * 
From  allteachers
Where email = @email) as q)
if (@check = @email)
begin
print('This email already exists'); --or we can release a trigger here
end
else
begin
insert into allteachers([NAME], email, age, [address], contact_no, [password]) Values(@name, @email, @age, @address, @contact_no, @password) --change according to the table
print('Sign up successful')
end
end
go

CREATE PROCEDURE TeacherLogin
@email varchar(30),
@password varchar(30)
as
BEGIN
DECLARE @check varchar(20) = null;
set @check = (Select q.email From 
(Select * 
From  allteachers
Where email = @email) as q)
If (@check = null)
Begin
print('This email does not exist'); --or we can release a trigger here
End
Else
Begin
Set @check = (Select q.[password] From 
(Select * 
From  allteachers
Where email = @email) as q)
If(@password = @check)
begin
print('Password is correct, logged in successfully')
end
else
begin
print('Incorrect password and/or email, try again')
end
end
end
go

CREATE PROCEDURE StudentLogin
@email varchar(30),
@password varchar(30)
as
BEGIN
DECLARE @check varchar(20) = null;
set @check = (Select q.email From 
(Select * 
From  allstudents
Where email = @email) as q)
If (@check = null)
Begin
print('This email does not exist'); --or we can release a trigger here
End
Else
Begin
Set @check = (Select q.[password] From 
(Select * 
From  allstudents
Where email = @email) as q)
If(@password = @check)
begin
print('Password is correct, logged in successfully')
end
else
begin
print('Incorrect password and/or email, try again')
end
end
end
go

Create procedure Add_Material
@materialid int,
@materialtype VARCHAR(30),
@materialname VARCHAR(30),
@course_name VARCHAR(25),
@ref_link VARCHAR(50)
as
begin
insert
into helpingmaterial
values
(@materialid, @materialtype, @materialname, @course_name, @ref_link)
end
go

Create procedure Remove_Material
@materialid int,
@materialtype VARCHAR(30),
@course_name VARCHAR(25)
as
begin
delete
from helpingmaterial
where
materialid=@materialid and materialtype=@materialtype and course_name=@course_name
end
go

Create procedure Add_Assignment
@id int,
@email VARCHAR(30),
@course VARCHAR(25),
@assesment_type VARCHAR(15),
@assesment_name VARCHAR(30),
@taken_date DATE,
@marks	INT,
@total INT
as
begin
insert
into assesment
values
(@id, @email, @course, @assesment_type, @assesment_name, @taken_date, @marks, @total)
end
go

Create procedure Remove_Assignment
@id int,
@email VARCHAR(30),
@course VARCHAR(25)
as
begin
delete
from assesment
where
id=@id and email =@email and course= @course and assesment_type = 'assignment'
end
go

Create procedure Add_Quiz
@id int,
@email VARCHAR(30),
@course VARCHAR(25),
@assesment_type VARCHAR(15),
@assesment_name VARCHAR(30),
@taken_date DATE,
@marks	INT,
@total INT
as
begin
insert
into assesment
values
(@id, @email, @course, @assesment_type, @assesment_name, @taken_date, @marks, @total)
end
go

Create procedure Remove_Quiz
@id int,
@email VARCHAR(30),
@course VARCHAR(25)
as
begin
delete
from assesment
where
id=@id and email =@email and course= @course and assesment_type = 'quiz'
end
go

Create procedure Add_Hw
@id int,
@email VARCHAR(30),
@course VARCHAR(25),
@assesment_type VARCHAR(15),
@assesment_name VARCHAR(30),
@taken_date DATE,
@marks	INT,
@total INT
as
begin
insert
into assesment
values
(@id, @email, @course, @assesment_type, @assesment_name, @taken_date, @marks, @total)
end
go

Create procedure Remove_Hw
@id int,
@email VARCHAR(30),
@course VARCHAR(25)
as
begin
delete
from assesment
where
id=@id and email =@email and course= @course and assesment_type = 'homework'
end
go

Create procedure Student_View_Profile
@email varchar(30)
as
begin
Select *
From allstudents
Where allstudents.email = @email
end
go

--Teacher profile viewing
Create procedure Teacher_View_Profile
@email varchar(30)
as
begin
Select *
From allteachers
Where allteachers.email = @email
end
go

Create procedure Update_Student_Profile
@email varchar(30), 
@name varchar(20),
@age int,
@address varchar(50),
@contact_no varchar(11),
@password varchar(20)
as
begin
update student
set
[Name] = @name, 
age = @age,
[address] = @address,
contact_no = @contact_no,
[password] = @password
where email = @email
end
go

Create trigger update_success_student on student after update as begin print('Data Updated Successfully') end
go

Create procedure Update_Teacher_Profile
@email varchar(30), 
@name varchar(20),
@age int,
@address varchar(50),
@contact_no varchar(11),
@password varchar(20)
as
begin
update teacher
set
[Name] = @name, 
age = @age,
[address] = @address,
contact_no = @contact_no,
[password] = @password
where email = @email
end
go

Create trigger update_success_teacher on teacher after update as begin print('Data Updated Successfully') end
go

create procedure attendancechk
@attendance_date DATE,
@courseid int,
@rollno int,
@value nchar(1),
@check int = null
as
begin
set @check = (Select @courseid From Course Where courseid = @courseid)
if(@check = null)
begin
print('Invalid courseid')
end
else
begin
set @check = (Select email From allstudents Where  email = @rollno)
if(@check = null)
begin
print('Invalid rollno')
end
else
begin
insert into attendance values(@attendance_date, @courseid, @rollno, @value)
end
end
end
go

create procedure course_finding
@email varchar(30),
@course_name varchar(25)
as 
begin
Select*
From enrollment
Where s_email = @email AND course_name = @course_name
end
go

create procedure course_registration
@email varchar(30),
@course_name varchar(25),
@t_email varchar(30)
as 
begin
Insert into enrollment Values(@course_name, @email, @t_email);
end
go

create procedure add_quiz
@id int, --we will add auto attribute to it
@rollno int,
@course_id int,
@assesmentname varchar(30),
@taken_date Date,
@marks int,
@total int,
@check int = null
as
begin
set @check = (Select courseid From Course Where @course_id = course_id)
if(@check = null)
begin
print('This course is invalid')
end
else
begin
set @check = (Select email From Student Where @rollno = email)
if(@check = null)
begin
print('This student is invalid')
end
else
begin
Insert into Quiz Values(@id, @rollno, @course_id, @assesmentname, @taken_date, @marks, @total)
end
end
end
go

create procedure add_assignment
@id int, --we will add auto attribute to it
@rollno int,
@course_id int,
@assessmentname varchar(30),
@taken_date Date,
@marks int,
@total int,
@check int = null
as
begin
set @check = (Select courseid From Course Where @course_id = course_id)
if(@check = null)
begin
print('This course is invalid')
end
else
begin
set @check = (Select email From Student Where @rollno = email)
if(@check = null)
begin
print('This student is invalid')
end
else
begin
Insert into Assignment Values(@id, @rollno, @course_id, @assessmentname, @taken_date, @marks, @total)
end
end
end
go

create procedure add_homework
@id int, --we will add auto attribute to it
@rollno int,
@course_id int,
@assessmentname varchar(30),
@taken_date Date,
@marks int,
@total int,
@check int = null
as
begin
set @check = (Select courseid From Course Where @course_id = course_id)
if(@check = null)
begin
print('This course is invalid')
end
else
begin
set @check = (Select email From Student Where @rollno = email)
if(@check = null)
begin
print('This student is invalid')
end
else
begin
Insert into homework Values(@id, @rollno, @course_id, @assessmentname, @taken_date, @marks, @total)
end
end
end
go
