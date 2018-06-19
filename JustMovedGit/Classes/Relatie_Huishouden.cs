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
    class Relatie_Huishouden
    {
        public string gebruiker_id { get; set; }
        public string huishoud_id { get; set; }

        public Relatie_Huishouden(string gebruikerId, string huishoudenId)
        {
            gebruiker_id = gebruikerId;
            huishoud_id = huishoudenId;
        }
        public Relatie_Huishouden()
        {

        }
    }
}