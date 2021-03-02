using System;
using Xamarin.Forms;

namespace App2
{
    public partial class App : Application
    {
        internal static string _UserName;

        public App()
        {
            InitializeComponent();

            MainPage = /*new NavigationPage(*/new App2.Pages.MainPage();//new InfoPage()/*)*/;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
