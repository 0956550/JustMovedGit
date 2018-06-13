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
    public class VeiligheidActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PlannenView);

            string id = Intent.GetStringExtra("id");
            TextView titel = FindViewById<TextView>(Resource.Id.txtReceptTitel);
            TextView beschrijving = FindViewById<TextView>(Resource.Id.txtReceptBeschrijving);
            ImageButton favorieten = FindViewById<ImageButton>(Resource.Id.favorietenReceptBtn);

            Models.VeiligheidModel model = new Models.VeiligheidModel();
            List<Classes.Veiligheid> veiligheid = model.GetSingleData(id);
            Classes.Veiligheid deveiligheid = veiligheid[0];

            titel.Text = deveiligheid.ongeval;
            beschrijving.Text = deveiligheid.handeling;

            favorieten.Click += delegate
            {
                Console.WriteLine(model.setFavorite(id));
            };
        }
    }
}