using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkbook
{
    public class Category
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }

        public Category(string title, decimal amount)
        {
            Title = title;
            Amount = amount;
        }

        public override string ToString()
        {
            return string.Format("{0}\t{1:C}", Title, Amount);
        }
    }
}
