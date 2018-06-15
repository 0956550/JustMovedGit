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

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MenuView);
            ListView receptenMenu = FindViewById<ListView>(Resource.Id.ListView);
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.LinearLayout);
            List<Recept> recepten = model.GetAllData();
            ReceptenAdapter adapter = new ReceptenAdapter(this, recepten, Resource.Layout.ReceptMenuListview);
            receptenMenu.Adapter = adapter;
            EditText searchBar = FindViewById<EditText>(Resource.Id.searchBar);
            RelatieReceptModel relatieReceptModel = new RelatieReceptModel();

            receptenMenu.ItemClick += (s, e) =>
            {
                Intent receptActivity = new Intent(this, typeof(ReceptenActivity));
                receptActivity.PutExtra("id", adapter.GetRecept(e.Position).id);
                receptActivity.PutExtra("userId", userId);
                this.StartActivity(receptActivity);
                Console.WriteLine(userId);
                List<Relatie_Recepten> test = relatieReceptModel.getFavorieten();

                foreach (Relatie_Recepten item in test)
                {
                    Console.WriteLine("kaas" + item.gebruiker_id + "\t" + item.recept_id);
                }
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