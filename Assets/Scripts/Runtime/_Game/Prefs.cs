using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK
{
    public static class Prefs
    {
        // Prefs Keys
        private const string _Highscore = "Highscore";

        public static float Highscore
        {
            get => PlayerPrefs.GetFloat(_Highscore, 0.0f);
            set => PlayerPrefs.SetFloat(_Highscore, value);
        }
    }
}