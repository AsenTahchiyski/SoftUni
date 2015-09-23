namespace BankOfKurtovoKonare
{
    using System;
    using BankOfKurtovoKonare.Accounts;
    using BankOfKurtovoKonare.Customers;

    class Program
    {
        static void Main()
        {
            Person person1 = new Person("Cheplyat 4711, ul. Kriva 7", "+35930143285", "Georgi", "Nashmatliyski", 44, "7104254323");
            Person person2 = new Person("Lovech 7611, ul. Prava 10", "+35940165883", "Kaymet", "Dertliev", 31, "8401055374");
            Person person3 = new Person("Gudevitza 1691, ul. Glavna 1", "+35988765373", "Evlampi", "Svetlozarov", 52, "6401055374");

            Company company1 = new Company("Sofia 1000, ul. Buren 23", "024446667", "Bastuni Unlimited EOOD", "Tenko Gazarliev", "BG237452357");
            Company company2 = new Company("Sofia 1000, ul. Kiryak Stefchov 13", "026236305", "Kloshari Incorporated OOD", "Ceko Minev", "BG127722365");
            Company company3 = new Company("Plovdiv 2030, ul. Tepe 5", "032481690", "ET Bass Tune", "Stamat Kazandjiev", "BG224711902");

            Loan loan1 = new Loan(person1, -1000m, 0.12m);
            Loan loan2 = new Loan(company1, -20000m, 0.08m);
            Loan loan3 = new Loan(company2, -10010m, 0.10m);

            Mortgage mort1 = new Mortgage(person1, -100000m, 0.06m);
            Mortgage mort2 = new Mortgage(person2, -200000m, 0.05m);
            Mortgage mort3 = new Mortgage(person3, -50000m, 0.055m);

            Deposit deposit1 = new Deposit(person1, 500m, 0.02m);
            Deposit deposit2 = new Deposit(company3, 15000m, 0.02m);
            Deposit deposit3 = new Deposit(person3, 5500m, 0.02m);

            loan1.DepositMoney(1500);
            mort2.DepositMoney(15000);
            deposit3.WithdrawMoney(1000);

            int period = 2; // <<-- months; change the period to see how interest calculation differs according to the problem description

            Account[] allAccounts = { loan1, loan2, loan3, mort1, mort2, mort3, deposit1, deposit2, deposit3 };
            foreach (var account in allAccounts)
            {
                Console.WriteLine("{2} {0} account\nCurrent Ballance = {1} BGN", account.Type, account.Ballance, account.Customer.Type);
                Console.WriteLine("Ballance in {0} months\n(Interest: {2:P}) = {1} BGN", period, account.CalcInterest(period), account.InterestRate);
                Console.WriteLine(new string('+', 50));
                if (account.Customer is Person)
                {
                    Person temp = (Person)account.Customer;
                    Console.WriteLine("Owner: {0} {1} (EGN {2}), Age: {3}\nAddress: {4}\nPhone: {5}", temp.FirstName, temp.LastName, temp.EGN, temp.Age, temp.Address, temp.Phone);
                }
                else if (account.Customer is Company)
                {
                    Company temp = (Company)account.Customer;
                    Console.WriteLine("Company name: {0} (Bulstat: {1})\nMOL: {2}\nAddress: {3}\nPhone: {4}", temp.Name, temp.Bulstat, temp.MOL, temp.Address, temp.Phone);
                }
                Console.WriteLine(new string('=', 50));
            }
        }
    }
}
