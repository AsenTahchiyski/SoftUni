namespace VehicleParkSystem
{
    using System.Globalization;
    using System.Threading;

    public static class VehicleParkSystemMain
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            VehiclePark vehiclePark = new VehiclePark();
            var engine = new Engine(vehiclePark); 
            engine.Run();
        }
    }
}