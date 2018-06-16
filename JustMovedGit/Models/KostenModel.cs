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
        public List<Kosten> kosten;
        
        public KostenModel()
        {
            this.conn = new SQLiteConnection(DbHandler.GetLocalFilePath("JustMovedDb.sqlite"));
            kosten = conn.Query<Kosten>("SELECT * FROM kosten")
                .ToList();
        }

        public Boolean createKosten(string kosten, string beschrijving)
        {
            int kosten_id = 1;

            foreach (Kosten item in this.kosten)
            {
                if (kosten_id != Int32.Parse(item.kosten_id))
                {
                    Kosten newKosten = new Kosten(kosten_id.ToString(), kosten, beschrijving);
                    conn.Insert(newKosten);
                    return true;
                }

                else if (kosten_id == Int32.Parse(item.kosten_id))
                {
                    kosten_id++;
                }
            }
            foreach (Kosten item in this.kosten)
            {
                if (kosten_id != Int32.Parse(item.kosten_id))
                {
                    Kosten newKosten = new Kosten(kosten_id.ToString(), kosten, beschrijving);
                    conn.Insert(newKosten);
                    return true;
                }

            }
            
            return false;
        }

    }
}