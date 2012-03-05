using System;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using LostPets.ViewModels;
using Microsoft.Phone.Controls;

namespace LostPets
{
    public partial class BreedPivotPage : PhoneApplicationPage
    {
        public BreedPivotPage()
        {
            InitializeComponent();
            DataContext = new BreedViewModel();
        }

        private void DogSelected(object sender, SelectionChangedEventArgs eventArgs) {
            var addedItem = eventArgs.AddedItems[0] as Dog;
            var settings = IsolatedStorageSettings.ApplicationSettings;
            settings.Remove("breed");
            settings.Add("breed", addedItem.DogBreed.ToString());
            NavigationService.GoBack();
        }

        private void CatSelected(object sender, SelectionChangedEventArgs eventArgs) {
            var addedItem = eventArgs.AddedItems[0] as Cat;
            var settings = IsolatedStorageSettings.ApplicationSettings;
            settings.Remove("breed");
            settings.Add("breed", addedItem.CatBreed.ToString());
            NavigationService.GoBack();
        }
    }
}