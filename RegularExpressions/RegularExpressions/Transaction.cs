using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressions
{
    class Transaction
    {
        private Dictionary<string, string> _elements;

        public Dictionary<string, string> Elements
        { 
            get
            {
                return _elements;
            }

            set
            {
                _elements = value;
            }
        }

        public Transaction(string elementsText)
        {
            Regex transactionElementPattern = new Regex(@"<(?<tag>[^>]+)>(?<content>[^<>]+?)<\/\k<tag>>");
            MatchCollection transactionElements = transactionElementPattern.Matches(elementsText);

            _elements = new Dictionary<string, string>(transactionElements.Count);
            for (int x = 0; x < transactionElements.Count; x++)
            {
                _elements.Add(
                    transactionElements[x].Groups["tag"].ToString(),
                    transactionElements[x].Groups["content"].ToString()
                    );
            }

        }

        public override string ToString()
        {
            string description = new string('_',31) + Environment.NewLine;
            foreach (var element in Elements)
            {
                description += string.Format("|{0,-14}|{1,-14}|", element.Key, element.Value) + Environment.NewLine;
            }
            description += new String('_', 31) + Environment.NewLine;
            return description;
        }

    }
}
