// This class contains Problems 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 and 12
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;
class ClassStudent
{
    static List<Student> studentsList = new List<Student>();
    static void Main()
    {
        P01(); // Problem 1. Class Student  (creates the list of students for all following problems, DO NOT COMMENT OUT)
        //P02(); // Problem 2. Students by Group
        //P03(); // Problem 3. Students by First and Last Name
        //P04(); // Problem 4. Students by Age
        //P05(); // Problem 5. Sort Students
        //P06(); // Problem 6. Filter Students by Email Domain
        //P07(); // Problem 7. Filter Students by Phone
        //P08(); // Problem 8. Excellent Students
        //P09(); // Problem 9. Weak Students
        //P10(); // Problem 10. Students Enrolled in 2014
        //P11(); // Problem 11. * Students by Groups
        //P12(); // Problem 12. * Students Joined to Specialties
    }
    static void P01()
    {
        // 01. Class Student (10 sample students, click on the + to expand)
        Student student1 = new Student();
        student1.FirstName = "Hristo";
        student1.LastName = "Ivanov";
        student1.Age = 22;
        student1.FacultyNumber = "123414";
        student1.Phone = "0881234567";
        student1.Email = "hrivanov@abv.bg";
        student1.Marks = new List<int>() { 5, 6, 6, 5, 5 };
        student1.GroupNumber = 2;
        student1.GroupName = "Alpha";
        studentsList.Add(student1);

        Student student2 = new Student();
        student2.FirstName = "Petar";
        student2.LastName = "Ivanov";
        student2.Age = 25;
        student2.FacultyNumber = "123656";
        student2.Phone = "0286234567";
        student2.Email = "petarivanov@abv.bg";
        student2.Marks = new List<int>() { 3, 2, 4, 2, 5 };
        student2.GroupNumber = 1;
        student2.GroupName = "Omega";
        studentsList.Add(student2);

        Student student3 = new Student();
        student3.FirstName = "Ivan";
        student3.LastName = "Draganov";
        student3.Age = 32;
        student3.FacultyNumber = "129813";
        student3.Phone = "+3592365267";
        student3.Email = "ivandraganov@mail.ru";
        student3.Marks = new List<int>() { 4, 3, 4, 5, 4 };
        student3.GroupNumber = 2;
        student3.GroupName = "Beta";
        studentsList.Add(student3);

        Student student4 = new Student();
        student4.FirstName = "Petkan";
        student4.LastName = "Iliev";
        student4.Age = 28;
        student4.FacultyNumber = "111814";
        student4.Phone = "0881265337";
        student4.Email = "petkaniliev@abv.bg";
        student4.Marks = new List<int>() { 4, 4, 4, 4, 4 };
        student4.GroupNumber = 3;
        student4.GroupName = "Beta";
        studentsList.Add(student4);

        Student student5 = new Student();
        student5.FirstName = "Nashmat";
        student5.LastName = "Golemanov";
        student5.Age = 21;
        student5.FacultyNumber = "125536";
        student5.Phone = "0881265666";
        student5.Email = "nashmatgolemanov@abv.bg";
        student5.Marks = new List<int>() { 2, 3, 2, 4, 4 };
        student5.GroupNumber = 1;
        student5.GroupName = "Omega";
        studentsList.Add(student5);

        Student student6 = new Student();
        student6.FirstName = "Goran";
        student6.LastName = "Sariev";
        student6.Age = 18;
        student6.FacultyNumber = "122214";
        student6.Phone = "+359 2555267";
        student6.Email = "goransariev@mail.bg";
        student6.Marks = new List<int>() { 4, 2, 4, 3, 4 };
        student6.GroupNumber = 3;
        student6.GroupName = "Omega";
        studentsList.Add(student6);

        Student student7 = new Student();
        student7.FirstName = "Georgi";
        student7.LastName = "Georgiev";
        student7.Age = 20;
        student7.FacultyNumber = "111113";
        student7.Phone = "0881115267";
        student7.Email = "gogo@yahoo.com";
        student7.Marks = new List<int>() { 2, 5, 3, 4, 2 };
        student7.GroupNumber = 2;
        student7.GroupName = "Omega";
        studentsList.Add(student7);

        Student student8 = new Student();
        student8.FirstName = "Emil";
        student8.LastName = "Petkov";
        student8.Age = 19;
        student8.FacultyNumber = "121116";
        student8.Phone = "+3591115227";
        student8.Email = "empopetkov@abv.bg";
        student8.Marks = new List<int>() { 3, 2, 4, 5, 2 };
        student8.GroupNumber = 1;
        student8.GroupName = "Omega";
        studentsList.Add(student8);

        Student student9 = new Student();
        student9.FirstName = "Ivo";
        student9.LastName = "Papazov";
        student9.Age = 23;
        student9.FacultyNumber = "113314";
        student9.Phone = "0881133267";
        student9.Email = "ivowe@gmail.com";
        student9.Marks = new List<int>() { 4, 5, 4, 5, 4 };
        student9.GroupNumber = 3;
        student9.GroupName = "Beta";
        studentsList.Add(student9);

        Student student10 = new Student();
        student10.FirstName = "Onufri";
        student10.LastName = "Gagarin";
        student10.Age = 25;
        student10.FacultyNumber = "110156";
        student10.Phone = "0881110067";
        student10.Email = "spacemf@abv.bg";
        student10.Marks = new List<int>() { 6, 6, 4, 5, 6 };
        student10.GroupNumber = 2;
        student10.GroupName = "Alpha";
        studentsList.Add(student10);
    }
    static void P02()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Problem 2: Students by Group:");
        Console.WriteLine(new string('-', 30));
        var orderedByFirstName = from stud in studentsList
                                 where stud.GroupNumber == 2
                                 select stud;
        foreach (var student in orderedByFirstName)
        {
            Console.WriteLine("{0} {1} - Group {2}", student.FirstName, student.LastName, student.GroupNumber);
        } 
    }
    static void P03()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Problem 3: Students by First and Last Name:");
        Console.WriteLine(new string('-', 30));
        var alphabeticFirstBeforeLastName = from stud in studentsList
                                            where string.Compare(stud.FirstName, stud.LastName) == -1
                                            select stud;
        foreach (var student in alphabeticFirstBeforeLastName)
        {
            Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
        }  
    }
    static void P04()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Problem 4: Students by Age:");
        Console.WriteLine(new string('-', 30));
        var studentsByAge = from stud in studentsList
                            where stud.Age > 17 && stud.Age < 25
                            select new { stud.FirstName, stud.LastName, stud.Age };
        foreach (var item in studentsByAge)
        {
            Console.WriteLine("{0} {1} - Age {2}", item.FirstName, item.LastName, item.Age);
        }
    }
    static void P05()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Problem 5: Sort Students:");
        Console.WriteLine(new string('-', 30));
        var sortedLambda = studentsList
            .OrderByDescending(stud => stud.FirstName)
            .ThenByDescending(stud => stud.LastName)
            .ToList();
        var sortedLINQquery = from student in studentsList
                              orderby student.FirstName descending, student.LastName descending
                              select student;
        Console.WriteLine("<<< Using Lambda expression >>>");
        foreach (var stud in sortedLambda)
        {
            Console.WriteLine("{0} {1}", stud.FirstName, stud.LastName);
        }
        Console.WriteLine("<<< Using LINQ query >>>");
        foreach (var stud in sortedLINQquery)
        {
            Console.WriteLine("{0} {1}", stud.FirstName, stud.LastName);
        } 
    }
    static void P06()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Problem 6: Filter Students by Email Domain:");
        Console.WriteLine(new string('-', 30));
        var studentABVemail = from stud in studentsList
                              where stud.Email != null && stud.Email.EndsWith("@abv.bg")
                              select stud;
        foreach (var stud in studentABVemail)
        {
            Console.WriteLine("{0} {1} [Email: {2}]", stud.FirstName, stud.LastName, stud.Email);
        }
    }
    static void P07()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Problem 7: Filter Students by Phone:");
        Console.WriteLine(new string('-', 30));
        var studentsByPhone = from stud in studentsList
                              where stud.Phone != null && 
                              (stud.Phone.StartsWith("02") || stud.Phone.StartsWith("+3592") || stud.Phone.StartsWith("+359 2"))
                              select stud;
        Console.WriteLine("Students from Sofia:");
        foreach (var stud in studentsByPhone)
        {
            Console.WriteLine("{0} {1} (Phone: {2})", stud.FirstName, stud.LastName, stud.Phone);
        }
    }
    static void P08()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Problem 8: Excellent Students:");
        Console.WriteLine(new string('-', 30));
        var excellentStudents = from stud in studentsList
                                where stud.Marks != null && stud.Marks.Contains(6)
                                select new { FullName = string.Format("{0} {1}", stud.FirstName, stud.LastName), stud.Marks };
        foreach (var stud in excellentStudents)
        {
            Console.WriteLine("{0} - Marks: {1}", stud.FullName, string.Join(" ", stud.Marks));
        }
    }
    static void P09()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Problem 9: Weak Students:");
        Console.WriteLine(new string('-', 30));
        var weakStudents = studentsList.Weak();
        foreach (var student in weakStudents)
        {
            Console.WriteLine("{0} {1} - Marks: {2}", student.FirstName, student.LastName, string.Join(" ", student.Marks));
        }
    }
    static void P10()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Problem 10: Students Enrolled in 2014:");
        Console.WriteLine(new string('-', 30));
        var studentsEnrolledIn2014 = from stud in studentsList
                                     where (stud.FacultyNumber != null && stud.FacultyNumber.Length > 5 
                                     && stud.FacultyNumber.Substring(4, 2) == "14")
                                     select new { FullName = string.Format("{0} {1}", stud.FirstName, stud.LastName), stud.Marks, stud.FacultyNumber };
        Console.WriteLine("Students enrolled in 2014:");
        foreach (var stud in studentsEnrolledIn2014)
        {
            Console.WriteLine("{2}: {0} - Marks: {1}", stud.FullName, string.Join(" ", stud.Marks), stud.FacultyNumber);
        }
    }
    static void P11()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Problem 11: Students by Groups:");
        Console.WriteLine(new string('-', 30));
        var studentsByGroups = 
            from stud in studentsList
            group stud by stud.GroupName into groups
            orderby groups.Key
            select groups;
        foreach (var group in studentsByGroups)
        {
            Console.WriteLine("\n\tGroup {0}:\n", group.Key);
            foreach (var student in group)
            {
                Console.WriteLine("Student: {0} {1}", student.FirstName, student.LastName);
            }
        }
    }
    static void P12()
    {
        Console.WriteLine(new string('-', 30));
        Console.WriteLine("Problem 12: Students Joined to Specialties:");
        Console.WriteLine(new string('-', 30));
        List<StudentSpecialty> specialties = new List<StudentSpecialty>();
    
        StudentSpecialty studSpec01 = new StudentSpecialty();
        studSpec01.FacultyNumber = "123414";
        studSpec01.Specialty = "Web Developer";
        specialties.Add(studSpec01);
        StudentSpecialty studSpec02 = new StudentSpecialty();
        studSpec02.FacultyNumber = "123656";
        studSpec02.Specialty = "C# Developer";
        specialties.Add(studSpec02);
        StudentSpecialty studSpec03 = new StudentSpecialty();
        studSpec03.FacultyNumber = "129813";
        studSpec03.Specialty = "Java Developer";
        specialties.Add(studSpec03);
        StudentSpecialty studSpec04 = new StudentSpecialty();
        studSpec04.FacultyNumber = "111814";
        studSpec04.Specialty = "Web Developer";
        specialties.Add(studSpec04);
        StudentSpecialty studSpec05 = new StudentSpecialty();
        studSpec05.FacultyNumber = "125536";
        studSpec05.Specialty = "Java Developer";
        specialties.Add(studSpec05);
        StudentSpecialty studSpec06 = new StudentSpecialty();
        studSpec06.FacultyNumber = "122214";
        studSpec06.Specialty = "JavaScript Developer";
        specialties.Add(studSpec06);
        StudentSpecialty studSpec07 = new StudentSpecialty();
        studSpec07.FacultyNumber = "111113";
        studSpec07.Specialty = "C# Developer";
        specialties.Add(studSpec07);
        StudentSpecialty studSpec08 = new StudentSpecialty();
        studSpec08.FacultyNumber = "121116";
        studSpec08.Specialty = "C# Developer";
        specialties.Add(studSpec08);
        StudentSpecialty studSpec09 = new StudentSpecialty();
        studSpec09.FacultyNumber = "113314";
        studSpec09.Specialty = "JavaScript Developer";
        specialties.Add(studSpec09);
        StudentSpecialty studSpec10 = new StudentSpecialty();
        studSpec10.FacultyNumber = "110156";
        studSpec10.Specialty = "Web Developer";
        specialties.Add(studSpec10);

        Console.WriteLine("{0, -20}| Faculty Number | Specialty", "Student");
        Console.WriteLine(new string('-',60));
        var studentsBySpecialty = from student in studentsList
                                  join spec in specialties on student.FacultyNumber equals spec.FacultyNumber
                                  select new { FullName = string.Format("{0} {1}", student.FirstName, student.LastName), FacultyNum = student.FacultyNumber, Specialty = spec.Specialty };
        foreach (var student in studentsBySpecialty)
        {
            Console.WriteLine("{0, -20}| F#:{1} | Specialty: {2}", student.FullName, student.FacultyNum, student.Specialty);
        }
    }
}
