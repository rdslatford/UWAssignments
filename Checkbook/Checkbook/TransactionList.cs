using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Checkbook
{
    public class TransactionList : List<Transaction>
    {
        public TransactionList (string filepath)
        {
            StreamReader transactionsFile = new StreamReader(filepath);
            string input = transactionsFile.ReadToEnd();

            Regex transactionsPattern = new Regex(@"<Transaction>.*?<\/Transaction>");
            MatchCollection transactions = transactionsPattern.Matches(input);

            foreach (Match transaction in transactions)
            {
                string elementsText = transaction.ToString();

                Regex transactionElementPattern = new Regex(@"<(?<tag>[^>]+)>(?<content>[^<>]+?)<\/\k<tag>>");
                MatchCollection transactionElements = transactionElementPattern.Matches(elementsText);

                Dictionary<string, string> elements = new Dictionary<string, string>(transactionElements.Count);
                foreach (Match element in transactionElements)
                {

                    elements.Add(
                        element.Groups["tag"].ToString(),
                        element.Groups["content"].ToString()
                        );
                }

                switch (elements["Type"])
                {
                    case "Check":
                        Transaction check = new Check(
                            DateTime.Parse(elements["Date"]),
                            elements["Description"],
                            elements["Category"],
                            Decimal.Parse(elements["Amount"]),
                            elements["Checknum"]
                            );
                        Add(check);
                        break;
                    case "Debit":
                        Transaction debit = new Debit(
                            DateTime.Parse(elements["Date"]),
                            elements["Description"],
                            elements["Category"],
                            Decimal.Parse(elements["Amount"])
                            );
                        Add(debit);
                        break;
                    case "Deposit":
                        Transaction deposit = new Deposit(
                            DateTime.Parse(elements["Date"]),
                            elements["Description"],
                            elements["Category"],
                            Decimal.Parse(elements["Amount"])
                            );
                        Add(deposit);
                        break;
                }
            }
        }

        public void Save (string filepath)
        {
            using (StreamWriter output = new StreamWriter(filepath))
            {
                output.Write("<Transactions>");
                foreach (Transaction tran in this)
                {
                    output.Write("<Transaction>");
                    output.Write(tran.XML);
                    output.Write("</Transaction>");
                }
                output.Write("</Transactions>");
            }
        }
        public decimal Balance
        {
            get
            {
                decimal bal = 0;
                foreach (Transaction t in this) { bal += t.CalculationAmount; }
                return bal;
            }
        }
    }
}
