

using System.Reflection.Metadata.Ecma335;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace SupportBank.BankManagement;

public class Account
{
    public required string Name{get;set;}

   public decimal Balance { get; set; } = 0;
    public List<Transaction> Transactions {get; } = [];
    private readonly ILogger<Bank> _logger;
    // private string getUser;

    public Account(ILogger<Bank> logger)
    {
        _logger = logger;       
    }
}