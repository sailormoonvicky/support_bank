

using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;

namespace SupportBank.BankManagement;

public class Account
{
    public string Name{get;set;}

   public decimal Balance { get; set; }
    public List<Transaction> Transactions {get; set;}
    public Account(string name)
    {
        Name=name;
        Transactions= new List<Transaction>();
        
    }
    public void GetAccountTransactions () {
        foreach(var trans in Bank.Transactions)
        {
            if(trans.From.Name == Name)
            {
                Balance -= trans.Amount;
                Transactions.Add(trans);
            }
            if(trans.To.Name == Name)
            {
                Balance += trans.Amount;
                Transactions.Add(trans);
            }
        }
    }
}