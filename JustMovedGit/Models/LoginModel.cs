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
            this.gebruikers = conn.Query<Gebruiker>("SELECT * FROM gebruiker")
                .ToList();
        }
        public Boolean checkIfAccountExists(string gebruikersNaam, string wachtwoord)
        {
            foreach(Gebruiker item in this.gebruikers)
            {
                if(gebruikersNaam.Equals(item.gebruikersnaam))
                {
                    
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public Boolean createAccount(string gebruikersNaam, string wachtwoord)
        {
            int id = 0;

            foreach(Gebruiker item in this.gebruikers)
            {
                if(Int32.Parse(item.id) > id)
                {
                    id++;
                }
                else
                {
                    Gebruiker newGebruiker = new Gebruiker(id.ToString(), gebruikersNaam, wachtwoord);
                    conn.Insert(newGebruiker);
                    return true;
                }
            }
            return false;
        }
        public Gebruiker credentialCheck(string gebruikersNaam, string wachtwoord)
        {

            foreach(Gebruiker Item in this.gebruikers)
            {
                if(gebruikersNaam.Equals(Item.gebruikersnaam) && wachtwoord.Equals(Item.wachtwoord))
                {
                    return Item;
                }
                else if(gebruikersNaam.Equals(Item.gebruikersnaam) && !wachtwoord.Equals(Item.wachtwoord))
                {
                    errorHandler(1);
                }
                else if (!gebruikersNaam.Equals(Item.gebruikersnaam) && !wachtwoord.Equals(Item.wachtwoord))
                {
                    errorHandler(2);
                }
            }
            return null;
        }
        private string errorHandler(int switchId)
        {
            switch(switchId)
            {
                case 1:
                    return "Wachtwoord is onjuist.";
                case 2:
                    return "Deze gebruiker bestaat niet check of alle ingevoerde waardes correct zijn.";
            }
            return null;
        }
    }
}