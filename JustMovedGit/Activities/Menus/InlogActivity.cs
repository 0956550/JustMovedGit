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
        Gebruiker gebruiker;

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

            //string loginNaam = accountEditText.Text;
            //string wachtwoord = passwordEditText.Text;
            logInButton.Click += delegate
            {
                if(string.IsNullOrEmpty(accountEditText.Text))
                {
                    messageHandler(4);
                }
                else if(string.IsNullOrEmpty(passwordEditText.Text))
                {
                    messageHandler(5);
                }
                else
                {
                    gebruiker = model.credentialCheck(accountEditText.Text, passwordEditText.Text);
                    if(gebruiker == null)
                    {
                        messageHandler(6);
                    }
                    else
                    {
                        messageHandler(7);
                    }
                }
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
                    case 4:
                        Android.App.AlertDialog.Builder popupMessage4 = new AlertDialog.Builder(this);
                        AlertDialog alert4 = popupMessage4.Create();
                        alert4.SetTitle("Inloggen mislukt!");
                        alert4.SetMessage("Account naam mag niet leeg zijn bij het inloggen.");
                        alert4.SetButton("OK", (c, ev) =>
                        {
                            accountEditText.Text = "";
                            passwordEditText.Text = "";
                        });
                        alert4.Show();
                        break;
                    case 5:
                        Android.App.AlertDialog.Builder popupMessage5 = new AlertDialog.Builder(this);
                        AlertDialog alert5 = popupMessage5.Create();
                        alert5.SetTitle("Inloggen mislukt!");
                        alert5.SetMessage("Wachtwoord mag niet leeg zijn.");
                        alert5.SetButton("OK", (c, ev) =>
                        {
                            accountEditText.Text = "";
                            passwordEditText.Text = "";
                        });
                        alert5.Show();
                        break;
                    case 6:
                        Android.App.AlertDialog.Builder popupMessage6 = new AlertDialog.Builder(this);
                        AlertDialog alert6 = popupMessage6.Create();
                        alert6.SetTitle("Inloggen mislukt!");
                        alert6.SetMessage("Het wachtwoord en/of gebruikersnaam is onjuist.");
                        alert6.SetButton("OK", (c, ev) =>
                        {
                            accountEditText.Text = "";
                            passwordEditText.Text = "";
                        });
                        alert6.Show();
                        break;
                    case 7:
                        Android.App.AlertDialog.Builder popupMessage7 = new AlertDialog.Builder(this);
                        AlertDialog alert7 = popupMessage7.Create();
                        alert7.SetTitle("Inloggen gelukt!");
                        alert7.SetMessage("Door op ok te klikken zal u teruggaan naar het hoofdmenu.");
                        alert7.SetButton("OK", (c, ev) =>
                        {
                            accountEditText.Text = "";
                            passwordEditText.Text = "";
                            Intent myIntent = new Intent(this, typeof(MainActivity));
                            myIntent.PutExtra("userId", gebruiker.id.ToString());
                            SetResult(Result.Ok, myIntent);
                            Finish();
                        });
                        alert7.Show();
          
                        break;
                }
            }
        }
    }
}