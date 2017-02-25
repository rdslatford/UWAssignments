using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PhotoKeeper
{
    /// <summary>
    /// Storage for photograph data
    /// </summary>
    [Serializable]
    class Photograph : INotifyPropertyChanged
    {
        private string _title;
        private string _artist;
        private DateTime _taken;
        private DateTime _added;
        private string _description;
        private List<string> _keywords;
        public string Title
        {
            get { return _title; }
            set { _title = value; NotifyChanged(Title); }
        }
        public string Artist
        {
            get { return _artist; }
            set { _artist = value; NotifyChanged("Artist"); }
        }
        public DateTime Taken
        {
            get { return _taken; }
            set { _taken = value; NotifyChanged("Taken"); }
        }
        public DateTime Added
        {
            get { return _added; }
            set { _added = value; NotifyChanged("Added"); }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; NotifyChanged("Description"); }
        }
        public string ImagePath
        {
            get;
        }
        public List<string> Keywords
        {
            get { return _keywords; }
            set { _keywords = value; NotifyChanged("Keywords"); }
        }
        public Photograph(string title, string artist, DateTime taken, string description, string imagePath, params string[] keywords)
        {
            Title = title;
            Artist = artist;
            Taken = taken;
            Added = DateTime.Now;
            Description = description;
            ImagePath = imagePath;
            Keywords = new List<string>(keywords);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
