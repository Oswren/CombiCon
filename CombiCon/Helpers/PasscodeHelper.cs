using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;

namespace CombiCon.Helpers
{
    public class PasscodeHelper
    {
        private static JoyconHelper _helper;
        public static Vector3 _position;
  

        public PasscodeHelper()
        {
            _helper = new JoyconHelper();
        }

        public List<Vector3> GenerateSequence()
        {
            List<Vector3> seq = new List<Vector3>();

            Console.WriteLine("Enter a passcode");

            while (true)
            {
                _position = _helper.PollJoyconForDirection();

                if (_helper.PollJoyconForButton(Joycon.Button.SHOULDER_2))
                {
                    Console.WriteLine(_position.ToString());
                    seq.Add(_position);
                }
                if (_helper.PollJoyconForButton(Joycon.Button.SHOULDER_1))
                {
                    break;
                }

                    Thread.Sleep(10);
            }

            Console.WriteLine("Thank you.");

            return seq;
        }
    }
}
