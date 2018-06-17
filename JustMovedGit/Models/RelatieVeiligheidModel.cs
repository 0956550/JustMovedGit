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
    class RelatieVeiligheidModel
    {

        private SQLiteConnection conn;

        public RelatieVeiligheidModel()
        {
            conn = new SQLiteConnection(DbHandler.GetLocalFilePath("JustMovedDb.sqlite"));
        }

        public bool checkIfExists(string userId, string veiligheidId)
        {
            List<Relatie_Veiligheid> veiligheidFavorieten = conn.Query<Relatie_Veiligheid>("SELECT * FROM relatie_veiligheid")
                .ToList();

            foreach (Relatie_Veiligheid item in  veiligheidFavorieten)
            {
                Console.WriteLine("gebruiker: " + item.gebruiker_id + "+ veiligheid: " + item.veiligheid_id);
                if (userId.Equals(item.gebruiker_id.ToString()) && veiligheidId.Equals(item.veiligheid_id.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public void setFavoriet(string userId, string veiligheidId)
        {
            List<Relatie_Veiligheid> veiligheidFavorieten = conn.Query<Relatie_Veiligheid>("SELECT * FROM relatie_veiligheid")
                .ToList();
            Relatie_Veiligheid favoriet = new Relatie_Veiligheid(userId, veiligheidId);
            conn.Insert(favoriet);
        }

        public void deleteFavoriet(string userId, string veiligheidId)
        {
            conn.Query<Relatie_Veiligheid>("DELETE FROM relatie_veiligheid WHERE gebruiker_id = " + userId + " AND veiligheid_id = " + veiligheidId);
        }

        public List<Relatie_Veiligheid> getFavorieten()
        {
            List<Relatie_Veiligheid> veiligheidFavorieten = conn.Query<Relatie_Veiligheid>("SELECT * FROM relatie_veiligheid")
                .ToList();
            return veiligheidFavorieten;
        }
    }
}