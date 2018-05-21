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

namespace JustMovedGit
{
    class Food
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Procedure { get; set; }

        public Food(string name, string description, string ingredients, string procedure)
        {
            this.Name = name;
            this.Description = description;
            this.Ingredients = ingredients;
            this.Procedure = procedure;
        }

    }
}