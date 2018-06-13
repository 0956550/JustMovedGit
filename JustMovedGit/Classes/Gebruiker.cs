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

namespace JustMovedGit.Classes
{
    class Gebruiker
    {
        public string id { get; set; }
        public string gebruikersnaam { get; set; }
        public string wachtwoord { get; set; }

        public Gebruiker(string Id, string Gebruikersnaam, string Wachtwoord)
        {
            id = Id;
            gebruikersnaam = Gebruikersnaam;
            wachtwoord = Wachtwoord;
        }
        public Gebruiker()
        {

        }
    }
}