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
    [Activity(Label = "Budgettoinput", Theme = "@android:style/Theme.NoTitleBar")]
    public class BudgettoinputActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BudgetInvoerView);

        }
    }
}