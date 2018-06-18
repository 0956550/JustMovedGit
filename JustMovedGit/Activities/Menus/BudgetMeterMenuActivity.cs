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
    [Activity(Label = "BudgetMeterMenuActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class BudgetMeterMenuActivity : Activity
    {
        private KostenModel model = new KostenModel();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            string userId = Intent.GetStringExtra("userId");

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BudgetMeterView);
            ListView kostenMenu = FindViewById<ListView>(Resource.Id.ListView);
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.LinearLayout);
            //List<Kosten> kosten = model.GetAllKosten(userId);
            List<Kosten> kosten;
           
            if (model.GetAllKosten(userId)==null)
            {
                kosten = null;
            }
            else
            {
                kosten = model.GetAllKosten(userId);
                KostenAdapter adapter = new KostenAdapter(this, kosten, Resource.Layout.KostenpostenListview);
                kostenMenu.Adapter = adapter;
            }

            



        }
    }
}