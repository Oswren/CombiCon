using CombiCon.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

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

        public void makeCsvFile()
        {
            _timer.Start();
            float[] toCompare = new float[2];
            float previous = _joyconHelper.PollJoyconForDirection().Y;

            _csv.AppendLine("previousHit, newHit, directionChanged?");

            while (_timer.Elapsed < TimeSpan.FromSeconds(10))
            {
                toCompare[0] = previous;
                toCompare[1] = _joyconHelper.PollJoyconForDirection().Y;

                var previousHit = previous;

                previous = _joyconHelper.PollJoyconForDirection().Y;

                var currentHit = _joyconHelper.PollJoyconForDirection().Y.ToString();
                var hasDirectionChanged = "0";

                if (Math.Abs(toCompare[0] - toCompare[1]) > 0.6 || Math.Abs(toCompare[0] - toCompare[1]) < -0.6)
                {
                    hasDirectionChanged = "1";
                }

                var newLine = string.Format("{0},{1},{2}", previousHit, currentHit, hasDirectionChanged);
                Console.WriteLine(newLine);
                _csv.AppendLine(newLine);
            }

            File.WriteAllText("/Source/newDataset.csv", _csv.ToString());
        }
    }
}
