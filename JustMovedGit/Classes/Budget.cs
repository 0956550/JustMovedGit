﻿using System;
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
    class Budget
    {
        public string id { get; set; }
        public string titel { get; set; }
        public string categorie { get; set; }
        public string tip { get; set; }
        public string favorite { get; set; }
    }
}