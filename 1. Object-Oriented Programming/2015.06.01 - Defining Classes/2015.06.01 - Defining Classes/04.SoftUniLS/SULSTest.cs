using System;
using System.Linq;
using System.Collections.Generic;

using SULS.Students;
using SULS.Students.Current;
using SULS.Trainers;

namespace SULS
{
    class SULSTest
    {
        static void Main()
        {
            Person person1 = new Person("Gosho", "Minchev", 66);
            Person person2 = new Person("Pesho", "Genchev", 26);
            Person person3 = new Person("Mityo", "Pishtovliev", 36);
            List<Person> persons = new List<Person> { person1, person2, person3 };

            Student student1 = new Student("Misho", "Goranov", 23, "90012315", 4.56);
            Student student2 = new Student("Maya", "Petrova", 28, "90013315", 5.50);
            Student student3 = new Student("Petya", "Svilenova", 23, "90023315", 5.76);
            List<Student> students = new List<Student> { student1, student2, student3 };

            Trainer trainer1 = new Trainer("Svetlin", "Nakov", 33);
            Trainer trainer2 = new Trainer("Preslav", "Nakov", 35);
            Trainer trainer3 = new Trainer("Mario", "Peshev", 31);
            List<Trainer> trainers = new List<Trainer> { trainer1, trainer2, trainer3 };

            JuniorTrainer junior1 = new JuniorTrainer("Fil", "Kolev", 29);
            JuniorTrainer junior2 = new JuniorTrainer("Penka", "Borukova", 28);
            JuniorTrainer junior3 = new JuniorTrainer("Ivo", "Kotow", 30);
            List<JuniorTrainer> juniorTrainers = new List<JuniorTrainer> { junior1, junior2, junior3 };

            SeniorTrainer senior1 = new SeniorTrainer("Angel", "Georgiev", 31);
            SeniorTrainer senior2 = new SeniorTrainer("Atanas", "Rusenov", 26);
            SeniorTrainer senior3 = new SeniorTrainer("Bogomil", "Dimitrov", 30);
            List<SeniorTrainer> seniorTrainers = new List<SeniorTrainer> { senior1, senior2, senior3 };

            CurrentStudent currentSt1 = new CurrentStudent("Georgi", "Petkov", 21, "900432114", 5.25, "Advanced JavaScript");
            CurrentStudent currentSt2 = new CurrentStudent("Aneliya", "Borisova", 20, "900422114", 4.56, "Java Basics");
            CurrentStudent currentSt3 = new CurrentStudent("Sasha", "Grey", 29, "900434315", 3.69, "Avanced C#");
            List<CurrentStudent> currentStudents = new List<CurrentStudent> { currentSt1, currentSt2, currentSt3 };

            CurrentOnlineStudent currOnlineSt1 = new CurrentOnlineStudent("Merry", "Poppins", 22, "900682115", 3.50, "OOP");
            CurrentOnlineStudent currOnlineSt2 = new CurrentOnlineStudent("Aaron", "Turner", 32, "900542115", 5.50, "Database Applications");
            CurrentOnlineStudent currOnlineSt3 = new CurrentOnlineStudent("Nashmat", "Kodarov", 22, "900684315", 5.24, "Web Fundamentals");
            List<CurrentOnlineStudent> currentOnlineStudents = new List<CurrentOnlineStudent> { currOnlineSt1, currOnlineSt2, currOnlineSt3 };

            CurrentOnsiteStudent currOnsiteSt1 = new CurrentOnsiteStudent("Masha", "Medvedevna", 18, "900543215", 4.15, "Java Basics");
            CurrentOnsiteStudent currOnsiteSt2 = new CurrentOnsiteStudent("Ivana", "Kotareva", 29, "900693215", 5.80, "Java Advanced");
            CurrentOnsiteStudent currOnsiteSt3 = new CurrentOnsiteStudent("Ismail", "Programoglu", 18, "900541115", 4.95, "C# Advanced");
            List<CurrentOnsiteStudent> currentOnsiteStudents = new List<CurrentOnsiteStudent> { currOnsiteSt1, currOnsiteSt2, currOnsiteSt3 };

            GraduateStudent gradStudent1 = new GraduateStudent("Koycho", "Nashmatov", 25, "900122114", 5.15);
            GraduateStudent gradStudent2 = new GraduateStudent("Katya", "Yavorova", 45, "900002114", 5.45);
            GraduateStudent gradStudent3 = new GraduateStudent("Gospodin", "Nashmatov", 26, "900122214", 5.59);
            List<GraduateStudent> graduateStudents = new List<GraduateStudent> { gradStudent1, gradStudent2, gradStudent3 };

            DropoutStudent dropStudent1 = new DropoutStudent("Ganka", "Prostakieva", 19, "9001235214", 2.85, "Low grades");
            DropoutStudent dropStudent2 = new DropoutStudent("Vasil", "Sarikov", 29, "9001015214", 2.40, "Low grades");
            DropoutStudent dropStudent3 = new DropoutStudent("Daniel", "Zarezliev", 19, "9001235214", 4.85, "Going to the Mars colony.");
            List<DropoutStudent> dropoutStudents = new List<DropoutStudent> { dropStudent1, dropStudent2, dropStudent3 };

            List<Person> database = new List<Person>();
            database.AddRange(persons);
            database.AddRange(students);
            database.AddRange(trainers);
            database.AddRange(juniorTrainers);
            database.AddRange(seniorTrainers);
            database.AddRange(currentStudents);
            database.AddRange(currentOnlineStudents);
            database.AddRange(currentOnsiteStudents);
            database.AddRange(graduateStudents);
            database.AddRange(dropoutStudents);

            var currentStudentsSortedByAvgGrade = database.Where(x => x is CurrentStudent).Cast<CurrentStudent>().OrderByDescending(x => x.AverageGrade);

            foreach (Student student in currentStudentsSortedByAvgGrade)
            {
                Console.WriteLine("Name: {0} {1}", student.FirstName, student.LastName);
                Console.WriteLine("Average Grade: {0}", student.AverageGrade);
            }
        }
    }
}
