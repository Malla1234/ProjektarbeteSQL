using ProjektarbeteSQL.Data;
using ProjektarbeteSQL.Models;
using System.Net.Sockets;
using System.Runtime.Intrinsics.X86;

namespace ProjektarbeteSQL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Start();

            using SchoolContext db = new SchoolContext();
        }
    }
}

/*---Skolan vill kunna ta fram en översikt över all personal där det framgår namn och vilka befattningar de har samt hur många år de har arbetat på skolan.
Select a.Position, a.Fname, a.Lname, a.EmploymentDate
From EmploAdmin a
union all
Select o.Position, o.Fname, o.Lname, o.EmploymentDate
From EmploOther o
union all
Select t.Subject, t.Fname, t.Lname, t.EmploymentDate
From EmploTeacher t
 
---Lägga till anställd
INSERT INTO EmploAdmin
(AdminId, Position, Fname, Lname, EmploymentDate)
VALUES
(109, 'Advisor', 'Nils', 'Lindblom', '2023-01-02')

--Lägga till elever
INSERT INTO Student
(StudId, SSN, Fname, Lname, FK_ClassId, Class)
VALUES
(7, '20080513-4724', 'Ronja', 'Lindblom', 601, '3A')

--Se vilken klass studentarena går i
SELECT s.SSN, s.Fname, s.Lname, c.Class
FROM Student s
Join Class c on s.FK_ClassId = c.ClassId

-- Lägga till nytt betyg
INSERT INTO Grade
(GradeId, Date, Subject, Grade, FK_TeacherId, FK_StudId)
VALUES
(508, '2023-01-02', 'Chemistry', '2', 123, 1)

-- Se vilken lärare som satt betyg 
SELECT e.Fname, e.Lname, e.Subject, g.Grade, g.Date
FROM EmploTeacher e
Join Grade g on e.TeacherId = g.FK_TeacherId
Where e.Subject = 'Chemistry'
----------------------------------
-- Hur mycket betalar respektive avdelning ut varje månad
SELECT SUM(Salary) as 'Avd Admin'
FROM EmploAdmin;
--Avd Other
SELECT SUM(Salary) as 'Avd Other '
FROM EmploOther
--- Avd Teatcher
SELECT SUM(Salary) as 'Avd Teachers'
FROM EmploTeacher;

--Hur mycket betalar respektive avdelning ut varje månad ännu mer detaljerad/ingående.
--Avd Admin 
Select Position, max(Salary)' Högsta lönen', min(Salary)'Lägsta lönen', Sum(Salary)'Totalt för alla' 
From EmploAdmin
Group By Position
-- Avd Other
Select Position, max(Salary)' Högsta lönen', min(Salary)'Lägsta lönen', Sum(Salary)'Totalt för alla' 
From EmploOther
Group By Position
-- Avd Teatcher
Select Subject, max(Salary)' Högsta lönen', min(Salary)'Lägsta lönen', Sum(Salary)'Totalt för alla' 
From EmploTeacher
Group By Subject
---Hur mycket är medellönen för de olika avdelningarna.
Select Position, max(Salary)' Högsta', min(Salary)'Lägsta', avg(Salary)'Medellönen' 
From EmploAdmin
Group By Position
-- Avd Other
Select Position, max(Salary)' Högsta', min(Salary)'Lägsta', avg(Salary)'Medellönen' 
From EmploOther
Group By Position
-- Avd Teatcher
Select Subject, max(Salary)' Högsta', min(Salary)'Lägsta', avg(Salary)'Medellönen' 
From EmploTeacher
Group By Subject
-- Eller bara 
SELECT avg(Salary) as 'Avd Admin'
FROM EmploAdmin;
--Avd other
SELECT avg(Salary) as 'Avd Other '
FROM EmploOther
--- Avd Teatcher
SELECT avg(Salary) as 'Avd Teachers'
FROM EmploTeacher;

---Skapa en Stored Procedure som tar emot ett Id och returnerar viktig information om den elev som är registrerad med aktuellt id.
Create Procedure SP_Student_Id @StudId int
As
Select * From Student
Where StudId=@StudId
-- Hämta informationen
exec SP_Student_Id @StudId=4

---Sätt betyg på en elev genom att använda Transactions ifall något går fel.
Select * from Grade

begin transaction
update Grade
set Grade='3' where FK_StudId=3
and Subject ='Mathematics'

---Ångra
rollback transaction
---Spara permanent 
commit transaction*/