﻿using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace LostPets
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            this.Items = new ObservableCollection<ItemViewModel>();
            this.PetsNearYou = new ObservableCollection<Pet>();
        }

        /// <summary>
        /// A collection for ItemViewModel objects.
        /// </summary>
        public ObservableCollection<ItemViewModel> Items { get; private set; }
        public ObservableCollection<Pet> PetsNearYou { get; private set; }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates and adds a few ItemViewModel objects into the Items collection.
        /// </summary>
        public void LoadData()
        {
            // Sample data; replace with real data
            //this.Items.Add(new ItemViewModel() { LineOne = "find pets", Details = "Maecenas praesent accumsan bibendum", LineThree = "Facilisi faucibus habitant inceptos interdum lobortis nascetur pharetra placerat pulvinar sagittis senectus sociosqu" });
            this.Items.Add(new ItemViewModel() { LineOne = "rescue stray", Details = "upload info on stray", GoToUri = "/UploadPage.xaml" });
            this.Items.Add(new ItemViewModel() { LineOne = "report missing", Details = "upload info on your missing pet", GoToUri = "/MissingUploadPage.xaml" });
            this.Items.Add(new ItemViewModel() { LineOne = "settings", Details = "", GoToUri = "/Settings.xaml" });
            this.Items.Add(new ItemViewModel() { LineOne = "share", Details = "", GoToUri = "/SharePage.xaml" });

            this.PetsNearYou.Add(new Dog() { Breed = "Beagle", PictureUri = new Uri("Images/pet_thumbnail.jpg", UriKind.Relative), FoundAround = "1234 Downing St" });
            this.IsDataLoaded = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}