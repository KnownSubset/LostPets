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
        const string dogOrCatKey = "dogOrCat";
        private const string breedKey = "breed";

        public BreedPivotPage()
        {
            InitializeComponent();
            DataContext = new BreedViewModel();
        }

        private void PetBreedSelected(object sender, SelectionChangedEventArgs eventArgs) {
            if (eventArgs.AddedItems.Count == 0) return;
            var addedItem = eventArgs.AddedItems[0] as LongListSelector.LongListSelectorItem;
            var pet = addedItem.Item as Pet;
            var settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains(breedKey))
                settings.Remove(breedKey);
            settings[breedKey] = pet.Breed;
            if (settings.Contains(dogOrCatKey))
                settings.Remove(dogOrCatKey);
            settings[dogOrCatKey] = pet.DogOrCat.ToString();
            settings.Save();
            NavigationService.GoBack();
        }
    }
}