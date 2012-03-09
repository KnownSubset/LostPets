using System;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using RestSharp;

namespace LostPets.Services {
    public class PetUploader {
        public string Upload(Pet pet) {
            var restClient = new RestClient {BaseUrl = "http://ec2-107-20-224-204.compute-1.amazonaws.com/node"};
            byte[] readBuffer = new IsolatedStorageService().ReadImageFromIsolatedStorage("wp7.dat");
            IRestRequest restRequest = new RestRequest(Method.POST)
                .AddFile("file", readBuffer, pet.PictureUri.LocalPath)
                .AddParameter("breed", pet.Breed)
                .AddParameter("contact", pet.Contact)
                .AddParameter("contactMethod", pet.ContactMethod)
                .AddParameter("when", pet.DateWhen)
                .AddParameter("description", pet.Description)
                .AddParameter("dogOrCat", pet.DogOrCat)
                .AddParameter("foundAround", pet.FoundAround)
                .AddParameter("name", pet.Name)
                .AddParameter("size", pet.Size)
                .AddParameter("status", pet.Status);
            /*var callback = new Action<RestResponse>(delegate { });
            restClient.ExecuteAsync(restRequest, callback);*/
            return "http://www.lostpets.com";
        }
    }
}