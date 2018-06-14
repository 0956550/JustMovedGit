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
    class RelatieReceptModel
    {

        private SQLiteConnection conn;
        private List<Relatie_Recepten> receptFavorieten;

        public RelatieReceptModel()
        {
            conn = new SQLiteConnection(DbHandler.GetLocalFilePath("JustMovedDb.sqlite"));
        }
        public bool setFavoriet(string userId, string receptId)
        {
            receptFavorieten = conn.Query<Relatie_Recepten>("SELECT * FROM relatie_recepten")
                .ToList();

            foreach (Relatie_Recepten item in receptFavorieten)
            {
                if (userId.Equals(item.gebruiker_id) && receptId.Equals(item.recept_id))
                {
                    return false;
                }
            }
            Relatie_Recepten favoriet = new Relatie_Recepten(userId, receptId);
            conn.Insert(favoriet);
            return true;
        }
        public void deleteFavoriet(string userId, string receptId)
        {
            conn.Query<Relatie_Recepten>("DELETE FROM relatie_recepten WHERE gebruiker_id = " + userId + " AND recept_id = " + receptId);
        }
        public List<Relatie_Recepten> getFavorieten()
        {
            receptFavorieten = conn.Query<Relatie_Recepten>("SELECT * FROM relatie_recepten")
                .ToList();
            return receptFavorieten;
        }
    }
}