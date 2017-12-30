using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Nevitium.Models
{
    class MasterPageItem : INotifyPropertyChanged
    {

        public string Title { get; set; }

        public string IconSource { get; set; }

        public Type TargetType { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        private Color _backgroundColor;

        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BackgroundColor"));
                }
            }
        }

        public void SetColors(bool isSelected)
        {
            if (isSelected)
            {
                BackgroundColor = Color.Red;
            }
            else
            {
                BackgroundColor = Color.Black;
            }
        }

    }
}
