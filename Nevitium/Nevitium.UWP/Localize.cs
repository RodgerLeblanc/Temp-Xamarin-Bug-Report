
using Nevitium.Presentation.Localization;
using Nevitium.UWP;
using Xamarin.Forms;

[assembly: Dependency(typeof(Localize))]

namespace Nevitium.UWP
{
    class Localize : ILocalize
    {
        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            return new System.Globalization.CultureInfo(
                Windows.System.UserProfile.GlobalizationPreferences.Languages[0].ToString());
        }

        public void SetLocale(System.Globalization.CultureInfo ci)
        {
            // Do nothing
        }

    }
}
