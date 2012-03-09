using System;
using System.ComponentModel;
using System.Windows.Media;

namespace LostPets.ViewModels {
    public class SocialShareViewModel : INotifyPropertyChanged {
        private Color fillColor = Color.FromArgb(255, 196, 196, 196);
        private string message;

        public Color FillColor {
            get { return fillColor; }
            set {
                fillColor = value;
                NotifyPropertyChanged("FillColor");
            }
        }

        public string Message {
            get { return message; }
            set { message = value; }
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