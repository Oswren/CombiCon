using CombiCon.Communication;
using CombiCon.Helpers;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Threading;

namespace CombiCon
{
    class Program
    {
        private static PasscodeHelper _helper = new PasscodeHelper();
        private static List<Vector3> _savedPass;
        private static List<Vector3> _passAttempt;

        static void Main(string[] args)
        {
            MakeNewPasscode();
            CheckIfPasswordIsCorrect(_savedPass, _passAttempt);
        }

        private static void MakeNewPasscode()
        {
            _savedPass = _helper.GenerateSequence();
            Thread.Sleep(20);
            _passAttempt = _helper.GenerateSequence();
        }

        private static void CheckIfPasswordIsCorrect(List<Vector3> savedPass, List<Vector3> passAttempt)
        {
            if (_helper.PasswordAttemptIsCorrect(savedPass, passAttempt))
            {
                Console.WriteLine("Success! \n You have unlocked your imaginary safe.");
            }
            else
            {
                MessageSender sender = new MessageSender();
                sender.SendFailedLoginAttemptMessageToAll();
            }
        }
    }
}   
