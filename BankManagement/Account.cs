

using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace SupportBank.BankManagement;

public class Account
{
    public string Name{get;set;}

   public decimal Balance { get; set; }
    public List<Transaction> Transactions {get; init;} 
    private readonly ILogger<Bank> _logger;
    private string getUser;

    public Account(string name,ILogger<Bank> logger)
    {
        _logger = logger;
        Name=name;        
    }

     public void GetAccountTransactions () {
        // Console.WriteLine($"Account Name to check {Name}");
       
        foreach(var trans in Bank.Transactions)
        {
            Console.WriteLine(trans.Amount);
            if(trans.From == Name)            {
                // Console.WriteLine($"Account trans to check {trans.Amount}");
                Balance -= trans.Amount;
                Transactions.Add(trans);
            }
            if(trans.To == Name)
            {
                Balance += trans.Amount;
                Transactions.Add(trans);
            }
        }
     Console.WriteLine($"balance for:{Balance}");
    _logger.LogInformation("balance for:{Balance}.", Balance);
     //   Console.WriteLine($"balance for:{Balance}");
    }
    
}