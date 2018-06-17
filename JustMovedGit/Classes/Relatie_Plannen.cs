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
    class Relatie_Plannen
    {
        public string gebruiker_id { get; set; }
        public string plan_id { get; set; }

        public Relatie_Plannen(string gebruikerId, string planId)
        {
            gebruiker_id = gebruikerId;
            plan_id = planId;
        }
        public Relatie_Plannen()
        {

        }
    }
}