
using Xamarin.Forms;

namespace Nevitium.Presentation.CustomControls
{
    public class StyledViewCell : ViewCell
    {
        public StyledViewCell() : base()
        {
            RelativeLayout layout = new RelativeLayout();
            layout.SetBinding(Layout.BackgroundColorProperty, new Binding("BackgroundColor"));

            View = layout;
        }

    }
}
