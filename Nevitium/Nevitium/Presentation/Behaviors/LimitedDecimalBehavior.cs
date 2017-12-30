using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Nevitium.Presentation.Behaviors
{
    class LimitedDecimalBehavior : BehaviorBase<Entry>
    {

        public int MaxPrecision { get; set; } = 10;

        void OnEntryTextChanged(Object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            decimal val;
            var dec = Decimal.TryParse(entry.Text, out val);

            Debug.WriteLine(((Decimal.GetBits(val)[3] >> 16) & 0x000000FF));

            // if Entry text is longer then valid length
            if (dec != true || ((Decimal.GetBits(val)[3] >> 16) & 0x000000FF) > MaxPrecision)
            {
                entry.TextColor = Color.Red;
            }
            else
            {
                entry.TextColor = Color.Default;
            }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += OnEntryTextChanged;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnEntryTextChanged;
        }


    }
}
