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
using JustMovedGit.Classes;
using JustMovedGit.Models;
using JustMovedGit.Activities;

namespace JustMovedGit.Activities.Items
{
    [Activity(Label = "Kosten", Theme = "@android:style/Theme.NoTitleBar")]
    public class KostenActivity : Activity
    {
        
        LoginModel loginModel = new LoginModel();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.KostenView);
            
            string id = Intent.GetStringExtra("id");
            string userId = Intent.GetStringExtra("userId");
            ImageButton newkosten = FindViewById<ImageButton>(Resource.Id.addKostenpostbtn);
            Button newMaand = FindViewById<Button>(Resource.Id.kostenpostbtn);
            Gebruiker gebruiker = loginModel.requestUser(userId);

            TextView budgetover = FindViewById<TextView>(Resource.Id.txtBudgetOver);

            
            
            double kostendoubles = 0; 
            Models.KostenModel model = new Models.KostenModel();

            foreach (Kosten items in model.GetAllKosten(userId))
            {

                
                kostendoubles += Convert.ToDouble(items.kosten);
                

            }

            newkosten.Click += delegate
            {
                Intent Budgettoinput = new Intent(this, typeof(BudgettoinputActivity));
                this.StartActivity(Budgettoinput);
            };
            
            
        }
    }
}