namespace _02.Animals
{
    public class Dog : Animal, ISoundProducible
    {
        public Dog(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public void ProduceSound()
        {
            System.Console.WriteLine("Bark!");
        }
    }
}
