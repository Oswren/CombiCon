using CombiCon.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CombiCon.Compute
{
    class datasetMaker
    {
        private JoyconHelper _joyconHelper;
        private StringBuilder _csv;
        private Stopwatch _timer;

        public datasetMaker()
        {
            _joyconHelper = new JoyconHelper();
            _csv = new StringBuilder();
            _timer = new Stopwatch();
        }

        public void makeCsvFile()
        {
            _timer.Start();

            while (_timer.Elapsed < TimeSpan.FromSeconds(10))
            {
                var firstRow = _joyconHelper.PollJoyconForDirection().X.ToString();
                var secondRow = "0";

                var newLine = string.Format("{0},{1}", firstRow, secondRow);
                Console.WriteLine(newLine);
                _csv.AppendLine(newLine);
            }

            File.WriteAllText("/Source/dataset.csv", _csv.ToString());
        }
    }
}
