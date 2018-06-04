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

            //DbCopyCheck.GetLocalFilePath("JustMovedDb.sqlite");

            //Find button by id and make a Button variable. Set ID name in xml test
            /*
            Button receptenMenu = FindViewById<Button>(Resource.Id.storeDataBtn);
            Button huishoudenMenu = FindViewById<Button>(Resource.Id.getDataBtn);
            Button budgetMenu = FindViewById<Button>(Resource.Id.storeDataBtn);
            Button veiligheidMenu = FindViewById<Button>(Resource.Id.getDataBtn);

            //Button action on click
            storeDataBtn.Click += delegate
            {
                
            };

            getDataBtn.Click += delegate
            {

            };
            */
        }
    }
}

