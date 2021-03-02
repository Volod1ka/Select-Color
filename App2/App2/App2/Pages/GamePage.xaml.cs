using App2.Pages;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App2
{
    public partial class GamePage : ContentPage
    {
        #region Variables

        private bool _start = true;
        private TimeSpan _timeToPickColor;

        #endregion

        #region Constuctor

        public GamePage()
        {
            InitializeComponent();
        }

        #endregion

        #region Protected Methods

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StartGame();
        }

        #endregion

        #region Private Methods

        private async void TimerTick()
        {
            tTimer.Text = $"{_timeToPickColor}";

            while (!_start)
            {
                if (_timeToPickColor <= TimeSpan.Zero)
                {
                    _start = !_start;
                }
                else
                {
                    _timeToPickColor = _timeToPickColor.Subtract(new TimeSpan(0, 0, 1));

                    ProgressBarTimer.Progress = (double)_timeToPickColor.TotalSeconds / GameEngine.TimerPerSeconds.TotalSeconds;
                    tTimer.Text = $"{_timeToPickColor}";

                    await Task.Delay(1000);
                }
            }

            PickerLoyout.IsEnabled = !PickerLoyout.IsEnabled;

            ActiveIndicator.IsRunning = true;

            DrawingColorLabel(Languages.Language.LabelColorResult, "Gray");
            
            await Task.Delay(3000);
            ActiveIndicator.IsRunning = false;

            DrawingColorLabel(Languages.Language.LabelColor, "Gray");
            tTimer.Text = Languages.Language.tTimer;
            ProgressBarTimer.Progress = 1;

            PickerLoyout.IsEnabled = !PickerLoyout.IsEnabled;

            await Navigation.PushModalAsync(new ResultPage());
        }

        private void ButtonYes_Clicked(object sender, EventArgs e)
        {
            CheckCorrectChoise(isTrue: true);
        }

        private void ButtonNo_Clicked(object sender, EventArgs e)
        {
            CheckCorrectChoise(isTrue: false);
        }

        private async void StartGame()
        {
            PickerLoyout.IsEnabled = !PickerLoyout.IsEnabled;

            _timeToPickColor = GameEngine.TimerPerSeconds;

            for (int i = 3; i > 0; i--)
            {
                DrawingColorLabel($"{i}", "Gray");
                await Task.Delay(1000);
            }

            GameEngine.Start();
            DrawingColorLabel(GameEngine.NowColor[0], GameEngine.NowColor[1]);

            _start = !_start;

            PickerLoyout.IsEnabled = !PickerLoyout.IsEnabled;

            TimerTick();
        }
        
        private void CheckCorrectChoise(bool isTrue)
        {
            GameEngine.CheckChoice(isTrue: isTrue);
            GameEngine.NextRenerate();
            DrawingColorLabel(GameEngine.NowColor[0], GameEngine.NowColor[1]);     
        }

        private void DrawingColorLabel(string text, string color)
        {
            LabelColor.Text = text;
            LabelColor.TextColor = System.Drawing.Color.FromName(color);
        }

        #endregion
    }
}
