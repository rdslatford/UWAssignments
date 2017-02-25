using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BindingControls
{
    class Person : INotifyPropertyChanged
    {
        int _id;
        string _name;

        public int ID
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                NotifyChanged("ID");
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                NotifyChanged("Name");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChanged(string property)
        {
            if (property != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}
