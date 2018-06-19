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
    class KostenModel
    {
        private SQLiteConnection conn;
        
        public KostenModel()
        {
            this.conn = new SQLiteConnection(DbHandler.GetLocalFilePath("JustMovedDb.sqlite"));
        }

        public List<Kosten> GetAllData()
        {
            List<Kosten> kosten = conn.Query<Kosten>("SELECT * FROM kosten")
                .ToList();
            return kosten;
        }
        public List<Kosten> GetAllKosten(string userId)
        {
            List<Kosten> kosten = conn.Query<Kosten>("SELECT * FROM kosten WHERE is_budget = 0 AND gebruiker_id =" + userId)
                .ToList();
                return kosten;
        }

        public Kosten GetLimiet(string userId)
        {
            List<Kosten> allKosten = conn.Query<Kosten>("SELECT * FROM kosten WHERE is_budget = 1 AND gebruiker_id = " + userId)
                .ToList();

            Kosten kosten = allKosten[0];

            return kosten;
        }

        public void createNewMaand(string kosten, string userId)
        {
            conn.Query<Kosten>("DELETE FROM kosten WHERE gebruiker_id =" + userId);
            List<Kosten> allKosten = GetAllData();
            Kosten limiet = new Kosten(kosten, null, userId, "1");
            conn.Insert(limiet);
        }

        public void createKosten(string kosten, string beschrijving, string userId)
        {
            Kosten kostenPost = new Kosten(kosten, beschrijving, userId, "0");
            conn.Insert(kostenPost);
        }
        
        public Boolean checkUser(string userId)
        {
            List<Kosten> kosten = conn.Query<Kosten>("SELECT * FROM kosten WHERE gebruiker_id = " + userId + " AND is_budget = 1");

            foreach(Kosten item in kosten)
            {
                if(item.gebruiker_id == userId)
                {
                    return true;
                }
            }
            return false;
        }
    }
}