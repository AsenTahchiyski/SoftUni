namespace ATM.Data
{
    using System.Data.Entity;
    using Migrations;
    using Models;
    public class ATMContext : DbContext
    {
        public ATMContext()
            : base("name=ATMContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ATMContext, Configuration>());
        }

        public virtual DbSet<CardAccount> CardAccounts { get; set; }

        public virtual DbSet<TransactionHistory> TransactionsHistory { get; set; }
    }
}