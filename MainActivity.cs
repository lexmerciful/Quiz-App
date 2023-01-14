using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Google.Android.Material.Navigation;
using Quiz_App.Activities;

namespace Quiz_App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        AndroidX.AppCompat.Widget.Toolbar toolbar;
        AndroidX.DrawerLayout.Widget.DrawerLayout drawerLayout;
        NavigationView navigationview;

        LinearLayout historylayout;
        LinearLayout geographylayout;
        LinearLayout spacelayout;
        LinearLayout engineeringlayout;
        LinearLayout programminglayout;
        LinearLayout businesslayout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            toolbar = (AndroidX.AppCompat.Widget.Toolbar)FindViewById(Resource.Id.toolbar);

            //Setup Toolbar
            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Topics";
            AndroidX.AppCompat.App.ActionBar actionBar = SupportActionBar;
            actionBar.SetHomeAsUpIndicator(Resource.Drawable.menuaction);
            actionBar.SetDisplayHomeAsUpEnabled(true);

            //Layout View settings
            historylayout = (LinearLayout)FindViewById(Resource.Id.historylayout);
            geographylayout = (LinearLayout)FindViewById(Resource.Id.geographylayout);
            spacelayout = (LinearLayout)FindViewById(Resource.Id.spacelayout);
            engineeringlayout = (LinearLayout)FindViewById(Resource.Id.engineeringlayout);
            programminglayout = (LinearLayout)FindViewById(Resource.Id.programminglayout);
            businesslayout = (LinearLayout)FindViewById(Resource.Id.businesslayout);

            drawerLayout = (AndroidX.DrawerLayout.Widget.DrawerLayout)FindViewById(Resource.Id.drawerLayout);
            navigationview = (NavigationView)FindViewById(Resource.Id.navview);
            navigationview.NavigationItemSelected += Navigationview_NavigationItemSelected;

            //Click Event Handler
            historylayout.Click += Historylayout_Click;
            geographylayout.Click += Geographylayout_Click;
            spacelayout.Click += Spacelayout_Click;
            engineeringlayout.Click += Engineeringlayout_Click;
            programminglayout.Click += Programminglayout_Click;
            businesslayout.Click += Businesslayout_Click;
        }

        private void Navigationview_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            if(e.MenuItem.ItemId == Resource.Id.navhistory)
            {
                inithistory();
                drawerLayout.CloseDrawers();
            }

            else if(e.MenuItem.ItemId == Resource.Id.navgeography)
            {
                initgeography();
                drawerLayout.CloseDrawers();
            }

            else if(e.MenuItem.ItemId == Resource.Id.navspace)
            {
                initspace();
                drawerLayout.CloseDrawers();
            }

            else if(e.MenuItem.ItemId == Resource.Id.navengineering)
            {
                initengineering();
                drawerLayout.CloseDrawers();
            }

            else if(e.MenuItem.ItemId == Resource.Id.navprogramming)
            {
                initprogramming();
                drawerLayout.CloseDrawers();
            }

            else if(e.MenuItem.ItemId == Resource.Id.navbusiness)
            {
                initbusiness();
                drawerLayout.CloseDrawers();
            }
        }

        private void Businesslayout_Click(object sender, System.EventArgs e)
        {
            initbusiness();
        }

        private void Programminglayout_Click(object sender, System.EventArgs e)
        {
            initprogramming();
        }

        private void Engineeringlayout_Click(object sender, System.EventArgs e)
        {
            initengineering();
        }

        private void Spacelayout_Click(object sender, System.EventArgs e)
        {
            initspace();
        }

        private void Geographylayout_Click(object sender, System.EventArgs e)
        {
            initgeography();
        }

        private void Historylayout_Click(object sender, System.EventArgs e)
        {
            inithistory();
        }

        void inithistory()
        {
            Intent intent = new Intent(this, typeof(quizdescriptionactivity));
            intent.PutExtra("topic", "History");
            StartActivity(intent);
        }

        void initgeography()
        {
            Intent intent = new Intent(this, typeof(quizdescriptionactivity));
            intent.PutExtra("topic", "Geography");
            StartActivity(intent);
        }

        void initspace()
        {
            Intent intent = new Intent(this, typeof(quizdescriptionactivity));
            intent.PutExtra("topic", "Space");
            StartActivity(intent);
        }

        void initengineering()
        {
            Intent intent = new Intent(this, typeof(quizdescriptionactivity));
            intent.PutExtra("topic", "Engineering");
            StartActivity(intent);
        }

        void initprogramming()
        {
            Intent intent = new Intent(this, typeof(quizdescriptionactivity));
            intent.PutExtra("topic", "Programming");
            StartActivity(intent);
        }

        void initbusiness()
        {
            Intent intent = new Intent(this, typeof(quizdescriptionactivity));
            intent.PutExtra("topic", "Business");
            StartActivity(intent);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer((int)GravityFlags.Left);
                    return true;

                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
    }
}