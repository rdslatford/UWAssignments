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
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.ObjectModel;

namespace PhotoKeeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Photograph> _photos;

        ObservableCollection<Photograph> Photos
        {
            get { return _photos; }
            set { _photos = value; }
        }

        string _currentFile;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Photos = new ObservableCollection<Photograph>();
            //Photograph test = new Photograph("Test Photo", "Robert Slatford", DateTime.Now, "Default description", @"C:\temp\picX.png", "Cat");
            //Photograph test2 = new Photograph("Test Photo", "Katie Slatford", DateTime.Now, "Default description", @"C:\temp\picX.png", "Dog");
            //Photograph test3 = new Photograph("Test Photo", "Reginald Slatford", DateTime.Now, "Default description", @"C:\temp\picX.png", "Peanut");
            //Photograph test4 = new Photograph("Test Photo", "Nikki Slatford", DateTime.Now, "Default description", @"C:\temp\picX.png", "Potato");
            //_photos = new List<Photograph>() { test, test2, test3, test4 };

            //string searchString = "Robert, Katie, Nikki";

            //photographDataGrid.DataContext = _photos;
            //photographDataGrid.SelectedIndex = 0;


            //photographDataGrid.DataContext = photos.Where(x => x.Artist.Contains(searchString)
            //                                               || x.Title.Contains(searchString)
            //                                               || x.Description.Contains(searchString));            
            //image.DataContext = (Photograph)photographDataGrid.SelectedItem;
        }

        private void photographDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            image.DataContext = photographDataGrid.SelectedItem;
            keywordsListBox.DataContext = photographDataGrid.SelectedItem;
            addedTextBox.DataContext = photographDataGrid.SelectedItem;
            imagePathLabel.DataContext = photographDataGrid.SelectedItem;
            artistTextBox.DataContext = photographDataGrid.SelectedItem;
        }

        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void searchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string[] strings = searchTextBox.Text.Split(',').Select(s => s.Trim()).ToArray();

            if (strings.Count() < 1)
                photographDataGrid.DataContext = _photos;
            else
            {
                    photographDataGrid.DataContext = _photos.Where(photo => strings.Any(searchStr => photo.Artist.Contains(searchStr))
                                                                 || strings.Any(searchStr => photo.Title.Contains(searchStr))
                                                                 || strings.Any(searchStr => photo.Description.Contains(searchStr))
                                                                 //|| strings.Any(searchStr => x.Keywords.Contains(searchStr))); -- Required exact match
                                                                 || strings.Any(searchStr => photo.Keywords.Any(keyword => keyword.Contains(searchStr))));
            }
            photographDataGrid.SelectedIndex = 0;
        }

        private void newMenuItem_Click(object sender, RoutedEventArgs e)
        {
            AddPhoto dialog = new AddPhoto();
            if (dialog.ShowDialog() == true)
                _photos.Add(dialog.NewPhoto);
            RebindControls();
        }

        private void RebindControls()
        {
            photographDataGrid.DataContext = null;
            photographDataGrid.DataContext = _photos;
            photographDataGrid.SelectedIndex = 0;
        }

        private void addKeywordButton_Click(object sender, RoutedEventArgs e)
        {
            if (photographDataGrid.SelectedIndex != -1)
            {
                Photograph currentPhoto = (Photograph)photographDataGrid.SelectedItem;
                currentPhoto.Keywords.Add(keywordTextBox.Text);
                keywordsListBox.DataContext = null;
                keywordsListBox.DataContext = photographDataGrid.SelectedItem;
            }   
        }

        private void saveAsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Binary files (.bin)|*.bin";
            if (sfd.ShowDialog() == true)
            {
                _currentFile = sfd.FileName;
                using (Stream stream = File.Open(_currentFile, FileMode.Create))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, _photos);
                }
            }
        }

        private void openMenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Binary files (.bin)|*.bin";
            if (ofd.ShowDialog() == true)
            {
                _currentFile = ofd.FileName;
                using (Stream stream = File.Open(_currentFile, FileMode.Open))
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    _photos = (ObservableCollection<Photograph>)formatter.Deserialize(stream);
                    RebindControls();
                }
            }
        }

        private void saveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (_currentFile == null)
                return;

            using (Stream stream = File.Open(_currentFile, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, _photos);
            }
        }

    }
}
