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
    class Kosten
    {
        public string kosten { get; set; }
        public string beschrijving { get; set; }
        public string gebruiker_id { get; set; }
        public string is_budget { get; set; }
        

        public Kosten(string Kosteng, string Beschrijving, string gebruikerId, string isBudget)
        {
            kosten = Kosteng;
            beschrijving = Beschrijving;
            gebruiker_id = gebruikerId;
            is_budget = isBudget;
        }

        public Kosten()
        {

        }
    }  
}