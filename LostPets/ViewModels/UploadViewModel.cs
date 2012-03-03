using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LostPets.ViewModels
{
    public class UploadViewModel : INotifyPropertyChanged
    {
        public string Description { get; set; }
        public string Location { get; set; }
        public DateTime DateTime { get; set; }
        private Uri imageUri = new Uri("pet_thumbnail.jpg", UriKind.Relative);
        public Uri ImageUri {
            get { return imageUri; }
            set { imageUri = value;
                NotifyPropertyChanged("ImageUri");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
