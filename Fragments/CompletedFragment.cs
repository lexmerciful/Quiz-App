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
    public class CompletedFragment : AndroidX.Fragment.App.DialogFragment
    {

        ImageView thisimage;
        TextView scoretext;
        TextView remarktext;
        Button gohomebutton;

        string remark, score, image;

        public CompletedFragment (string _remark, string _score, string _image)
        {
            remark = _remark;
            score = _score;
            image = _image;
        }

        public event EventHandler GoHome;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);

            View view = inflater.Inflate(Resource.Layout.completed, container, false);
            thisimage = (ImageView)view.FindViewById(Resource.Id.thisimage);
            scoretext = (TextView)view.FindViewById(Resource.Id.scoretext);
            remarktext = (TextView)view.FindViewById(Resource.Id.remarktext);
            gohomebutton = (Button)view.FindViewById(Resource.Id.gohomebutton);

            gohomebutton.Click += Gohomebutton_Click;

            remarktext.Text = remark;
            scoretext.Text = score;

            if(image == "failed")
            {
                thisimage.SetImageResource(Resource.Drawable.sad);
            }

            return view;
        }

        private void Gohomebutton_Click(object sender, EventArgs e)
        {
            this.Dismiss();
            GoHome?.Invoke(this, new EventArgs());
        }
    }
}