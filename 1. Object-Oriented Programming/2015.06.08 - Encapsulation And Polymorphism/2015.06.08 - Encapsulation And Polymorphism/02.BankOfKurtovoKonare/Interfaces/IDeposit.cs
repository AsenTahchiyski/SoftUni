namespace BankOfKurtovoKonare.Interfaces
{
    using BankOfKurtovoKonare.Accounts;

    interface IDeposit
    {
        AccountType Type { get; set; }
        void WithdrawMoney(decimal amount);
        decimal CalcInterest(int months);
    }
}
