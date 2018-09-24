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
        private readonly List<News> newsList;

        public NewsAdapter(List<News> news)
        {
            newsList = news;
        }


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MyViewHolder h = holder as MyViewHolder;
            News news = newsList[position];
            h.Title.Text = news.Heading;
            h.Content.Text = news.Content;
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
                return newsList.Count;
            }
        } 

        /*
         * Our Viewholder class.
         * Will hold our textview.
         */
        internal class MyViewHolder : RecyclerView.ViewHolder
        {
            public TextView Title { get; set; }
            public TextView Content { get; set; }

            public MyViewHolder(View itemView)
                : base(itemView)
            {
                Title = itemView.FindViewById<TextView>(Resource.Id.title);
                Content = itemView.FindViewById<TextView>(Resource.Id.news);
            }
        }
}
}