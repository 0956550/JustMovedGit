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

        public RelatieReceptModel()
        {
            conn = new SQLiteConnection(DbHandler.GetLocalFilePath("JustMovedDb.sqlite"));
        }

        public bool checkIfExists(string userId, string receptId)
        {
            List<Relatie_Recepten> receptFavorieten = conn.Query<Relatie_Recepten>("SELECT * FROM relatie_recepten")
                .ToList();

                
            foreach (Relatie_Recepten item in receptFavorieten)
            {
                Console.WriteLine("gebruiker: " + item.gebruiker_id + "+ recept: " + item.recept_id);
                if (userId.Equals(item.gebruiker_id.ToString()) && receptId.Equals(item.recept_id.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public void setFavoriet(string userId, string receptId)
        {
            List<Relatie_Recepten> receptFavorieten = conn.Query<Relatie_Recepten>("SELECT * FROM relatie_recepten")
                .ToList();
            Relatie_Recepten favoriet = new Relatie_Recepten(userId, receptId);
            conn.Insert(favoriet);
        }

        public void deleteFavoriet(string userId, string receptId)
        {
            conn.Query<Relatie_Recepten>("DELETE FROM relatie_recepten WHERE gebruiker_id = " + userId + " AND recept_id = " + receptId);
        }

        public List<Recept> getFavorieten(string userId)
        {
            ReceptModel model = new ReceptModel();

            List<Relatie_Recepten> relatieReceptFavorieten = conn.Query<Relatie_Recepten>("SElECT * FROM relatie_recepten WHERE gebruiker_id = " + userId)
                .ToList();

            List<Recept> receptFavorieten = new List<Recept>();

            foreach(Relatie_Recepten item in relatieReceptFavorieten)
            {
                receptFavorieten.Add(model.GetSingleData(item.recept_id));
            }

            return receptFavorieten;
        }

    }
}