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
    class HuishoudenModel
    {
        private SQLiteConnection conn;

        public HuishoudenModel()
        {
            this.conn = new SQLiteConnection(DbHandler.GetLocalFilePath("JustMovedDb.sqlite"));
        }

        public List<Huishouden> GetAllData()
        {
            List<Huishouden> huishouden = conn.Query<Huishouden>("SELECT * FROM huishouden")
                .ToList();
            return huishouden;
        }

        public List<Huishouden> GetSearchData(string query)
        {
            List<Huishouden> huishouden = conn.Query<Huishouden>("SELECT * FROM huishouden")
                .Where(r => r.wat.ToLower().Contains(query))
                .ToList();
            return huishouden;
        }

        public Huishouden GetSingleData(string id)
        {
            List<Huishouden> huishouden = conn.Query<Huishouden>("SELECT * FROM huishouden")
                .Where(r => r.id.Equals(id))
                .ToList();
            return huishouden[0];
        }
    }
}