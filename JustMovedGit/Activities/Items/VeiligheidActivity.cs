﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using JustMovedGit.Models;
using JustMovedGit.Classes;
using Android.Widget;

namespace JustMovedGit.Activities.Items
{
    [Activity(Label = "", Theme = "@android:style/Theme.NoTitleBar")]
    public class VeiligheidActivity : Activity
    {

        LoginModel loginModel = new LoginModel();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PlannenView);
            RelatieVeiligheidModel relatieVeiligheidModel = new RelatieVeiligheidModel();

            string id = Intent.GetStringExtra("id");
            string userId = Intent.GetStringExtra("userId");

            TextView titel = FindViewById<TextView>(Resource.Id.txtReceptTitel);
            TextView beschrijving = FindViewById<TextView>(Resource.Id.txtReceptBeschrijving);
            ImageButton favorieten = FindViewById<ImageButton>(Resource.Id.favorietenReceptBtn);

            Models.VeiligheidModel model = new Models.VeiligheidModel();
            Veiligheid veiligheid = model.GetSingleData(id);

            titel.Text = veiligheid.ongeval;
            beschrijving.Text = veiligheid.handeling;

            favorieten.Click += delegate
            {
                if (string.IsNullOrEmpty(userId))
                {
                    messageHandler(3, null);
                }
                else
                {
                    if (relatieVeiligheidModel.checkIfExists(userId, id))
                    {
                        relatieVeiligheidModel.deleteFavoriet(userId, id);
                        messageHandler(2, loginModel.requestUser(userId));
                    }
                    else
                    {
                        relatieVeiligheidModel.setFavoriet(userId, id);
                        messageHandler(1, loginModel.requestUser(userId));
                    }
                }
            };

            void messageHandler(int switchId, Gebruiker gebruiker)
            {
                switch (switchId)
                {
                    case 1:
                        Android.App.AlertDialog.Builder popupMessage1 = new AlertDialog.Builder(this);
                        AlertDialog alert1 = popupMessage1.Create();
                        alert1.SetTitle("Favoriet toegevoegd!");
                        alert1.SetMessage("Het plan is aan de favorieten toegevoegd van gebruiker " + gebruiker.gebruikersnaam + ".");
                        alert1.SetButton("OK", (c, ev) =>
                        { });
                        alert1.Show();
                        break;
                    case 2:
                        Android.App.AlertDialog.Builder popupMessage2 = new AlertDialog.Builder(this);
                        AlertDialog alert2 = popupMessage2.Create();
                        alert2.SetTitle("Favoriet verwijderd!");
                        alert2.SetMessage("Het plan is uit de favorieten gehaald van gebruiker " + gebruiker.gebruikersnaam + ".");
                        alert2.SetButton("OK", (c, ev) =>
                        {
                        });
                        alert2.Show();
                        break;
                    case 3:
                        Android.App.AlertDialog.Builder popupMessage3 = new AlertDialog.Builder(this);
                        AlertDialog alert3 = popupMessage3.Create();
                        alert3.SetTitle("Favoriet toevoegen mislukt!");
                        alert3.SetMessage("U moet ingelogd zijn om gebruik te maken van deze functie.");
                        alert3.SetButton("OK", (c, ev) =>
                        { });
                        alert3.Show();
                        break;
                }
            }
        }
    }
}