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

namespace JustMovedGit.Activities.Menus
{
    [Activity(Label = "InlogActivity", Theme = "@android:style/Theme.NoTitleBar")]
    public class InlogActivity : Activity
    {
        LoginModel model = new LoginModel();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.UserMenu);

            EditText accountEditText = FindViewById<EditText>(Resource.Id.accountNaamEditText);
            EditText passwordEditText = FindViewById<EditText>(Resource.Id.wachtwoordEditText);
            Button logInButton = FindViewById<Button>(Resource.Id.loginButton);
            Button createAccountButton = FindViewById<Button>(Resource.Id.createAccountBtn);

            passwordEditText.InputType = Android.Text.InputTypes.TextVariationPassword |
                          Android.Text.InputTypes.ClassText;

            string loginNaam = accountEditText.Text;
            string wachtwoord = passwordEditText.Text;

            logInButton.Click += delegate
            {

            };

            createAccountButton.Click += delegate
            {
                if (string.IsNullOrEmpty(passwordEditText.Text))
                {
                    messageHandler(1);
                }
                else
                {
                    if (model.checkIfAccountExists(accountEditText.Text, passwordEditText.Text))
                    {
                        messageHandler(2);
                    }
                    else if(!model.checkIfAccountExists(accountEditText.Text, passwordEditText.Text))
                    {
                        if(model.createAccount(accountEditText.Text, passwordEditText.Text))
                        {
                            messageHandler(3);
                        }
                    }
                }
            };

            void messageHandler(int switchId)
            {
                switch (switchId)
                {
                    case 1:
                        Android.App.AlertDialog.Builder popupMessage1 = new AlertDialog.Builder(this);
                        AlertDialog alert1 = popupMessage1.Create();
                        alert1.SetTitle("Account maken mislukt!");
                        alert1.SetMessage("Het wachtwoord mag niet leeg zijn.");
                        alert1.SetButton("OK", (c, ev) =>
                        {
                            accountEditText.Text = "";
                            passwordEditText.Text = "";
                        });
                        alert1.Show();
                        break;
                    case 2:
                        Android.App.AlertDialog.Builder popupMessage2 = new AlertDialog.Builder(this);
                        AlertDialog alert2 = popupMessage2.Create();
                        alert2.SetTitle("Account maken mislukt!");
                        alert2.SetMessage("Het aanmaken van het account is mislukt, deze accountnaam bestaat al.");
                        alert2.SetButton("OK", (c, ev) =>
                        {
                            accountEditText.Text = "";
                            passwordEditText.Text = "";
                        });
                        alert2.Show();
                        break ;
                    case 3:
                        Android.App.AlertDialog.Builder popupMessage3 = new AlertDialog.Builder(this);
                        AlertDialog alert3 = popupMessage3.Create();
                        alert3.SetTitle("Account maken gelukt!");
                        alert3.SetMessage("U kunt nu inloggen.");
                        alert3.SetButton("OK", (c, ev) =>
                        {
                            accountEditText.Text = "";
                            passwordEditText.Text = "";
                        });
                        alert3.Show();
                        break;
                }
            }
        }
    }
}