using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz_App.Helpers
{
    public static class AppDataHelper
    {
        public static FirebaseFirestore GetFirestore()
        {
            var app = FirebaseApp.InitializeApp(Application.Context);
            FirebaseFirestore database;

            if (app == null)
            {
                var options = new FirebaseOptions.Builder()
                    .SetProjectId("quizapp22-441ad")
                    .SetApplicationId("quizapp22")
                    .SetApiKey("AIzaSyDU4Sf2-o_JlvyYp49gLM_euCUGPfCVYo4")
                    .SetStorageBucket("quizapp22-441ad.appspot.com")
                    .Build();

                app = FirebaseApp.InitializeApp(Application.Context, options);
                database = FirebaseFirestore.GetInstance(app);
            }
            else
            {
                database = FirebaseFirestore.GetInstance(app);
            }

            return database;
        }
    }
}