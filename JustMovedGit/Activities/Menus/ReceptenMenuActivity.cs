using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using JustMovedGit.Activities.Items;
using JustMovedGit.Adapters;
using JustMovedGit.Classes;
using JustMovedGit.Models;

namespace JustMovedGit.Activities
{
    [Activity(Label = "ReceptenMenuActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class ReceptenMenuActivity : Activity
    {
        private ReceptModel model = new ReceptModel();
       

        protected override void OnCreate(Bundle savedInstanceState)
        {
            string userId = Intent.GetStringExtra("userId");
            string isFavoriteOption = Intent.GetStringExtra("isFavoriteOption");

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MenuView);
            RelatieReceptModel relatieReceptModel = new RelatieReceptModel();
            ListView receptenMenu = FindViewById<ListView>(Resource.Id.ListView);
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.LinearLayout);

            ReceptenAdapter adapter;

            EditText searchBar = FindViewById<EditText>(Resource.Id.searchBar);

            if (isFavoriteOption.Equals("1"))
            {
                List<Recept> recepten = relatieReceptModel.getFavorieten(userId);
                adapter = new ReceptenAdapter(this, recepten, Resource.Layout.ReceptMenuListview);
                receptenMenu.Adapter = adapter;

                searchBar.Visibility = Android.Views.ViewStates.Invisible;
            }
            else
            {
                List<Recept> recepten = model.GetAllData();
                adapter = new ReceptenAdapter(this, recepten, Resource.Layout.ReceptMenuListview);
                receptenMenu.Adapter = adapter;
            }

            receptenMenu.ItemClick += (s, e) =>
            {
                Intent receptActivity = new Intent(this, typeof(ReceptenActivity));
                receptActivity.PutExtra("id", adapter.GetRecept(e.Position).id);
                receptActivity.PutExtra("userId", userId);
                this.StartActivity(receptActivity);
            };

            searchBar.TextChanged += searchBar_TextChanged;

            void searchBar_TextChanged(object sender, EventArgs e)
            {
                string query = searchBar.Text.ToLower();

                List<Recept>searchRecepten = model.GetSearchData(query);
                adapter = new ReceptenAdapter(this, searchRecepten, Resource.Layout.ReceptMenuListview);
                receptenMenu.Adapter = adapter;
            };
        }
    }
}