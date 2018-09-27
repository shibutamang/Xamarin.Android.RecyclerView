using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Xamarin.Android.RecyclerView;
using Xamarin.Android.RecyclerView.Model;
using Newtonsoft.Json;
using static Android.Provider.SyncStateContract;
using Android.Util;
using Xamarin.Android.RecyclerView.Services;

namespace MyXamarinApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private HttpService<Post> service;
        private List<Post> postList;
        private RecyclerView recyclerView;
        private RecyclerView.LayoutManager layoutManager;
        private NewsAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;

            //http service initialize
            service = new HttpService<Post>();
            postList = new List<Post>();

            //Running httpclient process in seperate thread
            Task.Run(async () => await DataInitAsync());

            recyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            layoutManager = new LinearLayoutManager(this);
            adapter = new NewsAdapter(postList);

            recyclerView.SetLayoutManager(layoutManager);
            recyclerView.SetAdapter(adapter);


        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (View.IOnClickListener)null).Show();
        }
        

        public async Task DataInitAsync()
        {
            List<Post> jsonPostList = await service.GetDataAsync();

                foreach (var item in jsonPostList)
                {
                    Log.Debug("Posts:", "Name: " + item.name.ToString());

                    var post = new Post() { email = item.email, body = item.body };
                    postList.Add(post);
                }

                adapter.NotifyDataSetChanged();
        }
        
	}
}

