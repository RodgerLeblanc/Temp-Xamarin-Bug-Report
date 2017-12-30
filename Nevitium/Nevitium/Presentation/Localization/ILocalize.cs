using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Nevitium.Presentation.Localization
{
    public interface ILocalize
    {
        CultureInfo GetCurrentCultureInfo();
        void SetLocale(CultureInfo ci);

    }
}
