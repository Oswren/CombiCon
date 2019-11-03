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
        private double _errorLevel;
  

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

                    Thread.Sleep(15);
            }

            Console.WriteLine("\nPasscode entered.");

            return seq;
        }

        public bool PasswordAttemptIsCorrect(List<Vector3> savedPass, List<Vector3> passAttempt)
        {
            _errorLevel = 0;

            for (int i = 0; i < savedPass.Count; i++)
            {
                Vector3 delta = passAttempt[i] - savedPass[i];
                _errorLevel += Math.Sqrt(Math.Pow(delta.X, 2) + Math.Pow(delta.Y, 2) + Math.Pow(delta.Z, 2));
            }

            var isCorrect = Math.Round(_errorLevel, 2) <= 0.60;

            return isCorrect;
        }
    }
}
