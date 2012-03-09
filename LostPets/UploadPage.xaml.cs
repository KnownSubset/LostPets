using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows;
using System.Windows.Navigation;
using LostPets.Services;
using LostPets.ViewModels;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace LostPets {
    public partial class UploadPage : PhoneApplicationPage {
        private readonly IsolatedStorageSettings isolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings;
        private readonly UploadViewModel uploadViewModel = new UploadViewModel();
        private bool firstTimeEnteredDescription = true;
        private bool firstTimeEnteredLocation = true;

        public UploadPage() {
            uploadViewModel.Description = "color/size/sex";
            uploadViewModel.Location = "neighborhood or address";
            uploadViewModel.DateTime = DateTime.Now;
            InitializeComponent();
            // Set the data context of the listbox control to the sample data
            DataContext = uploadViewModel;
            Loaded += MainPage_Loaded;
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e) {
            if (!App.ViewModel.IsDataLoaded) {
                App.ViewModel.LoadData();
            }
        }

        private void GotoGallery(object sender, RoutedEventArgs e) {
            try {
                var photoChooserTask = new PhotoChooserTask {ShowCamera = true};
                photoChooserTask.Show();
                photoChooserTask.Completed += ReadMetadataFromImage;
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
            }
        }

        private void ReadMetadataFromImage(object sender, PhotoResult photoResult) {
            //Setting the fileName
            string fileName = "myWP7.dat";
            new IsolatedStorageService().WriteOutToFile(fileName, photoResult.ChosenPhoto);
            isolatedStorageSettings.Remove("image");
            isolatedStorageSettings["image"] = photoResult.ChosenPhoto;
            uploadViewModel.ImageUri = new Uri(photoResult.OriginalFileName);
        }

        private void BreedTextBoxTouchEvent(object sender, GestureEventArgs e) {
            NavigationService.Navigate(new Uri("/BreedPivotPage.xaml", UriKind.Relative));
            NavigationService.Navigating += NavigationService_Navigating;
        }

        private void NavigationService_Navigating(object sender, NavigatingCancelEventArgs e) {
            string breed;
            if (isolatedStorageSettings.TryGetValue("breed", out breed)) {
                uploadViewModel.Breed = breed;
                uploadViewModel.IsDogOrCat = (DogOrCat) Enum.Parse(typeof (DogOrCat), isolatedStorageSettings["dogOrCat"] as string, true);
                isolatedStorageSettings.Remove("breed");
            }
        }

        private void EnteredDescriptionTextBox(object sender, GestureEventArgs e) {
            if (firstTimeEnteredDescription) {
                firstTimeEnteredDescription = false;
                uploadViewModel.Description = string.Empty;
            }
        }

        private void EnteredLocationTextBox(object sender, GestureEventArgs e) {
            if (firstTimeEnteredLocation) {
                firstTimeEnteredLocation = false;
                uploadViewModel.Location = string.Empty;
            }
        }

        private void UploadClick(object sender, EventArgs e) {
            try {
                Pet pet = uploadViewModel.Pet();
                isolatedStorageSettings.Remove("pet");
                isolatedStorageSettings.Add("pet", pet);
                isolatedStorageSettings.Save();
                string petUrl = new PetUploader().Upload(pet);
                isolatedStorageSettings.Remove("petUrl");
                isolatedStorageSettings.Add("petUrl", petUrl);
                isolatedStorageSettings.Save();
                NavigationService.Navigate(new Uri("/SharePage.xaml", UriKind.Relative));
            } catch (Exception exception) {
                MessageBox.Show(exception.Message);
                MessageBox.Show(exception.StackTrace);
            }
        }
    }

    internal class ExifReader : ExifLib.ExifReader {
        public ExifReader(Stream stream) : base(stream) {}
    }
}