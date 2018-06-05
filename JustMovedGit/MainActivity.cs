using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;
using Android.Content;
using Newtonsoft.Json;
using JustMovedGit.Classes;
using JustMovedGit.Activities;

namespace JustMovedGit
{
    [Activity(Label = "JustMovedGit", MainLauncher = true)]
    public class MainActivity : Activity
    {
        
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

            //DbCopyCheck.GetLocalFilePath("JustMovedDb.sqlite");
           
            budgetBtn.Click += delegate
            {
                
            };

            huishoudenBtn.Click += delegate
            {

            };

            plannenBtn.Click += delegate
            {

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
        public static void SetTitleIcon()
        {

        }
    }
}

