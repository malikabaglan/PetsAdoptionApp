using System;
using System.Collections.Generic;
using AdoptMe.ViewModels;
using Xamarin.Forms;

namespace AdoptMe.Views
{
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
         
            InitializeComponent();
            WelcomePageVM welcomePageVM = new WelcomePageVM();
            BindingContext = welcomePageVM;
        }
    }
}
