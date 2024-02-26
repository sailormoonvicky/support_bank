// See https://aka.ms/new-console-template for more information
using System.Globalization;
using SupportBank.BankManagement;
var llyods = new Bank();
llyods.AddTransactionList("data/Transactions2014.csv");
var Transactionlist = new Transaction();

// Console.Write("Enter the name of the file you wish to read from: ");

// //var fileName = Console.ReadLine() ?? "";

//     var fileReader = new StreamReader(fileName);
//     Console.WriteLine("Here is the content of your file:");
//     while(!fileReader.EndOfStream){
//         var line= fileReader.ReadLine().Trim();
//         lines.Add(line);
//     }
//      fileReader.Close();
//      Console.WriteLine("Here is the content of your file:");
//      foreach (var singleLine in lines)
//         {
//             if(singleLine.StartsWith("Date")) continue;
//             var col=singleLine.Split(',');
//             llyods.Transactions.Add(
//                 new Transaction
//                 {
//                     Date = DateTime.Parse(col[0]),
//                     From=col[1],
//                     To=col[2],
//                     Narrative=col[3],
//                     Amount=decimal.Parse(col[4]),                
//             });
//         }
//     foreach(var item in llyods.Transactions)
//     {
//         Console.WriteLine(item.Date);
//         Console.WriteLine(item.From);
//         Console.WriteLine(item.To);
//         Console.WriteLine(item.Narrative);
//         Console.WriteLine(item.Amount);
//         Console.WriteLine("=============");
//     }
//    // llyods.Transactions("Rob");
//     var balances = new Dictionary<string,decimal>();
//     foreach(var transaction in llyods.Transactions)
//     {
//         if(!balances.ContainsKey(transaction.From))
//         {
//             balances[transaction.From] = 0;
//         }
//         if(!balances.ContainsKey(transaction.To))
//         {
//             balances[transaction.To] = 0;
//         }
//          balances[transaction.From] -=transaction.Amount;
//          balances[transaction.To] +=transaction.Amount;
//     }
//     // foreach(var balance in balances)
//     // {
//     //     Console.WriteLine($"{balance.Key}  {balance.Value}");
//     // }

// }
// catch (FileNotFoundException)
// {
//     Console.WriteLine("Sorry, that file was not found.");
// }