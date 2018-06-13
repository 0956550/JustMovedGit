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
    public class BudgetActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BudgetView);

            string id = Intent.GetStringExtra("id");
            TextView titel = FindViewById<TextView>(Resource.Id.txtBudgetTitel);
            TextView beschrijving = FindViewById<TextView>(Resource.Id.txtBudgetTip);
            ImageButton favorieten = FindViewById<ImageButton>(Resource.Id.favorietenReceptBtn);

            Models.BudgetModel model = new Models.BudgetModel();
            List<Classes.Budget> budget = model.GetSingleData(id);
            Classes.Budget hetBudget = budget[0];

            titel.Text = hetBudget.titel;
            beschrijving.Text = hetBudget.tip;


        }
    }
}