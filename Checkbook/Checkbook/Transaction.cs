using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkbook
{
    public enum TransactionType { Check, Debit, Deposit }
    public abstract class Transaction : IComparable<Transaction>
    {
        private int _id;
        private TransactionType _type;
        private string _category;
        private DateTime _date;
        private string _description;
        private decimal _amount;
        private string _checknum;

        public int Id {
            get { return _id; }
            private set { _id = value; }
        }
        public TransactionType Type {
            get { return _type; }
            set { _type = value; }
        }
        public string Category {
            get { return _category; }
            set { _category = value; }
        }
        public DateTime Date {
            get { return _date; }
            set { _date = value; }
        }
        public string Description {
            get { return _description; }
            set { _description = value; }
        }
        public decimal Amount {
            get { return _amount; }
            set { _amount = value; }
        }
        public string Checknum {
            get { return _checknum; }
            set { _checknum = value; }
        }

        // Property creates and returns the amount string using the functions below
        public string AmountString
        {
            get
            {
                StringBuilder strAmt = new StringBuilder();
                int dollars = (int)Amount;
                int cents = (int)(Amount * 100 % 100);
                strAmt.Append(amtToString(dollars) + " and " + amtToString(cents, true) + "/100s Dollars");
                strAmt[0] = char.ToUpper(strAmt[0]);
                return strAmt.ToString();
            }
        }

        // Return dollars in text ("Three hundred seventy two"), or if useDigits, return "372" 
        private string amtToString(int amt, bool useDigits = false)
        {
            if (amt == 0) return (useDigits ? "00" : "zero");     // If amount is zero, no need to go further
            if (useDigits) return amt.ToString();                 // If using digits return just the digits

            StringBuilder strAmt = new StringBuilder();           // The full string goes in here
            int[] groups = { 1000000000, 1000000, 1000, 1 };       // Our words repeat in 3s (thousand, million)

            foreach (int grp in groups)                            // For each sub-group of 3
            {
                if (amt < grp) continue;                            // If nothing in this sub-group, skip it
                int v = amt / grp;                                  // Separate the 0-999 portion of grouping
                hundredsToString(v, strAmt, grp);                   // Append the current grouping
                amt = amt % grp;                                    // Remove value we're printing from left to do
            }
            return strAmt.ToString();                             // Return the stringified amount
        }

        // Covert a "hundreds" group into text
        // Our number system repeats every 3 digits (thousands, millions, billions, etc)
        // This processes one of those 3 digit groups.
        // params: amt = The amount to print. Must be 0-999
        //         strAmt = The StringBuilder object in which to write the text
        //         group = The grouping (1,1000,1000000,1000000000)
        private void hundredsToString(int amt, StringBuilder strAmt, int grouping)
        {
            String[] label = { "", "thousand", "million", "billion" };  // The grouping labels
            int group = 0;                        // Determine which group to use...
            if (grouping >= 1000) group++;
            if (grouping >= 1000000) group++;
            if (grouping >= 1000000000) group++;

            if (amt >= 100)                       // Do we need a "hundreds" value for this number
            {
                int h = amt / 100;                  // Yes. Strip out the hundreds from the rest of the nbr
                numberToString(h, strAmt);           // Add the hundreds value
                appendWithSpace(strAmt, "hundred");
                amt = amt % 100;                    // Remove what we've already printed
            }
            numberToString(amt, strAmt);          // Print the remaining value along with the grouping
            appendWithSpace(strAmt, label[group]);
            return;
        }

        // Convert a number (0-999) to a string.
        // Params: amt = The number to convert
        //         strAmt = The StringBuilder where the string value should be added
        private void numberToString(int amt, StringBuilder strAmt)
        {
            String[] nums = { "", "one", "two", "three", "four", "five", "six", "seven", "eight",
    "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen",
    "seventeen", "eighteen", "nineteen" };
            String[] tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy",
    "eighty", "ninety" };

            if (amt < 20)       // We have special cases for numbers under twenty
            {
                appendWithSpace(strAmt, nums[amt]);
            }
            else          // Otherwise use the tens grouping and the remaining number (like sixty five)
            {
                appendWithSpace(strAmt, tens[amt / 10]);
                appendWithSpace(strAmt, nums[amt % 10]);
            }
        }

        // Append a string to the StringBuilder, adding a space first if there's any existing text
        private void appendWithSpace(StringBuilder sb, String s)
        {
            if (s.Length == 0) return;              // If no text to append, return
            if (sb.Length > 0) sb.Append(" ");      // If there's any existing text, add a space
            sb.Append(s);                           // Append the text to the stringBuilder
        }

        private static int _lastId = 0;
        private int nextId() { return ++_lastId; }
        public override string ToString()
        {
            return Date.ToShortDateString() + "\t" + Type.ToString() + "\t" + Amount.ToString("C");
        }
        public String TransactionSummary { get { return ToString(); } }
        public Transaction(DateTime dateTime, TransactionType type, string description, 
            string category, decimal amount, string checknum = "")
        {
            _id = nextId();
            Date = dateTime;
            Type = type;
            Description = description;
            Category = category;
            Amount = amount;
            Checknum = checknum;
        }
        public abstract decimal CalculationAmount { get; }
        public virtual string XML
        {
            get
            {
                StringBuilder output = new StringBuilder();
                //ID
                output.Append("<Id>" + Id.ToString() + "</Id>");
                //Date
                output.Append("<Date>" + String.Format("{0:M/d/yyyy}", Date) + "</Date>");
                //Type
                output.Append("<Type>" + Type + "</Type>");
                //Description
                output.Append("<Description>" + Description + "</Description>");
                //Category
                output.Append("<Category>" + Category + "</Category>");
                //Amount
                output.Append("<Amount>" + Amount.ToString() + "</Amount>");
                return output.ToString();
            }
        }

        public int CompareTo(Transaction other)
        {
            if (other == null) return 1;

            return Category.CompareTo(other.Category);
        }
    }

    public class Check : Transaction
    {
        protected const decimal checkCharge = .10M;
        public Check(DateTime dateTime, string description, string category, decimal amount, String checknum) 
            : base(dateTime, TransactionType.Check, description, category, amount, checknum) { }
        public override decimal CalculationAmount
        {
            get { return 0 - (Amount + checkCharge);}
        }

        public override string XML
        {
            get
            {
                StringBuilder output = new StringBuilder();
                //ID
                output.Append("<ID>" + Id.ToString() + "</ID>" );
                //Date
                output.Append("<Date>" + String.Format("{0:M/d/yyyy}", Date) + "</Date>");
                //Type
                output.Append("<Type>" + Type + "</Type>");
                //Description
                output.Append("<Description>" + Description + "</Description>");
                //Category
                output.Append("<Category>" + Category + "</Category>");
                //Amount
                output.Append("<Amount>" + Amount.ToString() + "</Amount>");
                //Checknum
                output.Append("<Checknum>" + Checknum + "</Checknum>");
                return output.ToString();
            }
        }
            
    }
    public class Debit : Transaction
    {
        public Debit(DateTime dateTime, string description, string category, decimal amount) 
            : base(dateTime, TransactionType.Debit, description, category, amount) { }
        override public decimal CalculationAmount
        {
            get { return 0 - Amount; }
        }
    }
    public class Deposit : Transaction
    {
        public Deposit(DateTime dateTime, string description, string category, decimal amount) 
            :base(dateTime, TransactionType.Deposit, description, category, amount) { }
        override public decimal CalculationAmount { get { return Amount; } }
    }
}
