using ProjektarbeteSQL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektarbeteSQL.Models
{
    public class Menu
    {
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("*****************************************");
                Console.WriteLine("*   Välj ett av altenativen             *");
                Console.WriteLine("*  1. Se specifik klass                 *");
                Console.WriteLine("*  2. Hämta alla elever                 *");
                Console.WriteLine("*  3. Lägga till ny personal            *");
                Console.WriteLine("*  4. Se alla elever                    *");
                Console.WriteLine("*  5. Aktiva kurser                     *");
                Console.WriteLine("*  6. Se lärare                         *");
                Console.WriteLine("*  7. Avsluta                           *");
                Console.WriteLine("*****************************************");
                Console.Write("Knappa in ditt val : ");
                int option = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (option)
                {
                    case 1:
                        StudClass();
                        break;

                    case 2:
                        StudAll();
                        break;

                    case 3:
                        AddEmplo();
                        break;

                    case 4:
                        Allstud();
                        break;

                    case 5:
                        AllSubjects();
                        break;

                    case 6:
                        AllEmplo();
                        break;

                    case 7:
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
        public void StudClass()
        {

            using (var sc = new SchoolContext())
            {
                var stud = from c in sc.Classes
                           select c;
                foreach (var it in stud)
                {
                    Console.WriteLine($"Klassnamn:{it.Class1} Klassid:{it.ClassId}");
                }
                Console.WriteLine("Skriv in klassid från vilken klass du vill se. skriv exempelvis 601.");
                int option = int.Parse(Console.ReadLine());
                Console.WriteLine("**********************************************************");

                var stud2 = from s in sc.Students
                            join c in sc.Classes on s.FkClassId equals c.ClassId
                            where c.ClassId == option
                            select new
                            {
                                c.ClassId,
                                c.Class1,
                                s.Fname,
                                s.Lname
                            };

                foreach (var it in stud2)
                {
                    Console.WriteLine($"klassid:{it.ClassId} klassnamn:{it.Class1} Förnamn:{it.Fname} Efternamn:{it.Lname}");
                }
                Console.WriteLine("********************************************************");
                Console.WriteLine("Tryck Enter för att återvända till menyn");
                Console.ReadKey();
                Console.Clear();

            }

        }


        public void StudAll()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("*   Välj ett av altenativen               *");
            Console.WriteLine("*  1. Se eleverna sorterade på förnamn    *");
            Console.WriteLine("*  2. Se eleverna sorterade på efternamn  *");
            Console.WriteLine("*******************************************");
            Console.Write("Knappa in ditt val : ");
            int input = int.Parse(Console.ReadLine());
            Console.Clear();

            if (input == 1)
            {
                Console.WriteLine("*Välj ett av Alternativen*");
                Console.WriteLine("1. Sortera förnamnet i stigande ordning");
                Console.WriteLine("2. Sortera förnamnet i fallande ordning");
                int anwser = int.Parse(Console.ReadLine());
                if (anwser == 1)
                {
                    using (var sc = new SchoolContext())
                    {
                        var AllStud = from a in sc.Students orderby a.Fname select a;
                        Console.WriteLine("");
                        foreach (var it in AllStud)
                        {
                            Console.WriteLine($"klassid:{it.Class} Personnr:{it.Ssn} Förnamn:{it.Fname} Efternamn:{it.Lname}");

                        }
                    }
                    Console.WriteLine("Tryck Enter för att återvända till menyn");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (anwser == 2)
                {
                    using (var sc = new SchoolContext())
                    {
                        var AllStud = from a in sc.Students.OrderByDescending(a => a.Fname) select a;
                        Console.WriteLine("");
                        foreach (var it in AllStud)
                        {

                            Console.WriteLine($"klassid:{it.Class} Personnr:{it.Ssn} Förnamn:{it.Fname} Efternamn:{it.Lname}");
                        }
                    }
                    Console.WriteLine("Tryck Enter för att återvända till menyn");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else if (input == 2)
            {
                Console.WriteLine("*Välj ett av Alternativen*");
                Console.WriteLine("1. Sortera efternamnet i stigande ordning");
                Console.WriteLine("2. Sortera efternamnet i fallande ordning");
                int anwser = int.Parse(Console.ReadLine());
                if (anwser == 1)
                {
                    using (var sc = new SchoolContext())
                    {
                        var AllStud = from a in sc.Students orderby a.Lname select a;
                        Console.WriteLine("");
                        foreach (var it in AllStud)
                        {
                            Console.WriteLine($"klassid:{it.Class} Personnr:{it.Ssn} Förnamn:{it.Fname} Efternamn:{it.Lname}");

                        }
                    }
                    Console.WriteLine("Tryck Enter för att återvända till menyn");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (anwser == 2)
                {
                    using (var sc = new SchoolContext())
                    {
                        var AllStud = from a in sc.Students.OrderByDescending(a => a.Fname) select a;
                        Console.WriteLine("");
                        foreach (var it in AllStud)
                        {

                            Console.WriteLine($"klassid:{it.Class} Personnr:{it.Ssn} Förnamn:{it.Fname} Efternamn:{it.Lname}");
                        }
                    }
                    Console.WriteLine("Tryck Enter för att återvända till menyn");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

        }
        public void AddEmplo()
        {
            using SchoolContext context = new SchoolContext();
            EmploAdmin e1 = new EmploAdmin();
            Console.Write("Förnamn : ");
            e1.Fname = Console.ReadLine();
            Console.Write("Efternamn : ");
            e1.Lname = Console.ReadLine();
            Console.Write("Arbets titel : ");
            e1.Position = Console.ReadLine();
            context.EmploAdmins.Add(e1);
            context.SaveChanges();
            Console.WriteLine("Databasen är uppdaterad");
            Console.WriteLine("Tryck Enter för att återvända till menyn");
            Console.ReadKey();
            Console.Clear();
        }

        public void Allstud()
        {
            using (var sc = new SchoolContext())
            {
                var stud2 = from s in sc.Students
                            join c in sc.Classes on s.FkClassId equals c.ClassId
                            select new
                            {
                                c.ClassId,
                                c.Class1,
                                s.Fname,
                                s.Lname
                            };

                Console.WriteLine("");
                foreach (var it in stud2)
                {
                    Console.WriteLine($"klassid:{it.ClassId} klassnamn:{it.Class1} Förnamn:{it.Fname} Efternamn:{it.Lname}");
                }
                Console.WriteLine("********************************************************");
                Console.WriteLine("Tryck Enter för att återvända till menyn");
                Console.ReadKey();
                Console.Clear();
            }

        }

        public void AllSubjects()
        {
            using (var sc = new SchoolContext())
            {
                var stud2 = from e in sc.EmploTeachers
                            select new
                            {
                                e.Subject,
                            };

                Console.WriteLine("Aktiva Kurser");
                Console.WriteLine("********************************************************");
                foreach (var it in stud2)
                {
                    Console.WriteLine($"{it.Subject}");
                }
                Console.WriteLine("********************************************************");
                Console.WriteLine("Tryck Enter för att återvända till menyn");
                Console.ReadKey();
                Console.Clear();
            }

        }
        public void AllEmplo()
        {
            using (var sc = new SchoolContext())
            {
                var emplo = from c in sc.EmploTeachers
                            select c;
                foreach (var it in emplo)
                {
                    Console.WriteLine($"{it.Subject}");
                }
                Console.WriteLine("Skriv in vilken typ av lärare du vill se. emempel Physics");
                string option = (Console.ReadLine());
                Console.WriteLine("***********************************************************************************************************");

                var emplo2 = from s in sc.EmploTeachers
                             where s.Subject == option
                             select new
                             {
                                 s.TeacherId,
                                 s.Subject,
                                 s.Fname,
                                 s.Lname,
                                 s.EmploymentDate,
                                 s.Salary,
                             };

                foreach (var it in emplo2)
                {
                    Console.WriteLine($"Anställningsid:{it.TeacherId} Lärare inom ämne:{it.Subject} Förnamn:{it.Fname} Efternamn:{it.Lname} Anställd:{it.Salary} Lön:{it.Salary}");
                }
                Console.WriteLine("***********************************************************************************************************");
                Console.WriteLine("Tryck Enter för att återvända till menyn");
                Console.ReadKey();
                Console.Clear();

            }
        }
    }
}
