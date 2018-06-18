using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using JustMovedGit.Activities.Items;
using JustMovedGit.Activities.Menus;
using JustMovedGit.Adapters;
using JustMovedGit.Classes;
using JustMovedGit.Models;

namespace JustMovedGit.Activities
{
    [Activity(Label = "FavorietenMenuActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class FavorietenMenuActivity : Activity
    {
        private ReceptModel model = new ReceptModel();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            string userId = Intent.GetStringExtra("userId");
            string isFavoriteOption = "1";

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.FavorietenMenuView);

            ImageButton budgetBtn = FindViewById<ImageButton>(Resource.Id.budgetBtn);
            ImageButton huishoudenBtn = FindViewById<ImageButton>(Resource.Id.huishoudenBtn);
            ImageButton plannenBtn = FindViewById<ImageButton>(Resource.Id.plannenBtn);
            ImageButton veiligheidBtn = FindViewById<ImageButton>(Resource.Id.veiligheidBtn);
            ImageButton receptBtn = FindViewById<ImageButton>(Resource.Id.receptBtn);

            budgetBtn.Click += delegate
            {
                Intent budgetSelectorActivity = new Intent(this, typeof(BudgetSelectorActivity));
                this.StartActivity(budgetSelectorActivity);
            };

            huishoudenBtn.Click += delegate
            {
                Intent huishoudenMenuActivity = new Intent(this, typeof(HuishoudenMenuActivity));
                huishoudenMenuActivity.PutExtra("userId", userId);
                huishoudenMenuActivity.PutExtra("isFavoriteOption", isFavoriteOption);
                this.StartActivity(huishoudenMenuActivity);
            };

            plannenBtn.Click += delegate
            {
                Intent plannenMenuActivity = new Intent(this, typeof(PlannenMenuActivity));
                plannenMenuActivity.PutExtra("userId", userId);
                plannenMenuActivity.PutExtra("isFavoriteOption", isFavoriteOption);
                this.StartActivity(plannenMenuActivity);
            };

            veiligheidBtn.Click += delegate
            {
                Intent veiligheidMenuActivity = new Intent(this, typeof(VeiligheidMenuActivity));
                veiligheidMenuActivity.PutExtra("userId", userId);
                veiligheidMenuActivity.PutExtra("isFavoriteOption", isFavoriteOption);
                this.StartActivity(veiligheidMenuActivity);
            };

            receptBtn.Click += delegate
            {
                Intent receptMenuActivity = new Intent(this, typeof(ReceptenMenuActivity));
                receptMenuActivity.PutExtra("userId", userId);
                receptMenuActivity.PutExtra("isFavoriteOption", isFavoriteOption);
                this.StartActivity(receptMenuActivity);
            };

        }
    }
}