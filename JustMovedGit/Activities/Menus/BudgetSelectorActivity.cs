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

namespace JustMovedGit.Activities.Menus
{
    [Activity(Label = "Budget", Theme = "@android:style/Theme.NoTitleBar")]
    public class BudgetSelectorActivity : Activity
    {
        



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BudgetSelectMenu);

            string userId = Intent.GetStringExtra("userId");

            ImageButton budgetBtn = FindViewById<ImageButton>(Resource.Id.budgetBtn);
            ImageButton budgetPlannerBtn = FindViewById<ImageButton>(Resource.Id.budgetPlannerBtn);

           
            budgetBtn.Click += delegate
            {
                Intent BudgetMenuActivity = new Intent(this, typeof(BudgetMenuActivity));
                this.StartActivity(BudgetMenuActivity);
            };

            budgetPlannerBtn.Click += delegate
            {
                

                if (string.IsNullOrEmpty(userId))
                {
                    Android.App.AlertDialog.Builder popupMessage1 = new AlertDialog.Builder(this);
                    AlertDialog alert1 = popupMessage1.Create();
                    alert1.SetTitle("Budgetplanner openen mislukt!");
                    alert1.SetMessage("U moet ingelogd zijn om gebruik te maken van deze functie.");
                    alert1.SetButton("OK", (c, ev) =>
                    { });
                    alert1.Show();
                }
                else
                {
                    Intent budgetMeterMenuActivity = new Intent(this, typeof(BudgetMeterMenuActivity));
                    budgetMeterMenuActivity.PutExtra("userId", userId);
                    this.StartActivity(budgetMeterMenuActivity);  //todo: in deze statement de verwijzingen vervangen met Jaspers budgetplanner activity
                }
            };
        }
    }
}
