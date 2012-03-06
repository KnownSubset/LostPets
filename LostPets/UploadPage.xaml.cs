using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Phone.Tasks;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace LostPets
{
    public partial class UploadPage : PhoneApplicationPage
    {
        private UploadViewModel uploadViewModel = new UploadViewModel();

        public UploadPage() {
            uploadViewModel.Description = "here is data";
            InitializeComponent();
            // Set the data context of the listbox control to the sample data
            DataContext = uploadViewModel;
            this.Loaded += new RoutedEventHandler(MainPage_Loaded);
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void GotoGallery(object sender, RoutedEventArgs e)
        {
            PhotoChooserTask photoChooserTask = new PhotoChooserTask();
            photoChooserTask.ShowCamera = true;
            photoChooserTask.Show();
            photoChooserTask.Completed += ReadMetadataFromImage;
        }

        private void ReadMetadataFromImage(object sender, PhotoResult photoResult) {
            /*var bytes = new List<byte>();
            using (IsolatedStorageFile isStore = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (IsolatedStorageFileStream targetStream = isStore.OpenFile(photoResult.OriginalFileName, FileMode.Create, FileAccess.Write))
                {
                    // Initialize the buffer for 4KB disk pages.
                    var readBuffer = new byte[4096];
                    int bytesRead;

                    // Copy the image to isolated storage. 
                    while ((bytesRead = photoResult.ChosenPhoto.Read(readBuffer, 0, readBuffer.Length)) > 0)
                    {
                        targetStream.Write(readBuffer, 0, bytesRead);
                        bytes.AddRange(readBuffer);
                    }
                    bytes.RemoveRange((int)targetStream.Length, (int)(bytes.Count - targetStream.Length));
                }
            }*/
            var now = DateTime.Now;
            var fileName = photoResult.OriginalFileName;
            uploadViewModel.ImageUri = new Uri(fileName, UriKind.Absolute);
            var fileStream = new FileStream(fileName, FileMode.Open);
            var reader = new ExifReader(fileStream);
            reader.info.FileSize = (int)fileStream.Length;
            reader.info.LoadTime = DateTime.Now - now;
            LocationService.
            uploadViewModel.Location = reader.info.G
            
        }

        private void BreedTextBoxTouchEvent(object sender, GestureEventArgs e) {
            NavigationService.Navigate(new Uri("/BreedPivotPage.xaml", UriKind.Relative));
            NavigationService.Navigating += NavigationService_Navigating;
        }

        void NavigationService_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e) {
            var isolatedStorageSettings = IsolatedStorageSettings.ApplicationSettings;
            var breed = "";
            if (isolatedStorageSettings.TryGetValue("breed", out breed)) {
                uploadViewModel.Breed = breed;
            }
        }

    }

    class ExifReader : ExifLib.ExifReader {
        public ExifReader(Stream stream) : base(stream) {}
    }
}