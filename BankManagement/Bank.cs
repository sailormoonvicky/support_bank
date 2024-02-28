
using System.Globalization;
using CsvHelper;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank.BankManagement;

public class Bank
{
    public Dictionary<string, Account> Accounts { get; set; } = [];

    private readonly ILogger<Bank> _logger;

    public Bank(ILogger<Bank> logger)
    {
        _logger = logger;
    }

    public void AddTransactionList(string fileName)
    {
        Console.Write("Enter the name of the file you wish to read from: ");
        try
        {
            _logger.LogInformation("Add transaction logger starting");

            using var fileReader = new StreamReader(fileName);
            using var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
            try 
            {
                var transactions = csvReader.GetRecords<Transaction>();

                foreach (var transaction in transactions)
                {
                    if(!Accounts.TryGetValue(transaction.From, out var fromAccount))
                    {
                        fromAccount = new Account(_logger)
                        {
                            Name = transaction.From,
                        };
                        Accounts.Add(transaction.From, fromAccount);
                    }
                    if(!Accounts.TryGetValue(transaction.To, out var toAccount))
                    {
                        toAccount = new Account(_logger)
                        {
                            Name = transaction.To,
                        };
                        Accounts.Add(transaction.To, toAccount);
                    }

                    fromAccount.Balance -= transaction.Amount;
                    toAccount.Balance += transaction.Amount;
                    fromAccount.Transactions.Add(transaction);
                    toAccount.Transactions.Add(transaction);

                }
            }
            catch (CsvHelper.TypeConversion.TypeConverterException  ex)
            {
                _logger.LogError("This csv file doesn't match the format");
                _logger.LogDebug(ex.StackTrace);
                Console.WriteLine($"Sorry, that file doesn't match the format.");
            }

            
            // foreach (var transaction in transactions)
            // {
            //     if(!Accounts.TryGetValue(transaction.From, out var fromAccount))
            //     {
            //         fromAccount = new Account(_logger)
            //         {
            //             Name = transaction.From,
            //         };
            //         Accounts.Add(transaction.From, fromAccount);
            //     }
            //     if(!Accounts.TryGetValue(transaction.To, out var toAccount))
            //     {
            //         toAccount = new Account(_logger)
            //         {
            //             Name = transaction.To,
            //         };
            //         Accounts.Add(transaction.To, toAccount);
            //     }

            //     fromAccount.Balance -= transaction.Amount;
            //     toAccount.Balance += transaction.Amount;
            //     fromAccount.Transactions.Add(transaction);
            //     toAccount.Transactions.Add(transaction);

            // }
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
        // catch (CsvHelper.TypeConversion.TypeConverterException  ex)
        // {
        //     _logger.LogError("This csv file doesn't match the format");
        //    _logger.LogDebug(ex.StackTrace);
        //     Console.WriteLine($"Sorry, that file doesn't match the format.");
        // }

    }   

    public void CheckBalances()
    {
        _logger.LogInformation("Check Balance starting.");
        foreach(var (accountName,account) in Accounts)
        {
            Console.WriteLine($"{accountName}: {account.Balance}");
        }
    }

    public void CheckTransactions (string name)
    {
        foreach(var transaction in Accounts[name].Transactions)
        {
            Console.WriteLine(transaction);
        }
    }

     public void CheckBalance(string name)
    {

        Console.WriteLine($"{name} balance: {Accounts[name].Balance}.");
    }
}