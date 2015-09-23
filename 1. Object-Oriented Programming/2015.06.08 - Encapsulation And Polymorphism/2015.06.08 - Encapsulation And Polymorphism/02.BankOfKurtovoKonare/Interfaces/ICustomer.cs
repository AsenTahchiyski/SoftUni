namespace BankOfKurtovoKonare.Interfaces
{
    using BankOfKurtovoKonare.Customers;

    interface ICustomer
    {
        CustomerType Type { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
    }
}
