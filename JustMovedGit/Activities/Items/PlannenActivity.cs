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
    public class PlannenActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.PlannenView);

            string id = Intent.GetStringExtra("id");
            TextView titel = FindViewById<TextView>(Resource.Id.txtReceptTitel);
            TextView beschrijving = FindViewById<TextView>(Resource.Id.txtReceptBeschrijving);
            ImageButton favorieten = FindViewById<ImageButton>(Resource.Id.favorietenReceptBtn);

            Models.PlannenModel model = new Models.PlannenModel();
            List<Classes.Plannen> plannen = model.GetSingleData(id);
            Classes.Plannen hetPlan = plannen[0];

            titel.Text = hetPlan.titel;
            beschrijving.Text = hetPlan.tip;

            favorieten.Click += delegate
            {
                Console.WriteLine(model.setFavorite(id));
            };
        }
    }
}