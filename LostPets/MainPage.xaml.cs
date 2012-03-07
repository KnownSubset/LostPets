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
using System.Windows.Navigation;
using System.Windows.Shapes;
using LostPets.ViewModels;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace LostPets
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Set the data context of the listbox control to the sample data
            DataContext = App.ViewModel;
            this.Loaded += MainPage_Loaded;
            
        }

        // Load data for the ViewModel Items
        private void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (!App.ViewModel.IsDataLoaded)
            {
                App.ViewModel.LoadData();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs selectionChangedEventArgs)
        {
            var listBox = sender as ListBox;
            if (listBox.SelectedItem != null) {
                var itemViewModel = listBox.SelectedItem as ItemViewModel;
                NavigationService.Navigate(new Uri(itemViewModel.GoToUri, UriKind.Relative));
                listBox.SelectedItem = null;
            }
        }

        private void ShareClick(object sender, RoutedEventArgs routedEventArgs) {
            NavigationService.Navigate(new Uri("/Share.xaml", UriKind.Relative));
        }

        private void HideClick(object sender, RoutedEventArgs routedEventArgs) {}
        private void FlagClick(object sender, RoutedEventArgs routedEventArgs) {}
    }
}