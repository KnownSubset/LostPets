using System;
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
            UploadViewModel.breed = addedItem.DogBreed.ToString();
        }

        private void CatSelected(object sender, SelectionChangedEventArgs eventArgs) {
            var addedItem = eventArgs.AddedItems[0] as Cat;
            UploadViewModel.breed = addedItem.CatBreed.ToString();
        }
    }
}