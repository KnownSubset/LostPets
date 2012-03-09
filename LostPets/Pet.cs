using System;
using System.Net;
using System.Runtime.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace LostPets {
    [DataContract]
    public class Pet  {
        [DataMember]
        public DogOrCat DogOrCat { get; set; }
        [DataMember]
        public Size Size { get; set; }
        [DataMember]
        public Uri PictureUri { get; set; }
        [DataMember]
        public string FoundAround { get; set; }
        [DataMember]
        public string Breed { get; set; }
        [DataMember]
        public Status Status { get; set; }
        [DataMember]
        public DateTime DateWhen { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Contact { get; set; }
        [DataMember]
        public string ContactMethod { get; set; }
        [DataMember]
        public string Name { get; set; }
    }

    public class Dog : Pet {
        public Dog() {
            DogOrCat = DogOrCat.Dog;
        }

        public override string ToString() {
            return "Dog " + base.ToString();
        }
    }

    public class Cat : Pet {
        public Cat() {
            DogOrCat = DogOrCat.Cat;
        }

        public override string ToString() {
            return "Cat " + base.ToString();
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

    public enum Status {
        Lost,
        Stray,
        AtShelter
    }

}