--get all students from the state of Colorado and sort them by City
select *
From Student
order by City

-- get a class list that shows what courses each student is in
--a.	Include student Id, student name, class id and class description
--b.	Sort them by student name

select Student.StudentId, Name, Class.ClassId, Description
From StudentClass inner join Student 
on StudentClass.StudentId = Student.StudentId
inner join Class on StudentClass.ClassId = Class.ClassId
order by Name
 



--Insert a new student, filling in all columns
Insert into Student (StudentId, Name, Address, City, State, ZipCode)
Values(50, 'Michael', '123 Pitkin St', 'Fort Collins', 'CO', 80526)

--Register the new student for the Art History course
Insert into StudentClass(StudentId, ClassId)
Values(50, 324)

--Update the student called Betty to live in San Diego CA
Update Student
set City = 'San Diego', State = 'CA'
where Name = 'Betty'

--Delete the student you inserted
Delete from Student
where StudentId = 50
