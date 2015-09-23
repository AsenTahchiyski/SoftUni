namespace BankOfKurtovoKonare.Interfaces
{
    using BankOfKurtovoKonare.Customers;

    interface IPerson
    {
        CustomerType Type { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        int Age { get; set; }
        string EGN { get; set; }
    }
}
