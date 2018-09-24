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

namespace Xamarin.Android.RecyclerView.Model
{
    public class News
    {
        public string Heading { get; set; }
        public string Content { get; set; }
    }
}