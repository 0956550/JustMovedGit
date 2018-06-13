using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;
using Android.Content;
using Newtonsoft.Json;
using JustMovedGit.Classes;
using JustMovedGit.Activities;
using JustMovedGit.Activities.Menus;

namespace JustMovedGit
{
    [Activity(Label = "JustMovedGit", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar")]
    public class MainActivity : Activity
    {
        string userId = null;
        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            ImageButton budgetBtn = FindViewById<ImageButton>(Resource.Id.budgetBtn);
            ImageButton huishoudenBtn = FindViewById<ImageButton>(Resource.Id.huishoudenBtn);
            ImageButton plannenBtn = FindViewById<ImageButton>(Resource.Id.plannenBtn);
            ImageButton veiligheidBtn = FindViewById<ImageButton>(Resource.Id.veiligheidBtn);
            ImageButton receptBtn = FindViewById<ImageButton>(Resource.Id.receptBtn);
            ImageButton favorietenBtn = FindViewById<ImageButton>(Resource.Id.favorietenBtn);
            ImageButton userBtn = FindViewById<ImageButton>(Resource.Id.userButton);

            DbHandler.GetLocalFilePath("JustMovedDb.sqlite");

            userBtn.Click += delegate
            {
                Intent inlogActivity = new Intent(this, typeof(InlogActivity));
                StartActivityForResult(inlogActivity, 0);
                //this.StartActivity(inlogActivity);
            };

            budgetBtn.Click += delegate
            {
                
            };

            huishoudenBtn.Click += delegate
            {

            };

            plannenBtn.Click += delegate
            {
                Intent plannenMenuActivity = new Intent(this, typeof(PlannenMenuActivity));
                this.StartActivity(plannenMenuActivity);
            };

            veiligheidBtn.Click += delegate
            {

            };

            receptBtn.Click += delegate
            {
                Intent receptMenuActivity = new Intent(this, typeof(ReceptenMenuActivity));
                this.StartActivity(receptMenuActivity);
            };

            favorietenBtn.Click += delegate
            {

            };
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (resultCode == Result.Ok)
            {
                string stringRetFromResult = data.GetStringExtra("userId");
                userId = stringRetFromResult;
            }
        }
    }
}

