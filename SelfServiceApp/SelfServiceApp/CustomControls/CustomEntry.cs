using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SelfServiceApp.CustomControls
{
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty PaddingProperty =
        BindableProperty.Create(
            nameof(Padding),
            typeof(Thickness),
            typeof(CustomEntry),
            new Thickness());

        public Thickness Padding {
            get { return (Thickness)this.GetValue(PaddingProperty); }
            set { this.SetValue(PaddingProperty, value); }
        }
    }
}
