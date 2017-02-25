using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkbook
{
    public class CategoryList : List<Category>
    {
        private TransactionList _transactions;
        public CategoryList(TransactionList input)
        {
            _transactions = input;
            Refresh();
        }

        public void AddTransaction(Transaction input)
        {
            Category category = Find(c => c.Title == input.Category);
            if (category == null)
            {
                category = new Category(input.Category, 0.0M);
                this.Add(category);
            }

            category.Amount += input.Amount;
        }

        public void Refresh()
        {
            Clear();
            foreach (Transaction t in _transactions)
            {
                AddTransaction(t);
            }
            _transactions.Sort();
        }
    }

    class Category_CompareByTitle : IComparer<Category>
    {
        public int Compare(Category x, Category y)
        {
            return string.Compare(x.Title,y.Title);
        }
    }
    
    class Category_CompareByValue : IComparer<Category>
    {
        public int Compare(Category x, Category y)
        {
            return decimal.Compare(x.Amount, y.Amount);
        }
    }
}
