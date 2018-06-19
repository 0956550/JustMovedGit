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

namespace JustMovedGit.Activities.Items
{
    [Activity(Label = "Budgettoinput", Theme = "@android:style/Theme.NoTitleBar")]
    public class BudgettoinputActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.KostenView);

            string userId = Intent.GetStringExtra("userId");
            KostenModel model = new KostenModel();

            Button addKosten = FindViewById<Button>(Resource.Id.addKostenpostbtn);
            EditText nummer = FindViewById<EditText>(Resource.Id.kostenEditText);
            EditText kommaGetal = FindViewById<EditText>(Resource.Id.kostenEditText2);
            EditText beschrijving = FindViewById<EditText>(Resource.Id.beschrijvingkostenEditText);

            addKosten.Click += delegate
            {
                if (string.IsNullOrEmpty(nummer.Text) || string.IsNullOrEmpty(kommaGetal.Text))
                {
                    messageHandler(2);
                }
                else if (string.IsNullOrEmpty(beschrijving.Text))
                {
                    messageHandler(1);
                }
                else
                {
                    string kostenTotaal = nummer.Text + "." + kommaGetal.Text;
                    model.createKosten(kostenTotaal, beschrijving.Text, userId);
                    List<Kosten> kosten = model.GetAllKosten(userId);
                    foreach (Kosten item in kosten)
                    {
                        Console.WriteLine(item.kosten + "\t" + item.beschrijving);
                    }
                    messageHandler(3);
                }
            };

            void messageHandler(int switchId)
            {
                switch (switchId)
                {
                    case 1:
                        Android.App.AlertDialog.Builder popupMessage1 = new AlertDialog.Builder(this);
                        AlertDialog alert1 = popupMessage1.Create();
                        alert1.SetTitle("Kostenpost invoeren mislukt!");
                        alert1.SetMessage("Er moet een beschrijving ingevoerd worden!");
                        alert1.SetButton("OK", (c, ev) =>
                        {
                            nummer.Text = "";
                            beschrijving.Text = "";
                            kommaGetal.Text = "";

                        });
                        alert1.Show();
                        break;
                    case 2:
                        Android.App.AlertDialog.Builder popupMessage2 = new AlertDialog.Builder(this);
                        AlertDialog alert2 = popupMessage2.Create();
                        alert2.SetTitle("Kostenpost invoeren mislukt!");
                        alert2.SetMessage("De ingevoerde waarde moet een waarde hoger zijn dan nul!");
                        alert2.SetButton("OK", (c, ev) =>
                        {
                            nummer.Text = "";
                            beschrijving.Text = "";
                            kommaGetal.Text = "";
                        });
                        alert2.Show();
                        break;
                    case 3:
                        Android.App.AlertDialog.Builder popupMessage3 = new AlertDialog.Builder(this);
                        AlertDialog alert3 = popupMessage3.Create();
                        alert3.SetTitle("Kostenpost succesvol toegevoegd!");
                        alert3.SetMessage("Klik op refresh in het budget menu om de toegevoegde waarde te zien.");
                        alert3.SetButton("OK", (c, ev) =>
                        {
                            Finish();
                        });
                        alert3.Show();
                        break;
                }

            }
        }
    }
}