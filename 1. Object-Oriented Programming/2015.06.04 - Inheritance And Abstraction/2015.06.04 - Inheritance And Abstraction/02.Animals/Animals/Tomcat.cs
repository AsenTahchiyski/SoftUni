namespace _02.Animals
{
    public class Tomcat : Cat
    {
        public Tomcat(string name, int age)
            : base(name, age, "Male")
        {
        }

        public override void ProduceSound()
        {
            System.Console.WriteLine("Meow, motherf****r!");
        }
    }
}
