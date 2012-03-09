using System.IO;
using System.IO.IsolatedStorage;

namespace LostPets.Services {
    public class IsolatedStorageService {
        public void WriteOutToFile(string fileName, Stream stream) {
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication()) {
                using (var writeStream = new IsolatedStorageFileStream(fileName, FileMode.Create, store)) {
                    var readBuffer = new byte[4096];
                    int bytesRead;
                    while ((bytesRead = stream.Read(readBuffer, 0, readBuffer.Length)) > 0) {
                        writeStream.Write(readBuffer, 0, bytesRead);
                    }
                }
            }
        }

        public byte[] ReadImageFromIsolatedStorage(string fileName) {
            using (IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication()) {
                using (var fileStream = new IsolatedStorageFileStream(fileName, FileMode.Open, FileAccess.Read, store)) {
                    {
                        using (var ms = new MemoryStream()) {
                            var readBuffer = new byte[4096];
                            int bytesRead;
                            // Copy the thumbnail to isolated storage. 
                            while ((bytesRead = fileStream.Read(readBuffer, 0, readBuffer.Length)) > 0) {
                                ms.Write(readBuffer, 0, bytesRead);
                            }
                            return ms.ToArray();
                        }
                    }
                }
            }
        }
    }
}