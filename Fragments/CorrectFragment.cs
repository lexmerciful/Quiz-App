using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz_App.Fragments
{
    public class CorrectFragment : AndroidX.Fragment.App.DialogFragment
    {
        Button correctbutton;

        public event EventHandler NextQuestion;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.correct, container, false);

            correctbutton = (Button)view.FindViewById(Resource.Id.correctbutton);
            correctbutton.Click += Correctbutton_Click;

            return view;
        }

        private void Correctbutton_Click(object sender, EventArgs e)
        {
            this.Dismiss();
            NextQuestion?.Invoke(this, new EventArgs());
        }
    }
}