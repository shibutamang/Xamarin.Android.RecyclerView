using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using Xamarin.Android.RecyclerView;
using Xamarin.Android.RecyclerView.Model;

namespace MyXamarinApp
{
    public class NewsAdapter : RecyclerView.Adapter
    {
        private readonly List<Post> postList;

        public NewsAdapter(List<Post> posts)
        {
            postList = posts;
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyViewHolder h = holder as MyViewHolder;
            Post post = postList[position];
            h.Email.Text = post.email;
            h.Body.Text = post.body;
        }

        //INITIALIZE VH
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            //INFLATE LAYOUT TO VIEW
            View v = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.news_item, parent, false);
            MyViewHolder holder = new MyViewHolder(v);

            return holder;
        }

        //TOTAL NUM OF GALAXIES
        public override int ItemCount
        {
            get
            {
                return postList.Count;
            }
        } 

        /*
         * Our Viewholder class.
         * Will hold our textview.
         */
        internal class MyViewHolder : RecyclerView.ViewHolder
        {
            public TextView Email { get; set; }
            public TextView Body { get; set; }

            public MyViewHolder(View itemView)
                : base(itemView)
            {
                Email = itemView.FindViewById<TextView>(Resource.Id.email);
                Body = itemView.FindViewById<TextView>(Resource.Id.body);
            }
        }
}
}