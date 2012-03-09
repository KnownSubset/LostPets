using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LostPets.ViewModels {
    public class UploadViewModel : INotifyPropertyChanged {
        private string breed = "unknown";
        private string description;
        private Uri imageUri = new Uri("Images/pet_thumbnail.jpg", UriKind.Relative);
        private string location;

        public IEnumerable<Size> Sizes {
            get { return new Collection<Size> {Size.Small, Size.Medium, Size.Large}; }
        }

        public Size Size { get; set; }
        public DateTime DateTime { get; set; }
        public DogOrCat IsDogOrCat { get; set; }

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

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void NotifyPropertyChanged(String propertyName) {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler) {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public Pet Pet() {
            Pet pet = DogOrCat.Dog.Equals(IsDogOrCat) ? (Pet) new Dog() : new Cat();
            pet.Breed = Breed;
            pet.FoundAround = location;
            pet.PictureUri = imageUri;
            pet.Status = Status.Stray;
            pet.DateWhen = DateTime;
            pet.Description = description;
            pet.Size = Size;
            pet.Name = "";
            return pet;
        }
    }
}