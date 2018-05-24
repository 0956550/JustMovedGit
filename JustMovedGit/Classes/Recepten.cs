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
    class Recepten
    {
        public int Id { get; }
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public string Bereidingstijd { get; set; }
        public string Ingredienten { get; set; }
        public string Voorbereiding { get; set; }
        public string Bereidingswijze { get; set; }

        public Recepten(int id, string naam, string beschrijving, string bereidingstijd, string ingredienten, string voorbereiding, string bereidingswijze)
        {
            this.Id = id;
            this.Naam = naam;
            this.Beschrijving = beschrijving;
            this.Bereidingstijd = bereidingstijd;
            this.Ingredienten = Ingredienten;
            this.Voorbereiding = voorbereiding;
            this.Bereidingswijze = bereidingswijze;
        }

        public Recepten()
        {

        }
    }
}