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

namespace LostPets.ViewModels {
    public class UploadViewModel : INotifyPropertyChanged {
        private string description;

        private string location;

        public DateTime DateTime { get; set; }
        private Uri imageUri = new Uri("Images/pet_thumbnail.jpg", UriKind.Relative);
        private string breed = "unknown";

        public string Description {
            get { return description; }
            set {
                description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public string Location {
            get { return location; }
            set {
                location = value;
                NotifyPropertyChanged("Location");
            }
        }

        public Uri ImageUri {
            get { return imageUri; }
            set {
                imageUri = value;
                NotifyPropertyChanged("ImageUri");
            }
        }

        public string Breed {
            get { return breed; }
            set {
                breed = value;
                NotifyPropertyChanged("Breed");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}