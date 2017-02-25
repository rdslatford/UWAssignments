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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Checkbook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TransactionList _transactionList;
        private CategoryList _categoryList;
        private bool _compareByValue = true;

        private IComparer<Category> NextComparer
        {
            get
            {
                _compareByValue = !_compareByValue;
                if (_compareByValue)
                    return new Category_CompareByValue();
                else
                    return new Category_CompareByTitle();
            }
        }
        
        public MainWindow()
        {
            InitializeComponent();
            _transactionList = new TransactionList(@"C:\Users\rdsla\Desktop\NewTransactions.txt");
            _categoryList = new CategoryList(_transactionList);
            _compareByValue = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            transactionListBox.ItemsSource = _transactionList;
            Balance.Content = _transactionList.Balance.ToString("C");
            categoryListBox.ItemsSource = _categoryList;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            _categoryList.Reverse();
            categoryListBox.ItemsSource = null;
            categoryListBox.ItemsSource = _categoryList;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            _categoryList.Sort(NextComparer);
            categoryListBox.ItemsSource = null;
            categoryListBox.ItemsSource = _categoryList;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            _transactionList.Save(@"C:\Users\rdsla\Desktop\NewTransactions.txt");
        }

        private void transactionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTransaction();
        }

        private void UpdateTransaction()
        {
            int i = transactionListBox.SelectedIndex;
            if (i < 0)
            {
                i = 0;
            }
            Transaction t = _transactionList[i];

            IDTextBox.Text = t.Id.ToString();
            typeTextBox.Text = t.Type.ToString();
            checkNumTextBox.Text = t.Checknum.ToString();
            descriptionTextBox.Text = t.Description.ToString();
            dateTextBox.Text = t.Date.ToString("MM/dd/yyyy");
            amountTextBox.Text = t.Amount.ToString("C");
            categoryTextBox.Text = t.Category.ToString();
            amountInWordsTextBox.Text = t.AmountString;
        }

        private void editButton_Click(object sender, RoutedEventArgs e)
        {
            int i = transactionListBox.SelectedIndex;
            if (i < 0)
            {
                i = 0;
            }
            Transaction t = _transactionList[i];
            EditTransaction editWindow = new EditTransaction(t, _categoryList);

            Nullable<bool> dialogResult = editWindow.ShowDialog();
            if (dialogResult == true)
            {
                transactionListBox.ItemsSource = null;
                transactionListBox.ItemsSource = _transactionList;
            }
        }
    }
}
