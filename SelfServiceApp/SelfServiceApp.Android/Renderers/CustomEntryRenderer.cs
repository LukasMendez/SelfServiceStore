using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SelfServiceApp.CustomControls;
using SelfServiceApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace SelfServiceApp.Droid.Renderers
{
    class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context) {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);

            if (e.NewElement == null) {
                return;
            }

            if (this.Element is CustomEntry customEntry) {
                var paddingLeft = (int)customEntry.Padding.Left;
                var paddingTop = (int)customEntry.Padding.Top;
                var paddingRight = (int)customEntry.Padding.Right;
                var paddingBottom = (int)customEntry.Padding.Bottom;
                this.Control.SetPadding(paddingLeft, paddingTop, paddingRight, paddingBottom);
                
            }
        }
    }
}
