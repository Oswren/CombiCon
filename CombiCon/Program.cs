using CombiCon.Helpers;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;

namespace CombiCon
{
    class Program
    {
        public static Vector3 _position;
        private static JoyconHelper _helper = new JoyconHelper();

        static void Main(string[] args)
        {

            Vector3 newTick;
            List<Vector3> newSeq = new List<Vector3>();

            while (true)
            {
                _position = _helper.PollJoyconForDirection();

                newTick = new Vector3( (int)Math.Floor(_position.X * 4), (int)Math.Floor(_position.Y * 4), (int)Math.Floor(_position.Z * 4));

                foreach (var item in newSeq)
                {
                    if (item.Equals(newTick))
                    {
                        _helper.VibrateJoycon(1.0f, 100);
                    }
                }

                if (_helper.PollJoyconForButton(Joycon.Button.SHOULDER_2))
                {
                    Console.WriteLine(newTick.ToString());
                    newSeq.Add(newTick);
                }

                Thread.Sleep(10);
            }
        }
    }
}
