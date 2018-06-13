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
    [Activity(Label = "", Theme = "@android:style/Theme.NoTitleBar")]
    public class HuishoudenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.HuishoudenView);

            string id = Intent.GetStringExtra("id");
            TextView titel = FindViewById<TextView>(Resource.Id.txtHuishoudenBeschrijving);
            TextView categorie = FindViewById<TextView>(Resource.Id.txtHuishoudenCategorie);
            TextView benodigdheden = FindViewById<TextView>(Resource.Id.txtHuishoudenBenodigdheden);
            TextView handeling = FindViewById<TextView>(Resource.Id.txtHuishoudenHandeling);
            ImageButton favorieten = FindViewById<ImageButton>(Resource.Id.favorietenReceptBtn);

            Models.HuishoudenModel model = new Models.HuishoudenModel();
            List<Classes.Huishouden> huishouden = model.GetSingleData(id);
            Classes.Huishouden hetHuishouden = huishouden[0];

            titel.Text = hetHuishouden.wat;
            categorie.Text = hetHuishouden.categorie;
            benodigdheden.Text = hetHuishouden.benodigdheden;
            handeling.Text = hetHuishouden.handeling;

        }
    }
}