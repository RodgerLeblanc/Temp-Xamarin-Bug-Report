using System.Diagnostics;
using System.IO;
using Nevitium.Helpers;
using Nevitium.UWP.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Nevitium.UWP.Helpers
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            var docFolder = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
            var libFolder = Path.Combine(docFolder, "Nevitium", "Data");
            Debug.WriteLine(libFolder);
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);                
            }
            return Path.Combine(libFolder, filename);
        }
    }

   
}
