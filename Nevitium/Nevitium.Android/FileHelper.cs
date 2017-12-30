using Nevitium.Helpers;
using System.IO;
using Nevitium.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileHelper))]
namespace Nevitium.Droid
{
    
    class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            
            return Path.Combine(path, filename);
        }

    }
}