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
    class Relatie_Veiligheid
    {
        public string gebruiker_id { get; set; }
        public string veiligheid_id { get; set; }

        public Relatie_Veiligheid(string gebruikerId, string veiligheidId)
        {
            gebruiker_id = gebruikerId;
            veiligheid_id = veiligheidId;
        }
        public Relatie_Veiligheid()
        {

        }
    }
}