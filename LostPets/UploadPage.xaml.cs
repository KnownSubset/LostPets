using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace LostPets
{
    public partial class UploadPage : PhoneApplicationPage
    {
        public UploadPage()
        {
            InitializeComponent();
        }

        public String Description { get; set; }
        public String Location { get; set; }
        public DateTime DateTime { get; set; }

        private void GotoGallery(object sender, RoutedEventArgs e)
        {

        }
        private void TakePhoto(object sender, RoutedEventArgs e)
        {

        }
    }
}