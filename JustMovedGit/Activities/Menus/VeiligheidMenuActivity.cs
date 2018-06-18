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
            string userId = Intent.GetStringExtra("userId");
            string isFavoriteOption = Intent.GetStringExtra("isFavoriteOption");

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MenuView);
            ListView veiligheidMenu = FindViewById<ListView>(Resource.Id.ListView);
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.LinearLayout);
            VeiligheidAdapter adapter;
            RelatieVeiligheidModel relatieVeiligheidModel = new RelatieVeiligheidModel();
            EditText searchBar = FindViewById<EditText>(Resource.Id.searchBar);

            if (isFavoriteOption.Equals("1"))
            {
                List<Veiligheid> veiligheid = relatieVeiligheidModel.getFavorieten(userId);
                adapter = new VeiligheidAdapter(this, veiligheid, Resource.Layout.OtherMenuListview);
                veiligheidMenu.Adapter = adapter;

                searchBar.Visibility = Android.Views.ViewStates.Invisible;
            }
            else
            {
                List<Veiligheid> veiligheid = model.GetAllData();
                adapter = new VeiligheidAdapter(this, veiligheid, Resource.Layout.OtherMenuListview);
                veiligheidMenu.Adapter = adapter;
            }

            veiligheidMenu.ItemClick += (s, e) =>
            {
                Intent veiligheidActivity = new Intent(this, typeof(VeiligheidActivity));
                veiligheidActivity.PutExtra("id", adapter.GetVeiligheid(e.Position).id);
                veiligheidActivity.PutExtra("userId", userId);
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