using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Checkbook
{
    /// <summary>
    /// Interaction logic for EditTransaction.xaml
    /// </summary>
    public partial class EditTransaction : Window
    {
        private Transaction _transaction;
        public EditTransaction(Transaction tr, CategoryList cl)
        {
            InitializeComponent();
            _transaction = tr;
            var categories = from category in cl
                             select category.Title;
            categoryComboBox.ItemsSource = categories;
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {

            _transaction.Checknum = checkNumTextBox.Text;
            _transaction.Description = descriptionTextBox.Text;
            _transaction.Amount = decimal.Parse(amountTextBox.Text);
            _transaction.Category = categoryComboBox.Text;
            _transaction.Date = DateTime.Parse(dateTextBox.Text);
            this.DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            IDTextBox.Text = _transaction.Id.ToString();
            typeTextBox.Text = _transaction.Type.ToString();
            checkNumTextBox.Text = _transaction.Checknum.ToString();
            if (string.IsNullOrEmpty(_transaction.Checknum))
                checkNumTextBox.IsReadOnly = true;

            descriptionTextBox.Text = _transaction.Description.ToString();
            dateTextBox.Text = _transaction.Date.ToString("MM/dd/yyyy");
            categoryComboBox.Text = _transaction.Category;
            amountTextBox.Text = _transaction.Amount.ToString("C");
            amountInWordsTextBox.Text = _transaction.AmountString;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void amountTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string currentText = amountTextBox.Text;
            decimal amount;
            if (decimal.TryParse(currentText, out amount))
            {
                amountTextBox.Text = amount.ToString("C");
            }
            else
            {
                amountTextBox.Clear();
                //MessageBox.Show("Please enter a valid amount");
            }
        }
    }
}
