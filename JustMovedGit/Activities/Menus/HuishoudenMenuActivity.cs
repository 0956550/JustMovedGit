﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using JustMovedGit.Adapters;
using JustMovedGit.Classes;
using JustMovedGit.Models;
using JustMovedGit.Activities.Items;

namespace JustMovedGit.Activities
{
    [Activity(Label = "HuishoudenActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class HuishoudenMenuActivity : Activity
    {
            HuishoudenModel model = new HuishoudenModel();

            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.MenuView);
                ListView huishoudenMenu = FindViewById<ListView>(Resource.Id.ListView);
                LinearLayout linearLayout = FindViewById<LinearLayout>(Resource.Id.LinearLayout);
                List<Huishouden> huishouden = model.GetAllData();
                HuishoudenAdapter adapter = new HuishoudenAdapter(this, huishouden, Resource.Layout.ReceptMenuListview);
                huishoudenMenu.Adapter = adapter;
                EditText searchBar = FindViewById<EditText>(Resource.Id.searchBar);

                huishoudenMenu.ItemClick += (s, e) =>
                {
                    Intent huishoudenActivity = new Intent(this, typeof(HuishoudenActivity));
                    huishoudenActivity.PutExtra("id", adapter.GetHuishouden(e.Position).id);
                    this.StartActivity(huishoudenActivity);
                };

                searchBar.TextChanged += searchBar_TextChanged;

                void searchBar_TextChanged(object sender, EventArgs e)
                {
                    string query = searchBar.Text.ToLower();
                    List<Huishouden> searchHuishouden = model.GetSearchData(query);
                    adapter = new HuishoudenAdapter(this, searchHuishouden, Resource.Layout.ReceptMenuListview);
                    huishoudenMenu.Adapter = adapter;
                };
            }
        }
    
}
