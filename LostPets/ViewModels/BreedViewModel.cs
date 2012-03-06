using System.Collections.Generic;

namespace LostPets {
    public class BreedViewModel {
        private readonly List<Dog> dogBreeds = new List<Dog> {new Dog {DogBreed = DogBreed.Boxer, PictureUri = "Images/pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.Bulldogs, PictureUri = "Images/pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.CockerSpaniel, PictureUri = "Images/pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.Corgi, PictureUri = "Images/pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.Dachshund, PictureUri = "Images/pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.Dalmation, PictureUri = "Images/pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.GermanShepherd, PictureUri = "Images/pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.GoldenRetrievers, PictureUri = "Images/pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.GreyHound, PictureUri = "Images/pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.Husky, PictureUri = "Images/pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.LabradorRetrievers, PictureUri = "Images/pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.Poodles, PictureUri = "Images/pet_thumbnail.jpg"},
            new Dog {DogBreed = DogBreed.Beagles, PictureUri = "Images/pet_thumbnail.jpg"}};

        private readonly List<Cat> catBreeds = new List<Cat> {new Cat {CatBreed = CatBreed.Himalayan, PictureUri = "Images/pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.Abyssinian , PictureUri = "Images/pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.Burmese, PictureUri = "Images/pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.CornishRex, PictureUri = "Images/pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.DevonRex, PictureUri = "Images/pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.EgyptianMau, PictureUri = "Images/pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.Himalayan, PictureUri = "Images/pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.MaineCoon, PictureUri = "Images/pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.Persian, PictureUri = "Images/pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.Manx, PictureUri = "Images/pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.RussianBlue, PictureUri = "Images/pet_thumbnail.jpg"},
            new Cat {CatBreed = CatBreed.Siamese, PictureUri = "Images/pet_thumbnail.jpg"}};

        public List<Dog> DogBreeds {
            get { return dogBreeds; }
        }

        public List<Cat> CatBreeds
        {
            get { return catBreeds; }
        }
    }
}