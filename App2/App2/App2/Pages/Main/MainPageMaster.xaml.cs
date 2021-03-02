using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageMaster : ContentPage
    {
        #region Variables

        public ListView ListView;

        #endregion

        #region Constuctor

        public MainPageMaster()
        {
            InitializeComponent();
        }

        #endregion

        #region Protected Methods

        protected override void OnAppearing()
        {
            TimePicker.Items.Clear();
            TimePicker.Items.Add("1:00");
            TimePicker.Items.Add("0:50");
            TimePicker.Items.Add("0:30");
            TimePicker.Items.Add("0:15");

            LanguagePicker.Items.Clear();
            LanguagePicker.Items.Add("Українська");

            LoadSettings();
            base.OnAppearing();
        }

        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            Preferences.Set("Time", $"{TimePicker.Items[TimePicker.SelectedIndex < 0 ? 0 : TimePicker.SelectedIndex]}");
            Preferences.Set("Language", $"{LanguagePicker.Items[LanguagePicker.SelectedIndex < 0 ? 0 : LanguagePicker.SelectedIndex]}");
            
            DisplayAlert(Languages.Language.DisplayAlertSettingsTitle, Languages.Language.DisplayAlertSettingsMessage, Languages.Language.DisplayAlertSettingsCancel);       
        }

        private void ButtonRestart_Clicked(object sender, EventArgs e)
        {
            TimePicker.SelectedIndex = 0;
            LanguagePicker.SelectedIndex = 0;

            ButtonSave_Clicked(sender, e);
        }

        private int FindSettings(string find, ref Picker picker)
        {
            int selectedItem = 0;

            if (find != "")
            {
                int counter = 0;

                foreach (var item in picker.Items)
                {
                    if (item == find)
                    {
                        break;
                    }

                    counter++;
                }

                selectedItem = counter > picker.Items.Count ? 0 : counter;
            }

            return selectedItem;
        }

        private void LoadSettings()
        {
            TimePicker.SelectedIndex = FindSettings(Preferences.Get("Time", ""), ref TimePicker);
            LanguagePicker.SelectedIndex = FindSettings(Preferences.Get("Language", ""), ref LanguagePicker);
        }

        #endregion
    }
}