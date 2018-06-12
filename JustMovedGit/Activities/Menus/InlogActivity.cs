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

namespace JustMovedGit.Activities.Menus
{
    [Activity(Label = "InlogActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class InlogActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UserMenu);

            EditText accountEditText = FindViewById<EditText>(Resource.Id.accountNaamEditText);
            EditText passwordEditText = FindViewById<EditText>(Resource.Id.wachtwoordEditText);

            passwordEditText.InputType = Android.Text.InputTypes.TextVariationPassword |
                          Android.Text.InputTypes.ClassText;
            // Create your application here
        }
    }
}