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
    [Activity(Label = "VeiligheidActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class VeiligheidMenuActivity : Activity
    {

        VeiligheidModel model = new VeiligheidModel();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MenuView);
            ListView veiligheidMenu = FindViewById<ListView>(Resource.Id.ListView);
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.LinearLayout);
            List<Veiligheid> veiligheid = model.GetAllData();
            VeiligheidAdapter adapter = new VeiligheidAdapter(this, veiligheid, Resource.Layout.OtherMenuListview);
            veiligheidMenu.Adapter = adapter;
            EditText searchBar = FindViewById<EditText>(Resource.Id.searchBar);

            veiligheidMenu.ItemClick += (s, e) =>
            {
                Intent veiligheidActivity = new Intent(this, typeof(VeiligheidActivity));
                veiligheidActivity.PutExtra("id", adapter.GetVeiligheid(e.Position).id);
                this.StartActivity(veiligheidActivity);
            };

            searchBar.TextChanged += searchBar_TextChanged;

            void searchBar_TextChanged(object sender, EventArgs e)
            {
                string query = searchBar.Text.ToLower();
                List<Veiligheid> searchVeiligheid = model.GetSearchData(query);
                adapter = new VeiligheidAdapter(this, searchVeiligheid, Resource.Layout.OtherMenuListview);
                veiligheidMenu.Adapter = adapter;
            };
        }
    }
}