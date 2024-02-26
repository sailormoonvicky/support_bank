// See https://aka.ms/new-console-template for more information
using System.Globalization;
using SupportBank.BankManagement;
var llyods = new Bank();
Console.Write("Enter the name of the file you wish to read from: ");
var fileName = Console.ReadLine() ?? "";
llyods.AddTransactionList(fileName);
Console.WriteLine("Chekcking all balances");
llyods.checkBalance();
Console.WriteLine("Print for whose balance you want to check");
var getUser= Console.ReadLine() ?? "";
//llyods.checkBalance(getUser);
var user1= new Account(getUser);
user1.GetAccountTransactions();
llyods.checkBalance(user1);
