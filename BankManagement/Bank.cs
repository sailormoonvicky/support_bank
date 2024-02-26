
using System.Globalization;
using NLog;
using NLog.Config;
using NLog.Targets;

namespace SupportBank.BankManagement;

public class Bank 
{
    public HashSet<Account> AccountList {get; set; } = [];
    public static Dictionary<string,decimal> balances{get;set;}
    public Bank(){
        balances= new Dictionary<string, decimal>();
    }
    public static List<Transaction> Transactions{get;set;} = [];

    public decimal Balance=0;
    public void AddTransactionList (string fileName)
    {
        Console.Write("Enter the name of the file you wish to read from: ");

        //string data ; 
        List<String> lines=new List<string>();
        try
        {
        // var transactions = new List<Transaction>();
            var fileReader = new StreamReader(fileName);
            while(!fileReader.EndOfStream){
                var line= fileReader.ReadLine().Trim();
                lines.Add(line);
            }
            fileReader.Close();
            Console.WriteLine("Here is the content of your file:");
            foreach (var singleLine in lines)
                {
                    if(singleLine.StartsWith("Date")) continue;
                    var col=singleLine.Split(',');
                    Transactions.Add(
                        new Transaction
                        {
                            Date = DateTime.Parse(col[0]),
                            From= new Account(col[1]),
                            To= new Account(col[2]),
                            Narrative=col[3],
                            Amount=decimal.Parse(col[4]),              
                    });
                }
            // foreach(var item in Transactions)
            // {
            //     Console.WriteLine(item.Date.ToString("yyyy-MM-dd"));
            //     Console.WriteLine(item.From);
            //     Console.WriteLine(item.To);
            //     Console.WriteLine(item.Narrative);
            //     Console.WriteLine(item.Amount);
            //     Console.WriteLine("=============");
                //  if(!Accounts.ContainsKey(item.From)){
                //     Accounts[item.From]= new Account(item.From);
                // }
                //  if(!Accounts.ContainsKey(item.From)){
                //     Accounts[item.To]= new Account(item.To);
                // }
                // Accounts[item.From].Transactions.Add(item);
                // Accounts[item.To].Transactions.Add(item);
                
        //    }
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("Sorry, that file wcoas not found.");
        }
        // foreach(var acc in Accounts)
        // Console.WriteLine($"{acc.Key}{acc.Value}");
                
        
   

    }

   public void checkBalance()
   {
        foreach (var transaction in Transactions)
        {
            if (!balances.ContainsKey(transaction.From.Name))
                balances[transaction.From.Name] = 0m;

            if (!balances.ContainsKey(transaction.To.Name))
                balances[transaction.To.Name] = 0m;

            balances[transaction.From.Name] -= transaction.Amount;
            balances[transaction.To.Name] += transaction.Amount;
        }

        foreach (var balance in balances)
        {
            Console.WriteLine($"{balance.Key} balance: {balance.Value:C}");
        }
    }
    public void checkBalance (String name)
    {
        Console.WriteLine($"Balance is {balances[name]}");
       // Console.WriteLine($"{account.Name}'s balance: {account.Balance}.");
    }


    public void checkBalance (Account account)
    {

        Console.WriteLine($"{account.Name}'s balance: {account.Balance}.");
    }

}