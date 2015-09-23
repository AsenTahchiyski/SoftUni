using System;
class BankAccountData
{
    static void Main()
    {
        string FirstName = "Evlampi";
        string MidName = "Dragoev";
        string LastName = "Kostakiev";
        double balance = 3576298325.23;
        string bank = "Switzerland National Bank";
        string IBAN = "CH93 0076 2011 6238 5295 7";
        long[] CreditCards = { 5105105105105100, 4111111111111111, 378282246310005 };

        Console.WriteLine("Name: {0} {1} {2} \n{6}\nBallance: {3} CHF \n{6}\nBank: {4} \nIBAN: {5}\n{6}", 
            FirstName, MidName, LastName, String.Format("{0:#,###.##}", balance), bank, IBAN, new string('-', 30));
        foreach (long item in CreditCards)
        {
            Console.WriteLine("Credit Card:" + item);
        }
        Console.WriteLine(new string('-', 30));
    }
}
