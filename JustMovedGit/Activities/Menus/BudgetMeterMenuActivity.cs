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
            ListView kostenMenu = FindViewById<ListView>(Resource.Id.listView1);
            LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.linearLayout2);
            KostenAdapter adapter;
            List<Kosten> kosten;
            Button limiet = FindViewById<Button>(Resource.Id.kostenpostbtn);
            ImageButton addKosten = FindViewById<ImageButton>(Resource.Id.plusbudgetbtn);
            Button refresh = FindViewById<Button>(Resource.Id.refreshBtn);
            TextView budgetOver = FindViewById<TextView>(Resource.Id.BudgetOvertxt);


            if (!model.checkUser(userId))
            {
                kosten = model.GetAllKosten(userId);
                adapter = new KostenAdapter(this, kosten, Resource.Layout.KostenpostenListview);
                kostenMenu.Adapter = adapter;
            }
            else
            {
                kosten = model.GetAllKosten(userId);
                adapter = new KostenAdapter(this, kosten, Resource.Layout.KostenpostenListview);
                kostenMenu.Adapter = adapter;
                double kostenDbl = 0;

                foreach(Kosten item in kosten)
                {
                    kostenDbl += Convert.ToDouble(item.kosten);
                }

                double budgetOverDbl = Math.Round(Convert.ToDouble(model.GetLimiet(userId).kosten) - kostenDbl, 2);

                if (budgetOverDbl >= 0)
                {
                    budgetOver.SetBackgroundColor(Android.Graphics.Color.Rgb(112, 255, 104));
                }
                else
                {
                    budgetOver.SetBackgroundColor(Android.Graphics.Color.Rgb(255, 104, 104));
                }
                
                budgetOver.Text = budgetOverDbl.ToString();
            }

            limiet.Click += delegate
            {
                Intent newMaandActivity = new Intent(this, typeof(NewMaandActivity));
                newMaandActivity.PutExtra("userId", userId);
                this.StartActivity(newMaandActivity);
            };

            addKosten.Click += delegate
            {
                if (model.checkUser(userId))
                {
                    Intent budgetToInputActivity = new Intent(this, typeof(BudgettoinputActivity));
                    budgetToInputActivity.PutExtra("userId", userId);
                    this.StartActivity(budgetToInputActivity);
                }
                else
                {
                    messageHandler(1);
                }
            };

            refresh.Click += delegate
            {
                if (model.checkUser(userId))
                {
                    budgetOver.Text = model.GetLimiet(userId).kosten;
                    kosten = model.GetAllKosten(userId);
                    adapter = new KostenAdapter(this, kosten, Resource.Layout.KostenpostenListview);
                    kostenMenu.Adapter = adapter;

                    double kostenDbl = 0;

                    foreach (Kosten item in kosten)
                    {
                        
                        kostenDbl += Convert.ToDouble(item.kosten);
                    }
                    double budgetOverDbl = Math.Round(Convert.ToDouble(model.GetLimiet(userId).kosten) - kostenDbl, 2);
                    if (budgetOverDbl >= 0)
                    {
                        budgetOver.SetBackgroundColor(Android.Graphics.Color.Rgb(112, 255, 104));
                    }
                    else
                    {
                        budgetOver.SetBackgroundColor(Android.Graphics.Color.Rgb(255, 104, 104));
                    }
                    budgetOver.Text = budgetOverDbl.ToString();
                }
                else
                {
                    messageHandler(2);
                }
            };

            void messageHandler(int switchId)
            {
                switch (switchId)
                {
                    case 1:
                        Android.App.AlertDialog.Builder popupMessage1 = new AlertDialog.Builder(this);
                        AlertDialog alert1 = popupMessage1.Create();
                        alert1.SetTitle("Kostenpost toevoegen uitgeschakeld!");
                        alert1.SetMessage("Dit is de eerste keer dat u deze functie gebruikt. Maak eerst een nieuwe maand aan.");
                        alert1.SetButton("OK", (c, ev) =>
                        {
                        });
                        alert1.Show();
                        break;
                    case 2:
                        Android.App.AlertDialog.Builder popupMessage2 = new AlertDialog.Builder(this);
                        AlertDialog alert2 = popupMessage2.Create();
                        alert2.SetTitle("Refresh uitgeschakeld!");
                        alert2.SetMessage("Dit is de eerste keer dat u deze functie gebruikt. Maak eerst een nieuwe maand aan.");
                        alert2.SetButton("OK", (c, ev) =>
                        {
                        });
                        alert2.Show();
                        break;
                }
            }
        }
    }
}