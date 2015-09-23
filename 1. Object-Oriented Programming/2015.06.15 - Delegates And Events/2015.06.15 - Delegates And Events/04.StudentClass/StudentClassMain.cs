namespace StudentClass
{
    using System;

    class StudentClassMain
    {
        static void Main()
        {
            Student student = new Student("Peter", 22);
            student.PropertyChanged += (sender, args) =>
                {
                    Console.WriteLine("Property changed: {0} (from {1} to {2})", args.Name, args.OldValue, args.NewValue);
                };
            student.Name = "Maria";
            student.Age = 19;
        }
    }
}
