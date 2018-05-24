using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;
using Android.Content;
using Newtonsoft.Json;
using JustMovedGit.Classes;
using JustMovedGit.Activities;

namespace JustMovedGit
{
    [Activity(Label = "JustMovedGit", MainLauncher = true)]
    public class MainActivity : Activity
    {
        //Path string to the Database File
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbJustMoved.db3");

        //Test Data, global acces for testing.
        Recepten shoarma = new Recepten(1, "Shoarma", "Een shoarma gerecht voor 4 personen met shoarma en aardappel.", " +- 5/10 min", "-600g shoarma -450g aardappelschijfjes -250g fijngesneden andijvie -125g creme fraiche -gember siroop -1 paprika", "Maak de andijvie nat met de gember siroop in een kom, snij de paprika in lange plakjes. Plaats de andijvie op de borden.", "Bak de shoarma en de aardappelschijfjes in dezelfde pan gaar. Voeg op het laatst de creme fraiche toe.");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);


            //Find button by id and make a Button variable. Set ID name in xml test
            Button storeDataBtn = FindViewById<Button>(Resource.Id.storeDataBtn);
            Button getDataBtn = FindViewById<Button>(Resource.Id.getDataBtn);

            //Button action on click
            storeDataBtn.Click += delegate
            {

                //Setup connection
                var db = new SQLiteConnection(dbPath);

                //Creates table with the layout of the Food class
                db.CreateTable<Recepten>();

                

                //Store object in table
                db.Insert(shoarma);
            };

            getDataBtn.Click += delegate
            {
                
                Intent intent = new Intent(this, typeof(ReceptenMenuActivity));
                intent.PutExtra("shoarma", JsonConvert.SerializeObject(shoarma));

                this.StartActivity(intent);

                //Setup connection
                var db = new SQLiteConnection(dbPath);

                //Connect to table
                var foodTable = db.Table<Recepten>();
            };
        }
    }
}

