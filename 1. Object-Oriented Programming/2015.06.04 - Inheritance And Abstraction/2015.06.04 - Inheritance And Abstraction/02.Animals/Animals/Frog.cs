namespace _02.Animals
{
    public class Frog : Animal, ISoundProducible
    {
        public Frog(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public void ProduceSound()
        {
            System.Console.WriteLine("Ribbit!");
        }
    }
}
