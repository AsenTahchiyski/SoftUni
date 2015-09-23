namespace CustomLINQExtMethods
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            // WhereNot
            List<int> nums = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("List of numbers: {0}", string.Join(", ", nums));
            var filteredCollection = nums.WhereNot(x => x % 2 == 0);
            Console.WriteLine("Filtered collection: {0}", string.Join(", ", filteredCollection));
            Console.WriteLine(new string('=', 50));

            // Max
            var students = new List<Student>
            {
                new Student("Pesho", 3),
                new Student("Gosho", 2),
                new Student("Mariika", 7),
                new Student("Stamat", 5),
            };
            Console.WriteLine("Students:");
            foreach (Student st in students)
            {
                Console.WriteLine("Name: {0}, Grade: {1}", st.Name, st.Grade);
            }
            Console.WriteLine("Max grade: {0}", students.Max(student => student.Grade));
        }
    }
}
