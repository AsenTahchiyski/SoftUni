using System;
using System.Data.Entity;
using System.Linq;
using System.Transactions;
using ATM.Data;
using ATM.Models;

namespace ATM.ConsoleClient
{
    public class ATMMain
    {
        private static ATMContext context = new ATMContext();

        static void Main()
        {
            //context.CardAccounts.AddRange(new[]
            //{
            //    new CardAccount() { CardNumber = "1234567890", CardPIN = "1234", CardCash = 100.66m },
            //    new CardAccount() { CardNumber = "1234437890", CardPIN = "4321", CardCash = 1000.33m },
            //    new CardAccount() { CardNumber = "1211117890", CardPIN = "5678", CardCash = 131.65m },
            //    new CardAccount() { CardNumber = "1234562222", CardPIN = "0007", CardCash = 1000000.01m },
            //    new CardAccount() { CardNumber = "0001567890", CardPIN = "0101", CardCash = 12000.22m }
            //});

            //context.SaveChanges();

            Withdraw("1234567890", "1234", 50m);
        }

        static void Withdraw(string cardNum, string cardPin, decimal amount)
        {
            using (var scope = new TransactionScope())
            {
                var card = context.CardAccounts
                .Where(c => c.CardNumber == cardNum && c.CardPIN == cardPin)
                .FirstOrDefault();
                if (card == null)
                {
                    throw new InvalidOperationException("Incorrect card number of pin.");
                }
                if (card.CardCash < amount)
                {
                    throw new InvalidOperationException("Not enough cash brah.");
                }

                card.CardCash -= amount;
                context.TransactionsHistory
                    .Add(new TransactionHistory()
                    {
                        CardNumber = cardNum,
                        TransactionDate = DateTime.Now,
                        Amount = amount
                    });
                context.SaveChanges();
                scope.Complete();
            }
        }
    }
}
