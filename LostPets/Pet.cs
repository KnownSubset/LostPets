using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LostPets {
    public class Pet {
        public DogOrCat DogOrCat { get; set; }
        public Color FurColor { get; set; }
        public Size Size { get; set; }
        public string PictureUri { get; set; }
        public string FoundAround { get; set; }
        public string Breed { get; set; }
    }

    public class Dog : Pet {
        public Dog() {
            DogOrCat = DogOrCat.Dog;
        }
    }
    
    public class Cat : Pet {
        public Cat() {
            DogOrCat = DogOrCat.Cat;
        }
    }

    public enum DogOrCat {
        Dog,
        Cat
    }

    public enum Size {
        Small,
        Medium,
        Large,
    }
}