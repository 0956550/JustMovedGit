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

namespace JustMovedGit.Activities.Items
{
    [Activity(Label = "Recepten", Theme = "@android:style/Theme.NoTitleBar")]
    public class ReceptenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ReceptView);

            string id = Intent.GetStringExtra("id");
            
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
                Console.WriteLine(model.setFavorite(id));
            };
        }
    }
}