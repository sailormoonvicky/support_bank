
using System.Globalization;
using CsvHelper;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank.BankManagement;

public class Bank
{
    // private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
    public HashSet<Account> AccountList { get; set; } = [];
    public static Dictionary<string, decimal> balances { get; set; }

    private readonly ILogger<Bank> _logger;

    public Bank(ILogger<Bank> logger)
    {
        _logger = logger;
        balances = new Dictionary<string, decimal>();
    }

    public static IEnumerable<Transaction> Transactions { get; set; } = [];

    public decimal Balance = 0;
    public void AddTransactionList(string fileName)
    {
        Console.Write("Enter the name of the file you wish to read from: ");
        try
        {
             _logger.LogInformation("Add transaction logger starting");

            var fileReader = new StreamReader(fileName);
            var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
        //    _logger.LogInformation("csv convertion sucessful");
            Transactions = csvReader.GetRecords<Transaction>();
            //_logger.LogInformation("csv convertion sucessful");
         //  Console.WriteLine("Here is the content of your file:");
            // foreach (var singleLine in Transactions)
            // {
            //     _logger.LogInformation($"New account created for {singleLine.Date}.");
            //     _logger.LogInformation("New account created for {singleLine.From}.", singleLine.From);
            //     _logger.LogInformation("New account created for {singleLine.From}.", singleLine.To);
            //     _logger.LogInformation("New account created for {singleLine.From}.", singleLine.Narrative);
            //     _logger.LogInformation("New account created for {singleLine.From}.", singleLine.Amount);

            //     // Console.WriteLine(singleLine.Date);
            //     // Console.WriteLine(singleLine.From);
            //     // Console.WriteLine(singleLine.To);
            //     // Console.WriteLine(singleLine.Narrative);
            //     // Console.WriteLine(singleLine.Amount);
            //     Console.WriteLine("==============");
            // }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Sorry, that file wcoas not found.");
        }
        catch (CsvHelper.TypeConversion.TypeConverterException  msg)
        {
          //  _logger.LogInformation("New account created for {singleLine.From}.", msg);

             
            Console.WriteLine($"Sorry, that file doesn't match the format.");
        }

    }   

    public void checkBalance()
    {
        _logger.LogInformation("Check Balance starting.");
        foreach (var transaction in Transactions)
        {
            if (!balances.ContainsKey(transaction.From))
                balances[transaction.From] = 0m;

            if (!balances.ContainsKey(transaction.To))
                balances[transaction.To] = 0m;

            balances[transaction.From] -= transaction.Amount;
            balances[transaction.To] += transaction.Amount;
        }

        foreach (var balance in balances)
        {
            _logger.LogInformation($"{balance.Key} balance: {balance.Value:C}");
           // Console.WriteLine($"{balance.Key} balance: {balance.Value:C}");
        }
    }

     public void checkBalance(string name)
    {

        Console.WriteLine($"{name} balance: {balances[name]}.");
    }


    public void checkBalance(Account account)
    {

        Console.WriteLine($"{account.Name}'s balance: {account.Balance}.");
    }

}