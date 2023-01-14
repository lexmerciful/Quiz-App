using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Quiz_App.DataModels;
using Quiz_App.Helpers;
using System;
using Google.Android.Material;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quiz_App.Activities;
using Quiz_App.Fragments;
using Google.Android.Material.Snackbar;

namespace Quiz_App.Activities
{
    [Activity(Label = "QuizActivity", Theme = "@style/AppTheme")]
    public class QuizActivity : AppCompatActivity
    {
        //Textviews & Toolbar
        AndroidX.AppCompat.Widget.Toolbar quiztoolbar;
        TextView timecountertextview;
        TextView quizpositiontextview;
        TextView questiontextview;
        TextView optionATextview;
        TextView optionBTextview;
        TextView optionCTextview;
        TextView optionDTextview;

        //Radio Button
        RadioButton optionARadio;
        RadioButton optionBRadio;
        RadioButton optionCRadio;
        RadioButton optionDRadio;

        //Button
        Button proceedquizbutton;

        //Variables
        string quiztopic;
        int QuizPosition;
        double correctAnswerCount = 0;
        List<Question> quizQuestionList = new List<Question>();
        quizhelper QuizHelper = new quizhelper();

        System.Timers.Timer countDown = new System.Timers.Timer();
        int timerCounter = 0;

        DateTime dateTime;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.quiz_page);

            ConnectViews();

            quiztopic = Intent.GetStringExtra("topic");

            //Toolbar and Actionbar setup
            SetSupportActionBar(quiztoolbar);
            SupportActionBar.Title = quiztopic + " Quiz";

            AndroidX.AppCompat.App.ActionBar actionBar = SupportActionBar;
            actionBar.SetHomeAsUpIndicator(Resource.Drawable.outline_arrowback);
            actionBar.SetDisplayHomeAsUpEnabled(true);

            BeginQuiz();
            countDown.Interval = 1000;
            countDown.Elapsed += CountDown_Elapsed;
        }

        private void CountDown_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {

            timerCounter++;

            DateTime dt = new DateTime();
            dt = dateTime.AddSeconds(-1);

            var dateDifference = dateTime.Subtract(dt);
            dateTime = dateTime - dateDifference;

            RunOnUiThread(() =>
            {
                timecountertextview.Text = dateTime.ToString("mm:ss");
            });

            //End of quiz on timeout
            if(timerCounter == 120)
            {
                countDown.Enabled = false;
                CompleteQuiz();
            }
        }

        void ConnectViews()
        {
            //Linking Views
            quiztoolbar = FindViewById<AndroidX.AppCompat.Widget.Toolbar>(Resource.Id.quiztoolbar);
            timecountertextview = FindViewById<TextView>(Resource.Id.timecountertextview);
            quizpositiontextview = FindViewById<TextView>(Resource.Id.quizpositiontextview);
            questiontextview = FindViewById<TextView>(Resource.Id.questiontextview);
            optionATextview = FindViewById<TextView>(Resource.Id.optionATextview);
            optionBTextview = FindViewById<TextView>(Resource.Id.optionBTextview);
            optionCTextview = FindViewById<TextView>(Resource.Id.optionCTextview);
            optionDTextview = FindViewById<TextView>(Resource.Id.optionDTextview);

            optionARadio = FindViewById<RadioButton>(Resource.Id.optionARadio);
            optionBRadio = FindViewById<RadioButton>(Resource.Id.optionBRadio);
            optionCRadio = FindViewById<RadioButton>(Resource.Id.optionCRadio);
            optionDRadio = FindViewById<RadioButton>(Resource.Id.optionDRadio);

            proceedquizbutton = FindViewById<Button>(Resource.Id.proceedquizbutton);
            proceedquizbutton.Click += Proceedquizbutton_Click;

            optionARadio.Click += OptionARadio_Click;
            optionBRadio.Click += OptionBRadio_Click;
            optionCRadio.Click += OptionCRadio_Click;
            optionDRadio.Click += OptionDRadio_Click;
        }

        private void Proceedquizbutton_Click(object sender, EventArgs e)
        {
            if(optionARadio.Checked == false && optionBRadio.Checked == false && optionCRadio.Checked == false && optionDRadio.Checked == false)
            {
                Snackbar.Make((View)sender, "Please choose your answer!!", Snackbar.LengthShort).Show();
            }
            //Checks option A for correct answer
            else if (optionARadio.Checked)
            {
                if(optionATextview.Text == quizQuestionList[QuizPosition - 1].Answer)
                {
                    correctAnswerCount++;
                    CorrectAnswer();
                }
                else
                {
                    WrongAnswer();
                }
            }

            //Checks option B for correct answer
            else if (optionBRadio.Checked)
            {
                if (optionBTextview.Text == quizQuestionList[QuizPosition - 1].Answer)
                {
                    correctAnswerCount++;
                    CorrectAnswer();
                }
                else
                {
                    WrongAnswer();
                }
            }

            //Checks option C for correct answer
            else if (optionCRadio.Checked)
            {
                if (optionCTextview.Text == quizQuestionList[QuizPosition - 1].Answer)
                {
                    correctAnswerCount++;
                    CorrectAnswer();
                }
                else
                {
                    WrongAnswer();
                }
            }

            //Checks option D for correct answer
            else if (optionDRadio.Checked)
            {
                if (optionDTextview.Text == quizQuestionList[QuizPosition - 1].Answer)
                {
                    correctAnswerCount++;
                    CorrectAnswer();
                }
                else
                {
                    WrongAnswer();
                }
            }
        }

        private void OptionDRadio_Click(object sender, EventArgs e)
        {
            ClearOptionsselected();
            optionDRadio.Checked = true;
        }

        private void OptionCRadio_Click(object sender, EventArgs e)
        {
            ClearOptionsselected();
            optionCRadio.Checked = true;
        }

        private void OptionBRadio_Click(object sender, EventArgs e)
        {
            ClearOptionsselected();
            optionBRadio.Checked = true;
        }

        private void OptionARadio_Click(object sender, EventArgs e)
        {
            ClearOptionsselected();
            optionARadio.Checked = true;
        }

        void ClearOptionsselected()
        {
            optionARadio.Checked = false;
            optionBRadio.Checked = false;
            optionCRadio.Checked = false;
            optionDRadio.Checked = false;
        }

        void BeginQuiz()
        {
            QuizPosition = 1;
            quizQuestionList = QuizHelper.GetQuizQuestions(quiztopic);
            questiontextview.Text = quizQuestionList[0].QuizQuestion;
            optionATextview.Text = quizQuestionList[0].OptionA;
            optionBTextview.Text = quizQuestionList[0].OptionB;
            optionCTextview.Text = quizQuestionList[0].OptionC;
            optionDTextview.Text = quizQuestionList[0].OptionD;

            quizpositiontextview.Text = "Question " + QuizPosition.ToString() + "/" + quizQuestionList.Count();

            dateTime = new DateTime();
            dateTime = dateTime.AddMinutes(2);
            timecountertextview.Text = dateTime.ToString("mm:ss");

            countDown.Enabled = true;
        }

        void CorrectAnswer()
        {
            CorrectFragment correctFragment = new CorrectFragment();
            var trans = SupportFragmentManager.BeginTransaction();
            correctFragment.Cancelable = false;
            correctFragment.Show(trans, "Correct");
            correctFragment.NextQuestion += CorrectFragment_NextQuestion;
        }

        void WrongAnswer()
        {
            WrongFragment wrongFragment = new WrongFragment(quizQuestionList[QuizPosition - 1].Answer);
            var trans = SupportFragmentManager.BeginTransaction();
            wrongFragment.Cancelable = false;
            wrongFragment.Show(trans, "Wrong");
            wrongFragment.NextQuestion += CorrectFragment_NextQuestion;

        }

        private void CorrectFragment_NextQuestion(object sender, EventArgs e)
        {
            //Next Question

            QuizPosition++;

            if(QuizPosition > quizQuestionList.Count)
            {
                CompleteQuiz();
                return;
            }

            int indx = QuizPosition - 1;
            ClearOptionsselected();

            questiontextview.Text = quizQuestionList[indx].QuizQuestion;
            optionATextview.Text = quizQuestionList[indx].OptionA;
            optionBTextview.Text = quizQuestionList[indx].OptionB;
            optionCTextview.Text = quizQuestionList[indx].OptionC;
            optionDTextview.Text = quizQuestionList[indx].OptionD;

            quizpositiontextview.Text = "Question " + QuizPosition.ToString() + "/" + quizQuestionList.Count.ToString();
        }

        void CompleteQuiz()
        {
            timecountertextview.Text = "00:00";
            countDown.Enabled = false;

            string score = correctAnswerCount.ToString() + "/" + quizQuestionList.Count.ToString();
            double percentage = (correctAnswerCount / double.Parse(quizQuestionList.Count.ToString())) * 100;
            string remarks = "";
            string image = "";

            if( percentage > 50 && percentage < 70)
            {
                remarks = "Very Good Result\nReally tried";
            }

            else if (percentage >= 70)
            {
                remarks = "Very Outsanding Result\nNailed it!!";
            }

            else if (percentage == 50)
            {
                remarks = "You Made it\nAverage result";
            }

            else if(percentage < 50)
            {
                remarks = "So sad you didn't make it, \nBut you can try again";
                image = "failed";
            }

            CompletedFragment completedFragment = new CompletedFragment(remarks, score, image);
            completedFragment.Cancelable = false;
            var trans = SupportFragmentManager.BeginTransaction();
            completedFragment.Show(trans, "Complete");

            completedFragment.GoHome += (sender, e) =>
            {
                this.Finish();
            };
        }

    }
}