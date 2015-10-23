namespace VehicleParkingSystem
{
    using System.Globalization;
    using System.Threading;
    using Controllers;

    public static class StartHere
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture; 
            var engine = new Engine(); 
            engine.Run();
        }
    }
}