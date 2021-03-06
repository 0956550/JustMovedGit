﻿using System;
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
    class PlannenModel
    {
        private SQLiteConnection conn;

        public PlannenModel()
        {
            this.conn = new SQLiteConnection(DbHandler.GetLocalFilePath("JustMovedDb.sqlite"));
        }

        public List<Plannen> GetAllData()
        {
            List<Plannen> plannen = conn.Query<Plannen>("SELECT * FROM plannen")
                .ToList();
            return plannen;
        }

        public List<Plannen> GetSearchData(string query)
        {
            List<Plannen> plannen = conn.Query<Plannen>("SELECT * FROM plannen")
                .Where(r => r.titel.ToLower().Contains(query))
                .ToList();
            return plannen;
        }

        public Plannen GetSingleData(string id)
        {
            List<Plannen> plannen = conn.Query<Plannen>("SELECT * FROM plannen")
                .Where(r => r.id.Equals(id))
                .ToList();
            return plannen[0];
        }
    }
}