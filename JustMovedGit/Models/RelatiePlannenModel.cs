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
    class RelatiePlannenModel
    {

        private SQLiteConnection conn;

        public RelatiePlannenModel()
        {
            conn = new SQLiteConnection(DbHandler.GetLocalFilePath("JustMovedDb.sqlite"));
        }

        public bool checkIfExists(string userId, string receptId)
        {
            List<Relatie_Plannen> plannenFavorieten = conn.Query<Relatie_Plannen>("SELECT * FROM relatie_plannen")
                .ToList();


            foreach (Relatie_Plannen item in  plannenFavorieten)
            {
                Console.WriteLine("gebruiker: " + item.gebruiker_id + "+ plan: " + item.plan_id);
                if (userId.Equals(item.gebruiker_id.ToString()) && receptId.Equals(item.plan_id.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public void setFavoriet(string userId, string planId)
        {
            List<Relatie_Plannen> plannenFavorieten = conn.Query<Relatie_Plannen>("SELECT * FROM relatie_plannen")
                .ToList();
            Relatie_Plannen favoriet = new Relatie_Plannen(userId, planId);
            conn.Insert(favoriet);
        }

        public void deleteFavoriet(string userId, string planId)
        {
            conn.Query<Relatie_Plannen>("DELETE FROM relatie_plannen WHERE gebruiker_id = " + userId + " AND plan_id = " + planId);
        }

        public List<Relatie_Plannen> getFavorieten()
        {
            List<Relatie_Plannen> plannenFavorieten = conn.Query<Relatie_Plannen>("SELECT * FROM relatie_plannen")
                .ToList();
            return plannenFavorieten;
        }
    }
}