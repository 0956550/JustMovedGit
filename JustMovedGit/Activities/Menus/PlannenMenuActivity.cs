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
using JustMovedGit.Adapters;
using JustMovedGit.Classes;
using JustMovedGit.Models;
using JustMovedGit.Activities.Items;

namespace JustMovedGit.Activities
{
    [Activity(Label = "PlannenActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class PlannenMenuActivity : Activity
    {

        PlannenModel model = new PlannenModel();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MenuView);
            ListView plannenMenu = FindViewById<ListView>(Resource.Id.ListView);
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.LinearLayout);
            List<Plannen> plannen = model.GetAllData();
            PlannenAdapter adapter = new PlannenAdapter(this, plannen, Resource.Layout.OtherMenuListview);
            plannenMenu.Adapter = adapter;
            EditText searchBar = FindViewById<EditText>(Resource.Id.searchBar);

            plannenMenu.ItemClick += (s, e) =>
            {
                Intent plannenActivity = new Intent(this, typeof(PlannenActivity));
                plannenActivity.PutExtra("id", adapter.GetPlannen(e.Position).id);
                this.StartActivity(plannenActivity);
            };

            searchBar.TextChanged += searchBar_TextChanged;

            void searchBar_TextChanged(object sender, EventArgs e)
            {
                string query = searchBar.Text.ToLower();
                List<Plannen> searchPlannen = model.GetSearchData(query);
                adapter = new PlannenAdapter(this, searchPlannen, Resource.Layout.OtherMenuListview);
                plannenMenu.Adapter = adapter;
            };
        }
    }
}