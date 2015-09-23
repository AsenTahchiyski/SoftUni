namespace BankOfKurtovoKonare.Interfaces
{
    using BankOfKurtovoKonare.Accounts;

    interface IMortgage
    {
        AccountType Type { get; set; }
        decimal CalcInterest(int months);
    }
}
