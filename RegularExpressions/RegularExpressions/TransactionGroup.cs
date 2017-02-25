using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressions
{
    class TransactionGroup
    {
        private List<Transaction> _transactions = new List<Transaction>();

        public List<Transaction> Transactions
        {
            get
            {
                return _transactions;
            }
            set
            {
                _transactions = value;
            }
        }
        public TransactionGroup(string filepath)
        {
            StreamReader transactionsFile = new StreamReader(filepath);
            string input = transactionsFile.ReadToEnd();

            Regex transactionsPattern = new Regex(@"<Transaction>.*?<\/Transaction>");
            MatchCollection transactions = transactionsPattern.Matches(input);

            for (int i = 0; i < transactions.Count; i++)
            {
                _transactions.Add(new Transaction(transactions[i].ToString()));
            }
        }

        public override string ToString()
        {
            string description = "";
            foreach (Transaction trans in Transactions)
            {
                description += trans + Environment.NewLine;
            }
            return description;
        }
    }
}
