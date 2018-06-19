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
using JustMovedGit.Classes;
using JustMovedGit.Models;
using JustMovedGit.Activities;

namespace JustMovedGit.Activities.Items
{
    [Activity(Label = "BudgettonewmaandActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class NewMaandActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.BudgetInvoerView);
            string userId = Intent.GetStringExtra("userId");
            Button kosteninputbtn = FindViewById<Button>(Resource.Id.StartMaandbtn);
            EditText budgetinputtxt = FindViewById<EditText>(Resource.Id.BudgetInputEditText);
            LoginModel loginModel = new LoginModel();
            KostenModel model = new KostenModel();



            kosteninputbtn.Click += delegate
            {
                if (string.IsNullOrEmpty(budgetinputtxt.Text))
                {
                    messageHandler(1);
                }
                else if ((Convert.ToDouble(budgetinputtxt.Text)) <= 0)
                {
                    messageHandler(2);
                }
                else
                {
                    model.createNewMaand(budgetinputtxt.Text, userId);
                    List<Kosten> kosten = model.GetAllData();
                    foreach(Kosten item in kosten)
                    {
                        Console.WriteLine(item.kosten);
                    }
                    messageHandler(3);
                }

            };

            void messageHandler(int switchId)
            {
                switch (switchId)
                {
                    case 1:
                        Android.App.AlertDialog.Builder popupMessage1 = new AlertDialog.Builder(this);
                        AlertDialog alert1 = popupMessage1.Create();
                        alert1.SetTitle("Budget invoeren mislukt!");
                        alert1.SetMessage("Er moet een budget ingevoerd worden!");
                        alert1.SetButton("OK", (c, ev) =>
                        {
                            budgetinputtxt.Text = "";

                        });
                        alert1.Show();
                        break;
                    case 2:
                        Android.App.AlertDialog.Builder popupMessage2 = new AlertDialog.Builder(this);
                        AlertDialog alert2 = popupMessage2.Create();
                        alert2.SetTitle("Budget invoeren mislukt!");
                        alert2.SetMessage("Het ingevoerde budget moet een waarde hoger zijn dan nul!");
                        alert2.SetButton("OK", (c, ev) =>
                        {
                            budgetinputtxt.Text = "";
                        });
                        alert2.Show();
                        break;
                    case 3:
                        Android.App.AlertDialog.Builder popupMessage3 = new AlertDialog.Builder(this);
                        AlertDialog alert3 = popupMessage3.Create();
                        alert3.SetTitle("Nieuwe maand gestart!");
                        alert3.SetMessage("Door op ok te klikken zal u teruggaan naar het budgetmeter menu.");
                        alert3.SetButton("OK", (c, ev) =>
                        {
                            Finish();
                        });
                        alert3.Show();
                        break;
                }
            }
        }
    }
}