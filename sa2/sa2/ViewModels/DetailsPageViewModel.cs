using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace sa2.ViewModels
{
 public   class DetailsPageViewModel: INotifyPropertyChanged
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title != value)
                {
                    _title = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Title"));
                }
            }
            }
        string _Icon;
        public string Icon
        {
            get { return _Icon; }
            set
            {
                if (_Icon != value)
                {
                    _Icon = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("Icon"));
                }
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
