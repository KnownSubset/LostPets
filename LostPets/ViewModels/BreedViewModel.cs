using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace LostPets {
    public class BreedViewModel {
        private readonly List<Cat> catBreeds = new List<Cat> {
                                                                 new Cat {Breed = "abyssinian", PictureUri = "Images/cats/abyssinian.png"},
                                                                 new Cat {Breed = "burmese", PictureUri = "Images/cats/burmese.png"},
                                                                 new Cat {Breed = "cornish rex", PictureUri = "Images/cats/cornish rex.png"},
                                                                 new Cat {Breed = "devon rex", PictureUri = "Images/cats/devon rex.png"},
                                                                 new Cat {Breed = "egyptian mau", PictureUri = "Images/cats/egyptian mau.png"},
                                                                 new Cat {Breed = "himalayan", PictureUri = "Images/cats/himalayan.png"},
                                                                 new Cat {Breed = "maine coon", PictureUri = "Images/cats/maine coon.png"},
                                                                 new Cat {Breed = "persian", PictureUri = "Images/cats/persian.png"},
                                                                 new Cat {Breed = "manx", PictureUri = "Images/cats/manx.png"},
                                                                 new Cat {Breed = "russian blue", PictureUri = "Images/cats/russian blue.png"},
                                                                 new Cat {Breed = "siamese", PictureUri = "Images/cats/siamese.png"}
                                                             };

        private readonly List<Dog> dogBreeds = new List<Dog> {
                                                                 new Dog {Breed = "alaskan malamute", PictureUri = "Images/dogs/alaskan malamute.png"},
                                                                 new Dog {Breed = "austrialian sheppard", PictureUri = "Images/dogs/austrialian sheppard.png"},
                                                                 new Dog {Breed = "basenji", PictureUri = "Images/dogs/basenji.png"},
                                                                 new Dog {Breed = "basset hound", PictureUri = "Images/dogs/basset hound.png"},
                                                                 new Dog {Breed = "beagle", PictureUri = "Images/dogs/beagle.png"},
                                                                 new Dog {Breed = "bichon", PictureUri = "Images/dogs/bichon.png"},
                                                                 new Dog {Breed = "bloodhound", PictureUri = "Images/dogs/bloodhound.png"},
                                                                 new Dog {Breed = "border collie", PictureUri = "Images/dogs/border collie.png"},
                                                                 new Dog {Breed = "boston terrier", PictureUri = "Images/dogs/boston terrier.png"},
                                                                 new Dog {Breed = "boxer", PictureUri = "Images/dogs/boxer.png"},
                                                                 new Dog {Breed = "britteny", PictureUri = "Images/dogs/britteny.png"},
                                                                 new Dog {Breed = "bull mastiff", PictureUri = "Images/dogs/bull mastiff.png"},
                                                                 new Dog {Breed = "bull terrier", PictureUri = "Images/dogs/bull terrier.png"},
                                                                 new Dog {Breed = "bulldog", PictureUri = "Images/dogs/bulldog.png"},
                                                                 new Dog {Breed = "burmese mountain dog", PictureUri = "Images/dogs/burmese mountain dog.png"},
                                                                 new Dog {Breed = "cairn terrier", PictureUri = "Images/dogs/cairn terrier.png"},
                                                                 new Dog {Breed = "cavalier ac spaniel", PictureUri = "Images/dogs/cavalier ac spaniel.png"},
                                                                 new Dog {Breed = "chihuahua", PictureUri = "Images/dogs/chihuahua.png"},
                                                                 new Dog {Breed = "chow chow", PictureUri = "Images/dogs/chow chow.png"},
                                                                 new Dog {Breed = "cocker spaniel", PictureUri = "Images/dogs/cocker spaniel.png"},
                                                                 new Dog {Breed = "collie", PictureUri = "Images/dogs/collie.png"},
                                                                 new Dog {Breed = "daschund", PictureUri = "Images/dogs/daschund.png"},
                                                                 new Dog {Breed = "dobermann pinscher", PictureUri = "Images/dogs/dobermann pinscher.png"},
                                                                 new Dog {Breed = "english sheep dog", PictureUri = "Images/dogs/english sheep dog.png"},
                                                                 new Dog {Breed = "english springer spaniel", PictureUri = "Images/dogs/english springer spaniel.png"},
                                                                 new Dog {Breed = "fox terrier", PictureUri = "Images/dogs/fox terrier.png"},
                                                                 new Dog {Breed = "french bulldog", PictureUri = "Images/dogs/french bulldog.png"},
                                                                 new Dog {Breed = "german shephard", PictureUri = "Images/dogs/german shepherd.png"},
                                                                 new Dog {Breed = "german short hair pointer", PictureUri = "Images/dogs/german short hair pointer.png"},
                                                                 new Dog {Breed = "golden retriever", PictureUri = "Images/dogs/golden retriever.png"},
                                                                 new Dog {Breed = "great dane", PictureUri = "Images/dogs/great dane.png"},
                                                                 new Dog {Breed = "great pyrenees mountain dog", PictureUri = "Images/dogs/great pyrenees mountain dog.png"},
                                                                 new Dog {Breed = "greyhound", PictureUri = "Images/dogs/greyhound.png"},
                                                                 new Dog {Breed = "jack russel terrier", PictureUri = "Images/dogs/jack russel terrier.png"},
                                                                 new Dog {Breed = "japanese chin", PictureUri = "Images/dogs/japanese chin.png"},
                                                                 new Dog {Breed = "labrador retriever", PictureUri = "Images/dogs/labrador retriever.png"},
                                                                 new Dog {Breed = "lhasa apso", PictureUri = "Images/dogs/lhasa apso.png"},
                                                                 new Dog {Breed = "long-haired chihuahua", PictureUri = "Images/dogs/long-haired chihuahua.png"},
                                                                 new Dog {Breed = "maltese terrier", PictureUri = "Images/dogs/maltese terrier.png"},
                                                                 new Dog {Breed = "mastiff", PictureUri = "Images/dogs/mastiff.png"},
                                                                 new Dog {Breed = "mini pinscher", PictureUri = "Images/dogs/mini pinscher.png"},
                                                                 new Dog {Breed = "papillion", PictureUri = "Images/dogs/papillion.png"},
                                                                 new Dog {Breed = "pekingese", PictureUri = "Images/dogs/pekingese.png"},
                                                                 new Dog {Breed = "pointer", PictureUri = "Images/dogs/pointer.png"},
                                                                 new Dog {Breed = "pomeranian", PictureUri = "Images/dogs/pomeranian.png"},
                                                                 new Dog {Breed = "poodle", PictureUri = "Images/dogs/poodle.png"},
                                                                 new Dog {Breed = "portugese water dog", PictureUri = "Images/dogs/portugese water dog.png"},
                                                                 new Dog {Breed = "pug", PictureUri = "Images/dogs/pug.png"},
                                                                 new Dog {Breed = "rottweilier", PictureUri = "Images/dogs/rottweilier.png"},
                                                                 new Dog {Breed = "saint bernard", PictureUri = "Images/dogs/saint bernard.png"},
                                                                 new Dog {Breed = "schnauzer", PictureUri = "Images/dogs/schnauzer.png"},
                                                                 new Dog {Breed = "scottish terrier", PictureUri = "Images/dogs/scottish terrier.png"},
                                                                 new Dog {Breed = "shar-pei", PictureUri = "Images/dogs/shar-pei.png"},
                                                                 new Dog {Breed = "sheltie", PictureUri = "Images/dogs/sheltie.png"},
                                                                 new Dog {Breed = "shih-tzu", PictureUri = "Images/dogs/shih-tzu.png"},
                                                                 new Dog {Breed = "siberian huskie", PictureUri = "Images/dogs/siberian huskie.png"},
                                                                 new Dog {Breed = "toy poodle", PictureUri = "Images/dogs/toy poodle.png"},
                                                                 new Dog {Breed = "welsh corgi", PictureUri = "Images/dogs/welsh corgi.png"},
                                                                 new Dog {Breed = "west highland terrier", PictureUri = "Images/dogs/west highland terrier.png"},
                                                                 new Dog {Breed = "wheaten", PictureUri = "Images/dogs/wheaten.png"},
                                                                 new Dog {Breed = "yorkie", PictureUri = "Images/dogs/yorkie.png"}
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