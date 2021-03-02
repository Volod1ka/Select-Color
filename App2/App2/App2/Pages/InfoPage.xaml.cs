using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InfoPage : ContentPage
    {
        #region Constuctor

        public InfoPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void ButtonStart_Clicked(object sender, EventArgs e)
        {
            App._UserName = EntryUserName.Text;

            Preferences.Set("UserName", $"{App._UserName}");
            TimeSpan.TryParse($"00:{Preferences.Get("Time", "01:00")}", out GameEngine.TimerPerSeconds);

            Application.Current.MainPage = new GamePage();
        }

        private async void ButtonExit_Clicked(object sender, EventArgs e)
        {
            var result = await DisplayAlert(Languages.Language.ButtonExit, Languages.Language.ExitQuestion, Languages.Language.ButtonYes, Languages.Language.ButtonNo);

            if (result)
            {
                CloseApplication();
            }
        }

        private void EntryUserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ButtonStart.IsEnabled = EntryUserName.Text.Length > 0;
        }

        #endregion

        #region Public Methods

        public void CloseApplication()
        {
            System.Environment.Exit(0);
        }

        #endregion

        #region Protected Methods

        protected override void OnAppearing()
        {
            EntryUserName.Text = Preferences.Get("UserName", "");

            base.OnAppearing();            
        }

        #endregion
    }
}