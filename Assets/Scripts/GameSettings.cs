using System;
using System.Linq;
using System.Xml;
using UnityEngine;

namespace DefaultNamespace
{
    public class GameSettings
    {
        public int life;
        public int timer;
        public int maxCombo;

        private string settings;
        public GameSettings(string settings)
        {
            this.settings = settings;
            
            ReadSettings(settings);
        }

        private void ReadSettings(string settings)
        {
            string[] lines = settings.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

            string[] values = new string[lines.Length];
            
            for (int i = 0; i < lines.Length; i++)
            {
                var columns = lines[i].Split(',').Select(j => j.Trim()).ToList();

               values[i] = columns[1];
            }
            int.TryParse(values[1], out life);
            int.TryParse(values[2], out timer);
            int.TryParse(values[3], out maxCombo);

            Debug.Log($"Test read csv: {life} {timer} {maxCombo}");
        }
    }
}