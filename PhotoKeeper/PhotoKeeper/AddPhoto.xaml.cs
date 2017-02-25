using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PhotoKeeper
{
    /// <summary>
    /// Interaction logic for AddPhoto.xaml
    /// </summary>
    public partial class AddPhoto : Window
    {
        internal Photograph NewPhoto { get; set; }
        public AddPhoto()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            NewPhoto = new Photograph(
                titleTextBox.Text,
                artistTextBox.Text,
                takenDatePicker.SelectedDate.Value,
                descriptionTextBox.Text,
                imagePathTextBox.Text,
                keywordsTextBox.Text.Split(',').Select(keyword => keyword.Trim()).ToArray()
                );
            this.DialogResult = true;
        }

        private void fileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
                imagePathTextBox.Text = fileDialog.FileName;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            takenDatePicker.SelectedDate = DateTime.Now;
        }
    }
}
