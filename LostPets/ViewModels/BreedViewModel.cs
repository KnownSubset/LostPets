using System.Collections.Generic;

namespace LostPets {
    public class BreedViewModel {
        private readonly List<Dog> dogBreeds = new List<Dog> {new Dog {DogBreed = DogBreed.Boxer, PictureUri = "pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.Bulldogs, PictureUri = "pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.CockerSpaniel, PictureUri = "pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.Corgi, PictureUri = "pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.Dachshund, PictureUri = "pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.Dalmation, PictureUri = "pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.GermanShepherd, PictureUri = "pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.GoldenRetrievers, PictureUri = "pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.GreyHound, PictureUri = "pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.Husky, PictureUri = "pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.LabradorRetrievers, PictureUri = "pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.Poodles, PictureUri = "pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.Beagles, PictureUri = "pet_thumbnail.jpg"}};

        private readonly List<Cat> catBreeds = new List<Cat> {new Cat {CatBreed = CatBreed.Himalayan, PictureUri = "pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.Abyssinian , PictureUri = "pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.Burmese, PictureUri = "pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.CornishRex, PictureUri = "pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.DevonRex, PictureUri = "pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.EgyptianMau, PictureUri = "pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.Himalayan, PictureUri = "pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.MaineCoon, PictureUri = "pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.Persian, PictureUri = "pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.Manx, PictureUri = "pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.RussianBlue, PictureUri = "pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.Siamese, PictureUri = "pet_thumbnail.jpg"}};

        public List<Dog> DogBreeds {
            get { return dogBreeds; }
        }

        public List<Cat> CatBreeds
        {
            get { return catBreeds; }
        }
    }
}