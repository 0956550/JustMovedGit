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
    class BudgetModel
    {
        private SQLiteConnection conn;

        public BudgetModel()
        {
            this.conn = new SQLiteConnection(DbHandler.GetLocalFilePath("JustMovedDb.sqlite"));
        }

        public List<Budget> GetAllData()
        {
            List<Budget> budget = conn.Query<Budget>("SELECT * FROM budget")
                .ToList();
            return budget;
        }

        public List<Budget> GetSearchData(string query)
        {
            List<Budget> budget = conn.Query<Budget>("SELECT * FROM budget")
                .Where(r => r.titel.ToLower().Contains(query))
                .ToList();
            return budget;
        }

        public List<Budget> GetSingleData(string id)
        {
            List<Budget> budget = conn.Query<Budget>("SELECT * FROM budget")
                .Where(r => r.id.Equals(id))
                .ToList();
            return budget;
        }

        public Boolean setFavorite(string id)
        {
            List<Budget> budget = conn.Query<Budget>("UPDATE budget SET favorite = 1 WHERE ID =" + id);
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