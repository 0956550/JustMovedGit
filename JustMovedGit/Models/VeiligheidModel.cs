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
    class VeiligheidModel
    {
        private SQLiteConnection conn;

        public VeiligheidModel()
        {
            this.conn = new SQLiteConnection(DbHandler.GetLocalFilePath("JustMovedDb.sqlite"));
        }

        public List<Veiligheid> GetAllData()
        {
            List<Veiligheid> veiligheid = conn.Query<Veiligheid>("SELECT * FROM veiligheid")
                .ToList();
            return veiligheid;
        }

        public List<Veiligheid> GetSearchData(string query)
        {
            List<Veiligheid> veiligheid = conn.Query<Veiligheid>("SELECT * FROM veiligheid")
                .Where(r => r.ongeval.ToLower().Contains(query))
                .ToList();
            return veiligheid;
        }

        public List<Veiligheid> GetSingleData(string id)
        {
            List<Veiligheid> veiligheid = conn.Query<Veiligheid>("SELECT * FROM veiligheid")
                .Where(r => r.id.Equals(id))
                .ToList();
            return veiligheid;
        }

        public Boolean setFavorite(string id)
        {
            List<Veiligheid> recepten = conn.Query<Veiligheid>("UPDATE plannen SET favorite = 1 WHERE ID =" + id);
            if (Int32.Parse(GetSingleData(id)[0].favorite) == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}