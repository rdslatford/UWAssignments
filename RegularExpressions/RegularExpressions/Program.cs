using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            TransactionGroup log = new TransactionGroup(@"C:\Users\rdsla\Desktop\Transactions.txt");

            Console.WriteLine(log);
            //StreamReader transactionsFile = new StreamReader(@"C:\Users\rdsla\Desktop\Transactions.txt");
            //string input = transactionsFile.ReadToEnd();

            //// Is it safe to just pull the <Transaction> elements, or is it better to first pull the <Transactions> element?
            //// Regex transactionsGroup = new Regex(@"<Transactions>(.*)<Transactions>");

            //Regex transactionsPattern = new Regex(@"<Transaction>.*?<\/Transaction>");
            //MatchCollection transactions = transactionsPattern.Matches(input);

            //Regex transactionElementPattern = new Regex(@"<(?<tag>[^>]+)>(?<content>[^<>]+?)<\/\k<tag>>");
            //for (int i = 0; i < transactions.Count; i++)
            //{
            //    Console.WriteLine("Transaction " + i + ":");
            //    MatchCollection transactionElements = transactionElementPattern.Matches(transactions[i].ToString());
            //    for (int x = 0; x < transactionElements.Count; x++)
            //    {
            //        Console.Write("  " + transactionElements[x].Groups["tag"].ToString() + ":");
            //        Console.WriteLine("\t" + transactionElements[x].Groups["content"].ToString());
            //        Console.WriteLine();
            //    }
                
            //    //Console.WriteLine(transactions[i].ToString());
            //}

            

            Console.ReadKey();
        }
    }
}
