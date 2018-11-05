using Android.Graphics;
using LoginApp;
using System;
using System.IO;
using Xamarin.Forms;

namespace Test1
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void OnButtonClicked(object sender, System.EventArgs e) {

            if (!String.IsNullOrEmpty(_entryLogin.Text) && !String.IsNullOrEmpty(_entryPassword.Text)){
          
                if (!FieldValidation.CheckLogin(_entryLogin.Text) || !FieldValidation.CheckPassword(_entryPassword.Text))
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("Login Error", "Incorrect Login or Password", "OK");
                    });
          
                }else LoadProgressBar();
            }

            
        }



        private void LoadProgressBar()
        {
            _buttonLogin.IsEnabled = false;
            _progressBar.IsVisible = true;
            _progressBar.Progress = 0;
            _progressBar.ProgressTo(.99, 3000, Easing.Linear);
            Device.StartTimer(TimeSpan.FromSeconds(3), OnTimerTick);

        }

        private bool OnTimerTick()
        {
            _progressBar.IsVisible = false;
            ToSecondForm();
            return false;
        }

        private async void ToSecondForm()
        {
            _buttonLogin.IsEnabled = true;
            await Navigation.PushModalAsync(new NewsForm());
        }

    }
}
