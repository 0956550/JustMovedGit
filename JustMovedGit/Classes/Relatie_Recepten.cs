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
    class Relatie_Recepten
    {
        public string gebruiker_id { get; set; }
        public string recept_id { get; set; }

        public Relatie_Recepten(string gebruikerId, string receptId)
        {
            gebruiker_id = gebruikerId;
            recept_id = receptId;
        }
        public Relatie_Recepten()
        {

        }
    }
}