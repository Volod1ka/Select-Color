using System;

namespace App2
{
    internal static class GameEngine
    {
        #region Variables

        public static string[] NowColor { get; private set; }
        public static uint AllChoice { get; private set; }
        public static uint CorrectChoice { get; private set; }
        private static string[] _colors;
        public static TimeSpan TimerPerSeconds;

        #endregion

        #region Constuctor

        static GameEngine()
        {
            _colors = new string[]
            {
                "Red",
                "Blue",
                "Black",
                "Yellow",
                "Pink",
                "Brown",
                "Purple",
                "Orange",
                "Green",
                "Aqua",
                "Silver"
            };

            Restart();
        }

        #endregion

        #region Public Methods

        public static float GetResult()
        {
            float result = (float)Math.Round(((float)CorrectChoice / AllChoice * 100), 2);
            result = float.IsNaN(result) ? 0 : result;

            return result;
        }

        public static void Start()
        {
            Restart();
            NextRenerate();
        }

        public static bool CheckChoice(bool isTrue)
        {
            bool result = isEqualsColor() == isTrue;

            if (result)
            {
                CorrectChoice++;
            }

            AllChoice++;

            return result;
        }

        public static void NextRenerate()
        {
            Random random = new Random();
            int countColor = 2;

            for (int i = 0; i < countColor; i++)
            {
                if ((i == 1) && (random.Next(0, 2) == 1))
                {
                    NowColor[i] = NowColor[Math.Max(0, i - 1)];
                }
                else
                {
                    NowColor[i] = _colors[random.Next(0, 11)];
                }
            }
        }

        #endregion

        #region Private Methods

        private static void Restart()
        {
            NowColor = new string[2];
            //TimerPerSeconds = new TimeSpan(0, 1, 0);
            CorrectChoice = AllChoice = 0;
        }

        private static bool isEqualsColor()
        {
            return NowColor[0] == NowColor[1];
        }

        #endregion
    }
}
