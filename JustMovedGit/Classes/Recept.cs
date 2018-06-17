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
    class Recept
    {
        public string bereidingstijd { get; set; }
        public string bereidingswijze { get; set; }
        public string beschrijving { get; set; }
        public string id { get; set; }
        public string ingredienten { get; set; }
        public string kosten { get; set; }
        public string naam { get; set; }
        public string voorbereiding { get; set; }
    }
}