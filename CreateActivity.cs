using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XA1_NeWSqlite1
{
    [Activity(Label = "CreateActivity")]
    public class CreateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_create);

            var username = FindViewById<EditText>(Resource.Id.username);
            var password = FindViewById<EditText>(Resource.Id.password);
            var mobile = FindViewById<EditText>(Resource.Id.mobile);

            var cancel = FindViewById<Button>(Resource.Id.cancel);
            var create = FindViewById<Button>(Resource.Id.create);
            create.Click += delegate
            {
                if (username.Text != "" && password.Text != "")
                {
                    var user = new UserOperations.Users()
                    {
                        Username = username.Text,
                        Password = password.Text,
                        Mobile = mobile.Text,                       
                    };
                    var sq = new UserOperations();
                    sq.InsertUser(user);
                    Intent i = new Intent(this, typeof(LoginActivity));
                    StartActivity(i);
                }
                else
                {
                    Toast.MakeText(this, " UserName or Password is empty", ToastLength.Short).Show();
                }
            };
          
            cancel.Click += delegate
            {
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
            };
        }
    }
}