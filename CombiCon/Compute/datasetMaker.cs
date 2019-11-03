using CombiCon.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;

namespace CombiCon.Compute
{
    class DatasetMaker
    {
        private JoyconHelper _joyconHelper;
        private StringBuilder _csv;
        private Stopwatch _timer;

        public DatasetMaker()
        {
            _joyconHelper = new JoyconHelper();
            _csv = new StringBuilder();
            _timer = new Stopwatch();
        }

        public void StoreNewPassword()
        {
            makeCsvFile("/Source/SavedPassword.csv");
        }

        public void readPasswordAttempt()
        {
            makeCsvFile("/Source/PasswordAttempt.csv");
        }

        public void makeCsvFile(string filePath)
        {
            _timer.Restart();
            _timer.Start();
            float previous = _joyconHelper.PollJoyconForDirection().Y;
            _csv.Clear();
            _csv.AppendLine("previousHit, newHit, directionChanged?");

            while (_timer.Elapsed < TimeSpan.FromSeconds(2))
            {
                    var previousHit = previous;

                    previous = _joyconHelper.PollJoyconForDirection().Y;

                    var currentHit = _joyconHelper.PollJoyconForDirection().Y.ToString();

                    var newLine = string.Format("{0},{1},{2}", previousHit, currentHit, 0);
                    Console.WriteLine(newLine);
                    _csv.AppendLine(newLine);
                Thread.Sleep(10);
            }

            File.WriteAllText(filePath, _csv.ToString());
        }
    }
}
