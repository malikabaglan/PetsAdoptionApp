using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AdoptMe.Services;
using Xamarin.Forms;

namespace AdoptMe.ViewModels
{
    public class SignInVM : INotifyPropertyChanged
    {

        public SignInVM()
        {
            Email = "rahul@busi.in2";
            Password = "Abcd@111";

        }
        AuthenticatorService authenticatorService = new AuthenticatorService();
        private string _message;
        private bool _isBusy;
        public string Email { get; set; }
        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged();
            }
        }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    var status = await authenticatorService.Registration(Email, Password, ConfirmPassword);
                    if (status)
                        Message = "Register Successsful ";
                    else
                        Message = "Try Leter";

                    IsBusy = false;


                }
                );
            }
        }

        public ICommand LogiCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsBusy = true;
                    var status = await authenticatorService.LoginAsync(Email, Password);
                    App.AccessToken = status;
                    if (status != "")
                        Message = "Login Successsful " + status;
                    else
                        Message = "Try Leter";

                    IsBusy = false;


                }
                );
            }
        }


        /// <summary>
        /// Register the user to the API.
        /// </summary>
        /// <returns></returns>


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}