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
    class RelatieHuishoudenModel
    {

        private SQLiteConnection conn;

        public RelatieHuishoudenModel()
        {
            conn = new SQLiteConnection(DbHandler.GetLocalFilePath("JustMovedDb.sqlite"));
        }

        public bool checkIfExists(string userId, string huishoudenId)
        {
            List<Relatie_Huishouden> veiligheidFavorieten = conn.Query<Relatie_Huishouden>("SELECT * FROM relatie_huishouden")
                .ToList();

            foreach (Relatie_Huishouden item in  veiligheidFavorieten)
            {
                Console.WriteLine("gebruiker: " + item.gebruiker_id + "+ huishouden: " + item.huishouden_id);
                if (userId.Equals(item.gebruiker_id.ToString()) && huishoudenId.Equals(item.huishouden_id.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        public void setFavoriet(string userId, string huishoudenId)
        {
            List<Relatie_Huishouden> veiligheidFavorieten = conn.Query<Relatie_Huishouden>("SELECT * FROM relatie_huishouden")
                .ToList();
            Relatie_Huishouden favoriet = new Relatie_Huishouden(userId, huishoudenId);
            conn.Insert(favoriet);
        }

        public void deleteFavoriet(string userId, string huishoudenId)
        {
            conn.Query<Relatie_Huishouden>("DELETE FROM relatie_huishouden WHERE gebruiker_id = " + userId + " AND huishouden_id = " + huishoudenId);
        }

        public List<Relatie_Huishouden> getFavorieten()
        {
            List<Relatie_Huishouden> huishoudenFavorieten = conn.Query<Relatie_Huishouden>("SELECT * FROM relatie_huishouden")
                .ToList();
            return huishoudenFavorieten;
        }
    }
}