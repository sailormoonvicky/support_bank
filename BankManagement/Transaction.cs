using System.Runtime;

namespace SupportBank.BankManagement;
public class Transaction{
    public string Date{get;set;}
    public string From{get;set;}
    public string To{get;set;}
    public string Narrative{get;set;}
    public decimal Amount{get;set;}

    public override string ToString()
    {
        return $"{Date} From: {From} To: {To} Narrative: {Narrative} Amount: {Amount}";
    }
}
