namespace Customer
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            Customer pesho = new Customer("Pesho", "Peshev", "Peshliyski", 8012213456, "Peshovitza 5", "02/3456789", "pesho@peshonet.bg", new List<Payment>(), CustomerType.Regular);
            pesho.Payments.Add(new Payment("Vinkel", 100));
            pesho.Payments.Add(new Payment("Armatura", 150));
            Console.WriteLine(pesho);
            Console.WriteLine("Payments:");
            foreach (Payment item in pesho.Payments)
            {
                Console.WriteLine("- {0} - {1} BGN", item.ProductName, item.Price);
            }
            Console.WriteLine(new string('=', 30));

            Customer gosho = pesho.Clone() as Customer;
            gosho.FirstName = "Gosho";
            gosho.ID = 7704024567;
            gosho.Email = "gosho@peshonet.bg";
            gosho.Payments.Add(new Payment("Ankeri", 100));

            Console.WriteLine(gosho);
            Console.WriteLine("Payments:");
            foreach (Payment item in gosho.Payments)
            {
                Console.WriteLine("- {0} - {1} BGN", item.ProductName, item.Price);
            }
            Console.WriteLine(new string('=', 30));

            if (pesho.CompareTo(gosho) > 0)
            {
                Console.WriteLine("Customer is first, compared to the given criteria.");
            }
            else if (pesho.CompareTo(gosho) < 0)
            {
                Console.WriteLine("Customer is last, compared to the given criteria.");
            }
            else
            {
                Console.WriteLine("Customers are equal.");
            }

            Console.WriteLine("First equals second: " + pesho.Equals(gosho));
            Console.WriteLine("First == second: " + (pesho == gosho));
            Console.WriteLine("First != second: " + (pesho != gosho));

            Console.WriteLine("First's hash: " + pesho.GetHashCode());
            Console.WriteLine("Second's hash: " + gosho.GetHashCode());
        }
    }
}
