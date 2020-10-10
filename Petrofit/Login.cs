using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Petrofit
{
    [Activity(Label = "Login")]
    public class Login : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.login);

            EditText edtLogin = FindViewById<EditText>(Resource.Id.edtLogin);
            EditText edtSenha = FindViewById<EditText>(Resource.Id.edtSenha);

            Button btEntrar = FindViewById<Button>(Resource.Id.btEntrar);

            btEntrar.Click += delegate {

                var user = Autenticate(edtLogin.Text, edtSenha.Text);
                
                if(user != null)
                {
                    ISharedPreferences sharedprefs = GetSharedPreferences("prefs_file", FileCreationMode.Private);
                    sharedprefs.Edit().PutString("login", edtLogin.Text).Commit();

                    var intent = new Intent(this, typeof(MainActivity)); StartActivity(intent);

                } else Toast.MakeText(Application.Context, "Usuario ou Senha incorretos!", ToastLength.Short).Show();
            };
        }

        private User Autenticate(string login, string senha)
        {
            using (var context = new ApiContext())
            {
                if (!context.Users.Any(x => x.Login == login))
                    return null;

                var user = context.Users.Include(x => x.Role).Where(x => x.Login == login).FirstOrDefault();

                if (user.Password != senha)
                    return null;

                return user;
            }
        }
    }
}