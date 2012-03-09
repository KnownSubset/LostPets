using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace LostPets {
    public class BreedViewModel {
        private readonly List<Cat> catBreeds = new List<Cat> {
                                                                 new Cat {Breed = "abyssinian", PictureUri = new Uri("Images/cats/abyssinian.png", UriKind.Relative)},
                                                                 new Cat {Breed = "burmese", PictureUri = new Uri("Images/cats/burmese.png", UriKind.Relative)},
                                                                 new Cat {Breed = "cornish rex", PictureUri = new Uri("Images/cats/cornish rex.png", UriKind.Relative)},
                                                                 new Cat {Breed = "devon rex", PictureUri = new Uri("Images/cats/devon rex.png", UriKind.Relative)},
                                                                 new Cat {Breed = "egyptian mau", PictureUri = new Uri("Images/cats/egyptian mau.png", UriKind.Relative)},
                                                                 new Cat {Breed = "himalayan", PictureUri = new Uri("Images/cats/himalayan.png", UriKind.Relative)},
                                                                 new Cat {Breed = "maine coon", PictureUri = new Uri("Images/cats/maine coon.png", UriKind.Relative)},
                                                                 new Cat {Breed = "persian", PictureUri = new Uri("Images/cats/persian.png", UriKind.Relative)},
                                                                 new Cat {Breed = "manx", PictureUri = new Uri("Images/cats/manx.png", UriKind.Relative)},
                                                                 new Cat {Breed = "russian blue", PictureUri = new Uri("Images/cats/russian blue.png", UriKind.Relative)},
                                                                 new Cat {Breed = "siamese", PictureUri = new Uri("Images/cats/siamese.png", UriKind.Relative)}
                                                             };

        private readonly List<Dog> dogBreeds = new List<Dog> {
                                                                 new Dog {Breed = "alaskan malamute", PictureUri = new Uri("Images/dogs/alaskan malamute.png", UriKind.Relative)},
                                                                 new Dog {Breed = "austrialian sheppard", PictureUri = new Uri("Images/dogs/austrialian sheppard.png", UriKind.Relative)},
                                                                 new Dog {Breed = "basenji", PictureUri = new Uri("Images/dogs/basenji.png", UriKind.Relative)},
                                                                 new Dog {Breed = "basset hound", PictureUri = new Uri("Images/dogs/basset hound.png", UriKind.Relative)},
                                                                 new Dog {Breed = "beagle", PictureUri = new Uri("Images/dogs/beagle.png", UriKind.Relative)},
                                                                 new Dog {Breed = "bichon", PictureUri = new Uri("Images/dogs/bichon.png", UriKind.Relative)},
                                                                 new Dog {Breed = "bloodhound", PictureUri = new Uri("Images/dogs/bloodhound.png", UriKind.Relative)},
                                                                 new Dog {Breed = "border collie", PictureUri = new Uri("Images/dogs/border collie.png", UriKind.Relative)},
                                                                 new Dog {Breed = "boston terrier", PictureUri = new Uri("Images/dogs/boston terrier.png", UriKind.Relative)},
                                                                 new Dog {Breed = "boxer", PictureUri = new Uri("Images/dogs/boxer.png", UriKind.Relative)},
                                                                 new Dog {Breed = "britteny", PictureUri = new Uri("Images/dogs/britteny.png", UriKind.Relative)},
                                                                 new Dog {Breed = "bull mastiff", PictureUri = new Uri("Images/dogs/bull mastiff.png", UriKind.Relative)},
                                                                 new Dog {Breed = "bull terrier", PictureUri = new Uri("Images/dogs/bull terrier.png", UriKind.Relative)},
                                                                 new Dog {Breed = "bulldog", PictureUri = new Uri("Images/dogs/bulldog.png", UriKind.Relative)},
                                                                 new Dog {Breed = "burmese mountain dog", PictureUri = new Uri("Images/dogs/burmese mountain dog.png", UriKind.Relative)},
                                                                 new Dog {Breed = "cairn terrier", PictureUri = new Uri("Images/dogs/cairn terrier.png", UriKind.Relative)},
                                                                 new Dog {Breed = "cavalier ac spaniel", PictureUri = new Uri("Images/dogs/cavalier ac spaniel.png", UriKind.Relative)},
                                                                 new Dog {Breed = "chihuahua", PictureUri = new Uri("Images/dogs/chihuahua.png", UriKind.Relative)},
                                                                 new Dog {Breed = "chow chow", PictureUri = new Uri("Images/dogs/chow chow.png", UriKind.Relative)},
                                                                 new Dog {Breed = "cocker spaniel", PictureUri = new Uri("Images/dogs/cocker spaniel.png", UriKind.Relative)},
                                                                 new Dog {Breed = "collie", PictureUri = new Uri("Images/dogs/collie.png", UriKind.Relative)},
                                                                 new Dog {Breed = "daschund", PictureUri = new Uri("Images/dogs/daschund.png", UriKind.Relative)},
                                                                 new Dog {Breed = "dobermann pinscher", PictureUri = new Uri("Images/dogs/dobermann pinscher.png", UriKind.Relative)},
                                                                 new Dog {Breed = "english sheep dog", PictureUri = new Uri("Images/dogs/english sheep dog.png", UriKind.Relative)},
                                                                 new Dog {Breed = "english springer spaniel", PictureUri = new Uri("Images/dogs/english springer spaniel.png", UriKind.Relative)},
                                                                 new Dog {Breed = "fox terrier", PictureUri = new Uri("Images/dogs/fox terrier.png", UriKind.Relative)},
                                                                 new Dog {Breed = "french bulldog", PictureUri = new Uri("Images/dogs/french bulldog.png", UriKind.Relative)},
                                                                 new Dog {Breed = "german shephard", PictureUri = new Uri("Images/dogs/german shepherd.png", UriKind.Relative)},
                                                                 new Dog {Breed = "german short hair pointer", PictureUri = new Uri("Images/dogs/german short hair pointer.png", UriKind.Relative)},
                                                                 new Dog {Breed = "golden retriever", PictureUri = new Uri("Images/dogs/golden retriever.png", UriKind.Relative)},
                                                                 new Dog {Breed = "great dane", PictureUri = new Uri("Images/dogs/great dane.png", UriKind.Relative)},
                                                                 new Dog {Breed = "great pyrenees mountain dog", PictureUri = new Uri("Images/dogs/great pyrenees mountain dog.png", UriKind.Relative)},
                                                                 new Dog {Breed = "greyhound", PictureUri = new Uri("Images/dogs/greyhound.png", UriKind.Relative)},
                                                                 new Dog {Breed = "jack russel terrier", PictureUri = new Uri("Images/dogs/jack russel terrier.png", UriKind.Relative)},
                                                                 new Dog {Breed = "japanese chin", PictureUri = new Uri("Images/dogs/japanese chin.png", UriKind.Relative)},
                                                                 new Dog {Breed = "labrador retriever", PictureUri = new Uri("Images/dogs/labrador retriever.png", UriKind.Relative)},
                                                                 new Dog {Breed = "lhasa apso", PictureUri = new Uri("Images/dogs/lhasa apso.png", UriKind.Relative)},
                                                                 new Dog {Breed = "long-haired chihuahua", PictureUri = new Uri("Images/dogs/long-haired chihuahua.png", UriKind.Relative)},
                                                                 new Dog {Breed = "maltese terrier", PictureUri = new Uri("Images/dogs/maltese terrier.png", UriKind.Relative)},
                                                                 new Dog {Breed = "mastiff", PictureUri = new Uri("Images/dogs/mastiff.png", UriKind.Relative)},
                                                                 new Dog {Breed = "mini pinscher", PictureUri = new Uri("Images/dogs/mini pinscher.png", UriKind.Relative)},
                                                                 new Dog {Breed = "papillion", PictureUri = new Uri("Images/dogs/papillion.png", UriKind.Relative)},
                                                                 new Dog {Breed = "pekingese", PictureUri = new Uri("Images/dogs/pekingese.png", UriKind.Relative)},
                                                                 new Dog {Breed = "pointer", PictureUri = new Uri("Images/dogs/pointer.png", UriKind.Relative)},
                                                                 new Dog {Breed = "pomeranian", PictureUri = new Uri("Images/dogs/pomeranian.png", UriKind.Relative)},
                                                                 new Dog {Breed = "poodle", PictureUri = new Uri("Images/dogs/poodle.png", UriKind.Relative)},
                                                                 new Dog {Breed = "portugese water dog", PictureUri = new Uri("Images/dogs/portugese water dog.png", UriKind.Relative)},
                                                                 new Dog {Breed = "pug", PictureUri = new Uri("Images/dogs/pug.png", UriKind.Relative)},
                                                                 new Dog {Breed = "rottweilier", PictureUri = new Uri("Images/dogs/rottweilier.png", UriKind.Relative)},
                                                                 new Dog {Breed = "saint bernard", PictureUri = new Uri("Images/dogs/saint bernard.png", UriKind.Relative)},
                                                                 new Dog {Breed = "schnauzer", PictureUri = new Uri("Images/dogs/schnauzer.png", UriKind.Relative)},
                                                                 new Dog {Breed = "scottish terrier", PictureUri = new Uri("Images/dogs/scottish terrier.png", UriKind.Relative)},
                                                                 new Dog {Breed = "shar-pei", PictureUri = new Uri("Images/dogs/shar-pei.png", UriKind.Relative)},
                                                                 new Dog {Breed = "sheltie", PictureUri = new Uri("Images/dogs/sheltie.png", UriKind.Relative)},
                                                                 new Dog {Breed = "shih-tzu", PictureUri = new Uri("Images/dogs/shih-tzu.png", UriKind.Relative)},
                                                                 new Dog {Breed = "siberian huskie", PictureUri = new Uri("Images/dogs/siberian huskie.png", UriKind.Relative)},
                                                                 new Dog {Breed = "toy poodle", PictureUri = new Uri("Images/dogs/toy poodle.png", UriKind.Relative)},
                                                                 new Dog {Breed = "welsh corgi", PictureUri = new Uri("Images/dogs/welsh corgi.png", UriKind.Relative)},
                                                                 new Dog {Breed = "west highland terrier", PictureUri = new Uri("Images/dogs/west highland terrier.png", UriKind.Relative)},
                                                                 new Dog {Breed = "wheaten", PictureUri = new Uri("Images/dogs/wheaten.png", UriKind.Relative)},
                                                                 new Dog {Breed = "yorkie", PictureUri = new Uri("Images/dogs/yorkie.png", UriKind.Relative)}
                                                             };


        public List<Dog> DogBreeds {
            get { return dogBreeds; }
        }

        public List<Cat> CatBreeds {
            get { return catBreeds; }
        }

        public IEnumerable<Group<Dog>> DogBreedsDictionary {
            get {
                return from dog in dogBreeds
                       group dog by dog.Breed[0]
                       into c
                       orderby c.Key
                       select new Group<Dog>(c.Key.ToString(), c);
            }
        }

        public IEnumerable<Group<Cat>> CatBreedsDictionary {
            get {
                return from cat in catBreeds
                       group cat by cat.Breed[0]
                       into c
                       orderby c.Key
                       select new Group<Cat>(c.Key.ToString(), c);
            }
        }

    }
}