using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Nevitium.Presentation.Behaviors
{
    class LimitedIntegerBehavior : BehaviorBase<Entry>
    {

        public int MaxLength { get; set; } = 10;

        void OnEntryTextChanged(Object sender, TextChangedEventArgs e)
        {
            var entry = (Entry)sender;
            int val;
            var integer = Int32.TryParse(entry.Text, out val);

            // if Entry text is longer then valid length
            if (entry.Text != null && entry.Text.Length > this.MaxLength || integer != true)
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
