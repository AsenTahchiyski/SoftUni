using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.HumanStudentWorker
{
    class Program
    {
        static void Main()
        {
            List<Student> students = new List<Student>() {
            new Student("Blagoy", "Blajev",     "90012345"),
            new Student("Stamen", "Yordanov",   "90012321"),
            new Student("Tsvyatko", "Ivaylov",  "90022345"),
            new Student("Anatoli", "Chichev",   "90018765"),
            new Student("Kristina", "Koleva",   "90012444"),
            new Student("Petko", "Barbukov",    "90013458"),
            new Student("Slavka", "Georgieva",  "90011543"),
            new Student("Debelyan", "Peevski",  "90027654"),
            new Student("Paco", "Rapandjiev",   "90007643"),
            new Student("Katya", "Kazandjieva", "90006334"), }
            .OrderBy(x => x.FacultyNumber).ToList();

            List<Worker> workers = new List<Worker>() {
            new Worker("Petko", "Genchev", 300, 8),
            new Worker("Gencho", "Gurdev", 250, 4),
            new Worker("Panayot", "Trichkov", 120, 5),
            new Worker("Cvetan", "Mitkov", 280, 8),
            new Worker("Svetlin", "Kirov", 200, 6),
            new Worker("Dimitar", "Stefanov", 300, 6),
            new Worker("Georgi", "Petrov", 300, 4),
            new Worker("Yana", "Valcheva", 200, 7),
            new Worker("Petya", "Tupareva", 200, 8),
            new Worker("Anna", "Tripeva", 200, 10), }
            .OrderByDescending(x => x.MoneyPerHour()).ToList();

            List<Human> database = new List<Human>();
            database.AddRange(students);
            database.AddRange(workers);
            database = database.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();

            foreach (var human in database)
            {
                Console.WriteLine("{0} {1} ({2})", human.FirstName, human.LastName, human.GetType().Name);
            }
        }
    }
}
