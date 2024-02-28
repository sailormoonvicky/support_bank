// See https://aka.ms/new-console-template for more information
using System.Globalization;
using SupportBank.BankManagement;
using NLog;
using NLog.Config;
using NLog.Targets;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

var servicesProvider = new ServiceCollection()
    .AddTransient<Bank>()
    .AddLogging(loggingBuilder =>
    {
        loggingBuilder.ClearProviders();
        loggingBuilder.AddNLog();
    })
    .BuildServiceProvider();
var llyods = servicesProvider.GetRequiredService<Bank>();
Console.Write("Enter the name of the file you wish to read from: ");
var fileName = Console.ReadLine() ?? "";
llyods.AddTransactionList(fileName);
Console.WriteLine("Chekcking all balances");
llyods.CheckBalances();
Console.WriteLine("Print for whose balance you want to check");
var userName= Console.ReadLine() ?? "";

llyods.CheckTransactions(userName);
llyods.CheckBalance(userName);

