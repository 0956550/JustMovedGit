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
    [Activity(Label = "Recepten", Theme = "@android:style/Theme.NoTitleBar")]
    public class ReceptenActivity : Activity
    {
        
        LoginModel loginModel = new LoginModel();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ReceptView);
            RelatieReceptModel relatieReceptModel = new RelatieReceptModel();
            string id = Intent.GetStringExtra("id");
            string userId = Intent.GetStringExtra("userId");
            
            Gebruiker gebruiker = loginModel.requestUser(userId);

            TextView titel = FindViewById<TextView>(Resource.Id.txtReceptTitel);
            TextView beschrijving = FindViewById<TextView>(Resource.Id.txtReceptBeschrijving);
            TextView bereidingstijd = FindViewById<TextView>(Resource.Id.txtReceptBereidingstijd);
            TextView ingredienten = FindViewById<TextView>(Resource.Id.txtReceptIngredienten);
            TextView voorbereiding = FindViewById<TextView>(Resource.Id.txtReceptVoorbereiding);
            TextView bereidingswijze = FindViewById<TextView>(Resource.Id.txtReceptBereidingswijze);
            TextView kosten = FindViewById<TextView>(Resource.Id.txtReceptKosten);
            ImageButton favorieten = FindViewById<ImageButton>(Resource.Id.favorietenReceptBtn);

            Models.ReceptModel model = new Models.ReceptModel();
            List<Classes.Recept> recept = model.GetSingleData(id);
            Classes.Recept hetRecept = recept[0];

            titel.Text = hetRecept.naam;
            beschrijving.Text = hetRecept.beschrijving;
            bereidingstijd.Text = hetRecept.bereidingstijd;
            ingredienten.Text = hetRecept.ingredienten;
            voorbereiding.Text = hetRecept.voorbereiding;
            bereidingswijze.Text = hetRecept.bereidingswijze;
            kosten.Text = hetRecept.kosten;

            favorieten.Click += delegate
            {
                if(relatieReceptModel.checkIfExists(userId, id))
                {
                    relatieReceptModel.deleteFavoriet(userId, id);
                    messageHandler(2);
                }
                else
                {
                    relatieReceptModel.setFavoriet(userId, id);
                    messageHandler(1);
                }
            };

            void messageHandler(int switchId)
            {
                switch (switchId)
                {
                    case 1:
                        Android.App.AlertDialog.Builder popupMessage1 = new AlertDialog.Builder(this);
                        AlertDialog alert1 = popupMessage1.Create();
                        alert1.SetTitle("Favoriet toegevoegd!");
                        alert1.SetMessage("Het recept is aan de favorieten toegevoegd van gebruiker " + gebruiker.gebruikersnaam + ".");
                        alert1.SetButton("OK", (c, ev) =>
                        {});
                        alert1.Show();
                        break;
                    case 2:
                        Android.App.AlertDialog.Builder popupMessage2 = new AlertDialog.Builder(this);
                        AlertDialog alert2 = popupMessage2.Create();
                        alert2.SetTitle("Favoriet verwijderd!");
                        alert2.SetMessage("Het recept is uit de favorieten gehaald van gebruiker " + gebruiker.gebruikersnaam + ".");
                        alert2.SetButton("OK", (c, ev) =>
                        {
                            List<Relatie_Recepten> recepten = relatieReceptModel.getFavorieten();
                            foreach (Relatie_Recepten item in recepten)
                            {
                                Console.WriteLine("test" + item.gebruiker_id + "\t" + item.recept_id);
                            }
                        });
                        alert2.Show();
                        break;
                }
            }
        }
    }
}