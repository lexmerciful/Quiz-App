using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Firebase;
using Firebase.Firestore;
using Java.Util;
using Quiz_App.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz_App.Activities
{
    [Activity(Label = "quizdescriptionactivity", Theme = "@style/AppTheme")]
    public class quizdescriptionactivity : AppCompatActivity
    {

        TextView quiztopictext;
        TextView quizdescriptiontext;
        ImageView quizimage;
        Button startquizbutton;

        //Variables
        string quiztopic;

        //Firebase
        FirebaseFirestore database;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.selected_topic);

            quiztopictext = FindViewById<TextView>(Resource.Id.quiztopictext);
            quizdescriptiontext = FindViewById<TextView>(Resource.Id.quizdescriptiontext);
            quizimage = FindViewById<ImageView>(Resource.Id.quizimage);
            startquizbutton = FindViewById<Button>(Resource.Id.startquizbutton);

            //database = AppDataHelper.GetFirestore();

            quiztopic = Intent.GetStringExtra("topic");
            quiztopictext.Text = quiztopic;

            quizimage.SetImageResource(getimage(quiztopic));

            quizhelper quizHelper = new quizhelper();
            quizdescriptiontext.Text = quizHelper.Gettopicdescription(quiztopic);

            startquizbutton.Click += Startquizbutton_Click;
        }

        private void Startquizbutton_Click(object sender, EventArgs e)
        {
            //HashMap userMap = new HashMap();
            //userMap.Put("email", quiztopic);
            //userMap.Put("fullname", "Lexxx");
            //DocumentReference userReference = database.Collection("users").Document();

            //userReference.Set(userMap);

            Intent intent = new Intent(this, typeof(QuizActivity));
            intent.PutExtra("topic", quiztopic);
            StartActivity(intent);
            Finish();
        }

        int getimage(string topic)
        {
            int imageint = 0;

            if(topic == "History")
            {
                imageint = Resource.Drawable.history;
            }
            else if(topic == "Space")
            {
                imageint = Resource.Drawable.space;
            }
            else if(topic == "Geography")
            {
                imageint = Resource.Drawable.geography;
            }
            else if (topic == "Engineering")
            {
                imageint = Resource.Drawable.engineering;
            }
            else if (topic == "Programming")
            {
                imageint = Resource.Drawable.programming;
            }
            else if(topic == "Business")
            {
                imageint = Resource.Drawable.business;
            }

            return imageint;
        }

        
    }
}