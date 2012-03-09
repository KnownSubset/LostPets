using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LostPets.ViewModels {
    public class MissingPetUploadViewModel : INotifyPropertyChanged {
        private string breed = "unknown";
        private string name;
        private string contact;
        private string contactMethod;
        private string description;
        private string location;
        private IEnumerable<Status> statuses = new Collection<Status>{Status.Lost, Status.AtShelter};
        private Uri imageUri = new Uri("Images/pet_thumbnail.jpg", UriKind.Relative);
        public DateTime DateTime { get; set; }

        public string Name {
            get { return name; }
            set {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Contact {
            get { return contact; }
            set {
                contact = value;
                NotifyPropertyChanged("Contact");
            }
        }

        public string ContactMethod {
            get { return contactMethod; }
            set {
                contactMethod = value;
                NotifyPropertyChanged("ContactMethod");
            }
        }

        public string Description {
            get { return description; }
            set {
                description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public string Location {
            get { return location; }
            set {
                location = value;
                NotifyPropertyChanged("Location");
            }
        }

        public Uri ImageUri {
            get { return imageUri; }
            set {
                imageUri = value;
                NotifyPropertyChanged("ImageUri");
            }
        }

        public string Breed {
            get { return breed; }
            set {
                breed = value;
                NotifyPropertyChanged("Breed");
            }
        }

        public IEnumerable<Status> Statuses {
            get { return statuses; }
            set { statuses = value; }
        }

        private Status Status { get; set; }
        public DogOrCat IsDogOrCat { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public Pet Pet() {
            Pet pet =  DogOrCat.Dog.Equals(IsDogOrCat) ? (Pet) new Dog() : new Cat();
            pet.Breed = Breed;
            pet.FoundAround = location;
            pet.PictureUri = imageUri;
            pet.Status = Status;
            pet.DateWhen = DateTime;
            pet.Description = description;
            pet.Contact = contact;
            pet.ContactMethod = contactMethod;
            pet.Name = name;
            return pet;
        }
    }
}