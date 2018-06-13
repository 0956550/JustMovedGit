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
    [Activity(Label = "BudgetMenuActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class BudgetMenuActivity : Activity
    {
        private BudgetModel model = new BudgetModel();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MenuView);
            ListView budgetMenu = FindViewById<ListView>(Resource.Id.ListView);
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.LinearLayout);
            List<Budget> budget = model.GetAllData();
            BudgetAdapter adapter = new BudgetAdapter(this, budget, Resource.Layout.OtherMenuListview);
            budgetMenu.Adapter = adapter;
            EditText searchBar = FindViewById<EditText>(Resource.Id.searchBar);

            budgetMenu.ItemClick += (s, e) =>
            {
                Intent budgetActivity = new Intent(this, typeof(BudgetActivity));
                budgetActivity.PutExtra("id", adapter.GetBudget(e.Position).id);
                this.StartActivity(budgetActivity);
            };

            searchBar.TextChanged += searchBar_TextChanged;

            void searchBar_TextChanged(object sender, EventArgs e)
            {
                string query = searchBar.Text.ToLower();
                List<Budget> searchBudget = model.GetSearchData(query);
                adapter = new BudgetAdapter(this, searchBudget, Resource.Layout.OtherMenuListview);
                budgetMenu.Adapter = adapter;
            };
        }
    }
}