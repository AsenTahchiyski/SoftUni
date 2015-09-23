namespace _02.Animals
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age) : base(name, age, "Female")
        {
        }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Purrr :3");
        }
    }
}
