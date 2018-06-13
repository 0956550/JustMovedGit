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
    class LoginModel
    {
        private SQLiteConnection conn;
        public List<Gebruiker> gebruikers;

        public LoginModel()
        {
            this.conn = new SQLiteConnection(DbHandler.GetLocalFilePath("JustMovedDb.sqlite"));
            gebruikers = conn.Query<Gebruiker>("SELECT * FROM gebruiker")
                .ToList();
        }

        public Boolean checkIfAccountExists(string gebruikersNaam, string wachtwoord)
        {
            gebruikers = conn.Query<Gebruiker>("SELECT * FROM gebruiker")
                .ToList();

            foreach (Gebruiker item in gebruikers)
            {
                if(gebruikersNaam.Equals(item.gebruikersnaam))
                {
                    Console.WriteLine(item.id);
                    return true;
                }

            }
            return false;
        }

        public Boolean createAccount(string gebruikersNaam, string wachtwoord)
        {
            int id = 1;

            foreach (Gebruiker item in gebruikers)
            {
                if (id != Int32.Parse(item.id))
                {
                    Gebruiker newGebruiker = new Gebruiker(id.ToString(), gebruikersNaam, wachtwoord);
                    conn.Insert(newGebruiker);
                    return true;
                }

                else if (id == Int32.Parse(item.id))
                {
                    id++;  
                }
            }
            foreach (Gebruiker item in gebruikers)
            {
                if (id != Int32.Parse(item.id))
                {
                    Gebruiker newGebruiker = new Gebruiker(id.ToString(), gebruikersNaam, wachtwoord);
                    conn.Insert(newGebruiker);
                    return true;
                }
            }
            Console.WriteLine(id);
            return false;
        }

        public Gebruiker credentialCheck(string gebruikersNaam, string wachtwoord)
        {
            gebruikers = conn.Query<Gebruiker>("SELECT * FROM gebruiker")
                .ToList();

            foreach (Gebruiker Item in gebruikers)
            {
                if((gebruikersNaam.Equals(Item.gebruikersnaam)) && (wachtwoord.Equals(Item.wachtwoord)))
                {
                    return Item;
                }
            }
            return null;
        }
    }
}