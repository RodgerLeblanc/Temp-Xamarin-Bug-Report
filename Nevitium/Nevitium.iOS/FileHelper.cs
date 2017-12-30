using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Nevitium.Helpers;
using System.IO;
using Nevitium.iOS;

[assembly: Dependency(typeof(FileHelper))]
namespace Nevitium.iOS
{
    
    class FileHelper : IFileHelper
    {
        public FileHelper()
        {

        }

        public string GetLocalFilePath(string filename)
        {
            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");
            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            return Path.Combine(libFolder, filename);
        }
    }
}