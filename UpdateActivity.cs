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
    [Activity(Label = "UpdateActivity")]
    public class UpdateActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_update);

            var uid = FindViewById<TextView>(Resource.Id.uid);

            var username = FindViewById<EditText>(Resource.Id.username);
            var password = FindViewById<EditText>(Resource.Id.password);
            var mobile = FindViewById<EditText>(Resource.Id.mobile);
          

            var cancel = FindViewById<Button>(Resource.Id.cancel);
            var update = FindViewById<Button>(Resource.Id.update);
            var delete = FindViewById<Button>(Resource.Id.delete);

            uid.Text = Intent.GetStringExtra("Id");
            var sq = new UserOperations();
            var user = sq.GetUser(Convert.ToInt32(uid.Text));

            username.Text = user.Username;
            password.Text = user.Password;
            mobile.Text = user.Mobile;
         
            update.Click += delegate
            {
                if (username.Text != "" && password.Text != "")
                {

                    user.Username = username.Text;
                    user.Password = password.Text;
                    user.Mobile = mobile.Text;                   

                    var sq = new UserOperations();
                    sq.UpdateUser(user);
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
                Intent i = new Intent(this, typeof(ShowActivity));
                i.PutExtra("Id", user.Id + "");
                StartActivity(i);
            };
            delete.Click += delegate
            {
                var sq = new UserOperations();
                sq.DeleteUser(user);
                Intent i = new Intent(this, typeof(LoginActivity));
                StartActivity(i);
            };

        }
    }
}