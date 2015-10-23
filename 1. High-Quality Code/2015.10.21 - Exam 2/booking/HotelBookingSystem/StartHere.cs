namespace HotelBookingSystem
{
    using System;
    using Core;

    public class HotelBookingSystemMain
    {
        public static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
            var engine = Activator.CreateInstance(typeof(Engine)) as Engine;
            engine.Run();
        }
    }
}
