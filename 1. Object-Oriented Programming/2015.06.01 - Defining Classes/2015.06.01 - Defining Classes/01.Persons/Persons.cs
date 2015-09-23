using System;

namespace Persons
{
    class Persons
    {
        static void Main()
        {
            Person person1 = new Person("Nashmat", 18, "nashmat@shmahoo.com");
            Console.WriteLine(person1.ToString());

            Person person2 = new Person("Onufrey", 21);
            Console.WriteLine(person2.ToString());

            //Person person3 = new Person("Mircho", 101);
            //Console.WriteLine(person3.ToString());
        }
    }
}
