using System;
using System.ComponentModel;
using System.Windows.Media;

namespace LostPets.ViewModels {
    public class SocialShareViewModel : INotifyPropertyChanged {
        private Brush fillColor = new SolidColorBrush(Colors.DarkGray);
        private string message;

        public Brush FillColor {
            get { return fillColor; }
            set {
                fillColor = value;
                NotifyPropertyChanged("FillColor");
            }
        }

        public string Message {
            get { return message; }
            set {
                message = value;
                NotifyPropertyChanged("Message");
            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}