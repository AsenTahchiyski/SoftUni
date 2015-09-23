using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_.HTMLDispatcher
{
    class Program
    {
        static void Main()
        {
            ElementBuilder div = new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");

            Console.WriteLine(div * 2);

        }
    }
}
