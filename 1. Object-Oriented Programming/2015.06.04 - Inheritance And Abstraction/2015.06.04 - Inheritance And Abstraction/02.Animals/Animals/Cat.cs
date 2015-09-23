namespace _02.Animals
{
    public class Cat : Animal, ISoundProducible
    {
        public Cat(string name, int age, string gender)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        public virtual void ProduceSound()
        {
            System.Console.WriteLine("Meow!");
        }
    }
}
