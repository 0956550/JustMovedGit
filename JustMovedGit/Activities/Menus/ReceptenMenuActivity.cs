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
using JustMovedGit.Activities.Items;
using JustMovedGit.Adapters;
using JustMovedGit.Classes;
using JustMovedGit.Models;

namespace JustMovedGit.Activities
{
    [Activity(Label = "ReceptenMenuActivity")]
    public class ReceptenMenuActivity : Activity
    {
        private ReceptModel model = new ReceptModel();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ReceptenMenuView);

            EditText searchBar = FindViewById<EditText>(Resource.Id.searchBar);
            ListView receptenMenu = FindViewById<ListView>(Resource.Id.ListView);

            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.LinearLayout);
            string input = searchBar.Text.ToLower();
            List<Recept> recepten = model.GetAllData(input);
            ReceptenAdapter adapter = new ReceptenAdapter(this, recepten, Resource.Layout.test);
            receptenMenu.Adapter = adapter;

            searchBar.Alpha = 0;

            receptenMenu.ItemClick += (s, e) =>
            {
                Intent receptActivity = new Intent(this, typeof(ReceptenActivity));
                receptActivity.PutExtra("id", adapter.GetRecept(e.Position).id);
                this.StartActivity(receptActivity);
            };
            // Create your application here
        }
    }
}