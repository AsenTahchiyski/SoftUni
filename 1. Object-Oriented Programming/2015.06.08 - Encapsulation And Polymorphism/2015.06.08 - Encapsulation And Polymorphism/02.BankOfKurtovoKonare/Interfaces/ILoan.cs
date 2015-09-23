namespace BankOfKurtovoKonare.Interfaces
{
    using BankOfKurtovoKonare.Accounts;

    interface ILoan
    {
        AccountType Type { get; set; }
        decimal CalcInterest(int months);
    }
}
