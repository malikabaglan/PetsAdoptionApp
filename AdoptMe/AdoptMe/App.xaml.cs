using System;
using AdoptMe.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdoptMe
{
    public partial class App : Application
    {
        public static string AccessToken = "";
        public App()
        {
            InitializeComponent();

          MainPage = new NavigationPage(new SignInView());
          //  MainPage = new NavigationPage(new WelcomePage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
