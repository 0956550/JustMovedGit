using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;

namespace JustMovedGit
{
    [Activity(Label = "JustMovedGit", MainLauncher = true)]
    public class MainActivity : Activity
    {
        //Path string to the Database File
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbJustMoved.db3");

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
                db.CreateTable<Food>();

                Food salad = new Food("Groente salade", "Een salade gemaakt van verscheidene groentes", "200 gram Eikenblad sla melange, 5 cherry tomaatjes, 1/4 komkommer, 1/2 paprika, 1 el olijf olie.", "Snij de groentes in stukjes en doe het bij elkaar in een kom. Voeg de olijf olie erbij en genieten maar.");

                //Store object in table
                db.Insert(salad);
            };

            getDataBtn.Click += delegate
            {
                TextView dataTxt = FindViewById<Button>(Resource.Id.dataTxt);

                //Setup connection
                var db = new SQLiteConnection(dbPath);

                //Connect to table
                var foodTable = db.Table<Food>();

                foreach(var item in foodTable)
                {
                    Food food = new Food(item.Name, item.Description, item.Ingredients, item.Procedure);
                    dataTxt.Text += food + "\n";
                }
            };
        }
    }
}

