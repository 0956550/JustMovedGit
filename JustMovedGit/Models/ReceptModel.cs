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
using JustMovedGit.Classes;
using SQLite;

namespace JustMovedGit.Models
{
    class ReceptModel
    {
        private SQLiteConnection conn;

        public ReceptModel()
        {
            this.conn = new SQLiteConnection(DbHandler.GetLocalFilePath("JustMovedDb.sqlite"));
        }

        public List<Recept> GetAllData(string input)
        {
            List<Recept> recepten = conn.Query<Recept>("SELECT * FROM recepten")
                .Where(r => r.naam.ToLower().Contains(input))
                .ToList();
            return recepten;
        }
    }
}