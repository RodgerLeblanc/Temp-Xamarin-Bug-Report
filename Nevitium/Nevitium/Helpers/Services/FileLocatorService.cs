
using Xamarin.Forms;

namespace Nevitium.Helpers.Services
{
    public static class FileLocatorService
    {


        public static string DeviceSpecificFileLocation(string file)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.macOS:
                    return "Assets/menu/" + file;

                case Device.iOS:
                    return "Assets/menu/" + file;

                case Device.Android:
                    return "" + file;

                case Device.UWP:
                    return "Assets/" + file;

                default:
                    return "Assets/menu/" + file;
            }
        }


    }
}
