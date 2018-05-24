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

namespace JustMovedGit.Activities
{
    [Activity(Label = "ReceptenMenuActivity")]
    public class ReceptenMenuActivity : Activity
    {

        private List<string> testList = new List<string>();
        private ListView testListView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ReceptenMenuView);

            testListView = FindViewById<ListView>(Resource.Id.menuList);

            testList.Add("Shoarma");
            testList.Add("Nasi");
            testList.Add("Spinazie schotel");
            testList.Add("Pasta bolognese");

            ArrayAdapter<string> adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, testList);

            testListView.Adapter = adapter;

            // Create your application here
        }
    }
}