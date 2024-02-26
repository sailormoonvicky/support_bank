
using System.Globalization;

namespace SupportBank.BankManagement;

public class Bank 
{
    public List<Account> Accounts = [];
    public List<Transaction> Transactions{get;set;} = [];

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
                            From=col[1],
                            To=col[2],
                            Narrative=col[3],
                            Amount=decimal.Parse(col[4]),                
                    });
                }
            foreach(var item in Transactions)
            {
                Console.WriteLine(item.Date.ToString("yyyy-MM-dd"));
                Console.WriteLine(item.From);
                Console.WriteLine(item.To);
                Console.WriteLine(item.Narrative);
                Console.WriteLine(item.Amount);
                Console.WriteLine("=============");
            }
        }

        catch (FileNotFoundException)
        {
            Console.WriteLine("Sorry, that file was not found.");
        }
        
    }

    // public decimal checkBalance (Account account)
    // {
        
    // }

}