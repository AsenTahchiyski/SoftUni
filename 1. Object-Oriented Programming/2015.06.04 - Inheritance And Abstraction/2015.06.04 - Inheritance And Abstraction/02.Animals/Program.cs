using System;
using System.Linq;

namespace _02.Animals
{
    class Program
    {
        static void Main()
        {
            Cat cat1 = new Cat("Tom", 2, "Male");
            cat1.ProduceSound();
            Cat cat2 = new Cat("Minka", 3, "Female");
            cat2.ProduceSound();
            Cat cat3 = new Cat("Gosho", 4, "Male");
            cat3.ProduceSound();

            Dog dog1 = new Dog("Lassie", 3, "Female");
            dog1.ProduceSound();
            Dog dog2 = new Dog("Haruki", 4, "Male");
            dog2.ProduceSound();
            Dog dog3 = new Dog("Murdjo", 5, "Male");
            dog3.ProduceSound();

            Frog frog1 = new Frog("Prince", 1, "Male");
            frog1.ProduceSound();
            Frog frog2 = new Frog("Igor", 2, "Male");
            frog2.ProduceSound();
            Frog frog3 = new Frog("Jivka", 1, "Female");
            frog3.ProduceSound();
            
            Kitten kitten1 = new Kitten("Bira", 1);
            kitten1.ProduceSound();
            Kitten kitten2 = new Kitten("Chertichka", 4);
            kitten2.ProduceSound();
            Kitten kitten3 = new Kitten("Pepa", 2);
            kitten3.ProduceSound();

            Tomcat tomcat1 = new Tomcat("Coolio", 4);
            tomcat1.ProduceSound();
            Tomcat tomcat2 = new Tomcat("Pantelei", 3);
            tomcat2.ProduceSound();
            Tomcat tomcat3 = new Tomcat("Kotyo", 6);
            tomcat3.ProduceSound();

            Console.WriteLine(new string('=', 30));

            Animal[] animals = { cat1, cat2, cat3, dog1, dog2, dog3, frog1, frog2, frog3, kitten1, kitten2, kitten3, tomcat1, tomcat2, tomcat3 };

            double averageAge = animals.Average(x => x.Age);
            Console.WriteLine("Average age of all animals is {0:0.##} years.", averageAge);

            double averageAgeCat = animals.Where(x => x is Cat).Average(x => x.Age);
            Console.WriteLine("Average age of the cats is {0:0.##} years.", averageAgeCat);

            double averageAgeDog = animals.Where(x => x is Dog).Average(x => x.Age);
            Console.WriteLine("Average age of the dogs is {0:0.##} years.", averageAgeDog);

            double averageAgeFrog = animals.Where(x => x is Frog).Average(x => x.Age);
            Console.WriteLine("Average age of the frogs is {0:0.##} years.", averageAgeFrog);

            double averageAgeKitten = animals.Where(x => x is Kitten).Average(x => x.Age);
            Console.WriteLine("Average age of the kitten is {0:0.##} years.", averageAgeKitten);

            double averageAgeTomcat = animals.Where(x => x is Tomcat).Average(x => x.Age);
            Console.WriteLine("Average age of the tomcats is {0:0.##} years.", averageAgeTomcat);
        }
    }
}
