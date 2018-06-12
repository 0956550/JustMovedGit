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
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MenuView);
            ListView receptenMenu = FindViewById<ListView>(Resource.Id.ListView);
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.LinearLayout);
            List<Recept> recepten = model.GetAllData();
            ReceptenAdapter adapter = new ReceptenAdapter(this, recepten, Resource.Layout.ReceptMenuListview);
            receptenMenu.Adapter = adapter;
            EditText searchBar = FindViewById<EditText>(Resource.Id.searchBar);

            receptenMenu.ItemClick += (s, e) =>
            {
                Intent receptActivity = new Intent(this, typeof(ReceptenActivity));
                receptActivity.PutExtra("id", adapter.GetRecept(e.Position).id);
                this.StartActivity(receptActivity);
            };

            searchBar.TextChanged += searchBar_TextChanged;

            void searchBar_TextChanged(object sender, EventArgs e)
            {
                string query = searchBar.Text.ToLower();
                List<Recept>searchReceopten = model.GetSearchData(query);
                adapter = new ReceptenAdapter(this, searchReceopten, Resource.Layout.ReceptMenuListview);
                receptenMenu.Adapter = adapter;
            };
        }
    }
}