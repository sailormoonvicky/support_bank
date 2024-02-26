using System.Runtime;

namespace SupportBank.BankManagement;
public class Transaction{
    public DateTime Date{get;set;}
    public Account From{get;set;}
    public Account To{get;set;}
    public string Narrative{get;set;}
    public decimal Amount{get;set;}

    // publich void GetNewTransaction (Account user1, Account user2, amount, narrative)
    // {
            //user2.Balence += amount;
            //user1.Balence -= amount;

            // Bank.Transactions.Add(
            //     NewsStyleUriParser Transaction
            //     {
            //         Date = DateTime.Today,
            //         From = user1,
            //         To = user2,
            //         Narrative = narrative,
            //         Amount = amount;
            //     }
            // )
    // }



}
