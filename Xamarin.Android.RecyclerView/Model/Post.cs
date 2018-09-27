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
    public class Post
    {
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }
}