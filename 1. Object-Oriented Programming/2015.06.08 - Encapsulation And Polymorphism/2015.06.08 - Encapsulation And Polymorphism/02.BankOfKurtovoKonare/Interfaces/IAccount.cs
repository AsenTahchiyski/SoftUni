namespace BankOfKurtovoKonare.Interfaces
{
    using BankOfKurtovoKonare.Customers;
    using BankOfKurtovoKonare.Accounts;

    interface IAccount
    {
        Customer Customer { get; set; }
        AccountType Type { get; set; }
        decimal Ballance { get; set; }
        decimal InterestRate { get; set; }

        void DepositMoney(decimal amount);
    }
}
