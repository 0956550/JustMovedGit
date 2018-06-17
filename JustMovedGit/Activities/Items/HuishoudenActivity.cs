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
    [Activity(Label = "", Theme = "@android:style/Theme.NoTitleBar")]
    public class HuishoudenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HuishoudenView);

            string id = Intent.GetStringExtra("id");
            string userId = Intent.GetStringExtra("userId");
            RelatieHuishoudenModel relatieHuishoudenModel = new RelatieHuishoudenModel();
            LoginModel loginModel = new LoginModel();

            TextView titel = FindViewById<TextView>(Resource.Id.txtHuishoudenBeschrijving);
            TextView categorie = FindViewById<TextView>(Resource.Id.txtHuishoudenCategorie);
            TextView benodigdheden = FindViewById<TextView>(Resource.Id.txtHuishoudenBenodigdheden);
            TextView handeling = FindViewById<TextView>(Resource.Id.txtHuishoudenHandeling);
            ImageButton favorieten = FindViewById<ImageButton>(Resource.Id.favorietenHuishoudenBtn);

            Models.HuishoudenModel model = new Models.HuishoudenModel();
            List<Classes.Huishouden> huishouden = model.GetSingleData(id);
            Classes.Huishouden hetHuishouden = huishouden[0];

            titel.Text = hetHuishouden.wat;
            categorie.Text = hetHuishouden.categorie;
            benodigdheden.Text = hetHuishouden.benodigdheden;
            handeling.Text = hetHuishouden.handeling;

            favorieten.Click += delegate
            {
                if (string.IsNullOrEmpty(userId))
                {
                    messageHandler(3, null);
                }
                else
                {
                    if (relatieHuishoudenModel.checkIfExists(userId, id))
                    {
                        relatieHuishoudenModel.deleteFavoriet(userId, id);
                        messageHandler(2, loginModel.requestUser(userId));
                    }
                    else
                    {
                        relatieHuishoudenModel.setFavoriet(userId, id);
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
                        alert1.SetMessage("Het recept is aan de favorieten toegevoegd van gebruiker " + gebruiker.gebruikersnaam + ".");
                        alert1.SetButton("OK", (c, ev) =>
                        { });
                        alert1.Show();
                        break;
                    case 2:
                        Android.App.AlertDialog.Builder popupMessage2 = new AlertDialog.Builder(this);
                        AlertDialog alert2 = popupMessage2.Create();
                        alert2.SetTitle("Favoriet verwijderd!");
                        alert2.SetMessage("Het recept is uit de favorieten gehaald van gebruiker " + gebruiker.gebruikersnaam + ".");
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