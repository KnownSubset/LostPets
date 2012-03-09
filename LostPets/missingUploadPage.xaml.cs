using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using LostPets.Services;
using LostPets.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace LostPets {
    public partial class MissingUploadPage : PhoneApplicationPage {
        private readonly MissingPetUploadViewModel missingPetUploadViewModel = new MissingPetUploadViewModel();
        private readonly IList<string> visited = new List<string>();
        private readonly IsolatedStorageSettings isolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings;

        public MissingUploadPage() {
            missingPetUploadViewModel.Name = "pet's name";
            missingPetUploadViewModel.Contact = "owner's name";
            missingPetUploadViewModel.ContactMethod = "phone #/email address";
            missingPetUploadViewModel.Description = "color/size/sex";
            missingPetUploadViewModel.Location = "neighborhood or address";
            missingPetUploadViewModel.DateTime = DateTime.Now;
            InitializeComponent();
            // Set the data context of the listbox control to the sample data
            DataContext = missingPetUploadViewModel;
            Loaded += MainPage_Loaded;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e) {
            if (!App.ViewModel.IsDataLoaded) {
                App.ViewModel.LoadData();
            }
        }

        private void GotoGallery(object sender, RoutedEventArgs e) {
            var photoChooserTask = new PhotoChooserTask {ShowCamera = true};
            photoChooserTask.Show();
            photoChooserTask.Completed += ReadMetadataFromImage;
        }

        private void ReadMetadataFromImage(object sender, PhotoResult photoResult)
        {
            //Setting the fileName
            string fileName = "myWP7.dat";
            new IsolatedStorageService().WriteOutToFile(fileName, photoResult.ChosenPhoto);
            isolatedStorageSettings.Remove("image");
            isolatedStorageSettings["image"] = photoResult.ChosenPhoto;
            missingPetUploadViewModel.ImageUri = new Uri(photoResult.OriginalFileName);
        }

        private void BreedTextBoxTouchEvent(object sender, GestureEventArgs e) {
            NavigationService.Navigate(new Uri("/BreedPivotPage.xaml", UriKind.Relative));
            NavigationService.Navigating += NavigationService_Navigating;
        }

        private void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e) {
            if (isolatedStorageSettings.Contains("breed")) {
                missingPetUploadViewModel.Breed = isolatedStorageSettings["breed"] as string;
                missingPetUploadViewModel.IsDogOrCat = (DogOrCat)Enum.Parse(typeof(DogOrCat), isolatedStorageSettings["dogOrCat"] as string, true);
                isolatedStorageSettings.Remove("breed");
                isolatedStorageSettings.Remove("dogOrCat");
                isolatedStorageSettings.Save();
            }
        }

        private void WipeOutTextOnFirstEntry(object sender, GestureEventArgs e) {
            var textBox = sender as TextBox;
            if (!visited.Contains(textBox.Name)) {
                visited.Add(textBox.Name);
                textBox.Text = "";
            }
        }

        private void UploadClick(object sender, EventArgs e) {
            Pet pet = missingPetUploadViewModel.Pet();
            isolatedStorageSettings.Remove("pet");
            isolatedStorageSettings.Add("pet", pet);
            var petUrl = new PetUploader().Upload(pet);
            isolatedStorageSettings.Add("petUrl", petUrl);
            isolatedStorageSettings.Save();
            NavigationService.Navigate(new Uri("/SharePage.xaml", UriKind.Relative));
        }
    }
}