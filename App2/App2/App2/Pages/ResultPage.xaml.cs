using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ResultPage : ContentPage
    {
        #region Constuctor

        public ResultPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Protected Methods

        protected override void OnAppearing()
        {
            TitleLabel.Text = $"{App._UserName}, {Languages.Language.TitleLabelResult}";
            ResultLabel.Text = $"{Languages.Language.ResultLabel1} {GameEngine.CorrectChoice} {Languages.Language.ResultLabel2} {GameEngine.AllChoice}.\n{Languages.Language.ResultLabel3} {GameEngine.GetResult()} %";

            base.OnAppearing();
        }

        #endregion

        #region Private Methods

        private void ButtonTryAgain_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private void ButtonToInfoPage_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Pages.MainPage();
        }

        #endregion
    }
}