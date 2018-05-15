using Android.App;
using Android.Widget;
using Android.OS;

namespace JustMovedGit
{
    [Activity(Label = "JustMovedGit", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //test comment
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
        }
    }
}

