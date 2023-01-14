using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiz_App.Fragments
{
    public class WrongFragment : AndroidX.Fragment.App.DialogFragment
    {

        string correctAnswer;
        Button nextbutton;
        TextView correctanswertextview;

        public event EventHandler NextQuestion;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public WrongFragment (string answer)
        {
            correctAnswer = answer;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            View view = inflater.Inflate(Resource.Layout.wrong, container, false);
            nextbutton = (Button)view.FindViewById(Resource.Id.nextbutton);
            correctanswertextview = (TextView)view.FindViewById(Resource.Id.correctanswertextview);

            correctanswertextview.Text = correctAnswer;

            nextbutton.Click += Nextbutton_Click;

            return view;
        }

        private void Nextbutton_Click(object sender, EventArgs e)
        {
            this.Dismiss();
            NextQuestion?.Invoke(this, new EventArgs());
        }
    }
}