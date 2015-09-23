using System;
using System.Linq;
using System.Collections.Generic;

namespace _03.PCCatalog
{
    class PCCatalog
    {
        static void Main()
        {
            // valid data
            Computer pc1 = new Computer(
                "Dell Precision T3400 Workstation",
                "Intel Core2Quad E6600",
                100m,
                "Dell Intel Motherboard",
                50m,
                "nVidia GeForce 8600 GT",
                50m);

            Computer pc2 = new Computer(
                "Assembled",
                "AMD Athlon X2 64 4400+",
                30m,
                "2 MB cache, not overclocked",
                "ASUS M2N-E",
                30m,
                "nVidia nForce 570 Chipset, 10xUSB 2.0, 1xPCIe x16, 4xPCI",
                "nVidia Quadro FX 1700",
                30m,
                "Professional Graphics Card");

            Computer pc6 = new Computer(
                "ASUS G20AJ-BG002S",
                "INTEL CORE i7-4790",
                1000m,
                "3.6 GHz 8MB",
                "Unknown Motherboard",
                1000m,
                "INTEL H97 CHIPSET",
                "NVIDIA GeForce GTX970",
                1000m,
                "4GB DDR5"
                );

            List<Computer> compList = new List<Computer> { pc1, pc2, pc6 };
            var sortCompsByPrice = compList.OrderByDescending(x => x.Price);
            foreach (var comp in sortCompsByPrice)
            {
                comp.PrintConfigDetails();
            }

            // invalid data
            // try editing the line below - until you've defined a name for the computer and all of its components + the prices of the components are > 0 the line below will throw the respective exceptions
            
            //Computer pc3 = new Computer("", "", -5, "", -5, "", -5);
            //pc3.PrintConfigDetails();
        }
    }
}
